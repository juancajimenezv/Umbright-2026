<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_carga_presupuesto_general
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_carga_presupuesto_general))
        Me.dg_productos = New System.Windows.Forms.DataGridView
        Me.OFD_productos = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmb_campos = New System.Windows.Forms.ComboBox
        Me.cmb_operadores = New System.Windows.Forms.ComboBox
        Me.txt_texto = New System.Windows.Forms.TextBox
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.dg_resumen = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.btn_excel = New System.Windows.Forms.Button
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_productos
        '
        Me.dg_productos.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dg_productos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dg_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dg_productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dg_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos.Location = New System.Drawing.Point(3, 157)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dg_productos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_productos.Size = New System.Drawing.Size(785, 386)
        Me.dg_productos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicio"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Final"
        Me.Label2.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "floppy_disk_48.png")
        Me.ImageList1.Images.SetKeyName(1, "EXCEL.ICO")
        Me.ImageList1.Images.SetKeyName(2, "save.ico")
        '
        'cmb_campos
        '
        Me.cmb_campos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_campos.FormattingEnabled = True
        Me.cmb_campos.Items.AddRange(New Object() {"Descripcion", "Codigo", "Proveedor", "Marca"})
        Me.cmb_campos.Location = New System.Drawing.Point(13, 61)
        Me.cmb_campos.Name = "cmb_campos"
        Me.cmb_campos.Size = New System.Drawing.Size(121, 22)
        Me.cmb_campos.TabIndex = 4
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_operadores.FormattingEnabled = True
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(140, 61)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(69, 22)
        Me.cmb_operadores.TabIndex = 5
        '
        'txt_texto
        '
        Me.txt_texto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_texto.Location = New System.Drawing.Point(219, 62)
        Me.txt_texto.Name = "txt_texto"
        Me.txt_texto.Size = New System.Drawing.Size(333, 20)
        Me.txt_texto.TabIndex = 6
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "search_48.png")
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(655, -2)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(102, 39)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btn_guardar, "Actualizara la Informacion de los Meses Validos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No se guardara informacion de Pr" & _
                "oductos No VIGENTES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sobreescribira en el periodo seleccionado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'dg_resumen
        '
        Me.dg_resumen.AllowUserToAddRows = False
        Me.dg_resumen.AllowUserToDeleteRows = False
        Me.dg_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_resumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_resumen.Location = New System.Drawing.Point(3, 92)
        Me.dg_resumen.Name = "dg_resumen"
        Me.dg_resumen.Size = New System.Drawing.Size(785, 59)
        Me.dg_resumen.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(659, 42)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 0
        Me.btn_buscar.ImageList = Me.ImageList2
        Me.btn_buscar.Location = New System.Drawing.Point(555, 12)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(69, 25)
        Me.btn_buscar.TabIndex = 7
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'btn_excel
        '
        Me.btn_excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_excel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_excel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excel.ForeColor = System.Drawing.Color.White
        Me.btn_excel.Image = CType(resources.GetObject("btn_excel.Image"), System.Drawing.Image)
        Me.btn_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excel.Location = New System.Drawing.Point(526, -2)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(107, 39)
        Me.btn_excel.TabIndex = 1
        Me.btn_excel.Text = "Obtener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Excel"
        Me.btn_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excel.UseVisualStyleBackColor = False
        '
        'frm_carga_presupuesto_general
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(790, 547)
        Me.Controls.Add(Me.dg_resumen)
        Me.Controls.Add(Me.txt_texto)
        Me.Controls.Add(Me.cmb_operadores)
        Me.Controls.Add(Me.cmb_campos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_excel)
        Me.Controls.Add(Me.dg_productos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_carga_presupuesto_general"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ":: Carga de Presupuesto ::"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_excel As System.Windows.Forms.Button
    Friend WithEvents OFD_productos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents txt_texto As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dg_resumen As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
