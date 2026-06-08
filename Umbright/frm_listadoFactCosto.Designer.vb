<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_listadoFactCosto
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listadoFactCosto))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvListado = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_refrescar = New System.Windows.Forms.TextBox
        Me.lbl_tipo_impresion = New System.Windows.Forms.Label
        Me.Btn_Buscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvReimpresion = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnImprimirReimpresion = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.dtpInicioReimpresion = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFinalReimpresion = New System.Windows.Forms.DateTimePicker
        Me.btnActualizarReimpresion = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvReimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(8, 81)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 25
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListado.Size = New System.Drawing.Size(776, 301)
        Me.dgvListado.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 416)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txt_refrescar)
        Me.TabPage1.Controls.Add(Me.lbl_tipo_impresion)
        Me.TabPage1.Controls.Add(Me.Btn_Buscar)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_final)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_inicio)
        Me.TabPage1.Controls.Add(Me.btn_imprimir)
        Me.TabPage1.Controls.Add(Me.dgvListado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 390)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Facturaciones al Costo Pendientes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(487, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 16)
        Me.Label11.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Orange
        Me.Label10.Location = New System.Drawing.Point(400, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(513, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = ">  60 Min"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(422, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 16)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "> 30 Min"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(116, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 16)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Minutos"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(3, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Verif Cada"
        '
        'txt_refrescar
        '
        Me.txt_refrescar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_refrescar.Location = New System.Drawing.Point(68, 50)
        Me.txt_refrescar.Name = "txt_refrescar"
        Me.txt_refrescar.Size = New System.Drawing.Size(40, 20)
        Me.txt_refrescar.TabIndex = 34
        Me.txt_refrescar.Text = "5"
        Me.txt_refrescar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_tipo_impresion
        '
        Me.lbl_tipo_impresion.AutoSize = True
        Me.lbl_tipo_impresion.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_impresion.Location = New System.Drawing.Point(268, 12)
        Me.lbl_tipo_impresion.Name = "lbl_tipo_impresion"
        Me.lbl_tipo_impresion.Size = New System.Drawing.Size(416, 32)
        Me.lbl_tipo_impresion.TabIndex = 33
        Me.lbl_tipo_impresion.Text = "Impresion Facturacion al Costo"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Buscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.White
        Me.Btn_Buscar.Image = CType(resources.GetObject("Btn_Buscar.Image"), System.Drawing.Image)
        Me.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Buscar.Location = New System.Drawing.Point(172, 5)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(80, 64)
        Me.Btn_Buscar.TabIndex = 31
        Me.Btn_Buscar.Text = "Actualizar"
        Me.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Del"
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(68, 28)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final.TabIndex = 28
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(68, 5)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio.TabIndex = 27
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(696, 6)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(88, 64)
        Me.btn_imprimir.TabIndex = 32
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dgvReimpresion)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.btnImprimirReimpresion)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.dtpInicioReimpresion)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.dtpFinalReimpresion)
        Me.TabPage2.Controls.Add(Me.btnActualizarReimpresion)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(792, 390)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Facturaciones al  Costo Impresas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(116, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Minutos"
        '
        'dgvReimpresion
        '
        Me.dgvReimpresion.AllowUserToAddRows = False
        Me.dgvReimpresion.AllowUserToDeleteRows = False
        Me.dgvReimpresion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReimpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReimpresion.Location = New System.Drawing.Point(8, 81)
        Me.dgvReimpresion.Name = "dgvReimpresion"
        Me.dgvReimpresion.RowHeadersWidth = 25
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvReimpresion.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReimpresion.Size = New System.Drawing.Size(776, 301)
        Me.dgvReimpresion.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Verif Cada"
        '
        'btnImprimirReimpresion
        '
        Me.btnImprimirReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirReimpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnImprimirReimpresion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimirReimpresion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirReimpresion.ForeColor = System.Drawing.Color.White
        Me.btnImprimirReimpresion.Image = CType(resources.GetObject("btnImprimirReimpresion.Image"), System.Drawing.Image)
        Me.btnImprimirReimpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirReimpresion.Location = New System.Drawing.Point(696, 6)
        Me.btnImprimirReimpresion.Name = "btnImprimirReimpresion"
        Me.btnImprimirReimpresion.Size = New System.Drawing.Size(88, 64)
        Me.btnImprimirReimpresion.TabIndex = 43
        Me.btnImprimirReimpresion.Text = "Imprimir"
        Me.btnImprimirReimpresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirReimpresion.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(68, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(40, 20)
        Me.TextBox1.TabIndex = 45
        Me.TextBox1.Text = "5"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpInicioReimpresion
        '
        Me.dtpInicioReimpresion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicioReimpresion.Location = New System.Drawing.Point(68, 5)
        Me.dtpInicioReimpresion.Name = "dtpInicioReimpresion"
        Me.dtpInicioReimpresion.Size = New System.Drawing.Size(88, 20)
        Me.dtpInicioReimpresion.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(268, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(429, 32)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Re-Impresion Facturacion Costo"
        '
        'dtpFinalReimpresion
        '
        Me.dtpFinalReimpresion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinalReimpresion.Location = New System.Drawing.Point(68, 28)
        Me.dtpFinalReimpresion.Name = "dtpFinalReimpresion"
        Me.dtpFinalReimpresion.Size = New System.Drawing.Size(88, 20)
        Me.dtpFinalReimpresion.TabIndex = 39
        '
        'btnActualizarReimpresion
        '
        Me.btnActualizarReimpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnActualizarReimpresion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnActualizarReimpresion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarReimpresion.ForeColor = System.Drawing.Color.White
        Me.btnActualizarReimpresion.Image = CType(resources.GetObject("btnActualizarReimpresion.Image"), System.Drawing.Image)
        Me.btnActualizarReimpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizarReimpresion.Location = New System.Drawing.Point(172, 5)
        Me.btnActualizarReimpresion.Name = "btnActualizarReimpresion"
        Me.btnActualizarReimpresion.Size = New System.Drawing.Size(80, 64)
        Me.btnActualizarReimpresion.TabIndex = 42
        Me.btnActualizarReimpresion.Text = "Actualizar"
        Me.btnActualizarReimpresion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizarReimpresion.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Del"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Al"
        '
        'frm_listadoFactCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 416)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_listadoFactCosto"
        Me.Text = ":: Listado de Facturaciones al Costo ::"
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvReimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_refrescar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipo_impresion As System.Windows.Forms.Label
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnActualizarReimpresion As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFinalReimpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicioReimpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnImprimirReimpresion As System.Windows.Forms.Button
    Friend WithEvents dgvReimpresion As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
