<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequisicionMasivaIA_Cabecera
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
        Me.pnlCabecera = New System.Windows.Forms.Panel
        Me.lblNombreProveedor = New System.Windows.Forms.Label
        Me.btnBuscarProveedor = New System.Windows.Forms.Button
        Me.txtProveedor = New System.Windows.Forms.TextBox
        Me.lblProveedor = New System.Windows.Forms.Label
        Me.cmbMoneda = New System.Windows.Forms.ComboBox
        Me.lblMoneda = New System.Windows.Forms.Label
        Me.txtLugarEntrega = New System.Windows.Forms.TextBox
        Me.lblLugarEntrega = New System.Windows.Forms.Label
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.lblFechaEntrega = New System.Windows.Forms.Label
        Me.cmbAfectaInventario = New System.Windows.Forms.ComboBox
        Me.lblAfectaInventario = New System.Windows.Forms.Label
        Me.txtMontoAnticipo = New System.Windows.Forms.TextBox
        Me.lblMontoAnticipo = New System.Windows.Forms.Label
        Me.cmbAnticipo = New System.Windows.Forms.ComboBox
        Me.lblAnticipo = New System.Windows.Forms.Label
        Me.cmbCadena = New System.Windows.Forms.ComboBox
        Me.lblCadena = New System.Windows.Forms.Label
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.dgvLineas = New System.Windows.Forms.DataGridView
        Me.pnlBotonesLineas = New System.Windows.Forms.Panel
        Me.btnEliminarLinea = New System.Windows.Forms.Button
        Me.btnEditarLinea = New System.Windows.Forms.Button
        Me.btnAgregarLinea = New System.Windows.Forms.Button
        Me.btnDistribucion = New System.Windows.Forms.Button
        Me.pnlAceptarCancelar = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.pnlCabecera.SuspendLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesLineas.SuspendLayout()
        Me.pnlAceptarCancelar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Controls.Add(Me.lblNombreProveedor)
        Me.pnlCabecera.Controls.Add(Me.btnBuscarProveedor)
        Me.pnlCabecera.Controls.Add(Me.txtProveedor)
        Me.pnlCabecera.Controls.Add(Me.lblProveedor)
        Me.pnlCabecera.Controls.Add(Me.cmbMoneda)
        Me.pnlCabecera.Controls.Add(Me.lblMoneda)
        Me.pnlCabecera.Controls.Add(Me.txtLugarEntrega)
        Me.pnlCabecera.Controls.Add(Me.lblLugarEntrega)
        Me.pnlCabecera.Controls.Add(Me.dtpFechaEntrega)
        Me.pnlCabecera.Controls.Add(Me.lblFechaEntrega)
        Me.pnlCabecera.Controls.Add(Me.cmbAfectaInventario)
        Me.pnlCabecera.Controls.Add(Me.lblAfectaInventario)
        Me.pnlCabecera.Controls.Add(Me.txtMontoAnticipo)
        Me.pnlCabecera.Controls.Add(Me.lblMontoAnticipo)
        Me.pnlCabecera.Controls.Add(Me.cmbAnticipo)
        Me.pnlCabecera.Controls.Add(Me.lblAnticipo)
        Me.pnlCabecera.Controls.Add(Me.cmbCadena)
        Me.pnlCabecera.Controls.Add(Me.lblCadena)
        Me.pnlCabecera.Controls.Add(Me.txtObservaciones)
        Me.pnlCabecera.Controls.Add(Me.lblObservaciones)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlCabecera.Size = New System.Drawing.Size(1000, 200)
        Me.pnlCabecera.TabIndex = 0
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.ForeColor = System.Drawing.Color.DimGray
        Me.lblNombreProveedor.Location = New System.Drawing.Point(300, 43)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(0, 13)
        Me.lblNombreProveedor.TabIndex = 4
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(196, 39)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(90, 26)
        Me.btnBuscarProveedor.TabIndex = 3
        Me.btnBuscarProveedor.Text = "Buscar"
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(12, 40)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(178, 20)
        Me.txtProveedor.TabIndex = 2
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(12, 24)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 1
        Me.lblProveedor.Text = "Proveedor"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(850, 40)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(120, 21)
        Me.cmbMoneda.TabIndex = 5
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(850, 24)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(45, 13)
        Me.lblMoneda.TabIndex = 6
        Me.lblMoneda.Text = "Moneda"
        '
        'txtLugarEntrega
        '
        Me.txtLugarEntrega.Location = New System.Drawing.Point(338, 84)
        Me.txtLugarEntrega.Name = "txtLugarEntrega"
        Me.txtLugarEntrega.Size = New System.Drawing.Size(200, 20)
        Me.txtLugarEntrega.TabIndex = 8
        '
        'lblLugarEntrega
        '
        Me.lblLugarEntrega.AutoSize = True
        Me.lblLugarEntrega.Location = New System.Drawing.Point(338, 68)
        Me.lblLugarEntrega.Name = "lblLugarEntrega"
        Me.lblLugarEntrega.Size = New System.Drawing.Size(76, 13)
        Me.lblLugarEntrega.TabIndex = 9
        Me.lblLugarEntrega.Text = "Lugar Entrega"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(12, 84)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(178, 20)
        Me.dtpFechaEntrega.TabIndex = 7
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(12, 68)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaEntrega.TabIndex = 10
        Me.lblFechaEntrega.Text = "Fecha Entrega"
        '
        'cmbAfectaInventario
        '
        Me.cmbAfectaInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaInventario.FormattingEnabled = True
        Me.cmbAfectaInventario.Location = New System.Drawing.Point(850, 84)
        Me.cmbAfectaInventario.Name = "cmbAfectaInventario"
        Me.cmbAfectaInventario.Size = New System.Drawing.Size(120, 21)
        Me.cmbAfectaInventario.TabIndex = 15
        '
        'lblAfectaInventario
        '
        Me.lblAfectaInventario.AutoSize = True
        Me.lblAfectaInventario.Location = New System.Drawing.Point(850, 68)
        Me.lblAfectaInventario.Name = "lblAfectaInventario"
        Me.lblAfectaInventario.Size = New System.Drawing.Size(88, 13)
        Me.lblAfectaInventario.TabIndex = 16
        Me.lblAfectaInventario.Text = "Afecta Inventario"
        '
        'txtMontoAnticipo
        '
        Me.txtMontoAnticipo.Location = New System.Drawing.Point(690, 84)
        Me.txtMontoAnticipo.Name = "txtMontoAnticipo"
        Me.txtMontoAnticipo.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoAnticipo.TabIndex = 13
        Me.txtMontoAnticipo.Text = "0"
        Me.txtMontoAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoAnticipo
        '
        Me.lblMontoAnticipo.AutoSize = True
        Me.lblMontoAnticipo.Location = New System.Drawing.Point(690, 68)
        Me.lblMontoAnticipo.Name = "lblMontoAnticipo"
        Me.lblMontoAnticipo.Size = New System.Drawing.Size(78, 13)
        Me.lblMontoAnticipo.TabIndex = 14
        Me.lblMontoAnticipo.Text = "Monto Anticipo"
        '
        'cmbAnticipo
        '
        Me.cmbAnticipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnticipo.FormattingEnabled = True
        Me.cmbAnticipo.Location = New System.Drawing.Point(564, 84)
        Me.cmbAnticipo.Name = "cmbAnticipo"
        Me.cmbAnticipo.Size = New System.Drawing.Size(100, 21)
        Me.cmbAnticipo.TabIndex = 11
        '
        'lblAnticipo
        '
        Me.lblAnticipo.AutoSize = True
        Me.lblAnticipo.Location = New System.Drawing.Point(564, 68)
        Me.lblAnticipo.Name = "lblAnticipo"
        Me.lblAnticipo.Size = New System.Drawing.Size(45, 13)
        Me.lblAnticipo.TabIndex = 12
        Me.lblAnticipo.Text = "Anticipo"
        '
        'cmbCadena
        '
        Me.cmbCadena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCadena.FormattingEnabled = True
        Me.cmbCadena.Location = New System.Drawing.Point(564, 40)
        Me.cmbCadena.Name = "cmbCadena"
        Me.cmbCadena.Size = New System.Drawing.Size(100, 21)
        Me.cmbCadena.TabIndex = 17
        '
        'lblCadena
        '
        Me.lblCadena.AutoSize = True
        Me.lblCadena.Location = New System.Drawing.Point(564, 24)
        Me.lblCadena.Name = "lblCadena"
        Me.lblCadena.Size = New System.Drawing.Size(122, 13)
        Me.lblCadena.TabIndex = 18
        Me.lblCadena.Text = "Cadena Supermercados"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(12, 128)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(958, 20)
        Me.txtObservaciones.TabIndex = 19
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(12, 112)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(129, 13)
        Me.lblObservaciones.TabIndex = 20
        Me.lblObservaciones.Text = "Observaciones Generales"
        '
        'dgvLineas
        '
        Me.dgvLineas.AllowUserToAddRows = False
        Me.dgvLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLineas.Location = New System.Drawing.Point(0, 200)
        Me.dgvLineas.Name = "dgvLineas"
        Me.dgvLineas.ReadOnly = True
        Me.dgvLineas.Size = New System.Drawing.Size(1000, 260)
        Me.dgvLineas.TabIndex = 1
        '
        'pnlBotonesLineas
        '
        Me.pnlBotonesLineas.Controls.Add(Me.btnDistribucion)
        Me.pnlBotonesLineas.Controls.Add(Me.btnEliminarLinea)
        Me.pnlBotonesLineas.Controls.Add(Me.btnEditarLinea)
        Me.pnlBotonesLineas.Controls.Add(Me.btnAgregarLinea)
        Me.pnlBotonesLineas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesLineas.Location = New System.Drawing.Point(0, 460)
        Me.pnlBotonesLineas.Name = "pnlBotonesLineas"
        Me.pnlBotonesLineas.Size = New System.Drawing.Size(1000, 40)
        Me.pnlBotonesLineas.TabIndex = 2
        '
        'btnDistribucion
        '
        Me.btnDistribucion.Location = New System.Drawing.Point(346, 6)
        Me.btnDistribucion.Name = "btnDistribucion"
        Me.btnDistribucion.Size = New System.Drawing.Size(260, 28)
        Me.btnDistribucion.TabIndex = 3
        Me.btnDistribucion.Text = "Distribución (Centro Costo / Marca / Canal / Gasto)"
        Me.btnDistribucion.UseVisualStyleBackColor = True
        '
        'btnEliminarLinea
        '
        Me.btnEliminarLinea.Location = New System.Drawing.Point(226, 6)
        Me.btnEliminarLinea.Name = "btnEliminarLinea"
        Me.btnEliminarLinea.Size = New System.Drawing.Size(110, 28)
        Me.btnEliminarLinea.TabIndex = 2
        Me.btnEliminarLinea.Text = "Eliminar Línea"
        Me.btnEliminarLinea.UseVisualStyleBackColor = True
        '
        'btnEditarLinea
        '
        Me.btnEditarLinea.Location = New System.Drawing.Point(110, 6)
        Me.btnEditarLinea.Name = "btnEditarLinea"
        Me.btnEditarLinea.Size = New System.Drawing.Size(110, 28)
        Me.btnEditarLinea.TabIndex = 1
        Me.btnEditarLinea.Text = "Editar Línea"
        Me.btnEditarLinea.UseVisualStyleBackColor = True
        '
        'btnAgregarLinea
        '
        Me.btnAgregarLinea.Location = New System.Drawing.Point(4, 6)
        Me.btnAgregarLinea.Name = "btnAgregarLinea"
        Me.btnAgregarLinea.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregarLinea.TabIndex = 0
        Me.btnAgregarLinea.Text = "Agregar Línea"
        Me.btnAgregarLinea.UseVisualStyleBackColor = True
        '
        'pnlAceptarCancelar
        '
        Me.pnlAceptarCancelar.Controls.Add(Me.btnGuardar)
        Me.pnlAceptarCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlAceptarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAceptarCancelar.Location = New System.Drawing.Point(0, 500)
        Me.pnlAceptarCancelar.Name = "pnlAceptarCancelar"
        Me.pnlAceptarCancelar.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlAceptarCancelar.Size = New System.Drawing.Size(1000, 48)
        Me.pnlAceptarCancelar.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(810, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(901, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRequisicionMasivaIA_Cabecera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 548)
        Me.Controls.Add(Me.dgvLineas)
        Me.Controls.Add(Me.pnlBotonesLineas)
        Me.Controls.Add(Me.pnlAceptarCancelar)
        Me.Controls.Add(Me.pnlCabecera)
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Name = "frmRequisicionMasivaIA_Cabecera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Requisición"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesLineas.ResumeLayout(False)
        Me.pnlAceptarCancelar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents txtLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lblLugarEntrega As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents cmbAfectaInventario As System.Windows.Forms.ComboBox
    Friend WithEvents lblAfectaInventario As System.Windows.Forms.Label
    Friend WithEvents txtMontoAnticipo As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoAnticipo As System.Windows.Forms.Label
    Friend WithEvents cmbAnticipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnticipo As System.Windows.Forms.Label
    Friend WithEvents cmbCadena As System.Windows.Forms.ComboBox
    Friend WithEvents lblCadena As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents dgvLineas As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonesLineas As System.Windows.Forms.Panel
    Friend WithEvents btnDistribucion As System.Windows.Forms.Button
    Friend WithEvents btnEliminarLinea As System.Windows.Forms.Button
    Friend WithEvents btnEditarLinea As System.Windows.Forms.Button
    Friend WithEvents btnAgregarLinea As System.Windows.Forms.Button
    Friend WithEvents pnlAceptarCancelar As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

End Class
