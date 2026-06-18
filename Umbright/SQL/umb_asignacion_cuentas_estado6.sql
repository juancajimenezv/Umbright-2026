-- ============================================================================
-- AUTOMATIZACIÓN: Asignar cuentas sugeridas al pasar una solicitud a estado 6
--                 (Pendiente de Operar en FlexLine)
--
-- BD destino: BDcorporativo
-- Objetos creados (todos nuevos, ninguno existente se modifica):
--   1. Tabla:        flexline.umb_solicitud_cuentas_sugeridas
--   2. SP:           flexline.pa_umb_asignar_cuentas_solicitud
--   3. Trigger:      flexline.trg_umb_asignar_cuentas_estado6
--   4. Backfill:     para solicitudes que ya están en estado 6
--
-- Cómo deshacer:    DROP TRIGGER, DROP PROCEDURE, DROP TABLE (en ese orden)
-- ============================================================================

USE BDcorporativo
GO

-- ============================================================================
-- 1. TABLA: guarda las cuentas sugeridas por solicitud
-- ============================================================================
IF OBJECT_ID('flexline.umb_solicitud_cuentas_sugeridas', 'U') IS NOT NULL
    DROP TABLE flexline.umb_solicitud_cuentas_sugeridas
GO

CREATE TABLE flexline.umb_solicitud_cuentas_sugeridas (
    cod_solicitud   int          NOT NULL PRIMARY KEY,
    empresa         varchar(25)  NULL,
    familia         varchar(25)  NULL,
    cta_compra      varchar(25)  NULL,
    cta_venta       varchar(25)  NULL,
    cta_costo       varchar(25)  NULL,
    cta_desc        varchar(25)  NULL,
    cta_dev         varchar(25)  NULL,
    cantidad_reps   int          NULL,     -- "confianza" — cuántas veces se usó esta combinación
    fecha_asignada  datetime     NOT NULL DEFAULT GETDATE(),
    nota            varchar(200) NULL      -- motivo si no se pudo asignar
)
GO

-- ============================================================================
-- 2. SP: lógica de asignación para UNA solicitud
--    Lo usa el trigger Y el script de backfill (DRY)
-- ============================================================================
IF OBJECT_ID('flexline.pa_umb_asignar_cuentas_solicitud', 'P') IS NOT NULL
    DROP PROCEDURE flexline.pa_umb_asignar_cuentas_solicitud
GO

CREATE PROCEDURE flexline.pa_umb_asignar_cuentas_solicitud
    @cod_solicitud int
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @cod_empresa int,
            @familia     varchar(25),
            @empresa     varchar(25)

    -- Leer empresa+familia de la solicitud
    SELECT @cod_empresa = cod_empresa,
           @familia     = familia
    FROM flexline.inv_producto_solicitud
    WHERE cod_solicitud = @cod_solicitud

    -- Traducir cod_empresa (int) → nombre empresa (varchar)
    IF @cod_empresa IS NOT NULL
        SELECT @empresa = descripcion
        FROM flexline.pg_empresa
        WHERE cod_empresa = @cod_empresa

    DECLARE @cta_compra varchar(25),
            @cta_venta  varchar(25),
            @cta_costo  varchar(25),
            @cta_desc   varchar(25),
            @cta_dev    varchar(25),
            @reps       int

    -- Buscar las cuentas más usadas (vía linked server INTERFAZFLEX → BDFlexline)
    IF @empresa IS NOT NULL AND @familia IS NOT NULL
    BEGIN
        ;WITH CuentasAgrupadas AS (
            SELECT
                CUENTACOMPRA, CUENTAVENTA, CUENTACOSTO, Cuentadesc, Cuentadev,
                COUNT(*) AS Reps
            FROM INTERFAZFLEX.bdflexline.flexline.PRODUCTO
            WHERE EMPRESA = @empresa
              AND FAMILIA = @familia
              AND ISNULL(CUENTACOMPRA, '') <> ''
              AND ISNULL(CUENTAVENTA,  '') <> ''
              AND ISNULL(CUENTACOSTO,  '') <> ''
              AND ISNULL(Cuentadesc,   '') <> ''
              AND ISNULL(Cuentadev,    '') <> ''
            GROUP BY CUENTACOMPRA, CUENTAVENTA, CUENTACOSTO, Cuentadesc, Cuentadev
        )
        SELECT TOP 1
            @cta_compra = LTRIM(RTRIM(CUENTACOMPRA)),
            @cta_venta  = LTRIM(RTRIM(CUENTAVENTA)),
            @cta_costo  = LTRIM(RTRIM(CUENTACOSTO)),
            @cta_desc   = LTRIM(RTRIM(Cuentadesc)),
            @cta_dev    = LTRIM(RTRIM(Cuentadev)),
            @reps       = Reps
        FROM CuentasAgrupadas
        ORDER BY Reps DESC
    END

    -- Nota explicativa si no se logró asignar
    DECLARE @nota varchar(200) = NULL
    IF @empresa IS NULL
        SET @nota = 'No se identifico la empresa (cod_empresa NULL o no esta en pg_empresa)'
    ELSE IF @familia IS NULL OR LTRIM(RTRIM(@familia)) = ''
        SET @nota = 'Familia vacia en la solicitud'
    ELSE IF @cta_compra IS NULL
        SET @nota = 'Sin historico de cuentas para empresa=' + @empresa + ', familia=' + @familia

    -- Upsert
    MERGE flexline.umb_solicitud_cuentas_sugeridas AS dst
    USING (SELECT @cod_solicitud AS cod_solicitud) AS src
        ON dst.cod_solicitud = src.cod_solicitud
    WHEN MATCHED THEN UPDATE SET
        empresa        = @empresa,
        familia        = @familia,
        cta_compra     = @cta_compra,
        cta_venta      = @cta_venta,
        cta_costo      = @cta_costo,
        cta_desc       = @cta_desc,
        cta_dev        = @cta_dev,
        cantidad_reps  = @reps,
        fecha_asignada = GETDATE(),
        nota           = @nota
    WHEN NOT MATCHED THEN INSERT
        (cod_solicitud, empresa, familia, cta_compra, cta_venta, cta_costo,
         cta_desc, cta_dev, cantidad_reps, nota)
        VALUES (@cod_solicitud, @empresa, @familia, @cta_compra, @cta_venta,
                @cta_costo, @cta_desc, @cta_dev, @reps, @nota);
