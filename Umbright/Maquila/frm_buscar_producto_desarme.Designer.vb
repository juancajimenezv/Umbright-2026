<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_producto_desarme
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
        Me.dgv_Productos = New System.Windows.Forms.DataGridView
        Me.cmb_Campo = New System.Windows.Forms.ComboBox
        Me.cmb_Condicion = New System.Windows.Forms.ComboBox
        Me.txt_Filtro = New System.Windows.Forms.TextBox
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Productos
        '
        Me.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Productos.Location = New System.Drawing.Point(12, 64)
        Me.dgv_Productos.Name = "dgv_Productos"
        Me.dgv_Productos.ReadOnly = True
        Me.dgv_Productos.Size = New System.Drawing.Size(472, 410)
        Me.dgv_Productos.TabIndex = 0
        '
        'cmb_Campo
        '
        Me.cmb_Campo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_Campo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Campo.DropDownWidth = 150
        Me.cmb_Campo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_Campo.Location = New System.Drawing.Point(12, 21)
        Me.cmb_Campo.Name = "cmb_Campo"
        Me.cmb_Campo.Size = New System.Drawing.Size(104, 21)
        Me.cmb_Campo.TabIndex = 14
        '
        'cmb_Condicion
        '
        Me.cmb_Condicion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_Condicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Condicion.DropDownWidth = 50
        Me.cmb_Condicion.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_Condicion.Location = New System.Drawing.Point(122, 21)
        Me.cmb_Condicion.Name = "cmb_Condicion"
        Me.cmb_Condicion.Size = New System.Drawing.Size(55, 21)
        Me.cmb_Condicion.TabIndex = 15
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Filtro.Location = New System.Drawing.Point(183, 21)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(283, 20)
        Me.txt_Filtro.TabIndex = 16
        '
        'frm_buscar_producto_desarme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(499, 476)
        Me.Controls.Add(Me.cmb_Campo)
        Me.Controls.Add(Me.cmb_Condicion)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.dgv_Productos)
        Me.Name = "frm_buscar_producto_desarme"
        Me.Text = "Busqueda Producto Desarme"
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Productos As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_Campo As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Condicion As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
End Class
