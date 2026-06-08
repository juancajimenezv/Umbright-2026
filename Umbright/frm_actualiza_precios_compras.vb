Public Class frm_actualiza_precios_compras
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_precio_actual As System.Windows.Forms.TextBox
    Friend WithEvents txt_nuevo_precio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_lista_precios As System.Windows.Forms.DataGrid
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents cmb_operadores As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_campos_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tc_Precios As System.Windows.Forms.TabControl
    Friend WithEvents tp_cabios As System.Windows.Forms.TabPage
    Friend WithEvents tp_lista As System.Windows.Forms.TabPage
    Friend WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_lista_precios As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_actualiza_precios_compras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_ayuda = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.txt_precio_actual = New System.Windows.Forms.TextBox
        Me.txt_nuevo_precio = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_lista_precios = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dg_productos = New System.Windows.Forms.DataGridView
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tc_Precios = New System.Windows.Forms.TabControl
        Me.tp_cabios = New System.Windows.Forms.TabPage
        Me.tp_lista = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmb_operadores = New System.Windows.Forms.ComboBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.cmb_campos_busqueda = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dg_lista_precios = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.tc_Precios.SuspendLayout()
        Me.tp_cabios.SuspendLayout()
        Me.tp_lista.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_lista_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_agregar)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_proveedor)
        Me.GroupBox1.Controls.Add(Me.txt_descripcion)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.txt_precio_actual)
        Me.GroupBox1.Controls.Add(Me.txt_nuevo_precio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbl_lista_precios)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 144)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.White
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.ImageIndex = 0
        Me.btn_agregar.ImageList = Me.ImageList2
        Me.btn_agregar.Location = New System.Drawing.Point(456, 110)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(24, 22)
        Me.btn_agregar.TabIndex = 9
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "Search.png")
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(216, 20)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(26, 22)
        Me.btn_ayuda.TabIndex = 2
        Me.btn_ayuda.Text = "..."
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Precio Actual:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Proveedor:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto:"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BackColor = System.Drawing.Color.White
        Me.txt_proveedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_proveedor.Location = New System.Drawing.Point(120, 80)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(360, 22)
        Me.txt_proveedor.TabIndex = 3
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(120, 50)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(360, 22)
        Me.txt_descripcion.TabIndex = 4
        '
        'txt_producto
        '
        Me.txt_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(120, 20)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(96, 22)
        Me.txt_producto.TabIndex = 1
        '
        'txt_precio_actual
        '
        Me.txt_precio_actual.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio_actual.Location = New System.Drawing.Point(120, 110)
        Me.txt_precio_actual.Name = "txt_precio_actual"
        Me.txt_precio_actual.ReadOnly = True
        Me.txt_precio_actual.Size = New System.Drawing.Size(96, 22)
        Me.txt_precio_actual.TabIndex = 6
        Me.txt_precio_actual.TabStop = False
        Me.txt_precio_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nuevo_precio
        '
        Me.txt_nuevo_precio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nuevo_precio.Location = New System.Drawing.Point(344, 110)
        Me.txt_nuevo_precio.Name = "txt_nuevo_precio"
        Me.txt_nuevo_precio.Size = New System.Drawing.Size(112, 22)
        Me.txt_nuevo_precio.TabIndex = 8
        Me.txt_nuevo_precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(292, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nuevo Precio:"
        '
        'lbl_lista_precios
        '
        Me.lbl_lista_precios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lista_precios.Location = New System.Drawing.Point(248, 12)
        Me.lbl_lista_precios.Name = "lbl_lista_precios"
        Me.lbl_lista_precios.Size = New System.Drawing.Size(232, 34)
        Me.lbl_lista_precios.TabIndex = 10
        Me.lbl_lista_precios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg_productos)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 159)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 266)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'dg_productos
        '
        Me.dg_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_productos.Location = New System.Drawing.Point(3, 17)
        Me.dg_productos.Name = "dg_productos"
        Me.dg_productos.Size = New System.Drawing.Size(602, 246)
        Me.dg_productos.TabIndex = 0
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(16, 14)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(64, 56)
        Me.btn_nuevo.TabIndex = 11
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "3.png")
        Me.ImageList1.Images.SetKeyName(1, "Floppy-64.png")
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(16, 82)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(64, 56)
        Me.btn_guardar.TabIndex = 10
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_nuevo)
        Me.GroupBox3.Controls.Add(Me.btn_guardar)
        Me.GroupBox3.Location = New System.Drawing.Point(527, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(96, 144)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'tc_Precios
        '
        Me.tc_Precios.Controls.Add(Me.tp_cabios)
        Me.tc_Precios.Controls.Add(Me.tp_lista)
        Me.tc_Precios.Location = New System.Drawing.Point(0, 0)
        Me.tc_Precios.Name = "tc_Precios"
        Me.tc_Precios.SelectedIndex = 0
        Me.tc_Precios.Size = New System.Drawing.Size(648, 464)
        Me.tc_Precios.TabIndex = 11
        '
        'tp_cabios
        '
        Me.tp_cabios.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_cabios.Controls.Add(Me.GroupBox2)
        Me.tp_cabios.Controls.Add(Me.GroupBox3)
        Me.tp_cabios.Controls.Add(Me.GroupBox1)
        Me.tp_cabios.Location = New System.Drawing.Point(4, 25)
        Me.tp_cabios.Name = "tp_cabios"
        Me.tp_cabios.Size = New System.Drawing.Size(640, 435)
        Me.tp_cabios.TabIndex = 0
        Me.tp_cabios.Text = "Cambios de Precios"
        '
        'tp_lista
        '
        Me.tp_lista.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_lista.Controls.Add(Me.GroupBox5)
        Me.tp_lista.Controls.Add(Me.GroupBox4)
        Me.tp_lista.Location = New System.Drawing.Point(4, 22)
        Me.tp_lista.Name = "tp_lista"
        Me.tp_lista.Size = New System.Drawing.Size(640, 438)
        Me.tp_lista.TabIndex = 1
        Me.tp_lista.Text = "Lista Actual de Precios"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmb_operadores)
        Me.GroupBox5.Controls.Add(Me.btn_buscar)
        Me.GroupBox5.Controls.Add(Me.txt_busqueda)
        Me.GroupBox5.Controls.Add(Me.cmb_campos_busqueda)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(624, 48)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(120, 16)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(48, 24)
        Me.cmb_operadores.TabIndex = 7
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.ImageIndex = 1
        Me.btn_buscar.ImageList = Me.ImageList2
        Me.btn_buscar.Location = New System.Drawing.Point(544, 16)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 21)
        Me.btn_buscar.TabIndex = 8
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'txt_busqueda
        '
        Me.txt_busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_busqueda.Location = New System.Drawing.Point(176, 16)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(352, 22)
        Me.txt_busqueda.TabIndex = 5
        '
        'cmb_campos_busqueda
        '
        Me.cmb_campos_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos_busqueda.Items.AddRange(New Object() {"Producto", "Descripción", "Proveedor", "Valor"})
        Me.cmb_campos_busqueda.Location = New System.Drawing.Point(8, 16)
        Me.cmb_campos_busqueda.Name = "cmb_campos_busqueda"
        Me.cmb_campos_busqueda.Size = New System.Drawing.Size(104, 24)
        Me.cmb_campos_busqueda.TabIndex = 6
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dg_lista_precios)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(624, 368)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'dg_lista_precios
        '
        Me.dg_lista_precios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_lista_precios.DataMember = ""
        Me.dg_lista_precios.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_lista_precios.Location = New System.Drawing.Point(8, 16)
        Me.dg_lista_precios.Name = "dg_lista_precios"
        Me.dg_lista_precios.Size = New System.Drawing.Size(608, 344)
        Me.dg_lista_precios.TabIndex = 0
        '
        'frm_actualiza_precios_compras
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(648, 462)
        Me.Controls.Add(Me.tc_Precios)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_actualiza_precios_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Actualiza Precios Compras .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.tc_Precios.ResumeLayout(False)
        Me.tp_cabios.ResumeLayout(False)
        Me.tp_lista.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dg_lista_precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim Ods As DataSet
    Dim nuevoProducto As Boolean
    Dim isNuevo As Boolean = True
    Dim idlistaPrecios As Integer
    Dim dt_Info As DataTable

    Private Sub frm_actualiza_precios_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializar_Tablas()
    End Sub

    Private Sub Inicializar_Tablas()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim MyOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String = String.Empty
        Dim dt As DataTable
        Dim clGen As New ClasesGenerales.General

        Try
            Otrans.open()
            MyOtrans.open()
            Ods = New DataSet

            ls_sql = "pa_sel_um_gen_tabcod '" & gs_usuario & "','lista_precio_usuario','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "lista_activa"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_listaprecio_producto_activa '" & gs_empresa & "', '" & dt.Rows(0)("descripcion") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "listaProductosCompras"
            Ods.Tables.Add(dt.Copy)



            lbl_lista_precios.Text = "Lista Activa:  " & Ods.Tables("listaProductosCompras").Rows(0)("LISPRECIO").ToString
            Me.idlistaPrecios = Ods.Tables("listaProductosCompras").Rows(0).Item("idlisprecio")

            dg_lista_precios.DataSource = Ods.Tables("listaProductosCompras")
            dg_lista_precios.ReadOnly = True

            clGen.Alinea_Grid(dt, dg_lista_precios, dt.TableName, -1, 200, 60, True, True, "PRODUCTO, DESCRIPCION, PROVEEDOR, VALOR", True, "")

            'ls_sql = "pa_sel_um_lista_producto_vinoteca"
            'dt = Otrans.Obtiene(ls_sql)
            'dt.TableName = "listaProductosVinoteca"
            'Ods.Tables.Add(dt.Copy)

            dt = New DataTable("productos")

            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
            dt.Columns.Add(New DataColumn("precioActual", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("nuevoPrecio", GetType(Decimal)))


            Ods.Tables.Add(dt.Copy)

            dg_productos.DataSource = Ods.Tables("productos")
            dg_productos.ReadOnly = True

            clGen.Alinear_GridView(dt, dg_productos, "", "", "Producto, Descripcion, Proveedor, PrecioActual, NuevoPrecio", "", "", "", "Producto, Descripcion, Proveedor, PrecioActual, NuevoPrecio", True, True, 250, 0)

            clGen = Nothing

            ''Creo La Estructura para Los Productos Nuevos
            ls_sql = "pa_var_um_listaprecioD '" & gs_empresa & "', ''"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "lista_precio_D"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            MyOtrans.close()
            MyOtrans = Nothing

        End Try
    End Sub
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")
                Me.txt_proveedor.Text = dt.Rows(0)("subfamilia")
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub


    Private Sub buscar_datos()
        If txt_producto.Text.Trim.Length <= 0 Then Exit Sub

        If Not Ods.Tables.Contains("listaProductosCompras") Then Exit Sub

        Dim mRow() As DataRow = Ods.Tables("listaProductosCompras").Select("producto = " & txt_producto.Text)

        If mRow.Length <> 0 Then
            nuevoProducto = False
            muestra_informacion(mRow)
        Else
            Try

            
                Dim mRowP() As DataRow = Ods.Tables("listaProductosVinoteca").Select("producto = " & txt_producto.Text)

                If mRowP.Length <> 0 Then
                    nuevoProducto = True
                    muestra_informacion(mRowP)
                Else
                    MessageBox.Show("No se encontro el registro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_producto.Text = String.Empty
                End If
            Catch ex As Exception
                nuevoProducto = True

            End Try
        End If
        If nuevoProducto Then
            buscarProducto()
        End If
    End Sub

    Private Sub txt_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_producto.LostFocus
        buscar_datos()
    End Sub

    Private Sub muestra_informacion(ByVal mRowDatos() As DataRow)
        txt_producto.ReadOnly = True
        txt_producto.BackColor = System.Drawing.Color.White

        txt_producto.Text = mRowDatos(0)("producto")
        txt_descripcion.Text = mRowDatos(0)("descripcion")
        txt_proveedor.Text = mRowDatos(0)("proveedor")

        If Not nuevoProducto Then
            txt_precio_actual.Text = mRowDatos(0)("valor")
        End If

        txt_nuevo_precio.Focus()
    End Sub

    Private Function pasaValidaciones() As Boolean
        If Val(txt_nuevo_precio.Text) <= 0 Then
            MessageBox.Show("El nuevo precio del producto no puede ser cero (0).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_nuevo_precio.Focus()
            Return False
        End If

        If txt_producto.Text.Trim.Length <= 0 Then
            MessageBox.Show("Debe indicar que producto se modificará / agregará a la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_producto.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click

        If Not pasaValidaciones() Then Exit Sub

        isNuevo = False


        Dim fRow() As DataRow = Ods.Tables("productos").Select("producto = '" & txt_producto.Text & "'")

        If fRow.Length = 0 Then
            Dim mRow As DataRow = Ods.Tables("productos").NewRow

            mRow("producto") = txt_producto.Text
            mRow("descripcion") = txt_descripcion.Text
            mRow("proveedor") = txt_proveedor.Text
            mRow("precioActual") = Val(txt_precio_actual.Text)
            mRow("nuevoPrecio") = txt_nuevo_precio.Text


            Ods.Tables("productos").Rows.Add(mRow)

            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(Ods.Tables("productos"), dg_productos, "", "", "Producto, Descripcion, Proveedor, PrecioActual, NuevoPrecio", "", "", "", "Producto, Descripcion, Proveedor, PrecioActual, NuevoPrecio", True, True, 250, 0)
            clGen = Nothing
        Else
            Dim encontro As Boolean = False

            Dim ii As Integer = -1

            Do
                ii += 1
                If Ods.Tables("productos").Rows(ii)("producto") = txt_producto.Text Then
                    Ods.Tables("productos").Rows(ii)("nuevoPrecio") = txt_nuevo_precio.Text
                    encontro = True
                End If
            Loop Until Ods.Tables("productos").Rows.Count - 1 = ii Or encontro = True


        End If

        limpiar_campos()

    End Sub

    Private Sub limpiar_campos()
        txt_producto.Text = String.Empty
        txt_descripcion.Text = String.Empty
        txt_producto.ReadOnly = False
        txt_proveedor.Text = String.Empty
        txt_precio_actual.Text = String.Empty
        txt_nuevo_precio.Text = String.Empty

        If isNuevo And dg_productos.Rows.Count > 0 Then Ods.Tables("productos").Clear()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        isNuevo = True
        limpiar_campos()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If dg_productos.Rows.Count <= 0 Then Exit Sub

        If Ods.Tables("productos").Rows.Count = 0 Then
            MessageBox.Show("Debe existir como mínimo un producto para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If guardarDatos() Then
            MessageBox.Show("Se guardaron los datos satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            limpiar_campos()
            Inicializar_Tablas()
        Else
            MessageBox.Show("Se produjo un error al guardar los datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function dato_listaPrecioD(ByVal columna As String, ByVal codigo_lista As Integer) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_datos_lista_precioD '" & gs_empresa & "', " & codigo_lista
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columna).ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return True
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function

    Private Function guardarDatos() As Boolean
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String = String.Empty

        Try

            Otrans.open()
            dt_Info.Rows.Clear()

            For ii As Integer = 0 To Ods.Tables("productos").Rows.Count - 1
                With Ods.Tables("listaProductosCompras").Rows(ii)

                    ls_sql = "pa_upd_um_precio_producto_listaPrecioD '" & gs_empresa & "', " & _
                             .Item("idLisPrecio") & ", " & Ods.Tables("productos").Rows(ii)("nuevoprecio") & _
                             ", '" & Ods.Tables("productos").Rows(ii)("producto") & "','" & gs_usuario & "'"
                    If Otrans.Actualiza(ls_sql) = 0 Then
                        'se debe Insertar

                        Dim mNewRow As DataRow = dt_Info.NewRow

                        mNewRow("Empresa") = gs_empresa
                        mNewRow("IdLisPrecio") = Me.idlistaPrecios
                        mNewRow("Producto") = Ods.Tables("productos").Rows(ii)("producto")
                        mNewRow("Valor") = Ods.Tables("productos").Rows(ii)("nuevoprecio")
                        mNewRow("Moneda") = dato_listaPrecioD("moneda", Me.idlistaPrecios)
                        mNewRow("lisPrecio") = dato_listaPrecioD("LisPrecio", Me.idlistaPrecios)
                        mNewRow("PorcMaxDesc") = 0.0
                        mNewRow("Intervalo") = 0.0
                        mNewRow("PorcentajeInt") = 0.0
                        mNewRow("Cantidad") = 0.0
                        mNewRow("Tipo") = ""
                        mNewRow("ValorC") = 0.0
                        mNewRow("FechaVigencia") = CType(dato_listaPrecioD("FechaVigencia", Me.idlistaPrecios), DateTime)
                        mNewRow("fec_final") = CType(dato_listaPrecioD("fec_final", Me.idlistaPrecios), DateTime)
                        mNewRow("Origen") = ""
                        mNewRow("ValorOrigen") = 0.0
                        mNewRow("ValorPOrigen") = 0.0
                        mNewRow("UserModif") = gs_usuario
                        mNewRow("FechaModif") = Now
                        mNewRow("Efecto") = ""
                        mNewRow("PorcMaxDesc1") = 0.0
                        mNewRow("PorcMaxDesc2") = 0.0
                        mNewRow("PorcMaxDesc3") = 0.0
                        mNewRow("PorcMaxDesc4") = 0.0
                        mNewRow("PorcMaxDesc5") = 0.0

                        dt_Info.Rows.Add(mNewRow)
                    End If

                End With
            Next

            If dt_Info.Rows.Count > 0 Then
                Try
                    Dim sinc As New Sincronizacion.Productos("")
                    sinc.Actualizar_ProductoPrecio(dt_Info, False)
                    sinc.Cerrar()
                    sinc = Nothing
                Catch ex As Exception

                End Try


            End If

            Return True
        Catch ex As Exception
            Return False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function

    Private Sub Aplicar_Filtro()
        Dim ls_filtro As String = ""

        Try
            If Me.txt_busqueda.TextLength > 0 Then
                ls_filtro = cmb_campos_busqueda.Text & " " & _
                cmb_operadores.Text & " '" & IIf(cmb_operadores.Text = "like", "%", "") & _
                txt_busqueda.Text & IIf(cmb_operadores.Text = "like", "%", "") & "'"
            End If

            Ods.Tables("listaProductosCompras").DefaultView.RowFilter = ls_filtro

        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Aplicar_Filtro()
    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            Aplicar_Filtro()
        End If
    End Sub

    Private Sub dg_lista_precios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_lista_precios.DoubleClick
        If Not Ods.Tables.Contains("listaProductosCompras") Then Exit Sub

        txt_producto.Text = dg_lista_precios.Item(dg_lista_precios.CurrentRowIndex(), 0)
        txt_descripcion.Text = dg_lista_precios.Item(dg_lista_precios.CurrentRowIndex(), 1)
        txt_proveedor.Text = dg_lista_precios.Item(dg_lista_precios.CurrentRowIndex(), 2)

        tc_Precios.SelectedTab = tp_cabios
        txt_producto.Focus()

        SendKeys.Send("{Tab}")
    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)


        If frm_busqueda.resultado <> Nothing Then
            txt_producto.Text = frm_busqueda.resultado

            buscar_datos()

            frm_busqueda.Dispose()
            frm_busqueda = Nothing
        Else
            txt_nuevo_precio.Focus()
        End If
    End Sub

    Private Sub dg_productos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            Ods.Tables("productos").Rows(dg_productos.CurrentRow.Index).Delete()
            dg_productos.Update()
            dg_productos.Update()
        End If
    End Sub

    Private Sub frm_actualiza_precios_compras_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not Ods.Tables.Contains("lista_activa") Then
            MessageBox.Show("Usted no tiene ninguna lista asignada a la cual modificar precios.", "Sin lista Asignada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            If Ods.Tables("lista_activa").Rows.Count <= 0 Then
                MessageBox.Show("Usted no tiene ninguna lista asignada a la cual modificar precios.", "Sin lista Asignada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged

    End Sub
End Class