END
GO

-- ============================================================================
-- 3. TRIGGER: dispara al pasar la solicitud a estado 6
-- ============================================================================
IF OBJECT_ID('flexline.trg_umb_asignar_cuentas_estado6', 'TR') IS NOT NULL
    DROP TRIGGER flexline.trg_umb_asignar_cuentas_estado6
GO

CREATE TRIGGER flexline.trg_umb_asignar_cuentas_estado6
ON flexline.inv_producto_solicitud
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON

    -- Salir rápido si no se tocó la columna estado
    IF NOT UPDATE(estado) RETURN

    -- Procesar SOLO las filas donde estado pasó de "no 6" a "6"
    DECLARE @cod_solicitud int
    DECLARE c CURSOR LOCAL FAST_FORWARD FOR
        SELECT i.cod_solicitud
        FROM inserted i
        INNER JOIN deleted  d ON d.cod_solicitud = i.cod_solicitud
        WHERE i.estado = 6
          AND ISNULL(d.estado, 0) <> 6

    OPEN c
    FETCH NEXT FROM c INTO @cod_solicitud
    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            EXEC flexline.pa_umb_asignar_cuentas_solicitud @cod_solicitud
        END TRY
        BEGIN CATCH
            -- Si algo falla (linked server caído, etc.) no abortar el UPDATE original.
            -- Solo loguear y seguir.
            INSERT INTO flexline.umb_solicitud_cuentas_sugeridas (cod_solicitud, nota)
            SELECT @cod_solicitud,
                   'ERROR en trigger: ' + LEFT(ERROR_MESSAGE(), 180)
            WHERE NOT EXISTS (
                SELECT 1 FROM flexline.umb_solicitud_cuentas_sugeridas
                WHERE cod_solicitud = @cod_solicitud
            )
        END CATCH
        FETCH NEXT FROM c INTO @cod_solicitud
    END
    CLOSE c
    DEALLOCATE c
END
GO

-- ============================================================================
-- 4. BACKFILL: procesar las solicitudes que YA están en estado 6
-- ============================================================================
PRINT '----- Iniciando backfill de solicitudes existentes en estado 6 -----'

DECLARE @total int = (SELECT COUNT(*) FROM flexline.inv_producto_solicitud WHERE estado = 6)
PRINT 'Solicitudes en estado 6 detectadas: ' + CAST(@total AS varchar(10))

DECLARE @cod_solicitud int
DECLARE bk CURSOR LOCAL FAST_FORWARD FOR
    SELECT cod_solicitud
    FROM flexline.inv_producto_solicitud
    WHERE estado = 6

OPEN bk
FETCH NEXT FROM bk INTO @cod_solicitud
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC flexline.pa_umb_asignar_cuentas_solicitud @cod_solicitud
    FETCH NEXT FROM bk INTO @cod_solicitud
END
CLOSE bk
DEALLOCATE bk

PRINT '----- Backfill terminado -----'
GO

-- ============================================================================
-- 5. VERIFICACIÓN
-- ============================================================================
SELECT
    COUNT(*)                                              AS Total,
    SUM(CASE WHEN cta_compra IS NOT NULL THEN 1 ELSE 0 END) AS Con_Cuentas_Asignadas,
    SUM(CASE WHEN cta_compra IS NULL     THEN 1 ELSE 0 END) AS Sin_Asignar_Con_Motivo
FROM flexline.umb_solicitud_cuentas_sugeridas
GO

-- Ver detalle:
SELECT TOP 50 *
FROM flexline.umb_solicitud_cuentas_sugeridas
ORDER BY fecha_asignada DESC
GO

-- Ver las que no se pudieron asignar y por qué:
SELECT cod_solicitud, empresa, familia, nota
FROM flexline.umb_solicitud_cuentas_sugeridas
WHERE cta_compra IS NULL
ORDER BY cod_solicitud DESC
GO

-- ============================================================================
-- CÓMO REVERTIR TODO (si algo sale mal)
-- ============================================================================
-- DROP TRIGGER   flexline.trg_umb_asignar_cuentas_estado6
-- DROP PROCEDURE flexline.pa_umb_asignar_cuentas_solicitud
-- DROP TABLE     flexline.umb_solicitud_cuentas_sugeridas
-- ============================================================================
