# Umbright 2026

Sistema ERP de Umbral (módulos comerciales, finanzas, mercadeo, RRHH, logística, compras).
Aplicación Windows Forms en **VB.NET / C#** sobre **.NET Framework**.

---

## 🚀 Inicio rápido (clone → compile → run)

Si solo quieres correr el sistema:

```bash
git clone https://github.com/juancajimenezv/UMBRIGHT-2026.git
cd UMBRIGHT-2026
```

Luego en Visual Studio:
1. Abre `Umbright/Umbright.sln`
2. **Build → Compilar solución** (o `Ctrl + Shift + B`)
3. **F5** para ejecutar

✅ Debería compilar y correr sin errores.

> ⚠️ Necesitas estar en la **red interna de Umbral** o conectado por VPN para que el sistema pueda conectar a la BD (`172.50.0.150`).

---

## 📋 Requisitos previos

| Componente | Versión mínima |
|---|---|
| **Visual Studio** | 2019 o 2022 (Community sirve) |
| **.NET Framework** | 4.x (el SDK que cada `.vbproj` requiera, normalmente lo instala VS) |
| **SQL Server Client** | Para conectar a `bdflexline` |
| **Crystal Reports for VS** | Si vas a usar funciones de reportes (ver más abajo) |
| Acceso a red interna | Para conectar a la BD `172.50.0.150` |

---

## 🏗️ Estructura del proyecto

```
UMBRIGHT-2026/
├── Umbright/                       ◄── Aplicación principal (ejecutable)
│   ├── Umbright.sln                ◄── Solución que abres en VS
│   ├── Umbright.vbproj             ◄── Proyecto principal
│   ├── frm_*.vb                    ◄── Formularios (Solicitud Productos, Pedidos, etc.)
│   ├── Mercadeo/                   ◄── Módulo Mercadeo (incluye Actualización Productos)
│   ├── Comercial/                  ◄── Módulo Comercial
│   ├── Finanzas/                   ◄── Módulo Finanzas
│   ├── RRHH/                       ◄── Módulo RRHH
│   ├── Logistica/                  ◄── Módulo Logística
│   ├── Compras/                    ◄── Módulo Compras
│   ├── Internaciones/              ◄── Módulo Internaciones
│   ├── Maquila/                    ◄── Módulo Maquila
│   ├── Presupuestos/               ◄── Módulo Presupuestos
│   ├── SCM/                        ◄── Submódulos SCM
│   ├── DA/                         ◄── Despacho
│   ├── SQL/                        ◄── Scripts SQL del módulo
│   ├── packages/                   ◄── NuGet packages (incluidos en repo)
│   ├── bin/Debug/                  ◄── Output compilado (Umbright.exe)
│   ├── App.config                  ◄── Conexiones a BD (host/usuario/pwd hex-encoded)
│   └── log4net.config              ◄── Configuración de logging
│
├── Clases4.0/                      ◄── Librerías compartidas (DLLs)
│   ├── Umbral_Flex/                ◄── Lógica Flexline
│   ├── Sincronizacion/             ◄── Sincronización con Flex
│   ├── ClasesGenerales/            ◄── Helpers comunes
│   ├── Transaccional/              ◄── Conexiones BD
│   ├── Seguridad/                  ◄── Login + permisos
│   ├── FlexLine_CRUD/              ◄── CRUD genérico Flex
│   ├── Servicios/                  ◄── Servicios varios
│   ├── Compras/                    ◄── Lib de compras (C#)
│   ├── Umbral.FelInfile_Creditos/  ◄── Integración FEL
│   ├── FTP/                        ◄── Cliente FTP
│   ├── Automatizar/                ◄── Procesos automáticos
│   ├── Terceros/                   ◄── Newtonsoft.Json y otros
│   └── Umbral_Flex/                ◄── Lógica core Flexline
│
├── Interfaz_CRM.Mail/              ◄── Cliente correo (C#)
├── Integraciones Tekne/            ◄── Integraciones externas
├── MigrationLogs/                  ◄── Logs de migración (histórico)
├── .gitignore                      ◄── (actualmente vacío — todo se trackea)
├── .gitattributes
├── README.md                       ◄── Este archivo
└── README_INDEPENDENCIA_V9.md      ◄── Notas históricas
```

