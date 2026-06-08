<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Costo__Ingreso_CD
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
        Me.cb_TipoDocto = New System.Windows.Forms.ComboBox()
        Me.tb_Numero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.btn_Ejecutar = New System.Windows.Forms.Button()
        Me.Detalle = New System.Windows.Forms.GroupBox()
        Me.btn_Dai = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Actualizar = New System.Windows.Forms.Button()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Detalle.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb_TipoDocto
        '
        Me.cb_TipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipoDocto.FormattingEnabled = True
        Me.cb_TipoDocto.Location = New System.Drawing.Point(85, 35)
        Me.cb_TipoDocto.Name = "cb_TipoDocto"
        Me.cb_TipoDocto.Size = New System.Drawing.Size(316, 21)
        Me.cb_TipoDocto.TabIndex = 0
        '
        'tb_Numero
        '
        Me.tb_Numero.Location = New System.Drawing.Point(462, 36)
        Me.tb_Numero.Name = "tb_Numero"
        Me.tb_Numero.Size = New System.Drawing.Size(100, 20)
        Me.tb_Numero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Documento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(412, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Numero:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.btn_Nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_Ejecutar)
        Me.GroupBox1.Controls.Add(Me.cb_TipoDocto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tb_Numero)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Identificación"
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Location = New System.Drawing.Point(588, 69)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.btn_Imprimir.TabIndex = 7
        Me.btn_Imprimir.Text = "Imprimir"
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Location = New System.Drawing.Point(588, 43)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_Nuevo.TabIndex = 6
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'btn_Ejecutar
        '
        Me.btn_Ejecutar.Location = New System.Drawing.Point(588, 17)
        Me.btn_Ejecutar.Name = "btn_Ejecutar"
        Me.btn_Ejecutar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Ejecutar.TabIndex = 5
        Me.btn_Ejecutar.Text = "Ejecutar"
        Me.btn_Ejecutar.UseVisualStyleBackColor = True
        '
        'Detalle
        '
        Me.Detalle.Controls.Add(Me.btn_Dai)
        Me.Detalle.Controls.Add(Me.Label4)
        Me.Detalle.Controls.Add(Me.Label3)
        Me.Detalle.Controls.Add(Me.btn_Actualizar)
        Me.Detalle.Controls.Add(Me.dgv_Detalle)
        Me.Detalle.Location = New System.Drawing.Point(25, 129)
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Size = New System.Drawing.Size(679, 255)
        Me.Detalle.TabIndex = 5
        Me.Detalle.TabStop = False
        Me.Detalle.Text = "Detalle"
        '
        'btn_Dai
        '
        Me.btn_Dai.Location = New System.Drawing.Point(509, 18)
        Me.btn_Dai.Name = "btn_Dai"
        Me.btn_Dai.Size = New System.Drawing.Size(75, 23)
        Me.btn_Dai.TabIndex = 4
        Me.btn_Dai.Text = "DAI"
        Me.btn_Dai.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(151, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'btn_Actualizar
        '
        Me.btn_Actualizar.Location = New System.Drawing.Point(588, 17)
        Me.btn_Actualizar.Name = "btn_Actualizar"
        Me.btn_Actualizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Actualizar.TabIndex = 1
        Me.btn_Actualizar.Text = "Actualizar"
        Me.btn_Actualizar.UseVisualStyleBackColor = True
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.AllowUserToAddRows = False
        Me.dgv_Detalle.AllowUserToDeleteRows = False
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 50)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.Size = New System.Drawing.Size(667, 196)
        Me.dgv_Detalle.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(79, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(590, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Nota Importante: Aplicacion Exclusivamente Para Diferencias En Centavos por Conce" & _
    "pto de Etiquetas."
        '
        'Frm_Costo__Ingreso_CD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 399)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Detalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Costo__Ingreso_CD"
        Me.Text = "Costo Ingreso Centro Distribución"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Detalle.ResumeLayout(False)
        Me.Detalle.PerformLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_TipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Ejecutar As System.Windows.Forms.Button
    Friend WithEvents Detalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Actualizar As System.Windows.Forms.Button
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_Dai As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
