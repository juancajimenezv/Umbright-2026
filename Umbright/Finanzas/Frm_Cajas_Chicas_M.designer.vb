<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cajas_Chicas_M
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cajas_Chicas_M))
        Me.cb_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_Lote = New System.Windows.Forms.TextBox()
        Me.btn_BuscaLote = New System.Windows.Forms.Button()
        Me.btn_CreaLote = New System.Windows.Forms.Button()
        Me.btn_Proveedor = New System.Windows.Forms.Button()
        Me.lb_RazonSocial = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tb_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cb_Responsable = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_Renta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_Monto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_Serie = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cb_CCosto = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_Glosa = New System.Windows.Forms.TextBox()
        Me.lb_Desc_Producto = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_Exento = New System.Windows.Forms.TextBox()
        Me.tb_Item = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_Galones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Combustible = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cb_TipoIva = New System.Windows.Forms.ComboBox()
        Me.btn_Producto = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_Producto = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tb_SubTotal = New System.Windows.Forms.TextBox()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.lb_Total = New System.Windows.Forms.Label()
        Me.btn_Traslada = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Imprime = New System.Windows.Forms.Button()
        Me.tb_Nuevo = New System.Windows.Forms.Button()
        Me.lb_Mensaje = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lb_Iva = New System.Windows.Forms.Label()
        Me.lb_Estado = New System.Windows.Forms.Label()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_TipoDocto
        '
        Me.cb_TipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoDocto.FormattingEnabled = True
        Me.cb_TipoDocto.Location = New System.Drawing.Point(46, 85)
        Me.cb_TipoDocto.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_TipoDocto.Name = "cb_TipoDocto"
        Me.cb_TipoDocto.Size = New System.Drawing.Size(215, 28)
        Me.cb_TipoDocto.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_Lote)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaLote)
        Me.GroupBox1.Controls.Add(Me.btn_CreaLote)
        Me.GroupBox1.Controls.Add(Me.btn_Proveedor)
        Me.GroupBox1.Controls.Add(Me.lb_RazonSocial)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Tb_Proveedor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cb_TipoDocto)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(486, 175)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'tb_Lote
        '
        Me.tb_Lote.Location = New System.Drawing.Point(320, 34)
        Me.tb_Lote.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Lote.Name = "tb_Lote"
        Me.tb_Lote.Size = New System.Drawing.Size(72, 26)
        Me.tb_Lote.TabIndex = 18
        '
        'btn_BuscaLote
        '
        Me.btn_BuscaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_BuscaLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_BuscaLote.Location = New System.Drawing.Point(46, 23)
        Me.btn_BuscaLote.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_BuscaLote.Name = "btn_BuscaLote"
        Me.btn_BuscaLote.Size = New System.Drawing.Size(120, 37)
        Me.btn_BuscaLote.TabIndex = 14
        Me.btn_BuscaLote.Text = "Busca Lote"
        Me.btn_BuscaLote.UseVisualStyleBackColor = False
        '
        'btn_CreaLote
        '
        Me.btn_CreaLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_CreaLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_CreaLote.Location = New System.Drawing.Point(170, 23)
        Me.btn_CreaLote.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_CreaLote.Name = "btn_CreaLote"
        Me.btn_CreaLote.Size = New System.Drawing.Size(143, 37)
        Me.btn_CreaLote.TabIndex = 14
        Me.btn_CreaLote.Text = "Crea Lote"
        Me.btn_CreaLote.UseVisualStyleBackColor = False
        '
        'btn_Proveedor
        '
        Me.btn_Proveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Proveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Proveedor.Location = New System.Drawing.Point(399, 109)
        Me.btn_Proveedor.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Proveedor.Name = "btn_Proveedor"
        Me.btn_Proveedor.Size = New System.Drawing.Size(47, 35)
        Me.btn_Proveedor.TabIndex = 17
        Me.btn_Proveedor.Text = "P"
        Me.btn_Proveedor.UseVisualStyleBackColor = False
        '
        'lb_RazonSocial
        '
        Me.lb_RazonSocial.AutoSize = True
        Me.lb_RazonSocial.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_RazonSocial.Location = New System.Drawing.Point(47, 148)
        Me.lb_RazonSocial.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_RazonSocial.Name = "lb_RazonSocial"
        Me.lb_RazonSocial.Size = New System.Drawing.Size(108, 20)
        Me.lb_RazonSocial.TabIndex = 4
        Me.lb_RazonSocial.Text = "Razón Social"
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(263, 63)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 19)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Fecha:"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(263, 85)
        Me.dtp_Fecha.Margin = New System.Windows.Forms.Padding(2)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(132, 26)
        Me.dtp_Fecha.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(46, 115)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Proveedor:"
        '
        'Tb_Proveedor
        '
        Me.Tb_Proveedor.Location = New System.Drawing.Point(263, 116)
        Me.Tb_Proveedor.Margin = New System.Windows.Forms.Padding(2)
        Me.Tb_Proveedor.Name = "Tb_Proveedor"
        Me.Tb_Proveedor.Size = New System.Drawing.Size(132, 26)
        Me.Tb_Proveedor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(46, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cb_Responsable)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.tb_Renta)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.tb_Monto)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tb_Numero)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tb_Serie)
        Me.GroupBox2.Location = New System.Drawing.Point(503, 41)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(540, 142)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Factura"
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(58, 96)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 27)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Responsable:"
        '
        'cb_Responsable
        '
        Me.cb_Responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Responsable.FormattingEnabled = True
        Me.cb_Responsable.Location = New System.Drawing.Point(223, 95)
        Me.cb_Responsable.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Responsable.Name = "cb_Responsable"
        Me.cb_Responsable.Size = New System.Drawing.Size(243, 28)
        Me.cb_Responsable.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Location = New System.Drawing.Point(380, 35)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Renta:"
        '
        'tb_Renta
        '
        Me.tb_Renta.Location = New System.Drawing.Point(380, 63)
        Me.tb_Renta.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Renta.Name = "tb_Renta"
        Me.tb_Renta.Size = New System.Drawing.Size(142, 26)
        Me.tb_Renta.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(283, 35)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Monto:"
        '
        'tb_Monto
        '
        Me.tb_Monto.Location = New System.Drawing.Point(283, 63)
        Me.tb_Monto.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Monto.Name = "tb_Monto"
        Me.tb_Monto.Size = New System.Drawing.Size(91, 26)
        Me.tb_Monto.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(177, 35)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 23)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Numero:"
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(177, 63)
        Me.tb_Numero.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(104, 26)
        Me.tb_Numero.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(59, 35)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Serie:"
        '
        'tb_Serie
        '
        Me.tb_Serie.Location = New System.Drawing.Point(58, 63)
        Me.tb_Serie.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Serie.Name = "tb_Serie"
        Me.tb_Serie.Size = New System.Drawing.Size(114, 26)
        Me.tb_Serie.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(638, 331)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(203, 22)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Centro Costo"
        '
        'cb_CCosto
        '
        Me.cb_CCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CCosto.FormattingEnabled = True
        Me.cb_CCosto.Location = New System.Drawing.Point(637, 354)
        Me.cb_CCosto.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_CCosto.Name = "cb_CCosto"
        Me.cb_CCosto.Size = New System.Drawing.Size(204, 28)
        Me.cb_CCosto.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.tb_Glosa)
        Me.GroupBox3.Controls.Add(Me.lb_Desc_Producto)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tb_Exento)
        Me.GroupBox3.Controls.Add(Me.tb_Item)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.tb_Galones)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cb_Combustible)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cb_TipoIva)
        Me.GroupBox3.Controls.Add(Me.btn_Producto)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.tb_Producto)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(7, 186)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(1036, 140)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(6, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1023, 23)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Comentario:"
        '
        'tb_Glosa
        '
        Me.tb_Glosa.Location = New System.Drawing.Point(6, 107)
        Me.tb_Glosa.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Glosa.Name = "tb_Glosa"
        Me.tb_Glosa.Size = New System.Drawing.Size(1023, 26)
        Me.tb_Glosa.TabIndex = 10
        '
        'lb_Desc_Producto
        '
        Me.lb_Desc_Producto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lb_Desc_Producto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Desc_Producto.Location = New System.Drawing.Point(140, 52)
        Me.lb_Desc_Producto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_Desc_Producto.Name = "lb_Desc_Producto"
        Me.lb_Desc_Producto.Size = New System.Drawing.Size(320, 27)
        Me.lb_Desc_Producto.TabIndex = 13
        Me.lb_Desc_Producto.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(465, 26)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 23)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Item"
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Location = New System.Drawing.Point(910, 27)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 23)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Exento"
        '
        'tb_Exento
        '
        Me.tb_Exento.Location = New System.Drawing.Point(911, 54)
        Me.tb_Exento.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Exento.Name = "tb_Exento"
        Me.tb_Exento.Size = New System.Drawing.Size(120, 26)
        Me.tb_Exento.TabIndex = 5
        '
        'tb_Item
        '
        Me.tb_Item.Location = New System.Drawing.Point(466, 53)
        Me.tb_Item.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Item.Name = "tb_Item"
        Me.tb_Item.Size = New System.Drawing.Size(95, 26)
        Me.tb_Item.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(817, 26)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 23)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Galones"
        '
        'tb_Galones
        '
        Me.tb_Galones.Location = New System.Drawing.Point(817, 53)
        Me.tb_Galones.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Galones.Name = "tb_Galones"
        Me.tb_Galones.Size = New System.Drawing.Size(91, 26)
        Me.tb_Galones.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(687, 26)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 23)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Combustible Tipo"
        '
        'cb_Combustible
        '
        Me.cb_Combustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Combustible.FormattingEnabled = True
        Me.cb_Combustible.Items.AddRange(New Object() {"SUPER", "REGULAR", "DIESEL", "VI POWER"})
        Me.cb_Combustible.Location = New System.Drawing.Point(687, 52)
        Me.cb_Combustible.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Combustible.Name = "cb_Combustible"
        Me.cb_Combustible.Size = New System.Drawing.Size(129, 28)
        Me.cb_Combustible.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(562, 26)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Clase IVA"
        '
        'cb_TipoIva
        '
        Me.cb_TipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoIva.FormattingEnabled = True
        Me.cb_TipoIva.Location = New System.Drawing.Point(561, 53)
        Me.cb_TipoIva.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_TipoIva.Name = "cb_TipoIva"
        Me.cb_TipoIva.Size = New System.Drawing.Size(124, 28)
        Me.cb_TipoIva.TabIndex = 9
        '
        'btn_Producto
        '
        Me.btn_Producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Producto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Producto.Location = New System.Drawing.Point(104, 52)
        Me.btn_Producto.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Producto.Name = "btn_Producto"
        Me.btn_Producto.Size = New System.Drawing.Size(32, 29)
        Me.btn_Producto.TabIndex = 2
        Me.btn_Producto.Text = "Button1"
        Me.btn_Producto.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Location = New System.Drawing.Point(5, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 23)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Producto"
        '
        'tb_Producto
        '
        Me.tb_Producto.Location = New System.Drawing.Point(6, 54)
        Me.tb_Producto.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Producto.Name = "tb_Producto"
        Me.tb_Producto.Size = New System.Drawing.Size(98, 26)
        Me.tb_Producto.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(517, 331)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 22)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Sub Total:"
        '
        'tb_SubTotal
        '
        Me.tb_SubTotal.Location = New System.Drawing.Point(516, 355)
        Me.tb_SubTotal.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_SubTotal.Name = "tb_SubTotal"
        Me.tb_SubTotal.Size = New System.Drawing.Size(119, 26)
        Me.tb_SubTotal.TabIndex = 11
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(894, 330)
        Me.btn_Agregar.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(100, 51)
        Me.btn_Agregar.TabIndex = 14
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'cb_Empresa
        '
        Me.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa.FormattingEnabled = True
        Me.cb_Empresa.Location = New System.Drawing.Point(13, 342)
        Me.cb_Empresa.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Empresa.Name = "cb_Empresa"
        Me.cb_Empresa.Size = New System.Drawing.Size(101, 28)
        Me.cb_Empresa.TabIndex = 17
        Me.cb_Empresa.Visible = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 15)
        Me.dgv_Detalle.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.RowHeadersWidth = 62
        Me.dgv_Detalle.Size = New System.Drawing.Size(1033, 162)
        Me.dgv_Detalle.TabIndex = 4
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgv_Detalle)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 386)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(1045, 188)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label16.Location = New System.Drawing.Point(830, 588)
        Me.label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(51, 22)
        Me.label16.TabIndex = 6
        Me.label16.Text = "Total"
        '
        'lb_Total
        '
        Me.lb_Total.AutoSize = True
        Me.lb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Total.Location = New System.Drawing.Point(889, 585)
        Me.lb_Total.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_Total.Name = "lb_Total"
        Me.lb_Total.Size = New System.Drawing.Size(75, 33)
        Me.lb_Total.TabIndex = 7
        Me.lb_Total.Text = "0.00"
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
        Me.btn_Traslada.Location = New System.Drawing.Point(227, 579)
        Me.btn_Traslada.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Traslada.Name = "btn_Traslada"
        Me.btn_Traslada.Size = New System.Drawing.Size(134, 48)
        Me.btn_Traslada.TabIndex = 8
        Me.btn_Traslada.Text = "Trasladar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FlexLine"
        Me.btn_Traslada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Traslada.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297283_unknown.png")
        Me.ImageList1.Images.SetKeyName(1, "Actualizar_Blue.png")
        Me.ImageList1.Images.SetKeyName(2, "printer_48.png")
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
        Me.btn_Imprime.Location = New System.Drawing.Point(82, 579)
        Me.btn_Imprime.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Imprime.Name = "btn_Imprime"
        Me.btn_Imprime.Size = New System.Drawing.Size(134, 48)
        Me.btn_Imprime.TabIndex = 9
        Me.btn_Imprime.Text = "Impresión"
        Me.btn_Imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprime.UseVisualStyleBackColor = False
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
        Me.tb_Nuevo.Location = New System.Drawing.Point(373, 579)
        Me.tb_Nuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Nuevo.Name = "tb_Nuevo"
        Me.tb_Nuevo.Size = New System.Drawing.Size(134, 48)
        Me.tb_Nuevo.TabIndex = 10
        Me.tb_Nuevo.Text = "Nuevo"
        Me.tb_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tb_Nuevo.UseVisualStyleBackColor = False
        '
        'lb_Mensaje
        '
        Me.lb_Mensaje.AutoSize = True
        Me.lb_Mensaje.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Mensaje.Location = New System.Drawing.Point(527, 744)
        Me.lb_Mensaje.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_Mensaje.Name = "lb_Mensaje"
        Me.lb_Mensaje.Size = New System.Drawing.Size(81, 20)
        Me.lb_Mensaje.TabIndex = 11
        Me.lb_Mensaje.Text = "Mensajes"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(645, 589)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 20)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Iva"
        '
        'lb_Iva
        '
        Me.lb_Iva.AutoSize = True
        Me.lb_Iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Iva.Location = New System.Drawing.Point(681, 585)
        Me.lb_Iva.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_Iva.Name = "lb_Iva"
        Me.lb_Iva.Size = New System.Drawing.Size(75, 33)
        Me.lb_Iva.TabIndex = 13
        Me.lb_Iva.Text = "0.00"
        '
        'lb_Estado
        '
        Me.lb_Estado.AutoSize = True
        Me.lb_Estado.Location = New System.Drawing.Point(5, 347)
        Me.lb_Estado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lb_Estado.Name = "lb_Estado"
        Me.lb_Estado.Size = New System.Drawing.Size(0, 20)
        Me.lb_Estado.TabIndex = 14
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Limpiar.Location = New System.Drawing.Point(584, 4)
        Me.btn_Limpiar.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(96, 33)
        Me.btn_Limpiar.TabIndex = 15
        Me.btn_Limpiar.Text = "Nuevo"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'btn_Guardar
        '
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Guardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Guardar.Location = New System.Drawing.Point(689, 4)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(88, 33)
        Me.btn_Guardar.TabIndex = 16
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = False
        '
        'Frm_Cajas_Chicas_M
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1060, 632)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.tb_SubTotal)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.cb_Empresa)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.lb_Estado)
        Me.Controls.Add(Me.cb_CCosto)
        Me.Controls.Add(Me.lb_Iva)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lb_Mensaje)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.btn_Imprime)
        Me.Controls.Add(Me.tb_Nuevo)
        Me.Controls.Add(Me.btn_Traslada)
        Me.Controls.Add(Me.lb_Total)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Frm_Cajas_Chicas_M"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Cajas Chicas Distribución 25.02.21"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_TipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lb_RazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tb_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_Producto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cb_TipoIva As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Producto As System.Windows.Forms.Button
    Friend WithEvents dgv_Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_Combustible As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_Exento As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_Galones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cb_CCosto As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tb_Item As System.Windows.Forms.TextBox
    Friend WithEvents lb_Desc_Producto As System.Windows.Forms.Label
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_Glosa As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents lb_Total As System.Windows.Forms.Label
    Friend WithEvents btn_Traslada As System.Windows.Forms.Button
    Friend WithEvents btn_Imprime As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_Renta As System.Windows.Forms.TextBox
    Friend WithEvents tb_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cb_Responsable As System.Windows.Forms.ComboBox
    Friend WithEvents lb_Mensaje As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lb_Iva As System.Windows.Forms.Label
    Friend WithEvents btn_Proveedor As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_BuscaLote As System.Windows.Forms.Button
    Friend WithEvents btn_CreaLote As System.Windows.Forms.Button
    Friend WithEvents tb_Lote As System.Windows.Forms.TextBox
    Friend WithEvents lb_Estado As System.Windows.Forms.Label
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tb_SubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btn_Guardar As Button
End Class
