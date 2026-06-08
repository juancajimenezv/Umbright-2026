<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EvaluacionD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmbTipoDocto = New System.Windows.Forms.ComboBox
        Me.lbl_nodocto = New System.Windows.Forms.Label
        Me.chk_recogera = New System.Windows.Forms.CheckBox
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_equipo = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageKey = "Daemon-Tools-icon.png"
        Me.btn_generar.Location = New System.Drawing.Point(377, 29)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(83, 26)
        Me.btn_generar.TabIndex = 4
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'cmbTipoDocto
        '
        Me.cmbTipoDocto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbTipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocto.ForeColor = System.Drawing.Color.Maroon
        Me.cmbTipoDocto.FormattingEnabled = True
        Me.cmbTipoDocto.Items.AddRange(New Object() {"FACTURA", "CONSIGNACION"})
        Me.cmbTipoDocto.Location = New System.Drawing.Point(98, 65)
        Me.cmbTipoDocto.Name = "cmbTipoDocto"
        Me.cmbTipoDocto.Size = New System.Drawing.Size(151, 23)
        Me.cmbTipoDocto.TabIndex = 41
        Me.cmbTipoDocto.Visible = False
        '
        'lbl_nodocto
        '
        Me.lbl_nodocto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nodocto.ForeColor = System.Drawing.Color.Black
        Me.lbl_nodocto.Location = New System.Drawing.Point(12, 72)
        Me.lbl_nodocto.Name = "lbl_nodocto"
        Me.lbl_nodocto.Size = New System.Drawing.Size(69, 16)
        Me.lbl_nodocto.TabIndex = 42
        Me.lbl_nodocto.Text = "Evaluador"
        Me.lbl_nodocto.Visible = False
        '
        'chk_recogera
        '
        Me.chk_recogera.AutoSize = True
        Me.chk_recogera.Location = New System.Drawing.Point(377, 104)
        Me.chk_recogera.Name = "chk_recogera"
        Me.chk_recogera.Size = New System.Drawing.Size(94, 17)
        Me.chk_recogera.TabIndex = 43
        Me.chk_recogera.Text = "Mostrar Todos"
        Me.chk_recogera.UseVisualStyleBackColor = True
        Me.chk_recogera.Visible = False
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AllowUserToAddRows = False
        Me.dgv_pedidos.AllowUserToDeleteRows = False
        Me.dgv_pedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(20, 19)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.RowHeadersWidth = 25
        Me.dgv_pedidos.Size = New System.Drawing.Size(439, 138)
        Me.dgv_pedidos.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Empresa"
        Me.Label1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Maroon
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"FACTURA", "CONSIGNACION"})
        Me.ComboBox1.Location = New System.Drawing.Point(98, 100)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(151, 23)
        Me.ComboBox1.TabIndex = 45
        Me.ComboBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Equipo"
        '
        'cmb_equipo
        '
        Me.cmb_equipo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_equipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_equipo.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_equipo.FormattingEnabled = True
        Me.cmb_equipo.Location = New System.Drawing.Point(98, 29)
        Me.cmb_equipo.Name = "cmb_equipo"
        Me.cmb_equipo.Size = New System.Drawing.Size(264, 23)
        Me.cmb_equipo.TabIndex = 47
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_pedidos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 184)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Frm_EvaluacionD
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(531, 93)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_equipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.chk_recogera)
        Me.Controls.Add(Me.lbl_nodocto)
        Me.Controls.Add(Me.cmbTipoDocto)
        Me.Controls.Add(Me.btn_generar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Frm_EvaluacionD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plataforma para el Crecimiento"
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_nodocto As System.Windows.Forms.Label
    Friend WithEvents chk_recogera As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_equipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
