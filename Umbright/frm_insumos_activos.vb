Public Class frm_insumos_activos
    Inherits System.Windows.Forms.Form
    Dim dt_modelos As DataTable
    Dim ds_insumos As New DataSet
    Dim ds_movimiento As New DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Private okToValidate As Boolean

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
    Friend WithEvents menu_insumos As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_modelo As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_serie As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents m_insumos_tipos_activos As System.Windows.Forms.MenuItem
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents m_insumos_marcas As System.Windows.Forms.MenuItem
    Friend WithEvents m_insumos_modelos As System.Windows.Forms.MenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents m_insumos_categoria As System.Windows.Forms.MenuItem
    Friend WithEvents dg_insumos_asociados As System.Windows.Forms.DataGrid
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents dg_listado_insumos As System.Windows.Forms.DataGrid
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_guardar_movimiento As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo_movimiento As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txt_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmb_motivo_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipo_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents dg_detalle_movimiento As System.Windows.Forms.DataGrid
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents panel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents panel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents m_insumos_motivos As System.Windows.Forms.MenuItem
    Friend WithEvents dt_fecha_movimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dg_listado_movimientos As System.Windows.Forms.DataGrid
    Friend WithEvents txt_existencia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents StatusBar2 As System.Windows.Forms.StatusBar
    Friend WithEvents sb_grabo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sb_fecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents btn_impresion As System.Windows.Forms.Button
    Friend WithEvents btn_kardex As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_imei As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmb_usuario As System.Windows.Forms.ComboBox
    Friend WithEvents chk_generar As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_minimo As System.Windows.Forms.Label
    Friend WithEvents txt_minimo As System.Windows.Forms.TextBox
    Friend WithEvents cmb_filtro_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_filtro As System.Windows.Forms.Button
    Friend WithEvents btn_word As System.Windows.Forms.Button
    Friend WithEvents btn_categoria_movimiento As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmb_filtro_categoria_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents cmb_rep_listado As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_rep_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_rep_ubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_rep_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btn_rep_generar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_rep_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dg_software As System.Windows.Forms.DataGrid
    Friend WithEvents dg_caracteristicas As System.Windows.Forms.DataGrid
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents m_insumos_software As System.Windows.Forms.MenuItem
    Friend WithEvents m_insumos_caracteristicas As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insumos_activos))
        Me.menu_insumos = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.m_insumos_categoria = New System.Windows.Forms.MenuItem
        Me.m_insumos_tipos_activos = New System.Windows.Forms.MenuItem
        Me.m_insumos_marcas = New System.Windows.Forms.MenuItem
        Me.m_insumos_modelos = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.m_insumos_motivos = New System.Windows.Forms.MenuItem
        Me.m_insumos_software = New System.Windows.Forms.MenuItem
        Me.m_insumos_caracteristicas = New System.Windows.Forms.MenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_minimo = New System.Windows.Forms.TextBox
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_existencia = New System.Windows.Forms.TextBox
        Me.lbl_minimo = New System.Windows.Forms.Label
        Me.cmb_categoria = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chk_generar = New System.Windows.Forms.CheckBox
        Me.dg_software = New System.Windows.Forms.DataGrid
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.panel1 = New System.Windows.Forms.StatusBarPanel
        Me.panel2 = New System.Windows.Forms.StatusBarPanel
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.dg_insumos_asociados = New System.Windows.Forms.DataGrid
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_imei = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmb_modelo = New System.Windows.Forms.ComboBox
        Me.cmb_marca = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_serie = New System.Windows.Forms.TextBox
        Me.dg_caracteristicas = New System.Windows.Forms.DataGrid
        Me.Label25 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_filtro = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmb_filtro_categoria = New System.Windows.Forms.ComboBox
        Me.btn_kardex = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.dg_listado_insumos = New System.Windows.Forms.DataGrid
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btn_word = New System.Windows.Forms.Button
        Me.btn_impresion = New System.Windows.Forms.Button
        Me.StatusBar2 = New System.Windows.Forms.StatusBar
        Me.sb_grabo = New System.Windows.Forms.StatusBarPanel
        Me.sb_fecha = New System.Windows.Forms.StatusBarPanel
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmb_usuario = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.dt_fecha_movimiento = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmb_motivo_movimiento = New System.Windows.Forms.ComboBox
        Me.cmb_tipo_movimiento = New System.Windows.Forms.ComboBox
        Me.btn_nuevo_movimiento = New System.Windows.Forms.Button
        Me.btn_guardar_movimiento = New System.Windows.Forms.Button
        Me.txt_comentarios = New System.Windows.Forms.TextBox
        Me.dg_detalle_movimiento = New System.Windows.Forms.DataGrid
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.btn_categoria_movimiento = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmb_filtro_categoria_movimiento = New System.Windows.Forms.ComboBox
        Me.dg_listado_movimientos = New System.Windows.Forms.DataGrid
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmb_rep_listado = New System.Windows.Forms.ComboBox
        Me.cmb_rep_ubicacion = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmb_rep_categoria = New System.Windows.Forms.ComboBox
        Me.dtp_rep_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_rep_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.btn_rep_generar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_software, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_insumos_asociados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_caracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_listado_insumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.sb_grabo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sb_fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_movimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dg_listado_movimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_insumos
        '
        Me.menu_insumos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.m_insumos_categoria, Me.m_insumos_tipos_activos, Me.m_insumos_marcas, Me.m_insumos_modelos, Me.MenuItem5, Me.m_insumos_motivos, Me.m_insumos_software, Me.m_insumos_caracteristicas})
        Me.MenuItem1.Text = "Mantenimiento"
        '
        'm_insumos_categoria
        '
        Me.m_insumos_categoria.Index = 0
        Me.m_insumos_categoria.Text = "Categorias"
        '
        'm_insumos_tipos_activos
        '
        Me.m_insumos_tipos_activos.Index = 1
        Me.m_insumos_tipos_activos.Text = "Tipos Activos"
        '
        'm_insumos_marcas
        '
        Me.m_insumos_marcas.Index = 2
        Me.m_insumos_marcas.Text = "Marcas"
        '
        'm_insumos_modelos
        '
        Me.m_insumos_modelos.Index = 3
        Me.m_insumos_modelos.Text = "Modelos"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.Text = "Proveedores"
        '
        'm_insumos_motivos
        '
        Me.m_insumos_motivos.Index = 5
        Me.m_insumos_motivos.Text = "Motivos"
        '
        'm_insumos_software
        '
        Me.m_insumos_software.Index = 6
        Me.m_insumos_software.Text = "Software"
        '
        'm_insumos_caracteristicas
        '
        Me.m_insumos_caracteristicas.Index = 7
        Me.m_insumos_caracteristicas.Text = "Caracteristicas"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(909, 593)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.StatusBar1)
        Me.TabPage1.Controls.Add(Me.lbl_codigo)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(901, 564)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_minimo)
        Me.GroupBox4.Controls.Add(Me.cmb_tipos)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txt_existencia)
        Me.GroupBox4.Controls.Add(Me.lbl_minimo)
        Me.GroupBox4.Controls.Add(Me.cmb_categoria)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 128)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(416, 114)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        '
        'txt_minimo
        '
        Me.txt_minimo.Location = New System.Drawing.Point(123, 82)
        Me.txt_minimo.Name = "txt_minimo"
        Me.txt_minimo.Size = New System.Drawing.Size(130, 22)
        Me.txt_minimo.TabIndex = 7
        Me.txt_minimo.Text = "0"
        Me.txt_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmb_tipos
        '
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.Location = New System.Drawing.Point(123, 50)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(130, 24)
        Me.cmb_tipos.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Categoria"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(258, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Existencia"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Tipo"
        '
        'txt_existencia
        '
        Me.txt_existencia.ForeColor = System.Drawing.Color.Red
        Me.txt_existencia.Location = New System.Drawing.Point(333, 82)
        Me.txt_existencia.Name = "txt_existencia"
        Me.txt_existencia.ReadOnly = True
        Me.txt_existencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_existencia.Size = New System.Drawing.Size(67, 22)
        Me.txt_existencia.TabIndex = 25
        '
        'lbl_minimo
        '
        Me.lbl_minimo.AutoSize = True
        Me.lbl_minimo.Location = New System.Drawing.Point(14, 85)
        Me.lbl_minimo.Name = "lbl_minimo"
        Me.lbl_minimo.Size = New System.Drawing.Size(50, 16)
        Me.lbl_minimo.TabIndex = 28
        Me.lbl_minimo.Text = "Minimo"
        '
        'cmb_categoria
        '
        Me.cmb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_categoria.Location = New System.Drawing.Point(123, 18)
        Me.cmb_categoria.Name = "cmb_categoria"
        Me.cmb_categoria.Size = New System.Drawing.Size(130, 24)
        Me.cmb_categoria.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txt_codigo)
        Me.GroupBox3.Controls.Add(Me.txt_descripcion)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.chk_generar)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 113)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Codigo"
        '
        'txt_codigo
        '
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(123, 23)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(145, 22)
        Me.txt_codigo.TabIndex = 0
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(123, 53)
        Me.txt_descripcion.Multiline = True
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(277, 48)
        Me.txt_descripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Descripcion"
        '
        'chk_generar
        '
        Me.chk_generar.AutoSize = True
        Me.chk_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_generar.Location = New System.Drawing.Point(282, 24)
        Me.chk_generar.Name = "chk_generar"
        Me.chk_generar.Size = New System.Drawing.Size(70, 20)
        Me.chk_generar.TabIndex = 27
        Me.chk_generar.Text = "Generar"
        '
        'dg_software
        '
        Me.dg_software.CaptionVisible = False
        Me.dg_software.DataMember = ""
        Me.dg_software.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_software.Location = New System.Drawing.Point(126, 18)
        Me.dg_software.Name = "dg_software"
        Me.dg_software.Size = New System.Drawing.Size(290, 189)
        Me.dg_software.TabIndex = 29
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 542)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.panel1, Me.panel2})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(901, 22)
        Me.StatusBar1.TabIndex = 24
        Me.StatusBar1.Text = "StatusBar1"
        '
        'panel1
        '
        Me.panel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.panel1.Name = "panel1"
        Me.panel1.Width = 442
        '
        'panel2
        '
        Me.panel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.panel2.Name = "panel2"
        Me.panel2.Width = 442
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Location = New System.Drawing.Point(447, 10)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(100, 23)
        Me.lbl_codigo.TabIndex = 23
        Me.lbl_codigo.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(180, 21)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 75)
        Me.btn_guardar.TabIndex = 20
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Modelos"
        '
        'dg_insumos_asociados
        '
        Me.dg_insumos_asociados.CaptionVisible = False
        Me.dg_insumos_asociados.DataMember = ""
        Me.dg_insumos_asociados.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_insumos_asociados.Location = New System.Drawing.Point(123, 21)
        Me.dg_insumos_asociados.Name = "dg_insumos_asociados"
        Me.dg_insumos_asociados.Size = New System.Drawing.Size(277, 138)
        Me.dg_insumos_asociados.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Software"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txt_imei)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmb_modelo)
        Me.GroupBox1.Controls.Add(Me.cmb_marca)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_serie)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 107)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 16)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Imei"
        '
        'txt_imei
        '
        Me.txt_imei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_imei.Location = New System.Drawing.Point(123, 46)
        Me.txt_imei.Name = "txt_imei"
        Me.txt_imei.Size = New System.Drawing.Size(277, 22)
        Me.txt_imei.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(258, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Modelo"
        '
        'cmb_modelo
        '
        Me.cmb_modelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_modelo.DropDownWidth = 120
        Me.cmb_modelo.Location = New System.Drawing.Point(317, 76)
        Me.cmb_modelo.Name = "cmb_modelo"
        Me.cmb_modelo.Size = New System.Drawing.Size(83, 24)
        Me.cmb_modelo.TabIndex = 7
        '
        'cmb_marca
        '
        Me.cmb_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_marca.Location = New System.Drawing.Point(123, 76)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(130, 24)
        Me.cmb_marca.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Marca"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "No. Serie"
        '
        'txt_serie
        '
        Me.txt_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_serie.Location = New System.Drawing.Point(123, 16)
        Me.txt_serie.Name = "txt_serie"
        Me.txt_serie.Size = New System.Drawing.Size(277, 22)
        Me.txt_serie.TabIndex = 1
        '
        'dg_caracteristicas
        '
        Me.dg_caracteristicas.CaptionVisible = False
        Me.dg_caracteristicas.DataMember = ""
        Me.dg_caracteristicas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_caracteristicas.Location = New System.Drawing.Point(126, 224)
        Me.dg_caracteristicas.Name = "dg_caracteristicas"
        Me.dg_caracteristicas.Size = New System.Drawing.Size(290, 168)
        Me.dg_caracteristicas.TabIndex = 29
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 224)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 16)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Caracteristicas"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btn_filtro)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.cmb_filtro_categoria)
        Me.TabPage2.Controls.Add(Me.btn_kardex)
        Me.TabPage2.Controls.Add(Me.btn_nuevo)
        Me.TabPage2.Controls.Add(Me.dg_listado_insumos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(901, 564)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado Activos & Insumos"
        '
        'btn_filtro
        '
        Me.btn_filtro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_filtro.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_filtro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_filtro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_filtro.ForeColor = System.Drawing.Color.White
        Me.btn_filtro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_filtro.ImageIndex = 1
        Me.btn_filtro.ImageList = Me.ImageList1
        Me.btn_filtro.Location = New System.Drawing.Point(398, 12)
        Me.btn_filtro.Name = "btn_filtro"
        Me.btn_filtro.Size = New System.Drawing.Size(75, 71)
        Me.btn_filtro.TabIndex = 16
        Me.btn_filtro.Text = "Filtrar"
        Me.btn_filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_filtro.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 16)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Categoria"
        '
        'cmb_filtro_categoria
        '
        Me.cmb_filtro_categoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_filtro_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_filtro_categoria.Location = New System.Drawing.Point(83, 35)
        Me.cmb_filtro_categoria.Name = "cmb_filtro_categoria"
        Me.cmb_filtro_categoria.Size = New System.Drawing.Size(294, 24)
        Me.cmb_filtro_categoria.TabIndex = 3
        '
        'btn_kardex
        '
        Me.btn_kardex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_kardex.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_kardex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_kardex.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kardex.ForeColor = System.Drawing.Color.White
        Me.btn_kardex.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_kardex.ImageIndex = 3
        Me.btn_kardex.ImageList = Me.ImageList1
        Me.btn_kardex.Location = New System.Drawing.Point(716, 12)
        Me.btn_kardex.Name = "btn_kardex"
        Me.btn_kardex.Size = New System.Drawing.Size(75, 71)
        Me.btn_kardex.TabIndex = 2
        Me.btn_kardex.Text = "Kardex"
        Me.btn_kardex.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_kardex.UseVisualStyleBackColor = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 2
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(812, 12)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 71)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'dg_listado_insumos
        '
        Me.dg_listado_insumos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado_insumos.CaptionVisible = False
        Me.dg_listado_insumos.DataMember = ""
        Me.dg_listado_insumos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_listado_insumos.Location = New System.Drawing.Point(8, 97)
        Me.dg_listado_insumos.Name = "dg_listado_insumos"
        Me.dg_listado_insumos.ReadOnly = True
        Me.dg_listado_insumos.Size = New System.Drawing.Size(885, 455)
        Me.dg_listado_insumos.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.GroupBox8)
        Me.TabPage3.Controls.Add(Me.btn_word)
        Me.TabPage3.Controls.Add(Me.btn_impresion)
        Me.TabPage3.Controls.Add(Me.StatusBar2)
        Me.TabPage3.Controls.Add(Me.btn_nuevo_movimiento)
        Me.TabPage3.Controls.Add(Me.btn_guardar_movimiento)
        Me.TabPage3.Controls.Add(Me.dg_detalle_movimiento)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(901, 564)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Movimientos"
        '
        'btn_word
        '
        Me.btn_word.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_word.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_word.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_word.ForeColor = System.Drawing.Color.White
        Me.btn_word.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_word.ImageIndex = 5
        Me.btn_word.ImageList = Me.ImageList1
        Me.btn_word.Location = New System.Drawing.Point(805, 100)
        Me.btn_word.Name = "btn_word"
        Me.btn_word.Size = New System.Drawing.Size(82, 71)
        Me.btn_word.TabIndex = 17
        Me.btn_word.Text = "Word"
        Me.btn_word.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_word.UseVisualStyleBackColor = False
        '
        'btn_impresion
        '
        Me.btn_impresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_impresion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_impresion.ForeColor = System.Drawing.Color.White
        Me.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_impresion.ImageIndex = 4
        Me.btn_impresion.ImageList = Me.ImageList1
        Me.btn_impresion.Location = New System.Drawing.Point(805, 11)
        Me.btn_impresion.Name = "btn_impresion"
        Me.btn_impresion.Size = New System.Drawing.Size(82, 71)
        Me.btn_impresion.TabIndex = 16
        Me.btn_impresion.Text = "Impresion"
        Me.btn_impresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_impresion.UseVisualStyleBackColor = False
        '
        'StatusBar2
        '
        Me.StatusBar2.Location = New System.Drawing.Point(0, 542)
        Me.StatusBar2.Name = "StatusBar2"
        Me.StatusBar2.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sb_grabo, Me.sb_fecha})
        Me.StatusBar2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar2.ShowPanels = True
        Me.StatusBar2.Size = New System.Drawing.Size(901, 22)
        Me.StatusBar2.TabIndex = 12
        Me.StatusBar2.Text = "StatusBar2"
        '
        'sb_grabo
        '
        Me.sb_grabo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sb_grabo.Name = "sb_grabo"
        Me.sb_grabo.Width = 442
        '
        'sb_fecha
        '
        Me.sb_fecha.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sb_fecha.Name = "sb_fecha"
        Me.sb_fecha.Width = 442
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 16)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Usuario"
        '
        'cmb_usuario
        '
        Me.cmb_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_usuario.ItemHeight = 16
        Me.cmb_usuario.Location = New System.Drawing.Point(126, 78)
        Me.cmb_usuario.Name = "cmb_usuario"
        Me.cmb_usuario.Size = New System.Drawing.Size(312, 24)
        Me.cmb_usuario.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(470, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Numero"
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.ForeColor = System.Drawing.Color.Red
        Me.txt_numero.Location = New System.Drawing.Point(542, 47)
        Me.txt_numero.MaxLength = 8
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_numero.Size = New System.Drawing.Size(98, 22)
        Me.txt_numero.TabIndex = 8
        Me.txt_numero.Text = "Numero"
        Me.txt_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dt_fecha_movimiento
        '
        Me.dt_fecha_movimiento.Enabled = False
        Me.dt_fecha_movimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fecha_movimiento.Location = New System.Drawing.Point(542, 15)
        Me.dt_fecha_movimiento.Name = "dt_fecha_movimiento"
        Me.dt_fecha_movimiento.Size = New System.Drawing.Size(98, 22)
        Me.dt_fecha_movimiento.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Observaciones"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(470, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Fecha"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Motivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo Movimiento"
        '
        'cmb_motivo_movimiento
        '
        Me.cmb_motivo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_motivo_movimiento.Location = New System.Drawing.Point(126, 46)
        Me.cmb_motivo_movimiento.Name = "cmb_motivo_movimiento"
        Me.cmb_motivo_movimiento.Size = New System.Drawing.Size(312, 24)
        Me.cmb_motivo_movimiento.TabIndex = 3
        '
        'cmb_tipo_movimiento
        '
        Me.cmb_tipo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_movimiento.Location = New System.Drawing.Point(126, 14)
        Me.cmb_tipo_movimiento.Name = "cmb_tipo_movimiento"
        Me.cmb_tipo_movimiento.Size = New System.Drawing.Size(192, 24)
        Me.cmb_tipo_movimiento.TabIndex = 1
        '
        'btn_nuevo_movimiento
        '
        Me.btn_nuevo_movimiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_movimiento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_movimiento.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_movimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_movimiento.ImageIndex = 2
        Me.btn_nuevo_movimiento.ImageList = Me.ImageList1
        Me.btn_nuevo_movimiento.Location = New System.Drawing.Point(705, 11)
        Me.btn_nuevo_movimiento.Name = "btn_nuevo_movimiento"
        Me.btn_nuevo_movimiento.Size = New System.Drawing.Size(82, 71)
        Me.btn_nuevo_movimiento.TabIndex = 10
        Me.btn_nuevo_movimiento.Text = "Nuevo"
        Me.btn_nuevo_movimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_movimiento.UseVisualStyleBackColor = False
        '
        'btn_guardar_movimiento
        '
        Me.btn_guardar_movimiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_movimiento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_movimiento.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_movimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_movimiento.ImageIndex = 0
        Me.btn_guardar_movimiento.ImageList = Me.ImageList1
        Me.btn_guardar_movimiento.Location = New System.Drawing.Point(705, 100)
        Me.btn_guardar_movimiento.Name = "btn_guardar_movimiento"
        Me.btn_guardar_movimiento.Size = New System.Drawing.Size(82, 71)
        Me.btn_guardar_movimiento.TabIndex = 11
        Me.btn_guardar_movimiento.Text = "Guardar"
        Me.btn_guardar_movimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_movimiento.UseVisualStyleBackColor = False
        '
        'txt_comentarios
        '
        Me.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios.Location = New System.Drawing.Point(126, 110)
        Me.txt_comentarios.Multiline = True
        Me.txt_comentarios.Name = "txt_comentarios"
        Me.txt_comentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentarios.Size = New System.Drawing.Size(312, 40)
        Me.txt_comentarios.TabIndex = 7
        '
        'dg_detalle_movimiento
        '
        Me.dg_detalle_movimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_detalle_movimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_detalle_movimiento.CaptionVisible = False
        Me.dg_detalle_movimiento.DataMember = ""
        Me.dg_detalle_movimiento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_movimiento.Location = New System.Drawing.Point(12, 182)
        Me.dg_detalle_movimiento.Name = "dg_detalle_movimiento"
        Me.dg_detalle_movimiento.Size = New System.Drawing.Size(877, 346)
        Me.dg_detalle_movimiento.TabIndex = 9
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.btn_categoria_movimiento)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.cmb_filtro_categoria_movimiento)
        Me.TabPage4.Controls.Add(Me.dg_listado_movimientos)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(901, 564)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Listado Movimientos"
        '
        'btn_categoria_movimiento
        '
        Me.btn_categoria_movimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_categoria_movimiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_categoria_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_categoria_movimiento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_categoria_movimiento.ForeColor = System.Drawing.Color.White
        Me.btn_categoria_movimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_categoria_movimiento.ImageIndex = 1
        Me.btn_categoria_movimiento.ImageList = Me.ImageList1
        Me.btn_categoria_movimiento.Location = New System.Drawing.Point(606, 12)
        Me.btn_categoria_movimiento.Name = "btn_categoria_movimiento"
        Me.btn_categoria_movimiento.Size = New System.Drawing.Size(77, 73)
        Me.btn_categoria_movimiento.TabIndex = 19
        Me.btn_categoria_movimiento.Text = "Filtrar"
        Me.btn_categoria_movimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_categoria_movimiento.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(218, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 16)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Categoria"
        '
        'cmb_filtro_categoria_movimiento
        '
        Me.cmb_filtro_categoria_movimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_filtro_categoria_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_filtro_categoria_movimiento.Location = New System.Drawing.Point(287, 36)
        Me.cmb_filtro_categoria_movimiento.Name = "cmb_filtro_categoria_movimiento"
        Me.cmb_filtro_categoria_movimiento.Size = New System.Drawing.Size(294, 24)
        Me.cmb_filtro_categoria_movimiento.TabIndex = 17
        '
        'dg_listado_movimientos
        '
        Me.dg_listado_movimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado_movimientos.CaptionVisible = False
        Me.dg_listado_movimientos.DataMember = ""
        Me.dg_listado_movimientos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_listado_movimientos.Location = New System.Drawing.Point(8, 96)
        Me.dg_listado_movimientos.Name = "dg_listado_movimientos"
        Me.dg_listado_movimientos.ReadOnly = True
        Me.dg_listado_movimientos.Size = New System.Drawing.Size(885, 456)
        Me.dg_listado_movimientos.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.GroupBox2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(901, 564)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Reportes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmb_rep_listado)
        Me.GroupBox2.Controls.Add(Me.btn_rep_generar)
        Me.GroupBox2.Controls.Add(Me.cmb_rep_ubicacion)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.cmb_rep_categoria)
        Me.GroupBox2.Controls.Add(Me.dtp_rep_fecha_final)
        Me.GroupBox2.Controls.Add(Me.dtp_rep_fecha_inicio)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(38, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(824, 139)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametros"
        '
        'cmb_rep_listado
        '
        Me.cmb_rep_listado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_rep_listado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rep_listado.DropDownWidth = 350
        Me.cmb_rep_listado.Items.AddRange(New Object() {"Inventario de Insumos Por Categoria", "Inventario y Minimos de Insumos Por Categoria", "Toma de Inventario Fisico Por Categoria", "Kardex Por Categoria", "Movimientos Por Departamento Por Categoria y Fechas"})
        Me.cmb_rep_listado.Location = New System.Drawing.Point(161, 30)
        Me.cmb_rep_listado.Name = "cmb_rep_listado"
        Me.cmb_rep_listado.Size = New System.Drawing.Size(312, 24)
        Me.cmb_rep_listado.TabIndex = 0
        '
        'cmb_rep_ubicacion
        '
        Me.cmb_rep_ubicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_rep_ubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rep_ubicacion.Location = New System.Drawing.Point(161, 94)
        Me.cmb_rep_ubicacion.Name = "cmb_rep_ubicacion"
        Me.cmb_rep_ubicacion.Size = New System.Drawing.Size(312, 24)
        Me.cmb_rep_ubicacion.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(492, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 16)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Fecha Inicio"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(492, 81)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 16)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Fecha Final"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 33)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 16)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Nombre de Reporte"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(22, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 16)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Categoria"
        '
        'cmb_rep_categoria
        '
        Me.cmb_rep_categoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_rep_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rep_categoria.Location = New System.Drawing.Point(161, 62)
        Me.cmb_rep_categoria.Name = "cmb_rep_categoria"
        Me.cmb_rep_categoria.Size = New System.Drawing.Size(312, 24)
        Me.cmb_rep_categoria.TabIndex = 1
        '
        'dtp_rep_fecha_final
        '
        Me.dtp_rep_fecha_final.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_rep_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_rep_fecha_final.Location = New System.Drawing.Point(576, 78)
        Me.dtp_rep_fecha_final.Name = "dtp_rep_fecha_final"
        Me.dtp_rep_fecha_final.Size = New System.Drawing.Size(95, 22)
        Me.dtp_rep_fecha_final.TabIndex = 4
        '
        'dtp_rep_fecha_inicio
        '
        Me.dtp_rep_fecha_inicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_rep_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_rep_fecha_inicio.Location = New System.Drawing.Point(576, 48)
        Me.dtp_rep_fecha_inicio.Name = "dtp_rep_fecha_inicio"
        Me.dtp_rep_fecha_inicio.Size = New System.Drawing.Size(95, 22)
        Me.dtp_rep_fecha_inicio.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(22, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 16)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Ubicacion"
        '
        'btn_rep_generar
        '
        Me.btn_rep_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_rep_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_rep_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_rep_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_rep_generar.ForeColor = System.Drawing.Color.White
        Me.btn_rep_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_rep_generar.ImageIndex = 6
        Me.btn_rep_generar.ImageList = Me.ImageList1
        Me.btn_rep_generar.Location = New System.Drawing.Point(716, 37)
        Me.btn_rep_generar.Name = "btn_rep_generar"
        Me.btn_rep_generar.Size = New System.Drawing.Size(86, 75)
        Me.btn_rep_generar.TabIndex = 6
        Me.btn_rep_generar.Text = "Generar"
        Me.btn_rep_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_rep_generar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "filter_data.png")
        Me.ImageList1.Images.SetKeyName(2, "3.png")
        Me.ImageList1.Images.SetKeyName(3, "detail.png")
        Me.ImageList1.Images.SetKeyName(4, "print_48.png")
        Me.ImageList1.Images.SetKeyName(5, "word.png")
        Me.ImageList1.Images.SetKeyName(6, "engranaje1.png")
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dg_insumos_asociados)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 361)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(416, 170)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.dg_software)
        Me.GroupBox6.Controls.Add(Me.dg_caracteristicas)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Location = New System.Drawing.Point(450, 128)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(436, 403)
        Me.GroupBox6.TabIndex = 33
        Me.GroupBox6.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btn_guardar)
        Me.GroupBox7.Location = New System.Drawing.Point(450, 9)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(436, 113)
        Me.GroupBox7.TabIndex = 34
        Me.GroupBox7.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.txt_comentarios)
        Me.GroupBox8.Controls.Add(Me.cmb_tipo_movimiento)
        Me.GroupBox8.Controls.Add(Me.cmb_motivo_movimiento)
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.cmb_usuario)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.txt_numero)
        Me.GroupBox8.Controls.Add(Me.dt_fecha_movimiento)
        Me.GroupBox8.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(653, 168)
        Me.GroupBox8.TabIndex = 18
        Me.GroupBox8.TabStop = False
        '
        'frm_insumos_activos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(909, 593)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu = Me.menu_insumos
        Me.Name = "frm_insumos_activos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insumos & Activos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_software, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_insumos_asociados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_caracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dg_listado_insumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.sb_grabo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sb_fecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_movimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dg_listado_movimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        otrans.open()

        Try
            ls_sql = "call pa_sel_um_act_tipo_producto ()"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_tipos.DataSource = dt
            Me.cmb_tipos.DisplayMember = "descripcion"
            Me.cmb_tipos.ValueMember = "cod_tipo_producto"

            ls_sql = "call pa_sel_um_act_marca ()"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_marca.DataSource = dt
            Me.cmb_marca.DisplayMember = "descripcion"
            Me.cmb_marca.ValueMember = "cod_marca"

            ls_sql = "call pa_sel_um_act_marca_modelo (null)"
            dt_modelos = otrans.Obtiene(ls_sql)

            dt_modelos.DefaultView.RowFilter = "cod_marca = " & Me.cmb_marca.SelectedValue.ToString
            Me.cmb_modelo.DataSource = dt_modelos
            Me.cmb_modelo.DisplayMember = "descripcion"
            Me.cmb_modelo.ValueMember = "cod_marca_modelo"

            ls_sql = "call pa_sel_um_act_categoria ()"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_categoria.DataSource = dt
            Me.cmb_categoria.DisplayMember = "descripcion"
            Me.cmb_categoria.ValueMember = "cod_categoria"

            Me.cmb_filtro_categoria.DataSource = dt
            Me.cmb_filtro_categoria.DisplayMember = "descripcion"
            Me.cmb_filtro_categoria.ValueMember = "cod_categoria"

            Me.cmb_filtro_categoria_movimiento.DataSource = dt
            Me.cmb_filtro_categoria_movimiento.DisplayMember = "descripcion"
            Me.cmb_filtro_categoria_movimiento.ValueMember = "cod_categoria"

            Me.cmb_rep_categoria.DataSource = dt
            Me.cmb_rep_categoria.DisplayMember = "descripcion"
            Me.cmb_rep_categoria.ValueMember = "cod_categoria"

            ls_sql = "call pa_var_um_act_marca_modelo()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_marca_modelo"
            ds_insumos.Tables.Add(dt.Copy)

            ls_sql = "call pa_sel_um_act_software ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_software"
            ds_insumos.Tables.Add(dt.Copy)

            ls_sql = "call pa_sel_um_act_caracteristica ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_caracteristica"
            ds_insumos.Tables.Add(dt.Copy)

            Dim otrans_flex As New Transaccional.Conexion("flexline")
            otrans_flex.open()
            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_UBICACION'"
            dt = otrans_flex.Obtiene(ls_sql)

            otrans_flex.close()
            otrans_flex = Nothing

            Me.cmb_rep_ubicacion.DataSource = dt
            Me.cmb_rep_ubicacion.DisplayMember = "CODIGO"
            Me.cmb_rep_ubicacion.ValueMember = "CODIGO"

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub crear_estructura()
        Dim dt As New DataTable("modelos_aplicados")

        dt.Columns.Add(New DataColumn("marca_modelo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("unidades", GetType(Integer)))
        ds_insumos.Tables.Add(dt.Copy)

        dt = New DataTable("software_equipo")
        dt.Columns.Add(New DataColumn("cod_software", GetType(Integer)))
        dt.Columns.Add(New DataColumn("licencia", GetType(String)))
        ds_insumos.Tables.Add(dt.Copy)

        dt = New DataTable("caracteristicas_equipo")
        dt.Columns.Add(New DataColumn("cod_caracteristica", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        ds_insumos.Tables.Add(dt.Copy)

        Me.dg_insumos_asociados.DataSource = ds_insumos.Tables("modelos_aplicados")
        Me.dg_software.DataSource = ds_insumos.Tables("software_equipo")
        Me.dg_caracteristicas.DataSource = ds_insumos.Tables("caracteristicas_equipo")

        Combo_Modelos_Aplicados()
        Combo_software_equipo()
        Combo_caracteristicas_equipo()
    End Sub

    Private Sub Combo_Modelos_Aplicados()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "modelos_aplicados"

        Dim dt As DataTable = ds_insumos.Tables("telefono_cliente")
        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "marca_modelo"
        ComboTextCol.HeaderText = "Modelo que Aplica"
        ComboTextCol.Width = 150
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_marca_modelo").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_marca_modelo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "unidades"
        TextCol.HeaderText = "Unidades"
        TextCol.Width = 100
        TextCol.ReadOnly = True

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_insumos_asociados.TableStyles.Clear()
        Me.dg_insumos_asociados.TableStyles.Add(tableStyle)

    End Sub


    Private Sub Combo_software_equipo()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "software_equipo"


        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_software"
        ComboTextCol.HeaderText = "Software"
        ComboTextCol.Width = 125
        ComboTextCol.ColumnComboBox.DropDownWidth = 200
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_software").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_software"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "licencia"
        TextCol.HeaderText = "Licencia"
        TextCol.Width = 150
        'TextCol.ReadOnly = False

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_software.TableStyles.Clear()
        Me.dg_software.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Combo_caracteristicas_equipo()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "caracteristicas_equipo"


        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_caracteristica"
        ComboTextCol.HeaderText = "Caracteristica"
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_caracteristica").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_caracteristica"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "descripcion"
        TextCol.HeaderText = "Descripcion"
        TextCol.Width = 150
        'TextCol.ReadOnly = False

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_caracteristicas.TableStyles.Clear()
        Me.dg_caracteristicas.TableStyles.Add(tableStyle)

    End Sub


    Private Sub Guardar_Informacion()
        Dim ls_sql As String

        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            If Me.chk_generar.CheckState = CheckState.Checked Then
                'Debo Generar El Correlativo
                ls_sql = "call pa_var_um_act_producto_correlativo (" & _
                            Me.cmb_categoria.SelectedValue.ToString & ")"

                dt = otrans.Obtiene(ls_sql)
                If dt.Rows(0).Item("numero").ToString.Length = 7 Then
                    ls_sql = dt.Rows(0).Item("numero").ToString.Substring(3, 4) + 1
                Else
                    ls_sql = dt.Rows(0).Item("numero") + 1
                End If


                Me.txt_codigo.Text = Me.cmb_categoria.Text.ToString.Substring(0, 3).ToUpper & ls_sql.ToString.PadLeft(4, "0")

            End If

            ls_sql = "call pa_ins_um_act_producto ('" & Me.txt_codigo.Text & "','" & _
                    Me.txt_descripcion.Text & "'," & Me.cmb_tipos.SelectedValue.ToString & "," & _
                    Me.cmb_categoria.SelectedValue.ToString & ",'" & _
                    Me.txt_serie.Text & "','" & _
                    Me.txt_imei.Text & "'," & _
                    Me.txt_minimo.Text & ","

            If Me.cmb_marca.Text.Trim.Length > 0 Then
                ls_sql = ls_sql & Me.cmb_modelo.SelectedValue.ToString & ",'"
            Else
                ls_sql = ls_sql & "null,'"
            End If

            ls_sql = ls_sql & gs_usuario & "')"

            otrans.Ingresa(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                dt = otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                'li_cliente = otabla.Rows(0).Item("newid").ToString
                Actualizar_modelos_relacionados(dt.Rows(0).Item("newid").ToString)
                Actualizar_software(Me.lbl_codigo.Text)
                Actualizar_Caracteristicas(Me.lbl_codigo.Text)
                MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.btn_guardar.Text = "Actualizar"
        End Try

    End Sub

    Private Sub Actualizar_modelos_relacionados(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_modelo (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("modelos_aplicados").Rows
                ls_sql = "call pa_ins_um_act_producto_modelo (" & cod_producto.ToString & "," & _
                         dr.Item("marca_modelo").ToString & ")"

                otrans.Ingresa(ls_sql)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Actualizar_software(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_software (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("software_equipo").Rows
                ls_sql = "call pa_ins_um_act_producto_software (" & cod_producto.ToString & "," & _
                         dr.Item("cod_software").ToString & ",'" & dr.Item("licencia").ToString & "')"

                otrans.Ingresa(ls_sql)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Actualizar_Caracteristicas(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_caracteristica (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("caracteristicas_equipo").Rows
                ls_sql = "call pa_ins_um_act_producto_caracteristica (" & cod_producto.ToString & "," & _
                         dr.Item("cod_caracteristica").ToString & ",'" & dr.Item("descripcion").ToString & "')"
                otrans.Ingresa(ls_sql)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Modificar_Informacion()
        Dim ls_sql As String

        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_upd_um_act_producto (" & Me.lbl_codigo.Text & ",'" & Me.txt_codigo.Text & "','" & _
                    Me.txt_descripcion.Text & "'," & Me.cmb_tipos.SelectedValue.ToString & "," & _
                    Me.cmb_categoria.SelectedValue.ToString & ",'" & _
                    Me.txt_serie.Text & "','" & _
                    Me.txt_imei.Text & "'," & _
                    Me.txt_minimo.Text & ","

            If Me.cmb_marca.Text.Trim.Length > 0 Then
                ls_sql = ls_sql & Me.cmb_modelo.SelectedValue.ToString & ",'"
            Else
                ls_sql = ls_sql & "null,'"
            End If

            ls_sql = ls_sql & gs_usuario & "')"

            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'dt = otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                'li_cliente = otabla.Rows(0).Item("newid").ToString
                Actualizar_modelos_relacionados(Me.lbl_codigo.Text)
                Actualizar_software(Me.lbl_codigo.Text)
                Actualizar_Caracteristicas(Me.lbl_codigo.Text)
                MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_Grid()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim clsgen As New ClasesGenerales.General
        Try
            ds_insumos.Tables.Remove("listado_activos")
            ds_insumos.Tables.Remove("listado_movimientos")
        Catch ex As Exception
        End Try

        ls_sql = "call pa_sel_um_act_producto (null)"
        Try
            otrans.open()

            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "listado_activos"
            ds_insumos.Tables.Add(dt.Copy)

            Me.dg_listado_insumos.DataSource = ds_insumos.Tables("listado_activos")
            clsgen.Alinea_Grid(ds_insumos.Tables("listado_activos"), Me.dg_listado_insumos, "listado_activos", 4, 150, 0, True, False, "", True, "")

            ls_sql = "call pa_sel_um_act_movimiento ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "listado_movimientos"
            ds_insumos.Tables.Add(dt.Copy)

            Me.dg_listado_movimientos.DataSource = ds_insumos.Tables("listado_movimientos")
            clsgen.Alinea_Grid(ds_insumos.Tables("listado_movimientos"), Me.dg_listado_movimientos, "listado_movimientos", 1, 150, 0, False, False, "", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub llenar_registro(ByVal _pcod_producto As Short, ByVal _pdt As DataTable)
        Limpiar_Forma()

        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow

        dt = _pdt.Copy

        dt.DefaultView.RowFilter = "cod_producto = " & _pcod_producto

        Me.cmb_marca.Text = ""
        dr = dt.DefaultView(0).Row
        Me.txt_serie.Text = dr.Item("serie").ToString
        Me.txt_codigo.Text = dr.Item("codigo")
        Me.txt_descripcion.Text = dr.Item("descripcion").ToString
        Me.txt_imei.Text = dr.Item("imei").ToString
        Me.txt_existencia.Text = dr.Item("existencia")
        Me.txt_minimo.Text = dr.Item("minimo")

        Me.cmb_categoria.SelectedValue = dr.Item("cod_categoria")


        Me.cmb_marca.SelectedValue = dr.Item("cod_marca")
        filtrar_marcas()

        Me.cmb_tipos.SelectedValue = dr.Item("cod_tipo_producto")
        Me.cmb_modelo.SelectedValue = dr.Item("cod_marca_modelo")
        Me.panel1.Text = "Usuario Grabo .: " & dr.Item("usuario_grabo") & " " & dr.Item("fecha_grabo")
        Me.panel2.Text = "Usuario Modifico .: " & dr.Item("usuario_modifico") & " " & dr.Item("fecha_modifico")

        Try

            otrans.open()
            ls_sql = "call pa_sel_um_act_producto_modelo (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows

                dr_aux = ds_insumos.Tables("modelos_aplicados").NewRow
                dr_aux.Item("marca_modelo") = dr.Item("cod_marca_modelo")
                'dr_aux.Item("unidades") = dr.Item("unidades")

                ds_insumos.Tables("modelos_aplicados").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Mostrar_Unidades_Modelo()
        Mostrar_Caracteristicas(_pcod_producto)
        Mostrar_Software(_pcod_producto)
    End Sub


    'Debo Mostrar Las Caracteristicas
    Private Sub Mostrar_Caracteristicas(ByVal _pcod_producto As Integer)

        Dim ls_sql As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ds_insumos.Tables("caracteristicas_equipo").Rows.Clear()
            ls_sql = "call pa_sel_um_act_producto_caracteristica (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)


            For Each dr_aux In dt.Rows
                dr = ds_insumos.Tables("caracteristicas_equipo").NewRow
                dr.Item("cod_caracteristica") = dr_aux.Item("cod_caracteristica")
                dr.Item("descripcion") = dr_aux.Item("descripcion").ToString

                ds_insumos.Tables("caracteristicas_equipo").Rows.Add(dr)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Software(ByVal _pcod_producto As Integer)
        Dim ls_sql As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ds_insumos.Tables("software_equipo").Rows.Clear()
            ls_sql = "call pa_sel_um_act_producto_software (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)


            For Each dr_aux In dt.Rows
                dr = ds_insumos.Tables("software_equipo").NewRow
                dr.Item("cod_software") = dr_aux.Item("cod_software")
                dr.Item("licencia") = dr_aux.Item("licencia").ToString

                ds_insumos.Tables("software_equipo").Rows.Add(dr)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Limpiar_Forma()
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_serie.Text = ""
        Me.btn_guardar.Text = "Guardar"
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_existencia.Text = 0
        Me.txt_serie.Text = ""
        Me.txt_imei.Text = ""
        ds_insumos.Tables("modelos_aplicados").Rows.Clear()

    End Sub

    Private Sub Llenar_Movimiento(ByVal _pcod_movimiento As String, ByVal _pdt As DataTable)
        Movimiento_Nuevo()

        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow

        dt = _pdt.Copy

        dt.DefaultView.RowFilter = "cod_movimiento = " & _pcod_movimiento

        dr = dt.DefaultView(0).Row
        Me.cmb_tipo_movimiento.SelectedValue = dr.Item("cod_tipo_movimiento")
        Me.cmb_motivo_movimiento.SelectedValue = dr.Item("cod_motivo_movimiento")
        Me.txt_comentarios.Text = dr.Item("observaciones").ToString
        Me.cmb_usuario.SelectedValue = dr.Item("usuario_solicito").ToString
        Me.dt_fecha_movimiento.Text = dr.Item("fecha_movimiento")
        Me.txt_numero.Text = dr.Item("cod_movimiento")
        Me.sb_grabo.Text = "Usuario Grabo .: " & dr.Item("usuario_grabo")
        Me.sb_fecha.Text = "Fecha Grabo .: " & dr.Item("fecha_grabo")

        Try

            otrans.open()
            ls_sql = "call pa_sel_um_act_movimiento_detalle (" & _pcod_movimiento.ToString & ")"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows

                dr_aux = ds_movimiento.Tables("detalle_movimiento").NewRow
                dr_aux.Item("codigo") = dr.Item("codigo")
                dr_aux.Item("descripcion") = dr.Item("descripcion")
                dr_aux.Item("cantidad") = dr.Item("cantidad")

                ds_movimiento.Tables("detalle_movimiento").Rows.Add(dr_aux)
            Next

            DatoValido(1, 0, " ")
        Catch ex As Exception
        Finally
            Me.dg_detalle_movimiento.ReadOnly = True

            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Movimiento_Nuevo()
        ds_movimiento = New DataSet

        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim otrans_sql As New Transaccional.Conexion("flexline")


        Dim ls_sql As String

        Try
            Me.txt_numero.Text = ""
            Me.txt_comentarios.Text = ""
            Me.txt_numero.Enabled = False
            Me.txt_comentarios.Enabled = True
            Me.btn_guardar_movimiento.Visible = True
            Me.cmb_tipo_movimiento.Enabled = True
            Me.cmb_motivo_movimiento.Enabled = True
            Me.cmb_usuario.Enabled = True
            Me.dt_fecha_movimiento.Value = Now
            Me.sb_grabo.Text = " "
            Me.sb_fecha.Text = " "
            Me.dg_detalle_movimiento.ReadOnly = False

            otrans.open()
            otrans_sql.open()

            ls_sql = "call pa_sel_um_act_tipo_movimiento"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_tipo_movimiento"
            ds_movimiento.Tables.Add(dt.Copy)

            Me.cmb_tipo_movimiento.DataSource = ds_movimiento.Tables("m_tipo_movimiento")
            Me.cmb_tipo_movimiento.DisplayMember = "descripcion"
            Me.cmb_tipo_movimiento.ValueMember = "cod_tipo_movimiento"

            ls_sql = "call pa_sel_um_act_motivo_movimiento"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_motivo_movimiento"
            ds_movimiento.Tables.Add(dt.Copy)

            Me.cmb_motivo_movimiento.DataSource = ds_movimiento.Tables("m_motivo_movimiento")
            Me.cmb_motivo_movimiento.DisplayMember = "descripcion"
            Me.cmb_motivo_movimiento.ValueMember = "cod_motivo_movimiento"


            dt = New DataTable("detalle_movimiento")

            dt.Columns.Add(New DataColumn("codigo", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
            dt.Columns.Add(New DataColumn("existencia", GetType(String)))
            ds_movimiento.Tables.Add(dt.Copy)

            Me.dg_detalle_movimiento.DataSource = ds_movimiento.Tables("detalle_movimiento")


            ls_sql = "call pa_sel_um_sg_usuario_todos"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_usuarios"
            ds_movimiento.Tables.Add(dt.Copy)

            Me.cmb_usuario.DataSource = ds_movimiento.Tables("m_usuarios")
            Me.cmb_usuario.DisplayMember = "nombre"
            Me.cmb_usuario.ValueMember = "usuario"

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            otrans_sql.close()
            otrans_sql = Nothing
        End Try

    End Sub

    Private Sub Guardar_Movimiento()
        Dim ls_sql As String
        Dim ls_fecha_movimiento As String
        Dim i_count As Short = 1

        Dim dr As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        Try
            otrans.open()
            If ds_movimiento.Tables("detalle_movimiento").Rows.Count > 0 Then

                Me.btn_guardar_movimiento.Visible = False
                Dim fechaarray(3) As String

                ls_fecha_movimiento = Me.dt_fecha_movimiento.Text
                fechaarray = ls_fecha_movimiento.Split("/")
                ls_fecha_movimiento = fechaarray(2).Substring(0, 4) & "-" & fechaarray(1) & "-" & fechaarray(0)

                ls_sql = "call pa_ins_um_act_movimiento (" & Me.cmb_tipo_movimiento.SelectedValue.ToString & "," & _
                            Me.cmb_motivo_movimiento.SelectedValue.ToString & ",'" & ls_fecha_movimiento & "','" & _
                            Me.txt_comentarios.Text & "','" & gs_usuario & "','" & Me.cmb_usuario.SelectedValue.ToString & "')"

                otrans.Ingresa(ls_sql)


                ds_movimiento.Tables("m_tipo_movimiento").DefaultView.RowFilter = "cod_tipo_movimiento = " & Me.cmb_tipo_movimiento.SelectedValue.ToString

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    Me.txt_numero.Text = dt.Rows(0).Item("newid").ToString


                    For Each dr In ds_movimiento.Tables("detalle_movimiento").Rows
                        ls_sql = "call pa_sel_um_act_producto ('" & dr.Item("codigo") & "')"

                        dt = otrans.Obtiene(ls_sql)

                        ls_sql = "call pa_ins_um_act_movimiento_detalle (" & Me.txt_numero.Text & "," & _
                                i_count.ToString & "," & dt.Rows(0).Item("cod_producto").ToString & "," & _
                                dr.Item("cantidad").ToString & "," & _
                                ds_movimiento.Tables("m_tipo_movimiento").DefaultView(0).Item("signo") & _
                                ")"

                        otrans.Ingresa(ls_sql)
                        If otrans.Codigo_error > 0 Then
                            MessageBox.Show(otrans.descripcion_error)
                        End If
                        i_count = i_count + 1
                    Next

                End If
                MessageBox.Show("Se Ingreso Correctamente el Movimiento", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Imprimir_Reporte()
            Else
                MessageBox.Show("No Hay Registros Para Guardar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            ds_movimiento.Tables("m_tipo_movimiento").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub frm_insumos_activos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Grid()
        Llenar_Combos()
        crear_estructura()
    End Sub

    Public Function Validar_Existencia(ByVal pcod_producto As String, ByVal posicion_grid As Integer) As Boolean
        Dim lb_resultado As Boolean = False
        If Int32.Parse(Me.dg_detalle_movimiento(posicion_grid, 2).ToString) > Int32.Parse(Me.dg_detalle_movimiento(posicion_grid, 3).ToString) Then
            MessageBox.Show("No Hay Existencia Suficiente " & Me.dg_detalle_movimiento(posicion_grid, 2) & " -- " & Me.dg_detalle_movimiento(posicion_grid, 3), "Informacion")
            Me.dg_detalle_movimiento(posicion_grid, 2) = 0
        ElseIf Int32.Parse(Me.dg_detalle_movimiento(posicion_grid, 2).ToString) < 0 Then
            Me.dg_detalle_movimiento(posicion_grid, 2) = 0
        Else
            lb_resultado = True
        End If

        Return lb_resultado
    End Function

    Public Function Buscar_Producto(ByVal pcod_producto As String, ByVal posicion_grid As Integer)
        Dim ls_sql As String
        Dim lb_resultado As Boolean = False
        Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otabla As DataTable

        ls_sql = "call pa_sel_um_act_producto ('" & pcod_producto & "')"
        otrans.open()
        otabla = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        If otabla.Rows.Count > 0 Then
            lb_resultado = True
            Me.dg_detalle_movimiento(posicion_grid, 1) = otabla.Rows(0).Item("descripcion")
            Me.dg_detalle_movimiento(posicion_grid, 3) = otabla.Rows(0).Item("existencia")
        End If

        Return lb_resultado
    End Function

    Public Function DatoValido(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True
        Dim clgen As New ClasesGenerales.General

        Try
            If col = 1 Then
                returnValue = Buscar_Producto(Me.dg_detalle_movimiento(row, 0), row)
            End If

            If col = 2 Then
                If Me.cmb_tipo_movimiento.SelectedValue = 2 Then
                    returnValue = Validar_Existencia(Me.dg_detalle_movimiento(row, 0), row)
                End If
            End If

            If col = 0 And (row > -1 And row < 4) Then
                clgen.Alinea_Grid(ds_movimiento.Tables("detalle_movimiento"), Me.dg_detalle_movimiento, "detalle_movimiento", -1, 300, 50, False, False, "", True, "")
            End If
        Catch ex As Exception

        End Try
        Return returnValue
    End Function

    Private Sub filtrar_marcas()
        Try
            dt_modelos.DefaultView.RowFilter = "cod_marca = " & Me.cmb_marca.SelectedValue.ToString
        Catch ex As Exception
            dt_modelos.DefaultView.RowFilter = "cod_marca = 0"
        End Try
    End Sub

    Private Sub m_insumos_tipos_activos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_tipos_activos.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_tipo_producto"
        oform.Text = oform.Text & " Tipo de Activos"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub Imprimir_Reporte()
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String

        pm_parametros(0) = "pcodigo_movimiento"

        pm_valores(0) = Int32.Parse(Me.txt_numero.Text)


        Dim path_reporte As String
        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\movimiento_insumos.rpt"

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")
    End Sub

    Private Sub Mostrar_Unidades_Modelo()
        Dim dr As DataRow
        Try

            For Each dr In ds_insumos.Tables("modelos_aplicados").Rows

                ds_insumos.Tables("m_marca_modelo").DefaultView.RowFilter = "cod_marca_modelo = " & dr.Item("marca_modelo")
                If ds_insumos.Tables("m_marca_modelo").DefaultView.Count > 0 Then
                    dr.Item("unidades") = ds_insumos.Tables("m_marca_modelo").DefaultView(0).Item("unidades")
                End If

            Next
        Catch ex As Exception
        Finally
            ds_insumos.Tables("m_marca_modelo").DefaultView.RowFilter = ""

        End Try

    End Sub


    Private Sub m_insumos_marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_marcas.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_marca"
        oform.Text = oform.Text & " Marcas"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub m_insumos_modelos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_modelos.Click
        Dim oform As New frm_mantenimiento_modelos
        oform.nombre_tabla = "act_marca_modelo"
        oform.nombre_maestro = "act_marca"
        oform.Text = oform.Text & " Marcas & Modelos"
        oform.cmb_tabla.Visible = True
        oform.Label3.Visible = True
        oform.llenar_combo()
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Me.btn_guardar.Text = "Guardar" Then
            Guardar_Informacion()
        Else
            Modificar_Informacion()
        End If
        Llenar_Grid()
    End Sub

    Private Sub m_insumos_categoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_categoria.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_categoria"
        oform.Text = oform.Text & " Categorias"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub dg_listado_insumos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_listado_insumos.DoubleClick
        Dim li_codigo As Short = Me.dg_listado_insumos.CurrentCell.RowNumber()

        Me.lbl_codigo.Text = Me.dg_listado_insumos.Item(li_codigo, 0)
        llenar_registro(Me.dg_listado_insumos.Item(li_codigo, 0), ds_insumos.Tables("listado_activos"))

        Me.btn_guardar.Text = "Actualizar"
        Me.TabControl1.SelectedTab() = Me.TabPage1
    End Sub

    Private Sub cmb_marca_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_marca.SelectionChangeCommitted
        filtrar_marcas()
    End Sub

    'Para solo darle enter en el DataGrid de la generacion del formulario
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function 'ProcessCmdKey 

    Private Sub btn_nuevo_movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_movimiento.Click
        Movimiento_Nuevo()
    End Sub

    Private Sub dg_detalle_movimiento_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_detalle_movimiento.CurrentCellChanged
        newcurrentrow = Me.dg_detalle_movimiento.CurrentCell.RowNumber
        newcurrentcol = Me.dg_detalle_movimiento.CurrentCell.ColumnNumber

        Dim ls_codigo As String = String.Empty
        Try
            ls_codigo = Me.dg_detalle_movimiento(oldcurrentrow, 0).ToString()
            'totalizar(odataset.Tables("cotizacion_productos"))
        Catch ex As Exception
        End Try

        If ls_codigo = "+" Then
            Dim frm_busqueda As New frm_busqueda_general_mysql

            'frm_busqueda.parametros_fijos = " empresa = '" & Me.cmb_empresa.Text & "' and "
            frm_busqueda.parametros = "codigo, descripcion, modelos"
            frm_busqueda.nombre_vista = "v_act_producto_existencia"
            frm_busqueda.lista_campos = "codigo,codigo, descripcion, modelos "
            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.ShowDialog(Me)

            ls_codigo = frm_busqueda.resultado
            frm_busqueda = Nothing
            dg_detalle_movimiento(oldcurrentrow, 0) = ls_codigo

        End If

        If okToValidate And Not DatoValido(oldcurrentrow, oldcurrentcol, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            If oldcurrentcol = 1 Then 'La Validacion  del codigo del producto la hago en el nombre del producto
                Me.dg_detalle_movimiento.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
            Else
                Me.dg_detalle_movimiento.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            End If
            okToValidate = True
        Else
            oldcurrentrow = newcurrentrow
            oldcurrentcol = newcurrentcol
            If newcurrentcol = 1 Then
                SendKeys.Send("{Tab}")
            End If

            If newcurrentcol = 3 Then
                SendKeys.Send("{Tab}")
            End If

        End If

    End Sub

    Private Sub m_insumos_motivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_motivos.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_motivo_movimiento"
        oform.Text = oform.Text & " Motivos"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub btn_guardar_movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_movimiento.Click
        If Me.btn_guardar_movimiento.Text = "Guardar" Then
            Guardar_Movimiento()
        End If
    End Sub

    Private Sub dg_listado_movimientos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_listado_movimientos.DoubleClick
        Dim li_codigo As Short = Me.dg_listado_movimientos.CurrentCell.RowNumber()

        Me.lbl_codigo.Text = Me.dg_listado_movimientos.Item(li_codigo, 0)
        Llenar_Movimiento(Me.dg_listado_movimientos.Item(li_codigo, 0), ds_insumos.Tables("listado_movimientos"))

        Me.txt_comentarios.Enabled = False
        Me.btn_guardar_movimiento.Visible = False
        Me.cmb_tipo_movimiento.Enabled = False
        Me.cmb_motivo_movimiento.Enabled = False
        Me.cmb_usuario.Enabled = False
        Me.TabControl1.SelectedTab() = Me.TabPage3
    End Sub

    Private Sub btn_impresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_impresion.Click
        If Me.txt_numero.Text.Trim.Length > 0 Then
            Imprimir_Reporte()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Forma()
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub m_insumos_reporte_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String

        Dim oform As New frm_pickeador
        oform.Llenar_Combo_Tipos_Activos()
        oform.ShowDialog()

        pm_valores(0) = oform.cmb_nombre_picker.SelectedValue
        oform.Dispose()
        oform = Nothing
        pm_parametros(0) = "categoria"

        Dim path_reporte As String
        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Inventario de Insumos.rpt"

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")
    End Sub

    Private Sub m_insumos_reporte_kardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String

        Dim oform As New frm_pickeador
        oform.Llenar_Combo_Tipos_Activos()
        oform.ShowDialog()

        pm_valores(2) = oform.cmb_nombre_picker.SelectedValue
        oform.Dispose()
        oform = Nothing

        pm_parametros(0) = "producto_del"
        pm_parametros(1) = "producto_al"
        pm_parametros(2) = "categoria"
        pm_valores(0) = 1
        pm_valores(1) = 99999



        Dim path_reporte As String
        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Insumos kardex.rpt"

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")
    End Sub

    Private Sub btn_kardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kardex.Click
        Dim li_codigo As Short = Me.dg_listado_insumos.CurrentCell.RowNumber()
        Dim dt As DataTable
        dt = ds_insumos.Tables("listado_activos").Copy

        dt.DefaultView.RowFilter = "cod_producto = " & Me.dg_listado_insumos.Item(li_codigo, 0)

        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String

        pm_parametros(0) = "producto_del"
        pm_parametros(1) = "producto_al"
        pm_parametros(2) = "categoria"
        pm_valores(0) = Me.dg_listado_insumos.Item(li_codigo, 0)
        pm_valores(1) = Me.dg_listado_insumos.Item(li_codigo, 0)
        pm_valores(2) = dt.DefaultView(0).Item("cod_categoria")


        Dim path_reporte As String
        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Insumos kardex.rpt"

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")
    End Sub

    Private Sub btn_filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtro.Click
        ds_insumos.Tables("listado_activos").DefaultView.RowFilter = "categoria = '" & Me.cmb_filtro_categoria.Text & "'"
    End Sub

    Private Sub btn_word_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_word.Click

        If Me.cmb_tipo_movimiento.Text.ToLower = "salida" Then
            Imprimir_entrega(Me.txt_numero.Text)
        End If
        If Me.cmb_tipo_movimiento.Text.ToLower = "ingreso" Then
            Imprimir_Recepcion(Me.txt_numero.Text)
        End If
    End Sub

    Private Sub dg_insumos_asociados_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_insumos_asociados.CurrentCellChanged
        Mostrar_Unidades_Modelo()
    End Sub

    Private Sub btn_categoria_movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_categoria_movimiento.Click
        ds_insumos.Tables("listado_movimientos").DefaultView.RowFilter = "cod_categoria = " & Me.cmb_filtro_categoria_movimiento.SelectedValue
    End Sub

    Private Sub m_movimientos_por_departamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String

        Dim oform As New frm_pickeador
        oform.Text = " ::. Seleccione Ubicacion .:: "
        oform.Llenar_Combo_Ubicaciones_Fisicas()
        oform.ShowDialog()

        pm_valores(2) = oform.cmb_nombre_picker.SelectedValue

        Dim path_reporte As String
        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Movimientos_Insumos_Por_Ubicacion.rpt"

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")

    End Sub

    Private Sub btn_rep_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rep_generar.Click

        Dim pm_valores(3) As String
        Dim pm_parametros(3) As String
        Dim path_reporte As String

        If Me.cmb_rep_listado.Text = "Kardex Por Categoria" Then
            pm_parametros(0) = "producto_del"
            pm_parametros(1) = "producto_al"
            pm_parametros(2) = "categoria"
            pm_valores(0) = 1
            pm_valores(1) = 99999
            pm_valores(2) = Me.cmb_rep_categoria.SelectedValue

            path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Insumos kardex.rpt"
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")


        ElseIf Me.cmb_rep_listado.Text = "Inventario de Insumos Por Categoria" Then
            pm_parametros(0) = "categoria"
            pm_valores(0) = Me.cmb_rep_categoria.SelectedValue

            path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Inventario de Insumos.rpt"
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")

        ElseIf Me.cmb_rep_listado.Text = "Toma de Inventario Fisico Por Categoria" Then 'Inventario Fisico
            pm_parametros(0) = "categoria"
            pm_valores(0) = Me.cmb_rep_categoria.SelectedValue

            path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Toma de Inventario de Insumos Fisico.rpt"
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")

        ElseIf Me.cmb_rep_listado.Text = "Movimientos Por Departamento Por Categoria y Fechas" Then 'Movimientos por Departamento
            pm_parametros(0) = "categoria"
            pm_parametros(1) = "ubicacion"
            pm_parametros(2) = "Fecha_Final"
            pm_parametros(3) = "Fecha_Inicio"

            pm_valores(0) = Me.cmb_rep_categoria.SelectedValue
            pm_valores(1) = Me.cmb_rep_ubicacion.Text
            pm_valores(2) = Me.dtp_rep_fecha_final.Value.ToShortDateString
            pm_valores(3) = Me.dtp_rep_fecha_inicio.Value.ToShortDateString

            path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Movimientos_Insumos_Por_Ubicacion.rpt"
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "")
        ElseIf Me.cmb_rep_listado.Text = "Inventario y Minimos de Insumos Por Categoria" Then 'Inventarios y Minimos

            pm_parametros(0) = "categoria"
            pm_valores(0) = Me.cmb_rep_categoria.SelectedValue

            path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\IT\Inventario Minimos de Insumos.rpt"
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, True, "PDF", False, "")
        End If


    End Sub


    Private Sub m_insumos_software_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_software.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_software"
        oform.Text = oform.Text & " Software"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub m_insumos_caracteristicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_insumos_caracteristicas.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_caracteristica"
        oform.Text = oform.Text & " Caracteristicas"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub
End Class
