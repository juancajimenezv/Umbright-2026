<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Información_Lgs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv_Pdaant = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_pdaact = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_ResPicking = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgv_TablaAnterior = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgv_TablaActual = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_DevAnterior = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgv_DevActual = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgv_DevResumen = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.dtp_FechaF = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaI = New System.Windows.Forms.DateTimePicker()
        Me.btn_ControlRutas = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lb_final = New System.Windows.Forms.Label()
        Me.lb_inicial = New System.Windows.Forms.Label()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Pdaant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_pdaact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_ResPicking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_TablaAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_TablaActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_DevAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgv_DevActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgv_DevResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(10, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1057, 544)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1049, 518)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Picking"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(530, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Año Anterior"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Año Actual"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgv_Pdaant)
        Me.GroupBox2.Location = New System.Drawing.Point(526, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(514, 488)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'dgv_Pdaant
        '
        Me.dgv_Pdaant.AllowUserToAddRows = False
        Me.dgv_Pdaant.AllowUserToDeleteRows = False
        Me.dgv_Pdaant.AllowUserToOrderColumns = True
        Me.dgv_Pdaant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Pdaant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Pdaant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Pdaant.Location = New System.Drawing.Point(6, 10)
        Me.dgv_Pdaant.Name = "dgv_Pdaant"
        Me.dgv_Pdaant.ReadOnly = True
        Me.dgv_Pdaant.Size = New System.Drawing.Size(502, 472)
        Me.dgv_Pdaant.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv_pdaact)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(514, 488)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'dgv_pdaact
        '
        Me.dgv_pdaact.AllowUserToAddRows = False
        Me.dgv_pdaact.AllowUserToDeleteRows = False
        Me.dgv_pdaact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pdaact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_pdaact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pdaact.Location = New System.Drawing.Point(6, 10)
        Me.dgv_pdaact.Name = "dgv_pdaact"
        Me.dgv_pdaact.ReadOnly = True
        Me.dgv_pdaact.Size = New System.Drawing.Size(502, 472)
        Me.dgv_pdaact.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1049, 518)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Resumen Comparación Picking"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_ResPicking)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(395, 261)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'dgv_ResPicking
        '
        Me.dgv_ResPicking.AllowUserToAddRows = False
        Me.dgv_ResPicking.AllowUserToDeleteRows = False
        Me.dgv_ResPicking.AllowUserToOrderColumns = True
        Me.dgv_ResPicking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_ResPicking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ResPicking.Location = New System.Drawing.Point(6, 19)
        Me.dgv_ResPicking.Name = "dgv_ResPicking"
        Me.dgv_ResPicking.ReadOnly = True
        Me.dgv_ResPicking.Size = New System.Drawing.Size(383, 236)
        Me.dgv_ResPicking.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1049, 518)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Flujo Facturación"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(529, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Año Anterior"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Año Actual"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.dgv_TablaAnterior)
        Me.GroupBox5.Location = New System.Drawing.Point(526, 37)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(514, 434)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'dgv_TablaAnterior
        '
        Me.dgv_TablaAnterior.AllowUserToAddRows = False
        Me.dgv_TablaAnterior.AllowUserToDeleteRows = False
        Me.dgv_TablaAnterior.AllowUserToOrderColumns = True
        Me.dgv_TablaAnterior.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_TablaAnterior.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_TablaAnterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TablaAnterior.Location = New System.Drawing.Point(6, 10)
        Me.dgv_TablaAnterior.Name = "dgv_TablaAnterior"
        Me.dgv_TablaAnterior.ReadOnly = True
        Me.dgv_TablaAnterior.Size = New System.Drawing.Size(502, 418)
        Me.dgv_TablaAnterior.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgv_TablaActual)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 37)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(514, 434)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'dgv_TablaActual
        '
        Me.dgv_TablaActual.AllowUserToAddRows = False
        Me.dgv_TablaActual.AllowUserToDeleteRows = False
        Me.dgv_TablaActual.AllowUserToOrderColumns = True
        Me.dgv_TablaActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_TablaActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_TablaActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TablaActual.Location = New System.Drawing.Point(6, 10)
        Me.dgv_TablaActual.Name = "dgv_TablaActual"
        Me.dgv_TablaActual.ReadOnly = True
        Me.dgv_TablaActual.Size = New System.Drawing.Size(502, 418)
        Me.dgv_TablaActual.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Controls.Add(Me.GroupBox7)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1049, 518)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Devoluciones"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(530, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Año Anterior"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Año Actual"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgv_DevAnterior)
        Me.GroupBox6.Location = New System.Drawing.Point(527, 50)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(514, 434)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        '
        'dgv_DevAnterior
        '
        Me.dgv_DevAnterior.AllowUserToAddRows = False
        Me.dgv_DevAnterior.AllowUserToDeleteRows = False
        Me.dgv_DevAnterior.AllowUserToOrderColumns = True
        Me.dgv_DevAnterior.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_DevAnterior.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_DevAnterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DevAnterior.Location = New System.Drawing.Point(6, 10)
        Me.dgv_DevAnterior.Name = "dgv_DevAnterior"
        Me.dgv_DevAnterior.ReadOnly = True
        Me.dgv_DevAnterior.Size = New System.Drawing.Size(502, 418)
        Me.dgv_DevAnterior.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.dgv_DevActual)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 50)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(514, 434)
        Me.GroupBox7.TabIndex = 17
        Me.GroupBox7.TabStop = False
        '
        'dgv_DevActual
        '
        Me.dgv_DevActual.AllowUserToAddRows = False
        Me.dgv_DevActual.AllowUserToDeleteRows = False
        Me.dgv_DevActual.AllowUserToOrderColumns = True
        Me.dgv_DevActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_DevActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_DevActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DevActual.Location = New System.Drawing.Point(6, 10)
        Me.dgv_DevActual.Name = "dgv_DevActual"
        Me.dgv_DevActual.ReadOnly = True
        Me.dgv_DevActual.Size = New System.Drawing.Size(502, 418)
        Me.dgv_DevActual.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.dgv_DevResumen)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1049, 518)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Resumen Dev."
        '
        'dgv_DevResumen
        '
        Me.dgv_DevResumen.AllowUserToAddRows = False
        Me.dgv_DevResumen.AllowUserToDeleteRows = False
        Me.dgv_DevResumen.AllowUserToOrderColumns = True
        Me.dgv_DevResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_DevResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_DevResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DevResumen.Location = New System.Drawing.Point(36, 45)
        Me.dgv_DevResumen.Name = "dgv_DevResumen"
        Me.dgv_DevResumen.ReadOnly = True
        Me.dgv_DevResumen.Size = New System.Drawing.Size(502, 418)
        Me.dgv_DevResumen.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(616, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(505, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ejecutando . . . ..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(500, 28)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(241, 29)
        Me.ProgressBar1.TabIndex = 7
        '
        'dtp_FechaF
        '
        Me.dtp_FechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaF.Location = New System.Drawing.Point(121, 38)
        Me.dtp_FechaF.Name = "dtp_FechaF"
        Me.dtp_FechaF.Size = New System.Drawing.Size(118, 20)
        Me.dtp_FechaF.TabIndex = 12
        '
        'dtp_FechaI
        '
        Me.dtp_FechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaI.Location = New System.Drawing.Point(121, 12)
        Me.dtp_FechaI.Name = "dtp_FechaI"
        Me.dtp_FechaI.Size = New System.Drawing.Size(118, 20)
        Me.dtp_FechaI.TabIndex = 10
        '
        'btn_ControlRutas
        '
        Me.btn_ControlRutas.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ControlRutas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_ControlRutas.Location = New System.Drawing.Point(308, 17)
        Me.btn_ControlRutas.Name = "btn_ControlRutas"
        Me.btn_ControlRutas.Size = New System.Drawing.Size(123, 40)
        Me.btn_ControlRutas.TabIndex = 11
        Me.btn_ControlRutas.Text = "Generar"
        Me.btn_ControlRutas.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha Inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Fecha Final:"
        '
        'lb_final
        '
        Me.lb_final.AutoSize = True
        Me.lb_final.Location = New System.Drawing.Point(802, 38)
        Me.lb_final.Name = "lb_final"
        Me.lb_final.Size = New System.Drawing.Size(34, 13)
        Me.lb_final.TabIndex = 16
        Me.lb_final.Text = "00:00"
        '
        'lb_inicial
        '
        Me.lb_inicial.AutoSize = True
        Me.lb_inicial.Location = New System.Drawing.Point(802, 17)
        Me.lb_inicial.Name = "lb_inicial"
        Me.lb_inicial.Size = New System.Drawing.Size(34, 13)
        Me.lb_inicial.TabIndex = 15
        Me.lb_inicial.Text = "00:00"
        '
        'btn_Exportar
        '
        ' Me.btn_Exportar.Image = Global.Umbright.My.Resources.Resources.logo_excel
        Me.btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Exportar.Location = New System.Drawing.Point(890, 15)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(102, 66)
        Me.btn_Exportar.TabIndex = 17
        Me.btn_Exportar.Text = "Exportar"
        Me.btn_Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Exportar.UseVisualStyleBackColor = True
        '
        'frm_Información_Lgs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1072, 612)
        Me.Controls.Add(Me.btn_Exportar)
        Me.Controls.Add(Me.lb_final)
        Me.Controls.Add(Me.lb_inicial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_FechaF)
        Me.Controls.Add(Me.dtp_FechaI)
        Me.Controls.Add(Me.btn_ControlRutas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_Información_Lgs"
        Me.Text = "Información Lgs"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_Pdaant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_pdaact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_ResPicking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgv_TablaAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgv_TablaActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_DevAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgv_DevActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgv_DevResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgv_Pdaant As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_pdaact As DataGridView
    Friend WithEvents dtp_FechaF As DateTimePicker
    Friend WithEvents dtp_FechaI As DateTimePicker
    Friend WithEvents btn_ControlRutas As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents lb_final As Label
    Friend WithEvents lb_inicial As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgv_ResPicking As DataGridView
    Friend WithEvents btn_Exportar As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgv_TablaAnterior As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgv_TablaActual As DataGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dgv_DevAnterior As DataGridView
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents dgv_DevActual As DataGridView
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents dgv_DevResumen As DataGridView
End Class
