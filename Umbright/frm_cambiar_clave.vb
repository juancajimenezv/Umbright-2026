Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class frm_cambiar_clave
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_clave As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_cambiar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cambiar_clave))
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_clave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_cambiar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txt_usuario
        '
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario.Location = New System.Drawing.Point(15, 32)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.ReadOnly = True
        Me.txt_usuario.Size = New System.Drawing.Size(151, 22)
        Me.txt_usuario.TabIndex = 0
        Me.txt_usuario.TabStop = False
        '
        'txt_clave
        '
        Me.txt_clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_clave.Location = New System.Drawing.Point(15, 96)
        Me.txt_clave.Name = "txt_clave"
        Me.txt_clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_clave.Size = New System.Drawing.Size(151, 22)
        Me.txt_clave.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(15, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nueva Contraseña"
        '
        'btn_cambiar
        '
        Me.btn_cambiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_cambiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cambiar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cambiar.ForeColor = System.Drawing.Color.White
        Me.btn_cambiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cambiar.ImageIndex = 1
        Me.btn_cambiar.ImageList = Me.ImageList1
        Me.btn_cambiar.Location = New System.Drawing.Point(181, 12)
        Me.btn_cambiar.Name = "btn_cambiar"
        Me.btn_cambiar.Size = New System.Drawing.Size(74, 58)
        Me.btn_cambiar.TabIndex = 4
        Me.btn_cambiar.Text = "&Aceptar"
        Me.btn_cambiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cambiar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "129.png")
        Me.ImageList1.Images.SetKeyName(1, "121.png")
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.ImageIndex = 0
        Me.btn_cancelar.ImageList = Me.ImageList1
        Me.btn_cancelar.Location = New System.Drawing.Point(181, 77)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(74, 59)
        Me.btn_cancelar.TabIndex = 5
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(18, 124)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(77, 20)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "VerClave"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'frm_cambiar_clave
        '
        Me.AcceptButton = Me.btn_cambiar
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CancelButton = Me.btn_cancelar
        Me.ClientSize = New System.Drawing.Size(275, 164)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_cambiar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_clave)
        Me.Controls.Add(Me.txt_usuario)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cambiar_clave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub enviarAviso_CambioClave()
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            dt = clsGen.Fecha_Servidor("FlexLine")

            Dim varMotivo As String = "Cambio de Contraseña Umbright"
            Dim varMensajeAEnviar As String = "Desde Equipo: " & gs_nombre_equipo & "|" &
                        "Usuario : " & gs_usuario & "|" &
                        "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "| **** IMPORTANTE *** Si usted no realizó esta acción, comuniquese con Informatica y Tecnologia"

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

    Private Sub btn_cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click

        Dim oSeguridad As New Seguridad.Usuario("sql", "flexline")

        Try
            pb_acceso = oSeguridad.Tiene_Acceso(Me.txt_usuario.Text, Me.txt_clave.Text, gs_empresa)
            If pb_acceso Then

                MessageBox.Show("Debe Ingresar una Clave Distinta a la Actual", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If claveDebil(Me.txt_clave.Text) Then
                    MessageBox.Show("Su Clave Es Demasiado Debil o Se Repite,  Intente con Otra", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                Else

                    Dim oSeg As New Seguridad.Usuario("sql", "FlexLine")
                    If MessageBox.Show("Esta Seguro de Cambiar su Clave", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        If oSeg.actualiza_usuario(gs_usuario, Me.txt_clave.Text, "NULL", True, gs_usuario, "") Then
                            MessageBox.Show("Cambio Realizado con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            oSeg = Nothing
                            enviarAviso_CambioClave()
                            Me.Close()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            oSeguridad = Nothing
        End Try

    End Sub

    Private Sub frm_cambiar_clave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_usuario.Text = gs_usuario
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Me.txt_clave.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub
End Class
