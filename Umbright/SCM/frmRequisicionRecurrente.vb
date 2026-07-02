Public Class frmRequisicionRecurrente

    Public modoEdicion As Boolean = False
    Public idRecurrente As Integer = 0
    Public oDS As DataSet   ' expuesto para que frmRequisiciones lea notificaciones

    ' Valores precargados desde frmRequisiciones (se aplican en Load tras llenar combos)
    Private _preProveedor As String = ""
    Private _preNombreProveedor As String = ""
    Private _preMoneda As String = ""
    Private _preObservaciones As String = ""

    ' =========================================================================
    ' INICIALIZACIÓN
    ' =========================================================================

    Private Sub crearEstructura()
        oDS = New DataSet

        Dim dt As DataTable = New DataTable("notificaciones")
        dt.Columns.Add(New DataColumn("usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        oDS.Tables.Add(dt)

        Me.dgvNotificaciones.DataSource = oDS.Tables("notificaciones")
    End Sub

    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            Dim dt As DataTable = Otrans.Obtiene("bdflexline.flexline.pa_sel_um_gen_tabcod null,'GEN_MONEDA','UMBRAL'")
            Me.cmbMoneda.Items.Clear()
            For Each dr As DataRow In dt.Rows
                Me.cmbMoneda.Items.Add(dr.Item("CODIGO").ToString)
            Next
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Me.cmbFrecuencia.Items.Clear()
        Me.cmbFrecuencia.Items.AddRange(New String() {"MENSUAL", "BIMESTRAL", "TRIMESTRAL", "SEMESTRAL", "ANUAL"})
    End Sub

    Private Sub frmRequisicionRecurrente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()

        Me.dtpFechaInicio.Value = Today
        Me.dtpFechaVencRecurrencia.Value = Today.AddYears(1)
        Me.dtpFechaVencLicencia.Value = Today.AddYears(1)
        Me.nudDiaFactura.Value = 1
        Me.nudDiasAnticipacion.Value = 5
        Me.chkVencLicencia.Checked = False
        Me.dtpFechaVencLicencia.Enabled = False

        If Not modoEdicion Then aplicarPrecarga()

        If modoEdicion Then
            Me.Text = "Editar Plantilla Recurrente"
            Me.txtCodigo.ReadOnly = True  ' el código no se cambia en edición
            cargarDatos()
        Else
            Me.Text = "Nueva Plantilla Recurrente"
        End If
    End Sub

    ' Llamado desde frmRequisiciones ANTES de ShowDialog — solo almacena, aplica en Load
    Public Sub precargarDatos(ByVal sProveedor As String, ByVal sNombreProveedor As String,
                               ByVal sMoneda As String, ByVal sObservaciones As String)
        _preProveedor = sProveedor
        _preNombreProveedor = sNombreProveedor
        _preMoneda = sMoneda
        _preObservaciones = sObservaciones
    End Sub

    Private Sub aplicarPrecarga()
        Me.txtProveedor.Text = _preProveedor
        Me.txtNombreProveedor.Text = _preNombreProveedor
        Me.txtObservaciones.Text = _preObservaciones
        If _preMoneda.Length > 0 Then
            Dim idx As Integer = Me.cmbMoneda.Items.IndexOf(_preMoneda)
            If idx >= 0 Then Me.cmbMoneda.SelectedIndex = idx
        End If
    End Sub

    ' =========================================================================
    ' CARGA DE DATOS (modo edición)
    ' =========================================================================

    Private Sub cargarDatos()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            Dim dt As DataTable = Otrans.Obtiene("pa_sel_um_requisicion_recurrenteId " & idRecurrente)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub
            Dim dr As DataRow = dt.Rows(0)

            Me.txtCodigo.Text = dr.Item("codigo").ToString
            Me.txtDescripcion.Text = dr.Item("descripcion").ToString
            Me.txtProveedor.Text = dr.Item("proveedor").ToString
            Me.txtObservaciones.Text = dr.Item("observaciones").ToString
            Try : Me.cmbMoneda.SelectedItem = dr.Item("moneda").ToString : Catch ex As Exception : End Try
            Try : Me.dtpFechaInicio.Value = CDate(dr.Item("fecha_inicio")) : Catch ex As Exception : End Try
            Try : Me.dtpFechaVencRecurrencia.Value = CDate(dr.Item("fecha_venc_recurrencia")) : Catch ex As Exception : End Try
            Try : Me.cmbFrecuencia.SelectedItem = dr.Item("frecuencia").ToString : Catch ex As Exception : End Try
            Try : Me.nudDiaFactura.Value = CDec(dr.Item("dia_factura_mes")) : Catch ex As Exception : End Try
            Try : Me.nudDiasAnticipacion.Value = CDec(dr.Item("dias_anticipacion")) : Catch ex As Exception : End Try

            Me.txtUsuarioResponsable.Text = dr.Item("usuario_responsable").ToString
            Me.txtNombreResponsable.Text = dr.Item("nombre_responsable").ToString

            Dim tieneVencLic As Boolean = Not IsDBNull(dr.Item("fecha_venc_licencia"))
            Me.chkVencLicencia.Checked = tieneVencLic
            Me.dtpFechaVencLicencia.Enabled = tieneVencLic
            If tieneVencLic Then
                Try : Me.dtpFechaVencLicencia.Value = CDate(dr.Item("fecha_venc_licencia")) : Catch ex As Exception : End Try
            End If

            ' Notificaciones
            Dim sNotif As String = dr.Item("usuarios_notificar").ToString
            If sNotif.Length > 0 Then
                cargarNotificaciones(Otrans, sNotif)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar plantilla: " & ex.Message, "Recurrentes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub cargarNotificaciones(ByVal Otrans As Transaccional.Conexion, ByVal sLista As String)
        Try
            Dim dt As DataTable = Otrans.Obtiene("pa_sel_um_sg_usuario_todos")
            For Each sUsuario As String In sLista.Split(",")
                sUsuario = sUsuario.Trim
                If sUsuario.Length = 0 Then Continue For
                Dim encontrado As DataRow() = dt.Select("usuario = '" & sUsuario & "'")
                If encontrado.Length > 0 Then
                    Dim drAux As DataRow = oDS.Tables("notificaciones").NewRow
                    drAux.Item("usuario") = sUsuario
                    drAux.Item("nombre") = encontrado(0).Item("nombre").ToString
                    oDS.Tables("notificaciones").Rows.Add(drAux)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    ' =========================================================================
    ' EVENTOS
    ' =========================================================================

    Private Sub chkVencLicencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkVencLicencia.CheckedChanged
        Me.dtpFechaVencLicencia.Enabled = Me.chkVencLicencia.Checked
    End Sub

    Private Sub btnBuscarResponsable_Click(sender As Object, e As EventArgs) Handles btnBuscarResponsable.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()
            Dim dt As DataTable = Otrans.Obtiene("pa_sel_um_sg_usuario_todos")
            Dim clsSel As New ClasesGenerales.Seleccionar_Opcion
            clsSel.pdt = dt
            clsSel._DisplayMember = "nombre"
            clsSel._ValueMember = "usuario"
            clsSel.Obtener_Seleccion()

            If clsSel._SelectedValue.Length > 0 Then
                Me.txtUsuarioResponsable.Text = clsSel._SelectedValue
                Dim encontrado As DataRow() = dt.Select("usuario = '" & clsSel._SelectedValue & "'")
                If encontrado.Length > 0 Then
                    Me.txtNombreResponsable.Text = encontrado(0).Item("nombre").ToString
                End If
            End If
            clsSel = Nothing
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btnAgregarNotificacion_Click(sender As Object, e As EventArgs) Handles btnAgregarNotificacion.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()
            Dim dt As DataTable = Otrans.Obtiene("pa_sel_um_sg_usuario_todos")
            Dim clsSel As New ClasesGenerales.Seleccionar_Opcion
            clsSel.pdt = dt
            clsSel._DisplayMember = "nombre"
            clsSel._ValueMember = "usuario"
            clsSel.Obtener_Seleccion()

            If clsSel._SelectedValue.Length > 0 Then
                Dim existente As DataRow() = oDS.Tables("notificaciones").Select("usuario = '" & clsSel._SelectedValue & "'")
                If existente.Length > 0 Then
                    MessageBox.Show("El usuario ya está en la lista.", "Notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim encontrado As DataRow() = dt.Select("usuario = '" & clsSel._SelectedValue & "'")
                If encontrado.Length > 0 Then
                    Dim drAux As DataRow = oDS.Tables("notificaciones").NewRow
                    drAux.Item("usuario") = clsSel._SelectedValue
                    drAux.Item("nombre") = encontrado(0).Item("nombre").ToString
                    oDS.Tables("notificaciones").Rows.Add(drAux)
                End If
            End If
            clsSel = Nothing
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btnQuitarNotificacion_Click(sender As Object, e As EventArgs) Handles btnQuitarNotificacion.Click
        Try
            If Me.dgvNotificaciones.CurrentRow Is Nothing Then Exit Sub
            oDS.Tables("notificaciones").Rows(Me.dgvNotificaciones.CurrentRow.Index).Delete()
        Catch ex As Exception
        End Try
    End Sub

    ' =========================================================================
    ' GUARDAR (modo edición únicamente — creación la maneja frmRequisiciones)
    ' =========================================================================

    Private Function validar() As Boolean
        If Me.txtCodigo.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar un código para la plantilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtCodigo.Focus() : Return False
        End If
        If Me.txtDescripcion.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar una descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtDescripcion.Focus() : Return False
        End If
        If Me.cmbFrecuencia.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar la frecuencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbFrecuencia.Focus() : Return False
        End If
        If Me.txtUsuarioResponsable.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe seleccionar el usuario responsable.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Me.dtpFechaVencRecurrencia.Value.Date <= Me.dtpFechaInicio.Value.Date Then
            MessageBox.Show("La fecha de vencimiento debe ser posterior a la fecha de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not validar() Then Exit Sub

        If modoEdicion Then
            ' Solo UPDATE del header en modo edición
            Dim Otrans As New Transaccional.Conexion("SCM")
            Try
                Otrans.open()

                Dim sFechaVencLic As String = "null"
                If Me.chkVencLicencia.Checked Then
                    sFechaVencLic = "'" & Me.dtpFechaVencLicencia.Value.ToString("yyyyMMdd") & "'"
                End If

                Dim sNotificar As String = String.Empty
                For Each dr As DataRow In oDS.Tables("notificaciones").Rows
                    If sNotificar.Length > 0 Then sNotificar &= ","
                    sNotificar &= dr.Item("usuario").ToString
                Next

                Dim lsSQL As String = "pa_upd_um_requisicion_recurrente " &
                    idRecurrente & "," &
                    "'" & Me.txtDescripcion.Text.Trim & "'," &
                    "'" & Me.txtProveedor.Text.Trim & "'," &
                    "'" & Me.cmbMoneda.SelectedItem.ToString & "'," &
                    "'" & Me.txtObservaciones.Text.Trim & "'," &
                    sFechaVencLic & "," &
                    "'" & Me.dtpFechaVencRecurrencia.Value.ToString("yyyyMMdd") & "'," &
                    Me.nudDiaFactura.Value.ToString & "," &
                    "'" & Me.cmbFrecuencia.SelectedItem.ToString & "'," &
                    Me.nudDiasAnticipacion.Value.ToString & "," &
                    "'" & Me.txtUsuarioResponsable.Text.Trim & "'," &
                    "'" & sNotificar & "'," &
                    "'" & gs_usuario & "'"

                Otrans.Ingresa(lsSQL)
                MessageBox.Show("Plantilla actualizada correctamente.", "Recurrentes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error al guardar: " & ex.Message, "Recurrentes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Otrans.close()
                Otrans = Nothing
            End Try
        Else
            ' Modo creación: retornar OK para que frmRequisiciones procese los datos
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
