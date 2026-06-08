Public Class frm_actualizacion_sku

    Public sLinea As String 'Linea dentro de prodcodbarra
    '6 = walmart
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sLinea = "6" Then
            Me.Text = ":: Actualizacion SKU Walmart ::"
        ElseIf sLinea = "8" Then
            Me.Text = ":: Actualizacion SKU Unisuper ::"
        End If

    End Sub

    Dim Ods As DataSet
    Dim isNuevo As Boolean = True
    Dim dt_Info As DataTable

    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa").ToString
                Me.txt_proveedor.Text = dt.Rows(0)("subfamilia").ToString
                'Me.txt_sku.Text = dt.Rows(0)("itemwm").ToString


            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub buscarSKU()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & sLinea & "',null")
            If dt.Rows.Count > 0 Then
                Me.txt_sku.Text = dt.Rows(0)("codbarra").ToString
            End If



        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub validarlinea1()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_prodcodbarra '" & gs_empresa & "',null,'1',null")
            If dt.Rows.Count > 0 Then
                Me.txt_linea1.Text = dt.Rows(0)("unidad").ToString
            End If



        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub
    Private Sub validarsku()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String
        Try
            otrans.open()
            'dt = otrans.Obtiene("pa_sel_um_prodcodbarra '" & gs_empresa & "',null,'6','" & Me.txt_nuevo_sku.Text & "'")
            dt = otrans.Obtiene("pa_sel_um_prodcodbarra '" & gs_empresa & "',null,'" & sLinea & "','" & Me.txt_nuevo_sku.Text & "'")

            If dt.Rows.Count > 0 Then
                MessageBox.Show("El código de barra ya esta asignado para otro producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ''Codigo de Barra Nuevo
                If txt_nuevo_sku.Text.Length < 4 Then
                    If MessageBox.Show("El Producto no tiene SKU, ¿Desea Limpiar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                        'lsSQL = "pa_del_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "',6"
                        lsSQL = "pa_del_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "'," & sLinea
                        otrans.Elimina(lsSQL)
                    End If
                    'MessageBox.Show("Debe ingresar 6 caracteres como minimo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ''limpiar linea 6

                    ''insertar nueva linea 6
                    If (txt_nuevo_sku.Text.Length > 0) Then
                        'lsSQL = "pa_del_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "',6"
                        lsSQL = "pa_del_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "'," & sLinea
                        otrans.Elimina(lsSQL)
                        'lsSQL = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_nuevo_sku.Text & "','" & Me.txt_producto.Text & "','" & Me.txt_linea1.Text & "',1,6,1,' '"
                        lsSQL = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_nuevo_sku.Text & "','" & Me.txt_producto.Text & "','" & Me.txt_linea1.Text & "',1," & sLinea & ",1,' '"
                        otrans.Ingresa(lsSQL)
                        MessageBox.Show("Asignación Exitosa", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        isNuevo = True
                        limpiar_campos()
                    Else


                    End If

                End If
            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub txt_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_producto.LostFocus
        buscarProducto()
        validarlinea1()
        buscarSKU()
    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        validarsku()


    End Sub


    Private Sub limpiar_campos()
        txt_producto.Text = String.Empty
        txt_descripcion.Text = String.Empty
        txt_producto.ReadOnly = False
        txt_proveedor.Text = String.Empty
        txt_sku.Text = String.Empty
        txt_nuevo_sku.Text = String.Empty
        txt_linea1.Text = String.Empty
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        isNuevo = True
        limpiar_campos()
    End Sub

    Private Sub txt_nuevo_sku_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nuevo_sku.TextChanged

    End Sub

    Private Sub txt_linea1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_linea1.TextChanged

    End Sub


    Private Sub btn_ayuda_Click(sender As Object, e As EventArgs) Handles btn_ayuda.Click

    End Sub
End Class