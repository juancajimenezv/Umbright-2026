-- ============================================================================
-- SPs de SELECT para detalle, distribuciones y canal de plantilla recurrente.
-- Estos nunca se ejecutaron en BD. Ejecutar contra SCM.
-- ============================================================================

USE [SCM]
GO

CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_det]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_detalle]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY linea
END
GO

CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_dist]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_dist]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY linea, tipo, codigo
END
GO

CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_canal]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_canal]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY canal
END
GO
