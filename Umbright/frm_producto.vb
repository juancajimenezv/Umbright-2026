Imports System.IO
Public Class frm_producto
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_validar As System.Windows.Forms.Button
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txt_filtro2 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_valor2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_filtro1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmb_operadolog_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_filtro3 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_valor3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operadolog_2 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_existencia As System.Windows.Forms.Button
    Friend WithEvents btn_precios As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ofd_ruta_imagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pb_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents chk_mostrar_web As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_registro_sanitario As System.Windows.Forms.TextBox
    Friend WithEvents dtp_vencimiento_registro_sanitario As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_estado As System.Windows.Forms.Label
    Friend WithEvents lbl_estado_registro_sanitario As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegistroSanitarios As System.Windows.Forms.Button
    Friend WithEvents btnPesoVolumen As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnTodos As Button
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtSubtipo As TextBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents txtFamilia As TextBox
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_procedencia As TextBox
    Friend WithEvents txtvolumenML As TextBox
    Friend WithEvents txtCepa As TextBox
    Friend WithEvents txtBU As TextBox
    Friend WithEvents lblpathRegistro As Label
    Friend WithEvents txt_codbarra As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBU = New System.Windows.Forms.TextBox()
        Me.txtCepa = New System.Windows.Forms.TextBox()
        Me.txtFamilia = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txt_procedencia = New System.Windows.Forms.TextBox()
        Me.txtSubtipo = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.btnPesoVolumen = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnRegistroSanitarios = New System.Windows.Forms.Button()
        Me.txtvolumenML = New System.Windows.Forms.TextBox()
        Me.txt_codbarra = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_estado = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_estado_registro_sanitario = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtp_vencimiento_registro_sanitario = New System.Windows.Forms.DateTimePicker()
        Me.txt_registro_sanitario = New System.Windows.Forms.TextBox()
        Me.chk_mostrar_web = New System.Windows.Forms.CheckBox()
        Me.pb_imagen = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_existencia = New System.Windows.Forms.Button()
        Me.btn_precios = New System.Windows.Forms.Button()
        Me.btn_validar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.txt_cod_producto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv_productos = New System.Windows.Forms.DataGridView()
        Me.cmb_operadolog_2 = New System.Windows.Forms.ComboBox()
        Me.txt_filtro3 = New System.Windows.Forms.TextBox()
        Me.cmb_valor3 = New System.Windows.Forms.ComboBox()
        Me.cmb_3 = New System.Windows.Forms.ComboBox()
        Me.cmb_operadolog_1 = New System.Windows.Forms.ComboBox()
        Me.txt_filtro2 = New System.Windows.Forms.TextBox()
        Me.cmb_valor2 = New System.Windows.Forms.ComboBox()
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox()
        Me.cmb_2 = New System.Windows.Forms.ComboBox()
        Me.cmb_1 = New System.Windows.Forms.ComboBox()
        Me.txt_filtro1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.ofd_ruta_imagen = New System.Windows.Forms.OpenFileDialog()
        Me.lblpathRegistro = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(728, 496)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtBU)
        Me.TabPage1.Controls.Add(Me.txtCepa)
        Me.TabPage1.Controls.Add(Me.txtFamilia)
        Me.TabPage1.Controls.Add(Me.txtTipo)
        Me.TabPage1.Controls.Add(Me.txtProveedor)
        Me.TabPage1.Controls.Add(Me.txt_procedencia)
        Me.TabPage1.Controls.Add(Me.txtSubtipo)
        Me.TabPage1.Controls.Add(Me.txtMarca)
        Me.TabPage1.Controls.Add(Me.btnPesoVolumen)
        Me.TabPage1.Controls.Add(Me.btnRegistroSanitarios)
        Me.TabPage1.Controls.Add(Me.txtvolumenML)
        Me.TabPage1.Controls.Add(Me.txt_codbarra)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.lbl_estado)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.chk_mostrar_web)
        Me.TabPage1.Controls.Add(Me.pb_imagen)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.btn_existencia)
        Me.TabPage1.Controls.Add(Me.btn_precios)
        Me.TabPage1.Controls.Add(Me.btn_validar)
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.StatusBar1)
        Me.TabPage1.Controls.Add(Me.txt_descripcion)
        Me.TabPage1.Controls.Add(Me.txt_nombre)
        Me.TabPage1.Controls.Add(Me.cmb_empresa)
        Me.TabPage1.Controls.Add(Me.txt_cod_producto)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(720, 470)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle Producto"
        '
        'txtBU
        '
        Me.txtBU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBU.Location = New System.Drawing.Point(136, 311)
        Me.txtBU.Name = "txtBU"
        Me.txtBU.ReadOnly = True
        Me.txtBU.Size = New System.Drawing.Size(184, 21)
        Me.txtBU.TabIndex = 40
        '
        'txtCepa
        '
        Me.txtCepa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCepa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCepa.Location = New System.Drawing.Point(137, 287)
        Me.txtCepa.Name = "txtCepa"
        Me.txtCepa.ReadOnly = True
        Me.txtCepa.Size = New System.Drawing.Size(184, 21)
        Me.txtCepa.TabIndex = 39
        '
        'txtFamilia
        '
        Me.txtFamilia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFamilia.Location = New System.Drawing.Point(136, 170)
        Me.txtFamilia.Name = "txtFamilia"
        Me.txtFamilia.ReadOnly = True
        Me.txtFamilia.Size = New System.Drawing.Size(185, 21)
        Me.txtFamilia.TabIndex = 38
        '
        'txtTipo
        '
        Me.txtTipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipo.Location = New System.Drawing.Point(136, 145)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(185, 21)
        Me.txtTipo.TabIndex = 37
        '
        'txtProveedor
        '
        Me.txtProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Location = New System.Drawing.Point(136, 190)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(185, 21)
        Me.txtProveedor.TabIndex = 36
        '
        'txt_procedencia
        '
        Me.txt_procedencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_procedencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_procedencia.Location = New System.Drawing.Point(137, 262)
        Me.txt_procedencia.Name = "txt_procedencia"
        Me.txt_procedencia.ReadOnly = True
        Me.txt_procedencia.Size = New System.Drawing.Size(184, 21)
        Me.txt_procedencia.TabIndex = 35
        '
        'txtSubtipo
        '
        Me.txtSubtipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubtipo.Location = New System.Drawing.Point(137, 237)
        Me.txtSubtipo.Name = "txtSubtipo"
        Me.txtSubtipo.ReadOnly = True
        Me.txtSubtipo.Size = New System.Drawing.Size(184, 21)
        Me.txtSubtipo.TabIndex = 35
        '
        'txtMarca
        '
        Me.txtMarca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarca.Location = New System.Drawing.Point(136, 214)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(185, 21)
        Me.txtMarca.TabIndex = 34
        '
        'btnPesoVolumen
        '
        Me.btnPesoVolumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnPesoVolumen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPesoVolumen.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesoVolumen.ForeColor = System.Drawing.Color.White
        Me.btnPesoVolumen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPesoVolumen.ImageIndex = 0
        Me.btnPesoVolumen.ImageList = Me.ImageList1
        Me.btnPesoVolumen.Location = New System.Drawing.Point(232, 0)
        Me.btnPesoVolumen.Name = "btnPesoVolumen"
        Me.btnPesoVolumen.Size = New System.Drawing.Size(89, 64)
        Me.btnPesoVolumen.TabIndex = 33
        Me.btnPesoVolumen.Text = "Peso/Volumen"
        Me.btnPesoVolumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPesoVolumen.UseVisualStyleBackColor = False
        Me.btnPesoVolumen.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "calculator.ico")
        Me.ImageList1.Images.SetKeyName(1, "paper_content_pencil_48.png")
        '
        'btnRegistroSanitarios
        '
        Me.btnRegistroSanitarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRegistroSanitarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegistroSanitarios.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistroSanitarios.ForeColor = System.Drawing.Color.White
        Me.btnRegistroSanitarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRegistroSanitarios.ImageIndex = 1
        Me.btnRegistroSanitarios.ImageList = Me.ImageList1
        Me.btnRegistroSanitarios.Location = New System.Drawing.Point(143, 0)
        Me.btnRegistroSanitarios.Name = "btnRegistroSanitarios"
        Me.btnRegistroSanitarios.Size = New System.Drawing.Size(89, 64)
        Me.btnRegistroSanitarios.TabIndex = 33
        Me.btnRegistroSanitarios.Text = "Reg Sanitario"
        Me.btnRegistroSanitarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRegistroSanitarios.UseVisualStyleBackColor = False
        Me.btnRegistroSanitarios.Visible = False
        '
        'txtvolumenML
        '
        Me.txtvolumenML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtvolumenML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvolumenML.Location = New System.Drawing.Point(440, 264)
        Me.txtvolumenML.Name = "txtvolumenML"
        Me.txtvolumenML.ReadOnly = True
        Me.txtvolumenML.Size = New System.Drawing.Size(120, 21)
        Me.txtvolumenML.TabIndex = 32
        '
        'txt_codbarra
        '
        Me.txt_codbarra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_codbarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codbarra.Location = New System.Drawing.Point(440, 240)
        Me.txt_codbarra.Name = "txt_codbarra"
        Me.txt_codbarra.ReadOnly = True
        Me.txt_codbarra.Size = New System.Drawing.Size(120, 21)
        Me.txt_codbarra.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(352, 267)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 18)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Volumen ML"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(352, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Barra"
        '
        'lbl_estado
        '
        Me.lbl_estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_estado.AutoSize = True
        Me.lbl_estado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado.Location = New System.Drawing.Point(296, 96)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(0, 13)
        Me.lbl_estado.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblpathRegistro)
        Me.GroupBox1.Controls.Add(Me.lbl_estado_registro_sanitario)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.dtp_vencimiento_registro_sanitario)
        Me.GroupBox1.Controls.Add(Me.txt_registro_sanitario)
        Me.GroupBox1.Location = New System.Drawing.Point(344, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 80)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro Sanitario"
        '
        'lbl_estado_registro_sanitario
        '
        Me.lbl_estado_registro_sanitario.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_estado_registro_sanitario.Location = New System.Drawing.Point(187, 50)
        Me.lbl_estado_registro_sanitario.Name = "lbl_estado_registro_sanitario"
        Me.lbl_estado_registro_sanitario.Size = New System.Drawing.Size(24, 16)
        Me.lbl_estado_registro_sanitario.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 23)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Vecimiento"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Registro"
        '
        'dtp_vencimiento_registro_sanitario
        '
        Me.dtp_vencimiento_registro_sanitario.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_vencimiento_registro_sanitario.Location = New System.Drawing.Point(94, 48)
        Me.dtp_vencimiento_registro_sanitario.Name = "dtp_vencimiento_registro_sanitario"
        Me.dtp_vencimiento_registro_sanitario.Size = New System.Drawing.Size(88, 21)
        Me.dtp_vencimiento_registro_sanitario.TabIndex = 1
        '
        'txt_registro_sanitario
        '
        Me.txt_registro_sanitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_registro_sanitario.Location = New System.Drawing.Point(94, 24)
        Me.txt_registro_sanitario.Name = "txt_registro_sanitario"
        Me.txt_registro_sanitario.Size = New System.Drawing.Size(88, 21)
        Me.txt_registro_sanitario.TabIndex = 0
        '
        'chk_mostrar_web
        '
        Me.chk_mostrar_web.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_mostrar_web.Location = New System.Drawing.Point(595, 283)
        Me.chk_mostrar_web.Name = "chk_mostrar_web"
        Me.chk_mostrar_web.Size = New System.Drawing.Size(104, 24)
        Me.chk_mostrar_web.TabIndex = 28
        Me.chk_mostrar_web.Text = "Mostra Web"
        '
        'pb_imagen
        '
        Me.pb_imagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_imagen.Location = New System.Drawing.Point(600, 40)
        Me.pb_imagen.Name = "pb_imagen"
        Me.pb_imagen.Size = New System.Drawing.Size(100, 238)
        Me.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_imagen.TabIndex = 27
        Me.pb_imagen.TabStop = False
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 314)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 23)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Unidad de Negocio *"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 288)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Cepa  Estilo"
        '
        'btn_existencia
        '
        Me.btn_existencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_existencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_existencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_existencia.ForeColor = System.Drawing.Color.White
        Me.btn_existencia.Image = CType(resources.GetObject("btn_existencia.Image"), System.Drawing.Image)
        Me.btn_existencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_existencia.Location = New System.Drawing.Point(71, 0)
        Me.btn_existencia.Name = "btn_existencia"
        Me.btn_existencia.Size = New System.Drawing.Size(72, 64)
        Me.btn_existencia.TabIndex = 24
        Me.btn_existencia.Text = "Existencia"
        Me.btn_existencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_existencia.UseVisualStyleBackColor = False
        Me.btn_existencia.Visible = False
        '
        'btn_precios
        '
        Me.btn_precios.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_precios.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_precios.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_precios.ForeColor = System.Drawing.Color.White
        Me.btn_precios.Image = CType(resources.GetObject("btn_precios.Image"), System.Drawing.Image)
        Me.btn_precios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_precios.Location = New System.Drawing.Point(0, 0)
        Me.btn_precios.Name = "btn_precios"
        Me.btn_precios.Size = New System.Drawing.Size(72, 64)
        Me.btn_precios.TabIndex = 23
        Me.btn_precios.Text = "Precios"
        Me.btn_precios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_precios.UseVisualStyleBackColor = False
        Me.btn_precios.Visible = False
        '
        'btn_validar
        '
        Me.btn_validar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_validar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_validar.Location = New System.Drawing.Point(262, 96)
        Me.btn_validar.Name = "btn_validar"
        Me.btn_validar.Size = New System.Drawing.Size(24, 23)
        Me.btn_validar.TabIndex = 22
        Me.btn_validar.Text = "..."
        Me.btn_validar.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Location = New System.Drawing.Point(640, 5)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 21
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.Visible = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 452)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(720, 18)
        Me.StatusBar1.TabIndex = 20
        Me.StatusBar1.Visible = False
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 351
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Text = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 351
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(136, 334)
        Me.txt_descripcion.Multiline = True
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_descripcion.Size = New System.Drawing.Size(552, 114)
        Me.txt_descripcion.TabIndex = 19
        '
        'txt_nombre
        '
        Me.txt_nombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre.Location = New System.Drawing.Point(136, 120)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.ReadOnly = True
        Me.txt_nombre.Size = New System.Drawing.Size(424, 21)
        Me.txt_nombre.TabIndex = 12
        '
        'cmb_empresa
        '
        Me.cmb_empresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_empresa.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.Enabled = False
        Me.cmb_empresa.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_empresa.Location = New System.Drawing.Point(136, 72)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(121, 21)
        Me.cmb_empresa.TabIndex = 11
        '
        'txt_cod_producto
        '
        Me.txt_cod_producto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cod_producto.BackColor = System.Drawing.Color.White
        Me.txt_cod_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_producto.Location = New System.Drawing.Point(136, 96)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.ReadOnly = True
        Me.txt_cod_producto.Size = New System.Drawing.Size(120, 21)
        Me.txt_cod_producto.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Generalidades *"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Empresa"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Codigo Flex"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nombre Producto"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Procedencia"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "sub tipo"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Familia"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgv_productos)
        Me.TabPage2.Controls.Add(Me.cmb_operadolog_2)
        Me.TabPage2.Controls.Add(Me.txt_filtro3)
        Me.TabPage2.Controls.Add(Me.cmb_valor3)
        Me.TabPage2.Controls.Add(Me.cmb_3)
        Me.TabPage2.Controls.Add(Me.cmb_operadolog_1)
        Me.TabPage2.Controls.Add(Me.txt_filtro2)
        Me.TabPage2.Controls.Add(Me.cmb_valor2)
        Me.TabPage2.Controls.Add(Me.cmb_valor1)
        Me.TabPage2.Controls.Add(Me.cmb_2)
        Me.TabPage2.Controls.Add(Me.cmb_1)
        Me.TabPage2.Controls.Add(Me.txt_filtro1)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.btnTodos)
        Me.TabPage2.Controls.Add(Me.btn_nuevo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(720, 470)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado de Productos"
        '
        'dgv_productos
        '
        Me.dgv_productos.AllowUserToAddRows = False
        Me.dgv_productos.AllowUserToDeleteRows = False
        Me.dgv_productos.AllowUserToOrderColumns = True
        Me.dgv_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos.Location = New System.Drawing.Point(3, 92)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.ReadOnly = True
        Me.dgv_productos.RowHeadersWidth = 25
        Me.dgv_productos.Size = New System.Drawing.Size(712, 375)
        Me.dgv_productos.TabIndex = 21
        '
        'cmb_operadolog_2
        '
        Me.cmb_operadolog_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_operadolog_2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_operadolog_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadolog_2.DropDownWidth = 50
        Me.cmb_operadolog_2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_operadolog_2.Location = New System.Drawing.Point(536, 32)
        Me.cmb_operadolog_2.Name = "cmb_operadolog_2"
        Me.cmb_operadolog_2.Size = New System.Drawing.Size(56, 21)
        Me.cmb_operadolog_2.TabIndex = 12
        '
        'txt_filtro3
        '
        Me.txt_filtro3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_filtro3.Location = New System.Drawing.Point(192, 56)
        Me.txt_filtro3.Name = "txt_filtro3"
        Me.txt_filtro3.Size = New System.Drawing.Size(334, 21)
        Me.txt_filtro3.TabIndex = 2
        '
        'cmb_valor3
        '
        Me.cmb_valor3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor3.DropDownWidth = 150
        Me.cmb_valor3.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor3.Location = New System.Drawing.Point(48, 56)
        Me.cmb_valor3.Name = "cmb_valor3"
        Me.cmb_valor3.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor3.Sorted = True
        Me.cmb_valor3.TabIndex = 13
        '
        'cmb_3
        '
        Me.cmb_3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_3.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_3.Location = New System.Drawing.Point(152, 56)
        Me.cmb_3.Name = "cmb_3"
        Me.cmb_3.Size = New System.Drawing.Size(40, 21)
        Me.cmb_3.TabIndex = 1
        '
        'cmb_operadolog_1
        '
        Me.cmb_operadolog_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_operadolog_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_operadolog_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadolog_1.DropDownWidth = 50
        Me.cmb_operadolog_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_operadolog_1.Location = New System.Drawing.Point(536, 8)
        Me.cmb_operadolog_1.Name = "cmb_operadolog_1"
        Me.cmb_operadolog_1.Size = New System.Drawing.Size(56, 21)
        Me.cmb_operadolog_1.TabIndex = 8
        '
        'txt_filtro2
        '
        Me.txt_filtro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_filtro2.Location = New System.Drawing.Point(192, 32)
        Me.txt_filtro2.Name = "txt_filtro2"
        Me.txt_filtro2.Size = New System.Drawing.Size(334, 21)
        Me.txt_filtro2.TabIndex = 11
        '
        'cmb_valor2
        '
        Me.cmb_valor2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor2.DropDownWidth = 150
        Me.cmb_valor2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor2.Location = New System.Drawing.Point(48, 32)
        Me.cmb_valor2.Name = "cmb_valor2"
        Me.cmb_valor2.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor2.Sorted = True
        Me.cmb_valor2.TabIndex = 9
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(48, 8)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor1.Sorted = True
        Me.cmb_valor1.TabIndex = 3
        '
        'cmb_2
        '
        Me.cmb_2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_2.Location = New System.Drawing.Point(152, 32)
        Me.cmb_2.Name = "cmb_2"
        Me.cmb_2.Size = New System.Drawing.Size(40, 21)
        Me.cmb_2.TabIndex = 10
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(152, 8)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(40, 21)
        Me.cmb_1.TabIndex = 4
        '
        'txt_filtro1
        '
        Me.txt_filtro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_filtro1.Location = New System.Drawing.Point(192, 8)
        Me.txt_filtro1.Name = "txt_filtro1"
        Me.txt_filtro1.Size = New System.Drawing.Size(334, 21)
        Me.txt_filtro1.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 16)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Filtrar"
        '
        'btnTodos
        '
        Me.btnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTodos.Location = New System.Drawing.Point(640, 33)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 3
        Me.btnTodos.Text = "Todos"
        Me.btnTodos.Visible = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Location = New System.Drawing.Point(640, 4)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_nuevo.TabIndex = 3
        Me.btn_nuevo.Text = "Nuevo"
        '
        'lblpathRegistro
        '
        Me.lblpathRegistro.Location = New System.Drawing.Point(8, 64)
        Me.lblpathRegistro.Name = "lblpathRegistro"
        Me.lblpathRegistro.Size = New System.Drawing.Size(80, 23)
        Me.lblpathRegistro.TabIndex = 5
        Me.lblpathRegistro.Visible = False
        '
        'frm_producto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(728, 510)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Productos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim odataset As New DataSet
    'Dim oregistro_actual As New DataTable
    Dim oregistro_actual_flex As New DataTable
    Public ps_listaprecio As String = ""

    'calin
    Private Sub frm_producto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Llenar_Combos_flexline()
        'Llenar_Combos()
        Llenar_Informacion()
        'oregistro_actual = odataset.Tables("productos").Clone
        oregistro_actual_flex = odataset.Tables("productos_flex").Clone
        'Crear_Bindings()
        'Crear_BindingsFlex()

        Me.TabControl1.SelectedTab = Me.TabPage2
        aplicar_seguridad()

    End Sub

    Private Sub limpiarForma()
        Me.txt_cod_producto.Text = String.Empty
        Me.txt_nombre.Text = String.Empty
        Me.cmb_empresa.Text = String.Empty
        Me.txtTipo.Text = String.Empty
        Me.txtFamilia.Text = String.Empty
        Me.txtProveedor.Text = String.Empty
        Me.txtMarca.Text = String.Empty
        Me.txtSubtipo.Text = String.Empty
        Me.txt_procedencia.Text = String.Empty
        Me.txtvolumenML.Text = String.Empty

        Me.lbl_estado.Text = String.Empty
        Me.txt_codbarra.Text = String.Empty
        Me.lbl_estado.Text = String.Empty


        Me.txtCepa.Text = String.Empty
        Me.txtBU.Text = String.Empty
        Me.txt_codbarra.Text = String.Empty
        Me.dtp_vencimiento_registro_sanitario.Text = String.Empty

        Me.txt_registro_sanitario.Text = String.Empty



    End Sub


    Private Sub Llenar_Informacion()
        Dim ls_sql As String

        Dim otabla As DataTable

        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General

        Try
            oTrans.open()


            ls_sql = "SELECT * FROM flexline.v_um_producto_busqueda WHERE validastock = 's' and empresa = '" & gs_empresa & "'"
            otabla = oTrans.Obtiene(ls_sql)
            otabla.TableName = "productos_flex"
            If odataset.Tables.IndexOf("productos_flex") > 0 Then odataset.Tables.Remove("productos_flex")

            odataset.Tables.Add(otabla.Copy)


            Me.dgv_productos.DataSource = odataset.Tables("productos_flex")
            clsgen.Alinear_GridView(otabla, dgv_productos, "", ",empresa,validastock,precioventa,costo,path,cepa,", "", "", ",subfamilia=proveedor,tipo=marca,", ",vigente=20,", ",vigente,producto,glosa,familia,tipoproducto,subfamilia,tipo,subtipo,procedencia,codbarra,factoralt,analisisproducto6,path,", True, True, 175, 0)
        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing
        End Try


        hacer_filtro()
        Me.Refresh()
    End Sub

    Private Sub Llenar_Combos_flexline()
        Dim ls_sql As String
        Dim ls_campos_busqueda As String

        Dim otabla As DataTable
        'Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim Otrans As New Transaccional.Conexion("Flexline")



        Otrans.open()



        'ls_sql = "pa_sel_um_gen_tabcod null,'producto.familia','" & gs_empresa & "'"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_familia.DataSource = otabla
        'Me.cmb_familia.ValueMember = "codigo"
        'Me.cmb_familia.DisplayMember = "codigo"

        'otabla.TableName = "familia"
        'odataset.Tables.Add(otabla.Copy)

        'ls_sql = "pa_sel_um_gen_tabcod null,'producto.tipo','" & gs_empresa & "'"
        ''ls_sql = "call pa_sel_um_inv_tipo_bebidas_todos"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_tipo.DataSource = otabla
        'Me.cmb_tipo.ValueMember = "codigo"
        'Me.cmb_tipo.DisplayMember = "codigo"

        'otabla.TableName = "tipo_bebida"
        'odataset.Tables.Add(otabla.Copy)

        ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.PROCEDENCIA','" & gs_empresa & "'"
        otabla = Otrans.Obtiene(ls_sql)

        'Me.cmb_procedencia.DataSource = otabla
        'Me.cmb_procedencia.ValueMember = "codigo"
        'Me.cmb_procedencia.DisplayMember = "codigo"
        otabla.TableName = "pg_pais"
        odataset.Tables.Add(otabla.Copy)

        'ls_sql = "pa_sel_um_gen_tabcod null,'producto.subfamilia','" & gs_empresa & "'"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_proveedor.DataSource = otabla
        'Me.cmb_proveedor.ValueMember = "codigo"
        'Me.cmb_proveedor.DisplayMember = "codigo"
        'otabla.TableName = "inv_proveedor"
        'odataset.Tables.Add(otabla.Copy)

        'ls_sql = "pa_sel_um_gen_tabcod null,'producto.tipo','" & gs_empresa & "'"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_marca.DataSource = otabla
        'Me.cmb_marca.ValueMember = "codigo"
        'Me.cmb_marca.DisplayMember = "codigo"
        'otabla.TableName = "inv_marca"
        'odataset.Tables.Add(otabla.Copy)

        'ls_sql = "pa_sel_um_gen_tabcod null,'producto.subtipo','" & gs_empresa & "'"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_sub_tipo.DataSource = otabla
        'Me.cmb_sub_tipo.ValueMember = "cod_subtipo"
        'Me.cmb_sub_tipo.DisplayMember = "descripcion"
        'otabla.TableName = "inv_subtipo"
        'odataset.Tables.Add(otabla.Copy)

        ls_sql = "pa_sel_um_gen_tabcod null,'gen_empresa','" & gs_empresa & "'"
        otabla = Otrans.Obtiene(ls_sql)

        Me.cmb_empresa.DataSource = otabla
        Me.cmb_empresa.ValueMember = "descripcion"
        Me.cmb_empresa.DisplayMember = "descripcion"
        otabla.TableName = "pg_empresa"
        odataset.Tables.Add(otabla.Copy)

        'ls_sql = "call pa_sel_um_inv_producto_cepa"
        'otabla = otrans.Obtiene(ls_sql)

        'Me.cmb_cepa.DataSource = otabla
        'Me.cmb_cepa.ValueMember = "cod_cepa"
        'Me.cmb_cepa.DisplayMember = "descripcion"
        'otabla.TableName = "inv_cepa"
        'odataset.Tables.Add(otabla.Copy)


        '*/*/*/*/*/*/*
        'ls_sql = "pa_sel_um_producto_cepa"
        'otabla = Otrans.Obtiene(ls_sql)

        'Me.cmb_cepa.DataSource = otabla
        'Me.cmb_cepa.ValueMember = "analisisproducto6"
        'Me.cmb_cepa.DisplayMember = "analisisproducto6"


        'ls_sql = "pa_sel_um_producto_bu"
        'otabla = Otrans.Obtiene(ls_sql)

        'Me.cmbBU.DataSource = otabla
        'Me.cmbBU.ValueMember = "analisisproducto17"
        'Me.cmbBU.DisplayMember = "analisisproducto17"


        'otabla.TableName = "inv_cepa"
        'odataset.Tables.Add(otabla.Copy)


        '/*/*/*/*/*/*/*


        'ls_sql = "call pa_sel_um_pg_parametros_sistema"
        'otabla = otrans.Obtiene(ls_sql)


        Otrans.close()
        Otrans = Nothing

        'ls_campos_busqueda = otabla.Rows(0).Item("campos_busqueda_producto")
        ls_campos_busqueda = "glosa,tipoproducto,familia,proveedor,marca,subtipo,procedencia,producto"

        llenar_combos_filtro(ls_campos_busqueda)
    End Sub

    'Private Sub Llenar_Combos()
    '    Dim ls_sql As String
    '    Dim ls_campos_busqueda As String

    '    Dim otabla As DataTable
    '    Dim otrans As New Transaccional.Conexion_mysql("onBase")
    '    Dim Otrans2 As New Transaccional.Conexion("Flexline")



    '    otrans.open()
    '    Otrans2.open()


    '    ls_sql = "call pa_sel_um_inv_producto_familia"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_familia.DataSource = otabla
    '    Me.cmb_familia.ValueMember = "cod_familia"
    '    Me.cmb_familia.DisplayMember = "descripcion"

    '    otabla.TableName = "familia"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_inv_tipo_bebidas_todos"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_tipo.DataSource = otabla
    '    Me.cmb_tipo.ValueMember = "cod_tipo_bebida"
    '    Me.cmb_tipo.DisplayMember = "descripcion"

    '    otabla.TableName = "tipo_bebida"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_pg_pais"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_procedencia.DataSource = otabla
    '    Me.cmb_procedencia.ValueMember = "cod_pais"
    '    Me.cmb_procedencia.DisplayMember = "pais"
    '    otabla.TableName = "pg_pais"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_inv_proveedor"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_proveedor.DataSource = otabla
    '    Me.cmb_proveedor.ValueMember = "cod_proveedor"
    '    Me.cmb_proveedor.DisplayMember = "descripcion"
    '    otabla.TableName = "inv_proveedor"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_inv_producto_marca"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_marca.DataSource = otabla
    '    Me.cmb_marca.ValueMember = "cod_marca"
    '    Me.cmb_marca.DisplayMember = "descripcion"
    '    otabla.TableName = "inv_marca"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_inv_producto_subtipo_todos"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_sub_tipo.DataSource = otabla
    '    Me.cmb_sub_tipo.ValueMember = "cod_subtipo"
    '    Me.cmb_sub_tipo.DisplayMember = "descripcion"
    '    otabla.TableName = "inv_subtipo"
    '    odataset.Tables.Add(otabla.Copy)

    '    ls_sql = "call pa_sel_um_pg_empresa"
    '    otabla = otrans.Obtiene(ls_sql)

    '    Me.cmb_empresa.DataSource = otabla
    '    Me.cmb_empresa.ValueMember = "cod_empresa"
    '    Me.cmb_empresa.DisplayMember = "descripcion"
    '    otabla.TableName = "pg_empresa"
    '    odataset.Tables.Add(otabla.Copy)

    '    'ls_sql = "call pa_sel_um_inv_producto_cepa"
    '    'otabla = otrans.Obtiene(ls_sql)

    '    'Me.cmb_cepa.DataSource = otabla
    '    'Me.cmb_cepa.ValueMember = "cod_cepa"
    '    'Me.cmb_cepa.DisplayMember = "descripcion"
    '    'otabla.TableName = "inv_cepa"
    '    'odataset.Tables.Add(otabla.Copy)


    '    '*/*/*/*/*/*/*
    '    ls_sql = "pa_sel_um_producto_cepa"
    '    otabla = Otrans2.Obtiene(ls_sql)

    '    Me.cmb_cepa.DataSource = otabla
    '    Me.cmb_cepa.ValueMember = "analisisproducto6"
    '    Me.cmb_cepa.DisplayMember = "analisisproducto6"


    '    ls_sql = "pa_sel_um_producto_bu"
    '    otabla = Otrans2.Obtiene(ls_sql)

    '    Me.cmbBU.DataSource = otabla
    '    Me.cmbBU.ValueMember = "analisisproducto17"
    '    Me.cmbBU.DisplayMember = "analisisproducto17"


    '    'otabla.TableName = "inv_cepa"
    '    'odataset.Tables.Add(otabla.Copy)


    '    '/*/*/*/*/*/*/*


    '    'ls_sql = "call pa_sel_um_pg_parametros_sistema"
    '    'otabla = otrans.Obtiene(ls_sql)

    '    Otrans2.close()
    '    Otrans2 = Nothing

    '    otrans.close()
    '    otrans = Nothing

    '    'ls_campos_busqueda = otabla.Rows(0).Item("campos_busqueda_producto")
    '    ls_campos_busqueda = "glosa,tipoproducto,familia,proveedor,marca,subtipo,procedencia,producto"

    '    llenar_combos_filtro(ls_campos_busqueda)
    'End Sub

    Private Sub llenar_combos_filtro(ByVal ls_campos_busqueda)
        Dim lo_listaopciones As Array
        Dim lo_opcion As Object

        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")
        Me.cmb_1.Text = Me.cmb_1.Items(3)

        Me.cmb_2.Items.Add("=")
        Me.cmb_2.Items.Add(">")
        Me.cmb_2.Items.Add("<")
        Me.cmb_2.Items.Add("like")
        Me.cmb_2.Text = Me.cmb_2.Items(3)

        Me.cmb_3.Items.Add("=")
        Me.cmb_3.Items.Add(">")
        Me.cmb_3.Items.Add("<")
        Me.cmb_3.Items.Add("like")
        Me.cmb_3.Text = Me.cmb_3.Items(3)

        'combo de busqueda
        Me.cmb_operadolog_1.Items.Add("AND")
        Me.cmb_operadolog_1.Items.Add("OR")
        Me.cmb_operadolog_1.Text = Me.cmb_operadolog_1.Items(1)

        Me.cmb_operadolog_2.Items.Add("AND")
        Me.cmb_operadolog_2.Items.Add("OR")

        Me.cmb_operadolog_2.Text = Me.cmb_operadolog_2.Items(1)


        lo_listaopciones = ls_campos_busqueda.Split(",")
        For Each lo_opcion In lo_listaopciones
            Me.cmb_valor1.Items.Add(lo_opcion)
            Me.cmb_valor2.Items.Add(lo_opcion)
            Me.cmb_valor3.Items.Add(lo_opcion)
        Next
        Me.cmb_valor1.Text = "glosa" 'Me.cmb_valor1.Items(0)

    End Sub

    'Private Sub btn_validar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validar.Click
    '    Dim ls_sql As String
    '    Dim ls_filtro As String

    '    Dim dr As DataRow = oregistro_actual.NewRow()
    '    Dim otabla As DataTable
    '    Dim otrans As New Transaccional.Conexion("flexline")
    '    Try



    '        ls_sql = "pa_sel_um_producto '" & Me.cmb_empresa.Text & "','" & Me.txt_cod_producto.Text & "'"

    '        otrans.open()
    '        otabla = otrans.Obtiene(ls_sql)
    '        otrans.close()
    '        otrans = Nothing


    '        Me.lbl_estado.Text = IIf(otabla.Rows(0).Item("VIGENTE").ToString = "S", "ACTIVO", "INACTIVO")
    '        '
    '        dr.Item("cod_empresa") = Me.cmb_empresa.SelectedValue
    '        dr.Item("cod_flex") = Me.txt_cod_producto.Text


    '        'Descripcion
    '        dr.Item("nombre_producto") = otabla.Rows(0).Item("glosa")

    '        'Familia
    '        ls_filtro = "trim(descripcion) = '" & otabla.Rows(0).Item("familia") & "'"
    '        odataset.Tables("familia").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_familia.SelectedValue = odataset.Tables("familia").DefaultView(0)("cod_familia").ToString
    '            dr.Item("cod_familia") = odataset.Tables("familia").DefaultView(0)("cod_familia")
    '        Catch ex As Exception
    '        End Try

    '        'tipo producto
    '        ls_filtro = "trim(descripcion) = '" & otabla.Rows(0).Item("tipoproducto") & "'"
    '        odataset.Tables("tipo_bebida").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_tipo.SelectedValue = odataset.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida").ToString()
    '            dr.Item("cod_tipo") = odataset.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida")
    '        Catch ex As Exception
    '        End Try

    '        'proveedor
    '        ls_filtro = "trim(descripcion) = '" & otabla.Rows(0).Item("subfamilia") & "'"
    '        odataset.Tables("inv_proveedor").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_proveedor.SelectedValue = odataset.Tables("inv_proveedor").DefaultView(0)("cod_proveedor").ToString
    '            dr.Item("cod_proveedor") = odataset.Tables("inv_proveedor").DefaultView(0)("cod_proveedor")
    '        Catch ex As Exception
    '        End Try

    '        'marca
    '        ls_filtro = "trim(descripcion) = '" & otabla.Rows(0).Item("tipo") & "'"
    '        odataset.Tables("inv_marca").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_marca.SelectedValue = odataset.Tables("inv_marca").DefaultView(0)("cod_marca").ToString
    '            dr.Item("cod_marca") = odataset.Tables("inv_marca").DefaultView(0)("cod_marca")
    '        Catch ex As Exception
    '        End Try

    '        'sub tipo
    '        ls_filtro = "trim(descripcion) = '" & otabla.Rows(0).Item("subtipo") & "'"
    '        odataset.Tables("inv_subtipo").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_sub_tipo.SelectedValue = odataset.Tables("inv_subtipo").DefaultView(0)("cod_subtipo").ToString
    '            dr.Item("cod_subtipo") = odataset.Tables("inv_subtipo").DefaultView(0)("cod_subtipo")
    '        Catch ex As Exception
    '        End Try

    '        'pais
    '        ls_filtro = "pais = '" & otabla.Rows(0).Item("procedencia") & "'"
    '        odataset.Tables("pg_pais").DefaultView.RowFilter = ls_filtro
    '        Try
    '            'Me.cmb_procedencia.SelectedValue = odataset.Tables("pg_pais").DefaultView(0)("cod_pais").ToString
    '            dr.Item("cod_pais") = odataset.Tables("pg_pais").DefaultView(0)("cod_pais")
    '        Catch ex As Exception
    '        End Try

    '        dr.Item("unidad") = otabla.Rows(0).Item("unidad")
    '        dr.Item("volumen") = otabla.Rows(0).Item("volumen")
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        oregistro_actual.Rows.Clear()
    '        oregistro_actual.Rows.Add(dr)

    '    End Try

    'End Sub

    Private Sub dg_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim li_row_number As Integer
        Dim resultado As Integer

        li_row_number = Me.dgv_productos.CurrentCell.RowIndex
        'resultado = Me.dg_productos.Item(li_row_number, 0).ToString

        llenar_registro(odataset.Tables("productos"), resultado)

        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.btn_validar.Visible = False
    End Sub

    Private Sub llenar_registro(ByVal ptabla As DataTable, ByVal pcodflex As String)

        'Dim otabla As New DataTable
        Dim otablaFlex As New DataTable
        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim meses As Integer


        limpiarForma()

        oregistro_actual_flex.Clear()
        otablaFlex = odataset.Tables("productos_flex").Copy
        otablaFlex.DefaultView.RowFilter = "producto = '" & pcodflex & "'"
        otablaFlex = otablaFlex.DefaultView().ToTable

        Try
            Me.pb_imagen.Image = Nothing
        Catch ex As Exception

        End Try
        If otablaFlex.DefaultView.Count > 0 Then

            oregistro_actual_flex.ImportRow(otablaFlex.DefaultView(0).Row())
            Dim lrow As DataRow = otablaFlex.Rows(0)

            Try
                Me.txt_cod_producto.Text = lrow.Item("producto")
                Me.txt_nombre.Text = lrow.Item("glosa")
                Me.cmb_empresa.Text = lrow.Item("empresa")
                'Me.cmb_tipo.Text = lrow.Item("tipoproducto")
                Me.txtTipo.Text = lrow.Item("tipoproducto")
                'Me.cmb_familia.Text = lrow.Item("familia")
                Me.txtFamilia.Text = lrow.Item("familia")
                'Me.cmb_proveedor.Text = lrow.Item("subfamilia")
                Me.txtProveedor.Text = lrow.Item("subfamilia")
                'Me.cmb_marca.Text = lrow.Item("tipo")
                Me.txtMarca.Text = lrow.Item("tipo")
                'Me.cmb_sub_tipo.Text = lrow.Item("subtipo")
                Me.txtSubtipo.Text = lrow.Item("subtipo")
                Me.txt_procedencia.Text = lrow.Item("procedencia")
                Me.txtvolumenML.Text = lrow.Item("volumen_ml").ToString.Split(".")(0)


            Catch ex As Exception
            End Try

            Try
                ' If oregistro_actual.Rows(0).Item("imagen").ToString.Trim.Length > 0 Then
                Me.pb_imagen.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images\" & oregistro_actual_flex.Rows(0).Item("imagen"))
                'End If
            Catch ex As Exception
            End Try
            'Me.btn_guardar.Text = "Actualizar"
            'Me.chk_mostrar_web.Checked = IIf(oregistro_actual.Rows(0).Item("mostrar_web").ToString = "0", False, True)

            Try
                'ls_sql = "pa_sel_um_producto '" & Me.cmb_empresa.Text & "','" & Me.txt_cod_producto.Text & "'"
                'oTrans.open()
                'dt = oTrans.Obtiene(ls_sql)
                Me.lblpathRegistro.Text = ""
                Me.lbl_estado.Text = " "
                Me.txt_codbarra.Text = ""
                Me.lbl_estado.Text = IIf(otablaFlex.Rows(0).Item("VIGENTE").ToString = "S", "ACTIVO", "INACTIVO")

                If otablaFlex.Rows.Count > 0 Then
                    Me.txtCepa.Text = otablaFlex.Rows(0).Item("cepa_estilo").ToString
                    Me.txtBU.Text = otablaFlex.Rows(0).Item("BU").ToString
                End If

                If otablaFlex.Rows(0).Item("VIGENTE").ToString <> "S" Then
                    Me.lbl_estado.ForeColor = System.Drawing.Color.Red
                Else
                    Me.lbl_estado.ForeColor = System.Drawing.Color.Black
                End If

                Me.txt_codbarra.Text = otablaFlex.Rows(0).Item("CodBarra").ToString
                Me.lblpathRegistro.Text = otablaFlex.Rows(0).Item("path").ToString

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                oTrans.close()
                oTrans = Nothing
            End Try

            'Me.StatusBarPanel1.Text = "Grabo " & oregistro_actual.Rows(0)("usuario_grabo") & " " & oregistro_actual.Rows(0)("fecha_grabo")
            'Me.StatusBarPanel2.Text = "Ultima Modificacion " & oregistro_actual.Rows(0)("usuario_modifico") & " " & oregistro_actual.Rows(0)("fecha_modifico")

            'Fecha de registro sanitario
            If otablaFlex.Rows(0).Item("Vencimiento_Registro_Sanitario").ToString.Length > 0 Then
                Me.dtp_vencimiento_registro_sanitario.Text = otablaFlex.Rows(0).Item("Vencimiento_Registro_Sanitario").ToString
            Else
                Me.dtp_vencimiento_registro_sanitario.Text = ""

            End If
            'Registro sanitario
            If otablaFlex.Rows(0).Item("Registro_Sanitario").ToString.Length > 0 Then
                Me.txt_registro_sanitario.Text = otablaFlex.Rows(0).Item("Registro_Sanitario").ToString
            Else
                Me.txt_registro_sanitario.Text = ""

            End If






            'Colorear lbl_registro_Sanitario
            Try
                Me.lbl_estado_registro_sanitario.BackColor = System.Drawing.SystemColors.ControlLight
                meses = DateDiff(DateInterval.Month, Date.Parse(otablaFlex.Rows(0).Item("vencimiento_registro_sanitario").ToString), Now) * -1
                If meses >= 6 Then
                    Me.lbl_estado_registro_sanitario.BackColor = System.Drawing.Color.Green
                ElseIf meses >= 4 Then
                    Me.lbl_estado_registro_sanitario.BackColor = System.Drawing.Color.Orange
                Else
                    Me.lbl_estado_registro_sanitario.BackColor = System.Drawing.Color.Red
                End If
            Catch ex As Exception
            End Try

            Me.TabControl1.SelectedTab = Me.TabPage1
        End If

        ClsGen = Nothing
    End Sub

    Private Sub Crear_BindingsFlex()
        Me.txt_nombre.DataBindings.Add("Text", oregistro_actual_flex, "glosa")
        'Me.txt_descripcion.DataBindings.Add("Text", oregistro_actual_flex, "descripcion")
        Me.txt_cod_producto.DataBindings.Add("Text", oregistro_actual_flex, "producto")
        Me.cmb_empresa.DataBindings.Add("SelectedValue", oregistro_actual_flex, "empresa")
        'Me.cmb_procedencia.DataBindings.Add("SelectedValue", oregistro_actual_flex, "procedencia")
        ' Me.cmb_tipo.DataBindings.Add("SelectedValue", oregistro_actual_flex, "tipoproducto")
        ' Me.cmb_familia.DataBindings.Add("SelectedValue", oregistro_actual_flex, "familia")
        ' Me.cmb_proveedor.DataBindings.Add("SelectedValue", oregistro_actual_flex, "subfamilia")
        ' Me.cmb_marca.DataBindings.Add("SelectedValue", oregistro_actual_flex, "tipo")
        ' Me.cmb_sub_tipo.DataBindings.Add("SelectedValue", oregistro_actual_flex, "subtipo")
        Try

        Catch ex As Exception
            'Me.cmb_cepa.DataBindings.Add("SelectedValue", oregistro_actual_flex, "analisisproducto6")
        End Try

        ' Me.txt_registro_sanitario.DataBindings.Add("Text", oregistro_actual, "registro_sanitario")

        Try
            '   Me.dtp_vencimiento_registro_sanitario.DataBindings.Add("Text", oregistro_actual, "vencimiento_registro_sanitario")
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Crear_Bindings()
        'Me.txt_nombre.DataBindings.Add("Text", oregistro_actual, "nombre_producto")
        'Me.txt_descripcion.DataBindings.Add("Text", oregistro_actual, "descripcion")
        'Me.txt_cod_producto.DataBindings.Add("Text", oregistro_actual, "cod_flex")
        'Me.cmb_empresa.DataBindings.Add("SelectedValue", oregistro_actual, "cod_empresa")
        'Me.cmb_procedencia.DataBindings.Add("SelectedValue", oregistro_actual, "cod_pais")
        'Me.cmb_tipo.DataBindings.Add("SelectedValue", oregistro_actual, "cod_tipo")
        'Me.cmb_familia.DataBindings.Add("SelectedValue", oregistro_actual, "cod_familia")
        'Me.cmb_proveedor.DataBindings.Add("SelectedValue", oregistro_actual, "cod_proveedor")
        'Me.cmb_marca.DataBindings.Add("SelectedValue", oregistro_actual, "cod_marca")
        'Me.cmb_sub_tipo.DataBindings.Add("SelectedValue", oregistro_actual, "cod_subtipo")
        'Try

        'Catch ex As Exception
        '    Me.cmb_cepa.DataBindings.Add("SelectedValue", oregistro_actual, "analisisproducto6")
        'End Try

        '' Me.txt_registro_sanitario.DataBindings.Add("Text", oregistro_actual, "registro_sanitario")

        'Try
        '    '   Me.dtp_vencimiento_registro_sanitario.DataBindings.Add("Text", oregistro_actual, "vencimiento_registro_sanitario")
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click, btnTodos.Click
        Dim dr As DataRow

        Me.btn_guardar.Text = "Guardar"
        Me.btn_validar.Visible = True
        Me.lbl_estado.Text = ""

        '(c) 20201209
        'oregistro_actual.Rows.Clear()
        'dr = oregistro_actual.NewRow()
        'dr.Item("vencimiento_registro_sanitario") = Now
        'oregistro_actual.Rows.Add(dr)

        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub

    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text.Replace("proveedor", "subfamilia").Replace("marca", "tipo"),
                                        Me.cmb_valor2.Text.Replace("proveedor", "subfamilia").Replace("marca", "tipo"), Me.cmb_valor3.Text.Replace("proveedor", "subfamilia").Replace("marca", "tipo"),
                Me.txt_filtro1.Text, Me.txt_filtro2.Text, Me.txt_filtro3.Text,
                Me.cmb_1.Text, Me.cmb_2.Text, Me.cmb_3.Text,
                Me.cmb_operadolog_1.Text, Me.cmb_operadolog_2.Text)

        clsgen = Nothing

        odataset.Tables("productos_flex").DefaultView.RowFilter = ls_filtro

    End Sub

    Private Sub txt_filtro1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub txt_filtro2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro2.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub txt_filtro3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro3.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Me.btn_guardar.Text = "Guardar" Then
            'Guardar_Registro()
        Else
            'Modificar_Registro()
        End If
        'Llenar_Informacion()
    End Sub

    'Private Sub Modificar_Registro()
    '    Dim ls_sql, ls_sql2 As String


    '    Dim otrans As New Transaccional.Conexion_mysql("onBase")
    '    Dim Sotrans As New Transaccional.Conexion("Flexline")


    '    Dim fecha_vencimiento As String
    '    Dim fechaarray(3) As String
    '    Try
    '        fecha_vencimiento = oregistro_actual.Rows(0).Item("vencimiento_registro_sanitario").ToString
    '        fechaarray = fecha_vencimiento.Split("/")
    '        fecha_vencimiento = fechaarray(2).Substring(0, 4) & "-" & fechaarray(1) & "-" & fechaarray(0)


    '    Catch ex As Exception

    '    End Try


    '    ls_sql = "call pa_upd_um_inv_producto (" & oregistro_actual.Rows(0).Item("cod_producto").ToString & ",'" & _
    '             Me.txt_descripcion.Text & "',0"

    '    'If Me.cmb_cepa.SelectedValue < 1 Then
    '    '    ls_sql = ls_sql & "0"
    '    'Else
    '    '    ls_sql = ls_sql & Me.cmb_cepa.SelectedValue.ToString
    '    'End If
    '    If Me.chk_mostrar_web.CheckState = CheckState.Checked Then
    '        ls_sql = ls_sql & ",1"
    '    Else
    '        ls_sql = ls_sql & ",0"
    '    End If
    '    'ls_sql = ls_sql & ",'" & oregistro_actual.Rows(0).Item("imagen") & "','" & gs_usuario & "','" & _
    '    '        oregistro_actual.Rows(0).Item("registro_sanitario").ToString & "','" & _
    '    '        fecha_vencimiento & "')"
    '    ls_sql = ls_sql & ",'" & oregistro_actual.Rows(0).Item("imagen") & "','" & gs_usuario & "')"

    '    otrans.open()
    '    otrans.Actualiza(ls_sql)


    '    Sotrans.open()

    '    ls_sql2 = "pa_upd_um_producto_cepa '" & Me.txt_cod_producto.Text & "','" & Me.cmb_cepa.Text & "','" & gs_usuario & "'"
    '    Sotrans.Actualiza(ls_sql2)
    '    Sotrans.Escribir_Log(ls_sql2)


    '    ls_sql2 = "pa_upd_um_producto_bu '" & Me.txt_cod_producto.Text & "','" & gs_empresa & "','" & Me.cmbBU.Text & "','" & gs_usuario & "'"
    '    Sotrans.Actualiza(ls_sql2)
    '    Sotrans.Escribir_Log(ls_sql2)

    '    If otrans.Codigo_error = 0 Then
    '        MessageBox.Show("Informacion Actualizada Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Else
    '        MessageBox.Show(otrans.descripcion_error)
    '    End If

    '    Sotrans.close()
    '    Sotrans = Nothing


    '    otrans.close()
    '    otrans = Nothing
    '    'oregistro_actual.Rows.Clear()
    '    Me.TabControl1.SelectedTab = Me.TabPage2

    'End Sub

    'Private Sub Guardar_Registro()
    '    Dim ls_sql As String

    '    Dim otrans As New Transaccional.Conexion_mysql("onBase")
    '    Dim dr As DataRow = oregistro_actual.Rows(0)

    '    Try

    '        otrans.open()

    '        Dim fecha_vencimiento As String
    '        Dim fechaarray(3) As String

    '        fecha_vencimiento = dr.Item("vencimiento_registro_sanitario")
    '        fechaarray = fecha_vencimiento.Split("/")
    '        fecha_vencimiento = fechaarray(2).Substring(0, 4) & "-" & fechaarray(1) & "-" & fechaarray(0)

    '        ls_sql = "call pa_ins_um_inv_producto (" & _
    '                    dr.Item("cod_empresa").ToString & ",'" & _
    '                    dr.Item("cod_flex").ToString & "','" & _
    '                    dr.Item("nombre_producto").ToString & "'," & _
    '                    dr.Item("cod_tipo").ToString & "," & _
    '                    dr.Item("cod_familia").ToString & "," & _
    '                    dr.Item("cod_proveedor").ToString & "," & _
    '                    dr.Item("cod_marca").ToString & "," & _
    '                    dr.Item("cod_subtipo").ToString & "," & _
    '                    dr.Item("cod_pais").ToString & ",'" & _
    '                    dr.Item("descripcion").ToString & "','" & _
    '                    dr.Item("unidad").ToString & "'," & _
    '                    dr.Item("volumen").ToString & ","

    '        If Me.cmb_cepa.SelectedValue < 1 Then
    '            ls_sql = ls_sql & "0"
    '        Else
    '            ls_sql = ls_sql & Me.cmb_cepa.SelectedValue.ToString
    '        End If
    '        If Me.chk_mostrar_web.CheckState = CheckState.Checked Then
    '            ls_sql = ls_sql & ",1"
    '        Else
    '            ls_sql = ls_sql & ",0"
    '        End If
    '        ls_sql = ls_sql & ",'" & oregistro_actual.Rows(0).Item("imagen") & "','" & gs_usuario & "','" & _
    '                 dr.Item("registro_sanitario").ToString & "','" & _
    '                 fecha_vencimiento.ToString & "')"


    '        otrans.Ingresa(ls_sql)
    '        If otrans.Codigo_error = 0 Then
    '            MessageBox.Show("Informacion Actualizada Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show(otrans.descripcion_error)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        otrans.close()
    '        otrans = Nothing
    '        Me.btn_guardar.Text = "Actualizar"
    '        Me.btn_validar.Visible = False
    '    End Try
    'End Sub

    Private Sub Btn_Existencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_existencia.Click
        Dim lb_continuar As Boolean = True

        While lb_continuar
            lb_continuar = buscar_existencia()
        End While

    End Sub

    Private Function buscar_existencia() As Boolean
        Dim ls_sql As String
        Dim lb_resultado As Boolean = False
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim otabla As DataTable
        Dim lb_Reintentar As Boolean = False

        ls_sql = "pa_var_um_existencias_producto '" &
                  oregistro_actual_flex.Rows(0)("empresa") & "','" &
                  oregistro_actual_flex.Rows(0)("producto") & "'"


        Try
            otrans.open()
            otabla = otrans.Obtiene(ls_sql)
            If otrans.Codigo_error > 0 Then
                If MessageBox.Show(otrans.descripcion_error & Chr(13) & " Desea Reintentar", "Informacion", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                    lb_Reintentar = True
                End If
            Else

                'otabla.DefaultView.RowFilter = "bodega like '%" & "CD_CENTRAL%'"

                If otabla.Rows.Count > 0 Then
                    Dim oform As New frm_resultado
                    Dim clsgen As New ClasesGenerales.General
                    oform.dgv_resultado.DataSource = otabla
                    oform.dgv_resultado.ReadOnly = True

                    clsgen.Alinear_GridView(otabla, oform.dgv_resultado, "", ",empresa,", "", "", "", "", "", True, True, 250, 50)
                    clsgen = Nothing

                    oform.ShowDialog()
                    oform = Nothing


                    'Me.dg_productos(posicion_grid, 1) = otabla.Rows(0).Item("glosa")

                    If otabla.DefaultView.Count > 0 Then

                        '                Me.dg_productos(posicion_grid, 7) = otabla.DefaultView(0)("Existencia").ToString
                        '               Me.dg_productos(posicion_grid, 2) = 0
                    End If
                Else
                    MessageBox.Show("No Hay Movimientos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try


        Return lb_Reintentar
    End Function

    Private Sub aplicar_seguridad()
        If gi_tipo_usuario = 1 Then
            Me.btn_existencia.Visible = True
            'Me.btn_limpiar.Visible = False
            Me.btn_precios.Visible = True
            Me.btn_guardar.Visible = False
            Me.btn_nuevo.Visible = False
        Else
            Me.btn_guardar.Visible = False
            'Me.btn_limpiar.Visible = False
            Me.btn_nuevo.Visible = False
            'Me.btn_precios.Visible = True
            'Me.btn_existencia.Visible = True
        End If
        If tiene_permisos("mar_informacion_productos_precios") Then
            Me.btn_precios.Visible = True
        End If
        If tiene_permisos("mar_informacion_productos_existencias") Then
            Me.btn_existencia.Visible = True
        End If
        If tiene_permisos("mar_informacion_productos_actualizar") Then
            Me.btn_guardar.Visible = True
        End If

        Me.btnRegistroSanitarios.Visible = tiene_permisos("mar_informacion_productos_registro_sanitario")
        Me.btnPesoVolumen.Visible = tiene_permisos("mar_informacion_productos_peso_volumen")
        'If ps_permisos.IndexOf("W", 0, ps_permisos.Length) < 0 Then
        ' End If

    End Sub

    Private Sub btn_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_precios.Click
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")


        ls_sql = "pa_sel_um_listapreciod '" & Me.cmb_empresa.Text & "','" &
                 Me.txt_cod_producto.Text & "',"

        'Lista Precios
        'empresa
        'producto
        'no trae lista de precios
        If ps_listaprecio.Length = 0 Then
            ls_sql = ls_sql & "NULL"
        Else
            ls_sql = ls_sql & "'" & ps_listaprecio & "'"
        End If

        otrans.open()
        otabla = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        ls_sql = "fec_final > '" & Now & "'"

        otabla.DefaultView.RowFilter = ls_sql

        Dim oform As New frm_resultado
        Dim clsgen As New ClasesGenerales.General
        oform.dgv_resultado.DataSource = otabla
        oform.dgv_resultado.ReadOnly = True
        oform.Text = "Listas de Precios .:"
        '        clsgen.Alinea_Grid(otabla, oform.DataGrid1, otabla.TableName, 3, 250, 0, True, True, ",lisprecio,valor,fec_final,vigente,oferta,", True, "")
        clsgen.Alinear_GridView(otabla, oform.dgv_resultado, ",lisprecio,valor,fec_final,vigente,oferta,", "", "", "", "", "", "", True, True, 250, 0)

        clsgen = Nothing

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    'Private Sub pb_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_imagen.Click

    '    'If ps_permisos.IndexOf("W", 0, ps_permisos.Length) > 0 Then
    '    If tiene_permisos("asociar_imagen") Then


    '        Dim clsGen As New ClasesGenerales.General
    '        If Me.btn_guardar.Visible = True Then
    '            Try
    '                Dim sRuta As String
    '                sRuta = "\\onbase\tools$\images"

    '                ofd_ruta_imagen.Filter = "png|*.png"
    '                ' ofd_ruta_imagen.InitialDirectory = xx '"\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza"
    '                ofd_ruta_imagen.ShowDialog()
    '                Dim finfo As New FileInfo(ofd_ruta_imagen.FileName)

    '                '        If "\\onbase\tools$\images\" & oregistro_actual.Rows(0).Item("imagen") <> ofd_ruta_imagen.FileName Then
    '                If oregistro_actual.Rows(0).Item("imagen") <> finfo.Name Then
    '                    If MessageBox.Show("Esta Seguro de Cambiar la Imagen Asociada", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '                        oregistro_actual.Rows(0).Item("imagen") = finfo.Name

    '                        clsGen.Copiar_Archivo(ofd_ruta_imagen.FileName, sRuta & "\" & finfo.Name, True)


    '                    End If
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            'End If

    '        End If
    '    Else

    '        Dim ClsGen As New ClasesGenerales.frm_mostrarImagen
    '        'ClsGen.psimagen = "\\onbase\tools$\images\DM_0100020042.JPG"
    '        'ClsGen.ShowDialog()
    '        'ClsGen.Dispose()
    '        'ClsGen = Nothing
    '        Dim nRow As Integer
    '        Dim nombre_imagen As String = ""


    '        Try
    '            nRow = Me.dgv_productos.CurrentCell.RowIndex

    '            If oregistro_actual.Rows(0).Item("imagen").ToString.Length > 0 Then
    '                nombre_imagen = oregistro_actual.Rows(0).Item("imagen")
    '            Else
    '                nombre_imagen = "v_000.png"
    '            End If
    '            ClsGen.psimagen = "\\onbase\tools$\images\" & nombre_imagen
    '            ClsGen.ShowDialog()
    '            ClsGen.Dispose()
    '            ClsGen = Nothing




    '        Catch ex As Exception

    '        End Try
    '    End If




    'End Sub

    Private Sub dgv_productos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellEnter

    End Sub


    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = dgv_productos.Rows(rowIndex)

                If dgv_productos.Columns(colIndex).Name.ToLower.IndexOf("vigente") > -1 Then
                    If dgv_productos.Item(colIndex, rowIndex).Value.ToString.ToLower = "n" Then
                        Me.dgv_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgv_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.DoubleClick


        'resultado = Me.dg_productos.Item(li_row_number, 0).ToString
        Try

            llenar_registro(odataset.Tables("productos"), dgv_productos.Item("producto", Me.dgv_productos.CurrentCell.RowIndex).Value)

            Me.btn_validar.Visible = False
        Catch ex As Exception

        End Try

    End Sub



    Private Sub btnRegistroSanitarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistroSanitarios.Click
        Dim ClsGen As New ClasesGenerales.frm_mostrarImagen

        Dim ClasesGenerales As New ClasesGenerales.General

        Dim nombre_imagen As String = ""


        Try
            nombre_imagen = Me.lblpathRegistro.Text

            If nombre_imagen.Length = 0 Then
                nombre_imagen = "v_000.png"
            End If


            ClsGen.psimagen = "\\" & ClasesGenerales.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmb_empresa.Text & "\" & nombre_imagen



            ClsGen.ShowDialog()
            ClsGen.Dispose()
            ClsGen = Nothing




        Catch ex As Exception
        Finally
            ClasesGenerales = Nothing
        End Try











    End Sub


    Private Sub dgv_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellContentClick

    End Sub

    Private Sub txt_filtro1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_filtro1.TextChanged

    End Sub

    Private Sub btnPesoVolumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesoVolumen.Click
        Dim oform As New frm_Producto_Peso_Volumen
        oform.txt_Producto.Text = Me.txt_cod_producto.Text
        oform.txt_Descripcion.Text = Me.txt_nombre.Text
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub dgv_productos_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_productos.CellMouseUp

    End Sub

    Private Sub pb_imagen_DoubleClick(sender As Object, e As EventArgs) Handles pb_imagen.DoubleClick

    End Sub

    Private Sub dgv_productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_productos.CellDoubleClick

    End Sub

    Private Sub lbl_estado_registro_sanitario_Click(sender As Object, e As EventArgs) Handles lbl_estado_registro_sanitario.Click

    End Sub
End Class

