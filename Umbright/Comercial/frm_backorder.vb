Public Class frm_backorder
    Inherits System.Windows.Forms.Form
    Dim ds As DataSet

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
    Friend WithEvents btnProcesarCambios As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_aprobacion_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txt_aprobacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_grabo As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_lista_precios As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_top_pedidos As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_picking As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_factura_generada As System.Windows.Forms.DataGrid
    Friend WithEvents btn_tracking As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGrid
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha_genero_tracking As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_pedido_tracking As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_pedido_tracking As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_pedido_tracking As System.Windows.Forms.TextBox
    Friend WithEvents cmbCoordinador As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dgv_listadoProductos As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_productos_pedido As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_control_transporte As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cliente As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_backorder))
        Me.btnProcesarCambios = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_top_pedidos = New System.Windows.Forms.Button()
        Me.btn_tracking = New System.Windows.Forms.Button()
        Me.btn_cliente = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgv_listadoProductos = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv_productos_pedido = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox()
        Me.txt_aprobacion_pedido = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_total_pedido = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.txt_aprobacion = New System.Windows.Forms.TextBox()
        Me.txt_fecha_grabo = New System.Windows.Forms.TextBox()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.txt_lista_precios = New System.Windows.Forms.TextBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.txt_tipo_pedido = New System.Windows.Forms.TextBox()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_direccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txt_fecha_genero_tracking = New System.Windows.Forms.TextBox()
        Me.txt_fecha_pedido_tracking = New System.Windows.Forms.TextBox()
        Me.txt_numero_pedido_tracking = New System.Windows.Forms.TextBox()
        Me.txt_tipo_pedido_tracking = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGrid()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dg_picking = New System.Windows.Forms.DataGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgv_control_transporte = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dg_factura_generada = New System.Windows.Forms.DataGrid()
        Me.cmbCoordinador = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_listadoProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_productos_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_control_transporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_factura_generada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnProcesarCambios
        '
        Me.btnProcesarCambios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcesarCambios.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesarCambios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesarCambios.ForeColor = System.Drawing.Color.White
        Me.btnProcesarCambios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarCambios.ImageIndex = 1
        Me.btnProcesarCambios.ImageList = Me.ImageList1
        Me.btnProcesarCambios.Location = New System.Drawing.Point(836, 144)
        Me.btnProcesarCambios.Name = "btnProcesarCambios"
        Me.btnProcesarCambios.Size = New System.Drawing.Size(97, 72)
        Me.btnProcesarCambios.TabIndex = 25
        Me.btnProcesarCambios.Text = "Procesar Cambios"
        Me.btnProcesarCambios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnProcesarCambios, "Cliente No Recibe Back_Order")
        Me.btnProcesarCambios.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        Me.ImageList1.Images.SetKeyName(1, "engranaje1.png")
        Me.ImageList1.Images.SetKeyName(2, "2.png")
        Me.ImageList1.Images.SetKeyName(3, "info cliente.png")
        Me.ImageList1.Images.SetKeyName(4, "66.png")
        Me.ImageList1.Images.SetKeyName(5, "Remove User.png")
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.ImageIndex = 5
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(836, 408)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 64)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Quitar Cliente"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button2, "Cliente No Recibe Back_Order")
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'btn_top_pedidos
        '
        Me.btn_top_pedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_top_pedidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_top_pedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_top_pedidos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_top_pedidos.ForeColor = System.Drawing.Color.White
        Me.btn_top_pedidos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_top_pedidos.ImageIndex = 2
        Me.btn_top_pedidos.ImageList = Me.ImageList1
        Me.btn_top_pedidos.Location = New System.Drawing.Point(836, 216)
        Me.btn_top_pedidos.Name = "btn_top_pedidos"
        Me.btn_top_pedidos.Size = New System.Drawing.Size(97, 64)
        Me.btn_top_pedidos.TabIndex = 25
        Me.btn_top_pedidos.Text = "Top Pedidos"
        Me.btn_top_pedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btn_top_pedidos, "Ultimos 10 Pedidos de Cliente")
        Me.btn_top_pedidos.UseVisualStyleBackColor = False
        '
        'btn_tracking
        '
        Me.btn_tracking.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_tracking.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_tracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_tracking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tracking.ForeColor = System.Drawing.Color.White
        Me.btn_tracking.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_tracking.ImageIndex = 4
        Me.btn_tracking.ImageList = Me.ImageList1
        Me.btn_tracking.Location = New System.Drawing.Point(836, 280)
        Me.btn_tracking.Name = "btn_tracking"
        Me.btn_tracking.Size = New System.Drawing.Size(97, 64)
        Me.btn_tracking.TabIndex = 25
        Me.btn_tracking.Text = "Tracking"
        Me.btn_tracking.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btn_tracking, "Trancking del Pedido")
        Me.btn_tracking.UseVisualStyleBackColor = False
        '
        'btn_cliente
        '
        Me.btn_cliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cliente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cliente.ForeColor = System.Drawing.Color.White
        Me.btn_cliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cliente.ImageIndex = 3
        Me.btn_cliente.ImageList = Me.ImageList1
        Me.btn_cliente.Location = New System.Drawing.Point(836, 344)
        Me.btn_cliente.Name = "btn_cliente"
        Me.btn_cliente.Size = New System.Drawing.Size(97, 64)
        Me.btn_cliente.TabIndex = 25
        Me.btn_cliente.Text = "Info. Cliente"
        Me.btn_cliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btn_cliente, "Informacion de Cliente")
        Me.btn_cliente.UseVisualStyleBackColor = False
        Me.btn_cliente.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(389, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 59)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(93, 49)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_inicio.TabIndex = 3
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(295, 49)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_final.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(781, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Todos"
        Me.CheckBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Final"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 78)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(944, 511)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.dgv_listadoProductos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(936, 483)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado de Productos"
        '
        'dgv_listadoProductos
        '
        Me.dgv_listadoProductos.AllowUserToAddRows = False
        Me.dgv_listadoProductos.AllowUserToDeleteRows = False
        Me.dgv_listadoProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listadoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listadoProductos.Location = New System.Drawing.Point(3, 3)
        Me.dgv_listadoProductos.Name = "dgv_listadoProductos"
        Me.dgv_listadoProductos.ReadOnly = True
        Me.dgv_listadoProductos.RowHeadersWidth = 25
        Me.dgv_listadoProductos.Size = New System.Drawing.Size(930, 446)
        Me.dgv_listadoProductos.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgv_productos_pedido)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.btnProcesarCambios)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.btn_top_pedidos)
        Me.TabPage2.Controls.Add(Me.btn_tracking)
        Me.TabPage2.Controls.Add(Me.btn_cliente)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(936, 483)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle de Pedido"
        '
        'dgv_productos_pedido
        '
        Me.dgv_productos_pedido.AllowUserToAddRows = False
        Me.dgv_productos_pedido.AllowUserToDeleteRows = False
        Me.dgv_productos_pedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_productos_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos_pedido.Location = New System.Drawing.Point(8, 150)
        Me.dgv_productos_pedido.Name = "dgv_productos_pedido"
        Me.dgv_productos_pedido.RowHeadersWidth = 25
        Me.dgv_productos_pedido.Size = New System.Drawing.Size(822, 284)
        Me.dgv_productos_pedido.TabIndex = 28
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txt_cod_cliente)
        Me.GroupBox2.Controls.Add(Me.txt_aprobacion_pedido)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_total_pedido)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_porcentaje)
        Me.GroupBox2.Controls.Add(Me.txt_aprobacion)
        Me.GroupBox2.Controls.Add(Me.txt_fecha_grabo)
        Me.GroupBox2.Controls.Add(Me.txt_fecha)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Controls.Add(Me.txt_lista_precios)
        Me.GroupBox2.Controls.Add(Me.txt_vendedor)
        Me.GroupBox2.Controls.Add(Me.txt_tipo_pedido)
        Me.GroupBox2.Controls.Add(Me.txt_comentario)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_direccion)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(928, 136)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pedido"
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_cliente.Location = New System.Drawing.Point(80, 16)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.Size = New System.Drawing.Size(88, 20)
        Me.txt_cod_cliente.TabIndex = 22
        '
        'txt_aprobacion_pedido
        '
        Me.txt_aprobacion_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion_pedido.Location = New System.Drawing.Point(806, 64)
        Me.txt_aprobacion_pedido.Name = "txt_aprobacion_pedido"
        Me.txt_aprobacion_pedido.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion_pedido.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(745, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Aprobacion"
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_pedido.Location = New System.Drawing.Point(448, 64)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.Size = New System.Drawing.Size(80, 20)
        Me.txt_total_pedido.TabIndex = 19
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(411, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Total Pedido"
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_porcentaje.Location = New System.Drawing.Point(624, 64)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.Size = New System.Drawing.Size(40, 20)
        Me.txt_porcentaje.TabIndex = 17
        '
        'txt_aprobacion
        '
        Me.txt_aprobacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion.Location = New System.Drawing.Point(806, 40)
        Me.txt_aprobacion.Name = "txt_aprobacion"
        Me.txt_aprobacion.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion.TabIndex = 16
        '
        'txt_fecha_grabo
        '
        Me.txt_fecha_grabo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_grabo.Location = New System.Drawing.Point(624, 40)
        Me.txt_fecha_grabo.Name = "txt_fecha_grabo"
        Me.txt_fecha_grabo.Size = New System.Drawing.Size(112, 20)
        Me.txt_fecha_grabo.TabIndex = 15
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(448, 40)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.Size = New System.Drawing.Size(80, 20)
        Me.txt_fecha.TabIndex = 14
        Me.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(296, 40)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(112, 20)
        Me.txt_numero.TabIndex = 13
        '
        'txt_lista_precios
        '
        Me.txt_lista_precios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lista_precios.Location = New System.Drawing.Point(296, 64)
        Me.txt_lista_precios.Name = "txt_lista_precios"
        Me.txt_lista_precios.Size = New System.Drawing.Size(112, 20)
        Me.txt_lista_precios.TabIndex = 12
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vendedor.Location = New System.Drawing.Point(80, 64)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(128, 20)
        Me.txt_vendedor.TabIndex = 11
        '
        'txt_tipo_pedido
        '
        Me.txt_tipo_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_pedido.Location = New System.Drawing.Point(80, 40)
        Me.txt_tipo_pedido.Name = "txt_tipo_pedido"
        Me.txt_tipo_pedido.Size = New System.Drawing.Size(128, 20)
        Me.txt_tipo_pedido.TabIndex = 10
        '
        'txt_comentario
        '
        Me.txt_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentario.Location = New System.Drawing.Point(80, 88)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(816, 40)
        Me.txt_comentario.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(538, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 16)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "% Facturado"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 23)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Comentario"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(745, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Estado"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(214, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Lista de Precios"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Vendedor"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(536, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Fecha Generado"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(410, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(214, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tipo de Pedido"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(176, 16)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(352, 20)
        Me.txt_nombre_cliente.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cliente"
        '
        'txt_direccion
        '
        Me.txt_direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_direccion.Location = New System.Drawing.Point(624, 16)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(272, 20)
        Me.txt_direccion.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(536, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Direccion"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.txt_fecha_genero_tracking)
        Me.TabPage3.Controls.Add(Me.txt_fecha_pedido_tracking)
        Me.TabPage3.Controls.Add(Me.txt_numero_pedido_tracking)
        Me.TabPage3.Controls.Add(Me.txt_tipo_pedido_tracking)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(936, 483)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tracking Pedido"
        '
        'txt_fecha_genero_tracking
        '
        Me.txt_fecha_genero_tracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_genero_tracking.Enabled = False
        Me.txt_fecha_genero_tracking.Location = New System.Drawing.Point(714, 13)
        Me.txt_fecha_genero_tracking.Name = "txt_fecha_genero_tracking"
        Me.txt_fecha_genero_tracking.Size = New System.Drawing.Size(112, 21)
        Me.txt_fecha_genero_tracking.TabIndex = 23
        '
        'txt_fecha_pedido_tracking
        '
        Me.txt_fecha_pedido_tracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_pedido_tracking.Enabled = False
        Me.txt_fecha_pedido_tracking.Location = New System.Drawing.Point(519, 13)
        Me.txt_fecha_pedido_tracking.Name = "txt_fecha_pedido_tracking"
        Me.txt_fecha_pedido_tracking.Size = New System.Drawing.Size(80, 21)
        Me.txt_fecha_pedido_tracking.TabIndex = 22
        Me.txt_fecha_pedido_tracking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero_pedido_tracking
        '
        Me.txt_numero_pedido_tracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero_pedido_tracking.Enabled = False
        Me.txt_numero_pedido_tracking.Location = New System.Drawing.Point(350, 13)
        Me.txt_numero_pedido_tracking.Name = "txt_numero_pedido_tracking"
        Me.txt_numero_pedido_tracking.Size = New System.Drawing.Size(112, 21)
        Me.txt_numero_pedido_tracking.TabIndex = 21
        '
        'txt_tipo_pedido_tracking
        '
        Me.txt_tipo_pedido_tracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_pedido_tracking.Enabled = False
        Me.txt_tipo_pedido_tracking.Location = New System.Drawing.Point(114, 13)
        Me.txt_tipo_pedido_tracking.Name = "txt_tipo_pedido_tracking"
        Me.txt_tipo_pedido_tracking.Size = New System.Drawing.Size(168, 21)
        Me.txt_tipo_pedido_tracking.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(607, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 15)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Fecha Generado"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(470, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 15)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Fecha"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(290, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 15)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Numero"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(90, 15)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Tipo de Pedido"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 384)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(904, 75)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Devoluciones"
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_devoluciones.CaptionVisible = False
        Me.dg_devoluciones.DataMember = ""
        Me.dg_devoluciones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_devoluciones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_devoluciones.Location = New System.Drawing.Point(8, 20)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.ReadOnly = True
        Me.dg_devoluciones.Size = New System.Drawing.Size(888, 47)
        Me.dg_devoluciones.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.dg_picking)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(904, 102)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Picking"
        '
        'dg_picking
        '
        Me.dg_picking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_picking.CaptionVisible = False
        Me.dg_picking.DataMember = ""
        Me.dg_picking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_picking.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_picking.Location = New System.Drawing.Point(8, 20)
        Me.dg_picking.Name = "dg_picking"
        Me.dg_picking.ReadOnly = True
        Me.dg_picking.Size = New System.Drawing.Size(888, 74)
        Me.dg_picking.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgv_control_transporte)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 266)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(904, 104)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Control de Transporte"
        '
        'dgv_control_transporte
        '
        Me.dgv_control_transporte.AllowUserToAddRows = False
        Me.dgv_control_transporte.AllowUserToDeleteRows = False
        Me.dgv_control_transporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_control_transporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_control_transporte.Location = New System.Drawing.Point(8, 21)
        Me.dgv_control_transporte.Name = "dgv_control_transporte"
        Me.dgv_control_transporte.ReadOnly = True
        Me.dgv_control_transporte.RowHeadersVisible = False
        Me.dgv_control_transporte.Size = New System.Drawing.Size(888, 78)
        Me.dgv_control_transporte.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dg_factura_generada)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 40)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(904, 100)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Facturacion"
        '
        'dg_factura_generada
        '
        Me.dg_factura_generada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_factura_generada.CaptionVisible = False
        Me.dg_factura_generada.DataMember = ""
        Me.dg_factura_generada.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_factura_generada.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_factura_generada.Location = New System.Drawing.Point(8, 20)
        Me.dg_factura_generada.Name = "dg_factura_generada"
        Me.dg_factura_generada.ReadOnly = True
        Me.dg_factura_generada.Size = New System.Drawing.Size(888, 72)
        Me.dg_factura_generada.TabIndex = 0
        '
        'cmbCoordinador
        '
        Me.cmbCoordinador.FormattingEnabled = True
        Me.cmbCoordinador.Location = New System.Drawing.Point(93, 20)
        Me.cmbCoordinador.Name = "cmbCoordinador"
        Me.cmbCoordinador.Size = New System.Drawing.Size(290, 23)
        Me.cmbCoordinador.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(4, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 15)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Coordinador"
        '
        'frm_backorder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(944, 589)
        Me.Controls.Add(Me.cmbCoordinador)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtp_fecha_final)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_backorder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Back Order .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv_listadoProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_productos_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgv_control_transporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dg_factura_generada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub enviarCorreo(usuario_bum As String, numero_devolucion As String, sbodyMail As String, scliente As String, sDetalleTeams As String)

        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2

        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "notificacion@umbralcorp.com"
        Dim snombreRemitente As String = "Notificaciones Umbral"
        Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try




            Dim iCount As Integer = 0

            'sSubject = Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text
            sSubject = "BackOrder " & numero_devolucion & " en " & gs_empresa

            sBody = "<br>"
            sBody = sBody & "Se solicita Facturar el Complemento Siguiente  " ' & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            'sBody = sBody & Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text & "<br>"
            'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Empresa  " & gs_empresa
            sBody = sBody & " <br>"
            sBody = sBody & "Cliente  " & scliente
            sBody = sBody & " <br>"
            sBody = sBody & numero_devolucion
            sBody = sBody & " <br>"
            sBody = sBody & sbodyMail
            'If Me.txtComentario4.Text.Length > 0 Then
            'sBody = sBody & " Comentarios " & Me.txtComentario4.Text
            'End If




            Try
                Dim dtBU As DataTable
                Dim dtCorreo As DataTable


                scuentas = "facturacion@umbral.com.gt"

                Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & usuario_bum & "','" & gs_empresa & "'")
                For Each drBU As DataRow In dtUsuarioBU.Rows



                    dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drBU.Item("usuario").ToString & "'")
                    If dtCorreo.Rows.Count > 0 Then
                        If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                        scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                    End If
                Next

                'Usuario que esta procesando

                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & gs_usuario & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If


                Dim lsSQL1 As String = "pa_sel_um_sg_usuario_nombre_email null,'" & Me.txt_vendedor.Text & "'"
                dtCorreo = clsGen.selectQuery("FlexLine", lsSQL1)
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If


            Catch ex As Exception
                clsGen.Escribir_Log(ex.Message)

            End Try


            clsGen.enviarcorreo(sRemitente, snombreRemitente, scuentas, sSubject, sBody, "")

            'Envios a TEAMS
            '(c)

            Try
                Dim lsUsuarioFacturacion As String = clsGen.Obtener_XMLConfig("correo_facturacion", False)

                Dim lsSQL As String
                Dim lsIDUnico As String = sSubject

                lsSQL = "pa_ins_um_bot_avisos_teams '" & sSubject & "','" & lsUsuarioFacturacion & "','" & sDetalleTeams.Substring(0, 250) & "'"

                clsGen.insertQuery("RegionalDBintOut", lsSQL)


                '    If Not Directory.Exists(lsRutaServidor) Then
                '   Directory.CreateDirectory(lsRutaServidor)
                '  End If
            Catch ex As Exception

            End Try

            ' lsRutaServidor &= "\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            'clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub llenarCombo()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS','" & gs_empresa & "'")
            dt.DefaultView.RowFilter = "VIGENCIA <> 'N'"
            dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "texto2".Split(","))

            Me.cmbCoordinador.DataSource = dt
            Me.cmbCoordinador.ValueMember = "texto2"
            Me.cmbCoordinador.DisplayMember = "texto2"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub AgregarColumnas(ByVal dt As DataTable)

        Dim Oflex As New Umbral_Flex.productos
        Dim odt As DataTable
        dt.Columns.Add(New DataColumn("Existencia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Quitar", GetType(Boolean)))
        Try


            Dim dr As DataRow
            For Each dr In dt.Rows
                dr.Item("Agregar") = False
                dr.Item("Quitar") = False
                If dr.Item("CantidadAsignada") < dr.Item("Cantidad") Then
                    odt = Oflex.Obtener_Existencias(gs_empresa, dr.Item("producto").ToString, "CD_CENTRAL")
                    If odt.Rows.Count > 0 Then dr.Item("Existencia") = odt.Rows(0).Item("Existencia")

                End If
            Next
        Catch ex As Exception
        Finally
            Oflex.close()
            Oflex = Nothing
        End Try

        dt.DefaultView.Sort = "Existencia desc"

    End Sub

    Private Sub Cliente_Pedido_Producto()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim nrow As Integer = Me.dgv_productos_pedido.CurrentCell.RowIndex


        Try
            otrans.open()
            ls_sql = "pa_var_um_detalle_documento_cliente '" & gs_empresa & "','" & Me.txt_cod_cliente.Text & "','" & Me.dgv_productos_pedido.Item("producto", nrow).Value.ToString & "'"
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                Dim Oform As New frm_resultado

                Oform.dgv_resultado.DataSource = dt
                Oform.Text = "Ultimos Pedidos   " & dt.Rows(0).Item("producto").ToString & " - " & dt.Rows(0).Item("glosa").ToString
                ClsGen.Alinear_GridView(dt, Oform.dgv_resultado, "", "", "", "", ",cantidadasignada=facturado,", "", "", True, True, 200, 0)
                Oform.ShowDialog()
                Oform.Dispose()
                Oform = Nothing
            End If

        Catch ex As Exception
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try






    End Sub

    Private Sub Detalle_Pedido(ByVal ptipo_documento As String, ByVal pcorrelativo As String, ByVal pnumero As String)
        Dim clgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")


        ls_sql = "pa_var_um_documento_detalle_tracking  '" & gs_empresa & "','" & _
                    ptipo_documento & "'," & pcorrelativo

        Try

            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            'Me.dg_productos_pedido.DataSource = dt

            AgregarColumnas(dt)


            Me.dgv_productos_pedido.DataSource = dt
            clgen.Alinear_GridViewEnteros = ",cantidad,cantidadasignada,da_central,"
            clgen.Alinear_GridView(dt, Me.dgv_productos_pedido, "", ",quitar,", ",producto,glosa,precio,total,cantidadasignada,existencia,bum,", "", ",cantidadasignada=facturado,", ",existencia=60,cantidadasignada=60,agregar=40,", "", True, True, 250, 0)



            'Informacion del pedido
            ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" & _
                    ptipo_documento & "','" & _
                    pnumero & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.txt_comentario.Text = dt.Rows(0).Item("comentario1")
            Me.txt_vendedor.Text = dt.Rows(0).Item("vendedor")
            Me.txt_fecha.Text = dt.Rows(0).Item("fecha")
            Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fechaumodif")
            Me.txt_lista_precios.Text = dt.Rows(0).Item("ListaPrecio")
            Me.txt_tipo_pedido.Text = dt.Rows(0).Item("TipoDocto")
            Me.txt_aprobacion.Text = dt.Rows(0).Item("descripcion")
            Me.txt_porcentaje.Text = dt.Rows(0).Item("PorcentajeAsignado")
            Me.txt_numero.Text = dt.Rows(0).Item("numero")


            If dt.Rows(0).Item("descripcion_vigencia") = "ANULADO" Then
                Me.txt_aprobacion.Text = "ANULADO"
            End If
            Me.txt_total_pedido.Text = dt.Rows(0).Item("total").ToString
            Me.txt_aprobacion_pedido.Text = dt.Rows(0).Item("fecha_aprobacion")

            Me.txt_tipo_pedido_tracking.Text = dt.Rows(0).Item("TipoDocto")
            Me.txt_numero_pedido_tracking.Text = dt.Rows(0).Item("numero")
            Me.txt_fecha_pedido_tracking.Text = dt.Rows(0).Item("fecha")
            Me.txt_fecha_genero_tracking.Text = dt.Rows(0).Item("fechaumodif")

            ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & dt.Rows(0).Item("cliente").ToString & "',NULL"
            dt = otrans.Obtiene(ls_sql)

            With dt.Rows(0)
                Me.txt_nombre_cliente.Text = .Item("nombre_cliente")
                Me.txt_cod_cliente.Text = .Item("ctacte")
                Me.txt_direccion.Text = .Item("direccion").ToString
            End With

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clgen = Nothing
            'Limpiar_pantalla(0)

        End Try

    End Sub


    Private Sub Tracking_Pedido()
        Dim ls_sql As String = String.Empty
        Dim ls_sql2 As String = String.Empty
        Dim guia_anterior As String = String.Empty
        Dim dt, dt_aux As DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim cl As DataGridColumnStyle

        Try
            Otrans.open()
            Crear_Esquema()
            Me.dgv_control_transporte.DataSource = Nothing
            Me.dg_picking.DataSource = Nothing
            Me.dg_factura_generada.DataSource = Nothing
            Me.dg_devoluciones.DataSource = Nothing




            'Picking
            ls_sql = "pa_var_um_impresion_picking '" & gs_empresa & "','" & _
                   Me.txt_tipo_pedido.Text & "','" & _
                    Me.txt_numero.Text & "'"

            dt = Otrans.Obtiene(ls_sql)

            Me.dg_picking.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_picking, dt.TableName, -1, 250, -1, False, True, ",tipo_documento,numero,fecha_impresion,nombre_picker", True, "")

            cl = Me.dg_picking.TableStyles(0).GridColumnStyles(2)
            cl.HeaderText = "Fecha Picking"


            ' facturas
            ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" & _
                    Me.txt_tipo_pedido.Text & "','" & _
                    Me.txt_numero.Text & "'"

            dt = Otrans.Obtiene(ls_sql)

            Me.dg_factura_generada.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_factura_generada, dt.TableName, -1, 250, 0, False, True, ",TipoDocto,Numero,FechaUModif,Bodega,Total", True, "")

            'cl = Me.dg_factura_generada.TableStyles(0).GridColumnStyles(5)
            'cl.HeaderText = "Fecha Facturado"
            dt.TableName = "facturas_generadas"
            If ds.Tables.IndexOf("facturas_generadas") > 0 Then ds.Tables.Remove("facturas_generadas")

            ds.Tables.Add(dt.Copy)


            'Guia de Transporte
            For Each dr In dt.Rows

                ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" & _
                            dr.Item("TipoDocto") & "','" & _
                            dr.Item("Numero") & "'"

                ls_sql2 = "pa_var_um_documento_control_transporte '" & gs_empresa & "','" & _
                            dr.Item("TipoDocto") & "','" & _
                            dr.Item("Numero") & "'"

                dt_aux = Otrans.Obtiene(ls_sql)

                If dt_aux.Rows.Count > 0 Then
                    If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                        Agregar_Esquema(dt_aux, IIf(dt_aux.Rows(0).Item("TipoDocto").ToString.ToUpper.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones"))

                        'dt2.ImportRow(dt_aux.Rows(0))
                        If dt2.Rows.Count > 0 Then Me.dgv_control_transporte.DataSource = dt2

                        guia_anterior = dt_aux.Rows(0).Item("numero")
                    End If

                Else
                    'Tengo que Buscar en la Guia Temporal
                    dt_aux = Otrans.Obtiene(ls_sql2)

                    If dt_aux.Rows.Count > 0 Then

                        ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" & _
                                "CONTROL DE TRANSPORTE','" & _
                                dt_aux.Rows(0).Item("numero_temporal") & "'"
                        dt_aux = Otrans.Obtiene(ls_sql)

                        If dt_aux.Rows.Count > 0 Then
                            If dt_aux.Rows(0).Item("numero") <> guia_anterior Then Agregar_Esquema(dt_aux, "control_transporte")

                            guia_anterior = dt_aux.Rows(0).Item("numero")
                        End If
                    End If
                End If

            Next


            Me.dgv_control_transporte.DataSource = ds.Tables("control_transporte")
            Me.dgv_control_transporte.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            ClsGen.Alinear_GridView(ds.Tables("control_transporte"), Me.dgv_control_transporte, "", "", "", "", "", "", "", True, True, 190, 0)
            'ClsGen.Alinea_Grid(ds.Tables("control_transporte"), Me.dg_control_transporte, ds.Tables("control_transporte").TableName, _
            '                           -1, 190, 0, False, True, "", True, "")

            'cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(8)
            'cl.HeaderText = "Com Liquidador"
            'cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(0)
            'cl.Width = 50

            Me.dg_devoluciones.DataSource = ds.Tables("devoluciones")

            If ds.Tables("devoluciones").Rows.Count > 0 Then
                ls_sql = "pa_sel_um_documentod '" & gs_empresa & "','" & _
                        ds.Tables("devoluciones").Rows(0).Item("tipo") & "','" & _
                        ds.Tables("devoluciones").Rows(0).Item("numero") & "'"

                dt_aux = Otrans.Obtiene(ls_sql)
                If dt_aux.Rows.Count > 0 Then
                    ds.Tables("devoluciones").Rows(0).Item("comentario") = dt_aux.Rows(0).Item("descripcion_motivo")
                End If
                ds.Tables("devoluciones").Rows(0).Item("piloto") = ""
                ds.Tables("devoluciones").Rows(0).Item("vehiculo") = ""
            End If

            ClsGen.Alinea_Grid(ds.Tables("devoluciones"), Me.dg_devoluciones, ds.Tables("devoluciones").TableName, _
                            -1, 200, 10, False, True, "tipo,numero,fecha_guia,fecha_en_control,comentario", True, "")

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            Me.TabControl1.SelectedTab = Me.TabPage3

        End Try


    End Sub

    Private Sub Crear_Esquema()
        Try
            ds = New DataSet
        Catch ex As Exception
        End Try

        Dim clGen As New ClasesGenerales.General
        Dim dt As New DataTable("control_transporte")

        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_guia", GetType(Date)))
        dt.Columns.Add(New DataColumn("fecha_en_Control", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("piloto", GetType(String)))
        dt.Columns.Add(New DataColumn("vehiculo", GetType(String)))
        dt.Columns.Add(New DataColumn("ayudante", GetType(String)))
        dt.Columns.Add(New DataColumn("chequeador", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_creditos", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("recibio_creditos", GetType(String)))

        ds.Tables.Add(dt.Copy)

        dt.TableName = "devoluciones"
        ds.Tables.Add(dt.Copy)

        dt.TableName = "controles_asociados"
        ds.Tables.Add(dt.Copy)

    End Sub

    Private Sub Agregar_Esquema(ByVal dt As DataTable, ByVal nombre_esquema As String)
        Dim dr As DataRow
        Dim dr_aux As DataRow


        For Each dr In dt.Rows

            dr_aux = ds.Tables( _
                            IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones") _
                            ).NewRow()
            dr_aux.Item("tipo") = dr.Item("TipoDocto")
            dr_aux.Item("numero") = dr.Item("numero")
            dr_aux.Item("fecha_guia") = dr.Item("fecha")
            dr_aux.Item("fecha_en_control") = dr.Item("FechaUModif")
            dr_aux.Item("piloto") = dr.Item("Analisis")
            dr_aux.Item("vehiculo") = dr.Item("TipoCta")
            dr_aux.Item("ayudante") = dr.Item("AnalisisE1")
            dr_aux.Item("chequeador") = dr.Item("AnalisisE2")
            dr_aux.Item("comentario") = dr.Item("comentario")
            Try
                dr_aux.Item("fecha_creditos") = dr.Item("fecha_recepcion_creditos")
                dr_aux.Item("recibio_creditos") = dr.Item("usuario_recepcion_creditos")

            Catch ex As Exception

            End Try

            ds.Tables( _
                    IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones") _
                    ).Rows.Add(dr_aux)
        Next

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor
            otrans.open()
            ls_sql = "pa_var_um_back_order '" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "','" & Me.cmbCoordinador.SelectedValue & "'"
            dt = otrans.Obtiene(ls_sql)

            Me.dgv_listadoProductos.DataSource = dt
            ClsGen.Alinear_GridViewEnteros = ",cantidad,cantidadasignada,cd_central,da_central,"

            ClsGen.Alinear_GridView(dt, Me.dgv_listadoProductos, "", ",correlativo,", "", "", ",cantidadasignada=facturado,cd_central=Existencia CD,da_central=Existencia DA,", "", ",producto,glosa,cantidad,cantidadasignada,cd_central,da_central,nombre_cliente,fecha,tipodocto,numero,fecha", True, True, 200, 0)

            

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
            Me.Cursor = Cursors.Default
            Me.TabControl1.SelectedTab = Me.TabPage1
        End Try
    End Sub




    Private Sub txt_total_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_pedido.TextChanged
        txt_total_pedido.Text = Format(Convert.ToDecimal(txt_total_pedido.Text), "###,###,##0.00").ToString
    End Sub


    Private Sub dg_productos_pedido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_top_pedidos.Click
        Cliente_Pedido_Producto()
    End Sub

    Private Sub btn_tracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tracking.Click
        Tracking_Pedido()
    End Sub

    Private Sub btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cliente.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.Text = "Busqueda de Clientes .::"
        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        'frm_busqueda.ps_parametros_fijos = "'" & Me.cmb_empresa.Text.Trim & "',"
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente, direccion, telefono, contacto, ListaPrecio "
        'frm_busqueda.procedimiento_almacenado = "pa_sel_um_cliente_busqueda"
        frm_busqueda.dg_buscar.ReadOnly = True
        frm_busqueda.cmb_valor1.Text = "ctacte"
        frm_busqueda.cmb_1.Text = "="
        frm_busqueda.txt_buscar1.Text = Me.txt_cod_cliente.Text
        frm_busqueda.hacer_busqueda_vista()
        frm_busqueda.Size = New System.Drawing.Size(812, 520)
        frm_busqueda.dg_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        frm_busqueda.GroupBox1.Visible = False
        frm_busqueda.ShowDialog()
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
    End Sub

    Private Sub generarAvisos(ByVal dtv As DataView)
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim liAviso As Integer


        Try
            dt = ClsGen.usuariosAviso(9)
            For Each dr As DataRow In dt.Rows
                liAviso = ClsGen.guardarAviso(dr.Item("usuario"), "Umbright",
                "Facturar Complemento del " & Me.txt_tipo_pedido.Text & " " & Me.txt_numero.Text & " del Cliente " &
                Me.txt_cod_cliente.Text & "-" & Me.txt_nombre_cliente.Text & " - " & gs_empresa,
                9)


                For Each drv As DataRowView In dtv
                    ClsGen.guardarAvisoDetalle(liAviso, drv.Item("producto").ToString & " " & drv.Item("glosa").ToString, "", gs_usuario, drv.Item("cantidad") - drv.Item("cantidadasignada"), 0, 0)
                    'sBody = sBody & drv.Item("producto").ToString & " " & drv.Item("glosa").ToString ' & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
                    'sBody = sBody & Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text & "<br>"
                    'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
                    'sBody = sBody & " <br>"

                Next

                'enviarCorreo(dr.Item("usuario"), Me.txt_tipo_pedido.Text & " " & Me.txt_numero.Text, sBody)
            Next



        Catch ex As Exception

        End Try

        Try

            Dim dtBU As DataTable = ClsGen.ValoresDistinto(dtv.ToTable, "bum".Split(","))

            For Each dr As DataRow In dtBU.Rows

                Dim sBody As String = "<br>"
                Dim sDetalle As String = ""
                For Each drv As DataRowView In dtv
                    If drv.Item("bum").ToString = dr.Item("bum").ToString Then
                        sBody = sBody & drv.Item("producto").ToString & " " & drv.Item("glosa").ToString ' & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
                        'sBody = sBody & Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text & "<br>"
                        'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
                        sBody = sBody & " <br>"

                        sDetalle = drv.Item("producto").ToString & " " & drv.Item("glosa").ToString & "|"

                    End If
                Next
                enviarCorreo(dr.Item("bum"), Me.txt_tipo_pedido.Text & " " & Me.txt_numero.Text, sBody, Me.txt_cod_cliente.Text & "-" & Me.txt_nombre_cliente.Text, sDetalle)

            Next



            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try



    End Sub


    Private Sub frm_backorder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub

    Private Sub dg_listado_productos_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs)

    End Sub

    Private Sub dgv_listadoProductos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listadoProductos.CellClick

    End Sub

    Private Sub dgv_listadoProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listadoProductos.CellContentClick

    End Sub

    Private Sub dgv_listadoProductos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_listadoProductos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_listadoProductos.Rows(rowIndex)
                If therow.Cells("Cantidadasignada").Value > 0 Then '< therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Chocolate
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_listadoProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listadoProductos.DoubleClick
        Try

            Dim li_rowNumber As Integer

            li_rowNumber = Me.dgv_listadoProductos.CurrentCell.RowIndex

            Detalle_Pedido(Me.dgv_listadoProductos.Item("TipoDocto", li_rowNumber).Value, _
                Me.dgv_listadoProductos.Item("correlativo", li_rowNumber).Value, _
                Me.dgv_listadoProductos.Item("numero", li_rowNumber).Value)

            Me.TabControl1.SelectedTab = Me.TabPage2

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_productos_pedido_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos_pedido.CellEnter
        Try
            If e.RowIndex > -1 Then
                If Me.dgv_productos_pedido.Item("existencia", e.RowIndex).Value < 1 Then
                    Me.dgv_productos_pedido.Item("cantidad", e.RowIndex).ReadOnly = True
                    Me.dgv_productos_pedido.Item("agregar", e.RowIndex).ReadOnly = True
                Else
                    Me.dgv_productos_pedido.Item("cantidad", e.RowIndex).ReadOnly = False
                    Me.dgv_productos_pedido.Item("agregar", e.RowIndex).ReadOnly = False
                End If
            End If

        Catch ex As Exception
            Me.dgv_productos_pedido.Item("cantidad", e.RowIndex).ReadOnly = True
            Me.dgv_productos_pedido.Item("agregar", e.RowIndex).ReadOnly = True
        Finally

        End Try
    End Sub


    Private Sub dgv_productos_pedido_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos_pedido.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_productos_pedido.Rows(rowIndex)

                If therow.Cells("Cantidadasignada").Value = 0 Then '< therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf therow.Cells("Cantidadasignada").Value <> therow.Cells("cantidad").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Chocolate
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If

            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub btn_quitar_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarCambios.Click

        Dim dt As DataTable
        dt = Me.dgv_productos_pedido.DataSource


        dt.DefaultView.RowFilter = "agregar = true"
        If dt.DefaultView.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Procesar Estos Productos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                generarAvisos(dt.DefaultView)
            End If
        End If
        dt.DefaultView.RowFilter = ""



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

End Class
