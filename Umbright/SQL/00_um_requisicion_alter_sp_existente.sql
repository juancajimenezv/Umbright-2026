-- ============================================================================
-- ALTER SP: pa_ins_um_requisicion
-- BD destino: SCM  |  Schema: flexline
--
-- Agrega 2 parámetros opcionales al final:
--   @PEsRecurrente       CHAR(2) = NULL   →  'SI' | 'NO'
--   @PIdRecurrenteOrigen INT     = NULL   →  FK a um_requisicion_recurrente
--
-- COMPATIBILIDAD: Al ir al final con DEFAULT = NULL todas las llamadas
-- existentes siguen funcionando sin ningún cambio.
--
-- Como deshacer: quitar los 2 params nuevos y las 2 columnas del INSERT.
-- ============================================================================

USE [SCM]
GO

ALTER PROCEDURE [flexline].[pa_ins_um_requisicion]
    @PEmpresa            AS VARCHAR(25),
    @PNumero             AS VARCHAR(25),
    @PFechaEntrega       AS VARCHAR(15),
    @PLugarEntrega       AS VARCHAR(75),
    @PObservaciones      AS VARCHAR(255),
    @PCodigoCliente      AS VARCHAR(25),
    @PUsuarioGrabo       AS VARCHAR(25),
    @Pmoneda             AS VARCHAR(25),
    @PAnticipo           AS VARCHAR(2),
    @PCadena             AS NVARCHAR(2)      = NULL,
    @PMontoAnticipo      AS NUMERIC(10,2)    = NULL,
    @Pcosteo             AS NVARCHAR(2)      = NULL,   -- Afecta Inventario
    -- Parámetros nuevos — opcionales, no rompen llamadas existentes
    @PEsRecurrente       AS CHAR(2)          = NULL,   -- NULL se trata como 'N'
    @PIdRecurrenteOrigen AS INT              = NULL    -- NULL si no viene de plantilla
AS

DECLARE @PCorrelativo AS INTEGER

SET @PCorrelativo = ISNULL((SELECT MAX(Correlativo) FROM requisicion WHERE empresa = @PEmpresa), 1) + 1

INSERT INTO requisicion
    (empresa, correlativo, numero, fechaEntrega, lugarEntrega, observaciones,
     Proveedor, UsuarioGrabo, FechaGrabo, Moneda, Estado, fecha,
     tipocomprobante, SUPER_DR, TotalBimoneda, Costeo,
     es_recurrente, id_recurrente_origen)
SELECT
    @PEmpresa, @PCorrelativo, @PNumero, CAST(@PFechaEntrega AS DATETIME),
    @PLugarEntrega, @PObservaciones,
    LTRIM(RTRIM(@PCodigoCliente)), @PUsuarioGrabo, GETDATE(),
    @PMoneda, 10, GETDATE(), LEFT(@PAnticipo, 2),
    @PCadena, @PMontoAnticipo, ISNULL(LEFT(@Pcosteo, 1), 'N'),
    ISNULL(@PEsRecurrente, 'N'),
    @PIdRecurrenteOrigen

INSERT INTO requisicionEstado (empresa, numero, estado, fecha_grabo, usuario_grabo)
SELECT @PEmpresa, @PNumero, 0, GETDATE(), @PUsuarioGrabo

GO

-- ============================================================================
-- VERIFICACION: confirmar que las columnas nuevas existen antes de ejecutar
-- ============================================================================
-- SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
-- WHERE TABLE_NAME = 'requisicion'
-- ORDER BY ORDINAL_POSITION
-- ============================================================================
