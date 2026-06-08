<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualizacionProducto
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_actualizacionProducto))
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.cmbPaisCompraNuevo = New System.Windows.Forms.ComboBox()
        Me.cmbVigenciaNueva = New System.Windows.Forms.ComboBox()
        Me.cmbMarcaNueva = New System.Windows.Forms.ComboBox()
        Me.cmbProveedorNuevo = New System.Windows.Forms.ComboBox()
        Me.txtUxCNueva = New System.Windows.Forms.TextBox()
        Me.txtBarraNueva = New System.Windows.Forms.TextBox()
        Me.txtUxCOriginal = New System.Windows.Forms.TextBox()
        Me.txtBarraOriginal = New System.Windows.Forms.TextBox()
        Me.txtGlosaNueva = New System.Windows.Forms.TextBox()
        Me.txtPaisCompraOriginal = New System.Windows.Forms.TextBox()
        Me.txtVigenciaOriginal = New System.Windows.Forms.TextBox()
        Me.txtGlosaOriginal = New System.Windows.Forms.TextBox()
        Me.txtMarcaOriginal = New System.Windows.Forms.TextBox()
        Me.txtProveedorOriginal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProducto
        '
        Me.dgvProducto.AllowUserToAddRows = False
        Me.dgvProducto.AllowUserToDeleteRows = False
        Me.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProducto.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProducto.Location = New System.Drawing.Point(12, 67)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.ReadOnly = True
        Me.dgvProducto.RowHeadersWidth = 20
        Me.dgvProducto.Size = New System.Drawing.Size(756, 418)
        Me.dgvProducto.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.cmbPaisCompraNuevo)
        Me.GroupBox1.Controls.Add(Me.cmbVigenciaNueva)
        Me.GroupBox1.Controls.Add(Me.cmbMarcaNueva)
        Me.GroupBox1.Controls.Add(Me.cmbProveedorNuevo)
        Me.GroupBox1.Controls.Add(Me.txtUxCNueva)
        Me.GroupBox1.Controls.Add(Me.txtBarraNueva)
        Me.GroupBox1.Controls.Add(Me.txtUxCOriginal)
        Me.GroupBox1.Controls.Add(Me.txtBarraOriginal)
        Me.GroupBox1.Controls.Add(Me.txtGlosaNueva)
        Me.GroupBox1.Controls.Add(Me.txtPaisCompraOriginal)
        Me.GroupBox1.Controls.Add(Me.txtVigenciaOriginal)
        Me.GroupBox1.Controls.Add(Me.txtGlosaOriginal)
        Me.GroupBox1.Controls.Add(Me.txtMarcaOriginal)
        Me.GroupBox1.Controls.Add(Me.txtProveedorOriginal)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(774, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 473)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(110, 9)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtProducto.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAplicar.ImageIndex = 0
        Me.btnAplicar.ImageList = Me.ImageList1
        Me.btnAplicar.Location = New System.Drawing.Point(187, 406)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 61)
        Me.btnAplicar.TabIndex = 3
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'cmbPaisCompraNuevo
        '
        Me.cmbPaisCompraNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaisCompraNuevo.FormattingEnabled = True
        Me.cmbPaisCompraNuevo.Location = New System.Drawing.Point(9, 244)
        Me.cmbPaisCompraNuevo.Name = "cmbPaisCompraNuevo"
        Me.cmbPaisCompraNuevo.Size = New System.Drawing.Size(282, 21)
        Me.cmbPaisCompraNuevo.TabIndex = 2
        '
        'cmbVigenciaNueva
        '
        Me.cmbVigenciaNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVigenciaNueva.FormattingEnabled = True
        Me.cmbVigenciaNueva.Items.AddRange(New Object() {"S", "N"})
        Me.cmbVigenciaNueva.Location = New System.Drawing.Point(89, 369)
        Me.cmbVigenciaNueva.Name = "cmbVigenciaNueva"
        Me.cmbVigenciaNueva.Size = New System.Drawing.Size(121, 21)
        Me.cmbVigenciaNueva.TabIndex = 2
        '
        'cmbMarcaNueva
        '
        Me.cmbMarcaNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcaNueva.FormattingEnabled = True
        Me.cmbMarcaNueva.Location = New System.Drawing.Point(9, 184)
        Me.cmbMarcaNueva.Name = "cmbMarcaNueva"
        Me.cmbMarcaNueva.Size = New System.Drawing.Size(282, 21)
        Me.cmbMarcaNueva.TabIndex = 2
        '
        'cmbProveedorNuevo
        '
        Me.cmbProveedorNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedorNuevo.FormattingEnabled = True
        Me.cmbProveedorNuevo.Location = New System.Drawing.Point(6, 115)
        Me.cmbProveedorNuevo.Name = "cmbProveedorNuevo"
        Me.cmbProveedorNuevo.Size = New System.Drawing.Size(285, 21)
        Me.cmbProveedorNuevo.TabIndex = 2
        '
        'txtUxCNueva
        '
        Me.txtUxCNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUxCNueva.Location = New System.Drawing.Point(9, 370)
        Me.txtUxCNueva.Name = "txtUxCNueva"
        Me.txtUxCNueva.Size = New System.Drawing.Size(53, 20)
        Me.txtUxCNueva.TabIndex = 0
        '
        'txtBarraNueva
        '
        Me.txtBarraNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarraNueva.Location = New System.Drawing.Point(9, 305)
        Me.txtBarraNueva.Name = "txtBarraNueva"
        Me.txtBarraNueva.Size = New System.Drawing.Size(175, 20)
        Me.txtBarraNueva.TabIndex = 0
        '
        'txtUxCOriginal
        '
        Me.txtUxCOriginal.Location = New System.Drawing.Point(9, 348)
        Me.txtUxCOriginal.Name = "txtUxCOriginal"
        Me.txtUxCOriginal.ReadOnly = True
        Me.txtUxCOriginal.Size = New System.Drawing.Size(53, 20)
        Me.txtUxCOriginal.TabIndex = 0
        '
        'txtBarraOriginal
        '
        Me.txtBarraOriginal.Location = New System.Drawing.Point(9, 283)
        Me.txtBarraOriginal.Name = "txtBarraOriginal"
        Me.txtBarraOriginal.ReadOnly = True
        Me.txtBarraOriginal.Size = New System.Drawing.Size(175, 20)
        Me.txtBarraOriginal.TabIndex = 0
        '
        'txtGlosaNueva
        '
        Me.txtGlosaNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosaNueva.Location = New System.Drawing.Point(9, 56)
        Me.txtGlosaNueva.Name = "txtGlosaNueva"
        Me.txtGlosaNueva.Size = New System.Drawing.Size(285, 20)
        Me.txtGlosaNueva.TabIndex = 0
        '
        'txtPaisCompraOriginal
        '
        Me.txtPaisCompraOriginal.Location = New System.Drawing.Point(9, 223)
        Me.txtPaisCompraOriginal.Name = "txtPaisCompraOriginal"
        Me.txtPaisCompraOriginal.ReadOnly = True
        Me.txtPaisCompraOriginal.Size = New System.Drawing.Size(282, 20)
        Me.txtPaisCompraOriginal.TabIndex = 0
        '
        'txtVigenciaOriginal
        '
        Me.txtVigenciaOriginal.Location = New System.Drawing.Point(89, 348)
        Me.txtVigenciaOriginal.Name = "txtVigenciaOriginal"
        Me.txtVigenciaOriginal.ReadOnly = True
        Me.txtVigenciaOriginal.Size = New System.Drawing.Size(121, 20)
        Me.txtVigenciaOriginal.TabIndex = 0
        '
        'txtGlosaOriginal
        '
        Me.txtGlosaOriginal.Location = New System.Drawing.Point(9, 32)
        Me.txtGlosaOriginal.Name = "txtGlosaOriginal"
        Me.txtGlosaOriginal.ReadOnly = True
        Me.txtGlosaOriginal.Size = New System.Drawing.Size(285, 20)
        Me.txtGlosaOriginal.TabIndex = 0
        '
        'txtMarcaOriginal
        '
        Me.txtMarcaOriginal.Location = New System.Drawing.Point(9, 163)
        Me.txtMarcaOriginal.Name = "txtMarcaOriginal"
        Me.txtMarcaOriginal.ReadOnly = True
        Me.txtMarcaOriginal.Size = New System.Drawing.Size(282, 20)
        Me.txtMarcaOriginal.TabIndex = 0
        '
        'txtProveedorOriginal
        '
        Me.txtProveedorOriginal.Location = New System.Drawing.Point(6, 91)
        Me.txtProveedorOriginal.Name = "txtProveedorOriginal"
        Me.txtProveedorOriginal.ReadOnly = True
        Me.txtProveedorOriginal.Size = New System.Drawing.Size(285, 20)
        Me.txtProveedorOriginal.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Pais de Compra"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 332)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vigencia"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Marca"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Glosa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 333)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "UxC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 268)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Barra"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefrescar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefrescar.ForeColor = System.Drawing.Color.White
        Me.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.ImageList = Me.ImageList1
        Me.btnRefrescar.Location = New System.Drawing.Point(271, 0)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 61)
        Me.btnRefrescar.TabIndex = 3
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "Actualizar.png")
        '
        'frm_actualizacionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1077, 497)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvProducto)
        Me.Name = "frm_actualizacionProducto"
        Me.Text = ".::. Actualizacion de Productos .::."
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProducto As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents cmbPaisCompraNuevo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVigenciaNueva As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMarcaNueva As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProveedorNuevo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUxCNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtBarraNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtUxCOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtBarraOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosaNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtPaisCompraOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtVigenciaOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosaOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtMarcaOriginal As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedorOriginal As System.Windows.Forms.TextBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
