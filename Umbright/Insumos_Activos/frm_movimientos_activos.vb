Public Class frm_movimientos_activos
    Inherits System.Windows.Forms.Form
    Dim dt_modelos As DataTable
    Dim ds_insumos As New DataSet
    Dim ds_movimiento As New DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Friend WithEvents btn_user_ok As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents txt_comentarios_traslado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
   


    Public Insumos As Boolean = True

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
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_listado_movimientos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_categoria_movimiento As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_word As System.Windows.Forms.Button
    Friend WithEvents btn_impresion As System.Windows.Forms.Button
    Friend WithEvents StatusBar2 As System.Windows.Forms.StatusBar
    Friend WithEvents sb_grabo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sb_fecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmb_usuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dt_fecha_movimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_motivo_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipo_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents btn_nuevo_movimiento As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_movimiento As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents dgv_detalle_movimiento As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btn_nuevo_traslados As System.Windows.Forms.Button
    Friend WithEvents btn_traslado_guardar As System.Windows.Forms.Button
    Friend WithEvents dgv_detalle_movimiento_traslado As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_usuario_destino As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_usuario_origen As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_movimientos_activos))
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.dgv_listado_movimientos = New System.Windows.Forms.DataGridView
        Me.btn_categoria_movimiento = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dgv_detalle_movimiento = New System.Windows.Forms.DataGridView
        Me.btn_word = New System.Windows.Forms.Button
        Me.btn_impresion = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar2 = New System.Windows.Forms.StatusBar
        Me.sb_grabo = New System.Windows.Forms.StatusBarPanel
        Me.sb_fecha = New System.Windows.Forms.StatusBarPanel
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_comentarios = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmb_usuario = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dt_fecha_movimiento = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmb_motivo_movimiento = New System.Windows.Forms.ComboBox
        Me.cmb_tipo_movimiento = New System.Windows.Forms.ComboBox
        Me.btn_nuevo_movimiento = New System.Windows.Forms.Button
        Me.btn_guardar_movimiento = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btn_user_ok = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo_traslados = New System.Windows.Forms.Button
        Me.btn_traslado_guardar = New System.Windows.Forms.Button
        Me.dgv_detalle_movimiento_traslado = New System.Windows.Forms.DataGridView
        Me.cmb_usuario_destino = New System.Windows.Forms.ComboBox
        Me.cmb_usuario_origen = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_comentarios_traslado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage4.SuspendLayout()
        CType(Me.dgv_listado_movimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_detalle_movimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sb_grabo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sb_fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_detalle_movimiento_traslado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage4.Controls.Add(Me.dgv_listado_movimientos)
        Me.TabPage4.Controls.Add(Me.btn_categoria_movimiento)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(664, 426)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Listado Movimientos"
        '
        'dgv_listado_movimientos
        '
        Me.dgv_listado_movimientos.AllowUserToAddRows = False
        Me.dgv_listado_movimientos.AllowUserToDeleteRows = False
        Me.dgv_listado_movimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listado_movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado_movimientos.Location = New System.Drawing.Point(3, 37)
        Me.dgv_listado_movimientos.Name = "dgv_listado_movimientos"
        Me.dgv_listado_movimientos.ReadOnly = True
        Me.dgv_listado_movimientos.RowHeadersWidth = 25
        Me.dgv_listado_movimientos.Size = New System.Drawing.Size(658, 382)
        Me.dgv_listado_movimientos.TabIndex = 20
        '
        'btn_categoria_movimiento
        '
        Me.btn_categoria_movimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_categoria_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_categoria_movimiento.Location = New System.Drawing.Point(526, 8)
        Me.btn_categoria_movimiento.Name = "btn_categoria_movimiento"
        Me.btn_categoria_movimiento.Size = New System.Drawing.Size(75, 23)
        Me.btn_categoria_movimiento.TabIndex = 19
        Me.btn_categoria_movimiento.Text = "Filtrar"
        Me.btn_categoria_movimiento.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage3.Controls.Add(Me.dgv_detalle_movimiento)
        Me.TabPage3.Controls.Add(Me.btn_word)
        Me.TabPage3.Controls.Add(Me.btn_impresion)
        Me.TabPage3.Controls.Add(Me.StatusBar2)
        Me.TabPage3.Controls.Add(Me.txt_numero)
        Me.TabPage3.Controls.Add(Me.txt_comentarios)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.cmb_usuario)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.dt_fecha_movimiento)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.cmb_motivo_movimiento)
        Me.TabPage3.Controls.Add(Me.cmb_tipo_movimiento)
        Me.TabPage3.Controls.Add(Me.btn_nuevo_movimiento)
        Me.TabPage3.Controls.Add(Me.btn_guardar_movimiento)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(664, 426)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Movimientos"
        '
        'dgv_detalle_movimiento
        '
        Me.dgv_detalle_movimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_detalle_movimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle_movimiento.Location = New System.Drawing.Point(3, 168)
        Me.dgv_detalle_movimiento.Name = "dgv_detalle_movimiento"
        Me.dgv_detalle_movimiento.RowHeadersWidth = 25
        Me.dgv_detalle_movimiento.Size = New System.Drawing.Size(642, 231)
        Me.dgv_detalle_movimiento.TabIndex = 18
        '
        'btn_word
        '
        Me.btn_word.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_word.Location = New System.Drawing.Point(438, 107)
        Me.btn_word.Name = "btn_word"
        Me.btn_word.Size = New System.Drawing.Size(75, 23)
        Me.btn_word.TabIndex = 17
        Me.btn_word.Text = "Word"
        Me.btn_word.Visible = False
        '
        'btn_impresion
        '
        Me.btn_impresion.BackColor = System.Drawing.Color.LightCyan
        Me.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_impresion.ImageIndex = 2
        Me.btn_impresion.ImageList = Me.ImageList1
        Me.btn_impresion.Location = New System.Drawing.Point(577, 106)
        Me.btn_impresion.Name = "btn_impresion"
        Me.btn_impresion.Size = New System.Drawing.Size(68, 55)
        Me.btn_impresion.TabIndex = 16
        Me.btn_impresion.Text = "Impresion"
        Me.btn_impresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_impresion.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "page_blank.ico")
        Me.ImageList1.Images.SetKeyName(1, "save.ico")
        Me.ImageList1.Images.SetKeyName(2, "printer.ico")
        '
        'StatusBar2
        '
        Me.StatusBar2.Location = New System.Drawing.Point(0, 404)
        Me.StatusBar2.Name = "StatusBar2"
        Me.StatusBar2.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sb_grabo, Me.sb_fecha})
        Me.StatusBar2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusBar2.ShowPanels = True
        Me.StatusBar2.Size = New System.Drawing.Size(664, 22)
        Me.StatusBar2.TabIndex = 12
        Me.StatusBar2.Text = "StatusBar2"
        '
        'sb_grabo
        '
        Me.sb_grabo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sb_grabo.Name = "sb_grabo"
        Me.sb_grabo.Width = 323
        '
        'sb_fecha
        '
        Me.sb_fecha.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sb_fecha.Name = "sb_fecha"
        Me.sb_fecha.Width = 323
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.ForeColor = System.Drawing.Color.Red
        Me.txt_numero.Location = New System.Drawing.Point(477, 12)
        Me.txt_numero.MaxLength = 8
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_numero.Size = New System.Drawing.Size(80, 20)
        Me.txt_numero.TabIndex = 8
        Me.txt_numero.Text = "Numero"
        '
        'txt_comentarios
        '
        Me.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios.Location = New System.Drawing.Point(128, 91)
        Me.txt_comentarios.Multiline = True
        Me.txt_comentarios.Name = "txt_comentarios"
        Me.txt_comentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentarios.Size = New System.Drawing.Size(287, 71)
        Me.txt_comentarios.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(7, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Usuario"
        '
        'cmb_usuario
        '
        Me.cmb_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_usuario.ItemHeight = 14
        Me.cmb_usuario.Location = New System.Drawing.Point(128, 64)
        Me.cmb_usuario.Name = "cmb_usuario"
        Me.cmb_usuario.Size = New System.Drawing.Size(287, 22)
        Me.cmb_usuario.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(424, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Numero"
        '
        'dt_fecha_movimiento
        '
        Me.dt_fecha_movimiento.Enabled = False
        Me.dt_fecha_movimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fecha_movimiento.Location = New System.Drawing.Point(477, 35)
        Me.dt_fecha_movimiento.Name = "dt_fecha_movimiento"
        Me.dt_fecha_movimiento.Size = New System.Drawing.Size(80, 20)
        Me.dt_fecha_movimiento.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Observaciones"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(424, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Fecha"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Motivo"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo Movimiento"
        '
        'cmb_motivo_movimiento
        '
        Me.cmb_motivo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_motivo_movimiento.Location = New System.Drawing.Point(128, 40)
        Me.cmb_motivo_movimiento.Name = "cmb_motivo_movimiento"
        Me.cmb_motivo_movimiento.Size = New System.Drawing.Size(287, 22)
        Me.cmb_motivo_movimiento.TabIndex = 3
        '
        'cmb_tipo_movimiento
        '
        Me.cmb_tipo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_movimiento.Location = New System.Drawing.Point(128, 16)
        Me.cmb_tipo_movimiento.Name = "cmb_tipo_movimiento"
        Me.cmb_tipo_movimiento.Size = New System.Drawing.Size(192, 22)
        Me.cmb_tipo_movimiento.TabIndex = 1
        '
        'btn_nuevo_movimiento
        '
        Me.btn_nuevo_movimiento.BackColor = System.Drawing.Color.LightCyan
        Me.btn_nuevo_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_movimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_movimiento.ImageIndex = 0
        Me.btn_nuevo_movimiento.ImageList = Me.ImageList1
        Me.btn_nuevo_movimiento.Location = New System.Drawing.Point(577, 0)
        Me.btn_nuevo_movimiento.Name = "btn_nuevo_movimiento"
        Me.btn_nuevo_movimiento.Size = New System.Drawing.Size(68, 55)
        Me.btn_nuevo_movimiento.TabIndex = 10
        Me.btn_nuevo_movimiento.Text = "Nuevo"
        Me.btn_nuevo_movimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_movimiento.UseVisualStyleBackColor = False
        '
        'btn_guardar_movimiento
        '
        Me.btn_guardar_movimiento.BackColor = System.Drawing.Color.LightCyan
        Me.btn_guardar_movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_movimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_movimiento.ImageIndex = 1
        Me.btn_guardar_movimiento.ImageList = Me.ImageList1
        Me.btn_guardar_movimiento.Location = New System.Drawing.Point(577, 52)
        Me.btn_guardar_movimiento.Name = "btn_guardar_movimiento"
        Me.btn_guardar_movimiento.Size = New System.Drawing.Size(68, 55)
        Me.btn_guardar_movimiento.TabIndex = 11
        Me.btn_guardar_movimiento.Text = "Guardar"
        Me.btn_guardar_movimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_movimiento.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(677, 459)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage1.Controls.Add(Me.txt_comentarios_traslado)
        Me.TabPage1.Controls.Add(Me.btn_user_ok)
        Me.TabPage1.Controls.Add(Me.btn_nuevo_traslados)
        Me.TabPage1.Controls.Add(Me.btn_traslado_guardar)
        Me.TabPage1.Controls.Add(Me.dgv_detalle_movimiento_traslado)
        Me.TabPage1.Controls.Add(Me.cmb_usuario_destino)
        Me.TabPage1.Controls.Add(Me.cmb_usuario_origen)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(669, 432)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Traslados"
        '
        'btn_user_ok
        '
        Me.btn_user_ok.ImageKey = "aprobar2.jpg"
        Me.btn_user_ok.ImageList = Me.ImageList2
        Me.btn_user_ok.Location = New System.Drawing.Point(393, 23)
        Me.btn_user_ok.Name = "btn_user_ok"
        Me.btn_user_ok.Size = New System.Drawing.Size(38, 23)
        Me.btn_user_ok.TabIndex = 2
        Me.btn_user_ok.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "aprobar2.jpg")
        '
        'btn_nuevo_traslados
        '
        Me.btn_nuevo_traslados.BackColor = System.Drawing.Color.LightCyan
        Me.btn_nuevo_traslados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_traslados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_traslados.ImageIndex = 0
        Me.btn_nuevo_traslados.ImageList = Me.ImageList1
        Me.btn_nuevo_traslados.Location = New System.Drawing.Point(486, 14)
        Me.btn_nuevo_traslados.Name = "btn_nuevo_traslados"
        Me.btn_nuevo_traslados.Size = New System.Drawing.Size(68, 55)
        Me.btn_nuevo_traslados.TabIndex = 21
        Me.btn_nuevo_traslados.Text = "Nuevo"
        Me.btn_nuevo_traslados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_traslados.UseVisualStyleBackColor = False
        '
        'btn_traslado_guardar
        '
        Me.btn_traslado_guardar.BackColor = System.Drawing.Color.LightCyan
        Me.btn_traslado_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_traslado_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_traslado_guardar.ImageIndex = 1
        Me.btn_traslado_guardar.ImageList = Me.ImageList1
        Me.btn_traslado_guardar.Location = New System.Drawing.Point(574, 14)
        Me.btn_traslado_guardar.Name = "btn_traslado_guardar"
        Me.btn_traslado_guardar.Size = New System.Drawing.Size(68, 55)
        Me.btn_traslado_guardar.TabIndex = 5
        Me.btn_traslado_guardar.Text = "Guardar"
        Me.btn_traslado_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_traslado_guardar.UseVisualStyleBackColor = False
        '
        'dgv_detalle_movimiento_traslado
        '
        Me.dgv_detalle_movimiento_traslado.AllowUserToAddRows = False
        Me.dgv_detalle_movimiento_traslado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_detalle_movimiento_traslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle_movimiento_traslado.Location = New System.Drawing.Point(11, 75)
        Me.dgv_detalle_movimiento_traslado.Name = "dgv_detalle_movimiento_traslado"
        Me.dgv_detalle_movimiento_traslado.RowHeadersWidth = 25
        Me.dgv_detalle_movimiento_traslado.Size = New System.Drawing.Size(642, 237)
        Me.dgv_detalle_movimiento_traslado.TabIndex = 3
        '
        'cmb_usuario_destino
        '
        Me.cmb_usuario_destino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_usuario_destino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_usuario_destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_usuario_destino.ItemHeight = 14
        Me.cmb_usuario_destino.Location = New System.Drawing.Point(100, 368)
        Me.cmb_usuario_destino.Name = "cmb_usuario_destino"
        Me.cmb_usuario_destino.Size = New System.Drawing.Size(287, 22)
        Me.cmb_usuario_destino.TabIndex = 4
        '
        'cmb_usuario_origen
        '
        Me.cmb_usuario_origen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_usuario_origen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_usuario_origen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_usuario_origen.ItemHeight = 14
        Me.cmb_usuario_origen.Location = New System.Drawing.Point(100, 23)
        Me.cmb_usuario_origen.Name = "cmb_usuario_origen"
        Me.cmb_usuario_origen.Size = New System.Drawing.Size(287, 22)
        Me.cmb_usuario_origen.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Usuario Origen"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 371)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Usuario Destino"
        '
        'txt_comentarios_traslado
        '
        Me.txt_comentarios_traslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios_traslado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comentarios_traslado.Location = New System.Drawing.Point(100, 318)
        Me.txt_comentarios_traslado.Multiline = True
        Me.txt_comentarios_traslado.Name = "txt_comentarios_traslado"
        Me.txt_comentarios_traslado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentarios_traslado.Size = New System.Drawing.Size(553, 44)
        Me.txt_comentarios_traslado.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Comentarios"
        '
        'frm_movimientos_activos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(680, 465)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_movimientos_activos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Movimientos de Activos ::"
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgv_listado_movimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_detalle_movimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sb_grabo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sb_fecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgv_detalle_movimiento_traslado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim dt, dt2 As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        otrans.open()

        Try

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





            ls_sql = "call pa_sel_um_sg_usuario_todos"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_usuarios"
            ds_movimiento.Tables.Add(dt.Copy)

            Me.cmb_usuario.DataSource = ds_movimiento.Tables("m_usuarios")
            Me.cmb_usuario.DisplayMember = "nombre"
            Me.cmb_usuario.ValueMember = "usuario"

            Me.cmb_usuario_origen.DataSource = dt
            Me.cmb_usuario_origen.DisplayMember = "nombre"
            Me.cmb_usuario_origen.ValueMember = "usuario"

            dt2 = dt.Copy
            Me.cmb_usuario_destino.DataSource = dt2
            Me.cmb_usuario_destino.DisplayMember = "nombre"
            Me.cmb_usuario_destino.ValueMember = "usuario"

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
            otrans.open()

            ls_sql = "call pa_sel_um_act_movimiento_activos ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "listado_movimientos"
            ds_insumos.Tables.Add(dt.Copy)

            Me.dgv_listado_movimientos.DataSource = ds_insumos.Tables("listado_movimientos")
            clsgen.Alinear_GridView(dt, Me.dgv_listado_movimientos, ",cod_movimiento,tipo_movimiento,observaciones,usuario_solicito,fecha_movimiento,", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub Llenar_Movimiento(ByVal _pcod_movimiento As String, ByVal _pdt As DataTable)
        Movimiento_Nuevo()

        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim dt, dt_aux As DataTable
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
                dr_aux.Item("cantidad") = dr.Item("cantidad")
                dt_aux = Buscar_Producto(dr.Item("codigo"))

                dr_aux.Item("categoria") = dt_aux.Rows(0).Item("categoria")
                dr_aux.Item("tipo") = dt_aux.Rows(0).Item("tipo")
                dr_aux.Item("marca") = dt_aux.Rows(0).Item("marca")
                dr_aux.Item("modelo") = dt_aux.Rows(0).Item("modelo")
                dr_aux.Item("serie") = dt_aux.Rows(0).Item("serie")
                dr_aux.Item("existencia") = dt_aux.Rows(0).Item("existencia")

                ds_movimiento.Tables("detalle_movimiento").Rows.Add(dr_aux)
            Next


        Catch ex As Exception
        Finally
            Me.dgv_detalle_movimiento.ReadOnly = True
            Me.dgv_detalle_movimiento.AllowUserToAddRows = False

            otrans.close()
            otrans = Nothing
            Alinear_Grid_Detalle()
        End Try

    End Sub

    Private Sub Crear_Estructura()
        ds_movimiento = New DataSet
        Dim dt As New DataTable


        Try
            dt = New DataTable("detalle_movimiento")

            dt.Columns.Add(New DataColumn("codigo", GetType(String)))
            dt.Columns.Add(New DataColumn("categoria", GetType(String)))
            dt.Columns.Add(New DataColumn("tipo", GetType(String)))
            dt.Columns.Add(New DataColumn("marca", GetType(String)))
            dt.Columns.Add(New DataColumn("modelo", GetType(String)))
            dt.Columns.Add(New DataColumn("serie", GetType(String)))
            dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
            dt.Columns.Add(New DataColumn("existencia", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_producto", GetType(String)))
            ds_movimiento.Tables.Add(dt.Copy)

            Me.dgv_detalle_movimiento.DataSource = ds_movimiento.Tables("detalle_movimiento")

            dt.TableName = "detalle_movimiento_traslado"
            ds_movimiento.Tables.Add(dt.Copy)
            Me.dgv_detalle_movimiento_traslado.DataSource = ds_movimiento.Tables("detalle_movimiento_traslado")


        Catch ex As Exception
        Finally
            Alinear_Grid_Detalle()
            Alinear_Grid_Detalle_Traslado()

        End Try


    End Sub

    Private Sub Alinear_Grid_Detalle()
        Dim ClsGen As New ClasesGenerales.General

        Try
            ClsGen.Alinear_GridView(ds_movimiento.Tables("detalle_movimiento"), Me.dgv_detalle_movimiento, "", ",cod_producto,", _
                                         ",categoria,tipo,marca,modelo,serie,existencia,", ",existencia,", "", "", "", True, True, 200, 0)
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Alinear_Grid_Detalle_Traslado()
        Dim ClsGen As New ClasesGenerales.General

        Try
            ClsGen.Alinear_GridView(ds_movimiento.Tables("detalle_movimiento_traslado"), Me.dgv_detalle_movimiento_traslado, "", "", _
                                         ",categoria,tipo,marca,modelo,serie,existencia,", ",existencia,", "", "", "", True, True, 200, 0)
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Movimiento_Nuevo()


        Dim dt As New DataTable

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
            Me.dgv_detalle_movimiento.ReadOnly = False
            Me.dgv_detalle_movimiento.AllowUserToAddRows = True

            ds_movimiento.Tables("detalle_movimiento").Rows.Clear()

        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub Movimiento_Nuevo_traslado()


        Dim dt As New DataTable

        Try
            Me.txt_numero.Text = ""
            Me.txt_comentarios.Text = ""
            Me.txt_numero.Enabled = False
            Me.txt_comentarios.Enabled = True
            Me.btn_guardar_movimiento.Visible = True
            ' Me.cmb_tipo_movimiento.Enabled = True
            ' Me.cmb_motivo_movimiento.Enabled = True
            Me.cmb_usuario_origen.Enabled = True
            Me.cmb_usuario_destino.Enabled = True
            'Me.dt_fecha_movimiento.Value = Now
            'Me.sb_grabo.Text = " "
            'Me.sb_fecha.Text = " "
            Me.dgv_detalle_movimiento_traslado.ReadOnly = False
            Me.dgv_detalle_movimiento_traslado.AllowUserToAddRows = True

            ds_movimiento.Tables("detalle_movimiento_traslado").Rows.Clear()

        Catch ex As Exception
        Finally

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

                ds_movimiento.Tables("m_tipo_movimiento").DefaultView.RowFilter = "cod_tipo_movimiento = " & Me.cmb_tipo_movimiento.SelectedValue.ToString


                ls_sql = "call pa_ins_um_act_movimiento (" & Me.cmb_tipo_movimiento.SelectedValue.ToString & "," & _
                            Me.cmb_motivo_movimiento.SelectedValue.ToString & ",'" & ls_fecha_movimiento & "','" & _
                            Me.txt_comentarios.Text & "','" & gs_usuario & "','" & Me.cmb_usuario.SelectedValue.ToString & "')"

                otrans.Ingresa(ls_sql)




                If otrans.Codigo_error = 0 Then
                
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
                        Else
                            ls_sql = "call pa_upd_um_act_producto_usuario_actual (" & dt.Rows(0).Item("cod_producto").ToString & ",'" & _
                                     Me.cmb_usuario.SelectedValue.ToString & "')"
                            otrans.Actualiza(ls_sql)

                        End If
                        i_count = i_count + 1
                    Next
                Else
                    MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

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


    Public Function Buscar_Producto(ByVal pcod_producto As String) As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable

        ls_sql = "call pa_sel_um_act_producto ('" & pcod_producto & "')"
        otrans.open()
        dt = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        Return dt
    End Function

    Private Sub Customizar_Forma()
        If Insumos Then
        Else
            Me.Text = ":: Movimiento de Activos ::"
        End If
    End Sub

    Private Sub Obtener_Activos_Usuarios()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String

        Try
            myOtrans.open()
            ds_movimiento.Tables("detalle_movimiento_traslado").Rows.Clear()

            ls_sql = "call pa_var_um_act_producto ('" & Me.cmb_usuario_origen.SelectedValue & "')"

            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = ds_movimiento.Tables("detalle_movimiento_traslado").NewRow
                dr_aux.Item("codigo") = dr.Item("codigo")
                dr_aux.Item("categoria") = dr.Item("categoria")
                dr_aux.Item("tipo") = dr.Item("tipo")
                dr_aux.Item("marca") = dr.Item("marca")
                dr_aux.Item("modelo") = dr.Item("modelo")
                dr_aux.Item("serie") = dr.Item("serie")
                dr_aux.Item("cod_producto") = dr.Item("cod_producto")

                ds_movimiento.Tables("detalle_movimiento_traslado").Rows.Add(dr_aux)

            Next




            Me.dgv_detalle_movimiento_traslado.DataSource = ds_movimiento.Tables("detalle_movimiento_traslado")
            ClsGen.Alinear_GridView(ds_movimiento.Tables("detalle_movimiento_traslado"), Me.dgv_detalle_movimiento_traslado, "", ",cantidad,cod_marca_modelo,cod_tipo_producto,cod_marca,existencia,cod_modelo,cod_categoria,descripcion,modelos_aplica,usuario_grabo,fecha_grabo,usuario_modifico,fecha_modifico,minimo,usuario_actual,imei,cod_producto,", _
                        ",codigo,categoria,tipo,marca,modelo,serie,", "", "", "", ",codigo,categoria,tipo,marca,modelo,serie,", True, True, 200, 0)


        Catch ex As Exception
        Finally
            myOtrans.Close()
            myOtrans = Nothing
            ClsGen = Nothing

        End Try

    End Sub


    Private Sub Realizar_Traslado_Equipo()
        Dim myOtrans As New Transaccional.Conexion_mysql("onBase")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i_count As Integer
        Dim inumero As Integer


        '(c) debo hacer una salida y una entrada
        Try
            myOtrans.open()
            If ds_movimiento.Tables("detalle_movimiento_traslado").Rows.Count > 0 Then

                Me.btn_guardar_movimiento.Visible = False


                ls_sql = "call pa_ins_um_act_movimiento (2,9" & ",'" & Today.ToString("yyyy-MM-dd") & "','" & _
                            Me.txt_comentarios_traslado.Text & "','" & gs_usuario & "','" & Me.cmb_usuario_origen.SelectedValue.ToString & "')"

                myOtrans.Ingresa(ls_sql)


                'ds_movimiento.Tables("m_tipo_movimiento").DefaultView.RowFilter = "cod_tipo_movimiento = " & Me.cmb_tipo_movimiento.SelectedValue.ToString

                If myOtrans.Codigo_error > 0 Then
                    MessageBox.Show(myOtrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    inumero = dt.Rows(0).Item("newid").ToString


                    For Each dr In ds_movimiento.Tables("detalle_movimiento_traslado").Rows


                        ls_sql = "call pa_ins_um_act_movimiento_detalle (" & inumero.ToString & "," & _
                                i_count.ToString & "," & dr.Item("cod_producto").ToString & "," & _
                                 "1,-1)"

                        myOtrans.Ingresa(ls_sql)

                        If myOtrans.Codigo_error > 0 Then
                            MessageBox.Show(myOtrans.descripcion_error)

                        End If
                        i_count = i_count + 1
                    Next

                End If

                ''Debo hacer el Ingreso
                i_count = 1
                ls_sql = "call pa_ins_um_act_movimiento (1,9" & ",'" & Today.ToString("yyyy-MM-dd") & "','" & _
                                            Me.txt_comentarios_traslado.Text & "','" & gs_usuario & "','" & Me.cmb_usuario_destino.SelectedValue.ToString & "')"

                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error > 0 Then
                    MessageBox.Show(myOtrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    inumero = dt.Rows(0).Item("newid").ToString


                    For Each dr In ds_movimiento.Tables("detalle_movimiento_traslado").Rows

                        ls_sql = "call pa_ins_um_act_movimiento_detalle (" & inumero.ToString & "," & _
                                i_count.ToString & "," & dr.Item("cod_producto").ToString & "," & _
                                 "1,1)"

                        myOtrans.Ingresa(ls_sql)

                        If myOtrans.Codigo_error > 0 Then
                            MessageBox.Show(myOtrans.descripcion_error)
                        Else
                            ls_sql = "call pa_upd_um_act_producto_usuario_actual (" & dr.Item("cod_producto").ToString & ",'" & _
                                     Me.cmb_usuario_destino.SelectedValue.ToString & "')"
                            myOtrans.Actualiza(ls_sql)

                        End If
                        i_count = i_count + 1
                    Next

                End If

                MessageBox.Show("Se Ingreso Correctamente el Movimiento", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Imprimir_Reporte()
            Else
                MessageBox.Show("No Hay Registros Para Guardar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Llenar_Grid()
        End Try

    End Sub


    Private Sub frm_insumos_activos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Grid()
        Llenar_Combos()
        Customizar_Forma()


    End Sub

    Private Sub m_insumos_tipos_activos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onbase", "sa", "sa", False, False, "PDF", False, "", True)
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

    Private Sub m_insumos_marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_marca"
        oform.Text = oform.Text & " Marcas"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub m_insumos_modelos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    Private Sub m_insumos_categoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_categoria"
        oform.Text = oform.Text & " Categorias"
        oform.ShowDialog(Me)
        oform.Dispose()
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

  

    Private Sub m_insumos_motivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    Private Sub btn_impresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_impresion.Click
        If Me.txt_numero.Text.Trim.Length > 0 Then
            Imprimir_Reporte()
        End If
    End Sub




    Private Sub btn_word_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_word.Click

        If Me.cmb_tipo_movimiento.Text.ToLower = "salida" Then
            'Imprimir_entrega(Me.txt_numero.Text)
        End If
        If Me.cmb_tipo_movimiento.Text.ToLower = "ingreso" Then
            'Imprimir_Recepcion(Me.txt_numero.Text)
        End If
    End Sub

    Private Sub dgv_listado_movimientos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado_movimientos.DoubleClick
        Dim nrow As Integer = Me.dgv_listado_movimientos.CurrentCell.RowIndex


        Llenar_Movimiento(Me.dgv_listado_movimientos.Item("cod_movimiento", nrow).Value.ToString, ds_insumos.Tables("listado_movimientos"))

        Me.txt_comentarios.Enabled = False
        Me.btn_guardar_movimiento.Visible = False
        Me.cmb_tipo_movimiento.Enabled = False
        Me.cmb_motivo_movimiento.Enabled = False
        Me.cmb_usuario.Enabled = False
        Me.TabControl1.SelectedTab() = Me.TabPage3
    End Sub


    Private Sub dgv_detalle_movimiento_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle_movimiento.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim c As Control
        Dim ClsGen As New ClasesGenerales.General

        Try



            If colIndex = 0 Then

                c = Me.dgv_detalle_movimiento.EditingControl
                Dim dt As DataTable
                If c.Text = "+" Then
                    'Levantar la busquedaxd
                    Dim frm_busqueda As New frm_busqueda_general_mysql
                    frm_busqueda.parametros = "codigo, descripcion,categoria,tipo_producto,marca,modelo,serie"
                    frm_busqueda.nombre_vista = "v_act_producto_existencia"
                    frm_busqueda.lista_campos = "codigo,codigo, descripcion,categoria,tipo_producto,marca,modelo,serie"
                    frm_busqueda.txt_buscar1.Focus()
                    frm_busqueda.ShowDialog(Me)

                    c.Text = frm_busqueda.resultado
                    frm_busqueda.Dispose()
                    frm_busqueda = Nothing
                    dt = Buscar_Producto(c.Text)
                Else
                    dt = Buscar_Producto(c.Text)
                End If
                If dt.Rows.Count = 1 Then
                    Me.dgv_detalle_movimiento.Item("codigo", e.RowIndex).Value = c.Text
                    Me.dgv_detalle_movimiento.Item("categoria", e.RowIndex).Value = dt.Rows(0).Item("categoria").ToString
                    Me.dgv_detalle_movimiento.Item("tipo", e.RowIndex).Value = dt.Rows(0).Item("tipo").ToString
                    Me.dgv_detalle_movimiento.Item("marca", e.RowIndex).Value = dt.Rows(0).Item("marca").ToString
                    Me.dgv_detalle_movimiento.Item("modelo", e.RowIndex).Value = dt.Rows(0).Item("modelo").ToString
                    Me.dgv_detalle_movimiento.Item("serie", e.RowIndex).Value = dt.Rows(0).Item("serie").ToString
                    Me.dgv_detalle_movimiento.Item("cantidad", e.RowIndex).Value = 0
                    Me.dgv_detalle_movimiento.Item("existencia", e.RowIndex).Value = dt.Rows(0).Item("existencia").ToString
                    ClsGen.Alinear_GridView(ds_movimiento.Tables("detalle_movimiento"), Me.dgv_detalle_movimiento, "", "", _
                                                 ",categoria,tipo,marca,modelo,existencia,serie", ",existencia,", "", "", "", True, True, 200, 0)
                Else
                    MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgv_detalle_movimiento.Item("categoria", e.RowIndex).Value = ""
                    Me.dgv_detalle_movimiento.Item("tipo", e.RowIndex).Value = ""
                    Me.dgv_detalle_movimiento.Item("marca", e.RowIndex).Value = ""
                    Me.dgv_detalle_movimiento.Item("modelo", e.RowIndex).Value = ""
                    Me.dgv_detalle_movimiento.Item("serie", e.RowIndex).Value = ""
                    Me.dgv_detalle_movimiento.Item("cantidad", e.RowIndex).Value = 0
                    Me.dgv_detalle_movimiento.Item("descripcion", e.RowIndex).Value = 0
                End If
            ElseIf colIndex = 6 Then
                If Me.cmb_tipo_movimiento.SelectedValue = 2 Then
                    If Me.dgv_detalle_movimiento.Item("cantidad", e.RowIndex).Value > Me.dgv_detalle_movimiento.Item("existencia", e.RowIndex).Value Then
                        MessageBox.Show("No Hay Suficiente Existencia ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgv_detalle_movimiento.Item("cantidad", e.RowIndex).Value = Me.dgv_detalle_movimiento.Item("existencia", e.RowIndex).Value
                    End If

                End If
            End If

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_user_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_user_ok.Click
        Obtener_Activos_Usuarios()
    End Sub

    Private Sub btn_traslado_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_traslado_guardar.Click
        If MessageBox.Show("Esta Seguro de Hacer Este Traslado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Realizar_Traslado_Equipo()
        End If
    End Sub

    Private Sub btn_nuevo_traslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_traslados.Click
        Me.btn_traslado_guardar.Visible = True
        ds_movimiento.Tables("detalle_movimiento_traslado").Rows.Clear()
    End Sub
End Class
