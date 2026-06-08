<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Procesar_Pedidos_3pl
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
        Me.btn_BuscarArchivo3PL = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.btnProcesar3PL = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_BuscarArchivo3PL
        '
        Me.btn_BuscarArchivo3PL.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_BuscarArchivo3PL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_BuscarArchivo3PL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscarArchivo3PL.ForeColor = System.Drawing.Color.White
        Me.btn_BuscarArchivo3PL.Location = New System.Drawing.Point(528, 40)
        Me.btn_BuscarArchivo3PL.Name = "btn_BuscarArchivo3PL"
        Me.btn_BuscarArchivo3PL.Size = New System.Drawing.Size(109, 40)
        Me.btn_BuscarArchivo3PL.TabIndex = 0
        Me.btn_BuscarArchivo3PL.Text = "Buscar Archivo"
        Me.btn_BuscarArchivo3PL.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(39, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(483, 20)
        Me.TextBox1.TabIndex = 1
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToResizeRows = False
        Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(2, 145)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersWidth = 25
        Me.dgvProductos.Size = New System.Drawing.Size(1082, 255)
        Me.dgvProductos.TabIndex = 3
        '
        'btnProcesar3PL
        '
        Me.btnProcesar3PL.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesar3PL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesar3PL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar3PL.ForeColor = System.Drawing.Color.Transparent
        Me.btnProcesar3PL.Location = New System.Drawing.Point(791, 23)
        Me.btnProcesar3PL.Name = "btnProcesar3PL"
        Me.btnProcesar3PL.Size = New System.Drawing.Size(90, 57)
        Me.btnProcesar3PL.TabIndex = 4
        Me.btnProcesar3PL.Text = "Procesar"
        Me.btnProcesar3PL.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(39, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "GuateFacturas"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'frm_Procesar_Pedidos_3pl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1084, 412)
        Me.Controls.Add(Me.btnProcesar3PL)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_BuscarArchivo3PL)
        Me.Name = "frm_Procesar_Pedidos_3pl"
        Me.Text = "::. Procesar Pedidos 3PL .::"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscarArchivo3PL As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesar3PL As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
