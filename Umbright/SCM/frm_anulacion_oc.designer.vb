<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_anulacion_oc
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gb_busqueda = New System.Windows.Forms.GroupBox()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.cmb_tipodocto = New System.Windows.Forms.ComboBox()
        Me.lbl_tipo = New System.Windows.Forms.Label()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.lbl_empresa = New System.Windows.Forms.Label()
        Me.gb_documento = New System.Windows.Forms.GroupBox()
        Me.txt_h_comentario1 = New System.Windows.Forms.TextBox()
        Me.lbl_h_comentario1 = New System.Windows.Forms.Label()
        Me.txt_h_estadoactual = New System.Windows.Forms.TextBox()
        Me.lbl_h_estadoactual = New System.Windows.Forms.Label()
        Me.txt_h_porcentajeasignado = New System.Windows.Forms.TextBox()
        Me.lbl_h_porcentajeasignado = New System.Windows.Forms.Label()
        Me.txt_h_vigencia = New System.Windows.Forms.TextBox()
        Me.lbl_h_vigencia = New System.Windows.Forms.Label()
        Me.txt_h_total = New System.Windows.Forms.TextBox()
        Me.lbl_h_total = New System.Windows.Forms.Label()
        Me.txt_h_fecha = New System.Windows.Forms.TextBox()
        Me.lbl_h_fecha = New System.Windows.Forms.Label()
        Me.txt_h_proveedor = New System.Windows.Forms.TextBox()
        Me.lbl_h_proveedor = New System.Windows.Forms.Label()
        Me.txt_h_numero = New System.Windows.Forms.TextBox()
        Me.lbl_h_numero = New System.Windows.Forms.Label()
        Me.txt_h_tipodocto = New System.Windows.Forms.TextBox()
        Me.lbl_h_tipodocto = New System.Windows.Forms.Label()
        Me.txt_h_empresa = New System.Windows.Forms.TextBox()
        Me.lbl_h_empresa = New System.Windows.Forms.Label()
        Me.lbl_estado = New System.Windows.Forms.Label()
        Me.gb_accion = New System.Windows.Forms.GroupBox()
        Me.btn_reversar = New System.Windows.Forms.Button()
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.txt_motivo = New System.Windows.Forms.TextBox()
        Me.lbl_motivo = New System.Windows.Forms.Label()
        Me.pnl_radios = New System.Windows.Forms.Panel()
        Me.rbn_onhold = New System.Windows.Forms.RadioButton()
        Me.rbn_anular = New System.Windows.Forms.RadioButton()
        Me.gb_busqueda.SuspendLayout()
        Me.gb_documento.SuspendLayout()
        Me.gb_accion.SuspendLayout()
        Me.pnl_radios.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_busqueda
        '
        Me.gb_busqueda.Controls.Add(Me.btn_limpiar)
        Me.gb_busqueda.Controls.Add(Me.btn_consultar)
        Me.gb_busqueda.Controls.Add(Me.txt_numero)
        Me.gb_busqueda.Controls.Add(Me.lbl_numero)
        Me.gb_busqueda.Controls.Add(Me.cmb_tipodocto)
        Me.gb_busqueda.Controls.Add(Me.lbl_tipo)
        Me.gb_busqueda.Controls.Add(Me.cmb_empresa)
        Me.gb_busqueda.Controls.Add(Me.lbl_empresa)
        Me.gb_busqueda.Location = New System.Drawing.Point(12, 12)
        Me.gb_busqueda.Name = "gb_busqueda"
        Me.gb_busqueda.Size = New System.Drawing.Size(580, 95)
        Me.gb_busqueda.TabIndex = 0
        Me.gb_busqueda.TabStop = False
        Me.gb_busqueda.Text = "Busqueda"
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(83, 80, 34)
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.Location = New System.Drawing.Point(270, 56)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(85, 25)
        Me.btn_limpiar.TabIndex = 7
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_consultar
        '
        Me.btn_consultar.BackColor = System.Drawing.Color.FromArgb(83, 80, 34)
        Me.btn_consultar.ForeColor = System.Drawing.Color.White
        Me.btn_consultar.Location = New System.Drawing.Point(180, 56)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(85, 25)
        Me.btn_consultar.TabIndex = 6
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = False
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(80, 57)
        Me.txt_numero.MaxLength = 10
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(90, 21)
        Me.txt_numero.TabIndex = 5
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Location = New System.Drawing.Point(12, 60)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(53, 13)
        Me.lbl_numero.TabIndex = 4
        Me.lbl_numero.Text = "Numero:"
        '
        'cmb_tipodocto
        '
        Me.cmb_tipodocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipodocto.FormattingEnabled = True
        Me.cmb_tipodocto.Location = New System.Drawing.Point(310, 25)
        Me.cmb_tipodocto.Name = "cmb_tipodocto"
        Me.cmb_tipodocto.Size = New System.Drawing.Size(180, 21)
        Me.cmb_tipodocto.TabIndex = 3
        '
        'lbl_tipo
        '
        Me.lbl_tipo.AutoSize = True
        Me.lbl_tipo.Location = New System.Drawing.Point(235, 28)
        Me.lbl_tipo.Name = "lbl_tipo"
        Me.lbl_tipo.Size = New System.Drawing.Size(66, 13)
        Me.lbl_tipo.TabIndex = 2
        Me.lbl_tipo.Text = "Tipo Docto:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(80, 25)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(140, 21)
        Me.cmb_empresa.TabIndex = 1
        '
        'lbl_empresa
        '
        Me.lbl_empresa.AutoSize = True
        Me.lbl_empresa.Location = New System.Drawing.Point(12, 28)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Size = New System.Drawing.Size(54, 13)
        Me.lbl_empresa.TabIndex = 0
        Me.lbl_empresa.Text = "Empresa:"
        '
        'gb_documento
        '
        Me.gb_documento.Controls.Add(Me.txt_h_comentario1)
        Me.gb_documento.Controls.Add(Me.lbl_h_comentario1)
        Me.gb_documento.Controls.Add(Me.txt_h_estadoactual)
        Me.gb_documento.Controls.Add(Me.lbl_h_estadoactual)
        Me.gb_documento.Controls.Add(Me.txt_h_porcentajeasignado)
        Me.gb_documento.Controls.Add(Me.lbl_h_porcentajeasignado)
        Me.gb_documento.Controls.Add(Me.txt_h_vigencia)
        Me.gb_documento.Controls.Add(Me.lbl_h_vigencia)
        Me.gb_documento.Controls.Add(Me.txt_h_total)
        Me.gb_documento.Controls.Add(Me.lbl_h_total)
        Me.gb_documento.Controls.Add(Me.txt_h_fecha)
        Me.gb_documento.Controls.Add(Me.lbl_h_fecha)
        Me.gb_documento.Controls.Add(Me.txt_h_proveedor)
        Me.gb_documento.Controls.Add(Me.lbl_h_proveedor)
        Me.gb_documento.Controls.Add(Me.txt_h_numero)
        Me.gb_documento.Controls.Add(Me.lbl_h_numero)
        Me.gb_documento.Controls.Add(Me.txt_h_tipodocto)
        Me.gb_documento.Controls.Add(Me.lbl_h_tipodocto)
        Me.gb_documento.Controls.Add(Me.txt_h_empresa)
        Me.gb_documento.Controls.Add(Me.lbl_h_empresa)
        Me.gb_documento.Location = New System.Drawing.Point(12, 116)
        Me.gb_documento.Name = "gb_documento"
        Me.gb_documento.Size = New System.Drawing.Size(580, 220)
        Me.gb_documento.TabIndex = 1
        Me.gb_documento.TabStop = False
        Me.gb_documento.Text = "Documento"
        '
        'txt_h_comentario1
        '
        Me.txt_h_comentario1.Location = New System.Drawing.Point(12, 168)
        Me.txt_h_comentario1.Multiline = True
        Me.txt_h_comentario1.Name = "txt_h_comentario1"
        Me.txt_h_comentario1.ReadOnly = True
        Me.txt_h_comentario1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_h_comentario1.Size = New System.Drawing.Size(556, 35)
        Me.txt_h_comentario1.TabIndex = 19
        '
        'lbl_h_comentario1
        '
        Me.lbl_h_comentario1.AutoSize = True
        Me.lbl_h_comentario1.Location = New System.Drawing.Point(12, 150)
        Me.lbl_h_comentario1.Name = "lbl_h_comentario1"
        Me.lbl_h_comentario1.Size = New System.Drawing.Size(70, 13)
        Me.lbl_h_comentario1.TabIndex = 18
        Me.lbl_h_comentario1.Text = "Comentario1:"
        '
        'txt_h_estadoactual
        '
        Me.txt_h_estadoactual.Location = New System.Drawing.Point(400, 97)
        Me.txt_h_estadoactual.Name = "txt_h_estadoactual"
        Me.txt_h_estadoactual.ReadOnly = True
        Me.txt_h_estadoactual.Size = New System.Drawing.Size(120, 21)
        Me.txt_h_estadoactual.TabIndex = 17
        '
        'lbl_h_estadoactual
        '
        Me.lbl_h_estadoactual.AutoSize = True
        Me.lbl_h_estadoactual.Location = New System.Drawing.Point(320, 100)
        Me.lbl_h_estadoactual.Name = "lbl_h_estadoactual"
        Me.lbl_h_estadoactual.Size = New System.Drawing.Size(76, 13)
        Me.lbl_h_estadoactual.TabIndex = 16
        Me.lbl_h_estadoactual.Text = "Estado Actual:"
        '
        'txt_h_porcentajeasignado
        '
        Me.txt_h_porcentajeasignado.Location = New System.Drawing.Point(400, 72)
        Me.txt_h_porcentajeasignado.Name = "txt_h_porcentajeasignado"
        Me.txt_h_porcentajeasignado.ReadOnly = True
        Me.txt_h_porcentajeasignado.Size = New System.Drawing.Size(80, 21)
        Me.txt_h_porcentajeasignado.TabIndex = 15
        '
        'lbl_h_porcentajeasignado
        '
        Me.lbl_h_porcentajeasignado.AutoSize = True
        Me.lbl_h_porcentajeasignado.Location = New System.Drawing.Point(320, 75)
        Me.lbl_h_porcentajeasignado.Name = "lbl_h_porcentajeasignado"
        Me.lbl_h_porcentajeasignado.Size = New System.Drawing.Size(66, 13)
        Me.lbl_h_porcentajeasignado.TabIndex = 14
        Me.lbl_h_porcentajeasignado.Text = "% Asignado:"
        '
        'txt_h_vigencia
        '
        Me.txt_h_vigencia.Location = New System.Drawing.Point(400, 47)
        Me.txt_h_vigencia.Name = "txt_h_vigencia"
        Me.txt_h_vigencia.ReadOnly = True
        Me.txt_h_vigencia.Size = New System.Drawing.Size(60, 21)
        Me.txt_h_vigencia.TabIndex = 13
        '
        'lbl_h_vigencia
        '
        Me.lbl_h_vigencia.AutoSize = True
        Me.lbl_h_vigencia.Location = New System.Drawing.Point(320, 50)
        Me.lbl_h_vigencia.Name = "lbl_h_vigencia"
        Me.lbl_h_vigencia.Size = New System.Drawing.Size(50, 13)
        Me.lbl_h_vigencia.TabIndex = 12
        Me.lbl_h_vigencia.Text = "Vigencia:"
        '
        'txt_h_total
        '
        Me.txt_h_total.Location = New System.Drawing.Point(400, 22)
        Me.txt_h_total.Name = "txt_h_total"
        Me.txt_h_total.ReadOnly = True
        Me.txt_h_total.Size = New System.Drawing.Size(120, 21)
        Me.txt_h_total.TabIndex = 11
        '
        'lbl_h_total
        '
        Me.lbl_h_total.AutoSize = True
        Me.lbl_h_total.Location = New System.Drawing.Point(320, 25)
        Me.lbl_h_total.Name = "lbl_h_total"
        Me.lbl_h_total.Size = New System.Drawing.Size(34, 13)
        Me.lbl_h_total.TabIndex = 10
        Me.lbl_h_total.Text = "Total:"
        '
        'txt_h_fecha
        '
        Me.txt_h_fecha.Location = New System.Drawing.Point(110, 122)
        Me.txt_h_fecha.Name = "txt_h_fecha"
        Me.txt_h_fecha.ReadOnly = True
        Me.txt_h_fecha.Size = New System.Drawing.Size(120, 21)
        Me.txt_h_fecha.TabIndex = 9
        '
        'lbl_h_fecha
        '
        Me.lbl_h_fecha.AutoSize = True
        Me.lbl_h_fecha.Location = New System.Drawing.Point(12, 125)
        Me.lbl_h_fecha.Name = "lbl_h_fecha"
        Me.lbl_h_fecha.Size = New System.Drawing.Size(38, 13)
        Me.lbl_h_fecha.TabIndex = 8
        Me.lbl_h_fecha.Text = "Fecha:"
        '
        'txt_h_proveedor
        '
        Me.txt_h_proveedor.Location = New System.Drawing.Point(110, 97)
        Me.txt_h_proveedor.Name = "txt_h_proveedor"
        Me.txt_h_proveedor.ReadOnly = True
        Me.txt_h_proveedor.Size = New System.Drawing.Size(200, 21)
        Me.txt_h_proveedor.TabIndex = 7
        '
        'lbl_h_proveedor
        '
        Me.lbl_h_proveedor.AutoSize = True
        Me.lbl_h_proveedor.Location = New System.Drawing.Point(12, 100)
        Me.lbl_h_proveedor.Name = "lbl_h_proveedor"
        Me.lbl_h_proveedor.Size = New System.Drawing.Size(60, 13)
        Me.lbl_h_proveedor.TabIndex = 6
        Me.lbl_h_proveedor.Text = "Proveedor:"
        '
        'txt_h_numero
        '
        Me.txt_h_numero.Location = New System.Drawing.Point(110, 72)
        Me.txt_h_numero.Name = "txt_h_numero"
        Me.txt_h_numero.ReadOnly = True
        Me.txt_h_numero.Size = New System.Drawing.Size(120, 21)
        Me.txt_h_numero.TabIndex = 5
        '
        'lbl_h_numero
        '
        Me.lbl_h_numero.AutoSize = True
        Me.lbl_h_numero.Location = New System.Drawing.Point(12, 75)
        Me.lbl_h_numero.Name = "lbl_h_numero"
        Me.lbl_h_numero.Size = New System.Drawing.Size(53, 13)
        Me.lbl_h_numero.TabIndex = 4
        Me.lbl_h_numero.Text = "Numero:"
        '
        'txt_h_tipodocto
        '
        Me.txt_h_tipodocto.Location = New System.Drawing.Point(110, 47)
        Me.txt_h_tipodocto.Name = "txt_h_tipodocto"
        Me.txt_h_tipodocto.ReadOnly = True
        Me.txt_h_tipodocto.Size = New System.Drawing.Size(160, 21)
        Me.txt_h_tipodocto.TabIndex = 3
        '
        'lbl_h_tipodocto
        '
        Me.lbl_h_tipodocto.AutoSize = True
        Me.lbl_h_tipodocto.Location = New System.Drawing.Point(12, 50)
        Me.lbl_h_tipodocto.Name = "lbl_h_tipodocto"
        Me.lbl_h_tipodocto.Size = New System.Drawing.Size(66, 13)
        Me.lbl_h_tipodocto.TabIndex = 2
        Me.lbl_h_tipodocto.Text = "Tipo Docto:"
        '
        'txt_h_empresa
        '
        Me.txt_h_empresa.Location = New System.Drawing.Point(110, 22)
        Me.txt_h_empresa.Name = "txt_h_empresa"
        Me.txt_h_empresa.ReadOnly = True
        Me.txt_h_empresa.Size = New System.Drawing.Size(120, 21)
        Me.txt_h_empresa.TabIndex = 1
        '
        'lbl_h_empresa
        '
        Me.lbl_h_empresa.AutoSize = True
        Me.lbl_h_empresa.Location = New System.Drawing.Point(12, 25)
        Me.lbl_h_empresa.Name = "lbl_h_empresa"
        Me.lbl_h_empresa.Size = New System.Drawing.Size(54, 13)
        Me.lbl_h_empresa.TabIndex = 0
        Me.lbl_h_empresa.Text = "Empresa:"
        '
        'lbl_estado
        '
        Me.lbl_estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado.Location = New System.Drawing.Point(12, 344)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(580, 26)
        Me.lbl_estado.TabIndex = 2
        Me.lbl_estado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gb_accion
        '
        Me.gb_accion.Controls.Add(Me.btn_reversar)
        Me.gb_accion.Controls.Add(Me.btn_procesar)
        Me.gb_accion.Controls.Add(Me.txt_motivo)
        Me.gb_accion.Controls.Add(Me.lbl_motivo)
        Me.gb_accion.Controls.Add(Me.pnl_radios)
        Me.gb_accion.Location = New System.Drawing.Point(12, 378)
        Me.gb_accion.Name = "gb_accion"
        Me.gb_accion.Size = New System.Drawing.Size(580, 210)
        Me.gb_accion.TabIndex = 3
        Me.gb_accion.TabStop = False
        Me.gb_accion.Text = "Accion"
        '
        'btn_reversar
        '
        Me.btn_reversar.BackColor = System.Drawing.Color.FromArgb(83, 80, 34)
        Me.btn_reversar.ForeColor = System.Drawing.Color.White
        Me.btn_reversar.Location = New System.Drawing.Point(150, 162)
        Me.btn_reversar.Name = "btn_reversar"
        Me.btn_reversar.Size = New System.Drawing.Size(160, 30)
        Me.btn_reversar.TabIndex = 4
        Me.btn_reversar.Text = "REVERSAR ONHOLD"
        Me.btn_reversar.UseVisualStyleBackColor = False
        '
        'btn_procesar
        '
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(83, 80, 34)
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.Location = New System.Drawing.Point(12, 162)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(120, 30)
        Me.btn_procesar.TabIndex = 3
        Me.btn_procesar.Text = "PROCESAR"
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'txt_motivo
        '
        Me.txt_motivo.Location = New System.Drawing.Point(12, 103)
        Me.txt_motivo.Multiline = True
        Me.txt_motivo.Name = "txt_motivo"
        Me.txt_motivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_motivo.Size = New System.Drawing.Size(556, 50)
        Me.txt_motivo.TabIndex = 2
        '
        'lbl_motivo
        '
        Me.lbl_motivo.AutoSize = True
        Me.lbl_motivo.Location = New System.Drawing.Point(12, 85)
        Me.lbl_motivo.Name = "lbl_motivo"
        Me.lbl_motivo.Size = New System.Drawing.Size(180, 13)
        Me.lbl_motivo.TabIndex = 1
        Me.lbl_motivo.Text = "Motivo (minimo 10 caracteres):"
        '
        'pnl_radios
        '
        Me.pnl_radios.Controls.Add(Me.rbn_onhold)
        Me.pnl_radios.Controls.Add(Me.rbn_anular)
        Me.pnl_radios.Location = New System.Drawing.Point(12, 22)
        Me.pnl_radios.Name = "pnl_radios"
        Me.pnl_radios.Size = New System.Drawing.Size(300, 55)
        Me.pnl_radios.TabIndex = 0
        '
        'rbn_onhold
        '
        Me.rbn_onhold.AutoSize = True
        Me.rbn_onhold.Location = New System.Drawing.Point(3, 28)
        Me.rbn_onhold.Name = "rbn_onhold"
        Me.rbn_onhold.Size = New System.Drawing.Size(122, 17)
        Me.rbn_onhold.TabIndex = 1
        Me.rbn_onhold.Text = "Dejar en OnHold"
        Me.rbn_onhold.UseVisualStyleBackColor = True
        '
        'rbn_anular
        '
        Me.rbn_anular.AutoSize = True
        Me.rbn_anular.Checked = True
        Me.rbn_anular.Location = New System.Drawing.Point(3, 3)
        Me.rbn_anular.Name = "rbn_anular"
        Me.rbn_anular.Size = New System.Drawing.Size(58, 17)
        Me.rbn_anular.TabIndex = 0
        Me.rbn_anular.TabStop = True
        Me.rbn_anular.Text = "Anular"
        Me.rbn_anular.UseVisualStyleBackColor = True
        '
        'frm_anulacion_oc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(233, 234, 204)
        Me.ClientSize = New System.Drawing.Size(610, 600)
        Me.Controls.Add(Me.gb_accion)
        Me.Controls.Add(Me.lbl_estado)
        Me.Controls.Add(Me.gb_documento)
        Me.Controls.Add(Me.gb_busqueda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_anulacion_oc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Anulacion OC"
        Me.gb_busqueda.ResumeLayout(False)
        Me.gb_busqueda.PerformLayout()
        Me.gb_documento.ResumeLayout(False)
        Me.gb_documento.PerformLayout()
        Me.gb_accion.ResumeLayout(False)
        Me.gb_accion.PerformLayout()
        Me.pnl_radios.ResumeLayout(False)
        Me.pnl_radios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gb_busqueda As System.Windows.Forms.GroupBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents cmb_tipodocto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents gb_documento As System.Windows.Forms.GroupBox
    Friend WithEvents txt_h_comentario1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_comentario1 As System.Windows.Forms.Label
    Friend WithEvents txt_h_estadoactual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_estadoactual As System.Windows.Forms.Label
    Friend WithEvents txt_h_porcentajeasignado As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_porcentajeasignado As System.Windows.Forms.Label
    Friend WithEvents txt_h_vigencia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_vigencia As System.Windows.Forms.Label
    Friend WithEvents txt_h_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_total As System.Windows.Forms.Label
    Friend WithEvents txt_h_fecha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fecha As System.Windows.Forms.Label
    Friend WithEvents txt_h_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_proveedor As System.Windows.Forms.Label
    Friend WithEvents txt_h_numero As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_numero As System.Windows.Forms.Label
    Friend WithEvents txt_h_tipodocto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_tipodocto As System.Windows.Forms.Label
    Friend WithEvents txt_h_empresa As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_empresa As System.Windows.Forms.Label
    Friend WithEvents lbl_estado As System.Windows.Forms.Label
    Friend WithEvents gb_accion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_reversar As System.Windows.Forms.Button
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents txt_motivo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_motivo As System.Windows.Forms.Label
    Friend WithEvents pnl_radios As System.Windows.Forms.Panel
    Friend WithEvents rbn_onhold As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_anular As System.Windows.Forms.RadioButton

End Class
