-- =============================================================================
-- Permiso para actualizar la columna VIGENTE de flexline.producto
-- Ejecutar UNA sola vez en la BD FlexLine
-- =============================================================================

-- 1) Crear la opcion de menu (cod_menu = 16 = Mercadeo)
IF NOT EXISTS (
    SELECT 1
      FROM flexline.sg_menu_opcion
     WHERE nombre_opcion = 'mer_actProd_vigente'
)
BEGIN
    INSERT INTO flexline.sg_menu_opcion (cod_menu, nombre_opcion, opcion, estado)
    VALUES (16, 'mer_actProd_vigente', 'Actualizacion Productos / VIGENTE (Activar/Desactivar)', 1)
    PRINT 'Opcion mer_actProd_vigente creada.'
END
ELSE
BEGIN
    PRINT 'Opcion mer_actProd_vigente ya existe.'
END
GO

-- 2) Asignar el permiso a un usuario en una empresa
--    Editar @usuario y @empresa segun corresponda
--    Descomentar el bloque para asignar
/*
DECLARE @usuario varchar(50) = 'JJIMENEZ'
DECLARE @empresa varchar(20) = 'VINOTECA'

DECLARE @cod_opcion int
SELECT @cod_opcion = cod_opcion
  FROM flexline.sg_menu_opcion
 WHERE nombre_opcion = 'mer_actProd_vigente'

IF NOT EXISTS (
    SELECT 1
      FROM flexline.sg_usuario_menu_opcion_empresa
     WHERE usuario    = @usuario
       AND empresa    = @empresa
       AND cod_opcion = @cod_opcion
)
BEGIN
    INSERT INTO flexline.sg_usuario_menu_opcion_empresa (usuario, empresa, cod_opcion)
    VALUES (@usuario, @empresa, @cod_opcion)
    PRINT 'Permiso asignado a ' + @usuario + ' en ' + @empresa
END
ELSE
BEGIN
    PRINT 'Permiso ya existe.'
END
*/
