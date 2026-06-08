<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_vin_Pedido_automatico_otras_bodegas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_vin_Pedido_automatico_otras_bodegas))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbBodega = New System.Windows.Forms.ComboBox()
        Me.txtPedidosGenerados = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_observaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtNumeroPedidos = New System.Windows.Forms.TextBox()
        Me.txtSkus = New System.Windows.Forms.TextBox()
        Me.txt_monto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMostrarTodo = New System.Windows.Forms.CheckBox()
        Me.dgv_productos = New System.Windows.Forms.DataGridView()
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox()
        Me.cmb_1 = New System.Windows.Forms.ComboBox()
        Me.txt_filtro1 = New System.Windows.Forms.TextBox()
        Me.chkDesmarcar = New System.Windows.Forms.CheckBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbBodega)
        Me.GroupBox5.Controls.Add(Me.txtPedidosGenerados)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txt_observaciones)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.btn_guardar)
        Me.GroupBox5.Controls.Add(Me.btn_generar)
        Me.GroupBox5.Controls.Add(Me.txtNumeroPedidos)
        Me.GroupBox5.Controls.Add(Me.txtSkus)
        Me.GroupBox5.Controls.Add(Me.txt_monto)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.cmb_proveedor)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(994, 137)
        Me.GroupBox5.TabIndex = 25
        Me.GroupBox5.TabStop = False
        '
        'cmbBodega
        '
        Me.cmbBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(466, 21)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(121, 21)
        Me.cmbBodega.TabIndex = 40
        '
        'txtPedidosGenerados
        '
        Me.txtPedidosGenerados.Location = New System.Drawing.Point(465, 48)
        Me.txtPedidosGenerados.Multiline = True
        Me.txtPedidosGenerados.Name = "txtPedidosGenerados"
        Me.txtPedidosGenerados.ReadOnly = True
        Me.txtPedidosGenerados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPedidosGenerados.Size = New System.Drawing.Size(126, 83)
        Me.txtPedidosGenerados.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Pedidos"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.Location = New System.Drawing.Point(90, 51)
        Me.txt_observaciones.Multiline = True
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_observaciones.Size = New System.Drawing.Size(292, 82)
        Me.txt_observaciones.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(413, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Bodega"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(809, 21)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(101, 62)
        Me.btn_guardar.TabIndex = 35
        Me.btn_guardar.Text = "Grabar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedido"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "7.png")
        Me.ImageList1.Images.SetKeyName(1, "3.png")
        Me.ImageList1.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "Floppy-64.png")
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList3
        Me.btn_generar.Location = New System.Drawing.Point(678, 21)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(125, 62)
        Me.btn_generar.TabIndex = 34
        Me.btn_generar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "")
        Me.ImageList3.Images.SetKeyName(1, "")
        '
        'txtNumeroPedidos
        '
        Me.txtNumeroPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumeroPedidos.BackColor = System.Drawing.Color.White
        Me.txtNumeroPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroPedidos.ForeColor = System.Drawing.Color.Maroon
        Me.txtNumeroPedidos.Location = New System.Drawing.Point(871, 89)
        Me.txtNumeroPedidos.Name = "txtNumeroPedidos"
        Me.txtNumeroPedidos.ReadOnly = True
        Me.txtNumeroPedidos.Size = New System.Drawing.Size(39, 21)
        Me.txtNumeroPedidos.TabIndex = 28
        Me.txtNumeroPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSkus
        '
        Me.txtSkus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSkus.BackColor = System.Drawing.Color.White
        Me.txtSkus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSkus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSkus.ForeColor = System.Drawing.Color.Maroon
        Me.txtSkus.Location = New System.Drawing.Point(810, 89)
        Me.txtSkus.Name = "txtSkus"
        Me.txtSkus.ReadOnly = True
        Me.txtSkus.Size = New System.Drawing.Size(62, 21)
        Me.txtSkus.TabIndex = 28
        Me.txtSkus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_monto
        '
        Me.txt_monto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_monto.BackColor = System.Drawing.Color.White
        Me.txt_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_monto.ForeColor = System.Drawing.Color.Maroon
        Me.txt_monto.Location = New System.Drawing.Point(810, 111)
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.ReadOnly = True
        Me.txt_monto.Size = New System.Drawing.Size(100, 21)
        Me.txt_monto.TabIndex = 28
        Me.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(751, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Total SKU"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(737, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Total Pedido"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Proveedor"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(90, 21)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(292, 21)
        Me.cmb_proveedor.TabIndex = 26
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkMostrarTodo)
        Me.GroupBox1.Controls.Add(Me.dgv_productos)
        Me.GroupBox1.Controls.Add(Me.cmb_valor1)
        Me.GroupBox1.Controls.Add(Me.cmb_1)
        Me.GroupBox1.Controls.Add(Me.txt_filtro1)
        Me.GroupBox1.Controls.Add(Me.chkDesmarcar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 155)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(994, 348)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado de Productos"
        '
        'chkMostrarTodo
        '
        Me.chkMostrarTodo.AutoSize = True
        Me.chkMostrarTodo.Location = New System.Drawing.Point(838, 33)
        Me.chkMostrarTodo.Name = "chkMostrarTodo"
        Me.chkMostrarTodo.Size = New System.Drawing.Size(108, 20)
        Me.chkMostrarTodo.TabIndex = 42
        Me.chkMostrarTodo.Text = "Mostrar Todo"
        Me.chkMostrarTodo.UseVisualStyleBackColor = True
        '
        'dgv_productos
        '
        Me.dgv_productos.AllowUserToAddRows = False
        Me.dgv_productos.AllowUserToDeleteRows = False
        Me.dgv_productos.AllowUserToOrderColumns = True
        Me.dgv_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos.Location = New System.Drawing.Point(6, 59)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.RowHeadersWidth = 25
        Me.dgv_productos.Size = New System.Drawing.Size(982, 283)
        Me.dgv_productos.TabIndex = 21
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(6, 17)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 24)
        Me.cmb_valor1.Sorted = True
        Me.cmb_valor1.TabIndex = 3
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(116, 17)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(56, 24)
        Me.cmb_1.TabIndex = 4
        '
        'txt_filtro1
        '
        Me.txt_filtro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_filtro1.Location = New System.Drawing.Point(178, 19)
        Me.txt_filtro1.Name = "txt_filtro1"
        Me.txt_filtro1.Size = New System.Drawing.Size(626, 22)
        Me.txt_filtro1.TabIndex = 5
        '
        'chkDesmarcar
        '
        Me.chkDesmarcar.AutoSize = True
        Me.chkDesmarcar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDesmarcar.Location = New System.Drawing.Point(6, 42)
        Me.chkDesmarcar.Name = "chkDesmarcar"
        Me.chkDesmarcar.Size = New System.Drawing.Size(116, 18)
        Me.chkDesmarcar.TabIndex = 42
        Me.chkDesmarcar.Text = "Desmarcar Todo"
        Me.chkDesmarcar.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "Search.png")
        '
        'frm_vin_Pedido_automatico_otras_bodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1002, 515)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frm_vin_Pedido_automatico_otras_bodegas"
        Me.Text = "::. Pedido Automatico .::"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_filtro1 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents chkMostrarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents txtSkus As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPedidosGenerados As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroPedidos As System.Windows.Forms.TextBox
    Friend WithEvents chkDesmarcar As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
End Class
