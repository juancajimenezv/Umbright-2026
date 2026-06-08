<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_HOrarioAlmuerzo
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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_Fecha_Inicio = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_Guardar = New System.Windows.Forms.Button
        Me.dtp_Hora_Entrada = New System.Windows.Forms.DateTimePicker
        Me.dtp_Hora_Salida = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgv_Historial = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dtp_Fecha_Final = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_Division = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.clbx_empleados = New System.Windows.Forms.CheckedListBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.chkPermanente = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Historial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre"
        '
        'dtp_Fecha_Inicio
        '
        Me.dtp_Fecha_Inicio.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtp_Fecha_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha_Inicio.Location = New System.Drawing.Point(64, 19)
        Me.dtp_Fecha_Inicio.Name = "dtp_Fecha_Inicio"
        Me.dtp_Fecha_Inicio.Size = New System.Drawing.Size(85, 20)
        Me.dtp_Fecha_Inicio.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Salida"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Entrada"
        '
        'btn_Guardar
        '
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.btn_Guardar.Location = New System.Drawing.Point(390, 182)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(100, 69)
        Me.btn_Guardar.TabIndex = 9
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = False
        '
        'dtp_Hora_Entrada
        '
        Me.dtp_Hora_Entrada.CustomFormat = "HH:mm"
        Me.dtp_Hora_Entrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Hora_Entrada.Location = New System.Drawing.Point(85, 19)
        Me.dtp_Hora_Entrada.Name = "dtp_Hora_Entrada"
        Me.dtp_Hora_Entrada.ShowUpDown = True
        Me.dtp_Hora_Entrada.Size = New System.Drawing.Size(56, 20)
        Me.dtp_Hora_Entrada.TabIndex = 10
        Me.dtp_Hora_Entrada.TabStop = False
        Me.dtp_Hora_Entrada.Value = New Date(2013, 4, 30, 13, 0, 0, 0)
        '
        'dtp_Hora_Salida
        '
        Me.dtp_Hora_Salida.CustomFormat = "HH:mm"
        Me.dtp_Hora_Salida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Hora_Salida.Location = New System.Drawing.Point(85, 43)
        Me.dtp_Hora_Salida.Name = "dtp_Hora_Salida"
        Me.dtp_Hora_Salida.ShowUpDown = True
        Me.dtp_Hora_Salida.Size = New System.Drawing.Size(56, 20)
        Me.dtp_Hora_Salida.TabIndex = 11
        Me.dtp_Hora_Salida.Value = New Date(2013, 4, 30, 14, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtp_Hora_Salida)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtp_Hora_Entrada)
        Me.GroupBox1.Location = New System.Drawing.Point(204, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(158, 70)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Horario"
        '
        'dgv_Historial
        '
        Me.dgv_Historial.AllowUserToAddRows = False
        Me.dgv_Historial.AllowUserToDeleteRows = False
        Me.dgv_Historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Historial.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_Historial.Location = New System.Drawing.Point(12, 257)
        Me.dgv_Historial.Name = "dgv_Historial"
        Me.dgv_Historial.ReadOnly = True
        Me.dgv_Historial.RowHeadersWidth = 20
        Me.dgv_Historial.Size = New System.Drawing.Size(478, 291)
        Me.dgv_Historial.TabIndex = 13
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(122, 26)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'dtp_Fecha_Final
        '
        Me.dtp_Fecha_Final.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtp_Fecha_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Fecha_Final.Location = New System.Drawing.Point(64, 45)
        Me.dtp_Fecha_Final.Name = "dtp_Fecha_Final"
        Me.dtp_Fecha_Final.Size = New System.Drawing.Size(85, 20)
        Me.dtp_Fecha_Final.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Division"
        '
        'cmb_Division
        '
        Me.cmb_Division.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Division.FormattingEnabled = True
        Me.cmb_Division.Location = New System.Drawing.Point(59, 15)
        Me.cmb_Division.Name = "cmb_Division"
        Me.cmb_Division.Size = New System.Drawing.Size(303, 21)
        Me.cmb_Division.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtp_Fecha_Inicio)
        Me.GroupBox2.Controls.Add(Me.dtp_Fecha_Final)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 69)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Desde"
        '
        'clbx_empleados
        '
        Me.clbx_empleados.FormattingEnabled = True
        Me.clbx_empleados.Location = New System.Drawing.Point(59, 42)
        Me.clbx_empleados.Name = "clbx_empleados"
        Me.clbx_empleados.Size = New System.Drawing.Size(303, 124)
        Me.clbx_empleados.TabIndex = 19
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(509, 24)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(509, 24)
        Me.MenuStrip2.TabIndex = 21
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'chkPermanente
        '
        Me.chkPermanente.AutoSize = True
        Me.chkPermanente.Location = New System.Drawing.Point(369, 149)
        Me.chkPermanente.Name = "chkPermanente"
        Me.chkPermanente.Size = New System.Drawing.Size(121, 17)
        Me.chkPermanente.TabIndex = 22
        Me.chkPermanente.Text = "Cambio Permanente"
        Me.chkPermanente.UseVisualStyleBackColor = True
        '
        'frm_HOrarioAlmuerzo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(509, 560)
        Me.Controls.Add(Me.chkPermanente)
        Me.Controls.Add(Me.clbx_empleados)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmb_Division)
        Me.Controls.Add(Me.dgv_Historial)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_HOrarioAlmuerzo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horarios Almuerzos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_Historial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents dtp_Hora_Entrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Hora_Salida As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Historial As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_Fecha_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_Division As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents clbx_empleados As System.Windows.Forms.CheckedListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents chkPermanente As System.Windows.Forms.CheckBox
End Class
