<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mantenimiento_activos_insumos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mantenimiento_activos_insumos))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.btn_nuevos = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dg_software = New System.Windows.Forms.DataGrid
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.txt_minimo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_minimo = New System.Windows.Forms.Label
        Me.chk_generar = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_existencia = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.cmb_categoria = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.lbl_modelos = New System.Windows.Forms.Label
        Me.dg_insumos_asociados = New System.Windows.Forms.DataGrid
        Me.lbl_software = New System.Windows.Forms.Label
        Me.gb_marca_modelo = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_imei = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmb_modelo = New System.Windows.Forms.ComboBox
        Me.cmb_marca = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_serie = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.dg_caracteristicas = New System.Windows.Forms.DataGrid
        Me.lbl_caracteristicas = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmb_operadores = New System.Windows.Forms.ComboBox
        Me.cmb_opciones = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.dgv_listado = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CategoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarcasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModelosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MotivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SoftwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CaracteristicasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dg_software, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_insumos_asociados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_marca_modelo.SuspendLayout()
        CType(Me.dg_caracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(774, 415)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.btn_nuevos)
        Me.TabPage1.Controls.Add(Me.dg_software)
        Me.TabPage1.Controls.Add(Me.txtPrecio)
        Me.TabPage1.Controls.Add(Me.txt_minimo)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lbl_minimo)
        Me.TabPage1.Controls.Add(Me.chk_generar)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txt_existencia)
        Me.TabPage1.Controls.Add(Me.lbl_codigo)
        Me.TabPage1.Controls.Add(Me.cmb_categoria)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.lbl_modelos)
        Me.TabPage1.Controls.Add(Me.dg_insumos_asociados)
        Me.TabPage1.Controls.Add(Me.lbl_software)
        Me.TabPage1.Controls.Add(Me.gb_marca_modelo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cmb_tipos)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_descripcion)
        Me.TabPage1.Controls.Add(Me.txt_codigo)
        Me.TabPage1.Controls.Add(Me.dg_caracteristicas)
        Me.TabPage1.Controls.Add(Me.lbl_caracteristicas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(766, 389)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 364)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(760, 22)
        Me.StatusStrip1.TabIndex = 53
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(372, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(372, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'btn_nuevos
        '
        Me.btn_nuevos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevos.ForeColor = System.Drawing.Color.White
        Me.btn_nuevos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevos.ImageKey = "page_blank.ico"
        Me.btn_nuevos.ImageList = Me.ImageList1
        Me.btn_nuevos.Location = New System.Drawing.Point(577, 13)
        Me.btn_nuevos.Name = "btn_nuevos"
        Me.btn_nuevos.Size = New System.Drawing.Size(73, 56)
        Me.btn_nuevos.TabIndex = 52
        Me.btn_nuevos.Text = "&Nuevo"
        Me.btn_nuevos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevos.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "page_blank.ico")
        Me.ImageList1.Images.SetKeyName(1, "save.ico")
        '
        'dg_software
        '
        Me.dg_software.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_software.CaptionVisible = False
        Me.dg_software.DataMember = ""
        Me.dg_software.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_software.Location = New System.Drawing.Point(459, 101)
        Me.dg_software.Name = "dg_software"
        Me.dg_software.Size = New System.Drawing.Size(304, 128)
        Me.dg_software.TabIndex = 50
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(115, 140)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(128, 20)
        Me.txtPrecio.TabIndex = 34
        Me.txtPrecio.Text = "0"
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_minimo
        '
        Me.txt_minimo.Location = New System.Drawing.Point(115, 120)
        Me.txt_minimo.Name = "txt_minimo"
        Me.txt_minimo.Size = New System.Drawing.Size(128, 20)
        Me.txt_minimo.TabIndex = 34
        Me.txt_minimo.Text = "0"
        Me.txt_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(3, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 11)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Precio"
        '
        'lbl_minimo
        '
        Me.lbl_minimo.Location = New System.Drawing.Point(3, 121)
        Me.lbl_minimo.Name = "lbl_minimo"
        Me.lbl_minimo.Size = New System.Drawing.Size(80, 23)
        Me.lbl_minimo.TabIndex = 49
        Me.lbl_minimo.Text = "Minimo"
        '
        'chk_generar
        '
        Me.chk_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_generar.Location = New System.Drawing.Point(301, 13)
        Me.chk_generar.Name = "chk_generar"
        Me.chk_generar.Size = New System.Drawing.Size(72, 16)
        Me.chk_generar.TabIndex = 48
        Me.chk_generar.Text = "Generar"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(251, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 12)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Existencia"
        '
        'txt_existencia
        '
        Me.txt_existencia.ForeColor = System.Drawing.Color.Red
        Me.txt_existencia.Location = New System.Drawing.Point(315, 123)
        Me.txt_existencia.Name = "txt_existencia"
        Me.txt_existencia.ReadOnly = True
        Me.txt_existencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_existencia.Size = New System.Drawing.Size(72, 20)
        Me.txt_existencia.TabIndex = 47
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Location = New System.Drawing.Point(435, 13)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(100, 23)
        Me.lbl_codigo.TabIndex = 46
        Me.lbl_codigo.Visible = False
        '
        'cmb_categoria
        '
        Me.cmb_categoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_categoria.Location = New System.Drawing.Point(115, 72)
        Me.cmb_categoria.Name = "cmb_categoria"
        Me.cmb_categoria.Size = New System.Drawing.Size(162, 21)
        Me.cmb_categoria.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(3, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Tipo"
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageKey = "save.ico"
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(656, 13)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 56)
        Me.btn_guardar.TabIndex = 44
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'lbl_modelos
        '
        Me.lbl_modelos.Location = New System.Drawing.Point(3, 254)
        Me.lbl_modelos.Name = "lbl_modelos"
        Me.lbl_modelos.Size = New System.Drawing.Size(100, 23)
        Me.lbl_modelos.TabIndex = 43
        Me.lbl_modelos.Text = "Modelos"
        '
        'dg_insumos_asociados
        '
        Me.dg_insumos_asociados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dg_insumos_asociados.CaptionVisible = False
        Me.dg_insumos_asociados.DataMember = ""
        Me.dg_insumos_asociados.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_insumos_asociados.Location = New System.Drawing.Point(115, 254)
        Me.dg_insumos_asociados.Name = "dg_insumos_asociados"
        Me.dg_insumos_asociados.Size = New System.Drawing.Size(272, 95)
        Me.dg_insumos_asociados.TabIndex = 42
        '
        'lbl_software
        '
        Me.lbl_software.Location = New System.Drawing.Point(395, 101)
        Me.lbl_software.Name = "lbl_software"
        Me.lbl_software.Size = New System.Drawing.Size(80, 23)
        Me.lbl_software.TabIndex = 40
        Me.lbl_software.Text = "Software"
        '
        'gb_marca_modelo
        '
        Me.gb_marca_modelo.Controls.Add(Me.Label17)
        Me.gb_marca_modelo.Controls.Add(Me.txt_imei)
        Me.gb_marca_modelo.Controls.Add(Me.Label6)
        Me.gb_marca_modelo.Controls.Add(Me.cmb_modelo)
        Me.gb_marca_modelo.Controls.Add(Me.cmb_marca)
        Me.gb_marca_modelo.Controls.Add(Me.Label5)
        Me.gb_marca_modelo.Controls.Add(Me.Label4)
        Me.gb_marca_modelo.Controls.Add(Me.txt_serie)
        Me.gb_marca_modelo.Location = New System.Drawing.Point(3, 157)
        Me.gb_marca_modelo.Name = "gb_marca_modelo"
        Me.gb_marca_modelo.Size = New System.Drawing.Size(384, 88)
        Me.gb_marca_modelo.TabIndex = 39
        Me.gb_marca_modelo.TabStop = False
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(7, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Imei"
        '
        'txt_imei
        '
        Me.txt_imei.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_imei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_imei.Location = New System.Drawing.Point(112, 39)
        Me.txt_imei.Name = "txt_imei"
        Me.txt_imei.Size = New System.Drawing.Size(264, 20)
        Me.txt_imei.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(240, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Modelo"
        '
        'cmb_modelo
        '
        Me.cmb_modelo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_modelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_modelo.DropDownWidth = 120
        Me.cmb_modelo.Location = New System.Drawing.Point(288, 62)
        Me.cmb_modelo.Name = "cmb_modelo"
        Me.cmb_modelo.Size = New System.Drawing.Size(88, 21)
        Me.cmb_modelo.TabIndex = 7
        '
        'cmb_marca
        '
        Me.cmb_marca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_marca.Location = New System.Drawing.Point(112, 62)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(80, 21)
        Me.cmb_marca.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Marca"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "No. Serie"
        '
        'txt_serie
        '
        Me.txt_serie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_serie.Location = New System.Drawing.Point(112, 16)
        Me.txt_serie.Name = "txt_serie"
        Me.txt_serie.Size = New System.Drawing.Size(264, 20)
        Me.txt_serie.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Categoria"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Descripcion"
        '
        'cmb_tipos
        '
        Me.cmb_tipos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.Location = New System.Drawing.Point(115, 96)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(162, 21)
        Me.cmb_tipos.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Codigo"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(115, 37)
        Me.txt_descripcion.Multiline = True
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(306, 32)
        Me.txt_descripcion.TabIndex = 31
        '
        'txt_codigo
        '
        Me.txt_codigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(115, 13)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(174, 20)
        Me.txt_codigo.TabIndex = 30
        '
        'dg_caracteristicas
        '
        Me.dg_caracteristicas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_caracteristicas.CaptionVisible = False
        Me.dg_caracteristicas.DataMember = ""
        Me.dg_caracteristicas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_caracteristicas.Location = New System.Drawing.Point(459, 229)
        Me.dg_caracteristicas.Name = "dg_caracteristicas"
        Me.dg_caracteristicas.Size = New System.Drawing.Size(304, 120)
        Me.dg_caracteristicas.TabIndex = 51
        '
        'lbl_caracteristicas
        '
        Me.lbl_caracteristicas.Location = New System.Drawing.Point(387, 229)
        Me.lbl_caracteristicas.Name = "lbl_caracteristicas"
        Me.lbl_caracteristicas.Size = New System.Drawing.Size(80, 23)
        Me.lbl_caracteristicas.TabIndex = 41
        Me.lbl_caracteristicas.Text = "Caracteristicas"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.cmb_operadores)
        Me.TabPage2.Controls.Add(Me.cmb_opciones)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.btn_nuevo)
        Me.TabPage2.Controls.Add(Me.dgv_listado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(766, 389)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'cmb_operadores
        '
        Me.cmb_operadores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_operadores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_operadores.FormattingEnabled = True
        Me.cmb_operadores.Location = New System.Drawing.Point(110, 8)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(62, 21)
        Me.cmb_operadores.TabIndex = 5
        '
        'cmb_opciones
        '
        Me.cmb_opciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_opciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_opciones.FormattingEnabled = True
        Me.cmb_opciones.Location = New System.Drawing.Point(8, 8)
        Me.cmb_opciones.Name = "cmb_opciones"
        Me.cmb_opciones.Size = New System.Drawing.Size(96, 21)
        Me.cmb_opciones.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(178, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(458, 20)
        Me.TextBox1.TabIndex = 3
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.Location = New System.Drawing.Point(685, 6)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_nuevo.TabIndex = 2
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'dgv_listado
        '
        Me.dgv_listado.AllowUserToAddRows = False
        Me.dgv_listado.AllowUserToDeleteRows = False
        Me.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado.Location = New System.Drawing.Point(6, 47)
        Me.dgv_listado.Name = "dgv_listado"
        Me.dgv_listado.ReadOnly = True
        Me.dgv_listado.RowHeadersWidth = 25
        Me.dgv_listado.Size = New System.Drawing.Size(754, 339)
        Me.dgv_listado.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Honeydew
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(786, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "Menu_Mantenimientos"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CategoriasToolStripMenuItem, Me.TiposToolStripMenuItem, Me.MarcasToolStripMenuItem, Me.ModelosToolStripMenuItem, Me.MotivosToolStripMenuItem, Me.SoftwareToolStripMenuItem, Me.CaracteristicasToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.MantenimientoToolStripMenuItem.Text = "Mantenimiento"
        '
        'CategoriasToolStripMenuItem
        '
        Me.CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem"
        Me.CategoriasToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CategoriasToolStripMenuItem.Text = "Categorias"
        '
        'TiposToolStripMenuItem
        '
        Me.TiposToolStripMenuItem.Name = "TiposToolStripMenuItem"
        Me.TiposToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.TiposToolStripMenuItem.Text = "Tipos"
        '
        'MarcasToolStripMenuItem
        '
        Me.MarcasToolStripMenuItem.Name = "MarcasToolStripMenuItem"
        Me.MarcasToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MarcasToolStripMenuItem.Text = "Marcas"
        '
        'ModelosToolStripMenuItem
        '
        Me.ModelosToolStripMenuItem.Name = "ModelosToolStripMenuItem"
        Me.ModelosToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ModelosToolStripMenuItem.Text = "Modelos"
        '
        'MotivosToolStripMenuItem
        '
        Me.MotivosToolStripMenuItem.Name = "MotivosToolStripMenuItem"
        Me.MotivosToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MotivosToolStripMenuItem.Text = "Motivos"
        '
        'SoftwareToolStripMenuItem
        '
        Me.SoftwareToolStripMenuItem.Name = "SoftwareToolStripMenuItem"
        Me.SoftwareToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SoftwareToolStripMenuItem.Text = "Software"
        '
        'CaracteristicasToolStripMenuItem
        '
        Me.CaracteristicasToolStripMenuItem.Name = "CaracteristicasToolStripMenuItem"
        Me.CaracteristicasToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CaracteristicasToolStripMenuItem.Text = "Caracteristicas"
        '
        'frm_mantenimiento_activos_insumos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(786, 454)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frm_mantenimiento_activos_insumos"
        Me.Text = ":: Mantenimiento de Insumos ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dg_software, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_insumos_asociados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_marca_modelo.ResumeLayout(False)
        Me.gb_marca_modelo.PerformLayout()
        CType(Me.dg_caracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_listado As System.Windows.Forms.DataGridView
    Friend WithEvents dg_software As System.Windows.Forms.DataGrid
    Friend WithEvents txt_minimo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_minimo As System.Windows.Forms.Label
    Friend WithEvents chk_generar As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_existencia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents cmb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents lbl_modelos As System.Windows.Forms.Label
    Friend WithEvents dg_insumos_asociados As System.Windows.Forms.DataGrid
    Friend WithEvents lbl_software As System.Windows.Forms.Label
    Friend WithEvents gb_marca_modelo As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_imei As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_modelo As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_serie As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents dg_caracteristicas As System.Windows.Forms.DataGrid
    Friend WithEvents lbl_caracteristicas As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TiposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarcasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModelosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MotivosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CaracteristicasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_nuevos As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_opciones As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
