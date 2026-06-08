<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidacionCaja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiquidacionCaja))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnGuardarResumen = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkb_opera_recibos = New System.Windows.Forms.CheckBox()
        Me.lblajuste = New System.Windows.Forms.Label()
        Me.txtAjuste = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFaltantePiloto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMontoGuia2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRecibido = New System.Windows.Forms.TextBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.dgvLiquidacion = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lbl_opcion = New System.Windows.Forms.Label()
        Me.chkb_pendientes = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn_guardapendientes = New System.Windows.Forms.Button()
        Me.dgv_pendientes = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVehiculo = New System.Windows.Forms.TextBox()
        Me.dtpFechaGuia = New System.Windows.Forms.DateTimePicker()
        Me.txtDoctos = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPiloto = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.dgvTotales = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkFiltro = New System.Windows.Forms.CheckedListBox()
        Me.btnAplicarFiltro = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgv_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTotales, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(-2, 237)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1242, 504)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDetalle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1234, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeColumns = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(3, 3)
        Me.dgvDetalle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 20
        Me.dgvDetalle.Size = New System.Drawing.Size(1228, 506)
        Me.dgvDetalle.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btnGuardarResumen)
        Me.TabPage2.Controls.Add(Me.dgvResumen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1234, 475)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Recepción"
        '
        'btnGuardarResumen
        '
        Me.btnGuardarResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardarResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarResumen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarResumen.ForeColor = System.Drawing.Color.White
        Me.btnGuardarResumen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarResumen.ImageIndex = 4
        Me.btnGuardarResumen.ImageList = Me.ImageList1
        Me.btnGuardarResumen.Location = New System.Drawing.Point(1140, 9)
        Me.btnGuardarResumen.Name = "btnGuardarResumen"
        Me.btnGuardarResumen.Size = New System.Drawing.Size(87, 95)
        Me.btnGuardarResumen.TabIndex = 10
        Me.btnGuardarResumen.Text = "Guarda Recepción Guía"
        Me.btnGuardarResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarResumen.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "7.png")
        Me.ImageList1.Images.SetKeyName(1, "3.png")
        Me.ImageList1.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "Floppy-64.png")
        '
        'dgvResumen
        '
        Me.dgvResumen.AllowUserToAddRows = False
        Me.dgvResumen.AllowUserToDeleteRows = False
        Me.dgvResumen.AllowUserToResizeColumns = False
        Me.dgvResumen.AllowUserToResizeRows = False
        Me.dgvResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Location = New System.Drawing.Point(3, 4)
        Me.dgvResumen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.RowHeadersWidth = 20
        Me.dgvResumen.Size = New System.Drawing.Size(1131, 505)
        Me.dgvResumen.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.chkb_opera_recibos)
        Me.TabPage3.Controls.Add(Me.lblajuste)
        Me.TabPage3.Controls.Add(Me.txtAjuste)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.txtFaltantePiloto)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.txtMontoGuia2)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtRecibido)
        Me.TabPage3.Controls.Add(Me.btn_guardar)
        Me.TabPage3.Controls.Add(Me.dgvLiquidacion)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1234, 475)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Liquidacion"
        '
        'chkb_opera_recibos
        '
        Me.chkb_opera_recibos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkb_opera_recibos.AutoSize = True
        Me.chkb_opera_recibos.Location = New System.Drawing.Point(1126, 316)
        Me.chkb_opera_recibos.Name = "chkb_opera_recibos"
        Me.chkb_opera_recibos.Size = New System.Drawing.Size(103, 20)
        Me.chkb_opera_recibos.TabIndex = 15
        Me.chkb_opera_recibos.Text = "Lote Recibos"
        Me.chkb_opera_recibos.UseVisualStyleBackColor = True
        '
        'lblajuste
        '
        Me.lblajuste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblajuste.AutoSize = True
        Me.lblajuste.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblajuste.ForeColor = System.Drawing.Color.Black
        Me.lblajuste.Location = New System.Drawing.Point(1136, 65)
        Me.lblajuste.Name = "lblajuste"
        Me.lblajuste.Size = New System.Drawing.Size(41, 15)
        Me.lblajuste.TabIndex = 13
        Me.lblajuste.Text = "Ajuste"
        '
        'txtAjuste
        '
        Me.txtAjuste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAjuste.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAjuste.Location = New System.Drawing.Point(1139, 84)
        Me.txtAjuste.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAjuste.Name = "txtAjuste"
        Me.txtAjuste.ReadOnly = True
        Me.txtAjuste.Size = New System.Drawing.Size(89, 22)
        Me.txtAjuste.TabIndex = 14
        Me.txtAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(1139, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Faltante Piloto"
        '
        'txtFaltantePiloto
        '
        Me.txtFaltantePiloto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaltantePiloto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFaltantePiloto.Location = New System.Drawing.Point(1139, 135)
        Me.txtFaltantePiloto.Name = "txtFaltantePiloto"
        Me.txtFaltantePiloto.Size = New System.Drawing.Size(89, 22)
        Me.txtFaltantePiloto.TabIndex = 12
        Me.txtFaltantePiloto.Text = "0"
        Me.txtFaltantePiloto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1136, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Monto Guia"
        '
        'txtMontoGuia2
        '
        Me.txtMontoGuia2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoGuia2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoGuia2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoGuia2.Location = New System.Drawing.Point(1139, 29)
        Me.txtMontoGuia2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMontoGuia2.Name = "txtMontoGuia2"
        Me.txtMontoGuia2.ReadOnly = True
        Me.txtMontoGuia2.Size = New System.Drawing.Size(89, 22)
        Me.txtMontoGuia2.TabIndex = 6
        Me.txtMontoGuia2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1139, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Recibido"
        '
        'txtRecibido
        '
        Me.txtRecibido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecibido.Location = New System.Drawing.Point(1139, 192)
        Me.txtRecibido.Name = "txtRecibido"
        Me.txtRecibido.ReadOnly = True
        Me.txtRecibido.Size = New System.Drawing.Size(89, 22)
        Me.txtRecibido.TabIndex = 10
        Me.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 4
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(1144, 229)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(80, 72)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'dgvLiquidacion
        '
        Me.dgvLiquidacion.AllowUserToAddRows = False
        Me.dgvLiquidacion.AllowUserToDeleteRows = False
        Me.dgvLiquidacion.AllowUserToResizeColumns = False
        Me.dgvLiquidacion.AllowUserToResizeRows = False
        Me.dgvLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLiquidacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidacion.Location = New System.Drawing.Point(3, 3)
        Me.dgvLiquidacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.RowHeadersWidth = 20
        Me.dgvLiquidacion.Size = New System.Drawing.Size(1120, 468)
        Me.dgvLiquidacion.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.lbl_opcion)
        Me.TabPage4.Controls.Add(Me.chkb_pendientes)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.TextBox1)
        Me.TabPage4.Controls.Add(Me.btn_guardapendientes)
        Me.TabPage4.Controls.Add(Me.dgv_pendientes)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1234, 475)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Pendientes"
        '
        'lbl_opcion
        '
        Me.lbl_opcion.AutoSize = True
        Me.lbl_opcion.Location = New System.Drawing.Point(1160, 205)
        Me.lbl_opcion.Name = "lbl_opcion"
        Me.lbl_opcion.Size = New System.Drawing.Size(49, 16)
        Me.lbl_opcion.TabIndex = 6
        Me.lbl_opcion.Text = "Opcion"
        '
        'chkb_pendientes
        '
        Me.chkb_pendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkb_pendientes.AutoSize = True
        Me.chkb_pendientes.Location = New System.Drawing.Point(1128, 157)
        Me.chkb_pendientes.Name = "chkb_pendientes"
        Me.chkb_pendientes.Size = New System.Drawing.Size(103, 20)
        Me.chkb_pendientes.TabIndex = 19
        Me.chkb_pendientes.Text = "Lote Recibos"
        Me.chkb_pendientes.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(1141, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 15)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Recibido"
        Me.Label11.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(1141, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(89, 22)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox1.Visible = False
        '
        'btn_guardapendientes
        '
        Me.btn_guardapendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardapendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardapendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardapendientes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardapendientes.ForeColor = System.Drawing.Color.White
        Me.btn_guardapendientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardapendientes.ImageIndex = 4
        Me.btn_guardapendientes.ImageList = Me.ImageList1
        Me.btn_guardapendientes.Location = New System.Drawing.Point(1146, 70)
        Me.btn_guardapendientes.Name = "btn_guardapendientes"
        Me.btn_guardapendientes.Size = New System.Drawing.Size(80, 72)
        Me.btn_guardapendientes.TabIndex = 17
        Me.btn_guardapendientes.Text = "Guardar"
        Me.btn_guardapendientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardapendientes.UseVisualStyleBackColor = False
        '
        'dgv_pendientes
        '
        Me.dgv_pendientes.AllowUserToAddRows = False
        Me.dgv_pendientes.AllowUserToDeleteRows = False
        Me.dgv_pendientes.AllowUserToResizeColumns = False
        Me.dgv_pendientes.AllowUserToResizeRows = False
        Me.dgv_pendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pendientes.Location = New System.Drawing.Point(6, 3)
        Me.dgv_pendientes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv_pendientes.Name = "dgv_pendientes"
        Me.dgv_pendientes.RowHeadersWidth = 20
        Me.dgv_pendientes.Size = New System.Drawing.Size(1120, 468)
        Me.dgv_pendientes.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(404, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero de Guia"
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(509, 11)
        Me.txtGuia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(206, 22)
        Me.txtGuia.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtVehiculo)
        Me.GroupBox1.Controls.Add(Me.dtpFechaGuia)
        Me.GroupBox1.Controls.Add(Me.txtDoctos)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPiloto)
        Me.GroupBox1.Controls.Add(Me.txtRuta)
        Me.GroupBox1.Controls.Add(Me.dgvTotales)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(286, 50)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(936, 178)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion de la GUIA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Vehiculo"
        '
        'txtVehiculo
        '
        Me.txtVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehiculo.Location = New System.Drawing.Point(82, 90)
        Me.txtVehiculo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.ReadOnly = True
        Me.txtVehiculo.Size = New System.Drawing.Size(229, 21)
        Me.txtVehiculo.TabIndex = 5
        '
        'dtpFechaGuia
        '
        Me.dtpFechaGuia.Enabled = False
        Me.dtpFechaGuia.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaGuia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaGuia.Location = New System.Drawing.Point(82, 119)
        Me.dtpFechaGuia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaGuia.Name = "dtpFechaGuia"
        Me.dtpFechaGuia.Size = New System.Drawing.Size(109, 21)
        Me.dtpFechaGuia.TabIndex = 3
        '
        'txtDoctos
        '
        Me.txtDoctos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoctos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoctos.Location = New System.Drawing.Point(442, 74)
        Me.txtDoctos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDoctos.Name = "txtDoctos"
        Me.txtDoctos.ReadOnly = True
        Me.txtDoctos.Size = New System.Drawing.Size(116, 25)
        Me.txtDoctos.TabIndex = 2
        Me.txtDoctos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonto
        '
        Me.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(442, 38)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(116, 22)
        Me.txtMonto.TabIndex = 2
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Piloto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Ruta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(341, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Total Doctos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(341, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Monto Guia"
        '
        'txtPiloto
        '
        Me.txtPiloto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiloto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPiloto.Location = New System.Drawing.Point(82, 64)
        Me.txtPiloto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPiloto.Name = "txtPiloto"
        Me.txtPiloto.ReadOnly = True
        Me.txtPiloto.Size = New System.Drawing.Size(229, 21)
        Me.txtPiloto.TabIndex = 2
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.Location = New System.Drawing.Point(82, 38)
        Me.txtRuta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(229, 21)
        Me.txtRuta.TabIndex = 2
        '
        'dgvTotales
        '
        Me.dgvTotales.AllowUserToAddRows = False
        Me.dgvTotales.AllowUserToDeleteRows = False
        Me.dgvTotales.AllowUserToResizeColumns = False
        Me.dgvTotales.AllowUserToResizeRows = False
        Me.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTotales.Enabled = False
        Me.dgvTotales.Location = New System.Drawing.Point(568, 10)
        Me.dgvTotales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvTotales.Name = "dgvTotales"
        Me.dgvTotales.RowHeadersWidth = 20
        Me.dgvTotales.Size = New System.Drawing.Size(360, 161)
        Me.dgvTotales.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(747, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 38)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Obtener"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkFiltro
        '
        Me.chkFiltro.Enabled = False
        Me.chkFiltro.FormattingEnabled = True
        Me.chkFiltro.Items.AddRange(New Object() {"Credito", "Contado"})
        Me.chkFiltro.Location = New System.Drawing.Point(12, 60)
        Me.chkFiltro.Name = "chkFiltro"
        Me.chkFiltro.Size = New System.Drawing.Size(216, 55)
        Me.chkFiltro.TabIndex = 5
        '
        'btnAplicarFiltro
        '
        Me.btnAplicarFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAplicarFiltro.Enabled = False
        Me.btnAplicarFiltro.ForeColor = System.Drawing.Color.White
        Me.btnAplicarFiltro.Location = New System.Drawing.Point(12, 151)
        Me.btnAplicarFiltro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAplicarFiltro.Name = "btnAplicarFiltro"
        Me.btnAplicarFiltro.Size = New System.Drawing.Size(117, 38)
        Me.btnAplicarFiltro.TabIndex = 4
        Me.btnAplicarFiltro.Text = "Aplicar"
        Me.ToolTip1.SetToolTip(Me.btnAplicarFiltro, "Ya no Aplica!!")
        Me.btnAplicarFiltro.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.ImageIndex = 1
        Me.btnNuevo.ImageList = Me.ImageList1
        Me.btnNuevo.Location = New System.Drawing.Point(918, 3)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(117, 38)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_imprimir.Location = New System.Drawing.Point(1086, 3)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(91, 38)
        Me.btn_imprimir.TabIndex = 6
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1234, 475)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'frmLiquidacionCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1241, 749)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.chkFiltro)
        Me.Controls.Add(Me.btnAplicarFiltro)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtGuia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLiquidacionCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Liquidacion Transportes  - CAJA :: 24.03.22"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgv_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txtGuia As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDoctos As TextBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPiloto As TextBox
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents dgvTotales As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents dtpFechaGuia As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVehiculo As TextBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvResumen As DataGridView
    Friend WithEvents dgvLiquidacion As DataGridView
    Friend WithEvents btn_guardar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRecibido As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMontoGuia2 As TextBox
    Friend WithEvents chkFiltro As CheckedListBox
    Friend WithEvents btnAplicarFiltro As Button
    Friend WithEvents lblajuste As Label
    Friend WithEvents txtAjuste As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFaltantePiloto As TextBox
    Friend WithEvents btnGuardarResumen As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents chkb_opera_recibos As CheckBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgv_pendientes As DataGridView
    Friend WithEvents chkb_pendientes As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_guardapendientes As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lbl_opcion As Label
    Friend WithEvents TabPage5 As TabPage
End Class
