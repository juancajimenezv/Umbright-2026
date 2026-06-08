<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_graficar
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
        Me.components = New System.ComponentModel.Container
        Me.zgc1 = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'zgc1
        '
        Me.zgc1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgc1.Location = New System.Drawing.Point(0, 0)
        Me.zgc1.Name = "zgc1"
        Me.zgc1.ScrollGrace = 0
        Me.zgc1.ScrollMaxX = 0
        Me.zgc1.ScrollMaxY = 0
        Me.zgc1.ScrollMaxY2 = 0
        Me.zgc1.ScrollMinX = 0
        Me.zgc1.ScrollMinY = 0
        Me.zgc1.ScrollMinY2 = 0
        Me.zgc1.Size = New System.Drawing.Size(855, 465)
        Me.zgc1.TabIndex = 3
        '
        'frm_graficar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 465)
        Me.Controls.Add(Me.zgc1)
        Me.Name = "frm_graficar"
        Me.Text = "::. GRAFICA .::"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zgc1 As ZedGraph.ZedGraphControl
End Class
