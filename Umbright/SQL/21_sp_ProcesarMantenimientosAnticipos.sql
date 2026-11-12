SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================================
-- flexline.sp_ProcesarMantenimientosAnticipos
-- =============================================================================
-- Para cada fila pendiente de wms_interface.lgs_transportes.dbo.
-- lgs_mantenimientos con TipoSolicitud = 'Anticipo' crea la requisicion CON
-- ANTICIPO y la lleva hasta 60 "OdeC Generada", con los mismos pasos que hace
-- Umbright (frmRequisiciones). Las filas TipoSolicitud = 'Requisición' las
-- sigue procesando flexline.sp_ProcesarMantenimientosARequisicion, sin cambios.
--
-- Datos de la requisicion: igual que sp_ProcesarMantenimientosARequisicion
-- (empresa LOGISERV, proveedor por NIT, producto, CC/Item, dos fases sin
-- MSDTC, idempotencia por ReferenciaExterna 'MANT-<id>').
--
-- Anticipo, como Umbright (pa_ins_um_requisicion / pa_upd_um_requisicion_anticipo):
--   TipoComprobante = 'SI', TotalBimoneda = MontoTotal (anticipo por el total,
--   minimo 100), SUPER_DR (cadena) = 'NO' y Adjuntos = 'S' al generar la OC.
--
-- Usuarios: Solicitante y Aprobador traen la cuenta de Office; se buscan en
-- BDFlexline.flexline.sg_usuario.cuenta_office (usuario activo y unico).
-- Si no se encuentra un usuario unico, la fila queda con error y pendiente.
--
-- Estados (mismo recorrido que una OC hecha a mano en Umbright):
--     0  Grabado                    Solicitante
--    10  Pendiente de Revision      Solicitante
--    20  Revisada                   Aprobador  (+ usuario_reviso del CON_CCOSTO)
--    30  Pendiente de Cotizaciones  Aprobador
--    40  Cotizando                  @usuario_compras
--    50  Generar OdeC               @usuario_compras  (+ proveedor, cotizacion, precio)
--    60  OdeC Generada              @usuario_compras  (+ anticipo: Adjuntos = 'S')
--
-- Pendiente = TipoSolicitud 'Anticipo', Requisicion NULL, EstadoAnticipo NULL
-- y FechaCarga >= @anticipos_desde. Al terminar, el origen queda con
-- Requisicion = correlativo y EstadoAnticipo = 'Anticipo Procesado'.
-- =============================================================================

