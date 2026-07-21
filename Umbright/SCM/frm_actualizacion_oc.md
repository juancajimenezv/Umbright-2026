# Documentación técnica — Pantalla **Actualización OC**

Módulo: **Compras/Import** · Formulario: `frm_actualizacion_oc` · Ubicación: `Umbright/SCM/`

Permite **consultar** una Orden de Compra, **habilitar su período** si está cerrado, **modificar / agregar / eliminar** líneas del detalle, **guardar** los cambios y **regresar la orden a su período original** — todo con **auditoría completa** en un log dedicado.

---

## 1. Archivos y registro

| Elemento | Ubicación |
|---|---|
| Code-behind | `Umbright/SCM/frm_actualizacion_oc.vb` |
| Diseñador | `Umbright/SCM/frm_actualizacion_oc.designer.vb` |
| Recursos | `Umbright/SCM/frm_actualizacion_oc.resx` |
| Registro en proyecto | `Umbright/Umbright.vbproj` (2 `Compile` + 1 `EmbeddedResource`) |
| Acceso al menú | `Umbright/frm_menuprincipal.vb` (6 puntos, `mci_actualizacion_oc`) |
| Script SQL acceso | `Umbright/SQL/06_acceso_actualizacion_oc.sql` |
| Script SQL log | `Umbright/SQL/07_log_actualizacion_oc.sql` |

> **Codificación:** los `.vb` están en **Windows-1252 (cp1252)**. Editar con herramientas que preserven ese encoding; de lo contrario se corrompen los acentos.

---

## 2. Acceso / permiso

- Menú **Compras/Import → Actualización OC** (`cod_menu = 14`).
- Permiso en `bdflexline.flexline.sg_menu_opcion`:
  - `nombre_opcion = 'mci_actualización_oc'` (**con tilde** — la llave debe coincidir carácter por carácter con el `RowFilter` del código).
  - `opcion = 'Actualización OC'`, `cod_opcion = 958`.
- Asignación por usuario/empresa en `flexline.sg_usuario_menu_opcion_empresa` (`cod_opcion = 958`).
- Handler que abre la pantalla: `mci_actualizacion_oc_Click` (con `ShowDialog`).

---

## 3. Bases de datos y conexiones

| Conexión | Base | Servidor | Uso |
|---|---|---|---|
| `FlexLine` | `bdflexline` | 172.50.0.150 | documento, documentod, tipodocumento, producto |
| `SCM` | `scm` | 172.50.0.150 | log de auditoría `scm.dbo.log_actualizacion_oc` |

Ambas bases están en el **mismo servidor SQL**, por eso las escrituras al log se hacen con nombre completo `scm.dbo.log_actualizacion_oc` **dentro de la misma transacción** de la conexión FlexLine (no requiere MSDTC). El login `flexinterface` tiene acceso a ambas bases.

Clases de acceso a datos:
- `Transaccional.Conexion(con)` → `.open()`, `.Obtiene(sql)` (SELECT), `.Actualiza(sql)` (INSERT/UPDATE/DELETE), `.close()`.
- `ClasesGenerales.General.selectQuery(con, sql)` (SELECT rápido), `.insertQuery(con, sql)`, `.ValoresDistinto(...)`.

---

## 4. Tablas involucradas

| Tabla | Rol |
|---|---|
| `flexline.documento` | Cabecera de la OC. Clave: `empresa` + `TipoDocto` + `numero` (10 dígitos con ceros). |
| `flexline.documentod` | Detalle (líneas). Se liga por `empresa` + `TipoDocto` + `correlativo`. |
| `flexline.tipodocumento` | Catálogo de tipos de documento (llena el combo TipoDocto). |
| `flexline.producto` | Catálogo de productos; de aquí sale `factoralt` (factor de empaque). |
| `scm.dbo.log_actualizacion_oc` | Log de auditoría de esta pantalla. |

Relación clave: `documento.Numero` = 10 dígitos con ceros (`0000003645`); `documento.Correlativo` = número sin ceros (`3645`). El detalle **se busca por `Correlativo`**, no por `Numero`.

---

## 5. Barra de búsqueda (`gb_busqueda`)

