Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.MailMessage
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Core
Imports System.Reflection
Imports Microsoft.Win32
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frm_mercaderista_cliente

    Inherits System.Windows.Forms.Form
    Private ps_nombre_vista As String = ""
    Private ps_procedimiento_almacenado As String
    Public ps_parametros_fijos As String
    Public lista_parametros As String
    Public lista_campos As String
    Public seleccion_multiple As Boolean = False
    Private po_parametros As Array
    Public conectar As String = String.Empty
    Public ruta As String
    Public resultado As String
    Public dt As DataTable
    Dim odataset As DataSet
    Dim ds_clientes As DataSet
    Dim ds_merca As DataSet
    Dim ods As DataSet
    Dim ban As Integer
    Dim drv As DataRowView

    Public asociar, nombre_corto, ruta_logistica, cta_cte, razon_social, retorna, retorna2, clasificacion, segmento, motivoconsumo As String
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nom_mer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents email_mer As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_valor3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_buscar3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar1 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_mercaderistas As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_listadoclientes1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Txt_mail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_contra As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents inactivo As System.Windows.Forms.RadioButton
    Friend WithEvents activo As System.Windows.Forms.RadioButton
    Friend WithEvents Bitacora_correos As System.Windows.Forms.DataGridView
    Friend WithEvents Bitacora As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Email_resp As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents dgvListadoClientesAsignados As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dgvListadoMercaderistas As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardarClienteProveedor As System.Windows.Forms.Button
    Friend WithEvents btnNuevoClienteProveedor As System.Windows.Forms.Button
    Friend WithEvents btnLlenarClienteProveedor As System.Windows.Forms.Button
    Friend WithEvents btnBuscarClienteProveedor As System.Windows.Forms.Button
    Friend WithEvents txtMercaderistaClienteProveedor As System.Windows.Forms.TextBox
    Friend WithEvents cmbClienteClienteProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresaClienteProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvProveedoresAsignados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvProveedoresDisponibles As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesarMoverCliente As System.Windows.Forms.Button
    Friend WithEvents btnBuscarDestino As System.Windows.Forms.Button
    Friend WithEvents btnBuscarOrigen As System.Windows.Forms.Button
    Friend WithEvents btnNuevoMoverCliente As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMercaderistaDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtMercaderistaOrigen As System.Windows.Forms.TextBox
    Public toco As Boolean = False



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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvListadoMercaderistas = New System.Windows.Forms.DataGridView()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.inactivo = New System.Windows.Forms.RadioButton()
        Me.activo = New System.Windows.Forms.RadioButton()
        Me.Email_resp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_mer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.email_mer = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_mercaderistas = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb_valor3 = New System.Windows.Forms.ComboBox()
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox()
        Me.cmb_3 = New System.Windows.Forms.ComboBox()
        Me.cmb_1 = New System.Windows.Forms.ComboBox()
        Me.txt_buscar3 = New System.Windows.Forms.TextBox()
        Me.txt_buscar1 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvListadoClientesAsignados = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgv_listadoclientes1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnGuardarClienteProveedor = New System.Windows.Forms.Button()
        Me.btnNuevoClienteProveedor = New System.Windows.Forms.Button()
        Me.btnLlenarClienteProveedor = New System.Windows.Forms.Button()
        Me.btnBuscarClienteProveedor = New System.Windows.Forms.Button()
        Me.txtMercaderistaClienteProveedor = New System.Windows.Forms.TextBox()
        Me.cmbClienteClienteProveedor = New System.Windows.Forms.ComboBox()
        Me.cmbEmpresaClienteProveedor = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvProveedoresAsignados = New System.Windows.Forms.DataGridView()
        Me.dgvProveedoresDisponibles = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btnProcesarMoverCliente = New System.Windows.Forms.Button()
        Me.btnBuscarDestino = New System.Windows.Forms.Button()
        Me.btnBuscarOrigen = New System.Windows.Forms.Button()
        Me.btnNuevoMoverCliente = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMercaderistaDestino = New System.Windows.Forms.TextBox()
        Me.txtMercaderistaOrigen = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Bitacora_correos = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_contra = New System.Windows.Forms.TextBox()
        Me.Txt_mail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Bitacora = New System.Windows.Forms.GroupBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvListadoMercaderistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvListadoClientesAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_listadoclientes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvProveedoresAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProveedoresDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Bitacora_correos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(962, 505)
        Me.TabControl1.TabIndex = 41
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.dgvListadoMercaderistas)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_Cancelar)
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(954, 477)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mercaderistas"
        '
        'dgvListadoMercaderistas
        '
        Me.dgvListadoMercaderistas.AllowUserToAddRows = False
        Me.dgvListadoMercaderistas.AllowUserToDeleteRows = False
        Me.dgvListadoMercaderistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoMercaderistas.Location = New System.Drawing.Point(6, 212)
        Me.dgvListadoMercaderistas.Name = "dgvListadoMercaderistas"
        Me.dgvListadoMercaderistas.RowHeadersWidth = 20
        Me.dgvListadoMercaderistas.Size = New System.Drawing.Size(942, 259)
        Me.dgvListadoMercaderistas.TabIndex = 16
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.ForeColor = System.Drawing.Color.White
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.ImageIndex = 0
        Me.btn_modificar.Location = New System.Drawing.Point(585, 29)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(75, 61)
        Me.btn_modificar.TabIndex = 15
        Me.btn_modificar.Text = "Modificar"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cancelar.ImageIndex = 0
        Me.btn_Cancelar.Location = New System.Drawing.Point(585, 108)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 61)
        Me.btn_Cancelar.TabIndex = 14
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        Me.btn_Cancelar.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.Location = New System.Drawing.Point(504, 108)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 61)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        Me.btn_guardar.Visible = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.Location = New System.Drawing.Point(504, 29)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 61)
        Me.btn_nuevo.TabIndex = 6
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.Email_resp)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Nom_mer)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.email_mer)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 29)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(481, 177)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mercaderista"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "E-mail  Respuesta : "
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.inactivo)
        Me.GroupBox7.Controls.Add(Me.activo)
        Me.GroupBox7.Location = New System.Drawing.Point(134, 119)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(169, 42)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        '
        'inactivo
        '
        Me.inactivo.AutoSize = True
        Me.inactivo.Location = New System.Drawing.Point(90, 15)
        Me.inactivo.Name = "inactivo"
        Me.inactivo.Size = New System.Drawing.Size(66, 19)
        Me.inactivo.TabIndex = 1
        Me.inactivo.TabStop = True
        Me.inactivo.Text = "Inactivo"
        Me.inactivo.UseVisualStyleBackColor = True
        '
        'activo
        '
        Me.activo.AutoSize = True
        Me.activo.Location = New System.Drawing.Point(11, 15)
        Me.activo.Name = "activo"
        Me.activo.Size = New System.Drawing.Size(56, 19)
        Me.activo.TabIndex = 0
        Me.activo.TabStop = True
        Me.activo.Text = "Activo"
        Me.activo.UseVisualStyleBackColor = True
        '
        'Email_resp
        '
        Me.Email_resp.Location = New System.Drawing.Point(134, 82)
        Me.Email_resp.Name = "Email_resp"
        Me.Email_resp.Size = New System.Drawing.Size(245, 21)
        Me.Email_resp.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre : "
        '
        'Nom_mer
        '
        Me.Nom_mer.Enabled = False
        Me.Nom_mer.Location = New System.Drawing.Point(134, 30)
        Me.Nom_mer.Name = "Nom_mer"
        Me.Nom_mer.Size = New System.Drawing.Size(245, 21)
        Me.Nom_mer.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "E-mail : "
        '
        'email_mer
        '
        Me.email_mer.Location = New System.Drawing.Point(135, 57)
        Me.email_mer.Name = "email_mer"
        Me.email_mer.Size = New System.Drawing.Size(245, 21)
        Me.email_mer.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.cmb_mercaderistas)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(954, 477)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Clientes"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 1
        Me.Button1.Location = New System.Drawing.Point(867, 196)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 61)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Agregar Cliente"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 15)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Mercaderistas : "
        '
        'cmb_mercaderistas
        '
        Me.cmb_mercaderistas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_mercaderistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mercaderistas.DropDownWidth = 150
        Me.cmb_mercaderistas.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_mercaderistas.Location = New System.Drawing.Point(307, 6)
        Me.cmb_mercaderistas.Name = "cmb_mercaderistas"
        Me.cmb_mercaderistas.Size = New System.Drawing.Size(197, 23)
        Me.cmb_mercaderistas.TabIndex = 52
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmb_valor3)
        Me.GroupBox1.Controls.Add(Me.cmb_valor1)
        Me.GroupBox1.Controls.Add(Me.cmb_3)
        Me.GroupBox1.Controls.Add(Me.cmb_1)
        Me.GroupBox1.Controls.Add(Me.txt_buscar3)
        Me.GroupBox1.Controls.Add(Me.txt_buscar1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(23, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 45)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Cliente"
        '
        'cmb_valor3
        '
        Me.cmb_valor3.Location = New System.Drawing.Point(192, 114)
        Me.cmb_valor3.Name = "cmb_valor3"
        Me.cmb_valor3.Size = New System.Drawing.Size(102, 23)
        Me.cmb_valor3.TabIndex = 16
        Me.cmb_valor3.Visible = False
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Items.AddRange(New Object() {"ctacte"})
        Me.cmb_valor1.Location = New System.Drawing.Point(27, 14)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(93, 23)
        Me.cmb_valor1.TabIndex = 10
        '
        'cmb_3
        '
        Me.cmb_3.Location = New System.Drawing.Point(136, 119)
        Me.cmb_3.Name = "cmb_3"
        Me.cmb_3.Size = New System.Drawing.Size(40, 23)
        Me.cmb_3.TabIndex = 17
        Me.cmb_3.Visible = False
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Items.AddRange(New Object() {"like"})
        Me.cmb_1.Location = New System.Drawing.Point(131, 14)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(44, 23)
        Me.cmb_1.TabIndex = 11
        '
        'txt_buscar3
        '
        Me.txt_buscar3.Location = New System.Drawing.Point(176, 114)
        Me.txt_buscar3.Name = "txt_buscar3"
        Me.txt_buscar3.Size = New System.Drawing.Size(286, 21)
        Me.txt_buscar3.TabIndex = 19
        Me.txt_buscar3.Visible = False
        '
        'txt_buscar1
        '
        Me.txt_buscar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_buscar1.Location = New System.Drawing.Point(187, 15)
        Me.txt_buscar1.Name = "txt_buscar1"
        Me.txt_buscar1.Size = New System.Drawing.Size(552, 21)
        Me.txt_buscar1.TabIndex = 12
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.ImageIndex = 1
        Me.Button5.Location = New System.Drawing.Point(865, 356)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(78, 61)
        Me.Button5.TabIndex = 46
        Me.Button5.Text = "Borrar Cliente Asignado"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvListadoClientesAsignados)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(856, 197)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Clientes Asignados a Mercaderista"
        '
        'dgvListadoClientesAsignados
        '
        Me.dgvListadoClientesAsignados.AllowUserToAddRows = False
        Me.dgvListadoClientesAsignados.AllowUserToDeleteRows = False
        Me.dgvListadoClientesAsignados.AllowUserToOrderColumns = True
        Me.dgvListadoClientesAsignados.AllowUserToResizeColumns = False
        Me.dgvListadoClientesAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoClientesAsignados.Location = New System.Drawing.Point(6, 17)
        Me.dgvListadoClientesAsignados.Name = "dgvListadoClientesAsignados"
        Me.dgvListadoClientesAsignados.RowHeadersWidth = 20
        Me.dgvListadoClientesAsignados.Size = New System.Drawing.Size(844, 174)
        Me.dgvListadoClientesAsignados.TabIndex = 56
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(8, -160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(655, 153)
        Me.GroupBox4.TabIndex = 55
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Clientes Asignados a Mercaderistas"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgv_listadoclientes1)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.DataGrid1)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 75)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(853, 192)
        Me.GroupBox5.TabIndex = 56
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Clientes General"
        '
        'dgv_listadoclientes1
        '
        Me.dgv_listadoclientes1.AllowUserToAddRows = False
        Me.dgv_listadoclientes1.AllowUserToDeleteRows = False
        Me.dgv_listadoclientes1.AllowUserToOrderColumns = True
        Me.dgv_listadoclientes1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listadoclientes1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listadoclientes1.Location = New System.Drawing.Point(6, 20)
        Me.dgv_listadoclientes1.Name = "dgv_listadoclientes1"
        Me.dgv_listadoclientes1.RowHeadersWidth = 25
        Me.dgv_listadoclientes1.Size = New System.Drawing.Size(841, 162)
        Me.dgv_listadoclientes1.TabIndex = 57
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(8, -160)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(655, 153)
        Me.GroupBox6.TabIndex = 55
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Clientes Asignados a Mercaderistas"
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(27, 51)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(807, 113)
        Me.DataGrid1.TabIndex = 57
        Me.DataGrid1.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.btnGuardarClienteProveedor)
        Me.TabPage4.Controls.Add(Me.btnNuevoClienteProveedor)
        Me.TabPage4.Controls.Add(Me.btnLlenarClienteProveedor)
        Me.TabPage4.Controls.Add(Me.btnBuscarClienteProveedor)
        Me.TabPage4.Controls.Add(Me.txtMercaderistaClienteProveedor)
        Me.TabPage4.Controls.Add(Me.cmbClienteClienteProveedor)
        Me.TabPage4.Controls.Add(Me.cmbEmpresaClienteProveedor)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.dgvProveedoresAsignados)
        Me.TabPage4.Controls.Add(Me.dgvProveedoresDisponibles)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(954, 479)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cliente-Proveedor"
        '
        'btnGuardarClienteProveedor
        '
        Me.btnGuardarClienteProveedor.Location = New System.Drawing.Point(823, 224)
        Me.btnGuardarClienteProveedor.Name = "btnGuardarClienteProveedor"
        Me.btnGuardarClienteProveedor.Size = New System.Drawing.Size(75, 73)
        Me.btnGuardarClienteProveedor.TabIndex = 5
        Me.btnGuardarClienteProveedor.Text = "Guardar"
        Me.btnGuardarClienteProveedor.UseVisualStyleBackColor = True
        '
        'btnNuevoClienteProveedor
        '
        Me.btnNuevoClienteProveedor.Location = New System.Drawing.Point(823, 106)
        Me.btnNuevoClienteProveedor.Name = "btnNuevoClienteProveedor"
        Me.btnNuevoClienteProveedor.Size = New System.Drawing.Size(75, 70)
        Me.btnNuevoClienteProveedor.TabIndex = 5
        Me.btnNuevoClienteProveedor.Text = "Nuevo"
        Me.btnNuevoClienteProveedor.UseVisualStyleBackColor = True
        '
        'btnLlenarClienteProveedor
        '
        Me.btnLlenarClienteProveedor.Location = New System.Drawing.Point(453, 57)
        Me.btnLlenarClienteProveedor.Name = "btnLlenarClienteProveedor"
        Me.btnLlenarClienteProveedor.Size = New System.Drawing.Size(55, 23)
        Me.btnLlenarClienteProveedor.TabIndex = 5
        Me.btnLlenarClienteProveedor.Text = "Llenar"
        Me.btnLlenarClienteProveedor.UseVisualStyleBackColor = True
        '
        'btnBuscarClienteProveedor
        '
        Me.btnBuscarClienteProveedor.Location = New System.Drawing.Point(453, 32)
        Me.btnBuscarClienteProveedor.Name = "btnBuscarClienteProveedor"
        Me.btnBuscarClienteProveedor.Size = New System.Drawing.Size(55, 23)
        Me.btnBuscarClienteProveedor.TabIndex = 5
        Me.btnBuscarClienteProveedor.Text = "Buscar"
        Me.btnBuscarClienteProveedor.UseVisualStyleBackColor = True
        '
        'txtMercaderistaClienteProveedor
        '
        Me.txtMercaderistaClienteProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMercaderistaClienteProveedor.Location = New System.Drawing.Point(154, 34)
        Me.txtMercaderistaClienteProveedor.Name = "txtMercaderistaClienteProveedor"
        Me.txtMercaderistaClienteProveedor.ReadOnly = True
        Me.txtMercaderistaClienteProveedor.Size = New System.Drawing.Size(293, 21)
        Me.txtMercaderistaClienteProveedor.TabIndex = 4
        '
        'cmbClienteClienteProveedor
        '
        Me.cmbClienteClienteProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClienteClienteProveedor.FormattingEnabled = True
        Me.cmbClienteClienteProveedor.Location = New System.Drawing.Point(154, 58)
        Me.cmbClienteClienteProveedor.Name = "cmbClienteClienteProveedor"
        Me.cmbClienteClienteProveedor.Size = New System.Drawing.Size(293, 23)
        Me.cmbClienteClienteProveedor.TabIndex = 3
        '
        'cmbEmpresaClienteProveedor
        '
        Me.cmbEmpresaClienteProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresaClienteProveedor.FormattingEnabled = True
        Me.cmbEmpresaClienteProveedor.Location = New System.Drawing.Point(154, 9)
        Me.cmbEmpresaClienteProveedor.Name = "cmbEmpresaClienteProveedor"
        Me.cmbEmpresaClienteProveedor.Size = New System.Drawing.Size(121, 23)
        Me.cmbEmpresaClienteProveedor.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(58, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Cliente"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(58, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Mercaderista"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(58, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Empresa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(422, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 15)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Proveedores Asignados"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 15)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Proveedores Disponibles"
        '
        'dgvProveedoresAsignados
        '
        Me.dgvProveedoresAsignados.AllowUserToAddRows = False
        Me.dgvProveedoresAsignados.AllowUserToDeleteRows = False
        Me.dgvProveedoresAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedoresAsignados.Location = New System.Drawing.Point(425, 118)
        Me.dgvProveedoresAsignados.Name = "dgvProveedoresAsignados"
        Me.dgvProveedoresAsignados.RowHeadersWidth = 20
        Me.dgvProveedoresAsignados.Size = New System.Drawing.Size(332, 353)
        Me.dgvProveedoresAsignados.TabIndex = 0
        '
        'dgvProveedoresDisponibles
        '
        Me.dgvProveedoresDisponibles.AllowUserToAddRows = False
        Me.dgvProveedoresDisponibles.AllowUserToDeleteRows = False
        Me.dgvProveedoresDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedoresDisponibles.Location = New System.Drawing.Point(9, 118)
        Me.dgvProveedoresDisponibles.Name = "dgvProveedoresDisponibles"
        Me.dgvProveedoresDisponibles.RowHeadersWidth = 20
        Me.dgvProveedoresDisponibles.Size = New System.Drawing.Size(370, 353)
        Me.dgvProveedoresDisponibles.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.btnProcesarMoverCliente)
        Me.TabPage5.Controls.Add(Me.btnBuscarDestino)
        Me.TabPage5.Controls.Add(Me.btnBuscarOrigen)
        Me.TabPage5.Controls.Add(Me.btnNuevoMoverCliente)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Controls.Add(Me.txtMercaderistaDestino)
        Me.TabPage5.Controls.Add(Me.txtMercaderistaOrigen)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(954, 479)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Mover Cliente"
        '
        'btnProcesarMoverCliente
        '
        Me.btnProcesarMoverCliente.Location = New System.Drawing.Point(744, 105)
        Me.btnProcesarMoverCliente.Name = "btnProcesarMoverCliente"
        Me.btnProcesarMoverCliente.Size = New System.Drawing.Size(75, 49)
        Me.btnProcesarMoverCliente.TabIndex = 2
        Me.btnProcesarMoverCliente.Text = "Procesar"
        Me.btnProcesarMoverCliente.UseVisualStyleBackColor = True
        '
        'btnBuscarDestino
        '
        Me.btnBuscarDestino.Location = New System.Drawing.Point(430, 193)
        Me.btnBuscarDestino.Name = "btnBuscarDestino"
        Me.btnBuscarDestino.Size = New System.Drawing.Size(39, 21)
        Me.btnBuscarDestino.TabIndex = 2
        Me.btnBuscarDestino.Text = "Buscar"
        Me.btnBuscarDestino.UseVisualStyleBackColor = True
        '
        'btnBuscarOrigen
        '
        Me.btnBuscarOrigen.Location = New System.Drawing.Point(430, 119)
        Me.btnBuscarOrigen.Name = "btnBuscarOrigen"
        Me.btnBuscarOrigen.Size = New System.Drawing.Size(39, 21)
        Me.btnBuscarOrigen.TabIndex = 2
        Me.btnBuscarOrigen.Text = "Buscar"
        Me.btnBuscarOrigen.UseVisualStyleBackColor = True
        '
        'btnNuevoMoverCliente
        '
        Me.btnNuevoMoverCliente.Location = New System.Drawing.Point(652, 105)
        Me.btnNuevoMoverCliente.Name = "btnNuevoMoverCliente"
        Me.btnNuevoMoverCliente.Size = New System.Drawing.Size(75, 49)
        Me.btnNuevoMoverCliente.TabIndex = 2
        Me.btnNuevoMoverCliente.Text = "Nuevo"
        Me.btnNuevoMoverCliente.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(122, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Mercaderista Destino"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(158, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(487, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "*** IMPORTANTE **** Este Proceso Trasladara Toda la Informacion de Origen a Desti" & _
    "no"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(122, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Mercaderista Origen"
        '
        'txtMercaderistaDestino
        '
        Me.txtMercaderistaDestino.Location = New System.Drawing.Point(125, 193)
        Me.txtMercaderistaDestino.Name = "txtMercaderistaDestino"
        Me.txtMercaderistaDestino.ReadOnly = True
        Me.txtMercaderistaDestino.Size = New System.Drawing.Size(299, 21)
        Me.txtMercaderistaDestino.TabIndex = 0
        '
        'txtMercaderistaOrigen
        '
        Me.txtMercaderistaOrigen.Location = New System.Drawing.Point(125, 119)
        Me.txtMercaderistaOrigen.Name = "txtMercaderistaOrigen"
        Me.txtMercaderistaOrigen.ReadOnly = True
        Me.txtMercaderistaOrigen.Size = New System.Drawing.Size(299, 21)
        Me.txtMercaderistaOrigen.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Bitacora_correos)
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Txt_contra)
        Me.TabPage3.Controls.Add(Me.Txt_mail)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Bitacora)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(954, 479)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Procesos"
        '
        'Bitacora_correos
        '
        Me.Bitacora_correos.AllowUserToAddRows = False
        Me.Bitacora_correos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Bitacora_correos.Location = New System.Drawing.Point(14, 41)
        Me.Bitacora_correos.Name = "Bitacora_correos"
        Me.Bitacora_correos.ReadOnly = True
        Me.Bitacora_correos.Size = New System.Drawing.Size(923, 235)
        Me.Bitacora_correos.TabIndex = 60
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.ImageIndex = 1
        Me.Button4.Location = New System.Drawing.Point(587, 365)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 54)
        Me.Button4.TabIndex = 58
        Me.Button4.Text = "Procesar Correos..."
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(457, 316)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Contraseña  : "
        Me.Label9.Visible = False
        '
        'Txt_contra
        '
        Me.Txt_contra.Location = New System.Drawing.Point(543, 310)
        Me.Txt_contra.Name = "Txt_contra"
        Me.Txt_contra.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_contra.Size = New System.Drawing.Size(135, 21)
        Me.Txt_contra.TabIndex = 10
        Me.Txt_contra.Visible = False
        '
        'Txt_mail
        '
        Me.Txt_mail.Location = New System.Drawing.Point(238, 310)
        Me.Txt_mail.Name = "Txt_mail"
        Me.Txt_mail.Size = New System.Drawing.Size(215, 21)
        Me.Txt_mail.TabIndex = 9
        Me.Txt_mail.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(145, 316)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Email Emisor : "
        Me.Label8.Visible = False
        '
        'Bitacora
        '
        Me.Bitacora.Location = New System.Drawing.Point(6, 19)
        Me.Bitacora.Name = "Bitacora"
        Me.Bitacora.Size = New System.Drawing.Size(937, 269)
        Me.Bitacora.TabIndex = 61
        Me.Bitacora.TabStop = False
        Me.Bitacora.Text = "Bitacora Correo Enviados"
        '
        'frm_mercaderista_cliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(958, 529)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_mercaderista_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mercaderista - Clientes"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvListadoMercaderistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvListadoClientesAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgv_listadoclientes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvProveedoresAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProveedoresDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.Bitacora_correos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub actualizar_datos_rutaLogistica()

        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()
            ls_sql = "pa_upd_um_ctacteRutaLogistica '" & gs_empresa & "','" & cta_cte & " ','" & razon_social & "','" & retorna2 & "'"
            oTrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try




    End Sub


    Private Sub busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim clGenerales As New ClasesGenerales.General
        Me.Button1.Enabled = False
        Me.Button5.Enabled = False

        'inicializa valores del combo mercaderistas
        Inicializar()

        'llena el datagrid del primera tab
        llenado_mercaderista1()
        llenado_bitacora()

        ' llena combo de mercaderistas
        Llenar_Combos()
        ' crea estructura de datagridview de Clientes asignados
        crear_estructura()
        ' llena datagridview de Clientes asignados
        llenado_checkbox()
        llenarcombos_operadores()
        botones(False)

    End Sub


    Private Sub mostrarMercaderista()
        Dim sta_mer As String
        'If dt.Rows.Count > 0 Then
        If dgvListadoMercaderistas.CurrentRow.IsNewRow = False Then
            Me.Nom_mer.Text = Me.dgvListadoMercaderistas.Item(2, dgvListadoMercaderistas.CurrentRow.Index).Value
            Me.email_mer.Text = Me.dgvListadoMercaderistas.Item(5, dgvListadoMercaderistas.CurrentRow.Index).Value
            Me.Email_resp.Text = Me.dgvListadoMercaderistas.Item(7, dgvListadoMercaderistas.CurrentRow.Index).Value
            sta_mer = Me.dgvListadoMercaderistas.Item(6, dgvListadoMercaderistas.CurrentRow.Index).Value
            If sta_mer = "ACTIVO" Then
                activo.Checked = True
                inactivo.Checked = False
            Else
                activo.Checked = False
                inactivo.Checked = True
            End If
        End If
    End Sub

    Private Sub txt_buscar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub Llenar_Combos()

        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim oTrans As Transaccional.Conexion

        Try
            Me.cmb_mercaderistas.DataSource = Nothing
            Otrans.open()

            Me.cmb_mercaderistas.DataSource = ds_merca.Tables("gen_mercaderistas")
            Me.cmb_mercaderistas.DisplayMember = "DESCRIPCION"
            Me.cmb_mercaderistas.ValueMember = "CODIGO"


            dt = Otrans.Obtiene("pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'")
            Me.cmbEmpresaClienteProveedor.DataSource = dt
            Me.cmbEmpresaClienteProveedor.DisplayMember = "EMPRESA"
            Me.cmbEmpresaClienteProveedor.ValueMember = "EMPRESA"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Inicializar()
        Dim ls_sql As String
        ds_merca = New DataSet
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        odataset = New DataSet

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_MERCADERISTA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "gen_mercaderistas"
            ds_merca.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_sg_usuario_email '" & gs_usuario & "'"
            dt = Otrans.Obtiene(ls_sql)
            'dt.TableName = "correo_envio"
            'ds_merca.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                Me.Txt_mail.Text = dt.Rows(0).Item("correo").ToString
                Me.Txt_contra.Text = dt.Rows(0).Item("correo").ToString
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Public WriteOnly Property procedimiento_almacenado() As String

        Set(ByVal Value As String)
            ps_procedimiento_almacenado = Value
        End Set
    End Property



    Public WriteOnly Property nombre_vista() As String

        Set(ByVal Value As String)
            ps_nombre_vista = Value
        End Set
    End Property

    Public WriteOnly Property parametros() As String
        Set(ByVal Value As String)
            Dim lo_listaopciones As Array
            Dim lo_opcion As Object
            lo_listaopciones = Value.Split(",")
            For Each lo_opcion In lo_listaopciones
                Me.cmb_valor1.Items.Add(lo_opcion)
                Me.cmb_valor3.Items.Add(lo_opcion)
            Next
            Me.cmb_valor1.Text = Me.cmb_valor1.Items(0)
            po_parametros = lo_listaopciones
        End Set
    End Property

    Public WriteOnly Property parametros_fijos() As String
        Set(ByVal Value As String)
            ps_parametros_fijos = Value
        End Set
    End Property

    Private Sub llenarcombos_operadores()
        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")
        Me.cmb_1.Text = Me.cmb_1.Items(4)


    End Sub

    'Private Sub hacer_busqueda_sp()
    '    Dim i As Integer
    '    Dim ls_parametros As String
    '    Dim oTransaccion As Transaccional.Conexion
    '    Dim ls_Script As String
    '    Dim otabla As DataTable
    '    Dim clGeneral As New ClasesGenerales.General

    '    ls_parametros = ""
    '    If Me.txt_buscar1.Text.Length = 0 Then
    '        For i = 0 To Me.cmb_valor1.Items.Count - 1
    '            ls_parametros = ls_parametros & IIf(i = 0, "", ",")
    '            ls_parametros = ls_parametros & "null"
    '        Next
    '    Else
    '        i = Me.cmb_valor1.Items.Count
    '        For i = 0 To Me.cmb_valor1.Items.Count - 1
    '            ls_parametros = ls_parametros & IIf(i = 0, "", ",")

    '            If Me.cmb_valor1.Items(i) = Me.cmb_valor1.Text Then
    '                ls_parametros = ls_parametros & Me.txt_buscar1.Text.Trim
    '            Else
    '                ls_parametros = ls_parametros & "null"
    '            End If
    '        Next
    '    End If

    '    oTransaccion = New Transaccional.Conexion("flexline")
    '    oTransaccion.open()
    '    ls_Script = ps_procedimiento_almacenado & " " & ps_parametros_fijos & ls_parametros

    '    Try
    '        otabla = oTransaccion.Obtiene(ls_Script)
    '        otabla.TableName = "tabla1"
    '        Me.dg_buscar.DataSource = otabla

    '        Dim estilo As New DataGridTableStyle
    '        estilo.MappingName = "tabla1"

    '        Dim nombrecolumna As String
    '        For i = 0 To otabla.Columns.Count() - 1
    '            nombrecolumna = otabla.Columns(i).ColumnName
    '            Dim column As New DataGridTextBoxColumn
    '            With column
    '                .Width = clGeneral.tamaño_maximo_campo(otabla, " ", nombrecolumna, dg_buscar, 150, 50)
    '                .MappingName = nombrecolumna.Trim
    '                .HeaderText = nombrecolumna.Trim
    '            End With
    '            estilo.GridColumnStyles.Add(column)
    '        Next
    '        Me.dg_buscar.TableStyles.Clear()
    '        Me.dg_buscar.TableStyles.Add(estilo)
    '    Finally

    '    End Try
    '    oTransaccion.close()
    '    oTransaccion = Nothing
    '    clGeneral = Nothing
    'End Sub






    Public Sub hacer_busqueda_vista(Optional ByVal conexion As String = "flexline")
        Dim ls_parametros As String
        Dim ls_Script As String
        Dim clGeneral As New ClasesGenerales.General
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oTabla As DataTable

        ls_parametros = ""

        If Me.txt_buscar1.Text.Length > 0 Then
            ls_parametros = ls_parametros & " " & Me.cmb_valor1.Text & " " & _
                            Me.cmb_1.Text & " '" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "'"


            lista_campos = "Empresa, CtaCte, RazonSocial,Giro,Ejecutivo,Direccion"
            ls_Script = "Select " & Me.lista_campos & " From ctacte Where tipoctacte = 'CLIENTE' and vigencia = 'S' and empresa in ('DMARTE1','CODICASA','DIUVA') and " & ps_parametros_fijos & " (" & ls_parametros & ")"


            Otrans = New Transaccional.Conexion(conexion)
            Otrans.open()

            Try
                'dt = oTransaccion.Obtiene(ls_Script)

                oTabla = Otrans.Obtiene(ls_Script) '

                ods = New DataSet
                dt = New DataTable("tabla")
                dt.Columns.Add(New DataColumn("Asignar", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
                dt.Columns.Add(New DataColumn("CtaCte", GetType(String)))
                dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
                dt.Columns.Add(New DataColumn("Giro", GetType(String)))
                dt.Columns.Add(New DataColumn("Ejecutivo", GetType(String)))
                dt.Columns.Add(New DataColumn("Direccion", GetType(String)))

                ods.Tables.Add(dt.Copy)
                dt.TableName = "tabla"
                Me.dgv_listadoclientes1.DataSource = ods.Tables("tabla")



                For Each dr In oTabla.Rows

                    dr_aux = ods.Tables("tabla").NewRow

                    dr_aux.Item("Asignar") = 0
                    dr_aux.Item("CtaCte") = dr.Item("CtaCte")
                    dr_aux.Item("Empresa") = dr.Item("Empresa")
                    dr_aux.Item("RazonSocial") = dr.Item("RazonSocial")
                    dr_aux.Item("Giro") = dr.Item("Giro")
                    dr_aux.Item("Ejecutivo") = dr.Item("Ejecutivo")
                    dr_aux.Item("Direccion") = dr.Item("Direccion")

                    ods.Tables("tabla").Rows.Add(dr_aux)
                Next


                If ods.Tables("tabla").Rows.Count > 0 Then
                    Me.Button1.Enabled = True
                Else
                    Me.Button1.Enabled = False
                End If

                clGeneral.Alinear_GridView(ods.Tables("tabla"), dgv_listadoclientes1, "", "", "", "", "", "", "", True, True, 200, 0)

            Catch ex As Exception
            Finally
            End Try
            Otrans.close()
            Otrans = Nothing
            clGeneral = Nothing
        End If
    End Sub



    Private Sub btn_seleccion_multipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dr As DataRow

        For Each dr In dt.Rows
            dr.Item("agregar") = True
        Next

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub txt_buscar1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_buscar1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_busqueda_vista()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim ver_sel As Integer
        Dim drv1 As DataRowView
        'verifica si hay clientes seleccionados en el datagridview
        ver_sel = 0
        For Each drv1 In ods.Tables("mercaderistas").DefaultView
            If drv1.Item("Quitar") = True Then
                ver_sel = 1
            End If
        Next


        If ver_sel = 1 Then
            Proceso_actualizar_DesAsignar()
            crear_estructura_clientes()
            crear_estructura()
            llenado_checkbox()
        Else
            MessageBox.Show("No hay clientes Seleccionados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            crear_estructura_clientes()
            crear_estructura()
            llenado_checkbox()
        End If
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click

        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        ls_sql = "pa_sel_um_gen_tabcod '" & Me.Nom_mer.Text & "','" & "GEN_MERCADERISTA" & "','" & gs_empresa & "'"
        Otrans.open()
        dt = Otrans.Obtiene(ls_sql)

        If dt.Rows.Count > 0 Then

            If Nom_mer.Text.Length = 0 Then
                MsgBox("Falta Nombre del Mercaderista ", MsgBoxStyle.Critical, "Nombre del Mercaderista")
                Nom_mer.Focus()

            ElseIf email_mer.Text.Length = 0 Then
                MsgBox("Falta Ingresar E-mail", MsgBoxStyle.Critical, "Falta Dirección")
                email_mer.Focus()

            Else
                If MessageBox.Show("Esta seguro de Modificar el Mercaderista ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Proceso_modificar()
                    llenado_mercaderista1() 'refresca la grid

                End If

            End If
        Else
            If email_mer.Text.Length = 0 Then
                MsgBox("Falta Ingresar E-mail", MsgBoxStyle.Critical, "Falta Dirección")
                email_mer.Focus()

            Else

                If MessageBox.Show("Esta seguro de Guardar el Mercaderista ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Proceso_Guardar()
                    llenado_mercaderista1()
                    botones(False)

                    Inicializar()
                    Llenar_Combos()

                End If

                ban = 0
            End If
        End If
    End Sub



    Private Sub verifica_mercaderista()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        ban = 1
        Try
            Otrans.open()

            ban = 0
            Me.btn_guardar.Text = "Modificar"

            Me.Nom_mer.Enabled = False
            Me.email_mer.Focus()
            With dt.Rows(0)
                Me.email_mer.Text = .Item("TEXTO").ToString

                If .Item("TEXTO1") = "ACTIVO" Then
                    Me.activo.Checked = True
                    Me.inactivo.Checked = False
                End If
                If .Item("TEXTO1") = "INACTIVO" Then
                    Me.activo.Checked = False
                    Me.inactivo.Checked = True
                End If

            End With

            ban = 1
            Me.btn_guardar.Text = "Guardar"
            Me.email_mer.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub Proceso_Guardar()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String
        If Me.activo.Checked = True Then
            sta_mer = "ACTIVO"
        End If
        If Me.inactivo.Checked = True Then
            sta_mer = "INACTIVO"
        End If


        Try
            Otrans.open()
            If Nom_mer.Text <> String.Empty Then

                For Each sEmpresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")


                    ls_sql = "pa_ins_um_gen_tabcod '" & sEmpresa & "','" & _
                                                      "GEN_MERCADERISTA" & "','" & _
                                                      Me.Nom_mer.Text & "','" & _
                                                      Me.Nom_mer.Text & "','" & _
                                                      Me.Nom_mer.Text & "','" & _
                                                      Me.email_mer.Text & "','" & _
                                                      sta_mer & "','" & _
                                                      Me.Email_resp.Text & "','','','',0,0,0,0,0,'S','','','','',''"


                    Otrans.Ingresa(ls_sql)
                    If Otrans.Codigo_error = 0 Then
                        'MessageBox.Show("Informacion Ingresada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.activo.Checked = False
                        Me.inactivo.Checked = False

                    Else
                        MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Next
                MessageBox.Show("Proceso Finalizado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mercaderista_nuevo()
            Else
                MessageBox.Show("El nombre del Mercaderista No puede esta en blanco ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            mercaderista_nuevo()
            Me.Nom_mer.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Proceso_modificar()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String

        If Me.activo.Checked = True Then
            sta_mer = "ACTIVO"
        End If
        If Me.inactivo.Checked = True Then
            sta_mer = "INACTIVO"
        End If

        Try
            Otrans.open()
            If Nom_mer.Text <> String.Empty Then
                For Each sEmpresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")


                    ls_sql = "pa_upd_um_gen_tabcod '" & sEmpresa & "','" & _
                                                      "GEN_MERCADERISTA" & "','" & _
                                                      Me.Nom_mer.Text & "','" & _
                                                      Me.email_mer.Text & "','" & _
                                                      sta_mer & "','" & _
                                                      Me.Email_resp.Text & "'"
                    ls_sql = ls_sql
                    Otrans.Actualiza(ls_sql)
                    If Otrans.Codigo_error = 0 Then
                        Me.activo.Checked = False
                        Me.inactivo.Checked = False
                    Else
                        MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Next
                MessageBox.Show("Proceso Finalizado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mercaderista_nuevo()
            Else
                MessageBox.Show("El nombre del Mercaderista No puede esta en blanco ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            mercaderista_nuevo()
            Me.Nom_mer.Focus()
            Me.btn_guardar.Text = "Guardar"
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try

        ''56326389  Alejandra Mendez
    End Sub

   Private Sub Proceso_actualizar_DesAsignar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("DWH")
        Try
            Otrans.open()

            If MessageBox.Show("Esta Seguro de DesAsignar la Informacion del Cliente al Mercaderista ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                For Each drv1 As DataRowView In ods.Tables("mercaderistas").DefaultView
                    If drv1.Item("Quitar") = True Then
                        ls_sql = "pa_del_um_mercaderista_cliente_proveedor_proveedor '" & _
                                    cmb_mercaderistas.SelectedValue.ToString & "','" & _
                                    drv1.Item("empresa").ToString & "','" & _
                                    drv1.Item("ctacte").ToString & "'"
                        Otrans.Actualiza(ls_sql)
                    End If
                Next
            Else
                MessageBox.Show("Operacion Cancelada ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Proceso_actualizar_Asignar()
        Dim ls_sql As String
        Dim drv As DataRowView
        Dim Otrans As New Transaccional.Conexion("dwh")
        Dim dt As DataTable
        Dim lbOperar As Boolean = False


        Try
            Otrans.open()

            If MessageBox.Show("Esta Seguro de Actualizar la Informacion del Mercaderista ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                For Each drv In ods.Tables("tabla").DefaultView
                    If drv.Item("Asignar") = True Then

                        ''(c) Debo Verificar que el cliente no este previamente asignado

                        ls_sql = "pa_var_um_mercaderista_cliente_proveedor_proveedor null,'" & _
                                drv.Item("empresa").ToString & "','" & _
                                drv.Item("ctacte").ToString & "',''"
                        dt = Otrans.Obtiene(ls_sql)

                        If dt.Rows.Count = 0 Then
                            lbOperar = True
                        Else
                            If MessageBox.Show("El Cliente " & drv.Item("RazonSocial").ToString & "/" & drv.Item("Giro").ToString & " Esta Asignado Previamente, Desea Reasignarlo", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                lbOperar = True
                                ls_sql = "pa_del_um_mercaderista_cliente_proveedor_proveedor null,'" & _
                                        drv.Item("empresa").ToString & "','" & _
                                        drv.Item("ctacte").ToString & "',''"
                                Otrans.Elimina(ls_sql)

                            End If
                        End If


                        If lbOperar Then


                            ls_sql = "pa_ins_um_mercaderista_cliente_proveedor '" & _
                                        drv.Item("Empresa").ToString & "','" & _
                                        drv.Item("ctacte").ToString & "','" & _
                                        Me.cmb_mercaderistas.SelectedValue & "',''"
                            Otrans.Ingresa(ls_sql)
                        End If
                    End If
                Next
                MessageBox.Show("Asignacion Exitosa ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Operacion Cancelada ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub mercaderista_nuevo()
        Dim dt As New DataTable
        Try
            Me.Nom_mer.Text = ""
            Me.email_mer.Text = ""
            Me.Email_resp.Text = ""
            Me.Nom_mer.Enabled = True
            Me.email_mer.Enabled = True
            Me.email_mer.Enabled = True

            Me.activo.Checked = False
            Me.inactivo.Checked = False

        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub crear_estructura_listado()

        Dim dt As DataTable

        ods = New DataSet
        dt = New DataTable("mercaderistas_listado")
        dt.Columns.Add(New DataColumn("Mercaderista", GetType(String)))
        dt.Columns.Add(New DataColumn("Correo", GetType(String)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))

        ods.Tables.Add(dt.Copy)

        dt.TableName = "nce"
        ods.Tables.Add(dt.Copy)

        'Me.listadomercaderistas.DataSource = ods.Tables("mercaderistas_listado")

    End Sub
    Private Sub crear_estructura()

        Dim dt As DataTable

        ods = New DataSet
        dt = New DataTable("mercaderistas")
        dt.Columns.Add(New DataColumn("Quitar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedores", GetType(String)))
        dt.Columns.Add(New DataColumn("Contacto", GetType(String)))


        ods.Tables.Add(dt.Copy)

        dt.TableName = "nce"
        ods.Tables.Add(dt.Copy)

        Me.dgvListadoClientesAsignados.DataSource = ods.Tables("mercaderistas")

    End Sub

    Private Sub crear_estructura_clientes()

        Dim dt As DataTable

        ods = New DataSet
        dt = New DataTable("universal")
        dt.Columns.Add(New DataColumn("Asignar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        dt.Columns.Add(New DataColumn("CodLegal", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("Ejecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("Telefono", GetType(String)))


        ods.Tables.Add(dt.Copy)

        dt.TableName = "nce"
        ods.Tables.Add(dt.Copy)
        Me.dgv_listadoclientes1.DataSource = ods.Tables("universal")

        If ods.Tables("universal").Rows.Count > 0 Then
            Me.Button1.Enabled = True
        Else
            Me.Button1.Enabled = False
        End If
    End Sub


    Private Sub llenado_checkbox()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dr As DataRow
        Dim dr_aux As DataRow

        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        ods.Tables("mercaderistas").Rows.Clear()
        '        ls_sqltxt = "pa_sel_um_ctacte_mercaderista '" & Me.cmb_mercaderistas.Text & "'"

        ls_sqltxt = "pa_var_um_mercaderista_cliente_proveedor '" & Me.cmb_mercaderistas.Text & "'"
        oTrans = New Transaccional.Conexion("dwh")
        Try
            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            For Each dr In oTabla.Rows

                dr_aux = ods.Tables("mercaderistas").NewRow
                dr_aux.Item("Quitar") = 0
                dr_aux.Item("Empresa") = dr.Item("Empresa")
                dr_aux.Item("CtaCte") = dr.Item("CtaCte")
                dr_aux.Item("Contacto") = dr.Item("Contacto")
                dr_aux.Item("RazonSocial") = dr.Item("RazonSocial")
                dr_aux.Item("Direccion") = dr.Item("Direccion")
                dr_aux.Item("Proveedores") = dr.Item("Proveedores")
                ods.Tables("mercaderistas").Rows.Add(dr_aux)
            Next

            If ods.Tables("mercaderistas").Rows.Count > 0 Then
                Me.Button5.Enabled = True
            Else
                Me.Button5.Enabled = False
            End If



            clGen.Alinear_GridView(ods.Tables("mercaderistas"), dgvListadoClientesAsignados, "", "", "", "", "", "", True, True, True, 200, 0)
            '   ods.Tables.Add(oTabla.Copy)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try
    End Sub


    Private Sub llenado_clientes_universal()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable

        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        ods.Tables("mercaderistas").Rows.Clear()
        ' ls_sqltxt = "pa_sel_um_ctacte_mercaderista '" & Me.cmb_mercaderistas.Text & "'"
        ' ls_sqltxt = "pa_sel_um_ctacte_mercaderista '" & "felipe" & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)


            For Each dr In oTabla.Rows

                dr_aux = ods.Tables("mercaderistas").NewRow
                dr_aux.Item("Asignar") = 0
                dr_aux.Item("Empresa") = dr.Item("Empresa")
                dr_aux.Item("CtaCte") = dr.Item("CtaCte")
                dr_aux.Item("Contacto") = dr.Item("Contacto")
                dr_aux.Item("RazonSocial") = dr.Item("RazonSocial")
                ods.Tables("mercaderistas").Rows.Add(dr_aux)

            Next

            'clGen.Alinear_GridView(odsFACE.Tables("mercaderistas"), dgv_listadoclientes1, ",Asignar,Empresa,Ctacte,Contacto,Razonsocial,"", "", "", "", "","True, True, 150, 0)

            ods.Tables.Add(oTabla.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing
    End Sub

    
    Private Sub llenado_mercaderista1()

        Dim oTranss As Transaccional.Conexion
        Dim clsGen As New ClasesGenerales.General
        Dim oTablaMerc As DataTable
        Dim ls_filtro As String
        Dim ls_sqltxt As String

        oTranss = New Transaccional.Conexion("flexline")

        Try
            oTranss.open()

            ls_sqltxt = "pa_sel_um_gen_tabcod null,'GEN_MERCADERISTA','" & gs_empresa & "'"
            oTablaMerc = oTranss.Obtiene(ls_sqltxt)
            oTablaMerc.TableName = "lst_mercaderista"
            odataset.Tables.Add(oTablaMerc.Copy)

            'odataset.Tables("lst_mercaderista").DefaultView.RowFilter = ls_filtro
            Me.dgvListadoMercaderistas.DataSource = odataset.Tables("lst_mercaderista")

            clsGen.Alinear_GridView(odataset.Tables("lst_mercaderista"), dgvListadoMercaderistas, ",codigo,texto,texto1,", "", "", "", ",codigo=Nombre,texto=correo,texto1=estado,", "", "", True, True, 250, 0)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTranss.close()
            oTranss = Nothing
            clsGen = Nothing
        End Try



    End Sub

    Private Sub llenado_bitacora()
        Dim oTranss As Transaccional.Conexion
        Dim clGen As ClasesGenerales.General
        Dim oTablaMerc As DataTable
        Dim ls_filtro As String
        Dim ls_sqltxt As String
        odataset = New DataSet
        oTranss = New Transaccional.Conexion("flexline")

        Try
            oTranss.open()

            ls_sqltxt = "pa_sel_um_log_mercaderista '" & gs_empresa & "'"
            oTablaMerc = oTranss.Obtiene(ls_sqltxt)
            oTablaMerc.TableName = "log_mercaderista"
            odataset.Tables.Add(oTablaMerc.Copy)

            odataset.Tables("log_mercaderista").DefaultView.RowFilter = ls_filtro
            Me.Bitacora_correos.DataSource = odataset.Tables("log_mercaderista").DefaultView



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTranss.close()
        oTranss = Nothing


    End Sub

    Private Sub LlenarClienteMercaderista()

        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsGen.selectQuery("dwh", "pa_var_um_mercaderista_cliente_proveedor '" & Me.txtMercaderistaClienteProveedor.Text & "','" & Me.cmbEmpresaClienteProveedor.SelectedValue & "'")
            Me.cmbClienteClienteProveedor.DataSource = dt
            Me.cmbClienteClienteProveedor.ValueMember = "ctacte"
            Me.cmbClienteClienteProveedor.DisplayMember = "RazonSocial"
            
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub llenarGridProveedores()

        Dim clsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim lsSQL As String
        Try

            lsSQL = "Select distinct CODIGO from flexline.gen_tabcod " & _
                    " WHERE empresa = '" & Me.cmbEmpresaClienteProveedor.SelectedValue & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " & _
                    " and coalesce(tipo, '') <> ''  and isnull(texto, 'ACTIVO') <> 'INACTIVO' "

            dt = clsGen.selectQuery("flexline", lsSQL)
            dt.TableName = "proveedorDisponible"

            dt.Columns.Add(New DataColumn("Asignado", GetType(Integer)))
            'For Each dr As DataRow In dt.Rows
            '    dr.Item("asignado") = 0
            'Next



            ''Debo Obtener proveedores asignados y marcarlos en el listado para que no se muestre
            lsSQL = "pa_var_um_mercaderista_cliente_proveedor_proveedor '" & _
                Me.txtMercaderistaClienteProveedor.Text & "','" & Me.cmbEmpresaClienteProveedor.SelectedValue & "','" & _
                Me.cmbClienteClienteProveedor.SelectedValue & "'"

            dt2 = clsGen.selectQuery("dwh", lsSQL)
            dt2.TableName = "proveedorAsignado"
            'For Each dr As DataRow In dt2.Rows
            '    dt.DefaultView.RowFilter = "CODIGO = '" & dr.Item("proveedor").ToString & "'"
            '    If dt.DefaultView.Count > 0 Then
            '        dt.DefaultView(0).Item("Asignado") = 1
            '    End If
            'Next

            'dt.DefaultView.RowFilter = "asignado = 0"


            If odataset.Tables.Contains("proveedorAsignado") Then odataset.Tables.Remove("proveedorAsignado")
            If odataset.Tables.Contains("proveedorDisponible") Then odataset.Tables.Remove("proveedorDisponible")

            odataset.Tables.Add(dt.Copy)
            odataset.Tables.Add(dt2.Copy)

            'Me.dgvProveedoresDisponibles.DataSource = odataset.Tables("proveedorDisponible").DefaultView
            'clsGen.Alinear_GridView(odataset.Tables("proveedorDisponible"), dgvProveedoresDisponibles, "", ",asignado,", "", "", "", "", "", True, True, 250, 0)

            'Me.dgvProveedoresAsignados.DataSource = odataset.Tables("proveedorAsignado")
            'clsGen.Alinear_GridView(odataset.Tables("proveedorAsignado"), dgvProveedoresAsignados, "", "", "", "", "", "", "", True, True, 250, 0)
            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
        FiltrarProveedoresAsignados()
    End Sub


    Private Sub FiltrarProveedoresAsignados()
        Dim clsGen As New ClasesGenerales.General
        Try

            For Each dr As DataRow In odataset.Tables("proveedorDisponible").Rows
                dr.Item("Asignado") = 2
            Next


            For Each dr As DataRow In odataset.Tables("proveedorAsignado").Rows
                odataset.Tables("proveedorDisponible").DefaultView.RowFilter = "CODIGO = '" & dr.Item("proveedor").ToString & "'"
                If odataset.Tables("proveedorDisponible").DefaultView.Count > 0 Then
                    odataset.Tables("proveedorDisponible").DefaultView(0).Item("Asignado") = 1
                End If
            Next
        Catch ex As Exception
        Finally
            odataset.Tables("proveedorDisponible").DefaultView.RowFilter = ""
            odataset.Tables("proveedorDisponible").DefaultView.RowFilter = "Asignado = 2"

            Me.dgvProveedoresDisponibles.DataSource = odataset.Tables("proveedorDisponible").DefaultView
            clsGen.Alinear_GridView(odataset.Tables("proveedorDisponible"), dgvProveedoresDisponibles, "", ",asignado,", "", "", "", "", "", True, True, 250, 0)

            Me.dgvProveedoresAsignados.DataSource = odataset.Tables("proveedorAsignado")
            clsGen.Alinear_GridView(odataset.Tables("proveedorAsignado"), dgvProveedoresAsignados, "", "", "", "", "", "", "", True, True, 250, 0)


            clsGen = Nothing
        End Try

    End Sub

    Private Sub procesoTraladosClientes()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.insertQuery("dwh", "pa_upd_um_mercaderista_cliente_proveedor_mover '" & Me.txtMercaderistaOrigen.Text & "','" & Me.txtMercaderistaDestino.Text & "'")
            MessageBox.Show("Proceso Finalizado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub asignarProveedores()

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            ''Limpiar Proveedores Asignados al Usuario
            lsSQL = "pa_del_um_mercaderista_cliente_proveedor_proveedor '" & Me.txtMercaderistaClienteProveedor.Text & "','" &
                        Me.cmbEmpresaClienteProveedor.SelectedValue & "','" & Me.cmbClienteClienteProveedor.SelectedValue.ToString & "'"
            clsGen.insertQuery("dwh", lsSQL)


            For Each dr As DataRow In odataset.Tables("proveedorAsignado").Rows

                lsSQL = "pa_ins_um_mercaderista_cliente_proveedor_proveedor '" & Me.cmbEmpresaClienteProveedor.SelectedValue & "','" &
                        Me.cmbClienteClienteProveedor.SelectedValue.ToString & "','" & Me.txtMercaderistaClienteProveedor.Text & "','" & _
                            dr.Item("proveedor").ToString & "','" & gs_usuario & "'"

                clsGen.insertQuery("dwh", lsSQL)
            Next

            MessageBox.Show("Proceso Finalizado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        Finally
            clsGen = Nothing

        End Try
    End Sub


    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        mercaderista_nuevo()
        botones(True)
        Me.Nom_mer.Focus()
        ban = 0
    End Sub


    Private Sub cmb_mercaderistas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_mercaderistas.SelectedValueChanged
        crear_estructura()
        llenado_checkbox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ver_cli As Integer
        Dim drv As DataRowView
        ver_cli = 0
        For Each drv In ods.Tables("tabla").DefaultView
            If drv.Item("Asignar") = True Then
                ver_cli = 1
            End If
        Next

        If ver_cli = 1 Then

            Proceso_actualizar_Asignar()
            'para actualizar el datagridview de clientes asignados
            crear_estructura_clientes()
            crear_estructura()
            llenado_checkbox()
        Else
            MessageBox.Show("No hay clientes Seleccionados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub email_mer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles email_mer.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                Dim mail As New System.Net.Mail.MailAddress(Me.email_mer.Text)
            Catch ex As Exception
                MessageBox.Show("Email No Valido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.email_mer.Focus()
            End Try
        End If
    End Sub

    Private Sub email_mer_Leave(sender As Object, e As EventArgs) Handles email_mer.Leave
        If Me.email_mer.Text <> "" Then
            Try
                Dim mail As New System.Net.Mail.MailAddress(Me.email_mer.Text)
            Catch ex As Exception
                MessageBox.Show("Email No Valido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.email_mer.Focus()
            End Try
        End If

    End Sub

    Private Sub dgv_listadoclientes_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)
        Me.Button1.Enabled = False
        Me.Button5.Enabled = True
    End Sub

    Private Sub dgv_listadoclientes1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listadoclientes1.CellContentClick
        Me.Button5.Enabled = False
        Me.Button1.Enabled = True
    End Sub


    Private Sub correos()


        Dim sta_mer As String
        Dim nrow As Integer
        Dim oTrans As New Transaccional.Conexion("flexline")
        oTrans.open()
        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim ls_sql As String
        Dim clsGen As New ClasesGenerales.General


        If MessageBox.Show("Esta Seguro de procesar los correos para los mercaderistas activos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) Then

            For Each drv In odataset.Tables("lst_mercaderista").DefaultView
                Try
                    If drv.Item("TEXTO1") = "ACTIVO" Then
                        ruta = ""
                        generar_reporte()
                        Dim info As New FileInfo(ruta)

                        ' Get length of the file.
                        '(c) 20152710 validar el peso del archivo
                        'Solo se enviaran archivos mayores a 30Kb
                        If info.Length / 1024 > 30 Then


                            Message = New System.Net.Mail.MailMessage()
                            Dim adjuntar As New Net.Mail.Attachment(ruta)
                            SMTP1 = New System.Net.Mail.SmtpClient
                            'config. para Outlook
                            SMTP1.Port = 25
                            SMTP1.Host = "192.192.1.103" 'servidor de correo outlook
                            SMTP1.EnableSsl = False

                            ''config. para hotmail
                            'SMTP1.Port = 587
                            'SMTP1.Host = "smtp-mail.outlook.com"
                            'SMTP1.EnableSsl = True


                            SMTP1.Credentials = New Net.NetworkCredential(Me.Txt_mail.Text, Txt_contra.Text)
                            Message.[To].Add(drv.Item("TEXTO"))
                            Message.From = New System.Net.Mail.MailAddress(Me.Txt_mail.Text, gs_nombre_usuario, System.Text.Encoding.UTF8) 'Quien envía el e-mail
                            Message.Subject = "Informacion Tiendas " & gs_empresa & " Al " & Today.ToString("dd/MM/yyyy")
                            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                            Message.Body = "Informacion " & gs_empresa & " ** Por favor confirmar recepcion a este correo ***"
                            Message.BodyEncoding = System.Text.Encoding.UTF8
                            Message.Priority = System.Net.Mail.MailPriority.Normal
                            Message.IsBodyHtml = False
                            Message.Attachments.Add(adjuntar)

                            SMTP1.Send(Message)

                            'Message.Attachments.Clear()

                            '' llena bitacora
                            ls_sql = "pa_ins_um_gen_log_mercaderista '" & gs_empresa & "','" & drv.Item("CODIGO") & "','" & _
                                                          Date.Today & "'," & _
                                                          1 & ",'" & _
                                                          drv.Item("TEXTO") & "','" & _
                                                          drv.Item("TEXTO2") & "'"
                            oTrans.Ingresa(ls_sql)
                        End If
                    End If

                Catch ex As Exception

                    'MessageBox.Show("error  " + Err.Description, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    oTrans.Escribir_Log(Err.Description)
                Finally
                End Try
            Next
            MessageBox.Show("Correos enviados con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            llenado_bitacora()

        End If

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        llenado_mercaderista1()
        correos()
    End Sub


    Private Sub generar_reporte()
        Dim otrans As New Transaccional.Conexion("DWH")
        Dim ls_sql As String
        Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        Dim ubicacion_actual As String
        Dim path_reporte, ppath_reporte As String
        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Randomize()
        Dim aleat As Integer

        ''Obtengo Datos de Conexion

        Try

            otrans.open()
            pm_conexion = clsgen.Parametros_Conexion("dwh")
            ppath_reporte = clsgen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)

            '023:
            path_reporte = ppath_reporte & "Finanzas\Facturacion\Retail-Link2.rpt"
            'path_reporte = "c:\reportes\Retail-Link2.rpt"
            pm_parametros(0) = "@fecha"
            pm_parametros(1) = "@empresa"
            pm_parametros(2) = "@mercaderista"


            pm_valores(0) = Date.Today.ToString("yyyy/MM/dd")
            pm_valores(1) = gs_empresa
            pm_valores(2) = drv.Item("CODIGO")

            aleat = CInt(Int((2000 * Rnd()) + 1))
            ruta = "c:\temp\Reporte_mercaderista_" & drv.Item("CODIGO") & aleat & ".pdf"

            Oaut.Archivo_Generado = ruta
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                   True, True, "PDF", False)


            ' pm_valores(1) & "','" & _
            ' pm_valores(2) & "',NULL,NULL,NULL,100"
            ' otrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

            Oaut.finalizar()
            Oaut = Nothing
            clsgen = Nothing


        End Try

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        botones(False)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        botones(True)

    End Sub

    Private Sub botones(valor As Boolean)
        Me.btn_nuevo.Visible = Not valor
        Me.btn_modificar.Visible = Not valor
        Me.btn_guardar.Visible = valor
        Me.btn_Cancelar.Visible = valor
        Me.GroupBox3.Enabled = valor


    End Sub

    Private Sub dgvListadoMercaderistas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListadoMercaderistas.CellContentClick
        ban = 1
        mostrarMercaderista()
    End Sub

    Private Sub btnBuscarClienteProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarClienteProveedor.Click
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & Me.cmbEmpresaClienteProveedor.SelectedValue & "' and tipo = 'gen_mercaderista' and "
        frm_busqueda.parametros = "descripcion"
        frm_busqueda.nombre_vista = "gen_tabcod"
        frm_busqueda.lista_campos = "descripcion, texto1 as estado"

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.ShowDialog(Me)

        Try
            Me.txtMercaderistaClienteProveedor.Text = frm_busqueda.resultado


        Catch ex As Exception
        End Try

        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        If Me.txtMercaderistaClienteProveedor.Text.Length > 0 Then
            LlenarClienteMercaderista()
        End If

    End Sub

    Private Sub btnLlenarClienteProveedor_Click(sender As Object, e As EventArgs) Handles btnLlenarClienteProveedor.Click
        llenarGridProveedores()
    End Sub

    Private Sub btnProcesarMoverCliente_Click(sender As Object, e As EventArgs) Handles btnProcesarMoverCliente.Click
        If MessageBox.Show("Esta Seguro de Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            procesoTraladosClientes()
        End If
    End Sub


    Private Sub dgvProveedoresDisponibles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresDisponibles.CellDoubleClick

        Try

            Dim dr As DataRow = odataset.Tables("proveedorAsignado").NewRow
            dr.Item("proveedor") = Me.dgvProveedoresDisponibles.Item("CODIGO", _
                                Me.dgvProveedoresDisponibles.CurrentRow.Index).Value


            odataset.Tables("proveedorAsignado").Rows.Add(dr)
            FiltrarProveedoresAsignados()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvProveedoresAsignados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresAsignados.CellContentClick

    End Sub

    Private Sub dgvProveedoresAsignados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresAsignados.CellDoubleClick
        Try

            Dim lsProveedor As String = Me.dgvProveedoresAsignados.Item("proveedor", _
                                Me.dgvProveedoresAsignados.CurrentRow.Index).Value


            For Each dr As DataRow In odataset.Tables("proveedorAsignado").Rows

                If dr.Item("proveedor") = lsProveedor Then
                    dr.Delete()
                    Exit For
                End If
            Next

            odataset.Tables("proveedorAsignado").AcceptChanges()

        Catch ex As Exception
        Finally
            FiltrarProveedoresAsignados()

        End Try
    End Sub

    Private Sub dgvProveedoresDisponibles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresDisponibles.CellContentClick

    End Sub

    Private Sub btnGuardarClienteProveedor_Click(sender As Object, e As EventArgs) Handles btnGuardarClienteProveedor.Click
        If MessageBox.Show("Esta Seguro De Asignar Proveedores", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            asignarProveedores()
        End If
    End Sub

    Private Sub txt_buscar1_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar1.TextChanged

    End Sub


    Private Sub btnBuscarOrigen_Click(sender As Object, e As EventArgs) Handles btnBuscarOrigen.Click
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa in ('DMARTE1','CODICASA','DIUVA') and tipo = 'gen_mercaderista' and "
        frm_busqueda.parametros = "descripcion"
        frm_busqueda.nombre_vista = "gen_tabcod"
        frm_busqueda.lista_campos = "descripcion, texto1 as estado"

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.ShowDialog(Me)

        Try
            Me.txtMercaderistaOrigen.Text = frm_busqueda.resultado


        Catch ex As Exception
        End Try

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

    End Sub

    Private Sub btnBuscarDestino_Click(sender As Object, e As EventArgs) Handles btnBuscarDestino.Click
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa in ('DMARTE1','CODICASA','DIUVA') and tipo = 'gen_mercaderista' and "
        frm_busqueda.parametros = "descripcion"
        frm_busqueda.nombre_vista = "gen_tabcod"
        frm_busqueda.lista_campos = "descripcion, texto1 as estado"

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.ShowDialog(Me)

        Try
            Me.txtMercaderistaDestino.Text = frm_busqueda.resultado

        Catch ex As Exception
        End Try

        frm_busqueda.Dispose()
        frm_busqueda = Nothing
    End Sub

    Private Sub btnNuevoMoverCliente_Click(sender As Object, e As EventArgs) Handles btnNuevoMoverCliente.Click
        Me.txtMercaderistaOrigen.Text = ""
        Me.txtMercaderistaDestino.Text = ""
    End Sub

End Class


