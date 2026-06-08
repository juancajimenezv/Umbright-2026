<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_presupuesto_multiple_producto_cliente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_presupuesto_multiple_producto_cliente))
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.lbl_descripcion = New System.Windows.Forms.Label()
        Me.dg_productos = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitarFiltrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_presupuesto = New System.Windows.Forms.Label()
        Me.lbl_periodo = New System.Windows.Forms.Label()
        Me.btn_aplicar_estadisticas = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg_resumen = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_AplicarSugerido = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_actualizar = New System.Windows.Forms.Button()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_codigo.Location = New System.Drawing.Point(6, 16)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(50, 14)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "lblCodigo"
        '
        'lbl_descripcion
        '
        Me.lbl_descripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descripcion.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_descripcion.Location = New System.Drawing.Point(76, 16)
        Me.lbl_descripcion.Name = "lbl_descripcion"
        Me.lbl_descripcion.Size = New System.Drawing.Size(270, 13)
        Me.lbl_descripcion.TabIndex = 1
        Me.lbl_descripcion.Text = "lbldescripcion"
        '
        'dg_productos
        '
        Me.dg_productos.AllowUserToOrderColumns = True
        Me.dg_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_productos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg_productos.Location = New System.Drawing.Point(2, 168)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.RowHeadersWidth = 25
        Me.dg_productos.Size = New System.Drawing.Size(999, 441)
        Me.dg_productos.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarFiltrarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 26)
        '
        'QuitarFiltrarToolStripMenuItem
        '
        Me.QuitarFiltrarToolStripMenuItem.Name = "QuitarFiltrarToolStripMenuItem"
        Me.QuitarFiltrarToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.QuitarFiltrarToolStripMenuItem.Text = "Quitar Filtrar"
        '
        'lbl_presupuesto
        '
        Me.lbl_presupuesto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_presupuesto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_presupuesto.Location = New System.Drawing.Point(6, 16)
        Me.lbl_presupuesto.Name = "lbl_presupuesto"
        Me.lbl_presupuesto.Size = New System.Drawing.Size(86, 13)
        Me.lbl_presupuesto.TabIndex = 3
        Me.lbl_presupuesto.Text = "lblpresupuestoMerc"
        '
        'lbl_periodo
        '
        Me.lbl_periodo.AutoSize = True
        Me.lbl_periodo.Location = New System.Drawing.Point(68, 0)
        Me.lbl_periodo.Name = "lbl_periodo"
        Me.lbl_periodo.Size = New System.Drawing.Size(53, 14)
        Me.lbl_periodo.TabIndex = 4
        Me.lbl_periodo.Text = "lblPeriodo"
        '
        'btn_aplicar_estadisticas
        '
        Me.btn_aplicar_estadisticas.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_aplicar_estadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_aplicar_estadisticas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar_estadisticas.ForeColor = System.Drawing.Color.White
        Me.btn_aplicar_estadisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aplicar_estadisticas.ImageIndex = 2
        Me.btn_aplicar_estadisticas.ImageList = Me.ImageList1
        Me.btn_aplicar_estadisticas.Location = New System.Drawing.Point(505, 1)
        Me.btn_aplicar_estadisticas.Name = "btn_aplicar_estadisticas"
        Me.btn_aplicar_estadisticas.Size = New System.Drawing.Size(110, 41)
        Me.btn_aplicar_estadisticas.TabIndex = 6
        Me.btn_aplicar_estadisticas.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Estadisticas"
        Me.btn_aplicar_estadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aplicar_estadisticas.UseVisualStyleBackColor = False
        Me.btn_aplicar_estadisticas.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "save.ico")
        Me.ImageList1.Images.SetKeyName(1, "accept.ico")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(924, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(924, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'dg_resumen
        '
        Me.dg_resumen.AllowUserToAddRows = False
        Me.dg_resumen.AllowUserToDeleteRows = False
        Me.dg_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_resumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dg_resumen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dg_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_resumen.Location = New System.Drawing.Point(2, 44)
        Me.dg_resumen.Name = "dg_resumen"
        Me.dg_resumen.RowHeadersWidth = 25
        Me.dg_resumen.Size = New System.Drawing.Size(999, 118)
        Me.dg_resumen.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_codigo)
        Me.GroupBox1.Controls.Add(Me.lbl_descripcion)
        Me.GroupBox1.Controls.Add(Me.lbl_periodo)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 37)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_presupuesto)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(360, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(98, 37)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ppto Mercadeo"
        '
        'btn_AplicarSugerido
        '
        Me.btn_AplicarSugerido.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_AplicarSugerido.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_AplicarSugerido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AplicarSugerido.ForeColor = System.Drawing.Color.White
        Me.btn_AplicarSugerido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AplicarSugerido.ImageIndex = 1
        Me.btn_AplicarSugerido.ImageList = Me.ImageList1
        Me.btn_AplicarSugerido.Location = New System.Drawing.Point(621, 1)
        Me.btn_AplicarSugerido.Name = "btn_AplicarSugerido"
        Me.btn_AplicarSugerido.Size = New System.Drawing.Size(93, 41)
        Me.btn_AplicarSugerido.TabIndex = 6
        Me.btn_AplicarSugerido.Text = "Aplicar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sugerido"
        Me.btn_AplicarSugerido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AplicarSugerido.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(720, 1)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(93, 41)
        Me.btn_guardar.TabIndex = 6
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = False
        Me.btn_guardar.Visible = False
        '
        'btn_actualizar
        '
        Me.btn_actualizar.BackColor = System.Drawing.Color.LightCyan
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_actualizar.ImageIndex = 0
        Me.btn_actualizar.Location = New System.Drawing.Point(819, 1)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(93, 41)
        Me.btn_actualizar.TabIndex = 6
        Me.btn_actualizar.Text = "Guardar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_actualizar.UseVisualStyleBackColor = False
        Me.btn_actualizar.Visible = False
        '
        'frm_presupuesto_multiple_producto_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1005, 612)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_resumen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_productos)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.btn_AplicarSugerido)
        Me.Controls.Add(Me.btn_aplicar_estadisticas)
        Me.Name = "frm_presupuesto_multiple_producto_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Presupuesto Producto Cliente .::"
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents lbl_descripcion As System.Windows.Forms.Label
    Friend WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_presupuesto As System.Windows.Forms.Label
    Friend WithEvents lbl_periodo As System.Windows.Forms.Label
    Friend WithEvents btn_aplicar_estadisticas As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg_resumen As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_AplicarSugerido As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QuitarFiltrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
End Class
