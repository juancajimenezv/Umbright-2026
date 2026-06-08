<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Convierte_FactVentas_OC_SV
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
        Me.cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.cb_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.gb_Info = New System.Windows.Forms.GroupBox()
        Me.lb_Total = New System.Windows.Forms.Label()
        Me.lb_Fecha = New System.Windows.Forms.Label()
        Me.lb_Proveedor = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gb_Convertir = New System.Windows.Forms.GroupBox()
        Me.btn_Convertir = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_Numero = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lb_Bodega = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gb_Info.SuspendLayout()
        Me.gb_Convertir.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa:"
        '
        'cb_Empresa
        '
        Me.cb_Empresa.FormattingEnabled = True
        Me.cb_Empresa.Items.AddRange(New Object() {"CODICASA", "DIUVA", "DMARTE1"})
        Me.cb_Empresa.Location = New System.Drawing.Point(113, 21)
        Me.cb_Empresa.Name = "cb_Empresa"
        Me.cb_Empresa.Size = New System.Drawing.Size(153, 21)
        Me.cb_Empresa.TabIndex = 2
        '
        'cb_TipoDocto
        '
        Me.cb_TipoDocto.FormattingEnabled = True
        Me.cb_TipoDocto.Location = New System.Drawing.Point(113, 48)
        Me.cb_TipoDocto.Name = "cb_TipoDocto"
        Me.cb_TipoDocto.Size = New System.Drawing.Size(153, 21)
        Me.cb_TipoDocto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tipo Documento:"
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(113, 75)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(153, 20)
        Me.tb_Numero.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Número:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btn_Buscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cb_Empresa)
        Me.GroupBox1.Controls.Add(Me.tb_Numero)
        Me.GroupBox1.Controls.Add(Me.cb_TipoDocto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 128)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 298)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'btn_Buscar
        '
        Me.btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Buscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Buscar.Location = New System.Drawing.Point(272, 73)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Buscar.TabIndex = 5
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = False
        '
        'gb_Info
        '
        Me.gb_Info.Controls.Add(Me.lb_Bodega)
        Me.gb_Info.Controls.Add(Me.Label8)
        Me.gb_Info.Controls.Add(Me.lb_Total)
        Me.gb_Info.Controls.Add(Me.lb_Fecha)
        Me.gb_Info.Controls.Add(Me.lb_Proveedor)
        Me.gb_Info.Controls.Add(Me.Label6)
        Me.gb_Info.Controls.Add(Me.Label5)
        Me.gb_Info.Controls.Add(Me.Label4)
        Me.gb_Info.Location = New System.Drawing.Point(12, 146)
        Me.gb_Info.Name = "gb_Info"
        Me.gb_Info.Size = New System.Drawing.Size(391, 149)
        Me.gb_Info.TabIndex = 8
        Me.gb_Info.TabStop = False
        Me.gb_Info.Text = "Información"
        '
        'lb_Total
        '
        Me.lb_Total.AutoSize = True
        Me.lb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Total.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Total.Location = New System.Drawing.Point(93, 89)
        Me.lb_Total.Name = "lb_Total"
        Me.lb_Total.Size = New System.Drawing.Size(39, 15)
        Me.lb_Total.TabIndex = 5
        Me.lb_Total.Text = "Total"
        '
        'lb_Fecha
        '
        Me.lb_Fecha.AutoSize = True
        Me.lb_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Fecha.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Fecha.Location = New System.Drawing.Point(93, 58)
        Me.lb_Fecha.Name = "lb_Fecha"
        Me.lb_Fecha.Size = New System.Drawing.Size(46, 15)
        Me.lb_Fecha.TabIndex = 4
        Me.lb_Fecha.Text = "Fecha"
        '
        'lb_Proveedor
        '
        Me.lb_Proveedor.AutoSize = True
        Me.lb_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Proveedor.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Proveedor.Location = New System.Drawing.Point(93, 26)
        Me.lb_Proveedor.Name = "lb_Proveedor"
        Me.lb_Proveedor.Size = New System.Drawing.Size(52, 15)
        Me.lb_Proveedor.TabIndex = 3
        Me.lb_Proveedor.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cliente:"
        '
        'gb_Convertir
        '
        Me.gb_Convertir.Controls.Add(Me.lb_Numero)
        Me.gb_Convertir.Controls.Add(Me.Label7)
        Me.gb_Convertir.Controls.Add(Me.btn_Convertir)
        Me.gb_Convertir.Location = New System.Drawing.Point(12, 310)
        Me.gb_Convertir.Name = "gb_Convertir"
        Me.gb_Convertir.Size = New System.Drawing.Size(391, 134)
        Me.gb_Convertir.TabIndex = 9
        Me.gb_Convertir.TabStop = False
        '
        'btn_Convertir
        '
        Me.btn_Convertir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Convertir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Convertir.Location = New System.Drawing.Point(148, 83)
        Me.btn_Convertir.Name = "btn_Convertir"
        Me.btn_Convertir.Size = New System.Drawing.Size(75, 23)
        Me.btn_Convertir.TabIndex = 0
        Me.btn_Convertir.Text = "Convertir"
        Me.btn_Convertir.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(118, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Número de Orden de Compra:"
        '
        'lb_Numero
        '
        Me.lb_Numero.AutoSize = True
        Me.lb_Numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Numero.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Numero.Location = New System.Drawing.Point(158, 56)
        Me.lb_Numero.Name = "lb_Numero"
        Me.lb_Numero.Size = New System.Drawing.Size(58, 15)
        Me.lb_Numero.TabIndex = 6
        Me.lb_Numero.Text = "Número"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Bodega:"
        '
        'lb_Bodega
        '
        Me.lb_Bodega.AutoSize = True
        Me.lb_Bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Bodega.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb_Bodega.Location = New System.Drawing.Point(93, 118)
        Me.lb_Bodega.Name = "lb_Bodega"
        Me.lb_Bodega.Size = New System.Drawing.Size(56, 15)
        Me.lb_Bodega.TabIndex = 7
        Me.lb_Bodega.Text = "Bodega"
        '
        'frm_Convierte_FactVentas_OC_SV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(414, 456)
        Me.Controls.Add(Me.gb_Convertir)
        Me.Controls.Add(Me.gb_Info)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_Convierte_FactVentas_OC_SV"
        Me.Text = "Convierte Factura de Ventas a OC de SV"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_Info.ResumeLayout(False)
        Me.gb_Info.PerformLayout()
        Me.gb_Convertir.ResumeLayout(False)
        Me.gb_Convertir.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cb_Empresa As ComboBox
    Friend WithEvents cb_TipoDocto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_Numero As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_Buscar As Button
    Friend WithEvents gb_Info As GroupBox
    Friend WithEvents lb_Total As Label
    Friend WithEvents lb_Fecha As Label
    Friend WithEvents lb_Proveedor As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents gb_Convertir As GroupBox
    Friend WithEvents btn_Convertir As Button
    Friend WithEvents lb_Numero As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lb_Bodega As Label
    Friend WithEvents Label8 As Label
End Class