| Control | Descripción |
|---|---|
| **Empresa** (`cmb_empresa`) | Empresas asignadas al usuario: `pa_sel_um_sg_usuario_empresa '<usuario>'`. Preselecciona la empresa actual (`gs_empresa`). |
| **TipoDocto** (`cmb_tipodocto`) | Tipos de orden de compra de la empresa: `select TipoDocto from flexline.tipodocumento where empresa=… and tipodocto like '%ORDEN%COMPRA%'`. Preselecciona "ORDEN DE COMPRA". |
| **Número** (`txt_numero`) | Solo dígitos (máx. 10). Al consultar se **completa a 10 con ceros a la izquierda**. Enter también consulta. |
| **Consultar** (`btn_consultar`) | Ejecuta la consulta. |
| **Limpiar** (`btn_limpiar`) | Limpia la pantalla (avisa si hay cambios pendientes o la orden quedó habilitada). |
| **HABILITAR EDICIÓN** (`chk_habilitar_edicion`) | Interruptor general. Activa/bloquea la edición del detalle y de los campos editables de la cabecera. Solo se puede activar si la orden está en **período abierto**. |

---

## 6. Panel **DOCUMENTO** (`gb_documento`) — cabecera

Campos mostrados (nombres = columnas reales de `flexline.documento`), en **solo lectura** salvo los indicados:

`Empresa, TipoDocto, Numero, Correlativo, Proveedor, Moneda, Vigencia, Emitido, Valoriza, Aprobacion, UsuarioModif, PeriodoLibro*, Fecha*, FechaVcto, FechaComprobante, FechaEstado, FechaModif, FechaUModif, FechaCierre, FechaAprueba, Neto, SubTotal, Total, NetoIngreso, SubTotalIngreso, TotalIngreso`

- **`PeriodoLibro`** y **`Fecha`** (marcados `*`) → se vuelven **editables** cuando se activa HABILITAR EDICIÓN (fondo blanco). El resto queda bloqueado (gris).
- **Datos crudos tal cual la BD**: fechas completas (`yyyy-MM-dd HH:mm:ss.fff`, incluida `1900-01-01`), montos con todos los decimales, `NULL` visible como texto.
- `Paridad` no se muestra pero se usa internamente para los montos de ingreso.

**Franja de estado de período** (`lbl_estado_periodo`):
- 🟢 `ORDEN HABILITADA PARA ACTUALIZAR - SE ENCUENTRA EN PERIODO ABIERTO`
- 🔴 `ORDEN DESHABILITADA PARA ACTUALIZAR - SE ENCUENTRA EN PERIODO CERRADO`

Regla: **período ABIERTO** = `documento.Fecha` es del **mismo mes y año** que hoy. **CERRADO** = mes anterior o más atrás.

---

## 7. Sección **Habilitar Período** (`gb_habilitar`) — visible solo cuando aplica

| Control | Descripción |
|---|---|
| **Nueva Fecha** (`dtp_nueva_fecha`) | Fecha destino para habilitar (debe ser del **mes actual**). |
| `lbl_periodo_calc` | Muestra el `PeriodoLibro` calculado (aaaamm) de la nueva fecha. |
| **Habilitar Período** (`btn_habilitar`) | Aplica la habilitación. |
| `lbl_periodo_original` | Muestra el período original capturado. |
| **Regresar a Período Original** (`btn_restaurar`) | Devuelve la orden a su fecha/período original. |

---

## 8. Panel **DOCUMENTO DETALLE** (`dgv_detalle`)

Se llena con el detalle (`flexline.documentod`) ligado por `Correlativo`. Columnas mostradas:

`Sel (check), Empresa, TipoDocto, Correlativo, Linea, Secuencia, Producto*, Cantidad*, UnidadIngreso, Precio*, PrecioAjustado, PorcentajeDR, SubTotal, Neto, Total, CantidadIngreso, PrecioIngreso, SubTotalIngreso, NetoIngreso, TotalIngreso, Bodega, Fecha*, FechaEntrega*, FechaVcto*, FechaModif, FechaVigenciaLp, Vigente, Comentario`

- **Columnas editables** (marcadas `*`): `Producto, Cantidad, Precio, Fecha, FechaEntrega, FechaVcto`. Se editan **directo en la celda** (las fechas con **calendario desplegable**).
- **`Sel`** = casilla para marcar varias líneas y eliminarlas en lote.
- Columnas internas ocultas: `srcLinea`, `factorUnidad`.

**Colores del grid:**
| Color | Significado |
|---|---|
| Gris | Bloqueado / no editable (modo consulta o columna no autorizada) |
| Blanco | Editable (con HABILITAR EDICIÓN activo) |
| 🟢 Verde | Línea nueva (pendiente de guardar) |
| 🟡 Amarillo | Línea modificada |
| 🔴 Rojo | Línea marcada para eliminar (`Vigente='N'`) |

