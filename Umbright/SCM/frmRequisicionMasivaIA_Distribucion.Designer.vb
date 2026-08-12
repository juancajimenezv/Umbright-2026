<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequisicionMasivaIA_Distribucion
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlTipoGasto = New System.Windows.Forms.Panel
        Me.rbAyP = New System.Windows.Forms.RadioButton
        Me.rbItem = New System.Windows.Forms.RadioButton
        Me.lblTipoGasto = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabCC = New System.Windows.Forms.TabPage
        Me.dgvCC = New System.Windows.Forms.DataGridView
        Me.pnlBotonesCC = New System.Windows.Forms.Panel
        Me.btnAgregarCC = New System.Windows.Forms.Button
        Me.btnBuscarCC = New System.Windows.Forms.Button
        Me.btnEliminarCC = New System.Windows.Forms.Button
        Me.tabMarca = New System.Windows.Forms.TabPage
        Me.dgvMarca = New System.Windows.Forms.DataGridView
        Me.pnlBotonesMarca = New System.Windows.Forms.Panel
        Me.btnAgregarMarca = New System.Windows.Forms.Button
        Me.btnBuscarMarca = New System.Windows.Forms.Button
        Me.btnEliminarMarca = New System.Windows.Forms.Button
        Me.tabCanal = New System.Windows.Forms.TabPage
        Me.dgvCanal = New System.Windows.Forms.DataGridView
        Me.pnlBotonesCanal = New System.Windows.Forms.Panel
        Me.btnAgregarCanal = New System.Windows.Forms.Button
        Me.btnBuscarCanal = New System.Windows.Forms.Button
        Me.btnEliminarCanal = New System.Windows.Forms.Button
        Me.tabGasto = New System.Windows.Forms.TabPage
        Me.dgvGasto = New System.Windows.Forms.DataGridView
        Me.pnlBotonesGasto = New System.Windows.Forms.Panel
        Me.btnAgregarGasto = New System.Windows.Forms.Button
        Me.btnBuscarGasto = New System.Windows.Forms.Button
        Me.btnEliminarGasto = New System.Windows.Forms.Button
        Me.pnlAceptarCancelar = New System.Windows.Forms.Panel
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.pnlTipoGasto.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabCC.SuspendLayout()
        CType(Me.dgvCC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesCC.SuspendLayout()
        Me.tabMarca.SuspendLayout()
        CType(Me.dgvMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesMarca.SuspendLayout()
        Me.tabCanal.SuspendLayout()
        CType(Me.dgvCanal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesCanal.SuspendLayout()
        Me.tabGasto.SuspendLayout()
        CType(Me.dgvGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesGasto.SuspendLayout()
        Me.pnlAceptarCancelar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTipoGasto
        '
        Me.pnlTipoGasto.Controls.Add(Me.rbAyP)
        Me.pnlTipoGasto.Controls.Add(Me.rbItem)
        Me.pnlTipoGasto.Controls.Add(Me.lblTipoGasto)
        Me.pnlTipoGasto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTipoGasto.Location = New System.Drawing.Point(0, 0)
        Me.pnlTipoGasto.Name = "pnlTipoGasto"
        Me.pnlTipoGasto.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlTipoGasto.Size = New System.Drawing.Size(920, 44)
        Me.pnlTipoGasto.TabIndex = 0
        '
        'rbAyP
        '
        Me.rbAyP.Location = New System.Drawing.Point(200, 12)
        Me.rbAyP.Name = "rbAyP"
        Me.rbAyP.Size = New System.Drawing.Size(120, 24)
        Me.rbAyP.TabIndex = 2
        Me.rbAyP.Text = "A&&P"
        Me.rbAyP.UseVisualStyleBackColor = True
        '
        'rbItem
        '
        Me.rbItem.Checked = True
        Me.rbItem.Location = New System.Drawing.Point(90, 12)
        Me.rbItem.Name = "rbItem"
        Me.rbItem.Size = New System.Drawing.Size(100, 24)
        Me.rbItem.TabIndex = 1
        Me.rbItem.TabStop = True
        Me.rbItem.Text = "ITEM"
        Me.rbItem.UseVisualStyleBackColor = True
        '
        'lblTipoGasto
        '
        Me.lblTipoGasto.AutoSize = True
        Me.lblTipoGasto.Location = New System.Drawing.Point(8, 16)
        Me.lblTipoGasto.Name = "lblTipoGasto"
        Me.lblTipoGasto.Size = New System.Drawing.Size(70, 13)
        Me.lblTipoGasto.TabIndex = 0
        Me.lblTipoGasto.Text = "Tipo de Gasto"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabCC)
        Me.TabControl1.Controls.Add(Me.tabMarca)
        Me.TabControl1.Controls.Add(Me.tabCanal)
        Me.TabControl1.Controls.Add(Me.tabGasto)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 44)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(920, 416)
        Me.TabControl1.TabIndex = 1
        '
        'tabCC
        '
        Me.tabCC.Controls.Add(Me.dgvCC)
        Me.tabCC.Controls.Add(Me.pnlBotonesCC)
        Me.tabCC.Location = New System.Drawing.Point(4, 22)
        Me.tabCC.Name = "tabCC"
        Me.tabCC.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCC.Size = New System.Drawing.Size(912, 390)
        Me.tabCC.TabIndex = 0
        Me.tabCC.Text = "Centro de Costo"
        Me.tabCC.UseVisualStyleBackColor = True
        '
        'dgvCC
        '
        Me.dgvCC.AllowUserToAddRows = False
        Me.dgvCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCC.Location = New System.Drawing.Point(3, 3)
        Me.dgvCC.Name = "dgvCC"
        Me.dgvCC.Size = New System.Drawing.Size(906, 344)
        Me.dgvCC.TabIndex = 0
        '
        'pnlBotonesCC
        '
        Me.pnlBotonesCC.Controls.Add(Me.btnAgregarCC)
        Me.pnlBotonesCC.Controls.Add(Me.btnBuscarCC)
        Me.pnlBotonesCC.Controls.Add(Me.btnEliminarCC)
        Me.pnlBotonesCC.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesCC.Location = New System.Drawing.Point(3, 347)
        Me.pnlBotonesCC.Name = "pnlBotonesCC"
        Me.pnlBotonesCC.Size = New System.Drawing.Size(906, 40)
        Me.pnlBotonesCC.TabIndex = 1
        '
        'btnAgregarCC
        '
        Me.btnAgregarCC.Location = New System.Drawing.Point(4, 6)
        Me.btnAgregarCC.Name = "btnAgregarCC"
        Me.btnAgregarCC.Size = New System.Drawing.Size(90, 28)
        Me.btnAgregarCC.TabIndex = 0
        Me.btnAgregarCC.Text = "Agregar"
        Me.btnAgregarCC.UseVisualStyleBackColor = True
        '
        'btnBuscarCC
        '
        Me.btnBuscarCC.Location = New System.Drawing.Point(100, 6)
        Me.btnBuscarCC.Name = "btnBuscarCC"
        Me.btnBuscarCC.Size = New System.Drawing.Size(120, 28)
        Me.btnBuscarCC.TabIndex = 1
        Me.btnBuscarCC.Text = "Buscar Código"
        Me.btnBuscarCC.UseVisualStyleBackColor = True
        '
        'btnEliminarCC
        '
        Me.btnEliminarCC.Location = New System.Drawing.Point(226, 6)
        Me.btnEliminarCC.Name = "btnEliminarCC"
        Me.btnEliminarCC.Size = New System.Drawing.Size(90, 28)
        Me.btnEliminarCC.TabIndex = 2
        Me.btnEliminarCC.Text = "Eliminar"
        Me.btnEliminarCC.UseVisualStyleBackColor = True
        '
        'tabMarca
        '
        Me.tabMarca.Controls.Add(Me.dgvMarca)
        Me.tabMarca.Controls.Add(Me.pnlBotonesMarca)
        Me.tabMarca.Location = New System.Drawing.Point(4, 22)
        Me.tabMarca.Name = "tabMarca"
        Me.tabMarca.Size = New System.Drawing.Size(912, 390)
        Me.tabMarca.TabIndex = 1
        Me.tabMarca.Text = "Marca"
        Me.tabMarca.UseVisualStyleBackColor = True
        '
        'dgvMarca
        '
        Me.dgvMarca.AllowUserToAddRows = False
        Me.dgvMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMarca.Location = New System.Drawing.Point(0, 0)
        Me.dgvMarca.Name = "dgvMarca"
        Me.dgvMarca.Size = New System.Drawing.Size(912, 350)
        Me.dgvMarca.TabIndex = 0
        '
        'pnlBotonesMarca
        '
        Me.pnlBotonesMarca.Controls.Add(Me.btnAgregarMarca)
        Me.pnlBotonesMarca.Controls.Add(Me.btnBuscarMarca)
        Me.pnlBotonesMarca.Controls.Add(Me.btnEliminarMarca)
        Me.pnlBotonesMarca.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesMarca.Location = New System.Drawing.Point(0, 350)
        Me.pnlBotonesMarca.Name = "pnlBotonesMarca"
        Me.pnlBotonesMarca.Size = New System.Drawing.Size(912, 40)
        Me.pnlBotonesMarca.TabIndex = 1
        '
        'btnAgregarMarca
        '
        Me.btnAgregarMarca.Location = New System.Drawing.Point(4, 6)
        Me.btnAgregarMarca.Name = "btnAgregarMarca"
        Me.btnAgregarMarca.Size = New System.Drawing.Size(90, 28)
        Me.btnAgregarMarca.TabIndex = 0
        Me.btnAgregarMarca.Text = "Agregar"
        Me.btnAgregarMarca.UseVisualStyleBackColor = True
        '
        'btnBuscarMarca
        '
        Me.btnBuscarMarca.Location = New System.Drawing.Point(100, 6)
        Me.btnBuscarMarca.Name = "btnBuscarMarca"
        Me.btnBuscarMarca.Size = New System.Drawing.Size(120, 28)
        Me.btnBuscarMarca.TabIndex = 1
        Me.btnBuscarMarca.Text = "Buscar Código"
        Me.btnBuscarMarca.UseVisualStyleBackColor = True
        '
        'btnEliminarMarca
        '
        Me.btnEliminarMarca.Location = New System.Drawing.Point(226, 6)
        Me.btnEliminarMarca.Name = "btnEliminarMarca"
        Me.btnEliminarMarca.Size = New System.Drawing.Size(90, 28)
        Me.btnEliminarMarca.TabIndex = 2
        Me.btnEliminarMarca.Text = "Eliminar"
        Me.btnEliminarMarca.UseVisualStyleBackColor = True
        '
        'tabCanal
        '
        Me.tabCanal.Controls.Add(Me.dgvCanal)
        Me.tabCanal.Controls.Add(Me.pnlBotonesCanal)
        Me.tabCanal.Location = New System.Drawing.Point(4, 22)
        Me.tabCanal.Name = "tabCanal"
        Me.tabCanal.Size = New System.Drawing.Size(912, 390)
        Me.tabCanal.TabIndex = 2
        Me.tabCanal.Text = "Canal"
        Me.tabCanal.UseVisualStyleBackColor = True
        '
        'dgvCanal
        '
        Me.dgvCanal.AllowUserToAddRows = False
        Me.dgvCanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCanal.Location = New System.Drawing.Point(0, 0)
        Me.dgvCanal.Name = "dgvCanal"
        Me.dgvCanal.Size = New System.Drawing.Size(912, 350)
        Me.dgvCanal.TabIndex = 0
        '
        'pnlBotonesCanal
        '
        Me.pnlBotonesCanal.Controls.Add(Me.btnAgregarCanal)
        Me.pnlBotonesCanal.Controls.Add(Me.btnBuscarCanal)
        Me.pnlBotonesCanal.Controls.Add(Me.btnEliminarCanal)
        Me.pnlBotonesCanal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesCanal.Location = New System.Drawing.Point(0, 350)
        Me.pnlBotonesCanal.Name = "pnlBotonesCanal"
        Me.pnlBotonesCanal.Size = New System.Drawing.Size(912, 40)
        Me.pnlBotonesCanal.TabIndex = 1
        '
        'btnAgregarCanal
        '
        Me.btnAgregarCanal.Location = New System.Drawing.Point(4, 6)
        Me.btnAgregarCanal.Name = "btnAgregarCanal"
        Me.btnAgregarCanal.Size = New System.Drawing.Size(90, 28)
        Me.btnAgregarCanal.TabIndex = 0
        Me.btnAgregarCanal.Text = "Agregar"
        Me.btnAgregarCanal.UseVisualStyleBackColor = True
        '
        'btnBuscarCanal
        '
        Me.btnBuscarCanal.Location = New System.Drawing.Point(100, 6)
        Me.btnBuscarCanal.Name = "btnBuscarCanal"
        Me.btnBuscarCanal.Size = New System.Drawing.Size(120, 28)
        Me.btnBuscarCanal.TabIndex = 1
        Me.btnBuscarCanal.Text = "Buscar Código"
        Me.btnBuscarCanal.UseVisualStyleBackColor = True
        '
        'btnEliminarCanal
        '
        Me.btnEliminarCanal.Location = New System.Drawing.Point(226, 6)
        Me.btnEliminarCanal.Name = "btnEliminarCanal"
        Me.btnEliminarCanal.Size = New System.Drawing.Size(90, 28)
        Me.btnEliminarCanal.TabIndex = 2
        Me.btnEliminarCanal.Text = "Eliminar"
        Me.btnEliminarCanal.UseVisualStyleBackColor = True
        '
        'tabGasto
        '
        Me.tabGasto.Controls.Add(Me.dgvGasto)
        Me.tabGasto.Controls.Add(Me.pnlBotonesGasto)
        Me.tabGasto.Location = New System.Drawing.Point(4, 22)
        Me.tabGasto.Name = "tabGasto"
        Me.tabGasto.Size = New System.Drawing.Size(912, 390)
        Me.tabGasto.TabIndex = 3
        Me.tabGasto.Text = "Item de Gasto"
        Me.tabGasto.UseVisualStyleBackColor = True
        '
        'dgvGasto
        '
        Me.dgvGasto.AllowUserToAddRows = False
        Me.dgvGasto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGasto.Location = New System.Drawing.Point(0, 0)
        Me.dgvGasto.Name = "dgvGasto"
        Me.dgvGasto.Size = New System.Drawing.Size(912, 350)
        Me.dgvGasto.TabIndex = 0
        '
        'pnlBotonesGasto
        '
        Me.pnlBotonesGasto.Controls.Add(Me.btnAgregarGasto)
        Me.pnlBotonesGasto.Controls.Add(Me.btnBuscarGasto)
        Me.pnlBotonesGasto.Controls.Add(Me.btnEliminarGasto)
        Me.pnlBotonesGasto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesGasto.Location = New System.Drawing.Point(0, 350)
        Me.pnlBotonesGasto.Name = "pnlBotonesGasto"
        Me.pnlBotonesGasto.Size = New System.Drawing.Size(912, 40)
        Me.pnlBotonesGasto.TabIndex = 1
        '
        'btnAgregarGasto
        '
        Me.btnAgregarGasto.Location = New System.Drawing.Point(4, 6)
        Me.btnAgregarGasto.Name = "btnAgregarGasto"
        Me.btnAgregarGasto.Size = New System.Drawing.Size(90, 28)
        Me.btnAgregarGasto.TabIndex = 0
        Me.btnAgregarGasto.Text = "Agregar"
        Me.btnAgregarGasto.UseVisualStyleBackColor = True
        '
        'btnBuscarGasto
        '
        Me.btnBuscarGasto.Location = New System.Drawing.Point(100, 6)
        Me.btnBuscarGasto.Name = "btnBuscarGasto"
        Me.btnBuscarGasto.Size = New System.Drawing.Size(120, 28)
        Me.btnBuscarGasto.TabIndex = 1
        Me.btnBuscarGasto.Text = "Buscar Código"
        Me.btnBuscarGasto.UseVisualStyleBackColor = True
        '
        'btnEliminarGasto
        '
        Me.btnEliminarGasto.Location = New System.Drawing.Point(226, 6)
        Me.btnEliminarGasto.Name = "btnEliminarGasto"
        Me.btnEliminarGasto.Size = New System.Drawing.Size(90, 28)
        Me.btnEliminarGasto.TabIndex = 2
        Me.btnEliminarGasto.Text = "Eliminar"
        Me.btnEliminarGasto.UseVisualStyleBackColor = True
        '
        'pnlAceptarCancelar
        '
        Me.pnlAceptarCancelar.Controls.Add(Me.btnAceptar)
        Me.pnlAceptarCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlAceptarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAceptarCancelar.Location = New System.Drawing.Point(0, 460)
        Me.pnlAceptarCancelar.Name = "pnlAceptarCancelar"
        Me.pnlAceptarCancelar.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlAceptarCancelar.Size = New System.Drawing.Size(920, 48)
        Me.pnlAceptarCancelar.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(730, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(821, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRequisicionMasivaIA_Distribucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 508)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pnlAceptarCancelar)
        Me.Controls.Add(Me.pnlTipoGasto)
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Name = "frmRequisicionMasivaIA_Distribucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Distribución de la Requisición (Centro de Costo / Marca / Canal / Gasto)"
        Me.pnlTipoGasto.ResumeLayout(False)
        Me.pnlTipoGasto.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabCC.ResumeLayout(False)
        CType(Me.dgvCC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesCC.ResumeLayout(False)
        Me.tabMarca.ResumeLayout(False)
        CType(Me.dgvMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesMarca.ResumeLayout(False)
        Me.tabCanal.ResumeLayout(False)
        CType(Me.dgvCanal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesCanal.ResumeLayout(False)
        Me.tabGasto.ResumeLayout(False)
        CType(Me.dgvGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesGasto.ResumeLayout(False)
        Me.pnlAceptarCancelar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTipoGasto As System.Windows.Forms.Panel
    Friend WithEvents rbAyP As System.Windows.Forms.RadioButton
    Friend WithEvents rbItem As System.Windows.Forms.RadioButton
    Friend WithEvents lblTipoGasto As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabCC As System.Windows.Forms.TabPage
    Friend WithEvents dgvCC As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonesCC As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarCC As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCC As System.Windows.Forms.Button
    Friend WithEvents btnEliminarCC As System.Windows.Forms.Button
    Friend WithEvents tabMarca As System.Windows.Forms.TabPage
    Friend WithEvents dgvMarca As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonesMarca As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarMarca As System.Windows.Forms.Button
    Friend WithEvents btnBuscarMarca As System.Windows.Forms.Button
    Friend WithEvents btnEliminarMarca As System.Windows.Forms.Button
    Friend WithEvents tabCanal As System.Windows.Forms.TabPage
    Friend WithEvents dgvCanal As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonesCanal As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarCanal As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCanal As System.Windows.Forms.Button
    Friend WithEvents btnEliminarCanal As System.Windows.Forms.Button
    Friend WithEvents tabGasto As System.Windows.Forms.TabPage
    Friend WithEvents dgvGasto As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonesGasto As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarGasto As System.Windows.Forms.Button
    Friend WithEvents btnBuscarGasto As System.Windows.Forms.Button
    Friend WithEvents btnEliminarGasto As System.Windows.Forms.Button
    Friend WithEvents pnlAceptarCancelar As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

End Class
