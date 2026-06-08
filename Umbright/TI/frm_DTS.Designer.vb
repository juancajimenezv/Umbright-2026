<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_DTS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmr_Comparar = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Grid_Tablas_Origen = New System.Windows.Forms.DataGridView()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TConnectionStringBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TConnectionStringBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.chkintegridad = New System.Windows.Forms.CheckBox()
        Me.lblcolumns = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TdbBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.CboDestino = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MostrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTop = New System.Windows.Forms.ToolStripComboBox()
        Me.RegistrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Grid_Vista_Destino = New System.Windows.Forms.DataGridView()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lbltotalregistrosdestino = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Grid_vista_Origen = New System.Windows.Forms.DataGridView()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbltotalregistrosorigen = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboHojasDestino = New System.Windows.Forms.ComboBox()
        Me.LblTotalColumnas2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboHojas = New System.Windows.Forms.ComboBox()
        Me.lblTotalColumnas1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Grid_Tablas_destino = New System.Windows.Forms.DataGridView()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TdbBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3.SuspendLayout()
        CType(Me.Grid_Tablas_Origen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TConnectionStringBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TConnectionStringBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        CType(Me.TdbBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.Grid_Vista_Destino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Grid_vista_Origen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Grid_Tablas_destino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.TdbBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmr_Comparar
        '
        Me.tmr_Comparar.Enabled = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Grid_Tablas_Origen)
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(5, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(642, 198)
        Me.Panel3.TabIndex = 2
        '
        'Grid_Tablas_Origen
        '
        Me.Grid_Tablas_Origen.AllowUserToAddRows = False
        Me.Grid_Tablas_Origen.AllowUserToDeleteRows = False
        Me.Grid_Tablas_Origen.AllowUserToResizeColumns = False
        Me.Grid_Tablas_Origen.AllowUserToResizeRows = False
        Me.Grid_Tablas_Origen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grid_Tablas_Origen.BackgroundColor = System.Drawing.Color.White
        Me.Grid_Tablas_Origen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_Tablas_Origen.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid_Tablas_Origen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Tablas_Origen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Tablas_Origen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid_Tablas_Origen.Location = New System.Drawing.Point(0, 31)
        Me.Grid_Tablas_Origen.Name = "Grid_Tablas_Origen"
        Me.Grid_Tablas_Origen.RowHeadersVisible = False
        Me.Grid_Tablas_Origen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid_Tablas_Origen.Size = New System.Drawing.Size(642, 167)
        Me.Grid_Tablas_Origen.TabIndex = 1
        Me.Grid_Tablas_Origen.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Button1)
        Me.Panel9.Controls.Add(Me.CboOrigen)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.ForeColor = System.Drawing.Color.White
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(642, 31)
        Me.Panel9.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(337, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cargar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CboOrigen
        '
        Me.CboOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboOrigen.DisplayMember = "StringConnection"
        Me.CboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboOrigen.FormattingEnabled = True
        Me.CboOrigen.Items.AddRange(New Object() {"Excel"})
        Me.CboOrigen.Location = New System.Drawing.Point(70, 4)
        Me.CboOrigen.Name = "CboOrigen"
        Me.CboOrigen.Size = New System.Drawing.Size(254, 21)
        Me.CboOrigen.TabIndex = 1
        Me.CboOrigen.ValueMember = "StringConnection"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(10, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Origen :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(655, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(643, 21)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(643, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Destino de Datos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 21)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(642, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origen de Datos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TConnectionStringBindingSource1
        '
        Me.TConnectionStringBindingSource1.DataMember = "tConnectionString"
        '
        'TConnectionStringBindingSource
        '
        Me.TConnectionStringBindingSource.DataMember = "tConnectionString"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel13.Controls.Add(Me.Button7)
        Me.Panel13.Controls.Add(Me.chkintegridad)
        Me.Panel13.Controls.Add(Me.lblcolumns)
        Me.Panel13.Controls.Add(Me.Button6)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(1303, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(130, 612)
        Me.Panel13.TabIndex = 6
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(5, 7)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(122, 60)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Ejecutar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'chkintegridad
        '
        Me.chkintegridad.AutoSize = True
        Me.chkintegridad.Enabled = False
        Me.chkintegridad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkintegridad.Location = New System.Drawing.Point(10, 175)
        Me.chkintegridad.Name = "chkintegridad"
        Me.chkintegridad.Size = New System.Drawing.Size(73, 17)
        Me.chkintegridad.TabIndex = 5
        Me.chkintegridad.Text = "Integridad"
        Me.chkintegridad.UseVisualStyleBackColor = True
        '
        'lblcolumns
        '
        Me.lblcolumns.AutoSize = True
        Me.lblcolumns.Enabled = False
        Me.lblcolumns.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblcolumns.Location = New System.Drawing.Point(10, 152)
        Me.lblcolumns.Name = "lblcolumns"
        Me.lblcolumns.Size = New System.Drawing.Size(72, 17)
        Me.lblcolumns.TabIndex = 4
        Me.lblcolumns.Text = "Columnas"
        Me.lblcolumns.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(5, 73)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(122, 60)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "Salir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = False
        '
        'TdbBindingSource1
        '
        Me.TdbBindingSource1.DataMember = "t_db"
        '
        'CboDestino
        '
        Me.CboDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboDestino.DisplayMember = "StringConnection"
        Me.CboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDestino.FormattingEnabled = True
        Me.CboDestino.Items.AddRange(New Object() {"DWH", "SCM"})
        Me.CboDestino.Location = New System.Drawing.Point(75, 5)
        Me.CboDestino.Name = "CboDestino"
        Me.CboDestino.Size = New System.Drawing.Size(263, 21)
        Me.CboDestino.TabIndex = 6
        Me.CboDestino.ValueMember = "StringConnection"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarToolStripMenuItem, Me.ToolTop, Me.RegistrosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1303, 44)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MostrarToolStripMenuItem
        '
        Me.MostrarToolStripMenuItem.Enabled = False
        Me.MostrarToolStripMenuItem.Name = "MostrarToolStripMenuItem"
        Me.MostrarToolStripMenuItem.Size = New System.Drawing.Size(60, 40)
        Me.MostrarToolStripMenuItem.Text = "Mostrar"
        '
        'ToolTop
        '
        Me.ToolTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolTop.Items.AddRange(New Object() {"1000", "5000", "10000", "Todos"})
        Me.ToolTop.Name = "ToolTop"
        Me.ToolTop.Size = New System.Drawing.Size(121, 40)
        '
        'RegistrosToolStripMenuItem
        '
        Me.RegistrosToolStripMenuItem.Enabled = False
        Me.RegistrosToolStripMenuItem.Name = "RegistrosToolStripMenuItem"
        Me.RegistrosToolStripMenuItem.Size = New System.Drawing.Size(67, 40)
        Me.RegistrosToolStripMenuItem.Text = "Registros"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.75497!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.615894!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.82782!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1303, 568)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Grid_Vista_Destino)
        Me.Panel8.Controls.Add(Me.Panel12)
        Me.Panel8.Controls.Add(Me.lbltotalregistrosdestino)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(655, 284)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(643, 279)
        Me.Panel8.TabIndex = 7
        '
        'Grid_Vista_Destino
        '
        Me.Grid_Vista_Destino.AllowUserToAddRows = False
        Me.Grid_Vista_Destino.AllowUserToDeleteRows = False
        Me.Grid_Vista_Destino.AllowUserToResizeColumns = False
        Me.Grid_Vista_Destino.AllowUserToResizeRows = False
        Me.Grid_Vista_Destino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grid_Vista_Destino.BackgroundColor = System.Drawing.Color.White
        Me.Grid_Vista_Destino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_Vista_Destino.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid_Vista_Destino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Vista_Destino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Vista_Destino.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid_Vista_Destino.Location = New System.Drawing.Point(0, 31)
        Me.Grid_Vista_Destino.MultiSelect = False
        Me.Grid_Vista_Destino.Name = "Grid_Vista_Destino"
        Me.Grid_Vista_Destino.RowHeadersVisible = False
        Me.Grid_Vista_Destino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid_Vista_Destino.Size = New System.Drawing.Size(643, 235)
        Me.Grid_Vista_Destino.TabIndex = 2
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel12.Controls.Add(Me.TextBox2)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(643, 31)
        Me.Panel12.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(11, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(621, 20)
        Me.TextBox2.TabIndex = 1
        '
        'lbltotalregistrosdestino
        '
        Me.lbltotalregistrosdestino.BackColor = System.Drawing.Color.Khaki
        Me.lbltotalregistrosdestino.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbltotalregistrosdestino.Location = New System.Drawing.Point(0, 266)
        Me.lbltotalregistrosdestino.Name = "lbltotalregistrosdestino"
        Me.lbltotalregistrosdestino.Size = New System.Drawing.Size(643, 13)
        Me.lbltotalregistrosdestino.TabIndex = 4
        Me.lbltotalregistrosdestino.Text = "Listo"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Grid_vista_Origen)
        Me.Panel7.Controls.Add(Me.Panel11)
        Me.Panel7.Controls.Add(Me.lbltotalregistrosorigen)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(5, 284)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(642, 279)
        Me.Panel7.TabIndex = 6
        '
        'Grid_vista_Origen
        '
        Me.Grid_vista_Origen.AllowUserToAddRows = False
        Me.Grid_vista_Origen.AllowUserToDeleteRows = False
        Me.Grid_vista_Origen.AllowUserToResizeColumns = False
        Me.Grid_vista_Origen.AllowUserToResizeRows = False
        Me.Grid_vista_Origen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grid_vista_Origen.BackgroundColor = System.Drawing.Color.White
        Me.Grid_vista_Origen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_vista_Origen.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid_vista_Origen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_vista_Origen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_vista_Origen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid_vista_Origen.Location = New System.Drawing.Point(0, 31)
        Me.Grid_vista_Origen.MultiSelect = False
        Me.Grid_vista_Origen.Name = "Grid_vista_Origen"
        Me.Grid_vista_Origen.RowHeadersVisible = False
        Me.Grid_vista_Origen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid_vista_Origen.Size = New System.Drawing.Size(642, 235)
        Me.Grid_vista_Origen.TabIndex = 2
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Controls.Add(Me.TextBox1)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(642, 31)
        Me.Panel11.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(8, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(621, 20)
        Me.TextBox1.TabIndex = 0
        '
        'lbltotalregistrosorigen
        '
        Me.lbltotalregistrosorigen.BackColor = System.Drawing.Color.Khaki
        Me.lbltotalregistrosorigen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbltotalregistrosorigen.Location = New System.Drawing.Point(0, 266)
        Me.lbltotalregistrosorigen.Name = "lbltotalregistrosorigen"
        Me.lbltotalregistrosorigen.Size = New System.Drawing.Size(642, 13)
        Me.lbltotalregistrosorigen.TabIndex = 3
        Me.lbltotalregistrosorigen.Text = "Listo"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.cboHojasDestino)
        Me.Panel6.Controls.Add(Me.LblTotalColumnas2)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(655, 240)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(643, 36)
        Me.Panel6.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(7, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Seleccionar Hoja :"
        '
        'cboHojasDestino
        '
        Me.cboHojasDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboHojasDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboHojasDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHojasDestino.FormattingEnabled = True
        Me.cboHojasDestino.Location = New System.Drawing.Point(107, 15)
        Me.cboHojasDestino.Name = "cboHojasDestino"
        Me.cboHojasDestino.Size = New System.Drawing.Size(525, 21)
        Me.cboHojasDestino.TabIndex = 5
        '
        'LblTotalColumnas2
        '
        Me.LblTotalColumnas2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotalColumnas2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LblTotalColumnas2.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalColumnas2.Location = New System.Drawing.Point(507, 1)
        Me.LblTotalColumnas2.Name = "LblTotalColumnas2"
        Me.LblTotalColumnas2.Size = New System.Drawing.Size(136, 18)
        Me.LblTotalColumnas2.TabIndex = 3
        Me.LblTotalColumnas2.Text = "Columnas"
        Me.LblTotalColumnas2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(643, 36)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Vista Previa Destino"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.cboHojas)
        Me.Panel5.Controls.Add(Me.lblTotalColumnas1)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(5, 240)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(642, 36)
        Me.Panel5.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(5, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Seleccionar Hoja :"
        '
        'cboHojas
        '
        Me.cboHojas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboHojas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboHojas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHojas.FormattingEnabled = True
        Me.cboHojas.Location = New System.Drawing.Point(99, 14)
        Me.cboHojas.Name = "cboHojas"
        Me.cboHojas.Size = New System.Drawing.Size(530, 21)
        Me.cboHojas.TabIndex = 3
        '
        'lblTotalColumnas1
        '
        Me.lblTotalColumnas1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalColumnas1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lblTotalColumnas1.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalColumnas1.Location = New System.Drawing.Point(503, -2)
        Me.lblTotalColumnas1.Name = "lblTotalColumnas1"
        Me.lblTotalColumnas1.Size = New System.Drawing.Size(136, 18)
        Me.lblTotalColumnas1.TabIndex = 2
        Me.lblTotalColumnas1.Text = "Columnas :"
        Me.lblTotalColumnas1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(642, 36)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vista Previa Origen"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Grid_Tablas_destino)
        Me.Panel4.Controls.Add(Me.Panel10)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(655, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(643, 198)
        Me.Panel4.TabIndex = 3
        '
        'Grid_Tablas_destino
        '
        Me.Grid_Tablas_destino.AllowUserToAddRows = False
        Me.Grid_Tablas_destino.AllowUserToDeleteRows = False
        Me.Grid_Tablas_destino.AllowUserToResizeColumns = False
        Me.Grid_Tablas_destino.AllowUserToResizeRows = False
        Me.Grid_Tablas_destino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grid_Tablas_destino.BackgroundColor = System.Drawing.Color.White
        Me.Grid_Tablas_destino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_Tablas_destino.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid_Tablas_destino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Tablas_destino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Tablas_destino.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid_Tablas_destino.Location = New System.Drawing.Point(0, 31)
        Me.Grid_Tablas_destino.Name = "Grid_Tablas_destino"
        Me.Grid_Tablas_destino.RowHeadersVisible = False
        Me.Grid_Tablas_destino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid_Tablas_destino.Size = New System.Drawing.Size(643, 167)
        Me.Grid_Tablas_destino.TabIndex = 2
        Me.Grid_Tablas_destino.TabStop = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel10.Controls.Add(Me.CboDestino)
        Me.Panel10.Controls.Add(Me.Button2)
        Me.Panel10.Controls.Add(Me.Label6)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.ForeColor = System.Drawing.Color.White
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(643, 31)
        Me.Panel10.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(347, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 24)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cargar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(20, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Destino :"
        '
        'frm_DTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1433, 612)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel13)
        Me.Name = "frm_DTS"
        Me.Text = "::.  DTS  .::"
        Me.Panel3.ResumeLayout(False)
        CType(Me.Grid_Tablas_Origen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.TConnectionStringBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TConnectionStringBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        CType(Me.TdbBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.Grid_Vista_Destino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.Grid_vista_Origen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.Grid_Tablas_destino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.TdbBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tmr_Comparar As Windows.Forms.Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Grid_Tablas_Origen As DataGridView
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents CboOrigen As ComboBox
    Friend WithEvents TdbBindingSource As BindingSource
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TConnectionStringBindingSource1 As BindingSource
    Friend WithEvents TConnectionStringBindingSource As BindingSource
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Button7 As Button
    Friend WithEvents chkintegridad As CheckBox
    Friend WithEvents lblcolumns As CheckBox
    Friend WithEvents Button6 As Button
    Friend WithEvents TdbBindingSource1 As BindingSource
    Friend WithEvents CboDestino As ComboBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MostrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTop As ToolStripComboBox
    Friend WithEvents RegistrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Grid_Vista_Destino As DataGridView
    Friend WithEvents Panel12 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents lbltotalregistrosdestino As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Grid_vista_Origen As DataGridView
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbltotalregistrosorigen As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents cboHojasDestino As ComboBox
    Friend WithEvents LblTotalColumnas2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents cboHojas As ComboBox
    Friend WithEvents lblTotalColumnas1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Grid_Tablas_destino As DataGridView
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
End Class
