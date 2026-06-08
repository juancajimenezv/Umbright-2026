<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nombre_corto
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nombre_corto))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_nit = New System.Windows.Forms.Label()
        Me.txt_motivo_consumo = New System.Windows.Forms.TextBox()
        Me.txt_segmento = New System.Windows.Forms.TextBox()
        Me.txt_clasificacion = New System.Windows.Forms.TextBox()
        Me.txt_nombre_corto = New System.Windows.Forms.TextBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubCanal = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSubCanal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbl_nit)
        Me.GroupBox1.Controls.Add(Me.txt_motivo_consumo)
        Me.GroupBox1.Controls.Add(Me.txt_segmento)
        Me.GroupBox1.Controls.Add(Me.txt_clasificacion)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_corto)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 151)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Motivo Consumo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Segmento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Clasificacion"
        '
        'lbl_nit
        '
        Me.lbl_nit.AutoSize = True
        Me.lbl_nit.BackColor = System.Drawing.Color.Transparent
        Me.lbl_nit.ForeColor = System.Drawing.Color.Black
        Me.lbl_nit.Location = New System.Drawing.Point(6, 22)
        Me.lbl_nit.Name = "lbl_nit"
        Me.lbl_nit.Size = New System.Drawing.Size(72, 13)
        Me.lbl_nit.TabIndex = 1
        Me.lbl_nit.Text = "Nombre Corto"
        '
        'txt_motivo_consumo
        '
        Me.txt_motivo_consumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_motivo_consumo.Location = New System.Drawing.Point(93, 116)
        Me.txt_motivo_consumo.Name = "txt_motivo_consumo"
        Me.txt_motivo_consumo.Size = New System.Drawing.Size(302, 20)
        Me.txt_motivo_consumo.TabIndex = 5
        '
        'txt_segmento
        '
        Me.txt_segmento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_segmento.Location = New System.Drawing.Point(93, 90)
        Me.txt_segmento.Name = "txt_segmento"
        Me.txt_segmento.Size = New System.Drawing.Size(302, 20)
        Me.txt_segmento.TabIndex = 4
        '
        'txt_clasificacion
        '
        Me.txt_clasificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_clasificacion.Location = New System.Drawing.Point(93, 66)
        Me.txt_clasificacion.Name = "txt_clasificacion"
        Me.txt_clasificacion.Size = New System.Drawing.Size(302, 20)
        Me.txt_clasificacion.TabIndex = 3
        '
        'txt_nombre_corto
        '
        Me.txt_nombre_corto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_corto.Location = New System.Drawing.Point(93, 20)
        Me.txt_nombre_corto.Name = "txt_nombre_corto"
        Me.txt_nombre_corto.Size = New System.Drawing.Size(302, 20)
        Me.txt_nombre_corto.TabIndex = 1
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.ImageKey = "cerrar1.jpg"
        Me.btn_cancelar.ImageList = Me.ImageList1
        Me.btn_cancelar.Location = New System.Drawing.Point(432, 14)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(78, 59)
        Me.btn_cancelar.TabIndex = 4
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "floppy_disk_48.png")
        Me.ImageList1.Images.SetKeyName(1, "cerrar1.jpg")
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageKey = "floppy_disk_48.png"
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(432, 90)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(78, 59)
        Me.btn_guardar.TabIndex = 3
        Me.btn_guardar.Text = "Grabar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "SubCanal"
        '
        'txtSubCanal
        '
        Me.txtSubCanal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubCanal.Location = New System.Drawing.Point(93, 43)
        Me.txtSubCanal.Name = "txtSubCanal"
        Me.txtSubCanal.Size = New System.Drawing.Size(302, 20)
        Me.txtSubCanal.TabIndex = 7
        '
        'frm_nombre_corto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(521, 173)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frm_nombre_corto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nombre Corto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_nit As System.Windows.Forms.Label
    Friend WithEvents txt_motivo_consumo As System.Windows.Forms.TextBox
    Friend WithEvents txt_segmento As System.Windows.Forms.TextBox
    Friend WithEvents txt_clasificacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_corto As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSubCanal As TextBox
End Class