**Botones del detalle:**
| Botón | Acción |
|---|---|
| **Agregar Línea** (`btn_agregar`) | Agrega una **línea nueva en blanco**: hereda campos técnicos de una línea base, fija Empresa/TipoDocto/Correlativo, asigna Línea/Secuencia consecutivas, deja editables y calculados en blanco/cero. |
| **Eliminar Línea(s) marcadas** (`btn_eliminar`) | Marca como `Vigente='N'` las líneas con check (con confirmación). Las nuevas sin guardar se quitan directo. |
| **Descartar cambios** (`btn_descartar`) | Revierte todos los cambios pendientes del detalle. |
| **GUARDAR CAMBIOS** (`btn_guardar`) | Aplica todo en una sola transacción (ver §11). |
| `lbl_cambios` | Contador: "N modificadas, N nuevas, N eliminadas". |

---

## 9. Fórmulas de cálculo (al editar Cantidad o Precio)

Con `factor = flexline.producto.factoralt` (del producto de la línea; si es 0/nulo → 1) y `Paridad` de la cabecera:

```
Neto            = Cantidad × Precio
SubTotal        = Total = Neto
PrecioAjustado  = Precio
CantidadIngreso = Cantidad ÷ factor
NetoIngreso     = SubTotalIngreso = TotalIngreso = Neto ÷ Paridad
PrecioIngreso   = NetoIngreso ÷ CantidadIngreso
```

Al **guardar**, los totales de la **cabecera** (`documento`) se recalculan como la **suma del detalle vigente** (`Vigente='S'`) y se actualiza `FechaModif`, `FechaUModif`, `UsuarioModif`.

---

## 10. Validaciones

| Punto | Regla |
|---|---|
| Consulta | Empresa y TipoDocto obligatorios; Número solo dígitos; se completa a 10 con ceros. |
| Cantidad | Numérica y **> 0**. |
| Precio | Numérico y **≥ 0**. |
| Producto | Debe existir en `flexline.producto` de la empresa. |
| Fecha (celda) | Fecha válida (`aaaa-mm-dd`). |
| Nueva fecha (habilitar) | Debe ser del **mes actual** (período abierto). |
| Cabecera Fecha/PeriodoLibro | Fecha válida; PeriodoLibro numérico de 6 dígitos (`aaaamm`). |

---

## 11. Flujo completo (orden de las acciones)

```
1. CONSULTAR
   - Valida empresa/tipo/número, completa número a 10 ceros.
   - Carga cabecera (documento) y detalle (documentod por Correlativo).
   - RecuperarHabilitacion(): lee el log; si hay HABILITA_PERIODO 'ABIERTA'
     y el PeriodoLibro real coincide con el habilitado -> marca la orden como
     habilitada y recupera fecha/periodo original de la BD.
   - ValidarPeriodo(): pinta la franja verde/roja.

2a. PERÍODO ABIERTO (verde)
    - Se puede activar HABILITAR EDICIÓN.
    - (Si venía habilitada) aparece el botón "Regresar a Período Original".

2b. PERÍODO CERRADO (rojo)
    - Pregunta "¿Necesita habilitar el periodo?".
    - Si SÍ: captura Fecha/Periodo ORIGINAL, pide Nueva Fecha (mes actual).
    - HABILITAR PERÍODO ->
        update documento (fecha, PeriodoLibro, Valoriza='S')
        update documentod (fecha)
        log HABILITA_PERIODO (estado='ABIERTA')   [misma transacción]
      -> reconsulta -> ahora ABIERTA.

3. EDITAR (con HABILITAR EDICIÓN activo)
   - Modificar celdas (Producto/Cantidad/Precio/fechas) -> recalcula la fila.
   - Agregar Línea / Eliminar (check) Línea(s).
   - Editar Fecha/PeriodoLibro de la cabecera (opcional).

4. GUARDAR CAMBIOS  (una sola transacción)
   - INSERT/UPDATE de documentod (líneas nuevas/modificadas/eliminadas).
   - UPDATE documento: recalcula totales + FechaModif/UsuarioModif.
   - Si cambió cabecera: update documento (fecha/PeriodoLibro/Valoriza='S') + documentod.
   - LOG por cada cambio: AGREGA_LINEA / ELIMINA_LINEA / MODIFICA_LINEA (por campo) / MODIFICA_CABECERA.
   - commit -> reconsulta.

5. REGRESAR A PERÍODO ORIGINAL
   - update documento (fecha/PeriodoLibro original, Valoriza='S')
   - update documentod (fecha original)
   - log CIERRA_PERIODO + marca la habilitación como estado='CERRADA'   [misma transacción]
   - La orden queda cerrada de nuevo.
```

