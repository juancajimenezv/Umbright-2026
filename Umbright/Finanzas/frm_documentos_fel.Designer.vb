<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_documentos_fel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_documentos_fel))
        Me.lblTipoDocto = New System.Windows.Forms.Label()
        Me.dboTipoDocto = New System.Windows.Forms.ComboBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.grvDoctos = New System.Windows.Forms.DataGridView()
        Me.chkSelTodos = New System.Windows.Forms.CheckBox()
        Me.btnObtenerNC = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGenerarTXTNC = New System.Windows.Forms.Button()
        Me.btnReimpresionNC = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.nupCopias_fel = New System.Windows.Forms.NumericUpDown()
        Me.btnXmlWM = New System.Windows.Forms.Button()
        CType(Me.grvDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTipoDocto
        '
        Me.lblTipoDocto.AutoSize = True
        Me.lblTipoDocto.Location = New System.Drawing.Point(12, 9)
        Me.lblTipoDocto.Name = "lblTipoDocto"
        Me.lblTipoDocto.Size = New System.Drawing.Size(107, 13)
        Me.lblTipoDocto.TabIndex = 0
        Me.lblTipoDocto.Text = "Tipo de documentos:"
        '
        'dboTipoDocto
        '
        Me.dboTipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dboTipoDocto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dboTipoDocto.FormattingEnabled = True
        Me.dboTipoDocto.Items.AddRange(New Object() {"PEDIDO FEL RE", "NC-FEL-DEVOLUCION", "NC-FEL-DIFERENCIA", "NOTA DE ABONO", "NOTA DE ABONO CTE", "NC-ABONO-CTE", "NC-DIFERENCIA-CT"})
        Me.dboTipoDocto.Location = New System.Drawing.Point(125, 6)
        Me.dboTipoDocto.Name = "dboTipoDocto"
        Me.dboTipoDocto.Size = New System.Drawing.Size(168, 21)
        Me.dboTipoDocto.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(12, 37)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha:"
        '
        'dtFecha
        '
        Me.dtFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(125, 35)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(104, 20)
        Me.dtFecha.TabIndex = 3
        '
        'grvDoctos
        '
        Me.grvDoctos.AllowUserToAddRows = False
        Me.grvDoctos.AllowUserToDeleteRows = False
        Me.grvDoctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grvDoctos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvDoctos.Location = New System.Drawing.Point(2, 82)
        Me.grvDoctos.Name = "grvDoctos"
        Me.grvDoctos.RowHeadersWidth = 20
        Me.grvDoctos.Size = New System.Drawing.Size(1284, 483)
        Me.grvDoctos.TabIndex = 5
        '
        'chkSelTodos
        '
        Me.chkSelTodos.AutoSize = True
        Me.chkSelTodos.Location = New System.Drawing.Point(15, 63)
        Me.chkSelTodos.Name = "chkSelTodos"
        Me.chkSelTodos.Size = New System.Drawing.Size(111, 17)
        Me.chkSelTodos.TabIndex = 8
        Me.chkSelTodos.Text = "Seleccionar todos"
        Me.chkSelTodos.UseVisualStyleBackColor = True
        '
        'btnObtenerNC
        '
        Me.btnObtenerNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtenerNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnObtenerNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnObtenerNC.ForeColor = System.Drawing.Color.White
        Me.btnObtenerNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtenerNC.ImageIndex = 2
        Me.btnObtenerNC.ImageList = Me.ImageList1
        Me.btnObtenerNC.Location = New System.Drawing.Point(323, 6)
        Me.btnObtenerNC.Name = "btnObtenerNC"
        Me.btnObtenerNC.Size = New System.Drawing.Size(96, 74)
        Me.btnObtenerNC.TabIndex = 68
        Me.btnObtenerNC.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Información"
        Me.btnObtenerNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtenerNC.UseVisualStyleBackColor = False
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
        'btnGenerarTXTNC
        '
        Me.btnGenerarTXTNC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarTXTNC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarTXTNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarTXTNC.ForeColor = System.Drawing.Color.White
        Me.btnGenerarTXTNC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarTXTNC.ImageIndex = 3
        Me.btnGenerarTXTNC.ImageList = Me.ImageList1
        Me.btnGenerarTXTNC.Location = New System.Drawing.Point(443, 6)
        Me.btnGenerarTXTNC.Name = "btnGenerarTXTNC"
        Me.btnGenerarTXTNC.Size = New System.Drawing.Size(96, 74)
        Me.btnGenerarTXTNC.TabIndex = 69
        Me.btnGenerarTXTNC.Text = "Generar"
        Me.btnGenerarTXTNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarTXTNC.UseVisualStyleBackColor = False
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
        Me.btnReimpresionNC.Location = New System.Drawing.Point(1137, 6)
        Me.btnReimpresionNC.Name = "btnReimpresionNC"
        Me.btnReimpresionNC.Size = New System.Drawing.Size(91, 74)
        Me.btnReimpresionNC.TabIndex = 70
        Me.btnReimpresionNC.Text = "ReImpresion"
        Me.btnReimpresionNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimpresionNC.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(1009, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Numero de Copias"
        '
        'nupCopias_fel
        '
        Me.nupCopias_fel.Location = New System.Drawing.Point(1032, 35)
        Me.nupCopias_fel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nupCopias_fel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupCopias_fel.Name = "nupCopias_fel"
        Me.nupCopias_fel.Size = New System.Drawing.Size(37, 20)
        Me.nupCopias_fel.TabIndex = 73
        Me.nupCopias_fel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnXmlWM
        '
        Me.btnXmlWM.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnXmlWM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXmlWM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXmlWM.ForeColor = System.Drawing.Color.White
        Me.btnXmlWM.Image = CType(resources.GetObject("btnXmlWM.Image"), System.Drawing.Image)
        Me.btnXmlWM.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnXmlWM.Location = New System.Drawing.Point(563, 6)
        Me.btnXmlWM.Name = "btnXmlWM"
        Me.btnXmlWM.Size = New System.Drawing.Size(96, 74)
        Me.btnXmlWM.TabIndex = 74
        Me.btnXmlWM.Text = "XML Walmart"
        Me.btnXmlWM.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnXmlWM.UseVisualStyleBackColor = False
        '
        'frm_documentos_fel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1298, 610)
        Me.Controls.Add(Me.btnXmlWM)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.nupCopias_fel)
        Me.Controls.Add(Me.btnReimpresionNC)
        Me.Controls.Add(Me.btnGenerarTXTNC)
        Me.Controls.Add(Me.btnObtenerNC)
        Me.Controls.Add(Me.chkSelTodos)
        Me.Controls.Add(Me.grvDoctos)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dboTipoDocto)
        Me.Controls.Add(Me.lblTipoDocto)
        Me.Name = "frm_documentos_fel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Procesos FEL - CREDITOS ::"
        CType(Me.grvDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupCopias_fel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTipoDocto As Label
    Friend WithEvents dboTipoDocto As ComboBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents grvDoctos As DataGridView
    Friend WithEvents chkSelTodos As CheckBox
    Friend WithEvents btnObtenerNC As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnGenerarTXTNC As Button
    Friend WithEvents btnReimpresionNC As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents nupCopias_fel As NumericUpDown
    Friend WithEvents btnXmlWM As Button
End Class
