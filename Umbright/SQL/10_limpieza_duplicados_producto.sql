-- =============================================================================
-- Limpieza de duplicados en flexline.PRODUCTO y flexline.ITEM_PRODUCTO
-- Ejecutar en la BD SCM.
--
-- Ninguna de las dos tablas tiene llave primaria (son HEAP), por eso aceptan
-- filas repetidas. pa_sel_um_producto / buscarProducto (frmRequisiciones.vb)
-- exigen 1 sola fila por producto: con duplicados muestra "producto no encontrado".
--
-- Alcance PRODUCTO (empresa LOGISERV), 11 codigos:
--   A) Duplicados identicos creados por la carga del 2026-10-05 (igamboa):
--      0901021024, 0901031011, 0901031012, 0901031014, 0901031015,
--      0901051110, 0901081015, 0901211010, 0901231025
--      -> se conserva la fila mas antigua.
--   B) Codigos que ya existian y la carga del 2026-10-05 los volvio a insertar:
--      0900940367 (se conserva la de 2024-07-18, TIPOPRODUCTO SERVICIOS)
--      0900950532 (se conserva la de 2015-10-29, TIPOPRODUCTO PROVEDURIA)
--      -> se borran solo las filas de la carga.
--
-- NO se tocan (requieren decision funcional, mismo codigo con distinto significado):
--   0900000169 (DMAR / DPUR), 0900005000 (DCDC / DMXG)          -> carga 2026-10-05
--   0000000001..0000000009, 0902024013..0902024016, 0900950295  -> historicos
--
-- Alcance ITEM_PRODUCTO: filas 100% identicas (todas las columnas), se deja 1.
--
-- Seguridad:
--   * Respalda las filas afectadas en tablas bk_ antes de borrar.
--   * Corre en transaccion y por defecto hace ROLLBACK (@Confirmar = 0).
--     Revisar los conteos y volver a ejecutar con @Confirmar = 1.
-- =============================================================================

SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @Confirmar          bit
DECLARE @SoloLogiservItem   bit
SET @Confirmar        = 0    -- 1 = COMMIT
SET @SoloLogiservItem = 1    -- 1 = ITEM_PRODUCTO solo LOGISERV, 0 = todas las empresas

DECLARE @Empresa            varchar(20)
DECLARE @CargaDesde         datetime
DECLARE @CargaHasta         datetime
SET @Empresa    = 'LOGISERV'
SET @CargaDesde = '20261005 11:32:00'   -- formato yyyymmdd: el servidor usa idioma espanol (dmy)
SET @CargaHasta = '20261005 11:35:00'

DECLARE @Productos TABLE (Producto varchar(20) PRIMARY KEY)
INSERT INTO @Productos (Producto)
SELECT '0901021024' UNION ALL SELECT '0901031011' UNION ALL SELECT '0901031012'
UNION ALL SELECT '0901031014' UNION ALL SELECT '0901031015' UNION ALL SELECT '0901051110'
UNION ALL SELECT '0901081015' UNION ALL SELECT '0901211010' UNION ALL SELECT '0901231025'
UNION ALL SELECT '0900940367' UNION ALL SELECT '0900950532'

-- -----------------------------------------------------------------------------
-- 0) Situacion inicial
-- -----------------------------------------------------------------------------
PRINT '--- PRODUCTO antes'
SELECT p.PRODUCTO, COUNT(*) AS filas
  FROM flexline.PRODUCTO p
  JOIN @Productos x ON x.Producto = p.PRODUCTO
 WHERE p.EMPRESA = @Empresa
 GROUP BY p.PRODUCTO
 ORDER BY p.PRODUCTO

PRINT '--- ITEM_PRODUCTO antes (grupos identicos repetidos)'
SELECT Empresa, COUNT(*) AS grupos, SUM(n - 1) AS sobrantes
  FROM (SELECT Empresa, Producto, Glosa, TipoProducto, Item, TipoIva, COUNT(*) AS n
          FROM flexline.ITEM_PRODUCTO
         WHERE (@SoloLogiservItem = 0 OR Empresa = @Empresa)
         GROUP BY Empresa, Producto, Glosa, TipoProducto, Item, TipoIva
        HAVING COUNT(*) > 1) d
 GROUP BY Empresa

BEGIN TRAN

-- -----------------------------------------------------------------------------
-- 1) Respaldos (se crean una sola vez; si ya existen se agregan filas)
-- -----------------------------------------------------------------------------
IF OBJECT_ID('flexline.bk_PRODUCTO_dup_20261005') IS NULL
    SELECT p.*, GETDATE() AS fecha_respaldo
      INTO flexline.bk_PRODUCTO_dup_20261005
      FROM flexline.PRODUCTO p
      JOIN @Productos x ON x.Producto = p.PRODUCTO
     WHERE p.EMPRESA = @Empresa
