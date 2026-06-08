Option Explicit On

Imports System.IO

Public Class frm_guate_factura
    Inherits System.Windows.Forms.Form
    Dim oDataSet As New DataSet
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents cmb_tipododcto As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents chk_marcar As System.Windows.Forms.CheckBox
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
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents cmb_estados As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_comentarios_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents txt_vigencia_cliente As System.Windows.Forms.TextBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_notas_debito As System.Windows.Forms.TextBox
    Friend WithEvents txt_notas_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_facturas As System.Windows.Forms.TextBox
    Friend WithEvents txt_limite_credito As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_guate_factura))
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_comentario = New System.Windows.Forms.TextBox
        Me.cmb_estados = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Btn_Guardar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_comentarios_cliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_condicion = New System.Windows.Forms.TextBox
        Me.txt_vigencia_cliente = New System.Windows.Forms.TextBox
        Me.txt_limite_credito = New System.Windows.Forms.TextBox
        Me.txt_total_pedido = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_procesar = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmb_tipododcto = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_notas_debito = New System.Windows.Forms.TextBox
        Me.txt_notas_credito = New System.Windows.Forms.TextBox
        Me.txt_facturas = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chk_marcar = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(251, 16)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_final.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(221, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Al"
        '
        'txt_comentario
        '
        Me.txt_comentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comentario.Location = New System.Drawing.Point(72, 40)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(376, 72)
        Me.txt_comentario.TabIndex = 8
        '
        'cmb_estados
        '
        Me.cmb_estados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_estados.DisplayMember = "cds"
        Me.cmb_estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estados.Location = New System.Drawing.Point(72, 16)
        Me.cmb_estados.Name = "cmb_estados"
        Me.cmb_estados.Size = New System.Drawing.Size(304, 21)
        Me.cmb_estados.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Resolucion"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Guardar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.Btn_Guardar.Location = New System.Drawing.Point(-26, 16)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Guardar.TabIndex = 11
        Me.Btn_Guardar.Text = "Aceptar"
        Me.Btn_Guardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comentario Pedido"
        '
        'txt_comentarios_cliente
        '
        Me.txt_comentarios_cliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comentarios_cliente.Location = New System.Drawing.Point(72, 15)
        Me.txt_comentarios_cliente.Multiline = True
        Me.txt_comentarios_cliente.Name = "txt_comentarios_cliente"
        Me.txt_comentarios_cliente.ReadOnly = True
        Me.txt_comentarios_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentarios_cliente.Size = New System.Drawing.Size(272, 72)
        Me.txt_comentarios_cliente.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(8, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Comentario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_comentario)
        Me.GroupBox1.Controls.Add(Me.cmb_estados)
        Me.GroupBox1.Controls.Add(Me.Btn_Guardar)
        Me.GroupBox1.Location = New System.Drawing.Point(1089, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(62, 120)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_condicion)
        Me.GroupBox2.Controls.Add(Me.txt_vigencia_cliente)
        Me.GroupBox2.Controls.Add(Me.txt_limite_credito)
        Me.GroupBox2.Controls.Add(Me.txt_comentarios_cliente)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(1063, 488)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(18, 95)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion de Cliente"
        Me.GroupBox2.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Condicion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Lim. Credito"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(176, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Vigencia"
        '
        'txt_condicion
        '
        Me.txt_condicion.Location = New System.Drawing.Point(72, 40)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.ReadOnly = True
        Me.txt_condicion.Size = New System.Drawing.Size(272, 21)
        Me.txt_condicion.TabIndex = 17
        '
        'txt_vigencia_cliente
        '
        Me.txt_vigencia_cliente.Location = New System.Drawing.Point(264, 14)
        Me.txt_vigencia_cliente.Name = "txt_vigencia_cliente"
        Me.txt_vigencia_cliente.ReadOnly = True
        Me.txt_vigencia_cliente.Size = New System.Drawing.Size(80, 21)
        Me.txt_vigencia_cliente.TabIndex = 16
        '
        'txt_limite_credito
        '
        Me.txt_limite_credito.Location = New System.Drawing.Point(72, 16)
        Me.txt_limite_credito.Name = "txt_limite_credito"
        Me.txt_limite_credito.ReadOnly = True
        Me.txt_limite_credito.Size = New System.Drawing.Size(80, 21)
        Me.txt_limite_credito.TabIndex = 15
        Me.txt_limite_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_pedido.Location = New System.Drawing.Point(1035, 448)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(120, 21)
        Me.txt_total_pedido.TabIndex = 17
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_total_pedido.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(931, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Total de Pedido"
        Me.Label9.Visible = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(4, 358)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(1151, 234)
        Me.dgv_detalle.TabIndex = 19
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AllowUserToAddRows = False
        Me.dgv_pedidos.AllowUserToDeleteRows = False
        Me.dgv_pedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(4, 122)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.RowHeadersWidth = 25
        Me.dgv_pedidos.Size = New System.Drawing.Size(1151, 230)
        Me.dgv_pedidos.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chk_marcar)
        Me.GroupBox3.Controls.Add(Me.btn_generar)
        Me.GroupBox3.Controls.Add(Me.btn_procesar)
        Me.GroupBox3.Controls.Add(Me.cmb_tipododcto)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txt_notas_debito)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txt_notas_credito)
        Me.GroupBox3.Controls.Add(Me.dtp_fecha_final)
        Me.GroupBox3.Controls.Add(Me.txt_facturas)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.dtp_fecha_inicio)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 116)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informacion"
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
        Me.btn_generar.Location = New System.Drawing.Point(518, 13)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(125, 62)
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
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_procesar.ImageIndex = 2
        Me.btn_procesar.ImageList = Me.ImageList2
        Me.btn_procesar.Location = New System.Drawing.Point(659, 13)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(105, 62)
        Me.btn_procesar.TabIndex = 28
        Me.btn_procesar.Text = "Procesar"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "aceptar.png")
        Me.ImageList2.Images.SetKeyName(1, "DeleteRed.png")
        Me.ImageList2.Images.SetKeyName(2, "running_process.png")
        '
        'cmb_tipododcto
        '
        Me.cmb_tipododcto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipododcto.FormattingEnabled = True
        Me.cmb_tipododcto.Items.AddRange(New Object() {"Factura", "Credito", "Debito"})
        Me.cmb_tipododcto.Location = New System.Drawing.Point(306, 90)
        Me.cmb_tipododcto.Name = "cmb_tipododcto"
        Me.cmb_tipododcto.Size = New System.Drawing.Size(144, 21)
        Me.cmb_tipododcto.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(213, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 15)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Tipo Documento"
        '
        'txt_notas_debito
        '
        Me.txt_notas_debito.Location = New System.Drawing.Point(106, 90)
        Me.txt_notas_debito.Name = "txt_notas_debito"
        Me.txt_notas_debito.ReadOnly = True
        Me.txt_notas_debito.Size = New System.Drawing.Size(100, 21)
        Me.txt_notas_debito.TabIndex = 5
        '
        'txt_notas_credito
        '
        Me.txt_notas_credito.Location = New System.Drawing.Point(106, 68)
        Me.txt_notas_credito.Name = "txt_notas_credito"
        Me.txt_notas_credito.ReadOnly = True
        Me.txt_notas_credito.Size = New System.Drawing.Size(100, 21)
        Me.txt_notas_credito.TabIndex = 4
        '
        'txt_facturas
        '
        Me.txt_facturas.Location = New System.Drawing.Point(106, 46)
        Me.txt_facturas.Name = "txt_facturas"
        Me.txt_facturas.ReadOnly = True
        Me.txt_facturas.Size = New System.Drawing.Size(100, 21)
        Me.txt_facturas.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Notas de Debito"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Notas Credito"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Facturas"
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
        'chk_marcar
        '
        Me.chk_marcar.AutoSize = True
        Me.chk_marcar.Location = New System.Drawing.Point(507, 91)
        Me.chk_marcar.Name = "chk_marcar"
        Me.chk_marcar.Size = New System.Drawing.Size(114, 17)
        Me.chk_marcar.TabIndex = 36
        Me.chk_marcar.Text = "Marcar/Desmarcar"
        Me.chk_marcar.UseVisualStyleBackColor = True
        '
        'frm_guate_factura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1163, 598)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgv_pedidos)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_total_pedido)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_guate_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Factura Electronica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub Pedidos_Pendientes()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim dr, dr_aux As DataRow



        Dim ls_sqltxt As String
        oDataSet = New DataSet

        ods.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefactura '" & gs_empresa & "','" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "pedidos"
            'oDataSet.Tables.Add(oTabla.Copy)
            oTabla.DefaultView.RowFilter = "documento like 'debito'"
            Me.txt_notas_debito.Text = oTabla.DefaultView.Count

            oTabla.DefaultView.RowFilter = "documento like 'credito'"
            Me.txt_notas_credito.Text = oTabla.DefaultView.Count

            oTabla.DefaultView.RowFilter = "documento like 'factura'"
            Me.txt_facturas.Text = oTabla.DefaultView.Count



            For Each dr In oTabla.Rows



                dr_aux = ods.Tables("pedidos").NewRow
                dr_aux.Item("Enviar") = 1
                dr_aux.Item("serie") = dr.Item("serie")
                dr_aux.Item("documento") = dr.Item("documento")
                dr_aux.Item("empresa") = dr.Item("empresa")
                dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                dr_aux.Item("correlativo") = dr.Item("correlativo")
                dr_aux.Item("numero") = dr.Item("numero")
                dr_aux.Item("fecha") = dr.Item("fecha")
                dr_aux.Item("codlegal") = dr.Item("codlegal")
                dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                dr_aux.Item("direccion") = dr.Item("direccion")
                dr_aux.Item("telefono") = dr.Item("telefono")
                dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
                dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
                dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
                dr_aux.Item("RefFecha") = dr.Item("fechaRef")
                dr_aux.Item("vigencia") = dr.Item("vigencia")
                dr_aux.Item("exento") = dr.Item("exento")
                dr_aux.Item("porcdescuento") = dr.Item("porcdescuento")
                dr_aux.Item("total") = dr.Item("total")
                ods.Tables("pedidos").Rows.Add(dr_aux)


            Next

            clGen.Alinear_GridView(ods.Tables("pedidos"), dgv_pedidos, "", ",correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,", "", "", "", "", True, True, 150, 0)


            'ls_sqltxt = "pa_var_um_detalle_guatefactura '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_inicio.Text & "','" & gs_empresa & "'"
            ls_sqltxt = "pa_var_um_detalle_guatefactura '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "','" & gs_empresa & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_pedidos"
            oDataSet.Tables.Add(oTabla.Copy)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            detalle_pedido(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)

        'Dim ls_resultado As String
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_pedidos.Item("numero", pi_RowNumber).Value &
                                                             "' and tipodocto  = '" &
                                                            dgv_pedidos.Item("tipodocto", pi_RowNumber).Value &
                                                            "' and empresa = '" & dgv_pedidos.Item("empresa", pi_RowNumber).Value & "'"

        Me.dgv_detalle.DataSource = oDataSet.Tables("detalle_pedidos")
        Me.dgv_pedidos.Refresh()

        clgen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgv_detalle, "", "", "", "", "", "", "", True, True, 200, 0)



        clgen = Nothing

    End Sub
    Private Sub crear_estructura()
        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(String)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("exento", GetType(String)))
        dt.Columns.Add(New DataColumn("PorCDescuento", GetType(Double)))
        ods.Tables.Add(dt)
        Me.dgv_pedidos.DataSource = ods.Tables("pedidos")
        Me.cmb_tipododcto.Text = "Factura"
    End Sub
    Private Sub frm_pedidos_pendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        crear_estructura()


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
    Private Sub procesarInformacion()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable
        Dim dt2, dt3 As DataTable
        Dim dr, dr2 As DataRow
        Dim linea As String = ""
        Dim tipo_documento As String = ""
        Dim ClsGen As New ClasesGenerales.General
        ' Dim _archivo As String = ""
        Dim lexito As Boolean
        Dim importe_total As Double
        Dim importe_bruto As Double
        Dim importe_neto As Double
        Dim importe_iva As Double
        Dim importe_descuento As Double
        Dim i As Integer
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim neto As Double
        Dim reemplazar As Boolean = False
        Dim vigencia As String = ""
        Dim exento, dvalorPorcentajeDR1 As Double
        Dim impdist As Double

        Dim IMPORT_BRUTO As Double = 0.0
        Dim IMPORT_NETO As Double = 0.0
        Dim IMPORT_IVA As Double = 0.0
        Dim IMPORT_TOTAL As Double = 0.0
        Dim nLineas As Integer = 0

        Try
            Try
                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Debito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then
                    If MessageBox.Show("Ya existe Informacion generada para el dia " & Me.dtp_fecha_inicio.Text & ", Desea Volver a Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        reemplazar = True
                    End If
                Else
                    reemplazar = True
                End If
            Catch ex As Exception
            End Try


            Otrans.open()
            i = 0

            If reemplazar Then

                ods.Tables("pedidos").DefaultView.RowFilter = "enviar = true and documento = '" & Me.cmb_tipododcto.Text & "'"
                For Each drv As DataRowView In ods.Tables("pedidos").DefaultView

                    If drv.Item("enviar") = True Then
                        If drv.Item("documento").ToString = "Factura" Then
                            tipo_documento = "CFACE"
                        ElseIf drv.Item("documento").ToString = "Credito" Then
                            tipo_documento = "CNCE"
                        ElseIf drv.Item("documento").ToString = "Debito" Then
                            tipo_documento = "CNDE"
                        End If

                        If drv.Item("serie").ToString.Trim <> "" Then
                            If drv.Item("vigencia").ToString = "S" Or drv.Item("vigencia").ToString = "N" Then
                                linea = "1|" & Date.Parse(drv.Item("fecha").ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|" & drv.Item("serie").ToString & "|"
                                linea += drv.Item("numero").ToString & "|" & drv.Item("codlegal").ToString & "|" & drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
                                linea += drv.Item("direccion").ToString.Replace("|", " ") & "|" & drv.Item("telefono").ToString & "|1|1|E||"
                                linea += drv.Item("serie").ToString & " " & drv.Item("numero").ToString 'Orden Externo 'antes llevaba un 0

                                If gs_empresa = "LOGISERV" Then
                                    linea += "|S|" 'Bien Idenficar cuando sea servicio (c) 20170829
                                Else
                                    linea += "|B|" 'Bien Idenficar cuando sea servicio (c) 20170829
                                End If
                                linea += "1||N" '1=guatemala, 69=El Salvador

                                If drv.Item("codlegal").ToString = "7378106" And tipo_documento = "CFACE" Then
                                    ''Campos adicionales walmart
                                    linea += "|Vendor 010085261  "
                                    linea += "|"
                                    linea += "|"
                                    linea += "|Bodega" '
                                    linea += "|Comentraios "

                                    linea += "|010085261" 'Codigo de CODICASA
                                    linea += "|7407001008593" 'dtmyPedido.Rows(0).Item("gln")
                                    linea += "|Guatemala"
                                    linea += "|Guatemala" 'Comuna
                                    linea += "|" + drv.Item("Direccion").ToString.Trim.PadLeft(80, " ").Substring(0, 79)

                                    linea += "|2803120099"
                                    linea += "|2803120099" 'Cod Recepcion
                                    linea += "|0" 'Descuento
                                End If


                            Else
                                linea = "1|" & Date.Parse(drv.Item("fecha").ToString).ToString("yyyyMMdd") & "|" & tipo_documento & "|" & drv.Item("serie").ToString & "|"
                                linea += drv.Item("numero").ToString & "|" & drv.Item("codlegal").ToString & "|" & drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
                                linea += drv.Item("direccion").ToString.Replace("|", " ") & "|" & drv.Item("telefono").ToString & "|1|1|A|" & Date.Parse(drv.Item("fecha").ToString).ToString("yyyyMMdd") & "|"
                                linea += drv.Item("serie").ToString & " " & drv.Item("numero").ToString 'Orden Externo
                                linea += "|B|1|DOCUMENTO ANULADO|N"

                                If drv.Item("codlegal").ToString = "7378106" And tipo_documento = "CFACE" Then
                                    ''Campos adicionales walmart
                                    linea += "|Vendor 010085261  "
                                    linea += "|"
                                    linea += "|"
                                    linea += "|Bodega" '
                                    linea += "|Comentarios "

                                    linea += "|010085261" 'Codigo de CODICASA
                                    linea += "|7407001008593" 'dtmyPedido.Rows(0).Item("gln")
                                    linea += "|Guatemala"
                                    linea += "|Guatemala" 'Comuna
                                    linea += "|" + drv.Item("Direccion").ToString.Trim.PadLeft(80, " ").Substring(0, 79)

                                    linea += "|2803120099"
                                    linea += "|2803120099" 'Cod Recepcion
                                    linea += "|0" 'Descuento
                                End If


                            End If


                            Dim lsNombreArchivo, lsNombreDirectorio As String
                            lsNombreArchivo = "c:\aplicaciones\log\" & gs_empresa & "\" & drv.Item("documento").ToString & "\" &
                                             Me.dtp_fecha_inicio.Value.ToString("yyyyMM") & "\" & Me.dtp_fecha_inicio.Value.ToString("dd").Replace("/", "") & "-" & Me.dtp_fecha_final.Text.Replace("/", "") & "_" &
                                             ods.Tables("pedidos").DefaultView.Count & ".txt"


                            If drv.Item("documento").ToString = "Factura" And entro = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Value.ToString("yyyyMM")) Then
                                    Try
                                        System.IO.File.Delete(lsNombreArchivo)
                                        entro = True
                                    Catch ex As Exception
                                    End Try
                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Value.ToString("yyyyMM"))
                                    entro = True
                                End If
                            End If


                            If drv.Item("documento").ToString = "Credito" And entro_c = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Value.ToString("yyyyMM")) Then

                                    Try
                                        System.IO.File.Delete(lsNombreArchivo)
                                        entro_c = True
                                    Catch ex As Exception
                                    End Try

                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Value.ToString("yyyyMM"))
                                    entro_c = True
                                End If
                            End If

                            lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString &
                                                                        "' and tipodocto  = '" &
                                                                       drv.Item("tipodocto").ToString &
                                                                       "' and empresa = '" & drv.Item("empresa").ToString & "'"


                            If drv.Item("documento").ToString.Trim <> "Debito" Then
                                importe_total = 0
                                importe_bruto = 0
                                importe_neto = 0
                                importe_iva = 0
                                dvalorPorcentajeDR1 = 0
                                importe_descuento = 0

                                For Each drvD As DataRowView In oDataSet.Tables("detalle_pedidos").DefaultView
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    linea = ""


                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|" & drvD.Item("cantidad") & "|1|"
                                    '4.PRECIO
                                    linea += drvD.Item("Precio") & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

                                        If drvD.Item("PorcentajeDR") <> 0 Then
                                            '5.PORCENTAJE_DESCUENTO 
                                            linea += drvD.Item("PorcentajeDR") * -1 & "|"
                                            dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
                                        Else
                                            '5.PORCENTAJE_DESCUENTO 
                                            dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
                                            linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        End If

                                        '6.IMPORTE_DESCUENTO
                                        linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
                                        '7.IMPORTE_BRUTO
                                        linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"
                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        'SI NO HAY DESCUENTO
                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                        linea += "0|0|"
                                        '7.IMPORTE_BRUTO
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                        linea += IMPORT_BRUTO & "|"
                                        importe_bruto += IMPORT_BRUTO
                                    End If



                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                    If drv.Item("exento").ToString.ToLower = "si" Then

                                        exento = IMPORT_BRUTO
                                        '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
                                        linea += exento & "|0|0|0|"
                                        IMPORT_TOTAL = exento
                                        linea += IMPORT_TOTAL & "|"
                                    Else
                                        '8.IMPORTE_EXENTO 
                                        linea += "0|"
                                        '9.IMPORTE_NETO
                                        IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                        linea += IMPORT_NETO & "|"
                                        '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                        IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                        linea += IMPORT_IVA & "|0|"

                                        '12.IMPORTE_TOTAL
                                        IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                        linea += IMPORT_TOTAL & "|"
                                    End If

                                    '13.PRODUCTO       14.DESCRIPCION
                                    linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"



                                    If drv.Item("documento").ToString = "Factura" Then
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            'linea += "0.00|0.00"
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += "0.00"
                                        Else
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += Math.Round(drvD.Item("Impdist"), 2).ToString
                                        End If
                                        '16.PRECIO_SUGERIDO
                                        linea += "|" & drvD.Item("psugerido").ToString

                                        If drvD.Item("volumen").ToString.Length > 0 Then
                                            '17.VOLUMEN
                                            linea += "|" & drvD.Item("volumen").ToString
                                        Else
                                            '17.VOLUMEN
                                            linea += "|" & 0
                                        End If
                                    End If


                                    If drv.Item("documento").ToString = "Credito" Then
                                        impdist = Math.Round(drvD.Item("Impdist"), 2).ToString
                                        If impdist > 0 Then
                                            linea += "" & impdist
                                        Else
                                            linea += "0"

                                        End If


                                    End If
                                    impdist = 0
                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)

                                    'Informacion para walmart
                                    '(c)21052015
                                    If drv.Item("codlegal").ToString = "7378106" And tipo_documento = "CFACE" Then
                                        linea += "|" & "00014800000344" 'gtin
                                        linea += "|" & "070327006" 'idBuyer
                                        linea += "|" & "" 'IDU12
                                        linea += "|" & "0014800000344" 'IDU13
                                        linea += "|" & "200060191" 'IDSupplier
                                        linea += "|" & "EA" 'UnitOfMesure
                                    End If

                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                Next

                                nLineas = oDataSet.Tables("detalle_pedidos").DefaultView.Count
                                ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
                                ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
                                If drv.Item("porcDescuento") > 0 Then
                                    ls_sql = "pa_var_um_documentov '" & gs_empresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

                                    Dim drv2 As DataRowView = dt.DefaultView(0)
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|1|1|"
                                    '4.PRECIO
                                    linea += dMonto & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    'SI NO HAY DESCUENTO
                                    '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                    linea += "0|0|"
                                    '7.IMPORTE_BRUTO
                                    IMPORT_BRUTO = dMonto
                                    linea += IMPORT_BRUTO & "|"
                                    importe_bruto += IMPORT_BRUTO

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

                                    '8.IMPORTE_EXENTO 
                                    linea += "0|"
                                    '9.IMPORTE_NETO
                                    IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
                                    linea += IMPORT_NETO & "|"
                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                    linea += IMPORT_IVA & "|0|"

                                    '12.IMPORTE_TOTAL
                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                    linea += IMPORT_TOTAL & "|"

                                    '13.PRODUCTO       14.DESCRIPCION
                                    'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    linea += "0000000001|DESCUENTOS GLOBALES|"

                                    'linea += "0.00|0.00"
                                    '15.IMPUESTO_DISTRIBUCION
                                    linea += "0.00"

                                    '16.PRECIO_SUGERIDO
                                    linea += "|0"

                                    '17.VOLUMEN
                                    linea += "|0"

                                    impdist = 0
                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    nLineas += 1
                                End If ''Descuento Global

                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    If drv.Item("Refnumero").ToString.Trim.Length = 12 Then

                                        ls_sql = "pa_sel_um_documento_NCDC '" & gs_empresa & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|FACE|" & drv.Item("RefTipoDocto").ToString & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")

                                        Catch ex As Exception

                                        End Try
                                    Else

                                        ls_sql = "pa_sel_um_documento_NCDC '" & gs_empresa & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto4") & "-" & dt.Rows(0).Item("texto1") & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")
                                        Catch ex As Exception
                                        End Try

                                    End If
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)

                                End If
                                If drv.Item("documento").ToString = "Factura" Then
                                    If Math.Abs(importe_total - drv.Item("total")) > 0.1 Then
                                        MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                    Else
                                        linea = ""
                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
                                        linea += Math.Round(importe_descuento, 2) & "|"
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
                                        Else
                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
                                        End If
                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                            nLineas & "|0"
                                        lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                    End If
                                End If
                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                    nLineas & "|" & dt.Rows.Count
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreArchivo, linea & vbCrLf)
                                End If
                            End If
                        End If
                    End If
                Next

                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub


    Private Sub procesar_info()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim dr, dr2 As DataRow
        Dim linea As String = String.Empty
        Dim tipo_documento As String = String.Empty
        Dim ClsGen As New ClasesGenerales.General
        Dim _archivo As String = String.Empty
        Dim lexito As Boolean
        Dim importe_bruto As Double
        Dim importe_neto As Double
        Dim importe_iva As Double
        Dim i As Integer
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim neto As Double
        Dim reemplazar As Boolean = False
        Dim vigencia As String = String.Empty
        Dim exento As Double




        Try

            Try
                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Debito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then
                    If MessageBox.Show("Ya existe Informacion generada para el dia " & Me.dtp_fecha_inicio.Text & ", Desea Volver a Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then reemplazar = True
                Else
                    reemplazar = True
                End If
            Catch ex As Exception
            End Try


            Otrans.open()
            i = 0

            If reemplazar Then


                For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1
                    If dgv_pedidos.Item("enviar", jj).Value Then

                        If dgv_pedidos.Item("documento", jj).Value = "Factura" Then
                            tipo_documento = "CFACE"
                        ElseIf dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                            tipo_documento = "CNCE"
                        ElseIf dgv_pedidos.Item("documento", jj).Value = "Debito" Then
                            tipo_documento = "CNDE"
                        End If

                        If dgv_pedidos.Item("serie", jj).Value <> "" Then
                            If dgv_pedidos.Item("vigencia", jj).Value = "S" Or dgv_pedidos.Item("vigencia", jj).Value = "N" Then

                                linea = "1|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|" & tipo_documento & "|" & dgv_pedidos.Item("serie", jj).Value & "|"
                                linea += dgv_pedidos.Item("numero", jj).Value & "|" & dgv_pedidos.Item("codlegal", jj).Value & "|" & dgv_pedidos.Item("nombre_cliente", jj).Value & "|"
                                linea += dgv_pedidos.Item("direccion", jj).Value & "|" & dgv_pedidos.Item("telefono", jj).Value & "|1|1|E||0|B|1||N"
                            Else
                                linea = "1|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|" & tipo_documento & "|" & dgv_pedidos.Item("serie", jj).Value & "|"
                                linea += dgv_pedidos.Item("numero", jj).Value & "|" & dgv_pedidos.Item("codlegal", jj).Value & "|" & dgv_pedidos.Item("nombre_cliente", jj).Value & "|"
                                linea += dgv_pedidos.Item("direccion", jj).Value & "|" & dgv_pedidos.Item("telefono", jj).Value & "|1|1|A|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|0|B|1|DOCUMENTO ANULADO|N"



                            End If




                            If dgv_pedidos.Item("documento", jj).Value = "Factura" And entro = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then

                                    Try
                                        System.IO.File.Delete("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt")
                                        entro = True
                                        _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                    Catch ex As Exception
                                    End Try

                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", ""))
                                    entro = True
                                    _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                End If
                            End If




                            If dgv_pedidos.Item("documento", jj).Value = "Credito" And entro_c = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then

                                    Try
                                        System.IO.File.Delete("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt")
                                        entro_c = True
                                        _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                    Catch ex As Exception
                                    End Try

                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", ""))
                                    entro_c = True
                                    _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                End If
                            End If







                            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_pedidos.Item("numero", jj).Value &
                                                                        "' and tipodocto  = '" &
                                                                       dgv_pedidos.Item("tipodocto", jj).Value &
                                                                       "' and empresa = '" & dgv_pedidos.Item("empresa", jj).Value & "'"


                            If dgv_pedidos.Item("documento", jj).Value <> "Debito" Then



                                Dim drv As DataRowView
                                drv = oDataSet.Tables("detalle_pedidos").DefaultView(0)
                                importe_bruto = 0
                                importe_neto = 0
                                importe_iva = 0




                                For j As Integer = 0 To drv.DataView.Count - 1
                                    linea = ""
                                    linea = "2|" & drv.DataView(j)("cantidad") & "|1|"
                                    linea += drv.DataView(j)("Precio") & "|0|0|"
                                    linea += drv.DataView(j)("subtotal") & "|"

                                    If dgv_pedidos.Item("serie", jj).Value = "F" Then
                                        exento = drv.DataView(j)("subtotal") / 9.33
                                        linea += exento & "|0|0|0|" & drv.DataView(j)("subtotal") & "|"
                                    Else
                                        linea += "0|"
                                        linea += drv.DataView(j)("Neto") & "|"
                                        linea += drv.DataView(j)("Impuesto") & "|0|" & drv.DataView(j)("subtotal") & "|"

                                    End If


                                    linea += drv.DataView(j)("producto").ToString & "|" & drv.DataView(j)("glosa").ToString & "|"

                                    If dgv_pedidos.Item("serie", jj).Value = "F" Then
                                        linea += "0.00|0.00"
                                    Else
                                        linea += drv.DataView(j)("Impdist").ToString & "|" & drv.DataView(j)("psugerido").ToString

                                    End If


                                    importe_bruto += drv.DataView(j)("subtotal")
                                    importe_neto += drv.DataView(j)("Neto")
                                    importe_iva += drv.DataView(j)("Impuesto")
                                    lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                                Next
                                If dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                                    ls_sql = "pa_sel_um_documento_NCDC '" & gs_empresa & "','" & dgv_pedidos.Item("RefTipoDocto", jj).Value & "','" & dgv_pedidos.Item("RefCorrelativo", jj).Value & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    linea = ""
                                    linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto2") & "-" & dt.Rows(0).Item("texto1") & "|" & dt.Rows(0).Item("numero") & "|" & Date.Parse(dt.Rows(0).Item("fecha").ToString).ToString("yyyyMMdd")
                                    lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                                End If
                                If dgv_pedidos.Item("documento", jj).Value = "Factura" Then
                                    linea = ""
                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_bruto, 2) & "|0|0|" & drv.DataView.Count & "|0"
                                    lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                                End If
                                If dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                                    linea = ""
                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_bruto, 2) & "|0|0|" & drv.DataView.Count & "|" & dt.Rows.Count
                                    lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                                End If
                            End If
                        End If


                    End If

                Next



                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub
    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        procesarInformacion()
        generarFiltro()
        'procesar_info()
        'procesar_inn()

    End Sub
    Private Sub procesar_inn()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim dr, dr2 As DataRow
        Dim linea As String = ""
        Dim tipo_documento As String = ""
        Dim ClsGen As New ClasesGenerales.General
        Dim _archivo As String = ""
        Dim lexito As Boolean
        Dim importe_bruto As Double
        Dim importe_neto As Double
        Dim importe_iva As Double
        Dim i As Integer
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim neto As Double
        Dim reemplazar As Boolean = False
        Dim vigencia As String = ""




        Try

            Try
                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Or Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Debito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then
                    If MessageBox.Show("Ya existe Informacion generada para el dia " & Me.dtp_fecha_inicio.Text & ", Desea Volver a Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        reemplazar = True
                    End If
                Else
                    reemplazar = True
                End If


            Catch ex As Exception

            End Try


            Otrans.open()
            i = 0

            If reemplazar Then


                For jj As Integer = 0 To dgv_pedidos.Rows.Count - 1
                    If dgv_pedidos.Item("enviar", jj).Value Then

                        If dgv_pedidos.Item("documento", jj).Value = "Factura" Then
                            tipo_documento = "CFACE"
                        ElseIf dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                            tipo_documento = "CNCE"
                        ElseIf dgv_pedidos.Item("documento", jj).Value = "Debito" Then
                            tipo_documento = "CNDE"
                        End If

                        'If dgv_pedidos.Item("serie", jj).Value <> "" And dgv_pedidos.Item("serie", jj).Value = "A" Then
                        'If dgv_pedidos.Item("serie", jj).Value <> "" And dgv_pedidos.Item("serie", jj).Value = "J" Then
                        If dgv_pedidos.Item("serie", jj).Value <> "" And dgv_pedidos.Item("serie", jj).Value = "A" Then
                            If dgv_pedidos.Item("vigencia", jj).Value = "S" Or dgv_pedidos.Item("vigencia", jj).Value = "N" Then

                                linea = "CNCE-5-A|" & dgv_pedidos.Item("numero", jj).Value & "|" & dgv_pedidos.Item("codlegal", jj).Value & "|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|DOCUMENTO ANULADO"
                                'linea += dgv_pedidos.Item("numero", jj).Value & "|" & dgv_pedidos.Item("codlegal", jj).Value & "|" & dgv_pedidos.Item("nombre_cliente", jj).Value & "|"
                                'linea += dgv_pedidos.Item("direccion", jj).Value & "|" & dgv_pedidos.Item("telefono", jj).Value & "|1|1|E||0|B|1||N"
                            Else
                                'linea = "1|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|" & tipo_documento & "|" & dgv_pedidos.Item("serie", jj).Value & "|"
                                'linea += dgv_pedidos.Item("numero", jj).Value & "|" & dgv_pedidos.Item("codlegal", jj).Value & "|" & dgv_pedidos.Item("nombre_cliente", jj).Value & "|"
                                'linea += dgv_pedidos.Item("direccion", jj).Value & "|" & dgv_pedidos.Item("telefono", jj).Value & "|1|1|A|" & Date.Parse(dgv_pedidos.Item("fecha", jj).Value).ToString("yyyyMMdd") & "|0|B|1|DOCUMENTO ANULADO|N"



                            End If




                            If dgv_pedidos.Item("documento", jj).Value = "Factura" And entro = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then

                                    Try
                                        System.IO.File.Delete("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt")
                                        entro = True
                                        _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                    Catch ex As Exception
                                    End Try

                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Factura\" & Me.dtp_fecha_inicio.Text.Replace("/", ""))
                                    entro = True
                                    _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                End If
                            End If




                            If dgv_pedidos.Item("documento", jj).Value = "Credito" And entro_c = False Then
                                If Directory.Exists("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "")) Then

                                    Try
                                        System.IO.File.Delete("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt")
                                        entro_c = True
                                        _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                    Catch ex As Exception
                                    End Try

                                Else
                                    System.IO.Directory.CreateDirectory("c:\aplicaciones\log\" & gs_empresa & "\Credito\" & Me.dtp_fecha_inicio.Text.Replace("/", ""))
                                    entro_c = True
                                    _archivo = "c:\aplicaciones\log\" & gs_empresa & "\" & dgv_pedidos.Item("documento", jj).Value & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & "\" & Me.dtp_fecha_inicio.Text.Replace("/", "") & ".txt"
                                End If
                            End If







                            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            '        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_pedidos.Item("numero", jj).Value & _
                            '                                                    "' and tipodocto  = '" & _
                            '                                                   dgv_pedidos.Item("tipodocto", jj).Value & _
                            '                                                   "' and empresa = '" & dgv_pedidos.Item("empresa", jj).Value & "'"


                            '        If dgv_pedidos.Item("documento", jj).Value <> "Debito" Then



                            '            Dim drv As DataRowView
                            '            drv = oDataSet.Tables("detalle_pedidos").DefaultView(0)
                            '            importe_bruto = 0
                            '            importe_neto = 0
                            '            importe_iva = 0




                            '            For j As Integer = 0 To drv.DataView.Count - 1
                            '                linea = ""
                            '                linea = "2|" & drv.DataView(j)("cantidad") & "|1|"
                            '                linea += drv.DataView(j)("Precio") & "|0|0|"
                            '                linea += drv.DataView(j)("subtotal") & "|0|"
                            '                linea += drv.DataView(j)("Neto") & "|"
                            '                linea += drv.DataView(j)("Impuesto") & "|0|" & drv.DataView(j)("subtotal") & "|"
                            '                linea += drv.DataView(j)("producto").ToString & "|" & drv.DataView(j)("glosa").ToString & "|"
                            '                linea += drv.DataView(j)("Impdist").ToString & "|" & drv.DataView(j)("psugerido").ToString

                            '                importe_bruto += drv.DataView(j)("subtotal")
                            '                importe_neto += drv.DataView(j)("Neto")
                            '                importe_iva += drv.DataView(j)("Impuesto")
                            '                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            '            Next
                            '            If dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                            '                ls_sql = "pa_sel_um_documento_NCDC '" & gs_empresa & "','" & dgv_pedidos.Item("RefTipoDocto", jj).Value & "','" & dgv_pedidos.Item("RefCorrelativo", jj).Value & "'"
                            '                dt = Otrans.Obtiene(ls_sql)
                            '                linea = ""
                            '                linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto2") & "-" & dt.Rows(0).Item("texto1") & "|" & dt.Rows(0).Item("numero") & "|" & Date.Parse(dt.Rows(0).Item("fecha").ToString).ToString("yyyyMMdd")
                            '                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            '            End If
                            '            If dgv_pedidos.Item("documento", jj).Value = "Factura" Then
                            '                linea = ""
                            '                linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_bruto, 2) & "|0|0|" & drv.DataView.Count & "|0"
                            '                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            '            End If
                            '            If dgv_pedidos.Item("documento", jj).Value = "Credito" Then
                            '                linea = ""
                            '                linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_bruto, 2) & "|0|0|" & drv.DataView.Count & "|" & dt.Rows.Count
                            '                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
                            '            End If
                            '        End If
                        End If


                    End If

                Next



                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub generarFiltro()
        Dim clgen As New ClasesGenerales.General
        Try
            ods.Tables("pedidos").DefaultView.RowFilter = "Documento = '" & Me.cmb_tipododcto.Text & "'"
            Me.dgv_pedidos.DataSource = ods.Tables("pedidos")
            Me.dgv_pedidos.Refresh()
            clgen.Alinear_GridView(ods.Tables("pedidos"), dgv_pedidos, "", "", "", "", "", "", "", True, True, 200, 0)
            clgen = Nothing

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Pedidos_Pendientes()
        generarFiltro()
    End Sub


    Private Sub cmb_tipododcto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_tipododcto.SelectedValueChanged
        generarFiltro()
    End Sub


    Private Sub dgv_pedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pedidos.CellContentClick

    End Sub

    Private Sub dgv_pedidos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_pedidos.DataError

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgv_detalle_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_detalle.DataError

    End Sub

    Private Sub cmb_tipododcto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipododcto.SelectedIndexChanged

    End Sub

    Private Sub chk_marcar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_marcar.CheckedChanged
        If Me.chk_marcar.Checked Then
            For Each dr As DataRow In ods.Tables("pedidos").Rows
                dr.Item("Enviar") = True
            Next
        Else
            For Each dr As DataRow In ods.Tables("pedidos").Rows
                dr.Item("Enviar") = False
            Next
        End If
    End Sub
End Class