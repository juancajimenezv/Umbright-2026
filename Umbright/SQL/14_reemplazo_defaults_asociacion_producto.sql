-- =============================================================================
-- Reemplaza las asociaciones SIN centro de costo de flexline.um_lgs_asociacion_producto
-- Ejecutar en la BD SCM.
--
-- El CC lo trae siempre LGS_SolicitudesPago; estas filas solo definen que
-- producto usar para un Item cuando no hay regla exacta CC + Item.
--
--   1) Borra todas las filas con CentroCosto NULL de la empresa (las 22 de
--      referencia de la carga inicial, todas con EsDefault = 0).
--   2) Inserta la asociacion correcta Item -> Producto con EsDefault = 1:
--        1141015 SEGURIDAD Y VIGILANCIA             -> 0901141015
--        1071010 ALQUILER DE TRANSPORTE FLETE - LGS -> 0901071010
--        1021015 HONORARIOS PROFESIONALES LEGALES   -> 0900940019
--        1062022 ALQUILER MONTACARGA                -> 0900940013
--        1111010 MANTENIMIENTO DE VEHICULOS         -> 0901111010
--        1191016 EMPAQUE Y EMBALAJE                 -> 0900910004
--   3) (@CrearDefaultsUnicos = 1) Crea tambien el default de cada Item que en
--      las reglas por CC apunta a UN solo producto (ej. 1063010, 1081015).
--      Sin esto, un CC que no este en la lista deja la solicitud con error.
--
-- Las reglas con CC no se tocan y tienen prioridad sobre el default
-- (ej. 1021015 con CC 1727 / 1730 sigue usando 0902024019).
--
-- Por defecto hace ROLLBACK (@Confirmar = 0). Revisar y re-ejecutar con 1.
-- =============================================================================

SET NOCOUNT ON
SET XACT_ABORT ON
SET QUOTED_IDENTIFIER ON    -- requerido por los indices filtrados de la tabla
SET ANSI_NULLS ON

DECLARE @Confirmar           bit
DECLARE @CrearDefaultsUnicos bit
DECLARE @Empresa             varchar(20)
DECLARE @Usuario             varchar(25)
SET @Confirmar           = 0    -- 1 = COMMIT
SET @CrearDefaultsUnicos = 1    -- 0 = solo los 6 items de la lista
SET @Empresa             = 'LOGISERV'
SET @Usuario             = LEFT(SUSER_SNAME(), 25)

DECLARE @Nuevos TABLE (
    ItemGasto           varchar(20)  PRIMARY KEY,
    DescripcionItem     varchar(150),
    Producto            varchar(20),
    DescripcionProducto varchar(150)
)
INSERT INTO @Nuevos (ItemGasto, DescripcionItem, Producto, DescripcionProducto)
SELECT '1141015', 'SEGURIDAD Y VIGILANCIA',             '0901141015', 'SEGURIDAD INSTALACIONES   - TIENDAS'
UNION ALL SELECT '1071010', 'ALQUILER DE TRANSPORTE FLETE - LGS', '0901071010', 'ALQUILER DE TRANSPORTE FLETE'
UNION ALL SELECT '1021015', 'HONORARIOS PROFESIONALES LEGALES',   '0900940019', 'HONORARIOS PROFESIONALES LEGALES'
UNION ALL SELECT '1062022', 'ALQUILER MONTACARGA',                '0900940013', 'ALQUILER DE MONTACARGAS'
UNION ALL SELECT '1111010', 'MANTENIMIENTO DE VEHICULOS',         '0901111010', 'MANTENIMIENTO DE VEHICULOS'
UNION ALL SELECT '1191016', 'EMPAQUE Y EMBALAJE',                 '0900910004', 'EMPAQUE Y EMBALAJE'

-- -----------------------------------------------------------------------------
-- Validacion: los productos deben existir una sola vez y vigentes
-- -----------------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM @Nuevos n
            WHERE (SELECT COUNT(*) FROM flexline.PRODUCTO p
                    WHERE p.EMPRESA = @Empresa AND p.PRODUCTO = n.Producto AND p.VIGENTE = 'S') <> 1)
BEGIN
    SELECT n.ItemGasto, n.Producto, 'Producto no existe, no vigente o duplicado en PRODUCTO' AS Error
      FROM @Nuevos n
     WHERE (SELECT COUNT(*) FROM flexline.PRODUCTO p
             WHERE p.EMPRESA = @Empresa AND p.PRODUCTO = n.Producto AND p.VIGENTE = 'S') <> 1
    RAISERROR('Hay productos invalidos, no se hizo ningun cambio.', 16, 1)
    RETURN
