<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cambio_Dai
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
        Me.BoxFamilia = New System.Windows.Forms.ComboBox
        Me.btn_Grabar = New System.Windows.Forms.Button
        Me.Producto = New System.Windows.Forms.Label
        Me.btn_SubFamilia = New System.Windows.Forms.Button
        Me.l_SubFamilia = New System.Windows.Forms.Label
        Me.btn_Familia = New System.Windows.Forms.Button
        Me.BoxSubFamilia = New System.Windows.Forms.ComboBox
        Me.l_Familia = New System.Windows.Forms.Label
        Me.dgv_Impuestos = New System.Windows.Forms.DataGridView
        Me.tc_Productos = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgv_Productos = New System.Windows.Forms.DataGridView
        Me.tp_Impuestos = New System.Windows.Forms.TabPage
        Me.btn_Nuevo = New System.Windows.Forms.Button
        Me.l_producto = New System.Windows.Forms.Label
        Me.btn_BuscaProducto = New System.Windows.Forms.Button
        Me.tb_Producto = New System.Windows.Forms.TextBox
        CType(Me.dgv_Impuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Productos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Impuestos.SuspendLayout()
        Me.SuspendLayout()
        '
        'BoxFamilia
        '
        Me.BoxFamilia.FormattingEnabled = True
        Me.BoxFamilia.Location = New System.Drawing.Point(115, 33)
        Me.BoxFamilia.Name = "BoxFamilia"
        Me.BoxFamilia.Size = New System.Drawing.Size(214, 21)
        Me.BoxFamilia.TabIndex = 0
        '
        'btn_Grabar
        '
        Me.btn_Grabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Grabar.ForeColor = System.Drawing.Color.White
        Me.btn_Grabar.Location = New System.Drawing.Point(363, 35)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Grabar.TabIndex = 8
        Me.btn_Grabar.Text = "Grabar"
        Me.btn_Grabar.UseVisualStyleBackColor = False
        '
        'Producto
        '
        Me.Producto.AutoSize = True
        Me.Producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Producto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Producto.Location = New System.Drawing.Point(18, 35)
        Me.Producto.Name = "Producto"
        Me.Producto.Size = New System.Drawing.Size(58, 13)
        Me.Producto.TabIndex = 7
        Me.Producto.Text = "Producto"
        '
        'btn_SubFamilia
        '
        Me.btn_SubFamilia.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_SubFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SubFamilia.ForeColor = System.Drawing.Color.White
        Me.btn_SubFamilia.Location = New System.Drawing.Point(335, 64)
        Me.btn_SubFamilia.Name = "btn_SubFamilia"
        Me.btn_SubFamilia.Size = New System.Drawing.Size(75, 23)
        Me.btn_SubFamilia.TabIndex = 6
        Me.btn_SubFamilia.Text = "Aceptar"
        Me.btn_SubFamilia.UseVisualStyleBackColor = False
        '
        'l_SubFamilia
        '
        Me.l_SubFamilia.AutoSize = True
        Me.l_SubFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_SubFamilia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.l_SubFamilia.Location = New System.Drawing.Point(36, 68)
        Me.l_SubFamilia.Name = "l_SubFamilia"
        Me.l_SubFamilia.Size = New System.Drawing.Size(68, 13)
        Me.l_SubFamilia.TabIndex = 4
        Me.l_SubFamilia.Text = "SubFamilia"
        '
        'btn_Familia
        '
        Me.btn_Familia.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Familia.ForeColor = System.Drawing.Color.White
        Me.btn_Familia.Location = New System.Drawing.Point(335, 31)
        Me.btn_Familia.Name = "btn_Familia"
        Me.btn_Familia.Size = New System.Drawing.Size(75, 23)
        Me.btn_Familia.TabIndex = 3
        Me.btn_Familia.Text = "Aceptar"
        Me.btn_Familia.UseVisualStyleBackColor = False
        '
        'BoxSubFamilia
        '
        Me.BoxSubFamilia.FormattingEnabled = True
        Me.BoxSubFamilia.Location = New System.Drawing.Point(115, 66)
        Me.BoxSubFamilia.Name = "BoxSubFamilia"
        Me.BoxSubFamilia.Size = New System.Drawing.Size(214, 21)
        Me.BoxSubFamilia.TabIndex = 2
        '
        'l_Familia
        '
        Me.l_Familia.AutoSize = True
        Me.l_Familia.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.l_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_Familia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.l_Familia.Location = New System.Drawing.Point(38, 38)
        Me.l_Familia.Name = "l_Familia"
        Me.l_Familia.Size = New System.Drawing.Size(50, 13)
        Me.l_Familia.TabIndex = 1
        Me.l_Familia.Text = "Familia:"
        '
        'dgv_Impuestos
        '
        Me.dgv_Impuestos.AllowUserToAddRows = False
        Me.dgv_Impuestos.AllowUserToDeleteRows = False
        Me.dgv_Impuestos.BackgroundColor = System.Drawing.Color.White
        Me.dgv_Impuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Impuestos.GridColor = System.Drawing.Color.Silver
        Me.dgv_Impuestos.Location = New System.Drawing.Point(21, 118)
        Me.dgv_Impuestos.Name = "dgv_Impuestos"
        Me.dgv_Impuestos.Size = New System.Drawing.Size(340, 205)
        Me.dgv_Impuestos.TabIndex = 2
        '
        'tc_Productos
        '
        Me.tc_Productos.Controls.Add(Me.TabPage1)
        Me.tc_Productos.Controls.Add(Me.tp_Impuestos)
        Me.tc_Productos.Location = New System.Drawing.Point(7, 0)
        Me.tc_Productos.Name = "tc_Productos"
        Me.tc_Productos.SelectedIndex = 0
        Me.tc_Productos.Size = New System.Drawing.Size(558, 359)
        Me.tc_Productos.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgv_Productos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(550, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.l_Familia)
        Me.GroupBox1.Controls.Add(Me.l_SubFamilia)
        Me.GroupBox1.Controls.Add(Me.btn_SubFamilia)
        Me.GroupBox1.Controls.Add(Me.btn_Familia)
        Me.GroupBox1.Controls.Add(Me.BoxFamilia)
        Me.GroupBox1.Controls.Add(Me.BoxSubFamilia)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 100)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda Por"
        '
        'dgv_Productos
        '
        Me.dgv_Productos.AllowUserToAddRows = False
        Me.dgv_Productos.AllowUserToDeleteRows = False
        Me.dgv_Productos.AllowUserToOrderColumns = True
        Me.dgv_Productos.BackgroundColor = System.Drawing.Color.White
        Me.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Productos.GridColor = System.Drawing.Color.Silver
        Me.dgv_Productos.Location = New System.Drawing.Point(6, 131)
        Me.dgv_Productos.Name = "dgv_Productos"
        Me.dgv_Productos.Size = New System.Drawing.Size(538, 194)
        Me.dgv_Productos.TabIndex = 7
        '
        'tp_Impuestos
        '
        Me.tp_Impuestos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_Impuestos.Controls.Add(Me.btn_Nuevo)
        Me.tp_Impuestos.Controls.Add(Me.l_producto)
        Me.tp_Impuestos.Controls.Add(Me.btn_BuscaProducto)
        Me.tp_Impuestos.Controls.Add(Me.tb_Producto)
        Me.tp_Impuestos.Controls.Add(Me.dgv_Impuestos)
        Me.tp_Impuestos.Controls.Add(Me.btn_Grabar)
        Me.tp_Impuestos.Controls.Add(Me.Producto)
        Me.tp_Impuestos.Location = New System.Drawing.Point(4, 22)
        Me.tp_Impuestos.Name = "tp_Impuestos"
        Me.tp_Impuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_Impuestos.Size = New System.Drawing.Size(550, 333)
        Me.tp_Impuestos.TabIndex = 1
        Me.tp_Impuestos.Text = "Impuestos"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_Nuevo.Location = New System.Drawing.Point(457, 35)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_Nuevo.TabIndex = 14
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = False
        '
        'l_producto
        '
        Me.l_producto.AutoSize = True
        Me.l_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_producto.Location = New System.Drawing.Point(23, 77)
        Me.l_producto.Name = "l_producto"
        Me.l_producto.Size = New System.Drawing.Size(0, 15)
        Me.l_producto.TabIndex = 13
        '
        'btn_BuscaProducto
        '
        Me.btn_BuscaProducto.BackColor = System.Drawing.SystemColors.Control
        Me.btn_BuscaProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscaProducto.Location = New System.Drawing.Point(198, 30)
        Me.btn_BuscaProducto.Name = "btn_BuscaProducto"
        Me.btn_BuscaProducto.Size = New System.Drawing.Size(23, 23)
        Me.btn_BuscaProducto.TabIndex = 12
        Me.btn_BuscaProducto.Text = "?"
        Me.btn_BuscaProducto.UseVisualStyleBackColor = False
        '
        'tb_Producto
        '
        Me.tb_Producto.Location = New System.Drawing.Point(83, 33)
        Me.tb_Producto.Name = "tb_Producto"
        Me.tb_Producto.Size = New System.Drawing.Size(110, 20)
        Me.tb_Producto.TabIndex = 10
        '
        'Frm_Cambio_Dai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(572, 362)
        Me.Controls.Add(Me.tc_Productos)
        Me.Name = "Frm_Cambio_Dai"
        Me.Text = "Cambio De Dai"
        CType(Me.dgv_Impuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Productos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Impuestos.ResumeLayout(False)
        Me.tp_Impuestos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BoxFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents l_Familia As System.Windows.Forms.Label
    Friend WithEvents BoxSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Familia As System.Windows.Forms.Button
    Friend WithEvents l_SubFamilia As System.Windows.Forms.Label
    Friend WithEvents dgv_Impuestos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_SubFamilia As System.Windows.Forms.Button
    Friend WithEvents Producto As System.Windows.Forms.Label
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents tc_Productos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tp_Impuestos As System.Windows.Forms.TabPage
    Friend WithEvents dgv_Productos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_Producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaProducto As System.Windows.Forms.Button
    Friend WithEvents l_producto As System.Windows.Forms.Label
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
End Class
