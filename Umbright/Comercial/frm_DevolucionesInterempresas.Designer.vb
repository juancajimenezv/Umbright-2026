<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DevolucionesInterempresas
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_DevolucionesInterempresas))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvBU = New System.Windows.Forms.DataGridView()
        Me.btnProcesarDevolucion = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGenerarInformacion = New System.Windows.Forms.Button()
        Me.dgvExistencias = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvProductosDevolucionDetalle = New System.Windows.Forms.DataGridView()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.dgvProductosDevolucion = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.dgvDevolucionesPendientes = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnImprimirMovimientoFlexLine = New System.Windows.Forms.Button()
        Me.btnImprimirImpresiones = New System.Windows.Forms.Button()
        Me.btnRefrescarImpresiones = New System.Windows.Forms.Button()
        Me.dgvDevolucionMovimientoFlexLine = New System.Windows.Forms.DataGridView()
        Me.dgvDevolucionesImprimir = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvBU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProductosDevolucionDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductosDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDevolucionesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvDevolucionMovimientoFlexLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDevolucionesImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(944, 455)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.dgvBU)
        Me.TabPage1.Controls.Add(Me.btnProcesarDevolucion)
        Me.TabPage1.Controls.Add(Me.btnGenerarInformacion)
        Me.TabPage1.Controls.Add(Me.dgvExistencias)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(936, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Solicitud"
        '
        'dgvBU
        '
        Me.dgvBU.AllowUserToAddRows = False
        Me.dgvBU.AllowUserToDeleteRows = False
        Me.dgvBU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBU.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBU.Location = New System.Drawing.Point(640, 86)
        Me.dgvBU.Name = "dgvBU"
        Me.dgvBU.RowHeadersWidth = 20
        Me.dgvBU.Size = New System.Drawing.Size(293, 335)
        Me.dgvBU.TabIndex = 1
        '
        'btnProcesarDevolucion
        '
        Me.btnProcesarDevolucion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesarDevolucion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesarDevolucion.ForeColor = System.Drawing.Color.White
        Me.btnProcesarDevolucion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarDevolucion.ImageIndex = 3
        Me.btnProcesarDevolucion.ImageList = Me.ImageList1
        Me.btnProcesarDevolucion.Location = New System.Drawing.Point(757, 18)
        Me.btnProcesarDevolucion.Name = "btnProcesarDevolucion"
        Me.btnProcesarDevolucion.Size = New System.Drawing.Size(75, 62)
        Me.btnProcesarDevolucion.TabIndex = 1
        Me.btnProcesarDevolucion.Text = "Procesar"
        Me.btnProcesarDevolucion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesarDevolucion.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "printer_48.png")
        Me.ImageList1.Images.SetKeyName(1, "Actualizar.png")
        Me.ImageList1.Images.SetKeyName(2, "Actualizar_Blue.png")
        Me.ImageList1.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(4, "refresh.jpg")
        '
        'btnGenerarInformacion
        '
        Me.btnGenerarInformacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerarInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarInformacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarInformacion.ForeColor = System.Drawing.Color.White
        Me.btnGenerarInformacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerarInformacion.ImageIndex = 4
        Me.btnGenerarInformacion.ImageList = Me.ImageList1
        Me.btnGenerarInformacion.Location = New System.Drawing.Point(268, 18)
        Me.btnGenerarInformacion.Name = "btnGenerarInformacion"
        Me.btnGenerarInformacion.Size = New System.Drawing.Size(75, 62)
        Me.btnGenerarInformacion.TabIndex = 1
        Me.btnGenerarInformacion.Text = "Generar"
        Me.btnGenerarInformacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerarInformacion.UseVisualStyleBackColor = False
        '
        'dgvExistencias
        '
        Me.dgvExistencias.AllowUserToAddRows = False
        Me.dgvExistencias.AllowUserToDeleteRows = False
        Me.dgvExistencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExistencias.Location = New System.Drawing.Point(8, 86)
        Me.dgvExistencias.Name = "dgvExistencias"
        Me.dgvExistencias.RowHeadersVisible = False
        Me.dgvExistencias.Size = New System.Drawing.Size(626, 335)
        Me.dgvExistencias.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgvProductosDevolucionDetalle)
        Me.TabPage2.Controls.Add(Me.btnAplicar)
        Me.TabPage2.Controls.Add(Me.dgvProductosDevolucion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(936, 429)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Proceso.."
        '
        'dgvProductosDevolucionDetalle
        '
        Me.dgvProductosDevolucionDetalle.AllowUserToAddRows = False
        Me.dgvProductosDevolucionDetalle.AllowUserToDeleteRows = False
        Me.dgvProductosDevolucionDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductosDevolucionDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductosDevolucionDetalle.Location = New System.Drawing.Point(3, 327)
        Me.dgvProductosDevolucionDetalle.Name = "dgvProductosDevolucionDetalle"
        Me.dgvProductosDevolucionDetalle.RowHeadersWidth = 25
        Me.dgvProductosDevolucionDetalle.Size = New System.Drawing.Size(930, 102)
        Me.dgvProductosDevolucionDetalle.TabIndex = 2
        '
        'btnAplicar
        '
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAplicar.ImageIndex = 3
        Me.btnAplicar.ImageList = Me.ImageList1
        Me.btnAplicar.Location = New System.Drawing.Point(666, 1)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 60)
        Me.btnAplicar.TabIndex = 1
        Me.btnAplicar.Text = "Procesar"
        Me.btnAplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'dgvProductosDevolucion
        '
        Me.dgvProductosDevolucion.AllowUserToAddRows = False
        Me.dgvProductosDevolucion.AllowUserToDeleteRows = False
        Me.dgvProductosDevolucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductosDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductosDevolucion.Location = New System.Drawing.Point(3, 64)
        Me.dgvProductosDevolucion.Name = "dgvProductosDevolucion"
        Me.dgvProductosDevolucion.RowHeadersWidth = 25
        Me.dgvProductosDevolucion.Size = New System.Drawing.Size(930, 257)
        Me.dgvProductosDevolucion.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.btnProcesar)
        Me.TabPage3.Controls.Add(Me.btnRefrescar)
        Me.TabPage3.Controls.Add(Me.dgvDevolucionesPendientes)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(936, 429)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Devoluciones Pendientes"
        '
        'btnProcesar
        '
        Me.btnProcesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesar.ForeColor = System.Drawing.Color.White
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.ImageIndex = 3
        Me.btnProcesar.ImageList = Me.ImageList1
        Me.btnProcesar.Location = New System.Drawing.Point(593, 6)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 62)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefrescar.ForeColor = System.Drawing.Color.White
        Me.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.ImageList = Me.ImageList1
        Me.btnRefrescar.Location = New System.Drawing.Point(485, 6)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 62)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'dgvDevolucionesPendientes
        '
        Me.dgvDevolucionesPendientes.AllowUserToAddRows = False
        Me.dgvDevolucionesPendientes.AllowUserToDeleteRows = False
        Me.dgvDevolucionesPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDevolucionesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDevolucionesPendientes.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDevolucionesPendientes.Location = New System.Drawing.Point(8, 74)
        Me.dgvDevolucionesPendientes.Name = "dgvDevolucionesPendientes"
        Me.dgvDevolucionesPendientes.RowHeadersWidth = 25
        Me.dgvDevolucionesPendientes.Size = New System.Drawing.Size(925, 347)
        Me.dgvDevolucionesPendientes.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.btnImprimirMovimientoFlexLine)
        Me.TabPage4.Controls.Add(Me.btnImprimirImpresiones)
        Me.TabPage4.Controls.Add(Me.btnRefrescarImpresiones)
        Me.TabPage4.Controls.Add(Me.dgvDevolucionMovimientoFlexLine)
        Me.TabPage4.Controls.Add(Me.dgvDevolucionesImprimir)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(936, 429)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Monitor de Impresiones"
        '
        'btnImprimirMovimientoFlexLine
        '
        Me.btnImprimirMovimientoFlexLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirMovimientoFlexLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirMovimientoFlexLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirMovimientoFlexLine.ForeColor = System.Drawing.Color.White
        Me.btnImprimirMovimientoFlexLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirMovimientoFlexLine.ImageIndex = 0
        Me.btnImprimirMovimientoFlexLine.ImageList = Me.ImageList1
        Me.btnImprimirMovimientoFlexLine.Location = New System.Drawing.Point(855, 230)
        Me.btnImprimirMovimientoFlexLine.Name = "btnImprimirMovimientoFlexLine"
        Me.btnImprimirMovimientoFlexLine.Size = New System.Drawing.Size(75, 54)
        Me.btnImprimirMovimientoFlexLine.TabIndex = 1
        Me.btnImprimirMovimientoFlexLine.Text = "Imprimir"
        Me.btnImprimirMovimientoFlexLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirMovimientoFlexLine.UseVisualStyleBackColor = False
        '
        'btnImprimirImpresiones
        '
        Me.btnImprimirImpresiones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirImpresiones.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirImpresiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirImpresiones.ForeColor = System.Drawing.Color.White
        Me.btnImprimirImpresiones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirImpresiones.ImageIndex = 0
        Me.btnImprimirImpresiones.ImageList = Me.ImageList1
        Me.btnImprimirImpresiones.Location = New System.Drawing.Point(853, 6)
        Me.btnImprimirImpresiones.Name = "btnImprimirImpresiones"
        Me.btnImprimirImpresiones.Size = New System.Drawing.Size(75, 65)
        Me.btnImprimirImpresiones.TabIndex = 1
        Me.btnImprimirImpresiones.Text = "Imprimir"
        Me.btnImprimirImpresiones.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirImpresiones.UseVisualStyleBackColor = False
        '
        'btnRefrescarImpresiones
        '
        Me.btnRefrescarImpresiones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescarImpresiones.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRefrescarImpresiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefrescarImpresiones.ForeColor = System.Drawing.Color.White
        Me.btnRefrescarImpresiones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefrescarImpresiones.ImageKey = "Actualizar_Blue.png"
        Me.btnRefrescarImpresiones.ImageList = Me.ImageList1
        Me.btnRefrescarImpresiones.Location = New System.Drawing.Point(853, 101)
        Me.btnRefrescarImpresiones.Name = "btnRefrescarImpresiones"
        Me.btnRefrescarImpresiones.Size = New System.Drawing.Size(75, 55)
        Me.btnRefrescarImpresiones.TabIndex = 1
        Me.btnRefrescarImpresiones.Text = "Refrescar"
        Me.btnRefrescarImpresiones.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefrescarImpresiones.UseVisualStyleBackColor = False
        '
        'dgvDevolucionMovimientoFlexLine
        '
        Me.dgvDevolucionMovimientoFlexLine.AllowUserToDeleteRows = False
        Me.dgvDevolucionMovimientoFlexLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDevolucionMovimientoFlexLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDevolucionMovimientoFlexLine.Location = New System.Drawing.Point(3, 230)
        Me.dgvDevolucionMovimientoFlexLine.Name = "dgvDevolucionMovimientoFlexLine"
        Me.dgvDevolucionMovimientoFlexLine.RowHeadersWidth = 20
        Me.dgvDevolucionMovimientoFlexLine.Size = New System.Drawing.Size(844, 193)
        Me.dgvDevolucionMovimientoFlexLine.TabIndex = 0
        '
        'dgvDevolucionesImprimir
        '
        Me.dgvDevolucionesImprimir.AllowUserToAddRows = False
        Me.dgvDevolucionesImprimir.AllowUserToDeleteRows = False
        Me.dgvDevolucionesImprimir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDevolucionesImprimir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDevolucionesImprimir.Location = New System.Drawing.Point(3, 6)
        Me.dgvDevolucionesImprimir.Name = "dgvDevolucionesImprimir"
        Me.dgvDevolucionesImprimir.RowHeadersWidth = 20
        Me.dgvDevolucionesImprimir.Size = New System.Drawing.Size(844, 218)
        Me.dgvDevolucionesImprimir.TabIndex = 0
        '
        'frm_DevolucionesInterempresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 455)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_DevolucionesInterempresas"
        Me.Text = ".::. Devoluciones InterEmpresas .::."
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvBU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvProductosDevolucionDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductosDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvDevolucionesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvDevolucionMovimientoFlexLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDevolucionesImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnGenerarInformacion As System.Windows.Forms.Button
    Friend WithEvents dgvExistencias As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvBU As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesarDevolucion As System.Windows.Forms.Button
    Friend WithEvents dgvProductosDevolucion As System.Windows.Forms.DataGridView
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvDevolucionesPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dgvProductosDevolucionDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnImprimirImpresiones As System.Windows.Forms.Button
    Friend WithEvents btnRefrescarImpresiones As System.Windows.Forms.Button
    Friend WithEvents dgvDevolucionesImprimir As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimirMovimientoFlexLine As System.Windows.Forms.Button
    Friend WithEvents dgvDevolucionMovimientoFlexLine As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
