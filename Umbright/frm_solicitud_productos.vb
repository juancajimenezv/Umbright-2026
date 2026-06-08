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
    Friend WithEvents utiliza_añada As CheckBox
    Friend WithEvents utiliza_lote As CheckBox
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
        Me.utiliza_añada = New System.Windows.Forms.CheckBox()
        Me.utiliza_lote = New System.Windows.Forms.CheckBox()
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
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvAprobacionCambios = New System.Windows.Forms.DataGridView()
        Me.btnAprobarCambio = New System.Windows.Forms.Button()
        Me.btnRechazarCambio = New System.Windows.Forms.Button()
        Me.btnRefrescarCambios = New System.Windows.Forms.Button()
        Me.chkVerTodosCambios = New System.Windows.Forms.CheckBox()
        Me.lblEstadoCambios = New System.Windows.Forms.Label()
        Me.btnVerDetalleCambio = New System.Windows.Forms.Button()
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
        Me.txtDetObs = New System.Windows.Forms.TextBox()
        Me.btnDetAprobar = New System.Windows.Forms.Button()
        Me.btnDetRechazar = New System.Windows.Forms.Button()
        Me.btnDetCerrar = New System.Windows.Forms.Button()
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
        Me.lblTitAprobadoPor = New System.Windows.Forms.Label()
        Me.lblDetAprobadoPor = New System.Windows.Forms.Label()
        Me.dgv_productos = New System.Windows.Forms.DataGridView()
        Me.txt_filtro = New System.Windows.Forms.TextBox()
        Me.cb_condicion = New System.Windows.Forms.ComboBox()
        Me.cb_campos = New System.Windows.Forms.ComboBox()
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
        Me.TabPage4.SuspendLayout()
        Me.pnlDetCambio.SuspendLayout()
        CType(Me.dgvAprobacionCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox4.Location = New System.Drawing.Point(779, -19)
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
        Me.group_encabezado.Location = New System.Drawing.Point(367, 52)
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
        Me.txt_codigo_producto.Location = New System.Drawing.Point(96, 22)
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
        Me.txt_descripcion.Location = New System.Drawing.Point(96, 46)
        Me.txt_descripcion.MaxLength = 80
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(298, 20)
        Me.txt_descripcion.TabIndex = 3
        '
        'txtCodigoDistribuidora
        '
        Me.txtCodigoDistribuidora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoDistribuidora.Location = New System.Drawing.Point(262, 68)
        Me.txtCodigoDistribuidora.MaxLength = 15
        Me.txtCodigoDistribuidora.Name = "txtCodigoDistribuidora"
        Me.txtCodigoDistribuidora.Size = New System.Drawing.Size(132, 20)
        Me.txtCodigoDistribuidora.TabIndex = 5
        '
        'txt_codigo_barras
        '
        Me.txt_codigo_barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_barras.Location = New System.Drawing.Point(96, 70)
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
        Me.lbl_NombreCorto.Location = New System.Drawing.Point(192, 73)
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
        Me.gp_administracion.Location = New System.Drawing.Point(391, -18)
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
        Me.group_informacion.Location = New System.Drawing.Point(7, -17)
        Me.group_informacion.Name = "group_informacion"
        Me.group_informacion.Size = New System.Drawing.Size(352, 144)
        Me.group_informacion.TabIndex = 1
        Me.group_informacion.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lbl_numero)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 8)
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
        Me.Label10.Location = New System.Drawing.Point(7, 12)
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
        Me.lbl_numero.Location = New System.Drawing.Point(63, 12)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(50, 13)
        Me.lbl_numero.TabIndex = 1
        Me.lbl_numero.Text = "Numero"
        Me.lbl_numero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp_fecha_solicitud
        '
        Me.dtp_fecha_solicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_solicitud.Location = New System.Drawing.Point(72, 18)
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
        Me.Label6.Location = New System.Drawing.Point(8, 22)
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 124)
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
        Me.group_detalle.Controls.Add(Me.utiliza_lote)
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
        Me.group_detalle.Size = New System.Drawing.Size(872, 153)
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
        Me.txtCEPA.Location = New System.Drawing.Point(536, 102)
        Me.txtCEPA.Name = "txtCEPA"
        Me.txtCEPA.Size = New System.Drawing.Size(112, 20)
        Me.txtCEPA.TabIndex = 44
        Me.txtCEPA.Visible = False
        '
        'cmbCEPA
        '
        Me.cmbCEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEPA.DropDownWidth = 150
        Me.cmbCEPA.Location = New System.Drawing.Point(536, 101)
        Me.cmbCEPA.Name = "cmbCEPA"
        Me.cmbCEPA.Size = New System.Drawing.Size(112, 22)
        Me.cmbCEPA.TabIndex = 45
        Me.cmbCEPA.TabStop = False
        Me.cmbCEPA.Visible = False
        '
        'utiliza_añada
        '
        Me.utiliza_añada.AutoSize = True
        Me.utiliza_añada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.utiliza_añada.Location = New System.Drawing.Point(703, 75)
        Me.utiliza_añada.Name = "utiliza_añada"
        Me.utiliza_añada.Size = New System.Drawing.Size(140, 18)
        Me.utiliza_añada.TabIndex = 42
        Me.utiliza_añada.Text = "Producto Utiliza AÑADA"
        Me.utiliza_añada.UseVisualStyleBackColor = True
        '
        'utiliza_lote
        '
        Me.utiliza_lote.AutoSize = True
        Me.utiliza_lote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.utiliza_lote.Location = New System.Drawing.Point(715, 51)
        Me.utiliza_lote.Name = "utiliza_lote"
        Me.utiliza_lote.Size = New System.Drawing.Size(128, 18)
        Me.utiliza_lote.TabIndex = 41
        Me.utiliza_lote.Text = "Producto utiliza LOTE"
        Me.utiliza_lote.UseVisualStyleBackColor = True
        '
        'afecta_iva
        '
        Me.afecta_iva.AutoSize = True
        Me.afecta_iva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.afecta_iva.Location = New System.Drawing.Point(689, 26)
        Me.afecta_iva.Name = "afecta_iva"
        Me.afecta_iva.Size = New System.Drawing.Size(154, 18)
        Me.afecta_iva.TabIndex = 40
        Me.afecta_iva.Text = "Producto afectado por IVA"
        Me.afecta_iva.UseVisualStyleBackColor = True
        '
        'txt_precio_sugerido
        '
        Me.txt_precio_sugerido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_sugerido.Location = New System.Drawing.Point(536, 73)
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
        Me.txt_medida_litros.Location = New System.Drawing.Point(536, 23)
        Me.txt_medida_litros.Name = "txt_medida_litros"
        Me.txt_medida_litros.Size = New System.Drawing.Size(112, 20)
        Me.txt_medida_litros.TabIndex = 32
        Me.txt_medida_litros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(432, 26)
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
        Me.Label21.Location = New System.Drawing.Point(432, 75)
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
        Me.Label20.Location = New System.Drawing.Point(432, 48)
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
        Me.txt_dai.Location = New System.Drawing.Point(536, 46)
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
        Me.cmb_dai.Location = New System.Drawing.Point(536, 45)
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
        Me.chkVerTodosCambios.AutoSize = True : Me.chkVerTodosCambios.Location = New System.Drawing.Point(15, 15)
        Me.chkVerTodosCambios.Text = "Ver todos (incluir aprobados y rechazados)"
        '
        Me.btnRefrescarCambios.Location = New System.Drawing.Point(380, 10) : Me.btnRefrescarCambios.Size = New System.Drawing.Size(100, 25)
        Me.btnRefrescarCambios.Text = "Refrescar"
        '
        Me.btnVerDetalleCambio.Location = New System.Drawing.Point(490, 10) : Me.btnVerDetalleCambio.Size = New System.Drawing.Size(130, 25)
        Me.btnVerDetalleCambio.Text = "Ver / Aprobar Detalle"
        Me.btnVerDetalleCambio.BackColor = System.Drawing.Color.FromArgb(CType(33, Byte), CType(150, Byte), CType(243, Byte))
        Me.btnVerDetalleCambio.ForeColor = System.Drawing.Color.White : Me.btnVerDetalleCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalleCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        '
        Me.btnAprobarCambio.Visible = False
        Me.btnRechazarCambio.Visible = False
        '
        Me.dgvAprobacionCambios.Location = New System.Drawing.Point(10, 45) : Me.dgvAprobacionCambios.Size = New System.Drawing.Size(866, 280)
        Me.dgvAprobacionCambios.AllowUserToAddRows = False : Me.dgvAprobacionCambios.AllowUserToDeleteRows = False
        Me.dgvAprobacionCambios.RowHeadersVisible = False
        Me.dgvAprobacionCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAprobacionCambios.MultiSelect = False
        '
        Me.lblEstadoCambios.AutoSize = True : Me.lblEstadoCambios.Location = New System.Drawing.Point(15, 668)
        Me.lblEstadoCambios.ForeColor = System.Drawing.Color.DarkBlue : Me.lblEstadoCambios.Text = ""
        '
        'pnlDetCambio
        '
        Me.pnlDetCambio.Location = New System.Drawing.Point(10, 335)
        Me.pnlDetCambio.Size = New System.Drawing.Size(866, 320)
        Me.pnlDetCambio.Text = "Detalle de Solicitud"
        Me.pnlDetCambio.Visible = False
        Me.pnlDetCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
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
        '
        Me.lblDetTitulo.AutoSize = True : Me.lblDetTitulo.Location = New System.Drawing.Point(15, 25)
        Me.lblDetTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetTitulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDetTitulo.Text = "Modificación de Tipo de Producto"
        '
        Me.lblDetNumero.AutoSize = True : Me.lblDetNumero.Location = New System.Drawing.Point(300, 28)
        Me.lblDetNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetNumero.Text = "Solicitud #"
        '
        Me.lblDetEmpresa.AutoSize = True : Me.lblDetEmpresa.Location = New System.Drawing.Point(120, 60) : Me.lblDetEmpresa.Text = ""
        Me.lblDetEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetProducto.AutoSize = True : Me.lblDetProducto.Location = New System.Drawing.Point(560, 60) : Me.lblDetProducto.Text = ""
        Me.lblDetProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetGlosa.AutoSize = True : Me.lblDetGlosa.Location = New System.Drawing.Point(120, 85) : Me.lblDetGlosa.Text = ""
        Me.lblDetGlosa.MaximumSize = New System.Drawing.Size(830, 0)
        Me.lblDetGlosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetTipoActual.AutoSize = True : Me.lblDetTipoActual.Location = New System.Drawing.Point(120, 115) : Me.lblDetTipoActual.Text = ""
        Me.lblDetTipoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetTipoNuevo.AutoSize = True : Me.lblDetTipoNuevo.Location = New System.Drawing.Point(560, 115) : Me.lblDetTipoNuevo.Text = ""
        Me.lblDetTipoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetPrecio.AutoSize = True : Me.lblDetPrecio.Location = New System.Drawing.Point(120, 145) : Me.lblDetPrecio.Text = ""
        Me.lblDetPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetVolumen.AutoSize = True : Me.lblDetVolumen.Location = New System.Drawing.Point(560, 145) : Me.lblDetVolumen.Text = ""
        Me.lblDetVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetMotivo.AutoSize = True : Me.lblDetMotivo.Location = New System.Drawing.Point(120, 175) : Me.lblDetMotivo.Text = ""
        Me.lblDetMotivo.MaximumSize = New System.Drawing.Size(830, 0)
        Me.lblDetMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetSolicitante.AutoSize = True : Me.lblDetSolicitante.Location = New System.Drawing.Point(120, 205) : Me.lblDetSolicitante.Text = ""
        Me.lblDetSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        '
        Me.lblDetEstado.AutoSize = True : Me.lblDetEstado.Location = New System.Drawing.Point(120, 230) : Me.lblDetEstado.Text = ""
        Me.lblDetEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        '
        Me.txtDetObs.Location = New System.Drawing.Point(15, 255) : Me.txtDetObs.Size = New System.Drawing.Size(835, 20)
        Me.txtDetObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        Me.btnDetAprobar.Location = New System.Drawing.Point(560, 285) : Me.btnDetAprobar.Size = New System.Drawing.Size(95, 28)
        Me.btnDetAprobar.Text = "Aprobar"
        Me.btnDetAprobar.BackColor = System.Drawing.Color.FromArgb(CType(76, Byte), CType(175, Byte), CType(80, Byte))
        Me.btnDetAprobar.ForeColor = System.Drawing.Color.White : Me.btnDetAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        '
        Me.btnDetRechazar.Location = New System.Drawing.Point(660, 285) : Me.btnDetRechazar.Size = New System.Drawing.Size(95, 28)
        Me.btnDetRechazar.Text = "Rechazar"
        Me.btnDetRechazar.BackColor = System.Drawing.Color.FromArgb(CType(244, Byte), CType(67, Byte), CType(54, Byte))
        Me.btnDetRechazar.ForeColor = System.Drawing.Color.White : Me.btnDetRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        '
        Me.btnDetCerrar.Location = New System.Drawing.Point(760, 285) : Me.btnDetCerrar.Size = New System.Drawing.Size(90, 28)
        Me.btnDetCerrar.Text = "Cerrar Detalle" : Me.btnDetCerrar.UseVisualStyleBackColor = True
        '
        ' Titulos en negrita (col 1 x=15, col 2 x=440)
        Me.lblTitEmpresa.AutoSize = True : Me.lblTitEmpresa.Location = New System.Drawing.Point(15, 60) : Me.lblTitEmpresa.Text = "Empresa:"
        Me.lblTitProducto.AutoSize = True : Me.lblTitProducto.Location = New System.Drawing.Point(440, 60) : Me.lblTitProducto.Text = "Producto:"
        Me.lblTitGlosa.AutoSize = True : Me.lblTitGlosa.Location = New System.Drawing.Point(15, 85) : Me.lblTitGlosa.Text = "Descripción:"
        Me.lblTitTipoActual.AutoSize = True : Me.lblTitTipoActual.Location = New System.Drawing.Point(15, 115) : Me.lblTitTipoActual.Text = "Tipo actual:"
        Me.lblTitTipoNuevo.AutoSize = True : Me.lblTitTipoNuevo.Location = New System.Drawing.Point(440, 115) : Me.lblTitTipoNuevo.Text = "Tipo solicitado:"
        Me.lblTitPrecio.AutoSize = True : Me.lblTitPrecio.Location = New System.Drawing.Point(15, 145) : Me.lblTitPrecio.Text = "Precio venta:"
        Me.lblTitVolumen.AutoSize = True : Me.lblTitVolumen.Location = New System.Drawing.Point(440, 145) : Me.lblTitVolumen.Text = "Volumen:"
        Me.lblTitMotivo.AutoSize = True : Me.lblTitMotivo.Location = New System.Drawing.Point(15, 175) : Me.lblTitMotivo.Text = "Motivo:"
        Me.lblTitSolicitante.AutoSize = True : Me.lblTitSolicitante.Location = New System.Drawing.Point(15, 205) : Me.lblTitSolicitante.Text = "Solicitado por:"
        Me.lblTitFecha.AutoSize = True : Me.lblTitFecha.Location = New System.Drawing.Point(280, 205) : Me.lblTitFecha.Text = "Fecha:"
        Me.lblDetFecha.AutoSize = True : Me.lblDetFecha.Location = New System.Drawing.Point(325, 205) : Me.lblDetFecha.Text = ""
        Me.lblDetFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lblTitEstado.AutoSize = True : Me.lblTitEstado.Location = New System.Drawing.Point(15, 230) : Me.lblTitEstado.Text = "Estado:"
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.CatalogosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(892, 24)
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
        Me.ClientSize = New System.Drawing.Size(892, 712)
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
        Me.pnlDetCambio.ResumeLayout(False)
        Me.pnlDetCambio.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvAprobacionCambios, System.ComponentModel.ISupportInitialize).EndInit()
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
                Me.utiliza_añada.CheckState = CheckState.Checked
            Else
                Me.utiliza_añada.CheckState = CheckState.Unchecked
            End If


            If drSeleccion.Item("lote").ToString = "S" Then
                Me.utiliza_lote.CheckState = CheckState.Checked
            Else
                Me.utiliza_lote.CheckState = CheckState.Unchecked
            End If

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
            IIf(Me.utiliza_añada.Checked = True, "S", "N") & "','" &
            IIf(Me.utiliza_lote.Checked = True, "S", "N") & "'," &
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
                IIf(Me.utiliza_añada.Checked = True, "S", "N") & "', '" &
                IIf(Me.utiliza_lote.Checked = True, "S", "N") & "'" &
                IIf(Me.cmbCEPA.Visible = True, "'" & Me.txtCEPA.Text & "'", "''")

            cOtrans.Escribir_Log(ls_sql)
            cOtrans.Actualiza(ls_sql)
            retorna = cOtrans.Codigo_error

            icorrelativo = ncod_solicitud

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


    Private Sub procesarProducto(ByRef pbVisible As Boolean)
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


            frm_procesar.serie = If(Me.utiliza_añada.Checked = True, "S", "N")
            frm_procesar.lote = If(Me.utiliza_lote.Checked = True, "S", "N")


            If pbVisible Then
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
                frm_procesar.txt_nombre_receta.Text = "R_" & Me.txt_descripcion.Text.Replace(" ", "_").Substring(0, 20)
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

    Private Sub btn_aprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aprobar.Click
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
        txt_descripcion.Text = txt_descripcion.Text.Replace("'", "´")
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

    Private Sub utiliza_lote_CheckedChanged(sender As Object, e As EventArgs) Handles utiliza_lote.CheckedChanged
        If Me.utiliza_añada.CheckState = CheckState.Checked And Me.utiliza_lote.CheckState = CheckState.Checked Then
            MessageBox.Show("Debe Seleccionar entre Control de Lotes y Control de Añanada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.utiliza_lote.CheckState = CheckState.Unchecked
        End If

    End Sub

    Private Sub utiliza_añada_CheckedChanged(sender As Object, e As EventArgs) Handles utiliza_añada.CheckedChanged
        If Me.utiliza_añada.CheckState = CheckState.Checked And Me.utiliza_lote.CheckState = CheckState.Checked Then
            MessageBox.Show("Debe Seleccionar entre Control de Lotes y Control de Añanada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.utiliza_añada.CheckState = CheckState.Unchecked
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

End Class