<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImpresionFacturasAreas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpresionFacturasAreas))
        Me.dgv_pedidosFACE = New System.Windows.Forms.DataGridView()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnImprimirRecibos = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias = New System.Windows.Forms.NumericUpDown()
        Me.dtp_fel_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fel_final = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_tipo_impresion = New System.Windows.Forms.Label()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.btnActualizarFacturacion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.chkboxpedientes = New System.Windows.Forms.CheckBox()
        Me.btnTrasladar = New System.Windows.Forms.Button()
        Me.cmbTrasladarArea = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnImpresionFEL_PDF = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_pedidosFACE
        '
        Me.dgv_pedidosFACE.AllowUserToAddRows = False
        Me.dgv_pedidosFACE.AllowUserToDeleteRows = False
        Me.dgv_pedidosFACE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidosFACE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pedidosFACE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_pedidosFACE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_pedidosFACE.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_pedidosFACE.Location = New System.Drawing.Point(3, 150)
        Me.dgv_pedidosFACE.Name = "dgv_pedidosFACE"
        Me.dgv_pedidosFACE.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pedidosFACE.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_pedidosFACE.RowHeadersWidth = 62
        Me.dgv_pedidosFACE.Size = New System.Drawing.Size(1285, 460)
        Me.dgv_pedidosFACE.TabIndex = 1
        '
        'btnReimpresionNC
        '
        Me.btnReimpresionNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReimpresionNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimpresionNC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimpresionNC.ForeColor = System.Drawing.Color.White
        Me.btnReimpresionNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimpresionNC.ImageIndex = 4
        Me.btnReimpresionNC.ImageList = Me.ImageList1
        Me.btnReimpresionNC.Location = New System.Drawing.Point(1088, 62)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 74)
        Me.btnReimpresionNC.TabIndex = 7
        Me.btnReimpresionNC.Text = "Impresión FEL"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Text-Edit-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Smart-FTP-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        Me.ImageList1.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(4, "printer_48.png")
        Me.ImageList1.Images.SetKeyName(5, "cut_from_page.ico")
        '
        'btnImprimirRecibos
        '
        Me.btnImprimirRecibos.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirRecibos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirRecibos.ForeColor = System.Drawing.Color.White
        Me.btnImprimirRecibos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirRecibos.ImageIndex = 3
        Me.btnImprimirRecibos.ImageList = Me.ImageList2
        Me.btnImprimirRecibos.Location = New System.Drawing.Point(1185, 62)
        Me.btnImprimirRecibos.Name = "btnImprimirRecibos"
        Me.btnImprimirRecibos.Size = New System.Drawing.Size(96, 74)
        Me.btnImprimirRecibos.TabIndex = 8
        Me.btnImprimirRecibos.Text = "Impresión Recibos"
        Me.btnImprimirRecibos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirRecibos.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "7.png")
        Me.ImageList2.Images.SetKeyName(1, "3.png")
        Me.ImageList2.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList2.Images.SetKeyName(3, "print_48.png")
        Me.ImageList2.Images.SetKeyName(4, "Floppy-64.png")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(816, 106)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias
        '
        Me.nupCopias.Location = New System.Drawing.Point(930, 104)
        Me.nupCopias.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nupCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias.Name = "nupCopias"
        Me.nupCopias.Size = New System.Drawing.Size(37, 20)
        Me.nupCopias.TabIndex = 79
        Me.nupCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtp_fel_inicio
        '
        Me.dtp_fel_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_inicio.Location = New System.Drawing.Point(124, 70)
        Me.dtp_fel_inicio.Name = "dtp_fel_inicio"
        Me.dtp_fel_inicio.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_inicio.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Fecha Final"
        '
        'dtp_fel_final
        '
        Me.dtp_fel_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fel_final.Location = New System.Drawing.Point(124, 96)
        Me.dtp_fel_final.Name = "dtp_fel_final"
        Me.dtp_fel_final.Size = New System.Drawing.Size(89, 20)
        Me.dtp_fel_final.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Fecha Inicio"
        '
        'lbl_tipo_impresion
        '
        Me.lbl_tipo_impresion.AutoSize = True
        Me.lbl_tipo_impresion.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_impresion.Location = New System.Drawing.Point(454, 9)
        Me.lbl_tipo_impresion.Name = "lbl_tipo_impresion"
        Me.lbl_tipo_impresion.Size = New System.Drawing.Size(446, 32)
        Me.lbl_tipo_impresion.TabIndex = 83
        Me.lbl_tipo_impresion.Text = "Centro de Impresion Documentos"
        '
        'lblTipoPago
        '
        Me.lblTipoPago.AutoSize = True
        Me.lblTipoPago.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.Location = New System.Drawing.Point(514, 41)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(164, 32)
        Me.lblTipoPago.TabIndex = 84
        Me.lblTipoPago.Text = "lblTipoPago"
        Me.lblTipoPago.Visible = False
        '
        'btnActualizarFacturacion
        '
        Me.btnActualizarFacturacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualizarFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarFacturacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnActualizarFacturacion.ForeColor = System.Drawing.Color.White
        Me.btnActualizarFacturacion.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnActualizarFacturacion.ImageIndex = 2
        Me.btnActualizarFacturacion.ImageList = Me.ImageList1
        Me.btnActualizarFacturacion.Location = New System.Drawing.Point(229, 66)
        Me.btnActualizarFacturacion.Name = "btnActualizarFacturacion"
        Me.btnActualizarFacturacion.Size = New System.Drawing.Size(122, 53)
        Me.btnActualizarFacturacion.TabIndex = 85
        Me.btnActualizarFacturacion.Text = "Obtener Información"
        Me.btnActualizarFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarFacturacion.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Centro de Impresion"
        '
        'cmbArea
        '
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(124, 122)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(227, 21)
        Me.cmbArea.TabIndex = 86
        '
        'chkboxpedientes
        '
        Me.chkboxpedientes.AutoSize = True
        Me.chkboxpedientes.Location = New System.Drawing.Point(819, 131)
        Me.chkboxpedientes.Name = "chkboxpedientes"
        Me.chkboxpedientes.Size = New System.Drawing.Size(132, 17)
        Me.chkboxpedientes.TabIndex = 87
        Me.chkboxpedientes.Text = "Pendientes de Imprimir"
        Me.chkboxpedientes.UseVisualStyleBackColor = True
        '
        'btnTrasladar
        '
        Me.btnTrasladar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnTrasladar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrasladar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnTrasladar.ForeColor = System.Drawing.Color.White
        Me.btnTrasladar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTrasladar.ImageIndex = 1
        Me.btnTrasladar.ImageList = Me.ImageList1
        Me.btnTrasladar.Location = New System.Drawing.Point(678, 75)
        Me.btnTrasladar.Name = "btnTrasladar"
        Me.btnTrasladar.Size = New System.Drawing.Size(101, 47)
        Me.btnTrasladar.TabIndex = 78
        Me.btnTrasladar.Text = "Trasladar"
        Me.btnTrasladar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTrasladar.UseVisualStyleBackColor = False
        '
        'cmbTrasladarArea
        '
        Me.cmbTrasladarArea.FormattingEnabled = True
        Me.cmbTrasladarArea.Location = New System.Drawing.Point(562, 123)
        Me.cmbTrasladarArea.Name = "cmbTrasladarArea"
        Me.cmbTrasladarArea.Size = New System.Drawing.Size(217, 21)
        Me.cmbTrasladarArea.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(559, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Centro de Impresion"
        '
        'btnImpresionFEL_PDF
        '
        Me.btnImpresionFEL_PDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImpresionFEL_PDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresionFEL_PDF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpresionFEL_PDF.ForeColor = System.Drawing.Color.White
        Me.btnImpresionFEL_PDF.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImpresionFEL_PDF.ImageIndex = 0
        Me.btnImpresionFEL_PDF.ImageList = Me.ImageList1
        Me.btnImpresionFEL_PDF.Location = New System.Drawing.Point(991, 61)
        Me.btnImpresionFEL_PDF.Name = "btnImpresionFEL_PDF"
        Me.btnImpresionFEL_PDF.Size = New System.Drawing.Size(91, 74)
        Me.btnImpresionFEL_PDF.TabIndex = 7
        Me.btnImpresionFEL_PDF.Text = "Impresión FEL PDF"
        Me.btnImpresionFEL_PDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImpresionFEL_PDF.UseVisualStyleBackColor = False
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Seleccione Destino de la Informacion"
        '
        'frmImpresionFacturasAreas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 622)
        Me.Controls.Add(Me.chkboxpedientes)
        Me.Controls.Add(Me.cmbTrasladarArea)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.btnActualizarFacturacion)
        Me.Controls.Add(Me.lblTipoPago)
        Me.Controls.Add(Me.lbl_tipo_impresion)
        Me.Controls.Add(Me.btnTrasladar)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.nupCopias)
        Me.Controls.Add(Me.dtp_fel_inicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp_fel_final)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImpresionFEL_PDF)
        Me.Controls.Add(Me.btnReimpresionNC)
        Me.Controls.Add(Me.btnImprimirRecibos)
        Me.Controls.Add(Me.dgv_pedidosFACE)
        Me.Name = "frmImpresionFacturasAreas"
        Me.Text = "Impresión de Documentos"
        CType(Me.dgv_pedidosFACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_pedidosFACE As DataGridView
    Friend WithEvents btnReimpresionNC As Button
    Friend WithEvents btnImprimirRecibos As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias As NumericUpDown
    Friend WithEvents dtp_fel_inicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp_fel_final As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_tipo_impresion As Label
    Friend WithEvents lblTipoPago As Label
    Friend WithEvents btnActualizarFacturacion As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbArea As ComboBox
    Friend WithEvents chkboxpedientes As CheckBox
    Friend WithEvents btnTrasladar As Button
    Friend WithEvents cmbTrasladarArea As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnImpresionFEL_PDF As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
