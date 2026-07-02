-- ============================================================================
-- SP: pa_gen_um_requisicion_desde_recurrente
-- BD destino: SCM  |  Schema: flexline
--
-- Genera una requisición nueva a partir de una plantilla recurrente.
-- Usa exclusivamente los SPs existentes del sistema para insertar.
-- Actualiza ultima_generacion y proxima_generacion en la plantilla.
-- Retorna el número de la nueva requisición en @PNumeroNuevo.
--
-- Notas de compatibilidad verificadas contra los SPs existentes:
--   pa_var_um_numero_requisicion  → retorna SELECT (no OUTPUT), se captura con tabla temporal
--   pa_ins_um_requisiciond        → usa @PCorrelativo INT (no numero), se obtiene post-insert
--   pa_ins_um_requisicion_costo   → empresa, correlativo, producto, codigo, porcentaje, linea
--   pa_ins_um_requisicion_marca   → empresa, correlativo, producto, codigo, porcentaje,
--                                    porcEmpresa, porcSocio, linea  (NO tiene @PBU)
--   pa_ins_um_requisicion_gasto   → empresa, correlativo, producto, codigo, porcentaje, tipo, linea
--   pa_ins_um_requisicion_canal   → empresa, correlativo, canal, porcentaje
--
-- Prerrequisito: ejecutar 01_tablas.sql y 00_alter_sp_existente.sql antes.
--
-- Uso:
--   DECLARE @NroNuevo VARCHAR(25)
--   EXEC flexline.pa_gen_um_requisicion_desde_recurrente 1,'EMPRESA','usuario',@NroNuevo OUTPUT
--   SELECT @NroNuevo
-- ============================================================================

USE [SCM]
GO

