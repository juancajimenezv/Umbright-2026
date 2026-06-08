Option Explicit On

Imports System.IO
Imports System.Math

Public Class frm_PedidosEdiFact
    Inherits System.Windows.Forms.Form
    Dim oDataSet As New DataSet
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFinalCentralizado As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicioCentralizado As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvDetalleCentralizado As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEncabezadoCentralizado As System.Windows.Forms.DataGridView
    Friend WithEvents btnCentralizadas As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComenariosCentralizado As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesarCentralizado As System.Windows.Forms.Button
    Friend WithEvents txtPorcCentralizado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Dim ods As New DataSet


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
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents txt_facturas As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_detalle_reimpresion As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_pedidos_reimpresion As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_re_generar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt_re_facturas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_re_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PedidosEdiFact))
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.txt_facturas = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv_detalle_reimpresion = New System.Windows.Forms.DataGridView()
        Me.dgv_pedidos_reimpresion = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_re_generar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_re_facturas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_re_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtPorcCentralizado = New System.Windows.Forms.TextBox()
        Me.btnProcesarCentralizado = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtComenariosCentralizado = New System.Windows.Forms.TextBox()
        Me.btnCentralizadas = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFinalCentralizado = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicioCentralizado = New System.Windows.Forms.DateTimePicker()
        Me.dgvDetalleCentralizado = New System.Windows.Forms.DataGridView()
        Me.dgvEncabezadoCentralizado = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_detalle_reimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pedidos_reimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDetalleCentralizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEncabezadoCentralizado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(106, 16)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(100, 21)
        Me.dtp_fecha_inicio.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha"
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(3, 340)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(1007, 223)
        Me.dgv_detalle.TabIndex = 19
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AllowUserToAddRows = False
        Me.dgv_pedidos.AllowUserToDeleteRows = False
        Me.dgv_pedidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(3, 111)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.RowHeadersWidth = 25
        Me.dgv_pedidos.Size = New System.Drawing.Size(1007, 223)
        Me.dgv_pedidos.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.btn_generar)
        Me.GroupBox3.Controls.Add(Me.btn_procesar)
        Me.GroupBox3.Controls.Add(Me.txt_facturas)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.dtp_fecha_inicio)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(809, 70)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informacion"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 3
        Me.Button1.ImageList = Me.ImageList4
        Me.Button1.Location = New System.Drawing.Point(650, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 49)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "PDF"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "7.png")
        Me.ImageList4.Images.SetKeyName(1, "3.png")
        Me.ImageList4.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList4.Images.SetKeyName(3, "print_48.png")
        Me.ImageList4.Images.SetKeyName(4, "Floppy-64.png")
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList3
        Me.btn_generar.Location = New System.Drawing.Point(335, 12)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(125, 49)
        Me.btn_generar.TabIndex = 35
        Me.btn_generar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "")
        Me.ImageList3.Images.SetKeyName(1, "")
        '
        'btn_procesar
        '
        Me.btn_procesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_procesar.ImageIndex = 3
        Me.btn_procesar.ImageList = Me.ImageList4
        Me.btn_procesar.Location = New System.Drawing.Point(500, 12)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(105, 49)
        Me.btn_procesar.TabIndex = 28
        Me.btn_procesar.Text = "Imprimir"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'txt_facturas
        '
        Me.txt_facturas.Location = New System.Drawing.Point(106, 46)
        Me.txt_facturas.Name = "txt_facturas"
        Me.txt_facturas.ReadOnly = True
        Me.txt_facturas.Size = New System.Drawing.Size(100, 21)
        Me.txt_facturas.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Ordenes Compra"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "aceptar.png")
        Me.ImageList2.Images.SetKeyName(1, "DeleteRed.png")
        Me.ImageList2.Images.SetKeyName(2, "running_process.png")
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
        Me.TabControl1.Size = New System.Drawing.Size(1024, 595)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtComentarios)
        Me.TabPage1.Controls.Add(Me.btnProcesar)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.dgv_detalle)
        Me.TabPage1.Controls.Add(Me.dgv_pedidos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1016, 569)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ordenes Pendientes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Purple
        Me.Label9.Location = New System.Drawing.Point(637, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Orden Centralizada"
        '
        'txtComentarios
        '
        Me.txtComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentarios.Location = New System.Drawing.Point(109, 73)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(178, 32)
        Me.txtComentarios.TabIndex = 23
        '
        'btnProcesar
        '
        Me.btnProcesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.ForeColor = System.Drawing.Color.White
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(313, 76)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(81, 29)
        Me.btnProcesar.TabIndex = 35
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Comentarios"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgv_detalle_reimpresion)
        Me.TabPage2.Controls.Add(Me.dgv_pedidos_reimpresion)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1016, 569)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado Ordenes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv_detalle_reimpresion
        '
        Me.dgv_detalle_reimpresion.AllowUserToAddRows = False
        Me.dgv_detalle_reimpresion.AllowUserToDeleteRows = False
        Me.dgv_detalle_reimpresion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle_reimpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle_reimpresion.Location = New System.Drawing.Point(3, 404)
        Me.dgv_detalle_reimpresion.Name = "dgv_detalle_reimpresion"
        Me.dgv_detalle_reimpresion.ReadOnly = True
        Me.dgv_detalle_reimpresion.RowHeadersWidth = 20
        Me.dgv_detalle_reimpresion.Size = New System.Drawing.Size(1007, 159)
        Me.dgv_detalle_reimpresion.TabIndex = 23
        '
        'dgv_pedidos_reimpresion
        '
        Me.dgv_pedidos_reimpresion.AllowUserToAddRows = False
        Me.dgv_pedidos_reimpresion.AllowUserToDeleteRows = False
        Me.dgv_pedidos_reimpresion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos_reimpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos_reimpresion.Location = New System.Drawing.Point(3, 89)
        Me.dgv_pedidos_reimpresion.Name = "dgv_pedidos_reimpresion"
        Me.dgv_pedidos_reimpresion.RowHeadersWidth = 25
        Me.dgv_pedidos_reimpresion.Size = New System.Drawing.Size(1007, 306)
        Me.dgv_pedidos_reimpresion.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btn_re_generar)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txt_re_facturas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_re_fecha_inicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(852, 80)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 3
        Me.Button3.ImageList = Me.ImageList4
        Me.Button3.Location = New System.Drawing.Point(610, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(105, 62)
        Me.Button3.TabIndex = 37
        Me.Button3.Text = "PDF"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btn_re_generar
        '
        Me.btn_re_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_re_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_re_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_re_generar.ForeColor = System.Drawing.Color.White
        Me.btn_re_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_re_generar.ImageIndex = 0
        Me.btn_re_generar.ImageList = Me.ImageList3
        Me.btn_re_generar.Location = New System.Drawing.Point(335, 12)
        Me.btn_re_generar.Name = "btn_re_generar"
        Me.btn_re_generar.Size = New System.Drawing.Size(125, 62)
        Me.btn_re_generar.TabIndex = 35
        Me.btn_re_generar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_re_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_re_generar.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.ImageIndex = 3
        Me.Button2.ImageList = Me.ImageList4
        Me.Button2.Location = New System.Drawing.Point(481, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 62)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txt_re_facturas
        '
        Me.txt_re_facturas.Location = New System.Drawing.Point(106, 46)
        Me.txt_re_facturas.Name = "txt_re_facturas"
        Me.txt_re_facturas.ReadOnly = True
        Me.txt_re_facturas.Size = New System.Drawing.Size(100, 21)
        Me.txt_re_facturas.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ordenes Compra"
        '
        'dtp_re_fecha_inicio
        '
        Me.dtp_re_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_re_fecha_inicio.Location = New System.Drawing.Point(106, 16)
        Me.dtp_re_fecha_inicio.Name = "dtp_re_fecha_inicio"
        Me.dtp_re_fecha_inicio.Size = New System.Drawing.Size(100, 21)
        Me.dtp_re_fecha_inicio.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtPorcCentralizado)
        Me.TabPage3.Controls.Add(Me.btnProcesarCentralizado)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.txtComenariosCentralizado)
        Me.TabPage3.Controls.Add(Me.btnCentralizadas)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.dtpFinalCentralizado)
        Me.TabPage3.Controls.Add(Me.dtpInicioCentralizado)
        Me.TabPage3.Controls.Add(Me.dgvDetalleCentralizado)
        Me.TabPage3.Controls.Add(Me.dgvEncabezadoCentralizado)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1016, 569)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "OdC Centralizadas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtPorcCentralizado
        '
        Me.txtPorcCentralizado.Location = New System.Drawing.Point(604, 494)
        Me.txtPorcCentralizado.Name = "txtPorcCentralizado"
        Me.txtPorcCentralizado.Size = New System.Drawing.Size(56, 21)
        Me.txtPorcCentralizado.TabIndex = 7
        Me.txtPorcCentralizado.Text = "0"
        '
        'btnProcesarCentralizado
        '
        Me.btnProcesarCentralizado.Location = New System.Drawing.Point(825, 512)
        Me.btnProcesarCentralizado.Name = "btnProcesarCentralizado"
        Me.btnProcesarCentralizado.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesarCentralizado.TabIndex = 6
        Me.btnProcesarCentralizado.Text = "Procesar"
        Me.btnProcesarCentralizado.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(507, 497)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "% Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 497)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Comentarios"
        '
        'txtComenariosCentralizado
        '
        Me.txtComenariosCentralizado.Location = New System.Drawing.Point(81, 494)
        Me.txtComenariosCentralizado.Multiline = True
        Me.txtComenariosCentralizado.Name = "txtComenariosCentralizado"
        Me.txtComenariosCentralizado.Size = New System.Drawing.Size(395, 69)
        Me.txtComenariosCentralizado.TabIndex = 4
        '
        'btnCentralizadas
        '
        Me.btnCentralizadas.Location = New System.Drawing.Point(183, 6)
        Me.btnCentralizadas.Name = "btnCentralizadas"
        Me.btnCentralizadas.Size = New System.Drawing.Size(75, 23)
        Me.btnCentralizadas.TabIndex = 3
        Me.btnCentralizadas.Text = "Buscar"
        Me.btnCentralizadas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Final"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Inicio"
        '
        'dtpFinalCentralizado
        '
        Me.dtpFinalCentralizado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinalCentralizado.Location = New System.Drawing.Point(96, 31)
        Me.dtpFinalCentralizado.Name = "dtpFinalCentralizado"
        Me.dtpFinalCentralizado.Size = New System.Drawing.Size(81, 21)
        Me.dtpFinalCentralizado.TabIndex = 1
        '
        'dtpInicioCentralizado
        '
        Me.dtpInicioCentralizado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicioCentralizado.Location = New System.Drawing.Point(96, 6)
        Me.dtpInicioCentralizado.Name = "dtpInicioCentralizado"
        Me.dtpInicioCentralizado.Size = New System.Drawing.Size(81, 21)
        Me.dtpInicioCentralizado.TabIndex = 1
        '
        'dgvDetalleCentralizado
        '
        Me.dgvDetalleCentralizado.AllowUserToAddRows = False
        Me.dgvDetalleCentralizado.AllowUserToDeleteRows = False
        Me.dgvDetalleCentralizado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleCentralizado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleCentralizado.Location = New System.Drawing.Point(8, 215)
        Me.dgvDetalleCentralizado.Name = "dgvDetalleCentralizado"
        Me.dgvDetalleCentralizado.RowHeadersWidth = 25
        Me.dgvDetalleCentralizado.Size = New System.Drawing.Size(1002, 273)
        Me.dgvDetalleCentralizado.TabIndex = 0
        '
        'dgvEncabezadoCentralizado
        '
        Me.dgvEncabezadoCentralizado.AllowUserToAddRows = False
        Me.dgvEncabezadoCentralizado.AllowUserToDeleteRows = False
        Me.dgvEncabezadoCentralizado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEncabezadoCentralizado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEncabezadoCentralizado.Location = New System.Drawing.Point(8, 59)
        Me.dgvEncabezadoCentralizado.Name = "dgvEncabezadoCentralizado"
        Me.dgvEncabezadoCentralizado.RowHeadersWidth = 20
        Me.dgvEncabezadoCentralizado.Size = New System.Drawing.Size(1002, 153)
        Me.dgvEncabezadoCentralizado.TabIndex = 0
        '
        'frm_PedidosEdiFact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 598)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_PedidosEdiFact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ":: Edi Fact ::"
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_detalle_reimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pedidos_reimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvDetalleCentralizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEncabezadoCentralizado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Pedidos_Pendientes()
        Dim coTrans As New Transaccional.Conexion("Corporativo")
        Dim clGen As New ClasesGenerales.General
        Dim oTabla, tabla As DataTable
        Dim dt, dtProductos, dtTipoCentralizado As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String
        Dim fecha As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        Dim total_q As Double
        Dim unidades As Integer


        Dim ls_sqltxt As String
        oDataSet = New DataSet
        Dim dtCliente As DataTable

        ods.Tables("pedidos").Rows.Clear()

        'Me.dtp_fecha_inicio.CustomFormat = "yyyy-MM-dd"
        'Me.dtp_fecha_inicio.Format = DateTimePickerFormat.Custom



        ls_sqltxt = "pa_sel_um_edi_pedido_encabezado '" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & "','1'"
        'myoTrans = New Transaccional.Conexion_mysql("Umbright")

        dtTipoCentralizado = clGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null,'gen_oc_centralizada','" & gs_empresa & "'")

        Try
            coTrans.open()
            oTrans.open()
            oTabla = coTrans.Obtiene(ls_sqltxt)



            ls_sqltxt = "pa_sel_um_edi_pedido_detalle '" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & "'"
            tabla = coTrans.Obtiene(ls_sqltxt)

            tabla.TableName = "detalle_pedidos"

            oDataSet.Tables.Add(tabla.Copy)


            Me.txt_facturas.Text = oTabla.Rows.Count
            'dt = oTrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE'")

            dtProductos = oTrans.Obtiene("pa_sel_um_producto '" & gs_empresa & "'")




            For Each dr In oTabla.Rows

                'ls_sql = " pa_sel_um_ctacte_edi_tk '" & gs_empresa & "','" & dr.Item("ctacte") & "'"
                'dt = oTrans.Obtiene(ls_sql)
                total_q = 0
                unidades = 0

                oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"


                Try
                    If oDataSet.Tables("detalle_pedidos").DefaultView.Count = 0 Then

                        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "'"
                    End If
                    ' tengo que validar los totales
                    Dim drvs As DataRowView
                    drvs = oDataSet.Tables("detalle_pedidos").DefaultView(0)


                    For j As Integer = 0 To drvs.DataView.Count - 1

                        'total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precio")
                        total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precioflex")

                        unidades += drvs.DataView(j)("cantidad")

                    Next


                Catch ex As Exception

                End Try

                dr_aux = ods.Tables("pedidos").NewRow
                dr_aux.Item("Imprimir") = 1
                dr_aux.Item("No Pedido") = dr.Item("idtransaccion")
                dr_aux.Item("Ctacte") = dr.Item("ctacte")
                dr_aux.Item("RazonSocial") = dr.Item("nombre")
                dr_aux.Item("Nombre_Flex") = ""
                dr_aux.Item("Total") = Math.Round(total_q, 2)
                dr_aux.Item("Unidades") = unidades
                dr_aux.Item("Fecha") = dr.Item("fechahora")
                dr_aux.Item("Fecha Vencimiento") = dr.Item("fechahoravencimiento")
                dr_aux.Item("Depto Ventas") = dr.Item("departamentoventas")

                dr_aux.Item("store_number") = dr.Item("store_number").ToString
                dr_aux.Item("type_order") = dr.Item("tipoorden").ToString

                dr_aux.Item("total_original") = dr.Item("total_orden_edi_wm").ToString
                dr_aux.Item("lineas_original") = dr.Item("lineas_orden_edi_wm").ToString



                dr_aux.Item("Observaciones") = ""
                Try
                    dr_aux.Item("porcentaje_descuento") = dr.Item("porcentajedescuento")
                Catch ex As Exception

                End Try


                Try

                    dr_aux.Item("centralizado") = 0
                    dtTipoCentralizado.DefaultView.RowFilter = "codigo = " & dr.Item("tipoorden").ToString
                    If dtTipoCentralizado.DefaultView.Count > 0 Then
                        dr_aux.Item("centralizado") = 1


                        'If dr.Item("ctacte").ToString.Equals("49067552") Then
                        For Each drv2 As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                            dtProductos.DefaultView.RowFilter = "producto = '" & drv2.Item("codigoflex") & "'"
                            If dtProductos.DefaultView.Count > 0 Then
                                Try
                                    drv2.Item("ip") = dtProductos.DefaultView(0).Item("InnerPack")
                                Catch ex As Exception
                                End Try
                            End If
                        Next
                        'End If
                    End If

                Catch ex As Exception

                End Try

                dr_aux.Item("procesado") = False


                Try
                    dtCliente = clGen.selectQuery("FlexLine", "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & dr.Item("ctacte").ToString & "'")
                    If dtCliente.Rows.Count = 1 Then dr_aux.Item("Nombre_Flex") = dtCliente.Rows(0).Item("nombre_cliente").ToString

                Catch ex As Exception

                End Try

                'dt.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte").ToString & "'"
                'If dt.DefaultView.Count = 1 Then dr_aux.Item("Nombre_Flex") = dt.DefaultView(0)("nombre_cliente").ToString

                dr_aux.Item("idempresalocal") = dr.Item("idempresalocal")

                ods.Tables("pedidos").Rows.Add(dr_aux)
            Next

            ods.Tables("pedidos").DefaultView.RowFilter = "procesado = false"
            clGen.Alinear_GridView(ods.Tables("pedidos"), dgv_pedidos,
                                   ",Imprimir,No Pedido,Ctacte,RazonSocial,nombre_flex,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,idempresalocal,type_order,store_number,porcentaje_descuento,total_original,lineas_original,",
                                   ",Total ,", ",No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,", "", "", ",RazonSocial=300,Fecha=80,Fecha Vencimiento=80,", "", True, True, 150, 0)

            Me.dtp_fecha_inicio.CustomFormat = "dd/MM/yyyy"
            Me.dtp_fecha_inicio.Format = DateTimePickerFormat.Custom

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
            coTrans.close()
            coTrans = Nothing
        End Try



        Try
            detalle_pedido(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Pedidos_Pendientes_mysql()
        Dim myoTrans As Transaccional.Conexion_mysql
        Dim clGen As New ClasesGenerales.General
        Dim oTabla, tabla As DataTable
        Dim dt, dtProductos, dtTipoCentralizado As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String
        Dim fecha As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        Dim total_q As Double
        Dim unidades As Integer


        Dim ls_sqltxt As String
        oDataSet = New DataSet

        ods.Tables("pedidos").Rows.Clear()

        Me.dtp_fecha_inicio.CustomFormat = "yyyy-MM-dd"
        Me.dtp_fecha_inicio.Format = DateTimePickerFormat.Custom



        ls_sqltxt = "call pa_sel_um_edi_pedido_encabezado ('" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & " 12:00:00','1')"
        myoTrans = New Transaccional.Conexion_mysql("Umbright")

        dtTipoCentralizado = clGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null,'gen_oc_centralizada','" & gs_empresa & "'")

        Try
            myoTrans.open()
            oTrans.open()
            oTabla = myoTrans.Obtiene(ls_sqltxt)



            ls_sqltxt = "call pa_sel_um_edi_pedido_detalle ('" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & " 12:00:00')"
            tabla = myoTrans.Obtiene(ls_sqltxt)

            tabla.TableName = "detalle_pedidos"

            oDataSet.Tables.Add(tabla.Copy)


            Me.txt_facturas.Text = oTabla.Rows.Count
            dt = oTrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE'")

            dtProductos = oTrans.Obtiene("pa_sel_um_producto '" & gs_empresa & "'")




            For Each dr In oTabla.Rows

                'ls_sql = " pa_sel_um_ctacte_edi_tk '" & gs_empresa & "','" & dr.Item("ctacte") & "'"
                'dt = oTrans.Obtiene(ls_sql)
                total_q = 0
                unidades = 0

                oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"


                Try
                    If oDataSet.Tables("detalle_pedidos").DefaultView.Count = 0 Then

                        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "'"
                    End If
                    ' tengo que validar los totales
                    Dim drvs As DataRowView
                    drvs = oDataSet.Tables("detalle_pedidos").DefaultView(0)


                    For j As Integer = 0 To drvs.DataView.Count - 1

                        'total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precio")
                        total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precioflex")

                        unidades += drvs.DataView(j)("cantidad")

                    Next


                Catch ex As Exception

                End Try

                dr_aux = ods.Tables("pedidos").NewRow
                dr_aux.Item("Imprimir") = 1
                dr_aux.Item("No Pedido") = dr.Item("idtransaccion")
                dr_aux.Item("Ctacte") = dr.Item("ctacte")
                dr_aux.Item("RazonSocial") = dr.Item("nombre")
                dr_aux.Item("Nombre_Flex") = ""
                dr_aux.Item("Total") = Math.Round(total_q, 2)
                dr_aux.Item("Unidades") = unidades
                dr_aux.Item("Fecha") = dr.Item("fechahora")
                dr_aux.Item("Fecha Vencimiento") = dr.Item("fechahoravencimiento")
                dr_aux.Item("Depto Ventas") = dr.Item("departamentoventas")

                dr_aux.Item("store_number") = dr.Item("store_number").ToString
                dr_aux.Item("type_order") = dr.Item("tipoorden").ToString

                dr_aux.Item("total_original") = dr.Item("total_orden_edi_wm").ToString
                dr_aux.Item("lineas_original") = dr.Item("lineas_orden_edi_wm").ToString



                dr_aux.Item("Observaciones") = ""
                Try
                    dr_aux.Item("porcentaje_descuento") = dr.Item("porcentajedescuento")
                Catch ex As Exception

                End Try


                Try

                    dr_aux.Item("centralizado") = 0
                    dtTipoCentralizado.DefaultView.RowFilter = "codigo = " & dr.Item("tipoorden").ToString
                    If dtTipoCentralizado.DefaultView.Count > 0 Then
                        dr_aux.Item("centralizado") = 1


                        'If dr.Item("ctacte").ToString.Equals("49067552") Then
                        For Each drv2 As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                            dtProductos.DefaultView.RowFilter = "producto = '" & drv2.Item("codigoflex") & "'"
                            If dtProductos.DefaultView.Count > 0 Then
                                Try
                                    drv2.Item("ip") = dtProductos.DefaultView(0).Item("InnerPack")
                                Catch ex As Exception
                                End Try
                            End If
                        Next
                        'End If
                    End If

                Catch ex As Exception

                End Try

                dr_aux.Item("procesado") = False

                dt.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte").ToString & "'"
                If dt.DefaultView.Count = 1 Then dr_aux.Item("Nombre_Flex") = dt.DefaultView(0)("nombre_cliente").ToString

                dr_aux.Item("idempresalocal") = dr.Item("idempresalocal")

                ods.Tables("pedidos").Rows.Add(dr_aux)
            Next

            ods.Tables("pedidos").DefaultView.RowFilter = "procesado = false"
            clGen.Alinear_GridView(ods.Tables("pedidos"), dgv_pedidos,
                                   ",Imprimir,No Pedido,Ctacte,RazonSocial,nombre_flex,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,idempresalocal,type_order,store_number,porcentaje_descuento,total_original,lineas_original,",
                                   ",Total ,", ",No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,", "", "", ",RazonSocial=300,Fecha=80,Fecha Vencimiento=80,", "", True, True, 150, 0)

            Me.dtp_fecha_inicio.CustomFormat = "dd/MM/yyyy"
            Me.dtp_fecha_inicio.Format = DateTimePickerFormat.Custom

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing
        myoTrans.close()
        myoTrans = Nothing

        Try
            detalle_pedido(0)
        Catch ex As Exception
        End Try
    End Sub



    Private Sub Pedidos_reimpresion_mysql()
        Dim myoTrans As Transaccional.Conexion_mysql
        Dim clGen As New ClasesGenerales.General
        Dim oTabla, tabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String
        Dim fecha As String
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim ls_sqltxt As String
        Dim total_q As Double
        Dim unidades As Integer
        oDataSet = New DataSet

        ods.Tables("pedidos_reimpresion").Rows.Clear()
        Me.dtp_re_fecha_inicio.CustomFormat = "yyyy-MM-dd"
        Me.dtp_re_fecha_inicio.Format = DateTimePickerFormat.Custom



        ls_sqltxt = "call pa_sel_um_edi_pedido_encabezado ('" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & " 12:00:00','2')"
        myoTrans = New Transaccional.Conexion_mysql("Umbright")

        Try
            myoTrans.open()
            oTrans.open()
            oTabla = myoTrans.Obtiene(ls_sqltxt)
            Me.txt_re_facturas.Text = oTabla.Rows.Count


            ls_sqltxt = "call pa_sel_um_edi_pedido_detalle ('" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & " 12:00:00')"
            tabla = myoTrans.Obtiene(ls_sqltxt)
            tabla.TableName = "detalle_pedidos_reimpresion"

            oDataSet.Tables.Add(tabla.Copy)

            For Each dr In oTabla.Rows

                total_q = 0
                unidades = 0

                'oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"
                oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"

                Try
                    Dim drvs As DataRowView
                    drvs = oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView(0)


                    For j As Integer = 0 To drvs.DataView.Count - 1

                        total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precio")
                        unidades += drvs.DataView(j)("cantidad")

                    Next



                Catch ex As Exception

                End Try







                dr_aux = ods.Tables("pedidos_reimpresion").NewRow
                dr_aux.Item("Imprimir") = 1
                dr_aux.Item("No Pedido") = dr.Item("idtransaccion")
                dr_aux.Item("Ctacte") = dr.Item("ctacte")
                dr_aux.Item("RazonSocial") = dr.Item("nombre")

                dr_aux.Item("Total") = Math.Round(total_q, 2)
                dr_aux.Item("Unidades") = unidades



                dr_aux.Item("Fecha") = dr.Item("fechahora")
                dr_aux.Item("Fecha Vencimiento") = dr.Item("fechahoravencimiento")
                dr_aux.Item("Depto Ventas") = dr.Item("departamentoventas")
                dr_aux.Item("store_number") = dr.Item("store_number").ToString
                dr_aux.Item("type_order") = dr.Item("tipoorden").ToString
                dr_aux.Item("Observaciones") = ""
                dr_aux.Item("idempresalocal") = dr.Item("idempresalocal")
                ods.Tables("pedidos_reimpresion").Rows.Add(dr_aux)
            Next

            'clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Aprobar,Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", "", "", "", "", ",RazonSocial=300,", "", True, True, 150, 0)
            'clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Aprobar,Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", ",Total ,", ",Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", "", "", ",RazonSocial=300,", "", True, True, 150, 0)
            clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Imprimir,No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,idempresalocal,store_number,type_order,", ",Total ,", ",No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,", "", "", ",RazonSocial=300,Fecha=80,Fecha Vencimiento=80,", "", True, True, 150, 0)

            'ls_sqltxt = "call pa_sel_um_edi_pedido_detalle ('" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & " 12:00:00')"
            'oTabla = myoTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "detalle_pedidos_reimpresion"
            'oDataSet.Tables.Add(oTabla.Copy)
            Me.dtp_re_fecha_inicio.CustomFormat = "dd/MM/yyyy"
            Me.dtp_re_fecha_inicio.Format = DateTimePickerFormat.Custom
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing
        myoTrans.close()
        myoTrans = Nothing
        Try
            detalle_pedido_reimpresion(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Pedidos_reimpresion()
        Dim coTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla, tabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String
        Dim fecha As String
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim ls_sqltxt As String
        Dim total_q As Double
        Dim unidades As Integer
        oDataSet = New DataSet

        ods.Tables("pedidos_reimpresion").Rows.Clear()
        'Me.dtp_re_fecha_inicio.CustomFormat = "yyyy-MM-dd"
        'Me.dtp_re_fecha_inicio.Format = DateTimePickerFormat.Custom



        ls_sqltxt = "pa_sel_um_edi_pedido_encabezado '" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & "','2'"
        coTrans = New Transaccional.Conexion("corporativo")

        Try
            coTrans.open()
            oTrans.open()
            oTabla = coTrans.Obtiene(ls_sqltxt)
            Me.txt_re_facturas.Text = oTabla.Rows.Count


            ls_sqltxt = "pa_sel_um_edi_pedido_detalle '" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & "'"
            tabla = coTrans.Obtiene(ls_sqltxt)
            tabla.TableName = "detalle_pedidos_reimpresion"

            oDataSet.Tables.Add(tabla.Copy)

            For Each dr In oTabla.Rows

                total_q = 0
                unidades = 0

                'oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"
                oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView.RowFilter = "No_Pedido= '" & dr.Item("idtransaccion") & "' and idempresalocal= '" & dr.Item("idempresalocal") & "'"

                Try
                    Dim drvs As DataRowView
                    drvs = oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView(0)


                    For j As Integer = 0 To drvs.DataView.Count - 1

                        total_q += drvs.DataView(j)("cantidad") * drvs.DataView(j)("precio")
                        unidades += drvs.DataView(j)("cantidad")

                    Next



                Catch ex As Exception

                End Try







                dr_aux = ods.Tables("pedidos_reimpresion").NewRow
                dr_aux.Item("Imprimir") = 1
                dr_aux.Item("No Pedido") = dr.Item("idtransaccion")
                dr_aux.Item("Ctacte") = dr.Item("ctacte")
                dr_aux.Item("RazonSocial") = dr.Item("nombre")

                dr_aux.Item("Total") = Math.Round(total_q, 2)
                dr_aux.Item("Unidades") = unidades



                dr_aux.Item("Fecha") = dr.Item("fechahora")
                dr_aux.Item("Fecha Vencimiento") = dr.Item("fechahoravencimiento")
                dr_aux.Item("Depto Ventas") = dr.Item("departamentoventas")
                dr_aux.Item("store_number") = dr.Item("store_number").ToString
                dr_aux.Item("type_order") = dr.Item("tipoorden").ToString
                dr_aux.Item("Observaciones") = ""
                dr_aux.Item("idempresalocal") = dr.Item("idempresalocal")
                ods.Tables("pedidos_reimpresion").Rows.Add(dr_aux)
            Next

            'clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Aprobar,Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", "", "", "", "", ",RazonSocial=300,", "", True, True, 150, 0)
            'clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Aprobar,Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", ",Total ,", ",Idtransaccion,Ctacte,RazonSocial,Total,Fecha,Observaciones,", "", "", ",RazonSocial=300,", "", True, True, 150, 0)
            clGen.Alinear_GridView(ods.Tables("pedidos_reimpresion"), dgv_pedidos_reimpresion, ",Imprimir,No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,idempresalocal,store_number,type_order,", ",Total ,", ",No Pedido,Ctacte,RazonSocial,Total,Unidades,Fecha,Fecha Vencimiento,Depto Ventas,Observaciones,", "", "", ",RazonSocial=300,Fecha=80,Fecha Vencimiento=80,", "", True, True, 150, 0)

            'ls_sqltxt = "call pa_sel_um_edi_pedido_detalle ('" & gs_empresa & "','" & Me.dtp_re_fecha_inicio.Text & " 12:00:00')"
            'oTabla = myoTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "detalle_pedidos_reimpresion"
            'oDataSet.Tables.Add(oTabla.Copy)
            'Me.dtp_re_fecha_inicio.CustomFormat = "dd/MM/yyyy"
            'Me.dtp_re_fecha_inicio.Format = DateTimePickerFormat.Custom
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing
        coTrans.close()
        coTrans = Nothing
        Try
            detalle_pedido_reimpresion(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)

        'Dim ls_resultado As String
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dgv_pedidos.Item("No pedido", pi_RowNumber).Value & "' and idempresalocal = '" & dgv_pedidos.Item("idempresalocal", pi_RowNumber).Value & "'"
        Me.dgv_detalle.DataSource = oDataSet.Tables("detalle_pedidos")
        Me.dgv_pedidos.Refresh()

        If Me.dgv_pedidos.Item("centralizado", pi_RowNumber).Value.ToString.Equals("1") Then
            clgen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgv_detalle,
                ",no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,cantidad_facturar,ip,", "", ",no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,", "", ",precio=precio_WM,ip=Inner Pack,",
                ",descripcionflex=180,", ",no_pedido,sku,codigoflex,descripcionflex,precio,precioflex,ip,uxc,cantidad,cantidad_facturar,", True, True, 200, 0)
        Else

            clgen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgv_detalle,
                ",no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,cantidad_facturar,", "", ",no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,", "", ",precio=precio_WM,",
                ",descripcionflex=180,", ",no_pedido,sku,codigoflex,descripcionflex,precio,precioflex,uxc,cantidad,cantidad_facturar,", True, True, 200, 0)
        End If
        clgen = Nothing
        Me.dgv_pedidos.Refresh()

    End Sub

    Private Sub detalle_pedido_reimpresion(ByVal pi_RowNumber As Integer)
        Dim clgen As New ClasesGenerales.General
        oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView.RowFilter = "No_pedido= '" & dgv_pedidos_reimpresion.Item("No pedido", pi_RowNumber).Value & "'  and idempresalocal = '" & dgv_pedidos_reimpresion.Item("idempresalocal", pi_RowNumber).Value & "'"
        'oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & dgv_pedidos.Item("No pedido", pi_RowNumber).Value & "'  and idempresalocal = '" & dgv_pedidos.Item("idempresalocal", pi_RowNumber).Value & "'"
        Me.dgv_detalle_reimpresion.DataSource = oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView
        'Me.dgv_pedidos_reimpresion.Refresh()

        clgen.Alinear_GridView(oDataSet.Tables("detalle_pedidos_reimpresion").DefaultView.ToTable, dgv_detalle_reimpresion, "", "", "", "", "", "", "", True, True, 200, 0)
        clgen = Nothing
        'Me.dgv_pedidos_reimpresion.Refresh()

    End Sub
    Private Sub crear_estructura()
        Dim dt, dt2 As DataTable
        ods = New DataSet
        dt = New DataTable("pedidos")
        dt2 = New DataTable("pedidos_reimpresion")

        dt.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("No Pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("Ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Flex", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha Vencimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("Depto Ventas", GetType(String)))
        dt.Columns.Add(New DataColumn("store_number", GetType(String)))
        dt.Columns.Add(New DataColumn("type_order", GetType(String)))
        dt.Columns.Add(New DataColumn("procesado", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("idempresalocal", GetType(String)))
        dt.Columns.Add(New DataColumn("centralizado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_original", GetType(Double)))
        dt.Columns.Add(New DataColumn("lineas_original", GetType(Integer)))
        dt.Columns.Add(New DataColumn("porcentaje_descuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("Observaciones", GetType(String)))


        ods.Tables.Add(dt)
        Me.dgv_pedidos.DataSource = ods.Tables("pedidos").DefaultView


        'dt2.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        'dt2.Columns.Add(New DataColumn("No Pedido", GetType(String)))
        'dt2.Columns.Add(New DataColumn("Ctacte", GetType(String)))
        'dt2.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        'dt2.Columns.Add(New DataColumn("Total", GetType(String)))
        'dt2.Columns.Add(New DataColumn("Fecha", GetType(String)))
        'dt2.Columns.Add(New DataColumn("Observaciones", GetType(String)))
        dt2.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt2.Columns.Add(New DataColumn("No Pedido", GetType(String)))
        dt2.Columns.Add(New DataColumn("Ctacte", GetType(String)))
        dt2.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt2.Columns.Add(New DataColumn("Nombre_Flex", GetType(String)))
        dt2.Columns.Add(New DataColumn("Total", GetType(String)))
        dt2.Columns.Add(New DataColumn("Unidades", GetType(String)))
        dt2.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt2.Columns.Add(New DataColumn("Fecha Vencimiento", GetType(String)))
        dt2.Columns.Add(New DataColumn("Depto Ventas", GetType(String)))
        dt2.Columns.Add(New DataColumn("store_number", GetType(String)))
        dt2.Columns.Add(New DataColumn("type_order", GetType(String)))
        dt2.Columns.Add(New DataColumn("Observaciones", GetType(String)))
        dt2.Columns.Add(New DataColumn("idempresalocal", GetType(String)))
        dt2.Columns.Add(New DataColumn("porcentaje_descuento", GetType(Double)))
        dt2.Columns.Add(New DataColumn("total_original", GetType(Double)))
        dt2.Columns.Add(New DataColumn("lineas_original", GetType(Integer)))
        ods.Tables.Add(dt2)
        Me.dgv_pedidos_reimpresion.DataSource = ods.Tables("pedidos_reimpresion")
    End Sub

    Private Sub ProcesarPedido_Old(ByVal nPedido As String, ByVal ncliente As String)

        'Dim dtDetalle As DataSet
        Dim dtCliente, dt As DataTable
        Dim lbProcesarPedido As Boolean = False
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim myOTrans As New Transaccional.Conexion_mysql("Onbase")
        Dim lsSQL, lsNumeroPedido As String
        Dim iNumeroPedido As Integer
        Dim dPrecioUnitario As Double
        Dim oFlex As New Umbral_Flex.productos
        Dim lbPedidoCentralizado As Boolean


        Try
            lbPedidoCentralizado = Me.dgv_pedidos.Item("centralizado", Me.dgv_pedidos.CurrentRow.Index).Value
            oTrans.open()
            myOTrans.open()

            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & nPedido & "' and idempresalocal= '" & ncliente & "'"
            lbProcesarPedido = True
            ''Primero Hago Validaciones
            ''TotalizoUnidades
            Dim iTotalUnidades As Integer = 0
            If Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString.Length > 0 Then

                For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                    If drv.Item("descripcionFlex").ToString.Trim.Length = 0 Then
                        If drv.Item("cantidad_facturar") > 0 Then
                            lbProcesarPedido = False
                            MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Asociar " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'ElseIf Abs(drv.Item("precio") - drv.Item("precioflex")) > 0.01 Then '(c) 030712 Albin Rivas pidio que se liberar
                        '    lbProcesarPedido = False
                        '    MessageBox.Show("Este Pedido No se Procesara Por que Tiene Diferencia de Precios " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK)

                    End If
                    '(c) 28052015 Todo Producto de Pedido Centralizado debe tener Inner Pack

                    If lbPedidoCentralizado Then
                        Try
                            If drv.Item("ip") < 1 Then
                                lbProcesarPedido = False
                                MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Inner Pack " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        Catch ex As Exception
                            MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Inner Pack " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK)
                            lbProcesarPedido = False
                        End Try
                    End If
                    iTotalUnidades += drv.Item("cantidad_facturar")
                Next

                If iTotalUnidades = 0 Then
                    lbProcesarPedido = False
                    MessageBox.Show("No Se Procesara El Pedido" & Chr(13) & "No Hay Productos a Facturar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                If lbProcesarPedido Then
                    'Me.dgv_pedidos.Item("No Pedido", Me.dgv_pedidos.CurrentRow.Index).Value

                    dtCliente = oTrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" &
                    Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString & "'")
                    'CodigoCliente = Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString
                    'lsNumeroPedido = Now.ToString("ddMMyyyyHHmm")
                    lsNumeroPedido = nPedido 'Se tomara el numero de la OC

                    lsSQL = "call pa_ins_um_mov_pedidos_encabezado_walmart ('" &
                      gs_empresa.ToUpper & "','" & lsNumeroPedido & "','" &
                      dtCliente.Rows(0).Item("ctacte") & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                      "0,0,'" &
                     Now.ToString("yyyy-MM-dd HH:mm") & "','" &
                     Today.ToString("yyyy-MM-dd") & "','"

                    lsSQL += "1900-01-01','"

                    lsSQL += "EDI OC " & nPedido & " " & Me.txtComentarios.Text & "','" &
                            gs_usuario & "',1,'" &
                            dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                            Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'" &
                         ncliente & "')"  'ncliente trae la informacion del cliente edifact

                    myOTrans.Ingresa(lsSQL)

                    If myOTrans.Codigo_error = 0 Then
                        dt = myOTrans.Obtiene("SELECT @@IDENTITY AS NewID")
                        iNumeroPedido = dt.Rows(0).Item("newid").ToString

                        Dim iLinea As Integer = 0
                        For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                            If drv.Item("cantidad_facturar") > 0 Then
                                iLinea += 1
                                dt = oFlex.Obtener_Precio_Final(gs_empresa, drv.Item("codigoFlex"), dtCliente.Rows(0).Item("ctacte"))
                                Try
                                    dPrecioUnitario = dt.Rows(0).Item("valor")
                                Catch ex As Exception
                                    dPrecioUnitario = 0
                                End Try

                                lsSQL = "call pa_ins_um_mov_pedidos_detalle_walmart (" &
                                    iNumeroPedido & "," &
                                    iLinea & ",'" & drv.Item("codigoFlex").ToString & "'," &
                                    drv.Item("cantidad_facturar") & "," & dPrecioUnitario & "," &
                                      dPrecioUnitario * drv.Item("cantidad_facturar") & ",'" &
                                    drv.Item("dun14") & "','" & drv.Item("sku") & "','','" &
                                    drv.Item("gtin") & "','" & drv.Item("ref") & "','EA')"

                                myOTrans.Ingresa(lsSQL)
                                If myOTrans.Codigo_error > 0 Then
                                    'lbExitoso = False
                                End If
                            End If
                        Next

                        lsSQL = "call pa_upd_mov_pedidos_encabezado_cell (" & iNumeroPedido & ")"
                        myOTrans.Actualiza(lsSQL)

                    End If



                    'Imprimir_Ordenes(nPedido) (c)07092012 Autorizado por Jose Fernando Lopez
                    actualizar_estado(nPedido, ncliente)
                    If Me.dgv_pedidos.Item("no pedido", Me.dgv_pedidos.CurrentRow.Index).Value.ToString = nPedido Then
                        Me.dgv_pedidos.Item("procesado", Me.dgv_pedidos.CurrentRow.Index).Value = True
                    End If
                    MessageBox.Show("Pedido Procesado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComentarios.Text = String.Empty

                End If
            Else
                MessageBox.Show("El Pedido No tiene Cliente Asociado", "Verificar", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            myOTrans.close()
            myOTrans = Nothing
            oFlex.close()
            oFlex = Nothing
        End Try
    End Sub


    Private Sub ProcesarPedido(ByVal nPedido As String, ByVal ncliente As String)

        'Dim dtDetalle As DataSet
        Dim dtCliente, dt As DataTable
        Dim lbProcesarPedido As Boolean = False
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim cOTrans As New Transaccional.Conexion("Corporativo")
        Dim lsSQL, lsNumeroPedido As String
        Dim iNumeroPedido As Integer
        Dim dPrecioUnitario As Double
        Dim oFlex As New Umbral_Flex.productos
        Dim lbPedidoCentralizado As Boolean


        Try
            lbPedidoCentralizado = Me.dgv_pedidos.Item("centralizado", Me.dgv_pedidos.CurrentRow.Index).Value
            oTrans.open()
            cOTrans.open()

            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "No_Pedido= '" & nPedido & "' and idempresalocal= '" & ncliente & "'"
            lbProcesarPedido = True
            ''Primero Hago Validaciones
            ''TotalizoUnidades
            Dim iTotalUnidades As Integer = 0
            If Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString.Length > 0 Then

                For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                    If drv.Item("descripcionFlex").ToString.Trim.Length = 0 Then
                        If drv.Item("cantidad_facturar") > 0 Then
                            lbProcesarPedido = False
                            MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Asociar " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'ElseIf Abs(drv.Item("precio") - drv.Item("precioflex")) > 0.01 Then '(c) 030712 Albin Rivas pidio que se liberar
                        '    lbProcesarPedido = False
                        '    MessageBox.Show("Este Pedido No se Procesara Por que Tiene Diferencia de Precios " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK)

                    End If
                    '(c) 28052015 Todo Producto de Pedido Centralizado debe tener Inner Pack

                    If lbPedidoCentralizado Then
                        Try
                            If drv.Item("ip") < 1 Then
                                lbProcesarPedido = False
                                MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Inner Pack " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        Catch ex As Exception
                            MessageBox.Show("Este Pedido No se Procesara Por que Tiene Productos Sin Inner Pack " & Chr(13) & drv.Item("SKU"), "Verificar", MessageBoxButtons.OK)
                            lbProcesarPedido = False
                        End Try
                    End If
                    iTotalUnidades += drv.Item("cantidad_facturar")
                Next

                If iTotalUnidades = 0 Then
                    lbProcesarPedido = False
                    MessageBox.Show("No Se Procesara El Pedido" & Chr(13) & "No Hay Productos a Facturar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                If lbProcesarPedido Then
                    'Me.dgv_pedidos.Item("No Pedido", Me.dgv_pedidos.CurrentRow.Index).Value

                    dtCliente = oTrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" &
                    Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString & "'")
                    'CodigoCliente = Me.dgv_pedidos.Item("ctacte", Me.dgv_pedidos.CurrentRow.Index).Value.ToString
                    'lsNumeroPedido = Now.ToString("ddMMyyyyHHmm")
                    lsNumeroPedido = nPedido 'Se tomara el numero de la OC

                    lsSQL = "pa_ins_um_mov_pedidos_encabezado_walmart '" &
                      gs_empresa.ToUpper & "','" & lsNumeroPedido & "','" &
                      dtCliente.Rows(0).Item("ctacte") & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                      "0,0,'" &
                     Today.ToString("dd-MM-yyyy HH:mm") & "','" &
                     Today.ToString("dd-MM-yyyy") & "','"

                    lsSQL += "01-01-1900','"

                    lsSQL += "EDI OC " & nPedido & " " & Me.txtComentarios.Text & "','" &
                            gs_usuario & "',1,'" &
                            dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                            Now.ToString("dd-MM-yyyy HH:mm:ss") & "',NULL,'" &
                         ncliente & "'"  'ncliente trae la informacion del cliente edifact

                    cOTrans.Ingresa(lsSQL)

                    If cOTrans.Codigo_error = 0 Then
                        dt = cOTrans.Obtiene("SELECT @@IDENTITY AS NewID")
                        iNumeroPedido = dt.Rows(0).Item("newid").ToString

                        Dim iLinea As Integer = 0
                        For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                            If drv.Item("cantidad_facturar") > 0 Then
                                iLinea += 1
                                dt = oFlex.Obtener_Precio_Final(gs_empresa, drv.Item("codigoFlex"), dtCliente.Rows(0).Item("ctacte"))
                                Try
                                    dPrecioUnitario = dt.Rows(0).Item("valor")
                                Catch ex As Exception
                                    dPrecioUnitario = 0
                                End Try

                                lsSQL = "pa_ins_um_mov_pedidos_detalle_walmart " &
                                    iNumeroPedido & "," &
                                    iLinea & ",'" & drv.Item("codigoFlex").ToString & "'," &
                                    drv.Item("cantidad_facturar") & "," & dPrecioUnitario & "," &
                                      dPrecioUnitario * drv.Item("cantidad_facturar") & ",'" &
                                    drv.Item("dun14") & "','" & drv.Item("sku") & "','','" &
                                    drv.Item("gtin") & "','" & drv.Item("ref") & "','EA'"

                                cOTrans.Ingresa(lsSQL)
                                If cOTrans.Codigo_error > 0 Then
                                    'lbExitoso = False
                                End If
                            End If
                        Next

                        lsSQL = "pa_upd_mov_pedidos_encabezado_valores " & iNumeroPedido & ""
                        cOTrans.Actualiza(lsSQL)

                    End If



                    'Imprimir_Ordenes(nPedido) (c)07092012 Autorizado por Jose Fernando Lopez
                    actualizar_estado(nPedido, ncliente)

                    lsSQL = "pa_upd_um_edi_pedido_encabezado '" & gs_empresa & "','" & nPedido & "'"
                    cOTrans.Actualiza(lsSQL)

                    If Me.dgv_pedidos.Item("no pedido", Me.dgv_pedidos.CurrentRow.Index).Value.ToString = nPedido Then
                        Me.dgv_pedidos.Item("procesado", Me.dgv_pedidos.CurrentRow.Index).Value = True
                    End If
                    MessageBox.Show("Pedido Procesado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComentarios.Text = String.Empty

                End If
            Else
                MessageBox.Show("El Pedido No tiene Cliente Asociado", "Verificar", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            cOTrans.close()
            cOTrans = Nothing
            oFlex.close()
            oFlex = Nothing
        End Try
    End Sub


    'Private Function Subir_Pedido_Temporal_Celular(ByVal archivoXML As String)
    '    Dim ods As New DataSet
    '    Dim dr_encabezado As DataRow
    '    Dim numero_pedido As Integer = -1
    '    Dim dt As DataTable
    '    Dim ls_sql As String
    '    Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
    '    Dim Otrans As New Transaccional.Conexion("FlexLine")
    '    Dim oFlex As New Umbral_Flex.productos("FlexLine")
    '    Dim dFecha_Creacion_Archivo As DateTime
    '    Dim dtCliente As DataTable
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim CodigoCliente As Integer
    '    Dim encabezado(), detalle(), linea() As String
    '    Dim precio_unitario As Double
    '    Dim lbExitoso As Boolean = True


    '    Try
    '        myOtrans.open()
    '        Otrans.open()
    '        ods.ReadXml(archivoXML)
    '        dr_encabezado = ods.Tables("encabezado").Rows(0)




    '        Dim Archivo As New FileInfo(archivoXML)
    '        dFecha_Creacion_Archivo = Archivo.CreationTime


    '        With dr_encabezado

    '            encabezado = .Item("encabezado_pedido").ToString.Split("|")


    '            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & encabezado(2) & "','CLIENTE','" & encabezado(1) & "'")
    '            CodigoCliente = encabezado(1)

    '            '       Guardar_Sincronizacion(encabezado(3), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), 1, 1)

    '            ''Guardar 
    '            ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" & _
    '                     encabezado(2).ToString.ToUpper & "','" & encabezado(0).ToString & "','" & _
    '                     encabezado(1).ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," & _
    '                     "0,0,'" & _
    '                    DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm") & "','" & _
    '                    DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd") & "','"

    '            ls_sql += "1900-01-01','"

    '            ls_sql += "Cell " & encabezado(4).Replace("ENT", " Entregar ").Replace("OC", "Orden de Compra ") & "','" & _
    '                    encabezado(3).ToString & "',1,'" & _
    '                    dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" & _
    '                    dFecha_Creacion_Archivo.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL)"


    '            myOtrans.Ingresa(ls_sql)

    '            If myOtrans.Codigo_error = 0 Then
    '                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
    '                numero_pedido = dt.Rows(0).Item("newid").ToString
    '                For icount As Integer = 1 To 8

    '                    If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
    '                        detalle = .Item("detalle" & icount.ToString).ToString.Split(":")
    '                    Else
    '                        detalle = Nothing
    '                    End If


    '                    If Not detalle Is Nothing Then


    '                        For Each lineas As String In detalle
    '                            linea = lineas.Split("|")
    '                            If linea.Length > 1 Then
    '                                dt = oFlex.Obtener_Precio_Final(linea(4), linea(1), CodigoCliente)
    '                                Try
    '                                    precio_unitario = dt.Rows(0).Item("valor")
    '                                Catch ex As Exception
    '                                    precio_unitario = 0
    '                                End Try
    '                                If linea(0).StartsWith(encabezado(0).ToString) Then
    '                                    ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," & _
    '                                                      linea(3) & ",'" & linea(1).ToString & "'," & _
    '                                                      linea(2) & "," & precio_unitario & "," & _
    '                                                      precio_unitario * linea(2) & ")"

    '                                    myOtrans.Ingresa(ls_sql)
    '                                    If myOtrans.Codigo_error > 0 Then
    '                                        lbExitoso = False
    '                                    End If
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                Next


    '                ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
    '                myOtrans.Actualiza(ls_sql)


    '                Guardar_LogVisita_Umbright_EE(encabezado(2).ToString.ToUpper, encabezado(3).ToString, _
    '                encabezado(1).ToString, encabezado(0).ToString, DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), _
    '                    myOtrans)

    '            End If
    '        End With
    '        If numero_pedido > 0 And lbExitoso Then
    '            ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
    '        End If


    '    Catch ex As Exception
    '    Finally
    '        oFlex.close()
    '        oFlex = Nothing
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        Otrans.close()
    '        Otrans = Nothing
    '        ClsGen = Nothing
    '    End Try
    '    Return lbExitoso
    'End Function

    Private Sub frm_pedidos_pendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()
        Me.dtp_fecha_inicio.Value = Today.AddDays(-1)
    End Sub

    Private Sub dgv_pedidos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_pedidos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                'therow = Me.dgv_pedidos.Rows(rowIndex)

                If Me.dgv_pedidos.Item("centralizado", rowIndex).Value = 1 Then

                    Me.dgv_pedidos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Purple


                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgv_pedidos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pedidos.CurrentCellChanged
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgv_pedidos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_pedidos.MouseClick
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Imprimir_Ordenes_pdf(ByVal idtransaccion As String, ByVal cliente As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General


        Try

                pm_conexion = ClsGen.Parametros_Conexion("")
                path_reporte = ClsGen.Path_Reporte()
                'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
                path_reporte += "Direccion Comercial\edifact.rpt"
            pm_parametros(0) = "@empresa"
            pm_parametros(1) = "@cod_pedido"
            pm_parametros(2) = "@cliente"

            pm_valores(0) = gs_empresa
                pm_valores(1) = idtransaccion
                pm_valores(2) = cliente


                pm_valores(0) = gs_empresa
            pm_valores(1) = idtransaccion
            pm_valores(2) = cliente

            'pm_parametros(1) = "Numero de Documento"
            'pm_valores(0) = gs_empresa
            'pm_valores(1) = Me.lbl_numero.Text


            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                False, True, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                           True, False, "PDF", False, "", True)
        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Public Sub Imprimir_Ordenes(ByVal idtransaccion As String, ByVal cliente As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Direccion Comercial\edifact.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "cod_pedido"
            pm_parametros(2) = "cliente"

            pm_valores(0) = gs_empresa
            pm_valores(1) = idtransaccion
            pm_valores(2) = cliente



            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)


        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Private Sub actualizar_estado(ByVal transaccion As String, ByVal cliente As String)


        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion_mysql("onbase")


        Try
            oTrans.open()

            If cliente.ToString.Length > 0 Then
                ls_sql = "call pa_up_um_edi_pedido_encabezado_varios('" & gs_empresa & "','" & transaccion & "','" & cliente & "')"
            Else
                ls_sql = "call pa_up_um_edi_pedido_encabezado ('" & gs_empresa & "','" & transaccion & "')"
            End If



            oTrans.Actualiza(ls_sql)

        Catch ex As Exception
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try
    End Sub
    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        Dim conteo As Integer = 0

        For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1
            If dgv_pedidos.Item("Imprimir", jj).Value = True Then
                conteo = conteo + 1
            End If

        Next

        If MessageBox.Show("Esta seguro de Imprimir " & conteo & " Ordenes", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1

                If dgv_pedidos.Item("Imprimir", jj).Value = True Then
                    Imprimir_Ordenes(dgv_pedidos.Item("No pedido", jj).Value, dgv_pedidos.Item("idempresalocal", jj).Value)
                    actualizar_estado(dgv_pedidos.Item("No pedido", jj).Value, dgv_pedidos.Item("idempresalocal", jj).Value)
                End If


            Next
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Pedidos_Pendientes()
    End Sub

    Private Sub btn_re_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_re_generar.Click
        Pedidos_reimpresion()

    End Sub



    Private Sub dgv_pedidos_reimpresion_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pedidos_reimpresion.CurrentCellChanged
        Try
            detalle_pedido_reimpresion(Me.dgv_pedidos_reimpresion.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub dgv_pedidos_reimpresion_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_pedidos_reimpresion.MouseClick
        Try
            detalle_pedido_reimpresion(Me.dgv_pedidos_reimpresion.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conteo As Integer = 0



        ods.Tables("pedidos_reimpresion").DefaultView.RowFilter = "imprimir = true"




        'For jj As Integer = 0 To dgv_pedidos_reimpresion.Rows.Count - 1
        '    If dgv_pedidos_reimpresion.Item("Imprimir", jj).Value = True Then
        '        conteo = conteo + 1
        '    End If

        'Next



        If MessageBox.Show("Esta seguro de Re-Imprimir " &
                ods.Tables("pedidos_reimpresion").DefaultView.Count &
         " Ordenes", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'conteo & " Ordenes", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            For Each drv As DataRowView In ods.Tables("pedidos_reimpresion").DefaultView
                Imprimir_Ordenes(drv.Item("No pedido").ToString, drv.Item("idempresalocal").ToString)
            Next

            'For jj As Integer = 0 To dgv_pedidos_reimpresion.Rows.Count - 1
            '    If dgv_pedidos_reimpresion.Item("Imprimir", jj).Value = True Then
            '        Imprimir_Ordenes(dgv_pedidos_reimpresion.Item("Imprimir", jj).Value)
            '    End If
            'Next
            'MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ods.Tables("pedidos_reimpresion").DefaultView.RowFilter = ""
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conteo As Integer = 0

        For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1
            If dgv_pedidos.Item("Imprimir", jj).Value = True Then
                conteo = conteo + 1
            End If

        Next

        If MessageBox.Show("Esta seguro de Imprimir " & conteo & " Ordenes a PDF", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1

                If dgv_pedidos.Item("Imprimir", jj).Value = True Then
                    Imprimir_Ordenes_pdf(dgv_pedidos.Item("No pedido", jj).Value, dgv_pedidos.Item("idempresalocal", jj).Value)
                    actualizar_estado(dgv_pedidos.Item("No pedido", jj).Value, dgv_pedidos.Item("idempresalocal", jj).Value)
                End If


            Next
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim conteo As Integer = 0

        For jj As Integer = 0 To dgv_pedidos_reimpresion.Rows.Count - 1
            If dgv_pedidos_reimpresion.Item("Imprimir", jj).Value = True Then
                conteo = conteo + 1
            End If

        Next

        If MessageBox.Show("Esta seguro de Imprimir " & conteo & " Ordenes a PDF", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For jj As Integer = 0 To dgv_pedidos_reimpresion.Rows.Count - 1

                If dgv_pedidos_reimpresion.Item("Imprimir", jj).Value = True Then
                    Imprimir_Ordenes_pdf(dgv_pedidos_reimpresion.Item("No pedido", jj).Value, dgv_pedidos_reimpresion.Item("idempresalocal", jj).Value)
                    'actualizar_estado(dgv_pedidos_reimpresion.Item("No pedido", jj).Value)
                End If


            Next
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub dgv_detalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting

        'no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,cantidad_facturar,
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try


            'Me.dg_productos.Columns("vigente").Visible = True
            If rowIndex >= 0 And colIndex = 0 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_detalle.Rows(rowIndex)
                'If therow.Cells("codigoflex").Value = "0200060334" Then
                '    therow.Cells("codigoflex").Value = "0200060334"
                'End If
                If therow.Cells("precioflex").Value = 0 And therow.Cells("precio").Value > 0 Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                ElseIf therow.Cells("precio").Value - therow.Cells("precioflex").Value < -0.01 Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf therow.Cells("precio").Value - therow.Cells("precioflex").Value > 0.01 Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                End If

            End If
            'Me.dg_productos.Columns(0).Width = 10
            'Me.dg_productos.Columns("vigente").Visible = False
        Catch ex As Exception
        End Try


    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgv_detalle_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_detalle.DataError
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow
        Try

            therow = Me.dgv_detalle.Rows(rowIndex)

            therow.Cells("cantidad_facturar").Value = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_detalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)
                If (",cantidad_facturar,").IndexOf(Me.dgv_detalle.Columns(colIndex).Name.ToLower) > -1 Then
                    If therow.Cells("cantidad").Value < 0 Then
                        therow.Cells("cantidad_facturar").Value = 0
                    ElseIf therow.Cells("cantidad").Value < therow.Cells("cantidad_facturar").Value Then
                        therow.Cells("cantidad_facturar").Value = therow.Cells("cantidad").Value
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        Try
            If MessageBox.Show("Esta Seguro de Continuar con el Pedido " & _
                       Me.dgv_pedidos.Item("No Pedido", Me.dgv_pedidos.CurrentRow.Index).Value, _
                       "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ProcesarPedido(Me.dgv_pedidos.Item("No Pedido", Me.dgv_pedidos.CurrentRow.Index).Value, Me.dgv_pedidos.Item("idempresalocal", Me.dgv_pedidos.CurrentRow.Index).Value)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_pedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pedidos.CellContentClick

    End Sub

    Private Sub dgv_pedidos_reimpresion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pedidos_reimpresion.CellContentClick

    End Sub

    Private Sub btnCentralizadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentralizadas.Click
        pedidosPendientesCentralizado()
    End Sub

    Private Sub pedidosPendientesCentralizado()
        'Dim oTrans As Transaccional.Conexion
        'Dim oTabla As DataTable
        Dim dt, dtExistencias As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView

        Dim ls_sqltxt As String
        Dim ls_filtro As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General
        oDataSet = New DataSet
        'Limpiar_Bindings()


        Dim oTrans As New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            ls_sqltxt = "pa_var_um_pedidos_pendientes_facturar '" & Me.dtpInicioCentralizado.Text & "','" & Me.dtpFinalCentralizado.Text & "',100"

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "pedidos"
            oDataSet.Tables.Add(dt.Copy)

            ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = oTrans.Obtiene(ls_sqltxt)

            ls_filtro = ""

            oDataSet.Tables("pedidos").DefaultView.RowFilter = "cliente = '49067552'"

            Me.dgvEncabezadoCentralizado.DataSource = oDataSet.Tables("pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("pedidos"), dgvEncabezadoCentralizado, "", ",limitecredito,vigencia,Comentario_Cliente,Aprobacion,", "", "", "", "", "", True, True, 250, 0)

            'Colorear_Grid()
            ls_sqltxt = "pa_var_um_existencias_producto '" & gs_empresa & "',null,'CD_CENTRAL'"
            dtExistencias = oTrans.Obtiene(ls_sqltxt)

            ls_sqltxt = "pa_var_um_detalle_pedidos_pendientes_facturar '" & Me.dtpInicioCentralizado.Text & "','" & Me.dtpFinalCentralizado.Text & "',100"

            dt = oTrans.Obtiene(ls_sqltxt)
            dt.TableName = "detalle_pedidos"
            dt.Columns.Add(New DataColumn("existenciaCD", GetType(Integer)))
            dt.Columns.Add(New DataColumn("sugerido", GetType(Integer)))
            dt.Columns.Add(New DataColumn("pedido", GetType(Integer)))
            dt.Columns.Add(New DataColumn("procesar", GetType(Boolean)))
            For Each dr2 As DataRow In dt.Rows
                dr2.Item("existenciaCD") = 0
                dr2.Item("procesar") = False
                dtExistencias.DefaultView.RowFilter = "producto = '" & dr2.Item("producto") & "'"
                If dtExistencias.DefaultView.Count = 1 Then
                    dr2.Item("existenciaCD") = dtExistencias.DefaultView(0).Item("Existencia")

                End If

                If dr2.Item("cantidadAsignada") = 0 Then
                    If dr2.Item("ExistenciaCD") >= dr2.Item("Cantidad") Then
                        dr2.Item("pedido") = dr2.Item("Cantidad")
                        dr2.Item("sugerido") = dr2.Item("Cantidad")
                    ElseIf dr2.Item("ExistenciaCD") = 0 Then
                        dr2.Item("sugerido") = 0
                        dr2.Item("pedido") = 0
                    End If
                ElseIf dr2.Item("cantidadAsignada") <> dr2.Item("Cantidad") Then
                    If dr2.Item("ExistenciaCD") = 0 Then
                        dr2.Item("sugerido") = 0
                        dr2.Item("pedido") = 0
                    ElseIf dr2.Item("ExistenciaCD") >= dr2.Item("Cantidad") - dr2.Item("cantidadAsignada") Then
                        ''sugerido

                        dr2.Item("pedido") = dr2.Item("Cantidad") - dr2.Item("cantidadAsignada")
                        dr2.Item("sugerido") = dr2.Item("Cantidad") - dr2.Item("cantidadAsignada")

                    End If
                ElseIf dr2.Item("cantidad") = dr2.Item("cantidadAsignada") Then
                    dr2.Item("sugerido") = 0
                    dr2.Item("pedido") = 0
                End If

            Next

            oDataSet.Tables.Add(dt.Copy)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

        mostrarDetalleCentralizado()
    End Sub

    Private Sub mostrarDetalleCentralizado()
        Try
            Dim li_row_number As Integer
            li_row_number = Me.dgvEncabezadoCentralizado.CurrentRow.Index

            'Try
            '    Me.txt_total_pedido.DataBindings.Add("text", oDataSet.Tables("pedidos"), "total")
            '    Me.txt_comentario.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario1")

            '    If Not lpedidos_posfechados Then
            '        Me.cmb_estados.DataBindings.Add("SelectedValue", oDataSet.Tables("pedidos"), "Aprobacion")
            '    Else
            '        Me.dtp_fecha_Entrega.DataBindings.Add("text", oDataSet.Tables("pedidos"), "FechaEntrega")
            '    End If

            '    Me.txtComentario2.DataBindings.Add("text", oDataSet.Tables("pedidos"), "comentario2")
            'Catch ex As Exception
            'End Try

            detalleCentralizado(li_row_number)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub detalleCentralizado(ByVal nRow As Integer)
        Dim ClsGen As New ClasesGenerales.General

        Try

            Dim ls_resultado, tipo_docto As String
            Dim ls_filtro, ls_empresa As String

            ls_resultado = Me.dgvEncabezadoCentralizado.Item("numero", nRow).Value
            tipo_docto = Me.dgvEncabezadoCentralizado.Item("tipodocto", nRow).Value
            ls_empresa = Me.dgvEncabezadoCentralizado.Item("empresa", nRow).Value


            ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas

            ls_filtro = "empresa = '" & ls_empresa & "' and numero = '" & ls_resultado & "' and tipoDocto = '" & tipo_docto & "'"
            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = ls_filtro
            '"numero = '" & ls_resultado & "' and tipoDocto = '" & tipo_docto & "'"

            'Me.txt_total_lineas.Text = oDataSet.Tables("detalle_pedidos").DefaultView.Count
            Me.dgvDetalleCentralizado.DataSource = oDataSet.Tables("detalle_pedidos")
            ClsGen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgvDetalleCentralizado, "", ",tipodocto,empresa,codbarra,porcentajedr,correlativo,secuencia,", "", "", "", ",cantidadasignada=45,InnerPack=40,lote=20,", "", True, True, 200, 0)
            Me.txtComenariosCentralizado.Text = Me.dgvEncabezadoCentralizado.Item("comentario1", nRow).Value
            ' Me.dg_pedidos.Refresh()
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub dgvEncabezadoCentralizado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEncabezadoCentralizado.CellContentClick

    End Sub

    Private Sub dgvEncabezadoCentralizado_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEncabezadoCentralizado.CurrentCellChanged

        Try
            Me.mostrarDetalleCentralizado()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvDetalleCentralizado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleCentralizado.CellContentClick

    End Sub

    Private Sub dgvDetalleCentralizado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvDetalleCentralizado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalleCentralizado.Rows(rowIndex)

                If dgvDetalleCentralizado.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then
                    If Me.dgvDetalleCentralizado.Item("cantidadasignada", rowIndex).Value.ToString = 0 Then
                        Me.dgvDetalleCentralizado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    ElseIf Me.dgvDetalleCentralizado.Item("cantidad", rowIndex).Value.ToString <> Me.dgvDetalleCentralizado.Item("cantidadasignada", rowIndex).Value.ToString Then
                        Me.dgvDetalleCentralizado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                    End If
                End If


            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnProcesarCentralizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarCentralizado.Click
        If MessageBox.Show("Esta Seguro de Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            procesarPedidoCentralizado()
        End If
    End Sub

    Private Sub procesarPedidoCentralizado()

        Dim oFlex As New Umbral_Flex.Pedidos(False, True)
        Dim OflexPrecios As New Umbral_Flex.productos
        Dim Otrans As New Transaccional.Conexion("FlexLine")


        Dim dr As DataRow
        Dim rowIndex As Integer = Me.dgvEncabezadoCentralizado.CurrentRow.Index
        Dim therowE As DataGridViewRow = Me.dgvEncabezadoCentralizado.Rows(rowIndex)
        Dim dtPrecio As DataTable
        Dim dPrecio As Double
        Dim dtExistencias As DataTable

        Try
            Otrans.open()

            dr = oFlex.ods.Tables("encabezado").NewRow
            dr.Item("Empresa") = gs_empresa
            dr.Item("tipodocto") = "PEDIDO WALMART"
            dr.Item("correlativo") = 0
            dr.Item("CtaCte") = String.Empty
            dr.Item("numero") = String.Empty
            dr.Item("fecha") = Today
            dr.Item("proveedor") = String.Empty
            dr.Item("cliente") = Me.dgvEncabezadoCentralizado.Item("Cliente", rowIndex).Value
            dr.Item("bodega") = "CD_CENTRAL"
            dr.Item("bodega2") = String.Empty
            dr.Item("local") = String.Empty
            dr.Item("comprador") = String.Empty
            dr.Item("vendedor") = Me.dgvEncabezadoCentralizado.Item("Vendedor", rowIndex).Value
            dr.Item("CentroCosto") = String.Empty
            dr.Item("fechaVcto") = "01/01/1900"
            dr.Item("listaPrecio") = Me.dgvEncabezadoCentralizado.Item("ListaPrecio", rowIndex).Value 'dtFactura.Rows(0).Item("listaprecio").ToString
            dr.Item("Analisis") = "" 'PAYMENT_TERMS 'Forma de Pago
            dr.Item("Zona") = String.Empty
            dr.Item("tipocta") = "" 'FRT_VEND_NAME1
            dr.Item("moneda") = "QUETZALES" 'validar con Anixter
            dr.Item("paridad") = 1
            dr.Item("neto") = 0 'INVOICE_TOTAL
            dr.Item("subtotal") = 0 'INVOICE_TOTAL
            dr.Item("total") = 0 'INVOICE_TOTAL
            dr.Item("NetoIngreso") = 0 'INVOICE_TOTAL
            dr.Item("SubTotalIngreso") = 0 'INVOICE_TOTAL
            dr.Item("TotalIngreso") = 0 'INVOICE_TOTAL
            dr.Item("centraliza") = String.Empty
            dr.Item("valoriza") = "S"
            dr.Item("costeo") = String.Empty
            dr.Item("aprobacion") = "S"
            dr.Item("TipoComprobante") = String.Empty
            dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr.Item("FactorMonto") = 1
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = Me.dgvEncabezadoCentralizado.Item("Cliente", rowIndex).Value
            dr.Item("Glosa") = "" 'CUST_PO
            dr.Item("comentario1") = Me.txtComenariosCentralizado.Text
            dr.Item("comentario2") = String.Empty
            dr.Item("vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("direccion") = "" 'SHIP_TO_NAME1 & " " & SHIP_TO_NAME2 & " " & SHIP_TO_ADDR
            dr.Item("ciudad") = "" 'SHIP_TO_CITY
            dr.Item("comuna") = String.Empty
            dr.Item("EstadoDir") = String.Empty
            dr.Item("pais") = String.Empty
            dr.Item("contacto") = String.Empty
            dr.Item("FechaModif") = Now
            dr.Item("FechaUModif") = Now
            dr.Item("UsuarioModif") = gs_usuario
            dr.Item("Hora") = Now.ToString("HH:mm:ss")
            dr.Item("NetoBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("ParidadBimoneda") = 1
            dr.Item("AnalisisE1") = "" 'SORT_INVOICE ''Referencia Anixter
            dr.Item("AnalisisE2") = String.Empty
            dr.Item("AnalisisE30") = String.Empty 'Orden Edifact
            dr.Item("UsuarioAprueba") = String.Empty
            dr.Item("referenciaexterna") = "" 'INVOICE_NBR.Substring(0, 3) & ORDER_NBR ''Orden de Venta INVOICE_NBR Necesito Tomar los primeros 3 Posiciones

            Dim dtDocumentoFormula As DataTable
            Dim dtBodegas As DataTable
            dtDocumentoFormula = Otrans.Obtiene("pa_sel_um_tipodocumentoformula '" & gs_empresa & "','PEDIDO WALMART'")
            dtDocumentoFormula.DefaultView.RowFilter = "Nombre = 'IVA'"

            oFlex.ods.Tables("encabezado").Rows.Add(dr)

            Dim ldSubtotal As Double = 0
            Dim ldNeto As Double = 0
            Dim ldPorcentajeIva As Double = 0 = dtDocumentoFormula.DefaultView(0).Item("Porcentaje")


            Dim iCount As Integer = 0
            For Each drv As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                If drv.Item("procesar") = True Then
                    iCount += 1
                    dtPrecio = OflexPrecios.Obtener_Precio_Final(gs_empresa, drv.Item("producto"), _
                                    Me.dgvEncabezadoCentralizado.Item("Cliente", rowIndex).Value, _
                                    Me.dgvEncabezadoCentralizado.Item("ListaPrecio", rowIndex).Value)

                    dPrecio = 0
                    If dtPrecio.Rows.Count = 1 Then
                        If dtPrecio.Rows(0).Item("oferta") > 0 Then
                            dPrecio = dtPrecio.Rows(0).Item("oferta")
                        Else
                            dPrecio = dtPrecio.Rows(0).Item("valor")
                        End If
                    End If
                    If drv.Item("lote").ToString.ToLower.Equals("s") Then
                        dtExistencias = OflexPrecios.Obtener_Existencias_Lote(gs_empresa, drv.Item("producto"), drv.Item("bodega"))
                    End If

                    dtBodegas = OflexPrecios.Obtener_ProductoBodega(gs_empresa, "CD_CENTRAL", drv.Item("producto"))
                    dr = oFlex.ods.Tables("detalle").NewRow

                    dr.Item("Empresa") = gs_empresa
                    dr.Item("tipodocto") = "PEDIDO WALMART"
                    dr.Item("Secuencia") = iCount
                    dr.Item("Linea") = iCount
                    dr.Item("Producto") = drv.Item("producto")
                    dr.Item("Cantidad") = drv.Item("pedido") 'SHIP_QUANTITY
                    dr.Item("Precio") = dPrecio 'UNIT_PRICE
                    dr.Item("PorcentajeDr") = 0 'Lineas(iCount).Substring(144, 5)
                    dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
                    ldSubtotal += dr.Item("SubTotal")
                    dr.Item("Impuesto") = (dr.Item("SubTotal") / (1 + ldPorcentajeIva / 100)) * (ldPorcentajeIva / 100)
                    dr.Item("Neto") = dr.Item("SubTotal") - dr.Item("Impuesto")
                    ldNeto += dr.Item("Neto")
                    dr.Item("DRGlobal") = 0
                    dr.Item("Costo") = 0 'EXTENDED_STD_COST  'Es el costo de la tabla ProdBodegas
                    If dtBodegas.Rows.Count = 1 Then dr.Item("Costo") = dtBodegas.Rows(0).Item("Costo")
                    dr.Item("Total") = dr.Item("Neto")
                    dr.Item("PrecioAjustado") = dr.Item("precio") / (1 + ldPorcentajeIva / 100)
                    dr.Item("UnidadIngreso") = "UN" 'UM
                    dr.Item("CantidadIngreso") = dr.Item("cantidad") 'ORDER_QTY
                    dr.Item("PrecioIngreso") = dr.Item("precio")
                    dr.Item("SubTotalIngreso") = dr.Item("SubTotal") 'EXTENDED_PRICE 'dr.Item("cantidadIngreso") * dr.Item("precio")
                    dr.Item("ImpuestoIngreso") = dr.Item("Impuesto")
                    dr.Item("NetoIngreso") = dr.Item("Neto")
                    dr.Item("DRGlobalIngreso") = 0
                    dr.Item("TotalIngreso") = dr.Item("Total")
                    'dr.Item("Lote") = stro
                    'dr.Item("fechavcto") = ofila.Item("fechavcto")
                    dr.Item("TipoDoctoOrigen") = drv.Item("tipodocto")
                    dr.Item("CorrelativoOrigen") = drv.Item("correlativo")
                    dr.Item("SecuenciaOrigen") = drv.Item("secuencia")
                    dr.Item("Bodega") = "CD_CENTRAL"
                    dr.Item("FactorInventario") = -1
                    dr.Item("FechaEntrega") = Today
                    dr.Item("CantidadAsignada") = 0
                    dr.Item("Fecha") = Today
                    dr.Item("comentario") = String.Empty
                    dr.Item("Vigente") = "S"
                    dr.Item("CUP") = dr.Item("costo")
                    dr.Item("Ubicacion") = "PRINCIPAL"
                    dr.Item("Ubicacion2") = "PRINCIPAL"
                    dr.Item("cuenta") = String.Empty
                    dr.Item("FactorImpto") = 1 / (1 + ldPorcentajeIva / 100)
                    dr.Item("PrecioBimoneda") = dPrecio 'UNIT_PRICE_USD
                    dr.Item("SubTotalBimoneda") = dr.Item("subtotal")
                    dr.Item("ImpuestoBimoneda") = dr.Item("Impuesto")
                    dr.Item("NetoBimoneda") = dr.Item("Neto")
                    dr.Item("DrGlobalBimoneda") = 0
                    dr.Item("TotalBimoneda") = dr.Item("Total")
                    dr.Item("PrecioListaP") = dtPrecio.Rows(0).Item("valor")
                    dr.Item("UniMedDynamic") = 0
                    dr.Item("FechaVigenciaLp") = dtPrecio.Rows(0).Item("fec_final")
                    dr.Item("LoteDestino") = String.Empty
                    dr.Item("SerieDestino") = String.Empty
                    dr.Item("ProdAlias") = String.Empty
                    'dr.Item("DoctoOrigenVal") = "S"
                    dr.Item("MontoAsignado") = 0
                    ' dr.Item("Aux_Valor13") = ofila.Item("cod_motivo")

                    dr.Item("ValPorcentajeDr1") = 0
                    dr.Item("ValPorcentajeDr2") = 0
                    dr.Item("ValPorcentajeDr3") = 0
                    dr.Item("ValPorcentajeDr4") = 0
                    dr.Item("ValPorcentajeDr5") = 0
                    dr.Item("ValPorcentajeDr1Ingreso") = 0
                    dr.Item("ValPorcentajeDr2Ingreso") = 0
                    dr.Item("ValPorcentajeDr3Ingreso") = 0
                    dr.Item("ValPorcentajeDr4Ingreso") = 0
                    dr.Item("ValPorcentajeDr5Ingreso") = 0
                    dr.Item("ValPorcentajeDr1Bimoneda") = 0
                    dr.Item("ValPorcentajeDr2Bimoneda") = 0
                    dr.Item("ValPorcentajeDr3Bimoneda") = 0
                    dr.Item("ValPorcentajeDr4Bimoneda") = 0
                    dr.Item("ValPorcentajeDr5Bimoneda") = 0

                    oFlex.ods.Tables("detalle").Rows.Add(dr)
                End If
            Next
            ''Totales Documento
            oFlex.ods.Tables("encabezado").Rows(0).Item("neto") = ldNeto
            oFlex.ods.Tables("encabezado").Rows(0).Item("subtotal") = ldSubtotal
            oFlex.ods.Tables("encabezado").Rows(0).Item("total") = ldSubtotal - IIf(Double.Parse(Me.txtPorcCentralizado.Text) > 0, (ldSubtotal * Double.Parse(Me.txtPorcCentralizado.Text) / 100), 0)
            oFlex.ods.Tables("encabezado").Rows(0).Item("netoIngreso") = ldNeto
            oFlex.ods.Tables("encabezado").Rows(0).Item("subtotalIngreso") = ldSubtotal
            oFlex.ods.Tables("encabezado").Rows(0).Item("totalIngreso") = oFlex.ods.Tables("encabezado").Rows(0).Item("total")

            'DocumentoP
            dr = oFlex.ods.Tables("documentop").NewRow
            dr.Item("codigopago") = "CREDITO 30 DIAS"
            dr.Item("diascredito") = 30
            dr.Item("total") = oFlex.ods.Tables("encabezado").Rows(0).Item("total")
            dr.Item("numero") = oFlex.ods.Tables("encabezado").Rows(0).Item("numero")
            dr.Item("cuenta") = "010102010100"
            dr.Item("fecha") = Today
            oFlex.ods.Tables("documentop").Rows.Add(dr)

            ''Documento par


            For iCount = 1 To dtDocumentoFormula.Rows.Count
                dr = oFlex.ods.Tables("documentov").NewRow
                dtDocumentoFormula.DefaultView.RowFilter = "Orden = " & iCount
                dr.Item("Nombre") = dtDocumentoFormula.DefaultView(0).Item("Nombre")
                dr.Item("Orden") = dtDocumentoFormula.DefaultView(0).Item("Orden")
                dr.Item("Factor") = dtDocumentoFormula.DefaultView(0).Item("Factor")
                dr.Item("Monto") = 0
                If iCount = 1 Then
                    dr.Item("Monto") = ods.Tables("encabezado").Rows(0).Item("neto")
                ElseIf iCount = 4 And Double.Parse(Me.txtPorcCentralizado.Text) > 0 Then
                    dr.Item("Monto") = ods.Tables("encabezado").Rows(0).Item("subtotal") * (Double.Parse(Me.txtPorcCentralizado.Text) / 100)
                ElseIf iCount = 7 And Double.Parse(Me.txtPorcCentralizado.Text) > 0 Then
                    dr.Item("Monto") = (ods.Tables("encabezado").Rows(0).Item("subtotal") * (Double.Parse(Me.txtPorcCentralizado.Text) / 100)) / 1.12
                ElseIf iCount = 10 And Double.Parse(Me.txtPorcCentralizado.Text) > 0 Then
                    dr.Item("Monto") = ods.Tables("encabezado").Rows(0).Item("subtotal") * (Double.Parse(Me.txtPorcCentralizado.Text) / 100) - (ods.Tables("encabezado").Rows(0).Item("subtotal") * (Double.Parse(Me.txtPorcCentralizado.Text) / 100)) / 1.12
                ElseIf iCount = 20 Then
                ElseIf iCount = 21 Then
                    dr.Item("Monto") = ods.Tables("encabezado").Rows(0).Item("neto") * (Double.Parse(dtDocumentoFormula.DefaultView(0).Item("Porcentaje")) / 100)
                ElseIf iCount = 21 Then
                    dr.Item("Monto") = Double.Parse(Me.txtPorcCentralizado.Text)
                End If
                dr.Item("MontoIngreso") = dr.Item("Monto")
                dr.Item("Ajuste") = 0
                dr.Item("AjusteIngreso") = 0
                dr.Item("Texto") = String.Empty
                dr.Item("Porcentaje") = 0
                dr.Item("MontoBimoneda") = dr.Item("Monto")
                dr.Item("AjusteBimoneda") = 0
                If iCount = 21 Then
                    dr.Item("Porcentaje") = dtDocumentoFormula.DefaultView(0).Item("Porcentaje")
                ElseIf iCount = 4 Then
                    dr.Item("Porcentaje") = Me.txtPorcCentralizado.Text
                End If
            Next
            oFlex.ods.Tables("documentov").Rows.Add(dr)
            'ls_sql = "pa_ins_um_documentov_traslado '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipodocto") & "'," & _
            '                                            CStr(dr.Item("correlativo").ToString) & ",'" & dr2.Item("Nombre").ToString & "'," & _
            '                                            dr2.Item("Orden").ToString & "," & dr2.Item("Factor").ToString & "," & _
            '                                            dr2.Item("Monto").ToString & "," & dr2.Item("MontoIngreso").ToString & "," & _
            '                                            dr2.Item("Ajuste").ToString & "," & dr2.Item("AjusteIngreso").ToString & "," & _
            '                                            IIf(dr2.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr2.Item("Texto").ToString & "'") & "," & _
            '                                            dr2.Item("Porcentaje").ToString & "," & _
            '                                            dr2.Item("MontoBimoneda").ToString & "," & _
            '                                            IIf(dr2.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr2.Item("AjusteBimoneda").ToString)

            'li_sresultado = Otrans.Ingresa(ls_sql)

            oFlex.Validar_Totales = False
            If oFlex.Guardar_Documento() > 0 Then
                MessageBox.Show("Pedido Generado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                pedidosPendientesCentralizado()
            End If



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub dgvDetalleCentralizado_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleCentralizado.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow
        Dim ncantidad As Integer

        Try


            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalleCentralizado.Rows(rowIndex)

                If dgv_detalle.Columns(colIndex).Name.ToLower.Equals("pedido") Then
                    ''Cantidad debe ser multipo del pedido
                    ''Cantidad debe ser mayor o igual al inventario
                    ncantidad = dgv_detalle.Item("pedido", rowIndex).Value
                End If
                If dgvDetalleCentralizado.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_pedidos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv_pedidos.DataError

    End Sub
End Class