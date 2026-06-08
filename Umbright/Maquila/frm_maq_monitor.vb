Imports System.IO
Public Class frm_maq_monitor
    Inherits System.Windows.Forms.Form
    Dim Ods As DataSet
    Dim simagen1, simagen2 As String
    Friend WithEvents tb_detalle_op As System.Windows.Forms.TabPage
    Friend WithEvents tb_listado_ordenes As System.Windows.Forms.TabPage
    Friend WithEvents txt_filtro As System.Windows.Forms.TextBox
    Friend WithEvents cb_condicion As System.Windows.Forms.ComboBox
    Friend WithEvents cb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents tbn_lo_mostrar_ordenes As System.Windows.Forms.Button
    Friend WithEvents dg_lo_listado_ordenes As System.Windows.Forms.DataGrid
    Friend WithEvents tb_estadisticas As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelBaseProduccion As System.Windows.Forms.Panel
    Friend WithEvents PanelRellenoProduccion As System.Windows.Forms.Panel
    Friend WithEvents txt_estadisticas_producido As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_estadisticas_op As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_estadisticas_ventas As System.Windows.Forms.DataGrid
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar_estadisticas As System.Windows.Forms.Button
    Friend WithEvents cmb_pack_estadisticas As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_estadisticas_existencia As System.Windows.Forms.TextBox
    Friend WithEvents tb_nuevo_op As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dg_op_pendientes As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents solicitado_por As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_op_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_op_numero_orden As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_op_cantidad_solicitada As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_op_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_op_mostrar_ordenes As System.Windows.Forms.Button
    Friend WithEvents dg_op_producto As System.Windows.Forms.DataGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dg_detalle_pack_op As System.Windows.Forms.DataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_op_pack As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_detalle_pack As System.Windows.Forms.TabPage
    Friend WithEvents txt_total_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_detalle_pack_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_detalle_pack_inventario_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_detalle_pack_barra As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents panel1_detalle As System.Windows.Forms.StatusBarPanel
    Friend WithEvents panel2_detalle As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txt_descripcion_pack As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_detalle As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dg_detalle_pack_insumos As System.Windows.Forms.DataGrid
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pb_fotopack_1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_guardar_detalle_pack As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dg_detalle_pack As System.Windows.Forms.DataGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmb_detalle_pack As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pb_fotopack_2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tp_packs_activos As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_detalle_pack As System.Windows.Forms.Button
    Friend WithEvents btn_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_estadisticas As System.Windows.Forms.Button
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_detalle_total As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txt_detalle_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_detalle_orden As System.Windows.Forms.TextBox
    Friend WithEvents txt_detalle_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txt_precio_fact As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txt_costo_unitario As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo_base As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txt_costo_materiales As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_costo_equipo As System.Windows.Forms.DataGridView
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents dgv_costo_primo As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_materiales As System.Windows.Forms.DataGridView
    Friend WithEvents btn_productos_desarme As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha_Operacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents nudMinutosParaEleborar As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label40 As Label
    Friend WithEvents txt_Tipo_Produccion As TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_Maquila As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Mant_Materiales_Auxiliares As System.Windows.Forms.MenuItem
    Friend WithEvents mpro_asignacion_ordenes As System.Windows.Forms.MenuItem
    Friend WithEvents mpro_proceso_produccion As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_monitor))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.Menu_Maquila = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.Mant_Materiales_Auxiliares = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mpro_asignacion_ordenes = New System.Windows.Forms.MenuItem()
        Me.mpro_proceso_produccion = New System.Windows.Forms.MenuItem()
        Me.tb_detalle_op = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtp_Fecha_Operacion = New System.Windows.Forms.DateTimePicker()
        Me.dgv_materiales = New System.Windows.Forms.DataGridView()
        Me.dgv_costo_primo = New System.Windows.Forms.DataGridView()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.dgv_costo_equipo = New System.Windows.Forms.DataGridView()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txt_costo_base = New System.Windows.Forms.TextBox()
        Me.txt_costo_total = New System.Windows.Forms.TextBox()
        Me.txt_costo_unitario = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_costo_materiales = New System.Windows.Forms.TextBox()
        Me.txt_precio_fact = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_detalle_codigo = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txt_detalle_descripcion = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_detalle_total = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txt_detalle_orden = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tb_listado_ordenes = New System.Windows.Forms.TabPage()
        Me.txt_filtro = New System.Windows.Forms.TextBox()
        Me.cb_condicion = New System.Windows.Forms.ComboBox()
        Me.cb_campos = New System.Windows.Forms.ComboBox()
        Me.tbn_lo_mostrar_ordenes = New System.Windows.Forms.Button()
        Me.dg_lo_listado_ordenes = New System.Windows.Forms.DataGrid()
        Me.tb_estadisticas = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PanelBaseProduccion = New System.Windows.Forms.Panel()
        Me.PanelRellenoProduccion = New System.Windows.Forms.Panel()
        Me.txt_estadisticas_producido = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dg_estadisticas_op = New System.Windows.Forms.DataGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dg_estadisticas_ventas = New System.Windows.Forms.DataGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar_estadisticas = New System.Windows.Forms.Button()
        Me.cmb_pack_estadisticas = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_estadisticas_existencia = New System.Windows.Forms.TextBox()
        Me.tb_nuevo_op = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dg_op_pendientes = New System.Windows.Forms.DataGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txt_Tipo_Produccion = New System.Windows.Forms.TextBox()
        Me.btn_productos_desarme = New System.Windows.Forms.Button()
        Me.solicitado_por = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_op_observaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_op_numero_orden = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_op_cantidad_solicitada = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_op_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_nuevo_orden_produccion = New System.Windows.Forms.Button()
        Me.btn_guardar_orden_produccion = New System.Windows.Forms.Button()
        Me.btn_op_mostrar_ordenes = New System.Windows.Forms.Button()
        Me.dg_op_producto = New System.Windows.Forms.DataGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dg_detalle_pack_op = New System.Windows.Forms.DataGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_op_pack = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_detalle_pack = New System.Windows.Forms.TabPage()
        Me.nudMinutosParaEleborar = New System.Windows.Forms.NumericUpDown()
        Me.txt_total_costo = New System.Windows.Forms.TextBox()
        Me.txt_detalle_pack_cliente = New System.Windows.Forms.TextBox()
        Me.txt_detalle_pack_inventario_minimo = New System.Windows.Forms.TextBox()
        Me.txt_detalle_pack_barra = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.panel1_detalle = New System.Windows.Forms.StatusBarPanel()
        Me.panel2_detalle = New System.Windows.Forms.StatusBarPanel()
        Me.txt_descripcion_pack = New System.Windows.Forms.TextBox()
        Me.txt_codigo_detalle = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dg_detalle_pack_insumos = New System.Windows.Forms.DataGrid()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pb_fotopack_1 = New System.Windows.Forms.PictureBox()
        Me.btn_guardar_detalle_pack = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dg_detalle_pack = New System.Windows.Forms.DataGrid()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmb_detalle_pack = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pb_fotopack_2 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tp_packs_activos = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_detalle_pack = New System.Windows.Forms.Button()
        Me.btn_orden_produccion = New System.Windows.Forms.Button()
        Me.btn_estadisticas = New System.Windows.Forms.Button()
        Me.DataGrid2 = New System.Windows.Forms.DataGrid()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_detalle_op.SuspendLayout()
        CType(Me.dgv_materiales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_costo_primo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_costo_equipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tb_listado_ordenes.SuspendLayout()
        CType(Me.dg_lo_listado_ordenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_estadisticas.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.PanelBaseProduccion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_estadisticas_op, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_estadisticas_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.tb_nuevo_op.SuspendLayout()
        CType(Me.dg_op_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_op_producto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_pack_op, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_detalle_pack.SuspendLayout()
        CType(Me.nudMinutosParaEleborar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel1_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel2_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_fotopack_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_pack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_fotopack_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_packs_activos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "pack.png")
        Me.ImageList1.Images.SetKeyName(2, "pack2.png")
        Me.ImageList1.Images.SetKeyName(3, "3.png")
        Me.ImageList1.Images.SetKeyName(4, "grafica1.png")
        '
        'Menu_Maquila
        '
        Me.Menu_Maquila.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Mant_Materiales_Auxiliares})
        Me.MenuItem1.Text = "Mantenimiento"
        '
        'Mant_Materiales_Auxiliares
        '
        Me.Mant_Materiales_Auxiliares.Index = 0
        Me.Mant_Materiales_Auxiliares.Text = "Materiales Auxiliares"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mpro_asignacion_ordenes, Me.mpro_proceso_produccion})
        Me.MenuItem2.Text = "Procesos"
        '
        'mpro_asignacion_ordenes
        '
        Me.mpro_asignacion_ordenes.Index = 0
        Me.mpro_asignacion_ordenes.Text = "Asignacion De Ordenes"
        '
        'mpro_proceso_produccion
        '
        Me.mpro_proceso_produccion.Index = 1
        Me.mpro_proceso_produccion.Text = "Proceso Produccion"
        '
        'tb_detalle_op
        '
        Me.tb_detalle_op.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_detalle_op.Controls.Add(Me.Label26)
        Me.tb_detalle_op.Controls.Add(Me.dtp_Fecha_Operacion)
        Me.tb_detalle_op.Controls.Add(Me.dgv_materiales)
        Me.tb_detalle_op.Controls.Add(Me.dgv_costo_primo)
        Me.tb_detalle_op.Controls.Add(Me.btn_guardar)
        Me.tb_detalle_op.Controls.Add(Me.dgv_costo_equipo)
        Me.tb_detalle_op.Controls.Add(Me.GroupBox8)
        Me.tb_detalle_op.Controls.Add(Me.GroupBox7)
        Me.tb_detalle_op.Controls.Add(Me.Label33)
        Me.tb_detalle_op.Controls.Add(Me.txt_detalle_orden)
        Me.tb_detalle_op.Controls.Add(Me.Label32)
        Me.tb_detalle_op.Controls.Add(Me.Label30)
        Me.tb_detalle_op.Controls.Add(Me.Label31)
        Me.tb_detalle_op.Controls.Add(Me.Label25)
        Me.tb_detalle_op.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.tb_detalle_op.ForeColor = System.Drawing.Color.Black
        Me.tb_detalle_op.Location = New System.Drawing.Point(4, 22)
        Me.tb_detalle_op.Name = "tb_detalle_op"
        Me.tb_detalle_op.Size = New System.Drawing.Size(895, 524)
        Me.tb_detalle_op.TabIndex = 6
        Me.tb_detalle_op.Text = "Detalle Orden"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label26.Location = New System.Drawing.Point(355, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(90, 14)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Fecha Operacion"
        '
        'dtp_Fecha_Operacion
        '
        Me.dtp_Fecha_Operacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha_Operacion.Location = New System.Drawing.Point(451, 38)
        Me.dtp_Fecha_Operacion.Name = "dtp_Fecha_Operacion"
        Me.dtp_Fecha_Operacion.Size = New System.Drawing.Size(83, 21)
        Me.dtp_Fecha_Operacion.TabIndex = 78
        '
        'dgv_materiales
        '
        Me.dgv_materiales.AllowUserToAddRows = False
        Me.dgv_materiales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_materiales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_materiales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_materiales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_materiales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_materiales.Location = New System.Drawing.Point(23, 304)
        Me.dgv_materiales.Name = "dgv_materiales"
        Me.dgv_materiales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_materiales.RowHeadersWidth = 20
        Me.dgv_materiales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_materiales.Size = New System.Drawing.Size(373, 193)
        Me.dgv_materiales.TabIndex = 77
        '
        'dgv_costo_primo
        '
        Me.dgv_costo_primo.AllowUserToAddRows = False
        Me.dgv_costo_primo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_costo_primo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_costo_primo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_costo_primo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_costo_primo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_costo_primo.Location = New System.Drawing.Point(23, 172)
        Me.dgv_costo_primo.Name = "dgv_costo_primo"
        Me.dgv_costo_primo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_costo_primo.RowHeadersWidth = 20
        Me.dgv_costo_primo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_costo_primo.Size = New System.Drawing.Size(373, 95)
        Me.dgv_costo_primo.TabIndex = 76
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
        Me.btn_guardar.Location = New System.Drawing.Point(790, 68)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(97, 84)
        Me.btn_guardar.TabIndex = 75
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'dgv_costo_equipo
        '
        Me.dgv_costo_equipo.AllowUserToAddRows = False
        Me.dgv_costo_equipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_costo_equipo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_costo_equipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_costo_equipo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_costo_equipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_costo_equipo.Location = New System.Drawing.Point(413, 173)
        Me.dgv_costo_equipo.Name = "dgv_costo_equipo"
        Me.dgv_costo_equipo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv_costo_equipo.RowHeadersWidth = 20
        Me.dgv_costo_equipo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_costo_equipo.Size = New System.Drawing.Size(361, 95)
        Me.dgv_costo_equipo.TabIndex = 74
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label34)
        Me.GroupBox8.Controls.Add(Me.Label35)
        Me.GroupBox8.Controls.Add(Me.Label36)
        Me.GroupBox8.Controls.Add(Me.txt_costo_base)
        Me.GroupBox8.Controls.Add(Me.txt_costo_total)
        Me.GroupBox8.Controls.Add(Me.txt_costo_unitario)
        Me.GroupBox8.Controls.Add(Me.Label37)
        Me.GroupBox8.Controls.Add(Me.txt_costo_materiales)
        Me.GroupBox8.Controls.Add(Me.txt_precio_fact)
        Me.GroupBox8.Controls.Add(Me.Label38)
        Me.GroupBox8.Location = New System.Drawing.Point(413, 270)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(361, 227)
        Me.GroupBox8.TabIndex = 73
        Me.GroupBox8.TabStop = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(4, 17)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(164, 14)
        Me.Label34.TabIndex = 57
        Me.Label34.Text = "Costo Base (C.Primo + C.Equipo)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(178, 17)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(177, 14)
        Me.Label35.TabIndex = 59
        Me.Label35.Text = "Costo Total (C.Base + C.Materiales)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(178, 89)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(151, 14)
        Me.Label36.TabIndex = 61
        Me.Label36.Text = "Costo Unitario (C.Base / Total)"
        '
        'txt_costo_base
        '
        Me.txt_costo_base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_costo_base.Enabled = False
        Me.txt_costo_base.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_costo_base.Location = New System.Drawing.Point(7, 34)
        Me.txt_costo_base.Name = "txt_costo_base"
        Me.txt_costo_base.ReadOnly = True
        Me.txt_costo_base.Size = New System.Drawing.Size(161, 38)
        Me.txt_costo_base.TabIndex = 62
        Me.txt_costo_base.TabStop = False
        '
        'txt_costo_total
        '
        Me.txt_costo_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_costo_total.Enabled = False
        Me.txt_costo_total.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_costo_total.Location = New System.Drawing.Point(181, 34)
        Me.txt_costo_total.Name = "txt_costo_total"
        Me.txt_costo_total.ReadOnly = True
        Me.txt_costo_total.Size = New System.Drawing.Size(174, 38)
        Me.txt_costo_total.TabIndex = 63
        Me.txt_costo_total.TabStop = False
        '
        'txt_costo_unitario
        '
        Me.txt_costo_unitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_costo_unitario.Enabled = False
        Me.txt_costo_unitario.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_costo_unitario.Location = New System.Drawing.Point(181, 106)
        Me.txt_costo_unitario.Name = "txt_costo_unitario"
        Me.txt_costo_unitario.ReadOnly = True
        Me.txt_costo_unitario.Size = New System.Drawing.Size(174, 38)
        Me.txt_costo_unitario.TabIndex = 64
        Me.txt_costo_unitario.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(6, 162)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(91, 14)
        Me.Label37.TabIndex = 65
        Me.Label37.Text = "Costo De Factura"
        '
        'txt_costo_materiales
        '
        Me.txt_costo_materiales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_costo_materiales.Enabled = False
        Me.txt_costo_materiales.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_costo_materiales.Location = New System.Drawing.Point(9, 107)
        Me.txt_costo_materiales.Name = "txt_costo_materiales"
        Me.txt_costo_materiales.ReadOnly = True
        Me.txt_costo_materiales.Size = New System.Drawing.Size(159, 38)
        Me.txt_costo_materiales.TabIndex = 68
        Me.txt_costo_materiales.TabStop = False
        '
        'txt_precio_fact
        '
        Me.txt_precio_fact.BackColor = System.Drawing.Color.LightGray
        Me.txt_precio_fact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_fact.Enabled = False
        Me.txt_precio_fact.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_precio_fact.Location = New System.Drawing.Point(9, 179)
        Me.txt_precio_fact.Name = "txt_precio_fact"
        Me.txt_precio_fact.ReadOnly = True
        Me.txt_precio_fact.Size = New System.Drawing.Size(167, 38)
        Me.txt_precio_fact.TabIndex = 66
        Me.txt_precio_fact.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(6, 89)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(87, 14)
        Me.Label38.TabIndex = 67
        Me.Label38.Text = "Costo Materiales"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Controls.Add(Me.txt_detalle_codigo)
        Me.GroupBox7.Controls.Add(Me.Label28)
        Me.GroupBox7.Controls.Add(Me.txt_detalle_descripcion)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.txt_detalle_total)
        Me.GroupBox7.Location = New System.Drawing.Point(51, 68)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(678, 84)
        Me.GroupBox7.TabIndex = 69
        Me.GroupBox7.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(12, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 14)
        Me.Label27.TabIndex = 42
        Me.Label27.Text = "Codigo"
        '
        'txt_detalle_codigo
        '
        Me.txt_detalle_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_codigo.Enabled = False
        Me.txt_detalle_codigo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txt_detalle_codigo.Location = New System.Drawing.Point(15, 47)
        Me.txt_detalle_codigo.Name = "txt_detalle_codigo"
        Me.txt_detalle_codigo.ReadOnly = True
        Me.txt_detalle_codigo.Size = New System.Drawing.Size(91, 23)
        Me.txt_detalle_codigo.TabIndex = 43
        Me.txt_detalle_codigo.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(109, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 14)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Descripcion"
        '
        'txt_detalle_descripcion
        '
        Me.txt_detalle_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_descripcion.Enabled = False
        Me.txt_detalle_descripcion.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txt_detalle_descripcion.Location = New System.Drawing.Point(112, 48)
        Me.txt_detalle_descripcion.Name = "txt_detalle_descripcion"
        Me.txt_detalle_descripcion.ReadOnly = True
        Me.txt_detalle_descripcion.Size = New System.Drawing.Size(444, 23)
        Me.txt_detalle_descripcion.TabIndex = 45
        Me.txt_detalle_descripcion.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(559, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(29, 14)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "Total"
        '
        'txt_detalle_total
        '
        Me.txt_detalle_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_total.Enabled = False
        Me.txt_detalle_total.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txt_detalle_total.Location = New System.Drawing.Point(562, 40)
        Me.txt_detalle_total.Name = "txt_detalle_total"
        Me.txt_detalle_total.ReadOnly = True
        Me.txt_detalle_total.Size = New System.Drawing.Size(104, 30)
        Me.txt_detalle_total.TabIndex = 47
        Me.txt_detalle_total.TabStop = False
        Me.txt_detalle_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(410, 155)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(87, 14)
        Me.Label33.TabIndex = 55
        Me.Label33.Text = "Costo del Equipo"
        '
        'txt_detalle_orden
        '
        Me.txt_detalle_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_orden.Enabled = False
        Me.txt_detalle_orden.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txt_detalle_orden.ForeColor = System.Drawing.Color.Black
        Me.txt_detalle_orden.Location = New System.Drawing.Point(613, 29)
        Me.txt_detalle_orden.Name = "txt_detalle_orden"
        Me.txt_detalle_orden.ReadOnly = True
        Me.txt_detalle_orden.Size = New System.Drawing.Size(104, 30)
        Me.txt_detalle_orden.TabIndex = 50
        Me.txt_detalle_orden.TabStop = False
        Me.txt_detalle_orden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(20, 280)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(56, 14)
        Me.Label32.TabIndex = 54
        Me.Label32.Text = "Materiales"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(610, 12)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 14)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "No. Orden"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(20, 155)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(64, 14)
        Me.Label31.TabIndex = 52
        Me.Label31.Text = "Costo Primo"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(32, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(210, 25)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Orden de Produccion"
        '
        'tb_listado_ordenes
        '
        Me.tb_listado_ordenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_listado_ordenes.Controls.Add(Me.txt_filtro)
        Me.tb_listado_ordenes.Controls.Add(Me.cb_condicion)
        Me.tb_listado_ordenes.Controls.Add(Me.cb_campos)
        Me.tb_listado_ordenes.Controls.Add(Me.tbn_lo_mostrar_ordenes)
        Me.tb_listado_ordenes.Controls.Add(Me.dg_lo_listado_ordenes)
        Me.tb_listado_ordenes.ForeColor = System.Drawing.Color.Black
        Me.tb_listado_ordenes.Location = New System.Drawing.Point(4, 22)
        Me.tb_listado_ordenes.Name = "tb_listado_ordenes"
        Me.tb_listado_ordenes.Size = New System.Drawing.Size(895, 524)
        Me.tb_listado_ordenes.TabIndex = 4
        Me.tb_listado_ordenes.Text = "Listado de Ordenes"
        '
        'txt_filtro
        '
        Me.txt_filtro.Location = New System.Drawing.Point(215, 14)
        Me.txt_filtro.Name = "txt_filtro"
        Me.txt_filtro.Size = New System.Drawing.Size(304, 22)
        Me.txt_filtro.TabIndex = 22
        '
        'cb_condicion
        '
        Me.cb_condicion.FormattingEnabled = True
        Me.cb_condicion.Items.AddRange(New Object() {"<", "=", ">", "<>", "like"})
        Me.cb_condicion.Location = New System.Drawing.Point(144, 13)
        Me.cb_condicion.Name = "cb_condicion"
        Me.cb_condicion.Size = New System.Drawing.Size(65, 24)
        Me.cb_condicion.TabIndex = 21
        '
        'cb_campos
        '
        Me.cb_campos.FormattingEnabled = True
        Me.cb_campos.Items.AddRange(New Object() {"producto", "nombre_producto", "usuario_grabo"})
        Me.cb_campos.Location = New System.Drawing.Point(8, 13)
        Me.cb_campos.Name = "cb_campos"
        Me.cb_campos.Size = New System.Drawing.Size(130, 24)
        Me.cb_campos.TabIndex = 20
        '
        'tbn_lo_mostrar_ordenes
        '
        Me.tbn_lo_mostrar_ordenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.tbn_lo_mostrar_ordenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.tbn_lo_mostrar_ordenes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbn_lo_mostrar_ordenes.ForeColor = System.Drawing.Color.White
        Me.tbn_lo_mostrar_ordenes.Location = New System.Drawing.Point(730, 8)
        Me.tbn_lo_mostrar_ordenes.Name = "tbn_lo_mostrar_ordenes"
        Me.tbn_lo_mostrar_ordenes.Size = New System.Drawing.Size(141, 32)
        Me.tbn_lo_mostrar_ordenes.TabIndex = 18
        Me.tbn_lo_mostrar_ordenes.Text = "Mostrar Ordenes"
        Me.tbn_lo_mostrar_ordenes.UseVisualStyleBackColor = False
        '
        'dg_lo_listado_ordenes
        '
        Me.dg_lo_listado_ordenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_lo_listado_ordenes.CaptionVisible = False
        Me.dg_lo_listado_ordenes.DataMember = ""
        Me.dg_lo_listado_ordenes.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_lo_listado_ordenes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_lo_listado_ordenes.Location = New System.Drawing.Point(8, 48)
        Me.dg_lo_listado_ordenes.Name = "dg_lo_listado_ordenes"
        Me.dg_lo_listado_ordenes.ReadOnly = True
        Me.dg_lo_listado_ordenes.Size = New System.Drawing.Size(864, 439)
        Me.dg_lo_listado_ordenes.TabIndex = 17
        '
        'tb_estadisticas
        '
        Me.tb_estadisticas.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_estadisticas.Controls.Add(Me.GroupBox5)
        Me.tb_estadisticas.Controls.Add(Me.GroupBox4)
        Me.tb_estadisticas.Controls.Add(Me.GroupBox3)
        Me.tb_estadisticas.Controls.Add(Me.Label12)
        Me.tb_estadisticas.Controls.Add(Me.GroupBox6)
        Me.tb_estadisticas.ForeColor = System.Drawing.Color.Black
        Me.tb_estadisticas.Location = New System.Drawing.Point(4, 22)
        Me.tb_estadisticas.Name = "tb_estadisticas"
        Me.tb_estadisticas.Size = New System.Drawing.Size(895, 524)
        Me.tb_estadisticas.TabIndex = 3
        Me.tb_estadisticas.Text = "Estadisticas"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PanelBaseProduccion)
        Me.GroupBox5.Controls.Add(Me.txt_estadisticas_producido)
        Me.GroupBox5.Location = New System.Drawing.Point(741, 53)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(128, 414)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Producido"
        '
        'PanelBaseProduccion
        '
        Me.PanelBaseProduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelBaseProduccion.Controls.Add(Me.PanelRellenoProduccion)
        Me.PanelBaseProduccion.Location = New System.Drawing.Point(20, 53)
        Me.PanelBaseProduccion.Name = "PanelBaseProduccion"
        Me.PanelBaseProduccion.Size = New System.Drawing.Size(88, 346)
        Me.PanelBaseProduccion.TabIndex = 12
        '
        'PanelRellenoProduccion
        '
        Me.PanelRellenoProduccion.BackColor = System.Drawing.Color.Lime
        Me.PanelRellenoProduccion.Location = New System.Drawing.Point(0, 154)
        Me.PanelRellenoProduccion.Name = "PanelRellenoProduccion"
        Me.PanelRellenoProduccion.Size = New System.Drawing.Size(88, 192)
        Me.PanelRellenoProduccion.TabIndex = 13
        '
        'txt_estadisticas_producido
        '
        Me.txt_estadisticas_producido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_estadisticas_producido.Location = New System.Drawing.Point(40, 21)
        Me.txt_estadisticas_producido.Name = "txt_estadisticas_producido"
        Me.txt_estadisticas_producido.Size = New System.Drawing.Size(48, 22)
        Me.txt_estadisticas_producido.TabIndex = 8
        Me.txt_estadisticas_producido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dg_estadisticas_op)
        Me.GroupBox4.Location = New System.Drawing.Point(431, 159)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(293, 308)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Ordenes de Producción"
        '
        'dg_estadisticas_op
        '
        Me.dg_estadisticas_op.CaptionVisible = False
        Me.dg_estadisticas_op.DataMember = ""
        Me.dg_estadisticas_op.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_estadisticas_op.Location = New System.Drawing.Point(14, 21)
        Me.dg_estadisticas_op.Name = "dg_estadisticas_op"
        Me.dg_estadisticas_op.ReadOnly = True
        Me.dg_estadisticas_op.Size = New System.Drawing.Size(264, 272)
        Me.dg_estadisticas_op.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dg_estadisticas_ventas)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 159)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(388, 308)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ventas por Semana"
        '
        'dg_estadisticas_ventas
        '
        Me.dg_estadisticas_ventas.CaptionVisible = False
        Me.dg_estadisticas_ventas.DataMember = ""
        Me.dg_estadisticas_ventas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_estadisticas_ventas.Location = New System.Drawing.Point(14, 21)
        Me.dg_estadisticas_ventas.Name = "dg_estadisticas_ventas"
        Me.dg_estadisticas_ventas.ReadOnly = True
        Me.dg_estadisticas_ventas.Size = New System.Drawing.Size(360, 272)
        Me.dg_estadisticas_ventas.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 25)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Estadisticas"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_mostrar_estadisticas)
        Me.GroupBox6.Controls.Add(Me.cmb_pack_estadisticas)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.txt_estadisticas_existencia)
        Me.GroupBox6.Location = New System.Drawing.Point(25, 53)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(699, 100)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        '
        'btn_mostrar_estadisticas
        '
        Me.btn_mostrar_estadisticas.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_mostrar_estadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_mostrar_estadisticas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar_estadisticas.ForeColor = System.Drawing.Color.White
        Me.btn_mostrar_estadisticas.Location = New System.Drawing.Point(193, 60)
        Me.btn_mostrar_estadisticas.Name = "btn_mostrar_estadisticas"
        Me.btn_mostrar_estadisticas.Size = New System.Drawing.Size(195, 22)
        Me.btn_mostrar_estadisticas.TabIndex = 5
        Me.btn_mostrar_estadisticas.Text = "Mostrar Estadisticas"
        Me.btn_mostrar_estadisticas.UseVisualStyleBackColor = False
        '
        'cmb_pack_estadisticas
        '
        Me.cmb_pack_estadisticas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_pack_estadisticas.Location = New System.Drawing.Point(87, 20)
        Me.cmb_pack_estadisticas.Name = "cmb_pack_estadisticas"
        Me.cmb_pack_estadisticas.Size = New System.Drawing.Size(380, 24)
        Me.cmb_pack_estadisticas.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Pack"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 62)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 16)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Existencia"
        '
        'txt_estadisticas_existencia
        '
        Me.txt_estadisticas_existencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_estadisticas_existencia.Location = New System.Drawing.Point(87, 60)
        Me.txt_estadisticas_existencia.Name = "txt_estadisticas_existencia"
        Me.txt_estadisticas_existencia.Size = New System.Drawing.Size(100, 22)
        Me.txt_estadisticas_existencia.TabIndex = 8
        Me.txt_estadisticas_existencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_nuevo_op
        '
        Me.tb_nuevo_op.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_nuevo_op.Controls.Add(Me.Label18)
        Me.tb_nuevo_op.Controls.Add(Me.dg_op_pendientes)
        Me.tb_nuevo_op.Controls.Add(Me.GroupBox2)
        Me.tb_nuevo_op.Controls.Add(Me.btn_op_mostrar_ordenes)
        Me.tb_nuevo_op.Controls.Add(Me.dg_op_producto)
        Me.tb_nuevo_op.Controls.Add(Me.Label3)
        Me.tb_nuevo_op.Controls.Add(Me.dg_detalle_pack_op)
        Me.tb_nuevo_op.Controls.Add(Me.Label2)
        Me.tb_nuevo_op.Controls.Add(Me.cmb_op_pack)
        Me.tb_nuevo_op.Controls.Add(Me.Label4)
        Me.tb_nuevo_op.Controls.Add(Me.Label21)
        Me.tb_nuevo_op.Controls.Add(Me.Label9)
        Me.tb_nuevo_op.ForeColor = System.Drawing.Color.Black
        Me.tb_nuevo_op.Location = New System.Drawing.Point(4, 25)
        Me.tb_nuevo_op.Name = "tb_nuevo_op"
        Me.tb_nuevo_op.Size = New System.Drawing.Size(895, 521)
        Me.tb_nuevo_op.TabIndex = 1
        Me.tb_nuevo_op.Text = "Orden de Produccion"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(589, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 16)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Ordenes Pendientes"
        '
        'dg_op_pendientes
        '
        Me.dg_op_pendientes.CaptionVisible = False
        Me.dg_op_pendientes.DataMember = ""
        Me.dg_op_pendientes.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_op_pendientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_op_pendientes.Location = New System.Drawing.Point(592, 68)
        Me.dg_op_pendientes.Name = "dg_op_pendientes"
        Me.dg_op_pendientes.ReadOnly = True
        Me.dg_op_pendientes.Size = New System.Drawing.Size(295, 450)
        Me.dg_op_pendientes.TabIndex = 16
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.txt_Tipo_Produccion)
        Me.GroupBox2.Controls.Add(Me.btn_productos_desarme)
        Me.GroupBox2.Controls.Add(Me.solicitado_por)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txt_op_observaciones)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_op_numero_orden)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_op_cantidad_solicitada)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtp_op_fecha_inicio)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo_orden_produccion)
        Me.GroupBox2.Controls.Add(Me.btn_guardar_orden_produccion)
        Me.GroupBox2.Location = New System.Drawing.Point(80, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(506, 165)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(43, 136)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(100, 16)
        Me.Label40.TabIndex = 19
        Me.Label40.Text = "Tipo Producción"
        '
        'txt_Tipo_Produccion
        '
        Me.txt_Tipo_Produccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Tipo_Produccion.Location = New System.Drawing.Point(147, 133)
        Me.txt_Tipo_Produccion.Name = "txt_Tipo_Produccion"
        Me.txt_Tipo_Produccion.Size = New System.Drawing.Size(353, 22)
        Me.txt_Tipo_Produccion.TabIndex = 18
        '
        'btn_productos_desarme
        '
        Me.btn_productos_desarme.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_productos_desarme.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_productos_desarme.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_productos_desarme.ForeColor = System.Drawing.Color.White
        Me.btn_productos_desarme.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_productos_desarme.ImageIndex = 1
        Me.btn_productos_desarme.ImageList = Me.ImageList1
        Me.btn_productos_desarme.Location = New System.Drawing.Point(248, 13)
        Me.btn_productos_desarme.Name = "btn_productos_desarme"
        Me.btn_productos_desarme.Size = New System.Drawing.Size(80, 64)
        Me.btn_productos_desarme.TabIndex = 17
        Me.btn_productos_desarme.Text = "Desarme"
        Me.btn_productos_desarme.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_productos_desarme.UseVisualStyleBackColor = False
        '
        'solicitado_por
        '
        Me.solicitado_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.solicitado_por.Location = New System.Drawing.Point(147, 109)
        Me.solicitado_por.Name = "solicitado_por"
        Me.solicitado_por.ReadOnly = True
        Me.solicitado_por.Size = New System.Drawing.Size(353, 22)
        Me.solicitado_por.TabIndex = 16
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(57, 112)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(86, 16)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Solicitado por"
        '
        'txt_op_observaciones
        '
        Me.txt_op_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_observaciones.Location = New System.Drawing.Point(147, 85)
        Me.txt_op_observaciones.Name = "txt_op_observaciones"
        Me.txt_op_observaciones.Size = New System.Drawing.Size(353, 22)
        Me.txt_op_observaciones.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(81, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "No Orden"
        '
        'txt_op_numero_orden
        '
        Me.txt_op_numero_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_numero_orden.ForeColor = System.Drawing.Color.Brown
        Me.txt_op_numero_orden.Location = New System.Drawing.Point(147, 13)
        Me.txt_op_numero_orden.Name = "txt_op_numero_orden"
        Me.txt_op_numero_orden.ReadOnly = True
        Me.txt_op_numero_orden.Size = New System.Drawing.Size(88, 22)
        Me.txt_op_numero_orden.TabIndex = 9
        Me.txt_op_numero_orden.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cantidad Solicitada"
        '
        'txt_op_cantidad_solicitada
        '
        Me.txt_op_cantidad_solicitada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_cantidad_solicitada.Location = New System.Drawing.Point(147, 37)
        Me.txt_op_cantidad_solicitada.Name = "txt_op_cantidad_solicitada"
        Me.txt_op_cantidad_solicitada.Size = New System.Drawing.Size(88, 22)
        Me.txt_op_cantidad_solicitada.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(29, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha Inicio Venta"
        '
        'dtp_op_fecha_inicio
        '
        Me.dtp_op_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_op_fecha_inicio.Location = New System.Drawing.Point(147, 61)
        Me.dtp_op_fecha_inicio.Name = "dtp_op_fecha_inicio"
        Me.dtp_op_fecha_inicio.Size = New System.Drawing.Size(88, 22)
        Me.dtp_op_fecha_inicio.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(51, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 16)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Observaciones"
        '
        'btn_nuevo_orden_produccion
        '
        Me.btn_nuevo_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_orden_produccion.ImageIndex = 3
        Me.btn_nuevo_orden_produccion.ImageList = Me.ImageList1
        Me.btn_nuevo_orden_produccion.Location = New System.Drawing.Point(334, 13)
        Me.btn_nuevo_orden_produccion.Name = "btn_nuevo_orden_produccion"
        Me.btn_nuevo_orden_produccion.Size = New System.Drawing.Size(80, 64)
        Me.btn_nuevo_orden_produccion.TabIndex = 14
        Me.btn_nuevo_orden_produccion.Text = "Nuevo"
        Me.btn_nuevo_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_orden_produccion.UseVisualStyleBackColor = False
        Me.btn_nuevo_orden_produccion.Visible = False
        '
        'btn_guardar_orden_produccion
        '
        Me.btn_guardar_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_orden_produccion.ImageIndex = 0
        Me.btn_guardar_orden_produccion.ImageList = Me.ImageList1
        Me.btn_guardar_orden_produccion.Location = New System.Drawing.Point(420, 13)
        Me.btn_guardar_orden_produccion.Name = "btn_guardar_orden_produccion"
        Me.btn_guardar_orden_produccion.Size = New System.Drawing.Size(80, 64)
        Me.btn_guardar_orden_produccion.TabIndex = 14
        Me.btn_guardar_orden_produccion.Text = "Guardar"
        Me.btn_guardar_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_orden_produccion.UseVisualStyleBackColor = False
        Me.btn_guardar_orden_produccion.Visible = False
        '
        'btn_op_mostrar_ordenes
        '
        Me.btn_op_mostrar_ordenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_op_mostrar_ordenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_op_mostrar_ordenes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_op_mostrar_ordenes.ForeColor = System.Drawing.Color.White
        Me.btn_op_mostrar_ordenes.Location = New System.Drawing.Point(408, 14)
        Me.btn_op_mostrar_ordenes.Name = "btn_op_mostrar_ordenes"
        Me.btn_op_mostrar_ordenes.Size = New System.Drawing.Size(178, 23)
        Me.btn_op_mostrar_ordenes.TabIndex = 12
        Me.btn_op_mostrar_ordenes.Text = "Mostrar Ordenes"
        Me.btn_op_mostrar_ordenes.UseVisualStyleBackColor = False
        '
        'dg_op_producto
        '
        Me.dg_op_producto.CaptionVisible = False
        Me.dg_op_producto.DataMember = ""
        Me.dg_op_producto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_op_producto.Location = New System.Drawing.Point(80, 360)
        Me.dg_op_producto.Name = "dg_op_producto"
        Me.dg_op_producto.ReadOnly = True
        Me.dg_op_producto.Size = New System.Drawing.Size(506, 152)
        Me.dg_op_producto.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(592, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Orden de Produccion"
        '
        'dg_detalle_pack_op
        '
        Me.dg_detalle_pack_op.CaptionVisible = False
        Me.dg_detalle_pack_op.DataMember = ""
        Me.dg_detalle_pack_op.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pack_op.Location = New System.Drawing.Point(80, 46)
        Me.dg_detalle_pack_op.Name = "dg_detalle_pack_op"
        Me.dg_detalle_pack_op.ReadOnly = True
        Me.dg_detalle_pack_op.Size = New System.Drawing.Size(506, 137)
        Me.dg_detalle_pack_op.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pack"
        '
        'cmb_op_pack
        '
        Me.cmb_op_pack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_op_pack.Location = New System.Drawing.Point(80, 14)
        Me.cmb_op_pack.Name = "cmb_op_pack"
        Me.cmb_op_pack.Size = New System.Drawing.Size(320, 24)
        Me.cmb_op_pack.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 35)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Productos Pack"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 200)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 38)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Detalle de Produccion"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 35)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Ordenes de Produccion"
        '
        'tb_detalle_pack
        '
        Me.tb_detalle_pack.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_detalle_pack.Controls.Add(Me.nudMinutosParaEleborar)
        Me.tb_detalle_pack.Controls.Add(Me.txt_total_costo)
        Me.tb_detalle_pack.Controls.Add(Me.txt_detalle_pack_cliente)
        Me.tb_detalle_pack.Controls.Add(Me.txt_detalle_pack_inventario_minimo)
        Me.tb_detalle_pack.Controls.Add(Me.txt_detalle_pack_barra)
        Me.tb_detalle_pack.Controls.Add(Me.StatusBar1)
        Me.tb_detalle_pack.Controls.Add(Me.txt_descripcion_pack)
        Me.tb_detalle_pack.Controls.Add(Me.txt_codigo_detalle)
        Me.tb_detalle_pack.Controls.Add(Me.Label22)
        Me.tb_detalle_pack.Controls.Add(Me.Label19)
        Me.tb_detalle_pack.Controls.Add(Me.dg_detalle_pack_insumos)
        Me.tb_detalle_pack.Controls.Add(Me.Label16)
        Me.tb_detalle_pack.Controls.Add(Me.pb_fotopack_1)
        Me.tb_detalle_pack.Controls.Add(Me.btn_guardar_detalle_pack)
        Me.tb_detalle_pack.Controls.Add(Me.Label13)
        Me.tb_detalle_pack.Controls.Add(Me.dg_detalle_pack)
        Me.tb_detalle_pack.Controls.Add(Me.Label14)
        Me.tb_detalle_pack.Controls.Add(Me.cmb_detalle_pack)
        Me.tb_detalle_pack.Controls.Add(Me.Label15)
        Me.tb_detalle_pack.Controls.Add(Me.Label10)
        Me.tb_detalle_pack.Controls.Add(Me.pb_fotopack_2)
        Me.tb_detalle_pack.Controls.Add(Me.Label8)
        Me.tb_detalle_pack.Controls.Add(Me.Label39)
        Me.tb_detalle_pack.Controls.Add(Me.Label20)
        Me.tb_detalle_pack.ForeColor = System.Drawing.Color.Black
        Me.tb_detalle_pack.Location = New System.Drawing.Point(4, 22)
        Me.tb_detalle_pack.Name = "tb_detalle_pack"
        Me.tb_detalle_pack.Size = New System.Drawing.Size(895, 524)
        Me.tb_detalle_pack.TabIndex = 2
        Me.tb_detalle_pack.Text = "Detalle Pack"
        '
        'nudMinutosParaEleborar
        '
        Me.nudMinutosParaEleborar.DecimalPlaces = 2
        Me.nudMinutosParaEleborar.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudMinutosParaEleborar.Location = New System.Drawing.Point(558, 442)
        Me.nudMinutosParaEleborar.Name = "nudMinutosParaEleborar"
        Me.nudMinutosParaEleborar.Size = New System.Drawing.Size(75, 22)
        Me.nudMinutosParaEleborar.TabIndex = 44
        '
        'txt_total_costo
        '
        Me.txt_total_costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_costo.Location = New System.Drawing.Point(490, 207)
        Me.txt_total_costo.Name = "txt_total_costo"
        Me.txt_total_costo.ReadOnly = True
        Me.txt_total_costo.Size = New System.Drawing.Size(143, 22)
        Me.txt_total_costo.TabIndex = 43
        Me.txt_total_costo.TabStop = False
        Me.txt_total_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_detalle_pack_cliente
        '
        Me.txt_detalle_pack_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_pack_cliente.Location = New System.Drawing.Point(103, 412)
        Me.txt_detalle_pack_cliente.Name = "txt_detalle_pack_cliente"
        Me.txt_detalle_pack_cliente.Size = New System.Drawing.Size(530, 22)
        Me.txt_detalle_pack_cliente.TabIndex = 41
        '
        'txt_detalle_pack_inventario_minimo
        '
        Me.txt_detalle_pack_inventario_minimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_pack_inventario_minimo.Location = New System.Drawing.Point(103, 438)
        Me.txt_detalle_pack_inventario_minimo.Name = "txt_detalle_pack_inventario_minimo"
        Me.txt_detalle_pack_inventario_minimo.Size = New System.Drawing.Size(128, 22)
        Me.txt_detalle_pack_inventario_minimo.TabIndex = 39
        Me.txt_detalle_pack_inventario_minimo.Text = "0"
        '
        'txt_detalle_pack_barra
        '
        Me.txt_detalle_pack_barra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_detalle_pack_barra.Location = New System.Drawing.Point(103, 464)
        Me.txt_detalle_pack_barra.Name = "txt_detalle_pack_barra"
        Me.txt_detalle_pack_barra.ReadOnly = True
        Me.txt_detalle_pack_barra.Size = New System.Drawing.Size(128, 22)
        Me.txt_detalle_pack_barra.TabIndex = 36
        Me.txt_detalle_pack_barra.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 502)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.panel1_detalle, Me.panel2_detalle})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(895, 22)
        Me.StatusBar1.TabIndex = 35
        Me.StatusBar1.Text = "StatusBar1"
        '
        'panel1_detalle
        '
        Me.panel1_detalle.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.panel1_detalle.Name = "panel1_detalle"
        Me.panel1_detalle.Width = 439
        '
        'panel2_detalle
        '
        Me.panel2_detalle.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.panel2_detalle.Name = "panel2_detalle"
        Me.panel2_detalle.Width = 439
        '
        'txt_descripcion_pack
        '
        Me.txt_descripcion_pack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion_pack.Location = New System.Drawing.Point(103, 355)
        Me.txt_descripcion_pack.Multiline = True
        Me.txt_descripcion_pack.Name = "txt_descripcion_pack"
        Me.txt_descripcion_pack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_descripcion_pack.Size = New System.Drawing.Size(530, 53)
        Me.txt_descripcion_pack.TabIndex = 33
        '
        'txt_codigo_detalle
        '
        Me.txt_codigo_detalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_detalle.Location = New System.Drawing.Point(103, 48)
        Me.txt_codigo_detalle.Name = "txt_codigo_detalle"
        Me.txt_codigo_detalle.ReadOnly = True
        Me.txt_codigo_detalle.Size = New System.Drawing.Size(104, 22)
        Me.txt_codigo_detalle.TabIndex = 39
        Me.txt_codigo_detalle.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(407, 210)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 16)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Total Costo:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(30, 414)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 16)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Cliente"
        '
        'dg_detalle_pack_insumos
        '
        Me.dg_detalle_pack_insumos.CaptionVisible = False
        Me.dg_detalle_pack_insumos.DataMember = ""
        Me.dg_detalle_pack_insumos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_detalle_pack_insumos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pack_insumos.Location = New System.Drawing.Point(103, 230)
        Me.dg_detalle_pack_insumos.Name = "dg_detalle_pack_insumos"
        Me.dg_detalle_pack_insumos.Size = New System.Drawing.Size(530, 119)
        Me.dg_detalle_pack_insumos.TabIndex = 38
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(30, 466)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Cod. Barra"
        '
        'pb_fotopack_1
        '
        Me.pb_fotopack_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_fotopack_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_fotopack_1.Location = New System.Drawing.Point(649, 96)
        Me.pb_fotopack_1.Name = "pb_fotopack_1"
        Me.pb_fotopack_1.Size = New System.Drawing.Size(216, 189)
        Me.pb_fotopack_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_fotopack_1.TabIndex = 34
        Me.pb_fotopack_1.TabStop = False
        '
        'btn_guardar_detalle_pack
        '
        Me.btn_guardar_detalle_pack.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_detalle_pack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_detalle_pack.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_detalle_pack.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_detalle_pack.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_detalle_pack.ImageIndex = 0
        Me.btn_guardar_detalle_pack.ImageList = Me.ImageList1
        Me.btn_guardar_detalle_pack.Location = New System.Drawing.Point(782, 29)
        Me.btn_guardar_detalle_pack.Name = "btn_guardar_detalle_pack"
        Me.btn_guardar_detalle_pack.Size = New System.Drawing.Size(83, 61)
        Me.btn_guardar_detalle_pack.TabIndex = 30
        Me.btn_guardar_detalle_pack.Text = "Guardar"
        Me.btn_guardar_detalle_pack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_detalle_pack.UseVisualStyleBackColor = False
        Me.btn_guardar_detalle_pack.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(31, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 25)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Detalle Pack"
        '
        'dg_detalle_pack
        '
        Me.dg_detalle_pack.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_detalle_pack.CaptionVisible = False
        Me.dg_detalle_pack.DataMember = ""
        Me.dg_detalle_pack.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pack.Location = New System.Drawing.Point(103, 75)
        Me.dg_detalle_pack.Name = "dg_detalle_pack"
        Me.dg_detalle_pack.ReadOnly = True
        Me.dg_detalle_pack.Size = New System.Drawing.Size(530, 132)
        Me.dg_detalle_pack.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(30, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 16)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Pack"
        '
        'cmb_detalle_pack
        '
        Me.cmb_detalle_pack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_detalle_pack.Location = New System.Drawing.Point(215, 47)
        Me.cmb_detalle_pack.Name = "cmb_detalle_pack"
        Me.cmb_detalle_pack.Size = New System.Drawing.Size(418, 24)
        Me.cmb_detalle_pack.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(30, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 33)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Productos Pack"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(30, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 16)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Materiales Auxiliares"
        '
        'pb_fotopack_2
        '
        Me.pb_fotopack_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_fotopack_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_fotopack_2.Location = New System.Drawing.Point(649, 294)
        Me.pb_fotopack_2.Name = "pb_fotopack_2"
        Me.pb_fotopack_2.Size = New System.Drawing.Size(216, 189)
        Me.pb_fotopack_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_fotopack_2.TabIndex = 34
        Me.pb_fotopack_2.TabStop = False
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(30, 355)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 36)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Descripcion del Pack"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(360, 444)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(181, 16)
        Me.Label39.TabIndex = 37
        Me.Label39.Text = "Minutos Para Elaborar 1 Pack"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(30, 440)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 16)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Inv Minimo"
        '
        'tp_packs_activos
        '
        Me.tp_packs_activos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_packs_activos.Controls.Add(Me.Label1)
        Me.tp_packs_activos.Controls.Add(Me.GroupBox1)
        Me.tp_packs_activos.Controls.Add(Me.DataGrid2)
        Me.tp_packs_activos.Controls.Add(Me.DataGrid1)
        Me.tp_packs_activos.ForeColor = System.Drawing.Color.Black
        Me.tp_packs_activos.Location = New System.Drawing.Point(4, 25)
        Me.tp_packs_activos.Name = "tp_packs_activos"
        Me.tp_packs_activos.Size = New System.Drawing.Size(895, 521)
        Me.tp_packs_activos.TabIndex = 0
        Me.tp_packs_activos.Text = "Pack Activos"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Packs Activos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_detalle_pack)
        Me.GroupBox1.Controls.Add(Me.btn_orden_produccion)
        Me.GroupBox1.Controls.Add(Me.btn_estadisticas)
        Me.GroupBox1.Location = New System.Drawing.Point(767, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(117, 296)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btn_detalle_pack
        '
        Me.btn_detalle_pack.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_detalle_pack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_detalle_pack.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_detalle_pack.ForeColor = System.Drawing.Color.White
        Me.btn_detalle_pack.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_detalle_pack.ImageIndex = 1
        Me.btn_detalle_pack.ImageList = Me.ImageList1
        Me.btn_detalle_pack.Location = New System.Drawing.Point(12, 21)
        Me.btn_detalle_pack.Name = "btn_detalle_pack"
        Me.btn_detalle_pack.Size = New System.Drawing.Size(93, 76)
        Me.btn_detalle_pack.TabIndex = 1
        Me.btn_detalle_pack.Text = "Detalle del Pack"
        Me.btn_detalle_pack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_detalle_pack.UseVisualStyleBackColor = False
        '
        'btn_orden_produccion
        '
        Me.btn_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_orden_produccion.ImageIndex = 2
        Me.btn_orden_produccion.ImageList = Me.ImageList1
        Me.btn_orden_produccion.Location = New System.Drawing.Point(12, 112)
        Me.btn_orden_produccion.Name = "btn_orden_produccion"
        Me.btn_orden_produccion.Size = New System.Drawing.Size(93, 76)
        Me.btn_orden_produccion.TabIndex = 1
        Me.btn_orden_produccion.Text = "Orden de  Producción"
        Me.btn_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_orden_produccion.UseVisualStyleBackColor = False
        '
        'btn_estadisticas
        '
        Me.btn_estadisticas.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_estadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_estadisticas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_estadisticas.ForeColor = System.Drawing.Color.White
        Me.btn_estadisticas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_estadisticas.ImageIndex = 4
        Me.btn_estadisticas.ImageList = Me.ImageList1
        Me.btn_estadisticas.Location = New System.Drawing.Point(12, 214)
        Me.btn_estadisticas.Name = "btn_estadisticas"
        Me.btn_estadisticas.Size = New System.Drawing.Size(93, 76)
        Me.btn_estadisticas.TabIndex = 1
        Me.btn_estadisticas.Text = "Estadisticas Producción"
        Me.btn_estadisticas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_estadisticas.UseVisualStyleBackColor = False
        '
        'DataGrid2
        '
        Me.DataGrid2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGrid2.CaptionVisible = False
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(8, 309)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(752, 180)
        Me.DataGrid2.TabIndex = 1
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 29)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(751, 274)
        Me.DataGrid1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tp_packs_activos)
        Me.TabControl1.Controls.Add(Me.tb_detalle_pack)
        Me.TabControl1.Controls.Add(Me.tb_nuevo_op)
        Me.TabControl1.Controls.Add(Me.tb_estadisticas)
        Me.TabControl1.Controls.Add(Me.tb_listado_ordenes)
        Me.TabControl1.Controls.Add(Me.tb_detalle_op)
        Me.TabControl1.Location = New System.Drawing.Point(1, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(903, 550)
        Me.TabControl1.TabIndex = 0
        '
        'frm_maq_monitor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(904, 549)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Menu = Me.Menu_Maquila
        Me.Name = "frm_maq_monitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Maquilas .::"
        Me.tb_detalle_op.ResumeLayout(False)
        Me.tb_detalle_op.PerformLayout()
        CType(Me.dgv_materiales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_costo_primo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_costo_equipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tb_listado_ordenes.ResumeLayout(False)
        Me.tb_listado_ordenes.PerformLayout()
        CType(Me.dg_lo_listado_ordenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_estadisticas.ResumeLayout(False)
        Me.tb_estadisticas.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.PanelBaseProduccion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dg_estadisticas_op, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dg_estadisticas_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tb_nuevo_op.ResumeLayout(False)
        Me.tb_nuevo_op.PerformLayout()
        CType(Me.dg_op_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dg_op_producto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_pack_op, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_detalle_pack.ResumeLayout(False)
        Me.tb_detalle_pack.PerformLayout()
        CType(Me.nudMinutosParaEleborar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel1_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel2_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_fotopack_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_pack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_fotopack_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_packs_activos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Packs_Activos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsgen As New ClasesGenerales.General

        Try
            Ods = New DataSet
            Otrans.open()

            If Ods.Tables.Contains("packs") Then Ods.Tables.Remove("packs")
            If Ods.Tables.Contains("detalle_packs") Then Ods.Tables.Remove("detalle_packs")
            If Ods.Tables.Contains("detalle_onbase_packs") Then Ods.Tables.Remove("detalle_onbase_packs")
            If Ods.Tables.Contains("mpacks_insumos") Then Ods.Tables.Remove("mpacks_insumos")
            If Ods.Tables.Contains("mdetalle_packs_insumos") Then Ods.Tables.Remove("mdetalle_packs_insumos")

            ls_sql = "pa_var_um_ProdReceta '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "packs"
            Ods.Tables.Add(dt.Copy)
            Me.DataGrid1.DataSource = dt
            clsgen.Alinea_Grid(dt, DataGrid1, dt.TableName, -1, 300, 0, False, True, "", True, "")

            Me.cmb_op_pack.DataSource = dt
            Me.cmb_op_pack.DisplayMember = "glosa"
            Me.cmb_op_pack.ValueMember = "producto"

            Me.cmb_detalle_pack.DataSource = dt
            Me.cmb_detalle_pack.DisplayMember = "glosa"
            Me.cmb_detalle_pack.ValueMember = "producto"

            Me.cmb_pack_estadisticas.DataSource = dt
            Me.cmb_pack_estadisticas.DisplayMember = "glosa"
            Me.cmb_pack_estadisticas.ValueMember = "producto"

            ls_sql = "pa_var_um_ProdReceta_detalle '" & gs_empresa & "',0"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "detalle_packs"
            Ods.Tables.Add(dt.Copy)







            ls_sql = "pa_sel_um_maq_detalle_pack null,'" & gs_empresa & "'"
            dt = clsgen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "detalle_onbase_packs"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_insumos "
            dt = clsgen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "mpacks_insumos"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_detalle_pack_insumos "
            dt = clsgen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "mdetalle_packs_insumos"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_sg_usuario_simple '" & gs_usuario & "'"
            dt = Otrans.Obtiene(ls_sql)
            solicitado_por.Text = dt.Rows(0)("nombre")


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try


        'Informacion de detalle packs
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            'myOtrans.open()
            'ls_sql = "call pa_sel_um_maq_detalle_pack (null,'" & gs_empresa & "')"
            'dt = myOtrans.Obtiene(ls_sql)
            'dt.TableName = "detalle_onbase_packs"
            'Ods.Tables.Add(dt.Copy)

            'ls_sql = "call pa_sel_um_maq_insumos ()"
            'dt = myOtrans.Obtiene(ls_sql)
            'dt.TableName = "mpacks_insumos"
            'Ods.Tables.Add(dt.Copy)

            'ls_sql = "call pa_sel_um_maq_detalle_pack_insumos (null)"
            'dt = myOtrans.Obtiene(ls_sql)
            'dt.TableName = "mdetalle_packs_insumos"
            'Ods.Tables.Add(dt.Copy)

            'ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            'dt = myOtrans.Obtiene(ls_sql)
            'solicitado_por.Text = dt.Rows(0)("nombre")
        Catch ex As Exception
        Finally
            '   myOtrans.close()
            '  myOtrans = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Detalle_Pack()

        Dim nrow As Integer
        Dim ls_producto As String
        Dim ls_filtro As String
        Dim clsgen As New ClasesGenerales.General

        Try

            nrow = Me.DataGrid1.CurrentCell.RowNumber
            ls_producto = Me.DataGrid1.Item(nrow, 0)

            ls_filtro = "producto = '" & ls_producto & "'"

            Ods.Tables("detalle_packs").DefaultView.RowFilter = ls_filtro

            Me.DataGrid2.DataSource = Ods.Tables("detalle_packs")
            Me.DataGrid2.Refresh()

            clsgen.Alinea_Grid(Ods.Tables("detalle_packs"), Me.DataGrid2, Ods.Tables("detalle_packs").TableName, -1, 250, 0, True, True, "", True, "")
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            clsgen = Nothing
        End Try
    End Sub

    Private Function DebeObtener_Productos() As Boolean
        Dim lobtener As Boolean = True

        Dim ls_filtro As String = "Producto = '"

        Try

            If Me.TabControl1.SelectedTab.Name.ToLower = "tb_detalle_pack" Then
                ls_filtro += Me.cmb_detalle_pack.SelectedValue & "'"
            ElseIf Me.TabControl1.SelectedTab.Name.ToLower = "tb_nuevo_op" Then
                ls_filtro += Me.cmb_op_pack.SelectedValue & "'"
            Else
                ls_filtro += Me.cmb_detalle_pack.SelectedValue & "'"
            End If

            Ods.Tables("detalle_pack").DefaultView.RowFilter = ls_filtro

            If Ods.Tables("detalle_pack").DefaultView.Count > 0 Then
                lobtener = False
            End If

            Ods.Tables("detalle_packs").DefaultView.RowFilter = ""
        Catch ex As Exception

        End Try

        Return lobtener
    End Function

    Private Sub Obtener_Productos_Pack()
        Dim ls_sql As String
        Dim dt, dt_copy As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            ls_sql = "pa_var_um_ProdReceta_detalle '" & gs_empresa & "',1,'"
            If Me.TabControl1.SelectedTab.Name.ToLower = "tb_detalle_pack" Then
                ls_sql = ls_sql & Me.cmb_detalle_pack.SelectedValue & "'"
            ElseIf Me.TabControl1.SelectedTab.Name.ToLower = "tb_nuevo_op" Then
                ls_sql = ls_sql & Me.cmb_op_pack.SelectedValue & "'"
            Else
                ls_sql = ls_sql & Me.cmb_detalle_pack.SelectedValue & "'"
            End If

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "detalle_pack"
            If Ods.Tables.Contains("detalle_pack") Then
                Ods.Tables.Remove("detalle_pack")
            End If

            Ods.Tables.Add(dt.Copy)
            Dim mRow() As DataRow = Ods.Tables("detalle_onbase_packs").Select("cod_flex = '" & txt_codigo_detalle.Text & "'")

            Try
                txt_descripcion_pack.Text = mRow(0)("descripcion")
            Catch ex As Exception
            End Try


            Me.dg_detalle_pack.DataSource = Ods.Tables("detalle_pack")
            Me.dg_detalle_pack.Refresh()

            ClsGen.Alinea_Grid(Ods.Tables("detalle_pack"), dg_detalle_pack, Ods.Tables("detalle_pack").TableName, -1, 250, 0, True, True, "", True, "")

            Me.dg_detalle_pack_op.DataSource = Ods.Tables("detalle_pack")
            Me.dg_detalle_pack_op.Refresh()

            ClsGen.Alinea_Grid(Ods.Tables("detalle_pack"), dg_detalle_pack_op, Ods.Tables("detalle_pack").TableName, -1, 250, 0, True, True, "", True, "")

            dt_copy = Ods.Tables("packs").Copy
            dt_copy.DefaultView.RowFilter = "producto = '" & Me.cmb_detalle_pack.SelectedValue & "'"

            If dt_copy.DefaultView.Count > 0 Then
                Me.txt_detalle_pack_barra.Text = dt_copy.DefaultView(0).Item("codbarra")
            Else
                Me.txt_detalle_pack_barra.Text = ""
            End If




            obtener_detalle_pack_insumo(Me.cmb_detalle_pack.SelectedValue, gs_empresa)



        Catch ex As Exception
            Me.txt_detalle_pack_barra.Text = ""
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'myOtrans.open()
        'Try
        '    ls_sql = "CALL pa_sel_um_inv_producto(NULL,'" & gs_empresa & "', '" & Me.cmb_detalle_pack.SelectedValue & "')"
        '    dt = myOtrans.Obtiene(ls_sql)

        '    obtener_detalle_pack_insumo(dt.Rows(0)("cod_producto"))

        'Catch ex As Exception
        'Finally
        '    myOtrans.close()
        '    myOtrans = Nothing
        'End Try
    End Sub

    Private Sub Guardar_Detalle_Pack()
        Dim ls_sql As String
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'Dim dt As New DataTable
        Dim clsgen As New ClasesGenerales.General


        Try
            'myOtrans.open()
            ''debo obtener el codigo en onbase
            'ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','" & Me.cmb_detalle_pack.SelectedValue & "')"
            'dt = myOtrans.Obtiene(ls_sql)

            'If dt.Rows.Count > 0 Then
            ls_sql = "pa_ins_um_maq_detalle_pack '" & gs_empresa & "','" & Me.cmb_detalle_pack.SelectedValue & "','" &
                        Me.txt_descripcion_pack.Text & "','" & simagen1 & "','" & simagen2 & "','" &
                        Me.txt_detalle_pack_cliente.Text & "'," & Me.txt_detalle_pack_inventario_minimo.Text & ",'" & gs_usuario & "'," &
                        Me.nudMinutosParaEleborar.Value
            clsgen.insertQuery("Corporativo", ls_sql)
            'myOtrans.Ingresa(ls_sql)
            '    If myOtrans.Codigo_error > 0 Then
            '        MessageBox.Show(myOtrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Else
            MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

            'End If

        Catch ex As Exception
        Finally
            'ls_sql = "CALL pa_sel_um_inv_producto(NULL,'" & gs_empresa & "', '" & txt_codigo_detalle.Text & "')"
            'dt = myOtrans.Obtiene(ls_sql)

            'myOtrans.close()
            'myOtrans = Nothing

            Guardar_Insumos_Pack(Me.cmb_detalle_pack.SelectedValue, gs_empresa)
        End Try

    End Sub

    Private Sub obtener_detalle_pack_insumo(ByVal cod_producto As String, pempresa As String)
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String = String.Empty
        Dim dt As New DataTable
        Dim clsGen As New ClasesGenerales.General

        'myOtrans.open()
        Try
            ls_sql = "pa_sel_um_maq_detalle_pack_insumos '" & pempresa & "','" & cod_producto & "'"
            'ls_sql = "call pa_sel_um_maq_detalle_pack_insumos ('" & cod_producto & "')"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "mdetalle_packs_insumos"

            If Ods.Tables.Contains("insumos_pack") Then
                Ods.Tables("insumos_pack").Clear()
            End If

            If Ods.Tables.Contains("mdetalle_packs_insumos") Then
                Ods.Tables.Remove("mdetalle_packs_insumos")
            End If

            Ods.Tables.Add(dt.Copy)

            Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")
            Me.dg_detalle_pack_insumos.Refresh()

            Dim dr As DataRow

            For Each drv As DataRowView In Ods.Tables("mdetalle_packs_insumos").DefaultView
                dr = Ods.Tables("insumos_pack").NewRow
                dr.Item("cod_insumo") = drv.Item("cod_insumo")
                dr.Item("Especificaciones") = drv.Item("observaciones")
                dr.Item("costo") = drv.Item("costo")
                Ods.Tables("insumos_pack").Rows.Add(dr)
            Next

            Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
            txt_total_costo.Text = Format(suma, "##,###,##0.0000")

        Catch ex As Exception
        Finally
            '   myOtrans.close()
            '  myOtrans = Nothing
        End Try
    End Sub

    Private Sub Guardar_Insumos_Pack(ByVal pcod_producto As String, psEmpresa As String)

        Dim ls_sql As String
        Dim dr As DataRow
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("Corporativo")

        Try
            Otrans.open()
            ls_sql = "pa_del_um_maq_detalle_pack_insumos '" & psEmpresa & "','" & pcod_producto & "'"
            Otrans.Elimina(ls_sql)
            If Otrans.Codigo_error = 0 Then
                'Inserto Los Insumos utilizados en los packs
                For Each dr In Ods.Tables("insumos_pack").Rows
                    ls_sql = "pa_ins_um_maq_detalle_pack_insumos '" & psEmpresa & "','" & pcod_producto & "'," & dr.Item("cod_insumo") &
                            ",'" & dr.Item("Especificaciones") & "', " & dr.Item("costo").ToString
                    Otrans.Ingresa(ls_sql)

                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Modificar_Detalle_Pack()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim dt As New DataTable


        Try
            Otrans.open()
            'debo obtener el codigo en onbase
            'ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','" & Me.cmb_detalle_pack.SelectedValue & "')"
            'dt = myOtrans.Obtiene(ls_sql)

            'If dt.Rows.Count > 0 Then

            ls_sql = "call pa_upd_um_maq_detalle_pack '" & gs_empresa & "','" & Me.cmb_detalle_pack.SelectedValue & "','" &
                        Me.txt_descripcion_pack.Text & "','" & simagen1 & "','" & simagen2 & "','" &
                        Me.txt_detalle_pack_cliente.Text & "'," & Me.txt_detalle_pack_inventario_minimo.Text & ",'" & gs_usuario & "'," &
                        Me.nudMinutosParaEleborar.Value & ")"
            Otrans.Ingresa(ls_sql)

            If Otrans.Codigo_error > 0 Then
                MessageBox.Show(Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            Guardar_Insumos_Pack(Me.cmb_detalle_pack.SelectedValue, gs_empresa)
        End Try

    End Sub

    Private Sub Limpiar_Detalle_OnBase()
        Dim ClsGen As New ClasesGenerales.General
        Try


            Me.txt_descripcion_pack.Text = ""
            Me.txt_detalle_pack_inventario_minimo.Text = ""
            Me.nudMinutosParaEleborar.Value = 0
            Me.panel1_detalle.Text = ""
            Me.panel2_detalle.Text = ""

            simagen1 = "v_000.png"
            simagen2 = "v_000.png"

            Me.pb_fotopack_1.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images\" & simagen1)
            Me.pb_fotopack_2.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images\" & simagen2)

            Ods.Tables("insumos_pack").Rows.Clear()
        Catch ex As Exception

        End Try
        ClsGen = Nothing

    End Sub

    Private Sub Mostrar_Detalle_OnBase()

        Dim ls_filtro As String
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim icodproducto As Integer
        Dim ClsGen As New ClasesGenerales.General

        Try
            btn_guardar_detalle_pack.Text = "Guardar"

            Limpiar_Detalle_OnBase()
            'Genero Filtro
            Me.txt_codigo_detalle.Text = Me.cmb_detalle_pack.SelectedValue
            ls_filtro = "cod_flex = '" & Me.cmb_detalle_pack.SelectedValue & "'"
            Ods.Tables("detalle_onbase_packs").DefaultView.RowFilter = ls_filtro

            If Ods.Tables("detalle_onbase_packs").DefaultView.Count > 0 Then
                Me.btn_guardar_detalle_pack.Text = "Modificar"
                drv = Ods.Tables("detalle_onbase_packs").DefaultView(0)
                'Llenamos la Informacion del pack
                icodproducto = drv.Item("cod_producto")
                simagen1 = drv.Item("ruta_imagen1").ToString
                simagen2 = drv.Item("ruta_imagen2").ToString
                Me.txt_descripcion_pack.Text = drv.Item("descripcion")
                Me.txt_detalle_pack_inventario_minimo.Text = drv.Item("inventario_minimo").ToString
                Me.nudMinutosParaEleborar.Value = drv.Item("tiempo_unidad")

                Me.panel1_detalle.Text = "Usuario Grabo .:: " & drv.Item("usuario_grabo") & " " & drv.Item("fecha_grabo").ToString
                Me.panel2_detalle.Text = "Usuario Modifico .:: " & drv.Item("usuario_modifico") & " " & drv.Item("fecha_modifico").ToString
            Else
                simagen1 = ""
                simagen2 = ""
            End If

            If simagen1.Length = 0 Then
                simagen1 = "v_000.png"
            End If

            If simagen2.Length = 0 Then
                simagen2 = "v_000.png"
            End If

            Me.pb_fotopack_1.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images\" & simagen1)
            Me.pb_fotopack_2.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images\" & simagen2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try

        'muestro el detalle del pack
        Try
            Ods.Tables("mdetalle_packs_insumos").DefaultView.RowFilter = "cod_producto = " & icodproducto
            For Each drv In Ods.Tables("mdetalle_packs_insumos").DefaultView
                dr = Ods.Tables("insumos_pack").NewRow
                dr.Item("cod_insumo") = drv.Item("cod_insumo")
                dr.Item("Especificaciones") = drv.Item("observaciones")
                dr.Item("costo") = drv.Item("costo")
                Ods.Tables("insumos_pack").Rows.Add(dr)
            Next

            Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
            txt_total_costo.Text = Format(suma, "##,###,##0.0000")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    'Guardo Una Orden de Produccion Nueva
    Private Sub Guardar_Orden_Produccion()
        Dim ls_sql, ls_Sql2 As String

        Dim dt As DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("Corporativo")

        Try
            Otrans.open()

            '''debo obtener el codigo en onbase
            ''ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','" & Me.cmb_op_pack.SelectedValue & "')"
            ''dt = myOtrans.Obtiene(ls_sql)

            ''If dt.Rows.Count = 0 Then
            ''    Dim oSinc As New Sincronizacion.Envio_Onbase
            ''    oSinc.Insertar_OnBase(gs_empresa, Me.cmb_op_pack.SelectedValue.ToString)
            ''    oSinc = Nothing
            ''End If

            '''debo obtener el codigo en onbase
            ''ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','" & Me.cmb_op_pack.SelectedValue & "')"
            ''dt = myOtrans.Obtiene(ls_sql)

            ''If dt.Rows.Count > 0 Then


            'ls_sql = "pa_ins_um_maq_orden_produccion (" & dt.Rows(0).Item("cod_producto") & "," &
            '            Me.txt_op_cantidad_solicitada.Text & ",'" & Me.dtp_op_fecha_inicio.Value.ToString("yyyy-MM-dd") & "','" &
            '            Me.txt_op_observaciones.Text & "','" & gs_usuario & "')"

            ls_sql = "pa_ins_um_maq_orden_produccion '" & gs_empresa & "','" & Me.cmb_op_pack.SelectedValue & "'," &
                        Me.txt_op_cantidad_solicitada.Text & ",'" & Me.dtp_op_fecha_inicio.Value.ToString("dd-MM-yyyy") & "','" &
                        Me.txt_op_observaciones.Text & "','" & gs_usuario & "'"

            dt = Otrans.Obtiene(ls_sql)

            If Otrans.Codigo_error > 0 Then
                MessageBox.Show(Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")

                Me.txt_op_numero_orden.Text = dt.Rows(0).Item("newid").ToString

                ' GUARDA TIPO DE MAQUILADO

                ls_Sql2 = "pa_um_ins_tipo_orden_produccion	'" & gs_empresa & "','" & Me.txt_op_numero_orden.Text & "','" & Me.txt_Tipo_Produccion.Text & "'"
                Otrans.Obtiene(ls_Sql2)

            End If





        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub crea_documento()
        Dim tx_SQL As String = String.Empty
        Dim dt As New DataTable
        Dim mCosto As Decimal

        Dim MTRans As New Transaccional.Conexion("Flexline")
        MTRans.open()

        Try
            tx_SQL = "pa_sel_um_producto '" & gs_empresa & "', '" & txt_codigo_detalle.Text & "'"
            dt = MTRans.Obtiene(tx_SQL)
            Try
                mCosto = dt.Rows(0)("costo")
            Catch ex As Exception
            End Try

            If MTRans.Codigo_error = 0 Then
                tx_SQL = "pa_ins_um_documento '" & gs_empresa & "', 'PLAN DE PRODUCCION', '" & _
                         Microsoft.VisualBasic.Right("0000000000" & txt_op_numero_orden.Text.Trim, 10) & _
                         "', '" & Now.Date & "', '', '', 0, '', " & Val(txt_op_cantidad_solicitada.Text) * mCosto & _
                         ", " & "0, 'S', " & _
                         Now.Year.ToString & Microsoft.VisualBasic.Right("0" & Now.Month.ToString, 2) & ", " & _
                         "'', '', '', '', '', '', '" & gs_usuario & "', ''"
                MTRans.Ingresa(tx_SQL)



                If MTRans.Codigo_error = 0 Then
                    tx_SQL = "pa_sel_um_documento '" & gs_empresa & "', 'PLAN DE PRODUCCION', '" & Microsoft.VisualBasic.Right("0000000000" & txt_op_numero_orden.Text.Trim, 10) & "'"
                    dt = MTRans.Obtiene(tx_SQL)

                    If MTRans.Codigo_error = 0 Then
                        tx_SQL = "pa_ins_um_documentod '" & gs_empresa & "', 'PLAN DE PRODUCCION', " &
                                 dt.Rows(0)("correlativo") & ", 1, '" & txt_codigo_detalle.Text & "', " &
                                 txt_op_cantidad_solicitada.Text & ", " & mCosto & ", " &
                                 Val(txt_op_cantidad_solicitada.Text) * mCosto & ", 0, 0, '" & Now.Date & "', " &
                                 mCosto & ", " & mCosto & ", 1"
                        MTRans.Ingresa(tx_SQL)
                    End If

                    tx_SQL = "pa_var_um_actualiza_documento '" & gs_empresa & "', 'PLAN DE PRODUCCION', '" &
                         Microsoft.VisualBasic.Right("0000000000" & txt_op_numero_orden.Text.Trim, 10) & "'"
                    MTRans.Actualiza(tx_SQL)
                End If


            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Crear_Estructura_Insumos()

        Dim dt As New DataTable("insumos_pack")

        dt.Columns.Add(New DataColumn("cod_insumo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Especificaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("costo", GetType(Decimal)))

        Ods.Tables.Add(dt.Copy)
        Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")
        combo_datagrid_insumos()

    End Sub

    Private Sub combo_datagrid_insumos()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "insumos_pack"

        Dim dt As DataTable = Ods.Tables("insumos_pack")
        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_insumo"
        ComboTextCol.HeaderText = "Tipo "
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = Ods.Tables("mpacks_insumos").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_insumo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight

        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5
        tableStyle.GridColumnStyles.Add(ComboTextCol)

        Dim TextCol As New DataGridTextBoxColumn
        TextCol.MappingName = dt.Columns(1).ColumnName
        TextCol.HeaderText = "Especificaciones"
        TextCol.Width = 180
        tableStyle.GridColumnStyles.Add(TextCol)

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = dt.Columns(2).ColumnName
        TextCol2.HeaderText = "costo"
        TextCol2.Format = "N4"
        TextCol2.Width = 110
        TextCol2.Alignment = HorizontalAlignment.Right
        tableStyle.GridColumnStyles.Add(TextCol2)

        Me.dg_detalle_pack_insumos.TableStyles.Clear()
        Me.dg_detalle_pack_insumos.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Mostrar_OP_Producto()
        Dim ls_sql As String

        Dim dt As DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Me.dg_op_producto.DataSource = Nothing
            '   myOtrans.open()

            '            ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','"


            ls_sql = "pa_sel_um_maq_orden_produccion '" & gs_empresa & "','"
            If Me.TabControl1.SelectedTab.Name.ToLower = "tb_nuevo_op" Then
                ls_sql = ls_sql & Me.cmb_op_pack.SelectedValue & "'"
            ElseIf Me.TabControl1.SelectedTab.Name.ToLower = "tb_estadisticas" Then
                ls_sql = ls_sql & Me.cmb_pack_estadisticas.SelectedValue & "'"
            End If

            'debo obtener el codigo en onbase
            'dt = myOtrans.Obtiene(ls_sql)
            'If dt.Rows.Count > 0 Then
            'ls_sql = "call pa_sel_um_maq_orden_produccion (" & dt.Rows(0).Item("cod_producto") & ")"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = ClsGen.selectQuery("Corporativo", ls_sql)

            Me.dg_op_producto.DataSource = dt
            Me.dg_estadisticas_op.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_op_producto, dt.TableName, -1, 200, 0, True, True, "", True, "")
            ClsGen.Alinea_Grid(dt, Me.dg_estadisticas_op, dt.TableName, -1, 200, 0, True, True, "", True, "")
            'End If

        Catch ex As Exception
        Finally
            '  myOtrans.close()
            '   myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    'Muestro todas las Op pendientes
    Private Sub Mostrar_OP_Pendientes()
        Dim ls_sql As String

        Dim dt2 As DataTable

        Dim ClsGen As New ClasesGenerales.General

        Try



            'debo obtener el codigo en onbase
            ls_sql = "pa_var_um_maq_orden_produccion_pendientes '" & gs_empresa & "'"
            'dt2 = myOtrans.Obtiene(ls_sql)
            dt2 = ClsGen.selectQuery("Corporativo", ls_sql)
            Me.dg_op_pendientes.DataSource = dt2
            ClsGen.Alinea_Grid(dt2, Me.dg_op_pendientes, dt2.TableName, -1, 150, 20, False, True, "", True, "")

        Catch ex As Exception
        Finally

            ClsGen = Nothing
        End Try


    End Sub

    Private Sub Mostrar_Estadisticas()
        Dim ls_sql As String
        Dim nexistencia As Integer

        Dim dt2 As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()

            ls_sql = "pa_var_um_venta_producto '" & gs_empresa & "','" & Me.cmb_pack_estadisticas.SelectedValue & "','01/01/" & Now.ToString("yyyy") & "'"
            dt2 = Otrans.Obtiene(ls_sql)
            Me.dg_estadisticas_ventas.DataSource = dt2
            ClsGen.Alinea_Grid(dt2, Me.dg_estadisticas_ventas, dt2.TableName, -1, 250, 50, False, True, "nsemana,unidades,", True, "")

            dt2 = Ods.Tables("packs").Copy
            dt2.DefaultView.RowFilter = "producto = '" & Me.cmb_pack_estadisticas.SelectedValue & "'"

            If dt2.DefaultView.Count > 0 Then
                nexistencia = dt2.DefaultView(0).Item("existencia").ToString
                Me.txt_estadisticas_existencia.Text = nexistencia.ToString
            Else
                Me.txt_estadisticas_existencia.Text = ""
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Inicializar_Estadisticas()
        Me.txt_estadisticas_existencia.Text = 0
        Me.dg_estadisticas_ventas.DataSource = Nothing
    End Sub

    Private Sub Aplicar_Seguridad()
        If tiene_permisos("mlo_maq_detalle_pack") Then
            Me.btn_guardar_detalle_pack.Visible = True
        End If

        If tiene_permisos("mlo_maq_orden_produccion") Then
            Me.btn_guardar_orden_produccion.Visible = True
            Me.btn_nuevo_orden_produccion.Visible = True
        End If
    End Sub

    Private Sub Mostrar_Ordenes_Completas()
        Dim ls_sql As String

        Dim dt2 As DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try

            'myOtrans.open()

            'debo obtener el codigo en onbase
            ls_sql = "pa_var_um_maq_orden_produccion '" & gs_empresa & "'"
            'dt2 = myOtrans.Obtiene(ls_sql)
            dt2 = ClsGen.selectQuery("Corporativo", ls_sql)
            Me.dg_lo_listado_ordenes.DataSource = dt2
            ClsGen.Alinea_Grid(dt2, Me.dg_lo_listado_ordenes, dt2.TableName, -1, 150, 20, False, True, "", True, "")

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub frm_maq_monitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Aplicar_Seguridad()
        Llenar_Packs_Activos()
        Mostrar_Detalle_Pack()
        Crear_Estructura_Insumos()
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        Mostrar_Detalle_Pack()
    End Sub

    Private Sub cmb_pack_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_op_pack.SelectionChangeCommitted
        Obtener_Productos_Pack()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If Me.TabControl1.SelectedTab.Name.ToLower = "tb_nuevo_op" Or _
           Me.TabControl1.SelectedTab.Name.ToLower = "tb_detalle_pack" Then
            If DebeObtener_Productos() Then
                Obtener_Productos_Pack()
            End If

        End If

        If Me.TabControl1.SelectedTab.Name.ToLower = "tb_detalle_pack" Then
            Mostrar_Detalle_OnBase()
        End If

        If Me.TabControl1.SelectedTab.Name.ToLower = "tb_nuevo_op" Then
            Mostrar_OP_Producto()
        End If

        If Me.TabControl1.SelectedTab.Name.ToLower = "tb_estadisticas" Then
            Inicializar_Estadisticas()
            InicializarBarra(Me.PanelRellenoProduccion, "V")
        End If

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'Dim ls_Sql As String = String.Empty
        'Dim dt As New DataTable

        'myOtrans.open()
        Try
            'ls_Sql = "CALL pa_sel_um_inv_producto(NULL,'" & gs_empresa & "', '" & Me.cmb_detalle_pack.SelectedValue & "')"
            'dt = myOtrans.Obtiene(ls_Sql)

            'obtener_detalle_pack_insumo(dt.Rows(0)("cod_producto"))

            obtener_detalle_pack_insumo(Me.cmb_detalle_pack.SelectedValue, gs_empresa)

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
        End Try
    End Sub

    Private Sub btn_guardar_detalle_pack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_detalle_pack.Click
        Me.txt_detalle_pack_inventario_minimo.Text = IIf(Me.txt_detalle_pack_inventario_minimo.Text.Length = 0, "0", Me.txt_detalle_pack_inventario_minimo.Text)
        If Me.btn_guardar_detalle_pack.Text = "Guardar" Then
            Guardar_Detalle_Pack()
        Else
            Modificar_Detalle_Pack()
        End If

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String = String.Empty
        Dim dt As New DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            'myOtrans.open()
            ls_sql = "pa_sel_um_maq_detalle_pack null,'" & gs_empresa & "'"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = clsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "detalle_onbase_packs"

            If Ods.Tables.Contains("detalle_onbase_packs") Then Ods.Tables.Remove("detalle_onbase_packs")

            Ods.Tables.Add(dt.Copy)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pb_fotopack_1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_fotopack_1.DoubleClick
        Dim xx As String
        Dim clsgen As New ClasesGenerales.General
        xx = "\\" & clsgen.Obtener_XMLConfig("Servidor_Alterno_" & clsgen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images"

        ofd.Filter = "png|*.png"
        ofd.InitialDirectory = xx '"\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza"
        ofd.ShowDialog()

        Try
            Dim finfo As New FileInfo(ofd.FileName)
            simagen1 = finfo.Name
            If simagen1.Length > 0 Then
                Me.pb_fotopack_1.Image = Image.FromFile(simagen1)
            Else

            End If

        Catch ex As Exception

        End Try
        clsgen = Nothing
    End Sub

    Private Sub btn_detalle_pack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalle_pack.Click
        Obtener_Productos_Pack()
        Me.TabControl1.SelectedTab = Me.tb_detalle_pack
    End Sub

    Private Sub btn_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_orden_produccion.Click
        Obtener_Productos_Pack()
        Me.TabControl1.SelectedTab = Me.tb_nuevo_op
    End Sub

    Private Sub btn_estadisticas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_estadisticas.Click
        Me.TabControl1.SelectedTab = Me.tb_estadisticas
    End Sub

    Private Sub btn_op_mostrar_ordenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_op_mostrar_ordenes.Click
        Mostrar_OP_Producto()
        Mostrar_OP_Pendientes()
    End Sub

    Private Function tienen_existencias() As Boolean
        Try
            For ii As Integer = 0 To Ods.Tables("detalle_pack").Rows.Count - 1
                If Val(txt_op_cantidad_solicitada.Text) * Val(Ods.Tables("detalle_pack").Rows(ii)("cantidad").ToString) > Val(Ods.Tables("detalle_pack").Rows(ii)("existencia").ToString) Then
                    MessageBox.Show("Las existencias del producto (" & _
                                    Ods.Tables("detalle_pack").Rows(ii)("productoi").ToString & "  -  " & _
                                    Ods.Tables("detalle_pack").Rows(ii)("glosai").ToString & ")." & vbCrLf & _
                                    "No son suficientes para completar esta orden.", _
                                    "Existencia insuficiente.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Next
        Catch ex As Exception

        End Try

        Return True
    End Function

    Private Function tiene_peso_volumen() As Boolean

        Dim clsGen As New ClasesGenerales.General
        Dim lbtiene_peso_volumen As Boolean = False
        Dim dt As DataTable
        Try

            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_producto '" & gs_empresa & "','" & Me.cmb_op_pack.SelectedValue & "'")
            If dt.Rows.Count > 0 Then
                If Double.Parse(dt.Rows(0).Item("analisisproducto1").ToString) > 0 And _
                    Double.Parse(dt.Rows(0).Item("analisisproducto2").ToString) > 0 Then
                    lbtiene_peso_volumen = True
                Else
                    MessageBox.Show("El Producto Tiene " & dt.Rows(0).Item("analisisproducto1").ToString & " Peso y " & dt.Rows(0).Item("analisisproducto2").ToString & "Volumen", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

        Return lbtiene_peso_volumen
    End Function


    Private Sub btn_guardar_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_orden_produccion.Click

        If Not tienen_existencias() Then Exit Sub

        If Val(txt_op_cantidad_solicitada.Text) <= 0 Then
            MessageBox.Show("La cantidad no puede ser negativa o cero.", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim mDato() As String = txt_op_cantidad_solicitada.Text.Trim.Split(".")

        If mDato.Length > 1 Then
            If Val(mDato(1)) > 0 Then
                MessageBox.Show("Es campo no aceptar decimales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_op_cantidad_solicitada.Focus()

                Exit Sub
            End If
        End If


        If Not tiene_peso_volumen() Then Exit Sub

        If Me.btn_guardar_orden_produccion.Text = "Guardar" And Me.txt_op_numero_orden.Text.Length = 0 Then
            Guardar_Orden_Produccion()
            If txt_op_numero_orden.Text.Trim.Length > 0 Then crea_documento()

            Mostrar_OP_Producto()
            Mostrar_OP_Pendientes()

        End If
    End Sub


    Private Sub pb_fotopack_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_fotopack_2.Click
        Dim xx As String
        Dim clsgen As New ClasesGenerales.General
        xx = "\\" & clsgen.Obtener_XMLConfig("Servidor_Alterno_" & clsgen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\images"

        ofd.Filter = "png|*.png"
        ofd.InitialDirectory = xx
        ofd.ShowDialog()
        Dim finfo As New FileInfo(ofd.FileName)
        simagen2 = finfo.Name
        Me.pb_fotopack_2.Image = Image.FromFile(simagen2)
        clsgen = Nothing
    End Sub

    Private Sub Mant_Materiales_Auxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mant_Materiales_Auxiliares.Click

        If tiene_permisos("mlo_maq_man_auxiliares") Then
            Mantenimiento_Auxiliares()
        Else
            MessageBox.Show("No tiene Acceso a Esta Opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Mantenimiento_Auxiliares()
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "maq_insumos"
        oform.Text = "::. Mantenimiento de Materiales Auxiliares .::"
        oform.ShowDialog()

        Dim ls_sql As String

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            If Ods.Tables.IndexOf("mpacks_insumos") >= 0 Then
                Ods.Tables.Remove("mpacks_insumos")
            End If

            'myOtrans.open()
            ls_sql = "pa_sel_um_maq_insumos "
            'dt = myOtrans.Obtiene(ls_sql)

            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "mpacks_insumos"
            Ods.Tables.Add(dt.Copy)

            combo_datagrid_insumos()
        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
        End Try
    End Sub

    Private Sub cmb_detalle_pack_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_detalle_pack.SelectionChangeCommitted
        Obtener_Productos_Pack()
        Mostrar_Detalle_OnBase()
    End Sub

    Private Sub menu_asignacion_ordenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpro_asignacion_ordenes.Click

        If tiene_permisos("mlo_maq_pro_Asignar_Ordenes") Then
            Dim oform As New frm_maq_asignacion_ordenes
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
        Else
            MessageBox.Show("No tiene Acceso a Esta Opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    'Proceso de Produccion
    Private Sub mpro_proceso_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpro_proceso_produccion.Click
        If tiene_permisos("mlo_maq_pro_proceso_produccion") Then
            Dim oform As New frm_maq_proceso_produccion
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
        Else
            MessageBox.Show("No tiene Acceso a Esta Opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_mostrar_estadisticas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar_estadisticas.Click
        Mostrar_OP_Producto()
        Mostrar_Estadisticas()
        InicializarBarra(Me.PanelRellenoProduccion, "V") 'de abajo a arriba
        'de abajo a arriba
        Mostrar_Imagen_Produccion()
    End Sub

    Private Sub Mostrar_Imagen_Produccion()
        Dim nrow, nsolicitado, norden, navance As Integer
        Dim ls_sql As String

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General()
        Dim dt As DataTable

        nsolicitado = 0
        norden = 0
        navance = 0
        Me.txt_estadisticas_producido.Text = 0

        Try
            nrow = Me.dg_estadisticas_op.CurrentCell.RowNumber
            nsolicitado = Me.dg_estadisticas_op.Item(nrow, 2)
            norden = Me.dg_estadisticas_op.Item(nrow, 1)
        Catch ex As Exception
        End Try

        Try

            ls_sql = "pa_sel_um_maq_orden_produccion_avance " & norden
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            If dt.Rows.Count > 0 Then
                navance = (dt.Rows(0).Item("Cantidad") / nsolicitado) * 100
            End If

            Me.txt_estadisticas_producido.Text = dt.Rows(0).Item("Cantidad")
        Catch ex As Exception
        Finally

        End Try

        ActualizarBarra(Me.PanelRellenoProduccion, Me.PanelBaseProduccion, "B", navance)
    End Sub

    Sub InicializarBarra(ByRef NombreBarraRelleno As Panel, ByVal PosicionBarra As String)
        ' Valores de PosicionBarra
        ' H = Horizontal; V(Vertical)
        If PosicionBarra.ToUpper = "H" Then
            NombreBarraRelleno.Width = 0
        ElseIf PosicionBarra = "V" Then
            NombreBarraRelleno.Height = 0
        End If
    End Sub

    Sub ActualizarBarra(ByRef NombreBarraRelleno As Panel, ByRef NombreBarraBase As Panel, _
             ByVal PuntoInicio As String, ByVal Valor As Integer)
        ' Valores de PuntoInicio
        ' R(Right) = de derecha a izquierda ; L(Left) = de izquierda a derecha ; 
        ' T(Top) = de arriba a abajo ; B(Bottom) = de abajo a arriba

        'variable que sirve para guardar el valor de la unidad en la barra de progreso
        Dim Unidad As Decimal

        If PuntoInicio.ToUpper = "R" Or PuntoInicio.ToUpper = "L" Then
            'guardo el valor de la unidad de la barra de relleno
            Unidad = NombreBarraBase.Width / 100
        Else
            If PuntoInicio.ToUpper = "T" Or PuntoInicio.ToUpper = "B" Then
                'guardo el valor de la unidad de la barra de relleno
                Unidad = NombreBarraBase.Height / 100
            End If
        End If
        Select Case PuntoInicio
            Case "R" 'de derecha a izquierda
                NombreBarraRelleno.Left = NombreBarraBase.Width - (Unidad * Valor)
                NombreBarraRelleno.Width = Unidad * Valor
            Case "L" 'de izquierda a derecha
                NombreBarraRelleno.Width() = NombreBarraRelleno.Left + (Unidad * Valor)
            Case "T" 'de arriba a abajo
                NombreBarraRelleno.Height() = NombreBarraRelleno.Top + (Unidad * Valor)
            Case "B" 'de abajo a arriba
                NombreBarraRelleno.Top = NombreBarraBase.Height - (Unidad * Valor)
                NombreBarraRelleno.Height() = Unidad * Valor
            Case Else
                MessageBox.Show("El valor del parámetro PuntoInicio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub dg_estadisticas_op_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_estadisticas_op.CurrentCellChanged
        Mostrar_Imagen_Produccion()
    End Sub

    Private Sub btn_nuevo_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_orden_produccion.Click
        Me.txt_op_numero_orden.Text = ""
        Me.btn_guardar_orden_produccion.Text = "Guardar"
        Me.txt_op_observaciones.Text = ""
        Me.dtp_op_fecha_inicio.Value = Today

        txt_op_cantidad_solicitada.Text = String.Empty
        txt_op_numero_orden.Text = String.Empty
        txt_op_observaciones.Text = String.Empty
    End Sub

    Private Sub tbn_lo_mostrar_ordenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbn_lo_mostrar_ordenes.Click
        Mostrar_Ordenes_Completas()
    End Sub

    Private Sub tb_nuevo_op_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nuevo_op.Enter
        txt_op_cantidad_solicitada.Text = String.Empty
        txt_op_numero_orden.Text = String.Empty
        txt_op_observaciones.Text = String.Empty

        dtp_op_fecha_inicio.Value = Now
    End Sub

    Private Sub dg_detalle_pack_insumos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_detalle_pack_insumos.CurrentCellChanged
        If dg_detalle_pack_insumos.CurrentRowIndex < 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub

    Private Sub tb_detalle_pack_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_detalle_pack.Enter
        txt_total_costo.Text = String.Empty

        If dg_detalle_pack_insumos.CurrentRowIndex <= 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub

    Private Sub txt_filtro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_filtro.KeyDown
        If e.KeyCode = Keys.Enter Then
            hacerFiltro()
        End If
    End Sub

    Private Function validarCampos() As Boolean
        If cb_campos.Text.Trim.Length <= 0 Then
            MessageBox.Show("Aun no ha seleccionado el campor de busqueda.", "Campo de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_campos.Focus()
            Return False
        End If

        If cb_condicion.Text.Trim.Length <= 0 Then
            MessageBox.Show("Aun no ha seleccionado el tipo de filtro.", "Tipo Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_condicion.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub hacerFiltro()
        If Not validarCampos() Then Exit Sub

        Dim MyTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim SQL_tx As String = String.Empty
        Dim dt As New DataTable
        Dim clsgen As New ClasesGenerales.General

        MyTrans.open()

        Try
            If cb_condicion.Text.ToLower = "like" Then
                SQL_tx = "SELECT * FROM vi_maq_orden_produccion WHERE " & cb_campos.Text & _
                         " " & cb_condicion.Text & " '%" & txt_filtro.Text & "%'"

            Else
                SQL_tx = "SELECT * FROM vi_maq_orden_produccion WHERE " & cb_campos.Text & _
                         " " & cb_condicion.Text & " '" & txt_filtro.Text & "'"
            End If

            dt = MyTrans.Obtiene(SQL_tx)

            Me.dg_lo_listado_ordenes.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_lo_listado_ordenes, dt.TableName, -1, 150, 20, False, True, "", True, "")

        Catch ex As Exception
        Finally
            MyTrans.close()
            MyTrans = Nothing
        End Try
    End Sub

    Private Sub tp_packs_activos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_packs_activos.Enter
        Mostrar_Detalle_Pack()
    End Sub

    Private Sub dg_lo_listado_ordenes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_lo_listado_ordenes.DoubleClick
        TabControl1.SelectedTab = tb_detalle_op
        cargar_detalle_costos_packs()

    End Sub

    Private Function cargar_detalle_costos_packs()

        'Dim MyTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim newRow As DataRow
        Dim ls_sql As String
        Dim nrow, index As Integer
        Dim ClsGen As New ClasesGenerales.General

        nrow = dg_lo_listado_ordenes.CurrentCell.RowNumber
        txt_detalle_codigo.Text = dg_lo_listado_ordenes.Item(nrow, 1)
        txt_detalle_descripcion.Text = dg_lo_listado_ordenes.Item(nrow, 2)
        txt_detalle_orden.Text = dg_lo_listado_ordenes.Item(nrow, 0)
        txt_detalle_total.Text = dg_lo_listado_ordenes.Item(nrow, 3)


        Try

            ls_sql = "pa_sel_um_maq_costo_materiales 1"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "materiales"
            dt.Columns.Add("cantidad")
            ds.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_maq_costo_materiales 2"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            newRow = dt.NewRow()
            newRow("descripcion") = "No. Operadores Asignados"
            dt.Rows.Add(newRow)
            dt.TableName = "costo_primo"
            dt.Columns.Add("cantidad")
            ds.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_costo_materiales 3"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "costo_equipo"
            dt.Columns.Add("cantidad")
            ds.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_maq_materiales_pack_costo " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)


        Catch ex As Exception

        End Try


        Try
            'MyTrans.open()
            'Lleno los grids con los materiales segun su tipo
            'ls_sql = "call pa_sel_um_maq_costo_materiales (1)"
            'dt = MyTrans.Obtiene(ls_sql)
            'dt.TableName = "materiales"
            'dt.Columns.Add("cantidad")
            'ds.Tables.Add(dt.Copy)

            'ls_sql = "call pa_sel_um_maq_costo_materiales (2)"
            'dt = MyTrans.Obtiene(ls_sql)
            'newRow = dt.NewRow()
            'newRow("descripcion") = "No. Operadores Asignados"
            'dt.Rows.Add(newRow)
            'dt.TableName = "costo_primo"
            'dt.Columns.Add("cantidad")
            'ds.Tables.Add(dt.Copy)

            'ls_sql = "call pa_sel_um_maq_costo_materiales (3)"
            'dt = MyTrans.Obtiene(ls_sql)
            'dt.TableName = "costo_equipo"
            'dt.Columns.Add("cantidad")
            'ds.Tables.Add(dt.Copy)

            ''Verifico si ya hay datos para la orden seleccionada
            'ls_sql = "call pa_sel_um_maq_materiales_pack_costo(" & txt_detalle_orden.Text & ",'" & gs_empresa & "')"
            'dt = MyTrans.Obtiene(ls_sql)

            If dt.Rows.Count <> 0 Then
                dtp_Fecha_Operacion.Value = dt.Rows(0).Item("fecha_operacion")
                txt_costo_base.Text = dt.Rows(0).Item("costo_base")
                txt_costo_total.Text = dt.Rows(0).Item("costo_total")
                txt_costo_materiales.Text = dt.Rows(0).Item("costo_materiales")
                txt_costo_unitario.Text = dt.Rows(0).Item("costo_unitario")
                txt_precio_fact.Text = dt.Rows(0).Item("precio_facturacion")
                ds.Tables("costo_primo").Rows(ds.Tables("costo_primo").Rows.Count - 1).Item("cantidad") = dt.Rows(0).Item("total_operadores")
            Else
                txt_costo_base.Text = 0.0
                txt_costo_total.Text = 0.0
                txt_costo_materiales.Text = 0.0
                txt_costo_unitario.Text = 0.0
                txt_precio_fact.Text = 0.0
                dtp_Fecha_Operacion.Value = Now()

            End If

            ls_sql = "pa_sel_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)


            If dt.Rows.Count <> 0 Then
                Dim index2 As Integer

                index = 0
                For Each row As DataRow In dt.Rows

                    'Si es tipo 1 lo busca en materiales y le asigna la cantidad
                    If dt.Rows(index).Item("tipo") = 1 Then

                        For Each row2 As DataRow In ds.Tables("materiales").Rows
                            If (ds.Tables("materiales").Rows(index2).Item("cod_material") = dt.Rows(index).Item("material")) Then
                                ds.Tables("materiales").Rows(index2).Item("cantidad") = dt.Rows(index).Item("cantidad")
                            End If
                            index2 += 1
                        Next

                        index2 = 0
                    End If

                    'Si es tipo 2 lo busca en costo primo y le asigna la cantidad
                    If dt.Rows(index).Item("tipo") = 2 Then

                        For Each row2 As DataRow In ds.Tables("costo_primo").Rows

                            If (ds.Tables("costo_primo").Rows.Count - 1) <> index2 Then
                                If (ds.Tables("costo_primo").Rows(index2).Item("cod_material") = dt.Rows(index).Item("material")) Then
                                    ds.Tables("costo_primo").Rows(index2).Item("cantidad") = dt.Rows(index).Item("cantidad")
                                End If
                            End If

                            index2 += 1
                        Next

                        index2 = 0
                    End If

                    'Si es tipo 3 lo busca en costo equipo y le asigna la cantidad
                    If dt.Rows(index).Item("tipo") = 3 Then

                        For Each row2 As DataRow In ds.Tables("costo_equipo").Rows
                            If (ds.Tables("costo_equipo").Rows(index2).Item("cod_material") = dt.Rows(index).Item("material")) Then
                                ds.Tables("costo_equipo").Rows(index2).Item("cantidad") = dt.Rows(index).Item("cantidad")
                            End If
                            index2 += 1
                        Next

                        index2 = 0
                    End If

                    index += 1
                Next

            End If

            dgv_materiales.DataSource = ds.Tables("materiales")
            dgv_costo_primo.DataSource = ds.Tables("costo_primo")
            dgv_costo_equipo.DataSource = ds.Tables("costo_equipo")

            'Poner ceros en los materiales no usados en el pack
            index = 0

            For Each row As DataGridViewRow In dgv_materiales.Rows
                If IsDBNull(dgv_materiales.Item("cantidad", index).Value) Then dgv_materiales.Item("cantidad", index).Value = 0
                index += 1
            Next

            index = 0
            For Each row As DataGridViewRow In dgv_costo_primo.Rows
                If IsDBNull(dgv_costo_primo.Item("cantidad", index).Value) Then dgv_costo_primo.Item("cantidad", index).Value = 0
                index += 1
            Next

            index = 0
            For Each row As DataGridViewRow In dgv_costo_equipo.Rows
                If IsDBNull(dgv_costo_equipo.Item("cantidad", index).Value) Then dgv_costo_equipo.Item("cantidad", index).Value = 0
                index += 1
            Next


            ClsGen.Alinear_GridView(ds.Tables("materiales"), Me.dgv_materiales, ",descripcion,cantidad,", ",costo,", ",descripcion,", "", "", "", "", False, True, 250, 0)
            ClsGen.Alinear_GridView(ds.Tables("costo_primo"), Me.dgv_costo_primo, ",descripcion,cantidad,", ",costo,", ",descripcion,", "", "", "", "", False, True, 250, 0)
            ClsGen.Alinear_GridView(ds.Tables("costo_equipo"), Me.dgv_costo_equipo, ",descripcion,cantidad,", ",costo,", ",descripcion,", "", "", "", "", False, True, 250, 0)

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)

        Finally
            'MyTrans.close()
            'MyTrans = Nothing

        End Try

    End Function

    Private Function calcular_costo_base() As Double
        Dim costo_base As Double

        costo_base = calcular_costo_primo() + calcular_costo_equipo()

        Return (costo_base)

    End Function

    Private Function calcular_costo_primo() As Double
        Dim index As Integer = 0
        Dim total As Integer
        Dim costo_primo, _aux As Double

        total = dgv_costo_primo.Rows.Count

        For Each row As DataGridViewRow In dgv_costo_primo.Rows
            _aux = 0

            If total <> (index + 1) Then
                If IsDBNull(dgv_costo_primo.Item("costo", index).Value) Then dgv_costo_primo.Item("costo", index).Value = 0
                If IsDBNull(dgv_costo_primo.Item("cantidad", index).Value) Then dgv_costo_primo.Item("cantidad", index).Value = 0
                If IsDBNull(dgv_costo_primo.Item("cantidad", (total - 1)).Value) Then dgv_costo_primo.Item("cantidad", (total - 1)).Value = 0

                _aux = Convert.ToDouble(dgv_costo_primo.Item("cantidad", index).Value) * Convert.ToDouble(dgv_costo_primo.Item("costo", index).Value)
                _aux = _aux * Convert.ToDouble(dgv_costo_primo.Item("cantidad", (total - 1)).Value)

            End If

            costo_primo = costo_primo + _aux
            index += 1
        Next

        Return (costo_primo)

    End Function

    Private Function calcular_costo_equipo() As Double
        Dim costo_equipo, _aux As Double
        Dim index As Integer = 0

        costo_equipo = 0

        For Each row As DataGridViewRow In dgv_costo_equipo.Rows
            _aux = 0

            If IsDBNull(dgv_costo_equipo.Item("costo", index).Value) Then dgv_costo_equipo.Item("costo", index).Value = 0
            If IsDBNull(dgv_costo_equipo.Item("cantidad", index).Value) Then dgv_costo_equipo.Item("cantidad", index).Value = 0

            _aux = Convert.ToDouble(dgv_costo_equipo.Item("cantidad", index).Value) * Convert.ToDouble(dgv_costo_equipo.Item("costo", index).Value)
            costo_equipo = costo_equipo + _aux
            index += 1
        Next

        Return (costo_equipo)

    End Function

    Private Function calcular_costo_materiales() As Double
        Dim costo_materiales, _aux As Double
        Dim index As Integer = 0
        costo_materiales = 0

        For Each row As DataGridViewRow In dgv_materiales.Rows
            _aux = 0

            If IsDBNull(dgv_materiales.Item("costo", index).Value) Then dgv_materiales.Item("costo", index).Value = 0
            If IsDBNull(dgv_materiales.Item("cantidad", index).Value) Then dgv_materiales.Item("cantidad", index).Value = 0
            Try
                _aux = Convert.ToDouble(dgv_materiales.Item("cantidad", index).Value) * Convert.ToDouble(dgv_materiales.Item("costo", index).Value)
            Catch ex As Exception

            End Try
            costo_materiales = costo_materiales + _aux
            index += 1

        Next

        Return (costo_materiales)

    End Function

    Private Sub calcular_costos()

        txt_costo_base.Text = Math.Round(calcular_costo_base(), 4)
        txt_costo_materiales.Text = Math.Round(calcular_costo_materiales(), 4)
        txt_costo_total.Text = Math.Round(Convert.ToDouble((txt_costo_base.Text) + Convert.ToDouble(txt_costo_materiales.Text)), 4)
        txt_costo_unitario.Text = Math.Round(Convert.ToDouble(txt_costo_base.Text) / Convert.ToDouble(txt_detalle_total.Text), 4)
        txt_precio_fact.Text = Math.Round(Convert.ToDouble(txt_costo_unitario.Text) * 1.4, 4) '40% a partir del 17 de Marzo

    End Sub

    Private Sub dgv_materiales_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_materiales.CellValueChanged
        calcular_costos()
    End Sub

    Private Sub dgv_costo_equipo_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_costo_equipo.CellValueChanged
        calcular_costos()

    End Sub

    Private Sub dgv_costo_primo_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_costo_primo.CellValueChanged
        calcular_costos()
    End Sub

    Private Function Guardar_Cantidad_Materiales_Packs()
        'Dim MyTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim index As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            '   MyTrans.open()

            'Guardo los costos totales
            ls_sql = "pa_sel_um_maq_materiales_pack_costo " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
            '   dt = MyTrans.Obtiene(ls_sql)
            dt = clsGen.selectQuery("Corporativo", ls_sql)

            If (dt.Rows.Count > 0) Then
                ls_sql = "pa_del_um_maq_materiales_pack_costo " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
                clsGen.insertQuery("Corporativo", ls_sql)
                'MyTrans.Elimina(ls_sql)
            End If

            ls_sql = "pa_ins_um_maq_materiales_pack_costo " & txt_detalle_orden.Text & ",'" & gs_empresa & "','" &
                                    dtp_Fecha_Operacion.Value.ToString("dd/MM/yyyy") & "'," & dgv_costo_primo.Item("cantidad", (dgv_costo_primo.Rows.Count - 1)).Value & "," &
                                    txt_costo_base.Text & "," & txt_costo_materiales.Text & "," & txt_costo_total.Text & "," &
                                    txt_costo_unitario.Text & "," & txt_precio_fact.Text & ",'" & gs_usuario & "'"


            clsGen.insertQuery("Corporativo", ls_sql)


            'Guardo detalle de materiales en los packs
            ls_sql = "pa_sel_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
            ''dt = MyTrans.Obtiene(ls_sql)
            dt = clsGen.selectQuery("Corporativo", ls_sql)
            If (dt.Rows.Count > 0) Then
                ls_sql = "pa_del_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" & gs_empresa & "'"
                'MyTrans.Elimina(ls_sql)
                clsGen.insertQuery("Corporativo", ls_sql)
            End If

            index = 0
            For Each row As DataGridViewRow In dgv_costo_primo.Rows
                If (dgv_costo_primo.Rows.Count - 1 <> index) Then
                    If (dgv_costo_primo.Item("cantidad", index).Value <> 0) Then
                        ls_sql = "pa_ins_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" &
                                                                gs_empresa & "'," & dgv_costo_primo.Item("cod_material", index).Value & "," &
                                                                dgv_costo_primo.Item("cantidad", index).Value & "," & dgv_costo_primo.Item("costo", index).Value & ",'" & gs_usuario & "'"

                        clsGen.insertQuery("Corporativo", ls_sql)
                    End If
                End If
                index += 1
            Next

            index = 0
            For Each row As DataGridViewRow In dgv_costo_equipo.Rows

                If (dgv_costo_equipo.Item("cantidad", index).Value <> 0) Then
                    ls_sql = "pa_ins_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" &
                                                gs_empresa & "'," & dgv_costo_equipo.Item("cod_material", index).Value & "," &
                                                dgv_costo_equipo.Item("cantidad", index).Value & "," & dgv_costo_equipo.Item("costo", index).Value & ",'" & gs_usuario & "'"

                    clsGen.insertQuery("Corporativo", ls_sql)
                End If

                index += 1
            Next

            index = 0
            For Each row As DataGridViewRow In dgv_materiales.Rows

                If (dgv_materiales.Item("cantidad", index).Value <> 0) Then
                    ls_sql = "pa_ins_um_maq_materiales_pack_detalle " & txt_detalle_orden.Text & ",'" &
                                                gs_empresa & "'," & dgv_materiales.Item("cod_material", index).Value & "," &
                                                dgv_materiales.Item("cantidad", index).Value & "," & dgv_materiales.Item("costo", index).Value & ",'" & gs_usuario & "'"
                    clsGen.insertQuery("Corporativo", ls_sql)

                End If

                index += 1
            Next

            'If MyTrans.Codigo_error > 0 Then MessageBox.Show("ERROR: " & MyTrans.descripcion_error)

            MessageBox.Show("Costos guardados correctamente para la orden No. " & txt_detalle_orden.Text)


        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)

        Finally
            'MyTrans.close()
            'MyTrans = Nothing
        End Try

    End Function

    'Private Function Guardar_Cantidad_Materiales_Packs_onbase()
    '    Dim MyTrans As New Transaccional.Conexion_mysql("OnBase")
    '    Dim ls_sql As String
    '    Dim dt As New DataTable
    '    Dim ds As New DataSet
    '    Dim index As Integer

    '    Try
    '        MyTrans.open()

    '        'Guardo los costos totales
    '        ls_sql = "call pa_sel_um_maq_materiales_pack_costo(" & txt_detalle_orden.Text & ",'" & gs_empresa & "')"
    '        dt = MyTrans.Obtiene(ls_sql)

    '        If (dt.Rows.Count > 0) Then
    '            ls_sql = "call pa_del_um_maq_materiales_pack_costo(" & txt_detalle_orden.Text & ",'" & gs_empresa & "')"
    '            MyTrans.Elimina(ls_sql)
    '        End If

    '        ls_sql = "call pa_ins_um_maq_materiales_pack_costo(" & txt_detalle_orden.Text & ",'" & gs_empresa & "','" &
    '                                dtp_Fecha_Operacion.Value.ToString("yyyy/MM/dd") & "'," & dgv_costo_primo.Item("cantidad", (dgv_costo_primo.Rows.Count - 1)).Value & "," &
    '                                txt_costo_base.Text & "," & txt_costo_materiales.Text & "," & txt_costo_total.Text & "," &
    '                                txt_costo_unitario.Text & "," & txt_precio_fact.Text & ",'" & gs_usuario & "')"


    '        MyTrans.Ingresa(ls_sql)


    '        'Guardo detalle de materiales en los packs
    '        ls_sql = "call pa_sel_um_maq_materiales_pack_detalle(" & txt_detalle_orden.Text & ",'" & gs_empresa & "')"
    '        dt = MyTrans.Obtiene(ls_sql)
    '        If (dt.Rows.Count > 0) Then
    '            ls_sql = "call pa_del_um_maq_materiales_pack_detalle(" & txt_detalle_orden.Text & ",'" & gs_empresa & "')"
    '            MyTrans.Elimina(ls_sql)
    '        End If

    '        index = 0
    '        For Each row As DataGridViewRow In dgv_costo_primo.Rows
    '            If (dgv_costo_primo.Rows.Count - 1 <> index) Then
    '                If (dgv_costo_primo.Item("cantidad", index).Value <> 0) Then
    '                    ls_sql = "call pa_ins_um_maq_materiales_pack_detalle(" & txt_detalle_orden.Text & ",'" &
    '                                                            gs_empresa & "'," & dgv_costo_primo.Item("cod_material", index).Value & "," &
    '                                                            dgv_costo_primo.Item("cantidad", index).Value & "," & dgv_costo_primo.Item("costo", index).Value & ",'" & gs_usuario & "')"

    '                    MyTrans.Ingresa(ls_sql)
    '                End If
    '            End If
    '            index += 1
    '        Next

    '        index = 0
    '        For Each row As DataGridViewRow In dgv_costo_equipo.Rows

    '            If (dgv_costo_equipo.Item("cantidad", index).Value <> 0) Then
    '                ls_sql = "call pa_ins_um_maq_materiales_pack_detalle(" & txt_detalle_orden.Text & ",'" &
    '                                            gs_empresa & "'," & dgv_costo_equipo.Item("cod_material", index).Value & "," &
    '                                            dgv_costo_equipo.Item("cantidad", index).Value & "," & dgv_costo_equipo.Item("costo", index).Value & ",'" & gs_usuario & "')"

    '                MyTrans.Ingresa(ls_sql)
    '            End If

    '            index += 1
    '        Next

    '        index = 0
    '        For Each row As DataGridViewRow In dgv_materiales.Rows

    '            If (dgv_materiales.Item("cantidad", index).Value <> 0) Then
    '                ls_sql = "call pa_ins_um_maq_materiales_pack_detalle(" & txt_detalle_orden.Text & ",'" &
    '                                            gs_empresa & "'," & dgv_materiales.Item("cod_material", index).Value & "," &
    '                                            dgv_materiales.Item("cantidad", index).Value & "," & dgv_materiales.Item("costo", index).Value & ",'" & gs_usuario & "')"
    '                MyTrans.Ingresa(ls_sql)

    '            End If

    '            index += 1
    '        Next

    '        If MyTrans.Codigo_error > 0 Then MessageBox.Show("ERROR: " & MyTrans.descripcion_error)
    '        If MyTrans.Codigo_error = 0 Then MessageBox.Show("Costos guardados correctamente para la orden No. " & txt_detalle_orden.Text)

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR: " & MyTrans.descripcion_error & ", " & ex.Message)

    '    Finally
    '        MyTrans.close()
    '        MyTrans = Nothing

    '    End Try

    'End Function

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If MessageBox.Show("Esta seguro de guardar los costos para la orden " & txt_detalle_orden.Text & "?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Guardar_Cantidad_Materiales_Packs()
        End If

    End Sub

    Private Sub dgv_costo_primo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub dgv_costo_equipo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_costo_equipo.DataError
        MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub dgv_materiales_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub btn_productos_desarme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_productos_desarme.Click
        Dim frm_buscar_producto_desarme As New frm_buscar_producto_desarme
        frm_buscar_producto_desarme.ShowDialog()

        If (frm_buscar_producto_desarme.producto <> "") Then
            Dim dt As New DataTable
            Dim row As DataRow

            dt.Columns.Add("glosa")
            dt.Columns.Add("producto")

            row = dt.NewRow()
            row("glosa") = frm_buscar_producto_desarme.glosa
            row("producto") = frm_buscar_producto_desarme.producto

            dt.Rows.Add(row)

            cmb_op_pack.DataSource = dt
            cmb_op_pack.DisplayMember = "glosa"
            cmb_op_pack.ValueMember = "producto"
            cmb_op_pack.SelectedValue = frm_buscar_producto_desarme.producto

            dg_detalle_pack_op.DataSource = Nothing
            dg_op_pendientes.DataSource = Nothing
            dg_op_producto.DataSource = Nothing

        End If

    End Sub


    Private Sub tb_nuevo_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_nuevo_op.Click

    End Sub

    Private Sub txt_costo_unitario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_costo_unitario.TextChanged

    End Sub

    Private Sub tb_detalle_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_detalle_op.Click

    End Sub

    Private Sub dgv_costo_primo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_costo_primo.CellContentClick

    End Sub

    Private Sub txt_costo_base_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_costo_base.TextChanged

    End Sub

    Private Sub dg_lo_listado_ordenes_Navigate(sender As Object, ne As NavigateEventArgs) Handles dg_lo_listado_ordenes.Navigate

    End Sub
End Class
