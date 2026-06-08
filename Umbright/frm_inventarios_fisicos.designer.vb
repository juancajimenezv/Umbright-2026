<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_inventarios_fisicos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmb_operador_logico5 = New System.Windows.Forms.ComboBox
        Me.cmb_operador_logico4 = New System.Windows.Forms.ComboBox
        Me.cmb_operador_logico3 = New System.Windows.Forms.ComboBox
        Me.cmb_operador_logico2 = New System.Windows.Forms.ComboBox
        Me.cmb_operador_logico1 = New System.Windows.Forms.ComboBox
        Me.cmb_operador6 = New System.Windows.Forms.ComboBox
        Me.cmb_campos6 = New System.Windows.Forms.ComboBox
        Me.cmb_operador5 = New System.Windows.Forms.ComboBox
        Me.cmb_campos5 = New System.Windows.Forms.ComboBox
        Me.cmb_operador4 = New System.Windows.Forms.ComboBox
        Me.cmb_campos4 = New System.Windows.Forms.ComboBox
        Me.cmb_operador3 = New System.Windows.Forms.ComboBox
        Me.cmb_campos3 = New System.Windows.Forms.ComboBox
        Me.cmb_operador2 = New System.Windows.Forms.ComboBox
        Me.cmb_campos2 = New System.Windows.Forms.ComboBox
        Me.cmb_operador1 = New System.Windows.Forms.ComboBox
        Me.cmb_campos1 = New System.Windows.Forms.ComboBox
        Me.txt_buscar6 = New System.Windows.Forms.TextBox
        Me.txt_buscar5 = New System.Windows.Forms.TextBox
        Me.txt_buscar4 = New System.Windows.Forms.TextBox
        Me.txt_buscar3 = New System.Windows.Forms.TextBox
        Me.txt_buscar2 = New System.Windows.Forms.TextBox
        Me.txt_buscar1 = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_actualizar_Barras = New System.Windows.Forms.Button
        Me.dgv_listado_barras = New System.Windows.Forms.DataGridView
        Me.btn_obtener_archivos = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.cmbConteos = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv_conteo = New System.Windows.Forms.DataGridView
        Me.btn_enviar_Excel = New System.Windows.Forms.Button
        Me.btn_obtener_informacion2 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_listado_barras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_conteo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(791, 485)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.NumericUpDown1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.btn_generar)
        Me.TabPage1.Controls.Add(Me.cmb_operador_logico5)
        Me.TabPage1.Controls.Add(Me.cmb_operador_logico4)
        Me.TabPage1.Controls.Add(Me.cmb_operador_logico3)
        Me.TabPage1.Controls.Add(Me.cmb_operador_logico2)
        Me.TabPage1.Controls.Add(Me.cmb_operador_logico1)
        Me.TabPage1.Controls.Add(Me.cmb_operador6)
        Me.TabPage1.Controls.Add(Me.cmb_campos6)
        Me.TabPage1.Controls.Add(Me.cmb_operador5)
        Me.TabPage1.Controls.Add(Me.cmb_campos5)
        Me.TabPage1.Controls.Add(Me.cmb_operador4)
        Me.TabPage1.Controls.Add(Me.cmb_campos4)
        Me.TabPage1.Controls.Add(Me.cmb_operador3)
        Me.TabPage1.Controls.Add(Me.cmb_campos3)
        Me.TabPage1.Controls.Add(Me.cmb_operador2)
        Me.TabPage1.Controls.Add(Me.cmb_campos2)
        Me.TabPage1.Controls.Add(Me.cmb_operador1)
        Me.TabPage1.Controls.Add(Me.cmb_campos1)
        Me.TabPage1.Controls.Add(Me.txt_buscar6)
        Me.TabPage1.Controls.Add(Me.txt_buscar5)
        Me.TabPage1.Controls.Add(Me.txt_buscar4)
        Me.TabPage1.Controls.Add(Me.txt_buscar3)
        Me.TabPage1.Controls.Add(Me.txt_buscar2)
        Me.TabPage1.Controls.Add(Me.txt_buscar1)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(783, 459)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Envio Informacion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(671, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Conteo No."
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(738, 119)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(39, 20)
        Me.NumericUpDown1.TabIndex = 26
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(688, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 45)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Generar PDA"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_generar
        '
        Me.btn_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Location = New System.Drawing.Point(688, 6)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(89, 45)
        Me.btn_generar.TabIndex = 24
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_operador_logico5
        '
        Me.cmb_operador_logico5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador_logico5.FormattingEnabled = True
        Me.cmb_operador_logico5.Items.AddRange(New Object() {"Y", "O"})
        Me.cmb_operador_logico5.Location = New System.Drawing.Point(607, 100)
        Me.cmb_operador_logico5.Name = "cmb_operador_logico5"
        Me.cmb_operador_logico5.Size = New System.Drawing.Size(41, 21)
        Me.cmb_operador_logico5.TabIndex = 20
        '
        'cmb_operador_logico4
        '
        Me.cmb_operador_logico4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador_logico4.FormattingEnabled = True
        Me.cmb_operador_logico4.Items.AddRange(New Object() {"Y", "O"})
        Me.cmb_operador_logico4.Location = New System.Drawing.Point(607, 77)
        Me.cmb_operador_logico4.Name = "cmb_operador_logico4"
        Me.cmb_operador_logico4.Size = New System.Drawing.Size(41, 21)
        Me.cmb_operador_logico4.TabIndex = 16
        '
        'cmb_operador_logico3
        '
        Me.cmb_operador_logico3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador_logico3.FormattingEnabled = True
        Me.cmb_operador_logico3.Items.AddRange(New Object() {"Y", "O"})
        Me.cmb_operador_logico3.Location = New System.Drawing.Point(607, 53)
        Me.cmb_operador_logico3.Name = "cmb_operador_logico3"
        Me.cmb_operador_logico3.Size = New System.Drawing.Size(41, 21)
        Me.cmb_operador_logico3.TabIndex = 12
        '
        'cmb_operador_logico2
        '
        Me.cmb_operador_logico2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador_logico2.FormattingEnabled = True
        Me.cmb_operador_logico2.Items.AddRange(New Object() {"Y", "O"})
        Me.cmb_operador_logico2.Location = New System.Drawing.Point(607, 29)
        Me.cmb_operador_logico2.Name = "cmb_operador_logico2"
        Me.cmb_operador_logico2.Size = New System.Drawing.Size(41, 21)
        Me.cmb_operador_logico2.TabIndex = 8
        '
        'cmb_operador_logico1
        '
        Me.cmb_operador_logico1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador_logico1.FormattingEnabled = True
        Me.cmb_operador_logico1.Items.AddRange(New Object() {"Y", "O"})
        Me.cmb_operador_logico1.Location = New System.Drawing.Point(607, 6)
        Me.cmb_operador_logico1.Name = "cmb_operador_logico1"
        Me.cmb_operador_logico1.Size = New System.Drawing.Size(41, 21)
        Me.cmb_operador_logico1.TabIndex = 4
        '
        'cmb_operador6
        '
        Me.cmb_operador6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador6.FormattingEnabled = True
        Me.cmb_operador6.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador6.Location = New System.Drawing.Point(103, 124)
        Me.cmb_operador6.Name = "cmb_operador6"
        Me.cmb_operador6.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador6.TabIndex = 22
        '
        'cmb_campos6
        '
        Me.cmb_campos6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos6.FormattingEnabled = True
        Me.cmb_campos6.Location = New System.Drawing.Point(6, 124)
        Me.cmb_campos6.Name = "cmb_campos6"
        Me.cmb_campos6.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos6.TabIndex = 21
        '
        'cmb_operador5
        '
        Me.cmb_operador5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador5.FormattingEnabled = True
        Me.cmb_operador5.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador5.Location = New System.Drawing.Point(103, 100)
        Me.cmb_operador5.Name = "cmb_operador5"
        Me.cmb_operador5.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador5.TabIndex = 18
        '
        'cmb_campos5
        '
        Me.cmb_campos5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos5.FormattingEnabled = True
        Me.cmb_campos5.Location = New System.Drawing.Point(6, 100)
        Me.cmb_campos5.Name = "cmb_campos5"
        Me.cmb_campos5.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos5.TabIndex = 17
        '
        'cmb_operador4
        '
        Me.cmb_operador4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador4.FormattingEnabled = True
        Me.cmb_operador4.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador4.Location = New System.Drawing.Point(103, 77)
        Me.cmb_operador4.Name = "cmb_operador4"
        Me.cmb_operador4.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador4.TabIndex = 14
        '
        'cmb_campos4
        '
        Me.cmb_campos4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos4.FormattingEnabled = True
        Me.cmb_campos4.Location = New System.Drawing.Point(6, 77)
        Me.cmb_campos4.Name = "cmb_campos4"
        Me.cmb_campos4.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos4.TabIndex = 13
        '
        'cmb_operador3
        '
        Me.cmb_operador3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador3.FormattingEnabled = True
        Me.cmb_operador3.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador3.Location = New System.Drawing.Point(103, 53)
        Me.cmb_operador3.Name = "cmb_operador3"
        Me.cmb_operador3.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador3.TabIndex = 10
        '
        'cmb_campos3
        '
        Me.cmb_campos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos3.FormattingEnabled = True
        Me.cmb_campos3.Location = New System.Drawing.Point(6, 53)
        Me.cmb_campos3.Name = "cmb_campos3"
        Me.cmb_campos3.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos3.TabIndex = 9
        '
        'cmb_operador2
        '
        Me.cmb_operador2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador2.FormattingEnabled = True
        Me.cmb_operador2.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador2.Location = New System.Drawing.Point(103, 29)
        Me.cmb_operador2.Name = "cmb_operador2"
        Me.cmb_operador2.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador2.TabIndex = 6
        '
        'cmb_campos2
        '
        Me.cmb_campos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos2.FormattingEnabled = True
        Me.cmb_campos2.Location = New System.Drawing.Point(6, 29)
        Me.cmb_campos2.Name = "cmb_campos2"
        Me.cmb_campos2.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos2.TabIndex = 5
        '
        'cmb_operador1
        '
        Me.cmb_operador1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_operador1.FormattingEnabled = True
        Me.cmb_operador1.Items.AddRange(New Object() {"=", ">", "<", "Contenga"})
        Me.cmb_operador1.Location = New System.Drawing.Point(103, 6)
        Me.cmb_operador1.Name = "cmb_operador1"
        Me.cmb_operador1.Size = New System.Drawing.Size(53, 21)
        Me.cmb_operador1.TabIndex = 2
        '
        'cmb_campos1
        '
        Me.cmb_campos1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_campos1.FormattingEnabled = True
        Me.cmb_campos1.Location = New System.Drawing.Point(6, 6)
        Me.cmb_campos1.Name = "cmb_campos1"
        Me.cmb_campos1.Size = New System.Drawing.Size(92, 21)
        Me.cmb_campos1.TabIndex = 1
        '
        'txt_buscar6
        '
        Me.txt_buscar6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar6.Location = New System.Drawing.Point(162, 124)
        Me.txt_buscar6.Name = "txt_buscar6"
        Me.txt_buscar6.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar6.TabIndex = 23
        '
        'txt_buscar5
        '
        Me.txt_buscar5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar5.Location = New System.Drawing.Point(162, 100)
        Me.txt_buscar5.Name = "txt_buscar5"
        Me.txt_buscar5.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar5.TabIndex = 19
        '
        'txt_buscar4
        '
        Me.txt_buscar4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar4.Location = New System.Drawing.Point(162, 77)
        Me.txt_buscar4.Name = "txt_buscar4"
        Me.txt_buscar4.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar4.TabIndex = 15
        '
        'txt_buscar3
        '
        Me.txt_buscar3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar3.Location = New System.Drawing.Point(162, 53)
        Me.txt_buscar3.Name = "txt_buscar3"
        Me.txt_buscar3.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar3.TabIndex = 11
        '
        'txt_buscar2
        '
        Me.txt_buscar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar2.Location = New System.Drawing.Point(162, 29)
        Me.txt_buscar2.Name = "txt_buscar2"
        Me.txt_buscar2.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar2.TabIndex = 7
        '
        'txt_buscar1
        '
        Me.txt_buscar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar1.Location = New System.Drawing.Point(162, 6)
        Me.txt_buscar1.Name = "txt_buscar1"
        Me.txt_buscar1.Size = New System.Drawing.Size(439, 20)
        Me.txt_buscar1.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 7.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(6, 150)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Size = New System.Drawing.Size(771, 303)
        Me.DataGridView1.TabIndex = 25
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btn_actualizar_Barras)
        Me.TabPage2.Controls.Add(Me.dgv_listado_barras)
        Me.TabPage2.Controls.Add(Me.btn_obtener_archivos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(783, 459)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Recepcion Informacion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btn_actualizar_Barras
        '
        Me.btn_actualizar_Barras.Location = New System.Drawing.Point(644, 62)
        Me.btn_actualizar_Barras.Name = "btn_actualizar_Barras"
        Me.btn_actualizar_Barras.Size = New System.Drawing.Size(119, 30)
        Me.btn_actualizar_Barras.TabIndex = 2
        Me.btn_actualizar_Barras.Text = "Actualizar"
        Me.btn_actualizar_Barras.UseVisualStyleBackColor = True
        '
        'dgv_listado_barras
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listado_barras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_listado_barras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_listado_barras.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_listado_barras.Location = New System.Drawing.Point(3, 98)
        Me.dgv_listado_barras.Name = "dgv_listado_barras"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listado_barras.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_listado_barras.Size = New System.Drawing.Size(774, 312)
        Me.dgv_listado_barras.TabIndex = 1
        '
        'btn_obtener_archivos
        '
        Me.btn_obtener_archivos.Location = New System.Drawing.Point(644, 6)
        Me.btn_obtener_archivos.Name = "btn_obtener_archivos"
        Me.btn_obtener_archivos.Size = New System.Drawing.Size(119, 41)
        Me.btn_obtener_archivos.TabIndex = 0
        Me.btn_obtener_archivos.Text = "Obtener Informacion"
        Me.btn_obtener_archivos.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.cmbEmpresa)
        Me.TabPage3.Controls.Add(Me.cmbBodega)
        Me.TabPage3.Controls.Add(Me.cmbConteos)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.dgv_conteo)
        Me.TabPage3.Controls.Add(Me.btn_enviar_Excel)
        Me.TabPage3.Controls.Add(Me.btn_obtener_informacion2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(783, 459)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Revision Inventarios"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(81, 5)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresa.TabIndex = 5
        '
        'cmbBodega
        '
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(81, 27)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(121, 21)
        Me.cmbBodega.TabIndex = 5
        '
        'cmbConteos
        '
        Me.cmbConteos.FormattingEnabled = True
        Me.cmbConteos.Location = New System.Drawing.Point(81, 50)
        Me.cmbConteos.Name = "cmbConteos"
        Me.cmbConteos.Size = New System.Drawing.Size(121, 21)
        Me.cmbConteos.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Empresa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Bodega"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Conteo"
        '
        'dgv_conteo
        '
        Me.dgv_conteo.AllowUserToAddRows = False
        Me.dgv_conteo.AllowUserToDeleteRows = False
        Me.dgv_conteo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_conteo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_conteo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_conteo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_conteo.Location = New System.Drawing.Point(3, 78)
        Me.dgv_conteo.Name = "dgv_conteo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_conteo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_conteo.RowHeadersWidth = 25
        Me.dgv_conteo.Size = New System.Drawing.Size(775, 366)
        Me.dgv_conteo.TabIndex = 2
        '
        'btn_enviar_Excel
        '
        Me.btn_enviar_Excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_enviar_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar_Excel.ForeColor = System.Drawing.Color.White
        Me.btn_enviar_Excel.Location = New System.Drawing.Point(613, 12)
        Me.btn_enviar_Excel.Name = "btn_enviar_Excel"
        Me.btn_enviar_Excel.Size = New System.Drawing.Size(119, 41)
        Me.btn_enviar_Excel.TabIndex = 1
        Me.btn_enviar_Excel.Text = "Enviar Excel"
        Me.btn_enviar_Excel.UseVisualStyleBackColor = False
        '
        'btn_obtener_informacion2
        '
        Me.btn_obtener_informacion2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_obtener_informacion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_obtener_informacion2.ForeColor = System.Drawing.Color.White
        Me.btn_obtener_informacion2.Location = New System.Drawing.Point(441, 12)
        Me.btn_obtener_informacion2.Name = "btn_obtener_informacion2"
        Me.btn_obtener_informacion2.Size = New System.Drawing.Size(119, 41)
        Me.btn_obtener_informacion2.TabIndex = 1
        Me.btn_obtener_informacion2.Text = "Obtener Informacion"
        Me.btn_obtener_informacion2.UseVisualStyleBackColor = False
        '
        'frm_inventarios_fisicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 491)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_inventarios_fisicos"
        Me.Text = ":: Inventarios Fisicos ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_listado_barras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_conteo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmb_operador1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_buscar6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_operador6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador_logico5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador_logico4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador_logico3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador_logico2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operador_logico1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents dgv_listado_barras As System.Windows.Forms.DataGridView
    Friend WithEvents btn_obtener_archivos As System.Windows.Forms.Button
    Friend WithEvents btn_actualizar_Barras As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_obtener_informacion2 As System.Windows.Forms.Button
    Friend WithEvents dgv_conteo As System.Windows.Forms.DataGridView
    Friend WithEvents btn_enviar_Excel As System.Windows.Forms.Button
    Friend WithEvents cmbConteos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
