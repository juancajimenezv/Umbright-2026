<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Electronicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Electronicos))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gb_FechaVcto = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_proveedor = New System.Windows.Forms.TextBox()
        Me.dtp_Fecha_Final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Fech_Inicial = New System.Windows.Forms.DateTimePicker()
        Me.b_Genera = New System.Windows.Forms.Button()
        Me.l_FechaFinal = New System.Windows.Forms.Label()
        Me.l_FechaInicial = New System.Windows.Forms.Label()
        Me.dgv_Seleccion = New System.Windows.Forms.DataGridView()
        Me.gp_seleccion = New System.Windows.Forms.GroupBox()
        Me.lb_Sumatoria = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_Busca_Proveedor = New System.Windows.Forms.TextBox()
        Me.Total = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.b_Informe = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.b_PagosBi = New System.Windows.Forms.Button()
        Me.tb_Lote = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_EliminaLote = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_Seleccionar = New System.Windows.Forms.DataGridView()
        Me.btnQuita = New System.Windows.Forms.Button()
        Me.btnAgrega = New System.Windows.Forms.Button()
        Me.gb_FechaVcto.SuspendLayout()
        CType(Me.dgv_Seleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp_seleccion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Seleccionar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_FechaVcto
        '
        Me.gb_FechaVcto.Controls.Add(Me.Label2)
        Me.gb_FechaVcto.Controls.Add(Me.txt_proveedor)
        Me.gb_FechaVcto.Controls.Add(Me.dtp_Fecha_Final)
        Me.gb_FechaVcto.Controls.Add(Me.dtp_Fech_Inicial)
        Me.gb_FechaVcto.Controls.Add(Me.b_Genera)
        Me.gb_FechaVcto.Controls.Add(Me.l_FechaFinal)
        Me.gb_FechaVcto.Controls.Add(Me.l_FechaInicial)
        Me.gb_FechaVcto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.gb_FechaVcto.Location = New System.Drawing.Point(24, 11)
        Me.gb_FechaVcto.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_FechaVcto.Name = "gb_FechaVcto"
        Me.gb_FechaVcto.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_FechaVcto.Size = New System.Drawing.Size(564, 113)
        Me.gb_FechaVcto.TabIndex = 2
        Me.gb_FechaVcto.TabStop = False
        Me.gb_FechaVcto.Text = "Vencimientos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(105, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Proveedor :"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.Location = New System.Drawing.Point(208, 78)
        Me.txt_proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.Size = New System.Drawing.Size(132, 22)
        Me.txt_proveedor.TabIndex = 7
        '
        'dtp_Fecha_Final
        '
        Me.dtp_Fecha_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha_Final.Location = New System.Drawing.Point(208, 50)
        Me.dtp_Fecha_Final.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Fecha_Final.Name = "dtp_Fecha_Final"
        Me.dtp_Fecha_Final.Size = New System.Drawing.Size(132, 22)
        Me.dtp_Fecha_Final.TabIndex = 6
        '
        'dtp_Fech_Inicial
        '
        Me.dtp_Fech_Inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fech_Inicial.Location = New System.Drawing.Point(208, 23)
        Me.dtp_Fech_Inicial.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Fech_Inicial.Name = "dtp_Fech_Inicial"
        Me.dtp_Fech_Inicial.Size = New System.Drawing.Size(132, 22)
        Me.dtp_Fech_Inicial.TabIndex = 5
        '
        'b_Genera
        '
        Me.b_Genera.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.b_Genera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_Genera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.b_Genera.Image = CType(resources.GetObject("b_Genera.Image"), System.Drawing.Image)
        Me.b_Genera.Location = New System.Drawing.Point(427, 23)
        Me.b_Genera.Margin = New System.Windows.Forms.Padding(4)
        Me.b_Genera.Name = "b_Genera"
        Me.b_Genera.Size = New System.Drawing.Size(100, 75)
        Me.b_Genera.TabIndex = 4
        Me.b_Genera.Text = "Generar"
        Me.b_Genera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.b_Genera.UseVisualStyleBackColor = False
        '
        'l_FechaFinal
        '
        Me.l_FechaFinal.AutoSize = True
        Me.l_FechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_FechaFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.l_FechaFinal.Location = New System.Drawing.Point(94, 55)
        Me.l_FechaFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_FechaFinal.Name = "l_FechaFinal"
        Me.l_FechaFinal.Size = New System.Drawing.Size(102, 17)
        Me.l_FechaFinal.TabIndex = 3
        Me.l_FechaFinal.Text = "Fecha Final :"
        '
        'l_FechaInicial
        '
        Me.l_FechaInicial.AutoSize = True
        Me.l_FechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_FechaInicial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.l_FechaInicial.Location = New System.Drawing.Point(85, 27)
        Me.l_FechaInicial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_FechaInicial.Name = "l_FechaInicial"
        Me.l_FechaInicial.Size = New System.Drawing.Size(109, 17)
        Me.l_FechaInicial.TabIndex = 2
        Me.l_FechaInicial.Text = "Fecha Inicial :"
        '
        'dgv_Seleccion
        '
        Me.dgv_Seleccion.AllowUserToAddRows = False
        Me.dgv_Seleccion.AllowUserToDeleteRows = False
        Me.dgv_Seleccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Seleccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Seleccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgv_Seleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Seleccion.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgv_Seleccion.Location = New System.Drawing.Point(11, 19)
        Me.dgv_Seleccion.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Seleccion.Name = "dgv_Seleccion"
        Me.dgv_Seleccion.RowHeadersWidth = 62
        Me.dgv_Seleccion.Size = New System.Drawing.Size(1618, 151)
        Me.dgv_Seleccion.TabIndex = 3
        '
        'gp_seleccion
        '
        Me.gp_seleccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gp_seleccion.Controls.Add(Me.dgv_Seleccion)
        Me.gp_seleccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.gp_seleccion.Location = New System.Drawing.Point(13, 516)
        Me.gp_seleccion.Margin = New System.Windows.Forms.Padding(4)
        Me.gp_seleccion.Name = "gp_seleccion"
        Me.gp_seleccion.Padding = New System.Windows.Forms.Padding(4)
        Me.gp_seleccion.Size = New System.Drawing.Size(1637, 178)
        Me.gp_seleccion.TabIndex = 4
        Me.gp_seleccion.TabStop = False
        Me.gp_seleccion.Text = "Selección"
        '
        'lb_Sumatoria
        '
        Me.lb_Sumatoria.AutoSize = True
        Me.lb_Sumatoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Sumatoria.Location = New System.Drawing.Point(1016, 131)
        Me.lb_Sumatoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Sumatoria.Name = "lb_Sumatoria"
        Me.lb_Sumatoria.Size = New System.Drawing.Size(44, 20)
        Me.lb_Sumatoria.TabIndex = 4
        Me.lb_Sumatoria.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(620, 131)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Busca Numero:"
        '
        'tb_Busca_Proveedor
        '
        Me.tb_Busca_Proveedor.Location = New System.Drawing.Point(732, 130)
        Me.tb_Busca_Proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_Busca_Proveedor.Name = "tb_Busca_Proveedor"
        Me.tb_Busca_Proveedor.Size = New System.Drawing.Size(202, 22)
        Me.tb_Busca_Proveedor.TabIndex = 6
        '
        'Total
        '
        Me.Total.AutoSize = True
        Me.Total.Location = New System.Drawing.Point(955, 133)
        Me.Total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(41, 16)
        Me.Total.TabIndex = 5
        Me.Total.Text = "Total:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.b_Informe)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.b_PagosBi)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(622, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(747, 106)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Procesa"
        '
        'b_Informe
        '
        Me.b_Informe.BackColor = System.Drawing.Color.White
        Me.b_Informe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_Informe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.b_Informe.ImageIndex = 5
        Me.b_Informe.ImageList = Me.ImageList1
        Me.b_Informe.Location = New System.Drawing.Point(584, 20)
        Me.b_Informe.Margin = New System.Windows.Forms.Padding(4)
        Me.b_Informe.Name = "b_Informe"
        Me.b_Informe.Size = New System.Drawing.Size(137, 76)
        Me.b_Informe.TabIndex = 8
        Me.b_Informe.Text = "Informe"
        Me.b_Informe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.b_Informe.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "4.gif")
        Me.ImageList1.Images.SetKeyName(1, "ach.jpg")
        Me.ImageList1.Images.SetKeyName(2, "lupa.gif")
        Me.ImageList1.Images.SetKeyName(3, "lupa_buscar.gif")
        Me.ImageList1.Images.SetKeyName(4, "fileprint.ico")
        Me.ImageList1.Images.SetKeyName(5, "Imprimir.png")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageIndex = 1
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(365, 20)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 76)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = False
        '
        'b_PagosBi
        '
        Me.b_PagosBi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_PagosBi.ImageIndex = 0
        Me.b_PagosBi.ImageList = Me.ImageList1
        Me.b_PagosBi.Location = New System.Drawing.Point(121, 20)
        Me.b_PagosBi.Margin = New System.Windows.Forms.Padding(4)
        Me.b_PagosBi.Name = "b_PagosBi"
        Me.b_PagosBi.Size = New System.Drawing.Size(137, 76)
        Me.b_PagosBi.TabIndex = 5
        Me.b_PagosBi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.b_PagosBi.UseVisualStyleBackColor = True
        '
        'tb_Lote
        '
        Me.tb_Lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Lote.ForeColor = System.Drawing.Color.DarkGray
        Me.tb_Lote.Location = New System.Drawing.Point(1377, 13)
        Me.tb_Lote.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_Lote.Name = "tb_Lote"
        Me.tb_Lote.Size = New System.Drawing.Size(136, 23)
        Me.tb_Lote.TabIndex = 6
        Me.tb_Lote.Text = "LOTE"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.StatusStrip1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 699)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1666, 30)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(200, 28)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(200, 28)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'btn_EliminaLote
        '
        Me.btn_EliminaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_EliminaLote.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_EliminaLote.Location = New System.Drawing.Point(1377, 45)
        Me.btn_EliminaLote.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_EliminaLote.Name = "btn_EliminaLote"
        Me.btn_EliminaLote.Size = New System.Drawing.Size(82, 25)
        Me.btn_EliminaLote.TabIndex = 9
        Me.btn_EliminaLote.Text = "Eliminar"
        Me.btn_EliminaLote.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dgv_Seleccionar)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 160)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1634, 348)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccionar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1232, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 16)
        Me.Label3.TabIndex = 4
        '
        'dgv_Seleccionar
        '
        Me.dgv_Seleccionar.AllowUserToAddRows = False
        Me.dgv_Seleccionar.AllowUserToDeleteRows = False
        Me.dgv_Seleccionar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Seleccionar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Seleccionar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgv_Seleccionar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Seleccionar.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgv_Seleccionar.Location = New System.Drawing.Point(8, 20)
        Me.dgv_Seleccionar.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Seleccionar.Name = "dgv_Seleccionar"
        Me.dgv_Seleccionar.RowHeadersWidth = 62
        Me.dgv_Seleccionar.Size = New System.Drawing.Size(1618, 320)
        Me.dgv_Seleccionar.TabIndex = 3
        '
        'btnQuita
        '
        'Me.btnQuita.Image = Global.Umbright.My.Resources.Resources.arrow_up21
        Me.btnQuita.Location = New System.Drawing.Point(1613, 45)
        Me.btnQuita.Name = "btnQuita"
        Me.btnQuita.Size = New System.Drawing.Size(43, 104)
        Me.btnQuita.TabIndex = 12
        Me.btnQuita.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        'Me.btnAgrega.Image = Global.Umbright.My.Resources.Resources.arrow_down21
        Me.btnAgrega.Location = New System.Drawing.Point(1564, 46)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(43, 104)
        Me.btnAgrega.TabIndex = 11
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'Frm_Pagos_Electronicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1666, 729)
        Me.Controls.Add(Me.lb_Sumatoria)
        Me.Controls.Add(Me.btnQuita)
        Me.Controls.Add(Me.btnAgrega)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_EliminaLote)
        Me.Controls.Add(Me.tb_Busca_Proveedor)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tb_Lote)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gp_seleccion)
        Me.Controls.Add(Me.gb_FechaVcto)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Frm_Pagos_Electronicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección Pagos Electronicos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gb_FechaVcto.ResumeLayout(False)
        Me.gb_FechaVcto.PerformLayout()
        CType(Me.dgv_Seleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp_seleccion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_Seleccionar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb_FechaVcto As System.Windows.Forms.GroupBox
    Friend WithEvents l_FechaFinal As System.Windows.Forms.Label
    Friend WithEvents l_FechaInicial As System.Windows.Forms.Label
    Friend WithEvents dgv_Seleccion As System.Windows.Forms.DataGridView
    Friend WithEvents gp_seleccion As System.Windows.Forms.GroupBox
    Friend WithEvents b_Genera As System.Windows.Forms.Button
    Friend WithEvents b_PagosBi As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_Fech_Inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Fecha_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents b_Informe As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Total As System.Windows.Forms.Label
    Friend WithEvents lb_Sumatoria As System.Windows.Forms.Label
    Friend WithEvents tb_Lote As System.Windows.Forms.TextBox
    Friend WithEvents tb_Busca_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_proveedor As TextBox
    Friend WithEvents btn_EliminaLote As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv_Seleccionar As DataGridView
    Friend WithEvents btnAgrega As Button
    Friend WithEvents btnQuita As Button
End Class
