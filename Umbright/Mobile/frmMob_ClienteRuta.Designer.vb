<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMob_ClienteRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMob_ClienteRuta))
        Me.dgv_enrutados = New System.Windows.Forms.DataGridView
        Me.dgListadoCliente = New System.Windows.Forms.DataGridView
        Me.cmbCriterio = New System.Windows.Forms.ComboBox
        Me.cmbCondicion = New System.Windows.Forms.ComboBox
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.cmbRuta = New System.Windows.Forms.ComboBox
        Me.cmbVendedor = New System.Windows.Forms.ComboBox
        Me.Ejecutivo = New System.Windows.Forms.Label
        Me.btnObtener = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.cmbFrecuencia = New System.Windows.Forms.ComboBox
        Me.chk_ruta = New System.Windows.Forms.CheckBox
        Me.chk_frecuencia = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgv_enrutados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgListadoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_enrutados
        '
        Me.dgv_enrutados.AllowUserToAddRows = False
        Me.dgv_enrutados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_enrutados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_enrutados.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_enrutados.Location = New System.Drawing.Point(438, 80)
        Me.dgv_enrutados.Name = "dgv_enrutados"
        Me.dgv_enrutados.RowHeadersWidth = 25
        Me.dgv_enrutados.Size = New System.Drawing.Size(541, 441)
        Me.dgv_enrutados.TabIndex = 0
        '
        'dgListadoCliente
        '
        Me.dgListadoCliente.AllowUserToAddRows = False
        Me.dgListadoCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgListadoCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgListadoCliente.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgListadoCliente.Location = New System.Drawing.Point(2, 80)
        Me.dgListadoCliente.Name = "dgListadoCliente"
        Me.dgListadoCliente.ReadOnly = True
        Me.dgListadoCliente.RowHeadersWidth = 25
        Me.dgListadoCliente.Size = New System.Drawing.Size(420, 441)
        Me.dgListadoCliente.TabIndex = 1
        '
        'cmbCriterio
        '
        Me.cmbCriterio.FormattingEnabled = True
        Me.cmbCriterio.Items.AddRange(New Object() {"Ejecutivo", "RazonSocial", "Nit"})
        Me.cmbCriterio.Location = New System.Drawing.Point(3, 33)
        Me.cmbCriterio.Name = "cmbCriterio"
        Me.cmbCriterio.Size = New System.Drawing.Size(90, 21)
        Me.cmbCriterio.TabIndex = 2
        Me.cmbCriterio.Text = "Ejecutivo"
        '
        'cmbCondicion
        '
        Me.cmbCondicion.FormattingEnabled = True
        Me.cmbCondicion.Items.AddRange(New Object() {"like", "=", ">", "<"})
        Me.cmbCondicion.Location = New System.Drawing.Point(99, 33)
        Me.cmbCondicion.Name = "cmbCondicion"
        Me.cmbCondicion.Size = New System.Drawing.Size(43, 21)
        Me.cmbCondicion.TabIndex = 2
        Me.cmbCondicion.Text = "like"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(148, 34)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(186, 20)
        Me.txtValor.TabIndex = 3
        '
        'cmbRuta
        '
        Me.cmbRuta.FormattingEnabled = True
        Me.cmbRuta.Location = New System.Drawing.Point(521, 15)
        Me.cmbRuta.Name = "cmbRuta"
        Me.cmbRuta.Size = New System.Drawing.Size(78, 21)
        Me.cmbRuta.TabIndex = 4
        '
        'cmbVendedor
        '
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(521, 41)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(279, 21)
        Me.cmbVendedor.TabIndex = 4
        '
        'Ejecutivo
        '
        Me.Ejecutivo.AutoSize = True
        Me.Ejecutivo.Location = New System.Drawing.Point(468, 45)
        Me.Ejecutivo.Name = "Ejecutivo"
        Me.Ejecutivo.Size = New System.Drawing.Size(53, 13)
        Me.Ejecutivo.TabIndex = 5
        Me.Ejecutivo.Text = "Vendedor"
        '
        'btnObtener
        '
        Me.btnObtener.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtener.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnObtener.ForeColor = System.Drawing.Color.White
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtener.ImageKey = "refresh.jpg"
        Me.btnObtener.ImageList = Me.ImageList1
        Me.btnObtener.Location = New System.Drawing.Point(338, 7)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(84, 65)
        Me.btnObtener.TabIndex = 6
        Me.btnObtener.Text = "Obtener Informacion"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtener.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "refresh.jpg")
        Me.ImageList1.Images.SetKeyName(1, "1286297068_Floppy-64.png")
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.ImageKey = "1286297068_Floppy-64.png"
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(887, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(67, 65)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.FormattingEnabled = True
        Me.cmbFrecuencia.Location = New System.Drawing.Point(723, 17)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Size = New System.Drawing.Size(77, 21)
        Me.cmbFrecuencia.TabIndex = 4
        '
        'chk_ruta
        '
        Me.chk_ruta.AutoSize = True
        Me.chk_ruta.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chk_ruta.Location = New System.Drawing.Point(471, 17)
        Me.chk_ruta.Name = "chk_ruta"
        Me.chk_ruta.Size = New System.Drawing.Size(49, 17)
        Me.chk_ruta.TabIndex = 7
        Me.chk_ruta.Text = "Ruta"
        Me.chk_ruta.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chk_ruta.UseVisualStyleBackColor = True
        '
        'chk_frecuencia
        '
        Me.chk_frecuencia.AutoSize = True
        Me.chk_frecuencia.Location = New System.Drawing.Point(638, 17)
        Me.chk_frecuencia.Name = "chk_frecuencia"
        Me.chk_frecuencia.Size = New System.Drawing.Size(79, 17)
        Me.chk_frecuencia.TabIndex = 8
        Me.chk_frecuencia.Text = "Frecuencia"
        Me.chk_frecuencia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(420, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = ">>"
        '
        'frmMob_ClienteRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 524)
        Me.Controls.Add(Me.chk_frecuencia)
        Me.Controls.Add(Me.chk_ruta)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnObtener)
        Me.Controls.Add(Me.Ejecutivo)
        Me.Controls.Add(Me.cmbVendedor)
        Me.Controls.Add(Me.cmbFrecuencia)
        Me.Controls.Add(Me.cmbRuta)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.cmbCondicion)
        Me.Controls.Add(Me.cmbCriterio)
        Me.Controls.Add(Me.dgListadoCliente)
        Me.Controls.Add(Me.dgv_enrutados)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMob_ClienteRuta"
        Me.Text = "::Asignacion de Rutas ::"
        CType(Me.dgv_enrutados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgListadoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_enrutados As System.Windows.Forms.DataGridView
    Friend WithEvents dgListadoCliente As System.Windows.Forms.DataGridView
    Friend WithEvents cmbCriterio As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents cmbRuta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Ejecutivo As System.Windows.Forms.Label
    Friend WithEvents btnObtener As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbFrecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents chk_ruta As System.Windows.Forms.CheckBox
    Friend WithEvents chk_frecuencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
