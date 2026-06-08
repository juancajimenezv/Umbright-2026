<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_HorasExtras_CD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_Ver_Resumen = New System.Windows.Forms.Button
        Me.btn_Ver_Report = New System.Windows.Forms.Button
        Me.btn_Excel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgv_Resumen_Picking = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_ver_reporte = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.dgv_Horas_Extra = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_fec_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_fec_inicio = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgv_Resumen_Picking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_Horas_Extra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Ver_Resumen
        '
        Me.btn_Ver_Resumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Ver_Resumen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Ver_Resumen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ver_Resumen.ForeColor = System.Drawing.Color.White
        Me.btn_Ver_Resumen.Location = New System.Drawing.Point(148, 22)
        Me.btn_Ver_Resumen.Name = "btn_Ver_Resumen"
        Me.btn_Ver_Resumen.Size = New System.Drawing.Size(101, 60)
        Me.btn_Ver_Resumen.TabIndex = 11
        Me.btn_Ver_Resumen.Text = "Ver Resumen"
        Me.btn_Ver_Resumen.UseVisualStyleBackColor = False
        '
        'btn_Ver_Report
        '
        Me.btn_Ver_Report.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Ver_Report.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Ver_Report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ver_Report.ForeColor = System.Drawing.Color.White
        Me.btn_Ver_Report.Location = New System.Drawing.Point(27, 22)
        Me.btn_Ver_Report.Name = "btn_Ver_Report"
        Me.btn_Ver_Report.Size = New System.Drawing.Size(101, 60)
        Me.btn_Ver_Report.TabIndex = 8
        Me.btn_Ver_Report.Text = "Ver Reporte"
        Me.btn_Ver_Report.UseVisualStyleBackColor = False
        '
        'btn_Excel
        '
        Me.btn_Excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Excel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Excel.ForeColor = System.Drawing.Color.White
        Me.btn_Excel.Location = New System.Drawing.Point(267, 22)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(101, 60)
        Me.btn_Excel.TabIndex = 10
        Me.btn_Excel.Text = "Exportar Excel"
        Me.btn_Excel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Hasta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Desde"
        '
        'dgv_Resumen_Picking
        '
        Me.dgv_Resumen_Picking.AllowUserToAddRows = False
        Me.dgv_Resumen_Picking.AllowUserToDeleteRows = False
        Me.dgv_Resumen_Picking.Location = New System.Drawing.Point(12, 398)
        Me.dgv_Resumen_Picking.Name = "dgv_Resumen_Picking"
        Me.dgv_Resumen_Picking.ReadOnly = True
        Me.dgv_Resumen_Picking.Size = New System.Drawing.Size(940, 237)
        Me.dgv_Resumen_Picking.TabIndex = 17
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_ver_reporte)
        Me.GroupBox3.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox3.Location = New System.Drawing.Point(621, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(273, 82)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'btn_ver_reporte
        '
        Me.btn_ver_reporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ver_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ver_reporte.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ver_reporte.ForeColor = System.Drawing.Color.White
        Me.btn_ver_reporte.Location = New System.Drawing.Point(26, 14)
        Me.btn_ver_reporte.Name = "btn_ver_reporte"
        Me.btn_ver_reporte.Size = New System.Drawing.Size(101, 60)
        Me.btn_ver_reporte.TabIndex = 8
        Me.btn_ver_reporte.Text = "Ver Reporte"
        Me.btn_ver_reporte.UseVisualStyleBackColor = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar_excel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.ForeColor = System.Drawing.Color.White
        Me.btn_exportar_excel.Location = New System.Drawing.Point(142, 14)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(103, 60)
        Me.btn_exportar_excel.TabIndex = 10
        Me.btn_exportar_excel.Text = "Exportar Excel"
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'dgv_Horas_Extra
        '
        Me.dgv_Horas_Extra.AllowUserToAddRows = False
        Me.dgv_Horas_Extra.AllowUserToDeleteRows = False
        Me.dgv_Horas_Extra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Horas_Extra.Location = New System.Drawing.Point(12, 109)
        Me.dgv_Horas_Extra.Name = "dgv_Horas_Extra"
        Me.dgv_Horas_Extra.ReadOnly = True
        Me.dgv_Horas_Extra.Size = New System.Drawing.Size(940, 273)
        Me.dgv_Horas_Extra.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(320, 37)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Control de accesos por usuario"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtp_fec_final)
        Me.GroupBox2.Controls.Add(Me.dtp_fec_inicio)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 42)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha"
        '
        'dtp_fec_final
        '
        Me.dtp_fec_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_final.Location = New System.Drawing.Point(217, 13)
        Me.dtp_fec_final.Name = "dtp_fec_final"
        Me.dtp_fec_final.Size = New System.Drawing.Size(85, 20)
        Me.dtp_fec_final.TabIndex = 2
        '
        'dtp_fec_inicio
        '
        Me.dtp_fec_inicio.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtp_fec_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fec_inicio.Location = New System.Drawing.Point(71, 14)
        Me.dtp_fec_inicio.Name = "dtp_fec_inicio"
        Me.dtp_fec_inicio.Size = New System.Drawing.Size(85, 20)
        Me.dtp_fec_inicio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Desde"
        '
        'frm_HorasExtras_CD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(972, 647)
        Me.Controls.Add(Me.dgv_Resumen_Picking)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgv_Horas_Extra)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frm_HorasExtras_CD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horarios Picking"
        CType(Me.dgv_Resumen_Picking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_Horas_Extra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Ver_Resumen As System.Windows.Forms.Button
    Friend WithEvents btn_Ver_Report As System.Windows.Forms.Button
    Friend WithEvents btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_Resumen_Picking As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ver_reporte As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents dgv_Horas_Extra As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_fec_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fec_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
