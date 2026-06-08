Public Class Frm_Cambio_Dai
    Dim _dtProductoDai As DataTable
    Private Sub Nuevo()
        tb_Producto.Clear()
        Me.dgv_Impuestos.DataSource = ""
        _dtProductoDai.Rows.Clear()
        Me.l_producto.Text = " INGRESE EL CODIGO DEL PRODUCTO O SELECCIONELO..."
        Me.tb_Producto.Enabled = True
    End Sub
    Private Sub Limpia()
        Me.dgv_Impuestos.DataSource = ""
        _dtProductoDai.Rows.Clear()
        Me.l_producto.Text = " INGRESE EL CODIGO DEL PRODUCTO O SELECCIONELO..."
        Me.tb_Producto.Enabled = True
    End Sub

    Private Sub CambioDai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable  'Declara dt como DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL = " spa_ProductosCuenta '" & gs_empresa & "'"  'asigna el procedimiento a lsSql

            dt = otrans.Obtiene(lsSQL)                              'Ejecuta el procedimiento guardado en lsSql
            dt = clsGen.ValoresDistinto(dt, "Familia".Split(","))   'agrupa por familia

            Me.BoxFamilia.DataSource = dt                           'asigna comboBox la tabla o resultado del procedimiento
            Me.BoxFamilia.DisplayMember = "Familia"                 'Despliega el miembro familia
            Me.BoxFamilia.ValueMember = "Familia"                   '
            CreaTabla()
        Catch ex As Exception
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub
    Private Sub Obtiene_Subfamilia()
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable  'Declara dt como DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL = " spa_SubFamilias '" & gs_empresa & "','" & Me.BoxFamilia.Text & "'"    'asigna el procedimiento a lsSql
            dt = otrans.Obtiene(lsSQL)                                                      'Ejecuta el procedimiento guardado en lsSql
            dt = clsGen.ValoresDistinto(dt, "SubFamilia".Split(","))                        'agrupa por familia

            Me.BoxSubFamilia.DataSource = dt                                                'asigna comboBox la tabla o resultado del procedimiento
            Me.BoxSubFamilia.DisplayMember = "SubFamilia"                                   'Despliega el miembro familia 
            Me.BoxSubFamilia.ValueMember = "SubFamilia"

        Catch ex As Exception
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub
    Private Sub CreaTabla()

        _dtProductoDai = New DataTable("Tmp_ProductoDai")

        _dtProductoDai.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Familia", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("SubFamilia", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Producto", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Glosa", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Nivel", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        _dtProductoDai.Columns.Add(New DataColumn("Impuesto", GetType(Boolean)))
        _dtProductoDai.Columns.Add(New DataColumn("Modificado", GetType(Integer)))
        ' _dtProductoDai.PrimaryKey = New DataColumn() {_dtProductoDai.Columns(0), _dtProductoDai.Columns(4)}

    End Sub
    Private Sub ListaProductoDai()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_um_ImpuestosDai '" & gs_empresa & "','" & Me.BoxFamilia.Text & "','" & Me.BoxSubFamilia.Text & "','" & Me.tb_Producto.Text & "'" 'Me.BoxProducto.Text & "'"  ' 'asigna el procedimiento y valores a lsSql"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtProductoDai.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtProductoDai.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Familia") = dr.Item("Familia")
                dr2.Item("SubFamilia") = dr.Item("SubFamilia")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Glosa") = dr.Item("Glosa")
                dr2.Item("Nivel") = dr.Item("Nivel")
                dr2.Item("Impuesto") = dr.Item("Impuesto")
                dr2.Item("Descripcion") = dr.Item("Descripcion")
                dr2.Item("Modificado") = 2

                _dtProductoDai.Rows.Add(dr2)

            Next

            Me.dgv_Impuestos.DataSource = _dtProductoDai    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtProductoDai, Me.dgv_Impuestos, "", ",Empresa,Familia,SubFamilia,Producto,Glosa,Nivel,Modificado,", ",Descripcion,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btn_Familia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Familia.Click
        Obtiene_Subfamilia()
    End Sub
    Private Sub llenaProductos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_um_Productos2 '" & gs_empresa & "','" & Me.BoxFamilia.Text & " ','" & Me.BoxSubFamilia.Text & "'" '& Me.BoxProducto.Text & "'"  ' 'asigna el procedimiento y valores a lsSql"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.dgv_Productos.DataSource = dt    'asigna el resultado del procedimiento en un Grid

            clsGen.Alinear_GridView(dt, Me.dgv_Productos, "", ",Empresa,", ",Familia,SubFamilia,Producto,Glosa,", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_SubFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SubFamilia.Click
        llenaProductos()
    End Sub

    Private Sub btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Grabar.Click
        Graba()
        Me.tb_Producto.Enabled = True
        Me.tb_Producto.Focus()
    End Sub

    Private Sub IngresaProd() 'TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim Prod As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow
        Prod = tb_Producto.Text

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_um_ImpuestosDai2 '" & gs_empresa & "','" & Prod & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count = 0 Then
                l_producto.Text = "PRODUCTO NO EXISTE DENTRO DEL CATALOGO VERIFIQUE !!"

            Else
                Me.tb_Producto.Enabled = False
                _dtProductoDai.Rows.Clear()
                For Each dr As DataRow In dt.Rows
                    dr2 = _dtProductoDai.NewRow
                    dr2.Item("Empresa") = dr.Item("Empresa")
                    dr2.Item("Familia") = dr.Item("Familia")
                    dr2.Item("SubFamilia") = dr.Item("SubFamilia")
                    dr2.Item("Producto") = dr.Item("Producto")
                    dr2.Item("Glosa") = dr.Item("Glosa")
                    dr2.Item("Nivel") = dr.Item("Nivel")
                    dr2.Item("Impuesto") = dr.Item("Impuesto")
                    dr2.Item("Descripcion") = dr.Item("Descripcion")
                    dr2.Item("Modificado") = 2

                    _dtProductoDai.Rows.Add(dr2)
                    Me.l_producto.Text = dr.Item("producto") & " -- " & dr.Item("glosa") 'despliega codigo y producto en Label4
                Next

                Me.dgv_Impuestos.DataSource = _dtProductoDai    'Despliega el resultado del procedimiento en un Grid
                clsGen.Alinear_GridView(_dtProductoDai, Me.dgv_Impuestos, "", ",Empresa,Familia,SubFamilia,Producto,Glosa,Nivel,Modificado,", ",Descripcion,", "", "", "", "", True, True, 275, 0)
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IngresaProd()
    End Sub

    Private Sub dgv_Productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Productos.DoubleClick

        'Para seleccionar una linea o producto en el listado de productos
        Try

            Me.tb_Producto.Text = Me.dgv_Productos.Item("producto", Me.dgv_Productos.CurrentRow.Index).Value
            IngresaProd()
            Me.tc_Productos.SelectedTab = tp_Impuestos

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tb_Producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_Producto.GotFocus
        tb_Producto.SelectionStart = 0
        tb_Producto.SelectionLength = tb_Producto.Text.Length
    End Sub

    Private Sub tb_Producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_Producto.KeyPress
        If e.KeyChar = Chr(13) Then IngresaProd() ' para seleccionar con Enter
    End Sub

    Private Sub Graba()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Impto As Integer

        If tb_Producto.Text = "" Then
            MsgBox("Producto no Existe, Verifique")
            Exit Sub
        End If
        If MessageBox.Show("¿Esta Accion Actualizara Impuestos?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try
            Otrans.open()   'abre conexion

            dt = Me.dgv_Impuestos.DataSource

            For Each drv As DataRowView In dt.DefaultView

                If drv.Item("Impuesto") = True Then
                    Impto = 1
                Else
                    Impto = 0
                End If

                ls_sql = "exec spa_um_ActualizaDai '" & drv.Item("Empresa") & "','" & drv.Item("Producto") & "'," & drv.Item("Nivel") & "," & Impto
                Otrans.Actualiza(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""

            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Limpia()
    End Sub

    Private Sub btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub

End Class