---

## 🔧 Arquitectura — cómo se conectan las piezas

```
                       ┌────────────────────────────┐
                       │  Umbright.exe (Solución)   │
                       │  - Forms del usuario       │
                       │  - Lógica de negocio       │
                       └──────────────┬─────────────┘
                                      │ usa
                          ┌───────────┴────────────┐
                          ▼                        ▼
              ┌──────────────────┐     ┌──────────────────────┐
              │  Umbral_Flex.dll │◄───►│ Sincronizacion.dll   │
              │  (Flexline core) │     │ (Sync con Flexline)  │
              └────────┬─────────┘     └──────────┬───────────┘
                       │                          │
                       └──────┬───────────────────┘
                              ▼
                  ┌──────────────────────┐
                  │ Transaccional.dll    │  ◄── Conexiones a BD
                  │ ClasesGenerales.dll  │
                  │ Seguridad.dll        │
                  │ FlexLine_CRUD.dll    │
                  └──────────────────────┘

         ┌───────────────────────────────────────────┐
         ▼                                           ▼
    SQL Server                                  SMTP Office365
    172.50.0.150,bdflexline                     smtp.office365.com:587
    (Flexline + Corporativo + SCM)              (Notificaciones)
```

### Conexiones BD (definidas en App.config)
- **FlexLine** — base principal `bdflexline`
- **Corporativo** — solicitudes, log de cuentas
- **SCM** — credenciales y catálogos compartidos

---

## ⚙️ Cómo está organizada la solución (Umbright.sln)

> **Decisión arquitectural (junio 2026):** `Umbright.sln` contiene **solo el proyecto `Umbright`**.
> Las librerías de `Clases4.0/` se compilan automáticamente como dependencias del `.vbproj`,
> pero no aparecen como nodos editables en el Explorador de Soluciones.

### ¿Por qué?
Las librerías `Umbral_Flex` y `Sincronizacion` tienen **dependencia circular** entre sí
(cada una usa tipos definidas en la otra). Cuando ambas aparecían en `Umbright.sln`,
"Build Solution" fallaba con errores `BC2017` y `BC30002` en cualquier máquina nueva.

Con solo `Umbright` en la solución, MSBuild compila las dependencias siguiendo el orden
de los `.vbproj` y todo funciona transparente.

### Si necesitas editar código de una librería

Para tocar `.vb` dentro de `Clases4.0/Umbral_Flex/`, `Clases4.0/Sincronizacion/`, etc.:

1. Abre el `.sln` individual de esa librería:
   - `Clases4.0/Umbral_Flex/Umbral_Flex.sln`
   - `Clases4.0/Sincronizacion/Sincronizacion.sln`
   - `Clases4.0/ClasesGenerales/ClasesGenerales.sln`
   - Etc.
2. Modifica el código
3. **Build** → genera la `.dll` en `bin/Debug` de esa librería
4. Vuelve a `Umbright.sln` → F5 → corre con la `.dll` nueva (el `.vbproj` la referencia por path)

### Si quieres volver a tener todos los proyectos visibles en Umbright.sln
Restaura el backup:
```bash
cd Umbright
cp Umbright.sln.backup-multiproject Umbright.sln
```
Pero entonces tendrás que lidiar con los errores `BC2017` al hacer Build en clones nuevos.

---

## 🗄️ Base de datos

### Conexión (`Umbright/App.config`)

Las credenciales están **hex-encoded** en el `App.config` por seguridad básica.
Decodificándolas:

| Key | Valor |
|---|---|
| Server | `172.50.0.150` |
| Database | `bdflexline` |
| User | `flexinterface` |
| Password | `Interfaces.Flex` |

> ⚠️ El repo es **privado**. Aún así, considera no exponer este archivo en repos públicos.

### SPs y tablas clave usadas por el sistema

