<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenedorPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenedorPrecios))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFechaGrabo = New System.Windows.Forms.TextBox()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.cmbSolicitante = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Estado = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFechaCambios = New System.Windows.Forms.DateTimePicker()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.btn_grabar = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnXLSHorizontal = New System.Windows.Forms.Button()
        Me.btnCargarXLS = New System.Windows.Forms.Button()
        Me.lblBU = New System.Windows.Forms.Label()
        Me.txtPrecioNuevo = New System.Windows.Forms.TextBox()
        Me.txtPrecioAnterior = New System.Windows.Forms.TextBox()
        Me.chk_todaslasListas = New System.Windows.Forms.CheckBox()
        Me.cmbListaPrecios = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.txt_cod_producto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantidadPrecio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCantidadAnterior = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCantidad_PrecioAnterior = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(939, 516)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtCantidadAnterior)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.btnCargarXLS)
        Me.TabPage1.Controls.Add(Me.btnXLSHorizontal)
        Me.TabPage1.Controls.Add(Me.btn_grabar)
        Me.TabPage1.Controls.Add(Me.btn_imprimir)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgvProductos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(931, 490)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFechaGrabo)
        Me.GroupBox3.Controls.Add(Me.txtOperador)
        Me.GroupBox3.Controls.Add(Me.cmbSolicitante)
        Me.GroupBox3.Controls.Add(Me.cmbEstado)
        Me.GroupBox3.Controls.Add(Me.lblNumero)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Estado)
        Me.GroupBox3.Controls.Add(Me.lblEstado)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(579, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(345, 100)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'txtFechaGrabo
        '
        Me.txtFechaGrabo.Location = New System.Drawing.Point(195, 74)
        Me.txtFechaGrabo.Name = "txtFechaGrabo"
        Me.txtFechaGrabo.ReadOnly = True
        Me.txtFechaGrabo.Size = New System.Drawing.Size(97, 20)
        Me.txtFechaGrabo.TabIndex = 2
        '
        'txtOperador
        '
        Me.txtOperador.Location = New System.Drawing.Point(68, 74)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(121, 20)
        Me.txtOperador.TabIndex = 2
        '
        'cmbSolicitante
        '
        Me.cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolicitante.FormattingEnabled = True
        Me.cmbSolicitante.Location = New System.Drawing.Point(68, 50)
        Me.cmbSolicitante.Name = "cmbSolicitante"
        Me.cmbSolicitante.Size = New System.Drawing.Size(224, 21)
        Me.cmbSolicitante.TabIndex = 1
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(68, 27)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 1
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.Location = New System.Drawing.Point(241, 12)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(94, 31)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "00000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(196, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Numero"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Operador"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Solicitante"
        '
        'Estado
        '
        Me.Estado.AutoSize = True
        Me.Estado.Location = New System.Drawing.Point(6, 30)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(40, 13)
        Me.Estado.TabIndex = 0
        Me.Estado.Text = "Estado"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(80, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(86, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado Actual"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Estado Actual"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageKey = "1286297283_unknown.png"
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(649, 18)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(81, 60)
        Me.btn_nuevo.TabIndex = 3
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "1286297283_unknown.png")
        Me.ImageList1.Images.SetKeyName(2, "printer_48.png")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtFechaCambios)
        Me.GroupBox2.Controls.Add(Me.txtComentarios)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(505, 72)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha Cambios"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Comentarios"
        '
        'dtFechaCambios
        '
        Me.dtFechaCambios.Enabled = False
        Me.dtFechaCambios.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaCambios.Location = New System.Drawing.Point(89, 12)
        Me.dtFechaCambios.Name = "dtFechaCambios"
        Me.dtFechaCambios.Size = New System.Drawing.Size(90, 20)
        Me.dtFechaCambios.TabIndex = 0
        '
        'txtComentarios
        '
        Me.txtComentarios.Location = New System.Drawing.Point(89, 34)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(410, 37)
        Me.txtComentarios.TabIndex = 0
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_grabar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.White
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.ImageKey = "1286297068_Floppy-64.png"
        Me.btn_grabar.ImageList = Me.ImageList1
        Me.btn_grabar.Location = New System.Drawing.Point(732, 18)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(84, 60)
        Me.btn_grabar.TabIndex = 4
        Me.btn_grabar.Text = "Guardar"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 2
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(818, 18)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(81, 60)
        Me.btn_imprimir.TabIndex = 5
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCantidad_PrecioAnterior)
        Me.GroupBox1.Controls.Add(Me.txtCantidadPrecio)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblBU)
        Me.GroupBox1.Controls.Add(Me.txtPrecioNuevo)
        Me.GroupBox1.Controls.Add(Me.txtPrecioAnterior)
        Me.GroupBox1.Controls.Add(Me.chk_todaslasListas)
        Me.GroupBox1.Controls.Add(Me.cmbListaPrecios)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.txt_cod_producto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtGlosa)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 113)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnXLSHorizontal
        '
        Me.btnXLSHorizontal.Location = New System.Drawing.Point(531, 6)
        Me.btnXLSHorizontal.Name = "btnXLSHorizontal"
        Me.btnXLSHorizontal.Size = New System.Drawing.Size(75, 36)
        Me.btnXLSHorizontal.TabIndex = 11
        Me.btnXLSHorizontal.Text = "XLS Horiz"
        Me.ToolTip1.SetToolTip(Me.btnXLSHorizontal, "La columna a y b deben ser codigo y descripcion, el resto de columnas debe llevar" &
        " el nombre de la lista correcto")
        Me.btnXLSHorizontal.UseVisualStyleBackColor = True
        '
        'btnCargarXLS
        '
        Me.btnCargarXLS.Location = New System.Drawing.Point(531, 44)
        Me.btnCargarXLS.Name = "btnCargarXLS"
        Me.btnCargarXLS.Size = New System.Drawing.Size(75, 34)
        Me.btnCargarXLS.TabIndex = 11
        Me.btnCargarXLS.Text = "Cargar XLS"
        Me.btnCargarXLS.UseVisualStyleBackColor = True
        '
        'lblBU
        '
        Me.lblBU.AutoSize = True
        Me.lblBU.Location = New System.Drawing.Point(441, 74)
        Me.lblBU.Name = "lblBU"
        Me.lblBU.Size = New System.Drawing.Size(35, 13)
        Me.lblBU.TabIndex = 10
        Me.lblBU.Text = " lblBU"
        Me.lblBU.Visible = False
        '
        'txtPrecioNuevo
        '
        Me.txtPrecioNuevo.Location = New System.Drawing.Point(56, 70)
        Me.txtPrecioNuevo.Name = "txtPrecioNuevo"
        Me.txtPrecioNuevo.Size = New System.Drawing.Size(89, 20)
        Me.txtPrecioNuevo.TabIndex = 4
        '
        'txtPrecioAnterior
        '
        Me.txtPrecioAnterior.Location = New System.Drawing.Point(244, 69)
        Me.txtPrecioAnterior.Name = "txtPrecioAnterior"
        Me.txtPrecioAnterior.ReadOnly = True
        Me.txtPrecioAnterior.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioAnterior.TabIndex = 9
        '
        'chk_todaslasListas
        '
        Me.chk_todaslasListas.AutoSize = True
        Me.chk_todaslasListas.Location = New System.Drawing.Point(246, 21)
        Me.chk_todaslasListas.Name = "chk_todaslasListas"
        Me.chk_todaslasListas.Size = New System.Drawing.Size(106, 17)
        Me.chk_todaslasListas.TabIndex = 8
        Me.chk_todaslasListas.Text = "Todas Las Listas"
        Me.chk_todaslasListas.UseVisualStyleBackColor = True
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.Location = New System.Drawing.Point(56, 17)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(170, 21)
        Me.cmbListaPrecios.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(56, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(170, 21)
        Me.ComboBox1.TabIndex = 7
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarProducto.ForeColor = System.Drawing.Color.White
        Me.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarProducto.Location = New System.Drawing.Point(148, 46)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(28, 22)
        Me.btnBuscarProducto.TabIndex = 6
        Me.btnBuscarProducto.Text = "..."
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarProducto.UseVisualStyleBackColor = False
        '
        'txt_cod_producto
        '
        Me.txt_cod_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_producto.Location = New System.Drawing.Point(56, 46)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.Size = New System.Drawing.Size(89, 20)
        Me.txt_cod_producto.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "L. Precios"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(162, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Precio Anterior"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Precio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Producto"
        '
        'txtGlosa
        '
        Me.txtGlosa.Location = New System.Drawing.Point(180, 47)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.Size = New System.Drawing.Size(380, 20)
        Me.txtGlosa.TabIndex = 3
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvProductos.Location = New System.Drawing.Point(3, 202)
        Me.dgvProductos.Name = "dgvProductos"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvProductos.RowHeadersWidth = 25
        Me.dgvProductos.Size = New System.Drawing.Size(921, 282)
        Me.dgvProductos.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgvListado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(931, 490)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListado.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvListado.Location = New System.Drawing.Point(3, 89)
        Me.dgvListado.Name = "dgvListado"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.Size = New System.Drawing.Size(921, 395)
        Me.dgvListado.TabIndex = 0
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(56, 92)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(89, 20)
        Me.txtCantidad.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Cantidad"
        '
        'txtCantidadPrecio
        '
        Me.txtCantidadPrecio.Location = New System.Drawing.Point(244, 92)
        Me.txtCantidadPrecio.MaxLength = 10
        Me.txtCantidadPrecio.Name = "txtCantidadPrecio"
        Me.txtCantidadPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidadPrecio.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(154, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Precio Cantidad"
        '
        'txtCantidadAnterior
        '
        Me.txtCantidadAnterior.Location = New System.Drawing.Point(418, 176)
        Me.txtCantidadAnterior.Name = "txtCantidadAnterior"
        Me.txtCantidadAnterior.ReadOnly = True
        Me.txtCantidadAnterior.Size = New System.Drawing.Size(57, 20)
        Me.txtCantidadAnterior.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(361, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Anterior"
        '
        'txtCantidad_PrecioAnterior
        '
        Me.txtCantidad_PrecioAnterior.Location = New System.Drawing.Point(472, 92)
        Me.txtCantidad_PrecioAnterior.Name = "txtCantidad_PrecioAnterior"
        Me.txtCantidad_PrecioAnterior.ReadOnly = True
        Me.txtCantidad_PrecioAnterior.Size = New System.Drawing.Size(87, 20)
        Me.txtCantidad_PrecioAnterior.TabIndex = 18
        '
        'frmMantenedorPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(939, 516)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMantenedorPrecios"
        Me.Text = ":: Mantenimiento de Precios ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Estado As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFechaCambios As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSolicitante As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtPrecioNuevo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioAnterior As System.Windows.Forms.TextBox
    Friend WithEvents chk_todaslasListas As System.Windows.Forms.CheckBox
    Friend WithEvents cmbListaPrecios As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblBU As System.Windows.Forms.Label
    Friend WithEvents txtFechaGrabo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnCargarXLS As System.Windows.Forms.Button
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnXLSHorizontal As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtCantidadAnterior As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCantidad_PrecioAnterior As TextBox
    Friend WithEvents txtCantidadPrecio As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label10 As Label
End Class
