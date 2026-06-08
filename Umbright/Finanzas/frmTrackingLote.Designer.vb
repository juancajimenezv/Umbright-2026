<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrackingLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrackingLote))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.dgvEncabezado = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblNumeroTraslado = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtResponsableTraslado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtNumeroLoteTraslado = New System.Windows.Forms.TextBox()
        Me.lblMultiple = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgregarTraslado = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDoctosTraslado = New System.Windows.Forms.TextBox()
        Me.txtMontoTraslado = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtComentariosTraslado = New System.Windows.Forms.TextBox()
        Me.cmbSiguientePaso = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtCantidadLotes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvTraslado = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtComentariosRecepcion = New System.Windows.Forms.TextBox()
        Me.dtpAlRecepcionTraslados = New System.Windows.Forms.DateTimePicker()
        Me.dtpDelRecepcionTraslados = New System.Windows.Forms.DateTimePicker()
        Me.btnProcesarRecepcionTraslados = New System.Windows.Forms.Button()
        Me.dgvDetalleRecepcion = New System.Windows.Forms.DataGridView()
        Me.btnGenerarRecepcionTraslados = New System.Windows.Forms.Button()
        Me.dgvListadoRecepcion = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDetalleRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListadoRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(2, 10)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1038, 613)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.dtpFechaFinal)
        Me.TabPage2.Controls.Add(Me.dtpFechaInicio)
        Me.TabPage2.Controls.Add(Me.btnActualizar)
        Me.TabPage2.Controls.Add(Me.dgvDetalle)
        Me.TabPage2.Controls.Add(Me.dgvEncabezado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(1030, 587)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tracking"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(110, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Al"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(110, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Del"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(182, 37)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaFinal.TabIndex = 7
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(182, 11)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaInicio.TabIndex = 6
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.ImageIndex = 2
        Me.btnActualizar.Location = New System.Drawing.Point(317, 11)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(71, 45)
        Me.btnActualizar.TabIndex = 2
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(4, 301)
        Me.dgvDetalle.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 21
        Me.dgvDetalle.RowTemplate.Height = 24
        Me.dgvDetalle.Size = New System.Drawing.Size(1023, 282)
        Me.dgvDetalle.TabIndex = 0
        '
        'dgvEncabezado
        '
        Me.dgvEncabezado.AllowUserToAddRows = False
        Me.dgvEncabezado.AllowUserToDeleteRows = False
        Me.dgvEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEncabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEncabezado.Location = New System.Drawing.Point(4, 61)
        Me.dgvEncabezado.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvEncabezado.Name = "dgvEncabezado"
        Me.dgvEncabezado.ReadOnly = True
        Me.dgvEncabezado.RowHeadersWidth = 21
        Me.dgvEncabezado.RowTemplate.Height = 24
        Me.dgvEncabezado.Size = New System.Drawing.Size(1023, 236)
        Me.dgvEncabezado.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.lblNumeroTraslado)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txtCantidadLotes)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.dgvTraslado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1030, 587)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Operaciones y Traslados"
        '
        'lblNumeroTraslado
        '
        Me.lblNumeroTraslado.AutoSize = True
        Me.lblNumeroTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroTraslado.Location = New System.Drawing.Point(587, 36)
        Me.lblNumeroTraslado.Name = "lblNumeroTraslado"
        Me.lblNumeroTraslado.Size = New System.Drawing.Size(46, 31)
        Me.lblNumeroTraslado.TabIndex = 9
        Me.lblNumeroTraslado.Text = "00"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtResponsableTraslado)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtEstado)
        Me.GroupBox2.Controls.Add(Me.txtNumeroLoteTraslado)
        Me.GroupBox2.Controls.Add(Me.lblMultiple)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnAgregarTraslado)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDoctosTraslado)
        Me.GroupBox2.Controls.Add(Me.txtMontoTraslado)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 135)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(980, 56)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lote"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(633, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Resp."
        '
        'txtResponsableTraslado
        '
        Me.txtResponsableTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResponsableTraslado.Location = New System.Drawing.Point(674, 20)
        Me.txtResponsableTraslado.Name = "txtResponsableTraslado"
        Me.txtResponsableTraslado.ReadOnly = True
        Me.txtResponsableTraslado.Size = New System.Drawing.Size(176, 20)
        Me.txtResponsableTraslado.TabIndex = 11
        Me.txtResponsableTraslado.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(469, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Estado"
        '
        'txtEstado
        '
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.Location = New System.Drawing.Point(514, 20)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(113, 20)
        Me.txtEstado.TabIndex = 9
        Me.txtEstado.TabStop = False
        '
        'txtNumeroLoteTraslado
        '
        Me.txtNumeroLoteTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroLoteTraslado.Location = New System.Drawing.Point(180, 18)
        Me.txtNumeroLoteTraslado.Name = "txtNumeroLoteTraslado"
        Me.txtNumeroLoteTraslado.Size = New System.Drawing.Size(57, 20)
        Me.txtNumeroLoteTraslado.TabIndex = 5
        '
        'lblMultiple
        '
        Me.lblMultiple.AutoSize = True
        Me.lblMultiple.Location = New System.Drawing.Point(8, 22)
        Me.lblMultiple.Name = "lblMultiple"
        Me.lblMultiple.Size = New System.Drawing.Size(43, 13)
        Me.lblMultiple.TabIndex = 4
        Me.lblMultiple.Text = "Multiple"
        Me.lblMultiple.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(134, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Numero"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Monto"
        '
        'btnAgregarTraslado
        '
        Me.btnAgregarTraslado.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAgregarTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarTraslado.ForeColor = System.Drawing.Color.White
        Me.btnAgregarTraslado.ImageIndex = 3
        Me.btnAgregarTraslado.ImageList = Me.ImageList2
        Me.btnAgregarTraslado.Location = New System.Drawing.Point(898, 15)
        Me.btnAgregarTraslado.Name = "btnAgregarTraslado"
        Me.btnAgregarTraslado.Size = New System.Drawing.Size(45, 36)
        Me.btnAgregarTraslado.TabIndex = 6
        Me.btnAgregarTraslado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregarTraslado.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(353, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "No. Doctos"
        '
        'txtDoctosTraslado
        '
        Me.txtDoctosTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoctosTraslado.Location = New System.Drawing.Point(420, 18)
        Me.txtDoctosTraslado.Name = "txtDoctosTraslado"
        Me.txtDoctosTraslado.ReadOnly = True
        Me.txtDoctosTraslado.Size = New System.Drawing.Size(43, 20)
        Me.txtDoctosTraslado.TabIndex = 5
        Me.txtDoctosTraslado.TabStop = False
        '
        'txtMontoTraslado
        '
        Me.txtMontoTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoTraslado.Location = New System.Drawing.Point(280, 18)
        Me.txtMontoTraslado.Name = "txtMontoTraslado"
        Me.txtMontoTraslado.ReadOnly = True
        Me.txtMontoTraslado.Size = New System.Drawing.Size(72, 20)
        Me.txtMontoTraslado.TabIndex = 5
        Me.txtMontoTraslado.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtComentariosTraslado)
        Me.GroupBox1.Controls.Add(Me.cmbSiguientePaso)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(44, 32)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(378, 99)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'txtComentariosTraslado
        '
        Me.txtComentariosTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentariosTraslado.Location = New System.Drawing.Point(83, 42)
        Me.txtComentariosTraslado.Multiline = True
        Me.txtComentariosTraslado.Name = "txtComentariosTraslado"
        Me.txtComentariosTraslado.Size = New System.Drawing.Size(262, 43)
        Me.txtComentariosTraslado.TabIndex = 3
        '
        'cmbSiguientePaso
        '
        Me.cmbSiguientePaso.FormattingEnabled = True
        Me.cmbSiguientePaso.Location = New System.Drawing.Point(83, 16)
        Me.cmbSiguientePaso.Name = "cmbSiguientePaso"
        Me.cmbSiguientePaso.Size = New System.Drawing.Size(262, 21)
        Me.cmbSiguientePaso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Comentarios"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(637, 525)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Cantidad Lotes"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.ImageIndex = 2
        Me.Button2.Location = New System.Drawing.Point(878, 509)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 45)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Procesar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.ImageIndex = 0
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(836, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 68)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Nuevo"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
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
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 2
        Me.Button3.ImageList = Me.ImageList2
        Me.Button3.Location = New System.Drawing.Point(914, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 68)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Guardar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'txtCantidadLotes
        '
        Me.txtCantidadLotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCantidadLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadLotes.Location = New System.Drawing.Point(730, 524)
        Me.txtCantidadLotes.Name = "txtCantidadLotes"
        Me.txtCantidadLotes.ReadOnly = True
        Me.txtCantidadLotes.Size = New System.Drawing.Size(72, 20)
        Me.txtCantidadLotes.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(498, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Traslado No."
        '
        'dgvTraslado
        '
        Me.dgvTraslado.AllowUserToAddRows = False
        Me.dgvTraslado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTraslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTraslado.Location = New System.Drawing.Point(6, 196)
        Me.dgvTraslado.Name = "dgvTraslado"
        Me.dgvTraslado.ReadOnly = True
        Me.dgvTraslado.RowHeadersWidth = 20
        Me.dgvTraslado.Size = New System.Drawing.Size(1018, 307)
        Me.dgvTraslado.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.txtComentariosRecepcion)
        Me.TabPage3.Controls.Add(Me.dtpAlRecepcionTraslados)
        Me.TabPage3.Controls.Add(Me.dtpDelRecepcionTraslados)
        Me.TabPage3.Controls.Add(Me.btnProcesarRecepcionTraslados)
        Me.TabPage3.Controls.Add(Me.dgvDetalleRecepcion)
        Me.TabPage3.Controls.Add(Me.btnGenerarRecepcionTraslados)
        Me.TabPage3.Controls.Add(Me.dgvListadoRecepcion)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1030, 587)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Recepcion Traslados"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(386, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Comentarios de Recepcion"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(42, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Al"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(42, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(23, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Del"
        '
        'txtComentariosRecepcion
        '
        Me.txtComentariosRecepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentariosRecepcion.Location = New System.Drawing.Point(527, 9)
        Me.txtComentariosRecepcion.Multiline = True
        Me.txtComentariosRecepcion.Name = "txtComentariosRecepcion"
        Me.txtComentariosRecepcion.Size = New System.Drawing.Size(262, 43)
        Me.txtComentariosRecepcion.TabIndex = 10
        '
        'dtpAlRecepcionTraslados
        '
        Me.dtpAlRecepcionTraslados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAlRecepcionTraslados.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAlRecepcionTraslados.Location = New System.Drawing.Point(95, 32)
        Me.dtpAlRecepcionTraslados.Name = "dtpAlRecepcionTraslados"
        Me.dtpAlRecepcionTraslados.Size = New System.Drawing.Size(109, 20)
        Me.dtpAlRecepcionTraslados.TabIndex = 9
        '
        'dtpDelRecepcionTraslados
        '
        Me.dtpDelRecepcionTraslados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDelRecepcionTraslados.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDelRecepcionTraslados.Location = New System.Drawing.Point(95, 6)
        Me.dtpDelRecepcionTraslados.Name = "dtpDelRecepcionTraslados"
        Me.dtpDelRecepcionTraslados.Size = New System.Drawing.Size(109, 20)
        Me.dtpDelRecepcionTraslados.TabIndex = 8
        '
        'btnProcesarRecepcionTraslados
        '
        Me.btnProcesarRecepcionTraslados.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesarRecepcionTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesarRecepcionTraslados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesarRecepcionTraslados.ForeColor = System.Drawing.Color.White
        Me.btnProcesarRecepcionTraslados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesarRecepcionTraslados.ImageIndex = 3
        Me.btnProcesarRecepcionTraslados.ImageList = Me.ImageList2
        Me.btnProcesarRecepcionTraslados.Location = New System.Drawing.Point(848, 8)
        Me.btnProcesarRecepcionTraslados.Name = "btnProcesarRecepcionTraslados"
        Me.btnProcesarRecepcionTraslados.Size = New System.Drawing.Size(107, 58)
        Me.btnProcesarRecepcionTraslados.TabIndex = 6
        Me.btnProcesarRecepcionTraslados.Text = "Recibir"
        Me.btnProcesarRecepcionTraslados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesarRecepcionTraslados.UseVisualStyleBackColor = False
        '
        'dgvDetalleRecepcion
        '
        Me.dgvDetalleRecepcion.AllowUserToAddRows = False
        Me.dgvDetalleRecepcion.AllowUserToDeleteRows = False
        Me.dgvDetalleRecepcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleRecepcion.Location = New System.Drawing.Point(6, 292)
        Me.dgvDetalleRecepcion.Name = "dgvDetalleRecepcion"
        Me.dgvDetalleRecepcion.RowHeadersWidth = 20
        Me.dgvDetalleRecepcion.Size = New System.Drawing.Size(1018, 287)
        Me.dgvDetalleRecepcion.TabIndex = 5
        '
        'btnGenerarRecepcionTraslados
        '
        Me.btnGenerarRecepcionTraslados.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarRecepcionTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarRecepcionTraslados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarRecepcionTraslados.ForeColor = System.Drawing.Color.White
        Me.btnGenerarRecepcionTraslados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerarRecepcionTraslados.ImageIndex = 1
        Me.btnGenerarRecepcionTraslados.ImageList = Me.ImageList1
        Me.btnGenerarRecepcionTraslados.Location = New System.Drawing.Point(229, 4)
        Me.btnGenerarRecepcionTraslados.Name = "btnGenerarRecepcionTraslados"
        Me.btnGenerarRecepcionTraslados.Size = New System.Drawing.Size(110, 62)
        Me.btnGenerarRecepcionTraslados.TabIndex = 4
        Me.btnGenerarRecepcionTraslados.Text = "Generar"
        Me.btnGenerarRecepcionTraslados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerarRecepcionTraslados.UseVisualStyleBackColor = False
        '
        'dgvListadoRecepcion
        '
        Me.dgvListadoRecepcion.AllowUserToAddRows = False
        Me.dgvListadoRecepcion.AllowUserToDeleteRows = False
        Me.dgvListadoRecepcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoRecepcion.Location = New System.Drawing.Point(6, 72)
        Me.dgvListadoRecepcion.Name = "dgvListadoRecepcion"
        Me.dgvListadoRecepcion.RowHeadersWidth = 20
        Me.dgvListadoRecepcion.Size = New System.Drawing.Size(1018, 214)
        Me.dgvListadoRecepcion.TabIndex = 3
        '
        'frmTrackingLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 623)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmTrackingLote"
        Me.Text = "::. Tracking Lote - Cajas Chicas .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvDetalleRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListadoRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvEncabezado As DataGridView
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents btnAgregarTraslado As Button
    Friend WithEvents txtDoctosTraslado As TextBox
    Friend WithEvents txtMontoTraslado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNumeroLoteTraslado As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtComentariosTraslado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSiguientePaso As ComboBox
    Friend WithEvents dgvTraslado As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCantidadLotes As TextBox
    Friend WithEvents lblMultiple As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtResponsableTraslado As TextBox
    Friend WithEvents lblNumeroTraslado As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpAlRecepcionTraslados As DateTimePicker
    Friend WithEvents dtpDelRecepcionTraslados As DateTimePicker
    Friend WithEvents btnProcesarRecepcionTraslados As Button
    Friend WithEvents dgvDetalleRecepcion As DataGridView
    Friend WithEvents btnGenerarRecepcionTraslados As Button
    Friend WithEvents dgvListadoRecepcion As DataGridView
    Friend WithEvents txtComentariosRecepcion As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
End Class
