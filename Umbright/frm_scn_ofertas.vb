
Public Class frm_scn_ofertas
    Inherits System.Windows.Forms.Form
    Dim ds_sincronizacion As DataSet
    Public lproductos As Boolean = False
    Friend WithEvents chk_cambios As System.Windows.Forms.CheckedListBox
    Public lproductosmr As Boolean = False

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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_memo As System.Windows.Forms.TextBox
    Friend WithEvents dg_productos As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents lbl_marcar As System.Windows.Forms.Label
    Friend WithEvents clb_tienda As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_memo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scn_ofertas))
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_memo = New System.Windows.Forms.TextBox
        Me.lbl_memo = New System.Windows.Forms.Label
        Me.dg_productos = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chk_cambios = New System.Windows.Forms.CheckedListBox
        Me.clb_tienda = New System.Windows.Forms.CheckedListBox
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_marcar = New System.Windows.Forms.Label
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(80, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 2
        Me.DateTimePicker1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(200, 40)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 3
        Me.DateTimePicker2.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(176, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Al"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Del"
        Me.Label3.Visible = False
        '
        'txt_memo
        '
        Me.txt_memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_memo.Location = New System.Drawing.Point(80, 16)
        Me.txt_memo.Name = "txt_memo"
        Me.txt_memo.Size = New System.Drawing.Size(100, 20)
        Me.txt_memo.TabIndex = 1
        '
        'lbl_memo
        '
        Me.lbl_memo.Location = New System.Drawing.Point(8, 16)
        Me.lbl_memo.Name = "lbl_memo"
        Me.lbl_memo.Size = New System.Drawing.Size(64, 16)
        Me.lbl_memo.TabIndex = 7
        Me.lbl_memo.Text = "Memo"
        '
        'dg_productos
        '
        Me.dg_productos.CaptionVisible = False
        Me.dg_productos.DataMember = ""
        Me.dg_productos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_productos.Location = New System.Drawing.Point(8, 96)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.Size = New System.Drawing.Size(995, 360)
        Me.dg_productos.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_generar)
        Me.GroupBox1.Controls.Add(Me.txt_memo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.lbl_memo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'btn_generar
        '
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(320, 9)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 56)
        Me.btn_generar.TabIndex = 8
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_cambios)
        Me.GroupBox2.Controls.Add(Me.clb_tienda)
        Me.GroupBox2.Controls.Add(Me.btn_actualizar)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(432, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 88)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'chk_cambios
        '
        Me.chk_cambios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chk_cambios.CheckOnClick = True
        Me.chk_cambios.FormattingEnabled = True
        Me.chk_cambios.Items.AddRange(New Object() {"Informacion", "Barras", "Precios"})
        Me.chk_cambios.Location = New System.Drawing.Point(482, 9)
        Me.chk_cambios.Name = "chk_cambios"
        Me.chk_cambios.Size = New System.Drawing.Size(80, 77)
        Me.chk_cambios.TabIndex = 10
        Me.chk_cambios.Visible = False
        '
        'clb_tienda
        '
        Me.clb_tienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clb_tienda.CheckOnClick = True
        Me.clb_tienda.Location = New System.Drawing.Point(56, 9)
        Me.clb_tienda.Name = "clb_tienda"
        Me.clb_tienda.Size = New System.Drawing.Size(339, 77)
        Me.clb_tienda.TabIndex = 9
        '
        'btn_actualizar
        '
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 1
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(401, 16)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 56)
        Me.btn_actualizar.TabIndex = 8
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tiendas"
        '
        'lbl_marcar
        '
        Me.lbl_marcar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_marcar.Location = New System.Drawing.Point(8, 75)
        Me.lbl_marcar.Name = "lbl_marcar"
        Me.lbl_marcar.Size = New System.Drawing.Size(168, 16)
        Me.lbl_marcar.TabIndex = 11
        Me.lbl_marcar.Text = "Marcar/Desmarcar Todos"
        '
        'frm_scn_ofertas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.lbl_marcar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_productos)
        Me.Name = "frm_scn_ofertas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Sincronizacion de Ofertas Con Tiendas .::"
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Crear_Estructura_Productos()
        ds_sincronizacion = New DataSet

        Dim dt As New DataTable("productos")

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("barras", GetType(String)))

        ds_sincronizacion.Tables.Add(dt.Copy)
    End Sub

    Private Sub Crear_Estructura()

        ds_sincronizacion = New DataSet

        Dim dt As New DataTable("traslado")
        dt.Columns.Add(New DataColumn("agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("precio", GetType(Double)))
        dt.Columns.Add(New DataColumn("porcentajemax", GetType(Double)))
        dt.Columns.Add(New DataColumn("listaprecio", GetType(String)))
        dt.Columns.Add(New DataColumn("fechai", GetType(Date)))
        dt.Columns.Add(New DataColumn("fechaf", GetType(Date)))
        dt.Columns.Add(New DataColumn("horai", GetType(String)))
        dt.Columns.Add(New DataColumn("horaf", GetType(String)))
        dt.Columns.Add(New DataColumn("todos", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("porcdescuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("idoferta", GetType(Integer)))
        ds_sincronizacion.Tables.Add(dt.Copy)

    End Sub

    Private Sub Llenar_Combos_onbase()
        Dim ls_sql As String

        Dim dt As DataTable
        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Try


            myOtrans.open()

            ls_sql = "CALL pa_sel_um_pg_ubicacion()"

            'ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & ps_empresa & "'"
            'dt = Otrans.Obtiene(ls_sql)
            dt = myOtrans.Obtiene(ls_sql)

            dt.TableName = "ubicaciones"
            'Ods.Tables.Add(dt.Copy)
            'Ods.Tables("ubicaciones").DefaultView.RowFilter = "nombre_empresa = '" & ps_empresa & "' and traslada_informacion = true"
            dt.DefaultView.RowFilter = "nombre_empresa = '" & gs_empresa & "' and traslada_informacion = true"
            Me.clb_tienda.DataSource = dt.DefaultView 'Ods.Tables("ubicaciones").DefaultView
            Me.clb_tienda.ValueMember = "nombre_bodega" '"codigo"
            Me.clb_tienda.DisplayMember = "descripcion" '"texto5".ToLower


            'Otrans.open()
            'ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & ps_empresa & "'"
            'dt = Otrans.Obtiene(ls_sql)

            'Me.clb_tienda.DataSource = dt
            'Me.clb_tienda.DisplayMember = "DESCRIPCION"
            'Me.clb_tienda.ValueMember = "CODIGO"

        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub


    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim dt As DataTable
        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General


        Try


            'myOtrans.open()

            'ls_sql = "CALL pa_sel_um_pg_ubicacion()"

            ''ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & ps_empresa & "'"
            ''dt = Otrans.Obtiene(ls_sql)
            'dt = myOtrans.Obtiene(ls_sql)

            'dt.TableName = "ubicaciones"
            ''Ods.Tables.Add(dt.Copy)
            ''Ods.Tables("ubicaciones").DefaultView.RowFilter = "nombre_empresa = '" & ps_empresa & "' and traslada_informacion = true"
            'dt.DefaultView.RowFilter = "nombre_empresa = '" & gs_empresa & "' and traslada_informacion = true"
            'Me.clb_tienda.DataSource = dt.DefaultView 'Ods.Tables("ubicaciones").DefaultView
            'Me.clb_tienda.ValueMember = "nombre_bodega" '"codigo"
            'Me.clb_tienda.DisplayMember = "descripcion" '"texto5".ToLower


            ls_sql = "pa_sel_um_pg_ubicacion"

            'ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & ps_empresa & "'"
            'dt = Otrans.Obtiene(ls_sql)
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGEN.selectQuery("corporativo", ls_sql)
            dt.TableName = "ubicaciones"
            'Ods.Tables.Add(dt.Copy)
            'Ods.Tables("ubicaciones").DefaultView.RowFilter = "nombre_empresa = '" & ps_empresa & "' and traslada_informacion = true"
            dt.DefaultView.RowFilter = "nombre_empresa = '" & gs_empresa & "' and traslada_informacion = true"
            Me.clb_tienda.DataSource = dt.DefaultView 'Ods.Tables("ubicaciones").DefaultView
            Me.clb_tienda.ValueMember = "nombre_bodega" '"codigo"
            Me.clb_tienda.DisplayMember = "descripcion" '"texto5".ToLower




        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            'myOtrans.close()
            'myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub


    Private Sub Obtener_Productos()
        Dim ls_sql As String

        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")

        Try
            otrans.open()
            ls_sql = "pa_var_um_productooferta '" & gs_empresa & "',NULL,NULL,'" & Me.txt_memo.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = ds_sincronizacion.Tables("traslado").NewRow

                dr_aux.Item("agregar") = True
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("precio") = dr.Item("precio")
                dr_aux.Item("porcentajemax") = dr.Item("porcentajemax")
                dr_aux.Item("listaprecio") = dr.Item("listaprecio")
                dr_aux.Item("fechai") = dr.Item("fechai")
                dr_aux.Item("fechaf") = dr.Item("fechaf")
                dr_aux.Item("horai") = dr.Item("horai")
                dr_aux.Item("horaf") = dr.Item("horaf")
                dr_aux.Item("todos") = dr.Item("todos")
                dr_aux.Item("ctacte") = dr.Item("ctacte")
                dr_aux.Item("porcdescuento") = dr.Item("porcdescuento")
                dr_aux.Item("idoferta") = dr.Item("idoferta")

                ds_sincronizacion.Tables("traslado").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub Colorear_Grid()
        Dim clGenerales As New ClasesGenerales.General
        Me.dg_productos.DataSource = ds_sincronizacion.Tables("traslado")
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "traslado"

        For Each col As DataColumn In ds_sincronizacion.Tables("traslado").Columns
            If col.ColumnName.ToLower <> "agregar" Then

                Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
                gridCol.MappingName = col.ColumnName

                Select Case col.ColumnName.ToLower.Substring(0, 5)
                    Case "cod_empresa", "serie", "fecha_impresion", "area", "picker"
                        gridCol.Width = 0
                    Case "fecha"
                        gridCol.Width = 70
                    Case "preci"
                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_sincronizacion.Tables("traslado"), " ", col.ColumnName, Me.dg_productos, 200, 0)
                        gridCol.Format = "n"
                        gridCol.Alignment = HorizontalAlignment.Right
                    Case Else
                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_sincronizacion.Tables("traslado"), " ", col.ColumnName, Me.dg_productos, 200, 0)
                End Select
                gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
                gridCol.NullText = ""
                gridCol.ReadOnly = True
                AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
                tableStyle.GridColumnStyles.Add(gridCol)
            Else
                Dim mydatacol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
                                        HorizontalAlignment.Center, _
                                        False, "Agregar", _
                                        String.Empty, False, True, _
                                        False, String.Empty)
                tableStyle.GridColumnStyles.Add(mydatacol)
            End If
        Next
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray
        tableStyle.RowHeaderWidth = 5

        Me.dg_productos.TableStyles.Clear()
        Me.dg_productos.TableStyles.Add(tableStyle)

    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value As Integer


            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = data("agregar")


            If value Then
                e.RowColor = Color.Orange
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Inicializar_Productos_lp()
        Me.lbl_marcar.Visible = False
        Me.lbl_memo.Text = "Producto"
        Me.Text = "::. Sincronizacion de Productos Con Tiendas .::"
        Me.btn_generar.Visible = False
        Crear_Estructura_Productos()
        Me.dg_productos.DataSource = ds_sincronizacion.Tables("productos")
        Me.txt_memo.Focus()
    End Sub

    Private Sub Agregar_Producto_lp()
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim lagregar As Boolean = True

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        For Each dr In ds_sincronizacion.Tables("productos").Rows
            If dr.Item("producto") = Me.txt_memo.Text Then
                lagregar = False
                Exit For
            End If

        Next

        If lagregar Then
            Try
                'ls_sql = "Select producto, count(*) as veces" & _
                '            " from listapreciod  " & _
                '            " where empresa = 'VINOTECA'" & _
                '            " group by producto " & _
                '            " having count(*) > 1"

                otrans.open()

                'dt2 = otrans.Obtiene(ls_sql)
                'For Each dr2 In dt2.Rows
                'Me.txt_memo.Text = dr2.Item("producto")

                ls_sql = "pa_var_um_producto '" & gs_empresa & "','" & Me.txt_memo.Text & "'"

                dt = otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then


                    dr = ds_sincronizacion.Tables("productos").NewRow
                    dr.Item("producto") = Me.txt_memo.Text
                    dr.Item("glosa") = dt.Rows(0).Item("glosa")
                    dr.Item("barras") = dt.Rows(0).Item("CodBarra")
                    ds_sincronizacion.Tables("productos").Rows.Add(dr)

                End If
                'Next


            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing
                ClsGen.Alinea_Grid(ds_sincronizacion.Tables("productos"), Me.dg_productos, ds_sincronizacion.Tables("productos").TableName, -1, 250, 0, False, True, "", True, "")
            End Try

        End If

        otrans = Nothing
        ClsGen = Nothing

    End Sub

    Private Sub Actualizar_Ofertas(ByVal pstienda As String, ByVal psnombre As String)

        Dim dr As DataRow
        Dim lerror As Boolean = False
        Dim sinc As New sincronizacion.Productos(pstienda)

        Try

            For Each dr In ds_sincronizacion.Tables("traslado").Rows
                If dr.Item("agregar") = True Then
                    sinc.Actualizar_Ofertas(gs_empresa, Me.txt_memo.Text, dr)
                    If sinc.codigo_error > 0 Then
                        MessageBox.Show(sinc.descripcion_error)
                        lerror = True
                    End If
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(sinc.descripcion_error)
        Finally
            sinc.Cerrar()
            sinc = Nothing
        End Try
        If lerror Then
            MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Actualizar_Productos(ByVal pstienda As String, ByVal psnombre As String)

        Dim dr As DataRow
        Dim dt, dt_producto As DataTable
        Dim ls_sql As String
        Dim lerror As Boolean = False
        Dim lbprecios As Boolean = False

        Dim sinc As Sincronizacion.Productos
        If pstienda = "SVFB" Then
            sinc = New Sincronizacion.Productos(pstienda, "Fox", True)
        Else
            sinc = New Sincronizacion.Productos(pstienda, "FlexLine")
        End If

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim barranueva As Boolean = False

        Try

            If chk_cambios.GetItemChecked(2) Then lbprecios = True

            otrans.open()


            For Each dr In ds_sincronizacion.Tables("productos").Rows

                ls_sql = "pa_var_um_producto '" & gs_empresa & "','" & dr.Item("producto") & "'"
                dt_producto = otrans.Obtiene(ls_sql)
                If Me.chk_cambios.GetItemChecked(0) Then



                    If gs_empresa = "VINOTECA" And pstienda = "SVFB" Then
                        If pstienda = "SVFB" Then  'FontaBella
                            barranueva = False
                            Try
                                Dim codigo_asignado As String = String.Empty
                                barranueva = sinc.Existe_ProductoBarra_Vinoteca(dt_producto.Rows(0).Item("codigo_barra").ToString, codigo_asignado)
                                If barranueva Then
                                    If codigo_asignado <> dt_producto.Rows(0).Item("codigo_corto") Then
                                        MessageBox.Show("El Codigo de Barra Esta Asociada al Codigo " + codigo_asignado + "  en la Tienda")
                                    End If
                                End If
                            Catch ex As Exception
                            End Try

                            Try
                                sinc.Actualizar_Producto_Vinoteca(dt_producto.Rows(0), IIf(barranueva, 0, 1))
                            Catch ex As Exception
                            End Try
                            If sinc.codigo_error > 0 Then
                                '    MessageBox.Show(" Productos " & sinc.descripcion_error)
                                lerror = True
                            End If

                            If Not barranueva Then
                                Try
                                    sinc.Actualizar_ProductoBarra_Vinoteca(dt_producto)
                                Catch ex As Exception
                                End Try
                                If sinc.codigo_error > 0 Then
                                    MessageBox.Show("Codigos de Barras " & sinc.descripcion_error)
                                    lerror = True
                                Else

                                End If
                                ''Sincronizacion_temporales en onbase
                                ' sincOut.Actualizar_Producto(dt_producto.Rows(0))
                            End If

                        Else

                        End If
                        sinc.Actualizar_Producto(dt_producto.Rows(0))
                    Else
                        sinc.Actualizar_Producto(dt_producto.Rows(0))
                    End If

                End If 'Me.chk_cambios.CheckedItems(0)

                If sinc.codigo_error > 0 Then
                    'MessageBox.Show(" Productos " & sinc.descripcion_error)
                    lerror = True
                End If

                If Me.chk_cambios.GetItemChecked(1) Then
                    ls_sql = "pa_sel_um_prodcodbarra '" & gs_empresa & "','" & dr.Item("producto") & "'"
                    dt = otrans.Obtiene(ls_sql)

                    'If gs_empresa <> "VINOTECA" Then

                    '    sinc.Actualizar_ProductoBarra(dt)

                    '    If sinc.codigo_error > 0 Then
                    '        MessageBox.Show("Codigo Barras " & sinc.descripcion_error)
                    '        lerror = True
                    '    End If

                    'Else
                    If gs_empresa = "VINOTECA" And pstienda = "SVFB" Then
                        dt.DefaultView.RowFilter = "Linea = 3"
                        If dt.DefaultView.Count = 1 Then
                            'sinc = New Sincronizacion.Productos(pstienda, "Fox", True)
                            sinc.Actualizar_ProductoBarra_VinotecaFB(dt.DefaultView(0))
                        End If
                    Else
                        sinc.Actualizar_ProductoBarra(dt)
                    End If

                End If

                If lbprecios Then
                    ls_sql = "pa_var_um_listaprecioD '" & gs_empresa & "','" & dr.Item("producto") & "'"
                    dt = otrans.Obtiene(ls_sql)
                    If gs_empresa = "VINOTECA" And pstienda = "SVFB" Then  ''Fontabella
                        dt.DefaultView.RowFilter = "lisprecio like '%FONTA%' and fec_final > '" & Now & "'"
                        Try
                            If dt.DefaultView.Count = 1 Then
                                ' sinc = New Sincronizacion.Productos(pstienda, "Fox", True)
                                sinc.Actualizar_ProductoPrecio_VinotecaFB(dt.DefaultView(0).Row, dt_producto)
                            End If

                        Catch ex As Exception

                        End Try

                    Else
                        sinc.Actualizar_ProductoPrecio(dt)
                    End If

                If sinc.codigo_error > 0 Then
                    MessageBox.Show("Precios " & sinc.descripcion_error)
                    lerror = True
                End If
                End If


            Next

        Catch ex As Exception
            MessageBox.Show(sinc.descripcion_error)
        Finally
            sinc.Cerrar()
            sinc = Nothing
            otrans.close()
            otrans = Nothing

        End Try
        If lerror Then
            MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Actualizar_ProductosMR(ByVal pcodigo_mr As String, ByVal psnombre As String)

        Dim dr As DataRow

        Dim ls_sql As String
        Dim lerror As Boolean = False
        Dim lbprecios As Boolean = False
        
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try


            myOtrans.open()

            For Each dr In ds_sincronizacion.Tables("productos").Rows


                ls_sql = "call pa_ins_um_bbj_mayorista_productos_aprobados_traslado (" & pcodigo_mr & ",'" & dr.Item("producto") & "','" & _
                          gs_usuario & "')"

                myOtrans.Ingresa(ls_sql)
                If myOtrans.Codigo_error > 0 Then
                    lerror = True
                End If


                ''Actualizo OnBase
            Next

        Catch ex As Exception
            'MessageBox.Show(sinc.descripcion_error)
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        If lerror Then
            MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Sub Generar_informacion()
        Crear_Estructura()
        Obtener_Productos()
        Colorear_Grid()
    End Sub

    Private Sub inicializar_productos_mr()
        Me.lbl_marcar.Visible = False
        Me.lbl_memo.Text = "Producto"
        Me.Text = "::. Sincronizacion de Productos Con MR .::"
        Me.btn_generar.Visible = False
        Crear_Estructura_Productos()
        Me.dg_productos.DataSource = ds_sincronizacion.Tables("productos")
        Me.txt_memo.Focus()

    End Sub

    Private Sub llenar_combos_productos_mr()
        Dim myoTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable

        Dim ls_sql As String

        Try

            myoTrans.open()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myoTrans.Obtiene(ls_sql)

            Me.clb_tienda.DataSource = dt
            Me.clb_tienda.ValueMember = "cod_cliente"
            Me.clb_tienda.DisplayMember = "nombre"
        Catch ex As Exception
        Finally
            myoTrans.close()
            myoTrans = Nothing

        End Try

    End Sub

    Private Sub Actualizar_Productos_Vinoteca_Onbase()

        Dim dr As DataRow
        Dim dt, dt_producto As DataTable
        Dim ls_sql As String
        Dim lerror As Boolean = False


        Dim sincOut As New Sincronizacion.Productos("onbase", "VINOTECA")
        Dim oSincOB As New Sincronizacion.Envio_Onbase
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try


            otrans.open()
            myOtrans.open()

            For Each dr In ds_sincronizacion.Tables("productos").Rows

                ls_sql = "pa_var_um_producto '" & gs_empresa & "','" & dr.Item("producto") & "'"
                dt_producto = otrans.Obtiene(ls_sql)

                If gs_empresa = "VINOTECA" Then
                    ''Sincronizacion_temporales en onbase
                    sincOut.Actualizar_Producto(dt_producto.Rows(0))
                End If


                If sincOut.codigo_error > 0 Then
                    MessageBox.Show(" Productos " & sincOut.descripcion_error)
                    lerror = True
                End If


                ls_sql = "pa_sel_um_prodcodbarra '" & gs_empresa & "','" & dr.Item("producto") & "'"
                dt = otrans.Obtiene(ls_sql)

                If gs_empresa = "VINOTECA" Then
                    sincOut.Actualizar_ProductoBarra(dt)
                End If


                ''Actualizo OnBase
                ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','" & dr.Item("producto") & "')"
                dt = myOtrans.Obtiene(ls_sql)
                If dt.Rows.Count = 0 Then
                    oSincOB.Insertar_OnBase(gs_empresa, dr.Item("producto"))
                Else
                    oSincOB.Actualizar_Onbase(dr, gs_usuario)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(sincOut.descripcion_error)
        Finally
            otrans.close()
            otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            oSincOB = Nothing

            Try
                sincOut.Cerrar()
            Catch ex As Exception
            End Try
            sincOut = Nothing
        End Try

    End Sub

    Private Sub frm_sincronizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        If lproductos Then
            Inicializar_Productos_lp()
            Me.chk_cambios.Visible = True
        ElseIf lproductosmr Then
            inicializar_productos_mr()
            llenar_combos_productos_mr()
        End If

    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Generar_informacion()
    End Sub

    'marcar todos
    Private Sub lbl_marcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_marcar.Click
        Dim dr As DataRow
        For Each dr In ds_sincronizacion.Tables("traslado").Rows
            dr.Item("agregar") = Not dr.Item("agregar")
            Me.lbl_marcar.Font.Bold.ToString()
        Next
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Dim icount As Integer

        If MessageBox.Show("Esta Seguro de Realizar Esta Actualizacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For icount = 0 To Me.clb_tienda.Items.Count() - 1
                If Me.clb_tienda.GetItemChecked(icount) Then

                    'MessageBox.Show(clb_tienda.Items(icount)("CODIGO"))
                    If lproductos Then
                        Actualizar_Productos(clb_tienda.Items(icount)("nombre_bodega"), clb_tienda.Items(icount)("DESCRIPCION"))

                    ElseIf lproductosmr Then
                        Actualizar_ProductosMR(clb_tienda.Items(icount)("cod_cliente"), clb_tienda.Items(icount)("nombre"))
                    Else
                        Actualizar_Ofertas(clb_tienda.Items(icount)("nombre_bodega"), clb_tienda.Items(icount)("DESCRIPCION"))
                    End If

                End If
            Next
            'If gs_empresa = "VINOTECA" Then
            '    Actualizar_Productos_Vinoteca_Onbase()
            'End If
        End If
    End Sub

    Private Sub txt_memo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_memo.KeyPress
        'Enter
        If Asc(e.KeyChar()) = 13 Then
            If lproductos Or lproductosmr Then
                Agregar_Producto_lp()
                Me.txt_memo.SelectAll()
            End If
        End If

    End Sub

    Private Sub txt_memo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_memo.TextChanged

    End Sub
End Class
