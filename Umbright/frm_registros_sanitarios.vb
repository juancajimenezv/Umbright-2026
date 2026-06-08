Imports System.IO
Public Class frm_registros_sanitarios

    Inherits System.Windows.Forms.Form
    Dim ods, ods_marca_subtipo, ods_marca_producto As New DataSet
    Dim oregistro_actual As New DataTable
    Dim registro_antiguo, registro_actual As String
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Dim p_empresa As String


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
    Friend WithEvents txt_registro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_asociar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pb_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_g As System.Windows.Forms.Label
    Friend WithEvents lbl_c As System.Windows.Forms.Label
    Friend WithEvents btn_asociar_imagen As System.Windows.Forms.Button
    Friend WithEvents lbl_glosa As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents lbl_imagen As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_vencimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtFiltroProductos As System.Windows.Forms.TextBox
    Friend WithEvents dgv_producto_marca As System.Windows.Forms.DataGridView
    Friend WithEvents ofd_ruta_imagen As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtFiltroProductos = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_imagen = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl_glosa = New System.Windows.Forms.Label
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.btn_asociar_imagen = New System.Windows.Forms.Button
        Me.lbl_g = New System.Windows.Forms.Label
        Me.lbl_c = New System.Windows.Forms.Label
        Me.pb_imagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_fecha_vencimiento = New System.Windows.Forms.TextBox
        Me.btn_asociar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_registro = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgv_producto_marca = New System.Windows.Forms.DataGridView
        Me.ofd_ruta_imagen = New System.Windows.Forms.OpenFileDialog
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.Button3 = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbEmpresa2 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_producto_marca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1072, 729)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cmbEmpresa2)
        Me.TabPage1.Controls.Add(Me.txtFiltroProductos)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgv_producto_marca)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1064, 703)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtFiltroProductos
        '
        Me.txtFiltroProductos.Location = New System.Drawing.Point(119, 142)
        Me.txtFiltroProductos.Name = "txtFiltroProductos"
        Me.txtFiltroProductos.Size = New System.Drawing.Size(360, 20)
        Me.txtFiltroProductos.TabIndex = 33
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_imagen)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lbl_glosa)
        Me.GroupBox2.Controls.Add(Me.lbl_codigo)
        Me.GroupBox2.Controls.Add(Me.btn_asociar_imagen)
        Me.GroupBox2.Controls.Add(Me.lbl_g)
        Me.GroupBox2.Controls.Add(Me.lbl_c)
        Me.GroupBox2.Controls.Add(Me.pb_imagen)
        Me.GroupBox2.Location = New System.Drawing.Point(486, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(575, 154)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion Producto"
        '
        'lbl_imagen
        '
        Me.lbl_imagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_imagen.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_imagen.Location = New System.Drawing.Point(73, 78)
        Me.lbl_imagen.Name = "lbl_imagen"
        Me.lbl_imagen.Size = New System.Drawing.Size(272, 30)
        Me.lbl_imagen.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Imagen:"
        '
        'lbl_glosa
        '
        Me.lbl_glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_glosa.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_glosa.Location = New System.Drawing.Point(73, 55)
        Me.lbl_glosa.Name = "lbl_glosa"
        Me.lbl_glosa.Size = New System.Drawing.Size(272, 27)
        Me.lbl_glosa.TabIndex = 34
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_codigo.Location = New System.Drawing.Point(73, 30)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(170, 16)
        Me.lbl_codigo.TabIndex = 33
        '
        'btn_asociar_imagen
        '
        Me.btn_asociar_imagen.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_asociar_imagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_asociar_imagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_asociar_imagen.ForeColor = System.Drawing.Color.White
        Me.btn_asociar_imagen.Location = New System.Drawing.Point(494, 30)
        Me.btn_asociar_imagen.Name = "btn_asociar_imagen"
        Me.btn_asociar_imagen.Size = New System.Drawing.Size(75, 23)
        Me.btn_asociar_imagen.TabIndex = 32
        Me.btn_asociar_imagen.Text = "Asociar "
        Me.btn_asociar_imagen.UseVisualStyleBackColor = False
        '
        'lbl_g
        '
        Me.lbl_g.Location = New System.Drawing.Point(17, 55)
        Me.lbl_g.Name = "lbl_g"
        Me.lbl_g.Size = New System.Drawing.Size(37, 16)
        Me.lbl_g.TabIndex = 31
        Me.lbl_g.Text = "Glosa:"
        '
        'lbl_c
        '
        Me.lbl_c.Location = New System.Drawing.Point(17, 30)
        Me.lbl_c.Name = "lbl_c"
        Me.lbl_c.Size = New System.Drawing.Size(50, 16)
        Me.lbl_c.TabIndex = 30
        Me.lbl_c.Text = "Codigo:"
        '
        'pb_imagen
        '
        Me.pb_imagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_imagen.Location = New System.Drawing.Point(351, 8)
        Me.pb_imagen.Name = "pb_imagen"
        Me.pb_imagen.Size = New System.Drawing.Size(120, 140)
        Me.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_imagen.TabIndex = 29
        Me.pb_imagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_vencimiento)
        Me.GroupBox1.Controls.Add(Me.btn_asociar)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.txt_registro)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 112)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'dtp_fecha_vencimiento
        '
        Me.dtp_fecha_vencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtp_fecha_vencimiento.Location = New System.Drawing.Point(210, 47)
        Me.dtp_fecha_vencimiento.Name = "dtp_fecha_vencimiento"
        Me.dtp_fecha_vencimiento.Size = New System.Drawing.Size(100, 20)
        Me.dtp_fecha_vencimiento.TabIndex = 7
        '
        'btn_asociar
        '
        Me.btn_asociar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_asociar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_asociar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_asociar.ForeColor = System.Drawing.Color.White
        Me.btn_asociar.Location = New System.Drawing.Point(375, 18)
        Me.btn_asociar.Name = "btn_asociar"
        Me.btn_asociar.Size = New System.Drawing.Size(75, 23)
        Me.btn_asociar.TabIndex = 5
        Me.btn_asociar.Text = "Asociar "
        Me.btn_asociar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.Location = New System.Drawing.Point(375, 55)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 6
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'txt_registro
        '
        Me.txt_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_registro.Location = New System.Drawing.Point(210, 23)
        Me.txt_registro.Name = "txt_registro"
        Me.txt_registro.Size = New System.Drawing.Size(100, 20)
        Me.txt_registro.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Numero de Registro"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha Vencimiento Registro"
        '
        'dgv_producto_marca
        '
        Me.dgv_producto_marca.AllowUserToAddRows = False
        Me.dgv_producto_marca.AllowUserToDeleteRows = False
        Me.dgv_producto_marca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_producto_marca.Location = New System.Drawing.Point(3, 163)
        Me.dgv_producto_marca.Name = "dgv_producto_marca"
        Me.dgv_producto_marca.RowHeadersWidth = 25
        Me.dgv_producto_marca.Size = New System.Drawing.Size(1058, 508)
        Me.dgv_producto_marca.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Empresa"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(11, 51)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(1050, 633)
        Me.DataGridView1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(264, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(104, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Empresa"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(11, 51)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.Size = New System.Drawing.Size(1050, 633)
        Me.DataGridView2.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(264, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Generar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(104, 8)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox2.TabIndex = 1
        Me.ComboBox2.Text = "ComboBox1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Empresa"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(11, 51)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersWidth = 25
        Me.DataGridView3.Size = New System.Drawing.Size(1050, 633)
        Me.DataGridView3.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(264, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Generar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(104, 8)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox3.TabIndex = 1
        Me.ComboBox3.Text = "ComboBox1"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Empresa"
        '
        'cmbEmpresa2
        '
        Me.cmbEmpresa2.Location = New System.Drawing.Point(119, 118)
        Me.cmbEmpresa2.Name = "cmbEmpresa2"
        Me.cmbEmpresa2.Size = New System.Drawing.Size(136, 21)
        Me.cmbEmpresa2.TabIndex = 34
        Me.cmbEmpresa2.Text = "ComboBox1"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Glosa"
        '
        'frm_registros_sanitarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1080, 742)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_registros_sanitarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Registro Sanitario"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_producto_marca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Crear_Estructura()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("marcas_subtipos")
        'ods_marca_subtipo = New DataSet

        dt1.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt1.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt1.Columns.Add(New DataColumn("Subtipo", GetType(String)))

        ods_marca_subtipo.Tables.Add(dt1)
        ' Me.dgv_listado_marcas.DataSource = ods_marca_subtipo.Tables("marcas_subtipos")

    End Sub

    Private Sub Crear_Estructura_()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("marcas_productos")
        'ods_marca_subtipo = New DataSet

        dt1.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt1.Columns.Add(New DataColumn("Codigo", GetType(String)))
        dt1.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt1.Columns.Add(New DataColumn("Registro_Sanitario", GetType(String)))
        dt1.Columns.Add(New DataColumn("Fecha_vencimiento", GetType(String)))
        dt1.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt1.Columns.Add(New DataColumn("Subtipo", GetType(String)))
        dt1.Columns.Add(New DataColumn("Imagen", GetType(String)))

        ods_marca_producto.Tables.Add(dt1)
        Me.dgv_producto_marca.DataSource = ods_marca_producto.Tables("marcas_productos")






        '-------------


        'Dim dc, dc3 As New ClasesGenerales.CalendarColumn
        'dc3.Name = "Fecha_vencimiento"
        'dc3.DataPropertyName = "Fecha_vencimiento"

        'ClsGen.Alinear_GridViewCalendar(dc3)
        'ClsGen.Alinear_GridView(ods_marca_producto.Tables("marcas_productos"), Me.dgv_producto_marca, ",Empresa,Codigo,Glosa,Registro_Sanitario,Fecha_vencimiento,Marca,Subtipo,", "", "", "", "", "", "", True, True, 250, 0)
        '-------------

    End Sub
    Private Sub Llenar_Combo()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion_mysql("onBase")

        Try
            Otrans.open()
            ls_sql = "call pa_sel_um_pg_empresa ()"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pg_empresas"

            Me.cmbEmpresa2.DataSource = dt
            Me.cmbEmpresa2.ValueMember = "cod_empresa"
            Me.cmbEmpresa2.DisplayMember = "descripcion"

            ods.Tables.Add(dt.Copy)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    'Private Sub Llenar_Grid_Marcas()

    '    Dim ls_sql As String

    '    Dim dt As DataTable
    '    Dim dr2, dr_aux As DataRow

    '    Dim oTrans As New Transaccional.Conexion("FlexLine")
    '    Dim ClsGen As New ClasesGenerales.General

    '    Try
    '        ods_marca_subtipo.Tables("marcas_subtipos").Rows.Clear()
    '        oTrans.open()
    '        ls_sql = "pa_var_um_producto_marca_subtipo '" & Me.cmb_empresa.Text & "'"
    '        dt = oTrans.Obtiene(ls_sql)


    '        'dg_listado_marcas.DataSource = dt
    '        'dgv_listado_marcas.DataSource = dt

    '        ' ods.Tables.Add(dt.Copy)



    '        For Each dr2 In dt.Rows

    '            dr_aux = ods_marca_subtipo.Tables("marcas_subtipos").NewRow
    '            dr_aux.Item("Empresa") = dr2.Item("empresa")
    '            dr_aux.Item("Marca") = dr2.Item("tipo")
    '            dr_aux.Item("Subtipo") = dr2.Item("subtipo")
    '            ods_marca_subtipo.Tables("marcas_subtipos").Rows.Add(dr_aux)
    '        Next
    '        ClsGen.Alinear_GridView(ods_marca_subtipo.Tables("marcas_subtipos"), Me.dgv_listado_marcas, ",Empresa,Marca,Subtipo,", "", ",Empresa,", "", "", ",Empresa=75,Marca=150,Subtipo=300,", "", True, True, 250, 0)

    '        ' ClsGen.Alinear_GridView(ods_marca_subtipo.Tables("marcas_subtipos"), Me.dgv_listado_marcas, ",Empresa,Marca,Subtipo", "", "", "", "", ",Empresa=75,Marca=100,Subtipo=100,", "", True, True, 200, 0)
    '        'ClsGen.Alinear_GridView(ods1.Tables("control"), Me.dgv_control, ",Descripcion,Aplica,Lo tiene,Comentario,", "", ",Descripcion,", "", "", ",Descripcion=250,Aplica=50,Lo tiene=70,Comentario=450,", "", True, True, 200, 0)




    '    Catch ex As Exception
    '    Finally
    '        oTrans.close()
    '        oTrans = Nothing
    '        ClsGen = Nothing
    '    End Try

    'End Sub

    Private Sub Llenar_Productos_Marca(ByVal pempresa As String, ByVal pcod_marca As String, ByVal pcod_subtipo As String)


        Dim ls_sql, ls_sql1 As String
        Dim dt, dt1 As DataTable
        Dim dr2, dr_aux As DataRow

        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim sotrans As New Transaccional.Conexion("scm")
        Dim ClsGen As New ClasesGenerales.General
        p_empresa = pempresa


        Try
            ods_marca_producto.Tables("marcas_productos").Rows.Clear()
            oregistro_actual.Rows.Clear()

            Otrans.open()
            sotrans.open()

            's_sql = "pa_var_um_producto_subtipo '" & pempresa & "','" & pcod_marca.ToString & "','" & pcod_subtipo.ToString & "'"
            ls_sql = "pa_var_um_producto_subtipo '" & pempresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "glosa like '%" & Me.txtFiltroProductos.Text & "%'"
            registro_actual = "v_000.png"


            Try
                Me.pb_imagen.Image = Image.FromFile("\\" & ClsGen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)
            Catch ex As Exception
            End Try

            Try

                For Each drv As DataRowView In dt.DefaultView
                    dr_aux = ods_marca_producto.Tables("marcas_productos").NewRow
                    dr_aux.Item("Empresa") = drv.Item("empresa")
                    dr_aux.Item("Codigo") = drv.Item("producto")
                    dr_aux.Item("Glosa") = drv.Item("glosa")
                    dr_aux.Item("Registro_Sanitario") = drv.Item("analisisproducto12")
                    dr_aux.Item("Fecha_vencimiento") = drv.Item("Analisisproducto13")
                    dr_aux.Item("Marca") = drv.Item("tipo")
                    dr_aux.Item("Subtipo") = drv.Item("subtipo")
                    If drv.Item("ruta").ToString.Length > 0 Then
                        dr_aux.Item("Imagen") = drv.Item("ruta")
                    Else
                        dr_aux.Item("Imagen") = ""

                    End If
                    ods_marca_producto.Tables("marcas_productos").Rows.Add(dr_aux)
                Next
            Catch ex As Exception
            End Try
            ClsGen.Alinear_GridView(ods_marca_producto.Tables("marcas_productos"), Me.dgv_producto_marca, ",Empresa,Codigo,Glosa,Registro_Sanitario,Fecha_vencimiento,Marca,Subtipo,Imagen,", ",Empresa,", ",Empresa,Codigo,Glosa,Marca,Subtipo,", "", "", ",Codigo=70,Glosa=275,Registro_Sanitario=80,Fecha_vencimiento=80,Marca=150,Subtipo=150,Imagen=150,", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            sotrans.close()
            sotrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Hacer_Asociacion(ByVal tipo As String)
        Dim dr As DataRow

        If tipo = "registro_fecha" Then
            For Each dr In ods_marca_producto.Tables("marcas_productos").Rows
                dr.Item("Registro_Sanitario") = Me.txt_registro.Text
                dr.Item("Fecha_vencimiento") = Me.dtp_fecha_vencimiento.Text
            Next
        ElseIf tipo = "imagenes" Then
            For Each dr In ods_marca_producto.Tables("marcas_productos").Rows
                dr.Item("Imagen") = Me.lbl_imagen.Text
            Next
        End If

    End Sub

    Private Sub Guardar_Registro()
        Dim ls_sql, ls_sql1 As String
        Dim dr As DataRow
        Dim dt, dt1 As DataTable


        Dim fecha_vencimiento As String
        Dim fechaarray(3) As String
        Dim otrans As New Transaccional.Conexion("Flexline")
        Dim sotrans As New Transaccional.Conexion("scm")

        Try
            otrans.open()
            sotrans.open()
            For Each dr In ods_marca_producto.Tables("marcas_productos").Rows 'ods.Tables("productos_marca_subtipo").Rows

                If dr.Item("Registro_Sanitario").ToString.Length > 0 Then


                    ls_sql = "pa_upd_um_producto_registro_sanitario '" & _
                            dr.Item("Codigo") & "','" & _
                           dr.Item("Registro_Sanitario") & "','" & _
                         dr.Item("Fecha_vencimiento") & "','" & _
                         gs_usuario & "'"

                    otrans.Actualiza(ls_sql)

                    If otrans.Codigo_error > 0 Then
                        MessageBox.Show(otrans.descripcion_error)
                    End If
                End If
                '''

                ls_sql1 = "pa_var_um_inv_producto '" & p_empresa & "','" & dr.Item("Codigo") & "'"
                dt1 = sotrans.Obtiene(ls_sql1)


                If dt1.Rows.Count > 0 Then
                    'UNICAMENTE ACTUALIZA
                    If registro_actual <> registro_antiguo Then
                        ls_sql = "pa_upd_um_inv_producto_ruta '" & _
                         dr.Item("Imagen") & "','" & _
                      dr.Item("Codigo") & "'"

                        sotrans.Actualiza(ls_sql)

                        If sotrans.Codigo_error > 0 Then
                            MessageBox.Show(sotrans.descripcion_error)
                        End If
                    End If


                Else
                    'INGRESA PRODUCTO NUEVO



                    ls_sql1 = "pa_ins_um_inv_productoImagen '" & p_empresa & "','" & dr.Item("Codigo") & "'" & _
                            ",NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,'" & dr.Item("Imagen") & "'"
                    sotrans.Ingresa(ls_sql1)

                End If
                ''''
            Next



            MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            sotrans.close()
            sotrans = Nothing
        End Try


    End Sub


    Private Sub frm_registros_sanitarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combo()
        Crear_Estructura()
        Crear_Estructura_()
    End Sub


    Private Sub btn_asociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_asociar.Click
        Hacer_Asociacion("registro_fecha")
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro De Actualizar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Guardar_Registro()
        End If
    End Sub




    Private Sub limpiar_campos_imagen()
        Me.lbl_codigo.Text = ""
        Me.lbl_glosa.Text = ""
        Me.lbl_imagen.Text = ""
        registro_actual = "v_000.png"
        Try
            Dim clsGen As New ClasesGenerales.General
            Me.pb_imagen.Image = Image.FromFile("\\" & clsGen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)

            clsGen = Nothing
        Catch ex As Exception
        Finally


        End Try

    End Sub
    Private Sub pb_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_imagen.Click
        Try
            Dim clsGen As New ClasesGenerales.General
            Dim path_ As String
            path_ = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text

            'ofd_ruta_imagen.Filter = "png|*.png"
            ofd_ruta_imagen.InitialDirectory = path_ '"\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza"
            ofd_ruta_imagen.ShowDialog()
            Dim finfo As New FileInfo(ofd_ruta_imagen.FileName)

            If registro_actual <> finfo.Name Then
                If MessageBox.Show("Esta Seguro de Cambiar la Imagen Asociada", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    registro_actual = finfo.Name
                    Me.lbl_imagen.Text = finfo.Name

                    Dim nRow As Integer
                    nRow = Me.dgv_producto_marca.CurrentCell.RowIndex
                    Me.dgv_producto_marca.Item(7, nRow).Value = finfo.Name
                    Try
                        ' Me.pb_imagen.Image = Image.FromFile("\\onbase\tools$\images\Registros Sanitarios\" & finfo.Name)
                        Me.pb_imagen.Image = Image.FromFile("\\" & clsGen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)
                    Catch ex As Exception
                    End Try

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub



    Private Sub btn_asociar_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_asociar_imagen.Click
        If MessageBox.Show("Esta Seguro de Asociar la Imagen a los Registros", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Hacer_Asociacion("imagenes")
        End If
    End Sub

    Private Sub dgv_producto_marca_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_producto_marca.CurrentCellChanged
        Dim nRow As Integer
        Dim clsgen As New ClasesGenerales.General

        Try
            nRow = Me.dgv_producto_marca.CurrentCell.RowIndex
            Me.lbl_codigo.Text = Me.dgv_producto_marca.Item(1, nRow).Value.ToString
            Me.lbl_glosa.Text = Me.dgv_producto_marca.Item(2, nRow).Value.ToString

            Me.registro_actual = "v_000.png"
            Me.lbl_imagen.Text = ""

            Try
                Me.pb_imagen.Image = Image.FromFile("\\" & clsgen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)

            Catch ex As Exception
            End Try

            If Me.dgv_producto_marca.Item(7, nRow).Value.ToString = "" Then
                Me.registro_actual = "v_000.png"
                Me.lbl_imagen.Text = ""
            Else
                Me.lbl_imagen.Text = Me.dgv_producto_marca.Item(7, nRow).Value.ToString
                Me.registro_actual = Me.dgv_producto_marca.Item(7, nRow).Value.ToString
            End If

            Try
                '  Me.pb_imagen.Image = Image.FromFile("\\onbase\tools$\images\Registros Sanitarios\" & Me.registro_actual)
                'Me.pb_imagen.Image = Image.FromFile("\\onbase\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)
                Me.pb_imagen.Image = Image.FromFile("\\" & clsgen.Obtener_XMLConfig("servidor_alterno_gt", False) & "\tools$\images\Registros Sanitarios\" & Me.cmbEmpresa2.Text & "\" & Me.registro_actual)

            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgv_listado_marcas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_producto_marca_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_producto_marca.CellContentClick

    End Sub

    Private Sub txtFiltroProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltroProductos.KeyPress
        If e.KeyChar = Chr(13) Then

            Llenar_Productos_Marca(Me.cmbEmpresa2.Text, "", "")

            limpiar_campos_imagen()
        End If

    End Sub

    Private Sub txtFiltroProductos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroProductos.TextChanged

    End Sub
End Class
