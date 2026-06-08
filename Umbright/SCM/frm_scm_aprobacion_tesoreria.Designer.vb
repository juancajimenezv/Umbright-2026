<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_scm_aprobacion_tesoreria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_aprobacion_tesoreria))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtMontoAprobado = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaDespacho = New System.Windows.Forms.DateTimePicker()
        Me.Proveedor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.cmdMoneda = New System.Windows.Forms.ComboBox()
        Me.txtTasaCambio = New System.Windows.Forms.TextBox()
        Me.btnBuscaProveedor = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEmpresaPedido = New System.Windows.Forms.TextBox()
        Me.txtNumeroPedido = New System.Windows.Forms.TextBox()
        Me.txtObservacionesPedido = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudDiasCredito = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBU = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaCopac = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudDiasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.ImageIndex = 0
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(461, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 57)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "1286298659_button_cancel.png")
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCerrar.ImageKey = "1286298659_button_cancel.png"
        Me.btnCerrar.ImageList = Me.ImageList1
        Me.btnCerrar.Location = New System.Drawing.Point(461, 83)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 56)
        Me.btnCerrar.TabIndex = 22
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'txtMontoAprobado
        '
        Me.txtMontoAprobado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoAprobado.Location = New System.Drawing.Point(110, 142)
        Me.txtMontoAprobado.Name = "txtMontoAprobado"
        Me.txtMontoAprobado.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoAprobado.TabIndex = 6
        Me.txtMontoAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComentario
        '
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.Location = New System.Drawing.Point(110, 241)
        Me.txtComentario.MaxLength = 250
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(283, 96)
        Me.txtComentario.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Monto Aprobado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha Despacho"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Observaciones"
        '
        'dtpFechaDespacho
        '
        Me.dtpFechaDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDespacho.Location = New System.Drawing.Point(340, 189)
        Me.dtpFechaDespacho.Name = "dtpFechaDespacho"
        Me.dtpFechaDespacho.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaDespacho.TabIndex = 14
        '
        'Proveedor
        '
        Me.Proveedor.AutoSize = True
        Me.Proveedor.Location = New System.Drawing.Point(12, 99)
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Size = New System.Drawing.Size(56, 13)
        Me.Proveedor.TabIndex = 2
        Me.Proveedor.Text = "Proveedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Moneda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tasa Cambio"
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodProveedor.Location = New System.Drawing.Point(109, 97)
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.Size = New System.Drawing.Size(87, 20)
        Me.txtCodProveedor.TabIndex = 1
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreProveedor.Enabled = False
        Me.txtNombreProveedor.Location = New System.Drawing.Point(225, 97)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(230, 20)
        Me.txtNombreProveedor.TabIndex = 2
        '
        'cmdMoneda
        '
        Me.cmdMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmdMoneda.FormattingEnabled = True
        Me.cmdMoneda.Location = New System.Drawing.Point(340, 135)
        Me.cmdMoneda.Name = "cmdMoneda"
        Me.cmdMoneda.Size = New System.Drawing.Size(121, 21)
        Me.cmdMoneda.TabIndex = 8
        '
        'txtTasaCambio
        '
        Me.txtTasaCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaCambio.Location = New System.Drawing.Point(109, 165)
        Me.txtTasaCambio.Name = "txtTasaCambio"
        Me.txtTasaCambio.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaCambio.TabIndex = 10
        Me.txtTasaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBuscaProveedor
        '
        Me.btnBuscaProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnBuscaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscaProveedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaProveedor.ForeColor = System.Drawing.Color.White
        Me.btnBuscaProveedor.Location = New System.Drawing.Point(196, 95)
        Me.btnBuscaProveedor.Name = "btnBuscaProveedor"
        Me.btnBuscaProveedor.Size = New System.Drawing.Size(29, 22)
        Me.btnBuscaProveedor.TabIndex = 25
        Me.btnBuscaProveedor.Text = "..."
        Me.btnBuscaProveedor.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEmpresaPedido)
        Me.GroupBox1.Controls.Add(Me.txtNumeroPedido)
        Me.GroupBox1.Controls.Add(Me.txtObservacionesPedido)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 83)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'txtEmpresaPedido
        '
        Me.txtEmpresaPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresaPedido.Location = New System.Drawing.Point(97, 10)
        Me.txtEmpresaPedido.Name = "txtEmpresaPedido"
        Me.txtEmpresaPedido.Size = New System.Drawing.Size(113, 20)
        Me.txtEmpresaPedido.TabIndex = 0
        '
        'txtNumeroPedido
        '
        Me.txtNumeroPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPedido.Location = New System.Drawing.Point(293, 10)
        Me.txtNumeroPedido.Name = "txtNumeroPedido"
        Me.txtNumeroPedido.Size = New System.Drawing.Size(135, 20)
        Me.txtNumeroPedido.TabIndex = 0
        '
        'txtObservacionesPedido
        '
        Me.txtObservacionesPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacionesPedido.Location = New System.Drawing.Point(15, 36)
        Me.txtObservacionesPedido.Multiline = True
        Me.txtObservacionesPedido.Name = "txtObservacionesPedido"
        Me.txtObservacionesPedido.Size = New System.Drawing.Size(413, 41)
        Me.txtObservacionesPedido.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(231, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Pedido"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Empresa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Procedencia"
        '
        'cmbOrigen
        '
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(109, 119)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(121, 21)
        Me.cmbOrigen.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(243, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Dias Credito"
        '
        'nudDiasCredito
        '
        Me.nudDiasCredito.Location = New System.Drawing.Point(340, 165)
        Me.nudDiasCredito.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.nudDiasCredito.Name = "nudDiasCredito"
        Me.nudDiasCredito.Size = New System.Drawing.Size(74, 20)
        Me.nudDiasCredito.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BUM"
        '
        'cmbBU
        '
        Me.cmbBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBU.FormattingEnabled = True
        Me.cmbBU.Location = New System.Drawing.Point(110, 214)
        Me.cmbBU.Name = "cmbBU"
        Me.cmbBU.Size = New System.Drawing.Size(283, 21)
        Me.cmbBU.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Fecha COPAC"
        '
        'dtpFechaCopac
        '
        Me.dtpFechaCopac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCopac.Location = New System.Drawing.Point(110, 191)
        Me.dtpFechaCopac.Name = "dtpFechaCopac"
        Me.dtpFechaCopac.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaCopac.TabIndex = 28
        '
        'frm_scm_aprobacion_tesoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(538, 368)
        Me.Controls.Add(Me.dtpFechaCopac)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbBU)
        Me.Controls.Add(Me.nudDiasCredito)
        Me.Controls.Add(Me.cmbOrigen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBuscaProveedor)
        Me.Controls.Add(Me.cmdMoneda)
        Me.Controls.Add(Me.dtpFechaDespacho)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Proveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.txtNombreProveedor)
        Me.Controls.Add(Me.txtCodProveedor)
        Me.Controls.Add(Me.txtTasaCambio)
        Me.Controls.Add(Me.txtMontoAprobado)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Name = "frm_scm_aprobacion_tesoreria"
        Me.Text = "::. Aprobacion Tesoreria .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudDiasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtMontoAprobado As System.Windows.Forms.TextBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Proveedor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents cmdMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtTasaCambio As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaProveedor As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmpresaPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nudDiasCredito As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBU As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaCopac As System.Windows.Forms.DateTimePicker
End Class
