# Umbright Version 9 — Copia Independiente

Generada el 2026-05-18 a partir de `C:\Desarrollo\Version 8\Umbright`.

## Objetivo cumplido

Esta versión opera de forma **autónoma**: ninguna ruta dentro de `Umbright.vbproj`,
los proyectos referenciados o sus sub-dependencias apunta fuera de
`C:\Desarrollo\Version 9` (salvo ensamblados del sistema Windows / .NET / SQL Server SDK).

Para abrir: `C:\Desarrollo\Version 9\Umbright\Umbright.sln` en Visual Studio.

## Estructura

```
Version 9\
├── Umbright\                                 (proyecto principal — 467.6 MB)
│   ├── Umbright.sln                          (referencia a proyectos vía ..\Clases4.0\...)
│   ├── Umbright.vbproj
│   ├── packages\                             (NuGet: EntityFramework 6.3, log4net, GemBox, SQLite, etc.)
│   └── ...
├── Clases4.0\                                (proyectos referenciados por la solución)
│   ├── Automatizar\                          (HintPath transitivo)
│   ├── ClasesGenerales\                      (HintPath transitivo)
│   ├── Compras\                              (ProjectReference desde Umbright)
│   ├── FlexLine_CRUD\                        (ProjectReference desde Umbright)
│   ├── FTP\                                  (HintPath transitivo)
│   ├── Seguridad\                            (ProjectReference desde Umbright)
│   ├── Servicios\                            (Umbral_Servicios — HintPath desde Umbright)
│   ├── Sincronizacion\                       (ProjectReference desde Umbright)
│   ├── Terceros\                             (DLLs binarias: prtcom, Excel, ZedGraph, OpenNetCF, etc.)
│   ├── Transaccional\                        (HintPath transitivo)
│   ├── Umbral.FelInfile_Creditos\            (ProjectReference desde Umbright)
│   ├── Umbral_Flex\                          (ProjectReference desde Umbright)
│   └── conectorNET.dll                       (referenciada por Umbral.FelInFile.csproj)
├── Integraciones Tekne\                      (provee Sincronizacion.dll a Umbral_Flex)
├── Interfaz_CRM.Mail\                        (con packages\EntityFramework.6.2.0\ local)
└── _copy_logs\                               (logs de robocopy de la migración)
```

Total: **1.125,6 MB · 5.401 archivos**.

## Cambios aplicados para romper dependencias externas

### A. Solución y proyectos (.sln / .vbproj / .csproj)

| Archivo | Antes (fuera de V9) | Después (dentro de V9) |
|---|---|---|
| `Umbright\Umbright.vbproj` | `D:\Desarrollo\Aplicaciones Umbral\2008\Clases3.0\Terceros\OpenNetCF\OpenNETCF.Desktop.Communication.dll` | `..\Clases4.0\Terceros\OpenNetCF\OpenNETCF.Desktop.Communication.dll` |
| `Umbright\Umbright.vbproj` | `..\..\Net\onBase\bin\CrystalKeyCodeLib.dll` | `..\Clases4.0\Terceros\CrystalKeyCodeLib.dll` |
| `Clases4.0\Sincronizacion\Sincronizacion.vbproj` | `..\..\..\Version 4\Clases4.0\FTP\bin\FTP.dll` | `..\FTP\bin\FTP.dll` |
| `Clases4.0\Compras\Compras.csproj` | `..\..\..\Clases4.0\ClasesGenerales\bin\Debug\ClasesGenerales.dll` | `..\ClasesGenerales\bin\Debug\ClasesGenerales.dll` |
| `Clases4.0\Compras\Compras.csproj` | `..\..\..\Clases4.0\Transaccional\bin\Debug\Transaccional.dll` | `..\Transaccional\bin\Debug\Transaccional.dll` |
| `Clases4.0\Umbral.FelInfile_Creditos\Umbral.FelInFile.csproj` | `..\..\..\Clases4.0\Automatizar\bin\Debug\Automatizar.dll` | `..\Automatizar\bin\Debug\Automatizar.dll` |
| `Clases4.0\ClasesGenerales\ClasesGenerales.vbproj` | `..\..\..\Clases4.0\FTP\bin\FTP.dll` | `..\FTP\bin\FTP.dll` |
| `Clases4.0\ClasesGenerales\ClasesGenerales.vbproj` | `..\..\..\Clases4.0\ClasesGenerales\bin\Debug\Interop.prtcom.dll` | `..\Terceros\Interop.prtcom.dll` |
| `Clases4.0\Seguridad\Seguridad.vbproj` | `..\..\..\Clases4.0\Transaccional\bin\Debug\Transaccional.dll` | `..\Transaccional\bin\Debug\Transaccional.dll` |
| `Interfaz_CRM.Mail\Interfaz_CRM.Mail.csproj` | `..\Obtener Informacion\packages\EntityFramework.6.2.0\lib\net40\EntityFramework.dll` | `packages\EntityFramework.6.2.0\lib\net40\EntityFramework.dll` |
| `Interfaz_CRM.Mail\Interfaz_CRM.Mail.csproj` | `..\Obtener Informacion\packages\EntityFramework.6.2.0\lib\net40\EntityFramework.SqlServer.dll` | `packages\EntityFramework.6.2.0\lib\net40\EntityFramework.SqlServer.dll` |
| `Umbright\bin\Release\Umbright.sln` | `Executable = C:\Desarrollo\Aplicaciones\Version 8\Umbright\bin\Release\Umbright.exe` | `Executable = C:\Desarrollo\Version 9\Umbright\bin\Release\Umbright.exe` |
| `Interfaz_CRM.Mail\Mdl\mdlSCM.Designer.cs` (comentario T4) | `C:\Desarrollo\Version 8\Interfaz_CRM.Mail\Mdl\mdlSCM.edmx` | `C:\Desarrollo\Version 9\Interfaz_CRM.Mail\Mdl\mdlSCM.edmx` |

