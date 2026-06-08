Imports System.IO
Public Class frm_diseñador_reportes
    Inherits System.Windows.Forms.Form
    Dim odataset As DataSet
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Dim otabla_permisos As DataTable


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
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_linea_encabezado As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_linea_detalle As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_alineacion_detalle As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_alineacion_encabezado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_reporte As System.Windows.Forms.TextBox
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_areas As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nombre_reporte As System.Windows.Forms.TextBox
    Friend WithEvents clb_empresa As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_asignar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents txt_cod_reporte As System.Windows.Forms.TextBox
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_filtro1 As System.Windows.Forms.TextBox
    Friend WithEvents dg_usuarios As System.Windows.Forms.DataGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_proceso As System.Windows.Forms.TextBox
    Friend WithEvents cmb_servidor As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chk_tiempo_ejecucion As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_diseñador_reportes))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox
        Me.cmb_1 = New System.Windows.Forms.ComboBox
        Me.txt_filtro1 = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dg_usuarios = New System.Windows.Forms.DataGrid
        Me.Label9 = New System.Windows.Forms.Label
        Me.chk_tiempo_ejecucion = New System.Windows.Forms.CheckBox
        Me.clb_empresa = New System.Windows.Forms.CheckedListBox
        Me.txt_proceso = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmb_servidor = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_areas = New System.Windows.Forms.ComboBox
        Me.txt_cod_reporte = New System.Windows.Forms.TextBox
        Me.txt_nombre_reporte = New System.Windows.Forms.TextBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.txt_ruta_reporte = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_Eliminar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_asignar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DataGrid4 = New System.Windows.Forms.DataGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cmb_alineacion_detalle = New System.Windows.Forms.ComboBox
        Me.cmb_linea_detalle = New System.Windows.Forms.ComboBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.DataGrid3 = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.cmb_linea_encabezado = New System.Windows.Forms.ComboBox
        Me.cmb_alineacion_encabezado = New System.Windows.Forms.ComboBox
        Me.ofd = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(910, 578)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.cmb_valor1)
        Me.TabPage1.Controls.Add(Me.cmb_1)
        Me.TabPage1.Controls.Add(Me.txt_filtro1)
        Me.TabPage1.Controls.Add(Me.DataGrid1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(902, 549)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado Reportes"
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(17, 12)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(129, 24)
        Me.cmb_valor1.Sorted = True
        Me.cmb_valor1.TabIndex = 26
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(152, 12)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(65, 24)
        Me.cmb_1.TabIndex = 25
        '
        'txt_filtro1
        '
        Me.txt_filtro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_filtro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_filtro1.Location = New System.Drawing.Point(225, 13)
        Me.txt_filtro1.Name = "txt_filtro1"
        Me.txt_filtro1.Size = New System.Drawing.Size(627, 22)
        Me.txt_filtro1.TabIndex = 24
        '
        'DataGrid1
        '
        Me.DataGrid1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DataGrid1.CaptionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.GridLineColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(0, 42)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(902, 507)
        Me.DataGrid1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.btn_Eliminar)
        Me.TabPage3.Controls.Add(Me.btn_nuevo)
        Me.TabPage3.Controls.Add(Me.btn_asignar)
        Me.TabPage3.Controls.Add(Me.btn_guardar)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(759, 552)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Asignacion"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.dg_usuarios)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.chk_tiempo_ejecucion)
        Me.GroupBox5.Controls.Add(Me.clb_empresa)
        Me.GroupBox5.Controls.Add(Me.txt_proceso)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.cmb_servidor)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 117)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(625, 418)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Permisos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Usuarios"
        '
        'dg_usuarios
        '
        Me.dg_usuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dg_usuarios.CaptionVisible = False
        Me.dg_usuarios.DataMember = ""
        Me.dg_usuarios.FlatMode = True
        Me.dg_usuarios.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_usuarios.Location = New System.Drawing.Point(71, 18)
        Me.dg_usuarios.Name = "dg_usuarios"
        Me.dg_usuarios.Size = New System.Drawing.Size(264, 394)
        Me.dg_usuarios.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(396, 342)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 64)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Acciones      X = Ejecutar  P = Imprimir  E = Exportar"
        '
        'chk_tiempo_ejecucion
        '
        Me.chk_tiempo_ejecucion.AutoSize = True
        Me.chk_tiempo_ejecucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_tiempo_ejecucion.Checked = True
        Me.chk_tiempo_ejecucion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_tiempo_ejecucion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_tiempo_ejecucion.Location = New System.Drawing.Point(399, 308)
        Me.chk_tiempo_ejecucion.Name = "chk_tiempo_ejecucion"
        Me.chk_tiempo_ejecucion.Size = New System.Drawing.Size(196, 20)
        Me.chk_tiempo_ejecucion.TabIndex = 27
        Me.chk_tiempo_ejecucion.Text = "Ejecutar Antes del Reporte"
        '
        'clb_empresa
        '
        Me.clb_empresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clb_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clb_empresa.CheckOnClick = True
        Me.clb_empresa.Location = New System.Drawing.Point(462, 18)
        Me.clb_empresa.Name = "clb_empresa"
        Me.clb_empresa.Size = New System.Drawing.Size(145, 172)
        Me.clb_empresa.TabIndex = 14
        '
        'txt_proceso
        '
        Me.txt_proceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proceso.Location = New System.Drawing.Point(461, 230)
        Me.txt_proceso.Multiline = True
        Me.txt_proceso.Name = "txt_proceso"
        Me.txt_proceso.Size = New System.Drawing.Size(146, 64)
        Me.txt_proceso.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(396, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 16)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Servidor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(396, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Empresa"
        '
        'cmb_servidor
        '
        Me.cmb_servidor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_servidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_servidor.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_servidor.Items.AddRange(New Object() {"UMBRAL", "FLEXLINE", "ONBASE", "UMBRAL_FLEXLINE"})
        Me.cmb_servidor.Location = New System.Drawing.Point(461, 198)
        Me.cmb_servidor.Name = "cmb_servidor"
        Me.cmb_servidor.Size = New System.Drawing.Size(146, 24)
        Me.cmb_servidor.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(532, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 70)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Exportar  X = Excel P = PDF   * = Todos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(396, 230)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Proceso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.cmb_areas)
        Me.GroupBox4.Controls.Add(Me.txt_cod_reporte)
        Me.GroupBox4.Controls.Add(Me.txt_nombre_reporte)
        Me.GroupBox4.Controls.Add(Me.btn_buscar)
        Me.GroupBox4.Controls.Add(Me.txt_ruta_reporte)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(625, 100)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos Reporte"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Area"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Ruta"
        '
        'cmb_areas
        '
        Me.cmb_areas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_areas.DropDownWidth = 350
        Me.cmb_areas.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_areas.Location = New System.Drawing.Point(119, 18)
        Me.cmb_areas.Name = "cmb_areas"
        Me.cmb_areas.Size = New System.Drawing.Size(491, 24)
        Me.cmb_areas.TabIndex = 10
        '
        'txt_cod_reporte
        '
        Me.txt_cod_reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_reporte.Location = New System.Drawing.Point(509, 18)
        Me.txt_cod_reporte.Name = "txt_cod_reporte"
        Me.txt_cod_reporte.Size = New System.Drawing.Size(64, 22)
        Me.txt_cod_reporte.TabIndex = 18
        Me.txt_cod_reporte.Visible = False
        '
        'txt_nombre_reporte
        '
        Me.txt_nombre_reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_reporte.Location = New System.Drawing.Point(119, 43)
        Me.txt_nombre_reporte.Name = "txt_nombre_reporte"
        Me.txt_nombre_reporte.Size = New System.Drawing.Size(491, 22)
        Me.txt_nombre_reporte.TabIndex = 0
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.Location = New System.Drawing.Point(119, 67)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 22)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.Text = "..."
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'txt_ruta_reporte
        '
        Me.txt_ruta_reporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_ruta_reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ruta_reporte.Location = New System.Drawing.Point(140, 67)
        Me.txt_ruta_reporte.Name = "txt_ruta_reporte"
        Me.txt_ruta_reporte.Size = New System.Drawing.Size(470, 22)
        Me.txt_ruta_reporte.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombre Reporte"
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Eliminar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Eliminar.ForeColor = System.Drawing.Color.White
        Me.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Eliminar.ImageIndex = 2
        Me.btn_Eliminar.ImageList = Me.ImageList1
        Me.btn_Eliminar.Location = New System.Drawing.Point(655, 196)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(86, 72)
        Me.btn_Eliminar.TabIndex = 19
        Me.btn_Eliminar.Text = "Eliminar"
        Me.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Eliminar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "new report.png")
        Me.ImageList1.Images.SetKeyName(1, "save report.png")
        Me.ImageList1.Images.SetKeyName(2, "report_delete.png")
        Me.ImageList1.Images.SetKeyName(3, "asign report.png")
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(655, 20)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(86, 72)
        Me.btn_nuevo.TabIndex = 17
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_asignar
        '
        Me.btn_asignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_asignar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_asignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_asignar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_asignar.ForeColor = System.Drawing.Color.White
        Me.btn_asignar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_asignar.ImageIndex = 3
        Me.btn_asignar.ImageList = Me.ImageList1
        Me.btn_asignar.Location = New System.Drawing.Point(655, 284)
        Me.btn_asignar.Name = "btn_asignar"
        Me.btn_asignar.Size = New System.Drawing.Size(86, 72)
        Me.btn_asignar.TabIndex = 16
        Me.btn_asignar.Text = "&Asignar"
        Me.btn_asignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_asignar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(655, 108)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(86, 72)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(759, 552)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Diseño"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGrid4)
        Me.GroupBox3.Location = New System.Drawing.Point(79, 378)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(600, 144)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pie de Pagina"
        '
        'DataGrid4
        '
        Me.DataGrid4.DataMember = ""
        Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid4.Location = New System.Drawing.Point(16, 40)
        Me.DataGrid4.Name = "DataGrid4"
        Me.DataGrid4.Size = New System.Drawing.Size(568, 96)
        Me.DataGrid4.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.cmb_alineacion_detalle)
        Me.GroupBox2.Controls.Add(Me.cmb_linea_detalle)
        Me.GroupBox2.Controls.Add(Me.ComboBox4)
        Me.GroupBox2.Controls.Add(Me.DataGrid3)
        Me.GroupBox2.Location = New System.Drawing.Point(79, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(600, 136)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(480, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(16, 24)
        Me.CheckBox1.TabIndex = 5
        '
        'cmb_alineacion_detalle
        '
        Me.cmb_alineacion_detalle.Location = New System.Drawing.Point(264, 24)
        Me.cmb_alineacion_detalle.Name = "cmb_alineacion_detalle"
        Me.cmb_alineacion_detalle.Size = New System.Drawing.Size(121, 24)
        Me.cmb_alineacion_detalle.TabIndex = 4
        '
        'cmb_linea_detalle
        '
        Me.cmb_linea_detalle.Location = New System.Drawing.Point(200, 24)
        Me.cmb_linea_detalle.Name = "cmb_linea_detalle"
        Me.cmb_linea_detalle.Size = New System.Drawing.Size(48, 24)
        Me.cmb_linea_detalle.TabIndex = 3
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(16, 24)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(168, 24)
        Me.ComboBox4.TabIndex = 2
        '
        'DataGrid3
        '
        Me.DataGrid3.DataMember = ""
        Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid3.Location = New System.Drawing.Point(16, 48)
        Me.DataGrid3.Name = "DataGrid3"
        Me.DataGrid3.Size = New System.Drawing.Size(576, 72)
        Me.DataGrid3.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DataGrid2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.cmb_linea_encabezado)
        Me.GroupBox1.Controls.Add(Me.cmb_alineacion_encabezado)
        Me.GroupBox1.Location = New System.Drawing.Point(79, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 168)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encabezado"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(264, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Alineacion"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(200, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Linea"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Campo"
        '
        'DataGrid2
        '
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 72)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.Size = New System.Drawing.Size(576, 96)
        Me.DataGrid2.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(16, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(168, 24)
        Me.ComboBox1.TabIndex = 2
        '
        'cmb_linea_encabezado
        '
        Me.cmb_linea_encabezado.Location = New System.Drawing.Point(200, 40)
        Me.cmb_linea_encabezado.Name = "cmb_linea_encabezado"
        Me.cmb_linea_encabezado.Size = New System.Drawing.Size(48, 24)
        Me.cmb_linea_encabezado.TabIndex = 3
        '
        'cmb_alineacion_encabezado
        '
        Me.cmb_alineacion_encabezado.Location = New System.Drawing.Point(264, 40)
        Me.cmb_alineacion_encabezado.Name = "cmb_alineacion_encabezado"
        Me.cmb_alineacion_encabezado.Size = New System.Drawing.Size(121, 24)
        Me.cmb_alineacion_encabezado.TabIndex = 4
        '
        'frm_diseñador_reportes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(910, 578)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_diseñador_reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diseñador Reportes"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dg_usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frm_diseñador_reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Grid()
    End Sub

    Private Sub Llenar_Combos()

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("Flexline")
        otrans.open()
        Try
            otabla = otrans.Obtiene("pa_sel_um_sg_menu_submenu_opcion 'Reportes'")

            Me.cmb_areas.DataSource = otabla
            Me.cmb_areas.ValueMember = "cod_opcion"
            Me.cmb_areas.DisplayMember = "opcion"

            'otabla = otrans.Obtiene("pa_sel_um_sg_menu_submenu_opcion 'Cubos'")

            'Lleno la lista de empresas
            otabla = otrans.Obtiene("pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'")
            Me.clb_empresa.DataSource = otabla
            Me.clb_empresa.ValueMember = "EMPRESA"

            otrans.close()

            'Lleno el grid de usuarios sin informacion
            usuario_reporte(-1)


            Me.cmb_1.Items.Add("=")
            Me.cmb_1.Items.Add(">")
            Me.cmb_1.Items.Add("<")
            Me.cmb_1.Items.Add("like")
            Me.cmb_1.Text = Me.cmb_1.Items(3)

            Me.cmb_valor1.Items.Add("cod_reporte")
            Me.cmb_valor1.Items.Add("opcion")
            Me.cmb_valor1.Items.Add("nombre_reporte")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_Grid()
        Dim oTabla As DataTable
        Dim Clgen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("Flexline")
        odataset = New DataSet

        otrans.open()

        oTabla = otrans.Obtiene("pa_sel_um_gen_reporte")
        otrans.close()

        oTabla.TableName = "reportes"
        odataset.Tables.Add(oTabla.Copy)

        Me.DataGrid1.DataSource = odataset.Tables("reportes")
        Clgen.Alinea_Grid(oTabla, DataGrid1, oTabla.TableName, 0, 250, 50, False, True, "", True, "")


        Clgen = Nothing
        otrans = Nothing

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim xx As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Try
            xx = "pa_sel_um_gen_parametros_sistema"
            otrans.open()
            dt = otrans.Obtiene(xx)
            otrans.close()
            xx = dt.Rows(0)("path_reportes").ToString
        Finally
            otrans = Nothing
        End Try

        ofd.Filter = "rpt|*.rpt"
        ofd.InitialDirectory = xx '"\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza"
        ofd.ShowDialog()
        Me.txt_ruta_reporte.Text = ofd.FileName

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim ls_stringsql As String
        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        If Me.btn_guardar.Text = "Actualizar" Then
            'Actualizar(informacion)
            If MessageBox.Show("Esta Seguro de Modificar esta Informacion", "Confirmacion", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ls_stringsql = "pa_upd_um_gen_reporte " & Me.txt_cod_reporte.Text & "," & Me.cmb_areas.SelectedValue & ",'" & Me.txt_nombre_reporte.Text & "','" & Me.txt_ruta_reporte.Text & "','" & gs_usuario & "'"
                otrans.Actualiza(ls_stringsql)
            End If
        Else
            ls_stringsql = "pa_ins_um_gen_reporte  " & Me.cmb_areas.SelectedValue & ",'" & Me.txt_nombre_reporte.Text & "','" & Me.txt_ruta_reporte.Text & "','" & gs_usuario & "'"
            otrans.Ingresa(ls_stringsql)


        End If

        If otrans.Codigo_error > 0 Then
            MessageBox.Show(otrans.descripcion_error)
        Else
            ls_stringsql = "pa_sel_um_gen_reporte " & Me.cmb_areas.SelectedValue & ",'" & Me.txt_nombre_reporte.Text & "','" & Me.txt_ruta_reporte.Text & "'"
            otabla = otrans.Obtiene(ls_stringsql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error)
            Else
                Me.txt_cod_reporte.Text = otabla.Rows(0).Item("cod_reporte")
                asigno_usuario_reporte()
                asigno_reporte_empresa()
                asigno_proceso_reporte()
                MessageBox.Show("Informacion Actualizada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        otrans.close()
        otrans = Nothing

        Llenar_Grid()

    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Dim li_row_number As Integer
        Dim resultado As Integer
        li_row_number = Me.DataGrid1.CurrentCell.RowNumber()
        resultado = Me.DataGrid1.Item(li_row_number, 0)

        Mostrar_Reporte(resultado)
        Me.btn_guardar.Text = "Actualizar"

    End Sub

    Private Sub Mostrar_Reporte(ByVal pcod_reporte As Integer)
        Dim otable As DataTable

        otable = odataset.Tables("reportes").Copy
        otable.DefaultView.RowFilter = "cod_reporte=" & pcod_reporte

        Me.txt_nombre_reporte.Text = otable.DefaultView(0)("nombre_reporte")
        Me.txt_ruta_reporte.Text = otable.DefaultView(0)("path_reporte")
        Me.cmb_areas.SelectedValue = otable.DefaultView(0)("cod_opcion")
        'Me.btn_guardar.Text = "Modificar"
        Me.txt_cod_reporte.Text = pcod_reporte

        Me.TabControl1.SelectedTab = Me.TabPage3

        usuario_reporte(pcod_reporte)
        reporte_Empresa(pcod_reporte)
        proceso_reporte(pcod_reporte)

        Me.TabControl1.TabPages(2).Hide()

    End Sub

    Private Sub usuario_reporte(ByVal pcod_reporte As Integer)
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        otrans.open()

        otabla_permisos = otrans.Obtiene("pa_sel_um_sg_usuario_reporte_permisos " & pcod_reporte)

        If otrans.Codigo_error = 0 Then
            Me.dg_usuarios.DataSource = otabla_permisos
            clsgen.Alinea_Grid(otabla_permisos, Me.dg_usuarios, otabla_permisos.TableName, -1, 75, 0, False, True, "", True, "")
        End If

        otrans.close()
        otrans = Nothing
        clsgen = Nothing
    End Sub

    Private Sub reporte_Empresa(ByVal pcod_reporte As Integer)
        Dim i As Integer
        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        For i = 0 To Me.clb_empresa.Items.Count() - 1
            Me.clb_empresa.SetItemChecked(i, False)
        Next

        otabla = otrans.Obtiene("pa_sel_um_gen_reporte_empresa " & pcod_reporte & ",NULL")
        If otrans.Codigo_error = 0 Then
            For i = 0 To Me.clb_empresa.Items.Count() - 1
                otabla.DefaultView.RowFilter = "empresa = '" & Me.clb_empresa.Items(i)("EMPRESA") & "'"
                If otabla.DefaultView.Count > 0 Then
                    Me.clb_empresa.SetItemChecked(i, True)
                End If
            Next
        End If

        otrans.close()
        otrans = Nothing
    End Sub

    Private Sub Proceso_Reporte(ByVal pcod_reporte As Integer)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()
            ls_sql = "pa_sel_um_gen_reporte_proceso " & pcod_reporte
            dt = otrans.Obtiene(ls_sql)
            If otrans.Codigo_error = 0 Then
                Me.txt_proceso.Text = dt.Rows(0).Item("proceso")
                Me.cmb_servidor.Text = dt.Rows(0).Item("servidor")
                Me.chk_tiempo_ejecucion.CheckState = IIf(dt.Rows(0).Item("tiempo_ejecucion") = True, CheckState.Checked, CheckState.Unchecked)
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If
        Catch ex As Exception
            Me.txt_proceso.Text = ""
            Me.cmb_servidor.Text = ""
            Me.chk_tiempo_ejecucion.CheckState = CheckState.Unchecked
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.TabControl1.SelectedTab = Me.TabPage3
        Me.txt_nombre_reporte.Text = ""
        Me.txt_cod_reporte.Text = "0"
        Me.txt_ruta_reporte.Text = ""
        Me.cmb_areas.SelectedValue = 0
        Me.btn_guardar.Text = "&Guardar"
        usuario_reporte(0)
        reporte_Empresa(0)
        Proceso_Reporte(0)
    End Sub


    Private Sub btn_asignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_asignar.Click
        Try

            asigno_usuario_reporte()
            asigno_reporte_empresa()
            Asigno_Proceso_Reporte()

            MessageBox.Show("Informacion Actualizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub asigno_reporte_empresa()
        Dim i, li_resultado As Integer
        Dim ls_sqlstring As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        oTrans.open()

        ' Limpio la Informacion del usuarios por reporte
        ls_sqlstring = "pa_del_um_gen_reporte_empresa " & Me.txt_cod_reporte.Text
        li_resultado = oTrans.Elimina(ls_sqlstring)

        If oTrans.Codigo_error = 0 Then
            For i = 0 To Me.clb_empresa.Items.Count() - 1
                If Me.clb_empresa.GetItemChecked(i) Then
                    'Dar de alta usuario reporte
                    ls_sqlstring = "pa_ins_um_gen_reporte_empresa  " & Me.txt_cod_reporte.Text & ",'" & Me.clb_empresa.Items(i)("empresa") & "'"
                    li_resultado = oTrans.Ingresa(ls_sqlstring)

                End If
            Next
        End If

        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub asigno_usuario_reporte()
        Dim li_resultado As Integer
        Dim ls_sqlstring As String
        Dim drv As DataRowView
        Dim oTrans As New Transaccional.Conexion("flexline")

        oTrans.open()
        Try
            ' Limpio la Informacion del usuarios por reporte
            ls_sqlstring = "pa_del_um_sg_usuario_reporte " & Me.txt_cod_reporte.Text
            li_resultado = oTrans.Elimina(ls_sqlstring)

            If oTrans.Codigo_error = 0 Then

                otabla_permisos.DefaultView.RowFilter = " acciones <>  " & "''"

                For Each drv In otabla_permisos.DefaultView
                    ls_sqlstring = "pa_ins_um_sg_usuario_reporte  '" & _
                                    drv.Item("usuario") & "'," & _
                                    Me.txt_cod_reporte.Text & _
                                    ",'" & drv.Item("acciones") & "','" & _
                                    drv.Item("tipo_exportar").ToString & "'"

                    li_resultado = oTrans.Ingresa(ls_sqlstring)

                Next

                otabla_permisos.DefaultView.RowFilter = ""

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub Asigno_Proceso_Reporte()

        Dim li_resultado As Integer
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        oTrans.open()
        Try
            ' Limpio la Informacion del usuarios por reporte
            ls_sql = "pa_del_um_gen_reporte_proceso " & Me.txt_cod_reporte.Text
            li_resultado = oTrans.Elimina(ls_sql)

            If oTrans.Codigo_error = 0 Then
                If Me.txt_proceso.Text.Length > 0 Then
                    ls_sql = "pa_ins_um_gen_reporte_proceso " & Me.txt_cod_reporte.Text & ",'" & _
                            Me.cmb_servidor.Text & "','" & _
                            Me.txt_proceso.Text & "'," & _
                            IIf(Me.chk_tiempo_ejecucion.CheckState = CheckState.Checked, 1, 0)

                    oTrans.Ingresa(ls_sql)
                    If oTrans.Codigo_error > 0 Then
                        MessageBox.Show(oTrans.descripcion_error)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub Eliminar_reporte()
        Dim li_resultado As Integer
        Dim ls_sqlstring As String
        Dim oTrans As New Transaccional.Conexion("flexline")

        oTrans.open()

        ' Limpio la Informacion del usuarios por reporte
        ls_sqlstring = "pa_del_um_gen_reporte " & Me.txt_cod_reporte.Text
        li_resultado = oTrans.Elimina(ls_sqlstring)
        oTrans.close()

        If oTrans.Codigo_error > 0 Then
            MessageBox.Show(oTrans.descripcion_error)
        End If

        oTrans = Nothing
        Llenar_Combos()
        Llenar_Grid()

        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub
    Private Sub btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Eliminar.Click
        Eliminar_reporte()
    End Sub

    Private Sub TabPage2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.GotFocus
        'Para que no se pueda accesar a este tab
        Me.TabControl1.SelectedTab = Me.TabPage3
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        Me.TabControl1.SelectedTab = Me.TabPage3
    End Sub

    Private Sub GroupBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.GotFocus
        Me.TabControl1.SelectedTab = Me.TabPage3
    End Sub


    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", _
                Me.txt_filtro1.Text, "", "", _
                Me.cmb_1.Text, "", "", _
                "", "")

        clsgen = Nothing
        Try
            odataset.Tables("reportes").DefaultView.RowFilter = ls_filtro
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_filtro1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If

    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub
End Class
