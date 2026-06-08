<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_carga_presupuesto_comercial
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_carga_presupuesto_comercial))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.btn_obtener_excel = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.OFD_Productos = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tp_detalle = New System.Windows.Forms.TabPage()
        Me.dgv_log = New System.Windows.Forms.DataGridView()
        Me.tp_resumen = New System.Windows.Forms.TabPage()
        Me.dgv_resumen = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_periodo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_totalMercadeo = New System.Windows.Forms.Label()
        Me.lbl_TotalComercial = New System.Windows.Forms.Label()
        Me.lbl_diferencia = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Borra_x_Canal = New System.Windows.Forms.Button()
        Me.cb_Canal = New System.Windows.Forms.ComboBox()
        Me.cb_Periodo = New System.Windows.Forms.ComboBox()
        Me.l_canal = New System.Windows.Forms.Label()
        Me.l_periodo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Cancela = New System.Windows.Forms.Button()
        Me.bt_Borrar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_BuCancelar = New System.Windows.Forms.Button()
        Me.btn_Borrar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_BuPeriodo = New System.Windows.Forms.ComboBox()
        Me.cb_Bu = New System.Windows.Forms.ComboBox()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tp_detalle.SuspendLayout()
        CType(Me.dgv_log, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_resumen.SuspendLayout()
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalle.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_detalle.Location = New System.Drawing.Point(6, 6)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 25
        Me.dgv_detalle.Size = New System.Drawing.Size(842, 410)
        Me.dgv_detalle.TabIndex = 0
        '
        'btn_obtener_excel
        '
        Me.btn_obtener_excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_obtener_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_obtener_excel.ForeColor = System.Drawing.Color.White
        Me.btn_obtener_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_obtener_excel.ImageIndex = 1
        Me.btn_obtener_excel.ImageList = Me.ImageList1
        Me.btn_obtener_excel.Location = New System.Drawing.Point(222, 7)
        Me.btn_obtener_excel.Name = "btn_obtener_excel"
        Me.btn_obtener_excel.Size = New System.Drawing.Size(132, 52)
        Me.btn_obtener_excel.TabIndex = 1
        Me.btn_obtener_excel.Text = "Obtener Excel"
        Me.btn_obtener_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_obtener_excel.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "EXCEL.ICO")
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.ImageKey = "1286297068_Floppy-64.png"
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(360, 7)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(109, 52)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'OFD_Productos
        '
        Me.OFD_Productos.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tp_detalle)
        Me.TabControl1.Controls.Add(Me.tp_resumen)
        Me.TabControl1.Location = New System.Drawing.Point(4, 115)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(862, 522)
        Me.TabControl1.TabIndex = 2
        '
        'tp_detalle
        '
        Me.tp_detalle.Controls.Add(Me.dgv_log)
        Me.tp_detalle.Controls.Add(Me.dgv_detalle)
        Me.tp_detalle.Location = New System.Drawing.Point(4, 22)
        Me.tp_detalle.Name = "tp_detalle"
        Me.tp_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_detalle.Size = New System.Drawing.Size(854, 496)
        Me.tp_detalle.TabIndex = 0
        Me.tp_detalle.Text = "Detalle"
        Me.tp_detalle.UseVisualStyleBackColor = True
        '
        'dgv_log
        '
        Me.dgv_log.AllowUserToAddRows = False
        Me.dgv_log.AllowUserToDeleteRows = False
        Me.dgv_log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_log.Location = New System.Drawing.Point(6, 422)
        Me.dgv_log.Name = "dgv_log"
        Me.dgv_log.ReadOnly = True
        Me.dgv_log.RowHeadersWidth = 25
        Me.dgv_log.Size = New System.Drawing.Size(842, 68)
        Me.dgv_log.TabIndex = 3
        '
        'tp_resumen
        '
        Me.tp_resumen.Controls.Add(Me.dgv_resumen)
        Me.tp_resumen.Location = New System.Drawing.Point(4, 22)
        Me.tp_resumen.Name = "tp_resumen"
        Me.tp_resumen.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_resumen.Size = New System.Drawing.Size(854, 496)
        Me.tp_resumen.TabIndex = 1
        Me.tp_resumen.Text = "Resumen"
        Me.tp_resumen.UseVisualStyleBackColor = True
        '
        'dgv_resumen
        '
        Me.dgv_resumen.AllowUserToAddRows = False
        Me.dgv_resumen.AllowUserToDeleteRows = False
        Me.dgv_resumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_resumen.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_resumen.Location = New System.Drawing.Point(3, 6)
        Me.dgv_resumen.Name = "dgv_resumen"
        Me.dgv_resumen.ReadOnly = True
        Me.dgv_resumen.RowHeadersWidth = 25
        Me.dgv_resumen.Size = New System.Drawing.Size(845, 484)
        Me.dgv_resumen.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Periodo a Procesar"
        '
        'lbl_periodo
        '
        Me.lbl_periodo.AutoSize = True
        Me.lbl_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_periodo.Location = New System.Drawing.Point(129, 23)
        Me.lbl_periodo.Name = "lbl_periodo"
        Me.lbl_periodo.Size = New System.Drawing.Size(0, 13)
        Me.lbl_periodo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total Mercadeo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total Comercial"
        '
        'lbl_totalMercadeo
        '
        Me.lbl_totalMercadeo.Location = New System.Drawing.Point(115, 42)
        Me.lbl_totalMercadeo.Name = "lbl_totalMercadeo"
        Me.lbl_totalMercadeo.Size = New System.Drawing.Size(71, 13)
        Me.lbl_totalMercadeo.TabIndex = 3
        Me.lbl_totalMercadeo.Text = "0"
        Me.lbl_totalMercadeo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_TotalComercial
        '
        Me.lbl_TotalComercial.Location = New System.Drawing.Point(115, 58)
        Me.lbl_TotalComercial.Name = "lbl_TotalComercial"
        Me.lbl_TotalComercial.Size = New System.Drawing.Size(71, 13)
        Me.lbl_TotalComercial.TabIndex = 3
        Me.lbl_TotalComercial.Text = "0"
        Me.lbl_TotalComercial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_diferencia
        '
        Me.lbl_diferencia.Location = New System.Drawing.Point(115, 74)
        Me.lbl_diferencia.Name = "lbl_diferencia"
        Me.lbl_diferencia.Size = New System.Drawing.Size(71, 13)
        Me.lbl_diferencia.TabIndex = 3
        Me.lbl_diferencia.Text = "0"
        Me.lbl_diferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Diferencia"
        '
        'btn_Borra_x_Canal
        '
        Me.btn_Borra_x_Canal.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Borra_x_Canal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Borra_x_Canal.Location = New System.Drawing.Point(41, 19)
        Me.btn_Borra_x_Canal.Name = "btn_Borra_x_Canal"
        Me.btn_Borra_x_Canal.Size = New System.Drawing.Size(42, 23)
        Me.btn_Borra_x_Canal.TabIndex = 5
        Me.btn_Borra_x_Canal.Text = "OK"
        Me.btn_Borra_x_Canal.UseVisualStyleBackColor = False
        '
        'cb_Canal
        '
        Me.cb_Canal.FormattingEnabled = True
        Me.cb_Canal.Location = New System.Drawing.Point(56, 52)
        Me.cb_Canal.Name = "cb_Canal"
        Me.cb_Canal.Size = New System.Drawing.Size(154, 21)
        Me.cb_Canal.TabIndex = 6
        '
        'cb_Periodo
        '
        Me.cb_Periodo.FormattingEnabled = True
        Me.cb_Periodo.Location = New System.Drawing.Point(56, 78)
        Me.cb_Periodo.Name = "cb_Periodo"
        Me.cb_Periodo.Size = New System.Drawing.Size(72, 21)
        Me.cb_Periodo.TabIndex = 7
        '
        'l_canal
        '
        Me.l_canal.AutoSize = True
        Me.l_canal.Location = New System.Drawing.Point(6, 55)
        Me.l_canal.Name = "l_canal"
        Me.l_canal.Size = New System.Drawing.Size(37, 13)
        Me.l_canal.TabIndex = 8
        Me.l_canal.Text = "Canal:"
        '
        'l_periodo
        '
        Me.l_periodo.AutoSize = True
        Me.l_periodo.Location = New System.Drawing.Point(6, 81)
        Me.l_periodo.Name = "l_periodo"
        Me.l_periodo.Size = New System.Drawing.Size(46, 13)
        Me.l_periodo.TabIndex = 9
        Me.l_periodo.Text = "Periodo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Cancela)
        Me.GroupBox1.Controls.Add(Me.bt_Borrar)
        Me.GroupBox1.Controls.Add(Me.btn_Borra_x_Canal)
        Me.GroupBox1.Controls.Add(Me.l_periodo)
        Me.GroupBox1.Controls.Add(Me.cb_Canal)
        Me.GroupBox1.Controls.Add(Me.cb_Periodo)
        Me.GroupBox1.Controls.Add(Me.l_canal)
        Me.GroupBox1.Location = New System.Drawing.Point(480, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 106)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Borra X Canal"
        '
        'btn_Cancela
        '
        Me.btn_Cancela.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancela.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Cancela.Location = New System.Drawing.Point(89, 19)
        Me.btn_Cancela.Name = "btn_Cancela"
        Me.btn_Cancela.Size = New System.Drawing.Size(59, 23)
        Me.btn_Cancela.TabIndex = 11
        Me.btn_Cancela.Text = "Cancelar"
        Me.btn_Cancela.UseVisualStyleBackColor = False
        '
        'bt_Borrar
        '
        Me.bt_Borrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.bt_Borrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bt_Borrar.Location = New System.Drawing.Point(154, 19)
        Me.bt_Borrar.Name = "bt_Borrar"
        Me.bt_Borrar.Size = New System.Drawing.Size(57, 23)
        Me.bt_Borrar.TabIndex = 11
        Me.bt_Borrar.Text = "Borrar"
        Me.bt_Borrar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_BuCancelar)
        Me.GroupBox2.Controls.Add(Me.btn_Borrar)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cb_BuPeriodo)
        Me.GroupBox2.Controls.Add(Me.cb_Bu)
        Me.GroupBox2.Location = New System.Drawing.Point(705, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(168, 106)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Borra X Bu"
        '
        'btn_BuCancelar
        '
        Me.btn_BuCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_BuCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_BuCancelar.Location = New System.Drawing.Point(5, 74)
        Me.btn_BuCancelar.Name = "btn_BuCancelar"
        Me.btn_BuCancelar.Size = New System.Drawing.Size(76, 26)
        Me.btn_BuCancelar.TabIndex = 4
        Me.btn_BuCancelar.Text = "Cancelar"
        Me.btn_BuCancelar.UseVisualStyleBackColor = False
        '
        'btn_Borrar
        '
        Me.btn_Borrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Borrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Borrar.Location = New System.Drawing.Point(82, 74)
        Me.btn_Borrar.Name = "btn_Borrar"
        Me.btn_Borrar.Size = New System.Drawing.Size(80, 26)
        Me.btn_Borrar.TabIndex = 3
        Me.btn_Borrar.Text = "Borra"
        Me.btn_Borrar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Periodo"
        '
        'cb_BuPeriodo
        '
        Me.cb_BuPeriodo.FormattingEnabled = True
        Me.cb_BuPeriodo.Location = New System.Drawing.Point(56, 42)
        Me.cb_BuPeriodo.Name = "cb_BuPeriodo"
        Me.cb_BuPeriodo.Size = New System.Drawing.Size(106, 21)
        Me.cb_BuPeriodo.TabIndex = 1
        '
        'cb_Bu
        '
        Me.cb_Bu.FormattingEnabled = True
        Me.cb_Bu.Location = New System.Drawing.Point(12, 17)
        Me.cb_Bu.Name = "cb_Bu"
        Me.cb_Bu.Size = New System.Drawing.Size(150, 21)
        Me.cb_Bu.TabIndex = 0
        '
        'frm_carga_presupuesto_comercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(878, 640)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_periodo)
        Me.Controls.Add(Me.lbl_diferencia)
        Me.Controls.Add(Me.lbl_TotalComercial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_totalMercadeo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_obtener_excel)
        Me.Name = "frm_carga_presupuesto_comercial"
        Me.Text = ":: Carga de Presupuesto Comercial ::"
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tp_detalle.ResumeLayout(False)
        CType(Me.dgv_log, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_resumen.ResumeLayout(False)
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_obtener_excel As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents OFD_Productos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tp_detalle As System.Windows.Forms.TabPage
    Friend WithEvents tp_resumen As System.Windows.Forms.TabPage
    Friend WithEvents dgv_log As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_resumen As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_periodo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_totalMercadeo As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalComercial As System.Windows.Forms.Label
    Friend WithEvents lbl_diferencia As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_Borra_x_Canal As System.Windows.Forms.Button
    Friend WithEvents cb_Canal As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Periodo As System.Windows.Forms.ComboBox
    Friend WithEvents l_canal As System.Windows.Forms.Label
    Friend WithEvents l_periodo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_Borrar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancela As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Borrar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_BuPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Bu As System.Windows.Forms.ComboBox
    Friend WithEvents btn_BuCancelar As System.Windows.Forms.Button
End Class
