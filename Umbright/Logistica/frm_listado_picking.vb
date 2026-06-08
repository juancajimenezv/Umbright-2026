'Imports System.IO

Public Class frm_listado_picking
    Inherits System.Windows.Forms.Form
    Dim ds_picking As New DataSet
    Public pb_manual As Boolean
    Dim ppath_reporte As String
    Friend WithEvents dgv_reimpresion As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimirTMU As System.Windows.Forms.Button
    Friend WithEvents BtnReimpresionPickign As System.Windows.Forms.Button
    Friend WithEvents dg_picking_sin_guia As System.Windows.Forms.DataGridView
    Dim prt As prtcom.Imprimir_Puerto
    'Dim prt As Object

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
    'Friend WithEvents OrdersDataset1 As Prueba.OrdersDataset1
    Friend WithEvents dg_listado_pendientes As System.Windows.Forms.DataGrid
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar_reimpresion As System.Windows.Forms.Button
    Friend WithEvents btn_reimprimir As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_final_reimpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio_reimpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_tipo_impresion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_refrescar As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_reporte As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_picking))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dg_listado_pendientes = New System.Windows.Forms.DataGrid()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_refrescar = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_tipo_impresion = New System.Windows.Forms.Label()
        Me.btnImprimirTMU = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnReimpresionPickign = New System.Windows.Forms.Button()
        Me.dgv_reimpresion = New System.Windows.Forms.DataGridView()
        Me.btn_reporte = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_buscar_reimpresion = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_fecha_final_reimpresion = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio_reimpresion = New System.Windows.Forms.DateTimePicker()
        Me.btn_reimprimir = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dg_picking_sin_guia = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dg_listado_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_reimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dg_picking_sin_guia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_listado_pendientes
        '
        Me.dg_listado_pendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado_pendientes.CaptionVisible = False
        Me.dg_listado_pendientes.DataMember = ""
        Me.dg_listado_pendientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_listado_pendientes.Location = New System.Drawing.Point(0, 72)
        Me.dg_listado_pendientes.Name = "dg_listado_pendientes"
        Me.dg_listado_pendientes.Size = New System.Drawing.Size(1243, 400)
        Me.dg_listado_pendientes.TabIndex = 0
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Buscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.White
        Me.Btn_Buscar.Image = CType(resources.GetObject("Btn_Buscar.Image"), System.Drawing.Image)
        Me.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Buscar.Location = New System.Drawing.Point(176, 3)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(80, 64)
        Me.Btn_Buscar.TabIndex = 11
        Me.Btn_Buscar.Text = "Actualizar"
        Me.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Del"
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(72, 26)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final.TabIndex = 8
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(72, 3)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio.TabIndex = 7
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(1156, 3)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(87, 64)
        Me.btn_imprimir.TabIndex = 12
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        Me.btn_imprimir.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1258, 506)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txt_refrescar)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lbl_tipo_impresion)
        Me.TabPage1.Controls.Add(Me.Btn_Buscar)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_final)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_inicio)
        Me.TabPage1.Controls.Add(Me.btnImprimirTMU)
        Me.TabPage1.Controls.Add(Me.btn_imprimir)
        Me.TabPage1.Controls.Add(Me.dg_listado_pendientes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1250, 480)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Picking Pendiente de Imprimir"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(120, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 16)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Minutos"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Verif Cada"
        '
        'txt_refrescar
        '
        Me.txt_refrescar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_refrescar.Location = New System.Drawing.Point(72, 48)
        Me.txt_refrescar.Name = "txt_refrescar"
        Me.txt_refrescar.Size = New System.Drawing.Size(40, 20)
        Me.txt_refrescar.TabIndex = 24
        Me.txt_refrescar.Text = "3"
        Me.txt_refrescar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label14.Location = New System.Drawing.Point(841, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 16)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "TMK"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Chocolate
        Me.Label15.Location = New System.Drawing.Point(841, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 16)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "ON"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkMagenta
        Me.Label13.Location = New System.Drawing.Point(809, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 16)
        Me.Label13.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Chocolate
        Me.Label3.Location = New System.Drawing.Point(809, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(713, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 16)
        Me.Label12.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(713, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 16)
        Me.Label11.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Orange
        Me.Label10.Location = New System.Drawing.Point(713, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(746, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Urgentes"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(745, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = ">  60 M"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(745, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "> 30 M"
        '
        'lbl_tipo_impresion
        '
        Me.lbl_tipo_impresion.AutoSize = True
        Me.lbl_tipo_impresion.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_impresion.Location = New System.Drawing.Point(272, 10)
        Me.lbl_tipo_impresion.Name = "lbl_tipo_impresion"
        Me.lbl_tipo_impresion.Size = New System.Drawing.Size(284, 32)
        Me.lbl_tipo_impresion.TabIndex = 13
        Me.lbl_tipo_impresion.Text = "Impresion de Picking"
        '
        'btnImprimirTMU
        '
        Me.btnImprimirTMU.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirTMU.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirTMU.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimirTMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirTMU.ForeColor = System.Drawing.Color.White
        Me.btnImprimirTMU.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirTMU.ImageIndex = 3
        Me.btnImprimirTMU.ImageList = Me.ImageList1
        Me.btnImprimirTMU.Location = New System.Drawing.Point(883, 3)
        Me.btnImprimirTMU.Name = "btnImprimirTMU"
        Me.btnImprimirTMU.Size = New System.Drawing.Size(88, 64)
        Me.btnImprimirTMU.TabIndex = 12
        Me.btnImprimirTMU.Text = "Imprimir"
        Me.btnImprimirTMU.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirTMU.UseVisualStyleBackColor = False
        Me.btnImprimirTMU.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "images.jpg")
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.BtnReimpresionPickign)
        Me.TabPage2.Controls.Add(Me.dgv_reimpresion)
        Me.TabPage2.Controls.Add(Me.btn_reporte)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.btn_buscar_reimpresion)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.dtp_fecha_final_reimpresion)
        Me.TabPage2.Controls.Add(Me.dtp_fecha_inicio_reimpresion)
        Me.TabPage2.Controls.Add(Me.btn_reimprimir)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1265, 552)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Picking Impreso"
        '
        'BtnReimpresionPickign
        '
        Me.BtnReimpresionPickign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresionPickign.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.BtnReimpresionPickign.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnReimpresionPickign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresionPickign.ForeColor = System.Drawing.Color.White
        Me.BtnReimpresionPickign.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnReimpresionPickign.ImageIndex = 3
        Me.BtnReimpresionPickign.ImageList = Me.ImageList1
        Me.BtnReimpresionPickign.Location = New System.Drawing.Point(974, -1)
        Me.BtnReimpresionPickign.Name = "BtnReimpresionPickign"
        Me.BtnReimpresionPickign.Size = New System.Drawing.Size(88, 64)
        Me.BtnReimpresionPickign.TabIndex = 14
        Me.BtnReimpresionPickign.Text = "Imprimir"
        Me.BtnReimpresionPickign.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnReimpresionPickign.UseVisualStyleBackColor = False
        Me.BtnReimpresionPickign.Visible = False
        '
        'dgv_reimpresion
        '
        Me.dgv_reimpresion.AllowUserToAddRows = False
        Me.dgv_reimpresion.AllowUserToDeleteRows = False
        Me.dgv_reimpresion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_reimpresion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_reimpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_reimpresion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_reimpresion.Location = New System.Drawing.Point(3, 71)
        Me.dgv_reimpresion.Name = "dgv_reimpresion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_reimpresion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_reimpresion.RowHeadersWidth = 25
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_reimpresion.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_reimpresion.Size = New System.Drawing.Size(1259, 476)
        Me.dgv_reimpresion.TabIndex = 23
        '
        'btn_reporte
        '
        Me.btn_reporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_reporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reporte.ForeColor = System.Drawing.Color.White
        Me.btn_reporte.Image = CType(resources.GetObject("btn_reporte.Image"), System.Drawing.Image)
        Me.btn_reporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reporte.Location = New System.Drawing.Point(1169, -1)
        Me.btn_reporte.Name = "btn_reporte"
        Me.btn_reporte.Size = New System.Drawing.Size(89, 64)
        Me.btn_reporte.TabIndex = 22
        Me.btn_reporte.Text = "Reporte"
        Me.btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_reporte.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Tomato
        Me.Label4.Location = New System.Drawing.Point(304, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(326, 32)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Re Impresion de Picking"
        '
        'btn_buscar_reimpresion
        '
        Me.btn_buscar_reimpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar_reimpresion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar_reimpresion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_reimpresion.ForeColor = System.Drawing.Color.White
        Me.btn_buscar_reimpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar_reimpresion.ImageIndex = 0
        Me.btn_buscar_reimpresion.ImageList = Me.ImageList1
        Me.btn_buscar_reimpresion.Location = New System.Drawing.Point(160, 1)
        Me.btn_buscar_reimpresion.Name = "btn_buscar_reimpresion"
        Me.btn_buscar_reimpresion.Size = New System.Drawing.Size(80, 64)
        Me.btn_buscar_reimpresion.TabIndex = 19
        Me.btn_buscar_reimpresion.Text = "Buscar"
        Me.btn_buscar_reimpresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar_reimpresion.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Al"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Del"
        '
        'dtp_fecha_final_reimpresion
        '
        Me.dtp_fecha_final_reimpresion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final_reimpresion.Location = New System.Drawing.Point(48, 36)
        Me.dtp_fecha_final_reimpresion.Name = "dtp_fecha_final_reimpresion"
        Me.dtp_fecha_final_reimpresion.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final_reimpresion.TabIndex = 16
        '
        'dtp_fecha_inicio_reimpresion
        '
        Me.dtp_fecha_inicio_reimpresion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_reimpresion.Location = New System.Drawing.Point(48, 11)
        Me.dtp_fecha_inicio_reimpresion.Name = "dtp_fecha_inicio_reimpresion"
        Me.dtp_fecha_inicio_reimpresion.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio_reimpresion.TabIndex = 15
        '
        'btn_reimprimir
        '
        Me.btn_reimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reimprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_reimprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir.ForeColor = System.Drawing.Color.White
        Me.btn_reimprimir.Image = CType(resources.GetObject("btn_reimprimir.Image"), System.Drawing.Image)
        Me.btn_reimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reimprimir.Location = New System.Drawing.Point(1081, -1)
        Me.btn_reimprimir.Name = "btn_reimprimir"
        Me.btn_reimprimir.Size = New System.Drawing.Size(88, 64)
        Me.btn_reimprimir.TabIndex = 20
        Me.btn_reimprimir.Text = "Imprimir"
        Me.btn_reimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_reimprimir.UseVisualStyleBackColor = False
        Me.btn_reimprimir.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dg_picking_sin_guia)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.DateTimePicker1)
        Me.TabPage3.Controls.Add(Me.DateTimePicker2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1265, 552)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Picking Asignado"
        '
        'dg_picking_sin_guia
        '
        Me.dg_picking_sin_guia.AllowUserToAddRows = False
        Me.dg_picking_sin_guia.AllowUserToDeleteRows = False
        Me.dg_picking_sin_guia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_picking_sin_guia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_picking_sin_guia.Location = New System.Drawing.Point(3, 71)
        Me.dg_picking_sin_guia.Name = "dg_picking_sin_guia"
        Me.dg_picking_sin_guia.RowHeadersWidth = 25
        Me.dg_picking_sin_guia.Size = New System.Drawing.Size(1259, 476)
        Me.dg_picking_sin_guia.TabIndex = 25
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(160, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 64)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 16)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Al"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 15)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Del"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(48, 36)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 21
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(48, 11)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 20
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 180000
        '
        'frm_listado_picking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1266, 515)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_listado_picking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado Picking"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg_listado_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_reimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dg_picking_sin_guia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    '    Public Declare Auto Function CreateFile Lib "kernel32.dll" (ByVal lpFileName _
    'As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, _
    'ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As _
    'Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As _
    'IntPtr) As IntPtr

    'Const GENERIC_WRITE As Int32 = &H40000000
    'Const OPEN_EXISTING As Int32 = 3
    'Public Const escBoldOn As String = "Chr(27) & Chr(69) & Chr(1)" '/ Bold On 
    'Public Const escBoldOff As String = "Chr(27) & Chr(69) & Chr(0)" '/ Bold Off 

    'Private Function GetStreamWriter(ByVal port As String) As StreamWriter

    '    'Dim hFich As IntPtr = CreateFile(port, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    '    'Dim stream As New FileStream(hFich, FileAccess.Write)
    '    'Dim writer As New StreamWriter(stream)
    '    'Return writer

    'End Function

    'Private Sub imprimeLineaNegra(ByVal linea As String, ByVal color As String, ByVal lpt1 As StreamWriter)



    '    Try
    '        'lpt1.Write(Chr(27) & Chr(69) & Chr(0))
    '        'lpt1.Write(Chr(27) & "F")
    '        'lpt1.Write(Chr(27) & "M")
    '        'lpt1.Write(Chr(27) & "H")
    '        If color.ToLower.Equals("rojo") Then
    '            lpt1.Write(Chr(27) & "r" & Chr(1)) 'Para usar el rojo 
    '        End If

    '        lpt1.WriteLine(linea)

    '        If color.ToLower.Equals("rojo") Then
    '            lpt1.Write(Chr(27) & "r" & Chr(0)) 'Para usar el rojo 
    '        End If


    '    Catch ex As Exception
    '    Finally
    '    End Try

    'End Sub

    'Private Sub imprimeLineaNegraRoja(ByVal linea As String, ByVal linea2 As String, ByVal color As String, ByVal lpt1 As StreamWriter)



    '    Try
    '        'lpt1.Write(Chr(27) & Chr(69) & Chr(0))
    '        'lpt1.Write(Chr(27) & "F")
    '        'lpt1.Write(Chr(27) & "M")
    '        'lpt1.Write(Chr(27) & "H")
    '        lpt1.Write(linea)
    '        '            If Color.ToLower.Equals("rojo") Then
    '        lpt1.Write(Chr(27) & "r" & Chr(1)) 'Para usar el rojo 
    '        '            End If

    '        lpt1.Write(linea2)

    '        '           If color.ToLower.Equals("rojo") Then
    '        lpt1.Write(Chr(27) & "r" & Chr(0)) 'Para usar el rojo 
    '        '            End If
    '        lpt1.Write(vbCrLf)

    '    Catch ex As Exception
    '    Finally
    '    End Try

    'End Sub

    'Private Sub imprimeLineaRoja(ByVal linea As String)
    '    Dim lpt1 As StreamWriter = GetStreamWriter("COM1")

    '    Try

    '        lpt1.Write(Chr(27) & "r" & Chr(1)) 'Para usar el rojo 
    '    Catch ex As Exception
    '    Finally
    '        lpt1.Close()

    '    End Try

    'End Sub


    'Private Sub ImprimeFact()

    '    Dim lpt1 As StreamWriter = GetStreamWriter("COM1")


    '    'lpt1.Write(Chr(27) & Chr(64))
    '    'lpt1.Write(Chr(27) + Chr(67) + Chr(44))

    '    lpt1.Write(Chr(27) & "r" & Chr(1)) 'Para usar el rojo 
    '    lpt1.Write(Chr(27) & "!" & Chr(16)) 'Para hacer letras grandes 
    '    lpt1.WriteLine(" COMERCIAL SAN FRANCISCO ")
    '    lpt1.Write(Chr(27) & "!" & Chr(1)) 'Para usar letra peque¸as         otravez()
    '    lpt1.Write(Chr(27) & "r" & Chr(0)) 'Para usar negro 
    '    lpt1.WriteLine(" Rodrigo Lobo Alvarado ")
    '    lpt1.Write(Chr(27) & Chr(69) & Chr(1))
    '    'lpt1.Write(Chr(27) & "E" & Chr(27) & "W" & Chr(1)) 'Pongo negrita
    '    lpt1.WriteLine(" Telefonos: 734-0205 734-0735 ")
    '    'lpt1.Write(Chr(27) & "E" & Chr(27) & "W" & Chr(1)) 'Quito Negrita
    '    lpt1.Write(Chr(27) & Chr(69) & Chr(0))

    '    '        Write(MyPrinter, CHR(27) + CHR(64)); // Inicializar Impresora
    '    'Write(MyPrinter, CHR(27)+CHR(67)+CHR(44)); // Fijar Tamaño en Lineas
    '    'Write(MyPrinter,CHR(27)+ CHR(103)); // Tipo de Letra Chicas
    '    'Write(MyPrinter,CHR(27)+CHR(197)); // Negrita
    '    'Write(MyPrinter,CHR(27)+CHR(179)+CHR(28)); // Espacio entre Lineas
    '    'Write(MyPrinter,' ESTA ES UNA PRUEBA ');
    '    'Write(MyPrinter,' DE IMPRESION! ');

    '    'Dairyn Pivaral
    '    '24360300



    '    lpt1.WriteLine("Ultima Linea")


    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(Chr(27) & "m") 'Para cortar el papel 





    '    lpt1.Close()

    'End Sub

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("pendientes_impresion")

        dt.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("lineas", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("area", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("factura", GetType(String)))
        dt.Columns.Add(New DataColumn("bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("minutos", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ruta_logistica", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_impresion", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("fecha_factura", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))

        ds_picking.Tables.Add(dt.Copy)

        dt.TableName = "re_impresion"
        ds_picking.Tables.Add(dt.Copy)

    End Sub

    Private Sub Agregar_Pendientes_Impresion(ByVal _pdt As DataTable)
        Dim dr_aux As DataRow
        Dim drv As DataRowView
        '_pdt.DefaultView.RowFilter = "numero_picking = '-1' and minutos > " & Me.txt_refrescar.Text
        _pdt.DefaultView.RowFilter = "numero_picking = '-1'"

        For Each drv In _pdt.DefaultView
            dr_aux = ds_picking.Tables("pendientes_impresion").NewRow

            dr_aux.Item("imprimir") = Not pb_manual
            dr_aux.Item("lineas") = drv.Item("lineas")
            dr_aux.Item("empresa") = drv.Item("empresa")
            dr_aux.Item("tipo_cliente") = drv.Item("tipo_cliente")
            dr_aux.Item("nombre") = drv.Item("nombre_cliente")
            dr_aux.Item("area") = drv.Item("area")
            dr_aux.Item("serie") = drv.Item("TipoDocto")
            dr_aux.Item("factura") = drv.Item("numero")
            dr_aux.Item("bodega") = drv.Item("bodega")
            dr_aux.Item("fecha") = drv.Item("fechaUModif")
            dr_aux.Item("minutos") = drv.Item("minutos")
            dr_aux.Item("ruta_logistica") = drv.Item("ruta_logistica")
            dr_aux.Item("tipodocto") = drv.Item("tipodocto")
            ds_picking.Tables("pendientes_impresion").Rows.Add(dr_aux)
        Next

    End Sub

    Private Sub Agregar_Re_Impresion(ByVal _pdt As DataTable)
        Dim dr, dr_aux As DataRow

        For Each dr In _pdt.Rows
            dr_aux = ds_picking.Tables("re_impresion").NewRow

            dr_aux.Item("imprimir") = False
            dr_aux.Item("lineas") = dr.Item("lineas")
            dr_aux.Item("empresa") = dr.Item("empresa")
            dr_aux.Item("tipo_cliente") = dr.Item("tipo_cliente")
            dr_aux.Item("nombre") = dr.Item("nombre_cliente")
            dr_aux.Item("area") = dr.Item("area")
            dr_aux.Item("serie") = dr.Item("TipoDocto")
            dr_aux.Item("factura") = dr.Item("numero")
            dr_aux.Item("bodega") = dr.Item("bodega")
            dr_aux.Item("fecha") = dr.Item("fechaUModif")
            dr_aux.Item("minutos") = dr.Item("minutos")
            dr_aux.Item("ruta_logistica") = dr.Item("ruta_logistica")
            dr_aux.Item("fecha_impresion") = dr.Item("fecha_impresion")
            dr_aux.Item("picker") = dr.Item("picker")
            dr_aux.Item("tipodocto") = dr.Item("tipodocto")
            ds_picking.Tables("re_impresion").Rows.Add(dr_aux)
        Next


    End Sub

    Private Sub Llenar_Pendientes()
        Dim ls_sql As String
        Dim dt, dt_aux As DataTable
        Dim dr As DataRow
        Dim lsProcedimiento As String
        Dim clsGen As New ClasesGenerales.General

        Dim lbImprimirAutomatico As Boolean = tiene_permisos("mlo_impresion_picking_automatico_tmk")


        Dim otrans_sql As New Transaccional.Conexion("flexline")
        lsProcedimiento = "pa_var_um_facturas_picking_completo"

        If tiene_permisos("mlo_Impresion_picking_tmk") Then lsProcedimiento = "pa_var_um_facturas_picking_completo_tmk"

        If otrans_sql.Codigo_error = 0 Then
            Try
                otrans_sql.open()
                Me.dg_listado_pendientes.DataSource = Nothing
                ds_picking.Tables("pendientes_impresion").Rows.Clear()



                If lsProcedimiento = "pa_var_um_facturas_picking_completo" Then

                    ls_sql = "pa_sel_um_gen_tabcod null,'GEN_DOCTO_PICKING',null"
                    dt_aux = otrans_sql.Obtiene(ls_sql)


                    For Each dr In dt_aux.Rows
                        If dr.Item("texto").ToString.ToLower = gs_usuario.ToLower Or
                        dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or
                        dr.Item("texto2").ToString.ToLower = gs_usuario.ToLower Or
                        gi_tipo_usuario = 1 Then


                            'Agregar la validación por bodega



                            ls_sql = lsProcedimiento & " '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "','" &
                                    dr.Item("CODIGO") & "','" & dr.Item("empresa") & "'," & Me.txt_refrescar.Text

                            dt = otrans_sql.Obtiene(ls_sql)
                            If dt.Rows.Count > 0 Then
                                Agregar_Pendientes_Impresion(dt)
                            End If
                        End If
                    Next
                Else
                    'tmk
                    ls_sql = "pa_sel_um_seg_usuario_picker_tipodocto '" & gs_usuario & "'"
                    dt_aux = clsGen.selectQuery("SCM", ls_sql)

                    Dim dtBodegas As DataTable
                    ls_sql = "pa_sel_um_seg_usuario_picker_bodega '" & gs_usuario & "'"
                    dtBodegas = clsGen.selectQuery("SCM", ls_sql)

                    For Each dr In dt_aux.Rows

                        For Each drBodega As DataRow In dtBodegas.Rows
                            ls_sql = lsProcedimiento & " '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "','" &
                                    dr.Item("tipodocto").ToString & "','" & dr.Item("empresa") & "'," & Me.txt_refrescar.Text & ",'" & drBodega.Item("Bodega").ToString & "'"

                            dt = otrans_sql.Obtiene(ls_sql)
                            If dt.Rows.Count > 0 Then
                                If lbImprimirAutomatico Then pb_manual = False
                                Agregar_Pendientes_Impresion(dt)
                                If lbImprimirAutomatico Then pb_manual = True
                            End If
                        Next


                    Next



                End If

                ds_picking.Tables("pendientes_impresion").DefaultView.Sort = "minutos DESC"

                'If tiene_permisos("mlo_Impresion_picking_tmk") Then
                If lbImprimirAutomatico And ds_picking.Tables("pendientes_impresion").Rows.Count > 0 Then
                    procesarImpresion("LASER", False)
                End If
            Catch ex As Exception
            Finally
                otrans_sql.close()
                otrans_sql = Nothing
            End Try
        Else
            MessageBox.Show("Se produjo el siguiente error: " & otrans_sql.descripcion_error, "Error transaccional")
        End If
    End Sub

    Private Sub Llenar_Pendientes_20221117()
        Dim ls_sql As String
        Dim dt, dt_aux As DataTable
        Dim dr As DataRow
        Dim lsProcedimiento As String


        Dim otrans_sql As New Transaccional.Conexion("flexline")
        lsProcedimiento = "pa_var_um_facturas_picking_completo"

        If tiene_permisos("mlo_Impresion_picking_tmk") Then lsProcedimiento = "pa_var_um_facturas_picking_completo_tmk"

        If otrans_sql.Codigo_error = 0 Then
            Try
                Me.dg_listado_pendientes.DataSource = Nothing
                ds_picking.Tables("pendientes_impresion").Rows.Clear()


                otrans_sql.open()
                ls_sql = "pa_sel_um_gen_tabcod null,'GEN_DOCTO_PICKING',null"
                dt_aux = otrans_sql.Obtiene(ls_sql)

                For Each dr In dt_aux.Rows
                    If dr.Item("texto").ToString.ToLower = gs_usuario.ToLower Or
                        dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or
                        dr.Item("texto2").ToString.ToLower = gs_usuario.ToLower Or
                        gi_tipo_usuario = 1 Then


                        'Agregar la validación por bodega



                        ls_sql = lsProcedimiento & " '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "','" &
                                    dr.Item("CODIGO") & "','" & dr.Item("empresa") & "'," & Me.txt_refrescar.Text

                        dt = otrans_sql.Obtiene(ls_sql)
                        If dt.Rows.Count > 0 Then
                            Agregar_Pendientes_Impresion(dt)
                        End If
                    End If
                Next
                ds_picking.Tables("pendientes_impresion").DefaultView.Sort = "minutos DESC"
            Catch ex As Exception
            Finally
                otrans_sql.close()
                otrans_sql = Nothing
            End Try
        Else
            MessageBox.Show("Seprodujo el siguiente error: " & otrans_sql.descripcion_error, "Error transaccional")
        End If
    End Sub

    Private Sub Llenar_Reimpresion()
        Dim ls_sql As String
        Dim dt, dt_aux As DataTable
        Dim dr As DataRow
        Dim clsgen As New ClasesGenerales.General
        Dim lsProcedimiento As String = "pa_var_um_facturas_picking_reimpresion"

        Dim otrans_sql As New Transaccional.Conexion("flexline")
        Try
            otrans_sql.open()
            Me.dgv_reimpresion.DataSource = Nothing
            ds_picking.Tables("re_impresion").Rows.Clear()


            If tiene_permisos("mlo_Impresion_picking_tmk") Then lsProcedimiento = "pa_var_um_facturas_picking_reimpresion_tmk"

            If otrans_sql.Codigo_error = 0 Then
                Try

                    If lsProcedimiento = "pa_var_um_facturas_picking_reimpresion" Then


                        ls_sql = "pa_sel_um_gen_tabcod null,'GEN_DOCTO_PICKING',null"
                        dt_aux = otrans_sql.Obtiene(ls_sql)
                        'otrans.close()

                        For Each dr In dt_aux.Rows
                            If dr.Item("texto").ToString.ToLower = gs_usuario.ToLower Or
                    dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or
                    gi_tipo_usuario = 1 Then

                                ls_sql = "pa_var_um_facturas_picking_reimpresion '" & Me.dtp_fecha_inicio_reimpresion.Text & "','" & Me.dtp_fecha_final_reimpresion.Text & "','" &
                                dr.Item("CODIGO") & "','" & dr.Item("empresa") & "'"

                                dt = otrans_sql.Obtiene(ls_sql)
                                Try
                                    Agregar_Re_Impresion(dt)
                                Catch ex As Exception
                                End Try

                            End If
                        Next
                    Else
                        ls_sql = "pa_sel_um_seg_usuario_picker_tipodocto '" & gs_usuario & "'"
                        dt_aux = clsgen.selectQuery("SCM", ls_sql)

                        Dim dtBodegas As DataTable
                        ls_sql = "pa_sel_um_seg_usuario_picker_bodega '" & gs_usuario & "'"
                        dtBodegas = clsgen.selectQuery("SCM", ls_sql)

                        For Each dr In dt_aux.Rows

                            For Each drBodega As DataRow In dtBodegas.Rows
                                ls_sql = lsProcedimiento & " '" & Me.dtp_fecha_inicio_reimpresion.Text & "','" & Me.dtp_fecha_final_reimpresion.Text & "','" &
                                        dr.Item("tipodocto").ToString & "','" & dr.Item("empresa") & "','" & drBodega.Item("Bodega").ToString & "'"

                                dt = otrans_sql.Obtiene(ls_sql)
                                If dt.Rows.Count > 0 Then
                                    Agregar_Re_Impresion(dt)
                                End If
                            Next


                        Next



                    End If


                Catch ex As Exception

                End Try
            End If


            ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
            ds_picking.Tables("re_impresion").DefaultView.Sort = "fecha_impresion desc"

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            '  otrans.close()
            ' otrans = Nothing
            otrans_sql.close()
            otrans_sql = Nothing

            clsgen = Nothing
            If ds_picking.Tables("re_impresion").Rows.Count > 0 Then
                Me.dgv_reimpresion.DataSource = ds_picking.Tables("re_impresion")
                Colorear_Grid_reimpresion()
            End If
        End Try
        Try
            Me.dgv_reimpresion.CurrentCell = Me.dgv_reimpresion.Rows(0).Cells(0)
        Catch ex As Exception

        End Try

    End Sub

    'Grid Impresion
    Private Sub Colorear_Grid()
        Dim clGenerales As New ClasesGenerales.General
        Me.dg_listado_pendientes.DataSource = ds_picking.Tables("pendientes_impresion")

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "pendientes_impresion"

        For Each col As DataColumn In ds_picking.Tables("pendientes_impresion").Columns
            If col.ColumnName.ToLower <> "imprimir" Then

                Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
                gridCol.MappingName = col.ColumnName

                Select Case col.ColumnName.ToLower
                    Case "cod_empresa", "serie", "fecha_impresion", "area", "picker"
                        gridCol.Width = 0
                    Case "fecha"
                        gridCol.Width = 95
                    Case "lineas"
                        gridCol.Width = 20
                    Case Else
                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_picking.Tables("pendientes_impresion"), " ", col.ColumnName, Me.dg_listado_pendientes, 200, 0)
                End Select
                gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
                gridCol.NullText = ""
                AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
                tableStyle.GridColumnStyles.Add(gridCol)
            Else
                Dim mydatacol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
                                        HorizontalAlignment.Center, _
                                        False, "Imprimir", _
                                        String.Empty, False, True, _
                                        False, String.Empty)
                tableStyle.GridColumnStyles.Add(mydatacol)
            End If
        Next
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray
        tableStyle.RowHeaderWidth = 5

        Me.dg_listado_pendientes.TableStyles.Clear()
        Me.dg_listado_pendientes.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Colorear_Grid_reimpresion()

        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(ds_picking.Tables("re_impresion"), Me.dgv_reimpresion, "", ",cod_empresa,serie,minutos,area,", ",,nombre,area,serie,factura,bodega,fecha,ruta_logistica,fecha_impresion,picker,tipodocto,", "", "", ",lineas=20,", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

        'Dim tableStyle As New DataGridTableStyle
        'tableStyle.MappingName = "re_impresion"

        'For Each col As DataColumn In ds_picking.Tables("re_impresion").Columns
        '    If col.ColumnName.ToLower <> "imprimir" Then
        '        Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
        '        gridCol.MappingName = col.ColumnName                    Case "lineas"
        '        Select Case col.ColumnName.ToLower
        '            Case "cod_empresa", "serie", "minutos", "area"
        '                gridCol.Width = 0
        '            Case "fecha", "fecha_impresion"
        '                gridCol.Width = 95
        '            Case Else
        '                gridCol.Width = clGenerales.tamaño_maximo_campo(ds_picking.Tables("re_impresion"), " ", col.ColumnName, Me.dg_listado_pendientes, 200, 0)
        '        End Select
        '        gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")

        '        gridCol.NullText = ""
        '        tableStyle.GridColumnStyles.Add(gridCol)
        '    Else
        '        Dim mydatacol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
        '                                HorizontalAlignment.Center, _
        '                                False, "Imprimir", _
        '                                String.Empty, False, True, _
        '                                False, String.Empty)
        '        tableStyle.GridColumnStyles.Add(mydatacol)
        '    End If
        'Next
        'tableStyle.HeaderForeColor = Color.Black
        'tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        'tableStyle.GridLineColor = Color.LightGray
        'tableStyle.RowHeaderWidth = 5

        'Me.dg_reimpresion.TableStyles.Clear()
        'Me.dg_reimpresion.TableStyles.Add(tableStyle)
    End Sub

    'Private Sub imprimir2()


    '    Dim drv As DataRowView
    '    Dim ls_sql As String
    '    Dim fechaarray(3) As String
    '    Dim path_reporte As String
    '    Dim pm_valores(2), pm_valores_consolidado(2) As String
    '    Dim pm_parametros(2) As String
    '    Dim nombre_picker As String
    '    Dim generar_consolidado As Boolean = False
    '    Dim picking_misma_empresa As Boolean = True
    '    Dim pm_conexion(3) As String
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim icount As Integer = 0

    '    'Obtengo Datos de Conexion
    '    pm_conexion = ClsGen.Parametros_Conexion("DataServer")
    '    ppath_reporte = ClsGen.Path_Reporte


    '    'Tomo el nombre del Picker
    '    Dim oform As New frm_pickeador
    '    oform.Llenar_Combo()
    '    oform.ShowDialog(Me)
    '    nombre_picker = oform.cmb_nombre_picker.Text
    '    oform.Dispose()




    '    Dim oTrans As New Transaccional.Conexion("flexline")
    '    Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)
    '    pm_valores_consolidado(0) = ""

    '    Try

    '        oTrans.open()
    '        ds_picking.Tables("pendientes_impresion").DefaultView.RowFilter = "imprimir = True"
    '        path_reporte = ppath_reporte & "Logistica\Picking\Picking por Documento.rpt"
    '        Oaut._reporte_generico_multipleCarga(path_reporte, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3))

    '        For Each drv In ds_picking.Tables("pendientes_impresion").DefaultView

    '            'Actualizo el documento

    '            If False Then
    '                Imprimir_TMU(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), False, False)
    '            Else

    '                pm_parametros(0) = "empresa"
    '                pm_parametros(1) = "numero documento"
    '                pm_valores(0) = drv.Item("empresa")
    '                pm_valores(1) = drv.Item("factura").ToString.PadLeft(10, "0") & "," & drv.Item("factura").ToString.PadLeft(10, "0")
    '                pm_parametros(2) = "tipodocto"
    '                pm_valores(2) = drv.Item("tipodocto").ToString

    '                '                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
    '                '                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
    '                '                                      False, True, "PDF", False)

    '                ls_sql = "pa_ins_um_gen_log_documento_tracking  '" & _
    '                                          drv.Item("empresa") & "','" & drv.Item("serie") & _
    '                                          "','" & drv.Item("factura") & "','" & gs_usuario & "','" & _
    '                                          nombre_picker & "', NULL"

    '                oTrans.Ingresa(ls_sql)

    '                Oaut._reporte_generico_multiple(pm_parametros, pm_valores, False, True, "", False)
    '                'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
    '                '                         False, True, "PDF", False)
    '                'If Oaut.Descripcion_Error.Length > 0 Then
    '                '    MessageBox.Show(Oaut.Descripcion_Error)
    '                'Else

    '                '    ls_sql = "pa_ins_um_gen_log_documento_tracking  '" & _
    '                '                          drv.Item("empresa") & "','" & drv.Item("serie") & _
    '                '                          "','" & drv.Item("factura") & "','" & gs_usuario & "','" & _
    '                '                          nombre_picker & "', NULL"

    '                '    oTrans.Ingresa(ls_sql)
    '                'End If

    '                'If _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
    '                '      pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
    '                '      False, True, "PDF", False, "", False) Then


    '                'drv.Item("imprimir") = False

    '                'End If
    '                'icount += 1
    '                'If icount = 5 Then
    '                '    icount = 0
    '                '    Threading.Thread.Sleep(15000)
    '                'End If
    '            End If



    '            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "DATASERVER", "BDflexline", "flexline", "flexline", False, True, "PDF", False)
    '            'pm_valores_consolidado(1) = pm_valores_consolidado(1) & drv.Item("factura").ToString.PadLeft(10, "0") & ","
    '            'If pm_valores_consolidado(0).Length = 0 Then
    '            '    pm_valores_consolidado(0) = drv.Item("empresa")
    '            'End If
    '            'If pm_valores_consolidado(0) <> drv.Item("empresa") Then
    '            '    picking_misma_empresa = False
    '            'End If
    '        Next
    '        'ds_picking.Tables("pendientes_impresion").DefaultView.RowFilter = "imprimir = True"
    '        'If ds_picking.Tables("pendientes_impresion").DefaultView.Count > 0 Then
    '        '    imprimir(nveces, nombre_picker)
    '        'End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        oTrans.close()
    '        oTrans = Nothing
    '        ClsGen = Nothing
    '        Oaut.finalizar()
    '        Oaut = Nothing
    '    End Try





    '    If generar_consolidado Then
    '        If picking_misma_empresa Then
    '            path_reporte = ppath_reporte & "Logistica\Picking\Impresion de Facturas por Rangos Consolidado.rpt"
    '            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores_consolidado, _
    '                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
    '                        True, False, "PDF", True, "", True)
    '        Else
    '            MessageBox.Show("No Se Puede Consolidar Picking de Diferentes Empresas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    End If


    '    ds_picking.Tables("pendientes_impresion").DefaultView.RowFilter = ""
    '    Llenar_Pendientes()
    '    Colorear_Grid()

    'End Sub

    'Private Sub Re_Imprimir2()
    '    Dim drv As DataRowView
    '    Dim path_reporte As String
    '    Dim pm_valores(2) As String
    '    Dim pm_parametros(2) As String
    '    Dim pm_conexion(3) As String
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim Oaut As New Automatizar.Reportes_CraxDrt("")

    '    Dim icount As Integer = 0


    '    Try

    '        'Dim icount As Integer = 0
    '        'Obtengo Datos de Conexion
    '        pm_conexion = ClsGen.Parametros_Conexion("DataServer")
    '        ppath_reporte = ClsGen.Path_Reporte
    '        path_reporte = ppath_reporte & "Logistica\Picking\Picking por Documento.rpt"
    '        Oaut._reporte_generico_multipleCarga(path_reporte, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3))

    '        ds_picking.Tables("re_impresion").DefaultView.RowFilter = "imprimir = True"

    '        For Each drv In ds_picking.Tables("re_impresion").DefaultView

    '            'If False Then
    '            '    Imprimir_TMU(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"))
    '            'Else

    '            pm_parametros(0) = "empresa"
    '            pm_parametros(1) = "numero documento"
    '            pm_valores(0) = drv.Item("empresa")
    '            pm_valores(1) = drv.Item("factura").ToString.PadLeft(10, "0") & "," & drv.Item("factura").ToString.PadLeft(10, "0")
    '            pm_parametros(2) = "tipodocto"
    '            pm_valores(2) = drv.Item("tipodocto").ToString
    '            Oaut._reporte_generico_multiple(pm_parametros, pm_valores, False, True, "", False)

    '            '                    _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
    '            '_
    '            '                                                  False, True, "PDF", False, "", False) Then drv.Item("imprimir") = False

    '            'drv.Item("imprimir") = False
    '            'End If


    '            'End If
    '            'ls_sql = "pa_ins_um_gen_log_impresion_picking  '" & _
    '            '               drv.Item("empresa") & "','" & drv.Item("serie") & _
    '            '              "','" & drv.Item("factura") & "','" & gs_usuario & "'"
    '        Next
    '        'ds_picking.Tables("re_impresion").DefaultView.RowFilter = "imprimir = True"
    '        'If ds_picking.Tables("re_impresion").DefaultView.Count > 0 Then
    '        '    Re_Imprimir(pveces)
    '        'End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        Oaut.finalizar()
    '        Oaut = Nothing
    '        ClsGen = Nothing
    '    End Try


    '    ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""

    'End Sub

    'Private Sub Asignar_path()   
    '    Dim otrans As New Transaccional.Conexion("flexline")
    '    Dim dt As DataTable

    '    Try
    '        otrans.open()
    '        dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
    '        ppath_reporte = dt.Rows(0).Item("path_reportes")
    '    Catch ex As Exception
    '    Finally
    '        otrans.close()
    '        otrans = Nothing

    '    End Try

    'End Sub
    Private Sub Imprimir_TMU_Encabezado(ByVal dt As DataTable)

        Dim dr As DataRow
        dr = dt.Rows(0)
        Dim linea As String = String.Empty
        If dr.Item("empresa").ToString.ToLower = "dmarte1" Then
            linea = "DISTRIBUIDORA MARTE, S.A."
        ElseIf dr.Item("empresa").ToString.ToLower = "codicasa" Then
            linea = "CODICASA"
        ElseIf dr.Item("empresa").ToString.ToLower = "alamsa" Then
            linea = "ALAMSA"
        ElseIf dr.Item("empresa").ToString.ToLower = "diuva" Then
            linea = "DISTRIBUIDORA LA UVA, S.A."
        ElseIf dr.Item("empresa").ToString.ToLower = "vinoteca" Then
            linea = "VINOTECA"
        End If

        Imprimir_TMU_Linea(linea, True)
        Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & dr.Item("tipodocto").ToString & "-" & dr.Item("Numero").ToString)
        Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & "Bodega     :" & dr.Item("Bodega").ToString)
        Imprimir_TMU_Linea(Chr(27))
        Imprimir_TMU_Linea("Fecha      :" & Date.Parse(dr.Item("Fecha").ToString).ToString("dd/MM/yyyy"))
        Imprimir_TMU_Linea("Cliente    :" & dr.Item("Cliente").ToString)
        Imprimir_TMU_Linea(IIf(dr.Item("Vigencia").ToString = "A", "****DOCUMENTO ANULADO", dr.Item("RazonSocial").ToString))
        Imprimir_TMU_Linea("Direccion  :" & dr.Item("Direccion").ToString)
        Imprimir_TMU_Linea(Chr(27))
        Imprimir_TMU_Linea("Comentario :" & dr.Item("Comentario1").ToString.Trim & " " & dr.Item("glosa_docto").ToString.Trim)
        Imprimir_TMU_Linea(Chr(27))
    End Sub

    'Private Sub Imprimir_TMU_EncabezadoNET(ByVal dt As DataTable)
    '    Dim lpt1 As StreamWriter = GetStreamWriter("COM1")
    '    Dim dr As DataRow
    '    dr = dt.Rows(0)
    '    Dim linea As String = String.Empty
    '    If dr.Item("empresa").ToString.ToLower = "dmarte1" Then
    '        linea = "DISTRIBUIDORA MARTE, S.A."
    '    ElseIf dr.Item("empresa").ToString.ToLower = "codicasa" Then
    '        linea = "CODICASA"
    '    ElseIf dr.Item("empresa").ToString.ToLower = "alamsa" Then
    '        linea = "ALAMSA"
    '    ElseIf dr.Item("empresa").ToString.ToLower = "diuva" Then
    '        linea = "DISTRIBUIDORA LA UVA, S.A."
    '    ElseIf dr.Item("empresa").ToString.ToLower = "vinoteca" Then
    '        linea = "VINOTECA"
    '    End If

    '    imprimeLineaNegra(linea, "", lpt1)
    '    imprimeLineaNegra("Factura No.:" & dr.Item("Numero").ToString, "rojo", lpt1)

    '    '        imprimeLineaRoja("Factura No.:" & dr.Item("Numero").ToString)
    '    imprimeLineaNegra("Bodega     :" & dr.Item("Bodega").ToString, "", lpt1)
    '    imprimeLineaNegra(Chr(27), "", lpt1)
    '    imprimeLineaNegra("Fecha      :" & dr.Item("Fecha").ToString, "", lpt1)
    '    imprimeLineaNegra("Cliente    :" & dr.Item("Cliente").ToString, "", lpt1)
    '    imprimeLineaNegra(IIf(dr.Item("Vigencia").ToString = "A", "****DOCUMENTO ANULADO", dr.Item("RazonSocial").ToString), "", lpt1)
    '    imprimeLineaNegra("Direccion  :" & dr.Item("Direccion").ToString, "", lpt1)
    '    imprimeLineaNegra(Chr(27), "", lpt1)
    '    imprimeLineaNegra("Comentario :" & dr.Item("Comentario1").ToString.Trim & " " & dr.Item("glosa_docto").ToString.Trim, "", lpt1)
    '    imprimeLineaNegra(Chr(27), "", lpt1)
    '    lpt1.Close()
    'End Sub

    Public Sub Imprimir_TMU_Linea(ByVal Cadena As String, ByVal Centrar As Boolean)
        Dim diferencia As Integer
        Dim CadenaImprimir As String
        Dim MaxLen As Integer = 40
        If Centrar Then

            If Len(Cadena) < MaxLen Then
                diferencia = (MaxLen - Len(Cadena)) / 2
                If Len(Cadena) + (diferencia) * 2 > MaxLen Then
                    diferencia -= 1
                End If
                '  Cadena = Cadena.PadLeft(diferencia, Space(1))
                ' Cadena = Cadena.PadRight(diferencia - 1, Space(1))
            End If
        End If
        CadenaImprimir = Cadena.ToString.Replace("ñ", Chr(164)).Replace("ó", Chr(162)).Replace("é", Chr(130))
        prt.Imprimir(Space(diferencia) + CadenaImprimir, "LPT1")
        System.Threading.Thread.CurrentThread.Sleep(150)
    End Sub

    Private Sub Imprimir_TMU_Linea(ByVal Cadena As String)

        Dim CadenaImprimir As String
        '        prt.Imprimir(Cadena, "COM1")   'Nombre empresa
        CadenaImprimir = Cadena.ToString.Replace("ñ", Chr(164)).Replace("ó", Chr(162)).Replace("é", Chr(130))
        prt.Imprimir(CadenaImprimir, "LPT1")

        Threading.Thread.Sleep(150)
    End Sub

    'Private Sub Imprimir_TMU_Linea(ByVal Cadena As String, ByVal lpt1 As StreamWriter, ByVal color As String)
    '    imprimeLineaNegra(Cadena, color, lpt1)

    '    'prt.Imprimir(Cadena, "COM1")   'Nombre empresa
    '    'Threading.Thread.Sleep(150)
    'End Sub


    Private Sub imprimir_TMU_finalizar()
        'lpt1 en CD
        'com1 en cd
        'instalado el 20/06/2011
        prt.FinyCortar("LPT1")
    End Sub
    'Private Sub imprimir_TMU_finalizar(ByVal lpt1 As StreamWriter)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(vbCrLf)
    '    lpt1.WriteLine(Chr(27) & "m")
    'End Sub


    Private Function imprimirLaser(ByVal _Empresa As String, ByVal _TipoDocto As String, _
               ByVal _Numero As String, ByVal bEsReimpresion As Boolean, ByVal bCopia As Boolean, iNumeroCopias As Integer) As Boolean
        Dim path_reporte As String
        Dim nombre_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbreturn As Boolean = False
        Try
            'Obtengo Datos de Conexion
            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte

            If _Empresa.ToUpper.Equals("DIMAEXSA") Then
                path_reporte += "Logistica\Picking\Picking DIMAEXSA.rpt"
            Else
                path_reporte += "Logistica\Picking\Picking Barra.rpt"
            End If


            pm_parametros(0) = "@Empresa"
            pm_valores(0) = _Empresa

            pm_parametros(1) = "@TipoDocto"
            pm_valores(1) = _TipoDocto

            pm_parametros(2) = "@Numero"
            pm_valores(2) = _Numero
            lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                           False, True, "PDF", True, "", True, iNumeroCopias)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try
        Return lbreturn
    End Function


    Private Sub imprimirLaser2(ByVal _Empresa As String, ByVal _TipoDocto As String, _
                ByVal _Numero As String, ByVal bEsReimpresion As Boolean, ByVal bCopia As Boolean)
        Dim path_reporte As String
        Dim nombre_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General



        'Obtengo Datos de Conexion
        pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
        path_reporte = ClsGen.Path_Reporte


        path_reporte += "Logistica\Picking\Picking Barra.rpt"

        pm_parametros(0) = "@Pempresa"
        pm_valores(0) = _Empresa

        pm_parametros(1) = "@PTipoDocto"
        pm_valores(1) = _TipoDocto

        pm_parametros(2) = "@PNumero"
        pm_valores(2) = _Numero


        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                       False, True, "PDF", True, "", True)


        ClsGen = Nothing

    End Sub

    Private Sub Imprimir_TMU(ByVal _Empresa As String, ByVal _TipoDocto As String, _
                ByVal _Numero As String, ByVal bEsReimpresion As Boolean, ByVal bCopia As Boolean)


        Dim ls_sql, spuntos As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cajas As Integer = 0
        Dim cajas_decimal As Double = 0
        Dim totalunidades As Integer = 0
        Dim totalunidades_decimal As Decimal = 0
        Dim lbCentralizadoWalmart As Boolean = False


        Dim cantidad_decimal As Double = 0


        Dim btienelote As Boolean = False

        spuntos = "  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  ."

        Try



            ls_sql = "pa_var_um_documento_picking '" & _Empresa & "','" & _TipoDocto & "','" & _Numero & "'"

            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            otrans.close()
            otrans = Nothing

            prt = New prtcom.Imprimir_Puerto

            If bCopia Then
                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & "               -- COPIA --")
                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0))
            End If


            Imprimir_TMU_Encabezado(dt)
            Imprimir_TMU_Linea(Chr(27))
            Imprimir_TMU_Linea(Chr(27))
            If dt.Rows(0).Item("Cliente").ToString.Trim.Equals("49067552") Then
                lbCentralizadoWalmart = True
            End If

            If lbCentralizadoWalmart Then
                Imprimir_TMU_Linea("Codigo      Medida  Cajas Unidades   IP")
            Else
                Imprimir_TMU_Linea("Codigo       Medida    Cajas   Unidades")
            End If


            For Each dr In dt.Rows

                cantidad_decimal = 0
                cajas_decimal = 0
                cajas = 0

                If dr.Item("unidadingreso").ToString.StartsWith("LIB") Or dr.Item("unidadingreso").ToString.StartsWith("KI") Then
                    If dr.Item("FactorAlt") = 0 Then
                        cajas_decimal = 0
                    Else
                        cajas_decimal = dr.Item("Cantidad") / dr.Item("FACTORALT")
                        cajas_decimal = Format(Convert.ToDecimal(cajas_decimal), "###,###,##0.00").ToString()
                        cantidad_decimal = Format(Convert.ToDecimal(dr.Item("cantidad").ToString), "###,###,##0.00").ToString()
                    End If

                Else

                    If dr.Item("FactorAlt") = 0 Then
                        cajas = 0
                    Else
                        cajas = dr.Item("Cantidad") / dr.Item("FACTORALT")
                    End If
                End If


                If lbCentralizadoWalmart Then
                    ls_sql = dr.Item("producto").ToString.PadRight(10) & "   " & _
                            Format(Convert.ToDecimal(dr.Item("volumen").ToString), "###,###,##0.00").ToString.PadRight(4) & " " & _
                            IIf(cajas > 0, cajas.ToString.PadLeft(5), cajas_decimal.ToString.PadLeft(5)) & " " & _
                    IIf(cantidad_decimal > 0, Format(Convert.ToDecimal(cantidad_decimal.ToString), "###,###,##0.00").ToString.PadLeft(8), Format(Convert.ToDecimal(dr.Item("cantidad")), "###,###,##0").ToString.PadLeft(8))

                    Try
                        ls_sql += dr.Item("InnerPack").ToString.Trim.PadLeft(7)
                    Catch ex As Exception

                    End Try
                Else



                    ls_sql = dr.Item("producto").ToString.PadRight(10) & "     " & _
                            Format(Convert.ToDecimal(dr.Item("volumen").ToString), "###,###,##0.00").ToString.PadRight(5) & " " & _
                            IIf(cajas > 0, cajas.ToString.PadLeft(7), cajas_decimal.ToString.PadLeft(7)) & " " & _
                    IIf(cantidad_decimal > 0, Format(Convert.ToDecimal(cantidad_decimal.ToString), "###,###,##0.00").ToString.PadLeft(10), Format(Convert.ToDecimal(dr.Item("cantidad")), "###,###,##0").ToString.PadLeft(10))
                End If
                ' Format(Convert.ToDecimal(cantidad_decimal.ToString), "###,###,##0").ToString.PadLeft(10)

                'Format(Convert.ToDecimal(dr.Item("volumen").ToString), "###,###,##0.00").ToString.PadRight(5) & " " & _
                '      cajas.ToString.PadLeft(7) & " " & _
                '      Format(Convert.ToDecimal(dr.Item("cantidad").ToString), "###,###,##0").ToString.PadLeft(10)


                ' imprimeLineaNegraRoja(ls_sql)

                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & ls_sql)

                If dr.Item("glosa").ToString.Length <= 40 Then
                    ls_sql = dr.Item("glosa").ToString.ToLower & spuntos
                    ls_sql = ls_sql.Substring(0, 40)
                Else
                    ls_sql = dr.Item("glosa").ToString.ToLower.PadRight(75).Substring(0, 75) & " "
                End If

                If ls_sql.Length > 40 Then
                    ls_sql = ls_sql.PadRight(75).Substring(0, 75) & " "



                End If

                Imprimir_TMU_Linea(ls_sql)

                If dr.Item("lote").ToString.Length > 0 And dr.Item("fechavcto").ToString.Length > 0 Then
                    ' si el trae lote y fechavcto
                    ls_sql = "Lote: " & dr.Item("lote").ToString.ToLower & "  FechaVcto.:" & Date.Parse(dr.Item("fechavcto").ToString).ToString("dd/MM/yyyy")
                ElseIf dr.Item("lote").ToString.Length > 0 And dr.Item("fechavcto").ToString.Length = 0 Then
                    ' solo trae lote
                    ls_sql = "Lote: " & dr.Item("lote").ToString.ToLower
                End If

                If ls_sql.Length <= 40 And ls_sql.Length > 0 And dr.Item("lote").ToString.Length > 0 Then
                    'ls_sql = ls_sql.PadRight(79).Substring(0, 79) & " "
                    'ls_sql = ls_sql.ToString.ToLower & spuntos
                    'ls_sql = ls_sql.Substring(0, 40)
                    Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & ls_sql)
                    Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0))
                    btienelote = True
                Else
                    Imprimir_TMU_Linea(Chr(27))
                End If
                If cantidad_decimal > 0 Then
                    totalunidades_decimal += Format(Convert.ToDecimal(dr.Item("cantidad")), "###,###,##0.00").ToString
                Else
                    totalunidades += dr.Item("cantidad")
                End If


            Next
            Imprimir_TMU_Linea(Chr(27))
            ' Imprimir_TMU_Linea("   ::. Puntos Acumulados .::  " & Me.lbl_total.Text)
            Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & "Total de Unidades .: " & IIf(totalunidades_decimal > 0, totalunidades_decimal.ToString, totalunidades.ToString))
            Imprimir_TMU_Linea(Chr(27))

            If dt.Rows(0).Item("tipocliente").ToString.Length > 0 Then
                Imprimir_TMU_Linea(dt.Rows(0).Item("tipocliente").ToString.ToUpper, True)
            End If

            Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & "Ruta   : " & dt.Rows(0).Item("analisisCtacte9").ToString)
            'Imprimir_TMU_Linea("Ruta   : " & dt.Rows(0).Item("analisisCtacte9").ToString & " " & Now.ToShortDateString & " " & Now.ToLongTimeString)
            Imprimir_TMU_Linea("Picker : " & dt.Rows(0).Item("nombre_picking").ToString)

            imprimir_TMU_finalizar()


        Catch ex As Exception
        Finally
            prt = Nothing

            If btienelote And bEsReimpresion = False Then
                Imprimir_TMU(_Empresa, _TipoDocto, _Numero, True, True)
            End If
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Crear_Estructura()
            If pb_manual Then
                Me.dtp_fecha_inicio.Value = Me.dtp_fecha_inicio.Value.AddDays(-4)
                If Me.dtp_fecha_inicio.Value.Month <> Now.Month Then
                    Me.dtp_fecha_inicio.Text = "01/" & Month(Now()).ToString & "/" & Year(Now())
                End If
            End If
            Llenar_Pendientes()
            Colorear_Grid()
            'Colorear_Grid_reimpresion()
            Me.lbl_tipo_impresion.Text = Me.lbl_tipo_impresion.Text & IIf(pb_manual = True, " Manual", " Auto")

            If Not pb_manual Then
                If MessageBox.Show("Esta Seguro de Imprimir", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'imprimir()
                End If
            End If
            '       Asignar_path()

            If gs_empresa.ToLower = "dimaexsa" Then
                Me.btnImprimirTMU.Visible = True
                Me.BtnReimpresionPickign.Visible = True
                Me.btn_imprimir.Visible = True
                Me.btn_reimprimir.Visible = True
            End If

            If tiene_permisos("mlo_Impresion_picking_tmk") Then
                'Me.btnImprimirTMU.Visible = True
                Me.BtnReimpresionPickign.Visible = True
                Me.btn_imprimir.Visible = True
                Me.btn_reimprimir.Visible = True

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetBackColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value As Integer
            Dim value2 As String
            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = CInt(data("minutos"))

            If value >= 30 And value < 60 Then
                e.RowColor = Color.Orange
            End If
            If value >= 60 Then
                e.RowColor = Color.Red
            End If
            value2 = data("ruta_logistica")

            If value2.Trim.Length = 0 Or value2.Trim.ToLower = "sin ruta" Then
                e.RowColor = Color.Blue
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value As Integer
            Dim value2 As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = CInt(data("minutos"))


            If value >= 30 And value < 60 Then
                e.RowColor = Color.Orange
            End If
            If value >= 60 Then
                e.RowColor = Color.Red
            End If
            value2 = data("ruta_logistica")

            If value2.Trim.Length = 0 Or value2.Trim.ToLower = "sin ruta" Then
                e.RowColor = Color.Blue
            End If

            value2 = data("tipo_cliente")
            If value2.Trim.ToLower = "on capital" Then
                e.RowColor = Color.Chocolate
            End If

            If value2.Trim.ToLower = "telemarketing" Then
                e.RowColor = Color.DarkMagenta
            End If

        Catch ex As Exception
        End Try


    End Sub

    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        Me.Timer1.Stop()

        Llenar_Pendientes()
        Colorear_Grid()
        Me.Timer1.Start()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        '    Me.Timer1.Stop()
        '   imprimir()
        '  Me.Timer1.Start()

        procesarImpresion("LASER")
    End Sub

    Private Sub btn_buscar_reimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_reimpresion.Click

        Try
            Me.Cursor.Current = Cursors.WaitCursor
            Me.btn_buscar_reimpresion.Enabled = False
            Llenar_Reimpresion()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.btn_buscar_reimpresion.Enabled = True

        End Try

        'Colorear_Grid_reimpresion()
    End Sub

    Private Sub btn_reimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimprimir.Click
        'Re_Imprimir()
        'Imprimir_TMU()
        Try

            ds_picking.Tables("re_impresion").DefaultView.RowFilter = "imprimir = True"

            For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView

                imprimirLaser(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), True, False, 1)
                'drv.Item("imprimir") = False
            Next

        Catch ex As Exception
        Finally
            'ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Llenar_Pendientes()
        Colorear_Grid()
        'If Not pb_manual Then
        '    imprimir()
        'End If

    End Sub

    Private Sub btn_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte.Click

        Dim path_reporte As String
        Dim nombre_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Dim oForm As New frm_pickeador
        oForm.Text = "Seleccione Reporte"
        oForm.Label1.Text = "Reporte"
        oForm.Llenar_Combo_reportes()
        oForm.ShowDialog(Me)
        nombre_reporte = oForm.cmb_nombre_picker.Text
        oForm.Dispose()
        oForm = Nothing

        'Obtengo Datos de Conexion
        pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
        path_reporte = ClsGen.Path_Reporte


        path_reporte += "Logistica\Picking\" & nombre_reporte.Trim & ".rpt"

        pm_parametros(0) = "fecha"
        pm_valores(0) = Me.dtp_fecha_inicio_reimpresion.Text

        If nombre_reporte.Trim.ToLower = "picking diario" Or _
            nombre_reporte.Trim.ToLower = "flujo de facturacion al cd rango" Then
            pm_parametros(1) = "fecha_final"
            pm_valores(1) = Me.dtp_fecha_final_reimpresion.Text
        End If

        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                       False, False, "PDF", False, "", True)


        ClsGen = Nothing

    End Sub

    Private Sub txt_refrescar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_refrescar.LostFocus
        If Val(Me.txt_refrescar.Text) > 30 Or Val(Me.txt_refrescar.Text) < 1 Then
            Me.txt_refrescar.Text = 5
        End If
    End Sub

    Private Sub txt_refrescar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_refrescar.TextChanged

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dg_picking_sin_guia_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs)

    End Sub

    Private Sub btnImprimirTMU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirTMU.Click
        procesarImpresion("TMU")
    End Sub

    Private Sub procesarImpresion(ByVal psTipo As String, Optional ByVal pbRellenarpicking As Boolean = True)

        Dim lsSQL, nombrePicker As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lbImprimirAutomatico As Boolean = tiene_permisos("mlo_impresion_picking_automatico_tmk")

        Me.Timer1.Stop()

        Try
            If lbImprimirAutomatico Then
                nombrePicker = gs_nombre_usuario
            Else
                Dim oform As New frm_pickeador
                oform.Llenar_Combo()
                oform.ShowDialog(Me)
                nombrePicker = oform.cmb_nombre_picker.Text
                oform.Dispose()

            End If

            Otrans.open()

            ds_picking.Tables("pendientes_impresion").DefaultView.RowFilter = "imprimir = True"

            For Each drv As DataRowView In ds_picking.Tables("pendientes_impresion").DefaultView

                lsSQL = "pa_ins_um_gen_log_documento_tracking  '" &
                            drv.Item("empresa") & "','" & drv.Item("serie") &
                            "','" & drv.Item("factura") & "','" & gs_usuario & "','" &
                            nombrePicker & "', NULL"

                Otrans.Ingresa(lsSQL)
                If psTipo.Equals("TMU") Then
                    Imprimir_TMU(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), False, False)
                ElseIf psTipo.Equals("LASER") Then
                    imprimirLaser(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), False, False, 1)
                End If

            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ds_picking.Tables("pendientes_impresion").DefaultView.RowFilter = ""
            If pbRellenarpicking Then
                Llenar_Pendientes()
                Colorear_Grid()

            End If
        End Try

        Me.Timer1.Start()
    End Sub

    Private Sub BtnReimpresionPickign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresionPickign.Click

        Try

            ds_picking.Tables("re_impresion").DefaultView.RowFilter = "imprimir = True"

            For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView

                Imprimir_TMU(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), True, False)
                'drv.Item("imprimir") = False
            Next

        Catch ex As Exception
        Finally
            'ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
        End Try


        Llenar_Reimpresion()
        'ImprimeFact()

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub dg_listado_pendientes_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_listado_pendientes.Navigate

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim picker As String
        ''picker = cmbPickers.Text
        'If (picker.Length > 20) Then
        '    picker = picker.Substring(0, 20)
        'End If
        agregarFacturasAsignadas("pa_sel_um_documentos_picking_pendiente null")
    End Sub
    Private Sub agregarFacturasAsignadas(ByVal ls_sql As String)

        Dim dr, draux As DataRow
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        estructuraFacturasAsignadas()
        dtAsignar = ds_picking.Tables("facturas_asignadas")
        Try
            otrans.open()
            dtaux = otrans.Obtiene(ls_sql)
            For Each dr In dtaux.Rows
                draux = dtAsignar.NewRow
                draux.Item("Imprimir") = False
                draux.Item("Lineas") = dr.Item("lineas")
                draux.Item("Empresa") = dr.Item("empresa")
                draux.Item("Tipo Cliente") = dr.Item("tipocliente")
                draux.Item("Nombre Cliente") = dr.Item("nombre_cliente")
                draux.Item("TipoDocto") = dr.Item("tipodocto")
                draux.Item("Factura") = dr.Item("factura")
                draux.Item("Bodega") = dr.Item("bodega")
                draux.Item("picker") = dr.Item("nombre_picking")
                draux.Item("Ruta") = dr.Item("ruta")
                draux.Item("Fecha Asignación") = dr.Item("fecha_asignacion_picking")
                draux.Item("Fecha Factura") = dr.Item("fecha_factura")
                dtAsignar.Rows.Add(draux)
            Next
            Me.dg_picking_sin_guia.DataSource = dtAsignar
            'dgPickingAsignado.DataSource = dtAsignar
            Dim clsgen As New ClasesGenerales.General
            clsgen.Alinear_GridView(dtAsignar, dg_picking_sin_guia, "", "", ",Empresa,Tipo Cliente,Nombre Cliente,TipoDocto,Factura,Bodega,Ruta,Fecha Asignación,fecha factura,", "", False, True, 300, 40)
        Catch ex As Exception
        Finally
            otrans.close()
        End Try
    End Sub
    Private Sub estructuraFacturasAsignadas()

        Dim dt As New DataTable("facturas_asignadas")
        dt.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("Picker", GetType(String)))
        dt.Columns.Add(New DataColumn("Ruta", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha Asignación", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha factura", GetType(DateTime)))
        Try
            ds_picking.Tables.Remove("facturas_asignadas")
        Catch ex As Exception

        End Try
        ds_picking.Tables.Add(dt.Copy)
    End Sub
End Class
