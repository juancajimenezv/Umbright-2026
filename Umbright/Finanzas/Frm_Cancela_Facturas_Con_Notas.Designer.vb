<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cancela_Facturas_Con_Notas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cancela_Facturas_Con_Notas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Ejecuta = New System.Windows.Forms.Button()
        Me.cb_Grupo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_BuscaNumero = New System.Windows.Forms.TextBox()
        Me.dgv_Facturas = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_Cancelacion = New System.Windows.Forms.DataGridView()
        Me.cb_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tb_Nuevo = New System.Windows.Forms.Button()
        Me.lb_Monto = New System.Windows.Forms.Label()
        Me.lb_Cliente = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lb_Saldo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Cancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtp_Fecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_Ejecuta)
        Me.GroupBox1.Controls.Add(Me.cb_Grupo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generar Información"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha.Location = New System.Drawing.Point(261, 26)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(89, 20)
        Me.dtp_Fecha.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Grupo:"
        '
        'btn_Ejecuta
        '
        Me.btn_Ejecuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Ejecuta.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.btn_Ejecuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Ejecuta.Location = New System.Drawing.Point(356, 24)
        Me.btn_Ejecuta.Name = "btn_Ejecuta"
        Me.btn_Ejecuta.Size = New System.Drawing.Size(75, 23)
        Me.btn_Ejecuta.TabIndex = 20
        Me.btn_Ejecuta.Text = "Ejecuta"
        Me.btn_Ejecuta.UseVisualStyleBackColor = False
        '
        'cb_Grupo
        '
        Me.cb_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Grupo.FormattingEnabled = True
        Me.cb_Grupo.Items.AddRange(New Object() {"", "UNISUPER", "VINOTECA", "WALMART", "PRICESMART"})
        Me.cb_Grupo.Location = New System.Drawing.Point(64, 26)
        Me.cb_Grupo.Name = "cb_Grupo"
        Me.cb_Grupo.Size = New System.Drawing.Size(191, 21)
        Me.cb_Grupo.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tb_BuscaNumero)
        Me.GroupBox2.Controls.Add(Me.dgv_Facturas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(729, 167)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Notas de Credito"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Numero:"
        '
        'tb_BuscaNumero
        '
        Me.tb_BuscaNumero.Location = New System.Drawing.Point(16, 58)
        Me.tb_BuscaNumero.Name = "tb_BuscaNumero"
        Me.tb_BuscaNumero.Size = New System.Drawing.Size(100, 20)
        Me.tb_BuscaNumero.TabIndex = 9
        '
        'dgv_Facturas
        '
        Me.dgv_Facturas.AllowUserToAddRows = False
        Me.dgv_Facturas.AllowUserToDeleteRows = False
        Me.dgv_Facturas.AllowUserToOrderColumns = True
        Me.dgv_Facturas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Facturas.Location = New System.Drawing.Point(128, 15)
        Me.dgv_Facturas.Name = "dgv_Facturas"
        Me.dgv_Facturas.ReadOnly = True
        Me.dgv_Facturas.Size = New System.Drawing.Size(595, 145)
        Me.dgv_Facturas.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dgv_Cancelacion)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 318)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(729, 157)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cancelación"
        '
        'dgv_Cancelacion
        '
        Me.dgv_Cancelacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Cancelacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Cancelacion.Location = New System.Drawing.Point(6, 14)
        Me.dgv_Cancelacion.Name = "dgv_Cancelacion"
        Me.dgv_Cancelacion.Size = New System.Drawing.Size(717, 137)
        Me.dgv_Cancelacion.TabIndex = 0
        '
        'cb_TipoDocto
        '
        Me.cb_TipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoDocto.FormattingEnabled = True
        Me.cb_TipoDocto.Location = New System.Drawing.Point(98, 23)
        Me.cb_TipoDocto.Name = "cb_TipoDocto"
        Me.cb_TipoDocto.Size = New System.Drawing.Size(173, 21)
        Me.cb_TipoDocto.TabIndex = 3
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(343, 23)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(100, 20)
        Me.tb_Numero.TabIndex = 4
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.cb_TipoDocto)
        Me.GroupBox4.Controls.Add(Me.tb_Numero)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(454, 58)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Factura"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo Documento"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Controls.Add(Me.tb_Nuevo)
        Me.GroupBox5.Controls.Add(Me.lb_Monto)
        Me.GroupBox5.Controls.Add(Me.lb_Cliente)
        Me.GroupBox5.Location = New System.Drawing.Point(472, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(269, 127)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 89)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'tb_Nuevo
        '
        Me.tb_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.tb_Nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_Nuevo.Location = New System.Drawing.Point(100, 91)
        Me.tb_Nuevo.Name = "tb_Nuevo"
        Me.tb_Nuevo.Size = New System.Drawing.Size(148, 23)
        Me.tb_Nuevo.TabIndex = 2
        Me.tb_Nuevo.Text = "Nuevo"
        Me.tb_Nuevo.UseVisualStyleBackColor = False
        '
        'lb_Monto
        '
        Me.lb_Monto.AutoSize = True
        Me.lb_Monto.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Monto.Location = New System.Drawing.Point(13, 45)
        Me.lb_Monto.Name = "lb_Monto"
        Me.lb_Monto.Size = New System.Drawing.Size(34, 13)
        Me.lb_Monto.TabIndex = 1
        Me.lb_Monto.Text = "Saldo"
        '
        'lb_Cliente
        '
        Me.lb_Cliente.AutoSize = True
        Me.lb_Cliente.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Cliente.Location = New System.Drawing.Point(13, 19)
        Me.lb_Cliente.Name = "lb_Cliente"
        Me.lb_Cliente.Size = New System.Drawing.Size(39, 13)
        Me.lb_Cliente.TabIndex = 0
        Me.lb_Cliente.Text = "Cliente"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lb_Saldo
        '
        Me.lb_Saldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_Saldo.AutoSize = True
        Me.lb_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Saldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lb_Saldo.Location = New System.Drawing.Point(569, 489)
        Me.lb_Saldo.Name = "lb_Saldo"
        Me.lb_Saldo.Size = New System.Drawing.Size(44, 20)
        Me.lb_Saldo.TabIndex = 7
        Me.lb_Saldo.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(404, 490)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Saldo ===========>"
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Actualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Actualiza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Actualiza.Location = New System.Drawing.Point(12, 490)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(237, 23)
        Me.btn_Actualiza.TabIndex = 9
        Me.btn_Actualiza.Text = "Actualiza a Contabilidad"
        Me.btn_Actualiza.UseVisualStyleBackColor = False
        '
        'Frm_Cancela_Facturas_Con_Notas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(753, 520)
        Me.Controls.Add(Me.btn_Actualiza)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lb_Saldo)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Cancela_Facturas_Con_Notas"
        Me.Text = "Cancela Facturas Con Notas De Crédito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_Cancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Ejecuta As System.Windows.Forms.Button
    Friend WithEvents cb_Grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Facturas As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_TipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_Monto As System.Windows.Forms.Label
    Friend WithEvents lb_Cliente As System.Windows.Forms.Label
    Friend WithEvents tb_Nuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgv_Cancelacion As System.Windows.Forms.DataGridView
    Friend WithEvents lb_Saldo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_BuscaNumero As System.Windows.Forms.TextBox
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
End Class
