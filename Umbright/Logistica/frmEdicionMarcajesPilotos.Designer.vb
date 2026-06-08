<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdicionMarcajesPilotos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEdicionMarcajesPilotos))
        Me.txtNumeroDocto = New System.Windows.Forms.TextBox()
        Me.dtpFechaSalidaRampa = New System.Windows.Forms.DateTimePicker()
        Me.DTPFechaEntradaRampa = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MtxtHoraEntradaRampa = New System.Windows.Forms.MaskedTextBox()
        Me.MtxtHoraSalidaRampa = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMarcajes = New System.Windows.Forms.DataGridView()
        Me.dtpFechaEntradaCliente = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPFechaSalidaCliente = New System.Windows.Forms.DateTimePicker()
        Me.cmbEntregado = New System.Windows.Forms.ComboBox()
        Me.cmbMotivoNoEntrega = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnModificarLinea = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPiloto = New System.Windows.Forms.TextBox()
        Me.txtAuxiliar = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtNumeroControl = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mtxtHoraSalidaCliente = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtHoraEntradaCliente = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTipoDocto = New System.Windows.Forms.TextBox()
        Me.txtEmpresaDocto = New System.Windows.Forms.TextBox()
        Me.txtKilometraje = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtKilometrajeInicial = New System.Windows.Forms.TextBox()
        Me.txtKilometrajeFinal = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMarcajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNumeroDocto
        '
        Me.txtNumeroDocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroDocto.Location = New System.Drawing.Point(189, 112)
        Me.txtNumeroDocto.Name = "txtNumeroDocto"
        Me.txtNumeroDocto.ReadOnly = True
        Me.txtNumeroDocto.Size = New System.Drawing.Size(88, 20)
        Me.txtNumeroDocto.TabIndex = 17
        '
        'dtpFechaSalidaRampa
        '
        Me.dtpFechaSalidaRampa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalidaRampa.Location = New System.Drawing.Point(62, 19)
        Me.dtpFechaSalidaRampa.Name = "dtpFechaSalidaRampa"
        Me.dtpFechaSalidaRampa.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaSalidaRampa.TabIndex = 1
        '
        'DTPFechaEntradaRampa
        '
        Me.DTPFechaEntradaRampa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaEntradaRampa.Location = New System.Drawing.Point(62, 42)
        Me.DTPFechaEntradaRampa.Name = "DTPFechaEntradaRampa"
        Me.DTPFechaEntradaRampa.Size = New System.Drawing.Size(87, 20)
        Me.DTPFechaEntradaRampa.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtKilometrajeFinal)
        Me.GroupBox1.Controls.Add(Me.txtKilometrajeInicial)
        Me.GroupBox1.Controls.Add(Me.MtxtHoraEntradaRampa)
        Me.GroupBox1.Controls.Add(Me.MtxtHoraSalidaRampa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPFechaEntradaRampa)
        Me.GroupBox1.Controls.Add(Me.dtpFechaSalidaRampa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 65)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rampa"
        '
        'MtxtHoraEntradaRampa
        '
        Me.MtxtHoraEntradaRampa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtHoraEntradaRampa.Location = New System.Drawing.Point(155, 42)
        Me.MtxtHoraEntradaRampa.Mask = "00:00"
        Me.MtxtHoraEntradaRampa.Name = "MtxtHoraEntradaRampa"
        Me.MtxtHoraEntradaRampa.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.MtxtHoraEntradaRampa.Size = New System.Drawing.Size(38, 20)
        Me.MtxtHoraEntradaRampa.TabIndex = 4
        '
        'MtxtHoraSalidaRampa
        '
        Me.MtxtHoraSalidaRampa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MtxtHoraSalidaRampa.Location = New System.Drawing.Point(155, 19)
        Me.MtxtHoraSalidaRampa.Mask = "00:00"
        Me.MtxtHoraSalidaRampa.Name = "MtxtHoraSalidaRampa"
        Me.MtxtHoraSalidaRampa.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.MtxtHoraSalidaRampa.Size = New System.Drawing.Size(38, 20)
        Me.MtxtHoraSalidaRampa.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Entrada"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Salida"
        '
        'dgvMarcajes
        '
        Me.dgvMarcajes.AllowUserToAddRows = False
        Me.dgvMarcajes.AllowUserToDeleteRows = False
        Me.dgvMarcajes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMarcajes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMarcajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMarcajes.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMarcajes.Location = New System.Drawing.Point(8, 139)
        Me.dgvMarcajes.Name = "dgvMarcajes"
        Me.dgvMarcajes.ReadOnly = True
        Me.dgvMarcajes.RowHeadersWidth = 20
        Me.dgvMarcajes.Size = New System.Drawing.Size(918, 263)
        Me.dgvMarcajes.TabIndex = 12
        '
        'dtpFechaEntradaCliente
        '
        Me.dtpFechaEntradaCliente.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntradaCliente.Location = New System.Drawing.Point(283, 113)
        Me.dtpFechaEntradaCliente.Name = "dtpFechaEntradaCliente"
        Me.dtpFechaEntradaCliente.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaEntradaCliente.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(283, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Entrada Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(429, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Salida Cliente"
        '
        'DTPFechaSalidaCliente
        '
        Me.DTPFechaSalidaCliente.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaSalidaCliente.Location = New System.Drawing.Point(420, 113)
        Me.DTPFechaSalidaCliente.Name = "DTPFechaSalidaCliente"
        Me.DTPFechaSalidaCliente.Size = New System.Drawing.Size(86, 20)
        Me.DTPFechaSalidaCliente.TabIndex = 6
        '
        'cmbEntregado
        '
        Me.cmbEntregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntregado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEntregado.FormattingEnabled = True
        Me.cmbEntregado.Items.AddRange(New Object() {"1", "0"})
        Me.cmbEntregado.Location = New System.Drawing.Point(629, 111)
        Me.cmbEntregado.Name = "cmbEntregado"
        Me.cmbEntregado.Size = New System.Drawing.Size(38, 21)
        Me.cmbEntregado.TabIndex = 9
        '
        'cmbMotivoNoEntrega
        '
        Me.cmbMotivoNoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivoNoEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMotivoNoEntrega.FormattingEnabled = True
        Me.cmbMotivoNoEntrega.Location = New System.Drawing.Point(668, 111)
        Me.cmbMotivoNoEntrega.Name = "cmbMotivoNoEntrega"
        Me.cmbMotivoNoEntrega.Size = New System.Drawing.Size(212, 21)
        Me.cmbMotivoNoEntrega.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(627, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Entregado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(683, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Motivo No Entrega"
        '
        'btnModificarLinea
        '
        Me.btnModificarLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnModificarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificarLinea.ForeColor = System.Drawing.Color.White
        Me.btnModificarLinea.Location = New System.Drawing.Point(889, 111)
        Me.btnModificarLinea.Name = "btnModificarLinea"
        Me.btnModificarLinea.Size = New System.Drawing.Size(32, 23)
        Me.btnModificarLinea.TabIndex = 10
        Me.btnModificarLinea.Text = "+"
        Me.btnModificarLinea.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificarLinea.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(507, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Numero Control"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(507, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Piloto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(507, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Auxliar"
        '
        'txtPiloto
        '
        Me.txtPiloto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiloto.Enabled = False
        Me.txtPiloto.Location = New System.Drawing.Point(597, 34)
        Me.txtPiloto.Name = "txtPiloto"
        Me.txtPiloto.ReadOnly = True
        Me.txtPiloto.Size = New System.Drawing.Size(169, 20)
        Me.txtPiloto.TabIndex = 0
        '
        'txtAuxiliar
        '
        Me.txtAuxiliar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuxiliar.Enabled = False
        Me.txtAuxiliar.Location = New System.Drawing.Point(597, 56)
        Me.txtAuxiliar.Name = "txtAuxiliar"
        Me.txtAuxiliar.ReadOnly = True
        Me.txtAuxiliar.Size = New System.Drawing.Size(169, 20)
        Me.txtAuxiliar.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.ImageIndex = 0
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(851, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 52)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "1286297283_unknown.png")
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 1
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(851, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 49)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Limpiar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'txtNumeroControl
        '
        Me.txtNumeroControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroControl.Location = New System.Drawing.Point(597, 11)
        Me.txtNumeroControl.Name = "txtNumeroControl"
        Me.txtNumeroControl.Size = New System.Drawing.Size(85, 20)
        Me.txtNumeroControl.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Documento"
        '
        'mtxtHoraSalidaCliente
        '
        Me.mtxtHoraSalidaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtxtHoraSalidaCliente.Location = New System.Drawing.Point(508, 112)
        Me.mtxtHoraSalidaCliente.Mask = "00:00"
        Me.mtxtHoraSalidaCliente.Name = "mtxtHoraSalidaCliente"
        Me.mtxtHoraSalidaCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.mtxtHoraSalidaCliente.Size = New System.Drawing.Size(37, 20)
        Me.mtxtHoraSalidaCliente.TabIndex = 7
        '
        'mtxtHoraEntradaCliente
        '
        Me.mtxtHoraEntradaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtxtHoraEntradaCliente.Location = New System.Drawing.Point(368, 113)
        Me.mtxtHoraEntradaCliente.Mask = "00:00"
        Me.mtxtHoraEntradaCliente.Name = "mtxtHoraEntradaCliente"
        Me.mtxtHoraEntradaCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.mtxtHoraEntradaCliente.Size = New System.Drawing.Size(33, 20)
        Me.mtxtHoraEntradaCliente.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(554, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Km"
        '
        'txtTipoDocto
        '
        Me.txtTipoDocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDocto.Location = New System.Drawing.Point(74, 112)
        Me.txtTipoDocto.Name = "txtTipoDocto"
        Me.txtTipoDocto.ReadOnly = True
        Me.txtTipoDocto.Size = New System.Drawing.Size(114, 20)
        Me.txtTipoDocto.TabIndex = 16
        '
        'txtEmpresaDocto
        '
        Me.txtEmpresaDocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresaDocto.Location = New System.Drawing.Point(9, 112)
        Me.txtEmpresaDocto.Name = "txtEmpresaDocto"
        Me.txtEmpresaDocto.ReadOnly = True
        Me.txtEmpresaDocto.Size = New System.Drawing.Size(62, 20)
        Me.txtEmpresaDocto.TabIndex = 15
        '
        'txtKilometraje
        '
        Me.txtKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometraje.Location = New System.Drawing.Point(551, 112)
        Me.txtKilometraje.Name = "txtKilometraje"
        Me.txtKilometraje.Size = New System.Drawing.Size(72, 20)
        Me.txtKilometraje.TabIndex = 8
        Me.txtKilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(229, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Kilometraje  Inicial"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(229, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Kilometraje Final"
        '
        'txtKilometrajeInicial
        '
        Me.txtKilometrajeInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeInicial.Location = New System.Drawing.Point(341, 18)
        Me.txtKilometrajeInicial.Name = "txtKilometrajeInicial"
        Me.txtKilometrajeInicial.Size = New System.Drawing.Size(72, 20)
        Me.txtKilometrajeInicial.TabIndex = 5
        '
        'txtKilometrajeFinal
        '
        Me.txtKilometrajeFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeFinal.Location = New System.Drawing.Point(341, 41)
        Me.txtKilometrajeFinal.Name = "txtKilometrajeFinal"
        Me.txtKilometrajeFinal.Size = New System.Drawing.Size(72, 20)
        Me.txtKilometrajeFinal.TabIndex = 6
        '
        'frmEdicionMarcajesPilotos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(927, 406)
        Me.Controls.Add(Me.mtxtHoraEntradaCliente)
        Me.Controls.Add(Me.mtxtHoraSalidaCliente)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnModificarLinea)
        Me.Controls.Add(Me.cmbMotivoNoEntrega)
        Me.Controls.Add(Me.cmbEntregado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DTPFechaSalidaCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFechaEntradaCliente)
        Me.Controls.Add(Me.dgvMarcajes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtAuxiliar)
        Me.Controls.Add(Me.txtKilometraje)
        Me.Controls.Add(Me.txtNumeroControl)
        Me.Controls.Add(Me.txtPiloto)
        Me.Controls.Add(Me.txtTipoDocto)
        Me.Controls.Add(Me.txtEmpresaDocto)
        Me.Controls.Add(Me.txtNumeroDocto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Name = "frmEdicionMarcajesPilotos"
        Me.Text = "Edicion de Marcajes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMarcajes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumeroDocto As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaSalidaRampa As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaEntradaRampa As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMarcajes As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaEntradaCliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaSalidaCliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEntregado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMotivoNoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnModificarLinea As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPiloto As System.Windows.Forms.TextBox
    Friend WithEvents txtAuxiliar As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtNumeroControl As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MtxtHoraEntradaRampa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MtxtHoraSalidaRampa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtHoraSalidaCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtHoraEntradaCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDocto As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresaDocto As System.Windows.Forms.TextBox
    Friend WithEvents txtKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtKilometrajeFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtKilometrajeInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
