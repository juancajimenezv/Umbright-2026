Public Class frm_Convierte_FactVentas_OC_SV
    Private Sub frm_Convierte_FactVentas_OC_SV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carga_Combos()
        gb_Convertir.Enabled = False
    End Sub


    Private Sub Carga_Combos()
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_SqlScript As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ls_SqlScript = "select TipoDocto from flexline.tipodocumento where empresa='" & cb_Empresa.Text & "' and sistema='ventas' and clase='BOLETA (V)' AND (TIPODOCTO LIKE ('%EXENTA%') or tipodocto='FACTURA SERIE F') ORDER BY TIPODOCTO"

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Formas"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_TipoDocto.DisplayMember = "TipoDocto"
            Me.cb_TipoDocto.ValueMember = "TipoDocto"
            Me.cb_TipoDocto.DataSource = ldt_table
        Catch ex As Exception

        Finally
            otrans.close()

        End Try

    End Sub

    Private Sub Busca_Docto()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "select TipoDocto, Fecha, Numero, Cliente, Total, Bodega from flexline.Documento where empresa ='" & cb_Empresa.Text & "' and tipodocto='" & cb_TipoDocto.Text & "' and numero='" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  '

            If dt.Rows.Count <= 0 Then
                MsgBox("Documento No Existe, Verifique...", MsgBoxStyle.Critical, "Error en Documento")
            Else
                lb_Fecha.Text = dt.Rows(0).Item("Fecha").ToString
                lb_Proveedor.Text = dt.Rows(0).Item("Cliente").ToString
                lb_Total.Text = Format(CDbl(dt.Rows(0).Item("Total")), "###,###,#00.00")
                lb_Bodega.Text = dt.Rows(0).Item("Bodega").ToString

                gb_Convertir.Enabled = True
                Asigna_Numero()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing

        End Try

    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Busca_Docto()
    End Sub

    Private Sub cb_Empresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Empresa.SelectedValueChanged
        Carga_Combos()
    End Sub

    Private Sub btn_Convertir_Click(sender As Object, e As EventArgs) Handles btn_Convertir.Click
        Convertir()
    End Sub

    Private Sub Convertir()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "exec flexline.spa_Convierte_FactVtas_OC '" & cb_Empresa.Text & "','" & cb_TipoDocto.Text & "','" & tb_Numero.Text & "','" & lb_Bodega.Text & "','" & gs_usuario & "'"
            otrans.Obtiene(lsSQL)  '

            MsgBox("El documento se convirtio en Orden de Compra Satisfactoriamente...", MsgBoxStyle.Information, "Verificar")
            gb_Convertir.Enabled = False
            Limpia()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing

        End Try

    End Sub

    Private Sub Asigna_Numero()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "select max(correlativoactual)+1 Correlativo from tipodocumento where empresa='divinos' and tipodocto='orden de compra'"
            dt = otrans.Obtiene(lsSQL)

            lb_Numero.Text = dt.Rows(0).Item("Correlativo").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing

        End Try

    End Sub
    Private Sub Limpia()
        tb_Numero.Text = ""
        lb_Proveedor.Text = "Cliente"
        lb_Fecha.Text = "Fecha"
        lb_Total.Text = "Total"
        lb_Bodega.Text = "Bodega"
        lb_Numero.Text = "Número"

        tb_Numero.Focus()
    End Sub
End Class