Public Class frm_solicitud_productos
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbBU As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_barras As System.Windows.Forms.TextBox
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_solicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_solicitante As System.Windows.Forms.ComboBox
    Friend WithEvents txt_operado As System.Windows.Forms.TextBox
    Friend WithEvents dg_packs As System.Windows.Forms.DataGrid
    Friend WithEvents dg_listaprecios As System.Windows.Forms.DataGrid
    Friend WithEvents cmb_familia As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipo_producto As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_origen As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_procedencia As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_unidad_medida As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_dai As System.Windows.Forms.ComboBox
    Friend WithEvents dg_listado_solicitudes As System.Windows.Forms.DataGrid
    Friend WithEvents txt_precio_sugerido As System.Windows.Forms.TextBox
    Friend WithEvents txt_unidades_x_caja As System.Windows.Forms.TextBox
    Friend WithEvents txt_medida_litros As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_aprobar As System.Windows.Forms.Button
    Friend WithEvents btn_rechazar As System.Windows.Forms.Button
    Friend WithEvents group_detalle As System.Windows.Forms.GroupBox
    Friend WithEvents group_encabezado As System.Windows.Forms.GroupBox
    Friend WithEvents group_informacion As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_sub_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents group_listas As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_unidad_medida_alt As System.Windows.Forms.ComboBox
    Friend WithEvents gp_administracion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_familia As System.Windows.Forms.TextBox
    Friend WithEvents txt_dai As System.Windows.Forms.TextBox
    Friend WithEvents txt_unidad_medida_alt As System.Windows.Forms.TextBox
    Friend WithEvents txt_unidad_medida As System.Windows.Forms.TextBox
    Friend WithEvents txt_procedencia As System.Windows.Forms.TextBox
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_sub_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_marca As System.Windows.Forms.TextBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvAprobacionCambios As System.Windows.Forms.DataGridView
    Friend WithEvents btnAprobarCambio As System.Windows.Forms.Button
    Friend WithEvents btnRechazarCambio As System.Windows.Forms.Button
    Friend WithEvents btnRefrescarCambios As System.Windows.Forms.Button
    Friend WithEvents chkVerTodosCambios As System.Windows.Forms.CheckBox
    Friend WithEvents lblEstadoCambios As System.Windows.Forms.Label
    Friend WithEvents btnVerDetalleCambio As System.Windows.Forms.Button
    Friend WithEvents pnlDetCambio As System.Windows.Forms.GroupBox
    Friend WithEvents lblDetTitulo As System.Windows.Forms.Label
    Friend WithEvents lblDetNumero As System.Windows.Forms.Label
    Friend WithEvents lblDetEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblDetProducto As System.Windows.Forms.Label
    Friend WithEvents lblDetGlosa As System.Windows.Forms.Label
    Friend WithEvents lblDetTipoActual As System.Windows.Forms.Label
    Friend WithEvents lblDetTipoNuevo As System.Windows.Forms.Label
    Friend WithEvents lblDetPrecio As System.Windows.Forms.Label
    Friend WithEvents lblDetVolumen As System.Windows.Forms.Label
    Friend WithEvents lblDetMotivo As System.Windows.Forms.Label
    Friend WithEvents lblDetSolicitante As System.Windows.Forms.Label
    Friend WithEvents lblDetEstado As System.Windows.Forms.Label
    Friend WithEvents txtDetObs As System.Windows.Forms.TextBox
    Friend WithEvents btnDetAprobar As System.Windows.Forms.Button
    Friend WithEvents btnDetRechazar As System.Windows.Forms.Button
    Friend WithEvents btnDetCerrar As System.Windows.Forms.Button
    Friend WithEvents lblTitEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblTitProducto As System.Windows.Forms.Label
    Friend WithEvents lblTitGlosa As System.Windows.Forms.Label
    Friend WithEvents lblTitTipoActual As System.Windows.Forms.Label
    Friend WithEvents lblTitTipoNuevo As System.Windows.Forms.Label
    Friend WithEvents lblTitPrecio As System.Windows.Forms.Label
    Friend WithEvents lblTitVolumen As System.Windows.Forms.Label
    Friend WithEvents lblTitMotivo As System.Windows.Forms.Label
    Friend WithEvents lblTitSolicitante As System.Windows.Forms.Label
    Friend WithEvents lblTitFecha As System.Windows.Forms.Label
    Friend WithEvents lblDetFecha As System.Windows.Forms.Label
    Friend WithEvents lblTitEstado As System.Windows.Forms.Label
    Friend WithEvents lblTitAprobadoPor As System.Windows.Forms.Label
    Friend WithEvents lblDetAprobadoPor As System.Windows.Forms.Label
    Friend WithEvents txt_filtro As System.Windows.Forms.TextBox
    Friend WithEvents cb_condicion As System.Windows.Forms.ComboBox
    Friend WithEvents cb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents afecta_iva As System.Windows.Forms.CheckBox
    Friend WithEvents btn_anular As System.Windows.Forms.Button
    Friend WithEvents txtCodigoDistribuidora As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NombreCorto As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents chk_ver_todos As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvProductoSimilares As System.Windows.Forms.DataGridView
    Friend WithEvents lblPropuesta As Label
    Friend WithEvents utiliza_añada As ComboBox
    Friend WithEvents lbl_utiliza_añada As System.Windows.Forms.Label
    Friend WithEvents utiliza_lote As ComboBox
    Friend WithEvents lbl_utiliza_lote As System.Windows.Forms.Label
    Friend WithEvents cmb_tipo_proveedor As ComboBox
    Friend WithEvents lbl_tipo_proveedor As System.Windows.Forms.Label
    Friend WithEvents CatalogosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbCEPA As ComboBox
    Friend WithEvents lblCepa As Label
    Friend WithEvents txtCEPA As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkVinotecaHN As CheckBox
    Friend WithEvents chkDivinos As CheckBox
    Friend WithEvents chkVinoteca As CheckBox
    Friend WithEvents txt_tipo_producto As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_solicitud_productos))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProductoSimilares = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.group_listas = New System.Windows.Forms.GroupBox()
        Me.dg_listaprecios = New System.Windows.Forms.DataGrid()
        Me.dg_packs = New System.Windows.Forms.DataGrid()
        Me.group_encabezado = New System.Windows.Forms.GroupBox()
        Me.lblPropuesta = New System.Windows.Forms.Label()
        Me.btn_anular = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigoDistribuidora = New System.Windows.Forms.TextBox()
        Me.txt_codigo_barras = New System.Windows.Forms.TextBox()
        Me.txt_observaciones = New System.Windows.Forms.TextBox()
        Me.lbl_NombreCorto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gp_administracion = New System.Windows.Forms.GroupBox()
        Me.btn_aprobar = New System.Windows.Forms.Button()
        Me.btn_rechazar = New System.Windows.Forms.Button()
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.group_informacion = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.dtp_fecha_solicitud = New System.Windows.Forms.DateTimePicker()
        Me.cmb_estado = New System.Windows.Forms.ComboBox()
        Me.cmb_solicitante = New System.Windows.Forms.ComboBox()
        Me.txt_operado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbBU = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.group_detalle = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkVinotecaHN = New System.Windows.Forms.CheckBox()
        Me.chkDivinos = New System.Windows.Forms.CheckBox()
        Me.chkVinoteca = New System.Windows.Forms.CheckBox()
        Me.lblCepa = New System.Windows.Forms.Label()
        Me.txtCEPA = New System.Windows.Forms.TextBox()
        Me.cmbCEPA = New System.Windows.Forms.ComboBox()
        Me.utiliza_añada = New System.Windows.Forms.ComboBox()
        Me.lbl_utiliza_añada = New System.Windows.Forms.Label()
        Me.utiliza_lote = New System.Windows.Forms.ComboBox()
        Me.lbl_utiliza_lote = New System.Windows.Forms.Label()
        Me.cmb_tipo_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_tipo_proveedor = New System.Windows.Forms.Label()
        Me.afecta_iva = New System.Windows.Forms.CheckBox()
        Me.txt_precio_sugerido = New System.Windows.Forms.TextBox()
        Me.txt_unidades_x_caja = New System.Windows.Forms.TextBox()
        Me.txt_medida_litros = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_unidad_medida_alt = New System.Windows.Forms.TextBox()
        Me.txt_unidad_medida = New System.Windows.Forms.TextBox()
        Me.txt_procedencia = New System.Windows.Forms.TextBox()
        Me.txt_origen = New System.Windows.Forms.TextBox()
        Me.txt_sub_tipo = New System.Windows.Forms.TextBox()
        Me.txt_marca = New System.Windows.Forms.TextBox()
        Me.txt_proveedor = New System.Windows.Forms.TextBox()
        Me.txt_tipo_producto = New System.Windows.Forms.TextBox()
        Me.txt_familia = New System.Windows.Forms.TextBox()
        Me.cmb_unidad_medida_alt = New System.Windows.Forms.ComboBox()
        Me.cmb_sub_tipo = New System.Windows.Forms.ComboBox()
        Me.cmb_tipo_producto = New System.Windows.Forms.ComboBox()
        Me.cmb_marca = New System.Windows.Forms.ComboBox()
        Me.cmb_origen = New System.Windows.Forms.ComboBox()
        Me.cmb_procedencia = New System.Windows.Forms.ComboBox()
        Me.cmb_unidad_medida = New System.Windows.Forms.ComboBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.cmb_familia = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_dai = New System.Windows.Forms.TextBox()
        Me.cmb_dai = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chk_ver_todos = New System.Windows.Forms.CheckBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmb_operadores = New System.Windows.Forms.ComboBox()
        Me.cmb_campos_busqueda = New System.Windows.Forms.ComboBox()
        Me.txt_busqueda = New System.Windows.Forms.TextBox()
        Me.dg_listado_solicitudes = New System.Windows.Forms.DataGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgv_productos = New System.Windows.Forms.DataGridView()
        Me.txt_filtro = New System.Windows.Forms.TextBox()
        Me.cb_condicion = New System.Windows.Forms.ComboBox()
        Me.cb_campos = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvAprobacionCambios = New System.Windows.Forms.DataGridView()
        Me.chkVerTodosCambios = New System.Windows.Forms.CheckBox()
        Me.btnRefrescarCambios = New System.Windows.Forms.Button()
        Me.btnVerDetalleCambio = New System.Windows.Forms.Button()
        Me.btnAprobarCambio = New System.Windows.Forms.Button()
        Me.btnRechazarCambio = New System.Windows.Forms.Button()
        Me.lblEstadoCambios = New System.Windows.Forms.Label()
        Me.pnlDetCambio = New System.Windows.Forms.GroupBox()
        Me.lblDetTitulo = New System.Windows.Forms.Label()
        Me.lblDetNumero = New System.Windows.Forms.Label()
        Me.lblDetEmpresa = New System.Windows.Forms.Label()
        Me.lblDetProducto = New System.Windows.Forms.Label()
        Me.lblDetGlosa = New System.Windows.Forms.Label()
        Me.lblDetTipoActual = New System.Windows.Forms.Label()
        Me.lblDetTipoNuevo = New System.Windows.Forms.Label()
        Me.lblDetPrecio = New System.Windows.Forms.Label()
        Me.lblDetVolumen = New System.Windows.Forms.Label()
        Me.lblDetMotivo = New System.Windows.Forms.Label()
        Me.lblDetSolicitante = New System.Windows.Forms.Label()
        Me.lblDetEstado = New System.Windows.Forms.Label()
        Me.lblTitEmpresa = New System.Windows.Forms.Label()
        Me.lblTitProducto = New System.Windows.Forms.Label()
        Me.lblTitGlosa = New System.Windows.Forms.Label()
        Me.lblTitTipoActual = New System.Windows.Forms.Label()
        Me.lblTitTipoNuevo = New System.Windows.Forms.Label()
        Me.lblTitPrecio = New System.Windows.Forms.Label()
        Me.lblTitVolumen = New System.Windows.Forms.Label()
        Me.lblTitMotivo = New System.Windows.Forms.Label()
        Me.lblTitSolicitante = New System.Windows.Forms.Label()
        Me.lblTitFecha = New System.Windows.Forms.Label()
        Me.lblDetFecha = New System.Windows.Forms.Label()
        Me.lblTitEstado = New System.Windows.Forms.Label()
        Me.txtDetObs = New System.Windows.Forms.TextBox()
        Me.btnDetAprobar = New System.Windows.Forms.Button()
        Me.btnDetRechazar = New System.Windows.Forms.Button()
        Me.btnDetCerrar = New System.Windows.Forms.Button()
        Me.lblTitAprobadoPor = New System.Windows.Forms.Label()
        Me.lblDetAprobadoPor = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProductoSimilares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.group_listas.SuspendLayout()
        CType(Me.dg_listaprecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_packs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_encabezado.SuspendLayout()
        Me.gp_administracion.SuspendLayout()
        Me.group_informacion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.group_detalle.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_listado_solicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvAprobacionCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetCambio.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(894, 714)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.dgvProductoSimilares)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.group_listas)
        Me.TabPage1.Controls.Add(Me.group_encabezado)
        Me.TabPage1.Controls.Add(Me.gp_administracion)
        Me.TabPage1.Controls.Add(Me.group_informacion)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.group_detalle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(886, 687)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle de Solicitud"
        '
        'dgvProductoSimilares
        '
        Me.dgvProductoSimilares.AllowUserToAddRows = False
        Me.dgvProductoSimilares.AllowUserToDeleteRows = False
        Me.dgvProductoSimilares.ColumnHeadersHeight = 20
        Me.dgvProductoSimilares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductoSimilares.Location = New System.Drawing.Point(7, 558)
        Me.dgvProductoSimilares.Name = "dgvProductoSimilares"
        Me.dgvProductoSimilares.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProductoSimilares.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductoSimilares.Size = New System.Drawing.Size(869, 96)
        Me.dgvProductoSimilares.TabIndex = 7
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox4.Controls.Add(Me.btn_guardar)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir)
        Me.GroupBox4.Location = New System.Drawing.Point(779, -20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(100, 215)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(12, 75)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(76, 64)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "3.png")
        Me.ImageList1.Images.SetKeyName(1, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(2, "print_48.png")
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(12, 10)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(76, 64)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 2
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(12, 140)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(76, 64)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'group_listas
        '
        Me.group_listas.Controls.Add(Me.dg_listaprecios)
        Me.group_listas.Controls.Add(Me.dg_packs)
        Me.group_listas.Location = New System.Drawing.Point(0, 356)
        Me.group_listas.Name = "group_listas"
        Me.group_listas.Size = New System.Drawing.Size(879, 190)
        Me.group_listas.TabIndex = 4
        Me.group_listas.TabStop = False
        '
        'dg_listaprecios
        '
        Me.dg_listaprecios.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.dg_listaprecios.CaptionForeColor = System.Drawing.Color.White
        Me.dg_listaprecios.CaptionText = "Lista de Precios en las que estará el producto"
        Me.dg_listaprecios.DataMember = ""
        Me.dg_listaprecios.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_listaprecios.Location = New System.Drawing.Point(7, 11)
        Me.dg_listaprecios.Name = "dg_listaprecios"
        Me.dg_listaprecios.Size = New System.Drawing.Size(360, 176)
        Me.dg_listaprecios.TabIndex = 0
        '
        'dg_packs
        '
        Me.dg_packs.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.dg_packs.CaptionForeColor = System.Drawing.Color.White
        Me.dg_packs.CaptionText = "Productos que formaran el Pack"
        Me.dg_packs.DataMember = ""
        Me.dg_packs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_packs.Location = New System.Drawing.Point(384, 11)
        Me.dg_packs.Name = "dg_packs"
        Me.dg_packs.Size = New System.Drawing.Size(485, 176)
        Me.dg_packs.TabIndex = 1
        '
        'group_encabezado
        '
        Me.group_encabezado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.group_encabezado.Controls.Add(Me.lblPropuesta)
        Me.group_encabezado.Controls.Add(Me.btn_anular)
        Me.group_encabezado.Controls.Add(Me.txt_codigo_producto)
        Me.group_encabezado.Controls.Add(Me.Label1)
        Me.group_encabezado.Controls.Add(Me.txt_descripcion)
        Me.group_encabezado.Controls.Add(Me.txtCodigoDistribuidora)
        Me.group_encabezado.Controls.Add(Me.txt_codigo_barras)
        Me.group_encabezado.Controls.Add(Me.txt_observaciones)
        Me.group_encabezado.Controls.Add(Me.lbl_NombreCorto)
        Me.group_encabezado.Controls.Add(Me.Label2)
        Me.group_encabezado.Controls.Add(Me.Label3)
        Me.group_encabezado.Controls.Add(Me.Label4)
        Me.group_encabezado.Location = New System.Drawing.Point(367, 51)
        Me.group_encabezado.Name = "group_encabezado"
        Me.group_encabezado.Size = New System.Drawing.Size(400, 144)
        Me.group_encabezado.TabIndex = 2
        Me.group_encabezado.TabStop = False
        '
        'lblPropuesta
        '
        Me.lblPropuesta.AutoEllipsis = True
        Me.lblPropuesta.AutoSize = True
        Me.lblPropuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropuesta.Location = New System.Drawing.Point(192, 25)
        Me.lblPropuesta.Name = "lblPropuesta"
        Me.lblPropuesta.Size = New System.Drawing.Size(0, 13)
        Me.lblPropuesta.TabIndex = 2
        '
        'btn_anular
        '
        Me.btn_anular.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_anular.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_anular.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_anular.ForeColor = System.Drawing.Color.White
        Me.btn_anular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_anular.ImageIndex = 2
        Me.btn_anular.ImageList = Me.ImageList2
        Me.btn_anular.Location = New System.Drawing.Point(278, -5)
        Me.btn_anular.Name = "btn_anular"
        Me.btn_anular.Size = New System.Drawing.Size(116, 49)
        Me.btn_anular.TabIndex = 3
        Me.btn_anular.Text = "Anular"
        Me.btn_anular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_anular.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "aceptar.png")
        Me.ImageList2.Images.SetKeyName(1, "DeleteRed.png")
        Me.ImageList2.Images.SetKeyName(2, "running_process.png")
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(88, 22)
        Me.txt_codigo_producto.MaxLength = 10
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.Size = New System.Drawing.Size(90, 20)
        Me.txt_codigo_producto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Producto"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descripcion.Location = New System.Drawing.Point(88, 46)
        Me.txt_descripcion.MaxLength = 80
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(298, 20)
        Me.txt_descripcion.TabIndex = 3
        '
        'txtCodigoDistribuidora
        '
        Me.txtCodigoDistribuidora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoDistribuidora.Location = New System.Drawing.Point(250, 68)
        Me.txtCodigoDistribuidora.MaxLength = 15
        Me.txtCodigoDistribuidora.Name = "txtCodigoDistribuidora"
        Me.txtCodigoDistribuidora.Size = New System.Drawing.Size(132, 20)
        Me.txtCodigoDistribuidora.TabIndex = 5
        '
        'txt_codigo_barras
        '
        Me.txt_codigo_barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_barras.Location = New System.Drawing.Point(88, 70)
        Me.txt_codigo_barras.MaxLength = 13
        Me.txt_codigo_barras.Name = "txt_codigo_barras"
        Me.txt_codigo_barras.Size = New System.Drawing.Size(90, 20)
        Me.txt_codigo_barras.TabIndex = 5
        '
        'txt_observaciones
        '
        Me.txt_observaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_observaciones.Location = New System.Drawing.Point(96, 94)
        Me.txt_observaciones.Multiline = True
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_observaciones.Size = New System.Drawing.Size(298, 38)
        Me.txt_observaciones.TabIndex = 9
        '
        'lbl_NombreCorto
        '
        Me.lbl_NombreCorto.AutoSize = True
        Me.lbl_NombreCorto.Location = New System.Drawing.Point(180, 73)
        Me.lbl_NombreCorto.Name = "lbl_NombreCorto"
        Me.lbl_NombreCorto.Size = New System.Drawing.Size(75, 14)
        Me.lbl_NombreCorto.TabIndex = 2
        Me.lbl_NombreCorto.Text = "Codigo Origen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo Barras"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Observaciones"
        '
        'gp_administracion
        '
        Me.gp_administracion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gp_administracion.Controls.Add(Me.btn_aprobar)
        Me.gp_administracion.Controls.Add(Me.btn_rechazar)
        Me.gp_administracion.Controls.Add(Me.btn_procesar)
        Me.gp_administracion.Location = New System.Drawing.Point(391, -19)
        Me.gp_administracion.Name = "gp_administracion"
        Me.gp_administracion.Size = New System.Drawing.Size(380, 74)
        Me.gp_administracion.TabIndex = 6
        Me.gp_administracion.TabStop = False
        '
        'btn_aprobar
        '
        Me.btn_aprobar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_aprobar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_aprobar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aprobar.ForeColor = System.Drawing.Color.White
        Me.btn_aprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aprobar.ImageIndex = 0
        Me.btn_aprobar.ImageList = Me.ImageList2
        Me.btn_aprobar.Location = New System.Drawing.Point(10, 15)
        Me.btn_aprobar.Name = "btn_aprobar"
        Me.btn_aprobar.Size = New System.Drawing.Size(116, 49)
        Me.btn_aprobar.TabIndex = 0
        Me.btn_aprobar.Text = "Aprobar"
        Me.btn_aprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aprobar.UseVisualStyleBackColor = False
        '
        'btn_rechazar
        '
        Me.btn_rechazar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_rechazar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_rechazar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_rechazar.ForeColor = System.Drawing.Color.White
        Me.btn_rechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_rechazar.ImageIndex = 1
        Me.btn_rechazar.ImageList = Me.ImageList2
        Me.btn_rechazar.Location = New System.Drawing.Point(132, 15)
        Me.btn_rechazar.Name = "btn_rechazar"
        Me.btn_rechazar.Size = New System.Drawing.Size(116, 49)
        Me.btn_rechazar.TabIndex = 1
        Me.btn_rechazar.Text = "Rechazar"
        Me.btn_rechazar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_rechazar.UseVisualStyleBackColor = False
        '
        'btn_procesar
        '
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_procesar.ImageIndex = 2
        Me.btn_procesar.ImageList = Me.ImageList2
        Me.btn_procesar.Location = New System.Drawing.Point(254, 15)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(116, 49)
        Me.btn_procesar.TabIndex = 2
        Me.btn_procesar.Text = "Procesar"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_procesar.UseVisualStyleBackColor = False
        Me.btn_procesar.Visible = False
        '
        'group_informacion
        '
        Me.group_informacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.group_informacion.Controls.Add(Me.GroupBox2)
        Me.group_informacion.Controls.Add(Me.dtp_fecha_solicitud)
        Me.group_informacion.Controls.Add(Me.cmb_estado)
        Me.group_informacion.Controls.Add(Me.cmb_solicitante)
        Me.group_informacion.Controls.Add(Me.txt_operado)
        Me.group_informacion.Controls.Add(Me.Label6)
        Me.group_informacion.Controls.Add(Me.Label7)
        Me.group_informacion.Controls.Add(Me.Label8)
        Me.group_informacion.Controls.Add(Me.Label9)
        Me.group_informacion.Location = New System.Drawing.Point(7, -9)
        Me.group_informacion.Name = "group_informacion"
        Me.group_informacion.Size = New System.Drawing.Size(352, 141)
        Me.group_informacion.TabIndex = 1
        Me.group_informacion.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lbl_numero)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(128, 34)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoEllipsis = True
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Numero"
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_numero.ForeColor = System.Drawing.Color.Red
        Me.lbl_numero.Location = New System.Drawing.Point(63, 18)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(50, 13)
        Me.lbl_numero.TabIndex = 1
        Me.lbl_numero.Text = "Numero"
        Me.lbl_numero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp_fecha_solicitud
        '
        Me.dtp_fecha_solicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_solicitud.Location = New System.Drawing.Point(72, 24)
        Me.dtp_fecha_solicitud.Name = "dtp_fecha_solicitud"
        Me.dtp_fecha_solicitud.Size = New System.Drawing.Size(80, 20)
        Me.dtp_fecha_solicitud.TabIndex = 1
        '
        'cmb_estado
        '
        Me.cmb_estado.Enabled = False
        Me.cmb_estado.Location = New System.Drawing.Point(72, 52)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(272, 22)
        Me.cmb_estado.TabIndex = 3
        '
        'cmb_solicitante
        '
        Me.cmb_solicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_solicitante.DropDownWidth = 350
        Me.cmb_solicitante.Location = New System.Drawing.Point(72, 82)
        Me.cmb_solicitante.Name = "cmb_solicitante"
        Me.cmb_solicitante.Size = New System.Drawing.Size(272, 22)
        Me.cmb_solicitante.TabIndex = 5
        '
        'txt_operado
        '
        Me.txt_operado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_operado.Enabled = False
        Me.txt_operado.Location = New System.Drawing.Point(72, 112)
        Me.txt_operado.Name = "txt_operado"
        Me.txt_operado.Size = New System.Drawing.Size(269, 20)
        Me.txt_operado.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Estado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Solicitante"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 14)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Opero"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.cmbBU)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbBU
        '
        Me.cmbBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBU.Enabled = False
        Me.cmbBU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBU.Items.AddRange(New Object() {"Alta"})
        Me.cmbBU.Location = New System.Drawing.Point(116, 24)
        Me.cmbBU.Name = "cmbBU"
        Me.cmbBU.Size = New System.Drawing.Size(121, 23)
        Me.cmbBU.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(9, 30)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 14)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Unidad de Negocio"
        '
        'group_detalle
        '
        Me.group_detalle.Controls.Add(Me.GroupBox3)
        Me.group_detalle.Controls.Add(Me.lblCepa)
        Me.group_detalle.Controls.Add(Me.txtCEPA)
        Me.group_detalle.Controls.Add(Me.cmbCEPA)
        Me.group_detalle.Controls.Add(Me.utiliza_añada)
        Me.group_detalle.Controls.Add(Me.lbl_utiliza_añada)
        Me.group_detalle.Controls.Add(Me.utiliza_lote)
        Me.group_detalle.Controls.Add(Me.lbl_utiliza_lote)
        Me.group_detalle.Controls.Add(Me.cmb_tipo_proveedor)
        Me.group_detalle.Controls.Add(Me.lbl_tipo_proveedor)
        Me.group_detalle.Controls.Add(Me.afecta_iva)
        Me.group_detalle.Controls.Add(Me.txt_precio_sugerido)
        Me.group_detalle.Controls.Add(Me.txt_unidades_x_caja)
        Me.group_detalle.Controls.Add(Me.txt_medida_litros)
        Me.group_detalle.Controls.Add(Me.Label19)
        Me.group_detalle.Controls.Add(Me.Label17)
        Me.group_detalle.Controls.Add(Me.Label21)
        Me.group_detalle.Controls.Add(Me.Label25)
        Me.group_detalle.Controls.Add(Me.Label16)
        Me.group_detalle.Controls.Add(Me.Label23)
        Me.group_detalle.Controls.Add(Me.Label26)
        Me.group_detalle.Controls.Add(Me.Label20)
        Me.group_detalle.Controls.Add(Me.Label13)
        Me.group_detalle.Controls.Add(Me.Label14)
        Me.group_detalle.Controls.Add(Me.Label12)
        Me.group_detalle.Controls.Add(Me.Label11)
        Me.group_detalle.Controls.Add(Me.txt_unidad_medida_alt)
        Me.group_detalle.Controls.Add(Me.txt_unidad_medida)
        Me.group_detalle.Controls.Add(Me.txt_procedencia)
        Me.group_detalle.Controls.Add(Me.txt_origen)
        Me.group_detalle.Controls.Add(Me.txt_sub_tipo)
        Me.group_detalle.Controls.Add(Me.txt_marca)
        Me.group_detalle.Controls.Add(Me.txt_proveedor)
        Me.group_detalle.Controls.Add(Me.txt_tipo_producto)
        Me.group_detalle.Controls.Add(Me.txt_familia)
        Me.group_detalle.Controls.Add(Me.cmb_unidad_medida_alt)
        Me.group_detalle.Controls.Add(Me.cmb_sub_tipo)
        Me.group_detalle.Controls.Add(Me.cmb_tipo_producto)
        Me.group_detalle.Controls.Add(Me.cmb_marca)
        Me.group_detalle.Controls.Add(Me.cmb_origen)
        Me.group_detalle.Controls.Add(Me.cmb_procedencia)
        Me.group_detalle.Controls.Add(Me.cmb_unidad_medida)
        Me.group_detalle.Controls.Add(Me.cmb_proveedor)
        Me.group_detalle.Controls.Add(Me.cmb_familia)
        Me.group_detalle.Controls.Add(Me.Label15)
        Me.group_detalle.Controls.Add(Me.txt_dai)
        Me.group_detalle.Controls.Add(Me.cmb_dai)
        Me.group_detalle.Location = New System.Drawing.Point(7, 208)
        Me.group_detalle.Name = "group_detalle"
        Me.group_detalle.Size = New System.Drawing.Size(950, 153)
        Me.group_detalle.TabIndex = 3
        Me.group_detalle.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkVinotecaHN)
        Me.GroupBox3.Controls.Add(Me.chkDivinos)
        Me.GroupBox3.Controls.Add(Me.chkVinoteca)
        Me.GroupBox3.Location = New System.Drawing.Point(671, 101)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 52)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aplicar En"
        Me.GroupBox3.Visible = False
        '
        'chkVinotecaHN
        '
        Me.chkVinotecaHN.AutoSize = True
        Me.chkVinotecaHN.Location = New System.Drawing.Point(18, 32)
        Me.chkVinotecaHN.Name = "chkVinotecaHN"
        Me.chkVinotecaHN.Size = New System.Drawing.Size(86, 18)
        Me.chkVinotecaHN.TabIndex = 49
        Me.chkVinotecaHN.Text = "Vinoteca HN"
        Me.chkVinotecaHN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVinotecaHN.UseVisualStyleBackColor = True
        '
        'chkDivinos
        '
        Me.chkDivinos.AutoSize = True
        Me.chkDivinos.Location = New System.Drawing.Point(113, 15)
        Me.chkDivinos.Name = "chkDivinos"
        Me.chkDivinos.Size = New System.Drawing.Size(61, 18)
        Me.chkDivinos.TabIndex = 48
        Me.chkDivinos.Text = "Divinos"
        Me.chkDivinos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDivinos.UseVisualStyleBackColor = True
        '
        'chkVinoteca
        '
        Me.chkVinoteca.AutoSize = True
        Me.chkVinoteca.Location = New System.Drawing.Point(18, 15)
        Me.chkVinoteca.Name = "chkVinoteca"
        Me.chkVinoteca.Size = New System.Drawing.Size(69, 18)
        Me.chkVinoteca.TabIndex = 47
        Me.chkVinoteca.Text = "Vinoteca"
        Me.chkVinoteca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVinoteca.UseVisualStyleBackColor = True
        '
        'lblCepa
        '
        Me.lblCepa.AutoSize = True
        Me.lblCepa.Location = New System.Drawing.Point(432, 103)
        Me.lblCepa.Name = "lblCepa"
        Me.lblCepa.Size = New System.Drawing.Size(60, 14)
        Me.lblCepa.TabIndex = 43
        Me.lblCepa.Text = "Cepa Estilo"
        Me.lblCepa.Visible = False
        '
        'txtCEPA
        '
        Me.txtCEPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCEPA.Location = New System.Drawing.Point(498, 102)
        Me.txtCEPA.Name = "txtCEPA"
        Me.txtCEPA.Size = New System.Drawing.Size(112, 20)
        Me.txtCEPA.TabIndex = 44
        Me.txtCEPA.Visible = False
        '
        'cmbCEPA
        '
        Me.cmbCEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEPA.DropDownWidth = 150
        Me.cmbCEPA.Location = New System.Drawing.Point(498, 101)
        Me.cmbCEPA.Name = "cmbCEPA"
        Me.cmbCEPA.Size = New System.Drawing.Size(112, 22)
        Me.cmbCEPA.TabIndex = 45
        Me.cmbCEPA.TabStop = False
        Me.cmbCEPA.Visible = False
        '
        'utiliza_añada
        '
        Me.utiliza_añada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.utiliza_añada.FormattingEnabled = True
        Me.utiliza_añada.Items.AddRange(New Object() {"SI", "NO"})
        Me.utiliza_añada.Location = New System.Drawing.Point(820, 73)
        Me.utiliza_añada.Name = "utiliza_añada"
        Me.utiliza_añada.Size = New System.Drawing.Size(45, 22)
        Me.utiliza_añada.TabIndex = 42
        '
        'lbl_utiliza_añada
        '
        Me.lbl_utiliza_añada.AutoSize = True
        Me.lbl_utiliza_añada.Location = New System.Drawing.Point(685, 77)
        Me.lbl_utiliza_añada.Name = "lbl_utiliza_añada"
        Me.lbl_utiliza_añada.Size = New System.Drawing.Size(121, 14)
        Me.lbl_utiliza_añada.TabIndex = 47
        Me.lbl_utiliza_añada.Text = "Producto Utiliza AÑADA"
        '
        'utiliza_lote
        '
        Me.utiliza_lote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.utiliza_lote.FormattingEnabled = True
        Me.utiliza_lote.Items.AddRange(New Object() {"SI", "NO"})
        Me.utiliza_lote.Location = New System.Drawing.Point(820, 49)
        Me.utiliza_lote.Name = "utiliza_lote"
        Me.utiliza_lote.Size = New System.Drawing.Size(45, 22)
        Me.utiliza_lote.TabIndex = 41
        '
        'lbl_utiliza_lote
        '
        Me.lbl_utiliza_lote.AutoSize = True
        Me.lbl_utiliza_lote.Location = New System.Drawing.Point(685, 53)
        Me.lbl_utiliza_lote.Name = "lbl_utiliza_lote"
        Me.lbl_utiliza_lote.Size = New System.Drawing.Size(109, 14)
        Me.lbl_utiliza_lote.TabIndex = 48
        Me.lbl_utiliza_lote.Text = "Producto utiliza LOTE"
        '
        'cmb_tipo_proveedor
        '
        Me.cmb_tipo_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_proveedor.FormattingEnabled = True
        Me.cmb_tipo_proveedor.Items.AddRange(New Object() {"LOCAL", "INTERNACIONAL"})
        Me.cmb_tipo_proveedor.Location = New System.Drawing.Point(750, 97)
        Me.cmb_tipo_proveedor.Name = "cmb_tipo_proveedor"
        Me.cmb_tipo_proveedor.Size = New System.Drawing.Size(130, 22)
        Me.cmb_tipo_proveedor.TabIndex = 43
        '
        'lbl_tipo_proveedor
        '
        Me.lbl_tipo_proveedor.AutoSize = True
        Me.lbl_tipo_proveedor.Location = New System.Drawing.Point(635, 101)
        Me.lbl_tipo_proveedor.Name = "lbl_tipo_proveedor"
        Me.lbl_tipo_proveedor.Size = New System.Drawing.Size(95, 14)
        Me.lbl_tipo_proveedor.TabIndex = 49
        Me.lbl_tipo_proveedor.Text = "Tipo de Proveedor"
        '
        'afecta_iva
        '
        Me.afecta_iva.AutoSize = True
        Me.afecta_iva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.afecta_iva.Location = New System.Drawing.Point(710, 26)
        Me.afecta_iva.Name = "afecta_iva"
        Me.afecta_iva.Size = New System.Drawing.Size(154, 18)
        Me.afecta_iva.TabIndex = 40
        Me.afecta_iva.Text = "Producto afectado por IVA"
        Me.afecta_iva.UseVisualStyleBackColor = True
        '
        'txt_precio_sugerido
        '
        Me.txt_precio_sugerido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_sugerido.Location = New System.Drawing.Point(555, 73)
        Me.txt_precio_sugerido.Name = "txt_precio_sugerido"
        Me.txt_precio_sugerido.Size = New System.Drawing.Size(112, 20)
        Me.txt_precio_sugerido.TabIndex = 37
        Me.txt_precio_sugerido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_unidades_x_caja
        '
        Me.txt_unidades_x_caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidades_x_caja.Location = New System.Drawing.Point(314, 128)
        Me.txt_unidades_x_caja.Name = "txt_unidades_x_caja"
        Me.txt_unidades_x_caja.Size = New System.Drawing.Size(112, 20)
        Me.txt_unidades_x_caja.TabIndex = 28
        Me.txt_unidades_x_caja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_medida_litros
        '
        Me.txt_medida_litros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_medida_litros.Location = New System.Drawing.Point(555, 23)
        Me.txt_medida_litros.Name = "txt_medida_litros"
        Me.txt_medida_litros.Size = New System.Drawing.Size(112, 20)
        Me.txt_medida_litros.TabIndex = 32
        Me.txt_medida_litros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(427, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 14)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Medida (Litros)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(228, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 14)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Unidades x Caja"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(427, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 14)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "Precio Sugerido"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 129)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 14)
        Me.Label25.TabIndex = 12
        Me.Label25.Text = "Sub Tipo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(231, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 14)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Procedencia"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(231, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 14)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Origen"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(228, 103)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 14)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Unidad Alt."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(427, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 14)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "% Dai"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 14)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Tipo Producto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 14)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Marca"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 14)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Proveedor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 14)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Familia"
        '
        'txt_unidad_medida_alt
        '
        Me.txt_unidad_medida_alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidad_medida_alt.Location = New System.Drawing.Point(314, 102)
        Me.txt_unidad_medida_alt.Name = "txt_unidad_medida_alt"
        Me.txt_unidad_medida_alt.Size = New System.Drawing.Size(112, 20)
        Me.txt_unidad_medida_alt.TabIndex = 25
        '
        'txt_unidad_medida
        '
        Me.txt_unidad_medida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidad_medida.Location = New System.Drawing.Point(314, 73)
        Me.txt_unidad_medida.Name = "txt_unidad_medida"
        Me.txt_unidad_medida.Size = New System.Drawing.Size(112, 20)
        Me.txt_unidad_medida.TabIndex = 22
        '
        'txt_procedencia
        '
        Me.txt_procedencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_procedencia.Location = New System.Drawing.Point(314, 46)
        Me.txt_procedencia.Name = "txt_procedencia"
        Me.txt_procedencia.Size = New System.Drawing.Size(112, 20)
        Me.txt_procedencia.TabIndex = 19
        '
        'txt_origen
        '
        Me.txt_origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_origen.Location = New System.Drawing.Point(314, 21)
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.Size = New System.Drawing.Size(112, 20)
        Me.txt_origen.TabIndex = 16
        '
        'txt_sub_tipo
        '
        Me.txt_sub_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sub_tipo.Location = New System.Drawing.Point(88, 127)
        Me.txt_sub_tipo.Name = "txt_sub_tipo"
        Me.txt_sub_tipo.Size = New System.Drawing.Size(136, 20)
        Me.txt_sub_tipo.TabIndex = 13
        '
        'txt_marca
        '
        Me.txt_marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_marca.Location = New System.Drawing.Point(88, 101)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.Size = New System.Drawing.Size(136, 20)
        Me.txt_marca.TabIndex = 10
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proveedor.Location = New System.Drawing.Point(88, 73)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.Size = New System.Drawing.Size(136, 20)
        Me.txt_proveedor.TabIndex = 7
        '
        'txt_tipo_producto
        '
        Me.txt_tipo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_producto.Location = New System.Drawing.Point(88, 45)
        Me.txt_tipo_producto.Name = "txt_tipo_producto"
        Me.txt_tipo_producto.Size = New System.Drawing.Size(136, 20)
        Me.txt_tipo_producto.TabIndex = 4
        '
        'txt_familia
        '
        Me.txt_familia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_familia.Location = New System.Drawing.Point(88, 17)
        Me.txt_familia.Name = "txt_familia"
        Me.txt_familia.Size = New System.Drawing.Size(136, 20)
        Me.txt_familia.TabIndex = 1
        '
        'cmb_unidad_medida_alt
        '
        Me.cmb_unidad_medida_alt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_unidad_medida_alt.Location = New System.Drawing.Point(312, 101)
        Me.cmb_unidad_medida_alt.Name = "cmb_unidad_medida_alt"
        Me.cmb_unidad_medida_alt.Size = New System.Drawing.Size(112, 22)
        Me.cmb_unidad_medida_alt.TabIndex = 26
        Me.cmb_unidad_medida_alt.TabStop = False
        '
        'cmb_sub_tipo
        '
        Me.cmb_sub_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sub_tipo.DropDownWidth = 150
        Me.cmb_sub_tipo.Location = New System.Drawing.Point(88, 125)
        Me.cmb_sub_tipo.Name = "cmb_sub_tipo"
        Me.cmb_sub_tipo.Size = New System.Drawing.Size(136, 22)
        Me.cmb_sub_tipo.TabIndex = 14
        Me.cmb_sub_tipo.TabStop = False
        '
        'cmb_tipo_producto
        '
        Me.cmb_tipo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_producto.DropDownWidth = 150
        Me.cmb_tipo_producto.Location = New System.Drawing.Point(88, 44)
        Me.cmb_tipo_producto.Name = "cmb_tipo_producto"
        Me.cmb_tipo_producto.Size = New System.Drawing.Size(136, 22)
        Me.cmb_tipo_producto.TabIndex = 5
        Me.cmb_tipo_producto.TabStop = False
        '
        'cmb_marca
        '
        Me.cmb_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_marca.DropDownWidth = 150
        Me.cmb_marca.Location = New System.Drawing.Point(88, 100)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(136, 22)
        Me.cmb_marca.TabIndex = 11
        Me.cmb_marca.TabStop = False
        '
        'cmb_origen
        '
        Me.cmb_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_origen.DropDownWidth = 150
        Me.cmb_origen.Location = New System.Drawing.Point(312, 19)
        Me.cmb_origen.Name = "cmb_origen"
        Me.cmb_origen.Size = New System.Drawing.Size(114, 22)
        Me.cmb_origen.TabIndex = 17
        Me.cmb_origen.TabStop = False
        '
        'cmb_procedencia
        '
        Me.cmb_procedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_procedencia.DropDownWidth = 150
        Me.cmb_procedencia.Location = New System.Drawing.Point(314, 45)
        Me.cmb_procedencia.Name = "cmb_procedencia"
        Me.cmb_procedencia.Size = New System.Drawing.Size(112, 22)
        Me.cmb_procedencia.TabIndex = 20
        Me.cmb_procedencia.TabStop = False
        '
        'cmb_unidad_medida
        '
        Me.cmb_unidad_medida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_unidad_medida.Location = New System.Drawing.Point(312, 72)
        Me.cmb_unidad_medida.Name = "cmb_unidad_medida"
        Me.cmb_unidad_medida.Size = New System.Drawing.Size(114, 22)
        Me.cmb_unidad_medida.TabIndex = 23
        Me.cmb_unidad_medida.TabStop = False
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.DropDownWidth = 150
        Me.cmb_proveedor.Location = New System.Drawing.Point(88, 72)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(136, 22)
        Me.cmb_proveedor.TabIndex = 8
        Me.cmb_proveedor.TabStop = False
        '
        'cmb_familia
        '
        Me.cmb_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_familia.DropDownWidth = 150
        Me.cmb_familia.Location = New System.Drawing.Point(88, 16)
        Me.cmb_familia.Name = "cmb_familia"
        Me.cmb_familia.Size = New System.Drawing.Size(136, 22)
        Me.cmb_familia.TabIndex = 2
        Me.cmb_familia.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(229, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 14)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Uni. de Medida"
        '
        'txt_dai
        '
        Me.txt_dai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dai.Location = New System.Drawing.Point(555, 46)
        Me.txt_dai.Name = "txt_dai"
        Me.txt_dai.Size = New System.Drawing.Size(112, 20)
        Me.txt_dai.TabIndex = 34
        '
        'cmb_dai
        '
        Me.cmb_dai.DropDownHeight = 120
        Me.cmb_dai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_dai.DropDownWidth = 150
        Me.cmb_dai.IntegralHeight = False
        Me.cmb_dai.Location = New System.Drawing.Point(555, 45)
        Me.cmb_dai.Name = "cmb_dai"
        Me.cmb_dai.Size = New System.Drawing.Size(112, 22)
        Me.cmb_dai.TabIndex = 35
        Me.cmb_dai.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.chk_ver_todos)
        Me.TabPage2.Controls.Add(Me.btn_buscar)
        Me.TabPage2.Controls.Add(Me.cmb_operadores)
        Me.TabPage2.Controls.Add(Me.cmb_campos_busqueda)
        Me.TabPage2.Controls.Add(Me.txt_busqueda)
        Me.TabPage2.Controls.Add(Me.dg_listado_solicitudes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(886, 688)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado de Solicitudes"
        '
        'chk_ver_todos
        '
        Me.chk_ver_todos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chk_ver_todos.Location = New System.Drawing.Point(692, 13)
        Me.chk_ver_todos.Name = "chk_ver_todos"
        Me.chk_ver_todos.Size = New System.Drawing.Size(80, 16)
        Me.chk_ver_todos.TabIndex = 9
        Me.chk_ver_todos.Text = "Ver Todos"
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 0
        Me.btn_buscar.ImageList = Me.ImageList3
        Me.btn_buscar.Location = New System.Drawing.Point(584, 12)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 23)
        Me.btn_buscar.TabIndex = 8
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "search.ico")
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(102, 12)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(46, 22)
        Me.cmb_operadores.TabIndex = 7
        '
        'cmb_campos_busqueda
        '
        Me.cmb_campos_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos_busqueda.Items.AddRange(New Object() {"Numero", "Fecha", "des_estado", "Solicitante", "Actividad"})
        Me.cmb_campos_busqueda.Location = New System.Drawing.Point(8, 12)
        Me.cmb_campos_busqueda.Name = "cmb_campos_busqueda"
        Me.cmb_campos_busqueda.Size = New System.Drawing.Size(88, 22)
        Me.cmb_campos_busqueda.TabIndex = 6
        '
        'txt_busqueda
        '
        Me.txt_busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_busqueda.Location = New System.Drawing.Point(154, 12)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(424, 20)
        Me.txt_busqueda.TabIndex = 5
        '
        'dg_listado_solicitudes
        '
        Me.dg_listado_solicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado_solicitudes.CaptionVisible = False
        Me.dg_listado_solicitudes.DataMember = ""
        Me.dg_listado_solicitudes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_listado_solicitudes.Location = New System.Drawing.Point(8, 40)
        Me.dg_listado_solicitudes.Name = "dg_listado_solicitudes"
        Me.dg_listado_solicitudes.ReadOnly = True
        Me.dg_listado_solicitudes.Size = New System.Drawing.Size(872, 610)
        Me.dg_listado_solicitudes.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.dgv_productos)
        Me.TabPage3.Controls.Add(Me.txt_filtro)
        Me.TabPage3.Controls.Add(Me.cb_condicion)
        Me.TabPage3.Controls.Add(Me.cb_campos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(886, 688)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Productos Existentes"
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
        Me.dgv_productos.Location = New System.Drawing.Point(8, 43)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.ReadOnly = True
        Me.dgv_productos.RowHeadersWidth = 25
        Me.dgv_productos.Size = New System.Drawing.Size(872, 617)
        Me.dgv_productos.TabIndex = 5
        '
        'txt_filtro
        '
        Me.txt_filtro.Location = New System.Drawing.Point(207, 7)
        Me.txt_filtro.Name = "txt_filtro"
        Me.txt_filtro.Size = New System.Drawing.Size(303, 20)
        Me.txt_filtro.TabIndex = 4
        '
        'cb_condicion
        '
        Me.cb_condicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_condicion.FormattingEnabled = True
        Me.cb_condicion.Items.AddRange(New Object() {"<", "=", ">", "<>", "like"})
        Me.cb_condicion.Location = New System.Drawing.Point(135, 6)
        Me.cb_condicion.Name = "cb_condicion"
        Me.cb_condicion.Size = New System.Drawing.Size(66, 22)
        Me.cb_condicion.TabIndex = 3
        '
        'cb_campos
        '
        Me.cb_campos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_campos.FormattingEnabled = True
        Me.cb_campos.Items.AddRange(New Object() {"Producto", "Glosa", "Familia", "TipoProducto", "proveedor", "marca"})
        Me.cb_campos.Location = New System.Drawing.Point(8, 6)
        Me.cb_campos.Name = "cb_campos"
        Me.cb_campos.Size = New System.Drawing.Size(121, 22)
        Me.cb_campos.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.dgvAprobacionCambios)
        Me.TabPage4.Controls.Add(Me.chkVerTodosCambios)
        Me.TabPage4.Controls.Add(Me.btnRefrescarCambios)
        Me.TabPage4.Controls.Add(Me.btnVerDetalleCambio)
        Me.TabPage4.Controls.Add(Me.btnAprobarCambio)
        Me.TabPage4.Controls.Add(Me.btnRechazarCambio)
        Me.TabPage4.Controls.Add(Me.lblEstadoCambios)
        Me.TabPage4.Controls.Add(Me.pnlDetCambio)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(886, 688)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Listado de Solicitudes por Modificación"
        '
        'dgvAprobacionCambios
        '
        Me.dgvAprobacionCambios.AllowUserToAddRows = False
        Me.dgvAprobacionCambios.AllowUserToDeleteRows = False
        Me.dgvAprobacionCambios.Location = New System.Drawing.Point(10, 45)
        Me.dgvAprobacionCambios.MultiSelect = False
        Me.dgvAprobacionCambios.Name = "dgvAprobacionCambios"
        Me.dgvAprobacionCambios.RowHeadersVisible = False
        Me.dgvAprobacionCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAprobacionCambios.Size = New System.Drawing.Size(866, 280)
        Me.dgvAprobacionCambios.TabIndex = 0
        '
        'chkVerTodosCambios
        '
        Me.chkVerTodosCambios.AutoSize = True
        Me.chkVerTodosCambios.Location = New System.Drawing.Point(15, 15)
        Me.chkVerTodosCambios.Name = "chkVerTodosCambios"
        Me.chkVerTodosCambios.Size = New System.Drawing.Size(237, 18)
        Me.chkVerTodosCambios.TabIndex = 1
        Me.chkVerTodosCambios.Text = "Ver todos (incluir aprobados y rechazados)"
        '
        'btnRefrescarCambios
        '
        Me.btnRefrescarCambios.Location = New System.Drawing.Point(380, 10)
        Me.btnRefrescarCambios.Name = "btnRefrescarCambios"
        Me.btnRefrescarCambios.Size = New System.Drawing.Size(100, 25)
        Me.btnRefrescarCambios.TabIndex = 2
        Me.btnRefrescarCambios.Text = "Refrescar"
        '
        'btnVerDetalleCambio
        '
        Me.btnVerDetalleCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnVerDetalleCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalleCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnVerDetalleCambio.ForeColor = System.Drawing.Color.White
        Me.btnVerDetalleCambio.Location = New System.Drawing.Point(490, 10)
        Me.btnVerDetalleCambio.Name = "btnVerDetalleCambio"
        Me.btnVerDetalleCambio.Size = New System.Drawing.Size(130, 25)
        Me.btnVerDetalleCambio.TabIndex = 3
        Me.btnVerDetalleCambio.Text = "Ver / Aprobar Detalle"
        Me.btnVerDetalleCambio.UseVisualStyleBackColor = False
        '
        'btnAprobarCambio
        '
        Me.btnAprobarCambio.Location = New System.Drawing.Point(0, 0)
        Me.btnAprobarCambio.Name = "btnAprobarCambio"
        Me.btnAprobarCambio.Size = New System.Drawing.Size(75, 23)
        Me.btnAprobarCambio.TabIndex = 4
        Me.btnAprobarCambio.Visible = False
        '
        'btnRechazarCambio
        '
        Me.btnRechazarCambio.Location = New System.Drawing.Point(0, 0)
        Me.btnRechazarCambio.Name = "btnRechazarCambio"
        Me.btnRechazarCambio.Size = New System.Drawing.Size(75, 23)
        Me.btnRechazarCambio.TabIndex = 5
        Me.btnRechazarCambio.Visible = False
        '
        'lblEstadoCambios
        '
        Me.lblEstadoCambios.AutoSize = True
        Me.lblEstadoCambios.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblEstadoCambios.Location = New System.Drawing.Point(15, 668)
        Me.lblEstadoCambios.Name = "lblEstadoCambios"
        Me.lblEstadoCambios.Size = New System.Drawing.Size(0, 14)
        Me.lblEstadoCambios.TabIndex = 6
        '
        'pnlDetCambio
        '
        Me.pnlDetCambio.Controls.Add(Me.lblDetTitulo)
        Me.pnlDetCambio.Controls.Add(Me.lblDetNumero)
        Me.pnlDetCambio.Controls.Add(Me.lblDetEmpresa)
        Me.pnlDetCambio.Controls.Add(Me.lblDetProducto)
        Me.pnlDetCambio.Controls.Add(Me.lblDetGlosa)
        Me.pnlDetCambio.Controls.Add(Me.lblDetTipoActual)
        Me.pnlDetCambio.Controls.Add(Me.lblDetTipoNuevo)
        Me.pnlDetCambio.Controls.Add(Me.lblDetPrecio)
        Me.pnlDetCambio.Controls.Add(Me.lblDetVolumen)
        Me.pnlDetCambio.Controls.Add(Me.lblDetMotivo)
        Me.pnlDetCambio.Controls.Add(Me.lblDetSolicitante)
        Me.pnlDetCambio.Controls.Add(Me.lblDetEstado)
        Me.pnlDetCambio.Controls.Add(Me.lblTitEmpresa)
        Me.pnlDetCambio.Controls.Add(Me.lblTitProducto)
        Me.pnlDetCambio.Controls.Add(Me.lblTitGlosa)
        Me.pnlDetCambio.Controls.Add(Me.lblTitTipoActual)
        Me.pnlDetCambio.Controls.Add(Me.lblTitTipoNuevo)
        Me.pnlDetCambio.Controls.Add(Me.lblTitPrecio)
        Me.pnlDetCambio.Controls.Add(Me.lblTitVolumen)
        Me.pnlDetCambio.Controls.Add(Me.lblTitMotivo)
        Me.pnlDetCambio.Controls.Add(Me.lblTitSolicitante)
        Me.pnlDetCambio.Controls.Add(Me.lblTitFecha)
        Me.pnlDetCambio.Controls.Add(Me.lblDetFecha)
        Me.pnlDetCambio.Controls.Add(Me.lblTitEstado)
        Me.pnlDetCambio.Controls.Add(Me.txtDetObs)
        Me.pnlDetCambio.Controls.Add(Me.btnDetAprobar)
        Me.pnlDetCambio.Controls.Add(Me.btnDetRechazar)
        Me.pnlDetCambio.Controls.Add(Me.btnDetCerrar)
        Me.pnlDetCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.pnlDetCambio.Location = New System.Drawing.Point(10, 335)
        Me.pnlDetCambio.Name = "pnlDetCambio"
        Me.pnlDetCambio.Size = New System.Drawing.Size(866, 320)
        Me.pnlDetCambio.TabIndex = 7
        Me.pnlDetCambio.TabStop = False
        Me.pnlDetCambio.Text = "Detalle de Solicitud"
        Me.pnlDetCambio.Visible = False
        '
        'lblDetTitulo
        '
        Me.lblDetTitulo.AutoSize = True
        Me.lblDetTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetTitulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDetTitulo.Location = New System.Drawing.Point(15, 25)
        Me.lblDetTitulo.Name = "lblDetTitulo"
        Me.lblDetTitulo.Size = New System.Drawing.Size(251, 17)
        Me.lblDetTitulo.TabIndex = 0
        Me.lblDetTitulo.Text = "Modificación de Tipo de Producto"
        '
        'lblDetNumero
        '
        Me.lblDetNumero.AutoSize = True
        Me.lblDetNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetNumero.Location = New System.Drawing.Point(300, 28)
        Me.lblDetNumero.Name = "lblDetNumero"
        Me.lblDetNumero.Size = New System.Drawing.Size(75, 15)
        Me.lblDetNumero.TabIndex = 1
        Me.lblDetNumero.Text = "Solicitud #"
        '
        'lblDetEmpresa
        '
        Me.lblDetEmpresa.AutoSize = True
        Me.lblDetEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetEmpresa.Location = New System.Drawing.Point(120, 60)
        Me.lblDetEmpresa.Name = "lblDetEmpresa"
        Me.lblDetEmpresa.Size = New System.Drawing.Size(0, 13)
        Me.lblDetEmpresa.TabIndex = 2
        '
        'lblDetProducto
        '
        Me.lblDetProducto.AutoSize = True
        Me.lblDetProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetProducto.Location = New System.Drawing.Point(560, 60)
        Me.lblDetProducto.Name = "lblDetProducto"
        Me.lblDetProducto.Size = New System.Drawing.Size(0, 13)
        Me.lblDetProducto.TabIndex = 3
        '
        'lblDetGlosa
        '
        Me.lblDetGlosa.AutoSize = True
        Me.lblDetGlosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetGlosa.Location = New System.Drawing.Point(120, 85)
        Me.lblDetGlosa.MaximumSize = New System.Drawing.Size(830, 0)
        Me.lblDetGlosa.Name = "lblDetGlosa"
        Me.lblDetGlosa.Size = New System.Drawing.Size(0, 13)
        Me.lblDetGlosa.TabIndex = 4
        '
        'lblDetTipoActual
        '
        Me.lblDetTipoActual.AutoSize = True
        Me.lblDetTipoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetTipoActual.Location = New System.Drawing.Point(120, 115)
        Me.lblDetTipoActual.Name = "lblDetTipoActual"
        Me.lblDetTipoActual.Size = New System.Drawing.Size(0, 13)
        Me.lblDetTipoActual.TabIndex = 5
        '
        'lblDetTipoNuevo
        '
        Me.lblDetTipoNuevo.AutoSize = True
        Me.lblDetTipoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetTipoNuevo.Location = New System.Drawing.Point(560, 115)
        Me.lblDetTipoNuevo.Name = "lblDetTipoNuevo"
        Me.lblDetTipoNuevo.Size = New System.Drawing.Size(0, 13)
        Me.lblDetTipoNuevo.TabIndex = 6
        '
        'lblDetPrecio
        '
        Me.lblDetPrecio.AutoSize = True
        Me.lblDetPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetPrecio.Location = New System.Drawing.Point(120, 145)
        Me.lblDetPrecio.Name = "lblDetPrecio"
        Me.lblDetPrecio.Size = New System.Drawing.Size(0, 13)
        Me.lblDetPrecio.TabIndex = 7
        '
        'lblDetVolumen
        '
        Me.lblDetVolumen.AutoSize = True
        Me.lblDetVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetVolumen.Location = New System.Drawing.Point(560, 145)
        Me.lblDetVolumen.Name = "lblDetVolumen"
        Me.lblDetVolumen.Size = New System.Drawing.Size(0, 13)
        Me.lblDetVolumen.TabIndex = 8
        '
        'lblDetMotivo
        '
        Me.lblDetMotivo.AutoSize = True
        Me.lblDetMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetMotivo.Location = New System.Drawing.Point(120, 175)
        Me.lblDetMotivo.MaximumSize = New System.Drawing.Size(830, 0)
        Me.lblDetMotivo.Name = "lblDetMotivo"
        Me.lblDetMotivo.Size = New System.Drawing.Size(0, 13)
        Me.lblDetMotivo.TabIndex = 9
        '
        'lblDetSolicitante
        '
        Me.lblDetSolicitante.AutoSize = True
        Me.lblDetSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetSolicitante.Location = New System.Drawing.Point(120, 205)
        Me.lblDetSolicitante.Name = "lblDetSolicitante"
        Me.lblDetSolicitante.Size = New System.Drawing.Size(0, 13)
        Me.lblDetSolicitante.TabIndex = 10
        '
        'lblDetEstado
        '
        Me.lblDetEstado.AutoSize = True
        Me.lblDetEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetEstado.Location = New System.Drawing.Point(120, 230)
        Me.lblDetEstado.Name = "lblDetEstado"
        Me.lblDetEstado.Size = New System.Drawing.Size(0, 15)
        Me.lblDetEstado.TabIndex = 11
        '
        'lblTitEmpresa
        '
        Me.lblTitEmpresa.AutoSize = True
        Me.lblTitEmpresa.Location = New System.Drawing.Point(15, 60)
        Me.lblTitEmpresa.Name = "lblTitEmpresa"
        Me.lblTitEmpresa.Size = New System.Drawing.Size(59, 13)
        Me.lblTitEmpresa.TabIndex = 12
        Me.lblTitEmpresa.Text = "Empresa:"
        '
        'lblTitProducto
        '
        Me.lblTitProducto.AutoSize = True
        Me.lblTitProducto.Location = New System.Drawing.Point(440, 60)
        Me.lblTitProducto.Name = "lblTitProducto"
        Me.lblTitProducto.Size = New System.Drawing.Size(62, 13)
        Me.lblTitProducto.TabIndex = 13
        Me.lblTitProducto.Text = "Producto:"
        '
        'lblTitGlosa
        '
        Me.lblTitGlosa.AutoSize = True
        Me.lblTitGlosa.Location = New System.Drawing.Point(15, 85)
        Me.lblTitGlosa.Name = "lblTitGlosa"
        Me.lblTitGlosa.Size = New System.Drawing.Size(78, 13)
        Me.lblTitGlosa.TabIndex = 14
        Me.lblTitGlosa.Text = "Descripción:"
        '
        'lblTitTipoActual
        '
        Me.lblTitTipoActual.AutoSize = True
        Me.lblTitTipoActual.Location = New System.Drawing.Point(15, 115)
        Me.lblTitTipoActual.Name = "lblTitTipoActual"
        Me.lblTitTipoActual.Size = New System.Drawing.Size(75, 13)
        Me.lblTitTipoActual.TabIndex = 15
        Me.lblTitTipoActual.Text = "Tipo actual:"
        '
        'lblTitTipoNuevo
        '
        Me.lblTitTipoNuevo.AutoSize = True
        Me.lblTitTipoNuevo.Location = New System.Drawing.Point(440, 115)
        Me.lblTitTipoNuevo.Name = "lblTitTipoNuevo"
        Me.lblTitTipoNuevo.Size = New System.Drawing.Size(94, 13)
        Me.lblTitTipoNuevo.TabIndex = 16
        Me.lblTitTipoNuevo.Text = "Tipo solicitado:"
        '
        'lblTitPrecio
        '
        Me.lblTitPrecio.AutoSize = True
        Me.lblTitPrecio.Location = New System.Drawing.Point(15, 145)
        Me.lblTitPrecio.Name = "lblTitPrecio"
        Me.lblTitPrecio.Size = New System.Drawing.Size(83, 13)
        Me.lblTitPrecio.TabIndex = 17
        Me.lblTitPrecio.Text = "Precio venta:"
        '
        'lblTitVolumen
        '
        Me.lblTitVolumen.AutoSize = True
        Me.lblTitVolumen.Location = New System.Drawing.Point(440, 145)
        Me.lblTitVolumen.Name = "lblTitVolumen"
        Me.lblTitVolumen.Size = New System.Drawing.Size(59, 13)
        Me.lblTitVolumen.TabIndex = 18
        Me.lblTitVolumen.Text = "Volumen:"
        '
        'lblTitMotivo
        '
        Me.lblTitMotivo.AutoSize = True
        Me.lblTitMotivo.Location = New System.Drawing.Point(15, 175)
        Me.lblTitMotivo.Name = "lblTitMotivo"
        Me.lblTitMotivo.Size = New System.Drawing.Size(49, 13)
        Me.lblTitMotivo.TabIndex = 19
        Me.lblTitMotivo.Text = "Motivo:"
        '
        'lblTitSolicitante
        '
        Me.lblTitSolicitante.AutoSize = True
        Me.lblTitSolicitante.Location = New System.Drawing.Point(15, 205)
        Me.lblTitSolicitante.Name = "lblTitSolicitante"
        Me.lblTitSolicitante.Size = New System.Drawing.Size(89, 13)
        Me.lblTitSolicitante.TabIndex = 20
        Me.lblTitSolicitante.Text = "Solicitado por:"
        '
        'lblTitFecha
        '
        Me.lblTitFecha.AutoSize = True
        Me.lblTitFecha.Location = New System.Drawing.Point(280, 205)
        Me.lblTitFecha.Name = "lblTitFecha"
        Me.lblTitFecha.Size = New System.Drawing.Size(46, 13)
        Me.lblTitFecha.TabIndex = 21
        Me.lblTitFecha.Text = "Fecha:"
        '
        'lblDetFecha
        '
        Me.lblDetFecha.AutoSize = True
        Me.lblDetFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDetFecha.Location = New System.Drawing.Point(325, 205)
        Me.lblDetFecha.Name = "lblDetFecha"
        Me.lblDetFecha.Size = New System.Drawing.Size(0, 13)
        Me.lblDetFecha.TabIndex = 22
        '
        'lblTitEstado
        '
        Me.lblTitEstado.AutoSize = True
        Me.lblTitEstado.Location = New System.Drawing.Point(15, 230)
        Me.lblTitEstado.Name = "lblTitEstado"
        Me.lblTitEstado.Size = New System.Drawing.Size(50, 13)
        Me.lblTitEstado.TabIndex = 23
        Me.lblTitEstado.Text = "Estado:"
        '
        'txtDetObs
        '
        Me.txtDetObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDetObs.Location = New System.Drawing.Point(15, 255)
        Me.txtDetObs.Name = "txtDetObs"
        Me.txtDetObs.Size = New System.Drawing.Size(835, 20)
        Me.txtDetObs.TabIndex = 24
        '
        'btnDetAprobar
        '
        Me.btnDetAprobar.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnDetAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnDetAprobar.ForeColor = System.Drawing.Color.White
        Me.btnDetAprobar.Location = New System.Drawing.Point(560, 285)
        Me.btnDetAprobar.Name = "btnDetAprobar"
        Me.btnDetAprobar.Size = New System.Drawing.Size(95, 28)
        Me.btnDetAprobar.TabIndex = 25
        Me.btnDetAprobar.Text = "Aprobar"
        Me.btnDetAprobar.UseVisualStyleBackColor = False
        '
        'btnDetRechazar
        '
        Me.btnDetRechazar.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnDetRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnDetRechazar.ForeColor = System.Drawing.Color.White
        Me.btnDetRechazar.Location = New System.Drawing.Point(660, 285)
        Me.btnDetRechazar.Name = "btnDetRechazar"
        Me.btnDetRechazar.Size = New System.Drawing.Size(95, 28)
        Me.btnDetRechazar.TabIndex = 26
        Me.btnDetRechazar.Text = "Rechazar"
        Me.btnDetRechazar.UseVisualStyleBackColor = False
        '
        'btnDetCerrar
        '
        Me.btnDetCerrar.Location = New System.Drawing.Point(760, 285)
        Me.btnDetCerrar.Name = "btnDetCerrar"
        Me.btnDetCerrar.Size = New System.Drawing.Size(90, 28)
        Me.btnDetCerrar.TabIndex = 27
        Me.btnDetCerrar.Text = "Cerrar Detalle"
        Me.btnDetCerrar.UseVisualStyleBackColor = True
        '
        'lblTitAprobadoPor
        '
        Me.lblTitAprobadoPor.Location = New System.Drawing.Point(0, 0)
        Me.lblTitAprobadoPor.Name = "lblTitAprobadoPor"
        Me.lblTitAprobadoPor.Size = New System.Drawing.Size(100, 23)
        Me.lblTitAprobadoPor.TabIndex = 0
        '
        'lblDetAprobadoPor
        '
        Me.lblDetAprobadoPor.Location = New System.Drawing.Point(0, 0)
        Me.lblDetAprobadoPor.Name = "lblDetAprobadoPor"
        Me.lblDetAprobadoPor.Size = New System.Drawing.Size(100, 23)
        Me.lblDetAprobadoPor.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.CatalogosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(960, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "Archivo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAyuda})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(60, 20)
        Me.ToolStripMenuItem1.Text = "Archivo"
        '
        'MenuAyuda
        '
        Me.MenuAyuda.Name = "MenuAyuda"
        Me.MenuAyuda.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.MenuAyuda.Size = New System.Drawing.Size(127, 22)
        Me.MenuAyuda.Text = "Ayuda"
        '
        'CatalogosToolStripMenuItem
        '
        Me.CatalogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcasToolStripMenuItem})
        Me.CatalogosToolStripMenuItem.Name = "CatalogosToolStripMenuItem"
        Me.CatalogosToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CatalogosToolStripMenuItem.Text = "Catalogos"
        '
        'MarcasToolStripMenuItem
        '
        Me.MarcasToolStripMenuItem.Name = "MarcasToolStripMenuItem"
        Me.MarcasToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.MarcasToolStripMenuItem.Text = "Marcas"
        '
        'frm_solicitud_productos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(960, 712)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frm_solicitud_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Solcitud de Productos .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvProductoSimilares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.group_listas.ResumeLayout(False)
        CType(Me.dg_listaprecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_packs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_encabezado.ResumeLayout(False)
        Me.group_encabezado.PerformLayout()
        Me.gp_administracion.ResumeLayout(False)
        Me.group_informacion.ResumeLayout(False)
        Me.group_informacion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_detalle.ResumeLayout(False)
        Me.group_detalle.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dg_listado_solicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvAprobacionCambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetCambio.ResumeLayout(False)
        Me.pnlDetCambio.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dtMaestrosLP As DataTable
    Dim dtSolicitudes As DataTable
    Dim Ods As DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Dim ncod_solicitud As Integer = -1
    Dim drSeleccion As DataRow
    Dim proceso_insercion As Boolean = False
    Dim proceso_inicial As Boolean = True
    Dim ls_filtro_original As String = String.Empty

    Private Sub Incializar_Tablas()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            Ods = New DataSet

            dt = New DataTable("ListaPrecio")
            dt.Columns.Add("Precio", GetType(Double))
            dt.Columns.Add("LisPrecio", GetType(String))
            dt.Columns(1).Unique = True


            Ods.Tables.Add(dt.Copy)

            dt = New DataTable("productos_packs")
            dt.Columns.Add("Producto", GetType(String))
            dt.Columns.Add("Descripcion", GetType(String))
            dt.Columns.Add("Cantidad", GetType(Integer))
            dt.Columns(0).Unique = True

            Ods.Tables.Add(dt.Copy)
            dg_packs.DataSource = Ods.Tables("productos_packs")




            ls_sql = "pa_sel_um_listaprecio_activa '" & gs_empresa & "'"
            dtMaestrosLP = Otrans.Obtiene(ls_sql)
            ''quitar la lista de Costo

            ''ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
            ''           " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.FAMILIA' " &
            ''          " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " &
            ''         " UNION select distinct Familia from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "

            ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
                        " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.FAMILIA' " &
                        " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' and len(texto2) > 0 " &
                        "   order by 1 "

            'ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.FAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_Familia"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
                     " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " &
                     " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " &
                     " UNION select distinct SubFamilia from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "

            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_SubFamilia"
            Ods.Tables.Add(dt.Copy)

            'hace falta tipo producto

            ls_sql = "pa_sel_um_gen_tabcod_producto null,'GEN_TIPOPRODUCTO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_tipo"
            Ods.Tables.Add(dt.Copy)


            'marca
            'ls_sql = "Select distinct(tipo) as Codigo from producto where empresa = '" & gs_empresa & " ' and validastock = 'S' order by 1"
            'ls_sql = "pa_sel_um_gen_tabcod null,'CON_MARCA','" & gs_empresa & "'"
            ls_sql = "pa_sel_um_gen_tabcod_producto null,'PRODUCTO.TIPO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_marca"
            Ods.Tables.Add(dt.Copy)

            'hace falta tipo producto
            ls_sql = "pa_sel_um_gen_tabcod_producto null,'PAIS_COMPRA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_procedencia"
            Ods.Tables.Add(dt.Copy)

            dt.TableName = "cat_origen"
            Ods.Tables.Add(dt.Copy)

            'sub tipo
            'ls_sql = "SELECT DISTINCT(SUBTIPO) AS Codigo FROM producto WHERE empresa = '" & gs_empresa & "' AND validastock = 'S' ORDER BY 1"
            ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
                    " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBTIPO' " &
                    " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " &
                    " UNION select distinct Subtipo from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_subtipo"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa null,null,'mer_sp_solicitantes','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_solicitantes"
            Ods.Tables.Add(dt.Copy)
            Ods.Tables("cat_solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"


            'Unidad de Medida
            'ls_sql = "Select distinct(unidad) as Codigo from flexline.producto where empresa = '" & gs_empresa & " ' and validastock = 'S' order by 1"
            ls_sql = "Select distinct 'UN' as Codigo from flexline.producto where empresa = '" & gs_empresa & " ' and validastock = 'S' order by 1"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_unidad_medida"
            Ods.Tables.Add(dt.Copy)


            'Unidad de alternativa
            'ls_sql = "SELECT DISTINCT(UNIDADALT) AS Codigo FROM flexline.producto WHERE empresa = '" & gs_empresa & "' AND validastock = 'S' ORDER BY 1"
            ls_sql = "SELECT distinct 'CAJA' AS Codigo FROM flexline.producto WHERE empresa = '" & gs_empresa & "' AND validastock = 'S' ORDER BY 1"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_unidad_medida_alt"
            Ods.Tables.Add(dt.Copy)

            'CEPA
            ls_sql = "pa_var_um_cepa_catalogo"

            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "cat_cepa"
            Ods.Tables.Add(dt.Copy)

            'hace falta tipo producto
            ls_sql = "pa_sel_um_gen_tabcod null,'CONFIG.IMPUESTO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_impuesto"
            Ods.Tables.Add(dt.Copy)

            'PACK'S POR PRODUCTOS
            ls_sql = "pa_sel_um_receta_producto '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pack_producto"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_producto_bu '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "bu"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "scm..pa_sel_um_v_pg_estados 13"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "estados"
            Ods.Tables.Add(dt.Copy)
            Aplicar_Filtro_Estados()

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Llenar_Grid_LP()


        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "ListaPrecio"
        tableStyle.BackColor            = Drawing.Color.FromArgb(252, 251, 248)
        tableStyle.AlternatingBackColor = Drawing.Color.FromArgb(240, 238, 230)
        tableStyle.ForeColor            = Drawing.Color.FromArgb(55, 62, 28)
        tableStyle.HeaderBackColor      = Drawing.Color.FromArgb(61, 68, 32)
        tableStyle.HeaderForeColor      = Drawing.Color.FromArgb(200, 205, 170)
        tableStyle.HeaderFont           = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Bold)
        tableStyle.SelectionBackColor   = Drawing.Color.FromArgb(196, 81, 35)
        tableStyle.SelectionForeColor   = Drawing.Color.White
        tableStyle.GridLineColor        = Drawing.Color.FromArgb(215, 212, 202)

        Dim dt As DataTable = Ods.Tables("ListaPrecio")

        Dim TextCol As New DataGridTextBoxColumn
        TextCol.MappingName = dt.Columns(0).ColumnName
        TextCol.HeaderText = "Precio"
        TextCol.Width = 80
        TextCol.Format = "n"
        TextCol.Alignment = HorizontalAlignment.Right
        tableStyle.GridColumnStyles.Add(TextCol)

        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = dt.Columns(1).ColumnName
        ComboTextCol.HeaderText = "Lista de Precios "
        ComboTextCol.Width = 150
        ComboTextCol.ColumnComboBox.DataSource = dtMaestrosLP.DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "lisprecio"
        ComboTextCol.ColumnComboBox.ValueMember = "idlisprecio"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight

        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5
        tableStyle.GridColumnStyles.Add(ComboTextCol)



        dg_listaprecios.TableStyles.Clear()
        dg_listaprecios.TableStyles.Add(tableStyle)

        dg_listaprecios.DataSource = Ods.Tables("ListaPrecio")

    End Sub


    Private Sub Llenar_Combos()

        cmb_familia.DataSource = Ods.Tables("cat_familia")
        cmb_familia.DisplayMember = "CODIGO"
        cmb_familia.ValueMember = "CODIGO"

        cmb_proveedor.DataSource = Ods.Tables("cat_Subfamilia")
        cmb_proveedor.DisplayMember = "Codigo"
        cmb_proveedor.ValueMember = "CODIGO"

        cmb_tipo_producto.DataSource = Ods.Tables("cat_tipo")
        cmb_tipo_producto.DisplayMember = "Codigo"
        cmb_tipo_producto.ValueMember = "CODIGO"

        cmb_sub_tipo.DataSource = Ods.Tables("cat_subtipo")
        cmb_sub_tipo.DisplayMember = "Codigo"
        cmb_sub_tipo.ValueMember = "Codigo"

        cmb_marca.DataSource = Ods.Tables("cat_marca")
        cmb_marca.DisplayMember = "Codigo"
        cmb_marca.ValueMember = "Codigo"

        cmb_origen.DataSource = Ods.Tables("cat_origen")
        cmb_origen.DisplayMember = "Codigo"
        cmb_origen.ValueMember = "CODIGO"

        cmb_procedencia.DataSource = Ods.Tables("cat_procedencia")
        cmb_procedencia.DisplayMember = "Codigo"
        cmb_procedencia.ValueMember = "CODIGO"

        cmb_solicitante.DataSource = Ods.Tables("cat_solicitantes").DefaultView
        cmb_solicitante.ValueMember = "usuario"
        cmb_solicitante.DisplayMember = "nombre"

        cmb_unidad_medida.DataSource = Ods.Tables("cat_unidad_medida")
        cmb_unidad_medida.ValueMember = "Codigo"
        cmb_unidad_medida.DisplayMember = "CODIGO"

        cmb_unidad_medida_alt.DataSource = Ods.Tables("cat_unidad_medida_alt")
        cmb_unidad_medida_alt.ValueMember = "Codigo"
        cmb_unidad_medida_alt.DisplayMember = "CODIGO"

        Me.cmbCEPA.DataSource = Ods.Tables("cat_cepa")
        Me.cmbCEPA.ValueMember = "cepa"
        Me.cmbCEPA.DisplayMember = "cepa"

        Dim dt As New DataTable
        dt = Ods.Tables("cat_impuesto").Copy
        dt.TableName = "cat_impuesto2"
        Ods.Tables.Add(dt)

        Ods.Tables("cat_impuesto2").Rows(0)("TEXTO1") = ""

        cmb_dai.DataSource = Ods.Tables("cat_impuesto2")
        cmb_dai.ValueMember = "CODIGO"
        cmb_dai.DisplayMember = "TEXTO1"

        cmb_estado.DataSource = Ods.Tables("estados").DefaultView
        cmb_estado.ValueMember = "cod_estado"
        cmb_estado.DisplayMember = "estado"




        Me.cmbBU.DataSource = Ods.Tables("bu")
        Me.cmbBU.ValueMember = "analisisproducto17"
        Me.cmbBU.DisplayMember = "analisisproducto17"
    End Sub



    Private Sub Aplicar_Filtro_Estados()
        Dim ls_filtro As String = String.Empty
        ls_filtro = "cod_estado in (4,6,7,20,21,22)"
        Ods.Tables("estados").DefaultView.RowFilter = ls_filtro
    End Sub




    Private Sub Llenar_Solicitudes()
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String


        Try
            cOtrans.open()
            ls_sql = "pa_sel_um_inv_producto_solicitud '" & gs_empresa & "',null"
            dtSolicitudes = cOtrans.Obtiene(ls_sql)
            dg_listado_solicitudes.DataSource = dtSolicitudes

            ClsGen.Alinea_Grid(dtSolicitudes, dg_listado_solicitudes, -1, 250, 0, True, True, ",cod_solicitud,numero,accion,cod_flex,nombre_producto,des_estado,usuario_solicito,fecha_solicito,usuario_aprobo,fecha_aprobo,observaciones,bu,", True, "")

        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Function BuscarProducto(ByVal pcodigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim dts As New DataTable
        Dim ls_sql As String


        Try
            Otrans.open()

            ls_sql = "pa_var_um_producto '" & gs_empresa & "','" & pcodigo & "'"
            dt = Otrans.Obtiene(ls_sql)


            ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & pcodigo & "', NULL"
            dts = Otrans.Obtiene(ls_sql)
            dts.TableName = "listaPrecioDet"

            If Ods.Tables.Contains("listaPrecioDet") Then
                Ods.Tables.Remove("listaPrecioDet")
            End If

            Ods.Tables.Add(dts.Copy)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Buscar_Producto(ByVal pcod_producto As String, ByVal posicion_grid As Integer)
        Dim lb_resultado As Boolean = False
        Dim otabla As DataTable

        otabla = BuscarProducto(pcod_producto)



        If otabla.Rows.Count > 0 Then
            If otabla.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then
                lb_resultado = True
                dg_packs(posicion_grid, 1) = otabla.Rows(0).Item("glosa")
                dg_packs(posicion_grid, 2) = 0
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
        Dim lb_resultado As String = ""
        Dim otabla As DataTable


        otabla = BuscarProducto(_pcod_producto)


        If otabla.Rows.Count > 0 Then
            If otabla.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then
                lb_resultado = otabla.Rows(0).Item("glosa")
            Else
                lb_resultado = otabla.Rows(0).Item("vigente").ToString

            End If
        End If

        Return lb_resultado
    End Function

    Private Sub Alinear_Grid_Productos()
        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(Ods.Tables("productos_packs"), dg_packs, Ods.Tables("productos_packs").TableName, -1, 250, 50, False, True, "", True, "Descripcion")
        ClsGen = Nothing
    End Sub

    Public Function DatoValidoProducto(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True

        Try
            If col = 1 Then
                returnValue = Buscar_Producto(dg_packs(row, 0), row)
            End If

            'If col = 3 Then
            '    returnValue = Validar_Precio(row)
            'End If

            If col = 0 And (row = 0 Or row = 4) And returnValue Then
                Alinear_Grid_Productos()
            End If
        Catch ex As Exception
        End Try
        Return returnValue
    End Function

    Private Sub Mostrar_Solicitud(ByVal _numero As Integer)
        proceso_inicial = True
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            btn_guardar.Text = "Modificar" ' (F2)"
            cmbBU.Enabled = False
            cmb_solicitante.Enabled = False
            txt_codigo_producto.Enabled = False
            cOtrans.open()
            Otrans.open()



            ls_sql = "pa_sel_um_inv_producto_solicitud '" & gs_empresa & "'," & _numero
            dt = cOtrans.Obtiene(ls_sql)

            drSeleccion = dt.Rows(0)
            'Debo Mostrar La informacion que se guardo en la solicitud
            ncod_solicitud = drSeleccion.Item("cod_solicitud").ToString

            cmbBU.Text = drSeleccion.Item("bu").ToString


            txt_codigo_producto.Text = drSeleccion.Item("cod_flex").ToString
            txt_descripcion.Text = drSeleccion.Item("nombre_producto").ToString
            txt_codigo_barras.Text = drSeleccion.Item("codigo_barra").ToString
            'txt_codigo_proveedor.Text = drSeleccion.Item("codigo_proveedor").ToString
            txtCodigoDistribuidora.Text = drSeleccion.Item("nombre_corto").ToString
            txt_observaciones.Text = drSeleccion.Item("observaciones").ToString

            txt_familia.Text = drSeleccion.Item("familia").ToString
            txt_tipo_producto.Text = drSeleccion.Item("tipoproducto").ToString
            txt_proveedor.Text = drSeleccion.Item("subfamilia").ToString
            txt_marca.Text = drSeleccion.Item("tipo").ToString

            txt_sub_tipo.Text = drSeleccion.Item("sub_tipo").ToString
            txt_origen.Text = drSeleccion.Item("origen").ToString
            txt_procedencia.Text = drSeleccion.Item("procedencia").ToString
            txt_unidad_medida_alt.Text = drSeleccion.Item("unidad_alt").ToString


            txt_unidad_medida.Text = drSeleccion.Item("unidad").ToString
            txt_unidades_x_caja.Text = drSeleccion.Item("factoralt").ToString
            'txt_peso.Text = drSeleccion.Item("peso").ToString
            txt_medida_litros.Text = drSeleccion.Item("volumen").ToString

            cmb_familia.Text = drSeleccion.Item("familia").ToString
            cmb_tipo_producto.Text = drSeleccion.Item("tipoproducto").ToString
            cmb_proveedor.Text = drSeleccion.Item("subfamilia").ToString
            cmb_marca.Text = drSeleccion.Item("tipo").ToString
            cmb_origen.Text = drSeleccion.Item("origen").ToString
            cmb_procedencia.Text = drSeleccion.Item("procedencia").ToString
            cmb_unidad_medida.Text = drSeleccion.Item("unidad").ToString
            cmb_unidad_medida_alt.Text = drSeleccion.Item("unidad_alt").ToString
            cmb_sub_tipo.Text = drSeleccion.Item("sub_tipo").ToString

            txt_precio_sugerido.Text = drSeleccion.Item("precio_venta").ToString
            'txt_volumen.Text = drSeleccion.Item("volumen").ToString

            cmb_dai.SelectedIndex = drSeleccion.Item("porcentaje_dai").ToString
            txt_dai.Text = cmb_dai.Text

            lbl_numero.Text = drSeleccion.Item("numero").ToString
            cmb_estado.SelectedValue = drSeleccion.Item("estado").ToString
            cmb_solicitante.SelectedValue = drSeleccion.Item("usuario_solicito").ToString
            txt_operado.Text = drSeleccion.Item("nombre_usuario_grabo").ToString
            If drSeleccion.Item("valor_iva").ToString = "S" Then
                afecta_iva.CheckState = CheckState.Checked
            Else
                afecta_iva.CheckState = CheckState.Unchecked
            End If


            If drSeleccion.Item("serie").ToString = "S" Then
                Me.utiliza_añada.SelectedItem = "SI"
            ElseIf drSeleccion.Item("serie").ToString = "N" Then
                Me.utiliza_añada.SelectedItem = "NO"
            Else
                Me.utiliza_añada.SelectedIndex = -1
            End If


            If drSeleccion.Item("lote").ToString = "S" Then
                Me.utiliza_lote.SelectedItem = "SI"
            ElseIf drSeleccion.Item("lote").ToString = "N" Then
                Me.utiliza_lote.SelectedItem = "NO"
            Else
                Me.utiliza_lote.SelectedIndex = -1
            End If

            ' Cargar tipo_proveedor desde BD (separado del SP de carga, lectura simple)
            ' Si esta NULL en BD, se trata como LOCAL (default conservador)
            Try
                Dim cOtransTP As New Transaccional.Conexion("Corporativo")
                cOtransTP.open()
                Dim sqlTP As String = "SELECT tipo_proveedor FROM flexline.inv_producto_solicitud WITH (NOLOCK) WHERE cod_solicitud = " & ncod_solicitud
                Dim dtTP As DataTable = cOtransTP.Obtiene(sqlTP)
                If dtTP IsNot Nothing AndAlso dtTP.Rows.Count > 0 Then
                    Dim valTP As String = If(IsDBNull(dtTP.Rows(0)(0)), "", dtTP.Rows(0)(0).ToString().Trim().ToUpper())
                    If valTP = "INTERNACIONAL" Then
                        Me.cmb_tipo_proveedor.SelectedItem = "INTERNACIONAL"
                    ElseIf valTP = "LOCAL" Then
                        Me.cmb_tipo_proveedor.SelectedItem = "LOCAL"
                    Else
                        ' NULL o vacio => no seleccionar nada (queda en blanco)
                        ' No se asume LOCAL porque el tipo_producto podria no requerirlo.
                        Me.cmb_tipo_proveedor.SelectedIndex = -1
                    End If
                End If
                cOtransTP.close()
            Catch
                ' Si la columna no existe todavia (ALTER TABLE pendiente), no romper
            End Try

            Try
                If drSeleccion.Item("cepa").ToString.Length > 0 Then
                    Me.cmbCEPA.SelectedValue = drSeleccion.Item("cepa").ToString
                    Me.txtCEPA.Text = drSeleccion.Item("cepa").ToString
                    Me.lblCepa.Visible = True
                    Me.txtCEPA.Visible = True
                    Me.cmbCEPA.Visible = True
                End If
            Catch ex As Exception

            End Try


            gp_administracion.Visible = False

            If drSeleccion.Item("estado") = 4 Then
                If tiene_permisos("mer_sp_aprobar_solicitudes") Then
                    btn_aprobar.Visible = True
                    btn_procesar.Visible = True
                    btn_anular.Visible = True
                    btn_procesar.Enabled = False
                    gp_administracion.Visible = True
                End If
                If tiene_permisos("mer_sp_rechazar_solicitudes") Then
                    btn_rechazar.Visible = True
                    btn_procesar.Visible = True
                    btn_anular.Visible = True
                    btn_procesar.Enabled = False
                    gp_administracion.Visible = True
                End If
            End If

            btn_anular.Visible = False
            If drSeleccion.Item("estado") <> 6 And drSeleccion.Item("estado") <> 7 Then
                btn_guardar.Enabled = True
                group_encabezado.Enabled = True
                group_informacion.Enabled = True
                group_detalle.Enabled = True
                gp_administracion.Visible = False
                btn_guardar.Enabled = False
                If drSeleccion.Item("estado") <> 21 Then
                    btn_guardar.Enabled = True
                    gp_administracion.Visible = True
                    btn_anular.Visible = True
                    btn_procesar.Visible = False
                End If
            ElseIf drSeleccion.Item("estado") = 7 Then
                btn_guardar.Enabled = False
                group_encabezado.Enabled = False
                group_informacion.Enabled = False
                group_detalle.Enabled = False
                group_listas.Enabled = False
                gp_administracion.Visible = True
            Else
                btn_guardar.Enabled = False
                group_encabezado.Enabled = False
                group_informacion.Enabled = False
                group_detalle.Enabled = False
                group_listas.Enabled = False
                btn_anular.Visible = False
                btn_procesar.Visible = True
                btn_procesar.Enabled = True
                btn_rechazar.Visible = True '(c) 20201912 Opcon de rechazar para que pueda modificar
                btn_rechazar.Enabled = True
                If tiene_permisos("mer_sp_procesar_solicitudes") Then
                    gp_administracion.Visible = True
                Else
                    gp_administracion.Visible = False
                End If
            End If

            If btn_anular.Visible = True Then
                If drSeleccion.Item("usuario_grabo").ToString.ToLower <> gs_usuario.ToLower AndAlso drSeleccion.Item("usuario_solicito").ToString.ToLower <> gs_usuario.ToLower Then
                    btn_anular.Visible = False
                End If
            End If

            If btn_guardar.Enabled = True Then
                If drSeleccion.Item("usuario_grabo").ToString.ToLower <> gs_usuario.ToLower AndAlso drSeleccion.Item("usuario_solicito").ToString.ToLower <> gs_usuario.ToLower Then
                    btn_guardar.Enabled = False

                    If gi_tipo_usuario = 1 Then
                        btn_guardar.Enabled = True
                    End If
                End If
            Else
                ls_sql = "pa_sel_um_listaprecio_total '" & gs_empresa & "'"
                dtMaestrosLP = Otrans.Obtiene(ls_sql)
            End If

        Catch ex As Exception
        Finally
            Mostrar_Solicitudes_Lista_Precios(ncod_solicitud)
            Mostrar_Solicitudes_Packs(ncod_solicitud)
            TabControl1.SelectedTab = TabPage1
            txt_descripcion.Focus()
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try

        proceso_inicial = False
    End Sub

    Private Sub Mostrar_Solicitudes_Lista_Precios(ByVal ncod_solicitud As Integer)
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String

        Try
            Ods.Tables("ListaPrecio").Rows.Clear()


            cOtrans.open()
            ls_sql = "pa_sel_um_inv_producto_solicitud_lista_precios " & ncod_solicitud.ToString
            dt = cOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = Ods.Tables("ListaPrecio").NewRow

                dr_aux.Item("LisPrecio") = dr.Item("Lista_Precio").ToString
                dr_aux.Item("Precio") = dr.Item("Precio")

                Ods.Tables("ListaPrecio").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Llenar_Grid_LP()
        End Try



    End Sub

    Private Sub Mostrar_Solicitudes_Packs(ByVal ncod_solicitud As Integer)
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String

        Try
            cOtrans.open()
            Ods.Tables("productos_packs").Rows.Clear()



            ls_sql = "pa_sel_um_inv_producto_solicitud_packs " & ncod_solicitud.ToString
            dt = cOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = Ods.Tables("productos_packs").NewRow
                dr_aux.Item("producto") = dr.Item("cod_flex").ToString

                dt2 = BuscarProducto(dr.Item("cod_flex"))
                If dt2.Rows.Count = 1 Then
                    dr_aux.Item("Descripcion") = dt2.Rows(0).Item("glosa")
                End If

                dr_aux.Item("Cantidad") = dr.Item("Cantidad")
                Ods.Tables("productos_packs").Rows.Add(dr_aux)
            Next

            Alinear_Grid_Productos()
        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing

        End Try

    End Sub

    Private Sub Ingreso_Nuevo_Maestros()

        Me.Incializar_Tablas()
        Llenar_Grid_LP()
        proceso_inicial = True
        ncod_solicitud = -1
        gp_administracion.Visible = False

        cmbBU.SelectedText = ""
        group_detalle.Enabled = True
        group_encabezado.Enabled = True
        group_informacion.Enabled = True
        group_listas.Enabled = True
        dg_listaprecios.Enabled = True
        dg_packs.Enabled = True

        cmbBU.Enabled = True
        cmb_solicitante.Enabled = True

        'cmb_sub_tipo.Text = String.Empty
        'cmb_unidad_medida_alt.Text = String.Empty
        txt_codigo_producto.Enabled = True
        txt_operado.Text = gs_nombre_usuario
        dtp_fecha_solicitud.Enabled = False

        txt_codigo_producto.Text = ""
        txt_descripcion.Text = ""
        txt_codigo_barras.Text = ""
        'txt_codigo_proveedor.Text = ""
        txtCodigoDistribuidora.Text = String.Empty
        txt_observaciones.Text = ""
        txt_medida_litros.Text = 0
        txt_unidades_x_caja.Text = 0
        'txt_peso.Text = 0
        'txt_volumen.Text = 0
        txt_precio_sugerido.Text = 0

        'cmbBU.SelectedValue = -1
        'cmb_familia.SelectedValue = -1
        'cmb_marca.SelectedValue = 0
        'cmb_estado.SelectedValue = 0
        'cmb_origen.SelectedValue = 0
        'cmb_procedencia.SelectedValue = -1
        'cmb_proveedor.SelectedValue = -1
        'cmb_solicitante.SelectedValue = -1
        'cmb_tipo_producto.SelectedValue = -1
        cmb_unidad_medida.SelectedValue = -1
        cmb_dai.SelectedValue = -1

        'cmb_familia.Text = String.Empty
        'cmb_marca.Text = String.Empty
        cmb_estado.Text = String.Empty
        'cmb_origen.Text = String.Empty
        'cmb_procedencia.Text = String.Empty
        'cmb_proveedor.Text = String.Empty
        cmb_solicitante.Text = String.Empty
        'cmb_tipo_producto.Text = String.Empty
        cmb_unidad_medida.Text = String.Empty
        'cmb_dai.Text = String.Empty

        'txt_familia.Text = String.Empty
        'txt_tipo_producto.Text = String.Empty
        'txt_proveedor.Text = String.Empty
        'txt_marca.Text = String.Empty

        'txt_sub_tipo.Text = String.Empty
        'txt_origen.Text = String.Empty
        'txt_procedencia.Text = String.Empty
        txt_unidad_medida.Text = String.Empty

        'txt_dai.Text = String.Empty
        txt_unidad_medida_alt.Text = String.Empty

        Ods.Tables("Listaprecio").Rows.Clear()
        Ods.Tables("productos_packs").Rows.Clear()

        Aplicar_Filtro_Estados()
        btn_rechazar.Visible = False
        btn_aprobar.Visible = False
        btn_procesar.Visible = False
        btn_guardar.Text = "Guardar" ' (F2)"
        btn_guardar.Enabled = True
        lbl_numero.Text = String.Empty

        'cmbBU.Text = String.Empty
        'cmbBU.Text = ""
        afecta_iva.CheckState = CheckState.Checked
        Me.utiliza_lote.SelectedIndex = -1
        Me.utiliza_añada.SelectedIndex = -1
        Me.cmb_tipo_proveedor.SelectedIndex = -1

        proceso_inicial = False
        Me.txtCEPA.Visible = False
        Me.cmbCEPA.Visible = False
        Me.lblCepa.Visible = False
    End Sub


    Private Sub Ingreso_Nuevo()

        Me.Incializar_Tablas()
        Llenar_Grid_LP()
        proceso_inicial = True
        ncod_solicitud = -1
        gp_administracion.Visible = False

        cmbBU.SelectedText = ""
        group_detalle.Enabled = True
        group_encabezado.Enabled = True
        group_informacion.Enabled = True
        group_listas.Enabled = True
        dg_listaprecios.Enabled = True
        dg_packs.Enabled = True

        cmbBU.Enabled = True
        cmb_solicitante.Enabled = True

        cmb_sub_tipo.Text = String.Empty
        cmb_unidad_medida_alt.Text = String.Empty
        txt_codigo_producto.Enabled = True
        txt_operado.Text = gs_nombre_usuario
        dtp_fecha_solicitud.Enabled = False

        txt_codigo_producto.Text = ""
        txt_descripcion.Text = ""
        txt_codigo_barras.Text = ""
        'txt_codigo_proveedor.Text = ""
        txtCodigoDistribuidora.Text = String.Empty
        txt_observaciones.Text = ""
        txt_medida_litros.Text = 0
        txt_unidades_x_caja.Text = 0
        'txt_peso.Text = 0
        'txt_volumen.Text = 0
        txt_precio_sugerido.Text = 0

        cmbBU.SelectedValue = -1
        cmb_familia.SelectedValue = -1
        cmb_marca.SelectedValue = 0
        cmb_estado.SelectedValue = 0
        cmb_origen.SelectedValue = 0
        cmb_procedencia.SelectedValue = -1
        cmb_proveedor.SelectedValue = -1
        cmb_solicitante.SelectedValue = -1
        cmb_tipo_producto.SelectedValue = -1
        cmb_unidad_medida.SelectedValue = -1
        cmb_dai.SelectedValue = -1

        cmb_familia.Text = String.Empty
        cmb_marca.Text = String.Empty
        cmb_estado.Text = String.Empty
        cmb_origen.Text = String.Empty
        cmb_procedencia.Text = String.Empty
        cmb_proveedor.Text = String.Empty
        cmb_solicitante.Text = String.Empty
        cmb_tipo_producto.Text = String.Empty
        cmb_unidad_medida.Text = String.Empty
        cmb_dai.Text = String.Empty

        txt_familia.Text = String.Empty
        txt_tipo_producto.Text = String.Empty
        txt_proveedor.Text = String.Empty
        txt_marca.Text = String.Empty

        txt_sub_tipo.Text = String.Empty
        txt_origen.Text = String.Empty
        txt_procedencia.Text = String.Empty
        txt_unidad_medida.Text = String.Empty

        txt_dai.Text = String.Empty
        txt_unidad_medida_alt.Text = String.Empty

        Ods.Tables("Listaprecio").Rows.Clear()
        Ods.Tables("productos_packs").Rows.Clear()

        Aplicar_Filtro_Estados()
        btn_rechazar.Visible = False
        btn_aprobar.Visible = False
        btn_procesar.Visible = False
        btn_guardar.Text = "Guardar" ' (F2)"
        btn_guardar.Enabled = True
        lbl_numero.Text = String.Empty

        cmbBU.Text = String.Empty
        cmbBU.Text = ""
        afecta_iva.CheckState = CheckState.Checked
        Me.utiliza_lote.SelectedIndex = -1
        Me.utiliza_añada.SelectedIndex = -1
        Me.cmb_tipo_proveedor.SelectedIndex = -1

        proceso_inicial = False
        Me.txtCEPA.Visible = False
        Me.cmbCEPA.Visible = False
        Me.lblCepa.Visible = False
    End Sub

    Private Function Buscar_Producto() As Boolean
        Dim existe_producto As Boolean = False
        proceso_inicial = True
        Try
            Dim dt As DataTable
            Dim dr As DataRow
            Dim icount As Integer

            dt = BuscarProducto(txt_codigo_producto.Text)
            If dt.Rows.Count > 0 Then
                existe_producto = True
                dr = dt.Rows(0)

                txt_descripcion.Text = dr.Item("Glosa").ToString
                cmb_familia.Text = dr.Item("Familia").ToString
                cmb_tipo_producto.Text = dr.Item("TipoProducto").ToString
                cmb_proveedor.Text = dr.Item("SubFamilia").ToString
                cmb_procedencia.Text = dr.Item("Procedencia").ToString
                cmb_origen.Text = dr.Item("AnalisisProducto4").ToString
                cmb_marca.Text = dr.Item("Tipo").ToString
                cmb_unidad_medida.Text = dr.Item("Unidad").ToString
                cmb_unidad_medida_alt.Text = dr.Item("UnidadALT").ToString

                txt_familia.Text = dr.Item("Familia").ToString
                txt_tipo_producto.Text = dr.Item("TipoProducto").ToString
                txt_proveedor.Text = dr.Item("SubFamilia").ToString
                txt_procedencia.Text = dr.Item("Procedencia").ToString
                txt_origen.Text = dr.Item("AnalisisProducto4").ToString
                txt_marca.Text = dr.Item("Tipo").ToString
                txt_unidad_medida.Text = dr.Item("Unidad").ToString
                txt_unidad_medida_alt.Text = dr.Item("UnidadALT").ToString


                txt_unidades_x_caja.Text = dr.Item("FactorAlt").ToString
                'txt_peso.Text = dr.Item("Peso").ToString
                txt_medida_litros.Text = dr.Item("Volumen").ToString
                'txt_volumen.Text = dr.Item("AnalisisProducto1").ToString
                txt_precio_sugerido.Text = dr.Item("PrecioVenta").ToString
                txt_codigo_barras.Text = dr.Item("codigo_barra").ToString
                'txt_codigo_proveedor.Text = dr.Item("codigo_proveedor").ToString
                txtCodigoDistribuidora.Text = dr.Item("nombre_corto").ToString
                cmb_sub_tipo.Text = dr.Item("subtipo").ToString

                For icount = 1 To 20
                    If icount = 1 Or icount = 9 Or icount = 10 Or icount = 11 Then

                    Else
                        If dr.Item("Factor" & icount) = 1 Then
                            Exit For
                        End If
                    End If
                Next
                cmb_dai.SelectedIndex = icount
            Else
                MessageBox.Show("Producto No Existe")
            End If

            If existe_producto Then
                Dim mRow() As DataRow = Ods.Tables("pack_producto").Select("PRODUCTO = '" & txt_codigo_producto.Text & "'")

                Ods.Tables("productos_packs").Clear()

                If mRow.Length > 0 Then
                    For ii As Integer = 0 To mRow.Length - 1
                        Dim newRow As DataRow = Ods.Tables("productos_packs").NewRow()

                        newRow("producto") = mRow(ii)("productoi")
                        newRow("descripcion") = mRow(ii)("descripcion")
                        newRow("cantidad") = mRow(ii)("cantidad")

                        Ods.Tables("productos_packs").Rows.Add(newRow)
                    Next

                    dg_packs.Update()
                    dg_packs.Update()

                    Alinear_Grid_Productos()
                End If

                Ods.Tables("ListaPrecio").Clear()

                With Ods.Tables("listaPrecioDet")
                    If .Rows.Count > 0 Then
                        For ii As Integer = 0 To .Rows.Count - 1
                            Dim mNewRow As DataRow = Ods.Tables("ListaPrecio").NewRow

                            mNewRow("precio") = .Rows(ii)("valor")

                            Ods.Tables("ListaPrecio").Rows.Add(mNewRow)

                            dg_listaprecios.Update()

                            dg_listaprecios.Item(ii, 1) = .Rows(ii)("Lisprecio")
                        Next
                    End If


                End With
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            existe_producto = False
        End Try
        proceso_inicial = False
        Return existe_producto
    End Function

    Private Function Guardar_Solicitud() As Integer
        Dim retorna As Integer = 0
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim icorrelativo As Integer
        Dim lexito As Boolean = True

        Try
            cOtrans.open()

            ls_sql = "pa_var_um_inv_producto_solicitud_numero '" & gs_empresa & "'"
            dt = cOtrans.Obtiene(ls_sql)
            lbl_numero.Text = dt.Rows(0).Item("nuevo_numero").ToString


            'cmbBU.Text & "','" & _

            ls_sql = "pa_ins_um_inv_producto_solicitud '" &
            gs_empresa.ToString & "'," &
            lbl_numero.Text & ",'Alta','" &
            txt_codigo_producto.Text & "','" &
            txt_descripcion.Text.Replace("'", "!") & "','" &
            txt_tipo_producto.Text & "','" &
            txt_familia.Text & "','" &
            txt_proveedor.Text & "','" &
            txt_marca.Text & "','" &
            txt_origen.Text & "','" &
            txt_procedencia.Text & "','" &
            txt_unidad_medida.Text & "'," &
            txt_unidades_x_caja.Text & "," &
             "0,0,'" &
             txt_medida_litros.Text & "'," &
            txt_precio_sugerido.Text & ",'" &
            IIf(txt_codigo_barras.Text.Trim.Length = 0, "", txt_codigo_barras.Text) & "','" &
            txtCodigoDistribuidora.Text & "'," &
            IIf(cmb_dai.SelectedIndex <= 0, 0, cmb_dai.SelectedIndex) & ",'" &
            gs_usuario & "','" &
            cmb_solicitante.SelectedValue.ToString & "','" &
            txt_observaciones.Text & "', '" &
            txt_sub_tipo.Text & "', '" &
            txt_unidad_medida_alt.Text & "', '" &
            IIf(afecta_iva.Checked = True, "S'", "N'") &
            ",'" & Me.cmbBU.SelectedValue.ToString & "','" &
            IIf(Me.utiliza_añada.SelectedItem IsNot Nothing AndAlso Me.utiliza_añada.SelectedItem.ToString() = "SI", "S", "N") & "','" &
            IIf(Me.utiliza_lote.SelectedItem IsNot Nothing AndAlso Me.utiliza_lote.SelectedItem.ToString() = "SI", "S", "N") & "'," &
            IIf(Me.cmbCEPA.Visible = True, "'" & Me.txtCEPA.Text & "'", "''")


            'Se Agrego Opcion para Seleccionar el BU
            '(c) 20160122
            '(c) 20220627 Se Agrego CEPA


            cOtrans.Ingresa(ls_sql)
            If cOtrans.Codigo_error = 0 Then
                'ls_sql = "SELECT @@IDENTITY AS NewID"
                ls_sql = "pa_sel_um_inv_producto_solicitud '" & gs_empresa & "'," & Me.lbl_numero.Text
                dt = cOtrans.Obtiene(ls_sql)
                'icorrelativo = dt.Rows(0).Item("newid").ToString
                icorrelativo = dt.Rows(0).Item("cod_solicitud").ToString

                ' Guardar tipo_proveedor por separado (no se modifico el SP, UPDATE directo)
                Try
                    If Me.cmb_tipo_proveedor.SelectedItem IsNot Nothing Then
                        Dim sqlTP As String = "UPDATE flexline.inv_producto_solicitud SET tipo_proveedor = '" & Me.cmb_tipo_proveedor.SelectedItem.ToString() & "' WHERE cod_solicitud = " & icorrelativo
                        cOtrans.Actualiza(sqlTP)
                    End If
                Catch
                End Try

                Try
                    If icorrelativo > 0 And lexito Then

                        Guardar_Listas_Precios(icorrelativo, cOtrans)
                        Guardar_Productos_Pack(icorrelativo, cOtrans)
                        Guardar_estado_Solicitud(icorrelativo, 4, cOtrans)
                        Llenar_Solicitudes()
                    End If
                Catch ex As Exception
                    retorna = 1
                End Try
            Else
                lexito = False
                retorna = 1
            End If

        Catch ex As Exception
            retorna = 1
            lexito = False
        Finally
            cOtrans.close()
            cOtrans = Nothing
        End Try


        Return retorna
    End Function

    Private Function Guardar_Listas_Precios(ByVal ncod_solicitud As Integer, cOtrans As Transaccional.Conexion) As Boolean

        Dim ls_sql As String
        Dim dr As DataRow
        Dim lexito As Boolean = True

        Try


            cOtrans.Elimina("pa_del_um_inv_productos_solicitud_lista " & ncod_solicitud)

            For Each dr In Ods.Tables("ListaPrecio").Rows

                dtMaestrosLP.DefaultView.RowFilter = "idlisprecio = " & dr.Item("LisPrecio").ToString
                ls_sql = "pa_ins_um_inv_producto_solicitud_lista_precios " &
                        ncod_solicitud.ToString & ",'" & dr.Item("LisPrecio").ToString & "'," &
                        dr.Item("Precio").ToString & ",'" &
                        dtMaestrosLP.DefaultView(0)("lisprecio") & "'"

                cOtrans.Ingresa(ls_sql)
                If cOtrans.Codigo_error > 0 Then
                    MessageBox.Show("Problemas Al Guardar La Lista de Precios " & dr.Item("LisPrecio").ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lexito = False
                End If
            Next
            dtMaestrosLP.DefaultView.RowFilter = ""


        Catch ex As Exception
        Finally
        End Try

        Return lexito
    End Function

    Private Function Guardar_Productos_Pack(ByVal ncod_solicitud As Integer, cOtrans As Transaccional.Conexion) As Boolean

        Dim ls_sql As String
        Dim dr As DataRow
        Dim lexito As Boolean = True

        Try

            cOtrans.Elimina("pa_del_um_inv_productos_solicitud_packs " & ncod_solicitud)

            For Each dr In Ods.Tables("productos_packs").Rows

                ls_sql = "pa_ins_um_inv_producto_solicitud_packs " &
                                      ncod_solicitud.ToString & ",'" & dr.Item("producto").ToString & "'," &
                                      dr.Item("Cantidad").ToString

                cOtrans.Ingresa(ls_sql)
                If cOtrans.Codigo_error > 0 Then
                    MessageBox.Show("Problemas Al Guardar La Lista de Precios " & dr.Item("LisPrecio").ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lexito = False
                End If
            Next


        Catch ex As Exception
            lexito = False
        Finally
        End Try
        Return lexito
    End Function

    Private Sub Guardar_estado_Solicitud(ByVal _pcod_solicitud As Integer, ByVal _pcod_estado As Integer, cOtrans As Transaccional.Conexion)

        Dim ls_sql As String = ""

        Try

            Select Case _pcod_estado
                Case 3
                    'Do nothing
                Case 5
                    ls_sql = "pa_upd_um_inv_producto_solicitud_aprobado " & _pcod_solicitud.ToString & "," & _pcod_estado.ToString & ",'" & gs_usuario & "'"
                Case 7
                    ls_sql = "pa_upd_um_inv_producto_solicitud_opero_flex " & _pcod_solicitud.ToString & ",'" & txt_codigo_producto.Text & "','" & gs_usuario & "'"
                Case 21
                    ls_sql = "pa_upd_um_inv_producto_solicitud_estado_rechazado " & _pcod_solicitud.ToString & "," & _pcod_estado.ToString & ",'" & txt_observaciones.Text & "'"
                    'Do nothing
                Case 22
                    ls_sql = "pa_upd_um_inv_producto_solicitud_estado_rechazado " & _pcod_solicitud.ToString & "," & _pcod_estado.ToString & ",'" & txt_observaciones.Text & "'"
                Case Else
                    ls_sql = "pa_upd_um_inv_producto_solicitud_estado " & _pcod_solicitud.ToString & "," & _pcod_estado.ToString
            End Select

            cOtrans.Actualiza(ls_sql)
            cOtrans.Escribir_Log(ls_sql)


        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Function Modificar_Solicitud() As Integer
        Dim retorna As Integer = 0
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ls_sql As String
        Dim icorrelativo As Integer
        Dim lexito As Boolean = True

        Try
            cOtrans.open()

            'ls_sql = "call pa_var_um_inv_producto_solicitud_numero ('" & pi_cod_empresa_onbase.ToString & "')"
            'dt = myOtrans.Obtiene(ls_sql)

            'If btn_guardar.Text.ToLower <> "modificar" Then lbl_numero.Text = dt.Rows(0).Item("nuevo_numero").ToString

            ls_sql = "pa_upd_um_inv_producto_solicitud " & ncod_solicitud & "," & lbl_numero.Text & ",'Alta','" &
                txt_descripcion.Text & "','" & cmb_tipo_producto.Text & "','" &
                cmb_familia.Text & "','" & cmb_proveedor.Text & "','" & cmb_marca.Text & "','" &
                cmb_origen.Text & "','" & cmb_procedencia.Text & "','" &
                cmb_unidad_medida.Text & "','" & txt_unidades_x_caja.Text & "','" &
                  "0'," & txt_medida_litros.Text & ",0," &
                txt_precio_sugerido.Text & ",'" & txt_codigo_barras.Text & "','" & txtCodigoDistribuidora.Text & "'," &
                IIf(cmb_dai.SelectedIndex <= 0, 0, cmb_dai.SelectedIndex) &
                ",'" & gs_usuario & "','" & cmb_solicitante.SelectedValue.ToString & "','" &
                txt_observaciones.Text & "', '" & cmb_sub_tipo.SelectedValue.ToString & "', '" & cmb_unidad_medida_alt.SelectedValue.ToString & "', '" &
                IIf(afecta_iva.Checked = True, "S", "N") & "', '" &
                IIf(Me.utiliza_añada.SelectedItem IsNot Nothing AndAlso Me.utiliza_añada.SelectedItem.ToString() = "SI", "S", "N") & "', '" &
                IIf(Me.utiliza_lote.SelectedItem IsNot Nothing AndAlso Me.utiliza_lote.SelectedItem.ToString() = "SI", "S", "N") & "'" &
                IIf(Me.cmbCEPA.Visible = True, "'" & Me.txtCEPA.Text & "'", "''")

            cOtrans.Escribir_Log(ls_sql)
            cOtrans.Actualiza(ls_sql)
            retorna = cOtrans.Codigo_error

            icorrelativo = ncod_solicitud

            ' Guardar tipo_proveedor por separado (no se modifico el SP, UPDATE directo)
            Try
                If Me.cmb_tipo_proveedor.SelectedItem IsNot Nothing Then
                    Dim sqlTP As String = "UPDATE flexline.inv_producto_solicitud SET tipo_proveedor = '" & Me.cmb_tipo_proveedor.SelectedItem.ToString() & "' WHERE cod_solicitud = " & icorrelativo
                    cOtrans.Actualiza(sqlTP)
                End If
            Catch
            End Try

            If icorrelativo > 0 And lexito Then
                Guardar_Listas_Precios(icorrelativo, cOtrans)
                Guardar_Productos_Pack(icorrelativo, cOtrans)
                Llenar_Solicitudes()
            End If

        Catch ex As Exception
            retorna = 1
            lexito = False
        Finally
            cOtrans.close()
            cOtrans = Nothing
        End Try



        Return retorna
    End Function

    Private Function VerificarEstados() As Boolean
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim lbprocesar As Boolean = False

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_inv_producto_solicitud '" & gs_empresa & "'," & Me.lbl_numero.Text
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count = 0 Then
                lbprocesar = False
                Exit Try
            ElseIf dt.Rows(0).Item("estado") = 4 Or dt.Rows(0).Item("estado") = 22 Then
                lbprocesar = True
            End If

            If dt.Rows(0).Item("usuario_grabo") = gs_usuario Or dt.Rows(0).Item("usuario_solicito") = gs_usuario Or gi_tipo_usuario = 1 Then
                lbprocesar = True
            Else
                lbprocesar = False
                MessageBox.Show("Solo el Usuario que Grabo o Solicito Puede Modificar la Solicitud", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return lbprocesar
    End Function


    Private Sub imprimirSolicitud()

        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\SolicitudProducto_" & gs_empresa & "_" & Me.lbl_numero.Text & ".pdf"

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Mercadeo Corporativo\Solicitud de Productos.rpt"
            pm_parametros(0) = "Numero_solicitud"
            pm_parametros(1) = "Empresa"
            pm_valores(0) = Me.lbl_numero.Text
            pm_valores(1) = gs_empresa

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "mysql", "OnBase", "sa", "sa", True, False, "PDF", True)
        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

    End Sub

    Private Sub Aplicar_Filtro()
        Dim ls_filtro As String = ""

        Try

            '  ls_filtro_original = "empresa = '" & gs_empresa & "' "
            If Me.txt_busqueda.TextLength > 0 Then
                'ls_filtro = Me.cmb_campos_busqueda.SelectedValue.ToString & " " & Me.cmb_operadores.SelectedValue.ToString & " '" & Me.txt_busqueda.Text & "'"
                If Me.chk_ver_todos.CheckState = CheckState.Checked Then

                    ls_filtro = Me.cmb_campos_busqueda.Text & " " &
                               Me.cmb_operadores.Text & " '" & IIf(Me.cmb_operadores.Text = "like", "%", "") & Me.txt_busqueda.Text & IIf(Me.cmb_operadores.Text = "like", "%", "") & "'"
                Else
                    ls_filtro = Me.cmb_campos_busqueda.Text & " " &
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
            dtSolicitudes.DefaultView.RowFilter = ls_filtro
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub guardarAviso()
        '' 5 = pg_tipoaviso=Creacion de Productos
        '' Se le avisa al usuario que solicito la creacion del producto

        Dim dt As DataTable
        Dim dtCorreo As DataTable
        Dim sCuentas As String = String.Empty
        Dim ClsGen As New ClasesGenerales.General
        Try

            'ClsGen.guardarAviso(cmb_solicitante.SelectedValue, "Umbright", _
            '    "Se Proceso La Solicitud del Producto " & Me.txt_codigo_producto.Text & "-" & Me.txt_descripcion.Text & " del Proveedor " & Me.cmb_proveedor.SelectedValue.ToString, 5)

            dt = ClsGen.usuariosAviso(5)
            For Each dr As DataRow In dt.Rows
                'ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Se Proceso La Solicitud del Producto " & Me.txt_codigo_producto.Text & "-" & Me.txt_descripcion.Text & " del Proveedor " & Me.cmb_proveedor.SelectedValue.ToString, 5)

                dtCorreo = ClsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario").ToString & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If sCuentas.ToString.Length > 0 Then sCuentas = sCuentas & ","
                    sCuentas = sCuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If

            Next

            dtCorreo = ClsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & cmb_solicitante.SelectedValue & "'")
            If dtCorreo.Rows.Count > 0 Then
                If sCuentas.ToString.Length > 0 Then sCuentas = sCuentas & ","
                sCuentas = sCuentas & dtCorreo.Rows(0).Item("correo").ToString
            End If

            dtCorreo = ClsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & gs_usuario & "'")
            If dtCorreo.Rows.Count > 0 Then
                If sCuentas.ToString.Length > 0 Then sCuentas = sCuentas & ","
                sCuentas = sCuentas & dtCorreo.Rows(0).Item("correo").ToString
            End If


            enviarcorreo(sCuentas, "Notificaciones Umbral", "Creacion de Producto " & Me.txt_codigo_producto.Text & "-" & Me.txt_descripcion.Text)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub



    Private Sub enviarcorreo(psCuentaCorreo As String, psUsuarioActual As String, psSubject As String)


        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2

        Dim sta_mer As String
        Dim nrow As Integer
        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim ls_sql As String
        Dim sBody As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Message = New System.Net.Mail.MailMessage()
            'Dim adjuntar As New Net.Mail.Attachment(ruta)
            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
            SMTP1.EnableSsl = True





            Dim iCount As Integer = 0

            sBody = "<tr></tr><tr>"
            sBody = sBody & "Buen dia:  " & Me.cmb_solicitante.Text
            sBody = sBody & "</tr>"
            sBody = sBody & "<tr> "
            sBody = sBody & "</tr>"
            sBody = sBody & "<tr>"
            sBody = sBody & "Se Informa que se ha creado el Siguiente Producto"

            ' dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & psUsuarioActual & "'")

            Try
                '    sBody = sBody & StrConv(dt.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
            Catch ex As Exception
            End Try

            sBody = sBody & "</tr>"
            sBody = sBody & "<table><font size=2>"
            ' For Each dr As DataRow In pdtPedidos.Rows
            Try


                iCount += 1
                sBody = sBody & "<tr>"
                'sBody = sBody & "<td>Buen Dia </td>"
                'sBody = sBody & "</tr>"

                'sBody = sBody & "<td>Empresa</td>"
                sBody = sBody & "<td>Empresa  " & gs_empresa & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"
                sBody = sBody & "<td>Codigo " & Me.txt_codigo_producto.Text & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"

                sBody = sBody & "<td>Descripcion " & Me.txt_descripcion.Text & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"
                sBody = sBody & "<td>Marca " & Me.cmb_marca.SelectedValue.ToString() & "</td>"

                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"
                sBody = sBody & "<td>Proveedor " & Me.cmb_proveedor.SelectedValue.ToString() & "</td>"
                sBody = sBody & "</tr>"


            Catch ex As Exception


            Finally
            End Try
            'Next
            sBody = sBody & "</table>"

            'l_srv_salida.Credentials = New System.Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv");

            dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            ''SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            'SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

            Message.[To].Add(psCuentaCorreo)
            'Message.[To].Add("coscal@umbral.com.gt")
            Message.From = New System.Net.Mail.MailAddress("notificacion@umbralcorp.com", "Notificaciones Umbral", System.Text.Encoding.UTF8) 'Quien envía el e-mail
            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = sBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True
            'Message.Attachments.Add(adjuntar)

            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try

    End Sub




    Private Sub frm_solicitud_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Pestaña Listado por Modificación: permisos + autocarga
        Try
            PermisosActProductos.Cargar()
            If Not PermisosActProductos.ColumnaUsadaEnAlguna("aprobarCambios") Then
                TabControl1.TabPages.Remove(TabPage4)
            Else
                Try : CargarSolicitudesCambio() : Catch : End Try
            End If
        Catch
            Try : TabControl1.TabPages.Remove(TabPage4) : Catch : End Try
        End Try

        cb_campos.SelectedIndex = 0
        cb_condicion.SelectedIndex = cb_condicion.Items.Count - 1
        txt_filtro.Text = 0
        If gs_empresa = "VINOTECA" Then
            Me.lbl_NombreCorto.Visible = True
            Me.txtCodigoDistribuidora.Visible = True
        Else
            Me.lbl_NombreCorto.Visible = False
            Me.txtCodigoDistribuidora.Visible = False
        End If

        hacerFiltro()

        Incializar_Tablas()
        Llenar_Grid_LP()
        Llenar_Combos()
        Llenar_Solicitudes()

        Ingreso_Nuevo()

        AplicarEstiloUmbral()
        proceso_inicial = False
    End Sub

    Private Sub dg_packs_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_packs.CurrentCellChanged
        newcurrentrow = dg_packs.CurrentCell.RowNumber
        newcurrentcol = dg_packs.CurrentCell.ColumnNumber

        Dim ls_codigo As String = String.Empty
        Dim ls_descripcion As String = String.Empty

        Try
            ls_codigo = dg_packs(oldcurrentrow, 0).ToString()
        Catch ex As Exception
        End Try

        Dim dtr As New DataTable

        If ls_codigo = "+" Then
            If Not proceso_insercion Then
                Dim frm_busqueda As New frm_busqueda_general

                frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                frm_busqueda.lista_campos = "Cast(0 as bit) as agregar, producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"


                frm_busqueda.txt_buscar1.Focus()
                frm_busqueda.dg_buscar.ReadOnly = False
                frm_busqueda.btn_seleccion_multipe.Visible = True
                frm_busqueda.Btn_Aceptar.Visible = True
                frm_busqueda.ShowDialog(Me)

                dtr = frm_busqueda.dt

                frm_busqueda.Dispose()
            End If

            Dim dr, dr_aux As DataRow
            Dim icount As Integer = 0

            proceso_insercion = True

            For Each dr In dtr.Rows
                If dr.Item("agregar") = True Then
                    icount += 1
                    If icount = 1 Then
                        ls_codigo = dr.Item("producto")
                        dg_packs(oldcurrentrow, 0) = ls_codigo

                    Else
                        dr_aux = Ods.Tables("productos_packs").NewRow
                        dr_aux.Item("producto") = dr.Item("producto")

                        ls_descripcion = Obtener_Producto(dr.Item("producto"))
                        If ls_descripcion.ToString.Length > 1 Then
                            dr_aux.Item("descripcion") = ls_descripcion
                            dr_aux.Item("cantidad") = 0
                            Try
                                Ods.Tables("productos_packs").Rows.Add(dr_aux)
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            Next

            Dim reviso_todo As Boolean = False

            While reviso_todo = False
                reviso_todo = True

                For ii As Integer = 0 To Ods.Tables("productos_packs").Rows.Count - 1
                    If Ods.Tables("productos_packs").Rows(ii).IsNull("producto") Then
                        Ods.Tables("productos_packs").Rows(ii).Delete()
                        reviso_todo = False
                        Exit For
                    End If
                Next
            End While

            Alinear_Grid_Productos()
            dg_packs(oldcurrentrow, 0) = ls_codigo

            proceso_insercion = False
        End If

        If okToValidate And Not DatoValidoProducto(oldcurrentrow, oldcurrentcol, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            If oldcurrentcol = 1 Then 'La Validacion  del codigo del producto la hago en el nombre del producto
                dg_packs.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
            Else
                dg_packs.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            End If
            okToValidate = True
        Else
            oldcurrentrow = newcurrentrow
            oldcurrentcol = newcurrentcol
            If newcurrentcol = 1 Then
                SendKeys.Send("{Tab}")
            End If
        End If

    End Sub

    Private Sub dg_listado_solicitudes_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_listado_solicitudes.DockChanged

    End Sub

    Private Sub dg_listado_solicitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_listado_solicitudes.DoubleClick
        Dim nrow, numero_solicitud As Integer
        Try
            nrow = dg_listado_solicitudes.CurrentCell.RowNumber
            numero_solicitud = dg_listado_solicitudes.Item(nrow, 1)

        Catch ex As Exception
            numero_solicitud = 0
        End Try

        If numero_solicitud > 0 Then
            Ingreso_Nuevo()
            Mostrar_Solicitud(numero_solicitud)
        End If
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Ingreso_Nuevo()
    End Sub

    Private Function pasaValidaciones() As Boolean


        Try

            If txt_descripcion.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado ninguna descripción del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_descripcion.Focus()
                Return False
            End If

            If cmb_solicitante.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado quién solicita este movimiento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_solicitante.Focus()
                Return False
            End If

            If cmb_familia.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado la familia del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_familia.Focus()
                Return False
            End If


            If cmb_marca.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado la marca del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_marca.Focus()
                Return False
            End If

            If cmb_origen.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado el origen del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_origen.Focus()
                Return False
            End If

            If cmb_procedencia.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado la procedencia del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_procedencia.Focus()
                Return False
            End If

            If cmb_proveedor.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado el proveedor del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_proveedor.Focus()
                Return False
            End If

            If cmb_tipo_producto.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado el tipo producto del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_tipo_producto.Focus()
                Return False
            End If

            If cmb_unidad_medida.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha ingresado la unidad de medida del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_unidad_medida.Focus()
                Return False
            End If
            txt_medida_litros.Text = Val(txt_medida_litros.Text)

            If txt_medida_litros.Text.Trim.Length > 2 Then
                If Val(txt_medida_litros.Text) = 0 Then
                    MessageBox.Show("No es permitido ingresar letras.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_medida_litros.Focus()
                    Return False
                End If
                If Val(txt_medida_litros.Text) > 10 Then
                    MessageBox.Show("Revisar Los Litros del Producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_medida_litros.Focus()
                    Return False

                End If
            End If

            If Ods.Tables("listaPrecio").Rows.Count <= 0 Then
                MessageBox.Show("Como mínimo debe agregarle un precio al producto.", "Falta Precio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dg_listaprecios.Focus()
                Return False
            End If


            If gs_empresa.StartsWith("dmar") Or gs_empresa.StartsWith("cod") Or gs_empresa.StartsWith("diuva") Then
                If Me.txt_precio_sugerido.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Asignar Precio Sugerido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_precio_sugerido.Focus()
                    Return False
                End If

                'If Me.txt_peso.Text.Trim.Length = 0 Then
                '    MessageBox.Show("Debe Asignar Peso (KL*Unidades)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txt_peso.Focus()
                '    Return False
                'Else
                '    If Val(Me.txt_peso.Text) < 0.1 Then
                '        MessageBox.Show("Debe Asignar Peso (KL*Unidades)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        txt_peso.Focus()
                '        Return False
                '    End If
                'End If

                'If Me.txt_volumen.Text.Trim.Length = 0 Then
                '    MessageBox.Show("Debe Asignar Volumen (Mts3 * U)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txt_volumen.Focus()
                '    Return False
                'Else
                '    If Val(Me.txt_volumen.Text) < 0.01 Then
                '        MessageBox.Show("Debe Asignar Volumen (Mts3 * U)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        txt_volumen.Focus()
                '        Return False
                '    End If
                'End If

                If Me.txt_medida_litros.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Asignar Medida (Litros)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_medida_litros.Focus()
                    Return False
                Else
                    If Val(Me.txt_medida_litros.Text) < 0.1 Then
                        MessageBox.Show("Debe Asignar Medida (Litros)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txt_medida_litros.Focus()
                        Return False
                    End If
                End If
            End If

            If Me.txt_codigo_barras.Text.Length = 0 Then
                MessageBox.Show("Debe Asignar Codigo de Barras", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_codigo_barras.Focus()
                Return False
            End If

            If Me.utiliza_lote.SelectedItem Is Nothing Then
                MessageBox.Show("Debe seleccionar si el producto utiliza LOTE (SI/NO).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.utiliza_lote.Focus()
                Return False
            End If

            If Me.utiliza_añada.SelectedItem Is Nothing Then
                MessageBox.Show("Debe seleccionar si el producto utiliza AÑADA (SI/NO).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.utiliza_añada.Focus()
                Return False
            End If

            If Val(Me.txt_unidades_x_caja.Text) <= 0 Then
                MessageBox.Show("Debe ingresar Unidades x Caja (valor mayor a 0).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_unidades_x_caja.Focus()
                Return False
            End If

            If Val(Me.txt_unidades_x_caja.Text) > 99 Then
                If MessageBox.Show("El valor de Unidades x Caja es mayor a 99 (" & Me.txt_unidades_x_caja.Text & "). ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Me.txt_unidades_x_caja.Focus()
                    Return False
                End If
            End If



        Catch ex As Exception

            Return False
        End Try
        Return True
    End Function

    Private Function validacionesGuardar() As Boolean
        Dim lbValido As Boolean = True
        Dim clsGen As New ClasesGenerales.General

        Try
            If Me.cmbBU.SelectedValue = "" Then
                MessageBox.Show("Para Continuar debe Seleccionar BU", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbValido = False
            End If
        Catch ex As Exception
            MessageBox.Show("Para Continuar debe Seleccionar BU", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lbValido = False
        End Try

        If Len(Me.txt_codigo_barras.Text) < 4 Then
            MessageBox.Show("Para Continuar debe Agregar Codigo de Barra", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lbValido = False
        ElseIf Len(Me.txt_codigo_barras.Text) < 8 Then
            If MessageBox.Show("Esta Seguro del Codigo de Barra, Esto Puede Causar Inconsistencias!!", "Validaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                lbValido = False
            End If
        End If


        '(c) Validar Productos interempresas


        Try
            If Me.txt_proveedor.Text.ToLower = "codicasa" Or
                Me.txt_proveedor.Text.ToLower = "diuva" Or
                 Me.txt_proveedor.Text.ToLower = "distribuidora marte" Or
                 (Me.txt_proveedor.Text.ToLower = "vinoteca" And gs_empresa <> "vinoteca") Then


                Dim lsSQL As String = "pa_sel_um_producto '" & Me.txt_proveedor.Text.ToLower.Replace("distribuidora marte", "dmarte1") & "','" & Me.txtCodigoDistribuidora.Text & "'"
                Dim dt As DataTable = clsGen.selectQuery("FlexLine", lsSQL)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se localizo producto Origen, Por favor verificar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lbValido = False
                    clsGen.Escribir_Log(lsSQL)
                End If


            End If

        Catch ex As Exception

        End Try






        Return lbValido



    End Function

    Private Sub proceso_guardar()
        If Not pasaValidaciones() Then Exit Sub

        If btn_guardar.Text.ToLower = "guardar" Then
            If MessageBox.Show("¿Esta Seguro de Guardar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If validacionesGuardar() Then


                    If Guardar_Solicitud() = 0 Then
                        If MessageBox.Show("Solicitud Guardada con Exito, Desea Mantener Maestros Pantalla", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            Ingreso_Nuevo_Maestros()
                        Else
                            Ingreso_Nuevo()
                        End If


                    Else
                        MessageBox.Show("Se produjo un error al guardar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        Else
            'Verificar Estados
            If VerificarEstados() Then


                If Modificar_Solicitud() = 0 Then
                    Dim cOtrans As New Transaccional.Conexion("Corporativo")
                    Try
                        cOtrans.open()
                        Guardar_estado_Solicitud(ncod_solicitud, 4, cOtrans)
                    Catch ex As Exception
                    Finally
                        cOtrans.cerrar()
                        cOtrans = Nothing
                    End Try


                    MessageBox.Show("Solicitud Modificada con Exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Ingreso_Nuevo()
                Else
                    MessageBox.Show("Se produjo un error al modificar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Esta Solicitud No se Puede Modificar", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Llenar_Solicitudes()
    End Sub


    ' Replica el producto DIUVA en VINOTECA cuando se procesa exitosamente.
    ' Recibe cod_solicitud por parametro porque Ingreso_Nuevo puede haber reseteado el form.
    ' Lee TODO desde BD para no depender de variables del form (gs_empresa, cmb_familia, etc.)
    Private Sub ReplicarProductoEnVinoteca(codSolicitudParam As Integer)
        Try
            If codSolicitudParam <= 0 Then Return

            ' Leer todo desde la BD usando cod_solicitud
            Dim empresaSol As String = ""
            Dim familiaSol As String = ""
            Dim usuarioApr As String = ""
            Dim codFlexAsignado As String = ""
            Try
                Dim cnCorp As New Transaccional.Conexion("Corporativo")
                cnCorp.open()
                Dim sqlGet As String = "SELECT empresa, familia, usuario_aprobo, cod_flex FROM flexline.inv_producto_solicitud WHERE cod_solicitud = " & codSolicitudParam
                Dim dt As DataTable = cnCorp.Obtiene(sqlGet)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("empresa")) Then empresaSol = dt.Rows(0)("empresa").ToString().Trim()
                    If Not IsDBNull(dt.Rows(0)("familia")) Then familiaSol = dt.Rows(0)("familia").ToString().Trim()
                    If Not IsDBNull(dt.Rows(0)("usuario_aprobo")) Then usuarioApr = dt.Rows(0)("usuario_aprobo").ToString().Trim()
                    If Not IsDBNull(dt.Rows(0)("cod_flex")) Then codFlexAsignado = dt.Rows(0)("cod_flex").ToString().Trim()
                End If
                cnCorp.close()
            Catch
                Return
            End Try

            ' Filtros (todos usando datos leidos de BD, no del form)
            ' Replica a VINOTECA para TODAS las familias siempre que el producto
            ' haya sido creado (cod_flex asignado) en DIUVA y lo apruebe pplamport
            If UCase(empresaSol) <> "DIUVA" Then Return
            If codFlexAsignado = "" Then Return
            If UCase(usuarioApr) <> "PPLAMPORT" Then Return

            ' Cumple condiciones: replicar
            Dim resultado As String = ""
            Dim cnFlex As New Transaccional.Conexion("FlexLine")
            Try
                cnFlex.open()
                Dim sqlSp As String = "EXEC flexline.pa_ins_um_producto_interempresas 'DIUVA', '" & codFlexAsignado & "', 'VINOTECA', 'pplamport'"
                cnFlex.Actualiza(sqlSp)
                resultado = "OK " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " (SP replico - solo Cuentadesc/Cuentadev de DIUVA)"
                cnFlex.close()
            Catch ex As Exception
                resultado = "ERROR: " & ex.Message.Substring(0, Math.Min(220, ex.Message.Length))
            End Try

            ' Loguear
            Try
                Dim cnLog As New Transaccional.Conexion("Corporativo")
                cnLog.open()
                Dim sqlLog As String = "UPDATE flexline.umb_asignacion_cuentas_log SET replicado_vinoteca='" & resultado.Replace("'", "''") & "' WHERE cod_solicitud=" & codSolicitudParam
                cnLog.Actualiza(sqlLog)
                cnLog.close()
            Catch
            End Try

            ' Si fallo, notificar a Juan
            If resultado.StartsWith("ERROR") Then
                Try
                    EnviarCorreoSolicitudManual(codSolicitudParam, "", empresaSol, familiaSol, "", "Replicacion DIUVA->VINOTECA fallo: " & resultado)
                Catch
                End Try
            End If
        Catch
        End Try
    End Sub

    ' Genera el nombre de receta para productos compuestos/packs en auto-proceso.
    ' Algoritmo:
    '   1. Toma la descripcion del producto, la pasa a MAYUSCULAS y reemplaza espacios por "_"
    '   2. Construye el candidato base: "R_" + tantos chars como quepan en 20
    '   3. Si ya existe ese nombre en flexline.prodReceta para la empresa actual,
    '      agrega un numero incremental al final (2, 3, 4, ..., 99, 100, ...)
    '   4. El numero siempre debe caber entero. Si crece, se recorta la descripcion
    '      por la derecha para liberar el espacio necesario.
    ' Maximo 20 caracteres (MaxLength de txt_nombre_receta y varchar(20) en BD).
    ' Ejemplos:
    '   "VT2690 ALIMENTOS Y BEBIDAS PARA REUNION" -> "R_VT2690_ALIMENTOS_Y"  (1ra vez)
    '   (si ya existe)                            -> "R_VT2690_ALIMENTOS_2"  (n=2)
    '   (si ya hasta n=9)                         -> "R_VT2690_ALIMENTOS10"  (n=10, sin separador)
    '   (si ya hasta n=99)                        -> "R_VT2690_ALIMENTO100"  (n=100, recorta 1 char mas)
    Private Function GenerarNombreReceta(descripcion As String) As String
        Const MAX_LEN As Integer = 20
        Const PREFIX As String = "R_"

        Try
            ' 1) Normalizar descripcion: trim + UPPER + espacios -> "_"
            Dim desc As String = If(descripcion, "").Trim().ToUpper().Replace(" ", "_")
            If desc.Length = 0 Then Return PREFIX

            ' 2) Candidato base (sin numero)
            Dim maxDescLen As Integer = MAX_LEN - PREFIX.Length
            Dim descTrunc As String = If(desc.Length > maxDescLen, _
                                         desc.Substring(0, maxDescLen), desc)
            Dim candidato As String = PREFIX & descTrunc

            ' 3) Si el base no existe, listo
            If Not RecetaExiste(candidato) Then Return candidato

            ' 4) Buscar siguiente numero disponible (2..9999)
            For n As Integer = 2 To 9999
                Dim nStr As String = n.ToString()
                Dim descLen As Integer = MAX_LEN - PREFIX.Length - nStr.Length
                If descLen < 0 Then Exit For ' Sanity check
                Dim descN As String = If(desc.Length > descLen, _
                                          desc.Substring(0, descLen), desc)
                Dim cand As String = PREFIX & descN & nStr
                If Not RecetaExiste(cand) Then Return cand
            Next

            ' Si llegamos aqui (>9999 duplicados, caso extremo) devolvemos el base.
            ' La validacion downstream rechazara el duplicado -> solicitud queda manual.
            Return candidato
        Catch
            Return PREFIX
        End Try
    End Function

    ' Helper: consulta si una receta ya existe en flexline.prodReceta para la empresa actual.
    ' Usa el mismo SP que la validacion del form: pa_var_um_ProdReceta.
    ' Fail-open: si la query falla (red/BD), devuelve False (no bloquea generacion).
    Private Function RecetaExiste(nombreReceta As String) As Boolean
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim sql As String = "pa_var_um_ProdReceta '" & _
                gs_empresa.Replace("'", "''") & "','" & _
                nombreReceta.Replace("'", "''") & "'"
            Dim dt As DataTable = clsGen.selectQuery("FlexLine", sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return False
        End Try
    End Function

    Private Sub procesarProducto(ByRef pbVisible As Boolean)
        Dim codSolGuardado As Integer = ncod_solicitud
        Try


            Dim frm_procesar As New frm_procesar_productos

            frm_procesar.codigo_barra = txt_codigo_barras.Text
            frm_procesar.familia = cmb_familia.Text
            frm_procesar.impuesto_dai = Ods.Tables("cat_impuesto")
            frm_procesar.dr_seleccion = drSeleccion
            frm_procesar.cod_producto = txt_codigo_producto.Text
            frm_procesar.d_accion = cmbBU.Text
            frm_procesar.indice_dai = cmb_dai.SelectedIndex
            frm_procesar.txt_pais_compra.Text = txt_procedencia.Text
            frm_procesar.dt_precios = Ods.Tables("ListaPrecio")
            frm_procesar.dt_productos_pack = Ods.Tables("productos_packs")
            frm_procesar.no_solicitud = Val(lbl_numero.Text)
            frm_procesar.tipo = "creacion" 'IIf(cmbBU.Text.ToLower = "alta", "creacion", "modificacion")
            frm_procesar.lbl_nombre_producto.Text = Me.txt_descripcion.Text
            frm_procesar.bu = Me.cmbBU.Text


            frm_procesar.serie = If(Me.utiliza_añada.SelectedItem IsNot Nothing AndAlso Me.utiliza_añada.SelectedItem.ToString() = "SI", "S", "N")
            frm_procesar.lote = If(Me.utiliza_lote.SelectedItem IsNot Nothing AndAlso Me.utiliza_lote.SelectedItem.ToString() = "SI", "S", "N")

            ' Pasar tipo_proveedor a frm_procesar para auto-marcar IMPUESTO DISTRIBUCION
            ' Si el usuario no eligio tipo_proveedor, se pasa vacio (no se asume LOCAL).
            ' inicializarForma evalua (tipo_proveedor = "INTERNACIONAL") para marcar IMP. DISTRIB.,
            ' asi que un valor vacio o LOCAL deja el checkbox desmarcado igual (comportamiento correcto).
            frm_procesar.tipo_proveedor = If(Me.cmb_tipo_proveedor.SelectedItem IsNot Nothing, Me.cmb_tipo_proveedor.SelectedItem.ToString(), "")


            If pbVisible Then
                ' Caso MANUAL: precargar el Nombre de Receta antes de mostrar el dialogo,
                ' igual que se precargan las cuentas. Si la solicitud lleva receta/pack,
                ' el campo txt_nombre_receta queda lleno (y visible via inicializarForma en el
                ' Load del form) para que el usuario solo de "Procesar". No se cambia nada mas.
                ' inicializarForma() solo hace visible el campo, NO sobrescribe el .Text,
                ' por lo que el valor asignado aqui (antes del ShowDialog) se conserva.
                ' Formato: R_<numero>_<XX>_<YY>  (mismo helper que el path automatico).
                ' Si no tiene packs, no se asigna nada (queda en blanco) y todo sigue igual.
                Dim tienePackManual As Boolean = False
                Try
                    tienePackManual = (Ods.Tables("productos_packs") IsNot Nothing _
                                       AndAlso Ods.Tables("productos_packs").Rows.Count > 0)
                Catch
                End Try

                If tienePackManual Then
                    frm_procesar.txt_nombre_receta.Text = GenerarNombreReceta(Me.txt_descripcion.Text)
                End If

                If frm_procesar.ShowDialog = DialogResult.OK Then
                    Me.txt_codigo_producto.Text = frm_procesar.txt_codigo_producto.Text
                    Dim cOtrans As New Transaccional.Conexion("Corporativo")
                    Try
                        cOtrans.open()
                        Guardar_estado_Solicitud(ncod_solicitud, 7, cOtrans)

                    Catch ex As Exception
                    Finally
                        cOtrans.close()
                        cOtrans = Nothing

                    End Try

                    MessageBox.Show("Se realizó con exito el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    guardarAviso()
                    Ingreso_Nuevo()
                    Llenar_Solicitudes()

                Else
                    MessageBox.Show("No se pudo realizar el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                '(c) 20200916
                'Creacion Automatica

                ' Solo asignar nombre de receta cuando la solicitud lleva receta/pack.
                ' inicializarForma() prende el indicador "Compuesto" (idx 7) si hay packs,
                ' y pasaValidaciones solo exige nombre de receta cuando ese indicador esta marcado.
                ' Formato: R_<numero>_<XX>_<YY>
                '   Ej: "VT2690 ALIMENTOS Y BEBIDAS PARA REUNION" -> "R_2690_AL_BE"
                ' Si no tiene packs, no se asigna nada (queda en blanco) y todo sigue igual.
                Dim tienePack As Boolean = False
                Try
                    tienePack = (Ods.Tables("productos_packs") IsNot Nothing _
                                 AndAlso Ods.Tables("productos_packs").Rows.Count > 0)
                Catch
                End Try

                If tienePack Then
                    frm_procesar.txt_nombre_receta.Text = GenerarNombreReceta(Me.txt_descripcion.Text)
                End If

                frm_procesar.inicializarForma()
                frm_procesar.ProcesarSolicitud()
                Me.txt_codigo_producto.Text = frm_procesar.txt_codigo_producto.Text
                Dim cOtrans As New Transaccional.Conexion("Corporativo")
                Try
                    cOtrans.open()
                    Guardar_estado_Solicitud(ncod_solicitud, 7, cOtrans)

                Catch ex As Exception
                Finally
                    cOtrans.close()
                    cOtrans = Nothing

                End Try

                'MessageBox.Show("Se realizó con exito el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                guardarAviso()
                'Ingreso_Nuevo()
                'Llenar_Solicitudes()



            End If

            ' Replicar a VINOTECA si aplica (usa el codSolicitud guardado al inicio)
            Try
                ReplicarProductoEnVinoteca(codSolGuardado)
            Catch
            End Try

            frm_procesar.Dispose()

            frm_procesar = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        proceso_guardar()
    End Sub


    Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txt_codigo_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.LostFocus
        If txt_codigo_producto.Text.Length > 0 Then
            If Buscar_Producto() Then
                cmbBU.Enabled = False
                txt_codigo_producto.Enabled = False
            End If
        End If
    End Sub

    ' Envia correo de aviso cuando una solicitud aprobada queda pendiente de revision manual.
    ' Tambien registra el envio en umb_asignacion_cuentas_log (columnas correo_enviado_a, correo_fecha, motivo_manual).
    Private Sub EnviarCorreoSolicitudManual(codSolicitud As Integer, numero As String, empresa As String, familia As String, descripcion As String, motivo As String)
        Dim destinatario As String = "juan.jimenez@umbralcorp.com"
        Dim envioOK As Boolean = False
        Try
            Dim Message As New System.Net.Mail.MailMessage()
            Dim SMTP1 As New System.Net.Mail.SmtpClient()
            Dim clsGen As New ClasesGenerales.General

            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com"
            SMTP1.EnableSsl = True

            Dim dtCred As DataTable = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            SMTP1.Credentials = New Net.NetworkCredential(dtCred.Rows(0).Item("mail").ToString(), dtCred.Rows(0).Item("pwd").ToString())

            Message.From = New System.Net.Mail.MailAddress("notificacion@umbralcorp.com", "Notificaciones Umbral", System.Text.Encoding.UTF8)
            Message.[To].Add(destinatario)
            Message.Subject = "[Umbright] Solicitud pendiente de revision manual - #" & numero
            Message.SubjectEncoding = System.Text.Encoding.UTF8
            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.IsBodyHtml = True
            Message.Priority = System.Net.Mail.MailPriority.Normal

            Dim sBody As String = "<html><body style='font-family:Arial, sans-serif;'>"
            sBody &= "<p>Una solicitud aprobada quedo <b>pendiente de revision manual</b> antes de ser creada en FlexLine.</p>"
            sBody &= "<p>Por favor revisa y procesa cuando sea posible.</p>"
            sBody &= "<table style='border-collapse:collapse; border:1px solid #ccc;'>"
            sBody &= "<tr style='background:#f0f0f0;'><td style='padding:6px;'><b>Numero:</b></td><td style='padding:6px;'>" & numero & "</td></tr>"
            sBody &= "<tr><td style='padding:6px;'><b>Empresa:</b></td><td style='padding:6px;'>" & empresa & "</td></tr>"
            sBody &= "<tr style='background:#f0f0f0;'><td style='padding:6px;'><b>Familia:</b></td><td style='padding:6px;'>" & familia & "</td></tr>"
            sBody &= "<tr><td style='padding:6px;'><b>Producto:</b></td><td style='padding:6px;'>" & descripcion & "</td></tr>"
            sBody &= "<tr style='background:#f0f0f0;'><td style='padding:6px;'><b>Aprobado por:</b></td><td style='padding:6px;'>" & gs_usuario & "</td></tr>"
            sBody &= "<tr><td style='padding:6px;'><b>Fecha:</b></td><td style='padding:6px;'>" & DateTime.Now.ToString("dd/MM/yyyy HH:mm") & "</td></tr>"
            sBody &= "<tr style='background:#fff4e5;'><td style='padding:6px;'><b>Motivo:</b></td><td style='padding:6px;'>" & motivo & "</td></tr>"
            sBody &= "</table>"
            sBody &= "<p style='color:#777; font-size:11px;'>Correo automatico enviado por el sistema Umbright. No responda este mensaje.</p>"
            sBody &= "</body></html>"
            Message.Body = sBody

            SMTP1.Send(Message)
            envioOK = True
        Catch ex As Exception
            ' Si falla el envio, no abortamos. Solo registramos en el log que fallo.
            motivo = motivo & " | Error envio correo: " & ex.Message.Substring(0, Math.Min(100, ex.Message.Length))
        End Try

        ' Registrar en log (haya o no haya fallado el envio del correo)
        Try
            Dim cOtransLog As New Transaccional.Conexion("Corporativo")
            cOtransLog.open()
            Dim destinatarioSql As String = If(envioOK, destinatario, "ERROR: no enviado")
            Dim sqlLog As String = "UPDATE flexline.umb_asignacion_cuentas_log SET " &
                "correo_enviado_a = '" & destinatarioSql.Replace("'", "''") & "', " &
                "correo_fecha = GETDATE(), " &
                "motivo_manual = '" & motivo.Replace("'", "''") & "' " &
                "WHERE cod_solicitud = " & codSolicitud
            cOtransLog.Actualiza(sqlLog)
            cOtransLog.close()
        Catch
        End Try
    End Sub

    Private Sub btn_aprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aprobar.Click
        ' Validacion del Tipo de Proveedor (no aplica para TECNO):
        '   - Se busca en flexline.gen_tabcod si el TIPO DE PRODUCTO aplica al
        '     impuesto de distribucion: empresa actual + tipo='IMP_DISTRIB'
        '     + codigo=tipo_producto + valor1 > 0.001.
        '   - Si existe esa fila => tipo_proveedor es OBLIGATORIO.
        '       - Si INTERNACIONAL: medida_litros > 0 y precio_sugerido > 0
        '       - Si LOCAL: no se valida medida ni precio (el impuesto no se paga)
        '   - Si NO existe (o la consulta falla) => tipo_proveedor queda opcional.
        If gs_empresa <> "TECNO" Then
            Dim tipoProdCheck As String = If(cmb_tipo_producto.Text, "").Trim()
            Dim requiereTipoProv As Boolean = False
            If tipoProdCheck.Length > 0 Then
                Try
                    Dim clsGenChk As New ClasesGenerales.General
                    Dim sqlCheck As String = "SELECT TOP 1 1 AS aplica " & _
                        "FROM flexline.gen_tabcod WITH (NOLOCK) " & _
                        "WHERE empresa = '" & gs_empresa.Replace("'", "''") & "' " & _
                          "AND tipo = 'IMP_DISTRIB' " & _
                          "AND codigo = '" & tipoProdCheck.Replace("'", "''") & "' " & _
                          "AND valor1 > 0.00100000"
                    Dim dtChk As DataTable = clsGenChk.selectQuery("FlexLine", sqlCheck)
                    requiereTipoProv = (dtChk IsNot Nothing AndAlso dtChk.Rows.Count > 0)
                Catch
                    ' Si falla la consulta (red, BD), no bloqueamos la aprobacion.
                    requiereTipoProv = False
                End Try
            End If

            If requiereTipoProv Then
                If Me.cmb_tipo_proveedor.SelectedItem Is Nothing Then
                    MessageBox.Show("El Tipo de Producto '" & tipoProdCheck & "' requiere que indique Tipo de Proveedor (LOCAL/INTERNACIONAL) antes de aprobar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmb_tipo_proveedor.Focus()
                    Return
                End If
                If Me.cmb_tipo_proveedor.SelectedItem.ToString() = "INTERNACIONAL" Then
                    If Val(Me.txt_medida_litros.Text) <= 0 Then
                        MessageBox.Show("El Tipo de Producto '" & tipoProdCheck & "' con proveedor INTERNACIONAL requiere Medida (Litros) mayor a 0.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txt_medida_litros.Focus()
                        Return
                    End If
                    If Val(Me.txt_precio_sugerido.Text) <= 0 Then
                        MessageBox.Show("El Tipo de Producto '" & tipoProdCheck & "' con proveedor INTERNACIONAL requiere Precio Sugerido mayor a 0.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txt_precio_sugerido.Focus()
                        Return
                    End If
                End If
            End If
        End If
        If MessageBox.Show("Esta Seguro de Aprobar Esta Solicitud", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim cOtrans As New Transaccional.Conexion("Corporativo")
            Try
                cOtrans.open()
                Guardar_estado_Solicitud(ncod_solicitud, 5, cOtrans) 'Apruebo
                Guardar_estado_Solicitud(ncod_solicitud, 6, cOtrans) 'Lo pongo en espera de operar en FlexLine

                '(c) 20200916
                'Crear Producto

                If gs_empresa = "TECNO" Then

                    procesarProducto(False)
                End If

                ' Auto-procesar TODAS las empresas (excepto TECNO que ya tiene su bloque arriba)
                ' Reglas:
                '   - Las familias en familiasManuales SIEMPRE quedan manuales (revision)
                '   - DMARTE1 no usa cuentas: procesa directo
                '   - Resto de empresas: requieren cuentas asignadas en el log
                '   - Si queda manual, se envia correo de aviso
                ' Todas las familias son auto-procesables (no hay rama manual por familia)
                ' Si al final NO llego a estado 7 por cualquier motivo (sin cuentas en log,
                ' falla silenciosa en procesarProducto, etc.) => SIEMPRE enviar correo a Juan
                If gs_empresa <> "TECNO" Then
                    Dim quedoManual As Boolean = False
                    Dim motivoManual As String = ""
                    Dim puedeAutoProcesar As Boolean = False

                    If gs_empresa = "DMARTE1" Then
                        ' DMARTE1 no usa cuentas: procesar directo
                        puedeAutoProcesar = True
                    Else
                        ' Resto de empresas: requieren cuentas sugeridas en el log
                        Try
                            Dim sqlChk As String = "SELECT TOP 1 sug_cta_compra FROM flexline.umb_asignacion_cuentas_log WITH (NOLOCK) WHERE cod_solicitud = " & ncod_solicitud & " AND sug_cta_compra IS NOT NULL"
                            Dim dtChk As DataTable = cOtrans.Obtiene(sqlChk)
                            If dtChk IsNot Nothing AndAlso dtChk.Rows.Count > 0 Then
                                puedeAutoProcesar = True
                            End If
                        Catch
                        End Try
                    End If

                    If puedeAutoProcesar Then
                        procesarProducto(False)
                        ' Verificar si REALMENTE llego a estado 7. Si no, hubo falla silenciosa.
                        Try
                            Dim sqlEstado As String = "SELECT estado FROM flexline.inv_producto_solicitud WITH (NOLOCK) WHERE cod_solicitud = " & ncod_solicitud
                            Dim dtEstado As DataTable = cOtrans.Obtiene(sqlEstado)
                            If dtEstado IsNot Nothing AndAlso dtEstado.Rows.Count > 0 Then
                                Dim estadoActual As Integer = CInt(dtEstado.Rows(0)(0))
                                If estadoActual <> 7 Then
                                    quedoManual = True
                                    motivoManual = "Auto-proceso fallo: la solicitud quedo en estado " & estadoActual & " en vez de 7. Revisar manualmente."
                                End If
                            End If
                        Catch
                        End Try
                    Else
                        quedoManual = True
                        motivoManual = "Sin cuentas asignadas en historico - procesar manualmente"
                    End If

                    ' Si quedo manual por cualquier motivo, enviar correo a Juan
                    If quedoManual Then
                        Try
                            EnviarCorreoSolicitudManual(ncod_solicitud, lbl_numero.Text, gs_empresa, cmb_familia.Text, txt_descripcion.Text, motivoManual)
                        Catch
                        End Try
                    End If
                End If


            Catch ex As Exception
            Finally
                cOtrans.close()
                cOtrans = Nothing

            End Try
            Llenar_Solicitudes()

            MessageBox.Show("Solicitud aprobada exitósamente.", "Aprovación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Ingreso_Nuevo()
        End If
    End Sub


    Private Sub cmb_accion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBU.SelectionChangeCommitted
        'If cmbBU.SelectedItem = "Alta" Then
        '    txt_codigo_producto.Enabled = False
        'Else
        '    txt_codigo_producto.Enabled = True
        'End If
    End Sub

    Private Sub cmb_accion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBU.LostFocus
        'cmbBU.Enabled = False
    End Sub

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click

        procesarProducto(True)

    End Sub

    Private Sub cmb_origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_origen.SelectedIndexChanged
        If cmb_origen.SelectedIndex <= 0 Then Exit Sub

        cmb_procedencia.SelectedIndex = cmb_origen.SelectedIndex
    End Sub


    Private Sub btn_rechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rechazar.Click
        Dim ltxtRechazo As String = String.Empty
        If MessageBox.Show("¿Esta Seguro de Rechazar Esta Solicitud?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            ltxtRechazo = InputBox("Ingrese en motivo por el cual se esta rechazando este producto", "Motivo Rechazo")

            If ltxtRechazo.Trim.Length > 0 Then
                txt_observaciones.Text = " Rechazo " & ltxtRechazo
                Dim cOtrans As New Transaccional.Conexion("Corporativo")
                Try
                    cOtrans.open()
                    Guardar_estado_Solicitud(ncod_solicitud, 22, cOtrans) 'Rechazado
                    Guardar_estado_Solicitud(ncod_solicitud, 4, cOtrans) '(c) 20201209 Para que puedan editarla
                Catch ex As Exception
                Finally
                    cOtrans.close()
                    cOtrans = Nothing
                End Try


                'Modificar_Solicitud()

                Llenar_Solicitudes()

                MessageBox.Show("Solicitud rechazada exitósamente.", "Rechazo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Ingreso_Nuevo()
            Else
                MessageBox.Show("No se puede rechazar sin un motivo.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txt_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_familia.GotFocus
        cmb_familia.BringToFront()
        cmb_familia.Focus()
    End Sub

    Private Sub cmb_familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_familia.LostFocus
        txt_familia.Text = cmb_familia.Text
        txt_familia.BringToFront()
        productoSimilares()
        If txt_familia.Text.ToLower.Equals("vinos") Then
            Me.txtCEPA.Visible = True
            Me.cmbCEPA.Visible = True
            Me.lblCepa.Visible = True
        Else
            Me.txtCEPA.Visible = False
            Me.cmbCEPA.Visible = False
            Me.lblCepa.Visible = False
        End If
    End Sub

    Private Sub txt_tipo_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipo_producto.GotFocus
        cmb_tipo_producto.BringToFront()
        cmb_tipo_producto.Focus()
    End Sub

    Private Sub cmb_tipo_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_tipo_producto.LostFocus
        txt_tipo_producto.Text = cmb_tipo_producto.Text
        txt_tipo_producto.BringToFront()
        productoSimilares()
    End Sub

    Private Sub txt_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_proveedor.GotFocus
        cmb_proveedor.BringToFront()
        cmb_proveedor.Focus()

    End Sub

    Private Sub cmb_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.LostFocus
        txt_proveedor.Text = cmb_proveedor.Text
        txt_proveedor.BringToFront()
        productoSimilares()

        '(c) 20200916
        If Me.txt_proveedor.Text.ToLower = "codicasa" Or
                Me.txt_proveedor.Text.ToLower = "diuva" Or
                 Me.txt_proveedor.Text.ToLower = "distribuidora marte" Or
                 (Me.txt_proveedor.Text.ToLower = "vinoteca" And gs_empresa <> "vinoteca") Then


            Me.txtCodigoDistribuidora.Visible = True
            Me.lbl_NombreCorto.Visible = True

            MessageBox.Show("Este Proveedor Requiere que llene información de Origen", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If

    End Sub

    Private Sub txt_marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_marca.GotFocus
        cmb_marca.BringToFront()
        cmb_marca.Focus()
    End Sub

    Private Sub cmb_marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_marca.LostFocus
        txt_marca.Text = cmb_marca.Text
        txt_marca.BringToFront()
        productoSimilares()
    End Sub

    Private Sub txt_sub_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_sub_tipo.GotFocus
        cmb_sub_tipo.BringToFront()
        cmb_sub_tipo.Focus()
    End Sub

    Private Sub cmb_sub_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_sub_tipo.LostFocus
        txt_sub_tipo.Text = cmb_sub_tipo.Text
        txt_sub_tipo.BringToFront()
    End Sub

    Private Sub txt_origen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_origen.GotFocus
        cmb_origen.BringToFront()
        cmb_origen.Focus()
    End Sub

    Private Sub cmb_origen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_origen.LostFocus
        txt_origen.Text = cmb_origen.Text
        txt_origen.BringToFront()
    End Sub

    Private Sub txt_procedencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_procedencia.GotFocus
        cmb_procedencia.BringToFront()
        cmb_procedencia.Focus()
    End Sub

    Private Sub cmb_procedencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_procedencia.LostFocus
        txt_procedencia.Text = cmb_procedencia.Text
        txt_procedencia.BringToFront()
    End Sub

    Private Sub txt_unidad_medida_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_unidad_medida.GotFocus
        cmb_unidad_medida.BringToFront()
        cmb_unidad_medida.Focus()
    End Sub

    Private Sub cmb_unidad_medida_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_unidad_medida.LostFocus
        txt_unidad_medida.Text = cmb_unidad_medida.Text
        txt_unidad_medida.BringToFront()
    End Sub

    Private Sub txt_unidad_medida_alt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_unidad_medida_alt.GotFocus
        cmb_unidad_medida_alt.BringToFront()
        cmb_unidad_medida_alt.Focus()
    End Sub

    Private Sub cmb_unidad_medida_alt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_unidad_medida_alt.LostFocus
        txt_unidad_medida_alt.Text = cmb_unidad_medida_alt.Text
        txt_unidad_medida_alt.BringToFront()
    End Sub

    Private Sub txt_dai_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dai.GotFocus
        cmb_dai.BringToFront()
        cmb_dai.Focus()
    End Sub

    Private Sub cmb_dai_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_dai.LostFocus
        txt_dai.Text = cmb_dai.Text
        txt_dai.BringToFront()
    End Sub

    Private Sub txt_descripcion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descripcion.Leave
        txt_descripcion.Text = txt_descripcion.Text.Replace("'", "?")
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

        Dim MyTrans As New Transaccional.Conexion("FlexLine")
        Dim SQL_tx As String = String.Empty
        Dim dt As New DataTable
        Dim clsgen As New ClasesGenerales.General

        MyTrans.open()

        Try
            SQL_tx = "SELECT * FROM flexline.v_um_producto_busqueda WHERE validastock = 's' and empresa = '" & gs_empresa & "'"
            If txt_filtro.Text.Length > 0 Then
                SQL_tx += " And " & cb_campos.Text.Replace("marca", "tipo").Replace("proveedor", "subfamilia") &
                         " " & cb_condicion.Text & " "

                If cb_condicion.Text.ToLower = "like" Then

                    SQL_tx += " '%" & txt_filtro.Text & "%'"
                Else

                    SQL_tx += " '" & txt_filtro.Text & "'"
                End If
            End If

            SQL_tx += " Order by producto"
            dt = MyTrans.Obtiene(SQL_tx)

            dgv_productos.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_productos, "", ",empresa,validastock,precioventa,costo,", "", "", ",subfamilia=proveedor,tipo=marca,", ",vigente=20,", ",vigente,producto,glosa,familia,tipoproducto,subfamilia,tipo,subtipo,codbarra,factoralt,", True, True, 175, 0)

        Catch ex As Exception
        Finally
            MyTrans.close()
            MyTrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub productoSimilares()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim sql_tx As String

        Try
            sql_tx = "SELECT top 50 * FROM flexline.v_um_producto_busqueda WHERE validastock = 's' and empresa = '" & gs_empresa & "'"

            If Me.txt_familia.Text.Length > 0 Then
                sql_tx += " and familia  =  '" & Me.txt_familia.Text & "'"
            End If


            If Me.txt_proveedor.Text.Length > 0 Then
                sql_tx += " and subfamilia  =  '" & Me.txt_proveedor.Text & "'"
            End If

            If Me.txt_tipo_producto.Text.Length > 0 Then
                sql_tx += " and tipoproducto  =  '" & Me.txt_tipo_producto.Text & "'"
            End If

            If Me.txt_marca.Text.Length > 0 Then
                sql_tx += " and tipo  =  '" & Me.txt_marca.Text & "'"
            End If

            'If txt_filtro.Text.Length > 0 Then
            '    SQL_tx += " And " & cb_campos.Text.Replace("marca", "tipo").Replace("proveedor", "subfamilia") & _
            '             " " & cb_condicion.Text & " "

            '    If cb_condicion.Text.ToLower = "like" Then

            '        SQL_tx += " '%" & txt_filtro.Text & "%'"
            '    Else

            '        SQL_tx += " '" & txt_filtro.Text & "'"
            '    End If
            'End If

            sql_tx += " Order by producto"
            dt = clsGen.selectQuery("FlexLine", sql_tx)
            'dt = MyTrans.Obtiene(SQL_tx)

            dgvProductoSimilares.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvProductoSimilares, "", ",empresa,validastock,precioventa,costo,path,factor,", "", "", ",factoralt=uxc,subfamilia=proveedor,tipo=marca,", ",vigente=20,factoralt=25,", ",vigente,producto,glosa,familia,tipoproducto,subfamilia,tipo,subtipo,codbarra,factoralt,", True, True, 175, 0)



        Catch ex As Exception

        End Try
    End Sub


    Private Sub dg_listado_solicitudes_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_listado_solicitudes.Navigate

    End Sub

    Private Sub btn_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anular.Click
        Dim ltxtRechazo As String = String.Empty
        If MessageBox.Show("¿Esta Seguro de Anular Esta Solicitud?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            ltxtRechazo = InputBox("Ingrese en motivo por el cual se Anula Esta Solicitud", "Motivo Anulacion")

            If ltxtRechazo.Trim.Length > 0 Then
                txt_observaciones.Text = " Anulacion " & ltxtRechazo & " " & Now.ToString & " " & gs_usuario

                Dim cOtrans As New Transaccional.Conexion("Corporativo")
                Try
                    cOtrans.open()
                    Guardar_estado_Solicitud(ncod_solicitud, 21, cOtrans) 'Anulacion
                Catch ex As Exception
                Finally
                    cOtrans.close()
                    cOtrans = Nothing

                End Try




                Llenar_Solicitudes()

                MessageBox.Show("Solicitud Anulada exitósamente.", "Rechazo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Ingreso_Nuevo()
            Else
                MessageBox.Show("No se puede rechazar sin un motivo.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        imprimirSolicitud()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Aplicar_Filtro()
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
        If e.KeyChar = Chr(13) Then
            Aplicar_Filtro()
        End If
    End Sub


    Private Sub dg_packs_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_packs.Navigate

    End Sub

    Private Sub txt_filtro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_filtro.TextChanged

    End Sub

    Private Sub dgv_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellContentClick

    End Sub

    Private Sub txt_familia_TextChanged(sender As Object, e As EventArgs) Handles txt_familia.TextChanged

    End Sub

    Private Sub txt_proveedor_TextChanged(sender As Object, e As EventArgs) Handles txt_proveedor.TextChanged

    End Sub

    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = dgv_productos.Rows(rowIndex)

                If dgv_productos.Columns(colIndex).Name.ToLower.IndexOf("vigente") > -1 Then
                    Dim valVig As String = ""
                    If dgv_productos.Item(colIndex, rowIndex).Value IsNot Nothing Then
                        valVig = dgv_productos.Item(colIndex, rowIndex).Value.ToString().ToLower()
                    End If
                    If valVig = "n" Then
                        Me.dgv_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgv_productos.Item(colIndex, rowIndex).Style.ForeColor = Color.Red
                        Me.dgv_productos.Item(colIndex, rowIndex).Style.Font = New Font(dgv_productos.Font, FontStyle.Bold)
                    ElseIf valVig = "s" Then
                        Me.dgv_productos.Item(colIndex, rowIndex).Style.ForeColor = Color.DarkGreen
                        Me.dgv_productos.Item(colIndex, rowIndex).Style.Font = New Font(dgv_productos.Font, FontStyle.Bold)
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem.Click
        If tiene_permisos("mer_mantenimento_marcas") Then

            guardarLogB("Acceso Creacion de Marcas", gs_usuario, "frm_solicitud_productos", "mer_mantenimento_marcas")


            Dim oform As New frm_gen_tabcod
            oform.gen_tipo = "PRODUCTO.TIPO"
            oform.ShowDialog()
        End If
    End Sub

    Private Sub txt_origen_TextChanged(sender As Object, e As EventArgs) Handles txt_origen.TextChanged

    End Sub

    Private Sub MenuAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAyuda.Click
        'MessageBox.Show("Ayuda")
    End Sub

    Private Sub dgvProductoSimilares_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvProductoSimilares.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = dgvProductoSimilares.Rows(rowIndex)

                If dgvProductoSimilares.Columns(colIndex).Name.ToLower.IndexOf("vigente") > -1 Then
                    If dgvProductoSimilares.Item(colIndex, rowIndex).Value.ToString.ToLower = "n" Then
                        Me.dgvProductoSimilares.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dg_listado_solicitudes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dg_listado_solicitudes.MouseDoubleClick

    End Sub

    Private Sub utiliza_lote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles utiliza_lote.SelectedIndexChanged
        If Me.utiliza_añada.SelectedItem IsNot Nothing AndAlso Me.utiliza_añada.SelectedItem.ToString() = "SI" AndAlso Me.utiliza_lote.SelectedItem IsNot Nothing AndAlso Me.utiliza_lote.SelectedItem.ToString() = "SI" Then
            MessageBox.Show("Debe Seleccionar entre Control de Lotes y Control de Añanada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.utiliza_lote.SelectedIndex = -1
        End If

    End Sub

    Private Sub utiliza_añada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles utiliza_añada.SelectedIndexChanged
        If Me.utiliza_añada.SelectedItem IsNot Nothing AndAlso Me.utiliza_añada.SelectedItem.ToString() = "SI" AndAlso Me.utiliza_lote.SelectedItem IsNot Nothing AndAlso Me.utiliza_lote.SelectedItem.ToString() = "SI" Then
            MessageBox.Show("Debe Seleccionar entre Control de Lotes y Control de Añanada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.utiliza_añada.SelectedIndex = -1
        End If
    End Sub

    Private Sub txt_descripcion_TextChanged(sender As Object, e As EventArgs) Handles txt_descripcion.TextChanged

    End Sub

    Private Sub txtCEPA_GotFocus(sender As Object, e As EventArgs) Handles txtCEPA.GotFocus
        Me.cmbCEPA.BringToFront()
        Me.cmbCEPA.Focus()
    End Sub

    Private Sub cmbCEPA_LostFocus(sender As Object, e As EventArgs) Handles cmbCEPA.LostFocus
        txtCEPA.Text = cmbCEPA.Text
        txtCEPA.BringToFront()
    End Sub

    Private Sub txt_familia_LostFocus(sender As Object, e As EventArgs) Handles txt_familia.LostFocus

    End Sub

#Region " Listado de Solicitudes por Modificación "

    Private Sub TabControl1_SelectedIndexChanged_Aprobacion(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.TabPages.Contains(TabPage4) AndAlso TabControl1.SelectedTab Is TabPage4 Then
                CargarSolicitudesCambio()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnRefrescarCambios_Click(sender As Object, e As EventArgs) Handles btnRefrescarCambios.Click
        CargarSolicitudesCambio()
    End Sub

    Private Sub btnVerDetalleCambio_Click(sender As Object, e As EventArgs) Handles btnVerDetalleCambio.Click
        MostrarDetalleInline()
    End Sub

    Private Sub MostrarDetalleInline()
        Dim filaMarcada As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In dgvAprobacionCambios.Rows
            If CBool(If(row.Cells("sel").Value, False)) Then
                filaMarcada = row : Exit For
            End If
        Next
        If filaMarcada Is Nothing Then
            MessageBox.Show("Marca el checkbox de una solicitud primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim idSel As Integer = 0
        Try : idSel = CInt(filaMarcada.Cells("id").Value) : Catch : End Try
        If idSel <= 0 Then Return
        CargarDetalleEnPanel(idSel)
    End Sub

    Private Sub chkVerTodosCambios_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTodosCambios.CheckedChanged
        CargarSolicitudesCambio()
    End Sub

    Private Sub dgvAprobacionCambios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAprobacionCambios.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim id As Integer = 0
        Try : id = CInt(dgvAprobacionCambios.Rows(e.RowIndex).Cells("id").Value) : Catch : End Try
        If id <= 0 Then Return
        For Each rr As DataGridViewRow In dgvAprobacionCambios.Rows
            rr.Cells("sel").Value = (rr.Index = e.RowIndex)
        Next
        CargarDetalleEnPanel(id)
    End Sub

    Private Sub CargarSolicitudesCambio()
        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            oScm.open()
            ' Filtrar por empresas con permiso (admin no filtra)
            Dim empresasOk As System.Collections.Generic.HashSet(Of String) = PermisosActProductos.EmpresasConPermiso()
            Dim filtroEmpresas As String = ""
            If empresasOk IsNot Nothing Then
                Dim lst As New System.Collections.Generic.List(Of String)
                For Each emp As String In empresasOk
                    If PermisosActProductos.TienePermiso(emp, "aprobarCambios") Then
                        lst.Add("'" & emp.Replace("'", "''") & "'")
                    End If
                Next
                If lst.Count = 0 Then
                    ConfigurarColumnasGridCambio()
                    lblEstadoCambios.Text = "Sin permiso de aprobación en ninguna empresa."
                    lblEstadoCambios.ForeColor = System.Drawing.Color.DarkRed
                    Return
                End If
                filtroEmpresas = " empresa IN (" & String.Join(",", lst.ToArray()) & ") "
            End If
            Dim filtroEstado As String = If(chkVerTodosCambios.Checked, "", " estado = 'PENDIENTE' ")
            Dim where As String = ""
            If filtroEstado.Length > 0 AndAlso filtroEmpresas.Length > 0 Then
                where = " WHERE " & filtroEstado & " AND " & filtroEmpresas
            ElseIf filtroEstado.Length > 0 Then
                where = " WHERE " & filtroEstado
            ElseIf filtroEmpresas.Length > 0 Then
                where = " WHERE " & filtroEmpresas
            End If
            Dim sql As String =
                "SELECT id, empresa, producto, glosa, valor_anterior, valor_nuevo, estado, " &
                "       motivo, usuario_crea, fecha_crea " &
                "  FROM scm.dbo.solicitud_cambio_tipoproducto " & where &
                " ORDER BY fecha_crea DESC"
            Dim dt As DataTable = oScm.Obtiene(sql)
            ConfigurarColumnasGridCambio()
            dgvAprobacionCambios.Rows.Clear() : PoblarFilasCambio(dt)
            If dt IsNot Nothing Then
                lblEstadoCambios.Text = dt.Rows.Count & " solicitud(es) cargada(s). Marca el checkbox y presiona 'Ver / Aprobar Detalle'."
                lblEstadoCambios.ForeColor = System.Drawing.Color.DarkBlue
            End If
        Catch ex As Exception
            lblEstadoCambios.Text = "Error al cargar: " & ex.Message
            lblEstadoCambios.ForeColor = System.Drawing.Color.DarkRed
        Finally
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

#End Region


    Private columnasConfiguradasCambio As Boolean = False
    Private Sub ConfigurarColumnasGridCambio()
        If columnasConfiguradasCambio Then Return
        dgvAprobacionCambios.AutoGenerateColumns = False
        dgvAprobacionCambios.Columns.Clear()
        Dim colChk As New DataGridViewCheckBoxColumn() With {.Name = "sel", .HeaderText = "", .Width = 35}
        dgvAprobacionCambios.Columns.Add(colChk)
        Dim cols As Object(,) = {
            {"id", "N° Solicitud", 90},
            {"empresa", "Empresa", 100},
            {"producto", "Producto", 100},
            {"glosa", "Descripción", 180},
            {"valor_anterior", "Tipo actual", 100},
            {"valor_nuevo", "Tipo solicitado", 110},
            {"estado", "Estado", 90},
            {"motivo", "Motivo", 120},
            {"usuario_crea", "Solicitado por", 100},
            {"fecha_crea", "Fecha", 130}
        }
        For i As Integer = 0 To cols.GetLength(0) - 1
            Dim c As New DataGridViewTextBoxColumn()
            c.Name = cols(i, 0).ToString()
            c.HeaderText = cols(i, 1).ToString()
            c.Width = CInt(cols(i, 2))
            c.ReadOnly = True
            dgvAprobacionCambios.Columns.Add(c)
        Next
        columnasConfiguradasCambio = True
    End Sub

    Private Sub PoblarFilasCambio(dt As DataTable)
        If dt Is Nothing Then Return
        For Each r As DataRow In dt.Rows
            dgvAprobacionCambios.Rows.Add(False, r("id"), r("empresa"), r("producto"), r("glosa"),
                                          r("valor_anterior"), r("valor_nuevo"), r("estado"),
                                          r("motivo"), r("usuario_crea"), r("fecha_crea"))
        Next
    End Sub

    Private Sub dgvAprobacionCambios_CurrentCellDirtyStateChanged_Cambio(sender As Object, e As EventArgs) Handles dgvAprobacionCambios.CurrentCellDirtyStateChanged
        If TypeOf dgvAprobacionCambios.CurrentCell Is DataGridViewCheckBoxCell Then
            dgvAprobacionCambios.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvAprobacionCambios_CellValueChanged_Cambio(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAprobacionCambios.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvAprobacionCambios.Columns(e.ColumnIndex).Name <> "sel" Then Return
        If Not CBool(If(dgvAprobacionCambios.Rows(e.RowIndex).Cells("sel").Value, False)) Then Return
        For Each rr As DataGridViewRow In dgvAprobacionCambios.Rows
            If rr.Index <> e.RowIndex Then rr.Cells("sel").Value = False
        Next
    End Sub


    Private idSolicitudActual As Integer = 0

    Private Sub CargarDetalleEnPanel(idSol As Integer)
        idSolicitudActual = idSol
        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            oScm.open()
            Dim sql As String =
                "SELECT id, empresa, producto, glosa, valor_anterior, valor_nuevo, estado, " &
                "       motivo, usuario_crea, fecha_crea, usuario_aprueba, fecha_aprueba, observacion " &
                "  FROM scm.dbo.solicitud_cambio_tipoproducto WHERE id = " & idSol.ToString()
            Dim dt As DataTable = oScm.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                lblEstadoCambios.Text = "Solicitud no encontrada."
                Return
            End If
            Dim r As DataRow = dt.Rows(0)
            Dim emp As String = SafeStrCa(r("empresa"))
            Dim cod As String = SafeStrCa(r("producto"))
            lblDetNumero.Text = "Solicitud #" & idSol.ToString()
            lblDetEmpresa.Text = emp
            lblDetProducto.Text = cod
            lblDetGlosa.Text = SafeStrCa(r("glosa"))
            Dim vAnt As String = SafeStrCa(r("valor_anterior"))
            lblDetTipoActual.Text = If(vAnt = "", "(vacío)", vAnt)
            lblDetTipoNuevo.Text = SafeStrCa(r("valor_nuevo"))
            Dim m As String = SafeStrCa(r("motivo"))
            lblDetMotivo.Text = If(m = "", "(sin motivo)", m)
            lblDetSolicitante.Text = SafeStrCa(r("usuario_crea"))

            Dim estado As String = SafeStrCa(r("estado"))
            lblDetEstado.Text = estado
            Select Case estado
                Case "PENDIENTE" : lblDetEstado.ForeColor = System.Drawing.Color.DarkBlue
                Case "APROBADA" : lblDetEstado.ForeColor = System.Drawing.Color.DarkGreen
                Case "RECHAZADA" : lblDetEstado.ForeColor = System.Drawing.Color.DarkRed
                Case Else : lblDetEstado.ForeColor = System.Drawing.Color.Black
            End Select

            Dim esPendiente As Boolean = (estado = "PENDIENTE")
            btnDetAprobar.Enabled = esPendiente
            btnDetRechazar.Enabled = esPendiente
            txtDetObs.Enabled = esPendiente
            If Not esPendiente Then
                txtDetObs.Text = SafeStrCa(r("observacion"))
            Else
                txtDetObs.Text = ""
            End If
        Catch ex As Exception
            lblEstadoCambios.Text = "Error cargando detalle: " & ex.Message
            Return
        Finally
            Try : oScm.close() : Catch : End Try
        End Try

        ' Consultar precio venta y volumen en flexline.producto
        Dim emp2 As String = lblDetEmpresa.Text
        Dim cod2 As String = lblDetProducto.Text
        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Try
            oFlex.open()
            Dim sql2 As String =
                "SELECT TOP 1 ISNULL(precioventa,0) AS pv, ISNULL(volumen,0) AS vol " &
                "  FROM flexline.producto WHERE empresa = '" & emp2.Replace("'", "''") & "' " &
                "   AND producto = '" & cod2.Replace("'", "''") & "'"
            Dim dt2 As DataTable = oFlex.Obtiene(sql2)
            If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
                Dim pv As Double = 0 : Dim vol As Double = 0
                Try : pv = CDbl(dt2.Rows(0)("pv")) : Catch : End Try
                Try : vol = CDbl(dt2.Rows(0)("vol")) : Catch : End Try
                lblDetPrecio.Text = Format(pv, "N2")
                lblDetVolumen.Text = Format(vol, "N2") & " LTS"
            Else
                lblDetPrecio.Text = "(no encontrado)"
                lblDetVolumen.Text = "(no encontrado)"
            End If
        Catch
            lblDetPrecio.Text = "(error)"
            lblDetVolumen.Text = "(error)"
        Finally
            Try : oFlex.close() : Catch : End Try
        End Try

        pnlDetCambio.Visible = True
    End Sub

    Private Sub btnDetCerrar_Click(sender As Object, e As EventArgs) Handles btnDetCerrar.Click
        pnlDetCambio.Visible = False
        idSolicitudActual = 0
    End Sub

    Private Sub btnDetAprobar_Click(sender As Object, e As EventArgs) Handles btnDetAprobar.Click
        If idSolicitudActual <= 0 Then Return
        Dim emp As String = lblDetEmpresa.Text
        Dim cod As String = lblDetProducto.Text
        Dim valAnt As String = lblDetTipoActual.Text
        If valAnt = "(vacío)" Then valAnt = ""
        Dim valNuevo As String = lblDetTipoNuevo.Text
        Dim obs As String = txtDetObs.Text.Trim()

        If MessageBox.Show("¿Aprobar el cambio de tipo de producto?" & vbCrLf & vbCrLf &
                           "Producto: " & cod & "    Empresa: " & emp & vbCrLf &
                           "De: '" & valAnt & "'    A: '" & valNuevo & "'",
                           "Confirmar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            Cursor = Cursors.WaitCursor
            oFlex.open() : oScm.open()
            Dim sqlUpd As String =
                "UPDATE flexline.producto SET tipoproducto = '" & valNuevo.Replace("'", "''") & "' " &
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                "   AND producto = '" & cod.Replace("'", "''") & "'"
            oFlex.Ingresa(sqlUpd)
            If oFlex.Codigo_error <> 0 Then
                MessageBox.Show("Error UPDATE producto: " & oFlex.descripcion_error)
                Return
            End If
            Dim sqlSol As String =
                "UPDATE scm.dbo.solicitud_cambio_tipoproducto " &
                "   SET estado = 'APROBADA', usuario_aprueba = '" & gs_usuario.Replace("'", "''") & "', " &
                "       fecha_aprueba = GETDATE(), " &
                "       observacion = " & If(obs.Length = 0, "NULL", "N'" & obs.Replace("'", "''") & "'") & " " &
                " WHERE id = " & idSolicitudActual.ToString()
            oScm.Ingresa(sqlSol)
            Dim obsLog As String = "Solicitud #" & idSolicitudActual & " aprobada por " & gs_usuario
            If obs.Length > 0 Then obsLog &= " | " & obs
            Dim sqlLog As String =
                "INSERT INTO scm.dbo.log_modificaciones_productos " &
                "(empresa, cod_producto, tabla_modificada, columna_modificada, valor_anterior, valor_nuevo, accion, usuario, equipo, aplicacion, observacion) " &
                "VALUES ('" & emp.Replace("'", "''") & "', '" & cod.Replace("'", "''") & "', 'BDFlexline.flexline.producto', 'tipoproducto', " &
                "N'" & valAnt.Replace("'", "''") & "', N'" & valNuevo.Replace("'", "''") & "', 'UPDATE-APROBADO', " &
                "'" & gs_usuario.Replace("'", "''") & "', '" & gs_nombre_equipo.Replace("'", "''") & "', 'Umbright', " &
                "N'" & obsLog.Replace("'", "''") & "')"
            oScm.Ingresa(sqlLog)
            MessageBox.Show("Solicitud aprobada y cambio aplicado.", "Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlDetCambio.Visible = False
            CargarSolicitudesCambio()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Cursor = Cursors.Default
            Try : oFlex.close() : Catch : End Try
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Sub btnDetRechazar_Click(sender As Object, e As EventArgs) Handles btnDetRechazar.Click
        If idSolicitudActual <= 0 Then Return
        Dim obs As String = txtDetObs.Text.Trim()
        If obs.Length = 0 Then
            MessageBox.Show("Debes escribir un motivo en la observación para rechazar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDetObs.Focus() : Return
        End If
        If MessageBox.Show("¿Rechazar la solicitud #" & idSolicitudActual & "?",
                           "Confirmar rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            oScm.open()
            Dim sql As String =
                "UPDATE scm.dbo.solicitud_cambio_tipoproducto " &
                "   SET estado = 'RECHAZADA', usuario_aprueba = '" & gs_usuario.Replace("'", "''") & "', " &
                "       fecha_aprueba = GETDATE(), observacion = N'" & obs.Replace("'", "''") & "' " &
                " WHERE id = " & idSolicitudActual.ToString()
            oScm.Ingresa(sql)
            MessageBox.Show("Solicitud rechazada.", "Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlDetCambio.Visible = False
            CargarSolicitudesCambio()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Function SafeStrCa(v As Object) As String
        If v Is Nothing OrElse v Is DBNull.Value Then Return ""
        Return v.ToString().Trim()
    End Function


    Private Sub AplicarEstiloUmbral()
        Dim cFondo As Drawing.Color = Drawing.Color.FromArgb(242, 240, 234)
        Dim cHeader As Drawing.Color = Drawing.Color.FromArgb(45, 50, 22)
        Dim cOliva As Drawing.Color = Drawing.Color.FromArgb(106, 116, 56)
        Dim cNaranja As Drawing.Color = Drawing.Color.FromArgb(196, 81, 35)
        Dim cGris As Drawing.Color = Drawing.Color.FromArgb(120, 120, 112)
        Dim cGridHdr As Drawing.Color = Drawing.Color.FromArgb(61, 68, 32)

        Me.BackColor = cFondo
        Me.Text = "Solicitud de Productos"
        Me.MinimumSize = New Drawing.Size(978, 750)
        Me.MaximumSize = New Drawing.Size(978, 750)
        Me.Font = New Drawing.Font("Segoe UI", 8.5!, Drawing.FontStyle.Regular)

        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        TabControl1.ItemSize = New Drawing.Size(0, 26)
        AddHandler TabControl1.DrawItem, AddressOf DrawTabItem
        For Each tp As TabPage In TabControl1.TabPages
            tp.BackColor = cFondo
        Next

        MenuStrip1.BackColor = cHeader
        MenuStrip1.ForeColor = Drawing.Color.FromArgb(210, 208, 198)
        For Each tsi As ToolStripItem In MenuStrip1.Items
            tsi.ForeColor = Drawing.Color.FromArgb(210, 208, 198)
            tsi.BackColor = cHeader
        Next

        Dim fntSec As New Drawing.Font("Segoe UI", 7.5!, Drawing.FontStyle.Bold)
        Dim gbList() As GroupBox = {group_encabezado, group_informacion, GroupBox2,
                                    group_listas, group_detalle, GroupBox1,
                                    gp_administracion, GroupBox3, GroupBox4}
        For Each gb As GroupBox In gbList
            If gb Is Nothing Then Continue For
            gb.ForeColor = cOliva
            gb.Font = fntSec
            gb.BackColor = cFondo
        Next

        EstilarBoton(btn_guardar, cNaranja, Drawing.Color.White)
        EstilarBoton(btn_aprobar, cOliva, Drawing.Color.White)
        EstilarBoton(btn_procesar, cGris, Drawing.Color.White)
        EstilarBotonOutline(btn_nuevo, cOliva)
        EstilarBotonOutline(btn_imprimir, cGris)
        EstilarBotonOutline(btn_rechazar, cNaranja)
        EstilarBotonOutline(btn_anular, cGris)

        Dim dgBg As Drawing.Color = Drawing.Color.FromArgb(249, 248, 245)
        Dim dgFg As Drawing.Color = Drawing.Color.FromArgb(200, 205, 170)
        EstilarDataGridLegacy(dg_listaprecios)
        EstilarDataGridLegacy(dg_packs)
        dg_listado_solicitudes.CaptionBackColor = cGridHdr
        dg_listado_solicitudes.CaptionForeColor = dgFg
        dg_listado_solicitudes.BackgroundColor = dgBg
        EstilarDGV(dgvProductoSimilares, cGridHdr)
        EstilarDGV(dgv_productos, cGridHdr)
        EstilarDGV(dgvAprobacionCambios, cGridHdr)
        EstilarTabListado()
    End Sub

    Private Sub EstilarBoton(btn As Button, bgColor As Drawing.Color, fgColor As Drawing.Color)
        btn.FlatStyle = FlatStyle.Flat
        btn.BackColor = bgColor
        btn.ForeColor = fgColor
        btn.FlatAppearance.BorderColor = Drawing.Color.FromArgb(0, bgColor.R, bgColor.G, bgColor.B)
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Drawing.Font("Segoe UI", 8.5!, Drawing.FontStyle.Bold)
        btn.Image = Nothing
        btn.ImageList = Nothing
        btn.TextAlign = Drawing.ContentAlignment.MiddleCenter
    End Sub

    Private Sub EstilarBotonOutline(btn As Button, accentColor As Drawing.Color)
        btn.FlatStyle = FlatStyle.Flat
        btn.BackColor = Drawing.Color.White
        btn.ForeColor = accentColor
        btn.FlatAppearance.BorderColor = accentColor
        btn.FlatAppearance.BorderSize = 1
        btn.Font = New Drawing.Font("Segoe UI", 8.5!, Drawing.FontStyle.Bold)
        btn.Image = Nothing
        btn.ImageList = Nothing
        btn.TextAlign = Drawing.ContentAlignment.MiddleCenter
    End Sub

    Private Sub EstilarDGV(dgv As DataGridView, headerBg As Drawing.Color)
        Dim cHdrFg  As Drawing.Color = Drawing.Color.FromArgb(200, 205, 170)
        Dim cAlt    As Drawing.Color = Drawing.Color.FromArgb(245, 243, 236)
        Dim cFg     As Drawing.Color = Drawing.Color.FromArgb(55, 62, 28)
        Dim cSelBg  As Drawing.Color = Drawing.Color.FromArgb(196, 81, 35)
        Dim cSelFg  As Drawing.Color = Drawing.Color.White
        Dim cGrid   As Drawing.Color = Drawing.Color.FromArgb(220, 217, 208)
        Dim cBg     As Drawing.Color = Drawing.Color.FromArgb(249, 248, 245)

        AplicarEstiloDGV(dgv, headerBg, cHdrFg, cAlt, cFg, cSelBg, cSelFg, cGrid, cBg)

        ' Re-aplicar estilos despues de cada recarga de datos
        AddHandler dgv.DataBindingComplete,
            Sub(s As Object, ev As DataGridViewBindingCompleteEventArgs)
                AplicarEstiloDGV(DirectCast(s, DataGridView), headerBg, cHdrFg, cAlt, cFg, cSelBg, cSelFg, cGrid, cBg)
            End Sub
    End Sub

    Private Sub AplicarEstiloDGV(dgv As DataGridView, headerBg As Drawing.Color,
                                  headerFg As Drawing.Color, altRow As Drawing.Color,
                                  fg As Drawing.Color, selBg As Drawing.Color,
                                  selFg As Drawing.Color, gridColor As Drawing.Color,
                                  bgColor As Drawing.Color)
        dgv.BackgroundColor = bgColor
        dgv.GridColor = gridColor
        dgv.BorderStyle = BorderStyle.None
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = headerBg
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = headerFg
        dgv.ColumnHeadersDefaultCellStyle.Font = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg
        dgv.AlternatingRowsDefaultCellStyle.BackColor = altRow
        dgv.DefaultCellStyle.ForeColor = fg
        dgv.DefaultCellStyle.SelectionBackColor = selBg
        dgv.DefaultCellStyle.SelectionForeColor = selFg
        dgv.RowHeadersVisible = False
    End Sub

    Private Sub DrawTabItem(sender As Object, e As DrawItemEventArgs)
        Dim cHeader As Drawing.Color = Drawing.Color.FromArgb(45, 50, 22)
        Dim cTabBg As Drawing.Color = Drawing.Color.FromArgb(61, 68, 32)
        Dim cActive As Drawing.Color = Drawing.Color.FromArgb(196, 81, 35)
        Dim tc As TabControl = DirectCast(sender, TabControl)
        Dim tabRect As Drawing.Rectangle = e.Bounds
        Dim isSelected As Boolean = (e.State And DrawItemState.Selected) > 0

        Dim bgBrush As New Drawing.SolidBrush(If(isSelected, cHeader, cTabBg))
        e.Graphics.FillRectangle(bgBrush, tabRect)
        bgBrush.Dispose()

        If isSelected Then
            Dim accentPen As New Drawing.Pen(cActive, 2)
            e.Graphics.DrawLine(accentPen, tabRect.Left, tabRect.Bottom - 1, tabRect.Right, tabRect.Bottom - 1)
            accentPen.Dispose()
        End If

        Dim tabText As String = tc.TabPages(e.Index).Text
        Dim fgColor As Drawing.Color = If(isSelected, Drawing.Color.FromArgb(242, 240, 234), Drawing.Color.FromArgb(160, 168, 120))
        Dim txtBrush As New Drawing.SolidBrush(fgColor)
        Dim tabFont As New Drawing.Font("Segoe UI", 8.5!, If(isSelected, Drawing.FontStyle.Bold, Drawing.FontStyle.Regular))
        Dim sf As New Drawing.StringFormat()
        sf.Alignment = Drawing.StringAlignment.Center
        sf.LineAlignment = Drawing.StringAlignment.Center
        e.Graphics.DrawString(tabText, tabFont, txtBrush, tabRect, sf)
        txtBrush.Dispose()
        tabFont.Dispose()
        sf.Dispose()
    End Sub

    Private Sub EstilarTabListado()
        Dim cFondo  As Drawing.Color = Drawing.Color.FromArgb(242, 240, 234)
        Dim cOliva  As Drawing.Color = Drawing.Color.FromArgb(106, 116, 56)
        Dim cNaranja As Drawing.Color = Drawing.Color.FromArgb(196, 81, 35)
        Dim cHdr    As Drawing.Color = Drawing.Color.FromArgb(61, 68, 32)
        Dim cWhite  As Drawing.Color = Drawing.Color.White
        Dim cBorder As Drawing.Color = Drawing.Color.FromArgb(200, 198, 190)

        ' --- Panel de filtros ---
        Dim pnlFiltros As New Panel()
        pnlFiltros.Name = "pnlFiltros"
        pnlFiltros.Size = New Drawing.Size(TabPage2.Width, 44)
        pnlFiltros.Location = New Drawing.Point(0, 0)
        pnlFiltros.BackColor = cWhite
        pnlFiltros.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' Borde inferior del panel de filtros
        Dim pnlLine As New Panel()
        pnlLine.Dock = DockStyle.Bottom
        pnlLine.Height = 2
        pnlLine.BackColor = cOliva
        pnlFiltros.Controls.Add(pnlLine)

        ' Label Campo
        Dim lblCampo As New Label()
        lblCampo.Text = "Buscar por:"
        lblCampo.Font = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Regular)
        lblCampo.ForeColor = Drawing.Color.FromArgb(120, 120, 112)
        lblCampo.AutoSize = True
        lblCampo.Location = New Drawing.Point(8, 14)
        pnlFiltros.Controls.Add(lblCampo)

        ' Reubicar controles existentes dentro del panel
        TabPage2.Controls.Remove(cmb_campos_busqueda)
        cmb_campos_busqueda.Location = New Drawing.Point(72, 11)
        cmb_campos_busqueda.Size = New Drawing.Size(100, 22)
        cmb_campos_busqueda.FlatStyle = FlatStyle.Flat
        cmb_campos_busqueda.BackColor = cFondo
        pnlFiltros.Controls.Add(cmb_campos_busqueda)

        TabPage2.Controls.Remove(cmb_operadores)
        cmb_operadores.Location = New Drawing.Point(178, 11)
        cmb_operadores.Size = New Drawing.Size(46, 22)
        cmb_operadores.BackColor = cFondo
        pnlFiltros.Controls.Add(cmb_operadores)

        TabPage2.Controls.Remove(txt_busqueda)
        txt_busqueda.Location = New Drawing.Point(230, 11)
        txt_busqueda.Size = New Drawing.Size(360, 22)
        txt_busqueda.BorderStyle = BorderStyle.FixedSingle
        txt_busqueda.BackColor = cFondo
        pnlFiltros.Controls.Add(txt_busqueda)

        TabPage2.Controls.Remove(btn_buscar)
        btn_buscar.Location = New Drawing.Point(598, 10)
        btn_buscar.Size = New Drawing.Size(80, 24)
        btn_buscar.Image = Nothing
        btn_buscar.ImageList = Nothing
        EstilarBoton(btn_buscar, cNaranja, cWhite)
        pnlFiltros.Controls.Add(btn_buscar)

        TabPage2.Controls.Remove(chk_ver_todos)
        chk_ver_todos.Location = New Drawing.Point(690, 13)
        chk_ver_todos.ForeColor = Drawing.Color.FromArgb(55, 62, 28)
        chk_ver_todos.FlatStyle = FlatStyle.Flat
        chk_ver_todos.Font = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Regular)
        pnlFiltros.Controls.Add(chk_ver_todos)

        TabPage2.Controls.Add(pnlFiltros)

        ' --- Barra de titulo del grid ---
        Dim pnlGridHdr As New Panel()
        pnlGridHdr.Name = "pnlGridHdr"
        pnlGridHdr.Size = New Drawing.Size(TabPage2.Width, 28)
        pnlGridHdr.Location = New Drawing.Point(0, 44)
        pnlGridHdr.BackColor = cHdr
        pnlGridHdr.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim lblGridTit As New Label()
        lblGridTit.Text = "  Listado de Solicitudes"
        lblGridTit.Font = New Drawing.Font("Segoe UI", 8.5!, Drawing.FontStyle.Bold)
        lblGridTit.ForeColor = Drawing.Color.FromArgb(200, 205, 170)
        lblGridTit.Dock = DockStyle.Fill
        lblGridTit.TextAlign = Drawing.ContentAlignment.MiddleLeft
        pnlGridHdr.Controls.Add(lblGridTit)
        TabPage2.Controls.Add(pnlGridHdr)

        ' --- Reubicar y estilizar el DataGrid ---
        dg_listado_solicitudes.Location = New Drawing.Point(0, 72)
        dg_listado_solicitudes.Size = New Drawing.Size(TabPage2.Width, TabPage2.Height - 72)
        dg_listado_solicitudes.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        EstilarDataGridLegacy(dg_listado_solicitudes)

        ' Traer al frente en orden correcto
        pnlFiltros.BringToFront()
        pnlGridHdr.BringToFront()
    End Sub

    Private Sub EstilarDataGridLegacy(dg As DataGrid)
        Dim cHdr   As Drawing.Color = Drawing.Color.FromArgb(61, 68, 32)
        Dim cHdrFg As Drawing.Color = Drawing.Color.FromArgb(200, 205, 170)
        Dim cCell  As Drawing.Color = Drawing.Color.FromArgb(252, 251, 248)
        Dim cAlt   As Drawing.Color = Drawing.Color.FromArgb(240, 238, 230)
        Dim cBg    As Drawing.Color = Drawing.Color.FromArgb(242, 240, 234)
        Dim cFg    As Drawing.Color = Drawing.Color.FromArgb(55, 62, 28)
        Dim cSel   As Drawing.Color = Drawing.Color.FromArgb(196, 81, 35)
        Dim cLine  As Drawing.Color = Drawing.Color.FromArgb(215, 212, 202)
        dg.BackgroundColor      = cBg
        dg.BackColor            = cCell
        dg.AlternatingBackColor = cAlt
        dg.ForeColor            = cFg
        dg.HeaderBackColor      = cHdr
        dg.HeaderForeColor      = cHdrFg
        dg.HeaderFont           = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Bold)
        dg.SelectionBackColor   = cSel
        dg.SelectionForeColor   = Drawing.Color.White
        dg.GridLineColor        = cLine
        dg.GridLineStyle        = DataGridLineStyle.Solid
        dg.Font                 = New Drawing.Font("Segoe UI", 8.25!, Drawing.FontStyle.Regular)
        dg.CaptionBackColor     = cHdr
        dg.CaptionForeColor     = cHdrFg
        dg.CaptionFont          = New Drawing.Font("Segoe UI", 8!, Drawing.FontStyle.Bold)
        dg.BorderStyle          = BorderStyle.None
        dg.FlatMode             = True
    End Sub
End Class
