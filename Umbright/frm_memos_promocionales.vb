Public Class frm_memos_promocionales
    Inherits System.Windows.Forms.Form

    Dim Ods As New DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean

    Dim ls_filtro_original As String = String.Empty
    Friend WithEvents cmProductosUbicacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EstablecerUbicacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents lblcodmemo As Label
    Friend WithEvents lbl_BUM_aprueba As Label
    Dim ls_ubicaciones(5) As String
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
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents cmb_estado_memo As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_memo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_numero_memo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio_memo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_final_memo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_actividad As System.Windows.Forms.TextBox
    Friend WithEvents dg_productos As System.Windows.Forms.DataGrid
    Friend WithEvents dg_clientes As System.Windows.Forms.DataGrid
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmb_lista_precios As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_hora_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_hora_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Nup_porc_empresa As System.Windows.Forms.NumericUpDown
    Friend WithEvents Nup_porc_proveedor As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chk_todos_los_clientes As System.Windows.Forms.CheckBox
    Friend WithEvents Gb_informacion_solicitud As System.Windows.Forms.GroupBox
    Friend WithEvents gb_productos As System.Windows.Forms.GroupBox
    Friend WithEvents GB_dirigido_a As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_solicitantes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_productos As System.Windows.Forms.Button
    Friend WithEvents ofd_productos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbl_productos As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_correlativo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents btn_clientes As System.Windows.Forms.LinkLabel
    Friend WithEvents txt_usuario_opera_memo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_ubicaciones As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_ataque As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents chk_ver_todos As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_campos_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_mensaje As System.Windows.Forms.TextBox
    Friend WithEvents lbl_estado_actual As System.Windows.Forms.Label
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_memos_promocionales))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lbl_BUM_aprueba = New System.Windows.Forms.Label()
        Me.lbl_estado_actual = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_ubicaciones = New System.Windows.Forms.CheckedListBox()
        Me.GB_dirigido_a = New System.Windows.Forms.GroupBox()
        Me.chk_todos_los_clientes = New System.Windows.Forms.CheckBox()
        Me.cmb_lista_precios = New System.Windows.Forms.ComboBox()
        Me.dg_clientes = New System.Windows.Forms.DataGrid()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_clientes = New System.Windows.Forms.LinkLabel()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Gb_informacion_solicitud = New System.Windows.Forms.GroupBox()
        Me.Nup_porc_proveedor = New System.Windows.Forms.NumericUpDown()
        Me.Nup_porc_empresa = New System.Windows.Forms.NumericUpDown()
        Me.dtp_hora_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_fecha_final_memo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio_memo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_actividad = New System.Windows.Forms.TextBox()
        Me.dtp_hora_final = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chk_ataque = New System.Windows.Forms.CheckBox()
        Me.txt_observaciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gb_productos = New System.Windows.Forms.GroupBox()
        Me.lbl_productos = New System.Windows.Forms.Label()
        Me.dg_productos = New System.Windows.Forms.DataGrid()
        Me.cmProductosUbicacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EstablecerUbicacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_productos = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblcodmemo = New System.Windows.Forms.Label()
        Me.lbl_empresa = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_fecha_memo = New System.Windows.Forms.DateTimePicker()
        Me.lbl_numero_memo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_usuario_opera_memo = New System.Windows.Forms.TextBox()
        Me.cmb_estado_memo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_solicitantes = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_correlativo = New System.Windows.Forms.TextBox()
        Me.txt_mensaje = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_ayuda = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.chk_ver_todos = New System.Windows.Forms.CheckBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.cmb_operadores = New System.Windows.Forms.ComboBox()
        Me.cmb_campos_busqueda = New System.Windows.Forms.ComboBox()
        Me.txt_busqueda = New System.Windows.Forms.TextBox()
        Me.ofd_productos = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GB_dirigido_a.SuspendLayout()
        CType(Me.dg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_informacion_solicitud.SuspendLayout()
        CType(Me.Nup_porc_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nup_porc_empresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_productos.SuspendLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmProductosUbicacion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(832, 624)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.lbl_BUM_aprueba)
        Me.TabPage1.Controls.Add(Me.lbl_estado_actual)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GB_dirigido_a)
        Me.TabPage1.Controls.Add(Me.Gb_informacion_solicitud)
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.gb_productos)
        Me.TabPage1.Controls.Add(Me.btn_imprimir)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_ayuda)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(824, 598)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle Memo Promocional"
        '
        'lbl_BUM_aprueba
        '
        Me.lbl_BUM_aprueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BUM_aprueba.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbl_BUM_aprueba.Location = New System.Drawing.Point(663, 160)
        Me.lbl_BUM_aprueba.Name = "lbl_BUM_aprueba"
        Me.lbl_BUM_aprueba.Size = New System.Drawing.Size(100, 16)
        Me.lbl_BUM_aprueba.TabIndex = 12
        Me.lbl_BUM_aprueba.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_BUM_aprueba.Visible = False
        '
        'lbl_estado_actual
        '
        Me.lbl_estado_actual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_estado_actual.AutoSize = True
        Me.lbl_estado_actual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado_actual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_estado_actual.Location = New System.Drawing.Point(509, 160)
        Me.lbl_estado_actual.Name = "lbl_estado_actual"
        Me.lbl_estado_actual.Size = New System.Drawing.Size(110, 13)
        Me.lbl_estado_actual.TabIndex = 8
        Me.lbl_estado_actual.Text = "Esperando Estado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chk_ubicaciones)
        Me.GroupBox1.Location = New System.Drawing.Point(512, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 80)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicaciones"
        '
        'chk_ubicaciones
        '
        Me.chk_ubicaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chk_ubicaciones.CheckOnClick = True
        Me.chk_ubicaciones.Location = New System.Drawing.Point(8, 16)
        Me.chk_ubicaciones.Name = "chk_ubicaciones"
        Me.chk_ubicaciones.Size = New System.Drawing.Size(288, 62)
        Me.chk_ubicaciones.TabIndex = 0
        '
        'GB_dirigido_a
        '
        Me.GB_dirigido_a.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_dirigido_a.Controls.Add(Me.chk_todos_los_clientes)
        Me.GB_dirigido_a.Controls.Add(Me.cmb_lista_precios)
        Me.GB_dirigido_a.Controls.Add(Me.dg_clientes)
        Me.GB_dirigido_a.Controls.Add(Me.Label10)
        Me.GB_dirigido_a.Controls.Add(Me.btn_clientes)
        Me.GB_dirigido_a.Location = New System.Drawing.Point(0, 0)
        Me.GB_dirigido_a.Name = "GB_dirigido_a"
        Me.GB_dirigido_a.Size = New System.Drawing.Size(507, 176)
        Me.GB_dirigido_a.TabIndex = 0
        Me.GB_dirigido_a.TabStop = False
        Me.GB_dirigido_a.Text = "Dirigido A :"
        '
        'chk_todos_los_clientes
        '
        Me.chk_todos_los_clientes.Location = New System.Drawing.Point(336, 18)
        Me.chk_todos_los_clientes.Name = "chk_todos_los_clientes"
        Me.chk_todos_los_clientes.Size = New System.Drawing.Size(120, 16)
        Me.chk_todos_los_clientes.TabIndex = 2
        Me.chk_todos_los_clientes.Text = "Todos Los Clientes"
        '
        'cmb_lista_precios
        '
        Me.cmb_lista_precios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_lista_precios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_lista_precios.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_lista_precios.Location = New System.Drawing.Point(88, 16)
        Me.cmb_lista_precios.Name = "cmb_lista_precios"
        Me.cmb_lista_precios.Size = New System.Drawing.Size(240, 21)
        Me.cmb_lista_precios.TabIndex = 1
        '
        'dg_clientes
        '
        Me.dg_clientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_clientes.CaptionVisible = False
        Me.dg_clientes.DataMember = ""
        Me.dg_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_clientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_clientes.Location = New System.Drawing.Point(8, 39)
        Me.dg_clientes.Name = "dg_clientes"
        Me.dg_clientes.Size = New System.Drawing.Size(450, 132)
        Me.dg_clientes.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Lista Precios"
        '
        'btn_clientes
        '
        Me.btn_clientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clientes.ImageIndex = 0
        Me.btn_clientes.ImageList = Me.ImageList2
        Me.btn_clientes.Location = New System.Drawing.Point(464, 40)
        Me.btn_clientes.Name = "btn_clientes"
        Me.btn_clientes.Size = New System.Drawing.Size(40, 24)
        Me.btn_clientes.TabIndex = 11
        Me.btn_clientes.TabStop = True
        Me.btn_clientes.Text = "   .  ."
        Me.btn_clientes.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        '
        'Gb_informacion_solicitud
        '
        Me.Gb_informacion_solicitud.Controls.Add(Me.Nup_porc_proveedor)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Nup_porc_empresa)
        Me.Gb_informacion_solicitud.Controls.Add(Me.dtp_hora_inicio)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label5)
        Me.Gb_informacion_solicitud.Controls.Add(Me.dtp_fecha_final_memo)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label2)
        Me.Gb_informacion_solicitud.Controls.Add(Me.dtp_fecha_inicio_memo)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label1)
        Me.Gb_informacion_solicitud.Controls.Add(Me.txt_actividad)
        Me.Gb_informacion_solicitud.Controls.Add(Me.dtp_hora_final)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label8)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label11)
        Me.Gb_informacion_solicitud.Controls.Add(Me.chk_ataque)
        Me.Gb_informacion_solicitud.Controls.Add(Me.txt_observaciones)
        Me.Gb_informacion_solicitud.Controls.Add(Me.Label3)
        Me.Gb_informacion_solicitud.Location = New System.Drawing.Point(0, 176)
        Me.Gb_informacion_solicitud.Name = "Gb_informacion_solicitud"
        Me.Gb_informacion_solicitud.Size = New System.Drawing.Size(464, 168)
        Me.Gb_informacion_solicitud.TabIndex = 1
        Me.Gb_informacion_solicitud.TabStop = False
        Me.Gb_informacion_solicitud.Text = "Informacion de Solicitud"
        '
        'Nup_porc_proveedor
        '
        Me.Nup_porc_proveedor.Location = New System.Drawing.Point(240, 64)
        Me.Nup_porc_proveedor.Name = "Nup_porc_proveedor"
        Me.Nup_porc_proveedor.Size = New System.Drawing.Size(56, 20)
        Me.Nup_porc_proveedor.TabIndex = 8
        '
        'Nup_porc_empresa
        '
        Me.Nup_porc_empresa.Location = New System.Drawing.Point(88, 64)
        Me.Nup_porc_empresa.Name = "Nup_porc_empresa"
        Me.Nup_porc_empresa.Size = New System.Drawing.Size(56, 20)
        Me.Nup_porc_empresa.TabIndex = 6
        '
        'dtp_hora_inicio
        '
        Me.dtp_hora_inicio.CustomFormat = "HH:mm"
        Me.dtp_hora_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hora_inicio.Location = New System.Drawing.Point(176, 35)
        Me.dtp_hora_inicio.Name = "dtp_hora_inicio"
        Me.dtp_hora_inicio.ShowUpDown = True
        Me.dtp_hora_inicio.Size = New System.Drawing.Size(56, 20)
        Me.dtp_hora_inicio.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(256, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Al"
        '
        'dtp_fecha_final_memo
        '
        Me.dtp_fecha_final_memo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final_memo.Location = New System.Drawing.Point(288, 36)
        Me.dtp_fecha_final_memo.Name = "dtp_fecha_final_memo"
        Me.dtp_fecha_final_memo.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final_memo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Vigencia"
        '
        'dtp_fecha_inicio_memo
        '
        Me.dtp_fecha_inicio_memo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_memo.Location = New System.Drawing.Point(89, 35)
        Me.dtp_fecha_inicio_memo.Name = "dtp_fecha_inicio_memo"
        Me.dtp_fecha_inicio_memo.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio_memo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 11)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Actividad"
        '
        'txt_actividad
        '
        Me.txt_actividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_actividad.Location = New System.Drawing.Point(89, 13)
        Me.txt_actividad.Name = "txt_actividad"
        Me.txt_actividad.Size = New System.Drawing.Size(368, 20)
        Me.txt_actividad.TabIndex = 1
        '
        'dtp_hora_final
        '
        Me.dtp_hora_final.CustomFormat = "HH:mm:ss"
        Me.dtp_hora_final.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hora_final.Location = New System.Drawing.Point(376, 36)
        Me.dtp_hora_final.Name = "dtp_hora_final"
        Me.dtp_hora_final.ShowUpDown = True
        Me.dtp_hora_final.Size = New System.Drawing.Size(72, 20)
        Me.dtp_hora_final.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "% Empresa"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(160, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "% Proveedor"
        '
        'chk_ataque
        '
        Me.chk_ataque.Location = New System.Drawing.Point(312, 64)
        Me.chk_ataque.Name = "chk_ataque"
        Me.chk_ataque.Size = New System.Drawing.Size(128, 24)
        Me.chk_ataque.TabIndex = 9
        Me.chk_ataque.Text = "Ataque Contrabando"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_observaciones.Location = New System.Drawing.Point(88, 96)
        Me.txt_observaciones.Multiline = True
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.Size = New System.Drawing.Size(368, 64)
        Me.txt_observaciones.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Observaciones"
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 2
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(672, 8)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 64)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
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
        'gb_productos
        '
        Me.gb_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_productos.Controls.Add(Me.lbl_productos)
        Me.gb_productos.Controls.Add(Me.dg_productos)
        Me.gb_productos.Controls.Add(Me.btn_productos)
        Me.gb_productos.Location = New System.Drawing.Point(0, 344)
        Me.gb_productos.Name = "gb_productos"
        Me.gb_productos.Size = New System.Drawing.Size(816, 248)
        Me.gb_productos.TabIndex = 2
        Me.gb_productos.TabStop = False
        Me.gb_productos.Text = "Productos"
        '
        'lbl_productos
        '
        Me.lbl_productos.Location = New System.Drawing.Point(127, 2)
        Me.lbl_productos.Name = "lbl_productos"
        Me.lbl_productos.Size = New System.Drawing.Size(121, 16)
        Me.lbl_productos.TabIndex = 8
        Me.lbl_productos.Visible = False
        '
        'dg_productos
        '
        Me.dg_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_productos.CaptionVisible = False
        Me.dg_productos.ContextMenuStrip = Me.cmProductosUbicacion
        Me.dg_productos.DataMember = ""
        Me.dg_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_productos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_productos.Location = New System.Drawing.Point(8, 16)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.Size = New System.Drawing.Size(800, 225)
        Me.dg_productos.TabIndex = 0
        '
        'cmProductosUbicacion
        '
        Me.cmProductosUbicacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstablecerUbicacionToolStripMenuItem})
        Me.cmProductosUbicacion.Name = "cmProductosUbicacion"
        Me.cmProductosUbicacion.Size = New System.Drawing.Size(184, 26)
        '
        'EstablecerUbicacionToolStripMenuItem
        '
        Me.EstablecerUbicacionToolStripMenuItem.Name = "EstablecerUbicacionToolStripMenuItem"
        Me.EstablecerUbicacionToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EstablecerUbicacionToolStripMenuItem.Text = "Establecer Ubicacion"
        '
        'btn_productos
        '
        Me.btn_productos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_productos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_productos.ImageIndex = 0
        Me.btn_productos.ImageList = Me.ImageList2
        Me.btn_productos.Location = New System.Drawing.Point(64, 0)
        Me.btn_productos.Name = "btn_productos"
        Me.btn_productos.Size = New System.Drawing.Size(56, 24)
        Me.btn_productos.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btn_productos, "Cargar Productos Desde Archivo XLS")
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 1
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(744, 8)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(75, 64)
        Me.btn_imprimir.TabIndex = 6
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblcodmemo)
        Me.GroupBox4.Controls.Add(Me.lbl_empresa)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.dtp_fecha_memo)
        Me.GroupBox4.Controls.Add(Me.lbl_numero_memo)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txt_usuario_opera_memo)
        Me.GroupBox4.Controls.Add(Me.cmb_estado_memo)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cmb_solicitantes)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txt_correlativo)
        Me.GroupBox4.Controls.Add(Me.txt_mensaje)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Location = New System.Drawing.Point(464, 176)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(352, 168)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generales de Solicitud"
        '
        'lblcodmemo
        '
        Me.lblcodmemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcodmemo.ForeColor = System.Drawing.Color.Red
        Me.lblcodmemo.Location = New System.Drawing.Point(219, 144)
        Me.lblcodmemo.Name = "lblcodmemo"
        Me.lblcodmemo.Size = New System.Drawing.Size(80, 12)
        Me.lblcodmemo.TabIndex = 12
        Me.lblcodmemo.Text = "0"
        Me.lblcodmemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblcodmemo.Visible = False
        '
        'lbl_empresa
        '
        Me.lbl_empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_empresa.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbl_empresa.Location = New System.Drawing.Point(240, 16)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Size = New System.Drawing.Size(100, 16)
        Me.lbl_empresa.TabIndex = 11
        Me.lbl_empresa.Text = "EMPRESA"
        Me.lbl_empresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(2, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Solicitado Por"
        '
        'dtp_fecha_memo
        '
        Me.dtp_fecha_memo.Enabled = False
        Me.dtp_fecha_memo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_memo.Location = New System.Drawing.Point(82, 16)
        Me.dtp_fecha_memo.Name = "dtp_fecha_memo"
        Me.dtp_fecha_memo.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_memo.TabIndex = 2
        Me.dtp_fecha_memo.TabStop = False
        '
        'lbl_numero_memo
        '
        Me.lbl_numero_memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_numero_memo.ForeColor = System.Drawing.Color.Red
        Me.lbl_numero_memo.Location = New System.Drawing.Point(256, 40)
        Me.lbl_numero_memo.Name = "lbl_numero_memo"
        Me.lbl_numero_memo.Size = New System.Drawing.Size(80, 12)
        Me.lbl_numero_memo.TabIndex = 5
        Me.lbl_numero_memo.Text = "0"
        Me.lbl_numero_memo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(208, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 12)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Numero"
        '
        'txt_usuario_opera_memo
        '
        Me.txt_usuario_opera_memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario_opera_memo.Location = New System.Drawing.Point(80, 88)
        Me.txt_usuario_opera_memo.Name = "txt_usuario_opera_memo"
        Me.txt_usuario_opera_memo.ReadOnly = True
        Me.txt_usuario_opera_memo.Size = New System.Drawing.Size(264, 20)
        Me.txt_usuario_opera_memo.TabIndex = 2
        Me.txt_usuario_opera_memo.TabStop = False
        '
        'cmb_estado_memo
        '
        Me.cmb_estado_memo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_estado_memo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estado_memo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_estado_memo.Location = New System.Drawing.Point(80, 40)
        Me.cmb_estado_memo.Name = "cmb_estado_memo"
        Me.cmb_estado_memo.Size = New System.Drawing.Size(104, 21)
        Me.cmb_estado_memo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Estado"
        '
        'cmb_solicitantes
        '
        Me.cmb_solicitantes.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_solicitantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_solicitantes.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_solicitantes.Location = New System.Drawing.Point(80, 64)
        Me.cmb_solicitantes.Name = "cmb_solicitantes"
        Me.cmb_solicitantes.Size = New System.Drawing.Size(264, 21)
        Me.cmb_solicitantes.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(1, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 16)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Operado Por"
        '
        'txt_correlativo
        '
        Me.txt_correlativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_correlativo.Location = New System.Drawing.Point(80, 144)
        Me.txt_correlativo.Name = "txt_correlativo"
        Me.txt_correlativo.ReadOnly = True
        Me.txt_correlativo.Size = New System.Drawing.Size(104, 20)
        Me.txt_correlativo.TabIndex = 10
        Me.txt_correlativo.TabStop = False
        '
        'txt_mensaje
        '
        Me.txt_mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_mensaje.Location = New System.Drawing.Point(80, 110)
        Me.txt_mensaje.Multiline = True
        Me.txt_mensaje.Name = "txt_mensaje"
        Me.txt_mensaje.ReadOnly = True
        Me.txt_mensaje.Size = New System.Drawing.Size(264, 32)
        Me.txt_mensaje.TabIndex = 2
        Me.txt_mensaje.TabStop = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(1, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Correlativo Flex"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(1, 112)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Mensaje"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(600, 8)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 64)
        Me.btn_nuevo.TabIndex = 4
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_ayuda
        '
        Me.btn_ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.ImageIndex = 4
        Me.btn_ayuda.ImageList = Me.ImageList1
        Me.btn_ayuda.Location = New System.Drawing.Point(528, 8)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(75, 64)
        Me.btn_ayuda.TabIndex = 4
        Me.btn_ayuda.Text = "Ayuda"
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgvListado)
        Me.TabPage2.Controls.Add(Me.chk_ver_todos)
        Me.TabPage2.Controls.Add(Me.btn_buscar)
        Me.TabPage2.Controls.Add(Me.cmb_operadores)
        Me.TabPage2.Controls.Add(Me.cmb_campos_busqueda)
        Me.TabPage2.Controls.Add(Me.txt_busqueda)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(824, 598)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Memos Promocionales Pendientes"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToOrderColumns = True
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(8, 45)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.Size = New System.Drawing.Size(808, 543)
        Me.dgvListado.TabIndex = 6
        '
        'chk_ver_todos
        '
        Me.chk_ver_todos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_ver_todos.Location = New System.Drawing.Point(680, 19)
        Me.chk_ver_todos.Name = "chk_ver_todos"
        Me.chk_ver_todos.Size = New System.Drawing.Size(80, 16)
        Me.chk_ver_todos.TabIndex = 5
        Me.chk_ver_todos.Text = "Ver Todos"
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 1
        Me.btn_buscar.ImageList = Me.ImageList2
        Me.btn_buscar.Location = New System.Drawing.Point(584, 16)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 23)
        Me.btn_buscar.TabIndex = 4
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(96, 16)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(40, 21)
        Me.cmb_operadores.TabIndex = 3
        '
        'cmb_campos_busqueda
        '
        Me.cmb_campos_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos_busqueda.Items.AddRange(New Object() {"Numero", "Fecha", "Estado", "Solicitante", "Actividad"})
        Me.cmb_campos_busqueda.Location = New System.Drawing.Point(8, 16)
        Me.cmb_campos_busqueda.Name = "cmb_campos_busqueda"
        Me.cmb_campos_busqueda.Size = New System.Drawing.Size(88, 21)
        Me.cmb_campos_busqueda.TabIndex = 2
        '
        'txt_busqueda
        '
        Me.txt_busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_busqueda.Location = New System.Drawing.Point(136, 16)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(424, 20)
        Me.txt_busqueda.TabIndex = 1
        '
        'ofd_productos
        '
        Me.ofd_productos.DefaultExt = "xls"
        '
        'frm_memos_promocionales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(832, 622)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_memos_promocionales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Memos Promocionales .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GB_dirigido_a.ResumeLayout(False)
        CType(Me.dg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_informacion_solicitud.ResumeLayout(False)
        Me.Gb_informacion_solicitud.PerformLayout()
        CType(Me.Nup_porc_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nup_porc_empresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_productos.ResumeLayout(False)
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmProductosUbicacion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Ingreso_Nuevo()
        Dim icount As Integer
        Me.txt_actividad.Text = ""
        Me.txt_observaciones.Text = ""
        Me.Nup_porc_empresa.Value = 0
        Me.Nup_porc_proveedor.Value = 0
        Me.dtp_fecha_memo.Value = Today
        Me.lbl_numero_memo.Text = 0

        Me.txt_usuario_opera_memo.Text = gs_nombre_usuario
        Me.lbl_empresa.Text = gs_empresa
        Me.dtp_fecha_inicio_memo.Value = Today
        Me.dtp_fecha_final_memo.Value = Today
        Me.dtp_hora_inicio.Text = "06:00:00"
        Me.dtp_hora_final.Text = "23:59:59"
        newcurrentrow = -1
        Ods.Tables("listaprecio").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
        Ods.Tables("solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
        Ods.Tables("clientes").Clear()
        Ods.Tables("productos").Clear()
        Me.GB_dirigido_a.Enabled = True
        Me.Gb_informacion_solicitud.Enabled = True
        Me.gb_productos.Enabled = True
        Me.cmb_solicitantes.Enabled = True
        Me.chk_ubicaciones.Enabled = True
        Me.chk_ataque.Enabled = True
        Me.chk_ataque.CheckState = CheckState.Unchecked

        ''Limpiar_ubicaciones
        For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
            Me.chk_ubicaciones.SetItemChecked(icount, False)
        Next
        Me.lbl_estado_actual.Text = ""
        Me.dg_clientes.DataSource = Ods.Tables("clientes")
        Ods.Tables("estados").DefaultView.RowFilter = "cod_estado = 1"

        Me.cmb_lista_precios.Enabled = True
        Me.chk_todos_los_clientes.Enabled = True
        Me.btn_clientes.Enabled = True
        Me.dg_clientes.ReadOnly = False

        Me.dg_productos.ReadOnly = False

        Me.lblcodmemo.Text = "0"

    End Sub

    Private Sub Crear_Estructuras()
        Dim dt As New DataTable("clientes")

        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ListaPrecio", GetType(String)))
        dt.Columns(0).Unique = True

        Ods.Tables.Add(dt.Copy)

        Me.dg_clientes.DataSource = Ods.Tables("clientes")


        dt = New DataTable("productos")

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Precio_Final", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("C.COSTO", GetType(String)))
        dt.Columns.Add(New DataColumn("MARCA", GetType(String)))
        dt.Columns.Add(New DataColumn("GTO.CONT.", GetType(String)))
        dt.Columns.Add(New DataColumn("objetivo_venta", GetType(Integer)))
        dt.Columns.Add(New DataColumn("PrecioLista", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Ubicacion", GetType(String)))
        dt.Columns.Add(New DataColumn("desc_marca", GetType(String)))
        dt.Columns.Add(New DataColumn("bum", GetType(String)))
        dt.Columns(0).Unique = True
        Ods.Tables.Add(dt.Copy)

        Me.dg_productos.DataSource = Ods.Tables("productos")

        dt = New DataTable("productos_marca")

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gerente", GetType(String)))

        Ods.Tables.Add(dt.Copy)

        dt = New DataTable("productos_ubicacion")

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("ubicacion", GetType(String)))

        Ods.Tables.Add(dt.Copy)


    End Sub

    Private Sub Crear_Estructura_Traslado()

        Try
            Dim dt = New DataTable("traslado")

            If Not Ods.Tables.Contains("traslado") Then

                dt.Columns.Add(New DataColumn("agregar", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("producto", GetType(String)))
                dt.Columns.Add(New DataColumn("glosa", GetType(String)))
                dt.Columns.Add(New DataColumn("precio", GetType(Double)))
                dt.Columns.Add(New DataColumn("porcentajemax", GetType(Double)))
                dt.Columns.Add(New DataColumn("listaprecio", GetType(String)))
                dt.Columns.Add(New DataColumn("fechai", GetType(Date)))
                dt.Columns.Add(New DataColumn("fechaf", GetType(Date)))
                dt.Columns.Add(New DataColumn("horai", GetType(DateAndTime)))
                dt.Columns.Add(New DataColumn("horaf", GetType(DateAndTime)))
                dt.Columns.Add(New DataColumn("todos", GetType(String)))
                dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
                dt.Columns.Add(New DataColumn("porcdescuento", GetType(Double)))
                dt.Columns.Add(New DataColumn("idoferta", GetType(Integer)))

                Ods.Tables.Add(dt.Copy)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Alinear_Grid_Clientes()
        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(Ods.Tables("clientes"), Me.dg_clientes, Ods.Tables("clientes").TableName, -1, 250, 50, False, True, "", True, "cliente")
        ClsGen = Nothing
    End Sub

    Private Sub Alinear_Grid_Productos()
        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(Ods.Tables("productos"), Me.dg_productos, Ods.Tables("productos").TableName, -1, 250, 50, False, True, "", True, ",descripcion,preciolista,")
        ClsGen = Nothing
    End Sub

    Public Function DatoValido(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True

        Try
            If col = 1 Then
                returnValue = Buscar_Cliente(Me.dg_clientes(row, 0), row)
            End If

            If col = 0 And (row = 0 Or row = 4) Then
                Alinear_Grid_Clientes()
            End If
        Catch ex As Exception

        End Try
        Return returnValue
    End Function

    Public Function DatoValidoProducto(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True

        Try
            If col = 1 Then
                returnValue = Buscar_Producto(Me.dg_productos(row, 0), row)
            End If

            If col = 3 Then
                returnValue = Validar_Precio(row)
            End If

            If col = 0 And (row = 0 Or row = 4) And returnValue Then
                Alinear_Grid_Productos()
            End If
        Catch ex As Exception
        End Try
        Return returnValue
    End Function

    Private Function Validar_Precio(ByVal posicion_grid As Integer) As Boolean
        If Int32.Parse(Me.dg_productos(posicion_grid, 2).ToString) < 0 Then
            Me.dg_productos(posicion_grid, 2) = 0
        End If

        Return True
    End Function

    Public Function Buscar_Cliente(ByVal pcod_cliente As String, ByVal posicion_grid As Integer)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim lb_resultado As Boolean = False

        dt = Obtener_Cliente_tabla(pcod_cliente)
        If dt.Rows.Count > 0 Then
            Me.dg_clientes(posicion_grid, 1) = dt.Rows(0).Item("nombre_cliente").ToString  'ls_sql 'otabla.Rows(0).Item("nombre_cliente")
            Me.dg_clientes(posicion_grid, 2) = dt.Rows(0).Item("ListaPrecio").ToString
            lb_resultado = True
        Else
            MessageBox.Show("Cliente No Existe")
        End If

        Return lb_resultado
    End Function

    Public Function Obtener_Cliente_tabla(ByVal pcod_cliente As String) As DataTable

        Dim ls_sql As String
        Dim lb_resultado As String = ""
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        ls_sql = "pa_sel_um_ctacte '" & Me.lbl_empresa.Text & "','CLIENTE','" & pcod_cliente & "',NULL"
        otrans.open()
        dt = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        Return dt
    End Function

    Private Function precio_lista(ByVal pcod_producto As String) As Double
        Dim precio As Double = 0
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql As String = "pa_sel_um_listaprecioD '" & Me.lbl_empresa.Text & "','" & pcod_producto & "',"


        Try
            otrans.open()

            Try
                If Me.chk_todos_los_clientes.CheckState = CheckState.Checked Then
                    ls_sql += "'" & Me.cmb_lista_precios.Text & "'"
                ElseIf Ods.Tables("clientes").Rows.Count > 0 Then
                    ls_sql += "'" & Ods.Tables("clientes").Rows(0).Item("ListaPrecio") & "'"
                End If
            Catch ex As Exception
                ls_sql += "NULL"
            End Try
            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count = 1 Then
                precio = dt.Rows(0).Item("valor")
                'Else

            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return precio
    End Function

    Public Function Buscar_Producto(ByVal pcod_producto As String, ByVal posicion_grid As Integer)
        Dim ls_sql As String
        Dim lb_resultado As Boolean = False
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim otabla As DataTable

        ls_sql = "pa_sel_um_producto '" & Me.lbl_empresa.Text & "','" & pcod_producto & "'"
        otrans.open()
        otabla = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        If otabla.Rows.Count > 0 Then
            If otabla.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then
                lb_resultado = True
                Me.dg_productos(posicion_grid, 1) = otabla.Rows(0).Item("glosa")
                Me.dg_productos(posicion_grid, 7) = precio_lista(pcod_producto)

                ''Buscar_precio_lista
            Else
                MessageBox.Show("Producto  " & otabla.Rows(0).Item("glosa").ToString & " No esta Vigente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lb_resultado = False
            End If
        Else
            MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lb_resultado = False
        End If
        Return lb_resultado
    End Function

    Public Function Obtener_Producto(ByVal _pcod_producto As String) As String
        Dim ls_sql As String
        Dim lb_resultado As String = ""
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim otabla As DataTable

        ls_sql = "pa_sel_um_producto '" & Me.lbl_empresa.Text & "','" & _pcod_producto & "'"
        otrans.open()
        otabla = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        If otabla.Rows.Count > 0 Then
            If otabla.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then
                lb_resultado = otabla.Rows(0).Item("glosa")
            Else
                lb_resultado = otabla.Rows(0).Item("vigente").ToString

            End If
        End If

        Return lb_resultado
    End Function

    Private Sub Aplicar_filtro_Estados_Proximo(ByVal estado_actual As Integer)
        Dim ls_filtro As String
        If estado_actual < 20 Then
            estado_actual += 1
        Else
            estado_actual = 0
        End If
        ls_filtro = "cod_estado in (" & estado_actual & ",20,21"
        If estado_actual < 20 Then
            estado_actual -= 2
            ls_filtro += "," & estado_actual.ToString
        End If
        If tiene_permisos("mer_rechazar_memos") Then
            ls_filtro += ",22"
        End If
        ls_filtro += ")"
        Ods.Tables("estados").DefaultView.RowFilter = ls_filtro

    End Sub

    Private Sub Aplicar_Filtro_Estados()
        Dim ls_filtro As String = ""
        ls_filtro = "cod_estado in (1,3,5,7,20,21"
        If tiene_permisos("mer_rechazar_memos") Then
            ls_filtro += ",22"
        End If
        ls_filtro += ")"
        Ods.Tables("estados").DefaultView.RowFilter = ls_filtro
    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGEN As New ClasesGenerales.General
        Dim dt As DataTable



        Try
            'myOtrans.open()
            Otrans.open()
            ls_sql = "pa_sel_um_listaprecio_activa"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "listaprecio"
            Ods.Tables.Add(dt.Copy)

            Me.cmb_lista_precios.DataSource = Ods.Tables("listaprecio")
            Me.cmb_lista_precios.ValueMember = "lisprecio"
            Me.cmb_lista_precios.DisplayMember = "lisprecio"

            ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa null,null,'mer_solicita_memos_promocionales','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "solicitantes"
            Ods.Tables.Add(dt.Copy)

            Me.cmb_solicitantes.DataSource = Ods.Tables("solicitantes")
            Me.cmb_solicitantes.ValueMember = "usuario"
            Me.cmb_solicitantes.DisplayMember = "nombre"



            ls_sql = "pa_sel_um_pg_estados 12"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGEN.selectQuery("corporativo", ls_sql)
            dt.TableName = "estados"
            Ods.Tables.Add(dt.Copy)
            Aplicar_Filtro_Estados()


            Me.cmb_estado_memo.DataSource = Ods.Tables("estados").DefaultView
            Me.cmb_estado_memo.ValueMember = "cod_estado"
            Me.cmb_estado_memo.DisplayMember = "estado"


            'ls_sql = "CALL pa_sel_um_pg_ubicacion()"
            ls_sql = "pa_sel_um_pg_ubicacion"

            'ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & ps_empresa & "'"
            'dt = Otrans.Obtiene(ls_sql)
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGEN.selectQuery("corporativo", ls_sql)
            dt.TableName = "ubicaciones"
            'Ods.Tables.Add(dt.Copy)
            'Ods.Tables("ubicaciones").DefaultView.RowFilter = "nombre_empresa = '" & ps_empresa & "' and traslada_informacion = true"
            dt.DefaultView.RowFilter = "nombre_empresa = '" & gs_empresa & "' and traslada_informacion = true"
            Me.chk_ubicaciones.DataSource = dt.DefaultView 'Ods.Tables("ubicaciones").DefaultView
            Me.chk_ubicaciones.ValueMember = "nombre_bodega" '"codigo"
            Me.chk_ubicaciones.DisplayMember = "descripcion" '"texto5".ToLower


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            '            myOtrans.close()
            '           myOtrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_Solicitudes()
        Dim ls_Sql, ls_filtro As String
        Dim dt, dt2 As DataTable
        Dim dr As DataRow
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        Try
            ls_filtro = ""

            '   myOtrans.open()
            Otrans.open()

            'ls_Sql = "call pa_var_um_mmp_encabezado_listado (null"

            ls_Sql = "pa_var_um_mmp_encabezado_listado null"
            ''Si es usuario administrador Muestro Todos
            If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
                ls_filtro = ""

                'Si revisa memos solo le muestro aquellos que estan solicitados
            Else
                If tiene_permisos("mer_revisa_memos_promocionales") Then
                    ls_filtro = "(cod_estado = 2"

                End If
                'Si Aprueba memos solo le muestro aquellos que estan solicitados
                If tiene_permisos("mer_aprobar_memos") Then
                    ls_filtro += IIf(ls_filtro.Length > 0, " OR ", "(") & "cod_estado = 4"
                End If
                'Si Opera en Flex solo le muestro aquellos que ya estan aprobados
                If tiene_permisos("mer_operar_memos_sistema") Then
                    ls_filtro += IIf(ls_filtro.Length > 0, " OR ", IIf(ls_filtro.ToLower.IndexOf("(") >= 0, "", "(")) & "cod_estado = 6"
                End If
                If tiene_permisos("mer_solicita_memos_promocionales") Then
                    If ls_filtro.Length > 0 Then
                        ls_filtro += ")"
                    Else
                        'Si solo tiene acceso a Ingresar Nuevos Memos solo le muestro lo que ha grabado y q esten pendientes de Aprobar
                        ls_filtro = "(empresa = '" & gs_empresa & "' and cod_estado < 4 and usuario_grabo = '" & gs_usuario & "')"
                    End If
                End If
            End If
            ls_Sql += ",null,'" & gs_empresa & "'"
            'dt = myOtrans.Obtiene(ls_Sql)
            dt = ClsGen.selectQuery("corporativo", ls_Sql)
            dt.TableName = "listado"

            If Ods.Tables.Contains("listado") Then
                Ods.Tables.Remove("listado")
            End If

            'dt.Columns.Add(New DataColumn("No.Flex", GetType(String)))
            'For Each dr In dt.Rows
            '    If dr.Item("cod_estado").ToString = 20 Then
            '        ls_Sql = "pa_sel_um_productooferta_memo '" & dr.Item("empresa").ToString & "',NULL," & dr.Item("numero").ToString
            '        dt2 = Otrans.Obtiene(ls_Sql)
            '        If dt2.Rows.Count > 0 Then
            '            dr.Item("No.Flex") = dt2.Rows(0).Item("descripcion")
            '        End If
            '    End If
            'Next





            Ods.Tables.Add(dt.Copy)
            ls_filtro = ""
            Ods.Tables("listado").DefaultView.RowFilter = ls_filtro
            'dt.DefaultView.RowFilter = ls_filtro

            Me.dgvListado.DataSource = Ods.Tables("listado").DefaultView 'dt3

            ls_filtro = "cod_memo,numero,fecha,_estado,solicitante,actividad,observaciones,lista_precios,usuario_grabo,fecha_grabo,usuario_reviso,fecha_reviso,usuario_aprobo,fecha_aprobo,usuario_opero_flex,fecha_opero_flex,No.Flex"
            'ClsGen.Alinea_Grid(Ods.Tables("listado"), Me.dg_listado, dt.TableName, -1, 250, 0, True, True, ls_filtro, True, "")
            ClsGen.Alinear_GridView(Ods.Tables("listado"), Me.dgvListado, "", ",cod_memo,cod_estado,", "", "", "", "", "", True, True, 250, 0)
        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            ClsGen = Nothing
            ls_filtro_original = ls_filtro

        End Try


    End Sub

    Private Function Validar_Solicitud() As Boolean
        Dim Retorno As Boolean = True
        Dim dr_producto, dr_cliente As DataRow
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt_listas As DataTable



        'Jer 15:21  Te libraré de la mano de los malos, y te redimiré de la garra de los violentos. 

        Try
            If Me.chk_todos_los_clientes.CheckState = CheckState.Unchecked Then
                dt_listas = ClsGen.ValoresDistinto(Ods.Tables("clientes"), "ListaPrecio".Split(","))
            End If

            Otrans.open()

            For Each dr_producto In Ods.Tables("productos").Rows
                For Each dr_cliente In Ods.Tables("clientes").Rows
                    ls_sql = "pa_sel_um_productooferta_fecha '" & gs_empresa & "','" & dr_cliente.Item("cod_cliente").ToString & "','" &
                            dr_producto.Item("codigo").ToString & "','" & Me.dtp_fecha_inicio_memo.Value.ToString("dd/MM/yyyy") & "','" &
                            Me.dtp_fecha_final_memo.Value.ToString("dd/MM/yyyy") & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("El Producto " & dr_producto.Item("descripcion") & " del Cliente " & dr_cliente("cliente") & " Tiene Oferta en el Rango de Fecha " & Chr(13) &
                                " Ejemplo Memo No. " & dt.Rows(0).Item("Descripcion"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Retorno = False
                        Exit Try
                    End If

                    'Verificar que la Oferta el producto no este asociado a Lista de Precios
                    If Me.chk_todos_los_clientes.CheckState = CheckState.Unchecked Then
                        For Each dr As DataRow In dt_listas.Rows
                            ls_sql = "pa_sel_um_productooferta_lista '" & gs_empresa & "','" & dr_producto.Item("codigo").ToString & "','" &
                                    dr.Item("ListaPrecio") & "','" &
                                    Me.dtp_fecha_inicio_memo.Value.ToString("dd/MM/yyyy") & "','" &
                                    Me.dtp_fecha_final_memo.Value.ToString("dd/MM/yyyy") & "'"
                            dt = Otrans.Obtiene(ls_sql)

                            If dt.Rows.Count > 0 Then
                                MessageBox.Show("El Producto " & dr_producto.Item("descripcion") & " Tiene Oferta Para La Lista " & dr.Item("ListaPrecio") & Chr(13) &
                                        " Ejemplo Memo No. " & dt.Rows(0).Item("Descripcion"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Retorno = False
                                Exit Try
                            End If

                        Next
                    End If


                Next
                ''debo verificar si es aplicable a toda la lista

                If Me.chk_todos_los_clientes.CheckState = CheckState.Checked Then
                    ls_sql = "pa_sel_um_productooferta_lista '" & gs_empresa & "','" & dr_producto.Item("codigo").ToString & "','" &
                            Me.cmb_lista_precios.SelectedValue.ToString & "','" &
                            Me.dtp_fecha_inicio_memo.Value.ToString("dd/MM/yyyy") & "','" &
                            Me.dtp_fecha_final_memo.Value.ToString("dd/MM/yyyy") & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("El Producto " & dr_producto.Item("descripcion").ToString & " Tiene Oferta para la Lista " & Me.cmb_lista_precios.SelectedValue.ToString & Chr(13) & " Memo " & dt.Rows(0).Item("descripcion"), "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Retorno = False
                        Exit Try
                    End If
                End If
            Next

        Catch ex As Exception
            Retorno = False
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try



        Return Retorno
    End Function

    Private Sub Guardar_Solicitud()
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_sql As String
        Dim icod_empresa As Short = 0
        Dim icorrelativo As Integer = 0
        Dim lexito As Boolean = True
        Dim icount As Integer
        Dim ls_ubicaciones As String = ""

        Try

            'myOtrans.open()

            ''Obtengo Empresas
            ls_sql = "pa_sel_um_pg_empresa"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGen.selectQuery("corporativo", ls_sql)

            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "descripcion = '" & Me.lbl_empresa.Text & "'"
                If dt.DefaultView.Count = 1 Then
                    icod_empresa = dt.DefaultView(0).Item("cod_empresa").ToString
                End If
            End If

            If icod_empresa > 0 Then



                'Debo Crear Una lista de las ubicaciones a donde se enviara el memo
                For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                    If Me.chk_ubicaciones.GetItemChecked(icount) Then
                        ls_ubicaciones += Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString & ","
                    End If
                Next


                ls_sql = "pa_var_um_mmp_encabezado_numero " & icod_empresa.ToString & ""
                dt = clsGen.selectQuery("corporativo", ls_sql)
                'dt = myOtrans.Obtiene(ls_sql)
                Me.lbl_numero_memo.Text = dt.Rows(0).Item("nuevo_numero").ToString

                ls_sql = "pa_ins_um_mmp_encabezado " & icod_empresa.ToString & "," &
                        Me.lbl_numero_memo.Text & ",'" & Date.Parse(Me.dtp_fecha_memo.Text).ToString("dd-MM-yyyy") & "','" &
                        Me.cmb_solicitantes.SelectedValue.ToString & "','" & gs_usuario & "','" & Me.txt_actividad.Text & "','" &
                        Date.Parse(Me.dtp_fecha_inicio_memo.Text).ToString("dd-MM-yyyy") & " " & Me.dtp_hora_inicio.Text.Substring(0, 5) & "','" &
                        Date.Parse(Me.dtp_fecha_final_memo.Text).ToString("dd-MM-yyyy") & " " & Me.dtp_hora_final.Text.Substring(0, 5) & "','" &
                        Me.txt_observaciones.Text & "','" &
                        IIf(Me.chk_todos_los_clientes.CheckState = CheckState.Checked, Me.cmb_lista_precios.SelectedValue, "") & "'," &
                        IIf(Me.chk_todos_los_clientes.CheckState = CheckState.Checked, 1, 0) & "," & Me.Nup_porc_proveedor.Value.ToString & "," &
                        Me.Nup_porc_empresa.Value.ToString & ",'" & ls_ubicaciones & "'," &
                        IIf(Me.chk_ataque.CheckState = CheckState.Checked, 1, 0) & ",0"
                '                         Me.txt_objetivo_venta.Text & ")"

                clsGen.insertQuery("corporativo", ls_sql)

                ls_sql = "pa_var_um_mmp_encabezado " & icod_empresa & "," & Me.lbl_numero_memo.Text
                dt = clsGen.selectQuery("corporativo", ls_sql)

                'myOtrans.Ingresa(ls_sql)
                If dt.Rows.Count > 0 Then
                    'ls_sql = "SELECT @@IDENTITY AS NewID"
                    'dt = myOtrans.Obtiene(ls_sql)
                    icorrelativo = dt.Rows(0).Item("cod_memo").ToString
                Else
                    MessageBox.Show("Problemas Al Guardar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lexito = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lexito = False
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsGen = Nothing
        End Try

        If icorrelativo > 0 And lexito Then
            lexito = Guardar_Clientes(icorrelativo)
            lexito = Guardar_Productos(icorrelativo)
            Guardar_estado_Memo(icorrelativo, 2)

        End If
        If Not lexito Then
            MessageBox.Show("El Proceso Ha Generado Errores, Revise la Informacion", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.TabControl1.SelectedTab = Me.TabPage2
        End If
        Llenar_Solicitudes()
    End Sub

    ''Guardo Los Cliente
    Private Function Guardar_Clientes(ByVal _correlativo As Integer) As Boolean
        Dim dr As DataRow
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim lexito As Boolean = True
        Dim clsGen As New ClasesGenerales.General

        Try
            ' myOtrans.open()
            'Si el memo es para toda la lista no grabo clientes
            If Me.chk_todos_los_clientes.CheckState = CheckState.Unchecked Then
                Try
                    For Each dr In Ods.Tables("clientes").Rows
                        If dr.Item("cliente").ToString.Length > 0 Then
                            ls_sql = "pa_ins_um_mmp_detalle_clientes " & _correlativo & ",'" & dr.Item("cod_cliente") & "','" &
                                      dr.Item("cliente").ToString & "','" & dr.Item("listaPrecio").ToString & "'"
                            clsGen.insertQuery("corporativo", ls_sql)
                            'myOtrans.Ingresa(ls_sql)

                            'If myOtrans.Codigo_error > 0 Then
                            'MessageBox.Show("Problemas al Guardar Cliente " & dr.Item("cliente").ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ' lexito = False
                            'End If
                        End If
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    lexito = False
                End Try

            End If

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsGen = Nothing
        End Try
        Return lexito
    End Function

    'Guardo Productos Afectos Por los Memos
    Private Function Guardar_Productos(ByVal _correlativo As Integer) As Boolean
        Dim dr As DataRow
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim lexito As Boolean = True
        Dim clsgen As New ClasesGenerales.General
        Try
            'myOtrans.open()
            'Si el memo es para toda la lista no grabo clientes
            Try
                For Each dr In Ods.Tables("productos").Rows
                    If dr.Item("descripcion").ToString.Length > 0 Then
                        ''Solo Guardo Aquellos Productos que Tengan Precio o el precio sea 0
                        If Double.Parse(dr.Item("Precio_Final").ToString) > 0 Then
                            ls_sql = "pa_ins_um_mmp_detalle_productos " & _correlativo & ",'" & dr.Item("codigo").ToString.TrimEnd.TrimStart & "'," &
                                      dr.Item("Precio_Final").ToString & ",'" & dr.Item("C.COSTO").ToString.TrimEnd.TrimStart & "','" &
                                      dr.Item("MARCA").ToString.TrimEnd.TrimStart & "','" & dr.Item("GTO.CONT.").ToString.TrimEnd.TrimStart & "'," &
                                      dr.Item("objetivo_venta").ToString & "," & dr.Item("preciolista").ToString
                            clsgen.insertQuery("corporativo", ls_sql)
                            'myOtrans.Ingresa(ls_sql)
                            'If myOtrans.Codigo_error > 0 Then
                            'MessageBox.Show("Problemas al Guardar Producto " & dr.Item("codigo"), "Precuacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'lexito = False
                            ' End If
                        End If
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                lexito = False
            End Try

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsgen = Nothing
        End Try
        Return lexito

    End Function

    Private Function Guardar_Cambios() As Boolean
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim icod_empresa As Short = 0
        Dim icorrelativo As Integer = 0
        Dim nrow As Integer
        Dim lexito As Boolean = True
        Dim icount As Integer = 0
        Dim ls_ubicaciones As String = ""
        Dim clsGen As New ClasesGenerales.General


        Try
            '  myOtrans.open()

            'Debo Crear Una lista de las ubicaciones a donde se enviara el memo
            For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                If Me.chk_ubicaciones.GetItemChecked(icount) Then
                    ls_ubicaciones += Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString & ","
                End If
            Next

            'nrow = Me.dg_listado.CurrentCell.RowNumber

            'ls_sql = "call pa_upd_um_mmp_encabezado (" & Me.dg_listado.Item(nrow, 0).ToString & ",'" & gs_usuario & "','" 

            ls_sql = "pa_upd_um_mmp_encabezado (" & Me.lblcodmemo.Text & ",'" & gs_usuario & "','" &
                    Me.txt_actividad.Text & "','" & Date.Parse(Me.dtp_fecha_inicio_memo.Text).ToString("dd-MM-yyyy") & " " & Me.dtp_hora_inicio.Text.Substring(0, 5) & "','" &
                    Date.Parse(Me.dtp_fecha_final_memo.Text).ToString("dd-MM-yyyy") & " " & Me.dtp_hora_final.Text.Substring(0, 5) & "','" &
                    Me.txt_observaciones.Text & "','" &
                    IIf(Me.chk_todos_los_clientes.CheckState = CheckState.Checked, Me.cmb_lista_precios.SelectedValue, "") & "'," &
                    IIf(Me.chk_todos_los_clientes.CheckState = CheckState.Checked, 1, 0) & "," & Me.Nup_porc_proveedor.Value.ToString & "," &
                    Me.Nup_porc_empresa.Value.ToString & "," & Me.cmb_estado_memo.SelectedValue.ToString & ",'" &
                    ls_ubicaciones & "'," &
                    IIf(Me.chk_ataque.CheckState = CheckState.Checked, 1, 0) & ",0"
            '                    Me.txt_objetivo_venta.Text & ")"
            clsGen.insertQuery("corporativo", ls_sql)


            'myOtrans.Actualiza(ls_sql)


            'Problemas al insertar

            'If myOtrans.Codigo_error > 0 Then
            'lexito = False
            'Else
            If Me.cmb_estado_memo.SelectedValue.ToString <> 21 Then  'Si es Anulacion ya no Modifico los detalles
                ls_sql = "pa_del_um_mmp_detalle_clientes " & Me.lblcodmemo.Text
                clsGen.insertQuery("corporativo", ls_sql)
                'myOtrans.Elimina(ls_sql)

                ls_sql = "pa_del_um_mmp_detalle_productos " & Me.lblcodmemo.Text
                clsGen.insertQuery("corporativo", ls_sql)
                'myOtrans.Elimina(ls_sql)
            End If

            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardar Cambios")
            lexito = False
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsGen = Nothing
        End Try

        If lexito Then
            If Me.cmb_estado_memo.SelectedValue.ToString <> 21 Then  'Si es Anulacion ya no Modifico los detalles
                lexito = Guardar_Clientes(Me.lblcodmemo.Text)
                lexito = Guardar_Productos(Me.lblcodmemo.Text)
            End If
        End If

        If Not lexito Then
            MessageBox.Show("La Actualizacion Genero Errores", "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            '     MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Llenar_Solicitudes()
        'Me.TabControl1.SelectedTab = Me.TabPage2
        Return lexito
    End Function

    Private Sub Guardar_estado_Memo(ByVal _pcod_memo As Integer, ByVal _pcod_estado As Integer)
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim clsgen As New ClasesGenerales.General

        Try
            'myOtrans.open()

            If _pcod_estado = 3 Then
                ls_sql = "pa_upd_um_mmp_encabezado_reviso " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 5 Then
                ls_sql = "pa_upd_um_mmp_encabezado_autorizo " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 7 Then
                ls_sql = "pa_upd_um_mmp_encabezado_opero_flex " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 20 Then
                ls_sql = "pa_upd_um_mmp_encabezado_opero_flex " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
                'myOtrans.Actualiza(ls_sql)
                clsgen.insertQuery("corporativo", ls_sql)
                ls_sql = "pa_upd_um_mmp_encabezado_estado " & _pcod_memo.ToString & "," & _pcod_estado.ToString
            Else
                ls_sql = "pa_upd_um_mmp_encabezado_estado " & _pcod_memo.ToString & "," & _pcod_estado.ToString
                ' MessageBox.Show("Proceso Actualizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'myOtrans.Actualiza(ls_sql)
            clsgen.insertQuery("corporativo", ls_sql)


        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsgen = Nothing
        End Try

    End Sub

    Private Sub Guardar_estado_Memo_comentarios(ByVal _pcod_memo As Integer, ByVal _pcod_estado As Integer, ByVal _motivo As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim ls_sql2 As String

        Try
            myOtrans.open()

            If _pcod_estado = 3 Then
                ls_sql = "call pa_upd_um_mmp_encabezado_reviso (" & _pcod_memo.ToString & ",'" & gs_usuario & "')"
            ElseIf _pcod_estado = 5 Then
                ls_sql = "call pa_upd_um_mmp_encabezado_autorizo (" & _pcod_memo.ToString & ",'" & gs_usuario & "')"
            ElseIf _pcod_estado = 7 Then
                ls_sql = "call pa_upd_um_mmp_encabezado_opero_flex (" & _pcod_memo.ToString & ",'" & gs_usuario & "')"
            ElseIf _pcod_estado = 20 Then
                ls_sql = "call pa_upd_um_mmp_encabezado_opero_flex (" & _pcod_memo.ToString & ",'" & gs_usuario & "')"
                myOtrans.Actualiza(ls_sql)
                ls_sql = "call pa_upd_um_mmp_encabezado_estado (" & _pcod_memo.ToString & "," & _pcod_estado.ToString & ")"
            Else
                ls_sql = "call pa_upd_um_mmp_encabezado_estado (" & _pcod_memo.ToString & "," & _pcod_estado.ToString & ")"
                ' MessageBox.Show("Proceso Actualizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            myOtrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Estado_Memo_Rechazado(ByVal _pcod_memo As Integer, ByVal _pcod_estado As Integer, ByVal _motivo As String)

        Dim ls_sql As String
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Try

            'myOtrans.open()
            If _pcod_estado < 2 Then
                _pcod_estado = 2
            End If
            ls_sql = "pa_upd_um_mmp_encabezado_estado_rechazado " & _pcod_memo.ToString & "," & _pcod_estado.ToString &
                                                                    ",' " & _motivo & "'"
            'myOtrans.Actualiza(ls_sql)
            clsGen.insertQuery("corporativo", ls_sql)
        Catch ex As Exception

        Finally
            'myOtrans.close()
            'myOtrans = Nothing
        End Try

    End Sub

    Private Function Verificar_Conexiones() As Boolean
        Dim icount As Integer
        Dim sinc As Sincronizacion.Productos
        Dim conexiones As Boolean = True
        Try

            For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                If Me.chk_ubicaciones.GetItemChecked(icount) Then
                    'ls_ubicaciones += Me.chk_ubicaciones.Items(icount)("codigo").ToString & ","
                    'Verifico Conexiones
                    sinc = New Sincronizacion.Productos(Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString)
                    If sinc.codigo_error > 0 Then
                        sinc = Nothing
                        MessageBox.Show("En Este Momento No se Puede Operar Este Memo en " & Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString &
                                        Chr(13) & "Por Favor Intente Mas Tarde", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        conexiones = False
                    End If
                End If
            Next
        Catch ex As Exception
            conexiones = False
        Finally
            sinc = Nothing
        End Try
        Return conexiones

    End Function

    Private Function Traslado_Memos() As Boolean
        Dim exitoso As Boolean = True
        Dim icount As Integer

        Try
            Crear_Estructura_Traslado()
            exitoso = Prepara_Informacion_Traslado()

            If exitoso Then
                For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                    If Me.chk_ubicaciones.GetItemChecked(icount) Then
                        If Not Realiza_Traslado_Memos(Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString,
                                                Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString) Then
                            exitoso = False
                        End If
                    End If
                Next

            End If

        Catch ex As Exception

        End Try
        Return exitoso
    End Function

    Private Function Prepara_Informacion_Traslado() As Boolean
        Dim ls_sql As String

        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim exitoso As Boolean = True

        Try
            Ods.Tables("traslado").Rows.Clear()
            otrans.open()
            ls_sql = "pa_var_um_productooferta '" & Me.lbl_empresa.Text & "',NULL,NULL,'" & Me.txt_correlativo.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = Ods.Tables("traslado").NewRow

                dr_aux.Item("agregar") = True
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("precio") = dr.Item("precio")
                dr_aux.Item("porcentajemax") = dr.Item("porcentajemax")
                dr_aux.Item("listaprecio") = dr.Item("listaprecio")
                dr_aux.Item("fechai") = dr.Item("fechai")
                dr_aux.Item("fechaf") = dr.Item("fechaf")
                dr_aux.Item("horai") = dr.Item("horai")
                dr_aux.Item("horaf") = dr.Item("horaf")
                dr_aux.Item("todos") = dr.Item("todos")
                dr_aux.Item("ctacte") = dr.Item("ctacte")
                dr_aux.Item("porcdescuento") = dr.Item("porcdescuento")
                dr_aux.Item("idoferta") = dr.Item("idoferta")

                Ods.Tables("traslado").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            exitoso = False
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Return exitoso
    End Function

    Private Function Realiza_Traslado_Memos(ByVal pstienda As String, ByVal psnombre As String) As Boolean

        Dim dr As DataRow
        Dim lerror As Boolean = False
        Dim exitoso As Boolean = True
        Dim sinc As New Sincronizacion.Productos(pstienda)

        Try

            For Each dr In Ods.Tables("traslado").Rows
                If dr.Item("agregar") = True Then
                    sinc.Actualizar_Ofertas(Me.lbl_empresa.Text, Me.txt_correlativo.Text, dr)
                    If sinc.codigo_error > 0 Then
                        MessageBox.Show(sinc.descripcion_error)
                        lerror = True
                        exitoso = False
                    End If
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(sinc.descripcion_error)
            exitoso = False
            lerror = True
        Finally
            sinc.Cerrar()
            sinc = Nothing
        End Try
        If lerror Then
            MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return exitoso
    End Function

    Private Function Guardar_Memo_Flex(ByVal _pdr As DataRow) As Boolean
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim dr, dr2 As DataRow

        Dim ls_sql, ls_listaprecios As String
        Dim ls_sql_detalle, sNumeroFlex As String
        Dim idoferta As Integer
        Dim numero As Integer
        Dim icount As Integer
        Dim ls_ubicaciones As String = ""
        Dim proceso_exitoso As Boolean = False
        Dim conexiones As Boolean = True
        'Dim sinc As sincronizacion.Productos




        Try
            Otrans.open()
            myOtrans.open()

            For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                If Me.chk_ubicaciones.GetItemChecked(icount) Then
                    ls_ubicaciones += Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString & ","
                End If
            Next


            ''Verificar las Conexiones a las diferentes ubicaciones

            conexiones = Verificar_Conexiones()
            If conexiones Then

                ls_sql = "call pa_sel_um_mmp_detalle_producto (" & _pdr.Item("cod_memo").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)
                dt.TableName = "mmp_detalle_productos"

                If Ods.Tables.Contains("mmp_detalle_productos") Then
                    Ods.Tables.Remove("mmp_detalle_productos")
                End If
                Ods.Tables.Add(dt.Copy)

                ls_sql = "call pa_sel_um_mmp_detalle_clientes (" & _pdr.Item("cod_memo").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)
                dt.TableName = "mmp_detalle_clientes"

                If Ods.Tables.Contains("mmp_detalle_clientes") Then
                    Ods.Tables.Remove("mmp_detalle_clientes")
                End If
                Ods.Tables.Add(dt.Copy)

                Ods.Tables("mmp_detalle_clientes").Columns.Add(New DataColumn("listaprecio", GetType(String)))


                For Each dr2 In Ods.Tables("mmp_detalle_clientes").Rows
                    ls_sql_detalle = "pa_sel_um_ctacte '" & Me.lbl_empresa.Text & "','CLIENTE','" & dr2.Item("cod_cliente") & "',NULL"
                    dt = Otrans.Obtiene(ls_sql_detalle)
                    dr2.Item("listaprecio") = dt.Rows(0).Item("ListaPrecio")

                Next

                ''Debo Obtener Correlativo Nuevo

                sNumeroFlex = "00"
                ls_sql = "pa_sel_um_productooferta_numero '" & Me.lbl_empresa.Text & "'"
                dt = Otrans.Obtiene(ls_sql)
                If dt.Rows.Count = 1 Then
                    numero = dt.Rows(0).Item("Numero_maximo").ToString
                    numero += 1
                    sNumeroFlex += dt.Rows(0).Item("anio").ToString.Trim
                    sNumeroFlex += numero.ToString.PadLeft(4, "0")
                Else
                    MessageBox.Show("Problemas al Obtener Correlativo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If

                If Me.lbl_empresa.Text = "CODICASA" Then
                    sNumeroFlex += "  "
                    sNumeroFlex += Me.Nup_porc_empresa.Value.ToString.PadLeft(3, "0")
                    sNumeroFlex += "  "
                    sNumeroFlex += Me.Nup_porc_proveedor.Value.ToString.PadLeft(3, "0")
                End If
                Me.txt_correlativo.Text = sNumeroFlex

                For Each dr In Ods.Tables("mmp_detalle_productos").Rows

                    ls_sql = "pa_sel_um_producto '" & Me.lbl_empresa.Text & "','" & dr.Item("cod_flex").ToString & "'"
                    dt = Otrans.Obtiene(ls_sql)



                    ''Aprueba solo los vigentes
                    If dt.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then


                        ls_sql = "pa_var_um_productoOferta_id '" & Me.lbl_empresa.Text & "','" &
                                                                dr.Item("cod_flex").ToString & "'"

                        dt = Otrans.Obtiene(ls_sql)
                        idoferta = dt.Rows(0).Item("newIdOferta")
                        ls_sql = "pa_ins_um_productooferta '" & Me.lbl_empresa.Text & "','" &
                                                      dr.Item("cod_flex").ToString & "',''," & dr.Item("precio").ToString & ",'" &
                                                      Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" &
                                                      Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "',"

                        If _pdr.Item("aplica_todos").ToString Then
                            ls_sql += "'S','"
                            ls_listaprecios = _pdr.Item("lista_precios").ToString
                        Else
                            ls_sql += "'N','"
                            For Each dr2 In Ods.Tables("mmp_detalle_clientes").Rows

                                ls_sql_detalle = ""
                                ls_sql_detalle = "pa_ins_um_productoOferta '" & Me.lbl_empresa.Text & "','" &
                                                    dr.Item("cod_flex").ToString & "','" & dr2.Item("cod_cliente").ToString & "'," & dr.Item("precio").ToString & ",'" &
                                                    Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" &
                                                    Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "','N','" &
                                                    sNumeroFlex & "','" &
                                                    Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToString("HH:mm:ss") & "','" &
                                                    Date.Parse(_pdr.Item("vigencia_final").ToString).ToString("HH:mm:ss") & "',0.00,0.00,'" &
                                                    dr2.Item("listaprecio").ToString & "'," & idoferta.ToString
                                Otrans.Ingresa(ls_sql_detalle)


                                ls_listaprecios = dr2.Item("listaprecio").ToString
                            Next  ''Detalle de Clientes
                        End If  ''Aplica a todos

                        ls_sql += sNumeroFlex & "','" &
                                    Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToString("HH:mm:ss") & "','" &
                                    Date.Parse(_pdr.Item("vigencia_final").ToString).ToString("HH:mm:ss") & "',0.00,0.00,'" &
                                    ls_listaprecios & "'," & idoferta.ToString
                        Otrans.Ingresa(ls_sql)

                        ''Guardo nueva tabla debe guardar una linea por producto para mantener la vigencia
                        ls_sql = "pa_ins_um_productooferta_memo '" & Me.lbl_empresa.Text & "','" & sNumeroFlex & "'," &
                                    dr.Item("objetivo_venta").ToString & "," & IIf(Me.chk_ataque.CheckState = CheckState.Checked, 1, 0) & ",' " &
                                    ls_ubicaciones.Trim & "'," &
                                    Me.Nup_porc_proveedor.Value.ToString & "," & Me.Nup_porc_empresa.Value.ToString & "," &
                                     Me.lbl_numero_memo.Text & ",'" & dr.Item("cod_flex").ToString & "'"

                        Otrans.Ingresa(ls_sql)

                    End If '''Productos Vigentes
                Next


                '''Enviar Memo a Distintas ubicaciones

                If Not Traslado_Memos() Then
                    proceso_exitoso = False
                    'Debo Eliminar El Memo
                Else
                    proceso_exitoso = True
                End If





            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardar Memo Flex", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return proceso_exitoso
    End Function

    Private Sub Buscar_Memo_Flex()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_productooferta_memo '" & Me.lbl_empresa.Text & "',NULL," & Me.lbl_numero_memo.Text
            dt = oTrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                Me.txt_correlativo.Text = dt.Rows(0).Item("descripcion")
            End If

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try
    End Sub

    Private Sub Mostrar_Memo()
        Dim nrow As Integer
        Dim drv As DataRowView
        Dim ls As String
        Dim icount As Integer
        Dim dt As DataTable

        Try

            Me.lblcodmemo.Text = "0"
            nrow = Me.dgvListado.CurrentRow.Index
            dt = Ods.Tables("listado").Copy

            ' Ods.Tables("listado").DefaultView.RowFilter = "cod_memo = " & Me.dg_listado.Item(nrow, 0).ToString
            'dt.DefaultView.RowFilter = "cod_memo = " & Me.dg_listado.Item(nrow, 0).ToString

            dt.DefaultView.RowFilter = "cod_memo = " & Me.dgvListado.Item("cod_memo", nrow).Value

            drv = dt.DefaultView(0)

            Me.lblcodmemo.Text = Me.dgvListado.Item("cod_memo", nrow).Value

            Me.txt_actividad.Text = drv.Item("actividad").ToString
            Me.txt_observaciones.Text = drv.Item("observaciones").ToString
            Me.txt_usuario_opera_memo.Text = drv.Item("nombre_usuario_grabo").ToString
            Me.cmb_solicitantes.SelectedValue = drv.Item("usuario_solicito").ToString
            Me.lbl_empresa.Text = drv.Item("empresa").ToString
            Me.lbl_numero_memo.Text = drv.Item("numero").ToString
            Me.dtp_fecha_memo.Text = drv.Item("fecha").ToString
            Me.dtp_fecha_inicio_memo.Text = drv.Item("vigencia_inicio").ToString
            Me.dtp_fecha_final_memo.Text = drv.Item("vigencia_final").ToString
            Me.dtp_hora_inicio.Text = drv.Item("vigencia_inicio").ToString
            Me.dtp_hora_final.Text = drv.Item("vigencia_final").ToString

            Me.cmb_lista_precios.SelectedValue = drv.Item("lista_precios").ToString
            Me.cmb_lista_precios.Text = drv.Item("lista_precios").ToString


            Me.cmb_estado_memo.SelectedValue = drv.Item("cod_estado").ToString
            Me.Nup_porc_empresa.Value = drv.Item("porcentaje_empresa").ToString
            Me.Nup_porc_proveedor.Value = drv.Item("porcentaje_proveedor").ToString
            Me.txt_correlativo.Text = ""
            Me.txt_mensaje.Text = drv.Item("comentario").ToString

            Me.TabControl1.SelectedTab = Me.TabPage1

            'Me.chk_todos_los_clientes.Checked = IIf(drv.Item("aplica_todos").ToString = 1, True, False)
            Me.chk_todos_los_clientes.Checked = drv.Item("aplica_todos")
            If drv.Item("lista_precios").ToString.Length = 0 Then
                Ods.Tables("listaprecio").DefaultView.RowFilter = "empresa = '" & Me.lbl_empresa.Text & "'"
            End If
            Me.chk_ataque.CheckState = CheckState.Unchecked

            For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                If drv.Item("ubicaciones").ToString.ToLower.IndexOf(Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString.ToLower) >= 0 Then
                    Me.chk_ubicaciones.SetItemChecked(icount, True)
                Else
                    Me.chk_ubicaciones.SetItemChecked(icount, False)
                End If
            Next

            Me.chk_ubicaciones.Enabled = False
            '            Me.chk_ataque.Enabled = False


            If drv.Item("cod_estado").ToString > 2 Then
                'Or _                    drv.Item("usuario_grabo").ToString <> ps_usuario Then
                '' Group Box Cliente
                Me.GB_dirigido_a.Enabled = True
                Me.cmb_lista_precios.Enabled = False
                Me.chk_todos_los_clientes.Enabled = False
                Me.btn_clientes.Enabled = False
                Me.dg_clientes.ReadOnly = True

                Me.Gb_informacion_solicitud.Enabled = False
                Me.gb_productos.Enabled = True
                Me.dg_productos.ReadOnly = True
                Me.cmb_solicitantes.Enabled = False
            Else
                Me.GB_dirigido_a.Enabled = True
                Me.gb_productos.Enabled = True
                Me.Gb_informacion_solicitud.Enabled = True

                Me.cmb_lista_precios.Enabled = True
                Me.chk_todos_los_clientes.Enabled = True
                Me.btn_clientes.Enabled = True
                Me.dg_clientes.ReadOnly = False

                Me.dg_productos.ReadOnly = False
                Me.chk_ubicaciones.Enabled = True


            End If

            'Me.chk_ataque.CheckState = IIf(drv.Item("ataque_contrabando").ToString = 1, CheckState.Checked, CheckState.Unchecked)
            Me.chk_ataque.CheckState = drv.Item("ataque_contrabando")
            Me.lbl_estado_actual.Text = drv.Item("_estado").ToString
            Me.lbl_estado_actual.Visible = True

            Me.Aplicar_filtro_Estados_Proximo(drv.Item("cod_estado").ToString)
            Me.cmb_estado_memo.SelectedValue = drv.Item("cod_estado").ToString

            'txt_correlativo.Text = drv.Item("No.Flex")


            If Integer.Parse(drv.Item("cod_estado").ToString) = 20 Then
                Buscar_Memo_Flex()
            End If

        Catch ex As Exception
        Finally

        End Try


        Mostrar_Clientes(Me.dgvListado.Item("cod_memo", nrow).Value)
        Mostrar_Productos(Me.dgvListado.Item("cod_memo", nrow).Value, drv.Item("cod_estado").ToString)
        'Mostrar_Clientes(Me.dg_listado.Item(nrow, 0).ToString)
        'Mostrar_Productos(Me.dg_listado.Item(nrow, 0).ToString, drv.Item("cod_estado").ToString)

        ''Si aplica para toda la lista no debe mostrar el detalle de clientes
        If Me.chk_todos_los_clientes.CheckState = CheckState.Checked Then
            Me.dg_clientes.DataSource = Nothing
        End If


    End Sub

    Private Sub Mostrar_Clientes(ByVal _pcod_memo As Integer)
        'Dim MyOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt, dt2 As DataTable

        Dim dr, dr_aux As DataRow

        Dim ls_sql As String
        Dim clsGen As New ClasesGenerales.General

        Try
            Ods.Tables("clientes").Clear()
            'MyOtrans.open()
            ls_sql = "pa_sel_um_mmp_detalle_clientes  " & _pcod_memo & ""
            dt = clsGen.selectQuery("corporativo", ls_sql)
            'dt = MyOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = Ods.Tables("clientes").NewRow
                dr_aux.Item("cod_cliente") = dr.Item("cod_cliente")

                dt2 = Obtener_Cliente_tabla(dr.Item("cod_cliente"))
                dr_aux.Item("cliente") = dt2.Rows(0).Item("nombre_cliente").ToString
                dr_aux.Item("ListaPrecio") = dt2.Rows(0).Item("ListaPrecio").ToString

                Ods.Tables("clientes").Rows.Add(dr_aux)

            Next

            Me.dg_clientes.DataSource = Ods.Tables("clientes")
        Catch ex As Exception
        Finally
            'MyOtrans.close()
            'MyOtrans = Nothing
            Alinear_Grid_Clientes()
            If Ods.Tables("clientes").Rows.Count > 0 Then
                Me.cmb_lista_precios.SelectedValue = -1
            End If
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Mostrar_Productos(ByVal _pcod_memo As Integer, ByVal ipCodEstado As Integer)

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim clsGen As New ClasesGenerales.General
        Dim ls_sql, ls_descripcion As String


        Try
            Ods.Tables("productos").Clear()

            'myOtrans.open()
            ls_sql = "pa_sel_um_mmp_detalle_producto " & _pcod_memo.ToString & ""
            dt = clsGen.selectQuery("corporativo", ls_sql)
            'dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = Ods.Tables("productos").NewRow

                'ls_descripcion = Obtener_Producto(dr.Item("cod_flex"))

                dr_aux.Item("codigo") = dr.Item("cod_flex")
                ' dr_aux.Item("descripcion") = ls_descripcion
                dr_aux.Item("Precio_Final") = dr.Item("precio")
                dr_aux.Item("C.COSTO") = dr.Item("centro_costo")
                dr_aux.Item("MARCA") = dr.Item("marca")
                dr_aux.Item("GTO.CONT.") = dr.Item("gasto_conta")
                dr_aux.Item("objetivo_venta") = dr.Item("objetivo_venta")
                dr_aux.Item("preciolista") = dr.Item("precio_lista")

                Ods.Tables("productos").Rows.Add(dr_aux)

                'If dr.Item("nombre_producto").ToString.Length = 0 Then
                '    Dim oSinc As New sincronizacion.Envio_Onbase
                '    oSinc.Insertar_OnBase(gs_empresa, dr.Item("cod_flex"))
                '    oSinc = Nothing
                'End If

            Next
            obtenerInformacionAdicionalproductos(ipCodEstado)

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            Alinear_Grid_Productos()
        End Try

    End Sub

    Private Sub obtenerInformacionAdicionalproductos(ByVal ipCodEstado As Integer)

        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim drAux As DataRow
        Dim dt, dtMarcas As DataTable

        lsSQL = "pa_sel_um_producto '" & Me.lbl_empresa.Text & "'"
        Otrans.open()
        dt = Otrans.Obtiene(lsSQL)
        Otrans.close()
        Otrans = Nothing
        ' Dim oSinc As New Sincronizacion.Envio_Onbase
        Dim clsGen As New ClasesGenerales.General
        dtMarcas = clsGen.marcasEmpleado("")
        Ods.Tables("productos_marca").Rows.Clear()

        Try
            For Each dr As DataRow In Ods.Tables("productos").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo") & "'"

                If dt.DefaultView.Count > 0 Then
                    dr.Item("descripcion") = dt.DefaultView(0).Item("glosa")


                    drAux = Ods.Tables("productos_marca").NewRow
                    drAux.Item("codigo") = dr.Item("codigo")
                    drAux.Item("descripcion") = dt.DefaultView(0).Item("glosa")
                    drAux.Item("marca") = dr.Item("marca") 'dt.DefaultView(0).Item("tipo")
                    'dtMarcas.DefaultView.RowFilter = "codigo = '" & dt.DefaultView(0).Item("tipo") & "' and empresa = '" & gs_empresa.ToUpper & "'"
                    dtMarcas.DefaultView.RowFilter = "codigo = '" & dr.Item("marca") & "' and empresa = '" & gs_empresa.ToUpper & "'"

                    drAux.Item("gerente") = ""
                    If dtMarcas.DefaultView.Count > 0 Then
                        drAux.Item("gerente") = dtMarcas.DefaultView(0).Item("texto3")
                        dr.Item("bum") = dtMarcas.DefaultView(0).Item("texto3")
                        dr.Item("desc_marca") = dtMarcas.DefaultView(0).Item("descripcion")


                    End If

                    Ods.Tables("productos_marca").Rows.Add(drAux)

                    If ipCodEstado < 20 Then
                        Try
                            '  oSinc.Insertar_OnBase(gs_empresa, dr.Item("cod_flex"))
                        Catch ex As Exception
                        End Try
                    End If

                    '(c)

                    ' dr.("desc_marca") = 


                End If
            Next
            Me.lbl_BUM_aprueba.Text = String.Empty

            dtMarcas = clsGen.ValoresDistinto(Ods.Tables("productos_marca"), "gerente".Split(","))
            If ipCodEstado = 4 And (gs_empresa.ToLower = "dmarte1" Or gs_empresa.ToLower = "codicasa") Then
                Me.lbl_estado_actual.Text += " por"

                For Each dr As DataRow In dtMarcas.Rows
                    Me.lbl_estado_actual.Text += " " + dr.Item("gerente")
                    Me.lbl_BUM_aprueba.Text += dr.Item("gerente")
                Next

            End If

        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
            clsGen.Escribir_Log(ex.ToString)
        Finally
            clsGen = Nothing
            ' oSinc = Nothing
        End Try



    End Sub

    Private Sub Modificar_Memo()
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql, comentario As String
        Dim nrow As Integer
        Dim blProcesar As Boolean = False
        comentario = ""
        Dim clsGen As New ClasesGenerales.General
        Try
            'myOtrans.open()
            'nrow = Me.dg_listado.CurrentCell.RowNumber
            ls_sql = "pa_var_um_mmp_encabezado_listado NULL," & Me.lblcodmemo.Text & ",'" & gs_empresa & "'"
            dt = clsGen.selectQuery("corporativo", ls_sql)
            'dt = myOtrans.Obtiene(ls_sql)
        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
        End Try

        dr = dt.Rows(0)
        If Val(dr.Item("cod_estado").ToString) > 4 Then
            MessageBox.Show("Este Memo No Se Puede Modificar", "Atencion !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Me.cmb_estado_memo.SelectedValue.ToString = 21 Then
            'Int32.Parse(Me.cmb_estado_memo.SelectedValue.ToString) = Int32.Parse(dr.Item("cod_estado").ToString) Or 

            ''El Memo lo pueden anular siempre y cuando no este operado en flex
            If tiene_permisos("mer_anular_memos") Or
                tiene_permisos("mer_administrador_memos") Then
                If dr.Item("cod_estado").ToString <> 20 Then
                    Guardar_Estado_Memo_Rechazado(Me.lblcodmemo.Text, 21, " Anulado " & gs_usuario & " " & Now.ToString("ddMMyyyHHmm")) ''Lo Pongo Anulado
                    MessageBox.Show("Este Memo Ha Sido Anulado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Este Memo no se puede Anular", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No Tiene Permisos Suficientes Para Anular Memos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Memos Rechazados
        ElseIf Me.cmb_estado_memo.SelectedValue.ToString = 22 Then
            If tiene_permisos("mer_rechazar_memos") Or
            tiene_permisos("mer_administrar_memos") Then
                If dr.Item("cod_estado").ToString < 5 Then
                    comentario = InputBox("Indique Cual es el Motivo del Rechazo", "Rechazo de Memos")
                    If comentario.ToString.Length > 0 Then
                        comentario = gs_usuario & " -- " & comentario.Trim
                        Guardar_Estado_Memo_Rechazado(Me.lblcodmemo.Text, dr.Item("cod_estado").ToString - 2, comentario)
                        MessageBox.Show("El Memo Fue Regresado Al Estado Anterior", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Debe Indicar el Motivo del Rechazo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Su Usuario No Tiene Permisos Para RECHAZAR Memos Promocionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ''Valido Pemisos para Revisado

        ElseIf validar_datos() Then
            ''Si el Memo No ha sido autorizado, puedo hacerle cambios
            If Me.cmb_estado_memo.SelectedValue.ToString < 3 Then
                If Guardar_Cambios() = False Then
                    Exit Sub
                Else
                    MessageBox.Show("Las Modificaciones Fueron  Guardadas Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Llenar_Solicitudes()
                    Me.TabControl1.SelectedTab = Me.TabPage2
                End If
            End If

            If Me.cmb_estado_memo.SelectedValue.ToString = 3 Then
                ''Valido que el estado sea el correcto
                If dr.Item("cod_estado").ToString = 2 Then

                    If tiene_permisos("mer_revisa_memos_promocionales") Or
                        tiene_permisos("mer_administrar_memos") Then

                        If MessageBox.Show("Desea Agregar Comentario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            comentario = InputBox("Ingrese Comentarios", "Comentarios")
                            comentario = IIf(comentario.Trim.Length > 0, "Revision " & comentario.Trim & Chr(13), "")
                        End If
                        Guardar_Estado_Memo_Rechazado(Me.lblcodmemo.Text, Me.cmb_estado_memo.SelectedValue.ToString, comentario)
                        Guardar_estado_Memo(Me.lblcodmemo.Text, Me.cmb_estado_memo.SelectedValue.ToString)
                        Guardar_estado_Memo(Me.lblcodmemo.Text, 4) ''Lo Pongo en Espera de Aprobacion
                        MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Su Usuario No Tiene Permisos Para Aprobar Memos Promocionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Solo Se Puede Revisar Memos Solicitados" & Chr(13) & " El estado Actual Es " & dr.Item("_estado"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ''Valido Permisos Para Operar en Aprobado
            ElseIf Me.cmb_estado_memo.SelectedValue.ToString = 5 Then
                ''Valido que el estado sea el correcto
                If dr.Item("cod_estado").ToString = 4 Then
                    If tiene_permisos("mer_aprobar_memos") Or
                        tiene_permisos("mer_administrar_memos") Then

                        If gs_empresa.ToLower.StartsWith("codi") Or
                            gs_empresa.ToLower.StartsWith("dmar") Or
                            gs_empresa.ToLower.StartsWith("diu") Or
                            gs_empresa.ToLower.StartsWith("lain") Then

                            If tiene_permisos("mer_administrar_memos") Then
                                blProcesar = True
                            ElseIf verificarMarcas() Then
                                '(c) 20150807 Solo en el equipo donde esta logueado puede parobar
                                If gs_usuario.ToLower.Equals(gs_nombre_equipo.ToLower) Then
                                    blProcesar = True
                                Else
                                    blProcesar = True
                                    MessageBox.Show("Solo Puede Autorizar En el Equipo de " & gs_usuario, "Informacion", MessageBoxButtons.OK)
                                End If

                            Else

                                MessageBox.Show("Solo el BU de puede autorizar este Memo", "Informacion", MessageBoxButtons.OK)
                            End If
                            'Else
                            'If dr.Item("usuario_reviso").ToString = gs_usuario And
                            '        Not tiene_permisos("mer_administrar_memos") Then
                            '    MessageBox.Show("El Usuario que Revisa No puede ser el que AUTORIZA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            blProcesar = True
                        End If

                        If blProcesar Then
                            If MessageBox.Show("Desea Agregar Comentario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                comentario = InputBox("Ingrese Comentarios", "Comentarios")
                                comentario = IIf(comentario.Length > 0, "Aprobacion " & comentario.Trim & Chr(13), "")
                            End If
                            Guardar_Estado_Memo_Rechazado(Me.lblcodmemo.Text, Me.cmb_estado_memo.SelectedValue.ToString, comentario)
                            Guardar_estado_Memo(Me.lblcodmemo.Text, Me.cmb_estado_memo.SelectedValue.ToString)
                            Guardar_estado_Memo(Me.lblcodmemo.Text, 6) ''Lo Pongo en Espera de Operacion Flex
                            MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    Else
                        MessageBox.Show("Su Usuario No Tiene Permisos Para Aprobar Memos Promocionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Solo Se Puede Aprobar Memos Revisados" & Chr(13) & " El estado Actual Es " & dr.Item("_estado"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ''Valido Permisos Para Operar en Flex
            ElseIf Me.cmb_estado_memo.SelectedValue.ToString = 7 Then
                If dr.Item("cod_estado").ToString = 6 Then  'Aprobado
                    If tiene_permisos("mer_operar_memos_sistema") Then
                        'If Me.txt_correlativo.Text.Length = 0 Then
                        '    MessageBox.Show("Debe Agregar Correlativo para Poder Operar en Flex", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Else
                        If MessageBox.Show("Esta Seguro de Operar Memo en Sistema", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                            If Guardar_Memo_Flex(dr) Then
                                Guardar_estado_Memo(Me.lblcodmemo.Text, 20) ''Cierro La Solicitud

                                MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                        End If
                        'End If
                    Else
                        MessageBox.Show("Su Usuario No Tiene Permisos Para Operar Memos en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Solo Se Puede Operar Memos Autorizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Function verificarMarcas() As Boolean
        Dim lbPermisosMarca As Boolean = False
        Dim clsGen As New ClasesGenerales.General
        Dim dtMarcas As DataTable

        Try
            Ods.Tables("productos_marca").DefaultView.RowFilter = "gerente = '" & gs_usuario & "'"

            If Ods.Tables("productos_marca").DefaultView.Count > 0 Then lbPermisosMarca = True


            dtMarcas = clsGen.ValoresDistinto(Ods.Tables("productos_marca"), "gerente".Split(","))
            If dtMarcas.Rows.Count > 1 Then '(c) 20250829 Cuando hay mas de un gerente no se puede aprobar
                lbPermisosMarca = False
                Dim oform As New frm_resultado
                oform.Text = "El Memo Contiene Productos de las Siguientes Marcas:" & Chr(13)
                oform.dgv_resultado.DataSource = dtMarcas
                oform.ShowDialog()
                oform = Nothing
            End If


        Catch ex As Exception
        End Try
        Return lbPermisosMarca
    End Function



    Private Sub Imprimir_Memos()

        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(Me.lbl_empresa.Text)
            Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\Memo_Promocional_" & Me.lbl_empresa.Text & "_" & Me.lbl_numero_memo.Text & ".pdf"

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Mercadeo Corporativo\Memos Promocionales.rpt"
            pm_parametros(0) = "Numero"
            pm_parametros(1) = "Empresa"
            pm_valores(0) = Me.lbl_numero_memo.Text
            pm_valores(1) = Me.lbl_empresa.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "mysql", "OnBase", "sa", "sa", True, False, "PDF", True)
        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

    End Sub

    Private Sub Cargar_Productos()
        Dim snombre_archivo As String
        Dim dt As DataTable
        Dim Oaut As New Automatizar.importar_excel
        Dim dr, dr_aux As DataRow
        Dim ls_descripcion As String = ""

        Try
            Me.ofd_productos.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.ofd_productos.ShowDialog()

            snombre_archivo = Me.ofd_productos.FileName

            If snombre_archivo.Length = 0 Then
                MessageBox.Show("Debe Seleccionar Un Archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            Else
                dt = Oaut.obtener_registros(snombre_archivo, 7)
                'MessageBox.Show(dt.Rows.Count.ToString)

                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        ls_descripcion = Obtener_Producto(dr.Item("Columna1"))
                        If ls_descripcion.Trim.Length > 1 Then
                            dr_aux = Ods.Tables("productos").NewRow

                            dr_aux.Item("codigo") = dr.Item("Columna1")
                            dr_aux.Item("descripcion") = ls_descripcion
                            dr_aux.Item("Precio_Final") = dr.Item("Columna3")
                            dr_aux.Item("C.COSTO") = dr.Item("Columna4")
                            dr_aux.Item("MARCA") = dr.Item("Columna5")
                            dr_aux.Item("GTO.CONT.") = dr.Item("Columna6")
                            dr_aux.Item("objetivo_venta") = dr.Item("Columna7")
                            dr_aux.Item("preciolista") = precio_lista(dr.Item("Columna1"))

                            Ods.Tables("productos").Rows.Add(dr_aux)
                        ElseIf ls_descripcion.Trim.Length = 1 Then
                            MessageBox.Show("El Producto " & dr.Item("Columna1").ToString & " " & dr.Item("Columna2").ToString & Chr(13) & "No Esta Vigente y no se Agregara a la Lista", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        ls_descripcion = ""
                    Next
                    Alinear_Grid_Productos()
                    Me.lbl_productos.Visible = True
                    Me.lbl_productos.Text = "Lineas Cargadas " & Ods.Tables("productos").Rows.Count.ToString
                Else
                    Me.lbl_productos.Visible = False
                End If

            End If
        Catch ex As Exception
        Finally
            Oaut.Cerrar_Libros()
            Oaut = Nothing

        End Try



    End Sub

    Private Sub Aplicar_Filtro()
        Dim ls_filtro As String = ""

        Try

            ls_filtro = "empresa = '" & gs_empresa & "' "
            If Me.txt_busqueda.TextLength > 0 Then
                'ls_filtro = Me.cmb_campos_busqueda.SelectedValue.ToString & " " & Me.cmb_operadores.SelectedValue.ToString & " '" & Me.txt_busqueda.Text & "'"
                If Me.chk_ver_todos.CheckState = CheckState.Checked Then

                    ls_filtro = Me.cmb_campos_busqueda.Text & " " &
                               Me.cmb_operadores.Text & " '" & IIf(Me.cmb_operadores.Text = "like", "%", "") & Me.txt_busqueda.Text & IIf(Me.cmb_operadores.Text = "like", "%", "") & "'"
                Else
                    ls_filtro = ls_filtro_original & " and " & Me.cmb_campos_busqueda.Text & " " &
                                                  Me.cmb_operadores.Text & " '" & IIf(Me.cmb_operadores.Text = "like", "%", "") & Me.txt_busqueda.Text & IIf(Me.cmb_operadores.Text = "like", "%", "") & "'"
                End If
            Else
                If Me.chk_ver_todos.CheckState = CheckState.Checked Then
                    ls_filtro += ""
                Else
                    ls_filtro = ls_filtro_original
                End If


            End If
            'ds_cliente.Tables("listado_clientes").DefaultView.RowFilter = ls_filtro
            Ods.Tables("listado").DefaultView.RowFilter = ls_filtro
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Mostrar_Manual()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql, ls_rutamanual As String


        Dim proceso As New Process
        ls_sql = "pa_sel_um_gen_parametros_sistema"
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            ls_rutamanual = dt.Rows(0).Item("path_manuales").ToString.Trim
            ls_rutamanual += "memospromocionales.pdf"

            proceso.Start(ls_rutamanual)



        Catch ex As Exception
        Finally
            proceso = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Aplicar_Seguridad()
        If tiene_permisos("mer_ingreso_memos") Or
                tiene_permisos("mer_administrar_memos") Then
            Me.btn_nuevo.Visible = True
        Else
            Me.btn_nuevo.Visible = False

        End If
        If tiene_permisos("mer_ingreso_memos") Or
                tiene_permisos("mer_administrar_memos") Or
                tiene_permisos("mer_revisa_memos_promocionales") Or
                tiene_permisos("mer_anular_memos") Or
                tiene_permisos("mer_aprobar_memos") Or
                tiene_permisos("mer_rechazar_memos") Then
            Me.btn_guardar.Visible = True
        Else
            Me.btn_guardar.Visible = False
        End If




    End Sub

    Private Sub frm_memos_promocionales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructuras()
        Llenar_Combos()
        Llenar_Solicitudes()
        Alinear_Grid_Clientes()
        Alinear_Grid_Productos()
        Ingreso_Nuevo()
        Aplicar_Seguridad()

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Ingreso_Nuevo()
    End Sub

    Private Function validar_datos() As Boolean
        Dim Valido As Boolean = True
        Dim nclientes As Integer

        Try

            nclientes = Ods.Tables("clientes").Rows.Count
        Catch ex As Exception
            nclientes = 0

        End Try

        'Valido los porcentajes
        If (Me.Nup_porc_empresa.Value + Me.Nup_porc_proveedor.Value) > 100 Then
            MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False

            'Valido que el rango de fechas sea valido
        ElseIf Me.dtp_fecha_inicio_memo.Value > Me.dtp_fecha_final_memo.Value Then
            MessageBox.Show("La Fecha inicial es Mayor que la Final", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        ElseIf Me.dtp_fecha_final_memo.Value < Today Then
            MessageBox.Show("El Memo No Puede Finalizar Antes de Hoy", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        ElseIf Ods.Tables("productos").Rows.Count = 0 Then
            MessageBox.Show("Debe Ingresar Productos Para la Promocion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        ElseIf (nclientes = 0 And Me.chk_todos_los_clientes.CheckState = CheckState.Unchecked) Then
            MessageBox.Show("Debe Especificar Clientes/Lista Precios", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        ElseIf Me.dtp_fecha_final_memo.Value.AddDays(-31) >= Me.dtp_fecha_inicio_memo.Value Then
            'If Me.dtp_fecha_final_memo.Value.Month = Me.dtp_fecha_inicio_memo.Value.Month And _
            '      Me.dtp_fecha_final_memo.Value.Year = Me.dtp_fecha_final_memo.Value.Year Then
            'Si es dentro del mismo mes puede contener 31 dias
            'Else
            '(c) El memo se ampliara a 60 Dias, en base a la reunion del 15 de Marzo
            MessageBox.Show("El Memo No puede Durar Mas de 30 Dias", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
            'End If

        End If

        If gs_empresa.ToLower = "codicasa" Then
            If (Me.Nup_porc_empresa.Value + Me.Nup_porc_proveedor.Value) = 0 Then
                MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Valido = False
            End If
        End If


        Dim dr As DataRow
        Dim ls_sql As String
        Try

            For Each dr In Ods.Tables("productos").Rows


                If dr.Item("descripcion").ToString.Length > 0 Then
                    If dr.Item("objetivo_venta").ToString < 1 Then
                        MessageBox.Show("El Producto " & dr.Item("descripcion").ToString & " No tiene Objetivo de Venta", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Valido = False
                        Exit Try

                    End If
                End If

            Next


        Catch ex As Exception
            MessageBox.Show("Debe Agregar Objetivo de Ventas", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Valido = False
        End Try

        ls_sql = ""
        Try
            For Each dr In Ods.Tables("clientes").Rows
                If ls_sql.IndexOf(dr.Item("ListaPrecio")) = -1 Then
                    If ls_sql.Length > 0 Then
                        MessageBox.Show("Tiene Clientes Con Diferente Lista de Precios", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Valido = False
                        Exit Try
                    End If
                    ls_sql += dr.Item("ListaPrecio") & ","
                End If

            Next


        Catch ex As Exception

        End Try


        'If objetivo_venta <= 0 Then
        'MessageBox.Show("Debe Agregar Objetivo de Ventas", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Valido = False
        'End If

        Return Valido
    End Function

    Private Sub dg_clientes_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_clientes.CurrentCellChanged
        newcurrentrow = Me.dg_clientes.CurrentCell.RowNumber
        newcurrentcol = Me.dg_clientes.CurrentCell.ColumnNumber

        Dim ls_codigo As String
        Dim dt As DataTable
        Try
            ls_codigo = Me.dg_clientes(oldcurrentrow, 0).ToString()
            'totalizar(odataset.Tables("cotizacion_productos"))
        Catch ex As Exception
        End Try

        If ls_codigo = "+" Then
            ' Me.dg_clientes(oldcurrentrow, 0) = ""
            Try


                Dim frm_busqueda As New frm_busqueda_general

                frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                frm_busqueda.parametros = "CtaCte,RazonSocial,Giro,Ejecutivo,vigencia_cliente"
                frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
                frm_busqueda.lista_campos = "Cast(0 as bit) as agregar, ctacte, RazonSocial, Giro, Ejecutivo, vigencia_cliente,ListaPrecio "

                frm_busqueda.txt_buscar1.Focus()
                frm_busqueda.dg_buscar.ReadOnly = False
                frm_busqueda.btn_seleccion_multipe.Visible = True
                frm_busqueda.Btn_Aceptar.Visible = True
                frm_busqueda.ShowDialog(Me)


                'Ods.Tables("clientes").Clear()
                'MyOtrans.open()
                'ls_sql = "call pa_sel_um_mmp_detalle_clientes ( " & _pcod_memo & ")"
                'dt = MyOtrans.Obtiene(ls_sql)
                'Me.dg_clientes(oldcurrentrow, 0) = ""
                Dim dr, dr_aux As DataRow
                Dim icount As Integer = 0

                For Each dr In frm_busqueda.dt.Rows
                    If dr.Item("agregar") = True Then
                        icount += 1
                        If icount = 1 Then
                            ls_codigo = dr.Item("ctacte")
                            Me.dg_clientes(oldcurrentrow, 0) = ls_codigo

                        Else
                            dr_aux = Ods.Tables("clientes").NewRow
                            dr_aux.Item("cod_cliente") = dr.Item("ctacte")
                            dt = Obtener_Cliente_tabla(dr.Item("ctacte"))
                            If dt.Rows.Count > 0 Then
                                dr_aux.Item("cliente") = dt.Rows(0).Item("nombre_cliente")
                                dr_aux.Item("ListaPrecio") = dt.Rows(0).Item("ListaPrecio")
                            End If


                            Ods.Tables("clientes").Rows.Add(dr_aux)
                        End If
                    End If
                Next

                For Each dr In Ods.Tables("clientes").Rows
                    If dr_aux.Item("cod_cliente") = "+" Then
                        dr_aux.Delete()
                    End If
                Next

                'ls_codigo = frm_busqueda.resultado

                frm_busqueda.Dispose()
                frm_busqueda = Nothing
                Alinear_Grid_Clientes()
                Me.dg_clientes(oldcurrentrow, 0) = ls_codigo
            Catch ex As Exception
                Me.dg_clientes(oldcurrentrow, 0) = ""

            End Try

        End If

        If okToValidate And Not DatoValido(oldcurrentrow, oldcurrentcol, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            If oldcurrentcol = 1 Then ''La Validacion  del codigo del producto la hago en el nombre del producto
                Me.dg_clientes.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
            Else
                Me.dg_clientes.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            End If
            okToValidate = True
        Else
            oldcurrentrow = newcurrentrow
            oldcurrentcol = newcurrentcol
            If newcurrentcol = 1 Then
                SendKeys.Send("{Tab}")
            End If

            If newcurrentcol = 2 Then
                SendKeys.Send("{Tab}")
            End If

        End If

    End Sub

    Private Sub dg_productos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_productos.CurrentCellChanged
        newcurrentrow = Me.dg_productos.CurrentCell.RowNumber
        newcurrentcol = Me.dg_productos.CurrentCell.ColumnNumber

        Dim ls_codigo, ls_descripcion As String
        Dim dt As DataTable

        Try
            ls_codigo = Me.dg_productos(oldcurrentrow, 0).ToString()
            'totalizar(odataset.Tables("cotizacion_productos"))
        Catch ex As Exception
        End Try

        If ls_codigo = "+" Then
            Dim frm_busqueda As New frm_busqueda_general

            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
            frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
            frm_busqueda.nombre_vista = "v_um_producto_busqueda"
            frm_busqueda.lista_campos = "Cast(0 as bit) as agregar, producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"
            frm_busqueda.txt_buscar1.Focus()

            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.dg_buscar.ReadOnly = False
            frm_busqueda.btn_seleccion_multipe.Visible = True
            frm_busqueda.Btn_Aceptar.Visible = True
            frm_busqueda.ShowDialog(Me)

            Dim dr, dr_aux As DataRow
            Dim icount As Integer = 0

            For Each dr In frm_busqueda.dt.Rows
                If dr.Item("agregar") = True Then
                    icount += 1
                    If icount = 1 Then
                        ls_codigo = dr.Item("producto")
                        Me.dg_productos(oldcurrentrow, 0) = ls_codigo

                    Else
                        dr_aux = Ods.Tables("productos").NewRow
                        dr_aux.Item("codigo") = dr.Item("producto")
                        'dt = Obtener_Producto_tabla(dr.Item("ctacte"))
                        ls_descripcion = Obtener_Producto(dr.Item("producto"))
                        If ls_descripcion.ToString.Length > 1 Then
                            dr_aux.Item("descripcion") = ls_descripcion
                            dr_aux.Item("Precio_Final") = 0.0
                            dr_aux.Item("C.COSTO") = ""
                            dr_aux.Item("MARCA") = ""
                            dr_aux.Item("GTO.CONT.") = ""
                            dr_aux.Item("objetivo_venta") = 0
                            dr_aux.Item("preciolista") = precio_lista(dr.Item("producto"))
                            Ods.Tables("productos").Rows.Add(dr_aux)
                        End If
                    End If
                End If
            Next

            For Each dr In Ods.Tables("productos").Rows
                If dr_aux.Item("codigo") = "+" Then
                    dr_aux.Delete()
                End If
            Next

            frm_busqueda.Dispose()
            frm_busqueda = Nothing
            Alinear_Grid_Productos()
            Me.dg_productos(oldcurrentrow, 0) = ls_codigo

        End If

        If okToValidate And Not DatoValidoProducto(oldcurrentrow, oldcurrentcol, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            If oldcurrentcol = 1 Then ''La Validacion  del codigo del producto la hago en el nombre del producto
                Me.dg_productos.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
            Else
                Me.dg_productos.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            End If
            okToValidate = True
        Else
            oldcurrentrow = newcurrentrow
            oldcurrentcol = newcurrentcol
            If newcurrentcol = 1 Then
                SendKeys.Send("{Tab}")
            End If

            If newcurrentcol = 7 Then
                SendKeys.Send("{Tab}")
            End If
            If newcurrentcol = 2 And Me.dg_productos(oldcurrentrow, 1).ToString.Trim.Length = 0 Then
                Me.dg_productos.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 2)
            End If

        End If


    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        Dim estado As Integer
        Try

            estado = Me.cmb_estado_memo.SelectedValue.ToString


            If Int32.Parse(Me.lbl_numero_memo.Text) > 0 Then
                If validar_datos() Then
                    If Validar_Solicitud() Then
                        Modificar_Memo()
                        Llenar_Solicitudes()
                        Me.TabControl1.SelectedTab = Me.TabPage2
                    End If
                End If
            ElseIf validar_datos() Then
                If MessageBox.Show("Esta Seguro de Guardar Esta Solicitud", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    MessageBox.Show("Se Verificara Que no Existan Memos Con Fechas Similares", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If Validar_Solicitud() Then
                        Guardar_Solicitud()
                    End If
                End If
                Llenar_Solicitudes()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardar Click", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub dg_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Aplicar_Filtro_Estados()
        Mostrar_Memo()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If Me.lbl_empresa.Text.Length > 0 And Int32.Parse(Me.lbl_numero_memo.Text) > 0 Then
            Imprimir_Memos()
        End If
    End Sub

    Private Sub btn_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_productos.Click
        If Int32.Parse(Me.lbl_numero_memo.Text) = 0 Then
            Cargar_Productos()
        Else
            MessageBox.Show("La Carga de Productos Solo Se Puede Hacer Con Memos Nuevos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub


    Private Sub btn_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clientes.Click
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "CtaCte,RazonSocial,Giro,Ejecutivo,vigencia_cliente"
        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.lista_campos = "Cast(0 as bit) as agregar, ctacte, RazonSocial, Giro, Ejecutivo, vigencia_cliente,ListaPrecio "

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = True
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.ShowDialog(Me)

        Try
            For Each dr In frm_busqueda.dt.Rows
                If dr.Item("agregar") = True Then
                    dr_aux = Ods.Tables("clientes").NewRow
                    dr_aux.Item("cod_cliente") = dr.Item("ctacte")
                    dt = Obtener_Cliente_tabla(dr.Item("ctacte"))
                    dr_aux.Item("cliente") = dt.Rows(0).Item("nombre_cliente")
                    dr_aux.Item("ListaPrecio") = dt.Rows(0).Item("ListaPrecio")

                    Ods.Tables("clientes").Rows.Add(dr_aux)
                End If
            Next

        Catch ex As Exception
        End Try

        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Alinear_Grid_Clientes()

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Aplicar_Filtro()
    End Sub

    Private Sub txt_filtro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
        If e.KeyChar = Chr(13) Then
            Aplicar_Filtro()
        End If
    End Sub



    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Mostrar_Manual()
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub EstablecerUbicacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstablecerUbicacionToolStripMenuItem.Click
        Try
            If gs_empresa.ToLower.StartsWith("") Then 'vinoteca
                'debo levantar ventana para preguntar ubicacion

                Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
                Dim dt As DataTable
                Try
                    Dim oForm As New frm_busqueda_general_mysql
                    oForm.nombre_vista = "pg_ubicacion"
                    oForm.lista_campos = "true as agregar, nombre_bodega,descripcion"

                    oForm.ps_parametros_fijos = "cod_empresa = 7 and traslada_informacion = true"
                    oForm.ShowDialog()
                    'dt = myOtrans.Obtiene("CALL pa_sel_um_pg_ubicacion()")
                    'dt.DefaultView.RowFilter = "nombre_empresa = '" & gs_empresa & "' and traslada_informacion = true"


                Catch ex As Exception

                End Try



            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvListado_DoubleClick(sender As Object, e As EventArgs) Handles dgvListado.DoubleClick
        Aplicar_Filtro_Estados()
        Mostrar_Memo()
    End Sub

    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick

    End Sub


End Class
