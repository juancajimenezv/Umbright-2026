<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_inventariosCiclicos
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
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
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_actualizar_Barras = New System.Windows.Forms.Button
        Me.dgv_listado_barras = New System.Windows.Forms.DataGridView
        Me.btn_obtener_archivos = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_conteo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_listado_barras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(791, 485)
        Me.TabControl1.TabIndex = 0
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
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Items.AddRange(New Object() {"CODICASA", "DMARTE1", "DIUVA", "VINOTECA"})
        Me.cmbEmpresa.Location = New System.Drawing.Point(81, 5)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 20)
        Me.cmbEmpresa.TabIndex = 5
        '
        'cmbBodega
        '
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(81, 27)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(121, 21)
        Me.cmbBodega.TabIndex = 5
        Me.cmbBodega.Visible = False
        '
        'cmbConteos
        '
        Me.cmbConteos.FormattingEnabled = True
        Me.cmbConteos.Location = New System.Drawing.Point(81, 50)
        Me.cmbConteos.Name = "cmbConteos"
        Me.cmbConteos.Size = New System.Drawing.Size(121, 21)
        Me.cmbConteos.TabIndex = 4
        Me.cmbConteos.Visible = False
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
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Conteo"
        Me.Label2.Visible = False
        '
        'dgv_conteo
        '
        Me.dgv_conteo.AllowUserToAddRows = False
        Me.dgv_conteo.AllowUserToDeleteRows = False
        Me.dgv_conteo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_conteo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_conteo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_conteo.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_conteo.Location = New System.Drawing.Point(3, 78)
        Me.dgv_conteo.Name = "dgv_conteo"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_conteo.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
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
        Me.TabPage2.Text = "Revision de Barras"
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listado_barras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_listado_barras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_listado_barras.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgv_listado_barras.Location = New System.Drawing.Point(3, 98)
        Me.dgv_listado_barras.Name = "dgv_listado_barras"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_listado_barras.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
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
        'frm_inventariosCiclicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 491)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_inventariosCiclicos"
        Me.Text = ":: Inventarios Ciclicos ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_conteo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_listado_barras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_listado_barras As System.Windows.Forms.DataGridView
    Friend WithEvents btn_obtener_archivos As System.Windows.Forms.Button
    Friend WithEvents btn_actualizar_Barras As System.Windows.Forms.Button
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
