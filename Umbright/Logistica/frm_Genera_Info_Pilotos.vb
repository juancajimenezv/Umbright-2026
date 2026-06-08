Public Class frm_Genera_Info_Pilotos

    Private Sub frm_Genera_Info_Pilotos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub procesar()
        'declara la variable'
        Dim ls_sql As String
        'hace la conexion'
        Dim oTrans As New Transaccional.Conexion_mysql("onbase")

        Try
            oTrans.open()

            'llama al stored procedure para que ejecute el isf en la linea 13 (es la sincronizacion de pedidos edifact) '
            ls_sql = "call pa_upd_um_pg_procesos_isf_tiempo (19)"

            oTrans.Actualiza(ls_sql)

            MessageBox.Show("Proceso Finalizado con exito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            'cierra la conexion'
            oTrans.close()
            oTrans = Nothing


        End Try

    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        procesar()

    End Sub
End Class