Imports System.Math
Public Class frm_OCconfirmacion
    Inherits System.Windows.Forms.Form

    Dim ds As New DataSet


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
    Friend WithEvents lbl_vigencia As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_moc_valores As System.Windows.Forms.TextBox
    Friend WithEvents txt_moc_lineas As System.Windows.Forms.TextBox
    Friend WithEvents txt_moc_unidades As System.Windows.Forms.TextBox
    Friend WithEvents txt_moc_moneda As System.Windows.Forms.TextBox
    Friend WithEvents txt_moc_paridad As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txt_moc_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_moc_comentario As System.Windows.Forms.TextBox
    Friend WithEvents btn_aplicar_moc As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents dtp_mov_fecha_despacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_moc_fechavencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents dg_moc_productos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_moc_nuevo As System.Windows.Forms.Button
    Friend WithEvents txt_moc_numeroOC As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMotivoFechaDespacho As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaDespachoActualizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnAplicarFechaDespacho As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroOCDespacho As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtComentarioProduccion As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaProduccionActualizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnAplicarFechaProduccion As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroOCProduccion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnumeroOCCreditos As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnAplicarOCCreditos As System.Windows.Forms.Button
    Friend WithEvents txtComentarioOCCreditos As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoOCCreditos As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtValores As System.Windows.Forms.TextBox
    Friend WithEvents txtLineas As System.Windows.Forms.TextBox
    Friend WithEvents txtUnidades As System.Windows.Forms.TextBox
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtParidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtComentarioConfirmacion As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaVencimientoConfirmacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnOCPendientes As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroOC As System.Windows.Forms.TextBox
    Friend WithEvents dgvProductosOC As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label27 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OCconfirmacion))
        Me.lbl_vigencia = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt_moc_valores = New System.Windows.Forms.TextBox()
        Me.txt_moc_lineas = New System.Windows.Forms.TextBox()
        Me.txt_moc_unidades = New System.Windows.Forms.TextBox()
        Me.txt_moc_moneda = New System.Windows.Forms.TextBox()
        Me.txt_moc_paridad = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txt_moc_proveedor = New System.Windows.Forms.TextBox()
        Me.txt_moc_comentario = New System.Windows.Forms.TextBox()
        Me.btn_aplicar_moc = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.dtp_mov_fecha_despacho = New System.Windows.Forms.DateTimePicker()
        Me.dtp_moc_fechavencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dg_moc_productos = New System.Windows.Forms.DataGridView()
        Me.btn_moc_nuevo = New System.Windows.Forms.Button()
        Me.txt_moc_numeroOC = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtMotivoFechaDespacho = New System.Windows.Forms.TextBox()
        Me.dtpFechaDespachoActualizacion = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnAplicarFechaDespacho = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNumeroOCDespacho = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtComentarioProduccion = New System.Windows.Forms.TextBox()
        Me.dtpFechaProduccionActualizacion = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnAplicarFechaProduccion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNumeroOCProduccion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnumeroOCCreditos = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnAplicarOCCreditos = New System.Windows.Forms.Button()
        Me.txtComentarioOCCreditos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbEstadoOCCreditos = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValores = New System.Windows.Forms.TextBox()
        Me.txtLineas = New System.Windows.Forms.TextBox()
        Me.txtUnidades = New System.Windows.Forms.TextBox()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.txtParidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtComentarioConfirmacion = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFechaDespacho = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaVencimientoConfirmacion = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnOCPendientes = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumeroOC = New System.Windows.Forms.TextBox()
        Me.dgvProductosOC = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_moc_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvProductosOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_vigencia
        '
        Me.lbl_vigencia.Location = New System.Drawing.Point(486, 88)
        Me.lbl_vigencia.Name = "lbl_vigencia"
        Me.lbl_vigencia.Size = New System.Drawing.Size(100, 23)
        Me.lbl_vigencia.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(680, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(74, 20)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(680, 72)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(74, 20)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(680, 48)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(74, 20)
        Me.TextBox3.TabIndex = 11
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(517, 48)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(64, 20)
        Me.TextBox4.TabIndex = 10
        '
        'TextBox5
        '
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(517, 72)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(64, 20)
        Me.TextBox5.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(612, 71)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Lineas"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(612, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "T.Unidades"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(466, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Paridad"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(612, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 13)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "T. Valores"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(466, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 13)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Moneda"
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(111, 68)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(345, 20)
        Me.TextBox6.TabIndex = 6
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(111, 42)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(345, 20)
        Me.TextBox7.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(496, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Proveedor"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Comentario"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(363, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(87, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(111, 19)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(87, 20)
        Me.DateTimePicker2.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(238, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Fecha Despacho"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 22)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 13)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Fecha Vencimiento"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.dg_moc_productos)
        Me.TabPage1.Controls.Add(Me.btn_moc_nuevo)
        Me.TabPage1.Controls.Add(Me.txt_moc_numeroOC)
        Me.TabPage1.Controls.Add(Me.Label37)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(889, 513)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Modificacion OC"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt_moc_valores)
        Me.GroupBox5.Controls.Add(Me.txt_moc_lineas)
        Me.GroupBox5.Controls.Add(Me.txt_moc_unidades)
        Me.GroupBox5.Controls.Add(Me.txt_moc_moneda)
        Me.GroupBox5.Controls.Add(Me.txt_moc_paridad)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.txt_moc_proveedor)
        Me.GroupBox5.Controls.Add(Me.txt_moc_comentario)
        Me.GroupBox5.Controls.Add(Me.btn_aplicar_moc)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.dtp_mov_fecha_despacho)
        Me.GroupBox5.Controls.Add(Me.dtp_moc_fechavencimiento)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(872, 105)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Confirmacion de Proveedor"
        '
        'txt_moc_valores
        '
        Me.txt_moc_valores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_valores.Enabled = False
        Me.txt_moc_valores.Location = New System.Drawing.Point(680, 24)
        Me.txt_moc_valores.Name = "txt_moc_valores"
        Me.txt_moc_valores.Size = New System.Drawing.Size(74, 20)
        Me.txt_moc_valores.TabIndex = 11
        Me.txt_moc_valores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_moc_lineas
        '
        Me.txt_moc_lineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_lineas.Enabled = False
        Me.txt_moc_lineas.Location = New System.Drawing.Point(680, 72)
        Me.txt_moc_lineas.Name = "txt_moc_lineas"
        Me.txt_moc_lineas.Size = New System.Drawing.Size(74, 20)
        Me.txt_moc_lineas.TabIndex = 11
        Me.txt_moc_lineas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_moc_unidades
        '
        Me.txt_moc_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_unidades.Enabled = False
        Me.txt_moc_unidades.Location = New System.Drawing.Point(680, 48)
        Me.txt_moc_unidades.Name = "txt_moc_unidades"
        Me.txt_moc_unidades.Size = New System.Drawing.Size(74, 20)
        Me.txt_moc_unidades.TabIndex = 11
        Me.txt_moc_unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_moc_moneda
        '
        Me.txt_moc_moneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_moneda.Enabled = False
        Me.txt_moc_moneda.Location = New System.Drawing.Point(517, 48)
        Me.txt_moc_moneda.Name = "txt_moc_moneda"
        Me.txt_moc_moneda.Size = New System.Drawing.Size(64, 20)
        Me.txt_moc_moneda.TabIndex = 10
        '
        'txt_moc_paridad
        '
        Me.txt_moc_paridad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_paridad.Enabled = False
        Me.txt_moc_paridad.Location = New System.Drawing.Point(517, 72)
        Me.txt_moc_paridad.Name = "txt_moc_paridad"
        Me.txt_moc_paridad.Size = New System.Drawing.Size(64, 20)
        Me.txt_moc_paridad.TabIndex = 9
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(612, 71)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 14)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "Lineas"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(612, 51)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(60, 14)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "T.Unidades"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(466, 75)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 14)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "Paridad"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(612, 27)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 14)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "T. Valores"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(466, 48)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(45, 14)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "Moneda"
        '
        'txt_moc_proveedor
        '
        Me.txt_moc_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_proveedor.Enabled = False
        Me.txt_moc_proveedor.Location = New System.Drawing.Point(111, 68)
        Me.txt_moc_proveedor.Name = "txt_moc_proveedor"
        Me.txt_moc_proveedor.Size = New System.Drawing.Size(345, 20)
        Me.txt_moc_proveedor.TabIndex = 6
        '
        'txt_moc_comentario
        '
        Me.txt_moc_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_comentario.Location = New System.Drawing.Point(111, 42)
        Me.txt_moc_comentario.Name = "txt_moc_comentario"
        Me.txt_moc_comentario.Size = New System.Drawing.Size(345, 20)
        Me.txt_moc_comentario.TabIndex = 6
        '
        'btn_aplicar_moc
        '
        Me.btn_aplicar_moc.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_aplicar_moc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aplicar_moc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar_moc.ForeColor = System.Drawing.Color.White
        Me.btn_aplicar_moc.Location = New System.Drawing.Point(496, 10)
        Me.btn_aplicar_moc.Name = "btn_aplicar_moc"
        Me.btn_aplicar_moc.Size = New System.Drawing.Size(75, 31)
        Me.btn_aplicar_moc.TabIndex = 3
        Me.btn_aplicar_moc.Text = "Aplicar"
        Me.btn_aplicar_moc.UseVisualStyleBackColor = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 71)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(57, 14)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "Proveedor"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 45)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 14)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "Comentario"
        '
        'dtp_mov_fecha_despacho
        '
        Me.dtp_mov_fecha_despacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_mov_fecha_despacho.Location = New System.Drawing.Point(363, 19)
        Me.dtp_mov_fecha_despacho.Name = "dtp_mov_fecha_despacho"
        Me.dtp_mov_fecha_despacho.Size = New System.Drawing.Size(87, 20)
        Me.dtp_mov_fecha_despacho.TabIndex = 4
        '
        'dtp_moc_fechavencimiento
        '
        Me.dtp_moc_fechavencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_moc_fechavencimiento.Location = New System.Drawing.Point(111, 19)
        Me.dtp_moc_fechavencimiento.Name = "dtp_moc_fechavencimiento"
        Me.dtp_moc_fechavencimiento.Size = New System.Drawing.Size(87, 20)
        Me.dtp_moc_fechavencimiento.TabIndex = 4
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(238, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(89, 14)
        Me.Label35.TabIndex = 5
        Me.Label35.Text = "Fecha Despacho"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 22)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(98, 14)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "Fecha Vencimiento"
        '
        'dg_moc_productos
        '
        Me.dg_moc_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_moc_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_moc_productos.Location = New System.Drawing.Point(4, 143)
        Me.dg_moc_productos.Name = "dg_moc_productos"
        Me.dg_moc_productos.RowHeadersWidth = 25
        Me.dg_moc_productos.Size = New System.Drawing.Size(876, 349)
        Me.dg_moc_productos.TabIndex = 1
        '
        'btn_moc_nuevo
        '
        Me.btn_moc_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_moc_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_moc_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_moc_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_moc_nuevo.Location = New System.Drawing.Point(469, 3)
        Me.btn_moc_nuevo.Name = "btn_moc_nuevo"
        Me.btn_moc_nuevo.Size = New System.Drawing.Size(110, 23)
        Me.btn_moc_nuevo.TabIndex = 25
        Me.btn_moc_nuevo.Text = "Nuevo"
        Me.btn_moc_nuevo.UseVisualStyleBackColor = False
        '
        'txt_moc_numeroOC
        '
        Me.txt_moc_numeroOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_moc_numeroOC.Location = New System.Drawing.Point(363, 6)
        Me.txt_moc_numeroOC.Name = "txt_moc_numeroOC"
        Me.txt_moc_numeroOC.Size = New System.Drawing.Size(100, 20)
        Me.txt_moc_numeroOC.TabIndex = 23
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(238, 8)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(92, 14)
        Me.Label37.TabIndex = 24
        Me.Label37.Text = "Orden de Compra"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(889, 514)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Propiedades OC"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtMotivoFechaDespacho)
        Me.GroupBox4.Controls.Add(Me.dtpFechaDespachoActualizacion)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.btnAplicarFechaDespacho)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.txtNumeroOCDespacho)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 290)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(871, 113)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Despacho"
        '
        'txtMotivoFechaDespacho
        '
        Me.txtMotivoFechaDespacho.Location = New System.Drawing.Point(101, 82)
        Me.txtMotivoFechaDespacho.Name = "txtMotivoFechaDespacho"
        Me.txtMotivoFechaDespacho.Size = New System.Drawing.Size(590, 20)
        Me.txtMotivoFechaDespacho.TabIndex = 2
        '
        'dtpFechaDespachoActualizacion
        '
        Me.dtpFechaDespachoActualizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDespachoActualizacion.Location = New System.Drawing.Point(101, 56)
        Me.dtpFechaDespachoActualizacion.Name = "dtpFechaDespachoActualizacion"
        Me.dtpFechaDespachoActualizacion.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaDespachoActualizacion.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 14)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Fecha Despacho"
        '
        'btnAplicarFechaDespacho
        '
        Me.btnAplicarFechaDespacho.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarFechaDespacho.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarFechaDespacho.ForeColor = System.Drawing.Color.White
        Me.btnAplicarFechaDespacho.Location = New System.Drawing.Point(528, 12)
        Me.btnAplicarFechaDespacho.Name = "btnAplicarFechaDespacho"
        Me.btnAplicarFechaDespacho.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarFechaDespacho.TabIndex = 3
        Me.btnAplicarFechaDespacho.Text = "Aplicar"
        Me.btnAplicarFechaDespacho.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 14)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Motivo"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(241, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 14)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Orden de Compra"
        '
        'txtNumeroOCDespacho
        '
        Me.txtNumeroOCDespacho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroOCDespacho.Location = New System.Drawing.Point(366, 14)
        Me.txtNumeroOCDespacho.Name = "txtNumeroOCDespacho"
        Me.txtNumeroOCDespacho.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroOCDespacho.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtComentarioProduccion)
        Me.GroupBox3.Controls.Add(Me.dtpFechaProduccionActualizacion)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.btnAplicarFechaProduccion)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtNumeroOCProduccion)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 173)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(871, 111)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Produccion"
        '
        'txtComentarioProduccion
        '
        Me.txtComentarioProduccion.Location = New System.Drawing.Point(101, 82)
        Me.txtComentarioProduccion.Name = "txtComentarioProduccion"
        Me.txtComentarioProduccion.Size = New System.Drawing.Size(590, 20)
        Me.txtComentarioProduccion.TabIndex = 2
        '
        'dtpFechaProduccionActualizacion
        '
        Me.dtpFechaProduccionActualizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProduccionActualizacion.Location = New System.Drawing.Point(101, 56)
        Me.dtpFechaProduccionActualizacion.Name = "dtpFechaProduccionActualizacion"
        Me.dtpFechaProduccionActualizacion.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaProduccionActualizacion.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 14)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Fecha Produccion"
        '
        'btnAplicarFechaProduccion
        '
        Me.btnAplicarFechaProduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarFechaProduccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarFechaProduccion.ForeColor = System.Drawing.Color.White
        Me.btnAplicarFechaProduccion.Location = New System.Drawing.Point(528, 12)
        Me.btnAplicarFechaProduccion.Name = "btnAplicarFechaProduccion"
        Me.btnAplicarFechaProduccion.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarFechaProduccion.TabIndex = 3
        Me.btnAplicarFechaProduccion.Text = "Aplicar"
        Me.btnAplicarFechaProduccion.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Motivo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(241, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 14)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Orden de Compra"
        '
        'txtNumeroOCProduccion
        '
        Me.txtNumeroOCProduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroOCProduccion.Location = New System.Drawing.Point(366, 14)
        Me.txtNumeroOCProduccion.Name = "txtNumeroOCProduccion"
        Me.txtNumeroOCProduccion.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroOCProduccion.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtnumeroOCCreditos)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnImprimir)
        Me.GroupBox2.Controls.Add(Me.btnAplicarOCCreditos)
        Me.GroupBox2.Controls.Add(Me.txtComentarioOCCreditos)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmbEstadoOCCreditos)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(871, 130)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Situacion Crediticia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(241, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 14)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Orden de Compra"
        '
        'txtnumeroOCCreditos
        '
        Me.txtnumeroOCCreditos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnumeroOCCreditos.Location = New System.Drawing.Point(366, 14)
        Me.txtnumeroOCCreditos.Name = "txtnumeroOCCreditos"
        Me.txtnumeroOCCreditos.Size = New System.Drawing.Size(100, 20)
        Me.txtnumeroOCCreditos.TabIndex = 3
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnEliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(616, 40)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(340, 47)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnAplicarOCCreditos
        '
        Me.btnAplicarOCCreditos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarOCCreditos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarOCCreditos.ForeColor = System.Drawing.Color.White
        Me.btnAplicarOCCreditos.Location = New System.Drawing.Point(244, 46)
        Me.btnAplicarOCCreditos.Name = "btnAplicarOCCreditos"
        Me.btnAplicarOCCreditos.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarOCCreditos.TabIndex = 3
        Me.btnAplicarOCCreditos.Text = "Aplicar"
        Me.btnAplicarOCCreditos.UseVisualStyleBackColor = False
        '
        'txtComentarioOCCreditos
        '
        Me.txtComentarioOCCreditos.Location = New System.Drawing.Point(101, 74)
        Me.txtComentarioOCCreditos.Multiline = True
        Me.txtComentarioOCCreditos.Name = "txtComentarioOCCreditos"
        Me.txtComentarioOCCreditos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarioOCCreditos.Size = New System.Drawing.Size(590, 48)
        Me.txtComentarioOCCreditos.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 14)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Estado"
        '
        'cmbEstadoOCCreditos
        '
        Me.cmbEstadoOCCreditos.FormattingEnabled = True
        Me.cmbEstadoOCCreditos.Location = New System.Drawing.Point(101, 47)
        Me.cmbEstadoOCCreditos.Name = "cmbEstadoOCCreditos"
        Me.cmbEstadoOCCreditos.Size = New System.Drawing.Size(121, 22)
        Me.cmbEstadoOCCreditos.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.btnOCPendientes)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtNumeroOC)
        Me.TabPage2.Controls.Add(Me.dgvProductosOC)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(889, 513)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Confirmacion Proveedor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValores)
        Me.GroupBox1.Controls.Add(Me.txtLineas)
        Me.GroupBox1.Controls.Add(Me.txtUnidades)
        Me.GroupBox1.Controls.Add(Me.txtMoneda)
        Me.GroupBox1.Controls.Add(Me.txtParidad)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.txtComentarioConfirmacion)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDespacho)
        Me.GroupBox1.Controls.Add(Me.dtpFechaVencimientoConfirmacion)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 105)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Confirmacion de Proveedor"
        '
        'txtValores
        '
        Me.txtValores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValores.Enabled = False
        Me.txtValores.Location = New System.Drawing.Point(680, 24)
        Me.txtValores.Name = "txtValores"
        Me.txtValores.Size = New System.Drawing.Size(74, 20)
        Me.txtValores.TabIndex = 11
        Me.txtValores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineas
        '
        Me.txtLineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineas.Enabled = False
        Me.txtLineas.Location = New System.Drawing.Point(680, 72)
        Me.txtLineas.Name = "txtLineas"
        Me.txtLineas.Size = New System.Drawing.Size(74, 20)
        Me.txtLineas.TabIndex = 11
        Me.txtLineas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnidades
        '
        Me.txtUnidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnidades.Enabled = False
        Me.txtUnidades.Location = New System.Drawing.Point(680, 48)
        Me.txtUnidades.Name = "txtUnidades"
        Me.txtUnidades.Size = New System.Drawing.Size(74, 20)
        Me.txtUnidades.TabIndex = 11
        Me.txtUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMoneda
        '
        Me.txtMoneda.Enabled = False
        Me.txtMoneda.Location = New System.Drawing.Point(517, 48)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(64, 20)
        Me.txtMoneda.TabIndex = 10
        '
        'txtParidad
        '
        Me.txtParidad.Enabled = False
        Me.txtParidad.Location = New System.Drawing.Point(517, 72)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(64, 20)
        Me.txtParidad.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(612, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Lineas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(612, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "T.Unidades"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(466, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Paridad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(612, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "T. Valores"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(466, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Moneda"
        '
        'txtProveedor
        '
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(111, 68)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(345, 20)
        Me.txtProveedor.TabIndex = 6
        '
        'txtComentarioConfirmacion
        '
        Me.txtComentarioConfirmacion.Location = New System.Drawing.Point(111, 42)
        Me.txtComentarioConfirmacion.Name = "txtComentarioConfirmacion"
        Me.txtComentarioConfirmacion.Size = New System.Drawing.Size(345, 20)
        Me.txtComentarioConfirmacion.TabIndex = 6
        '
        'btnAplicar
        '
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.Location = New System.Drawing.Point(496, 10)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 31)
        Me.btnAplicar.TabIndex = 3
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Proveedor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 14)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Comentario"
        '
        'dtpFechaDespacho
        '
        Me.dtpFechaDespacho.Enabled = False
        Me.dtpFechaDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDespacho.Location = New System.Drawing.Point(363, 19)
        Me.dtpFechaDespacho.Name = "dtpFechaDespacho"
        Me.dtpFechaDespacho.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaDespacho.TabIndex = 4
        '
        'dtpFechaVencimientoConfirmacion
        '
        Me.dtpFechaVencimientoConfirmacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVencimientoConfirmacion.Location = New System.Drawing.Point(111, 19)
        Me.dtpFechaVencimientoConfirmacion.Name = "dtpFechaVencimientoConfirmacion"
        Me.dtpFechaVencimientoConfirmacion.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaVencimientoConfirmacion.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(238, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 14)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Fecha Despacho"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 14)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Fecha Vencimiento"
        '
        'btnOCPendientes
        '
        Me.btnOCPendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnOCPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOCPendientes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOCPendientes.ForeColor = System.Drawing.Color.White
        Me.btnOCPendientes.Location = New System.Drawing.Point(480, 3)
        Me.btnOCPendientes.Name = "btnOCPendientes"
        Me.btnOCPendientes.Size = New System.Drawing.Size(110, 23)
        Me.btnOCPendientes.TabIndex = 3
        Me.btnOCPendientes.Text = "OC Pendientes"
        Me.btnOCPendientes.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(249, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 14)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Orden de Compra"
        '
        'txtNumeroOC
        '
        Me.txtNumeroOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroOC.Location = New System.Drawing.Point(374, 6)
        Me.txtNumeroOC.Name = "txtNumeroOC"
        Me.txtNumeroOC.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroOC.TabIndex = 1
        '
        'dgvProductosOC
        '
        Me.dgvProductosOC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductosOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductosOC.Location = New System.Drawing.Point(11, 142)
        Me.dgvProductosOC.Name = "dgvProductosOC"
        Me.dgvProductosOC.RowHeadersWidth = 25
        Me.dgvProductosOC.Size = New System.Drawing.Size(872, 358)
        Me.dgvProductosOC.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(897, 540)
        Me.TabControl1.TabIndex = 22
        '
        'frm_OCconfirmacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(897, 540)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbl_vigencia)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_OCconfirmacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualizar Fechas a Documentos"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dg_moc_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvProductosOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub crearEstructura()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt.Columns.Add(New DataColumn("preciou", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("factoralt", GetType(Double)))
        '(c) 20160721
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("maneja_lote", GetType(String)))

        dt.Columns("producto").Unique = True
        dt.TableName = "productos"

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)

        dt.TableName = "productos_moc"
        If ds.Tables.Contains("productos_moc") Then ds.Tables.Remove("productos_moc")
        ds.Tables.Add(dt.Copy)


        dt = New DataTable("tipo_unidad")
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        If Not ds.Tables.Contains("tipo_unidad") Then ds.Tables.Add(dt.Copy)


    End Sub

    Private Sub LlenarCombos()
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ls_sql = "pa_sel_um_gen_tabcod NULL,'IT_VIGENCIA','DMARTE1'"
            otabla = otrans.Obtiene(ls_sql)
            'otabla.DefaultView.RowFilter = "codigo <> 'A'"  ''Se podra Anular desde esta opcion (c)22Feb


            Me.cmbEstadoOCCreditos.DataSource = otabla
            Me.cmbEstadoOCCreditos.DisplayMember = "DESCRIPCION"
            Me.cmbEstadoOCCreditos.ValueMember = "CODIGO"


            ls_sql = "pa_sel_um_vi_unidadingreso '" & gs_empresa & "'"
            otabla = otrans.Obtiene(ls_sql)

            For Each dr As DataRow In otabla.Rows

                Dim draux As DataRow = ds.Tables("tipo_unidad").NewRow
                draux.Item("unidad") = dr.Item("unidadingreso")
                ds.Tables("tipo_unidad").Rows.Add(draux)




            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Crear_Estructura_Auxiliar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            ls_sql = "pa_var_um_documento_traslado_fecha 'VINOTECA',NULL,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)

            dt.TableName = "documento"
            If ds.Tables.Contains("documento") Then
                ds.Tables.Remove("documento")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)


            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If ds.Tables.Contains("documentod") Then
                ds.Tables.Remove("documentod")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If ds.Tables.Contains("documentov") Then
                ds.Tables.Remove("documentov")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If ds.Tables.Contains("documentop") Then
                ds.Tables.Remove("documentop")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

