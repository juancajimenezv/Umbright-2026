SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================================
-- sp_ProcesarMantenimientosARequisicion
-- =============================================================================
-- Crea una Requisicion (SCM.flexline.Requisicion + RequisicionD + dbo.
-- requisicionCodigo + dbo.requisicionEstado) por cada registro pendiente en
-- wms_interface.lgs_transportes.dbo.lgs_mantenimientos (tabla de
-- mantenimiento de vehiculos de Logiserv, alimentada por un flujo externo
-- ligado a SharePoint).
--
-- Diseñado para correr en SCM (ahi viven Requisicion/RequisicionD/
-- requisicionCodigo/requisicionEstado). Usa el linked server
-- "wms_interface" (ya confirmado accesible) para leer/actualizar
-- lgs_mantenimientos, y nombrado de tres partes hacia BDFlexline.flexline.
-- ctacte / seg_usuario_centro_costo (mismo patron que usa server.js).
--
-- Confirmado contra datos reales (correlativos 3866/3867/3869, ya creados
-- por otro proceso antes de este SP):
--   - Empresa siempre 'LOGISERV' (este flujo es solo de esa empresa).
--   - Proveedor se resuelve por NIT -> ctacte.CodLegal (empresa=LOGISERV,
--     TipoCtaCte='PROVEEDOR').
--   - Producto de la linea: ItemProducto si viene poblado, si no el fijo
--     '0900940171' ("MANTENIMIENTO DE EQUIPO").
--   - requisicionCodigo lleva 2 filas: CON_CCOSTO (=CentroCosto, 100%) y
--     CON_ITEM (=ItemGasto, 100%, tipo_gasto='CON_ITEM').
--   - Placa siempre se guarda con un guion despues de la primera letra
--     (ej. "C413BYP" -> "C-413BYP") - confirmado en los 3 ejemplos reales.
--
-- [ANTICIPO] 2026-10-07: tambien se procesan las filas con
-- TipoSolicitud = 'Anticipo'. Se crean igual que una requisicion normal pero
-- marcadas con anticipo, como lo hace Umbright (frmRequisiciones /
-- pa_ins_um_requisicion):
--   - Requisicion.TipoComprobante = 'SI'   (combo "Anticipo" de la pantalla)
--   - Requisicion.TotalBimoneda   = monto del anticipo (Umbright guarda ahi
--     @PMontoAnticipo). Aqui es el MontoTotal: el anticipo es por el total.
--   - Umbright exige un anticipo de al menos 100: si es menor, el registro
--     queda con error y no se crea.
--   - Requisicion.Adjuntos NO se toca: Umbright lo pone en 'S' al generar la
--     OC (pa_upd_um_requisicion_anticipo, estado 50 -> 60). Como la pantalla
--     carga el combo desde TipoComprobante, el anticipo se mantiene al cotizar.
--   - Observaciones empiezan con 'ANTICIPO - ' para distinguirlas.
--   - Solo se toman anticipos sin EstadoAnticipo (los 'Anticipo Procesado'
--     ya se pagaron por el flujo actual) y cargados desde @anticipos_desde,
--     para no generar requisiciones de anticipos viejos ya atendidos.
--   - En el origen se llena Requisicion y EstadoAnticipo = 'Anticipo
--     Procesado' (este SP reemplaza al flujo anterior que lo marcaba).
--     FechaPago no se toca.
--
-- Dos cosas donde este SP se aparta A PROPOSITO del comportamiento real
-- observado (pendiente de confirmar con el usuario):
--   1. El texto de Observaciones en los 3 registros reales revisados NO
--      sigue un patron fijo (formatos/mayusculas distintas entre si) - aqui
--      se usa un formato propio, simple y consistente.
--   2. En los registros reales, Requisicion.Total quedo en 0 (solo
--      RequisicionD.Total tenia el monto correcto) - aqui SI se llena
--      Requisicion.Total con el monto real, por ser mas correcto.
--
-- El usuario que graba (UsuarioGrabo) queda fijo en una variable
-- (@usuario_grabo) para poder cambiarlo facilmente sin reescribir el SP.
--
-- *** SIN TRANSACCIONES DISTRIBUIDAS (MSDTC) A PROPOSITO ***
-- Primer intento de este SP hacia el UPDATE de vuelta a
-- wms_interface...lgs_mantenimientos DENTRO de la misma transaccion local
-- (junto con los INSERT en SCM) y windows fallo con:
--   "El administrador de transacciones asociado deshabilito el soporte
--    para transacciones de red o remotas" / "no pudo iniciar una
--    transaccion distribuida"
-- porque MSDTC no esta habilitado entre los servidores. La solucion aqui es
-- separar el trabajo en DOS fases que NUNCA comparten una misma
-- transaccion:
--   Fase 1 (transaccional, solo en SCM/BDFlexline - mismo servidor, no hay
--           problema de MSDTC): crea la Requisicion + detalle + distribucion
--           + bitacora, y graba el IdMantenimiento de origen en
--           Requisicion.ReferenciaExterna (formato 'MANT-<id>') para poder
--           reconocerla despues.
--   Fase 2 (fuera de cualquier transaccion, autocommit): UPDATE al servidor
--           remoto marcando la fila de origen como procesada.
-- Si la Fase 2 falla (ej. problema de red puntual), la Requisicion YA
-- quedo creada y committeada en Fase 1 - la siguiente corrida del SP NO
-- crea una Requisicion duplicada (se detecta por ReferenciaExterna), solo
-- reintenta la Fase 2 para esa fila.
-- =============================================================================


