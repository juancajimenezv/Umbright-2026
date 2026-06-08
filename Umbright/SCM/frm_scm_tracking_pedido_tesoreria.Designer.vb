<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_scm_tracking_pedido_tesoreria
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAsociarOC = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.dgvOrdenes = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMesPago = New System.Windows.Forms.TextBox()
        Me.dtpFechaPagoReal = New System.Windows.Forms.DateTimePicker()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.dtpFechaPagoInicial = New System.Windows.Forms.DateTimePicker()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.dtpFechaDespachoReal = New System.Windows.Forms.DateTimePicker()
        Me.txtRefenciaCopac = New System.Windows.Forms.TextBox()
        Me.dtpFechaDespachoInicial = New System.Windows.Forms.DateTimePicker()
        Me.txtBUMAprueba = New System.Windows.Forms.TextBox()
        Me.dtpFechaAprueba = New System.Windows.Forms.DateTimePicker()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.dtpFechaCOPAC = New System.Windows.Forms.DateTimePicker()
        Me.txtDiasCredito = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSocio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMontoMoneda = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMontoQ = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvOC = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(906, 518)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtpFechaFinal)
        Me.TabPage1.Controls.Add(Me.dtpFechaInicio)
        Me.TabPage1.Controls.Add(Me.btnBuscar)
        Me.TabPage1.Controls.Add(Me.btnAsociarOC)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.dgvOrdenes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(898, 492)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Del"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(102, 25)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(102, 0)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaInicio.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.White
        Me.btnBuscar.Location = New System.Drawing.Point(245, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(59, 45)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnAsociarOC
        '
        Me.btnAsociarOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAsociarOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsociarOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsociarOC.ForeColor = System.Drawing.Color.White
        Me.btnAsociarOC.Location = New System.Drawing.Point(708, 6)
        Me.btnAsociarOC.Name = "btnAsociarOC"
        Me.btnAsociarOC.Size = New System.Drawing.Size(75, 57)
        Me.btnAsociarOC.TabIndex = 3
        Me.btnAsociarOC.Text = "Tracking"
        Me.btnAsociarOC.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(102, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(233, 20)
        Me.TextBox1.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(8, 51)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'dgvOrdenes
        '
        Me.dgvOrdenes.AllowUserToAddRows = False
        Me.dgvOrdenes.AllowUserToDeleteRows = False
        Me.dgvOrdenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenes.Location = New System.Drawing.Point(8, 88)
        Me.dgvOrdenes.Name = "dgvOrdenes"
        Me.dgvOrdenes.RowHeadersWidth = 25
        Me.dgvOrdenes.Size = New System.Drawing.Size(882, 396)
        Me.dgvOrdenes.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgvFacturas)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.dgvOC)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(898, 492)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMesPago)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPagoReal)
        Me.GroupBox1.Controls.Add(Me.txtPedido)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPagoInicial)
        Me.GroupBox1.Controls.Add(Me.txtEmpresa)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDespachoReal)
        Me.GroupBox1.Controls.Add(Me.txtRefenciaCopac)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDespachoInicial)
        Me.GroupBox1.Controls.Add(Me.txtBUMAprueba)
        Me.GroupBox1.Controls.Add(Me.dtpFechaAprueba)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.dtpFechaCOPAC)
        Me.GroupBox1.Controls.Add(Me.txtDiasCredito)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtSocio)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtMoneda)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtMontoMoneda)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtMontoQ)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(879, 170)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'txtMesPago
        '
        Me.txtMesPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMesPago.Location = New System.Drawing.Point(479, 138)
        Me.txtMesPago.Name = "txtMesPago"
        Me.txtMesPago.Size = New System.Drawing.Size(100, 20)
        Me.txtMesPago.TabIndex = 2
        '
        'dtpFechaPagoReal
        '
        Me.dtpFechaPagoReal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPagoReal.Location = New System.Drawing.Point(777, 135)
        Me.dtpFechaPagoReal.Name = "dtpFechaPagoReal"
        Me.dtpFechaPagoReal.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaPagoReal.TabIndex = 4
        '
        'txtPedido
        '
        Me.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPedido.Location = New System.Drawing.Point(100, 11)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtPedido.TabIndex = 2
        '
        'dtpFechaPagoInicial
        '
        Me.dtpFechaPagoInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPagoInicial.Location = New System.Drawing.Point(479, 110)
        Me.dtpFechaPagoInicial.Name = "dtpFechaPagoInicial"
        Me.dtpFechaPagoInicial.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaPagoInicial.TabIndex = 4
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa.Location = New System.Drawing.Point(100, 37)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(100, 20)
        Me.txtEmpresa.TabIndex = 2
        '
        'dtpFechaDespachoReal
        '
        Me.dtpFechaDespachoReal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDespachoReal.Location = New System.Drawing.Point(777, 112)
        Me.dtpFechaDespachoReal.Name = "dtpFechaDespachoReal"
        Me.dtpFechaDespachoReal.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaDespachoReal.TabIndex = 4
        '
        'txtRefenciaCopac
        '
        Me.txtRefenciaCopac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefenciaCopac.Location = New System.Drawing.Point(100, 89)
        Me.txtRefenciaCopac.Name = "txtRefenciaCopac"
        Me.txtRefenciaCopac.Size = New System.Drawing.Size(225, 20)
        Me.txtRefenciaCopac.TabIndex = 2
        '
        'dtpFechaDespachoInicial
        '
        Me.dtpFechaDespachoInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDespachoInicial.Location = New System.Drawing.Point(479, 61)
        Me.dtpFechaDespachoInicial.Name = "dtpFechaDespachoInicial"
        Me.dtpFechaDespachoInicial.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaDespachoInicial.TabIndex = 4
        '
        'txtBUMAprueba
        '
        Me.txtBUMAprueba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBUMAprueba.Location = New System.Drawing.Point(100, 141)
        Me.txtBUMAprueba.Name = "txtBUMAprueba"
        Me.txtBUMAprueba.Size = New System.Drawing.Size(100, 20)
        Me.txtBUMAprueba.TabIndex = 2
        '
        'dtpFechaAprueba
        '
        Me.dtpFechaAprueba.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAprueba.Location = New System.Drawing.Point(100, 112)
        Me.dtpFechaAprueba.Name = "dtpFechaAprueba"
        Me.dtpFechaAprueba.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaAprueba.TabIndex = 4
        '
        'txtOrigen
        '
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(479, 34)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(140, 20)
        Me.txtOrigen.TabIndex = 2
        '
        'dtpFechaCOPAC
        '
        Me.dtpFechaCOPAC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCOPAC.Location = New System.Drawing.Point(100, 62)
        Me.dtpFechaCOPAC.Name = "dtpFechaCOPAC"
        Me.dtpFechaCOPAC.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaCOPAC.TabIndex = 4
        '
        'txtDiasCredito
        '
        Me.txtDiasCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiasCredito.Location = New System.Drawing.Point(479, 86)
        Me.txtDiasCredito.Name = "txtDiasCredito"
        Me.txtDiasCredito.Size = New System.Drawing.Size(100, 20)
        Me.txtDiasCredito.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(663, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Fecha PagoReal"
        '
        'txtSocio
        '
        Me.txtSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSocio.Location = New System.Drawing.Point(479, 8)
        Me.txtSocio.Name = "txtSocio"
        Me.txtSocio.Size = New System.Drawing.Size(140, 20)
        Me.txtSocio.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(375, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Mes Pago"
        '
        'txtMoneda
        '
        Me.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoneda.Location = New System.Drawing.Point(777, 8)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtMoneda.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(375, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Fecha Pago"
        '
        'txtMontoMoneda
        '
        Me.txtMontoMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoMoneda.Location = New System.Drawing.Point(777, 34)
        Me.txtMontoMoneda.Name = "txtMontoMoneda"
        Me.txtMontoMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoMoneda.TabIndex = 2
        Me.txtMontoMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(663, 117)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Fecha Despacho Real"
        '
        'txtMontoQ
        '
        Me.txtMontoQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoQ.Location = New System.Drawing.Point(777, 60)
        Me.txtMontoQ.Name = "txtMontoQ"
        Me.txtMontoQ.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoQ.TabIndex = 2
        Me.txtMontoQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(375, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Dias Credito"
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(777, 86)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtStatus.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(375, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Fecha Despacho"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Numero"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(375, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Origen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Empresa"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(663, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fecha COPAC"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(663, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Monto GTQ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 26)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Referencia " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "COPAC"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(663, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Monto Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 144)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "BUM Aprueba"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(663, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Moneda"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Fecha  Aprueba"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(375, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Socio"
        '
        'dgvOC
        '
        Me.dgvOC.AllowUserToAddRows = False
        Me.dgvOC.AllowUserToDeleteRows = False
        Me.dgvOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOC.Location = New System.Drawing.Point(3, 199)
        Me.dgvOC.Name = "dgvOC"
        Me.dgvOC.RowHeadersWidth = 20
        Me.dgvOC.Size = New System.Drawing.Size(887, 161)
        Me.dgvOC.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(311, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Ordenes de Compra Asociadas"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 361)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 25)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Facturas "
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.AllowUserToDeleteRows = False
        Me.dgvFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Location = New System.Drawing.Point(3, 389)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersWidth = 20
        Me.dgvFacturas.Size = New System.Drawing.Size(887, 97)
        Me.dgvFacturas.TabIndex = 7
        '
        'frm_scm_tracking_pedido_tesoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 518)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_scm_tracking_pedido_tesoreria"
        Me.Text = ":: Tracking Pedidos Tesoreria ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvOrdenes As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnAsociarOC As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvOC As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSocio As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtRefenciaCopac As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaPagoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDespachoReal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDespachoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaAprueba As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaCOPAC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoQ As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtMesPago As System.Windows.Forms.TextBox
    Friend WithEvents txtBUMAprueba As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaPagoReal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
