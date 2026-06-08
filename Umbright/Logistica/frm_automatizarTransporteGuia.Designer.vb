<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_automatizarTransporteGuia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_automatizarTransporteGuia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblVolumenRuta = New System.Windows.Forms.Label()
        Me.lblPesoRuta = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbRutaFinal = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.txObservaciones = New System.Windows.Forms.TextBox()
        Me.chkTiempoExtra = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbAuxiliar = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dtpControl = New System.Windows.Forms.DateTimePicker()
        Me.cmbPiloto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbVehiculos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblVolumen = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.dgvFacturasAsignadas = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NUDcopias = New System.Windows.Forms.NumericUpDown()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnConsolidar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_cobroTransporte = New System.Windows.Forms.TextBox()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImprimirParcial = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgvFacturasAsignadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVolumenRuta
        '
        Me.lblVolumenRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVolumenRuta.AutoSize = True
        Me.lblVolumenRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblVolumenRuta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVolumenRuta.Location = New System.Drawing.Point(407, 107)
        Me.lblVolumenRuta.Name = "lblVolumenRuta"
        Me.lblVolumenRuta.Size = New System.Drawing.Size(92, 15)
        Me.lblVolumenRuta.TabIndex = 87
        Me.lblVolumenRuta.Text = "Volumen Total: "
        '
        'lblPesoRuta
        '
        Me.lblPesoRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPesoRuta.AutoSize = True
        Me.lblPesoRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPesoRuta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPesoRuta.Location = New System.Drawing.Point(407, 128)
        Me.lblPesoRuta.Name = "lblPesoRuta"
        Me.lblPesoRuta.Size = New System.Drawing.Size(71, 15)
        Me.lblPesoRuta.TabIndex = 86
        Me.lblPesoRuta.Text = "Peso Total: "
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(407, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 17)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Ruta:"
        '
        'cmbRutaFinal
        '
        Me.cmbRutaFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRutaFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRutaFinal.FormattingEnabled = True
        Me.cmbRutaFinal.Location = New System.Drawing.Point(461, 17)
        Me.cmbRutaFinal.Name = "cmbRutaFinal"
        Me.cmbRutaFinal.Size = New System.Drawing.Size(280, 21)
        Me.cmbRutaFinal.TabIndex = 84
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(11, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 17)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "Auxiliar:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(11, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 17)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Piloto:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(11, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 17)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Obs."
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(407, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 17)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Fecha Vencimiento:"
        '
        'dtpVencimiento
        '
        Me.dtpVencimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimiento.Location = New System.Drawing.Point(537, 62)
        Me.dtpVencimiento.Name = "dtpVencimiento"
        Me.dtpVencimiento.Size = New System.Drawing.Size(96, 20)
        Me.dtpVencimiento.TabIndex = 73
        '
        'txObservaciones
        '
        Me.txObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txObservaciones.Location = New System.Drawing.Point(83, 89)
        Me.txObservaciones.Multiline = True
        Me.txObservaciones.Name = "txObservaciones"
        Me.txObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txObservaciones.Size = New System.Drawing.Size(297, 58)
        Me.txObservaciones.TabIndex = 77
        '
        'chkTiempoExtra
        '
        Me.chkTiempoExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTiempoExtra.AutoSize = True
        Me.chkTiempoExtra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkTiempoExtra.Location = New System.Drawing.Point(655, 40)
        Me.chkTiempoExtra.Name = "chkTiempoExtra"
        Me.chkTiempoExtra.Size = New System.Drawing.Size(88, 17)
        Me.chkTiempoExtra.TabIndex = 76
        Me.chkTiempoExtra.Text = "Tiempo Extra"
        Me.chkTiempoExtra.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(407, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 17)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Fecha de Salida:"
        '
        'cmbAuxiliar
        '
        Me.cmbAuxiliar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAuxiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAuxiliar.FormattingEnabled = True
        Me.cmbAuxiliar.Location = New System.Drawing.Point(83, 63)
        Me.cmbAuxiliar.Name = "cmbAuxiliar"
        Me.cmbAuxiliar.Size = New System.Drawing.Size(302, 21)
        Me.cmbAuxiliar.TabIndex = 75
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.ImageIndex = 2
        Me.btnSave.ImageList = Me.ImageList1
        Me.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSave.Location = New System.Drawing.Point(786, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 68)
        Me.btnSave.TabIndex = 78
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
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
        '
        'dtpControl
        '
        Me.dtpControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpControl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpControl.Location = New System.Drawing.Point(537, 40)
        Me.dtpControl.Name = "dtpControl"
        Me.dtpControl.Size = New System.Drawing.Size(96, 20)
        Me.dtpControl.TabIndex = 72
        '
        'cmbPiloto
        '
        Me.cmbPiloto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPiloto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPiloto.FormattingEnabled = True
        Me.cmbPiloto.Location = New System.Drawing.Point(83, 39)
        Me.cmbPiloto.Name = "cmbPiloto"
        Me.cmbPiloto.Size = New System.Drawing.Size(302, 21)
        Me.cmbPiloto.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Vehículo:"
        '
        'cmbVehiculos
        '
        Me.cmbVehiculos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVehiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVehiculos.FormattingEnabled = True
        Me.cmbVehiculos.Location = New System.Drawing.Point(83, 17)
        Me.cmbVehiculos.Name = "cmbVehiculos"
        Me.cmbVehiculos.Size = New System.Drawing.Size(302, 21)
        Me.cmbVehiculos.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(407, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Monto Total: "
        '
        'lblPeso
        '
        Me.lblPeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPeso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPeso.Location = New System.Drawing.Point(507, 127)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(14, 15)
        Me.lblPeso.TabIndex = 87
        Me.lblPeso.Text = "0"
        '
        'lblVolumen
        '
        Me.lblVolumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVolumen.AutoSize = True
        Me.lblVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblVolumen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVolumen.Location = New System.Drawing.Point(507, 109)
        Me.lblVolumen.Name = "lblVolumen"
        Me.lblVolumen.Size = New System.Drawing.Size(14, 15)
        Me.lblVolumen.TabIndex = 87
        Me.lblVolumen.Text = "0"
        '
        'lblMonto
        '
        Me.lblMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblMonto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonto.Location = New System.Drawing.Point(507, 90)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(14, 15)
        Me.lblMonto.TabIndex = 87
        Me.lblMonto.Text = "0"
        '
        'dgvFacturasAsignadas
        '
        Me.dgvFacturasAsignadas.AllowUserToAddRows = False
        Me.dgvFacturasAsignadas.AllowUserToDeleteRows = False
        Me.dgvFacturasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturasAsignadas.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFacturasAsignadas.Location = New System.Drawing.Point(8, 154)
        Me.dgvFacturasAsignadas.Name = "dgvFacturasAsignadas"
        Me.dgvFacturasAsignadas.RowHeadersVisible = False
        Me.dgvFacturasAsignadas.RowHeadersWidth = 62
        Me.dgvFacturasAsignadas.Size = New System.Drawing.Size(956, 225)
        Me.dgvFacturasAsignadas.TabIndex = 88
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(651, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "Copias"
        '
        'NUDcopias
        '
        Me.NUDcopias.Location = New System.Drawing.Point(699, 63)
        Me.NUDcopias.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NUDcopias.Name = "NUDcopias"
        Me.NUDcopias.Size = New System.Drawing.Size(42, 20)
        Me.NUDcopias.TabIndex = 89
        Me.NUDcopias.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.ImageIndex = 1
        Me.btnImprimir.ImageList = Me.ImageList1
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(786, 84)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(85, 67)
        Me.btnImprimir.TabIndex = 91
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnConsolidar
        '
        Me.btnConsolidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsolidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnConsolidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsolidar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsolidar.ForeColor = System.Drawing.Color.White
        Me.btnConsolidar.Image = CType(resources.GetObject("btnConsolidar.Image"), System.Drawing.Image)
        Me.btnConsolidar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsolidar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConsolidar.Location = New System.Drawing.Point(877, 17)
        Me.btnConsolidar.Name = "btnConsolidar"
        Me.btnConsolidar.Size = New System.Drawing.Size(89, 67)
        Me.btnConsolidar.TabIndex = 92
        Me.btnConsolidar.Text = "Consolidado"
        Me.btnConsolidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsolidar.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(600, 92)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 13)
        Me.Label16.TabIndex = 94
        Me.Label16.Text = "Transporte Q."
        '
        'txt_cobroTransporte
        '
        Me.txt_cobroTransporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cobroTransporte.Location = New System.Drawing.Point(675, 90)
        Me.txt_cobroTransporte.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_cobroTransporte.MaxLength = 5
        Me.txt_cobroTransporte.Name = "txt_cobroTransporte"
        Me.txt_cobroTransporte.Size = New System.Drawing.Size(71, 20)
        Me.txt_cobroTransporte.TabIndex = 93
        Me.txt_cobroTransporte.Text = "0.00"
        Me.txt_cobroTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_numero
        '
        Me.lbl_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_numero.ForeColor = System.Drawing.Color.Red
        Me.lbl_numero.Location = New System.Drawing.Point(675, 113)
        Me.lbl_numero.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(71, 20)
        Me.lbl_numero.TabIndex = 96
        Me.lbl_numero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(591, 116)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Numero Control"
        '
        'btnImprimirParcial
        '
        Me.btnImprimirParcial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirParcial.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirParcial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirParcial.ForeColor = System.Drawing.Color.White
        Me.btnImprimirParcial.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirParcial.ImageIndex = 3
        Me.btnImprimirParcial.ImageList = Me.ImageList2
        Me.btnImprimirParcial.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirParcial.Location = New System.Drawing.Point(877, 84)
        Me.btnImprimirParcial.Name = "btnImprimirParcial"
        Me.btnImprimirParcial.Size = New System.Drawing.Size(89, 67)
        Me.btnImprimirParcial.TabIndex = 91
        Me.btnImprimirParcial.Text = "Imprimir Parcial"
        Me.btnImprimirParcial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirParcial.UseVisualStyleBackColor = False
        Me.btnImprimirParcial.Visible = False
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
        'frm_automatizarTransporteGuia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(971, 388)
        Me.Controls.Add(Me.lbl_numero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_cobroTransporte)
        Me.Controls.Add(Me.btnConsolidar)
        Me.Controls.Add(Me.btnImprimirParcial)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.NUDcopias)
        Me.Controls.Add(Me.dgvFacturasAsignadas)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.lblVolumen)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVolumenRuta)
        Me.Controls.Add(Me.lblPesoRuta)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbRutaFinal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpVencimiento)
        Me.Controls.Add(Me.txObservaciones)
        Me.Controls.Add(Me.chkTiempoExtra)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbAuxiliar)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpControl)
        Me.Controls.Add(Me.cmbPiloto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbVehiculos)
        Me.Name = "frm_automatizarTransporteGuia"
        Me.Text = ".::. Generar Control de Transporte .::."
        CType(Me.dgvFacturasAsignadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVolumenRuta As System.Windows.Forms.Label
    Friend WithEvents lblPesoRuta As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbRutaFinal As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents chkTiempoExtra As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbAuxiliar As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dtpControl As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbPiloto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVehiculos As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents lblVolumen As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents dgvFacturasAsignadas As System.Windows.Forms.DataGridView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NUDcopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnImprimir As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnConsolidar As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_cobroTransporte As TextBox
    Friend WithEvents lbl_numero As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnImprimirParcial As Button
    Friend WithEvents ImageList2 As ImageList
End Class
