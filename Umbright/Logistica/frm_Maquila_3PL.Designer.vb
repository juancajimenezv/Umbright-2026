<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Maquila_3PL
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_Documentos = New System.Windows.Forms.TabPage()
        Me.btn_Todos = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Finalizados = New System.Windows.Forms.Button()
        Me.btn_Proceso = New System.Windows.Forms.Button()
        Me.btn_Pendientes = New System.Windows.Forms.Button()
        Me.dgv_Documentos = New System.Windows.Forms.DataGridView()
        Me.tp_Maquila = New System.Windows.Forms.TabPage()
        Me.lb_Finaliza = New System.Windows.Forms.Label()
        Me.lb_Inicia = New System.Windows.Forms.Label()
        Me.btn_Finalizar = New System.Windows.Forms.Button()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.dgv_Detalle = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.tb_Documentos.SuspendLayout()
        CType(Me.dgv_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Maquila.SuspendLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tb_Documentos)
        Me.TabControl1.Controls.Add(Me.tp_Maquila)
        Me.TabControl1.Location = New System.Drawing.Point(4, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(888, 442)
        Me.TabControl1.TabIndex = 0
        '
        'tb_Documentos
        '
        Me.tb_Documentos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tb_Documentos.Controls.Add(Me.btn_Todos)
        Me.tb_Documentos.Controls.Add(Me.Label1)
        Me.tb_Documentos.Controls.Add(Me.btn_Finalizados)
        Me.tb_Documentos.Controls.Add(Me.btn_Proceso)
        Me.tb_Documentos.Controls.Add(Me.btn_Pendientes)
        Me.tb_Documentos.Controls.Add(Me.dgv_Documentos)
        Me.tb_Documentos.Location = New System.Drawing.Point(4, 22)
        Me.tb_Documentos.Name = "tb_Documentos"
        Me.tb_Documentos.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_Documentos.Size = New System.Drawing.Size(880, 416)
        Me.tb_Documentos.TabIndex = 0
        Me.tb_Documentos.Text = "Documentos"
        '
        'btn_Todos
        '
        Me.btn_Todos.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Todos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Todos.Location = New System.Drawing.Point(11, 145)
        Me.btn_Todos.Name = "btn_Todos"
        Me.btn_Todos.Size = New System.Drawing.Size(75, 23)
        Me.btn_Todos.TabIndex = 5
        Me.btn_Todos.Text = "Todos"
        Me.btn_Todos.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ver"
        '
        'btn_Finalizados
        '
        Me.btn_Finalizados.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Finalizados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Finalizados.Location = New System.Drawing.Point(11, 116)
        Me.btn_Finalizados.Name = "btn_Finalizados"
        Me.btn_Finalizados.Size = New System.Drawing.Size(75, 23)
        Me.btn_Finalizados.TabIndex = 3
        Me.btn_Finalizados.Text = "Finalizados"
        Me.btn_Finalizados.UseVisualStyleBackColor = False
        '
        'btn_Proceso
        '
        Me.btn_Proceso.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Proceso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Proceso.Location = New System.Drawing.Point(11, 87)
        Me.btn_Proceso.Name = "btn_Proceso"
        Me.btn_Proceso.Size = New System.Drawing.Size(75, 23)
        Me.btn_Proceso.TabIndex = 2
        Me.btn_Proceso.Text = "En Proceso"
        Me.btn_Proceso.UseVisualStyleBackColor = False
        '
        'btn_Pendientes
        '
        Me.btn_Pendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Pendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Pendientes.Location = New System.Drawing.Point(11, 57)
        Me.btn_Pendientes.Name = "btn_Pendientes"
        Me.btn_Pendientes.Size = New System.Drawing.Size(75, 23)
        Me.btn_Pendientes.TabIndex = 1
        Me.btn_Pendientes.Text = "Pendientes"
        Me.btn_Pendientes.UseVisualStyleBackColor = False
        '
        'dgv_Documentos
        '
        Me.dgv_Documentos.AllowUserToAddRows = False
        Me.dgv_Documentos.AllowUserToDeleteRows = False
        Me.dgv_Documentos.AllowUserToOrderColumns = True
        Me.dgv_Documentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Documentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Documentos.Location = New System.Drawing.Point(99, 16)
        Me.dgv_Documentos.Name = "dgv_Documentos"
        Me.dgv_Documentos.RowHeadersWidth = 20
        Me.dgv_Documentos.Size = New System.Drawing.Size(683, 385)
        Me.dgv_Documentos.TabIndex = 0
        '
        'tp_Maquila
        '
        Me.tp_Maquila.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.tp_Maquila.Controls.Add(Me.lb_Finaliza)
        Me.tp_Maquila.Controls.Add(Me.lb_Inicia)
        Me.tp_Maquila.Controls.Add(Me.btn_Finalizar)
        Me.tp_Maquila.Controls.Add(Me.btn_Iniciar)
        Me.tp_Maquila.Controls.Add(Me.dgv_Detalle)
        Me.tp_Maquila.Location = New System.Drawing.Point(4, 22)
        Me.tp_Maquila.Name = "tp_Maquila"
        Me.tp_Maquila.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_Maquila.Size = New System.Drawing.Size(880, 416)
        Me.tp_Maquila.TabIndex = 1
        Me.tp_Maquila.Text = "Maquila"
        '
        'lb_Finaliza
        '
        Me.lb_Finaliza.AutoSize = True
        Me.lb_Finaliza.Location = New System.Drawing.Point(752, 24)
        Me.lb_Finaliza.Name = "lb_Finaliza"
        Me.lb_Finaliza.Size = New System.Drawing.Size(42, 13)
        Me.lb_Finaliza.TabIndex = 4
        Me.lb_Finaliza.Text = "Finaliza"
        '
        'lb_Inicia
        '
        Me.lb_Inicia.AutoSize = True
        Me.lb_Inicia.Location = New System.Drawing.Point(418, 25)
        Me.lb_Inicia.Name = "lb_Inicia"
        Me.lb_Inicia.Size = New System.Drawing.Size(32, 13)
        Me.lb_Inicia.TabIndex = 3
        Me.lb_Inicia.Text = "Inicia"
        '
        'btn_Finalizar
        '
        Me.btn_Finalizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Finalizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Finalizar.Location = New System.Drawing.Point(624, 6)
        Me.btn_Finalizar.Name = "btn_Finalizar"
        Me.btn_Finalizar.Size = New System.Drawing.Size(91, 49)
        Me.btn_Finalizar.TabIndex = 2
        Me.btn_Finalizar.Text = "Finalizar"
        Me.btn_Finalizar.UseVisualStyleBackColor = False
        '
        'btn_Iniciar
        '
        Me.btn_Iniciar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Iniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_Iniciar.Location = New System.Drawing.Point(525, 6)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(91, 49)
        Me.btn_Iniciar.TabIndex = 1
        Me.btn_Iniciar.Text = "Iniciar"
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'dgv_Detalle
        '
        Me.dgv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detalle.Location = New System.Drawing.Point(6, 61)
        Me.dgv_Detalle.Name = "dgv_Detalle"
        Me.dgv_Detalle.RowHeadersWidth = 20
        Me.dgv_Detalle.Size = New System.Drawing.Size(866, 349)
        Me.dgv_Detalle.TabIndex = 0
        '
        'frm_Maquila_3PL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(892, 447)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_Maquila_3PL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitor Maquila 3PL"
        Me.TabControl1.ResumeLayout(False)
        Me.tb_Documentos.ResumeLayout(False)
        Me.tb_Documentos.PerformLayout()
        CType(Me.dgv_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Maquila.ResumeLayout(False)
        Me.tp_Maquila.PerformLayout()
        CType(Me.dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_Documentos As System.Windows.Forms.TabPage
    Friend WithEvents tp_Maquila As System.Windows.Forms.TabPage
    Friend WithEvents dgv_Documentos As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Finalizar As System.Windows.Forms.Button
    Friend WithEvents btn_Iniciar As System.Windows.Forms.Button
    Friend WithEvents btn_Todos As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Finalizados As System.Windows.Forms.Button
    Friend WithEvents btn_Proceso As System.Windows.Forms.Button
    Friend WithEvents btn_Pendientes As System.Windows.Forms.Button
    Friend WithEvents lb_Finaliza As System.Windows.Forms.Label
    Friend WithEvents lb_Inicia As System.Windows.Forms.Label
End Class
