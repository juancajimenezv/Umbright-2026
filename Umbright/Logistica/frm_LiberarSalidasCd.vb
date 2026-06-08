Public Class frm_LiberarSalidasCd
    Private Sub frm_LiberarSalidasCd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarEmpresas()
        Limpiar()
    End Sub


    Private Sub llenarEmpresas()

        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSql As String

        Try

            lsSql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSql)
            dt.TableName = "empresa"
            Me.cmb_e_empresa.DisplayMember = "descripcion"
            Me.cmb_e_empresa.ValueMember = "descripcion"
            Me.cmb_e_empresa.DataSource = dt


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub Busca_SalidaCD()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = " select * from flexline.DOCUMENTO where empresa='" & cmb_e_empresa.Text & "' and tipodocto='SALIDA TRASLADO CD' and numero='" & Me.txt_numero.Text.PadLeft(10, "0") & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                MessageBox.Show("Salida Traslado CD Existente... Proceda a Liberar... Verique Que No Haya Sido Cargada Anteriormente...", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btn_Liberar.Enabled = True
                txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")

            Else
                MessageBox.Show("Documento No Existe... Verifique!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()

            End If


        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Limpiar()
        txt_numero.Text = ""
        btn_Liberar.Enabled = False
    End Sub
    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(txt_numero.Text) Or txt_numero.Text.Length = 0 Or cmb_e_TipoDocto.SelectedIndex = -1 Or cmb_e_empresa.SelectedIndex = -1 Then
                txt_numero.Focus()
                txt_numero.SelectAll()
            Else
                Busca_SalidaCD()
            End If
        End If
    End Sub

    Private Sub btn_Liberar_Click(sender As Object, e As EventArgs) Handles btn_Liberar.Click
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("Flexline")

        Try
            Otrans.open()

            lsSQL = " pa_Gen_Libera_Salidas_CD '" & cmb_e_empresa.Text & "','" & cmb_e_TipoDocto.Text & "','" & txt_numero.Text & "'"
            Otrans.Obtiene(lsSQL)

            MessageBox.Show("Documento Liberado... Proceda a Realizar la Carga", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()

        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
End Class