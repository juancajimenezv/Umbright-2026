<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidacionCajaP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.cb_formaPago = New System.Windows.Forms.ComboBox()
        Me.txt_monto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.lb_tipodocto = New System.Windows.Forms.Label()
        Me.lb_numero = New System.Windows.Forms.Label()
        Me.lb_formaPago = New System.Windows.Forms.Label()
        Me.lb_empresa = New System.Windows.Forms.Label()
        Me.lb_lote = New System.Windows.Forms.Label()
        Me.lb_recibo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lb_pagos = New System.Windows.Forms.Label()
        Me.lb_totalDocto = New System.Windows.Forms.Label()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Agregar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_monto)
        Me.GroupBox1.Controls.Add(Me.cb_formaPago)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Condiciones de pago Disponibles"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgv_detalle)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 240)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(6, 13)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.Size = New System.Drawing.Size(418, 221)
        Me.dgv_detalle.TabIndex = 0
        '
        'cb_formaPago
        '
        Me.cb_formaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_formaPago.FormattingEnabled = True
        Me.cb_formaPago.Location = New System.Drawing.Point(53, 33)
        Me.cb_formaPago.Name = "cb_formaPago"
        Me.cb_formaPago.Size = New System.Drawing.Size(199, 21)
        Me.cb_formaPago.TabIndex = 0
        '
        'txt_monto
        '
        Me.txt_monto.Location = New System.Drawing.Point(308, 33)
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.Size = New System.Drawing.Size(113, 20)
        Me.txt_monto.TabIndex = 1
        Me.txt_monto.Text = "0.00"
        Me.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Monto:"
        '
        'btn_Agregar
        '
        Me.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Agregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Agregar.Location = New System.Drawing.Point(346, 59)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Agregar.TabIndex = 4
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = False
        '
        'lb_tipodocto
        '
        Me.lb_tipodocto.AutoSize = True
        Me.lb_tipodocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_tipodocto.Location = New System.Drawing.Point(86, 403)
        Me.lb_tipodocto.Name = "lb_tipodocto"
        Me.lb_tipodocto.Size = New System.Drawing.Size(79, 13)
        Me.lb_tipodocto.TabIndex = 3
        Me.lb_tipodocto.Text = "TIPODOCTO"
        Me.lb_tipodocto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lb_numero
        '
        Me.lb_numero.AutoSize = True
        Me.lb_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_numero.Location = New System.Drawing.Point(182, 404)
        Me.lb_numero.Name = "lb_numero"
        Me.lb_numero.Size = New System.Drawing.Size(61, 13)
        Me.lb_numero.TabIndex = 4
        Me.lb_numero.Text = "NUMERO"
        '
        'lb_formaPago
        '
        Me.lb_formaPago.AutoSize = True
        Me.lb_formaPago.Location = New System.Drawing.Point(167, 9)
        Me.lb_formaPago.Name = "lb_formaPago"
        Me.lb_formaPago.Size = New System.Drawing.Size(78, 13)
        Me.lb_formaPago.TabIndex = 5
        Me.lb_formaPago.Text = "FORMA PAGO"
        Me.lb_formaPago.Visible = False
        '
        'lb_empresa
        '
        Me.lb_empresa.AutoSize = True
        Me.lb_empresa.Location = New System.Drawing.Point(31, 9)
        Me.lb_empresa.Name = "lb_empresa"
        Me.lb_empresa.Size = New System.Drawing.Size(59, 13)
        Me.lb_empresa.TabIndex = 6
        Me.lb_empresa.Text = "EMPRESA"
        Me.lb_empresa.Visible = False
        '
        'lb_lote
        '
        Me.lb_lote.AutoSize = True
        Me.lb_lote.Location = New System.Drawing.Point(120, 9)
        Me.lb_lote.Name = "lb_lote"
        Me.lb_lote.Size = New System.Drawing.Size(35, 13)
        Me.lb_lote.TabIndex = 7
        Me.lb_lote.Text = "LOTE"
        Me.lb_lote.Visible = False
        '
        'lb_recibo
        '
        Me.lb_recibo.AutoSize = True
        Me.lb_recibo.Location = New System.Drawing.Point(232, 9)
        Me.lb_recibo.Name = "lb_recibo"
        Me.lb_recibo.Size = New System.Drawing.Size(47, 13)
        Me.lb_recibo.TabIndex = 8
        Me.lb_recibo.Text = "RECIBO"
        Me.lb_recibo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(273, 412)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Total Documento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(273, 390)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Total Pagos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 402)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Documento:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(167, 403)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "/"
        '
        'lb_pagos
        '
        Me.lb_pagos.AutoSize = True
        Me.lb_pagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_pagos.Location = New System.Drawing.Point(371, 390)
        Me.lb_pagos.Name = "lb_pagos"
        Me.lb_pagos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lb_pagos.Size = New System.Drawing.Size(32, 13)
        Me.lb_pagos.TabIndex = 13
        Me.lb_pagos.Text = "0.00"
        '
        'lb_totalDocto
        '
        Me.lb_totalDocto.AutoSize = True
        Me.lb_totalDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_totalDocto.Location = New System.Drawing.Point(372, 412)
        Me.lb_totalDocto.Name = "lb_totalDocto"
        Me.lb_totalDocto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lb_totalDocto.Size = New System.Drawing.Size(32, 13)
        Me.lb_totalDocto.TabIndex = 14
        Me.lb_totalDocto.Text = "0.00"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_guardar.Location = New System.Drawing.Point(358, 12)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 15
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'frmLiquidacionCajaP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(454, 438)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.lb_totalDocto)
        Me.Controls.Add(Me.lb_pagos)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lb_recibo)
        Me.Controls.Add(Me.lb_lote)
        Me.Controls.Add(Me.lb_empresa)
        Me.Controls.Add(Me.lb_formaPago)
        Me.Controls.Add(Me.lb_numero)
        Me.Controls.Add(Me.lb_tipodocto)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmLiquidacionCajaP"
        Me.Text = "Formas de Pago"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgv_detalle As DataGridView
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_monto As TextBox
    Friend WithEvents cb_formaPago As ComboBox
    Friend WithEvents lb_tipodocto As Label
    Friend WithEvents lb_numero As Label
    Friend WithEvents lb_formaPago As Label
    Friend WithEvents lb_empresa As Label
    Friend WithEvents lb_lote As Label
    Friend WithEvents lb_recibo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lb_pagos As Label
    Friend WithEvents lb_totalDocto As Label
    Friend WithEvents btn_guardar As Button
End Class
