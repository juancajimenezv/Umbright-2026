<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Carga_Precios_Costo
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Carga_Precios_Costo))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OFD_Listas = New System.Windows.Forms.OpenFileDialog
        Me.dgv_Importados = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_Procesar = New System.Windows.Forms.Button
        Me.btn_Importar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_Descartar = New System.Windows.Forms.Button
        Me.dgv_Descartar = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_Limpiar = New System.Windows.Forms.Button
        Me.btn_Enviar = New System.Windows.Forms.Button
        CType(Me.dgv_Importados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Descartar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "4493_excel 2007.png")
        Me.ImageList1.Images.SetKeyName(1, "iconos%20excel1.jpg")
        Me.ImageList1.Images.SetKeyName(2, "icono-excel.gif")
        Me.ImageList1.Images.SetKeyName(3, "filesave.ico")
        Me.ImageList1.Images.SetKeyName(4, "normalfloppy2.png")
        Me.ImageList1.Images.SetKeyName(5, "Listar.png")
        Me.ImageList1.Images.SetKeyName(6, "Procesar.png")
        Me.ImageList1.Images.SetKeyName(7, "check.ico")
        Me.ImageList1.Images.SetKeyName(8, "Descartar.png")
        Me.ImageList1.Images.SetKeyName(9, "Limpiar.png")
        Me.ImageList1.Images.SetKeyName(10, "Transfer Document.png")
        Me.ImageList1.Images.SetKeyName(11, "server_client_exchange.png")
        '
        'OFD_Listas
        '
        Me.OFD_Listas.FileName = "OpenFileDialog1"
        '
        'dgv_Importados
        '
        Me.dgv_Importados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Importados.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Importados.Name = "dgv_Importados"
        Me.dgv_Importados.Size = New System.Drawing.Size(732, 168)
        Me.dgv_Importados.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Procesar)
        Me.GroupBox1.Controls.Add(Me.btn_Importar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 106)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btn_Procesar
        '
        Me.btn_Procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Procesar.ForeColor = System.Drawing.Color.White
        Me.btn_Procesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Procesar.ImageIndex = 6
        Me.btn_Procesar.ImageList = Me.ImageList1
        Me.btn_Procesar.Location = New System.Drawing.Point(229, 19)
        Me.btn_Procesar.Name = "btn_Procesar"
        Me.btn_Procesar.Size = New System.Drawing.Size(75, 61)
        Me.btn_Procesar.TabIndex = 2
        Me.btn_Procesar.Text = "Procesar"
        Me.btn_Procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Procesar.UseVisualStyleBackColor = False
        '
        'btn_Importar
        '
        Me.btn_Importar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Importar.ForeColor = System.Drawing.Color.White
        Me.btn_Importar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Importar.ImageIndex = 2
        Me.btn_Importar.ImageList = Me.ImageList1
        Me.btn_Importar.Location = New System.Drawing.Point(88, 19)
        Me.btn_Importar.Name = "btn_Importar"
        Me.btn_Importar.Size = New System.Drawing.Size(75, 61)
        Me.btn_Importar.TabIndex = 1
        Me.btn_Importar.Text = "Importar"
        Me.btn_Importar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Importar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Descartar)
        Me.GroupBox2.Controls.Add(Me.dgv_Descartar)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 324)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(744, 111)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos Para Descartar"
        '
        'btn_Descartar
        '
        Me.btn_Descartar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Descartar.ForeColor = System.Drawing.Color.White
        Me.btn_Descartar.ImageIndex = 8
        Me.btn_Descartar.ImageList = Me.ImageList1
        Me.btn_Descartar.Location = New System.Drawing.Point(626, 19)
        Me.btn_Descartar.Name = "btn_Descartar"
        Me.btn_Descartar.Size = New System.Drawing.Size(75, 75)
        Me.btn_Descartar.TabIndex = 1
        Me.btn_Descartar.Text = "Descartar"
        Me.btn_Descartar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Descartar.UseVisualStyleBackColor = False
        '
        'dgv_Descartar
        '
        Me.dgv_Descartar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Descartar.Location = New System.Drawing.Point(25, 19)
        Me.dgv_Descartar.Name = "dgv_Descartar"
        Me.dgv_Descartar.Size = New System.Drawing.Size(560, 86)
        Me.dgv_Descartar.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_Importados)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 125)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(744, 193)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Importados"
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_Limpiar.ImageIndex = 9
        Me.btn_Limpiar.ImageList = Me.ImageList1
        Me.btn_Limpiar.Location = New System.Drawing.Point(379, 32)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(76, 61)
        Me.btn_Limpiar.TabIndex = 7
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'btn_Enviar
        '
        Me.btn_Enviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Enviar.ForeColor = System.Drawing.Color.White
        Me.btn_Enviar.ImageIndex = 11
        Me.btn_Enviar.ImageList = Me.ImageList1
        Me.btn_Enviar.Location = New System.Drawing.Point(514, 32)
        Me.btn_Enviar.Name = "btn_Enviar"
        Me.btn_Enviar.Size = New System.Drawing.Size(76, 61)
        Me.btn_Enviar.TabIndex = 8
        Me.btn_Enviar.Text = "Envia Xela"
        Me.btn_Enviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Enviar.UseVisualStyleBackColor = False
        '
        'Frm_Carga_Precios_Costo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(769, 447)
        Me.Controls.Add(Me.btn_Enviar)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Carga_Precios_Costo"
        Me.Text = "Carga Lista De Precios Costo"
        CType(Me.dgv_Importados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_Descartar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Importar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents OFD_Listas As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_Procesar As System.Windows.Forms.Button
    Friend WithEvents dgv_Importados As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_Descartar As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Descartar As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Enviar As System.Windows.Forms.Button
End Class