| SP / Tabla | Para qué |
|---|---|
| `flexline.inv_producto_solicitud` | Solicitudes de productos nuevos |
| `flexline.inv_producto_solicitud_packs` | Ingredientes de packs/recetas |
| `flexline.producto` | Productos finales en Flex |
| `flexline.prodReceta` | Recetas de productos compuestos |
| `flexline.gen_tabcod` | Catálogo general (incluye `IMP_DISTRIB`) |
| `flexline.umb_asignacion_cuentas_log` | Sugerencias de cuentas + log de procesos manuales |
| `pa_var_um_ProdReceta` | Validar unicidad de receta |
| `pa_ins_um_prodReceta` | Insertar línea de receta |
| `pa_ins_um_producto_interempresas` | Replicar producto DIUVA → VINOTECA |
| `pa_sel_um_producto` | Validar productos interempresa |
| `pa_sel_um_inv_producto_solicitud_listado` | Listado de solicitudes |

---

## 📦 Empresas configuradas

| Código | Nombre | Notas |
|---|---|---|
| **VINOTECA** | Vinoteca | Empresa principal de vinos |
| **DIUVA** | Distribuidora DIUVA | Replica a VINOTECA cuando aprueba `pplamport` |
| **DMARTE1** | Distribuidora Marte | No usa cuentas contables |
| **CODICASA** | Codicasa | Distribución general |
| **TECNO** | Tecno | Productos técnicos, cuentas hardcoded |
| **CABYSPA** | Cabysa | Productos varios |
| **DEMO, DIVINOS, LAINCONDI, MARDIVIN** | Empresas adicionales |

---

## ✨ Funcionalidades clave del módulo "Solicitud de Productos"

### Validaciones implementadas (al Guardar)
- Campos obligatorios: descripción, solicitante, familia, marca, origen, procedencia, proveedor, tipo de producto, unidad de medida, código de barras, lote, añada, unidades x caja, lista de precios, BU
- DMARTE1/CODICASA/DIUVA: además precio sugerido + medida (litros) ≥ 0.1
- Si proveedor es interempresa: valida código origen en `flexline.producto`

### Validaciones al Aprobar
- Consulta `flexline.gen_tabcod` con `tipo='IMP_DISTRIB'` para determinar si exige `tipo_proveedor`
- Si exige y elige INTERNACIONAL: además `medida_litros > 0` y `precio_sugerido > 0`
- Excepción: TECNO no valida

### Auto-procesamiento
- TECNO + DMARTE1: procesan directo
- Resto: verifica `umb_asignacion_cuentas_log` para cuentas sugeridas
- Si falla algo → queda manual + correo a `juan.jimenez@umbralcorp.com`

### Replicación DIUVA → VINOTECA
- Se ejecuta si: empresa = DIUVA + cod_flex asignado + aprobador = pplamport
- Ejecuta SP `pa_ins_um_producto_interempresas`
- Funciona en auto-proceso Y en proceso manual

### Generación automática de receta (productos compuestos)
- Formato: `R_<descripcion_con_underscores>_<n?>`
- Máximo 20 caracteres
- Numeración incremental si hay duplicados (2, 3, ..., 9, 10, ..., 100)
- Recorta descripción cuando el número crece
- Validación de unicidad por empresa

### Reglas por tipo de proveedor

| `tipo_proveedor` | Checkbox `IMP. DISTRIBUCION` |
|---|---|
| `INTERNACIONAL` | ✅ Marcado |
| `LOCAL` | ☐ Desmarcado |
| Vacío (no aplica) | ☐ Desmarcado |

---

## 🐛 Troubleshooting

### `BC2017: no se encontró la biblioteca 'Umbral_Flex.dll' / 'Sincronizacion.dll'`

**Causa:** Hiciste "Rebuild Solution" o tu carpeta `bin/Debug` quedó incompleta.

**Solución:**
1. Cierra Visual Studio
2. En la carpeta del proyecto, ejecuta:
   ```bash
   git checkout -- Clases4.0/Umbral_Flex/bin/Debug Clases4.0/Sincronizacion/bin/Debug
   ```
   (esto restaura las DLLs originales del repo)
3. Reabre `Umbright/Umbright.sln`
4. **Build solution** otra vez

### `BC30002: No está definido el tipo 'Sincronizacion.X' / 'Umbral_Flex.X'`
Mismo origen que el anterior. Mismo fix.