END

PRINT '--- Filas sin CC antes'
SELECT id, ItemGasto, Producto, EsDefault
  FROM flexline.um_lgs_asociacion_producto
 WHERE Empresa = @Empresa AND CentroCosto IS NULL
 ORDER BY ItemGasto, Producto

BEGIN TRAN

-- -----------------------------------------------------------------------------
-- 1) Borrar las asociaciones sin CC
-- -----------------------------------------------------------------------------
DELETE FROM flexline.um_lgs_asociacion_producto
 WHERE Empresa = @Empresa
   AND CentroCosto IS NULL

PRINT 'Filas sin CC borradas: ' + CAST(@@ROWCOUNT AS varchar(10))

-- -----------------------------------------------------------------------------
-- 2) Insertar la asociacion correcta (default por Item)
-- -----------------------------------------------------------------------------
INSERT INTO flexline.um_lgs_asociacion_producto
    (Empresa, Area, CentroCosto, GlosaCentroCosto, ItemGasto, DescripcionItem,
     Producto, DescripcionProducto, CuentaContable, DescCuentaContable,
     EsDefault, Vigente, UsuarioGrabo)
SELECT @Empresa, NULL, NULL, NULL, n.ItemGasto, n.DescripcionItem,
       n.Producto, n.DescripcionProducto, '613001001', 'GASTOS OPERACIONALES',
       1, 'S', @Usuario
  FROM @Nuevos n

PRINT 'Defaults de la lista insertados: ' + CAST(@@ROWCOUNT AS varchar(10))

-- -----------------------------------------------------------------------------
-- 3) Defaults de items con un solo producto en sus reglas por CC
-- -----------------------------------------------------------------------------
IF @CrearDefaultsUnicos = 1
BEGIN
    INSERT INTO flexline.um_lgs_asociacion_producto
        (Empresa, Area, CentroCosto, GlosaCentroCosto, ItemGasto, DescripcionItem,
         Producto, DescripcionProducto, CuentaContable, DescCuentaContable,
         EsDefault, Vigente, UsuarioGrabo)
    SELECT @Empresa, NULL, NULL, NULL, a.ItemGasto, MAX(a.DescripcionItem),
           MAX(a.Producto), MAX(a.DescripcionProducto), MAX(a.CuentaContable), MAX(a.DescCuentaContable),
           1, 'S', @Usuario
      FROM flexline.um_lgs_asociacion_producto a
     WHERE a.Empresa = @Empresa
       AND a.CentroCosto IS NOT NULL
       AND a.Vigente = 'S'
       AND a.ItemGasto NOT IN (SELECT ItemGasto FROM @Nuevos)
     GROUP BY a.ItemGasto
    HAVING COUNT(DISTINCT a.Producto) = 1

    PRINT 'Defaults por producto unico insertados: ' + CAST(@@ROWCOUNT AS varchar(10))

    PRINT '--- Items con varios productos por CC (sin default, solo regla exacta)'
    SELECT a.ItemGasto, MAX(a.DescripcionItem) AS descripcion, COUNT(DISTINCT a.Producto) AS productos
      FROM flexline.um_lgs_asociacion_producto a
     WHERE a.Empresa = @Empresa
       AND a.CentroCosto IS NOT NULL
       AND a.ItemGasto NOT IN (SELECT ItemGasto FROM @Nuevos)
     GROUP BY a.ItemGasto
    HAVING COUNT(DISTINCT a.Producto) > 1
END

-- -----------------------------------------------------------------------------
-- Verificacion
-- -----------------------------------------------------------------------------
PRINT '--- Defaults de la lista despues'
SELECT a.ItemGasto, a.Producto, a.EsDefault, a.Vigente
  FROM flexline.um_lgs_asociacion_producto a
 WHERE a.Empresa = @Empresa
   AND a.CentroCosto IS NULL
   AND a.ItemGasto IN (SELECT ItemGasto FROM @Nuevos)
 ORDER BY a.ItemGasto

PRINT '--- Totales'
SELECT EsDefault, CASE WHEN CentroCosto IS NULL THEN 'sin CC' ELSE 'con CC' END AS tipo, COUNT(*) AS filas
  FROM flexline.um_lgs_asociacion_producto
 WHERE Empresa = @Empresa
 GROUP BY EsDefault, CASE WHEN CentroCosto IS NULL THEN 'sin CC' ELSE 'con CC' END

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
