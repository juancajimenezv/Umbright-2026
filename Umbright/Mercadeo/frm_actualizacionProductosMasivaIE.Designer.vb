<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualizacionProductosMasivaIE
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblColumna As System.Windows.Forms.Label
    Friend WithEvents cmbColumna As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_vigente_hint As System.Windows.Forms.Label
    Friend WithEvents btnCargarExcel As System.Windows.Forms.Button
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents lblFormato As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents lblObs As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents btnValidar As System.Windows.Forms.Button
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblColumna = New System.Windows.Forms.Label()
        Me.cmbColumna = New System.Windows.Forms.ComboBox()
        Me.lbl_vigente_hint = New System.Windows.Forms.Label()
        Me.btnCargarExcel = New System.Windows.Forms.Button()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.lblObs = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.btnValidar = New System.Windows.Forms.Button()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblEmpresa.AutoSize = True : Me.lblEmpresa.Location = New System.Drawing.Point(20, 20) : Me.lblEmpresa.Text = "Empresa:"
        Me.cmbEmpresa.Location = New System.Drawing.Point(100, 17) : Me.cmbEmpresa.Size = New System.Drawing.Size(200, 21)
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.lblColumna.AutoSize = True : Me.lblColumna.Location = New System.Drawing.Point(320, 20) : Me.lblColumna.Text = "Columna a actualizar:"
        Me.cmbColumna.Location = New System.Drawing.Point(450, 17) : Me.cmbColumna.Size = New System.Drawing.Size(200, 21)
        Me.cmbColumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.lbl_vigente_hint.AutoSize = True : Me.lbl_vigente_hint.Location = New System.Drawing.Point(450, 40)
        Me.lbl_vigente_hint.Text = """S"" ACTIVAR    ""N"" INACTIVAR"
        Me.lbl_vigente_hint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_vigente_hint.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbl_vigente_hint.Visible = False

        Me.btnCargarExcel.Location = New System.Drawing.Point(20, 55) : Me.btnCargarExcel.Size = New System.Drawing.Size(140, 27)
        Me.btnCargarExcel.Text = "Cargar Excel..." : Me.btnCargarExcel.UseVisualStyleBackColor = True

        Me.lblArchivo.AutoSize = True : Me.lblArchivo.Location = New System.Drawing.Point(170, 62)
        Me.lblArchivo.Text = "(ningún archivo cargado)" : Me.lblArchivo.ForeColor = System.Drawing.Color.Gray

        Me.lblFormato.AutoSize = True : Me.lblFormato.Location = New System.Drawing.Point(20, 95)
        Me.lblFormato.Text = "Columna A: Producto (10 dígitos, se completa con ceros)    ·    Columna B: Valor a actualizar"
        Me.lblFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblFormato.ForeColor = System.Drawing.Color.DarkSlateGray

        Me.dgvDatos.Location = New System.Drawing.Point(20, 120) : Me.dgvDatos.Size = New System.Drawing.Size(700, 240)
        Me.dgvDatos.AllowUserToAddRows = False : Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.RowHeadersVisible = False
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None

        Me.lblObs.AutoSize = True : Me.lblObs.Location = New System.Drawing.Point(20, 375) : Me.lblObs.Text = "Observación:"
        Me.txtObs.Location = New System.Drawing.Point(100, 372) : Me.txtObs.Size = New System.Drawing.Size(620, 20)

        Me.btnValidar.Location = New System.Drawing.Point(450, 405) : Me.btnValidar.Size = New System.Drawing.Size(130, 30)
        Me.btnValidar.Text = "Validar" : Me.btnValidar.UseVisualStyleBackColor = True

        Me.btnAplicar.Location = New System.Drawing.Point(590, 405) : Me.btnAplicar.Size = New System.Drawing.Size(130, 30)
        Me.btnAplicar.Text = "Guardar"
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(76, Byte), CType(175, Byte), CType(80, Byte))
        Me.btnAplicar.ForeColor = System.Drawing.Color.White : Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAplicar.Enabled = False

        Me.lblEstado.AutoSize = True : Me.lblEstado.Location = New System.Drawing.Point(20, 415)
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkBlue : Me.lblEstado.Text = ""
        Me.lblEstado.MaximumSize = New System.Drawing.Size(420, 0)

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 450)
        Me.Controls.Add(Me.lblEmpresa) : Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.lblColumna) : Me.Controls.Add(Me.cmbColumna)
        Me.Controls.Add(Me.lbl_vigente_hint)
        Me.Controls.Add(Me.btnCargarExcel) : Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.lblFormato) : Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.lblObs) : Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.btnValidar) : Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.lblEstado)
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.Name = "frm_actualizacionProductosMasivaIE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización Masiva IE"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False) : Me.PerformLayout()
    End Sub
End Class
