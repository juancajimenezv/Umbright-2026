Imports System.Security.Cryptography

Public Class frm_conversion
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_parametros As System.Windows.Forms.TabPage
    Friend WithEvents tb_conversiones As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txt_erp As System.Windows.Forms.TextBox
    Friend WithEvents txt_crm As System.Windows.Forms.TextBox
    Friend WithEvents txt_reportes As System.Windows.Forms.TextBox
    Friend WithEvents txt_olap As System.Windows.Forms.TextBox
    Friend WithEvents txt_logos As System.Windows.Forms.TextBox
    Friend WithEvents txt_vnet As System.Windows.Forms.TextBox
    Friend WithEvents txt_reverse As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_conversion))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_parametros = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_reverse = New System.Windows.Forms.TextBox()
        Me.txt_vnet = New System.Windows.Forms.TextBox()
        Me.txt_logos = New System.Windows.Forms.TextBox()
        Me.txt_olap = New System.Windows.Forms.TextBox()
        Me.txt_reportes = New System.Windows.Forms.TextBox()
        Me.txt_crm = New System.Windows.Forms.TextBox()
        Me.txt_erp = New System.Windows.Forms.TextBox()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tb_conversiones = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.tb_parametros.SuspendLayout()
        Me.tb_conversiones.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tb_parametros)
        Me.TabControl1.Controls.Add(Me.tb_conversiones)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(396, 284)
        Me.TabControl1.TabIndex = 6
        '
        'tb_parametros
        '
        Me.tb_parametros.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_parametros.Controls.Add(Me.Label9)
        Me.tb_parametros.Controls.Add(Me.Label8)
        Me.tb_parametros.Controls.Add(Me.Label7)
        Me.tb_parametros.Controls.Add(Me.Label6)
        Me.tb_parametros.Controls.Add(Me.Label5)
        Me.tb_parametros.Controls.Add(Me.Label4)
        Me.tb_parametros.Controls.Add(Me.Label3)
        Me.tb_parametros.Controls.Add(Me.txt_reverse)
        Me.tb_parametros.Controls.Add(Me.txt_vnet)
        Me.tb_parametros.Controls.Add(Me.txt_logos)
        Me.tb_parametros.Controls.Add(Me.txt_olap)
        Me.tb_parametros.Controls.Add(Me.txt_reportes)
        Me.tb_parametros.Controls.Add(Me.txt_crm)
        Me.tb_parametros.Controls.Add(Me.txt_erp)
        Me.tb_parametros.Controls.Add(Me.Btn_Guardar)
        Me.tb_parametros.Location = New System.Drawing.Point(4, 25)
        Me.tb_parametros.Name = "tb_parametros"
        Me.tb_parametros.Size = New System.Drawing.Size(388, 255)
        Me.tb_parametros.TabIndex = 0
        Me.tb_parametros.Text = "Parametros Sistema"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Path Reverse"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Path ViNet"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Path Logos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Path OLAP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Path Reportes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Path CRM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Path ERP"
        '
        'txt_reverse
        '
        Me.txt_reverse.Location = New System.Drawing.Point(110, 199)
        Me.txt_reverse.Name = "txt_reverse"
        Me.txt_reverse.Size = New System.Drawing.Size(264, 22)
        Me.txt_reverse.TabIndex = 7
        '
        'txt_vnet
        '
        Me.txt_vnet.Location = New System.Drawing.Point(110, 175)
        Me.txt_vnet.Name = "txt_vnet"
        Me.txt_vnet.Size = New System.Drawing.Size(264, 22)
        Me.txt_vnet.TabIndex = 6
        '
        'txt_logos
        '
        Me.txt_logos.Location = New System.Drawing.Point(110, 151)
        Me.txt_logos.Name = "txt_logos"
        Me.txt_logos.Size = New System.Drawing.Size(264, 22)
        Me.txt_logos.TabIndex = 5
        '
        'txt_olap
        '
        Me.txt_olap.Location = New System.Drawing.Point(110, 127)
        Me.txt_olap.Name = "txt_olap"
        Me.txt_olap.Size = New System.Drawing.Size(264, 22)
        Me.txt_olap.TabIndex = 4
        '
        'txt_reportes
        '
        Me.txt_reportes.Location = New System.Drawing.Point(110, 222)
        Me.txt_reportes.Name = "txt_reportes"
        Me.txt_reportes.Size = New System.Drawing.Size(264, 22)
        Me.txt_reportes.TabIndex = 3
        '
        'txt_crm
        '
        Me.txt_crm.Location = New System.Drawing.Point(110, 102)
        Me.txt_crm.Name = "txt_crm"
        Me.txt_crm.Size = New System.Drawing.Size(264, 22)
        Me.txt_crm.TabIndex = 2
        '
        'txt_erp
        '
        Me.txt_erp.Location = New System.Drawing.Point(110, 79)
        Me.txt_erp.Name = "txt_erp"
        Me.txt_erp.Size = New System.Drawing.Size(264, 22)
        Me.txt_erp.TabIndex = 1
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Guardar.ImageIndex = 0
        Me.Btn_Guardar.ImageList = Me.ImageList1
        Me.Btn_Guardar.Location = New System.Drawing.Point(306, 11)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(68, 60)
        Me.Btn_Guardar.TabIndex = 0
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        '
        'tb_conversiones
        '
        Me.tb_conversiones.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_conversiones.Controls.Add(Me.TextBox3)
        Me.tb_conversiones.Controls.Add(Me.Button2)
        Me.tb_conversiones.Controls.Add(Me.Label2)
        Me.tb_conversiones.Controls.Add(Me.Label1)
        Me.tb_conversiones.Controls.Add(Me.Button1)
        Me.tb_conversiones.Controls.Add(Me.TextBox2)
        Me.tb_conversiones.Controls.Add(Me.TextBox1)
        Me.tb_conversiones.Location = New System.Drawing.Point(4, 25)
        Me.tb_conversiones.Name = "tb_conversiones"
        Me.tb_conversiones.Size = New System.Drawing.Size(388, 255)
        Me.tb_conversiones.TabIndex = 1
        Me.tb_conversiones.Text = "Conversion Hexadecimal"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(246, 99)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Hex  a Txt"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(26, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Hexadecimal"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "texto"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(114, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Txt a  Hex"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(114, 131)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(248, 59)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(114, 35)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(248, 56)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(114, 193)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(248, 59)
        Me.TextBox3.TabIndex = 12
        '
        'frm_conversion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(396, 284)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_conversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametros Generales"
        Me.TabControl1.ResumeLayout(False)
        Me.tb_parametros.ResumeLayout(False)
        Me.tb_parametros.PerformLayout()
        Me.tb_conversiones.ResumeLayout(False)
        Me.tb_conversiones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Generar_Controles()

        Dim ls_sql As String
        Dim dt As DataTable

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()


        Try
            ls_sql = "pa_sel_um_gen_parametros_sistema"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Me.txt_crm.Text = dt.Rows(0)("path_crm").ToString
                Me.txt_erp.Text = dt.Rows(0)("path_erp").ToString
                Me.txt_logos.Text = dt.Rows(0)("path_logos").ToString
                Me.txt_olap.Text = dt.Rows(0)("path_olap").ToString
                Me.txt_reportes.Text = dt.Rows(0)("path_reportes").ToString
                Me.txt_reverse.Text = dt.Rows(0)("path_reverse").ToString
                Me.txt_vnet.Text = dt.Rows(0)("path_vnet").ToString

                Me.Btn_Guardar.Text = "Actualizar"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Informacion()
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")

        otrans.open()
        Try
            ls_sql = "pa_ins_um_gen_parametros_sistema '" &
                       Me.txt_erp.Text & "','" &
                       Me.txt_crm.Text & "','" &
                       Me.txt_logos.Text & "','" &
                       Me.txt_olap.Text & "','" &
                       Me.txt_reportes.Text & "','" &
                       Me.txt_reverse.Text & "','" &
                       Me.txt_vnet.Text & "'"

            otrans.Ingresa(ls_sql)
            If otrans.Codigo_error > 0 Then
                MsgBox(otrans.descripcion_error)
            Else
                MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim Data As String = Me.TextBox1.Text
        Dim Data1 As String = ""
        Dim sData As String = ""
        Dim svalue As String
        Dim shex As String = ""

        Do While (Data.Length > 0)
            svalue = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()))
            Data = Data.Substring(1, Data.Length - 1)
            shex = shex + svalue
        Loop

        Me.TextBox2.Text = shex





        Dim encriptar As clEmpaquetar
        encriptar = New clEmpaquetar("EtiquetaBlue")

        'MessageBox.Show(lsString, encriptar.Encrypt(lsString) & " --- " & encriptar.Decrypt(encriptar.Encrypt("73612C7361")))

        Me.TextBox3.Text = encriptar.Encrypt(Data)

        encriptar = Nothing



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Data As String = Me.TextBox2.Text
        Dim Data1 As String = ""
        Dim sData As String = ""
        Dim shex As String = ""

        Try
            Do While (Data.Length > 0)
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString()
                sData = sData + Data1
                Data = Data.Substring(2, Data.Length - 2)
            Loop

        Catch ex As Exception
        Finally
            Me.TextBox1.Text = ""
            Me.TextBox1.Text = sData
        End Try


    End Sub

    Private Sub frm_conversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Generar_Controles()
    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        Guardar_Informacion()
    End Sub

End Class
