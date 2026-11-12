-- =============================================================================
-- (Opcional) ALTER flexline.pa_upd_um_requisicion_anticipo
-- Umbright llama a este SP al generar la OC (estado 50 -> 60) con el valor del
-- combo "Anticipo". El combo solo tiene SI / NO / TC / FA: al abrir una
-- requisicion 'Auto' muestra NO, y al generar la OC la marca 'Auto' se perderia.
-- Cambio: si llega 'NO' y la requisicion esta en 'Auto', se conserva 'Auto'.
-- Cualquier otro valor (SI, TC, FA) se graba igual que antes. Adjuntos no cambia.
-- Ejecutar en SCM.
-- =============================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER   Procedure [flexline].[pa_upd_um_requisicion_anticipo]
@PEmpresa	As VarChar(25),
@PNumero	As VarChar(25),
@PUsuario	As VarChar(25),
@PAnticipo As VarChar(5)
As
Update requisicion
set Adjuntos = left(@PAnticipo,1),
TipoComprobante = CASE WHEN UPPER(@PAnticipo) = 'NO' AND TipoComprobante = 'Auto'
                       THEN TipoComprobante          -- requisicion automatica: se conserva
                       ELSE @PAnticipo END
Where Empresa = @PEmpresa
And Numero = @PNumero
GO
