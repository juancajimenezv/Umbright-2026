Public Class frm_control_recolecciones
    Inherits System.Windows.Forms.Form

    Dim ds_guia As New DataSet
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDistancia As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaSalida As System.Windows.Forms.Label
    Friend WithEvents dtpFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents chkTiempoExtra As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NUDcopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_cobroTransporte As TextBox
    Dim ptipo_guia As String = ""
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
    Friend WithEvents dg_detalle_guia As System.Windows.Forms.DataGrid
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_piloto As System.Windows.Forms.ComboBox
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_vehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_auxliar As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents dg_controles_pendientes As System.Windows.Forms.DataGrid
    Friend WithEvents btn_control As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_aprobar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_vcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_control As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_ruta As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents menu_vehiculos As System.Windows.Forms.MenuItem
    Friend WithEvents menu_pilotos As System.Windows.Forms.MenuItem
    Friend WithEvents menu_ayudantes As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_Pickers As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_control_recolecciones))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_cobroTransporte = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NUDcopias = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_aprobar = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_ruta = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtp_fecha_vcto = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_control = New System.Windows.Forms.DateTimePicker()
        Me.btn_control = New System.Windows.Forms.Button()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.txt_monto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_auxliar = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_vehiculo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_observaciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmb_tipos = New System.Windows.Forms.ComboBox()
        Me.txtDistancia = New System.Windows.Forms.TextBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.cmb_piloto = New System.Windows.Forms.ComboBox()
        Me.dg_detalle_guia = New System.Windows.Forms.DataGrid()
        Me.lblFechaSalida = New System.Windows.Forms.Label()
        Me.chkTiempoExtra = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dg_controles_pendientes = New System.Windows.Forms.DataGrid()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.menu_vehiculos = New System.Windows.Forms.MenuItem()
        Me.menu_pilotos = New System.Windows.Forms.MenuItem()
        Me.menu_ayudantes = New System.Windows.Forms.MenuItem()
        Me.Menu_Pickers = New System.Windows.Forms.MenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_controles_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1370, 650)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txt_cobroTransporte)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.NUDcopias)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.StatusBar1)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.cmb_ruta)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.dtpFechaSalida)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_vcto)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_control)
        Me.TabPage1.Controls.Add(Me.btn_control)
        Me.TabPage1.Controls.Add(Me.lbl_numero)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txt_peso)
        Me.TabPage1.Controls.Add(Me.txt_monto)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmb_auxliar)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmb_vehiculo)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txt_observaciones)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cmbEmpresa)
        Me.TabPage1.Controls.Add(Me.cmb_tipos)
        Me.TabPage1.Controls.Add(Me.txtDistancia)
        Me.TabPage1.Controls.Add(Me.txt_numero)
        Me.TabPage1.Controls.Add(Me.cmb_piloto)
        Me.TabPage1.Controls.Add(Me.dg_detalle_guia)
        Me.TabPage1.Controls.Add(Me.lblFechaSalida)
        Me.TabPage1.Controls.Add(Me.chkTiempoExtra)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1362, 614)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle Control"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(133, 23)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Transporte Q."
        '
        'txt_cobroTransporte
        '
        Me.txt_cobroTransporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cobroTransporte.Location = New System.Drawing.Point(155, 230)
        Me.txt_cobroTransporte.MaxLength = 5
        Me.txt_cobroTransporte.Name = "txt_cobroTransporte"
        Me.txt_cobroTransporte.Size = New System.Drawing.Size(121, 30)
        Me.txt_cobroTransporte.TabIndex = 37
        Me.txt_cobroTransporte.Text = "0.00"
        Me.txt_cobroTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(830, 159)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 23)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Copias"
        '
        'NUDcopias
        '
        Me.NUDcopias.Location = New System.Drawing.Point(910, 158)
        Me.NUDcopias.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NUDcopias.Name = "NUDcopias"
        Me.NUDcopias.Size = New System.Drawing.Size(64, 30)
        Me.NUDcopias.TabIndex = 35
        Me.NUDcopias.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.btn_aprobar)
        Me.GroupBox1.Location = New System.Drawing.Point(988, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 256)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 1
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(9, 18)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(120, 111)
        Me.btn_nuevo.TabIndex = 7
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "7.png")
        Me.ImageList1.Images.SetKeyName(1, "3.png")
        Me.ImageList1.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "Floppy-64.png")
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 4
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(138, 133)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(120, 111)
        Me.btn_guardar.TabIndex = 8
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Imprimir.ImageIndex = 3
        Me.btn_Imprimir.ImageList = Me.ImageList1
        Me.btn_Imprimir.Location = New System.Drawing.Point(9, 133)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(120, 111)
        Me.btn_Imprimir.TabIndex = 23
        Me.btn_Imprimir.Text = "Imprimir"
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Imprimir.UseVisualStyleBackColor = False
        '
        'btn_aprobar
        '
        Me.btn_aprobar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_aprobar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_aprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aprobar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aprobar.ForeColor = System.Drawing.Color.White
        Me.btn_aprobar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aprobar.ImageIndex = 2
        Me.btn_aprobar.ImageList = Me.ImageList1
        Me.btn_aprobar.Location = New System.Drawing.Point(138, 18)
        Me.btn_aprobar.Name = "btn_aprobar"
        Me.btn_aprobar.Size = New System.Drawing.Size(120, 111)
        Me.btn_aprobar.TabIndex = 29
        Me.btn_aprobar.Text = "Aprobar"
        Me.btn_aprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aprobar.UseVisualStyleBackColor = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 580)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel2, Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1362, 34)
        Me.StatusBar1.TabIndex = 32
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 1197
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 140
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(769, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 23)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Ruta"
        '
        'cmb_ruta
        '
        Me.cmb_ruta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ruta.DropDownWidth = 150
        Me.cmb_ruta.Location = New System.Drawing.Point(826, 120)
        Me.cmb_ruta.Name = "cmb_ruta"
        Me.cmb_ruta.Size = New System.Drawing.Size(148, 31)
        Me.cmb_ruta.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(645, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(175, 23)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Fecha Vencimiento"
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaSalida.Location = New System.Drawing.Point(1147, 276)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(194, 30)
        Me.dtpFechaSalida.TabIndex = 6
        Me.dtpFechaSalida.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(686, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 23)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Fecha Control"
        '
        'dtp_fecha_vcto
        '
        Me.dtp_fecha_vcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vcto.Location = New System.Drawing.Point(826, 83)
        Me.dtp_fecha_vcto.Name = "dtp_fecha_vcto"
        Me.dtp_fecha_vcto.Size = New System.Drawing.Size(148, 30)
        Me.dtp_fecha_vcto.TabIndex = 6
        '
        'dtp_fecha_control
        '
        Me.dtp_fecha_control.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_control.Location = New System.Drawing.Point(826, 48)
        Me.dtp_fecha_control.Name = "dtp_fecha_control"
        Me.dtp_fecha_control.Size = New System.Drawing.Size(148, 30)
        Me.dtp_fecha_control.TabIndex = 5
        '
        'btn_control
        '
        Me.btn_control.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_control.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_control.ForeColor = System.Drawing.Color.White
        Me.btn_control.Location = New System.Drawing.Point(1087, 278)
        Me.btn_control.Name = "btn_control"
        Me.btn_control.Size = New System.Drawing.Size(36, 33)
        Me.btn_control.TabIndex = 24
        Me.btn_control.Text = "..."
        Me.btn_control.UseVisualStyleBackColor = False
        '
        'lbl_numero
        '
        Me.lbl_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_numero.ForeColor = System.Drawing.Color.Red
        Me.lbl_numero.Location = New System.Drawing.Point(826, 17)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(148, 29)
        Me.lbl_numero.TabIndex = 22
        Me.lbl_numero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(672, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 23)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Numero Control"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(717, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 23)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Peso Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(708, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Monto Total"
        '
        'txt_peso
        '
        Me.txt_peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_peso.Location = New System.Drawing.Point(826, 227)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.ReadOnly = True
        Me.txt_peso.Size = New System.Drawing.Size(148, 30)
        Me.txt_peso.TabIndex = 17
        Me.txt_peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_monto
        '
        Me.txt_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_monto.Location = New System.Drawing.Point(826, 195)
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.ReadOnly = True
        Me.txt_monto.Size = New System.Drawing.Size(148, 30)
        Me.txt_monto.TabIndex = 16
        Me.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Ayudante"
        '
        'cmb_auxliar
        '
        Me.cmb_auxliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_auxliar.Location = New System.Drawing.Point(156, 93)
        Me.cmb_auxliar.Name = "cmb_auxliar"
        Me.cmb_auxliar.Size = New System.Drawing.Size(468, 31)
        Me.cmb_auxliar.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 23)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vehiculo"
        '
        'cmb_vehiculo
        '
        Me.cmb_vehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_vehiculo.Location = New System.Drawing.Point(156, 12)
        Me.cmb_vehiculo.Name = "cmb_vehiculo"
        Me.cmb_vehiculo.Size = New System.Drawing.Size(468, 31)
        Me.cmb_vehiculo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Observaciones"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.Location = New System.Drawing.Point(156, 135)
        Me.txt_observaciones.Multiline = True
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_observaciones.Size = New System.Drawing.Size(468, 86)
        Me.txt_observaciones.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Piloto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 23)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 281)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Docto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(815, 283)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 23)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Distancia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(597, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Numero"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.DropDownWidth = 175
        Me.cmbEmpresa.Location = New System.Drawing.Point(111, 278)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(144, 31)
        Me.cmbEmpresa.TabIndex = 10
        '
        'cmb_tipos
        '
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.DropDownWidth = 175
        Me.cmb_tipos.Location = New System.Drawing.Point(333, 278)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(239, 31)
        Me.cmb_tipos.TabIndex = 10
        '
        'txtDistancia
        '
        Me.txtDistancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistancia.Location = New System.Drawing.Point(910, 279)
        Me.txtDistancia.MaxLength = 5
        Me.txtDistancia.Name = "txtDistancia"
        Me.txtDistancia.Size = New System.Drawing.Size(64, 30)
        Me.txtDistancia.TabIndex = 12
        Me.txtDistancia.Text = "0"
        Me.txtDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(683, 279)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(122, 30)
        Me.txt_numero.TabIndex = 11
        '
        'cmb_piloto
        '
        Me.cmb_piloto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_piloto.Location = New System.Drawing.Point(156, 52)
        Me.cmb_piloto.Name = "cmb_piloto"
        Me.cmb_piloto.Size = New System.Drawing.Size(468, 31)
        Me.cmb_piloto.TabIndex = 2
        '
        'dg_detalle_guia
        '
        Me.dg_detalle_guia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_detalle_guia.CaptionVisible = False
        Me.dg_detalle_guia.DataMember = ""
        Me.dg_detalle_guia.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_guia.Location = New System.Drawing.Point(12, 320)
        Me.dg_detalle_guia.Name = "dg_detalle_guia"
        Me.dg_detalle_guia.Size = New System.Drawing.Size(1334, 202)
        Me.dg_detalle_guia.TabIndex = 0
        '
        'lblFechaSalida
        '
        Me.lblFechaSalida.AutoSize = True
        Me.lblFechaSalida.Location = New System.Drawing.Point(1154, 277)
        Me.lblFechaSalida.Name = "lblFechaSalida"
        Me.lblFechaSalida.Size = New System.Drawing.Size(124, 23)
        Me.lblFechaSalida.TabIndex = 28
        Me.lblFechaSalida.Text = "Fecha Salida"
        Me.lblFechaSalida.Visible = False
        '
        'chkTiempoExtra
        '
        Me.chkTiempoExtra.AutoSize = True
        Me.chkTiempoExtra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTiempoExtra.Location = New System.Drawing.Point(645, 153)
        Me.chkTiempoExtra.Name = "chkTiempoExtra"
        Me.chkTiempoExtra.Size = New System.Drawing.Size(158, 27)
        Me.chkTiempoExtra.TabIndex = 34
        Me.chkTiempoExtra.Text = "Tiempo Extra "
        Me.chkTiempoExtra.UseVisualStyleBackColor = True
        Me.chkTiempoExtra.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dg_controles_pendientes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1362, 614)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Controles Pendientes"
        '
        'dg_controles_pendientes
        '
        Me.dg_controles_pendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_controles_pendientes.CaptionVisible = False
        Me.dg_controles_pendientes.DataMember = ""
        Me.dg_controles_pendientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_controles_pendientes.Location = New System.Drawing.Point(15, 25)
        Me.dg_controles_pendientes.Name = "dg_controles_pendientes"
        Me.dg_controles_pendientes.ReadOnly = True
        Me.dg_controles_pendientes.Size = New System.Drawing.Size(1251, 692)
        Me.dg_controles_pendientes.TabIndex = 0
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menu_vehiculos, Me.menu_pilotos, Me.menu_ayudantes, Me.Menu_Pickers})
        Me.MenuItem1.Text = "Catalogos"
        '
        'menu_vehiculos
        '
        Me.menu_vehiculos.Index = 0
        Me.menu_vehiculos.Text = "Vehiculos"
        '
        'menu_pilotos
        '
        Me.menu_pilotos.Index = 1
        Me.menu_pilotos.Text = "Pilotos"
        '
        'menu_ayudantes
        '
        Me.menu_ayudantes.Index = 2
        Me.menu_ayudantes.Text = "Ayudantes"
        '
        'Menu_Pickers
        '
        Me.Menu_Pickers.Index = 3
        Me.Menu_Pickers.Text = "Pickers"
        Me.Menu_Pickers.Visible = False
        '
        'frm_control_recolecciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(9, 23)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1370, 650)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "frm_control_recolecciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control de Recolecciones"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_controles_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        'ls_sql = "pa_sel_um_gen_parametros_sistema"
        'ldt_table = oTransaccion.Obtiene(ls_sql)
        'tipos_doctos = ldt_table.Rows(0).Item("documentos_control_transporte").ToString.Split(",")
        'Me.cmb_tipos.Items.AddRange(tipos_doctos)

        ls_sql = "pa_sel_tipodocto_recoleccion '" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "tdr"
        Me.cmb_tipos.DisplayMember = "TIPODOCTO"
        Me.cmb_tipos.ValueMember = "TIPODOCTO"
        Me.cmb_tipos.DataSource = ldt_table.DefaultView

        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_VEHICULOS','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "piloto"
        ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_vehiculo.DisplayMember = "CODIGO"
        Me.cmb_vehiculo.ValueMember = "CODIGO"
        Me.cmb_vehiculo.DataSource = ldt_table.DefaultView

        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_AUXILIAR','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "piloto"
        ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_auxliar.DisplayMember = "CODIGO"
        Me.cmb_auxliar.ValueMember = "CODIGO"
        Me.cmb_auxliar.DataSource = ldt_table.DefaultView

        'ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_TIPOGUIA',NULL"
        'ldt_table = oTransaccion.Obtiene(ls_sql)
        ptipo_guia = "CONTROL RECOLECCIONES"
        'ldt_table.Rows(0).Item("descripcion").ToString

        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_PILOTO','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "piloto"
        ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_piloto.DisplayMember = "CODIGO"
        Me.cmb_piloto.ValueMember = "CODIGO"
        Me.cmb_piloto.DataSource = ldt_table.DefaultView

        ls_sql = "pa_sel_um_gen_tabcod NULL,'analisisctacte9','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "ruta"

        Me.cmb_ruta.DisplayMember = "CODIGO"
        Me.cmb_ruta.ValueMember = "CODIGO"
        Me.cmb_ruta.DataSource = ldt_table

        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "empresa"

        Me.cmbEmpresa.DisplayMember = "descripcion"
        Me.cmbEmpresa.ValueMember = "descripcion"
        Me.cmbEmpresa.DataSource = ldt_table


        oTransaccion.close()
        oTransaccion = Nothing
    End Sub

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("detalle_guia")

        dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_docto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("comentario_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("distancia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        ds_guia.Tables.Add(dt.Copy)
    End Sub

    Private Sub Colorear_Grid()
        Dim clsGen As New ClasesGenerales.General
        Me.dg_detalle_guia.DataSource = ds_guia.Tables("detalle_guia")
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "detalle_guia"


        For Each col As DataColumn In ds_guia.Tables("detalle_guia").Columns

            Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
            gridCol.MappingName = col.ColumnName

            Select Case col.ColumnName.ToLower
                Case "picker"
                    gridCol.Width = 0
                Case "monto", "peso"
                    gridCol.Format = "n"
                    gridCol.Alignment = HorizontalAlignment.Right
                Case Else
                    gridCol.Width = clsGen.tamaño_maximo_campo(ds_guia.Tables("detalle_guia"), " ", col.ColumnName, Me.dg_detalle_guia, 200, 0)
            End Select

            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
            gridCol.NullText = ""
            AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
            tableStyle.GridColumnStyles.Add(gridCol)
        Next

        tableStyle.RowHeaderWidth = 5
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray

        Me.dg_detalle_guia.TableStyles.Clear()
        Me.dg_detalle_guia.TableStyles.Add(tableStyle)
    End Sub

    'Llenar Pedientes de Aprobacion
    Private Sub Llenar_Pendientes_Aprobacion()
        Dim ls_sql As String
        Dim dt As DataTable

        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()
            If ds_guia.Tables.IndexOf("pendientes_aprobacion") > 0 Then
                ds_guia.Tables.Remove("pendientes_aprobacion")
            End If

            '    If gs_usuario = "orodriguez" Or gs_usuario = "eabad" Or gs_usuario = "cdeleon" Or gs_usuario = "asaravia" Then
            ls_sql = "pa_sel_um_gen_control_transporte_recolecciones null,null,'" & gs_usuario & "'"
            dt = oTrans.Obtiene(ls_sql)
            '   Else
            '  ls_sql = "pa_sel_um_gen_control_transporte_temporal_DTT '" & gs_empresa & "'"
            ' dt = oTrans.Obtiene(ls_sql)
            'End If

            Me.dg_controles_pendientes.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_controles_pendientes, dt.TableName, -1, 350, 0, False, False, "", True, "")
            dt.TableName = "pendientes_aprobacion"
            ds_guia.Tables.Add(dt.Copy)
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try

    End Sub

    Private Sub frm_control_transporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Crear_Estructura()
        Colorear_Grid()
        Llenar_Pendientes_Aprobacion()
        Me.Text = "Control de Recolecciones 2024"
    End Sub

    Private Sub Buscar_Factura()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dr, dr_aux As DataRow

        otrans.open()

        Try


            If Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0") Then
                ls_sql = "pa_var_um_documento_control_transporte '" & Me.cmbEmpresa.SelectedValue & "','" &
                                Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"

                dt = otrans.Obtiene(ls_sql)

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                Else
                    If dt.Rows.Count > 0 Then

                        If dt.Rows(0).Item("porcentajeAsignado") > 0 Or
                            dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0 Then

                            MessageBox.Show("Documento Asignado En Control " & dt.Rows(0).Item("numero_final") & ", Puede Continuar..", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            If Es_Unico("detalle_guia", ds_guia.Tables("detalle_guia"), "numero", Me.txt_numero.Text) Then

                                dr = dt.Rows(0)
                                Try
                                    If Val(dr.Item("distancia").ToString) > 0 Then
                                        Me.txtDistancia.Text = dr.Item("distancia")
                                    End If

                                Catch ex As Exception
                                End Try

                                dr_aux = ds_guia.Tables("detalle_guia").NewRow
                                dr_aux.Item("tipo_docto") = dr.Item("tipodocto")
                                dr_aux.Item("numero") = dr.Item("numero")
                                dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                                dr_aux.Item("monto") = dr.Item("total")
                                dr_aux.Item("peso") = dr.Item("peso")
                                dr_aux.Item("picker") = dr.Item("picker")
                                dr_aux.Item("comentario_factura") = dr.Item("comentario1")
                                Try
                                    dr_aux.Item("distancia") = Val(Me.txtDistancia.Text)
                                Catch ex As Exception

                                End Try

                                dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                                ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
                                Colorear_Grid()
                                Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                                Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                            Else
                                MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Documento no Existe en Guia, No puede ser Recolectada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Documento No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If 'codigo_error
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.txt_numero.Focus()
            Me.txt_numero.SelectAll()

        End Try

    End Sub

    Private Sub Recalcular_Totales(ByVal dt As DataTable)
        'Totaliza la cotizacion
        'Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, total_peso As Double

        total = 0
        total_peso = 0
        Try

            For Each dr In dt.Rows
                total = total + dr.Item("monto")
                total_peso = total_peso + dr.Item("peso")
            Next
        Catch ex As Exception
        Finally
            Me.txt_monto.Text = total
            Me.txt_peso.Text = total_peso
            Try
                Me.StatusBarPanel1.Text = "Documentos " & ds_guia.Tables("detalle_guia").Rows.Count.ToString
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Private Sub Recalcular_Totales(ByVal dt As DataTable, ByVal psEmpresa As String)
        'Totaliza la cotizacion
        'Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, total_peso As Double

        total = 0
        total_peso = 0
        Try

            For Each dr In dt.Rows
                If dr.Item("empresa").ToString.ToLower.Equals(psEmpresa.ToLower) Then

                    total = total + dr.Item("monto")
                    total_peso = total_peso + dr.Item("peso")
                End If
            Next
        Catch ex As Exception
        Finally
            Me.txt_monto.Text = total
            Me.txt_peso.Text = total_peso
            Try
                Me.StatusBarPanel1.Text = "Documentos " & ds_guia.Tables("detalle_guia").Rows.Count.ToString
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Private Function Es_Unico(ByVal TableName As String,
                              ByVal SourceTable As DataTable,
                              ByVal FieldName As String,
                              ByVal DatoActual As String) As Boolean


        Dim ReturnValue As Boolean = True
        Dim dt As New DataTable(TableName)
        Dim nveces As Integer = 0

        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)


        For Each dr As DataRow In SourceTable.Select("", FieldName)
            If ColumnEqual(DatoActual, dr(FieldName)) Then
                ReturnValue = False
            End If
            'If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
            '   LastValue = dr(FieldName)
            '    dt.Rows.Add(New Object() {LastValue})
            'End If
        Next
        'If Not ds Is Nothing Then ds.Tables.Add(dt)
        'Return dt
        Return ReturnValue
    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle the fields in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function

    Private Sub Guardar_Control()
        Dim ls_sql, ls_sql2 As String
        Dim dt, dtEmpresas As DataTable

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim llimpiar_pantalla As Boolean = False
        Dim ls_periodo As String
        Dim ldfecha As Date

        otrans.open()

        Try
            dtEmpresas = clsGen.ValoresDistinto(ds_guia.Tables("detalle_guia"), "empresa".Split(","))
            ls_sql = "pa_sel_um_numero_control_transporte_corporativo '" & ptipo_guia & "'"
            dt = otrans.Obtiene(ls_sql)

            If otrans.Codigo_error = 0 Then
                If dt.Rows.Count > 0 Then
                    Me.lbl_numero.Text = CInt(dt.Rows(0).Item("numero")) + 1
                    Me.lbl_numero.Text = Me.lbl_numero.Text.PadLeft(10, "0")


                    ldfecha = Me.dtp_fecha_control.Value
                    ls_periodo = ldfecha.Year & ldfecha.Month.ToString.PadLeft(2, "0")
                    'Insertar(Documento)

                    For Each dr As DataRow In dtEmpresas.Rows

                        Try
                            Recalcular_Totales(ds_guia.Tables("detalle_guia"), dr.Item("empresa"))
                            'Me.txt_monto.Text = ds_guia.Tables("detalle_guia").Compute("monto", "empresa='" & dr.Item("empresa") & "'")
                        Catch ex As Exception

                        End Try


                        ls_sql = "pa_ins_um_control_recolecciones'" & dr.Item("empresa").ToString & "','" &
                                 ptipo_guia & "','" & Me.lbl_numero.Text.Trim & "','" &
                                 Me.dtp_fecha_control.Text & "','" & Me.dtp_fecha_vcto.Text & "','" &
                                 Me.cmb_piloto.Text & "','" & Me.cmb_vehiculo.Text & "','" &
                                 Me.cmb_auxliar.Text & "'," & Double.Parse(Me.txt_monto.Text) & "," &
                                "12,'S','" & ls_periodo & "','" & Me.cmb_ruta.Text & "','"

                        ls_sql2 = Me.txt_observaciones.Text & "','" &
                                gs_usuario & "',null,'" &
                                IIf(Me.chkTiempoExtra.CheckState = CheckState.Checked, "SI", "NO") & "'," & txt_cobroTransporte.Text


                        otrans.Ingresa(ls_sql & ls_sql2)
                    Next


                    If otrans.Codigo_error = 0 Then
                        Guarda_Detalle()

                        'VALIDA SI LA RUTA ES DTT PARA CREAR PICKING CONSOLIDADO
                        '-------------------------------------------------------
                        'If cmb_ruta.Text.ToString.StartsWith("DTT") Or cmb_ruta.Text.ToString.StartsWith("TEX") Or cmb_ruta.Text = "BAZAR" Then 'Or cmb_ruta.Text = "DTT XE"

                        '    If Not (Me.cmb_tipos.Text.ToString.ToLower.StartsWith("devolu")) Then
                        '        crea_picking_dtt()
                        '    End If

                        'End If

                    Else
                        MessageBox.Show(otrans.descripcion_error)
                    End If


                End If

                If MessageBox.Show("Desea Imprimir Control", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Imprimir_Control()
                End If
                llimpiar_pantalla = True
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        If llimpiar_pantalla Then
            Limpiar_Pantalla()
            Llenar_Pendientes_Aprobacion()
        End If
    End Sub

    Private Sub Modificar_Control()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim dt, dtEmpresas As DataTable
        Dim llimpiar_pantalla As Boolean = False

        Try
            otrans.open()

            'Actualizo Estado de Control
            'Hacer Validaciones
            ls_sql = "pa_sel_um_gen_control_transporte_temporal_DTT '" & gs_empresa & "','" & Me.lbl_numero.Text & "'"
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then


                '' Validar si es DTT
                ''------------------------
                'If cmb_ruta.Text = "DTT" And dt.Rows(0).Item("Ruta") = "DTT" And Mid(dt.Rows(0).Item("Comentario1"), 1, 3) = "DTT" Then
                '    MsgBox("actualiza numero ya que es DTT")



                '    'Asigna numero REAL de los controles
                '    '-----------------------------------
                '    dtEmpresas = clsGen.ValoresDistinto(ds_guia.Tables("detalle_guia"), "empresa".Split(","))
                '    ls_sql = "pa_sel_um_numero_control_transporte_corporativo '" & ptipo_guia & "'"
                '    dt = otrans.Obtiene(ls_sql)

                '    ' Elimina el control con el numero temporal para asignarle uno REAL
                '    '------------------------------------------------------------------
                '    If otrans.Codigo_error = 0 Then
                '        ls_sql = "pa_del_um_control_transporte '" & lbl_numero.Text & "'"
                '        otrans.Obtiene(ls_sql)

                '        'guarda nuevamente el control con los cambios a DTT
                '        '---------------------------------------------------

                '        ' Crea PICKING CONSOLIDADO DTT se hace dentro del Guardar_Control
                '        '-----------------------------------------------------------------
                '        ' crea_picking_dtt()
                '        Guardar_Control()




                '    End If

                'Else

                If dt.Rows(0).Item("estado") = False Then
                    ls_sql = "pa_upd_um_control_transporte '" & gs_empresa & "','" & ptipo_guia & "','" &
                                  Me.lbl_numero.Text & "',NULL,'" &
                                  Me.cmb_piloto.Text & "','" & Me.cmb_vehiculo.Text & "','" &
                                  Me.cmb_auxliar.Text & "'," & Double.Parse(Me.txt_monto.Text) & "," &
                                  "'" & Me.cmb_ruta.Text & "','" & Me.txt_observaciones.Text & "','" &
                                   Me.dtp_fecha_vcto.Text & "','" & Me.dtp_fecha_control.Text & "'"

                    otrans.Actualiza(ls_sql)
                    If otrans.Codigo_error = 0 Then

                        ls_sql = "pa_del_um_gen_control_transporte_temporal '" & gs_empresa & "','" & ptipo_guia & "','" &
                                  Me.lbl_numero.Text & "'"

                        otrans.Elimina(ls_sql)

                        If otrans.Codigo_error = 0 Then
                            Guarda_Detalle()
                        End If

                        llimpiar_pantalla = True
                        ' Preguntamos si desea Actualizar el Control
                        If MessageBox.Show("Desea APROBAR el Control", "Aprobacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            otrans.close()
                            Aprobar_Control()
                            llimpiar_pantalla = False
                        End If
                    Else
                        MessageBox.Show(otrans.descripcion_error)
                    End If
                Else
                    MessageBox.Show("Este Control no se puede Modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If


            '   End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If llimpiar_pantalla Then
            Limpiar_Pantalla()
            Llenar_Pendientes_Aprobacion()
        End If
    End Sub

    Private Sub crea_picking_dtt()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ' SE AGREGA RUTA 
            ls_sql = "pa_ins_um_pincking_consolidado_dtt '" & dtp_fecha_control.Text & "','" & gs_usuario & "','" & lbl_numero.Text & "','" & cmb_ruta.Text & "'"
            otrans.Ingresa(ls_sql)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Guarda_Detalle()
        Dim dr As DataRow
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            For Each dr In ds_guia.Tables("detalle_guia").Rows
                Try
                    ls_sql = "pa_ins_um_gen_control_transporte_temporal '" & dr.Item("empresa").ToString & "','" &
                             ptipo_guia & "','" & Me.lbl_numero.Text.Trim & "','" &
                             dr.Item("tipo_docto").ToString & "','" &
                             dr.Item("numero").ToString & "','" &
                             gs_usuario & "'," & dr.Item("distancia").ToString

                    otrans.Ingresa(ls_sql)
                    If otrans.Codigo_error > 0 Then
                        MessageBox.Show(otrans.descripcion_error)
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Mostrar_registro(ByVal prownumber As Integer, ByVal pnumero As String)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("flexline")

        otrans.open()

        Try
            ds_guia.Tables("detalle_guia").Rows.Clear()

            '  If gs_usuario = "jvasquez" Or gs_usuario = "aescobar" Or gs_usuario = "earreaga" Or gs_usuario = "asaravia" Or gs_usuario = "walvarado" Then

            ls_sql = "pa_sel_um_gen_control_transporte_detalle_temporal_recolecciones null, '" & pnumero & "'"
            dt = otrans.Obtiene(ls_sql)

            'Else
            '    ls_sql = "pa_sel_um_gen_control_transporte_detalle_temporal '" & gs_empresa & "','" & pnumero & "'"
            '    dt = otrans.Obtiene(ls_sql)

            'End If

            For Each dr In dt.Rows

                dr_aux = ds_guia.Tables("detalle_guia").NewRow

                dr_aux.Item("tipo_docto") = dr.Item("tipodoctoOrigen")
                dr_aux.Item("numero") = dr.Item("numeroOrigen")
                dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                dr_aux.Item("monto") = dr.Item("total")
                dr_aux.Item("peso") = dr.Item("peso")
                dr_aux.Item("comentario_factura") = dr.Item("comentario1")
                dr_aux.Item("distancia") = dr.Item("distancia")
                dr_aux.Item("empresa") = dr.Item("empresa")
                ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)

            Next

            ds_guia.Tables("pendientes_aprobacion").DefaultView.RowFilter = "numero = '" & Me.dg_controles_pendientes.Item(prownumber, 2) & "'"
            drv = ds_guia.Tables("pendientes_aprobacion").DefaultView(0)
            Me.cmb_ruta.SelectedValue = drv.Item("ruta")
            Me.dtp_fecha_control.Text = drv.Item("fecha")
            Me.dtp_fecha_vcto.Value = drv.Item("fechaVcto")
            Me.cmb_vehiculo.SelectedValue = drv.Item("vehiculo")
            Me.cmb_piloto.SelectedValue = drv.Item("piloto")
            Me.cmb_auxliar.SelectedValue = drv.Item("auxiliar")
            Me.lbl_numero.Text = drv.Item("numero")
            Me.txt_observaciones.Text = drv.Item("comentario1")
            Me.chkTiempoExtra.CheckState = IIf(drv.Item("tiempoExtra") = "SI", CheckState.Checked, CheckState.Unchecked)
            Me.txt_observaciones.Text = txt_observaciones.Text & " " & dt.Rows(0).Item("Vendedor").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            Colorear_Grid()
            Recalcular_Totales(ds_guia.Tables("detalle_guia"))

        End Try

    End Sub

    Private Sub Limpiar_Pantalla()
        ds_guia.Tables("detalle_guia").Rows.Clear()
        Me.cmb_ruta.SelectedValue = ""
        Me.dtp_fecha_control.Value = Now
        Me.dtp_fecha_vcto.Value = Now
        Me.cmb_vehiculo.SelectedValue = ""
        Me.cmb_piloto.SelectedValue = ""
        Me.lbl_numero.Text = ""
        Me.txt_observaciones.Text = ""
        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
        Me.lblFechaSalida.Visible = False
        Me.dtpFechaSalida.Visible = False
    End Sub

    Private Sub Aprobar_Control()

        Dim ls_sql, nombre_chequeador As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim icount As Integer = 0
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim llimpiar_pantalla As Boolean = False

        Try
            otrans.open()
            'Hacer Validaciones
            ls_sql = "pa_sel_um_gen_control_transporte_temporal_recolecciones '" & gs_empresa & "','" & Me.lbl_numero.Text & "'"
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("estado") = False Then

                    'Quien fue el Chequeador
                    Dim oform As New frm_pickeador
                    oform.Text = "Seleccione Chequeador"
                    oform.Llenar_Combo_Chequeador()
                    oform.ShowDialog(Me)
                    nombre_chequeador = oform.cmb_nombre_picker.Text
                    oform.Dispose()



                    'Tomar toda la informacion de los controles
                    'tengo que traer el correlativo
                    If nombre_chequeador.Trim.Length > 5 Then


                        ls_sql = "pa_var_um_detalle_documento_control_transporte '" & gs_empresa & "','" & ptipo_guia & "','" & Me.lbl_numero.Text & "'"
                        dt = otrans.Obtiene(ls_sql)

                        For Each dr In dt.Rows
                            icount = icount + 1
                            ls_sql = "pa_ins_um_detalle_control_transporte '" &
                                      gs_empresa & "','" & ptipo_guia & "'," & dr.Item("correlativoControl").ToString.Trim & "," &
                                      icount.ToString.Trim & ",'" & dr.Item("producto").ToString & "'," &
                                      dr.Item("cantidad").ToString & "," & dr.Item("precio").ToString & "," &
                                      dr.Item("SubTotal").ToString & "," & dr.Item("neto").ToString & "," &
                                      dr.Item("Costo").ToString & "," & dr.Item("Total").ToString & "," &
                                      dr.Item("PrecioAjustado").ToString & ",'" & dr.Item("UnidadIngreso").ToString & "'," &
                                      dr.Item("CantidadIngreso").ToString & "," & dr.Item("PrecioIngreso").ToString & "," &
                                      dr.Item("SubTotalIngreso").ToString & "," & dr.Item("NetoIngreso").ToString & "," &
                                      dr.Item("TotalIngreso").ToString & ",'" & dr.Item("tipoDoctoOriginal").ToString & "'," &
                                      dr.Item("CorrelativoOriginal").ToString & "," & dr.Item("SecuenciaOriginal").ToString & ",'" &
                                      dr.Item("fechaEntregaOriginal").ToString & "','" & dr.Item("fecha").ToString & "'," &
                                      dr.Item("CUP").ToString & ",'" & dr.Item("ubicacion").ToString & "','" &
                                      dr.Item("ubicacion2").ToString & "'," & dr.Item("PrecioBimoneda").ToString & "," &
                                      dr.Item("SubTotalBimoneda").ToString & "," & dr.Item("NetoBimoneda").ToString & "," &
                                      dr.Item("TotalBimoneda").ToString & "," & dr.Item("PrecioListaP").ToString & ",'" &
                                      dr.Item("FechaVigenciaLp").ToString & "'"

                            otrans.Ingresa(ls_sql)
                            If otrans.Codigo_error > 0 Then
                                MessageBox.Show(otrans.descripcion_error)
                            End If

                        Next

                        'Actualizo Estado de Control
                        ls_sql = "pa_upd_um_gen_control_transporte_temporal '" & gs_empresa & "','" & ptipo_guia & "','" &
                                  Me.lbl_numero.Text & "',1"
                        otrans.Actualiza(ls_sql)

                        'Actualizo Chequeador
                        ls_sql = "pa_upd_um_control_transporte  '" & gs_empresa & "','" & ptipo_guia & "','" &
                                Me.lbl_numero.Text & "','" & nombre_chequeador & "',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" &
                                Me.dtpFechaSalida.Text & "',NULL,'" &
                                IIf(Me.chkTiempoExtra.CheckState = CheckState.Checked, "SI", "NO") & "'" &
                                ",'" & gs_usuario & "'"


                        otrans.Actualiza(ls_sql)


                        'Genero Documentov
                        ls_sql = "pa_ins_um_documentov '" & gs_empresa & "','" & ptipo_guia & "'," &
                                dt.Rows(0).Item("correlativocontrol").ToString & "," &
                                Double.Parse(Me.txt_monto.Text) & ",12"

                        otrans.Ingresa(ls_sql)


                        MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        llimpiar_pantalla = True
                    Else
                        MessageBox.Show("Debe Seleccionar un Chequeador Valido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Este Control ya ha sido Procesado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        If llimpiar_pantalla Then
            Limpiar_Pantalla()
            Llenar_Pendientes_Aprobacion()
        End If
    End Sub
    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            '    Buscar_Factura()
            Busca_numero_barra()
            Me.txt_numero.Text = ""
            Me.txt_numero.Focus()
        End If
    End Sub

    Private Sub Busca_numero_barra()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            ' POR DEFAULT AGREGARA FEL

            If cmb_tipos.Text = "" Or cmb_tipos.SelectedIndex = -1 Then
                cmb_tipos.Text = "CONSIGNACIONES"
            End If


            lsSQL = Mid(txt_numero.Text.PadLeft(10, "0"c), 1, 10)
            txt_numero.Text = lsSQL
            txtDistancia.Text = "0"
                    Buscar_Factura()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value2 As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value2 = data("picker").ToString

            If value2.Trim.ToLower = "sin picker" Then
                e.RowColor = Color.Red
            End If


        Catch ex As Exception
        End Try
    End Sub



    Public Sub Imprimir_Control()
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        '  Dim dtEmpresas As DataTable

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Logistica\Trafico\Guía del Liquidador Recoleccion.rpt"
            '  pm_parametros(0) = "empresa"
            pm_parametros(0) = "Numero de Documento"

            'dtEmpresas = ClsGen.ValoresDistinto(ds_guia.Tables("detalle_guia"), "empresa".Split(","))
            'For Each dr As DataRow In dtEmpresas.Rows
            'pm_valores(0) = dr.Item("empresa") 'gs_empresa
            pm_valores(0) = Me.lbl_numero.Text

            '(c) 20150601

            For i As Integer = 1 To Me.NUDcopias.Value
                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", False, "", True, 1)
            Next

            '   Imprimir_picking()

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Imprimir_picking()
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            otrans.open()

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False

            Try
                'Obtengo Datos de Conexion
                pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                path_reporte = ClsGen.Path_Reporte

                path_reporte += "Logistica\Picking\Picking Consolidado DTT.rpt"

                pm_parametros(0) = "@Identificador"
                pm_valores(0) = CInt(lbl_numero.Text)

                For i As Integer = 1 To Me.NUDcopias.Value

                    lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                   pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                   False, True, "PDF", True, "", True, 1)
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto.TextChanged
        txt_monto.Text = Format(Convert.ToDecimal(txt_monto.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub txt_peso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_peso.TextChanged
        txt_peso.Text = Format(Convert.ToDecimal(txt_peso.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub dg_detalle_guia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dg_detalle_guia.Validating
        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Me.btn_guardar.Text = "Guardar" Then
            If Me.lbl_numero.Text.Trim.Length = 0 Then
                If Double.Parse(Me.txt_monto.Text) <> 0 Then
                    Guardar_Control()
                End If

            Else
                If MessageBox.Show("Esta Seguro de Modificar La Informacion del Control", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Modificar_Control()
                End If
            End If
        End If
    End Sub

    Private Sub dg_controles_pendientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_controles_pendientes.DoubleClick
        Dim li_rownumber As Integer
        Dim ls_resultado As String
        li_rownumber = Me.dg_controles_pendientes.CurrentCell.RowNumber
        ls_resultado = Me.dg_controles_pendientes.Item(li_rownumber, 2)
        Mostrar_registro(li_rownumber, ls_resultado)
        Me.lblFechaSalida.Visible = True
        Me.dtpFechaSalida.Visible = True
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub btn_control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_control.Click
        Dim ls_sql As String
        Dim dt As DataTable

        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            otrans.open()
            ls_sql = "pa_var_um_documento_guia_transporte '" & Me.cmbEmpresa.SelectedValue & "','" & Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"

            dt = otrans.Obtiene(ls_sql)

            If otrans.Codigo_error = 0 Then
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Control Asignado  " & Chr(13) & dt.Rows(0).Item("numero_control").ToString & " del " &
                                        dt.Rows(0).Item("fecha_control").ToString,
                     "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        Imprimir_Control()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Pantalla()
    End Sub

    Private Sub btn_aprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aprobar.Click
        Aprobar_Control()
    End Sub

    Private Sub menu_vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_vehiculos.Click
        Dim oform As New frm_gen_tabcod
        oform.gen_tipo = "GEN_VEHICULOS"
        oform.ShowDialog()
    End Sub

    Private Sub menu_pilotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_pilotos.Click
        Dim oform As New frm_gen_tabcod
        oform.gen_tipo = "GEN_PILOTO"
        oform.ShowDialog()

    End Sub

    Private Sub menu_ayudantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_ayudantes.Click
        Dim oform As New frm_gen_tabcod
        oform.gen_tipo = "GEN_AUXILIAR"
        oform.ShowDialog()

    End Sub


    Private Sub Menu_Pickers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Pickers.Click
        Dim oform As New frm_gen_tabcod
        oform.gen_tipo = "GEN_PICKER"
        oform.ShowDialog()
    End Sub

    Private Sub txtTipoCtaCte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDistancia.KeyPress
        If e.KeyChar = Chr(13) Then

            Buscar_Factura()
            ''' PARA AGREGAR DEVOLUCIONES
        End If
    End Sub

    Private Sub cmb_tipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipos.SelectedIndexChanged
        If Me.cmb_tipos.Text = "ENTREGA EXPRESS" Then

            Dim oform As New frm_entregaExpress
            oform.lsEmpresa = Me.cmbEmpresa.SelectedValue
            oform.lsPiloto = Me.cmb_piloto.SelectedValue
            oform.lsVehiculo = Me.cmb_vehiculo.SelectedValue
            oform.ShowDialog()
            Me.txt_numero.Text = oform.txtNumero.Text
            oform.Dispose()
            oform = Nothing

        End If
    End Sub


    Private Sub dg_controles_pendientes_Navigate(sender As Object, ne As NavigateEventArgs) Handles dg_controles_pendientes.Navigate

    End Sub

    Private Sub txt_numero_TextChanged(sender As Object, e As EventArgs) Handles txt_numero.TextChanged

    End Sub

    Private Sub txtDistancia_TextChanged(sender As Object, e As EventArgs) Handles txtDistancia.TextChanged

    End Sub

    Private Sub cmb_piloto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_piloto.SelectedIndexChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class

