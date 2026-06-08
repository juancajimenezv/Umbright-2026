Public Class frm_tracking_pedidos
    Inherits System.Windows.Forms.Form
    Dim ds As New DataSet

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dg_top_pedidos As System.Windows.Forms.DataGrid
    Friend WithEvents dg_facturas As System.Windows.Forms.DataGrid
    Friend WithEvents dg_detalle_pedido As System.Windows.Forms.DataGrid
    Friend WithEvents btn_factura As System.Windows.Forms.Button
    Friend WithEvents txt_codcliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_ejecutivo As System.Windows.Forms.TextBox
    Friend WithEvents btn_tracking As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_lista_precios As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_grabo As System.Windows.Forms.TextBox
    Friend WithEvents txt_aprobacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents btn_detalle As System.Windows.Forms.Button
    Friend WithEvents dg_picking As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dg_top_facturas As System.Windows.Forms.DataGrid
    Friend WithEvents btn_pedidos As System.Windows.Forms.Button
    Friend WithEvents btn_facturas As System.Windows.Forms.Button
    Friend WithEvents txt_aprobacion_pedido As System.Windows.Forms.TextBox
    Friend WithEvents dg_control_transporte As System.Windows.Forms.DataGrid
    Friend WithEvents dgv_facturas As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDireccionEntrega As TextBox
    Friend WithEvents lbl_controles_asociados As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tracking_pedidos))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dg_top_pedidos = New System.Windows.Forms.DataGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dg_top_facturas = New System.Windows.Forms.DataGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dg_detalle_pedido = New System.Windows.Forms.DataGrid()
        Me.btn_factura = New System.Windows.Forms.Button()
        Me.dg_facturas = New System.Windows.Forms.DataGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lbl_controles_asociados = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dg_picking = New System.Windows.Forms.DataGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dg_control_transporte = New System.Windows.Forms.DataGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_facturas = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
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
        Me.txtDireccionEntrega = New System.Windows.Forms.TextBox()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGrid()
        Me.btn_pedidos = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.txt_codcliente = New System.Windows.Forms.TextBox()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_ejecutivo = New System.Windows.Forms.TextBox()
        Me.txt_tipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_tracking = New System.Windows.Forms.Button()
        Me.btn_detalle = New System.Windows.Forms.Button()
        Me.btn_facturas = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_top_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dg_top_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_detalle_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 96)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(928, 504)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.dg_top_pedidos)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(920, 474)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Top Pedidos"
        '
        'dg_top_pedidos
        '
        Me.dg_top_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_top_pedidos.CaptionVisible = False
        Me.dg_top_pedidos.DataMember = ""
        Me.dg_top_pedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_top_pedidos.Location = New System.Drawing.Point(8, 6)
        Me.dg_top_pedidos.Name = "dg_top_pedidos"
        Me.dg_top_pedidos.ReadOnly = True
        Me.dg_top_pedidos.Size = New System.Drawing.Size(904, 450)
        Me.dg_top_pedidos.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dg_top_facturas)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(920, 475)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Top Facturas"
        '
        'dg_top_facturas
        '
        Me.dg_top_facturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_top_facturas.CaptionVisible = False
        Me.dg_top_facturas.DataMember = ""
        Me.dg_top_facturas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_top_facturas.Location = New System.Drawing.Point(8, 6)
        Me.dg_top_facturas.Name = "dg_top_facturas"
        Me.dg_top_facturas.ReadOnly = True
        Me.dg_top_facturas.Size = New System.Drawing.Size(904, 450)
        Me.dg_top_facturas.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.dg_detalle_pedido)
        Me.TabPage2.Controls.Add(Me.btn_factura)
        Me.TabPage2.Controls.Add(Me.dg_facturas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(920, 475)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle Pedido & Factura"
        '
        'dg_detalle_pedido
        '
        Me.dg_detalle_pedido.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dg_detalle_pedido.CaptionText = "Detalle de Pedido"
        Me.dg_detalle_pedido.DataMember = ""
        Me.dg_detalle_pedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pedido.Location = New System.Drawing.Point(8, 6)
        Me.dg_detalle_pedido.Name = "dg_detalle_pedido"
        Me.dg_detalle_pedido.ReadOnly = True
        Me.dg_detalle_pedido.Size = New System.Drawing.Size(904, 224)
        Me.dg_detalle_pedido.TabIndex = 12
        '
        'btn_factura
        '
        Me.btn_factura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_factura.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_factura.ForeColor = System.Drawing.Color.OrangeRed
        Me.btn_factura.Location = New System.Drawing.Point(8, 235)
        Me.btn_factura.Name = "btn_factura"
        Me.btn_factura.Size = New System.Drawing.Size(104, 32)
        Me.btn_factura.TabIndex = 14
        Me.btn_factura.Text = "Datos Factura ..."
        '
        'dg_facturas
        '
        Me.dg_facturas.CaptionVisible = False
        Me.dg_facturas.DataMember = ""
        Me.dg_facturas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_facturas.Location = New System.Drawing.Point(8, 274)
        Me.dg_facturas.Name = "dg_facturas"
        Me.dg_facturas.ReadOnly = True
        Me.dg_facturas.Size = New System.Drawing.Size(904, 176)
        Me.dg_facturas.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.lbl_controles_asociados)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(920, 474)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tracking"
        '
        'lbl_controles_asociados
        '
        Me.lbl_controles_asociados.AutoSize = True
        Me.lbl_controles_asociados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_controles_asociados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl_controles_asociados.Location = New System.Drawing.Point(788, 381)
        Me.lbl_controles_asociados.Name = "lbl_controles_asociados"
        Me.lbl_controles_asociados.Size = New System.Drawing.Size(121, 16)
        Me.lbl_controles_asociados.TabIndex = 4
        Me.lbl_controles_asociados.Text = "Controles Asociados ..."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dg_picking)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 200)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(904, 96)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Picking"
        '
        'dg_picking
        '
        Me.dg_picking.CaptionVisible = False
        Me.dg_picking.DataMember = ""
        Me.dg_picking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_picking.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_picking.Location = New System.Drawing.Point(8, 12)
        Me.dg_picking.Name = "dg_picking"
        Me.dg_picking.ReadOnly = True
        Me.dg_picking.Size = New System.Drawing.Size(888, 77)
        Me.dg_picking.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dg_control_transporte)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 296)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(904, 85)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Control de Transporte"
        '
        'dg_control_transporte
        '
        Me.dg_control_transporte.CaptionVisible = False
        Me.dg_control_transporte.DataMember = ""
        Me.dg_control_transporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderFont = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_control_transporte.Location = New System.Drawing.Point(8, 12)
        Me.dg_control_transporte.Name = "dg_control_transporte"
        Me.dg_control_transporte.ReadOnly = True
        Me.dg_control_transporte.Size = New System.Drawing.Size(888, 68)
        Me.dg_control_transporte.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_facturas)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(904, 95)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Facturacion"
        '
        'dgv_facturas
        '
        Me.dgv_facturas.AllowUserToAddRows = False
        Me.dgv_facturas.AllowUserToDeleteRows = False
        Me.dgv_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_facturas.Location = New System.Drawing.Point(8, 14)
        Me.dgv_facturas.Name = "dgv_facturas"
        Me.dgv_facturas.RowHeadersVisible = False
        Me.dgv_facturas.Size = New System.Drawing.Size(888, 76)
        Me.dgv_facturas.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
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
        Me.GroupBox2.Controls.Add(Me.txtDireccionEntrega)
        Me.GroupBox2.Controls.Add(Me.txt_comentario)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 105)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pedido"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(538, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 38)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Dirección Entrega"
        '
        'txt_aprobacion_pedido
        '
        Me.txt_aprobacion_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion_pedido.Location = New System.Drawing.Point(806, 40)
        Me.txt_aprobacion_pedido.Name = "txt_aprobacion_pedido"
        Me.txt_aprobacion_pedido.ReadOnly = True
        Me.txt_aprobacion_pedido.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion_pedido.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(745, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Aprobacion"
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_pedido.Location = New System.Drawing.Point(448, 40)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(80, 20)
        Me.txt_total_pedido.TabIndex = 19
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(411, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Total Pedido"
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_porcentaje.Location = New System.Drawing.Point(624, 40)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.ReadOnly = True
        Me.txt_porcentaje.Size = New System.Drawing.Size(40, 20)
        Me.txt_porcentaje.TabIndex = 17
        '
        'txt_aprobacion
        '
        Me.txt_aprobacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion.Location = New System.Drawing.Point(806, 19)
        Me.txt_aprobacion.Name = "txt_aprobacion"
        Me.txt_aprobacion.ReadOnly = True
        Me.txt_aprobacion.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion.TabIndex = 16
        '
        'txt_fecha_grabo
        '
        Me.txt_fecha_grabo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_grabo.Location = New System.Drawing.Point(624, 19)
        Me.txt_fecha_grabo.Name = "txt_fecha_grabo"
        Me.txt_fecha_grabo.ReadOnly = True
        Me.txt_fecha_grabo.Size = New System.Drawing.Size(112, 20)
        Me.txt_fecha_grabo.TabIndex = 15
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(448, 19)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(80, 20)
        Me.txt_fecha.TabIndex = 14
        Me.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(296, 19)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.ReadOnly = True
        Me.txt_numero.Size = New System.Drawing.Size(112, 20)
        Me.txt_numero.TabIndex = 13
        '
        'txt_lista_precios
        '
        Me.txt_lista_precios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lista_precios.Location = New System.Drawing.Point(296, 40)
        Me.txt_lista_precios.Name = "txt_lista_precios"
        Me.txt_lista_precios.ReadOnly = True
        Me.txt_lista_precios.Size = New System.Drawing.Size(112, 20)
        Me.txt_lista_precios.TabIndex = 12
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vendedor.Location = New System.Drawing.Point(80, 40)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(128, 20)
        Me.txt_vendedor.TabIndex = 11
        '
        'txt_tipo_pedido
        '
        Me.txt_tipo_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_pedido.Location = New System.Drawing.Point(80, 19)
        Me.txt_tipo_pedido.Name = "txt_tipo_pedido"
        Me.txt_tipo_pedido.Size = New System.Drawing.Size(128, 20)
        Me.txt_tipo_pedido.TabIndex = 10
        '
        'txtDireccionEntrega
        '
        Me.txtDireccionEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccionEntrega.Location = New System.Drawing.Point(624, 61)
        Me.txtDireccionEntrega.Multiline = True
        Me.txtDireccionEntrega.Name = "txtDireccionEntrega"
        Me.txtDireccionEntrega.ReadOnly = True
        Me.txtDireccionEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccionEntrega.Size = New System.Drawing.Size(272, 40)
        Me.txtDireccionEntrega.TabIndex = 9
        '
        'txt_comentario
        '
        Me.txt_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentario.Location = New System.Drawing.Point(80, 61)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ReadOnly = True
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(448, 40)
        Me.txt_comentario.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(538, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 16)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "% Facturado"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 23)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Comentario"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(745, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Estado"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(214, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Lista de Precios"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Vendedor"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(536, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Fecha Generado"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(410, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(214, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "tipo de pedido"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 397)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(904, 72)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Devoluciones"
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.CaptionVisible = False
        Me.dg_devoluciones.DataMember = ""
        Me.dg_devoluciones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_devoluciones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_devoluciones.Location = New System.Drawing.Point(8, 12)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.ReadOnly = True
        Me.dg_devoluciones.Size = New System.Drawing.Size(888, 55)
        Me.dg_devoluciones.TabIndex = 1
        '
        'btn_pedidos
        '
        Me.btn_pedidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_pedidos.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pedidos.ForeColor = System.Drawing.Color.Blue
        Me.btn_pedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pedidos.ImageIndex = 1
        Me.btn_pedidos.ImageList = Me.ImageList1
        Me.btn_pedidos.Location = New System.Drawing.Point(824, 0)
        Me.btn_pedidos.Name = "btn_pedidos"
        Me.btn_pedidos.Size = New System.Drawing.Size(96, 24)
        Me.btn_pedidos.TabIndex = 8
        Me.btn_pedidos.Text = "Top Pedidos"
        Me.btn_pedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 0
        Me.btn_buscar.ImageList = Me.ImageList1
        Me.btn_buscar.Location = New System.Drawing.Point(184, 22)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 23)
        Me.btn_buscar.TabIndex = 10
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_codcliente
        '
        Me.txt_codcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codcliente.Location = New System.Drawing.Point(80, 24)
        Me.txt_codcliente.Name = "txt_codcliente"
        Me.txt_codcliente.Size = New System.Drawing.Size(100, 20)
        Me.txt_codcliente.TabIndex = 9
        '
        'txt_cliente
        '
        Me.txt_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cliente.Location = New System.Drawing.Point(80, 48)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(368, 21)
        Me.txt_cliente.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_ejecutivo)
        Me.GroupBox1.Controls.Add(Me.txt_tipo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_codcliente)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 80)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion de Cliente"
        '
        'txt_ejecutivo
        '
        Me.txt_ejecutivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ejecutivo.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ejecutivo.Location = New System.Drawing.Point(528, 48)
        Me.txt_ejecutivo.Name = "txt_ejecutivo"
        Me.txt_ejecutivo.ReadOnly = True
        Me.txt_ejecutivo.Size = New System.Drawing.Size(248, 21)
        Me.txt_ejecutivo.TabIndex = 16
        '
        'txt_tipo
        '
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo.Location = New System.Drawing.Point(528, 24)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(248, 21)
        Me.txt_tipo.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(456, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Ejecutivo"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(456, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Codigo"
        '
        'btn_tracking
        '
        Me.btn_tracking.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_tracking.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tracking.ForeColor = System.Drawing.Color.Blue
        Me.btn_tracking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_tracking.ImageIndex = 3
        Me.btn_tracking.ImageList = Me.ImageList1
        Me.btn_tracking.Location = New System.Drawing.Point(824, 72)
        Me.btn_tracking.Name = "btn_tracking"
        Me.btn_tracking.Size = New System.Drawing.Size(96, 24)
        Me.btn_tracking.TabIndex = 13
        Me.btn_tracking.Text = "Tracking"
        Me.btn_tracking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_detalle
        '
        Me.btn_detalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_detalle.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_detalle.ForeColor = System.Drawing.Color.Blue
        Me.btn_detalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_detalle.ImageIndex = 2
        Me.btn_detalle.ImageList = Me.ImageList1
        Me.btn_detalle.Location = New System.Drawing.Point(824, 48)
        Me.btn_detalle.Name = "btn_detalle"
        Me.btn_detalle.Size = New System.Drawing.Size(96, 24)
        Me.btn_detalle.TabIndex = 14
        Me.btn_detalle.Text = "Detalle"
        Me.btn_detalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_facturas
        '
        Me.btn_facturas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_facturas.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturas.ForeColor = System.Drawing.Color.Blue
        Me.btn_facturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_facturas.ImageIndex = 4
        Me.btn_facturas.ImageList = Me.ImageList1
        Me.btn_facturas.Location = New System.Drawing.Point(824, 24)
        Me.btn_facturas.Name = "btn_facturas"
        Me.btn_facturas.Size = New System.Drawing.Size(96, 24)
        Me.btn_facturas.TabIndex = 15
        Me.btn_facturas.Text = "Top Facturas"
        Me.btn_facturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_tracking_pedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(928, 597)
        Me.Controls.Add(Me.btn_facturas)
        Me.Controls.Add(Me.btn_detalle)
        Me.Controls.Add(Me.btn_tracking)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_pedidos)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_tracking_pedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::.. Tracking de Pedidos ..::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dg_top_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dg_top_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_detalle_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function 'ProcessCmdKey 

    Private Sub Buscar_Cliente()

        Dim dt As New DataTable
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim ls_sql As String

        If Me.txt_codcliente.Text.Length > 0 Then
            Try
                oTrans.open()
                ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txt_codcliente.Text.Trim & "'"
                dt = oTrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.txt_cliente.Text = dt.Rows(0).Item("RazonSocial") & "/" & dt.Rows(0).Item("giro")
                    Me.txt_ejecutivo.Text = dt.Rows(0).Item("ejecutivo")
                    Me.txt_tipo.Text = dt.Rows(0).Item("tipo")
                End If
            Catch ex As Exception
            Finally
                oTrans.close()
                oTrans = Nothing
                Limpiar_pantalla(2)
            End Try

        End If
    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value As Integer
            Dim value2 As Integer

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = data("cantidad")
            value2 = data("cantidadasignada")

            If value2 = 0 Then
                e.RowColor = Color.Red
            ElseIf value2 <> value Then
                e.RowColor = Color.Chocolate
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub Colorear_Grid(ByVal pdt As DataTable)
        Dim clsGen As New ClasesGenerales.General

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = pdt.TableName
        Dim nombre_tipo As String

        For Each col As DataColumn In pdt.Columns

            Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
            gridCol.MappingName = col.ColumnName

            Try
                nombre_tipo = col.DataType.ToString
            Catch ex As Exception
                nombre_tipo = ""
            End Try

            gridCol.Width = clsGen.tamaño_maximo_campo(pdt, " ", col.ColumnName, Me.dg_detalle_pedido, 300, 0)

            If nombre_tipo = "System.Decimal" Then
                gridCol.Format = "n"
                gridCol.Alignment = HorizontalAlignment.Right
            End If
            If nombre_tipo = "System.DateTime" Then
                gridCol.Width = 95
            End If


            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
            gridCol.NullText = ""
            AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
            tableStyle.GridColumnStyles.Add(gridCol)
        Next

        tableStyle.RowHeaderWidth = 5
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray

        Me.dg_detalle_pedido.TableStyles.Clear()
        Me.dg_detalle_pedido.TableStyles.Add(tableStyle)
    End Sub

    Private Sub Detalle_Pedido(ByVal ptipo_documento As String, ByVal pcorrelativo As String)
        Dim clgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim li_RowNumber As Integer = Me.dg_top_pedidos.CurrentCell.RowNumber

        ls_sql = "pa_var_um_documento_detalle_tracking  '" & gs_empresa & "','" &
                    ptipo_documento & "'," & pcorrelativo

        Try

            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            Me.dg_detalle_pedido.DataSource = dt

            Colorear_Grid(dt)

            Me.dg_detalle_pedido.CaptionText = "Detalle Pedido " & Me.dg_top_pedidos.Item(li_RowNumber, 2).ToString
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clgen = Nothing
            Limpiar_pantalla(0)

        End Try

    End Sub

    Private Sub Buscar_Pedidos(ByVal pnumero As String)
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        ls_sql = "pa_sel_um_documento_cliente '" & gs_empresa & "', '%PEDIDO%','" & Me.txt_codcliente.Text & "'"

        If pnumero.Trim.Length > 0 Then
            ls_sql = ls_sql & ",'" & pnumero & "'"
        End If
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            Me.dg_top_pedidos.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_top_pedidos, dt.TableName, -1, 350, 0, True, True, "", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub Buscar_Facturas()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        ls_sql = "pa_sel_um_documento_cliente '" & gs_empresa & "', '%FAC%','" & Me.txt_codcliente.Text & "'"

        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            Me.dg_top_facturas.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_top_facturas, dt.TableName, -1, 350, 0, True, True, "", True, "")
            Me.TabControl1.SelectedTab = Me.TabPage4
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub Buscar_Factura_Relacionada()
        Dim li_row_number As Integer
        Dim ls_sql As String
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")

        li_row_number = Me.dg_top_pedidos.CurrentCell.RowNumber

        ls_sql = "pa_var_um_documento_relacion_detalle_tracking  '" & gs_empresa & "','" &
                    Me.dg_top_pedidos.Item(li_row_number, 1).ToString & "'," &
                    Me.dg_top_pedidos.Item(li_row_number, 0).ToString()

        Try
            ls_sql = "pa_var_um_documento_relacion_detalle_tracking  '" & gs_empresa & "','" &
                   Me.dg_top_pedidos.Item(li_row_number, 1).ToString & "'," &
                   Me.dg_top_pedidos.Item(li_row_number, 0).ToString()

            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            Me.dg_facturas.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_facturas, dt.TableName, -1, 200, 0, False, True, "", True, "")


        Catch ex As Exception



        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub Tracking_pedido()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim dt_aux As New DataTable
        Dim dt2 As New DataTable
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim lirownumber As Integer
        Dim clsgen As New ClasesGenerales.General
        Dim cl As DataGridTextBoxColumn
        Dim dr As DataRow
        Dim guia_anterior As String = ""

        Try
            Crear_Esquema()
            Me.TabControl1.SelectedTab = Me.TabPage3
            lirownumber = Me.dg_top_pedidos.CurrentCell.RowNumber

            otrans.open()

            'Informacion del pedido
            ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)
            Me.txt_comentario.Text = dt.Rows(0).Item("comentario1")
            Me.txt_vendedor.Text = dt.Rows(0).Item("vendedor")
            Me.txt_fecha.Text = dt.Rows(0).Item("fecha")
            '(c)
            'Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fechaumodif")
            Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fecha_insertado")



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
            Me.txtDireccionEntrega.Text = dt.Rows(0).Item("direccion").ToString


            'Picking
            ls_sql = "pa_var_um_impresion_picking '" & gs_empresa & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dg_picking.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_picking, dt.TableName, -1, 250, -1, False, True, ",tipo_documento,numero,fecha_impresion,nombre_picker,ac_ubicacion,", True, "")

            cl = Me.dg_picking.TableStyles(0).GridColumnStyles(2)
            cl.HeaderText = "Fecha Picking"


            ' facturas
            ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" &
                    Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dgv_facturas.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_facturas, ",tipodocto,numero,fechaumodif,bodega,total,analisise28,", "", "", "", ",fechaumodif=fecha facturado,analisise28=area despacho,direccion=direccion entrega,", ",fechaumodif=100,direccion=300,", "", True, True, 250, 100)



            'clsgen.Alinea_Grid(dt, Me.dg_factura_generada, dt.TableName, -1, 250, 0, False, True, ",TipoDocto,Numero,FechaUModif,Bodega,Total", True, "")

            Try
                '       cl = Me.dg_factura_generada.TableStyles(0).GridColumnStyles(5)
                'cl.HeaderText = "Fecha Facturado"
            Catch ex As Exception
            End Try

            dt.TableName = "facturas_generadas"
            If ds.Tables.IndexOf("facturas_generadas") > 0 Then
                ds.Tables.Remove("facturas_generadas")
            End If
            ds.Tables.Add(dt.Copy)
            '

            'Guia de Transporte
            For Each dr In dt.Rows

                ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" &
                            dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"

                ls_sql2 = "pa_var_um_documento_control_transporte '" & gs_empresa & "','" &
                            dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)

                If dt_aux.Rows.Count > 0 Then
                    If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                        Agregar_Esquema(dt_aux, IIf(dt_aux.Rows(0).Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones"))

                        'dt2.ImportRow(dt_aux.Rows(0))
                        If dt2.Rows.Count > 0 Then
                            Me.dg_control_transporte.DataSource = dt2
                        End If
                        guia_anterior = dt_aux.Rows(0).Item("numero")
                    End If

                Else
                    'Tengo que Buscar en la Guia Temporal
                    dt_aux = otrans.Obtiene(ls_sql2)

                    If dt_aux.Rows.Count > 0 Then

                        ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" &
                                "CONTROL DE TRANSPORTE','" &
                                dt_aux.Rows(0).Item("numero_temporal") & "'"
                        dt_aux = otrans.Obtiene(ls_sql)

                        If dt_aux.Rows.Count > 0 Then
                            If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                                Agregar_Esquema(dt_aux, "control_transporte")
                            End If
                            guia_anterior = dt_aux.Rows(0).Item("numero")
                        End If
                    End If
                End If

            Next


            Me.dg_control_transporte.DataSource = ds.Tables("control_transporte")
            clsgen.Alinea_Grid(ds.Tables("control_transporte"), Me.dg_control_transporte, ds.Tables("control_transporte").TableName,
                                        -1, 190, 0, False, True, "", True, "")

            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(8)
            cl.HeaderText = "Com Liquidador"
            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(0)
            cl.Width = 50

            Me.dg_devoluciones.DataSource = ds.Tables("devoluciones")

            If ds.Tables("devoluciones").Rows.Count > 0 Then
                ls_sql = "pa_sel_um_documentod '" & gs_empresa & "','" &
                        ds.Tables("devoluciones").Rows(0).Item("tipo") & "','" &
                        ds.Tables("devoluciones").Rows(0).Item("numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)
                If dt_aux.Rows.Count > 0 Then
                    ds.Tables("devoluciones").Rows(0).Item("comentario") = dt_aux.Rows(0).Item("descripcion_motivo")
                End If
                ds.Tables("devoluciones").Rows(0).Item("piloto") = ""
                ds.Tables("devoluciones").Rows(0).Item("vehiculo") = ""
            End If

            clsgen.Alinea_Grid(ds.Tables("devoluciones"), Me.dg_devoluciones, ds.Tables("devoluciones").TableName,
                            -1, 200, 10, False, True, "tipo,numero,fecha_guia,fecha_en_control,comentario", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try

    End Sub

    Private Sub Agregar_Esquema(ByVal dt As DataTable, ByVal nombre_esquema As String)
        Dim dr As DataRow
        Dim dr_aux As DataRow


        For Each dr In dt.Rows

            dr_aux = ds.Tables(
                            IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones")
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

            ds.Tables(
                    IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones")
                    ).Rows.Add(dr_aux)
        Next

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

    Private Sub Limpiar_pantalla(ByVal pnivel As Short)

        Me.txt_comentario.Text = ""
        Me.txt_vendedor.Text = ""
        Me.txt_fecha.Text = ""
        Me.txt_fecha_grabo.Text = ""
        Me.txt_lista_precios.Text = ""
        Me.txt_tipo_pedido.Text = ""
        Me.txt_aprobacion.Text = ""
        Me.txt_porcentaje.Text = ""
        Me.txt_numero.Text = ""
        Me.txt_total_pedido.Text = 0
        Me.txt_aprobacion_pedido.Text = ""
        Me.txtDireccionEntrega.Text = String.Empty

        Me.dgv_facturas.DataSource = Nothing
        Me.dg_facturas.DataSource = Nothing
        Me.dg_control_transporte.DataSource = Nothing
        Me.dg_picking.DataSource = Nothing

        Me.dg_devoluciones.DataSource = Nothing
        ds = New DataSet

        If pnivel > 0 Then
            Me.dg_detalle_pedido.DataSource = Nothing
        End If
        If pnivel > 1 Then
            Me.dg_top_pedidos.DataSource = Nothing
            Me.dg_top_facturas.DataSource = Nothing
        End If

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo "
        frm_busqueda.ShowDialog()

        Me.txt_codcliente.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        Buscar_Cliente()
    End Sub

    Private Sub btn_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pedidos.Click
        If Me.txt_codcliente.Text.Length > 0 Then
            Buscar_Pedidos("")
            Me.TabControl1.SelectedTab = Me.TabPage1
        End If
    End Sub

    Private Sub txt_codCliente_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codcliente.LostFocus
        If Me.txt_codcliente.Text.Length > 0 Then
            Buscar_Cliente()
        End If
    End Sub

    Private Sub dg_top_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_top_pedidos.DoubleClick
        Try
            Dim li_rowNumber As Integer
            li_rowNumber = Me.dg_top_pedidos.CurrentCell.RowNumber

            Detalle_Pedido(Me.dg_top_pedidos.Item(li_rowNumber, 1).ToString, Me.dg_top_pedidos.Item(li_rowNumber, 0).ToString)
            Me.TabControl1.SelectedTab = Me.TabPage2

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_factura.Click
        Try
            Buscar_Factura_Relacionada()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_tracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tracking.Click
        Tracking_pedido()
    End Sub

    Private Sub btn_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalle.Click
        Try
            Dim li_rownumber As Integer
            li_rownumber = Me.dg_top_pedidos.CurrentCell.RowNumber
            Detalle_Pedido(Me.dg_top_pedidos.Item(li_rownumber, 1).ToString, Me.dg_top_pedidos.Item(li_rownumber, 0).ToString)
            Me.TabControl1.SelectedTab = Me.TabPage2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_total_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_pedido.TextChanged
        txt_total_pedido.Text = Format(Convert.ToDecimal(txt_total_pedido.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub btn_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturas.Click
        If Me.txt_codcliente.Text.Length > 0 Then
            Buscar_Facturas()
        End If
    End Sub

    Private Sub dg_top_facturas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_top_facturas.DoubleClick
        Dim ls_sql As String
        Dim li_rownumber As Integer
        li_rownumber = Me.dg_top_facturas.CurrentCell.RowNumber
        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        ls_sql = "pa_sel_um_documentod '" & gs_empresa & "','" &
                   Me.dg_top_facturas.Item(li_rownumber, 1).ToString & "','" &
                    Me.dg_top_facturas.Item(li_rownumber, 2).ToString & "'"

        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                Buscar_Pedidos(dt.Rows(0).Item("numero_origen"))
                Detalle_Pedido(dt.Rows(0).Item("TipoDoctoOrigen"), dt.Rows(0).Item("CorrelativoOrigen"))
                Buscar_Factura_Relacionada()
                Me.TabControl1.SelectedTab = Me.TabPage2
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub dg_devoluciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_devoluciones.DoubleClick
        Dim li_rownumber As Integer
        li_rownumber = Me.dg_devoluciones.CurrentCell.RowNumber

        If li_rownumber > -1 Then
            Dim otrans As New Transaccional.Conexion("flexline")
            Dim clsgen As New ClasesGenerales.General
            Dim dt As New DataTable
            Dim ls_sql As String
            Try
                otrans.open()

                ls_sql = "pa_sel_um_documentod '" & gs_empresa & "','" &
                        Me.dg_devoluciones.Item(li_rownumber, 0).ToString & "','" &
                        Me.dg_devoluciones.Item(li_rownumber, 1).ToString & "'"

                dt = otrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    otrans.close()
                    Dim oform As New frm_resultado
                    oform.dgv_resultado.DataSource = dt
                    'clsgen.Alinea_Grid(dt, oform.DataGrid1, dt.TableName, -1, 250, 0, False, True, _
                    '               "Producto,Cantidad,glosa,descripcion_motivo", True, "")
                    clsgen.Alinear_GridView(dt, oform.dgv_resultado, "Producto,Cantidad,glosa,descripcion_motivo", "", "", "", "", "", "", True, True, 250, 0)
                    oform.Text = Me.dg_devoluciones.Item(li_rownumber, 0).ToString & " .:. " &
                                 Me.dg_devoluciones.Item(li_rownumber, 1).ToString
                    oform.ShowDialog(Me)
                    oform.Dispose()
                    oform = Nothing

                End If

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing

            End Try

        End If
    End Sub


    Private Sub lbl_controles_asociados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_controles_asociados.Click

        Dim dt As DataTable
        Dim dr, dr_aux, dr2 As DataRow
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Try
            ds.Tables("controles_asociados").Rows.Clear()
            otrans.open()

            For Each dr In ds.Tables("facturas_generadas").Rows
                ls_sql = "pa_sel_um_gen_log_guia_liquidador '" & gs_empresa & "','" &
                        dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"
                dt = otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    For Each dr_aux In dt.Rows

                        dr2 = ds.Tables("controles_asociados").NewRow()
                        dr2.Item("tipo") = dr_aux.Item("TipoDocto_Origen")
                        dr2.Item("numero") = dr_aux.Item("numero_origen")
                        dr2.Item("fecha_guia") = dr_aux.Item("fecha_control")
                        dr2.Item("piloto") = dr_aux.Item("usuario")
                        dr2.Item("vehiculo") = dr_aux.Item("tipoDocto")
                        dr2.Item("ayudante") = dr_aux.Item("numero")
                        dr2.Item("comentario") = dr_aux.Item("Observaciones")

                        ds.Tables("controles_asociados").Rows.Add(dr2)
                    Next
                End If
            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds.Tables("controles_asociados").Rows.Count > 0 Then
            Dim oform As New frm_resultado
            Dim clsgen As New ClasesGenerales.General
            Dim cl As DataGridViewColumn

            oform.dgv_resultado.DataSource = ds.Tables("controles_asociados")
            '            clsgen.Alinea_Grid(ds.Tables("controles_asociados"), oform.DataGrid1, ds.Tables("controles_asociados").TableName, _
            '                                        -1, 200, 0, False, True, ",tipo, numero, fecha_guia, vehiculo, ayudante, comentario", True, "")

            clsgen.Alinear_GridView(ds.Tables("controles_asociados"), oform.dgv_resultado, ",tipo,numero,fecha_guia,vehiculo,ayudante,comentario", "", "", "", "", "", "", True, True, 200, 0)

            cl = oform.dgv_resultado.Columns(0)
            cl.HeaderText = "Control"
            cl = oform.dgv_resultado.Columns(1)
            cl.HeaderText = "Numero"
            cl = oform.dgv_resultado.Columns(2)
            cl.HeaderText = "Fecha Control"
            cl = oform.dgv_resultado.Columns(3)
            cl.HeaderText = "TipoDocto"
            cl = oform.dgv_resultado.Columns(4)
            cl.HeaderText = "NumeroDocto"
            cl = oform.dgv_resultado.Columns(5)
            cl.HeaderText = "Motivo"
            oform.Text = "Controles Asociados"

            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
        Else
            MessageBox.Show("No Hay Movimientos en Control Historico", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub dg_top_facturas_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_top_facturas.Navigate

    End Sub

    Private Sub dg_devoluciones_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_devoluciones.Navigate

    End Sub

    Private Sub frm_tracking_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_codcliente_TextChanged(sender As Object, e As EventArgs) Handles txt_codcliente.TextChanged

    End Sub
End Class
