<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Buscar_Suspendidos
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
        Me.dgv_Busca_Suspendidos = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_Busca_Suspendidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Busca_Suspendidos
        '
        Me.dgv_Busca_Suspendidos.AllowUserToAddRows = False
        Me.dgv_Busca_Suspendidos.AllowUserToDeleteRows = False
        Me.dgv_Busca_Suspendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Busca_Suspendidos.Location = New System.Drawing.Point(12, 51)
        Me.dgv_Busca_Suspendidos.Name = "dgv_Busca_Suspendidos"
        Me.dgv_Busca_Suspendidos.ReadOnly = True
        Me.dgv_Busca_Suspendidos.Size = New System.Drawing.Size(477, 187)
        Me.dgv_Busca_Suspendidos.TabIndex = 0
        '
        'Frm_Buscar_Suspendidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(501, 250)
        Me.Controls.Add(Me.dgv_Busca_Suspendidos)
        Me.Name = "Frm_Buscar_Suspendidos"
        Me.Text = "Busca Suspendidos"
        CType(Me.dgv_Busca_Suspendidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_Busca_Suspendidos As System.Windows.Forms.DataGridView
End Class
