Public Class frm_liberar_facturas

    Dim ods As DataSet
    Public lbVinoteca As Boolean = False
    Private Sub llenarCombos()

        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        If lbVinoteca Then

            clsGen.fillComboBox(Otrans, "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA','VINOTECA'", "EMPRESAS", "EMPRESA", "EMPRESA", Me.cmbEmpresa)

        Else



            clsGen.fillComboBox(Otrans, "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'", "EMPRESAS", "EMPRESA", "EMPRESA", Me.cmbEmpresa)



        End If


        clsGen = Nothing
        Otrans = Nothing
    End Sub

    Private Sub mostrarTipoDocto()


        Dim lsSQL As String
        Dim clsgen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable


        Try



            If lbVinoteca = True Then
                lsSQL = "pa_sel_um_tipodocumento '" & Me.cmbEmpresa.SelectedValue.ToString & "','Salida (i)',null"
                dt = clsgen.selectQuery("FlexLine", lsSQL)

            Else
                lsSQL = "pa_sel_um_tipodocumento '" & Me.cmbEmpresa.SelectedValue.ToString & "','Boleta (v)',null"
                dt = clsgen.selectQuery("FlexLine", lsSQL)

            End If


            Me.cmbTipoDocto.DataSource = dt
            Me.cmbTipoDocto.DisplayMember = "tipoDocto"
            Me.cmbTipoDocto.ValueMember = "tipoDocto"
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub


    Private Sub buscarNota()

        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_var_um_documento '" & Me.cmbEmpresa.SelectedValue.ToString & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'"

            lsSQL = "pa_sel_um_documento_detalle '" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.cmbEmpresa.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'"

            dt = clsgen.selectQuery("FlexLine", lsSQL)

            If dt.Rows.Count > 0 Then
                ods = New DataSet
                dt.TableName = "Detalle"
                ods.Tables.Add(dt.Copy)
                Me.dgvDetalle.DataSource = ods.Tables("detalle")

                'Dim drAux As DataRow

                'drAux = ods.Tables("notas").NewRow
                'drAux.Item("NCE") = False
                'drAux.Item("Refacturar") = False
                'drAux.Item("Empresa") = Me.cmbEmpresa.SelectedValue
                'drAux.Item("tipodocto") = Me.cmbTipoDocto.SelectedValue
                'drAux.Item("correlativo") = dt.Rows(0).Item("correlativo")
                'drAux.Item("numero") = Me.txtNumero.Text
                'drAux.Item("cliente") = dt.Rows(0).Item("cliente")
                'drAux.Item("razonSocial") = dt.Rows(0).Item("razonSocial")
                'drAux.Item("Fecha") = dt.Rows(0).Item("Fecha")
                'drAux.Item("glosa") = dt.Rows(0).Item("glosa")
                'drAux.Item("Monto") = dt.Rows(0).Item("total")
                'drAux.Item("dias") = 99


                'Try
                '    If drAux.Item("glosa").ToString.ToLower.IndexOf("parcial") > 0 Then
                '        drAux.Item("NCE") = True
                '        drAux.Item("Refacturar") = True
                '    End If
                'Catch ex As Exception

                'End Try





                clsgen.Alinear_GridView(ods.Tables("detalle"), Me.dgvDetalle, "", "", _
                                        "", "", "", "", "", True, True, 180, 0)


            End If


        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try

    End Sub

    Private Sub frm_liberar_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub

   

    Private Sub cmbEmpresa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectionChangeCommitted
        mostrarTipoDocto()
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbEmpresa.Enabled = False
            Me.txtNumero.Text = Me.txtNumero.Text.PadLeft(10, "0")
            buscarNota()
            Me.txtNumero.Text = String.Empty
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub btnLiberar_Click(sender As Object, e As EventArgs) Handles btnLiberar.Click

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Try
            For Each dr As DataRow In ods.Tables("detalle").Rows

                lsSQL = "pa_upd_um_documentod_asignado '" & Me.cmbEmpresa.SelectedValue.ToString & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "'," &
                        dr.Item("correlativo") & ",'" & dr.Item("producto") & "'," & dr.Item("Secuencia") & ",'" & gs_usuario & "'"
                clsGen.insertQuery("FlexLine", lsSQL)

            Next

            MessageBox.Show("Proceso Finalizado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged

    End Sub
End Class