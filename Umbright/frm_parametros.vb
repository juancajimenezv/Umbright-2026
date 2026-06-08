Imports Microsoft.win32
Public Class frm_parametros
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tc_parametros As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_servidor_fl As System.Windows.Forms.TextBox
    Friend WithEvents txt_basededatos_fl As System.Windows.Forms.TextBox
    Friend WithEvents txt_usuario_fl As System.Windows.Forms.TextBox
    Friend WithEvents txt_clave_fl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_clave_sg As System.Windows.Forms.TextBox
    Friend WithEvents txt_usuario_sg As System.Windows.Forms.TextBox
    Friend WithEvents txt_servidor_sg As System.Windows.Forms.TextBox
    Friend WithEvents txt_basededatos_sg As System.Windows.Forms.TextBox
    Friend WithEvents tb_sg As System.Windows.Forms.TabPage
    Friend WithEvents tp_fl As System.Windows.Forms.TabPage
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tb_sg = New System.Windows.Forms.TabPage
        Me.txt_basededatos_sg = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_clave_sg = New System.Windows.Forms.TextBox
        Me.txt_usuario_sg = New System.Windows.Forms.TextBox
        Me.txt_servidor_sg = New System.Windows.Forms.TextBox
        Me.tc_parametros = New System.Windows.Forms.TabControl
        Me.tp_fl = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_clave_fl = New System.Windows.Forms.TextBox
        Me.txt_usuario_fl = New System.Windows.Forms.TextBox
        Me.txt_basededatos_fl = New System.Windows.Forms.TextBox
        Me.txt_servidor_fl = New System.Windows.Forms.TextBox
        Me.btn_Aceptar = New System.Windows.Forms.Button
        Me.ErrorP = New System.Windows.Forms.ErrorProvider
        Me.tb_sg.SuspendLayout()
        Me.tc_parametros.SuspendLayout()
        Me.tp_fl.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_sg
        '
        Me.tb_sg.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.tb_sg.Controls.Add(Me.txt_basededatos_sg)
        Me.tb_sg.Controls.Add(Me.Label5)
        Me.tb_sg.Controls.Add(Me.Label6)
        Me.tb_sg.Controls.Add(Me.Label7)
        Me.tb_sg.Controls.Add(Me.Label8)
        Me.tb_sg.Controls.Add(Me.txt_clave_sg)
        Me.tb_sg.Controls.Add(Me.txt_usuario_sg)
        Me.tb_sg.Controls.Add(Me.txt_servidor_sg)
        Me.tb_sg.Location = New System.Drawing.Point(4, 22)
        Me.tb_sg.Name = "tb_sg"
        Me.tb_sg.Size = New System.Drawing.Size(272, 150)
        Me.tb_sg.TabIndex = 0
        Me.tb_sg.Text = "SysGold"
        '
        'txt_basededatos_sg
        '
        Me.txt_basededatos_sg.Location = New System.Drawing.Point(120, 48)
        Me.txt_basededatos_sg.Name = "txt_basededatos_sg"
        Me.txt_basededatos_sg.Size = New System.Drawing.Size(128, 20)
        Me.txt_basededatos_sg.TabIndex = 9
        Me.txt_basededatos_sg.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Contraseña"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Usuario"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Base de Datos"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Servidor"
        '
        'txt_clave_sg
        '
        Me.txt_clave_sg.Location = New System.Drawing.Point(120, 112)
        Me.txt_clave_sg.Name = "txt_clave_sg"
        Me.txt_clave_sg.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txt_clave_sg.Size = New System.Drawing.Size(128, 20)
        Me.txt_clave_sg.TabIndex = 11
        Me.txt_clave_sg.Text = ""
        '
        'txt_usuario_sg
        '
        Me.txt_usuario_sg.Location = New System.Drawing.Point(120, 80)
        Me.txt_usuario_sg.Name = "txt_usuario_sg"
        Me.txt_usuario_sg.Size = New System.Drawing.Size(128, 20)
        Me.txt_usuario_sg.TabIndex = 10
        Me.txt_usuario_sg.Text = ""
        '
        'txt_servidor_sg
        '
        Me.txt_servidor_sg.Location = New System.Drawing.Point(120, 16)
        Me.txt_servidor_sg.Name = "txt_servidor_sg"
        Me.txt_servidor_sg.Size = New System.Drawing.Size(128, 20)
        Me.txt_servidor_sg.TabIndex = 8
        Me.txt_servidor_sg.Text = ""
        '
        'tc_parametros
        '
        Me.tc_parametros.Controls.Add(Me.tb_sg)
        Me.tc_parametros.Controls.Add(Me.tp_fl)
        Me.tc_parametros.ItemSize = New System.Drawing.Size(62, 18)
        Me.tc_parametros.Location = New System.Drawing.Point(16, 16)
        Me.tc_parametros.Name = "tc_parametros"
        Me.tc_parametros.SelectedIndex = 0
        Me.tc_parametros.Size = New System.Drawing.Size(280, 176)
        Me.tc_parametros.TabIndex = 0
        '
        'tp_fl
        '
        Me.tp_fl.BackColor = System.Drawing.SystemColors.Info
        Me.tp_fl.Controls.Add(Me.Label4)
        Me.tp_fl.Controls.Add(Me.Label3)
        Me.tp_fl.Controls.Add(Me.Label2)
        Me.tp_fl.Controls.Add(Me.Label1)
        Me.tp_fl.Controls.Add(Me.txt_clave_fl)
        Me.tp_fl.Controls.Add(Me.txt_usuario_fl)
        Me.tp_fl.Controls.Add(Me.txt_basededatos_fl)
        Me.tp_fl.Controls.Add(Me.txt_servidor_fl)
        Me.tp_fl.Location = New System.Drawing.Point(4, 22)
        Me.tp_fl.Name = "tp_fl"
        Me.tp_fl.Size = New System.Drawing.Size(272, 150)
        Me.tp_fl.TabIndex = 1
        Me.tp_fl.Text = "FlexLine"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Contraseña"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Base de Datos"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Servidor"
        '
        'txt_clave_fl
        '
        Me.txt_clave_fl.Location = New System.Drawing.Point(120, 112)
        Me.txt_clave_fl.Name = "txt_clave_fl"
        Me.txt_clave_fl.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txt_clave_fl.Size = New System.Drawing.Size(128, 20)
        Me.txt_clave_fl.TabIndex = 3
        Me.txt_clave_fl.Text = ""
        '
        'txt_usuario_fl
        '
        Me.txt_usuario_fl.Location = New System.Drawing.Point(120, 80)
        Me.txt_usuario_fl.Name = "txt_usuario_fl"
        Me.txt_usuario_fl.Size = New System.Drawing.Size(128, 20)
        Me.txt_usuario_fl.TabIndex = 2
        Me.txt_usuario_fl.Text = ""
        '
        'txt_basededatos_fl
        '
        Me.txt_basededatos_fl.Location = New System.Drawing.Point(120, 48)
        Me.txt_basededatos_fl.Name = "txt_basededatos_fl"
        Me.txt_basededatos_fl.Size = New System.Drawing.Size(128, 20)
        Me.txt_basededatos_fl.TabIndex = 1
        Me.txt_basededatos_fl.Text = ""
        '
        'txt_servidor_fl
        '
        Me.txt_servidor_fl.Location = New System.Drawing.Point(120, 16)
        Me.txt_servidor_fl.Name = "txt_servidor_fl"
        Me.txt_servidor_fl.Size = New System.Drawing.Size(128, 20)
        Me.txt_servidor_fl.TabIndex = 0
        Me.txt_servidor_fl.Text = ""
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(119, 203)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(72, 32)
        Me.btn_Aceptar.TabIndex = 1
        Me.btn_Aceptar.Text = "&Aceptar"
        '
        'ErrorP
        '
        Me.ErrorP.ContainerControl = Me
        '
        'frm_parametros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 246)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.tc_parametros)
        Me.Name = "frm_parametros"
        Me.Text = "Parametros"
        Me.tb_sg.ResumeLayout(False)
        Me.tc_parametros.ResumeLayout(False)
        Me.tp_fl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frm_parametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Leer_Registro("Sysgold")
        Leer_Registro("Flexline")
    End Sub
    Private Sub Leer_Registro(ByVal servidor As String)

        Dim regVersion As RegistryKey '= Registry.LocalMachine
        Dim keyValue As String
        Try
            'debe traer los nombres de los servidores p.e flexline o SysGold
            keyValue = "SOFTWARE\\" & Trim(servidor)
            regVersion = Registry.LocalMachine.OpenSubKey(keyValue, False)
            If (Not regVersion Is Nothing) Then
                If LCase(Trim(servidor)) = "sysgold" Then
                    Me.txt_basededatos_sg.Text = regVersion.GetValue("base_datos", 0)
                    Me.txt_servidor_sg.Text = regVersion.GetValue("servidor", 0)
                    Me.txt_usuario_sg.Text = regVersion.GetValue("usuario", 0)
                    Me.txt_clave_sg.Text = regVersion.GetValue("clave", 0)
                End If

                If LCase(Trim(servidor)) = "flexline" Then
                    Me.txt_basededatos_fl.Text = regVersion.GetValue("base_datos", 0)
                    Me.txt_servidor_fl.Text = regVersion.GetValue("servidor", 0)
                    Me.txt_usuario_fl.Text = regVersion.GetValue("usuario", 0)
                    Me.txt_clave_fl.Text = regVersion.GetValue("clave", 0)
                End If

                regVersion.Close()
            End If
        Finally
        End Try

    End Sub

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        If Len(Me.txt_basededatos_fl.Text) = 0 Or Len(Me.txt_clave_fl.Text) = 0 Or Len(Me.txt_servidor_fl.Text) = 0 Or Len(Me.txt_usuario_fl.Text) = 0 Then
            MessageBox.Show("Debe Complementar la Informacion", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Len(Me.txt_basededatos_fl.Text) = 0 Or Len(Me.txt_clave_fl.Text) = 0 Or Len(Me.txt_servidor_fl.Text) = 0 Or Len(Me.txt_usuario_fl.Text) = 0 Then
            MessageBox.Show("Debe Complementar la Informacion", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Actualizar_Registro()
        End If

    End Sub
    Private Sub Actualizar_Registro()


        Dim regVersion As RegistryKey
        regVersion = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sysgold", True)
        If regVersion Is Nothing Then
            ' No existe la clave, crearla.
            regVersion = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sysgold")
        End If
        regVersion.SetValue("base_datos", Me.txt_basededatos_sg.Text)
        regVersion.SetValue("servidor", Me.txt_servidor_sg.Text)
        regVersion.SetValue("usuario", Me.txt_usuario_sg.Text)
        regVersion.SetValue("clave", Me.txt_clave_sg.Text)


        regVersion = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Flexline", True)
        If regVersion Is Nothing Then
            ' No existe la clave, crearla.
            regVersion = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Flexline")
        End If
        regVersion.SetValue("base_datos", Me.txt_basededatos_fl.Text)
        regVersion.SetValue("servidor", Me.txt_servidor_fl.Text)
        regVersion.SetValue("usuario", Me.txt_usuario_fl.Text)
        regVersion.SetValue("clave", Me.txt_clave_fl.Text)

        MessageBox.Show("Actualizacion Existosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
