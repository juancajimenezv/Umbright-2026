<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tracking_Pagos_Electronicos_Tesoreria
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.btn_Enviar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Verifica = New System.Windows.Forms.Button()
        Me.tb_Verifica = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.btnAplicarFecha = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtLoteAsigna = New System.Windows.Forms.TextBox()
        Me.btnAsignarLote = New System.Windows.Forms.Button()
        Me.btn_valida_proceso = New System.Windows.Forms.Button()
        Me.lbl_lote = New System.Windows.Forms.Label()
        Me.cmbCuentaBanco = New System.Windows.Forms.ComboBox()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTasa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(990, 353)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AllowUserToAddRows = False
        Me.dgv_Detalle.AllowUserToOrderColumns = True
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 16)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.RowHeadersWidth = 62
        Me.dgv_Detalle.Size = New System.Drawing.Size(978, 331)
        Me.dgv_Detalle.TabIndex = 0
        '
        'btn_Enviar
        '
        Me.btn_Enviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Enviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Enviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Enviar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Enviar.Location = New System.Drawing.Point(599, 360)
        Me.btn_Enviar.Name = "btn_Enviar"
        Me.btn_Enviar.Size = New System.Drawing.Size(89, 66)
        Me.btn_Enviar.TabIndex = 1
        Me.btn_Enviar.Text = "Enviar a Tesorería"
        Me.btn_Enviar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Cancelar.Location = New System.Drawing.Point(703, 360)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(89, 66)
        Me.btn_Cancelar.TabIndex = 2
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Verifica
        '
        Me.btn_Verifica.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Verifica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Verifica.Location = New System.Drawing.Point(117, 11)
        Me.btn_Verifica.Name = "btn_Verifica"
        Me.btn_Verifica.Size = New System.Drawing.Size(75, 23)
        Me.btn_Verifica.TabIndex = 3
        Me.btn_Verifica.Text = "Verifica"
        Me.btn_Verifica.UseVisualStyleBackColor = False
        '
        'tb_Verifica
        '
        Me.tb_Verifica.Location = New System.Drawing.Point(6, 32)
        Me.tb_Verifica.Name = "tb_Verifica"
        Me.tb_Verifica.Size = New System.Drawing.Size(87, 20)
        Me.tb_Verifica.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox2.Controls.Add(Me.tb_Verifica)
        Me.GroupBox2.Controls.Add(Me.btn_Verifica)
        Me.GroupBox2.Location = New System.Drawing.Point(798, 360)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 60)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(6, 10)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(87, 20)
        Me.dtp_Fecha.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dtpFechaAsignacion)
        Me.GroupBox3.Controls.Add(Me.btnAplicarFecha)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 366)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 60)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Asignar Fecha"
        '
        'dtpFechaAsignacion
        '
        Me.dtpFechaAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAsignacion.Location = New System.Drawing.Point(17, 20)
        Me.dtpFechaAsignacion.Name = "dtpFechaAsignacion"
        Me.dtpFechaAsignacion.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaAsignacion.TabIndex = 5
        '
        'btnAplicarFecha
        '
        Me.btnAplicarFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicarFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnAplicarFecha.Location = New System.Drawing.Point(120, 11)
        Me.btnAplicarFecha.Name = "btnAplicarFecha"
        Me.btnAplicarFecha.Size = New System.Drawing.Size(75, 42)
        Me.btnAplicarFecha.TabIndex = 3
        Me.btnAplicarFecha.Text = "Aplicar"
        Me.btnAplicarFecha.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtLoteAsigna)
        Me.GroupBox4.Controls.Add(Me.btnAsignarLote)
        Me.GroupBox4.Location = New System.Drawing.Point(226, 369)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(201, 57)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Asignar Debito"
        '
        'txtLoteAsigna
        '
        Me.txtLoteAsigna.Location = New System.Drawing.Point(6, 23)
        Me.txtLoteAsigna.Name = "txtLoteAsigna"
        Me.txtLoteAsigna.Size = New System.Drawing.Size(87, 20)
        Me.txtLoteAsigna.TabIndex = 8
        '
        'btnAsignarLote
        '
        Me.btnAsignarLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAsignarLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignarLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignarLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnAsignarLote.Location = New System.Drawing.Point(120, 11)
        Me.btnAsignarLote.Name = "btnAsignarLote"
        Me.btnAsignarLote.Size = New System.Drawing.Size(75, 42)
        Me.btnAsignarLote.TabIndex = 3
        Me.btnAsignarLote.Text = "Aplicar"
        Me.btnAsignarLote.UseVisualStyleBackColor = False
        '
        'btn_valida_proceso
        '
        Me.btn_valida_proceso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_valida_proceso.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_valida_proceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_valida_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_valida_proceso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_valida_proceso.Location = New System.Drawing.Point(498, 361)
        Me.btn_valida_proceso.Name = "btn_valida_proceso"
        Me.btn_valida_proceso.Size = New System.Drawing.Size(89, 66)
        Me.btn_valida_proceso.TabIndex = 8
        Me.btn_valida_proceso.Text = "Validar Proceso"
        Me.btn_valida_proceso.UseVisualStyleBackColor = False
        '
        'lbl_lote
        '
        Me.lbl_lote.AutoSize = True
        Me.lbl_lote.Location = New System.Drawing.Point(445, 395)
        Me.lbl_lote.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_lote.Name = "lbl_lote"
        Me.lbl_lote.Size = New System.Drawing.Size(28, 13)
        Me.lbl_lote.TabIndex = 9
        Me.lbl_lote.Text = "Lote"
        '
        'cmbCuentaBanco
        '
        Me.cmbCuentaBanco.FormattingEnabled = True
        Me.cmbCuentaBanco.Location = New System.Drawing.Point(1002, 109)
        Me.cmbCuentaBanco.Name = "cmbCuentaBanco"
        Me.cmbCuentaBanco.Size = New System.Drawing.Size(121, 21)
        Me.cmbCuentaBanco.TabIndex = 10
        '
        'cmbMoneda
        '
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(1002, 161)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(121, 21)
        Me.cmbMoneda.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.830189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1004, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cuenta Banco:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.830189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1005, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Moneda:"
        '
        'cmbBanco
        '
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(1002, 58)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(121, 21)
        Me.cmbBanco.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.830189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1003, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Banco:"
        '
        'txtTasa
        '
        Me.txtTasa.Location = New System.Drawing.Point(1002, 216)
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(87, 20)
        Me.txtTasa.TabIndex = 16
        Me.txtTasa.Text = "1.00"
        Me.txtTasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.830189!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1005, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Tasa:"
        '
        'Frm_Tracking_Pagos_Electronicos_Tesoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1135, 438)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTasa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbBanco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMoneda)
        Me.Controls.Add(Me.cmbCuentaBanco)
        Me.Controls.Add(Me.lbl_lote)
        Me.Controls.Add(Me.btn_valida_proceso)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Enviar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Tracking_Pagos_Electronicos_Tesoreria"
        Me.Text = "Crea Nota Debito en Flexline"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_Detalle As DataGridView
    Friend WithEvents btn_Enviar As Button
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents btn_Verifica As Button
    Friend WithEvents tb_Verifica As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtp_Fecha As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpFechaAsignacion As DateTimePicker
    Friend WithEvents btnAplicarFecha As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtLoteAsigna As TextBox
    Friend WithEvents btnAsignarLote As Button
    Friend WithEvents btn_valida_proceso As Button
    Friend WithEvents lbl_lote As Label
    Friend WithEvents cmbCuentaBanco As ComboBox
    Friend WithEvents cmbMoneda As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTasa As TextBox
    Friend WithEvents Label4 As Label
End Class
