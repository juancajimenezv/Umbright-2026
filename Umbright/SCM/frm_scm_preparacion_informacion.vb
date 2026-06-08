Public Class frm_scm_preparacion_informacion
    Inherits System.Windows.Forms.Form
    Dim ds_preparacion As DataSet
    Public dtCalculoPrevio As DataTable
    Dim pi_meses_adicionales As Short = 0
    Dim pi_lead_time As Short
    Friend WithEvents chkProyeccion As System.Windows.Forms.CheckBox
    Friend WithEvents chkTiendas As System.Windows.Forms.CheckBox
    Friend WithEvents chk_minimo_standard As System.Windows.Forms.CheckBox
    Friend WithEvents chkPresupuestoAlterno As CheckBox
    Friend WithEvents chk_reservas As CheckBox
    Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday)
#Region " Windows Form Designer generated code "

    Public Sub New(ByRef ds_anterior As Object)
        MyBase.New()
        ds_preparacion = ds_anterior
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
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_origen As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_generar_individual As System.Windows.Forms.CheckBox
    Friend WithEvents chk_existencias_cd As System.Windows.Forms.CheckBox
    Friend WithEvents chk_obtener_productos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_minimos As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chk_transitos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_presupuestos As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents chk_generar_region As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_saldos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_precios As System.Windows.Forms.CheckBox
    Friend WithEvents chk_resumen As System.Windows.Forms.CheckBox
    Friend WithEvents NuPSemanasReorden As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_puerto As System.Windows.Forms.ComboBox
    Friend WithEvents chk_generar_puerto As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_Generar_Proveedor As System.Windows.Forms.CheckBox
    Friend WithEvents chk_generar_global As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_preparacion_informacion))
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_origen = New System.Windows.Forms.ComboBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_existencias_cd = New System.Windows.Forms.CheckBox()
        Me.chk_obtener_productos = New System.Windows.Forms.CheckBox()
        Me.chk_minimos = New System.Windows.Forms.CheckBox()
        Me.chk_transitos = New System.Windows.Forms.CheckBox()
        Me.chk_presupuestos = New System.Windows.Forms.CheckBox()
        Me.chk_saldos = New System.Windows.Forms.CheckBox()
        Me.chk_precios = New System.Windows.Forms.CheckBox()
        Me.chk_resumen = New System.Windows.Forms.CheckBox()
        Me.chk_generar_individual = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NuPSemanasReorden = New System.Windows.Forms.NumericUpDown()
        Me.chkTiendas = New System.Windows.Forms.CheckBox()
        Me.chkProyeccion = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.chk_generar_region = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Chk_Generar_Proveedor = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmb_puerto = New System.Windows.Forms.ComboBox()
        Me.chk_generar_puerto = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chk_generar_global = New System.Windows.Forms.CheckBox()
        Me.chk_minimo_standard = New System.Windows.Forms.CheckBox()
        Me.chkPresupuestoAlterno = New System.Windows.Forms.CheckBox()
        Me.chk_reservas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NuPSemanasReorden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 2
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(488, 8)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(88, 64)
        Me.btn_generar.TabIndex = 17
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.DimGray
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Origen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Proveedor"
        '
        'cmb_origen
        '
        Me.cmb_origen.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_origen.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_origen.Location = New System.Drawing.Point(73, 48)
        Me.cmb_origen.Name = "cmb_origen"
        Me.cmb_origen.Size = New System.Drawing.Size(152, 21)
        Me.cmb_origen.TabIndex = 14
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_proveedor.Location = New System.Drawing.Point(73, 24)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(183, 21)
        Me.cmb_proveedor.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_reservas)
        Me.GroupBox1.Controls.Add(Me.chk_existencias_cd)
        Me.GroupBox1.Controls.Add(Me.chk_obtener_productos)
        Me.GroupBox1.Controls.Add(Me.chk_minimos)
        Me.GroupBox1.Controls.Add(Me.chk_transitos)
        Me.GroupBox1.Controls.Add(Me.chk_presupuestos)
        Me.GroupBox1.Controls.Add(Me.chk_saldos)
        Me.GroupBox1.Controls.Add(Me.chk_precios)
        Me.GroupBox1.Controls.Add(Me.chk_resumen)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(280, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 240)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generando ...."
        '
        'chk_existencias_cd
        '
        Me.chk_existencias_cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_existencias_cd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_existencias_cd.Location = New System.Drawing.Point(27, 44)
        Me.chk_existencias_cd.Name = "chk_existencias_cd"
        Me.chk_existencias_cd.Size = New System.Drawing.Size(160, 24)
        Me.chk_existencias_cd.TabIndex = 1
        Me.chk_existencias_cd.Text = "Obteniendo Existencias"
        '
        'chk_obtener_productos
        '
        Me.chk_obtener_productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_obtener_productos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_obtener_productos.Location = New System.Drawing.Point(27, 21)
        Me.chk_obtener_productos.Name = "chk_obtener_productos"
        Me.chk_obtener_productos.Size = New System.Drawing.Size(128, 24)
        Me.chk_obtener_productos.TabIndex = 0
        Me.chk_obtener_productos.Text = "Obtener Productos"
        '
        'chk_minimos
        '
        Me.chk_minimos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_minimos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_minimos.Location = New System.Drawing.Point(27, 128)
        Me.chk_minimos.Name = "chk_minimos"
        Me.chk_minimos.Size = New System.Drawing.Size(160, 24)
        Me.chk_minimos.TabIndex = 1
        Me.chk_minimos.Text = "Generando Minimos"
        '
        'chk_transitos
        '
        Me.chk_transitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_transitos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_transitos.Location = New System.Drawing.Point(27, 63)
        Me.chk_transitos.Name = "chk_transitos"
        Me.chk_transitos.Size = New System.Drawing.Size(160, 24)
        Me.chk_transitos.TabIndex = 1
        Me.chk_transitos.Text = "Generando Transitos"
        '
        'chk_presupuestos
        '
        Me.chk_presupuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_presupuestos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_presupuestos.Location = New System.Drawing.Point(27, 85)
        Me.chk_presupuestos.Name = "chk_presupuestos"
        Me.chk_presupuestos.Size = New System.Drawing.Size(160, 24)
        Me.chk_presupuestos.TabIndex = 1
        Me.chk_presupuestos.Text = "Generando Presupuestos"
        '
        'chk_saldos
        '
        Me.chk_saldos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_saldos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_saldos.Location = New System.Drawing.Point(27, 106)
        Me.chk_saldos.Name = "chk_saldos"
        Me.chk_saldos.Size = New System.Drawing.Size(160, 24)
        Me.chk_saldos.TabIndex = 1
        Me.chk_saldos.Text = "Generando Saldos"
        '
        'chk_precios
        '
        Me.chk_precios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_precios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_precios.Location = New System.Drawing.Point(27, 150)
        Me.chk_precios.Name = "chk_precios"
        Me.chk_precios.Size = New System.Drawing.Size(160, 24)
        Me.chk_precios.TabIndex = 1
        Me.chk_precios.Text = "Generando Precios"
        '
        'chk_resumen
        '
        Me.chk_resumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_resumen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_resumen.Location = New System.Drawing.Point(27, 193)
        Me.chk_resumen.Name = "chk_resumen"
        Me.chk_resumen.Size = New System.Drawing.Size(160, 24)
        Me.chk_resumen.TabIndex = 1
        Me.chk_resumen.Text = "Generando Resumen"
        '
        'chk_generar_individual
        '
        Me.chk_generar_individual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_generar_individual.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_generar_individual.Location = New System.Drawing.Point(139, 71)
        Me.chk_generar_individual.Name = "chk_generar_individual"
        Me.chk_generar_individual.Size = New System.Drawing.Size(106, 23)
        Me.chk_generar_individual.TabIndex = 19
        Me.chk_generar_individual.Text = "Generar Origen"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Semanas Reorden"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NuPSemanasReorden)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.chkTiendas)
        Me.GroupBox2.Controls.Add(Me.chkProyeccion)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 258)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 70)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion General ..."
        '
        'NuPSemanasReorden
        '
        Me.NuPSemanasReorden.Location = New System.Drawing.Point(137, 14)
        Me.NuPSemanasReorden.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NuPSemanasReorden.Name = "NuPSemanasReorden"
        Me.NuPSemanasReorden.Size = New System.Drawing.Size(52, 20)
        Me.NuPSemanasReorden.TabIndex = 25
        Me.NuPSemanasReorden.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'chkTiendas
        '
        Me.chkTiendas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTiendas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkTiendas.Location = New System.Drawing.Point(0, 51)
        Me.chkTiendas.Name = "chkTiendas"
        Me.chkTiendas.Size = New System.Drawing.Size(147, 23)
        Me.chkTiendas.TabIndex = 19
        Me.chkTiendas.Text = "Generar Tiendas"
        '
        'chkProyeccion
        '
        Me.chkProyeccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProyeccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkProyeccion.Location = New System.Drawing.Point(1, 33)
        Me.chkProyeccion.Name = "chkProyeccion"
        Me.chkProyeccion.Size = New System.Drawing.Size(147, 23)
        Me.chkProyeccion.TabIndex = 19
        Me.chkProyeccion.Text = "Generar Proyeccion"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmb_region)
        Me.GroupBox3.Controls.Add(Me.chk_generar_region)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 60)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Region ....."
        Me.ToolTip1.SetToolTip(Me.GroupBox3, "Generar Todos los Proveedores del Area")
        '
        'cmb_region
        '
        Me.cmb_region.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_region.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_region.Location = New System.Drawing.Point(64, 13)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(183, 21)
        Me.cmb_region.TabIndex = 13
        '
        'chk_generar_region
        '
        Me.chk_generar_region.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_generar_region.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_generar_region.Location = New System.Drawing.Point(8, 35)
        Me.chk_generar_region.Name = "chk_generar_region"
        Me.chk_generar_region.Size = New System.Drawing.Size(106, 23)
        Me.chk_generar_region.TabIndex = 19
        Me.chk_generar_region.Text = "Generar Region"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Region"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmb_origen)
        Me.GroupBox4.Controls.Add(Me.cmb_proveedor)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Chk_Generar_Proveedor)
        Me.GroupBox4.Controls.Add(Me.chk_generar_individual)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 156)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 96)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Proveedor ..."
        '
        'Chk_Generar_Proveedor
        '
        Me.Chk_Generar_Proveedor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_Generar_Proveedor.Checked = True
        Me.Chk_Generar_Proveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Generar_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Chk_Generar_Proveedor.Location = New System.Drawing.Point(9, 71)
        Me.Chk_Generar_Proveedor.Name = "Chk_Generar_Proveedor"
        Me.Chk_Generar_Proveedor.Size = New System.Drawing.Size(121, 23)
        Me.Chk_Generar_Proveedor.TabIndex = 19
        Me.Chk_Generar_Proveedor.Text = "Generar Proveedor"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmb_puerto)
        Me.GroupBox5.Controls.Add(Me.chk_generar_puerto)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 87)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(264, 64)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Puerto ....."
        Me.ToolTip1.SetToolTip(Me.GroupBox5, "Generar Todos los Proveedores del Area")
        '
        'cmb_puerto
        '
        Me.cmb_puerto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_puerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_puerto.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_puerto.Location = New System.Drawing.Point(64, 13)
        Me.cmb_puerto.Name = "cmb_puerto"
        Me.cmb_puerto.Size = New System.Drawing.Size(183, 21)
        Me.cmb_puerto.TabIndex = 13
        '
        'chk_generar_puerto
        '
        Me.chk_generar_puerto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_generar_puerto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_generar_puerto.Location = New System.Drawing.Point(8, 35)
        Me.chk_generar_puerto.Name = "chk_generar_puerto"
        Me.chk_generar_puerto.Size = New System.Drawing.Size(106, 23)
        Me.chk_generar_puerto.TabIndex = 19
        Me.chk_generar_puerto.Text = "Generar Puerto"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Puerto"
        '
        'chk_generar_global
        '
        Me.chk_generar_global.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_generar_global.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_generar_global.Location = New System.Drawing.Point(22, 2)
        Me.chk_generar_global.Name = "chk_generar_global"
        Me.chk_generar_global.Size = New System.Drawing.Size(157, 23)
        Me.chk_generar_global.TabIndex = 19
        Me.chk_generar_global.Text = "Todas las Empresas"
        '
        'chk_minimo_standard
        '
        Me.chk_minimo_standard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_minimo_standard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_minimo_standard.Location = New System.Drawing.Point(307, 272)
        Me.chk_minimo_standard.Name = "chk_minimo_standard"
        Me.chk_minimo_standard.Size = New System.Drawing.Size(147, 23)
        Me.chk_minimo_standard.TabIndex = 26
        Me.chk_minimo_standard.Text = "Minimo Standard"
        '
        'chkPresupuestoAlterno
        '
        Me.chkPresupuestoAlterno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPresupuestoAlterno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkPresupuestoAlterno.Location = New System.Drawing.Point(307, 301)
        Me.chkPresupuestoAlterno.Name = "chkPresupuestoAlterno"
        Me.chkPresupuestoAlterno.Size = New System.Drawing.Size(147, 23)
        Me.chkPresupuestoAlterno.TabIndex = 28
        Me.chkPresupuestoAlterno.Text = "Presupuesto Alterno"
        '
        'chk_reservas
        '
        Me.chk_reservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_reservas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_reservas.Location = New System.Drawing.Point(27, 170)
        Me.chk_reservas.Name = "chk_reservas"
        Me.chk_reservas.Size = New System.Drawing.Size(160, 24)
        Me.chk_reservas.TabIndex = 2
        Me.chk_reservas.Text = "Generando Reservas"
        '
        'frm_scm_preparacion_informacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 346)
        Me.Controls.Add(Me.chkPresupuestoAlterno)
        Me.Controls.Add(Me.chk_minimo_standard)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chk_generar_global)
        Me.Controls.Add(Me.btn_generar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_scm_preparacion_informacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Praparacion de Informacion .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NuPSemanasReorden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos_Asociados()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            otrans.open()

            'ls_sql = "pa_var_um_proveedor_procedencia "
            'If Me.chk_generar_global.CheckState = CheckState.Checked Then
            '    ls_sql += "NULL,'0090000000'"
            'Else
            '    ls_sql += "'" & gs_empresa & "',"
            '    If gs_empresa = "ALAMSA" Then ls_sql += "'0090000000'" Else ls_sql += "'0060000000'"
            'End If

            ls_sql = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"

            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "origenes"
            If ds_preparacion.Tables.Contains("origenes") Then ds_preparacion.Tables.Remove("origenes")

            ds_preparacion.Tables.Add(dt.Copy)

            If Me.chk_generar_global.CheckState = CheckState.Unchecked Then
                ds_preparacion.Tables("origenes").DefaultView.RowFilter = "proveedor = '" & Me.cmb_proveedor.SelectedValue & "'"
            End If

            Me.cmb_origen.DataSource = ds_preparacion.Tables("origenes")
            Me.cmb_origen.DisplayMember = "origen"
            Me.cmb_origen.ValueMember = "origen"


            ls_sql = "pa_var_um_prv_proveedor_origen "
            If Me.chk_generar_global.CheckState = CheckState.Checked Then ls_sql += "NULL" Else ls_sql += "'" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_region.DataSource = dt
            Me.cmb_region.DisplayMember = "region"
            Me.cmb_region.ValueMember = "region"


            ''Puertos
            ls_sql = "pa_var_um_prv_proveedor_puerto "
            If Me.chk_generar_global.CheckState = CheckState.Checked Then ls_sql += "NULL" Else ls_sql += "'" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            Me.cmb_puerto.DataSource = dt
            Me.cmb_puerto.DisplayMember = "puerto_consolida"
            Me.cmb_puerto.ValueMember = "puerto_consolida"




        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General

        Try
            otrans.open()

            'ls_sql = "pa_var_um_proveedor_producto '" & gs_empresa & "','" & _
            '            IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            ls_sql = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            dt = ClsGen.ValoresDistinto(dt, "proveedor".Split(","))

            dt.TableName = "proveedores"

            ds_preparacion.Tables.Add(dt.Copy)
            Me.cmb_proveedor.DataSource = ds_preparacion.Tables("proveedores")
            Me.cmb_proveedor.ValueMember = "proveedor"
            Me.cmb_proveedor.DisplayMember = "proveedor"

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Llenar_Maestros_Globales()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_prv_proveedor "
            If Me.chk_generar_global.CheckState = CheckState.Checked Then
                ls_sql += "NULL"
            Else
                ls_sql += "'" & gs_empresa & "'"
            End If

            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_proveedor"

            If ds_preparacion.Tables.Contains("prv_proveedor") Then ds_preparacion.Tables.Remove("prv_proveedor")
            ds_preparacion.Tables.Add(dt.Copy)

            ''Proveedores
            ls_sql = "pa_sel_um_prv_frecuencia_compra "
            If Me.chk_generar_global.CheckState = CheckState.Checked Then
                ls_sql += "NULL"
            Else
                ls_sql += "'" & gs_empresa & "'"
            End If
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_frecuencia_compra"

            If ds_preparacion.Tables.Contains("prv_frecuencia_compra") Then ds_preparacion.Tables.Remove("prv_frecuencia_compra")
            ds_preparacion.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_prv_dias_inventario_minimo "
            If Me.chk_generar_global.CheckState = CheckState.Checked Then
                ls_sql += "NULL"
            Else
                ls_sql += "'" & gs_empresa & "'"
            End If

            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_dias_inventario_minimo"

            If ds_preparacion.Tables.Contains("prv_dias_inventario_minimo") Then ds_preparacion.Tables.Remove("prv_dias_inventario_minimo")
            ds_preparacion.Tables.Add(dt.Copy)



        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
    End Sub

    Private Sub Llenar_Maestros()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")
        Try
            oTrans.open()

            ''Parametros Generales
            ls_sql = "pa_sel_um_scm_parametros_generales"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "scm_parametros_generales"
            ds_preparacion.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_pg_pareto "
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "pg_pareto"
            ds_preparacion.Tables.Add(dt.Copy)

            pi_meses_adicionales = IIf(ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing


        End Try
    End Sub

    Private Sub Crear_Estructuras()
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Try
            oCompras.Crear_Estructura()

        Catch ex As Exception
        Finally
            oCompras = Nothing

        End Try
    End Sub


    Private Sub Generar_Informacion()
        Dim ls_sql As String
        Dim iaux As Integer
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Dim clsGen As New ClasesGenerales.General



        Try
            Otrans.open()
            If Me.chkProyeccion.Checked = True Then 'Cuando es proyeccion solo debe realizar las semanas reorden 1 vez
                Me.NuPSemanasReorden.Value = 1
                oCompras.proyeccion = True
            End If

            If Me.chk_minimo_standard.Checked = True Then
                oCompras.minimo_standard = True
            End If

            Me.chk_obtener_productos.Checked = True

            If Me.chk_generar_global.CheckState = CheckState.Unchecked Then oCompras.Empresa = gs_empresa
            If Me.chk_generar_region.CheckState = CheckState.Checked Then oCompras.Region = Me.cmb_region.Text
            If Me.chk_generar_individual.CheckState = CheckState.Checked Then oCompras.SetOrigen(cmb_origen.Text)



            oCompras.SetProductoLimite(IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000"))
            If Me.Chk_Generar_Proveedor.CheckState = CheckState.Checked Then oCompras.Proveedor = Me.cmb_proveedor.Text

            If Me.chk_generar_puerto.CheckState = CheckState.Checked Then oCompras.Puerto = Me.cmb_puerto.Text


            oCompras.Inicializar_Productos(Me.chk_generar_global.Checked, Me.chk_generar_region.Checked, Me.chk_generar_individual.Checked, True)
            'oCompras.Inicializar_Productos(Me.chk_generar_global.Checked, Me.chk_generar_region.Checked, Me.chk_generar_individual.Checked, False) ''Generar Toda La informacion
            oCompras.Revisar_productoDerivados("detalle_productos")
            oCompras.generarExistencia(False, Me.chkTiendas.Checked)
            oCompras.generarExistenciaLote(False, Me.chkTiendas.Checked)
            oCompras.generarExistenciaSerie(False, Me.chkTiendas.Checked) '20241113 (c)


            '    ''Existencia CD
            Me.chk_existencias_cd.Checked = True

            ''Generando Transitos
            Me.chk_transitos.Checked = True
            '   Generar_Transitos()

            oCompras.generarTransitos(psemanaActual, IIf(Me.chk_generar_individual.Checked = True, Me.cmb_origen.Text, ""), False)

            Me.chk_reservas.Checked = True
            Generar_Reservas()
            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""

            ''Generando Presupuestos
            Me.chk_presupuestos.Checked = True
            '  Generar_Presupuestos()

            If Me.chkPresupuestoAlterno.Checked = True Then
                oCompras.generarPresupuestosAlterno(psemanaActual, IIf(Me.chk_generar_individual.Checked = True, Me.cmb_origen.Text, ""), False)

            Else
                oCompras.generarPresupuestos(psemanaActual, IIf(Me.chk_generar_individual.Checked = True, Me.cmb_origen.Text, ""), False)

            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            oCompras = Nothing
            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""

        End Try


        Generar_Pedido_Sugerido()

        ''Agrego Informacion del Calculo Anterior
        Try
            If dtCalculoPrevio.Rows.Count > 0 Then
                Dim draux As DataRow
                For Each dr In dtCalculoPrevio.Rows
                    draux = ds_preparacion.Tables("detalle_productos").NewRow

                    For Each dc As DataColumn In dtCalculoPrevio.Columns
                        draux(dc.ColumnName) = dr(dc.ColumnName)
                    Next
                    ds_preparacion.Tables("detalle_productos").Rows.Add(draux)
                Next
            End If

        Catch ex As Exception

        End Try

        Me.chk_precios.Checked = True
        Generar_Precios()



        Me.chk_resumen.Checked = True
    End Sub


    Private Sub Generar_Reservas()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ldreserva As Double

        Try
            dt = clsGen.selectQuery("SCM", "pa_var_um_scm_reservas_exterior")

            For Each dr As DataRow In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "'"
                ldreserva = 0
                If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                    ldreserva = ds_preparacion.Tables("detalle_productos").DefaultView(0).Item("reservas")
                    ldreserva = ldreserva + dr.Item("cantidad")
                    ds_preparacion.Tables("detalle_productos").DefaultView(0).Item("reservas") = ldreserva
                End If

            Next

            Try
                dt.TableName = "reservas"
                ds_preparacion.Tables.Add(dt.Copy)
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

    End Sub


    ''Generar Transitos
    Private Sub Generar_Transitos()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql, ls_mes As String
        Dim nsemana As String
        Dim ntotalSemanas As Integer
        Dim ntransito As Integer

        Try
            otrans.open()
            Dim dtunicos As DataTable = ClsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_var_um_transito_productos '" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "'," & _
                         IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL")

                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    If dr.Item("producto") = "0010101018" Then
                        dr.Item("producto") = "0010101018"
                    End If

                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"

                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)


                        If dr.Item("semana") < psemanaActual And DateTime.Parse(dr.Item("fecha_vencimiento").ToString).Year = Today.Year Then
                            nsemana = 0
                        Else
                            nsemana = dr.Item("semana") - psemanaActual
                        End If
                        If DateTime.Parse(dr.Item("fecha_vencimiento").ToString).Year = Today.Year Then
                            ntotalSemanas = DatePart(DateInterval.WeekOfYear, Date.Parse("01/01/" & Today.Year + 1).AddDays(-1), FirstDayOfWeek.Monday)
                        Else
                            ntotalSemanas = 62
                        End If



                        If nsemana < 0 Then nsemana += ntotalSemanas
                        ls_mes = "transito"
                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")

                        ntransito = IIf(dr.Item("CantidadArriboPuerto") Is System.DBNull.Value, dr.Item("cajas_pedidas"), dr.Item("cantidadArriboPuerto"))
                        drv.Item(ls_mes) += ntransito
                    End If
                Next

                Try
                    dt.TableName = "transitos"
                    ds_preparacion.Tables.Add(dt.Copy)
                Catch ex As Exception

                End Try


            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    ''Generar Presupuestos, pendiente validar que se incluya mes actual
    Private Sub Generar_Presupuestos()
        Dim ls_sql, ls_mes As String
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")
        Dim clsGen As New ClasesGenerales.General
        Dim nsemana As Integer

        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux In dtunicos.Rows


                ls_sql = "pa_sel_um_producto_presupuesto " & pi_meses_adicionales & ", '" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "',NULL"
                'IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL")
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows

                    'ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
                    '            "producto = '" & dr.Item("producto") & "'"

                    'If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
                    '    For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView


                    '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                    '                    = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

                    '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    '            'Try
                    '            '    iaux = (drv2.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
                    '            'Catch ex As Exception
                    '            '    iaux = 0
                    '            'End Try
                    '            'drv.Item("bodegas") += iaux
                    '            'drv2.Item("cajas") = iaux
                    '            ''drv.Item("existencia") += iaux


                    '            nsemana = dr.Item("semana") - psemanaActual

                    '            If nsemana < 0 Then nsemana += 52

                    '            ls_mes = "ppto"
                    '            If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")
                    '            drv.Item(ls_mes) += dr.Item("ppto_semanal")
                    '        Next

                    '    Next
                    'Else
                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"


                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                        nsemana = dr.Item("semana") - psemanaActual

                        If nsemana < 0 Then nsemana += 62

                        ls_mes = "ppto"
                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")
                        drv.Item(ls_mes) += dr.Item("ppto_semanal")

                    End If

                    'End If





                Next
            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try


    End Sub

    Private Sub Generar_Precios()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General

        Dim ls_sql As String


        Try
            otrans.open()
            Dim dtunicos As DataTable = clsgen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_sel_um_listaprecioD '" & dr_aux.Item("empresa") & "',NULL,'" & _
                        ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("lista_precio").ToString & "'"


                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"

                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                        'If dr.Item("meses_diferencia") <= 0 + pi_meses_adicionales Then
                        drv.Item("fob") = dr.Item("valor") * drv.Item("uxc")
                        'Else

                        '  ls_mes = "transito+" & (dr.Item("meses_diferencia") + pi_meses_adicionales).ToString.PadLeft(2, "0")
                        ' drv.Item(ls_mes) = drv.Item(ls_mes) + dr.Item("cajas_pedidas")
                    End If
                    'End If
                Next
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Generar_Pedido_Sugerido()
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Dim clsGen As New ClasesGenerales.General

        Try
            Me.chk_saldos.Checked = True
            oCompras.Generar_SaldosyCoberturas(False)

            For iaux As Integer = 0 To NuPSemanasReorden.Value - 1
                Me.chk_minimos.Checked = True
                oCompras.Minimos_Maximos(iaux, IIf(iaux = 0, True, False))
                ''Generando Saldos
                Me.chk_saldos.Checked = True


                Try
                    oCompras.Generar_Pedido_Sugerido(iaux, IIf(iaux = 0, True, False))

                Catch ex As Exception
                    clsGen.Escribir_Log(ex.ToString)
                    clsGen.Escribir_Log(ex.Message)

                End Try

            Next



        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
            clsGen.Escribir_Log(ex.Message)
        Finally
            oCompras = Nothing
            clsGen = Nothing

        End Try

    End Sub

    Private Sub generarResumen()
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Try
            oCompras.generarResumen()

            '(c) 20160719
            oCompras.generarResumenTotal()


        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try
    End Sub


    Private Sub frm_scm_preparacion_informacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Combos_Asociados()
        Llenar_Maestros()
        Llenar_Maestros_Globales()
        Crear_Estructuras()
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        If chk_generar_global.CheckState = CheckState.Unchecked Then
            ds_preparacion.Tables("origenes").DefaultView.RowFilter = "proveedor = '" & Me.cmb_proveedor.SelectedValue & "'"
        End If
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Generar_Informacion()
        Me.Close()
    End Sub



    Private Sub chk_generar_global_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_generar_global.CheckedChanged
        If chk_generar_global.CheckState = CheckState.Checked Then
            cmb_proveedor.Enabled = False
        Else
            cmb_proveedor.Enabled = True
        End If
        Llenar_Combos_Asociados()
        Llenar_Maestros_Globales()
    End Sub

    Private Sub cmb_region_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_region.SelectedIndexChanged
        'ds_preparacion.Tables("proveedores").DefaultView.RowFilter = "Region = '" & Me.cmb_region.Text & "'"
    End Sub
End Class
