<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_dua_HH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_dua_HH))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl_Dua = New System.Windows.Forms.Label
        Me.txt_ingresoDua = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_lote_oculto = New System.Windows.Forms.TextBox
        Me.dgv_detalleDua = New System.Windows.Forms.DataGridView
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chk_fechavcto = New System.Windows.Forms.CheckBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_origen = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLoteProducto = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblLote = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.dtpFechaVctoProducto = New System.Windows.Forms.DateTimePicker
        Me.txt_cod_producto = New System.Windows.Forms.TextBox
        Me.txt_unidades = New System.Windows.Forms.TextBox
        Me.txt_produccion = New System.Windows.Forms.TextBox
        Me.lblFechaVcto = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.btn_agrega_producto = New System.Windows.Forms.Button
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgv_motivo_daño = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_detalleDua, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_motivo_daño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Dua
        '
        Me.lbl_Dua.AutoSize = True
        Me.lbl_Dua.Location = New System.Drawing.Point(2, 16)
        Me.lbl_Dua.Name = "lbl_Dua"
        Me.lbl_Dua.Size = New System.Drawing.Size(82, 13)
        Me.lbl_Dua.TabIndex = 0
        Me.lbl_Dua.Text = "Numero de Dua"
        '
        'txt_ingresoDua
        '
        Me.txt_ingresoDua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ingresoDua.Location = New System.Drawing.Point(90, 11)
        Me.txt_ingresoDua.Name = "txt_ingresoDua"
        Me.txt_ingresoDua.Size = New System.Drawing.Size(121, 20)
        Me.txt_ingresoDua.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.cmb_proveedor)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.btn_imprimir)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.btn_grabar)
        Me.GroupBox3.Controls.Add(Me.txt_ingresoDua)
        Me.GroupBox3.Controls.Add(Me.lbl_Dua)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(721, 112)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Traslado de Dua"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_proveedor.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(90, 38)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(362, 21)
        Me.cmb_proveedor.TabIndex = 42
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 5
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(608, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 47)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Actualizar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "3.png")
        Me.ImageList1.Images.SetKeyName(1, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(2, "DeleteRed.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "127.png")
        Me.ImageList1.Images.SetKeyName(5, "Refresh48.png")
        Me.ImageList1.Images.SetKeyName(6, "2.png")
        Me.ImageList1.Images.SetKeyName(7, "clear.png")
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprimir.ImageIndex = 3
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(609, 5)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(100, 47)
        Me.btn_imprimir.TabIndex = 4
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 6
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(503, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 47)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Informe Prueba"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_grabar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.White
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_grabar.ImageIndex = 1
        Me.btn_grabar.ImageList = Me.ImageList1
        Me.btn_grabar.Location = New System.Drawing.Point(503, 57)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(100, 47)
        Me.btn_grabar.TabIndex = 2
        Me.btn_grabar.Text = "Guardar"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(2, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Proveedor"
        '
        'txt_lote_oculto
        '
        Me.txt_lote_oculto.BackColor = System.Drawing.Color.White
        Me.txt_lote_oculto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lote_oculto.Location = New System.Drawing.Point(535, 217)
        Me.txt_lote_oculto.Name = "txt_lote_oculto"
        Me.txt_lote_oculto.Size = New System.Drawing.Size(58, 20)
        Me.txt_lote_oculto.TabIndex = 116
        Me.txt_lote_oculto.Visible = False
        '
        'dgv_detalleDua
        '
        Me.dgv_detalleDua.AllowUserToAddRows = False
        Me.dgv_detalleDua.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_detalleDua.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_detalleDua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalleDua.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_detalleDua.Location = New System.Drawing.Point(12, 174)
        Me.dgv_detalleDua.Name = "dgv_detalleDua"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_detalleDua.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_detalleDua.RowHeadersWidth = 20
        Me.dgv_detalleDua.Size = New System.Drawing.Size(999, 307)
        Me.dgv_detalleDua.TabIndex = 93
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chk_fechavcto)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.txt_origen)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtLoteProducto)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.lblLote)
        Me.GroupBox5.Controls.Add(Me.txt_descripcion)
        Me.GroupBox5.Controls.Add(Me.dtpFechaVctoProducto)
        Me.GroupBox5.Controls.Add(Me.txt_cod_producto)
        Me.GroupBox5.Controls.Add(Me.txt_unidades)
        Me.GroupBox5.Controls.Add(Me.txt_produccion)
        Me.GroupBox5.Controls.Add(Me.lblFechaVcto)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(721, 49)
        Me.GroupBox5.TabIndex = 94
        Me.GroupBox5.TabStop = False
        '
        'chk_fechavcto
        '
        Me.chk_fechavcto.AutoSize = True
        Me.chk_fechavcto.Location = New System.Drawing.Point(425, 30)
        Me.chk_fechavcto.Name = "chk_fechavcto"
        Me.chk_fechavcto.Size = New System.Drawing.Size(15, 14)
        Me.chk_fechavcto.TabIndex = 116
        Me.chk_fechavcto.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(93, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 15)
        Me.Label19.TabIndex = 103
        Me.Label19.Text = "Glosa"
        '
        'txt_origen
        '
        Me.txt_origen.BackColor = System.Drawing.Color.White
        Me.txt_origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_origen.Location = New System.Drawing.Point(653, 26)
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.Size = New System.Drawing.Size(58, 20)
        Me.txt_origen.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(656, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Origen"
        '
        'txtLoteProducto
        '
        Me.txtLoteProducto.BackColor = System.Drawing.Color.White
        Me.txtLoteProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoteProducto.Location = New System.Drawing.Point(596, 26)
        Me.txtLoteProducto.Name = "txtLoteProducto"
        Me.txtLoteProducto.Size = New System.Drawing.Size(58, 20)
        Me.txtLoteProducto.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(353, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "Unidades"
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.BackColor = System.Drawing.Color.Transparent
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(604, 5)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(35, 15)
        Me.lblLote.TabIndex = 113
        Me.lblLote.Text = "Lote"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(66, 26)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(298, 20)
        Me.txt_descripcion.TabIndex = 2
        '
        'dtpFechaVctoProducto
        '
        Me.dtpFechaVctoProducto.Enabled = False
        Me.dtpFechaVctoProducto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVctoProducto.Location = New System.Drawing.Point(440, 26)
        Me.dtpFechaVctoProducto.Name = "dtpFechaVctoProducto"
        Me.dtpFechaVctoProducto.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaVctoProducto.TabIndex = 8
        '
        'txt_cod_producto
        '
        Me.txt_cod_producto.BackColor = System.Drawing.Color.White
        Me.txt_cod_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_producto.Location = New System.Drawing.Point(0, 26)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.ReadOnly = True
        Me.txt_cod_producto.Size = New System.Drawing.Size(67, 20)
        Me.txt_cod_producto.TabIndex = 1
        '
        'txt_unidades
        '
        Me.txt_unidades.BackColor = System.Drawing.Color.White
        Me.txt_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidades.Location = New System.Drawing.Point(363, 26)
        Me.txt_unidades.Name = "txt_unidades"
        Me.txt_unidades.Size = New System.Drawing.Size(58, 20)
        Me.txt_unidades.TabIndex = 3
        '
        'txt_produccion
        '
        Me.txt_produccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_produccion.Location = New System.Drawing.Point(522, 26)
        Me.txt_produccion.Name = "txt_produccion"
        Me.txt_produccion.Size = New System.Drawing.Size(76, 20)
        Me.txt_produccion.TabIndex = 4
        '
        'lblFechaVcto
        '
        Me.lblFechaVcto.AutoSize = True
        Me.lblFechaVcto.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaVcto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaVcto.Location = New System.Drawing.Point(437, 5)
        Me.lblFechaVcto.Name = "lblFechaVcto"
        Me.lblFechaVcto.Size = New System.Drawing.Size(77, 15)
        Me.lblFechaVcto.TabIndex = 113
        Me.lblFechaVcto.Text = "Fecha Vcto"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(519, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 15)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "Produccion"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 15)
        Me.Label18.TabIndex = 99
        Me.Label18.Text = "Producto"
        '
        'btn_agrega_producto
        '
        Me.btn_agrega_producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agrega_producto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agrega_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agrega_producto.ForeColor = System.Drawing.Color.White
        Me.btn_agrega_producto.ImageIndex = 0
        Me.btn_agrega_producto.ImageList = Me.ImageList3
        Me.btn_agrega_producto.Location = New System.Drawing.Point(235, 145)
        Me.btn_agrega_producto.Name = "btn_agrega_producto"
        Me.btn_agrega_producto.Size = New System.Drawing.Size(38, 22)
        Me.btn_agrega_producto.TabIndex = 9
        Me.btn_agrega_producto.Tag = ""
        Me.btn_agrega_producto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agrega_producto.UseVisualStyleBackColor = False
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "")
        Me.ImageList3.Images.SetKeyName(1, "")
        '
        'dgv_motivo_daño
        '
        Me.dgv_motivo_daño.AllowUserToAddRows = False
        Me.dgv_motivo_daño.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_motivo_daño.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_motivo_daño.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_motivo_daño.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_motivo_daño.Location = New System.Drawing.Point(6, 19)
        Me.dgv_motivo_daño.Name = "dgv_motivo_daño"
        Me.dgv_motivo_daño.RowHeadersWidth = 20
        Me.dgv_motivo_daño.Size = New System.Drawing.Size(230, 148)
        Me.dgv_motivo_daño.TabIndex = 118
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_motivo_daño)
        Me.GroupBox1.Controls.Add(Me.btn_agrega_producto)
        Me.GroupBox1.Location = New System.Drawing.Point(738, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 173)
        Me.GroupBox1.TabIndex = 119
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Unidades Malas"
        '
        'frm_dua_HH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 496)
        Me.Controls.Add(Me.txt_lote_oculto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.dgv_detalleDua)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frm_dua_HH"
        Me.Text = ":: TRASLADO DUA ::"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_detalleDua, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_motivo_daño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Dua As System.Windows.Forms.Label
    Friend WithEvents txt_ingresoDua As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgv_detalleDua As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaVctoProducto As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLoteProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaVcto As System.Windows.Forms.Label
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents txt_produccion As System.Windows.Forms.TextBox
    Friend WithEvents btn_agrega_producto As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_unidades As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_motivo_daño As System.Windows.Forms.DataGridView
    Friend WithEvents txt_lote_oculto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_fechavcto As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
