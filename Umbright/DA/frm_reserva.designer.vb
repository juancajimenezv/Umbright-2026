<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reserva
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reserva))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_estatus = New System.Windows.Forms.ComboBox()
        Me.btn_ayuda_oc = New System.Windows.Forms.Button()
        Me.txt_dua = New System.Windows.Forms.TextBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_bodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txt_cod_provee = New System.Windows.Forms.TextBox()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.txt_bultos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_cod_producto = New System.Windows.Forms.TextBox()
        Me.txt_saldo_u = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_saldo_b = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.txt_unidades = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.btn_borrar = New System.Windows.Forms.Button()
        Me.btn_grabar = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv_lista_ingresos = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmb_destino = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_lista_ingresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmb_destino)
        Me.GroupBox1.Controls.Add(Me.cmb_estatus)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda_oc)
        Me.GroupBox1.Controls.Add(Me.txt_dua)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha)
        Me.GroupBox1.Controls.Add(Me.txt_numero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb_bodega)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtObservaciones)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(50, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Obs:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Estatus:"
        '
        'cmb_estatus
        '
        Me.cmb_estatus.FormattingEnabled = True
        Me.cmb_estatus.Items.AddRange(New Object() {"CREADA", "APROBADA", "RECHAZADA", "PROCESADA"})
        Me.cmb_estatus.Location = New System.Drawing.Point(90, 104)
        Me.cmb_estatus.Name = "cmb_estatus"
        Me.cmb_estatus.Size = New System.Drawing.Size(161, 24)
        Me.cmb_estatus.TabIndex = 10
        '
        'btn_ayuda_oc
        '
        Me.btn_ayuda_oc.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_oc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_oc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_oc.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_oc.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda_oc.Location = New System.Drawing.Point(228, 43)
        Me.btn_ayuda_oc.Name = "btn_ayuda_oc"
        Me.btn_ayuda_oc.Size = New System.Drawing.Size(28, 22)
        Me.btn_ayuda_oc.TabIndex = 6
        Me.btn_ayuda_oc.Text = "..."
        Me.btn_ayuda_oc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ayuda_oc.UseVisualStyleBackColor = False
        '
        'txt_dua
        '
        Me.txt_dua.BackColor = System.Drawing.Color.White
        Me.txt_dua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dua.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dua.Location = New System.Drawing.Point(90, 42)
        Me.txt_dua.MaxLength = 30
        Me.txt_dua.Name = "txt_dua"
        Me.txt_dua.ReadOnly = True
        Me.txt_dua.Size = New System.Drawing.Size(133, 22)
        Me.txt_dua.TabIndex = 5
        '
        'dtp_fecha
        '
        Me.dtp_fecha.CustomFormat = "MMMM dd,  yyyy"
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(360, 14)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(121, 22)
        Me.dtp_fecha.TabIndex = 1
        Me.dtp_fecha.TabStop = False
        '
        'txt_numero
        '
        Me.txt_numero.BackColor = System.Drawing.Color.White
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(90, 14)
        Me.txt_numero.MaxLength = 30
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(161, 22)
        Me.txt_numero.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "No. Reserva:"
        '
        'cb_bodega
        '
        Me.cb_bodega.DropDownHeight = 120
        Me.cb_bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_bodega.DropDownWidth = 280
        Me.cb_bodega.Enabled = False
        Me.cb_bodega.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bodega.FormattingEnabled = True
        Me.cb_bodega.IntegralHeight = False
        Me.cb_bodega.ItemHeight = 16
        Me.cb_bodega.Location = New System.Drawing.Point(326, 45)
        Me.cb_bodega.Name = "cb_bodega"
        Me.cb_bodega.Size = New System.Drawing.Size(161, 24)
        Me.cb_bodega.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(268, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Bodega:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(310, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "No. Ingreso:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Location = New System.Drawing.Point(90, 129)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(391, 22)
        Me.txtObservaciones.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.txtLote)
        Me.GroupBox2.Controls.Add(Me.txt_cod_provee)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.txt_bultos)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_cod_producto)
        Me.GroupBox2.Controls.Add(Me.txt_saldo_u)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_saldo_b)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lbl_proveedor)
        Me.GroupBox2.Controls.Add(Me.txt_unidades)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(642, 115)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtLote
        '
        Me.txtLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLote.Location = New System.Drawing.Point(406, 62)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ReadOnly = True
        Me.txtLote.Size = New System.Drawing.Size(131, 22)
        Me.txtLote.TabIndex = 16
        '
        'txt_cod_provee
        '
        Me.txt_cod_provee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_provee.Location = New System.Drawing.Point(90, 37)
        Me.txt_cod_provee.Name = "txt_cod_provee"
        Me.txt_cod_provee.ReadOnly = True
        Me.txt_cod_provee.Size = New System.Drawing.Size(121, 22)
        Me.txt_cod_provee.TabIndex = 15
        Me.txt_cod_provee.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_cod_provee, "Código del producto para" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "nuestro proveedor.")
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(217, 12)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(419, 22)
        Me.txt_descripcion.TabIndex = 4
        Me.txt_descripcion.TabStop = False
        '
        'txt_bultos
        '
        Me.txt_bultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bultos.Location = New System.Drawing.Point(90, 87)
        Me.txt_bultos.Name = "txt_bultos"
        Me.txt_bultos.Size = New System.Drawing.Size(121, 22)
        Me.txt_bultos.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(39, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Bultos:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 7
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(756, 189)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 78)
        Me.Button1.TabIndex = 14
        Me.Button1.Tag = "NUEVO"
        Me.Button1.Text = "Limpiar Info."
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
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
        'txt_cod_producto
        '
        Me.txt_cod_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_producto.Location = New System.Drawing.Point(90, 12)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.ReadOnly = True
        Me.txt_cod_producto.Size = New System.Drawing.Size(121, 22)
        Me.txt_cod_producto.TabIndex = 1
        '
        'txt_saldo_u
        '
        Me.txt_saldo_u.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_saldo_u.Location = New System.Drawing.Point(323, 62)
        Me.txt_saldo_u.Name = "txt_saldo_u"
        Me.txt_saldo_u.ReadOnly = True
        Me.txt_saldo_u.Size = New System.Drawing.Size(50, 22)
        Me.txt_saldo_u.TabIndex = 8
        Me.txt_saldo_u.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(214, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Saldo Unidades:"
        '
        'txt_saldo_b
        '
        Me.txt_saldo_b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_saldo_b.Location = New System.Drawing.Point(90, 62)
        Me.txt_saldo_b.Name = "txt_saldo_b"
        Me.txt_saldo_b.ReadOnly = True
        Me.txt_saldo_b.Size = New System.Drawing.Size(121, 22)
        Me.txt_saldo_b.TabIndex = 6
        Me.txt_saldo_b.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(2, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Saldo Bultos:"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_proveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_proveedor.Location = New System.Drawing.Point(217, 37)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(419, 22)
        Me.lbl_proveedor.TabIndex = 2
        Me.lbl_proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.White
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.ImageIndex = 5
        Me.btn_agregar.ImageList = Me.ImageList1
        Me.btn_agregar.Location = New System.Drawing.Point(668, 189)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(82, 78)
        Me.btn_agregar.TabIndex = 13
        Me.btn_agregar.Tag = "NUEVO"
        Me.btn_agregar.Text = "Actualizar producto"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'txt_unidades
        '
        Me.txt_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidades.Location = New System.Drawing.Point(293, 87)
        Me.txt_unidades.Name = "txt_unidades"
        Me.txt_unidades.Size = New System.Drawing.Size(50, 22)
        Me.txt_unidades.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Producto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(19, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Proveedor:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(375, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 16)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Lote:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(221, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Unidades:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgv_detalle)
        Me.GroupBox6.Location = New System.Drawing.Point(9, 273)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(840, 280)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_detalle.Location = New System.Drawing.Point(3, 18)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.Size = New System.Drawing.Size(834, 259)
        Me.dgv_detalle.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btn_imprimir)
        Me.GroupBox7.Controls.Add(Me.btn_borrar)
        Me.GroupBox7.Controls.Add(Me.btn_grabar)
        Me.GroupBox7.Controls.Add(Me.btn_nuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(527, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(302, 142)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
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
        Me.btn_imprimir.Location = New System.Drawing.Point(35, 81)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(107, 51)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.UseVisualStyleBackColor = False
        Me.btn_imprimir.Visible = False
        '
        'btn_borrar
        '
        Me.btn_borrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_borrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_borrar.ForeColor = System.Drawing.Color.White
        Me.btn_borrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_borrar.ImageIndex = 2
        Me.btn_borrar.ImageList = Me.ImageList1
        Me.btn_borrar.Location = New System.Drawing.Point(160, 81)
        Me.btn_borrar.Name = "btn_borrar"
        Me.btn_borrar.Size = New System.Drawing.Size(107, 51)
        Me.btn_borrar.TabIndex = 3
        Me.btn_borrar.Text = "Eliminar"
        Me.btn_borrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_borrar.UseVisualStyleBackColor = False
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
        Me.btn_grabar.Location = New System.Drawing.Point(160, 17)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(107, 51)
        Me.btn_grabar.TabIndex = 1
        Me.btn_grabar.Text = "Guardar"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(35, 17)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(107, 51)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(866, 587)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.btn_agregar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(858, 558)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reserva"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgv_lista_ingresos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(663, 587)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "  Lista de Reservas"
        '
        'dgv_lista_ingresos
        '
        Me.dgv_lista_ingresos.AllowUserToAddRows = False
        Me.dgv_lista_ingresos.AllowUserToDeleteRows = False
        Me.dgv_lista_ingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lista_ingresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_lista_ingresos.Location = New System.Drawing.Point(3, 3)
        Me.dgv_lista_ingresos.Name = "dgv_lista_ingresos"
        Me.dgv_lista_ingresos.ReadOnly = True
        Me.dgv_lista_ingresos.RowHeadersWidth = 25
        Me.dgv_lista_ingresos.Size = New System.Drawing.Size(657, 581)
        Me.dgv_lista_ingresos.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'cmb_destino
        '
        Me.cmb_destino.FormattingEnabled = True
        Me.cmb_destino.Items.AddRange(New Object() {"EL SALVADOR", "HONDURAS", "EXONERADOS"})
        Me.cmb_destino.Location = New System.Drawing.Point(90, 74)
        Me.cmb_destino.Name = "cmb_destino"
        Me.cmb_destino.Size = New System.Drawing.Size(161, 24)
        Me.cmb_destino.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(31, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 16)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Destino:"
        '
        'frm_reserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(866, 587)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_reserva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Mantenedor de Reservas .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_lista_ingresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_unidades As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_borrar As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_lista_ingresos As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btn_ayuda_oc As System.Windows.Forms.Button
    Friend WithEvents txt_dua As System.Windows.Forms.TextBox
    Friend WithEvents txt_saldo_u As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents txt_saldo_b As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_bultos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_estatus As System.Windows.Forms.ComboBox
    Friend WithEvents txt_cod_provee As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmb_destino As ComboBox
End Class
