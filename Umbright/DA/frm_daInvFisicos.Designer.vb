<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_daInvFisicos
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
        Me.tabs = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_productos = New System.Windows.Forms.DataGridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dg_historial_detalle = New System.Windows.Forms.DataGridView
        Me.dg_historial = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnReportes = New System.Windows.Forms.Button
        Me.dg_reporte = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fechaFinal = New System.Windows.Forms.MonthCalendar
        Me.fechaInicial = New System.Windows.Forms.MonthCalendar
        Me.btnDuaDetalle = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.txFecha = New System.Windows.Forms.MaskedTextBox
        Me.txDescripcion = New System.Windows.Forms.TextBox
        Me.lblDesc = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.tabs.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_historial_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_historial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dg_reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabs
        '
        Me.tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabs.Controls.Add(Me.TabPage2)
        Me.tabs.Controls.Add(Me.TabPage1)
        Me.tabs.Controls.Add(Me.TabPage3)
        Me.tabs.Location = New System.Drawing.Point(12, 51)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(1064, 509)
        Me.tabs.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LemonChiffon
        Me.TabPage2.Controls.Add(Me.dg_productos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1056, 483)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Productos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dg_productos
        '
        Me.dg_productos.AllowUserToAddRows = False
        Me.dg_productos.AllowUserToDeleteRows = False
        Me.dg_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos.Location = New System.Drawing.Point(0, 0)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.Size = New System.Drawing.Size(1060, 483)
        Me.dg_productos.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dg_historial_detalle)
        Me.TabPage1.Controls.Add(Me.dg_historial)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1056, 483)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Histórico"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dg_historial_detalle
        '
        Me.dg_historial_detalle.AllowUserToAddRows = False
        Me.dg_historial_detalle.AllowUserToDeleteRows = False
        Me.dg_historial_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_historial_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_historial_detalle.Location = New System.Drawing.Point(3, 229)
        Me.dg_historial_detalle.Name = "dg_historial_detalle"
        Me.dg_historial_detalle.ReadOnly = True
        Me.dg_historial_detalle.Size = New System.Drawing.Size(1050, 258)
        Me.dg_historial_detalle.TabIndex = 1
        '
        'dg_historial
        '
        Me.dg_historial.AllowUserToAddRows = False
        Me.dg_historial.AllowUserToDeleteRows = False
        Me.dg_historial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_historial.Location = New System.Drawing.Point(3, 3)
        Me.dg_historial.Name = "dg_historial"
        Me.dg_historial.ReadOnly = True
        Me.dg_historial.Size = New System.Drawing.Size(1050, 227)
        Me.dg_historial.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnReportes)
        Me.TabPage3.Controls.Add(Me.dg_reporte)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.fechaFinal)
        Me.TabPage3.Controls.Add(Me.fechaInicial)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1056, 483)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Reporte"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Location = New System.Drawing.Point(105, 428)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(75, 23)
        Me.btnReportes.TabIndex = 6
        Me.btnReportes.Text = "Generar"
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'dg_reporte
        '
        Me.dg_reporte.AllowUserToAddRows = False
        Me.dg_reporte.AllowUserToDeleteRows = False
        Me.dg_reporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_reporte.Location = New System.Drawing.Point(192, 3)
        Me.dg_reporte.Name = "dg_reporte"
        Me.dg_reporte.ReadOnly = True
        Me.dg_reporte.Size = New System.Drawing.Size(861, 477)
        Me.dg_reporte.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Inicial"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fechaFinal
        '
        Me.fechaFinal.Location = New System.Drawing.Point(9, 261)
        Me.fechaFinal.Name = "fechaFinal"
        Me.fechaFinal.TabIndex = 2
        '
        'fechaInicial
        '
        Me.fechaInicial.Location = New System.Drawing.Point(9, 51)
        Me.fechaInicial.Name = "fechaInicial"
        Me.fechaInicial.TabIndex = 1
        '
        'btnDuaDetalle
        '
        Me.btnDuaDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDuaDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnDuaDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDuaDetalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnDuaDetalle.ForeColor = System.Drawing.Color.White
        Me.btnDuaDetalle.Location = New System.Drawing.Point(785, 12)
        Me.btnDuaDetalle.Name = "btnDuaDetalle"
        Me.btnDuaDetalle.Size = New System.Drawing.Size(113, 33)
        Me.btnDuaDetalle.TabIndex = 2
        Me.btnDuaDetalle.Text = "Ver Productos"
        Me.btnDuaDetalle.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(991, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 33)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(904, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(81, 33)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'txFecha
        '
        Me.txFecha.Location = New System.Drawing.Point(242, 12)
        Me.txFecha.Mask = "00/00/0000"
        Me.txFecha.Name = "txFecha"
        Me.txFecha.Size = New System.Drawing.Size(81, 20)
        Me.txFecha.TabIndex = 5
        Me.txFecha.ValidatingType = GetType(Date)
        '
        'txDescripcion
        '
        Me.txDescripcion.Location = New System.Drawing.Point(82, 12)
        Me.txDescripcion.Name = "txDescripcion"
        Me.txDescripcion.Size = New System.Drawing.Size(100, 20)
        Me.txDescripcion.TabIndex = 6
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(16, 15)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(66, 13)
        Me.lblDesc.TabIndex = 7
        Me.lblDesc.Text = "Descripción:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(194, 15)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 8
        Me.lblFecha.Text = "Fecha:"
        '
        'frm_daInvFisicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1088, 572)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txDescripcion)
        Me.Controls.Add(Me.txFecha)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnDuaDetalle)
        Me.Controls.Add(Me.tabs)
        Me.Name = "frm_daInvFisicos"
        Me.Text = "Inventarios Físicos"
        Me.tabs.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dg_historial_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_historial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dg_reporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents btnDuaDetalle As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dg_historial As System.Windows.Forms.DataGridView
    Friend WithEvents dg_historial_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fechaFinal As System.Windows.Forms.MonthCalendar
    Friend WithEvents fechaInicial As System.Windows.Forms.MonthCalendar
    Friend WithEvents dg_reporte As System.Windows.Forms.DataGridView
    Friend WithEvents btnReportes As System.Windows.Forms.Button

End Class
