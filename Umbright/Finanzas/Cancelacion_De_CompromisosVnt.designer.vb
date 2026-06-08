<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cancelacion_De_CompromisosVnt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cancelacion_De_CompromisosVnt))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Continuar = New System.Windows.Forms.Button()
        Me.cb_FormaPago = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_Tienda = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tb_ClienteC = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb_CuentaContable = New System.Windows.Forms.ComboBox()
        Me.tb_SobraFalta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_Deposito2C = New System.Windows.Forms.TextBox()
        Me.tb_MontoC = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_depositoC = New System.Windows.Forms.TextBox()
        Me.btn_ProcesarC = New System.Windows.Forms.Button()
        Me.cb_Serie = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_Propina2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.label = New System.Windows.Forms.Label()
        Me.tb_ClienteT = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tb_Propina = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_FaltaSobreT = New System.Windows.Forms.ComboBox()
        Me.tb_MontoSFt = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_Monto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_DepositoT2 = New System.Windows.Forms.TextBox()
        Me.btnVisaNet = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.clb_Series = New System.Windows.Forms.CheckedListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_DepositoT = New System.Windows.Forms.TextBox()
        Me.btn_ProcesarT = New System.Windows.Forms.Button()
        Me.cb_Pos = New System.Windows.Forms.ComboBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_GeneraFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Genera = New System.Windows.Forms.DateTimePicker()
        Me.btn_Genera = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtp_FechaActualiza = New System.Windows.Forms.DateTimePicker()
        Me.tb_DepActualiza = New System.Windows.Forms.TextBox()
        Me.l_Deposito = New System.Windows.Forms.Label()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicial:"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(116, 31)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(99, 20)
        Me.dtp_Fecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tienda:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_FechaFinal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btn_Cancelar)
        Me.GroupBox1.Controls.Add(Me.btn_Continuar)
        Me.GroupBox1.Controls.Add(Me.cb_FormaPago)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cb_Tienda)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 154)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proceso"
        '
        'dtp_FechaFinal
        '
        Me.dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaFinal.Location = New System.Drawing.Point(392, 31)
        Me.dtp_FechaFinal.Name = "dtp_FechaFinal"
        Me.dtp_FechaFinal.Size = New System.Drawing.Size(97, 20)
        Me.dtp_FechaFinal.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(325, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Fecha Final:"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Location = New System.Drawing.Point(415, 74)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 23)
        Me.btn_Cancelar.TabIndex = 6
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_Continuar
        '
        Me.btn_Continuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Continuar.Location = New System.Drawing.Point(414, 112)
        Me.btn_Continuar.Name = "btn_Continuar"
        Me.btn_Continuar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Continuar.TabIndex = 5
        Me.btn_Continuar.Text = "Continuar"
        Me.btn_Continuar.UseVisualStyleBackColor = True
        '
        'cb_FormaPago
        '
        Me.cb_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_FormaPago.FormattingEnabled = True
        Me.cb_FormaPago.Items.AddRange(New Object() {"CONTADO", "TARJETA"})
        Me.cb_FormaPago.Location = New System.Drawing.Point(116, 112)
        Me.cb_FormaPago.Name = "cb_FormaPago"
        Me.cb_FormaPago.Size = New System.Drawing.Size(222, 21)
        Me.cb_FormaPago.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Forma de Pago:"
        '
        'cb_Tienda
        '
        Me.cb_Tienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Tienda.FormattingEnabled = True
        Me.cb_Tienda.Items.AddRange(New Object() {"DELI 10", "DELI 14", "RESTAURANTE FB", "TELEMERCADEO 10", "VENTA DIRECTA 10", "VENTA DIRECTA 14", "VENTA DIRECTA MF", "VENTA DIRECTA PC"})
        Me.cb_Tienda.Location = New System.Drawing.Point(116, 74)
        Me.cb_Tienda.Name = "cb_Tienda"
        Me.cb_Tienda.Size = New System.Drawing.Size(222, 21)
        Me.cb_Tienda.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.tb_ClienteC)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cb_CuentaContable)
        Me.GroupBox2.Controls.Add(Me.tb_SobraFalta)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.tb_Deposito2C)
        Me.GroupBox2.Controls.Add(Me.tb_MontoC)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.tb_depositoC)
        Me.GroupBox2.Controls.Add(Me.btn_ProcesarC)
        Me.GroupBox2.Controls.Add(Me.cb_Serie)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(34, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 109)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contado"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(477, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Cliente/Personal:"
        '
        'tb_ClienteC
        '
        Me.tb_ClienteC.Location = New System.Drawing.Point(478, 83)
        Me.tb_ClienteC.Name = "tb_ClienteC"
        Me.tb_ClienteC.Size = New System.Drawing.Size(79, 20)
        Me.tb_ClienteC.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(310, 86)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Monto s/f:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(131, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Movimiento"
        '
        'cb_CuentaContable
        '
        Me.cb_CuentaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CuentaContable.FormattingEnabled = True
        Me.cb_CuentaContable.Items.AddRange(New Object() {"", "FALTANTE", "SOBRANTE", "ANTICIPO", "DOLARES"})
        Me.cb_CuentaContable.Location = New System.Drawing.Point(194, 82)
        Me.cb_CuentaContable.Name = "cb_CuentaContable"
        Me.cb_CuentaContable.Size = New System.Drawing.Size(113, 21)
        Me.cb_CuentaContable.TabIndex = 10
        '
        'tb_SobraFalta
        '
        Me.tb_SobraFalta.Location = New System.Drawing.Point(368, 83)
        Me.tb_SobraFalta.Name = "tb_SobraFalta"
        Me.tb_SobraFalta.Size = New System.Drawing.Size(105, 20)
        Me.tb_SobraFalta.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(326, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Monto:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(131, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Depósito 2:"
        '
        'tb_Deposito2C
        '
        Me.tb_Deposito2C.Location = New System.Drawing.Point(194, 56)
        Me.tb_Deposito2C.Name = "tb_Deposito2C"
        Me.tb_Deposito2C.Size = New System.Drawing.Size(113, 20)
        Me.tb_Deposito2C.TabIndex = 6
        '
        'tb_MontoC
        '
        Me.tb_MontoC.Location = New System.Drawing.Point(368, 56)
        Me.tb_MontoC.Name = "tb_MontoC"
        Me.tb_MontoC.Size = New System.Drawing.Size(105, 20)
        Me.tb_MontoC.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(313, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Deposito:"
        '
        'tb_depositoC
        '
        Me.tb_depositoC.Location = New System.Drawing.Point(368, 27)
        Me.tb_depositoC.Name = "tb_depositoC"
        Me.tb_depositoC.Size = New System.Drawing.Size(105, 20)
        Me.tb_depositoC.TabIndex = 3
        '
        'btn_ProcesarC
        '
        Me.btn_ProcesarC.Enabled = False
        Me.btn_ProcesarC.Location = New System.Drawing.Point(479, 24)
        Me.btn_ProcesarC.Name = "btn_ProcesarC"
        Me.btn_ProcesarC.Size = New System.Drawing.Size(75, 23)
        Me.btn_ProcesarC.TabIndex = 2
        Me.btn_ProcesarC.Text = "Procesar.."
        Me.btn_ProcesarC.UseVisualStyleBackColor = True
        '
        'cb_Serie
        '
        Me.cb_Serie.AutoCompleteCustomSource.AddRange(New String() {"FACTURA SERIE A-2"})
        Me.cb_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Serie.FormattingEnabled = True
        Me.cb_Serie.Location = New System.Drawing.Point(112, 26)
        Me.cb_Serie.Name = "cb_Serie"
        Me.cb_Serie.Size = New System.Drawing.Size(195, 21)
        Me.cb_Serie.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Serie Factura:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tb_Propina2)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.label)
        Me.GroupBox3.Controls.Add(Me.tb_ClienteT)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.tb_Propina)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.tb_FaltaSobreT)
        Me.GroupBox3.Controls.Add(Me.tb_MontoSFt)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.tb_Monto)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tb_DepositoT2)
        Me.GroupBox3.Controls.Add(Me.btnVisaNet)
        Me.GroupBox3.Controls.Add(Me.clb_Series)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.tb_DepositoT)
        Me.GroupBox3.Controls.Add(Me.btn_ProcesarT)
        Me.GroupBox3.Controls.Add(Me.cb_Pos)
        Me.GroupBox3.Controls.Add(Me.label5)
        Me.GroupBox3.Location = New System.Drawing.Point(34, 287)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(563, 214)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tarjeta"
        '
        'tb_Propina2
        '
        Me.tb_Propina2.Location = New System.Drawing.Point(397, 138)
        Me.tb_Propina2.Name = "tb_Propina2"
        Me.tb_Propina2.Size = New System.Drawing.Size(81, 20)
        Me.tb_Propina2.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(353, 106)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Propina:"
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(369, 176)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(88, 13)
        Me.label.TabIndex = 20
        Me.label.Text = "Cliente/Personal:"
        '
        'tb_ClienteT
        '
        Me.tb_ClienteT.Location = New System.Drawing.Point(458, 173)
        Me.tb_ClienteT.Name = "tb_ClienteT"
        Me.tb_ClienteT.Size = New System.Drawing.Size(92, 20)
        Me.tb_ClienteT.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(353, 141)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Propina:"
        '
        'tb_Propina
        '
        Me.tb_Propina.Location = New System.Drawing.Point(397, 103)
        Me.tb_Propina.Name = "tb_Propina"
        Me.tb_Propina.Size = New System.Drawing.Size(81, 20)
        Me.tb_Propina.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(38, 177)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Movimiento:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(215, 177)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Monto s/f:"
        '
        'tb_FaltaSobreT
        '
        Me.tb_FaltaSobreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_FaltaSobreT.FormattingEnabled = True
        Me.tb_FaltaSobreT.Items.AddRange(New Object() {"", "FALTANTE", "SOBRANTE"})
        Me.tb_FaltaSobreT.Location = New System.Drawing.Point(103, 173)
        Me.tb_FaltaSobreT.Name = "tb_FaltaSobreT"
        Me.tb_FaltaSobreT.Size = New System.Drawing.Size(112, 21)
        Me.tb_FaltaSobreT.TabIndex = 14
        '
        'tb_MontoSFt
        '
        Me.tb_MontoSFt.Location = New System.Drawing.Point(272, 173)
        Me.tb_MontoSFt.Name = "tb_MontoSFt"
        Me.tb_MontoSFt.Size = New System.Drawing.Size(78, 20)
        Me.tb_MontoSFt.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(230, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Monto:"
        '
        'tb_Monto
        '
        Me.tb_Monto.Location = New System.Drawing.Point(272, 139)
        Me.tb_Monto.Name = "tb_Monto"
        Me.tb_Monto.Size = New System.Drawing.Size(78, 20)
        Me.tb_Monto.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(60, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Depósito 2:"
        '
        'tb_DepositoT2
        '
        Me.tb_DepositoT2.Location = New System.Drawing.Point(121, 139)
        Me.tb_DepositoT2.Name = "tb_DepositoT2"
        Me.tb_DepositoT2.Size = New System.Drawing.Size(94, 20)
        Me.tb_DepositoT2.TabIndex = 9
        '
        'btnVisaNet
        '
        Me.btnVisaNet.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVisaNet.ImageIndex = 2
        Me.btnVisaNet.ImageList = Me.ImageList1
        Me.btnVisaNet.Location = New System.Drawing.Point(59, 21)
        Me.btnVisaNet.Name = "btnVisaNet"
        Me.btnVisaNet.Size = New System.Drawing.Size(43, 34)
        Me.btnVisaNet.TabIndex = 7
        Me.btnVisaNet.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "update.png")
        Me.ImageList1.Images.SetKeyName(1, "Actualizar.png")
        Me.ImageList1.Images.SetKeyName(2, "visa.png")
        Me.ImageList1.Images.SetKeyName(3, "Actualizar_Blue.png")
        Me.ImageList1.Images.SetKeyName(4, "money.gif")
        '
        'clb_Series
        '
        Me.clb_Series.FormattingEnabled = True
        Me.clb_Series.Location = New System.Drawing.Point(116, 19)
        Me.clb_Series.Name = "clb_Series"
        Me.clb_Series.Size = New System.Drawing.Size(438, 64)
        Me.clb_Series.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.ImageKey = "Actualizar.png"
        Me.Button4.Location = New System.Drawing.Point(59, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 34)
        Me.Button4.TabIndex = 8
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Depósito:"
        '
        'tb_DepositoT
        '
        Me.tb_DepositoT.Location = New System.Drawing.Point(272, 103)
        Me.tb_DepositoT.Name = "tb_DepositoT"
        Me.tb_DepositoT.Size = New System.Drawing.Size(78, 20)
        Me.tb_DepositoT.TabIndex = 4
        '
        'btn_ProcesarT
        '
        Me.btn_ProcesarT.Location = New System.Drawing.Point(481, 101)
        Me.btn_ProcesarT.Name = "btn_ProcesarT"
        Me.btn_ProcesarT.Size = New System.Drawing.Size(75, 23)
        Me.btn_ProcesarT.TabIndex = 2
        Me.btn_ProcesarT.Text = "Procesar.."
        Me.btn_ProcesarT.UseVisualStyleBackColor = True
        '
        'cb_Pos
        '
        Me.cb_Pos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Pos.FormattingEnabled = True
        Me.cb_Pos.Items.AddRange(New Object() {"POS CREDOMATIC", "POS VISA NET"})
        Me.cb_Pos.Location = New System.Drawing.Point(62, 103)
        Me.cb_Pos.Name = "cb_Pos"
        Me.cb_Pos.Size = New System.Drawing.Size(153, 21)
        Me.cb_Pos.TabIndex = 1
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(10, 25)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(45, 20)
        Me.label5.TabIndex = 0
        Me.label5.Text = "POS"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.dtp_GeneraFinal)
        Me.GroupBox4.Controls.Add(Me.dtp_Genera)
        Me.GroupBox4.Controls.Add(Me.btn_Genera)
        Me.GroupBox4.Location = New System.Drawing.Point(626, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(136, 227)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generar Información"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Fecha Final:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Fecha Inicial:"
        '
        'dtp_GeneraFinal
        '
        Me.dtp_GeneraFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_GeneraFinal.Location = New System.Drawing.Point(24, 77)
        Me.dtp_GeneraFinal.Name = "dtp_GeneraFinal"
        Me.dtp_GeneraFinal.Size = New System.Drawing.Size(90, 20)
        Me.dtp_GeneraFinal.TabIndex = 2
        '
        'dtp_Genera
        '
        Me.dtp_Genera.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_Genera.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtp_Genera.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Genera.Location = New System.Drawing.Point(24, 35)
        Me.dtp_Genera.Name = "dtp_Genera"
        Me.dtp_Genera.Size = New System.Drawing.Size(92, 20)
        Me.dtp_Genera.TabIndex = 1
        '
        'btn_Genera
        '
        Me.btn_Genera.ImageIndex = 3
        Me.btn_Genera.ImageList = Me.ImageList1
        Me.btn_Genera.Location = New System.Drawing.Point(24, 109)
        Me.btn_Genera.Name = "btn_Genera"
        Me.btn_Genera.Size = New System.Drawing.Size(92, 99)
        Me.btn_Genera.TabIndex = 0
        Me.btn_Genera.Text = ".."
        Me.btn_Genera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Genera.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtp_FechaActualiza)
        Me.GroupBox5.Controls.Add(Me.tb_DepActualiza)
        Me.GroupBox5.Controls.Add(Me.l_Deposito)
        Me.GroupBox5.Controls.Add(Me.btn_Actualiza)
        Me.GroupBox5.Location = New System.Drawing.Point(626, 306)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(135, 193)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Actualizar Deposito:"
        '
        'dtp_FechaActualiza
        '
        Me.dtp_FechaActualiza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaActualiza.Location = New System.Drawing.Point(24, 50)
        Me.dtp_FechaActualiza.Name = "dtp_FechaActualiza"
        Me.dtp_FechaActualiza.Size = New System.Drawing.Size(90, 20)
        Me.dtp_FechaActualiza.TabIndex = 3
        '
        'tb_DepActualiza
        '
        Me.tb_DepActualiza.Location = New System.Drawing.Point(24, 23)
        Me.tb_DepActualiza.Name = "tb_DepActualiza"
        Me.tb_DepActualiza.Size = New System.Drawing.Size(90, 20)
        Me.tb_DepActualiza.TabIndex = 2
        '
        'l_Deposito
        '
        Me.l_Deposito.AutoSize = True
        Me.l_Deposito.Location = New System.Drawing.Point(50, 112)
        Me.l_Deposito.Name = "l_Deposito"
        Me.l_Deposito.Size = New System.Drawing.Size(0, 13)
        Me.l_Deposito.TabIndex = 1
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.ImageKey = "update.png"
        Me.btn_Actualiza.ImageList = Me.ImageList1
        Me.btn_Actualiza.Location = New System.Drawing.Point(24, 76)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(92, 103)
        Me.btn_Actualiza.TabIndex = 0
        Me.btn_Actualiza.Text = ".."
        Me.btn_Actualiza.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(672, 259)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "27.08.14."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(657, 258)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 13)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "v."
        '
        'Cancelacion_De_CompromisosVnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 511)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cancelacion_De_CompromisosVnt"
        Me.Text = "Cancelación De Compromisos Vnt"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Tienda As System.Windows.Forms.ComboBox
    Friend WithEvents cb_FormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Serie As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Continuar As System.Windows.Forms.Button
    Friend WithEvents cb_Pos As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ProcesarC As System.Windows.Forms.Button
    Friend WithEvents btn_ProcesarT As System.Windows.Forms.Button
    Friend WithEvents tb_depositoC As System.Windows.Forms.TextBox
    Friend WithEvents tb_DepositoT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Genera As System.Windows.Forms.Button
    Friend WithEvents dtp_Genera As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
    Friend WithEvents btnVisaNet As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents l_Deposito As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_GeneraFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents clb_Series As System.Windows.Forms.CheckedListBox
    Friend WithEvents dtp_FechaActualiza As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_DepActualiza As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_DepositoT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tb_Deposito2C As System.Windows.Forms.TextBox
    Friend WithEvents tb_MontoC As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_SobraFalta As System.Windows.Forms.TextBox
    Friend WithEvents cb_CuentaContable As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_FaltaSobreT As System.Windows.Forms.ComboBox
    Friend WithEvents tb_MontoSFt As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tb_Propina As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tb_ClienteC As System.Windows.Forms.TextBox
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents tb_ClienteT As System.Windows.Forms.TextBox
    Friend WithEvents tb_Propina2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
