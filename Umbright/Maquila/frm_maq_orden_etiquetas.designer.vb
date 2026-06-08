<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_maq_orden_etiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_orden_etiquetas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_stickers = New System.Windows.Forms.TextBox()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.btn_ayuda = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.solicitado_por = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_op_DI = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_op_numero_orden = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_op_cantidad_solicitada = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_op_fecha_etiquetado = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_nuevo_orden_produccion = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar_orden_produccion = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgv_costo_primo = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txt_costo_primo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgv_chequeo = New System.Windows.Forms.DataGridView()
        Me.clbx_chequeo = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.dtp_hora_inicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_tiempo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_hora_final = New System.Windows.Forms.DateTimePicker()
        Me.tb_ordenes_etiquetado = New System.Windows.Forms.TabControl()
        Me.tb_detalle = New System.Windows.Forms.TabPage()
        Me.tb_listado = New System.Windows.Forms.TabPage()
        Me.tbn__mostrar_ordenes = New System.Windows.Forms.Button()
        Me.dgv_listado_ordenes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_costo_primo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_chequeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tb_ordenes_etiquetado.SuspendLayout()
        Me.tb_detalle.SuspendLayout()
        Me.tb_listado.SuspendLayout()
        CType(Me.dgv_listado_ordenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_stickers)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.txt_producto)
        Me.GroupBox2.Controls.Add(Me.btn_ayuda)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.solicitado_por)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txt_op_DI)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_op_numero_orden)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_op_cantidad_solicitada)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtp_op_fecha_etiquetado)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 260)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(12, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Stickers Colocados"
        '
        'txt_stickers
        '
        Me.txt_stickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_stickers.Location = New System.Drawing.Point(118, 132)
        Me.txt_stickers.Name = "txt_stickers"
        Me.txt_stickers.ReadOnly = True
        Me.txt_stickers.Size = New System.Drawing.Size(88, 20)
        Me.txt_stickers.TabIndex = 20
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(118, 79)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(347, 22)
        Me.txt_descripcion.TabIndex = 3
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(118, 52)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(88, 22)
        Me.txt_producto.TabIndex = 1
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(212, 52)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(26, 22)
        Me.btn_ayuda.TabIndex = 2
        Me.btn_ayuda.Text = "..."
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Producto"
        '
        'solicitado_por
        '
        Me.solicitado_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.solicitado_por.Location = New System.Drawing.Point(118, 220)
        Me.solicitado_por.Name = "solicitado_por"
        Me.solicitado_por.ReadOnly = True
        Me.solicitado_por.Size = New System.Drawing.Size(347, 20)
        Me.solicitado_por.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(12, 227)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Solicitado por"
        '
        'txt_op_DI
        '
        Me.txt_op_DI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_DI.Location = New System.Drawing.Point(118, 194)
        Me.txt_op_DI.Name = "txt_op_DI"
        Me.txt_op_DI.Size = New System.Drawing.Size(347, 20)
        Me.txt_op_DI.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "No Orden"
        '
        'txt_op_numero_orden
        '
        Me.txt_op_numero_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_numero_orden.ForeColor = System.Drawing.Color.Brown
        Me.txt_op_numero_orden.Location = New System.Drawing.Point(118, 26)
        Me.txt_op_numero_orden.Name = "txt_op_numero_orden"
        Me.txt_op_numero_orden.ReadOnly = True
        Me.txt_op_numero_orden.Size = New System.Drawing.Size(88, 20)
        Me.txt_op_numero_orden.TabIndex = 0
        Me.txt_op_numero_orden.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cantidad Solicitada"
        '
        'txt_op_cantidad_solicitada
        '
        Me.txt_op_cantidad_solicitada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_cantidad_solicitada.Location = New System.Drawing.Point(118, 104)
        Me.txt_op_cantidad_solicitada.Name = "txt_op_cantidad_solicitada"
        Me.txt_op_cantidad_solicitada.Size = New System.Drawing.Size(88, 20)
        Me.txt_op_cantidad_solicitada.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha Etiquetado"
        '
        'dtp_op_fecha_etiquetado
        '
        Me.dtp_op_fecha_etiquetado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_op_fecha_etiquetado.Location = New System.Drawing.Point(118, 168)
        Me.dtp_op_fecha_etiquetado.Name = "dtp_op_fecha_etiquetado"
        Me.dtp_op_fecha_etiquetado.Size = New System.Drawing.Size(88, 20)
        Me.dtp_op_fecha_etiquetado.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(12, 201)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(18, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "DI"
        '
        'btn_nuevo_orden_produccion
        '
        Me.btn_nuevo_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_orden_produccion.ImageIndex = 3
        Me.btn_nuevo_orden_produccion.ImageList = Me.ImageList1
        Me.btn_nuevo_orden_produccion.Location = New System.Drawing.Point(17, 19)
        Me.btn_nuevo_orden_produccion.Name = "btn_nuevo_orden_produccion"
        Me.btn_nuevo_orden_produccion.Size = New System.Drawing.Size(92, 60)
        Me.btn_nuevo_orden_produccion.TabIndex = 11
        Me.btn_nuevo_orden_produccion.Text = "Nuevo"
        Me.btn_nuevo_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_orden_produccion.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "pack.png")
        Me.ImageList1.Images.SetKeyName(2, "pack2.png")
        Me.ImageList1.Images.SetKeyName(3, "3.png")
        Me.ImageList1.Images.SetKeyName(4, "grafica1.png")
        '
        'btn_guardar_orden_produccion
        '
        Me.btn_guardar_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_orden_produccion.ImageIndex = 0
        Me.btn_guardar_orden_produccion.ImageList = Me.ImageList1
        Me.btn_guardar_orden_produccion.Location = New System.Drawing.Point(17, 85)
        Me.btn_guardar_orden_produccion.Name = "btn_guardar_orden_produccion"
        Me.btn_guardar_orden_produccion.Size = New System.Drawing.Size(92, 56)
        Me.btn_guardar_orden_produccion.TabIndex = 12
        Me.btn_guardar_orden_produccion.Text = "Guardar"
        Me.btn_guardar_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_orden_produccion.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        '
        'dgv_costo_primo
        '
        Me.dgv_costo_primo.AllowUserToAddRows = False
        Me.dgv_costo_primo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "#,##0 "
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_costo_primo.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_costo_primo.Location = New System.Drawing.Point(9, 23)
        Me.dgv_costo_primo.Name = "dgv_costo_primo"
        Me.dgv_costo_primo.RowHeadersWidth = 20
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgv_costo_primo.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_costo_primo.Size = New System.Drawing.Size(333, 101)
        Me.dgv_costo_primo.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.txt_costo_primo)
        Me.GroupBox1.Controls.Add(Me.dgv_costo_primo)
        Me.GroupBox1.Location = New System.Drawing.Point(262, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 211)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Costo Primo"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(6, 140)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(64, 14)
        Me.Label34.TabIndex = 69
        Me.Label34.Text = "Costo Primo"
        '
        'txt_costo_primo
        '
        Me.txt_costo_primo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_costo_primo.Enabled = False
        Me.txt_costo_primo.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_costo_primo.Location = New System.Drawing.Point(9, 157)
        Me.txt_costo_primo.Name = "txt_costo_primo"
        Me.txt_costo_primo.ReadOnly = True
        Me.txt_costo_primo.Size = New System.Drawing.Size(174, 38)
        Me.txt_costo_primo.TabIndex = 72
        Me.txt_costo_primo.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.dgv_chequeo)
        Me.GroupBox4.Controls.Add(Me.clbx_chequeo)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 269)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(245, 342)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Chequeo"
        '
        'dgv_chequeo
        '
        Me.dgv_chequeo.AllowUserToAddRows = False
        Me.dgv_chequeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_chequeo.Location = New System.Drawing.Point(15, 130)
        Me.dgv_chequeo.Name = "dgv_chequeo"
        Me.dgv_chequeo.RowHeadersWidth = 20
        Me.dgv_chequeo.Size = New System.Drawing.Size(217, 200)
        Me.dgv_chequeo.TabIndex = 9
        '
        'clbx_chequeo
        '
        Me.clbx_chequeo.CheckOnClick = True
        Me.clbx_chequeo.FormattingEnabled = True
        Me.clbx_chequeo.Location = New System.Drawing.Point(15, 15)
        Me.clbx_chequeo.Name = "clbx_chequeo"
        Me.clbx_chequeo.Size = New System.Drawing.Size(217, 109)
        Me.clbx_chequeo.TabIndex = 8
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.btn_nuevo_orden_produccion)
        Me.GroupBox5.Controls.Add(Me.btnReporte)
        Me.GroupBox5.Controls.Add(Me.btn_guardar_orden_produccion)
        Me.GroupBox5.Location = New System.Drawing.Point(495, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(127, 257)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReporte.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.ForeColor = System.Drawing.Color.White
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.ImageIndex = 0
        Me.btnReporte.Location = New System.Drawing.Point(17, 147)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(92, 56)
        Me.btnReporte.TabIndex = 12
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'dtp_hora_inicio
        '
        Me.dtp_hora_inicio.CustomFormat = "HH:mm:ss"
        Me.dtp_hora_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hora_inicio.Location = New System.Drawing.Point(56, 33)
        Me.dtp_hora_inicio.Name = "dtp_hora_inicio"
        Me.dtp_hora_inicio.ShowUpDown = True
        Me.dtp_hora_inicio.Size = New System.Drawing.Size(80, 20)
        Me.dtp_hora_inicio.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txt_tiempo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtp_hora_final)
        Me.GroupBox3.Controls.Add(Me.dtp_hora_inicio)
        Me.GroupBox3.Location = New System.Drawing.Point(262, 504)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(319, 85)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Calcular Tiempo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(175, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Tiempo"
        '
        'txt_tiempo
        '
        Me.txt_tiempo.Location = New System.Drawing.Point(178, 59)
        Me.txt_tiempo.Name = "txt_tiempo"
        Me.txt_tiempo.ReadOnly = True
        Me.txt_tiempo.Size = New System.Drawing.Size(93, 20)
        Me.txt_tiempo.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Desde"
        '
        'dtp_hora_final
        '
        Me.dtp_hora_final.CustomFormat = "HH:mm:ss"
        Me.dtp_hora_final.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hora_final.Location = New System.Drawing.Point(56, 59)
        Me.dtp_hora_final.Name = "dtp_hora_final"
        Me.dtp_hora_final.ShowUpDown = True
        Me.dtp_hora_final.Size = New System.Drawing.Size(80, 20)
        Me.dtp_hora_final.TabIndex = 16
        '
        'tb_ordenes_etiquetado
        '
        Me.tb_ordenes_etiquetado.Controls.Add(Me.tb_detalle)
        Me.tb_ordenes_etiquetado.Controls.Add(Me.tb_listado)
        Me.tb_ordenes_etiquetado.Location = New System.Drawing.Point(0, 2)
        Me.tb_ordenes_etiquetado.Name = "tb_ordenes_etiquetado"
        Me.tb_ordenes_etiquetado.SelectedIndex = 0
        Me.tb_ordenes_etiquetado.Size = New System.Drawing.Size(649, 644)
        Me.tb_ordenes_etiquetado.TabIndex = 20
        '
        'tb_detalle
        '
        Me.tb_detalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_detalle.Controls.Add(Me.GroupBox2)
        Me.tb_detalle.Controls.Add(Me.GroupBox3)
        Me.tb_detalle.Controls.Add(Me.GroupBox5)
        Me.tb_detalle.Controls.Add(Me.GroupBox1)
        Me.tb_detalle.Controls.Add(Me.GroupBox4)
        Me.tb_detalle.Location = New System.Drawing.Point(4, 22)
        Me.tb_detalle.Name = "tb_detalle"
        Me.tb_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_detalle.Size = New System.Drawing.Size(641, 618)
        Me.tb_detalle.TabIndex = 0
        Me.tb_detalle.Text = "Detalle Etiquetado"
        '
        'tb_listado
        '
        Me.tb_listado.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_listado.Controls.Add(Me.tbn__mostrar_ordenes)
        Me.tb_listado.Controls.Add(Me.dgv_listado_ordenes)
        Me.tb_listado.Location = New System.Drawing.Point(4, 22)
        Me.tb_listado.Name = "tb_listado"
        Me.tb_listado.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_listado.Size = New System.Drawing.Size(641, 618)
        Me.tb_listado.TabIndex = 1
        Me.tb_listado.Text = "Listado Ordenes"
        '
        'tbn__mostrar_ordenes
        '
        Me.tbn__mostrar_ordenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.tbn__mostrar_ordenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.tbn__mostrar_ordenes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbn__mostrar_ordenes.ForeColor = System.Drawing.Color.White
        Me.tbn__mostrar_ordenes.Location = New System.Drawing.Point(477, 3)
        Me.tbn__mostrar_ordenes.Name = "tbn__mostrar_ordenes"
        Me.tbn__mostrar_ordenes.Size = New System.Drawing.Size(141, 32)
        Me.tbn__mostrar_ordenes.TabIndex = 19
        Me.tbn__mostrar_ordenes.Text = "Mostrar Ordenes"
        Me.tbn__mostrar_ordenes.UseVisualStyleBackColor = False
        '
        'dgv_listado_ordenes
        '
        Me.dgv_listado_ordenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado_ordenes.Location = New System.Drawing.Point(6, 44)
        Me.dgv_listado_ordenes.Name = "dgv_listado_ordenes"
        Me.dgv_listado_ordenes.ReadOnly = True
        Me.dgv_listado_ordenes.RowHeadersWidth = 20
        Me.dgv_listado_ordenes.Size = New System.Drawing.Size(629, 567)
        Me.dgv_listado_ordenes.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'frm_maq_orden_etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(651, 647)
        Me.Controls.Add(Me.tb_ordenes_etiquetado)
        Me.Name = "frm_maq_orden_etiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Etiquetas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_costo_primo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgv_chequeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tb_ordenes_etiquetado.ResumeLayout(False)
        Me.tb_detalle.ResumeLayout(False)
        Me.tb_listado.ResumeLayout(False)
        CType(Me.dgv_listado_ordenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents solicitado_por As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_op_DI As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_op_numero_orden As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_op_cantidad_solicitada As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_op_fecha_etiquetado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents dgv_costo_primo As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txt_costo_primo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clbx_chequeo As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_chequeo As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_hora_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_tiempo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_hora_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_ordenes_etiquetado As System.Windows.Forms.TabControl
    Friend WithEvents tb_detalle As System.Windows.Forms.TabPage
    Friend WithEvents tb_listado As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_stickers As System.Windows.Forms.TextBox
    Friend WithEvents dgv_listado_ordenes As System.Windows.Forms.DataGridView
    Friend WithEvents tbn__mostrar_ordenes As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
End Class
