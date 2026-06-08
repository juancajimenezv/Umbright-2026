<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMonitorImpresiones_cedi
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorImpresiones_cedi))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_pedidosFACE = New System.Windows.Forms.DataGridView()
        Me.dtp_fel_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fel_final = New System.Windows.Forms.DateTimePicker()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias = New System.Windows.Forms.NumericUpDown()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnObtenerNC = New System.Windows.Forms.Button()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.btn_e_nuevo = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_e_guardar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_e_monto = New System.Windows.Forms.TextBox()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_e_comentario = New System.Windows.Forms.TextBox()
        Me.txt_e_razonSocial = New System.Windows.Forms.TextBox()
        Me.txt_e_numero = New System.Windows.Forms.TextBox()
        Me.cmb_e_empresa = New System.Windows.Forms.ComboBox()
        Me.cmb_e_tipodocto = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_e_numero_envio = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmb_e_Destino = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.dgvDetalleEnvios = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_listado_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_listado_final = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscarTraslados = New System.Windows.Forms.Button()
        Me.btnImprimirTraslados = New System.Windows.Forms.Button()
        Me.dgv_listados_traslados = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mProcesosLiberar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDetalleEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_listados_traslados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_pedidosFACE
        '
        Me.dgv_pedidosFACE.AllowUserToAddRows = False
        Me.dgv_pedidosFACE.AllowUserToDeleteRows = False
        Me.dgv_pedidosFACE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidosFACE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pedidosFACE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_pedidosFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_pedidosFACE.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_pedidosFACE.Location = New System.Drawing.Point(6, 96)
        Me.dgv_pedidosFACE.Name = "dgv_pedidosFACE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pedidosFACE.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_pedidosFACE.Size = New System.Drawing.Size(1235, 523)
        Me.dgv_pedidosFACE.TabIndex = 0
        '
        'dtp_fel_inicio
        '
        Me.dtp_fel_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_inicio.Location = New System.Drawing.Point(119, 27)
        Me.dtp_fel_inicio.Name = "dtp_fel_inicio"
        Me.dtp_fel_inicio.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_inicio.TabIndex = 1
        '
        'dtp_fel_final
        '
        Me.dtp_fel_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_final.Location = New System.Drawing.Point(119, 53)
        Me.dtp_fel_final.Name = "dtp_fel_final"
        Me.dtp_fel_final.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_final.TabIndex = 2
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
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.ImageList = Me.ImageList1
        Me.Button6.Location = New System.Drawing.Point(833, 16)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 74)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Impresión Recibos Bajo Demanda"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Fecha Final"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(429, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias
        '
        Me.nupCopias.Location = New System.Drawing.Point(543, 32)
        Me.nupCopias.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias.Name = "nupCopias"
        Me.nupCopias.Size = New System.Drawing.Size(37, 20)
        Me.nupCopias.TabIndex = 4
        Me.nupCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1257, 657)
        Me.TabControl1.TabIndex = 77
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btnObtenerNC)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.dgv_pedidosFACE)
        Me.TabPage1.Controls.Add(Me.nupCopias)
        Me.TabPage1.Controls.Add(Me.dtp_fel_inicio)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtp_fel_final)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnReimpresionNC)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1249, 631)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Imprimir Documentos"
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
        Me.btnObtenerNC.Location = New System.Drawing.Point(234, 16)
        Me.btnObtenerNC.Name = "btnObtenerNC"
        Me.btnObtenerNC.Size = New System.Drawing.Size(96, 74)
        Me.btnObtenerNC.TabIndex = 3
        Me.btnObtenerNC.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btnObtenerNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtenerNC.UseVisualStyleBackColor = False
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
        Me.btnReimpresionNC.Location = New System.Drawing.Point(629, 16)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 74)
        Me.btnReimpresionNC.TabIndex = 5
        Me.btnReimpresionNC.Text = "Impresión FEL"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.btn_Agregar)
        Me.TabPage4.Controls.Add(Me.btn_e_nuevo)
        Me.TabPage4.Controls.Add(Me.btn_e_guardar)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txt_e_monto)
        Me.TabPage4.Controls.Add(Me.dtp_Fecha)
        Me.TabPage4.Controls.Add(Me.txt_e_comentario)
        Me.TabPage4.Controls.Add(Me.txt_e_razonSocial)
        Me.TabPage4.Controls.Add(Me.txt_e_numero)
        Me.TabPage4.Controls.Add(Me.cmb_e_empresa)
        Me.TabPage4.Controls.Add(Me.cmb_e_tipodocto)
        Me.TabPage4.Controls.Add(Me.GroupBox4)
        Me.TabPage4.Controls.Add(Me.Label36)
        Me.TabPage4.Controls.Add(Me.Label35)
        Me.TabPage4.Controls.Add(Me.Label34)
        Me.TabPage4.Controls.Add(Me.Label33)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.Label31)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.TextBox8)
        Me.TabPage4.Controls.Add(Me.dgvDetalleEnvios)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1249, 631)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Trasladar Documentos"
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Agregar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.White
        Me.btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Agregar.ImageIndex = 0
        Me.btn_Agregar.ImageList = Me.ImageList1
        Me.btn_Agregar.Location = New System.Drawing.Point(503, 63)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 57)
        Me.btn_Agregar.TabIndex = 110
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'btn_e_nuevo
        '
        Me.btn_e_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_e_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_e_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_e_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_e_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_e_nuevo.ImageIndex = 1
        Me.btn_e_nuevo.ImageList = Me.ImageList2
        Me.btn_e_nuevo.Location = New System.Drawing.Point(925, 3)
        Me.btn_e_nuevo.Name = "btn_e_nuevo"
        Me.btn_e_nuevo.Size = New System.Drawing.Size(80, 56)
        Me.btn_e_nuevo.TabIndex = 110
        Me.btn_e_nuevo.Text = "Nuevo"
        Me.btn_e_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_e_nuevo.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "7.png")
        Me.ImageList2.Images.SetKeyName(1, "3.png")
        Me.ImageList2.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList2.Images.SetKeyName(3, "print_48.png")
        Me.ImageList2.Images.SetKeyName(4, "Floppy-64.png")
        '
        'btn_e_guardar
        '
        Me.btn_e_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_e_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_e_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_e_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_e_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_e_guardar.ImageIndex = 4
        Me.btn_e_guardar.ImageList = Me.ImageList2
        Me.btn_e_guardar.Location = New System.Drawing.Point(1011, 2)
        Me.btn_e_guardar.Name = "btn_e_guardar"
        Me.btn_e_guardar.Size = New System.Drawing.Size(80, 57)
        Me.btn_e_guardar.TabIndex = 110
        Me.btn_e_guardar.Text = "Grabar"
        Me.btn_e_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_e_guardar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(269, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Fecha"
        '
        'txt_e_monto
        '
        Me.txt_e_monto.BackColor = System.Drawing.SystemColors.Window
        Me.txt_e_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_monto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_e_monto.Location = New System.Drawing.Point(82, 107)
        Me.txt_e_monto.Name = "txt_e_monto"
        Me.txt_e_monto.Size = New System.Drawing.Size(126, 21)
        Me.txt_e_monto.TabIndex = 107
        Me.txt_e_monto.Text = "0.00"
        Me.txt_e_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(352, 104)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(126, 20)
        Me.dtp_Fecha.TabIndex = 108
        '
        'txt_e_comentario
        '
        Me.txt_e_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_comentario.Location = New System.Drawing.Point(82, 82)
        Me.txt_e_comentario.Name = "txt_e_comentario"
        Me.txt_e_comentario.Size = New System.Drawing.Size(396, 20)
        Me.txt_e_comentario.TabIndex = 104
        '
        'txt_e_razonSocial
        '
        Me.txt_e_razonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_razonSocial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_e_razonSocial.Location = New System.Drawing.Point(82, 56)
        Me.txt_e_razonSocial.Name = "txt_e_razonSocial"
        Me.txt_e_razonSocial.Size = New System.Drawing.Size(396, 21)
        Me.txt_e_razonSocial.TabIndex = 103
        '
        'txt_e_numero
        '
        Me.txt_e_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_numero.Location = New System.Drawing.Point(452, 30)
        Me.txt_e_numero.Name = "txt_e_numero"
        Me.txt_e_numero.Size = New System.Drawing.Size(126, 20)
        Me.txt_e_numero.TabIndex = 28
        '
        'cmb_e_empresa
        '
        Me.cmb_e_empresa.FormattingEnabled = True
        Me.cmb_e_empresa.Location = New System.Drawing.Point(82, 27)
        Me.cmb_e_empresa.Name = "cmb_e_empresa"
        Me.cmb_e_empresa.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_empresa.TabIndex = 26
        '
        'cmb_e_tipodocto
        '
        Me.cmb_e_tipodocto.FormattingEnabled = True
        Me.cmb_e_tipodocto.Location = New System.Drawing.Point(272, 27)
        Me.cmb_e_tipodocto.Name = "cmb_e_tipodocto"
        Me.cmb_e_tipodocto.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_tipodocto.TabIndex = 27
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_e_numero_envio)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.cmb_e_Destino)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Location = New System.Drawing.Point(776, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(140, 125)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        '
        'txt_e_numero_envio
        '
        Me.txt_e_numero_envio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_numero_envio.Location = New System.Drawing.Point(9, 32)
        Me.txt_e_numero_envio.Name = "txt_e_numero_envio"
        Me.txt_e_numero_envio.ReadOnly = True
        Me.txt_e_numero_envio.Size = New System.Drawing.Size(126, 20)
        Me.txt_e_numero_envio.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 58)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 13)
        Me.Label28.TabIndex = 112
        Me.Label28.Text = "Destino"
        '
        'cmb_e_Destino
        '
        Me.cmb_e_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_e_Destino.FormattingEnabled = True
        Me.cmb_e_Destino.Location = New System.Drawing.Point(9, 80)
        Me.cmb_e_Destino.Name = "cmb_e_Destino"
        Me.cmb_e_Destino.Size = New System.Drawing.Size(126, 21)
        Me.cmb_e_Destino.TabIndex = 111
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(54, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Envio No."
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(4, 107)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(37, 13)
        Me.Label36.TabIndex = 21
        Me.Label36.Text = "Monto"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(4, 85)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 13)
        Me.Label35.TabIndex = 20
        Me.Label35.Text = "Observaciones"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(4, 63)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(39, 13)
        Me.Label34.TabIndex = 19
        Me.Label34.Text = "Cliente"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(585, 31)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(32, 13)
        Me.Label33.TabIndex = 18
        Me.Label33.Text = "Barra"
        Me.Label33.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(404, 31)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(44, 13)
        Me.Label32.TabIndex = 22
        Me.Label32.Text = "Numero"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(213, 30)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 17
        Me.Label31.Text = "Documento"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(4, 30)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 13)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "Empresa"
        '
        'TextBox8
        '
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Location = New System.Drawing.Point(624, 28)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(121, 20)
        Me.TextBox8.TabIndex = 12
        Me.TextBox8.Visible = False
        '
        'dgvDetalleEnvios
        '
        Me.dgvDetalleEnvios.AllowUserToAddRows = False
        Me.dgvDetalleEnvios.AllowUserToDeleteRows = False
        Me.dgvDetalleEnvios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleEnvios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalleEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleEnvios.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDetalleEnvios.Location = New System.Drawing.Point(7, 134)
        Me.dgvDetalleEnvios.Name = "dgvDetalleEnvios"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleEnvios.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetalleEnvios.RowHeadersWidth = 20
        Me.dgvDetalleEnvios.Size = New System.Drawing.Size(1216, 411)
        Me.dgvDetalleEnvios.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtp_listado_inicio)
        Me.TabPage2.Controls.Add(Me.dtp_listado_final)
        Me.TabPage2.Controls.Add(Me.btnBuscarTraslados)
        Me.TabPage2.Controls.Add(Me.btnImprimirTraslados)
        Me.TabPage2.Controls.Add(Me.dgv_listados_traslados)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1249, 631)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "Listado de Traslados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Fecha Final"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Fecha inicio"
        Me.Label3.Visible = False
        '
        'dtp_listado_inicio
        '
        Me.dtp_listado_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_listado_inicio.Location = New System.Drawing.Point(150, 33)
        Me.dtp_listado_inicio.Name = "dtp_listado_inicio"
        Me.dtp_listado_inicio.Size = New System.Drawing.Size(95, 20)
        Me.dtp_listado_inicio.TabIndex = 114
        Me.dtp_listado_inicio.Visible = False
        '
        'dtp_listado_final
        '
        Me.dtp_listado_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_listado_final.Location = New System.Drawing.Point(150, 59)
        Me.dtp_listado_final.Name = "dtp_listado_final"
        Me.dtp_listado_final.Size = New System.Drawing.Size(95, 20)
        Me.dtp_listado_final.TabIndex = 113
        Me.dtp_listado_final.Visible = False
        '
        'btnBuscarTraslados
        '
        Me.btnBuscarTraslados.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnBuscarTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarTraslados.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBuscarTraslados.ForeColor = System.Drawing.Color.White
        Me.btnBuscarTraslados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarTraslados.ImageIndex = 1
        Me.btnBuscarTraslados.ImageList = Me.ImageList1
        Me.btnBuscarTraslados.Location = New System.Drawing.Point(292, 22)
        Me.btnBuscarTraslados.Name = "btnBuscarTraslados"
        Me.btnBuscarTraslados.Size = New System.Drawing.Size(80, 63)
        Me.btnBuscarTraslados.TabIndex = 111
        Me.btnBuscarTraslados.Text = "Buscar"
        Me.btnBuscarTraslados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarTraslados.UseVisualStyleBackColor = False
        '
        'btnImprimirTraslados
        '
        Me.btnImprimirTraslados.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirTraslados.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnImprimirTraslados.ForeColor = System.Drawing.Color.White
        Me.btnImprimirTraslados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirTraslados.ImageIndex = 3
        Me.btnImprimirTraslados.ImageList = Me.ImageList2
        Me.btnImprimirTraslados.Location = New System.Drawing.Point(790, 16)
        Me.btnImprimirTraslados.Name = "btnImprimirTraslados"
        Me.btnImprimirTraslados.Size = New System.Drawing.Size(80, 69)
        Me.btnImprimirTraslados.TabIndex = 112
        Me.btnImprimirTraslados.Text = "Imprimir"
        Me.btnImprimirTraslados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirTraslados.UseVisualStyleBackColor = False
        '
        'dgv_listados_traslados
        '
        Me.dgv_listados_traslados.AllowUserToAddRows = False
        Me.dgv_listados_traslados.AllowUserToDeleteRows = False
        Me.dgv_listados_traslados.AllowUserToResizeColumns = False
        Me.dgv_listados_traslados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listados_traslados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_listados_traslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_listados_traslados.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_listados_traslados.Location = New System.Drawing.Point(-4, 124)
        Me.dgv_listados_traslados.Name = "dgv_listados_traslados"
        Me.dgv_listados_traslados.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listados_traslados.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_listados_traslados.RowHeadersWidth = 20
        Me.dgv_listados_traslados.Size = New System.Drawing.Size(1247, 405)
        Me.dgv_listados_traslados.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1270, 24)
        Me.MenuStrip1.TabIndex = 78
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mProcesosLiberar})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'mProcesosLiberar
        '
        Me.mProcesosLiberar.Name = "mProcesosLiberar"
        Me.mProcesosLiberar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mProcesosLiberar.Size = New System.Drawing.Size(208, 22)
        Me.mProcesosLiberar.Text = "Liberar Salidas CD"
        '
        'frmMonitorImpresiones_cedi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1270, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMonitorImpresiones_cedi"
        Me.Text = "::. Monitor de Impresiones .::"
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvDetalleEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_listados_traslados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_pedidosFACE As DataGridView
    Friend WithEvents dtp_fel_inicio As DateTimePicker
    Friend WithEvents dtp_fel_final As DateTimePicker
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnReimpresionNC As Button
    Friend WithEvents btnObtenerNC As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias As NumericUpDown
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mProcesosLiberar As ToolStripMenuItem
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txt_e_numero_envio As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents dgvDetalleEnvios As DataGridView
    Friend WithEvents txt_e_numero As TextBox
    Friend WithEvents cmb_e_empresa As ComboBox
    Friend WithEvents cmb_e_tipodocto As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_e_monto As TextBox
    Friend WithEvents dtp_Fecha As DateTimePicker
    Friend WithEvents txt_e_comentario As TextBox
    Friend WithEvents txt_e_razonSocial As TextBox
    Friend WithEvents btn_e_guardar As Button
    Friend WithEvents btn_e_nuevo As Button
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents cmb_e_Destino As ComboBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnBuscarTraslados As Button
    Friend WithEvents btnImprimirTraslados As Button
    Friend WithEvents dgv_listados_traslados As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_listado_inicio As DateTimePicker
    Friend WithEvents dtp_listado_final As DateTimePicker
End Class
