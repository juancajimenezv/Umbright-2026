Public Class frm_usuario
    Inherits System.Windows.Forms.Form
    Dim dt_usuarios As DataTable

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_list_empresa As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_menu As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_opciones As System.Windows.Forms.Button
    Friend WithEvents chk_list_opciones As System.Windows.Forms.CheckedListBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_asignar As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_hacercopia As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_usuario_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chk_administrador As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_area As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_puesto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresaOpcion As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbValidacion As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents cmbRiesgo As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbPasswordless As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_usuario))
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_list_empresa = New System.Windows.Forms.CheckedListBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_usuario_buscar = New System.Windows.Forms.TextBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_puesto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmb_area = New System.Windows.Forms.ComboBox()
        Me.chk_administrador = New System.Windows.Forms.CheckBox()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_asignar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cmbEmpresaOpcion = New System.Windows.Forms.ComboBox()
        Me.cmb_menu = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_opciones = New System.Windows.Forms.Button()
        Me.chk_list_opciones = New System.Windows.Forms.CheckedListBox()
        Me.cmbRiesgo = New System.Windows.Forms.ComboBox()
        Me.cmbValidacion = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_hacercopia = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_nombre_destino = New System.Windows.Forms.TextBox()
        Me.txt_nombre_origen = New System.Windows.Forms.TextBox()
        Me.txt_destino = New System.Windows.Forms.TextBox()
        Me.txt_origen = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbPasswordless = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_usuario
        '
        Me.txt_usuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario.Location = New System.Drawing.Point(68, 8)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(176, 20)
        Me.txt_usuario.TabIndex = 0
        '
        'txt_password
        '
        Me.txt_password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_password.Location = New System.Drawing.Point(68, 32)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(176, 20)
        Me.txt_password.TabIndex = 1
        '
        'txt_nombre
        '
        Me.txt_nombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre.Location = New System.Drawing.Point(68, 55)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(436, 20)
        Me.txt_nombre.TabIndex = 2
        '
        'chk_activo
        '
        Me.chk_activo.Checked = True
        Me.chk_activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_activo.Location = New System.Drawing.Point(429, 8)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(24, 22)
        Me.chk_activo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(314, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Activo"
        '
        'chk_list_empresa
        '
        Me.chk_list_empresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_list_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chk_list_empresa.Location = New System.Drawing.Point(68, 168)
        Me.chk_list_empresa.Name = "chk_list_empresa"
        Me.chk_list_empresa.Size = New System.Drawing.Size(360, 77)
        Me.chk_list_empresa.TabIndex = 8
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.ForeColor = System.Drawing.Color.White
        Me.btn_Aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Aceptar.ImageKey = "Floppy-64.png"
        Me.btn_Aceptar.ImageList = Me.ImageList1
        Me.btn_Aceptar.Location = New System.Drawing.Point(520, 83)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 59)
        Me.btn_Aceptar.TabIndex = 15
        Me.btn_Aceptar.Text = "&Guardar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
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
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Empresa"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(5, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(616, 624)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txt_usuario_buscar)
        Me.TabPage2.Controls.Add(Me.DataGrid1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(608, 598)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Usuarios"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Usuario"
        '
        'txt_usuario_buscar
        '
        Me.txt_usuario_buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario_buscar.Location = New System.Drawing.Point(80, 8)
        Me.txt_usuario_buscar.Name = "txt_usuario_buscar"
        Me.txt_usuario_buscar.Size = New System.Drawing.Size(200, 20)
        Me.txt_usuario_buscar.TabIndex = 1
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 32)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(592, 552)
        Me.DataGrid1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtCelular)
        Me.TabPage1.Controls.Add(Me.txtEmail)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txt_puesto)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.cmb_area)
        Me.TabPage1.Controls.Add(Me.chk_administrador)
        Me.TabPage1.Controls.Add(Me.btn_limpiar)
        Me.TabPage1.Controls.Add(Me.btn_asignar)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.cmbEmpresaOpcion)
        Me.TabPage1.Controls.Add(Me.cmb_menu)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmb_opciones)
        Me.TabPage1.Controls.Add(Me.chk_list_empresa)
        Me.TabPage1.Controls.Add(Me.txt_usuario)
        Me.TabPage1.Controls.Add(Me.txt_password)
        Me.TabPage1.Controls.Add(Me.txt_nombre)
        Me.TabPage1.Controls.Add(Me.chk_activo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.chk_list_opciones)
        Me.TabPage1.Controls.Add(Me.btn_Aceptar)
        Me.TabPage1.Controls.Add(Me.cmbPasswordless)
        Me.TabPage1.Controls.Add(Me.cmbRiesgo)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.cmbValidacion)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.cmb_empresa)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(608, 598)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Informacion"
        '
        'txtCelular
        '
        Me.txtCelular.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.Location = New System.Drawing.Point(357, 77)
        Me.txtCelular.MaxLength = 11
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(147, 20)
        Me.txtCelular.TabIndex = 24
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(68, 77)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(184, 20)
        Me.txtEmail.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(268, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 19)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Celular"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 23)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Email"
        '
        'txt_puesto
        '
        Me.txt_puesto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_puesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_puesto.Location = New System.Drawing.Point(68, 144)
        Me.txt_puesto.Name = "txt_puesto"
        Me.txt_puesto.Size = New System.Drawing.Size(184, 20)
        Me.txt_puesto.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 23)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Puesto"
        '
        'cmb_area
        '
        Me.cmb_area.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_area.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_area.Location = New System.Drawing.Point(68, 120)
        Me.cmb_area.Name = "cmb_area"
        Me.cmb_area.Size = New System.Drawing.Size(184, 21)
        Me.cmb_area.TabIndex = 5
        '
        'chk_administrador
        '
        Me.chk_administrador.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_administrador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_administrador.Location = New System.Drawing.Point(306, 34)
        Me.chk_administrador.Name = "chk_administrador"
        Me.chk_administrador.Size = New System.Drawing.Size(136, 16)
        Me.chk_administrador.TabIndex = 4
        Me.chk_administrador.Text = "Administrador"
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 0
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(520, 16)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(75, 62)
        Me.btn_limpiar.TabIndex = 14
        Me.btn_limpiar.Text = "&Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_asignar
        '
        Me.btn_asignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_asignar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_asignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_asignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_asignar.ForeColor = System.Drawing.Color.White
        Me.btn_asignar.Location = New System.Drawing.Point(520, 249)
        Me.btn_asignar.Name = "btn_asignar"
        Me.btn_asignar.Size = New System.Drawing.Size(75, 23)
        Me.btn_asignar.TabIndex = 13
        Me.btn_asignar.Text = "&Asignar"
        Me.btn_asignar.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 248)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(592, 2)
        Me.ProgressBar1.TabIndex = 16
        '
        'cmbEmpresaOpcion
        '
        Me.cmbEmpresaOpcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEmpresaOpcion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbEmpresaOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresaOpcion.DropDownWidth = 150
        Me.cmbEmpresaOpcion.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbEmpresaOpcion.Location = New System.Drawing.Point(218, 258)
        Me.cmbEmpresaOpcion.Name = "cmbEmpresaOpcion"
        Me.cmbEmpresaOpcion.Size = New System.Drawing.Size(99, 21)
        Me.cmbEmpresaOpcion.TabIndex = 10
        '
        'cmb_menu
        '
        Me.cmb_menu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_menu.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_menu.DropDownWidth = 150
        Me.cmb_menu.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_menu.Location = New System.Drawing.Point(68, 258)
        Me.cmb_menu.Name = "cmb_menu"
        Me.cmb_menu.Size = New System.Drawing.Size(144, 21)
        Me.cmb_menu.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Menu"
        '
        'cmb_opciones
        '
        Me.cmb_opciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_opciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.cmb_opciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_opciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_opciones.ForeColor = System.Drawing.Color.White
        Me.cmb_opciones.Location = New System.Drawing.Point(396, 249)
        Me.cmb_opciones.Name = "cmb_opciones"
        Me.cmb_opciones.Size = New System.Drawing.Size(76, 24)
        Me.cmb_opciones.TabIndex = 12
        Me.cmb_opciones.Text = "&Opciones"
        Me.cmb_opciones.UseVisualStyleBackColor = False
        '
        'chk_list_opciones
        '
        Me.chk_list_opciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_list_opciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chk_list_opciones.Location = New System.Drawing.Point(68, 281)
        Me.chk_list_opciones.Name = "chk_list_opciones"
        Me.chk_list_opciones.Size = New System.Drawing.Size(360, 317)
        Me.chk_list_opciones.TabIndex = 11
        '
        'cmbRiesgo
        '
        Me.cmbRiesgo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRiesgo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbRiesgo.Items.AddRange(New Object() {"BAJO", "MEDIO", "ALTO"})
        Me.cmbRiesgo.Location = New System.Drawing.Point(357, 124)
        Me.cmbRiesgo.Name = "cmbRiesgo"
        Me.cmbRiesgo.Size = New System.Drawing.Size(147, 21)
        Me.cmbRiesgo.TabIndex = 5
        '
        'cmbValidacion
        '
        Me.cmbValidacion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbValidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValidacion.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbValidacion.Items.AddRange(New Object() {"SMS", "TEAMS"})
        Me.cmbValidacion.Location = New System.Drawing.Point(357, 101)
        Me.cmbValidacion.Name = "cmbValidacion"
        Me.cmbValidacion.Size = New System.Drawing.Size(147, 21)
        Me.cmbValidacion.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(268, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 15)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Riesgo"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_empresa.Location = New System.Drawing.Point(68, 98)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(184, 21)
        Me.cmb_empresa.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(268, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 15)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Validación"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Area"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Empresa"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.btn_hacercopia)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.txt_nombre_destino)
        Me.TabPage3.Controls.Add(Me.txt_nombre_origen)
        Me.TabPage3.Controls.Add(Me.txt_destino)
        Me.TabPage3.Controls.Add(Me.txt_origen)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(608, 598)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Copiar"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(184, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 23)
        Me.Button2.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(184, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 23)
        Me.Button1.TabIndex = 7
        '
        'btn_hacercopia
        '
        Me.btn_hacercopia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_hacercopia.Location = New System.Drawing.Point(176, 144)
        Me.btn_hacercopia.Name = "btn_hacercopia"
        Me.btn_hacercopia.Size = New System.Drawing.Size(128, 24)
        Me.btn_hacercopia.TabIndex = 6
        Me.btn_hacercopia.Text = "&Copiar"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Destino"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Origen"
        '
        'txt_nombre_destino
        '
        Me.txt_nombre_destino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombre_destino.Enabled = False
        Me.txt_nombre_destino.Location = New System.Drawing.Point(216, 77)
        Me.txt_nombre_destino.Name = "txt_nombre_destino"
        Me.txt_nombre_destino.ReadOnly = True
        Me.txt_nombre_destino.Size = New System.Drawing.Size(368, 20)
        Me.txt_nombre_destino.TabIndex = 3
        Me.txt_nombre_destino.TabStop = False
        '
        'txt_nombre_origen
        '
        Me.txt_nombre_origen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombre_origen.Enabled = False
        Me.txt_nombre_origen.Location = New System.Drawing.Point(216, 32)
        Me.txt_nombre_origen.Name = "txt_nombre_origen"
        Me.txt_nombre_origen.ReadOnly = True
        Me.txt_nombre_origen.Size = New System.Drawing.Size(368, 20)
        Me.txt_nombre_origen.TabIndex = 2
        Me.txt_nombre_origen.TabStop = False
        '
        'txt_destino
        '
        Me.txt_destino.Location = New System.Drawing.Point(88, 77)
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.Size = New System.Drawing.Size(88, 20)
        Me.txt_destino.TabIndex = 1
        '
        'txt_origen
        '
        Me.txt_origen.Location = New System.Drawing.Point(88, 32)
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.Size = New System.Drawing.Size(88, 20)
        Me.txt_origen.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(268, 145)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 15)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Passwordless"
        '
        'cmbPasswordless
        '
        Me.cmbPasswordless.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbPasswordless.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPasswordless.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbPasswordless.Items.AddRange(New Object() {"SI", "NO"})
        Me.cmbPasswordless.Location = New System.Drawing.Point(357, 146)
        Me.cmbPasswordless.Name = "cmbPasswordless"
        Me.cmbPasswordless.Size = New System.Drawing.Size(147, 21)
        Me.cmbPasswordless.TabIndex = 5
        '
        'frm_usuario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 629)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento de Usuarios"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frm_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        LlenarGrid()
    End Sub

    Private Sub LlenarGrid()
        Dim ldt_table As New DataTable

        Dim clGen As New ClasesGenerales.General
        Dim otransaccion As New Transaccional.Conexion("flexline")
        otransaccion.open()

        dt_usuarios = otransaccion.Obtiene("pa_sel_um_sg_usuario_todos")
        otransaccion.close()

        Me.DataGrid1.DataSource = dt_usuarios

        clGen.Alinea_Grid(dt_usuarios, Me.DataGrid1, dt_usuarios.TableName, -1, 200, 50, False, True, ",usuario,nombre,ubicacion,estatus,puesto,empresa,cuenta_office,telefono,metodo_validacion,nivel_riesgo,passwordless,", True, "")

        clGen = Nothing
        otransaccion = Nothing
    End Sub

    Private Sub LlenarCombo()

        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim dt, dt2 As DataTable
        Dim ls_SqlScript As String
        Dim otransaccion As Transaccional.Conexion

        otransaccion = New Transaccional.Conexion("flexline")
        otransaccion.open()

        ls_SqlScript = "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'"
        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "empresas"
        l_Dataset.Tables.Add(ldt_table.Copy)

        dt = ldt_table.Copy
        Me.cmb_empresa.DataSource = dt
        Me.cmb_empresa.ValueMember = "EMPRESA"
        Me.cmb_empresa.DisplayMember = "EMPRESA"

        dt2 = ldt_table.Copy
        Me.cmbEmpresaOpcion.DataSource = dt2
        Me.cmbEmpresaOpcion.ValueMember = "EMPRESA"
        Me.cmbEmpresaOpcion.DisplayMember = "EMPRESA"

        Me.chk_list_empresa.DataSource = ldt_table
        Me.chk_list_empresa.ValueMember = "EMPRESA"

        ls_SqlScript = "pa_sel_um_sg_menu"
        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "menu_principal"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cmb_menu.DisplayMember = "menu"
        Me.cmb_menu.ValueMember = "cod_menu"
        Me.cmb_menu.DataSource = ldt_table

        ls_SqlScript = "pa_sel_um_gen_tabcod null,'GEN_UBICACION'"
        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "ubicacion"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cmb_area.DisplayMember = "CODIGO"
        Me.cmb_area.ValueMember = "CODIGO"
        Me.cmb_area.DataSource = ldt_table

        otransaccion.close()
        otransaccion = Nothing
    End Sub

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Dim Oseg As New Seguridad.Usuario("sql", "FlexLine")
        'Dim myOseg As New Seguridad.Usuario("mysql", "Onbase")

        If Oseg.existe_usuario(Me.txt_usuario.Text.Trim) Then
            If MessageBox.Show("Desea Modificar la Informacion del Usuario", "Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Cambiar Password
                If Me.txt_password.Text.Length > 0 Then
                    If MessageBox.Show("Esta Seguro de Cambiar El PassWord", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        If Oseg.actualiza_usuario(Me.txt_usuario.Text, Me.txt_password.Text, "NULL", True, gs_usuario, Me.txtEmail.Text.ToString) Then
                            'myOseg.actualiza_usuario(Me.txt_usuario.Text, Me.txt_password.Text, "NULL", Me.chk_activo.Checked, gs_usuario, Me.txtEmail.Text.ToString)
                            MessageBox.Show("Cambio Realizado con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If

                Oseg.actualiza_usuario_simple(Me.txt_usuario.Text, Me.txt_password.Text, Me.txt_nombre.Text, Me.chk_activo.CheckState, Me.cmb_area.Text, Me.txt_puesto.Text, Me.cmb_empresa.Text, gs_usuario, Me.txtEmail.Text.ToString, Me.txtCelular.Text, Me.cmbValidacion.SelectedItem, cmbRiesgo.SelectedItem, cmbPasswordless.SelectedItem)
                Registrar_Empresa()
            End If

        Else
            If Oseg.registra_usuario(Me.txt_usuario.Text, Me.txt_password.Text, Me.txt_nombre.Text, Me.chk_activo.Checked, Me.chk_administrador.Checked, Me.cmb_area.Text, Me.txt_puesto.Text, gs_usuario, Me.txtEmail.Text.ToString, Me.txtCelular.Text, Me.cmbValidacion.SelectedItem, cmbRiesgo.SelectedItem, cmbPasswordless.SelectedItem) Then
                Registrar_Empresa()
            End If
            'If MessageBox.Show("Desea Crear El Usuario Para CRM ", "Seguridad CRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


        End If
        Oseg = Nothing
        Me.LlenarGrid()

        'Dim otrans As New Transaccional.Conexion_mysql("onBase")

        'Dim ls_sql As String

        'Try
        '    otrans.open()

        '    ls_sql = "call pa_ins_um_seg_usuario    ('" & Me.txt_usuario.Text & "',NULL,'" &
        '            Me.txt_nombre.Text & "','" & Me.txt_puesto.Text & "','',''," &
        '            IIf(Me.chk_activo.Checked = True, 1, 0) & "," &
        '            "0" & "," &
        '            "3" & ",'" & Me.cmb_area.Text & "','" & Me.cmb_empresa.Text & "')"

        '    otrans.Ingresa(ls_sql)
        '    If otrans.Codigo_error > 0 Then
        '        ls_sql = "call pa_upd_um_sg_usuario    ('" & Me.txt_usuario.Text & "',NULL,'" &
        '                Me.txt_nombre.Text & "','" & Me.txt_puesto.Text & "'," &
        '                "NULL,NULL," &
        '                IIf(Me.chk_activo.Checked = True, 1, 0) & "," &
        '                "NULL" & "," &
        '                "NULL" & ",'" & Me.cmb_area.Text & "','" & Me.cmb_empresa.Text & "')"
        '        otrans.Actualiza(ls_sql)
        '    End If

        'Catch ex As Exception

        'Finally
        '    otrans.close()
        '    otrans = Nothing
        'End Try
    End Sub

    Private Sub Registrar_Empresa()
        Dim i As Integer
        Dim li_resultado As Integer
        Dim ls_SqlString As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        Try
            oTrans.open()
            ' Limpio la Informacion de la empresa
            ls_SqlString = "pa_del_um_sg_usuario_empresa '" & Me.txt_usuario.Text & "'"
            li_resultado = oTrans.Elimina(ls_SqlString)

            If oTrans.Codigo_error = 0 Then
                For i = 0 To Me.chk_list_empresa.Items.Count() - 1
                    If Me.chk_list_empresa.GetItemChecked(i) Then
                        'Dar de alta una empresa
                        ls_SqlString = "pa_ins_um_sg_usuario_empresa '" & Me.txt_usuario.Text & "','" & Me.chk_list_empresa.Items(i)("EMPRESA") & "'"
                        li_resultado = oTrans.Ingresa(ls_SqlString)
                    End If
                Next
            End If
            MessageBox.Show("Informacion Actualizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Try
            Me.txt_usuario.Text = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 0)
            Me.txt_nombre.Text = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 1)
            Me.chk_activo.Checked = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 3)
            Me.cmb_area.SelectedValue = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 2).ToString
            Me.txt_puesto.Text = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 4).ToString
            Me.cmb_empresa.SelectedValue = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 5).ToString
            Me.txtEmail.Text = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 6).ToString
            Me.txtCelular.Text = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 7).ToString
            Me.cmbValidacion.SelectedItem = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 8).ToString
            Me.cmbRiesgo.SelectedItem = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 9).ToString
            Me.cmbPasswordless.SelectedItem = Me.DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 10).ToString
        Catch ex As Exception

        End Try
        Me.TabControl1.SelectedTab = Me.TabPage1

        Empresa_Usuario()
        opciones_usuario()

    End Sub

    Private Sub Empresa_Usuario()
        Dim ls_SqlString As String
        Dim i As Integer
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim otabla As DataTable


        Try
            oTrans.open()
            For i = 0 To Me.chk_list_empresa.Items.Count() - 1
                Me.chk_list_empresa.SetItemChecked(i, False)
            Next

            ls_SqlString = "pa_sel_um_sg_usuario_empresa '" & Me.txt_usuario.Text & "'"
            otabla = oTrans.Obtiene(ls_SqlString)
            Try
                If otabla.Rows.Count() > 0 Then
                    For i = 0 To Me.chk_list_empresa.Items.Count() - 1
                        otabla.DefaultView.RowFilter = "empresa = '" & Me.chk_list_empresa.Items(i)("EMPRESA") & "'"
                        If otabla.DefaultView.Count > 0 Then
                            Me.chk_list_empresa.SetItemChecked(i, True)
                        End If
                    Next
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing

        End Try

    End Sub

    Private Sub opciones_usuario()
        Dim ls_SqlString As String
        Dim i As Integer
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim otabla As DataTable

        ls_SqlString = "pa_sel_um_sg_menu_opcion '" & Me.cmb_menu.SelectedValue & "'"
        oTrans.open()
        otabla = oTrans.Obtiene(ls_SqlString)

        Me.chk_list_opciones.DataSource = Nothing
        Me.chk_list_opciones.DataSource = otabla
        Me.chk_list_opciones.ValueMember = Nothing
        Me.chk_list_opciones.ValueMember = "opcion"
        'Me.chk_list_opciones.
        Me.chk_list_opciones.Refresh()


        ' Me.chk_list_opciones.

        ls_SqlString = "pa_sel_um_sg_usuario_menu_opcion_empresa " & Me.cmb_menu.SelectedValue & ",'" & Me.txt_usuario.Text & "',NULL,'" & Me.cmbEmpresaOpcion.SelectedValue & "'"
        otabla = oTrans.Obtiene(ls_SqlString)

        If otabla.Rows.Count > 0 Then
            For i = 0 To Me.chk_list_opciones.Items.Count() - 1
                otabla.DefaultView.RowFilter = "cod_opcion = '" & Me.chk_list_opciones.Items(i)("cod_opcion") & "'"
                If otabla.DefaultView.Count > 0 Then
                    Me.chk_list_opciones.SetItemChecked(i, True)
                End If
            Next
        End If

        oTrans.close()
        oTrans = Nothing
    End Sub
    Private Sub cmb_opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_opciones.Click
        opciones_usuario()
    End Sub

    Private Sub btn_asignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_asignar.Click
        Dim i, li_resultado As Integer
        Dim ls_sqlstring As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        oTrans.open()
        Try
            ' Limpio la Informacion de la empresa
            ls_sqlstring = "pa_del_um_sg_usuario_menu_opcion_empresa '" & Me.txt_usuario.Text & "'," & Me.cmb_menu.SelectedValue & ",'" & Me.cmbEmpresaOpcion.SelectedValue & "','" & gs_usuario & "'"
            li_resultado = oTrans.Elimina(ls_sqlstring)

            If oTrans.Codigo_error = 0 Then
                For i = 0 To Me.chk_list_opciones.Items.Count() - 1
                    If Me.chk_list_opciones.GetItemChecked(i) Then
                        'Dar de alta una empresa
                        ls_sqlstring = "pa_ins_um_sg_usuario_menu_opcion_empresa '" & Me.txt_usuario.Text & "'," & Me.chk_list_opciones.Items(i)("cod_opcion") & ",'" & Me.cmbEmpresaOpcion.SelectedValue & "','" & gs_usuario & "'"
                        li_resultado = oTrans.Ingresa(ls_sqlstring)
                    End If
                Next
            End If

            MessageBox.Show("Asignacion Exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Me.TabControl1.SelectedTab = TabPage2
        Me.TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.procedimiento_almacenado = "pa_sel_um_sg_usuario_todos"
        frm_busqueda.ShowDialog(Me)

        Me.txt_origen.Text = frm_busqueda.resultado
        frm_busqueda = Nothing

        If Me.txt_origen.Text.Length > 0 Then
            Me.txt_nombre_origen.Text = Buscar_usuario(Me.txt_origen.Text)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.procedimiento_almacenado = "pa_sel_um_sg_usuario_todos"
        frm_busqueda.ShowDialog(Me)

        Me.txt_destino.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        If Me.txt_destino.Text.Length > 0 Then
            Me.txt_nombre_destino.Text = Buscar_usuario(Me.txt_destino.Text)
        End If
    End Sub

    Private Function Buscar_usuario(ByVal nombre_usuario As String) As String

        Dim ldt_table As New DataTable
        Dim ReturnValue As String = " "
        Dim otransaccion As New Transaccional.Conexion("flexline")

        otransaccion.open()
        Try
            ldt_table = otransaccion.Obtiene("pa_sel_um_sg_usuario_todos '" & nombre_usuario & "'")
            ldt_table.TableName = "usuarios"
            otransaccion.close()
            ReturnValue = ldt_table.Rows(0)("nombre")
        Catch ex As Exception

        End Try

        ldt_table = Nothing
        otransaccion = Nothing
        Return ReturnValue

    End Function

    Private Sub btn_hacercopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hacercopia.Click
        Dim ls_sqltxt As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        If Me.txt_origen.Text.ToLower.Trim.Equals(Me.txt_destino.Text.Trim.ToLower) Then
            MessageBox.Show("No Puede Hacer Copia del Mismo Usuario", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            If MessageBox.Show("Este Proceso Hara una Copia Exacta del Origen, Esta Seguro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ls_sqltxt = "pa_var_um_copiar_usuario '" & Me.txt_origen.Text & "','" & Me.txt_destino.Text & "'"
                oTrans.open()
                oTrans.Elimina(ls_sqltxt)
                If oTrans.Codigo_error = 0 Then
                    MessageBox.Show("Se Realizo la Copia, Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(oTrans.descripcion_error)
                End If
                oTrans.close()
            End If
        End If
        oTrans = Nothing
    End Sub

    Private Sub txt_origen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_origen.LostFocus
        If Me.txt_origen.Text.Length > 0 Then
            Me.txt_nombre_origen.Text = Buscar_usuario(Me.txt_origen.Text)
        End If
    End Sub

    Private Sub txt_destino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_destino.LostFocus
        If Me.txt_destino.Text.Length > 0 Then
            Me.txt_nombre_destino.Text = Buscar_usuario(Me.txt_destino.Text)
        End If
    End Sub

    Private Sub hacer_filtro()
        Dim ls_filtro As String

        ls_filtro = "usuario like '%" & Me.txt_usuario_buscar.Text & "%'"

        Try
            dt_usuarios.DefaultView.RowFilter = ls_filtro
            '    odataset.Tables("reportes").DefaultView.RowFilter = ls_filtro
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_usuario_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_usuario_buscar.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub DataGrid1_ParentChanged(sender As Object, e As EventArgs) Handles DataGrid1.ParentChanged

    End Sub

    Private Sub DataGrid1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGrid1.PreviewKeyDown

    End Sub
End Class
