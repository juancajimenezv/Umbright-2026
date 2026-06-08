<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cancelacion_Contados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cancelacion_Contados))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cb_Ubicacion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtp_FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Continuar = New System.Windows.Forms.Button()
        Me.cb_Tienda = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.cb_Serie = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_Facturas = New System.Windows.Forms.DataGridView()
        Me.tb_Glosa = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tb_ClienteC = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lb_Diferencia = New System.Windows.Forms.Label()
        Me.tb_Monto = New System.Windows.Forms.TextBox()
        Me.tb_deposito = New System.Windows.Forms.TextBox()
        Me.btn_ProcesarC = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_SubTotal = New System.Windows.Forms.Label()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.lb_Mensaje = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Operacion = New System.Windows.Forms.ComboBox()
        Me.lb_TotalDepositos = New System.Windows.Forms.Label()
        Me.dgv_Deposito = New System.Windows.Forms.DataGridView()
        Me.lb_checkDep = New System.Windows.Forms.Label()
        Me.btn_Deposito = New System.Windows.Forms.Button()
        Me.dtp_Fecha_Operacion = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_DepositoGeneral = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_Operacion = New System.Windows.Forms.Label()
        Me.lb_Cuenta = New System.Windows.Forms.Label()
        Me.lb_TipoPago = New System.Windows.Forms.Label()
        Me.lb_DH = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Deposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cb_Ubicacion)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.dtp_FechaFinal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btn_Cancelar)
        Me.GroupBox1.Controls.Add(Me.btn_Continuar)
        Me.GroupBox1.Controls.Add(Me.cb_Tienda)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox1.Controls.Add(Me.cb_Serie)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 98)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proceso"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(54, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Actualizada: 29/09/2021"
        '
        'cb_Ubicacion
        '
        Me.cb_Ubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Ubicacion.FormattingEnabled = True
        Me.cb_Ubicacion.Location = New System.Drawing.Point(255, 14)
        Me.cb_Ubicacion.Name = "cb_Ubicacion"
        Me.cb_Ubicacion.Size = New System.Drawing.Size(164, 21)
        Me.cb_Ubicacion.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(193, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Ubicación:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(187, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 13)
        Me.Label24.TabIndex = 12
        Me.Label24.Text = "Documento:"
        '
        'dtp_FechaFinal
        '
        Me.dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaFinal.Location = New System.Drawing.Point(80, 53)
        Me.dtp_FechaFinal.Name = "dtp_FechaFinal"
        Me.dtp_FechaFinal.Size = New System.Drawing.Size(100, 20)
        Me.dtp_FechaFinal.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Fecha Final:"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Cancelar.Location = New System.Drawing.Point(453, 21)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 23)
        Me.btn_Cancelar.TabIndex = 6
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Continuar
        '
        Me.btn_Continuar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Continuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Continuar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Continuar.Location = New System.Drawing.Point(453, 53)
        Me.btn_Continuar.Name = "btn_Continuar"
        Me.btn_Continuar.Size = New System.Drawing.Size(74, 23)
        Me.btn_Continuar.TabIndex = 6
        Me.btn_Continuar.Text = "Continuar"
        Me.btn_Continuar.UseVisualStyleBackColor = False
        '
        'cb_Tienda
        '
        Me.cb_Tienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Tienda.FormattingEnabled = True
        Me.cb_Tienda.Location = New System.Drawing.Point(255, 41)
        Me.cb_Tienda.Name = "cb_Tienda"
        Me.cb_Tienda.Size = New System.Drawing.Size(164, 21)
        Me.cb_Tienda.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tienda:"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(81, 22)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(99, 20)
        Me.dtp_Fecha.TabIndex = 1
        '
        'cb_Serie
        '
        Me.cb_Serie.AutoCompleteCustomSource.AddRange(New String() {"FACTURA SERIE A-2"})
        Me.cb_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Serie.FormattingEnabled = True
        Me.cb_Serie.Location = New System.Drawing.Point(255, 67)
        Me.cb_Serie.Name = "cb_Serie"
        Me.cb_Serie.Size = New System.Drawing.Size(164, 21)
        Me.cb_Serie.TabIndex = 5
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgv_Facturas)
        Me.GroupBox6.Location = New System.Drawing.Point(10, 108)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(725, 210)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Detalle Contado"
        '
        'dgv_Facturas
        '
        Me.dgv_Facturas.AllowUserToAddRows = False
        Me.dgv_Facturas.AllowUserToOrderColumns = True
        Me.dgv_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Facturas.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Facturas.Name = "dgv_Facturas"
        Me.dgv_Facturas.RowHeadersWidth = 51
        Me.dgv_Facturas.ShowCellErrors = False
        Me.dgv_Facturas.Size = New System.Drawing.Size(713, 185)
        Me.dgv_Facturas.TabIndex = 8
        '
        'tb_Glosa
        '
        Me.tb_Glosa.Location = New System.Drawing.Point(300, 73)
        Me.tb_Glosa.Name = "tb_Glosa"
        Me.tb_Glosa.Size = New System.Drawing.Size(227, 20)
        Me.tb_Glosa.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(303, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Glosa:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(209, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Cte/Per/Prov:"
        '
        'tb_ClienteC
        '
        Me.tb_ClienteC.Location = New System.Drawing.Point(206, 73)
        Me.tb_ClienteC.Name = "tb_ClienteC"
        Me.tb_ClienteC.Size = New System.Drawing.Size(88, 20)
        Me.tb_ClienteC.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(129, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Monto:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(661, 428)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Diferencia"
        '
        'lb_Diferencia
        '
        Me.lb_Diferencia.AutoSize = True
        Me.lb_Diferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Diferencia.Location = New System.Drawing.Point(676, 446)
        Me.lb_Diferencia.Name = "lb_Diferencia"
        Me.lb_Diferencia.Size = New System.Drawing.Size(44, 20)
        Me.lb_Diferencia.TabIndex = 13
        Me.lb_Diferencia.Text = "0.00"
        '
        'tb_Monto
        '
        Me.tb_Monto.Location = New System.Drawing.Point(125, 73)
        Me.tb_Monto.Name = "tb_Monto"
        Me.tb_Monto.Size = New System.Drawing.Size(75, 20)
        Me.tb_Monto.TabIndex = 22
        Me.tb_Monto.Text = "0.00"
        Me.tb_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_deposito
        '
        Me.tb_deposito.Location = New System.Drawing.Point(13, 73)
        Me.tb_deposito.Name = "tb_deposito"
        Me.tb_deposito.Size = New System.Drawing.Size(106, 20)
        Me.tb_deposito.TabIndex = 21
        '
        'btn_ProcesarC
        '
        Me.btn_ProcesarC.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ProcesarC.Enabled = False
        Me.btn_ProcesarC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_ProcesarC.Location = New System.Drawing.Point(660, 340)
        Me.btn_ProcesarC.Name = "btn_ProcesarC"
        Me.btn_ProcesarC.Size = New System.Drawing.Size(75, 52)
        Me.btn_ProcesarC.TabIndex = 2
        Me.btn_ProcesarC.Text = "Procesar.."
        Me.btn_ProcesarC.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(470, 328)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Sub Total      Q."
        '
        'lb_SubTotal
        '
        Me.lb_SubTotal.AutoSize = True
        Me.lb_SubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_SubTotal.Location = New System.Drawing.Point(558, 326)
        Me.lb_SubTotal.Name = "lb_SubTotal"
        Me.lb_SubTotal.Size = New System.Drawing.Size(40, 18)
        Me.lb_SubTotal.TabIndex = 13
        Me.lb_SubTotal.Text = "0.00"
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(389, 323)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Agregar.TabIndex = 8
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'lb_Mensaje
        '
        Me.lb_Mensaje.AutoSize = True
        Me.lb_Mensaje.Location = New System.Drawing.Point(645, 97)
        Me.lb_Mensaje.Name = "lb_Mensaje"
        Me.lb_Mensaje.Size = New System.Drawing.Size(39, 13)
        Me.lb_Mensaje.TabIndex = 15
        Me.lb_Mensaje.Text = "Label4"
        Me.lb_Mensaje.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tb_Glosa)
        Me.GroupBox3.Controls.Add(Me.cb_Operacion)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lb_TotalDepositos)
        Me.GroupBox3.Controls.Add(Me.dgv_Deposito)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.lb_checkDep)
        Me.GroupBox3.Controls.Add(Me.tb_ClienteC)
        Me.GroupBox3.Controls.Add(Me.btn_Deposito)
        Me.GroupBox3.Controls.Add(Me.tb_deposito)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.tb_Monto)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 352)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(632, 195)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Operación:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Depósito:"
        '
        'cb_Operacion
        '
        Me.cb_Operacion.FormattingEnabled = True
        Me.cb_Operacion.Location = New System.Drawing.Point(10, 28)
        Me.cb_Operacion.Name = "cb_Operacion"
        Me.cb_Operacion.Size = New System.Drawing.Size(552, 21)
        Me.cb_Operacion.TabIndex = 20
        '
        'lb_TotalDepositos
        '
        Me.lb_TotalDepositos.AutoSize = True
        Me.lb_TotalDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_TotalDepositos.Location = New System.Drawing.Point(569, 167)
        Me.lb_TotalDepositos.Name = "lb_TotalDepositos"
        Me.lb_TotalDepositos.Size = New System.Drawing.Size(40, 17)
        Me.lb_TotalDepositos.TabIndex = 17
        Me.lb_TotalDepositos.Text = "0.00"
        '
        'dgv_Deposito
        '
        Me.dgv_Deposito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Deposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Deposito.Location = New System.Drawing.Point(13, 99)
        Me.dgv_Deposito.Name = "dgv_Deposito"
        Me.dgv_Deposito.RowHeadersWidth = 51
        Me.dgv_Deposito.Size = New System.Drawing.Size(549, 87)
        Me.dgv_Deposito.TabIndex = 17
        '
        'lb_checkDep
        '
        Me.lb_checkDep.AutoSize = True
        Me.lb_checkDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_checkDep.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lb_checkDep.Location = New System.Drawing.Point(568, 76)
        Me.lb_checkDep.Name = "lb_checkDep"
        Me.lb_checkDep.Size = New System.Drawing.Size(15, 16)
        Me.lb_checkDep.TabIndex = 17
        Me.lb_checkDep.Text = "√"
        '
        'btn_Deposito
        '
        Me.btn_Deposito.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Deposito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Deposito.Location = New System.Drawing.Point(533, 71)
        Me.btn_Deposito.Name = "btn_Deposito"
        Me.btn_Deposito.Size = New System.Drawing.Size(29, 23)
        Me.btn_Deposito.TabIndex = 25
        Me.btn_Deposito.Text = "Ok"
        Me.btn_Deposito.UseVisualStyleBackColor = False
        '
        'dtp_Fecha_Operacion
        '
        Me.dtp_Fecha_Operacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha_Operacion.Location = New System.Drawing.Point(622, 32)
        Me.dtp_Fecha_Operacion.Name = "dtp_Fecha_Operacion"
        Me.dtp_Fecha_Operacion.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Fecha_Operacion.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(627, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Fecha Operación"
        '
        'tb_DepositoGeneral
        '
        Me.tb_DepositoGeneral.Location = New System.Drawing.Point(622, 74)
        Me.tb_DepositoGeneral.Name = "tb_DepositoGeneral"
        Me.tb_DepositoGeneral.Size = New System.Drawing.Size(100, 20)
        Me.tb_DepositoGeneral.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(645, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Deposito"
        '
        'lb_Operacion
        '
        Me.lb_Operacion.AutoSize = True
        Me.lb_Operacion.Location = New System.Drawing.Point(19, 329)
        Me.lb_Operacion.Name = "lb_Operacion"
        Me.lb_Operacion.Size = New System.Drawing.Size(56, 13)
        Me.lb_Operacion.TabIndex = 21
        Me.lb_Operacion.Text = "Operacion"
        Me.lb_Operacion.Visible = False
        '
        'lb_Cuenta
        '
        Me.lb_Cuenta.AutoSize = True
        Me.lb_Cuenta.Location = New System.Drawing.Point(113, 329)
        Me.lb_Cuenta.Name = "lb_Cuenta"
        Me.lb_Cuenta.Size = New System.Drawing.Size(41, 13)
        Me.lb_Cuenta.TabIndex = 22
        Me.lb_Cuenta.Text = "Cuenta"
        Me.lb_Cuenta.Visible = False
        '
        'lb_TipoPago
        '
        Me.lb_TipoPago.AutoSize = True
        Me.lb_TipoPago.Location = New System.Drawing.Point(207, 329)
        Me.lb_TipoPago.Name = "lb_TipoPago"
        Me.lb_TipoPago.Size = New System.Drawing.Size(53, 13)
        Me.lb_TipoPago.TabIndex = 23
        Me.lb_TipoPago.Text = "TipoPago"
        Me.lb_TipoPago.Visible = False
        '
        'lb_DH
        '
        Me.lb_DH.AutoSize = True
        Me.lb_DH.Location = New System.Drawing.Point(325, 328)
        Me.lb_DH.Name = "lb_DH"
        Me.lb_DH.Size = New System.Drawing.Size(19, 13)
        Me.lb_DH.TabIndex = 24
        Me.lb_DH.Text = "dh"
        Me.lb_DH.Visible = False
        '
        'Frm_Cancelacion_Contados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(750, 555)
        Me.Controls.Add(Me.lb_DH)
        Me.Controls.Add(Me.lb_TipoPago)
        Me.Controls.Add(Me.lb_Cuenta)
        Me.Controls.Add(Me.lb_Operacion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_DepositoGeneral)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_Fecha_Operacion)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lb_Mensaje)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.lb_Diferencia)
        Me.Controls.Add(Me.lb_SubTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_ProcesarC)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Cancelacion_Contados"
        Me.Text = "Cancelación de Compromisos 250722"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_Deposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Continuar As System.Windows.Forms.Button
    Friend WithEvents cb_Tienda As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_Serie As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Facturas As System.Windows.Forms.DataGridView
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lb_Diferencia As System.Windows.Forms.Label
    Friend WithEvents tb_ClienteC As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents tb_deposito As System.Windows.Forms.TextBox
    Friend WithEvents btn_ProcesarC As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_SubTotal As System.Windows.Forms.Label
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents lb_Mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Deposito As System.Windows.Forms.Button
    Friend WithEvents lb_checkDep As System.Windows.Forms.Label
    Friend WithEvents dgv_Deposito As System.Windows.Forms.DataGridView
    Friend WithEvents lb_TotalDepositos As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha_Operacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_Glosa As System.Windows.Forms.TextBox
    Friend WithEvents tb_DepositoGeneral As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_Ubicacion As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cb_Operacion As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lb_Operacion As Label
    Friend WithEvents lb_Cuenta As Label
    Friend WithEvents lb_TipoPago As Label
    Friend WithEvents lb_DH As Label
    Friend WithEvents Label9 As Label
End Class
