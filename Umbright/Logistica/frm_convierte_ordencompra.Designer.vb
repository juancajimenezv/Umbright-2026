<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_convierte_ordencompra
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> '_
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '  If disposing AndAlso components IsNot Nothing Then
    '    components.Dispose()
    ' End If
    ' MyBase.Dispose(disposing)
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    Me.components = New System.ComponentModel.Container
    '    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_convierte_ordencompra))
    '    Me.cmb_proceso = New System.Windows.Forms.ComboBox
    '    Me.btn_limpiar = New System.Windows.Forms.Button
    '    Me.btn_ejecutar = New System.Windows.Forms.Button
    '    Me.Label1 = New System.Windows.Forms.Label
    '    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    '    Me.SuspendLayout()
    '    '
    '    'cmb_proceso
    '    '
    '    Me.cmb_proceso.BackColor = System.Drawing.SystemColors.ControlLight
    '    Me.cmb_proceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    '    Me.cmb_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.cmb_proceso.ForeColor = System.Drawing.Color.DarkRed
    '    Me.cmb_proceso.Location = New System.Drawing.Point(135, 21)
    '    Me.cmb_proceso.Name = "cmb_proceso"
    '    Me.cmb_proceso.Size = New System.Drawing.Size(200, 24)
    '    Me.cmb_proceso.TabIndex = 9
    '    '
    '    'btn_limpiar
    '    '
    '    Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
    '    Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    '    Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.btn_limpiar.ForeColor = System.Drawing.Color.White
    '    Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    '    Me.btn_limpiar.ImageIndex = 1
    '    Me.btn_limpiar.ImageList = Me.ImageList1
    '    Me.btn_limpiar.Location = New System.Drawing.Point(420, 101)
    '    Me.btn_limpiar.Name = "btn_limpiar"
    '    Me.btn_limpiar.Size = New System.Drawing.Size(80, 64)
    '    Me.btn_limpiar.TabIndex = 8
    '    Me.btn_limpiar.Text = "&Limpiar"
    '    Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.btn_limpiar.UseVisualStyleBackColor = False
    '    '
    '    'btn_ejecutar
    '    '
    '    Me.btn_ejecutar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
    '    Me.btn_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    '    Me.btn_ejecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.btn_ejecutar.ForeColor = System.Drawing.Color.White
    '    Me.btn_ejecutar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    '    Me.btn_ejecutar.ImageKey = "running_process.png"
    '    Me.btn_ejecutar.ImageList = Me.ImageList1
    '    Me.btn_ejecutar.Location = New System.Drawing.Point(420, 21)
    '    Me.btn_ejecutar.Name = "btn_ejecutar"
    '    Me.btn_ejecutar.Size = New System.Drawing.Size(80, 64)
    '    Me.btn_ejecutar.TabIndex = 7
    '    Me.btn_ejecutar.Text = "&Ejecutar"
    '    Me.btn_ejecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.btn_ejecutar.UseVisualStyleBackColor = False
    '    '
    '    'Label1
    '    '
    '    Me.Label1.AutoSize = True
    '    Me.Label1.Location = New System.Drawing.Point(47, 25)
    '    Me.Label1.Name = "Label1"
    '    Me.Label1.Size = New System.Drawing.Size(86, 13)
    '    Me.Label1.TabIndex = 10
    '    Me.Label1.Text = "Nombre Proceso"
    '    '
    '    'ImageList1
    '    '
    '    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    '    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '    Me.ImageList1.Images.SetKeyName(0, "running_process.png")
    '    Me.ImageList1.Images.SetKeyName(1, "clear.png")
    '    '
    '    'frm_convierte_ordencompra
    '    '
    '    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    Me.ClientSize = New System.Drawing.Size(539, 355)
    '    Me.Controls.Add(Me.cmb_proceso)
    '    Me.Controls.Add(Me.btn_limpiar)
    '    Me.Controls.Add(Me.btn_ejecutar)
    '    Me.Controls.Add(Me.Label1)
    '    Me.Name = "frm_convierte_ordencompra"
    '    Me.Text = "frm_convierte_ordencompra"
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()

    'End Sub
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_ejecutar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmb_tipodocto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipodocto As System.Windows.Forms.Label
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
End Class
