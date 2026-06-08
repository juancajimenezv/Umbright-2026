<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_int_etiquetado
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFiltroDI = New System.Windows.Forms.TextBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.dgvInternacionesDetalle = New System.Windows.Forms.DataGridView()
        Me.dgvInternaciones = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtCodPedido = New System.Windows.Forms.TextBox()
        Me.txtDI = New System.Windows.Forms.TextBox()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.gbFinal = New System.Windows.Forms.GroupBox()
        Me.dgv_estados = New System.Windows.Forms.DataGridView()
        Me.gbInicial = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAplicarInformacionInicial = New System.Windows.Forms.Button()
        Me.txtNumeroPersonas = New System.Windows.Forms.TextBox()
        Me.clbx_etiquetas = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkTiempoExtra = New System.Windows.Forms.CheckBox()
        Me.txtNumeroOrdenEtiquetado = New System.Windows.Forms.TextBox()
        Me.lblCantidadActual = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnReinicio = New System.Windows.Forms.Button()
        Me.btnPausa = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.txtGlosaProducto = New System.Windows.Forms.TextBox()
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.txtCantidadActual = New System.Windows.Forms.TextBox()
        Me.txtCodigoBarra = New System.Windows.Forms.TextBox()
        Me.txtBarraOriginal = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvInternacionesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInternaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbFinal.SuspendLayout()
        CType(Me.dgv_estados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInicial.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(929, 481)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtFiltroDI)
        Me.TabPage1.Controls.Add(Me.btnRefrescar)
        Me.TabPage1.Controls.Add(Me.dgvInternacionesDetalle)
        Me.TabPage1.Controls.Add(Me.dgvInternaciones)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(921, 455)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado Internaciones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(66, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "DI"
        '
        'txtFiltroDI
        '
        Me.txtFiltroDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltroDI.Location = New System.Drawing.Point(114, 22)
        Me.txtFiltroDI.Name = "txtFiltroDI"
        Me.txtFiltroDI.Size = New System.Drawing.Size(174, 20)
        Me.txtFiltroDI.TabIndex = 2
        '
        'btnRefrescar
        '
        Me.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefrescar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefrescar.ForeColor = System.Drawing.Color.White
        Me.btnRefrescar.Location = New System.Drawing.Point(471, 6)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 51)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefrescar.UseVisualStyleBackColor = False
        '
        'dgvInternacionesDetalle
        '
        Me.dgvInternacionesDetalle.AllowUserToAddRows = False
        Me.dgvInternacionesDetalle.AllowUserToDeleteRows = False
        Me.dgvInternacionesDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInternacionesDetalle.Location = New System.Drawing.Point(449, 61)
        Me.dgvInternacionesDetalle.Name = "dgvInternacionesDetalle"
        Me.dgvInternacionesDetalle.RowHeadersVisible = False
        Me.dgvInternacionesDetalle.Size = New System.Drawing.Size(469, 386)
        Me.dgvInternacionesDetalle.TabIndex = 0
        '
        'dgvInternaciones
        '
        Me.dgvInternaciones.AllowUserToAddRows = False
        Me.dgvInternaciones.AllowUserToDeleteRows = False
        Me.dgvInternaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInternaciones.Location = New System.Drawing.Point(8, 63)
        Me.dgvInternaciones.Name = "dgvInternaciones"
        Me.dgvInternaciones.RowHeadersVisible = False
        Me.dgvInternaciones.Size = New System.Drawing.Size(435, 386)
        Me.dgvInternaciones.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.gbFinal)
        Me.TabPage2.Controls.Add(Me.gbInicial)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(921, 455)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle Internaciones"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtCantidad)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtProveedor)
        Me.GroupBox4.Controls.Add(Me.txtCodPedido)
        Me.GroupBox4.Controls.Add(Me.txtDI)
        Me.GroupBox4.Controls.Add(Me.txtEmpresa)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(904, 48)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'txtCantidad
        '
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Location = New System.Drawing.Point(775, 19)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(38, 20)
        Me.txtCantidad.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(430, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "DI"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa"
        '
        'txtProveedor
        '
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Location = New System.Drawing.Point(487, 19)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(273, 20)
        Me.txtProveedor.TabIndex = 0
        '
        'txtCodPedido
        '
        Me.txtCodPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodPedido.Location = New System.Drawing.Point(248, 19)
        Me.txtCodPedido.Name = "txtCodPedido"
        Me.txtCodPedido.ReadOnly = True
        Me.txtCodPedido.Size = New System.Drawing.Size(38, 20)
        Me.txtCodPedido.TabIndex = 0
        Me.txtCodPedido.Visible = False
        '
        'txtDI
        '
        Me.txtDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDI.Location = New System.Drawing.Point(292, 19)
        Me.txtDI.Name = "txtDI"
        Me.txtDI.ReadOnly = True
        Me.txtDI.Size = New System.Drawing.Size(100, 20)
        Me.txtDI.TabIndex = 0
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa.Location = New System.Drawing.Point(103, 19)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(100, 20)
        Me.txtEmpresa.TabIndex = 0
        '
        'gbFinal
        '
        Me.gbFinal.Controls.Add(Me.dgv_estados)
        Me.gbFinal.Location = New System.Drawing.Point(385, 151)
        Me.gbFinal.Name = "gbFinal"
        Me.gbFinal.Size = New System.Drawing.Size(383, 298)
        Me.gbFinal.TabIndex = 2
        Me.gbFinal.TabStop = False
        Me.gbFinal.Text = "Informacion Final"
        '
        'dgv_estados
        '
        Me.dgv_estados.AllowUserToAddRows = False
        Me.dgv_estados.AllowUserToDeleteRows = False
        Me.dgv_estados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_estados.Location = New System.Drawing.Point(6, 14)
        Me.dgv_estados.Name = "dgv_estados"
        Me.dgv_estados.RowHeadersWidth = 25
        Me.dgv_estados.Size = New System.Drawing.Size(362, 278)
        Me.dgv_estados.TabIndex = 0
        '
        'gbInicial
        '
        Me.gbInicial.Controls.Add(Me.Label5)
        Me.gbInicial.Controls.Add(Me.btnAplicarInformacionInicial)
        Me.gbInicial.Controls.Add(Me.txtNumeroPersonas)
        Me.gbInicial.Controls.Add(Me.clbx_etiquetas)
        Me.gbInicial.Location = New System.Drawing.Point(8, 149)
        Me.gbInicial.Name = "gbInicial"
        Me.gbInicial.Size = New System.Drawing.Size(319, 298)
        Me.gbInicial.TabIndex = 1
        Me.gbInicial.TabStop = False
        Me.gbInicial.Text = "Informacion Inicial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(154, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Cantidad de Personas"
        '
        'btnAplicarInformacionInicial
        '
        Me.btnAplicarInformacionInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarInformacionInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicarInformacionInicial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarInformacionInicial.ForeColor = System.Drawing.Color.White
        Me.btnAplicarInformacionInicial.Location = New System.Drawing.Point(157, 96)
        Me.btnAplicarInformacionInicial.Name = "btnAplicarInformacionInicial"
        Me.btnAplicarInformacionInicial.Size = New System.Drawing.Size(75, 41)
        Me.btnAplicarInformacionInicial.TabIndex = 2
        Me.btnAplicarInformacionInicial.Text = "Iniciar"
        Me.btnAplicarInformacionInicial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAplicarInformacionInicial.UseVisualStyleBackColor = False
        '
        'txtNumeroPersonas
        '
        Me.txtNumeroPersonas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPersonas.Location = New System.Drawing.Point(154, 51)
        Me.txtNumeroPersonas.Name = "txtNumeroPersonas"
        Me.txtNumeroPersonas.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroPersonas.TabIndex = 10
        '
        'clbx_etiquetas
        '
        Me.clbx_etiquetas.CheckOnClick = True
        Me.clbx_etiquetas.FormattingEnabled = True
        Me.clbx_etiquetas.Location = New System.Drawing.Point(6, 19)
        Me.clbx_etiquetas.Name = "clbx_etiquetas"
        Me.clbx_etiquetas.Size = New System.Drawing.Size(142, 259)
        Me.clbx_etiquetas.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBarraOriginal)
        Me.GroupBox1.Controls.Add(Me.chkTiempoExtra)
        Me.GroupBox1.Controls.Add(Me.txtNumeroOrdenEtiquetado)
        Me.GroupBox1.Controls.Add(Me.lblCantidadActual)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnFinalizar)
        Me.GroupBox1.Controls.Add(Me.btnReinicio)
        Me.GroupBox1.Controls.Add(Me.btnPausa)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnIniciar)
        Me.GroupBox1.Controls.Add(Me.txtGlosaProducto)
        Me.GroupBox1.Controls.Add(Me.txtCodigoProducto)
        Me.GroupBox1.Controls.Add(Me.txtCantidadActual)
        Me.GroupBox1.Controls.Add(Me.txtCodigoBarra)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(904, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkTiempoExtra
        '
        Me.chkTiempoExtra.AutoSize = True
        Me.chkTiempoExtra.Location = New System.Drawing.Point(399, 66)
        Me.chkTiempoExtra.Name = "chkTiempoExtra"
        Me.chkTiempoExtra.Size = New System.Drawing.Size(94, 17)
        Me.chkTiempoExtra.TabIndex = 3
        Me.chkTiempoExtra.Text = "Horario Inhabil"
        Me.chkTiempoExtra.UseVisualStyleBackColor = True
        '
        'txtNumeroOrdenEtiquetado
        '
        Me.txtNumeroOrdenEtiquetado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroOrdenEtiquetado.Location = New System.Drawing.Point(270, 63)
        Me.txtNumeroOrdenEtiquetado.Name = "txtNumeroOrdenEtiquetado"
        Me.txtNumeroOrdenEtiquetado.Size = New System.Drawing.Size(38, 20)
        Me.txtNumeroOrdenEtiquetado.TabIndex = 2
        Me.txtNumeroOrdenEtiquetado.Visible = False
        '
        'lblCantidadActual
        '
        Me.lblCantidadActual.AutoSize = True
        Me.lblCantidadActual.Location = New System.Drawing.Point(6, 63)
        Me.lblCantidadActual.Name = "lblCantidadActual"
        Me.lblCantidadActual.Size = New System.Drawing.Size(82, 13)
        Me.lblCantidadActual.TabIndex = 1
        Me.lblCantidadActual.Text = "Cantidad Actual"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Producto"
        '
        'btnFinalizar
        '
        Me.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.ForeColor = System.Drawing.Color.White
        Me.btnFinalizar.Location = New System.Drawing.Point(751, 13)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(75, 51)
        Me.btnFinalizar.TabIndex = 2
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFinalizar.UseVisualStyleBackColor = False
        '
        'btnReinicio
        '
        Me.btnReinicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReinicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReinicio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReinicio.ForeColor = System.Drawing.Color.White
        Me.btnReinicio.Location = New System.Drawing.Point(579, 13)
        Me.btnReinicio.Name = "btnReinicio"
        Me.btnReinicio.Size = New System.Drawing.Size(75, 51)
        Me.btnReinicio.TabIndex = 2
        Me.btnReinicio.Text = "Reinicio"
        Me.btnReinicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReinicio.UseVisualStyleBackColor = False
        '
        'btnPausa
        '
        Me.btnPausa.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnPausa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPausa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPausa.ForeColor = System.Drawing.Color.White
        Me.btnPausa.Location = New System.Drawing.Point(670, 13)
        Me.btnPausa.Name = "btnPausa"
        Me.btnPausa.Size = New System.Drawing.Size(75, 51)
        Me.btnPausa.TabIndex = 2
        Me.btnPausa.Text = "Pausa"
        Me.btnPausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPausa.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.White
        Me.btnLimpiar.Location = New System.Drawing.Point(829, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 51)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnIniciar
        '
        Me.btnIniciar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIniciar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciar.ForeColor = System.Drawing.Color.White
        Me.btnIniciar.Location = New System.Drawing.Point(589, 13)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(75, 51)
        Me.btnIniciar.TabIndex = 2
        Me.btnIniciar.Text = "btnIniciar"
        Me.btnIniciar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'txtGlosaProducto
        '
        Me.txtGlosaProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosaProducto.Location = New System.Drawing.Point(238, 29)
        Me.txtGlosaProducto.Name = "txtGlosaProducto"
        Me.txtGlosaProducto.Size = New System.Drawing.Size(320, 20)
        Me.txtGlosaProducto.TabIndex = 1
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoProducto.Location = New System.Drawing.Point(159, 29)
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(78, 20)
        Me.txtCodigoProducto.TabIndex = 0
        '
        'txtCantidadActual
        '
        Me.txtCantidadActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadActual.Location = New System.Drawing.Point(103, 60)
        Me.txtCantidadActual.Name = "txtCantidadActual"
        Me.txtCantidadActual.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidadActual.TabIndex = 0
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoBarra.Location = New System.Drawing.Point(57, 29)
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoBarra.TabIndex = 0
        '
        'txtBarraOriginal
        '
        Me.txtBarraOriginal.Location = New System.Drawing.Point(57, 8)
        Me.txtBarraOriginal.Name = "txtBarraOriginal"
        Me.txtBarraOriginal.Size = New System.Drawing.Size(100, 20)
        Me.txtBarraOriginal.TabIndex = 4
        Me.txtBarraOriginal.Visible = False
        '
        'frm_int_etiquetado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 481)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_int_etiquetado"
        Me.Text = ".::. Etiquetado .::."
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvInternacionesDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInternaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbFinal.ResumeLayout(False)
        CType(Me.dgv_estados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInicial.ResumeLayout(False)
        Me.gbInicial.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInternaciones As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gbFinal As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_estados As System.Windows.Forms.DataGridView
    Friend WithEvents gbInicial As System.Windows.Forms.GroupBox
    Friend WithEvents btnAplicarInformacionInicial As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnPausa As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents txtGlosaProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtDI As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clbx_etiquetas As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroPersonas As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPedido As System.Windows.Forms.TextBox
    Friend WithEvents lblCantidadActual As System.Windows.Forms.Label
    Friend WithEvents txtCantidadActual As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroOrdenEtiquetado As System.Windows.Forms.TextBox
    Friend WithEvents btnReinicio As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFiltroDI As System.Windows.Forms.TextBox
    Friend WithEvents chkTiempoExtra As System.Windows.Forms.CheckBox
    Friend WithEvents dgvInternacionesDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtBarraOriginal As System.Windows.Forms.TextBox
End Class
