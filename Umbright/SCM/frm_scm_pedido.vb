Imports ZedGraph
'Imports AutomatizacionUmbright
Imports System.Text
Imports System.IO

Public Class frm_scm_pedido
    Inherits System.Windows.Forms.Form

    Dim snombreCalculo As String = ""
    Public ds_informacion_productos As DataSet
    Private piSemanas As Short = 0
    Dim pintar_azul As Boolean
    Dim psemana As Integer = DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday)
    Dim pfechaCalculo As DateTime
    Dim nfrozen As Integer = 0
    Dim nCodigoPedido As Integer = 0
    Dim pbBodegasExtras As Boolean = False
    Private columnasOcultas As String = String.Empty
    Private psNombreCalculo As String = String.Empty
    Private pGenerarTodasLasEmpresas As Boolean = False
    Private pbGenerarProyeccion As Boolean = False
    Friend WithEvents lblPresupuesto As System.Windows.Forms.Label
    Friend WithEvents HabilitarForecastingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Dim porcentajeAumentoPresupuesto As Double = 0
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerResumenGeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarResumenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAjuste As CheckBox
    Friend WithEvents lblPresupuestoAlterno As Windows.Forms.Label
    Friend WithEvents timer_orden As Windows.Forms.Timer
    Friend WithEvents lblHoraAutoSave As Windows.Forms.Label
    Friend WithEvents AutoSaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambiarTiempoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ObtenerVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetenerAutoSaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents IniciarAutosaveToolStripMenuItem As ToolStripMenuItem
    Dim generarForecasting As Boolean = False

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
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Exportar As System.Windows.Forms.Button
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aplicar_sugerido As System.Windows.Forms.Button
    Friend WithEvents btn_Abrir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_resumen As System.Windows.Forms.DataGridView
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_filtro As System.Windows.Forms.CheckBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AumentarDisminuirPresupuestoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarEstadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_pedido))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_Exportar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Btn_Aplicar_sugerido = New System.Windows.Forms.Button()
        Me.btn_Abrir = New System.Windows.Forms.Button()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.chk_filtro = New System.Windows.Forms.CheckBox()
        Me.dgv_resumen = New System.Windows.Forms.DataGridView()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AumentarDisminuirPresupuestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarEstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HabilitarForecastingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerResumenGeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarResumenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarTiempoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ObtenerVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DetenerAutoSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IniciarAutosaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblPresupuesto = New System.Windows.Forms.Label()
        Me.chkAjuste = New System.Windows.Forms.CheckBox()
        Me.lblPresupuestoAlterno = New System.Windows.Forms.Label()
        Me.timer_orden = New System.Windows.Forms.Timer(Me.components)
        Me.lblHoraAutoSave = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar.ImageIndex = 0
        Me.btn_buscar.ImageList = Me.ImageList1
        Me.btn_buscar.Location = New System.Drawing.Point(1014, 24)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(62, 64)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.Text = "Generar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btn_buscar, "Buscar Proveedor y Generar Informacion")
        Me.btn_buscar.UseVisualStyleBackColor = False
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
        Me.ImageList1.Images.SetKeyName(5, "venta.png")
        '
        'Btn_Exportar
        '
        Me.Btn_Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Exportar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Exportar.ForeColor = System.Drawing.Color.White
        Me.Btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Exportar.ImageIndex = 2
        Me.Btn_Exportar.ImageList = Me.ImageList1
        Me.Btn_Exportar.Location = New System.Drawing.Point(1132, 24)
        Me.Btn_Exportar.Name = "Btn_Exportar"
        Me.Btn_Exportar.Size = New System.Drawing.Size(75, 64)
        Me.Btn_Exportar.TabIndex = 2
        Me.Btn_Exportar.Text = "Exportar"
        Me.Btn_Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Btn_Exportar, "Guardar Calculo")
        Me.Btn_Exportar.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Guardar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Guardar.ImageIndex = 1
        Me.Btn_Guardar.ImageList = Me.ImageList1
        Me.Btn_Guardar.Location = New System.Drawing.Point(1207, 24)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 64)
        Me.Btn_Guardar.TabIndex = 2
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Btn_Guardar, "Guardar Calculo")
        Me.Btn_Guardar.UseVisualStyleBackColor = False
        '
        'Btn_Aplicar_sugerido
        '
        Me.Btn_Aplicar_sugerido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Aplicar_sugerido.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Aplicar_sugerido.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Aplicar_sugerido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aplicar_sugerido.ForeColor = System.Drawing.Color.White
        Me.Btn_Aplicar_sugerido.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Aplicar_sugerido.ImageIndex = 3
        Me.Btn_Aplicar_sugerido.ImageList = Me.ImageList1
        Me.Btn_Aplicar_sugerido.Location = New System.Drawing.Point(939, 25)
        Me.Btn_Aplicar_sugerido.Name = "Btn_Aplicar_sugerido"
        Me.Btn_Aplicar_sugerido.Size = New System.Drawing.Size(75, 64)
        Me.Btn_Aplicar_sugerido.TabIndex = 2
        Me.Btn_Aplicar_sugerido.Text = "Valorizado"
        Me.Btn_Aplicar_sugerido.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Btn_Aplicar_sugerido, "Aplicar Pedido Sugerido")
        Me.Btn_Aplicar_sugerido.UseVisualStyleBackColor = False
        '
        'btn_Abrir
        '
        Me.btn_Abrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Abrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Abrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Abrir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Abrir.ForeColor = System.Drawing.Color.White
        Me.btn_Abrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Abrir.ImageIndex = 4
        Me.btn_Abrir.ImageList = Me.ImageList1
        Me.btn_Abrir.Location = New System.Drawing.Point(1075, 24)
        Me.btn_Abrir.Name = "btn_Abrir"
        Me.btn_Abrir.Size = New System.Drawing.Size(57, 64)
        Me.btn_Abrir.TabIndex = 2
        Me.btn_Abrir.Text = "Abrir"
        Me.btn_Abrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btn_Abrir, "Buscar Proveedor y Generar Informacion")
        Me.btn_Abrir.UseVisualStyleBackColor = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.AllowUserToOrderColumns = True
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_detalle.Location = New System.Drawing.Point(1, 88)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(1280, 585)
        Me.dgv_detalle.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItem1.Text = "Inmovilizar Paneles"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItem2.Text = "Movilizar Paneles"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 50)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contenedor"
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "% Lleno"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cantidad"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'chk_filtro
        '
        Me.chk_filtro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_filtro.Location = New System.Drawing.Point(329, 69)
        Me.chk_filtro.Name = "chk_filtro"
        Me.chk_filtro.Size = New System.Drawing.Size(161, 17)
        Me.chk_filtro.TabIndex = 8
        Me.chk_filtro.Text = "Ver Todos Los Productos"
        Me.chk_filtro.UseVisualStyleBackColor = True
        '
        'dgv_resumen
        '
        Me.dgv_resumen.AllowUserToAddRows = False
        Me.dgv_resumen.AllowUserToDeleteRows = False
        Me.dgv_resumen.AllowUserToOrderColumns = True
        Me.dgv_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_resumen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_resumen.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_resumen.Location = New System.Drawing.Point(1, 679)
        Me.dgv_resumen.Name = "dgv_resumen"
        Me.dgv_resumen.ReadOnly = True
        Me.dgv_resumen.RowHeadersWidth = 25
        Me.dgv_resumen.Size = New System.Drawing.Size(1280, 99)
        Me.dgv_resumen.TabIndex = 9
        '
        'txtComentarios
        '
        Me.txtComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentarios.Location = New System.Drawing.Point(78, 24)
        Me.txtComentarios.MaxLength = 255
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(242, 63)
        Me.txtComentarios.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Comentarios"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(388, 25)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(169, 21)
        Me.cmbProveedor.TabIndex = 12
        Me.cmbProveedor.Visible = False
        '
        'cmbOrigen
        '
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(388, 48)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(169, 21)
        Me.cmbOrigen.TabIndex = 13
        Me.cmbOrigen.Visible = False
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(326, 28)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 11
        Me.lblProveedor.Text = "Proveedor"
        Me.lblProveedor.Visible = False
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Location = New System.Drawing.Point(326, 51)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(38, 13)
        Me.lblOrigen.TabIndex = 11
        Me.lblOrigen.Text = "Origen"
        Me.lblOrigen.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.AutoSaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AumentarDisminuirPresupuestoToolStripMenuItem, Me.CambiarEstadoToolStripMenuItem, Me.HabilitarForecastingToolStripMenuItem, Me.ToolStripMenuItem4, Me.VerResumenGeneralToolStripMenuItem, Me.ExportarResumenToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AumentarDisminuirPresupuestoToolStripMenuItem
        '
        Me.AumentarDisminuirPresupuestoToolStripMenuItem.Name = "AumentarDisminuirPresupuestoToolStripMenuItem"
        Me.AumentarDisminuirPresupuestoToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.AumentarDisminuirPresupuestoToolStripMenuItem.Text = "Aumentar/Disminuir Presupuesto"
        '
        'CambiarEstadoToolStripMenuItem
        '
        Me.CambiarEstadoToolStripMenuItem.Name = "CambiarEstadoToolStripMenuItem"
        Me.CambiarEstadoToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.CambiarEstadoToolStripMenuItem.Text = "Cambiar Estado"
        '
        'HabilitarForecastingToolStripMenuItem
        '
        Me.HabilitarForecastingToolStripMenuItem.Name = "HabilitarForecastingToolStripMenuItem"
        Me.HabilitarForecastingToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.HabilitarForecastingToolStripMenuItem.Text = "Habilitar Forecasting"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(251, 22)
        Me.ToolStripMenuItem4.Text = "-----------"
        '
        'VerResumenGeneralToolStripMenuItem
        '
        Me.VerResumenGeneralToolStripMenuItem.Name = "VerResumenGeneralToolStripMenuItem"
        Me.VerResumenGeneralToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.VerResumenGeneralToolStripMenuItem.Text = "Ver Resumen Empresa"
        '
        'ExportarResumenToolStripMenuItem
        '
        Me.ExportarResumenToolStripMenuItem.Name = "ExportarResumenToolStripMenuItem"
        Me.ExportarResumenToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.ExportarResumenToolStripMenuItem.Text = "Exportar Resumen"
        '
        'AutoSaveToolStripMenuItem
        '
        Me.AutoSaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiarTiempoToolStripMenuItem, Me.ToolStripMenuItem3, Me.ObtenerVersionToolStripMenuItem, Me.ToolStripMenuItem5, Me.DetenerAutoSaveToolStripMenuItem, Me.IniciarAutosaveToolStripMenuItem})
        Me.AutoSaveToolStripMenuItem.Name = "AutoSaveToolStripMenuItem"
        Me.AutoSaveToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.AutoSaveToolStripMenuItem.Text = "AutoSave"
        '
        'CambiarTiempoToolStripMenuItem
        '
        Me.CambiarTiempoToolStripMenuItem.Name = "CambiarTiempoToolStripMenuItem"
        Me.CambiarTiempoToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CambiarTiempoToolStripMenuItem.Text = "Cambiar Tiempo AutoSave"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(213, 6)
        '
        'ObtenerVersionToolStripMenuItem
        '
        Me.ObtenerVersionToolStripMenuItem.Name = "ObtenerVersionToolStripMenuItem"
        Me.ObtenerVersionToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ObtenerVersionToolStripMenuItem.Text = "Obtener Version "
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(213, 6)
        '
        'DetenerAutoSaveToolStripMenuItem
        '
        Me.DetenerAutoSaveToolStripMenuItem.Name = "DetenerAutoSaveToolStripMenuItem"
        Me.DetenerAutoSaveToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.DetenerAutoSaveToolStripMenuItem.Text = "Detener AutoSave"
        '
        'IniciarAutosaveToolStripMenuItem
        '
        Me.IniciarAutosaveToolStripMenuItem.Name = "IniciarAutosaveToolStripMenuItem"
        Me.IniciarAutosaveToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.IniciarAutosaveToolStripMenuItem.Text = "Iniciar Autosave"
        '
        'lblPresupuesto
        '
        Me.lblPresupuesto.AutoSize = True
        Me.lblPresupuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresupuesto.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPresupuesto.Location = New System.Drawing.Point(563, 30)
        Me.lblPresupuesto.Name = "lblPresupuesto"
        Me.lblPresupuesto.Size = New System.Drawing.Size(100, 16)
        Me.lblPresupuesto.TabIndex = 16
        Me.lblPresupuesto.Text = "Aumento 10%"
        Me.lblPresupuesto.Visible = False
        '
        'chkAjuste
        '
        Me.chkAjuste.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAjuste.Location = New System.Drawing.Point(496, 68)
        Me.chkAjuste.Name = "chkAjuste"
        Me.chkAjuste.Size = New System.Drawing.Size(66, 19)
        Me.chkAjuste.TabIndex = 17
        Me.chkAjuste.Text = "Ajuste"
        Me.chkAjuste.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAjuste.UseVisualStyleBackColor = True
        '
        'lblPresupuestoAlterno
        '
        Me.lblPresupuestoAlterno.AutoSize = True
        Me.lblPresupuestoAlterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresupuestoAlterno.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPresupuestoAlterno.Location = New System.Drawing.Point(563, 46)
        Me.lblPresupuestoAlterno.Name = "lblPresupuestoAlterno"
        Me.lblPresupuestoAlterno.Size = New System.Drawing.Size(81, 26)
        Me.lblPresupuestoAlterno.TabIndex = 18
        Me.lblPresupuestoAlterno.Text = "Presupuesto " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alterno"
        Me.lblPresupuestoAlterno.Visible = False
        '
        'timer_orden
        '
        Me.timer_orden.Interval = 300000
        '
        'lblHoraAutoSave
        '
        Me.lblHoraAutoSave.AutoSize = True
        Me.lblHoraAutoSave.Location = New System.Drawing.Point(847, 72)
        Me.lblHoraAutoSave.Name = "lblHoraAutoSave"
        Me.lblHoraAutoSave.Size = New System.Drawing.Size(0, 13)
        Me.lblHoraAutoSave.TabIndex = 19
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "xml"
        Me.OpenFileDialog1.InitialDirectory = "c:\aplicaciones\compras\autosave"
        Me.OpenFileDialog1.Title = "Version"
        '
        'frm_scm_pedido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1284, 781)
        Me.Controls.Add(Me.lblHoraAutoSave)
        Me.Controls.Add(Me.lblPresupuestoAlterno)
        Me.Controls.Add(Me.chkAjuste)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmbOrigen)
        Me.Controls.Add(Me.cmbProveedor)
        Me.Controls.Add(Me.dgv_resumen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblOrigen)
        Me.Controls.Add(Me.lblProveedor)
        Me.Controls.Add(Me.txtComentarios)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.chk_filtro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.btn_Abrir)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.Btn_Exportar)
        Me.Controls.Add(Me.Btn_Aplicar_sugerido)
        Me.Controls.Add(Me.lblPresupuesto)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_scm_pedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Generar Pedido .::"
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub Colorear_DetalleNew()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa,"
            'ls_columnas_ocultar += ",pv_modificar_transito,peso_total,volumen_total,cuando,cuanto,pv_inv_seguridad,marca,diario_cajas,estatus,sugerido_proveedor,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,calculos,"
            'ls_columnas_ocultar += ",pv_inv_meximo,min_cajas,max_cajas,pv_inv_reorden,peso,volumen,full,"
            ls_columnas_fijas = ",bodegas,pv_lead_time_total=50,"

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_productos"), Me.dgv_detalle, "", ls_columnas_ocultar, "", "", ",max_cajas=cuanto,min_cajas=cuando,porcentaje_ajuste=% Ajuste,pv_lead_time_total=Lead Time,", ls_columnas_fijas, "", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                    dc.DefaultCellStyle.Format = "n1"
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If piSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < piSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If


                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("trans") Or dc.Name.ToLower = "pedido" Or dc.Name.ToLower.StartsWith("saldo") _
                        Or dc.Name.ToLower.StartsWith("ppto") Or dc.Name.ToLower.StartsWith("exis") Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.Width = 50
                ElseIf dc.Name.StartsWith("cd_") Or dc.Name.StartsWith("da_") Or dc.Name.StartsWith("cdx_") Or dc.Name.StartsWith("internaci") Or dc.Name.ToLower = "uxc" Or dc.Name.ToLower = "pareto" Or dc.Name.ToLower = "porcentaje_ajuste" Or dc.Name.ToLower = "bodegas" Then
                    dc.Width = 30
                    dc.DefaultCellStyle.Format = "n0"
                End If

                'If dc.Name.ToLower.StartsWith("exis") Then
                '    dc.DefaultCellStyle.Format = "n0"
                '    dc.Width = 50
                'End If
                'If dc.Name.ToLower.IndexOf("+") > 0 Then
                '    dc.ToolTipText = pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                '    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                '                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
                'ElseIf dc.Name.ToLower.StartsWith("trans") Then
                '    dc.ToolTipText = pfechaCalculo.ToString("dd-MMM-yyyy")
                'ElseIf dc.Name.ToLower.StartsWith("pedido") Then
                '    dc.ToolTipText = pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).ToString("dd-MMM-yyyy")
                '    dc.HeaderText = dc.HeaderText + " sem" + _
                '            DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString))).ToString
                'End If (c)060911 Mostrar las fechas



                If dc.Name.ToLower.IndexOf("+") > 0 Then


                    If pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).Year > Now.Year Then

                        If pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7).Year = Now.Year Then
                            dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem 1" '+ _
                            'DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString()
                            dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " 01-Ene-" +
                                        pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("yyyy")
                        Else

                            'End If

                            dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                         DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7), FirstDayOfWeek.Monday).ToString
                            dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " +
                                        pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7).ToString("dd-MMM-yyyy")
                        End If
                    Else
                        dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                     DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)), FirstDayOfWeek.Monday).ToString
                        dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " +
                                    pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                    End If


                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = pfechaCalculo.ToString("dd-MMM-yyyy")

                ElseIf dc.Name.ToLower.StartsWith("pedido") Then

                    If pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).Year > Now.Year Then
                        dc.HeaderText = dc.HeaderText + " " + pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).AddDays(-7).ToString("dd-MMM-yyyy")
                        dc.ToolTipText = " sem" +
                                DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).AddDays(-7), FirstDayOfWeek.Monday).ToString

                    Else
                        dc.HeaderText = dc.HeaderText + " " + pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).ToString("dd-MMM-yyyy")
                        dc.ToolTipText = " sem" +
                                DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)), FirstDayOfWeek.Monday).ToString
                    End If

                End If

                If dc.Name.ToLower.StartsWith("pedido") Or dc.Name.ToLower.StartsWith("agre") Or dc.Name.ToLower.StartsWith("porcentaje_ajuste") Or dc.Name.ToLower.StartsWith("pv_lead_time_total") Then
                    dc.ReadOnly = False
                End If
                'If dc.Name.ToLower.Equals("producto") Then
                '    dc.Visible = True
                'End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub


    Private Sub Colorear_Detalle(ByRef phabilitarForecast As Boolean)
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa,"
            ls_columnas_ocultar += ",familia,region,pv_modificar_transito,peso_total,volumen_total,cuando,cuanto,pv_inv_seguridad,marca,diario_cajas,estatus,sugerido_proveedor,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,calculos,"
            'ls_columnas_ocultar += ",pv_inv_meximo,min_cajas,max_cajas,pv_inv_reorden,peso,volumen,full,"
            ls_columnas_ocultar += ",pv_inv_meximo,pv_inv_reorden,peso,volumen,full,cuando,cuanto,min_cajas,max_cajas,"
            ls_columnas_fijas = ",bodegas,pv_lead_time_total=50,bu=50,inco_cajas=50,"

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_productos"), Me.dgv_detalle, "", ls_columnas_ocultar, "", "", ",max_cajas=cuanto,min_cajas=cuando,porcentaje_ajuste=% Ajuste,pv_lead_time_total=Lead Time,cdx_cajas=cd_xela,cdag_cajas=cd_antigua,cdor_cajas=cdr_oriente,inco_cajas=incondi,", ls_columnas_fijas, "", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                    dc.DefaultCellStyle.Format = "n1"
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If piSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < piSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If


                ElseIf dc.Name.ToLower.StartsWith("teoric") Or dc.Name.ToLower.StartsWith("valor_transi") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("transito+") Or dc.Name.ToLower = "pedido" Or dc.Name.ToLower.StartsWith("saldo") _
                        Or dc.Name.ToLower.StartsWith("ppto") Or dc.Name.ToLower.StartsWith("exis") Or dc.Name.ToLower.Equals("transito") _
                        Or dc.Name.ToLower.StartsWith("consignacio") Or dc.Name.ToLower.StartsWith("reservas") Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.Width = 50
                ElseIf dc.Name.StartsWith("cd_") Or dc.Name.StartsWith("da_") Or dc.Name.StartsWith("cdag_") Or dc.Name.StartsWith("cdx_") Or dc.Name.StartsWith("cdor_") Or dc.Name.StartsWith("internaci") Or
                    dc.Name.ToLower = "uxc" Or dc.Name.ToLower = "pareto" Or dc.Name.ToLower = "porcentaje_ajuste" Or dc.Name.ToLower = "bodegas" Or dc.Name.ToLower = "minimo_compra" Or dc.Name.StartsWith("inco_cajas") Then
                    dc.Width = 30
                    dc.DefaultCellStyle.Format = "n0"
                End If

                'If dc.Name.ToLower.StartsWith("exis") Then
                '    dc.DefaultCellStyle.Format = "n0"
                '    dc.Width = 50
                'End If
                'If dc.Name.ToLower.IndexOf("+") > 0 Then
                '    dc.ToolTipText = pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                '    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                '                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
                'ElseIf dc.Name.ToLower.StartsWith("trans") Then
                '    dc.ToolTipText = pfechaCalculo.ToString("dd-MMM-yyyy")
                'ElseIf dc.Name.ToLower.StartsWith("pedido") Then
                '    dc.ToolTipText = pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).ToString("dd-MMM-yyyy")
                '    dc.HeaderText = dc.HeaderText + " sem" + _
                '            DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString))).ToString
                'End If (c)060911 Mostrar las fechas



                If dc.Name.ToLower.IndexOf("+") > 0 Then


                    If pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).Year > Now.Year Then

                        If pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7).Year = Now.Year Then
                            dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem 1" '+ _
                            'DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString()
                            dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " 01-Ene-" +
                                        pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("yyyy")
                        Else

                            'End If

                            dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                         DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7), FirstDayOfWeek.Monday).ToString
                            dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " +
                                        pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).AddDays(-7).ToString("dd-MMM-yyyy")
                        End If
                    Else
                        dc.ToolTipText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                     DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)), FirstDayOfWeek.Monday).ToString
                        dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " +
                                    pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                    End If


                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = pfechaCalculo.ToString("dd-MMM-yyyy")

                ElseIf dc.Name.ToLower.StartsWith("pedido") Then

                    If pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).Year > Now.Year Then
                        dc.HeaderText = dc.HeaderText + " " + pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).AddDays(-7).ToString("dd-MMM-yyyy")
                        dc.ToolTipText = " sem" +
                                DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).AddDays(-7), FirstDayOfWeek.Monday).ToString

                    Else
                        dc.HeaderText = dc.HeaderText + " " + pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)).ToString("dd-MMM-yyyy")
                        dc.ToolTipText = " sem" +
                                DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * Double.Parse(ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total").ToString)), FirstDayOfWeek.Monday).ToString
                    End If

                End If

                If dc.Name.ToLower.StartsWith("pedido") Or dc.Name.ToLower.StartsWith("agre") Or dc.Name.ToLower.StartsWith("porcentaje_ajuste") Or dc.Name.ToLower.StartsWith("pv_lead_time_total") Then
                    dc.ReadOnly = False
                End If

                '20160629 (c) Poder habilitar transito cuando se genera un forecast

                If phabilitarForecast Then
                    If dc.Name.ToLower.StartsWith("transito") Then
                        dc.ReadOnly = False
                    End If
                End If
                'If dc.Name.ToLower.Equals("producto") Then
                '    dc.Visible = True
                'End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Colorear_Resumen()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            'ls_columnas_ocultar += ",region,marca,fob,existencia,glosa,producto,pareto,uxc,agregar,diario_cajas,estatus,cd_cajas,cdx_cajas,da_cajas,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,full,cajasxpallet,cajasxlayer,calculos,"
            ls_columnas_ocultar += ",region,marca,fob,existencia,glosa,producto,pareto,uxc,agregar,diario_cajas,estatus,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,full,cajasxpallet,cajasxlayer,calculos,"
            ls_columnas_ocultar += "porcentaje_ajuste,"
            ls_columnas_fijas = String.Empty

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("Resumen"), Me.dgv_resumen, "", ls_columnas_ocultar, "", "", ",valor_sugerido=valor_pedido,", ls_columnas_fijas, ",proveedor,procedencia,pedido,valor_sugerido,peso,volumen,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_resumen.Columns
                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                    'dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If piSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < piSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If


                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("saldo") Then
                    dc.Visible = True
                ElseIf dc.Name.ToLower.StartsWith("transi") Then
                    dc.Visible = True
                ElseIf dc.Name.IndexOf("+") > 0 Then
                    dc.Visible = False

                End If
                If pbGenerarProyeccion Then
                    If dc.Name.ToString.StartsWith("valor_transit") Then
                        dc.Width = 70
                    End If

                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)), FirstDayOfWeek.Monday).ToString


                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Colorear_Resumen_Empresa()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            'ls_columnas_ocultar += ",region,marca,fob,existencia,glosa,producto,pareto,uxc,agregar,diario_cajas,estatus,cd_cajas,cdx_cajas,da_cajas,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,full,cajasxpallet,cajasxlayer,calculos,"
            ls_columnas_ocultar += "porcentaje_ajuste,"
            ls_columnas_fijas = String.Empty

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("ResumenEmpresa"), Me.dgv_resumen, "", ls_columnas_ocultar, "", "", ",valor_sugerido=valor_pedido,", ls_columnas_fijas, ",proveedor,procedencia,pedido,valor_sugerido,peso,volumen,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_resumen.Columns
                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    'dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    'dc.Width = 50
                    'dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If piSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < piSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If


                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("saldo") Then
                    dc.Visible = True
                ElseIf dc.Name.IndexOf("+") > 0 Then
                    dc.Visible = False

                End If
                If pbGenerarProyeccion Then
                    If dc.Name.ToString.StartsWith("valor_transit") Then
                        dc.Width = 70
                    End If

                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)), FirstDayOfWeek.Monday).ToString
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub


    Private Sub Recargar_Resumen()

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Try
            oCompras.generarResumen()
            '(c) 20160719
            'oCompras.generarResumenTotal()
            oCompras.generarResumenEmpresa()
            oCompras.Generar_SaldosyCoberturasResumenTotal("resumen")
            oCompras.Generar_SaldosyCoberturasResumenTotal("resumenEmpresa")
            'oCompras.generarPedidoSugeridoEmpresa("CODICASA", "", 1, False)

        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try


        Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")
        ds_informacion_productos.Tables("Resumen").DefaultView.RowFilter = ""
        Colorear_Resumen() '(c) Regresar a su valor anterior 20160914
        'Colorear_Resumen_Empresa()

        'Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumenTotal")
        'ds_informacion_productos.Tables("ResumenTotal").DefaultView.RowFilter = ""
        'Colorear_Resumen()


    End Sub

    'Guardar Calculo
    Private Sub Guardar_Calculo()


        Dim berror As Boolean = False
        'Dim dt As DataTable
        Dim ds As New DataSet("calculo")
        Dim ls_sql As String


        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General


        Try
            otrans.open()
            ds.Tables.Add(ds_informacion_productos.Tables("detalle_productos").Copy)
            ds.Tables.Add(ds_informacion_productos.Tables("derivados").Copy)
            If ds_informacion_productos.Tables.Contains("existencias") Then ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)

            Try
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_derivado").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_mensual").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("transitos").Copy)


                ds.Tables.Add(ds_informacion_productos.Tables("existenciasLote").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("existenciasSerie").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)
                'dt.TableName = "presupuesto_derivado";
            Catch ex As Exception

            End Try
            ''Agregar presupuesto por Producto Actual



            If snombreCalculo.Length = 0 Then snombreCalculo = InputBox("Ingrese Nombre De Calculo", "Nombre", psNombreCalculo)
            If snombreCalculo.Length > 0 Then
                'ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & Clsgen.Obtener_XMLConfig("ubicacion",False), False)
                If generarForecasting Then
                    snombreCalculo = snombreCalculo + "_forecast"
                End If

                Try
                    'copia local (c) 20200526
                    ds.WriteXml("c:\aplicaciones\compras\" & snombreCalculo.Trim & ".xml", XmlWriteMode.WriteSchema)

                Catch ex As Exception

                End Try

                ds.WriteXml("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\compras$\" & snombreCalculo.Trim & ".xml", XmlWriteMode.WriteSchema)


                'ls_sql = "pa_ins_um_inv_pedido_encabezado '" & gs_empresa & "','" & snombre & "','" & gs_usuario & "','" & Me.txtComentarios.Text & "','" & columnasOcultas & "'," & piSemanas & "," & porcentajeAumentoPresupuesto
                ls_sql = "pa_ins_um_inv_pedido_encabezado '" & gs_empresa & "','" & snombreCalculo & "','" & gs_usuario & "','" & String.Empty & "','" & columnasOcultas & "'," & piSemanas & "," & porcentajeAumentoPresupuesto
                otrans.Ingresa(ls_sql)


                If berror Then
                    MessageBox.Show("El Proceso Genero Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Proceso Guardado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Debe Ingresar Un Nombre Para el Calculo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClsGen.Escribir_Log(ex.ToString)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub


    '(c) 20160714
    Private Sub modificarCalculo()

        Dim snombre As String
        Dim berror As Boolean = False
        Dim dt As DataTable
        Dim ds As New DataSet("calculo")
        Dim ls_sql As String


        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General


        Try
            otrans.open()
            ds.Tables.Add(ds_informacion_productos.Tables("detalle_productos").Copy)
            ds.Tables.Add(ds_informacion_productos.Tables("derivados").Copy)
            If ds_informacion_productos.Tables.Contains("existencias") Then ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)

            Try
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_derivado").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_mensual").Copy)

                ds.Tables.Add(ds_informacion_productos.Tables("transitos").Copy)



                ds.Tables.Add(ds_informacion_productos.Tables("existenciasLote").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("existenciasSerie").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)


                'dt.TableName = "presupuesto_derivado";
            Catch ex As Exception

            End Try
            ''Agregar presupuesto por Producto Actual



            'piSemanas = oform.pnSemanas
            'columnasOcultas = oform.psColumnasOcultas
            'pfechaCalculo = oform.pFechaCalculo
            'psNombreCalculo = oform.psNombreCalculo
            'nCodigoPedido = oform.pnumeroPedido



            snombre = psNombreCalculo + "_editado"

            Try
                Try
                    'copia local (c) 20200526
                    ds.WriteXml("c:\aplicaciones\compras\" & snombre.Trim & ".xml", XmlWriteMode.WriteSchema)

                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try

            ds.WriteXml("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\compras$\" & snombre.Trim & ".xml", XmlWriteMode.WriteSchema)


            'ls_sql = "pa_ins_um_inv_pedido_encabezado '" & gs_empresa & "','" & snombre & "','" & gs_usuario & "','" & Me.txtComentarios.Text & "','" & columnasOcultas & "'," & piSemanas & "," & porcentajeAumentoPresupuesto

            ls_sql = "pa_upd_um_inv_pedido_encabezado " & nCodigoPedido & ",null,'" & gs_usuario & "','" & snombre & "'"
            'ls_sql = "pa_ins_um_inv_pedido_encabezado '" & gs_empresa & "','" & snombre & "','" & gs_usuario & "','" & String.Empty & "','" & columnasOcultas & "'," & piSemanas & "," & porcentajeAumentoPresupuesto)
            otrans.Ingresa(ls_sql)



            agregarComentario("Indique Cual es el Motivo de la Edicion")

            If berror Then
                MessageBox.Show("El Proceso Genero Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Proceso Guardado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClsGen.Escribir_Log(ex.ToString)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub


    Private Sub generarVentas()

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try


            therow = Me.dgv_detalle.CurrentRow
            oCompras.Empresa = dgv_detalle.Item("empresa", therow.Index).Value
            oCompras.mostrarVentas(dgv_detalle.Item("producto", therow.Index).Value,
                                    dgv_detalle.Item("glosa", therow.Index).Value, True)


        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try


    End Sub

    Private Sub generarVentasold()
        Dim Otrans As New Transaccional.Conexion("umbralsa")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2, dt3 As DataTable
        Dim ls_sql As String

        Dim therow As DataGridViewRow


        Try
            Otrans.open()

            therow = Me.dgv_detalle.CurrentRow


            ls_sql = "pa_sel_um_producto_derivado '" & gs_empresa & "','" & dgv_detalle.Item("producto", therow.Index).Value & "'"
            dt2 = Otrans.Obtiene(ls_sql)



            ls_sql = "pa_var_um_ventas_presupuesto_producto_periodo '" & gs_empresa & "','" &
                    dgv_detalle.Item("producto", therow.Index).Value & "','" & Today.AddYears(-1).ToString("yyyyMM") & "'"

            dt = Otrans.Obtiene(ls_sql)

            If dt2.Rows.Count > 0 Then
                For Each dr As DataRow In dt2.Rows
                    Try

                        ls_sql = "pa_var_um_ventas_presupuesto_producto_periodo '" & gs_empresa & "','" &
                                dr.Item("producto") & "','" & Today.AddYears(-1).ToString("yyyyMM") & "'"
                        dt3 = Otrans.Obtiene(ls_sql)

                        For Each dr2 As DataRow In dt3.Rows
                            Dim dr3 As DataRow = dt.NewRow
                            For Each dc As DataColumn In dt.Columns
                                dr3.Item(dc.ColumnName) = dr2.Item(dc.ColumnName)
                            Next
                            dt.Rows.Add(dr3)
                        Next

                    Catch ex As Exception

                    End Try
                Next
            End If

            If dt.Rows.Count > 0 Then

                Dim oform As New frm_resultado
                oform.Text = "Ventas " + dgv_detalle.Item("producto", therow.Index).Value + " - " + dgv_detalle.Item("glosa", therow.Index).Value

                dt.DefaultView.Sort = "periodo DESC"
                oform.dgv_resultado.DataSource = dt
                Dim lcolumnasmostrar As String = ",periodo,ventas_cajas,pptocom,pptomer,"
                If Not dt2 Is Nothing Then lcolumnasmostrar += "producto,glosa,"


                ClsGen.Alinear_GridView(dt, oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", "", True, True, 190, 0)
                '  ClsGen.Alinea_Grid(dt, oform.DataGrid1, dt.TableName, -1, 250, 0, False, True, ",,", True, "")
                With oform.dgv_resultado
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                End With
                oform.ShowDialog()
                oform = Nothing
            End If
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub mostrarTransitoProducto()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2, dtfinal As DataTable
        Dim draux As DataRow
        Dim ls_sql, sencabezado As String
        sencabezado = String.Empty
        Dim lbmultiples As Boolean = False
        Dim therow As DataGridViewRow
        Dim pempresa, pproducto As String

        Try
            therow = Me.dgv_detalle.CurrentRow
            pempresa = dgv_detalle.Item("empresa", therow.Index).Value
            pproducto = dgv_detalle.Item("producto", therow.Index).Value
            sencabezado = "Transitos :: " & pproducto & " - " & dgv_detalle.Item("glosa", therow.Index).Value



            ds_informacion_productos.Tables("transitos").DefaultView.RowFilter = "empresa = '" & pempresa &
                "' and producto = '" & pproducto & "'"

            If ds_informacion_productos.Tables("transitos").DefaultView.Count > 0 Then
                Dim oform As New frm_resultado
                ds_informacion_productos.Tables("transitos").DefaultView.Sort = "fecha_vencimiento"
                oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("transitos").DefaultView
                ClsGen.Alinear_GridView(ds_informacion_productos.Tables("transitos").DefaultView.ToTable,
                                oform.dgv_resultado, ",numero,fecha_vencimiento,semana,cajas_pedidas,cantidadArriboPuerto,", "", "", "",
                                ",fecha_vencimiento=fecha_ingreso,cantidadArriboPuerto=cajas_facturadas,", "", ",cajas_pedidas,cantidadArriboPuerto,fecha_vencimiento,semana,numero,cantidadArriboPuerto,", True, True, 250, 0)

                oform.Text = sencabezado

                Try
                    oform.lblResumenlabel.Visible = True
                    oform.lblResumenTotal.Visible = True

                    dt = ds_informacion_productos.Tables("transitos").DefaultView.ToTable
                    oform.lblResumenlabel.Text = "Cajas Pedidas " & Format(Convert.ToDecimal(dt.Compute("Sum(cajas_pedidas)", "cajas_pedidas>0")), "###,###,##0.0").ToString()
                    oform.lblResumenTotal.Text = "Cajas Arribo " & Format(Convert.ToDecimal(dt.Compute("Sum(cap)", "cap>0")), "###,###,##0.0").ToString()
                Catch ex As Exception

                End Try
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing


                'Format(Convert.ToDecimal(cajas_decimal), "###,###,##0.00").ToString()

            End If


        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing

        End Try

    End Sub

    Private Sub mostrarTransito(ByVal pEmpresa As String, ByVal pProducto As String, ByVal pSemana As String, pdtDerivados As DataTable)
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2, dtfinal As DataTable
        Dim draux As DataRow
        Dim ls_sql, sencabezado As String
        sencabezado = String.Empty
        Dim lbmultiples As Boolean = False

        Try
            otrans.open()
            ls_sql = "pa_var_um_transito_productos_semana_producto '" & pEmpresa & "','" & pProducto & "'," & DatePart(DateInterval.WeekOfYear, Date.Parse(pSemana), FirstDayOfWeek.Monday) & "," & Date.Parse(pSemana).Year
            dt = otrans.Obtiene(ls_sql)

            Try

                For Each dr As DataRow In dt.Rows
                    ls_sql = "pa_var_um_transito_productos_orden '" & pEmpresa & "','" & dr.Item("numero") & "'"
                    '  If sencabezado.Length > 0 Then sencabezado += Chr(13)
                    sencabezado += "::No. Orden " & dr.Item("numero") & " -- Fecha " & dr.Item("fecha")
                    dt2 = otrans.Obtiene(ls_sql)
                    If dtfinal Is Nothing Then
                        dtfinal = dt2.Copy
                    Else
                        lbmultiples = True
                        For Each draux2 As DataRow In dt2.Rows


                            draux = dtfinal.NewRow
                            For Each dc As DataColumn In dtfinal.Columns
                                draux.Item(dc.ColumnName) = draux2.Item(dc.ColumnName)
                            Next
                            dtfinal.Rows.Add(draux)
                        Next
                    End If


                Next

            Catch ex As Exception

            End Try

            Try

                pdtDerivados.DefaultView.RowFilter = "producto_padre = '" & pProducto & "' and empresa = '" & pEmpresa & "'"
                If pdtDerivados.DefaultView.Count > 0 Then

                    For Each drvDerivado As DataRowView In pdtDerivados.DefaultView

                        ls_sql = "pa_var_um_transito_productos_semana_producto '" & drvDerivado.Item("empresa").ToString & "','" & drvDerivado.Item("producto").ToString & "'," & DatePart(DateInterval.WeekOfYear, Date.Parse(pSemana), FirstDayOfWeek.Monday) & "," & Date.Parse(pSemana).Year
                        dt = otrans.Obtiene(ls_sql)


                        Try

                            For Each dr As DataRow In dt.Rows
                                ls_sql = "pa_var_um_transito_productos_orden '" & pEmpresa & "','" & dr.Item("numero") & "'"
                                '  If sencabezado.Length > 0 Then sencabezado += Chr(13)
                                sencabezado += "::No. Orden " & dr.Item("numero") & " -- Fecha " & dr.Item("fecha")
                                dt2 = otrans.Obtiene(ls_sql)

                                For Each draux2 As DataRow In dt2.Rows


                                    If dtfinal Is Nothing Then
                                        dtfinal = dt2.Copy
                                    Else

                                        draux = dtfinal.NewRow
                                        For Each dc As DataColumn In dtfinal.Columns
                                            draux.Item(dc.ColumnName) = draux2.Item(dc.ColumnName)
                                        Next
                                        dtfinal.Rows.Add(draux)
                                    End If
                                Next
                            Next
                        Catch ex As Exception

                        End Try
                    Next
                End If

            Catch ex As Exception

            End Try

            If dtfinal.Rows.Count > 0 Then
                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dtfinal
                ClsGen.Alinear_GridView(dtfinal, oform.dgv_resultado, "", "", "", "", "", "", IIf(lbmultiples, ",numero,producto,", ""), True, True, 250, 0)

                oform.Text = sencabezado
                oform.lblResumenlabel.Visible = True
                Try
                    oform.lblResumenTotal.Visible = True
                    oform.lblResumenTotal.Text = dtfinal.Compute("Sum(Cajas)", "cajas>0")
                Catch ex As Exception

                End Try
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing


            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub mostrarReservas(ByVal sEmpresa As String, ByVal sProducto As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim lsFiltro As String

        Try

            ds_informacion_productos.Tables("reservas").DefaultView.RowFilter = "producto = '" & sProducto & "'"




            If ds_informacion_productos.Tables("reservas").DefaultView.Count > 0 Then

                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("reservas").DefaultView
                ClsGen.Alinear_GridView(ds_informacion_productos.Tables("reservas").DefaultView.ToTable, oform.dgv_resultado, "", "", "", "", "", "", "", True, True, 250, 0)

                oform.Text = "Reservas" ' & sProducto & "-" & ds_informacion_productos.Tables("existencias").DefaultView(0).Item("glosa").ToString
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mostrarInventarioBodegas(ByVal sEmpresa As String, ByVal sProducto As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim lsFiltro As String

        Try

            lsFiltro = "empresa = '" & sEmpresa & "' and (producto = '" & sProducto & "'"
            'If sEmpresa.ToLower = "diuva" Then '(c) 310072014 Solicitud MMeza
            If sEmpresa.ToLower <> "vinoteca" Then '(c) 20210518 muestre todos los inventarios
                lsFiltro = "(producto = '" & sProducto & "'"
            End If
            ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & sProducto & "'"

            For Each drv As DataRowView In ds_informacion_productos.Tables("derivados").DefaultView

                lsFiltro += " OR producto = '" & drv.Item("producto").ToString & "'"
            Next
            lsFiltro += ") and cajas  > 0"



            ds_informacion_productos.Tables("existencias").DefaultView.RowFilter = lsFiltro '"empresa = '" & sEmpresa & "' and (producto = '" & sProducto & "'"
            If ds_informacion_productos.Tables("existencias").DefaultView.Count > 0 Then

                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("existencias").DefaultView
                ClsGen.Alinear_GridView(ds_informacion_productos.Tables("existencias").DefaultView.ToTable, oform.dgv_resultado, "empresa,producto,glosa,bodega,cajas,", "", "", "", "", "", "", True, True, 250, 0)

                oform.Text = "Existencias por Bodega " ' & sProducto & "-" & ds_informacion_productos.Tables("existencias").DefaultView(0).Item("glosa").ToString
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub OcultarColumna(ByVal EsSemana As Boolean, ByVal nombre_campo As String)
        Dim icount As Integer
        'Dim saux As String = MenuItem.Text.Split("'")(1)
        'columnasOcultas += "," + MenuItem.Text.Split(" ")(1)
        If nombre_campo.Length = 0 Then Exit Sub
        Try
            If EsSemana Then
                For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                    If dc.HeaderText.ToLower.IndexOf(" " & nombre_campo.ToLower) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                        icount += 1
                        dc.Visible = False
                        '        columnasOcultas = columnasOcultas.Replace("," & saux, "")
                    End If
                    If icount = 4 Then
                        Exit For
                    End If
                Next
            Else
                Me.dgv_detalle.Columns(nombre_campo).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgv_detalle.Columns(nombre_campo).Visible = False


            End If

        Catch ex As Exception
        End Try


    End Sub

    Private Sub llenarComentarios()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            Me.txtComentarios.Text = String.Empty 'sComentarioOriginal
            lsSQL = "pa_sel_um_inv_pedido_comentario " & nCodigoPedido
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                Me.txtComentarios.AppendText(dr.Item("fecha_grabo").ToString & " " & dr.Item("usuario_grabo").ToString & " " & dr.Item("comentario").ToString & vbCrLf)
            Next


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub


    Private Sub LlenarFiltros()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.ValoresDistinto(ds_informacion_productos.Tables("detalle_productos"), "proveedor".Split(","))
            If dt.Rows.Count > 1 Then
                cmbProveedor.Items.Clear()
                cmbProveedor.Items.Add("-TODOS-")
                For Each dr As DataRow In dt.Rows
                    cmbProveedor.Items.Add(dr.Item("proveedor"))
                Next
                lblProveedor.Visible = True
                cmbProveedor.Visible = True
            Else
                lblProveedor.Visible = False
                cmbProveedor.Visible = False
            End If

            dt = clsgen.ValoresDistinto(ds_informacion_productos.Tables("detalle_productos"), "procedencia".Split(","))
            If dt.Rows.Count > 1 Then
                cmbOrigen.Items.Clear()
                cmbOrigen.Items.Add("-TODOS-")
                For Each dr As DataRow In dt.Rows
                    cmbOrigen.Items.Add(dr.Item("procedencia"))
                Next
                lblOrigen.Visible = True
                cmbOrigen.Visible = True
            Else
                lblOrigen.Visible = False
                cmbOrigen.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub aplicarFiltro()
        Dim lsfiltro As New StringBuilder
        lsfiltro.Append(String.Empty)


        If Not chk_filtro.CheckState = CheckState.Checked Then
            lsfiltro.Append("tiene_compra = true")
        End If

        Try
            If cmbProveedor.Visible = True Then
                If Not cmbProveedor.SelectedItem.StartsWith("-") Then
                    If lsfiltro.ToString.Length > 0 Then lsfiltro.Append(" and ")
                    lsfiltro.Append("proveedor = '" & cmbProveedor.SelectedItem & "'")
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            If cmbOrigen.Visible = True Then
                If Not cmbOrigen.SelectedItem.StartsWith("-") Then
                    If lsfiltro.ToString.Length > 0 Then lsfiltro.Append(" and ")
                    lsfiltro.Append("procedencia = '" & cmbOrigen.SelectedItem & "'")
                End If
            End If
        Catch ex As Exception
        End Try

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = lsfiltro.ToString


    End Sub

    Private Sub mostrarDerivados()
        Dim oform As New frm_resultado
        Dim clsGen As New ClasesGenerales.General



        Try
            oform.Text = "Productos Derivados de " + dgv_detalle.Item("producto", Me.dgv_detalle.CurrentRow.Index).Value + "--" + dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value


            ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value & "'"
            oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("derivados")
            Dim lcolumnasmostrar As String = ",empresa,producto,glosa,unidades,existencia,"

            clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", ",existencia=existencia_unidades,", "", ",empresa,producto,glosa,unidades,", True, True, 250, 0)

            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If dc.Name.ToLower = "unidades" Then
                    dc.DefaultCellStyle.Format = "n4"
                End If
            Next
            With oform.dgv_resultado
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            End With
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing

        Catch ex As Exception
        Finally
            oform = Nothing
        End Try

    End Sub

    Private Sub mostrarPresupuesto()
        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try


            therow = Me.dgv_detalle.CurrentRow
            oCompras.Empresa = dgv_detalle.Item("empresa", therow.Index).Value
            oCompras.mostrarPresupuesto(dgv_detalle.Item("producto", therow.Index).Value,
                                     True)


        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try
    End Sub

    Private Sub mostrarInventarioPorSerie()
        'Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try

            therow = Me.dgv_detalle.CurrentRow
            Dim dt As DataTable
            dt = ds_informacion_productos.Tables("existenciasSerie").Copy
            dt.DefaultView.RowFilter = "producto = '" & dgv_detalle.Item("producto", therow.Index).Value & "'"

            Dim oform As New frm_resultado
            oform.Text = ":: Inventario Por Añada ::"
            Dim clsGen As New ClasesGenerales.General

            Dim lcolumnasmostrar As String = ",producto,bodega,serie,cajas,"

            oform.dgv_resultado.DataSource = dt.DefaultView
            'clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If lcolumnasmostrar.IndexOf(dc.Name.ToLower) < 1 Then
                    dc.Visible = False
                End If
                If dc.Name.ToLower = "cajas" Then
                    dc.DefaultCellStyle.Format = "n2"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If


            Next
            With oform.dgv_resultado
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            End With
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
            clsGen = Nothing
            'End If
        Catch ex As Exception
        Finally
            'oCompras = Nothing
        End Try
    End Sub

    Private Sub mostrarInventarioPorLote()
        'Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try

            therow = Me.dgv_detalle.CurrentRow
            Dim dt As DataTable
            dt = ds_informacion_productos.Tables("existenciasLote").Copy
            dt.DefaultView.RowFilter = "producto = '" & dgv_detalle.Item("producto", therow.Index).Value & "'"

            Dim oform As New frm_resultado
            oform.Text = ":: Inventario Por Lote ::"
            Dim clsGen As New ClasesGenerales.General

            Dim lcolumnasmostrar As String = ",producto,bodega,lote,fechavcto,cajas,"

            oform.dgv_resultado.DataSource = dt.DefaultView
            'clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If lcolumnasmostrar.IndexOf(dc.Name.ToLower) < 1 Then
                    dc.Visible = False
                End If
                If dc.Name.ToLower = "cajas" Then
                    dc.DefaultCellStyle.Format = "n2"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If


            Next
            With oform.dgv_resultado
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            End With
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
            clsGen = Nothing
            'End If
        Catch ex As Exception
        Finally
            'oCompras = Nothing
        End Try
    End Sub


    Private Sub mostrarPresupuestoOriginal()
        'Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try

            therow = Me.dgv_detalle.CurrentRow
            Dim dt As DataTable
            dt = ds_informacion_productos.Tables("presupuesto_mensual").Copy
            dt.DefaultView.RowFilter = "producto = '" & dgv_detalle.Item("producto", therow.Index).Value & "'"

            Dim oform As New frm_resultado
            oform.Text = ":: Presupuesto Mensual ::"
            Dim clsGen As New ClasesGenerales.General

            Dim lcolumnasmostrar As String = ",periodo,producto,glosa,cajas,"

            oform.dgv_resultado.DataSource = dt.DefaultView
            'clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If dc.Name.ToLower = "cajas" Then
                    dc.DefaultCellStyle.Format = "n2"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If


            Next
            With oform.dgv_resultado
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            End With
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
            clsGen = Nothing
            'End If
        Catch ex As Exception
        Finally
            'oCompras = Nothing
        End Try
    End Sub

    Private Function validarRegistrosSanitarios() As Boolean
        Dim valorReturn As Boolean = True
        Try
            For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("Agregar") = True Then

                    If DateTime.Parse(dr.Item("fecha_registro").ToString()) < Today.AddMonths(6) Then

                        If MessageBox.Show("La Fecha de Vencimiento del Registro del Producto " & dr.Item("glosa").ToString & Chr(13) &
                                           " Es " & dr.Item("fecha_registro") & " Desea Continuar ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            ''No cambio el estado
                        Else
                            valorReturn = False
                        End If
                        guardarAvisoRegistro("Compras El Producto " & dr.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido")
                    End If

                End If
            Next

        Catch ex As Exception

        End Try
        Return valorReturn
    End Function

    Private Sub guardarAvisoRegistro(ByVal smensaje As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable

        Try

            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (17)" '17= Registros Sanitarios

            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", smensaje, 17)
            Next


            'lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(17)" '17= Registros Sanitarios
            'dt = myOtrans.Obtiene(lsSQL)



            'For Each dr3 As DataRow In dt3.Rows

            '    guardarAviso = False
            '    Dim lsMensaje As String
            '    lsMensaje = "El Producto " & dr3.Item("producto").ToString.Trim & "-" & dr3.Item("glosa").ToString.Trim

            '    If dr3.Item("registro").ToString.Length = 0 Then
            '        guardarAviso = True
            '        lsMensaje += " No tiene Registro Sanitario, Ingreso en la Dua " & Me.txt_numero.Text
            '    Else
            '        If dr3.Item("Fecha_vencimiento").ToString.Length = 0 Then
            '            guardarAviso = True
            '            lsMensaje += " No tiene Fecha de Vencimiento, Ingreso en la Dua " & Me.txt_numero.Text
            '        Else
            '            Try
            '                If CDate(dr3.Item("Fecha_vencimiento")).Date < Today() Then
            '                    guardarAviso = True
            '                    lsMensaje += " El Registro Ya Vencio, Ingreso en la Dua " & Me.txt_numero.Text
            '                ElseIf CDate(dr3.Item("Fecha_vencimiento")).Date < Today().AddMonths(3) Then
            '                    guardarAviso = True
            '                    lsMensaje += " El Registro Esta Por Vencer, Ingreso en la Dua " & Me.txt_numero.Text
            '                End If
            '            Catch ex As Exception
            '                guardarAviso = True
            '                lsMensaje += " Problemas con la Fecha, Ingreso en la Dua " & Me.txt_numero.Text

            '            End Try

            '        End If
            '    End If


            '    If guardarAviso() Then

            '        For Each dr As DataRow In dt.Rows
            '            If dr.Item("validar_marca").ToString = "1" Then
            '                dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
            '                If dt2.DefaultView.Count > 0 Then guardarAviso = True

            '            ElseIf dr.Item("validar_empresa").ToString = "1" Then

            '                dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
            '                If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True
            '            End If


            '            If guardarAviso() Then

            '                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsMensaje, 17)
            '                guardarAviso = False
            '            End If
            '        Next
            '    End If

            'Next
            'End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub


    Private Sub mostrarPresupuestoOld()
        ''Tengo que levantar una forma en la que se muestre el presupuesto a futuro
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim lssql As String

        Try
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index

            Otrans.open()
            lssql = "pa_sel_um_ppt_presupuesto_general '" & Me.dgv_detalle.Item("empresa", nrow).Value & "',null,'" &
                                                    Me.dgv_detalle.Item("producto", nrow).Value & "'"

            dt = Otrans.Obtiene(lssql)
            dt.Columns.Add(New DataColumn("cajas", GetType(Double)))
            dt.DefaultView.RowFilter = "periodo >= '" & Today.ToString("yyyyMM") & "'"
            dt.DefaultView.Sort = "periodo"

            If dt.DefaultView.Count > 0 Then
                For Each drv As DataRowView In dt.DefaultView
                    drv.Item("cajas") = drv.Item("cantidad") / drv.Item("factoralt")
                Next
                Dim oform As New frm_resultado
                oform.Text = ":: Presupuesto Mensual ::"
                Dim clsGen As New ClasesGenerales.General

                Dim lcolumnasmostrar As String = ",periodo,producto,glosa,cajas,"

                oform.dgv_resultado.DataSource = dt.DefaultView
                clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", True, True, 250, 0)
                For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                    If dc.Name.ToLower = "cajas" Then
                        dc.DefaultCellStyle.Format = "n2"
                        dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If


                Next
                With oform.dgv_resultado
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                End With
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
                clsGen = Nothing
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub modificarPresupuesto(ByVal nporcentaje As Double)

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim dt As DataTable

        dt = ds_informacion_productos.Tables("calculo_original").Copy
        dt.TableName = "detalle_productos"
        If ds_informacion_productos.Tables.Contains("detalle_productos") Then ds_informacion_productos.Tables.Remove("detalle_productos")
        ds_informacion_productos.Tables.Add(dt.Copy)

        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
            '(c) 20200604 si cambian el presupuesto debe mostrarlo en la columna de ajuste
            dr.Item("porcentaje_ajuste") = nporcentaje
            dr.Item("ppto") = dr.Item("ppto") + (dr.Item("ppto") * (nporcentaje / 100))
            For icount As Integer = 1 To 62
                dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) = dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) + (dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) * (nporcentaje / 100))
            Next

        Next

        oCompras.Generar_SaldosyCoberturas(False)

        For iaux As Integer = 0 To piSemanas

            oCompras.Minimos_Maximos(iaux, IIf(iaux = 0, True, False))
            oCompras.Generar_Pedido_Sugerido(iaux, IIf(iaux = 0, True, False))

        Next


        Me.dgv_detalle.DataSource = Nothing
        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
        If Me.chk_filtro.CheckState = CheckState.Checked Then
            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = ""
        Else
            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "tiene_compra = true"
        End If
        Colorear_Detalle(generarForecasting)

        If columnasOcultas.Length > 0 Then
            For Each saux As String In columnasOcultas.Split(",")
                If saux.Length > 0 Then
                    If saux.ToLower.StartsWith("semana") Then
                        OcultarColumna(True, saux.Split("'")(1))
                    Else
                        OcultarColumna(False, saux)
                    End If
                End If
            Next
        End If
        porcentajeAumentoPresupuesto = nporcentaje

        oCompras = Nothing

        Recargar_Resumen()
        Me.lblPresupuesto.Visible = False
        If porcentajeAumentoPresupuesto <> 0 Then
            Me.lblPresupuesto.Text = IIf(porcentajeAumentoPresupuesto > 0, "Aumento ", "Disminucion ") + porcentajeAumentoPresupuesto.ToString + " %"
            Me.lblPresupuesto.Visible = True
        End If

    End Sub

    Private Sub modificarPresupuestoProducto(ByVal sempresa As String, ByVal sproducto As String, ByVal dporcentaje As Double)

        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
            If dr.Item("empresa") = sempresa And dr.Item("producto") = sproducto Then


                dr.Item("ppto") = dr.Item("ppto") + (dr.Item("ppto") * (dporcentaje / 100))
                For icount As Integer = 1 To 62
                    dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) = dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) + (dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) * (dporcentaje / 100))
                Next
                Exit For
            End If

        Next
    End Sub

    Private Sub modificarFechaIngreso()
        '(c)

        Dim dfecha As DateTime
        Try
            Dim sfecha As String = InputBox("Ingrese Nueva Fecha de Ingreso en formato dd/mm/yyyy", "Fecha de Orden")
            If sfecha.Length > 0 Then

                dfecha = DateTime.Parse(sfecha)
                If dfecha < Today Then
                    MessageBox.Show("No Puede Asignar esta fecha", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim isemana As Integer = DatePart(DateInterval.WeekOfYear, dfecha, FirstDayOfWeek.Monday)
                Dim nsemana As Integer
                Dim ntotalSemanas As Integer


                If isemana < psemana And DateTime.Parse(dfecha).Year = Today.Year Then
                    nsemana = 0
                Else
                    nsemana = isemana - psemana
                End If
                If dfecha.Year = Today.Year Then
                    ntotalSemanas = DatePart(DateInterval.WeekOfYear, Date.Parse("01/01/" & Today.Year + 1).AddDays(-1), FirstDayOfWeek.Monday)
                Else
                    ntotalSemanas = 52
                End If


                Dim ls_mes As String

                If nsemana < 0 Then nsemana += ntotalSemanas
                ls_mes = "transito"
                If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")



                Dim ntransitoactual As Integer
                Dim colIndex, rowIndex As Integer
                colIndex = Me.dgv_detalle.CurrentCell.ColumnIndex
                rowIndex = Me.dgv_detalle.CurrentCell.RowIndex
                ntransitoactual = Me.dgv_detalle.Item(Me.dgv_detalle.CurrentCell.ColumnIndex, Me.dgv_detalle.CurrentCell.RowIndex).Value
                'ntransito = IIf(dr.Item("CantidadArriboPuerto") Is System.DBNull.Value, dr.Item("cajas_pedidas"), dr.Item("cantidadArriboPuerto"))
                'drv.Item(ls_mes) += ntransito

                Me.dgv_detalle.Item(colIndex, rowIndex).Value = 0
                Me.dgv_detalle.Item(ls_mes, Me.dgv_detalle.CurrentCell.RowIndex).Value = ntransitoactual

                'Me.AplicarProducto(Me.dgv_detalle.Item("empresa", rowIndex).Value, _
                'Me.dgv_detalle.Item("producto", rowIndex).Value, _
                'dgv_detalle.Columns(colIndex).Name.ToLower, _
                ''0, _
                ' False)

                Dim oCompras As New Compras.SCM(ds_informacion_productos)
                Try
                    oCompras.Generar_SaldosyCoberturasProducto(Me.dgv_detalle.Item("producto", rowIndex).Value)
                Catch ex As Exception
                Finally
                    oCompras = Nothing
                    Recargar_Resumen()
                End Try

                dgv_detalle.CurrentCell = dgv_detalle.Item(colIndex, rowIndex)
                Me.Btn_Guardar.Enabled = False
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Me.timer_orden.Enabled = False
        Me.dgv_detalle.DataSource = Nothing
        Me.dgv_resumen.DataSource = Nothing
        Dim dt As DataTable
        Me.txtComentarios.Text = String.Empty
        psNombreCalculo = String.Empty
        nCodigoPedido = 0
        generarForecasting = False 'Cuando se genera debe reiniciar forecasting
        Me.lblPresupuestoAlterno.Visible = False

        ''Me.Refresh()
        ''Verifico Calculos Previos

        snombreCalculo = InputBox("Ingrese Nombre De Calculo", "Nombre", psNombreCalculo)
        If snombreCalculo.Length > 0 Then
            Me.Text = "::.SCM - Generar Pedido - " & snombreCalculo & " .:: "
        Else
            Me.Text = "::.SCM - Generar Pedido  .::"
        End If
        Try
            If ds_informacion_productos.Tables.Contains("detalle_productos") Then
                If ds_informacion_productos.Tables("detalle_productos").Rows.Count > 0 Then
                    If MessageBox.Show("Desea Limpiar Informacion Previa", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        dt = ds_informacion_productos.Tables("detalle_productos").Copy
                    Else
                        Me.lblPresupuesto.Visible = False
                        Me.lblPresupuesto.Text = String.Empty
                    End If
                Else
                    Me.lblPresupuesto.Visible = False
                    Me.lblPresupuesto.Text = String.Empty
                End If
            End If

        Catch ex As Exception

        End Try

        ds_informacion_productos = New DataSet

        '(c) 20240320
        'Limpiar pedidos autoguardados antiguos

        Try

            Dim ls_path As String


            Dim proceso As Process = New Process
            ls_path = "C:\Aplicaciones\Compras\autosave"

            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "limpiar_historico.bat"

            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()
            proceso = Nothing



        Catch ex As Exception
            Escribir_log(ex.Message.ToString)
        End Try

        Dim oform As New frm_scm_preparacion_informacion(ds_informacion_productos)
        Try
            oform.dtCalculoPrevio = dt.Copy
        Catch ex As Exception

        End Try

        oform.ShowDialog()

        pGenerarTodasLasEmpresas = oform.chk_generar_global.Checked

        piSemanas = oform.NuPSemanasReorden.Value
        pbGenerarProyeccion = oform.chkProyeccion.Checked
        pbBodegasExtras = oform.chkTiendas.Checked
        Me.lblPresupuestoAlterno.Visible = oform.chkPresupuestoAlterno.Checked
        oform = Nothing
        pfechaCalculo = Now
        dt = ds_informacion_productos.Tables("detalle_productos").Copy

        dt.TableName = "calculo_original"
        If ds_informacion_productos.Tables.Contains("calculo_original") Then ds_informacion_productos.Tables.Remove("calculo_original")

        ds_informacion_productos.Tables.Add(dt.Copy)

        'Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
        'Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")


        Dim clsGen As New ClasesGenerales.General

        Dim smes_actual As String
        Try
            For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows

                Try
                    smes_actual = "cobertura+" & Integer.Parse(dr.Item("pv_lead_time_total")).ToString.PadLeft(2, "0")
                    'dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")
                    'smes_actual = "cobertura+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                    dr.Item("cobertura_pedido") = dr.Item(smes_actual)
                Catch ex As Exception
                    clsGen.Escribir_Log(ex.Message)
                    clsGen.Escribir_Log(ex.ToString)
                    clsGen.Escribir_Log(dr.Item("producto").ToString)
                End Try
                'pv_lead_time_total()

            Next
        Catch ex As Exception

        End Try


        'If Not Me.Btn_Aplicar_sugerido.Visible Then


        If Not pGenerarTodasLasEmpresas Then
            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "tiene_compra = true"
            For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_productos").DefaultView
                If drv.Item("sugerido") > 0 Or drv.Item("sugerido+01") > 0 Then
                    drv.Item("agregar") = True
                    AplicarProducto(drv.Item("empresa").ToString, drv.Item("producto").ToString, "agregar", 0, True, False)
                End If
            Next
        End If

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = ""
        If pbGenerarProyeccion Then
            Dim oCompras As New Compras.SCM(ds_informacion_productos)

            piSemanas = 30 'Semanas a Mostrar
            Dim ldLeadTime, ldCicloCompra, ldCicloPago, ldValorTransito As Double
            Dim liTransito As Integer
            Dim lsSugerido As String

            For iCount As Integer = 1 To 12 ''Realizara 12 Repeticiones por cada producto
                oCompras.Minimos_MaximosSemana(iCount, True)
                oCompras.Generar_Pedido_Sugerido_Semana(iCount, True)

                For Each dr2 As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
                    ldCicloCompra = Double.Parse(dr2.Item("pv_ciclo_compra").ToString) * iCount
                    If ldCicloCompra < 53 Then
                        lsSugerido = "sugerido+" & ldCicloCompra.ToString.PadLeft(2, "0")
                        If dr2.Item(lsSugerido) > 0 Then
                            ldLeadTime = dr2.Item("pv_lead_time_total") + ldCicloCompra
                            ldCicloPago = dr2.Item("pv_ciclo_pago") + ldCicloCompra
                            liTransito = 0
                            ldValorTransito = 0
                            '  dt = transitoProductoSemana(dr2.Item("empresa"), dr2.Item("producto"), _
                            '     DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(ldLeadTime * 7), FirstDayOfWeek.Monday))
                            'Try
                            'liTransito = dt.Compute("cajas", "cajas > 0")
                            'ldValorTransito = dt.Compute("valor", "cajas > 0")
                            'Catch ex As Exception
                            'End Try

                            'If liTransito Then

                            Try
                                liTransito = liTransito '+ dr2.Item(lsSugerido)
                            Catch ex As Exception

                            End Try
                            smes_actual = "transito+" & Integer.Parse(ldLeadTime).ToString.PadLeft(2, "0")
                            dr2.Item(smes_actual) = dr2.Item(lsSugerido)

                            smes_actual = "valor_transito+" & Integer.Parse(ldCicloPago).ToString.PadLeft(2, "0")

                            Try
                                dr2.Item(smes_actual) = Double.Parse(dr2.Item(lsSugerido).ToString) * Double.Parse(dr2.Item("fob").ToString())
                            Catch ex As Exception
                            End Try

                            dr2.Item("agregar") = True
                            oCompras.Generar_SaldosyCoberturasProducto(dr2.Item("producto"))
                        End If
                    End If
                Next

            Next

            oCompras.generarResumenProyeccion()
            oCompras = Nothing
        End If
        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
        'Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "tiene_compra = true"
        'ds_informacion_productos.Tables("resumen").DefaultView.RowFilter = ""

        Colorear_Detalle(False)
        'Colorear_DetalleNew()
        Recargar_Resumen()

        LlenarFiltros()
        Me.Btn_Guardar.Enabled = True
        Me.timer_orden.Enabled = True

    End Sub

    Private Function transitoProductoSemana(ByVal psEmpresa As String, ByVal psProducto As String, ByVal psemana As Integer) As DataTable

        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2, dtfinal As DataTable
        Dim draux As DataRow
        Dim ls_sql, sencabezado As String
        sencabezado = String.Empty
        Dim lbmultiples As Boolean = False

        Try
            otrans.open()
            ls_sql = "pa_var_um_transito_productos_semana_producto '" & psEmpresa & "','" & psProducto & "'," & DatePart(DateInterval.WeekOfYear, Date.Parse(psemana), FirstDayOfWeek.Monday) & "," & Date.Parse(psemana).Year
            dt = otrans.Obtiene(ls_sql)
            For Each dr As DataRow In dt.Rows
                ls_sql = "pa_var_um_transito_productos_orden '" & psEmpresa & "','" & dr.Item("numero") & "'"
                '  If sencabezado.Length > 0 Then sencabezado += Chr(13)
                'sencabezado += "::No. Orden " & dr.Item("numero") & " -- Fecha " & dr.Item("fecha")
                dt2 = otrans.Obtiene(ls_sql)
                If dtfinal Is Nothing Then
                    dtfinal = dt2.Copy
                Else
                    lbmultiples = True
                    For Each draux2 As DataRow In dt2.Rows


                        draux = dtfinal.NewRow
                        For Each dc As DataColumn In dtfinal.Columns
                            draux.Item(dc.ColumnName) = draux2.Item(dc.ColumnName)
                        Next
                        dtfinal.Rows.Add(draux)
                    Next
                End If


            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return dtfinal

    End Function

    Private Function establecerCantidad(ByRef dr As DataRow, ByVal ncantidad As Integer) As Integer
        Dim ldpedido As Double

        Dim ipedido_sugerido As Integer = ncantidad
        If dr("full").ToString().ToLower().Equals("pallet") Then
            Dim ipallet As Integer = 0
            Dim icajasxpallet As Integer
            Dim dpallet As Double

            icajasxpallet = Integer.Parse(dr("cajasxpallet").ToString())
            icajasxpallet = icajasxpallet * Integer.Parse(dr("minimo_compra").ToString())
            If (icajasxpallet < 1) Then icajasxpallet = 1

            dpallet = ipedido_sugerido / icajasxpallet
            ipallet = System.Convert.ToInt32(dpallet)
            If (ipallet - dpallet > 0.5) Then ipallet += 1

            ldpedido = ipallet * icajasxpallet '; //ipedido_sugerido

        ElseIf dr("full").ToString().ToLower().Equals("layer") Then

            Dim ilayer As Integer = 0
            Dim icajasxlayer As Integer
            Dim dlayer As Double

            icajasxlayer = Integer.Parse(dr("cajasxlayer").ToString())
            icajasxlayer = icajasxlayer * Integer.Parse(dr("minimo_compra").ToString())
            If (icajasxlayer < 1) Then icajasxlayer = 1 '//Cuando trae 0, por q la division por 0 da error 130110 (c)

            dlayer = ipedido_sugerido / icajasxlayer
            ilayer = System.Convert.ToInt32(dlayer)

            If (ilayer - ilayer > 0.5) Then ilayer += 1

            ldpedido = ilayer * icajasxlayer '; //ipedido_sugerido;
            dr("pedido") = ldpedido


        Else
            Dim iminimo_compra As Integer = Integer.Parse(dr("minimo_compra").ToString())

            If iminimo_compra > 0 Then

                'If (ipedido_sugerido >= iminimo_compra) Then
                '    dr("pedido") = ipedido_sugerido
                '    ldpedido = dr("pedido")
                'Else
                Dim ilayer As Integer = 0
                Dim icajasxlayer As Integer
                Dim dlayer As Double
                dlayer = ipedido_sugerido / iminimo_compra
                ilayer = System.Convert.ToInt32(dlayer)

                'If (ilayer - dlayer < 0.51) Then
                If ilayer > 0 Then
                    dr("pedido") = iminimo_compra * ilayer
                    ldpedido = dr("pedido") 'iminimo_compra * ilayer
                Else
                    dr("pedido") = 0
                    ldpedido = 0
                End If
                'End If
            Else

                dr("pedido") = ipedido_sugerido
                ldpedido = dr("pedido")

            End If
        End If


        'tomas


        Return ldpedido
    End Function

    Private Sub AplicarProducto(ByVal psEmpresa As String, ByVal psProducto As String, ByVal pscolumnaCambio As String, ByVal ncantidad As Integer, ByVal clickAgregar As Boolean,
                                pbRecargarResumen As Boolean)
        Dim dr As DataRow
        Dim smes_actual As String
        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim dt As DataTable
        Dim ldporcentajeAjuste As Double = 0
        Dim dsugerido() As Double
        ReDim dsugerido(piSemanas)
        Dim ldLeadTime As Double
        Dim ileadtime As Integer

        Try
            Me.Cursor = Cursors.WaitCursor


            'dt = ds_informacion_productos.Tables("calculo_original").Copy
            'dt.TableName = "copia"
            For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then
                    ds_informacion_productos.Tables("calculo_original").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"


                    For iaux As Integer = 0 To piSemanas - 1
                        smes_actual = "sugerido"
                        If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                        dsugerido(iaux) = dr.Item(smes_actual)
                    Next
                    Dim lbagregar As Boolean = dr.Item("agregar")

                    Dim ldpedido As Double = IIf(ncantidad = -99, dr.Item("pedido"), ncantidad)

                    If ncantidad > 0 Then
                        ldpedido = establecerCantidad(dr, ncantidad)
                    End If

                    Dim itransito As Integer = 0
                    ldporcentajeAjuste = dr.Item("porcentaje_ajuste")
                    ldLeadTime = dr.Item("pv_lead_time_total")
                    For Each dc As DataColumn In ds_informacion_productos.Tables("detalle_productos").Columns
                        dr.Item(dc.ColumnName) = ds_informacion_productos.Tables("calculo_original").DefaultView(0)(dc.ColumnName)
                    Next

                    dr.Item("porcentaje_ajuste") = ldporcentajeAjuste

                    If pscolumnaCambio.Equals("porcentaje_ajuste") Then
                        modificarPresupuestoProducto(dr.Item("empresa"), dr.Item("producto"), dr.Item("porcentaje_ajuste"))
                    Else
                        If Not lbagregar Then
                            dr.Item("pedido") = 0
                        End If

                        ileadtime = dr.Item("pv_lead_time_total")
                        dt = Me.transitoProductoSemana(dr.Item("empresa"), dr.Item("producto"), DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(ileadtime * 7), FirstDayOfWeek.Monday))
                        'pa_var_um_transito_productos_semana_producto()
                        Try
                            'If dt.Rows.Count > 0 Then
                            itransito = dt.Compute("cajas", "cajas>0")
                            'End If
                        Catch ex As Exception
                        End Try

                        smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                        dr.Item(smes_actual) = itransito 'dr.Item(smes_actual) + dr.Item("pedido")



                        dr.Item("agregar") = lbagregar



                        If dr.Item("Agregar").ToString.ToLower = "true" Then
                            dr.Item("Agregar") = "True"
                            dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ldpedido)
                            'Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
                            If dr.Item("pedido") = 0 Then
                                For iaux As Integer = 0 To piSemanas - 1
                                    smes_actual = "sugerido"
                                    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                                    If dr.Item(smes_actual) > 0 Then

                                        ldpedido = establecerCantidad(dr, dr.Item(smes_actual))
                                        dr.Item("pedido") = ldpedido
                                        'dr.Item("pedido") = dr.Item(smes_actual)
                                        Exit For

                                    End If
                                    'dr.Item(smes_actual) = dsugerido(iaux)
                                Next
                            End If

                            smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                            dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")

                        End If

                        dr.Item("valor_sugerido") = dr.Item("pedido") * dr.Item("fob")
                        dr.Item("peso_total") = dr.Item("pedido") * dr.Item("peso")
                        dr.Item("volumen_total") = dr.Item("pedido") * dr.Item("volumen")

                    End If

                    Exit For

                End If
            Next

            oCompras.Generar_SaldosyCoberturasProducto(psProducto)
            smes_actual = "cobertura+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
            dr.Item("cobertura_pedido") = dr.Item(smes_actual)

            If pscolumnaCambio.Equals("porcentaje_ajuste") Or pscolumnaCambio.Equals("pv_lead_time_total") Then
                For iaux As Integer = 0 To piSemanas
                    If pscolumnaCambio.Equals("porcentaje_ajuste") Then
                        oCompras.Minimos_MaximosProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                    End If
                    oCompras.generarPedidoSugeridoProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                Next
            End If

            If pbRecargarResumen Then Recargar_Resumen()
        Catch ex As Exception
        Finally
            oCompras = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub AplicarProducto_new(ByVal psEmpresa As String, ByVal psProducto As String, ByVal pscolumnaCambio As String, ByVal ncantidad As Integer, ByVal clickAgregar As Boolean,
                                pbRecargarResumen As Boolean)
        Dim dr As DataRow
        Dim smes_actual As String
        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim dt As DataTable
        Dim ldporcentajeAjuste As Double = 0
        Dim dsugerido() As Double
        ReDim dsugerido(piSemanas)
        Dim ldLeadTime As Double
        Dim ileadtime As Integer
        Dim ldpedido As Double
        Dim lbagregar As Boolean
        Dim itransito As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor


            'dt = ds_informacion_productos.Tables("calculo_original").Copy
            'dt.TableName = "copia"
            For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then
                    ds_informacion_productos.Tables("calculo_original").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"


                    For iaux As Integer = 0 To piSemanas - 1
                        smes_actual = "sugerido"
                        If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                        dsugerido(iaux) = dr.Item(smes_actual)
                    Next
                    lbagregar = dr.Item("agregar")

                    ldpedido = IIf(ncantidad = -99, dr.Item("pedido"), ncantidad)

                    If ncantidad > 0 Then
                        ldpedido = establecerCantidad(dr, ncantidad)
                    End If


                    ldporcentajeAjuste = dr.Item("porcentaje_ajuste")
                    ldLeadTime = dr.Item("pv_lead_time_total")
                    For Each dc As DataColumn In ds_informacion_productos.Tables("detalle_productos").Columns
                        dr.Item(dc.ColumnName) = ds_informacion_productos.Tables("calculo_original").DefaultView(0)(dc.ColumnName)
                    Next

                    dr.Item("porcentaje_ajuste") = ldporcentajeAjuste

                    '(c) 20200604 Si el porcentaje Ajuste tiene valor siempre debe modificar el presupuesto
                    If ldporcentajeAjuste <> 0 Or pscolumnaCambio.Equals("porcentaje_ajuste") Then
                        modificarPresupuestoProducto(dr.Item("empresa"), dr.Item("producto"), dr.Item("porcentaje_ajuste"))
                    End If


                    '(c) 20200604 Si el porcentaje Ajuste tiene valor siempre debe modificar el presupuesto

                    'If pscolumnaCambio.Equals("porcentaje_ajuste") Then
                    'modificarPresupuestoProducto(dr.Item("empresa"), dr.Item("producto"), dr.Item("porcentaje_ajuste"))

                    If False Then
                    Else
                        If Not lbagregar Then
                            dr.Item("pedido") = 0
                        End If

                        ileadtime = dr.Item("pv_lead_time_total")
                        dt = Me.transitoProductoSemana(dr.Item("empresa"), dr.Item("producto"), DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(ileadtime * 7), FirstDayOfWeek.Monday))
                        'pa_var_um_transito_productos_semana_producto()
                        Try
                            'If dt.Rows.Count > 0 Then
                            itransito = dt.Compute("cajas", "cajas>0")
                            'End If
                        Catch ex As Exception
                        End Try

                        smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                        dr.Item(smes_actual) = itransito 'dr.Item(smes_actual) + dr.Item("pedido")



                        dr.Item("agregar") = lbagregar



                        If dr.Item("Agregar").ToString.ToLower = "true" Then
                            dr.Item("Agregar") = "True"
                            '(c) 20200604
                            'dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ldpedido)

                            dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ncantidad)

                            'Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
                            '(c)20200604
                            If dr.Item("pedido") <= 0 Then
                                'If dr.Item("pedido") = 0 Or ldporcentajeAjuste <> 0 Or pscolumnaCambio.Equals("porcentaje_ajuste") Then
                                For iaux As Integer = 0 To piSemanas - 1
                                    smes_actual = "sugerido"
                                    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                                    If dr.Item(smes_actual) > 0 Then

                                        ldpedido = establecerCantidad(dr, dr.Item(smes_actual))
                                        dr.Item("pedido") = ldpedido
                                        'dr.Item("pedido") = dr.Item(smes_actual)}
                                        '(c) 20200604, si no lleva cantidad no debe agregar el pedido
                                        lbagregar = False
                                        If ldpedido = 0 Then
                                            dr.Item("Agregar") = lbagregar
                                        End If
                                        Exit For

                                    End If
                                    'dr.Item(smes_actual) = dsugerido(iaux)
                                Next
                            End If


                            smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                            'dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")
                            '(c) 20200604
                            dr.Item(smes_actual) = itransito + dr.Item("pedido")

                        End If


                        dr.Item("valor_sugerido") = dr.Item("pedido") * dr.Item("fob")
                        dr.Item("peso_total") = dr.Item("pedido") * dr.Item("peso")
                        dr.Item("volumen_total") = dr.Item("pedido") * dr.Item("volumen")

                    End If

                    Exit For

                End If
            Next

            'Verificar que ese nuevo saldo y cobertura funcione porque esta afuera de for


            oCompras.Generar_SaldosyCoberturasProducto(psProducto)
            smes_actual = "cobertura+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")

            '(c) 20200604 se hizo nuevamente el for para poner dentro el dr
            For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then
                    dr.Item("cobertura_pedido") = dr.Item(smes_actual)

                    Exit For
                End If
            Next

            If pscolumnaCambio.Equals("porcentaje_ajuste") Or pscolumnaCambio.Equals("pv_lead_time_total") _
                Or ldporcentajeAjuste <> 0 Then

                '(c) 20200604 lo calculo porque cambian los minimos y maximos

                oCompras.Generar_SaldosyCoberturasProducto(psProducto)

                For iaux As Integer = 0 To piSemanas
                    If pscolumnaCambio.Equals("porcentaje_ajuste") Or ldporcentajeAjuste <> 0 Then
                        oCompras.Minimos_MaximosProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                    End If

                    oCompras.generarPedidoSugeridoProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                Next



                smes_actual = "cobertura+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")

                '(c) 20200604 se hizo nuevamente el for para poner dentro el dr
                For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                    If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then


                        dr.Item("cobertura_pedido") = dr.Item(smes_actual)

                        '(c) 20200604
                        'If dr.Item("Agregar").ToString.ToLower = "true" Then
                        If True Then
                            dr.Item("Agregar") = lbagregar

                            dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ncantidad)
                            'dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ldpedido)
                            'Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
                            '(c)20200604
                            If dr.Item("pedido") <= 0 Then
                                dr.Item("pedido") = 0
                                lbagregar = False
                                If ldpedido = 0 Then
                                    dr.Item("Agregar") = lbagregar
                                End If
                                'If dr.Item("pedido") = 0 Or ldporcentajeAjuste <> 0 Or pscolumnaCambio.Equals("porcentaje_ajuste") Then
                                For iaux As Integer = 0 To piSemanas - 1
                                    smes_actual = "sugerido"
                                    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                                    If dr.Item(smes_actual) > 0 Then

                                        ldpedido = establecerCantidad(dr, dr.Item(smes_actual))
                                        dr.Item("pedido") = ldpedido
                                        'dr.Item("pedido") = dr.Item(smes_actual)}
                                        '(c) 20200604, si no lleva cantidad no debe agregar el pedido
                                        If ldpedido = 0 Then
                                            lbagregar = False

                                        Else
                                            lbagregar = True

                                        End If
                                        dr.Item("Agregar") = lbagregar

                                        Exit For

                                    End If
                                    'dr.Item(smes_actual) = dsugerido(iaux)
                                Next
                            End If


                            smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                            '(c) 20200604
                            'dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")
                            dr.Item(smes_actual) = itransito + dr.Item("pedido")


                        End If

                        dr.Item("valor_sugerido") = dr.Item("pedido") * dr.Item("fob")
                        dr.Item("peso_total") = dr.Item("pedido") * dr.Item("peso")
                        dr.Item("volumen_total") = dr.Item("pedido") * dr.Item("volumen")
                        Exit For
                    End If
                Next

            End If

            oCompras.Generar_SaldosyCoberturasProducto(psProducto)
            smes_actual = "cobertura+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")

            '(c) 20200604 se hizo nuevamente el for para poner dentro el dr
            For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then


                    dr.Item("cobertura_pedido") = dr.Item(smes_actual)
                    Exit For
                End If
            Next


            If pbRecargarResumen Then Recargar_Resumen()
        Catch ex As Exception
            Escribir_log(ex.ToString)
        Finally
            oCompras = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub agregarComentario(Optional ByVal psComentario As String = "Ingrese Comentario de Pedido")


        Dim scomentario As String = String.Empty
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Try
            Otrans.open()
            scomentario = InputBox(psComentario, "Comentarios")
            If scomentario.Length > 250 Or scomentario.Length = 0 Then
                MessageBox.Show("Problemas con el Comentario " & IIf(scomentario.Length = 0, " ", " Sobrepaso los 75 Caracteres"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If

            lsSQL = "pa_ins_um_inv_pedido_comentarios " & nCodigoPedido & ",'" & gs_usuario & "','" & scomentario & "'"
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error > 0 Then
                MessageBox.Show("Problemas al Ingresar el Comentario", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Comentario Ingresado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            llenarComentarios()
        End Try



    End Sub


    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        If MessageBox.Show("Esta Seguro De Guardar Calculo", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If validarRegistrosSanitarios() Then
                '(c) 20160714 Sobreescribir el calculo Original
                If nCodigoPedido > 0 Then
                    If MessageBox.Show("Desea SobreEscribir el Calculo Original", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        modificarCalculo()
                    Else
                        Guardar_Calculo()
                    End If
                Else
                    Guardar_Calculo()
                End If
                ''Guardar_Calculo()
            End If
        End If
    End Sub

    Private Sub Btn_Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar.Click



        Dim Oaut As New Automatizar.exportar_excel

        Dim socultarColumnas As New StringBuilder
        Dim snombreColumnas As New StringBuilder


        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

        Oaut.Nombre_Columnas = ",,,,,,,,,,,,,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns
            If Me.pbGenerarProyeccion Then
                If dc.Name.ToLower.StartsWith("ppto+") Or dc.Name.ToLower.StartsWith("cobertura+") Then
                    dc.Visible = False
                End If
            End If
            If Not dc.Visible Then socultarColumnas.Append("," & dc.Name.ToLower)
            If dc.Visible Then snombreColumnas.Append("," & dc.HeaderText.ToLower)
        Next
        socultarColumnas.Append(",")
        snombreColumnas.Append(",")
        Oaut.ocultar_columnas = socultarColumnas.ToString
        Oaut.Nombre_Columnas = snombreColumnas.ToString

        Oaut.sTitulo = psNombreCalculo
        Oaut.sgPiePagina = Me.txtComentarios.Text
        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ds_informacion_productos.Tables("detalle_productos").DefaultView.ToTable)
        Oaut = Nothing
    End Sub

    Private Sub Btn_Aplicar_sugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aplicar_sugerido.Click

        ds_informacion_productos = New DataSet

        Dim ocompras As Compras.SCM = New Compras.SCM(ds_informacion_productos)


        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql, ls_mes As String
        Dim nsemana As String
        Dim ntotalSemanas As Integer
        Dim ntransito As Integer
        Dim saux As String


        otrans.open()

        'ocompras.Empresa = gs_empresa 'Se Habilita para Generar Por Empresa
        ocompras.Crear_Estructura()
        ocompras.SetProductoLimite(IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000"))

        pfechaCalculo = Now

        ocompras.Inicializar_Productos(False, False, False, False)
        ocompras.Revisar_productoDerivados("detalle_productos")
        ocompras.generarExistencia(True, pbBodegasExtras)
        ocompras.generarTransitos(DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday), "", True)
        ocompras.generarPresupuestos(DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday), "", True)

        'ocompras.generarResumen()
        ocompras.generarResumenEmpresa()
        ocompras.generarResumenTotal()

        ocompras.Generar_SaldosyCoberturasResumenTotal("ResumenTotal")
        ocompras.Generar_SaldosyCoberturasResumenTotal("ResumenPareto")
        ocompras.Generar_SaldosyCoberturasResumenTotal("ResumenEmpresa")
        ocompras.Generar_SaldosyCoberturasResumenTotal("ResumenEmpresaPareto")

        ocompras.Generar_SaldosyCoberturasResumenTotal("detalle_productos")

        ds_informacion_productos.Tables("detalle_productos").WriteXml("c:\temp\empresas" & Today.ToString("ddMMyyyy") & ".xml")

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = ""
        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
        'Me.Colorear_Detalle()

        For Each drempresa As DataRow In ds_informacion_productos.Tables("ResumenEmpresa").Rows

            Me.graficarCoberturasEmpresa(drempresa)
        Next
        ' Me.graficarCoberturasCorporativo()

        ds_informacion_productos.Tables("ResumenEmpresa").WriteXml("c:\temp\empresas" & Today.ToString("ddMMyyyy") & ".xml")
        ds_informacion_productos.Tables("ResumenEmpresaPareto").WriteXml("c:\temp\empresas" & Today.ToString("ddMMyyyy") & ".xml")

        Me.graficarCoberturasCorporativo()


        Me.dgv_resumen.DataSource = Nothing
        Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("ResumenPareto")


    End Sub

    Private Sub graficarCoberturasEmpresa(ByVal pdr As DataRow)

        Dim i, nrow As Integer
        Dim ncolumn As Integer = -1
        Dim coberturas, saldos, saldosHistoricos, saldosA, saldosB, saldosC, saldosD As Double(,)

        Dim nombre_productos As String()
        Dim periodos As String()


        ReDim nombre_productos(1)


        ReDim coberturas(7, 20)
        ReDim saldos(7, 20), saldosA(7, 20), saldosB(7, 20), saldosC(7, 20), saldosD(7, 20)
        ReDim saldosHistoricos(7, 20)


        ReDim periodos(20)
        Dim oCompras As New Compras.SCM
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As New StringBuilder
        Dim lsSQLCobertura As New StringBuilder
        lsSQL.Append("pa_ins_um_scm_saldo_empresa '").Append(pdr.Item("empresa").ToString).Append("','")
        lsSQL.Append(pfechaCalculo.ToString("dd-MM-yyyy")).Append("'")

        lsSQLCobertura.Append("pa_ins_um_scm_coberturas_empresa '").Append(pdr.Item("empresa").ToString).Append("','")
        lsSQLCobertura.Append(pfechaCalculo.ToString("dd-MM-yyyy")).Append("'")

        Try
            Otrans.open()

            pfechaCalculo = Today
            'dr = ds_informacion_productos.Tables("ResumenTotal").Rows(0)

            Dim dt2 As DataTable = Otrans.Obtiene("pa_sel_um_scm_saldos_empresa '" & pdr.Item("empresa").ToString & "'") 'Select * from scm_saldos_empresa ")

            nombre_productos(i) = pdr.Item("empresa").ToString.ToUpper 'gs_empresa  ' dgv_detalle.Item("glosa", dgv_detalle.SelectedCells(i).RowIndex).Value.ToString
            saldos(7, 0) = 10 'Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
            saldos(6, 0) = 6 'Me.dgv_detalle.Item("pv_inv_reorden", nrow).Value.ToString
            coberturas(i, 0) = Math.Round(Double.Parse(pdr.Item("cobertura").ToString), 0)
            periodos(0) = pfechaCalculo.ToString("dd-MMM-yyyy")
            saldos(i, 0) = Math.Round(pdr.Item("saldo")) 'Math.Round(Double.Parse(dgv_detalle.Item("Saldo", nrow).Value.ToString), 0)
            lsSQL.Append(",").Append(saldos(i, 0))
            lsSQLCobertura.Append(",").Append(coberturas(i, 0))
            For Each dr2 As DataRow In dt2.Rows
                saldosHistoricos(i, 0) = saldosHistoricos(i, 0) + Math.Round(Double.Parse(dr2.Item("saldo_01").ToString), 0)
            Next

            For icount As Integer = 1 To 20
                coberturas(i, icount) = Math.Round(Double.Parse(pdr.Item("cobertura+" + icount.ToString.PadLeft(2, "0"))), 0)
                saldos(i, icount) = Math.Round(Double.Parse(pdr.Item("saldo+" + icount.ToString.PadLeft(2, "0")).ToString), 0)
                lsSQL.Append(",").Append(saldos(i, icount))
                lsSQLCobertura.Append(",").Append(coberturas(i, icount))
                periodos(icount) = pfechaCalculo.AddDays(icount * 7).ToString("dd-MMM-yyyy") '"cobertura+" + icount.ToString.PadLeft(2, "0") ' Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
                saldos(6, icount) = 6 'dr.Item("pv_inv_reorden").Value.ToString
                saldos(7, icount) = 10 'dr.Item("pv_inv_maximo").Value.ToString
                If icount < 20 Then
                    For Each dr2 As DataRow In dt2.Rows
                        Try
                            saldosHistoricos(i, icount) += Math.Round(Double.Parse(dr2.Item("saldo_" + (icount + 1).ToString.PadLeft(2, "0")).ToString), 0)
                        Catch ex As Exception
                        End Try
                    Next
                End If
            Next

            Otrans.Ingresa(lsSQL.ToString)
            Otrans.Ingresa(lsSQLCobertura.ToString)

            'Saldos Pareto
            'lsSQL = New StringBuilder
            'lsSQL.Append("pa_ins_um_scm_saldo_empresa_pareto '").Append(pdr.Item("empresa").ToString).Append("','")
            'lsSQL.Append(pfechaCalculo.ToString("dd-MMM-yyyy")).Append("'")

            ds_informacion_productos.Tables("ResumenEmpresaPareto").DefaultView.RowFilter = "empresa = '" & pdr.Item("empresa").ToString & "'"
            For Each drv As DataRowView In ds_informacion_productos.Tables("ResumenEmpresaPareto").DefaultView
                For icount As Integer = 0 To 20
                    Dim snombrecampo As String = "saldo"
                    If icount > 0 Then snombrecampo += "+" + icount.ToString.PadLeft(2, "0")

                    If drv.Item("pareto") = "A" Then
                        saldosA(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "B" Then
                        saldosB(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "C" Then
                        saldosC(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "D" Then
                        saldosD(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    End If
                    saldosA(6, icount) = 6 'dr.Item("pv_inv_reorden").Value.ToString
                    saldosA(7, icount) = 10 'dr.Item("pv_inv_maximo").Value.ToString

                Next
            Next



            Try
                oCompras.mostrarGraficaComparativa(1, coberturas, saldos, nombre_productos, periodos, "Cobertura Semanas", "Valores Q.", saldosHistoricos)
                oCompras.mostrarGraficaComparativaABC(1, coberturas, saldosA, nombre_productos, periodos, "Cobertura Semanas", "Valores Q.", saldosB, saldosC, saldosD)
            Catch ex As Exception
            End Try




            'LLeno Los Saldos Historicos por Pareto

            For Each lspareto As String In ("A,B,C,D").Split(",")
                lsSQL = New StringBuilder
                lsSQL.Append("pa_ins_um_scm_saldo_empresa_pareto '").Append(pdr.Item("empresa").ToString).Append("','").Append(lspareto).Append("','")
                lsSQL.Append(pfechaCalculo.ToString("dd-MM-yyyy")).Append("'")

                ds_informacion_productos.Tables("ResumenEmpresaPareto").DefaultView.RowFilter =
                    "empresa = '" & pdr.Item("empresa").ToString & "' and pareto = '" & lspareto & "'"
                For Each drv As DataRowView In ds_informacion_productos.Tables("ResumenEmpresaPareto").DefaultView
                    For icount As Integer = 0 To 20
                        Dim snombrecampo As String = "saldo"
                        If icount > 0 Then snombrecampo += "+" + icount.ToString.PadLeft(2, "0")
                        Dim isaldo = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                        lsSQL.Append(",").Append(isaldo)
                    Next
                Next

                Otrans.Ingresa(lsSQL.ToString)
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            oCompras = Nothing
        End Try


    End Sub


    Private Sub graficarCoberturasCorporativo()

        Dim i, nrow As Integer
        Dim ncolumn As Integer = -1
        Dim coberturas, saldos, saldosHistoricos, saldosA, saldosB, saldosC, saldosD As Double(,)

        Dim nombre_productos As String()
        Dim periodos As String()


        ReDim nombre_productos(1)


        ReDim coberturas(7, 20)
        ReDim saldos(7, 20), saldosA(7, 20), saldosB(7, 20), saldosC(7, 20), saldosD(7, 20)
        ReDim saldosHistoricos(7, 20)


        ReDim periodos(20)
        Dim oCompras As New Compras.SCM
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()

            pfechaCalculo = Today
            Dim dr As DataRow = ds_informacion_productos.Tables("ResumenTotal").Rows(0)
            Dim dt2 As DataTable = Otrans.Obtiene("pa_sel_um_scm_saldos_empresa null")
            'Dim dt2 As DataTable = Otrans.Obtiene("pa_sel_um_scm_saldos_empresaAnterior null")


            nombre_productos(i) = "Corporativo"
            saldos(7, 0) = 10 'inv_maximo" 
            saldos(6, 0) = 6 'inv_reorden 
            coberturas(i, 0) = Math.Round(Double.Parse(dr.Item("cobertura").ToString), 0)
            periodos(0) = pfechaCalculo.ToString("dd-MMM-yyyy")
            saldos(i, 0) = Math.Round(dr.Item("saldo")) 'Math.Round(Double.Parse(dgv_detalle.Item("Saldo", nrow).Value.ToString), 0)
            For Each dr2 As DataRow In dt2.Rows
                saldosHistoricos(i, 0) = saldosHistoricos(i, 0) + Math.Round(Double.Parse(dr2.Item("saldo_01").ToString), 0)
            Next

            For icount As Integer = 1 To 20
                coberturas(i, icount) = Math.Round(Double.Parse(dr.Item("cobertura+" + icount.ToString.PadLeft(2, "0"))), 0)
                saldos(i, icount) = Math.Round(Double.Parse(dr.Item("saldo+" + icount.ToString.PadLeft(2, "0")).ToString), 0)
                periodos(icount) = pfechaCalculo.AddDays(icount * 7).ToString("dd-MMM-yyyy") '"cobertura+" + icount.ToString.PadLeft(2, "0") ' Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
                saldos(6, icount) = 6
                saldos(7, icount) = 10
                If icount < 20 Then
                    For Each dr2 As DataRow In dt2.Rows
                        saldosHistoricos(i, icount) += Math.Round(Double.Parse(dr2.Item("saldo_" + (icount + 1).ToString.PadLeft(2, "0")).ToString), 0)
                    Next
                End If
            Next

            'For Each dr2 As DataRow In dt3.Rows
            '    saldos(i, 0) = saldos(i, 0) + Math.Round(Double.Parse(dr2.Item("saldo_01").ToString), 0)
            'Next

            'For icount As Integer = 1 To 20
            '    ' coberturas(i, icount) = Math.Round(Double.Parse(dr.Item("cobertura+" + icount.ToString.PadLeft(2, "0"))), 0)
            '    '  saldos(i, icount) = Math.Round(Double.Parse(dr.Item("saldo+" + icount.ToString.PadLeft(2, "0")).ToString), 0)
            '    periodos(icount) = pfechaCalculo.AddDays(icount * 7).ToString("dd-MMM-yyyy") '"cobertura+" + icount.ToString.PadLeft(2, "0") ' Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
            '    saldos(6, icount) = 6
            '    saldos(7, icount) = 10
            '    If icount < 20 Then
            '        For Each dr2 As DataRow In dt2.Rows
            '            saldos(i, icount) += Math.Round(Double.Parse(dr2.Item("saldo_" + (icount + 1).ToString.PadLeft(2, "0")).ToString), 0)
            '        Next
            '    End If
            'Next


            oCompras.mostrarGraficaComparativa(1, coberturas, saldos, nombre_productos, periodos, "Cobertura Semanas", "Valores Q.", saldosHistoricos)



            'Saldos Pareto
            ds_informacion_productos.Tables("ResumenPareto").DefaultView.RowFilter = ""
            For Each drv As DataRowView In ds_informacion_productos.Tables("ResumenPareto").DefaultView
                For icount As Integer = 0 To 20
                    Dim snombrecampo As String = "saldo"
                    If icount > 0 Then snombrecampo += "+" + icount.ToString.PadLeft(2, "0")

                    If drv.Item("pareto") = "A" Then
                        saldosA(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "B" Then
                        saldosB(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "C" Then
                        saldosC(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    ElseIf drv.Item("pareto") = "D" Then
                        saldosD(i, icount) = Math.Round(Double.Parse(drv.Item(snombrecampo).ToString), 0)
                    End If
                    saldosA(6, icount) = 6 'dr.Item("pv_inv_reorden").Value.ToString
                    saldosA(7, icount) = 10 'dr.Item("pv_inv_maximo").Value.ToString
                Next
            Next

            Try
                oCompras.mostrarGraficaComparativa(1, coberturas, saldos, nombre_productos, periodos, "Cobertura Semanas", "Valores Q.", saldosHistoricos)
                oCompras.mostrarGraficaComparativaABC(1, coberturas, saldosA, nombre_productos, periodos, "Cobertura Semanas", "Valores Q.", saldosB, saldosC, saldosD)
            Catch ex As Exception
            End Try

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            oCompras = Nothing
        End Try


    End Sub




    Private Sub btn_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Abrir.Click
        Me.timer_orden.Enabled = False
        Me.dgv_detalle.DataSource = Nothing
        Me.dgv_resumen.DataSource = Nothing
        Me.txtComentarios.Text = String.Empty 'sComentarioOriginal
        Me.Refresh()


        ds_informacion_productos = New DataSet
        Dim oform As New frm_scm_obtiene_informacion(ds_informacion_productos)


        'ds_informacion_productos = New DataSet
        oform.ShowDialog()

        piSemanas = oform.pnSemanas
        columnasOcultas = oform.psColumnasOcultas
        pfechaCalculo = oform.pFechaCalculo
        psNombreCalculo = oform.psNombreCalculo
        nCodigoPedido = oform.pnumeroPedido


        oform.Dispose()
        oform = Nothing

        Me.Text = "::.SCM - Generar Pedido - " & psNombreCalculo & " .::"
        Me.snombreCalculo = psNombreCalculo

        Recargar_Resumen()

        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
        Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")



        'pi_meses_adicionales = IIf(ds_informacion_productos.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)

        Colorear_Detalle(Me.generarForecasting)
        Colorear_Resumen()

        If columnasOcultas.Length > 0 Then
            For Each scolumna As String In columnasOcultas.Split(",")
                OcultarColumna(False, scolumna)
            Next
        End If
        LlenarFiltros()
        Me.llenarComentarios()
        Me.chk_filtro.Checked = True
        Me.Btn_Guardar.Enabled = True
        Me.timer_orden.Enabled = True
    End Sub


    Private Sub graficarSeleccion()

        Dim selectedCellCount As Integer =
                            Me.dgv_detalle.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then



            Dim i, nrow As Integer
            Dim ncolumn As Integer = -1
            Dim liSemanas As Integer = 21
            Dim coberturas, saldos As Double(,)

            Dim nombre_productos As String()
            Dim periodos As String()


            ReDim nombre_productos(selectedCellCount - 1)
            If pbGenerarProyeccion Then
                liSemanas = 30
            End If

            ''            ReDim coberturas(7, 21)
            ''            ReDim saldos(7, 21)
            ''            ReDim periodos(21)

            ReDim coberturas(7, liSemanas)
            ReDim saldos(7, liSemanas)
            ReDim periodos(liSemanas)


            If selectedCellCount > 6 Then
                MessageBox.Show("El Maximo Para Graficar es 6", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For i = 0 To selectedCellCount - 1

                nrow = dgv_detalle.SelectedCells(i).RowIndex

                nombre_productos(i) = dgv_detalle.Item("glosa", dgv_detalle.SelectedCells(i).RowIndex).Value.ToString
                saldos(7, 0) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                saldos(6, 0) = Me.dgv_detalle.Item("pv_inv_reorden", nrow).Value.ToString
                coberturas(i, 0) = Math.Round(Double.Parse(dgv_detalle.Item("cobertura", nrow).Value.ToString), 0)
                periodos(0) = pfechaCalculo.ToString("dd-MMM-yyyy")
                saldos(i, 0) = Math.Round(Double.Parse(dgv_detalle.Item("Saldo", nrow).Value.ToString), 0)

                For icount As Integer = 1 To liSemanas
                    coberturas(i, icount) = Math.Round(Double.Parse(Me.dgv_detalle.Item("cobertura+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString), 0)
                    saldos(i, icount) = Math.Round(Double.Parse(Me.dgv_detalle.Item("saldo+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString), 0)
                    periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
                    'If icount Mod 4 = 0 Then
                    '    periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).ToolTipText
                    'End If
                    saldos(6, icount) = Me.dgv_detalle.Item("pv_inv_reorden", nrow).Value.ToString
                    saldos(7, icount) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                Next


            Next i


            Dim ileadtime As Integer = Me.dgv_detalle.Item("pv_lead_time_total", nrow).Value.ToString

            periodos(ileadtime) = "****" & periodos(ileadtime)


            Dim ocompras As New Compras.SCM

            Try
                ocompras.mostrarGrafica(selectedCellCount, coberturas, saldos, nombre_productos, periodos, "Cobertura Semanas", "Existencias Cajas", liSemanas)
            Catch ex As Exception
            Finally
                ocompras = Nothing
            End Try

        End If



    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)
            'If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.ToLower.StartsWith("glosa") Then
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index
            If Me.dgv_detalle.Item("glosa", nrow).Value.ToString.StartsWith("**") Then
                Me.ContextMenuStrip1.Items.Add("Ver Derivados ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If
            'End If

            Me.ContextMenuStrip1.Items.Add("Ver Ventas", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items(Me.ContextMenuStrip1.Items.Count - 1).ForeColor = Color.Blue
            Me.ContextMenuStrip1.Items.Add("Ver Presupuesto Mensual", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Ver Transito", Nothing, AddressOf ToolStripMenuItem_Click)

            Me.ContextMenuStrip1.Items.Add("Graficar", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items(Me.ContextMenuStrip1.Items.Count - 1).ForeColor = Color.Brown


            If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.IndexOf("+") > 0 Then
                Me.ContextMenuStrip1.Items.Add("Ocultar Semana '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText.Split(" ")(1) & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            End If
            Me.ContextMenuStrip1.Items.Add("Ocultar Columna '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)

            If psNombreCalculo.Length > 0 Then
                Me.ContextMenuStrip1.Items.Add("Agregar Comentario ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If

            If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.StartsWith("transito+") Then
                Me.ContextMenuStrip1.Items.Add("Cambiar Ingreso de Transito ", Nothing, AddressOf ToolStripMenuItem_Click)
                Me.ContextMenuStrip1.Items(Me.ContextMenuStrip1.Items.Count - 1).ForeColor = Color.DarkSalmon
            End If

            If columnasOcultas.Length > 0 Then
                For Each saux As String In columnasOcultas.Split(",")
                    If saux.Length > 0 Then
                        Me.ContextMenuStrip1.Items.Add("Mostrar Columna '" & saux & "'", Nothing, AddressOf ToolStripMenuItem_Click)
                    End If
                Next
            End If

            Me.ContextMenuStrip1.Items.Add("Presupuesto Original", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Ver Inventario Por Lote", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Ver Inventario Por Añada", Nothing, AddressOf ToolStripMenuItem_Click)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("ocultar co") Then
                    columnasOcultas += "," + Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Visible = False
                ElseIf menuItem.Text.ToLower.StartsWith("ocultar sem") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    columnasOcultas += "," + menuItem.Text.Split(" ")(1)

                    Me.OcultarColumna(True, saux)
                    'For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                    '    If dc.HeaderText.ToLower.IndexOf(" " & saux.ToLower) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                    '        icount += 1
                    '        dc.Visible = False
                    '        '        columnasOcultas = columnasOcultas.Replace("," & saux, "")
                    '    End If
                    '    If icount = 4 Then
                    '        Exit For
                    '    End If
                    'Next



                    '             ods.Tables("productos").DefaultView.RowFilter = filtro_actual
                ElseIf menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = True
                    nfrozen = Me.dgv_detalle.CurrentCell.ColumnIndex

                ElseIf menuItem.Text.ToLower.StartsWith("mostrar") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    If saux.ToLower.StartsWith("semana") Then

                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.HeaderText.LastIndexOf(menuItem.Text.Split("'")(2)) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & "Semana'" & menuItem.Text.Split("'")(2) & "'", "")
                            End If
                        Next
                    Else


                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.Name.ToLower = saux.ToLower Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & saux, "")
                            End If
                        Next
                    End If

                ElseIf menuItem.Text.ToLower.StartsWith("ver d") Then
                    mostrarDerivados()
                ElseIf menuItem.Text.ToLower.StartsWith("ver v") Then
                    generarVentas()
                ElseIf menuItem.Text.ToLower.StartsWith("ver p") Then
                    mostrarPresupuesto()
                ElseIf menuItem.Text.ToLower.StartsWith("ver t") Then
                    mostrarTransitoProducto()
                ElseIf menuItem.Text.ToLower.StartsWith("grafi") Then
                    graficarSeleccion()
                ElseIf menuItem.Text.ToLower.StartsWith("agregar com") Then
                    agregarComentario()
                ElseIf menuItem.Text.ToLower.StartsWith("cambiar ingreso") Then
                    modificarFechaIngreso()
                ElseIf menuItem.Text.ToLower.StartsWith("presu") Then
                    mostrarPresupuestoOriginal()
                ElseIf menuItem.Text.ToLower.StartsWith("ver inventario por lote") Then
                    mostrarInventarioPorLote() '(c) 20240829
                ElseIf menuItem.Text.ToLower.StartsWith("ver inventario por añada") Then
                    mostrarInventarioPorSerie() '(c) 20240829
                Else


                    For iaux As Integer = 1 To nfrozen
                        Me.dgv_detalle.Columns(iaux).Frozen = False
                    Next
                    'Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = False


                    'menuItem.Text.Replace("Filtrar ", " ")
                    'Dim nombre_supervisor As String = menuItem.Text.Replace("Filtrar ", "")
                    'MessageBox.Show("The " & nombre_supervisor & " item was just selected.")
                    '            ods.Tables("productos").DefaultView.RowFilter = filtro_actual & " and supervisor = '" & nombre_supervisor & "'"


                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_detalle_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_detalle.CellMouseDoubleClick
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow
        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)
                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("tran") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        'mostrarTransito(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, Me.dgv_detalle.Columns(colIndex).ToolTipText)\

                        If Me.dgv_detalle.Columns(colIndex).HeaderText.IndexOf(" ") > 0 Then
                            mostrarTransito(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, Me.dgv_detalle.Columns(colIndex).HeaderText.Split(" ")(1), ds_informacion_productos.Tables("derivados"))
                        Else
                            mostrarTransito(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, pfechaCalculo, ds_informacion_productos.Tables("derivados"))
                        End If


                    End If
                ElseIf dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("bodegas") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        mostrarInventarioBodegas(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value)
                    End If
                ElseIf dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("consig") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        mostrarInventarioBodegas(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value)
                    End If
                ElseIf dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("reservas") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        mostrarReservas(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_detalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)

                If dgv_detalle.Columns(colIndex).Name.ToLower.StartsWith("sugerido") Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightSalmon
                    Else
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.White
                    End If
                End If

                If Me.dgv_detalle.Item("agregar", rowIndex).Value = True Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    If Me.dgv_detalle.Item("pareto", rowIndex).Value.ToString.ToLower = "d" Then
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If

                'End If
                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("transi") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Try
                            If Me.dgv_detalle.Columns(colIndex).Name.IndexOf("+") > -1 Then
                                If Me.dgv_detalle.Columns(colIndex).Name.Substring(9) >= Me.dgv_detalle.Item("pv_modificar_transito", rowIndex).Value Then
                                    Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LemonChiffon
                                Else
                                    Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                                End If
                            Else
                                Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                            End If

                        Catch ex As Exception
                            Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen

                        End Try
                    Else
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.White
                    End If
                End If

                If dgv_detalle.Columns(colIndex).Name.ToLower.Equals("porcentaje_ajuste") Then
                    If dgv_detalle.Item(colIndex, rowIndex).Value <> 0 Then
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightSteelBlue
                    Else
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.White
                    End If

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub chk_filtro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_filtro.CheckedChanged
        aplicarFiltro()
    End Sub

    Private Sub verificarSeguridad()
        Me.CambiarEstadoToolStripMenuItem.Visible = tiene_permisos("mci_scm_cambiar_estado_calculos")
        Me.Btn_Aplicar_sugerido.Visible = tiene_permisos("mci_scm_generar_grafica_cobertura_global")
    End Sub

    Private Sub cambiarEstado()
        'Dim clsgen As New ClasesGenerales.frm_seleccionar_opcion
        'Dim Otrans As New Transaccional.Conexion("SCM")
        'Dim estados As String = String.Empty
        'Dim lsSQL As String

        'Try
        '    Otrans.open()
        '    For Each dr As DataRow In ds_preparacion.Tables("pg_estados").Rows
        '        estados += IIf(estados.Length > 0, ",", "") & dr.Item("estado")
        '    Next
        '    clsgen.Llenar_ComboString(estados)
        '    clsgen.ShowDialog()
        '    estados = clsgen.cmb_listado.SelectedItem
        '    clsgen.Dispose()
        '    Dim dt As DataTable
        '    dt = ds_preparacion.Tables("pg_estados").Copy
        '    dt.DefaultView.RowFilter = "estado = '" & estados & "'"

        '    ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "agregar = true and estado = " & Me.cmbEstado.SelectedValue
        '    For Each drv As DataRowView In ds_preparacion.Tables("calculos_previos").DefaultView
        '        lsSQL = "pa_upd_um_inv_pedido_encabezado " & drv.Item("cod_calculo") & "," & dt.DefaultView(0)("cod_estado") & ",'" & gs_usuario & "'"
        '        Otrans.Actualiza(lsSQL)
        '    Next
        '    MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Exception
        'Finally
        '    Otrans.close()
        '    Otrans = Nothing
        '    clsgen = Nothing
        'End Try

    End Sub

    Private Sub frm_scm_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        verificarSeguridad()
    End Sub

    Private Sub dgv_detalle_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_detalle.DataError
        MessageBox.Show("Ingreso Un Valor Invalido", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub cmbOrigen_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrigen.SelectionChangeCommitted
        aplicarFiltro()
    End Sub

    Private Sub cmbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProveedor.SelectionChangeCommitted
        aplicarFiltro()
    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgv_detalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        'Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                '              therow = Me.dgv_detalle.Rows(rowIndex)
                If (",pedido,agregar,porcentaje_ajuste,").IndexOf(dgv_detalle.Columns(colIndex).Name.ToLower) > -1 Then
                    Dim ncantidad As Integer = -99

                    Dim clickagregar As Boolean = dgv_detalle.Columns(colIndex).Name.ToLower.Equals("agregar")
                    'Me.dgv_detalle.Item("valor_sugerido", rowIndex).Value = Me.dgv_detalle.Item("pedido", rowIndex).Value * Me.dgv_detalle.Item("fob", rowIndex).Value
                    If dgv_detalle.Columns(colIndex).Name.ToLower.Equals("pedido") Then
                        ncantidad = dgv_detalle.Item(colIndex, rowIndex).Value

                    End If
                    If Me.chkAjuste.CheckState = CheckState.Checked Then
                        Me.AplicarProducto_new(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, dgv_detalle.Columns(colIndex).Name.ToLower, ncantidad, False, True)
                    Else
                        Me.AplicarProducto(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, dgv_detalle.Columns(colIndex).Name.ToLower, ncantidad, False, True)
                    End If


                    dgv_detalle.CurrentCell = dgv_detalle.Item(colIndex, rowIndex)

                End If

                '(c) 20160906 Cuando se modifica un transito se deben regenerar las coberturas
                If dgv_detalle.Columns(colIndex).Name.ToLower.StartsWith("transito") Then
                    Dim oCompras As New Compras.SCM(ds_informacion_productos)
                    Try
                        oCompras.Generar_SaldosyCoberturasProducto(Me.dgv_detalle.Item("producto", rowIndex).Value)
                    Catch ex As Exception
                    Finally
                        oCompras = Nothing
                        Recargar_Resumen()
                    End Try

                    dgv_detalle.CurrentCell = dgv_detalle.Item(colIndex, rowIndex)
                    'Me.Btn_Guardar.Enabled = False

                End If
            End If

        Catch ex As Exception
            Escribir_log(ex.ToString)

        End Try
    End Sub

    Private Sub AumentarDisminuirPresupuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AumentarDisminuirPresupuestoToolStripMenuItem.Click

        Try
            Dim ntext As String = InputBox("Ingrese Porcentaje Que Desea Aumentar/Disminuir", "Modificar Presupuesto")
            If Val(ntext) <> 0 Then
                modificarPresupuesto(Double.Parse(ntext))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CambiarEstadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarEstadoToolStripMenuItem.Click
        If MessageBox.Show("Esta Seguro de Cambiar Estado ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            cambiarEstado()
        End If
    End Sub

    Private Sub HabilitarForecastingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HabilitarForecastingToolStripMenuItem.Click
        If MessageBox.Show("Esta Seguro de Habilitar Forecasting ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            generarForecasting = True
            'Colorear_Detalle(True)

            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns
                If dc.Name.ToLower.StartsWith("transito") Then
                    dc.ReadOnly = False
                End If
            Next

        End If

    End Sub


    Private Sub VerResumenGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerResumenGeneralToolStripMenuItem.Click

        Dim oform As New frm_resultado
        Try
            oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("ResumenEmpresa")




            Dim ClsGen As New ClasesGenerales.General
            Dim ls_columnas_ocultar, ls_columnas_fijas As String

            Try

                ls_columnas_ocultar = String.Empty
                If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
                'ls_columnas_ocultar += ",region,marca,fob,existencia,glosa,producto,pareto,uxc,agregar,diario_cajas,estatus,cd_cajas,cdx_cajas,da_cajas,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,full,cajasxpallet,cajasxlayer,calculos,"
                ls_columnas_ocultar += "porcentaje_ajuste,"
                ls_columnas_fijas = String.Empty

                ClsGen.Alinear_GridView(ds_informacion_productos.Tables("ResumenEmpresa"), oform.dgv_resultado, "", ls_columnas_ocultar, "", "", ",valor_sugerido=valor_pedido,", ls_columnas_fijas, ",proveedor,procedencia,pedido,valor_sugerido,peso,volumen,", True, True, 250, 0)
                For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                    dc.ReadOnly = True
                    If dc.Name.ToLower.StartsWith("cober") Then
                        'dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        'dc.Width = 50
                        'dc.Visible = False
                    ElseIf dc.Name.ToLower.StartsWith("suger") Then
                        dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        If piSemanas > 0 Then
                            Try
                                If dc.Name.IndexOf("+") > 0 Then
                                    If Val(dc.Name.Split("+")(1)) < piSemanas Then
                                        dc.Width = 70
                                    Else
                                        dc.Visible = False
                                    End If
                                Else
                                    dc.Width = 70
                                End If
                            Catch ex As Exception
                                dc.Width = 70
                            End Try

                        End If


                    ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                        dc.Visible = False
                    ElseIf dc.Name.ToLower.StartsWith("saldo") Then
                        dc.Visible = True
                    ElseIf dc.Name.IndexOf("+") > 0 Then
                        dc.Visible = False

                    End If
                    If pbGenerarProyeccion Then
                        If dc.Name.ToString.StartsWith("valor_transit") Then
                            dc.Width = 70
                        End If

                    End If

                    If dc.Name.ToLower.IndexOf("+") > 0 Then
                        dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " +
                                     DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)), FirstDayOfWeek.Monday).ToString
                    End If
                Next

            Catch ex As Exception
            Finally
                ClsGen = Nothing

            End Try


            oform.ShowDialog()

            If MessageBox.Show("Desea Exportar Resultado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                Dim Oaut As New Automatizar.exportar_excel

                Dim socultarColumnas As New StringBuilder
                Dim snombreColumnas As New StringBuilder


                Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

                Oaut.Nombre_Columnas = ",,,,,,,,,,,,,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

                For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                    If Me.pbGenerarProyeccion Then
                        If dc.Name.ToLower.StartsWith("ppto+") Or dc.Name.ToLower.StartsWith("cobertura+") Then
                            dc.Visible = False
                        End If
                    End If
                    If Not dc.Visible Then socultarColumnas.Append("," & dc.Name.ToLower)
                    If dc.Visible Then snombreColumnas.Append("," & dc.HeaderText.ToLower)
                Next
                socultarColumnas.Append(",")
                snombreColumnas.Append(",")
                Oaut.ocultar_columnas = socultarColumnas.ToString
                Oaut.Nombre_Columnas = snombreColumnas.ToString

                Oaut.nAgregar_Filas = 2
                Oaut.DataTableToExcel(ds_informacion_productos.Tables("ResumenEmpresa").DefaultView.ToTable)
                Oaut = Nothing

            End If


            oform.Dispose()
            oform = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportarResumenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarResumenToolStripMenuItem.Click




        Dim Oaut As New Automatizar.exportar_excel

        Dim socultarColumnas As New StringBuilder
        Dim snombreColumnas As New StringBuilder


        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

        Oaut.Nombre_Columnas = ",,,,,,,,,,,,,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

        For Each dc As DataGridViewColumn In Me.dgv_resumen.Columns
            If Me.pbGenerarProyeccion Then
                If dc.Name.ToLower.StartsWith("ppto+") Or dc.Name.ToLower.StartsWith("cobertura+") Then
                    dc.Visible = False
                End If
            End If
            If Not dc.Visible Then socultarColumnas.Append("," & dc.Name.ToLower)
            If dc.Visible Then snombreColumnas.Append("," & dc.HeaderText.ToLower)
        Next
        socultarColumnas.Append(",")
        snombreColumnas.Append(",")
        Oaut.ocultar_columnas = socultarColumnas.ToString
        Oaut.Nombre_Columnas = snombreColumnas.ToString

        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ds_informacion_productos.Tables("Resumen").DefaultView.ToTable)
        Oaut = Nothing


    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub timer_orden_Tick(sender As Object, e As EventArgs) Handles timer_orden.Tick
        'MessageBox.Show("Timer " & Now)
        Try
            'copia local (c) 20200526
            Dim ds As New DataSet("calculo")

            ds.Tables.Add(ds_informacion_productos.Tables("detalle_productos").Copy)
            ds.Tables.Add(ds_informacion_productos.Tables("derivados").Copy)
            If ds_informacion_productos.Tables.Contains("existencias") Then ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)

            Try
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_derivado").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_mensual").Copy)
                ds.Tables.Add(ds_informacion_productos.Tables("transitos").Copy)

                ds.Tables.Add(ds_informacion_productos.Tables("existencias").Copy)
                'dt.TableName = "presupuesto_derivado";
            Catch ex As Exception

            End Try

            Try
                Dim clsgen As New ClasesGenerales.General
                If Not Directory.Exists("c:\aplicaciones\compras\autosave") Then
                    Directory.CreateDirectory("c:\aplicaciones\compras\autosave")
                End If
                clsgen = Nothing
            Catch ex As Exception
            Finally


            End Try

            ds.WriteXml("c:\aplicaciones\compras\autosave\" & snombreCalculo.Trim & "_autosave_" & Now.ToString("HHmm") & ".xml", XmlWriteMode.WriteSchema)
            Me.lblHoraAutoSave.Text = Now
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CambiarTiempoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarTiempoToolStripMenuItem.Click
        Dim imilisegundos As Integer
        Dim sMinutos As String
        Try
            sMinutos = InputBox("Ingrese Nombre De Calculo", "Nombre", "5")
            imilisegundos = Integer.Parse(sMinutos) * 60 * 1000
            Me.timer_orden.Interval = imilisegundos
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ObtenerVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObtenerVersionToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        Dim sarchivo As String
        sarchivo = OpenFileDialog1.FileName




        Try
            ds_informacion_productos = New DataSet
            ds_informacion_productos.ReadXml(sarchivo)


            'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto").Copy)
            'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_derivado").Copy)
            'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_mensual").Copy)

            'If pnsemanas < drv.Item("Semanas_Calculo") Then
            'pnsemanas = 4
            'End If
            'pfechaCalculo = drv.Item("fecha_grabo")
            'psColumnasOcultas = drv.Item("Columnas_Ocultas").ToString
            'psComentarios = drv.Item("comentarios").ToString
            'pnumeroPedido = drv.Item("cod_calculo")
            'psNombreCalculo = drv.Item("nombre_calculo").ToString.Trim

            'dt2 = ds_preparacion.Tables("detalle_productos").Copy
            'dt2.TableName = "calculo_original"
            'If ds_preparacion.Tables.Contains("calculo_original") Then ds_preparacion.Tables.Remove("calculo_original")
            'ds_preparacion.Tables.Add(dt2.Copy)
            Recargar_Resumen()

            Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")
            Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")



            'pi_meses_adicionales = IIf(ds_informacion_productos.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)

            Colorear_Detalle(Me.generarForecasting)
            Colorear_Resumen()

            'If columnasOcultas.Length > 0 Then
            '    For Each scolumna As String In columnasOcultas.Split(",")
            '        OcultarColumna(False, scolumna)
            '    Next
            'End If
            LlenarFiltros()
            'Me.llenarComentarios()
            Me.chk_filtro.Checked = True
            Me.Btn_Guardar.Enabled = True
            Me.timer_orden.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IniciarAutosaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarAutosaveToolStripMenuItem.Click
        Me.timer_orden.Enabled = True

    End Sub

    Private Sub DetenerAutoSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetenerAutoSaveToolStripMenuItem.Click
        Me.timer_orden.Enabled = False

    End Sub


End Class
