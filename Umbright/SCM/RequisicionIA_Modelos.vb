Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic

''' <summary>
''' Distribución porcentual de una dimensión de línea (Centro de Costo, Marca, Canal o Gasto).
''' Espejo de las columnas usadas en oDS.Tables("centro_costo"/"marca"/"gasto"/"canal") en frmRequisiciones.vb.
''' </summary>
Public Class RequisicionDimensionDraft
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Porcentaje As Double

    ''' <summary>Solo aplica a Marca.</summary>
    Public Property PorcentajeEmpresa As Double?

    ''' <summary>Solo aplica a Marca (el "socio" comercial).</summary>
    Public Property PorcentajeSocio As Double?

    ''' <summary>Unidad de negocio, solo aplica a Marca.</summary>
    Public Property Bu As String

    ''' <summary>Solo aplica a Gasto: "CON_ITEM" o "CON_A&amp;P".</summary>
    Public Property Tipo As String
End Class

''' <summary>
''' Una línea de detalle de requisición (producto). NO lleva distribución propia:
''' en el sistema real (frmRequisiciones.vb:2411-2472), Centro de Costo/Marca/Canal/Gasto
''' se captura UNA sola vez con la primera línea y se reutiliza automáticamente para las
''' demás (`dsLocal = oDS.Copy`, sin volver a preguntar) — por eso esa distribución vive en
''' RequisicionCabeceraDraft, no aquí.
''' </summary>
Public Class RequisicionLineaDraft
    Public Property Linea As Integer
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Cantidad As Double
    Public Property Precio As Double
    Public Property Observaciones As String
End Class

''' <summary>
''' Cabecera completa de una requisición propuesta por el modelo de IA, antes de guardarse.
''' Espejo de los campos de cabecera capturados en frmRequisiciones.vb (proveedor, fecha entrega, etc),
''' MÁS la distribución de Centro de Costo/Marca/Canal/Gasto — que en el sistema real se define
''' una sola vez por requisición y se replica a todas sus líneas al guardar
''' (frmRequisiciones.vb:600-649: el guardado siempre filtra por `linea = min(linea)`,
''' es decir, todas las líneas comparten la distribución de la primera).
''' </summary>
Public Class RequisicionCabeceraDraft
    Public Property Proveedor As String
    Public Property NombreProveedor As String
    Public Property FechaEntrega As Date
    Public Property LugarEntrega As String
    Public Property Observaciones As String

    ''' <summary>Empresa que el usuario mencionó explícitamente en el chat (ej. "EMPRESA: MARTE"),
    ''' si la mencionó. Solo se usa para VALIDAR que coincide con la empresa de la sesión activa
    ''' — nunca cambia la empresa bajo la que se guarda la requisición.</summary>
    Public Property EmpresaMencionada As String

    ''' <summary>"QUETZALES" o "DOLARES" — únicas monedas permitidas, obligatoria.</summary>
    Public Property Moneda As String

    Public Property Cadena As String
    Public Property Anticipo As String ' "SI" / "NO"
    Public Property MontoAnticipo As Double
    Public Property AfectaInventario As String ' "S" / "N"

    ''' <summary>"CON_ITEM" o "CON_A&amp;P" — una sola vez por requisición (igual que rbItem/rbAyP en frmRequisiconesDetalle).</summary>
    Public Property TipoGasto As String

    Public Property CentrosCosto As New List(Of RequisicionDimensionDraft)
    Public Property Marcas As New List(Of RequisicionDimensionDraft)
    Public Property Canales As New List(Of RequisicionDimensionDraft)
    Public Property Gastos As New List(Of RequisicionDimensionDraft)

    Public Property Lineas As New List(Of RequisicionLineaDraft)
End Class

Public Enum EstadoBorradorRequisicion
    Valido
    ConErrores
    PendienteAclaracion
End Enum

''' <summary>
''' Envoltorio de una requisición dentro del lote que gestiona el chat: agrega estado
''' de validación y las preguntas de aclaración pendientes al borrador puro.
''' </summary>
Public Class RequisicionBatchItem
    Public Property Id As String
    Public Property Cabecera As RequisicionCabeceraDraft
    Public Property Estado As EstadoBorradorRequisicion = EstadoBorradorRequisicion.ConErrores
    Public Property Errores As New List(Of String)
    Public Property PreguntasAclaracion As New List(Of String)

    ''' <summary>Número de requisición ya asignado, una vez guardada exitosamente.</summary>
    Public Property NumeroRequisicionGuardada As String
End Class

''' <summary>
''' Transaccional.Conexion (ensamblado externo, sin fuente en este repo) ejecuta el SQL que se
''' le pasa como string tal cual, sin overload parametrizado conocido. Como en este módulo el
''' texto libre puede venir de una corrección de chat en lenguaje natural, TODO valor de texto
''' debe pasar por EscaparSql antes de concatenarse en un EXEC.
''' </summary>
Public Module RequisicionSqlUtil
    Public Function EscaparSql(valor As String) As String
        If valor Is Nothing Then Return ""
        Return valor.Replace("'", "''")
    End Function
End Module
