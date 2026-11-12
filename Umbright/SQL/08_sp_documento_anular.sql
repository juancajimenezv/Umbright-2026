-- =============================================================================
-- Stored Procedures: Anular Orden de Compra (modulo Compras/Import, pantalla
-- "Anulacion OC" - Umbright/SCM/frm_anulacion_oc.vb)
--
-- SPs creados:
--   flexline.pa_sel_um_documento_anular         - Consulta (estado actual del documento)
--   flexline.pa_upd_um_documento_anular         - Anular u OnHold (Vigencia = 'A')
--   flexline.pa_upd_um_documento_reversar_onhold - Reversar un OnHold (Vigencia = 'S')
--
-- Reglas de negocio:
--   * Solo se puede Anular / poner en OnHold un documento con Vigencia = 'S'
--     y PorcentajeAsignado = 0.
--   * Anular y OnHold usan el mismo valor Vigencia = 'A'; se distinguen por el
--     prefijo que se guarda en Comentario1 ('ANULAR: ...' / 'ONHOLD: ...').
--   * Solo un documento en estado ONHOLD puede reversarse (vuelve a Vigencia = 'S').
--     Un documento ANULAR es definitivo, no tiene reversion en este alcance.
--   * La auditoria se registra reutilizando el log generico existente
--     pa_ins_um_gen_log_documento (ya usado por otras pantallas de este modulo).
--
-- Ejecutar UNA sola vez en la base bdflexline.
-- =============================================================================

USE bdflexline
GO

-- -----------------------------------------------------------------------------
-- 1. Consulta: estado actual del documento para la pantalla de anulacion
-- -----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_sel_um_documento_anular', 'P') IS NOT NULL
    DROP PROCEDURE flexline.pa_sel_um_documento_anular
GO

CREATE PROCEDURE flexline.pa_sel_um_documento_anular
    @empresa   varchar(20),
    @tipodocto varchar(50),
    @numero    varchar(10)
AS
BEGIN
    SET NOCOUNT ON

    SELECT
        d.Empresa,
        d.TipoDocto,
        d.Numero,
        d.Correlativo,
        d.Proveedor,
        d.Fecha,
        d.Total,
        d.Vigencia,
        d.PorcentajeAsignado,
        d.Comentario1,
        CASE
            WHEN d.Vigencia = 'A' AND d.Comentario1 LIKE 'ONHOLD:%' THEN 'ONHOLD'
            WHEN d.Vigencia = 'A'                                   THEN 'ANULADO'
            WHEN d.Vigencia = 'S'                                   THEN 'VIGENTE'
            ELSE d.Vigencia
        END AS EstadoActual,
        CASE WHEN d.Vigencia = 'S' AND d.PorcentajeAsignado = 0 THEN 1 ELSE 0 END AS PuedeAnular,
        CASE WHEN d.Vigencia = 'A' AND d.Comentario1 LIKE 'ONHOLD:%' THEN 1 ELSE 0 END AS PuedeReversar,
        CASE
            WHEN d.Vigencia = 'A' AND d.Comentario1 LIKE 'ONHOLD:%' THEN 'El documento esta en ONHOLD'
            WHEN d.Vigencia = 'A'                                   THEN 'El documento ya esta ANULADO'
            WHEN d.Vigencia <> 'S'                                  THEN 'El documento no esta vigente'
            WHEN d.PorcentajeAsignado <> 0                          THEN 'El documento ya tiene porcentaje asignado, no se puede anular/onhold'
            ELSE NULL
        END AS MotivoNoAnula
    FROM flexline.documento d
    WHERE d.Empresa = @empresa
      AND d.TipoDocto = @tipodocto
      AND d.Numero = @numero
END
GO

-- -----------------------------------------------------------------------------
-- 2. Actualizacion: Anular u OnHold (misma escritura para ambas acciones)
--    Revalida Vigencia='S' AND PorcentajeAsignado=0 en el propio UPDATE (server
--    side, atomico) para evitar condiciones de carrera con la consulta previa.
-- -----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_upd_um_documento_anular', 'P') IS NOT NULL
    DROP PROCEDURE flexline.pa_upd_um_documento_anular