ALTER   PROCEDURE [flexline].[sp_ProcesarMantenimientosARequisicion]
AS
BEGIN
    SET NOCOUNT ON;

    -- ---- Configuracion ------------------------------------------------------
    DECLARE @usuario_grabo VARCHAR(25) = 'ppineda';  -- fijo por ahora, facil de cambiar aqui
    DECLARE @empresa       VARCHAR(25) = 'LOGISERV'; -- este flujo siempre es de Logiserv
    DECLARE @producto_default VARCHAR(50) = '0900940171'; -- "MANTENIMIENTO DE EQUIPO"
    -- [ANTICIPO] solo anticipos cargados desde esta fecha (yyyymmdd); los
    -- anteriores sin EstadoAnticipo no se tocan
    DECLARE @anticipos_desde  DATETIME = '20261008';
    DECLARE @anticipo_minimo  DECIMAL(18,2) = 100;    -- mismo minimo que frmRequisiciones

    -- ---- Variables de trabajo (una fila de lgs_mantenimientos a la vez) ----
    DECLARE @IdMantenimiento INT,
            @Orden           VARCHAR(50),
            @TipoServicio    VARCHAR(100),
            @Placa           VARCHAR(50),
            @NIT             VARCHAR(50),
            @CentroCosto     VARCHAR(50),
            @ItemGasto       VARCHAR(50),
            @ItemProducto    VARCHAR(50),
            @MontoTotal      DECIMAL(18,2),
            @TipoSolicitud   NVARCHAR(30);                -- [ANTICIPO]

    DECLARE @PlacaGuion       VARCHAR(50),
            @Observaciones    VARCHAR(255),
            @Producto         VARCHAR(50),
            @Proveedor        VARCHAR(50),
            @Correlativo      INT,
            @Numero           VARCHAR(20),
            @ReferenciaExterna VARCHAR(40),
            @Fecha            DATETIME,
            @Estado           VARCHAR(20),
            @ErrorMsg         NVARCHAR(4000),
            @EsAnticipo       BIT,                         -- [ANTICIPO]
            @TipoComprobante  VARCHAR(2),                  -- [ANTICIPO] 'SI' / 'NO'
            @MontoAnticipo    DECIMAL(18,2);               -- [ANTICIPO]

    -- Lectura del remoto - un simple SELECT, sin transaccion abierta, no
    -- dispara ningun requisito de MSDTC.
    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT IdMantenimiento, Orden, TipoServicio, Placa, NIT, CentroCosto, ItemGasto, ItemProducto, MontoTotal,
               TipoSolicitud                                                        -- [ANTICIPO]
        FROM wms_interface.lgs_transportes.dbo.lgs_mantenimientos
        WHERE Requisicion IS NULL
          AND (    TipoSolicitud = N'Requisición'
               OR (    TipoSolicitud = N'Anticipo'                                 -- [ANTICIPO]
                   AND EstadoAnticipo IS NULL
                   AND FechaCarga >= @anticipos_desde))
       -- and idsharepoint in (233,228)
        ;

    OPEN cur;
    FETCH NEXT FROM cur INTO @IdMantenimiento, @Orden, @TipoServicio, @Placa, @NIT, @CentroCosto, @ItemGasto, @ItemProducto, @MontoTotal, @TipoSolicitud;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Reset de variables de trabajo en cada vuelta (evita arrastrar
        -- valores de la fila anterior si algo falla antes de recalcularlas).
        SELECT @PlacaGuion=NULL, @Observaciones=NULL, @Producto=NULL, @Proveedor=NULL,
               @Correlativo=NULL, @Numero=NULL, @ReferenciaExterna=NULL, @Fecha=NULL, @Estado=NULL,
               @EsAnticipo=0, @TipoComprobante='NO', @MontoAnticipo=NULL;           -- [ANTICIPO]

        SET @ReferenciaExterna = 'MANT-' + CAST(@IdMantenimiento AS VARCHAR(20));

        -- [ANTICIPO] como en Umbright: TipoComprobante 'SI' + monto en TotalBimoneda
        IF @TipoSolicitud = N'Anticipo'
            SELECT @EsAnticipo = 1, @TipoComprobante = 'SI', @MontoAnticipo = @MontoTotal;

        BEGIN TRY
            -- Idempotencia: si ya existe una Requisicion creada para este
            -- IdMantenimiento (ej. la Fase 2 de una corrida anterior fallo),
            -- no se crea otra - solo se reintenta marcar el remoto.
            SELECT TOP 1 @Correlativo = Correlativo, @Numero = Numero
            FROM flexline.Requisicion
            WHERE Empresa = @empresa AND ReferenciaExterna = @ReferenciaExterna;

            IF @Correlativo IS NULL
            BEGIN
                -- [ANTICIPO] misma validacion que frmRequisiciones (monto minimo)
                IF @EsAnticipo = 1 AND ISNULL(@MontoAnticipo, 0) < @anticipo_minimo
                BEGIN
                    SET @ErrorMsg = N'Anticipo de ' + ISNULL(CAST(@MontoAnticipo AS NVARCHAR(30)), N'(nulo)')
                                  + N' menor al minimo de ' + CAST(@anticipo_minimo AS NVARCHAR(30));
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                -- ============== FASE 1 (transaccional, un solo servidor) ==============
                BEGIN TRANSACTION;

                SET @Fecha = GETDATE();

                -- Placa con guion despues de la primera letra (patron
                -- confirmado contra datos reales: "C413BYP" -> "C-413BYP").
                SET @PlacaGuion = LEFT(@Placa, 1) + '-' + SUBSTRING(@Placa, 2, LEN(@Placa));

                -- Formato propio y consistente (ver nota arriba - el real
                -- no seguia un patron fijo).
                SET @Observaciones = LEFT(CASE WHEN @EsAnticipo = 1 THEN 'ANTICIPO - ' ELSE '' END     -- [ANTICIPO]
                                          + 'Prefactura ' + ISNULL(@Orden,'') + ' - ' + ISNULL(@TipoServicio,'') + ' - Unidad ' + @PlacaGuion, 255);

                SET @Producto = ISNULL(NULLIF(LTRIM(RTRIM(@ItemProducto)), ''), @producto_default);

                -- Proveedor por NIT (ctacte no tiene columna "Nit" literal -
                -- CodLegal es el Nit, confirmado contra datos reales).
                SELECT TOP 1 @Proveedor = CtaCte
                FROM BDFlexline.flexline.ctacte
                WHERE Empresa = @empresa AND TipoCtaCte = 'PROVEEDOR' AND CodLegal = @NIT;

                IF @Proveedor IS NULL
                BEGIN
                    SET @ErrorMsg = N'No se encontro proveedor con NIT ' + ISNULL(@NIT,'(nulo)') + N' en empresa ' + @empresa;
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                -- Correlativo/Numero siguiente - mismo candado (UPDLOCK/
                -- HOLDLOCK) que usa el resto de la app.
                SELECT @Correlativo = ISNULL(MAX(Correlativo), 0) + 1
                FROM flexline.Requisicion WITH (UPDLOCK, HOLDLOCK)
                WHERE Empresa = @empresa;
                SET @Numero = RIGHT('0000000000' + CAST(@Correlativo AS VARCHAR(10)), 10);

                -- Auto-aprobacion: mismo criterio que la app web (acceso
                -- real al centro de costo usado).
                IF EXISTS (
                    SELECT 1 FROM BDFlexline.flexline.seg_usuario_centro_costo
                    WHERE usuario = @usuario_grabo AND empresa = @empresa AND centro_costo = @CentroCosto
                )
                    SET @Estado = '20';
                ELSE
                    SET @Estado = '10';

                INSERT INTO flexline.Requisicion
                    (Empresa, Numero, Correlativo, Fecha, Proveedor, FechaEntrega, LugarEntrega,
                     Observaciones, Moneda, Total, TipoComprobante, TotalBimoneda,          -- [ANTICIPO]
                     Costeo, Estado, UsuarioGrabo, FechaGrabo, ReferenciaExterna)
                VALUES
                    (@empresa, @Numero, @Correlativo, @Fecha, @Proveedor, @Fecha, 'Logistica de Servicios',
                     @Observaciones, 'QUETZALES', @MontoTotal, @TipoComprobante, @MontoAnticipo,  -- [ANTICIPO]
                     'N', @Estado, @usuario_grabo, @Fecha, @ReferenciaExterna);

                INSERT INTO flexline.RequisicionD
                    (Empresa, Correlativo, Linea, Producto, Cantidad, Precio, SubTotal, Total, Comentario)
                VALUES
                    (@empresa, @Correlativo, 1, @Producto, 1, @MontoTotal, @MontoTotal, @MontoTotal, @Observaciones);

                INSERT INTO dbo.requisicionCodigo
                    (empresa, correlativo, producto, linea, tipo, codigo, porcentaje, tipo_gasto, Porcentaje_Empresa, Porcentaje_Socio)
                VALUES
                    (@empresa, @Correlativo, @Producto, 1, 'CON_CCOSTO', @CentroCosto, 100, NULL, 0, 0);

                INSERT INTO dbo.requisicionCodigo
                    (empresa, correlativo, producto, linea, tipo, codigo, porcentaje, tipo_gasto, Porcentaje_Empresa, Porcentaje_Socio)
                VALUES
                    (@empresa, @Correlativo, @Producto, 1, 'CON_ITEM', @ItemGasto, 100, 'CON_ITEM', 0, 0);

                INSERT INTO dbo.requisicionEstado (empresa, numero, estado, fecha_grabo, usuario_grabo, comentario)
                VALUES (@empresa, @Numero, 0, @Fecha, @usuario_grabo, NULL);

                IF @Estado = '20'
                    INSERT INTO dbo.requisicionEstado (empresa, numero, estado, fecha_grabo, usuario_grabo, comentario)
                    VALUES (@empresa, @Numero, 20, @Fecha, @usuario_grabo, 'Aprobado automaticamente (acceso a centro de costo)');

                COMMIT TRANSACTION;
                -- ============== fin FASE 1 ==============
            END

            -- ============== FASE 2 (fuera de cualquier transaccion) ==============
            -- Si esto falla, la Requisicion ya quedo creada (o ya existia de
            -- una corrida anterior) - la siguiente corrida solo reintenta
            -- esta actualizacion, sin crear nada de nuevo.
            -- [ANTICIPO] los anticipos quedan como 'Anticipo Procesado' (el
            -- mismo valor que ponia el flujo anterior, que este SP reemplaza)
            UPDATE wms_interface.lgs_transportes.dbo.lgs_mantenimientos
            SET Requisicion = CAST(@Correlativo AS VARCHAR(20)),
                EstadoAnticipo = CASE WHEN @EsAnticipo = 1 THEN N'Anticipo Procesado'
                                      ELSE N'Requisición Procesada' END
            WHERE IdMantenimiento = @IdMantenimiento;

        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
            -- No se detiene el lote completo por un registro con error - se
            -- deja pendiente (o con la Requisicion ya creada pero sin
            -- marcar en el remoto) para la siguiente corrida.
            PRINT 'Error procesando IdMantenimiento ' + CAST(@IdMantenimiento AS VARCHAR) + ': ' + ERROR_MESSAGE();
        END CATCH

        FETCH NEXT FROM cur INTO @IdMantenimiento, @Orden, @TipoServicio, @Placa, @NIT, @CentroCosto, @ItemGasto, @ItemProducto, @MontoTotal, @TipoSolicitud;
    END

    CLOSE cur;
    DEALLOCATE cur;
END
GO
