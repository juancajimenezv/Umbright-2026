<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PagosOtros
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
        Me.dgv_PagoOtros = New System.Windows.Forms.DataGridView
        Me.b_Genera = New System.Windows.Forms.Button
        Me.b_Cencela_G = New System.Windows.Forms.Button
        CType(Me.dgv_PagoOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_PagoOtros
        '
        Me.dgv_PagoOtros.AllowUserToAddRows = False
        Me.dgv_PagoOtros.AllowUserToDeleteRows = False
        Me.dgv_PagoOtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_PagoOtros.Location = New System.Drawing.Point(12, 13)
        Me.dgv_PagoOtros.Name = "dgv_PagoOtros"
        Me.dgv_PagoOtros.Size = New System.Drawing.Size(734, 175)
        Me.dgv_PagoOtros.TabIndex = 0
        '
        'b_Genera
        '
        Me.b_Genera.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.b_Genera.Cursor = System.Windows.Forms.Cursors.Hand
        Me.b_Genera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_Genera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.b_Genera.Location = New System.Drawing.Point(226, 211)
        Me.b_Genera.Name = "b_Genera"
        Me.b_Genera.Size = New System.Drawing.Size(85, 38)
        Me.b_Genera.TabIndex = 2
        Me.b_Genera.Text = "Genera  Archivo"
        Me.b_Genera.UseVisualStyleBackColor = False
        '
        'b_Cencela_G
        '
        Me.b_Cencela_G.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.b_Cencela_G.Cursor = System.Windows.Forms.Cursors.Hand
        Me.b_Cencela_G.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_Cencela_G.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.b_Cencela_G.Location = New System.Drawing.Point(380, 211)
        Me.b_Cencela_G.Name = "b_Cencela_G"
        Me.b_Cencela_G.Size = New System.Drawing.Size(85, 38)
        Me.b_Cencela_G.TabIndex = 3
        Me.b_Cencela_G.Text = "Cancela Generación"
        Me.b_Cencela_G.UseVisualStyleBackColor = False
        '
        'Frm_PagosOtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(758, 273)
        Me.Controls.Add(Me.b_Cencela_G)
        Me.Controls.Add(Me.b_Genera)
        Me.Controls.Add(Me.dgv_PagoOtros)
        Me.Name = "Frm_PagosOtros"
        Me.Text = "Verificacion Pagos ACH"
        CType(Me.dgv_PagoOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_PagoOtros As System.Windows.Forms.DataGridView
    Friend WithEvents b_Genera As System.Windows.Forms.Button
    Friend WithEvents b_Cencela_G As System.Windows.Forms.Button
End Class
