<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Recibos_Canal_Moderno_Actualizar
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
        Me.tb_Recibo = New System.Windows.Forms.TextBox()
        Me.tb_Monto_Diferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Actualizar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_Comentario = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_Recibo
        '
        Me.tb_Recibo.Location = New System.Drawing.Point(113, 22)
        Me.tb_Recibo.Name = "tb_Recibo"
        Me.tb_Recibo.Size = New System.Drawing.Size(100, 20)
        Me.tb_Recibo.TabIndex = 0
        '
        'tb_Monto_Diferencia
        '
        Me.tb_Monto_Diferencia.Location = New System.Drawing.Point(113, 50)
        Me.tb_Monto_Diferencia.Name = "tb_Monto_Diferencia"
        Me.tb_Monto_Diferencia.Size = New System.Drawing.Size(100, 20)
        Me.tb_Monto_Diferencia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Recibo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Monto Diferencia: Q"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Actualizar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tb_Comentario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tb_Recibo)
        Me.GroupBox1.Controls.Add(Me.tb_Monto_Diferencia)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 166)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btn_Actualizar
        '
        Me.btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Actualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Actualizar.Location = New System.Drawing.Point(326, 22)
        Me.btn_Actualizar.Name = "btn_Actualizar"
        Me.btn_Actualizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Actualizar.TabIndex = 6
        Me.btn_Actualizar.Text = "Actualizar"
        Me.btn_Actualizar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Comentario:"
        '
        'tb_Comentario
        '
        Me.tb_Comentario.Location = New System.Drawing.Point(113, 76)
        Me.tb_Comentario.Multiline = True
        Me.tb_Comentario.Name = "tb_Comentario"
        Me.tb_Comentario.Size = New System.Drawing.Size(288, 84)
        Me.tb_Comentario.TabIndex = 4
        '
        'Frm_Recibos_Canal_Moderno_Actualizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(444, 190)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Recibos_Canal_Moderno_Actualizar"
        Me.Text = "Actualizar Recibos Canal Moderno"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tb_Recibo As System.Windows.Forms.TextBox
    Friend WithEvents tb_Monto_Diferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Actualizar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_Comentario As System.Windows.Forms.TextBox
End Class
