Public Class frm_enviarProductoOnbase
    Inherits System.Windows.Forms.Form
    Dim ods As New DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.btn_generar = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 64)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(896, 280)
        Me.DataGrid1.TabIndex = 0
        '
        'btn_actualizar
        '
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Location = New System.Drawing.Point(472, 16)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 40)
        Me.btn_actualizar.TabIndex = 1
        Me.btn_actualizar.Text = "Actualizar"
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionVisible = False
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 360)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.Size = New System.Drawing.Size(896, 128)
        Me.DataGrid2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Empresa"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.Location = New System.Drawing.Point(136, 16)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(136, 21)
        Me.cmb_empresa.TabIndex = 3
        Me.cmb_empresa.Text = "ComboBox1"
        '
        'btn_generar
        '
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Location = New System.Drawing.Point(400, 16)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 40)
        Me.btn_generar.TabIndex = 5
        Me.btn_generar.Text = "Generar"
        '
        'frm_actualizacion_productos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(928, 509)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frm_actualizacion_productos"
        Me.Text = "Actualizacion de Productos"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub llenarInformacion(ByVal sempresa As String)
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim clsgen As New ClasesGenerales.General

        ods.Tables.Clear()

        otrans.open()
        ls_sql = "call pa_sel_um_inv_producto (NULL,'" & sempresa & "',NULL)"
        otabla = otrans.Obtiene(ls_sql)



        otabla.TableName = "productos"
        Try
            If ods.Tables.IndexOf("productos") > 0 Then ods.Tables.Remove("productos")


        Catch ex As Exception
        End Try
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_producto_familia"
        otabla = otrans.Obtiene(ls_sql)


        otabla.TableName = "familia"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_tipo_bebidas_todos"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "tipo_bebida"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_pg_pais"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "pg_pais"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_proveedor"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "inv_proveedor"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_producto_marca"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "inv_marca"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_producto_subtipo_todos"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "inv_subtipo"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_pg_empresa"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "pg_empresa"
        ods.Tables.Add(otabla.Copy)

        ls_sql = "call pa_sel_um_inv_producto_cepa"
        otabla = otrans.Obtiene(ls_sql)
        otabla.TableName = "inv_cepa"
        ods.Tables.Add(otabla.Copy)

        otrans.close()
        otrans = Nothing

        Dim otrans2 As New Transaccional.Conexion("flexline")
        otrans2.open()
        ls_sql = "pa_sel_um_producto '" & sempresa & "',NULL"
        otabla = otrans2.Obtiene(ls_sql)

        otrans2.close()
        otrans2 = Nothing


        otabla.TableName = "productos_flex"
        ods.Tables.Add(otabla.Copy)


        Me.DataGrid1.DataSource = ods.Tables("productos_flex")
        Me.DataGrid2.DataSource = ods.Tables("productos")

    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion_mysql("onBase")

        Try
            Otrans.open()
            ls_sql = "call pa_sel_um_pg_empresa ()"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pg_empresas"

            Me.cmb_empresa.DataSource = dt
            Me.cmb_empresa.ValueMember = "cod_empresa"
            Me.cmb_empresa.DisplayMember = "descripcion"

            ods.Tables.Add(dt.Copy)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub frm_actualizacion_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
    End Sub

    Private Sub Ingresar_Producto_Nuevo(ByVal pdr As DataRow, ByVal sEmpresa As String)

        Dim ls_sql As String
        Dim ls_filtro As String
        Dim lbingresar As Boolean = True
        Dim ls_aux As String
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            otrans.open()



            ls_sql = "call pa_ins_um_inv_producto (" & ClsGen.Codigo_Empresa_Onbase(sEmpresa) & ",'" & _
                            pdr.Item("producto") & "','" & _
                            pdr.Item("glosa").ToString.Replace("'", "") & "',"           ''Descripcion


            If pdr.Item("producto") = "0200100311" Then
                pdr.Item("producto") = pdr.Item("producto")
            End If

            ''tipo producto
            ls_filtro = "trim(descripcion) = '" & pdr.Item("tipoproducto") & "'"
            ods.Tables("tipo_bebida").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_tipo.SelectedValue = odataset.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida").ToString()
                'dr.Item("cod_tipo") = ods.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida")
                ls_sql = ls_sql & ods.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida") & ","
            Catch ex As Exception
                lbingresar = False
                ClsGen.Escribir_texto("c:\aplicaciones\log.txt", "tipo bebida " & ls_filtro & vbCrLf)
                'MessageBox.Show("tipo producto " & ls_filtro)
            End Try


            ''Familia
            ls_filtro = "trim(descripcion) = '" & pdr.Item("familia") & "'"
            ods.Tables("familia").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_familia.SelectedValue = odataset.Tables("familia").DefaultView(0)("cod_familia").ToString
                'dr.Item("cod_familia") = ods.Tables("familia").DefaultView(0)("cod_familia")
                ls_sql = ls_sql & ods.Tables("familia").DefaultView(0)("cod_familia") & ","
            Catch ex As Exception
                lbingresar = False
                ClsGen.Escribir_texto("c:\aplicaciones\log.txt", "familia " & ls_filtro & vbCrLf)

                'MessageBox.Show("Familia " & ls_filtro)
            End Try

            ''proveedor
            ls_filtro = "trim(descripcion) = '" & pdr.Item("subfamilia") & "'"
            ods.Tables("inv_proveedor").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_proveedor.SelectedValue = odataset.Tables("inv_proveedor").DefaultView(0)("cod_proveedor").ToString
                'dr.Item("cod_proveedor") = ods.Tables("inv_proveedor").DefaultView(0)("cod_proveedor")
                ls_sql = ls_sql & ods.Tables("inv_proveedor").DefaultView(0)("cod_proveedor") & ","
            Catch ex As Exception
                lbingresar = False
                ClsGen.Escribir_texto("c:\aplicaciones\log.txt", "inv_proveedor " & ls_filtro & vbCrLf)
                'MessageBox.Show("proveedor " & ls_filtro)
            End Try

            ''marca
            ls_filtro = "trim(descripcion) = '" & pdr.Item("tipo") & "'"
            ods.Tables("inv_marca").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_marca.SelectedValue = odataset.Tables("inv_marca").DefaultView(0)("cod_marca").ToString
                'dr.Item("cod_marca") = ods.Tables("inv_marca").DefaultView(0)("cod_marca")
                ls_sql = ls_sql & ods.Tables("inv_marca").DefaultView(0)("cod_marca") & ","
            Catch ex As Exception
                lbingresar = False
                'MessageBox.Show("Marca " & ls_filtro)
                ClsGen.Escribir_texto("c:\aplicaciones\log.txt", "inv_marca " & ls_filtro & vbCrLf)
            End Try

            ''sub tipo
            ls_filtro = "trim(descripcion) = '" & pdr.Item("subtipo") & "'"
            ods.Tables("inv_subtipo").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_sub_tipo.SelectedValue = odataset.Tables("inv_subtipo").DefaultView(0)("cod_subtipo").ToString
                'dr.Item("cod_subtipo") = ods.Tables("inv_subtipo").DefaultView(0)("cod_subtipo")
                ls_sql = ls_sql & ods.Tables("inv_subtipo").DefaultView(0)("cod_subtipo") & ","
            Catch ex As Exception
                lbingresar = False
                'MessageBox.Show("Sub Tipo " & ls_filtro)
                If pdr.Item("subtipo").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_subtipo ('" & pdr.Item("subtipo").ToString & "')"
                    otrans.Ingresa(ls_aux) 'quitar comentario
                End If
            End Try


            ''pais

            'ls_filtro = "pais = '"
            If pdr.Item("procedencia").ToString.ToLower = "usa" Or _
                pdr.Item("procedencia").ToString.ToLower = "miami" Then
                ls_filtro = "pais = 'estados unidos'"
            Else
                ls_filtro = "pais = '" & pdr.Item("procedencia").ToString.ToLower & "'"
            End If


            ods.Tables("pg_pais").DefaultView.RowFilter = ls_filtro
            Try
                'Me.cmb_procedencia.SelectedValue = odataset.Tables("pg_pais").DefaultView(0)("cod_pais").ToString
                'dr.Item("cod_pais") = ods.Tables("pg_pais").DefaultView(0)("cod_pais")
                ls_sql = ls_sql & ods.Tables("pg_pais").DefaultView(0)("cod_pais").ToString & ","
            Catch ex As Exception
                'lbingresar = False
                ClsGen.Escribir_texto("c:\aplicaciones\log.txt", ls_filtro)
                ' MessageBox.Show("Pais " & ls_filtro)
                ls_sql = ls_sql & "1,"
            End Try

            ls_sql = ls_sql & "'','" & _
                        pdr.Item("unidad") & "'," & _
                        pdr.Item("volumen") & "," & _
                        "0,0,'v_000.png','" & _
                        "SARANA" & "','',NULL)"



            If lbingresar Then
                '     MessageBox.Show(ls_sql)
                otrans.Ingresa(ls_sql)
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try


    End Sub

    Public Sub actualizarProductos(ByVal sEmpresa As String)
        Dim dr As DataRow
        Dim drv As DataRowView
        'Dim ls_filtro As String
        Dim dt As DataTable
        Dim lactualizar As Boolean = False
        dt = ods.Tables("productos_flex")
        'Dim ls_sql, ls_aux As String
        Dim oSinc As New Sincronizacion.Envio_Onbase

        For Each dr In dt.Rows

            ods.Tables("productos").DefaultView.RowFilter = "cod_flex = '" & dr.Item("producto") & "'"
            ods.Tables("productos_flex").DefaultView.RowFilter = "producto ='" & dr.Item("producto") & "'"
            If dr.Item("producto") = "0200100283" Then
                dr.Item("producto") = "0200100283"
            End If

            If ods.Tables("productos").DefaultView.Count > 0 Then

                lactualizar = False
                drv = ods.Tables("productos").DefaultView(0)

                oSinc.Actualizar_Onbase(dr, gs_usuario, drv)


                ''''''Descripcion
                ''''If drv.Item("nombre_producto") <> dr.Item("glosa") Then
                ''''    'MessageBox.Show("Actualizar Nombre")
                ''''    drv.Item("nombre_producto") = dr.Item("glosa")
                ''''    lactualizar = True
                ''''    ' Exit For
                ''''End If

                ''''''tipo producto
                ''''If drv.Item("tipo") <> dr.Item("tipoproducto") Then
                ''''    ls_filtro = "trim(descripcion) = '" & dr.Item("tipoproducto") & "'"
                ''''    ods.Tables("tipo_bebida").DefaultView.RowFilter = ls_filtro
                ''''    Try
                ''''        drv.Item("cod_tipo") = ods.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida")
                ''''        lactualizar = True
                ''''    Catch ex As Exception
                ''''        'MessageBox.Show("Actualizar TipoProducto " & ls_filtro)
                ''''        lactualizar = False
                ''''    End Try
                ''''    'Exit For
                ''''End If

                ''''''Familia
                ''''If drv.Item("familia") <> dr.Item("familia") Then
                ''''    ls_filtro = "trim(descripcion) = '" & dr.Item("familia") & "'"
                ''''    ods.Tables("familia").DefaultView.RowFilter = ls_filtro
                ''''    Try
                ''''        drv.Item("cod_familia") = ods.Tables("familia").DefaultView(0)("cod_familia")
                ''''        lactualizar = True
                ''''    Catch ex As Exception
                ''''        'MessageBox.Show("Actualizar Familia " & ls_filtro)
                ''''        lactualizar = False
                ''''    End Try
                ''''End If

                ''''''proveedor
                ''''If drv.Item("proveedor") <> dr.Item("subfamilia") Then
                ''''    ls_filtro = "trim(descripcion) = '" & dr.Item("subfamilia") & "'"
                ''''    ods.Tables("inv_proveedor").DefaultView.RowFilter = ls_filtro
                ''''    Try
                ''''        drv.Item("cod_proveedor") = ods.Tables("inv_proveedor").DefaultView(0)("cod_proveedor")
                ''''        lactualizar = True
                ''''    Catch ex As Exception
                ''''        ' MessageBox.Show("Actualizar Proveedor " & ls_filtro)
                ''''        lactualizar = False
                ''''    End Try
                ''''End If


                ''''''marca
                ''''If drv.Item("marca") <> dr.Item("tipo") Then

                ''''    ls_filtro = "trim(descripcion) = '" & dr.Item("tipo") & "'"
                ''''    ods.Tables("inv_marca").DefaultView.RowFilter = ls_filtro
                ''''    Try
                ''''        drv.Item("cod_marca") = ods.Tables("inv_marca").DefaultView(0)("cod_marca")
                ''''        lactualizar = True
                ''''    Catch ex As Exception
                ''''        ' MessageBox.Show("Actualizar Marca " & ls_filtro)
                ''''        lactualizar = False
                ''''    End Try
                ''''End If

                ''''''sub tipo
                ''''Try
                ''''    If drv.Item("subtipo") <> dr.Item("subtipo") Then
                ''''        ls_filtro = "trim(descripcion) = '" & dr.Item("subtipo") & "'"
                ''''        ods.Tables("inv_subtipo").DefaultView.RowFilter = ls_filtro
                ''''        Try
                ''''            drv.Item("cod_subtipo") = ods.Tables("inv_subtipo").DefaultView(0)("cod_subtipo")
                ''''            lactualizar = True
                ''''        Catch ex As Exception
                ''''            '   MessageBox.Show("Actualizar SubTipo " & ls_filtro)
                ''''            lactualizar = False
                ''''            If dr.Item("subtipo").ToString.Length > 0 Then
                ''''                ls_aux = "call pa_ins_um_inv_subtipo ('" & dr.Item("subtipo").ToString & "')"
                ''''                otrans.Ingresa(ls_aux)
                ''''            End If
                ''''        End Try
                ''''    End If
                ''''Catch ex As Exception

                ''''End Try
                ''''''pais
                ''''If drv.Item("pais").ToString.ToLower <> dr.Item("procedencia").ToString.ToLower Then


                ''''    'ls_filtro = "pais = '" & dr.Item("procedencia") & "'"

                ''''    If dr.Item("procedencia").ToString.ToLower = "usa" Or _
                ''''        dr.Item("procedencia").ToString.ToLower = "miami" Then
                ''''        ls_filtro = "pais = 'estados unidos'"
                ''''    ElseIf dr.Item("procedencia").ToString.ToLower = "rep.dominicana" Then
                ''''        ls_filtro = "pais = 'republica dominicana'"
                ''''    ElseIf dr.Item("procedencia").ToString.ToLower = "sud africa" Then
                ''''        ls_filtro = "pais = 'sudafrica'"
                ''''    ElseIf dr.Item("procedencia").ToString.ToLower = "salvador" Then
                ''''        ls_filtro = "pais = 'el salvador'"
                ''''    Else
                ''''        ls_filtro = "pais = '" & dr.Item("procedencia").ToString.ToLower & "'"
                ''''    End If
                ''''    ods.Tables("pg_pais").DefaultView.RowFilter = ls_filtro
                ''''    Try
                ''''        drv.Item("cod_pais") = ods.Tables("pg_pais").DefaultView(0)("cod_pais")
                ''''        lactualizar = True
                ''''    Catch ex As Exception
                ''''        '  MessageBox.Show("Actualizar Pais de " & ls_filtro)
                ''''        lactualizar = False
                ''''    End Try
                ''''End If

                ''''''estado
                ''''If drv.Item("estado") <> dr.Item("vigente") Then
                ''''    drv.Item("estado") = dr.Item("vigente")
                ''''    lactualizar = True
                ''''End If

                ''''drv.Item("unidad") = dr.Item("unidad")
                ''''drv.Item("volumen") = dr.Item("volumen")

                ''''If lactualizar Then
                ''''    '          MessageBox.Show("Actualizar " & drv.Item("nombre_producto"))
                ''''    ls_sql = "call pa_upd_um_inv_producto_masivo (" & _
                ''''                drv.Item("cod_producto").ToString & ",'" & _
                ''''                drv.Item("nombre_producto").ToString & "'," & _
                ''''                drv.Item("cod_tipo").ToString & "," & _
                ''''                drv.Item("cod_familia").ToString & "," & _
                ''''                drv.Item("cod_proveedor").ToString & "," & _
                ''''                drv.Item("cod_marca").ToString & "," & _
                ''''                drv.Item("cod_subtipo").ToString & "," & _
                ''''                drv.Item("cod_pais").ToString & ",'" & _
                ''''                drv.Item("unidad").ToString & "'," & _
                ''''                drv.Item("volumen").ToString & ",'" & _
                ''''                ps_usuario & "','" & _
                ''''                drv.Item("estado").ToString & "')"
                ''''    otrans.Actualiza(ls_sql)
                ''''End If

                ''''If drv.Item("plasma") > 0 Then
                ''''    ''Actualizar Precio
                ''''    ls_sql = "pa_sel_um_listaprecioD '" & Me.cmb_empresa.Text & "','" & dr.Item("producto") & "','DIRECTO_1007A'"
                ''''    dt = otrans_flex.Obtiene(ls_sql)
                ''''    If otrans_flex.Codigo_error = 0 And _
                ''''        dt.Rows.Count > 0 Then
                ''''        ls_sql = "call pa_upd_um_plm_opcion (" & drv.Item("cod_producto").ToString & "," & _
                ''''                dt.Rows(0).Item("valor") & ")"
                ''''        otrans.Actualiza(ls_sql)
                ''''    End If
                ''''End If
            Else


                If dr.Item("vigente") = "S" Then
                    If (sEmpresa = "DMARTE1" Or sEmpresa = "CODICASA") Then
                        'And _
                        '    (dr.Item("tipo").ToString = "GUARNICIONES" Or dr.Item("tipo").ToString = "CAJA" _
                        '    Or dr.Item("tipo").ToString = "MONEL" Or dr.Item("tipo").ToString = "CANASTA" Or dr.Item("tipo").ToString = "CAVA") Then
                        '' Or dr.Item("familia").ToString <> "PUBLICIDAD Y PROMO") Then



                        Ingresar_Producto_Nuevo(dr, sEmpresa)
                        '            Dim oSinc As New sincronizacion.Envio_Onbase
                        'oSinc.Insertar_OnBase(Me.cmb_empresa.Text, dr.Item("producto").ToString)

                    ElseIf sEmpresa = "DIMAEXSA" Then
                        If (dr.Item("familia") <> "MATERIA PRIMA" And dr.Item("familia") <> "MATERIAL EMPAQUE") Then
                            Ingresar_Producto_Nuevo(dr, sEmpresa)
                            'oSinc.Insertar_OnBase(Me.cmb_empresa.Text, dr.Item("producto").ToString)
                            '  MessageBox.Show("Producto No Esta en Onbase" & dr.Item("producto"))
                        End If
                    ElseIf sEmpresa = "TECNO" Then
                        Ingresar_Producto_Nuevo(dr, sEmpresa)
                        'oSinc.Insertar_OnBase(Me.cmb_empresa.Text, dr.Item("producto").ToString)
                    ElseIf sEmpresa = "DIUVA" Or sEmpresa = "VINOTECA" Then

                        Ingresar_Producto_Nuevo(dr, sEmpresa)
                    ElseIf sEmpresa = "ALAMSAES" Or sEmpresa = "DIVINOS" Then
                        Ingresar_Producto_Nuevo(dr, sEmpresa)
                    End If

                End If
            End If

        Next
        '    MessageBox.Show("Actualizacion Finalizada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oSinc = Nothing
    End Sub


    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        actualizarProductos(Me.cmb_empresa.Text)
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        llenarInformacion(Me.cmb_empresa.Text)
    End Sub
End Class
