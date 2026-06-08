<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MonitorMaquila
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelBaseProduccion = New System.Windows.Forms.Panel()
        Me.PanelRellenoProduccion = New System.Windows.Forms.Panel()
        Me.txt_estadisticas_producido = New System.Windows.Forms.TextBox()
        Me.dgv_OPAvance = New System.Windows.Forms.DataGridView()
        Me.dgv_OPProducto = New System.Windows.Forms.DataGridView()
        Me.gtnGenerar = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelBaseProduccion.SuspendLayout()
        CType(Me.dgv_OPAvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_OPProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(945, 614)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PanelBaseProduccion)
        Me.TabPage1.Controls.Add(Me.txt_estadisticas_producido)
        Me.TabPage1.Controls.Add(Me.dgv_OPAvance)
        Me.TabPage1.Controls.Add(Me.dgv_OPProducto)
        Me.TabPage1.Controls.Add(Me.gtnGenerar)
        Me.TabPage1.Controls.Add(Me.DateTimePicker2)
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.dgvListado)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(937, 588)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Packs"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(879, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Avance"
        '
        'PanelBaseProduccion
        '
        Me.PanelBaseProduccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBaseProduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelBaseProduccion.Controls.Add(Me.PanelRellenoProduccion)
        Me.PanelBaseProduccion.Location = New System.Drawing.Point(866, 101)
        Me.PanelBaseProduccion.Name = "PanelBaseProduccion"
        Me.PanelBaseProduccion.Size = New System.Drawing.Size(68, 290)
        Me.PanelBaseProduccion.TabIndex = 14
        '
        'PanelRellenoProduccion
        '
        Me.PanelRellenoProduccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRellenoProduccion.BackColor = System.Drawing.Color.Lime
        Me.PanelRellenoProduccion.Location = New System.Drawing.Point(0, 154)
        Me.PanelRellenoProduccion.Name = "PanelRellenoProduccion"
        Me.PanelRellenoProduccion.Size = New System.Drawing.Size(68, 136)
        Me.PanelRellenoProduccion.TabIndex = 13
        '
        'txt_estadisticas_producido
        '
        Me.txt_estadisticas_producido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_estadisticas_producido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_estadisticas_producido.Location = New System.Drawing.Point(879, 80)
        Me.txt_estadisticas_producido.Name = "txt_estadisticas_producido"
        Me.txt_estadisticas_producido.Size = New System.Drawing.Size(48, 20)
        Me.txt_estadisticas_producido.TabIndex = 13
        Me.txt_estadisticas_producido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_OPAvance
        '
        Me.dgv_OPAvance.AllowUserToAddRows = False
        Me.dgv_OPAvance.AllowUserToDeleteRows = False
        Me.dgv_OPAvance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_OPAvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_OPAvance.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_OPAvance.Location = New System.Drawing.Point(8, 410)
        Me.dgv_OPAvance.Name = "dgv_OPAvance"
        Me.dgv_OPAvance.RowHeadersVisible = False
        Me.dgv_OPAvance.Size = New System.Drawing.Size(297, 175)
        Me.dgv_OPAvance.TabIndex = 3
        '
        'dgv_OPProducto
        '
        Me.dgv_OPProducto.AllowUserToAddRows = False
        Me.dgv_OPProducto.AllowUserToDeleteRows = False
        Me.dgv_OPProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_OPProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_OPProducto.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_OPProducto.Location = New System.Drawing.Point(321, 410)
        Me.dgv_OPProducto.Name = "dgv_OPProducto"
        Me.dgv_OPProducto.RowHeadersVisible = False
        Me.dgv_OPProducto.Size = New System.Drawing.Size(610, 175)
        Me.dgv_OPProducto.TabIndex = 3
        '
        'gtnGenerar
        '
        Me.gtnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.gtnGenerar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gtnGenerar.ForeColor = System.Drawing.Color.White
        Me.gtnGenerar.Location = New System.Drawing.Point(313, 1)
        Me.gtnGenerar.Name = "gtnGenerar"
        Me.gtnGenerar.Size = New System.Drawing.Size(75, 57)
        Me.gtnGenerar.TabIndex = 2
        Me.gtnGenerar.Text = "Generar"
        Me.gtnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.gtnGenerar.UseVisualStyleBackColor = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(94, 32)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(85, 20)
        Me.DateTimePicker2.TabIndex = 1
        Me.DateTimePicker2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(94, 6)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(85, 20)
        Me.DateTimePicker1.TabIndex = 1
        Me.DateTimePicker1.Visible = False
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListado.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListado.Location = New System.Drawing.Point(6, 58)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 20
        Me.dgvListado.Size = New System.Drawing.Size(854, 333)
        Me.dgvListado.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(318, 394)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Armado Packs Historico"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Proceso de Este Pack"
        '
        'frm_MonitorMaquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 614)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_MonitorMaquila"
        Me.Text = ".::. Monitor de Maquila .::."
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelBaseProduccion.ResumeLayout(False)
        CType(Me.dgv_OPAvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_OPProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents gtnGenerar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_OPAvance As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_OPProducto As System.Windows.Forms.DataGridView
    Friend WithEvents PanelBaseProduccion As System.Windows.Forms.Panel
    Friend WithEvents PanelRellenoProduccion As System.Windows.Forms.Panel
    Friend WithEvents txt_estadisticas_producido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
