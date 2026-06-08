Public Class frm_nombre_corto
    Public Pcta_cte, Prazon_social As String

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Me.txt_nombre_corto.Text.Length > 0 And Me.txt_clasificacion.Text.Length > 0 And Me.txt_segmento.Text.Length > 0 And Me.txt_motivo_consumo.Text.Length > 0 Then
            guardar_informacion()

        Else
            MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub
    Private Sub guardar_informacion()
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim cerrar_ventana As Boolean = False

        Try
            oTrans.open()
            ls_sql = "pa_upd_um_ctacteNombreCorto '" & gs_empresa & "','" & Pcta_cte & " ','" & Prazon_social & "','" & Me.txt_nombre_corto.Text & "','" & Me.txt_clasificacion.Text & "','" & Me.txt_segmento.Text & "','" & Me.txt_motivo_consumo.Text & "'"
            oTrans.Actualiza(ls_sql)


            If oTrans.Codigo_error > 0 Then
                MessageBox.Show("No Se Pudo Almacenar La Informacion", "", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Informacion Almacenada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cerrar_Ventana = True

                If Cerrar_Ventana Then
                    'CodigoNuevo = Me.txt_codigo.Text
                    Me.Close()
                End If
            End If

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub frm_nombre_corto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()

    End Sub
End Class