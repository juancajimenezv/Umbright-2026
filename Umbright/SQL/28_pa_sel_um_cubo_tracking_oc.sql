-- =============================================================================
-- Stored Procedure: Cubo Tracking OC (modulo Compras/Import, misma informacion
-- que la pantalla "Tracking Orden de Compra" - Umbright/SCM/frm_OChistorial.vb)
--
-- SP creado:
--   flexline.pa_sel_um_cubo_tracking_oc - Una fila por linea de OC (y por ingreso
--                                         parcial) con la fecha de cada etapa del
--                                         tracking hasta la Fecha Real de Ingreso.
--
-- Parametros:
--   @empresa  Empresa Flexline (DIMAEXSA, DIUVA, VINOTECA, ...)
--   @desde    Fecha de OC desde (inclusive)
--   @hasta    Fecha de OC hasta (inclusive, se toma el dia completo)
--
-- Cadena de documentos (se sigue linea a linea por TipoDoctoOrigen /
-- CorrelativoOrigen / SecuenciaOrigen):
--   ORDEN DE COMPRA -> CONFIRMACION PROVEEDOR -> FECHA EMBARQUE
--   -> FECHA CONFIRMACION DE EMBARQUE -> FECHA ARRIBO PUERTO
--   -> FECHA SALIDA PUERTO DE GUATEMALA -> FECHA INGRESO DEPOSITO ADUANERO
--   -> INGRESO PRODUCTO DA / INGRESO CONSOLIDA DA / ... (ingreso real)
--
-- Lo consume el Excel "Cubo Tracking OC.xlsx" (conexion ODBC con parametros).
-- Ejecutar UNA sola vez en la base bdflexline.
-- =============================================================================

USE bdflexline
GO

IF OBJECT_ID('flexline.pa_sel_um_cubo_tracking_oc', 'P') IS NOT NULL
    DROP PROCEDURE flexline.pa_sel_um_cubo_tracking_oc
GO

