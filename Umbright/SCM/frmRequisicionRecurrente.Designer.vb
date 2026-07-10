<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRequisicionRecurrente
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageHeader = New System.Windows.Forms.TabPage()
        Me.TabPageDetalle = New System.Windows.Forms.TabPage()
        Me.TabPageNotificaciones = New System.Windows.Forms.TabPage()

        ' Header controls
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblFrecuencia = New System.Windows.Forms.Label()
        Me.cmbFrecuencia = New System.Windows.Forms.ComboBox()
        Me.lblDiaFactura = New System.Windows.Forms.Label()
        Me.nudDiaFactura = New System.Windows.Forms.NumericUpDown()
        Me.lblDiasAnticipacion = New System.Windows.Forms.Label()
        Me.nudDiasAnticipacion = New System.Windows.Forms.NumericUpDown()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaVencRecurrencia = New System.Windows.Forms.Label()
        Me.dtpFechaVencRecurrencia = New System.Windows.Forms.DateTimePicker()
        Me.chkVencLicencia = New System.Windows.Forms.CheckBox()
        Me.dtpFechaVencLicencia = New System.Windows.Forms.DateTimePicker()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.txtUsuarioResponsable = New System.Windows.Forms.TextBox()
        Me.txtNombreResponsable = New System.Windows.Forms.TextBox()
        Me.btnBuscarResponsable = New System.Windows.Forms.Button()

        ' Detalle controls
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.dgvDistribuciones = New System.Windows.Forms.DataGridView()
        Me.dgvCanal = New System.Windows.Forms.DataGridView()

        ' Notificaciones controls
        Me.dgvNotificaciones = New System.Windows.Forms.DataGridView()
        Me.btnAgregarNotificacion = New System.Windows.Forms.Button()
        Me.btnQuitarNotificacion = New System.Windows.Forms.Button()

        ' Bottom buttons
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()

        Me.TabControl1.SuspendLayout()
        Me.TabPageHeader.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.TabPageNotificaciones.SuspendLayout()
        CType(Me.nudDiaFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiasAnticipacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDistribuciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNotificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' =====================================================================
        ' TabControl1
        ' =====================================================================
        Me.TabControl1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageHeader)
        Me.TabControl1.Controls.Add(Me.TabPageNotificaciones)
        Me.TabControl1.Location = New System.Drawing.Point(4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(876, 560)
        Me.TabControl1.TabIndex = 0

        ' =====================================================================
        ' TabPageHeader — datos generales de la plantilla
        ' =====================================================================
        Me.TabPageHeader.Controls.Add(Me.lblCodigo)
        Me.TabPageHeader.Controls.Add(Me.txtCodigo)
        Me.TabPageHeader.Controls.Add(Me.lblDescripcion)
        Me.TabPageHeader.Controls.Add(Me.txtDescripcion)
        Me.TabPageHeader.Controls.Add(Me.lblProveedor)
        Me.TabPageHeader.Controls.Add(Me.txtProveedor)
        Me.TabPageHeader.Controls.Add(Me.txtNombreProveedor)
        Me.TabPageHeader.Controls.Add(Me.lblMoneda)
        Me.TabPageHeader.Controls.Add(Me.cmbMoneda)
        Me.TabPageHeader.Controls.Add(Me.lblObservaciones)
        Me.TabPageHeader.Controls.Add(Me.txtObservaciones)
        Me.TabPageHeader.Controls.Add(Me.lblFrecuencia)
        Me.TabPageHeader.Controls.Add(Me.cmbFrecuencia)
        Me.TabPageHeader.Controls.Add(Me.lblDiaFactura)
        Me.TabPageHeader.Controls.Add(Me.nudDiaFactura)
        Me.TabPageHeader.Controls.Add(Me.lblDiasAnticipacion)
        Me.TabPageHeader.Controls.Add(Me.nudDiasAnticipacion)
        Me.TabPageHeader.Controls.Add(Me.lblFechaInicio)
        Me.TabPageHeader.Controls.Add(Me.dtpFechaInicio)
        Me.TabPageHeader.Controls.Add(Me.lblFechaVencRecurrencia)
        Me.TabPageHeader.Controls.Add(Me.dtpFechaVencRecurrencia)
        Me.TabPageHeader.Controls.Add(Me.chkVencLicencia)
        Me.TabPageHeader.Controls.Add(Me.dtpFechaVencLicencia)
        Me.TabPageHeader.Controls.Add(Me.lblResponsable)
        Me.TabPageHeader.Controls.Add(Me.txtUsuarioResponsable)
        Me.TabPageHeader.Controls.Add(Me.txtNombreResponsable)
        Me.TabPageHeader.Controls.Add(Me.btnBuscarResponsable)
        Me.TabPageHeader.Location = New System.Drawing.Point(4, 22)
        Me.TabPageHeader.Name = "TabPageHeader"
        Me.TabPageHeader.Size = New System.Drawing.Size(868, 534)
        Me.TabPageHeader.TabIndex = 0
        Me.TabPageHeader.Text = "General"

        ' Código
        Me.lblCodigo.Location = New System.Drawing.Point(12, 20)
        Me.lblCodigo.Size = New System.Drawing.Size(120, 20)
        Me.lblCodigo.Text = "Código:"
        Me.txtCodigo.Location = New System.Drawing.Point(140, 18)
        Me.txtCodigo.Size = New System.Drawing.Size(150, 22)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.MaxLength = 20

        ' Descripción
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 50)
        Me.lblDescripcion.Size = New System.Drawing.Size(120, 20)
        Me.lblDescripcion.Text = "Descripción:"
        Me.txtDescripcion.Location = New System.Drawing.Point(140, 48)
        Me.txtDescripcion.Size = New System.Drawing.Size(400, 22)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.MaxLength = 200

        ' Proveedor
        Me.lblProveedor.Location = New System.Drawing.Point(12, 80)
        Me.lblProveedor.Size = New System.Drawing.Size(120, 20)
        Me.lblProveedor.Text = "Proveedor:"
        Me.txtProveedor.Location = New System.Drawing.Point(140, 78)
        Me.txtProveedor.Size = New System.Drawing.Size(120, 22)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.MaxLength = 25
        Me.txtNombreProveedor.Location = New System.Drawing.Point(268, 78)
        Me.txtNombreProveedor.Size = New System.Drawing.Size(280, 22)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.ReadOnly = True
        Me.txtNombreProveedor.MaxLength = 100

        ' Moneda
        Me.lblMoneda.Location = New System.Drawing.Point(360, 80)
        Me.lblMoneda.Size = New System.Drawing.Size(80, 20)
        Me.lblMoneda.Text = "Moneda:"
        Me.cmbMoneda.Location = New System.Drawing.Point(448, 78)
        Me.cmbMoneda.Size = New System.Drawing.Size(100, 22)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.DropDownStyle = ComboBoxStyle.DropDownList

        ' Observaciones
        Me.lblObservaciones.Location = New System.Drawing.Point(12, 110)
        Me.lblObservaciones.Size = New System.Drawing.Size(120, 20)
        Me.lblObservaciones.Text = "Observaciones:"
        Me.txtObservaciones.Location = New System.Drawing.Point(140, 108)
        Me.txtObservaciones.Size = New System.Drawing.Size(400, 60)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.MaxLength = 255

        ' Separador visual — recurrencia
        Me.lblFrecuencia.Location = New System.Drawing.Point(12, 190)
        Me.lblFrecuencia.Size = New System.Drawing.Size(120, 20)
        Me.lblFrecuencia.Text = "Frecuencia:"
        Me.cmbFrecuencia.Location = New System.Drawing.Point(140, 188)
        Me.cmbFrecuencia.Size = New System.Drawing.Size(150, 22)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.DropDownStyle = ComboBoxStyle.DropDownList

        ' Día factura
        Me.lblDiaFactura.Location = New System.Drawing.Point(310, 190)
        Me.lblDiaFactura.Size = New System.Drawing.Size(120, 20)
        Me.lblDiaFactura.Text = "Día factura en mes:"
        Me.nudDiaFactura.Location = New System.Drawing.Point(438, 188)
        Me.nudDiaFactura.Size = New System.Drawing.Size(60, 22)
        Me.nudDiaFactura.Name = "nudDiaFactura"
        Me.nudDiaFactura.Minimum = 1
        Me.nudDiaFactura.Maximum = 31

        ' Días anticipación
        Me.lblDiasAnticipacion.Location = New System.Drawing.Point(520, 190)
        Me.lblDiasAnticipacion.Size = New System.Drawing.Size(120, 20)
        Me.lblDiasAnticipacion.Text = "Días anticipación:"
        Me.nudDiasAnticipacion.Location = New System.Drawing.Point(648, 188)
        Me.nudDiasAnticipacion.Size = New System.Drawing.Size(60, 22)
        Me.nudDiasAnticipacion.Name = "nudDiasAnticipacion"
        Me.nudDiasAnticipacion.Minimum = 0
        Me.nudDiasAnticipacion.Maximum = 60

        ' Fecha inicio
        Me.lblFechaInicio.Location = New System.Drawing.Point(12, 222)
        Me.lblFechaInicio.Size = New System.Drawing.Size(120, 20)
        Me.lblFechaInicio.Text = "Fecha inicio:"
        Me.dtpFechaInicio.Location = New System.Drawing.Point(140, 220)
        Me.dtpFechaInicio.Size = New System.Drawing.Size(150, 22)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Format = DateTimePickerFormat.Short

        ' Fecha vencimiento recurrencia
        Me.lblFechaVencRecurrencia.Location = New System.Drawing.Point(310, 222)
        Me.lblFechaVencRecurrencia.Size = New System.Drawing.Size(150, 20)
        Me.lblFechaVencRecurrencia.Text = "Vencimiento recurrencia:"
        Me.dtpFechaVencRecurrencia.Location = New System.Drawing.Point(468, 220)
        Me.dtpFechaVencRecurrencia.Size = New System.Drawing.Size(150, 22)
        Me.dtpFechaVencRecurrencia.Name = "dtpFechaVencRecurrencia"
        Me.dtpFechaVencRecurrencia.Format = DateTimePickerFormat.Short

        ' Vencimiento licencia (opcional)
        Me.chkVencLicencia.Location = New System.Drawing.Point(12, 254)
        Me.chkVencLicencia.Size = New System.Drawing.Size(160, 22)
        Me.chkVencLicencia.Name = "chkVencLicencia"
        Me.chkVencLicencia.Text = "Vencimiento de licencia:"
        Me.dtpFechaVencLicencia.Location = New System.Drawing.Point(180, 252)
        Me.dtpFechaVencLicencia.Size = New System.Drawing.Size(150, 22)
        Me.dtpFechaVencLicencia.Name = "dtpFechaVencLicencia"
        Me.dtpFechaVencLicencia.Format = DateTimePickerFormat.Short

        ' Usuario responsable
        Me.lblResponsable.Location = New System.Drawing.Point(12, 290)
        Me.lblResponsable.Size = New System.Drawing.Size(120, 20)
        Me.lblResponsable.Text = "Responsable:"
        Me.txtUsuarioResponsable.Location = New System.Drawing.Point(140, 288)
        Me.txtUsuarioResponsable.Size = New System.Drawing.Size(100, 22)
        Me.txtUsuarioResponsable.Name = "txtUsuarioResponsable"
        Me.txtUsuarioResponsable.ReadOnly = True
        Me.txtNombreResponsable.Location = New System.Drawing.Point(248, 288)
        Me.txtNombreResponsable.Size = New System.Drawing.Size(250, 22)
        Me.txtNombreResponsable.Name = "txtNombreResponsable"
        Me.txtNombreResponsable.ReadOnly = True
        Me.btnBuscarResponsable.Location = New System.Drawing.Point(506, 286)
        Me.btnBuscarResponsable.Size = New System.Drawing.Size(80, 26)
        Me.btnBuscarResponsable.Name = "btnBuscarResponsable"
        Me.btnBuscarResponsable.Text = "Buscar"

        ' =====================================================================
        ' TabPageDetalle — líneas, distribuciones y canal
        ' =====================================================================
        Me.TabPageDetalle.Controls.Add(Me.dgvDetalle)
        Me.TabPageDetalle.Controls.Add(Me.dgvDistribuciones)
        Me.TabPageDetalle.Controls.Add(Me.dgvCanal)
        Me.TabPageDetalle.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(868, 534)
        Me.TabPageDetalle.TabIndex = 1
        Me.TabPageDetalle.Text = "Detalle"

        Me.dgvDetalle.AllowUserToAddRows = True
        Me.dgvDetalle.AllowUserToDeleteRows = True
        Me.dgvDetalle.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(4, 4)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersWidth = 25
        Me.dgvDetalle.Size = New System.Drawing.Size(858, 160)
        Me.dgvDetalle.TabIndex = 0

        Me.dgvDistribuciones.AllowUserToAddRows = True
        Me.dgvDistribuciones.AllowUserToDeleteRows = True
        Me.dgvDistribuciones.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.dgvDistribuciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDistribuciones.Location = New System.Drawing.Point(4, 172)
        Me.dgvDistribuciones.Name = "dgvDistribuciones"
        Me.dgvDistribuciones.RowHeadersWidth = 25
        Me.dgvDistribuciones.Size = New System.Drawing.Size(858, 180)
        Me.dgvDistribuciones.TabIndex = 1

        Me.dgvCanal.AllowUserToAddRows = True
        Me.dgvCanal.AllowUserToDeleteRows = True
        Me.dgvCanal.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.dgvCanal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCanal.Location = New System.Drawing.Point(4, 360)
        Me.dgvCanal.Name = "dgvCanal"
        Me.dgvCanal.RowHeadersWidth = 25
        Me.dgvCanal.Size = New System.Drawing.Size(858, 160)
        Me.dgvCanal.TabIndex = 2

        ' =====================================================================
        ' TabPageNotificaciones
        ' =====================================================================
        Me.TabPageNotificaciones.Controls.Add(Me.btnAgregarNotificacion)
        Me.TabPageNotificaciones.Controls.Add(Me.btnQuitarNotificacion)
        Me.TabPageNotificaciones.Controls.Add(Me.dgvNotificaciones)
        Me.TabPageNotificaciones.Location = New System.Drawing.Point(4, 22)
        Me.TabPageNotificaciones.Name = "TabPageNotificaciones"
        Me.TabPageNotificaciones.Size = New System.Drawing.Size(868, 534)
        Me.TabPageNotificaciones.TabIndex = 2
        Me.TabPageNotificaciones.Text = "Notificaciones"

        Me.btnAgregarNotificacion.Location = New System.Drawing.Point(4, 4)
        Me.btnAgregarNotificacion.Size = New System.Drawing.Size(130, 28)
        Me.btnAgregarNotificacion.Name = "btnAgregarNotificacion"
        Me.btnAgregarNotificacion.Text = "Agregar Usuario"

        Me.btnQuitarNotificacion.Location = New System.Drawing.Point(140, 4)
        Me.btnQuitarNotificacion.Size = New System.Drawing.Size(100, 28)
        Me.btnQuitarNotificacion.Name = "btnQuitarNotificacion"
        Me.btnQuitarNotificacion.Text = "Quitar"

        Me.dgvNotificaciones.AllowUserToAddRows = False
        Me.dgvNotificaciones.AllowUserToDeleteRows = False
        Me.dgvNotificaciones.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
        Me.dgvNotificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotificaciones.Location = New System.Drawing.Point(4, 40)
        Me.dgvNotificaciones.Name = "dgvNotificaciones"
        Me.dgvNotificaciones.ReadOnly = True
        Me.dgvNotificaciones.RowHeadersWidth = 25
        Me.dgvNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvNotificaciones.Size = New System.Drawing.Size(858, 488)
        Me.dgvNotificaciones.TabIndex = 0

        ' =====================================================================
        ' Botones inferiores
        ' =====================================================================
        Me.btnGuardar.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(696, 572)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(90, 30)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False

        Me.btnCancelar.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(794, 572)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"

        ' =====================================================================
        ' Forma
        ' =====================================================================
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 610)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.MinimizeBox = False
        Me.Name = "frmRequisicionRecurrente"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Plantilla Recurrente"

        Me.TabControl1.ResumeLayout(False)
        Me.TabPageHeader.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.TabPageNotificaciones.ResumeLayout(False)
        CType(Me.nudDiaFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiasAnticipacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDistribuciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNotificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageHeader As TabPage
    Friend WithEvents TabPageDetalle As TabPage
    Friend WithEvents TabPageNotificaciones As TabPage
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblProveedor As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtNombreProveedor As TextBox
    Friend WithEvents lblMoneda As Label
    Friend WithEvents cmbMoneda As ComboBox
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents lblFrecuencia As Label
    Friend WithEvents cmbFrecuencia As ComboBox
    Friend WithEvents lblDiaFactura As Label
    Friend WithEvents nudDiaFactura As NumericUpDown
    Friend WithEvents lblDiasAnticipacion As Label
    Friend WithEvents nudDiasAnticipacion As NumericUpDown
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblFechaVencRecurrencia As Label
    Friend WithEvents dtpFechaVencRecurrencia As DateTimePicker
    Friend WithEvents chkVencLicencia As CheckBox
    Friend WithEvents dtpFechaVencLicencia As DateTimePicker
    Friend WithEvents lblResponsable As Label
    Friend WithEvents txtUsuarioResponsable As TextBox
    Friend WithEvents txtNombreResponsable As TextBox
    Friend WithEvents btnBuscarResponsable As Button
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents dgvDistribuciones As DataGridView
    Friend WithEvents dgvCanal As DataGridView
    Friend WithEvents dgvNotificaciones As DataGridView
    Friend WithEvents btnAgregarNotificacion As Button
    Friend WithEvents btnQuitarNotificacion As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button

End Class
