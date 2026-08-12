-- ============================================================================
-- Configuración del módulo de Requisiciones Masivas con IA.
-- Guarda la API Key de Anthropic (cifrada con clEmpaquetar/TripleDES + Base64
-- desde VB) en una tabla dedicada: el valor cifrado (Unicode + Base64) puede
-- superar ampliamente los 200 caracteres del campo TEXTO de gen_tabcod, por
-- eso NO se reutiliza esa tabla.
-- BD: SCM | Schema: flexline
-- ============================================================================

USE [SCM]
GO

IF OBJECT_ID('flexline.um_ia_configuracion') IS NULL
BEGIN
    CREATE TABLE [flexline].[um_ia_configuracion] (
        id_configuracion    INT IDENTITY(1,1) PRIMARY KEY,
        empresa             VARCHAR(25)     NOT NULL,
        tipo                VARCHAR(20)     NOT NULL,   -- 'CON_CONFIG_IA'
        codigo              VARCHAR(20)     NOT NULL,   -- 'ANTHROPIC_API_KEY'
        descripcion         VARCHAR(200)    NULL,
        valor               VARCHAR(MAX)    NOT NULL,   -- valor cifrado (TripleDES + Base64), sin límite práctico
        fechaModif          DATETIME        NULL,
        CONSTRAINT UQ_um_ia_configuracion UNIQUE (empresa, tipo, codigo)
    )
END
GO

-- ----------------------------------------------------------------------------
-- Lectura de un valor de configuración de IA.
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_sel_um_configuracion_ia') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_sel_um_configuracion_ia]
GO

CREATE PROCEDURE [flexline].[pa_sel_um_configuracion_ia]
    @PEmpresa   VARCHAR(25),
    @PTipo      VARCHAR(20) = 'CON_CONFIG_IA',
    @PCodigo    VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON
    SELECT TOP 1 valor
    FROM [flexline].[um_ia_configuracion]
    WHERE empresa = @PEmpresa AND tipo = @PTipo AND codigo = @PCodigo
END
GO

-- ----------------------------------------------------------------------------
-- Escritura/rotación de un valor de configuración de IA (upsert).
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_upd_um_configuracion_ia') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_upd_um_configuracion_ia]
GO

CREATE PROCEDURE [flexline].[pa_upd_um_configuracion_ia]
    @PEmpresa       VARCHAR(25),
    @PTipo          VARCHAR(20) = 'CON_CONFIG_IA',
    @PCodigo        VARCHAR(20),
    @PValor         VARCHAR(MAX),
    @PDescripcion   VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON

    IF EXISTS (SELECT 1 FROM [flexline].[um_ia_configuracion] WHERE empresa = @PEmpresa AND tipo = @PTipo AND codigo = @PCodigo)
    BEGIN
        UPDATE [flexline].[um_ia_configuracion]
        SET valor = @PValor,
            descripcion = ISNULL(@PDescripcion, descripcion),
            fechaModif = GETDATE()
        WHERE empresa = @PEmpresa AND tipo = @PTipo AND codigo = @PCodigo
    END
    ELSE
    BEGIN
        INSERT INTO [flexline].[um_ia_configuracion] (empresa, tipo, codigo, descripcion, valor, fechaModif)
        VALUES (@PEmpresa, @PTipo, @PCodigo, ISNULL(@PDescripcion, @PCodigo), @PValor, GETDATE())
    END
END
GO
