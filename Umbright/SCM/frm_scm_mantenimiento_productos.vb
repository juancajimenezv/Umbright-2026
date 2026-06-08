Public Class frm_scm_mantenimiento_productos
    Inherits System.Windows.Forms.Form
    Dim ds_productos As DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOrigen As System.Windows.Forms.Button
    Friend WithEvents lblAsociados As System.Windows.Forms.Label
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_origen As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_mantenimiento_productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_generar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_origen = New System.Windows.Forms.ComboBox
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.dgv_productos = New System.Windows.Forms.DataGridView
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOrigen = New System.Windows.Forms.Button
        Me.lblAsociados = New System.Windows.Forms.Label
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Location = New System.Drawing.Point(264, 48)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(80, 23)
        Me.btn_generar.TabIndex = 12
        Me.btn_generar.Text = "Generar"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Origen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Proveedor"
        '
        'cmb_origen
        '
        Me.cmb_origen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_origen.Location = New System.Drawing.Point(88, 48)
        Me.cmb_origen.Name = "cmb_origen"
        Me.cmb_origen.Size = New System.Drawing.Size(160, 21)
        Me.cmb_origen.TabIndex = 9
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.Location = New System.Drawing.Point(88, 24)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(352, 21)
        Me.cmb_proveedor.TabIndex = 8
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(821, 0)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(88, 64)
        Me.btn_guardar.TabIndex = 14
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "home.ico")
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(733, 0)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(88, 64)
        Me.btn_exportar.TabIndex = 14
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'dgv_productos
        '
        Me.dgv_productos.AllowUserToAddRows = False
        Me.dgv_productos.AllowUserToDeleteRows = False
        Me.dgv_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_productos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_productos.Location = New System.Drawing.Point(0, 77)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.RowHeadersVisible = False
        Me.dgv_productos.Size = New System.Drawing.Size(944, 422)
        Me.dgv_productos.TabIndex = 15
        '
        'cmb_empresa
        '
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(88, 1)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(170, 21)
        Me.cmb_empresa.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Empresa"
        '
        'btnOrigen
        '
        Me.btnOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrigen.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOrigen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigen.ForeColor = System.Drawing.Color.White
        Me.btnOrigen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOrigen.ImageIndex = 2
        Me.btnOrigen.ImageList = Me.ImageList1
        Me.btnOrigen.Location = New System.Drawing.Point(646, 0)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(88, 64)
        Me.btnOrigen.TabIndex = 14
        Me.btnOrigen.Text = "Asociar Origen"
        Me.btnOrigen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOrigen.UseVisualStyleBackColor = False
        '
        'lblAsociados
        '
        Me.lblAsociados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAsociados.AutoSize = True
        Me.lblAsociados.Location = New System.Drawing.Point(374, 55)
        Me.lblAsociados.Name = "lblAsociados"
        Me.lblAsociados.Size = New System.Drawing.Size(111, 13)
        Me.lblAsociados.TabIndex = 17
        Me.lblAsociados.Text = "Producto Asociados 0"
        '
        'frm_scm_mantenimiento_productos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(944, 501)
        Me.Controls.Add(Me.lblAsociados)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.dgv_productos)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_origen)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.btnOrigen)
        Me.Controls.Add(Me.btn_exportar)
        Me.Name = "frm_scm_mantenimiento_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Mantenimiento de Productos .::"
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Llenar_Empresa()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_empresa.DataSource = dt
            Me.cmb_empresa.DisplayMember = "empresa"
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.SelectedValue = gs_empresa

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General

        Try
            otrans.open()

            ls_sql = "pa_sel_um_prv_proveedor '" & Me.cmb_empresa.SelectedValue.ToString & "'"
            dt = otrans.Obtiene(ls_sql)

            dt = ClsGen.ValoresDistinto(dt, "proveedor".Split(","))
            dt.TableName = "proveedores"
            If ds_productos.Tables.Contains("proveedores") Then
                ds_productos.Tables.Remove("proveedores")
            End If

            ds_productos.Tables.Add(dt.Copy)
            Me.cmb_proveedor.DataSource = ds_productos.Tables("proveedores")
            Me.cmb_proveedor.ValueMember = "proveedor"
            Me.cmb_proveedor.DisplayMember = "proveedor"

            ls_sql = "pa_var_um_proveedor_procedencia '" & Me.cmb_empresa.SelectedValue.ToString & "','" & _
                        IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "origenes"

            If ds_productos.Tables.Contains("origenes") Then ds_productos.Tables.Remove("origenes")

            ds_productos.Tables.Add(dt.Copy)

            ds_productos.Tables("origenes").DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.SelectedValue & "'"
            Me.cmb_origen.DataSource = ds_productos.Tables("origenes")
            Me.cmb_origen.DisplayMember = "procedencia"
            Me.cmb_origen.ValueMember = "procedencia"


            dt = New DataTable("tipo_manejo")

            dt.Columns.Add(New DataColumn("manejo", GetType(String)))
            Dim dr As DataRow
            dr = dt.NewRow
            dr.Item("manejo") = "Pallet"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr.Item("manejo") = "Layer"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr.Item("manejo") = "Cajas"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr.Item("manejo") = ""
            dt.Rows.Add(dr)




            If ds_productos.Tables.Contains("tipo_manejo") Then ds_productos.Tables.Remove("tipo_manejo")
            ds_productos.Tables.Add(dt.Copy)

            ''Parametros Generales
            ls_sql = "pa_sel_um_scm_parametros_generales"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "scm_parametros_generales"
            ds_productos.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Buscar_Productos()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim ClsGen As New ClasesGenerales.General
        Dim dgtbc As New DataGridViewComboBoxColumn

        Try
            Otrans.open()
            Me.dgv_productos.DataSource = Nothing


            ls_sql = "pa_sel_um_inv_producto '" & Me.cmb_empresa.SelectedValue.ToString & "','" & _
                     Me.cmb_proveedor.Text & "','" & _
                     Me.cmb_origen.Text & "',NULL,null,'" & _
                     IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "productos"
            If ds_productos.Tables.IndexOf("productos") > -1 Then
                ds_productos.Tables.Remove("productos")
            End If

            dt.Columns.Add(New DataColumn("fob", GetType(Double)))
            dt.Columns.Add(New DataColumn("modificado", GetType(Int16)))

            dt.DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.Text & "' and procedencia = '" & Me.cmb_origen.Text & "'"

            dt = dt.DefaultView.ToTable
            ds_productos.Tables.Add(dt.Copy)

            Generar_Precios()

            dgtbc.DataSource = ds_productos.Tables("tipo_manejo")
            dgtbc.ValueMember = "manejo"
            dgtbc.DisplayMember = "manejo"
            dgtbc.HeaderText = "Unidad Compra"
            dgtbc.DataPropertyName = "tipo_manejo"
            dgtbc.Name = "tipo_manejo"



            Me.dgv_productos.DataSource = ds_productos.Tables("productos")
            ClsGen.Alinear_GridViewComboBox(dgtbc)
            ClsGen.Alinear_GridView(ds_productos.Tables("productos"), Me.dgv_productos, _
                                    ",producto,glosa,uxc,volumen,tipo_manejo,cajas_por_layer,volumen_cubico_caja,peso_bruto_caja,pareto,comprar,fob,cajas_por_pallet,minimo_compra,Codigo_Proveedor,minimo_compra_standard,", _
                                    ",procedencia,subfamilia,modifico,", ",producto,glosa,uxc,volumen,pareto,peso_bruto_cajas,volumen_cubico_caja,", ",volumen,volumen_cubico_caja,peso_bruto_caja,", _
                                    ",tipo_manejo=unidad_compra,volumen_cubico_caja=volumen3,peso_bruto_caja=peso,", ",minimo_compra=50,volumen_cubico_caja=80,uxc=50,peso_bruto_caja=80,pareto=40,tipo_manejo=70,cajas_por_pallet=70,cajas_por_layer=70,", _
                                    ",producto,glosa,comprar,uxc,tipo_manejo,minimo_compra,cajas_por_layer,cajas_por_pallet,fob,volumen_cubico_caja,peso_bruto_caja,pareto,", True, True, 250, 50)

            For Each dc As DataGridViewColumn In Me.dgv_productos.Columns
                If dc.Name = "volumen_cubico_caja" Then
                    dc.DefaultCellStyle.Format = "n7"
                ElseIf dc.Name = "precio_fob" Then
                    dc.DefaultCellStyle.Format = "n4"
                ElseIf dc.Name = "peso_bruto_caja" Then
                    dc.DefaultCellStyle.Format = "n4"
                End If

            Next




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Generar_Precios()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General

        Dim ls_sql As String


        Try
            otrans.open()
            Dim dtunicos As DataTable = clsgen.ValoresDistinto(ds_productos.Tables("productos"), "empresa".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_sel_um_listaprecioD '" & dr_aux.Item("empresa") & "',NULL,'" & _
                        ds_productos.Tables("scm_parametros_generales").Rows(0).Item("lista_precio").ToString & "'"


                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    ds_productos.Tables("productos").DefaultView.RowFilter _
                                        = "producto = '" & dr.Item("producto") & "' and subfamilia = '" & dr.Item("proveedor") & "'"

                    If ds_productos.Tables("productos").DefaultView.Count > 0 Then
                        drv = ds_productos.Tables("productos").DefaultView(0)

                        'If dr.Item("meses_diferencia") <= 0 + pi_meses_adicionales Then
                        drv.Item("fob") = dr.Item("valor") * drv.Item("uxc")
                        'Else

                        '  ls_mes = "transito+" & (dr.Item("meses_diferencia") + pi_meses_adicionales).ToString.PadLeft(2, "0")
                        ' drv.Item(ls_mes) = drv.Item(ls_mes) + dr.Item("cajas_pedidas")
                    End If
                    'End If
                Next
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ds_productos.Tables("productos").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub Guardar_Informacion()
        Dim ls_sql As String

        Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()


          

            ds_productos.Tables("productos").DefaultView.RowFilter = "modificado = 1"
            For Each drv As DataRowView In ds_productos.Tables("productos").DefaultView

                'ls_sql = "pa_del_um_inv_producto '" & Me.cmb_empresa.SelectedValue.ToString & "','" & _
                '             Me.cmb_proveedor.Text & "','" & _
                '             Me.cmb_origen.Text & "','" & drv.Item("producto").ToString & "'"

                'Otrans.Elimina(ls_sql)

                ls_sql = "pa_ins_um_inv_producto '" & Me.cmb_empresa.SelectedValue.ToString & "','" & drv.Item("producto").ToString & "','" & _
                        drv.Item("tipo_manejo").ToString & "','" & drv.Item("tipo_pallet").ToString & "'," & _
                        IIf(drv.Item("layer_por_pallet").ToString.Length = 0, 0, drv.Item("layer_por_pallet").ToString) & "," & _
                        IIf(drv.Item("cajas_por_layer").ToString.Length = 0, 0, drv.Item("cajas_por_layer").ToString) & "," & _
                        IIf(drv.Item("comprar") = True, 1, 0) & "," & _
                        IIf(drv.Item("cajas_por_pallet").ToString.Length = 0, 0, drv.Item("cajas_por_pallet").ToString) & "," & _
                        IIf(drv.Item("minimo_compra").ToString.Length = 0, 0, drv.Item("minimo_compra").ToString) & ",'" & _
                        gs_usuario & "'," & _
                        IIf(drv.Item("minimo_compra_standard").ToString.Length = 0, 0, drv.Item("minimo_compra_standard").ToString)

                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show(Otrans.descripcion_error)
                End If
            Next

            ds_productos.Tables("productos").DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_InformacionOld()
        Dim ls_sql As String

        Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()


            ls_sql = "pa_del_um_inv_producto '" & Me.cmb_empresa.SelectedValue.ToString & "','" & _
                         Me.cmb_proveedor.Text & "','" & _
                         Me.cmb_origen.Text & "'"

            Otrans.Elimina(ls_sql)
            For Each dr In ds_productos.Tables("productos").Rows
                ls_sql = "pa_ins_um_inv_producto '" & Me.cmb_empresa.SelectedValue.ToString & "','" & dr.Item("producto").ToString & "','" & _
                        dr.Item("tipo_manejo").ToString & "','" & dr.Item("tipo_pallet").ToString & "'," & _
                        IIf(dr.Item("layer_por_pallet").ToString.Length = 0, 0, dr.Item("layer_por_pallet").ToString) & "," & _
                        IIf(dr.Item("cajas_por_layer").ToString.Length = 0, 0, dr.Item("cajas_por_layer").ToString) & "," & _
                        IIf(dr.Item("comprar") = True, 1, 0) & "," & _
                        IIf(dr.Item("cajas_por_pallet").ToString.Length = 0, 0, dr.Item("cajas_por_pallet").ToString) & "," & _
                        IIf(dr.Item("minimo_compra").ToString.Length = 0, 0, dr.Item("minimo_compra").ToString)

                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show(Otrans.descripcion_error)
                End If

            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Inicializar()
        ds_productos = New DataSet
        newcurrentrow = -1
        newcurrentcol = -1
    End Sub

    Private Sub aplicarSeguridad()

        Me.btn_guardar.Visible = tiene_permisos("mci_scm_grabar_mantenimiento_productos")



    End Sub

    Private Sub frm_scm_mantenimiento_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializar()
        Llenar_Empresa()
        Llenar_Combos()
        aplicarSeguridad()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Buscar_Productos()
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        ds_productos.Tables("origenes").DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.SelectedValue & "'"
    End Sub

  
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro de Actualizar la Informacion", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Guardar_Informacion()
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim Oaut As New Automatizar.exportar_excel
        Oaut.ocultar_columnas = ",procedencia,subfamilia"
        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

        Oaut.Nombre_Columnas = "," ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"


        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ds_productos.Tables("productos"))
        Oaut = Nothing
    End Sub



    Private Sub cmb_empresa_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectionChangeCommitted
        Llenar_Combos()
    End Sub

    Private Sub dg_productos_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs)

    End Sub

    Private Sub dgv_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellContentClick

    End Sub

    Private Sub dgv_productos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellEndEdit
        Try
            dgv_productos.Item("modificado", e.RowIndex).Value = 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try
            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_productos.Rows(rowIndex)

                If therow.Cells("comprar").Value.ToString().ToLower = "true" Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellValueChanged
        

    End Sub

    Private Sub dgv_productos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_productos.DataError
        MessageBox.Show(e.Exception.Message)
    End Sub

    Private Sub btnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrigen.Click
        Dim oform As New frm_scm_AsignarOrigen
        oform.Show()
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged

    End Sub
End Class
