Public Class frm_ws_control_entregas

 

    Private Sub buscarSocio()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Try

            Dim oform As New frm_busqueda_general
            oform.nombre_vista = "ws_socio_club"
            oform.lista_campos = "cod_socio,ctacte,nombre_socio"
            oform.parametros = "ctacte,nombre_socio"
            oform.conectar = "scm"
            oform.hacer_busqueda_vista("scm")
            oform.ShowDialog()
            Me.txtSocio.Text = oform.resultado

            dt = clsGen.selectQuery("SCM", "pa_var_um_ws_socio " & Me.txtSocio.Text)
            If dt.Rows.Count > 0 Then
                Me.txtNombreSocio.Text = dt.Rows(0).Item("nombre_socio").ToString
            End If



            Me.txtSocio.ReadOnly = True
            Me.btnBuscar.Enabled = False
            oform = Nothing
            oform.Dispose()
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub llenarCombo()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General


        Try
            lsSQL = "scm.flexline.pa_sel_um_ws_club"
            dt = clsgen.selectQuery("SCM", lsSQL)
            Me.cmbClub.DataSource = dt
            Me.cmbClub.ValueMember = "cod_club"
            Me.cmbClub.DisplayMember = "descripcion"
        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try

    End Sub

    Private Sub grabarEntrega()
        Dim lsSQL As String
        Dim clsgen As New ClasesGenerales.General

        Try

            lsSQL = "pa_upd_ws_socio_envio_entrega " & Me.txtSocio.Text & "," & Me.cmbClub.SelectedValue & "," &
                Me.dtpPrimerEnvio.Value.Month & "," & Me.dtpPrimerEnvio.Value.Year & ",'" & _
                    Me.dtpFechaEntrega.Value & "','" & Me.txtComentarios.Text & "','" & gs_usuario & "'"

            clsgen.insertQuery("SCM", lsSQL)

            MessageBox.Show("Proceso Finalizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiarPantalla()
            llenarEntregas()
        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try


    End Sub

    Private Sub limpiarPantalla()
        Me.txtComentarios.Text = String.Empty
        Me.txtSocio.Text = String.Empty
        Me.txtNombreSocio.Text = String.Empty
        Me.dtpPrimerEnvio.Value = Today
        Me.dtpFechaEntrega.Value = Today
        Me.txtSocio.ReadOnly = False
        Me.btnBuscar.Enabled = True
        Me.cmbDocumentos.DataSource = Nothing

    End Sub

    Private Sub llenarEntregas()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General

        Try
            lsSQL = "pa_var_um_ws_socio_envio_entrega"
            dt = clsgen.selectQuery("SCM", lsSQL)

            Me.dgvListado.DataSource = dt
            clsgen.Alinear_GridView(dt, Me.dgvListado, "", "", "", "", True, True, 150, 0)
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub

    Private Function verificarMes() As Boolean
        Dim clsgen As New ClasesGenerales.General
        Try

            Dim dt As DataTable
            Dim lsSQL As String

            lsSQL = "pa_sel_um_ws_socio_envio '" & Me.cmbDocumentos.SelectedValue.ToString.Split("/")(0) & "','" & _
            Me.cmbDocumentos.SelectedValue.ToString.Split("/")(1) & "'," & Me.txtSocio.Text & "," & Me.cmbClub.SelectedValue.ToString
            dt = clsgen.selectQuery("SCM", lsSQL)

            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "mes = " & Me.dtpPrimerEnvio.Value.Month & " and año = " & Me.dtpPrimerEnvio.Value.Year
                If dt.DefaultView.Count = 0 Then
                    MessageBox.Show("Este Mes No Puede Asignar Entregas, Fuera de Rango", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    If dt.DefaultView(0).Item("usuario_grabo_entrega").ToString.Trim.Length > 0 Then
                        If MessageBox.Show("Esta Entrega ya Tiene Informacion, Desea Modificarla", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        Return True
                    End If

                End If

            Else
                MessageBox.Show("Este Mes No Puede Asignar Entregas, Fuera de Rango", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try

    End Function

    Private Sub llenarComboDocumentos()

        Dim clsgen As New ClasesGenerales.General
        Try

            Dim dt As DataTable
            dt = clsgen.selectQuery("SCM", "pa_sel_um_ws_socio_club " & Me.txtSocio.Text & "," & Me.cmbClub.SelectedValue)

            Me.cmbDocumentos.DataSource = dt
            Me.cmbDocumentos.ValueMember = "serie_numero"
            Me.cmbDocumentos.DisplayMember = "serie_numero"
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub

    Private Sub frm_ws_control_entregas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.llenarCombo()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarSocio()
    End Sub

    Private Sub txtSocio_TextChanged(sender As Object, e As EventArgs) Handles txtSocio.TextChanged

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Me.cmbDocumentos.SelectedValue.ToString.Trim.Length > 0 Then


            If MessageBox.Show("Esta Seguro de Grabar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If verificarMes() Then
                    grabarEntrega()
                End If

            End If
        Else
            MessageBox.Show("Debe Seleccionar Documento de Entrega", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        llenarEntregas()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.limpiarPantalla()
    End Sub

    Private Sub btnObtener_Click(sender As Object, e As EventArgs) Handles btnObtener.Click
        Me.llenarComboDocumentos()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class