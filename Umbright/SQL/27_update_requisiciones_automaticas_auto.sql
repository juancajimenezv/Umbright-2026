-- =============================================================================
-- Una sola vez: marca como 'Auto' (Requisicion.TipoComprobante, columna del
-- combo "Anticipo") las requisiciones que ya generaron los procesos automaticos:
--   - LGS Solicitudes de Pago: las del log um_lgs_solicitudes_pago_log (OK).
--   - Mantenimiento: las ligadas en lgs_mantenimientos (TipoSolicitud distinta
--     de 'Anticipo') y creadas por sp_ProcesarMantenimientosARequisicion, que
--     existe desde 2026-09-03 15:31. Las anteriores (mayo a agosto) se
--     capturaron a mano en Umbright y no se tocan.
-- Solo cambia las que estan en 'NO'. Los anticipos ('SI') no se tocan.
-- Ejecutar en SCM. Primero revisa el resultado de (1).
-- =============================================================================

SET NOCOUNT ON
SET XACT_ABORT ON

IF OBJECT_ID('tempdb..#auto') IS NOT NULL DROP TABLE #auto
CREATE TABLE #auto (Empresa VARCHAR(20) COLLATE DATABASE_DEFAULT,
                    Numero  VARCHAR(25) COLLATE DATABASE_DEFAULT,
                    Origen  VARCHAR(10))

-- LGS Solicitudes de Pago
INSERT INTO #auto (Empresa, Numero, Origen)
SELECT DISTINCT l.Empresa, l.NumeroRequisicion, 'LGS'
  FROM flexline.um_lgs_solicitudes_pago_log l
 WHERE l.Resultado = 'OK'
   AND l.NumeroRequisicion IS NOT NULL

-- Mantenimiento (lectura del servidor vinculado fuera de transaccion)
INSERT INTO #auto (Empresa, Numero, Origen)
SELECT r.Empresa, r.Numero, 'MANT'
  FROM flexline.Requisicion r
  JOIN wms_interface.lgs_transportes.dbo.lgs_mantenimientos m
    ON r.Empresa = 'LOGISERV'
   AND CAST(r.Correlativo AS VARCHAR(20)) = m.Requisicion COLLATE DATABASE_DEFAULT
 WHERE m.TipoSolicitud <> N'Anticipo'
   AND r.FechaGrabo >= '20260903 15:30:00'

-- (1) Revision: lo que se va a cambiar
SELECT a.Origen, r.Empresa, r.Numero, r.Estado, r.TipoComprobante, r.UsuarioGrabo, r.FechaGrabo
  FROM #auto a
  JOIN flexline.Requisicion r ON r.Empresa = a.Empresa AND r.Numero = a.Numero
 WHERE r.TipoComprobante = 'NO'
 ORDER BY a.Origen, r.Empresa, r.Numero

-- (2) Update
BEGIN TRAN

UPDATE r
   SET TipoComprobante = 'Auto'
  FROM flexline.Requisicion r
  JOIN #auto a ON a.Empresa = r.Empresa AND a.Numero = r.Numero
 WHERE r.TipoComprobante = 'NO'

PRINT CAST(@@ROWCOUNT AS VARCHAR(10)) + ' requisiciones marcadas como Auto'

COMMIT TRAN

-- (3) Resultado
SELECT a.Origen, r.TipoComprobante, COUNT(*) AS Requisiciones
  FROM #auto a
  JOIN flexline.Requisicion r ON r.Empresa = a.Empresa AND r.Numero = a.Numero
 GROUP BY a.Origen, r.TipoComprobante
 ORDER BY a.Origen, r.TipoComprobante