CREATE PROCEDURE flexline.pa_sel_um_cubo_tracking_oc
    @empresa varchar(20),
    @desde   datetime,
    @hasta   datetime
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @desde_d datetime, @hasta_d datetime
    SET @desde_d = CAST(CAST(@desde AS date) AS datetime)
    SET @hasta_d = DATEADD(day, 1, CAST(CAST(@hasta AS date) AS datetime))

    SELECT
        oc.Empresa, oc.Numero AS Numero_OC, oc.TipoDocto, oc.Fecha AS Fecha_OC,
        oc.FechaVcto AS Fecha_Vencimiento_OC, oc.Proveedor, cc.RazonSocial, oc.Vigencia,
        CASE WHEN oc.Vigencia = 'A' AND UPPER(oc.Comentario1) LIKE 'ONHOLD:%' THEN 'ONHOLD'
             WHEN oc.Vigencia = 'A' THEN 'ANULADA' ELSE 'VIGENTE' END AS Estado_OC,
        oc.Comentario1,
        od.Producto, p.GLOSA AS Glosa,
        p.FACTORALT AS uxc,
        od.UnidadIngreso AS Unidad, od.CantidadIngreso AS Cantidad_Pedido,
        od.PrecioIngreso AS PrecioU, od.SubTotalIngreso AS Total,
        hcp.FechaVcto AS F_Confirmacion_Proveedor,
        hfe.FechaVcto AS F_Embarque,
        hce.FechaVcto AS F_Confirmacion_Embarque,
        hap.FechaVcto AS F_Arribo_Puerto,
        dap.VALOR1    AS Cantidad_Facturada,
        dap.VALOR2    AS Fecha_Vencimiento_Prod,
        hsp.FechaVcto AS F_Salida_Puerto_Gt,
        hda.FechaVcto AS F_Ingreso_Deposito_Aduanero,
        hin.Fecha     AS Fecha_Real_Ingreso,
        din.CantidadIngreso AS Cantidad_Ingresada,
        DATEDIFF(day, oc.Fecha, hin.Fecha) AS Dias_OC_a_Ingreso
    FROM flexline.Documento oc WITH (NOLOCK)
    JOIN flexline.DocumentoD od WITH (NOLOCK) ON od.Empresa = oc.Empresa AND od.TipoDocto = oc.TipoDocto AND od.Correlativo = oc.Correlativo
    LEFT JOIN flexline.CTACTE cc WITH (NOLOCK) ON cc.Empresa = oc.Empresa AND cc.CtaCte = oc.Proveedor AND cc.TipoCtaCte = 'PROVEEDOR'
    LEFT JOIN flexline.PRODUCTO p WITH (NOLOCK) ON p.EMPRESA = od.Empresa AND p.PRODUCTO = od.Producto
    LEFT JOIN flexline.DocumentoD dcp WITH (NOLOCK) ON dcp.Empresa = od.Empresa AND dcp.TipoDocto = 'CONFIRMACION PROVEEDOR' AND dcp.TipoDoctoOrigen = od.TipoDocto AND dcp.CorrelativoOrigen = od.Correlativo AND dcp.SecuenciaOrigen = od.Secuencia
    LEFT JOIN flexline.Documento hcp WITH (NOLOCK) ON hcp.Empresa = dcp.Empresa AND hcp.TipoDocto = dcp.TipoDocto AND hcp.Correlativo = dcp.Correlativo AND hcp.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD dfe WITH (NOLOCK) ON dfe.Empresa = dcp.Empresa AND dfe.TipoDocto = 'FECHA EMBARQUE' AND dfe.TipoDoctoOrigen = dcp.TipoDocto AND dfe.CorrelativoOrigen = dcp.Correlativo AND dfe.SecuenciaOrigen = dcp.Secuencia
    LEFT JOIN flexline.Documento hfe WITH (NOLOCK) ON hfe.Empresa = dfe.Empresa AND hfe.TipoDocto = dfe.TipoDocto AND hfe.Correlativo = dfe.Correlativo AND hfe.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD dce WITH (NOLOCK) ON dce.Empresa = dfe.Empresa AND dce.TipoDocto = 'FECHA CONFIRMACION DE EMBARQUE' AND dce.TipoDoctoOrigen = dfe.TipoDocto AND dce.CorrelativoOrigen = dfe.Correlativo AND dce.SecuenciaOrigen = dfe.Secuencia
    LEFT JOIN flexline.Documento hce WITH (NOLOCK) ON hce.Empresa = dce.Empresa AND hce.TipoDocto = dce.TipoDocto AND hce.Correlativo = dce.Correlativo AND hce.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD dap WITH (NOLOCK) ON dap.Empresa = dce.Empresa AND dap.TipoDocto = 'FECHA ARRIBO PUERTO' AND dap.TipoDoctoOrigen = dce.TipoDocto AND dap.CorrelativoOrigen = dce.Correlativo AND dap.SecuenciaOrigen = dce.Secuencia
    LEFT JOIN flexline.Documento hap WITH (NOLOCK) ON hap.Empresa = dap.Empresa AND hap.TipoDocto = dap.TipoDocto AND hap.Correlativo = dap.Correlativo AND hap.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD dsp WITH (NOLOCK) ON dsp.Empresa = dap.Empresa AND dsp.TipoDocto = 'FECHA SALIDA PUERTO DE GUATEMALA' AND dsp.TipoDoctoOrigen = dap.TipoDocto AND dsp.CorrelativoOrigen = dap.Correlativo AND dsp.SecuenciaOrigen = dap.Secuencia
    LEFT JOIN flexline.Documento hsp WITH (NOLOCK) ON hsp.Empresa = dsp.Empresa AND hsp.TipoDocto = dsp.TipoDocto AND hsp.Correlativo = dsp.Correlativo AND hsp.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD dda WITH (NOLOCK) ON dda.Empresa = dsp.Empresa AND dda.TipoDocto = 'FECHA INGRESO DEPOSITO ADUANERO' AND dda.TipoDoctoOrigen = dsp.TipoDocto AND dda.CorrelativoOrigen = dsp.Correlativo AND dda.SecuenciaOrigen = dsp.Secuencia
    LEFT JOIN flexline.Documento hda WITH (NOLOCK) ON hda.Empresa = dda.Empresa AND hda.TipoDocto = dda.TipoDocto AND hda.Correlativo = dda.Correlativo AND hda.Vigencia <> 'A'
    LEFT JOIN flexline.DocumentoD din WITH (NOLOCK) ON din.Empresa = dda.Empresa AND din.TipoDoctoOrigen = dda.TipoDocto AND din.CorrelativoOrigen = dda.Correlativo AND din.SecuenciaOrigen = dda.Secuencia
    LEFT JOIN flexline.Documento hin WITH (NOLOCK) ON hin.Empresa = din.Empresa AND hin.TipoDocto = din.TipoDocto AND hin.Correlativo = din.Correlativo AND hin.Vigencia <> 'A'
    WHERE oc.Empresa = @empresa
      AND oc.TipoDocto = 'Orden de Compra'
      AND oc.Fecha >= @desde_d
      AND oc.Fecha <  @hasta_d
    ORDER BY oc.Numero, od.Producto
END
GO

-- Prueba:
-- EXEC flexline.pa_sel_um_cubo_tracking_oc 'VINOTECA', '20260101', '20261016'

-- Permiso para los usuarios del Excel (ajustar al rol/login que corresponda):
-- GRANT EXECUTE ON flexline.pa_sel_um_cubo_tracking_oc TO [rol_o_usuario]