### B. Archivos binarios copiados explícitamente

| Archivo | Origen | Destino dentro de V9 |
|---|---|---|
| `EntityFramework.6.2.0` (paquete completo) | `C:\Desarrollo\cloud\otros\UmbralSvc\packages\EntityFramework.6.2.0` | `Interfaz_CRM.Mail\packages\EntityFramework.6.2.0` |
| `CrystalKeyCodeLib.dll` | `C:\Desarrollo\Version 8\Sam\bin\Debug\CrystalKeyCodeLib.dll` | `Clases4.0\Terceros\CrystalKeyCodeLib.dll` |
| `conectorNET.dll` | `C:\Desarrollo\Version 8\Clases4.0\ClasesGenerales\bin\Debug\conectorNET.dll` | `Clases4.0\conectorNET.dll` |

### C. Carpetas copiadas (que la solución/proyectos referencian)

| Carpeta | Tamaño | Por qué se incluyó |
|---|---|---|
| `Umbright` | 467,6 MB | Proyecto principal |
| `Clases4.0\Compras` | 5,0 MB | ProjectReference desde Umbright (.sln) |
| `Clases4.0\Sincronizacion` | 69,4 MB | ProjectReference desde Umbright (.sln) |
| `Clases4.0\Umbral_Flex` | 37,3 MB | ProjectReference desde Umbright (.sln) |
| `Clases4.0\Umbral.FelInfile_Creditos` | 57,3 MB | ProjectReference (Umbral.FelInFile.csproj) |
| `Clases4.0\FlexLine_CRUD` | 13,1 MB | ProjectReference desde Umbright (.sln) |
| `Clases4.0\Servicios` | 14,2 MB | Provee `Umbral_Servicios.dll` |
| `Clases4.0\Seguridad` | 3,3 MB | ProjectReference desde Umbright (.sln) |
| `Interfaz_CRM.Mail` | 15,9 MB | ProjectReference desde Sincronizacion |
| `Clases4.0\Automatizar` | 26,4 MB | HintPath transitivo (Umbright, Umbral_Flex, Servicios, Umbral.FelInFile) |
| `Clases4.0\ClasesGenerales` | 139,9 MB | HintPath transitivo (toda la cadena) |
| `Clases4.0\FTP` | 0,2 MB | HintPath transitivo (Umbright, Umbral_Flex, Sincronizacion, ClasesGenerales) |
| `Clases4.0\Terceros` | 41,9 MB | DLLs binarias (prtcom, Excel, ZedGraph, OpenNetCF, etc.) |
| `Clases4.0\Transaccional` | 34,8 MB | HintPath transitivo (toda la cadena) |
| `Integraciones Tekne` | 176,7 MB | Provee `Sincronizacion.dll` referenciada por Umbral_Flex |

