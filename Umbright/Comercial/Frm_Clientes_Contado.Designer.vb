<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Clientes_Contado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Clientes_Contado))
        Me.tb_Cliente = New System.Windows.Forms.TextBox()
        Me.tb_Nit = New System.Windows.Forms.TextBox()
        Me.tb_RazonSocial = New System.Windows.Forms.TextBox()
        Me.tb_Giro = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Abrir = New System.Windows.Forms.Button()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_Comentario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cb_Grupo = New System.Windows.Forms.ComboBox()
        Me.cb_Tipo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Ruta = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_Contacto = New System.Windows.Forms.TextBox()
        Me.cb_ListaPrecio = New System.Windows.Forms.ComboBox()
        Me.cb_Condicion = New System.Windows.Forms.ComboBox()
        Me.cb_Vendedor = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_Vigencia = New System.Windows.Forms.ComboBox()
        Me.tb_Sucursal = New System.Windows.Forms.TextBox()
        Me.tb_Direccion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Ubicación = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_Telefono = New System.Windows.Forms.TextBox()
        Me.cb_Estado = New System.Windows.Forms.ComboBox()
        Me.cb_Region = New System.Windows.Forms.ComboBox()
        Me.cb_Comuna = New System.Windows.Forms.ComboBox()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Ubicación.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tb_Cliente
        '
        Me.tb_Cliente.Location = New System.Drawing.Point(77, 21)
        Me.tb_Cliente.Name = "tb_Cliente"
        Me.tb_Cliente.Size = New System.Drawing.Size(121, 20)
        Me.tb_Cliente.TabIndex = 0
        '
        'tb_Nit
        '
        Me.tb_Nit.Location = New System.Drawing.Point(77, 46)
        Me.tb_Nit.Name = "tb_Nit"
        Me.tb_Nit.Size = New System.Drawing.Size(121, 20)
        Me.tb_Nit.TabIndex = 1
        '
        'tb_RazonSocial
        '
        Me.tb_RazonSocial.Location = New System.Drawing.Point(77, 72)
        Me.tb_RazonSocial.Name = "tb_RazonSocial"
        Me.tb_RazonSocial.Size = New System.Drawing.Size(619, 20)
        Me.tb_RazonSocial.TabIndex = 2
        '
        'tb_Giro
        '
        Me.tb_Giro.Location = New System.Drawing.Point(77, 98)
        Me.tb_Giro.Name = "tb_Giro"
        Me.tb_Giro.Size = New System.Drawing.Size(619, 20)
        Me.tb_Giro.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Abrir)
        Me.GroupBox1.Controls.Add(Me.btn_Grabar)
        Me.GroupBox1.Controls.Add(Me.btn_Nuevo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_Giro)
        Me.GroupBox1.Controls.Add(Me.tb_Cliente)
        Me.GroupBox1.Controls.Add(Me.tb_RazonSocial)
        Me.GroupBox1.Controls.Add(Me.tb_Nit)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(702, 136)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'btn_Abrir
        '
        Me.btn_Abrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Abrir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Abrir.Location = New System.Drawing.Point(617, 26)
        Me.btn_Abrir.Name = "btn_Abrir"
        Me.btn_Abrir.Size = New System.Drawing.Size(75, 23)
        Me.btn_Abrir.TabIndex = 8
        Me.btn_Abrir.Text = "Abrir Doc."
        Me.btn_Abrir.UseVisualStyleBackColor = False
        '
        'btn_Grabar
        '
        Me.btn_Grabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Grabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Grabar.Location = New System.Drawing.Point(537, 26)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Grabar.TabIndex = 7
        Me.btn_Grabar.Text = "Grabar"
        Me.btn_Grabar.UseVisualStyleBackColor = False
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Nuevo.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btn_Nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Nuevo.Location = New System.Drawing.Point(455, 26)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_Nuevo.TabIndex = 6
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Giro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Razón Social"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Código Legal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.tb_Comentario)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cb_Grupo)
        Me.GroupBox2.Controls.Add(Me.cb_Tipo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cb_Ruta)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.tb_Contacto)
        Me.GroupBox2.Controls.Add(Me.cb_ListaPrecio)
        Me.GroupBox2.Controls.Add(Me.cb_Condicion)
        Me.GroupBox2.Controls.Add(Me.cb_Vendedor)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cb_Vigencia)
        Me.GroupBox2.Controls.Add(Me.tb_Sucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(702, 182)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Propiedades"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(269, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Comentario"
        '
        'tb_Comentario
        '
        Me.tb_Comentario.Location = New System.Drawing.Point(332, 78)
        Me.tb_Comentario.Multiline = True
        Me.tb_Comentario.Name = "tb_Comentario"
        Me.tb_Comentario.Size = New System.Drawing.Size(353, 95)
        Me.tb_Comentario.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(293, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Grupo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(502, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Tipo"
        '
        'cb_Grupo
        '
        Me.cb_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Grupo.FormattingEnabled = True
        Me.cb_Grupo.Location = New System.Drawing.Point(332, 44)
        Me.cb_Grupo.Name = "cb_Grupo"
        Me.cb_Grupo.Size = New System.Drawing.Size(157, 21)
        Me.cb_Grupo.TabIndex = 15
        '
        'cb_Tipo
        '
        Me.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Tipo.FormattingEnabled = True
        Me.cb_Tipo.Location = New System.Drawing.Point(533, 18)
        Me.cb_Tipo.Name = "cb_Tipo"
        Me.cb_Tipo.Size = New System.Drawing.Size(152, 21)
        Me.cb_Tipo.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(299, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Ruta"
        '
        'cb_Ruta
        '
        Me.cb_Ruta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Ruta.FormattingEnabled = True
        Me.cb_Ruta.Location = New System.Drawing.Point(332, 18)
        Me.cb_Ruta.Name = "cb_Ruta"
        Me.cb_Ruta.Size = New System.Drawing.Size(157, 21)
        Me.cb_Ruta.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Contacto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Lista De Precios"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Condición Pago"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Vendedor"
        '
        'tb_Contacto
        '
        Me.tb_Contacto.Location = New System.Drawing.Point(91, 153)
        Me.tb_Contacto.Name = "tb_Contacto"
        Me.tb_Contacto.Size = New System.Drawing.Size(160, 20)
        Me.tb_Contacto.TabIndex = 7
        '
        'cb_ListaPrecio
        '
        Me.cb_ListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ListaPrecio.FormattingEnabled = True
        Me.cb_ListaPrecio.Location = New System.Drawing.Point(92, 126)
        Me.cb_ListaPrecio.Name = "cb_ListaPrecio"
        Me.cb_ListaPrecio.Size = New System.Drawing.Size(159, 21)
        Me.cb_ListaPrecio.TabIndex = 6
        '
        'cb_Condicion
        '
        Me.cb_Condicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Condicion.FormattingEnabled = True
        Me.cb_Condicion.Location = New System.Drawing.Point(92, 99)
        Me.cb_Condicion.Name = "cb_Condicion"
        Me.cb_Condicion.Size = New System.Drawing.Size(159, 21)
        Me.cb_Condicion.TabIndex = 5
        '
        'cb_Vendedor
        '
        Me.cb_Vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Vendedor.FormattingEnabled = True
        Me.cb_Vendedor.Location = New System.Drawing.Point(91, 72)
        Me.cb_Vendedor.Name = "cb_Vendedor"
        Me.cb_Vendedor.Size = New System.Drawing.Size(160, 21)
        Me.cb_Vendedor.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Vigencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Sucursal"
        '
        'cb_Vigencia
        '
        Me.cb_Vigencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Vigencia.FormattingEnabled = True
        Me.cb_Vigencia.Location = New System.Drawing.Point(91, 45)
        Me.cb_Vigencia.Name = "cb_Vigencia"
        Me.cb_Vigencia.Size = New System.Drawing.Size(160, 21)
        Me.cb_Vigencia.TabIndex = 1
        '
        'tb_Sucursal
        '
        Me.tb_Sucursal.Location = New System.Drawing.Point(91, 19)
        Me.tb_Sucursal.Name = "tb_Sucursal"
        Me.tb_Sucursal.Size = New System.Drawing.Size(160, 20)
        Me.tb_Sucursal.TabIndex = 0
        '
        'tb_Direccion
        '
        Me.tb_Direccion.Location = New System.Drawing.Point(63, 19)
        Me.tb_Direccion.Name = "tb_Direccion"
        Me.tb_Direccion.Size = New System.Drawing.Size(633, 20)
        Me.tb_Direccion.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Dirección"
        '
        'Ubicación
        '
        Me.Ubicación.Controls.Add(Me.Label19)
        Me.Ubicación.Controls.Add(Me.Label18)
        Me.Ubicación.Controls.Add(Me.Label17)
        Me.Ubicación.Controls.Add(Me.Label16)
        Me.Ubicación.Controls.Add(Me.tb_Telefono)
        Me.Ubicación.Controls.Add(Me.cb_Estado)
        Me.Ubicación.Controls.Add(Me.cb_Region)
        Me.Ubicación.Controls.Add(Me.cb_Comuna)
        Me.Ubicación.Controls.Add(Me.Label14)
        Me.Ubicación.Controls.Add(Me.tb_Direccion)
        Me.Ubicación.Location = New System.Drawing.Point(12, 338)
        Me.Ubicación.Name = "Ubicación"
        Me.Ubicación.Size = New System.Drawing.Size(702, 104)
        Me.Ubicación.TabIndex = 6
        Me.Ubicación.TabStop = False
        Me.Ubicación.Text = "Ubicación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(537, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Telefono"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(223, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Estado"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(67, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Región"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(380, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Comuna"
        '
        'tb_Telefono
        '
        Me.tb_Telefono.Location = New System.Drawing.Point(534, 62)
        Me.tb_Telefono.Name = "tb_Telefono"
        Me.tb_Telefono.Size = New System.Drawing.Size(142, 20)
        Me.tb_Telefono.TabIndex = 23
        '
        'cb_Estado
        '
        Me.cb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Estado.FormattingEnabled = True
        Me.cb_Estado.Location = New System.Drawing.Point(219, 62)
        Me.cb_Estado.Name = "cb_Estado"
        Me.cb_Estado.Size = New System.Drawing.Size(142, 21)
        Me.cb_Estado.TabIndex = 22
        '
        'cb_Region
        '
        Me.cb_Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Region.FormattingEnabled = True
        Me.cb_Region.Location = New System.Drawing.Point(63, 62)
        Me.cb_Region.Name = "cb_Region"
        Me.cb_Region.Size = New System.Drawing.Size(142, 21)
        Me.cb_Region.TabIndex = 21
        '
        'cb_Comuna
        '
        Me.cb_Comuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Comuna.FormattingEnabled = True
        Me.cb_Comuna.Location = New System.Drawing.Point(376, 61)
        Me.cb_Comuna.Name = "cb_Comuna"
        Me.cb_Comuna.Size = New System.Drawing.Size(142, 21)
        Me.cb_Comuna.TabIndex = 20
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(12, 454)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.Size = New System.Drawing.Size(702, 31)
        Me.dgv_Detalle.TabIndex = 7
        '
        'Frm_Clientes_Contado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(726, 498)
        Me.Controls.Add(Me.dgv_Detalle)
        Me.Controls.Add(Me.Ubicación)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Clientes_Contado"
        Me.Text = "Creación, Actualización y Sincronización de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Ubicación.ResumeLayout(False)
        Me.Ubicación.PerformLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tb_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents tb_Nit As System.Windows.Forms.TextBox
    Friend WithEvents tb_RazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents tb_Giro As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_Contacto As System.Windows.Forms.TextBox
    Friend WithEvents cb_ListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Condicion As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_Vigencia As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tb_Comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tb_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cb_Grupo As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_Ruta As System.Windows.Forms.ComboBox
    Friend WithEvents Ubicación As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents cb_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Region As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Comuna As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Abrir As System.Windows.Forms.Button
    Friend WithEvents dgv_Detalle As DataGridView
End Class
