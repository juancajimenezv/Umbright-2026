Imports System.IO
Public Class frm_maq_etiquetas_materiales
    Inherits System.Windows.Forms.Form
    Dim Ods As DataSet
    Dim simagen1, simagen2 As String
    Dim ls_codigo As String
    Dim Pcorrelativo As Integer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents dg_detalle_pack_insumos As System.Windows.Forms.DataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents dgv_listado As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_filtro1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo_listado As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Menu_Maquila As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Mant_Materiales_Auxiliares As System.Windows.Forms.MenuItem
    Dim Pproducto As String = ""




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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_etiquetas_materiales))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.btn_ayuda = New System.Windows.Forms.Button
        Me.dg_detalle_pack_insumos = New System.Windows.Forms.DataGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_total_costo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_nuevo_listado = New System.Windows.Forms.Button
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.dgv_listado = New System.Windows.Forms.DataGridView
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox
        Me.cmb_1 = New System.Windows.Forms.ComboBox
        Me.txt_filtro1 = New System.Windows.Forms.TextBox
        Me.Menu_Maquila = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Mant_Materiales_Auxiliares = New System.Windows.Forms.MenuItem
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "pack.png")
        Me.ImageList1.Images.SetKeyName(2, "pack2.png")
        Me.ImageList1.Images.SetKeyName(3, "3.png")
        Me.ImageList1.Images.SetKeyName(4, "grafica1.png")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(668, 346)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.ForeColor = System.Drawing.Color.Black
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(660, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Materiales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.txt_descripcion)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda)
        Me.GroupBox1.Controls.Add(Me.dg_detalle_pack_insumos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_total_costo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 288)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.ImageIndex = 1
        Me.btn_nuevo.Location = New System.Drawing.Point(468, 21)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(71, 24)
        Me.btn_nuevo.TabIndex = 54
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.Location = New System.Drawing.Point(387, 22)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 53
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(112, 50)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(427, 22)
        Me.txt_descripcion.TabIndex = 50
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(112, 23)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(88, 22)
        Me.txt_producto.TabIndex = 48
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(206, 23)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(26, 22)
        Me.btn_ayuda.TabIndex = 49
        Me.btn_ayuda.Text = "..."
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'dg_detalle_pack_insumos
        '
        Me.dg_detalle_pack_insumos.CaptionVisible = False
        Me.dg_detalle_pack_insumos.DataMember = ""
        Me.dg_detalle_pack_insumos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_detalle_pack_insumos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pack_insumos.Location = New System.Drawing.Point(9, 125)
        Me.dg_detalle_pack_insumos.Name = "dg_detalle_pack_insumos"
        Me.dg_detalle_pack_insumos.Size = New System.Drawing.Size(530, 135)
        Me.dg_detalle_pack_insumos.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Producto"
        '
        'txt_total_costo
        '
        Me.txt_total_costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_costo.Location = New System.Drawing.Point(419, 97)
        Me.txt_total_costo.Name = "txt_total_costo"
        Me.txt_total_costo.ReadOnly = True
        Me.txt_total_costo.Size = New System.Drawing.Size(120, 22)
        Me.txt_total_costo.TabIndex = 47
        Me.txt_total_costo.TabStop = False
        Me.txt_total_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Total Costo:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btn_nuevo_listado)
        Me.TabPage2.Controls.Add(Me.btn_buscar)
        Me.TabPage2.Controls.Add(Me.dgv_listado)
        Me.TabPage2.Controls.Add(Me.cmb_valor1)
        Me.TabPage2.Controls.Add(Me.cmb_1)
        Me.TabPage2.Controls.Add(Me.txt_filtro1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(660, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado Productos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btn_nuevo_listado
        '
        Me.btn_nuevo_listado.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_listado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_listado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_listado.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_listado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo_listado.ImageIndex = 1
        Me.btn_nuevo_listado.Location = New System.Drawing.Point(578, 9)
        Me.btn_nuevo_listado.Name = "btn_nuevo_listado"
        Me.btn_nuevo_listado.Size = New System.Drawing.Size(72, 21)
        Me.btn_nuevo_listado.TabIndex = 2
        Me.btn_nuevo_listado.Text = "&Nuevo"
        Me.btn_nuevo_listado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo_listado.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 1
        Me.btn_buscar.Location = New System.Drawing.Point(500, 9)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 21)
        Me.btn_buscar.TabIndex = 1
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'dgv_listado
        '
        Me.dgv_listado.AllowUserToAddRows = False
        Me.dgv_listado.AllowUserToDeleteRows = False
        Me.dgv_listado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado.Location = New System.Drawing.Point(23, 36)
        Me.dgv_listado.Name = "dgv_listado"
        Me.dgv_listado.RowHeadersWidth = 20
        Me.dgv_listado.Size = New System.Drawing.Size(627, 242)
        Me.dgv_listado.TabIndex = 99
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(23, 6)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 24)
        Me.cmb_valor1.Sorted = True
        Me.cmb_valor1.TabIndex = 96
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(133, 6)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(40, 24)
        Me.cmb_1.TabIndex = 97
        '
        'txt_filtro1
        '
        Me.txt_filtro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_filtro1.Location = New System.Drawing.Point(179, 8)
        Me.txt_filtro1.Name = "txt_filtro1"
        Me.txt_filtro1.Size = New System.Drawing.Size(315, 22)
        Me.txt_filtro1.TabIndex = 0
        '
        'Menu_Maquila
        '
        Me.Menu_Maquila.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Mant_Materiales_Auxiliares})
        Me.MenuItem1.Text = "Mantenimiento"
        '
        'Mant_Materiales_Auxiliares
        '
        Me.Mant_Materiales_Auxiliares.Index = 0
        Me.Mant_Materiales_Auxiliares.Text = "Materiales Auxiliares"
        '
        'frm_maq_etiquetas_materiales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(673, 351)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Menu = Me.Menu_Maquila
        Me.Name = "frm_maq_etiquetas_materiales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Maquilas .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Packs_Activos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsgen As New ClasesGenerales.General

        Try
            Ods = New DataSet
            Otrans.open()

            'If Ods.Tables.Contains("packs") Then Ods.Tables.Remove("packs")
            'If Ods.Tables.Contains("detalle_packs") Then Ods.Tables.Remove("detalle_packs")
            'If Ods.Tables.Contains("detalle_onbase_packs") Then Ods.Tables.Remove("detalle_onbase_packs")
            'If Ods.Tables.Contains("mpacks_insumos") Then Ods.Tables.Remove("mpacks_insumos")
            'If Ods.Tables.Contains("mdetalle_packs_insumos") Then Ods.Tables.Remove("mdetalle_packs_insumos")

            'ls_sql = "pa_var_um_ProdReceta '" & gs_empresa & "'"
            'dt = Otrans.Obtiene(ls_sql)
            'dt.TableName = "packs"
            'Ods.Tables.Add(dt.Copy)


            'ls_sql = "pa_var_um_ProdReceta_detalle '" & gs_empresa & "',0"
            'dt = Otrans.Obtiene(ls_sql)
            'dt.TableName = "detalle_packs"
            'Ods.Tables.Add(dt.Copy)




            Me.cmb_valor1.Items.Add("Producto")
            Me.cmb_valor1.Items.Add("Glosa")
            Me.cmb_1.Items.Add("=")
            Me.cmb_1.Items.Add(">")
            Me.cmb_1.Items.Add("<")
            Me.cmb_1.Items.Add("like")

            Me.cmb_valor1.Text = "Glosa"
            Me.cmb_1.Text = "like"



        Catch ex As Exception
        Finally

        End Try

        'Informacion de detalle packs
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            myOtrans.open()

            ls_sql = "pa_sel_um_maq_materiales '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "mpacks_insumos"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            dt = myOtrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try


    End Sub
    Private Sub Crear_Estructura_Insumos()

        Dim dt As New DataTable("insumos_pack")


        dt.Columns.Add(New DataColumn("cod_insumo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Especificaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("costo", GetType(Decimal)))
        Ods.Tables.Add(dt.Copy)
        Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")




        combo_datagrid_insumos()

    End Sub
    Private Sub combo_datagrid_insumos()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "insumos_pack"

        Dim dt As DataTable = Ods.Tables("insumos_pack")
        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_insumo"
        ComboTextCol.HeaderText = "Tipo "
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = Ods.Tables("mpacks_insumos").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_insumo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight

        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5
        tableStyle.GridColumnStyles.Add(ComboTextCol)

        Dim TextCol As New DataGridTextBoxColumn
        TextCol.MappingName = dt.Columns(1).ColumnName
        TextCol.HeaderText = "Especificaciones"
        TextCol.Width = 180
        tableStyle.GridColumnStyles.Add(TextCol)

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = dt.Columns(2).ColumnName
        TextCol2.HeaderText = "costo"
        TextCol2.Format = "N4"
        TextCol2.Width = 110
        TextCol2.Alignment = HorizontalAlignment.Right
        tableStyle.GridColumnStyles.Add(TextCol2)

        Me.dg_detalle_pack_insumos.TableStyles.Clear()
        Me.dg_detalle_pack_insumos.TableStyles.Add(tableStyle)

    End Sub
    'Muestro todas las Op pendientes
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim Otrans_ As New Transaccional.Conexion("SCM")
        Dim dt, dt2 As DataTable

        Try
            otrans.open()
            Otrans_.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")

            dt2 = Otrans_.Obtiene("pa_sel_um_maq_materiales '" & gs_empresa & "','" & Me.txt_producto.Text & "'")


            dt2.TableName = "mdetalle_packs_insumos"

            If Ods.Tables.Contains("insumos_pack") Then
                Ods.Tables("insumos_pack").Clear()
            End If


            If Ods.Tables.Contains("mdetalle_packs_insumos") Then
                Ods.Tables.Remove("mdetalle_packs_insumos")
            End If

            Ods.Tables.Add(dt2.Copy)

            Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")
            Me.dg_detalle_pack_insumos.Refresh()

            Dim dr As DataRow

            For Each drv As DataRowView In Ods.Tables("mdetalle_packs_insumos").DefaultView
                dr = Ods.Tables("insumos_pack").NewRow
                dr.Item("cod_insumo") = drv.Item("cod_insumo")
                dr.Item("Especificaciones") = drv.Item("observaciones")
                dr.Item("costo") = drv.Item("costo")
                Ods.Tables("insumos_pack").Rows.Add(dr)
            Next


            '''

            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")

            End If

            If dt2.Rows.Count > 0 Then
                Pcorrelativo = dt2.Rows(0)("correlativo")
                Pproducto = dt.Rows(0)("producto")
            End If

            If dt2.Rows.Count > 0 Then
                Me.btn_guardar.Text = "Actualizar"

            Else
                Me.btn_guardar.Text = "Guardar"
            End If
            Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
            txt_total_costo.Text = Format(suma, "##,###,##0.0000")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing

        End Try
    End Sub
    Private Sub llenar_informacion()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            otrans.open()
            ls_sql = "pa_sel_um_maq_encabezado_productos '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dt.DefaultView.Count > 0 Then
                    Try
                        dr_aux = Ods.Tables("productos").NewRow
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("glosa") = dr.Item("glosa")
                        dr_aux.Item("costo") = dr.Item("costo")
                        Ods.Tables("productos").Rows.Add(dr_aux)
                    Catch ex As Exception
                    End Try
                End If
            Next


            ClsGen.Alinear_GridView(Ods.Tables("productos"), dgv_listado, ",producto,glosa,costo,", ",,", ",producto,glosa,costo,", "", "", ",producto=90,glosa=300,costo=50,", "", True, True, 175, 0)




        Catch ex As Exception
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing

        End Try


    End Sub
    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", Me.txt_filtro1.Text, "", "", Me.cmb_1.Text, "", "", Me.txt_filtro1.Text, "")
        clsgen = Nothing
        Ods.Tables("productos").DefaultView.RowFilter = ls_filtro
    End Sub
    Private Sub limpiar()
        Me.txt_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_total_costo.Text = "0"
        Me.btn_guardar.Text = "Guardar"
        Llenar_Packs_Activos()
        Crear_Estructura_Insumos()



    End Sub
    Private Sub crear_estructura_productos()
        Dim dt2 As New DataTable("productos")

        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("costo", GetType(Decimal)))
        Ods.Tables.Add(dt2.Copy)
        Me.dgv_listado.DataSource = Ods.Tables("productos")
    End Sub

   
    Private Sub frm_maq_etiquetas_materiales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Packs_Activos()
        Crear_Estructura_Insumos()
        crear_estructura_productos()

        llenar_informacion()
        Me.TabControl1.SelectedTab() = Me.TabPage2

    End Sub
    Sub InicializarBarra(ByRef NombreBarraRelleno As Panel, ByVal PosicionBarra As String)
        ' Valores de PosicionBarra
        ' H = Horizontal; V(Vertical)
        If PosicionBarra.ToUpper = "H" Then
            NombreBarraRelleno.Width = 0
        ElseIf PosicionBarra = "V" Then
            NombreBarraRelleno.Height = 0
        End If
    End Sub
    Sub ActualizarBarra(ByRef NombreBarraRelleno As Panel, ByRef NombreBarraBase As Panel, _
             ByVal PuntoInicio As String, ByVal Valor As Integer)
        ' Valores de PuntoInicio
        ' R(Right) = de derecha a izquierda ; L(Left) = de izquierda a derecha ; 
        ' T(Top) = de arriba a abajo ; B(Bottom) = de abajo a arriba

        'variable que sirve para guardar el valor de la unidad en la barra de progreso
        Dim Unidad As Decimal

        If PuntoInicio.ToUpper = "R" Or PuntoInicio.ToUpper = "L" Then
            'guardo el valor de la unidad de la barra de relleno
            Unidad = NombreBarraBase.Width / 100
        Else
            If PuntoInicio.ToUpper = "T" Or PuntoInicio.ToUpper = "B" Then
                'guardo el valor de la unidad de la barra de relleno
                Unidad = NombreBarraBase.Height / 100
            End If
        End If
        Select Case PuntoInicio
            Case "R" 'de derecha a izquierda
                NombreBarraRelleno.Left = NombreBarraBase.Width - (Unidad * Valor)
                NombreBarraRelleno.Width = Unidad * Valor
            Case "L" 'de izquierda a derecha
                NombreBarraRelleno.Width() = NombreBarraRelleno.Left + (Unidad * Valor)
            Case "T" 'de arriba a abajo
                NombreBarraRelleno.Height() = NombreBarraRelleno.Top + (Unidad * Valor)
            Case "B" 'de abajo a arriba
                NombreBarraRelleno.Top = NombreBarraBase.Height - (Unidad * Valor)
                NombreBarraRelleno.Height() = Unidad * Valor
            Case Else
                MessageBox.Show("El valor del parámetro PuntoInicio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub tb_detalle_pack_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_total_costo.Text = String.Empty

        If dg_detalle_pack_insumos.CurrentRowIndex <= 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub
    Private Sub Actualiza_Materiales(ByVal _pcod_producto As Integer)

        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim especificaciones As String = ""


        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim Otrans_ As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            Otrans_.open()
            ls_sql = "pa_del_um_detalle_materiales '" & gs_empresa & "'," & Pcorrelativo & ",'" & _pcod_producto & "'"
            Otrans_.Elimina(ls_sql)
            If Otrans_.Codigo_error = 0 Then
                'Inserto Los Insumos utilizados en los packs
                For Each dr In Ods.Tables("insumos_pack").Rows
                    ls_sql = "pa_sel_um_maq_tipo_material " & dr.Item("cod_insumo")
                    dt = Otrans_.Obtiene(ls_sql)

                    If dr.Item("Especificaciones").ToString.Length > 0 Then
                        especificaciones = dr.Item("Especificaciones")
                    Else
                        especificaciones = "NULL"
                    End If
                    ls_sql = "pa_ins_um_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & dt.Rows(0).Item("nemotecnico") & _
                            "'," & dr.Item("costo").ToString & ", " & especificaciones
                    Otrans_.Ingresa(ls_sql)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
                ls_sql = "pa_upd_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & Pproducto & "'," & Me.txt_total_costo.Text & ",'" & gs_usuario & "'"
                Otrans_.Actualiza(ls_sql)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing
        End Try
    End Sub
    Private Sub Guarda_Materiales(ByVal _pcod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim especificaciones As String = ""
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim Otrans_ As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            Otrans_.open()
            ls_sql = "pa_sel_um_maq_encabezado_materiales_numero '" & gs_empresa & "'"
            dt = Otrans_.Obtiene(ls_sql)

            ls_sql = "pa_ins_maq_encabezado_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & Pproducto & "'," & Me.txt_total_costo.Text & ",'" & gs_usuario & "'"
            Otrans_.Actualiza(ls_sql)
            'Inserto Los Insumos utilizados en los packs
            For Each dr In Ods.Tables("insumos_pack").Rows
                If dr.Item("Especificaciones").ToString.Length > 0 Then
                    especificaciones = dr.Item("Especificaciones")
                Else
                    especificaciones = "NULL"
                End If
                ls_sql = "pa_ins_um_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & dt.Rows(0).Item("nemotecnico") & _
                        "'," & dr.Item("costo").ToString & ", " & especificaciones
                Otrans_.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing
        End Try
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Me.btn_guardar.Text = "Guardar" Then
            Guarda_Materiales(Trim(Me.txt_producto.Text))
        Else
            Actualiza_Materiales(Trim(Me.txt_producto.Text))
        End If
    End Sub
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
        'frm_busqueda.pConexion = "FlexLine"
        frm_busqueda.ShowDialog(Me)
        ls_codigo = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Me.txt_producto.Text = ls_codigo

        buscarProducto()
    End Sub
    Private Sub txt_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.buscarProducto()

        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        hacer_filtro()

    End Sub
    Private Sub dgv_listado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_listado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_listado.Rows(rowIndex)
                If therow.Cells("costo").Value > 0 Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgv_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado.DoubleClick
        Dim nRow As Integer


        Try
            nRow = Me.dgv_listado.CurrentCell.RowIndex
            Me.txt_producto.Text = Me.dgv_listado.Item(0, nRow).Value.ToString

            Me.buscarProducto()


            Me.TabControl1.SelectedTab() = Me.TabPage1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dg_detalle_pack_insumos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_detalle_pack_insumos.CurrentCellChanged
        txt_total_costo.Text = String.Empty

        If dg_detalle_pack_insumos.CurrentRowIndex <= 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_listado.Click
        Me.TabControl1.SelectedTab() = Me.TabPage1
        limpiar()
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()

    End Sub

    Private Sub Mant_Materiales_Auxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mant_Materiales_Auxiliares.Click
        Dim oform As New frm_gen_tabcod
        oform.gen_tipo = "MAQ_MATERIALES"
        oform.ShowDialog()



        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim dt As DataTable
        Try
            If Ods.Tables.IndexOf("mpacks_insumos") >= 0 Then
                Ods.Tables.Remove("mpacks_insumos")
            End If

            Otrans.open()

            ls_sql = "pa_sel_um_maq_materiales '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "mpacks_insumos"
            Ods.Tables.Add(dt.Copy)


            combo_datagrid_insumos()
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub dgv_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado.CellContentClick

    End Sub
End Class
