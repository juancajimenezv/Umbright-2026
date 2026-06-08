<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_conciliacion_bancaria
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.imprimir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_conciliar_manual = New System.Windows.Forms.Button()
        Me.btn_reconciliar = New System.Windows.Forms.Button()
        Me.btn_importar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cta = New System.Windows.Forms.Label()
        Me.periodo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_cta_banco = New System.Windows.Forms.ComboBox()
        Me.cmb_mes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgv_banco = New System.Windows.Forms.DataGridView()
        Me.conteo_banco = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_conta = New System.Windows.Forms.DataGridView()
        Me.conteo_conta = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgv_conciliado = New System.Windows.Forms.DataGridView()
        Me.conteo_conciliado = New System.Windows.Forms.Label()
        Me.tab = New System.Windows.Forms.TabPage()
        Me.listado_tipos = New System.Windows.Forms.DataGridView()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.group = New System.Windows.Forms.GroupBox()
        Me.banco = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cuenta = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.destino = New System.Windows.Forms.TextBox()
        Me.origen = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Cmb_bancos = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.listadoposiciones = New System.Windows.Forms.DataGridView()
        Me.modificar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        Me.guardar = New System.Windows.Forms.Button()
        Me.nuevo = New System.Windows.Forms.Button()
        Me.pos_con = New System.Windows.Forms.TextBox()
        Me.pos_concepto = New System.Windows.Forms.Label()
        Me.pos_tipo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pos_documento = New System.Windows.Forms.TextBox()
        Me.pos_fecha = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pos_haber = New System.Windows.Forms.TextBox()
        Me.pos_debe = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_revertir_conciliacion = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_conta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgv_conciliado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab.SuspendLayout()
        CType(Me.listado_tipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.listadoposiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tab)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 9)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1274, 667)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btn_revertir_conciliacion)
        Me.TabPage1.Controls.Add(Me.imprimir)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.btn_conciliar_manual)
        Me.TabPage1.Controls.Add(Me.btn_reconciliar)
        Me.TabPage1.Controls.Add(Me.btn_importar)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1266, 641)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Conciliacion"
        '
        'imprimir
        '
        Me.imprimir.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.imprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imprimir.Location = New System.Drawing.Point(1185, 549)
        Me.imprimir.Name = "imprimir"
        Me.imprimir.Size = New System.Drawing.Size(75, 65)
        Me.imprimir.TabIndex = 20
        Me.imprimir.Text = "Imprimir"
        Me.imprimir.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(1023, 550)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 62)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Obtener Informacion"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_conciliar_manual
        '
        Me.btn_conciliar_manual.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_conciliar_manual.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_conciliar_manual.Enabled = False
        Me.btn_conciliar_manual.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_conciliar_manual.Location = New System.Drawing.Point(1104, 478)
        Me.btn_conciliar_manual.Name = "btn_conciliar_manual"
        Me.btn_conciliar_manual.Size = New System.Drawing.Size(75, 65)
        Me.btn_conciliar_manual.TabIndex = 8
        Me.btn_conciliar_manual.Text = "Conciliacion Manual"
        Me.btn_conciliar_manual.UseVisualStyleBackColor = False
        '
        'btn_reconciliar
        '
        Me.btn_reconciliar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_reconciliar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_reconciliar.Enabled = False
        Me.btn_reconciliar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_reconciliar.Location = New System.Drawing.Point(1023, 478)
        Me.btn_reconciliar.Name = "btn_reconciliar"
        Me.btn_reconciliar.Size = New System.Drawing.Size(75, 65)
        Me.btn_reconciliar.TabIndex = 7
        Me.btn_reconciliar.Text = "Reconciliar"
        Me.btn_reconciliar.UseVisualStyleBackColor = False
        '
        'btn_importar
        '
        Me.btn_importar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_importar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_importar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_importar.Location = New System.Drawing.Point(1104, 549)
        Me.btn_importar.Name = "btn_importar"
        Me.btn_importar.Size = New System.Drawing.Size(75, 65)
        Me.btn_importar.TabIndex = 9
        Me.btn_importar.Text = "Importar Estado de Cuenta"
        Me.btn_importar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GroupBox1.Controls.Add(Me.cta)
        Me.GroupBox1.Controls.Add(Me.periodo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_cta_banco)
        Me.GroupBox1.Controls.Add(Me.cmb_mes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 42)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'cta
        '
        Me.cta.AutoSize = True
        Me.cta.Location = New System.Drawing.Point(440, 18)
        Me.cta.Name = "cta"
        Me.cta.Size = New System.Drawing.Size(10, 13)
        Me.cta.TabIndex = 18
        Me.cta.Text = "."
        '
        'periodo
        '
        Me.periodo.Location = New System.Drawing.Point(605, 15)
        Me.periodo.MaxLength = 4
        Me.periodo.Name = "periodo"
        Me.periodo.Size = New System.Drawing.Size(100, 20)
        Me.periodo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(548, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Periodo  : "
        '
        'cmb_cta_banco
        '
        Me.cmb_cta_banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_cta_banco.FormattingEnabled = True
        Me.cmb_cta_banco.Location = New System.Drawing.Point(80, 14)
        Me.cmb_cta_banco.Name = "cmb_cta_banco"
        Me.cmb_cta_banco.Size = New System.Drawing.Size(340, 21)
        Me.cmb_cta_banco.TabIndex = 3
        '
        'cmb_mes
        '
        Me.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mes.FormattingEnabled = True
        Me.cmb_mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmb_mes.Location = New System.Drawing.Point(763, 14)
        Me.cmb_mes.Name = "cmb_mes"
        Me.cmb_mes.Size = New System.Drawing.Size(100, 21)
        Me.cmb_mes.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cta. Banco : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(721, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mes : "
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GroupBox5.Controls.Add(Me.dgv_banco)
        Me.GroupBox5.Controls.Add(Me.conteo_banco)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 54)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(602, 374)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Estado Cuenta Banco"
        '
        'dgv_banco
        '
        Me.dgv_banco.AllowUserToAddRows = False
        Me.dgv_banco.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_banco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_banco.Location = New System.Drawing.Point(4, 19)
        Me.dgv_banco.Name = "dgv_banco"
        Me.dgv_banco.Size = New System.Drawing.Size(593, 349)
        Me.dgv_banco.TabIndex = 23
        '
        'conteo_banco
        '
        Me.conteo_banco.AutoSize = True
        Me.conteo_banco.Location = New System.Drawing.Point(137, 0)
        Me.conteo_banco.Name = "conteo_banco"
        Me.conteo_banco.Size = New System.Drawing.Size(10, 13)
        Me.conteo_banco.TabIndex = 22
        Me.conteo_banco.Text = "."
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgv_conta)
        Me.GroupBox6.Controls.Add(Me.conteo_conta)
        Me.GroupBox6.Location = New System.Drawing.Point(613, 54)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(650, 374)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Movimiento Contabilidad No Conciliado"
        '
        'dgv_conta
        '
        Me.dgv_conta.AllowUserToAddRows = False
        Me.dgv_conta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_conta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_conta.Location = New System.Drawing.Point(6, 19)
        Me.dgv_conta.Name = "dgv_conta"
        Me.dgv_conta.Size = New System.Drawing.Size(638, 349)
        Me.dgv_conta.TabIndex = 22
        '
        'conteo_conta
        '
        Me.conteo_conta.AutoSize = True
        Me.conteo_conta.Location = New System.Drawing.Point(207, 0)
        Me.conteo_conta.Name = "conteo_conta"
        Me.conteo_conta.Size = New System.Drawing.Size(10, 13)
        Me.conteo_conta.TabIndex = 21
        Me.conteo_conta.Text = "."
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.dgv_conciliado)
        Me.GroupBox7.Controls.Add(Me.conteo_conciliado)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 434)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(995, 204)
        Me.GroupBox7.TabIndex = 18
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Movimiento Conciliado"
        '
        'dgv_conciliado
        '
        Me.dgv_conciliado.AllowUserToAddRows = False
        Me.dgv_conciliado.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_conciliado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_conciliado.Location = New System.Drawing.Point(6, 19)
        Me.dgv_conciliado.Name = "dgv_conciliado"
        Me.dgv_conciliado.Size = New System.Drawing.Size(983, 180)
        Me.dgv_conciliado.TabIndex = 22
        '
        'conteo_conciliado
        '
        Me.conteo_conciliado.AutoSize = True
        Me.conteo_conciliado.Location = New System.Drawing.Point(139, 2)
        Me.conteo_conciliado.Name = "conteo_conciliado"
        Me.conteo_conciliado.Size = New System.Drawing.Size(10, 13)
        Me.conteo_conciliado.TabIndex = 20
        Me.conteo_conciliado.Text = "."
        '
        'tab
        '
        Me.tab.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tab.Controls.Add(Me.listado_tipos)
        Me.tab.Controls.Add(Me.btn_modificar)
        Me.tab.Controls.Add(Me.btn_Cancelar)
        Me.tab.Controls.Add(Me.btn_guardar)
        Me.tab.Controls.Add(Me.btn_nuevo)
        Me.tab.Controls.Add(Me.group)
        Me.tab.Location = New System.Drawing.Point(4, 22)
        Me.tab.Name = "tab"
        Me.tab.Padding = New System.Windows.Forms.Padding(3)
        Me.tab.Size = New System.Drawing.Size(1266, 641)
        Me.tab.TabIndex = 1
        Me.tab.Text = "Equivalencia de Tipos"
        '
        'listado_tipos
        '
        Me.listado_tipos.AllowUserToAddRows = False
        Me.listado_tipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.listado_tipos.Location = New System.Drawing.Point(28, 179)
        Me.listado_tipos.Name = "listado_tipos"
        Me.listado_tipos.ReadOnly = True
        Me.listado_tipos.Size = New System.Drawing.Size(395, 313)
        Me.listado_tipos.TabIndex = 38
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.ForeColor = System.Drawing.Color.White
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.ImageIndex = 0
        Me.btn_modificar.Location = New System.Drawing.Point(589, 190)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(75, 61)
        Me.btn_modificar.TabIndex = 37
        Me.btn_modificar.Text = "Modificar"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cancelar.ImageIndex = 0
        Me.btn_Cancelar.Location = New System.Drawing.Point(589, 256)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 61)
        Me.btn_Cancelar.TabIndex = 36
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        Me.btn_Cancelar.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.Location = New System.Drawing.Point(508, 256)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 61)
        Me.btn_guardar.TabIndex = 35
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        Me.btn_guardar.Visible = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.Location = New System.Drawing.Point(508, 190)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 61)
        Me.btn_nuevo.TabIndex = 34
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'group
        '
        Me.group.Controls.Add(Me.banco)
        Me.group.Controls.Add(Me.Label5)
        Me.group.Controls.Add(Me.cuenta)
        Me.group.Controls.Add(Me.Label22)
        Me.group.Controls.Add(Me.Label8)
        Me.group.Controls.Add(Me.destino)
        Me.group.Controls.Add(Me.origen)
        Me.group.Controls.Add(Me.Label7)
        Me.group.Location = New System.Drawing.Point(28, 26)
        Me.group.Name = "group"
        Me.group.Size = New System.Drawing.Size(678, 123)
        Me.group.TabIndex = 33
        Me.group.TabStop = False
        Me.group.Text = "Equivalencias Tipos de Documento"
        '
        'banco
        '
        Me.banco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.banco.DisplayMember = "BANRURAL"
        Me.banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.banco.Enabled = False
        Me.banco.FormattingEnabled = True
        Me.banco.Items.AddRange(New Object() {"INDUSTRIAL", "G&T", "BAM", "BANRURAL", "BAC", "QUETZAL", "CUSCATLAN"})
        Me.banco.Location = New System.Drawing.Point(106, 23)
        Me.banco.Name = "banco"
        Me.banco.Size = New System.Drawing.Size(289, 21)
        Me.banco.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Banco : "
        '
        'cuenta
        '
        Me.cuenta.AutoSize = True
        Me.cuenta.Location = New System.Drawing.Point(534, 23)
        Me.cuenta.Name = "cuenta"
        Me.cuenta.Size = New System.Drawing.Size(10, 13)
        Me.cuenta.TabIndex = 41
        Me.cuenta.Text = "."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(278, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 33
        Me.Label22.Text = "Destino "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(138, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Origen "
        '
        'destino
        '
        Me.destino.Enabled = False
        Me.destino.Location = New System.Drawing.Point(249, 68)
        Me.destino.Name = "destino"
        Me.destino.Size = New System.Drawing.Size(116, 20)
        Me.destino.TabIndex = 34
        '
        'origen
        '
        Me.origen.Enabled = False
        Me.origen.Location = New System.Drawing.Point(109, 68)
        Me.origen.Name = "origen"
        Me.origen.Size = New System.Drawing.Size(122, 20)
        Me.origen.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Equivalencia :"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Cmb_bancos)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.listadoposiciones)
        Me.TabPage3.Controls.Add(Me.modificar)
        Me.TabPage3.Controls.Add(Me.cancelar)
        Me.TabPage3.Controls.Add(Me.guardar)
        Me.TabPage3.Controls.Add(Me.nuevo)
        Me.TabPage3.Controls.Add(Me.pos_con)
        Me.TabPage3.Controls.Add(Me.pos_concepto)
        Me.TabPage3.Controls.Add(Me.pos_tipo)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.pos_documento)
        Me.TabPage3.Controls.Add(Me.pos_fecha)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.pos_haber)
        Me.TabPage3.Controls.Add(Me.pos_debe)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1266, 641)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Configuracion de Posicion de Estado de Cuenta"
        '
        'Cmb_bancos
        '
        Me.Cmb_bancos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmb_bancos.DisplayMember = "BANRURAL"
        Me.Cmb_bancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_bancos.Enabled = False
        Me.Cmb_bancos.FormattingEnabled = True
        Me.Cmb_bancos.Items.AddRange(New Object() {"INDUSTRIAL", "G&T", "BAM", "BANRURAL", "BAC", "QUETZAL", "CUSCATLAN"})
        Me.Cmb_bancos.Location = New System.Drawing.Point(158, 40)
        Me.Cmb_bancos.Name = "Cmb_bancos"
        Me.Cmb_bancos.Size = New System.Drawing.Size(289, 21)
        Me.Cmb_bancos.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(108, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Banco : "
        '
        'listadoposiciones
        '
        Me.listadoposiciones.AllowUserToAddRows = False
        Me.listadoposiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listadoposiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.listadoposiciones.Location = New System.Drawing.Point(12, 237)
        Me.listadoposiciones.Name = "listadoposiciones"
        Me.listadoposiciones.ReadOnly = True
        Me.listadoposiciones.Size = New System.Drawing.Size(756, 252)
        Me.listadoposiciones.TabIndex = 40
        '
        'modificar
        '
        Me.modificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.modificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.ForeColor = System.Drawing.Color.White
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.modificar.ImageIndex = 0
        Me.modificar.Location = New System.Drawing.Point(605, 45)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(75, 61)
        Me.modificar.TabIndex = 39
        Me.modificar.Text = "Modificar"
        Me.modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.modificar.UseVisualStyleBackColor = False
        '
        'cancelar
        '
        Me.cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelar.ForeColor = System.Drawing.Color.White
        Me.cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cancelar.ImageIndex = 0
        Me.cancelar.Location = New System.Drawing.Point(605, 124)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(75, 61)
        Me.cancelar.TabIndex = 38
        Me.cancelar.Text = "Cancelar"
        Me.cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cancelar.UseVisualStyleBackColor = False
        Me.cancelar.Visible = False
        '
        'guardar
        '
        Me.guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ForeColor = System.Drawing.Color.White
        Me.guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.guardar.ImageIndex = 1
        Me.guardar.Location = New System.Drawing.Point(524, 124)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(75, 61)
        Me.guardar.TabIndex = 37
        Me.guardar.Text = "Guardar"
        Me.guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.guardar.UseVisualStyleBackColor = False
        Me.guardar.Visible = False
        '
        'nuevo
        '
        Me.nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ForeColor = System.Drawing.Color.White
        Me.nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.nuevo.ImageIndex = 0
        Me.nuevo.Location = New System.Drawing.Point(524, 45)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(75, 61)
        Me.nuevo.TabIndex = 36
        Me.nuevo.Text = "Nuevo"
        Me.nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.nuevo.UseVisualStyleBackColor = False
        '
        'pos_con
        '
        Me.pos_con.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_con.Enabled = False
        Me.pos_con.Location = New System.Drawing.Point(158, 151)
        Me.pos_con.Name = "pos_con"
        Me.pos_con.Size = New System.Drawing.Size(131, 20)
        Me.pos_con.TabIndex = 33
        '
        'pos_concepto
        '
        Me.pos_concepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_concepto.AutoSize = True
        Me.pos_concepto.Location = New System.Drawing.Point(48, 151)
        Me.pos_concepto.Name = "pos_concepto"
        Me.pos_concepto.Size = New System.Drawing.Size(108, 13)
        Me.pos_concepto.TabIndex = 34
        Me.pos_concepto.Text = "Posicion Concepto  : "
        '
        'pos_tipo
        '
        Me.pos_tipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_tipo.Enabled = False
        Me.pos_tipo.Location = New System.Drawing.Point(158, 124)
        Me.pos_tipo.Name = "pos_tipo"
        Me.pos_tipo.Size = New System.Drawing.Size(131, 20)
        Me.pos_tipo.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Posicion Tipo Docto. : "
        '
        'pos_documento
        '
        Me.pos_documento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_documento.Enabled = False
        Me.pos_documento.Location = New System.Drawing.Point(158, 98)
        Me.pos_documento.Name = "pos_documento"
        Me.pos_documento.Size = New System.Drawing.Size(131, 20)
        Me.pos_documento.TabIndex = 31
        '
        'pos_fecha
        '
        Me.pos_fecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_fecha.Enabled = False
        Me.pos_fecha.Location = New System.Drawing.Point(158, 72)
        Me.pos_fecha.Name = "pos_fecha"
        Me.pos_fecha.Size = New System.Drawing.Size(131, 20)
        Me.pos_fecha.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Posicion Documento : "
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(67, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Posicion Fecha : "
        '
        'pos_haber
        '
        Me.pos_haber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_haber.Enabled = False
        Me.pos_haber.Location = New System.Drawing.Point(158, 204)
        Me.pos_haber.Name = "pos_haber"
        Me.pos_haber.Size = New System.Drawing.Size(131, 20)
        Me.pos_haber.TabIndex = 35
        '
        'pos_debe
        '
        Me.pos_debe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pos_debe.Enabled = False
        Me.pos_debe.Location = New System.Drawing.Point(158, 177)
        Me.pos_debe.Name = "pos_debe"
        Me.pos_debe.Size = New System.Drawing.Size(131, 20)
        Me.pos_debe.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(68, 204)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Posicion Haber : "
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(72, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Posicion Debe : "
        '
        'btn_revertir_conciliacion
        '
        Me.btn_revertir_conciliacion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_revertir_conciliacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_revertir_conciliacion.Enabled = False
        Me.btn_revertir_conciliacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_revertir_conciliacion.Location = New System.Drawing.Point(1185, 478)
        Me.btn_revertir_conciliacion.Name = "btn_revertir_conciliacion"
        Me.btn_revertir_conciliacion.Size = New System.Drawing.Size(75, 65)
        Me.btn_revertir_conciliacion.TabIndex = 21
        Me.btn_revertir_conciliacion.Text = "Revertir Conciliacion"
        Me.btn_revertir_conciliacion.UseVisualStyleBackColor = False
        '
        'frm_conciliacion_bancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1276, 688)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_conciliacion_bancaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Conciliacion Bancaria :: "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_banco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgv_conta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.dgv_conciliado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab.ResumeLayout(False)
        CType(Me.listado_tipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group.ResumeLayout(False)
        Me.group.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.listadoposiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tab As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_conciliar_manual As System.Windows.Forms.Button
    Friend WithEvents btn_reconciliar As System.Windows.Forms.Button
    Friend WithEvents btn_importar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents periodo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_cta_banco As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents pos_con As System.Windows.Forms.TextBox
    Friend WithEvents pos_concepto As System.Windows.Forms.Label
    Friend WithEvents pos_tipo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pos_documento As System.Windows.Forms.TextBox
    Friend WithEvents pos_fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pos_haber As System.Windows.Forms.TextBox
    Friend WithEvents pos_debe As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents modificar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents listado_tipos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents group As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents destino As System.Windows.Forms.TextBox
    Friend WithEvents origen As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents listadoposiciones As System.Windows.Forms.DataGridView
    Friend WithEvents Cmb_bancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents cuenta As System.Windows.Forms.Label
    Friend WithEvents banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cta As System.Windows.Forms.Label
    Friend WithEvents imprimir As System.Windows.Forms.Button
    Friend WithEvents conteo_banco As System.Windows.Forms.Label
    Friend WithEvents conteo_conta As System.Windows.Forms.Label
    Friend WithEvents conteo_conciliado As System.Windows.Forms.Label
    Friend WithEvents dgv_banco As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_conta As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_conciliado As System.Windows.Forms.DataGridView
    Friend WithEvents btn_revertir_conciliacion As System.Windows.Forms.Button
End Class
