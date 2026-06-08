<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_control_vacaciones
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_solicitud_vacaciones = New System.Windows.Forms.TabPage()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_dias_solicitados = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_periodo_dias = New System.Windows.Forms.DataGridView()
        Me.Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dias_disponibles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_dias_disponibles = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtp_fin_vacaciones = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_Inicio_Vacaciones = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_empresa = New System.Windows.Forms.TextBox()
        Me.lbl_fec_final = New System.Windows.Forms.Label()
        Me.txt_fecha_final = New System.Windows.Forms.TextBox()
        Me.txt_fecha_ingreso = New System.Windows.Forms.TextBox()
        Me.Lbl_estado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_puesto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_departamento = New System.Windows.Forms.TextBox()
        Me.txt_ficha = New System.Windows.Forms.TextBox()
        Me.btn_ayuda = New System.Windows.Forms.Button()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_historial_vacaciones = New System.Windows.Forms.TabPage()
        Me.lbl_historial_estado = New System.Windows.Forms.Label()
        Me.txt_historial_empresa = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_historial_eliminar = New System.Windows.Forms.Button()
        Me.txt_historial_ficha = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgv_historial = New System.Windows.Forms.DataGridView()
        Me.btn_historial_buscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_historial_nombre = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_empleado = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_empre = New System.Windows.Forms.TextBox()
        Me.txt_fi = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tb_solicitud_vacaciones.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_periodo_dias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tb_historial_vacaciones.SuspendLayout()
        CType(Me.dgv_historial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tb_solicitud_vacaciones)
        Me.TabControl1.Controls.Add(Me.tb_historial_vacaciones)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(667, 481)
        Me.TabControl1.TabIndex = 0
        '
        'tb_solicitud_vacaciones
        '
        Me.tb_solicitud_vacaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_solicitud_vacaciones.Controls.Add(Me.btn_guardar)
        Me.tb_solicitud_vacaciones.Controls.Add(Me.GroupBox2)
        Me.tb_solicitud_vacaciones.Controls.Add(Me.GroupBox1)
        Me.tb_solicitud_vacaciones.Location = New System.Drawing.Point(4, 22)
        Me.tb_solicitud_vacaciones.Name = "tb_solicitud_vacaciones"
        Me.tb_solicitud_vacaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_solicitud_vacaciones.Size = New System.Drawing.Size(659, 455)
        Me.tb_solicitud_vacaciones.TabIndex = 0
        Me.tb_solicitud_vacaciones.Text = "Solicitud de Vacaciones"
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 3
        Me.btn_guardar.Location = New System.Drawing.Point(513, 138)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(76, 72)
        Me.btn_guardar.TabIndex = 6
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_dias_solicitados)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dgv_periodo_dias)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_dias_disponibles)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.dtp_fin_vacaciones)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtp_Inicio_Vacaciones)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(585, 220)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txt_dias_solicitados
        '
        Me.txt_dias_solicitados.Location = New System.Drawing.Point(436, 104)
        Me.txt_dias_solicitados.Name = "txt_dias_solicitados"
        Me.txt_dias_solicitados.Size = New System.Drawing.Size(82, 20)
        Me.txt_dias_solicitados.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(306, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Dias Solicitados"
        '
        'dgv_periodo_dias
        '
        Me.dgv_periodo_dias.AllowUserToAddRows = False
        Me.dgv_periodo_dias.AllowUserToDeleteRows = False
        Me.dgv_periodo_dias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_periodo_dias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Periodo, Me.dias_disponibles})
        Me.dgv_periodo_dias.Location = New System.Drawing.Point(12, 32)
        Me.dgv_periodo_dias.Name = "dgv_periodo_dias"
        Me.dgv_periodo_dias.RowHeadersVisible = False
        Me.dgv_periodo_dias.Size = New System.Drawing.Size(217, 182)
        Me.dgv_periodo_dias.TabIndex = 40
        '
        'Periodo
        '
        Me.Periodo.HeaderText = "Periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.ReadOnly = True
        '
        'dias_disponibles
        '
        Me.dias_disponibles.HeaderText = "Dias Disponibles"
        Me.dias_disponibles.Name = "dias_disponibles"
        Me.dias_disponibles.ReadOnly = True
        Me.dias_disponibles.Width = 110
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Periodo"
        '
        'txt_dias_disponibles
        '
        Me.txt_dias_disponibles.Location = New System.Drawing.Point(436, 78)
        Me.txt_dias_disponibles.Name = "txt_dias_disponibles"
        Me.txt_dias_disponibles.ReadOnly = True
        Me.txt_dias_disponibles.Size = New System.Drawing.Size(82, 20)
        Me.txt_dias_disponibles.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(306, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Dias Disponibles"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(306, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Fecha Final Vacaciones"
        '
        'dtp_fin_vacaciones
        '
        Me.dtp_fin_vacaciones.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fin_vacaciones.Location = New System.Drawing.Point(436, 50)
        Me.dtp_fin_vacaciones.Name = "dtp_fin_vacaciones"
        Me.dtp_fin_vacaciones.Size = New System.Drawing.Size(82, 20)
        Me.dtp_fin_vacaciones.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(306, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Fecha Inicio Vacaciones"
        '
        'dtp_Inicio_Vacaciones
        '
        Me.dtp_Inicio_Vacaciones.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Inicio_Vacaciones.Location = New System.Drawing.Point(436, 26)
        Me.dtp_Inicio_Vacaciones.Name = "dtp_Inicio_Vacaciones"
        Me.dtp_Inicio_Vacaciones.Size = New System.Drawing.Size(82, 20)
        Me.dtp_Inicio_Vacaciones.TabIndex = 33
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_empresa)
        Me.GroupBox1.Controls.Add(Me.lbl_fec_final)
        Me.GroupBox1.Controls.Add(Me.txt_fecha_final)
        Me.GroupBox1.Controls.Add(Me.txt_fecha_ingreso)
        Me.GroupBox1.Controls.Add(Me.Lbl_estado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_puesto)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_departamento)
        Me.GroupBox1.Controls.Add(Me.txt_ficha)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda)
        Me.GroupBox1.Controls.Add(Me.txt_nombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "Empresa"
        '
        'txt_empresa
        '
        Me.txt_empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_empresa.Location = New System.Drawing.Point(101, 75)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.ReadOnly = True
        Me.txt_empresa.Size = New System.Drawing.Size(112, 20)
        Me.txt_empresa.TabIndex = 106
        '
        'lbl_fec_final
        '
        Me.lbl_fec_final.AutoSize = True
        Me.lbl_fec_final.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fec_final.ForeColor = System.Drawing.Color.Black
        Me.lbl_fec_final.Location = New System.Drawing.Point(259, 91)
        Me.lbl_fec_final.Name = "lbl_fec_final"
        Me.lbl_fec_final.Size = New System.Drawing.Size(71, 15)
        Me.lbl_fec_final.TabIndex = 105
        Me.lbl_fec_final.Text = "Fecha Final"
        Me.lbl_fec_final.Visible = False
        '
        'txt_fecha_final
        '
        Me.txt_fecha_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_fecha_final.Location = New System.Drawing.Point(336, 87)
        Me.txt_fecha_final.Name = "txt_fecha_final"
        Me.txt_fecha_final.ReadOnly = True
        Me.txt_fecha_final.Size = New System.Drawing.Size(118, 20)
        Me.txt_fecha_final.TabIndex = 104
        Me.txt_fecha_final.Visible = False
        '
        'txt_fecha_ingreso
        '
        Me.txt_fecha_ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_fecha_ingreso.Location = New System.Drawing.Point(101, 107)
        Me.txt_fecha_ingreso.Name = "txt_fecha_ingreso"
        Me.txt_fecha_ingreso.ReadOnly = True
        Me.txt_fecha_ingreso.Size = New System.Drawing.Size(112, 20)
        Me.txt_fecha_ingreso.TabIndex = 103
        '
        'Lbl_estado
        '
        Me.Lbl_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_estado.ForeColor = System.Drawing.Color.Red
        Me.Lbl_estado.Location = New System.Drawing.Point(298, 59)
        Me.Lbl_estado.Name = "Lbl_estado"
        Me.Lbl_estado.Size = New System.Drawing.Size(129, 23)
        Me.Lbl_estado.TabIndex = 102
        Me.Lbl_estado.Text = "Empleado Inactivo"
        Me.Lbl_estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_estado.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Puesto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Departamento"
        '
        'txt_puesto
        '
        Me.txt_puesto.BackColor = System.Drawing.Color.White
        Me.txt_puesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_puesto.Location = New System.Drawing.Point(101, 163)
        Me.txt_puesto.Name = "txt_puesto"
        Me.txt_puesto.ReadOnly = True
        Me.txt_puesto.Size = New System.Drawing.Size(256, 20)
        Me.txt_puesto.TabIndex = 40
        Me.txt_puesto.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 15)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Fecha Ingreso"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 15)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Ficha"
        '
        'txt_departamento
        '
        Me.txt_departamento.BackColor = System.Drawing.Color.White
        Me.txt_departamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_departamento.Location = New System.Drawing.Point(101, 137)
        Me.txt_departamento.Name = "txt_departamento"
        Me.txt_departamento.ReadOnly = True
        Me.txt_departamento.Size = New System.Drawing.Size(256, 20)
        Me.txt_departamento.TabIndex = 38
        Me.txt_departamento.TabStop = False
        '
        'txt_ficha
        '
        Me.txt_ficha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_ficha.Location = New System.Drawing.Point(101, 45)
        Me.txt_ficha.Name = "txt_ficha"
        Me.txt_ficha.ReadOnly = True
        Me.txt_ficha.Size = New System.Drawing.Size(112, 20)
        Me.txt_ficha.TabIndex = 28
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(363, 18)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(76, 21)
        Me.btn_ayuda.TabIndex = 20
        Me.btn_ayuda.Text = "Buscar"
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt_nombre.Location = New System.Drawing.Point(101, 19)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.ReadOnly = True
        Me.txt_nombre.Size = New System.Drawing.Size(256, 20)
        Me.txt_nombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empleado"
        '
        'tb_historial_vacaciones
        '
        Me.tb_historial_vacaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_historial_vacaciones.Controls.Add(Me.lbl_historial_estado)
        Me.tb_historial_vacaciones.Controls.Add(Me.txt_historial_empresa)
        Me.tb_historial_vacaciones.Controls.Add(Me.Label14)
        Me.tb_historial_vacaciones.Controls.Add(Me.btn_historial_eliminar)
        Me.tb_historial_vacaciones.Controls.Add(Me.txt_historial_ficha)
        Me.tb_historial_vacaciones.Controls.Add(Me.Label12)
        Me.tb_historial_vacaciones.Controls.Add(Me.dgv_historial)
        Me.tb_historial_vacaciones.Controls.Add(Me.btn_historial_buscar)
        Me.tb_historial_vacaciones.Controls.Add(Me.Label4)
        Me.tb_historial_vacaciones.Controls.Add(Me.txt_historial_nombre)
        Me.tb_historial_vacaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.75!)
        Me.tb_historial_vacaciones.Location = New System.Drawing.Point(4, 22)
        Me.tb_historial_vacaciones.Name = "tb_historial_vacaciones"
        Me.tb_historial_vacaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_historial_vacaciones.Size = New System.Drawing.Size(659, 455)
        Me.tb_historial_vacaciones.TabIndex = 1
        Me.tb_historial_vacaciones.Text = "Historial de Vacaciones"
        '
        'lbl_historial_estado
        '
        Me.lbl_historial_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_historial_estado.ForeColor = System.Drawing.Color.Red
        Me.lbl_historial_estado.Location = New System.Drawing.Point(245, 68)
        Me.lbl_historial_estado.Name = "lbl_historial_estado"
        Me.lbl_historial_estado.Size = New System.Drawing.Size(129, 23)
        Me.lbl_historial_estado.TabIndex = 103
        Me.lbl_historial_estado.Text = "Empleado Inactivo"
        Me.lbl_historial_estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_historial_estado.Visible = False
        '
        'txt_historial_empresa
        '
        Me.txt_historial_empresa.Location = New System.Drawing.Point(66, 46)
        Me.txt_historial_empresa.Name = "txt_historial_empresa"
        Me.txt_historial_empresa.ReadOnly = True
        Me.txt_historial_empresa.Size = New System.Drawing.Size(142, 19)
        Me.txt_historial_empresa.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Empresa"
        '
        'btn_historial_eliminar
        '
        Me.btn_historial_eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_historial_eliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_historial_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_historial_eliminar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_historial_eliminar.ForeColor = System.Drawing.Color.White
        Me.btn_historial_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_historial_eliminar.ImageIndex = 3
        Me.btn_historial_eliminar.Location = New System.Drawing.Point(568, 49)
        Me.btn_historial_eliminar.Name = "btn_historial_eliminar"
        Me.btn_historial_eliminar.Size = New System.Drawing.Size(76, 43)
        Me.btn_historial_eliminar.TabIndex = 25
        Me.btn_historial_eliminar.Text = "Eliminar"
        Me.btn_historial_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_historial_eliminar.UseVisualStyleBackColor = False
        '
        'txt_historial_ficha
        '
        Me.txt_historial_ficha.Location = New System.Drawing.Point(66, 71)
        Me.txt_historial_ficha.Name = "txt_historial_ficha"
        Me.txt_historial_ficha.ReadOnly = True
        Me.txt_historial_ficha.Size = New System.Drawing.Size(142, 19)
        Me.txt_historial_ficha.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Ficha"
        '
        'dgv_historial
        '
        Me.dgv_historial.AllowUserToAddRows = False
        Me.dgv_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_historial.Location = New System.Drawing.Point(9, 96)
        Me.dgv_historial.Name = "dgv_historial"
        Me.dgv_historial.ReadOnly = True
        Me.dgv_historial.RowHeadersWidth = 25
        Me.dgv_historial.Size = New System.Drawing.Size(644, 353)
        Me.dgv_historial.TabIndex = 22
        '
        'btn_historial_buscar
        '
        Me.btn_historial_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_historial_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_historial_buscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_historial_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_historial_buscar.Location = New System.Drawing.Point(380, 22)
        Me.btn_historial_buscar.Name = "btn_historial_buscar"
        Me.btn_historial_buscar.Size = New System.Drawing.Size(76, 21)
        Me.btn_historial_buscar.TabIndex = 21
        Me.btn_historial_buscar.Text = "Buscar"
        Me.btn_historial_buscar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Empleado"
        '
        'txt_historial_nombre
        '
        Me.txt_historial_nombre.Location = New System.Drawing.Point(66, 22)
        Me.txt_historial_nombre.Name = "txt_historial_nombre"
        Me.txt_historial_nombre.ReadOnly = True
        Me.txt_historial_nombre.Size = New System.Drawing.Size(308, 19)
        Me.txt_historial_nombre.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.cmb_empresa)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(659, 455)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Trasladar Historial de Vacaciones"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.txt_empleado)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txt_empre)
        Me.GroupBox3.Controls.Add(Me.txt_fi)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Location = New System.Drawing.Point(69, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(525, 108)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(361, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 21)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txt_empleado
        '
        Me.txt_empleado.Location = New System.Drawing.Point(129, 20)
        Me.txt_empleado.Name = "txt_empleado"
        Me.txt_empleado.ReadOnly = True
        Me.txt_empleado.Size = New System.Drawing.Size(225, 20)
        Me.txt_empleado.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(69, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Empleado"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(69, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Ficha"
        '
        'txt_empre
        '
        Me.txt_empre.Location = New System.Drawing.Point(129, 72)
        Me.txt_empre.Name = "txt_empre"
        Me.txt_empre.ReadOnly = True
        Me.txt_empre.Size = New System.Drawing.Size(308, 20)
        Me.txt_empre.TabIndex = 31
        '
        'txt_fi
        '
        Me.txt_fi.Location = New System.Drawing.Point(129, 46)
        Me.txt_fi.Name = "txt_fi"
        Me.txt_fi.ReadOnly = True
        Me.txt_fi.Size = New System.Drawing.Size(308, 20)
        Me.txt_fi.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(69, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Empresa"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(273, 256)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 21)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "Actualizar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(138, 223)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Empresa a Trasladar"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(254, 220)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(252, 21)
        Me.cmb_empresa.TabIndex = 32
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Dias Disponibles"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Dias"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(222, 65)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(267, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "TRASLADO DE HISTORIAL DE VACACIONES"
        '
        'frm_control_vacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(672, 495)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_control_vacaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Control de Vacaciones .::"
        Me.TabControl1.ResumeLayout(False)
        Me.tb_solicitud_vacaciones.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_periodo_dias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tb_historial_vacaciones.ResumeLayout(False)
        Me.tb_historial_vacaciones.PerformLayout()
        CType(Me.dgv_historial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_solicitud_vacaciones As System.Windows.Forms.TabPage
    Friend WithEvents tb_historial_vacaciones As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_puesto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_departamento As System.Windows.Forms.TextBox
    Friend WithEvents txt_ficha As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_estado As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_Inicio_Vacaciones As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtp_fin_vacaciones As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_dias_disponibles As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_periodo_dias As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_fecha_ingreso As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_dias_solicitados As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv_historial As System.Windows.Forms.DataGridView
    Friend WithEvents btn_historial_buscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_historial_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_historial_ficha As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Periodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dias_disponibles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_historial_eliminar As System.Windows.Forms.Button
    Friend WithEvents lbl_fec_final As System.Windows.Forms.Label
    Friend WithEvents txt_fecha_final As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_empresa As System.Windows.Forms.TextBox
    Friend WithEvents txt_historial_empresa As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_historial_estado As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_empleado As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_empre As System.Windows.Forms.TextBox
    Friend WithEvents txt_fi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
