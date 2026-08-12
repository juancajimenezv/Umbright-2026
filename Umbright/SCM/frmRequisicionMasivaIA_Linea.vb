Option Strict Off
Option Explicit On
Option Infer On

''' <summary>
''' Alta/edición de UNA línea de requisición del borrador de IA: solo datos de producto
''' (código, descripción, cantidad, precio, observaciones). La distribución de Centro de
''' Costo/Marca/Canal/Gasto NO va aquí — se captura una sola vez por requisición desde
''' "Distribución" en frmRequisicionMasivaIA_Cabecera, igual que en el sistema real
''' (frmRequisiciones.vb:2411-2472 reutiliza la distribución de la primera línea para las
''' demás, sin volver a preguntar).
''' </summary>
Public Class frmRequisicionMasivaIA_Linea

    ''' <summary>Línea resultante tras Aceptar. Nothing si se canceló.</summary>
    Public LineaResultado As RequisicionLineaDraft

    Private ReadOnly _lineaOriginal As RequisicionLineaDraft
    Private ReadOnly _catalogo As New RequisicionCatalogContext(gs_empresa)

    Public Sub New(Optional lineaExistente As RequisicionLineaDraft = Nothing)
        InitializeComponent()
        _lineaOriginal = lineaExistente
    End Sub

    Private Sub frmRequisicionMasivaIA_Linea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarEstilos()

        If _lineaOriginal IsNot Nothing Then
            txtCodigoProducto.Text = _lineaOriginal.Codigo
            txtDescripcionProducto.Text = _lineaOriginal.Descripcion
            txtCantidad.Text = _lineaOriginal.Cantidad.ToString(Globalization.CultureInfo.InvariantCulture)
            txtPrecio.Text = _lineaOriginal.Precio.ToString(Globalization.CultureInfo.InvariantCulture)
            txtObservaciones.Text = _lineaOriginal.Observaciones
        End If
    End Sub

    Private Sub AplicarEstilos()
        Me.BackColor = RequisicionIA_Estilos.ColorFondo
        For Each lbl As Label In {Label1, Label2, Label3, Label4, Label5}
            lbl.ForeColor = RequisicionIA_Estilos.ColorTextoMuted
            lbl.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 7.5F, FontStyle.Bold)
        Next
        RequisicionIA_Estilos.EstilizarBotonSecundario(btnBuscarProducto)
        RequisicionIA_Estilos.EstilizarBotonPrimario(btnAceptar)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnCancelar)
    End Sub

    ''' <summary>Abre el mismo buscador de producto que usa frmRequisiciones.vb:btnBuscarProducto_Click
    ''' (líneas 2701-2704): vista `scm.flexline.producto`, empresa fija 'LOGISERV'.</summary>
    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        Dim frm As New frm_busqueda_general
        frm.parametros_fijos = " empresa = 'LOGISERV' and "
        frm.parametros = "glosa,producto,tipoproducto"
        frm.nombre_vista = "scm.flexline.producto"
        frm.lista_campos = "producto,glosa,tipoproducto"
        frm.btn_seleccion_multipe.Visible = False
        frm.ShowDialog(Me)
        Dim codigo As String = frm.resultado
        frm.Dispose()

        If String.IsNullOrEmpty(codigo) Then Return
        txtCodigoProducto.Text = codigo
        ValidarCodigoProducto()
    End Sub

    ''' <summary>Igual que el proveedor en la cabecera: valida apenas se sale del campo,
    ''' así un código de producto escrito a mano queda marcado "(no existe)" de inmediato
    ''' y trae la descripción real si sí existe.</summary>
    Private Sub txtCodigoProducto_Leave(sender As Object, e As EventArgs) Handles txtCodigoProducto.Leave
        ValidarCodigoProducto()
    End Sub

    ''' <summary>Devuelve True si el código actual existe (y ya dejó la descripción cargada);
    ''' False si está vacío o no existe (y ya lo marcó "(no existe)").</summary>
    Private Function ValidarCodigoProducto() As Boolean
        Dim codigo As String = txtCodigoProducto.Text.Trim
        If codigo.Length = 0 Then Return False

        Dim descripcion As String = _catalogo.ObtenerDescripcionProducto(codigo)
        If descripcion IsNot Nothing Then
            txtDescripcionProducto.ForeColor = SystemColors.WindowText
            txtDescripcionProducto.Text = descripcion
            Return True
        Else
            txtDescripcionProducto.ForeColor = Color.Red
            txtDescripcionProducto.Text = "(no existe)"
            Return False
        End If
    End Function

    Private Function ValorDoubleSeguro(valor As Object) As Double
        If valor Is Nothing OrElse valor Is DBNull.Value Then Return 0
        Dim resultado As Double
        Double.TryParse(valor.ToString, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, resultado)
        Return resultado
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If String.IsNullOrWhiteSpace(txtCodigoProducto.Text) Then
            MessageBox.Show("Debe indicar el código de producto.", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidarCodigoProducto() Then
            MessageBox.Show($"El producto '{txtCodigoProducto.Text.Trim}' no existe. Use el botón ""..."" para buscarlo o corrija el código.", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cantidad As Double = ValorDoubleSeguro(txtCantidad.Text)
        Dim precio As Double = ValorDoubleSeguro(txtPrecio.Text)
        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a 0.", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LineaResultado = New RequisicionLineaDraft With {
            .Linea = If(_lineaOriginal IsNot Nothing, _lineaOriginal.Linea, 0),
            .Codigo = txtCodigoProducto.Text.Trim,
            .Descripcion = txtDescripcionProducto.Text.Trim,
            .Cantidad = cantidad,
            .Precio = precio,
            .Observaciones = txtObservaciones.Text.Trim
        }

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
