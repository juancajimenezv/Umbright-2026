Public Class Frm_Producto_Item
    'Dim gs_empresa As String = "CODICASA"

    Private Sub Frm_Producto_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Muestra()
        Carga_Combos()
    End Sub

    Private Sub Muestra()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Producto, Glosa, TipoProducto, Item, TipoIva from SCM.flexline.item_producto where empresa= '" & gs_empresa & "' order by producto"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_Detalle.DataSource = dt

            ''lb_Estado.Text = dt.Rows(0).Item("Estado")
            ''lb_EstadoRm.Text = dt.Rows(0).Item("Estado")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try
    End Sub

    Private Sub Carga_Combos()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("SCM")
        otrans.open()

        ls_SqlScript = "select tipoproducto Codigo from SCM.flexline.item_producto where empresa='" & gs_empresa & "' group by tipoproducto order by tipoproducto"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Tipo"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Tipo.DisplayMember = "Codigo"
        Me.cb_Tipo.ValueMember = "Codigo"
        Me.cb_Tipo.DataSource = ldt_table


    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        If MsgBox("Desea Agregar Producto Item?", MsgBoxStyle.YesNo, "Seguro") = MsgBoxResult.Yes Then
            Agregar()
            Limpiar()
        End If
    End Sub

    Private Sub Agregar()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try

            Utrans.open()
            ls_sql = "spa_Guarda_Producto_Item '" & gs_empresa & "','" & tb_Codigo.Text & "','" & tb_Descripcion.Text & "','" & cb_Tipo.Text & "','" & tb_Item.Text & "','" & cb_TipoIva.Text & "'"
            Utrans.Ingresa(ls_sql)
            Muestra()
            MsgBox("Agregado Con Exito!!", MsgBoxStyle.MsgBoxSetForeground, "Agregado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub tb_Codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Codigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Codigo.Text.Length > 0 Then
                tb_Descripcion.Focus()
            Else
                MsgBox("Debe Ingresar Codigo", MsgBoxStyle.Critical, "Codigo")
                tb_Codigo.Focus()
            End If
        End If
    End Sub

    Private Sub tb_Descripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Descripcion.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Descripcion.Text.Length > 0 Then
                cb_Tipo.Focus()
            Else
                MsgBox("Debe Ingresar Descripción", MsgBoxStyle.Critical, "Codigo")
                tb_Descripcion.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Tipo.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Tipo.Text.Length > 0 Then
                tb_Item.Focus()
            Else
                MsgBox("Debe Ingresar Tipo de Producto", MsgBoxStyle.Critical, "Tipo")
                cb_Tipo.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub tb_Item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Item.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Item.Text.Length > 0 Then
                cb_TipoIva.Focus()
            Else
                MsgBox("Debe Ingresar Item", MsgBoxStyle.Critical, "Item")
                cb_TipoIva.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub cb_TipoIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_TipoIva.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_TipoIva.Text.Length > 0 Then
                btn_Agregar.Focus()
            Else
                MsgBox("Debe Ingresar Tipo de Iva", MsgBoxStyle.Critical, "IVA")
                cb_TipoIva.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub Limpiar()
        tb_Codigo.Text = ""
        tb_Descripcion.Text = ""
        tb_Item.Text = ""
        cb_TipoIva.Text = ""
        cb_Tipo.Text = ""
        Carga_Combos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub
End Class