ELSE
    INSERT INTO flexline.bk_PRODUCTO_dup_20261005
    SELECT p.*, GETDATE()
      FROM flexline.PRODUCTO p
      JOIN @Productos x ON x.Producto = p.PRODUCTO
     WHERE p.EMPRESA = @Empresa

IF OBJECT_ID('flexline.bk_ITEM_PRODUCTO_dup_20261005') IS NULL
    SELECT i.*, GETDATE() AS fecha_respaldo
      INTO flexline.bk_ITEM_PRODUCTO_dup_20261005
      FROM flexline.ITEM_PRODUCTO i
     WHERE (@SoloLogiservItem = 0 OR i.Empresa = @Empresa)
ELSE
    INSERT INTO flexline.bk_ITEM_PRODUCTO_dup_20261005
    SELECT i.*, GETDATE()
      FROM flexline.ITEM_PRODUCTO i
     WHERE (@SoloLogiservItem = 0 OR i.Empresa = @Empresa)

-- -----------------------------------------------------------------------------
-- 2) PRODUCTO: dejar 1 fila por codigo (la mas antigua).
--    Solo se borran filas de la carga del 2026-10-05, nunca una historica.
-- -----------------------------------------------------------------------------
;WITH r AS (
    SELECT p.FECHAMODIF, p.USUARIOMODIF,
           ROW_NUMBER() OVER (PARTITION BY p.EMPRESA, p.PRODUCTO
                              ORDER BY p.FECHAMODIF, p.GLOSA) AS rn
      FROM flexline.PRODUCTO p
     WHERE p.EMPRESA = @Empresa
       AND p.PRODUCTO IN (SELECT Producto FROM @Productos)
)
DELETE FROM r
 WHERE rn > 1
   AND FECHAMODIF >= @CargaDesde
   AND FECHAMODIF <  @CargaHasta
   AND USUARIOMODIF = 'igamboa'

PRINT 'PRODUCTO filas borradas: ' + CAST(@@ROWCOUNT AS varchar(10))

-- -----------------------------------------------------------------------------
-- 3) ITEM_PRODUCTO: filas 100% identicas, dejar 1
-- -----------------------------------------------------------------------------
;WITH r AS (
    SELECT ROW_NUMBER() OVER (PARTITION BY Empresa, Producto, Glosa, TipoProducto, Item, TipoIva
                              ORDER BY (SELECT 1)) AS rn
      FROM flexline.ITEM_PRODUCTO
     WHERE (@SoloLogiservItem = 0 OR Empresa = @Empresa)
)
DELETE FROM r WHERE rn > 1

PRINT 'ITEM_PRODUCTO filas borradas: ' + CAST(@@ROWCOUNT AS varchar(10))

-- -----------------------------------------------------------------------------
-- 4) Verificacion: los 11 codigos deben quedar con 1 fila
-- -----------------------------------------------------------------------------
PRINT '--- PRODUCTO despues'
SELECT x.Producto, COUNT(p.PRODUCTO) AS filas,
       MIN(p.TIPOPRODUCTO) AS tipoproducto, MIN(p.FECHAMODIF) AS fechamodif
  FROM @Productos x
  LEFT JOIN flexline.PRODUCTO p ON p.EMPRESA = @Empresa AND p.PRODUCTO = x.Producto
 GROUP BY x.Producto
 ORDER BY x.Producto

IF EXISTS (SELECT 1
             FROM @Productos x
             LEFT JOIN flexline.PRODUCTO p ON p.EMPRESA = @Empresa AND p.PRODUCTO = x.Producto
            GROUP BY x.Producto
           HAVING COUNT(p.PRODUCTO) <> 1)
BEGIN
    PRINT 'ERROR: algun codigo no quedo con exactamente 1 fila. Se hace ROLLBACK.'
    ROLLBACK TRAN
    RETURN
END

PRINT '--- ITEM_PRODUCTO despues (debe venir vacio)'
SELECT Empresa, Producto, Item, COUNT(*) AS n
  FROM flexline.ITEM_PRODUCTO
 WHERE (@SoloLogiservItem = 0 OR Empresa = @Empresa)
 GROUP BY Empresa, Producto, Glosa, TipoProducto, Item, TipoIva
HAVING COUNT(*) > 1

IF @Confirmar = 1
BEGIN
    COMMIT TRAN
    PRINT '*** COMMIT realizado ***'
END
ELSE
BEGIN
    ROLLBACK TRAN
    PRINT '*** ROLLBACK (prueba). Cambiar @Confirmar = 1 para aplicar. ***'
END
