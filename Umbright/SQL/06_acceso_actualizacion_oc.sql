-- =============================================================================
-- Acceso: "Actualización OC"  (modulo Compras/Import, cod_menu = 14)
--   nombre_opcion = 'mci_actualización_oc'  <-- llave que usa el codigo VB
--   opcion        = 'Actualización OC'      <-- descripcion visible
-- Ejecutar UNA sola vez en la BD BDflexline
-- =============================================================================

-- 1) Crear la opcion en el catalogo de menu
IF NOT EXISTS (
    SELECT 1
      FROM flexline.sg_menu_opcion
     WHERE nombre_opcion = 'mci_actualización_oc'
)
BEGIN
    -- Tomar cod_menu / cod_sub_menu de una opcion hermana del mismo modulo
    -- (Tracking Orden de Compra ya vive en Compras/Import)
    DECLARE @cod_menu int, @cod_sub_menu int

    SELECT @cod_menu     = cod_menu,
           @cod_sub_menu = cod_sub_menu
      FROM flexline.sg_menu_opcion
     WHERE nombre_opcion = 'mci_tracking_orden_compra'

    -- Fallback por si no existe la hermana: Compras/Import = 14, sin sub-menu
    IF @cod_menu IS NULL     SET @cod_menu = 14
    IF @cod_sub_menu IS NULL SET @cod_sub_menu = 0

    INSERT INTO flexline.sg_menu_opcion
        (cod_menu, cod_sub_menu, opcion, nombre_opcion, estado, requiere_equipo)
    VALUES
        (@cod_menu, @cod_sub_menu, 'Actualización OC', 'mci_actualización_oc', 1, 0)

    PRINT 'Opcion mci_actualización_oc creada (cod_opcion=' + CAST(SCOPE_IDENTITY() AS varchar(10)) + ').'
END
ELSE
BEGIN
    PRINT 'Opcion mci_actualización_oc ya existe.'
END
GO

-- 2) (OPCIONAL) Asignar el acceso a un usuario en una empresa.
--    Editar @usuario y @empresa y descomentar el bloque.
/*
DECLARE @usuario varchar(50) = 'JJIMENEZ'
DECLARE @empresa varchar(20) = 'VINOTECA'

DECLARE @cod_opcion int
SELECT @cod_opcion = cod_opcion
  FROM flexline.sg_menu_opcion
 WHERE nombre_opcion = 'mci_actualización_oc'

IF NOT EXISTS (
    SELECT 1
      FROM flexline.sg_usuario_menu_opcion_empresa
     WHERE usuario    = @usuario
       AND empresa    = @empresa
       AND cod_opcion = @cod_opcion
)
BEGIN
    INSERT INTO flexline.sg_usuario_menu_opcion_empresa (empresa, usuario, cod_opcion)
    VALUES (@empresa, @usuario, @cod_opcion)
    PRINT 'Permiso asignado a ' + @usuario + ' en ' + @empresa
END
ELSE
BEGIN
    PRINT 'Permiso ya existe.'
END
*/
