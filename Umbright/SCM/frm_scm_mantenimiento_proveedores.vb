Public Class frm_scm_mantenimiento_proveedores
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLeadTimeProv As System.Windows.Forms.TextBox
    Friend WithEvents dg_contactos As System.Windows.Forms.DataGrid
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_region As System.Windows.Forms.TextBox
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLeadTimeFlete As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCicloCompra As System.Windows.Forms.TextBox
    Friend WithEvents dgv_proveedores As System.Windows.Forms.DataGridView
    Friend WithEvents txtInvMaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPuertoSalida As System.Windows.Forms.TextBox
    Friend WithEvents txtInventarioSeguridad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtReOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txt_semanas_Max_OC As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPago As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPuertoConsolida As System.Windows.Forms.TextBox
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_mantenimiento_proveedores))
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox
        Me.cmb_origen = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPago = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_semanas_Max_OC = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLeadTimeProv = New System.Windows.Forms.TextBox
        Me.txtReOrden = New System.Windows.Forms.TextBox
        Me.txtInventarioSeguridad = New System.Windows.Forms.TextBox
        Me.txtInvMaximo = New System.Windows.Forms.TextBox
        Me.txtCicloCompra = New System.Windows.Forms.TextBox
        Me.txtLeadTimeFlete = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_origen = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPuertoConsolida = New System.Windows.Forms.TextBox
        Me.txtPuertoSalida = New System.Windows.Forms.TextBox
        Me.txt_region = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.dg_contactos = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgv_proveedores = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dg_contactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.Location = New System.Drawing.Point(94, 27)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(352, 22)
        Me.cmb_proveedor.TabIndex = 1
        '
        'cmb_origen
        '
        Me.cmb_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_origen.Location = New System.Drawing.Point(94, 51)
        Me.cmb_origen.Name = "cmb_origen"
        Me.cmb_origen.Size = New System.Drawing.Size(160, 22)
        Me.cmb_origen.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(8, 384)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(824, 143)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txt_origen)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPuertoConsolida)
        Me.TabPage1.Controls.Add(Me.txtPuertoSalida)
        Me.TabPage1.Controls.Add(Me.txt_region)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(816, 116)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPago)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_semanas_Max_OC)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLeadTimeProv)
        Me.GroupBox1.Controls.Add(Me.txtReOrden)
        Me.GroupBox1.Controls.Add(Me.txtInventarioSeguridad)
        Me.GroupBox1.Controls.Add(Me.txtInvMaximo)
        Me.GroupBox1.Controls.Add(Me.txtCicloCompra)
        Me.GroupBox1.Controls.Add(Me.txtLeadTimeFlete)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 104)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Semanas"
        '
        'txtPago
        '
        Me.txtPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPago.Location = New System.Drawing.Point(303, 77)
        Me.txtPago.Name = "txtPago"
        Me.txtPago.Size = New System.Drawing.Size(72, 20)
        Me.txtPago.TabIndex = 8
        Me.txtPago.Text = "10"
        Me.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(215, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Pago Factura"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 14)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Cambios a OC"
        '
        'txt_semanas_Max_OC
        '
        Me.txt_semanas_Max_OC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_semanas_Max_OC.Location = New System.Drawing.Point(111, 80)
        Me.txt_semanas_Max_OC.Name = "txt_semanas_Max_OC"
        Me.txt_semanas_Max_OC.Size = New System.Drawing.Size(72, 20)
        Me.txt_semanas_Max_OC.TabIndex = 3
        Me.txt_semanas_Max_OC.Text = "0"
        Me.txt_semanas_Max_OC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Ciclo de Compra"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "LeadTime Prov"
        '
        'txtLeadTimeProv
        '
        Me.txtLeadTimeProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeadTimeProv.Location = New System.Drawing.Point(111, 16)
        Me.txtLeadTimeProv.Name = "txtLeadTimeProv"
        Me.txtLeadTimeProv.Size = New System.Drawing.Size(72, 20)
        Me.txtLeadTimeProv.TabIndex = 0
        Me.txtLeadTimeProv.Text = "6"
        Me.txtLeadTimeProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReOrden
        '
        Me.txtReOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReOrden.Location = New System.Drawing.Point(303, 56)
        Me.txtReOrden.Name = "txtReOrden"
        Me.txtReOrden.Size = New System.Drawing.Size(72, 20)
        Me.txtReOrden.TabIndex = 6
        Me.txtReOrden.Text = "10"
        Me.txtReOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInventarioSeguridad
        '
        Me.txtInventarioSeguridad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventarioSeguridad.Location = New System.Drawing.Point(303, 35)
        Me.txtInventarioSeguridad.Name = "txtInventarioSeguridad"
        Me.txtInventarioSeguridad.Size = New System.Drawing.Size(72, 20)
        Me.txtInventarioSeguridad.TabIndex = 5
        Me.txtInventarioSeguridad.Text = "10"
        Me.txtInventarioSeguridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvMaximo
        '
        Me.txtInvMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvMaximo.Location = New System.Drawing.Point(303, 14)
        Me.txtInvMaximo.Name = "txtInvMaximo"
        Me.txtInvMaximo.Size = New System.Drawing.Size(72, 20)
        Me.txtInvMaximo.TabIndex = 4
        Me.txtInvMaximo.Text = "10"
        Me.txtInvMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCicloCompra
        '
        Me.txtCicloCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCicloCompra.Location = New System.Drawing.Point(111, 60)
        Me.txtCicloCompra.Name = "txtCicloCompra"
        Me.txtCicloCompra.Size = New System.Drawing.Size(72, 20)
        Me.txtCicloCompra.TabIndex = 2
        Me.txtCicloCompra.Text = "4"
        Me.txtCicloCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLeadTimeFlete
        '
        Me.txtLeadTimeFlete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeadTimeFlete.Location = New System.Drawing.Point(111, 39)
        Me.txtLeadTimeFlete.Name = "txtLeadTimeFlete"
        Me.txtLeadTimeFlete.Size = New System.Drawing.Size(72, 20)
        Me.txtLeadTimeFlete.TabIndex = 1
        Me.txtLeadTimeFlete.Text = "6"
        Me.txtLeadTimeFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(215, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Inv. ReOrden"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(215, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Inv. Seguridad"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(215, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Inv. Maximo"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "LeadTime Flete"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Origen"
        '
        'txt_origen
        '
        Me.txt_origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_origen.Location = New System.Drawing.Point(118, 11)
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.Size = New System.Drawing.Size(178, 20)
        Me.txt_origen.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 23)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Puerto Consolida"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 23)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Puerto Salida"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 23)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Region"
        '
        'txtPuertoConsolida
        '
        Me.txtPuertoConsolida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPuertoConsolida.Location = New System.Drawing.Point(118, 79)
        Me.txtPuertoConsolida.Name = "txtPuertoConsolida"
        Me.txtPuertoConsolida.Size = New System.Drawing.Size(178, 20)
        Me.txtPuertoConsolida.TabIndex = 3
        '
        'txtPuertoSalida
        '
        Me.txtPuertoSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPuertoSalida.Location = New System.Drawing.Point(118, 58)
        Me.txtPuertoSalida.Name = "txtPuertoSalida"
        Me.txtPuertoSalida.Size = New System.Drawing.Size(178, 20)
        Me.txtPuertoSalida.TabIndex = 2
        '
        'txt_region
        '
        Me.txt_region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_region.Location = New System.Drawing.Point(118, 35)
        Me.txt_region.Name = "txt_region"
        Me.txt_region.Size = New System.Drawing.Size(178, 20)
        Me.txt_region.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.dg_contactos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(816, 117)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Contactos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Contactos"
        '
        'dg_contactos
        '
        Me.dg_contactos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_contactos.CaptionVisible = False
        Me.dg_contactos.DataMember = ""
        Me.dg_contactos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_contactos.Location = New System.Drawing.Point(8, 40)
        Me.dg_contactos.Name = "dg_contactos"
        Me.dg_contactos.Size = New System.Drawing.Size(800, 160)
        Me.dg_contactos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Origen"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(752, 4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 56)
        Me.btn_guardar.TabIndex = 6
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'btn_agregar
        '
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agregar.Location = New System.Drawing.Point(272, 47)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(80, 23)
        Me.btn_agregar.TabIndex = 7
        Me.btn_agregar.Text = "Agregar"
        '
        'btn_exportar
        '
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(677, 4)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 56)
        Me.btn_exportar.TabIndex = 6
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        Me.btn_exportar.Visible = False
        '
        'cmb_empresa
        '
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(94, 3)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(121, 22)
        Me.cmb_empresa.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Empresa"
        '
        'dgv_proveedores
        '
        Me.dgv_proveedores.AllowUserToAddRows = False
        Me.dgv_proveedores.AllowUserToDeleteRows = False
        Me.dgv_proveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_proveedores.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_proveedores.Location = New System.Drawing.Point(8, 78)
        Me.dgv_proveedores.Name = "dgv_proveedores"
        Me.dgv_proveedores.RowHeadersWidth = 25
        Me.dgv_proveedores.Size = New System.Drawing.Size(824, 300)
        Me.dgv_proveedores.TabIndex = 9
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frm_scm_mantenimiento_proveedores
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(840, 527)
        Me.Controls.Add(Me.dgv_proveedores)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmb_origen)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.btn_exportar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_scm_mantenimiento_proveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Mantenimiento de Proveedores .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dg_contactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim ds_proveedores As DataSet

    Private Sub Llenar_Empresa()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_empresa.DataSource = dt
            Me.cmb_empresa.DisplayMember = "empresa"
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.SelectedValue = gs_empresa

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")

        Try
            otrans.open()

            ls_sql = "pa_var_um_proveedor_producto '" & Me.cmb_empresa.SelectedValue & "','" & _
                        IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "proveedores"

            If ds_proveedores.Tables.Contains("proveedores") Then
                ds_proveedores.Tables.Remove("proveedores")
            End If

            ds_proveedores.Tables.Add(dt.Copy)
            Me.cmb_proveedor.DataSource = ds_proveedores.Tables("proveedores")
            Me.cmb_proveedor.ValueMember = "subfamilia"
            Me.cmb_proveedor.DisplayMember = "subfamilia"

            ls_sql = "pa_var_um_proveedor_procedencia '" & Me.cmb_empresa.SelectedValue & "','" & _
                        IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "origenes"
            If ds_proveedores.Tables.Contains("origenes") Then
                ds_proveedores.Tables.Remove("origenes")
            End If

            ds_proveedores.Tables.Add(dt.Copy)

            ds_proveedores.Tables("origenes").DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.SelectedValue & "'"
            Me.cmb_origen.DataSource = ds_proveedores.Tables("origenes")
            Me.cmb_origen.DisplayMember = "procedencia"
            Me.cmb_origen.ValueMember = "procedencia"

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Inicializar_Informacion()
        ds_proveedores = New DataSet
    End Sub

    Private Sub Crear_Estructuras()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As New DataTable("proveedores_contactos")

        dt.Columns.Add(New DataColumn("nombre_contacto", GetType(String)))
        dt.Columns.Add(New DataColumn("puesto", GetType(String)))
        dt.Columns.Add(New DataColumn("departamento", GetType(String)))
        dt.Columns.Add(New DataColumn("email", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        ds_proveedores.Tables.Add(dt.Copy)

        Me.dg_contactos.DataSource = ds_proveedores.Tables("proveedores_contactos")


        clsgen.Alinea_Grid(ds_proveedores.Tables("proveedores_contactos"), Me.dg_contactos, ds_proveedores.Tables("proveedores_contactos").TableName, -1, 250, 150, False, True, "", True, "")
        'clsgen.Alinea_Grid(ds_proveedores.Tables("frecuencia_compra"), Me.dg_frecuencia_compra, ds_proveedores.Tables("frecuencia_compra").TableName, -1, 250, 50, False, True, "", True, "")
        'clsgen.Alinea_Grid(ds_proveedores.Tables("dias_inventario_minimo"), Me.dg_inventario_minimo, ds_proveedores.Tables("dias_inventario_minimo").TableName, -1, 250, 50, False, True, "", True, "")

        clsgen = Nothing
    End Sub

    Private Sub Llenar_Proveedores()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General

        Try
            otrans.open()
            ls_sql = "pa_sel_um_prv_proveedor '" & Me.cmb_empresa.SelectedValue.ToString & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "prv_proveedores"

            If ds_proveedores.Tables.IndexOf("prv_proveedores") > -1 Then
                ds_proveedores.Tables.Remove("prv_proveedores")
            End If
            ds_proveedores.Tables.Add(dt.Copy)
            Me.dgv_proveedores.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_proveedores, "", ",empresa,cod_proveedor,", "", ",lead_time_proveedor,lead_time_flete,", "", "", "", True, True, 250, 100)



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        clsgen = Nothing
    End Sub

    Private Sub Asociar_Maestros()
        Dim dr As DataRowView
        Dim dr_aux As DataRow
        Dim irow, icod_proveedor As Integer



        Try
            irow = dgv_proveedores.CurrentCell.RowIndex
            icod_proveedor = dgv_proveedores.Item("cod_proveedor", irow).Value.ToString

            'Contactos
            ds_proveedores.Tables("prv_proveedor_contactos").DefaultView.RowFilter = "cod_proveedor = " & icod_proveedor.ToString
            ds_proveedores.Tables("proveedores_contactos").Rows.Clear()
            For Each dr In ds_proveedores.Tables("prv_proveedor_contactos").DefaultView
                dr_aux = ds_proveedores.Tables("proveedores_contactos").NewRow
                dr_aux.Item("nombre_contacto") = dr.Item("nombre_contacto")
                dr_aux.Item("puesto") = dr.Item("puesto")
                dr_aux.Item("departamento") = dr.Item("departamento")
                dr_aux.Item("email") = dr.Item("email")
                dr_aux.Item("telefono") = dr.Item("telefono")
                ds_proveedores.Tables("proveedores_contactos").Rows.Add(dr_aux)
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Llenar_Proveedores_Adicionales()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("scm")

        Try
            otrans.open()

            ls_sql = "pa_sel_um_prv_proveedor_contacto '" & Me.cmb_empresa.SelectedValue.ToString & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "prv_proveedor_contactos"

            If ds_proveedores.Tables.IndexOf("prv_proveedor_contactos") > -1 Then
                ds_proveedores.Tables.Remove("prv_proveedor_contactos")
            End If
            ds_proveedores.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Agregar_Proveedor()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("scm")
        Try
            otrans.open()
            ls_sql = "pa_ins_um_prv_proveedor '" & Me.cmb_empresa.SelectedValue.ToString & "','" & Me.cmb_proveedor.SelectedValue & "','" & _
                    Me.cmb_origen.SelectedValue & "','" & gs_usuario & "'"
            otrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Llenar_Proveedores()
    End Sub

    Private Function Verificar_Proveedor(ByVal ldt As DataTable) As Boolean
        Dim lb_regreso As Boolean = False
        Dim dr As DataRow
        Dim dt As DataTable
        dt = ldt.Clone

        For Each dr In ds_proveedores.Tables("prv_proveedores").Rows
            If dr.Item("proveedor").ToString.Trim.ToLower = Me.cmb_proveedor.SelectedValue.Trim.ToLower And _
                dr.Item("origen").ToString.Trim.ToLower = Me.cmb_origen.SelectedValue.Trim.ToLower Then
                lb_regreso = True
            End If

        Next
        Return lb_regreso
    End Function

    Private Sub Buscar_proveedor()
        Dim icount As Integer



        Try

            For icount = 0 To dgv_proveedores.RowCount
                If dgv_proveedores.Item("proveedor", icount).Value.ToString.Trim.ToLower = Me.cmb_proveedor.SelectedValue.Trim.ToLower And _
                     dgv_proveedores.Item("origen", icount).Value.ToString.Trim.ToLower = Me.cmb_origen.SelectedValue.Trim.ToLower Then


                    'dgv_proveedores.CurrentCell = New DataGridCell(icount, 0)
                    dgv_proveedores.CurrentCell = dgv_proveedores.Rows(icount).Cells(3)
                    'dgv_proveedores.
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Mostrar_Datos_Proveedor()
        Dim irow, icod_proveedor As Integer

        irow = dgv_proveedores.CurrentCell.RowIndex
        'irow = Me.dg_proveedores.CurrentCell.RowNumber
        icod_proveedor = dgv_proveedores.Item("cod_proveedor", irow).Value.ToString

        txtLeadTimeProv.Text = dgv_proveedores.Item("lead_time_proveedor", irow).Value.ToString
        txt_origen.Text = dgv_proveedores.Item("origen", irow).Value.ToString
        txt_region.Text = dgv_proveedores.Item("region", irow).Value.ToString
        txtLeadTimeFlete.Text = dgv_proveedores.Item("lead_time_flete", irow).Value.ToString
        txtCicloCompra.Text = dgv_proveedores.Item("ciclo_compra", irow).Value.ToString
        txtInvMaximo.Text = dgv_proveedores.Item("inv_maximo", irow).Value.ToString
        txtInventarioSeguridad.Text = dgv_proveedores.Item("inv_seguridad", irow).Value.ToString
        txtReOrden.Text = dgv_proveedores.Item("inv_reorden", irow).Value.ToString
        txtPuertoSalida.Text = dgv_proveedores.Item("puerto_salida", irow).Value.ToString
        Me.txtPuertoConsolida.Text = dgv_proveedores.Item("puerto_consolida", irow).Value.ToString
        txt_semanas_Max_OC.Text = dgv_proveedores.Item("Semanas_Maximo_Cambio_OC", irow).Value.ToString
        Me.txtPago.Text = dgv_proveedores.Item("Semanas_Pago", irow).Value.ToString


    End Sub

    Private Sub Modificar_Proveedor()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("scm")
        Dim irow, icod_proveedor As Integer


        icod_proveedor = 0

        Try
            irow = dgv_proveedores.CurrentCell.RowIndex
            otrans.open()
            ls_sql = "pa_upd_um_prv_proveedor " & dgv_proveedores.Item("cod_proveedor", irow).Value & ",'" & _
                    Me.txt_origen.Text & "'," & Me.txtLeadTimeProv.Text & "," & txtLeadTimeFlete.Text & "," & _
                    txtCicloCompra.Text & "," & txtInvMaximo.Text & "," & txtInventarioSeguridad.Text & ",'" & _
                    Me.txt_region.Text & "','" & txtPuertoConsolida.Text.Trim & "','" & gs_usuario & "'," & _
                    txtReOrden.Text & "," & Me.txt_semanas_Max_OC.Text & "," & Me.txtPago.Text & ",'" & Me.txtPuertoSalida.Text.Trim & "'"

            otrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Proveedores_Contactos()
        Dim ls_sql As String
        Dim irow, icod_proveedor As Integer

        Dim dr As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")




        Try
            otrans.open()
            irow = dgv_proveedores.CurrentCell.RowIndex
            icod_proveedor = dgv_proveedores.Item("cod_proveedor", irow).Value
            ls_sql = "pa_del_um_prv_proveedor_contacto " & icod_proveedor.ToString
            otrans.Elimina(ls_sql)

            For Each dr In ds_proveedores.Tables("proveedores_contactos").DefaultView
                ls_sql = "pa_ins_um_prv_proveedor_contacto  " & icod_proveedor.ToString & ",'" & _
                        dr.Item("nombre_contacto").ToString & "','" & dr.Item("puesto").ToString & "','" & _
                        dr.Item("departamento").ToString & "','" & dr.Item("email").ToString & "','" & _
                        dr.Item("telefono").ToString & "'"

                otrans.Ingresa(ls_sql)
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub aplicarSeguridad()
        Me.btn_guardar.Visible = tiene_permisos("mci_scm_grabar_mantenimiento_proveedores")
    End Sub

    Private Sub frm_csm_mantenimiento_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializar_Informacion()
        Llenar_Empresa()
        Llenar_Combos()
        Crear_Estructuras()
        Llenar_Proveedores()
        Llenar_Proveedores_Adicionales()
        Asociar_Maestros()
        aplicarSeguridad()
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        ds_proveedores.Tables("origenes").DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.SelectedValue & "'"
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Not Verificar_Proveedor(ds_proveedores.Tables("prv_proveedores")) Then
            If MessageBox.Show("Este Proveedor No Esta Asociado, Desea Asociarlo", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Agregar_Proveedor()
                Llenar_Proveedores()
            End If
        End If
        Buscar_proveedor()
    End Sub



    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Modificar_Proveedor()
        Guardar_Proveedores_Contactos()
        Llenar_Proveedores()
        Llenar_Proveedores_Adicionales()
        Asociar_Maestros()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim Oaut As New Automatizar.exportar_excel
        Oaut.ocultar_columnas = ",cod_pro,"
        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

        Oaut.Nombre_Columnas = "," ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"


        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ds_proveedores.Tables("prv_proveedores"))
        Oaut = Nothing
    End Sub

    Private Sub cmb_origen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_origen.GotFocus
        ds_proveedores.Tables("origenes").DefaultView.RowFilter = "subfamilia = '" & Me.cmb_proveedor.SelectedValue & "'"
    End Sub

    Private Sub cmb_empresa_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectionChangeCommitted
        Llenar_Combos()
        Llenar_Proveedores()
        Llenar_Proveedores_Adicionales()
        Asociar_Maestros()
    End Sub


    Private Sub dgv_provyeedores_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_proveedores.CurrentCellChanged
        Try
            Mostrar_Datos_Proveedor()
            Asociar_Maestros()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_proveedores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_proveedores.CellContentClick

    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then


                'Tell the user which menu item they just clicked.




                '             ods.Tables("productos").DefaultView.RowFilter = filtro_actual
                If menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dgv_proveedores.Columns(Me.dgv_proveedores.CurrentCell.ColumnIndex).Frozen = True
                    'nfrozen = Me.dgv_proveedores.CurrentCell.ColumnIndex
                Else

                    For iaux As Integer = 0 To Me.dgv_proveedores.ColumnCount
                        Me.dgv_proveedores.Columns(iaux).Frozen = False
                    Next
                End If
            End If

        Catch ex As Exception


        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dgv_proveedores.Columns(Me.dgv_proveedores.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)
            'If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.ToLower.StartsWith("glosa") Then
            'End If
        Catch ex As Exception

        End Try

    End Sub


   
End Class
