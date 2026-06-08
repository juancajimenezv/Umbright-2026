Public Class frm_resultado
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents dgv_resultado As System.Windows.Forms.DataGridView
    Friend WithEvents lblResumenlabel As Label
    Friend WithEvents lblResumenTotal As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgv_resultado = New System.Windows.Forms.DataGridView()
        Me.lblResumenlabel = New System.Windows.Forms.Label()
        Me.lblResumenTotal = New System.Windows.Forms.Label()
        CType(Me.dgv_resultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_resultado
        '
        Me.dgv_resultado.AllowUserToAddRows = False
        Me.dgv_resultado.AllowUserToDeleteRows = False
        Me.dgv_resultado.AllowUserToOrderColumns = True
        Me.dgv_resultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_resultado.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_resultado.Location = New System.Drawing.Point(2, 12)
        Me.dgv_resultado.Name = "dgv_resultado"
        Me.dgv_resultado.RowHeadersWidth = 20
        Me.dgv_resultado.Size = New System.Drawing.Size(572, 245)
        Me.dgv_resultado.TabIndex = 0
        '
        'lblResumenlabel
        '
        Me.lblResumenlabel.AutoSize = True
        Me.lblResumenlabel.Location = New System.Drawing.Point(145, 261)
        Me.lblResumenlabel.Name = "lblResumenlabel"
        Me.lblResumenlabel.Size = New System.Drawing.Size(74, 13)
        Me.lblResumenlabel.TabIndex = 1
        Me.lblResumenlabel.Text = "Cajas Pedidas"
        Me.lblResumenlabel.Visible = False
        '
        'lblResumenTotal
        '
        Me.lblResumenTotal.AutoSize = True
        Me.lblResumenTotal.Location = New System.Drawing.Point(352, 261)
        Me.lblResumenTotal.Name = "lblResumenTotal"
        Me.lblResumenTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblResumenTotal.TabIndex = 1
        Me.lblResumenTotal.Text = "0"
        Me.lblResumenTotal.Visible = False
        '
        'frm_resultado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(576, 283)
        Me.Controls.Add(Me.lblResumenTotal)
        Me.Controls.Add(Me.lblResumenlabel)
        Me.Controls.Add(Me.dgv_resultado)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_resultado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resultado"
        CType(Me.dgv_resultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class
