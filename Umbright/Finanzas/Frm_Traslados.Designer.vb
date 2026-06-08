<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Traslados
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_tipodocto = New System.Windows.Forms.ComboBox()
        Me.txt_anio = New System.Windows.Forms.TextBox()
        Me.cmb_bodega = New System.Windows.Forms.ComboBox()
        Me.btn_traslado = New System.Windows.Forms.Button()
        Me.txt_cte = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.txt_numero_final = New System.Windows.Forms.TextBox()
        Me.txt_posiciones = New System.Windows.Forms.TextBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.txt_empresa = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_empresa_proveedor = New System.Windows.Forms.TextBox()
        Me.txt_proveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_tipo_compra = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerieFEL = New System.Windows.Forms.TextBox()
        Me.TxtNumeroFel = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No. Factura"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bodega"
        '
        'cmb_tipodocto
        '
        Me.cmb_tipodocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipodocto.FormattingEnabled = True
        Me.cmb_tipodocto.Location = New System.Drawing.Point(109, 85)
        Me.cmb_tipodocto.Name = "cmb_tipodocto"
        Me.cmb_tipodocto.Size = New System.Drawing.Size(207, 23)
        Me.cmb_tipodocto.TabIndex = 3
        '
        'txt_anio
        '
        Me.txt_anio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_anio.Location = New System.Drawing.Point(109, 114)
        Me.txt_anio.Name = "txt_anio"
        Me.txt_anio.Size = New System.Drawing.Size(27, 21)
        Me.txt_anio.TabIndex = 4
        '
        'cmb_bodega
        '
        Me.cmb_bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_bodega.FormattingEnabled = True
        Me.cmb_bodega.Location = New System.Drawing.Point(109, 142)
        Me.cmb_bodega.Name = "cmb_bodega"
        Me.cmb_bodega.Size = New System.Drawing.Size(207, 23)
        Me.cmb_bodega.TabIndex = 5
        '
        'btn_traslado
        '
        Me.btn_traslado.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_traslado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_traslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_traslado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_traslado.Location = New System.Drawing.Point(148, 186)
        Me.btn_traslado.Name = "btn_traslado"
        Me.btn_traslado.Size = New System.Drawing.Size(91, 32)
        Me.btn_traslado.TabIndex = 6
        Me.btn_traslado.Text = "Trasladar"
        Me.btn_traslado.UseVisualStyleBackColor = False
        '
        'txt_cte
        '
        Me.txt_cte.Location = New System.Drawing.Point(498, 19)
        Me.txt_cte.Name = "txt_cte"
        Me.txt_cte.ReadOnly = True
        Me.txt_cte.Size = New System.Drawing.Size(87, 20)
        Me.txt_cte.TabIndex = 7
        Me.txt_cte.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(439, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cliente"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(419, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ejecutivo"
        Me.Label5.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(570, 213)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(126, 20)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.Visible = False
        '
        'txt_numero
        '
        Me.txt_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(109, 114)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(203, 21)
        Me.txt_numero.TabIndex = 12
        Me.txt_numero.Visible = False
        '
        'txt_numero_final
        '
        Me.txt_numero_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_final.Location = New System.Drawing.Point(109, 114)
        Me.txt_numero_final.Name = "txt_numero_final"
        Me.txt_numero_final.Size = New System.Drawing.Size(207, 21)
        Me.txt_numero_final.TabIndex = 13
        '
        'txt_posiciones
        '
        Me.txt_posiciones.Location = New System.Drawing.Point(442, 213)
        Me.txt_posiciones.Name = "txt_posiciones"
        Me.txt_posiciones.Size = New System.Drawing.Size(100, 20)
        Me.txt_posiciones.TabIndex = 14
        Me.txt_posiciones.Visible = False
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(498, 85)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.ReadOnly = True
        Me.txt_vendedor.Size = New System.Drawing.Size(343, 20)
        Me.txt_vendedor.TabIndex = 15
        Me.txt_vendedor.Visible = False
        '
        'txt_empresa
        '
        Me.txt_empresa.Location = New System.Drawing.Point(591, 20)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.ReadOnly = True
        Me.txt_empresa.Size = New System.Drawing.Size(250, 20)
        Me.txt_empresa.TabIndex = 16
        Me.txt_empresa.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(337, 50)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 33)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Nuevo"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(105, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Compras Interempresas"
        '
        'txt_empresa_proveedor
        '
        Me.txt_empresa_proveedor.Location = New System.Drawing.Point(591, 53)
        Me.txt_empresa_proveedor.Name = "txt_empresa_proveedor"
        Me.txt_empresa_proveedor.ReadOnly = True
        Me.txt_empresa_proveedor.Size = New System.Drawing.Size(250, 20)
        Me.txt_empresa_proveedor.TabIndex = 19
        Me.txt_empresa_proveedor.Visible = False
        '
        'txt_proveedor
        '
        Me.txt_proveedor.Location = New System.Drawing.Point(498, 53)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(87, 20)
        Me.txt_proveedor.TabIndex = 20
        Me.txt_proveedor.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(419, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 18)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "proveedor"
        Me.Label7.Visible = False
        '
        'cmb_tipo_compra
        '
        Me.cmb_tipo_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipo_compra.FormattingEnabled = True
        Me.cmb_tipo_compra.Location = New System.Drawing.Point(109, 56)
        Me.cmb_tipo_compra.Name = "cmb_tipo_compra"
        Me.cmb_tipo_compra.Size = New System.Drawing.Size(207, 23)
        Me.cmb_tipo_compra.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 18)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Compra"
        '
        'txtSerieFEL
        '
        Me.txtSerieFEL.Location = New System.Drawing.Point(498, 114)
        Me.txtSerieFEL.Name = "txtSerieFEL"
        Me.txtSerieFEL.Size = New System.Drawing.Size(87, 20)
        Me.txtSerieFEL.TabIndex = 24
        Me.txtSerieFEL.Visible = False
        '
        'TxtNumeroFel
        '
        Me.TxtNumeroFel.Location = New System.Drawing.Point(591, 114)
        Me.TxtNumeroFel.Name = "TxtNumeroFel"
        Me.TxtNumeroFel.Size = New System.Drawing.Size(143, 20)
        Me.TxtNumeroFel.TabIndex = 24
        Me.TxtNumeroFel.Visible = False
        '
        'Frm_Traslados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(871, 245)
        Me.Controls.Add(Me.TxtNumeroFel)
        Me.Controls.Add(Me.txtSerieFEL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmb_tipo_compra)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_proveedor)
        Me.Controls.Add(Me.txt_empresa_proveedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txt_empresa)
        Me.Controls.Add(Me.txt_vendedor)
        Me.Controls.Add(Me.txt_posiciones)
        Me.Controls.Add(Me.txt_numero_final)
        Me.Controls.Add(Me.txt_numero)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_cte)
        Me.Controls.Add(Me.btn_traslado)
        Me.Controls.Add(Me.cmb_bodega)
        Me.Controls.Add(Me.txt_anio)
        Me.Controls.Add(Me.cmb_tipodocto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Traslados"
        Me.Text = ":: Traslados ::"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_anio As System.Windows.Forms.TextBox
    Friend WithEvents cmb_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents btn_traslado As System.Windows.Forms.Button
    Friend WithEvents txt_cte As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_final As System.Windows.Forms.TextBox
    Friend WithEvents txt_posiciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_empresa As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_empresa_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents cmb_tipodocto As System.Windows.Forms.ComboBox
    Protected WithEvents cmb_tipo_compra As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSerieFEL As TextBox
    Friend WithEvents TxtNumeroFel As TextBox
End Class
