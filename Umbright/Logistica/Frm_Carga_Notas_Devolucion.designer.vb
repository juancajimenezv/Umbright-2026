<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Carga_Notas_Devolucion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Carga_Notas_Devolucion))
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_Fecha = New System.Windows.Forms.Label()
        Me.lb_Cliente = New System.Windows.Forms.Label()
        Me.lb_Nombre = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_Total = New System.Windows.Forms.Label()
        Me.lb_Comentario = New System.Windows.Forms.Label()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(186, 249)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Agregar.TabIndex = 0
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(85, 46)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(100, 20)
        Me.tb_Numero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nombre:"
        '
        'lb_Fecha
        '
        Me.lb_Fecha.AutoSize = True
        Me.lb_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Fecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Fecha.Location = New System.Drawing.Point(87, 77)
        Me.lb_Fecha.Name = "lb_Fecha"
        Me.lb_Fecha.Size = New System.Drawing.Size(42, 13)
        Me.lb_Fecha.TabIndex = 6
        Me.lb_Fecha.Text = "Fecha"
        '
        'lb_Cliente
        '
        Me.lb_Cliente.AutoSize = True
        Me.lb_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Cliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Cliente.Location = New System.Drawing.Point(87, 104)
        Me.lb_Cliente.Name = "lb_Cliente"
        Me.lb_Cliente.Size = New System.Drawing.Size(46, 13)
        Me.lb_Cliente.TabIndex = 7
        Me.lb_Cliente.Text = "Cliente"
        '
        'lb_Nombre
        '
        Me.lb_Nombre.AutoSize = True
        Me.lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Nombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Nombre.Location = New System.Drawing.Point(87, 131)
        Me.lb_Nombre.Name = "lb_Nombre"
        Me.lb_Nombre.Size = New System.Drawing.Size(50, 13)
        Me.lb_Nombre.TabIndex = 8
        Me.lb_Nombre.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Total:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Comentario:"
        '
        'lb_Total
        '
        Me.lb_Total.AutoSize = True
        Me.lb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Total.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Total.Location = New System.Drawing.Point(87, 160)
        Me.lb_Total.Name = "lb_Total"
        Me.lb_Total.Size = New System.Drawing.Size(32, 13)
        Me.lb_Total.TabIndex = 11
        Me.lb_Total.Text = "0.00"
        '
        'lb_Comentario
        '
        Me.lb_Comentario.AutoSize = True
        Me.lb_Comentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Comentario.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Comentario.Location = New System.Drawing.Point(87, 188)
        Me.lb_Comentario.Name = "lb_Comentario"
        Me.lb_Comentario.Size = New System.Drawing.Size(70, 13)
        Me.lb_Comentario.TabIndex = 12
        Me.lb_Comentario.Text = "Comentario"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Nuevo.Location = New System.Drawing.Point(98, 249)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_Nuevo.TabIndex = 13
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = False
        '
        'cb_Empresa
        '
        Me.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa.FormattingEnabled = True
        Me.cb_Empresa.Items.AddRange(New Object() {"", "ALAMSA", "CODICASA", "DIMAEXSA", "DIUVA", "DMARTE1", "VINOTECA"})
        Me.cb_Empresa.Location = New System.Drawing.Point(85, 17)
        Me.cb_Empresa.Name = "cb_Empresa"
        Me.cb_Empresa.Size = New System.Drawing.Size(100, 21)
        Me.cb_Empresa.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Empresa:"
        '
        'Frm_Carga_Notas_Devolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(329, 279)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cb_Empresa)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Controls.Add(Me.lb_Comentario)
        Me.Controls.Add(Me.lb_Total)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb_Nombre)
        Me.Controls.Add(Me.lb_Cliente)
        Me.Controls.Add(Me.lb_Fecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_Numero)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Carga_Notas_Devolucion"
        Me.Text = "Carga Notas De Devolución"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents tb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lb_Fecha As System.Windows.Forms.Label
    Friend WithEvents lb_Cliente As System.Windows.Forms.Label
    Friend WithEvents lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_Total As System.Windows.Forms.Label
    Friend WithEvents lb_Comentario As System.Windows.Forms.Label
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
