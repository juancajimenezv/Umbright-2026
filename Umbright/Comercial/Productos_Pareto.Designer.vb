<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Productos_Pareto
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
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_Cargar = New System.Windows.Forms.Button()
        Me.btn_Salir = New System.Windows.Forms.Button()
        Me.btn_Actualizar = New System.Windows.Forms.Button()
        Me.lb_Empresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_Producto = New System.Windows.Forms.TextBox()
        Me.tb_Glosa = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.tb_Pareto = New System.Windows.Forms.TextBox()
        Me.tb_Bu = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(813, 324)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.Size = New System.Drawing.Size(801, 299)
        Me.dgv_Detalle.TabIndex = 0
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Imprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Imprimir.Location = New System.Drawing.Point(582, 36)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.btn_Imprimir.TabIndex = 1
        Me.btn_Imprimir.Text = "Imprimir"
        Me.btn_Imprimir.UseVisualStyleBackColor = False
        '
        'btn_Cargar
        '
        Me.btn_Cargar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cargar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Cargar.Location = New System.Drawing.Point(663, 36)
        Me.btn_Cargar.Name = "btn_Cargar"
        Me.btn_Cargar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cargar.TabIndex = 2
        Me.btn_Cargar.Text = "Cargar"
        Me.btn_Cargar.UseVisualStyleBackColor = False
        '
        'btn_Salir
        '
        Me.btn_Salir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Salir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Salir.Location = New System.Drawing.Point(744, 36)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(75, 23)
        Me.btn_Salir.TabIndex = 3
        Me.btn_Salir.Text = "Salir"
        Me.btn_Salir.UseVisualStyleBackColor = False
        '
        'btn_Actualizar
        '
        Me.btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Actualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Actualizar.Location = New System.Drawing.Point(501, 36)
        Me.btn_Actualizar.Name = "btn_Actualizar"
        Me.btn_Actualizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Actualizar.TabIndex = 4
        Me.btn_Actualizar.Text = "Actualizar"
        Me.btn_Actualizar.UseVisualStyleBackColor = False
        '
        'lb_Empresa
        '
        Me.lb_Empresa.AutoSize = True
        Me.lb_Empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Empresa.Location = New System.Drawing.Point(15, 9)
        Me.lb_Empresa.Name = "lb_Empresa"
        Me.lb_Empresa.Size = New System.Drawing.Size(80, 20)
        Me.lb_Empresa.TabIndex = 5
        Me.lb_Empresa.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Actualiza Productos..."
        '
        'tb_Producto
        '
        Me.tb_Producto.Location = New System.Drawing.Point(57, 69)
        Me.tb_Producto.Name = "tb_Producto"
        Me.tb_Producto.Size = New System.Drawing.Size(78, 20)
        Me.tb_Producto.TabIndex = 7
        '
        'tb_Glosa
        '
        Me.tb_Glosa.Location = New System.Drawing.Point(141, 69)
        Me.tb_Glosa.Name = "tb_Glosa"
        Me.tb_Glosa.Size = New System.Drawing.Size(266, 20)
        Me.tb_Glosa.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(413, 69)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(77, 20)
        Me.TextBox3.TabIndex = 9
        '
        'tb_Pareto
        '
        Me.tb_Pareto.Location = New System.Drawing.Point(496, 69)
        Me.tb_Pareto.Name = "tb_Pareto"
        Me.tb_Pareto.Size = New System.Drawing.Size(61, 20)
        Me.tb_Pareto.TabIndex = 10
        '
        'tb_Bu
        '
        Me.tb_Bu.Location = New System.Drawing.Point(563, 69)
        Me.tb_Bu.Name = "tb_Bu"
        Me.tb_Bu.Size = New System.Drawing.Size(94, 20)
        Me.tb_Bu.TabIndex = 11
        '
        'Productos_Pareto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(837, 426)
        Me.Controls.Add(Me.tb_Bu)
        Me.Controls.Add(Me.tb_Pareto)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.tb_Glosa)
        Me.Controls.Add(Me.tb_Producto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lb_Empresa)
        Me.Controls.Add(Me.btn_Actualizar)
        Me.Controls.Add(Me.btn_Salir)
        Me.Controls.Add(Me.btn_Cargar)
        Me.Controls.Add(Me.btn_Imprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Productos_Pareto"
        Me.Text = "Productos_Pareto"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents btn_Salir As System.Windows.Forms.Button
    Friend WithEvents btn_Actualizar As System.Windows.Forms.Button
    Friend WithEvents lb_Empresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_Producto As System.Windows.Forms.TextBox
    Friend WithEvents tb_Glosa As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents tb_Pareto As System.Windows.Forms.TextBox
    Friend WithEvents tb_Bu As System.Windows.Forms.TextBox
End Class
