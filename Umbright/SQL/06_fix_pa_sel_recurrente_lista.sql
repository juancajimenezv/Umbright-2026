-- ============================================================================
-- FIX: pa_sel_um_requisicion_recurrente y pa_sel_um_requisicion_recurrenteId
--   Cambia JOIN [flexline].[sg_usuario] por bdflexline.flexline.sg_usuario
-- BD: SCM | Schema: flexline
-- ============================================================================

USE [SCM]
GO

-- ----------------------------------------------------------------------------
-- 1. Listado de plantillas (pestaña Recurrentes)
-- ----------------------------------------------------------------------------
ALTER PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente]
    @PEmpresa VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON
    SELECT
        r.id_recurrente,
        r.codigo,
        r.descripcion,
        r.proveedor,
        r.frecuencia,
        r.dia_factura_mes,
        r.fecha_venc_licencia,
        r.fecha_venc_recurrencia,
        r.ultima_generacion,
        r.proxima_generacion,
        r.estado,
        r.usuario_responsable,
        ISNULL(u.nombre, r.usuario_responsable) AS nombre_responsable,
        r.usuarios_notificar
    FROM [flexline].[um_requisicion_recurrente] r
    LEFT JOIN bdflexline.flexline.sg_usuario u
        ON u.usuario = r.usuario_responsable
    WHERE r.empresa = @PEmpresa
    ORDER BY r.descripcion
END
GO

-- ----------------------------------------------------------------------------
-- 2. Header de plantilla por ID (usado en editar y cargar)
-- ----------------------------------------------------------------------------
ALTER PROCEDURE [flexline].[pa_sel_um_requisicion_recurrenteId]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT
        r.*,
        ISNULL(u.nombre, r.usuario_responsable) AS nombre_responsable
    FROM [flexline].[um_requisicion_recurrente] r
    LEFT JOIN bdflexline.flexline.sg_usuario u
        ON u.usuario = r.usuario_responsable
    WHERE r.id_recurrente = @PIdRecurrente
END
GO