> **Regla de oro:** toda orden que se **abre** (habilita período) **debe cerrarse** (regresar a su período original) al terminar. La pantalla avisa al cerrar/limpiar si queda habilitada.

---

## 12. Log de auditoría — `scm.dbo.log_actualizacion_oc`

Un solo log para todo. Se escribe **dentro de la misma transacción** de cada operación (si falla algo, se revierte también el log).

**Acciones (`accion`):** `HABILITA_PERIODO`, `CIERRA_PERIODO`, `AGREGA_LINEA`, `ELIMINA_LINEA`, `MODIFICA_LINEA`, `MODIFICA_CABECERA`.

**Columnas:** `id, empresa, tipodocto, numero, correlativo, accion, linea, secuencia, producto, campo, valor_anterior, valor_nuevo, fecha_original, periodo_original, fecha_habilitada, periodo_habilitado, estado, usuario, equipo, aplicacion, fecha_hora, observacion`.

- **MODIFICA_LINEA**: una fila **por cada campo cambiado** (con `campo`, `valor_anterior`, `valor_nuevo`).
- **HABILITA_PERIODO**: guarda `fecha_original`, `periodo_original`, `fecha_habilitada`, `periodo_habilitado`, `estado='ABIERTA'`.
- **CIERRA_PERIODO**: registra el cierre y marca la habilitación previa como `estado='CERRADA'`.

**Consultas de control:**
```sql
-- Órdenes abiertas (período habilitado) que NO se han regresado
select * from scm.dbo.log_actualizacion_oc
 where accion='HABILITA_PERIODO' and estado='ABIERTA' order by fecha_hora;

-- Historial completo de una orden
select * from scm.dbo.log_actualizacion_oc
 where empresa='DIUVA' and tipodocto='ORDEN DE COMPRA' and numero='0000003645'
 order by fecha_hora, linea;
```

**Autocorrección (validación cruzada):** al consultar, si el log dice `ABIERTA` pero el `PeriodoLibro` real del documento ya **no coincide** con el habilitado (p. ej. la regresaron por SQL directo), la pantalla **marca esa habilitación como `CERRADA`** (`observacion = 'Cerrada externamente - detectado al consultar'`) y permite habilitarla de nuevo. La verdad siempre la manda la **fecha real del documento**.

---

## 13. Transacciones y robustez

- Habilitar, regresar y guardar se ejecutan como **`set xact_abort on begin tran … commit tran`** — todo o nada.
- **Reintento automático ante deadlock** (`EjecutarConReintento`): si SQL reporta interbloqueo (error 1205 / "interbloqueo"/"deadlock"), reintenta hasta **3 veces** con espera de 0.7 s.
- Escrituras del log en la **misma transacción** que la operación (mismo servidor, cross-database).

---

## 14. Recomendaciones

1. **Cerrar siempre lo que se abre:** tras actualizar una OC de período cerrado, regresarla a su período original **desde la pantalla** (no por SQL) para conservar la trazabilidad de quién/cuándo la cerró.
2. **Monitoreo periódico:** revisar `estado='ABIERTA'` para detectar órdenes que quedaron abiertas sin cerrar.
3. **Evitar edición simultánea:** no tener la misma OC abierta en FlexLine y en esta pantalla a la vez (genera deadlocks; el reintento ayuda pero no siempre).
4. **SQL directo solo en emergencia:** si se regresa una OC por SQL, la pantalla lo detecta y autocorrige el log, pero se pierde el detalle de auditoría del cierre.
5. **Permisos:** el acceso se asigna por usuario/empresa; validar que el usuario tenga la empresa correspondiente.

---

## 15. Pendientes / mejoras futuras

- Reporte/consulta visual dentro de la app para el log (hoy se consulta por SQL).
- Posible limpieza de la columna interna `factorUnidad` (quedó sin uso tras usar `producto.factoralt`).
- Considerar bloqueo optimista / aviso si otro usuario modificó la OC entre la consulta y el guardado.

---

*Documento generado para el equipo de desarrollo Umbright — pantalla Actualización OC (Compras/Import).*
