<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_solicitud_reserva
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_solicitud_reserva))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_cant_caja = New System.Windows.Forms.TextBox
        Me.btn_ayuda_producto = New System.Windows.Forms.Button
        Me.txt_bultos = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cm_nuevo_prod = New System.Windows.Forms.Button
        Me.txt_cod_producto = New System.Windows.Forms.TextBox
        Me.lbl_proveedor = New System.Windows.Forms.Label
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.txt_unidades = New System.Windows.Forms.TextBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_borrar = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_estatus = New System.Windows.Forms.ComboBox
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgv_lista_ingresos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_lista_ingresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(752, 496)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(744, 470)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Solicitud de Reserva"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.txt_cant_caja)
        Me.GroupBox2.Controls.Add(Me.btn_ayuda_producto)
        Me.GroupBox2.Controls.Add(Me.txt_bultos)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cm_nuevo_prod)
        Me.GroupBox2.Controls.Add(Me.txt_cod_producto)
        Me.GroupBox2.Controls.Add(Me.lbl_proveedor)
        Me.GroupBox2.Controls.Add(Me.btn_agregar)
        Me.GroupBox2.Controls.Add(Me.txt_unidades)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 107)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 95)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txt_cant_caja
        '
        Me.txt_cant_caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cant_caja.Location = New System.Drawing.Point(250, 64)
        Me.txt_cant_caja.Name = "txt_cant_caja"
        Me.txt_cant_caja.ReadOnly = True
        Me.txt_cant_caja.Size = New System.Drawing.Size(165, 20)
        Me.txt_cant_caja.TabIndex = 10
        Me.txt_cant_caja.TabStop = False
        Me.txt_cant_caja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_ayuda_producto
        '
        Me.btn_ayuda_producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_producto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_producto.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_producto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda_producto.Location = New System.Drawing.Point(167, 16)
        Me.btn_ayuda_producto.Name = "btn_ayuda_producto"
        Me.btn_ayuda_producto.Size = New System.Drawing.Size(28, 20)
        Me.btn_ayuda_producto.TabIndex = 2
        Me.btn_ayuda_producto.Text = "..."
        Me.btn_ayuda_producto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ayuda_producto.UseVisualStyleBackColor = False
        '
        'txt_bultos
        '
        Me.txt_bultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bultos.Location = New System.Drawing.Point(192, 64)
        Me.txt_bultos.Name = "txt_bultos"
        Me.txt_bultos.Size = New System.Drawing.Size(52, 20)
        Me.txt_bultos.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(148, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Bultos:"
        '
        'cm_nuevo_prod
        '
        Me.cm_nuevo_prod.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.cm_nuevo_prod.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cm_nuevo_prod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nuevo_prod.ForeColor = System.Drawing.Color.White
        Me.cm_nuevo_prod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cm_nuevo_prod.ImageIndex = 7
        Me.cm_nuevo_prod.ImageList = Me.ImageList1
        Me.cm_nuevo_prod.Location = New System.Drawing.Point(576, 24)
        Me.cm_nuevo_prod.Name = "cm_nuevo_prod"
        Me.cm_nuevo_prod.Size = New System.Drawing.Size(131, 51)
        Me.cm_nuevo_prod.TabIndex = 12
        Me.cm_nuevo_prod.Tag = "NUEVO"
        Me.cm_nuevo_prod.Text = "Limpiar Información"
        Me.cm_nuevo_prod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cm_nuevo_prod.UseVisualStyleBackColor = False
        '
        'txt_cod_producto
        '
        Me.txt_cod_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_producto.Location = New System.Drawing.Point(90, 16)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.Size = New System.Drawing.Size(77, 20)
        Me.txt_cod_producto.TabIndex = 1
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_proveedor.Location = New System.Drawing.Point(201, 16)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(214, 20)
        Me.lbl_proveedor.TabIndex = 3
        Me.lbl_proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.White
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_agregar.ImageIndex = 5
        Me.btn_agregar.ImageList = Me.ImageList1
        Me.btn_agregar.Location = New System.Drawing.Point(433, 24)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(123, 51)
        Me.btn_agregar.TabIndex = 11
        Me.btn_agregar.Tag = "NUEVO"
        Me.btn_agregar.Text = "Actulizar produto"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'txt_unidades
        '
        Me.txt_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidades.Location = New System.Drawing.Point(90, 64)
        Me.txt_unidades.Name = "txt_unidades"
        Me.txt_unidades.Size = New System.Drawing.Size(52, 20)
        Me.txt_unidades.TabIndex = 7
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(90, 40)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(325, 20)
        Me.txt_descripcion.TabIndex = 5
        Me.txt_descripcion.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Producto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(24, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Descripcion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(35, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Unidades:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgv_detalle)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 208)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(726, 254)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_detalle.Location = New System.Drawing.Point(3, 16)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.Size = New System.Drawing.Size(720, 235)
        Me.dgv_detalle.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btn_imprimir)
        Me.GroupBox7.Controls.Add(Me.btn_borrar)
        Me.GroupBox7.Controls.Add(Me.btn_grabar)
        Me.GroupBox7.Controls.Add(Me.btn_nuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(442, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(284, 106)
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
        Me.btn_imprimir.Location = New System.Drawing.Point(16, 55)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(107, 51)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.UseVisualStyleBackColor = False
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
        Me.btn_borrar.Location = New System.Drawing.Point(167, 54)
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
        Me.btn_grabar.Location = New System.Drawing.Point(167, -3)
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
        Me.btn_nuevo.Location = New System.Drawing.Point(16, 0)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(107, 51)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_estatus)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha)
        Me.GroupBox1.Controls.Add(Me.txtObservaciones)
        Me.GroupBox1.Controls.Add(Me.txt_numero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 95)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmb_estatus
        '
        Me.cmb_estatus.FormattingEnabled = True
        Me.cmb_estatus.Items.AddRange(New Object() {"CREADA", "APROBADA", "RECHAZADA", "PROCESADA"})
        Me.cmb_estatus.Location = New System.Drawing.Point(284, 39)
        Me.cmb_estatus.Name = "cmb_estatus"
        Me.cmb_estatus.Size = New System.Drawing.Size(105, 21)
        Me.cmb_estatus.TabIndex = 5
        Me.cmb_estatus.TabStop = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.CustomFormat = "MMMM dd,  yyyy"
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(62, 13)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(105, 20)
        Me.dtp_fecha.TabIndex = 1
        Me.dtp_fecha.TabStop = False
        '
        'txt_numero
        '
        Me.txt_numero.BackColor = System.Drawing.Color.White
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(284, 15)
        Me.txt_numero.MaxLength = 30
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(105, 22)
        Me.txt_numero.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "No. Solicitud:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(189, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Estatus:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgv_lista_ingresos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(744, 470)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "  Lista de Solicitudes"
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
        Me.dgv_lista_ingresos.Size = New System.Drawing.Size(738, 464)
        Me.dgv_lista_ingresos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Obs:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(9, 62)
        Me.txtObservaciones.MaxLength = 30
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(380, 22)
        Me.txtObservaciones.TabIndex = 3
        '
        'frm_solicitud_reserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_solicitud_reserva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Solicitud de Reservas .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_lista_ingresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ayuda_producto As System.Windows.Forms.Button
    Friend WithEvents txt_bultos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cm_nuevo_prod As System.Windows.Forms.Button
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_unidades As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_estatus As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_borrar As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_lista_ingresos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_cant_caja As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
