Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' Captura la distribución de Centro de Costo / Marca / Canal / Item de Gasto (+ITEM/A&amp;P)
''' de una requisición completa — UNA sola vez, aplicada luego a todas sus líneas de producto
''' (RequisicionPersistenceService.GuardarRequisicion), igual que en el sistema real
''' (frmRequisiciones.vb:2411-2472 reutiliza la distribución de la primera línea para las
''' demás sin volver a preguntar). Usa el mismo `frm_busqueda_general` y los mismos catálogos
''' reales que `frmRequisiconesDetalle.vb`. Al Aceptar corre
''' `RequisicionValidator.ValidarDistribucion` y bloquea el cierre si hay errores.
''' </summary>
Public Class frmRequisicionMasivaIA_Distribucion

    Private ReadOnly _cabecera As RequisicionCabeceraDraft
    Private ReadOnly _catalogo As New RequisicionCatalogContext(gs_empresa)
    Private ReadOnly _validator As New RequisicionValidator()

    Private _dtCC As DataTable
    Private _dtMarca As DataTable
    Private _dtCanal As DataTable
    Private _dtGasto As DataTable

    ''' <summary>Recibe la cabecera y la edita EN SITIO (mismo objeto, no un clon) — el
    ''' llamador ya trabaja sobre su propia copia editable.</summary>
    Public Sub New(cabecera As RequisicionCabeceraDraft)
        InitializeComponent()
        _cabecera = cabecera
    End Sub

    Private Sub frmRequisicionMasivaIA_Distribucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarEstilos()

        _dtCC = NuevaTablaDimension(False)
        _dtMarca = NuevaTablaDimension(True)
        _dtCanal = NuevaTablaDimension(False)
        _dtGasto = NuevaTablaDimension(False)
        dgvCC.DataSource = _dtCC
        dgvMarca.DataSource = _dtMarca
        dgvCanal.DataSource = _dtCanal
        dgvGasto.DataSource = _dtGasto

        LlenarTabla(_dtCC, _cabecera.CentrosCosto)
        LlenarTabla(_dtMarca, _cabecera.Marcas)
        LlenarTabla(_dtCanal, _cabecera.Canales)
        LlenarTabla(_dtGasto, _cabecera.Gastos)

        rbAyP.Checked = (If(_cabecera.TipoGasto, "").ToUpper = "CON_A&P")
        rbItem.Checked = Not rbAyP.Checked
    End Sub

    Private Sub AplicarEstilos()
        Me.BackColor = RequisicionIA_Estilos.ColorFondo
        Me.Controls.Add(RequisicionIA_Estilos.CrearHeader("Distribución de la Requisición"))

        pnlTipoGasto.BackColor = RequisicionIA_Estilos.ColorPanelSuave
        lblTipoGasto.ForeColor = RequisicionIA_Estilos.ColorTextoOscuro
        lblTipoGasto.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 8.5F, FontStyle.Bold)

        For Each btn As Button In {btnAgregarCC, btnBuscarCC, btnAgregarMarca, btnBuscarMarca,
                                    btnAgregarCanal, btnBuscarCanal, btnAgregarGasto, btnBuscarGasto}
            RequisicionIA_Estilos.EstilizarBotonSecundario(btn)
        Next
        For Each btn As Button In {btnEliminarCC, btnEliminarMarca, btnEliminarCanal, btnEliminarGasto}
            RequisicionIA_Estilos.EstilizarBotonSuave(btn)
        Next
        RequisicionIA_Estilos.EstilizarBotonPrimario(btnAceptar)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnCancelar)

        RequisicionIA_Estilos.EstilizarGrid(dgvCC)
        RequisicionIA_Estilos.EstilizarGrid(dgvMarca)
        RequisicionIA_Estilos.EstilizarGrid(dgvCanal)
        RequisicionIA_Estilos.EstilizarGrid(dgvGasto)
    End Sub

    Private Function NuevaTablaDimension(incluyeSocios As Boolean) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("porcentaje", GetType(Double))
        If incluyeSocios Then
            dt.Columns.Add("porcentajeEmpresa", GetType(Double))
            dt.Columns.Add("porcentajeSocio", GetType(Double))
            dt.Columns.Add("bu", GetType(String))
        End If
        Return dt
    End Function

    Private Sub LlenarTabla(dt As DataTable, items As List(Of RequisicionDimensionDraft))
        For Each it In items
            Dim dr As DataRow = dt.NewRow()
            dr("codigo") = it.Codigo
            dr("descripcion") = it.Descripcion
            dr("porcentaje") = it.Porcentaje
            If dt.Columns.Contains("porcentajeEmpresa") Then
                dr("porcentajeEmpresa") = If(it.PorcentajeEmpresa, 0)
                dr("porcentajeSocio") = If(it.PorcentajeSocio, 0)
                dr("bu") = it.Bu
            End If
            dt.Rows.Add(dr)
        Next
    End Sub

    ' ------------------------------------------------------------------
    ' Centro de Costo
    ' ------------------------------------------------------------------

    Private Sub btnAgregarCC_Click(sender As Object, e As EventArgs) Handles btnAgregarCC.Click
        _dtCC.Rows.Add(_dtCC.NewRow())
    End Sub

    Private Sub btnEliminarCC_Click(sender As Object, e As EventArgs) Handles btnEliminarCC.Click
        EliminarFilaSeleccionada(dgvCC, _dtCC)
    End Sub

    Private Sub btnBuscarCC_Click(sender As Object, e As EventArgs) Handles btnBuscarCC.Click
        If dgvCC.CurrentRow Is Nothing Then Return
        Dim catalogo = _catalogo.ObtenerCatalogo("CON_CCOSTO")
        Dim seleccionado = BuscarCodigo("empresa = '" & gs_empresa & "' and tipo in ('CON_CCOSTO') and ", "descripcion, codigo", "gen_tabcod", "codigo, descripcion, tipo")
        AplicarSeleccion(dgvCC.CurrentRow, seleccionado, catalogo)
    End Sub

    ' ------------------------------------------------------------------
    ' Marca
    ' ------------------------------------------------------------------

    Private Sub btnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        _dtMarca.Rows.Add(_dtMarca.NewRow())
    End Sub

    Private Sub btnEliminarMarca_Click(sender As Object, e As EventArgs) Handles btnEliminarMarca.Click
        EliminarFilaSeleccionada(dgvMarca, _dtMarca)
    End Sub

    Private Sub btnBuscarMarca_Click(sender As Object, e As EventArgs) Handles btnBuscarMarca.Click
        If dgvMarca.CurrentRow Is Nothing Then Return
        Dim catalogo = _catalogo.ObtenerCatalogo("CON_MARCA")
        Dim seleccionado = BuscarCodigo("empresa = '" & gs_empresa & "' and tipo in ('CON_MARCA') and ", "descripcion, codigo", "gen_tabcod", "codigo, descripcion, tipo")
        AplicarSeleccion(dgvMarca.CurrentRow, seleccionado, catalogo)
    End Sub

    ' ------------------------------------------------------------------
    ' Canal
    ' ------------------------------------------------------------------

    Private Sub btnAgregarCanal_Click(sender As Object, e As EventArgs) Handles btnAgregarCanal.Click
        _dtCanal.Rows.Add(_dtCanal.NewRow())
    End Sub

    Private Sub btnEliminarCanal_Click(sender As Object, e As EventArgs) Handles btnEliminarCanal.Click
        EliminarFilaSeleccionada(dgvCanal, _dtCanal)
    End Sub

    Private Sub btnBuscarCanal_Click(sender As Object, e As EventArgs) Handles btnBuscarCanal.Click
        If dgvCanal.CurrentRow Is Nothing Then Return
        Dim catalogo = _catalogo.ObtenerCatalogoCanal()
        Dim seleccionado = BuscarCodigo(
            "empresa = '" & gs_empresa & "' and tipo = 'sysgold_ejecutivos' and substring(texto4,3,1) = ')' and ",
            "texto4", "gen_tabcod", "Distinct texto4 as codigo, texto4 as descripcion")
        AplicarSeleccion(dgvCanal.CurrentRow, seleccionado, catalogo)
    End Sub

    ' ------------------------------------------------------------------
    ' Gasto (catálogo depende de ITEM/A&P)
    ' ------------------------------------------------------------------

    Private Sub btnAgregarGasto_Click(sender As Object, e As EventArgs) Handles btnAgregarGasto.Click
        _dtGasto.Rows.Add(_dtGasto.NewRow())
    End Sub

    Private Sub btnEliminarGasto_Click(sender As Object, e As EventArgs) Handles btnEliminarGasto.Click
        EliminarFilaSeleccionada(dgvGasto, _dtGasto)
    End Sub

    Private Sub btnBuscarGasto_Click(sender As Object, e As EventArgs) Handles btnBuscarGasto.Click
        If dgvGasto.CurrentRow Is Nothing Then Return
        Dim tipo As String = If(rbAyP.Checked, "CON_A&P", "CON_ITEM")
        Dim catalogo = _catalogo.ObtenerCatalogo(tipo)
        Dim seleccionado = BuscarCodigo("empresa = '" & gs_empresa & "' and tipo in ('" & tipo & "') and ", "descripcion, codigo", "gen_tabcod", "codigo, descripcion, tipo")
        AplicarSeleccion(dgvGasto.CurrentRow, seleccionado, catalogo)
    End Sub

    ' ------------------------------------------------------------------
    ' Helpers de búsqueda / grid
    ' ------------------------------------------------------------------

    Private Function BuscarCodigo(parametrosFijos As String, parametros As String, nombreVista As String, listaCampos As String) As String
        Dim frm As New frm_busqueda_general
        frm.parametros_fijos = parametrosFijos
        frm.parametros = parametros
        frm.nombre_vista = nombreVista
        frm.lista_campos = listaCampos
        frm.btn_seleccion_multipe.Visible = False
        frm.ShowDialog(Me)
        Dim resultado As String = frm.resultado
        frm.Dispose()
        Return resultado
    End Function

    ''' <summary>
    ''' Resuelve la descripción de un código contra el catálogo (llamado tanto al elegir
    ''' con "Buscar Código" como al escribir el código a mano y salir de la celda). Si no
    ''' existe, lo marca explícitamente en vez de dejarlo pasar en silencio.
    ''' </summary>
    Private Function AplicarSeleccion(fila As DataGridViewRow, codigo As String, catalogo As List(Of RequisicionCatalogContext.ItemCatalogo)) As Boolean
        If String.IsNullOrEmpty(codigo) Then Return False
        fila.Cells("codigo").Value = codigo
        Dim item = catalogo.FirstOrDefault(Function(c) String.Equals(c.Codigo, codigo, StringComparison.OrdinalIgnoreCase))
        If item IsNot Nothing Then
            fila.Cells("descripcion").Value = item.Descripcion
            ' "bu" es un atributo del código de marca en el catálogo (gen_tabcod.texto4),
            ' nunca algo que el usuario escriba a mano — solo aplica a la grilla de Marca.
            If fila.DataGridView IsNot Nothing AndAlso fila.DataGridView.Columns.Contains("bu") Then
                fila.Cells("bu").Value = item.Bu
            End If
            Return True
        Else
            fila.Cells("descripcion").Value = "(no existe)"
            Return False
        End If
    End Function

    ''' <summary>Se dispara cuando el usuario escribe un código a mano (sin usar "Buscar
    ''' Código") y sale de la celda — resuelve o marca "(no existe)" igual que el buscador.</summary>
    Private Sub dgvCC_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCC.CellEndEdit
        ResolverCodigoEditado(dgvCC, e, _catalogo.ObtenerCatalogo("CON_CCOSTO"))
    End Sub

    Private Sub dgvMarca_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarca.CellEndEdit
        ResolverCodigoEditado(dgvMarca, e, _catalogo.ObtenerCatalogo("CON_MARCA"))
    End Sub

    Private Sub dgvCanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanal.CellEndEdit
        ResolverCodigoEditado(dgvCanal, e, _catalogo.ObtenerCatalogoCanal())
    End Sub

    Private Sub dgvGasto_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGasto.CellEndEdit
        Dim tipo As String = If(rbAyP.Checked, "CON_A&P", "CON_ITEM")
        ResolverCodigoEditado(dgvGasto, e, _catalogo.ObtenerCatalogo(tipo))
    End Sub

    Private Sub ResolverCodigoEditado(grid As DataGridView, e As DataGridViewCellEventArgs, catalogo As List(Of RequisicionCatalogContext.ItemCatalogo))
        If e.RowIndex < 0 OrElse grid.Columns(e.ColumnIndex).Name <> "codigo" Then Return
        Dim fila = grid.Rows(e.RowIndex)
        Dim codigo As String = If(fila.Cells("codigo").Value Is Nothing, "", fila.Cells("codigo").Value.ToString).Trim
        If codigo.Length = 0 Then Return
        AplicarSeleccion(fila, codigo, catalogo)
    End Sub

    Private Sub EliminarFilaSeleccionada(grid As DataGridView, dt As DataTable)
        If grid.CurrentRow IsNot Nothing AndAlso grid.CurrentRow.Index < dt.Rows.Count Then
            dt.Rows.RemoveAt(grid.CurrentRow.Index)
        End If
    End Sub

    Private Function LeerDimensiones(dt As DataTable) As List(Of RequisicionDimensionDraft)
        Dim resultado As New List(Of RequisicionDimensionDraft)
        For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For
            Dim codigo As String = If(dr("codigo") Is DBNull.Value, "", dr("codigo").ToString).Trim
            If codigo.Length = 0 Then Continue For

            Dim dim1 As New RequisicionDimensionDraft With {
                .Codigo = codigo,
                .Descripcion = If(dr("descripcion") Is DBNull.Value, "", dr("descripcion").ToString),
                .Porcentaje = ValorDoubleSeguro(dr("porcentaje"))
            }
            If dt.Columns.Contains("porcentajeEmpresa") Then
                dim1.PorcentajeEmpresa = ValorDoubleSeguro(dr("porcentajeEmpresa"))
                dim1.PorcentajeSocio = ValorDoubleSeguro(dr("porcentajeSocio"))
                dim1.Bu = If(dr("bu") Is DBNull.Value, "", dr("bu").ToString)
            End If
            resultado.Add(dim1)
        Next
        Return resultado
    End Function

    Private Function ValorDoubleSeguro(valor As Object) As Double
        If valor Is Nothing OrElse valor Is DBNull.Value Then Return 0
        Dim resultado As Double
        Double.TryParse(valor.ToString, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, resultado)
        Return resultado
    End Function

    ' ------------------------------------------------------------------
    ' Aceptar / Cancelar
    ' ------------------------------------------------------------------

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cabeceraCandidata As New RequisicionCabeceraDraft With {
            .TipoGasto = If(rbAyP.Checked, "CON_A&P", "CON_ITEM")
        }
        cabeceraCandidata.CentrosCosto = LeerDimensiones(_dtCC)
        cabeceraCandidata.Marcas = LeerDimensiones(_dtMarca)
        cabeceraCandidata.Canales = LeerDimensiones(_dtCanal)
        cabeceraCandidata.Gastos = LeerDimensiones(_dtGasto)

        Dim errores = _validator.ValidarDistribucion(cabeceraCandidata)
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        _cabecera.TipoGasto = cabeceraCandidata.TipoGasto
        _cabecera.CentrosCosto = cabeceraCandidata.CentrosCosto
        _cabecera.Marcas = cabeceraCandidata.Marcas
        _cabecera.Canales = cabeceraCandidata.Canales
        _cabecera.Gastos = cabeceraCandidata.Gastos

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
