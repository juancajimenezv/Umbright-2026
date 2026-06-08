Public Class frm_maq_tipo_produccion
    Dim ds As New DataSet

    Private Sub frm_maq_tipo_produccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
    End Sub

    Private Sub CreaTabla()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("num_orden", GetType(Integer)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha_Operacion", GetType(Date)))
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.TableName = "prods"

        If ds.Tables.Contains("prods") Then ds.Tables.Remove("prods")
        ds.Tables.Add(dt.Copy)

        dgv_detalle.DataSource = dt

    End Sub

    Private Sub genera_detalle()
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow

        Try
            Otrans.open()
            lsSQL = "pa_um_sel_tipo_orden_produccion '" & dtp_FechaI.Text & "','" & dtp_FechaF.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                For Each dr In dt.Rows
                    dr_aux = ds.Tables("prods").NewRow
                    dr_aux.Item("Num_Orden") = dr.Item("Num_Orden")
                    dr_aux.Item("Empresa") = dr.Item("Empresa")
                    dr_aux.Item("Cantidad") = dr.Item("Cantidad")
                    dr_aux.Item("Fecha_Operacion") = dr.Item("Fecha_Operacion")
                    dr_aux.Item("Tipo") = dr.Item("Tipo")

                    ds.Tables("prods").Rows.Add(dr_aux)

                    'If dr.Item("ExistenciaCD") < dr.Item("Sugerido") Then
                    '    dgv_detalle.Columns(11).DefaultCellStyle.ForeColor = Color.Red
                    'End If

                Next

                Me.dgv_detalle.DataSource = ds.Tables("prods")
                dgv_detalle.Columns(0).ReadOnly = True
                dgv_detalle.Columns(1).ReadOnly = True
                dgv_detalle.Columns(2).ReadOnly = True
                dgv_detalle.Columns(3).ReadOnly = True


                MessageBox.Show("Información Generada con Exito.....", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btn_generar_Click(sender As Object, e As EventArgs) Handles btn_generar.Click
        genera_detalle()
    End Sub

    Private Sub guardar_detalle()
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            Otrans.open()
            dt = Me.dgv_detalle.DataSource()

            For Each dr As DataRow In dt.Rows

                If dr.Item("Tipo").ToString <> "---" Then

                    ls_sql = "pa_um_ins_tipo_orden_produccion	'" & dr.Item("Empresa") & "','" & dr.Item("Num_Orden") & "','" & dr.Item("Tipo") & "'"
                    Otrans.Obtiene(ls_sql)

                End If

            Next

            MessageBox.Show("Tipos de Producción Guardados Con Exito......", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        guardar_detalle()
    End Sub
End Class