Public Class frm_maq_orden_etiquetas
    Dim ls_codigo As String
    Dim valida As Boolean = False
  



    Private Sub frm_maq_orden_etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()

    End Sub

    Private Sub crear_estructura()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            myOtrans.open()
            otrans.open()

        


            ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            dt = myOtrans.Obtiene(ls_sql)
            solicitado_por.Text = dt.Rows(0)("nombre")

            ls_sql = "pa_sel_um_maq_control_numero'" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows(0)("numero").ToString <> "" Then
                Me.txt_op_numero_orden.Text = dt.Rows(0)("numero")
            Else
                Me.txt_op_numero_orden.Text = 1


            End If




        Catch ex As Exception
            myOtrans.close()
            myOtrans = Nothing

            otrans.close()
            otrans = Nothing
        End Try
    End Sub

   

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
    

        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "glosa,producto"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, producto, glosa "
        frm_busqueda.cmb_2.Visible = False
        frm_busqueda.cmb_log1.Visible = False
        frm_busqueda.txt_buscar2.Visible = False
        frm_busqueda.cmb_valor2.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.txt_buscar1.Text = Me.txt_producto.Text
        frm_busqueda.txt_buscar1.Focus()
        'frm_busqueda.pConexion = "FlexLine"
        frm_busqueda.ShowDialog(Me)
        ls_codigo = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Me.txt_producto.Text = ls_codigo

        buscarProducto()
    End Sub
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")
                ' Me.txt_proveedor.Text = dt.Rows(0)("subfamilia")
                Me.txt_op_cantidad_solicitada.Focus()

            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub
    Private Sub verificacion()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            otrans.open()

            ls_sql = "pa_var_um_maq_control_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.dtp_op_fecha_inicio.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                valida = False
            Else
                valida = True
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub
    Private Sub limpiar()
        Me.txt_producto.Text = ""
        Me.txt_op_observaciones.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_op_cantidad_solicitada.Text = ""


        Me.txt_producto.Focus()

        
    End Sub
    Private Sub procesar_informacion()

        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            otrans.open()

            ls_sql = "pa_ins_um_maq_control_produccion_etiqueta '" & gs_empresa & "','" & Me.txt_op_numero_orden.Text & "','" & Me.txt_producto.Text & "'," & Me.txt_op_cantidad_solicitada.Text & ",'" & Me.txt_op_observaciones.Text & "','" & Me.dtp_op_fecha_inicio.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(ls_sql)

            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Grabada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try



    End Sub

    Private Sub guardar_cambios()
        verificacion()

        If valida Then
            procesar_informacion()
            crear_estructura()


        Else
            MessageBox.Show("No se puede Grabar la informacion, por favor verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub

    Private Sub btn_guardar_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_orden_produccion.Click
        Try
            If Me.txt_producto.Text.Length = 10 And Me.txt_descripcion.Text.Length > 0 And Val(Me.txt_op_cantidad_solicitada.Text) <> 0 Then
                guardar_cambios()
            Else
                MessageBox.Show("No se puede Grabar la informacion, por favor verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If


        Catch ex As Exception
            MessageBox.Show("No se puede Grabar la informacion, por favor verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        

    End Sub

    Private Sub btn_nuevo_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_orden_produccion.Click
        limpiar()
    End Sub

    Private Sub txt_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_producto.LostFocus
        Me.buscarProducto()

    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged

    End Sub
End Class