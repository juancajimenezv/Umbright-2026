<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_suspension
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
        Me.tb_Ficha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_Jefe = New System.Windows.Forms.Label()
        Me.lb_Fecha_Ingreso = New System.Windows.Forms.Label()
        Me.lb_Puesto = New System.Windows.Forms.Label()
        Me.lb_Departamento = New System.Windows.Forms.Label()
        Me.lb_Area = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cb_Motivo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_CausaDiagnostico = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_FechaAlta = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaAccidente = New System.Windows.Forms.DateTimePicker()
        Me.btn_Actulizar = New System.Windows.Forms.Button()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_FechaF = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaI = New System.Windows.Forms.DateTimePicker()
        Me.lb_Nombre = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_Impresion = New System.Windows.Forms.Button()
        Me.btn_Suspendidos = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_Ficha
        '
        Me.tb_Ficha.Location = New System.Drawing.Point(92, 27)
        Me.tb_Ficha.Name = "tb_Ficha"
        Me.tb_Ficha.Size = New System.Drawing.Size(100, 20)
        Me.tb_Ficha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empleado:"
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Location = New System.Drawing.Point(192, 27)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(21, 20)
        Me.btn_Buscar.TabIndex = 2
        Me.btn_Buscar.Text = "B."
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Area:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lb_Jefe)
        Me.GroupBox1.Controls.Add(Me.lb_Fecha_Ingreso)
        Me.GroupBox1.Controls.Add(Me.lb_Puesto)
        Me.GroupBox1.Controls.Add(Me.lb_Departamento)
        Me.GroupBox1.Controls.Add(Me.lb_Area)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 253)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos  "
        '
        'lb_Jefe
        '
        Me.lb_Jefe.AutoSize = True
        Me.lb_Jefe.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Jefe.Location = New System.Drawing.Point(94, 155)
        Me.lb_Jefe.Name = "lb_Jefe"
        Me.lb_Jefe.Size = New System.Drawing.Size(76, 13)
        Me.lb_Jefe.TabIndex = 12
        Me.lb_Jefe.Text = "Jefe Inmediato"
        '
        'lb_Fecha_Ingreso
        '
        Me.lb_Fecha_Ingreso.AutoSize = True
        Me.lb_Fecha_Ingreso.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Fecha_Ingreso.Location = New System.Drawing.Point(96, 128)
        Me.lb_Fecha_Ingreso.Name = "lb_Fecha_Ingreso"
        Me.lb_Fecha_Ingreso.Size = New System.Drawing.Size(75, 13)
        Me.lb_Fecha_Ingreso.TabIndex = 11
        Me.lb_Fecha_Ingreso.Text = "Fecha Ingreso"
        '
        'lb_Puesto
        '
        Me.lb_Puesto.AutoSize = True
        Me.lb_Puesto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Puesto.Location = New System.Drawing.Point(96, 102)
        Me.lb_Puesto.Name = "lb_Puesto"
        Me.lb_Puesto.Size = New System.Drawing.Size(40, 13)
        Me.lb_Puesto.TabIndex = 10
        Me.lb_Puesto.Text = "Puesto"
        '
        'lb_Departamento
        '
        Me.lb_Departamento.AutoSize = True
        Me.lb_Departamento.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Departamento.Location = New System.Drawing.Point(96, 75)
        Me.lb_Departamento.Name = "lb_Departamento"
        Me.lb_Departamento.Size = New System.Drawing.Size(74, 13)
        Me.lb_Departamento.TabIndex = 9
        Me.lb_Departamento.Text = "Departamento"
        '
        'lb_Area
        '
        Me.lb_Area.AutoSize = True
        Me.lb_Area.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Area.Location = New System.Drawing.Point(96, 50)
        Me.lb_Area.Name = "lb_Area"
        Me.lb_Area.Size = New System.Drawing.Size(29, 13)
        Me.lb_Area.TabIndex = 8
        Me.lb_Area.Text = "Area"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Jefe Inmediato:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Fecha ‌Ingreso:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Puesto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Departamento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Nombre:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cb_Motivo)
        Me.GroupBox2.Location = New System.Drawing.Point(330, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 73)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Suspensión "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Motivo;"
        '
        'cb_Motivo
        '
        Me.cb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Motivo.FormattingEnabled = True
        Me.cb_Motivo.Location = New System.Drawing.Point(86, 28)
        Me.cb_Motivo.Name = "cb_Motivo"
        Me.cb_Motivo.Size = New System.Drawing.Size(199, 21)
        Me.cb_Motivo.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(335, 338)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Causa / Diasgnostico:"
        '
        'tb_CausaDiagnostico
        '
        Me.tb_CausaDiagnostico.Location = New System.Drawing.Point(337, 355)
        Me.tb_CausaDiagnostico.Name = "tb_CausaDiagnostico"
        Me.tb_CausaDiagnostico.Size = New System.Drawing.Size(313, 20)
        Me.tb_CausaDiagnostico.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(200, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Fecha Alta:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fecha Inicial:"
        '
        'dtp_FechaAlta
        '
        Me.dtp_FechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaAlta.Location = New System.Drawing.Point(202, 41)
        Me.dtp_FechaAlta.Name = "dtp_FechaAlta"
        Me.dtp_FechaAlta.Size = New System.Drawing.Size(101, 20)
        Me.dtp_FechaAlta.TabIndex = 9
        '
        'dtp_FechaAccidente
        '
        Me.dtp_FechaAccidente.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaAccidente.Location = New System.Drawing.Point(36, 41)
        Me.dtp_FechaAccidente.Name = "dtp_FechaAccidente"
        Me.dtp_FechaAccidente.Size = New System.Drawing.Size(101, 20)
        Me.dtp_FechaAccidente.TabIndex = 8
        '
        'btn_Actulizar
        '
        Me.btn_Actulizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Actulizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Actulizar.Location = New System.Drawing.Point(398, 386)
        Me.btn_Actulizar.Name = "btn_Actulizar"
        Me.btn_Actulizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Actulizar.TabIndex = 14
        Me.btn_Actulizar.Text = "Actualizar"
        Me.btn_Actulizar.UseVisualStyleBackColor = False
        '
        'btn_Guardar
        '
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Guardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Guardar.Location = New System.Drawing.Point(504, 386)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Guardar.TabIndex = 13
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(205, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Fecha Final:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Fecha Inicio:"
        '
        'dtp_FechaF
        '
        Me.dtp_FechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaF.Location = New System.Drawing.Point(198, 42)
        Me.dtp_FechaF.Name = "dtp_FechaF"
        Me.dtp_FechaF.Size = New System.Drawing.Size(101, 20)
        Me.dtp_FechaF.TabIndex = 11
        '
        'dtp_FechaI
        '
        Me.dtp_FechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaI.Location = New System.Drawing.Point(34, 43)
        Me.dtp_FechaI.Name = "dtp_FechaI"
        Me.dtp_FechaI.Size = New System.Drawing.Size(101, 20)
        Me.dtp_FechaI.TabIndex = 10
        '
        'lb_Nombre
        '
        Me.lb_Nombre.AutoSize = True
        Me.lb_Nombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Nombre.Location = New System.Drawing.Point(92, 61)
        Me.lb_Nombre.Name = "lb_Nombre"
        Me.lb_Nombre.Size = New System.Drawing.Size(113, 13)
        Me.lb_Nombre.TabIndex = 7
        Me.lb_Nombre.Text = "Nombre Del Empleado"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_Impresion)
        Me.GroupBox3.Controls.Add(Me.btn_Suspendidos)
        Me.GroupBox3.Controls.Add(Me.btn_Limpiar)
        Me.GroupBox3.Location = New System.Drawing.Point(330, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(326, 45)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ejecutar "
        '
        'btn_Impresion
        '
        Me.btn_Impresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Impresion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Impresion.Location = New System.Drawing.Point(211, 14)
        Me.btn_Impresion.Name = "btn_Impresion"
        Me.btn_Impresion.Size = New System.Drawing.Size(75, 23)
        Me.btn_Impresion.TabIndex = 2
        Me.btn_Impresion.Text = "Impresión"
        Me.btn_Impresion.UseVisualStyleBackColor = False
        '
        'btn_Suspendidos
        '
        Me.btn_Suspendidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Suspendidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Suspendidos.Location = New System.Drawing.Point(124, 14)
        Me.btn_Suspendidos.Name = "btn_Suspendidos"
        Me.btn_Suspendidos.Size = New System.Drawing.Size(75, 23)
        Me.btn_Suspendidos.TabIndex = 1
        Me.btn_Suspendidos.Text = "Buscar"
        Me.btn_Suspendidos.UseVisualStyleBackColor = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Limpiar.Location = New System.Drawing.Point(38, 14)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Limpiar.TabIndex = 0
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtp_FechaAccidente)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.dtp_FechaAlta)
        Me.GroupBox4.Location = New System.Drawing.Point(330, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(326, 74)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fechas de Suspensión Real"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.dtp_FechaI)
        Me.GroupBox5.Controls.Add(Me.dtp_FechaF)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(330, 240)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(326, 81)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fechas Para Cálculos Laborales"
        '
        'Frm_suspension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(665, 412)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tb_CausaDiagnostico)
        Me.Controls.Add(Me.lb_Nombre)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Actulizar)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_Ficha)
        Me.Name = "Frm_suspension"
        Me.Text = "Control De Suspensión"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_Ficha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cb_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents lb_Departamento As System.Windows.Forms.Label
    Friend WithEvents lb_Area As System.Windows.Forms.Label
    Friend WithEvents lb_Jefe As System.Windows.Forms.Label
    Friend WithEvents lb_Fecha_Ingreso As System.Windows.Forms.Label
    Friend WithEvents lb_Puesto As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Suspendidos As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Actulizar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaAccidente As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_CausaDiagnostico As System.Windows.Forms.TextBox
    Friend WithEvents btn_Impresion As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
