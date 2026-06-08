<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Impresion_Factura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Impresion_Factura))
        Me.crv_Impresion = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crv_Impresion
        '
        Me.crv_Impresion.ActiveViewIndex = -1
        Me.crv_Impresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv_Impresion.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv_Impresion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv_Impresion.Location = New System.Drawing.Point(0, 0)
        Me.crv_Impresion.Name = "crv_Impresion"
        Me.crv_Impresion.Size = New System.Drawing.Size(756, 431)
        Me.crv_Impresion.TabIndex = 0
        '
        'frm_Impresion_Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 431)
        Me.Controls.Add(Me.crv_Impresion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Impresion_Factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crv_Impresion As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
