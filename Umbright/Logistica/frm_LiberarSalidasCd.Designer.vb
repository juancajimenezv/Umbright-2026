<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LiberarSalidasCd
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
        Me.cmb_e_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_e_empresa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Liberar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_e_TipoDocto
        '
        Me.cmb_e_TipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_e_TipoDocto.FormattingEnabled = True
        Me.cmb_e_TipoDocto.Items.AddRange(New Object() {"SALIDA TRASLADO CD"})
        Me.cmb_e_TipoDocto.Location = New System.Drawing.Point(124, 62)
        Me.cmb_e_TipoDocto.Name = "cmb_e_TipoDocto"
        Me.cmb_e_TipoDocto.Size = New System.Drawing.Size(226, 21)
        Me.cmb_e_TipoDocto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Documento"
        '
        'cmb_e_empresa
        '
        Me.cmb_e_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_e_empresa.FormattingEnabled = True
        Me.cmb_e_empresa.Location = New System.Drawing.Point(124, 35)
        Me.cmb_e_empresa.Name = "cmb_e_empresa"
        Me.cmb_e_empresa.Size = New System.Drawing.Size(226, 21)
        Me.cmb_e_empresa.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Empresa"
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(124, 89)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(100, 20)
        Me.txt_numero.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Número"
        '
        'btn_Liberar
        '
        Me.btn_Liberar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Liberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Liberar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Liberar.ForeColor = System.Drawing.Color.White
        Me.btn_Liberar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Liberar.Location = New System.Drawing.Point(124, 146)
        Me.btn_Liberar.Name = "btn_Liberar"
        Me.btn_Liberar.Size = New System.Drawing.Size(96, 55)
        Me.btn_Liberar.TabIndex = 3
        Me.btn_Liberar.Text = "LIBERAR"
        Me.btn_Liberar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.ForeColor = System.Drawing.Color.White
        Me.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cancelar.Location = New System.Drawing.Point(240, 146)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(96, 55)
        Me.btn_Cancelar.TabIndex = 8
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'frm_LiberarSalidasCd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(423, 213)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Liberar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_numero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_e_empresa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_e_TipoDocto)
        Me.Name = "frm_LiberarSalidasCd"
        Me.Text = "Liberar Salidas CD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_e_TipoDocto As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_e_empresa As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_numero As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_Liberar As Button
    Friend WithEvents btn_Cancelar As Button
End Class
