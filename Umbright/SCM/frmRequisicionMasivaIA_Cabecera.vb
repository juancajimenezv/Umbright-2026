Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' Edición manual de UNA requisición del borrador de IA: cabecera (proveedor, fecha
''' entrega, moneda, cadena, anticipo, afecta inventario) + grid de líneas, con
''' Agregar/Editar/Eliminar línea vía `frmRequisicionMasivaIA_Linea`. Se abre desde
''' doble clic en `dgvBorrador` de `frmRequisicionesMasivasIA`.
''' Trabaja sobre una COPIA del draft (clon JSON) — "Cancelar" no deja cambios a medias;
''' "Guardar" devuelve el draft editado y deja que el llamador corra la validación fina
''' (RequisicionChatOrchestrator.RevalidarItem) contra reglas de negocio y catálogos.
''' </summary>
Public Class frmRequisicionMasivaIA_Cabecera

    ''' <summary>Cabecera resultante tras Guardar. Nothing si se canceló.</summary>
    Public CabeceraResultado As RequisicionCabeceraDraft

    Private ReadOnly _cabecera As RequisicionCabeceraDraft
    Private ReadOnly _catalogo As New RequisicionCatalogContext(gs_empresa)

    Public Sub New(cabeceraOriginal As RequisicionCabeceraDraft)
        InitializeComponent()
        _cabecera = ClonarCabecera(cabeceraOriginal)
    End Sub

    Private Function ClonarCabecera(cab As RequisicionCabeceraDraft) As RequisicionCabeceraDraft
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of RequisicionCabeceraDraft)(Newtonsoft.Json.JsonConvert.SerializeObject(cab))
    End Function

    Private Sub frmRequisicionMasivaIA_Cabecera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarEstilos()
        LlenarCombos()
        CargarCamposDesdeCabecera()
        RefrescarGridLineas()
    End Sub

    Private Sub AplicarEstilos()
        Me.BackColor = RequisicionIA_Estilos.ColorFondo
        Me.Controls.Add(RequisicionIA_Estilos.CrearHeader("Editar Requisición"))

        pnlCabecera.BackColor = RequisicionIA_Estilos.ColorFondo
        For Each lbl As Label In {lblProveedor, lblMoneda, lblLugarEntrega, lblFechaEntrega,
                                   lblAfectaInventario, lblMontoAnticipo, lblAnticipo, lblCadena, lblObservaciones}
            lbl.ForeColor = RequisicionIA_Estilos.ColorTextoMuted
            lbl.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 7.5F, FontStyle.Bold)
        Next

        RequisicionIA_Estilos.EstilizarBotonSecundario(btnBuscarProveedor)
        RequisicionIA_Estilos.EstilizarBotonSecundario(btnAgregarLinea)
        RequisicionIA_Estilos.EstilizarBotonSecundario(btnEditarLinea)
        RequisicionIA_Estilos.EstilizarBotonSecundario(btnDistribucion)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnEliminarLinea)
        RequisicionIA_Estilos.EstilizarBotonPrimario(btnGuardar)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnCancelar)
        RequisicionIA_Estilos.EstilizarGrid(dgvLineas)
    End Sub

    Private Sub LlenarCombos()
        ' Moneda restringida a QUETZALES/DOLARES (pedido explícito del usuario) — a diferencia
        ' del formulario original que carga TODO el catálogo GEN_MONEDA, aquí solo se permiten
        ' estas dos, igual que las literales que ya usa frmRequisiciones.vb ("QUETZALES"/"DOLARES").
        cmbMoneda.Items.Clear()
        cmbMoneda.Items.AddRange(New Object() {"QUETZALES", "DOLARES"})

        cmbCadena.Items.Clear()
        cmbCadena.Items.AddRange(New Object() {"SI", "NO"})
        cmbAnticipo.Items.Clear()
        cmbAnticipo.Items.AddRange(New Object() {"SI", "NO", "TC", "FA"})
        cmbAfectaInventario.Items.Clear()
        cmbAfectaInventario.Items.AddRange(New Object() {"S", "N"})
    End Sub

    Private Sub CargarCamposDesdeCabecera()
        txtProveedor.Text = _cabecera.Proveedor
        lblNombreProveedor.Text = _cabecera.NombreProveedor
        If _cabecera.FechaEntrega > Date.MinValue Then dtpFechaEntrega.Value = _cabecera.FechaEntrega
        txtLugarEntrega.Text = _cabecera.LugarEntrega
        txtObservaciones.Text = _cabecera.Observaciones
        If Not String.IsNullOrWhiteSpace(_cabecera.Moneda) Then
            cmbMoneda.SelectedItem = _cabecera.Moneda.ToUpper
        End If
        cmbCadena.SelectedItem = If(String.IsNullOrWhiteSpace(_cabecera.Cadena), "NO", _cabecera.Cadena.ToUpper)
        cmbAnticipo.SelectedItem = If(String.IsNullOrWhiteSpace(_cabecera.Anticipo), "NO", _cabecera.Anticipo.ToUpper)
        txtMontoAnticipo.Text = _cabecera.MontoAnticipo.ToString(Globalization.CultureInfo.InvariantCulture)
        cmbAfectaInventario.SelectedItem = If(String.IsNullOrWhiteSpace(_cabecera.AfectaInventario), "N", _cabecera.AfectaInventario.ToUpper)
    End Sub

    Private Sub GuardarCamposEnCabecera()
        _cabecera.Proveedor = txtProveedor.Text.Trim
        _cabecera.NombreProveedor = lblNombreProveedor.Text
        _cabecera.FechaEntrega = dtpFechaEntrega.Value
        _cabecera.LugarEntrega = txtLugarEntrega.Text.Trim
        _cabecera.Observaciones = txtObservaciones.Text.Trim
        _cabecera.Moneda = If(cmbMoneda.SelectedItem, "").ToString
        _cabecera.Cadena = If(cmbCadena.SelectedItem, "").ToString
        _cabecera.Anticipo = If(cmbAnticipo.SelectedItem, "").ToString
        Dim monto As Double
        Double.TryParse(txtMontoAnticipo.Text, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, monto)
        _cabecera.MontoAnticipo = monto
        _cabecera.AfectaInventario = If(cmbAfectaInventario.SelectedItem, "").ToString
    End Sub

    ' ------------------------------------------------------------------
    ' Proveedor
    ' ------------------------------------------------------------------

    ''' <summary>Valida el código apenas el usuario sale del campo, sin esperar a "Guardar" — así
    ''' un código escrito a mano (no elegido con "Buscar") también queda marcado de inmediato.</summary>
    Private Sub txtProveedor_Leave(sender As Object, e As EventArgs) Handles txtProveedor.Leave
        Dim codigo As String = txtProveedor.Text.Trim
        If codigo.Length = 0 Then
            lblNombreProveedor.Text = ""
            Return
        End If

        Dim chk = _catalogo.ValidarProveedor(codigo)
        If chk.Existe Then
            lblNombreProveedor.ForeColor = Color.DimGray
            lblNombreProveedor.Text = chk.Nombre
        Else
            lblNombreProveedor.ForeColor = Color.Red
            lblNombreProveedor.Text = "(no existe) — use ""Buscar"" para encontrar el código correcto"
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frm_busqueda_general
        frm.parametros_fijos = "empresa = '" & gs_empresa & "' and "
        frm.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm.nombre_vista = "v_um_ctacte_proveedor_busqueda"
        frm.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente"
        frm.btn_seleccion_multipe.Visible = False
        frm.ShowDialog(Me)
        Dim codigo As String = frm.resultado
        frm.Dispose()

        If String.IsNullOrEmpty(codigo) Then Return
        txtProveedor.Text = codigo
        Dim chk = _catalogo.ValidarProveedor(codigo)
        lblNombreProveedor.Text = If(chk.Existe, chk.Nombre, "(no encontrado)")
    End Sub

    ' ------------------------------------------------------------------
    ' Líneas
    ' ------------------------------------------------------------------

    Private Sub RefrescarGridLineas()
        Dim dt As New DataTable()
        dt.Columns.Add("Línea", GetType(Integer))
        dt.Columns.Add("Código", GetType(String))
        dt.Columns.Add("Descripción", GetType(String))
        dt.Columns.Add("Cantidad", GetType(Double))
        dt.Columns.Add("Precio", GetType(Double))
        dt.Columns.Add("Total", GetType(Double))

        For Each linea In _cabecera.Lineas
            dt.Rows.Add(linea.Linea, linea.Codigo, linea.Descripcion, linea.Cantidad, linea.Precio, linea.Cantidad * linea.Precio)
        Next

        dgvLineas.DataSource = dt
    End Sub

    ' ------------------------------------------------------------------
    ' Distribución (Centro de Costo / Marca / Canal / Gasto) — una sola vez por requisición
    ' ------------------------------------------------------------------

    Private Sub btnDistribucion_Click(sender As Object, e As EventArgs) Handles btnDistribucion.Click
        Dim frm As New frmRequisicionMasivaIA_Distribucion(_cabecera)
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    Private Sub btnAgregarLinea_Click(sender As Object, e As EventArgs) Handles btnAgregarLinea.Click
        Dim frm As New frmRequisicionMasivaIA_Linea()
        If frm.ShowDialog(Me) = DialogResult.OK Then
            Dim nuevaLinea = frm.LineaResultado
            nuevaLinea.Linea = If(_cabecera.Lineas.Count = 0, 1, _cabecera.Lineas.Max(Function(l) l.Linea) + 1)
            _cabecera.Lineas.Add(nuevaLinea)
            RefrescarGridLineas()
        End If
        frm.Dispose()
    End Sub

    Private Sub btnEditarLinea_Click(sender As Object, e As EventArgs) Handles btnEditarLinea.Click
        EditarLineaSeleccionada()
    End Sub

    Private Sub dgvLineas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLineas.CellDoubleClick
        If e.RowIndex >= 0 Then EditarLineaSeleccionada()
    End Sub

    Private Sub EditarLineaSeleccionada()
        If dgvLineas.CurrentRow Is Nothing Then Return
        Dim indice As Integer = dgvLineas.CurrentRow.Index
        If indice < 0 OrElse indice >= _cabecera.Lineas.Count Then Return

        Dim lineaActual = _cabecera.Lineas(indice)
        Dim frm As New frmRequisicionMasivaIA_Linea(lineaActual)
        If frm.ShowDialog(Me) = DialogResult.OK Then
            _cabecera.Lineas(indice) = frm.LineaResultado
            RefrescarGridLineas()
        End If
        frm.Dispose()
    End Sub

    Private Sub btnEliminarLinea_Click(sender As Object, e As EventArgs) Handles btnEliminarLinea.Click
        If dgvLineas.CurrentRow Is Nothing Then Return
        Dim indice As Integer = dgvLineas.CurrentRow.Index
        If indice < 0 OrElse indice >= _cabecera.Lineas.Count Then Return

        If MessageBox.Show("¿Eliminar esta línea?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _cabecera.Lineas.RemoveAt(indice)
            RefrescarGridLineas()
        End If
    End Sub

    ' ------------------------------------------------------------------
    ' Guardar / Cancelar
    ' ------------------------------------------------------------------

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarCamposEnCabecera()
        CabeceraResultado = _cabecera
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
