-- =============================================================================
-- Tabla de asociacion Centro de Costo + Item de gasto -> Producto de requisicion
-- Usada por la interfaz LGS_SolicitudesPago -> Requisicion / OC.
-- Ejecutar UNA sola vez en la BD SCM.
--
-- Regla de busqueda del producto:
--   1) Coincidencia exacta  Empresa + CentroCosto + ItemGasto  (Vigente = 'S')
--   2) Si no hay, el registro EsDefault = 1 del ItemGasto      (Vigente = 'S')
--   3) Si tampoco hay, la fila origen no se procesa (error).
--
-- CentroCosto NULL = regla generica para el item (se usa con EsDefault = 1).
-- =============================================================================

IF OBJECT_ID('flexline.um_lgs_asociacion_producto') IS NULL
BEGIN
    CREATE TABLE flexline.um_lgs_asociacion_producto (
        id                   INT IDENTITY(1,1) NOT NULL
                             CONSTRAINT PK_um_lgs_asociacion_producto PRIMARY KEY,
        Empresa              VARCHAR(20)  NOT NULL,
        Area                 VARCHAR(30)  NULL,
        CentroCosto          VARCHAR(20)  NULL,          -- NULL = aplica a cualquier CC
        GlosaCentroCosto     VARCHAR(100) NULL,
        ItemGasto            VARCHAR(20)  NOT NULL,
        DescripcionItem      VARCHAR(150) NULL,
        Producto             VARCHAR(20)  NOT NULL,
        DescripcionProducto  VARCHAR(150) NULL,
        CuentaContable       VARCHAR(20)  NULL,
        DescCuentaContable   VARCHAR(100) NULL,
        EsDefault            BIT          NOT NULL
                             CONSTRAINT DF_um_lgs_asoc_EsDefault  DEFAULT (0),
        Vigente              CHAR(1)      NOT NULL
                             CONSTRAINT DF_um_lgs_asoc_Vigente    DEFAULT ('S'),
        FechaGrabo           DATETIME     NOT NULL
                             CONSTRAINT DF_um_lgs_asoc_FechaGrabo DEFAULT (GETDATE()),
        UsuarioGrabo         VARCHAR(25)  NULL,
        FechaModif           DATETIME     NULL,
        UsuarioModif         VARCHAR(25)  NULL,
        CONSTRAINT CK_um_lgs_asoc_Vigente CHECK (Vigente IN ('S','N'))
    )

    PRINT 'Tabla flexline.um_lgs_asociacion_producto creada'
END
ELSE
    PRINT 'La tabla flexline.um_lgs_asociacion_producto ya existe'
GO

-- Una sola regla por Empresa + CC + Item
IF NOT EXISTS (SELECT 1 FROM sys.indexes
                WHERE object_id = OBJECT_ID('flexline.um_lgs_asociacion_producto')
                  AND name = 'UX_um_lgs_asoc_cc_item')
    CREATE UNIQUE INDEX UX_um_lgs_asoc_cc_item
        ON flexline.um_lgs_asociacion_producto (Empresa, CentroCosto, ItemGasto)
        WHERE CentroCosto IS NOT NULL
GO

-- Un solo producto por defecto por Empresa + Item
IF NOT EXISTS (SELECT 1 FROM sys.indexes
                WHERE object_id = OBJECT_ID('flexline.um_lgs_asociacion_producto')
                  AND name = 'UX_um_lgs_asoc_item_default')
    CREATE UNIQUE INDEX UX_um_lgs_asoc_item_default
        ON flexline.um_lgs_asociacion_producto (Empresa, ItemGasto)
        WHERE EsDefault = 1
GO

-- Busqueda por item (paso 2 de la regla)
IF NOT EXISTS (SELECT 1 FROM sys.indexes
                WHERE object_id = OBJECT_ID('flexline.um_lgs_asociacion_producto')
                  AND name = 'IX_um_lgs_asoc_item')
    CREATE INDEX IX_um_lgs_asoc_item
        ON flexline.um_lgs_asociacion_producto (Empresa, ItemGasto)
        INCLUDE (Producto, Vigente, EsDefault)
GO
