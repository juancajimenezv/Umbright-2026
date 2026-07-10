-- ============================================================================
-- FIX: Reemplaza pa_ins_um_requisicion_recurrente
--      Quita el parámetro OUTPUT @PIdRecurrente que ya no se usa.
--      El INSERT ahora solo inserta; el ID se lee con
--      pa_sel_um_requisicion_recurrenteId_byCodigo.
-- BD: SCM | Schema: flexline
-- ============================================================================

USE [SCM]
GO

ALTER PROCEDURE [flexline].[pa_ins_um_requisicion_recurrente]
    @PEmpresa               VARCHAR(25),
    @PCodigo                VARCHAR(20),
    @PDescripcion           VARCHAR(200),
    @PProveedor             VARCHAR(25)     = NULL,
    @PMoneda                VARCHAR(25)     = NULL,
    @PObservaciones         VARCHAR(255)    = NULL,
    @PFechaInicio           DATE,
    @PFechaVencLicencia     DATE            = NULL,
    @PFechaVencRecurrencia  DATE,
    @PDiaFacturaMes         TINYINT         = NULL,
    @PFrecuencia            VARCHAR(20),
    @PDiasAnticipacion      INT             = 5,
    @PUsuarioResponsable    VARCHAR(25),
    @PUsuariosNotificar     VARCHAR(500)    = NULL,
    @PUsuarioCrea           VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRANSACTION
    BEGIN TRY

        DECLARE @ProximaGeneracion DATE
        SET @ProximaGeneracion = CASE @PFrecuencia
            WHEN 'MENSUAL'      THEN DATEADD(MONTH,  1, @PFechaInicio)
            WHEN 'BIMESTRAL'    THEN DATEADD(MONTH,  2, @PFechaInicio)
            WHEN 'TRIMESTRAL'   THEN DATEADD(MONTH,  3, @PFechaInicio)
            WHEN 'SEMESTRAL'    THEN DATEADD(MONTH,  6, @PFechaInicio)
            WHEN 'ANUAL'        THEN DATEADD(MONTH, 12, @PFechaInicio)
            ELSE @PFechaInicio
        END

        INSERT INTO [flexline].[um_requisicion_recurrente] (
            empresa, codigo, descripcion, proveedor, moneda, observaciones,
            fecha_inicio, fecha_venc_licencia, fecha_venc_recurrencia,
            dia_factura_mes, frecuencia, dias_anticipacion,
            usuario_responsable, usuarios_notificar,
            estado, proxima_generacion,
            usuario_creo, fecha_creo
        ) VALUES (
            @PEmpresa, @PCodigo, @PDescripcion, @PProveedor, @PMoneda, @PObservaciones,
            @PFechaInicio, @PFechaVencLicencia, @PFechaVencRecurrencia,
            @PDiaFacturaMes, @PFrecuencia, @PDiasAnticipacion,
            @PUsuarioResponsable, @PUsuariosNotificar,
            'ACTIVA', @ProximaGeneracion,
            @PUsuarioCrea, GETDATE()
        )

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @MsgError VARCHAR(500) = ERROR_MESSAGE()
        RAISERROR('pa_ins_um_requisicion_recurrente: %s', 16, 1, @MsgError)
    END CATCH
END
GO

-- ----------------------------------------------------------------------------
-- SP auxiliar: leer id_recurrente por empresa+codigo (llamado tras el INSERT)
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_sel_um_requisicion_recurrenteId_byCodigo') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_sel_um_requisicion_recurrenteId_byCodigo]
GO

CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrenteId_byCodigo]
    @PEmpresa   VARCHAR(25),
    @PCodigo    VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_recurrente
    FROM [flexline].[um_requisicion_recurrente]
    WHERE empresa = @PEmpresa AND codigo = @PCodigo
END
GO
