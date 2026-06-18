Imports System.Math
Public Class frm_procesar_productos

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
    Friend WithEvents group_encabezado As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents grupo_Cuentas As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grupo_indicadores As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents check_indicadores As System.Windows.Forms.CheckedListBox
    Friend WithEvents grupo_analisis As System.Windows.Forms.GroupBox
    Friend WithEvents check_impuestos As System.Windows.Forms.CheckedListBox
    Friend WithEvents dg_analisis As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_codigos As System.Windows.Forms.DataGrid
    Friend WithEvents codigosBarra As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents codigo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents unidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents factor As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tc_control As System.Windows.Forms.TabControl
    Friend WithEvents tp_producto As System.Windows.Forms.TabPage
    Friend WithEvents atributos As System.Windows.Forms.TabPage
    Friend WithEvents tp_analisis As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_pais_compra As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_compra As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_venta As System.Windows.Forms.TextBox
    Friend WithEvents txt_cuenta_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_des_dev As System.Windows.Forms.TextBox
    Friend WithEvents txt_des_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_des_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_des_venta As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_compra As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_devoluciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_descuento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_sugerencia As System.Windows.Forms.Label
    Friend WithEvents btn_ayuda_dev As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_desc As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_costo As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_venta As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_compra As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lbl_nombre_producto As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_receta As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nombre_receta As System.Windows.Forms.Label
    Friend WithEvents gb_sugerencia As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_procesar_productos))
        Me.group_encabezado = New System.Windows.Forms.GroupBox()
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grupo_Cuentas = New System.Windows.Forms.GroupBox()
        Me.btn_ayuda_dev = New System.Windows.Forms.Button()
        Me.btn_ayuda_desc = New System.Windows.Forms.Button()
        Me.btn_ayuda_costo = New System.Windows.Forms.Button()
        Me.btn_ayuda_venta = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_des_dev = New System.Windows.Forms.TextBox()
        Me.txt_des_desc = New System.Windows.Forms.TextBox()
        Me.txt_des_costo = New System.Windows.Forms.TextBox()
        Me.txt_des_venta = New System.Windows.Forms.TextBox()
        Me.txt_cta_devoluciones = New System.Windows.Forms.TextBox()
        Me.txt_cta_descuento = New System.Windows.Forms.TextBox()
        Me.txt_desc_compra = New System.Windows.Forms.TextBox()
        Me.txt_cuenta_costo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_cta_venta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_cta_compra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_ayuda_compra = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.check_impuestos = New System.Windows.Forms.CheckedListBox()
        Me.grupo_indicadores = New System.Windows.Forms.GroupBox()
        Me.check_indicadores = New System.Windows.Forms.CheckedListBox()
        Me.grupo_analisis = New System.Windows.Forms.GroupBox()
        Me.dg_analisis = New System.Windows.Forms.DataGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dg_codigos = New System.Windows.Forms.DataGrid()
        Me.codigosBarra = New System.Windows.Forms.DataGridTableStyle()
        Me.codigo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.unidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.factor = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tc_control = New System.Windows.Forms.TabControl()
        Me.tp_producto = New System.Windows.Forms.TabPage()
        Me.lbl_nombre_producto = New System.Windows.Forms.Label()
        Me.gb_sugerencia = New System.Windows.Forms.GroupBox()
        Me.lbl_sugerencia = New System.Windows.Forms.Label()
        Me.atributos = New System.Windows.Forms.TabPage()
        Me.tp_analisis = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_pais_compra = New System.Windows.Forms.TextBox()
        Me.txt_nombre_receta = New System.Windows.Forms.TextBox()
        Me.txt_tipo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_nombre_receta = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.group_encabezado.SuspendLayout()
        Me.grupo_Cuentas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grupo_indicadores.SuspendLayout()
        Me.grupo_analisis.SuspendLayout()
        CType(Me.dg_analisis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_codigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_control.SuspendLayout()
        Me.tp_producto.SuspendLayout()
        Me.gb_sugerencia.SuspendLayout()
        Me.atributos.SuspendLayout()
        Me.tp_analisis.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'group_encabezado
        '
        Me.group_encabezado.Controls.Add(Me.txt_codigo_producto)
        Me.group_encabezado.Controls.Add(Me.Label1)
        Me.group_encabezado.Location = New System.Drawing.Point(12, 20)
        Me.group_encabezado.Name = "group_encabezado"
        Me.group_encabezado.Size = New System.Drawing.Size(228, 39)
        Me.group_encabezado.TabIndex = 0
        Me.group_encabezado.TabStop = False
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(106, 14)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.Size = New System.Drawing.Size(101, 20)
        Me.txt_codigo_producto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Producto"
        '
        'btn_procesar
        '
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_procesar.ImageIndex = 0
        Me.btn_procesar.ImageList = Me.ImageList1
        Me.btn_procesar.Location = New System.Drawing.Point(12, 10)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(96, 32)
        Me.btn_procesar.TabIndex = 0
        Me.btn_procesar.Text = "Procesar"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        '
        'grupo_Cuentas
        '
        Me.grupo_Cuentas.Controls.Add(Me.btn_ayuda_dev)
        Me.grupo_Cuentas.Controls.Add(Me.btn_ayuda_desc)
        Me.grupo_Cuentas.Controls.Add(Me.btn_ayuda_costo)
        Me.grupo_Cuentas.Controls.Add(Me.btn_ayuda_venta)
        Me.grupo_Cuentas.Controls.Add(Me.Label10)
        Me.grupo_Cuentas.Controls.Add(Me.Label9)
        Me.grupo_Cuentas.Controls.Add(Me.txt_des_dev)
        Me.grupo_Cuentas.Controls.Add(Me.txt_des_desc)
        Me.grupo_Cuentas.Controls.Add(Me.txt_des_costo)
        Me.grupo_Cuentas.Controls.Add(Me.txt_des_venta)
        Me.grupo_Cuentas.Controls.Add(Me.txt_cta_devoluciones)
        Me.grupo_Cuentas.Controls.Add(Me.txt_cta_descuento)
        Me.grupo_Cuentas.Controls.Add(Me.txt_desc_compra)
        Me.grupo_Cuentas.Controls.Add(Me.txt_cuenta_costo)
        Me.grupo_Cuentas.Controls.Add(Me.Label4)
        Me.grupo_Cuentas.Controls.Add(Me.txt_cta_venta)
        Me.grupo_Cuentas.Controls.Add(Me.Label3)
        Me.grupo_Cuentas.Controls.Add(Me.txt_cta_compra)
        Me.grupo_Cuentas.Controls.Add(Me.Label2)
        Me.grupo_Cuentas.Controls.Add(Me.btn_ayuda_compra)
        Me.grupo_Cuentas.Location = New System.Drawing.Point(12, 67)
        Me.grupo_Cuentas.Name = "grupo_Cuentas"
        Me.grupo_Cuentas.Size = New System.Drawing.Size(488, 168)
        Me.grupo_Cuentas.TabIndex = 1
        Me.grupo_Cuentas.TabStop = False
        Me.grupo_Cuentas.Text = "Cuentas"
        '
        'btn_ayuda_dev
        '
        Me.btn_ayuda_dev.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_dev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_dev.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_dev.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_dev.Location = New System.Drawing.Point(176, 136)
        Me.btn_ayuda_dev.Name = "btn_ayuda_dev"
        Me.btn_ayuda_dev.Size = New System.Drawing.Size(16, 20)
        Me.btn_ayuda_dev.TabIndex = 18
        Me.btn_ayuda_dev.Text = "?"
        Me.btn_ayuda_dev.UseVisualStyleBackColor = False
        '
        'btn_ayuda_desc
        '
        Me.btn_ayuda_desc.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_desc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_desc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_desc.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_desc.Location = New System.Drawing.Point(176, 108)
        Me.btn_ayuda_desc.Name = "btn_ayuda_desc"
        Me.btn_ayuda_desc.Size = New System.Drawing.Size(16, 20)
        Me.btn_ayuda_desc.TabIndex = 14
        Me.btn_ayuda_desc.Text = "?"
        Me.btn_ayuda_desc.UseVisualStyleBackColor = False
        '
        'btn_ayuda_costo
        '
        Me.btn_ayuda_costo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_costo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_costo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_costo.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_costo.Location = New System.Drawing.Point(176, 80)
        Me.btn_ayuda_costo.Name = "btn_ayuda_costo"
        Me.btn_ayuda_costo.Size = New System.Drawing.Size(16, 20)
        Me.btn_ayuda_costo.TabIndex = 10
        Me.btn_ayuda_costo.Text = "?"
        Me.btn_ayuda_costo.UseVisualStyleBackColor = False
        '
        'btn_ayuda_venta
        '
        Me.btn_ayuda_venta.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_venta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_venta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_venta.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_venta.Location = New System.Drawing.Point(176, 52)
        Me.btn_ayuda_venta.Name = "btn_ayuda_venta"
        Me.btn_ayuda_venta.Size = New System.Drawing.Size(16, 20)
        Me.btn_ayuda_venta.TabIndex = 6
        Me.btn_ayuda_venta.Text = "?"
        Me.btn_ayuda_venta.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Devoluciones"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Descuento"
        '
        'txt_des_dev
        '
        Me.txt_des_dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_des_dev.Location = New System.Drawing.Point(200, 136)
        Me.txt_des_dev.Name = "txt_des_dev"
        Me.txt_des_dev.ReadOnly = True
        Me.txt_des_dev.Size = New System.Drawing.Size(272, 20)
        Me.txt_des_dev.TabIndex = 19
        Me.txt_des_dev.TabStop = False
        '
        'txt_des_desc
        '
        Me.txt_des_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_des_desc.Location = New System.Drawing.Point(200, 108)
        Me.txt_des_desc.Name = "txt_des_desc"
        Me.txt_des_desc.ReadOnly = True
        Me.txt_des_desc.Size = New System.Drawing.Size(272, 20)
        Me.txt_des_desc.TabIndex = 15
        Me.txt_des_desc.TabStop = False
        '
        'txt_des_costo
        '
        Me.txt_des_costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_des_costo.Location = New System.Drawing.Point(200, 80)
        Me.txt_des_costo.Name = "txt_des_costo"
        Me.txt_des_costo.ReadOnly = True
        Me.txt_des_costo.Size = New System.Drawing.Size(272, 20)
        Me.txt_des_costo.TabIndex = 11
        Me.txt_des_costo.TabStop = False
        '
        'txt_des_venta
        '
        Me.txt_des_venta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_des_venta.Location = New System.Drawing.Point(200, 52)
        Me.txt_des_venta.Name = "txt_des_venta"
        Me.txt_des_venta.ReadOnly = True
        Me.txt_des_venta.Size = New System.Drawing.Size(272, 20)
        Me.txt_des_venta.TabIndex = 7
        Me.txt_des_venta.TabStop = False
        '
        'txt_cta_devoluciones
        '
        Me.txt_cta_devoluciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cta_devoluciones.Location = New System.Drawing.Point(88, 136)
        Me.txt_cta_devoluciones.Name = "txt_cta_devoluciones"
        Me.txt_cta_devoluciones.Size = New System.Drawing.Size(88, 20)
        Me.txt_cta_devoluciones.TabIndex = 17
        '
        'txt_cta_descuento
        '
        Me.txt_cta_descuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cta_descuento.Location = New System.Drawing.Point(88, 108)
        Me.txt_cta_descuento.Name = "txt_cta_descuento"
        Me.txt_cta_descuento.Size = New System.Drawing.Size(88, 20)
        Me.txt_cta_descuento.TabIndex = 13
        '
        'txt_desc_compra
        '
        Me.txt_desc_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_desc_compra.Location = New System.Drawing.Point(200, 24)
        Me.txt_desc_compra.Name = "txt_desc_compra"
        Me.txt_desc_compra.ReadOnly = True
        Me.txt_desc_compra.Size = New System.Drawing.Size(272, 20)
        Me.txt_desc_compra.TabIndex = 3
        Me.txt_desc_compra.TabStop = False
        '
        'txt_cuenta_costo
        '
        Me.txt_cuenta_costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cuenta_costo.Location = New System.Drawing.Point(88, 80)
        Me.txt_cuenta_costo.Name = "txt_cuenta_costo"
        Me.txt_cuenta_costo.Size = New System.Drawing.Size(88, 20)
        Me.txt_cuenta_costo.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Costo:"
        '
        'txt_cta_venta
        '
        Me.txt_cta_venta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cta_venta.Location = New System.Drawing.Point(88, 52)
        Me.txt_cta_venta.Name = "txt_cta_venta"
        Me.txt_cta_venta.Size = New System.Drawing.Size(88, 20)
        Me.txt_cta_venta.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Venta:"
        '
        'txt_cta_compra
        '
        Me.txt_cta_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cta_compra.Location = New System.Drawing.Point(88, 24)
        Me.txt_cta_compra.Name = "txt_cta_compra"
        Me.txt_cta_compra.Size = New System.Drawing.Size(88, 20)
        Me.txt_cta_compra.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Compra:"
        '
        'btn_ayuda_compra
        '
        Me.btn_ayuda_compra.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda_compra.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda_compra.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda_compra.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda_compra.Location = New System.Drawing.Point(176, 24)
        Me.btn_ayuda_compra.Name = "btn_ayuda_compra"
        Me.btn_ayuda_compra.Size = New System.Drawing.Size(16, 20)
        Me.btn_ayuda_compra.TabIndex = 2
        Me.btn_ayuda_compra.Text = "?"
        Me.btn_ayuda_compra.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.check_impuestos)
        Me.GroupBox2.Location = New System.Drawing.Point(260, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 144)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Impuestos"
        '
        'check_impuestos
        '
        Me.check_impuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.check_impuestos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.check_impuestos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.check_impuestos.CheckOnClick = True
        Me.check_impuestos.Location = New System.Drawing.Point(8, 16)
        Me.check_impuestos.Name = "check_impuestos"
        Me.check_impuestos.Size = New System.Drawing.Size(224, 120)
        Me.check_impuestos.TabIndex = 0
        '
        'grupo_indicadores
        '
        Me.grupo_indicadores.Controls.Add(Me.check_indicadores)
        Me.grupo_indicadores.Location = New System.Drawing.Point(12, 243)
        Me.grupo_indicadores.Name = "grupo_indicadores"
        Me.grupo_indicadores.Size = New System.Drawing.Size(232, 144)
        Me.grupo_indicadores.TabIndex = 2
        Me.grupo_indicadores.TabStop = False
        Me.grupo_indicadores.Text = "Indicadores"
        '
        'check_indicadores
        '
        Me.check_indicadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.check_indicadores.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.check_indicadores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.check_indicadores.CheckOnClick = True
        Me.check_indicadores.Items.AddRange(New Object() {" Control de Lotes", " Control de Series", " Fecha de Vencimiento", " Corrección Monetaria ", " Depreciación", " Costeable", " Valida Stock", " Producto Compuesto", " Kit Virtual"})
        Me.check_indicadores.Location = New System.Drawing.Point(8, 16)
        Me.check_indicadores.Name = "check_indicadores"
        Me.check_indicadores.Size = New System.Drawing.Size(216, 120)
        Me.check_indicadores.TabIndex = 0
        '
        'grupo_analisis
        '
        Me.grupo_analisis.Controls.Add(Me.dg_analisis)
        Me.grupo_analisis.Location = New System.Drawing.Point(23, 168)
        Me.grupo_analisis.Name = "grupo_analisis"
        Me.grupo_analisis.Size = New System.Drawing.Size(336, 213)
        Me.grupo_analisis.TabIndex = 1
        Me.grupo_analisis.TabStop = False
        '
        'dg_analisis
        '
        Me.dg_analisis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_analisis.CaptionText = "Análisis Contable"
        Me.dg_analisis.DataMember = ""
        Me.dg_analisis.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_analisis.Location = New System.Drawing.Point(8, 16)
        Me.dg_analisis.Name = "dg_analisis"
        Me.dg_analisis.RowHeadersVisible = False
        Me.dg_analisis.Size = New System.Drawing.Size(320, 189)
        Me.dg_analisis.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dg_codigos)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 152)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dg_codigos
        '
        Me.dg_codigos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_codigos.CaptionText = "Código de Barras"
        Me.dg_codigos.DataMember = ""
        Me.dg_codigos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_codigos.Location = New System.Drawing.Point(8, 16)
        Me.dg_codigos.Name = "dg_codigos"
        Me.dg_codigos.RowHeadersVisible = False
        Me.dg_codigos.Size = New System.Drawing.Size(320, 128)
        Me.dg_codigos.TabIndex = 0
        Me.dg_codigos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.codigosBarra})
        '
        'codigosBarra
        '
        Me.codigosBarra.DataGrid = Me.dg_codigos
        Me.codigosBarra.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.codigo, Me.unidad, Me.factor})
        Me.codigosBarra.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'codigo
        '
        Me.codigo.Format = ""
        Me.codigo.FormatInfo = Nothing
        Me.codigo.HeaderText = "Código de Barra"
        Me.codigo.Width = 125
        '
        'unidad
        '
        Me.unidad.Format = ""
        Me.unidad.FormatInfo = Nothing
        Me.unidad.HeaderText = "Unidad"
        Me.unidad.Width = 60
        '
        'factor
        '
        Me.factor.Format = ""
        Me.factor.FormatInfo = Nothing
        Me.factor.HeaderText = "Factor"
        Me.factor.Width = 60
        '
        'tc_control
        '
        Me.tc_control.Controls.Add(Me.tp_producto)
        Me.tc_control.Controls.Add(Me.atributos)
        Me.tc_control.Controls.Add(Me.tp_analisis)
        Me.tc_control.Location = New System.Drawing.Point(0, 0)
        Me.tc_control.Name = "tc_control"
        Me.tc_control.SelectedIndex = 0
        Me.tc_control.Size = New System.Drawing.Size(520, 424)
        Me.tc_control.TabIndex = 0
        '
        'tp_producto
        '
        Me.tp_producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_producto.Controls.Add(Me.lbl_nombre_producto)
        Me.tp_producto.Controls.Add(Me.group_encabezado)
        Me.tp_producto.Controls.Add(Me.grupo_Cuentas)
        Me.tp_producto.Controls.Add(Me.grupo_indicadores)
        Me.tp_producto.Controls.Add(Me.GroupBox2)
        Me.tp_producto.Controls.Add(Me.gb_sugerencia)
        Me.tp_producto.Location = New System.Drawing.Point(4, 23)
        Me.tp_producto.Name = "tp_producto"
        Me.tp_producto.Size = New System.Drawing.Size(512, 397)
        Me.tp_producto.TabIndex = 0
        Me.tp_producto.Text = "Producto"
        '
        'lbl_nombre_producto
        '
        Me.lbl_nombre_producto.AutoSize = True
        Me.lbl_nombre_producto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre_producto.Location = New System.Drawing.Point(17, 6)
        Me.lbl_nombre_producto.Name = "lbl_nombre_producto"
        Me.lbl_nombre_producto.Size = New System.Drawing.Size(43, 14)
        Me.lbl_nombre_producto.TabIndex = 5
        Me.lbl_nombre_producto.Text = "Label5"
        '
        'gb_sugerencia
        '
        Me.gb_sugerencia.Controls.Add(Me.lbl_sugerencia)
        Me.gb_sugerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_sugerencia.Location = New System.Drawing.Point(248, 20)
        Me.gb_sugerencia.Name = "gb_sugerencia"
        Me.gb_sugerencia.Size = New System.Drawing.Size(120, 39)
        Me.gb_sugerencia.TabIndex = 4
        Me.gb_sugerencia.TabStop = False
        Me.gb_sugerencia.Text = "Código Sugerido"
        '
        'lbl_sugerencia
        '
        Me.lbl_sugerencia.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sugerencia.Location = New System.Drawing.Point(13, 18)
        Me.lbl_sugerencia.Name = "lbl_sugerencia"
        Me.lbl_sugerencia.Size = New System.Drawing.Size(94, 16)
        Me.lbl_sugerencia.TabIndex = 0
        Me.lbl_sugerencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'atributos
        '
        Me.atributos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.atributos.Controls.Add(Me.GroupBox1)
        Me.atributos.Controls.Add(Me.grupo_analisis)
        Me.atributos.Location = New System.Drawing.Point(4, 23)
        Me.atributos.Name = "atributos"
        Me.atributos.Size = New System.Drawing.Size(512, 397)
        Me.atributos.TabIndex = 1
        Me.atributos.Text = "Atributos"
        '
        'tp_analisis
        '
        Me.tp_analisis.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_analisis.Controls.Add(Me.GroupBox3)
        Me.tp_analisis.Location = New System.Drawing.Point(4, 23)
        Me.tp_analisis.Name = "tp_analisis"
        Me.tp_analisis.Size = New System.Drawing.Size(512, 397)
        Me.tp_analisis.TabIndex = 2
        Me.tp_analisis.Text = "Analisis"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_pais_compra)
        Me.GroupBox3.Controls.Add(Me.txt_nombre_receta)
        Me.GroupBox3.Controls.Add(Me.txt_tipo)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.lbl_nombre_receta)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(88, 125)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 146)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txt_pais_compra
        '
        Me.txt_pais_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pais_compra.Location = New System.Drawing.Point(139, 85)
        Me.txt_pais_compra.Name = "txt_pais_compra"
        Me.txt_pais_compra.Size = New System.Drawing.Size(154, 20)
        Me.txt_pais_compra.TabIndex = 7
        '
        'txt_nombre_receta
        '
        Me.txt_nombre_receta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_receta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nombre_receta.Location = New System.Drawing.Point(139, 19)
        Me.txt_nombre_receta.MaxLength = 20
        Me.txt_nombre_receta.Name = "txt_nombre_receta"
        Me.txt_nombre_receta.Size = New System.Drawing.Size(154, 20)
        Me.txt_nombre_receta.TabIndex = 6
        Me.txt_nombre_receta.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_tipo.Location = New System.Drawing.Point(139, 49)
        Me.txt_tipo.MaxLength = 1
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(100, 20)
        Me.txt_tipo.TabIndex = 6
        Me.txt_tipo.Text = "C"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(43, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "País Compra:"
        '
        'lbl_nombre_receta
        '
        Me.lbl_nombre_receta.Location = New System.Drawing.Point(43, 22)
        Me.lbl_nombre_receta.Name = "lbl_nombre_receta"
        Me.lbl_nombre_receta.Size = New System.Drawing.Size(90, 20)
        Me.lbl_nombre_receta.TabIndex = 2
        Me.lbl_nombre_receta.Text = "Nombre Receta"
        Me.lbl_nombre_receta.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(43, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Pareto:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_procesar)
        Me.GroupBox5.Location = New System.Drawing.Point(384, 43)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(120, 41)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'frm_procesar_productos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(520, 424)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.tc_control)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_procesar_productos"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Procesar Producto .::"
        Me.group_encabezado.ResumeLayout(False)
        Me.group_encabezado.PerformLayout()
        Me.grupo_Cuentas.ResumeLayout(False)
        Me.grupo_Cuentas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grupo_indicadores.ResumeLayout(False)
        Me.grupo_analisis.ResumeLayout(False)
        CType(Me.dg_analisis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dg_codigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_control.ResumeLayout(False)
        Me.tp_producto.ResumeLayout(False)
        Me.tp_producto.PerformLayout()
        Me.gb_sugerencia.ResumeLayout(False)
        Me.atributos.ResumeLayout(False)
        Me.tp_analisis.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public codigo_barra As String = String.Empty
    Public familia As String = String.Empty
    Public impuesto_dai As DataTable
    Public dt_precios, dt_productos_pack As DataTable
    Public dr_seleccion As DataRow
    Public cod_producto As String = String.Empty
    Public d_accion As String = String.Empty
    Public indice_dai As Integer
    Public no_solicitud As Integer
    Public tipo As String
    Public bu As String
    Public serie As String
    Public lote As String
    Public tipo_proveedor As String = ""

    Dim dsInfo As New DataSet

    Private Sub Incializar_Tablas()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt_info As DataTable

        Try
            Otrans.open()

            Dim empresa As String = String.Empty
            Dim producto As String = String.Empty
            empresa = gs_empresa

            txt_codigo_producto.Text = cod_producto

            If txt_codigo_producto.Text.Trim.Length > 0 Then
                producto = txt_codigo_producto.Text
            End If

            ls_sql = "pa_var_um_producto '" & empresa & "', '" & producto & "'"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "producto"
            dsInfo.Tables.Add(dt_info.Copy)

            ls_sql = "pa_sel_um_cuentas_contables '" & empresa & "'"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "cta_contables"
            dsInfo.Tables.Add(dt_info.Copy)

            ls_sql = "pa_sel_um_prodcodbarra '" & empresa & "', ''"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "prod_cod_barra"
            dsInfo.Tables.Add(dt_info.Copy)


            ls_sql = "pa_var_um_listaprecioD '" & empresa & "', ''"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "lista_precio_D"
            dsInfo.Tables.Add(dt_info.Copy)

            ls_sql = "pa_sel_um_ProdReceta '" & empresa & "',''"
            dt_info = Otrans.Obtiene(ls_sql)
            dt_info.TableName = "prodReceta"
            dsInfo.Tables.Add(dt_info.Copy)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub crear_listas()
        Dim analisis As String = "CLIENTES|PROVEEDORES|CENTROS DE COSTO|ITEM GASTOS|PERSONAL|RUBRO|RESPONSABLE|" & _
                                 "AP|MARCA|VENDEDOR|FLUJOS DE CAJA|CLASE IVA|MOTIVO|FECHA DE VENCIMIENTO|PARIDAD MONEDA"

        For ii As Integer = 0 To impuesto_dai.Rows.Count - 1
            check_impuestos.Items.Add(impuesto_dai.Rows(ii)("texto1"))

            If impuesto_dai.Rows(ii)("texto1") = "IVA" Then
                check_impuestos.SetItemChecked(ii, True)
            End If
            If gs_empresa = "TECNO" Then
                If impuesto_dai.Rows(ii)("texto1") = "DAI 0" Then
                    check_impuestos.SetItemChecked(ii, True)
                End If
            End If

        Next

        Dim lista_analisis() As String = Split(analisis, "|")

        Llenar_Grids(lista_analisis)
    End Sub

    Public Sub inicializarForma()
        Incializar_Tablas()
        crear_listas()

        'If txt_codigo_producto.Text.Trim.Length > 0 Then
        '    txt_codigo_producto.ReadOnly = True
        '    mostrar_info()
        'End If

        'If d_accion.ToLower = "alta" Then
        sugerencia_codigo()
        'Else
        'gb_sugerencia.Visible = False
        'End If

        check_indicadores.SetItemChecked(5, True)
        check_indicadores.SetItemChecked(6, True)


        Try
            If dt_productos_pack.Rows.Count > 0 Then
                check_indicadores.SetItemChecked(7, True)
                tc_control.SelectTab(2)
                lbl_nombre_receta.Visible = True
                txt_nombre_receta.Visible = True
                tc_control.SelectTab(0)
            End If
        Catch ex As Exception

        End Try




        Try
            If Me.lote = "S" Then
                check_indicadores.SetItemChecked(0, True)
                check_indicadores.SetItemChecked(2, True)
            End If
        Catch ex As Exception

        End Try


        Try
            If Me.serie = "S" Then
                check_indicadores.SetItemChecked(1, True)
            End If
        Catch ex As Exception

        End Try

        '(c) 20200916 Cuentas por Default
        Try
            If gs_empresa = "TECNO" Then
                Me.txt_cta_compra.Text = "040101010200"
                Me.txt_cta_venta.Text = "040101010100"
                Me.txt_cuenta_costo.Text = "050101010100"
                Me.txt_cta_descuento.Text = "040101010300"
                Me.txt_cta_devoluciones.Text = "040101010200"
            End If

            ' FASE 2: Pre-cargar cuentas sugeridas desde umb_asignacion_cuentas_log
            PrecargarCuentasSugeridas()

            ' Auto-marcar IMPUESTO DISTRIBUCION segun tipo_proveedor
            ' INTERNACIONAL => marcar / LOCAL o vacio => desmarcar (consistencia)
            Try
                For i As Integer = 0 To check_impuestos.Items.Count - 1
                    If check_impuestos.Items(i).ToString().ToUpper().Contains("DISTRIBUCION") Then
                        check_impuestos.SetItemChecked(i, (Me.tipo_proveedor = "INTERNACIONAL"))
                        Exit For
                    End If
                Next
            Catch
            End Try

        Catch ex As Exception

        Finally

            descripcion_cuenta(txt_cta_compra, txt_desc_compra)
            descripcion_cuenta(txt_cta_venta, txt_des_venta)
            descripcion_cuenta(txt_cuenta_costo, txt_des_costo)
            descripcion_cuenta(txt_cta_descuento, txt_des_desc)
            descripcion_cuenta(txt_cta_devoluciones, txt_des_dev)

        End Try


    End Sub

    ' ================================================================
    ' Pre-carga automatica de cuentas sugeridas desde el log
    ' Lee de flexline.umb_asignacion_cuentas_log y rellena los 5 textboxes
    ' Solo se ejecuta si los textboxes estan vacios (no pisa TECNO ni producto existente)
    ' WITH (NOLOCK) para ver fila del trigger aunque su transaccion no haya commit-eado
    ' ================================================================
    Private Sub PrecargarCuentasSugeridas()
        If no_solicitud <= 0 Then Exit Sub
        If Me.txt_cta_compra.Text.Trim.Length > 0 Then Exit Sub

        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Try
            cOtrans.open()
            Dim sql As String = _
                "SELECT TOP 1 l.sug_cta_compra, l.sug_cta_venta, l.sug_cta_costo, " & _
                "             l.sug_cta_desc,   l.sug_cta_dev " & _
                "FROM flexline.umb_asignacion_cuentas_log l WITH (NOLOCK) " & _
                "INNER JOIN flexline.inv_producto_solicitud s WITH (NOLOCK) ON s.cod_solicitud = l.cod_solicitud " & _
                "WHERE s.numero = " & no_solicitud & _
                " AND s.empresa = '" & gs_empresa.Replace("'", "''") & "' " & _
                " AND l.sug_cta_compra IS NOT NULL"

            Dim dt As DataTable = cOtrans.Obtiene(sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.txt_cta_compra.Text       = dt.Rows(0).Item("sug_cta_compra").ToString()
                Me.txt_cta_venta.Text        = dt.Rows(0).Item("sug_cta_venta").ToString()
                Me.txt_cuenta_costo.Text     = dt.Rows(0).Item("sug_cta_costo").ToString()
                Me.txt_cta_descuento.Text    = dt.Rows(0).Item("sug_cta_desc").ToString()
                Me.txt_cta_devoluciones.Text = dt.Rows(0).Item("sug_cta_dev").ToString()
            End If
        Catch
        Finally
            cOtrans.close()
            cOtrans = Nothing
        End Try
    End Sub

    Private Sub frm_procesar_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializarForma()
    End Sub

    Private Sub mostrar_info()
        With dsInfo.Tables("producto").Rows(0)
            txt_cta_compra.Text = .Item("cuentacompra")
            txt_cta_venta.Text = .Item("cuentaventa")
            txt_cuenta_costo.Text = .Item("cuentacosto")
            txt_cta_descuento.Text = IIf(.IsNull("cuentadesc") = True, "", .Item("cuentadesc").ToString)
            txt_cta_devoluciones.Text = IIf(.IsNull("cuentadesc") = True, "", .Item("cuentadev").ToString)

            txt_tipo.Text = .Item("analisisproducto3")
            txt_pais_compra.Text = .Item("analisisproducto4")

            check_indicadores.SetItemChecked(0, IIf(.Item("lote") = "S", True, False))
            check_indicadores.SetItemChecked(1, IIf(.Item("serie") = "S", True, False))
            check_indicadores.SetItemChecked(2, IIf(.Item("fechavcto") = "S", True, False))
            check_indicadores.SetItemChecked(3, IIf(.Item("cmonetaria") = "S", True, False))
            check_indicadores.SetItemChecked(4, IIf(.Item("depreciable") = "S", True, False))
            check_indicadores.SetItemChecked(5, IIf(.Item("costeable") = "S", True, False))
            check_indicadores.SetItemChecked(6, IIf(.Item("validastock") = "S", True, False))
            check_indicadores.SetItemChecked(7, IIf(.Item("compuesto") = "S", True, False))
            check_indicadores.SetItemChecked(8, IIf(.Item("kitvirtual") = "S", True, False))


            For ii As Integer = 0 To check_impuestos.Items.Count - 1
                check_impuestos.SetItemChecked(ii, IIf(.Item("factor" & ii + 1) = 1, True, False))
            Next

            For ii As Integer = 0 To dsInfo.Tables("dt_productos").Rows.Count - 1
                dsInfo.Tables("dt_productos").Rows(ii)("tipo_analisis") = .Item("aux_valor" & CStr(ii + 1))
            Next

            If txt_cta_compra.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_compra, txt_desc_compra)
            If txt_cta_venta.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_venta, txt_des_venta)
            If txt_cuenta_costo.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cuenta_costo, txt_des_costo)
            If txt_cta_descuento.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_descuento, txt_des_desc)
            If txt_cta_devoluciones.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_devoluciones, txt_des_dev)

            txt_pais_compra.Text = .Item("procedencia")
        End With
    End Sub

    Private Sub sugerencia_codigo()
        check_impuestos.SetItemChecked(0, True)
        check_impuestos.SetItemChecked(indice_dai, True)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            Otrans.open()

            ls_sql = "pa_var_nuevo_codigo '" & gs_empresa & "','" & dr_seleccion("familia") & "','" & dr_seleccion("subfamilia") & "','" & dr_seleccion("tipoproducto") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "nuevoCodigo"

            If dt.Rows(0).IsNull("NUEVOCODIGO") Then
                lbl_sugerencia.Text = ""
            Else
                lbl_sugerencia.Text = dt.Rows(0)("NUEVOCODIGO")
                Me.txt_codigo_producto.Text = dt.Rows(0)("NUEVOCODIGO")
                dsInfo.Tables("codigoBarra").Rows(0)("codigo") = txt_codigo_producto.Text
                dsInfo.Tables("codigoBarra").Rows(1)("codigo") = Mid(txt_codigo_producto.Text, 3)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Llenar_Grids(ByVal datos() As String)
        Dim dt As New DataTable("dt_productos")
        Dim dts As New DataTable("listaOpciones")
        Dim dtC As New DataTable("codigoBarra")

        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_analisis", GetType(Integer)))
        dsInfo.Tables.Add(dt)

        dts.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dts.Columns.Add(New DataColumn("codigo", GetType(Integer)))
        dsInfo.Tables.Add(dts)

        dtC.Columns.Add(New DataColumn("codigo", GetType(String)))
        dtC.Columns.Add(New DataColumn("unidad", GetType(String)))
        dtC.Columns.Add(New DataColumn("factor", GetType(Integer)))
        dsInfo.Tables.Add(dtC)

        Dim mRow As DataRow = dts.NewRow
        mRow("codigo") = 0
        mRow("descripcion") = "No Utilizado"
        dts.Rows.Add(mRow)

        Dim mRow2 As DataRow = dts.NewRow
        mRow2("codigo") = 1
        mRow2("descripcion") = "Opcional"
        dts.Rows.Add(mRow2)

        Dim mRow3 As DataRow = dts.NewRow
        mRow3("codigo") = 2
        mRow3("descripcion") = "Obligatorio"
        dts.Rows.Add(mRow3)

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "dt_productos"

        Dim TextCol As New DataGridTextBoxColumn
        TextCol.MappingName = dt.Columns(0).ColumnName
        TextCol.HeaderText = "Análsis"
        TextCol.Width = 160
        TextCol.Alignment = HorizontalAlignment.Left
        TextCol.ReadOnly = True
        tableStyle.GridColumnStyles.Add(TextCol)

        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = dt.Columns(1).ColumnName
        ComboTextCol.HeaderText = "Tipo Analisis"
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = dts.DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "codigo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight

        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5
        tableStyle.GridColumnStyles.Add(ComboTextCol)
        tableStyle.AllowSorting = False


        Me.dg_analisis.TableStyles.Clear()
        Me.dg_analisis.TableStyles.Add(tableStyle)

        dg_analisis.DataSource = dsInfo.Tables("dt_productos")

        For ii As Integer = 0 To datos.Length - 1
            Dim mdRow As DataRow = dsInfo.Tables("dt_productos").NewRow

            mdRow("descripcion") = datos(ii)
            Dim m As Integer = 0
            Select Case datos(ii)
                Case "CENTROS DE COSTO", "ITEM GASTOS", "RUBRO", "AP", "MARCA"
                    m = 1
                Case "MOTIVO"
                    m = 2
            End Select
            mdRow("tipo_analisis") = m

            dsInfo.Tables("dt_productos").Rows.Add(mdRow)
        Next

        Dim EstiloGrid As New DataGridTableStyle
        EstiloGrid.MappingName = "codigoBarra"

        Dim TextCodigo As New DataGridTextBoxColumn
        TextCodigo.MappingName = dtC.Columns(0).ColumnName
        TextCodigo.HeaderText = "Código de Barras"
        TextCodigo.Width = 130
        TextCodigo.Alignment = HorizontalAlignment.Left
        TextCodigo.ReadOnly = False
        EstiloGrid.GridColumnStyles.Add(TextCodigo)

        Dim TextUnidad As New DataGridTextBoxColumn
        TextUnidad.MappingName = dtC.Columns(1).ColumnName
        TextUnidad.HeaderText = "Unidad"
        TextUnidad.Width = 65
        TextUnidad.Alignment = HorizontalAlignment.Left
        TextUnidad.ReadOnly = False
        EstiloGrid.GridColumnStyles.Add(TextUnidad)

        Dim TextFactor As New DataGridTextBoxColumn
        TextFactor.MappingName = dtC.Columns(2).ColumnName
        TextFactor.HeaderText = "Factor"
        TextFactor.Width = 65
        TextFactor.Alignment = HorizontalAlignment.Left
        TextFactor.ReadOnly = False
        EstiloGrid.GridColumnStyles.Add(TextFactor)

        EstiloGrid.RowHeaderWidth = 5
        EstiloGrid.AllowSorting = False

        Me.dg_codigos.TableStyles.Clear()
        Me.dg_codigos.TableStyles.Add(EstiloGrid)

        Me.dg_codigos.DataSource = dsInfo.Tables("codigoBarra")

        For ii As Integer = 0 To IIf(codigo_barra.Trim.Length = 0, 1, 2)
            Dim mdRow As DataRow = dsInfo.Tables("codigoBarra").NewRow

            If ii <> 2 Then
                mdRow("codigo") = ""
                mdRow("unidad") = "UN"
                mdRow("factor") = 1
            Else
                mdRow("codigo") = codigo_barra
                mdRow("unidad") = "UN"
                mdRow("factor") = 1
            End If

            dsInfo.Tables("codigoBarra").Rows.Add(mdRow)

        Next

        If txt_codigo_producto.Text.Trim.Length > 0 Then
            dsInfo.Tables("codigoBarra").Rows(0)("codigo") = txt_codigo_producto.Text
            dsInfo.Tables("codigoBarra").Rows(1)("codigo") = Mid(txt_codigo_producto.Text, 3)
        End If
    End Sub

    Private Function pasaValidaciones() As Boolean
        If txt_codigo_producto.Text.Trim.Length = 0 Then
            MessageBox.Show("Aún no ha ingresado el código del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_codigo_producto.Focus()
            Return False
        End If

        If gs_empresa.ToUpper <> "DMARTE1" Then
            If txt_cta_compra.Text.Trim.Length = 0 Then
                MessageBox.Show("Aún no ha ingresado la cuenta de compra.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_cta_compra.Focus()
                Return False
            End If

            If txt_cta_venta.Text.Trim.Length = 0 Then
                MessageBox.Show("Aún no ha ingresado la cuenta de venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_cta_venta.Focus()
                Return False
            End If

            If txt_cuenta_costo.Text.Trim.Length = 0 Then
                MessageBox.Show("Aún no ha ingresado la cuenta de costo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_cuenta_costo.Focus()
                Return False
            End If
        End If

        If txt_tipo.Text.Trim.Length = 0 Then
            MessageBox.Show("Aún no ha ingresado el tipo del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_cuenta_costo.Focus()
            Return False
        End If

        If txt_pais_compra.Text.Trim.Length = 0 Then
            MessageBox.Show("Aún no ha ingresado el país donde se compro el producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_cuenta_costo.Focus()
            Return False
        End If

        If txt_codigo_producto.Text.Trim.Length <> 10 Then
            MessageBox.Show("El código del producto debe de ser de 10 dígitos porfavor revise.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txt_codigo_producto.Focus()
            txt_codigo_producto.SelectAll()
            Return False
        End If

        If txt_codigo_producto.ReadOnly = False Then
            If existeProducto(gs_empresa, txt_codigo_producto.Text) Then
                MessageBox.Show("El código que ingreso ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txt_codigo_producto.Focus()
                txt_codigo_producto.SelectAll()
                Return False
            End If
        End If

        If check_indicadores.GetItemChecked(7) Then
            If txt_nombre_receta.Text.Length > 0 Then
                If existeNombreReceta() Then
                    MessageBox.Show("El Nombre de la Receta ya Existe, Debe Asignar Una Nueva", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_nombre_receta.Focus()
                    Return False
                End If

            Else
                MessageBox.Show("Debe Asignarle Nombre a la Receta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_nombre_receta.Focus()
                Return False
            End If

        End If

        Return True
    End Function

    Public Sub ProcesarSolicitud()
        Try

            If Not pasaValidaciones() Then Exit Sub

            Dim sinc As New Sincronizacion.Productos("")

            Dim mrow As DataRow = dsInfo.Tables("producto").NewRow

            mrow("empresa") = gs_empresa : mrow("producto") = Me.txt_codigo_producto.Text
            mrow("glosa") = dr_seleccion("nombre_producto") : mrow("tipoproducto") = dr_seleccion("tipoproducto")
            mrow("familia") = dr_seleccion("familia") : mrow("subfamilia") = dr_seleccion("subfamilia")
            mrow("tipo") = dr_seleccion("tipo") : mrow("subtipo") = dr_seleccion("sub_tipo")
            mrow("vigente") = "S" : mrow("unidad") = dr_seleccion("unidad")
            mrow("decimales") = 2 : mrow("precioventa") = dr_seleccion("precio_venta")
            mrow("procedencia") = dr_seleccion("procedencia") : mrow("cuentacompra") = txt_cta_compra.Text
            mrow("cuentaventa") = txt_cta_venta.Text : mrow("cuentacosto") = txt_cuenta_costo.Text
            mrow("cuentaDesc") = txt_cta_descuento.Text : mrow("cuentaDev") = txt_cta_devoluciones.Text
            mrow("unidadalt") = dr_seleccion("unidad_alt") : mrow("factoralt") = dr_seleccion("factoralt")
            mrow("decimalesalt") = 2 : mrow("serie") = IIf(check_indicadores.GetItemChecked(1) = True, "S", "N")
            mrow("lote") = IIf(check_indicadores.GetItemChecked(0) = True, "S", "N")
            mrow("fechavcto") = IIf(check_indicadores.GetItemChecked(2) = True, "S", "N")
            mrow("validastock") = IIf(check_indicadores.GetItemChecked(6) = True, "S", "N")
            mrow("cmonetaria") = IIf(check_indicadores.GetItemChecked(3) = True, "S", "N")
            mrow("costeable") = IIf(check_indicadores.GetItemChecked(5) = True, "S", "N")
            mrow("depreciable") = IIf(check_indicadores.GetItemChecked(4) = True, "S", "N")
            mrow("compuesto") = IIf(check_indicadores.GetItemChecked(7) = True, "S", "N")

            For ii As Integer = 1 To check_impuestos.Items.Count
                mrow("factor" & CStr(ii)) = check_impuestos.GetItemCheckState(ii - 1)
            Next

            For ii As Integer = 1 To 20 - check_impuestos.Items.Count
                mrow("factor" & CStr(ii + check_impuestos.Items.Count)) = "0"
            Next

            mrow("stockminimo") = "0.00" : mrow("stockmaximo") = "0.00"
            mrow("costoestandar") = "0.00" : mrow("comentario") = String.Empty
            mrow("fechamodif") = Now : mrow("costo_valor") = "0.00"
            mrow("usuariomodif") = gs_usuario.ToUpper

            'analisis producto = tab
            For ii As Integer = 1 To dsInfo.Tables("dt_productos").Rows.Count
                mrow("aux_valor" & CStr(ii)) = dsInfo.Tables("dt_productos").Rows(ii - 1)("tipo_analisis")
            Next

            For ii As Integer = 1 To 20 - dsInfo.Tables("dt_productos").Rows.Count
                mrow("aux_valor" & CStr(ii + dsInfo.Tables("dt_productos").Rows.Count)) = "0"
            Next

            mrow("diascompra") = "0" : mrow("diasproduccion") = "0"
            mrow("lotecompra") = "0" : mrow("loteproduccion") = "0"
            mrow("stockreposicion") = "0" : mrow("peso") = dr_seleccion("peso")
            mrow("volumen") = dr_seleccion("volumen") : mrow("proveedor") = ""
            mrow("kitvirtual") = IIf(check_indicadores.GetItemChecked(8) = True, "S", "N")
            mrow("productosxempaque1") = "0.00" : mrow("empaque1xempaque2") = "0.00"

            mrow("analisisproducto1") = "0" : mrow("analisisproducto2") = "0"
            mrow("analisisproducto3") = txt_tipo.Text : mrow("analisisproducto4") = txt_pais_compra.Text
            mrow("analisisproducto5") = "" : mrow("analisisproducto6") = dr_seleccion("CEPA").ToString
            mrow("analisisproducto7") = "" : mrow("analisisproducto8") = ""
            mrow("analisisproducto9") = "" : mrow("analisisproducto10") = ""

            mrow("multiple") = "N" : mrow("act_grupo") = "" : mrow("Act_SerieCartola") = ""
            mrow("analisisproducto17") = bu

            If tipo = "creacion" Then
                sinc.Actualizar_Producto(mrow)
            Else
                Actualizar_Producto(mrow)
            End If

            If sinc.codigo_error = 0 Then


                Try


                    ''Precios
                    For ii As Integer = 0 To dt_precios.Rows.Count - 1
                        Dim mNewRow As DataRow = dsInfo.Tables("lista_precio_D").NewRow

                        mNewRow("Empresa") = gs_empresa
                        mNewRow("IdLisPrecio") = dt_precios.Rows(ii)("LisPrecio")
                        mNewRow("Producto") = txt_codigo_producto.Text
                        mNewRow("Valor") = dt_precios.Rows(ii)("Precio")
                        mNewRow("Moneda") = dato_listaPrecioD("moneda", dt_precios.Rows(ii)("LisPrecio"))
                        mNewRow("lisPrecio") = dato_listaPrecioD("LisPrecio", dt_precios.Rows(ii)("LisPrecio"))
                        mNewRow("PorcMaxDesc") = 0.0
                        mNewRow("Intervalo") = 0.0
                        mNewRow("PorcentajeInt") = 0.0
                        mNewRow("Cantidad") = 0.0
                        mNewRow("Tipo") = ""
                        mNewRow("ValorC") = 0.0
                        mNewRow("FechaVigencia") = CType(dato_listaPrecioD("FechaVigencia", dt_precios.Rows(ii)("LisPrecio")), DateTime)
                        mNewRow("fec_final") = CType(dato_listaPrecioD("fec_final", dt_precios.Rows(ii)("LisPrecio")), DateTime)
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

                        dsInfo.Tables("lista_precio_D").Rows.Add(mNewRow)
                    Next

                    sinc.Actualizar_ProductoPrecio(dsInfo.Tables("lista_precio_D"))
                Catch ex As Exception

                End Try
                Try

                    ''Barras
                    For ii As Integer = 0 To dsInfo.Tables("codigoBarra").Rows.Count - 1
                        Dim mNewRow As DataRow = dsInfo.Tables("prod_cod_barra").NewRow

                        mNewRow("EMPRESA") = gs_empresa
                        mNewRow("CODBARRA") = dsInfo.Tables("codigoBarra").Rows(ii)("codigo")
                        mNewRow("PRODUCTO") = txt_codigo_producto.Text
                        mNewRow("Unidad") = dsInfo.Tables("codigoBarra").Rows(ii)("unidad")
                        mNewRow("Factor") = dsInfo.Tables("codigoBarra").Rows(ii)("factor")
                        mNewRow("Linea") = ii + 1
                        mNewRow("FactorUB") = dsInfo.Tables("codigoBarra").Rows(ii)("factor")
                        mNewRow("TipoCodigo") = ""

                        dsInfo.Tables("prod_cod_barra").Rows.Add(mNewRow)
                    Next

                    sinc.Actualizar_ProductoBarra(dsInfo.Tables("prod_cod_barra"))
                Catch ex As Exception

                End Try


                ''Productos Compuestos
                Dim icount As Integer = 0
                For Each drAux As DataRow In dt_productos_pack.Rows
                    icount += 1

                    Dim mNewRow As DataRow = dsInfo.Tables("prodReceta").NewRow
                    mNewRow("empresa") = gs_empresa
                    mNewRow("producto") = txt_codigo_producto.Text
                    mNewRow("receta") = txt_nombre_receta.Text
                    mNewRow("Linea") = icount
                    mNewRow("Proceso") = "ARMADO"
                    mNewRow("ProductoI") = drAux.Item("producto")
                    mNewRow("Cantidad") = Abs(Integer.Parse(drAux.Item("Cantidad").ToString)) * -1
                    mNewRow("UnidadI") = "UN"
                    mNewRow("CantidadI") = Abs(Integer.Parse(drAux.Item("Cantidad").ToString)) * -1

                    dsInfo.Tables("prodReceta").Rows.Add(mNewRow)
                Next

                sinc.Actualizar_ProductoReceta(dsInfo.Tables("prodReceta"), False)

                If sinc.codigo_error Then
                    MessageBox.Show(sinc.descripcion_error)
                End If



                'Dim MyTrans As New Transaccional.Conexion_mysql("onBase")

                'MyTrans.open()

                'Try
                '    Dim sql_tx As String = String.Empty

                '    sql_tx = "CALL pa_upd_um_inv_producto_codFlex ( " & no_solicitud & ",'" & txt_codigo_producto.Text & "')"
                '    MyTrans.Actualiza(sql_tx)

                'Catch ex As Exception
                '    MyTrans.close()
                '    MyTrans = Nothing
                'End Try
                DialogResult = DialogResult.OK
            Else
                DialogResult = DialogResult.Retry
            End If


        Catch ex As Exception
            DialogResult = DialogResult.Abort
        End Try

    End Sub

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        ProcesarSolicitud()
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

    Private Sub descripcion_cuenta(ByVal txt_cuenta As TextBox, ByVal txt_resultado As TextBox)
        If txt_cuenta.Text.Length > 0 Then


            Dim mRows() As DataRow = dsInfo.Tables("cta_contables").Select("CUENTA = '" & txt_cuenta.Text & "'")

            If mRows.Length > 0 Then
                txt_resultado.Text = mRows(0)("DESCRIPCION")
            Else
                MessageBox.Show("El número de cuenta ingresado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_cuenta.Text = String.Empty
                txt_cuenta.Focus()
                txt_resultado.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub txt_cta_compra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_compra.LostFocus
        If txt_cta_compra.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_compra, txt_desc_compra)
    End Sub

    Private Sub txt_cta_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_venta.LostFocus
        If txt_cta_venta.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_venta, txt_des_venta)
    End Sub

    Private Sub txt_cuenta_costo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cuenta_costo.LostFocus
        If txt_cuenta_costo.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cuenta_costo, txt_des_costo)
    End Sub

    Private Sub txt_cta_descuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_descuento.LostFocus
        If txt_cta_descuento.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_descuento, txt_des_desc)
    End Sub

    Private Sub txt_cta_devoluciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_devoluciones.LostFocus
        If txt_cta_devoluciones.Text.Trim.Length > 0 Then descripcion_cuenta(txt_cta_devoluciones, txt_des_dev)
    End Sub

    Private Function existeProducto(ByVal empresa As String, ByVal producto As String) As Boolean
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_producto '" & empresa & "','" & producto & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function

    Private Function existeNombreReceta() As Boolean
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim dt As DataTable


        Try
            oTrans.open()
            dt = oTrans.Obtiene("pa_var_um_ProdReceta '" & gs_empresa & "','" & Me.txt_nombre_receta.Text & "'")
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return True
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try
    End Function

    Private Sub btn_ayuda_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_compra.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "cuenta, descripcion"
        frm_busqueda.nombre_vista = "vi_cuentas_contables"
        frm_busqueda.lista_campos = "cuenta, descripcion"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        txt_cta_compra.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        If txt_cta_compra.Text.Trim.Length > 0 Then
            txt_cta_compra.Focus()
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btn_ayuda_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_venta.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "cuenta, descripcion"
        frm_busqueda.nombre_vista = "vi_cuentas_contables"
        frm_busqueda.lista_campos = "cuenta, descripcion"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        txt_cta_venta.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        If txt_cta_venta.Text.Trim.Length > 0 Then
            txt_cta_venta.Focus()
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btn_ayuda_costo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_costo.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "cuenta, descripcion"
        frm_busqueda.nombre_vista = "vi_cuentas_contables"
        frm_busqueda.lista_campos = "cuenta, descripcion"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        txt_cuenta_costo.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        If txt_cuenta_costo.Text.Trim.Length > 0 Then
            txt_cuenta_costo.Focus()
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btn_ayuda_desc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_desc.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "cuenta, descripcion"
        frm_busqueda.nombre_vista = "vi_cuentas_contables"
        frm_busqueda.lista_campos = "cuenta, descripcion"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        txt_cta_descuento.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        If txt_cta_descuento.Text.Trim.Length > 0 Then
            txt_cta_descuento.Focus()
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btn_ayuda_dev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_dev.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "cuenta, descripcion"
        frm_busqueda.nombre_vista = "vi_cuentas_contables"
        frm_busqueda.lista_campos = "cuenta, descripcion"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        txt_cta_devoluciones.Text = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        If txt_cta_devoluciones.Text.Trim.Length > 0 Then
            txt_cta_devoluciones.Focus()
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txt_codigo_producto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.Leave
        If tipo.Trim.ToLower = "modificacion" Then Exit Sub

        If txt_codigo_producto.Text.Trim.Length <= 0 Then Exit Sub

        If txt_codigo_producto.Text.Trim.Length <> 10 Then
            MessageBox.Show("El código del producto debe de ser de 10 dígitos porfavor revise.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txt_codigo_producto.Focus()
            txt_codigo_producto.SelectAll()
            Exit Sub
        End If

        If existeProducto(gs_empresa, txt_codigo_producto.Text) Then
            MessageBox.Show("El código que ingreso ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txt_codigo_producto.Focus()
            txt_codigo_producto.SelectAll()
            Exit Sub
        End If

        dsInfo.Tables("codigoBarra").Rows(0)("codigo") = txt_codigo_producto.Text
        dsInfo.Tables("codigoBarra").Rows(1)("codigo") = Mid(txt_codigo_producto.Text, 3)
    End Sub

    Private Function tieneMovimientos() As Boolean

        Return True
    End Function

    Private Sub Actualizar_Producto(ByVal pdr As DataRow)
        If tieneMovimientos() Then Exit Sub

        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("FlexLine")

        oTrans.open()

        Try

            ls_sql = "pa_upd_um_producto '" & pdr.Item("empresa").ToString & "','" & pdr.Item("producto").ToString & "','" & _
                    pdr.Item("glosa").ToString.Replace("'", "") & "','" & pdr.Item("tipoproducto").ToString & "','" & pdr.Item("familia").ToString & "','" & _
                    pdr.Item("subfamilia").ToString & "','" & pdr.Item("tipo").ToString.Replace("'", "") & "','" & pdr.Item("subtipo").ToString & "','" & _
                    pdr.Item("vigente").ToString & "','" & pdr.Item("unidad").ToString & "'," & pdr.Item("decimales").ToString & "," & _
                    pdr.Item("precioventa").ToString & ",'" & pdr.Item("procedencia").ToString & "','" & pdr.Item("cuentacompra").ToString & "','" & _
                    pdr.Item("cuentaventa").ToString & "','" & pdr.Item("cuentacosto").ToString & "','" & pdr.Item("unidadalt").ToString & "'," & _
                    pdr.Item("factoralt").ToString & "," & pdr.Item("decimalesalt").ToString & ",'" & pdr.Item("serie").ToString & "','" & _
                    pdr.Item("lote").ToString & "','" & pdr.Item("fechavcto").ToString & "','" & pdr.Item("validastock").ToString & "','" & _
                    pdr.Item("cmonetaria").ToString & "','" & pdr.Item("costeable").ToString & "','" & pdr.Item("depreciable").ToString & "','" & _
                    pdr.Item("compuesto").ToString & "'," & pdr.Item("factor1").ToString & "," & pdr.Item("factor2").ToString & "," & pdr.Item("factor3").ToString & "," & _
                    pdr.Item("factor4").ToString & "," & pdr.Item("factor5").ToString & "," & pdr.Item("factor6").ToString & "," & pdr.Item("factor7").ToString & "," & _
                    pdr.Item("factor8").ToString & "," & pdr.Item("factor9").ToString & "," & pdr.Item("factor10").ToString & "," & pdr.Item("factor11").ToString & "," & _
                    pdr.Item("factor12").ToString & "," & pdr.Item("factor13").ToString & "," & pdr.Item("factor14").ToString & "," & pdr.Item("factor15").ToString & "," & _
                    pdr.Item("factor16").ToString & "," & pdr.Item("factor17").ToString & "," & pdr.Item("factor18").ToString & "," & pdr.Item("factor19").ToString & "," & _
                    pdr.Item("factor20").ToString & "," & pdr.Item("stockminimo").ToString & "," & pdr.Item("stockmaximo").ToString & "," & _
                    pdr.Item("costoestandar").ToString & ",'" & pdr.Item("comentario").ToString & "','" & _
                    pdr.Item("fechamodif").ToString & "'," & pdr.Item("costo_valor").ToString & ",'" & pdr.Item("usuariomodif").ToString & "'," & _
                    pdr.Item("aux_valor1").ToString & "," & pdr.Item("aux_valor2").ToString & "," & pdr.Item("aux_valor3").ToString & "," & _
                    pdr.Item("aux_valor4").ToString & "," & pdr.Item("aux_valor5").ToString & "," & pdr.Item("aux_valor6").ToString & "," & _
                    pdr.Item("aux_valor7").ToString & "," & pdr.Item("aux_valor8").ToString & "," & pdr.Item("aux_valor9").ToString & "," & _
                    pdr.Item("aux_valor10").ToString & "," & pdr.Item("aux_valor11").ToString & "," & pdr.Item("aux_valor12").ToString & "," & _
                    pdr.Item("aux_valor13").ToString & "," & pdr.Item("aux_valor14").ToString & "," & pdr.Item("aux_valor15").ToString & "," & _
                    pdr.Item("aux_valor16").ToString & "," & pdr.Item("aux_valor17").ToString & "," & pdr.Item("aux_valor18").ToString & "," & _
                    pdr.Item("aux_valor19").ToString & "," & pdr.Item("aux_valor20").ToString & "," & _
                    pdr.Item("diascompra").ToString & "," & pdr.Item("diasproduccion").ToString & "," & _
                    pdr.Item("lotecompra").ToString & "," & pdr.Item("loteproduccion").ToString & "," & pdr.Item("stockreposicion").ToString & "," & _
                    pdr.Item("peso").ToString & "," & pdr.Item("volumen").ToString & ",'" & pdr.Item("proveedor").ToString & "','" & _
                    pdr.Item("kitvirtual").ToString & "'," & pdr.Item("productosxempaque1").ToString & "," & pdr.Item("empaque1xempaque2").ToString & ",'" & _
                    pdr.Item("analisisproducto1").ToString & "','" & pdr.Item("analisisproducto2").ToString & "','" & pdr.Item("analisisproducto3").ToString & "','" & _
                    pdr.Item("analisisproducto4").ToString & "','" & pdr.Item("analisisproducto5").ToString & "','" & pdr.Item("analisisproducto6").ToString & "','" & _
                    pdr.Item("analisisproducto7").ToString & "','" & pdr.Item("analisisproducto8").ToString & "','" & pdr.Item("analisisproducto9").ToString & "','" & _
                    pdr.Item("analisisproducto10").ToString & "','" & pdr.Item("multiple").ToString & "','" & pdr.Item("act_grupo").ToString & "','" & _
                    pdr.Item("Act_SerieCartola").ToString & "'"

            oTrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try
    End Sub
End Class