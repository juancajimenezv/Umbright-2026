<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_int_ListadoInternaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_ListadoInternaciones))
        Me.dg_detalle = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_ayuda = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btnExportarListado = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.btn_editar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_comentarios = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbEstadoReal = New System.Windows.Forms.ComboBox
        Me.dgv_internaciones = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarComentarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerTrackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_internaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_detalle
        '
        Me.dg_detalle.AllowUserToAddRows = False
        Me.dg_detalle.AllowUserToDeleteRows = False
        Me.dg_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_detalle.Location = New System.Drawing.Point(0, 379)
        Me.dg_detalle.Name = "dg_detalle"
        Me.dg_detalle.ReadOnly = True
        Me.dg_detalle.RowHeadersVisible = False
        Me.dg_detalle.RowHeadersWidth = 25
        Me.dg_detalle.Size = New System.Drawing.Size(1026, 209)
        Me.dg_detalle.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.btn_ayuda)
        Me.GroupBox2.Controls.Add(Me.btn_actualizar)
        Me.GroupBox2.Controls.Add(Me.btn_imprimir)
        Me.GroupBox2.Controls.Add(Me.btnExportarListado)
        Me.GroupBox2.Controls.Add(Me.btn_exportar)
        Me.GroupBox2.Controls.Add(Me.btn_editar)
        Me.GroupBox2.Location = New System.Drawing.Point(506, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(495, 84)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'btn_ayuda
        '
        Me.btn_ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.ImageIndex = 6
        Me.btn_ayuda.ImageList = Me.ImageList1
        Me.btn_ayuda.Location = New System.Drawing.Point(413, 12)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(75, 64)
        Me.btn_ayuda.TabIndex = 15
        Me.btn_ayuda.Text = "Ayuda"
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "help.ico")
        Me.ImageList1.Images.SetKeyName(7, "EXCEL.ICO")
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 3
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(332, 12)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 64)
        Me.btn_actualizar.TabIndex = 2
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_actualizar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 0
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(89, 12)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(75, 64)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btnExportarListado
        '
        Me.btnExportarListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportarListado.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnExportarListado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportarListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarListado.ForeColor = System.Drawing.Color.White
        Me.btnExportarListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarListado.ImageIndex = 7
        Me.btnExportarListado.ImageList = Me.ImageList1
        Me.btnExportarListado.Location = New System.Drawing.Point(8, 12)
        Me.btnExportarListado.Name = "btnExportarListado"
        Me.btnExportarListado.Size = New System.Drawing.Size(75, 64)
        Me.btnExportarListado.TabIndex = 2
        Me.btnExportarListado.Text = "Exportar Listado"
        Me.btnExportarListado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarListado.UseVisualStyleBackColor = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(170, 12)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 64)
        Me.btn_exportar.TabIndex = 2
        Me.btn_exportar.Text = "Exportar Pedido"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'btn_editar
        '
        Me.btn_editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_editar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_editar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.ForeColor = System.Drawing.Color.White
        Me.btn_editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_editar.ImageIndex = 5
        Me.btn_editar.ImageList = Me.ImageList1
        Me.btn_editar.Location = New System.Drawing.Point(251, 12)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(75, 64)
        Me.btn_editar.TabIndex = 2
        Me.btn_editar.Text = "Ver DI"
        Me.btn_editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_editar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_comentarios)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbEstadoReal)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 75)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(392, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Ver Todos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAplicar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAplicar.ImageIndex = 3
        Me.btnAplicar.Location = New System.Drawing.Point(277, 39)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(70, 21)
        Me.btnAplicar.TabIndex = 2
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Comentarios"
        '
        'txt_comentarios
        '
        Me.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios.Location = New System.Drawing.Point(81, 13)
        Me.txt_comentarios.Name = "txt_comentarios"
        Me.txt_comentarios.Size = New System.Drawing.Size(409, 20)
        Me.txt_comentarios.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Estado"
        '
        'cmbEstadoReal
        '
        Me.cmbEstadoReal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoReal.DropDownWidth = 160
        Me.cmbEstadoReal.Location = New System.Drawing.Point(81, 42)
        Me.cmbEstadoReal.Name = "cmbEstadoReal"
        Me.cmbEstadoReal.Size = New System.Drawing.Size(180, 21)
        Me.cmbEstadoReal.TabIndex = 5
        '
        'dgv_internaciones
        '
        Me.dgv_internaciones.AllowUserToAddRows = False
        Me.dgv_internaciones.AllowUserToDeleteRows = False
        Me.dgv_internaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_internaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_internaciones.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_internaciones.Location = New System.Drawing.Point(0, 88)
        Me.dgv_internaciones.Name = "dgv_internaciones"
        Me.dgv_internaciones.ReadOnly = True
        Me.dgv_internaciones.RowHeadersWidth = 25
        Me.dgv_internaciones.Size = New System.Drawing.Size(1026, 285)
        Me.dgv_internaciones.TabIndex = 11
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarComentarioToolStripMenuItem, Me.VerTrackingToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(183, 48)
        Me.ContextMenuStrip1.Text = "Agregar Comentario"
        '
        'AgregarComentarioToolStripMenuItem
        '
        Me.AgregarComentarioToolStripMenuItem.Name = "AgregarComentarioToolStripMenuItem"
        Me.AgregarComentarioToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.AgregarComentarioToolStripMenuItem.Text = "Agregar Comentario"
        '
        'VerTrackingToolStripMenuItem
        '
        Me.VerTrackingToolStripMenuItem.Name = "VerTrackingToolStripMenuItem"
        Me.VerTrackingToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.VerTrackingToolStripMenuItem.Text = "Ver Tracking"
        '
        'frm_int_ListadoInternaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 589)
        Me.Controls.Add(Me.dg_detalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_internaciones)
        Me.Name = "frm_int_ListadoInternaciones"
        Me.Text = ":: Listado de Internaciones ::"
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_internaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents dgv_internaciones As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoReal As System.Windows.Forms.ComboBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarComentarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerTrackingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents btnExportarListado As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
