Public Class frm_int_prepara_informacion
    Inherits System.Windows.Forms.Form
    Dim ds_preparacion As DataSet
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Dim pi_meses_adicionales As Integer
    'Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today)

    Friend WithEvents chk_existencias_cdx As System.Windows.Forms.CheckBox
    Dim pdiaActual As Integer = DatePart(DateInterval.DayOfYear, Today)
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public pdfechaIngreso As DateTime

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef ds_anterior As Object)
        MyBase.New()
        ds_preparacion = ds_anterior

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_existencias_cd As System.Windows.Forms.CheckBox
    Friend WithEvents chk_obtener_productos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_existencias_da As System.Windows.Forms.CheckBox
    Friend WithEvents chk_dias_inventarios As System.Windows.Forms.CheckBox
    Friend WithEvents chk_preparando_informacion As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Calculando_traslado As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chk_calcular_transitos As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_prepara_informacion))
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_existencias_cdx = New System.Windows.Forms.CheckBox
        Me.chk_existencias_cd = New System.Windows.Forms.CheckBox
        Me.chk_obtener_productos = New System.Windows.Forms.CheckBox
        Me.chk_existencias_da = New System.Windows.Forms.CheckBox
        Me.chk_dias_inventarios = New System.Windows.Forms.CheckBox
        Me.chk_preparando_informacion = New System.Windows.Forms.CheckBox
        Me.chk_Calculando_traslado = New System.Windows.Forms.CheckBox
        Me.chk_calcular_transitos = New System.Windows.Forms.CheckBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbProveedor = New System.Windows.Forms.ComboBox
        Me.chkProveedor = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(374, 12)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(80, 79)
        Me.btn_generar.TabIndex = 0
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_existencias_cdx)
        Me.GroupBox1.Controls.Add(Me.chk_existencias_cd)
        Me.GroupBox1.Controls.Add(Me.chk_obtener_productos)
        Me.GroupBox1.Controls.Add(Me.chk_existencias_da)
        Me.GroupBox1.Controls.Add(Me.chk_dias_inventarios)
        Me.GroupBox1.Controls.Add(Me.chk_preparando_informacion)
        Me.GroupBox1.Controls.Add(Me.chk_Calculando_traslado)
        Me.GroupBox1.Controls.Add(Me.chk_calcular_transitos)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 176)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado ...."
        '
        'chk_existencias_cdx
        '
        Me.chk_existencias_cdx.AutoSize = True
        Me.chk_existencias_cdx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_existencias_cdx.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_existencias_cdx.Location = New System.Drawing.Point(33, 152)
        Me.chk_existencias_cdx.Name = "chk_existencias_cdx"
        Me.chk_existencias_cdx.Size = New System.Drawing.Size(177, 18)
        Me.chk_existencias_cdx.TabIndex = 1
        Me.chk_existencias_cdx.Text = "Obteniendo Existencias CDX"
        Me.chk_existencias_cdx.Visible = False
        '
        'chk_existencias_cd
        '
        Me.chk_existencias_cd.AutoSize = True
        Me.chk_existencias_cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_existencias_cd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_existencias_cd.Location = New System.Drawing.Point(40, 54)
        Me.chk_existencias_cd.Name = "chk_existencias_cd"
        Me.chk_existencias_cd.Size = New System.Drawing.Size(170, 18)
        Me.chk_existencias_cd.TabIndex = 1
        Me.chk_existencias_cd.Text = "Obteniendo Existencias CD"
        '
        'chk_obtener_productos
        '
        Me.chk_obtener_productos.AutoSize = True
        Me.chk_obtener_productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_obtener_productos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_obtener_productos.Location = New System.Drawing.Point(40, 35)
        Me.chk_obtener_productos.Name = "chk_obtener_productos"
        Me.chk_obtener_productos.Size = New System.Drawing.Size(128, 18)
        Me.chk_obtener_productos.TabIndex = 0
        Me.chk_obtener_productos.Text = "Obtener Productos"
        '
        'chk_existencias_da
        '
        Me.chk_existencias_da.AutoSize = True
        Me.chk_existencias_da.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_existencias_da.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_existencias_da.Location = New System.Drawing.Point(40, 72)
        Me.chk_existencias_da.Name = "chk_existencias_da"
        Me.chk_existencias_da.Size = New System.Drawing.Size(170, 18)
        Me.chk_existencias_da.TabIndex = 1
        Me.chk_existencias_da.Text = "Obteniendo Existencias DA"
        '
        'chk_dias_inventarios
        '
        Me.chk_dias_inventarios.AutoSize = True
        Me.chk_dias_inventarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_dias_inventarios.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_dias_inventarios.Location = New System.Drawing.Point(40, 91)
        Me.chk_dias_inventarios.Name = "chk_dias_inventarios"
        Me.chk_dias_inventarios.Size = New System.Drawing.Size(121, 18)
        Me.chk_dias_inventarios.TabIndex = 1
        Me.chk_dias_inventarios.Text = "Dias de Inventario"
        '
        'chk_preparando_informacion
        '
        Me.chk_preparando_informacion.AutoSize = True
        Me.chk_preparando_informacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_preparando_informacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_preparando_informacion.Location = New System.Drawing.Point(40, 16)
        Me.chk_preparando_informacion.Name = "chk_preparando_informacion"
        Me.chk_preparando_informacion.Size = New System.Drawing.Size(156, 18)
        Me.chk_preparando_informacion.TabIndex = 1
        Me.chk_preparando_informacion.Text = "Preparando Informacion"
        '
        'chk_Calculando_traslado
        '
        Me.chk_Calculando_traslado.AutoSize = True
        Me.chk_Calculando_traslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_Calculando_traslado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Calculando_traslado.Location = New System.Drawing.Point(40, 128)
        Me.chk_Calculando_traslado.Name = "chk_Calculando_traslado"
        Me.chk_Calculando_traslado.Size = New System.Drawing.Size(134, 18)
        Me.chk_Calculando_traslado.TabIndex = 1
        Me.chk_Calculando_traslado.Text = "Calculando Traslado"
        '
        'chk_calcular_transitos
        '
        Me.chk_calcular_transitos.AutoSize = True
        Me.chk_calcular_transitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_calcular_transitos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_calcular_transitos.Location = New System.Drawing.Point(40, 110)
        Me.chk_calcular_transitos.Name = "chk_calcular_transitos"
        Me.chk_calcular_transitos.Size = New System.Drawing.Size(139, 18)
        Me.chk_calcular_transitos.TabIndex = 1
        Me.chk_calcular_transitos.Text = "Calculando Transitos"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(31, 267)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(361, 23)
        Me.ProgressBar1.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkProveedor)
        Me.GroupBox2.Controls.Add(Me.cmbProveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(31, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(316, 63)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(75, 16)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(222, 22)
        Me.cmbProveedor.TabIndex = 0
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkProveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkProveedor.Location = New System.Drawing.Point(75, 40)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(126, 18)
        Me.chkProveedor.TabIndex = 2
        Me.chkProveedor.Text = "GenerarProveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Proveedor"
        '
        'frm_int_prepara_informacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(466, 296)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_generar)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_int_prepara_informacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. SCM - Internaciones | Prepara Informacion .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim cuenta As Integer = 0


    Private Sub llenarCombo()
        Dim lsSql As String

        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")
        Dim clsGen As New ClasesGenerales.General
        Try
            oTrans.open()
            'Parametros Generales

            lsSql = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"
            dt = oTrans.Obtiene(lsSql)
            dt.TableName = "prv_proveedor"
            dt = clsGen.ValoresDistinto(dt, "proveedor".Split(","))
            Me.cmbProveedor.DataSource = dt
            Me.cmbProveedor.ValueMember = "proveedor"
            Me.cmbProveedor.ValueMember = "proveedor"
            'ds_preparacion.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Llenar_Maestros()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")
        Try
            oTrans.open()
            'Parametros Generales
            ls_sql = "pa_sel_um_scm_parametros_generales"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "scm_parametros_generales"
            ds_preparacion.Tables.Add(dt.Copy)

            'Proveedores
            ls_sql = "pa_sel_um_prv_frecuencia_compra '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_frecuencia_compra"
            ds_preparacion.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_prv_dias_inventario_minimo '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_dias_inventario_minimo"
            ds_preparacion.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_pg_pareto "
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "pg_pareto"
            ds_preparacion.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "prv_proveedor"
            ds_preparacion.Tables.Add(dt.Copy)

            pi_meses_adicionales = IIf(ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

        oTrans = New Transaccional.Conexion("FlexLine")
        Try
            oTrans.open()
            ls_sql = "pa_sel_um_gen_tabcod NULL,'CONFIG.IMPUESTO','" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "impuestos"
            ds_preparacion.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub Crear_Estructuras()
        Dim dt As New DataTable("detalle_productos")

        dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("pareto", GetType(String)))
        dt.Columns.Add(New DataColumn("estatus", GetType(String)))
        dt.Columns.Add(New DataColumn("uxc", GetType(Short)))
        dt.Columns.Add(New DataColumn("traslado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("dias_inventario_cd", GetType(Integer)))
        dt.Columns.Add(New DataColumn("diario_cajas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("lead_time", GetType(Short)))
        dt.Columns.Add(New DataColumn("min_cajas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("max_cajas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cd_cajas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("da_cajas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("transito", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fob", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("dai", GetType(Short)))
        dt.Columns.Add(New DataColumn("daiV", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("iva", GetType(Decimal)))

        ds_preparacion.Tables.Add(dt.Copy)
        dt.TableName = "Resumen"
        ds_preparacion.Tables.Add(dt.Copy)

        dt = New DataTable("detalle_dua")

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("dua", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("cantidad_trasladar", GetType(Integer)))
        dt.Columns.Add(New DataColumn("asociar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("saldo_cajas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo_unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento_dua", GetType(Date)))
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento_producto", GetType(Date)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("fob", GetType(Double)))
        dt.Columns.Add(New DataColumn("dai", GetType(Double)))
        dt.Columns.Add(New DataColumn("iva", GetType(Double)))
        dt.Columns.Add(New DataColumn("fobunitario", GetType(Double)))
        dt.Columns.Add(New DataColumn("daiunitario", GetType(Double)))
        'dt.Columns.Add(New DataColumn("foblinea", GetType(Double)))
        ' dt.Columns.Add(New DataColumn("dailinea", GetType(Double)))
        'dt.Columns.Add(New DataColumn("ivalinea", GetType(Double)))

        ds_preparacion.Tables.Add(dt.Copy)

        dt = New DataTable("detalle_seleccion")
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("dua", GetType(String)))
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        ds_preparacion.Tables.Add(dt.Copy)


    End Sub

    Private Sub Preparar_Informacion()

        Dim ls_sql, saux, sfiltro As String
        Dim icount, iaux, dias_max, minimo_cajas, maximo_cajas As Integer
        Dim pronostico_diario As Decimal
        Dim otrans As New Transaccional.Conexion("scm")
        Dim li_dias_inventario As Short = ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("meses_proyeccion") * 30
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable

        Try
            otrans.open()
            For Me.cuenta = 1 To 10
                ProgressBar1.Value = cuenta
            Next

            Me.chk_obtener_productos.Checked = True
            ls_sql = "pa_var_um_producto_internaciones '" & gs_empresa & "','" & _
                      IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString & "'"

            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = ds_preparacion.Tables("detalle_productos").NewRow

                dr_aux.Item("proveedor") = dr.Item("subfamilia")
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("pareto") = dr.Item("pareto")
                dr_aux.Item("uxc") = dr.Item("UxC")
                dr_aux.Item("traslado") = 0
                dr_aux.Item("Agregar") = False
                Try
                    pronostico_diario = dr.Item("total_cajas") / li_dias_inventario
                Catch ex As Exception
                    pronostico_diario = 0
                End Try
                dr_aux.Item("diario_cajas") = pronostico_diario
                dr_aux.Item("lead_time") = dr.Item("lead_time")
                Try
                    minimo_cajas = (dr.Item("dias_minimo_cd") * pronostico_diario * (1 + (dr.Item("porcentaje_minimo") / 100)))
                Catch ex As Exception
                    minimo_cajas = 0
                End Try
                dr_aux.Item("min_cajas") = minimo_cajas

                Try
                    dias_max = dr.Item("dias_minimo_cd") + dr.Item("frecuencia_compra") + ((dr.Item("porcentaje_variable_lead_time") / 100) * dr.Item("lead_time"))
                Catch ex As Exception
                    dias_max = 0
                End Try

                Try
                    maximo_cajas = dias_max * pronostico_diario * (1 + (dr.Item("porcentaje_maximo") / 100))
                Catch ex As Exception
                    maximo_cajas = 0
                End Try

                dr_aux.Item("max_cajas") = maximo_cajas
                dr_aux.Item("cd_cajas") = 0
                dr_aux.Item("da_cajas") = 0
                dr_aux.Item("transito") = 0
                dr_aux.Item("dias_inventario_cd") = 0
                dr_aux.Item("fob") = 0
                dr_aux.Item("dai") = 0
                dr_aux.Item("daiV") = 0
                dr_aux.Item("iva") = 0

                'Obtengo el Porcentaje del Dai
                For icount = 2 To 20
                    saux = "factor" & icount
                    If dr.Item(saux) = 1 Then
                        sfiltro = "VALOR5 = " & icount
                        ds_preparacion.Tables("impuestos").DefaultView.RowFilter = sfiltro
                        If ds_preparacion.Tables("impuestos").DefaultView.Count > 0 Then
                            If ds_preparacion.Tables("impuestos").DefaultView(0).Item("texto").ToString.Substring(0, 3).ToLower = "dai" Then
                                dr_aux.Item("dai") = ds_preparacion.Tables("impuestos").DefaultView(0).Item("valor1")
                            End If
                        End If
                    End If
                Next

                ds_preparacion.Tables("detalle_productos").Rows.Add(dr_aux)


            Next

            'Existencia CD
            Me.chk_existencias_cd.Checked = True
            For Me.cuenta = 11 To 25
                ProgressBar1.Value = cuenta
            Next

            ls_sql = "pa_var_um_existencias_producto '" & gs_empresa & "',NULL,NULL" & _
                                          ",'CD_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    Try
                        iaux = dr.Item("Existencia") / drv.Item("uxc")
                    Catch ex As Exception
                        iaux = 0
                    End Try
                    drv.Item("cd_cajas") = iaux
                Next
            Next

            'Existencias DA
            Me.chk_existencias_da.Checked = True
            For Me.cuenta = 26 To 50
                ProgressBar1.Value = cuenta
            Next


            ls_sql = "pa_var_um_existencias_producto '" & gs_empresa & "',NULL,NULL" & _
                    ",'DA_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    Try
                        iaux = dr.Item("Existencia") / drv.Item("uxc")
                    Catch ex As Exception
                        iaux = 0
                    End Try
                    drv.Item("da_cajas") = iaux
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
        Me.chk_dias_inventarios.Checked = True
        For Me.cuenta = 51 To 70
            ProgressBar1.Value = cuenta
        Next

        Dias_Inventario()

        'Los Precios se debe obtener cuando se Asocie Con la DA
        'Generar_Precios()

        Me.chk_calcular_transitos.Checked = True
        For Me.cuenta = 71 To 80
            ProgressBar1.Value = cuenta
        Next
        Generar_Transitos()

        Me.chk_Calculando_traslado.Checked = True
        For Me.cuenta = 81 To 95
            ProgressBar1.Value = cuenta
        Next

        Calcular_Traslado()

        For Me.cuenta = 96 To 100
            ProgressBar1.Value = cuenta
        Next

    End Sub


    'Calcular Dias de Inventario
    Private Sub Dias_Inventario()
        Dim dr As DataRow
        For Each dr In ds_preparacion.Tables("detalle_productos").Rows
            Try
                dr.Item("dias_inventario_cd") = dr.Item("cd_cajas") / dr.Item("diario_cajas")
            Catch ex As Exception

            End Try
            If dr.Item("cd_cajas") > dr.Item("max_cajas") Then
                dr.Item("estatus") = "Over"
            ElseIf dr.Item("cd_cajas") > dr.Item("min_cajas") Then
                dr.Item("estatus") = "Within"
            ElseIf dr.Item("cd_cajas") > 0 Then
                dr.Item("estatus") = "Under"
            Else
                dr.Item("estatus") = "OOS"
            End If

        Next

    End Sub

    Private Sub Generar_Precios()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ls_sql As String

        Try
            otrans.open()

            ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "',NULL,'" & _
                    ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("lista_precio").ToString & "'"


            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                    drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                    'If dr.Item("meses_diferencia") <= 0 + pi_meses_adicionales Then
                    drv.Item("fob") = dr.Item("valor") * drv.Item("uxc")

                    'Else

                    '  ls_mes = "transito+" & (dr.Item("meses_diferencia") + pi_meses_adicionales).ToString.PadLeft(2, "0")
                    ' drv.Item(ls_mes) = drv.Item(ls_mes) + dr.Item("cajas_pedidas")
                End If
                'End If
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub Generar_Transitos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim lsTransito As String


        Try
            Otrans.open()
            'ls_sql = "pa_sel_um_int_pedido_detalle_pendientes"
            ls_sql = "pa_sel_um_int_pedido_detalle_pendientes_aprobados '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"

                If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                    drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)
                    lsTransito = "transito"
                    If dr.Item("dias_ingreso").ToString > 0 Then lsTransito &= "+" & dr.Item("dias_ingreso").ToString.PadLeft(2, "0")

                    drv.Item(lsTransito) += dr.Item("cantidad")
                End If

            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub Calcular_Traslado()
        Dim dr As DataRow
        Dim itraslado As Integer
        Dim liva As Decimal
        Dim ldaiq As Decimal
        For Each dr In ds_preparacion.Tables("detalle_productos").Rows
            Try
                If dr.Item("da_cajas") > 0 Then
                    itraslado = dr.Item("max_cajas") - (dr.Item("cd_cajas") - (dr.Item("lead_time") * dr.Item("diario_cajas")) + dr.Item("transito"))
                Else
                    itraslado = 0
                End If
            Catch ex As Exception
                itraslado = 0
            End Try

            itraslado = IIf(itraslado < 0, 0, itraslado) ' si es negativo es por que hay suficiente en el cd
            itraslado = Math.Round((itraslado / 5), 0) * 5  'Redondeamos la cantidad para trasladar
            itraslado = IIf(dr.Item("da_cajas") < itraslado, dr.Item("da_cajas"), itraslado) ' valido que haya en el cd
            dr.Item("traslado") = itraslado
            If itraslado = 0 Then
                ldaiq = 0
                liva = 0
            Else
                ldaiq = (dr.Item("fob") * (dr.Item("dai") / 100)) * itraslado
                liva = (((dr.Item("fob") * itraslado)) + (dr.Item("fob") * (dr.Item("dai") / 100))) * 0.12
            End If

            dr.Item("daiV") = ldaiq
            dr.Item("iva") = liva
        Next
    End Sub

    ''Nueva Informacion 
    Private Sub prepararInformacion()
        Dim oCompras As New Compras.Internaciones(ds_preparacion)
        Try
            chk_obtener_productos.Checked = True
            oCompras.Empresa = gs_empresa
            If Me.chkProveedor.CheckState = CheckState.Checked Then
                oCompras.proveedor = Me.cmbProveedor.SelectedValue
            End If
            'oCompras.productoLimite = "0900000000"

            oCompras.crearEstructura()
            agregarParametros()
            oCompras.inicializarProductos(False, False, False, False)
            oCompras.revisarProductosDerivados()

            'llenarExistencias()
            llenarPresupuesto()
            'quitarDerivados() (c) 20241218 Prueba
            Generar_Transitos()
            'obtenerExistenciasDA()
            oCompras.llenarExistenciasDA()
            oCompras.llenarExistenciasCD()
            oCompras.obtenerExistenciasDA("1")
            LlenarFOB()
            Try
                oCompras.generarSaldosyCoberturas(45)
            Catch ex As Exception
            End Try

            calcularDiasRealesTransito()
            oCompras.generarMinimosyMaximos(0, True)
            oCompras.generarPedidoSugerido(0, True)
            'For iCount As Int16 = 0 To 3
            '    oCompras.generarMinimosyMaximos(iCount, True)
            '    oCompras.generarPedidoSugerido(iCount, True)

            'Next

            verificarProductosBloqueados()
            verificarProductosRegistroSanitario()
            verificarProductosProximosaVencer()
        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try

    End Sub

    Private Sub verificarProductosProximosaVencer()
        Dim iDiasVencimientoProducto As Integer = ds_preparacion.Tables("parametros").Rows(0).Item("dias_vencimiento_producto") + 1
        Dim iDiasVencimientoDua As Integer = ds_preparacion.Tables("parametros").Rows(0).Item("dias_vencimiento_dua") + 1
        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""


        For Each dr As DataRow In ds_preparacion.Tables("detalle_productos").Rows
            ds_preparacion.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
            For Each drv As DataRowView In ds_preparacion.Tables("detalle_dua").DefaultView
                Try
                    If DateDiff(DateInterval.Day, Today, drv.Item("fecha_vencimiento_producto")) < iDiasVencimientoProducto Then
                        dr.Item("bloqueado_internacion") = 3
                        If dr.Item("sugerido") < 1 Then
                            dr.Item("sugerido") = drv.Item("saldo_cajas")
                            dr.Item("sugerido") = drv.Item("saldo_cajas")
                        End If

                        Exit For
                    End If
                    If DateDiff(DateInterval.Day, Today, drv.Item("fecha_vencimiento_dua")) < iDiasVencimientoDua Then
                        dr.Item("bloqueado_internacion") = 5
                        If dr.Item("sugerido") < 1 Then
                            dr.Item("sugerido") = drv.Item("saldo_cajas")
                            dr.Item("sugerido") = drv.Item("saldo_cajas")
                        End If

                        Exit For
                    End If


                Catch ex As Exception

                End Try


            Next

        Next

    End Sub

    Private Sub verificarProductosRegistroSanitario()

        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
 

        For Each dr As DataRow In ds_preparacion.Tables("detalle_productos").Rows
            If dr.Item("numero_registro_sanitario").ToString.Trim.Length > 0 Then



                Try
                    If DateDiff(DateInterval.Day, Today, dr.Item("fecha_vencimiento_registro")) < 2 Then dr.Item("bloqueado_internacion") = 2
                Catch ex As Exception
                    dr.Item("bloqueado_internacion") = 2
                End Try
            End If


        Next
    End Sub

    Private Sub verificarProductosBloqueados()
        Dim otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_int_producto_bloqueado '" & gs_empresa & "'")
            For Each dr As DataRow In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                    ds_preparacion.Tables("detalle_productos").DefaultView(0)("bloqueado_internacion") = 1
                End If
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub calcularDiasRealesTransito()
        Dim dt As DataTable
        Try
            Dim umOtrans As New Transaccional.Conexion("Umbral")
            umOtrans.open()
            dt = umOtrans.Obtiene("pa_var_um_calendario_habil '" & gs_empresa & "','" & Today.ToString("dd/MM/yyyy") & "'")
            umOtrans.close()
            umOtrans = Nothing

            dt.DefaultView.RowFilter = "fecha >= '" & Today & "'"
            dt.DefaultView.Sort = "fecha"
            pdfechaIngreso = dt.DefaultView(ds_preparacion.Tables("parametros").Rows(0).Item("lead_time") - 1).Item("fecha")
            If DateDiff(DateInterval.Day, Today, pdfechaIngreso) <> ds_preparacion.Tables("parametros").Rows(0).Item("lead_time") Then
                Dim ileadtime As Integer = DateDiff(DateInterval.Day, Today, pdfechaIngreso)
                For Each dr As DataRow In ds_preparacion.Tables("detalle_productos").Rows
                    dr.Item("pv_lead_time_total") = ileadtime
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub obtenerExistenciasDA()
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            otrans.open()
    
            lsSQL = "pa_sel_um_vs_detalle_dua '" & gs_empresa & "',null,1" ' ",'" & drv.Item("producto") & "',1"

            dt = otrans.Obtiene(lsSQL)

            For Each dr_aux In dt.Rows

                dr = ds_preparacion.Tables("detalle_dua").NewRow

                dr.Item("producto") = dr_aux.Item("producto")
                dr.Item("glosa") = dr_aux.Item("glosa")
                dr.Item("dua") = dr_aux.Item("no_dua")
                dr.Item("asociar") = False
                dr.Item("saldo_cajas") = dr_aux.Item("saldo_bultos") '/ drv.Item("uxc")
                dr.Item("saldo_unidades") = dr_aux.Item("saldo_unidades")
                dr.Item("observaciones") = dr_aux.Item("observaciones")
                dr.Item("fecha_vencimiento_dua") = dr_aux.Item("fecha_vence_dua")
                dr.Item("fecha_vencimiento_producto") = dr_aux.Item("fecha_vence_prod")
                dr.Item("fob") = 0
                dr.Item("dai") = 0
                dr.Item("iva") = 0

                ds_preparacion.Tables("detalle_dua").Rows.Add(dr)

            Next

            'ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"
            'ds_asociacion.Tables("detalle_dua").DefaultView.Sort = "fecha_vencimiento_producto, fecha_vencimiento_dua"

            'Dim itraslado As Integer = drv.Item("pedido")
            'drv.Item("dua") = String.Empty
            'For Each drv2 As DataRowView In ds_asociacion.Tables("detalle_dua").DefaultView
            '    If drv2.Item("saldo_cajas") >= itraslado Then
            '        drv2.Item("cantidad_trasladar") = itraslado
            '    Else
            '        drv2.Item("cantidad_trasladar") = drv2.Item("saldo_cajas")
            '    End If
            '    drv.Item("dua") = drv.Item("dua").ToString.Trim & IIf(drv.Item("dua").ToString.Length > 0, ",", "") & drv2.Item("dua").ToString.Trim
            '    itraslado -= drv2.Item("saldo_cajas")
            '    drv2.Item("asociar") = True
            '    If itraslado <= 0 Then
            '        Exit For
            '    End If
            'Next

            ' Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        'hacerResumen()
        'obtenerdai()
        LlenarFOB()

        'Me.dg_producto_dua.DataSource = ds_asociacion.Tables("detalle_dua")


        'Colorear_Detalle()
        'Mostrar_Productos()
    End Sub

    Private Sub LlenarFOB()
        Dim otransFlex As New Transaccional.Conexion("FlexLine")
        Dim lfob, ldaiq, liva As Double
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            otransFlex.open()

            ds_preparacion.Tables("detalle_dua").DefaultView.RowFilter = ""

            For Each drv2 As DataRowView In ds_preparacion.Tables("detalle_dua").DefaultView

                'Obtener Productos de la Dua
                lsSQL = "pa_sel_um_documentod '" & gs_empresa & "','INGRESO DE MERCADERIA DEPOSITO ADUANERO','" & _
                            drv2.Item("dua").ToString.Replace("-", "").Trim.Replace("FPA", "").Trim.Replace(" ", "").Trim.PadLeft(10, "0") & "'"
                dt = otransFlex.Obtiene(lsSQL)

                If dt.Rows.Count = 0 Then
                    'Obtener Productos de la Dua
                    lsSQL = "pa_sel_um_documentod '" & gs_empresa & "','INGRESO DA CONSOLIDADO','" & _
                                drv2.Item("dua").ToString.Replace("-", "").Trim.Replace("FPA", "").Trim.Replace(" ", "").Trim.PadLeft(10, "0") & "'"
                    dt = otransFlex.Obtiene(lsSQL)
                End If

                dt.DefaultView.RowFilter = "PRODUCTO  = '" & drv2.Item("producto") & "'"

                If drv2.Item("producto") = "0100010230" Then
                    drv2.Item("producto") = "0100010230"
                End If
                If dt.DefaultView.Count = 1 Then
                    With dt.DefaultView(0)

                        Try

                            'Fob Total
                            lfob = (.Item("SubTotal") / .Item("Cantidad")) * .Item("factoralt")
                            drv2.Item("fobunitario") = lfob '* drv2.Item("cantidad_trasladar")
                            ldaiq = 0

                            ldaiq = (lfob * (.Item("dai") / 100)) '* drv2.Item("cantidad_trasladar")
                            drv2.Item("daiunitario") = ldaiq
                            drv2.Item("fob") = 0
                            drv2.Item("dai") = 0
                            drv2.Item("iva") = 0

                        Catch ex As Exception

                        End Try


                    End With
                End If

            Next



        Catch ex As Exception
        Finally
            otransFlex.close()
            otransFlex = Nothing
        End Try





    End Sub

    Private Sub agregarParametros()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_int_pareto '" & gs_empresa & "'")
            dt.TableName = "pareto"

            If ds_preparacion.Tables.Contains("pareto") Then ds_preparacion.Tables.Remove("pareto")
            ds_preparacion.Tables.Add(dt.Copy)

            dt = Otrans.Obtiene("pa_sel_um_int_parametros_generales '" & gs_empresa & "'")
            dt.TableName = "parametros"

            If ds_preparacion.Tables.Contains("parametros") Then ds_preparacion.Tables.Remove("parametros")
            ds_preparacion.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub llenarExistencias()
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim iaux As Double
        Dim dr As DataRow
        Dim drv As DataRowView

        Try
            Otrans.open()
            'Existencia CD
            Me.chk_existencias_cd.Checked = True
            For Me.cuenta = 11 To 25
                ProgressBar1.Value = cuenta
            Next

            lsSQL = "pa_var_um_existencias_producto '" + gs_empresa + "',NULL,NULL" + _
                                          ",'CD_CENTRAL','" + IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString + "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    Try
                        iaux = dr.Item("Existencia") / drv.Item("uxc")
                    Catch ex As Exception
                        iaux = 0
                    End Try
                    drv.Item("cd_cajas") = iaux
                Next

                ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and " & _
                              "producto = '" & dr.Item("producto").ToString & "'"
                If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
                    For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView
                        Try
                            drvaux.Item("existencia") = dr.Item("Existencia") '(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                        Catch ex As Exception

                        End Try

                        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & drvaux.Item("producto_padre").ToString & "' and empresa = '" & drvaux.Item("empresa").ToString & "'"

                        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                            Try
                                iaux = (dr.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
                            Catch ex As Exception
                                iaux = 0
                            End Try
                            drv.Item("cd_cajas") += iaux
                            '  drv.Item("existencia") += iaux
                        Next

                    Next


                End If
            Next

            ''Existencia CD XELA
            ''No se tomaran en cuenta para Internacion HG lo indico 240212
            'Me.chk_existencias_cdx.Checked = True

            'lsSQL = "pa_var_um_existencias_producto '" & gs_empresa & "',NULL,NULL" & _
            '                                          ",'CDX_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString & "'"
            ''IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL") & _
            'dt = Otrans.Obtiene(lsSQL)

            'For Each dr In dt.Rows
            '    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                    = "producto = '" & dr.Item("producto").ToString & "' and proveedor = '" & dr.Item("proveedor").ToString & "'"
            '    For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '        Try
            '            iaux = dr.Item("Existencia") / drv.Item("uxc")
            '        Catch ex As Exception
            '            iaux = 0
            '        End Try
            '        drv.Item("cdx_cajas") = iaux
            '        '         drv.Item("existencia") += drv.Item("cdx_cajas")
            '    Next


            '    ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and " & _
            '                "producto = '" & dr.Item("producto").ToString & "'"
            '    If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
            '        For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView


            '            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & drvaux.Item("producto_padre").ToString & "' and empresa = '" & drvaux.Item("empresa").ToString & "'"

            '            For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '                Try
            '                    iaux = (dr.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
            '                Catch ex As Exception
            '                    iaux = 0
            '                End Try
            '                drv.Item("cdx_cajas") += iaux
            '                '   drv.Item("existencia") += iaux
            '            Next

            '        Next


            '    End If

            'Next

            'Existencias DA
            Me.chk_existencias_da.Checked = True
            For Me.cuenta = 26 To 50
                ProgressBar1.Value = cuenta
            Next


            lsSQL = "pa_var_um_existencias_producto '" & gs_empresa & "',NULL,NULL" & _
                    ",'DA_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000").ToString & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    Try
                        iaux = dr.Item("Existencia") / drv.Item("uxc")
                    Catch ex As Exception
                        iaux = 0
                    End Try
                    drv.Item("da_cajas") = iaux
                Next
            Next

            'producto en internacion
            

            lsSQL = "pa_var_um_producto_transito_internacion '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                   = "producto = '" & dr.Item("producto").ToString & "' and empresa = '" & dr.Item("empresa").ToString & "'"
                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
                    Try
                        iaux = dr.Item("cantidad") / drv.Item("uxc")
                    Catch ex As Exception
                        iaux = 0
                    End Try
                    drv.Item("internacion") = iaux
                    ' drv.Item("existencia") += drv.Item("internacion")
                    '    Next

                Next
            Next


            'Resta Las Reservas
            lsSQL = "pa_var_um_da_saldo_reservas '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr In dt.Rows
                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                     = "producto = '" & dr.Item("producto").ToString & "' and empresa = '" & dr.Item("empresa").ToString & "'"

                Try
                    iaux = dr.Item("unidades") / drv.Item("uxc")
                Catch ex As Exception
                    iaux = 0
                End Try

                Try
                    drv.Item("da_cajas") = drv.Item("da_cajas") - iaux
                    If drv.Item("da_cajas") < 0 Then drv.Item("da_cajas") = 0
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub llenarPresupuesto()

        Dim ls_sql, ls_mes As String
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")
        Dim clsGen As New ClasesGenerales.General
        Dim nsemana As Integer
        Dim ndia, ndiasaño As Integer

        ndiasaño = DatePart(DateInterval.DayOfYear, Date.Parse("31/12/" & Year(Today).ToString))

        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa".Split(","))

            For Each dr_aux In dtunicos.Rows


                ''Presupuesto Diario
                ls_sql = "pa_sel_um_producto_presupuesto_dia 0, '" & dr_aux.Item("empresa") & "'"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                 = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"


                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                        ndia = dr.Item("dia") - pdiaActual

                        If ndia < 0 Then ndia += ndiasaño

                        If ndia < 46 Then
                            ls_mes = "ppto"
                            If ndia > 0 Then ls_mes += "+" + ndia.ToString.PadLeft(2, "00")
                            drv(ls_mes) += dr.Item("ppto_diario")
                        End If
                        drv("ppto_total") += dr.Item("ppto_diario")

                    End If

                    ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and " & _
                             "producto = '" & dr.Item("producto").ToString & "'"
                    'Derivador 110613
                    If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
                        For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView
                            'Try
                            '    drvaux.Item("existencia") = dr.Item("Existencia") '(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                            'Catch ex As Exception

                            'End Try

                            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                        = "producto = '" & drvaux.Item("producto_padre").ToString & "' and empresa = '" & drvaux.Item("empresa").ToString & "'"

                            If ds_preparacion.Tables("detalle_productos").DefaultView.Count Then


                                drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)
                                ndia = dr.Item("dia") - pdiaActual

                                If ndia < 0 Then ndia += ndiasaño

                                If ndia < 46 Then
                                    ls_mes = "ppto"
                                    If ndia > 0 Then ls_mes += "+" + ndia.ToString.PadLeft(2, "00")
                                    drv(ls_mes) += dr.Item("ppto_diario")
                                End If
                                drv("ppto_total") += dr.Item("ppto_diario")
                            End If
                        Next


                    End If
                Next


                Next





        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""

        End Try


    End Sub

    Private Sub quitarDerivados()

        Dim dt As DataTable
        dt = ds_preparacion.Tables("detalle_productos").Copy
        Dim draux As DataRow

        dt.Rows.Clear()
        Try
            For Each dr As DataRow In ds_preparacion.Tables("detalle_productos").Rows
                ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
                              "producto = '" & dr.Item("producto") & "'"
                If ds_preparacion.Tables("derivados").DefaultView.Count = 0 Then
                    draux = dt.NewRow
                    For Each dc As DataColumn In dt.Columns
                        draux.Item(dc.ColumnName) = dr.Item(dc.ColumnName)
                    Next
                    dt.Rows.Add(draux)
                End If
            Next

            ds_preparacion.Tables.Remove("detalle_productos")
            dt.TableName = "detalle_productos"
            ds_preparacion.Tables.Add(dt.Copy)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Me.chk_preparando_informacion.Checked = True
        prepararInformacion()
        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
        Me.Close()
    End Sub

    Private Sub frm_int_prepara_informacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructuras()
        llenarCombo()
    End Sub
End Class
