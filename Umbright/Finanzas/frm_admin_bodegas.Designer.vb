<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_admin_bodegas
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
        Me.dgv_cambiarBodega = New System.Windows.Forms.DataGridView()
        Me.btnActualiza = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_cambiarBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_cambiarBodega)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 318)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgv_cambiarBodega
        '
        Me.dgv_cambiarBodega.AllowUserToAddRows = False
        Me.dgv_cambiarBodega.AllowUserToDeleteRows = False
        Me.dgv_cambiarBodega.AllowUserToOrderColumns = True
        Me.dgv_cambiarBodega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_cambiarBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_cambiarBodega.Location = New System.Drawing.Point(16, 24)
        Me.dgv_cambiarBodega.Name = "dgv_cambiarBodega"
        Me.dgv_cambiarBodega.RowHeadersWidth = 62
        Me.dgv_cambiarBodega.RowTemplate.Height = 28
        Me.dgv_cambiarBodega.Size = New System.Drawing.Size(671, 272)
        Me.dgv_cambiarBodega.TabIndex = 0
        '
        'btnActualiza
        '
        Me.btnActualiza.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualiza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnActualiza.Location = New System.Drawing.Point(752, 38)
        Me.btnActualiza.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnActualiza.Name = "btnActualiza"
        Me.btnActualiza.Size = New System.Drawing.Size(116, 57)
        Me.btnActualiza.TabIndex = 17
        Me.btnActualiza.Text = "Actualizar"
        Me.btnActualiza.UseVisualStyleBackColor = False
        '
        'frm_admin_bodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(888, 356)
        Me.Controls.Add(Me.btnActualiza)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_admin_bodegas"
        Me.Text = "Administración de Bodegas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_cambiarBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_cambiarBodega As DataGridView
    Friend WithEvents btnActualiza As Button
End Class
