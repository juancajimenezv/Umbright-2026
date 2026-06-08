Imports System.Text

Public Class frm_vin_Inventario_MinimoMaximo

    Dim int As Integer
    Dim encabezados_seleccionados As String = ""
    Dim _dtregistros As DataTable
    Dim _dtListaPrecio As DataTable
    Dim ods_listado, ods_nuevo As New DataSet
    Dim ods As DataSet


    Dim Pbodega As String = ""
    Dim Pcomprador As String = ""

    Private Sub llenar_combos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2 As DataTable


        Try

            Otrans.open()

            ods = New DataSet
            ls_sql = "pa_sel_um_usuario_bodega '" & gs_empresa & "','INGRESO STOCKMINMAX','" & gs_usuario & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            ods.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                Pbodega = dt.Rows(0).Item("bodega")
                Pcomprador = dt.Rows(0).Item("nombre")
                Me.txt_bodega.Text = dt.Rows(0).Item("ubicacion")



            End If
            Me.cmb_valor1.Items.Add("Producto")
            Me.cmb_valor1.Items.Add("Glosa")
            Me.cmb_1.Items.Add("=")
            Me.cmb_1.Items.Add(">")
            Me.cmb_1.Items.Add("<")
            Me.cmb_1.Items.Add("like")

            'Me.cmb_proveedor.Items.Add("CODICASA")
            'Me.cmb_proveedor.Items.Add("DISTRIBUIDORA MARTE")
            'Me.cmb_proveedor.Items.Add("DIUVA")

            Me.cmb_valor1.Text = "Glosa"
            Me.cmb_1.Text = "like"
            'Me.cmb_proveedor.Text = "CODICASA"

            ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
          " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " &
          " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " &
          " UNION select distinct SubFamilia from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "

            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_SubFamilia"
            'ods.Tables.Add(dt.Copy)

            Me.cmb_proveedor.DataSource = dt
            Me.cmb_proveedor.DisplayMember = "CODIGO"
            Me.cmb_proveedor.ValueMember = "CODIGO"
            Me.cmb_proveedor.SelectedValue = "CODICASA"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub crear_estructura()
        Dim dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General

        ods_listado = New DataSet
        dt2 = New DataTable("listado")
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("subfamilia", GetType(String)))
        dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        dt2.Columns("producto").Unique = True
        ods_listado.Tables.Add(dt2)
        Me.dgv_productos.DataSource = ods_listado.Tables("listado")
        'clsgen.Alinear_GridView(ods_listado.Tables("listado"), dgv_productos, ",producto,glosa,subfamilia,stockminimo,stockmaximo,", ",,", ",producto,glosa,", "", "", ",producto=100,Glosa=250,subfamilia=150,stockminimo=50,stockmaximo=50,", "", True, True, 175, 0)
        clsgen.Alinear_GridView(ods_listado.Tables("listado"), dgv_productos, ",producto,glosa,subfamilia,stockminimo,stockmaximo,", "", ",producto,glosa,subfamilia,", "", "", ",Glosa=400,subfamilia=150,", "", True, True, 175, 0)

    End Sub


    Private Sub llenar_informacion()
        Dim ls_sql, ls_sqls As String
        Dim dr, dr_aux As DataRow
        Dim dt, dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()

            ods_listado.Tables("listado").Rows.Clear()
            'ls_sql = "pa_sel_um_prodbodegas_temp '" & gs_empresa & "','" & Pbodega & "','" & Me.cmb_proveedor.Text & "'"
            ls_sql = "pa_sel_um_prodbodegas_general '" & gs_empresa & "','" & Pbodega & "','NULL'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "productos"
            If ods.Tables.IndexOf("productos") > 0 Then ods.Tables.Remove("productos")
            ods.Tables.Add(dt.Copy)
            For Each dr In dt.Rows
                dr_aux = ods_listado.Tables("listado").NewRow
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("subfamilia") = dr.Item("subfamilia")
                dr_aux.Item("stockminimo") = dr.Item("stockminimo")
                dr_aux.Item("stockmaximo") = dr.Item("stockmaximo")
                ods_listado.Tables("listado").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try
    End Sub

    Private Sub llenar_informacion_excel(ByVal _dt As DataTable)
        Dim ls_sql, ls_sqls As String
        Dim dr, dr_aux As DataRow
        Dim dt, dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Try

            oTrans.open()

            ods_listado.Tables("listado").Rows.Clear()
            If Me.cmb_proveedor.Text = "DISTRIBUIDORA MARTE" Then
                ls_sql = "pa_sel_um_producto 'DMARTE1',NULL"
            Else
                ls_sql = "pa_sel_um_producto '" & Me.cmb_proveedor.Text & "',NULL"
            End If

            ls_sql = "pa_sel_um_producto 'VINOTECA',NULL"
            dt = oTrans.Obtiene(ls_sql)

            dt.DefaultView.RowFilter = "Subfamilia = '" & Me.cmb_proveedor.Text & "'"
            dt = dt.DefaultView.ToTable

            For Each dr In _dt.Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo") & "'"
                If dt.DefaultView.Count > 0 Then
                    Try
                        dr_aux = ods_listado.Tables("listado").NewRow
                        dr_aux.Item("producto") = dr.Item("codigo")
                        dr_aux.Item("glosa") = dr.Item("descripcion")
                        dr_aux.Item("subfamilia") = Me.cmb_proveedor.Text
                        dr_aux.Item("stockminimo") = 0
                        dr_aux.Item("stockmaximo") = dr.Item("cantidad")
                        dr_aux.Item("modificado") = 1
                        ods_listado.Tables("listado").Rows.Add(dr_aux)
                    Catch ex As Exception
                    End Try
                End If
            Next
            Me.dgv_productos.DataSource = ods_listado.Tables("listado")
            clsgen.Alinear_GridView(dt, dgv_productos, ",producto,glosa,subfamilia,stockminimo,stockmaximo,existenciacd,", "", ",producto,glosa,subfamilia,", "", "", ",Glosa=400,subfamilia=150,", "", True, True, 175, 0)
            Me.dgv_productos.ForeColor = Color.Black
            Me.dgv_productos.Refresh()

        Catch ex As Exception
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try


    End Sub
    Private Sub frm_producto_bodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combos()
        crear_estructura()
        llenar_informacion()

    End Sub



    Private Sub txt_filtro1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", Me.txt_filtro1.Text, "", "", Me.cmb_1.Text, "", "", Me.txt_filtro1.Text, "")
        clsgen = Nothing
        ods_listado.Tables("listado").DefaultView.RowFilter = ls_filtro
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_movimiento()
    End Sub

    Private Sub guardar_movimiento()
        Dim ls_sql, ls_sqls, ls_ssql, tipodocto As String
        Dim dt, dt1 As DataTable
        'Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()
            ods_listado.Tables("listado").DefaultView.RowFilter = "modificado=1"

            If ods_listado.Tables("listado").DefaultView.Count > 0 Then
                For Each drv2 As DataRowView In ods_listado.Tables("listado").DefaultView
                    Try
                        If drv2.Item("stockmaximo").ToString <> "" And drv2.Item("stockminimo").ToString <> "" Then
                            If Val(drv2.Item("stockmaximo")) >= 0 Then 'And Val(dr.Item("stockminimo")) < Val(dr.Item("stockmaximo")) Then
                                'buscar el producto en la tabla prodbodegas
                                ls_sql = "pa_sel_um_prodbodegas_verifica '" & gs_empresa & "','" & Me.Pbodega & "','" & drv2.Item("producto") & "'"
                                dt = Otrans.Obtiene(ls_sql)
                                If dt.Rows.Count > 0 Then
                                    'actualiza
                                    ls_sql = "pa_upd_um_prodbodegas '" & gs_empresa & "','" & Me.Pbodega & "','" & drv2.Item("producto") & "'," & _
                                                                            drv2.Item("stockminimo") & "," & drv2.Item("stockmaximo")
                                    Otrans.Actualiza(ls_sql)
                                Else
                                    'ingresa
                                    ls_sql = "pa_ins_um_prodbodegas '" & gs_empresa & "','" & drv2.Item("producto") & "','" & Me.Pbodega & "',0," & _
                                                                             drv2.Item("stockminimo") & "," & drv2.Item("stockmaximo") & ",NULL"
                                    Otrans.Ingresa(ls_sql)
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                MessageBox.Show("Informacion Guardada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        hacer_filtro()
    End Sub



    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click

        ImportarExcel()
        llenar_informacion_excel(_dtregistros)
    End Sub

    '''''''codigo nuevo
    Private Sub ImportarExcel()

        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados() As String

        Try
            ods_listado.Tables("listado").Rows.Clear()


            Me.OFD_Listas.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OFD_Listas.FileName = ""
            Me.OFD_Listas.ShowDialog()

            snombre_archivo = Me.OFD_Listas.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas
            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If

            hojas_encabezados = Oaut.obtenerEncabezados

            Dim listaencabezado As New StringBuilder
            For Each encabezado As String In hojas_encabezados
                If Not encabezado Is Nothing Then listaencabezado.Append("," & encabezado)
            Next
            encabezados_seleccionados = listaencabezado.ToString

            Oaut.pNombreColumnas = encabezados_seleccionados

            _dtregistros = Oaut.obtener_registros_nombres()

        Catch ex As Exception
        Finally
            Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try
    End Sub

    Private Sub txt_filtro1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_filtro1.TextChanged

    End Sub

    Private Sub frm_carga_stock_tienda_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not ods.Tables.Contains("usuario_activo") Then
            MessageBox.Show("Usted no tiene permisos para Ingreso de Stock.", "Sin permisos Asignados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            If ods.Tables("usuario_activo").Rows.Count <= 0 Then
                'MessageBox.Show("Usted no tiene permisos para Ingreso de Stock", "Sin permisos Asignados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Me.Close()
            End If
        End If
    End Sub


    Private Sub hacer_filtro_proveedores()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro("SUBFAMILIA", "", "", Me.cmb_proveedor.SelectedValue.ToString, "", "", "=", "", "", Me.cmb_proveedor.SelectedValue.ToString, "")
        clsgen = Nothing
        Try
            ods_listado.Tables("listado").DefaultView.RowFilter = ls_filtro
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmb_proveedor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectedValueChanged
        hacer_filtro_proveedores()

    End Sub

    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgv_productos.Rows(rowIndex)

                If Me.dgv_productos.Columns(colIndex).Name.ToLower = "stockmaximo" Then
                    If Me.dgv_productos.Item("modificado", e.RowIndex).Value.ToString = 1 Then
                        Me.dgv_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub



    Private Sub dgv_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellValueChanged
        Dim rowIndex As Integer = e.RowIndex
        Dim colIndex As Integer = e.ColumnIndex
        If e.ColumnIndex = 4 Then
            Me.dgv_productos.Item("modificado", e.RowIndex).Value = 1
        End If
    End Sub

    Private Sub cmb_proveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectedIndexChanged

    End Sub

    Private Sub dgv_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellContentClick

    End Sub
End Class