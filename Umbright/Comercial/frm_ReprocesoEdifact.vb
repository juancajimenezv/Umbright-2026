Public Class frm_ReprocesoEdifact

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If MessageBox.Show("Esta seguro de continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            procesar()
        End If

    End Sub

    Private Sub dt_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha.ValueChanged

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'resta un dia a la fecha actual'
        dt_fecha.Value = Today.AddDays(-1)


    End Sub


    Private Sub procesar()
        'declara la variable'
        Dim ls_sql As String
        'hace la conexion'
        Dim oTrans As New Transaccional.Conexion_mysql("onbase")

        Try
            oTrans.open()
            'Formato de fecha'
            Me.dt_fecha.CustomFormat = "yyyy-MM-dd"
            Me.dt_fecha.Format = DateTimePickerFormat.Custom

            'llama al stored procedure para hacer la eliminacion del detalle de pedido'
            ls_sql = "call pa_del_um_edi_pedido_detalle ('" & gs_empresa & "','" & Me.dt_fecha.Text & " 12:00:00')"
            If oTrans.Elimina(ls_sql) > 0 Then
                'llama al stored procedure para eliminar el encabezado del pedido'
                ls_sql = "call pa_del_um_edi_pedido_encabezado ('" & gs_empresa & "','" & Me.dt_fecha.Text & " 12:00:00')"
                oTrans.Elimina(ls_sql)

            End If

            'llama al stored procedure para que ejecute el isf en la linea 13 (es la sincronizacion de pedidos edifact) '
            ls_sql = "call pa_upd_um_pg_procesos_isf_tiempo (13)"

            oTrans.Actualiza(ls_sql)

            MessageBox.Show("Proceso Finalizado con exito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            'cierra la conexion'
            oTrans.close()
            oTrans = Nothing


        End Try

    End Sub
End Class