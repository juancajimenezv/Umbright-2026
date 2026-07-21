Imports System.Collections.Generic
Imports System.Data
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Public Class frm_actualizacion_oc

    ' Actualizacion de Ordenes de Compra (Compras/Import).
    '   Cabecera -> flexline.documento    Detalle -> flexline.documentod (por Correlativo)
    ' La edicion se hace DIRECTO en el grid del detalle. Un check interruptor habilita/bloquea
    ' las celdas autorizadas. Los cambios se guardan en una sola transaccion.

    Private Const CONEXION As String = "FlexLine"

    ' Columnas del detalle que el usuario puede editar directo en el grid
    Private ReadOnly COLS_EDITABLES() As String = {"Producto", "Cantidad", "Precio", "Fecha", "FechaEntrega", "FechaVcto"}

    ' ---- Estado de la orden consultada ----
    Private mEmpresa As String = ""
    Private mTipoDocto As String = ""
    Private mNumero As String = ""
    Private mCorrelativo As String = ""
    Private mClave As String = ""
    Private mParidad As Double = 1
    ' ---- Periodo original capturado (en memoria) ----
    Private mFechaOriginal As DateTime
    Private mPeriodoOriginal As String = ""
    Private mHabilitada As Boolean = False
    ' ---- Detalle en edicion ----
    Private mDtDet As DataTable = Nothing
    Private mColsInsert As List(Of String) = Nothing
    Private mFechaCabOrig As String = ""
    Private mPeriodoCabOrig As String = ""
    Private mCargando As Boolean = False   ' suprime eventos durante operaciones internas

    Private Sub frm_actualizacion_oc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResaltarTitulos()
        LimpiarResultado()
        LlenarEmpresas()
    End Sub

    ' Pone en negrilla solo el titulo de los groupbox (no su contenido)
    Private Sub ResaltarTitulos()
        Dim negrita As New System.Drawing.Font(Me.gb_documento.Font, System.Drawing.FontStyle.Bold)
        Dim normal As New System.Drawing.Font(Me.gb_documento.Font, System.Drawing.FontStyle.Regular)
        For Each gb As GroupBox In New GroupBox() {Me.gb_busqueda, Me.gb_documento}
            gb.Font = negrita
            For Each ctl As Control In gb.Controls
                ctl.Font = normal
            Next
        Next
        ' el check conserva su negrilla
        Me.chk_habilitar_edicion.Font = New System.Drawing.Font(Me.chk_habilitar_edicion.Font, System.Drawing.FontStyle.Bold)
    End Sub

    ' ================= COMBOS =================

    Private Sub LlenarEmpresas()
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim dt As DataTable = clsGen.selectQuery(CONEXION, "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'")
            Me.cmb_empresa.DisplayMember = "empresa"
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.DataSource = dt
            Try
                Me.cmb_empresa.SelectedValue = gs_empresa
            Catch
            End Try
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar las empresas." & vbCrLf & ex.Message, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        LlenarTiposDocto()
    End Sub

    Private Sub LlenarTiposDocto()
        Try
            Dim empresa As String = Me.cmb_empresa.Text.Trim
            If empresa = "" Then Return
            Dim clsGen As New ClasesGenerales.General
            Dim ls As String = "select TipoDocto from flexline.tipodocumento " & _
                "where empresa = '" & empresa & "' " & _
                "and tipodocto like '%ORDEN%COMPRA%' order by TipoDocto"
            Dim dt As DataTable = clsGen.selectQuery(CONEXION, ls)
            Me.cmb_tipodocto.DisplayMember = "TipoDocto"
            Me.cmb_tipodocto.ValueMember = "TipoDocto"
            Me.cmb_tipodocto.DataSource = dt
            If dt IsNot Nothing Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("TipoDocto").ToString.Trim.ToUpper = "ORDEN DE COMPRA" Then
                        Me.cmb_tipodocto.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar los tipos de documento." & vbCrLf & ex.Message, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedIndexChanged
        LlenarTiposDocto()
    End Sub

    ' ================= BUSQUEDA =================

    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            ConsultarOrden()
        ElseIf Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        ConsultarOrden()
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        If Not ConfirmarDescartePendientes() Then Return
        If mHabilitada Then
            MessageBox.Show("ATENCIÓN: la orden " & mNumero & " quedó con el periodo habilitado y NO se ha regresado a su periodo original.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.txt_numero.Text = ""
        LimpiarResultado()
        Me.txt_numero.Focus()
    End Sub

    Private Function HayCambiosPendientes() As Boolean
        If mDtDet Is Nothing Then Return False
        Return mDtDet.GetChanges() IsNot Nothing
    End Function

    Private Function ConfirmarDescartePendientes() As Boolean
        If Not HayCambiosPendientes() Then Return True
        Return MessageBox.Show("Hay cambios pendientes SIN GUARDAR en el detalle. ¿Desea descartarlos?", "Actualización OC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes
    End Function

    Private Sub ConsultarOrden()
        Dim empresa As String = Me.cmb_empresa.Text.Trim
        Dim tipo As String = Me.cmb_tipodocto.Text.Trim
        Dim numero As String = Me.txt_numero.Text.Trim

        If empresa = "" OrElse tipo = "" Then
            MessageBox.Show("Seleccione la empresa y el tipo de documento.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If numero = "" OrElse Not IsNumeric(numero) Then
            MessageBox.Show("Digite el número de la orden (solo números).", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_numero.Focus()
            Return
        End If

        numero = numero.PadLeft(10, "0"c)
        Dim claveNueva As String = empresa & "|" & tipo & "|" & numero
        If claveNueva <> mClave AndAlso Not ConfirmarDescartePendientes() Then Return
        Me.txt_numero.Text = numero

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim clsGen As New ClasesGenerales.General

            ' -- Cabecera --
            Dim sqlDoc As String = "select * from flexline.documento " & _
                "where empresa = '" & empresa & "' and numero = '" & numero & "' and tipodocto like '%" & tipo & "%'"
            Dim dtDoc As DataTable = clsGen.selectQuery(CONEXION, sqlDoc)

            If dtDoc Is Nothing OrElse dtDoc.Rows.Count = 0 Then
                LimpiarResultado()
                MessageBox.Show("No se encontró la orden " & numero & " (" & tipo & ") en la empresa " & empresa & ".", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dr As DataRow = dtDoc.Rows(0)
            MostrarCabecera(dr)
            mFechaCabOrig = Me.txt_h_fecha.Text
            mPeriodoCabOrig = Me.txt_h_periodolibro.Text

            mEmpresa = ValorCol(dr, "Empresa")
            mTipoDocto = ValorCol(dr, "TipoDocto")
            mNumero = ValorCol(dr, "Numero")
            mCorrelativo = ValorCol(dr, "Correlativo")

            mParidad = 1
            Try
                If Not IsDBNull(dr.Item("Paridad")) Then mParidad = Convert.ToDouble(dr.Item("Paridad"))
            Catch
            End Try
            If mParidad = 0 Then mParidad = 1

            Dim clave As String = mEmpresa & "|" & mTipoDocto & "|" & mNumero
            If clave <> mClave Then
                mClave = clave
                mHabilitada = False
                mPeriodoOriginal = ""
                Me.btn_restaurar.Enabled = False
                Me.lbl_periodo_original.Text = ""
            End If

            ' -- Detalle --
            Dim sqlDet As String = "select Empresa, TipoDocto, Correlativo, Linea, Secuencia, Producto, Cantidad, UnidadIngreso, Precio, PrecioAjustado, PorcentajeDR, SubTotal, Neto, Total, CantidadIngreso, PrecioIngreso, SubTotalIngreso, NetoIngreso, TotalIngreso, Bodega, Fecha, FechaEntrega, FechaVcto, FechaModif, FechaVigenciaLp, Vigente, Comentario " & _
                "from flexline.documentod " & _
                "where empresa = '" & mEmpresa & "' and correlativo = '" & mCorrelativo & "' and tipodocto = '" & mTipoDocto & "' order by Linea"
            mDtDet = clsGen.selectQuery(CONEXION, sqlDet)

            ' Columnas internas de apoyo
            If Not mDtDet.Columns.Contains("srcLinea") Then mDtDet.Columns.Add(New DataColumn("srcLinea", GetType(Integer)))
            If Not mDtDet.Columns.Contains("factorUnidad") Then mDtDet.Columns.Add(New DataColumn("factorUnidad", GetType(Double)))
            ' Factor unidades por linea = Cantidad / CantidadIngreso (para recalcular los montos Ingreso)
            For Each r As DataRow In mDtDet.Rows
                Dim c As Double = ADouble(r.Item("Cantidad"))
                Dim ci As Double = ADouble(r.Item("CantidadIngreso"))
                r.Item("factorUnidad") = If(c > 0 AndAlso ci > 0, c / ci, 1)
            Next
            mDtDet.AcceptChanges()

            mCargando = True
            Me.dgv_detalle.DefaultCellStyle.NullValue = "NULL"
            Me.dgv_detalle.DataSource = mDtDet
            PrepararGrid()
            Me.chk_habilitar_edicion.Checked = False
            AplicarModoEdicion(False)
            mCargando = False

            Me.lbl_lineas.Text = "Líneas: " & mDtDet.Rows.Count.ToString
            ActualizarContador()

            RecuperarHabilitacion(ValorCol(dr, "PeriodoLibro"))
            ValidarPeriodo(dr)
        Catch ex As Exception
            MessageBox.Show("Error al consultar la orden." & vbCrLf & ex.Message, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ================= GRID =================

    Private Sub PrepararGrid()
        ' Columna de check "Sel" (para eliminar varias a la vez)
        If Me.dgv_detalle.Columns("Sel") Is Nothing Then
            Dim chk As New DataGridViewCheckBoxColumn()
            chk.Name = "Sel"
            chk.HeaderText = "Sel"
            chk.Width = 35
            chk.Frozen = True
            chk.DefaultCellStyle.NullValue = False
            Me.dgv_detalle.Columns.Insert(0, chk)
        End If
        ' Ocultar columnas internas
        If Me.dgv_detalle.Columns("srcLinea") IsNot Nothing Then Me.dgv_detalle.Columns("srcLinea").Visible = False
        If Me.dgv_detalle.Columns("factorUnidad") IsNot Nothing Then Me.dgv_detalle.Columns("factorUnidad").Visible = False
        ' Fechas editables en formato corto para facilitar la captura
        For Each cn As String In New String() {"Fecha", "FechaEntrega", "FechaVcto"}
            UsarCalendario(cn)
        Next
        ' Resaltar los encabezados de las columnas editables
        For Each col As DataGridViewColumn In Me.dgv_detalle.Columns
            If EsColumnaResaltable(col.Name) Then
                col.HeaderCell.Style.BackColor = Drawing.Color.LightSteelBlue
                col.HeaderCell.Style.ForeColor = Drawing.Color.Black
                col.HeaderCell.Style.Font = New Drawing.Font(Me.dgv_detalle.Font, Drawing.FontStyle.Bold)
            End If
        Next
    End Sub

    ' Cambia una columna de fecha por una con calendario (DateTimePicker)
    Private Sub UsarCalendario(colName As String)
        Dim col As DataGridViewColumn = Me.dgv_detalle.Columns(colName)
        If col Is Nothing Then Return
        If TypeOf col Is CalendarColumn Then Return
        Dim idx As Integer = col.Index
        Dim header As String = col.HeaderText
        Dim dp As String = col.DataPropertyName
        Me.dgv_detalle.Columns.Remove(col)
        Dim cal As New CalendarColumn()
        cal.Name = colName
        cal.HeaderText = header
        cal.DataPropertyName = dp
        Me.dgv_detalle.Columns.Insert(idx, cal)
    End Sub

    ' Habilita/bloquea la edicion de las celdas autorizadas y los botones
    Private Sub AplicarModoEdicion(habilitado As Boolean)
        Me.dgv_detalle.ReadOnly = Not habilitado
        If habilitado Then
            For Each col As DataGridViewColumn In Me.dgv_detalle.Columns
                col.ReadOnly = Not EsColumnaEditable(col.Name)
            Next
        End If
        Me.btn_agregar.Enabled = habilitado
        Me.btn_eliminar.Enabled = habilitado
        Me.btn_descartar.Enabled = habilitado
        Me.btn_guardar.Enabled = habilitado
        ' Cabecera: PeriodoLibro y Fecha editables al habilitar
        Me.txt_h_periodolibro.ReadOnly = Not habilitado
        Me.txt_h_fecha.ReadOnly = Not habilitado
        If habilitado Then
            Me.txt_h_periodolibro.BackColor = Drawing.Color.White
            Me.txt_h_fecha.BackColor = Drawing.Color.White
        Else
            Me.txt_h_periodolibro.BackColor = System.Drawing.SystemColors.Control
            Me.txt_h_fecha.BackColor = System.Drawing.SystemColors.Control
        End If
        Me.dgv_detalle.Invalidate()
    End Sub

    ' Columnas de datos editables (para resaltar); NO incluye el check Sel
    Private Function EsColumnaResaltable(nombre As String) As Boolean
        For Each c As String In COLS_EDITABLES
            If String.Equals(c, nombre, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return False
    End Function

    Private Function EsColumnaEditable(nombre As String) As Boolean
        If nombre = "Sel" Then Return True
        For Each c As String In COLS_EDITABLES
            If String.Equals(c, nombre, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return False
    End Function

    ' Interruptor: habilitar / bloquear los campos autorizados
    Private Sub chk_habilitar_edicion_CheckedChanged(sender As Object, e As EventArgs) Handles chk_habilitar_edicion.CheckedChanged
        If mCargando Then Return
        If Me.chk_habilitar_edicion.Checked Then
            AplicarModoEdicion(True)
        Else
            If HayCambiosPendientes() Then
                If MessageBox.Show("Hay cambios pendientes SIN GUARDAR. ¿Desea descartarlos y bloquear la edición?", "Actualización OC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                    mCargando = True
                    Me.chk_habilitar_edicion.Checked = True
                    mCargando = False
                    Return
                End If
                mDtDet.RejectChanges()
                LimpiarChecks()
                ActualizarContador()
                Me.dgv_detalle.Invalidate()
            End If
            AplicarModoEdicion(False)
        End If
    End Sub

    ' Confirmar el check de la columna Sel de inmediato
    Private Sub dgv_detalle_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv_detalle.CurrentCellDirtyStateChanged
        If Me.dgv_detalle.IsCurrentCellDirty AndAlso Me.dgv_detalle.CurrentCell IsNot Nothing _
            AndAlso Me.dgv_detalle.CurrentCell.OwningColumn.Name = "Sel" Then
            Me.dgv_detalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' Colores: nueva=verde, eliminada=rojo, modificada=amarillo
    Private Sub dgv_detalle_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_detalle.CellFormatting
        Try
            Dim drv As DataRowView = TryCast(Me.dgv_detalle.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            If drv.Row.RowState = DataRowState.Added Then
                e.CellStyle.BackColor = Drawing.Color.LightGreen
            ElseIf drv.Row.RowState = DataRowState.Modified Then
                If drv.Row.Item("Vigente").ToString.Trim.ToUpper = "N" Then
                    e.CellStyle.BackColor = Drawing.Color.LightCoral
                Else
                    e.CellStyle.BackColor = Drawing.Color.LightYellow
                End If
            Else
                ' Por defecto todo bloqueado (gris, como en DOCUMENTO); solo blanco lo editable al habilitar
                Dim cn As String = Me.dgv_detalle.Columns(e.ColumnIndex).Name
                If cn = "Sel" Then
                    If Not Me.chk_habilitar_edicion.Checked Then e.CellStyle.BackColor = System.Drawing.SystemColors.Control
                ElseIf Me.chk_habilitar_edicion.Checked AndAlso EsColumnaResaltable(cn) Then
                    e.CellStyle.BackColor = Drawing.Color.White
                Else
                    e.CellStyle.BackColor = System.Drawing.SystemColors.Control
                End If
            End If
        Catch
        End Try
    End Sub

    ' Validacion al escribir en una celda autorizada
    Private Sub dgv_detalle_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv_detalle.CellValidating
        If mCargando Then Return
        Dim col As String = Me.dgv_detalle.Columns(e.ColumnIndex).Name
        Dim val As String = If(e.FormattedValue Is Nothing, "", e.FormattedValue.ToString.Trim)

        Select Case col
            Case "Cantidad"
                Dim d As Double
                If Not Double.TryParse(val, NumberStyles.Any, CultureInfo.CurrentCulture, d) OrElse d <= 0 Then
                    MessageBox.Show("Cantidad inválida (debe ser numérica y mayor que cero).", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            Case "Precio"
                Dim d As Double
                If Not Double.TryParse(val, NumberStyles.Any, CultureInfo.CurrentCulture, d) OrElse d < 0 Then
                    MessageBox.Show("Precio inválido (debe ser numérico, cero o mayor).", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            Case "Fecha", "FechaEntrega", "FechaVcto"
                Dim f As DateTime
                If Not DateTime.TryParse(val, f) Then
                    MessageBox.Show("Fecha inválida. Use el formato aaaa-mm-dd.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            Case "Producto"
                If val = "" Then
                    MessageBox.Show("El producto no puede quedar vacío.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
        End Select
    End Sub

    ' Al terminar de editar: recalcular montos / validar producto
    Private Sub dgv_detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellEndEdit
        If mCargando Then Return
        If e.RowIndex < 0 Then Return
        Dim drv As DataRowView = TryCast(Me.dgv_detalle.Rows(e.RowIndex).DataBoundItem, DataRowView)
        If drv Is Nothing Then Return
        Dim col As String = Me.dgv_detalle.Columns(e.ColumnIndex).Name

        If col = "Cantidad" OrElse col = "Precio" Then
            RecalcularFila(drv.Row)
            Me.dgv_detalle.InvalidateRow(e.RowIndex)
        ElseIf col = "Producto" Then
            Dim prod As String = drv.Row.Item("Producto").ToString.Trim
            If prod <> "" AndAlso Not ProductoExiste(prod) Then
                MessageBox.Show("Aviso: el producto '" & prod & "' NO existe en la empresa " & mEmpresa & "." & vbCrLf & "Verifíquelo antes de guardar.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        ActualizarContador()
    End Sub

    Private Sub dgv_detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv_detalle.DataError
        e.ThrowException = False
        e.Cancel = True
        MessageBox.Show("Valor inválido en la columna '" & Me.dgv_detalle.Columns(e.ColumnIndex).Name & "'.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ' Recalcula los montos de una linea (Neto = Cantidad x Precio; Ingreso con factor y paridad)
    Private Sub RecalcularFila(dr As DataRow)
        Dim cantidad As Double = ADouble(dr.Item("Cantidad"))
        Dim precio As Double = ADouble(dr.Item("Precio"))
        Dim neto As Double = cantidad * precio

        ' Factor de empaque real del producto (producto.factoralt); 0 o nulo => 1 a 1
        Dim producto As String = dr.Item("Producto").ToString.Trim
        Dim factor As Double = FactorProducto(producto)
        If factor <= 0 Then factor = 1
        Dim cantIng As Double = cantidad / factor

        dr.Item("PrecioAjustado") = precio
        dr.Item("SubTotal") = neto
        dr.Item("Neto") = neto
        dr.Item("Total") = neto
        dr.Item("CantidadIngreso") = cantIng
        dr.Item("SubTotalIngreso") = neto / mParidad
        dr.Item("NetoIngreso") = neto / mParidad
        dr.Item("TotalIngreso") = neto / mParidad
        If cantIng <> 0 Then
            dr.Item("PrecioIngreso") = (neto / mParidad) / cantIng
        Else
            dr.Item("PrecioIngreso") = 0
        End If
    End Sub

    ' Devuelve el factoralt del producto (unidades por unidad de ingreso); 0 si no aplica
    Private Function FactorProducto(producto As String) As Double
        If producto Is Nothing OrElse producto.Trim = "" Then Return 0
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim sql As String = "select factoralt from flexline.producto where empresa = " & Comilla(mEmpresa) & " and producto = " & Comilla(producto.Trim)
            Dim dt As DataTable = clsGen.selectQuery(CONEXION, sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then Return ADouble(dt.Rows(0).Item("factoralt"))
        Catch
        End Try
        Return 0
    End Function

    ' Envuelve texto entre comillas simples para SQL
    Private Function Comilla(s As String) As String
        Return "'" & s.Replace("'", "''") & "'"
    End Function

    Private Function ProductoExiste(producto As String) As Boolean
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim dt As DataTable = clsGen.selectQuery(CONEXION, "select top 1 producto from flexline.producto where empresa = '" & mEmpresa & "' and producto = '" & producto.Replace("'", "''") & "'")
            Return dt IsNot Nothing AndAlso dt.Rows.Count > 0
        Catch
            Return False
        End Try
    End Function

    Private Sub LimpiarChecks()
        For Each fila As DataGridViewRow In Me.dgv_detalle.Rows
            If fila.Cells("Sel") IsNot Nothing Then fila.Cells("Sel").Value = False
        Next
    End Sub

    ' ================= AGREGAR LINEA (EN BLANCO) =================

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        ' Toma una linea existente como plantilla de los campos tecnicos (por defecto)
        Dim plantilla As DataRow = Nothing
        For Each r As DataRow In mDtDet.Rows
            If r.RowState <> DataRowState.Deleted AndAlso r.RowState <> DataRowState.Added Then
                plantilla = r
                Exit For
            End If
        Next
        If plantilla Is Nothing Then
            MessageBox.Show("La orden no tiene lineas base para tomar los valores por defecto.", "Actualizaci
ó
n OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim maxLinea As Integer = 0, maxSec As Integer = 0
        For Each r As DataRow In mDtDet.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            maxLinea = Math.Max(maxLinea, CInt(ADouble(r.Item("Linea"))))
            maxSec = Math.Max(maxSec, CInt(ADouble(r.Item("Secuencia"))))
        Next

        Dim nuevo As DataRow = mDtDet.NewRow()
        ' Hereda los campos tecnicos por defecto de la plantilla
        nuevo.ItemArray = CType(plantilla.ItemArray.Clone(), Object())
        ' Campos fijos de la orden
        nuevo.Item("Empresa") = mEmpresa
        nuevo.Item("TipoDocto") = mTipoDocto
        nuevo.Item("Correlativo") = mCorrelativo
        ' Numero de linea y secuencia que le tocan
        nuevo.Item("Linea") = maxLinea + 1
        nuevo.Item("Secuencia") = maxSec + 1
        nuevo.Item("Vigente") = "S"
        ' Campos autorizados en blanco
        nuevo.Item("Producto") = ""
        nuevo.Item("Cantidad") = 0
        nuevo.Item("Precio") = 0
        ' Campos calculados en cero (se recalculan al capturar cantidad/precio)
        nuevo.Item("PrecioAjustado") = 0
        nuevo.Item("SubTotal") = 0
        nuevo.Item("Neto") = 0
        nuevo.Item("Total") = 0
        nuevo.Item("CantidadIngreso") = 0
        nuevo.Item("PrecioIngreso") = 0
        nuevo.Item("SubTotalIngreso") = 0
        nuevo.Item("NetoIngreso") = 0
        nuevo.Item("TotalIngreso") = 0
        ' Plantilla en SQL para copiar los campos tecnicos
        nuevo.Item("srcLinea") = CInt(ADouble(plantilla.Item("Linea", DataRowVersion.Original)))
        mDtDet.Rows.Add(nuevo)

        ActualizarContador()
        MessageBox.Show("Linea " & (maxLinea + 1).ToString & " agregada en blanco." & vbCrLf & _
            "Capture Producto, Cantidad, Precio y las fechas directamente en el grid.", "Actualizaci
ó
n OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ================= ELIMINAR LINEA(S) MARCADAS =================

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Dim marcadas As New List(Of DataGridViewRow)
        For Each fila As DataGridViewRow In Me.dgv_detalle.Rows
            Dim v As Object = fila.Cells("Sel").Value
            If v IsNot Nothing AndAlso TypeOf v Is Boolean AndAlso CBool(v) Then marcadas.Add(fila)
        Next

        If marcadas.Count = 0 Then
            MessageBox.Show("Marque con el check las líneas que desea eliminar.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim lineas As New List(Of String)
        For Each fila As DataGridViewRow In marcadas
            Dim drv As DataRowView = TryCast(fila.DataBoundItem, DataRowView)
            If drv IsNot Nothing Then lineas.Add(drv.Row.Item("Linea").ToString)
        Next

        If MessageBox.Show("Se marcarán como eliminadas (Vigente='N') " & marcadas.Count.ToString & " línea(s): " & String.Join(", ", lineas.ToArray()) & vbCrLf & vbCrLf & _
            "El cambio se aplica en la BD hasta presionar GUARDAR CAMBIOS. ¿Desea continuar?", "Eliminar Líneas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        For Each fila As DataGridViewRow In marcadas
            Dim drv As DataRowView = TryCast(fila.DataBoundItem, DataRowView)
            If drv Is Nothing Then Continue For
            If drv.Row.RowState = DataRowState.Added Then
                mDtDet.Rows.Remove(drv.Row)
            Else
                drv.Row.Item("Vigente") = "N"
                fila.Cells("Sel").Value = False
            End If
        Next

        Me.dgv_detalle.Invalidate()
        ActualizarContador()
    End Sub

    ' ================= DESCARTAR =================

    Private Sub btn_descartar_Click(sender As Object, e As EventArgs) Handles btn_descartar.Click
        If Not HayCambiosPendientes() Then
            MessageBox.Show("No hay cambios pendientes.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Se descartarán TODOS los cambios pendientes. ¿Desea continuar?", "Descartar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        mDtDet.RejectChanges()
        LimpiarChecks()
        Me.dgv_detalle.Invalidate()
        ActualizarContador()
    End Sub

    ' ================= GUARDAR (una transaccion) =================

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim cambioCab As Boolean = CabeceraCambio()
        If Not HayCambiosPendientes() AndAlso Not cambioCab Then
            MessageBox.Show("No hay cambios pendientes por guardar.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Validar cabecera si cambió Fecha / PeriodoLibro
        Dim fCab As DateTime = New DateTime(1900, 1, 1)
        Dim perCab As String = ""
        If cambioCab Then
            If Not DateTime.TryParse(Me.txt_h_fecha.Text.Trim, fCab) Then
                MessageBox.Show("La Fecha de la cabecera no es válida. Use el formato aaaa-mm-dd.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            perCab = Me.txt_h_periodolibro.Text.Trim
            If perCab.Length <> 6 OrElse Not IsNumeric(perCab) Then
                MessageBox.Show("El PeriodoLibro debe ser numérico de 6 dígitos (aaaamm).", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' Validar productos / cantidades de las líneas
        For Each dr As DataRow In mDtDet.Rows
            If dr.RowState = DataRowState.Added OrElse dr.RowState = DataRowState.Modified Then
                If dr.Item("Vigente").ToString.Trim.ToUpper = "N" Then Continue For
                If ADouble(dr.Item("Cantidad")) <= 0 Then
                    MessageBox.Show("La línea " & dr.Item("Linea").ToString & " tiene cantidad en cero. Capture una cantidad válida.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Dim prod As String = dr.Item("Producto").ToString.Trim
                If prod = "" OrElse Not ProductoExiste(prod) Then
                    MessageBox.Show("La línea " & dr.Item("Linea").ToString & " tiene un producto inválido ('" & prod & "'). Corrija antes de guardar.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        Next

        Dim nMod As Integer = 0, nNue As Integer = 0, nEli As Integer = 0
        ContarCambios(nMod, nNue, nEli)

        Dim msg As String = "Se aplicarán los siguientes cambios a la orden " & mNumero & " (" & mTipoDocto & ") de " & mEmpresa & ":" & vbCrLf & vbCrLf & _
            "   Líneas modificadas: " & nMod.ToString & vbCrLf & _
            "   Líneas nuevas:      " & nNue.ToString & vbCrLf & _
            "   Líneas eliminadas:  " & nEli.ToString & " (Vigente='N')" & vbCrLf
        If cambioCab Then
            msg = msg & "   Cabecera -> Fecha " & fCab.ToString("yyyy-MM-dd") & ", PeriodoLibro " & perCab & ", Valoriza S" & vbCrLf
        End If
        msg = msg & vbCrLf & "También se recalculan los totales de la cabecera. ¿Desea continuar?"
        If MessageBox.Show(msg, "GUARDAR CAMBIOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim sb As New StringBuilder()
        sb.Append("set xact_abort on begin tran ")
        Try
            For Each dr As DataRow In mDtDet.Rows
                If dr.RowState = DataRowState.Added Then
                    sb.Append(SqlInsertLinea(dr))
                    sb.Append(LogSql("AGREGA_LINEA", linea:=CInt(ADouble(dr.Item("Linea"))).ToString, secuencia:=CInt(ADouble(dr.Item("Secuencia"))).ToString, producto:=Comilla(dr.Item("Producto").ToString.Trim)))
                ElseIf dr.RowState = DataRowState.Modified Then
                    sb.Append(SqlUpdateLinea(dr))
                    If dr.Item("Vigente").ToString.Trim.ToUpper = "N" Then
                        sb.Append(LogSql("ELIMINA_LINEA", linea:=CInt(ADouble(dr.Item("Linea"))).ToString, secuencia:=CInt(ADouble(dr.Item("Secuencia"))).ToString, producto:=Comilla(dr.Item("Producto").ToString.Trim)))
                    Else
                        LogCamposModificados(sb, dr)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("No se pudo preparar el guardado." & vbCrLf & ex.Message, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim keyDet As String = "empresa = '" & mEmpresa & "' and tipodocto = '" & mTipoDocto & "' and correlativo = '" & mCorrelativo & "' and vigente = 'S'"
        sb.Append("update flexline.documento set ")
        sb.Append("neto = (select isnull(sum(neto),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("subtotal = (select isnull(sum(subtotal),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("total = (select isnull(sum(total),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("netoingreso = (select isnull(sum(netoingreso),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("subtotalingreso = (select isnull(sum(subtotalingreso),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("totalingreso = (select isnull(sum(totalingreso),0) from flexline.documentod where " & keyDet & "), ")
        sb.Append("fechamodif = getdate(), fechaumodif = getdate(), usuariomodif = '" & gs_usuario & "' ")
        sb.Append("where empresa = '" & mEmpresa & "' and tipodocto = '" & mTipoDocto & "' and numero = '" & mNumero & "' ")

        ' Si el usuario cambió Fecha/PeriodoLibro de la cabecera, aplicarlo (Valoriza siempre S) + log
        If cambioCab Then
            Dim fstr As String = fCab.ToString("yyyyMMdd")
            sb.Append("update flexline.documento set fecha = '" & fstr & "', PeriodoLibro = '" & perCab & "', Valoriza = 'S' ")
            sb.Append("where empresa = '" & mEmpresa & "' and tipodocto = '" & mTipoDocto & "' and numero = '" & mNumero & "' ")
            sb.Append("update flexline.documentod set fecha = '" & fstr & "' ")
            sb.Append("where empresa = '" & mEmpresa & "' and tipodocto = '" & mTipoDocto & "' and correlativo = '" & mCorrelativo & "' ")
            sb.Append(LogSql("MODIFICA_CABECERA", campo:=Comilla("Fecha"), vAnt:=Comilla(mFechaCabOrig), vNue:=Comilla(fCab.ToString("yyyy-MM-dd"))))
            sb.Append(LogSql("MODIFICA_CABECERA", campo:=Comilla("PeriodoLibro"), vAnt:=Comilla(mPeriodoCabOrig), vNue:=Comilla(perCab)))
        End If

        sb.Append("commit tran")

        If Not EjecutarConReintento(sb.ToString(), "guardar los cambios") Then Return

        MessageBox.Show("Cambios guardados correctamente.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ConsultarOrden()
    End Sub

    ' Indica si el usuario cambió Fecha o PeriodoLibro en la cabecera
    Private Function CabeceraCambio() As Boolean
        If mFechaCabOrig Is Nothing Then Return False
        Return (Me.txt_h_fecha.Text.Trim <> mFechaCabOrig.Trim) OrElse (Me.txt_h_periodolibro.Text.Trim <> mPeriodoCabOrig.Trim)
    End Function

    Private Sub ContarCambios(ByRef nMod As Integer, ByRef nNue As Integer, ByRef nEli As Integer)
        nMod = 0 : nNue = 0 : nEli = 0
        If mDtDet Is Nothing Then Return
        For Each dr As DataRow In mDtDet.Rows
            If dr.RowState = DataRowState.Added Then
                nNue += 1
            ElseIf dr.RowState = DataRowState.Modified Then
                If dr.Item("Vigente").ToString.Trim.ToUpper = "N" Then nEli += 1 Else nMod += 1
            End If
        Next
    End Sub

    Private Sub ActualizarContador()
        Dim nMod As Integer = 0, nNue As Integer = 0, nEli As Integer = 0
        ContarCambios(nMod, nNue, nEli)
        Me.lbl_cambios.Text = "Cambios pendientes: " & nMod.ToString & " modificadas, " & nNue.ToString & " nuevas, " & nEli.ToString & " eliminadas"
    End Sub

    Private Function FilaActual() As DataRow
        If Me.dgv_detalle.CurrentRow Is Nothing Then Return Nothing
        Dim drv As DataRowView = TryCast(Me.dgv_detalle.CurrentRow.DataBoundItem, DataRowView)
        If drv Is Nothing Then Return Nothing
        Return drv.Row
    End Function

    ' ================= SQL DEL DETALLE =================

    Private Function SqlUpdateLinea(dr As DataRow) As String
        Dim lineaOrig As String = CInt(ADouble(dr.Item("Linea", DataRowVersion.Original))).ToString
        Return "update flexline.documentod set " & _
            "producto = '" & dr.Item("Producto").ToString.Trim.Replace("'", "''") & "', " & _
            "cantidad = " & NumSql(dr.Item("Cantidad")) & ", " & _
            "precio = " & NumSql(dr.Item("Precio")) & ", " & _
            "precioajustado = " & NumSql(dr.Item("PrecioAjustado")) & ", " & _
            "subtotal = " & NumSql(dr.Item("SubTotal")) & ", " & _
            "neto = " & NumSql(dr.Item("Neto")) & ", " & _
            "total = " & NumSql(dr.Item("Total")) & ", " & _
            "cantidadingreso = " & NumSql(dr.Item("CantidadIngreso")) & ", " & _
            "precioingreso = " & NumSql(dr.Item("PrecioIngreso")) & ", " & _
            "subtotalingreso = " & NumSql(dr.Item("SubTotalIngreso")) & ", " & _
            "netoingreso = " & NumSql(dr.Item("NetoIngreso")) & ", " & _
            "totalingreso = " & NumSql(dr.Item("TotalIngreso")) & ", " & _
            "fecha = " & FechaSql(dr.Item("Fecha")) & ", " & _
            "fechaentrega = " & FechaSql(dr.Item("FechaEntrega")) & ", " & _
            "fechavcto = " & FechaSql(dr.Item("FechaVcto")) & ", " & _
            "vigente = '" & dr.Item("Vigente").ToString.Trim & "', " & _
            "fechamodif = getdate() " & _
            "where empresa = '" & mEmpresa & "' and tipodocto = '" & mTipoDocto & "' and correlativo = '" & mCorrelativo & "' and linea = " & lineaOrig & " "
    End Function

    Private Function SqlInsertLinea(dr As DataRow) As String
        CargarColumnasInsert()
        Dim dicValores As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        dicValores("linea") = CInt(ADouble(dr.Item("Linea"))).ToString
        dicValores("secuencia") = CInt(ADouble(dr.Item("Secuencia"))).ToString
        dicValores("producto") = "'" & dr.Item("Producto").ToString.Trim.Replace("'", "''") & "'"
        dicValores("cantidad") = NumSql(dr.Item("Cantidad"))
        dicValores("precio") = NumSql(dr.Item("Precio"))
        dicValores("precioajustado") = NumSql(dr.Item("PrecioAjustado"))
        dicValores("subtotal") = NumSql(dr.Item("SubTotal"))
        dicValores("neto") = NumSql(dr.Item("Neto"))
        dicValores("total") = NumSql(dr.Item("Total"))
        dicValores("cantidadingreso") = NumSql(dr.Item("CantidadIngreso"))
        dicValores("precioingreso") = NumSql(dr.Item("PrecioIngreso"))
        dicValores("subtotalingreso") = NumSql(dr.Item("SubTotalIngreso"))
        dicValores("netoingreso") = NumSql(dr.Item("NetoIngreso"))
        dicValores("totalingreso") = NumSql(dr.Item("TotalIngreso"))
        dicValores("fecha") = FechaSql(dr.Item("Fecha"))
        dicValores("fechaentrega") = FechaSql(dr.Item("FechaEntrega"))
        dicValores("fechavcto") = FechaSql(dr.Item("FechaVcto"))
        dicValores("fechamodif") = "getdate()"
        dicValores("vigente") = "'S'"

        Dim cols As New StringBuilder()
        Dim vals As New StringBuilder()
        For Each c As String In mColsInsert
            If cols.Length > 0 Then
                cols.Append(", ")
                vals.Append(", ")
            End If
            cols.Append("[" & c & "]")
            If dicValores.ContainsKey(c) Then
                vals.Append(dicValores(c))
            Else
                vals.Append("src.[" & c & "]")
            End If
        Next

        Dim srcLinea As String = CInt(ADouble(dr.Item("srcLinea"))).ToString
        Return "insert into flexline.documentod (" & cols.ToString & ") " & _
            "select " & vals.ToString & " from flexline.documentod src " & _
            "where src.empresa = '" & mEmpresa & "' and src.tipodocto = '" & mTipoDocto & "' and src.correlativo = '" & mCorrelativo & "' and src.linea = " & srcLinea & " "
    End Function

    Private Sub CargarColumnasInsert()
        If mColsInsert IsNot Nothing Then Return
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable = clsGen.selectQuery(CONEXION, _
            "select name from sys.columns where object_id = object_id('flexline.documentod') and is_identity = 0 and is_computed = 0 order by column_id")
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Throw New Exception("No se pudieron leer las columnas de flexline.documentod.")
        mColsInsert = New List(Of String)
        For Each r As DataRow In dt.Rows
            mColsInsert.Add(r.Item("name").ToString)
        Next
    End Sub

    ' ================= HELPERS =================

    Private Function ADouble(v As Object) As Double
        If v Is Nothing OrElse IsDBNull(v) Then Return 0
        Try
            Return Convert.ToDouble(v)
        Catch
            Return 0
        End Try
    End Function

    Private Function NumSql(v As Object) As String
        Return ADouble(v).ToString(CultureInfo.InvariantCulture)
    End Function

    Private Function FechaSql(v As Object) As String
        If v Is Nothing OrElse IsDBNull(v) Then Return "'19000101'"
        Try
            Return "'" & CType(v, DateTime).ToString("yyyyMMdd") & "'"
        Catch
            Return "'19000101'"
        End Try
    End Function

    ' ================= VALIDACION DE PERIODO =================

    ' Lee el log y lo VALIDA contra la realidad (PeriodoLibro real del documento):
    '   - Si sigue en el periodo habilitado -> la orden esta realmente ABIERTA (recupera original).
    '   - Si ya volvio a otro periodo (la regresaron por fuera, ej. SQL directo) -> auto-cierra el log.
    Private Sub RecuperarHabilitacion(periodoReal As String)
        mHabilitada = False
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim sql As String = "select top 1 id, fecha_original, periodo_original, periodo_habilitado from scm.dbo.log_actualizacion_oc " & _
                "where empresa = " & Comilla(mEmpresa) & " and tipodocto = " & Comilla(mTipoDocto) & " and numero = " & Comilla(mNumero) & _
                " and accion = " & Comilla("HABILITA_PERIODO") & " and estado = " & Comilla("ABIERTA") & " order by id desc"
            Dim dt As DataTable = clsGen.selectQuery("SCM", sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return

            Dim idLog As String = dt.Rows(0).Item("id").ToString
            Dim perHab As String = ("" & dt.Rows(0).Item("periodo_habilitado")).Trim
            Dim perReal As String = If(periodoReal Is Nothing, "", periodoReal.Trim)

            If perHab <> "" AndAlso perReal = perHab Then
                ' La orden sigue en el periodo al que se habilito -> realmente ABIERTA
                mHabilitada = True
                If Not IsDBNull(dt.Rows(0).Item("fecha_original")) Then mFechaOriginal = CType(dt.Rows(0).Item("fecha_original"), DateTime)
                mPeriodoOriginal = dt.Rows(0).Item("periodo_original").ToString.Trim
            Else
                ' El periodo real ya no coincide: fue regresada por fuera -> autocorregir el log
                mHabilitada = False
                Dim upd As String = "update scm.dbo.log_actualizacion_oc set estado = 'CERRADA', " & _
                    "observacion = 'Cerrada externamente - detectado al consultar' where id = " & idLog
                Try
                    clsGen.insertQuery("SCM", upd)
                Catch
                End Try
            End If
        Catch
        End Try
    End Sub

    Private Sub ValidarPeriodo(dr As DataRow)
        If IsDBNull(dr.Item("Fecha")) Then
            Me.lbl_estado_periodo.Text = "NO SE PUDO VALIDAR EL PERIODO (FECHA NULL)"
            Me.lbl_estado_periodo.ForeColor = Drawing.Color.DarkOrange
            Me.gb_habilitar.Visible = False
            Me.chk_habilitar_edicion.Enabled = False
            Return
        End If

        Dim fechaDoc As DateTime = CType(dr.Item("Fecha"), DateTime)

        If fechaDoc.Year = Today.Year AndAlso fechaDoc.Month = Today.Month Then
            ' PERIODO ABIERTO
            Me.lbl_estado_periodo.Text = "ORDEN HABILITADA PARA ACTUALIZAR - SE ENCUENTRA EN PERIODO ABIERTO"
            Me.lbl_estado_periodo.ForeColor = Drawing.Color.Green
            Me.chk_habilitar_edicion.Enabled = True

            If mHabilitada Then
                Me.gb_habilitar.Visible = True
                Me.dtp_nueva_fecha.Enabled = False
                Me.btn_habilitar.Enabled = False
                Me.btn_restaurar.Enabled = True
                Me.lbl_periodo_original.Text = "Periodo original capturado -> Fecha " & mFechaOriginal.ToString("yyyy-MM-dd") & "   PeriodoLibro " & mPeriodoOriginal & "   (usar al terminar la actualización)"
            Else
                Me.gb_habilitar.Visible = False
            End If
        Else
            ' PERIODO CERRADO
            Me.lbl_estado_periodo.Text = "ORDEN DESHABILITADA PARA ACTUALIZAR - SE ENCUENTRA EN PERIODO CERRADO"
            Me.lbl_estado_periodo.ForeColor = Drawing.Color.Red
            Me.chk_habilitar_edicion.Enabled = False

            If Not mHabilitada Then
                mFechaOriginal = fechaDoc
                mPeriodoOriginal = ValorCol(dr, "PeriodoLibro")

                If MessageBox.Show("La orden se encuentra en periodo cerrado." & vbCrLf & vbCrLf & "¿Necesita habilitar el periodo?", "Actualización OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Me.gb_habilitar.Visible = True
                    Me.dtp_nueva_fecha.Enabled = True
                    Me.dtp_nueva_fecha.Value = Today
                    Me.btn_habilitar.Enabled = True
                    Me.btn_restaurar.Enabled = False
                    Me.lbl_periodo_calc.Text = "PeriodoLibro " & Today.ToString("yyyyMM")
                    Me.lbl_periodo_original.Text = "Periodo original capturado -> Fecha " & mFechaOriginal.ToString("yyyy-MM-dd") & "   PeriodoLibro " & mPeriodoOriginal
                Else
                    Me.gb_habilitar.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub dtp_nueva_fecha_ValueChanged(sender As Object, e As EventArgs) Handles dtp_nueva_fecha.ValueChanged
        Me.lbl_periodo_calc.Text = "PeriodoLibro " & Me.dtp_nueva_fecha.Value.ToString("yyyyMM")
    End Sub

    Private Sub btn_habilitar_Click(sender As Object, e As EventArgs) Handles btn_habilitar.Click
        Dim f As DateTime = Me.dtp_nueva_fecha.Value.Date
        If f.Year <> Today.Year OrElse f.Month <> Today.Month Then
            MessageBox.Show("La nueva fecha debe estar dentro del periodo abierto (mes actual).", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim msg As String = "Se habilitará la orden " & mNumero & " (" & mTipoDocto & ") de " & mEmpresa & vbCrLf & vbCrLf & _
            "   Fecha         " & f.ToString("yyyy-MM-dd") & vbCrLf & _
            "   PeriodoLibro  " & f.ToString("yyyyMM") & vbCrLf & _
            "   Valoriza      S" & vbCrLf & vbCrLf & _
            "Periodo original capturado -> Fecha " & mFechaOriginal.ToString("yyyy-MM-dd") & ", PeriodoLibro " & mPeriodoOriginal & vbCrLf & vbCrLf & _
            "¿Desea continuar?"
        If MessageBox.Show(msg, "Habilitar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        If ActualizarPeriodo(f, "", False) Then
            mHabilitada = True
            RegistrarLog("Habilita periodo OC (original " & mFechaOriginal.ToString("yyyyMMdd") & "/" & mPeriodoOriginal & " -> " & f.ToString("yyyyMMdd") & "/" & f.ToString("yyyyMM") & ")")
            MessageBox.Show("Periodo habilitado correctamente.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConsultarOrden()
        End If
    End Sub

    Private Sub btn_restaurar_Click(sender As Object, e As EventArgs) Handles btn_restaurar.Click
        If HayCambiosPendientes() Then
            MessageBox.Show("Hay cambios pendientes SIN GUARDAR en el detalle. Guarde o descarte antes de regresar la orden a su periodo original.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim msg As String = "Se regresará la orden " & mNumero & " (" & mTipoDocto & ") de " & mEmpresa & " a su periodo ORIGINAL" & vbCrLf & vbCrLf & _
            "   Fecha         " & mFechaOriginal.ToString("yyyy-MM-dd") & vbCrLf & _
            "   PeriodoLibro  " & mPeriodoOriginal & vbCrLf & _
            "   Valoriza      S" & vbCrLf & vbCrLf & _
            "¿Desea continuar?"
        If MessageBox.Show(msg, "Regresar a Periodo Original", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        If ActualizarPeriodo(mFechaOriginal, mPeriodoOriginal, True) Then
            mHabilitada = False
            RegistrarLog("Regresa OC a periodo original (" & mFechaOriginal.ToString("yyyyMMdd") & "/" & mPeriodoOriginal & ")")
            MessageBox.Show("La orden regresó a su periodo original.", "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConsultarOrden()
        End If
    End Sub

    Private Function ActualizarPeriodo(f As DateTime, periodoLibro As String, esCierre As Boolean) As Boolean
        Dim periodo As String = periodoLibro
        If periodo = "" Then periodo = f.ToString("yyyyMM")
        Dim fecha As String = f.ToString("yyyyMMdd")

        Dim sb As New StringBuilder()
        sb.Append("set xact_abort on begin tran ")
        sb.Append("update flexline.documento set fecha = '" & fecha & "', PeriodoLibro = '" & periodo & "', Valoriza = 'S' ")
        sb.Append("where empresa = '" & mEmpresa & "' and TipoDocto = '" & mTipoDocto & "' and numero = '" & mNumero & "' ")
        sb.Append("update flexline.documentod set fecha = '" & fecha & "' ")
        sb.Append("where empresa = '" & mEmpresa & "' and TipoDocto = '" & mTipoDocto & "' and correlativo = '" & mCorrelativo & "' ")

        ' --- Log en la MISMA transaccion (scm.dbo.log_actualizacion_oc) ---
        If esCierre Then
            sb.Append(LogSql("CIERRA_PERIODO", fOrig:=FSql(mFechaOriginal), pOrig:=Comilla(mPeriodoOriginal), fHab:="'" & fecha & "'", pHab:=Comilla(periodo), estado:=Comilla("CERRADA")))
            ' Marca la habilitacion abierta de esta orden como CERRADA
            sb.Append("update scm.dbo.log_actualizacion_oc set estado = 'CERRADA' ")
            sb.Append("where empresa = " & Comilla(mEmpresa) & " and tipodocto = " & Comilla(mTipoDocto) & " and numero = " & Comilla(mNumero) & " and accion = 'HABILITA_PERIODO' and estado = 'ABIERTA' ")
        Else
            sb.Append(LogSql("HABILITA_PERIODO", fOrig:=FSql(mFechaOriginal), pOrig:=Comilla(mPeriodoOriginal), fHab:="'" & fecha & "'", pHab:=Comilla(periodo), estado:=Comilla("ABIERTA")))
        End If

        sb.Append("commit tran")
        Return EjecutarConReintento(sb.ToString(), If(esCierre, "regresar el periodo", "habilitar el periodo"))
    End Function

    ' ================= HELPERS DE LOG (scm.dbo.log_actualizacion_oc) =================

    ' Arma el INSERT del log. Los parametros ya vienen como LITERAL SQL ('texto', numero o NULL).
    Private Function LogSql(accion As String, Optional linea As String = "NULL", Optional secuencia As String = "NULL", _
                            Optional producto As String = "NULL", Optional campo As String = "NULL", _
                            Optional vAnt As String = "NULL", Optional vNue As String = "NULL", _
                            Optional fOrig As String = "NULL", Optional pOrig As String = "NULL", _
                            Optional fHab As String = "NULL", Optional pHab As String = "NULL", _
                            Optional estado As String = "NULL", Optional obs As String = "NULL") As String
        Return "insert into scm.dbo.log_actualizacion_oc " & _
            "(empresa,tipodocto,numero,correlativo,accion,linea,secuencia,producto,campo,valor_anterior,valor_nuevo," & _
            "fecha_original,periodo_original,fecha_habilitada,periodo_habilitado,estado,usuario,equipo,aplicacion,observacion) values (" & _
            Comilla(mEmpresa) & "," & Comilla(mTipoDocto) & "," & Comilla(mNumero) & "," & CorrSql() & "," & _
            Comilla(accion) & "," & linea & "," & secuencia & "," & producto & "," & campo & "," & vAnt & "," & vNue & "," & _
            fOrig & "," & pOrig & "," & fHab & "," & pHab & "," & estado & "," & _
            Comilla(gs_usuario) & "," & Comilla(Environment.MachineName) & ",'Umbright'," & obs & ") "
    End Function

    ' Correlativo como literal numerico o NULL
    Private Function CorrSql() As String
        If mCorrelativo Is Nothing OrElse mCorrelativo.Trim = "" OrElse Not IsNumeric(mCorrelativo) Then Return "NULL"
        Return CInt(mCorrelativo).ToString
    End Function

    ' Fecha como literal 'yyyymmdd' o NULL
    Private Function FSql(f As DateTime) As String
        If f.Year <= 1 Then Return "NULL"
        Return "'" & f.ToString("yyyyMMdd") & "'"
    End Function

    ' Valor de una columna en una version (Original / Current) como texto plano
    Private Function ValorVer(dr As DataRow, campo As String, ver As DataRowVersion) As String
        Try
            If Not dr.Table.Columns.Contains(campo) Then Return ""
            Dim v As Object = dr.Item(campo, ver)
            If IsDBNull(v) Then Return ""
            If TypeOf v Is DateTime Then Return CType(v, DateTime).ToString("yyyy-MM-dd")
            Return v.ToString.Trim
        Catch
        End Try
        Return ""
    End Function

    ' Registra en el log (sb) cada campo editable que cambio en una linea modificada
    Private Sub LogCamposModificados(sb As StringBuilder, dr As DataRow)
        Dim lin As String = CInt(ADouble(dr.Item("Linea"))).ToString
        Dim sec As String = CInt(ADouble(dr.Item("Secuencia"))).ToString
        Dim prod As String = dr.Item("Producto").ToString.Trim
        For Each campo As String In COLS_EDITABLES
            Dim ant As String = ValorVer(dr, campo, DataRowVersion.Original)
            Dim act As String = ValorVer(dr, campo, DataRowVersion.Current)
            If ant <> act Then
                sb.Append(LogSql("MODIFICA_LINEA", linea:=lin, secuencia:=sec, producto:=Comilla(prod), campo:=Comilla(campo), vAnt:=Comilla(ant), vNue:=Comilla(act)))
            End If
        Next
    End Sub

    ' Ejecuta una transaccion; si SQL reporta interbloqueo (deadlock) reintenta hasta 3 veces
    Private Function EjecutarConReintento(sql As String, accion As String) As Boolean
        Dim intentos As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        Try
            Do
                intentos = intentos + 1
                Dim otrans As New Transaccional.Conexion(CONEXION)
                Try
                    otrans.open()
                    otrans.Actualiza(sql)
                    If otrans.Codigo_error = 0 Then Return True
                    Dim msg As String = "" & otrans.descripcion_error
                    If EsDeadlock(msg) AndAlso intentos < 3 Then
                        System.Threading.Thread.Sleep(700)
                        Continue Do
                    End If
                    MessageBox.Show("No se pudo " & accion & "." & vbCrLf & vbCrLf & msg, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Finally
                    otrans.close()
                    otrans = Nothing
                End Try
            Loop
        Catch ex As Exception
            MessageBox.Show("Error al " & accion & "." & vbCrLf & ex.Message, "Actualización OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    ' Detecta si el error es un interbloqueo (deadlock) de SQL Server (1205)
    Private Function EsDeadlock(msg As String) As Boolean
        If msg Is Nothing Then Return False
        Dim m As String = msg.ToLower()
        If m.Contains("interbloqueo") Then Return True
        If m.Contains("deadlock") Then Return True
        If m.Contains("1205") Then Return True
        If m.Contains("sujeto del") Then Return True
        Return False
    End Function

    Private Sub RegistrarLog(actividad As String)
        Try
            Dim otrans As New Transaccional.Conexion(CONEXION)
            otrans.open()
            otrans.Ingresa("pa_ins_um_gen_log_documento '" & mEmpresa & "','" & mTipoDocto & "','" & mNumero & "','" & gs_usuario & "','NULL','" & actividad & "'")
            otrans.close()
            otrans = Nothing
        Catch
        End Try
    End Sub

    ' ================= CABECERA =================

    Private Sub MostrarCabecera(dr As DataRow)
        Me.txt_h_empresa.Text = ValorCol(dr, "Empresa")
        Me.txt_h_tipodocto.Text = ValorCol(dr, "TipoDocto")
        Me.txt_h_numero.Text = ValorCol(dr, "Numero")
        Me.txt_h_correlativo.Text = ValorCol(dr, "Correlativo")
        Me.txt_h_proveedor.Text = ValorCol(dr, "Proveedor")
        Me.txt_h_moneda.Text = ValorCol(dr, "Moneda")
        Me.txt_h_vigencia.Text = ValorCol(dr, "Vigencia")
        Me.txt_h_emitido.Text = ValorCol(dr, "Emitido")
        Me.txt_h_valoriza.Text = ValorCol(dr, "Valoriza")
        Me.txt_h_aprobacion.Text = ValorCol(dr, "Aprobacion")
        Me.txt_h_usuariomodif.Text = ValorCol(dr, "UsuarioModif")
        Me.txt_h_periodolibro.Text = ValorCol(dr, "PeriodoLibro")
        Me.txt_h_fecha.Text = ValorCol(dr, "Fecha")
        Me.txt_h_fechavcto.Text = ValorCol(dr, "FechaVcto")
        Me.txt_h_fechacomprobante.Text = ValorCol(dr, "FechaComprobante")
        Me.txt_h_fechaestado.Text = ValorCol(dr, "FechaEstado")
        Me.txt_h_fechamodif.Text = ValorCol(dr, "FechaModif")
        Me.txt_h_fechaumodif.Text = ValorCol(dr, "FechaUModif")
        Me.txt_h_fechacierre.Text = ValorCol(dr, "FechaCierre")
        Me.txt_h_fechaaprueba.Text = ValorCol(dr, "FechaAprueba")
        Me.txt_h_neto.Text = ValorCol(dr, "Neto")
        Me.txt_h_subtotal.Text = ValorCol(dr, "SubTotal")
        Me.txt_h_total.Text = ValorCol(dr, "Total")
        Me.txt_h_netoingreso.Text = ValorCol(dr, "NetoIngreso")
        Me.txt_h_subtotalingreso.Text = ValorCol(dr, "SubTotalIngreso")
        Me.txt_h_totalingreso.Text = ValorCol(dr, "TotalIngreso")
    End Sub

    Private Function ValorCol(dr As DataRow, col As String) As String
        Try
            If Not dr.Table.Columns.Contains(col) Then Return ""
            If IsDBNull(dr.Item(col)) Then Return "NULL"
            If TypeOf dr.Item(col) Is DateTime Then
                Return CType(dr.Item(col), DateTime).ToString("yyyy-MM-dd HH:mm:ss.fff")
            End If
            Return dr.Item(col).ToString.Trim
        Catch
        End Try
        Return ""
    End Function

    Private Sub LimpiarResultado()
        Me.txt_h_empresa.Clear()
        Me.txt_h_tipodocto.Clear()
        Me.txt_h_numero.Clear()
        Me.txt_h_correlativo.Clear()
        Me.txt_h_proveedor.Clear()
        Me.txt_h_moneda.Clear()
        Me.txt_h_vigencia.Clear()
        Me.txt_h_emitido.Clear()
        Me.txt_h_valoriza.Clear()
        Me.txt_h_aprobacion.Clear()
        Me.txt_h_usuariomodif.Clear()
        Me.txt_h_periodolibro.Clear()
        Me.txt_h_fecha.Clear()
        Me.txt_h_fechavcto.Clear()
        Me.txt_h_fechacomprobante.Clear()
        Me.txt_h_fechaestado.Clear()
        Me.txt_h_fechamodif.Clear()
        Me.txt_h_fechaumodif.Clear()
        Me.txt_h_fechacierre.Clear()
        Me.txt_h_fechaaprueba.Clear()
        Me.txt_h_neto.Clear()
        Me.txt_h_subtotal.Clear()
        Me.txt_h_total.Clear()
        Me.txt_h_netoingreso.Clear()
        Me.txt_h_subtotalingreso.Clear()
        Me.txt_h_totalingreso.Clear()
        mCargando = True
        Me.dgv_detalle.DataSource = Nothing
        mCargando = False
        Me.lbl_lineas.Text = "Líneas: 0"
        Me.lbl_estado_periodo.Text = ""
        Me.gb_habilitar.Visible = False
        Me.chk_habilitar_edicion.Checked = False
        Me.chk_habilitar_edicion.Enabled = False
        Me.btn_agregar.Enabled = False
        Me.btn_eliminar.Enabled = False
        Me.btn_descartar.Enabled = False
        Me.btn_guardar.Enabled = False
        Me.lbl_cambios.Text = "Cambios pendientes: 0 modificadas, 0 nuevas, 0 eliminadas"
        mDtDet = Nothing
        mEmpresa = ""
        mTipoDocto = ""
        mNumero = ""
        mCorrelativo = ""
        mClave = ""
        mParidad = 1
        mPeriodoOriginal = ""
        mHabilitada = False
    End Sub

    Private Sub frm_actualizacion_oc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If HayCambiosPendientes() Then
            If MessageBox.Show("Hay cambios pendientes SIN GUARDAR en el detalle. ¿Desea salir y perderlos?", "Actualización OC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                e.Cancel = True
                Return
            End If
        End If
        If mHabilitada Then
            Dim r As DialogResult = MessageBox.Show("ATENCIÓN: la orden " & mNumero & " sigue con el periodo HABILITADO." & vbCrLf & _
                "Periodo original -> Fecha " & mFechaOriginal.ToString("yyyy-MM-dd") & ", PeriodoLibro " & mPeriodoOriginal & vbCrLf & vbCrLf & _
                "¿Desea salir de todos modos sin regresarla a su periodo original?", "Actualización OC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If r = DialogResult.No Then e.Cancel = True
        End If
    End Sub

End Class


' ===================================================================
' Columna de calendario para el DataGridView (fechas con DateTimePicker)
' ===================================================================
Public Class CalendarColumn
    Inherits DataGridViewColumn
    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub
    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(value As DataGridViewCell)
            If value IsNot Nothing AndAlso Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) Then
                Throw New InvalidCastException("La celda debe ser CalendarCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell
    Public Sub New()
        Me.Style.Format = "yyyy-MM-dd"
    End Sub
    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As CalendarEditingControl = CType(Me.DataGridView.EditingControl, CalendarEditingControl)
        Dim f As DateTime
        If Me.Value Is Nothing OrElse IsDBNull(Me.Value) OrElse Not DateTime.TryParse(Me.Value.ToString(), f) Then
            f = DateTime.Now
        End If
        If f < New DateTime(1900, 1, 1) Then f = New DateTime(1900, 1, 1)
        ctl.Value = f
    End Sub
    Public Overrides ReadOnly Property EditType As Type
        Get
            Return GetType(CalendarEditingControl)
        End Get
    End Property
    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(DateTime)
        End Get
    End Property
    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Return DateTime.Now
        End Get
    End Property
End Class

Public Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl
    Private dgvControl As DataGridView
    Private valueChangedField As Boolean
    Private rowIndexField As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "yyyy-MM-dd"
    End Sub

    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToString("yyyy-MM-dd")
        End Get
        Set(value As Object)
            Dim f As DateTime
            If value IsNot Nothing AndAlso DateTime.TryParse(value.ToString(), f) Then Me.Value = f
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Value.ToString("yyyy-MM-dd")
    End Function

    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub

    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexField
        End Get
        Set(value As Integer)
            rowIndexField = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(key As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case (key And Keys.KeyCode)
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.[End], Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dgvControl
        End Get
        Set(value As DataGridView)
            dgvControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueChangedField
        End Get
        Set(value As Boolean)
            valueChangedField = value
        End Set
    End Property

    Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(eventargs As EventArgs)
        valueChangedField = True
        If Me.dgvControl IsNot Nothing Then Me.dgvControl.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class
