<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_soporte_claim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_soporte_claim))
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBU = New System.Windows.Forms.ComboBox()
        Me.btnDescargar = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnDescargarFaC = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnGenerarFaC = New System.Windows.Forms.Button()
        Me.btnMarcarFaC = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbMARCA_costo = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpFinalFaC = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicioFaC = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbBU_costo = New System.Windows.Forms.ComboBox()
        Me.dgvDocumentosFaC = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDocumentosFaC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Seleccione Destino de la Informacion"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1042, 524)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btnMarcar)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbBU)
        Me.TabPage1.Controls.Add(Me.btnDescargar)
        Me.TabPage1.Controls.Add(Me.btnPreview)
        Me.TabPage1.Controls.Add(Me.btnImprimir)
        Me.TabPage1.Controls.Add(Me.btnGenerar)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1034, 498)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Requisiciones"
        '
        'btnMarcar
        '
        Me.btnMarcar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnMarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcar.ForeColor = System.Drawing.Color.White
        Me.btnMarcar.Location = New System.Drawing.Point(2, 64)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(105, 23)
        Me.btnMarcar.TabIndex = 17
        Me.btnMarcar.Text = "Marcar/Desmarcar"
        Me.btnMarcar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbMarca)
        Me.GroupBox2.Location = New System.Drawing.Point(245, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 41)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Marca"
        '
        'cmbMarca
        '
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(9, 15)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(218, 21)
        Me.cmbMarca.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 72)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Facturacion"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(83, 41)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaFinal.TabIndex = 0
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(83, 15)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaInicio.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(251, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "BU"
        '
        'cmbBU
        '
        Me.cmbBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBU.FormattingEnabled = True
        Me.cmbBU.Location = New System.Drawing.Point(279, 5)
        Me.cmbBU.Name = "cmbBU"
        Me.cmbBU.Size = New System.Drawing.Size(170, 21)
        Me.cmbBU.TabIndex = 13
        '
        'btnDescargar
        '
        Me.btnDescargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDescargar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescargar.ForeColor = System.Drawing.Color.White
        Me.btnDescargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDescargar.ImageIndex = 1
        Me.btnDescargar.Location = New System.Drawing.Point(952, 8)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(77, 62)
        Me.btnDescargar.TabIndex = 9
        Me.btnDescargar.Text = "Descargar"
        Me.btnDescargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDescargar.UseVisualStyleBackColor = False
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.ForeColor = System.Drawing.Color.White
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreview.ImageIndex = 1
        Me.btnPreview.Location = New System.Drawing.Point(875, 8)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(77, 62)
        Me.btnPreview.TabIndex = 10
        Me.btnPreview.Text = "Vista " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.ImageIndex = 1
        Me.btnImprimir.ImageList = Me.ImageList2
        Me.btnImprimir.Location = New System.Drawing.Point(798, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(77, 62)
        Me.btnImprimir.TabIndex = 11
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerar.ImageIndex = 3
        Me.btnGenerar.ImageList = Me.ImageList2
        Me.btnGenerar.Location = New System.Drawing.Point(720, 8)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(79, 62)
        Me.btnGenerar.TabIndex = 12
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.Size = New System.Drawing.Size(1030, 407)
        Me.DataGridView1.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.btnDescargarFaC)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.btnGenerarFaC)
        Me.TabPage2.Controls.Add(Me.btnMarcarFaC)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cmbBU_costo)
        Me.TabPage2.Controls.Add(Me.dgvDocumentosFaC)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1034, 498)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Facturas al Costo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(507, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(186, 87)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "FACTURAS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AL  COSTO / " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AUTOCONSUMO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDescargarFaC
        '
        Me.btnDescargarFaC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDescargarFaC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnDescargarFaC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescargarFaC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescargarFaC.ForeColor = System.Drawing.Color.White
        Me.btnDescargarFaC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDescargarFaC.ImageIndex = 1
        Me.btnDescargarFaC.Location = New System.Drawing.Point(954, 6)
        Me.btnDescargarFaC.Name = "btnDescargarFaC"
        Me.btnDescargarFaC.Size = New System.Drawing.Size(77, 62)
        Me.btnDescargarFaC.TabIndex = 24
        Me.btnDescargarFaC.Text = "Descargar"
        Me.btnDescargarFaC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDescargarFaC.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 1
        Me.Button3.Location = New System.Drawing.Point(877, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 62)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "Vista " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.ImageIndex = 1
        Me.Button4.ImageList = Me.ImageList2
        Me.Button4.Location = New System.Drawing.Point(800, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 62)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "Imprimir"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'btnGenerarFaC
        '
        Me.btnGenerarFaC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarFaC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarFaC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarFaC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarFaC.ForeColor = System.Drawing.Color.White
        Me.btnGenerarFaC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarFaC.ImageIndex = 3
        Me.btnGenerarFaC.ImageList = Me.ImageList2
        Me.btnGenerarFaC.Location = New System.Drawing.Point(722, 6)
        Me.btnGenerarFaC.Name = "btnGenerarFaC"
        Me.btnGenerarFaC.Size = New System.Drawing.Size(79, 62)
        Me.btnGenerarFaC.TabIndex = 27
        Me.btnGenerarFaC.Text = "Generar"
        Me.btnGenerarFaC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarFaC.UseVisualStyleBackColor = False
        '
        'btnMarcarFaC
        '
        Me.btnMarcarFaC.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnMarcarFaC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcarFaC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarFaC.ForeColor = System.Drawing.Color.White
        Me.btnMarcarFaC.Location = New System.Drawing.Point(1, 69)
        Me.btnMarcarFaC.Name = "btnMarcarFaC"
        Me.btnMarcarFaC.Size = New System.Drawing.Size(105, 23)
        Me.btnMarcarFaC.TabIndex = 23
        Me.btnMarcarFaC.Text = "Marcar/Desmarcar"
        Me.btnMarcarFaC.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbMARCA_costo)
        Me.GroupBox3.Location = New System.Drawing.Point(240, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(233, 41)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Marca"
        '
        'cmbMARCA_costo
        '
        Me.cmbMARCA_costo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMARCA_costo.FormattingEnabled = True
        Me.cmbMARCA_costo.Location = New System.Drawing.Point(9, 15)
        Me.cmbMARCA_costo.Name = "cmbMARCA_costo"
        Me.cmbMARCA_costo.Size = New System.Drawing.Size(218, 21)
        Me.cmbMARCA_costo.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpFinalFaC)
        Me.GroupBox4.Controls.Add(Me.dtpInicioFaC)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(191, 72)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Facturacion"
        '
        'dtpFinalFaC
        '
        Me.dtpFinalFaC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinalFaC.Location = New System.Drawing.Point(83, 41)
        Me.dtpFinalFaC.Name = "dtpFinalFaC"
        Me.dtpFinalFaC.Size = New System.Drawing.Size(101, 20)
        Me.dtpFinalFaC.TabIndex = 0
        '
        'dtpInicioFaC
        '
        Me.dtpInicioFaC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicioFaC.Location = New System.Drawing.Point(83, 15)
        Me.dtpInicioFaC.Name = "dtpInicioFaC"
        Me.dtpInicioFaC.Size = New System.Drawing.Size(101, 20)
        Me.dtpInicioFaC.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Final"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Inicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "BU"
        '
        'cmbBU_costo
        '
        Me.cmbBU_costo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBU_costo.FormattingEnabled = True
        Me.cmbBU_costo.Location = New System.Drawing.Point(274, 9)
        Me.cmbBU_costo.Name = "cmbBU_costo"
        Me.cmbBU_costo.Size = New System.Drawing.Size(170, 21)
        Me.cmbBU_costo.TabIndex = 19
        '
        'dgvDocumentosFaC
        '
        Me.dgvDocumentosFaC.AllowUserToAddRows = False
        Me.dgvDocumentosFaC.AllowUserToDeleteRows = False
        Me.dgvDocumentosFaC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDocumentosFaC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocumentosFaC.Location = New System.Drawing.Point(1, 94)
        Me.dgvDocumentosFaC.Name = "dgvDocumentosFaC"
        Me.dgvDocumentosFaC.RowHeadersWidth = 20
        Me.dgvDocumentosFaC.Size = New System.Drawing.Size(1027, 398)
        Me.dgvDocumentosFaC.TabIndex = 18
        '
        'frm_soporte_claim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1039, 527)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_soporte_claim"
        Me.Text = ":: Soporte CLAIM ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvDocumentosFaC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnMarcar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbMarca As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbBU As ComboBox
    Friend WithEvents btnDescargar As Button
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnGenerar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents btnDescargarFaC As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btnGenerarFaC As Button
    Friend WithEvents btnMarcarFaC As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbMARCA_costo As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtpFinalFaC As DateTimePicker
    Friend WithEvents dtpInicioFaC As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbBU_costo As ComboBox
    Friend WithEvents dgvDocumentosFaC As DataGridView
End Class
