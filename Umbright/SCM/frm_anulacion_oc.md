# Documentacion tecnica - Pantalla **Anulacion OC**

Modulo: **Compras/Import** - Formulario: `frm_anulacion_oc` - Ubicacion: `Umbright/SCM/`

Permite **Anular** o dejar en **OnHold** una Orden de Compra de FlexLine, y **reversar** un OnHold previo. Sigue el mismo patron arquitectonico que la pantalla hermana `frm_actualizacion_oc` (ver `Umbright/SCM/frm_actualizacion_oc.md`), pero toda la logica de negocio vive en stored procedures nuevos (no hay SQL directo desde el codigo VB).

---

## 1. Archivos y registro

| Elemento | Ubicacion |
|---|---|
| Code-behind | `Umbright/SCM/frm_anulacion_oc.vb` |
| Disenador | `Umbright/SCM/frm_anulacion_oc.designer.vb` |
| Recursos | `Umbright/SCM/frm_anulacion_oc.resx` |
| Registro en proyecto | `Umbright/Umbright.vbproj` (2 `Compile` + 1 `EmbeddedResource`) |
| Acceso al menu | `Umbright/frm_menuprincipal.vb` (declaracion, instanciacion, registro en `Menu_Compras_Importaciones`, handler `mci_anular_oc_Click`) |
| Script SQL de stored procedures | `Umbright/SQL/08_sp_documento_anular.sql` |
| Script SQL de acceso/menu | `Umbright/SQL/09_acceso_anular_oc.sql` |

> **Codificacion:** `frm_menuprincipal.vb` esta en Windows-1252 (cp1252) y no tiene BOM. Los cambios sobre ese archivo se aplicaron con un script que respeta ese encoding byte a byte (ver nota de `frm_actualizacion_oc.md`: "editar con herramientas que preserven ese encoding"). Los archivos nuevos de esta pantalla (`frm_anulacion_oc.*`) usan unicamente texto ASCII (sin tildes) para no depender de ningun encoding especifico.

---

## 2. Acceso / permiso

- Menu **Compras/Import -> Anular OC** (`cod_menu = 14`, mismo nivel que "Tracking Orden de Compra" y "Actualizacion OC").
- Permiso en `flexline.sg_menu_opcion`:
  - `nombre_opcion = 'mci_anular_oc'` (llave que usa el codigo VB, sin tildes).
  - `opcion = 'Anular OC'`.
- Asignacion por usuario/empresa en `flexline.sg_usuario_menu_opcion_empresa`.
- Ademas de la visibilidad del menu, cada boton de accion (`PROCESAR`, `REVERSAR ONHOLD`) valida `tiene_permisos("mci_anular_oc")` antes de ejecutar el cambio (defensa en profundidad, igual patron usado en `Frm_Devoluciones.vb`).

---

## 3. Bases de datos y conexiones

| Conexion | Base | Uso |
|---|---|---|
| `FlexLine` | `bdflexline` | documento, tipodocumento; los 3 stored procedures nuevos |

Clase de acceso a datos: `Transaccional.Conexion("FlexLine")` -> `.open()`, `.Obtiene(sql)` (SELECT y tambien los SP de escritura, que devuelven un `SELECT Resultado, Mensaje` al final), `.close()`. No se usa SQL directo en ningun punto del code-behind: todo pasa por los 3 SPs.

---

## 4. Tabla involucrada

| Tabla | Rol |
|---|---|
| `flexline.documento` | Cabecera de la OC. Clave: `Empresa` + `TipoDocto` + `Numero` (10 digitos con ceros). |

Columnas relevantes: `Vigencia`, `PorcentajeAsignado`, `Comentario1`, `FechaEstado`, `FechaModif`, `UsuarioModif`.

---

## 5. Reglas de negocio y semantica de estados

- Solo se puede **Anular** o dejar en **OnHold** un documento con `Vigencia = 'S'` y `PorcentajeAsignado = 0`.
- Ambas acciones dejan `Vigencia = 'A'`. Como no existe una columna dedicada para distinguirlas, se usa el prefijo de `Comentario1`:
  - `'ANULAR: <motivo>'` -> estado **ANULADO** (definitivo, sin reversion en esta pantalla).
  - `'ONHOLD: <motivo>'` -> estado **ONHOLD** (temporal, reversible).
- Solo un documento en **ONHOLD** puede **reversarse**: vuelve a `Vigencia = 'S'` y `Comentario1 = 'REACTIVADO: <motivo>'`.
- Un documento ya **ANULADO** no tiene reversion en este alcance.
- El motivo es obligatorio en las 3 acciones (Anular, OnHold, Reversar), minimo 10 caracteres.

---

## 6. Stored Procedures (ver `Umbright/SQL/08_sp_documento_anular.sql`)

| SP | Tipo | Parametros | Uso |
|---|---|---|---|
| `flexline.pa_sel_um_documento_anular` | Consulta | `@empresa, @tipodocto, @numero` | Trae la cabecera + columnas calculadas `EstadoActual` (`VIGENTE`/`ONHOLD`/`ANULADO`), `PuedeAnular`, `PuedeReversar`, `MotivoNoAnula`. |
| `flexline.pa_upd_um_documento_anular` | Update | `@empresa, @tipodocto, @numero, @accion ('ANULAR'/'ONHOLD'), @motivo, @usuario` | Revalida `Vigencia='S' AND PorcentajeAsignado=0` dentro del propio UPDATE (atomico); si aplica, deja `Vigencia='A'` y el `Comentario1` con el prefijo de la accion; registra auditoria y devuelve `SELECT Resultado, Mensaje`. |
| `flexline.pa_upd_um_documento_reversar_onhold` | Update | `@empresa, @tipodocto, @numero, @motivo, @usuario` | Solo aplica si el documento esta en ONHOLD; regresa `Vigencia='S'`, registra auditoria y devuelve `SELECT Resultado, Mensaje`. |

