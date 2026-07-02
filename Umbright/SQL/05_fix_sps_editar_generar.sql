-- ============================================================================
-- FIX 1: pa_sel_um_requisicion_recurrenteId
--   Quita el JOIN con sg_usuario (puede no existir en SCM).
--   nombre_responsable se retorna como el mismo usuario_responsable.
-- FIX 2: pa_gen_um_requisicion_desde_recurrente
--   Elimina @PNumeroNuevo OUTPUT. El VB llama con Ingresa y luego
--   consulta el número con pa_sel_um_requisicion_last_numero.
-- FIX 3: nuevo SP pa_sel_um_requisicion_last_numero
--   Retorna el último número de requisición generado desde una plantilla.
-- BD: SCM | Schema: flexline
-- ============================================================================

USE [SCM]
GO

-- ----------------------------------------------------------------------------
-- FIX 1: pa_sel_um_requisicion_recurrenteId sin JOIN a sg_usuario
-- ----------------------------------------------------------------------------
ALTER PROCEDURE [flexline].[pa_sel_um_requisicion_recurrenteId]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT
        r.*,
        r.usuario_responsable AS nombre_responsable
    FROM [flexline].[um_requisicion_recurrente] r
    WHERE r.id_recurrente = @PIdRecurrente
END
GO

-- ----------------------------------------------------------------------------
-- FIX 2: pa_gen_um_requisicion_desde_recurrente sin OUTPUT
-- ----------------------------------------------------------------------------
ALTER PROCEDURE [flexline].[pa_gen_um_requisicion_desde_recurrente]
    @PIdRecurrente  INT,
    @PEmpresa       VARCHAR(25),
    @PUsuario       VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRANSACTION
    BEGIN TRY

        DECLARE @tblNumero TABLE (numero INT)
        INSERT INTO @tblNumero
            EXEC [flexline].[pa_var_um_numero_requisicion] @PEmpresa

        DECLARE @NroReq VARCHAR(25)
        SELECT @NroReq = CAST(numero AS VARCHAR(25)) FROM @tblNumero

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

        DECLARE @FechaEntrega VARCHAR(15)
        SET @FechaEntrega = CONVERT(VARCHAR(15),
            CASE
                WHEN @dia_factura IS NOT NULL
                    THEN DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), @dia_factura)
                ELSE CAST(GETDATE() AS DATE)
            END, 103)

        EXEC [flexline].[pa_ins_um_requisicion]
            @PEmpresa,
            @NroReq,
            @FechaEntrega,
            NULL,
            @observaciones,
            @proveedor,
            @PUsuario,
            @moneda,
            'NO',
            NULL,
            0,
            'N',
            'S',
            @PIdRecurrente

        DECLARE @Correlativo INT
        SELECT @Correlativo = correlativo
        FROM [flexline].[requisicion]
        WHERE empresa = @PEmpresa AND numero = @NroReq

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
            EXEC [flexline].[pa_ins_um_requisiciond]
                @PEmpresa, @Correlativo, @linea, @producto, @cant, @precio, @comentario

            DECLARE @codDist VARCHAR(50), @porcDist NUMERIC(8,2),
                    @porcEmp NUMERIC(8,2), @porcSoc NUMERIC(8,2),
                    @tipoGasto VARCHAR(25), @tipoDist VARCHAR(25)

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

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @MsgError VARCHAR(500) = ERROR_MESSAGE()
        RAISERROR('pa_gen_um_requisicion_desde_recurrente: %s', 16, 1, @MsgError)
    END CATCH
END
GO

-- ----------------------------------------------------------------------------
-- FIX 3: nuevo SP para leer el número de la última req generada
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_sel_um_requisicion_last_numero') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_sel_um_requisicion_last_numero]
GO

CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_last_numero]
    @PEmpresa       VARCHAR(25),
    @PIdRecurrente  INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT TOP 1 numero
    FROM [flexline].[requisicion]
    WHERE empresa = @PEmpresa
      AND id_recurrente_origen = @PIdRecurrente
    ORDER BY correlativo DESC
END
GO
