<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ppto_general
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ppto_general))
        Me.dg_presupuesto = New System.Windows.Forms.DataGridView()
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.dg_resumen = New System.Windows.Forms.DataGridView()
        Me.cl_mes_mostrar = New System.Windows.Forms.CheckedListBox()
        Me.btn_actualizar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OFD_Productos = New System.Windows.Forms.OpenFileDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cmb_campos = New System.Windows.Forms.ComboBox()
        Me.cmb_operadores = New System.Windows.Forms.ComboBox()
        Me.txt_texto = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Seleccion = New System.Windows.Forms.Button()
        Me.btn_exportar_excel = New System.Windows.Forms.Button()
        Me.SFD_productos = New System.Windows.Forms.SaveFileDialog()
        Me.btn_packs = New System.Windows.Forms.Button()
        CType(Me.dg_presupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_presupuesto
        '
        Me.dg_presupuesto.AllowUserToDeleteRows = False
        Me.dg_presupuesto.AllowUserToOrderColumns = True
        Me.dg_presupuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_presupuesto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_presupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_presupuesto.Location = New System.Drawing.Point(1, 162)
        Me.dg_presupuesto.Name = "dg_presupuesto"
        Me.dg_presupuesto.RowHeadersWidth = 25
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_presupuesto.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_presupuesto.Size = New System.Drawing.Size(999, 492)
        Me.dg_presupuesto.TabIndex = 0
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generar.ImageIndex = 1
        Me.btn_generar.ImageList = Me.ImageList2
        Me.btn_generar.Location = New System.Drawing.Point(306, 11)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(111, 52)
        Me.btn_generar.TabIndex = 1
        Me.btn_generar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Informacion"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "save.ico")
        Me.ImageList2.Images.SetKeyName(1, "process.ico")
        Me.ImageList2.Images.SetKeyName(2, "repeat.ico")
        Me.ImageList2.Images.SetKeyName(3, "users.ico")
        Me.ImageList2.Images.SetKeyName(4, "02408.bmp")
        Me.ImageList2.Images.SetKeyName(5, "stock.gif")
        Me.ImageList2.Images.SetKeyName(6, "accounts.gif")
        Me.ImageList2.Images.SetKeyName(7, "app_48.png")
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.HelpProvider1.SetHelpString(Me.btn_guardar, "Ayuda Guardar")
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList2
        Me.btn_guardar.Location = New System.Drawing.Point(420, 11)
        Me.btn_guardar.Name = "btn_guardar"
        Me.HelpProvider1.SetShowHelp(Me.btn_guardar, True)
        Me.btn_guardar.Size = New System.Drawing.Size(111, 52)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = False
        Me.btn_guardar.Visible = False
        '
        'dg_resumen
        '
        Me.dg_resumen.AllowUserToAddRows = False
        Me.dg_resumen.AllowUserToDeleteRows = False
        Me.dg_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_resumen.Location = New System.Drawing.Point(1, 112)
        Me.dg_resumen.Name = "dg_resumen"
        Me.dg_resumen.ReadOnly = True
        Me.dg_resumen.RowHeadersVisible = False
        Me.dg_resumen.RowHeadersWidth = 25
        Me.dg_resumen.Size = New System.Drawing.Size(999, 43)
        Me.dg_resumen.TabIndex = 2
        '
        'cl_mes_mostrar
        '
        Me.cl_mes_mostrar.CheckOnClick = True
        Me.cl_mes_mostrar.FormattingEnabled = True
        Me.cl_mes_mostrar.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Proveedor", "Marca", "BU", "UxC", "Volumen"})
        Me.cl_mes_mostrar.Location = New System.Drawing.Point(765, 5)
        Me.cl_mes_mostrar.Name = "cl_mes_mostrar"
        Me.cl_mes_mostrar.Size = New System.Drawing.Size(127, 94)
        Me.cl_mes_mostrar.TabIndex = 3
        '
        'btn_actualizar
        '
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_actualizar.ImageIndex = 2
        Me.btn_actualizar.ImageList = Me.ImageList2
        Me.btn_actualizar.Location = New System.Drawing.Point(898, 18)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(111, 45)
        Me.btn_actualizar.TabIndex = 1
        Me.btn_actualizar.Text = "       Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Vista"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_actualizar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Mercadeo (-) Comercial(+)"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Salmon
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mercadeo(+) Comercial (-)"
        Me.Label2.Visible = False
        '
        'OFD_Productos
        '
        Me.OFD_Productos.FileName = "OpenFileDialog1"
        '
        'cmb_campos
        '
        Me.cmb_campos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_campos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_campos.FormattingEnabled = True
        Me.cmb_campos.Items.AddRange(New Object() {"codigo", "descripcion", "proveedor", "marca"})
        Me.cmb_campos.Location = New System.Drawing.Point(8, 83)
        Me.cmb_campos.Name = "cmb_campos"
        Me.cmb_campos.Size = New System.Drawing.Size(140, 22)
        Me.cmb_campos.TabIndex = 7
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DisplayMember = "like"
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_operadores.FormattingEnabled = True
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(153, 83)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(65, 22)
        Me.cmb_operadores.TabIndex = 8
        Me.cmb_operadores.ValueMember = "like"
        '
        'txt_texto
        '
        Me.txt_texto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_texto.Location = New System.Drawing.Point(222, 83)
        Me.txt_texto.Name = "txt_texto"
        Me.txt_texto.Size = New System.Drawing.Size(443, 20)
        Me.txt_texto.TabIndex = 9
        '
        'btn_buscar
        '
        Me.btn_buscar.AutoEllipsis = True
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 0
        Me.btn_buscar.ImageList = Me.ImageList1
        Me.btn_buscar.Location = New System.Drawing.Point(670, 12)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(80, 25)
        Me.btn_buscar.TabIndex = 10
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "search_48.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(757, 40)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'btn_Seleccion
        '
        Me.btn_Seleccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Seleccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Seleccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Seleccion.ForeColor = System.Drawing.Color.White
        Me.btn_Seleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Seleccion.ImageIndex = 3
        Me.btn_Seleccion.ImageList = Me.ImageList2
        Me.btn_Seleccion.Location = New System.Drawing.Point(648, 11)
        Me.btn_Seleccion.Name = "btn_Seleccion"
        Me.btn_Seleccion.Size = New System.Drawing.Size(111, 52)
        Me.btn_Seleccion.TabIndex = 1
        Me.btn_Seleccion.Text = "Detalle " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccion"
        Me.btn_Seleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Seleccion.UseVisualStyleBackColor = False
        Me.btn_Seleccion.Visible = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar_excel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.ForeColor = System.Drawing.Color.White
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exportar_excel.ImageIndex = 4
        Me.btn_exportar_excel.ImageList = Me.ImageList2
        Me.btn_exportar_excel.Location = New System.Drawing.Point(191, 11)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(111, 52)
        Me.btn_exportar_excel.TabIndex = 12
        Me.btn_exportar_excel.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Excel "
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        Me.btn_exportar_excel.Visible = False
        '
        'btn_packs
        '
        Me.btn_packs.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_packs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_packs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_packs.ForeColor = System.Drawing.Color.White
        Me.btn_packs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_packs.ImageIndex = 7
        Me.btn_packs.ImageList = Me.ImageList2
        Me.btn_packs.Location = New System.Drawing.Point(534, 11)
        Me.btn_packs.Name = "btn_packs"
        Me.btn_packs.Size = New System.Drawing.Size(111, 52)
        Me.btn_packs.TabIndex = 1
        Me.btn_packs.Text = "Comparar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vrs Comercial"
        Me.btn_packs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_packs.UseVisualStyleBackColor = False
        '
        'frm_ppto_general
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1012, 672)
        Me.Controls.Add(Me.btn_exportar_excel)
        Me.Controls.Add(Me.txt_texto)
        Me.Controls.Add(Me.cmb_operadores)
        Me.Controls.Add(Me.cmb_campos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cl_mes_mostrar)
        Me.Controls.Add(Me.dg_resumen)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.btn_packs)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_Seleccion)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.dg_presupuesto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me, "El Archivo de Excel, Debe contener en la primera fila los encabezados, para la ca" & _
        "rga tomara el periodo que esta seleccionado")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ppto_general"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Presupuesto General .::"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg_presupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_presupuesto As System.Windows.Forms.DataGridView
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents dg_resumen As System.Windows.Forms.DataGridView
    Friend WithEvents cl_mes_mostrar As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OFD_Productos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents txt_texto As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Seleccion As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents SFD_productos As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btn_packs As System.Windows.Forms.Button
End Class
