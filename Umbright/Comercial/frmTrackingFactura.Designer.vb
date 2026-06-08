<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTrackingFactura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrackingFactura))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_facturas = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDireccionEntrega = New System.Windows.Forms.TextBox()
        Me.txt_aprobacion_pedido = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_total_pedido = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.txt_aprobacion = New System.Windows.Forms.TextBox()
        Me.txt_fecha_grabo = New System.Windows.Forms.TextBox()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.txt_lista_precios = New System.Windows.Forms.TextBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.txt_tipo_pedido = New System.Windows.Forms.TextBox()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_controles_asociados = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dg_picking = New System.Windows.Forms.DataGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dg_control_transporte = New System.Windows.Forms.DataGrid()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGrid()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbTipoDocto = New System.Windows.Forms.ComboBox()
        Me.txtNumeroFactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.nupAnio = New System.Windows.Forms.NumericUpDown()
        Me.gbWalmart = New System.Windows.Forms.GroupBox()
        Me.dgWalmart = New System.Windows.Forms.DataGrid()
        Me.txtSerieFEL = New System.Windows.Forms.TextBox()
        Me.txtNumeroFel = New System.Windows.Forms.TextBox()
        Me.lblSerieFEL = New System.Windows.Forms.Label()
        Me.lblNumeroFEL = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWalmart.SuspendLayout()
        CType(Me.dgWalmart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_facturas)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(904, 85)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Facturacion"
        '
        'dgv_facturas
        '
        Me.dgv_facturas.AllowUserToAddRows = False
        Me.dgv_facturas.AllowUserToDeleteRows = False
        Me.dgv_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_facturas.Location = New System.Drawing.Point(8, 14)
        Me.dgv_facturas.Name = "dgv_facturas"
        Me.dgv_facturas.RowHeadersVisible = False
        Me.dgv_facturas.Size = New System.Drawing.Size(888, 65)
        Me.dgv_facturas.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtDireccionEntrega)
        Me.GroupBox2.Controls.Add(Me.txt_aprobacion_pedido)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_total_pedido)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_porcentaje)
        Me.GroupBox2.Controls.Add(Me.txt_aprobacion)
        Me.GroupBox2.Controls.Add(Me.txt_fecha_grabo)
        Me.GroupBox2.Controls.Add(Me.txt_fecha)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Controls.Add(Me.txt_lista_precios)
        Me.GroupBox2.Controls.Add(Me.txt_vendedor)
        Me.GroupBox2.Controls.Add(Me.txt_tipo_pedido)
        Me.GroupBox2.Controls.Add(Me.txt_comentario)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(19, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 105)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pedido"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(537, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 38)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Dirección Entrega"
        '
        'txtDireccionEntrega
        '
        Me.txtDireccionEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccionEntrega.Location = New System.Drawing.Point(623, 66)
        Me.txtDireccionEntrega.Multiline = True
        Me.txtDireccionEntrega.Name = "txtDireccionEntrega"
        Me.txtDireccionEntrega.ReadOnly = True
        Me.txtDireccionEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccionEntrega.Size = New System.Drawing.Size(272, 40)
        Me.txtDireccionEntrega.TabIndex = 23
        '
        'txt_aprobacion_pedido
        '
        Me.txt_aprobacion_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion_pedido.Location = New System.Drawing.Point(806, 40)
        Me.txt_aprobacion_pedido.Name = "txt_aprobacion_pedido"
        Me.txt_aprobacion_pedido.ReadOnly = True
        Me.txt_aprobacion_pedido.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion_pedido.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(745, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Aprobacion"
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_pedido.Location = New System.Drawing.Point(448, 40)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(80, 20)
        Me.txt_total_pedido.TabIndex = 19
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(411, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Total Pedido"
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_porcentaje.Location = New System.Drawing.Point(624, 40)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.ReadOnly = True
        Me.txt_porcentaje.Size = New System.Drawing.Size(40, 20)
        Me.txt_porcentaje.TabIndex = 17
        '
        'txt_aprobacion
        '
        Me.txt_aprobacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion.Location = New System.Drawing.Point(806, 19)
        Me.txt_aprobacion.Name = "txt_aprobacion"
        Me.txt_aprobacion.ReadOnly = True
        Me.txt_aprobacion.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion.TabIndex = 16
        '
        'txt_fecha_grabo
        '
        Me.txt_fecha_grabo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_grabo.Location = New System.Drawing.Point(624, 19)
        Me.txt_fecha_grabo.Name = "txt_fecha_grabo"
        Me.txt_fecha_grabo.ReadOnly = True
        Me.txt_fecha_grabo.Size = New System.Drawing.Size(112, 20)
        Me.txt_fecha_grabo.TabIndex = 15
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(448, 19)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(80, 20)
        Me.txt_fecha.TabIndex = 14
        Me.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(296, 19)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.ReadOnly = True
        Me.txt_numero.Size = New System.Drawing.Size(112, 20)
        Me.txt_numero.TabIndex = 13
        '
        'txt_lista_precios
        '
        Me.txt_lista_precios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lista_precios.Location = New System.Drawing.Point(296, 40)
        Me.txt_lista_precios.Name = "txt_lista_precios"
        Me.txt_lista_precios.ReadOnly = True
        Me.txt_lista_precios.Size = New System.Drawing.Size(112, 20)
        Me.txt_lista_precios.TabIndex = 12
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vendedor.Location = New System.Drawing.Point(80, 40)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.ReadOnly = True
        Me.txt_vendedor.Size = New System.Drawing.Size(128, 20)
        Me.txt_vendedor.TabIndex = 11
        '
        'txt_tipo_pedido
        '
        Me.txt_tipo_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_pedido.Location = New System.Drawing.Point(80, 19)
        Me.txt_tipo_pedido.Name = "txt_tipo_pedido"
        Me.txt_tipo_pedido.ReadOnly = True
        Me.txt_tipo_pedido.Size = New System.Drawing.Size(128, 20)
        Me.txt_tipo_pedido.TabIndex = 10
        '
        'txt_comentario
        '
        Me.txt_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentario.Location = New System.Drawing.Point(80, 61)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ReadOnly = True
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(448, 40)
        Me.txt_comentario.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(538, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 16)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "% Facturado"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 23)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Comentario"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(745, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Estado"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(214, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Lista de Precios"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Vendedor"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(536, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Fecha Generado"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(410, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(214, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "tipo de pedido"
        '
        'lbl_controles_asociados
        '
        Me.lbl_controles_asociados.AutoSize = True
        Me.lbl_controles_asociados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_controles_asociados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl_controles_asociados.Location = New System.Drawing.Point(806, 399)
        Me.lbl_controles_asociados.Name = "lbl_controles_asociados"
        Me.lbl_controles_asociados.Size = New System.Drawing.Size(117, 15)
        Me.lbl_controles_asociados.TabIndex = 7
        Me.lbl_controles_asociados.Text = "Controles Asociados ..."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dg_picking)
        Me.GroupBox5.Location = New System.Drawing.Point(19, 246)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(904, 69)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Picking"
        '
        'dg_picking
        '
        Me.dg_picking.CaptionVisible = False
        Me.dg_picking.DataMember = ""
        Me.dg_picking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_picking.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_picking.Location = New System.Drawing.Point(8, 12)
        Me.dg_picking.Name = "dg_picking"
        Me.dg_picking.ReadOnly = True
        Me.dg_picking.Size = New System.Drawing.Size(888, 60)
        Me.dg_picking.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dg_control_transporte)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 321)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(904, 75)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Control de Transporte"
        '
        'dg_control_transporte
        '
        Me.dg_control_transporte.CaptionVisible = False
        Me.dg_control_transporte.DataMember = ""
        Me.dg_control_transporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderFont = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_control_transporte.Location = New System.Drawing.Point(8, 12)
        Me.dg_control_transporte.Name = "dg_control_transporte"
        Me.dg_control_transporte.ReadOnly = True
        Me.dg_control_transporte.Size = New System.Drawing.Size(888, 60)
        Me.dg_control_transporte.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox6.Location = New System.Drawing.Point(23, 412)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(904, 72)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Devoluciones"
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.CaptionVisible = False
        Me.dg_devoluciones.DataMember = ""
        Me.dg_devoluciones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_devoluciones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_devoluciones.Location = New System.Drawing.Point(8, 12)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.ReadOnly = True
        Me.dg_devoluciones.Size = New System.Drawing.Size(888, 55)
        Me.dg_devoluciones.TabIndex = 1
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(99, 5)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresa.TabIndex = 9
        '
        'cmbTipoDocto
        '
        Me.cmbTipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocto.FormattingEnabled = True
        Me.cmbTipoDocto.Location = New System.Drawing.Point(315, 5)
        Me.cmbTipoDocto.Name = "cmbTipoDocto"
        Me.cmbTipoDocto.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoDocto.TabIndex = 9
        '
        'txtNumeroFactura
        '
        Me.txtNumeroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroFactura.Location = New System.Drawing.Point(642, 5)
        Me.txtNumeroFactura.Name = "txtNumeroFactura"
        Me.txtNumeroFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroFactura.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Empresa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Tipo"
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(555, 8)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(44, 13)
        Me.lblAnio.TabIndex = 12
        Me.lblAnio.Text = "Numero"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerar.ImageKey = "Actualizar.png"
        Me.btnGenerar.ImageList = Me.ImageList1
        Me.btnGenerar.Location = New System.Drawing.Point(767, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 56)
        Me.btnGenerar.TabIndex = 13
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Actualizar.png")
        Me.ImageList1.Images.SetKeyName(1, "limpiar2.jpg")
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.White
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.ImageKey = "limpiar2.jpg"
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(842, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 56)
        Me.btnLimpiar.TabIndex = 14
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'nupAnio
        '
        Me.nupAnio.Location = New System.Drawing.Point(602, 4)
        Me.nupAnio.Name = "nupAnio"
        Me.nupAnio.Size = New System.Drawing.Size(39, 20)
        Me.nupAnio.TabIndex = 14
        '
        'gbWalmart
        '
        Me.gbWalmart.Controls.Add(Me.dgWalmart)
        Me.gbWalmart.Location = New System.Drawing.Point(19, 485)
        Me.gbWalmart.Name = "gbWalmart"
        Me.gbWalmart.Size = New System.Drawing.Size(904, 72)
        Me.gbWalmart.TabIndex = 15
        Me.gbWalmart.TabStop = False
        Me.gbWalmart.Text = "Envio a Walmart"
        '
        'dgWalmart
        '
        Me.dgWalmart.CaptionVisible = False
        Me.dgWalmart.DataMember = ""
        Me.dgWalmart.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgWalmart.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgWalmart.Location = New System.Drawing.Point(10, 11)
        Me.dgWalmart.Name = "dgWalmart"
        Me.dgWalmart.ReadOnly = True
        Me.dgWalmart.Size = New System.Drawing.Size(888, 55)
        Me.dgWalmart.TabIndex = 1
        '
        'txtSerieFEL
        '
        Me.txtSerieFEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerieFEL.Location = New System.Drawing.Point(369, 39)
        Me.txtSerieFEL.Name = "txtSerieFEL"
        Me.txtSerieFEL.Size = New System.Drawing.Size(100, 20)
        Me.txtSerieFEL.TabIndex = 10
        '
        'txtNumeroFel
        '
        Me.txtNumeroFel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroFel.Location = New System.Drawing.Point(571, 39)
        Me.txtNumeroFel.Name = "txtNumeroFel"
        Me.txtNumeroFel.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroFel.TabIndex = 10
        '
        'lblSerieFEL
        '
        Me.lblSerieFEL.AutoSize = True
        Me.lblSerieFEL.Location = New System.Drawing.Point(312, 42)
        Me.lblSerieFEL.Name = "lblSerieFEL"
        Me.lblSerieFEL.Size = New System.Drawing.Size(53, 13)
        Me.lblSerieFEL.TabIndex = 16
        Me.lblSerieFEL.Text = "Serie FEL"
        '
        'lblNumeroFEL
        '
        Me.lblNumeroFEL.AutoSize = True
        Me.lblNumeroFEL.Location = New System.Drawing.Point(499, 42)
        Me.lblNumeroFEL.Name = "lblNumeroFEL"
        Me.lblNumeroFEL.Size = New System.Drawing.Size(66, 13)
        Me.lblNumeroFEL.TabIndex = 16
        Me.lblNumeroFEL.Text = "Numero FEL"
        '
        'frmTrackingFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(935, 556)
        Me.Controls.Add(Me.lblNumeroFEL)
        Me.Controls.Add(Me.lblSerieFEL)
        Me.Controls.Add(Me.lbl_controles_asociados)
        Me.Controls.Add(Me.gbWalmart)
        Me.Controls.Add(Me.nupAnio)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.lblAnio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSerieFEL)
        Me.Controls.Add(Me.txtNumeroFel)
        Me.Controls.Add(Me.txtNumeroFactura)
        Me.Controls.Add(Me.cmbTipoDocto)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmTrackingFactura"
        Me.Text = ":: Tracking Por Factura ::"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWalmart.ResumeLayout(False)
        CType(Me.dgWalmart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_facturas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_aprobacion_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txt_aprobacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_grabo As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_lista_precios As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_controles_asociados As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_picking As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_control_transporte As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGrid
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumeroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents nupAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gbWalmart As System.Windows.Forms.GroupBox
    Friend WithEvents dgWalmart As System.Windows.Forms.DataGrid
    Friend WithEvents txtSerieFEL As TextBox
    Friend WithEvents txtNumeroFel As TextBox
    Friend WithEvents lblSerieFEL As Label
    Friend WithEvents lblNumeroFEL As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDireccionEntrega As TextBox
End Class
