<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualizacionProductos
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents tabPanel As System.Windows.Forms.TabControl
    Friend WithEvents tabIndividual As System.Windows.Forms.TabPage
    Friend WithEvents tabMasiva As System.Windows.Forms.TabPage

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabPanel = New System.Windows.Forms.TabControl()
        Me.tabIndividual = New System.Windows.Forms.TabPage()
        Me.tabMasiva = New System.Windows.Forms.TabPage()
        Me.tabPanel.SuspendLayout()
        Me.SuspendLayout()

        Me.tabPanel.Controls.Add(Me.tabIndividual)
        Me.tabPanel.Controls.Add(Me.tabMasiva)
        Me.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPanel.SelectedIndex = 0

        Me.tabIndividual.Text = "Actualización Individual"
        Me.tabIndividual.UseVisualStyleBackColor = True

        Me.tabMasiva.Text = "Actualización Masiva"
        Me.tabMasiva.UseVisualStyleBackColor = True

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 782)
        Me.Controls.Add(Me.tabPanel)
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.Name = "frm_actualizacionProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización de Productos"
        Me.tabPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class
