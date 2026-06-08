<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cancelacion_Compromisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cancelacion_Compromisos))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_Ubicacion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_FechaF = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaI = New System.Windows.Forms.DateTimePicker()
        Me.btn_Genera = New System.Windows.Forms.Button()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.tb_Correlativo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Activar = New System.Windows.Forms.Button()
        Me.tb_Intro = New System.Windows.Forms.TextBox()
        Me.lbAleatorio = New System.Windows.Forms.Label()
        Me.btn_GenRandom = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_Usuario = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cb_Ubicacion)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.dtp_FechaF)
        Me.GroupBox4.Controls.Add(Me.dtp_FechaI)
        Me.GroupBox4.Controls.Add(Me.btn_Genera)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 42)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(418, 114)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generar Información"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Ubicación:"
        '
        'cb_Ubicacion
        '
        Me.cb_Ubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Ubicacion.FormattingEnabled = True
        Me.cb_Ubicacion.Location = New System.Drawing.Point(87, 65)
        Me.cb_Ubicacion.Name = "cb_Ubicacion"
        Me.cb_Ubicacion.Size = New System.Drawing.Size(164, 21)
        Me.cb_Ubicacion.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(163, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Fecha Final:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Fecha Inicial:"
        '
        'dtp_FechaF
        '
        Me.dtp_FechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaF.Location = New System.Drawing.Point(161, 35)
        Me.dtp_FechaF.Name = "dtp_FechaF"
        Me.dtp_FechaF.Size = New System.Drawing.Size(90, 20)
        Me.dtp_FechaF.TabIndex = 2
        '
        'dtp_FechaI
        '
        Me.dtp_FechaI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaI.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtp_FechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaI.Location = New System.Drawing.Point(24, 35)
        Me.dtp_FechaI.Name = "dtp_FechaI"
        Me.dtp_FechaI.Size = New System.Drawing.Size(90, 20)
        Me.dtp_FechaI.TabIndex = 1
        '
        'btn_Genera
        '
        Me.btn_Genera.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Genera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Genera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Genera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Genera.ImageIndex = 3
        Me.btn_Genera.Location = New System.Drawing.Point(305, 33)
        Me.btn_Genera.Name = "btn_Genera"
        Me.btn_Genera.Size = New System.Drawing.Size(92, 53)
        Me.btn_Genera.TabIndex = 0
        Me.btn_Genera.Text = "Genera"
        Me.btn_Genera.UseVisualStyleBackColor = False
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Actualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Actualiza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Actualiza.Location = New System.Drawing.Point(305, 22)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(91, 36)
        Me.btn_Actualiza.TabIndex = 8
        Me.btn_Actualiza.Text = "Actualiza √"
        Me.btn_Actualiza.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox1.Controls.Add(Me.tb_Correlativo)
        Me.GroupBox1.Controls.Add(Me.btn_Actualiza)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 77)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Actualización"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Correlativo"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(161, 39)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(90, 20)
        Me.dtp_Fecha.TabIndex = 10
        '
        'tb_Correlativo
        '
        Me.tb_Correlativo.Location = New System.Drawing.Point(24, 38)
        Me.tb_Correlativo.Name = "tb_Correlativo"
        Me.tb_Correlativo.Size = New System.Drawing.Size(90, 20)
        Me.tb_Correlativo.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btn_Activar)
        Me.GroupBox2.Controls.Add(Me.tb_Intro)
        Me.GroupBox2.Controls.Add(Me.lbAleatorio)
        Me.GroupBox2.Controls.Add(Me.btn_GenRandom)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 68)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Anulación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ingrese Contraseña"
        '
        'btn_Activar
        '
        Me.btn_Activar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Activar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Activar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Activar.Location = New System.Drawing.Point(261, 29)
        Me.btn_Activar.Name = "btn_Activar"
        Me.btn_Activar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Activar.TabIndex = 3
        Me.btn_Activar.Text = "Activar"
        Me.btn_Activar.UseVisualStyleBackColor = False
        '
        'tb_Intro
        '
        Me.tb_Intro.Location = New System.Drawing.Point(170, 30)
        Me.tb_Intro.Name = "tb_Intro"
        Me.tb_Intro.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_Intro.Size = New System.Drawing.Size(90, 20)
        Me.tb_Intro.TabIndex = 2
        '
        'lbAleatorio
        '
        Me.lbAleatorio.AutoSize = True
        Me.lbAleatorio.Location = New System.Drawing.Point(108, 34)
        Me.lbAleatorio.Name = "lbAleatorio"
        Me.lbAleatorio.Size = New System.Drawing.Size(14, 13)
        Me.lbAleatorio.TabIndex = 1
        Me.lbAleatorio.Text = "#"
        '
        'btn_GenRandom
        '
        Me.btn_GenRandom.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_GenRandom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_GenRandom.Location = New System.Drawing.Point(14, 29)
        Me.btn_GenRandom.Name = "btn_GenRandom"
        Me.btn_GenRandom.Size = New System.Drawing.Size(75, 23)
        Me.btn_GenRandom.TabIndex = 0
        Me.btn_GenRandom.Text = "Generar"
        Me.btn_GenRandom.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Usuario Actual:"
        '
        'lb_Usuario
        '
        Me.lb_Usuario.AutoSize = True
        Me.lb_Usuario.Location = New System.Drawing.Point(330, 21)
        Me.lb_Usuario.Name = "lb_Usuario"
        Me.lb_Usuario.Size = New System.Drawing.Size(13, 13)
        Me.lb_Usuario.TabIndex = 16
        Me.lb_Usuario.Text = "::"
        '
        'Frm_Cancelacion_Compromisos
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(451, 340)
        Me.Controls.Add(Me.lb_Usuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Cancelacion_Compromisos"
        Me.Text = ":: Cancelación Compromisos ::"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Genera As System.Windows.Forms.Button
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_Correlativo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_GenRandom As System.Windows.Forms.Button
    Friend WithEvents lbAleatorio As System.Windows.Forms.Label
    Friend WithEvents btn_Activar As System.Windows.Forms.Button
    Friend WithEvents tb_Intro As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_Ubicacion As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lb_Usuario As Label
End Class