CREATE PROCEDURE [flexline].[pa_gen_um_requisicion_desde_recurrente]
    @PIdRecurrente  INT,
    @PEmpresa       VARCHAR(25),
    @PUsuario       VARCHAR(25),
    @PNumeroNuevo   VARCHAR(25) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRANSACTION
    BEGIN TRY

        -- ----------------------------------------------------------------
        -- 1. Obtener número de requisición
        --    pa_var_um_numero_requisicion retorna SELECT, no OUTPUT
        -- ----------------------------------------------------------------
        DECLARE @tblNumero TABLE (numero INT)
        INSERT INTO @tblNumero
            EXEC [flexline].[pa_var_um_numero_requisicion] @PEmpresa

        DECLARE @NroReq VARCHAR(25)
        SELECT @NroReq = CAST(numero AS VARCHAR(25)) FROM @tblNumero

        -- ----------------------------------------------------------------
        -- 2. Leer header de la plantilla
        -- ----------------------------------------------------------------
        DECLARE
            @proveedor              VARCHAR(25),
            @moneda                 VARCHAR(25),
            @observaciones          VARCHAR(255),
            @dia_factura            TINYINT,
            @frecuencia             VARCHAR(20),
            @fecha_venc_recurrencia DATE,
            @proxima_actual         DATE

        SELECT
            @proveedor              = proveedor,
            @moneda                 = moneda,
            @observaciones          = observaciones,
            @dia_factura            = dia_factura_mes,
            @frecuencia             = frecuencia,
            @fecha_venc_recurrencia = fecha_venc_recurrencia,
            @proxima_actual         = proxima_generacion
        FROM [flexline].[um_requisicion_recurrente]
        WHERE id_recurrente = @PIdRecurrente
          AND empresa       = @PEmpresa

        -- ----------------------------------------------------------------
        -- 3. Calcular fecha de entrega: día de factura del mes en curso
        -- ----------------------------------------------------------------
        DECLARE @FechaEntrega VARCHAR(15)
        SET @FechaEntrega = CONVERT(VARCHAR(15),
            CASE
                WHEN @dia_factura IS NOT NULL
                    THEN DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), @dia_factura)
                ELSE CAST(GETDATE() AS DATE)
            END, 103)   -- formato dd/mm/yyyy igual que el sistema

        -- ----------------------------------------------------------------
        -- 4. Insertar header via SP existente (con los 2 params nuevos al final)
        -- ----------------------------------------------------------------
        EXEC [flexline].[pa_ins_um_requisicion]
            @PEmpresa,          -- empresa
            @NroReq,            -- numero
            @FechaEntrega,      -- fechaEntrega (VARCHAR(15))
            NULL,               -- lugarEntrega
            @observaciones,     -- observaciones
            @proveedor,         -- codigoCliente (proveedor)
            @PUsuario,          -- usuarioGrabo
            @moneda,            -- moneda
            'NO',               -- anticipo
            NULL,               -- cadena
            0,                  -- montoAnticipo
            'N',                -- costeo (afectaInventario)
            'S',                -- esRecurrente  ← param nuevo opcional
            @PIdRecurrente      -- idRecurrenteOrigen ← param nuevo opcional

        -- ----------------------------------------------------------------
        -- 5. Obtener el correlativo generado por pa_ins_um_requisicion
        --    (el SP lo calcula internamente con Max(Correlativo)+1)
        -- ----------------------------------------------------------------
        DECLARE @Correlativo INT
        SELECT @Correlativo = correlativo
        FROM [flexline].[requisicion]
        WHERE empresa = @PEmpresa AND numero = @NroReq

        -- ----------------------------------------------------------------
        -- 6. Copiar líneas y distribuciones usando los SPs existentes
        -- ----------------------------------------------------------------
        DECLARE
            @linea      INT,
            @producto   VARCHAR(25),
            @comentario VARCHAR(255),
            @cant       NUMERIC(10,2),
            @precio     NUMERIC(10,2)

        DECLARE cur_det CURSOR LOCAL FAST_FORWARD FOR
            SELECT linea, producto, comentario, cantidad, precio
            FROM [flexline].[um_requisicion_recurrente_detalle]
            WHERE id_recurrente = @PIdRecurrente
            ORDER BY linea

        OPEN cur_det
        FETCH NEXT FROM cur_det INTO @linea, @producto, @comentario, @cant, @precio

        WHILE @@FETCH_STATUS = 0
        BEGIN

            -- Línea de producto
            EXEC [flexline].[pa_ins_um_requisiciond]
                @PEmpresa, @Correlativo, @linea, @producto, @cant, @precio, @comentario

            -- Centro de costo de esta línea
            DECLARE @codDist VARCHAR(50), @porcDist NUMERIC(8,2),
                    @porcEmp NUMERIC(8,2), @porcSoc NUMERIC(8,2), @tipoGasto VARCHAR(25), @tipoDist VARCHAR(25)

            DECLARE cur_dist CURSOR LOCAL FAST_FORWARD FOR
                SELECT tipo, codigo, porcentaje, porcentaje_empresa, porcentaje_socio, tipo_gasto
                FROM [flexline].[um_requisicion_recurrente_dist]
                WHERE id_recurrente = @PIdRecurrente AND linea = @linea
                ORDER BY tipo, codigo

            OPEN cur_dist
            FETCH NEXT FROM cur_dist INTO @tipoDist, @codDist, @porcDist, @porcEmp, @porcSoc, @tipoGasto

            WHILE @@FETCH_STATUS = 0
            BEGIN
                IF @tipoDist = 'CON_CCOSTO'
                    EXEC [flexline].[pa_ins_um_requisicion_costo]
                        @PEmpresa, @Correlativo, @producto, @codDist, @porcDist, @linea

                ELSE IF @tipoDist = 'CON_MARCA'
                    EXEC [flexline].[pa_ins_um_requisicion_marca]
                        @PEmpresa, @Correlativo, @producto, @codDist, @porcDist,
                        @porcEmp, @porcSoc, @linea

                ELSE IF @tipoDist = 'CON_ITEM'
                    EXEC [flexline].[pa_ins_um_requisicion_gasto]
                        @PEmpresa, @Correlativo, @producto, @codDist, @porcDist, @tipoGasto, @linea

                FETCH NEXT FROM cur_dist INTO @tipoDist, @codDist, @porcDist, @porcEmp, @porcSoc, @tipoGasto
            END

            CLOSE cur_dist
            DEALLOCATE cur_dist

            FETCH NEXT FROM cur_det INTO @linea, @producto, @comentario, @cant, @precio
        END

        CLOSE cur_det
        DEALLOCATE cur_det

        -- Canal (no está por línea)
        DECLARE @canal VARCHAR(50), @porcCanal NUMERIC(10,4)
        DECLARE cur_canal CURSOR LOCAL FAST_FORWARD FOR
            SELECT canal, porcentaje
            FROM [flexline].[um_requisicion_recurrente_canal]
            WHERE id_recurrente = @PIdRecurrente

        OPEN cur_canal
        FETCH NEXT FROM cur_canal INTO @canal, @porcCanal

        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC [flexline].[pa_ins_um_requisicion_canal]
                @PEmpresa, @Correlativo, @canal, @porcCanal

            FETCH NEXT FROM cur_canal INTO @canal, @porcCanal
        END

        CLOSE cur_canal
        DEALLOCATE cur_canal

        -- ----------------------------------------------------------------
        -- 7. Actualizar trazabilidad en la plantilla
        -- ----------------------------------------------------------------
        DECLARE @NuevaProxima DATE
        SET @NuevaProxima = CASE @frecuencia
            WHEN 'MENSUAL'      THEN DATEADD(MONTH,  1, ISNULL(@proxima_actual, CAST(GETDATE() AS DATE)))
            WHEN 'BIMESTRAL'    THEN DATEADD(MONTH,  2, ISNULL(@proxima_actual, CAST(GETDATE() AS DATE)))
            WHEN 'TRIMESTRAL'   THEN DATEADD(MONTH,  3, ISNULL(@proxima_actual, CAST(GETDATE() AS DATE)))
            WHEN 'SEMESTRAL'    THEN DATEADD(MONTH,  6, ISNULL(@proxima_actual, CAST(GETDATE() AS DATE)))
            WHEN 'ANUAL'        THEN DATEADD(MONTH, 12, ISNULL(@proxima_actual, CAST(GETDATE() AS DATE)))
            ELSE ISNULL(@proxima_actual, CAST(GETDATE() AS DATE))
        END

        DECLARE @NuevoEstado VARCHAR(10)
        SET @NuevoEstado = CASE
            WHEN @NuevaProxima > @fecha_venc_recurrencia THEN 'VENCIDA'
            ELSE 'ACTIVA'
        END

        UPDATE [flexline].[um_requisicion_recurrente] SET
            ultima_generacion  = CAST(GETDATE() AS DATE),
            proxima_generacion = @NuevaProxima,
            estado             = @NuevoEstado
        WHERE id_recurrente = @PIdRecurrente

        SET @PNumeroNuevo = @NroReq

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SET @PNumeroNuevo = ''
        DECLARE @MsgError VARCHAR(500) = ERROR_MESSAGE()
        RAISERROR('pa_gen_um_requisicion_desde_recurrente: %s', 16, 1, @MsgError)
    END CATCH
END
GO

-- ============================================================================
-- VERIFICACION
-- ============================================================================
-- DECLARE @nro VARCHAR(25)
-- EXEC flexline.pa_gen_um_requisicion_desde_recurrente 1, 'EMPRESA', 'usuarioprueba', @nro OUTPUT
-- SELECT @nro AS NuevaRequisicion
-- ============================================================================
