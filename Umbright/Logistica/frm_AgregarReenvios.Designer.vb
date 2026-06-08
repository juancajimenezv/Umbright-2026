<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AgregarReenvios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_AgregarReenvios))
        Me.btn_control = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmb_tipos = New System.Windows.Forms.ComboBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtp_fecha_vcto = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_control = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NUDcopias = New System.Windows.Forms.NumericUpDown()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dg_detalle_guia = New System.Windows.Forms.DataGrid()
        Me.txtNumeroControl = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtAyudante = New System.Windows.Forms.TextBox()
        Me.txtPiloto = New System.Windows.Forms.TextBox()
        Me.txtVehicuo = New System.Windows.Forms.TextBox()
        Me.dgvEmpresas = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_control
        '
        Me.btn_control.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_control.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_control.ForeColor = System.Drawing.Color.White
        Me.btn_control.Location = New System.Drawing.Point(667, 214)
        Me.btn_control.Name = "btn_control"
        Me.btn_control.Size = New System.Drawing.Size(24, 22)
        Me.btn_control.TabIndex = 31
        Me.btn_control.Text = "..."
        Me.btn_control.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(77, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Docto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(516, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Numero"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.DropDownWidth = 175
        Me.cmbEmpresa.Location = New System.Drawing.Point(141, 217)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(150, 21)
        Me.cmbEmpresa.TabIndex = 28
        '
        'cmb_tipos
        '
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.DropDownWidth = 175
        Me.cmb_tipos.Location = New System.Drawing.Point(382, 218)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(116, 21)
        Me.cmb_tipos.TabIndex = 29
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(566, 218)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(81, 20)
        Me.txt_numero.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Ruta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(444, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Fecha Vencimiento"
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(444, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Fecha Control"
        Me.Label10.Visible = False
        '
        'dtp_fecha_vcto
        '
        Me.dtp_fecha_vcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vcto.Location = New System.Drawing.Point(566, 52)
        Me.dtp_fecha_vcto.Name = "dtp_fecha_vcto"
        Me.dtp_fecha_vcto.Size = New System.Drawing.Size(98, 20)
        Me.dtp_fecha_vcto.TabIndex = 36
        Me.dtp_fecha_vcto.Visible = False
        '
        'dtp_fecha_control
        '
        Me.dtp_fecha_control.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_control.Location = New System.Drawing.Point(566, 29)
        Me.dtp_fecha_control.Name = "dtp_fecha_control"
        Me.dtp_fecha_control.Size = New System.Drawing.Size(98, 20)
        Me.dtp_fecha_control.TabIndex = 35
        Me.dtp_fecha_control.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(444, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Numero Control"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Ayudante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Vehiculo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Piloto"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(782, 531)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.dgvEmpresas)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.NUDcopias)
        Me.TabPage1.Controls.Add(Me.btnGrabar)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.dg_detalle_guia)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtNumeroControl)
        Me.TabPage1.Controls.Add(Me.txt_numero)
        Me.TabPage1.Controls.Add(Me.cmb_tipos)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.cmbEmpresa)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_vcto)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_control)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.btn_control)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtObservaciones)
        Me.TabPage1.Controls.Add(Me.txtRuta)
        Me.TabPage1.Controls.Add(Me.txtAyudante)
        Me.TabPage1.Controls.Add(Me.txtPiloto)
        Me.TabPage1.Controls.Add(Me.txtVehicuo)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(774, 505)
        Me.TabPage1.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(446, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Copias"
        '
        'NUDcopias
        '
        Me.NUDcopias.Location = New System.Drawing.Point(500, 80)
        Me.NUDcopias.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NUDcopias.Name = "NUDcopias"
        Me.NUDcopias.Size = New System.Drawing.Size(42, 20)
        Me.NUDcopias.TabIndex = 52
        Me.NUDcopias.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ForeColor = System.Drawing.Color.White
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGrabar.ImageIndex = 4
        Me.btnGrabar.ImageList = Me.ImageList1
        Me.btnGrabar.Location = New System.Drawing.Point(692, 93)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 66)
        Me.btnGrabar.TabIndex = 51
        Me.btnGrabar.Text = "Guardar"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 1
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(692, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 66)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Limpiar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dg_detalle_guia
        '
        Me.dg_detalle_guia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_detalle_guia.CaptionVisible = False
        Me.dg_detalle_guia.DataMember = ""
        Me.dg_detalle_guia.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_guia.Location = New System.Drawing.Point(8, 244)
        Me.dg_detalle_guia.Name = "dg_detalle_guia"
        Me.dg_detalle_guia.Size = New System.Drawing.Size(763, 255)
        Me.dg_detalle_guia.TabIndex = 50
        '
        'txtNumeroControl
        '
        Me.txtNumeroControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroControl.Location = New System.Drawing.Point(566, 6)
        Me.txtNumeroControl.Name = "txtNumeroControl"
        Me.txtNumeroControl.Size = New System.Drawing.Size(98, 20)
        Me.txtNumeroControl.TabIndex = 30
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(87, 73)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(242, 20)
        Me.txtRuta.TabIndex = 41
        '
        'txtAyudante
        '
        Me.txtAyudante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAyudante.Location = New System.Drawing.Point(87, 52)
        Me.txtAyudante.Name = "txtAyudante"
        Me.txtAyudante.ReadOnly = True
        Me.txtAyudante.Size = New System.Drawing.Size(242, 20)
        Me.txtAyudante.TabIndex = 41
        '
        'txtPiloto
        '
        Me.txtPiloto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiloto.Location = New System.Drawing.Point(87, 30)
        Me.txtPiloto.Name = "txtPiloto"
        Me.txtPiloto.ReadOnly = True
        Me.txtPiloto.Size = New System.Drawing.Size(242, 20)
        Me.txtPiloto.TabIndex = 41
        '
        'txtVehicuo
        '
        Me.txtVehicuo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicuo.Location = New System.Drawing.Point(87, 7)
        Me.txtVehicuo.Name = "txtVehicuo"
        Me.txtVehicuo.ReadOnly = True
        Me.txtVehicuo.Size = New System.Drawing.Size(242, 20)
        Me.txtVehicuo.TabIndex = 41
        '
        'dgvEmpresas
        '
        Me.dgvEmpresas.AllowUserToAddRows = False
        Me.dgvEmpresas.AllowUserToDeleteRows = False
        Me.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmpresas.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmpresas.Location = New System.Drawing.Point(87, 121)
        Me.dgvEmpresas.Name = "dgvEmpresas"
        Me.dgvEmpresas.RowHeadersWidth = 5
        Me.dgvEmpresas.Size = New System.Drawing.Size(240, 90)
        Me.dgvEmpresas.TabIndex = 54
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Empresas"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Location = New System.Drawing.Point(87, 95)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(242, 20)
        Me.txtObservaciones.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Obs."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "7.png")
        Me.ImageList1.Images.SetKeyName(1, "3.png")
        Me.ImageList1.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "Floppy-64.png")
        '
        'frm_AgregarReenvios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 531)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_AgregarReenvios"
        Me.Text = "::. Agregar Reenvios .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.NUDcopias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btn_control As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_vcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_control As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dg_detalle_guia As System.Windows.Forms.DataGrid
    Friend WithEvents txtNumeroControl As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtAyudante As System.Windows.Forms.TextBox
    Friend WithEvents txtPiloto As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicuo As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NUDcopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvEmpresas As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents ImageList1 As ImageList
End Class
