<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Actualizacion_Codigos
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
        Me.tb_Producto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.lb_Descripcion = New System.Windows.Forms.Label()
        Me.lb_Vence = New System.Windows.Forms.Label()
        Me.lb_Registro = New System.Windows.Forms.Label()
        Me.lb_Uxc = New System.Windows.Forms.Label()
        Me.lb_Un = New System.Windows.Forms.Label()
        Me.lb_Procedencia = New System.Windows.Forms.Label()
        Me.lb_Marca = New System.Windows.Forms.Label()
        Me.lb_Proveedor = New System.Windows.Forms.Label()
        Me.lb_Familia = New System.Windows.Forms.Label()
        Me.lb_TipoProd = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv_Existencias = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_Memos = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_Replicar = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.Consignaciones = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgv_Consignaciones = New System.Windows.Forms.DataGridView()
        Me.gb_Replicar = New System.Windows.Forms.GroupBox()
        Me.btn_Generar = New System.Windows.Forms.Button()
        Me.nud_Uxc = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_CodigoNuevo = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_Precios = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgv_Presupuestos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Existencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Memos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Consignaciones.SuspendLayout()
        CType(Me.dgv_Consignaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Replicar.SuspendLayout()
        CType(Me.nud_Uxc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_Precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgv_Presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tb_Producto
        '
        Me.tb_Producto.Location = New System.Drawing.Point(69, 19)
        Me.tb_Producto.Name = "tb_Producto"
        Me.tb_Producto.Size = New System.Drawing.Size(100, 20)
        Me.tb_Producto.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Buscar)
        Me.GroupBox1.Controls.Add(Me.lb_Descripcion)
        Me.GroupBox1.Controls.Add(Me.lb_Vence)
        Me.GroupBox1.Controls.Add(Me.lb_Registro)
        Me.GroupBox1.Controls.Add(Me.lb_Uxc)
        Me.GroupBox1.Controls.Add(Me.lb_Un)
        Me.GroupBox1.Controls.Add(Me.lb_Procedencia)
        Me.GroupBox1.Controls.Add(Me.lb_Marca)
        Me.GroupBox1.Controls.Add(Me.lb_Proveedor)
        Me.GroupBox1.Controls.Add(Me.lb_Familia)
        Me.GroupBox1.Controls.Add(Me.lb_TipoProd)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_Producto)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 154)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(171, 18)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(20, 21)
        Me.btn_Buscar.TabIndex = 7
        Me.btn_Buscar.Text = "?"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'lb_Descripcion
        '
        Me.lb_Descripcion.AutoSize = True
        Me.lb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Descripcion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Descripcion.Location = New System.Drawing.Point(259, 23)
        Me.lb_Descripcion.Name = "lb_Descripcion"
        Me.lb_Descripcion.Size = New System.Drawing.Size(74, 13)
        Me.lb_Descripcion.TabIndex = 2
        Me.lb_Descripcion.Text = "Descripción"
        '
        'lb_Vence
        '
        Me.lb_Vence.AutoSize = True
        Me.lb_Vence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Vence.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Vence.Location = New System.Drawing.Point(527, 122)
        Me.lb_Vence.Name = "lb_Vence"
        Me.lb_Vence.Size = New System.Drawing.Size(43, 13)
        Me.lb_Vence.TabIndex = 2
        Me.lb_Vence.Text = "Vence"
        '
        'lb_Registro
        '
        Me.lb_Registro.AutoSize = True
        Me.lb_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Registro.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Registro.Location = New System.Drawing.Point(401, 122)
        Me.lb_Registro.Name = "lb_Registro"
        Me.lb_Registro.Size = New System.Drawing.Size(54, 13)
        Me.lb_Registro.TabIndex = 2
        Me.lb_Registro.Text = "Registro"
        '
        'lb_Uxc
        '
        Me.lb_Uxc.AutoSize = True
        Me.lb_Uxc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Uxc.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Uxc.Location = New System.Drawing.Point(401, 99)
        Me.lb_Uxc.Name = "lb_Uxc"
        Me.lb_Uxc.Size = New System.Drawing.Size(38, 13)
        Me.lb_Uxc.TabIndex = 2
        Me.lb_Uxc.Text = "U x C"
        '
        'lb_Un
        '
        Me.lb_Un.AutoSize = True
        Me.lb_Un.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Un.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Un.Location = New System.Drawing.Point(401, 76)
        Me.lb_Un.Name = "lb_Un"
        Me.lb_Un.Size = New System.Drawing.Size(118, 13)
        Me.lb_Un.TabIndex = 13
        Me.lb_Un.Text = "Unidad De Negocio"
        '
        'lb_Procedencia
        '
        Me.lb_Procedencia.AutoSize = True
        Me.lb_Procedencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Procedencia.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Procedencia.Location = New System.Drawing.Point(401, 54)
        Me.lb_Procedencia.Name = "lb_Procedencia"
        Me.lb_Procedencia.Size = New System.Drawing.Size(78, 13)
        Me.lb_Procedencia.TabIndex = 12
        Me.lb_Procedencia.Text = "Procedencia"
        '
        'lb_Marca
        '
        Me.lb_Marca.AutoSize = True
        Me.lb_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Marca.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Marca.Location = New System.Drawing.Point(103, 122)
        Me.lb_Marca.Name = "lb_Marca"
        Me.lb_Marca.Size = New System.Drawing.Size(42, 13)
        Me.lb_Marca.TabIndex = 2
        Me.lb_Marca.Text = "Marca"
        '
        'lb_Proveedor
        '
        Me.lb_Proveedor.AutoSize = True
        Me.lb_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Proveedor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Proveedor.Location = New System.Drawing.Point(102, 99)
        Me.lb_Proveedor.Name = "lb_Proveedor"
        Me.lb_Proveedor.Size = New System.Drawing.Size(65, 13)
        Me.lb_Proveedor.TabIndex = 2
        Me.lb_Proveedor.Text = "Proveedor"
        '
        'lb_Familia
        '
        Me.lb_Familia.AutoSize = True
        Me.lb_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Familia.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Familia.Location = New System.Drawing.Point(102, 76)
        Me.lb_Familia.Name = "lb_Familia"
        Me.lb_Familia.Size = New System.Drawing.Size(46, 13)
        Me.lb_Familia.TabIndex = 2
        Me.lb_Familia.Text = "Familia"
        '
        'lb_TipoProd
        '
        Me.lb_TipoProd.AutoSize = True
        Me.lb_TipoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_TipoProd.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_TipoProd.Location = New System.Drawing.Point(102, 54)
        Me.lb_TipoProd.Name = "lb_TipoProd"
        Me.lb_TipoProd.Size = New System.Drawing.Size(87, 13)
        Me.lb_TipoProd.TabIndex = 2
        Me.lb_TipoProd.Text = "Tipo Producto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(483, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Vence:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(286, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Registro Sanitario:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(280, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Unidades Por Caja:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(274, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Unidad De Negocio:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Procedencia:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Marca:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Proveedor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Familia:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgv_Existencias)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 154)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Existencias"
        '
        'dgv_Existencias
        '
        Me.dgv_Existencias.AllowUserToAddRows = False
        Me.dgv_Existencias.AllowUserToDeleteRows = False
        Me.dgv_Existencias.AllowUserToOrderColumns = True
        Me.dgv_Existencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Existencias.Location = New System.Drawing.Point(10, 19)
        Me.dgv_Existencias.Name = "dgv_Existencias"
        Me.dgv_Existencias.ReadOnly = True
        Me.dgv_Existencias.Size = New System.Drawing.Size(273, 129)
        Me.dgv_Existencias.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_Memos)
        Me.GroupBox3.Location = New System.Drawing.Point(310, 167)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(417, 154)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Memos"
        '
        'dgv_Memos
        '
        Me.dgv_Memos.AllowUserToAddRows = False
        Me.dgv_Memos.AllowUserToDeleteRows = False
        Me.dgv_Memos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Memos.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Memos.Name = "dgv_Memos"
        Me.dgv_Memos.ReadOnly = True
        Me.dgv_Memos.Size = New System.Drawing.Size(404, 129)
        Me.dgv_Memos.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_Replicar)
        Me.GroupBox4.Controls.Add(Me.btn_Nuevo)
        Me.GroupBox4.Location = New System.Drawing.Point(622, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(105, 143)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'btn_Replicar
        '
        Me.btn_Replicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Replicar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Replicar.Location = New System.Drawing.Point(17, 60)
        Me.btn_Replicar.Name = "btn_Replicar"
        Me.btn_Replicar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Replicar.TabIndex = 1
        Me.btn_Replicar.Text = "Copiar"
        Me.btn_Replicar.UseVisualStyleBackColor = False
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Nuevo.Location = New System.Drawing.Point(17, 19)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.Text = "Limpiar"
        Me.btn_Nuevo.UseVisualStyleBackColor = False
        '
        'Consignaciones
        '
        Me.Consignaciones.Controls.Add(Me.GroupBox5)
        Me.Consignaciones.Controls.Add(Me.dgv_Consignaciones)
        Me.Consignaciones.Location = New System.Drawing.Point(13, 322)
        Me.Consignaciones.Name = "Consignaciones"
        Me.Consignaciones.Size = New System.Drawing.Size(714, 100)
        Me.Consignaciones.TabIndex = 5
        Me.Consignaciones.TabStop = False
        Me.Consignaciones.Text = "Consignaciones"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(43, 106)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(631, 58)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'dgv_Consignaciones
        '
        Me.dgv_Consignaciones.AllowUserToAddRows = False
        Me.dgv_Consignaciones.AllowUserToDeleteRows = False
        Me.dgv_Consignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Consignaciones.Location = New System.Drawing.Point(10, 18)
        Me.dgv_Consignaciones.Name = "dgv_Consignaciones"
        Me.dgv_Consignaciones.ReadOnly = True
        Me.dgv_Consignaciones.Size = New System.Drawing.Size(697, 76)
        Me.dgv_Consignaciones.TabIndex = 0
        '
        'gb_Replicar
        '
        Me.gb_Replicar.Controls.Add(Me.btn_Generar)
        Me.gb_Replicar.Controls.Add(Me.nud_Uxc)
        Me.gb_Replicar.Controls.Add(Me.Label13)
        Me.gb_Replicar.Controls.Add(Me.Label12)
        Me.gb_Replicar.Controls.Add(Me.tb_CodigoNuevo)
        Me.gb_Replicar.Location = New System.Drawing.Point(112, 557)
        Me.gb_Replicar.Name = "gb_Replicar"
        Me.gb_Replicar.Size = New System.Drawing.Size(482, 64)
        Me.gb_Replicar.TabIndex = 6
        Me.gb_Replicar.TabStop = False
        Me.gb_Replicar.Text = "Creación"
        '
        'btn_Generar
        '
        Me.btn_Generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Generar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Generar.Location = New System.Drawing.Point(385, 24)
        Me.btn_Generar.Name = "btn_Generar"
        Me.btn_Generar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Generar.TabIndex = 4
        Me.btn_Generar.Text = "Generar"
        Me.btn_Generar.UseVisualStyleBackColor = False
        '
        'nud_Uxc
        '
        Me.nud_Uxc.Location = New System.Drawing.Point(314, 25)
        Me.nud_Uxc.Name = "nud_Uxc"
        Me.nud_Uxc.Size = New System.Drawing.Size(41, 20)
        Me.nud_Uxc.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(210, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Unidades Por Caja:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Nuevo Código:"
        '
        'tb_CodigoNuevo
        '
        Me.tb_CodigoNuevo.Location = New System.Drawing.Point(94, 25)
        Me.tb_CodigoNuevo.Name = "tb_CodigoNuevo"
        Me.tb_CodigoNuevo.Size = New System.Drawing.Size(100, 20)
        Me.tb_CodigoNuevo.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgv_Precios)
        Me.GroupBox6.Location = New System.Drawing.Point(13, 428)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(333, 123)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Precios"
        '
        'dgv_Precios
        '
        Me.dgv_Precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Precios.Location = New System.Drawing.Point(10, 17)
        Me.dgv_Precios.Name = "dgv_Precios"
        Me.dgv_Precios.Size = New System.Drawing.Size(317, 100)
        Me.dgv_Precios.TabIndex = 8
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.dgv_Presupuestos)
        Me.GroupBox7.Location = New System.Drawing.Point(352, 428)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(371, 123)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Presupuestos"
        '
        'dgv_Presupuestos
        '
        Me.dgv_Presupuestos.AllowUserToAddRows = False
        Me.dgv_Presupuestos.AllowUserToDeleteRows = False
        Me.dgv_Presupuestos.AllowUserToOrderColumns = True
        Me.dgv_Presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Presupuestos.Location = New System.Drawing.Point(6, 17)
        Me.dgv_Presupuestos.Name = "dgv_Presupuestos"
        Me.dgv_Presupuestos.ReadOnly = True
        Me.dgv_Presupuestos.Size = New System.Drawing.Size(356, 100)
        Me.dgv_Presupuestos.TabIndex = 0
        '
        'Frm_Actualizacion_Codigos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(735, 627)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gb_Replicar)
        Me.Controls.Add(Me.Consignaciones)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Actualizacion_Codigos"
        Me.Text = "Actualización Códigos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_Existencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_Memos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Consignaciones.ResumeLayout(False)
        CType(Me.dgv_Consignaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Replicar.ResumeLayout(False)
        Me.gb_Replicar.PerformLayout()
        CType(Me.nud_Uxc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_Precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgv_Presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tb_Producto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_Vence As System.Windows.Forms.Label
    Friend WithEvents lb_Registro As System.Windows.Forms.Label
    Friend WithEvents lb_Uxc As System.Windows.Forms.Label
    Friend WithEvents lb_Un As System.Windows.Forms.Label
    Friend WithEvents lb_Procedencia As System.Windows.Forms.Label
    Friend WithEvents lb_Marca As System.Windows.Forms.Label
    Friend WithEvents lb_Proveedor As System.Windows.Forms.Label
    Friend WithEvents lb_Familia As System.Windows.Forms.Label
    Friend WithEvents lb_TipoProd As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents dgv_Existencias As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_Memos As System.Windows.Forms.DataGridView
    Friend WithEvents Consignaciones As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Consignaciones As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Replicar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gb_Replicar As System.Windows.Forms.GroupBox
    Friend WithEvents nud_Uxc As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_CodigoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents btn_Generar As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Precios As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Presupuestos As System.Windows.Forms.DataGridView
End Class