GO

CREATE PROCEDURE flexline.pa_upd_um_documento_anular
    @empresa   varchar(20),
    @tipodocto varchar(50),
    @numero    varchar(10),
    @accion    varchar(10),   -- 'ANULAR' u 'ONHOLD'
    @motivo    varchar(500),
    @usuario   varchar(50)
AS
BEGIN
    SET NOCOUNT ON
    SET XACT_ABORT ON

    IF @accion NOT IN ('ANULAR', 'ONHOLD')
    BEGIN
        SELECT 0 AS Resultado, 'Accion no valida' AS Mensaje
        RETURN
    END

    BEGIN TRAN

    UPDATE flexline.documento
       SET Vigencia     = 'A',
           Comentario1  = @accion + ': ' + @motivo,
           FechaEstado  = GETDATE(),
           FechaModif   = GETDATE(),
           UsuarioModif = @usuario
     WHERE Empresa = @empresa
       AND TipoDocto = @tipodocto
       AND Numero = @numero
       AND Vigencia = 'S'
       AND PorcentajeAsignado = 0

    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRAN
        SELECT 0 AS Resultado, 'No se pudo procesar: el documento ya no cumple las condiciones (vigencia/porcentaje asignado) o no existe' AS Mensaje
        RETURN
    END

    -- Sin prefijo de schema: se llama igual que en el resto de pantallas VB de
    -- este modulo (deja que el schema por defecto del login resuelva el SP).
    -- Nota: EXEC no acepta expresiones como argumento (solo constantes/variables),
    -- por eso se arma el texto en una variable antes de llamarlo.
    DECLARE @Actividad varchar(550)
    SET @Actividad = @accion + ' OC - Motivo: ' + @motivo
    EXEC pa_ins_um_gen_log_documento @empresa, @tipodocto, @numero, @usuario, NULL, @Actividad

    COMMIT TRAN
    SELECT 1 AS Resultado, 'Documento procesado correctamente (' + @accion + ')' AS Mensaje
END
GO

-- -----------------------------------------------------------------------------
-- 3. Reversar un ONHOLD: regresa el documento a Vigencia = 'S'
--    Solo aplica si el documento esta actualmente en ONHOLD; no aplica a ANULAR.
-- -----------------------------------------------------------------------------
IF OBJECT_ID('flexline.pa_upd_um_documento_reversar_onhold', 'P') IS NOT NULL
    DROP PROCEDURE flexline.pa_upd_um_documento_reversar_onhold
GO

CREATE PROCEDURE flexline.pa_upd_um_documento_reversar_onhold
    @empresa   varchar(20),
    @tipodocto varchar(50),
    @numero    varchar(10),
    @motivo    varchar(500),
    @usuario   varchar(50)
AS
BEGIN
    SET NOCOUNT ON
    SET XACT_ABORT ON
    BEGIN TRAN

    UPDATE flexline.documento
       SET Vigencia     = 'S',
           Comentario1  = 'REACTIVADO: ' + @motivo,
           FechaEstado  = GETDATE(),
           FechaModif   = GETDATE(),
           UsuarioModif = @usuario
     WHERE Empresa = @empresa
       AND TipoDocto = @tipodocto
       AND Numero = @numero
       AND Vigencia = 'A'
       AND Comentario1 LIKE 'ONHOLD:%'

    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRAN
        SELECT 0 AS Resultado, 'No se pudo reversar: el documento no esta en estado ONHOLD' AS Mensaje
        RETURN
    END

    -- Nota: EXEC no acepta expresiones como argumento (solo constantes/variables),
    -- por eso se arma el texto en una variable antes de llamarlo.
    DECLARE @Actividad varchar(550)
    SET @Actividad = 'REVERSA ONHOLD OC - Motivo: ' + @motivo
    EXEC pa_ins_um_gen_log_documento @empresa, @tipodocto, @numero, @usuario, NULL, @Actividad

    COMMIT TRAN
    SELECT 1 AS Resultado, 'Documento reactivado correctamente (Vigencia=S)' AS Mensaje
END
GO
