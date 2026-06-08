<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmForecast
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmForecast))
        Me.dgv_productos = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.zgc1 = New ZedGraph.ZedGraphControl
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.nupgama = New System.Windows.Forms.NumericUpDown
        Me.nupbeta = New System.Windows.Forms.NumericUpDown
        Me.nupalpha = New System.Windows.Forms.NumericUpDown
        Me.lblMarca = New System.Windows.Forms.Label
        Me.cmbMarca = New System.Windows.Forms.ComboBox
        Me.chk_marcas = New System.Windows.Forms.CheckedListBox
        Me.btnMarcar = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnExportar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_generar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.nupgama, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupbeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupalpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_productos
        '
        Me.dgv_productos.AllowUserToAddRows = False
        Me.dgv_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_productos.Location = New System.Drawing.Point(3, 105)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.RowHeadersWidth = 25
        Me.dgv_productos.Size = New System.Drawing.Size(1011, 184)
        Me.dgv_productos.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'zgc1
        '
        Me.zgc1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zgc1.Location = New System.Drawing.Point(97, 290)
        Me.zgc1.Name = "zgc1"
        Me.zgc1.ScrollGrace = 0
        Me.zgc1.ScrollMaxX = 0
        Me.zgc1.ScrollMaxY = 0
        Me.zgc1.ScrollMaxY2 = 0
        Me.zgc1.ScrollMinX = 0
        Me.zgc1.ScrollMinY = 0
        Me.zgc1.ScrollMinY2 = 0
        Me.zgc1.Size = New System.Drawing.Size(917, 327)
        Me.zgc1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Symbol", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 376)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "g"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Symbol", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 350)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "b"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Symbol", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 324)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "a"
        '
        'nupgama
        '
        Me.nupgama.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nupgama.DecimalPlaces = 2
        Me.nupgama.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nupgama.Location = New System.Drawing.Point(24, 374)
        Me.nupgama.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupgama.Name = "nupgama"
        Me.nupgama.Size = New System.Drawing.Size(53, 20)
        Me.nupgama.TabIndex = 9
        Me.nupgama.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'nupbeta
        '
        Me.nupbeta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nupbeta.DecimalPlaces = 2
        Me.nupbeta.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nupbeta.Location = New System.Drawing.Point(24, 348)
        Me.nupbeta.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupbeta.Name = "nupbeta"
        Me.nupbeta.Size = New System.Drawing.Size(53, 20)
        Me.nupbeta.TabIndex = 8
        Me.nupbeta.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'nupalpha
        '
        Me.nupalpha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nupalpha.DecimalPlaces = 2
        Me.nupalpha.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nupalpha.Location = New System.Drawing.Point(24, 322)
        Me.nupalpha.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupalpha.Name = "nupalpha"
        Me.nupalpha.Size = New System.Drawing.Size(53, 20)
        Me.nupalpha.TabIndex = 10
        Me.nupalpha.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(209, 76)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 17
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(252, 73)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(121, 21)
        Me.cmbMarca.TabIndex = 16
        Me.cmbMarca.Visible = False
        '
        'chk_marcas
        '
        Me.chk_marcas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_marcas.FormattingEnabled = True
        Me.chk_marcas.Location = New System.Drawing.Point(1, 23)
        Me.chk_marcas.Name = "chk_marcas"
        Me.chk_marcas.Size = New System.Drawing.Size(177, 79)
        Me.chk_marcas.TabIndex = 14
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(189, 23)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(75, 37)
        Me.btnMarcar.TabIndex = 15
        Me.btnMarcar.Text = "Marcar Todos"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.ForeColor = System.Drawing.Color.White
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.ImageKey = "01EXCEL116.bmp"
        Me.btnExportar.ImageList = Me.ImageList1
        Me.btnExportar.Location = New System.Drawing.Point(685, 21)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(101, 53)
        Me.btnExportar.TabIndex = 20
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(1, "01EXCEL116.bmp")
        Me.ImageList1.Images.SetKeyName(2, "1286297068_Floppy-64.png")
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generar.ImageKey = "1286295506_Process-Accept.png"
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(594, 21)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(96, 53)
        Me.btn_generar.TabIndex = 19
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "1286297068_Floppy-64.png"
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(786, 21)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(101, 53)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        Me.btnGuardar.Visible = False
        '
        'frmForecast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1016, 620)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.lblMarca)
        Me.Controls.Add(Me.cmbMarca)
        Me.Controls.Add(Me.chk_marcas)
        Me.Controls.Add(Me.btnMarcar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nupgama)
        Me.Controls.Add(Me.nupbeta)
        Me.Controls.Add(Me.nupalpha)
        Me.Controls.Add(Me.zgc1)
        Me.Controls.Add(Me.dgv_productos)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmForecast"
        Me.Text = ":: FORECAST ::"
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.nupgama, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupbeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupalpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents zgc1 As ZedGraph.ZedGraphControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nupgama As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupbeta As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupalpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
    Friend WithEvents chk_marcas As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnMarcar As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
