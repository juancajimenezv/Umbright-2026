-- ============================================================================
-- FIX ESTÁNDAR: pa_ins_um_requisicion
--   El número siempre se guarda con 10 dígitos (ceros a la izquierda).
--   Se aplica RIGHT('0000000000' + @PNumero, 10) antes del INSERT para que
--   cualquier llamada —VB, SP de recurrentes, u otro origen— quede uniforme.
-- BD: SCM | Schema: flexline
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
    @Pcosteo             AS NVARCHAR(2)      = NULL,
    @PEsRecurrente       AS CHAR(2)          = NULL,
    @PIdRecurrenteOrigen AS INT              = NULL
AS

-- Normalizar número a 10 dígitos con ceros a la izquierda (estándar)
DECLARE @PNumeroFormateado AS VARCHAR(25)
SET @PNumeroFormateado = RIGHT('0000000000' + LTRIM(RTRIM(@PNumero)), 10)

DECLARE @PCorrelativo AS INTEGER
SET @PCorrelativo = ISNULL((SELECT MAX(Correlativo) FROM requisicion WHERE empresa = @PEmpresa), 1) + 1

INSERT INTO requisicion
    (empresa, correlativo, numero, fechaEntrega, lugarEntrega, observaciones,
     Proveedor, UsuarioGrabo, FechaGrabo, Moneda, Estado, fecha,
     tipocomprobante, SUPER_DR, TotalBimoneda, Costeo,
     es_recurrente, id_recurrente_origen)
SELECT
    @PEmpresa, @PCorrelativo, @PNumeroFormateado, CAST(@PFechaEntrega AS DATETIME),
    @PLugarEntrega, @PObservaciones,
    LTRIM(RTRIM(@PCodigoCliente)), @PUsuarioGrabo, GETDATE(),
    @PMoneda, 10, GETDATE(), LEFT(@PAnticipo, 2),
    @PCadena, @PMontoAnticipo, ISNULL(LEFT(@Pcosteo, 1), 'N'),
    ISNULL(@PEsRecurrente, 'N'),
    @PIdRecurrenteOrigen

INSERT INTO requisicionEstado (empresa, numero, estado, fecha_grabo, usuario_grabo)
SELECT @PEmpresa, @PNumeroFormateado, 0, GETDATE(), @PUsuarioGrabo

GO
