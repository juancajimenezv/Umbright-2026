-- ============================================================================
-- TABLAS: Módulo Requisiciones Recurrentes
-- BD destino: SCM  |  Schema: flexline
--
-- Tablas creadas:
--   um_requisicion_recurrente          - Plantillas de requisición recurrente
--   um_requisicion_recurrente_detalle  - Líneas de producto de la plantilla
--   um_requisicion_recurrente_dist     - Distribuciones (costo/marca/gasto) unificadas en tipo
--   um_requisicion_recurrente_canal    - Distribución canal
--
-- Cambio en tabla existente:
--   requisicion  - Agregar es_recurrente e id_recurrente_origen (ambas NULL con DEFAULT)
--
-- Como deshacer:
--   DROP TABLE flexline.um_requisicion_recurrente_canal
--   DROP TABLE flexline.um_requisicion_recurrente_dist
--   DROP TABLE flexline.um_requisicion_recurrente_detalle
--   DROP TABLE flexline.um_requisicion_recurrente
--   ALTER TABLE flexline.requisicion DROP COLUMN es_recurrente, id_recurrente_origen
-- ============================================================================

USE [SCM]
GO

-- ----------------------------------------------------------------------------
-- 1. Tabla principal: plantilla de requisición recurrente
-- ----------------------------------------------------------------------------
CREATE TABLE [flexline].[um_requisicion_recurrente] (
    id_recurrente           INT IDENTITY(1,1)   NOT NULL,
    empresa                 VARCHAR(25)         NOT NULL,
    codigo                  VARCHAR(20)         NOT NULL,
    descripcion             VARCHAR(200)        NOT NULL,
    proveedor               VARCHAR(25)         NULL,
    moneda                  VARCHAR(25)         NULL,
    observaciones           VARCHAR(255)        NULL,

    -- Control de recurrencia
    fecha_inicio            DATE                NOT NULL,
    fecha_venc_licencia     DATE                NULL,
    fecha_venc_recurrencia  DATE                NOT NULL,
    dia_factura_mes         TINYINT             NULL,           -- 1-31
    frecuencia              VARCHAR(20)         NOT NULL,       -- MENSUAL|BIMESTRAL|TRIMESTRAL|SEMESTRAL|ANUAL
    dias_anticipacion       INT                 NOT NULL DEFAULT 5,

    -- Notificaciones
    usuario_responsable     VARCHAR(25)         NOT NULL,       -- FK sg_usuario.usuario
    usuarios_notificar      VARCHAR(500)        NULL,           -- "USER1,USER2,USER3"

    -- Trazabilidad
    estado                  VARCHAR(10)         NOT NULL DEFAULT 'ACTIVA', -- ACTIVA|PAUSADA|VENCIDA
    ultima_generacion       DATE                NULL,
    proxima_generacion      DATE                NULL,

    -- Auditoría
    usuario_creo            VARCHAR(25)         NULL,
    fecha_creo              DATETIME            NOT NULL DEFAULT GETDATE(),
    usuario_modifico        VARCHAR(25)         NULL,
    fecha_modifico          DATETIME            NULL,

    CONSTRAINT PK_um_requisicion_recurrente PRIMARY KEY (id_recurrente),
    CONSTRAINT UQ_um_requisicion_recurrente_codigo UNIQUE (empresa, codigo)
)
GO

-- ----------------------------------------------------------------------------
-- 2. Líneas de detalle de la plantilla
-- ----------------------------------------------------------------------------
CREATE TABLE [flexline].[um_requisicion_recurrente_detalle] (
    id_recurrente   INT             NOT NULL,
    linea           INT             NOT NULL,
    producto        VARCHAR(25)     NULL,
    descripcion     VARCHAR(200)    NULL,
    comentario      VARCHAR(255)    NULL,
    cantidad        NUMERIC(10,2)   NOT NULL DEFAULT 0,
    precio          NUMERIC(10,2)   NOT NULL DEFAULT 0,

    CONSTRAINT PK_um_requisicion_recurrente_detalle PRIMARY KEY (id_recurrente, linea),
    CONSTRAINT FK_um_req_rec_det
        FOREIGN KEY (id_recurrente) REFERENCES [flexline].[um_requisicion_recurrente](id_recurrente)
)
GO

-- ----------------------------------------------------------------------------
-- 3. Distribuciones (costo/marca/gasto) — misma estructura que requisicionCodigo
--    tipo: CON_CCOSTO | CON_MARCA | CON_ITEM
-- ----------------------------------------------------------------------------
CREATE TABLE [flexline].[um_requisicion_recurrente_dist] (
    id_recurrente       INT             NOT NULL,
    linea               INT             NOT NULL,
    producto            VARCHAR(25)     NOT NULL,
    tipo                VARCHAR(25)     NOT NULL,   -- CON_CCOSTO | CON_MARCA | CON_ITEM
    codigo              VARCHAR(50)     NOT NULL,
    porcentaje          NUMERIC(8,2)    NOT NULL DEFAULT 0,
    porcentaje_empresa  NUMERIC(8,2)    NULL DEFAULT 0,  -- solo MARCA
    porcentaje_socio    NUMERIC(8,2)    NULL DEFAULT 0,  -- solo MARCA
    tipo_gasto          VARCHAR(25)     NULL,             -- solo ITEM

    CONSTRAINT PK_um_requisicion_recurrente_dist PRIMARY KEY (id_recurrente, linea, producto, tipo, codigo),
    CONSTRAINT FK_um_req_rec_dist
        FOREIGN KEY (id_recurrente) REFERENCES [flexline].[um_requisicion_recurrente](id_recurrente)
)
GO

-- ----------------------------------------------------------------------------
-- 4. Canal de la plantilla — misma estructura que requisicionCanal
-- ----------------------------------------------------------------------------
CREATE TABLE [flexline].[um_requisicion_recurrente_canal] (
    id_recurrente   INT             NOT NULL,
    canal           VARCHAR(50)     NOT NULL,
    porcentaje      NUMERIC(10,4)   NOT NULL DEFAULT 0,

    CONSTRAINT PK_um_requisicion_recurrente_canal PRIMARY KEY (id_recurrente, canal),
    CONSTRAINT FK_um_req_rec_canal
        FOREIGN KEY (id_recurrente) REFERENCES [flexline].[um_requisicion_recurrente](id_recurrente)
)
GO

-- ----------------------------------------------------------------------------
-- 5. Modificación en tabla requisicion existente
--    NULL con DEFAULT para compatibilidad total con el sistema actual.
--    Ejecutar este ALTER ANTES del script 00 (ALTER SP).
-- ----------------------------------------------------------------------------
ALTER TABLE [flexline].[requisicion]
    ADD es_recurrente        CHAR(2)  NULL DEFAULT 'N',  -- S|N
        id_recurrente_origen INT      NULL                -- NULL si no viene de plantilla
GO

-- ============================================================================
-- VERIFICACION
-- ============================================================================
-- SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
-- WHERE TABLE_NAME LIKE 'um_requisicion_recurrente%'
-- ORDER BY TABLE_NAME
--
-- SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, COLUMN_DEFAULT
-- FROM INFORMATION_SCHEMA.COLUMNS
-- WHERE TABLE_NAME = 'requisicion' AND COLUMN_NAME IN ('es_recurrente','id_recurrente_origen')
-- ============================================================================
