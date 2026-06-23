Imports System.Management
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Interop
Imports System.Text

Public Class frm_login
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
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents btn_passwordless As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_login))
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btn_passwordless = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_usuario
        '
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_usuario.Location = New System.Drawing.Point(50, 244)
        Me.txt_usuario.MaxLength = 25
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(320, 28)
        Me.txt_usuario.TabIndex = 0
        '
        'txt_password
        '
        Me.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_password.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_password.Location = New System.Drawing.Point(50, 302)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(320, 28)
        Me.txt_password.TabIndex = 1
        '
        'cmb_empresa
        '
        Me.cmb_empresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb_empresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_empresa.BackColor = System.Drawing.Color.White
        Me.cmb_empresa.DropDownWidth = 320
        Me.cmb_empresa.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_empresa.ForeColor = System.Drawing.Color.FromArgb(55, 62, 28)
        Me.cmb_empresa.Location = New System.Drawing.Point(50, 360)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(320, 28)
        Me.cmb_empresa.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(55, 62, 28)
        Me.Label1.Location = New System.Drawing.Point(50, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(55, 62, 28)
        Me.Label2.Location = New System.Drawing.Point(50, 282)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(55, 62, 28)
        Me.Label3.Location = New System.Drawing.Point(50, 340)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(320, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Empresa"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.FromArgb(196, 81, 35)
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.FlatAppearance.BorderSize = 0
        Me.btn_aceptar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.ForeColor = System.Drawing.Color.White
        Me.btn_aceptar.Location = New System.Drawing.Point(50, 410)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(155, 40)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Ingresar"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(120, 120, 112)
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.FlatAppearance.BorderSize = 0
        Me.btn_cancelar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_cancelar.Location = New System.Drawing.Point(215, 410)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(155, 40)
        Me.btn_cancelar.TabIndex = 7
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(86, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 16)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(130, 78)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(120, 120, 112)
        Me.lblVersion.Location = New System.Drawing.Point(50, 488)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(29, 14)
        Me.lblVersion.TabIndex = 10
        Me.lblVersion.Text = "0.0."
        '
        'btn_passwordless
        '
        Me.btn_passwordless.BackColor = System.Drawing.Color.FromArgb(106, 116, 56)
        Me.btn_passwordless.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_passwordless.FlatAppearance.BorderSize = 0
        Me.btn_passwordless.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_passwordless.ForeColor = System.Drawing.Color.White
        Me.btn_passwordless.Location = New System.Drawing.Point(50, 462)
        Me.btn_passwordless.Name = "btn_passwordless"
        Me.btn_passwordless.Size = New System.Drawing.Size(320, 36)
        Me.btn_passwordless.TabIndex = 11
        Me.btn_passwordless.Text = "Ingreso &Sin Clave"
        Me.ToolTip1.SetToolTip(Me.btn_passwordless, "Se envirá un TOKEN al Número de Celular Asociado con el usuario, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "si desea cambi" &
        "ar el número de celular asociado, por favor generar un ticket")
        Me.btn_passwordless.UseVisualStyleBackColor = False
        Me.btn_passwordless.Visible = False
        '
        'frm_login
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(242, 240, 234)
        Me.ClientSize = New System.Drawing.Size(420, 510)
        Me.Controls.Add(Me.btn_passwordless)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Umbright - Inicio de Sesion"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim liIntentosFallidos As Integer = 0
    Private Sub Buscar_iguales()
        Dim ls_sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim oSeg As New Seguridad.Usuario("sql", "flexline")

        Try
            otrans.open()

            ls_sql = "pa_sel_um_sg_usuario_todos"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                ls_sql = "'" & dr.Item("usuario") & "','" & dr.Item("usuario") & "','dmarte1'"
                If oSeg.Tiene_Acceso(dr.Item("usuario"), dr.Item("usuario"), "dmarte1") Then
                    MessageBox.Show(dr.Item("usuario"))
                End If
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            oSeg = Nothing
        End Try

    End Sub


    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        salir()
    End Sub

    Private Sub salir()
        pb_acceso = False
        Me.Close()
    End Sub



    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        Validar_Usuario()
    End Sub




    Private Sub Validar_Usuario()
        Dim oSeguridad As New Seguridad.Usuario("sql", "flexline")
        If oSeguridad.existe_usuario(Me.txt_usuario.Text) Then

            pb_acceso = oSeguridad.Tiene_Acceso(Me.txt_usuario.Text, Me.txt_password.Text, Me.cmb_empresa.Text.Trim)

            If pb_acceso = True Then



                gs_empresa = Me.cmb_empresa.Text.Trim
                gs_usuario = Me.txt_usuario.Text.Trim

                'verificarValores() Deshabilitado (c) 20180322
                If Me.txt_usuario.Text.ToLower.Equals(Me.txt_password.Text.ToLower) Or claveDebil(Me.txt_password.Text) Or oSeguridad.lbAntigua Then
                    'MessageBox.Show("Es Necesario Que Cambie Su Contraseña", "Verificacion Urgente!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    pbPedirDobleFactor = True
                End If
                guardarLogB("Acceso Umbright", Me.txt_usuario.Text, "", Me.Name)

                Try
                    Dim clsgen As New ClasesGenerales.General
                    Dim dt As DataTable

                    dt = clsgen.selectQuery("Flexline", "pa_sel_um_gen_tabcod null,'MDFO_EMPRESA','" & gs_empresa & "'")
                    If dt.Rows.Count > 0 Then
                        mdfo_gs_empresa = dt.Rows(0).Item("codigo").ToString
                    End If
                Catch ex As Exception

                End Try
                Me.Close()
            Else
                MessageBox.Show("Ingreso una Contraseña Invalida", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txt_password.SelectAll()
                Me.txt_password.Focus()
                guardarLogB("IntentoFallido", Me.txt_usuario.Text, "", Me.Name)
                liIntentosFallidos += 1
                If liIntentosFallidos > 5 Then
                    enviarAvisoIntentosFallidos()
                End If
            End If
        Else
            MessageBox.Show("Usuario No Existe, Por Favor Verifique", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub enviarAvisoIntentosFallidos()
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General


        Try



            dt = clsGen.Fecha_Servidor("FlexLine")
            'lsSQL = lsSQL & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "'"
            'ClsGen.insertQuery("RegionalDBintOut", lsSQL)

            Dim varMotivo As String = "Intento de Acceso Fallido Umbright"
            Dim varMensajeAEnviar As String = "Desde Equipo: " & gs_nombre_equipo & "|" &
                "Usuario : " & Me.txt_usuario.Text & "|" &
                "Numero de Intentos : " & liIntentosFallidos & "|" & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "| **** IMPORTANTE *** Si usted no realizó esta acción, comuniquese con Informatica y Tecnologia"

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & gs_cuenta_usuario & """,
              ""Motivo"": """ & varMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
            }"
            Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            response = request.GetResponse()
            Dim sr As New StreamReader(response.GetResponseStream())
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txt_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.LostFocus
        'Verificar Usuario, cargar empresas asignadas a usuario
        Dim ldt_table As New DataTable
        Dim ls_SqlScript As String
        Dim otransaccion As New Transaccional.Conexion("flexline")
        otransaccion.open()

        ls_SqlScript = "flexline.pa_sel_um_sg_usuario_empresa '" & Me.txt_usuario.Text & "'"
        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        otransaccion.close()
        otransaccion = Nothing

        Me.btn_passwordless.Visible = False
        Me.ClientSize = New System.Drawing.Size(420, 510)

        Me.cmb_empresa.DisplayMember = "empresa"
        Me.cmb_empresa.ValueMember = "empresa"
        Me.cmb_empresa.DataSource = ldt_table

        Try
            gs_ubicacion = ldt_table.Rows(0).Item("ubicacion").ToString
            gi_tipo_usuario = ldt_table.Rows(0).Item("tipo_usuario").ToString
            gs_nombre_usuario = ldt_table.Rows(0).Item("nombre").ToString
            gs_cuenta_usuario = ldt_table.Rows(0).Item("cuenta_office").ToString
            gs_medio_preferido_validacion = ldt_table.Rows(0).Item("metodo_validacion").ToString
            gs_numero_telefonico = ldt_table.Rows(0).Item("telefono").ToString
            gs_nivel_riesgo = ldt_table.Rows(0).Item("nivel_riesgo").ToString
            gs_passwordless = ldt_table.Rows(0).Item("passwordless").ToString

            If gs_passwordless.ToUpper.Equals("SI") Then
                Me.btn_passwordless.Visible = True

                Me.ClientSize = New System.Drawing.Size(420, 516)
                'Me.Size.Height = 224

            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmb_empresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_empresa.KeyPress

        If e.KeyChar = Chr(13) Then
            Validar_Usuario()
        End If
    End Sub

    Private Sub txt_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_password.KeyPress
        If e.KeyChar = Chr(13) Then
            Validar_Usuario()
        End If
    End Sub

    Private Sub txt_password_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_password.Enter
        'Cuando Entre que seleccione todo, es similar a hacer selectonentry
        Me.txt_password.SelectAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Buscar_iguales()
    End Sub

    Private Sub frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' -- Header --
        Dim pnlHeader As New Panel()
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 68
        pnlHeader.BackColor = Color.FromArgb(45, 50, 22)

        Dim lblSistema As New Label()
        lblSistema.Text = "UMBRIGHT ERP"
        lblSistema.ForeColor = Color.FromArgb(196, 81, 35)
        lblSistema.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblSistema.AutoSize = True
        lblSistema.Location = New Point(16, 10)

        Dim lblSubtitulo As New Label()
        lblSubtitulo.Text = "Sistema de Gestion Empresarial"
        lblSubtitulo.ForeColor = Color.FromArgb(180, 185, 150)
        lblSubtitulo.Font = New Font("Segoe UI", 8F, FontStyle.Regular)
        lblSubtitulo.AutoSize = True
        lblSubtitulo.Location = New Point(16, 26)

        Dim lblBienvenida As New Label()
        lblBienvenida.Text = "Bienvenido, ingrese sus credenciales"
        lblBienvenida.ForeColor = Color.White
        lblBienvenida.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblBienvenida.AutoSize = True
        lblBienvenida.Location = New Point(16, 42)

        pnlHeader.Controls.Add(lblSistema)
        pnlHeader.Controls.Add(lblSubtitulo)
        pnlHeader.Controls.Add(lblBienvenida)
        Me.Controls.Add(pnlHeader)
        pnlHeader.BringToFront()

        ' -- Card blanca de campos --
        Dim pnlCard As New Panel()
        pnlCard.Location = New Point(30, 212)
        pnlCard.Size = New Size(360, 210)
        pnlCard.BackColor = Color.White
        Me.Controls.Add(pnlCard)
        pnlCard.SendToBack()

        ' Acento naranja izquierdo en la card
        Dim pnlCardAccent As New Panel()
        pnlCardAccent.Dock = DockStyle.Left
        pnlCardAccent.Width = 4
        pnlCardAccent.BackColor = Color.FromArgb(196, 81, 35)
        pnlCard.Controls.Add(pnlCardAccent)
        ' Inputs redondeados y botones
        WrapRounded(txt_usuario)
        WrapRounded(txt_password)
        'lblVersion.Text = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString & " " & Application.ProductVersion
        lblVersion.Text = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString & " " & "8.26.1.2"




    End Sub

    Private Sub txt_usuario_SizeChanged(sender As Object, e As EventArgs) Handles txt_usuario.SizeChanged

    End Sub

    Private Sub txt_usuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_usuario.TextChanged

    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged

    End Sub

    Private Sub verificarValores()


        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim lsSQL As String
        Dim objWMI As New WMI()
        Try


            Dim Host As String
            ' Si no se pasa como parametro un nombre, muestra las ip locales
            If Environment.GetCommandLineArgs().Length > 1 Then
                Host = Environment.GetCommandLineArgs(1)
            Else
                Host = Dns.GetHostName
            End If

            Dim IPs As IPHostEntry = Dns.GetHostByName(Host)
            Dim Direcciones As IPAddress() = IPs.AddressList

            'Se despliega la lista de IP's



            lsSQL = "call pa_ins_um_seg_usuario_hardware_software_um ('"
            Dim bit As String
            Dim VGA As String
            If My.Computer.Registry.LocalMachine.OpenSubKey("Hardware\Description\System\CentralProcessor\0").GetValue("Identifier").ToString.Contains("x86") Then
                bit = "32-bit"
            Else
                bit = "64-bit"
            End If
            'Console.Title = "System Information's"
            Console.WriteLine("your system information's")
            Console.WriteLine("")
            Console.WriteLine(My.Computer.Info.OSFullName.ToString())
            Console.WriteLine(My.Computer.Info.OSPlatform.ToString())
            Console.WriteLine(My.Computer.Info.OSVersion.ToString())
            Console.WriteLine("Windows bit version: " + bit)
            Console.WriteLine("Computer Name: " & My.Computer.Name.ToString())

            '(c) 20160927 Juntamente con el nombre de la computadora guardo el usuario de umbright utilizado

            'lsSQL = lsSQL + My.Computer.Name.ToString() & "-" & gs_usuario & "','"

            lsSQL = lsSQL + My.Computer.Name.ToString() & "','" '& "-" & gs_usuario & "','"
            For i_cont As Integer = 0 To Direcciones.Length - 1
                If Direcciones(i_cont).ToString.IndexOf(".192") > 0 Or Direcciones(i_cont).ToString.IndexOf("172") >= 0 Then
                    lsSQL = lsSQL & Direcciones(i_cont).ToString() & ","
                End If
            Next
            lsSQL = lsSQL & "','"
            lsSQL = lsSQL & My.Computer.Info.OSFullName.ToString() & "','"
            lsSQL = lsSQL & bit & "','"
            lsSQL = lsSQL & objWMI.Manufacturer & "','"
            lsSQL = lsSQL & objWMI.Model & "','"

            Console.WriteLine("Computer Language: " & System.Globalization.CultureInfo.CurrentCulture.DisplayName)
            Console.WriteLine("Current Date/Time: " & Date.Now.ToLongDateString + ", " + Date.Now.ToLongTimeString)
            Console.WriteLine("")

            With objWMI
                Console.WriteLine("Computer Manufacturer = " & .Manufacturer)
                Console.WriteLine("Computer Model = " & .Model)
                Console.WriteLine("OS Version = " & .OSVersion)
                Console.WriteLine("System Type = " & .SystemType)
                Console.WriteLine("Windows Directory = " & .WindowsDirectory)
            End With
            Console.WriteLine("")
            Console.WriteLine("Number of Processes" & Environment.ProcessorCount.ToString)
            Dim moSearch As New ManagementObjectSearcher("Select * from Win32_Processor")
            Dim moReturn As ManagementObjectCollection = moSearch.Get
            For Each mo As ManagementObject In moReturn
                Console.WriteLine("Processor: " & (mo("name")))
                lsSQL = lsSQL & mo("name") & ","
            Next
            lsSQL = lsSQL & "','"

            Dim ramsize As Integer
            ramsize = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024
            Console.WriteLine("Memory: " & ramsize.ToString & "MB RAM")

            lsSQL = lsSQL & ramsize.ToString & "','"


            Dim drive As DriveInfo


            drive = New DriveInfo("C")
            'lsSQL = lsSQL & "C:"
            lsSQL = lsSQL & Math.Round(drive.TotalSize / 1024 / 1024 / 1024, 2) & " / " & Math.Round(drive.TotalFreeSpace / 1024 / 1024 / 1024, 2)

            lsSQL = lsSQL & "','"
            lsSQL = lsSQL & Determine_OfficeVersion()
            lsSQL = lsSQL & "','"
            Console.WriteLine("")
            'Dim WmiSelect As New ManagementObjectSearcher _
            '("root\CIMV2", "SELECT * FROM Win32_VideoController")
            'For Each WmiResults As ManagementObject In WmiSelect.Get()
            '    VGA = WmiResults.GetPropertyValue("Name").ToString
            'Next
            'Console.WriteLine("Computer Display Info: " & VGA)

            Dim Buscar As New ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor")

            For Each queryObj As ManagementObject In Buscar.Get()
                'MsgBox("La Marca y Modelo de tu Monitor es '" & queryObj("Caption") & "'")
                'MsgBox("El Fabricante del Monitor es '" & queryObj("MonitorManufacturer") & "'")
                lsSQL = lsSQL & queryObj("Caption") & "','"
                lsSQL = lsSQL & queryObj("MonitorManufacturer")
                Exit For
            Next


            'Dim intX As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Width
            'Dim intY As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            'Console.WriteLine("Screen Resolution: " & intX & " X " & intY)
            'Console.WriteLine("")
            'Console.WriteLine("Total Physical Memory: " & My.Computer.Info.TotalPhysicalMemory.ToString())
            'Console.WriteLine("Total Virtual Memory: " & My.Computer.Info.TotalVirtualMemory.ToString())
            'Console.WriteLine("Available Virtual Memory: " & My.Computer.Info.AvailableVirtualMemory.ToString())
            'Console.WriteLine("Available Physical Memory: " & My.Computer.Info.AvailablePhysicalMemory.ToString())
            'Console.WriteLine("Network Available: " & My.Computer.Network.IsAvailable.ToString())
            lsSQL = lsSQL & "','" & Application.ProductVersion
            lsSQL = lsSQL & "')"
            myOtrans.open()
            myOtrans.Ingresa(lsSQL)
            'Video()
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub


    Private Function Determine_OfficeVersion() As String
        Dim strEVersion As String 'Identify Version
        Try

            Dim objEApp As Excel.Application 'Excel Object
            ' Dim strEVersion As String 'Identify Version

            objEApp = DirectCast(CreateObject("Excel.Application"), Excel.Application) 'Cast To Excel App

            strEVersion = objEApp.Version
            Select Case objEApp.Version 'Determine Version
                Case "7.0"
                    strEVersion = "95"
                Case "8.0"
                    strEVersion = "97"
                Case "9.0"
                    strEVersion = "2000"
                Case "10.0"
                    strEVersion = "2002"
                Case "11.0"
                    strEVersion = "2003"
                Case "12.0"
                    strEVersion = "2007"
                Case "14.0"
                    strEVersion = "2010"
                Case "15.0"
                    strEVersion = "2013"
            End Select

            'MessageBox.Show("Excel Version: " & strEVersion) 'Display Result

            objEApp.Quit() 'Quit

            objEApp = Nothing 'Release Memory


        Catch ex As Exception

        End Try
        Return strEVersion
    End Function

    Private Sub Video()
        ' VIDEO
        Dim lsSql As String
        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DisplayConfiguration")

            'Dim _Node As New Infragistics.Win.UltraWinTree.UltraTreeNode

            For Each queryObj As ManagementObject In searcher.Get()

                lsSql = "1"
                ' "Modelo:" & queryObj("Caption").ToString & ControlChars.CrLf & _
                '               "Frecuencia:" & queryObj("DisplayFrequency").ToString & ControlChars.CrLf

            Next

            'Me.UltraTree1.Nodes(2).Nodes.Add(_Node)

        Catch err As ManagementException
            MessageBox.Show("Error recuperando información WMI: " & err.Message)
        End Try
    End Sub


    Private Sub btn_passwordless_Click(sender As Object, e As EventArgs) Handles btn_passwordless.Click
        gs_usuario = Me.txt_usuario.Text.Trim
        gs_empresa = Me.cmb_empresa.Text.Trim

        If tokenValido_passwordless() Then

            'gs_usuario = Me.txt_usuario.Text.Trim
            pb_acceso = True
            Me.Close()
        Else
            MessageBox.Show("Información Ingresada Erronea", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txt_password.SelectAll()
            Me.txt_password.Focus()
        End If
    End Sub

    Private Function tokenValido_passwordless() As Boolean
        Dim liToken, liTokeRecibido As Integer
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lbTokenValido As Boolean
        Dim varMensajeAEnviar As String

        Try
            'pbPedirDobleFactor = True



            Dim lsabecedario As String = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,n,o,p,q,r,s,t,u,v,w,x,y,z"

            liToken = numAleatorioEntre(100000, 999999)
            dt = ClsGen.Fecha_Servidor("FlexLine")


            If gs_nivel_riesgo.ToString.ToLower.Equals("alto") Then

                varMensajeAEnviar = "Validacion desde equipo:" & gs_nombre_equipo & ", " &
                                        "Usuario:" & gs_usuario & "," &
                    "TOKEN : " & liToken & ", para UMBRIGHT, " & "Fecha:" & dt.Rows(0).Item("Fecha_Actual")

                '"A Empresa : " & gs_empresa & "|" &
                lsSQL = "pa_ins_um_pwa_enviar_sms_claro '" & gs_numero_telefonico & "','" & varMensajeAEnviar & "'"

                ClsGen.insertQuery("RegionalDBintOut", lsSQL)
                liTokeRecibido = InputBox("Ingrese el Token Enviado por SMS al Celular: ****-" + gs_numero_telefonico.ToString.Substring(gs_numero_telefonico.Length - 4), "Validacion")

            ElseIf pbPedirDobleFactor Then




                Dim varMotivo As String = "Validacion de Acceso"
                varMensajeAEnviar = "Desde Equipo: " & gs_nombre_equipo & "|" &
                    "Sistema :  UMBRIGHT |" &
                    "Usuario : " & gs_usuario & "|" &
                    "TOKEN : " & liToken & "|" & "Fecha :" & dt.Rows(0).Item("Fecha_Actual")

                System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
                Dim request As WebRequest
                'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

                request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
                Dim response As WebResponse
                Dim postData As String = "
            {
              ""Correo"": """ & gs_cuenta_usuario & """,
              ""Motivo"": """ & varMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
            }"
                Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
                request.Method = "POST"
                request.ContentType = "application/json"
                request.ContentLength = data.Length
                Dim stream As Stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
                stream.Close()
                response = request.GetResponse()
                Dim sr As New StreamReader(response.GetResponseStream())

                Dim lscorreoOculto As String

                'lscorreoOculto = gs_cuenta_usuario.Substring(0, gs_cuenta_usuario.ToString.IndexOf("@") - 3).Replace(lsabecedario, "*") + gs_cuenta_usuario.Substring(gs_cuenta_usuario.IndexOf("@") - 3, gs_cuenta_usuario.Length())
                lscorreoOculto = gs_cuenta_usuario.Substring(2, gs_cuenta_usuario.ToString.IndexOf("@") - 2)
                For Each lscaracter As String In lsabecedario.Split(",")
                    lscorreoOculto = lscorreoOculto.Replace(lscaracter, "*")
                Next


                lscorreoOculto = gs_cuenta_usuario.Substring(0, 2) + lscorreoOculto + gs_cuenta_usuario.Substring(gs_cuenta_usuario.IndexOf("@") - 2)


                liTokeRecibido = InputBox("Ingrese el Token Enviado a TEAMS!!! a la cuenta " + lscorreoOculto, "Validacion")
            End If

            If liToken <> liTokeRecibido Then

                lbTokenValido = False
            Else
                lbTokenValido = True
                enviarAviso_ingresoToken()
            End If



        Catch ex As Exception
        End Try

        Return lbTokenValido

    End Function

    Private Sub enviarAviso_ingresoToken()
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            dt = clsGen.Fecha_Servidor("FlexLine")

            Dim varMotivo As String = "Passwordless Authentication"
            Dim varMensajeAEnviar As String = "Desde Equipo: " & gs_nombre_equipo & "|" &
                        "Usuario : " & gs_usuario & "|" &
                        "Sistema : UMBRIGHT |" &
                        "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "|Se Informa de un Acceso con Token" &
             "| **** IMPORTANTE *** |Si usted no realizó esta acción, comuniquese con Informatica y Tecnologia"

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & gs_cuenta_usuario & """,
              ""Motivo"": """ & varMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
            }"
            Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            response = request.GetResponse()
            Dim sr As New StreamReader(response.GetResponseStream())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub WrapRounded(tb As TextBox)
        tb.BorderStyle = BorderStyle.None
        Dim wrapper As New Panel()
        wrapper.Size = New Size(tb.Width + 8, tb.Height + 10)
        wrapper.Location = New Point(tb.Left - 4, tb.Top - 5)
        wrapper.BackColor = Color.White
        wrapper.Cursor = Cursors.IBeam
        Dim capturedTb As TextBox = tb
        AddHandler wrapper.Paint, Sub(s, e)
            Dim g = e.Graphics
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim path As New Drawing2D.GraphicsPath()
            Dim r = New Rectangle(1, 1, wrapper.Width - 3, wrapper.Height - 3)
            Dim rad = 10
            path.AddArc(r.X, r.Y, rad, rad, 180, 90)
            path.AddArc(r.Right - rad, r.Y, rad, rad, 270, 90)
            path.AddArc(r.Right - rad, r.Bottom - rad, rad, rad, 0, 90)
            path.AddArc(r.X, r.Bottom - rad, rad, rad, 90, 90)
            path.CloseFigure()
            g.FillPath(New SolidBrush(Color.White), path)
            g.DrawPath(New Pen(Color.FromArgb(106, 116, 56), 1.5!), path)
        End Sub
        AddHandler wrapper.Click, Sub(s, e) capturedTb.Focus()
        Me.Controls.Remove(tb)
        wrapper.Controls.Add(tb)
        tb.Location = New Point(4, 5)
        tb.Width = wrapper.Width - 8
        Me.Controls.Add(wrapper)
        wrapper.BringToFront()
    End Sub

    Private Sub RoundBtn(btn As Control, radius As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        Dim r = New Rectangle(0, 0, btn.Width, btn.Height)
        Dim rad = radius * 2
        path.AddArc(r.X, r.Y, rad, rad, 180, 90)
        path.AddArc(r.Right - rad, r.Y, rad, rad, 270, 90)
        path.AddArc(r.Right - rad, r.Bottom - rad, rad, rad, 0, 90)
        path.AddArc(r.X, r.Bottom - rad, rad, rad, 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub

End Class
