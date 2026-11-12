-- =============================================================================
-- Una sola vez: lleva a 60 "OdeC Generada" los anticipos de mantenimiento que
-- ya se crearon y quedaron en 30 "Pendiente de Cotizaciones" (3965 y 4032 al
-- 2026-10-15). Ya estan revisados y aprobados (20 / 30 por HGARCIA), asi que
-- solo se hacen los pasos de compras, igual que flexline.sp_ProcesarMantenimientosAnticipos:
--   40 Cotizando, 50 Generar OdeC (+ proveedor, cotizacion, precio),
--   anticipo (Adjuntos = 'S'), 60 OdeC Generada.
-- El origen (lgs_mantenimientos) ya esta marcado como 'Anticipo Procesado'.
-- Ejecutar en SCM. Primero corre solo la consulta de revision (1).
-- =============================================================================

SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @empresa         VARCHAR(25)  = 'LOGISERV'
DECLARE @usuario_compras VARCHAR(25)  = 'ppineda'
DECLARE @cotizacion      VARCHAR(100) = 'Sin Cotizacion'

-- (1) Revision: requisiciones que se van a mover
SELECT r.Numero, r.Correlativo, r.Estado, r.TipoComprobante, r.TotalBimoneda, r.Proveedor, r.ReferenciaExterna
  FROM flexline.Requisicion r
 WHERE r.Empresa = @empresa
   AND r.ReferenciaExterna LIKE 'MANT-%'
   AND r.TipoComprobante = 'SI'
   AND r.Estado = '30'
 ORDER BY r.Numero

-- (2) Paso a 60, una requisicion por transaccion
DECLARE @Numero VARCHAR(20), @Proveedor VARCHAR(50), @Linea INT, @Producto VARCHAR(50), @Monto DECIMAL(18,4)

DECLARE cReq CURSOR LOCAL FAST_FORWARD FOR
    SELECT r.Numero, r.Proveedor
      FROM flexline.Requisicion r
     WHERE r.Empresa = @empresa
       AND r.ReferenciaExterna LIKE 'MANT-%'
       AND r.TipoComprobante = 'SI'
       AND r.Estado = '30'
     ORDER BY r.Numero

OPEN cReq
FETCH NEXT FROM cReq INTO @Numero, @Proveedor
WHILE @@FETCH_STATUS = 0
BEGIN
    BEGIN TRY
        BEGIN TRAN

        EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 40, NULL
        EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 50, NULL
        EXEC flexline.pa_upd_um_requisicion_proveedor @empresa, @Numero, @Proveedor, @cotizacion

        DECLARE cLin CURSOR LOCAL FAST_FORWARD FOR
            SELECT d.Linea, d.Producto, d.Total
              FROM flexline.RequisicionD d
              JOIN flexline.Requisicion r ON r.Empresa = d.Empresa AND r.Correlativo = d.Correlativo
             WHERE r.Empresa = @empresa AND r.Numero = @Numero
             ORDER BY d.Linea
        OPEN cLin
        FETCH NEXT FROM cLin INTO @Linea, @Producto, @Monto
        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC flexline.pa_upd_um_requisiciond_precio @empresa, @Numero, @Linea, @Producto, @Monto, 1
            FETCH NEXT FROM cLin INTO @Linea, @Producto, @Monto
        END
        CLOSE cLin
        DEALLOCATE cLin

        EXEC flexline.pa_upd_um_requisicion_anticipo @empresa, @Numero, @usuario_compras, 'SI'

        UPDATE flexline.Requisicion SET SUPER_DR = 'NO'
         WHERE Empresa = @empresa AND Numero = @Numero AND SUPER_DR IS NULL

        EXEC flexline.pa_upd_um_requisicion_estado @empresa, @Numero, @usuario_compras, 60, NULL

        COMMIT TRAN
        PRINT 'Requisicion ' + @Numero + ' -> 60 OdeC Generada'
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN
        IF CURSOR_STATUS('local', 'cLin') >= -1 BEGIN CLOSE cLin DEALLOCATE cLin END
        PRINT 'Error en requisicion ' + @Numero + ': ' + ERROR_MESSAGE()
    END CATCH

    FETCH NEXT FROM cReq INTO @Numero, @Proveedor
END
CLOSE cReq
DEALLOCATE cReq

-- (3) Resultado
SELECT r.Numero, r.Estado, r.TipoComprobante, r.Adjuntos, r.TotalBimoneda, r.Cotizacion, r.SUPER_DR,
       d.PrecioAjustado, d.Neto, d.CantidadAsignada
  FROM flexline.Requisicion r
  JOIN flexline.RequisicionD d ON d.Empresa = r.Empresa AND d.Correlativo = r.Correlativo
 WHERE r.Empresa = @empresa
   AND r.ReferenciaExterna LIKE 'MANT-%'
   AND r.TipoComprobante = 'SI'
 ORDER BY r.Numero
