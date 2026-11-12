Imports System.Data
Imports System.Windows.Forms

Public Class frm_anulacion_oc

    ' Anulacion / OnHold de Ordenes de Compra (Compras/Import).
    '   Cabecera -> flexline.documento (clave Empresa + TipoDocto + Numero)
    ' Vigencia='A' representa dos estados posibles, distinguidos por el prefijo
    ' guardado en Comentario1: 'ANULAR: <motivo>' (definitivo) u 'ONHOLD: <motivo>'
    ' (reversible, regresa a Vigencia='S').

    Private Const CONEXION As String = "FlexLine"
    Private Const OPCION_PERMISO As String = "mci_anular_oc"

    Private mEmpresa As String = ""
    Private mTipoDocto As String = ""
    Private mNumero As String = ""
    Private mEstadoActual As String = ""
    Private mPuedeAnular As Boolean = False
    Private mPuedeReversar As Boolean = False
    Private mConsultado As Boolean = False

    Private Sub frm_anulacion_oc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResaltarTitulos()
        LimpiarResultado()
        LlenarEmpresas()
    End Sub

    ' Pone en negrilla solo el titulo de los groupbox (no su contenido)
    Private Sub ResaltarTitulos()
        Dim negrita As New System.Drawing.Font(Me.gb_documento.Font, System.Drawing.FontStyle.Bold)
        Dim normal As New System.Drawing.Font(Me.gb_documento.Font, System.Drawing.FontStyle.Regular)
        For Each gb As GroupBox In New GroupBox() {Me.gb_busqueda, Me.gb_documento, Me.gb_accion}
            gb.Font = negrita
            For Each ctl As Control In gb.Controls
                ctl.Font = normal
            Next
        Next
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
            MessageBox.Show("No se pudieron cargar las empresas." & vbCrLf & ex.Message, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        LlenarTiposDocto()
    End Sub

    Private Sub LlenarTiposDocto()
        Try
            Dim empresa As String = Me.cmb_empresa.Text.Trim
            If empresa = "" Then Return
            Dim clsGen As New ClasesGenerales.General
            Dim ls As String = "select TipoDocto from flexline.tipodocumento " & _
                "where empresa = '" & empresa.Replace("'", "''") & "' " & _
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
            MessageBox.Show("No se pudieron cargar los tipos de documento." & vbCrLf & ex.Message, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedIndexChanged
        LlenarTiposDocto()
    End Sub

    ' ================= BUSQUEDA / CONSULTA =================

    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            ConsultarDocumento()
        ElseIf Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        ConsultarDocumento()
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        Me.txt_numero.Text = ""
        Me.txt_motivo.Text = ""
        LimpiarResultado()
        Me.txt_numero.Focus()
    End Sub

    Private Sub ConsultarDocumento()
        Dim empresa As String = Me.cmb_empresa.Text.Trim
        Dim tipo As String = Me.cmb_tipodocto.Text.Trim
        Dim numero As String = Me.txt_numero.Text.Trim

        If empresa = "" OrElse tipo = "" Then
            MessageBox.Show("Seleccione la empresa y el tipo de documento.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If numero = "" OrElse Not IsNumeric(numero) Then
            MessageBox.Show("Digite el numero de la orden (solo numeros).", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_numero.Focus()
            Return
        End If

        numero = numero.PadLeft(10, "0"c)
        Me.txt_numero.Text = numero

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dt As DataTable = Nothing
            Dim otrans As New Transaccional.Conexion(CONEXION)
            Try
                otrans.open()
                Dim sql As String = "pa_sel_um_documento_anular " & Comilla(empresa) & "," & Comilla(tipo) & "," & Comilla(numero)
                dt = otrans.Obtiene(sql)
                If otrans.Codigo_error <> 0 Then
                    MessageBox.Show("Error al consultar la orden." & vbCrLf & otrans.descripcion_error, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Finally
                otrans.close()
                otrans = Nothing
            End Try

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                LimpiarResultado()
                MessageBox.Show("No se encontro la orden " & numero & " (" & tipo & ") en la empresa " & empresa & ".", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            MostrarDocumento(dt.Rows(0))
        Catch ex As Exception
            MessageBox.Show("Error al consultar la orden." & vbCrLf & ex.Message, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ================= MOSTRAR / LIMPIAR =================

    Private Sub MostrarDocumento(dr As DataRow)
        mEmpresa = ValorCol(dr, "Empresa")
        mTipoDocto = ValorCol(dr, "TipoDocto")
        mNumero = ValorCol(dr, "Numero")
        mEstadoActual = ValorCol(dr, "EstadoActual")
        mPuedeAnular = (ValorCol(dr, "PuedeAnular") = "1")
        mPuedeReversar = (ValorCol(dr, "PuedeReversar") = "1")
        mConsultado = True

        Me.txt_h_empresa.Text = mEmpresa
        Me.txt_h_tipodocto.Text = mTipoDocto
        Me.txt_h_numero.Text = mNumero
        Me.txt_h_proveedor.Text = ValorCol(dr, "Proveedor")
        Me.txt_h_fecha.Text = ValorCol(dr, "Fecha")
        Me.txt_h_total.Text = ValorCol(dr, "Total")
        Me.txt_h_vigencia.Text = ValorCol(dr, "Vigencia")
        Me.txt_h_porcentajeasignado.Text = ValorCol(dr, "PorcentajeAsignado")
        Me.txt_h_comentario1.Text = ValorCol(dr, "Comentario1")
        Me.txt_h_estadoactual.Text = mEstadoActual

        Select Case mEstadoActual
            Case "VIGENTE"
                If mPuedeAnular Then
                    Me.lbl_estado.Text = "SE PUEDE ANULAR O DEJAR EN ONHOLD"
                    Me.lbl_estado.ForeColor = Drawing.Color.Green
                Else
                    Me.lbl_estado.Text = ValorCol(dr, "MotivoNoAnula")
                    Me.lbl_estado.ForeColor = Drawing.Color.Red
                End If
            Case "ONHOLD"
                Me.lbl_estado.Text = "DOCUMENTO EN ONHOLD"
                Me.lbl_estado.ForeColor = Drawing.Color.DarkOrange
            Case "ANULADO"
                Me.lbl_estado.Text = "DOCUMENTO ANULADO (definitivo, sin reversion)"
                Me.lbl_estado.ForeColor = Drawing.Color.Red
            Case Else
                Me.lbl_estado.Text = ValorCol(dr, "MotivoNoAnula")
                Me.lbl_estado.ForeColor = Drawing.Color.Red
        End Select

        Me.pnl_radios.Visible = mPuedeAnular
        If mPuedeAnular Then Me.rbn_anular.Checked = True

        Me.btn_procesar.Visible = mPuedeAnular
        Me.btn_procesar.Enabled = mPuedeAnular

        Me.btn_reversar.Visible = mPuedeReversar
        Me.btn_reversar.Enabled = mPuedeReversar

        Me.gb_accion.Visible = mPuedeAnular OrElse mPuedeReversar
        Me.txt_motivo.Enabled = mPuedeAnular OrElse mPuedeReversar
        Me.txt_motivo.Text = ""
    End Sub

    Private Sub LimpiarResultado()
        Me.txt_h_empresa.Clear()
        Me.txt_h_tipodocto.Clear()
        Me.txt_h_numero.Clear()
        Me.txt_h_proveedor.Clear()
        Me.txt_h_fecha.Clear()
        Me.txt_h_total.Clear()
        Me.txt_h_vigencia.Clear()
        Me.txt_h_porcentajeasignado.Clear()
        Me.txt_h_comentario1.Clear()
        Me.txt_h_estadoactual.Clear()
        Me.lbl_estado.Text = ""
        Me.gb_accion.Visible = False
        Me.pnl_radios.Visible = False
        Me.btn_procesar.Visible = False
        Me.btn_procesar.Enabled = False
        Me.btn_reversar.Visible = False
        Me.btn_reversar.Enabled = False
        mEmpresa = "" : mTipoDocto = "" : mNumero = "" : mEstadoActual = ""
        mPuedeAnular = False : mPuedeReversar = False : mConsultado = False
    End Sub

    ' ================= PROCESAR (ANULAR / ONHOLD) =================

    Private Sub btn_procesar_Click(sender As Object, e As EventArgs) Handles btn_procesar.Click
        If Not mConsultado OrElse Not mPuedeAnular Then
            MessageBox.Show("Consulte primero una orden que se pueda anular o dejar en onhold.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not tiene_permisos(OPCION_PERMISO) Then
            MessageBox.Show("No tiene permisos para anular o dejar en onhold ordenes de compra.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim motivo As String = Me.txt_motivo.Text.Trim
        If motivo.Length < 10 Then
            MessageBox.Show("Digite un motivo de al menos 10 caracteres.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_motivo.Focus()
            Return
        End If

        Dim accion As String = If(Me.rbn_onhold.Checked, "ONHOLD", "ANULAR")
        Dim verbo As String = If(accion = "ONHOLD", "dejar en ONHOLD", "ANULAR")

        If MessageBox.Show("Esta seguro de " & verbo & " la orden " & mNumero & " (" & mTipoDocto & ") de " & mEmpresa & "?", "Anulacion OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim sql As String = "pa_upd_um_documento_anular " & Comilla(mEmpresa) & "," & Comilla(mTipoDocto) & "," & Comilla(mNumero) & "," & Comilla(accion) & "," & Comilla(motivo) & "," & Comilla(gs_usuario)

        Dim dtResultado As DataTable = Nothing
        If Not EjecutarConReintento(sql, "procesar la orden", dtResultado) Then Return
        If Not MostrarResultadoProceso(dtResultado) Then Return

        ConsultarDocumento()
    End Sub

    ' ================= REVERSAR ONHOLD =================

    Private Sub btn_reversar_Click(sender As Object, e As EventArgs) Handles btn_reversar.Click
        If Not mConsultado OrElse Not mPuedeReversar Then
            MessageBox.Show("Solo se puede reversar un documento que este en ONHOLD.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not tiene_permisos(OPCION_PERMISO) Then
            MessageBox.Show("No tiene permisos para reversar el onhold de ordenes de compra.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim motivo As String = Me.txt_motivo.Text.Trim
        If motivo.Length < 10 Then
            MessageBox.Show("Digite el motivo de la reactivacion (minimo 10 caracteres).", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_motivo.Focus()
            Return
        End If

        If MessageBox.Show("Esta seguro de reversar el ONHOLD de la orden " & mNumero & " (" & mTipoDocto & ") de " & mEmpresa & "? Quedara Vigencia = S.", "Anulacion OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim sql As String = "pa_upd_um_documento_reversar_onhold " & Comilla(mEmpresa) & "," & Comilla(mTipoDocto) & "," & Comilla(mNumero) & "," & Comilla(motivo) & "," & Comilla(gs_usuario)

        Dim dtResultado As DataTable = Nothing
        If Not EjecutarConReintento(sql, "reversar el onhold", dtResultado) Then Return
        If Not MostrarResultadoProceso(dtResultado) Then Return

        ConsultarDocumento()
    End Sub

    ' Interpreta el resultado (Resultado, Mensaje) devuelto por los SP de escritura.
    ' Devuelve True si el proceso fue exitoso (Resultado = 1).
    Private Function MostrarResultadoProceso(dtResultado As DataTable) As Boolean
        If dtResultado Is Nothing OrElse dtResultado.Rows.Count = 0 Then
            MessageBox.Show("No se obtuvo respuesta del proceso.", "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim resultado As Integer = CInt(ADouble(dtResultado.Rows(0).Item("Resultado")))
        Dim mensaje As String = dtResultado.Rows(0).Item("Mensaje").ToString

        If resultado = 1 Then
            MessageBox.Show(mensaje, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            MessageBox.Show(mensaje, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function

    ' ================= HELPERS =================

    ' Envuelve texto entre comillas simples para SQL
    Private Function Comilla(s As String) As String
        If s Is Nothing Then Return "NULL"
        Return "'" & s.Replace("'", "''") & "'"
    End Function

    Private Function ValorCol(dr As DataRow, col As String) As String
        Try
            If Not dr.Table.Columns.Contains(col) Then Return ""
            If IsDBNull(dr.Item(col)) Then Return ""
            If TypeOf dr.Item(col) Is DateTime Then
                Return CType(dr.Item(col), DateTime).ToString("yyyy-MM-dd")
            End If
            Return dr.Item(col).ToString.Trim
        Catch
        End Try
        Return ""
    End Function

    Private Function ADouble(v As Object) As Double
        If v Is Nothing OrElse IsDBNull(v) Then Return 0
        Try
            Return Convert.ToDouble(v)
        Catch
            Return 0
        End Try
    End Function

    ' Ejecuta un SP que devuelve un SELECT (Resultado, Mensaje), con reintento ante deadlock
    Private Function EjecutarConReintento(sql As String, accion As String, ByRef dtResultado As DataTable) As Boolean
        Dim intentos As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        Try
            Do
                intentos = intentos + 1
                Dim otrans As New Transaccional.Conexion(CONEXION)
                Try
                    otrans.open()
                    dtResultado = otrans.Obtiene(sql)
                    If otrans.Codigo_error = 0 Then Return True
                    Dim msg As String = "" & otrans.descripcion_error
                    If EsDeadlock(msg) AndAlso intentos < 3 Then
                        System.Threading.Thread.Sleep(700)
                        Continue Do
                    End If
                    MessageBox.Show("No se pudo " & accion & "." & vbCrLf & vbCrLf & msg, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Finally
                    otrans.close()
                    otrans = Nothing
                End Try
            Loop
        Catch ex As Exception
            MessageBox.Show("Error al " & accion & "." & vbCrLf & ex.Message, "Anulacion OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

End Class
