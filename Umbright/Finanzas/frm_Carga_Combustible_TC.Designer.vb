<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Carga_Combustible_TC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Carga_Combustible_TC))
        Me.btn_Carga_Archivo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_registros = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_Convertir = New System.Windows.Forms.Button()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumeroLiquidacion = New System.Windows.Forms.Label()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Carga_Archivo
        '
        Me.btn_Carga_Archivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Carga_Archivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Carga_Archivo.ForeColor = System.Drawing.Color.White
        Me.btn_Carga_Archivo.Location = New System.Drawing.Point(6, 14)
        Me.btn_Carga_Archivo.Name = "btn_Carga_Archivo"
        Me.btn_Carga_Archivo.Size = New System.Drawing.Size(113, 73)
        Me.btn_Carga_Archivo.TabIndex = 1
        Me.btn_Carga_Archivo.Text = "Cargar Archivo"
        Me.btn_Carga_Archivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Carga_Archivo.UseVisualStyleBackColor = False
        Me.btn_Carga_Archivo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(764, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero de Registros:"
        '
        'lb_registros
        '
        Me.lb_registros.AutoSize = True
        Me.lb_registros.Location = New System.Drawing.Point(879, 69)
        Me.lb_registros.Name = "lb_registros"
        Me.lb_registros.Size = New System.Drawing.Size(13, 13)
        Me.lb_registros.TabIndex = 3
        Me.lb_registros.Text = "0"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btn_Convertir
        '
        Me.btn_Convertir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Convertir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Convertir.ForeColor = System.Drawing.Color.White
        Me.btn_Convertir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Convertir.ImageIndex = 3
        Me.btn_Convertir.ImageList = Me.ImageList2
        Me.btn_Convertir.Location = New System.Drawing.Point(979, 14)
        Me.btn_Convertir.Name = "btn_Convertir"
        Me.btn_Convertir.Size = New System.Drawing.Size(93, 73)
        Me.btn_Convertir.TabIndex = 4
        Me.btn_Convertir.Text = "Convertir"
        Me.btn_Convertir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Convertir.UseVisualStyleBackColor = False
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(879, 85)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(13, 13)
        Me.lblMonto.TabIndex = 5
        Me.lblMonto.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(764, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Monto:"
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AllowUserToAddRows = False
        Me.dgv_Detalle.AllowUserToOrderColumns = True
        Me.dgv_Detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 106)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.ReadOnly = True
        Me.dgv_Detalle.RowHeadersWidth = 20
        Me.dgv_Detalle.Size = New System.Drawing.Size(1066, 344)
        Me.dgv_Detalle.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(691, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Liquidacion No.:"
        '
        'lblNumeroLiquidacion
        '
        Me.lblNumeroLiquidacion.AutoSize = True
        Me.lblNumeroLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroLiquidacion.Location = New System.Drawing.Point(854, 16)
        Me.lblNumeroLiquidacion.Name = "lblNumeroLiquidacion"
        Me.lblNumeroLiquidacion.Size = New System.Drawing.Size(23, 25)
        Me.lblNumeroLiquidacion.TabIndex = 3
        Me.lblNumeroLiquidacion.Text = "0"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(693, 46)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(13, 13)
        Me.lblCorreo.TabIndex = 7
        Me.lblCorreo.Text = "0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1092, 482)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.lblCorreo)
        Me.TabPage1.Controls.Add(Me.btn_Carga_Archivo)
        Me.TabPage1.Controls.Add(Me.dgv_Detalle)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblMonto)
        Me.TabPage1.Controls.Add(Me.lb_registros)
        Me.TabPage1.Controls.Add(Me.btn_Convertir)
        Me.TabPage1.Controls.Add(Me.lblNumeroLiquidacion)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1084, 456)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Proceso"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 5
        Me.Button1.ImageList = Me.ImageList3
        Me.Button1.Location = New System.Drawing.Point(125, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 73)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Rechazar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btnActualizar)
        Me.TabPage2.Controls.Add(Me.dgvListado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1084, 456)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.ImageIndex = 2
        Me.btnActualizar.ImageList = Me.ImageList2
        Me.btnActualizar.Location = New System.Drawing.Point(957, 17)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(71, 60)
        Me.btnActualizar.TabIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(8, 83)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.Size = New System.Drawing.Size(1064, 367)
        Me.dgvListado.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
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
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "")
        Me.ImageList3.Images.SetKeyName(1, "")
        Me.ImageList3.Images.SetKeyName(2, "")
        Me.ImageList3.Images.SetKeyName(3, "")
        Me.ImageList3.Images.SetKeyName(4, "")
        Me.ImageList3.Images.SetKeyName(5, "cancel1.jpg")
        '
        'frm_Carga_Combustible_TC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1088, 485)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_Carga_Combustible_TC"
        Me.Text = "::. Carga Combustible TC .::"
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Carga_Archivo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lb_registros As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btn_Convertir As Button
    Friend WithEvents lblMonto As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv_Detalle As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNumeroLiquidacion As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents ImageList3 As ImageList
End Class
