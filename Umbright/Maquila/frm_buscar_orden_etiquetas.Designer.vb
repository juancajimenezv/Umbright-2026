<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_orden_etiquetas
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
        Me.dgv_ordenes_fecha = New System.Windows.Forms.DataGridView
        Me.Fecha = New System.Windows.Forms.Label
        Me.dtp_fecha_buscar = New System.Windows.Forms.DateTimePicker
        CType(Me.dgv_ordenes_fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_ordenes_fecha
        '
        Me.dgv_ordenes_fecha.AllowUserToAddRows = False
        Me.dgv_ordenes_fecha.AllowUserToDeleteRows = False
        Me.dgv_ordenes_fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ordenes_fecha.Location = New System.Drawing.Point(12, 56)
        Me.dgv_ordenes_fecha.Name = "dgv_ordenes_fecha"
        Me.dgv_ordenes_fecha.ReadOnly = True
        Me.dgv_ordenes_fecha.Size = New System.Drawing.Size(760, 251)
        Me.dgv_ordenes_fecha.TabIndex = 0
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(12, 21)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(109, 13)
        Me.Fecha.TabIndex = 1
        Me.Fecha.Text = "Fecha de Produccion"
        '
        'dtp_fecha_buscar
        '
        Me.dtp_fecha_buscar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_buscar.Location = New System.Drawing.Point(127, 14)
        Me.dtp_fecha_buscar.Name = "dtp_fecha_buscar"
        Me.dtp_fecha_buscar.Size = New System.Drawing.Size(84, 20)
        Me.dtp_fecha_buscar.TabIndex = 2
        '
        'frm_buscar_orden_etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 319)
        Me.Controls.Add(Me.dtp_fecha_buscar)
        Me.Controls.Add(Me.Fecha)
        Me.Controls.Add(Me.dgv_ordenes_fecha)
        Me.Name = "frm_buscar_orden_etiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Orden Etiquetas"
        CType(Me.dgv_ordenes_fecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_ordenes_fecha As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_buscar As System.Windows.Forms.DateTimePicker
End Class
