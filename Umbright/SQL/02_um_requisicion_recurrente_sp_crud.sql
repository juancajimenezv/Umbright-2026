-- ============================================================================
-- STORED PROCEDURES: CRUD Requisiciones Recurrentes
-- BD destino: SCM  |  Schema: flexline
--
-- SPs creados:
--   pa_ins_um_requisicion_recurrente        - Insertar plantilla (header)
--   pa_ins_um_requisicion_recurrente_det    - Insertar línea de detalle
--   pa_ins_um_requisicion_recurrente_dist   - Insertar distribución (costo/marca/gasto)
--   pa_ins_um_requisicion_recurrente_canal  - Insertar canal
--   pa_upd_um_requisicion_recurrente        - Actualizar header (Opción A: solo futuras)
--   pa_del_um_requisicion_recurrente_det    - Limpiar detalle y distribuciones (para re-guardar)
--   pa_sel_um_requisicion_recurrente        - Listar plantillas por empresa (grid)
--   pa_sel_um_requisicion_recurrenteId      - Obtener plantilla completa por id
--   pa_del_um_requisicion_recurrente        - Pausar / Activar / Eliminar plantilla
-- ============================================================================

USE [SCM]
GO

-- ----------------------------------------------------------------------------
-- 1. INSERT header de la plantilla
--    Retorna el id_recurrente generado en @PIdRecurrente OUTPUT
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_ins_um_requisicion_recurrente]
    @PEmpresa               VARCHAR(25),
    @PCodigo                VARCHAR(20),
    @PDescripcion           VARCHAR(200),
    @PProveedor             VARCHAR(25)     = NULL,
    @PMoneda                VARCHAR(25)     = NULL,
    @PObservaciones         VARCHAR(255)    = NULL,
    @PFechaInicio           DATE,
    @PFechaVencLicencia     DATE            = NULL,
    @PFechaVencRecurrencia  DATE,
    @PDiaFacturaMes         TINYINT         = NULL,
    @PFrecuencia            VARCHAR(20),
    @PDiasAnticipacion      INT             = 5,
    @PUsuarioResponsable    VARCHAR(25),
    @PUsuariosNotificar     VARCHAR(500)    = NULL,
    @PUsuarioCrea           VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRANSACTION
    BEGIN TRY

        DECLARE @ProximaGeneracion DATE
        SET @ProximaGeneracion = CASE @PFrecuencia
            WHEN 'MENSUAL'      THEN DATEADD(MONTH,  1, @PFechaInicio)
            WHEN 'BIMESTRAL'    THEN DATEADD(MONTH,  2, @PFechaInicio)
            WHEN 'TRIMESTRAL'   THEN DATEADD(MONTH,  3, @PFechaInicio)
            WHEN 'SEMESTRAL'    THEN DATEADD(MONTH,  6, @PFechaInicio)
            WHEN 'ANUAL'        THEN DATEADD(MONTH, 12, @PFechaInicio)
            ELSE @PFechaInicio
        END

        INSERT INTO [flexline].[um_requisicion_recurrente] (
            empresa, codigo, descripcion, proveedor, moneda, observaciones,
            fecha_inicio, fecha_venc_licencia, fecha_venc_recurrencia,
            dia_factura_mes, frecuencia, dias_anticipacion,
            usuario_responsable, usuarios_notificar,
            estado, proxima_generacion,
            usuario_creo, fecha_creo
        ) VALUES (
            @PEmpresa, @PCodigo, @PDescripcion, @PProveedor, @PMoneda, @PObservaciones,
            @PFechaInicio, @PFechaVencLicencia, @PFechaVencRecurrencia,
            @PDiaFacturaMes, @PFrecuencia, @PDiasAnticipacion,
            @PUsuarioResponsable, @PUsuariosNotificar,
            'ACTIVA', @ProximaGeneracion,
            @PUsuarioCrea, GETDATE()
        )

        DECLARE @NuevoId INT = SCOPE_IDENTITY()
        SELECT @NuevoId AS id_recurrente

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SELECT -1 AS id_recurrente
        DECLARE @MsgError VARCHAR(500) = ERROR_MESSAGE()
        RAISERROR('pa_ins_um_requisicion_recurrente: %s', 16, 1, @MsgError)
    END CATCH
END
GO

-- ----------------------------------------------------------------------------
-- 2. INSERT línea de detalle de la plantilla
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_ins_um_requisicion_recurrente_det]
    @PIdRecurrente  INT,
    @PLinea         INT,
    @PProducto      VARCHAR(25)     = NULL,
    @PDescripcion   VARCHAR(200)    = NULL,
    @PComentario    VARCHAR(255)    = NULL,
    @PCantidad      NUMERIC(10,2)   = 0,
    @PPrecio        NUMERIC(10,2)   = 0
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO [flexline].[um_requisicion_recurrente_detalle] (
        id_recurrente, linea, producto, descripcion, comentario, cantidad, precio
    ) VALUES (
        @PIdRecurrente, @PLinea, @PProducto, @PDescripcion, @PComentario, @PCantidad, @PPrecio
    )