## Dependencias que NO pudieron desacoplarse automáticamente

Estas son dependencias del **sistema operativo / runtimes instalados**. Son externas
al concepto de "versión de Umbright" y deben existir en cualquier máquina donde se
compile o ejecute la aplicación. **No representan acoplamiento entre versiones.**

| Dependencia | Ubicación esperada | Notas |
|---|---|---|
| `System.Web.Services.dll` v2.0 (GAC) | `C:\WINDOWS\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__...` | Referenciada por `Automatizar.vbproj`. Del .NET Framework instalado. |
| `Microsoft.SQLServer.ManagedDTS.dll` | `C:\Program Files (x86)\Microsoft SQL Server\110\SDK\Assemblies\` | Referenciada por `Umbright.vbproj`. Requiere SQL Server 2012 (110) Client SDK. |
| `System.Drawing.dll` / `System.Windows.Forms.dll` v1.1 | `C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\` | Referenciadas por `Clases4.0\FTP\FTP.vbproj`. Requiere .NET Framework 1.1 instalado. |

### Cómo cubrir estas dependencias

- **SQL Server Client SDK 2012 (versión 110)**: instalar el "SQL Server 2012 Feature Pack" o "Microsoft SQL Server 2012 Native Client" para que aparezca el folder `110\SDK\Assemblies`.
- **.NET Framework 1.1**: el proyecto `FTP` apunta a v1.1 — si MSBuild no la encuentra, en la práctica Visual Studio resuelve esos asemblados desde el GAC actual al compilar. Si falla, instalar el redistribuible NDP1.1sp1-KB867460-X86.exe.
- **GAC_MSIL/System.Web.Services**: viene con el .NET Framework. Cualquier instalación de .NET 4.x lo cubre.

## Recursos referenciados en código (no en proyectos)

`App.config` de Umbright apunta a estos paths absolutos, que son **datos de runtime**,
no dependencias de compilación:

```xml
<setting name="DirFel">                <value>C:\Aplicaciones\Fel\</value>
<setting name="FormularioEntregaWM">   <value>C:\Aplicaciones\FORMULARIO DE ENTREGA ORIGINAL.xls</value>
```

Estos folders / archivos deben existir en la máquina cliente cuando la app se ejecute.
No bloquean compilación, pero pueden requerir ajuste en producción.

## Carpetas excluidas intencionalmente

Las siguientes existían en `Version 8` pero **no** están referenciadas por
ningún proyecto/HintPath activo y, por tanto, no se copiaron:

- `Backup/`, `Sam/`, `Sam2707/`, `SamMovile/`, `Umbright POS*`, `EnvioCorreos*`,
  `InFileFEL_*`, `EvaluacionesRH*`, `Procesos Memos`, `MAGAYA`, `Edifact`,
  `MonitorImpresiones`, `aprobacionControlTransporte`, etc.

Si descubres en build que falta alguna, ese sub-proyecto puede agregarse copiando
la carpeta correspondiente desde `Version 8`.

## Verificación realizada

Script automatizado escaneó los 14 `.vbproj` / `.csproj` activos (excluyendo Backup
y Newtonsoft.Json tests de Terceros):

- ✅ **0** paths resolviendo fuera de `Version 9` (después de fixes).
- ✅ **0** archivos estáticos faltantes (después de copiar conectorNET / EntityFramework.6.2.0 / CrystalKeyCodeLib).
- ⚠️ Los `obj\*\FileListAbsolute.txt` aún contienen rutas antiguas a `Version 8`,
  pero MSBuild los **regenera al primer build**: son cache, no se cargan.

## Siguiente paso (a cargo del usuario)

1. Abrir `C:\Desarrollo\Version 9\Umbright\Umbright.sln` en Visual Studio.
2. **Build Solution** (Ctrl+Shift+B) en Debug o Release.
3. Si compila, la independencia está confirmada. Si algún proyecto falla, revisar el
   error específico y comparar contra `Version 8` (la copia original quedó intacta).
