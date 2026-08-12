<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequisicionesMasivasIA
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rtbHistorial = New System.Windows.Forms.RichTextBox()
        Me.pnlEntrada = New System.Windows.Forms.Panel()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.dgvBorrador = New System.Windows.Forms.DataGridView()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardarValidas = New System.Windows.Forms.Button()
        Me.btnConfigurarApiKey = New System.Windows.Forms.Button()
        Me.btnDescartar = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlEntrada.SuspendLayout()
        CType(Me.dgvBorrador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbHistorial)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlEntrada)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBorrador)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblContador)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlBotones)
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 620)
        Me.SplitContainer1.SplitterDistance = 460
        Me.SplitContainer1.TabIndex = 0
        '
        'rtbHistorial
        '
        Me.rtbHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbHistorial.Location = New System.Drawing.Point(0, 0)
        Me.rtbHistorial.Name = "rtbHistorial"
        Me.rtbHistorial.ReadOnly = True
        Me.rtbHistorial.Size = New System.Drawing.Size(460, 580)
        Me.rtbHistorial.TabIndex = 0
        Me.rtbHistorial.Text = ""
        '
        'pnlEntrada
        '
        Me.pnlEntrada.Controls.Add(Me.btnEnviar)
        Me.pnlEntrada.Controls.Add(Me.txtMensaje)
        Me.pnlEntrada.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEntrada.Location = New System.Drawing.Point(0, 580)
        Me.pnlEntrada.Name = "pnlEntrada"
        Me.pnlEntrada.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlEntrada.Size = New System.Drawing.Size(460, 40)
        Me.pnlEntrada.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEnviar.Location = New System.Drawing.Point(382, 4)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(74, 32)
        Me.btnEnviar.TabIndex = 1
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMensaje.Location = New System.Drawing.Point(4, 4)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(452, 32)
        Me.txtMensaje.TabIndex = 0
        '
        'dgvBorrador
        '
        Me.dgvBorrador.AllowUserToAddRows = False
        Me.dgvBorrador.AllowUserToDeleteRows = False
        Me.dgvBorrador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBorrador.Location = New System.Drawing.Point(0, 32)
        Me.dgvBorrador.Name = "dgvBorrador"
        Me.dgvBorrador.ReadOnly = True
        Me.dgvBorrador.Size = New System.Drawing.Size(536, 548)
        Me.dgvBorrador.TabIndex = 1
        '
        'lblContador
        '
        Me.lblContador.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblContador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblContador.Location = New System.Drawing.Point(0, 0)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Padding = New System.Windows.Forms.Padding(6)
        Me.lblContador.Size = New System.Drawing.Size(536, 32)
        Me.lblContador.TabIndex = 0
        Me.lblContador.Text = "0 requisiciones"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardarValidas)
        Me.pnlBotones.Controls.Add(Me.btnConfigurarApiKey)
        Me.pnlBotones.Controls.Add(Me.btnDescartar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotones.Location = New System.Drawing.Point(0, 580)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlBotones.Size = New System.Drawing.Size(536, 40)
        Me.pnlBotones.TabIndex = 2
        '
        'btnGuardarValidas
        '
        Me.btnGuardarValidas.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGuardarValidas.Location = New System.Drawing.Point(4, 4)
        Me.btnGuardarValidas.Name = "btnGuardarValidas"
        Me.btnGuardarValidas.Size = New System.Drawing.Size(140, 32)
        Me.btnGuardarValidas.TabIndex = 0
        Me.btnGuardarValidas.Text = "Guardar Válidas"
        Me.btnGuardarValidas.UseVisualStyleBackColor = True
        '
        'btnConfigurarApiKey
        '
        Me.btnConfigurarApiKey.Location = New System.Drawing.Point(160, 4)
        Me.btnConfigurarApiKey.Name = "btnConfigurarApiKey"
        Me.btnConfigurarApiKey.Size = New System.Drawing.Size(140, 32)
        Me.btnConfigurarApiKey.TabIndex = 2
        Me.btnConfigurarApiKey.Text = "Configurar API Key"
        Me.btnConfigurarApiKey.UseVisualStyleBackColor = True
        '
        'btnDescartar
        '
        Me.btnDescartar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDescartar.Location = New System.Drawing.Point(416, 4)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(116, 32)
        Me.btnDescartar.TabIndex = 1
        Me.btnDescartar.Text = "Descartar Todo"
        Me.btnDescartar.UseVisualStyleBackColor = True
        '
        'frmRequisicionesMasivasIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 620)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MinimumSize = New System.Drawing.Size(700, 400)
        Me.Name = "frmRequisicionesMasivasIA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Requisiciones Masivas (IA)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlEntrada.ResumeLayout(False)
        Me.pnlEntrada.PerformLayout()
        CType(Me.dgvBorrador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rtbHistorial As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlEntrada As System.Windows.Forms.Panel
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents dgvBorrador As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarValidas As System.Windows.Forms.Button
    Friend WithEvents btnConfigurarApiKey As System.Windows.Forms.Button

End Class
