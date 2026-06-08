<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consignaciones_saldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consignaciones_saldos))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_agregar_producto = New System.Windows.Forms.Button
        Me.txt_cantidad_aprobada_dc = New System.Windows.Forms.TextBox
        Me.txt_descripcion_producto_dc = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto_dc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.txt_nombre_cliente_dc = New System.Windows.Forms.TextBox
        Me.txt_codigo_cliente_dc = New System.Windows.Forms.TextBox
        Me.dgv_historial = New System.Windows.Forms.DataGridView
        Me.dgv_productos = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv_clientes = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txt_codigo_listado_producto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nombre_listado_producto = New System.Windows.Forms.TextBox
        Me.btn_buscar_listado_productos = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgv_listado_clientes_productos = New System.Windows.Forms.DataGridView
        Me.dgv_listado_productos_clientes_saldos = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_historial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_listado_clientes_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listado_productos_clientes_saldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(851, 523)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.btn_limpiar)
        Me.TabPage1.Controls.Add(Me.txt_nombre_cliente_dc)
        Me.TabPage1.Controls.Add(Me.txt_codigo_cliente_dc)
        Me.TabPage1.Controls.Add(Me.dgv_historial)
        Me.TabPage1.Controls.Add(Me.dgv_productos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(843, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle de Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_agregar_producto)
        Me.GroupBox1.Controls.Add(Me.txt_cantidad_aprobada_dc)
        Me.GroupBox1.Controls.Add(Me.txt_descripcion_producto_dc)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_producto_dc)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 52)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos Nuevos"
        '
        'btn_agregar_producto
        '
        Me.btn_agregar_producto.BackColor = System.Drawing.Color.LightCyan
        Me.btn_agregar_producto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar_producto.Location = New System.Drawing.Point(573, 25)
        Me.btn_agregar_producto.Name = "btn_agregar_producto"
        Me.btn_agregar_producto.Size = New System.Drawing.Size(39, 22)
        Me.btn_agregar_producto.TabIndex = 3
        Me.btn_agregar_producto.Text = "Ok"
        Me.btn_agregar_producto.UseVisualStyleBackColor = False
        '
        'txt_cantidad_aprobada_dc
        '
        Me.txt_cantidad_aprobada_dc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad_aprobada_dc.Location = New System.Drawing.Point(459, 27)
        Me.txt_cantidad_aprobada_dc.Name = "txt_cantidad_aprobada_dc"
        Me.txt_cantidad_aprobada_dc.Size = New System.Drawing.Size(60, 20)
        Me.txt_cantidad_aprobada_dc.TabIndex = 2
        '
        'txt_descripcion_producto_dc
        '
        Me.txt_descripcion_producto_dc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion_producto_dc.Location = New System.Drawing.Point(89, 27)
        Me.txt_descripcion_producto_dc.Name = "txt_descripcion_producto_dc"
        Me.txt_descripcion_producto_dc.ReadOnly = True
        Me.txt_descripcion_producto_dc.Size = New System.Drawing.Size(364, 20)
        Me.txt_descripcion_producto_dc.TabIndex = 1
        Me.txt_descripcion_producto_dc.TabStop = False
        '
        'txt_codigo_producto_dc
        '
        Me.txt_codigo_producto_dc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto_dc.Location = New System.Drawing.Point(6, 27)
        Me.txt_codigo_producto_dc.Name = "txt_codigo_producto_dc"
        Me.txt_codigo_producto_dc.Size = New System.Drawing.Size(77, 20)
        Me.txt_codigo_producto_dc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Cliente"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.LightCyan
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageKey = "floppy_disk_48.png"
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(753, 6)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(69, 55)
        Me.btn_guardar.TabIndex = 4
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "floppy_disk_48.png")
        Me.ImageList1.Images.SetKeyName(1, "limpiar2.jpg")
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.LightCyan
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageKey = "limpiar2.jpg"
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(682, 6)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(71, 55)
        Me.btn_limpiar.TabIndex = 4
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'txt_nombre_cliente_dc
        '
        Me.txt_nombre_cliente_dc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_cliente_dc.Location = New System.Drawing.Point(135, 6)
        Me.txt_nombre_cliente_dc.Name = "txt_nombre_cliente_dc"
        Me.txt_nombre_cliente_dc.ReadOnly = True
        Me.txt_nombre_cliente_dc.Size = New System.Drawing.Size(408, 20)
        Me.txt_nombre_cliente_dc.TabIndex = 3
        '
        'txt_codigo_cliente_dc
        '
        Me.txt_codigo_cliente_dc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_cliente_dc.Location = New System.Drawing.Point(51, 6)
        Me.txt_codigo_cliente_dc.Name = "txt_codigo_cliente_dc"
        Me.txt_codigo_cliente_dc.Size = New System.Drawing.Size(78, 20)
        Me.txt_codigo_cliente_dc.TabIndex = 2
        '
        'dgv_historial
        '
        Me.dgv_historial.AllowUserToAddRows = False
        Me.dgv_historial.AllowUserToDeleteRows = False
        Me.dgv_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_historial.Location = New System.Drawing.Point(6, 272)
        Me.dgv_historial.Name = "dgv_historial"
        Me.dgv_historial.ReadOnly = True
        Me.dgv_historial.RowHeadersWidth = 25
        Me.dgv_historial.Size = New System.Drawing.Size(831, 215)
        Me.dgv_historial.TabIndex = 1
        '
        'dgv_productos
        '
        Me.dgv_productos.AllowUserToAddRows = False
        Me.dgv_productos.AllowUserToDeleteRows = False
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos.Location = New System.Drawing.Point(6, 88)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.RowHeadersWidth = 25
        Me.dgv_productos.Size = New System.Drawing.Size(831, 181)
        Me.dgv_productos.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.dgv_clientes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(843, 496)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado de Clientes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Clientes Aprobados "
        '
        'dgv_clientes
        '
        Me.dgv_clientes.AllowUserToAddRows = False
        Me.dgv_clientes.AllowUserToDeleteRows = False
        Me.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_clientes.Location = New System.Drawing.Point(6, 51)
        Me.dgv_clientes.Name = "dgv_clientes"
        Me.dgv_clientes.RowHeadersWidth = 25
        Me.dgv_clientes.Size = New System.Drawing.Size(831, 437)
        Me.dgv_clientes.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Honeydew
        Me.TabPage3.Controls.Add(Me.txt_codigo_listado_producto)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.txt_nombre_listado_producto)
        Me.TabPage3.Controls.Add(Me.btn_buscar_listado_productos)
        Me.TabPage3.Controls.Add(Me.dgv_listado_clientes_productos)
        Me.TabPage3.Controls.Add(Me.dgv_listado_productos_clientes_saldos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(843, 496)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Listado de Productos"
        '
        'txt_codigo_listado_producto
        '
        Me.txt_codigo_listado_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_listado_producto.Location = New System.Drawing.Point(63, 15)
        Me.txt_codigo_listado_producto.Name = "txt_codigo_listado_producto"
        Me.txt_codigo_listado_producto.Size = New System.Drawing.Size(74, 20)
        Me.txt_codigo_listado_producto.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Producto"
        '
        'txt_nombre_listado_producto
        '
        Me.txt_nombre_listado_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_listado_producto.Enabled = False
        Me.txt_nombre_listado_producto.Location = New System.Drawing.Point(143, 16)
        Me.txt_nombre_listado_producto.Name = "txt_nombre_listado_producto"
        Me.txt_nombre_listado_producto.Size = New System.Drawing.Size(384, 20)
        Me.txt_nombre_listado_producto.TabIndex = 3
        '
        'btn_buscar_listado_productos
        '
        Me.btn_buscar_listado_productos.BackColor = System.Drawing.Color.LightCyan
        Me.btn_buscar_listado_productos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar_listado_productos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar_listado_productos.ImageIndex = 0
        Me.btn_buscar_listado_productos.ImageList = Me.ImageList2
        Me.btn_buscar_listado_productos.Location = New System.Drawing.Point(561, 14)
        Me.btn_buscar_listado_productos.Name = "btn_buscar_listado_productos"
        Me.btn_buscar_listado_productos.Size = New System.Drawing.Size(76, 25)
        Me.btn_buscar_listado_productos.TabIndex = 2
        Me.btn_buscar_listado_productos.Text = "Buscar"
        Me.btn_buscar_listado_productos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar_listado_productos.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "buscar2.jpg")
        '
        'dgv_listado_clientes_productos
        '
        Me.dgv_listado_clientes_productos.AllowUserToAddRows = False
        Me.dgv_listado_clientes_productos.AllowUserToDeleteRows = False
        Me.dgv_listado_clientes_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado_clientes_productos.Location = New System.Drawing.Point(7, 218)
        Me.dgv_listado_clientes_productos.Name = "dgv_listado_clientes_productos"
        Me.dgv_listado_clientes_productos.ReadOnly = True
        Me.dgv_listado_clientes_productos.RowHeadersWidth = 25
        Me.dgv_listado_clientes_productos.Size = New System.Drawing.Size(830, 271)
        Me.dgv_listado_clientes_productos.TabIndex = 1
        '
        'dgv_listado_productos_clientes_saldos
        '
        Me.dgv_listado_productos_clientes_saldos.AllowUserToAddRows = False
        Me.dgv_listado_productos_clientes_saldos.AllowUserToDeleteRows = False
        Me.dgv_listado_productos_clientes_saldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listado_productos_clientes_saldos.Location = New System.Drawing.Point(7, 45)
        Me.dgv_listado_productos_clientes_saldos.Name = "dgv_listado_productos_clientes_saldos"
        Me.dgv_listado_productos_clientes_saldos.ReadOnly = True
        Me.dgv_listado_productos_clientes_saldos.RowHeadersWidth = 25
        Me.dgv_listado_productos_clientes_saldos.Size = New System.Drawing.Size(830, 166)
        Me.dgv_listado_productos_clientes_saldos.TabIndex = 0
        '
        'frm_consignaciones_saldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(856, 527)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_consignaciones_saldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Consignaciones - Saldos ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_historial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_listado_clientes_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listado_productos_clientes_saldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_historial As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_nombre_cliente_dc As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_cliente_dc As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_agregar_producto As System.Windows.Forms.Button
    Friend WithEvents txt_cantidad_aprobada_dc As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion_producto_dc As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_producto_dc As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_listado_clientes_productos As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_listado_productos_clientes_saldos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_listado_producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_listado_productos As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_listado_producto As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
End Class
