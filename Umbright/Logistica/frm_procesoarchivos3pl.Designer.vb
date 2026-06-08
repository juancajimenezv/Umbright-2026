<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_procesoarchivos3pl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_procesoarchivos3pl))
        Me.btn_BuscarArchivo3PL = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnProcesar3PL = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_BuscarArchivo3PL
        '
        Me.btn_BuscarArchivo3PL.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_BuscarArchivo3PL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_BuscarArchivo3PL.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_BuscarArchivo3PL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_BuscarArchivo3PL.ImageIndex = 1
        Me.btn_BuscarArchivo3PL.ImageList = Me.ImageList1
        Me.btn_BuscarArchivo3PL.Location = New System.Drawing.Point(34, 12)
        Me.btn_BuscarArchivo3PL.Name = "btn_BuscarArchivo3PL"
        Me.btn_BuscarArchivo3PL.Size = New System.Drawing.Size(148, 43)
        Me.btn_BuscarArchivo3PL.TabIndex = 0
        Me.btn_BuscarArchivo3PL.Text = "BUSCAR ARCHIVO"
        Me.btn_BuscarArchivo3PL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_BuscarArchivo3PL.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(34, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(542, 20)
        Me.TextBox1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 119)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(1082, 281)
        Me.DataGridView1.TabIndex = 3
        '
        'btnProcesar3PL
        '
        Me.btnProcesar3PL.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesar3PL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnProcesar3PL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnProcesar3PL.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnProcesar3PL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar3PL.ImageIndex = 0
        Me.btnProcesar3PL.ImageList = Me.ImageList1
        Me.btnProcesar3PL.Location = New System.Drawing.Point(603, 18)
        Me.btnProcesar3PL.Name = "btnProcesar3PL"
        Me.btnProcesar3PL.Size = New System.Drawing.Size(101, 67)
        Me.btnProcesar3PL.TabIndex = 4
        Me.btnProcesar3PL.Text = "PROCESAR"
        Me.btnProcesar3PL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar3PL.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(34, 90)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "GuateFacturas"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(1, "buscar.png")
        Me.ImageList1.Images.SetKeyName(2, "procesar.jpg")
        '
        'frm_procesoarchivos3pl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1084, 412)
        Me.Controls.Add(Me.btnProcesar3PL)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_BuscarArchivo3PL)
        Me.Name = "frm_procesoarchivos3pl"
        Me.Text = "PROCESO ARCHIVOS 3PL"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscarArchivo3PL As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesar3PL As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
