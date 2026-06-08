Public Class frm_int_producto_problema
    Dim ls_codigo As String
    Dim odataset As New DataSet
    Dim fecha_inicial As String = ""

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Dim frm_busqueda As New frm_busqueda_general
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "glosa,producto"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa "
        frm_busqueda.cmb_2.Visible = False
        frm_busqueda.cmb_log1.Visible = False
        frm_busqueda.txt_buscar2.Visible = False
        frm_busqueda.cmb_valor2.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.txt_buscar1.Text = Me.txt_producto.Text
        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.ShowDialog(Me)
        ls_codigo = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Me.txt_producto.Text = ls_codigo

        buscarProducto()
    End Sub
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2 As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")
                Me.txt_motivo.Focus()
            End If
            Me.hacer_filtro()
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub
    Private Sub llena_info_producto()
        Dim oTrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim otabla As DataTable

        Try

            oTrans.open()
            Try
                If odataset.Tables("productos_flex").Rows.Count > 0 Then
                    odataset.Tables("productos_flex").Rows.Clear()
                End If
            Catch ex As Exception
            End Try

            ls_sql = "pa_sel_um_int_producto_bloqueado '" & gs_empresa & "'"
            otabla = oTrans.Obtiene(ls_sql)
            otabla.TableName = "productos_flex"
            If odataset.Tables.IndexOf("productos_flex") > 0 Then odataset.Tables.Remove("productos_flex")
            odataset.Tables.Add(otabla.Copy)
            Me.dgv_productos.DataSource = odataset.Tables("productos_flex")
            clsgen.Alinear_GridView(otabla, dgv_productos, ",producto,glosa,motivo,fecha_grabo,usuario_grabo,", ",,", ",,", "", "", ",producto=70,glosa=250,motivo=150,fecha_grabo=75,usuario_grabo=100,", "", True, True, 175, 0)
        Catch ex As Exception
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try
    End Sub

    Private Sub hacer_filtro()
        Dim dr As DataRow

        Try
            For Each dr In odataset.Tables("productos_flex").Rows
                If dr.Item("producto") = Me.txt_producto.Text Then
                    Me.txt_descripcion.Text = dr.Item("glosa")
                    Me.txt_motivo.Text = dr.Item("motivo")
                    Me.txt_descripcion.Enabled = False
                    Me.txt_producto.Enabled = False
                    Me.txt_motivo.Enabled = False
                    Me.btn_guardar.Text = "Operar"
                    Me.fecha_inicial = dr.Item("fecha_grabo").ToString.Substring(0, 10)
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub
    Private Sub crear_estructura()
        Dim dt2 As New DataTable
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("motivo", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("fecha_grabo", GetType(Date)))
        dt2.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        odataset.Tables.Add(dt2.Copy)
        Me.dgv_productos.DataSource = odataset.Tables("productos_flex")
    End Sub
    
    Private Sub frm_int_producto_problema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()
        llena_info_producto()
    End Sub

    Private Sub txt_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.buscarProducto()
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub dgv_productos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.CurrentCellChanged
        Dim nRow As Integer
        Try
            nRow = Me.dgv_productos.CurrentCell.RowIndex
            Me.txt_producto.Text = Me.dgv_productos.Item(0, nRow).Value.ToString
            Me.txt_descripcion.Text = Me.dgv_productos.Item(1, nRow).Value.ToString
            Me.txt_motivo.Text = Me.dgv_productos.Item(2, nRow).Value.ToString
            Me.fecha_inicial = Me.dgv_productos.Item(3, nRow).Value.ToString.Substring(0, 10)
            deshabilitar()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub deshabilitar()
        Me.txt_descripcion.Enabled = False
        Me.txt_producto.Enabled = False
        Me.txt_motivo.Enabled = False
        Me.btn_guardar.Text = "Operar"
    End Sub
    Private Sub dgv_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.DoubleClick
        Dim nRow As Integer
        Try
            nRow = Me.dgv_productos.CurrentCell.RowIndex
            Me.txt_producto.Text = Me.dgv_productos.Item(0, nRow).Value.ToString
            Me.txt_descripcion.Text = Me.dgv_productos.Item(1, nRow).Value.ToString
            Me.txt_motivo.Text = Me.dgv_productos.Item(2, nRow).Value.ToString
            Me.fecha_inicial = Me.dgv_productos.Item(3, nRow).Value.ToString.Substring(0, 10)
            deshabilitar()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub limpiar()
        Me.txt_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_motivo.Text = ""
        Me.txt_producto.Enabled = True
        Me.txt_descripcion.Enabled = True
        Me.txt_motivo.Enabled = True
        Me.btn_guardar.Text = "Guardar"
    End Sub

    Private Sub procesar_producto(ByVal _accion As String)
        Dim oTrans As New Transaccional.Conexion("scm")
        Dim sql As String
        Try
            oTrans.open()

            If _accion = "Guardar" Then
                If MessageBox.Show("Esta Seguro de Grabar la Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    sql = "pa_ins_um_int_producto_bloqueado '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.txt_motivo.Text & "','" & gs_usuario & "'"
                    oTrans.Ingresa(sql)
                    If oTrans.Codigo_error = 0 Then
                        MessageBox.Show("Proceso realizado con Exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        limpiar()
                    End If
                End If
            Else
                If MessageBox.Show("Esta Seguro de Actualizar la Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    sql = "pa_upd_um_int_producto_bloqueado '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & gs_usuario & "','" & fecha_inicial & "'"
                    oTrans.Actualiza(sql)
                    If oTrans.Codigo_error = 0 Then
                        MessageBox.Show("Proceso realizado con Exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        limpiar()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Me.btn_guardar.Text = "Guardar" And Me.txt_producto.Text.Length = 10 And Me.txt_descripcion.Text.Length > 0 And LTrim(Me.txt_motivo.Text).Length > 0 Then
            procesar_producto("Guardar")
            llena_info_producto()
        ElseIf Me.txt_producto.Text.Length = 10 And Me.txt_descripcion.Text.Length > 0 And Me.txt_motivo.Text.Length > 0 And Me.btn_guardar.Text = "Operar" Then
            procesar_producto("actualizar")
            llena_info_producto()
        Else
            MessageBox.Show("No se puede guardar la informacion, favor hacer la verificacion.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub
  
End Class