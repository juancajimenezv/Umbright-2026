<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_impresoras1
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_impresora_actual = New System.Windows.Forms.TextBox()
        Me.cmb_tipoDocto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_impresoras = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_aplicar = New System.Windows.Forms.Button()
        Me.dgv_impresoras_disponibles = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_impresoras_disponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(202, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "IMPRESORAS DISPONIBLES"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_impresora_actual)
        Me.GroupBox1.Controls.Add(Me.cmb_tipoDocto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_empresa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_impresoras)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_aplicar)
        Me.GroupBox1.Location = New System.Drawing.Point(74, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 139)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Impresora Actual"
        '
        'txt_impresora_actual
        '
        Me.txt_impresora_actual.Location = New System.Drawing.Point(115, 76)
        Me.txt_impresora_actual.Name = "txt_impresora_actual"
        Me.txt_impresora_actual.ReadOnly = True
        Me.txt_impresora_actual.Size = New System.Drawing.Size(219, 20)
        Me.txt_impresora_actual.TabIndex = 9
        '
        'cmb_tipoDocto
        '
        Me.cmb_tipoDocto.FormattingEnabled = True
        Me.cmb_tipoDocto.Location = New System.Drawing.Point(116, 45)
        Me.cmb_tipoDocto.Name = "cmb_tipoDocto"
        Me.cmb_tipoDocto.Size = New System.Drawing.Size(219, 21)
        Me.cmb_tipoDocto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Impresoras"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"CODICASA", "DIUVA", "DMARTE1", "VINOTECA", "DIMAEXSA", "TECNO", "LOGISERV", "PURITA", "ALAMSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(116, 18)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(219, 21)
        Me.cmb_empresa.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo Documento"
        '
        'cmb_impresoras
        '
        Me.cmb_impresoras.FormattingEnabled = True
        Me.cmb_impresoras.Location = New System.Drawing.Point(116, 105)
        Me.cmb_impresoras.Name = "cmb_impresoras"
        Me.cmb_impresoras.Size = New System.Drawing.Size(219, 21)
        Me.cmb_impresoras.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Empresa"
        '
        'btn_aplicar
        '
        Me.btn_aplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_aplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_aplicar.Location = New System.Drawing.Point(352, 16)
        Me.btn_aplicar.Name = "btn_aplicar"
        Me.btn_aplicar.Size = New System.Drawing.Size(69, 30)
        Me.btn_aplicar.TabIndex = 4
        Me.btn_aplicar.Text = "Aplicar"
        Me.btn_aplicar.UseVisualStyleBackColor = False
        '
        'dgv_impresoras_disponibles
        '
        Me.dgv_impresoras_disponibles.AllowUserToAddRows = False
        Me.dgv_impresoras_disponibles.AllowUserToDeleteRows = False
        Me.dgv_impresoras_disponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_impresoras_disponibles.Location = New System.Drawing.Point(120, 50)
        Me.dgv_impresoras_disponibles.Name = "dgv_impresoras_disponibles"
        Me.dgv_impresoras_disponibles.RowHeadersWidth = 25
        Me.dgv_impresoras_disponibles.Size = New System.Drawing.Size(336, 124)
        Me.dgv_impresoras_disponibles.TabIndex = 10
        '
        'frm_impresoras1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(616, 356)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_impresoras_disponibles)
        Me.Name = "frm_impresoras1"
        Me.Text = "::Impresoras::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_impresoras_disponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_impresora_actual As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_impresoras As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_aplicar As System.Windows.Forms.Button
    Friend WithEvents dgv_impresoras_disponibles As System.Windows.Forms.DataGridView
End Class
