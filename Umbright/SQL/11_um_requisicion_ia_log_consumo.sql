-- ============================================================================
-- Control de consumo de tokens del módulo de Requisiciones Masivas con IA.
-- Registra cada llamada a la API de Anthropic: usuario, cuándo, y cuántos
-- tokens gastó, agrupado por lote de chat (correlativo_lote).
-- BD: SCM | Schema: flexline
-- ============================================================================

USE [SCM]
GO

IF OBJECT_ID('flexline.um_ia_log_consumo') IS NULL
BEGIN
    CREATE TABLE [flexline].[um_ia_log_consumo] (
        id_log              INT IDENTITY(1,1) PRIMARY KEY,
        empresa             VARCHAR(25)     NOT NULL,
        usuario             VARCHAR(25)     NOT NULL,
        fecha               DATETIME        NOT NULL DEFAULT GETDATE(),
        modelo              VARCHAR(50)     NOT NULL,
        accion              VARCHAR(30)     NOT NULL, -- 'GENERAR_BORRADOR' | 'CORRECCION' | 'ACLARACION'
        tokens_input        INT             NOT NULL,
        tokens_output       INT             NOT NULL,
        tokens_total        AS (tokens_input + tokens_output) PERSISTED,
        correlativo_lote    VARCHAR(50)     NULL,
        numero_requisicion  VARCHAR(25)     NULL
    )

    CREATE INDEX IX_um_ia_log_consumo_usuario_fecha
        ON [flexline].[um_ia_log_consumo] (empresa, usuario, fecha)

    CREATE INDEX IX_um_ia_log_consumo_lote
        ON [flexline].[um_ia_log_consumo] (correlativo_lote)
END
GO

-- ----------------------------------------------------------------------------
-- Inserta una línea de consumo. Se llama una vez por cada respuesta de la API
-- (generación inicial, corrección por chat, o pregunta de aclaración) para que
-- ninguna llamada quede sin registrar, incluso si la requisición resultante
-- no pasa validación.
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_ins_um_ia_log_consumo') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_ins_um_ia_log_consumo]
GO

CREATE PROCEDURE [flexline].[pa_ins_um_ia_log_consumo]
    @PEmpresa               VARCHAR(25),
    @PUsuario               VARCHAR(25),
    @PModelo                VARCHAR(50),
    @PAccion                VARCHAR(30),
    @PTokensInput           INT,
    @PTokensOutput          INT,
    @PCorrelativoLote       VARCHAR(50) = NULL,
    @PNumeroRequisicion     VARCHAR(25) = NULL
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO [flexline].[um_ia_log_consumo] (
        empresa, usuario, fecha, modelo, accion,
        tokens_input, tokens_output, correlativo_lote, numero_requisicion
    ) VALUES (
        @PEmpresa, @PUsuario, GETDATE(), @PModelo, @PAccion,
        @PTokensInput, @PTokensOutput, @PCorrelativoLote, @PNumeroRequisicion
    )
END
GO

-- ----------------------------------------------------------------------------
-- Consulta de consumo por usuario/periodo, filtros opcionales (NULL = sin filtrar).
-- Pensado para un futuro dashboard de costos.
-- ----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_sel_um_ia_log_consumo') IS NOT NULL
    DROP PROCEDURE [flexline].[pa_sel_um_ia_log_consumo]
GO

CREATE PROCEDURE [flexline].[pa_sel_um_ia_log_consumo]
    @PEmpresa       VARCHAR(25),
    @PUsuario       VARCHAR(25)  = NULL,
    @PFechaDesde    DATETIME     = NULL,
    @PFechaHasta    DATETIME     = NULL
AS
BEGIN
    SET NOCOUNT ON

    SELECT id_log, empresa, usuario, fecha, modelo, accion,
           tokens_input, tokens_output, tokens_total,
           correlativo_lote, numero_requisicion
    FROM [flexline].[um_ia_log_consumo]
    WHERE empresa = @PEmpresa
      AND (@PUsuario IS NULL OR usuario = @PUsuario)
      AND (@PFechaDesde IS NULL OR fecha >= @PFechaDesde)
      AND (@PFechaHasta IS NULL OR fecha < DATEADD(DAY, 1, @PFechaHasta))
    ORDER BY fecha DESC
END
GO