#Region "Generacion de Documento"


    Private Sub GenerarDocumentos()
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim icount, dfactoralt As Integer
        Dim dtotal As Double
        Dim lsSQL As String

        Try
            Crear_Estructura_Auxiliar()
            otrans.open()
            dtotal = ds.Tables("productos").Compute("Sum(total)", "total>0")
            dt = otrans.Obtiene("pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOC.Text & "'")

            dr = dt.Rows(0)
            dr_aux = ds.Tables("documento").NewRow

            dr_aux.Item("empresa") = gs_empresa
            dr_aux.Item("TipoDocto") = "CONFIRMACION PROVEEDOR"
            dr_aux.Item("Numero") = dr.Item("numero").ToString
            'dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy")
            dr_aux.Item("FechaVcto") = Me.dtpFechaVencimientoConfirmacion.Value


            dr_aux.Item("ctacte") = String.Empty
            dr_aux.Item("proveedor") = dr.Item("proveedor")
            dr_aux.Item("idCtacte") = dr.Item("proveedor")
            dr_aux.Item("Bodega") = String.Empty
            dr_aux.Item("Vendedor") = String.Empty
            dr_aux.Item("ListaPrecio") = String.Empty
            dr_aux.Item("Moneda") = Me.txtMoneda.Text
            dr_aux.Item("Paridad") = Me.txtParidad.Text

            dr_aux.Item("Neto") = dtotal * Double.Parse(Me.txtParidad.Text)
            dr_aux.Item("SubTotal") = dtotal * Double.Parse(Me.txtParidad.Text)
            dr_aux.Item("Total") = dtotal * Double.Parse(Me.txtParidad.Text)
            dr_aux.Item("NetoIngreso") = dtotal
            dr_aux.Item("SubTotalIngreso") = dtotal
            dr_aux.Item("TotalIngreso") = dtotal
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("Valoriza") = "S"
            dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = dr.Item("tipoctacte")
            dr_aux.Item("glosa") = dr.Item("glosa")
            dr_aux.Item("Comentario1") = dr.Item("Comentario1").ToString & " " & Me.txtComentarioConfirmacion.Text
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N"
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now

            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = gs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")

            'dr_aux.Item("Caja") = dr.Item("U_SSOCAJA")
            'dr_aux.Item("Pago") = dr_aux.Item("Total")
            'dr_aux.Item("IdApertura") = dr.Item("U_SSOSESION")

            dr_aux.Item("NetoBimoneda") = dr_aux.Item("NetoIngreso")
            dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("TotalIngreso")
            dr_aux.Item("TotalBimoneda") = dr_aux.Item("TotalIngreso")

            dr_aux.Item("ParidadBimoneda") = 1
            dr_aux.Item("AnalisisE3") = dr.Item("analisisE3")
            dr_aux.Item("AnalisisE7") = dr.Item("analisisE7")


            ds.Tables("documento").Rows.Add(dr_aux)


            ''Detalle
            Try
                'dt_detalle.DefaultView.RowFilter = "Numero = " & dr.Item("Numero")
                dt = otrans.Obtiene("pa_sel_um_documentod '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOC.Text & "'")

                icount = 0
                For Each drv In ds.Tables("productos").DefaultView


                    dt.DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "'"
                    'dt_producto_barra.DefaultView.RowFilter = "codbarra = '" & drv.Item("CodArticulo").ToString & "'"
                    dr_aux = ds.Tables("documentod").NewRow

                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "CONFIRMACION PROVEEDOR"
                    dr_aux.Item("Producto") = drv.Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")


                    dfactoralt = drv.Item("factoralt")

                    dr_aux.Item("Cantidad") = drv.Item("Cantidad") * dfactoralt
                    dr_aux.Item("Precio") = Round((drv.Item("preciou") * Me.txtParidad.Text) / dfactoralt, 4)

                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = Round(dr_aux.Item("cantidad") * dr_aux.Item("Precio"), 2)
                    dr_aux.Item("Impuesto") = 0 'Round(drv.Item("ValorImpuesto"), 2)
                    dr_aux.Item("Neto") = Round(dr_aux.Item("SubTotal"), 2)
                    dr_aux.Item("DrGlobal") = 0

                    dr_aux.Item("Total") = dr_aux.Item("Neto")
                    dr_aux.Item("PrecioAjustado") = dr_aux.Item("Precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = drv.Item("unidad")
                    dr_aux.Item("CantidadIngreso") = drv.Item("Cantidad")
                    dr_aux.Item("PrecioIngreso") = Round(drv.Item("preciou"), 2)
                    dr_aux.Item("SubTotalIngreso") = Round(drv.Item("total"), 2)
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = Round(drv.Item("total"), 2)
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = Round(drv.Item("total"), 2)


                    dr_aux.Item("FactorInventario") = 0
                    dr_aux.Item("FechaEntrega") = Me.dtpFechaVencimientoConfirmacion.Value
                    dr_aux.Item("CantidadAsignada") = 0
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S"
                    dr_aux.Item("CUP") = 0
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1
                    dr_aux.Item("PrecioBimoneda") = Round(drv.Item("preciou"), 2)
                    dr_aux.Item("SubTotalBimoneda") = Round(drv.Item("total"), 2)
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = Round(drv.Item("total"), 2)
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = Round(drv.Item("total"), 2)

                    dr_aux.Item("DoctoOrigenVal") = "N"

                    '(c) 20160721
                    Try
                        If drv.Item("maneja_lote").ToString.ToUpper.Equals("S") Then
                            dr_aux("lote") = drv.Item("lote")
                            dr_aux("fechavcto") = drv.Item("fechavcto").ToString("dd/MM/yyyy")
                        End If
                    Catch ex As Exception
                    End Try

                    If dt.DefaultView.Count > 0 Then
                        dr_aux.Item("Secuencia") = dt.DefaultView(0).Item("secuencia")
                        dr_aux.Item("Linea") = dt.DefaultView(0).Item("linea")
                        dr_aux.Item("TipoDoctoOrigen") = dt.DefaultView(0).Item("tipoDocto")
                        dr_aux.Item("CorrelativoOrigen") = dt.DefaultView(0).Item("correlativo")
                        dr_aux.Item("SecuenciaOrigen") = dt.DefaultView(0).Item("secuencia")
                    Else
                        icount = dt.Compute("max(Linea)", "Linea>0")
                        Try
                            If icount < ds.Tables("documentod").Compute("max(Linea)", "Linea>0") Then
                                icount = ds.Tables("documentod").Compute("max(Linea)", "Linea>0")
                            End If
                        Catch ex As Exception
                        End Try

                        icount += 1
                        dr_aux.Item("Secuencia") = icount
                        dr_aux.Item("Linea") = icount
                        dr_aux.Item("TipoDoctoOrigen") = String.Empty
                        dr_aux.Item("CorrelativoOrigen") = 0
                        dr_aux.Item("SecuenciaOrigen") = 0
                    End If


                    Try
                        dr_aux.Item("costo") = 0
                    Catch ex As Exception
                        dr_aux.Item("costo") = 0
                    End Try

                    Try
                        dr_aux.Item("PrecioListaP") = 0
                    Catch ex As Exception
                        dr_aux.Item("PrecioListaP") = 0
                    End Try

                    ds.Tables("documentod").Rows.Add(dr_aux)
                Next


                'verificacion correlativos
                Try
                    icount = ds.Tables("documentod").Compute("max(SecuenciaOrigen)", "SecuenciaOrigen > 0")
                Catch ex As Exception
                    icount = 0
                End Try

                ds.Tables("documentod").DefaultView.RowFilter = "SecuenciaOrigen  = 0"
                ds.Tables("documentod").DefaultView.Sort = "linea"
                For Each drv In ds.Tables("documentod").DefaultView
                    icount += 1
                    drv.Item("secuencia") = icount
                    drv.Item("linea") = icount
                Next



                ds.Tables("documentod").DefaultView.RowFilter = ""

            Catch ex As Exception
                clsGen.Escribir_Log("Productos " & dr.Item("Numero") & " " & ex.Message)
                'lgenerar_error = True
            End Try

            ''Documentov

            '  dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
            Try
                For icount = 1 To 2
                    dr_aux = ds.Tables("documentov").NewRow
                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "CONFIRMACION PROVEEDOR"
                    'dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
                    If icount = 1 Then
                        dr_aux.Item("Nombre") = "SUB_TOTAL"
                        dr_aux.Item("Orden") = 1
                        dr_aux.Item("Monto") = ds.Tables("documento").Rows(0)("Total")
                        dr_aux.Item("MontoIngreso") = ds.Tables("documento").Rows(0)("TotalIngreso")
                    ElseIf icount = 2 Then
                        dr_aux.Item("Nombre") = "TASA"
                        dr_aux.Item("Orden") = 2

                        dr_aux.Item("Monto") = 0

                    End If
                    If icount < 3 Then
                        dr_aux.Item("Factor") = 0
                        dr_aux.Item("Porcentaje") = 0
                    Else
                        dr_aux.Item("Factor") = 0
                    End If

                    dr_aux.Item("MontoBimoneda") = Round(dr_aux.Item("MontoIngreso"), 2)
                    dr_aux.Item("Ajuste") = 0
                    dr_aux.Item("AjusteIngreso") = 0

                    ds.Tables("documentov").Rows.Add(dr_aux)

                Next
            Catch ex As Exception
                clsGen.Escribir_Log(ex.ToString)
            End Try


            Dim osinc As New Sincronizacion.Documentos("")

            dr = ds.Tables("documento").Rows(0)
            Try
                osinc.Enviar_Documento(gs_empresa, dr, ds.Tables("documentod").DefaultView.ToTable, ds.Tables("documentov").DefaultView.ToTable, ds.Tables("documentop").DefaultView.ToTable, "CONFIRMACION PROVEEDOR", False)
                If osinc.codigo_error = 0 Then
                    For Each dr In ds.Tables("documentod").Rows
                        lsSQL = "pa_upd_um_documentod_asignado '" & gs_empresa & "','" & dr.Item("tipodoctoOrigen").ToString & "'," & dr.Item("correlativoOrigen") & ",'" & dr.Item("producto").ToString & "'," & dr.Item("SecuenciaOrigen")
                        otrans.Actualiza(lsSQL)
                    Next
                End If

            Catch ex As Exception
            Finally
                osinc.Cerrar()
                osinc = Nothing

            End Try

        Catch ex As Exception
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try


    End Sub




    Private Sub Log_OCconfirmacion(ByVal pNumero As String, ByVal pActividad As String)

        Dim ls_sql As String


        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()


            ls_sql = "pa_ins_um_gen_log_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & pNumero & " ','" & gs_usuario & "','NULL','" & pActividad & "'"
            oTrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try



    End Sub


#End Region

    Private Function BuscarProducto(ByVal pcodigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & pcodigo & "'"
            dt = Otrans.Obtiene(ls_sql)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Private Function validarFechas() As Boolean

        Dim fechasvalidas As Boolean = True
        ds.Tables("doctosfecha").DefaultView.RowFilter = ""
        ds.Tables("doctosfecha").DefaultView.Sort = "orden"

        Dim fechainicial As DateTime = Me.dtpFechaVencimientoConfirmacion.Value

        For Each drv As DataRowView In ds.Tables("doctosfecha").DefaultView
            If fechainicial > drv.Item("fechavencimiento") Then
                MessageBox.Show("Problemas Con El Documento " & drv.Item("tipodocto").ToString, "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                fechasvalidas = False
                Exit For
            Else
                fechainicial = drv.Item("fechavencimiento")
            End If
            If (DateDiff(DateInterval.Day, Today, fechainicial)) < 0 Then
                MessageBox.Show("La Fecha del Documento " & drv.Item("tipodocto").ToString & "No Puede Ser Menor a la Fecha Actual", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                fechasvalidas = False
                Exit For
            End If

        Next

        Return fechasvalidas
    End Function

    Private Sub llenarMaestros()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_tipodocumento '" & gs_empresa & "','pedido (c)'"
            dt = oTrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "aprobacion ='n' and fechavcto = 's'"
            dt = dt.DefaultView.ToTable
            dt.DefaultView.RowFilter = "tipodocto <> 'confirmacion proveedor'"
            dt = dt.DefaultView.ToTable
            dt.TableName = "tipodocto"
            ds.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

    End Sub

    Private Sub Totalizar()
        Try

            Dim total As Double
            total = ds.Tables("productos").Rows.Count
            Me.txtLineas.Text = total
            total = ds.Tables("productos").Compute("Sum(total)", "total>0")
            Me.txtValores.Text = total
            total = ds.Tables("productos").Compute("Sum(cantidad)", "cantidad>0")
            Me.txtUnidades.Text = total
        Catch ex As Exception

        End Try

    End Sub

    Private Sub buscarOrdenCompra()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'ORDEN DE COMPRA','" & gs_empresa & "','" & Me.txtNumeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            ds.Tables("productos").Rows.Clear()
            Me.dgvProductosOC.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                Dim cantidadAsignada As Integer = dt.Compute("Sum(CantidadAsignada)", "cantidad>0")
                If cantidadAsignada = 0 Then
                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "s" And _
                        dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado
                        ' Me.dtpFechaVencimientoConfirmacion.Value = dt.Rows(0).Item("fechaVcto")
                        Me.dtpFechaDespacho.Value = dt.Rows(0).Item("fechaDespacho")
                        Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
                        Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString
                        Me.txtProveedor.Text = dt.Rows(0)("proveedor").ToString

                        For Each dr As DataRow In dt.Rows
                            draux = ds.Tables("productos").NewRow
                            draux.Item("producto") = dr.Item("producto")
                            draux.Item("glosa") = dr.Item("glosa")
                            draux.Item("unidad") = dr.Item("unidadIngreso")
                            draux.Item("cantidad") = dr.Item("cantidadIngreso")
                            draux.Item("preciou") = dr.Item("precioIngreso")
                            draux.Item("total") = dr.Item("subtotalIngreso")
                            '(c) 20160721
                            draux.Item("maneja_lote") = dr.Item("maneja_lote")
                            draux.Item("lote") = dr.Item("lote")
                            Try
                                draux.Item("fecha_vencimiento") = dr.Item("FechaVctod")
                            Catch ex As Exception

                            End Try



                            ds.Tables("productos").Rows.Add(draux)
                        Next

                        Me.dgvProductosOC.DataSource = ds.Tables("productos")

                        Dim dgtbc As New DataGridViewComboBoxColumn
                        dgtbc.DataSource = ds.Tables("tipo_unidad")
                        dgtbc.ValueMember = "unidad"
                        dgtbc.DisplayMember = "unidad"
                        dgtbc.HeaderText = "unidad"
                        dgtbc.DataPropertyName = "unidad"
                        dgtbc.Name = "unidad"

                        clsGen.Alinear_GridViewComboBox(dgtbc)
                        clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgvProductosOC, "", ",factoralt,", ",glosa,total,maneja_lote,", ",cantidad,preciou,total,", "", "", "", True, True, 250, 0)
                    Else

                        If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                            MessageBox.Show("Esta Orden de Compra No Esta Vigente, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtNumeroOC.Text = String.Empty
                        Else
                            MessageBox.Show("Esta Orden de Compra Esta Anulada o Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtNumeroOC.Text = String.Empty
                        End If
                    End If
                Else
                    MessageBox.Show("Esta Orden de Compra ya Tiene Confirmacion de Proveedor", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtNumeroOC.Text = String.Empty
                End If

            Else

                MessageBox.Show("Problemas con Esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtNumeroOC.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
            Totalizar()
        End Try

    End Sub

    Private Sub crearAvisoConfirmacion()
        Dim ClsGen As New ClasesGenerales.General
        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dtusuarioEmpresa As DataTable
        Dim lsSQL As String
        Dim bguardarAviso As Boolean = False

        Try
            Otrans.open()
            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(2)" '2= pg_tipo_aviso=Confirmacion de Proveedor
            dt = myOtrans.Obtiene(lsSQL)
            lsSQL = "pa_sel_um_gen_tabcod '" & Me.txtProveedor.Text & "','CON_PROVEE','" & gs_empresa & "'"
            dt2 = Otrans.Obtiene(lsSQL)
            lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
            dtusuarioEmpresa = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows

                If dr.Item("validar_marca").ToString = "1" Then
                    'tengo que establecer los dueños de las marcas
                    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                    If dt2.DefaultView.Count > 0 Then bguardarAviso = True

                ElseIf dr.Item("validar_empresa").ToString = "1" Then
                    dtusuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                    If dtusuarioEmpresa.DefaultView.Count > 0 Then bguardarAviso = True

                Else
                    bguardarAviso = True
                End If

                If bguardarAviso Then
                    ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Se Confirmo La OC No. " & Me.txtNumeroOC.Text & " del Proveedor " & Me.txtProveedor.Text, 2)
                    bguardarAviso = False
                End If
            Next







            ''Generar Avisos Registro Sanitario
            Dim dt3 As DataTable
            Dim guardarAviso As Boolean


            lsSQL = "pa_var_um_confirmacion_proveedor_registros_sanitarios '" & gs_empresa & "','" & Me.txtNumeroOC.Text & "'"
            dt3 = Otrans.Obtiene(lsSQL)

            If dt3.Rows.Count > 0 Then
                lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(17)" '17= Registros Sanitarios
                dt = myOtrans.Obtiene(lsSQL)



                For Each dr3 As DataRow In dt3.Rows

                    guardarAviso = False
                    Dim lsMensaje As String
                    lsMensaje = "El Producto " & dr3.Item("producto").ToString.Trim & "-" & dr3.Item("glosa").ToString.Trim

                    If dr3.Item("registro").ToString.Length = 0 Then
                        guardarAviso = True
                        lsMensaje += " No tiene Registro Sanitario, OC " & Me.txtNumeroOC.Text
                    Else
                        If dr3.Item("Fecha_vencimiento").ToString.Length = 0 Then
                            guardarAviso = True
                            lsMensaje += " No tiene Fecha de Vencimiento, OC " & Me.txtNumeroOC.Text
                        Else
                            Try
                                If CDate(dr3.Item("Fecha_vencimiento")).Date < Today() Then
                                    guardarAviso = True
                                    lsMensaje += " El Registro Ya Vencio, OC " & Me.txtNumeroOC.Text
                                ElseIf CDate(dr3.Item("Fecha_vencimiento")).Date < Today().AddMonths(3) Then
                                    guardarAviso = True
                                    lsMensaje += " El Registro Esta Por Vencer, OC " & Me.txtNumeroOC.Text
                                End If
                            Catch ex As Exception
                                guardarAviso = True
                                lsMensaje += " Problemas con la Fecha, OC " & Me.txtNumeroOC.Text

                            End Try

                        End If
                    End If


                    If guardarAviso Then

                        For Each dr As DataRow In dt.Rows
                            If dr.Item("validar_marca").ToString = "1" Then
                                dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                                If dt2.DefaultView.Count > 0 Then guardarAviso = True

                            ElseIf dr.Item("validar_empresa").ToString = "1" Then

                                dtusuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                                If dtusuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True
                            End If


                            If guardarAviso Then

                                ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsMensaje, 17)
                                guardarAviso = False
                            End If
                        Next
                    End If

                Next
            End If




        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub frm_consignaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarMaestros()
        crearEstructura()
        LlenarCombos()

    End Sub

    Private Sub txtNumeroOC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroOC.KeyDown

    End Sub



    Private Sub txtNumeroOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroOC.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroOC.Text = Me.txtNumeroOC.Text.PadLeft(10, "0")
            ' CrearEstructura()
            buscarOrdenCompra()
        End If
    End Sub


    Private Sub dgvProductosOC_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductosOC.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex



        Try

            'Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon

            Dim c As Control = Me.dgvProductosOC.EditingControl

            Select Case Me.dgvProductosOC.Columns(e.ColumnIndex).Name.ToLower
                Case "producto"

                    Dim dt As DataTable
                    If c.Text = "+" Then
                        Dim frm_busqueda As New frm_busqueda_general
                        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                        frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                        frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
                        frm_busqueda.txt_buscar1.Focus()
                        frm_busqueda.ShowDialog(Me)

                        c.Text = frm_busqueda.resultado
                        frm_busqueda.Dispose()
                        frm_busqueda = Nothing
                        dt = BuscarProducto(c.Text)
                    Else
                        dt = BuscarProducto(c.Text)
                    End If
                    If dt.Rows.Count = 1 Then
                        ''Validar que el cliente no este en la lista
                        If dt.Rows(0)("VIGENTE").ToString.ToLower = "s" Then
                            Me.dgvProductosOC.Item("producto", e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
                            Me.dgvProductosOC.Item("glosa", e.RowIndex).Value = dt.Rows(0).Item("glosa").ToString
                            Me.dgvProductosOC.Item("cantidad", e.RowIndex).Value = 0
                            Me.dgvProductosOC.Item("preciou", e.RowIndex).Value = 0
                            Me.dgvProductosOC.Item("total", e.RowIndex).Value = 0
                        Else
                            MessageBox.Show("El Producto No Esta Vigente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Case "cantidad"
                    If Me.dgvProductosOC.Item("preciou", e.RowIndex).Value > 0 Then
                        Me.dgvProductosOC.Item("total", e.RowIndex).Value = c.Text * Me.dgvProductosOC.Item("preciou", e.RowIndex).Value
                        Totalizar()
                    End If
                Case "preciou"
                    If Me.dgvProductosOC.Item("cantidad", e.RowIndex).Value > 0 Then
                        Me.dgvProductosOC.Item("total", e.RowIndex).Value = c.Text * Me.dgvProductosOC.Item("cantidad", e.RowIndex).Value
                        Totalizar()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Function validarProductos(ByVal pnombreTabla As String) As Boolean
        Dim dt As DataTable
        Dim lbretorno As Boolean = True

        Try
            For Each dr As DataRow In ds.Tables(pnombreTabla).Rows

                If dr.Item("unidad").ToString.ToLower = "un" Then
                    dr.Item("factoralt") = 1
                Else
                    dt = Me.BuscarProducto(dr.Item("producto").ToString)
                    If dt.Rows.Count > 0 Then
                        With dt.Rows(0)
                            If .Item("unidadalt").ToString.ToLower <> dr.Item("unidad").ToString.ToLower And .Item("unidad").ToString.ToLower <> dr.Item("unidad").ToString.ToLower Then
                                MessageBox.Show("El Producto " & dr.Item("glosa").ToString & " No Permite Esta Unidad", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                lbretorno = True
                                Exit For
                            Else
                                dr.Item("factoralt") = .Item("factoralt")
                            End If
                        End With
                    End If
                End If
            Next
        Catch ex As Exception
            lbretorno = False
        End Try
        Return lbretorno

    End Function


    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        If validarProductos("productos") Then


            If MessageBox.Show("Esta Seguro de Generar La Confirmacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GenerarDocumentos() 'Solo Tiene que Generar Confirmacion de proveedor 

                Log_OCconfirmacion(Me.txtNumeroOC.Text, "Confirmacion Proveedor ")
                If MessageBox.Show("Proceso Finalizado Correctamente" & Chr(13) & "Desea Imprimir El Documento", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ImprimirConfirmacion(Me.txtNumeroOC.Text)
                End If
                Me.dgvProductosOC.DataSource = Nothing
                '   CrearEstructura()
                'crearAvisoConfirmacion()
            End If
        End If
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub


#Region "Creditos"


    Private Sub BuscarOCCreditos()
        Dim dt As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        Me.lbl_vigencia.Text = String.Empty
        Dim lsSQL As String

        Try

            oTransaccion.open()

            lsSQL = "pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtnumeroOCCreditos.Text & "'"
            dt = oTransaccion.Obtiene(lsSQL)

            If oTransaccion.Codigo_error = 0 Then
                If dt.Rows(0).Item("vigencia").ToString.ToUpper <> "A" Then
                    Me.txtComentarioOCCreditos.Text = dt.Rows(0).Item("comentario1").ToString
                    Me.cmbEstadoOCCreditos.SelectedValue = dt.Rows(0).Item("aprobacion")
                Else
                    MessageBox.Show("El Documento Esta ANULADO", "Vigencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComentarioOCCreditos.Text = String.Empty
                    Me.txtnumeroOCCreditos.Text = String.Empty
                End If
            End If

        Catch ex As Exception
        Finally
            oTransaccion.close()
            oTransaccion = Nothing
        End Try

    End Sub


    Private Sub txtnumeroOCCreditos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumeroOCCreditos.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtnumeroOCCreditos.Text = Me.txtnumeroOCCreditos.Text.PadLeft(10, "0")
            BuscarOCCreditos()
        End If
    End Sub

    Private Sub btnAplicarOCCreditos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarOCCreditos.Click
        If MessageBox.Show("Esta Seguro de Cambiar El Estado de La Orden de Compra", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If Me.cmbEstadoOCCreditos.SelectedValue.ToString = "A" Then
                Dim dt As DataTable = obtenerDocumentoRelacionados("FECHA INGRESO DEPOSITO ADUANERO", txtnumeroOCCreditos.Text)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("tipoDoctoDestino").ToString.Length > 5 Then
                        MessageBox.Show("No se Pueden Eliminar Los Documentos " & Chr(13) & " ya existe " & dt.Rows(0).Item("tipodoctoDestino").ToString, "Confirmacion", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
            End If

            Dim oTrans As New Transaccional.Conexion("FlexLine")
            Dim lsSQL As String

            Try
                oTrans.open()

                lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                    "Orden de Compra" & "','" & _
                    Me.txtnumeroOCCreditos.Text & "','" & _
                    Me.txtComentarioOCCreditos.Text & "','" & Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"


                oTrans.Actualiza(lsSQL)
                If oTrans.Codigo_error = 0 Then
                    MessageBox.Show("Actualizacion Exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                         "CONFIRMACION PROVEEDOR" & "','" & _
                         Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                         Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                         "FECHA EMBARQUE" & "','" & _
                         Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                         Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                        "FECHA CONFIRMACION DE EMBARQUE" & "','" & _
                        Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                        Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)


                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                        "FECHA ARRIBO PUERTO" & "','" & _
                        Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                        Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                        "FECHA SALIDA PUERTO DE GUATEMALA" & "','" & _
                        Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                        Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)


                    lsSQL = "pa_upd_um_documento_estado '" & gs_empresa & "','" & _
                        "FECHA INGRESO DEPOSITO ADUANERO" & "','" & _
                        Me.txtnumeroOCCreditos.Text & "',NULL,'" & _
                        Me.cmbEstadoOCCreditos.SelectedValue.ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(lsSQL)

                    Me.txtnumeroOCCreditos.Text = String.Empty
                    Me.cmbEstadoOCCreditos.Text = "PENDIENTE"
                    Me.txtComentarioOCCreditos.Text = String.Empty
                    Log_OCconfirmacion(Me.txtnumeroOCCreditos.Text, "Propiedades Situacion Crediticia OCconfirmacion")

                Else
                    MessageBox.Show("Problemas al Actualizar el Documento", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
            Finally
                oTrans.close()
                oTrans = Nothing
            End Try



        End If


    End Sub

#End Region


    Private Sub btnAplicarFechaDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarFechaDespacho.Click

        If Me.txtNumeroOCDespacho.Text.Length = 10 Then


            Dim otrans As New Transaccional.Conexion("FlexLine")

            Try
                otrans.open()
                otrans.Actualiza("pa_upd_um_documento_analisis '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCDespacho.Text & "','" & gs_usuario & "','" & _
                                Me.txtMotivoFechaDespacho.Text & "','" & Me.dtpFechaDespachoActualizacion.Value.ToString("dd/MM/yyyy") & "',null")


                If otrans.Codigo_error > 0 Then
                    MessageBox.Show("problemas al actualizar Fecha de Despacho", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Log_OCconfirmacion(Me.txtNumeroOCDespacho.Text, "Propiedades Despacho OCconfirmacion")
                    MessageBox.Show("Fecha de Despacho Actualizada Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroOCDespacho.Text = String.Empty
                    Me.txtMotivoFechaDespacho.Text = String.Empty
                    Me.dtpFechaDespachoActualizacion.Value = Today.AddDays(-1)
                End If

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing

            End Try
        End If
    End Sub

    Private Sub btnAplicarFechaProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarFechaProduccion.Click
        If Me.txtNumeroOCDespacho.Text.Length = 10 Then


            Dim otrans As New Transaccional.Conexion("FlexLine")

            Try
                otrans.open()
                otrans.Actualiza("pa_upd_um_documento_analisis '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCDespacho.Text & "','" & gs_usuario & "','" & _
                                Me.txtComentarioProduccion.Text & "',null,'" & _
                                  Me.dtpFechaProduccionActualizacion.Value.ToString("dd/MM/yyyy") & "'")


                If otrans.Codigo_error > 0 Then
                    MessageBox.Show("problemas al actualizar Fecha de Produccion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Log_OCconfirmacion(Me.txtNumeroOCProduccion.Text, "Propiedades Produccion OCconfirmacion")
                    MessageBox.Show("Fecha de Produccion Actualizacion Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroOCProduccion.Text = String.Empty
                    Me.dtpFechaProduccionActualizacion.Value = Today.AddDays(-1)
                End If

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing

            End Try
        End If
    End Sub

    Private Sub txtNumeroOCProduccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroOCProduccion.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroOCProduccion.Text = Me.txtNumeroOCProduccion.Text.PadLeft(10, "0")

            Dim dt As DataTable
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Dim lsSQL As String

            Try

                oTransaccion.open()

                lsSQL = "pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCProduccion.Text & "'"
                dt = oTransaccion.Obtiene(lsSQL)

                If oTransaccion.Codigo_error = 0 Then
                    If dt.Rows(0).Item("vigencia") <> "A" Then
                        Me.dtpFechaProduccionActualizacion.Value = dt.Rows(0).Item("AnalisisE7")
                    Else
                        MessageBox.Show("El Documento Esta ANULADO", "Vigencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtNumeroOCProduccion.Text = String.Empty
                    End If
                End If

            Catch ex As Exception
            Finally
                oTransaccion.close()
                oTransaccion = Nothing
            End Try
        End If

    End Sub

    Private Sub txtNumeroOCDespacho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroOCDespacho.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroOCDespacho.Text = Me.txtNumeroOCDespacho.Text.PadLeft(10, "0")

            Dim dt As DataTable
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Dim lsSQL As String

            Try

                oTransaccion.open()

                lsSQL = "pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCDespacho.Text & "'"
                dt = oTransaccion.Obtiene(lsSQL)

                If oTransaccion.Codigo_error = 0 Then
                    If dt.Rows(0).Item("vigencia") <> "A" Then
                        Me.dtpFechaDespachoActualizacion.Value = dt.Rows(0).Item("AnalisisE3")
                    Else
                        MessageBox.Show("El Documento Esta ANULADO", "Vigencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtNumeroOCProduccion.Text = String.Empty
                    End If
                End If

            Catch ex As Exception
            Finally
                oTransaccion.close()
                oTransaccion = Nothing
            End Try
        End If
    End Sub


    Private Sub txtNumeroOCDespacho_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroOCDespacho.TextChanged

    End Sub

    Private Sub btnOCPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOCPendientes.Click

        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "Select numero,fecha,proveedor,fechavcto,total,vigencia,comentario1 from documento  Where " & _
                    "tipodocto = 'ORDEN DE COMPRA' and porcentajeasignado = 0 and vigencia <> 'A' and empresa = '" & gs_empresa & "' " & _
                    "order by fecha"
            dt = oTrans.Obtiene(lsSQL)


            Dim oform As New frm_resultado
            oform.Text = "::. Ordenes de Compra Pendientes de Confirmar .::"
            oform.dgv_resultado.DataSource = dt
            ClsGen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", "", "", "", True, True, 250, 0)

            oform.ShowDialog()

            oform.Dispose()
            oform = Nothing

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub dgvProductosOC_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProductosOC.DataError
        MessageBox.Show(e.Exception.Message)
    End Sub


    Private Sub dgvDoctos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        MessageBox.Show(e.Exception.Message)
    End Sub

    Private Sub ImprimirConfirmacion(ByVal numeroOC As String)
        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String



        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataserver")
            path_reporte = ClsGen.Path_Reporte()


            ReDim pm_parametros(2)
            ReDim pm_valores(2)
            pm_parametros(0) = "Empresa"
            pm_parametros(1) = "Numero"
            pm_valores(0) = gs_empresa
            pm_valores(1) = numeroOC



            path_reporte += "Compras e Importaciones\orden de compra.rpt"






            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                        False, False, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub txtNumeroOC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroOC.TextChanged

    End Sub

    Private Function obtenerDocumentoRelacionados(ByVal pdocumento As String, ByVal pnumero As String) As DataTable
        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String

        Try
            otrans.open()
            lsSQL = "pa_sel_um_documento_relacionado '" & gs_empresa & "','" & pdocumento & "','" & pnumero & "'"
            dt = otrans.Obtiene(lsSQL)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        Return dt
    End Function


    Private Sub eliminarDocumentos()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            oTrans.open()
            lsSQL = " pa_sel_um_documento '" & gs_empresa & "',NULL,'" & Me.txtnumeroOCCreditos.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "sistema = 'compras' and clase = 'pedido (c)' and tipodocto <> 'ORDEN DE COMPRA'"
            dt = dt.DefaultView.ToTable
            '            dt.DefaultView.RowFilter = "tipodocto <> 'confirmacion proveedor'"
            dt.DefaultView.Sort = "fecha, fechavcto"

            Dim oform As New frm_resultado
            oform.dgv_resultado.DataSource = dt
            oform.Text = "::. Documentos a Eliminar .::"

            clsGen.Alinear_GridView(dt, oform.dgv_resultado, ",tipodocto,numero,fecha,fechavcto,comentario1,", "", "", "", "", "", "", False, True, 200, 0)
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing

            If MessageBox.Show("Desea Continuar con la Eliminacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim lsMotivo As String = InputBox("Cual Es El Motivo De La Eliminacion", "Ingresar Motivo")
                For Each dr As DataRow In dt.Rows
                    lsSQL = "pa_del_um_documento_completo '" & gs_empresa & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "'," & Integer.Parse(dr.Item("correlativo").ToString)
                    oTrans.Elimina(lsSQL)
                    If oTrans.Codigo_error = 0 Then
                        lsSQL = "pa_ins_um_gen_log_documento '" & gs_empresa & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "','E','" & lsMotivo & "'"
                        oTrans.Ingresa(lsSQL)
                    End If
                Next


                lsSQL = "pa_sel_um_documentod '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtnumeroOCCreditos.Text & "'"
                dt = oTrans.Obtiene(lsSQL)

                For Each dr As DataRow In dt.Rows
                    lsSQL = "pa_upd_um_documentod_asignado '" & gs_empresa & "','" & _
                            dr.Item("tipodocto").ToString & "'," & dr.Item("correlativo").ToString & ",'" & _
                            dr.Item("producto").ToString & "'," & dr.Item("Secuencia").ToString
                    oTrans.Actualiza(lsSQL)
                Next
            End If
            Log_OCconfirmacion(Me.txtnumeroOCCreditos.Text, "Propiedades_Situacion_Crediticia_eliminacion")
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.txtComentarioOCCreditos.Text = String.Empty
            Me.txtnumeroOCCreditos.Text = String.Empty

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta Seguro de Eliminar Los Documentos Relacionados Con La Orden de Compra", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim dt As DataTable = obtenerDocumentoRelacionados("FECHA INGRESO DEPOSITO ADUANERO", Me.txtnumeroOCCreditos.Text)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("tipoDoctoDestino").ToString.Length > 5 Then
                    MessageBox.Show("No se Pueden Eliminar Los Documentos " & Chr(13) & " ya existe " & dt.Rows(0).Item("tipodoctoDestino").ToString, "Confirmacion", MessageBoxButtons.OK)
                Else
                    eliminarDocumentos()
                End If
            Else
                eliminarDocumentos()
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ImprimirConfirmacion(Me.txtnumeroOCCreditos.Text)
    End Sub

    Private Sub txtValores_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValores.TextChanged
        txtValores.Text = Format(Convert.ToDecimal(txtValores.Text), "###,###,##0.00").ToString()

    End Sub

    Private Sub dgvProductosOC_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductosOC.CellContentClick

    End Sub

    Private Sub txt_moc_numeroOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_moc_numeroOC.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_moc_numeroOC.Text = Me.txt_moc_numeroOC.Text.PadLeft(10, "0")
            BuscarOCCreditos()
            moc_BuscarOC()
        End If
    End Sub

    Private Sub moc_BuscarOC()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'ORDEN DE COMPRA','" & gs_empresa & "','" & Me.txt_moc_numeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            ds.Tables("productos").Rows.Clear()
            Me.dgvProductosOC.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                Dim cantidadAsignada As Integer = dt.Compute("Sum(CantidadAsignada)", "cantidad>0")
                If cantidadAsignada = 0 Then
                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "s" And _
                        dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado
                        ' Me.dtpFechaVencimientoConfirmacion.Value = dt.Rows(0).Item("fechaVcto")
                        Me.dtp_mov_fecha_despacho.Value = dt.Rows(0).Item("fechaDespacho")
                        Me.txt_moc_paridad.Text = dt.Rows(0).Item("paridad").ToString
                        Me.txt_moc_moneda.Text = dt.Rows(0).Item("moneda").ToString
                        Me.txt_moc_proveedor.Text = dt.Rows(0)("proveedor").ToString
                        Me.txt_moc_comentario.Text = dt.Rows(0)("comentario1").ToString
                        Try
                            Me.dtp_moc_fechavencimiento.Value = dt.Rows(0).Item("fechavcto").ToString
                        Catch ex As Exception
                        End Try


                        ds.Tables("productos_moc").Rows.Clear()

                        For Each dr As DataRow In dt.Rows
                            draux = ds.Tables("productos_moc").NewRow
                            draux.Item("producto") = dr.Item("producto")
                            draux.Item("glosa") = dr.Item("glosa")
                            draux.Item("unidad") = dr.Item("unidadIngreso")
                            draux.Item("cantidad") = dr.Item("cantidadIngreso")
                            draux.Item("preciou") = dr.Item("precioIngreso")
                            draux.Item("total") = dr.Item("subtotalIngreso")
                            ds.Tables("productos_moc").Rows.Add(draux)
                        Next

                        Me.dg_moc_productos.DataSource = ds.Tables("productos_moc")

                        Dim dgtbc As New DataGridViewComboBoxColumn
                        dgtbc.DataSource = ds.Tables("tipo_unidad")
                        dgtbc.ValueMember = "unidad"
                        dgtbc.DisplayMember = "unidad"
                        dgtbc.HeaderText = "unidad"
                        dgtbc.DataPropertyName = "unidad"
                        dgtbc.Name = "unidad"

                        clsGen.Alinear_GridViewComboBox(dgtbc)
                        clsGen.Alinear_GridView(ds.Tables("productos_moc"), Me.dg_moc_productos, "", ",factoralt,", ",glosa,total,", ",cantidad,preciou,total,", "", "", "", True, True, 250, 0)
                    Else

                        If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                            MessageBox.Show("Esta Orden de Compra No Esta Vigente, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtNumeroOC.Text = String.Empty
                        Else
                            MessageBox.Show("Esta Orden de Compra Esta Anulada o Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtNumeroOC.Text = String.Empty
                        End If
                    End If
                Else
                    MessageBox.Show("Esta Orden de Compra ya Tiene Confirmacion de Proveedor", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtNumeroOC.Text = String.Empty
                End If

            Else

                MessageBox.Show("Problemas con Esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtNumeroOC.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
            TotalizarMoc()
        End Try

    End Sub


    Private Sub dg_moc_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_moc_productos.CellContentClick

    End Sub

    Private Sub TotalizarMoc()
        Try

            Dim total As Double
            total = ds.Tables("productos_moc").Rows.Count
            Me.txt_moc_lineas.Text = total
            total = ds.Tables("productos_moc").Compute("Sum(total)", "total>0")
            Me.txt_moc_valores.Text = total
            total = ds.Tables("productos_moc").Compute("Sum(cantidad)", "cantidad>0")
            Me.txt_moc_unidades.Text = total
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg_moc_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_moc_productos.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex



        Try

            'Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon

            Dim c As Control = Me.dg_moc_productos.EditingControl

            Select Case Me.dg_moc_productos.Columns(e.ColumnIndex).Name.ToLower
                Case "producto"

                    Dim dt As DataTable
                    If c.Text = "+" Then
                        Dim frm_busqueda As New frm_busqueda_general
                        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                        frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                        frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
                        frm_busqueda.txt_buscar1.Focus()
                        frm_busqueda.ShowDialog(Me)

                        c.Text = frm_busqueda.resultado
                        frm_busqueda.Dispose()
                        frm_busqueda = Nothing
                        dt = BuscarProducto(c.Text)
                    Else
                        dt = BuscarProducto(c.Text)
                    End If
                    If dt.Rows.Count = 1 Then
                        ''Validar que el cliente no este en la lista
                        If dt.Rows(0)("VIGENTE").ToString.ToLower = "s" Then
                            Me.dg_moc_productos.Item("producto", e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
                            Me.dg_moc_productos.Item("glosa", e.RowIndex).Value = dt.Rows(0).Item("glosa").ToString
                            Me.dg_moc_productos.Item("cantidad", e.RowIndex).Value = 0
                            Me.dg_moc_productos.Item("preciou", e.RowIndex).Value = 0
                            Me.dg_moc_productos.Item("total", e.RowIndex).Value = 0
                        Else
                            MessageBox.Show("El Producto No Esta Vigente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Case "cantidad"
                    If Me.dg_moc_productos.Item("preciou", e.RowIndex).Value > 0 Then
                        Me.dg_moc_productos.Item("total", e.RowIndex).Value = c.Text * Me.dg_moc_productos.Item("preciou", e.RowIndex).Value
                        TotalizarMoc()
                    End If
                Case "preciou"
                    If Me.dg_moc_productos.Item("cantidad", e.RowIndex).Value > 0 Then
                        Me.dg_moc_productos.Item("total", e.RowIndex).Value = c.Text * Me.dg_moc_productos.Item("cantidad", e.RowIndex).Value
                        TotalizarMoc()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub


    ''sobreescribo la Orden de Compra
    Private Sub Guardar_OC_MOV()

        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim icount, dfactoralt As Integer
        Dim dtotal As Double
        Dim lsSQL As String
        Dim blimpiarInformacion As Boolean = False

        Try
            Crear_Estructura_Auxiliar()
            otrans.open()
            dtotal = ds.Tables("productos_moc").Compute("Sum(total)", "total>0")
            dt = otrans.Obtiene("pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txt_moc_numeroOC.Text & "'")

            dr = dt.Rows(0)
            dr_aux = ds.Tables("documento").NewRow

            dr_aux.Item("empresa") = gs_empresa
            dr_aux.Item("TipoDocto") = "ORDEN DE COMPRA"
            dr_aux.Item("Numero") = dr.Item("numero").ToString
            dr_aux.Item("Correlativo") = dr.Item("correlativo").ToString
            dr_aux.Item("Fecha") = dr.Item("fecha").ToString("dd/MM/yyyy")
            dr_aux.Item("FechaVcto") = Me.dtp_moc_fechavencimiento.Value.ToString("dd/MM/yyyy")


            dr_aux.Item("ctacte") = String.Empty
            dr_aux.Item("proveedor") = dr.Item("proveedor")
            dr_aux.Item("idCtacte") = dr.Item("proveedor")
            dr_aux.Item("Bodega") = String.Empty
            dr_aux.Item("Vendedor") = String.Empty
            dr_aux.Item("ListaPrecio") = String.Empty
            dr_aux.Item("Moneda") = Me.txt_moc_moneda.Text
            dr_aux.Item("Paridad") = Me.txt_moc_paridad.Text

            dr_aux.Item("Neto") = dtotal * Double.Parse(Me.txt_moc_paridad.Text)
            dr_aux.Item("SubTotal") = dtotal * Double.Parse(Me.txt_moc_paridad.Text)
            dr_aux.Item("Total") = dtotal * Double.Parse(Me.txt_moc_paridad.Text)
            dr_aux.Item("NetoIngreso") = dtotal
            dr_aux.Item("SubTotalIngreso") = dtotal
            dr_aux.Item("TotalIngreso") = dtotal
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("Valoriza") = "S"
            dr_aux.Item("PeriodoLibro") = dr.Item("periodoLibro") 'Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = dr.Item("tipoctacte")
            dr_aux.Item("glosa") = dr.Item("glosa")
            dr_aux.Item("Comentario1") = Me.txt_moc_comentario.Text
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N"
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now

            dr_aux.Item("FechaUModif") = Now.ToString("dd/MM/yyyy HH:mm")
            dr_aux.Item("UsuarioModif") = gs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")

            'dr_aux.Item("Caja") = dr.Item("U_SSOCAJA")
            'dr_aux.Item("Pago") = dr_aux.Item("Total")
            'dr_aux.Item("IdApertura") = dr.Item("U_SSOSESION")

            dr_aux.Item("NetoBimoneda") = dr_aux.Item("NetoIngreso")
            dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("TotalIngreso")
            dr_aux.Item("TotalBimoneda") = dr_aux.Item("TotalIngreso")

            dr_aux.Item("ParidadBimoneda") = 1
            dr_aux.Item("AnalisisE3") = Me.dtp_mov_fecha_despacho.Value.ToString("dd/MM/yyyy")
            dr_aux.Item("AnalisisE7") = dr.Item("analisisE7")


            ds.Tables("documento").Rows.Add(dr_aux)


            ''Detalle
            Try

                dt = otrans.Obtiene("pa_sel_um_documentod '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOC.Text & "'")

                icount = 0
                For Each drv In ds.Tables("productos_moc").DefaultView


                    dt.DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "'"

                    dr_aux = ds.Tables("documentod").NewRow

                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "ORDEN DE COMPRA"
                    dr_aux.Item("Correlativo") = ds.Tables("documento").Rows(0)("correlativo")
                    dr_aux.Item("Producto") = drv.Item("Producto")


                    dfactoralt = drv.Item("factoralt")
                    If dfactoralt = 0 Then dfactoralt = 1

                    dr_aux.Item("Cantidad") = drv.Item("Cantidad") * dfactoralt
                    dr_aux.Item("Precio") = Round((drv.Item("preciou") * Me.txt_moc_paridad.Text) / dfactoralt, 4)

                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = Round(dr_aux.Item("cantidad") * dr_aux.Item("Precio"), 2)
                    dr_aux.Item("Impuesto") = 0 'Round(drv.Item("ValorImpuesto"), 2)
                    dr_aux.Item("Neto") = Round(dr_aux.Item("SubTotal"), 2)
                    dr_aux.Item("DrGlobal") = 0

                    dr_aux.Item("Total") = dr_aux.Item("Neto")
                    dr_aux.Item("PrecioAjustado") = dr_aux.Item("Precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = drv.Item("unidad")
                    dr_aux.Item("CantidadIngreso") = drv.Item("Cantidad")
                    dr_aux.Item("PrecioIngreso") = Round(drv.Item("preciou"), 2)
                    dr_aux.Item("SubTotalIngreso") = Round(drv.Item("total"), 2)
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = Round(drv.Item("total"), 2)
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = Round(drv.Item("total"), 2)


                    dr_aux.Item("FactorInventario") = 0
                    dr_aux.Item("FechaEntrega") = Me.dtp_moc_fechavencimiento.Value.ToString("dd/MM/yyyy")
                    dr_aux.Item("CantidadAsignada") = 0
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S"
                    dr_aux.Item("CUP") = 0
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1
                    dr_aux.Item("PrecioBimoneda") = Round(drv.Item("preciou"), 2)
                    dr_aux.Item("SubTotalBimoneda") = Round(drv.Item("total"), 2)
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = Round(drv.Item("total"), 2)
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = Round(drv.Item("total"), 2)

                    dr_aux.Item("DoctoOrigenVal") = "N"

                    If dt.DefaultView.Count > 0 Then
                        dr_aux.Item("Secuencia") = dt.DefaultView(0).Item("secuencia")
                        dr_aux.Item("Linea") = dt.DefaultView(0).Item("linea")
                        dr_aux.Item("TipoDoctoOrigen") = String.Empty
                        dr_aux.Item("CorrelativoOrigen") = 0
                        dr_aux.Item("SecuenciaOrigen") = dt.DefaultView(0).Item("secuencia")
                    Else
                        Try
                            icount = dt.Compute("max(Linea)", "Linea>0")
                            If icount < ds.Tables("documentod").Compute("max(Linea)", "Linea>0") Then
                                icount = ds.Tables("documentod").Compute("max(Linea)", "Linea>0")
                            End If
                        Catch ex As Exception
                        End Try

                        icount += 1
                        dr_aux.Item("Secuencia") = icount
                        dr_aux.Item("Linea") = icount
                        dr_aux.Item("TipoDoctoOrigen") = String.Empty
                        dr_aux.Item("CorrelativoOrigen") = 0
                        dr_aux.Item("SecuenciaOrigen") = 0
                    End If


                    Try
                        dr_aux.Item("costo") = 0
                    Catch ex As Exception
                        dr_aux.Item("costo") = 0
                    End Try

                    Try
                        dr_aux.Item("PrecioListaP") = 0
                    Catch ex As Exception
                        dr_aux.Item("PrecioListaP") = 0
                    End Try

                    ds.Tables("documentod").Rows.Add(dr_aux)
                Next


                'verificacion correlativos
                Try
                    icount = ds.Tables("documentod").Compute("max(SecuenciaOrigen)", "SecuenciaOrigen > 0")
                Catch ex As Exception
                    icount = 0
                End Try

                ds.Tables("documentod").DefaultView.RowFilter = "SecuenciaOrigen  = 0"
                ds.Tables("documentod").DefaultView.Sort = "linea"
                For Each drv In ds.Tables("documentod").DefaultView
                    icount += 1
                    drv.Item("secuencia") = icount
                    drv.Item("linea") = icount
                Next
                ds.Tables("documentod").DefaultView.RowFilter = ""

            Catch ex As Exception
            End Try

            ''Documentov


            Try
                For icount = 1 To 2
                    dr_aux = ds.Tables("documentov").NewRow
                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "ORDEN DE COMPRA"
                    dr_aux.Item("Correlativo") = ds.Tables("documento").Rows(0)("correlativo")

                    If icount = 1 Then
                        dr_aux.Item("Nombre") = "SUB_TOTAL"
                        dr_aux.Item("Orden") = 1
                        dr_aux.Item("Monto") = ds.Tables("documento").Rows(0)("Total")
                        dr_aux.Item("MontoIngreso") = ds.Tables("documento").Rows(0)("TotalIngreso")
                    ElseIf icount = 2 Then
                        dr_aux.Item("Nombre") = "TASA"
                        dr_aux.Item("Orden") = 2

                        dr_aux.Item("Monto") = 0

                    End If
                    If icount < 3 Then
                        dr_aux.Item("Factor") = 0
                        dr_aux.Item("Porcentaje") = 0
                    Else
                        dr_aux.Item("Factor") = 0
                    End If

                    dr_aux.Item("MontoBimoneda") = Round(dr_aux.Item("MontoIngreso"), 2)
                    dr_aux.Item("Ajuste") = 0
                    dr_aux.Item("AjusteIngreso") = 0

                    ds.Tables("documentov").Rows.Add(dr_aux)

                Next
            Catch ex As Exception
            End Try


            Dim osinc As New Sincronizacion.Documentos("")

            dr = ds.Tables("documento").Rows(0)
            Try
                osinc.Enviar_Documento(gs_empresa, dr, ds.Tables("documentod").DefaultView.ToTable, ds.Tables("documentov").DefaultView.ToTable, ds.Tables("documentop").DefaultView.ToTable, "", True)
                If osinc.codigo_error > 0 Then
                    MessageBox.Show("Problemas al Generar La Orden de Compra", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'For Each dr In ds.Tables("documentod").Rows
                    '    lsSQL = "pa_upd_um_documentod_asignado '" & gs_empresa & "','" & dr.Item("tipodoctoOrigen").ToString & "'," & dr.Item("correlativoOrigen") & ",'" & dr.Item("producto").ToString & "'," & dr.Item("SecuenciaOrigen")
                    '    otrans.Actualiza(lsSQL)
                    'Next
                Else
                    Log_OCconfirmacion(Me.txt_moc_numeroOC.Text, "Modificacion OCconfirmacion")
                    MessageBox.Show("Proceso Finalizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blimpiarInformacion = True
                End If

            Catch ex As Exception
            Finally
                osinc.Cerrar()
                osinc = Nothing
            End Try

        Catch ex As Exception
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

        If blimpiarInformacion Then
            limpiarInformacion_MOC()
        End If




    End Sub

    Private Sub limpiarInformacion_MOC()
        Me.txt_moc_paridad.Text = String.Empty
        Me.txt_moc_proveedor.Text = String.Empty
        Me.txt_moc_unidades.Text = String.Empty
        Me.txt_moc_valores.Text = String.Empty
        Me.txt_moc_numeroOC.Text = String.Empty
        Me.txt_moc_moneda.Text = String.Empty
        Me.txt_moc_lineas.Text = String.Empty
        Me.txt_moc_comentario.Text = String.Empty
        Me.dtp_moc_fechavencimiento.Value = Today.AddDays(-12)
        Me.dtp_mov_fecha_despacho.Value = Today.AddDays(-12)

        Me.dg_moc_productos.DataSource = Nothing
    End Sub

    Private Sub btn_aplicar_moc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_moc.Click
        If validarProductos("productos_moc") Then
            Guardar_OC_MOV()
        End If

    End Sub

    

  
End Class
