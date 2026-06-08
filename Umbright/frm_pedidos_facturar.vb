Imports System.IO
Public Class frm_pedidos_facturar
    Inherits System.Windows.Forms.Form
    Dim oDataSet As New DataSet
    Dim ods_Listado As New DataSet
    Dim ods As New DataSet
    Public lpedidos_posfechados As Boolean = False

    Public lanular_memos As Boolean = False
    Dim odsFACE As DataSet
    Friend WithEvents btnLiberarEnvios As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents btnReimpresionNC As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnGenerarFACENC As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dgvNC As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerarTXTNC As System.Windows.Forms.Button
    Friend WithEvents dgvNCDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btnLiberarEnviosNC As System.Windows.Forms.Button
    Friend WithEvents btnObtenerNC As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaFinNC As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicioNC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents btnReimpresionRecibos As System.Windows.Forms.Button
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroFacturaEnvio As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoDoctoEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresaEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDetalleEnvios As System.Windows.Forms.DataGridView
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnProcesarEnvio As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtMontoEnvio As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesEnvio As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteEnvio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevoEnvio As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dgvResumenEnvios As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_unidades As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents chkGenerarTodo_Fel As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_reimpresion_fel As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias_fel As NumericUpDown
    Friend WithEvents Button4 As Button
    Friend WithEvents dgv_encabezado_fel As DataGridView
    Friend WithEvents dgv_detalle_fel As DataGridView
    Friend WithEvents btn_obtener_informacion_fel As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents dtp_fel_inicio As DateTimePicker
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtDocumentosFel As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents dtp_fel_final As DateTimePicker
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents button_reimprimir_recibos As Button
    Friend WithEvents btn_liberar_envios_fel As Button
    Friend WithEvents verificarFEL As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents reimprimirCOMPRAS As Button
    Friend WithEvents btnValidarStock As Button
    Friend WithEvents btnTrasladoAntigua As Button
    Friend WithEvents lbTipoExp As ComboBox
    Friend WithEvents lblTipoExp As Label
    Friend WithEvents btnFacturacion_RecogeBodega As Button
    Friend WithEvents btnFacturarBatch As Button
    Friend WithEvents txtCantidadPedidos As TextBox
    Friend WithEvents cmbCEDI As ComboBox
    Friend WithEvents btnFacturacionDescuento As Button
    Friend WithEvents cmb_estados As ComboBox
    Friend WithEvents btnLiberarConsignacion As Button
    Dim sDirectorio As String


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
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_Estado_Cuenta As System.Windows.Forms.Button
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    'Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txt_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lbl_facturado As System.Windows.Forms.Label
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_encabezado As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txt_total_lineas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_total_lineas As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_Entrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents nupCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicioFACE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumeroOCRecepcionWM As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_facturas As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinalFACE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumeroOC As System.Windows.Forms.TextBox
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFace As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents dgv_pedidosFACE As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetalleFACE As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtComentario2 As System.Windows.Forms.TextBox
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents chkTodo As System.Windows.Forms.CheckBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents chk_todo As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedidos_facturar))
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Btn_Estado_Cuenta = New System.Windows.Forms.Button()
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.lbl_facturado = New System.Windows.Forms.Label()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.dgv_encabezado = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtCantidadPedidos = New System.Windows.Forms.TextBox()
        Me.cmbCEDI = New System.Windows.Forms.ComboBox()
        Me.btnFacturarBatch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnFacturacion_RecogeBodega = New System.Windows.Forms.Button()
        Me.btnTrasladoAntigua = New System.Windows.Forms.Button()
        Me.txt_total_unidades = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.chk_todo = New System.Windows.Forms.CheckBox()
        Me.txt_total_lineas = New System.Windows.Forms.TextBox()
        Me.btnValidarStock = New System.Windows.Forms.Button()
        Me.btnFacturacionDescuento = New System.Windows.Forms.Button()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.lbl_total_lineas = New System.Windows.Forms.Label()
        Me.txt_total_pedido = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtComentario2 = New System.Windows.Forms.TextBox()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.cmb_estados = New System.Windows.Forms.ComboBox()
        Me.btnLiberarConsignacion = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTodo = New System.Windows.Forms.CheckBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.nupCopias = New System.Windows.Forms.NumericUpDown()
        Me.btnFace = New System.Windows.Forms.Button()
        Me.dgv_pedidosFACE = New System.Windows.Forms.DataGridView()
        Me.dgvDetalleFACE = New System.Windows.Forms.DataGridView()
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpFechaInicioFACE = New System.Windows.Forms.DateTimePicker()
        Me.txtNumeroOCRecepcionWM = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_facturas = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFechaFinalFACE = New System.Windows.Forms.DateTimePicker()
        Me.txtNumeroOC = New System.Windows.Forms.TextBox()
        Me.btnReimpresionRecibos = New System.Windows.Forms.Button()
        Me.btnLiberarEnvios = New System.Windows.Forms.Button()
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lbTipoExp = New System.Windows.Forms.ComboBox()
        Me.lblTipoExp = New System.Windows.Forms.Label()
        Me.chkGenerarTodo_Fel = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.reimprimirCOMPRAS = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn_reimpresion_fel = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias_fel = New System.Windows.Forms.NumericUpDown()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dgv_encabezado_fel = New System.Windows.Forms.DataGridView()
        Me.dgv_detalle_fel = New System.Windows.Forms.DataGridView()
        Me.btn_obtener_informacion_fel = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtp_fel_inicio = New System.Windows.Forms.DateTimePicker()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDocumentosFel = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtp_fel_final = New System.Windows.Forms.DateTimePicker()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.button_reimprimir_recibos = New System.Windows.Forms.Button()
        Me.btn_liberar_envios_fel = New System.Windows.Forms.Button()
        Me.verificarFEL = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.btnGenerarFACENC = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dgvNC = New System.Windows.Forms.DataGridView()
        Me.btnGenerarTXTNC = New System.Windows.Forms.Button()
        Me.dgvNCDetalle = New System.Windows.Forms.DataGridView()
        Me.btnLiberarEnviosNC = New System.Windows.Forms.Button()
        Me.btnObtenerNC = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.dtpFechaFinNC = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicioNC = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvResumenEnvios = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnNuevoEnvio = New System.Windows.Forms.Button()
        Me.btnProcesarEnvio = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMontoEnvio = New System.Windows.Forms.TextBox()
        Me.txtObservacionesEnvio = New System.Windows.Forms.TextBox()
        Me.txtClienteEnvio = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.txtNumeroFacturaEnvio = New System.Windows.Forms.TextBox()
        Me.cmbTipoDoctoEnvio = New System.Windows.Forms.ComboBox()
        Me.cmbEmpresaEnvio = New System.Windows.Forms.ComboBox()
        Me.dgvDetalleEnvios = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.dtp_fecha_Entrega = New System.Windows.Forms.DateTimePicker()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_encabezado_fel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_detalle_fel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNCDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvResumenEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDetalleEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(37, 6)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_inicio.TabIndex = 2
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(165, 6)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_final.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Del"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(141, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Al"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Buscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.White
        Me.Btn_Buscar.Location = New System.Drawing.Point(389, 6)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Buscar.TabIndex = 6
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'Btn_Estado_Cuenta
        '
        Me.Btn_Estado_Cuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Estado_Cuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Estado_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Estado_Cuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Estado_Cuenta.ForeColor = System.Drawing.Color.White
        Me.Btn_Estado_Cuenta.Location = New System.Drawing.Point(1289, 5)
        Me.Btn_Estado_Cuenta.Name = "Btn_Estado_Cuenta"
        Me.Btn_Estado_Cuenta.Size = New System.Drawing.Size(95, 23)
        Me.Btn_Estado_Cuenta.TabIndex = 7
        Me.Btn_Estado_Cuenta.Text = "Est. de Cuenta"
        Me.Btn_Estado_Cuenta.UseVisualStyleBackColor = False
        Me.Btn_Estado_Cuenta.Visible = False
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_porcentaje.Location = New System.Drawing.Point(343, 6)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.Size = New System.Drawing.Size(40, 21)
        Me.txt_porcentaje.TabIndex = 19
        Me.txt_porcentaje.Text = "0"
        '
        'lbl_facturado
        '
        Me.lbl_facturado.Location = New System.Drawing.Point(269, 7)
        Me.lbl_facturado.Name = "lbl_facturado"
        Me.lbl_facturado.Size = New System.Drawing.Size(72, 16)
        Me.lbl_facturado.TabIndex = 20
        Me.lbl_facturado.Text = "% Facturado"
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(1, 303)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.RowHeadersVisible = False
        Me.dgv_detalle.RowHeadersWidth = 51
        Me.dgv_detalle.Size = New System.Drawing.Size(1415, 226)
        Me.dgv_detalle.TabIndex = 30
        '
        'dgv_encabezado
        '
        Me.dgv_encabezado.AllowUserToAddRows = False
        Me.dgv_encabezado.AllowUserToDeleteRows = False
        Me.dgv_encabezado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_encabezado.Location = New System.Drawing.Point(1, 33)
        Me.dgv_encabezado.Name = "dgv_encabezado"
        Me.dgv_encabezado.ReadOnly = True
        Me.dgv_encabezado.RowHeadersWidth = 25
        Me.dgv_encabezado.Size = New System.Drawing.Size(1415, 269)
        Me.dgv_encabezado.TabIndex = 31
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
        Me.TabControl1.Size = New System.Drawing.Size(1429, 665)
        Me.TabControl1.TabIndex = 32
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtCantidadPedidos)
        Me.TabPage1.Controls.Add(Me.cmbCEDI)
        Me.TabPage1.Controls.Add(Me.btnFacturarBatch)
        Me.TabPage1.Controls.Add(Me.btnFacturacion_RecogeBodega)
        Me.TabPage1.Controls.Add(Me.btnTrasladoAntigua)
        Me.TabPage1.Controls.Add(Me.txt_total_unidades)
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.chk_todo)
        Me.TabPage1.Controls.Add(Me.txt_total_lineas)
        Me.TabPage1.Controls.Add(Me.btnValidarStock)
        Me.TabPage1.Controls.Add(Me.btnFacturacionDescuento)
        Me.TabPage1.Controls.Add(Me.btnVerificar)
        Me.TabPage1.Controls.Add(Me.lbl_total_lineas)
        Me.TabPage1.Controls.Add(Me.txt_total_pedido)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgv_encabezado)
        Me.TabPage1.Controls.Add(Me.dgv_detalle)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_inicio)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_final)
        Me.TabPage1.Controls.Add(Me.lbl_facturado)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_porcentaje)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Btn_Buscar)
        Me.TabPage1.Controls.Add(Me.btnLiberarConsignacion)
        Me.TabPage1.Controls.Add(Me.Btn_Estado_Cuenta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1421, 639)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pedidos Pendientes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtCantidadPedidos
        '
        Me.txtCantidadPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCantidadPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadPedidos.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCantidadPedidos.Location = New System.Drawing.Point(929, 8)
        Me.txtCantidadPedidos.Name = "txtCantidadPedidos"
        Me.txtCantidadPedidos.ReadOnly = True
        Me.txtCantidadPedidos.Size = New System.Drawing.Size(44, 21)
        Me.txtCantidadPedidos.TabIndex = 45
        Me.txtCantidadPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCEDI
        '
        Me.cmbCEDI.FormattingEnabled = True
        Me.cmbCEDI.Location = New System.Drawing.Point(556, 9)
        Me.cmbCEDI.Name = "cmbCEDI"
        Me.cmbCEDI.Size = New System.Drawing.Size(95, 21)
        Me.cmbCEDI.TabIndex = 43
        '
        'btnFacturarBatch
        '
        Me.btnFacturarBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacturarBatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnFacturarBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFacturarBatch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturarBatch.ForeColor = System.Drawing.Color.White
        Me.btnFacturarBatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFacturarBatch.ImageIndex = 1
        Me.btnFacturarBatch.ImageList = Me.ImageList1
        Me.btnFacturarBatch.Location = New System.Drawing.Point(1178, 551)
        Me.btnFacturarBatch.Name = "btnFacturarBatch"
        Me.btnFacturarBatch.Size = New System.Drawing.Size(83, 62)
        Me.btnFacturarBatch.TabIndex = 42
        Me.btnFacturarBatch.Text = "Batch"
        Me.btnFacturarBatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFacturarBatch.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Text-Edit-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Smart-FTP-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        Me.ImageList1.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(4, "printer_48.png")
        Me.ImageList1.Images.SetKeyName(5, "cut_from_page.ico")
        '
        'btnFacturacion_RecogeBodega
        '
        Me.btnFacturacion_RecogeBodega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacturacion_RecogeBodega.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnFacturacion_RecogeBodega.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFacturacion_RecogeBodega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturacion_RecogeBodega.ForeColor = System.Drawing.Color.White
        Me.btnFacturacion_RecogeBodega.Location = New System.Drawing.Point(1031, 7)
        Me.btnFacturacion_RecogeBodega.Name = "btnFacturacion_RecogeBodega"
        Me.btnFacturacion_RecogeBodega.Size = New System.Drawing.Size(133, 23)
        Me.btnFacturacion_RecogeBodega.TabIndex = 41
        Me.btnFacturacion_RecogeBodega.Text = "Recoge Bodega"
        Me.btnFacturacion_RecogeBodega.UseVisualStyleBackColor = False
        Me.btnFacturacion_RecogeBodega.Visible = False
        '
        'btnTrasladoAntigua
        '
        Me.btnTrasladoAntigua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTrasladoAntigua.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnTrasladoAntigua.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTrasladoAntigua.ForeColor = System.Drawing.Color.White
        Me.btnTrasladoAntigua.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTrasladoAntigua.ImageIndex = 2
        Me.btnTrasladoAntigua.ImageList = Me.ImageList1
        Me.btnTrasladoAntigua.Location = New System.Drawing.Point(1341, 73)
        Me.btnTrasladoAntigua.Name = "btnTrasladoAntigua"
        Me.btnTrasladoAntigua.Size = New System.Drawing.Size(75, 62)
        Me.btnTrasladoAntigua.TabIndex = 40
        Me.btnTrasladoAntigua.Text = "Stock SVAG"
        Me.btnTrasladoAntigua.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTrasladoAntigua.UseVisualStyleBackColor = False
        Me.btnTrasladoAntigua.Visible = False
        '
        'txt_total_unidades
        '
        Me.txt_total_unidades.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_unidades.ForeColor = System.Drawing.Color.DarkRed
        Me.txt_total_unidades.Location = New System.Drawing.Point(969, 599)
        Me.txt_total_unidades.Name = "txt_total_unidades"
        Me.txt_total_unidades.ReadOnly = True
        Me.txt_total_unidades.Size = New System.Drawing.Size(103, 21)
        Me.txt_total_unidades.TabIndex = 39
        Me.txt_total_unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.ForeColor = System.Drawing.Color.DarkRed
        Me.Label38.Location = New System.Drawing.Point(879, 599)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(84, 16)
        Me.Label38.TabIndex = 38
        Me.Label38.Text = "Total Unidades"
        '
        'chk_todo
        '
        Me.chk_todo.AutoSize = True
        Me.chk_todo.Location = New System.Drawing.Point(483, 7)
        Me.chk_todo.Name = "chk_todo"
        Me.chk_todo.Size = New System.Drawing.Size(50, 17)
        Me.chk_todo.TabIndex = 37
        Me.chk_todo.Text = "Todo"
        Me.chk_todo.UseVisualStyleBackColor = True
        '
        'txt_total_lineas
        '
        Me.txt_total_lineas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_lineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_lineas.ForeColor = System.Drawing.Color.DarkRed
        Me.txt_total_lineas.Location = New System.Drawing.Point(969, 576)
        Me.txt_total_lineas.Name = "txt_total_lineas"
        Me.txt_total_lineas.ReadOnly = True
        Me.txt_total_lineas.Size = New System.Drawing.Size(103, 21)
        Me.txt_total_lineas.TabIndex = 36
        Me.txt_total_lineas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnValidarStock
        '
        Me.btnValidarStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidarStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnValidarStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnValidarStock.ForeColor = System.Drawing.Color.White
        Me.btnValidarStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnValidarStock.ImageIndex = 2
        Me.btnValidarStock.ImageList = Me.ImageList1
        Me.btnValidarStock.Location = New System.Drawing.Point(1263, 551)
        Me.btnValidarStock.Name = "btnValidarStock"
        Me.btnValidarStock.Size = New System.Drawing.Size(75, 62)
        Me.btnValidarStock.TabIndex = 11
        Me.btnValidarStock.Text = "Stock/Pedid"
        Me.btnValidarStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnValidarStock.UseVisualStyleBackColor = False
        '
        'btnFacturacionDescuento
        '
        Me.btnFacturacionDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacturacionDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnFacturacionDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFacturacionDescuento.ForeColor = System.Drawing.Color.White
        Me.btnFacturacionDescuento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFacturacionDescuento.ImageIndex = 0
        Me.btnFacturacionDescuento.ImageList = Me.ImageList1
        Me.btnFacturacionDescuento.Location = New System.Drawing.Point(1101, 551)
        Me.btnFacturacionDescuento.Name = "btnFacturacionDescuento"
        Me.btnFacturacionDescuento.Size = New System.Drawing.Size(75, 62)
        Me.btnFacturacionDescuento.TabIndex = 11
        Me.btnFacturacionDescuento.Text = "Pedido %"
        Me.btnFacturacionDescuento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFacturacionDescuento.UseVisualStyleBackColor = False
        '
        'btnVerificar
        '
        Me.btnVerificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVerificar.ForeColor = System.Drawing.Color.White
        Me.btnVerificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVerificar.ImageIndex = 3
        Me.btnVerificar.ImageList = Me.ImageList1
        Me.btnVerificar.Location = New System.Drawing.Point(1339, 551)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(75, 62)
        Me.btnVerificar.TabIndex = 11
        Me.btnVerificar.Text = "Pedido"
        Me.btnVerificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerificar.UseVisualStyleBackColor = False
        '
        'lbl_total_lineas
        '
        Me.lbl_total_lineas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_total_lineas.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_total_lineas.Location = New System.Drawing.Point(879, 580)
        Me.lbl_total_lineas.Name = "lbl_total_lineas"
        Me.lbl_total_lineas.Size = New System.Drawing.Size(84, 15)
        Me.lbl_total_lineas.TabIndex = 35
        Me.lbl_total_lineas.Text = "Total Lineas"
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_pedido.Location = New System.Drawing.Point(969, 550)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(103, 21)
        Me.txt_total_pedido.TabIndex = 33
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(878, 550)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 24)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Total de Pedido"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.txtComentario2)
        Me.GroupBox1.Controls.Add(Me.txt_comentario)
        Me.GroupBox1.Controls.Add(Me.cmb_estados)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 536)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 119)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 32)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Resolucion"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(8, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 32)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Comentario Pedido"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Location = New System.Drawing.Point(529, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.Visible = False
        '
        'txtComentario2
        '
        Me.txtComentario2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComentario2.Location = New System.Drawing.Point(385, 46)
        Me.txtComentario2.Multiline = True
        Me.txtComentario2.Name = "txtComentario2"
        Me.txtComentario2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentario2.Size = New System.Drawing.Size(226, 63)
        Me.txtComentario2.TabIndex = 8
        '
        'txt_comentario
        '
        Me.txt_comentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comentario.Location = New System.Drawing.Point(72, 42)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(307, 67)
        Me.txt_comentario.TabIndex = 8
        '
        'cmb_estados
        '
        Me.cmb_estados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_estados.DisplayMember = "cds"
        Me.cmb_estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estados.Enabled = False
        Me.cmb_estados.Location = New System.Drawing.Point(72, 16)
        Me.cmb_estados.Name = "cmb_estados"
        Me.cmb_estados.Size = New System.Drawing.Size(304, 21)
        Me.cmb_estados.TabIndex = 9
        '
        'btnLiberarConsignacion
        '
        Me.btnLiberarConsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLiberarConsignacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLiberarConsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLiberarConsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberarConsignacion.ForeColor = System.Drawing.Color.White
        Me.btnLiberarConsignacion.Location = New System.Drawing.Point(1188, 5)
        Me.btnLiberarConsignacion.Name = "btnLiberarConsignacion"
        Me.btnLiberarConsignacion.Size = New System.Drawing.Size(95, 23)
        Me.btnLiberarConsignacion.TabIndex = 7
        Me.btnLiberarConsignacion.Text = "Consignacion"
        Me.btnLiberarConsignacion.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.dgv_pedidosFACE)
        Me.TabPage2.Controls.Add(Me.dgvDetalleFACE)
        Me.TabPage2.Controls.Add(Me.btn_generar)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.dtpFechaInicioFACE)
        Me.TabPage2.Controls.Add(Me.txtNumeroOCRecepcionWM)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txt_facturas)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.dtpFechaFinalFACE)
        Me.TabPage2.Controls.Add(Me.txtNumeroOC)
        Me.TabPage2.Controls.Add(Me.btnReimpresionRecibos)
        Me.TabPage2.Controls.Add(Me.btnLiberarEnvios)
        Me.TabPage2.Controls.Add(Me.btn_procesar)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1421, 639)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "FACE"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkTodo)
        Me.GroupBox2.Controls.Add(Me.txtRuta)
        Me.GroupBox2.Controls.Add(Me.btnImpresion)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.nupCopias)
        Me.GroupBox2.Controls.Add(Me.btnFace)
        Me.GroupBox2.Location = New System.Drawing.Point(800, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 102)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Factura Electronica"
        '
        'chkTodo
        '
        Me.chkTodo.AutoSize = True
        Me.chkTodo.Location = New System.Drawing.Point(491, 7)
        Me.chkTodo.Name = "chkTodo"
        Me.chkTodo.Size = New System.Drawing.Size(92, 17)
        Me.chkTodo.TabIndex = 59
        Me.chkTodo.Text = "Generar Todo"
        Me.chkTodo.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(6, 75)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(428, 21)
        Me.txtRuta.TabIndex = 57
        '
        'btnImpresion
        '
        Me.btnImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpresion.ForeColor = System.Drawing.Color.White
        Me.btnImpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImpresion.ImageIndex = 4
        Me.btnImpresion.ImageList = Me.ImageList1
        Me.btnImpresion.Location = New System.Drawing.Point(271, 7)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(91, 66)
        Me.btnImpresion.TabIndex = 56
        Me.btnImpresion.Text = "ReImpresion"
        Me.btnImpresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImpresion.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Numero de Copias"
        '
        'nupCopias
        '
        Me.nupCopias.Location = New System.Drawing.Point(105, 21)
        Me.nupCopias.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias.Name = "nupCopias"
        Me.nupCopias.Size = New System.Drawing.Size(37, 21)
        Me.nupCopias.TabIndex = 55
        Me.nupCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnFace
        '
        Me.btnFace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFace.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFace.ForeColor = System.Drawing.Color.White
        Me.btnFace.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFace.ImageIndex = 0
        Me.btnFace.ImageList = Me.ImageList1
        Me.btnFace.Location = New System.Drawing.Point(370, 7)
        Me.btnFace.Name = "btnFace"
        Me.btnFace.Size = New System.Drawing.Size(96, 66)
        Me.btnFace.TabIndex = 45
        Me.btnFace.Text = "Generar FACE"
        Me.btnFace.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFace.UseVisualStyleBackColor = False
        '
        'dgv_pedidosFACE
        '
        Me.dgv_pedidosFACE.AllowUserToAddRows = False
        Me.dgv_pedidosFACE.AllowUserToDeleteRows = False
        Me.dgv_pedidosFACE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidosFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidosFACE.Location = New System.Drawing.Point(1, 142)
        Me.dgv_pedidosFACE.Name = "dgv_pedidosFACE"
        Me.dgv_pedidosFACE.RowHeadersWidth = 25
        Me.dgv_pedidosFACE.Size = New System.Drawing.Size(1407, 320)
        Me.dgv_pedidosFACE.TabIndex = 57
        '
        'dgvDetalleFACE
        '
        Me.dgvDetalleFACE.AllowUserToAddRows = False
        Me.dgvDetalleFACE.AllowUserToDeleteRows = False
        Me.dgvDetalleFACE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleFACE.Location = New System.Drawing.Point(2, 467)
        Me.dgvDetalleFACE.Name = "dgvDetalleFACE"
        Me.dgvDetalleFACE.ReadOnly = True
        Me.dgvDetalleFACE.RowHeadersWidth = 20
        Me.dgvDetalleFACE.Size = New System.Drawing.Size(1404, 441)
        Me.dgvDetalleFACE.TabIndex = 56
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 2
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(238, 40)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(96, 74)
        Me.btn_generar.TabIndex = 47
        Me.btn_generar.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(30, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 16)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "Fecha"
        '
        'dtpFechaInicioFACE
        '
        Me.dtpFechaInicioFACE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioFACE.Location = New System.Drawing.Point(125, 6)
        Me.dtpFechaInicioFACE.Name = "dtpFechaInicioFACE"
        Me.dtpFechaInicioFACE.Size = New System.Drawing.Size(100, 21)
        Me.dtpFechaInicioFACE.TabIndex = 41
        '
        'txtNumeroOCRecepcionWM
        '
        Me.txtNumeroOCRecepcionWM.Location = New System.Drawing.Point(125, 87)
        Me.txtNumeroOCRecepcionWM.Name = "txtNumeroOCRecepcionWM"
        Me.txtNumeroOCRecepcionWM.Size = New System.Drawing.Size(100, 21)
        Me.txtNumeroOCRecepcionWM.TabIndex = 52
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Documentos"
        '
        'txt_facturas
        '
        Me.txt_facturas.Location = New System.Drawing.Point(125, 36)
        Me.txt_facturas.Name = "txt_facturas"
        Me.txt_facturas.ReadOnly = True
        Me.txt_facturas.Size = New System.Drawing.Size(100, 21)
        Me.txt_facturas.TabIndex = 42
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "No. Recepcion"
        '
        'dtpFechaFinalFACE
        '
        Me.dtpFechaFinalFACE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinalFACE.Location = New System.Drawing.Point(231, 6)
        Me.dtpFechaFinalFACE.Name = "dtpFechaFinalFACE"
        Me.dtpFechaFinalFACE.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaFinalFACE.TabIndex = 43
        '
        'txtNumeroOC
        '
        Me.txtNumeroOC.Location = New System.Drawing.Point(125, 62)
        Me.txtNumeroOC.Name = "txtNumeroOC"
        Me.txtNumeroOC.Size = New System.Drawing.Size(100, 21)
        Me.txtNumeroOC.TabIndex = 53
        '
        'btnReimpresionRecibos
        '
        Me.btnReimpresionRecibos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionRecibos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimpresionRecibos.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionRecibos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionRecibos.ImageIndex = 5
        Me.btnReimpresionRecibos.Location = New System.Drawing.Point(527, 40)
        Me.btnReimpresionRecibos.Name = "btnReimpresionRecibos"
        Me.btnReimpresionRecibos.Size = New System.Drawing.Size(96, 74)
        Me.btnReimpresionRecibos.TabIndex = 46
        Me.btnReimpresionRecibos.Text = "Reimprimir Recibos"
        Me.btnReimpresionRecibos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionRecibos.UseVisualStyleBackColor = False
        '
        'btnLiberarEnvios
        '
        Me.btnLiberarEnvios.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLiberarEnvios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLiberarEnvios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberarEnvios.ForeColor = System.Drawing.Color.White
        Me.btnLiberarEnvios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLiberarEnvios.ImageIndex = 5
        Me.btnLiberarEnvios.ImageList = Me.ImageList1
        Me.btnLiberarEnvios.Location = New System.Drawing.Point(430, 40)
        Me.btnLiberarEnvios.Name = "btnLiberarEnvios"
        Me.btnLiberarEnvios.Size = New System.Drawing.Size(96, 74)
        Me.btnLiberarEnvios.TabIndex = 46
        Me.btnLiberarEnvios.Text = "Liberar Envios"
        Me.btnLiberarEnvios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiberarEnvios.UseVisualStyleBackColor = False
        '
        'btn_procesar
        '
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_procesar.ImageIndex = 3
        Me.btn_procesar.ImageList = Me.ImageList1
        Me.btn_procesar.Location = New System.Drawing.Point(334, 40)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(96, 74)
        Me.btn_procesar.TabIndex = 46
        Me.btn_procesar.Text = "Generar TXT"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "No. Envio"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.lbTipoExp)
        Me.TabPage3.Controls.Add(Me.lblTipoExp)
        Me.TabPage3.Controls.Add(Me.chkGenerarTodo_Fel)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.dgv_encabezado_fel)
        Me.TabPage3.Controls.Add(Me.dgv_detalle_fel)
        Me.TabPage3.Controls.Add(Me.btn_obtener_informacion_fel)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.dtp_fel_inicio)
        Me.TabPage3.Controls.Add(Me.TextBox7)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.txtDocumentosFel)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.dtp_fel_final)
        Me.TabPage3.Controls.Add(Me.TextBox14)
        Me.TabPage3.Controls.Add(Me.button_reimprimir_recibos)
        Me.TabPage3.Controls.Add(Me.btn_liberar_envios_fel)
        Me.TabPage3.Controls.Add(Me.verificarFEL)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1421, 639)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "FEL"
        '
        'lbTipoExp
        '
        Me.lbTipoExp.FormattingEnabled = True
        Me.lbTipoExp.Items.AddRange(New Object() {"CIF", "FOB"})
        Me.lbTipoExp.Location = New System.Drawing.Point(128, 112)
        Me.lbTipoExp.Name = "lbTipoExp"
        Me.lbTipoExp.Size = New System.Drawing.Size(100, 21)
        Me.lbTipoExp.TabIndex = 78
        '
        'lblTipoExp
        '
        Me.lblTipoExp.AutoSize = True
        Me.lblTipoExp.Location = New System.Drawing.Point(33, 115)
        Me.lblTipoExp.Name = "lblTipoExp"
        Me.lblTipoExp.Size = New System.Drawing.Size(91, 13)
        Me.lblTipoExp.TabIndex = 77
        Me.lblTipoExp.Text = "Tipo exportacion:"
        '
        'chkGenerarTodo_Fel
        '
        Me.chkGenerarTodo_Fel.AutoSize = True
        Me.chkGenerarTodo_Fel.Location = New System.Drawing.Point(367, 8)
        Me.chkGenerarTodo_Fel.Name = "chkGenerarTodo_Fel"
        Me.chkGenerarTodo_Fel.Size = New System.Drawing.Size(92, 17)
        Me.chkGenerarTodo_Fel.TabIndex = 76
        Me.chkGenerarTodo_Fel.Text = "Generar Todo"
        Me.chkGenerarTodo_Fel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.reimprimirCOMPRAS)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.btn_reimpresion_fel)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.nupCopias_fel)
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Location = New System.Drawing.Point(989, 26)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(408, 102)
        Me.GroupBox5.TabIndex = 75
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "FEL"
        '
        'reimprimirCOMPRAS
        '
        Me.reimprimirCOMPRAS.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.reimprimirCOMPRAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reimprimirCOMPRAS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reimprimirCOMPRAS.ForeColor = System.Drawing.Color.White
        Me.reimprimirCOMPRAS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.reimprimirCOMPRAS.ImageIndex = 0
        Me.reimprimirCOMPRAS.Location = New System.Drawing.Point(301, 5)
        Me.reimprimirCOMPRAS.Name = "reimprimirCOMPRAS"
        Me.reimprimirCOMPRAS.Size = New System.Drawing.Size(91, 66)
        Me.reimprimirCOMPRAS.TabIndex = 58
        Me.reimprimirCOMPRAS.Text = "ReImpresion COMPRAS"
        Me.reimprimirCOMPRAS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.reimprimirCOMPRAS.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 75)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(428, 21)
        Me.TextBox1.TabIndex = 57
        Me.TextBox1.Visible = False
        '
        'btn_reimpresion_fel
        '
        Me.btn_reimpresion_fel.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reimpresion_fel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reimpresion_fel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimpresion_fel.ForeColor = System.Drawing.Color.White
        Me.btn_reimpresion_fel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reimpresion_fel.ImageIndex = 4
        Me.btn_reimpresion_fel.ImageList = Me.ImageList1
        Me.btn_reimpresion_fel.Location = New System.Drawing.Point(204, 5)
        Me.btn_reimpresion_fel.Name = "btn_reimpresion_fel"
        Me.btn_reimpresion_fel.Size = New System.Drawing.Size(91, 66)
        Me.btn_reimpresion_fel.TabIndex = 56
        Me.btn_reimpresion_fel.Text = "ReImpresion"
        Me.btn_reimpresion_fel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_reimpresion_fel.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias_fel
        '
        Me.nupCopias_fel.Location = New System.Drawing.Point(32, 44)
        Me.nupCopias_fel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias_fel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias_fel.Name = "nupCopias_fel"
        Me.nupCopias_fel.Size = New System.Drawing.Size(37, 21)
        Me.nupCopias_fel.TabIndex = 55
        Me.nupCopias_fel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.ImageIndex = 0
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(102, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 66)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "Generar FACE"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'dgv_encabezado_fel
        '
        Me.dgv_encabezado_fel.AllowUserToAddRows = False
        Me.dgv_encabezado_fel.AllowUserToDeleteRows = False
        Me.dgv_encabezado_fel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_encabezado_fel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_encabezado_fel.Location = New System.Drawing.Point(4, 147)
        Me.dgv_encabezado_fel.Name = "dgv_encabezado_fel"
        Me.dgv_encabezado_fel.RowHeadersWidth = 25
        Me.dgv_encabezado_fel.Size = New System.Drawing.Size(1407, 302)
        Me.dgv_encabezado_fel.TabIndex = 74
        '
        'dgv_detalle_fel
        '
        Me.dgv_detalle_fel.AllowUserToAddRows = False
        Me.dgv_detalle_fel.AllowUserToDeleteRows = False
        Me.dgv_detalle_fel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle_fel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle_fel.Location = New System.Drawing.Point(4, 455)
        Me.dgv_detalle_fel.Name = "dgv_detalle_fel"
        Me.dgv_detalle_fel.ReadOnly = True
        Me.dgv_detalle_fel.RowHeadersWidth = 20
        Me.dgv_detalle_fel.Size = New System.Drawing.Size(1407, 176)
        Me.dgv_detalle_fel.TabIndex = 73
        '
        'btn_obtener_informacion_fel
        '
        Me.btn_obtener_informacion_fel.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_obtener_informacion_fel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_obtener_informacion_fel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_obtener_informacion_fel.ForeColor = System.Drawing.Color.White
        Me.btn_obtener_informacion_fel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_obtener_informacion_fel.ImageIndex = 2
        Me.btn_obtener_informacion_fel.ImageList = Me.ImageList1
        Me.btn_obtener_informacion_fel.Location = New System.Drawing.Point(234, 50)
        Me.btn_obtener_informacion_fel.Name = "btn_obtener_informacion_fel"
        Me.btn_obtener_informacion_fel.Size = New System.Drawing.Size(96, 74)
        Me.btn_obtener_informacion_fel.TabIndex = 68
        Me.btn_obtener_informacion_fel.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_obtener_informacion_fel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_obtener_informacion_fel.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(33, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 16)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Fecha"
        '
        'dtp_fel_inicio
        '
        Me.dtp_fel_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_inicio.Location = New System.Drawing.Point(128, 5)
        Me.dtp_fel_inicio.Name = "dtp_fel_inicio"
        Me.dtp_fel_inicio.Size = New System.Drawing.Size(100, 21)
        Me.dtp_fel_inicio.TabIndex = 61
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(128, 86)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 21)
        Me.TextBox7.TabIndex = 71
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(33, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 13)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "Documentos"
        '
        'txtDocumentosFel
        '
        Me.txtDocumentosFel.Location = New System.Drawing.Point(128, 35)
        Me.txtDocumentosFel.Name = "txtDocumentosFel"
        Me.txtDocumentosFel.ReadOnly = True
        Me.txtDocumentosFel.Size = New System.Drawing.Size(100, 21)
        Me.txtDocumentosFel.TabIndex = 62
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(33, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 69
        Me.Label22.Text = "No. Recepcion"
        '
        'dtp_fel_final
        '
        Me.dtp_fel_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_final.Location = New System.Drawing.Point(234, 5)
        Me.dtp_fel_final.Name = "dtp_fel_final"
        Me.dtp_fel_final.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fel_final.TabIndex = 63
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(128, 61)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(100, 21)
        Me.TextBox14.TabIndex = 72
        '
        'button_reimprimir_recibos
        '
        Me.button_reimprimir_recibos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.button_reimprimir_recibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_reimprimir_recibos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button_reimprimir_recibos.ForeColor = System.Drawing.Color.White
        Me.button_reimprimir_recibos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.button_reimprimir_recibos.ImageIndex = 5
        Me.button_reimprimir_recibos.Location = New System.Drawing.Point(438, 50)
        Me.button_reimprimir_recibos.Name = "button_reimprimir_recibos"
        Me.button_reimprimir_recibos.Size = New System.Drawing.Size(96, 74)
        Me.button_reimprimir_recibos.TabIndex = 66
        Me.button_reimprimir_recibos.Text = "Reimprimir Recibos"
        Me.button_reimprimir_recibos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.button_reimprimir_recibos.UseVisualStyleBackColor = False
        '
        'btn_liberar_envios_fel
        '
        Me.btn_liberar_envios_fel.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_liberar_envios_fel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_liberar_envios_fel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_liberar_envios_fel.ForeColor = System.Drawing.Color.White
        Me.btn_liberar_envios_fel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_liberar_envios_fel.ImageIndex = 5
        Me.btn_liberar_envios_fel.ImageList = Me.ImageList1
        Me.btn_liberar_envios_fel.Location = New System.Drawing.Point(336, 50)
        Me.btn_liberar_envios_fel.Name = "btn_liberar_envios_fel"
        Me.btn_liberar_envios_fel.Size = New System.Drawing.Size(96, 74)
        Me.btn_liberar_envios_fel.TabIndex = 65
        Me.btn_liberar_envios_fel.Text = "Liberar Envios"
        Me.btn_liberar_envios_fel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_liberar_envios_fel.UseVisualStyleBackColor = False
        '
        'verificarFEL
        '
        Me.verificarFEL.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.verificarFEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.verificarFEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verificarFEL.ForeColor = System.Drawing.Color.White
        Me.verificarFEL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.verificarFEL.ImageIndex = 3
        Me.verificarFEL.ImageList = Me.ImageList1
        Me.verificarFEL.Location = New System.Drawing.Point(540, 50)
        Me.verificarFEL.Name = "verificarFEL"
        Me.verificarFEL.Size = New System.Drawing.Size(96, 74)
        Me.verificarFEL.TabIndex = 67
        Me.verificarFEL.Text = "Verficar FEL"
        Me.verificarFEL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.verificarFEL.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(33, 63)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 13)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "No. Envio"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CheckBox1)
        Me.TabPage4.Controls.Add(Me.Label26)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.dgvNC)
        Me.TabPage4.Controls.Add(Me.btnGenerarTXTNC)
        Me.TabPage4.Controls.Add(Me.dgvNCDetalle)
        Me.TabPage4.Controls.Add(Me.btnLiberarEnviosNC)
        Me.TabPage4.Controls.Add(Me.btnObtenerNC)
        Me.TabPage4.Controls.Add(Me.TextBox6)
        Me.TabPage4.Controls.Add(Me.dtpFechaFinNC)
        Me.TabPage4.Controls.Add(Me.dtpFechaInicioNC)
        Me.TabPage4.Controls.Add(Me.Label28)
        Me.TabPage4.Controls.Add(Me.TextBox4)
        Me.TabPage4.Controls.Add(Me.TextBox5)
        Me.TabPage4.Controls.Add(Me.Label27)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1421, 639)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "NCredito"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(361, 10)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 17)
        Me.CheckBox1.TabIndex = 75
        Me.CheckBox1.Text = "Generar Todo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(27, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 16)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "Fecha"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.btnReimpresionNC)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox3.Controls.Add(Me.btnGenerarFACENC)
        Me.GroupBox3.Location = New System.Drawing.Point(968, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(440, 102)
        Me.GroupBox3.TabIndex = 74
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Factura Electronica"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(6, 75)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(428, 21)
        Me.TextBox3.TabIndex = 57
        '
        'btnReimpresionNC
        '
        Me.btnReimpresionNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionNC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimpresionNC.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionNC.ImageIndex = 4
        Me.btnReimpresionNC.ImageList = Me.ImageList1
        Me.btnReimpresionNC.Location = New System.Drawing.Point(271, 7)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 66)
        Me.btnReimpresionNC.TabIndex = 56
        Me.btnReimpresionNC.Text = "ReImpresion"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(94, 13)
        Me.Label25.TabIndex = 49
        Me.Label25.Text = "Numero de Copias"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(105, 21)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(37, 21)
        Me.NumericUpDown2.TabIndex = 55
        Me.NumericUpDown2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'btnGenerarFACENC
        '
        Me.btnGenerarFACENC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarFACENC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarFACENC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarFACENC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarFACENC.ForeColor = System.Drawing.Color.White
        Me.btnGenerarFACENC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarFACENC.ImageIndex = 0
        Me.btnGenerarFACENC.ImageList = Me.ImageList1
        Me.btnGenerarFACENC.Location = New System.Drawing.Point(169, 7)
        Me.btnGenerarFACENC.Name = "btnGenerarFACENC"
        Me.btnGenerarFACENC.Size = New System.Drawing.Size(96, 66)
        Me.btnGenerarFACENC.TabIndex = 45
        Me.btnGenerarFACENC.Text = "Generar FACE"
        Me.btnGenerarFACENC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarFACENC.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(27, 65)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 69
        Me.Label29.Text = "No. Envio"
        '
        'dgvNC
        '
        Me.dgvNC.AllowUserToAddRows = False
        Me.dgvNC.AllowUserToDeleteRows = False
        Me.dgvNC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNC.Location = New System.Drawing.Point(0, 143)
        Me.dgvNC.Name = "dgvNC"
        Me.dgvNC.RowHeadersWidth = 25
        Me.dgvNC.Size = New System.Drawing.Size(1413, 457)
        Me.dgvNC.TabIndex = 73
        '
        'btnGenerarTXTNC
        '
        Me.btnGenerarTXTNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarTXTNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarTXTNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarTXTNC.ForeColor = System.Drawing.Color.White
        Me.btnGenerarTXTNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarTXTNC.ImageIndex = 3
        Me.btnGenerarTXTNC.ImageList = Me.ImageList1
        Me.btnGenerarTXTNC.Location = New System.Drawing.Point(361, 41)
        Me.btnGenerarTXTNC.Name = "btnGenerarTXTNC"
        Me.btnGenerarTXTNC.Size = New System.Drawing.Size(96, 74)
        Me.btnGenerarTXTNC.TabIndex = 66
        Me.btnGenerarTXTNC.Text = "Generar TXT"
        Me.btnGenerarTXTNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarTXTNC.UseVisualStyleBackColor = False
        '
        'dgvNCDetalle
        '
        Me.dgvNCDetalle.AllowUserToAddRows = False
        Me.dgvNCDetalle.AllowUserToDeleteRows = False
        Me.dgvNCDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNCDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNCDetalle.Location = New System.Drawing.Point(1, 603)
        Me.dgvNCDetalle.Name = "dgvNCDetalle"
        Me.dgvNCDetalle.ReadOnly = True
        Me.dgvNCDetalle.RowHeadersWidth = 20
        Me.dgvNCDetalle.Size = New System.Drawing.Size(1417, 306)
        Me.dgvNCDetalle.TabIndex = 72
        '
        'btnLiberarEnviosNC
        '
        Me.btnLiberarEnviosNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLiberarEnviosNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLiberarEnviosNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberarEnviosNC.ForeColor = System.Drawing.Color.White
        Me.btnLiberarEnviosNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLiberarEnviosNC.ImageIndex = 5
        Me.btnLiberarEnviosNC.ImageList = Me.ImageList1
        Me.btnLiberarEnviosNC.Location = New System.Drawing.Point(463, 41)
        Me.btnLiberarEnviosNC.Name = "btnLiberarEnviosNC"
        Me.btnLiberarEnviosNC.Size = New System.Drawing.Size(96, 74)
        Me.btnLiberarEnviosNC.TabIndex = 65
        Me.btnLiberarEnviosNC.Text = "Liberar Envios"
        Me.btnLiberarEnviosNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLiberarEnviosNC.UseVisualStyleBackColor = False
        '
        'btnObtenerNC
        '
        Me.btnObtenerNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtenerNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnObtenerNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnObtenerNC.ForeColor = System.Drawing.Color.White
        Me.btnObtenerNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtenerNC.ImageIndex = 2
        Me.btnObtenerNC.ImageList = Me.ImageList1
        Me.btnObtenerNC.Location = New System.Drawing.Point(259, 41)
        Me.btnObtenerNC.Name = "btnObtenerNC"
        Me.btnObtenerNC.Size = New System.Drawing.Size(96, 74)
        Me.btnObtenerNC.TabIndex = 67
        Me.btnObtenerNC.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btnObtenerNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtenerNC.UseVisualStyleBackColor = False
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(122, 63)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 21)
        Me.TextBox6.TabIndex = 71
        '
        'dtpFechaFinNC
        '
        Me.dtpFechaFinNC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinNC.Location = New System.Drawing.Point(228, 7)
        Me.dtpFechaFinNC.Name = "dtpFechaFinNC"
        Me.dtpFechaFinNC.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaFinNC.TabIndex = 63
        '
        'dtpFechaInicioNC
        '
        Me.dtpFechaInicioNC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioNC.Location = New System.Drawing.Point(122, 7)
        Me.dtpFechaInicioNC.Name = "dtpFechaInicioNC"
        Me.dtpFechaInicioNC.Size = New System.Drawing.Size(100, 21)
        Me.dtpFechaInicioNC.TabIndex = 61
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(27, 90)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 13)
        Me.Label28.TabIndex = 68
        Me.Label28.Text = "No. Recepcion"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(122, 88)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 21)
        Me.TextBox4.TabIndex = 70
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(122, 37)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(100, 21)
        Me.TextBox5.TabIndex = 62
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(27, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(66, 13)
        Me.Label27.TabIndex = 60
        Me.Label27.Text = "Documentos"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.dgvResumenEnvios)
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Controls.Add(Me.btnAgregar)
        Me.TabPage5.Controls.Add(Me.Label36)
        Me.TabPage5.Controls.Add(Me.Label35)
        Me.TabPage5.Controls.Add(Me.Label34)
        Me.TabPage5.Controls.Add(Me.Label33)
        Me.TabPage5.Controls.Add(Me.Label32)
        Me.TabPage5.Controls.Add(Me.Label31)
        Me.TabPage5.Controls.Add(Me.Label30)
        Me.TabPage5.Controls.Add(Me.txtMontoEnvio)
        Me.TabPage5.Controls.Add(Me.txtObservacionesEnvio)
        Me.TabPage5.Controls.Add(Me.txtClienteEnvio)
        Me.TabPage5.Controls.Add(Me.TextBox8)
        Me.TabPage5.Controls.Add(Me.txtNumeroFacturaEnvio)
        Me.TabPage5.Controls.Add(Me.cmbTipoDoctoEnvio)
        Me.TabPage5.Controls.Add(Me.cmbEmpresaEnvio)
        Me.TabPage5.Controls.Add(Me.dgvDetalleEnvios)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1421, 639)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Envios"
        '
        'dgvResumenEnvios
        '
        Me.dgvResumenEnvios.AllowUserToAddRows = False
        Me.dgvResumenEnvios.AllowUserToDeleteRows = False
        Me.dgvResumenEnvios.AllowUserToOrderColumns = True
        Me.dgvResumenEnvios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResumenEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumenEnvios.Location = New System.Drawing.Point(308, 130)
        Me.dgvResumenEnvios.Name = "dgvResumenEnvios"
        Me.dgvResumenEnvios.RowHeadersWidth = 51
        Me.dgvResumenEnvios.Size = New System.Drawing.Size(1080, 782)
        Me.dgvResumenEnvios.TabIndex = 7
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnNuevoEnvio)
        Me.GroupBox4.Controls.Add(Me.btnProcesarEnvio)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.TextBox12)
        Me.GroupBox4.Location = New System.Drawing.Point(852, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'btnNuevoEnvio
        '
        Me.btnNuevoEnvio.Location = New System.Drawing.Point(24, 58)
        Me.btnNuevoEnvio.Name = "btnNuevoEnvio"
        Me.btnNuevoEnvio.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevoEnvio.TabIndex = 5
        Me.btnNuevoEnvio.Text = "Nuevo"
        Me.btnNuevoEnvio.UseVisualStyleBackColor = True
        '
        'btnProcesarEnvio
        '
        Me.btnProcesarEnvio.Location = New System.Drawing.Point(119, 58)
        Me.btnProcesarEnvio.Name = "btnProcesarEnvio"
        Me.btnProcesarEnvio.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesarEnvio.TabIndex = 5
        Me.btnProcesarEnvio.Text = "Procesar"
        Me.btnProcesarEnvio.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(21, 17)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(53, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Envio No."
        '
        'TextBox12
        '
        Me.TextBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox12.Location = New System.Drawing.Point(74, 14)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(121, 21)
        Me.TextBox12.TabIndex = 2
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(541, 37)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(42, 86)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(37, 13)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Monto"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(42, 64)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 13)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Observaciones"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(42, 42)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 13)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Cliente"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(623, 10)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(33, 13)
        Me.Label33.TabIndex = 4
        Me.Label33.Text = "Barra"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(442, 10)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(44, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Numero"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(251, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Documento"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(42, 9)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 13)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "Empresa"
        '
        'txtMontoEnvio
        '
        Me.txtMontoEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoEnvio.Location = New System.Drawing.Point(120, 83)
        Me.txtMontoEnvio.Name = "txtMontoEnvio"
        Me.txtMontoEnvio.Size = New System.Drawing.Size(121, 21)
        Me.txtMontoEnvio.TabIndex = 2
        '
        'txtObservacionesEnvio
        '
        Me.txtObservacionesEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacionesEnvio.Location = New System.Drawing.Point(120, 61)
        Me.txtObservacionesEnvio.Name = "txtObservacionesEnvio"
        Me.txtObservacionesEnvio.Size = New System.Drawing.Size(330, 21)
        Me.txtObservacionesEnvio.TabIndex = 2
        '
        'txtClienteEnvio
        '
        Me.txtClienteEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClienteEnvio.Location = New System.Drawing.Point(120, 39)
        Me.txtClienteEnvio.Name = "txtClienteEnvio"
        Me.txtClienteEnvio.Size = New System.Drawing.Size(330, 21)
        Me.txtClienteEnvio.TabIndex = 2
        '
        'TextBox8
        '
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Location = New System.Drawing.Point(662, 7)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(121, 21)
        Me.TextBox8.TabIndex = 2
        '
        'txtNumeroFacturaEnvio
        '
        Me.txtNumeroFacturaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroFacturaEnvio.Location = New System.Drawing.Point(492, 7)
        Me.txtNumeroFacturaEnvio.Name = "txtNumeroFacturaEnvio"
        Me.txtNumeroFacturaEnvio.Size = New System.Drawing.Size(121, 21)
        Me.txtNumeroFacturaEnvio.TabIndex = 2
        '
        'cmbTipoDoctoEnvio
        '
        Me.cmbTipoDoctoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoctoEnvio.DropDownWidth = 170
        Me.cmbTipoDoctoEnvio.FormattingEnabled = True
        Me.cmbTipoDoctoEnvio.Location = New System.Drawing.Point(318, 7)
        Me.cmbTipoDoctoEnvio.Name = "cmbTipoDoctoEnvio"
        Me.cmbTipoDoctoEnvio.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoDoctoEnvio.TabIndex = 1
        '
        'cmbEmpresaEnvio
        '
        Me.cmbEmpresaEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresaEnvio.FormattingEnabled = True
        Me.cmbEmpresaEnvio.Location = New System.Drawing.Point(120, 6)
        Me.cmbEmpresaEnvio.Name = "cmbEmpresaEnvio"
        Me.cmbEmpresaEnvio.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresaEnvio.TabIndex = 1
        '
        'dgvDetalleEnvios
        '
        Me.dgvDetalleEnvios.AllowUserToAddRows = False
        Me.dgvDetalleEnvios.AllowUserToDeleteRows = False
        Me.dgvDetalleEnvios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleEnvios.Location = New System.Drawing.Point(18, 130)
        Me.dgvDetalleEnvios.Name = "dgvDetalleEnvios"
        Me.dgvDetalleEnvios.RowHeadersWidth = 51
        Me.dgvDetalleEnvios.Size = New System.Drawing.Size(284, 782)
        Me.dgvDetalleEnvios.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 32)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Resolucion"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(8, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comentario Pedido"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Guardar.Location = New System.Drawing.Point(464, 16)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Guardar.TabIndex = 11
        Me.Btn_Guardar.Text = "Aceptar"
        Me.Btn_Guardar.Visible = False
        '
        'dtp_fecha_Entrega
        '
        Me.dtp_fecha_Entrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_Entrega.Location = New System.Drawing.Point(456, 48)
        Me.dtp_fecha_Entrega.Name = "dtp_fecha_Entrega"
        Me.dtp_fecha_Entrega.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_Entrega.TabIndex = 23
        Me.dtp_fecha_Entrega.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1, 665)
        Me.Splitter1.TabIndex = 54
        Me.Splitter1.TabStop = False
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(6, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(428, 20)
        Me.TextBox2.TabIndex = 57
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 4
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(271, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 66)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "ReImpresion"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 13)
        Me.Label24.TabIndex = 49
        Me.Label24.Text = "Numero de Copias"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(105, 21)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(37, 20)
        Me.NumericUpDown1.TabIndex = 55
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.ImageIndex = 0
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(169, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 66)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "Generar FACE"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frm_pedidos_facturar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1429, 665)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_pedidos_facturar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ":: FACTURACION ::"
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleFACE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_encabezado_fel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_detalle_fel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNCDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgvResumenEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvDetalleEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        Me.dgv_detalle.DataSource = Nothing

        If lpedidos_posfechados Then
            'Limpiar_Bindings()
            'Pedidos_PosFechados()
            'Crear_Bindings()


        ElseIf lanular_memos Then
            Memos_Activos()

        Else
            Try
                Pedidos_Pendientes()
                Crear_Bindings()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Pedidos_Pendientes()
        'Dim oTrans As Transaccional.Conexion
        'Dim oTabla As DataTable
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView

        Dim ls_sqltxt As String
        Dim ls_filtro As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General
        oDataSet = New DataSet
        Limpiar_Bindings()


        Dim oTrans As New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            ls_sqltxt = "pa_var_um_pedidos_pendientes_facturar_empresa_cedi_usuario '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'," & Me.txt_porcentaje.Text & ",'" & gs_usuario & "'"

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "pedidos"
            oDataSet.Tables.Add(dt.Copy)

            ''ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            ''dt = oTrans.Obtiene(ls_sqltxt)

            ''ls_filtro = ""
            ''icount = 0
            ''For Each dr In dt.Rows
            ''    If icount > 0 Then
            ''        ls_filtro += " OR "
            ''    End If
            ''    ls_filtro += "Empresa = '" & dr.Item("empresa").ToString & "'"
            ''    icount += 1
            ''Next


            ''Armar_Filtro
            'ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            'dt = oTrans.Obtiene(ls_sqltxt)

            'dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            'ls_filtro = ""



            If chk_todo.CheckState = CheckState.Unchecked Then ls_filtro = "("

            'For Each drv In dt.DefaultView
            '    ls_filtro += IIf(ls_filtro.Length > 1, " OR ", "") & "(Empresa = '" & drv.Item("EMPRESA") & "' AND (AnalisisCtaCte2 = '" & drv.Item("TEXTO") & "' "
            '    If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
            '    If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
            '    ls_filtro += "))"
            '    'IIf(drv.Item("TEXTO1").ToString.Length > 0, , "") & _
            '    ''IIf(drv.Item("TEXTO2").ToString.Length > 0, " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'", "") & "))"
            'Next

            If chk_todo.CheckState = CheckState.Unchecked Then
                If ls_filtro.Length > 1 Then ls_filtro += " and "
                ls_filtro += "comentario2 = '')"
            End If

            oDataSet.Tables("pedidos").DefaultView.RowFilter = ls_filtro



            dgv_encabezado.DataSource = oDataSet.Tables("pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("pedidos"), dgv_encabezado, "", ",limitecredito,vigencia,Comentario_Cliente,Aprobacion,", "", "", "", ",minutos=30,porcentajeasignado=40,comentario2=80,cedi=30,", "", True, True, 200, 0)

            'Colorear_Grid()

            ls_sqltxt = "pa_var_um_detalle_pedidos_pendientes_facturar_empresa_usuario '" & dtp_fecha_inicio.Text & "','" & dtp_fecha_final.Text & "'," & txt_porcentaje.Text & ",'" & gs_usuario & "'"

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "detalle_pedidos"
            oDataSet.Tables.Add(dt.Copy)

            Me.txtCantidadPedidos.Text = oDataSet.Tables("pedidos").DefaultView.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try


        mostrar_detalle_pedido()
    End Sub


    Private Sub Pedidos_Pendientes_20220802()
        'Dim oTrans As Transaccional.Conexion
        'Dim oTabla As DataTable
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView

        Dim ls_sqltxt As String
        Dim ls_filtro As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General
        oDataSet = New DataSet
        Limpiar_Bindings()


        Dim oTrans As New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            ls_sqltxt = "pa_var_um_pedidos_pendientes_facturar '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'," & Me.txt_porcentaje.Text

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "pedidos"
            oDataSet.Tables.Add(dt.Copy)

            ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = oTrans.Obtiene(ls_sqltxt)

            ls_filtro = ""
            icount = 0
            For Each dr In dt.Rows
                If icount > 0 Then
                    ls_filtro += " OR "
                End If
                ls_filtro += "Empresa = '" & dr.Item("empresa").ToString & "'"
                icount += 1
            Next


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            ls_filtro = ""



            If chk_todo.CheckState = CheckState.Unchecked Then ls_filtro = "("

            For Each drv In dt.DefaultView
                ls_filtro += IIf(ls_filtro.Length > 1, " OR ", "") & "(Empresa = '" & drv.Item("EMPRESA") & "' AND (AnalisisCtaCte2 = '" & drv.Item("TEXTO") & "' "
                If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
                If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
                ls_filtro += "))"
                'IIf(drv.Item("TEXTO1").ToString.Length > 0, , "") & _
                ''IIf(drv.Item("TEXTO2").ToString.Length > 0, " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'", "") & "))"
            Next

            If chk_todo.CheckState = CheckState.Unchecked Then
                If ls_filtro.Length > 1 Then ls_filtro += " and "
                ls_filtro += "comentario2 = '')"
            End If

            oDataSet.Tables("pedidos").DefaultView.RowFilter = ls_filtro



            dgv_encabezado.DataSource = oDataSet.Tables("pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("pedidos"), dgv_encabezado, "", ",limitecredito,vigencia,Comentario_Cliente,Aprobacion,", "", "", "", ",minutos=30,", "", True, True, 250, 0)

            'Colorear_Grid()

            ls_sqltxt = "pa_var_um_detalle_pedidos_pendientes_facturar '" & dtp_fecha_inicio.Text & "','" & dtp_fecha_final.Text & "'," & txt_porcentaje.Text

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "detalle_pedidos"

            oDataSet.Tables.Add(dt.Copy)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try


        mostrar_detalle_pedido()
    End Sub


    Private Sub Pedidos_PosFechados()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            Me.dgv_encabezado.DataSource = Nothing

            Otrans.open()
            ls_sql = "pa_var_um_documentos_posfechados '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pedidos"
            If oDataSet.Tables.Contains("pedidos") Then
                oDataSet.Tables.Remove("pedidos")
            End If

            oDataSet.Tables.Add(dt.Copy)
            Me.dgv_encabezado.DataSource = oDataSet.Tables("pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("pedidos"), dgv_encabezado, "", ",limitecredito,vigencia_cliente,Comentario_Cliente,Aprobacion,porcentajeasignado,", "", "", "", "", "", True, True, 150, 0)
            ' Me.Colorear_Grid_posfechados()
            'ClsGen.Alinea_Grid(dt, Me.dg_pedidos, -1, 250, 50, False, True, "", True, "")

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Memos_Activos()

        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2 As DataTable
        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General



        Try
            oTrans.open()
            'myOtrans.open()
            ls_sql = "pa_var_um_memos_activos '" & gs_empresa & "','" & dtp_fecha_inicio.Text & "','" & dtp_fecha_final.Text & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "memos"
            If oDataSet.Tables.Contains("memos") Then
                oDataSet.Tables.Remove("memos")
            End If
            dt.Columns.Add(New DataColumn("usuario_autorizo", GetType(String)))
            dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
            dt.Columns.Add(New DataColumn("usuario_solicito", GetType(String)))

            For Each dr As DataRow In dt.Rows

                ls_sql = " pa_var_um_mmp_encabezado " & ClsGen.Codigo_Empresa_Onbase(gs_empresa) & "," & dr.Item("numero").ToString & ""
                dt2 = ClsGen.selectQuery("Corporativo", ls_sql)
                If dt2.Rows.Count > 0 Then
                    dr.Item("usuario_autorizo") = dt2.Rows(0).Item("usuario_autorizo")
                    dr.Item("usuario_grabo") = dt2.Rows(0).Item("usuario_grabo")
                    dr.Item("usuario_solicito") = dt2.Rows(0).Item("usuario_solicito")
                End If
            Next

            oDataSet.Tables.Add(dt.Copy)
            Me.dgv_encabezado.DataSource = oDataSet.Tables("memos")
            ClsGen.Alinear_GridView(oDataSet.Tables("memos"), dgv_encabezado, "", ",limitecredito,vigencia_cliente,Comentario_Cliente,Aprobacion,", "", "", "", "", "", True, True, 150, 0)

            'Colorear_memos()
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
            'myOtrans.close()
            'myOtrans = Nothing
        End Try


    End Sub

    Private Sub dg_pedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not lpedidos_posfechados And Not lanular_memos Then
            'con un click muestro el detalle del pedido
            Try
                Dim li_row_number As Integer
                ' li_row_number = Me.dg_pedidos.CurrentCell.RowNumber
                detalle_pedido(li_row_number)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)
        Dim ClsGen As New ClasesGenerales.General

        Try
            Me.txt_total_unidades.Text = "0"
            Dim ls_resultado, tipo_docto As String
            Dim ls_filtro, ls_empresa As String

            ls_resultado = Me.dgv_encabezado.Item("numero", pi_RowNumber).Value
            tipo_docto = Me.dgv_encabezado.Item("tipodocto", pi_RowNumber).Value
            ls_empresa = Me.dgv_encabezado.Item("empresa", pi_RowNumber).Value


            ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas

            ls_filtro = "empresa = '" & ls_empresa & "' and numero = '" & ls_resultado & "' and tipoDocto = '" & tipo_docto & "'"
            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = ls_filtro
            '"numero = '" & ls_resultado & "' and tipoDocto = '" & tipo_docto & "'"

            Me.txt_total_lineas.Text = oDataSet.Tables("detalle_pedidos").DefaultView.Count
            Me.dgv_detalle.DataSource = oDataSet.Tables("detalle_pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgv_detalle, "", ",tipodocto,empresa,codbarra,innerpack,correlativo,secuencia,", "", "", "", "", "", True, True, 200, 0)
            ' Me.dg_pedidos.Refresh()
            Me.txt_total_unidades.Text = oDataSet.Tables("detalle_pedidos").DefaultView.ToTable.Compute("sum(Cantidad)", "Cantidad > 0")
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

        'Me.Colorear_Grid_detalle(oDataSet.Tables("detalle_pedidos"))
    End Sub

    Private Sub Customizar_Forma()
        If Me.lpedidos_posfechados Then
            Me.Text = "Pedidos Posfechados"
            'Me.dgv_encabezado.CaptionTex= "Pedidos"
            Me.dgv_detalle.Visible = False
            Me.dgv_encabezado.Size = New System.Drawing.Size(912, 440)
            Me.Label3.Text = "Fecha de Entrega"
            Me.cmb_estados.Visible = False
            Me.dtp_fecha_Entrega.Visible = True
            Me.dtp_fecha_Entrega.Location = New System.Drawing.Point(72, 16)
            'Me.gb_colores.Visible = True

            Me.lbl_facturado.Visible = False
            Me.txt_porcentaje.Visible = False
            Me.lbl_total_lineas.Visible = False
            Me.txt_total_lineas.Visible = False

        ElseIf lanular_memos Then
            Me.Text = "Memos Activos"
            'Me.dg_pedidos.CaptionText = "Memos Activos"
            Me.dgv_detalle.Visible = False
            Me.dgv_encabezado.Size = New System.Drawing.Size(912, 440)
            Me.Label3.Text = "Fecha de Entrega"
            Me.cmb_estados.Visible = False
            Me.dtp_fecha_Entrega.Visible = False
            Me.dtp_fecha_Entrega.Location = New System.Drawing.Point(72, 16)
            'Me.gb_colores.Visible = False
            Me.GroupBox1.Visible = False
            Me.Btn_Estado_Cuenta.Visible = True
            Me.Btn_Estado_Cuenta.Text = "Anular"

            Me.Label9.Visible = False
            Me.txt_total_pedido.Visible = False

            Me.lbl_facturado.Visible = False
            Me.txt_porcentaje.Visible = False
            Me.lbl_total_lineas.Visible = False
            Me.txt_total_lineas.Visible = False

            Me.btnVerificar.Visible = False
            Me.btnValidarStock.Visible = False
        Else
            Me.Btn_Estado_Cuenta.Visible = True
            Me.Btn_Estado_Cuenta.Text = "Visualizar"
            Me.btnAceptar.Visible = True
            Me.btnFacturacion_RecogeBodega.Visible = True
        End If

    End Sub

    Private Sub Mostrar_Controles_Asociados()
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim ls_sql As String
        Dim nrow As Integer

        Dim ls_empresa, ls_tipodocto, ls_numero As String

        nrow = Me.dgv_encabezado.CurrentRow.Index
        'detalle_pedido(nrow_number)
        ls_empresa = Me.dgv_encabezado.Item("empresa", nrow).Value
        ls_tipodocto = Me.dgv_encabezado.Item("tipodocto", nrow).Value
        ls_numero = Me.dgv_encabezado.Item("numero", nrow).Value

        Try
            Otrans.abrir()


            ls_sql = "pa_sel_var_documento_generado '" & ls_empresa & "','" &
                           ls_tipodocto & "','" &
                           ls_numero & "'"

            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count = 0 Then
                ls_sql = "pa_var_um_documento_control_transporte '" & ls_empresa & "','" &
                                           ls_tipodocto & "','" &
                                           ls_numero & "'"
                dt = Otrans.Obtiene(ls_sql)
            End If

            If dt.Rows.Count > 0 Then
                Dim oform As New frm_resultado
                Dim clsgen As New ClasesGenerales.General
                Dim cl As DataGridTextBoxColumn

                oform.dgv_resultado.DataSource = dt
                'clsgen.Alinea_Grid(dt, oform.DataGrid1, _
                '                            -1, 200, 0, False, True, ",tipoDocto, numero, fecha_guia, vehiculo, ayudante, comentario,analisis, TipoCta,glosa,AnalisisE1,AnalisisE2,fecha_recepcion,usuario_recepcion", True, "")

                clsgen.Alinear_GridView(dt, oform.dgv_resultado, ",tipoDocto,numero,fecha_guia,vehiculo,ayudante,comentario,analisis,TipoCta,glosa,AnalisisE1,AnalisisE2,fecha_recepcion,usuario_recepcion,", "", "", "", "", "", "", True, True, 200, 0)



                For Each cl In oform.dgv_resultado.Columns
                    If cl.HeaderText.ToLower = "analisis" Then
                        cl.HeaderText = "Piloto"
                    ElseIf cl.HeaderText.ToLower = "tipocta" Then
                        cl.HeaderText = "Vehiculo"
                    ElseIf cl.HeaderText.ToLower = "analisise1" Then
                        cl.HeaderText = "Auxiliar"
                    ElseIf cl.HeaderText.ToLower = "analisise2" Then
                        cl.HeaderText = "Chequeador"
                    ElseIf cl.HeaderText.ToLower = "glosa" Then
                        cl.HeaderText = "Ruta"
                    End If
                Next

                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(0)
                ''cl.HeaderText = "Control"
                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(1)
                ''cl.HeaderText = "Numero"
                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(2)
                ''cl.HeaderText = "Fecha Control"
                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(3)
                ''cl.HeaderText = "TipoDocto"
                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(4)
                ''cl.HeaderText = "NumeroDocto"
                ''cl = oform.DataGrid1.TableStyles(0).GridColumnStyles(5)
                ''cl.HeaderText = "Motivo"
                oform.Text = "Controles Asociados"

                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
                clsgen = Nothing
            End If

        Catch ex As Exception
        Finally
            Otrans.cerrar()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub Anular_Memo()

        Dim nrow As Integer
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        Dim ubicacion_actual As String


        Try
            otrans.open()
            myOtrans.open()
            nrow = Me.dgv_encabezado.CurrentRow.Index

            If Me.dgv_encabezado.Item("usuario_autorizo", nrow).Value.ToString.Trim.ToLower.Equals(gs_usuario.ToLower) Or gi_tipo_usuario = 1 Then


                If MessageBox.Show("Esta Seguro de Anular El Memo " & Me.dgv_encabezado.Item("correlativo_flex", nrow).Value, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ls_sql = "pa_upd_um_productooferta '" & gs_empresa & "','" & Me.dgv_encabezado.Item("correlativo_flex", nrow).Value & "','" &
                                Me.dgv_encabezado.Item("listaprecio", nrow).Value.ToString.Trim & "','" & gs_usuario & "'"

                    otrans.Actualiza(ls_sql)
                    If otrans.Codigo_error > 0 Then
                        MessageBox.Show("Error " & otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        clsGen.Escribir_Log(ls_sql & " " & gs_usuario)
                        MessageBox.Show("Memo Actualizado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ls_ubicaciones = Me.dgv_encabezado.Item("ubicaciones", nrow).Value
                        If ls_ubicaciones.Trim.Length > 0 Then
                            otrans.close()
                            For Each ubicacion_actual In ls_ubicaciones.Split(",")
                                If ubicacion_actual.Length > 0 Then

                                    otrans = New Transaccional.Conexion("FlexLine" & ubicacion_actual.Trim)
                                    Try
                                        otrans.open()
                                        otrans.Actualiza(ls_sql)
                                        If otrans.Codigo_error > 0 Then
                                            MessageBox.Show("Error al Anular en " & ubicacion_actual & " " & otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Else
                                            MessageBox.Show("Memo Actualizado Correctamente en " & ubicacion_actual, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                    Catch ex As Exception
                                    Finally
                                        otrans.close()
                                    End Try
                                End If
                            Next
                        End If


                        Try
                            clsGen.enviarMensajeTeams(gs_cuenta_usuario, "Memo Anulado", "El Memo " & Me.dgv_encabezado.Item("correlativo_flex", nrow).Value & " ha sido anulado por " & gs_nombre_usuario)

                            Dim dt As DataTable
                            dt = clsGen.selectQuery("Flexline", "pa_sel_um_sg_usuario_email '" & Me.dgv_encabezado.Item("usuario_grabo", nrow).Value.ToString.Trim & "'")

                            If dt.Rows.Count > 0 Then
                                clsGen.enviarMensajeTeams(dt.Rows(0).Item("correo").ToString, "Memo Anulado", "El Memo " & Me.dgv_encabezado.Item("correlativo_flex", nrow).Value & " ha sido anulado por " & gs_nombre_usuario)
                            End If

                            dt = clsGen.selectQuery("Flexline", "pa_sel_um_sg_usuario_email '" & Me.dgv_encabezado.Item("usuario_solicito", nrow).Value.ToString.Trim & "'")

                            If dt.Rows.Count > 0 Then
                                clsGen.enviarMensajeTeams(dt.Rows(0).Item("correo").ToString, "Memo Anulado", "El Memo " & Me.dgv_encabezado.Item("correlativo_flex", nrow).Value & " ha sido anulado por " & gs_nombre_usuario)
                            End If


                        Catch ex As Exception

                        End Try


                        llenar_memos = True
                    End If
                End If
            Else
                MessageBox.Show("Solo el Usuario Que Autorizo Puede Anular El Memo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        If llenar_memos Then
            Memos_Activos()
        End If


    End Sub

    Private Sub Visualizar_Facturacion_Consignaciones()
        Dim nrow As Integer
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        Dim ubicacion_actual As String
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        ''Obtengo Datos de Conexion



        Try
            otrans.open()
            nrow = Me.dgv_encabezado.CurrentRow.Index
            pm_conexion = ClsGen.Parametros_Conexion("")
            ppath_reporte = ClsGen.Path_Reporte
            '023:
            Oaut = New Automatizar.Reportes_CraxDrt(Me.dgv_encabezado.Item("empresa", nrow).Value)
            path_reporte = ppath_reporte & "Finanzas\Facturacion\Facturar Consignacion.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_valores(0) = Me.dgv_encabezado.Item("empresa", nrow).Value
            pm_valores(1) = Me.dgv_encabezado.Item("tipodocto", nrow).Value
            pm_valores(2) = Me.dgv_encabezado.Item("numero", nrow).Value

            '                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                                      False, True, "PDF", False)
            Oaut.Archivo_Generado = "c:\temp\" & Me.dgv_encabezado.Item("empresa", nrow).Value & "_" & Me.dgv_encabezado.Item("tipodocto", nrow).Value & "_" & Me.dgv_encabezado.Item("numero", nrow).Value & ".pdf"
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                     True, True, "PDF", True)

            ls_sql = "pa_upd_um_documento_fecha_vcto '" & pm_valores(0) & "','" &
                            pm_valores(1) & "','" &
                            pm_valores(2) & "',NULL,NULL,NULL,100"
            otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub generarPedidoFACEAutomatico_cedi(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, psBodega As String, psCedi As String, pdDescuento As Double)
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        'Dim lsNumeroGenerado As String

        Try
            ' gs_usuario = "CARANA"
            'lsSQL = "pa_ins_um_pedido_FACE_automatico '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "'"
            '(c) 20220908
            'lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "','" & psCedi & "'"
            '(c) 20230309

            'lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi_descuento '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "','" & psCedi & "'," & pdDescuento

            '(c) 20241107
            lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi_descuento_porcentaje_asignado_minimo '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "','" & psCedi & "'," & pdDescuento & ",0"

            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then
                ' MessageBox.Show("Se Genero el Documento " & psEmpresa & " - - " & dt.Rows(0).Item("TipoDocto").ToString & " - -" & dt.Rows(0).Item("numero").ToString, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            Try
                MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Catch ex2 As Exception

            End Try

        Finally

            Try
                lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','" & dt.Rows(0).Item("TipoDocto").ToString & "','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                'lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','PEDIDO FEL','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                dt = clsGen.selectQuery("FlexLine", lsSQL)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                'eliminar el documento
            End Try


            clsGen = Nothing
        End Try
    End Sub

    Private Sub generarPedidoFACEAutomatico_cedi(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, psBodega As String, psCedi As String)
        generarPedidoFACEAutomatico_cedi(psEmpresa, psTipoDocto, psNumero, psBodega, psCedi, 0)

    End Sub


    Private Sub generarPedidoFACEAutomatico_old(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, psBodega As String)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lsNumeroGenerado As String

        Try
            'gs_usuario = "CARANA"
            '(c) 20230309
            'lsSQL = "pa_ins_um_pedido_FACE_automatico '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "'"

            lsSQL = "pa_ins_um_pedido_FACE_automatico_descuento '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "'"
            '(c) 20220908
            'lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "'"

            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Se Genero el Documento " & psEmpresa & " - - " & dt.Rows(0).Item("TipoDocto").ToString & " - -" & dt.Rows(0).Item("numero").ToString, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            Try
                MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Catch ex2 As Exception

            End Try

        Finally

            Try
                lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','" & dt.Rows(0).Item("TipoDocto").ToString & "','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                'lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','PEDIDO FEL','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                dt = clsGen.selectQuery("FlexLine", lsSQL)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                'eliminar el documento
            End Try


            clsGen = Nothing
        End Try
    End Sub


    Private Sub verificarDocumentoFEL()

        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtCertificacion, dtRelacion, dtPedidoFel, dtFel As DataTable

        Try


            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                If drv.Item("serieFACE").ToString.Length = 0 Or drv.Item("numeroFace").ToString.Length = 0 Then

                    'Paso 1
                    'Validar que haya generado FEL

                    lsSQL = "pa_var_um_fel_documento_cert '" & gs_empresa & "','" & drv.Item("Tipodocto").ToString & "','" & drv.Item("numero").ToString & "'"
                    dtCertificacion = ClsGen.selectQuery("Flexline", lsSQL)

                    If dtCertificacion.Rows.Count = 0 Then
                        MessageBox.Show("Este Documento No Esta Certificado, Verifique Simbolos en Nombre, Direccion, Comentarios, Forma de Pago, Luego Regrabe el Documento", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If


                    'paso 2
                    'validar tablas de documento
                    dtRelacion = ClsGen.selectQuery("FlexLine", "pa_var_um_relacion_fel")

                    dtRelacion.DefaultView.RowFilter = "tipodocto_origen = '" & drv.Item("tipoDocto").ToString & "'"
                    If dtRelacion.DefaultView.Count = 0 Then
                        MessageBox.Show("No Existe Relacion para Este Documento", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    'Paso 3
                    'Obtengo documentos para validar
                    dtPedidoFel = ClsGen.selectQuery("FlexLine", "pa_var_um_documento_validacion_fel '" & gs_empresa & "','" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "'")


                    dtFel = ClsGen.selectQuery("FlexLine", "pa_var_um_documento_validacion_fel '" & gs_empresa & "','" & dtRelacion.DefaultView(0).Item("tipodocto_destino").ToString & "','" & drv.Item("numero").ToString & "'")

                    'Paso 4
                    'Valido documento


                    Try
                        If dtFel.Rows(0).Item("documento") = 0 Then
                            MessageBox.Show("No se ha generdado FEL", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If



                    Catch ex As Exception

                    End Try


                    Try
                        If dtFel.Rows(0).Item("documentod").ToString = "" Or dtFel.Rows(0).Item("documentod").ToString = "0" Then
                            'Debo Generar Documentod

                            lsSQL = "pa_ins_um_documentod_FACE '" & gs_empresa & "', '" & drv.Item("tipodocto").ToString &
                                "','" & drv.Item("numero").ToString & "','" & dtRelacion.DefaultView(0).Item("tipodocto_destino").ToString &
                                "','" & drv.Item("numero").ToString & "','" & drv.Item("fecha").ToString & "'"
                            'lsSQL = "pa_ins_um_documentod_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941', '23-12-2020'"

                            ClsGen.insertQuery("FlexLine", lsSQL)
                            MessageBox.Show("No se ha generdado FEL", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Exit Sub
                        End If



                    Catch ex As Exception

                    End Try


                    Try
                        If dtFel.Rows(0).Item("documentop").ToString = "" Or dtFel.Rows(0).Item("documentop").ToString = "0" Then
                            'Debo Generar Documentod
                            'pa_ins_um_documentod_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941', '23-12-2020'
                            lsSQL = "pa_ins_um_documentop_FACE '" & gs_empresa & "', '" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "','" & dtRelacion.DefaultView(0).Item("tipodocto_destino").ToString & "','" & drv.Item("numero").ToString & "'"
                            ClsGen.insertQuery("FlexLine", lsSQL)


                        End If



                    Catch ex As Exception

                    End Try


                    Try
                        If dtFel.Rows(0).Item("documentov").ToString = "" Or dtFel.Rows(0).Item("documentov").ToString = "0" Then
                            'Debo Generar Documentod
                            'pa_ins_um_documentod_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941', '23-12-2020'
                            lsSQL = "pa_ins_um_documentov_FACE '" & gs_empresa & "', '" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "','" & dtRelacion.DefaultView(0).Item("tipodocto_destino").ToString & "','" & drv.Item("numero").ToString & "'"
                            ClsGen.insertQuery("FlexLine", lsSQL)


                        End If



                    Catch ex As Exception

                    End Try


                    'Finalizo Anulando el Documento Orgien

                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "', '" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "', NULL,'A','" & gs_usuario & "','" & dtRelacion.DefaultView(0).Item("tipodocto_destino").ToString & " " & drv.Item("numero").ToString & "'"
                    ClsGen.insertQuery("FlexLine", lsSQL)



                    '23/12/2020 15:36:26 pa_ins_um_documentod_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941', '23-12-2020'
                    '23/12/2020 15:36:26 pa_ins_um_documentop_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941'
                    '23/12/2020 15:36:26 pa_ins_um_documentov_FACE 'DMARTE1', 'PEDIDO FEL', '0000037941', 'FEL', '0000037941'
                    '23/12/2020 15:36:26 pa_upd_um_documento_estado 'DMARTE1', 'PEDIDO FEL', '0000037941', NULL,'A', '', 'FEL 0000037941'

                    'Debo llenar la informacion

                    ''pa_upd_um_documento_estado 'DMARTE1', 'PEDIDO FEL', '0000037941', NULL,'A', gsusuario, 'FEL 0000037941'

                    'pa_sel_var_documento_generado


                End If
            Next
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub ReimprimirRecibos_FEL()



        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Try

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("SCM")
            Dim ppath_reporte As String = clsGen.Path_Reporte



            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                If drv.Item("forma_pago").ToString.ToLower.Contains("conta") Then

                    If drv.Item("serieFACE").ToString.Length = 0 Or drv.Item("numeroFace").ToString.Length = 0 Then
                        verificarDocumentoFEL()
                    End If

                    lsSQL = "flexline.spa_RecibosGuarda '" & gs_empresa & "','" & drv.Item("serieFACE").ToString & "','" & drv.Item("numeroFACE").ToString & "'"
                    clsGen.insertQuery("Flexline", lsSQL)

                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

                    Dim pm_parametros2(2) As String
                    Dim pm_valores2(2) As String


                    pm_parametros2(0) = "Empresa"
                    pm_parametros2(1) = "Tipodocto"
                    pm_parametros2(2) = "Numero"


                    pm_valores2(0) = gs_empresa
                    pm_valores2(1) = drv.Item("serieFACE")
                    pm_valores2(2) = drv.Item("numeroFACE")


                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        False, True, "PDF", True, "", True, Me.nupCopias.Value)

                End If
            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub frm_pedidos_pendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If lpedidos_posfechados Then
            'Me.dtp_fecha_inicio.Text = Today.AddDays(-1)
            'Me.dtp_fecha_final.Text = Today.AddDays(10)
            'Customizar_Forma()
            'Pedidos_PosFechados()
            'Crear_Bindings()
            Me.TabControl1.TabPages.Remove(Me.TabPage2)
            Me.TabControl1.TabPages.Remove(Me.TabPage3)
            Me.TabControl1.TabPages.Remove(Me.TabPage4)
        ElseIf lanular_memos Then
            Me.dtp_fecha_inicio.Text = Today.AddDays(-1)
            Me.dtp_fecha_final.Text = Today.AddDays(10)
            Customizar_Forma()
            Memos_Activos()
            Crear_Bindings()
            Me.TabControl1.TabPages.Remove(Me.TabPage2)
            Me.TabControl1.TabPages.Remove(Me.TabPage3)
            Me.TabControl1.TabPages.Remove(Me.TabPage4)
            Me.btnLiberarConsignacion.Visible = False
            Me.btnValidarStock.Visible = False
            Me.btnVerificar.Visible = False
            Me.btnFacturacionDescuento.Visible = False
            Me.btnFacturarBatch.Visible = False
        Else
            'Me.dtp_fecha_inicio.Text = "01/" & Month(Now()).ToString & "/" & Year(Now())
            Me.dtp_fecha_inicio.Text = Today.AddDays(-4)
            Customizar_Forma()
            Llenar_Combos()
            Pedidos_Pendientes()
            Crear_Bindings()
        End If
        Dim clsGen As New ClasesGenerales.General
        Try
            sDirectorio = clsGen.Obtener_XMLConfig("Directorio_local", False)
        Catch ex As Exception

        End Try

        Try



            If tiene_permisos("mfi_fc_boton_facturar_automatico_tmk") And gi_tipo_usuario <> 1 Then
                Me.btnValidarStock.Text = "Vinoteca"
                Me.btnVerificar.Visible = False
                Me.btnFacturarBatch.Visible = False
                Me.btnFacturacionDescuento.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim tipos_doctos(20) As String
        Dim ldt_table As New DataTable

        Dim otrans As New Transaccional.Conexion("flexline")





        Try
            otrans.open()

            ls_sql = "pa_sel_um_gen_tabcod NULL,'IT_VIGENCIA','DMARTE1'"
            otabla = otrans.Obtiene(ls_sql)

            Me.cmb_estados.DataSource = otabla
            Me.cmb_estados.DisplayMember = "DESCRIPCION"
            Me.cmb_estados.ValueMember = "CODIGO"


            ls_sql = "pa_sel_um_gen_parametros_sistema"
            ldt_table = otrans.Obtiene(ls_sql)
            tipos_doctos = ldt_table.Rows(0).Item("documentos_control_transporte").ToString.Split(",")
            Me.cmbTipoDoctoEnvio.Items.AddRange(tipos_doctos)

            ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
            ldt_table = otrans.Obtiene(ls_sql)
            ldt_table.TableName = "empresa"

            Me.cmbEmpresaEnvio.DisplayMember = "descripcion"
            Me.cmbEmpresaEnvio.ValueMember = "descripcion"
            Me.cmbEmpresaEnvio.DataSource = ldt_table


        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing

        End Try






        Dim dt2 As DataTable


        ods_Listado = New DataSet
        dt2 = New DataTable("listado")
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Existencia", GetType(String)))
        dt2.Columns.Add(New DataColumn("ExistenciaCD", GetType(String)))
        dt2.Columns.Add(New DataColumn("Sugerido", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Sugerido_original", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Comprar", GetType(Boolean)))
        dt2.Columns.Add(New DataColumn("valor", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("grupo", GetType(Integer)))
        ods_Listado.Tables.Add(dt2)

    End Sub

    Private Sub Crear_Bindings()
        Try
            Me.txt_total_pedido.DataBindings.Add("text", oDataSet.Tables("pedidos"), "total")
            Me.txt_comentario.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario1")
            Me.txtComentario2.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario2")
            If Not lpedidos_posfechados Then
                Me.cmb_estados.DataBindings.Add("SelectedValue", oDataSet.Tables("pedidos"), "Aprobacion")
            Else
                Me.dtp_fecha_Entrega.DataBindings.Add("text", oDataSet.Tables("pedidos"), "FechaEntrega")
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Limpiar_Bindings()
        Try
            Me.txt_total_pedido.DataBindings.Clear()
            Me.txt_comentario.DataBindings.Clear()
            Me.txtComentario2.DataBindings.Clear()
            Me.cmb_estados.DataBindings.Clear()
            Me.dtp_fecha_Entrega.DataBindings.Clear()
        Catch ex As Exception
        End Try

    End Sub


    Private Sub BtnliberarConsignacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberarConsignacion.Click

        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index
        If Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.StartsWith("FACTURAR CONSIGNACION") Then

            Dim clsGen As New ClasesGenerales.General
            clsGen.insertQuery("Flexline", "pa_var_um_actualiza_serie_documento '" & Me.dgv_encabezado.Item("empresa", nrow).Value.ToString & "','" & Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString & "','" & Me.dgv_encabezado.Item("numero", nrow).Value.ToString & "'")
            MessageBox.Show("Documento Actualizado", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub


    Private Sub Btn_Estado_Cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estado_Cuenta.Click
        If Me.Btn_Estado_Cuenta.Text = "Anular" Then
            Anular_Memo()
        ElseIf Me.Btn_Estado_Cuenta.Text = "Visualizar" Then
            Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index
            If Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.StartsWith("FACTURAR CONSIGNACION") Then

                Visualizar_Facturacion_Consignaciones()


                Me.Btn_Buscar_Click(sender, e.Empty)
            Else
                MessageBox.Show("Solo se pueden visualizar los documentos FACTURAR CONSIGNACION", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            'Generar Estado de Cta
            'Dim li_row_number As Integer
            'Dim ls_codigo_cliente As String
            'Try
            '    li_row_number = Me.dg_pedidos.CurrentCell.RowNumber
            '    ls_codigo_cliente = Me.dg_pedidos.Item(li_row_number, 7)
            '    ' generar_estado_de_cuenta(ls_codigo_cliente, Me.dg_pedidos.Item(li_row_number, 0))

            'Catch ex As Exception

            'End Try
        End If

    End Sub

    ''Valida para el resto de empresas
    Private Sub validarStockBodega_CEDI1()

        Dim nRow As Integer
        Dim dt, dtStock, dtBodega As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim Oflex As New Umbral_Flex.productos
        Dim sBodega As String
        Dim bCompleto As Boolean = False
        Try
            nRow = Me.dgv_encabezado.CurrentRow.Index


            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" &
                Me.dgv_encabezado.Item("empresa", nRow).Value & "','" &
                                    Me.dgv_encabezado.Item("tipodocto", nRow).Value & "','" &
                                    Me.dgv_encabezado.Item("numero", nRow).Value & "'")




            bCompleto = False
            If dt.Rows.Count > 0 Then
                bCompleto = True
            End If

            If Me.dgv_encabezado.Item("cedi", nRow).Value.ToString.Length > 0 Then
                dtBodega = clsGen.selectQuery("FlexLine", "flexline.pa_sel_um_gen_tabcod '" & Me.dgv_encabezado.Item("cedi", nRow).Value.ToString & "','GEN_LOCALES','" & Me.dgv_encabezado.Item("empresa", nRow).Value & "'")
                If dtBodega.Rows.Count = 1 Then
                    sBodega = dt.Rows(0).Item("descripcion").ToString
                Else
                    MessageBox.Show("Problemas con la Configuracion de CEDI " & Me.dgv_encabezado.Item("cedi", nRow).Value.ToString, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bCompleto = False
                End If
            Else
                sBodega = "CD_CENTRAL"
            End If

            For Each dr As DataRow In dt.Rows
                dtStock = Oflex.Obtener_Existencias(Me.dgv_encabezado.Item("empresa", nRow).Value, dr.Item("producto"), sBodega)
                If dtStock.Rows.Count > 0 Then
                    If dtStock.Rows(0).Item("existencia") = 0 Then
                        'liPedir = dr.Item("cantidad")
                        MessageBox.Show("No Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        bCompleto = False
                    ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                        MessageBox.Show("No Hay Suficiente Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ''Pedir la diferencia
                        'liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                        bCompleto = False
                    End If
                Else
                    MessageBox.Show("No Hay Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bCompleto = False
                    'Pedir completo
                    'liPedir = dr.Item("cantidad")
                End If
            Next
            If bCompleto Then
                If MessageBox.Show("Inventario Suficiente, Desea Facturar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    generarPedidoFACEAutomatico_cedi(Me.dgv_encabezado.Item("empresa", nRow).Value,
                                     Me.dgv_encabezado.Item("tipodocto", nRow).Value,
                                   Me.dgv_encabezado.Item("numero", nRow).Value, sBodega, 0)
                End If
            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing
            Oflex = Nothing

        End Try
    End Sub



    Private Sub validarStockBodega()

        Dim nRow As Integer
        Dim dt, dtStock As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim Oflex As New Umbral_Flex.productos

        Dim bCompleto As Boolean = False

        Dim lsBodega As String



        Try
            nRow = Me.dgv_encabezado.CurrentRow.Index

            If Me.dgv_encabezado.Item("cedi", nRow).Value.ToString.Length = 0 Then
                If Me.dgv_encabezado.Item("empresa", nRow).Value.ToString.ToUpper.Equals("VINOTECA") And Me.dgv_encabezado.Item("listaprecio", nRow).Value.ToString.ToUpper.StartsWith("7)_ON_PREMIUM") Then
                    lsBodega = "CD_PREMIUM"

                Else
                    lsBodega = "CD_CENTRAL"
                End If
                'lsBodega = "CD_CENTRAL"
            Else

                dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & Me.dgv_encabezado.Item("cedi", nRow).Value.ToString & "','GEN_LOCALES','" & Me.dgv_encabezado.Item("empresa", nRow).Value & "'")
                If dt.Rows.Count = 1 Then
                    lsBodega = dt.Rows(0).Item("descripcion").ToString
                Else
                    'Problema con los cedis
                    MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Exit Sub
                End If

            End If



            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" &
                                    Me.dgv_encabezado.Item("empresa", nRow).Value & "','" &
                                    Me.dgv_encabezado.Item("tipodocto", nRow).Value & "','" &
                                    Me.dgv_encabezado.Item("numero", nRow).Value & "'")



            bCompleto = False
            If dt.Rows.Count > 0 Then
                bCompleto = True
            End If

            For Each dr As DataRow In dt.Rows
                'dtStock = Oflex.Obtener_Existencias(Me.dgv_encabezado.Item("empresa", nRow).Value, dr.Item("producto"), "CD_CENTRAL")
                dtStock = Oflex.Obtener_Existencias(Me.dgv_encabezado.Item("empresa", nRow).Value, dr.Item("producto"), lsBodega)
                If dtStock.Rows.Count > 0 Then
                    If dtStock.Rows(0).Item("existencia") = 0 Then
                        'liPedir = dr.Item("cantidad")
                        MessageBox.Show("No Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        bCompleto = False
                    ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                        MessageBox.Show("No Hay Suficiente Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ''Pedir la diferencia
                        'liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                        bCompleto = False
                    End If
                Else
                    MessageBox.Show("No Hay Existencia de " & dr.Item("producto"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bCompleto = False
                    'Pedir completo
                    'liPedir = dr.Item("cantidad")
                End If
            Next
            If bCompleto Then
                If MessageBox.Show("Inventario Suficiente, Desea Facturar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    generarPedidoFACEAutomatico_cedi(Me.dgv_encabezado.Item("empresa", nRow).Value,
                                     Me.dgv_encabezado.Item("tipodocto", nRow).Value,
                                   Me.dgv_encabezado.Item("numero", nRow).Value, lsBodega,
                                   Me.dgv_encabezado.Item("cedi", nRow).Value, 0)
                End If
            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing
            Oflex = Nothing

        End Try
    End Sub

    Private Sub mostrar_detalle_pedido()
        Try
            Dim li_row_number As Integer
            li_row_number = Me.dgv_encabezado.CurrentRow.Index

            Try
                Me.txt_total_pedido.DataBindings.Add("text", oDataSet.Tables("pedidos"), "total")
                Me.txt_comentario.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario1")

                If Not lpedidos_posfechados Then
                    Me.cmb_estados.DataBindings.Add("SelectedValue", oDataSet.Tables("pedidos"), "Aprobacion")
                Else
                    Me.dtp_fecha_Entrega.DataBindings.Add("text", oDataSet.Tables("pedidos"), "FechaEntrega")
                End If

                Me.txtComentario2.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario2")
            Catch ex As Exception
            End Try

            detalle_pedido(li_row_number)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_detalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)

                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then
                    If Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString = 0 Then
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    ElseIf Me.dgv_detalle.Item("cantidad", rowIndex).Value.ToString <> Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString Then
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                    End If
                    If Me.dgv_detalle.Item("adle", rowIndex).Value.ToString.ToLower.Equals("si") Then
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                    End If
                End If


            End If

        Catch ex As Exception
        End Try
        'value = Data("cantidadasignada")
        'value2 = Data("cantidad")

        'If value = 0 Then
        '    e.RowColor = Color.Blue
        'ElseIf value <> value2 Then
        '    e.RowColor = Color.Chocolate
        'End If
    End Sub

    Private Sub dgv_encabezado_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_encabezado.CellMouseMove

    End Sub

    Private Sub dgv_encabezado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_encabezado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_encabezado.Rows(rowIndex)
                If lpedidos_posfechados Then ''Pedidos Posfechados
                    If Me.dgv_encabezado.Item("porcentajeasignado", rowIndex).Value = 0 Then
                        If Me.dgv_encabezado.Item("ControlTemporal", rowIndex).Value.ToString.Length = 10 Then
                            Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                        ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 1 Then
                            Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                        ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 3 Then
                            Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                        End If
                    Else
                        Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                    End If


                    'value = Data("porcentajeasignado").ToString
                    'value2 = Data("dias").ToString
                    ''Try
                    'value4 = 0
                    'value3 = Data("ControlTemporal").ToString
                    'If value3.Trim.Length = 10 Then
                    '    value4 = Int64.Parse(value3)
                    '    '       MessageBox.Show(value3)
                    'End If

                    ''Catch ex As Exception
                    ''value4 = 0
                    ''End Try





                    'If Double.Parse(value.ToString) = 0 Then
                    '    If Int64.Parse(value4.ToString) > 0 Then
                    '        e.RowColor = Color.Green
                    '    ElseIf Int64.Parse(value2) < 1 Then
                    '        e.RowColor = Color.Red
                    '    ElseIf Int64.Parse(value2) < 3 Then
                    '        e.RowColor = Color.Blue
                    '    End If
                    'Else
                    '    e.RowColor = Color.Green
                    'End If
                ElseIf lanular_memos Then


                Else ''Pedidos
                    If Me.dgv_encabezado.Item("porcentajeasignado", rowIndex).Value = 0 Then
                        If Me.dgv_encabezado.Item("aprobacion", rowIndex).Value.ToString.ToLower = "n" Then
                            Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                        Else
                            If Me.dgv_encabezado.Item("comentario2", rowIndex).Value.ToString.Length > 0 Then
                                Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Purple
                            Else
                                Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                            End If
                        End If
                    ElseIf Me.dgv_encabezado.Item("porcentajeasignado", rowIndex).Value < 100 Then
                        Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                    End If

                    therow = Me.dgv_encabezado.Rows(rowIndex)
                    If Me.dgv_encabezado.Item("minutos", rowIndex).Value > 30 And Me.dgv_encabezado.Item("minutos", rowIndex).Value < 61 Then
                        therow.Cells("minutos").Style.BackColor = Color.Yellow
                    ElseIf Me.dgv_encabezado.Item("minutos", rowIndex).Value > 60 Then
                        therow.Cells("minutos").Style.BackColor = Color.LightCoral
                    End If
                    If Me.dgv_encabezado.Item("cedi", rowIndex).Value.ToString.ToLower.Length > 0 Then
                        Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                    End If

                End If


            End If


            ' Data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            '    value = Data("porcentajeasignado").ToString
            '    value2 = Data("dias").ToString


            '    'Try
            '    value4 = 0
            '    value3 = Data("ControlTemporal").ToString
            '    If value3.Trim.Length = 10 Then
            '        value4 = Int64.Parse(value3)
            '        '       MessageBox.Show(value3)
            '    End If

            '    'Catch ex As Exception
            '    'value4 = 0
            '    'End Try





            '    If Double.Parse(value.ToString) = 0 Then
            '        If Int64.Parse(value4.ToString) > 0 Then
            '            e.RowColor = Color.Green
            '        ElseIf Int64.Parse(value2) < 1 Then
            '            e.RowColor = Color.Red
            '        ElseIf Int64.Parse(value2) < 3 Then
            '            e.RowColor = Color.Blue
            '        End If
            '    Else
            '        e.RowColor = Color.Green
            '    End If
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_encabezado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_encabezado.Click
        If Not lpedidos_posfechados Then

            mostrar_detalle_pedido()
        End If
    End Sub

    Private Sub dgv_encabezado_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_encabezado.CurrentCellChanged
        Try

            If Not lpedidos_posfechados Then
                mostrar_detalle_pedido()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgv_encabezado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_encabezado.DoubleClick
        Dim nrow As Integer
        If lpedidos_posfechados Then
            nrow = Me.dgv_encabezado.CurrentRow.Index
            If Me.dgv_encabezado.Item(10, nrow).Value > 0 Then
                Mostrar_Controles_Asociados()
            End If
        End If
    End Sub

#Region "FACE"

    Private Sub crear_estructuraFACE()
        Dim dt As DataTable

        odsFACE = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("forma_Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("PorcDescuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(String)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("exento", GetType(String)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_Pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_PedidoWM", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFEL", GetType(String)))
        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaEnvioFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("FechaRecepcionFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ComentarioFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas
        dt.Columns.Add(New DataColumn("Comuna", GetType(String))) '(c)230315 Campo para informacion walmart 
        dt.Columns.Add(New DataColumn("Estado", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("AnalisisCtaCte2", GetType(String))) '(c) 20191129 Campo para visualizar lasfacturas de AG
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))

        odsFACE.Tables.Add(dt.Copy)

        dt.TableName = "nce"
        odsFACE.Tables.Add(dt.Copy)
        Me.dgv_pedidosFACE.DataSource = odsFACE.Tables("pedidos")
        Me.dgvNC.DataSource = odsFACE.Tables("nce")

    End Sub

    Private Sub procesarInformacionFACE()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim dtDocumentoPrevio As DataTable
        Dim dtmyPedido, dtmydetalle As DataTable
        Dim dr, dr2 As DataRow
        Dim linea As String = String.Empty
        Dim tipo_documento As String = String.Empty
        Dim lsNombreArchivo, lsNombreDirectorio As String

        Dim ClsGen As New ClasesGenerales.General
        Dim lexito As Boolean
        Dim importe_total, importe_bruto, importe_neto As Double
        Dim importe_iva, importe_descuento, impdist As Double

        Dim i As Integer = 0
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim neto As Double
        Dim reemplazar As Boolean = False
        Dim vigencia As String = String.Empty
        Dim exento, dvalorPorcentajeDR1 As Double

        Dim IMPORT_BRUTO As Double = 0.0
        Dim IMPORT_NETO As Double = 0.0
        Dim IMPORT_IVA As Double = 0.0
        Dim IMPORT_TOTAL As Double = 0.0
        Dim nLineas As Integer = 0

        Dim dMontoDescuento As Double = 0

        Try
            Try
                If Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Today.ToString.Replace("/", "")) Or Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Credito\" & Today.ToString.Replace("/", "")) Or
                    Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Debito\" & Today.ToString.Replace("/", "")) Then
                    If MessageBox.Show("Ya existe Informacion generada para el dia " & Me.dtpFechaInicioFACE.Text & ", Desea Volver a Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        reemplazar = True
                    End If
                Else
                    reemplazar = True
                End If
            Catch ex As Exception
            End Try

            Me.txtRuta.Text = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
                             Today.ToString("yyyyMM")

            lsNombreArchivo = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
                             Today.ToString("yyyyMM") & "\" & gs_empresa &
                             Today.ToString("ddMMyyyy").Replace("/", "") & "_"


            Otrans.open()

            If reemplazar Then

                odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
                dt = odsFACE.Tables("pedidos").DefaultView.ToTable.Copy
                dt = ClsGen.ValoresDistinto(dt, "tipoDoctoOrigen".Split(","))
                If dt.Rows.Count > 2 Then
                    MessageBox.Show("No Se Pueden Procesar 2 Tipos de Pedidos", "Informacion", MessageBoxButtons.OK)
                    Exit Try
                Else
                    If dt.Rows(0).Item("TipoDoctoOrigen").ToString.Trim.ToLower.Equals("pedido walmart") Then
                        If odsFACE.Tables("pedidos").DefaultView.Count > 1 Then
                            MessageBox.Show("No Puede Procesar Mas de 1 Pedido de Este Tipo de Documentos", "Verificacion", MessageBoxButtons.OK)
                            Exit Try
                        Else
                            'Nombre del archivo walmart
                            lsNombreArchivo += odsFACE.Tables("pedidos").DefaultView(0).Item("numero").ToString
                        End If
                    Else '' varias lineas 
                        lsNombreArchivo += Now.ToString("HHmm") & "_" & odsFACE.Tables("pedidos").DefaultView.Count
                    End If
                End If
                lsNombreArchivo += ".txt"

                '                odsFACE.Tables("pedidos").DefaultView.RowFilter = "numero  = '" & Me.txtNumero.Text & "'"
                For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                    If drv.Item("enviar") = True And drv.Item("vigencia") = "S" Then

                        tipo_documento = "FACE"
                        If drv.Item("documento").ToString = "Credito" Then
                            tipo_documento = "NCE"
                        End If
                        If drv.Item("serie").ToString.Trim = "" Then
                            If drv.Item("vigencia").ToString = "S" Then 'Or drv.Item("vigencia").ToString = "N" Then


                                ''Generar La informacion para el Impuesto de Distribucion
                                '(c) 20151005

                                Try
                                    ls_sql = "spa_AddImptoDistribDetalle '" & drv.Item("empresa").ToString & "','" & drv.Item("TipoDocto") & "'," & drv.Item("correlativo")
                                    ClsGen.insertQuery("FlexLine", ls_sql)
                                Catch ex As Exception

                                End Try




                                If drv.Item("porcDescuento") > 0 Then
                                    ls_sql = "pa_var_um_documentov '" & gs_empresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

                                    Dim drv2 As DataRowView = dt.DefaultView(0)
                                    'dvalorPorcentajeDR1 = 0
                                    'IMPORT_BRUTO = 0
                                    'IMPORT_NETO = 0
                                    'IMPORT_IVA = 0
                                    'IMPORT_TOTAL = 0

                                    dMontoDescuento = Math.Round(drv2.Item("Monto"), 2) * -1
                                End If


                                linea = "1|" & Date.Parse(Today.ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|"
                                'linea = "1|" & Date.Parse(Me.dtpFechaInicioFACE.Value.ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|"
                                linea += drv.Item("codlegal").ToString & "|1|1|"
                                linea += drv.Item("TipoDoctoOrigen").ToString & "-" & drv.Item("numero").ToString & "|" 'Numero de Referencia
                                linea += "B|1|N|"
                                linea += drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
                                linea += drv.Item("direccion").ToString.Replace("|", " ")
                                If tipo_documento.ToLower = "face" Then


                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        linea += "|Vendor 010085261  " '& Me.txtNumero.Text '& drv.Item("numero").ToString
                                    Else
                                        linea += "|Pedido " & drv.Item("numero").ToString
                                    End If

                                    If drv.Item("codlegal").ToString = "7378106" Then 'Numero de Orden
                                        linea += "|" & Me.txtNumeroOC.Text '& drv.Item("numero_pedidoWM").ToString
                                    Else
                                        linea += "|"
                                    End If
                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        linea += "|" + Me.txtNumeroOCRecepcionWM.Text
                                    Else
                                        linea += "|"
                                    End If
                                    linea += "|Bodega " & drv.Item("Bodega").ToString.Trim & "   Agente: " & drv.Item("vendedor").ToString.Trim
                                    linea += "|" & drv.Item("comentario").ToString.Trim.Replace(Chr(13), " ")
                                End If
                            End If


                            'drv.Item("numero").ToString.Trim & ".txt"

                            If drv.Item("documento").ToString = "Factura" And entro = False Then
                                If Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM")) Then
                                    Try
                                        System.IO.File.Delete(lsNombreArchivo)
                                        entro = True
                                    Catch ex As Exception
                                    End Try
                                Else
                                    System.IO.Directory.CreateDirectory(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM"))
                                    entro = True
                                End If
                            End If

                            'If gs_empresa = "CODICASA" And tipo_documento = "FACE" Then 'campos adicionales para Codicasa y Facturas

                            If tipo_documento = "FACE" Then 'campos adicionales para Codicasa y Facturas
                                Dim lsSQl As String
                                myOtrans.open()

                                lsSQl = "pa_var_um_documento_previo '" & drv.Item("empresa").ToString & "','" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                dtDocumentoPrevio = ClsGen.selectQuery("FlexLine", lsSQl)

                                Try


                                    lsSQl = "call pa_var_um_mov_pedidos_encabezado_numeroflex ('" & drv.Item("empresa").ToString & "','" &
                                            dtDocumentoPrevio.Rows(0).Item("tipodocto") & "','" & dtDocumentoPrevio.Rows(0).Item("numero") & "')"
                                    dtmyPedido = myOtrans.Obtiene(lsSQl)
                                Catch ex As Exception

                                End Try


                                Try

                                    If dtmyPedido.Rows.Count > 0 Then


                                        linea += "|010085261|"
                                        linea += dtmyPedido.Rows(0).Item("gln").ToString & "|"
                                        linea += drv.Item("Comuna").ToString & "|"
                                        linea += drv.Item("Estado").ToString & "|"
                                        linea += drv.Item("Direccion").ToString & "|"
                                        linea += dtmyPedido.Rows(0).Item("numero_pedido") & "|"
                                        linea += IIf(Me.txtNumeroOCRecepcionWM.Text.Length = 0, "03050811", Me.txtNumeroOCRecepcionWM.Text) & "|"
                                        linea += IIf(drv.Item("porcDescuento") > 0, Math.Abs(dMontoDescuento).ToString("N"), "0")


                                        lsSQl = "call pa_sel_um_mov_pedidos_detalle_walmart (" & dtmyPedido.Rows(0).Item("cod_pedido") & ")"
                                        dtmydetalle = myOtrans.Obtiene(lsSQl)
                                    Else

                                        If drv.Item("codlegal").ToString = "7378106" Then 'And tipo_documento = "CFACE" Then
                                            ''Campos adicionales walmart
                                            linea += "|Vendor 010085261  "
                                            linea += "|"
                                            linea += "|"
                                            linea += "|Bodega" '
                                            linea += "|Comentraios "

                                            linea += "|010085261" 'Codigo de CODICASA
                                            linea += "|7407001008593" 'dtmyPedido.Rows(0).Item("gln")
                                            linea += "|Guatemala"
                                            linea += "|Guatemala" 'Comuna
                                            linea += "|" + drv.Item("Direccion").ToString.Trim.PadLeft(80, " ").Substring(0, 79)

                                            linea += "|2803120099"
                                            linea += "|2803120099" 'Cod Recepcion
                                            linea += "|0" 'Descuento
                                        Else
                                            linea += "||"
                                            linea += "|"
                                            linea += "|"
                                            linea += "|"
                                            linea += "|"
                                            linea += "|"
                                            linea += "|"
                                            linea += "0"
                                        End If

                                        'linea += "|010085261|||||||"
                                    End If
                                Catch ex As Exception

                                End Try

                                'archivo.writeLine("<CODPROV>" & drEncabezado.Item("codProv").ToString.Trim & "</CODPROV>")
                                'archivo.writeLine("<GLN>" & drEncabezado.Item("gln").ToString.Trim & "</GLN>")
                                'archivo.writeLine("<CITY>" & drEncabezado.Item("city").ToString.Trim & "</CITY>")
                                'archivo.writeLine("<STATE>" & drEncabezado.Item("state").ToString.Trim & "</STATE>")
                                'archivo.writeLine("<STREETADDRESS>" & drEncabezado.Item("streetAddress").ToString.Trim & "</STREETADDRESS>")
                                'archivo.writeLine("<NOPEDIDO>" & drEncabezado.Item("NoPedido").ToString.Trim & "</NOPEDIDO>")
                                'archivo.writeLine("<CODRECEPCION>" & drEncabezado.Item("CodRecepcion").ToString.Trim & "</CODRECEPCION>")
                                'archivo.writeLine("<DESCUENTO>" & drEncabezado.Item("Descuento").ToString.Trim & "</DESCUENTO>")

                                'drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA
                                'drEncabezado.Item("gln") = dtmyPedido.Rows(0).Item("gln")
                                'drEncabezado.Item("city") = drv.Item("Comuna").ToString
                                'drEncabezado.Item("state") = drv.Item("Estado").ToString
                                'drEncabezado.Item("streetAddress") = drv.Item("Direccion").ToString
                                'drEncabezado.Item("NoPedido") = dtmyPedido.Rows(0).Item("numero_pedido")
                                'drEncabezado.Item("CodRecepcion") = "2803120099"
                                'drEncabezado.Item("Descuento") = 0

                            End If


                            'lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                            odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString &
                                                                        "' and tipodocto  = '" &
                                                                       drv.Item("tipodocto").ToString &
                                                                       "' and empresa = '" & drv.Item("empresa").ToString & "'"


                            If drv.Item("documento").ToString.Trim <> "Debito" Then
                                importe_total = 0
                                importe_bruto = 0
                                importe_neto = 0
                                importe_iva = 0
                                dvalorPorcentajeDR1 = 0
                                importe_descuento = 0
                                If odsFACE.Tables("detalle_pedidos").DefaultView.Count > 0 Then 'Grabo la Linea para determinar que si tenga detalle
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                End If

                                For Each drvD As DataRowView In odsFACE.Tables("detalle_pedidos").DefaultView
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|" & drvD.Item("cantidad") & "|1|"
                                    '4.PRECIO
                                    linea += drvD.Item("Precio") & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

                                        If drvD.Item("PorcentajeDR") <> 0 Then
                                            '5.PORCENTAJE_DESCUENTO 
                                            linea += drvD.Item("PorcentajeDR") * -1 & "|"
                                            dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
                                        Else
                                            '5.PORCENTAJE_DESCUENTO 
                                            dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
                                            linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        End If

                                        '6.IMPORTE_DESCUENTO
                                        linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
                                        '7.IMPORTE_BRUTO
                                        linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"
                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        'SI NO HAY DESCUENTO
                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                        linea += "0|0|"
                                        '7.IMPORTE_BRUTO
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                        linea += IMPORT_BRUTO & "|"
                                        importe_bruto += IMPORT_BRUTO
                                    End If

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                    If drv.Item("exento").ToString.ToLower = "si" Then
                                        exento = IMPORT_BRUTO
                                        '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
                                        linea += exento & "|0|0|0|"
                                        IMPORT_TOTAL = exento
                                        linea += IMPORT_TOTAL & "|"
                                    Else
                                        '8.IMPORTE_EXENTO 
                                        linea += "0|"
                                        '9.IMPORTE_NETO
                                        IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                        linea += IMPORT_NETO & "|"
                                        '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                        IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                        linea += IMPORT_IVA & "|0|"

                                        '12.IMPORTE_TOTAL
                                        IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                        linea += IMPORT_TOTAL & "|"
                                    End If

                                    '13.PRODUCTO       14.DESCRIPCION
                                    linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("documento").ToString = "Factura" Then
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            'linea += "0.00|0.00"
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += "0.00"
                                        Else
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += Math.Round(drvD.Item("Impdist"), 2).ToString
                                        End If
                                        '16.PRECIO_SUGERIDO
                                        linea += "|" & drvD.Item("psugerido").ToString

                                        If drvD.Item("volumen").ToString.Length > 0 Then
                                            '17.VOLUMEN
                                            linea += "|" & drvD.Item("volumen").ToString
                                        Else
                                            '17.VOLUMEN
                                            linea += "|" & 0
                                        End If
                                    End If

                                    impdist = 0

                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)


                                    'If gs_empresa = "CODICASA" And tipo_documento = "FACE" Then 'campos adicionales para informacion de walmart

                                    If tipo_documento = "FACE" Then 'campos adicionales para informacion de walmart
                                        ''(c) 23032014
                                        ''Datos Adicionales Walmart
                                        ''Obtener del pedido en mysql


                                        Try

                                            If dtmydetalle.Rows.Count > 0 Then
                                                dtmydetalle.DefaultView.RowFilter = "cod_producto_flex = '" & drvD.Item("Producto").ToString & "'"
                                                If dtmydetalle.DefaultView.Count > 0 Then
                                                    linea += "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("gtin").ToString + "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("idBuyer").ToString + "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("IdU12").ToString + "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("IdU13").ToString + "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("IdSupplier").ToString + "|"
                                                    linea += dtmydetalle.DefaultView(0).Item("UnitofMesure").ToString
                                                Else
                                                    linea += "|07891200009503|070321956|000000000000|7891200009503|9503|EA"
                                                End If
                                            Else
                                                linea += "|07891200009503|070321956|000000000000|7891200009503|9503|EA"
                                            End If

                                        Catch ex As Exception
                                            'Informacion para walmart
                                            '(c)21052015
                                            If drv.Item("codlegal").ToString = "7378106" Then 'And tipo_documento = "CFACE" Then
                                                linea += "|" & "00014800000344" 'gtin
                                                linea += "|" & "070327006" 'idBuyer
                                                linea += "|" & "" 'IDU12
                                                linea += "|" & "0014800000344" 'IDU13
                                                linea += "|" & "200060191" 'IDSupplier
                                                linea += "|" & "EA" 'UnitOfMesure
                                            Else
                                                linea += "|"
                                                linea += "|"
                                                linea += "|"
                                                linea += "|"
                                                linea += "|"
                                                linea += "|"
                                                'linea += dtmydetalle.DefaultView(0).Item("UnitofMesure").ToString
                                            End If
                                        End Try

                                        'archivo.writeLine("<GTIN>" & drProductos.Item("gtin").ToString.Trim & "</GTIN>")
                                        'archivo.writeLine("<IDBUYER>" & drProductos.Item("idBuyer").ToString.Trim & "</IDBUYER>")
                                        ''archivo.writeLine("<IDU12>" & drProductos.Item("IdU12").ToString.Trim & "</IDU12>")
                                        'archivo.writeLine("<IDU13>" & drProductos.Item("IdU13").ToString.Trim & "</IDU13>")
                                        'archivo.writeLine("<IDSUPPLIER>" & drProductos.Item("IdSupplier").ToString.Trim & "</IDSUPPLIER>")
                                        'archivo.writeLine("<UNITOFMESURE>" & drProductos.Item("UnitOfMesure").ToString.Trim & "</UNITOFMESURE>")
                                    End If
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                Next '' Detalle de Pedidos

                                nLineas = odsFACE.Tables("detalle_pedidos").DefaultView.Count
                                ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
                                ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
                                If drv.Item("porcDescuento") > 0 Then
                                    ls_sql = "pa_var_um_documentov '" & gs_empresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

                                    Dim drv2 As DataRowView = dt.DefaultView(0)
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|1|1|"
                                    '4.PRECIO
                                    linea += dMonto & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    'SI NO HAY DESCUENTO
                                    '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                    linea += "0|0|"
                                    '7.IMPORTE_BRUTO
                                    IMPORT_BRUTO = dMonto
                                    linea += IMPORT_BRUTO & "|"
                                    importe_bruto += IMPORT_BRUTO

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

                                    '8.IMPORTE_EXENTO 
                                    linea += "0|"
                                    '9.IMPORTE_NETO
                                    IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
                                    linea += IMPORT_NETO & "|"
                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                    linea += IMPORT_IVA & "|0|"

                                    '12.IMPORTE_TOTAL
                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                    linea += IMPORT_TOTAL & "|"

                                    '13.PRODUCTO       14.DESCRIPCION
                                    'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        linea += "0000000002|DESCUENTO POR CENTRALIZACION|"
                                    Else
                                        linea += "0000000001|DESCUENTOS GLOBALES|"
                                    End If


                                    'linea += "0.00|0.00"
                                    '15.IMPUESTO_DISTRIBUCION
                                    linea += "0.00"

                                    '16.PRECIO_SUGERIDO
                                    linea += "|0"

                                    '17.VOLUMEN
                                    linea += "|0"


                                    If gs_empresa = "CODICASA" And tipo_documento = "FACE" Then 'campos adicionales para informacion de walmart
                                        '(c) por ser producto adicional lleva informacion dummy
                                        'linea += "||||||"
                                        linea += "|07891200009503|070321956|000000000000|7891200009503|9503|EA"
                                    End If
                                    impdist = 0
                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    nLineas += 1
                                End If ''Descuento Global

                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    If drv.Item("Refnumero").ToString.Trim.Length = 12 Then

                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|FACE|" & drv.Item("RefTipoDocto").ToString & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")

                                        Catch ex As Exception

                                        End Try
                                    Else

                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString &
                                                    "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto4") & "-" & dt.Rows(0).Item("texto1") & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")
                                        Catch ex As Exception
                                        End Try

                                    End If
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)

                                End If


                                If drv.Item("documento").ToString = "Factura" Then

                                    If Math.Abs(importe_total - drv.Item("total")) > 0.1 Then
                                        MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                    Else


                                        linea = ""
                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
                                        linea += Math.Round(importe_descuento, 2) & "|"
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
                                        Else
                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
                                        End If
                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                            nLineas & "|0"
                                        lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    End If
                                End If

                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                    nLineas & "|" & dt.Rows.Count
                                    'Dim lsSQL As String = "pa_ins_um_gen_log_documento_face '" & _
                                    '    drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & _
                                    '    "','" & drv.Item("numero") & "','" & lsLote & "'"

                                    'Otrans.Ingresa(lsSQL)
                                    'If Otrans.Codigo_error = 0 Then
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    '    drv.Item("procesado") = 1
                                    'End If

                                End If
                            End If
                        End If
                    End If
                Next

                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log(ex.ToString)
            ClsGen.Escribir_Log(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub

    Private Sub procesarInformacionNCreditoEletronica()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim dr, dr2 As DataRow
        Dim linea As String = String.Empty
        Dim tipo_documento As String = String.Empty
        Dim lsNombreArchivo, lsNombreDirectorio As String

        Dim ClsGen As New ClasesGenerales.General
        Dim lexito As Boolean
        Dim importe_total, importe_bruto, importe_neto As Double
        Dim importe_iva, importe_descuento, impdist As Double

        Dim i As Integer = 0
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim neto As Double
        Dim reemplazar As Boolean = False
        Dim vigencia As String = String.Empty
        Dim exento, dvalorPorcentajeDR1 As Double

        Dim IMPORT_BRUTO As Double = 0.0
        Dim IMPORT_NETO As Double = 0.0
        Dim IMPORT_IVA As Double = 0.0
        Dim IMPORT_TOTAL As Double = 0.0
        Dim nLineas As Integer = 0

        Try
            Try
                If Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Today.ToString.Replace("/", "")) Or
                    Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Credito\" & Today.ToString.Replace("/", "")) Or
                    Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Debito\" & Today.ToString.Replace("/", "")) Then
                    If MessageBox.Show("Ya existe Informacion generada para el dia " & Me.dtpFechaInicioFACE.Text & ", Desea Volver a Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        reemplazar = True
                    End If
                Else
                    reemplazar = True
                End If
            Catch ex As Exception
            End Try

            Me.txtRuta.Text = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
                             Today.ToString("yyyyMM")

            lsNombreArchivo = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
                             Today.ToString("yyyyMM") & "\" & gs_empresa &
                             Today.ToString("ddMMyyyy").Replace("/", "") & "_"


            Otrans.open()

            If reemplazar Then

                odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
                dt = odsFACE.Tables("pedidos").DefaultView.ToTable.Copy
                dt = ClsGen.ValoresDistinto(dt, "tipoDoctoOrigen".Split(","))
                If dt.Rows.Count > 2 Then
                    MessageBox.Show("No Se Pueden Procesar 2 Tipos de Pedidos", "Informacion", MessageBoxButtons.OK)
                    Exit Try
                Else
                    If dt.Rows(0).Item("TipoDoctoOrigen").ToString.Trim.ToLower.Equals("pedido walmart") Then
                        If odsFACE.Tables("pedidos").DefaultView.Count > 1 Then
                            MessageBox.Show("No Puede Procesar Mas de 1 Pedido de Este Tipo de Documentos", "Verificacion", MessageBoxButtons.OK)
                            Exit Try
                        Else
                            'Nombre del archivo walmart
                            lsNombreArchivo += odsFACE.Tables("pedidos").DefaultView(0).Item("numero").ToString
                        End If
                    Else '' varias lineas 
                        lsNombreArchivo += Now.ToString("HHmm") & "_" & odsFACE.Tables("pedidos").DefaultView.Count
                    End If
                End If
                lsNombreArchivo += ".txt"

                '                odsFACE.Tables("pedidos").DefaultView.RowFilter = "numero  = '" & Me.txtNumero.Text & "'"
                For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                    If drv.Item("enviar") = True And drv.Item("vigencia") = "S" Then

                        tipo_documento = "FACE"
                        If drv.Item("serie").ToString.Trim = "" Then
                            If drv.Item("vigencia").ToString = "S" Then 'Or drv.Item("vigencia").ToString = "N" Then

                                linea = "1|" & Date.Parse(Today.ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|"
                                'linea = "1|" & Date.Parse(Me.dtpFechaInicioFACE.Value.ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|"
                                linea += drv.Item("codlegal").ToString & "|1|1|"
                                linea += drv.Item("TipoDoctoOrigen").ToString & "-" & drv.Item("numero").ToString & "|" 'Numero de Referencia
                                linea += "B|1|N|"
                                linea += drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
                                linea += drv.Item("direccion").ToString.Replace("|", " ")
                                If drv.Item("codlegal").ToString = "7378106" Then
                                    linea += "|Vendor 010085261  " '& Me.txtNumero.Text '& drv.Item("numero").ToString
                                Else
                                    linea += "|Pedido " & drv.Item("numero").ToString
                                End If

                                If drv.Item("codlegal").ToString = "7378106" Then 'Numero de Orden
                                    linea += "|" & Me.txtNumeroOC.Text '& drv.Item("numero_pedidoWM").ToString
                                Else
                                    linea += "|"
                                End If
                                If drv.Item("codlegal").ToString = "7378106" Then
                                    linea += "|" + Me.txtNumeroOCRecepcionWM.Text
                                Else
                                    linea += "|"
                                End If
                                linea += "|Bodega " & drv.Item("Bodega").ToString.Trim & "   Agente: " & drv.Item("vendedor").ToString.Trim
                                linea += "|" & drv.Item("comentario").ToString.Trim.Replace(Chr(13), " ")
                            End If


                            'drv.Item("numero").ToString.Trim & ".txt"

                            If drv.Item("documento").ToString = "Factura" And entro = False Then
                                If Directory.Exists(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM")) Then
                                    Try
                                        System.IO.File.Delete(lsNombreArchivo)
                                        entro = True
                                    Catch ex As Exception
                                    End Try
                                Else
                                    System.IO.Directory.CreateDirectory(sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM"))
                                    entro = True
                                End If
                            End If

                            'lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                            odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString &
                                                                        "' and tipodocto  = '" &
                                                                       drv.Item("tipodocto").ToString &
                                                                       "' and empresa = '" & drv.Item("empresa").ToString & "'"


                            If drv.Item("documento").ToString.Trim <> "Debito" Then
                                importe_total = 0
                                importe_bruto = 0
                                importe_neto = 0
                                importe_iva = 0
                                dvalorPorcentajeDR1 = 0
                                importe_descuento = 0
                                If odsFACE.Tables("detalle_pedidos").DefaultView.Count > 0 Then 'Grabo la Linea para determinar que si tenga detalle
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                End If

                                For Each drvD As DataRowView In odsFACE.Tables("detalle_pedidos").DefaultView
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|" & drvD.Item("cantidad") & "|1|"
                                    '4.PRECIO
                                    linea += drvD.Item("Precio") & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

                                        If drvD.Item("PorcentajeDR") <> 0 Then
                                            '5.PORCENTAJE_DESCUENTO 
                                            linea += drvD.Item("PorcentajeDR") * -1 & "|"
                                            dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
                                        Else
                                            '5.PORCENTAJE_DESCUENTO 
                                            dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
                                            linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        End If

                                        '6.IMPORTE_DESCUENTO
                                        linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
                                        '7.IMPORTE_BRUTO
                                        linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"
                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        'SI NO HAY DESCUENTO
                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                        linea += "0|0|"
                                        '7.IMPORTE_BRUTO
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                        linea += IMPORT_BRUTO & "|"
                                        importe_bruto += IMPORT_BRUTO
                                    End If

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                    If drv.Item("exento").ToString.ToLower = "si" Then
                                        exento = IMPORT_BRUTO
                                        '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
                                        linea += exento & "|0|0|0|"
                                        IMPORT_TOTAL = exento
                                        linea += IMPORT_TOTAL & "|"
                                    Else
                                        '8.IMPORTE_EXENTO 
                                        linea += "0|"
                                        '9.IMPORTE_NETO
                                        IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                        linea += IMPORT_NETO & "|"
                                        '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                        IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                        linea += IMPORT_IVA & "|0|"

                                        '12.IMPORTE_TOTAL
                                        IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                        linea += IMPORT_TOTAL & "|"
                                    End If

                                    '13.PRODUCTO       14.DESCRIPCION
                                    linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("documento").ToString = "Factura" Then
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            'linea += "0.00|0.00"
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += "0.00"
                                        Else
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += Math.Round(drvD.Item("Impdist"), 2).ToString
                                        End If
                                        '16.PRECIO_SUGERIDO
                                        linea += "|" & drvD.Item("psugerido").ToString

                                        If drvD.Item("volumen").ToString.Length > 0 Then
                                            '17.VOLUMEN
                                            linea += "|" & drvD.Item("volumen").ToString
                                        Else
                                            '17.VOLUMEN
                                            linea += "|" & 0
                                        End If
                                    End If

                                    impdist = 0

                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                Next '' Detalle de Pedidos

                                nLineas = odsFACE.Tables("detalle_pedidos").DefaultView.Count
                                ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
                                ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
                                If drv.Item("porcDescuento") > 0 Then
                                    ls_sql = "pa_var_um_documentov '" & gs_empresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

                                    Dim drv2 As DataRowView = dt.DefaultView(0)
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|1|1|"
                                    '4.PRECIO
                                    linea += dMonto & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    'SI NO HAY DESCUENTO
                                    '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                    linea += "0|0|"
                                    '7.IMPORTE_BRUTO
                                    IMPORT_BRUTO = dMonto
                                    linea += IMPORT_BRUTO & "|"
                                    importe_bruto += IMPORT_BRUTO

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

                                    '8.IMPORTE_EXENTO 
                                    linea += "0|"
                                    '9.IMPORTE_NETO
                                    IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
                                    linea += IMPORT_NETO & "|"
                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                    linea += IMPORT_IVA & "|0|"

                                    '12.IMPORTE_TOTAL
                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                    linea += IMPORT_TOTAL & "|"

                                    '13.PRODUCTO       14.DESCRIPCION
                                    'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        linea += "0000000002|DESCUENTO POR CENTRALIZACION|"
                                    Else
                                        linea += "0000000001|DESCUENTOS GLOBALES|"
                                    End If


                                    'linea += "0.00|0.00"
                                    '15.IMPUESTO_DISTRIBUCION
                                    linea += "0.00"

                                    '16.PRECIO_SUGERIDO
                                    linea += "|0"

                                    '17.VOLUMEN
                                    linea += "|0"

                                    impdist = 0
                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    nLineas += 1
                                End If ''Descuento Global

                                If drv.Item("documento").ToString = "Factura" Then

                                    If Math.Abs(importe_total - drv.Item("total")) > 0.1 Then
                                        MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                    Else


                                        linea = ""
                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
                                        linea += Math.Round(importe_descuento, 2) & "|"
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
                                        Else
                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
                                        End If
                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                            nLineas & "|0"
                                        lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub enviosPendientesFACE()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & gs_empresa & "','" & Me.dtpFechaInicioFACE.Text & "','" & Me.dtpFechaFinalFACE.Text & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"


            '
            'ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            'dtPermisos = oTrans.Obtiene(ls_sqltxt)

            'lsFiltro = ""
            'icount = 0
            'For Each dr In dt.Rows
            '    If icount > 0 Then
            '        lsFiltro += " OR "
            '    End If
            '    lsFiltro += "Empresa = '" & dr.Item("empresa").ToString & "'"
            '    icount += 1
            'Next


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            dtPermisos = dt.DefaultView.ToTable.Copy
            'lsFiltro = ""
            '

            For Each dr In oTabla.Rows

                lbProcesar = True
                If Me.chkTodo.CheckState = CheckState.Unchecked Then
                    If dr.Item("vigencia").ToString.ToLower.Equals("a") Then
                        lbProcesar = False
                    End If
                End If

                If lbProcesar Then
                    'lsFiltro = "empresa = '" & gs_empresa & "' and (texto = '" & dr.Item("analisisCtaCte2").ToString & "' Or texto2 = '" & dr.Item("analisisCtaCte2").ToString & "')"

                    lsFiltro = "(Empresa = '" & gs_empresa & "' AND (texto = '" & dr.Item("analisisCtaCte2").ToString & "'))"

                    '    If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
                    '    If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
                    '    ls_filtro += "))"
                    dtPermisos.DefaultView.RowFilter = lsFiltro
                    If dtPermisos.DefaultView.Count > 0 Then
                        lbProcesar = True
                    Else
                        lbProcesar = False
                    End If

                End If

                If Not lbProcesar Then
                    If tiene_permisos("administrador") Then
                        lbProcesar = True
                    End If
                End If
                If lbProcesar Then

                    dr_aux = odsFACE.Tables("pedidos").NewRow

                    dr_aux.Item("Enviar") = 0
                    dr_aux.Item("serie") = dr.Item("serie")
                    dr_aux.Item("documento") = dr.Item("documento")
                    dr_aux.Item("empresa") = dr.Item("empresa")
                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                    dr_aux.Item("correlativo") = dr.Item("correlativo")
                    dr_aux.Item("numero") = dr.Item("numero")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("codlegal") = dr.Item("codlegal")
                    dr_aux.Item("ctacte") = dr.Item("ctacte")
                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                    dr_aux.Item("direccion") = dr.Item("direccion")
                    dr_aux.Item("telefono") = dr.Item("telefono")
                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
                    dr_aux.Item("vigencia") = dr.Item("vigencia")
                    dr_aux.Item("exento") = dr.Item("exento")
                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
                    dr_aux.Item("comentario") = dr.Item("comentario")
                    dr_aux.Item("Bodega") = dr.Item("bodega")
                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
                    dr_aux.Item("total") = dr.Item("total")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
                        End If
                    Catch ex As Exception

                    End Try




                    Try

                        dr_aux.Item("FechaEnvioFACE") = dr.Item("FechaEnvio")
                        dr_aux.Item("FechaRecepcionFACE") = dr.Item("FechaRecepcion")
                        dr_aux.Item("ComentarioFACE") = dr.Item("ComentarioFACE")
                    Catch ex As Exception

                    End Try




                    Try

                        dr_aux.Item("ImpresoraFace") = dr.Item("Impresora")
                        dr_aux.Item("BodegaInterEmpresas") = dr.Item("bodegaFacturar")
                        dr_aux.Item("comuna") = dr.Item("comuna")
                        dr_aux.Item("estado") = dr.Item("estado")
                        'dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
                        'dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas

                    Catch ex As Exception

                    End Try

                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)

                End If


            Next
            Me.txt_facturas.Text = odsFACE.Tables("pedidos").Rows.Count

            clGen.Alinear_GridView(odsFACE.Tables("pedidos"), dgv_pedidosFACE, ",forma_pago,bodega,exento,vigencia,direccion,tipo_docto,enviar,numero,fecha,codlegal,nombre_cliente,PorcDescuento,numeroFACE,fechaenvioFACE,comentarioFACE,fecharecepcionFACE,BodegaInterEmpresas,",
             ",firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,", "", "", ",PorcDescuento=30,vigencia=15,exento=15,", "", True, True, 150, 0)

            ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & Me.dtpFechaInicioFACE.Text & "','" & Me.dtpFechaFinalFACE.Text & "','" & gs_empresa & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            detalle_pedidoFACE(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub enviosPendientesFEL()

        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        odsFACE.Tables("pedidos").Rows.Clear()

        ls_sqltxt = "pa_sel_um_tipodocumento_FELPura_empresa '" & gs_empresa & "','" & Me.dtp_fel_inicio.Text & "','" & Me.dtp_fel_final.Text & "',0"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"


            '
            'ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            'dtPermisos = oTrans.Obtiene(ls_sqltxt)

            'lsFiltro = ""
            'icount = 0
            'For Each dr In dt.Rows
            '    If icount > 0 Then
            '        lsFiltro += " OR "
            '    End If
            '    lsFiltro += "Empresa = '" & dr.Item("empresa").ToString & "'"
            '    icount += 1
            'Next


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            dtPermisos = dt.DefaultView.ToTable.Copy
            'lsFiltro = ""
            '

            For Each dr In oTabla.Rows

                lbProcesar = True
                If Me.chkGenerarTodo_Fel.CheckState = CheckState.Unchecked Then
                    If dr.Item("vigencia").ToString.ToLower.Equals("a") Then
                        lbProcesar = False
                    End If
                End If

                If lbProcesar Then
                    lsFiltro = "empresa = '" & gs_empresa & "' and (texto = '" & dr.Item("analisisCtaCte2").ToString & "' Or texto1 = '" & dr.Item("analisisCtaCte2").ToString & "')"

                    'lsFiltro = "(Empresa = '" & gs_empresa & "' AND (texto = '" & dr.Item("analisisCtaCte2").ToString & "' "
                    'lsFiltro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"

                    'If drv.Item("TEXTO1").ToString.Length > 0 Then lsFiltro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
                    '    If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
                    'lsFiltro += "))"
                    dtPermisos.DefaultView.RowFilter = lsFiltro
                    If dtPermisos.DefaultView.Count > 0 Then
                        lbProcesar = True
                    Else
                        lbProcesar = False
                    End If

                End If

                If Not lbProcesar Then
                    If tiene_permisos("administrador") Then
                        lbProcesar = True
                    End If
                End If
                If lbProcesar Then

                    dr_aux = odsFACE.Tables("pedidos").NewRow

                    dr_aux.Item("Enviar") = 0
                    dr_aux.Item("serie") = dr.Item("serie")
                    dr_aux.Item("documento") = dr.Item("documento")
                    dr_aux.Item("empresa") = dr.Item("empresa")
                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                    dr_aux.Item("correlativo") = dr.Item("correlativo")
                    dr_aux.Item("numero") = dr.Item("numero")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("codlegal") = dr.Item("codlegal")
                    dr_aux.Item("ctacte") = dr.Item("ctacte")
                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                    dr_aux.Item("direccion") = dr.Item("direccion")
                    dr_aux.Item("telefono") = dr.Item("telefono")
                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
                    dr_aux.Item("vigencia") = dr.Item("vigencia")
                    dr_aux.Item("exento") = dr.Item("exento")
                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
                    dr_aux.Item("comentario") = dr.Item("comentario")
                    dr_aux.Item("Bodega") = dr.Item("bodega")
                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
                    dr_aux.Item("total") = dr.Item("total")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then


                            If dr.Item("FACE").ToString.Split(" ").Length = 2 Then
                                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
                            ElseIf dr.Item("FACE").ToString.Split(" ").Length = 3 Then
                                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0) + " " +
                                dr.Item("FACE").ToString.Split(" ")(1)


                                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(2)
                            ElseIf dr.Item("FACE").ToString.Split(" ").Length = 4 Then
                                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0) + " " +
                                dr.Item("FACE").ToString.Split(" ")(1) + " " +
                                dr.Item("FACE").ToString.Split(" ")(2)


                                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(3)

                            End If


                        End If
                    Catch ex As Exception

                    End Try




                    Try

                        dr_aux.Item("FechaEnvioFACE") = dr.Item("FechaEnvio")
                        dr_aux.Item("FechaRecepcionFACE") = dr.Item("FechaRecepcion")
                        dr_aux.Item("ComentarioFACE") = dr.Item("ComentarioFACE")
                    Catch ex As Exception

                    End Try




                    Try

                        dr_aux.Item("ImpresoraFace") = dr.Item("Impresora")
                        dr_aux.Item("BodegaInterEmpresas") = dr.Item("bodegaFacturar")
                        dr_aux.Item("comuna") = dr.Item("comuna")
                        dr_aux.Item("estado") = dr.Item("estado")
                        'dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
                        'dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas

                    Catch ex As Exception

                    End Try

                    Try
                        dr_aux.Item("numeroFEL") = dr.Item("numeroFEL")
                    Catch ex As Exception

                    End Try


                    Try
                        dr_aux.Item("AnalisisCtaCte2") = dr.Item("AnalisisCtaCte2").ToString
                        'dt.Columns.Add(New DataColumn("AnalisisCtaCte2", GetType(String))) '(c)230315 Campo para informacion walmart
                    Catch ex As Exception

                    End Try

                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)

                End If


            Next
            Me.txtDocumentosFel.Text = odsFACE.Tables("pedidos").Rows.Count


            Me.dgv_encabezado_fel.DataSource = odsFACE.Tables("pedidos")

            clGen.Alinear_GridView(odsFACE.Tables("pedidos"), dgv_encabezado_fel,
                                   ",forma_pago,bodega,exento,vigencia,direccion,tipo_docto,enviar,numero,fecha,codlegal,nombre_cliente,PorcDescuento,serieFACE,numeroFACE,fechaenvioFACE,comentarioFACE,fecharecepcionFACE,BodegaInterEmpresas,numeroFEL,analisisctacte2,comentario,",
                                    ",firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,",
                                    "", ",comentario=comentario_Pedido,", ",PorcDescuento=30,vigencia=15,exento=15,", "", True, True, 150, 0)

            ls_sqltxt = "pa_var_um_detalle_felPURA '" & Me.dtp_fel_inicio.Text & "','" & Me.dtp_fel_final.Text & "','" & gs_empresa & "',0"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)
            Me.dgv_detalle_fel.DataSource = odsFACE.Tables("detalle_pedidos")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            detalle_pedidoFEL(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub enviosPendientesNCE()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaNCPURA '" & gs_empresa & "','" & Me.dtpFechaInicioNC.Text & "','" & Me.dtpFechaFinNC.Text & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            'oTabla.DefaultView.RowFilter = "documento like 'factura'"


            '
            'ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            'dtPermisos = oTrans.Obtiene(ls_sqltxt)

            'lsFiltro = ""
            'icount = 0
            'For Each dr In dt.Rows
            '    If icount > 0 Then
            '        lsFiltro += " OR "
            '    End If
            '    lsFiltro += "Empresa = '" & dr.Item("empresa").ToString & "'"
            '    icount += 1
            'Next


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            dtPermisos = dt.DefaultView.ToTable.Copy
            'lsFiltro = ""
            '

            For Each dr In oTabla.Rows

                lbProcesar = True
                If Me.chkTodo.CheckState = CheckState.Unchecked Then
                    If dr.Item("vigencia").ToString.ToLower.Equals("a") Then
                        lbProcesar = False
                    End If
                End If

                If lbProcesar Then
                    'lsFiltro = "empresa = '" & gs_empresa & "' and (texto = '" & dr.Item("analisisCtaCte2").ToString & "' Or texto2 = '" & dr.Item("analisisCtaCte2").ToString & "')"

                    lsFiltro = "(Empresa = '" & gs_empresa & "' AND (texto = '" & dr.Item("analisisCtaCte2").ToString & "'))"

                    '    If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
                    '    If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
                    '    ls_filtro += "))"
                    dtPermisos.DefaultView.RowFilter = lsFiltro
                    If dtPermisos.DefaultView.Count > 0 Then
                        lbProcesar = True
                    Else
                        lbProcesar = False
                    End If

                End If

                If Not lbProcesar Then
                    If tiene_permisos("administrador") Then
                        lbProcesar = True
                    End If
                End If
                If lbProcesar Then

                    dr_aux = odsFACE.Tables("nce").NewRow

                    dr_aux.Item("Enviar") = 0
                    dr_aux.Item("serie") = dr.Item("serie")
                    dr_aux.Item("documento") = dr.Item("documento")
                    dr_aux.Item("empresa") = dr.Item("empresa")
                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                    dr_aux.Item("correlativo") = dr.Item("correlativo")
                    dr_aux.Item("numero") = dr.Item("numero")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("codlegal") = dr.Item("codlegal")
                    dr_aux.Item("ctacte") = dr.Item("ctacte")
                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                    dr_aux.Item("direccion") = dr.Item("direccion")
                    dr_aux.Item("telefono") = dr.Item("telefono")
                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
                    dr_aux.Item("vigencia") = dr.Item("vigencia")
                    dr_aux.Item("exento") = dr.Item("exento")
                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
                    dr_aux.Item("comentario") = dr.Item("comentario")
                    dr_aux.Item("Bodega") = dr.Item("bodega")
                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
                    dr_aux.Item("total") = dr.Item("total")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        dr_aux.Item("FechaEnvioFACE") = dr.Item("FechaEnvio")
                        dr_aux.Item("FechaRecepcionFACE") = dr.Item("FechaRecepcion")
                        dr_aux.Item("ComentarioFACE") = dr.Item("ComentarioFACE")
                    Catch ex As Exception

                    End Try
                    odsFACE.Tables("nce").Rows.Add(dr_aux)
                End If


            Next
            Me.txt_facturas.Text = odsFACE.Tables("nce").Rows.Count

            clGen.Alinear_GridView(odsFACE.Tables("nce"), dgvNC, ",forma_pago,bodega,exento,vigencia,direccion,tipo_docto,enviar,numero,fecha,codlegal,nombre_cliente,PorcDescuento,numeroFACE,fechaenvioFACE,comentarioFACE,fecharecepcionFACE,",
             ",firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,", "", "", ",PorcDescuento=30,vigencia=15,exento=15,", "", True, True, 150, 0)

            ls_sqltxt = "pa_var_um_detalle_guatefacturaNCE '" & Me.dtpFechaInicioNC.Text & "','" & Me.dtpFechaFinNC.Text & "','" & gs_empresa & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_notas"

            odsFACE.Tables.Add(oTabla.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            detalle_pedidoFACE(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub detalle_pedidoFACE(ByVal pi_RowNumber As Integer)

        'Dim ls_resultado As String
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_pedidosFACE.Item("numero", pi_RowNumber).Value &
                                                             "' and tipodocto  = '" &
                                                            dgv_pedidosFACE.Item("tipodocto", pi_RowNumber).Value &
                                                            "' and empresa = '" & dgv_pedidosFACE.Item("empresa", pi_RowNumber).Value & "'"

        Me.dgvDetalleFACE.DataSource = odsFACE.Tables("detalle_pedidos")
        Me.dgv_pedidosFACE.Refresh()

        clgen.Alinear_GridView(odsFACE.Tables("detalle_pedidos"), dgvDetalleFACE, "", "", "", "", "", "", "", True, True, 200, 0)



        clgen = Nothing

    End Sub


    Private Sub detalle_pedidoFEL(ByVal pi_RowNumber As Integer)

        'Dim ls_resultado As String
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_encabezado_fel.Item("numero", pi_RowNumber).Value &
                                                             "' and tipodocto  = '" &
                                                            dgv_encabezado_fel.Item("tipodocto", pi_RowNumber).Value &
                                                            "' and empresa = '" & dgv_encabezado_fel.Item("empresa", pi_RowNumber).Value & "'"

        Me.dgv_detalle_fel.DataSource = odsFACE.Tables("detalle_pedidos")
        Me.dgv_detalle_fel.Refresh()


        clgen.Alinear_GridView(odsFACE.Tables("detalle_pedidos"), dgv_detalle_fel, "", "", "", "", "", "", "", True, True, 200, 0)



        clgen = Nothing

    End Sub


    Private Function valores_orden_edifact_correctos_mysql(psempresa As String, psTipoDocto As String, psNumeroDocto As String, ByRef pdDiferencia As Double)
        Dim lbValoresCorrectos As Boolean = False

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtDetalle, dtOrdenes As DataTable
        Dim lsSQL As String
        pdDiferencia = 0

        Try
            myOtrans.open()
            lsSQL = "pa_var_um_pedidos_walmart_detalle_pedido '" & psempresa & "','" & psTipoDocto & "','" & psNumeroDocto & "'"
            dtDetalle = ClsGen.selectQuery("FlexLine", lsSQL)
            dtOrdenes = ClsGen.ValoresDistinto(dtDetalle, "pedido,numero_pedido".Split(","))

            For Each drEncabezado As DataRow In dtOrdenes.Rows
                lsSQL = "call pa_var_um_edi_pedido_precios ('" & psempresa & "','" &
                            drEncabezado.Item("pedido").ToString & "','" &
                            drEncabezado.Item("numero_pedido").ToString & "')"

                dt = myOtrans.Obtiene(lsSQL)

                dtDetalle.DefaultView.RowFilter = "pedido = '" & drEncabezado.Item("pedido") & "' and numero_pedido = '" & drEncabezado.Item("numero_pedido") & "'"

                For Each drv As DataRowView In dtDetalle.DefaultView
                    dt.DefaultView.RowFilter = "codigoFlex = '" & drv.Item("producto").ToString & "'"
                    If dt.DefaultView.Count > 0 Then
                        drv.Item("precioEdi") = Math.Round(dt.DefaultView(0).Item("costonegociado"), 2, MidpointRounding.AwayFromZero)
                        drv.Item("precioEdi_iva") = Math.Round(drv.Item("precioEdi") * 1.12, 2, MidpointRounding.AwayFromZero)
                        drv.Item("PrecioAjustado") = Math.Round(drv.Item("PrecioAjustado"), 2, MidpointRounding.AwayFromZero)
                    End If
                Next

            Next

            dtDetalle.DefaultView.RowFilter = ""

            For Each dr As DataRow In dtDetalle.Rows
                dr.Item("diferencia") = Math.Abs(dr.Item("precioAjustado") - dr.Item("precioEdi"))
                'dr.Item("diferencia") = Math.Abs(dr.Item("precio") - dr.Item("precioEdi_iva"))
                pdDiferencia = pdDiferencia + (dr.Item("diferencia") * dr.Item("cantidad"))

            Next
            lbValoresCorrectos = True

            If Math.Abs(pdDiferencia) > Double.Parse(ClsGen.Obtener_XMLConfig("diferencia_maxima_WM", False).ToString) Then
                lbValoresCorrectos = False
            End If

        Catch ex As Exception
            lbValoresCorrectos = False

        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return lbValoresCorrectos
    End Function



    Private Function valores_orden_edifact_correctos(psempresa As String, psTipoDocto As String, psNumeroDocto As String, ByRef pdDiferencia As Double)
        Dim lbValoresCorrectos As Boolean = False

        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtDetalle, dtOrdenes As DataTable
        Dim lsSQL As String
        pdDiferencia = 0

        Try
            cOtrans.open()
            lsSQL = "pa_var_um_pedidos_walmart_detalle_pedido '" & psempresa & "','" & psTipoDocto & "','" & psNumeroDocto & "'"
            dtDetalle = ClsGen.selectQuery("FlexLine", lsSQL)
            dtOrdenes = ClsGen.ValoresDistinto(dtDetalle, "pedido,numero_pedido".Split(","))

            For Each drEncabezado As DataRow In dtOrdenes.Rows
                lsSQL = "pa_var_um_edi_pedido_precios '" & psempresa & "','" &
                            drEncabezado.Item("pedido").ToString & "','" &
                            drEncabezado.Item("numero_pedido").ToString & "'"

                dt = cOtrans.Obtiene(lsSQL)

                dtDetalle.DefaultView.RowFilter = "pedido = '" & drEncabezado.Item("pedido") & "' and numero_pedido = '" & drEncabezado.Item("numero_pedido") & "'"

                For Each drv As DataRowView In dtDetalle.DefaultView
                    dt.DefaultView.RowFilter = "codigoFlex = '" & drv.Item("producto").ToString & "'"
                    If dt.DefaultView.Count > 0 Then
                        drv.Item("precioEdi") = Math.Round(dt.DefaultView(0).Item("costonegociado"), 2, MidpointRounding.AwayFromZero)
                        drv.Item("precioEdi_iva") = Math.Round(drv.Item("precioEdi") * 1.12, 2, MidpointRounding.AwayFromZero)
                        drv.Item("PrecioAjustado") = Math.Round(drv.Item("PrecioAjustado"), 2, MidpointRounding.AwayFromZero)
                    End If
                Next

            Next

            dtDetalle.DefaultView.RowFilter = ""

            For Each dr As DataRow In dtDetalle.Rows
                dr.Item("diferencia") = Math.Abs(dr.Item("precioAjustado") - dr.Item("precioEdi"))
                'dr.Item("diferencia") = Math.Abs(dr.Item("precio") - dr.Item("precioEdi_iva"))
                pdDiferencia = pdDiferencia + (dr.Item("diferencia") * dr.Item("cantidad"))

            Next
            lbValoresCorrectos = True

            If Math.Abs(pdDiferencia) > Double.Parse(ClsGen.Obtener_XMLConfig("diferencia_maxima_WM", False).ToString) Then
                lbValoresCorrectos = False
            End If

        Catch ex As Exception
            lbValoresCorrectos = False

        Finally
            cOtrans.close()
            cOtrans = Nothing
        End Try
        Return lbValoresCorrectos
    End Function


    Private Sub actualizarInformacionWALMART()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim lsSQL, lsCodProv As String
        Dim dtmyPedido, dtmyEdiEncabezado, dtdocumentoPrevio As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim dDiferencia As Double = 0

        lsCodProv = String.Empty

        Try
            Otrans.open()
            '   myOtrans.open()
            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            If odsFACE.Tables("pedidos").DefaultView.Count = 1 Then

                Dim drv As DataRowView = odsFACE.Tables("pedidos").DefaultView(0)

                '(c) 20151019 Busco Numero Vendor en el pedido Edi

                If Me.valores_orden_edifact_correctos(drv.Item("empresa"), drv.Item("tipodocto"), drv.Item("numero"), dDiferencia) Then
                    'If Me.valores_orden_edifact_correctos_mysql(drv.Item("empresa"), drv.Item("tipodocto"), drv.Item("numero"), dDiferencia) Then


                    lsSQL = "pa_var_um_documento_previo '" & drv.Item("empresa").ToString & "','" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "'"
                    dtdocumentoPrevio = ClsGen.selectQuery("FlexLine", lsSQL)


                    If drv.Item("tipodocto") = "PEDIDO FACE RE" Or drv.Item("tipodocto") = "PEDIDO CONSOLIDADO" Then
                        Dim iCount As Integer = 0
                        While True
                            Try

                                lsSQL = "pa_var_um_documento_previo '" & drv.Item("empresa").ToString & "','" &
                                    dtdocumentoPrevio.Rows(0).Item("tipodocto") & "','" & dtdocumentoPrevio.Rows(0).Item("numero") & "'"
                                dtdocumentoPrevio = ClsGen.selectQuery("FlexLine", lsSQL)
                                If iCount > 5 Or dtdocumentoPrevio.Rows(0).Item("tipodocto").ToString.ToLower.StartsWith("pedido al") Then
                                    Exit While
                                End If
                                iCount = +1
                            Catch ex As Exception
                                Exit While
                            End Try

                        End While
                    End If

                    '(c) 20221117 La información ya no es necesaria, ultiuma vez que se lleno en 2019

                    'lsSQL = "call pa_var_um_mov_pedidos_encabezado_numeroflex ('" & drv.Item("empresa").ToString & "','" &
                    '                                   dtdocumentoPrevio.Rows(0).Item("tipodocto") & "','" & dtdocumentoPrevio.Rows(0).Item("numero") & "')"
                    'dtmyPedido = myOtrans.Obtiene(lsSQL)



                    'If dtmyPedido.Rows.Count > 0 Then
                    '    If dtmyPedido.Rows(0).Item("gln").ToString.Trim.Length > 0 Then

                    '        ''Debo Ir a traer el encabezado para el CodProv

                    '        lsSQL = "call pa_var_um_edi_pedido_encabezado ('" & drv.Item("empresa").ToString & "','" & dtmyPedido.Rows(0).Item("numero_pedido").ToString & "','" &
                    '                dtmyPedido.Rows(0).Item("gln").ToString & "')"
                    '        dtmyEdiEncabezado = myOtrans.Obtiene(lsSQL)

                    '        lsCodProv = dtmyEdiEncabezado.Rows(0).Item("idempresalocalproveedor").ToString.PadLeft(9, "0")
                    '    End If

                    'End If
                    lsSQL = "pa_upd_um_documento_variables_walmart '" & drv.Item("empresa") & "','" &
                    drv.Item("tipodocto") & "','" &
                    drv.Item("numero") & "','" & Me.txtNumeroOC.Text & "','" &
                    Me.txtNumeroOCRecepcionWM.Text & "','" &
                    lsCodProv & "'"
                    Otrans.Actualiza(lsSQL)

                    lsSQL = "pa_ins_um_convierte_pedido_walmart_fel '" & drv.Item("empresa").ToString & "','" &
                            drv.Item("tipodocto").ToString & "','" &
                            drv.Item("numero").ToString & "'"

                    Otrans.Ingresa(lsSQL)


                Else

                    MessageBox.Show("El Documento No Se Puede Procesar por Diferencia en Precios " & dDiferencia, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            'myOtrans.close()
            'myOtrans = Nothing
        End Try
    End Sub

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        If Me.dtpFechaInicioFACE.Value > Today.AddDays(1) Then
            MessageBox.Show("No Puede Procesar Informacion con Fecha Posterior a Hoy", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Me.txtNumeroOCRecepcionWM.Text.Length > 0 Then
                If MessageBox.Show("Esta Seguro de La Informacion Para WM", "Confirmacion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


                    actualizarInformacionWALMART()


                End If
            End If
            '(c) 20221117 Ya no es necesario porque ahora son FEL
            'procesarInformacionFACE()
        End If
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        crear_estructuraFACE()
        enviosPendientesFACE()
    End Sub

    Private Sub dgv_pedidosFACE_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_pedidosFACE.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_pedidosFACE.Rows(rowIndex)

                'If Me.dgv_pedidosFACE.Item("codlegal", rowIndex).Value = "7378106" And Me.dgv_pedidosFACE.Item("direccion", rowIndex).Value.ToString.ToUpper.Equals("CENTRO DE DISTRIBUCION AMATITLAN") Then
                If Me.dgv_pedidosFACE.Item("tipodocto", rowIndex).Value = "PEDIDO WALMART" Then

                    Me.dgv_pedidosFACE.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If


            End If





            ' Data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            '    value = Data("porcentajeasignado").ToString
            '    value2 = Data("dias").ToString


            '    'Try
            '    value4 = 0
            '    value3 = Data("ControlTemporal").ToString
            '    If value3.Trim.Length = 10 Then
            '        value4 = Int64.Parse(value3)
            '        '       MessageBox.Show(value3)
            '    End If

            '    'Catch ex As Exception
            '    'value4 = 0
            '    'End Try





            '    If Double.Parse(value.ToString) = 0 Then
            '        If Int64.Parse(value4.ToString) > 0 Then
            '            e.RowColor = Color.Green
            '        ElseIf Int64.Parse(value2) < 1 Then
            '            e.RowColor = Color.Red
            '        ElseIf Int64.Parse(value2) < 3 Then
            '            e.RowColor = Color.Blue
            '        End If
            '    Else
            '        e.RowColor = Color.Green
            '    End If
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_pedidos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pedidosFACE.CurrentCellChanged
        Try
            detalle_pedidoFACE(Me.dgv_pedidosFACE.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFace.Click
        If MessageBox.Show("Esta Seguro de Generar FACE", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            extraerzipFACE()
            If Me.txtRuta.Text.Length > 0 Then
                generarFACE()
            End If
            moverArchivosFACE()
        End If
    End Sub

    Private Sub extraerzipFACE()

        Dim ClsGen As New ClasesGenerales.General
        Dim lsRuta As String
        Dim lsArchivos() As String

        Try
            Me.txtRuta.Text = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
                 Today.ToString("yyyyMM")

            lsArchivos = Directory.GetFiles(Me.txtRuta.Text, "*.zip")
            If lsArchivos.Length > 1 Then
                MessageBox.Show("No Puede Haber Mas de un Archivo ZIP en " & Chr(13) & Me.txtRuta.Text, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf lsArchivos.Length = 1 Then

                ClsGen.Descomprimir_Archivo(lsArchivos(0), Me.txtRuta.Text)
                Dim di As New DirectoryInfo(Me.txtRuta.Text & "\app")
                Dim fics() As FileInfo
                fics = di.GetFiles("*.txt", SearchOption.AllDirectories)
                'MessageBox.Show(fics(0).FullName)
                If fics.Length = 1 Then
                    Me.txtRuta.Text = fics(0).FullName
                Else
                    MessageBox.Show("Problemas Para Generar FACE")
                    Me.txtRuta.Text = String.Empty
                End If
            Else
                MessageBox.Show("No Se Encontro Archivo ZIP", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try


    End Sub




    Private Sub generarFACE()


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        'Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt("CODICASA")
        Dim lsDirectorio As String = sDirectorio & ":\temp\" & gs_empresa & "\" & Me.dtp_fecha_inicio.Value.ToString("yyyyMM") & "\" & Me.dtp_fecha_inicio.Value.ToString("ddMMyyyy")
        Dim nCopias As Integer = 0
        Dim dtImpresoras As DataTable


        Try

            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            If odsFACE.Tables("pedidos").DefaultView.Count > 0 Then
                If Not Directory.Exists(lsDirectorio) Then
                    System.IO.Directory.CreateDirectory(lsDirectorio)
                End If
            End If
        Catch ex As Exception

        End Try

        Try


            Otrans.open()

            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            If odsFACE.Tables("pedidos").DefaultView.Count > 0 Then

                Dim sArchivo As String = Me.txtRuta.Text

                Dim sLineas, sDetalle, Sdocumento As String()

                Dim sTexto As String

                Dim sr As New System.IO.StreamReader(sArchivo)
                Me.TextBox1.Text = sr.ReadToEnd()
                sr.Close()



                sLineas = Me.TextBox1.Text.Split(Chr(10))
                ' MessageBox.Show(TextBox1.Text)
                MessageBox.Show("Por Favor Seleccione La Impresora", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                For Each sLinea As String In sLineas
                    If sLinea.Length > 0 Then
                        sDetalle = sLinea.Split("|")
                        Sdocumento = sDetalle(8).Split("-")
                        For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                            If drv.Item("tipoDoctoOrigen") = Sdocumento(0) And drv.Item("numero") = Sdocumento(1) Then
                                If Math.Abs(drv.Item("total") - sDetalle(5)) > 0.1 Then
                                    MessageBox.Show("Problemas con El Documento Numero" & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                Else
                                    drv.Item("fechaFACE") = sDetalle(1).Substring(6, 2) & "/" & sDetalle(1).Substring(4, 2) & "/" & sDetalle(1).Substring(0, 4) 'añomesdia
                                    drv.Item("serieFACE") = sDetalle(2)
                                    drv.Item("numeroFACE") = sDetalle(3)
                                    drv.Item("firmaFACE") = sDetalle(7)
                                    drv.Item("nitFACE") = sDetalle(4)
                                    drv.Item("nombreFACE") = sDetalle(9)
                                    drv.Item("direccionFACE") = sDetalle(10)
                                End If
                            End If
                        Next
                    End If
                    '     MessageBox.Show(sLinea)
                Next
                Me.TextBox1.Text = String.Empty

            End If

            ' Exit Sub


            'odsFACE.Tables("pedidos").DefaultView.RowFilter = "numero  = '" & Me.txtNumero.Text & "'"
            odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            odsFACE.Tables("pedidos").DefaultView.Sort = "numeroFACE"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                If drv.Item("enviar") = True And drv.Item("numeroFACE").ToString.Trim.Length > 0 Then
                    ''Creamos los documentos FACE
                    lsSQL = "pa_ins_um_documento_FACE '" & gs_empresa & "','" &
                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" &
                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" &
                            drv.Item("firmaFACE").ToString.PadRight(100, " ") & "','" & gs_usuario & "','" &
                            Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"


                    If Otrans.Ingresa(lsSQL) > 0 Then
                        lsSQL = "pa_ins_um_documentod_FACE '" & gs_empresa & "','" &
                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" &
                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" &
                                Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"
                        Otrans.Ingresa(lsSQL)

                        lsSQL = "pa_ins_um_documentop_FACE '" & gs_empresa & "','" &
                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" &
                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"
                        Otrans.Ingresa(lsSQL)

                        lsSQL = "pa_ins_um_documentov_FACE '" & gs_empresa & "','" &
                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" &
                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"

                        Otrans.Ingresa(lsSQL)

                        ''Anulo el Documento Anterior
                        lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" &
                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "',NULL,'A','" &
                                gs_usuario & "','" & drv.Item("serieFACE") & " " & drv.Item("numeroFACE") & "'"
                        Otrans.Actualiza(lsSQL)


                        ''Actualizo la Informacion de GuateFactura

                        lsSQL = "pa_upd_um_ctacte_FACE '" & drv.Item("empresa") & "','" &
                            drv.Item("ctacte") & "','" &
                            drv.Item("nitFACE") & "','" &
                            drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" &
                            drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "','" &
                            drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" &
                            drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "'"

                        Otrans.Actualiza(lsSQL)
                        If drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("walmart") > 0 Or
                            drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("consolidado") > 0 Then
                            'Los Pedidos de WalMart No deben Generar Picking por eso se llena la Informacion con picker en Blanco
                            lsSQL = "pa_ins_um_gen_log_documento_tracking  '" &
                                        drv.Item("empresa") & "','" & drv.Item("serieFACE") &
                                        "','" & drv.Item("numeroFACE") & "','" & gs_usuario & "','" &
                                          "', NULL"
                            Otrans.Ingresa(lsSQL)

                        End If

                        ''Cuando sea un pedido consolidado debo anular los documentos prececentes de este
                        ''que deberian ser pedidos walmart
                        '(c) 31072015
                        If drv.Item("tipodoctoOrigen").ToString.ToLower.StartsWith("pedido consol") Then
                            ''Debo correr el Script del pedido Consolidad0






                        End If
                        ''Llamar al Reporte

                        Dim pm_valores(3), pm_valores_consolidado(2) As String
                        Dim pm_parametros(3) As String
                        Dim pm_conexion(3) As String


                        pm_conexion = clsGen.Parametros_Conexion("")
                        Dim ppath_reporte As String = clsGen.Path_Reporte
                        '023:


                        ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                        ppath_reporte += gs_empresa.ToLower.Trim + " "
                        ppath_reporte += drv.Item("serieFACE").ToString.Trim
                        ppath_reporte += ".rpt"
                        pm_parametros(0) = "empresa"
                        pm_parametros(1) = "tipodocto"
                        pm_parametros(2) = "numero"
                        pm_parametros(3) = "user_name"
                        pm_valores(0) = gs_empresa
                        pm_valores(1) = drv.Item("serieFACE")
                        pm_valores(2) = drv.Item("numeroFACE")
                        pm_valores(3) = gs_usuario



                        'Guardo las copias en pdf

                        nCopias = Me.nupCopias.Value
                        If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then nCopias = 1

                        _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", True, "", True, nCopias)

                        If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 And
                            drv.Item("tipodocto") = "PEDIDO FACE" Then 'Si El Pedido Lleva Bodega debe Realizar un Ingreso a la Bodega
                            ''(c) 20150522 Se Agrego validacion para que solo tome en cuenta los pedidos para generar la factura de compra

                            lsSQL = "flexline.spa_Convierte_FactVtas_Compras '" & gs_empresa & "','" &
                                        drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" &
                                        drv.Item("bodegaInterEmpresas") & "','ADMIN_ISF'"

                            If Otrans.Ingresa(lsSQL) > 0 Then 'Si se realizo el SP
                                clsGen.Escribir_Log("Enviar Impresion Ingreso " & gs_empresa)
                                ppath_reporte = clsGen.Path_Reporte
                                ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Compras.rpt"
                                Dim pm_parametros2(3) As String
                                Dim pm_valores2(3) As String

                                clsGen.Escribir_Log("Inicializo Parametros " & gs_empresa)
                                pm_parametros2(0) = "@Empresa"
                                pm_parametros2(1) = "@Tipodocto"
                                pm_parametros2(2) = "@Numero"
                                pm_parametros2(3) = "@Proveedor"

                                clsGen.Escribir_Log("Inicializo Valores " & gs_empresa)
                                pm_valores2(0) = gs_empresa
                                If drv.Item("ctacte").ToString.StartsWith("12218") Then
                                    pm_valores2(0) = "DMARTE1"
                                ElseIf drv.Item("ctacte").ToString.StartsWith("7951") Then
                                    pm_valores2(0) = "CODICASA"
                                ElseIf drv.Item("ctacte").ToString.StartsWith("6608") Then
                                    pm_valores2(0) = "DIUVA"
                                ElseIf drv.Item("ctacte").ToString.StartsWith("2968") Then
                                    pm_valores2(0) = "VINOTECA"
                                End If

                                clsGen.Escribir_Log("Parametros0 " & pm_valores2(0))
                                pm_valores2(1) = "FACE DE COMPRAS" '' drv.Item("serieFACE")
                                pm_valores2(2) = drv.Item("numeroFACE")
                                clsGen.Escribir_Log("Parametros1 " & pm_valores2(1))
                                clsGen.Escribir_Log("Parametros2 " & pm_valores2(2))

                                If gs_empresa.ToLower.Equals("dmarte1") Then
                                    pm_valores2(3) = "122183"
                                ElseIf gs_empresa.ToLower.Equals("codicasa") Then
                                    pm_valores2(3) = "79512"
                                ElseIf gs_empresa.ToLower.Equals("diuva") Then
                                    pm_valores2(3) = "6608388"
                                End If

                                'Los Ingresos Interempresas se imprimen en la misma impresora de facturas


                                clsGen.Escribir_Log("Parametros3 " & pm_valores2(3))

                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                        False, True, "PDF", False, "", True, 2, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)
                            End If 'realiza el ingreso
                        End If 'bodega Interempresa

                        ''Forma de Pago
                        If drv.Item("forma_pago").ToString.ToLower.StartsWith("contado") And drv.Item("tipodoctoOrigen").ToString.ToUpper = "PEDIDO FACE" Then

                            'lsSQL = flexline.spa_RecibosGuarda @Empresa varchar(20),@Tipodocto varchar(40), @Numero varchar(20)
                            lsSQL = " flexline.spa_RecibosGuarda '" & gs_empresa & "','" & drv.Item("serieFACE").ToString & "','" & drv.Item("numeroFACE").ToString & "'"
                            If Otrans.Ingresa(lsSQL) > 0 Then
                                ppath_reporte = clsGen.Path_Reporte
                                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

                                Dim pm_parametros2(2) As String
                                Dim pm_valores2(2) As String

                                pm_parametros2(0) = "Empresa"
                                pm_parametros2(1) = "Tipodocto"
                                pm_parametros2(2) = "Numero"

                                pm_valores2(0) = gs_empresa
                                pm_valores2(1) = drv.Item("serieFACE")
                                pm_valores2(2) = drv.Item("numeroFACE")


                                Try
                                    nCopias = 1
                                    dtImpresoras = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod 'recibos','gen_impresion','" & gs_empresa & "'")

                                    If dtImpresoras.Rows.Count = 1 Then
                                        If dtImpresoras.Rows(0).Item("valor1") = 1 Then
                                            drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")
                                            nCopias = 2
                                        End If


                                    End If
                                Catch ex As Exception

                                End Try

                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                        False, True, "PDF", False, "", True, 2, gs_empresa, drv.Item("ImpresoraFACE").ToString)


                                'Guardar Copia Electronica del Recibo
                                'Dim lsRutaCopia As String = clsGen.Path_Imagenes
                                'lsRutaCopia += "Recibos\" + psEmpresa + "\" + drv.Item("serieFACE") + "-" + drv.Item("numeroFACE")


                                '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                '        True, False, "PDF", False, lsRutaCopia, True, 1, psEmpresa, "")

                            End If

                        End If 'forma Pago

                    End If 'Ingreso Otrans.Ingresa(lsSQL)
                End If
            Next

            'Oaut = Nothing
            MessageBox.Show("Proceso Concluido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Mover Archivos
            moverArchivosFACE()
            crear_estructuraFACE()
            enviosPendientesFACE()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub txtNumeroOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroOC.KeyPress

        If e.KeyChar = Chr(13) Then
            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = true"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                drv.Item("enviar") = False
            Next
            Me.txtNumeroOC.Text = Me.txtNumeroOC.Text.PadLeft(10, "0")
            odsFACE.Tables("pedidos").DefaultView.RowFilter = "numero  = '" & Me.txtNumeroOC.Text & "'"

            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                drv.Item("enviar") = True
            Next
        End If

    End Sub

    Private Sub imprimirFACE()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Dim lsSQL As String
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM") & "\" & Me.dtpFechaInicioFACE.Value.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                If gs_empresa <> "DIUVA" Then


                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                    ppath_reporte += gs_empresa.ToLower.Trim + " "
                    ppath_reporte += drv.Item("serieFACE").ToString.Trim
                    'ppath_reporte += drv.Item("numeroFACE").ToString.Trim.Split("-")(0)
                    ppath_reporte += ".rpt"

                    pm_valores(0) = gs_empresa
                    'pm_valores(1) = drv.Item("numeroFACE").ToString.Trim.Split("-")(0)
                    'pm_valores(2) = drv.Item("numeroFACE").ToString.Trim.Split("-")(1)
                    pm_valores(1) = drv.Item("serieFACE")
                    pm_valores(2) = drv.Item("numeroFACE")
                    pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo
                Else
                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                    ppath_reporte += gs_empresa.ToLower.Trim + " "
                    ppath_reporte += drv.Item("serieFACE").ToString.Trim
                    ppath_reporte += ".rpt"

                    pm_valores(0) = gs_empresa
                    pm_valores(1) = drv.Item("serieFACE")
                    pm_valores(2) = drv.Item("numeroFACE")
                    pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo
                End If

                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, Me.nupCopias.Value)

                Try
                    lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
                                          drv.Item("empresa"), drv.Item("SerieFace").ToString, drv.Item("numeroFACE").ToString, gs_usuario, gs_nombre_equipo, "frm_pedidos_facturar", nupCopias.Value)

                    clsGen.insertQuery("FlexLine", lsSQL)
                Catch ex As Exception

                End Try


            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub imprimirCOMPRAS()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM") & "\" & Me.dtpFechaInicioFACE.Value.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView


                clsGen.Escribir_Log("Enviar Impresion Ingreso " & gs_empresa)
                ppath_reporte = clsGen.Path_Reporte
                ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Compras.rpt"
                Dim pm_parametros2(3) As String
                Dim pm_valores2(3) As String

                clsGen.Escribir_Log("Inicializo Parametros " & gs_empresa)
                pm_parametros2(0) = "@Empresa"
                pm_parametros2(1) = "@Tipodocto"
                pm_parametros2(2) = "@Numero"
                pm_parametros2(3) = "@Proveedor"

                clsGen.Escribir_Log("Inicializo Valores " & gs_empresa)
                pm_valores2(0) = gs_empresa
                If drv.Item("ctacte").ToString.StartsWith("12218") Then
                    pm_valores2(0) = "DMARTE1"
                ElseIf drv.Item("ctacte").ToString.StartsWith("7951") Then
                    pm_valores2(0) = "CODICASA"
                ElseIf drv.Item("ctacte").ToString.StartsWith("6608") Then
                    pm_valores2(0) = "DIUVA"
                ElseIf drv.Item("ctacte").ToString.StartsWith("2968") Then
                    pm_valores2(0) = "VINOTECA"
                ElseIf drv.Item("ctacte").ToString.StartsWith("11878454") Then
                    pm_valores2(0) = "LAINCONDI"

                End If


                clsGen.Escribir_Log("Parametros0 " & pm_valores2(0))
                If drv.Item("serieFACE").ToString.ToUpper.IndexOf("FECAM") > 0 Then
                    pm_valores2(1) = "FECAM DE COMPRAS" '' drv.Item("serieFACE")
                    pm_valores2(2) = drv.Item("numeroFACE")

                Else
                    pm_valores2(1) = "FEL DE COMPRAS" '' drv.Item("serieFACE")
                    pm_valores2(2) = drv.Item("numeroFEL").ToString().PadLeft(12, "0")
                End If



                clsGen.Escribir_Log("Parametros1 " & pm_valores2(1))
                clsGen.Escribir_Log("Parametros2 " & pm_valores2(2))

                If gs_empresa.ToLower.Equals("dmarte1") Then
                    pm_valores2(3) = "122183"
                ElseIf gs_empresa.ToLower.Equals("codicasa") Then
                    pm_valores2(3) = "79512"
                ElseIf gs_empresa.ToLower.Equals("diuva") Then
                    pm_valores2(3) = "6608388"
                ElseIf gs_empresa.ToLower.Equals("laincondi") Then
                    pm_valores2(3) = "11878454"
                End If

                'Los Ingresos Interempresas se imprimen en la misma impresora de facturas


                clsGen.Escribir_Log("Parametros3 " & pm_valores2(3))


                '(c) 20160916 Se Cambio la Cantidad de Copias a 1 en InterEmpresas
                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                                        False, True, "PDF", False, "", True, 1, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)




            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub


    Private Sub imprimirFEL()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Dim lsSQL As String
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtpFechaInicioFACE.Value.ToString("yyyyMM") & "\" & Me.dtpFechaInicioFACE.Value.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"

            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                If drv.Item("tipodocto").ToString() = "PEDIDO FEL EXENTO" Then

                    Dim pm_valores_ex(4), pm_valores_consolidado_ex(3) As String
                    Dim pm_parametros_ex(4) As String

                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                    ppath_reporte += gs_empresa.ToLower.Trim + " "
                    ppath_reporte += "FEL EXENTA"
                    ppath_reporte += ".rpt"


                    pm_parametros_ex(0) = "empresa"
                    pm_parametros_ex(1) = "tipodocto"
                    pm_parametros_ex(2) = "numero"
                    pm_parametros_ex(3) = "user_name"
                    pm_parametros_ex(4) = "CIF_FOB"

                    pm_valores_ex(0) = gs_empresa
                    pm_valores_ex(1) = drv.Item("serieFACE")
                    pm_valores_ex(2) = drv.Item("numero")
                    pm_valores_ex(3) = gs_usuario & " - " & gs_nombre_equipo
                    pm_valores_ex(4) = lbTipoExp.SelectedItem


                    _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        False, True, "PDF", True, "", True, Me.nupCopias_fel.Value)

                Else

                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                    ppath_reporte += gs_empresa.ToLower.Trim + " "
                    ppath_reporte += drv.Item("serieFACE").ToString.Trim
                    ppath_reporte += ".rpt"

                    pm_valores(0) = gs_empresa
                    pm_valores(1) = drv.Item("serieFACE")
                    pm_valores(2) = drv.Item("numeroFACE")
                    pm_valores(3) = gs_usuario & "-" & gs_nombre_equipo

                    _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        False, True, "PDF", True, "", True, Me.nupCopias_fel.Value)

                End If


                Try
                    lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
                                          drv.Item("empresa"), drv.Item("SerieFace").ToString, drv.Item("numeroFACE").ToString, gs_usuario, gs_nombre_equipo, "frm_pedidos_facturar", nupCopias_fel.Value)

                    clsGen.insertQuery("FlexLine", lsSQL)
                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub
    Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
        imprimirFACE()
    End Sub

    Private Sub moverArchivosFACE()

        Dim clsGen As New ClasesGenerales.General
        Dim lsArchivos() As String
        Try

            Me.txtRuta.Text = sDirectorio & ":\aplicaciones\log\" & gs_empresa & "\Factura\" &
            Today.ToString("yyyyMM")

            If Directory.Exists(Me.txtRuta.Text & "\Backup") Then
                'Try
                '    System.IO.File.Delete(lsNombreArchivo)
                '    entro = True
                'Catch ex As Exception
                'End Try
            Else
                System.IO.Directory.CreateDirectory(Me.txtRuta.Text & "\Backup")
                'entro = True
            End If

            lsArchivos = Directory.GetFiles(Me.txtRuta.Text, "*.*")
            For Each lsArchivo As String In lsArchivos
                clsGen.Mover_Archivo(lsArchivo, Me.txtRuta.Text & "\Backup\" & lsArchivo.Split("\").GetValue(lsArchivo.Split("\").LongLength - 1))

            Next
            lsArchivos = Directory.GetDirectories(Me.txtRuta.Text)
            For Each lsDirectorio As String In lsArchivos
                If lsDirectorio.LastIndexOf("app") > 0 Then
                    Directory.Delete(lsDirectorio, True)
                End If
                '    Directory.Move(lsDirectorio, Me.txtRuta.Text & "\backup")
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub liberarEnvios()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try



            Otrans.open()

            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            If odsFACE.Tables("pedidos").DefaultView.Count > 0 Then
                If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                        If drv.Item("fechaRecepcionFace").ToString.Trim.Length > 0 Then
                            MessageBox.Show("")
                        Else
                            lsSQL = "pa_del_um_gen_log_documento_face '" & drv.Item("empresa").ToString & "','" & drv.Item("tipoDocto").ToString & "','" & drv.Item("numero") & "'"
                            Otrans.Elimina(lsSQL)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub liberarEnviosFel()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try



            Otrans.open()

            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            If odsFACE.Tables("pedidos").DefaultView.Count > 0 Then
                If MessageBox.Show("Esta Seguro de Liberar Este Documento", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                        If drv.Item("numeroFEL").ToString.Trim.Length > 0 Then
                            MessageBox.Show("Este Documento No Se Puede Liberar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            'lsSQL = "pa_del_um_gen_log_documento_fel '" & drv.Item("empresa").ToString & "','" & drv.Item("tipoDocto").ToString & "','" & drv.Item("numero") & "'"
                            lsSQL = "pa_upd_reproceso_docto_fel '" & drv.Item("empresa").ToString & "','" & drv.Item("tipoDocto").ToString & "','" & drv.Item("numero") & "'"

                            Otrans.Elimina(lsSQL)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub ReimprimirRecibos_FACE()
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Try

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("SCM")
            Dim ppath_reporte As String = clsGen.Path_Reporte



            odsFACE.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView
                ppath_reporte = clsGen.Path_Reporte
                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

                Dim pm_parametros2(2) As String
                Dim pm_valores2(2) As String


                pm_parametros2(0) = "Empresa"
                pm_parametros2(1) = "Tipodocto"
                pm_parametros2(2) = "Numero"


                pm_valores2(0) = gs_empresa
                pm_valores2(1) = drv.Item("serieFACE")
                pm_valores2(2) = drv.Item("numeroFACE")


                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, Me.nupCopias.Value)

            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try
    End Sub

#End Region



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index
        If MessageBox.Show("Esta Seguro de Asignar Este Comentario a " & Chr(13) &
            Me.dgv_encabezado.Item("tipodocto", nrow).Value & " " & Me.dgv_encabezado.Item("numero", nrow).Value,
                "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarComentario2()
        End If
    End Sub

    Private Sub txt_total_pedido_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_pedido.TextChanged
        txt_total_pedido.Text = Format(Convert.ToDecimal(txt_total_pedido.Text), "###,###,##0.00").ToString
    End Sub


    Private Sub guardarComentario2()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index

        Try
            Otrans.open()
            'lsSQL = "pa_upd_um_documento_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" &
            '            Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" &
            '            Me.dgv_encabezado.Item("numero", nrow).Value & "','" &
            '            Me.txtComentario2.Text & "','" & gs_usuario & "'"

            '(c) 20241216 
            lsSQL = "pa_upd_um_documento_pedido_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" &
                        Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" &
                        Me.dgv_encabezado.Item("numero", nrow).Value & "','" &
                        Me.txtComentario2.Text & "','" & gs_usuario & "'"




            Otrans.Actualiza(lsSQL)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub





    Private Sub dgv_pedidosFACE_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_pedidosFACE.DataError

    End Sub

    Private Sub dgvDetalleFACE_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDetalleFACE.DataError

    End Sub

    Private Sub btnLiberarEnvios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberarEnvios.Click

        liberarEnvios()
    End Sub


    Private Sub btnObtenerNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerNC.Click
        crear_estructuraFACE()
        enviosPendientesNCE()
    End Sub

    Private Sub dgv_pedidosFACE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidosFACE.CellContentClick

    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index
        Dim lsBodega As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General


        Try


            ''Verificar Stock
            If Me.dgv_encabezado.Item("empresa", nrow).Value.ToString.ToUpper = "VINOTECA" Then 'And Me.cmb_estados.SelectedValue = "S" Then

                If Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.IndexOf("AG") > 0 Then
                    verificarStock_AGVinoteca(Me.dgv_encabezado.Item("empresa", nrow).Value,
                                 Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                               Me.dgv_encabezado.Item("numero", nrow).Value, ods,
                               Me.dgv_encabezado.Item("fecha", nrow).Value)
                Else


                    '(c) 20230711 Se traslada a clase y se facture automaticamente

                    Dim oComprasInterempresas As New Umbral_Flex.comprasInterempresa

                    Try
                        oComprasInterempresas.verificarStockVINOTECA(Me.dgv_encabezado.Item("fecha", nrow).Value)
                        oComprasInterempresas = Nothing
                    Catch ex As Exception

                    End Try
                    'verificarStock(Me.dgv_encabezado.Item("empresa", nrow).Value,
                    '             Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                    '           Me.dgv_encabezado.Item("numero", nrow).Value, ods,
                    '           Me.dgv_encabezado.Item("fecha", nrow).Value)

                End If
                '(c) 20230728
            ElseIf Me.dgv_encabezado.Item("empresa", nrow).Value.ToString.ToUpper = "LAINCONDI" Then
                'verificarStockLAINCONDICIONAL(Me.dgv_encabezado.Item("empresa", nrow).Value,
                '    Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                '    Me.dgv_encabezado.Item("numero", nrow).Value, ods,
                '    Me.dgv_encabezado.Item("fecha", nrow).Value)

                '(c) 20230711 Se traslada a clase y se facture automaticamente
                Dim oComprasInterempresas As New Umbral_Flex.comprasInterempresa

                Try
                    oComprasInterempresas.verificarStockLAINCONDICIONAL()
                    oComprasInterempresas = Nothing
                Catch ex As Exception

                End Try
            Else


                Dim ls_filtro As String
                ls_filtro = "empresa = '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "' and numero = '" & Me.dgv_encabezado.Item("numero", nrow).Value & "' and tipoDocto = '" & Me.dgv_encabezado.Item("tipodocto", nrow).Value & "'"
                oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = ls_filtro
                'For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                '    If drv.Item("SERIE") = "S" Then
                '        MessageBox.Show("Producto Requerie Añada, Por Favor Procese en FlexLine", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        Exit Try
                '    End If
                'Next

                If (Me.dgv_encabezado.Item("empresa", nrow).Value = "DMARTE1" Or
                    Me.dgv_encabezado.Item("empresa", nrow).Value = "CODICASA" Or
                    Me.dgv_encabezado.Item("empresa", nrow).Value = "DIUVA") _
                    And (Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.StartsWith("PEDIDO AL CONTADO") Or
                        Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.StartsWith("PEDIDO AL CREDITO")) Then


                    '(c) 20220809

                    If Me.dgv_encabezado.Item("cedi", nrow).Value.ToString.Length = 0 Then
                        lsBodega = "CD_CENTRAL"
                    Else

                        dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & Me.dgv_encabezado.Item("cedi", nrow).Value.ToString & "','GEN_LOCALES','" & Me.dgv_encabezado.Item("empresa", nrow).Value & "'")
                        If dt.Rows.Count = 1 Then
                            lsBodega = dt.Rows(0).Item("descripcion").ToString
                        Else
                            'Problema con los cedis
                            MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            Exit Sub
                        End If

                    End If

                    '(c) 20220809
                    generarPedidoFACEAutomatico_cedi(Me.dgv_encabezado.Item("empresa", nrow).Value,
                                     Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                                   Me.dgv_encabezado.Item("numero", nrow).Value, lsBodega,
                                   Me.dgv_encabezado.Item("cedi", nrow).Value)




                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub marcarRecogeBodega(psEmpresa As String, psTipodocto As String, psNumero As String)

        Dim clsGEN As New ClasesGenerales.General
        Dim lsSQL As String
        Try

            lsSQL = "pa_upd_um_documento_recoge_bodega '" & psEmpresa & "','" & psTipodocto & "','" & psNumero & "','" & gs_usuario & "'"
            clsGEN.insertQuery("FlexLine", lsSQL)

            MessageBox.Show("Información Actualizada Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            clsGEN = Nothing
        End Try
    End Sub


    Private Sub btnReimpresionRecibos_Click(sender As Object, e As EventArgs) Handles btnReimpresionRecibos.Click
        ReimprimirRecibos_FACE()
    End Sub

    Private Sub dgv_encabezado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_encabezado.CellContentClick

    End Sub

    Private Sub dgv_detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgv_encabezado_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles dgv_encabezado.CellParsing

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click, Label33.Click, Label34.Click, Label35.Click, Label37.Click

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesarEnvio.Click, btnNuevoEnvio.Click
        If MessageBox.Show("Esta Seguro de Realizar el Envio", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroFacturaEnvio.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim clsgen As New ClasesGenerales.General
            Dim dt As DataTable
            Dim lsSQL As String
            Me.txtNumeroFacturaEnvio.Text = Me.txtNumeroFacturaEnvio.Text.PadLeft(10, "0")
            lsSQL = "pa_var_um_documento_control_transporte '" & Me.cmbEmpresaEnvio.SelectedValue & "','" &
                            Me.cmbTipoDoctoEnvio.Text & "','" & Me.txtNumeroFacturaEnvio.Text & "'"

            dt = clsgen.selectQuery("FlexLine", lsSQL)
            Me.txtClienteEnvio.Text = ""
        End If
    End Sub


    Private Sub txt_total_unidades_TextChanged(sender As Object, e As EventArgs) Handles txt_total_unidades.TextChanged
        txt_total_unidades.Text = Format(Convert.ToDecimal(txt_total_unidades.Text), "###,###,##0.0").ToString
    End Sub

    Private Sub btn_obtener_informacion_fel_Click(sender As Object, e As EventArgs) Handles btn_obtener_informacion_fel.Click
        crear_estructuraFACE()
        Me.dgv_pedidosFACE.DataSource = Nothing
        Me.dgvDetalleFACE.DataSource = Nothing
        enviosPendientesFEL()
    End Sub

    Private Sub dgv_encabezado_fel_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv_encabezado_fel.CurrentCellChanged
        Try
            detalle_pedidoFEL(Me.dgv_encabezado_fel.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_reimpresion_fel_Click(sender As Object, e As EventArgs) Handles btn_reimpresion_fel.Click
        imprimirFEL()
    End Sub

    Private Sub reimprimirCOMPRAS_Click(sender As Object, e As EventArgs) Handles reimprimirCOMPRAS.Click
        Try
            imprimirCOMPRAS()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_liberar_envios_fel_Click(sender As Object, e As EventArgs) Handles btn_liberar_envios_fel.Click
        Try
            liberarEnviosFel()
        Catch ex As Exception

        End Try
    End Sub

    '(c) 20241003
    'Exclusivo para Vinoteca TMK
    Private Sub procesarPedidoVinotecaTMK()
        Dim lsSQL As String
        Dim nRow As Integer
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim slListaPrecio, slBodega, slPago, slArea As String

        Try

            nRow = Me.dgv_encabezado.CurrentRow.Index




            If MessageBox.Show("Esta Seguro de Procesar  " & Me.dgv_encabezado.Item("tipodocto", nRow).Value.ToString & "-" & Me.dgv_encabezado.Item("numero", nRow).Value.ToString & " de " & Me.dgv_encabezado.Item("empresa", nRow).Value.ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim oForm As New frm_pickeador
                oForm.Text = "Seleccione Bodega"
                oForm.Llenar_Combo_Bodega()
                oForm.ShowDialog()
                slBodega = oForm.cmb_nombre_picker.SelectedValue


                oForm = New frm_pickeador
                oForm.Text = "Seleccione Lista de Precios"
                oForm.Llenar_Combo_ListaPrecio()
                oForm.ShowDialog()
                slListaPrecio = oForm.cmb_nombre_picker.SelectedValue


                oForm = New frm_pickeador
                oForm.Text = "Seleccione Forma de Pago"
                oForm.Llenar_Combo_pago()
                oForm.ShowDialog()
                slPago = oForm.cmb_nombre_picker.SelectedValue

                oForm = New frm_pickeador
                oForm.Text = "Seleccione Area"
                oForm.Llenar_Combo_area_vinoteca()
                oForm.ShowDialog()
                slArea = oForm.cmb_nombre_picker.SelectedValue


                If MessageBox.Show("Desea Continuar con los Siguientes Datos" _
                                    + Chr(13) + "Bodega           : " + slBodega _
                                    + Chr(13) + "Lista de Precios : " + slListaPrecio _
                                    + Chr(13) + "Forma de Pago    : " + slPago _
                                    + Chr(13) + "Area             : " + slArea _
                                   , "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then



                    If Me.dgv_encabezado.Item("tipodocto", nRow).Value.ToString.ToUpper.StartsWith("PEDIDO") Then




                        lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi_descuento_porcentaje_asignado_minimo_listaprecios '"
                        lsSQL += Me.dgv_encabezado.Item("empresa", nRow).Value.ToString & "','" & Me.dgv_encabezado.Item("tipodocto", nRow).Value.ToString & "','" & Me.dgv_encabezado.Item("numero", nRow).Value.ToString & "',"
                        lsSQL += "'" & gs_usuario & "','" & slBodega & "','" & slArea & "',0,0,'" & slListaPrecio & "','" & slPago & "'"

                    ElseIf Me.dgv_encabezado.Item("tipodocto", nRow).Value.ToString.ToUpper.StartsWith("SOLICITUD") Then
                        lsSQL = "pa_ins_um_consigna_FACE_automatico_cedi_descuento_porcentaje_asignado_minimo_listaprecios '"
                        lsSQL += Me.dgv_encabezado.Item("empresa", nRow).Value.ToString & "','" & Me.dgv_encabezado.Item("tipodocto", nRow).Value.ToString & "','" & Me.dgv_encabezado.Item("numero", nRow).Value.ToString & "',"
                        lsSQL += "'" & gs_usuario & "','" & slBodega & "','" & slArea & "',0,0,'" & slListaPrecio & "','" & slPago & "'"


                    End If
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("Se Genero el Documento " & Me.dgv_encabezado.Item("empresa", nRow).Value.ToString & " - - " & dt.Rows(0).Item("TipoDocto").ToString & " - -" & dt.Rows(0).Item("numero").ToString, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub btnValidarStock_Click(sender As Object, e As EventArgs) Handles btnValidarStock.Click

        If tiene_permisos("mfi_fc_boton_facturar_automatico_tmk") Then
            'Boton para Factura de vinoteca TMK
            'necesito obtener 




            procesarPedidoVinotecaTMK()


        Else

            If MessageBox.Show("Desea Validar Stock", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                validarStockBodega()
            End If

        End If
    End Sub

    Private Sub btnTrasladoAntigua_Click(sender As Object, e As EventArgs) Handles btnTrasladoAntigua.Click
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index

        Try
            verificarStockAG(Me.dgv_encabezado.Item("fecha", nrow).Value, ods)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub button_reimprimir_recibos_Click(sender As Object, e As EventArgs) Handles button_reimprimir_recibos.Click
        ReimprimirRecibos_FEL()
    End Sub

    Private Sub verificarFEL_Click(sender As Object, e As EventArgs) Handles verificarFEL.Click
        verificarDocumentoFEL()
    End Sub


    Private Sub btnFacturacion_RecogeBodega_Click(sender As Object, e As EventArgs) Handles btnFacturacion_RecogeBodega.Click

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index

        Try
            'Otrans.open()
            'lsSQL = "pa_upd_um_documento_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("numero", nrow).Value & "','" & _
            '            Me.txtComentario2.Text & "','" & gs_usuario & "'"
            'Otrans.Actualiza(lsSQL)

            ''Verificar Stock
            If MessageBox.Show("Esta Seguro que Cliente " & Me.dgv_encabezado.Item("nombre_cliente", nrow).Value & "Recoge en Bodega", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                marcarRecogeBodega(Me.dgv_encabezado.Item("empresa", nrow).Value,
                                 Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                               Me.dgv_encabezado.Item("numero", nrow).Value)

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnFacturarBatch_Click(sender As Object, e As EventArgs) Handles btnFacturarBatch.Click
        Dim iSelectedRow As Integer
        Dim sTipodocto, sEmpresa, sNumero, lsBodega, slCedi As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim slistaPrecios As String

        Try

            iSelectedRow = Me.dgv_encabezado.Rows.GetRowCount(DataGridViewElementStates.Selected)

            For i As Integer = 0 To iSelectedRow


                slCedi = String.Empty

                sTipodocto = Me.dgv_encabezado.Item("tipodocto", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString
                sNumero = Me.dgv_encabezado.Item("numero", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString
                sEmpresa = Me.dgv_encabezado.Item("empresa", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString
                slCedi = Me.dgv_encabezado.Item("cedi", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString
                slistaPrecios = Me.dgv_encabezado.Item("listaprecio", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString

                If (sTipodocto.StartsWith("PEDIDO AL CONTADO") Or
                        sTipodocto.StartsWith("PEDIDO AL CREDITO")) And
                        (sEmpresa = "DMARTE1" Or
                        sEmpresa = "DIUVA" Or
                        sEmpresa = "CODICASA" Or
                        sEmpresa = "PURITA" Or
                        sEmpresa = "LAINCONDI" Or
                        sEmpresa = "VINOTECA") Then


                    If slCedi.Length = 0 Then
                        If sEmpresa = "VINOTECA" And slistaPrecios.ToString.ToUpper.StartsWith("7)_ON_PREMIUM") Then
                            lsBodega = "CD_PREMIUM"

                        Else
                            lsBodega = "CD_CENTRAL"
                        End If

                    Else
                        dt = Nothing


                        dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & sEmpresa & "'")
                        If dt.Rows.Count = 1 Then
                            lsBodega = dt.Rows(0).Item("descripcion").ToString
                        Else
                            'Problema con los cedis
                            MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            Exit Sub
                        End If

                    End If

                    '(c) 20220809
                    generarPedidoFACEAutomatico_cedi(sEmpresa,
                                     sTipodocto,
                                  sNumero, lsBodega,
                                   slCedi)


                    'generarPedidoFACEAutomatico(sEmpresa, sTipodocto, sNumero, "CD_CENTRAL")


                    'MessageBox.Show(Me.dgv_encabezado.Item("Empresa", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString & " - " &
                    'Me.dgv_encabezado.Item("tipodocto", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString & " - " &
                    'Me.dgv_encabezado.Item("numero", Me.dgv_encabezado.SelectedRows(i).Index).Value.ToString)
                End If

            Next






        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnFacturacionDescuento_Click(sender As Object, e As EventArgs) Handles btnFacturacionDescuento.Click

        Dim lsDescuento As String
        Dim nrow As Integer = Me.dgv_encabezado.CurrentRow.Index
        Dim lsBodega As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General


        Try

            Dim ls_filtro As String
            ls_filtro = "empresa = '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "' and numero = '" & Me.dgv_encabezado.Item("numero", nrow).Value & "' and tipoDocto = '" & Me.dgv_encabezado.Item("tipodocto", nrow).Value & "'"
            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = ls_filtro

            If (Me.dgv_encabezado.Item("empresa", nrow).Value = "DMARTE1" Or
                    Me.dgv_encabezado.Item("empresa", nrow).Value = "CODICASA" Or
                    Me.dgv_encabezado.Item("empresa", nrow).Value = "DIUVA" Or
                    Me.dgv_encabezado.Item("empresa", nrow).Value = "PURITA") _
                    And (Me.dgv_encabezado.Item("tipodocto", nrow).Value.ToString.StartsWith("PEDIDO AL CONTADO")) Then


                '(c) 20220809

                If Me.dgv_encabezado.Item("cedi", nrow).Value.ToString.Length = 0 Then
                    lsBodega = "CD_CENTRAL"
                Else

                    dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & Me.dgv_encabezado.Item("cedi", nrow).Value.ToString & "','GEN_LOCALES','" & Me.dgv_encabezado.Item("empresa", nrow).Value & "'")
                    If dt.Rows.Count = 1 Then
                        lsBodega = dt.Rows(0).Item("descripcion").ToString
                    Else
                        MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Exit Sub
                    End If
                End If

                lsDescuento = InputBox("Ingrese el Porcentaje de Descuento", "Descuento")

                If Double.Parse(lsDescuento) > 0.9 And Double.Parse(lsDescuento) < 10 Then

                    '(c) 20220809
                    generarPedidoFACEAutomatico_cedi(Me.dgv_encabezado.Item("empresa", nrow).Value,
                                     Me.dgv_encabezado.Item("tipodocto", nrow).Value,
                                   Me.dgv_encabezado.Item("numero", nrow).Value, lsBodega,
                                   Me.dgv_encabezado.Item("cedi", nrow).Value, Double.Parse(lsDescuento))
                Else
                    MessageBox.Show("Por Monto de Descuento lo Debe Realizar en FlexLine", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Proceso No Aplica para Empresa o Tipo de Documento", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub txtNumeroFacturaEnvio_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroFacturaEnvio.TextChanged

    End Sub

    Private Sub OFD_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OFD.FileOk

    End Sub
End Class