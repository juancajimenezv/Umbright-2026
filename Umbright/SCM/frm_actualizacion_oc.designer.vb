<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualizacion_oc
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
        Me.lbl_h_empresa = New System.Windows.Forms.Label()
        Me.txt_h_empresa = New System.Windows.Forms.TextBox()
        Me.lbl_h_tipodocto = New System.Windows.Forms.Label()
        Me.txt_h_tipodocto = New System.Windows.Forms.TextBox()
        Me.lbl_h_numero = New System.Windows.Forms.Label()
        Me.txt_h_numero = New System.Windows.Forms.TextBox()
        Me.lbl_h_correlativo = New System.Windows.Forms.Label()
        Me.txt_h_correlativo = New System.Windows.Forms.TextBox()
        Me.lbl_h_proveedor = New System.Windows.Forms.Label()
        Me.txt_h_proveedor = New System.Windows.Forms.TextBox()
        Me.lbl_h_moneda = New System.Windows.Forms.Label()
        Me.txt_h_moneda = New System.Windows.Forms.TextBox()
        Me.lbl_h_vigencia = New System.Windows.Forms.Label()
        Me.txt_h_vigencia = New System.Windows.Forms.TextBox()
        Me.lbl_h_emitido = New System.Windows.Forms.Label()
        Me.txt_h_emitido = New System.Windows.Forms.TextBox()
        Me.lbl_h_valoriza = New System.Windows.Forms.Label()
        Me.txt_h_valoriza = New System.Windows.Forms.TextBox()
        Me.lbl_h_aprobacion = New System.Windows.Forms.Label()
        Me.txt_h_aprobacion = New System.Windows.Forms.TextBox()
        Me.lbl_h_usuariomodif = New System.Windows.Forms.Label()
        Me.txt_h_usuariomodif = New System.Windows.Forms.TextBox()
        Me.lbl_h_periodolibro = New System.Windows.Forms.Label()
        Me.txt_h_periodolibro = New System.Windows.Forms.TextBox()
        Me.lbl_h_fecha = New System.Windows.Forms.Label()
        Me.txt_h_fecha = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechavcto = New System.Windows.Forms.Label()
        Me.txt_h_fechavcto = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechacomprobante = New System.Windows.Forms.Label()
        Me.txt_h_fechacomprobante = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechaestado = New System.Windows.Forms.Label()
        Me.txt_h_fechaestado = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechamodif = New System.Windows.Forms.Label()
        Me.txt_h_fechamodif = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechaumodif = New System.Windows.Forms.Label()
        Me.txt_h_fechaumodif = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechacierre = New System.Windows.Forms.Label()
        Me.txt_h_fechacierre = New System.Windows.Forms.TextBox()
        Me.lbl_h_fechaaprueba = New System.Windows.Forms.Label()
        Me.txt_h_fechaaprueba = New System.Windows.Forms.TextBox()
        Me.lbl_h_neto = New System.Windows.Forms.Label()
        Me.txt_h_neto = New System.Windows.Forms.TextBox()
        Me.lbl_h_subtotal = New System.Windows.Forms.Label()
        Me.txt_h_subtotal = New System.Windows.Forms.TextBox()
        Me.lbl_h_total = New System.Windows.Forms.Label()
        Me.txt_h_total = New System.Windows.Forms.TextBox()
        Me.lbl_h_netoingreso = New System.Windows.Forms.Label()
        Me.txt_h_netoingreso = New System.Windows.Forms.TextBox()
        Me.lbl_h_subtotalingreso = New System.Windows.Forms.Label()
        Me.txt_h_subtotalingreso = New System.Windows.Forms.TextBox()
        Me.lbl_h_totalingreso = New System.Windows.Forms.Label()
        Me.txt_h_totalingreso = New System.Windows.Forms.TextBox()
        Me.lbl_estado_periodo = New System.Windows.Forms.Label()
        Me.gb_habilitar = New System.Windows.Forms.GroupBox()
        Me.lbl_nueva_fecha = New System.Windows.Forms.Label()
        Me.dtp_nueva_fecha = New System.Windows.Forms.DateTimePicker()
        Me.lbl_periodo_calc = New System.Windows.Forms.Label()
        Me.btn_habilitar = New System.Windows.Forms.Button()
        Me.lbl_periodo_original = New System.Windows.Forms.Label()
        Me.btn_restaurar = New System.Windows.Forms.Button()
        Me.lbl_documento_detalle = New System.Windows.Forms.Label()
        Me.lbl_lineas = New System.Windows.Forms.Label()
        Me.chk_habilitar_edicion = New System.Windows.Forms.CheckBox()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_descartar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.lbl_cambios = New System.Windows.Forms.Label()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.pnl_main.SuspendLayout()
        Me.gb_busqueda.SuspendLayout()
        Me.gb_documento.SuspendLayout()
        Me.gb_habilitar.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_busqueda
        '
        Me.gb_busqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_busqueda.Controls.Add(Me.chk_habilitar_edicion)
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
        Me.gb_busqueda.Size = New System.Drawing.Size(976, 56)
        Me.gb_busqueda.TabIndex = 0
        Me.gb_busqueda.TabStop = False
        Me.gb_busqueda.Text = "Buscar Orden de Compra"
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(720, 19)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(70, 25)
        Me.btn_limpiar.TabIndex = 7
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_consultar
        '
        Me.btn_consultar.Location = New System.Drawing.Point(635, 19)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(80, 25)
        Me.btn_consultar.TabIndex = 6
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(535, 21)
        Me.txt_numero.MaxLength = 10
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(90, 20)
        Me.txt_numero.TabIndex = 5
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Location = New System.Drawing.Point(480, 24)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Text = "Numero:"
        '
        'cmb_tipodocto
        '
        Me.cmb_tipodocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipodocto.FormattingEnabled = True
        Me.cmb_tipodocto.Location = New System.Drawing.Point(280, 20)
        Me.cmb_tipodocto.Name = "cmb_tipodocto"
        Me.cmb_tipodocto.Size = New System.Drawing.Size(190, 21)
        Me.cmb_tipodocto.TabIndex = 3
        '
        'lbl_tipo
        '
        Me.lbl_tipo.AutoSize = True
        Me.lbl_tipo.Location = New System.Drawing.Point(210, 24)
        Me.lbl_tipo.Name = "lbl_tipo"
        Me.lbl_tipo.Text = "TipoDocto:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(70, 20)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(130, 21)
        Me.cmb_empresa.TabIndex = 1
        '
        'lbl_empresa
        '
        Me.lbl_empresa.AutoSize = True
        Me.lbl_empresa.Location = New System.Drawing.Point(12, 24)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Text = "Empresa:"
        '
        'gb_documento
        '
        Me.gb_documento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_documento.Controls.Add(Me.lbl_h_empresa)
        Me.gb_documento.Controls.Add(Me.txt_h_empresa)
        Me.gb_documento.Controls.Add(Me.lbl_h_tipodocto)
        Me.gb_documento.Controls.Add(Me.txt_h_tipodocto)
        Me.gb_documento.Controls.Add(Me.lbl_h_numero)
        Me.gb_documento.Controls.Add(Me.txt_h_numero)
        Me.gb_documento.Controls.Add(Me.lbl_h_correlativo)
        Me.gb_documento.Controls.Add(Me.txt_h_correlativo)
        Me.gb_documento.Controls.Add(Me.lbl_h_proveedor)
        Me.gb_documento.Controls.Add(Me.txt_h_proveedor)
        Me.gb_documento.Controls.Add(Me.lbl_h_moneda)
        Me.gb_documento.Controls.Add(Me.txt_h_moneda)
        Me.gb_documento.Controls.Add(Me.lbl_h_vigencia)
        Me.gb_documento.Controls.Add(Me.txt_h_vigencia)
        Me.gb_documento.Controls.Add(Me.lbl_h_emitido)
        Me.gb_documento.Controls.Add(Me.txt_h_emitido)
        Me.gb_documento.Controls.Add(Me.lbl_h_valoriza)
        Me.gb_documento.Controls.Add(Me.txt_h_valoriza)
        Me.gb_documento.Controls.Add(Me.lbl_h_aprobacion)
        Me.gb_documento.Controls.Add(Me.txt_h_aprobacion)
        Me.gb_documento.Controls.Add(Me.lbl_h_usuariomodif)
        Me.gb_documento.Controls.Add(Me.txt_h_usuariomodif)
        Me.gb_documento.Controls.Add(Me.lbl_h_periodolibro)
        Me.gb_documento.Controls.Add(Me.txt_h_periodolibro)
        Me.gb_documento.Controls.Add(Me.lbl_h_fecha)
        Me.gb_documento.Controls.Add(Me.txt_h_fecha)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechavcto)
        Me.gb_documento.Controls.Add(Me.txt_h_fechavcto)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechacomprobante)
        Me.gb_documento.Controls.Add(Me.txt_h_fechacomprobante)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechaestado)
        Me.gb_documento.Controls.Add(Me.txt_h_fechaestado)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechamodif)
        Me.gb_documento.Controls.Add(Me.txt_h_fechamodif)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechaumodif)
        Me.gb_documento.Controls.Add(Me.txt_h_fechaumodif)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechacierre)
        Me.gb_documento.Controls.Add(Me.txt_h_fechacierre)
        Me.gb_documento.Controls.Add(Me.lbl_h_fechaaprueba)
        Me.gb_documento.Controls.Add(Me.txt_h_fechaaprueba)
        Me.gb_documento.Controls.Add(Me.lbl_h_neto)
        Me.gb_documento.Controls.Add(Me.txt_h_neto)
        Me.gb_documento.Controls.Add(Me.lbl_h_subtotal)
        Me.gb_documento.Controls.Add(Me.txt_h_subtotal)
        Me.gb_documento.Controls.Add(Me.lbl_h_total)
        Me.gb_documento.Controls.Add(Me.txt_h_total)
        Me.gb_documento.Controls.Add(Me.lbl_h_netoingreso)
        Me.gb_documento.Controls.Add(Me.txt_h_netoingreso)
        Me.gb_documento.Controls.Add(Me.lbl_h_subtotalingreso)
        Me.gb_documento.Controls.Add(Me.txt_h_subtotalingreso)
        Me.gb_documento.Controls.Add(Me.lbl_h_totalingreso)
        Me.gb_documento.Controls.Add(Me.txt_h_totalingreso)
        Me.gb_documento.Location = New System.Drawing.Point(12, 74)
        Me.gb_documento.Name = "gb_documento"
        Me.gb_documento.Size = New System.Drawing.Size(976, 244)
        Me.gb_documento.TabIndex = 1
        Me.gb_documento.TabStop = False
        Me.gb_documento.Text = "DOCUMENTO"
        Me.lbl_h_empresa.AutoSize = True
        Me.lbl_h_empresa.Location = New System.Drawing.Point(12, 20)
        Me.lbl_h_empresa.Name = "lbl_h_empresa"
        Me.lbl_h_empresa.Text = "Empresa:"
        Me.txt_h_empresa.Location = New System.Drawing.Point(75, 17)
        Me.txt_h_empresa.Name = "txt_h_empresa"
        Me.txt_h_empresa.ReadOnly = True
        Me.txt_h_empresa.Size = New System.Drawing.Size(150, 20)
        Me.lbl_h_tipodocto.AutoSize = True
        Me.lbl_h_tipodocto.Location = New System.Drawing.Point(245, 20)
        Me.lbl_h_tipodocto.Name = "lbl_h_tipodocto"
        Me.lbl_h_tipodocto.Text = "TipoDocto:"
        Me.txt_h_tipodocto.Location = New System.Drawing.Point(315, 17)
        Me.txt_h_tipodocto.Name = "txt_h_tipodocto"
        Me.txt_h_tipodocto.ReadOnly = True
        Me.txt_h_tipodocto.Size = New System.Drawing.Size(175, 20)
        Me.lbl_h_numero.AutoSize = True
        Me.lbl_h_numero.Location = New System.Drawing.Point(510, 20)
        Me.lbl_h_numero.Name = "lbl_h_numero"
        Me.lbl_h_numero.Text = "Numero:"
        Me.txt_h_numero.Location = New System.Drawing.Point(565, 17)
        Me.txt_h_numero.Name = "txt_h_numero"
        Me.txt_h_numero.ReadOnly = True
        Me.txt_h_numero.Size = New System.Drawing.Size(100, 20)
        Me.lbl_h_correlativo.AutoSize = True
        Me.lbl_h_correlativo.Location = New System.Drawing.Point(690, 20)
        Me.lbl_h_correlativo.Name = "lbl_h_correlativo"
        Me.lbl_h_correlativo.Text = "Correlativo:"
        Me.txt_h_correlativo.Location = New System.Drawing.Point(765, 17)
        Me.txt_h_correlativo.Name = "txt_h_correlativo"
        Me.txt_h_correlativo.ReadOnly = True
        Me.txt_h_correlativo.Size = New System.Drawing.Size(95, 20)
        Me.lbl_h_proveedor.AutoSize = True
        Me.lbl_h_proveedor.Location = New System.Drawing.Point(12, 48)
        Me.lbl_h_proveedor.Name = "lbl_h_proveedor"
        Me.lbl_h_proveedor.Text = "Proveedor:"
        Me.txt_h_proveedor.Location = New System.Drawing.Point(75, 45)
        Me.txt_h_proveedor.Name = "txt_h_proveedor"
        Me.txt_h_proveedor.ReadOnly = True
        Me.txt_h_proveedor.Size = New System.Drawing.Size(380, 20)
        Me.lbl_h_moneda.AutoSize = True
        Me.lbl_h_moneda.Location = New System.Drawing.Point(510, 48)
        Me.lbl_h_moneda.Name = "lbl_h_moneda"
        Me.lbl_h_moneda.Text = "Moneda:"
        Me.txt_h_moneda.Location = New System.Drawing.Point(565, 45)
        Me.txt_h_moneda.Name = "txt_h_moneda"
        Me.txt_h_moneda.ReadOnly = True
        Me.txt_h_moneda.Size = New System.Drawing.Size(140, 20)
        Me.lbl_h_vigencia.AutoSize = True
        Me.lbl_h_vigencia.Location = New System.Drawing.Point(12, 76)
        Me.lbl_h_vigencia.Name = "lbl_h_vigencia"
        Me.lbl_h_vigencia.Text = "Vigencia:"
        Me.txt_h_vigencia.Location = New System.Drawing.Point(75, 73)
        Me.txt_h_vigencia.Name = "txt_h_vigencia"
        Me.txt_h_vigencia.ReadOnly = True
        Me.txt_h_vigencia.Size = New System.Drawing.Size(60, 20)
        Me.lbl_h_emitido.AutoSize = True
        Me.lbl_h_emitido.Location = New System.Drawing.Point(245, 76)
        Me.lbl_h_emitido.Name = "lbl_h_emitido"
        Me.lbl_h_emitido.Text = "Emitido:"
        Me.txt_h_emitido.Location = New System.Drawing.Point(300, 73)
        Me.txt_h_emitido.Name = "txt_h_emitido"
        Me.txt_h_emitido.ReadOnly = True
        Me.txt_h_emitido.Size = New System.Drawing.Size(60, 20)
        Me.lbl_h_valoriza.AutoSize = True
        Me.lbl_h_valoriza.Location = New System.Drawing.Point(400, 76)
        Me.lbl_h_valoriza.Name = "lbl_h_valoriza"
        Me.lbl_h_valoriza.Text = "Valoriza:"
        Me.txt_h_valoriza.Location = New System.Drawing.Point(460, 73)
        Me.txt_h_valoriza.Name = "txt_h_valoriza"
        Me.txt_h_valoriza.ReadOnly = True
        Me.txt_h_valoriza.Size = New System.Drawing.Size(60, 20)
        Me.lbl_h_aprobacion.AutoSize = True
        Me.lbl_h_aprobacion.Location = New System.Drawing.Point(560, 76)
        Me.lbl_h_aprobacion.Name = "lbl_h_aprobacion"
        Me.lbl_h_aprobacion.Text = "Aprobacion:"
        Me.txt_h_aprobacion.Location = New System.Drawing.Point(635, 73)
        Me.txt_h_aprobacion.Name = "txt_h_aprobacion"
        Me.txt_h_aprobacion.ReadOnly = True
        Me.txt_h_aprobacion.Size = New System.Drawing.Size(60, 20)
        Me.lbl_h_usuariomodif.AutoSize = True
        Me.lbl_h_usuariomodif.Location = New System.Drawing.Point(712, 76)
        Me.lbl_h_usuariomodif.Name = "lbl_h_usuariomodif"
        Me.lbl_h_usuariomodif.Text = "UsuarioModif:"
        Me.txt_h_usuariomodif.Location = New System.Drawing.Point(797, 73)
        Me.txt_h_usuariomodif.Name = "txt_h_usuariomodif"
        Me.txt_h_usuariomodif.ReadOnly = True
        Me.txt_h_usuariomodif.Size = New System.Drawing.Size(110, 20)
        Me.lbl_h_periodolibro.AutoSize = True
        Me.lbl_h_periodolibro.Location = New System.Drawing.Point(12, 104)
        Me.lbl_h_periodolibro.Name = "lbl_h_periodolibro"
        Me.lbl_h_periodolibro.Text = "PeriodoLibro:"
        Me.txt_h_periodolibro.Location = New System.Drawing.Point(95, 101)
        Me.txt_h_periodolibro.Name = "txt_h_periodolibro"
        Me.txt_h_periodolibro.ReadOnly = True
        Me.txt_h_periodolibro.Size = New System.Drawing.Size(80, 20)
        Me.lbl_h_fecha.AutoSize = True
        Me.lbl_h_fecha.Location = New System.Drawing.Point(245, 104)
        Me.lbl_h_fecha.Name = "lbl_h_fecha"
        Me.lbl_h_fecha.Text = "Fecha:"
        Me.txt_h_fecha.Location = New System.Drawing.Point(300, 101)
        Me.txt_h_fecha.Name = "txt_h_fecha"
        Me.txt_h_fecha.ReadOnly = True
        Me.txt_h_fecha.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechavcto.AutoSize = True
        Me.lbl_h_fechavcto.Location = New System.Drawing.Point(510, 104)
        Me.lbl_h_fechavcto.Name = "lbl_h_fechavcto"
        Me.lbl_h_fechavcto.Text = "FechaVcto:"
        Me.txt_h_fechavcto.Location = New System.Drawing.Point(580, 101)
        Me.txt_h_fechavcto.Name = "txt_h_fechavcto"
        Me.txt_h_fechavcto.ReadOnly = True
        Me.txt_h_fechavcto.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechacomprobante.AutoSize = True
        Me.lbl_h_fechacomprobante.Location = New System.Drawing.Point(12, 132)
        Me.lbl_h_fechacomprobante.Name = "lbl_h_fechacomprobante"
        Me.lbl_h_fechacomprobante.Text = "FechaComprobante:"
        Me.txt_h_fechacomprobante.Location = New System.Drawing.Point(120, 129)
        Me.txt_h_fechacomprobante.Name = "txt_h_fechacomprobante"
        Me.txt_h_fechacomprobante.ReadOnly = True
        Me.txt_h_fechacomprobante.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechaestado.AutoSize = True
        Me.lbl_h_fechaestado.Location = New System.Drawing.Point(300, 132)
        Me.lbl_h_fechaestado.Name = "lbl_h_fechaestado"
        Me.lbl_h_fechaestado.Text = "FechaEstado:"
        Me.txt_h_fechaestado.Location = New System.Drawing.Point(385, 129)
        Me.txt_h_fechaestado.Name = "txt_h_fechaestado"
        Me.txt_h_fechaestado.ReadOnly = True
        Me.txt_h_fechaestado.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechamodif.AutoSize = True
        Me.lbl_h_fechamodif.Location = New System.Drawing.Point(560, 132)
        Me.lbl_h_fechamodif.Name = "lbl_h_fechamodif"
        Me.lbl_h_fechamodif.Text = "FechaModif:"
        Me.txt_h_fechamodif.Location = New System.Drawing.Point(645, 129)
        Me.txt_h_fechamodif.Name = "txt_h_fechamodif"
        Me.txt_h_fechamodif.ReadOnly = True
        Me.txt_h_fechamodif.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechaumodif.AutoSize = True
        Me.lbl_h_fechaumodif.Location = New System.Drawing.Point(12, 160)
        Me.lbl_h_fechaumodif.Name = "lbl_h_fechaumodif"
        Me.lbl_h_fechaumodif.Text = "FechaUModif:"
        Me.txt_h_fechaumodif.Location = New System.Drawing.Point(95, 157)
        Me.txt_h_fechaumodif.Name = "txt_h_fechaumodif"
        Me.txt_h_fechaumodif.ReadOnly = True
        Me.txt_h_fechaumodif.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechacierre.AutoSize = True
        Me.lbl_h_fechacierre.Location = New System.Drawing.Point(300, 160)
        Me.lbl_h_fechacierre.Name = "lbl_h_fechacierre"
        Me.lbl_h_fechacierre.Text = "FechaCierre:"
        Me.txt_h_fechacierre.Location = New System.Drawing.Point(385, 157)
        Me.txt_h_fechacierre.Name = "txt_h_fechacierre"
        Me.txt_h_fechacierre.ReadOnly = True
        Me.txt_h_fechacierre.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_fechaaprueba.AutoSize = True
        Me.lbl_h_fechaaprueba.Location = New System.Drawing.Point(560, 160)
        Me.lbl_h_fechaaprueba.Name = "lbl_h_fechaaprueba"
        Me.lbl_h_fechaaprueba.Text = "FechaAprueba:"
        Me.txt_h_fechaaprueba.Location = New System.Drawing.Point(655, 157)
        Me.txt_h_fechaaprueba.Name = "txt_h_fechaaprueba"
        Me.txt_h_fechaaprueba.ReadOnly = True
        Me.txt_h_fechaaprueba.Size = New System.Drawing.Size(160, 20)
        Me.lbl_h_neto.AutoSize = True
        Me.lbl_h_neto.Location = New System.Drawing.Point(12, 188)
        Me.lbl_h_neto.Name = "lbl_h_neto"
        Me.lbl_h_neto.Text = "Neto:"
        Me.txt_h_neto.Location = New System.Drawing.Point(95, 185)
        Me.txt_h_neto.Name = "txt_h_neto"
        Me.txt_h_neto.ReadOnly = True
        Me.txt_h_neto.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_neto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_h_subtotal.AutoSize = True
        Me.lbl_h_subtotal.Location = New System.Drawing.Point(300, 188)
        Me.lbl_h_subtotal.Name = "lbl_h_subtotal"
        Me.lbl_h_subtotal.Text = "SubTotal:"
        Me.txt_h_subtotal.Location = New System.Drawing.Point(365, 185)
        Me.txt_h_subtotal.Name = "txt_h_subtotal"
        Me.txt_h_subtotal.ReadOnly = True
        Me.txt_h_subtotal.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_h_total.AutoSize = True
        Me.lbl_h_total.Location = New System.Drawing.Point(560, 188)
        Me.lbl_h_total.Name = "lbl_h_total"
        Me.lbl_h_total.Text = "Total:"
        Me.txt_h_total.Location = New System.Drawing.Point(605, 185)
        Me.txt_h_total.Name = "txt_h_total"
        Me.txt_h_total.ReadOnly = True
        Me.txt_h_total.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_h_netoingreso.AutoSize = True
        Me.lbl_h_netoingreso.Location = New System.Drawing.Point(12, 216)
        Me.lbl_h_netoingreso.Name = "lbl_h_netoingreso"
        Me.lbl_h_netoingreso.Text = "NetoIngreso:"
        Me.txt_h_netoingreso.Location = New System.Drawing.Point(95, 213)
        Me.txt_h_netoingreso.Name = "txt_h_netoingreso"
        Me.txt_h_netoingreso.ReadOnly = True
        Me.txt_h_netoingreso.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_netoingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_h_subtotalingreso.AutoSize = True
        Me.lbl_h_subtotalingreso.Location = New System.Drawing.Point(300, 216)
        Me.lbl_h_subtotalingreso.Name = "lbl_h_subtotalingreso"
        Me.lbl_h_subtotalingreso.Text = "SubTotalIngreso:"
        Me.txt_h_subtotalingreso.Location = New System.Drawing.Point(400, 213)
        Me.txt_h_subtotalingreso.Name = "txt_h_subtotalingreso"
        Me.txt_h_subtotalingreso.ReadOnly = True
        Me.txt_h_subtotalingreso.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_subtotalingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_h_totalingreso.AutoSize = True
        Me.lbl_h_totalingreso.Location = New System.Drawing.Point(560, 216)
        Me.lbl_h_totalingreso.Name = "lbl_h_totalingreso"
        Me.lbl_h_totalingreso.Text = "TotalIngreso:"
        Me.txt_h_totalingreso.Location = New System.Drawing.Point(645, 213)
        Me.txt_h_totalingreso.Name = "txt_h_totalingreso"
        Me.txt_h_totalingreso.ReadOnly = True
        Me.txt_h_totalingreso.Size = New System.Drawing.Size(130, 20)
        Me.txt_h_totalingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_estado_periodo
        '
        Me.lbl_estado_periodo.AutoSize = True
        Me.lbl_estado_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado_periodo.Location = New System.Drawing.Point(12, 324)
        Me.lbl_estado_periodo.Name = "lbl_estado_periodo"
        Me.lbl_estado_periodo.Text = ""
        '
        'gb_habilitar
        '
        Me.gb_habilitar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_habilitar.Controls.Add(Me.lbl_nueva_fecha)
        Me.gb_habilitar.Controls.Add(Me.dtp_nueva_fecha)
        Me.gb_habilitar.Controls.Add(Me.lbl_periodo_calc)
        Me.gb_habilitar.Controls.Add(Me.btn_habilitar)
        Me.gb_habilitar.Controls.Add(Me.lbl_periodo_original)
        Me.gb_habilitar.Controls.Add(Me.btn_restaurar)
        Me.gb_habilitar.Location = New System.Drawing.Point(12, 344)
        Me.gb_habilitar.Name = "gb_habilitar"
        Me.gb_habilitar.Size = New System.Drawing.Size(976, 86)
        Me.gb_habilitar.TabIndex = 2
        Me.gb_habilitar.TabStop = False
        Me.gb_habilitar.Text = "Habilitar Período"
        Me.gb_habilitar.Visible = False
        '
        'lbl_nueva_fecha
        '
        Me.lbl_nueva_fecha.AutoSize = True
        Me.lbl_nueva_fecha.Location = New System.Drawing.Point(12, 26)
        Me.lbl_nueva_fecha.Name = "lbl_nueva_fecha"
        Me.lbl_nueva_fecha.Text = "Nueva Fecha:"
        '
        'dtp_nueva_fecha
        '
        Me.dtp_nueva_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_nueva_fecha.Location = New System.Drawing.Point(100, 22)
        Me.dtp_nueva_fecha.Name = "dtp_nueva_fecha"
        Me.dtp_nueva_fecha.Size = New System.Drawing.Size(110, 20)
        Me.dtp_nueva_fecha.TabIndex = 1
        '
        'lbl_periodo_calc
        '
        Me.lbl_periodo_calc.AutoSize = True
        Me.lbl_periodo_calc.Location = New System.Drawing.Point(230, 26)
        Me.lbl_periodo_calc.Name = "lbl_periodo_calc"
        Me.lbl_periodo_calc.Text = "PeriodoLibro: "
        '
        'btn_habilitar
        '
        Me.btn_habilitar.Location = New System.Drawing.Point(430, 20)
        Me.btn_habilitar.Name = "btn_habilitar"
        Me.btn_habilitar.Size = New System.Drawing.Size(160, 25)
        Me.btn_habilitar.TabIndex = 3
        Me.btn_habilitar.Text = "Habilitar Período"
        Me.btn_habilitar.UseVisualStyleBackColor = True
        '
        'lbl_periodo_original
        '
        Me.lbl_periodo_original.AutoSize = True
        Me.lbl_periodo_original.Location = New System.Drawing.Point(12, 58)
        Me.lbl_periodo_original.Name = "lbl_periodo_original"
        Me.lbl_periodo_original.Text = ""
        '
        'btn_restaurar
        '
        Me.btn_restaurar.Enabled = False
        Me.btn_restaurar.Location = New System.Drawing.Point(720, 52)
        Me.btn_restaurar.Name = "btn_restaurar"
        Me.btn_restaurar.Size = New System.Drawing.Size(210, 25)
        Me.btn_restaurar.TabIndex = 5
        Me.btn_restaurar.Text = "Regresar a Período Original"
        Me.btn_restaurar.UseVisualStyleBackColor = True
        '
        'lbl_documento_detalle
        '
        Me.lbl_documento_detalle.AutoSize = True
        Me.lbl_documento_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_documento_detalle.Location = New System.Drawing.Point(12, 446)
        Me.lbl_documento_detalle.Name = "lbl_documento_detalle"
        Me.lbl_documento_detalle.Text = "DOCUMENTO DETALLE"
        '
        'lbl_lineas
        '
        Me.lbl_lineas.AutoSize = True
        Me.lbl_lineas.Location = New System.Drawing.Point(170, 446)
        Me.lbl_lineas.Name = "lbl_lineas"
        Me.lbl_lineas.Text = "Líneas: 0"
        '
        'chk_habilitar_edicion
        '
        Me.chk_habilitar_edicion.AutoSize = True
        Me.chk_habilitar_edicion.Enabled = False
        Me.chk_habilitar_edicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_habilitar_edicion.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chk_habilitar_edicion.Location = New System.Drawing.Point(800, 22)
        Me.chk_habilitar_edicion.Name = "chk_habilitar_edicion"
        Me.chk_habilitar_edicion.Text = "HABILITAR EDICIÓN"
        Me.chk_habilitar_edicion.UseVisualStyleBackColor = True
        '
        'dgv_detalle
        '
        Me.dgv_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.EnableHeadersVisualStyles = False
        Me.dgv_detalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(12, 466)
        Me.dgv_detalle.MultiSelect = False
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.RowHeadersVisible = False
        Me.dgv_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_detalle.Size = New System.Drawing.Size(976, 210)
        Me.dgv_detalle.TabIndex = 3
        '
        'btn_agregar
        '
        Me.btn_agregar.Enabled = False
        Me.btn_agregar.Location = New System.Drawing.Point(12, 684)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(180, 27)
        Me.btn_agregar.TabIndex = 4
        Me.btn_agregar.Text = "Agregar Línea"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Location = New System.Drawing.Point(200, 684)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(200, 27)
        Me.btn_eliminar.TabIndex = 5
        Me.btn_eliminar.Text = "Eliminar Línea(s) marcadas"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_descartar
        '
        Me.btn_descartar.Enabled = False
        Me.btn_descartar.Location = New System.Drawing.Point(408, 684)
        Me.btn_descartar.Name = "btn_descartar"
        Me.btn_descartar.Size = New System.Drawing.Size(150, 27)
        Me.btn_descartar.TabIndex = 6
        Me.btn_descartar.Text = "Descartar cambios"
        Me.btn_descartar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(760, 682)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(200, 31)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "GUARDAR CAMBIOS"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'lbl_cambios
        '
        Me.lbl_cambios.AutoSize = True
        Me.lbl_cambios.Location = New System.Drawing.Point(12, 720)
        Me.lbl_cambios.Name = "lbl_cambios"
        Me.lbl_cambios.Text = "Cambios pendientes: 0 modificadas, 0 nuevas, 0 eliminadas"
        '
        'frm_actualizacion_oc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = False
        Me.ClientSize = New System.Drawing.Size(1000, 745)
        Me.pnl_main.Controls.Add(Me.lbl_cambios)
        Me.pnl_main.Controls.Add(Me.btn_guardar)
        Me.pnl_main.Controls.Add(Me.btn_descartar)
        Me.pnl_main.Controls.Add(Me.btn_eliminar)
        Me.pnl_main.Controls.Add(Me.btn_agregar)
        Me.pnl_main.Controls.Add(Me.dgv_detalle)
        Me.pnl_main.Controls.Add(Me.lbl_lineas)
        Me.pnl_main.Controls.Add(Me.lbl_documento_detalle)
        Me.pnl_main.Controls.Add(Me.gb_habilitar)
        Me.pnl_main.Controls.Add(Me.lbl_estado_periodo)
        Me.pnl_main.Controls.Add(Me.gb_documento)
        Me.pnl_main.Controls.Add(Me.gb_busqueda)
        Me.pnl_main.AutoScroll = True
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(0, 0)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(1000, 745)
        Me.Controls.Add(Me.pnl_main)
        Me.MinimumSize = New System.Drawing.Size(780, 420)
        Me.Name = "frm_actualizacion_oc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización OC"
        Me.gb_busqueda.ResumeLayout(False)
        Me.gb_busqueda.PerformLayout()
        Me.gb_documento.ResumeLayout(False)
        Me.gb_documento.PerformLayout()
        Me.gb_habilitar.ResumeLayout(False)
        Me.gb_habilitar.PerformLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_main.ResumeLayout(False)
        Me.pnl_main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents gb_busqueda As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo As System.Windows.Forms.Label
    Friend WithEvents cmb_tipodocto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents gb_documento As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_h_empresa As System.Windows.Forms.Label
    Friend WithEvents txt_h_empresa As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_tipodocto As System.Windows.Forms.Label
    Friend WithEvents txt_h_tipodocto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_numero As System.Windows.Forms.Label
    Friend WithEvents txt_h_numero As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_correlativo As System.Windows.Forms.Label
    Friend WithEvents txt_h_correlativo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_proveedor As System.Windows.Forms.Label
    Friend WithEvents txt_h_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_moneda As System.Windows.Forms.Label
    Friend WithEvents txt_h_moneda As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_vigencia As System.Windows.Forms.Label
    Friend WithEvents txt_h_vigencia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_emitido As System.Windows.Forms.Label
    Friend WithEvents txt_h_emitido As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_valoriza As System.Windows.Forms.Label
    Friend WithEvents txt_h_valoriza As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_aprobacion As System.Windows.Forms.Label
    Friend WithEvents txt_h_aprobacion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_usuariomodif As System.Windows.Forms.Label
    Friend WithEvents txt_h_usuariomodif As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_periodolibro As System.Windows.Forms.Label
    Friend WithEvents txt_h_periodolibro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fecha As System.Windows.Forms.Label
    Friend WithEvents txt_h_fecha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechavcto As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechavcto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechacomprobante As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechacomprobante As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechaestado As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechaestado As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechamodif As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechamodif As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechaumodif As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechaumodif As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechacierre As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechacierre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_fechaaprueba As System.Windows.Forms.Label
    Friend WithEvents txt_h_fechaaprueba As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_neto As System.Windows.Forms.Label
    Friend WithEvents txt_h_neto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_subtotal As System.Windows.Forms.Label
    Friend WithEvents txt_h_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_total As System.Windows.Forms.Label
    Friend WithEvents txt_h_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_netoingreso As System.Windows.Forms.Label
    Friend WithEvents txt_h_netoingreso As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_subtotalingreso As System.Windows.Forms.Label
    Friend WithEvents txt_h_subtotalingreso As System.Windows.Forms.TextBox
    Friend WithEvents lbl_h_totalingreso As System.Windows.Forms.Label
    Friend WithEvents txt_h_totalingreso As System.Windows.Forms.TextBox
    Friend WithEvents lbl_estado_periodo As System.Windows.Forms.Label
    Friend WithEvents gb_habilitar As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_nueva_fecha As System.Windows.Forms.Label
    Friend WithEvents dtp_nueva_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_periodo_calc As System.Windows.Forms.Label
    Friend WithEvents btn_habilitar As System.Windows.Forms.Button
    Friend WithEvents lbl_periodo_original As System.Windows.Forms.Label
    Friend WithEvents btn_restaurar As System.Windows.Forms.Button
    Friend WithEvents lbl_documento_detalle As System.Windows.Forms.Label
    Friend WithEvents lbl_lineas As System.Windows.Forms.Label
    Friend WithEvents chk_habilitar_edicion As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_descartar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents lbl_cambios As System.Windows.Forms.Label
    Friend WithEvents pnl_main As System.Windows.Forms.Panel
End Class