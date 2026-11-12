-- =============================================================================
-- Ejecutar en 172.50.0.157, BD lgs_transportes (NO en SCM).
-- Agrega a dbo.LGS_SolicitudesPago el resultado de la interfaz
-- flexline.pa_pro_um_lgs_solicitudes_pago:
--   ErrorProceso  1 = la solicitud no se proceso por error
--                 0 = se proceso bien (se limpia al crear la requisicion)
--                 NULL = todavia no la evalua la interfaz
--   MensajeError  motivo del error (el mismo texto que queda en el log)
-- Desde SCM no se puede hacer: el servidor vinculado WMS_INTERFACE tiene
-- rpc_out apagado. Aplicar ANTES que el script 29.
-- =============================================================================
USE lgs_transportes
GO

IF COL_LENGTH('dbo.LGS_SolicitudesPago', 'ErrorProceso') IS NULL
    ALTER TABLE dbo.LGS_SolicitudesPago ADD ErrorProceso INT NULL
GO

IF COL_LENGTH('dbo.LGS_SolicitudesPago', 'MensajeError') IS NULL
    ALTER TABLE dbo.LGS_SolicitudesPago ADD MensajeError NVARCHAR(1000) NULL
GO