### "No se puede conectar a la base de datos"
- Verifica que estés en la red interna o VPN
- IP `172.50.0.150` debe ser alcanzable (ping desde cmd)

### Error al instalar Crystal Reports
El proyecto usa **CrystalDecisions** (Crystal Reports for Visual Studio). Si no lo tienes:
- Descarga e instala desde el sitio oficial de SAP Crystal Reports
- Sin esto, los reportes no compilan

### Errores de permisos al hacer git pull o push
- Asegúrate de estar autenticado en GitHub con la cuenta `juancajimenezv`
- Tu Personal Access Token debe tener scope `repo`

---

## 🔄 Flujo de trabajo recomendado

### Para agregar una feature nueva al módulo principal
1. `git pull origin master`
2. Modifica los archivos en `Umbright/`
3. Build → verifica que compile
4. F5 → prueba manualmente
5. `git add` + `git commit` + `git push`

### Para modificar una librería compartida (Clases4.0/X)
1. `git pull origin master`
2. Abre `Clases4.0/X/X.sln`
3. Modifica el código
4. Build → genera nueva DLL en `Clases4.0/X/bin/Debug/X.dll`
5. Verifica que las copias en `bin/Debug` de otros proyectos también se actualicen
   (los proyectos que usan X copian la DLL en su propio bin/Debug)
6. Reabre `Umbright/Umbright.sln` → Build → F5 → prueba
7. Commit incluyendo: el `.vb` modificado + las DLLs nuevas regeneradas
8. Push

---

## 📂 Archivos relevantes del módulo Solicitud de Productos

| Archivo | Función |
|---|---|
| [`Umbright/frm_solicitud_productos.vb`](Umbright/frm_solicitud_productos.vb) | Formulario principal de solicitud |
| [`Umbright/frm_procesar_productos.vb`](Umbright/frm_procesar_productos.vb) | Procesar producto → INSERT en flexline.producto |
| [`Umbright/Mercadeo/PermisosActProductos.vb`](Umbright/Mercadeo/PermisosActProductos.vb) | Permisos para actualización de productos |
| [`Umbright/Mercadeo/frm_actualizacionProductosIE.vb`](Umbright/Mercadeo/frm_actualizacionProductosIE.vb) | Actualización individual |
| [`Umbright/Mercadeo/frm_actualizacionProductosMasivaIE.vb`](Umbright/Mercadeo/frm_actualizacionProductosMasivaIE.vb) | Actualización masiva interempresas |
| [`Umbright/SQL/pa_ins_um_producto_interempresas_v2.sql`](Umbright/SQL/pa_ins_um_producto_interempresas_v2.sql) | SP replicación |
| [`Umbright/SQL/umb_asignacion_cuentas_estado6.sql`](Umbright/SQL/umb_asignacion_cuentas_estado6.sql) | Script log de cuentas |

---

## 📞 Contactos

- **Owner del repo:** juancajimenezv
- **Dev principal:** Juan Carlos Jimenez (juan.jimenez@umbralcorp.com)
- **Operación de procesos manuales:** Juan (correos automáticos llegan a `juan.jimenez@umbralcorp.com`)

---

## 📜 Historia y cambios relevantes

Ver [README_INDEPENDENCIA_V9.md](README_INDEPENDENCIA_V9.md) para notas históricas del proyecto.

### Junio 2026
- ✏️ Validación `tipo_proveedor` ahora por `flexline.gen_tabcod` (reemplaza lista hardcoded de 10 familias)
- 🆕 Generación automática de nombre de receta para productos compuestos en auto-proceso
- ✏️ Tipo de proveedor queda vacío en BD si no aplica (no se fuerza `LOCAL`)
- 🐛 Fix `PermisosActProductos` case-insensitive (campo BU ya aparece en actualización masiva)
- 🎨 Reposicionamiento UI: `cmb_tipo_proveedor` y `cmbCEPA`
- 🔧 Restauración encoding Windows-1252 (115 caracteres acentuados)
- 🏗️ `Umbright.sln` reducido a solo el proyecto Umbright (resuelve errores `BC2017` en clones nuevos)
