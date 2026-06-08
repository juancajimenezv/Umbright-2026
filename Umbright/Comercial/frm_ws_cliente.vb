Public Class frm_ws_cliente

    Dim dtListado As DataTable

    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod null,'CON_TIPDOC','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)

            dt.DefaultView.RowFilter = "codigo like '%a serie%'"

            Me.cmbSerie.DataSource = dt.DefaultView
            Me.cmbSerie.ValueMember = "CODIGO"
            Me.cmbSerie.DisplayMember = "CODIGO"


            lsSQL = "scm.flexline.pa_sel_um_ws_club"
            dt = Otrans.Obtiene(lsSQL)
            Me.cmbClub.DataSource = dt
            Me.cmbClub.ValueMember = "cod_club"
            Me.cmbClub.DisplayMember = "descripcion"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub


    Private Sub grabarInformacion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String


        Try
            obtenerCodigoSocioNuevo()
            Otrans.open()
            ''Creamos ws_socio Siempre trata de Insertaro, aunque el codigo de Socio es un valor que no se puede repetir
            lsSQL = "pa_ins_um_ws_socio " & Me.txtSocio.Text & ",'" & gs_empresa & "','" & Me.txtCtaCte.Text & "','" & Me.txtNombreSocio.Text & "','" & gs_usuario & "'"
            Otrans.Ingresa(lsSQL)



            ''Creamos ws_socio_club
            lsSQL = "pa_ins_um_ws_socio_club '" & gs_empresa & "','" & Me.txtCtaCte.Text & "','" & Me.cmbSerie.SelectedValue & "','" & Me.txtNumero.Text & "','" & _
                    Me.dtpPrimerEnvio.Value.ToString("dd/MM/yyyy") & "','" & Me.txtNombreSocio.Text & "','" & Me.txtTelefono.Text & "','" & _
                    Me.txtEmail.Text & "','" & Me.txtDireccionEntrega.Text & "','" & gs_usuario & "',null,'" & Me.txtObservaciones.Text & "'," & Me.txtSocio.Text & "," & _
                    Me.cmbClub.SelectedValue & "," & Me.nupEnvios.Value
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error = 0 Then

                For i As Integer = 0 To Me.nupEnvios.Value - 1
                    'MessageBox.Show(Me.dtpPrimerEnvio.Value.AddMonths(i))
                    lsSQL = "pa_ins_um_ws_socio_envio '" & Me.cmbSerie.SelectedValue & "','" & Me.txtNumero.Text & "'," & i + 1 & "," & _
                            Month(Me.dtpPrimerEnvio.Value.AddMonths(i)) & "," & Year(Me.dtpPrimerEnvio.Value.AddMonths(i)) & "," & _
                            Me.txtSocio.Text & "," & Me.cmbClub.SelectedValue
                    Otrans.Ingresa(lsSQL)

                Next

                MessageBox.Show("Proceso Generado Exitosamente", "Informacion", MessageBoxButtons.OK)
                Me.llenarListado()
                Me.limpiarPantalla()
            Else
                MessageBox.Show("Problemas para Ingresar la Informacion " & Otrans.descripcion_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub obtenerCodigoSocioNuevo()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            dt = clsGen.selectQuery("scm", "pa_var_um_ws_nuevo_socio")
            Me.txtSocio.Text = dt.Rows(0).Item("nuevo")


        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Function modificarInformacion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_upd_um_ws_socio_club '" & gs_empresa & "','" & _
                     Me.cmbSerie.SelectedValue & "','" & Me.txtNumero.Text & "'," & _
                     Me.txtSocio.Text & "," & _
                     Me.cmbClub.SelectedValue & ",'" & _
                     Me.txtTelefono.Text & "','" & _
                     Me.txtEmail.Text & "','" & Me.txtDireccionEntrega.Text & "','" & _
                     Me.txtObservaciones.Text & "','" & _
                     gs_usuario & "'"

            Otrans.Actualiza(lsSQL)

            MessageBox.Show("Proceso Generado Exitosamente", "Informacion", MessageBoxButtons.OK)
            Me.llenarListado()
            Me.limpiarPantalla()
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Function

    Private Function validarModificar() As Boolean


        If tiene_permisos("mco_ws_modificar_socio") Then
            Return True
        End If
        Return True
    End Function
    Private Function validarGuardar() As Boolean


        '' Socio En Blanco
        If Me.txtSocio.Text.Length = 0 Then
            If MessageBox.Show("Esta Seguro que es un nuevo Socio", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                obtenerCodigoSocioNuevo()
            Else
                Return False
            End If
        ElseIf Me.txtNombreSocio.Text.Length < 10 Then
            MessageBox.Show("Debe Llevar Nombre de Socio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        ElseIf Me.txtTelefono.Text.Length < 8 Then
            MessageBox.Show("Debe Ingresar Numero de Telefono", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        ElseIf Me.txtEmail.Text.Length < 10 Then
            MessageBox.Show("Debe Ingresar Correo Electronico", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        ElseIf Me.txtDireccionEntrega.Text.Length < 15 Then
            MessageBox.Show("Debe Ingresar Direccion de Entrega", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub llenarListado()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            Otrans.open()
            lsSQL = "pa_sel_um_ws_socio"
            dtListado = Otrans.Obtiene(lsSQL)
            Me.dgvListado.DataSource = dtListado
            ClsGen.Alinear_GridView(dtListado, dgvListado, "", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub mostrarSocio(ByVal psTipoDocto As String, ByVal psNumero As String)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_ws_socio '" & psTipoDocto & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.txtCtaCte.Text = .Item("ctacte").ToString
                    Me.txtDireccionEntrega.Text = .Item("direccion_entrega").ToString
                    Me.txtEmail.Text = .Item("correo_electronico").ToString
                    Me.txtTelefono.Text = .Item("telefono").ToString
                    Me.txtNombreSocio.Text = .Item("nombre_socio").ToString
                    Me.txtNumero.Text = .Item("numero").ToString
                    Me.cmbSerie.SelectedValue = .Item("serie").ToString
                    Me.dtpPrimerEnvio.Value = .Item("fecha_inicio")
                    Me.txtSocio.Text = .Item("cod_socio")
                    Me.txtObservaciones.Text = .Item("observaciones").ToString
                End With

            End If
            lsSQL = "pa_sel_um_ws_socio_envio '" & psTipoDocto & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvEnvios.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgvEnvios, ",numero_envio,mes,año,", "", ",numero_envio,mes,año,", "", "", "", "", True, True, 250, 0)

            Me.btnGrabar.Text = "Modificar"
            Me.cmbSerie.Enabled = False
            Me.txtNumero.Enabled = False

            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub





    Private Sub limpiarPantalla()
        Me.txtCtaCte.Text = String.Empty
        Me.txtDireccionEntrega.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.txtNombreSocio.Text = String.Empty
        Me.txtTelefono.Text = String.Empty
        Me.txtRazonSocial.Text = String.Empty
        Me.txtNumero.Text = String.Empty
        Me.txtSocio.Text = String.Empty

        Me.btnGrabar.Text = "Grabar"
        Me.dgvEnvios.DataSource = Nothing
        Me.cmbSerie.Enabled = True
        Me.txtNumero.Enabled = True
    End Sub

    Private Sub buscarSocio()

        Try

            Dim oform As New frm_busqueda_general
            oform.nombre_vista = "ws_socio_club"
            oform.lista_campos = "cod_socio,ctacte,nombre_socio"
            oform.parametros = "nombre_socio,ctacte"
            oform.conectar = "scm"
            oform.hacer_busqueda_vista("scm")
            oform.ShowDialog()
            Me.txtSocio.Text = oform.resultado
            oform = Nothing
            oform.Dispose()
        Catch ex As Exception

        End Try
        If Me.txtSocio.Text.Trim.Length > 0 Then
            llenarSocio()
        End If
    End Sub

    Private Sub llenarSocio()
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            lsSQL = "pa_sel_um_ws_socio_club " & Me.txtSocio.Text
            dt = ClsGen.selectQuery("SCM", lsSQL)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.txtCtaCte.Text = .Item("ctacte").ToString
                    Me.txtDireccionEntrega.Text = .Item("direccion_entrega").ToString
                    Me.txtEmail.Text = .Item("correo_electronico").ToString
                    Me.txtTelefono.Text = .Item("telefono").ToString
                    Me.txtNombreSocio.Text = .Item("nombre_socio").ToString
                    'Me.txtNumero.Text = .Item("numero").ToString
                    'Me.cmbSerie.SelectedValue = .Item("serie").ToString
                    'Me.dtpPrimerEnvio.Value = .Item("fecha_inicio")
                    Me.txtSocio.Text = .Item("cod_socio")
                End With

            End If

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub
    Private Sub buscarCliente()

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_ctacte '" & gs_empresa & "','" & Me.txtCtaCte.Text & "','CLIENTE'")
            If dt.Rows.Count > 0 Then
                Me.txtRazonSocial.Text = dt.Rows(0).Item("nombre_cliente").ToString
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub realizarFiltro()
        If Me.TextBox1.Text.Length = 0 Then
            dtListado.DefaultView.RowFilter = ""
        Else
            dtListado.DefaultView.RowFilter = Me.ComboBox1.SelectedItem & " like '%" & Me.TextBox1.Text & "%'"
        End If
    End Sub

    Private Sub frm_ws_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.llenarCombos()
        llenarListado()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.btnGrabar.Text.ToLower.Equals("grabar") Then
            If MessageBox.Show("Esta Seguro de Guardar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If validarGuardar() Then
                    grabarInformacion()
                    llenarListado()
                End If

            End If
        Else
            If MessageBox.Show("Esta Seguro de Modificar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If validarModificar Then
                    modificarInformacion()
                    llenarListado()
                End If

            End If

        End If

    End Sub

    Private Sub dgvListado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Try
            Dim colIndex As Integer = e.ColumnIndex
            Dim rowIndex As Integer = e.RowIndex

            mostrarSocio(Me.dgvListado.Item("serie", rowIndex).Value, Me.dgvListado.Item("numero", rowIndex).Value)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiarPantalla()
    End Sub

    Private Sub btnBuscarSocio_Click(sender As Object, e As EventArgs) Handles btnBuscarSocio.Click
        buscarSocio()
    End Sub

    Private Sub txtCtaCte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCtaCte.KeyPress
        If e.KeyChar = Chr(13) Then
            BUSCARCLIENTE()
        End If
    End Sub

    Private Sub txtCtaCte_TextChanged(sender As Object, e As EventArgs) Handles txtCtaCte.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            realizarFiltro()
        End If
    End Sub
End Class