<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScript
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridListaScript = New System.Windows.Forms.DataGridView()
        Me.script = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.OpAgregar = New System.Windows.Forms.RadioButton()
        Me.OpAgregarLimpiar = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltabla = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Bar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblFechahora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblServer = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.GridListaScript, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridListaScript
        '
        Me.GridListaScript.AllowUserToAddRows = False
        Me.GridListaScript.AllowUserToDeleteRows = False
        Me.GridListaScript.AllowUserToResizeRows = False
        Me.GridListaScript.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListaScript.BackgroundColor = System.Drawing.Color.White
        Me.GridListaScript.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridListaScript.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridListaScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListaScript.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.script})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridListaScript.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridListaScript.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridListaScript.Location = New System.Drawing.Point(12, 12)
        Me.GridListaScript.MultiSelect = False
        Me.GridListaScript.Name = "GridListaScript"
        Me.GridListaScript.RowHeadersVisible = False
        Me.GridListaScript.Size = New System.Drawing.Size(734, 419)
        Me.GridListaScript.TabIndex = 1
        '
        'script
        '
        Me.script.HeaderText = "Script"
        Me.script.Name = "script"
        Me.script.Width = 732
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(624, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 33)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.Location = New System.Drawing.Point(516, 5)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(106, 33)
        Me.btnEjecutar.TabIndex = 3
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'OpAgregar
        '
        Me.OpAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpAgregar.AutoSize = True
        Me.OpAgregar.Checked = True
        Me.OpAgregar.Location = New System.Drawing.Point(4, 14)
        Me.OpAgregar.Name = "OpAgregar"
        Me.OpAgregar.Size = New System.Drawing.Size(86, 17)
        Me.OpAgregar.TabIndex = 4
        Me.OpAgregar.TabStop = True
        Me.OpAgregar.Text = "Solo Agregar"
        Me.OpAgregar.UseVisualStyleBackColor = True
        '
        'OpAgregarLimpiar
        '
        Me.OpAgregarLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpAgregarLimpiar.AutoSize = True
        Me.OpAgregarLimpiar.Location = New System.Drawing.Point(139, 14)
        Me.OpAgregarLimpiar.Name = "OpAgregarLimpiar"
        Me.OpAgregarLimpiar.Size = New System.Drawing.Size(106, 17)
        Me.OpAgregarLimpiar.TabIndex = 5
        Me.OpAgregarLimpiar.Text = "Limpiar y Agregar"
        Me.OpAgregarLimpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 490)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tabla :"
        '
        'lbltabla
        '
        Me.lbltabla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltabla.Location = New System.Drawing.Point(56, 486)
        Me.lbltabla.Name = "lbltabla"
        Me.lbltabla.Size = New System.Drawing.Size(197, 22)
        Me.lbltabla.TabIndex = 7
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblEstado, Me.Bar1, Me.lblFechahora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 517)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(758, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblEstado
        '
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(32, 17)
        Me.LblEstado.Text = "Listo"
        '
        'Bar1
        '
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(500, 16)
        Me.Bar1.Step = 1
        Me.Bar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'lblFechahora
        '
        Me.lblFechahora.Name = "lblFechahora"
        Me.lblFechahora.Size = New System.Drawing.Size(64, 17)
        Me.lblFechahora.Text = "FechaHora"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'lblServer
        '
        Me.lblServer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblServer.Location = New System.Drawing.Point(302, 486)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(197, 22)
        Me.lblServer.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 490)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Server :"
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.OpAgregarLimpiar)
        Me.Panel1.Controls.Add(Me.OpAgregar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(12, 436)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 45)
        Me.Panel1.TabIndex = 11
        '
        'FrmScript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 539)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lbltabla)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridListaScript)
        Me.Name = "FrmScript"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Execute Script"
        CType(Me.GridListaScript, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridListaScript As System.Windows.Forms.DataGridView
    Friend WithEvents script As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents OpAgregar As System.Windows.Forms.RadioButton
    Friend WithEvents OpAgregarLimpiar As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lbltabla As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LblEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Bar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblFechahora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bw As ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