END
GO

-- ----------------------------------------------------------------------------
-- 3. INSERT distribución (costo / marca / gasto) de la plantilla
--    @PTipo: CON_CCOSTO | CON_MARCA | CON_ITEM
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_ins_um_requisicion_recurrente_dist]
    @PIdRecurrente      INT,
    @PLinea             INT,
    @PProducto          VARCHAR(25),
    @PTipo              VARCHAR(25),        -- CON_CCOSTO | CON_MARCA | CON_ITEM
    @PCodigo            VARCHAR(50),
    @PPorcentaje        NUMERIC(8,2)    = 0,
    @PPorcEmpresa       NUMERIC(8,2)    = NULL,  -- solo CON_MARCA
    @PPorcSocio         NUMERIC(8,2)    = NULL,  -- solo CON_MARCA
    @PTipoGasto         VARCHAR(25)     = NULL   -- solo CON_ITEM
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO [flexline].[um_requisicion_recurrente_dist] (
        id_recurrente, linea, producto, tipo, codigo,
        porcentaje, porcentaje_empresa, porcentaje_socio, tipo_gasto
    ) VALUES (
        @PIdRecurrente, @PLinea, @PProducto, @PTipo, @PCodigo,
        @PPorcentaje,
        ISNULL(@PPorcEmpresa, 0),
        ISNULL(@PPorcSocio, 0),
        @PTipoGasto
    )
END
GO

-- ----------------------------------------------------------------------------
-- 4. INSERT canal de la plantilla
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_ins_um_requisicion_recurrente_canal]
    @PIdRecurrente  INT,
    @PCanal         VARCHAR(50),
    @PPorcentaje    NUMERIC(10,4)   = 0
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO [flexline].[um_requisicion_recurrente_canal] (
        id_recurrente, canal, porcentaje
    ) VALUES (
        @PIdRecurrente, @PCanal, @PPorcentaje
    )
END
GO

-- ----------------------------------------------------------------------------
-- 5. UPDATE header de plantilla (Opción A: solo afecta generaciones futuras)
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_upd_um_requisicion_recurrente]
    @PIdRecurrente          INT,
    @PDescripcion           VARCHAR(200),
    @PProveedor             VARCHAR(25)     = NULL,
    @PMoneda                VARCHAR(25)     = NULL,
    @PObservaciones         VARCHAR(255)    = NULL,
    @PFechaVencLicencia     DATE            = NULL,
    @PFechaVencRecurrencia  DATE,
    @PDiaFacturaMes         TINYINT         = NULL,
    @PFrecuencia            VARCHAR(20),
    @PDiasAnticipacion      INT             = 5,
    @PUsuarioResponsable    VARCHAR(25),
    @PUsuariosNotificar     VARCHAR(500)    = NULL,
    @PUsuarioModifica       VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @FechaBase DATE
    SELECT @FechaBase = ISNULL(ultima_generacion, fecha_inicio)
    FROM [flexline].[um_requisicion_recurrente]
    WHERE id_recurrente = @PIdRecurrente

    DECLARE @ProximaGeneracion DATE
    SET @ProximaGeneracion = CASE @PFrecuencia
        WHEN 'MENSUAL'      THEN DATEADD(MONTH,  1, @FechaBase)
        WHEN 'BIMESTRAL'    THEN DATEADD(MONTH,  2, @FechaBase)
        WHEN 'TRIMESTRAL'   THEN DATEADD(MONTH,  3, @FechaBase)
        WHEN 'SEMESTRAL'    THEN DATEADD(MONTH,  6, @FechaBase)
        WHEN 'ANUAL'        THEN DATEADD(MONTH, 12, @FechaBase)
        ELSE @FechaBase
    END

    UPDATE [flexline].[um_requisicion_recurrente] SET
        descripcion             = @PDescripcion,
        proveedor               = @PProveedor,
        moneda                  = @PMoneda,
        observaciones           = @PObservaciones,
        fecha_venc_licencia     = @PFechaVencLicencia,
        fecha_venc_recurrencia  = @PFechaVencRecurrencia,
        dia_factura_mes         = @PDiaFacturaMes,
        frecuencia              = @PFrecuencia,
        dias_anticipacion       = @PDiasAnticipacion,
        usuario_responsable     = @PUsuarioResponsable,
        usuarios_notificar      = @PUsuariosNotificar,
        proxima_generacion      = @ProximaGeneracion,
        usuario_modifico        = @PUsuarioModifica,
        fecha_modifico          = GETDATE()
    WHERE id_recurrente = @PIdRecurrente
END
GO

