<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_lotes_picking_consolidado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_lotes_picking_consolidado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_normal = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_Lotes = New System.Windows.Forms.DataGridView()
        Me.btn_creaLote = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn_pasar = New System.Windows.Forms.Button()
        Me.btn_bajar = New System.Windows.Forms.Button()
        Me.btn_subir = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lb_tValores = New System.Windows.Forms.Label()
        Me.lb_tUnidades = New System.Windows.Forms.Label()
        Me.lb_tDocumentos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_creados = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv_Resto = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_lectura = New System.Windows.Forms.TextBox()
        Me.btn_generaDoctos = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbPickerConsolidado = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.btnEntregaFacturas = New System.Windows.Forms.Button()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.btn_controlTransporte = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.btnReimpresionConsolidado = New System.Windows.Forms.Button()
        Me.btn_refrescar_picking_consolidado = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_reFecha = New System.Windows.Forms.DateTimePicker()
        Me.btn_reImpresion = New System.Windows.Forms.Button()
        Me.btn_reGenerar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgv_reDetalle = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_normal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Lotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_creados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Resto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_reDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_normal)
        Me.GroupBox1.Location = New System.Drawing.Point(66, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 289)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asingar Documentos para Lote"
        '
        'dgv_normal
        '
        Me.dgv_normal.AllowUserToAddRows = False
        Me.dgv_normal.AllowUserToDeleteRows = False
        Me.dgv_normal.AllowUserToOrderColumns = True
        Me.dgv_normal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_normal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_normal.Location = New System.Drawing.Point(6, 12)
        Me.dgv_normal.Name = "dgv_normal"
        Me.dgv_normal.Size = New System.Drawing.Size(774, 271)
        Me.dgv_normal.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dgv_Lotes)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 82)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(723, 398)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lotes"
        '
        'dgv_Lotes
        '
        Me.dgv_Lotes.AllowUserToAddRows = False
        Me.dgv_Lotes.AllowUserToDeleteRows = False
        Me.dgv_Lotes.AllowUserToOrderColumns = True
        Me.dgv_Lotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Lotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Lotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Lotes.Location = New System.Drawing.Point(9, 20)
        Me.dgv_Lotes.Name = "dgv_Lotes"
        Me.dgv_Lotes.Size = New System.Drawing.Size(708, 361)
        Me.dgv_Lotes.TabIndex = 0
        '
        'btn_creaLote
        '
        Me.btn_creaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_creaLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_creaLote.Location = New System.Drawing.Point(1062, 6)
        Me.btn_creaLote.Name = "btn_creaLote"
        Me.btn_creaLote.Size = New System.Drawing.Size(119, 49)
        Me.btn_creaLote.TabIndex = 5
        Me.btn_creaLote.Text = "Crear Lote"
        Me.btn_creaLote.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(744, 536)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btn_pasar)
        Me.TabPage1.Controls.Add(Me.btn_bajar)
        Me.TabPage1.Controls.Add(Me.btn_subir)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txt_lectura)
        Me.TabPage1.Controls.Add(Me.btn_generaDoctos)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.cmbPickerConsolidado)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btn_creaLote)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(736, 510)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Crear Lotes"
        '
        'btn_pasar
        '
        Me.btn_pasar.Location = New System.Drawing.Point(794, 15)
        Me.btn_pasar.Name = "btn_pasar"
        Me.btn_pasar.Size = New System.Drawing.Size(115, 42)
        Me.btn_pasar.TabIndex = 32
        Me.btn_pasar.UseVisualStyleBackColor = True
        '
        'btn_bajar
        '
        Me.btn_bajar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_bajar.ForeColor = System.Drawing.Color.White
        Me.btn_bajar.Location = New System.Drawing.Point(8, 286)
        Me.btn_bajar.Name = "btn_bajar"
        Me.btn_bajar.Size = New System.Drawing.Size(52, 63)
        Me.btn_bajar.TabIndex = 31
        Me.btn_bajar.Text = "Bajar"
        Me.btn_bajar.UseVisualStyleBackColor = False
        '
        'btn_subir
        '
        Me.btn_subir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_subir.ForeColor = System.Drawing.Color.White
        Me.btn_subir.Location = New System.Drawing.Point(8, 371)
        Me.btn_subir.Name = "btn_subir"
        Me.btn_subir.Size = New System.Drawing.Size(52, 63)
        Me.btn_subir.TabIndex = 30
        Me.btn_subir.Text = "Subir"
        Me.btn_subir.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lb_tValores)
        Me.GroupBox4.Controls.Add(Me.lb_tUnidades)
        Me.GroupBox4.Controls.Add(Me.lb_tDocumentos)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.dgv_creados)
        Me.GroupBox4.Location = New System.Drawing.Point(855, 68)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(359, 538)
        Me.GroupBox4.TabIndex = 29
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Crear Lote"
        '
        'lb_tValores
        '
        Me.lb_tValores.AutoSize = True
        Me.lb_tValores.Location = New System.Drawing.Point(309, 518)
        Me.lb_tValores.Name = "lb_tValores"
        Me.lb_tValores.Size = New System.Drawing.Size(28, 13)
        Me.lb_tValores.TabIndex = 33
        Me.lb_tValores.Text = "0.00"
        '
        'lb_tUnidades
        '
        Me.lb_tUnidades.AutoSize = True
        Me.lb_tUnidades.Location = New System.Drawing.Point(309, 500)
        Me.lb_tUnidades.Name = "lb_tUnidades"
        Me.lb_tUnidades.Size = New System.Drawing.Size(28, 13)
        Me.lb_tUnidades.TabIndex = 32
        Me.lb_tUnidades.Text = "0.00"
        '
        'lb_tDocumentos
        '
        Me.lb_tDocumentos.AutoSize = True
        Me.lb_tDocumentos.Location = New System.Drawing.Point(309, 482)
        Me.lb_tDocumentos.Name = "lb_tDocumentos"
        Me.lb_tDocumentos.Size = New System.Drawing.Size(28, 13)
        Me.lb_tDocumentos.TabIndex = 31
        Me.lb_tDocumentos.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 518)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Total Valores Q:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 500)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Total Unidades:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Total Documentos:"
        '
        'dgv_creados
        '
        Me.dgv_creados.AllowUserToAddRows = False
        Me.dgv_creados.AllowUserToDeleteRows = False
        Me.dgv_creados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_creados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_creados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_creados.Location = New System.Drawing.Point(6, 16)
        Me.dgv_creados.Name = "dgv_creados"
        Me.dgv_creados.Size = New System.Drawing.Size(347, 410)
        Me.dgv_creados.TabIndex = 27
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgv_Resto)
        Me.GroupBox2.Location = New System.Drawing.Point(65, 363)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(786, 243)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resto"
        '
        'dgv_Resto
        '
        Me.dgv_Resto.AllowUserToAddRows = False
        Me.dgv_Resto.AllowUserToDeleteRows = False
        Me.dgv_Resto.AllowUserToOrderColumns = True
        Me.dgv_Resto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_Resto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Resto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Resto.Location = New System.Drawing.Point(6, 13)
        Me.dgv_Resto.Name = "dgv_Resto"
        Me.dgv_Resto.Size = New System.Drawing.Size(774, 224)
        Me.dgv_Resto.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(583, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Lectura de Barra"
        '
        'txt_lectura
        '
        Me.txt_lectura.Location = New System.Drawing.Point(632, 27)
        Me.txt_lectura.Name = "txt_lectura"
        Me.txt_lectura.Size = New System.Drawing.Size(131, 20)
        Me.txt_lectura.TabIndex = 23
        '
        'btn_generaDoctos
        '
        Me.btn_generaDoctos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generaDoctos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_generaDoctos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generaDoctos.Location = New System.Drawing.Point(66, 12)
        Me.btn_generaDoctos.Name = "btn_generaDoctos"
        Me.btn_generaDoctos.Size = New System.Drawing.Size(119, 49)
        Me.btn_generaDoctos.TabIndex = 22
        Me.btn_generaDoctos.Text = "Generar       Documentos"
        Me.btn_generaDoctos.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(244, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Picker"
        '
        'cmbPickerConsolidado
        '
        Me.cmbPickerConsolidado.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbPickerConsolidado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPickerConsolidado.DropDownWidth = 300
        Me.cmbPickerConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPickerConsolidado.FormattingEnabled = True
        Me.cmbPickerConsolidado.Items.AddRange(New Object() {"CONSOLIDADO"})
        Me.cmbPickerConsolidado.Location = New System.Drawing.Point(286, 23)
        Me.cmbPickerConsolidado.Name = "cmbPickerConsolidado"
        Me.cmbPickerConsolidado.Size = New System.Drawing.Size(205, 24)
        Me.cmbPickerConsolidado.TabIndex = 20
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.lbl_usuario)
        Me.TabPage2.Controls.Add(Me.btnEntregaFacturas)
        Me.TabPage2.Controls.Add(Me.lbl_numero)
        Me.TabPage2.Controls.Add(Me.btn_controlTransporte)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.dtp_fecha)
        Me.TabPage2.Controls.Add(Me.btnReimpresionConsolidado)
        Me.TabPage2.Controls.Add(Me.btn_refrescar_picking_consolidado)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(736, 510)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Impresion de Lotes"
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usuario.Location = New System.Drawing.Point(249, 488)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(65, 15)
        Me.lbl_usuario.TabIndex = 26
        Me.lbl_usuario.Text = "Usuario: "
        '
        'btnEntregaFacturas
        '
        Me.btnEntregaFacturas.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnEntregaFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntregaFacturas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnEntregaFacturas.ForeColor = System.Drawing.Color.White
        Me.btnEntregaFacturas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEntregaFacturas.ImageIndex = 1
        Me.btnEntregaFacturas.Location = New System.Drawing.Point(620, 10)
        Me.btnEntregaFacturas.Name = "btnEntregaFacturas"
        Me.btnEntregaFacturas.Size = New System.Drawing.Size(103, 66)
        Me.btnEntregaFacturas.TabIndex = 25
        Me.btnEntregaFacturas.Text = "Entrega de Facturas"
        Me.btnEntregaFacturas.UseVisualStyleBackColor = False
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Location = New System.Drawing.Point(463, 38)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(13, 13)
        Me.lbl_numero.TabIndex = 24
        Me.lbl_numero.Text = "0"
        Me.lbl_numero.Visible = False
        '
        'btn_controlTransporte
        '
        Me.btn_controlTransporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_controlTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_controlTransporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_controlTransporte.ForeColor = System.Drawing.Color.White
        Me.btn_controlTransporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_controlTransporte.ImageIndex = 1
        Me.btn_controlTransporte.Location = New System.Drawing.Point(510, 9)
        Me.btn_controlTransporte.Name = "btn_controlTransporte"
        Me.btn_controlTransporte.Size = New System.Drawing.Size(103, 67)
        Me.btn_controlTransporte.TabIndex = 23
        Me.btn_controlTransporte.Text = "Control de Transporte"
        Me.btn_controlTransporte.UseVisualStyleBackColor = False
        Me.btn_controlTransporte.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Fecha a Generar"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(105, 31)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(112, 20)
        Me.dtp_fecha.TabIndex = 21
        '
        'btnReimpresionConsolidado
        '
        Me.btnReimpresionConsolidado.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionConsolidado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionConsolidado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnReimpresionConsolidado.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionConsolidado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionConsolidado.ImageIndex = 1
        Me.btnReimpresionConsolidado.Location = New System.Drawing.Point(342, 9)
        Me.btnReimpresionConsolidado.Name = "btnReimpresionConsolidado"
        Me.btnReimpresionConsolidado.Size = New System.Drawing.Size(103, 67)
        Me.btnReimpresionConsolidado.TabIndex = 20
        Me.btnReimpresionConsolidado.Text = "Imprimir Picking"
        Me.btnReimpresionConsolidado.UseVisualStyleBackColor = False
        '
        'btn_refrescar_picking_consolidado
        '
        Me.btn_refrescar_picking_consolidado.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_refrescar_picking_consolidado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_refrescar_picking_consolidado.ForeColor = System.Drawing.Color.White
        Me.btn_refrescar_picking_consolidado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_refrescar_picking_consolidado.ImageIndex = 0
        Me.btn_refrescar_picking_consolidado.Location = New System.Drawing.Point(240, 8)
        Me.btn_refrescar_picking_consolidado.Name = "btn_refrescar_picking_consolidado"
        Me.btn_refrescar_picking_consolidado.Size = New System.Drawing.Size(96, 71)
        Me.btn_refrescar_picking_consolidado.TabIndex = 19
        Me.btn_refrescar_picking_consolidado.Text = "Generar"
        Me.btn_refrescar_picking_consolidado.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.dtp_reFecha)
        Me.TabPage3.Controls.Add(Me.btn_reImpresion)
        Me.TabPage3.Controls.Add(Me.btn_reGenerar)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(736, 510)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Re - Impresión"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Fecha a Generar"
        '
        'dtp_reFecha
        '
        Me.dtp_reFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_reFecha.Location = New System.Drawing.Point(116, 38)
        Me.dtp_reFecha.Name = "dtp_reFecha"
        Me.dtp_reFecha.Size = New System.Drawing.Size(112, 20)
        Me.dtp_reFecha.TabIndex = 25
        '
        'btn_reImpresion
        '
        Me.btn_reImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reImpresion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_reImpresion.ForeColor = System.Drawing.Color.White
        Me.btn_reImpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reImpresion.ImageIndex = 1
        Me.btn_reImpresion.Location = New System.Drawing.Point(353, 16)
        Me.btn_reImpresion.Name = "btn_reImpresion"
        Me.btn_reImpresion.Size = New System.Drawing.Size(103, 67)
        Me.btn_reImpresion.TabIndex = 24
        Me.btn_reImpresion.Text = "Re Imprimir Picking"
        Me.btn_reImpresion.UseVisualStyleBackColor = False
        '
        'btn_reGenerar
        '
        Me.btn_reGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reGenerar.ForeColor = System.Drawing.Color.White
        Me.btn_reGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reGenerar.ImageIndex = 0
        Me.btn_reGenerar.Location = New System.Drawing.Point(251, 17)
        Me.btn_reGenerar.Name = "btn_reGenerar"
        Me.btn_reGenerar.Size = New System.Drawing.Size(96, 66)
        Me.btn_reGenerar.TabIndex = 23
        Me.btn_reGenerar.Text = "Generar"
        Me.btn_reGenerar.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.dgv_reDetalle)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 101)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(723, 398)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lotes"
        '
        'dgv_reDetalle
        '
        Me.dgv_reDetalle.AllowUserToAddRows = False
        Me.dgv_reDetalle.AllowUserToDeleteRows = False
        Me.dgv_reDetalle.AllowUserToOrderColumns = True
        Me.dgv_reDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_reDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_reDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_reDetalle.Location = New System.Drawing.Point(9, 20)
        Me.dgv_reDetalle.Name = "dgv_reDetalle"
        Me.dgv_reDetalle.Size = New System.Drawing.Size(708, 361)
        Me.dgv_reDetalle.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 600000
        '
        'frm_lotes_picking_consolidado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(759, 550)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_lotes_picking_consolidado"
        Me.Text = "Lotes Control Transporte y Picking Consolidados"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_normal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_Lotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgv_creados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_Resto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgv_reDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_normal As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgv_Lotes As DataGridView
    Friend WithEvents btn_creaLote As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbPickerConsolidado As ComboBox
    Friend WithEvents btn_generaDoctos As Button
    Friend WithEvents btn_refrescar_picking_consolidado As Button
    Friend WithEvents btnReimpresionConsolidado As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_lectura As TextBox
    Friend WithEvents dgv_creados As DataGridView
    Friend WithEvents dgv_Resto As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_bajar As Button
    Friend WithEvents btn_subir As Button
    Friend WithEvents btn_pasar As Button
    Friend WithEvents lb_tValores As Label
    Friend WithEvents lb_tUnidades As Label
    Friend WithEvents lb_tDocumentos As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents btn_controlTransporte As Button
    Friend WithEvents lbl_numero As Label
    Friend WithEvents btnEntregaFacturas As Button
    Friend WithEvents lbl_usuario As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dgv_reDetalle As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents dtp_reFecha As DateTimePicker
    Friend WithEvents btn_reImpresion As Button
    Friend WithEvents btn_reGenerar As Button
End Class
