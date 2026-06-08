<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_scm_recalculo_semanas
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.NUDSemana = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSemanaActual = New System.Windows.Forms.Label
        Me.lblSemanaCalculo = New System.Windows.Forms.Label
        CType(Me.NUDSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(28, 107)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Generar Todos       "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(315, 30)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGenerar.TabIndex = 1
        Me.BtnGenerar.Text = "Button1"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'NUDSemana
        '
        Me.NUDSemana.Location = New System.Drawing.Point(123, 66)
        Me.NUDSemana.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.NUDSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUDSemana.Name = "NUDSemana"
        Me.NUDSemana.Size = New System.Drawing.Size(31, 21)
        Me.NUDSemana.TabIndex = 2
        Me.NUDSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Agregar Semanas"
        '
        'lblSemanaActual
        '
        Me.lblSemanaActual.AutoSize = True
        Me.lblSemanaActual.Location = New System.Drawing.Point(25, 9)
        Me.lblSemanaActual.Name = "lblSemanaActual"
        Me.lblSemanaActual.Size = New System.Drawing.Size(78, 13)
        Me.lblSemanaActual.TabIndex = 3
        Me.lblSemanaActual.Text = "Semana Actual"
        '
        'lblSemanaCalculo
        '
        Me.lblSemanaCalculo.AutoSize = True
        Me.lblSemanaCalculo.Location = New System.Drawing.Point(25, 30)
        Me.lblSemanaCalculo.Name = "lblSemanaCalculo"
        Me.lblSemanaCalculo.Size = New System.Drawing.Size(82, 13)
        Me.lblSemanaCalculo.TabIndex = 3
        Me.lblSemanaCalculo.Text = "Semana Calculo"
        '
        'frm_scm_recalculo_semanas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 289)
        Me.Controls.Add(Me.lblSemanaCalculo)
        Me.Controls.Add(Me.lblSemanaActual)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NUDSemana)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.CheckBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_scm_recalculo_semanas"
        Me.Text = "frm_scm_recalculo_semanas"
        CType(Me.NUDSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents NUDSemana As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSemanaActual As System.Windows.Forms.Label
    Friend WithEvents lblSemanaCalculo As System.Windows.Forms.Label
End Class
