<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cajas_Chicas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cajas_Chicas))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lb_Estado = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_Lote = New System.Windows.Forms.TextBox()
        Me.btn_BuscaLote = New System.Windows.Forms.Button()
        Me.btn_CreaLote = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_diferencial = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cb_Responsable = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Proveedor = New System.Windows.Forms.Button()
        Me.Tb_Proveedor = New System.Windows.Forms.TextBox()
        Me.tb_Renta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lb_RazonSocial = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.cb_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cb_CCosto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_Monto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_Serie = New System.Windows.Forms.TextBox()
        Me.lb_Iva = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_Idp = New System.Windows.Forms.Label()
        Me.lbl_impTurismo = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_Isr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_Glosa = New System.Windows.Forms.TextBox()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.lb_Desc_Producto = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tb_Item = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_Galones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Combustible = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_Exento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cb_TipoIva = New System.Windows.Forms.ComboBox()
        Me.btn_Producto = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_Producto = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.lb_Mensaje = New System.Windows.Forms.Label()
        Me.label16 = New System.Windows.Forms.Label()
        Me.btn_Imprime = New System.Windows.Forms.Button()
        Me.lb_Total = New System.Windows.Forms.Label()
        Me.tb_Nuevo = New System.Windows.Forms.Button()
        Me.btn_Traslada = New System.Windows.Forms.Button()
        Me.Operación = New System.Windows.Forms.TabControl()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Operación.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297283_unknown.png")
        Me.ImageList1.Images.SetKeyName(1, "Actualizar_Blue.png")
        Me.ImageList1.Images.SetKeyName(2, "printer_48.png")
        '
        'lb_Estado
        '
        Me.lb_Estado.AutoSize = True
        Me.lb_Estado.Location = New System.Drawing.Point(9, 534)
        Me.lb_Estado.Name = "lb_Estado"
        Me.lb_Estado.Size = New System.Drawing.Size(0, 20)
        Me.lb_Estado.TabIndex = 14
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1356, 840)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btn_Limpiar)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.lb_Iva)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.lb_Mensaje)
        Me.TabPage1.Controls.Add(Me.label16)
        Me.TabPage1.Controls.Add(Me.btn_Imprime)
        Me.TabPage1.Controls.Add(Me.lb_Total)
        Me.TabPage1.Controls.Add(Me.tb_Nuevo)
        Me.TabPage1.Controls.Add(Me.btn_Traslada)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1356, 840)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Operación"
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Limpiar.Location = New System.Drawing.Point(276, 111)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(90, 49)
        Me.btn_Limpiar.TabIndex = 15
        Me.btn_Limpiar.Text = "Nuevo"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_Lote)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaLote)
        Me.GroupBox1.Controls.Add(Me.btn_CreaLote)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 101)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'tb_Lote
        '
        Me.tb_Lote.Location = New System.Drawing.Point(231, 31)
        Me.tb_Lote.Multiline = True
        Me.tb_Lote.Name = "tb_Lote"
        Me.tb_Lote.Size = New System.Drawing.Size(106, 38)
        Me.tb_Lote.TabIndex = 18
        '
        'btn_BuscaLote
        '
        Me.btn_BuscaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_BuscaLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_BuscaLote.Location = New System.Drawing.Point(15, 28)
        Me.btn_BuscaLote.Name = "btn_BuscaLote"
        Me.btn_BuscaLote.Size = New System.Drawing.Size(103, 49)
        Me.btn_BuscaLote.TabIndex = 14
        Me.btn_BuscaLote.Text = "Busca Lote"
        Me.btn_BuscaLote.UseVisualStyleBackColor = False
        '
        'btn_CreaLote
        '
        Me.btn_CreaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_CreaLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_CreaLote.Location = New System.Drawing.Point(127, 28)
        Me.btn_CreaLote.Name = "btn_CreaLote"
        Me.btn_CreaLote.Size = New System.Drawing.Size(95, 49)
        Me.btn_CreaLote.TabIndex = 14
        Me.btn_CreaLote.Text = "Crea Lote"
        Me.btn_CreaLote.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txt_diferencial)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cb_Responsable)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btn_Proveedor)
        Me.GroupBox2.Controls.Add(Me.Tb_Proveedor)
        Me.GroupBox2.Controls.Add(Me.tb_Renta)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.lb_RazonSocial)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox2.Controls.Add(Me.cb_TipoDocto)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.cb_CCosto)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.tb_Monto)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tb_Numero)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tb_Serie)
        Me.GroupBox2.Location = New System.Drawing.Point(372, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(970, 163)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Factura"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(737, 136)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 20)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Diferencial:"
        '
        'txt_diferencial
        '
        Me.txt_diferencial.Location = New System.Drawing.Point(839, 133)
        Me.txt_diferencial.Name = "txt_diferencial"
        Me.txt_diferencial.Size = New System.Drawing.Size(125, 26)
        Me.txt_diferencial.TabIndex = 18
        Me.txt_diferencial.Text = "0.00"
        Me.txt_diferencial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(721, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 20)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Responsable:"
        '
        'cb_Responsable
        '
        Me.cb_Responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Responsable.FormattingEnabled = True
        Me.cb_Responsable.Location = New System.Drawing.Point(715, 97)
        Me.cb_Responsable.Name = "cb_Responsable"
        Me.cb_Responsable.Size = New System.Drawing.Size(249, 28)
        Me.cb_Responsable.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(584, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Renta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Proveedor:"
        '
        'btn_Proveedor
        '
        Me.btn_Proveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Proveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Proveedor.Location = New System.Drawing.Point(19, 90)
        Me.btn_Proveedor.Name = "btn_Proveedor"
        Me.btn_Proveedor.Size = New System.Drawing.Size(47, 43)
        Me.btn_Proveedor.TabIndex = 17
        Me.btn_Proveedor.Text = "P"
        Me.btn_Proveedor.UseVisualStyleBackColor = False
        '
        'Tb_Proveedor
        '
        Me.Tb_Proveedor.Location = New System.Drawing.Point(73, 100)
        Me.Tb_Proveedor.Name = "Tb_Proveedor"
        Me.Tb_Proveedor.Size = New System.Drawing.Size(142, 26)
        Me.Tb_Proveedor.TabIndex = 2
        '
        'tb_Renta
        '
        Me.tb_Renta.Location = New System.Drawing.Point(577, 96)
        Me.tb_Renta.Name = "tb_Renta"
        Me.tb_Renta.Size = New System.Drawing.Size(125, 26)
        Me.tb_Renta.TabIndex = 11
        Me.tb_Renta.Text = "0.00"
        Me.tb_Renta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(306, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Fecha:"
        '
        'lb_RazonSocial
        '
        Me.lb_RazonSocial.AutoSize = True
        Me.lb_RazonSocial.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_RazonSocial.Location = New System.Drawing.Point(76, 133)
        Me.lb_RazonSocial.Name = "lb_RazonSocial"
        Me.lb_RazonSocial.Size = New System.Drawing.Size(108, 20)
        Me.lb_RazonSocial.TabIndex = 4
        Me.lb_RazonSocial.Text = "Razón Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo:"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(374, 25)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(142, 26)
        Me.dtp_Fecha.TabIndex = 4
        '
        'cb_TipoDocto
        '
        Me.cb_TipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoDocto.FormattingEnabled = True
        Me.cb_TipoDocto.Location = New System.Drawing.Point(73, 26)
        Me.cb_TipoDocto.Name = "cb_TipoDocto"
        Me.cb_TipoDocto.Size = New System.Drawing.Size(227, 28)
        Me.cb_TipoDocto.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(373, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 20)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Centro Costo:"
        '
        'cb_CCosto
        '
        Me.cb_CCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CCosto.FormattingEnabled = True
        Me.cb_CCosto.Location = New System.Drawing.Point(368, 96)
        Me.cb_CCosto.Name = "cb_CCosto"
        Me.cb_CCosto.Size = New System.Drawing.Size(197, 28)
        Me.cb_CCosto.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(231, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Monto:"
        '
        'tb_Monto
        '
        Me.tb_Monto.Location = New System.Drawing.Point(226, 98)
        Me.tb_Monto.Name = "tb_Monto"
        Me.tb_Monto.Size = New System.Drawing.Size(124, 26)
        Me.tb_Monto.TabIndex = 6
        Me.tb_Monto.Text = "0.00"
        Me.tb_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(527, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Numero:"
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(606, 26)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(149, 26)
        Me.tb_Numero.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(771, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Serie:"
        '
        'tb_Serie
        '
        Me.tb_Serie.Location = New System.Drawing.Point(830, 25)
        Me.tb_Serie.Name = "tb_Serie"
        Me.tb_Serie.Size = New System.Drawing.Size(131, 26)
        Me.tb_Serie.TabIndex = 0
        '
        'lb_Iva
        '
        Me.lb_Iva.AutoSize = True
        Me.lb_Iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Iva.Location = New System.Drawing.Point(930, 694)
        Me.lb_Iva.Name = "lb_Iva"
        Me.lb_Iva.Size = New System.Drawing.Size(75, 33)
        Me.lb_Iva.TabIndex = 13
        Me.lb_Iva.Text = "0.00"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_Idp)
        Me.GroupBox3.Controls.Add(Me.lbl_impTurismo)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txt_Isr)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.tb_Glosa)
        Me.GroupBox3.Controls.Add(Me.btn_Agregar)
        Me.GroupBox3.Controls.Add(Me.lb_Desc_Producto)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.tb_Item)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.tb_Galones)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cb_Combustible)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tb_Exento)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cb_TipoIva)
        Me.GroupBox3.Controls.Add(Me.btn_Producto)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.tb_Producto)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 177)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1337, 154)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle"
        '
        'lbl_Idp
        '
        Me.lbl_Idp.AutoSize = True
        Me.lbl_Idp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Idp.Location = New System.Drawing.Point(1236, 50)
        Me.lbl_Idp.Name = "lbl_Idp"
        Me.lbl_Idp.Size = New System.Drawing.Size(40, 20)
        Me.lbl_Idp.TabIndex = 22
        Me.lbl_Idp.Text = "0.00"
        '
        'lbl_impTurismo
        '
        Me.lbl_impTurismo.AutoSize = True
        Me.lbl_impTurismo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_impTurismo.Location = New System.Drawing.Point(1236, 25)
        Me.lbl_impTurismo.Name = "lbl_impTurismo"
        Me.lbl_impTurismo.Size = New System.Drawing.Size(40, 20)
        Me.lbl_impTurismo.TabIndex = 21
        Me.lbl_impTurismo.Text = "0.00"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(1112, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 20)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "Imp.Combust:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(1116, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Imp.Turismo:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(688, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 20)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Ret. ISR:"
        '
        'txt_Isr
        '
        Me.txt_Isr.Location = New System.Drawing.Point(682, 45)
        Me.txt_Isr.Name = "txt_Isr"
        Me.txt_Isr.Size = New System.Drawing.Size(108, 26)
        Me.txt_Isr.TabIndex = 17
        Me.txt_Isr.Text = "0.00"
        Me.txt_Isr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Glosa:"
        '
        'tb_Glosa
        '
        Me.tb_Glosa.Location = New System.Drawing.Point(77, 104)
        Me.tb_Glosa.Name = "tb_Glosa"
        Me.tb_Glosa.Size = New System.Drawing.Size(1047, 26)
        Me.tb_Glosa.TabIndex = 15
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(1181, 86)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(124, 58)
        Me.btn_Agregar.TabIndex = 14
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'lb_Desc_Producto
        '
        Me.lb_Desc_Producto.AutoSize = True
        Me.lb_Desc_Producto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Desc_Producto.Location = New System.Drawing.Point(82, 75)
        Me.lb_Desc_Producto.Name = "lb_Desc_Producto"
        Me.lb_Desc_Producto.Size = New System.Drawing.Size(99, 20)
        Me.lb_Desc_Producto.TabIndex = 13
        Me.lb_Desc_Producto.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(300, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 20)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Item:"
        '
        'tb_Item
        '
        Me.tb_Item.Location = New System.Drawing.Point(294, 44)
        Me.tb_Item.Name = "tb_Item"
        Me.tb_Item.Size = New System.Drawing.Size(126, 26)
        Me.tb_Item.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(955, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 20)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Galones:"
        '
        'tb_Galones
        '
        Me.tb_Galones.Location = New System.Drawing.Point(950, 44)
        Me.tb_Galones.Name = "tb_Galones"
        Me.tb_Galones.Size = New System.Drawing.Size(106, 26)
        Me.tb_Galones.TabIndex = 9
        Me.tb_Galones.Text = "0.00"
        Me.tb_Galones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(801, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Combustible Tipo:"
        '
        'cb_Combustible
        '
        Me.cb_Combustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Combustible.FormattingEnabled = True
        Me.cb_Combustible.Items.AddRange(New Object() {"SUPER", "REGULAR", "DIESEL", "VI POWER"})
        Me.cb_Combustible.Location = New System.Drawing.Point(797, 44)
        Me.cb_Combustible.Name = "cb_Combustible"
        Me.cb_Combustible.Size = New System.Drawing.Size(146, 28)
        Me.cb_Combustible.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(581, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Exento:"
        '
        'tb_Exento
        '
        Me.tb_Exento.Location = New System.Drawing.Point(572, 44)
        Me.tb_Exento.Name = "tb_Exento"
        Me.tb_Exento.Size = New System.Drawing.Size(105, 26)
        Me.tb_Exento.TabIndex = 5
        Me.tb_Exento.Text = "0.00"
        Me.tb_Exento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(429, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Clase IVA:"
        '
        'cb_TipoIva
        '
        Me.cb_TipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoIva.FormattingEnabled = True
        Me.cb_TipoIva.Location = New System.Drawing.Point(423, 43)
        Me.cb_TipoIva.Name = "cb_TipoIva"
        Me.cb_TipoIva.Size = New System.Drawing.Size(144, 28)
        Me.cb_TipoIva.TabIndex = 3
        '
        'btn_Producto
        '
        Me.btn_Producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Producto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Producto.Location = New System.Drawing.Point(225, 25)
        Me.btn_Producto.Name = "btn_Producto"
        Me.btn_Producto.Size = New System.Drawing.Size(50, 44)
        Me.btn_Producto.TabIndex = 2
        Me.btn_Producto.Text = "?"
        Me.btn_Producto.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(82, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Producto / Item:"
        '
        'tb_Producto
        '
        Me.tb_Producto.Location = New System.Drawing.Point(77, 38)
        Me.tb_Producto.Name = "tb_Producto"
        Me.tb_Producto.Size = New System.Drawing.Size(145, 26)
        Me.tb_Producto.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(881, 700)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 20)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Iva"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 337)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1345, 333)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.RowHeadersWidth = 62
        Me.dgv_Detalle.Size = New System.Drawing.Size(1331, 304)
        Me.dgv_Detalle.TabIndex = 4
        '
        'lb_Mensaje
        '
        Me.lb_Mensaje.AutoSize = True
        Me.lb_Mensaje.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Mensaje.Location = New System.Drawing.Point(837, 732)
        Me.lb_Mensaje.Name = "lb_Mensaje"
        Me.lb_Mensaje.Size = New System.Drawing.Size(81, 20)
        Me.lb_Mensaje.TabIndex = 11
        Me.lb_Mensaje.Text = "Mensajes"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label16.Location = New System.Drawing.Point(1108, 702)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(51, 22)
        Me.label16.TabIndex = 6
        Me.label16.Text = "Total"
        '
        'btn_Imprime
        '
        Me.btn_Imprime.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Imprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Imprime.ImageKey = "printer_48.png"
        Me.btn_Imprime.ImageList = Me.ImageList1
        Me.btn_Imprime.Location = New System.Drawing.Point(39, 687)
        Me.btn_Imprime.Name = "btn_Imprime"
        Me.btn_Imprime.Size = New System.Drawing.Size(176, 86)
        Me.btn_Imprime.TabIndex = 9
        Me.btn_Imprime.Text = "Impresión"
        Me.btn_Imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprime.UseVisualStyleBackColor = False
        '
        'lb_Total
        '
        Me.lb_Total.AutoSize = True
        Me.lb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Total.Location = New System.Drawing.Point(1180, 697)
        Me.lb_Total.Name = "lb_Total"
        Me.lb_Total.Size = New System.Drawing.Size(75, 33)
        Me.lb_Total.TabIndex = 7
        Me.lb_Total.Text = "0.00"
        '
        'tb_Nuevo
        '
        Me.tb_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.tb_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tb_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tb_Nuevo.ImageKey = "1286297283_unknown.png"
        Me.tb_Nuevo.ImageList = Me.ImageList1
        Me.tb_Nuevo.Location = New System.Drawing.Point(417, 687)
        Me.tb_Nuevo.Name = "tb_Nuevo"
        Me.tb_Nuevo.Size = New System.Drawing.Size(175, 86)
        Me.tb_Nuevo.TabIndex = 10
        Me.tb_Nuevo.Text = "Nuevo"
        Me.tb_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tb_Nuevo.UseVisualStyleBackColor = False
        '
        'btn_Traslada
        '
        Me.btn_Traslada.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Traslada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Traslada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Traslada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Traslada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Traslada.ImageKey = "Actualizar_Blue.png"
        Me.btn_Traslada.ImageList = Me.ImageList1
        Me.btn_Traslada.Location = New System.Drawing.Point(221, 687)
        Me.btn_Traslada.Name = "btn_Traslada"
        Me.btn_Traslada.Size = New System.Drawing.Size(191, 86)
        Me.btn_Traslada.TabIndex = 8
        Me.btn_Traslada.Text = "Trasladar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FlexLine"
        Me.btn_Traslada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Traslada.UseVisualStyleBackColor = False
        '
        'Operación
        '
        Me.Operación.Controls.Add(Me.TabPage1)
        Me.Operación.Controls.Add(Me.TabPage2)
        Me.Operación.Location = New System.Drawing.Point(2, 3)
        Me.Operación.Name = "Operación"
        Me.Operación.SelectedIndex = 0
        Me.Operación.Size = New System.Drawing.Size(1364, 873)
        Me.Operación.TabIndex = 16
        '
        'Frm_Cajas_Chicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1371, 888)
        Me.Controls.Add(Me.Operación)
        Me.Controls.Add(Me.lb_Estado)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Cajas_Chicas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Cajas Chicas 25.4.2"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Operación.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lb_Estado As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btn_Limpiar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tb_Lote As TextBox
    Friend WithEvents btn_BuscaLote As Button
    Friend WithEvents btn_CreaLote As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cb_Responsable As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_Proveedor As Button
    Friend WithEvents Tb_Proveedor As TextBox
    Friend WithEvents tb_Renta As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lb_RazonSocial As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp_Fecha As DateTimePicker
    Friend WithEvents cb_TipoDocto As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cb_CCosto As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tb_Monto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tb_Numero As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tb_Serie As TextBox
    Friend WithEvents lb_Iva As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_Glosa As TextBox
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents lb_Desc_Producto As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents tb_Item As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tb_Galones As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cb_Combustible As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tb_Exento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cb_TipoIva As ComboBox
    Friend WithEvents btn_Producto As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents tb_Producto As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgv_Detalle As DataGridView
    Friend WithEvents lb_Mensaje As Label
    Friend WithEvents label16 As Label
    Friend WithEvents btn_Imprime As Button
    Friend WithEvents lb_Total As Label
    Friend WithEvents tb_Nuevo As Button
    Friend WithEvents btn_Traslada As Button
    Friend WithEvents Operación As TabControl
    Friend WithEvents Label19 As Label
    Friend WithEvents txt_Isr As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txt_diferencial As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lbl_Idp As Label
    Friend WithEvents lbl_impTurismo As Label
    Friend WithEvents Label22 As Label
End Class
