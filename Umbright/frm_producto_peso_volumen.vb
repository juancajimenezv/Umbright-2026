Public Class frm_Producto_Peso_Volumen
    

    Private Sub frm_Producto_Peso_Volumen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_peso_volumen()

    End Sub

    Private Sub cargar_peso_volumen()
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim ls_sql As String
        Dim dt As New DataTable
        Try
            oTrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "', '" & txt_Producto.Text & "'"

            dt = oTrans.Obtiene(ls_sql)
            txt_Peso.Text = dt.Rows(0).Item("analisisproducto2").ToString
            txt_Volumen.Text = dt.Rows(0).Item("analisisproducto1").ToString

        Catch ex As Exception
            MessageBox.Show("ERROR: " & oTrans.descripcion_error)
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
    End Sub

    Private Sub guardar_peso_volumen()
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            oTrans.open()
            ls_sql = "pa_upd_um_producto_peso_volumen '" & gs_empresa & "', '" & txt_Producto.Text & "', '" & txt_Peso.Text & "','" & txt_Volumen.Text & "'"

            oTrans.Actualiza(ls_sql)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR: " & oTrans.descripcion_error)

        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
        
    End Sub

    Private Sub btn_Calcular_Volumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calcular_Volumen.Click
        If (IsNumeric(txt_Volumen.Text) And IsNumeric(txt_altura.Text) And IsNumeric(txt_ancho.Text)) Then
            txt_Volumen.Text = Math.Round(txt_base.Text * txt_altura.Text * txt_ancho.Text, 4)

        Else
            MessageBox.Show("ERROR: Altura, Base y Ancho deben ser datos numericos.")

        End If
    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        If (IsNumeric(txt_Volumen.Text) And IsNumeric(txt_Peso.Text)) Then

            If MessageBox.Show("Esta seguro de guardar Peso='" & txt_Peso.Text & "' y Volumen='" & txt_Volumen.Text & "' para el producto '" & txt_Producto.Text & "'?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                guardar_peso_volumen()
            End If

        Else
            MessageBox.Show("ERROR: Volumen y Peso deben ser datos numericos.")

        End If
    End Sub
End Class