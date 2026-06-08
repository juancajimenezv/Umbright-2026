Public Class frm_buscar_orden_etiquetas
    Public num_orden As String = ""

    Private Sub dtp_fecha_buscar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_buscar.ValueChanged
        obtener_datos()

    End Sub

    Private Sub obtener_datos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            otrans.open()
            ls_sql = "pa_var_um_maq_control_producto  '" & gs_empresa & "',NULL,'" & dtp_fecha_buscar.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            dgv_ordenes_fecha.DataSource = dt
            ClsGen.Alinear_GridView(dt, dgv_ordenes_fecha, ",empresa,fecha_produccion,numero,producto,glosa,cantidad,", ",observaciones,fecha_grabo,usuario_grabo,estado,fecha_modif,usuario_modif,costo_primo,", "", "", False, True, 255, 0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_ordenes_fecha_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_ordenes_fecha.CellDoubleClick
        num_orden = (dgv_ordenes_fecha.Item("numero", dgv_ordenes_fecha.CurrentRow.Index).Value.ToString)
        Me.Close()

    End Sub
End Class