Los 3 SPs revalidan las condiciones en el propio `UPDATE ... WHERE ...` (server-side, dentro de una transaccion explicita `BEGIN TRAN / COMMIT TRAN`), evitando condiciones de carrera entre la consulta y el clic del boton (por ejemplo, otro usuario ya proceso el mismo documento).

### Auditoria

Se reutiliza el log generico ya existente `pa_ins_um_gen_log_documento` (usado tambien por `frm_actualizacion_oc.vb` y `frm_OCconfirmacion.vb`), con una linea de actividad tipo `"ANULAR OC - Motivo: ..."`, `"ONHOLD OC - Motivo: ..."` o `"REVERSA ONHOLD OC - Motivo: ..."`. No se creo una tabla de log dedicada para esta pantalla (decision explicita: la trazabilidad que da el log generico es suficiente para este alcance).

---

## 7. Pantalla (`frm_anulacion_oc`)

### Busqueda (`gb_busqueda`)
Empresa (combo, empresas asignadas al usuario) + Tipo Docto (combo, preseleccionado "ORDEN DE COMPRA") + Numero (solo digitos, se completa a 10 con ceros) + botones Consultar / Limpiar.

### Documento (`gb_documento`, solo lectura)
Empresa, TipoDocto, Numero, Proveedor, Fecha, Total, Vigencia, % Asignado, Estado Actual, Comentario1 - resultado de `pa_sel_um_documento_anular`.

### Franja de estado (`lbl_estado`)
- Verde: "SE PUEDE ANULAR O DEJAR EN ONHOLD" (`EstadoActual = VIGENTE` y `PuedeAnular = 1`).
- Naranja: "DOCUMENTO EN ONHOLD" (`EstadoActual = ONHOLD`).
- Rojo: "DOCUMENTO ANULADO (definitivo, sin reversion)" o el `MotivoNoAnula` devuelto por el SP (documento no vigente, o con porcentaje ya asignado).

### Accion (`gb_accion`)
- Selector Anular / Dejar en OnHold (`rbn_anular` / `rbn_onhold`), visible solo cuando `PuedeAnular = 1`.
- Motivo (`txt_motivo`, minimo 10 caracteres), reutilizado tanto para Anular/OnHold como para Reversar.
- Boton **PROCESAR**: ejecuta `pa_upd_um_documento_anular` con la accion elegida; visible/habilitado solo cuando `PuedeAnular = 1`.
- Boton **REVERSAR ONHOLD**: ejecuta `pa_upd_um_documento_reversar_onhold`; visible/habilitado solo cuando `PuedeReversar = 1` (documento en ONHOLD).
- Reintento automatico ante deadlock (`EjecutarConReintento`, mismo patron que `frm_actualizacion_oc.vb`: hasta 3 intentos, 0.7s de espera).
- Al terminar cualquier accion (exitosa o no), la pantalla vuelve a consultar el documento para refrescar el estado real.

---

## 8. Flujo completo

```
1. CONSULTAR
   - Valida empresa/tipo/numero, completa numero a 10 ceros.
   - Llama pa_sel_um_documento_anular -> EstadoActual, PuedeAnular, PuedeReversar.
   - Pinta la franja de estado y muestra/oculta los controles de accion segun corresponda.

2a. VIGENTE y PuedeAnular=1
    - El usuario elige Anular u OnHold, captura motivo, presiona PROCESAR.
    - pa_upd_um_documento_anular revalida Vigencia='S' AND PorcentajeAsignado=0
      dentro del UPDATE; si ya no aplica, devuelve Resultado=0 y no cambia nada.
    - Si aplica: Vigencia='A', Comentario1 = '<ACCION>: <motivo>', log de auditoria,
      commit. Resultado=1 -> mensaje de exito -> reconsulta.

2b. ONHOLD
    - Solo aparece el boton REVERSAR ONHOLD.
    - El usuario captura el motivo de reactivacion y presiona REVERSAR ONHOLD.
    - pa_upd_um_documento_reversar_onhold revalida Vigencia='A' AND
      Comentario1 LIKE 'ONHOLD:%'; si aplica: Vigencia='S',
      Comentario1='REACTIVADO: <motivo>', log de auditoria, commit -> reconsulta.

2c. ANULADO
    - No hay ninguna accion disponible (definitivo en este alcance).
```

---

## 9. Recomendaciones

1. Ejecutar `Umbright/SQL/08_sp_documento_anular.sql` y `Umbright/SQL/09_acceso_anular_oc.sql` en `bdflexline` antes de habilitar el menu a los usuarios.
2. Asignar el permiso (`flexline.sg_usuario_menu_opcion_empresa`, `cod_opcion` de `mci_anular_oc`) solo a los usuarios que deban poder anular/onhold ordenes de compra.
3. Monitorear periodicamente documentos en estado ONHOLD (`Vigencia='A' AND Comentario1 LIKE 'ONHOLD:%'`) para detectar ordenes que quedaron en espera por mucho tiempo sin resolverse (anular definitivamente o reversar).
4. Antes de anular/onhold una orden, verificar manualmente si tiene documentos relacionados aguas abajo (recepciones, facturas, DUA) - el `PorcentajeAsignado=0` ya cubre el caso mas comun, pero para reglas adicionales de integridad referencial revisar el patron de `frm_OCconfirmacion.vb` (`pa_sel_um_documento_relacionado`).

---

*Documento generado para el equipo de desarrollo Umbright - pantalla Anulacion OC (Compras/Import).*
