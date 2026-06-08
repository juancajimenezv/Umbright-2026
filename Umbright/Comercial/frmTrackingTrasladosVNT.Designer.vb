<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTrackingTrasladosVNT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrackingTrasladosVNT))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.dtp_fechafinal = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbWalmart = New System.Windows.Forms.GroupBox()
        Me.dgDetalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_aprobacion = New System.Windows.Forms.TextBox()
        Me.txt_total_pedido = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.txt_tipo_pedido = New System.Windows.Forms.TextBox()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dg_control_transporte = New System.Windows.Forms.DataGrid()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dg_picking = New System.Windows.Forms.DataGrid()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGrid()
        Me.txtNumeroPedido = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.gbWalmart.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Actualizar.png")
        Me.ImageList1.Images.SetKeyName(1, "limpiar2.jpg")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1060, 685)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnGenerar)
        Me.TabPage1.Controls.Add(Me.btnLimpiar)
        Me.TabPage1.Controls.Add(Me.dtp_fechafinal)
        Me.TabPage1.Controls.Add(Me.dtp_fechaInicio)
        Me.TabPage1.Controls.Add(Me.dgvListado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1052, 659)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerar.ImageKey = "Actualizar.png"
        Me.btnGenerar.ImageList = Me.ImageList1
        Me.btnGenerar.Location = New System.Drawing.Point(408, 6)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 56)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.White
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.ImageKey = "limpiar2.jpg"
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(949, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 56)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'dtp_fechafinal
        '
        Me.dtp_fechafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechafinal.Location = New System.Drawing.Point(277, 32)
        Me.dtp_fechafinal.Name = "dtp_fechafinal"
        Me.dtp_fechafinal.Size = New System.Drawing.Size(84, 20)
        Me.dtp_fechafinal.TabIndex = 1
        '
        'dtp_fechaInicio
        '
        Me.dtp_fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechaInicio.Location = New System.Drawing.Point(277, 6)
        Me.dtp_fechaInicio.Name = "dtp_fechaInicio"
        Me.dtp_fechaInicio.Size = New System.Drawing.Size(84, 20)
        Me.dtp_fechaInicio.TabIndex = 1
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(8, 68)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 20
        Me.dgvListado.Size = New System.Drawing.Size(1037, 585)
        Me.dgvListado.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.gbWalmart)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.lblAnio)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.txtNumeroPedido)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1052, 659)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        '
        'gbWalmart
        '
        Me.gbWalmart.Controls.Add(Me.dgDetalle)
        Me.gbWalmart.Location = New System.Drawing.Point(5, 380)
        Me.gbWalmart.Name = "gbWalmart"
        Me.gbWalmart.Size = New System.Drawing.Size(1040, 338)
        Me.gbWalmart.TabIndex = 15
        Me.gbWalmart.TabStop = False
        Me.gbWalmart.Text = "Detalle"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowUserToAddRows = False
        Me.dgDetalle.AllowUserToDeleteRows = False
        Me.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetalle.Location = New System.Drawing.Point(12, 19)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.Size = New System.Drawing.Size(1022, 260)
        Me.dgDetalle.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_aprobacion)
        Me.GroupBox2.Controls.Add(Me.txt_total_pedido)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_fecha)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Controls.Add(Me.txt_tipo_pedido)
        Me.GroupBox2.Controls.Add(Me.txt_comentario)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(19, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(984, 105)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Traslado"
        '
        'txt_aprobacion
        '
        Me.txt_aprobacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_aprobacion.Location = New System.Drawing.Point(806, 19)
        Me.txt_aprobacion.Name = "txt_aprobacion"
        Me.txt_aprobacion.ReadOnly = True
        Me.txt_aprobacion.Size = New System.Drawing.Size(90, 20)
        Me.txt_aprobacion.TabIndex = 16
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_pedido.Location = New System.Drawing.Point(644, 17)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(80, 20)
        Me.txt_total_pedido.TabIndex = 19
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(590, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Total Pedido"
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(448, 17)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(80, 20)
        Me.txt_fecha.TabIndex = 14
        Me.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(267, 17)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.ReadOnly = True
        Me.txt_numero.Size = New System.Drawing.Size(112, 20)
        Me.txt_numero.TabIndex = 13
        '
        'txt_tipo_pedido
        '
        Me.txt_tipo_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo_pedido.Location = New System.Drawing.Point(80, 17)
        Me.txt_tipo_pedido.Name = "txt_tipo_pedido"
        Me.txt_tipo_pedido.ReadOnly = True
        Me.txt_tipo_pedido.Size = New System.Drawing.Size(128, 20)
        Me.txt_tipo_pedido.TabIndex = 10
        '
        'txt_comentario
        '
        Me.txt_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentario.Location = New System.Drawing.Point(80, 45)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ReadOnly = True
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(897, 40)
        Me.txt_comentario.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 23)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Comentario"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(760, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Estado"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(402, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(214, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dg_control_transporte)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 221)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1035, 75)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Control de Transporte"
        '
        'dg_control_transporte
        '
        Me.dg_control_transporte.CaptionVisible = False
        Me.dg_control_transporte.DataMember = ""
        Me.dg_control_transporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderFont = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_control_transporte.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_control_transporte.Location = New System.Drawing.Point(8, 12)
        Me.dg_control_transporte.Name = "dg_control_transporte"
        Me.dg_control_transporte.ReadOnly = True
        Me.dg_control_transporte.Size = New System.Drawing.Size(1021, 60)
        Me.dg_control_transporte.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dg_picking)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 143)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1035, 69)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Picking"
        '
        'dg_picking
        '
        Me.dg_picking.CaptionVisible = False
        Me.dg_picking.DataMember = ""
        Me.dg_picking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_picking.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_picking.Location = New System.Drawing.Point(8, 12)
        Me.dg_picking.Name = "dg_picking"
        Me.dg_picking.ReadOnly = True
        Me.dg_picking.Size = New System.Drawing.Size(1021, 60)
        Me.dg_picking.TabIndex = 3
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(181, 8)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(44, 13)
        Me.lblAnio.TabIndex = 12
        Me.lblAnio.Text = "Numero"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 302)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1040, 72)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Relacionado"
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.CaptionVisible = False
        Me.dg_devoluciones.DataMember = ""
        Me.dg_devoluciones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_devoluciones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_devoluciones.Location = New System.Drawing.Point(8, 12)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.ReadOnly = True
        Me.dg_devoluciones.Size = New System.Drawing.Size(1026, 55)
        Me.dg_devoluciones.TabIndex = 1
        '
        'txtNumeroPedido
        '
        Me.txtNumeroPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroPedido.Location = New System.Drawing.Point(246, 6)
        Me.txtNumeroPedido.Name = "txtNumeroPedido"
        Me.txtNumeroPedido.ReadOnly = True
        Me.txtNumeroPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroPedido.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Fecha Final"
        '
        'frmTrackingTrasladosVNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1054, 686)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmTrackingTrasladosVNT"
        Me.Text = ":: Tracking de Traslados ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.gbWalmart.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dg_control_transporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dg_picking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_comentario As TextBox
    Friend WithEvents txt_tipo_pedido As TextBox
    Friend WithEvents txt_numero As TextBox
    Friend WithEvents txt_fecha As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_total_pedido As TextBox
    Friend WithEvents txt_aprobacion As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dg_control_transporte As DataGrid
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dg_picking As DataGrid
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dg_devoluciones As DataGrid
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtNumeroPedido As TextBox
    Friend WithEvents lblAnio As Label
    Friend WithEvents dgDetalle As DataGridView
    Friend WithEvents gbWalmart As GroupBox
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dtp_fechafinal As DateTimePicker
    Friend WithEvents dtp_fechaInicio As DateTimePicker
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
End Class
