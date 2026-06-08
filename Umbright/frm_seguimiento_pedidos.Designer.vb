<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_seguimiento_pedidos
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
        Me.Btn_Buscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Buscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.White
        Me.Btn_Buscar.Location = New System.Drawing.Point(280, 12)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Buscar.TabIndex = 11
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(144, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Del"
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(168, 12)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final.TabIndex = 8
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(40, 12)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio.TabIndex = 7
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AllowUserToOrderColumns = True
        Me.dgv_pedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(12, 77)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.Size = New System.Drawing.Size(691, 529)
        Me.dgv_pedidos.TabIndex = 12
        '
        'frm_seguimiento_pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(715, 618)
        Me.Controls.Add(Me.dgv_pedidos)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fecha_final)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Name = "frm_seguimiento_pedidos"
        Me.Text = "frm_seguimiento_pedidos"
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
End Class
