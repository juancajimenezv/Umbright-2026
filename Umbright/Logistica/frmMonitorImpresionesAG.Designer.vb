<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorImpresionesAG
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorImpresionesAG))
        Me.dgv_pedidosFACE = New System.Windows.Forms.DataGridView()
        Me.dtp_fel_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fel_final = New System.Windows.Forms.DateTimePicker()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias = New System.Windows.Forms.NumericUpDown()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnObtenerNC = New System.Windows.Forms.Button()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lb_Pendiente = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.lb_Total = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_e_comentario = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_e_monto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btn_e_guardar = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_e_nuevo = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbContado = New System.Windows.Forms.GroupBox()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_FormasPago = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_e_montoCobro = New System.Windows.Forms.TextBox()
        Me.txt_e_cheque = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmb_e_banco = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_e_recibo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbCredito = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_e_razonSocial = New System.Windows.Forms.TextBox()
        Me.txt_e_numero = New System.Windows.Forms.TextBox()
        Me.cmb_e_empresa = New System.Windows.Forms.ComboBox()
        Me.cmb_e_tipodocto = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmb_e_empresa2 = New System.Windows.Forms.ComboBox()
        Me.btnCrediticiasReporte = New System.Windows.Forms.Button()
        Me.dgv_creditos = New System.Windows.Forms.DataGridView()
        Me.dtp_creditos_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_creditos_final = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_creditos_obtener = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mProcesosLiberar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbContado.SuspendLayout()
        Me.gbCredito.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_creditos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_pedidosFACE
        '
        Me.dgv_pedidosFACE.AllowUserToAddRows = False
        Me.dgv_pedidosFACE.AllowUserToDeleteRows = False
        Me.dgv_pedidosFACE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidosFACE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_pedidosFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidosFACE.Location = New System.Drawing.Point(6, 96)
        Me.dgv_pedidosFACE.Name = "dgv_pedidosFACE"
        Me.dgv_pedidosFACE.Size = New System.Drawing.Size(1189, 464)
        Me.dgv_pedidosFACE.TabIndex = 0
        '
        'dtp_fel_inicio
        '
        Me.dtp_fel_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_inicio.Location = New System.Drawing.Point(119, 27)
        Me.dtp_fel_inicio.Name = "dtp_fel_inicio"
        Me.dtp_fel_inicio.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_inicio.TabIndex = 1
        '
        'dtp_fel_final
        '
        Me.dtp_fel_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_final.Location = New System.Drawing.Point(119, 53)
        Me.dtp_fel_final.Name = "dtp_fel_final"
        Me.dtp_fel_final.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_final.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Text-Edit-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Smart-FTP-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        Me.ImageList1.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(4, "printer_48.png")
        Me.ImageList1.Images.SetKeyName(5, "cut_from_page.ico")
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.ImageList = Me.ImageList1
        Me.Button6.Location = New System.Drawing.Point(840, 16)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 74)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Impresión Recibos Bajo Demanda"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Fecha Final"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(429, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias
        '
        Me.nupCopias.Location = New System.Drawing.Point(543, 32)
        Me.nupCopias.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias.Name = "nupCopias"
        Me.nupCopias.Size = New System.Drawing.Size(37, 20)
        Me.nupCopias.TabIndex = 4
        Me.nupCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1210, 600)
        Me.TabControl1.TabIndex = 77
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btnObtenerNC)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.dgv_pedidosFACE)
        Me.TabPage1.Controls.Add(Me.nupCopias)
        Me.TabPage1.Controls.Add(Me.dtp_fel_inicio)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtp_fel_final)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnReimpresionNC)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1202, 574)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Impresiones"
        '
        'btnObtenerNC
        '
        Me.btnObtenerNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtenerNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnObtenerNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnObtenerNC.ForeColor = System.Drawing.Color.White
        Me.btnObtenerNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtenerNC.ImageIndex = 2
        Me.btnObtenerNC.ImageList = Me.ImageList1
        Me.btnObtenerNC.Location = New System.Drawing.Point(234, 16)
        Me.btnObtenerNC.Name = "btnObtenerNC"
        Me.btnObtenerNC.Size = New System.Drawing.Size(96, 74)
        Me.btnObtenerNC.TabIndex = 3
        Me.btnObtenerNC.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btnObtenerNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtenerNC.UseVisualStyleBackColor = False
        '
        'btnReimpresionNC
        '
        Me.btnReimpresionNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionNC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimpresionNC.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionNC.ImageIndex = 4
        Me.btnReimpresionNC.ImageList = Me.ImageList1
        Me.btnReimpresionNC.Location = New System.Drawing.Point(629, 16)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 74)
        Me.btnReimpresionNC.TabIndex = 5
        Me.btnReimpresionNC.Text = "Impresión FEL"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.lb_Pendiente)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.dtp_Fecha)
        Me.TabPage3.Controls.Add(Me.lb_Total)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txt_e_comentario)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txt_e_monto)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.TextBox5)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.TextBox4)
        Me.TabPage3.Controls.Add(Me.btn_e_guardar)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.btn_e_nuevo)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.gbContado)
        Me.TabPage3.Controls.Add(Me.gbCredito)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.txt_e_razonSocial)
        Me.TabPage3.Controls.Add(Me.txt_e_numero)
        Me.TabPage3.Controls.Add(Me.cmb_e_empresa)
        Me.TabPage3.Controls.Add(Me.cmb_e_tipodocto)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1202, 574)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Entregas"
        '
        'lb_Pendiente
        '
        Me.lb_Pendiente.AutoSize = True
        Me.lb_Pendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Pendiente.Location = New System.Drawing.Point(688, 481)
        Me.lb_Pendiente.Name = "lb_Pendiente"
        Me.lb_Pendiente.Size = New System.Drawing.Size(35, 15)
        Me.lb_Pendiente.TabIndex = 109
        Me.lb_Pendiente.Text = "0.00"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(536, 481)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 15)
        Me.Label27.TabIndex = 108
        Me.Label27.Text = "PENDIENTE:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(636, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 113)
        Me.GroupBox2.TabIndex = 107
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Devoluciones"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(106, 70)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(40, 13)
        Me.Label26.TabIndex = 89
        Me.Label26.Text = "Monto:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(99, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 88
        Me.Label25.Text = "Numero:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(57, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 87
        Me.Label24.Text = "Tipo Documento:"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(150, 67)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(113, 20)
        Me.TextBox6.TabIndex = 2
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(150, 41)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(113, 20)
        Me.TextBox3.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(150, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(113, 20)
        Me.TextBox1.TabIndex = 0
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(135, 128)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(126, 20)
        Me.dtp_Fecha.TabIndex = 106
        '
        'lb_Total
        '
        Me.lb_Total.AutoSize = True
        Me.lb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Total.Location = New System.Drawing.Point(688, 457)
        Me.lb_Total.Name = "lb_Total"
        Me.lb_Total.Size = New System.Drawing.Size(35, 15)
        Me.lb_Total.TabIndex = 105
        Me.lb_Total.Text = "0.00"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(512, 455)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(114, 15)
        Me.Label22.TabIndex = 104
        Me.Label22.Text = "TOTAL COBROS:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox1.Location = New System.Drawing.Point(393, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 196)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AllowUserToAddRows = False
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 13)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.ReadOnly = True
        Me.dgv_Detalle.Size = New System.Drawing.Size(516, 174)
        Me.dgv_Detalle.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(20, 205)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Observaciones"
        '
        'txt_e_comentario
        '
        Me.txt_e_comentario.Location = New System.Drawing.Point(135, 202)
        Me.txt_e_comentario.Name = "txt_e_comentario"
        Me.txt_e_comentario.Size = New System.Drawing.Size(415, 20)
        Me.txt_e_comentario.TabIndex = 102
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Monto"
        '
        'txt_e_monto
        '
        Me.txt_e_monto.BackColor = System.Drawing.SystemColors.Window
        Me.txt_e_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_monto.Location = New System.Drawing.Point(135, 151)
        Me.txt_e_monto.Name = "txt_e_monto"
        Me.txt_e_monto.Size = New System.Drawing.Size(126, 20)
        Me.txt_e_monto.TabIndex = 100
        Me.txt_e_monto.Text = "0.00"
        Me.txt_e_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(354, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(276, 32)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Entrega de Facturas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "Cliente"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(228, 481)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(107, 20)
        Me.TextBox5.TabIndex = 14
        Me.TextBox5.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Fecha"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(228, 457)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(107, 20)
        Me.TextBox4.TabIndex = 13
        Me.TextBox4.Visible = False
        '
        'btn_e_guardar
        '
        Me.btn_e_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_e_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_e_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_e_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_e_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_e_guardar.ImageIndex = 4
        Me.btn_e_guardar.ImageList = Me.ImageList2
        Me.btn_e_guardar.Location = New System.Drawing.Point(866, 446)
        Me.btn_e_guardar.Name = "btn_e_guardar"
        Me.btn_e_guardar.Size = New System.Drawing.Size(96, 74)
        Me.btn_e_guardar.TabIndex = 17
        Me.btn_e_guardar.Text = "Grabar"
        Me.btn_e_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_e_guardar.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "7.png")
        Me.ImageList2.Images.SetKeyName(1, "3.png")
        Me.ImageList2.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList2.Images.SetKeyName(3, "print_48.png")
        Me.ImageList2.Images.SetKeyName(4, "Floppy-64.png")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(115, 484)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "Voucher"
        Me.Label12.Visible = False
        '
        'btn_e_nuevo
        '
        Me.btn_e_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_e_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_e_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_e_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_e_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_e_nuevo.ImageIndex = 1
        Me.btn_e_nuevo.ImageList = Me.ImageList2
        Me.btn_e_nuevo.Location = New System.Drawing.Point(741, 17)
        Me.btn_e_nuevo.Name = "btn_e_nuevo"
        Me.btn_e_nuevo.Size = New System.Drawing.Size(96, 74)
        Me.btn_e_nuevo.TabIndex = 89
        Me.btn_e_nuevo.Text = "Nuevo"
        Me.btn_e_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_e_nuevo.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(115, 460)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Boleta"
        Me.Label10.Visible = False
        '
        'gbContado
        '
        Me.gbContado.Controls.Add(Me.btn_Agregar)
        Me.gbContado.Controls.Add(Me.Label11)
        Me.gbContado.Controls.Add(Me.cb_FormasPago)
        Me.gbContado.Controls.Add(Me.Label21)
        Me.gbContado.Controls.Add(Me.txt_e_montoCobro)
        Me.gbContado.Controls.Add(Me.txt_e_cheque)
        Me.gbContado.Controls.Add(Me.Label20)
        Me.gbContado.Controls.Add(Me.cmb_e_banco)
        Me.gbContado.Controls.Add(Me.Label18)
        Me.gbContado.Controls.Add(Me.txt_e_recibo)
        Me.gbContado.Controls.Add(Me.Label9)
        Me.gbContado.Location = New System.Drawing.Point(23, 244)
        Me.gbContado.Name = "gbContado"
        Me.gbContado.Size = New System.Drawing.Size(346, 196)
        Me.gbContado.TabIndex = 87
        Me.gbContado.TabStop = False
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Agregar.Location = New System.Drawing.Point(251, 132)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Agregar.TabIndex = 103
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Tipo Cobro:"
        '
        'cb_FormasPago
        '
        Me.cb_FormasPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_FormasPago.FormattingEnabled = True
        Me.cb_FormasPago.Location = New System.Drawing.Point(124, 14)
        Me.cb_FormasPago.Name = "cb_FormasPago"
        Me.cb_FormasPago.Size = New System.Drawing.Size(167, 21)
        Me.cb_FormasPago.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 13)
        Me.Label21.TabIndex = 100
        Me.Label21.Text = "Monto Cobro"
        '
        'txt_e_montoCobro
        '
        Me.txt_e_montoCobro.BackColor = System.Drawing.SystemColors.Window
        Me.txt_e_montoCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_montoCobro.Location = New System.Drawing.Point(124, 41)
        Me.txt_e_montoCobro.Name = "txt_e_montoCobro"
        Me.txt_e_montoCobro.Size = New System.Drawing.Size(126, 20)
        Me.txt_e_montoCobro.TabIndex = 11
        Me.txt_e_montoCobro.Text = "0.00"
        Me.txt_e_montoCobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_e_cheque
        '
        Me.txt_e_cheque.Location = New System.Drawing.Point(124, 118)
        Me.txt_e_cheque.Name = "txt_e_cheque"
        Me.txt_e_cheque.Size = New System.Drawing.Size(107, 20)
        Me.txt_e_cheque.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 118)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Cheque"
        '
        'cmb_e_banco
        '
        Me.cmb_e_banco.FormattingEnabled = True
        Me.cmb_e_banco.Location = New System.Drawing.Point(124, 93)
        Me.cmb_e_banco.Name = "cmb_e_banco"
        Me.cmb_e_banco.Size = New System.Drawing.Size(202, 21)
        Me.cmb_e_banco.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 87
        Me.Label18.Text = "Banco"
        '
        'txt_e_recibo
        '
        Me.txt_e_recibo.Location = New System.Drawing.Point(124, 67)
        Me.txt_e_recibo.Name = "txt_e_recibo"
        Me.txt_e_recibo.Size = New System.Drawing.Size(107, 20)
        Me.txt_e_recibo.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Recibo/Contraseña"
        '
        'gbCredito
        '
        Me.gbCredito.Controls.Add(Me.TextBox2)
        Me.gbCredito.Controls.Add(Me.Label8)
        Me.gbCredito.Location = New System.Drawing.Point(488, 74)
        Me.gbCredito.Name = "gbCredito"
        Me.gbCredito.Size = New System.Drawing.Size(50, 93)
        Me.gbCredito.TabIndex = 87
        Me.gbCredito.TabStop = False
        Me.gbCredito.Text = "Credito"
        Me.gbCredito.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(120, 34)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(107, 20)
        Me.TextBox2.TabIndex = 84
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Contraseña / Factura"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Numero"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Empresa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Serie"
        '
        'txt_e_razonSocial
        '
        Me.txt_e_razonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_razonSocial.Location = New System.Drawing.Point(135, 176)
        Me.txt_e_razonSocial.Name = "txt_e_razonSocial"
        Me.txt_e_razonSocial.Size = New System.Drawing.Size(415, 20)
        Me.txt_e_razonSocial.TabIndex = 101
        '
        'txt_e_numero
        '
        Me.txt_e_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_numero.Location = New System.Drawing.Point(135, 105)
        Me.txt_e_numero.Name = "txt_e_numero"
        Me.txt_e_numero.Size = New System.Drawing.Size(126, 20)
        Me.txt_e_numero.TabIndex = 9
        '
        'cmb_e_empresa
        '
        Me.cmb_e_empresa.FormattingEnabled = True
        Me.cmb_e_empresa.Location = New System.Drawing.Point(135, 51)
        Me.cmb_e_empresa.Name = "cmb_e_empresa"
        Me.cmb_e_empresa.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_empresa.TabIndex = 7
        '
        'cmb_e_tipodocto
        '
        Me.cmb_e_tipodocto.FormattingEnabled = True
        Me.cmb_e_tipodocto.Location = New System.Drawing.Point(135, 78)
        Me.cmb_e_tipodocto.Name = "cmb_e_tipodocto"
        Me.cmb_e_tipodocto.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_tipodocto.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.cmb_e_empresa2)
        Me.TabPage2.Controls.Add(Me.btnCrediticiasReporte)
        Me.TabPage2.Controls.Add(Me.dgv_creditos)
        Me.TabPage2.Controls.Add(Me.dtp_creditos_inicio)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtp_creditos_final)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.btn_creditos_obtener)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1202, 574)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Informe"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(46, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 13)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "Empresa"
        '
        'cmb_e_empresa2
        '
        Me.cmb_e_empresa2.FormattingEnabled = True
        Me.cmb_e_empresa2.Location = New System.Drawing.Point(98, 20)
        Me.cmb_e_empresa2.Name = "cmb_e_empresa2"
        Me.cmb_e_empresa2.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_empresa2.TabIndex = 81
        '
        'btnCrediticiasReporte
        '
        Me.btnCrediticiasReporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnCrediticiasReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrediticiasReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrediticiasReporte.ForeColor = System.Drawing.Color.White
        Me.btnCrediticiasReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCrediticiasReporte.ImageIndex = 4
        Me.btnCrediticiasReporte.ImageList = Me.ImageList1
        Me.btnCrediticiasReporte.Location = New System.Drawing.Point(264, 6)
        Me.btnCrediticiasReporte.Name = "btnCrediticiasReporte"
        Me.btnCrediticiasReporte.Size = New System.Drawing.Size(91, 74)
        Me.btnCrediticiasReporte.TabIndex = 20
        Me.btnCrediticiasReporte.Text = "Imprimir Reporte"
        Me.btnCrediticiasReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCrediticiasReporte.UseVisualStyleBackColor = False
        '
        'dgv_creditos
        '
        Me.dgv_creditos.AllowUserToAddRows = False
        Me.dgv_creditos.AllowUserToDeleteRows = False
        Me.dgv_creditos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_creditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_creditos.Location = New System.Drawing.Point(3, 100)
        Me.dgv_creditos.Name = "dgv_creditos"
        Me.dgv_creditos.Size = New System.Drawing.Size(1181, 450)
        Me.dgv_creditos.TabIndex = 80
        '
        'dtp_creditos_inicio
        '
        Me.dtp_creditos_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_creditos_inicio.Location = New System.Drawing.Point(98, 45)
        Me.dtp_creditos_inicio.Name = "dtp_creditos_inicio"
        Me.dtp_creditos_inicio.Size = New System.Drawing.Size(89, 20)
        Me.dtp_creditos_inicio.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Fecha Final"
        '
        'dtp_creditos_final
        '
        Me.dtp_creditos_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_creditos_final.Location = New System.Drawing.Point(98, 69)
        Me.dtp_creditos_final.Name = "dtp_creditos_final"
        Me.dtp_creditos_final.Size = New System.Drawing.Size(89, 20)
        Me.dtp_creditos_final.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Fecha Inicio"
        '
        'btn_creditos_obtener
        '
        Me.btn_creditos_obtener.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_creditos_obtener.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_creditos_obtener.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_creditos_obtener.ForeColor = System.Drawing.Color.White
        Me.btn_creditos_obtener.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_creditos_obtener.ImageIndex = 2
        Me.btn_creditos_obtener.ImageList = Me.ImageList1
        Me.btn_creditos_obtener.Location = New System.Drawing.Point(630, 7)
        Me.btn_creditos_obtener.Name = "btn_creditos_obtener"
        Me.btn_creditos_obtener.Size = New System.Drawing.Size(96, 74)
        Me.btn_creditos_obtener.TabIndex = 77
        Me.btn_creditos_obtener.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_creditos_obtener.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_creditos_obtener.UseVisualStyleBackColor = False
        Me.btn_creditos_obtener.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1223, 24)
        Me.MenuStrip1.TabIndex = 78
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mProcesosLiberar})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'mProcesosLiberar
        '
        Me.mProcesosLiberar.Name = "mProcesosLiberar"
        Me.mProcesosLiberar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mProcesosLiberar.Size = New System.Drawing.Size(208, 22)
        Me.mProcesosLiberar.Text = "Liberar Salidas CD"
        '
        'frmMonitorImpresionesAG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1223, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMonitorImpresionesAG"
        Me.Text = "::. Impresiones AG .::"
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbContado.ResumeLayout(False)
        Me.gbContado.PerformLayout()
        Me.gbCredito.ResumeLayout(False)
        Me.gbCredito.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_creditos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_pedidosFACE As DataGridView
    Friend WithEvents dtp_fel_inicio As DateTimePicker
    Friend WithEvents dtp_fel_final As DateTimePicker
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnReimpresionNC As Button
    Friend WithEvents btnObtenerNC As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias As NumericUpDown
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgv_creditos As DataGridView
    Friend WithEvents btn_creditos_obtener As Button
    Friend WithEvents dtp_creditos_inicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_creditos_final As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCrediticiasReporte As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txt_e_numero As TextBox
    Friend WithEvents cmb_e_tipodocto As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_e_guardar As Button
    Friend WithEvents btn_e_nuevo As Button
    Friend WithEvents gbContado As GroupBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents txt_e_recibo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents gbCredito As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_e_comentario As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_e_monto As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_e_razonSocial As TextBox
    Friend WithEvents cmb_e_empresa As ComboBox
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents txt_e_cheque As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmb_e_banco As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cb_FormasPago As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txt_e_montoCobro As TextBox
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents lb_Total As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_Detalle As DataGridView
    Friend WithEvents dtp_Fecha As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cmb_e_empresa2 As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents lb_Pendiente As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mProcesosLiberar As ToolStripMenuItem
End Class
