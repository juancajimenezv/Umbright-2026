<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_maq_orden_etiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_orden_etiquetas))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.btn_ayuda = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.solicitado_por = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_op_observaciones = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_op_numero_orden = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_op_cantidad_solicitada = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_op_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_nuevo_orden_produccion = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar_orden_produccion = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.txt_producto)
        Me.GroupBox2.Controls.Add(Me.btn_ayuda)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.solicitado_por)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txt_op_observaciones)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_op_numero_orden)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_op_cantidad_solicitada)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtp_op_fecha_inicio)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo_orden_produccion)
        Me.GroupBox2.Controls.Add(Me.btn_guardar_orden_produccion)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(506, 222)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(128, 78)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(360, 22)
        Me.txt_descripcion.TabIndex = 3
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(128, 51)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(88, 22)
        Me.txt_producto.TabIndex = 1
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(222, 51)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(26, 22)
        Me.btn_ayuda.TabIndex = 2
        Me.btn_ayuda.Text = "..."
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Producto"
        '
        'solicitado_por
        '
        Me.solicitado_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.solicitado_por.Location = New System.Drawing.Point(128, 181)
        Me.solicitado_por.Name = "solicitado_por"
        Me.solicitado_por.ReadOnly = True
        Me.solicitado_por.Size = New System.Drawing.Size(338, 20)
        Me.solicitado_por.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(22, 188)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Solicitado por"
        '
        'txt_op_observaciones
        '
        Me.txt_op_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_observaciones.Location = New System.Drawing.Point(128, 155)
        Me.txt_op_observaciones.Name = "txt_op_observaciones"
        Me.txt_op_observaciones.Size = New System.Drawing.Size(338, 20)
        Me.txt_op_observaciones.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(22, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "No Orden"
        '
        'txt_op_numero_orden
        '
        Me.txt_op_numero_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_numero_orden.ForeColor = System.Drawing.Color.Brown
        Me.txt_op_numero_orden.Location = New System.Drawing.Point(128, 25)
        Me.txt_op_numero_orden.Name = "txt_op_numero_orden"
        Me.txt_op_numero_orden.ReadOnly = True
        Me.txt_op_numero_orden.Size = New System.Drawing.Size(88, 20)
        Me.txt_op_numero_orden.TabIndex = 0
        Me.txt_op_numero_orden.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cantidad Solicitada"
        '
        'txt_op_cantidad_solicitada
        '
        Me.txt_op_cantidad_solicitada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_op_cantidad_solicitada.Location = New System.Drawing.Point(128, 103)
        Me.txt_op_cantidad_solicitada.Name = "txt_op_cantidad_solicitada"
        Me.txt_op_cantidad_solicitada.Size = New System.Drawing.Size(88, 20)
        Me.txt_op_cantidad_solicitada.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(22, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha Inicio Venta"
        '
        'dtp_op_fecha_inicio
        '
        Me.dtp_op_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_op_fecha_inicio.Location = New System.Drawing.Point(128, 129)
        Me.dtp_op_fecha_inicio.Name = "dtp_op_fecha_inicio"
        Me.dtp_op_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_op_fecha_inicio.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(22, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Observaciones"
        '
        'btn_nuevo_orden_produccion
        '
        Me.btn_nuevo_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_orden_produccion.ImageIndex = 3
        Me.btn_nuevo_orden_produccion.ImageList = Me.ImageList1
        Me.btn_nuevo_orden_produccion.Location = New System.Drawing.Point(319, 13)
        Me.btn_nuevo_orden_produccion.Name = "btn_nuevo_orden_produccion"
        Me.btn_nuevo_orden_produccion.Size = New System.Drawing.Size(80, 59)
        Me.btn_nuevo_orden_produccion.TabIndex = 8
        Me.btn_nuevo_orden_produccion.Text = "Nuevo"
        Me.btn_nuevo_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_orden_produccion.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "pack.png")
        Me.ImageList1.Images.SetKeyName(2, "pack2.png")
        Me.ImageList1.Images.SetKeyName(3, "3.png")
        Me.ImageList1.Images.SetKeyName(4, "grafica1.png")
        '
        'btn_guardar_orden_produccion
        '
        Me.btn_guardar_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_orden_produccion.ImageIndex = 0
        Me.btn_guardar_orden_produccion.ImageList = Me.ImageList1
        Me.btn_guardar_orden_produccion.Location = New System.Drawing.Point(405, 13)
        Me.btn_guardar_orden_produccion.Name = "btn_guardar_orden_produccion"
        Me.btn_guardar_orden_produccion.Size = New System.Drawing.Size(80, 59)
        Me.btn_guardar_orden_produccion.TabIndex = 9
        Me.btn_guardar_orden_produccion.Text = "Guardar"
        Me.btn_guardar_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_orden_produccion.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        '
        'frm_maq_orden_etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(563, 268)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frm_maq_orden_etiquetas"
        Me.Text = "::. Etiquetas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents solicitado_por As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_op_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_op_numero_orden As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_op_cantidad_solicitada As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_op_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
End Class
