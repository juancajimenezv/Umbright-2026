<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_int_listado
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dg_detalle_dua = New System.Windows.Forms.DataGridView
        Me.dg_detalle = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.btn_editar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_comentarios = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_estados = New System.Windows.Forms.ComboBox
        Me.dg_internaciones = New System.Windows.Forms.DataGridView
        CType(Me.dg_detalle_dua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_internaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_detalle_dua
        '
        Me.dg_detalle_dua.AllowUserToAddRows = False
        Me.dg_detalle_dua.AllowUserToDeleteRows = False
        Me.dg_detalle_dua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_detalle_dua.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg_detalle_dua.Location = New System.Drawing.Point(539, 329)
        Me.dg_detalle_dua.Name = "dg_detalle_dua"
        Me.dg_detalle_dua.ReadOnly = True
        Me.dg_detalle_dua.RowHeadersWidth = 25
        Me.dg_detalle_dua.Size = New System.Drawing.Size(536, 246)
        Me.dg_detalle_dua.TabIndex = 21
        '
        'dg_detalle
        '
        Me.dg_detalle.AllowUserToAddRows = False
        Me.dg_detalle.AllowUserToDeleteRows = False
        Me.dg_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_detalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_detalle.Location = New System.Drawing.Point(1, 329)
        Me.dg_detalle.Name = "dg_detalle"
        Me.dg_detalle.ReadOnly = True
        Me.dg_detalle.RowHeadersWidth = 25
        Me.dg_detalle.Size = New System.Drawing.Size(520, 246)
        Me.dg_detalle.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.btn_actualizar)
        Me.GroupBox2.Controls.Add(Me.btn_imprimir)
        Me.GroupBox2.Controls.Add(Me.btn_exportar)
        Me.GroupBox2.Controls.Add(Me.btn_editar)
        Me.GroupBox2.Location = New System.Drawing.Point(577, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 100)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 3
        Me.btn_actualizar.Location = New System.Drawing.Point(283, 20)
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
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 0
        Me.btn_imprimir.Location = New System.Drawing.Point(10, 20)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(75, 64)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.Location = New System.Drawing.Point(101, 20)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 64)
        Me.btn_exportar.TabIndex = 2
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'btn_editar
        '
        Me.btn_editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_editar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_editar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.ForeColor = System.Drawing.Color.White
        Me.btn_editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_editar.ImageIndex = 2
        Me.btn_editar.Location = New System.Drawing.Point(192, 20)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(75, 64)
        Me.btn_editar.TabIndex = 2
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_editar.UseVisualStyleBackColor = False
        Me.btn_editar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_comentarios)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_estados)
        Me.GroupBox1.Location = New System.Drawing.Point(42, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 100)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Comentarios"
        '
        'txt_comentarios
        '
        Me.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios.Location = New System.Drawing.Point(97, 25)
        Me.txt_comentarios.Name = "txt_comentarios"
        Me.txt_comentarios.Size = New System.Drawing.Size(409, 20)
        Me.txt_comentarios.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Estado"
        '
        'cmb_estados
        '
        Me.cmb_estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estados.DropDownWidth = 160
        Me.cmb_estados.Location = New System.Drawing.Point(97, 63)
        Me.cmb_estados.Name = "cmb_estados"
        Me.cmb_estados.Size = New System.Drawing.Size(144, 21)
        Me.cmb_estados.TabIndex = 5
        '
        'dg_internaciones
        '
        Me.dg_internaciones.AllowUserToAddRows = False
        Me.dg_internaciones.AllowUserToDeleteRows = False
        Me.dg_internaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_internaciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.dg_internaciones.Location = New System.Drawing.Point(1, 127)
        Me.dg_internaciones.Name = "dg_internaciones"
        Me.dg_internaciones.ReadOnly = True
        Me.dg_internaciones.RowHeadersWidth = 25
        Me.dg_internaciones.Size = New System.Drawing.Size(1074, 183)
        Me.dg_internaciones.TabIndex = 17
        '
        'frm_int_listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 586)
        Me.Controls.Add(Me.dg_detalle_dua)
        Me.Controls.Add(Me.dg_detalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_internaciones)
        Me.Name = "frm_int_listado"
        Me.Text = "frm_int_listado"
        CType(Me.dg_detalle_dua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_internaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_detalle_dua As System.Windows.Forms.DataGridView
    Friend WithEvents dg_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_estados As System.Windows.Forms.ComboBox
    Friend WithEvents dg_internaciones As System.Windows.Forms.DataGridView
End Class
