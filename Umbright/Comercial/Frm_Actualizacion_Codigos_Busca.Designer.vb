<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Actualizacion_Codigos_Busca
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
        Me.dgv_BuscaProductos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_BuscaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_BuscaProductos)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgv_BuscaProductos
        '
        Me.dgv_BuscaProductos.AllowUserToAddRows = False
        Me.dgv_BuscaProductos.AllowUserToDeleteRows = False
        Me.dgv_BuscaProductos.AllowUserToOrderColumns = True
        Me.dgv_BuscaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_BuscaProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_BuscaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_BuscaProductos.Location = New System.Drawing.Point(7, 19)
        Me.dgv_BuscaProductos.Name = "dgv_BuscaProductos"
        Me.dgv_BuscaProductos.ReadOnly = True
        Me.dgv_BuscaProductos.Size = New System.Drawing.Size(622, 173)
        Me.dgv_BuscaProductos.TabIndex = 0
        '
        'Frm_Actualizacion_Codigos_Busca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(643, 246)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Actualizacion_Codigos_Busca"
        Me.Text = "Busca Códigos"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_BuscaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_BuscaProductos As System.Windows.Forms.DataGridView
End Class
