<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Producto_Item
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Producto_Item))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_TipoIva = New System.Windows.Forms.ComboBox()
        Me.tb_Item = New System.Windows.Forms.TextBox()
        Me.cb_Tipo = New System.Windows.Forms.ComboBox()
        Me.tb_Descripcion = New System.Windows.Forms.TextBox()
        Me.tb_Codigo = New System.Windows.Forms.TextBox()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(803, 358)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.Size = New System.Drawing.Size(787, 333)
        Me.dgv_Detalle.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Limpiar)
        Me.GroupBox2.Controls.Add(Me.cb_TipoIva)
        Me.GroupBox2.Controls.Add(Me.tb_Item)
        Me.GroupBox2.Controls.Add(Me.cb_Tipo)
        Me.GroupBox2.Controls.Add(Me.tb_Descripcion)
        Me.GroupBox2.Controls.Add(Me.tb_Codigo)
        Me.GroupBox2.Controls.Add(Me.btn_Agregar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(799, 116)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cb_TipoIva
        '
        Me.cb_TipoIva.FormattingEnabled = True
        Me.cb_TipoIva.Items.AddRange(New Object() {"", "COMPRA", "SERVICIO"})
        Me.cb_TipoIva.Location = New System.Drawing.Point(703, 36)
        Me.cb_TipoIva.Name = "cb_TipoIva"
        Me.cb_TipoIva.Size = New System.Drawing.Size(86, 21)
        Me.cb_TipoIva.TabIndex = 5
        '
        'tb_Item
        '
        Me.tb_Item.Location = New System.Drawing.Point(637, 36)
        Me.tb_Item.Name = "tb_Item"
        Me.tb_Item.Size = New System.Drawing.Size(62, 20)
        Me.tb_Item.TabIndex = 4
        '
        'cb_Tipo
        '
        Me.cb_Tipo.FormattingEnabled = True
        Me.cb_Tipo.Location = New System.Drawing.Point(512, 35)
        Me.cb_Tipo.Name = "cb_Tipo"
        Me.cb_Tipo.Size = New System.Drawing.Size(121, 21)
        Me.cb_Tipo.TabIndex = 3
        '
        'tb_Descripcion
        '
        Me.tb_Descripcion.Location = New System.Drawing.Point(120, 36)
        Me.tb_Descripcion.Name = "tb_Descripcion"
        Me.tb_Descripcion.Size = New System.Drawing.Size(385, 20)
        Me.tb_Descripcion.TabIndex = 2
        '
        'tb_Codigo
        '
        Me.tb_Codigo.Location = New System.Drawing.Point(34, 36)
        Me.tb_Codigo.Name = "tb_Codigo"
        Me.tb_Codigo.Size = New System.Drawing.Size(81, 20)
        Me.tb_Codigo.TabIndex = 1
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(703, 74)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(86, 23)
        Me.btn_Agregar.TabIndex = 0
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Limpiar.Location = New System.Drawing.Point(604, 74)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Limpiar.TabIndex = 6
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'Frm_Producto_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(819, 507)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Producto_Item"
        Me.Text = "Producto Item"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents tb_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents cb_TipoIva As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Item As System.Windows.Forms.TextBox
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
End Class
