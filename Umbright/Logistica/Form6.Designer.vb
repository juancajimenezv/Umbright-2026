<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_glosa = New System.Windows.Forms.TextBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_tipo_producto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_unidad_medida = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb_Grupo = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tb_Codigo_Cliente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tipo = New System.Windows.Forms.Label()
        Me.cmb_tipo2 = New System.Windows.Forms.ComboBox()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Procedencia = New System.Windows.Forms.ComboBox()
        Me.txt_subtipo = New System.Windows.Forms.TextBox()
        Me.cmb_familia = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_Volumen = New System.Windows.Forms.TextBox()
        Me.tb_Peso = New System.Windows.Forms.TextBox()
        Me.tb_Factor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nud_DecimalesAlt = New System.Windows.Forms.NumericUpDown()
        Me.cmb_Alternativa = New System.Windows.Forms.ComboBox()
        Me.nud_Decimales = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ckb_ValidaStock = New System.Windows.Forms.CheckBox()
        Me.ckb_Costea = New System.Windows.Forms.CheckBox()
        Me.ckb_FechaVcto = New System.Windows.Forms.CheckBox()
        Me.ckb_Serie = New System.Windows.Forms.CheckBox()
        Me.ckb_Lote = New System.Windows.Forms.CheckBox()
        Me.ckb_Iva = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_cla_CmasxTar = New System.Windows.Forms.TextBox()
        Me.tb_cla_CajasxCam = New System.Windows.Forms.TextBox()
        Me.tb_cla_CajasxTar = New System.Windows.Forms.TextBox()
        Me.tb_cla_Peso = New System.Windows.Forms.TextBox()
        Me.tb_cla_volumen = New System.Windows.Forms.TextBox()
        Me.txt_codtesa = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nud_DecimalesAlt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_Decimales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(5, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Código Sugerido + 1:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(19, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Nombre Producto:"
        '
        'txt_glosa
        '
        Me.txt_glosa.Location = New System.Drawing.Point(115, 81)
        Me.txt_glosa.Name = "txt_glosa"
        Me.txt_glosa.Size = New System.Drawing.Size(526, 20)
        Me.txt_glosa.TabIndex = 3
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(80, 48)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(151, 21)
        Me.cmb_proveedor.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(34, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Familia:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(18, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Proveedor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(36, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Marca:"
        '
        'cmb_tipo_producto
        '
        Me.cmb_tipo_producto.FormattingEnabled = True
        Me.cmb_tipo_producto.Location = New System.Drawing.Point(79, 75)
        Me.cmb_tipo_producto.Name = "cmb_tipo_producto"
        Me.cmb_tipo_producto.Size = New System.Drawing.Size(152, 21)
        Me.cmb_tipo_producto.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(25, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "SubTipo:"
        '
        'cmb_unidad_medida
        '
        Me.cmb_unidad_medida.FormattingEnabled = True
        Me.cmb_unidad_medida.Location = New System.Drawing.Point(71, 25)
        Me.cmb_unidad_medida.Name = "cmb_unidad_medida"
        Me.cmb_unidad_medida.Size = New System.Drawing.Size(100, 21)
        Me.cmb_unidad_medida.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_Grupo)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.tb_Codigo_Cliente)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Tipo)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo2)
        Me.GroupBox1.Controls.Add(Me.txt_glosa)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 152)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'cmb_Grupo
        '
        Me.cmb_Grupo.FormattingEnabled = True
        Me.cmb_Grupo.Location = New System.Drawing.Point(115, 31)
        Me.cmb_Grupo.Name = "cmb_Grupo"
        Me.cmb_Grupo.Size = New System.Drawing.Size(213, 21)
        Me.cmb_Grupo.TabIndex = 85
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label21.Location = New System.Drawing.Point(328, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 13)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "Código del Cliente:"
        '
        'tb_Codigo_Cliente
        '
        Me.tb_Codigo_Cliente.Location = New System.Drawing.Point(427, 108)
        Me.tb_Codigo_Cliente.Name = "tb_Codigo_Cliente"
        Me.tb_Codigo_Cliente.Size = New System.Drawing.Size(214, 20)
        Me.tb_Codigo_Cliente.TabIndex = 83
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(72, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Grupo:"
        '
        'Tipo
        '
        Me.Tipo.AutoSize = True
        Me.Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Tipo.Location = New System.Drawing.Point(80, 110)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(31, 13)
        Me.Tipo.TabIndex = 79
        Me.Tipo.Text = "Tipo:"
        '
        'cmb_tipo2
        '
        Me.cmb_tipo2.FormattingEnabled = True
        Me.cmb_tipo2.Location = New System.Drawing.Point(115, 107)
        Me.cmb_tipo2.Name = "cmb_tipo2"
        Me.cmb_tipo2.Size = New System.Drawing.Size(170, 21)
        Me.cmb_tipo2.TabIndex = 4
        '
        'txt_producto
        '
        Me.txt_producto.Location = New System.Drawing.Point(114, 55)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(214, 20)
        Me.txt_producto.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txt_codtesa)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cb_Procedencia)
        Me.GroupBox2.Controls.Add(Me.txt_subtipo)
        Me.GroupBox2.Controls.Add(Me.cmb_familia)
        Me.GroupBox2.Controls.Add(Me.cmb_proveedor)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmb_tipo_producto)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 205)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 182)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Atributos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(7, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Procedencia:"
        '
        'cb_Procedencia
        '
        Me.cb_Procedencia.FormattingEnabled = True
        Me.cb_Procedencia.Location = New System.Drawing.Point(78, 128)
        Me.cb_Procedencia.Name = "cb_Procedencia"
        Me.cb_Procedencia.Size = New System.Drawing.Size(153, 21)
        Me.cb_Procedencia.TabIndex = 75
        '
        'txt_subtipo
        '
        Me.txt_subtipo.Location = New System.Drawing.Point(78, 101)
        Me.txt_subtipo.Name = "txt_subtipo"
        Me.txt_subtipo.Size = New System.Drawing.Size(153, 20)
        Me.txt_subtipo.TabIndex = 8
        '
        'cmb_familia
        '
        Me.cmb_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_familia.DropDownWidth = 150
        Me.cmb_familia.Location = New System.Drawing.Point(80, 22)
        Me.cmb_familia.Name = "cmb_familia"
        Me.cmb_familia.Size = New System.Drawing.Size(151, 21)
        Me.cmb_familia.TabIndex = 5
        Me.cmb_familia.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_nuevo)
        Me.GroupBox3.Controls.Add(Me.btn_guardar)
        Me.GroupBox3.Location = New System.Drawing.Point(669, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(176, 152)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.Location = New System.Drawing.Point(44, 19)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(98, 56)
        Me.btn_nuevo.TabIndex = 78
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.Location = New System.Drawing.Point(44, 84)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(98, 53)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(702, 12)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(90, 20)
        Me.dtFecha.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(659, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Fecha:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(229, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(353, 26)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Creación de Productos de Terceros"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.tb_Volumen)
        Me.GroupBox4.Controls.Add(Me.tb_Peso)
        Me.GroupBox4.Controls.Add(Me.tb_Factor)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.nud_DecimalesAlt)
        Me.GroupBox4.Controls.Add(Me.cmb_Alternativa)
        Me.GroupBox4.Controls.Add(Me.nud_Decimales)
        Me.GroupBox4.Controls.Add(Me.cmb_unidad_medida)
        Me.GroupBox4.Location = New System.Drawing.Point(256, 205)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(238, 164)
        Me.GroupBox4.TabIndex = 82
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Unidad de Medida"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Volumen"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 108)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Peso"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Factor (uxc)"
        '
        'tb_Volumen
        '
        Me.tb_Volumen.Location = New System.Drawing.Point(71, 130)
        Me.tb_Volumen.Name = "tb_Volumen"
        Me.tb_Volumen.Size = New System.Drawing.Size(100, 20)
        Me.tb_Volumen.TabIndex = 12
        '
        'tb_Peso
        '
        Me.tb_Peso.Location = New System.Drawing.Point(71, 104)
        Me.tb_Peso.Name = "tb_Peso"
        Me.tb_Peso.Size = New System.Drawing.Size(100, 20)
        Me.tb_Peso.TabIndex = 11
        '
        'tb_Factor
        '
        Me.tb_Factor.Location = New System.Drawing.Point(71, 78)
        Me.tb_Factor.Name = "tb_Factor"
        Me.tb_Factor.Size = New System.Drawing.Size(100, 20)
        Me.tb_Factor.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Alternativa"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Normal"
        '
        'nud_DecimalesAlt
        '
        Me.nud_DecimalesAlt.Location = New System.Drawing.Point(177, 52)
        Me.nud_DecimalesAlt.Name = "nud_DecimalesAlt"
        Me.nud_DecimalesAlt.Size = New System.Drawing.Size(43, 20)
        Me.nud_DecimalesAlt.TabIndex = 3
        '
        'cmb_Alternativa
        '
        Me.cmb_Alternativa.FormattingEnabled = True
        Me.cmb_Alternativa.Location = New System.Drawing.Point(71, 51)
        Me.cmb_Alternativa.Name = "cmb_Alternativa"
        Me.cmb_Alternativa.Size = New System.Drawing.Size(100, 21)
        Me.cmb_Alternativa.TabIndex = 2
        '
        'nud_Decimales
        '
        Me.nud_Decimales.Location = New System.Drawing.Point(177, 25)
        Me.nud_Decimales.Name = "nud_Decimales"
        Me.nud_Decimales.Size = New System.Drawing.Size(43, 20)
        Me.nud_Decimales.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ckb_ValidaStock)
        Me.GroupBox5.Controls.Add(Me.ckb_Costea)
        Me.GroupBox5.Controls.Add(Me.ckb_FechaVcto)
        Me.GroupBox5.Controls.Add(Me.ckb_Serie)
        Me.GroupBox5.Controls.Add(Me.ckb_Lote)
        Me.GroupBox5.Controls.Add(Me.ckb_Iva)
        Me.GroupBox5.Location = New System.Drawing.Point(498, 205)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(168, 164)
        Me.GroupBox5.TabIndex = 83
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Indicadores"
        '
        'ckb_ValidaStock
        '
        Me.ckb_ValidaStock.AutoSize = True
        Me.ckb_ValidaStock.Location = New System.Drawing.Point(20, 119)
        Me.ckb_ValidaStock.Name = "ckb_ValidaStock"
        Me.ckb_ValidaStock.Size = New System.Drawing.Size(86, 17)
        Me.ckb_ValidaStock.TabIndex = 5
        Me.ckb_ValidaStock.Text = "Valida Stock"
        Me.ckb_ValidaStock.UseVisualStyleBackColor = True
        '
        'ckb_Costea
        '
        Me.ckb_Costea.AutoSize = True
        Me.ckb_Costea.Location = New System.Drawing.Point(20, 99)
        Me.ckb_Costea.Name = "ckb_Costea"
        Me.ckb_Costea.Size = New System.Drawing.Size(73, 17)
        Me.ckb_Costea.TabIndex = 4
        Me.ckb_Costea.Text = "Costeable"
        Me.ckb_Costea.UseVisualStyleBackColor = True
        '
        'ckb_FechaVcto
        '
        Me.ckb_FechaVcto.AutoSize = True
        Me.ckb_FechaVcto.Location = New System.Drawing.Point(20, 80)
        Me.ckb_FechaVcto.Name = "ckb_FechaVcto"
        Me.ckb_FechaVcto.Size = New System.Drawing.Size(132, 17)
        Me.ckb_FechaVcto.TabIndex = 3
        Me.ckb_FechaVcto.Text = "Fecha de Vencimiento"
        Me.ckb_FechaVcto.UseVisualStyleBackColor = True
        '
        'ckb_Serie
        '
        Me.ckb_Serie.AutoSize = True
        Me.ckb_Serie.Location = New System.Drawing.Point(20, 62)
        Me.ckb_Serie.Name = "ckb_Serie"
        Me.ckb_Serie.Size = New System.Drawing.Size(106, 17)
        Me.ckb_Serie.TabIndex = 2
        Me.ckb_Serie.Text = "Control de Series"
        Me.ckb_Serie.UseVisualStyleBackColor = True
        '
        'ckb_Lote
        '
        Me.ckb_Lote.AutoSize = True
        Me.ckb_Lote.Location = New System.Drawing.Point(20, 43)
        Me.ckb_Lote.Name = "ckb_Lote"
        Me.ckb_Lote.Size = New System.Drawing.Size(103, 17)
        Me.ckb_Lote.TabIndex = 1
        Me.ckb_Lote.Text = "Control de Lotes"
        Me.ckb_Lote.UseVisualStyleBackColor = True
        '
        'ckb_Iva
        '
        Me.ckb_Iva.AutoSize = True
        Me.ckb_Iva.Location = New System.Drawing.Point(20, 25)
        Me.ckb_Iva.Name = "ckb_Iva"
        Me.ckb_Iva.Size = New System.Drawing.Size(43, 17)
        Me.ckb_Iva.TabIndex = 0
        Me.ckb_Iva.Text = "IVA"
        Me.ckb_Iva.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.tb_cla_CmasxTar)
        Me.GroupBox6.Controls.Add(Me.tb_cla_CajasxCam)
        Me.GroupBox6.Controls.Add(Me.tb_cla_CajasxTar)
        Me.GroupBox6.Controls.Add(Me.tb_cla_Peso)
        Me.GroupBox6.Controls.Add(Me.tb_cla_volumen)
        Me.GroupBox6.Location = New System.Drawing.Point(669, 205)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(179, 164)
        Me.GroupBox6.TabIndex = 84
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Clasificadores"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 132)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Camas x Tar:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Cajas x Cam:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Cajas x Tar:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Peso kg:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Volumen m3:"
        '
        'tb_cla_CmasxTar
        '
        Me.tb_cla_CmasxTar.Location = New System.Drawing.Point(81, 128)
        Me.tb_cla_CmasxTar.Name = "tb_cla_CmasxTar"
        Me.tb_cla_CmasxTar.Size = New System.Drawing.Size(84, 20)
        Me.tb_cla_CmasxTar.TabIndex = 4
        '
        'tb_cla_CajasxCam
        '
        Me.tb_cla_CajasxCam.Location = New System.Drawing.Point(81, 101)
        Me.tb_cla_CajasxCam.Name = "tb_cla_CajasxCam"
        Me.tb_cla_CajasxCam.Size = New System.Drawing.Size(84, 20)
        Me.tb_cla_CajasxCam.TabIndex = 3
        '
        'tb_cla_CajasxTar
        '
        Me.tb_cla_CajasxTar.Location = New System.Drawing.Point(81, 74)
        Me.tb_cla_CajasxTar.Name = "tb_cla_CajasxTar"
        Me.tb_cla_CajasxTar.Size = New System.Drawing.Size(84, 20)
        Me.tb_cla_CajasxTar.TabIndex = 2
        '
        'tb_cla_Peso
        '
        Me.tb_cla_Peso.Location = New System.Drawing.Point(81, 47)
        Me.tb_cla_Peso.Name = "tb_cla_Peso"
        Me.tb_cla_Peso.Size = New System.Drawing.Size(84, 20)
        Me.tb_cla_Peso.TabIndex = 1
        '
        'tb_cla_volumen
        '
        Me.tb_cla_volumen.Location = New System.Drawing.Point(81, 19)
        Me.tb_cla_volumen.Name = "tb_cla_volumen"
        Me.tb_cla_volumen.Size = New System.Drawing.Size(84, 20)
        Me.tb_cla_volumen.TabIndex = 0
        '
        'txt_codtesa
        '
        Me.txt_codtesa.Location = New System.Drawing.Point(78, 156)
        Me.txt_codtesa.Name = "txt_codtesa"
        Me.txt_codtesa.Size = New System.Drawing.Size(153, 20)
        Me.txt_codtesa.TabIndex = 77
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label22.Location = New System.Drawing.Point(3, 160)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "Codigo TESA:"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(857, 387)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form6"
        Me.Text = "Creación de Productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nud_DecimalesAlt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_Decimales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_glosa As System.Windows.Forms.TextBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipo_producto As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_unidad_medida As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents cmb_familia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_subtipo As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Tipo As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_Procedencia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nud_DecimalesAlt As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmb_Alternativa As System.Windows.Forms.ComboBox
    Friend WithEvents nud_Decimales As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_Volumen As System.Windows.Forms.TextBox
    Friend WithEvents tb_Peso As System.Windows.Forms.TextBox
    Friend WithEvents tb_Factor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ckb_ValidaStock As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_Costea As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_FechaVcto As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_Serie As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_Lote As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_Iva As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_cla_CmasxTar As System.Windows.Forms.TextBox
    Friend WithEvents tb_cla_CajasxCam As System.Windows.Forms.TextBox
    Friend WithEvents tb_cla_CajasxTar As System.Windows.Forms.TextBox
    Friend WithEvents tb_cla_Peso As System.Windows.Forms.TextBox
    Friend WithEvents tb_cla_volumen As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tb_Codigo_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents cmb_Grupo As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_codtesa As TextBox
End Class
