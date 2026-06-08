<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Maquila_3PL_Producto
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_Cantidad = New System.Windows.Forms.Label()
        Me.lb_glosa = New System.Windows.Forms.Label()
        Me.lb_Maquilar = New System.Windows.Forms.Label()
        Me.lb_Producto = New System.Windows.Forms.Label()
        Me.lb_numero = New System.Windows.Forms.Label()
        Me.btn_Inicia = New System.Windows.Forms.Button()
        Me.btn_Finaliza = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lb_Cantidad)
        Me.GroupBox1.Controls.Add(Me.lb_glosa)
        Me.GroupBox1.Controls.Add(Me.lb_Maquilar)
        Me.GroupBox1.Controls.Add(Me.lb_Producto)
        Me.GroupBox1.Controls.Add(Me.lb_numero)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(4, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(747, 337)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 30)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cantidad"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 47)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Glosa"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 27)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Producto"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Número"
        '
        'lb_Cantidad
        '
        Me.lb_Cantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_Cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Cantidad.Location = New System.Drawing.Point(116, 138)
        Me.lb_Cantidad.Name = "lb_Cantidad"
        Me.lb_Cantidad.Size = New System.Drawing.Size(625, 30)
        Me.lb_Cantidad.TabIndex = 4
        Me.lb_Cantidad.Text = "Cantidad"
        '
        'lb_glosa
        '
        Me.lb_glosa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_glosa.Location = New System.Drawing.Point(116, 84)
        Me.lb_glosa.Name = "lb_glosa"
        Me.lb_glosa.Size = New System.Drawing.Size(625, 46)
        Me.lb_glosa.TabIndex = 3
        Me.lb_glosa.Text = "Glosa"
        '
        'lb_Maquilar
        '
        Me.lb_Maquilar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_Maquilar.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Maquilar.Location = New System.Drawing.Point(5, 177)
        Me.lb_Maquilar.Name = "lb_Maquilar"
        Me.lb_Maquilar.Size = New System.Drawing.Size(736, 151)
        Me.lb_Maquilar.TabIndex = 2
        Me.lb_Maquilar.Text = "Maquilar"
        '
        'lb_Producto
        '
        Me.lb_Producto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_Producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Producto.Location = New System.Drawing.Point(116, 50)
        Me.lb_Producto.Name = "lb_Producto"
        Me.lb_Producto.Size = New System.Drawing.Size(625, 27)
        Me.lb_Producto.TabIndex = 1
        Me.lb_Producto.Text = "Producto"
        '
        'lb_numero
        '
        Me.lb_numero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_numero.Location = New System.Drawing.Point(116, 16)
        Me.lb_numero.Name = "lb_numero"
        Me.lb_numero.Size = New System.Drawing.Size(625, 28)
        Me.lb_numero.TabIndex = 0
        Me.lb_numero.Text = "Número"
        '
        'btn_Inicia
        '
        Me.btn_Inicia.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Inicia.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Inicia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Inicia.Location = New System.Drawing.Point(279, 15)
        Me.btn_Inicia.Name = "btn_Inicia"
        Me.btn_Inicia.Size = New System.Drawing.Size(91, 58)
        Me.btn_Inicia.TabIndex = 1
        Me.btn_Inicia.Text = "Inicia"
        Me.btn_Inicia.UseVisualStyleBackColor = False
        Me.btn_Inicia.Visible = False
        '
        'btn_Finaliza
        '
        Me.btn_Finaliza.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Finaliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Finaliza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Finaliza.Location = New System.Drawing.Point(421, 15)
        Me.btn_Finaliza.Name = "btn_Finaliza"
        Me.btn_Finaliza.Size = New System.Drawing.Size(91, 58)
        Me.btn_Finaliza.TabIndex = 2
        Me.btn_Finaliza.Text = "Finaliza"
        Me.btn_Finaliza.UseVisualStyleBackColor = False
        Me.btn_Finaliza.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Inicia"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(560, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Finaliza"
        Me.Label6.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frm_Maquila_3PL_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(758, 416)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_Finaliza)
        Me.Controls.Add(Me.btn_Inicia)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frm_Maquila_3PL_Producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maquila 3PL por Producto"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Inicia As System.Windows.Forms.Button
    Friend WithEvents btn_Finaliza As System.Windows.Forms.Button
    Friend WithEvents lb_Producto As System.Windows.Forms.Label
    Friend WithEvents lb_numero As System.Windows.Forms.Label
    Friend WithEvents lb_Maquilar As System.Windows.Forms.Label
    Friend WithEvents lb_Cantidad As System.Windows.Forms.Label
    Friend WithEvents lb_glosa As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
