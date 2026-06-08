<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_asocia_solicitud_reserva
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_asocia_solicitud_reserva))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        Me.cb_bodega = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_reserva = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_ayuda_oc = New System.Windows.Forms.Button
        Me.txt_dua = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_unidades = New System.Windows.Forms.TextBox
        Me.txt_bultos = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_procesar = New System.Windows.Forms.Button
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgv_detalle)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 138)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(576, 183)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_detalle.Location = New System.Drawing.Point(3, 17)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.Size = New System.Drawing.Size(570, 163)
        Me.dgv_detalle.TabIndex = 0
        '
        'cb_bodega
        '
        Me.cb_bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_bodega.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bodega.FormattingEnabled = True
        Me.cb_bodega.Location = New System.Drawing.Point(81, 41)
        Me.cb_bodega.Name = "cb_bodega"
        Me.cb_bodega.Size = New System.Drawing.Size(138, 24)
        Me.cb_bodega.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Bodega:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.txt_reserva)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_proveedor)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btn_agregar)
        Me.GroupBox2.Controls.Add(Me.btn_ayuda_oc)
        Me.GroupBox2.Controls.Add(Me.txt_dua)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.cb_bodega)
        Me.GroupBox2.Controls.Add(Me.txt_unidades)
        Me.GroupBox2.Controls.Add(Me.txt_bultos)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.txt_producto)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 125)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'txt_reserva
        '
        Me.txt_reserva.BackColor = System.Drawing.Color.White
        Me.txt_reserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_reserva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_reserva.Location = New System.Drawing.Point(317, 17)
        Me.txt_reserva.MaxLength = 30
        Me.txt_reserva.Name = "txt_reserva"
        Me.txt_reserva.Size = New System.Drawing.Size(153, 22)
        Me.txt_reserva.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(230, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "No. Reserva:"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proveedor.Location = New System.Drawing.Point(317, 68)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(153, 21)
        Me.txt_proveedor.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Proveedor:"
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.White
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.ImageIndex = 3
        Me.btn_agregar.ImageList = Me.ImageList1
        Me.btn_agregar.Location = New System.Drawing.Point(480, 17)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(84, 97)
        Me.btn_agregar.TabIndex = 16
        Me.btn_agregar.Tag = "NUEVO"
        Me.btn_agregar.Text = "Actualizar producto"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Gear.ico")
        Me.ImageList1.Images.SetKeyName(1, "clear.png")
        Me.ImageList1.Images.SetKeyName(2, "116.png")
        Me.ImageList1.Images.SetKeyName(3, "Refresh48.png")
        '
        'btn_ayuda_oc
        '
        Me.btn_ayuda_oc.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_oc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_oc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_oc.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_oc.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda_oc.Location = New System.Drawing.Point(191, 17)
        Me.btn_ayuda_oc.Name = "btn_ayuda_oc"
        Me.btn_ayuda_oc.Size = New System.Drawing.Size(28, 22)
        Me.btn_ayuda_oc.TabIndex = 17
        Me.btn_ayuda_oc.Text = "..."
        Me.btn_ayuda_oc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ayuda_oc.UseVisualStyleBackColor = False
        '
        'txt_dua
        '
        Me.txt_dua.BackColor = System.Drawing.Color.White
        Me.txt_dua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dua.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dua.Location = New System.Drawing.Point(81, 17)
        Me.txt_dua.MaxLength = 30
        Me.txt_dua.Name = "txt_dua"
        Me.txt_dua.ReadOnly = True
        Me.txt_dua.Size = New System.Drawing.Size(111, 22)
        Me.txt_dua.TabIndex = 16
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(18, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 16)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "No. DUA:"
        '
        'txt_unidades
        '
        Me.txt_unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unidades.Location = New System.Drawing.Point(81, 93)
        Me.txt_unidades.Name = "txt_unidades"
        Me.txt_unidades.ReadOnly = True
        Me.txt_unidades.Size = New System.Drawing.Size(84, 21)
        Me.txt_unidades.TabIndex = 8
        '
        'txt_bultos
        '
        Me.txt_bultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bultos.Location = New System.Drawing.Point(317, 93)
        Me.txt_bultos.Name = "txt_bultos"
        Me.txt_bultos.ReadOnly = True
        Me.txt_bultos.Size = New System.Drawing.Size(84, 21)
        Me.txt_bultos.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(271, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Bultos:"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(81, 68)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(138, 21)
        Me.txt_descripcion.TabIndex = 4
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Location = New System.Drawing.Point(317, 43)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.ReadOnly = True
        Me.txt_producto.Size = New System.Drawing.Size(153, 21)
        Me.txt_producto.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(257, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Producto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(5, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Descripcion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(17, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Unidades:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btn_limpiar)
        Me.GroupBox1.Controls.Add(Me.btn_procesar)
        Me.GroupBox1.Location = New System.Drawing.Point(601, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 314)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 2
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(18, 214)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 75)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Cancelar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 1
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(19, 123)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(92, 75)
        Me.btn_limpiar.TabIndex = 18
        Me.btn_limpiar.Text = "Limpiar Información"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_procesar
        '
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_procesar.ImageIndex = 0
        Me.btn_procesar.ImageList = Me.ImageList1
        Me.btn_procesar.Location = New System.Drawing.Point(18, 32)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(92, 75)
        Me.btn_procesar.TabIndex = 16
        Me.btn_procesar.Text = "Procesar"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'frm_asocia_solicitud_reserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(741, 335)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_asocia_solicitud_reserva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Asignar Reserva a Solicitud .::"
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents cb_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_unidades As System.Windows.Forms.TextBox
    Friend WithEvents txt_bultos As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_oc As System.Windows.Forms.Button
    Friend WithEvents txt_dua As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_reserva As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