CREATE PROCEDURE [flexline].[sp_ProcesarMantenimientosAnticipos]
AS
BEGIN
    SET NOCOUNT ON;

    -- ---- Configuracion ------------------------------------------------------
    DECLARE @empresa          VARCHAR(25)   = 'LOGISERV';
    DECLARE @usuario_compras  VARCHAR(25)   = 'ppineda';     -- registra 40 / 50 / 60
    DECLARE @producto_default VARCHAR(50)   = '0900940171';  -- "MANTENIMIENTO DE EQUIPO"
    DECLARE @anticipos_desde  DATETIME      = '20261008';    -- yyyymmdd; los anteriores no se procesan
    DECLARE @anticipo_minimo  DECIMAL(18,2) = 100;           -- mismo minimo que frmRequisiciones
    DECLARE @cotizacion       VARCHAR(100)  = 'Sin Cotizacion';

    -- ---- Variables de trabajo (una fila de lgs_mantenimientos a la vez) ----
    DECLARE @IdMantenimiento    INT,
            @Orden              VARCHAR(50),
            @TipoServicio       VARCHAR(100),
            @Placa              VARCHAR(50),
            @NIT                VARCHAR(50),
            @CentroCosto        VARCHAR(50),
            @ItemGasto          VARCHAR(50),
            @ItemProducto       VARCHAR(50),
            @MontoTotal         DECIMAL(18,2),
            @Solicitante        VARCHAR(200),
            @Aprobador          VARCHAR(200),
            @NumeroAutorizacion VARCHAR(50);

    DECLARE @PlacaGuion        VARCHAR(50),
            @Observaciones     VARCHAR(255),
            @Producto          VARCHAR(50),
            @Proveedor         VARCHAR(50),
            @Correlativo       INT,
            @Numero            VARCHAR(20),
            @ReferenciaExterna VARCHAR(40),
            @Fecha             DATETIME,
            @UsrSolicita       VARCHAR(25),
            @UsrAprueba        VARCHAR(25),
            @Usuarios          INT,
            @Cmt               VARCHAR(150),
            @ErrorMsg          NVARCHAR(4000);

    -- Lectura del remoto sin transaccion abierta (no requiere MSDTC)
    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT IdMantenimiento, Orden, TipoServicio, Placa, NIT, CentroCosto, ItemGasto, ItemProducto, MontoTotal,
               LTRIM(RTRIM(Solicitante)), LTRIM(RTRIM(Aprobador)), LTRIM(RTRIM(NumeroAutorizacion))
        FROM wms_interface.lgs_transportes.dbo.lgs_mantenimientos
        WHERE TipoSolicitud = N'Anticipo'
          AND Requisicion IS NULL
          AND EstadoAnticipo IS NULL
          AND FechaCarga >= @anticipos_desde;

    OPEN cur;
    FETCH NEXT FROM cur INTO @IdMantenimiento, @Orden, @TipoServicio, @Placa, @NIT, @CentroCosto, @ItemGasto, @ItemProducto, @MontoTotal,
                             @Solicitante, @Aprobador, @NumeroAutorizacion;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @PlacaGuion=NULL, @Observaciones=NULL, @Producto=NULL, @Proveedor=NULL,
               @Correlativo=NULL, @Numero=NULL, @ReferenciaExterna=NULL, @Fecha=NULL,
               @UsrSolicita=NULL, @UsrAprueba=NULL, @Cmt=NULL;

        SET @ReferenciaExterna = 'MANT-' + CAST(@IdMantenimiento AS VARCHAR(20));

        BEGIN TRY
            -- Idempotencia: si ya existe la requisicion de este IdMantenimiento
            -- solo se reintenta marcar el origen (Fase 2)
            SELECT TOP 1 @Correlativo = Correlativo, @Numero = Numero
            FROM flexline.Requisicion
            WHERE Empresa = @empresa AND ReferenciaExterna = @ReferenciaExterna;

            IF @Correlativo IS NULL
            BEGIN
                -- ---- Validaciones (antes de abrir la transaccion) ----
                IF ISNULL(@MontoTotal, 0) < @anticipo_minimo
                BEGIN
                    SET @ErrorMsg = N'Anticipo de ' + ISNULL(CAST(@MontoTotal AS NVARCHAR(30)), N'(nulo)')
                                  + N' menor al minimo de ' + CAST(@anticipo_minimo AS NVARCHAR(30));
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                -- Usuarios por cuenta de Office (activo y unico)
                SELECT @UsrSolicita = LEFT(MIN(u.usuario), 25), @Usuarios = COUNT(*)
                FROM BDFlexline.flexline.sg_usuario u
                WHERE u.estatus = 1
                  AND LOWER(LTRIM(RTRIM(u.cuenta_office))) = LOWER(@Solicitante);

                IF @Usuarios <> 1
                BEGIN
                    SET @ErrorMsg = N'Solicitante ' + ISNULL(@Solicitante, N'(vacio)') + N': '
                                  + CAST(@Usuarios AS NVARCHAR(10)) + N' usuarios activos con esa cuenta_office en sg_usuario';
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                SELECT @UsrAprueba = LEFT(MIN(u.usuario), 25), @Usuarios = COUNT(*)
                FROM BDFlexline.flexline.sg_usuario u
                WHERE u.estatus = 1
                  AND LOWER(LTRIM(RTRIM(u.cuenta_office))) = LOWER(@Aprobador);

                IF @Usuarios <> 1
                BEGIN
                    SET @ErrorMsg = N'Aprobador ' + ISNULL(@Aprobador, N'(vacio)') + N': '
                                  + CAST(@Usuarios AS NVARCHAR(10)) + N' usuarios activos con esa cuenta_office en sg_usuario';
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                -- Proveedor por NIT (CodLegal), igual que el SP de requisiciones
                SELECT TOP 1 @Proveedor = CtaCte
                FROM BDFlexline.flexline.ctacte
                WHERE Empresa = @empresa AND TipoCtaCte = 'PROVEEDOR' AND CodLegal = @NIT;

                IF @Proveedor IS NULL
                BEGIN
                    SET @ErrorMsg = N'No se encontro proveedor con NIT ' + ISNULL(@NIT,'(nulo)') + N' en empresa ' + @empresa;
                    RAISERROR(@ErrorMsg, 16, 1);
                END

                -- ============== FASE 1 (transaccional, un solo servidor) ==============
                BEGIN TRANSACTION;

                SET @Fecha = GETDATE();

                -- Placa con guion despues de la primera letra ("C413BYP" -> "C-413BYP")
                SET @PlacaGuion = LEFT(@Placa, 1) + '-' + SUBSTRING(@Placa, 2, LEN(@Placa));

                SET @Observaciones = LEFT('ANTICIPO - Prefactura ' + ISNULL(@Orden,'') + ' - ' + ISNULL(@TipoServicio,'')
                                          + ' - Unidad ' + @PlacaGuion, 255);

                SET @Producto = ISNULL(NULLIF(LTRIM(RTRIM(@ItemProducto)), ''), @producto_default);

                -- Correlativo/Numero siguiente, mismo candado que el SP de requisiciones
                SELECT @Correlativo = ISNULL(MAX(Correlativo), 0) + 1
                FROM flexline.Requisicion WITH (UPDLOCK, HOLDLOCK)
                WHERE Empresa = @empresa;
                SET @Numero = RIGHT('0000000000' + CAST(@Correlativo AS VARCHAR(10)), 10);

                -- 0 Grabado (por el solicitante). Anticipo: TipoComprobante 'SI' +
                -- monto en TotalBimoneda; cadena 'NO' (SUPER_DR) como en la pantalla
                INSERT INTO flexline.Requisicion
                    (Empresa, Numero, Correlativo, Fecha, Proveedor, FechaEntrega, LugarEntrega,
                     Observaciones, Moneda, Total, TipoComprobante, TotalBimoneda, SUPER_DR,
                     Costeo, Estado, UsuarioGrabo, FechaGrabo, ReferenciaExterna)
                VALUES
                    (@empresa, @Numero, @Correlativo, @Fecha, @Proveedor, @Fecha, 'Logistica de Servicios',
                     @Observaciones, 'QUETZALES', @MontoTotal, 'SI', @MontoTotal, 'NO',
                     'N', '0', @UsrSolicita, @Fecha, @ReferenciaExterna);

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
                VALUES (@empresa, @Numero, 0, @Fecha, @UsrSolicita, NULL);

                -- 10 Pendiente de Revision (solicitante)
                SET @Cmt = LEFT('Anticipo de mantenimiento, prefactura ' + ISNULL(@Orden, ''), 150);
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @UsrSolicita, 10, @Cmt;

                -- 20 / 30 Revisada y aprobada (aprobador), igual que la pantalla:
                -- usuario_reviso en la distribucion del centro de costo
                UPDATE dbo.requisicionCodigo
                   SET usuario_reviso = @UsrAprueba, fecha_reviso = GETDATE()
                 WHERE empresa = @empresa AND correlativo = @Correlativo AND tipo = 'CON_CCOSTO';

                SET @Cmt = LEFT('Autorizada en SharePoint ' + ISNULL(@NumeroAutorizacion, ''), 150);
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @UsrAprueba, 20, @Cmt;
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @UsrAprueba, 30, @Cmt;

                -- 40 / 50 / 60 compras, mismo orden que frmRequisiciones al generar
                -- la OC: estado, proveedor, precios, anticipo
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 40, NULL;
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 50, NULL;
                EXEC flexline.pa_upd_um_requisicion_proveedor @empresa, @Numero, @Proveedor, @cotizacion;
                EXEC flexline.pa_upd_um_requisiciond_precio @empresa, @Numero, 1, @Producto, @MontoTotal, 1;
                EXEC flexline.pa_upd_um_requisicion_anticipo @empresa, @Numero, @usuario_compras, 'SI';
                EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 60, NULL;

                COMMIT TRANSACTION;
                -- ============== fin FASE 1 ==============
            END

            -- ============== FASE 2 (fuera de cualquier transaccion) ==============
            UPDATE wms_interface.lgs_transportes.dbo.lgs_mantenimientos
            SET Requisicion    = CAST(@Correlativo AS VARCHAR(20)),
                EstadoAnticipo = N'Anticipo Procesado'
            WHERE IdMantenimiento = @IdMantenimiento;

        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
            -- Un registro con error no detiene el lote; queda pendiente
            PRINT 'Error procesando anticipo IdMantenimiento ' + CAST(@IdMantenimiento AS VARCHAR) + ': ' + ERROR_MESSAGE();
        END CATCH

        FETCH NEXT FROM cur INTO @IdMantenimiento, @Orden, @TipoServicio, @Placa, @NIT, @CentroCosto, @ItemGasto, @ItemProducto, @MontoTotal,
                                 @Solicitante, @Aprobador, @NumeroAutorizacion;
    END

    CLOSE cur;
    DEALLOCATE cur;
END
GO
