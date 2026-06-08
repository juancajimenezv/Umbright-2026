<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_MinMax_Solicitud_Vinoteca
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MinMax_Solicitud_Vinoteca))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMostrarTodo = New System.Windows.Forms.CheckBox()
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox()
        Me.cmb_1 = New System.Windows.Forms.ComboBox()
        Me.txt_filtro1 = New System.Windows.Forms.TextBox()
        Me.chkDesmarcar = New System.Windows.Forms.CheckBox()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Bodega = New System.Windows.Forms.ComboBox()
        Me.lb_Aleatorio = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_cliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_usuario = New System.Windows.Forms.TextBox()
        Me.tb_bodega = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_tienda = New System.Windows.Forms.TextBox()
        Me.lb_correlativo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_crear = New System.Windows.Forms.Button()
        Me.lb_total = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lb_procesar = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_comentario = New System.Windows.Forms.TextBox()
        Me.Comentario = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.lbMaxímo = New System.Windows.Forms.Label()
        Me.lbminimo = New System.Windows.Forms.Label()
        Me.txt_maximo = New System.Windows.Forms.TextBox()
        Me.txt_minimo = New System.Windows.Forms.TextBox()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.cmb_Proveedor = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Comentario.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkMostrarTodo)
        Me.GroupBox1.Controls.Add(Me.cmb_valor1)
        Me.GroupBox1.Controls.Add(Me.cmb_1)
        Me.GroupBox1.Controls.Add(Me.txt_filtro1)
        Me.GroupBox1.Controls.Add(Me.chkDesmarcar)
        Me.GroupBox1.Controls.Add(Me.dgv_detalle)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(12, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 407)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'chkMostrarTodo
        '
        Me.chkMostrarTodo.AutoSize = True
        Me.chkMostrarTodo.Location = New System.Drawing.Point(818, 21)
        Me.chkMostrarTodo.Name = "chkMostrarTodo"
        Me.chkMostrarTodo.Size = New System.Drawing.Size(89, 17)
        Me.chkMostrarTodo.TabIndex = 46
        Me.chkMostrarTodo.Text = "Mostrar Todo"
        Me.chkMostrarTodo.UseVisualStyleBackColor = True
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(13, 17)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor1.Sorted = True
        Me.cmb_valor1.TabIndex = 43
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(123, 17)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(56, 21)
        Me.cmb_1.TabIndex = 44
        '
        'txt_filtro1
        '
        Me.txt_filtro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_filtro1.Location = New System.Drawing.Point(185, 19)
        Me.txt_filtro1.Name = "txt_filtro1"
        Me.txt_filtro1.Size = New System.Drawing.Size(626, 20)
        Me.txt_filtro1.TabIndex = 45
        '
        'chkDesmarcar
        '
        Me.chkDesmarcar.AutoSize = True
        Me.chkDesmarcar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDesmarcar.Location = New System.Drawing.Point(13, 42)
        Me.chkDesmarcar.Name = "chkDesmarcar"
        Me.chkDesmarcar.Size = New System.Drawing.Size(116, 18)
        Me.chkDesmarcar.TabIndex = 47
        Me.chkDesmarcar.Text = "Desmarcar Todo"
        Me.chkDesmarcar.UseVisualStyleBackColor = True
        Me.chkDesmarcar.Visible = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.Location = New System.Drawing.Point(6, 61)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(1244, 339)
        Me.dgv_detalle.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cb_Bodega)
        Me.GroupBox2.Controls.Add(Me.lb_Aleatorio)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.tb_cliente)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.dtp_fecha)
        Me.GroupBox2.Controls.Add(Me.btn_generar)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tb_usuario)
        Me.GroupBox2.Controls.Add(Me.tb_bodega)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tb_tienda)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 110)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Encabezado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Bodega Origen:"
        '
        'cb_Bodega
        '
        Me.cb_Bodega.FormattingEnabled = True
        Me.cb_Bodega.Location = New System.Drawing.Point(6, 36)
        Me.cb_Bodega.Name = "cb_Bodega"
        Me.cb_Bodega.Size = New System.Drawing.Size(144, 21)
        Me.cb_Bodega.TabIndex = 0
        '
        'lb_Aleatorio
        '
        Me.lb_Aleatorio.AutoSize = True
        Me.lb_Aleatorio.Location = New System.Drawing.Point(394, 12)
        Me.lb_Aleatorio.Name = "lb_Aleatorio"
        Me.lb_Aleatorio.Size = New System.Drawing.Size(28, 13)
        Me.lb_Aleatorio.TabIndex = 18
        Me.lb_Aleatorio.Text = "###"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(162, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cliente:"
        '
        'tb_cliente
        '
        Me.tb_cliente.Enabled = False
        Me.tb_cliente.Location = New System.Drawing.Point(207, 77)
        Me.tb_cliente.Name = "tb_cliente"
        Me.tb_cliente.Size = New System.Drawing.Size(156, 20)
        Me.tb_cliente.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Fecha"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Enabled = False
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(6, 77)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(82, 20)
        Me.dtp_fecha.TabIndex = 12
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_generar.Location = New System.Drawing.Point(369, 30)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(89, 62)
        Me.btn_generar.TabIndex = 1
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Usuario:"
        '
        'tb_usuario
        '
        Me.tb_usuario.Enabled = False
        Me.tb_usuario.Location = New System.Drawing.Point(207, 56)
        Me.tb_usuario.Name = "tb_usuario"
        Me.tb_usuario.Size = New System.Drawing.Size(156, 20)
        Me.tb_usuario.TabIndex = 17
        '
        'tb_bodega
        '
        Me.tb_bodega.Enabled = False
        Me.tb_bodega.Location = New System.Drawing.Point(207, 35)
        Me.tb_bodega.Name = "tb_bodega"
        Me.tb_bodega.Size = New System.Drawing.Size(156, 20)
        Me.tb_bodega.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Bodega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tienda:"
        '
        'tb_tienda
        '
        Me.tb_tienda.Enabled = False
        Me.tb_tienda.Location = New System.Drawing.Point(207, 15)
        Me.tb_tienda.Name = "tb_tienda"
        Me.tb_tienda.Size = New System.Drawing.Size(156, 20)
        Me.tb_tienda.TabIndex = 15
        '
        'lb_correlativo
        '
        Me.lb_correlativo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_correlativo.AutoSize = True
        Me.lb_correlativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_correlativo.ForeColor = System.Drawing.Color.Red
        Me.lb_correlativo.Location = New System.Drawing.Point(201, 44)
        Me.lb_correlativo.Name = "lb_correlativo"
        Me.lb_correlativo.Size = New System.Drawing.Size(88, 16)
        Me.lb_correlativo.TabIndex = 11
        Me.lb_correlativo.Text = "0000000000"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(129, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(214, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SALIDA POR TRASLADO No.:"
        '
        'btn_crear
        '
        Me.btn_crear.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_crear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_crear.Location = New System.Drawing.Point(11, 28)
        Me.btn_crear.Name = "btn_crear"
        Me.btn_crear.Size = New System.Drawing.Size(105, 62)
        Me.btn_crear.TabIndex = 9
        Me.btn_crear.Text = "Crear Solicitud"
        Me.btn_crear.UseVisualStyleBackColor = False
        '
        'lb_total
        '
        Me.lb_total.AutoSize = True
        Me.lb_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total.Location = New System.Drawing.Point(284, 64)
        Me.lb_total.Name = "lb_total"
        Me.lb_total.Size = New System.Drawing.Size(36, 16)
        Me.lb_total.TabIndex = 8
        Me.lb_total.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(130, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Unidades Sugeridas:"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 613)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1274, 22)
        Me.StatusBar1.TabIndex = 5
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 419
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 419
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel3.Name = "StatusBarPanel3"
        Me.StatusBarPanel3.Width = 419
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lb_procesar)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.btn_crear)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.lb_correlativo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.lb_total)
        Me.GroupBox3.Location = New System.Drawing.Point(746, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(373, 110)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Traslado"
        '
        'lb_procesar
        '
        Me.lb_procesar.AutoSize = True
        Me.lb_procesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_procesar.Location = New System.Drawing.Point(285, 84)
        Me.lb_procesar.Name = "lb_procesar"
        Me.lb_procesar.Size = New System.Drawing.Size(36, 16)
        Me.lb_procesar.TabIndex = 13
        Me.lb_procesar.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(126, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Unidades a Procesar:"
        '
        'tb_comentario
        '
        Me.tb_comentario.Location = New System.Drawing.Point(6, 17)
        Me.tb_comentario.Multiline = True
        Me.tb_comentario.Name = "tb_comentario"
        Me.tb_comentario.Size = New System.Drawing.Size(248, 82)
        Me.tb_comentario.TabIndex = 15
        '
        'Comentario
        '
        Me.Comentario.Controls.Add(Me.tb_comentario)
        Me.Comentario.Location = New System.Drawing.Point(481, 16)
        Me.Comentario.Name = "Comentario"
        Me.Comentario.Size = New System.Drawing.Size(260, 110)
        Me.Comentario.TabIndex = 13
        Me.Comentario.TabStop = False
        Me.Comentario.Text = "Comentario"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(1137, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(52, 20)
        Me.TextBox1.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1137, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Sugerido > Existencia CD"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.RoyalBlue
        Me.TextBox2.Location = New System.Drawing.Point(1137, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(52, 20)
        Me.TextBox2.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1134, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Sin Minimo y Maximo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_agregar)
        Me.GroupBox4.Controls.Add(Me.lbMaxímo)
        Me.GroupBox4.Controls.Add(Me.lbminimo)
        Me.GroupBox4.Controls.Add(Me.txt_maximo)
        Me.GroupBox4.Controls.Add(Me.txt_minimo)
        Me.GroupBox4.Controls.Add(Me.txt_descripcion)
        Me.GroupBox4.Controls.Add(Me.lb_producto)
        Me.GroupBox4.Controls.Add(Me.txt_producto)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(975, 63)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_agregar.Location = New System.Drawing.Point(867, 1)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(89, 47)
        Me.btn_agregar.TabIndex = 5
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'lbMaxímo
        '
        Me.lbMaxímo.AutoSize = True
        Me.lbMaxímo.Location = New System.Drawing.Point(721, 16)
        Me.lbMaxímo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbMaxímo.Name = "lbMaxímo"
        Me.lbMaxímo.Size = New System.Drawing.Size(45, 13)
        Me.lbMaxímo.TabIndex = 8
        Me.lbMaxímo.Text = "Maxímo"
        '
        'lbminimo
        '
        Me.lbminimo.AutoSize = True
        Me.lbminimo.Location = New System.Drawing.Point(577, 16)
        Me.lbminimo.Name = "lbminimo"
        Me.lbminimo.Size = New System.Drawing.Size(45, 13)
        Me.lbminimo.TabIndex = 7
        Me.lbminimo.Text = "Minímo:"
        '
        'txt_maximo
        '
        Me.txt_maximo.Location = New System.Drawing.Point(771, 13)
        Me.txt_maximo.Name = "txt_maximo"
        Me.txt_maximo.Size = New System.Drawing.Size(81, 20)
        Me.txt_maximo.TabIndex = 4
        Me.txt_maximo.Text = "0"
        '
        'txt_minimo
        '
        Me.txt_minimo.Location = New System.Drawing.Point(625, 15)
        Me.txt_minimo.Name = "txt_minimo"
        Me.txt_minimo.Size = New System.Drawing.Size(81, 20)
        Me.txt_minimo.TabIndex = 3
        Me.txt_minimo.Text = "0"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Enabled = False
        Me.txt_descripcion.Location = New System.Drawing.Point(154, 15)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(395, 20)
        Me.txt_descripcion.TabIndex = 10
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Location = New System.Drawing.Point(12, 17)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(53, 13)
        Me.lb_producto.TabIndex = 3
        Me.lb_producto.Text = "Producto:"
        '
        'txt_producto
        '
        Me.txt_producto.Location = New System.Drawing.Point(69, 15)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(81, 20)
        Me.txt_producto.TabIndex = 2
        '
        'cmb_Proveedor
        '
        Me.cmb_Proveedor.FormattingEnabled = True
        Me.cmb_Proveedor.Location = New System.Drawing.Point(1045, 173)
        Me.cmb_Proveedor.Name = "cmb_Proveedor"
        Me.cmb_Proveedor.Size = New System.Drawing.Size(199, 21)
        Me.cmb_Proveedor.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1041, 152)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 16)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Buscar Por Marca:"
        '
        'frm_MinMax_Solicitud_Vinoteca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1274, 635)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmb_Proveedor)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Comentario)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_MinMax_Solicitud_Vinoteca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minimos y Maximos Solicitud de Traslado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Comentario.ResumeLayout(False)
        Me.Comentario.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_detalle As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_generar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_usuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_bodega As TextBox
    Friend WithEvents tb_tienda As TextBox
    Friend WithEvents StatusBar1 As StatusBar
    Friend WithEvents StatusBarPanel1 As StatusBarPanel
    Friend WithEvents StatusBarPanel2 As StatusBarPanel
    Friend WithEvents StatusBarPanel3 As StatusBarPanel
    Friend WithEvents lb_total As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_crear As Button
    Friend WithEvents lb_correlativo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents tb_cliente As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tb_comentario As TextBox
    Friend WithEvents Comentario As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lb_procesar As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lb_Aleatorio As Label
    Friend WithEvents cb_Bodega As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lb_producto As Label
    Friend WithEvents txt_producto As TextBox
    Friend WithEvents btn_agregar As Button
    Friend WithEvents lbMaxímo As Label
    Friend WithEvents lbminimo As Label
    Friend WithEvents txt_maximo As TextBox
    Friend WithEvents txt_minimo As TextBox
    Friend WithEvents txt_descripcion As TextBox
    Friend WithEvents cmb_Proveedor As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkMostrarTodo As CheckBox
    Friend WithEvents cmb_valor1 As ComboBox
    Friend WithEvents cmb_1 As ComboBox
    Friend WithEvents txt_filtro1 As TextBox
    Friend WithEvents chkDesmarcar As CheckBox
End Class
