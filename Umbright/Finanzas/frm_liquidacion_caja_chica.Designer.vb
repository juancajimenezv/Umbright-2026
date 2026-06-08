<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_liquidacion_caja_chica
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_liquidacion_caja_chica))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMontoDocumentosSeleccionados = New System.Windows.Forms.Label()
        Me.lblDocumentosSeleccionados = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_registros = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAplicarFecha = New System.Windows.Forms.Button()
        Me.btnAplicarResponsable = New System.Windows.Forms.Button()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnRecibirParcial = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Convertir = New System.Windows.Forms.Button()
        Me.lblNumeroLiquidacion = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtfitro = New System.Windows.Forms.TextBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvBusqueda = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1092, 482)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnImprimir)
        Me.TabPage1.Controls.Add(Me.btnRecibirParcial)
        Me.TabPage1.Controls.Add(Me.lblCorreo)
        Me.TabPage1.Controls.Add(Me.dgv_Detalle)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btn_Convertir)
        Me.TabPage1.Controls.Add(Me.lblNumeroLiquidacion)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1084, 456)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Proceso"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.lblMontoDocumentosSeleccionados)
        Me.GroupBox3.Controls.Add(Me.lblDocumentosSeleccionados)
        Me.GroupBox3.Location = New System.Drawing.Point(636, 49)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(157, 57)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccionado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Registros:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Monto :"
        '
        'lblMontoDocumentosSeleccionados
        '
        Me.lblMontoDocumentosSeleccionados.AutoSize = True
        Me.lblMontoDocumentosSeleccionados.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoDocumentosSeleccionados.Location = New System.Drawing.Point(94, 34)
        Me.lblMontoDocumentosSeleccionados.Name = "lblMontoDocumentosSeleccionados"
        Me.lblMontoDocumentosSeleccionados.Size = New System.Drawing.Size(31, 15)
        Me.lblMontoDocumentosSeleccionados.TabIndex = 13
        Me.lblMontoDocumentosSeleccionados.Text = "0.00"
        '
        'lblDocumentosSeleccionados
        '
        Me.lblDocumentosSeleccionados.AutoSize = True
        Me.lblDocumentosSeleccionados.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentosSeleccionados.Location = New System.Drawing.Point(94, 17)
        Me.lblDocumentosSeleccionados.Name = "lblDocumentosSeleccionados"
        Me.lblDocumentosSeleccionados.Size = New System.Drawing.Size(14, 15)
        Me.lblDocumentosSeleccionados.TabIndex = 12
        Me.lblDocumentosSeleccionados.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lb_registros)
        Me.GroupBox2.Controls.Add(Me.lblMonto)
        Me.GroupBox2.Location = New System.Drawing.Point(437, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(169, 57)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Totales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Registros:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Monto:"
        '
        'lb_registros
        '
        Me.lb_registros.AutoSize = True
        Me.lb_registros.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_registros.Location = New System.Drawing.Point(93, 17)
        Me.lb_registros.Name = "lb_registros"
        Me.lb_registros.Size = New System.Drawing.Size(14, 15)
        Me.lb_registros.TabIndex = 3
        Me.lb_registros.Text = "0"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(93, 34)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(14, 15)
        Me.lblMonto.TabIndex = 5
        Me.lblMonto.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnAplicarFecha)
        Me.GroupBox1.Controls.Add(Me.btnAplicarResponsable)
        Me.GroupBox1.Controls.Add(Me.txtGlosa)
        Me.GroupBox1.Controls.Add(Me.txtResponsable)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 100)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Masivo"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(79, 65)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Glosa:"
        '
        'btnAplicarFecha
        '
        Me.btnAplicarFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicarFecha.ForeColor = System.Drawing.Color.White
        Me.btnAplicarFecha.Location = New System.Drawing.Point(311, 65)
        Me.btnAplicarFecha.Name = "btnAplicarFecha"
        Me.btnAplicarFecha.Size = New System.Drawing.Size(82, 23)
        Me.btnAplicarFecha.TabIndex = 15
        Me.btnAplicarFecha.Text = "Fecha"
        Me.btnAplicarFecha.UseVisualStyleBackColor = False
        '
        'btnAplicarResponsable
        '
        Me.btnAplicarResponsable.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarResponsable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicarResponsable.ForeColor = System.Drawing.Color.White
        Me.btnAplicarResponsable.Location = New System.Drawing.Point(311, 36)
        Me.btnAplicarResponsable.Name = "btnAplicarResponsable"
        Me.btnAplicarResponsable.Size = New System.Drawing.Size(82, 23)
        Me.btnAplicarResponsable.TabIndex = 15
        Me.btnAplicarResponsable.Text = "Responsable"
        Me.btnAplicarResponsable.UseVisualStyleBackColor = False
        '
        'txtGlosa
        '
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Location = New System.Drawing.Point(79, 10)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(226, 20)
        Me.txtGlosa.TabIndex = 8
        '
        'txtResponsable
        '
        Me.txtResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResponsable.Location = New System.Drawing.Point(79, 35)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(226, 20)
        Me.txtResponsable.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Fecha:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Responsable:"
        '
        'btnAplicar
        '
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.Location = New System.Drawing.Point(311, 6)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(82, 23)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Glosa"
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.ImageIndex = 4
        Me.btnImprimir.ImageList = Me.ImageList2
        Me.btnImprimir.Location = New System.Drawing.Point(807, 20)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(87, 66)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.Text = "Reporte"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        Me.btnImprimir.Visible = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Text-Edit-icon.png")
        Me.ImageList2.Images.SetKeyName(1, "Smart-FTP-icon.png")
        Me.ImageList2.Images.SetKeyName(2, "refresh.jpg")
        Me.ImageList2.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList2.Images.SetKeyName(4, "printer_48.png")
        Me.ImageList2.Images.SetKeyName(5, "cut_from_page.ico")
        '
        'btnRecibirParcial
        '
        Me.btnRecibirParcial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecibirParcial.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRecibirParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecibirParcial.ForeColor = System.Drawing.Color.White
        Me.btnRecibirParcial.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecibirParcial.ImageIndex = 1
        Me.btnRecibirParcial.ImageList = Me.ImageList1
        Me.btnRecibirParcial.Location = New System.Drawing.Point(899, 20)
        Me.btnRecibirParcial.Name = "btnRecibirParcial"
        Me.btnRecibirParcial.Size = New System.Drawing.Size(87, 66)
        Me.btnRecibirParcial.TabIndex = 10
        Me.btnRecibirParcial.Text = "Recibir Parcial"
        Me.btnRecibirParcial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecibirParcial.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "save.ico")
        Me.ImageList1.Images.SetKeyName(1, "accept.ico")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(566, 33)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(13, 13)
        Me.lblCorreo.TabIndex = 7
        Me.lblCorreo.Text = "0"
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AllowUserToAddRows = False
        Me.dgv_Detalle.AllowUserToOrderColumns = True
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 112)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.ReadOnly = True
        Me.dgv_Detalle.RowHeadersWidth = 20
        Me.dgv_Detalle.Size = New System.Drawing.Size(1066, 338)
        Me.dgv_Detalle.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(561, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Liquidación No.:"
        '
        'btn_Convertir
        '
        Me.btn_Convertir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Convertir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Convertir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Convertir.ForeColor = System.Drawing.Color.White
        Me.btn_Convertir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Convertir.ImageIndex = 0
        Me.btn_Convertir.ImageList = Me.ImageList1
        Me.btn_Convertir.Location = New System.Drawing.Point(992, 20)
        Me.btn_Convertir.Name = "btn_Convertir"
        Me.btn_Convertir.Size = New System.Drawing.Size(80, 66)
        Me.btn_Convertir.TabIndex = 4
        Me.btn_Convertir.Text = "Recibir"
        Me.btn_Convertir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Convertir.UseVisualStyleBackColor = False
        '
        'lblNumeroLiquidacion
        '
        Me.lblNumeroLiquidacion.AutoSize = True
        Me.lblNumeroLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroLiquidacion.Location = New System.Drawing.Point(741, 8)
        Me.lblNumeroLiquidacion.Name = "lblNumeroLiquidacion"
        Me.lblNumeroLiquidacion.Size = New System.Drawing.Size(23, 25)
        Me.lblNumeroLiquidacion.TabIndex = 3
        Me.lblNumeroLiquidacion.Text = "0"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtfitro)
        Me.TabPage2.Controls.Add(Me.btnActualizar)
        Me.TabPage2.Controls.Add(Me.dgvListado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1084, 456)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Buscar"
        Me.Label6.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(418, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'txtfitro
        '
        Me.txtfitro.Location = New System.Drawing.Point(53, 44)
        Me.txtfitro.Name = "txtfitro"
        Me.txtfitro.Size = New System.Drawing.Size(341, 20)
        Me.txtfitro.TabIndex = 2
        Me.txtfitro.Visible = False
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.ImageIndex = 2
        Me.btnActualizar.ImageList = Me.ImageList1
        Me.btnActualizar.Location = New System.Drawing.Point(960, 6)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 58)
        Me.btnActualizar.TabIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(8, 83)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.Size = New System.Drawing.Size(1064, 367)
        Me.dgvListado.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.dgvBusqueda)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.txtBuscar)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1084, 456)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Validación"
        '
        'dgvBusqueda
        '
        Me.dgvBusqueda.AllowUserToAddRows = False
        Me.dgvBusqueda.AllowUserToDeleteRows = False
        Me.dgvBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqueda.Location = New System.Drawing.Point(11, 81)
        Me.dgvBusqueda.Name = "dgvBusqueda"
        Me.dgvBusqueda.ReadOnly = True
        Me.dgvBusqueda.RowHeadersWidth = 25
        Me.dgvBusqueda.Size = New System.Drawing.Size(1064, 367)
        Me.dgvBusqueda.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(75, 35)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(341, 20)
        Me.txtBuscar.TabIndex = 12
        '
        'frm_liquidacion_caja_chica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 485)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_liquidacion_caja_chica"
        Me.Text = ":: Liquidación Caja Chica :: TEAMS ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblCorreo As Label
    Friend WithEvents dgv_Detalle As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents lb_registros As Label
    Friend WithEvents btn_Convertir As Button
    Friend WithEvents lblNumeroLiquidacion As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnActualizar As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnAplicar As Button
    Friend WithEvents txtGlosa As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRecibirParcial As Button
    Friend WithEvents txtfitro As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents lblMontoDocumentosSeleccionados As Label
    Friend WithEvents lblDocumentosSeleccionados As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvBusqueda As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnAplicarResponsable As Button
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents btnAplicarFecha As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnImprimir As Button
    Friend WithEvents ImageList2 As ImageList
End Class
