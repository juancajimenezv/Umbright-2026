-- =============================================================================
-- Reproceso de una requisicion creada por pa_pro_um_lgs_solicitudes_pago que
-- junto varias facturas (antes del script 17).
-- Ejecutar en la BD SCM DESPUES de instalar 17_alter_pa_pro_um_lgs_solicitudes_pago_factura.sql.
--
--   1) Valida que la requisicion exista, la haya creado la interfaz y siga en estado 60.
--   2) La anula (estado 1000) con pa_upd_um_requisicion_estado, igual que la pantalla.
--   3) En el log cambia sus filas 'OK' a 'ANULADA' (el SP solo excluye las 'OK').
--   4) Deja las filas del origen pendientes: Procesado / fechaProcesado /
--      NumeroRequisicion = NULL (fuera de la transaccion local, sin MSDTC).
-- Despues: EXEC flexline.pa_pro_um_lgs_solicitudes_pago  -> crea una OC por factura.
--
-- Por defecto hace ROLLBACK (@Confirmar = 0). Revisar y re-ejecutar con 1.
-- =============================================================================

SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @Confirmar  bit
DECLARE @Empresa    varchar(20)
DECLARE @Numero     varchar(25)
DECLARE @Usuario    varchar(25)
DECLARE @Comentario varchar(150)
SET @Confirmar  = 0                       -- 1 = aplicar
SET @Empresa    = 'DMARTE1'
SET @Numero     = '0000031401'
SET @Usuario    = LEFT(SUSER_SNAME(), 25)
SET @Comentario = 'Anulada: agrupaba 3 facturas. Se recrea una OC por factura (interfaz SP)'

-- -----------------------------------------------------------------------------
-- 1) Validaciones
-- -----------------------------------------------------------------------------
DECLARE @Estado varchar(20)
SELECT @Estado = Estado FROM flexline.Requisicion WHERE Empresa = @Empresa AND Numero = @Numero

IF @Estado IS NULL
BEGIN
    RAISERROR('La requisicion %s de %s no existe.', 16, 1, @Numero, @Empresa)
    RETURN
END

IF @Estado <> '60'
BEGIN
    RAISERROR('La requisicion %s esta en estado %s (se esperaba 60). Revisar antes de anular.', 16, 1, @Numero, @Estado)
    RETURN
END

IF NOT EXISTS (SELECT 1 FROM flexline.um_lgs_solicitudes_pago_log
                WHERE Empresa = @Empresa AND NumeroRequisicion = @Numero AND Resultado = 'OK')
BEGIN
    RAISERROR('La requisicion %s no fue creada por la interfaz (no esta en el log).', 16, 1, @Numero)
    RETURN
END

DECLARE @Registros TABLE (IDRegistro int PRIMARY KEY)
INSERT INTO @Registros (IDRegistro)
SELECT DISTINCT IDRegistro
  FROM flexline.um_lgs_solicitudes_pago_log
 WHERE Empresa = @Empresa AND NumeroRequisicion = @Numero AND Resultado = 'OK'

PRINT '--- Filas del origen que se reprocesaran'
SELECT s.IDRegistro, s.Title, s.NIT, s.Serie, s.NoFactura, s.Monto, s.Procesado, s.NumeroRequisicion
  FROM WMS_INTERFACE.lgs_transportes.dbo.LGS_SolicitudesPago s
 WHERE s.IDRegistro IN (SELECT IDRegistro FROM @Registros)
 ORDER BY s.IDRegistro

-- -----------------------------------------------------------------------------
-- 2) y 3) Anular la requisicion y liberar el log (transaccion local)
-- -----------------------------------------------------------------------------
BEGIN TRAN

EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @Usuario, 1000, @Comentario

UPDATE flexline.um_lgs_solicitudes_pago_log
   SET Resultado = 'ANULADA',
       Mensaje   = LEFT(ISNULL(Mensaje, '') + ' | ' + @Comentario, 1000)
 WHERE Empresa = @Empresa AND NumeroRequisicion = @Numero AND Resultado = 'OK'

PRINT 'Filas de log liberadas: ' + CAST(@@ROWCOUNT AS varchar(10))

SELECT Empresa, Numero, Estado, Glosa FROM flexline.Requisicion WHERE Empresa = @Empresa AND Numero = @Numero

IF @Confirmar = 1
BEGIN
    COMMIT TRAN
    PRINT '*** Requisicion anulada ***'
END
ELSE
BEGIN
    ROLLBACK TRAN
    PRINT '*** ROLLBACK (prueba). Cambiar @Confirmar = 1 para aplicar. ***'
    RETURN
END

-- -----------------------------------------------------------------------------
-- 4) Dejar pendientes las filas del origen (solo si se confirmo)
-- -----------------------------------------------------------------------------
UPDATE WMS_INTERFACE.lgs_transportes.dbo.LGS_SolicitudesPago
   SET Procesado = NULL,
       fechaProcesado = NULL,
       NumeroRequisicion = NULL
 WHERE IDRegistro IN (SELECT IDRegistro FROM @Registros)

PRINT 'Filas del origen liberadas: ' + CAST(@@ROWCOUNT AS varchar(10))
PRINT 'Siguiente paso: EXEC flexline.pa_pro_um_lgs_solicitudes_pago @SoloValidar = 1'