-- ----------------------------------------------------------------------------
-- 6. DELETE detalle y distribuciones de una plantilla (para re-guardar al editar)
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_del_um_requisicion_recurrente_det]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    DELETE FROM [flexline].[um_requisicion_recurrente_canal] WHERE id_recurrente = @PIdRecurrente
    DELETE FROM [flexline].[um_requisicion_recurrente_dist]  WHERE id_recurrente = @PIdRecurrente
    DELETE FROM [flexline].[um_requisicion_recurrente_detalle] WHERE id_recurrente = @PIdRecurrente
END
GO

-- ----------------------------------------------------------------------------
-- 7. SELECT listado para el grid de la pestaña Recurrentes
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente]
    @PEmpresa VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON
    SELECT
        r.id_recurrente,
        r.codigo,
        r.descripcion,
        r.proveedor,
        r.frecuencia,
        r.dia_factura_mes,
        r.fecha_venc_licencia,
        r.fecha_venc_recurrencia,
        r.ultima_generacion,
        r.proxima_generacion,
        r.estado,
        r.usuario_responsable,
        ISNULL(u.nombre, r.usuario_responsable) AS nombre_responsable,
        r.usuarios_notificar
    FROM [flexline].[um_requisicion_recurrente] r
    LEFT JOIN [flexline].[sg_usuario] u
        ON u.usuario = r.usuario_responsable
    WHERE r.empresa = @PEmpresa
    ORDER BY r.descripcion
END
GO

-- ----------------------------------------------------------------------------
-- 8a. SELECT header de plantilla por id
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrenteId]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT
        r.*,
        ISNULL(u.nombre, r.usuario_responsable) AS nombre_responsable
    FROM [flexline].[um_requisicion_recurrente] r
    LEFT JOIN [flexline].[sg_usuario] u
        ON u.usuario = r.usuario_responsable
    WHERE r.id_recurrente = @PIdRecurrente
END
GO

-- ----------------------------------------------------------------------------
-- 8b. SELECT detalle de líneas de plantilla
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_det]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_detalle]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY linea
END
GO

-- ----------------------------------------------------------------------------
-- 8c. SELECT distribuciones de plantilla (costo / marca / gasto)
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_dist]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_dist]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY linea, tipo, codigo
END
GO

-- ----------------------------------------------------------------------------
-- 8d. SELECT canal de plantilla
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_sel_um_requisicion_recurrente_canal]
    @PIdRecurrente INT
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM [flexline].[um_requisicion_recurrente_canal]
    WHERE id_recurrente = @PIdRecurrente
    ORDER BY canal
END
GO

-- ----------------------------------------------------------------------------
-- 9. Pausar / Activar / Eliminar plantilla
--    @PAccion: PAUSAR | ACTIVAR | ELIMINAR
--    Si ya tiene requisiciones generadas, ELIMINAR solo pausa.
-- ----------------------------------------------------------------------------
CREATE PROCEDURE [flexline].[pa_del_um_requisicion_recurrente]
    @PIdRecurrente  INT,
    @PAccion        VARCHAR(10),
    @PUsuario       VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON

    IF @PAccion = 'PAUSAR'
        UPDATE [flexline].[um_requisicion_recurrente] SET
            estado = 'PAUSADA', usuario_modifico = @PUsuario, fecha_modifico = GETDATE()
        WHERE id_recurrente = @PIdRecurrente

    ELSE IF @PAccion = 'ACTIVAR'
        UPDATE [flexline].[um_requisicion_recurrente] SET
            estado = 'ACTIVA', usuario_modifico = @PUsuario, fecha_modifico = GETDATE()
        WHERE id_recurrente = @PIdRecurrente

    ELSE IF @PAccion = 'ELIMINAR'
    BEGIN
        IF NOT EXISTS (
            SELECT 1 FROM [flexline].[requisicion]
            WHERE id_recurrente_origen = @PIdRecurrente
        )
        BEGIN
            DELETE FROM [flexline].[um_requisicion_recurrente_canal]   WHERE id_recurrente = @PIdRecurrente
            DELETE FROM [flexline].[um_requisicion_recurrente_dist]    WHERE id_recurrente = @PIdRecurrente
            DELETE FROM [flexline].[um_requisicion_recurrente_detalle] WHERE id_recurrente = @PIdRecurrente
            DELETE FROM [flexline].[um_requisicion_recurrente]         WHERE id_recurrente = @PIdRecurrente
        END
        ELSE
            -- Ya tiene requisiciones generadas, solo pausa
            UPDATE [flexline].[um_requisicion_recurrente] SET
                estado = 'PAUSADA', usuario_modifico = @PUsuario, fecha_modifico = GETDATE()
            WHERE id_recurrente = @PIdRecurrente
    END
END
GO

-- ============================================================================
-- VERIFICACION
-- ============================================================================
-- EXEC flexline.pa_sel_um_requisicion_recurrente 'EMPRESA'
-- ============================================================================
