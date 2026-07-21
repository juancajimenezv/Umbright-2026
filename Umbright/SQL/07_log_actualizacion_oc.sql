-- =============================================================================
-- Tabla de auditoria para la pantalla "Actualizacion OC" (modulo Compras/Import)
-- Un solo log para todo:
--   * Apertura / cierre de periodo (HABILITA_PERIODO / CIERRA_PERIODO)
--   * Cambios de lineas (AGREGA_LINEA / ELIMINA_LINEA / MODIFICA_LINEA)
--   * Cambios de cabecera (MODIFICA_CABECERA)
-- Ubicacion: base scm, schema dbo  ->  scm.dbo.log_actualizacion_oc
-- Ejecutar UNA sola vez.
-- =============================================================================

USE scm
GO

IF NOT EXISTS (
    SELECT 1
      FROM sys.tables t
      INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
     WHERE s.name = 'dbo' AND t.name = 'log_actualizacion_oc'
)
BEGIN
    CREATE TABLE dbo.log_actualizacion_oc (
        id                  int           IDENTITY(1,1) NOT NULL,
        empresa             varchar(20)   NOT NULL,
        tipodocto           varchar(50)   NOT NULL,
        numero              varchar(10)   NOT NULL,   -- numero con ceros (10 digitos)
        correlativo         int           NULL,
        accion              varchar(20)   NOT NULL,   -- HABILITA_PERIODO, CIERRA_PERIODO, AGREGA_LINEA, ELIMINA_LINEA, MODIFICA_LINEA, MODIFICA_CABECERA
        linea               int           NULL,       -- linea afectada (NULL = cabecera / periodo)
        secuencia           int           NULL,
        producto            varchar(30)   NULL,       -- producto de la linea (contexto)
        campo               varchar(50)   NULL,       -- columna modificada
        valor_anterior      varchar(200)  NULL,
        valor_nuevo         varchar(200)  NULL,
        fecha_original      datetime      NULL,       -- fecha antes de habilitar
        periodo_original    char(6)       NULL,       -- PeriodoLibro original (aaaamm)
        fecha_habilitada    datetime      NULL,       -- fecha a la que se movio
        periodo_habilitado  char(6)       NULL,       -- periodo al que se movio
        estado              varchar(10)   NULL,       -- ABIERTA / CERRADA (solo eventos de periodo)
        usuario             varchar(50)   NOT NULL,
        fecha_hora          datetime      NOT NULL CONSTRAINT DF_log_actualizacion_oc_fh DEFAULT (getdate()),
        equipo              varchar(100)  NULL,
        aplicacion          varchar(50)   NULL,
        observacion         varchar(500)  NULL,
        CONSTRAINT PK_log_actualizacion_oc PRIMARY KEY CLUSTERED (id)
    )

    -- Historial de una orden
    CREATE INDEX IX_log_actualizacion_oc_doc
        ON dbo.log_actualizacion_oc (empresa, tipodocto, numero)

    -- Deteccion de ordenes abiertas sin cerrar (control critico)
    CREATE INDEX IX_log_actualizacion_oc_estado
        ON dbo.log_actualizacion_oc (accion, estado)

    PRINT 'Tabla scm.dbo.log_actualizacion_oc creada.'
END
ELSE
BEGIN
    PRINT 'La tabla scm.dbo.log_actualizacion_oc ya existe.'
END
GO

-- =============================================================================
-- Consultas utiles (referencia)
-- =============================================================================

-- Ordenes que quedaron ABIERTAS (periodo habilitado) y NO se han regresado:
--   SELECT * FROM scm.dbo.log_actualizacion_oc
--    WHERE accion = 'HABILITA_PERIODO' AND estado = 'ABIERTA'
--    ORDER BY fecha_hora

-- Historial completo de una orden:
--   SELECT * FROM scm.dbo.log_actualizacion_oc
--    WHERE empresa = 'DIUVA' AND tipodocto = 'ORDEN DE COMPRA' AND numero = '0000003645'
--    ORDER BY fecha_hora, linea
