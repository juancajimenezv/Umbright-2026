<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoCreditoTmk
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
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.gvPedidos = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.chkSelTodos = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias_fel = New System.Windows.Forms.NumericUpDown()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnGenerarTXTNC = New System.Windows.Forms.Button()
        Me.btnObtener = New System.Windows.Forms.Button()
        CType(Me.gvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(12, 22)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha:"
        '
        'dtFecha
        '
        Me.dtFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(58, 19)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtFecha.TabIndex = 1
        '
        'gvPedidos
        '
        Me.gvPedidos.AllowUserToAddRows = False
        Me.gvPedidos.AllowUserToDeleteRows = False
        Me.gvPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPedidos.Location = New System.Drawing.Point(12, 86)
        Me.gvPedidos.Name = "gvPedidos"
        Me.gvPedidos.Size = New System.Drawing.Size(919, 326)
        Me.gvPedidos.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(856, 419)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'chkSelTodos
        '
        Me.chkSelTodos.AutoSize = True
        Me.chkSelTodos.Location = New System.Drawing.Point(15, 46)
        Me.chkSelTodos.Name = "chkSelTodos"
        Me.chkSelTodos.Size = New System.Drawing.Size(105, 17)
        Me.chkSelTodos.TabIndex = 6
        Me.chkSelTodos.Text = "Seleccionr todos"
        Me.chkSelTodos.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(712, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias_fel
        '
        Me.nupCopias_fel.Location = New System.Drawing.Point(735, 35)
        Me.nupCopias_fel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias_fel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias_fel.Name = "nupCopias_fel"
        Me.nupCopias_fel.Size = New System.Drawing.Size(37, 20)
        Me.nupCopias_fel.TabIndex = 76
        Me.nupCopias_fel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnReimpresionNC
        '
        Me.btnReimpresionNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionNC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimpresionNC.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionNC.Image = Global.Umbright.My.Resources.Resources.imprimir_32
        Me.btnReimpresionNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionNC.Location = New System.Drawing.Point(840, 6)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 74)
        Me.btnReimpresionNC.TabIndex = 74
        Me.btnReimpresionNC.Text = "ReImpresion"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnular.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnular.ForeColor = System.Drawing.Color.White
        Me.btnAnular.Image = Global.Umbright.My.Resources.Resources.anular_32
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(483, 7)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(96, 73)
        Me.btnAnular.TabIndex = 78
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'btnGenerarTXTNC
        '
        Me.btnGenerarTXTNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarTXTNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarTXTNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarTXTNC.ForeColor = System.Drawing.Color.White
        Me.btnGenerarTXTNC.Image = Global.Umbright.My.Resources.Resources.gen_32
        Me.btnGenerarTXTNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarTXTNC.Location = New System.Drawing.Point(378, 6)
        Me.btnGenerarTXTNC.Name = "btnGenerarTXTNC"
        Me.btnGenerarTXTNC.Size = New System.Drawing.Size(96, 73)
        Me.btnGenerarTXTNC.TabIndex = 77
        Me.btnGenerarTXTNC.Text = "Generar"
        Me.btnGenerarTXTNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarTXTNC.UseVisualStyleBackColor = False
        '
        'btnObtener
        '
        Me.btnObtener.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtener.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnObtener.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnObtener.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnObtener.Image = Global.Umbright.My.Resources.Resources.lupa_32
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtener.Location = New System.Drawing.Point(271, 5)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(96, 73)
        Me.btnObtener.TabIndex = 2
        Me.btnObtener.Text = "Obtener informacion"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtener.UseVisualStyleBackColor = False
        '
        'frmPedidoCreditoTmk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 450)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnGenerarTXTNC)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.nupCopias_fel)
        Me.Controls.Add(Me.btnReimpresionNC)
        Me.Controls.Add(Me.chkSelTodos)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gvPedidos)
        Me.Controls.Add(Me.btnObtener)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.lblFecha)
        Me.Name = "frmPedidoCreditoTmk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos al credito TMK"
        CType(Me.gvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFecha As Label
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents btnObtener As Button
    Friend WithEvents gvPedidos As DataGridView
    Friend WithEvents btnSalir As Button
    Friend WithEvents chkSelTodos As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias_fel As NumericUpDown
    Friend WithEvents btnReimpresionNC As Button
    Friend WithEvents btnGenerarTXTNC As Button
    Friend WithEvents btnAnular As Button
End Class
