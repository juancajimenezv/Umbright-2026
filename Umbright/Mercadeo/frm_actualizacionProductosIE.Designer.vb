<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_actualizacionProductosIE
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

    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresasTitulo As System.Windows.Forms.Label
    Friend WithEvents dgvEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents btnMarcarTodo As System.Windows.Forms.Button
    Friend WithEvents btnDesmarcarTodo As System.Windows.Forms.Button
    Friend WithEvents grpCampos As System.Windows.Forms.GroupBox
    Friend WithEvents chk_tipoproducto As System.Windows.Forms.CheckBox
    Friend WithEvents txt_tipoproducto As System.Windows.Forms.ComboBox
    Friend WithEvents chk_familia As System.Windows.Forms.CheckBox
    Friend WithEvents txt_familia As System.Windows.Forms.ComboBox
    Friend WithEvents chk_subfamilia As System.Windows.Forms.CheckBox
    Friend WithEvents txt_subfamilia As System.Windows.Forms.ComboBox
    Friend WithEvents chk_tipo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents chk_subtipo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_subtipo As System.Windows.Forms.ComboBox
    Friend WithEvents chk_factoralt As System.Windows.Forms.CheckBox
    Friend WithEvents txt_factoralt As System.Windows.Forms.TextBox
    Friend WithEvents chk_precioventa As System.Windows.Forms.CheckBox
    Friend WithEvents txt_precioventa As System.Windows.Forms.TextBox
    Friend WithEvents chk_volumen As System.Windows.Forms.CheckBox
    Friend WithEvents txt_volumen As System.Windows.Forms.TextBox
    Friend WithEvents chk_procedencia As System.Windows.Forms.CheckBox
    Friend WithEvents txt_procedencia As System.Windows.Forms.ComboBox
    Friend WithEvents chk_analisisproducto4 As System.Windows.Forms.CheckBox
    Friend WithEvents txt_analisisproducto4 As System.Windows.Forms.ComboBox
    Friend WithEvents chk_glosa As System.Windows.Forms.CheckBox
    Friend WithEvents txt_glosa As System.Windows.Forms.TextBox
    Friend WithEvents chk_vigente As System.Windows.Forms.CheckBox
    Friend WithEvents txt_vigente As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_vigente_hint As System.Windows.Forms.Label
    Friend WithEvents chk_AnalisisProducto17 As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_AnalisisProducto17 As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cuentacompra As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cuentacompra As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cuentaventa As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cuentaventa As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cuentacosto As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cuentacosto As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cuentadesc As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cuentadesc As System.Windows.Forms.ComboBox
    Friend WithEvents chk_cuentadev As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cuentadev As System.Windows.Forms.ComboBox
    Friend WithEvents lblObs As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.ComboBox()
        Me.lblEmpresasTitulo = New System.Windows.Forms.Label()
        Me.dgvEmpresas = New System.Windows.Forms.DataGridView()
        Me.btnMarcarTodo = New System.Windows.Forms.Button()
        Me.btnDesmarcarTodo = New System.Windows.Forms.Button()
        Me.grpCampos = New System.Windows.Forms.GroupBox()
        Me.chk_tipoproducto = New System.Windows.Forms.CheckBox()
        Me.txt_tipoproducto = New System.Windows.Forms.ComboBox()
        Me.chk_familia = New System.Windows.Forms.CheckBox()
        Me.txt_familia = New System.Windows.Forms.ComboBox()
        Me.chk_subfamilia = New System.Windows.Forms.CheckBox()
        Me.txt_subfamilia = New System.Windows.Forms.ComboBox()
        Me.chk_tipo = New System.Windows.Forms.CheckBox()
        Me.txt_tipo = New System.Windows.Forms.ComboBox()
        Me.chk_subtipo = New System.Windows.Forms.CheckBox()
        Me.txt_subtipo = New System.Windows.Forms.ComboBox()
        Me.chk_factoralt = New System.Windows.Forms.CheckBox()
        Me.txt_factoralt = New System.Windows.Forms.TextBox()
        Me.chk_precioventa = New System.Windows.Forms.CheckBox()
        Me.txt_precioventa = New System.Windows.Forms.TextBox()
        Me.chk_volumen = New System.Windows.Forms.CheckBox()
        Me.txt_volumen = New System.Windows.Forms.TextBox()
        Me.chk_procedencia = New System.Windows.Forms.CheckBox()
        Me.txt_procedencia = New System.Windows.Forms.ComboBox()
        Me.chk_analisisproducto4 = New System.Windows.Forms.CheckBox()
        Me.txt_analisisproducto4 = New System.Windows.Forms.ComboBox()
        Me.chk_glosa = New System.Windows.Forms.CheckBox()
        Me.txt_glosa = New System.Windows.Forms.TextBox()
        Me.chk_vigente = New System.Windows.Forms.CheckBox()
        Me.txt_vigente = New System.Windows.Forms.ComboBox()
        Me.lbl_vigente_hint = New System.Windows.Forms.Label()
        Me.chk_AnalisisProducto17 = New System.Windows.Forms.CheckBox()
        Me.cmb_AnalisisProducto17 = New System.Windows.Forms.ComboBox()
        Me.chk_cuentacompra = New System.Windows.Forms.CheckBox()
        Me.cmb_cuentacompra = New System.Windows.Forms.ComboBox()
        Me.chk_cuentaventa = New System.Windows.Forms.CheckBox()
        Me.cmb_cuentaventa = New System.Windows.Forms.ComboBox()
        Me.chk_cuentacosto = New System.Windows.Forms.CheckBox()
        Me.cmb_cuentacosto = New System.Windows.Forms.ComboBox()
        Me.chk_cuentadesc = New System.Windows.Forms.CheckBox()
        Me.cmb_cuentadesc = New System.Windows.Forms.ComboBox()
        Me.chk_cuentadev = New System.Windows.Forms.CheckBox()
        Me.cmb_cuentadev = New System.Windows.Forms.ComboBox()
        Me.lblObs = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCampos.SuspendLayout()
        Me.SuspendLayout()

        Me.lblCodigo.AutoSize = True : Me.lblCodigo.Location = New System.Drawing.Point(20, 20) : Me.lblCodigo.Text = "Código producto:"
        Me.txtCodigo.Location = New System.Drawing.Point(140, 17) : Me.txtCodigo.Size = New System.Drawing.Size(400, 21)
        Me.txtCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.txtCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.btnBuscar.Location = New System.Drawing.Point(550, 15) : Me.btnBuscar.Size = New System.Drawing.Size(100, 25)
        Me.btnBuscar.Text = "Buscar" : Me.btnBuscar.UseVisualStyleBackColor = True

        Me.lblDesc.AutoSize = True : Me.lblDesc.Location = New System.Drawing.Point(20, 55) : Me.lblDesc.Text = "Descripción:"
        Me.txtDesc.Location = New System.Drawing.Point(140, 52) : Me.txtDesc.Size = New System.Drawing.Size(580, 21)
        Me.txtDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None

        Me.lblEmpresasTitulo.AutoSize = True : Me.lblEmpresasTitulo.Location = New System.Drawing.Point(20, 85)
        Me.lblEmpresasTitulo.Text = "Empresas donde existe el producto (marca las que quieres actualizar):"
        Me.lblEmpresasTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)

        Me.dgvEmpresas.Location = New System.Drawing.Point(20, 105)
        Me.dgvEmpresas.Size = New System.Drawing.Size(580, 120)
        Me.dgvEmpresas.AllowUserToAddRows = False
        Me.dgvEmpresas.AllowUserToDeleteRows = False
        Me.dgvEmpresas.AllowUserToResizeRows = False
        Me.dgvEmpresas.RowHeadersVisible = False
        Me.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.dgvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpresas.MultiSelect = False

        Me.btnMarcarTodo.Location = New System.Drawing.Point(610, 105) : Me.btnMarcarTodo.Size = New System.Drawing.Size(110, 22)
        Me.btnMarcarTodo.Text = "Marcar todas" : Me.btnMarcarTodo.UseVisualStyleBackColor = True

        Me.btnDesmarcarTodo.Location = New System.Drawing.Point(610, 133) : Me.btnDesmarcarTodo.Size = New System.Drawing.Size(110, 22)
        Me.btnDesmarcarTodo.Text = "Desmarcar todas" : Me.btnDesmarcarTodo.UseVisualStyleBackColor = True

        Me.grpCampos.Location = New System.Drawing.Point(20, 235) : Me.grpCampos.Size = New System.Drawing.Size(820, 325)
        Me.grpCampos.Text = "Campos a actualizar (marca y escribe el nuevo valor)"
        Me.grpCampos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)

        Me.chk_tipoproducto.AutoSize = True : Me.chk_tipoproducto.Location = New System.Drawing.Point(15, 25)
        Me.chk_tipoproducto.Text = "TIPO DE PRODUCTO" : Me.chk_tipoproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_tipoproducto.Location = New System.Drawing.Point(160, 23) : Me.txt_tipoproducto.Size = New System.Drawing.Size(200, 20)
        Me.txt_tipoproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList : Me.txt_tipoproducto.Enabled = False : Me.txt_tipoproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_familia.AutoSize = True : Me.chk_familia.Location = New System.Drawing.Point(15, 58)
        Me.chk_familia.Text = "FAMILIA" : Me.chk_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_familia.Location = New System.Drawing.Point(160, 56) : Me.txt_familia.Size = New System.Drawing.Size(200, 20)
        Me.txt_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList : Me.txt_familia.Enabled = False : Me.txt_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_subfamilia.AutoSize = True : Me.chk_subfamilia.Location = New System.Drawing.Point(15, 91)
        Me.chk_subfamilia.Text = "PROVEEDOR" : Me.chk_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_subfamilia.Location = New System.Drawing.Point(160, 89) : Me.txt_subfamilia.Size = New System.Drawing.Size(200, 20)
        Me.txt_subfamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList : Me.txt_subfamilia.Enabled = False : Me.txt_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_tipo.AutoSize = True : Me.chk_tipo.Location = New System.Drawing.Point(15, 124)
        Me.chk_tipo.Text = "TIPO" : Me.chk_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_tipo.Location = New System.Drawing.Point(160, 122) : Me.txt_tipo.Size = New System.Drawing.Size(200, 20)
        Me.txt_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList : Me.txt_tipo.Enabled = False : Me.txt_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_subtipo.AutoSize = True : Me.chk_subtipo.Location = New System.Drawing.Point(15, 157)
        Me.chk_subtipo.Text = "MARCA" : Me.chk_subtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_subtipo.Location = New System.Drawing.Point(160, 155) : Me.txt_subtipo.Size = New System.Drawing.Size(200, 20)
        Me.txt_subtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList : Me.txt_subtipo.Enabled = False : Me.txt_subtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_factoralt.AutoSize = True : Me.chk_factoralt.Location = New System.Drawing.Point(15, 190)
        Me.chk_factoralt.Text = "UXC" : Me.chk_factoralt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_factoralt.Location = New System.Drawing.Point(160, 188) : Me.txt_factoralt.Size = New System.Drawing.Size(200, 20)
        Me.txt_factoralt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper : Me.txt_factoralt.Enabled = False : Me.txt_factoralt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_precioventa.AutoSize = True : Me.chk_precioventa.Location = New System.Drawing.Point(15, 223)
        Me.chk_precioventa.Text = "PRECIO SUGERIDO" : Me.chk_precioventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_precioventa.Location = New System.Drawing.Point(160, 221) : Me.txt_precioventa.Size = New System.Drawing.Size(200, 20)
        Me.txt_precioventa.Enabled = False : Me.txt_precioventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_volumen.AutoSize = True : Me.chk_volumen.Location = New System.Drawing.Point(15, 256)
        Me.chk_volumen.Text = "MEDIDA EN LITROS" : Me.chk_volumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_volumen.Location = New System.Drawing.Point(160, 254) : Me.txt_volumen.Size = New System.Drawing.Size(200, 20)
        Me.txt_volumen.Enabled = False : Me.txt_volumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_procedencia.AutoSize = True : Me.chk_procedencia.Location = New System.Drawing.Point(15, 289)
        Me.chk_procedencia.Text = "PROCEDENCIA" : Me.chk_procedencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_procedencia.Location = New System.Drawing.Point(160, 287) : Me.txt_procedencia.Size = New System.Drawing.Size(200, 20)
        Me.txt_procedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_procedencia.Enabled = False : Me.txt_procedencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_analisisproducto4.AutoSize = True : Me.chk_analisisproducto4.Location = New System.Drawing.Point(380, 25)
        Me.chk_analisisproducto4.Text = "ORIGEN" : Me.chk_analisisproducto4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_analisisproducto4.Location = New System.Drawing.Point(575, 23) : Me.txt_analisisproducto4.Size = New System.Drawing.Size(205, 20)
        Me.txt_analisisproducto4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_analisisproducto4.Enabled = False : Me.txt_analisisproducto4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_glosa.AutoSize = True : Me.chk_glosa.Location = New System.Drawing.Point(380, 58)
        Me.chk_glosa.Text = "DESCRIPCIÓN DE PRODUCTO" : Me.chk_glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_glosa.Location = New System.Drawing.Point(575, 56) : Me.txt_glosa.Size = New System.Drawing.Size(205, 20)
        Me.txt_glosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_glosa.Enabled = False : Me.txt_glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_vigente.AutoSize = True : Me.chk_vigente.Location = New System.Drawing.Point(380, 91)
        Me.chk_vigente.Text = "ACTIVAR/INACTIVAR PRODUCTO" : Me.chk_vigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_vigente.Location = New System.Drawing.Point(600, 89) : Me.txt_vigente.Size = New System.Drawing.Size(50, 21)
        Me.txt_vigente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_vigente.Items.AddRange(New Object() {"S", "N"})
        Me.txt_vigente.Enabled = False : Me.txt_vigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lbl_vigente_hint.AutoSize = True : Me.lbl_vigente_hint.Location = New System.Drawing.Point(658, 91)
        Me.lbl_vigente_hint.Text = """S"" ACTIVAR    ""N"" INACTIVAR"
        Me.lbl_vigente_hint.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold)
        Me.lbl_vigente_hint.ForeColor = System.Drawing.Color.DarkBlue

        Me.chk_AnalisisProducto17.AutoSize = True : Me.chk_AnalisisProducto17.Location = New System.Drawing.Point(380, 124)
        Me.chk_AnalisisProducto17.Text = "BU" : Me.chk_AnalisisProducto17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_AnalisisProducto17.Location = New System.Drawing.Point(575, 122) : Me.cmb_AnalisisProducto17.Size = New System.Drawing.Size(205, 21)
        Me.cmb_AnalisisProducto17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_AnalisisProducto17.Enabled = False : Me.cmb_AnalisisProducto17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_cuentacompra.AutoSize = True : Me.chk_cuentacompra.Location = New System.Drawing.Point(380, 157)
        Me.chk_cuentacompra.Text = "CUENTA COMPRA" : Me.chk_cuentacompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_cuentacompra.Location = New System.Drawing.Point(575, 155) : Me.cmb_cuentacompra.Size = New System.Drawing.Size(205, 21)
        Me.cmb_cuentacompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_cuentacompra.Enabled = False : Me.cmb_cuentacompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_cuentaventa.AutoSize = True : Me.chk_cuentaventa.Location = New System.Drawing.Point(380, 190)
        Me.chk_cuentaventa.Text = "CUENTA VENTA" : Me.chk_cuentaventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_cuentaventa.Location = New System.Drawing.Point(575, 188) : Me.cmb_cuentaventa.Size = New System.Drawing.Size(205, 21)
        Me.cmb_cuentaventa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_cuentaventa.Enabled = False : Me.cmb_cuentaventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_cuentacosto.AutoSize = True : Me.chk_cuentacosto.Location = New System.Drawing.Point(380, 223)
        Me.chk_cuentacosto.Text = "CUENTA COSTO" : Me.chk_cuentacosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_cuentacosto.Location = New System.Drawing.Point(575, 221) : Me.cmb_cuentacosto.Size = New System.Drawing.Size(205, 21)
        Me.cmb_cuentacosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_cuentacosto.Enabled = False : Me.cmb_cuentacosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_cuentadesc.AutoSize = True : Me.chk_cuentadesc.Location = New System.Drawing.Point(380, 256)
        Me.chk_cuentadesc.Text = "CUENTA DESCUENTO" : Me.chk_cuentadesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_cuentadesc.Location = New System.Drawing.Point(575, 254) : Me.cmb_cuentadesc.Size = New System.Drawing.Size(205, 21)
        Me.cmb_cuentadesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_cuentadesc.Enabled = False : Me.cmb_cuentadesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.chk_cuentadev.AutoSize = True : Me.chk_cuentadev.Location = New System.Drawing.Point(380, 289)
        Me.chk_cuentadev.Text = "CUENTA DEVOLUCIONES" : Me.chk_cuentadev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_cuentadev.Location = New System.Drawing.Point(575, 287) : Me.cmb_cuentadev.Size = New System.Drawing.Size(205, 21)
        Me.cmb_cuentadev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_cuentadev.Enabled = False : Me.cmb_cuentadev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)

        Me.grpCampos.Controls.Add(Me.chk_tipoproducto) : Me.grpCampos.Controls.Add(Me.txt_tipoproducto)
        Me.grpCampos.Controls.Add(Me.chk_familia) : Me.grpCampos.Controls.Add(Me.txt_familia)
        Me.grpCampos.Controls.Add(Me.chk_subfamilia) : Me.grpCampos.Controls.Add(Me.txt_subfamilia)
        Me.grpCampos.Controls.Add(Me.chk_tipo) : Me.grpCampos.Controls.Add(Me.txt_tipo)
        Me.grpCampos.Controls.Add(Me.chk_subtipo) : Me.grpCampos.Controls.Add(Me.txt_subtipo)
        Me.grpCampos.Controls.Add(Me.chk_factoralt) : Me.grpCampos.Controls.Add(Me.txt_factoralt)
        Me.grpCampos.Controls.Add(Me.chk_precioventa) : Me.grpCampos.Controls.Add(Me.txt_precioventa)
        Me.grpCampos.Controls.Add(Me.chk_volumen) : Me.grpCampos.Controls.Add(Me.txt_volumen)
        Me.grpCampos.Controls.Add(Me.chk_procedencia) : Me.grpCampos.Controls.Add(Me.txt_procedencia)
        Me.grpCampos.Controls.Add(Me.chk_analisisproducto4) : Me.grpCampos.Controls.Add(Me.txt_analisisproducto4)
        Me.grpCampos.Controls.Add(Me.chk_glosa) : Me.grpCampos.Controls.Add(Me.txt_glosa)
        Me.grpCampos.Controls.Add(Me.chk_vigente) : Me.grpCampos.Controls.Add(Me.txt_vigente)
        Me.grpCampos.Controls.Add(Me.lbl_vigente_hint)
        Me.grpCampos.Controls.Add(Me.chk_AnalisisProducto17) : Me.grpCampos.Controls.Add(Me.cmb_AnalisisProducto17)
        Me.grpCampos.Controls.Add(Me.chk_cuentacompra) : Me.grpCampos.Controls.Add(Me.cmb_cuentacompra)
        Me.grpCampos.Controls.Add(Me.chk_cuentaventa) : Me.grpCampos.Controls.Add(Me.cmb_cuentaventa)
        Me.grpCampos.Controls.Add(Me.chk_cuentacosto) : Me.grpCampos.Controls.Add(Me.cmb_cuentacosto)
        Me.grpCampos.Controls.Add(Me.chk_cuentadesc) : Me.grpCampos.Controls.Add(Me.cmb_cuentadesc)
        Me.grpCampos.Controls.Add(Me.chk_cuentadev) : Me.grpCampos.Controls.Add(Me.cmb_cuentadev)

        Me.lblObs.AutoSize = True : Me.lblObs.Location = New System.Drawing.Point(20, 578) : Me.lblObs.Text = "Observación:"
        Me.txtObs.Location = New System.Drawing.Point(140, 575) : Me.txtObs.Size = New System.Drawing.Size(600, 20)

        Me.btnGuardar.Location = New System.Drawing.Point(730, 600) : Me.btnGuardar.Size = New System.Drawing.Size(110, 32)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(76, Byte), CType(175, Byte), CType(80, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White : Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)

        Me.lblEstado.AutoSize = True : Me.lblEstado.Location = New System.Drawing.Point(20, 605)
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkBlue : Me.lblEstado.Text = ""
        Me.lblEstado.MaximumSize = New System.Drawing.Size(580, 0)

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 650)
        Me.Controls.Add(Me.lblCodigo) : Me.Controls.Add(Me.txtCodigo) : Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblDesc) : Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.lblEmpresasTitulo) : Me.Controls.Add(Me.dgvEmpresas)
        Me.Controls.Add(Me.btnMarcarTodo) : Me.Controls.Add(Me.btnDesmarcarTodo)
        Me.Controls.Add(Me.grpCampos)
        Me.Controls.Add(Me.lblObs) : Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.btnGuardar) : Me.Controls.Add(Me.lblEstado)
        Me.MaximizeBox = True : Me.MinimizeBox = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.Name = "frm_actualizacionProductosIE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización Individual"
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCampos.ResumeLayout(False) : Me.grpCampos.PerformLayout()
        Me.ResumeLayout(False) : Me.PerformLayout()
    End Sub
End Class
