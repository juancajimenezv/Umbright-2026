<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_da_SolicitudReserva
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_pedido))
        Me.dgvProductosAsociados = New System.Windows.Forms.DataGridView
        Me.dgvDuas = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_texto = New System.Windows.Forms.TextBox
        Me.cmb_operadores = New System.Windows.Forms.ComboBox
        Me.cmb_campos = New System.Windows.Forms.ComboBox
        Me.chkVerTodos = New System.Windows.Forms.CheckBox
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InmovilizarPanelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MovilizarPanelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_propuesta = New System.Windows.Forms.Button
        Me.lblFechaIngreso = New System.Windows.Forms.Label
        CType(Me.dgvProductosAsociados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDuas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProductosAsociados
        '
        Me.dgvProductosAsociados.AllowUserToAddRows = False
        Me.dgvProductosAsociados.AllowUserToDeleteRows = False
        Me.dgvProductosAsociados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductosAsociados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductosAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductosAsociados.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductosAsociados.Location = New System.Drawing.Point(573, 75)
        Me.dgvProductosAsociados.Name = "dgvProductosAsociados"
        Me.dgvProductosAsociados.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductosAsociados.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductosAsociados.RowHeadersWidth = 20
        Me.dgvProductosAsociados.Size = New System.Drawing.Size(368, 238)
        Me.dgvProductosAsociados.TabIndex = 23
        '
        'dgvDuas
        '
        Me.dgvDuas.AllowUserToAddRows = False
        Me.dgvDuas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDuas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDuas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDuas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDuas.Location = New System.Drawing.Point(2, 319)
        Me.dgvDuas.Name = "dgvDuas"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDuas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDuas.RowHeadersWidth = 20
        Me.dgvDuas.Size = New System.Drawing.Size(939, 193)
        Me.dgvDuas.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_texto)
        Me.GroupBox1.Controls.Add(Me.cmb_operadores)
        Me.GroupBox1.Controls.Add(Me.cmb_campos)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 40)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'txt_texto
        '
        Me.txt_texto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_texto.Location = New System.Drawing.Point(220, 11)
        Me.txt_texto.Name = "txt_texto"
        Me.txt_texto.Size = New System.Drawing.Size(276, 20)
        Me.txt_texto.TabIndex = 17
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DisplayMember = "like"
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_operadores.FormattingEnabled = True
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(151, 11)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(65, 21)
        Me.cmb_operadores.TabIndex = 16
        Me.cmb_operadores.ValueMember = "like"
        '
        'cmb_campos
        '
        Me.cmb_campos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_campos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_campos.FormattingEnabled = True
        Me.cmb_campos.Items.AddRange(New Object() {"producto", "glosa", "proveedor", "marca"})
        Me.cmb_campos.Location = New System.Drawing.Point(6, 11)
        Me.cmb_campos.Name = "cmb_campos"
        Me.cmb_campos.Size = New System.Drawing.Size(140, 21)
        Me.cmb_campos.TabIndex = 15
        '
        'chkVerTodos
        '
        Me.chkVerTodos.AutoSize = True
        Me.chkVerTodos.Location = New System.Drawing.Point(8, 52)
        Me.chkVerTodos.Name = "chkVerTodos"
        Me.chkVerTodos.Size = New System.Drawing.Size(75, 17)
        Me.chkVerTodos.TabIndex = 20
        Me.chkVerTodos.Text = "Ver Todos"
        Me.chkVerTodos.UseVisualStyleBackColor = True
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalle.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_detalle.Location = New System.Drawing.Point(2, 75)
        Me.dgv_detalle.Name = "dgv_detalle"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_detalle.RowHeadersWidth = 25
        Me.dgv_detalle.Size = New System.Drawing.Size(565, 238)
        Me.dgv_detalle.TabIndex = 19
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InmovilizarPanelesToolStripMenuItem, Me.MovilizarPanelesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 48)
        '
        'InmovilizarPanelesToolStripMenuItem
        '
        Me.InmovilizarPanelesToolStripMenuItem.Name = "InmovilizarPanelesToolStripMenuItem"
        Me.InmovilizarPanelesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.InmovilizarPanelesToolStripMenuItem.Text = "InmovilizarPaneles"
        '
        'MovilizarPanelesToolStripMenuItem
        '
        Me.MovilizarPanelesToolStripMenuItem.Name = "MovilizarPanelesToolStripMenuItem"
        Me.MovilizarPanelesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.MovilizarPanelesToolStripMenuItem.Text = "MovilizarPaneles"
        '
        'btn_generar
        '
        Me.btn_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(675, 5)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 64)
        Me.btn_generar.TabIndex = 17
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "finder.png")
        Me.ImageList1.Images.SetKeyName(1, "engranaje1.png")
        '
        'btn_propuesta
        '
        Me.btn_propuesta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_propuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_propuesta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_propuesta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_propuesta.ForeColor = System.Drawing.Color.White
        Me.btn_propuesta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_propuesta.ImageIndex = 1
        Me.btn_propuesta.ImageList = Me.ImageList1
        Me.btn_propuesta.Location = New System.Drawing.Point(756, 5)
        Me.btn_propuesta.Name = "btn_propuesta"
        Me.btn_propuesta.Size = New System.Drawing.Size(75, 64)
        Me.btn_propuesta.TabIndex = 18
        Me.btn_propuesta.Text = "Procesar"
        Me.btn_propuesta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_propuesta.UseVisualStyleBackColor = False
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIngreso.Location = New System.Drawing.Point(165, 56)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaIngreso.TabIndex = 24
        '
        'frm_int_Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(942, 509)
        Me.Controls.Add(Me.lblFechaIngreso)
        Me.Controls.Add(Me.dgvDuas)
        Me.Controls.Add(Me.dgvProductosAsociados)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkVerTodos)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.btn_propuesta)
        Me.Name = "frm_int_Pedido"
        Me.Text = ":: Internacion - Solicitud de Pedido ::"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProductosAsociados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDuas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProductosAsociados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDuas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_texto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents chkVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents btn_propuesta As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InmovilizarPanelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovilizarPanelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblFechaIngreso As System.Windows.Forms.Label
End Class
