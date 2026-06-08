<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Traslada_Personal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Traslada_Personal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_Nombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_Ficha = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_Empresa_Destino = New System.Windows.Forms.ComboBox()
        Me.cb_Empresa_Origen = New System.Windows.Forms.ComboBox()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Traslada = New System.Windows.Forms.Button()
        Me.ckb_Vacaciones = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckb_Vacaciones)
        Me.GroupBox1.Controls.Add(Me.lb_Nombre)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tb_Ficha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cb_Empresa_Destino)
        Me.GroupBox1.Controls.Add(Me.cb_Empresa_Origen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(348, 244)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lb_Nombre
        '
        Me.lb_Nombre.AutoSize = True
        Me.lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Nombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lb_Nombre.Location = New System.Drawing.Point(43, 204)
        Me.lb_Nombre.Name = "lb_Nombre"
        Me.lb_Nombre.Size = New System.Drawing.Size(50, 13)
        Me.lb_Nombre.TabIndex = 19
        Me.lb_Nombre.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Datos:"
        '
        'tb_Ficha
        '
        Me.tb_Ficha.Location = New System.Drawing.Point(153, 108)
        Me.tb_Ficha.Name = "tb_Ficha"
        Me.tb_Ficha.Size = New System.Drawing.Size(118, 20)
        Me.tb_Ficha.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(99, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Ficha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Empresa Destino:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Empresa Origen:"
        '
        'cb_Empresa_Destino
        '
        Me.cb_Empresa_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa_Destino.FormattingEnabled = True
        Me.cb_Empresa_Destino.Items.AddRange(New Object() {"", "ALAMSA", "CODICASA", "COSERCA", "DIMAEXSA", "DIUVA", "DMARTE1", "LOGISERV", "TECNO", "UMBRAL", "VINOTECA"})
        Me.cb_Empresa_Destino.Location = New System.Drawing.Point(153, 73)
        Me.cb_Empresa_Destino.Name = "cb_Empresa_Destino"
        Me.cb_Empresa_Destino.Size = New System.Drawing.Size(118, 21)
        Me.cb_Empresa_Destino.TabIndex = 16
        '
        'cb_Empresa_Origen
        '
        Me.cb_Empresa_Origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa_Origen.FormattingEnabled = True
        Me.cb_Empresa_Origen.Items.AddRange(New Object() {"", "ALAMSA", "CODICASA", "COSERCA", "DIMAEXSA", "DIUVA", "DMARTE1", "LOGISERV", "TECNO", "UMBRAL", "VINOTECA"})
        Me.cb_Empresa_Origen.Location = New System.Drawing.Point(153, 35)
        Me.cb_Empresa_Origen.Name = "cb_Empresa_Origen"
        Me.cb_Empresa_Origen.Size = New System.Drawing.Size(118, 21)
        Me.cb_Empresa_Origen.TabIndex = 15
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Limpiar.Location = New System.Drawing.Point(84, 264)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Limpiar.TabIndex = 1
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'btn_Traslada
        '
        Me.btn_Traslada.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Traslada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Traslada.Location = New System.Drawing.Point(208, 264)
        Me.btn_Traslada.Name = "btn_Traslada"
        Me.btn_Traslada.Size = New System.Drawing.Size(75, 23)
        Me.btn_Traslada.TabIndex = 2
        Me.btn_Traslada.Text = "Trasladar"
        Me.btn_Traslada.UseVisualStyleBackColor = False
        '
        'ckb_Vacaciones
        '
        Me.ckb_Vacaciones.AutoSize = True
        Me.ckb_Vacaciones.Location = New System.Drawing.Point(153, 144)
        Me.ckb_Vacaciones.Name = "ckb_Vacaciones"
        Me.ckb_Vacaciones.Size = New System.Drawing.Size(181, 17)
        Me.ckb_Vacaciones.TabIndex = 20
        Me.ckb_Vacaciones.Text = "Traslada Historial de Vacaciones"
        Me.ckb_Vacaciones.UseVisualStyleBackColor = True
        '
        'Frm_Traslada_Personal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(372, 295)
        Me.Controls.Add(Me.btn_Traslada)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Traslada_Personal"
        Me.Text = "Traslada Personal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Empresa_Origen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_Empresa_Destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_Ficha As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Traslada As System.Windows.Forms.Button
    Friend WithEvents lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents ckb_Vacaciones As System.Windows.Forms.CheckBox
End Class
