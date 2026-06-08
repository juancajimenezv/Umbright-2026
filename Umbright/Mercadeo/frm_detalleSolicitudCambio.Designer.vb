<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_detalleSolicitudCambio
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents lblTituloTipo As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblEmpresaLbl As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblProductoLbl As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblGlosaLbl As System.Windows.Forms.Label
    Friend WithEvents lblGlosa As System.Windows.Forms.Label
    Friend WithEvents lblValorAnteriorLbl As System.Windows.Forms.Label
    Friend WithEvents lblValorAnterior As System.Windows.Forms.Label
    Friend WithEvents lblValorNuevoLbl As System.Windows.Forms.Label
    Friend WithEvents lblValorNuevo As System.Windows.Forms.Label
    Friend WithEvents lblMotivoLbl As System.Windows.Forms.Label
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblSolicitanteLbl As System.Windows.Forms.Label
    Friend WithEvents lblSolicitante As System.Windows.Forms.Label
    Friend WithEvents lblFechaLbl As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblEstadoLbl As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblObsLbl As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTituloTipo = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblEmpresaLbl = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblProductoLbl = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblGlosaLbl = New System.Windows.Forms.Label()
        Me.lblGlosa = New System.Windows.Forms.Label()
        Me.lblValorAnteriorLbl = New System.Windows.Forms.Label()
        Me.lblValorAnterior = New System.Windows.Forms.Label()
        Me.lblValorNuevoLbl = New System.Windows.Forms.Label()
        Me.lblValorNuevo = New System.Windows.Forms.Label()
        Me.lblMotivoLbl = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblSolicitanteLbl = New System.Windows.Forms.Label()
        Me.lblSolicitante = New System.Windows.Forms.Label()
        Me.lblFechaLbl = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblEstadoLbl = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblObsLbl = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()

        ' Título: Tipo + Número
        Me.lblTituloTipo.AutoSize = True : Me.lblTituloTipo.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTituloTipo.Text = "Modificación de Tipo de Producto"

        Me.lblNumero.AutoSize = True : Me.lblNumero.Location = New System.Drawing.Point(15, 42)
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumero.Text = "Solicitud #"

        ' GroupBox con datos
        Me.grpDatos.Location = New System.Drawing.Point(15, 75) : Me.grpDatos.Size = New System.Drawing.Size(560, 240)
        Me.grpDatos.Text = "Detalle"

        Me.lblEmpresaLbl.AutoSize = True : Me.lblEmpresaLbl.Location = New System.Drawing.Point(15, 25) : Me.lblEmpresaLbl.Text = "Empresa:"
        Me.lblEmpresa.AutoSize = True : Me.lblEmpresa.Location = New System.Drawing.Point(140, 25)
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)

        Me.lblProductoLbl.AutoSize = True : Me.lblProductoLbl.Location = New System.Drawing.Point(15, 50) : Me.lblProductoLbl.Text = "Código producto:"
        Me.lblProducto.AutoSize = True : Me.lblProducto.Location = New System.Drawing.Point(140, 50)
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)

        Me.lblGlosaLbl.AutoSize = True : Me.lblGlosaLbl.Location = New System.Drawing.Point(15, 75) : Me.lblGlosaLbl.Text = "Descripción:"
        Me.lblGlosa.AutoSize = True : Me.lblGlosa.Location = New System.Drawing.Point(140, 75)
        Me.lblGlosa.MaximumSize = New System.Drawing.Size(410, 0)

        Me.lblValorAnteriorLbl.AutoSize = True : Me.lblValorAnteriorLbl.Location = New System.Drawing.Point(15, 105) : Me.lblValorAnteriorLbl.Text = "Tipo actual:"
        Me.lblValorAnterior.AutoSize = True : Me.lblValorAnterior.Location = New System.Drawing.Point(140, 105)
        Me.lblValorAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblValorAnterior.ForeColor = System.Drawing.Color.DarkRed

        Me.lblValorNuevoLbl.AutoSize = True : Me.lblValorNuevoLbl.Location = New System.Drawing.Point(15, 130) : Me.lblValorNuevoLbl.Text = "Tipo solicitado:"
        Me.lblValorNuevo.AutoSize = True : Me.lblValorNuevo.Location = New System.Drawing.Point(140, 130)
        Me.lblValorNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblValorNuevo.ForeColor = System.Drawing.Color.DarkGreen

        Me.lblMotivoLbl.AutoSize = True : Me.lblMotivoLbl.Location = New System.Drawing.Point(15, 155) : Me.lblMotivoLbl.Text = "Motivo solicitud:"
        Me.lblMotivo.AutoSize = True : Me.lblMotivo.Location = New System.Drawing.Point(140, 155)
        Me.lblMotivo.MaximumSize = New System.Drawing.Size(410, 0)

        Me.lblSolicitanteLbl.AutoSize = True : Me.lblSolicitanteLbl.Location = New System.Drawing.Point(15, 185) : Me.lblSolicitanteLbl.Text = "Solicitado por:"
        Me.lblSolicitante.AutoSize = True : Me.lblSolicitante.Location = New System.Drawing.Point(140, 185)

        Me.lblFechaLbl.AutoSize = True : Me.lblFechaLbl.Location = New System.Drawing.Point(15, 210) : Me.lblFechaLbl.Text = "Fecha:"
        Me.lblFecha.AutoSize = True : Me.lblFecha.Location = New System.Drawing.Point(140, 210)

        Me.grpDatos.Controls.Add(Me.lblEmpresaLbl) : Me.grpDatos.Controls.Add(Me.lblEmpresa)
        Me.grpDatos.Controls.Add(Me.lblProductoLbl) : Me.grpDatos.Controls.Add(Me.lblProducto)
        Me.grpDatos.Controls.Add(Me.lblGlosaLbl) : Me.grpDatos.Controls.Add(Me.lblGlosa)
        Me.grpDatos.Controls.Add(Me.lblValorAnteriorLbl) : Me.grpDatos.Controls.Add(Me.lblValorAnterior)
        Me.grpDatos.Controls.Add(Me.lblValorNuevoLbl) : Me.grpDatos.Controls.Add(Me.lblValorNuevo)
        Me.grpDatos.Controls.Add(Me.lblMotivoLbl) : Me.grpDatos.Controls.Add(Me.lblMotivo)
        Me.grpDatos.Controls.Add(Me.lblSolicitanteLbl) : Me.grpDatos.Controls.Add(Me.lblSolicitante)
        Me.grpDatos.Controls.Add(Me.lblFechaLbl) : Me.grpDatos.Controls.Add(Me.lblFecha)

        ' Estado actual
        Me.lblEstadoLbl.AutoSize = True : Me.lblEstadoLbl.Location = New System.Drawing.Point(15, 325) : Me.lblEstadoLbl.Text = "Estado:"
        Me.lblEstado.AutoSize = True : Me.lblEstado.Location = New System.Drawing.Point(80, 325)
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)

        ' Observación al aprobar/rechazar
        Me.lblObsLbl.AutoSize = True : Me.lblObsLbl.Location = New System.Drawing.Point(15, 355)
        Me.lblObsLbl.Text = "Observación (opcional al aprobar / requerida al rechazar):"
        Me.txtObservacion.Location = New System.Drawing.Point(15, 375) : Me.txtObservacion.Size = New System.Drawing.Size(560, 20)
        Me.txtObservacion.Multiline = False

        ' Botones
        Me.btnAprobar.Location = New System.Drawing.Point(280, 415) : Me.btnAprobar.Size = New System.Drawing.Size(100, 32)
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.BackColor = System.Drawing.Color.FromArgb(CType(76, Byte), CType(175, Byte), CType(80, Byte))
        Me.btnAprobar.ForeColor = System.Drawing.Color.White : Me.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)

        Me.btnRechazar.Location = New System.Drawing.Point(390, 415) : Me.btnRechazar.Size = New System.Drawing.Size(100, 32)
        Me.btnRechazar.Text = "Rechazar"
        Me.btnRechazar.BackColor = System.Drawing.Color.FromArgb(CType(244, Byte), CType(67, Byte), CType(54, Byte))
        Me.btnRechazar.ForeColor = System.Drawing.Color.White : Me.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)

        Me.btnCerrar.Location = New System.Drawing.Point(500, 415) : Me.btnCerrar.Size = New System.Drawing.Size(75, 32)
        Me.btnCerrar.Text = "Cerrar" : Me.btnCerrar.UseVisualStyleBackColor = True

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 460)
        Me.Controls.Add(Me.lblTituloTipo) : Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.lblEstadoLbl) : Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblObsLbl) : Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.btnAprobar) : Me.Controls.Add(Me.btnRechazar) : Me.Controls.Add(Me.btnCerrar)
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.Name = "frm_detalleSolicitudCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Solicitud"
        Me.grpDatos.ResumeLayout(False) : Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False) : Me.PerformLayout()
    End Sub
End Class
