Public Class frm_pedido_walmart
    Inherits System.Windows.Forms.Form
    Dim oDataSet As New DataSet
    Dim ods_listado As DataSet
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents glosa As System.Windows.Forms.Label
    Friend WithEvents rebaja_cant As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidadPacksDespachados As System.Windows.Forms.TextBox
    Friend WithEvents cmb_liberar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents Cantidad_Pedida As System.Windows.Forms.Label
    Friend WithEvents lbl_packs_pedidos As System.Windows.Forms.Label
    Friend WithEvents lbl_cant_x_pack As System.Windows.Forms.Label
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_motivo As System.Windows.Forms.TextBox
    Dim ods As DataSet



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.glosa = New System.Windows.Forms.Label()
        Me.rebaja_cant = New System.Windows.Forms.TextBox()
        Me.txt_cantidadPacksDespachados = New System.Windows.Forms.TextBox()
        Me.cmb_liberar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.Cantidad_Pedida = New System.Windows.Forms.Label()
        Me.lbl_packs_pedidos = New System.Windows.Forms.Label()
        Me.lbl_cant_x_pack = New System.Windows.Forms.Label()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.txt_motivo = New System.Windows.Forms.TextBox()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AccessibleName = ""
        Me.dgv_pedidos.AllowUserToAddRows = False
        Me.dgv_pedidos.AllowUserToDeleteRows = False
        Me.dgv_pedidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(12, 64)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.ReadOnly = True
        Me.dgv_pedidos.RowHeadersWidth = 25
        Me.dgv_pedidos.Size = New System.Drawing.Size(1040, 131)
        Me.dgv_pedidos.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(163, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Al"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(27, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 16)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Del"
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(187, 8)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_final.TabIndex = 57
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(59, 8)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Pedidos de Walmart Pendientes de Facturas"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(340, 8)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(116, 43)
        Me.btnGenerar.TabIndex = 60
        Me.btnGenerar.Text = "Generar Informacion"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(753, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Motivo:"
        Me.Label3.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(757, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Cantidad Disponible:"
        Me.Label5.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(753, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Cantidad Pedida:"
        '
        'glosa
        '
        Me.glosa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.glosa.AutoSize = True
        Me.glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.glosa.ForeColor = System.Drawing.Color.Black
        Me.glosa.Location = New System.Drawing.Point(753, 18)
        Me.glosa.Name = "glosa"
        Me.glosa.Size = New System.Drawing.Size(11, 13)
        Me.glosa.TabIndex = 51
        Me.glosa.Text = "."
        '
        'rebaja_cant
        '
        Me.rebaja_cant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rebaja_cant.Enabled = False
        Me.rebaja_cant.Location = New System.Drawing.Point(757, 212)
        Me.rebaja_cant.Name = "rebaja_cant"
        Me.rebaja_cant.Size = New System.Drawing.Size(77, 20)
        Me.rebaja_cant.TabIndex = 44
        Me.rebaja_cant.Visible = False
        '
        'txt_cantidadPacksDespachados
        '
        Me.txt_cantidadPacksDespachados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cantidadPacksDespachados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidadPacksDespachados.Enabled = False
        Me.txt_cantidadPacksDespachados.Location = New System.Drawing.Point(753, 95)
        Me.txt_cantidadPacksDespachados.Name = "txt_cantidadPacksDespachados"
        Me.txt_cantidadPacksDespachados.Size = New System.Drawing.Size(77, 20)
        Me.txt_cantidadPacksDespachados.TabIndex = 53
        '
        'cmb_liberar
        '
        Me.cmb_liberar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_liberar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.cmb_liberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_liberar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmb_liberar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmb_liberar.Location = New System.Drawing.Point(919, 209)
        Me.cmb_liberar.Name = "cmb_liberar"
        Me.cmb_liberar.Size = New System.Drawing.Size(133, 24)
        Me.cmb_liberar.TabIndex = 55
        Me.cmb_liberar.Text = "Actualizar Linea"
        Me.cmb_liberar.UseVisualStyleBackColor = False
        Me.cmb_liberar.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(753, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "packs:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(753, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Packs Despachados:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(919, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Cantidad x pack:"
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(9, 18)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(738, 217)
        Me.dgv_detalle.TabIndex = 46
        '
        'Cantidad_Pedida
        '
        Me.Cantidad_Pedida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cantidad_Pedida.AutoSize = True
        Me.Cantidad_Pedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad_Pedida.Location = New System.Drawing.Point(847, 40)
        Me.Cantidad_Pedida.Name = "Cantidad_Pedida"
        Me.Cantidad_Pedida.Size = New System.Drawing.Size(14, 20)
        Me.Cantidad_Pedida.TabIndex = 60
        Me.Cantidad_Pedida.Text = "."
        '
        'lbl_packs_pedidos
        '
        Me.lbl_packs_pedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_packs_pedidos.AutoSize = True
        Me.lbl_packs_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_packs_pedidos.Location = New System.Drawing.Point(812, 55)
        Me.lbl_packs_pedidos.Name = "lbl_packs_pedidos"
        Me.lbl_packs_pedidos.Size = New System.Drawing.Size(14, 20)
        Me.lbl_packs_pedidos.TabIndex = 61
        Me.lbl_packs_pedidos.Text = "."
        '
        'lbl_cant_x_pack
        '
        Me.lbl_cant_x_pack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_cant_x_pack.AutoSize = True
        Me.lbl_cant_x_pack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cant_x_pack.Location = New System.Drawing.Point(1011, 40)
        Me.lbl_cant_x_pack.Name = "lbl_cant_x_pack"
        Me.lbl_cant_x_pack.Size = New System.Drawing.Size(14, 20)
        Me.lbl_cant_x_pack.TabIndex = 61
        Me.lbl_cant_x_pack.Text = "."
        '
        'gb1
        '
        Me.gb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb1.Controls.Add(Me.lbl_cant_x_pack)
        Me.gb1.Controls.Add(Me.lbl_packs_pedidos)
        Me.gb1.Controls.Add(Me.Cantidad_Pedida)
        Me.gb1.Controls.Add(Me.dgv_detalle)
        Me.gb1.Controls.Add(Me.Label7)
        Me.gb1.Controls.Add(Me.Label9)
        Me.gb1.Controls.Add(Me.txt_motivo)
        Me.gb1.Controls.Add(Me.Label8)
        Me.gb1.Controls.Add(Me.cmb_liberar)
        Me.gb1.Controls.Add(Me.txt_cantidadPacksDespachados)
        Me.gb1.Controls.Add(Me.rebaja_cant)
        Me.gb1.Controls.Add(Me.glosa)
        Me.gb1.Controls.Add(Me.Label2)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.Label3)
        Me.gb1.Location = New System.Drawing.Point(3, 200)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(1060, 239)
        Me.gb1.TabIndex = 31
        Me.gb1.TabStop = False
        Me.gb1.Text = "Detalle de Pedido Walmart"
        '
        'txt_motivo
        '
        Me.txt_motivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_motivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_motivo.Location = New System.Drawing.Point(757, 136)
        Me.txt_motivo.Multiline = True
        Me.txt_motivo.Name = "txt_motivo"
        Me.txt_motivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_motivo.Size = New System.Drawing.Size(292, 61)
        Me.txt_motivo.TabIndex = 54
        Me.txt_motivo.Visible = False
        '
        'frm_pedido_walmart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1068, 444)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtp_fecha_final)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_pedidos)
        Me.Controls.Add(Me.gb1)
        Me.Name = "frm_pedido_walmart"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualizacion de Pedidos Walmart"
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim pdataset As New DataSet

    Private Sub frm_pedido_wallmart_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub
    Private Sub frm_pedido_wallmart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.rebaja_cant.Enabled = False
        Me.txt_cantidadPacksDespachados.Enabled = False
        Me.txt_motivo.Enabled = False
        Me.cmb_liberar.Enabled = False
        Me.dtp_fecha_inicio.Text = "01/" & Month(Now()).ToString & "/" & Year(Now())
        ods = New DataSet
        Pedidos_walmart()
    End Sub


    Private Sub crear_estructura()
        Dim dt2 As DataTable


        ods_listado = New DataSet
        dt2 = New DataTable("listado")
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Existencia", GetType(String)))
        dt2.Columns.Add(New DataColumn("ExistenciaCD", GetType(String)))
        dt2.Columns.Add(New DataColumn("Sugerido", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Sugerido_original", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Comprar", GetType(Boolean)))
        dt2.Columns.Add(New DataColumn("valor", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("grupo", GetType(Integer)))
        ods_listado.Tables.Add(dt2)
    End Sub

    Private Sub Pedidos_walmart()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String
        Dim ls_sqltxt As String

        oDataSet = New DataSet
        oTrans = New Transaccional.Conexion("flexline")

        Try
            oTrans.open()
            ls_sqltxt = "pa_sel_um_selecciona_pedido_walmart '" & gs_empresa & "','" & "PEDIDO WALMART" & "','" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "encabezado"
            oDataSet.Tables.Add(oTabla.Copy)
            oDataSet.Tables("encabezado").DefaultView.RowFilter = ls_filtro

            Me.dgv_pedidos.DataSource = oDataSet.Tables("encabezado").DefaultView
            clGen.Alinear_GridView(oDataSet.Tables("encabezado"), dgv_pedidos, "", ",correlativo,ctacte,direccion,", " ", "", "", "", "", True, True, 3000, 0)

            If oDataSet.Tables("encabezado").Rows.Count > 0 Then
                ls_sqltxt = "pa_var_um_detalle_pedidos_walmart '" & gs_empresa & "','" & "PEDIDO WALMART" & "','" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"
                oTabla = oTrans.Obtiene(ls_sqltxt)
                oTabla.TableName = "det_pedidos2"
                oDataSet.Tables.Add(oTabla.Copy)
                detalle_pedido(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
        End Try

        Try
            If oDataSet.Tables("encabezado").Rows.Count > 0 Then
                detalle_pedido(0)
                gb1.Visible = True
            Else
                gb1.Visible = False
                Me.dgv_detalle.DataSource = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)
        Dim oTrans As Transaccional.Conexion
        Dim oTabla As DataTable
        Dim ls_sqltxt As String
        Dim clgen As New ClasesGenerales.General


        Me.dgv_detalle.DataSource = oDataSet.Tables("det_pedidos2").DefaultView
        oDataSet.Tables("det_pedidos2").DefaultView.RowFilter = "correlativo = '" & dgv_pedidos.Item("correlativo", pi_RowNumber).Value & _
                                                             "' and TipoDocto  = '" & _
                                                            dgv_pedidos.Item("TipoDocto", pi_RowNumber).Value & _
                                                            "' and empresa = '" & dgv_pedidos.Item("empresa", pi_RowNumber).Value & "'"

        clgen.Alinear_GridView(oDataSet.Tables("det_pedidos2"), Me.dgv_detalle, "", ",secuencia,correlativo,porcentajedr,tipodocto,empresa,", "", ",cantidad,precio,subtotal,", ",analisisproducto20=InnerPack,", "", "", True, True, 300, 0)
        'Me.dgv_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.dgv_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.dgv_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.dgv_detalle.Columns.Item("precio").DefaultCellStyle.Format = "###,##0.00"
        'Me.dgv_detalle.Columns.Item("subtotal").DefaultCellStyle.Format = "###,##0.00"
        'Me.dgv_detalle.Columns.Item("GLOSA").Width = 300

        clgen = Nothing

    End Sub
    Private Sub Crear_Bindings()
        Me.rebaja_cant.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "total")

    End Sub

    Private Sub Limpiar_Bindings()
        Try
            Me.rebaja_cant.Text = ""
            Me.txt_motivo.Text = ""
            Me.txt_motivo.Text = ""
            Me.txt_cantidadPacksDespachados.Text = ""
            Me.rebaja_cant.Text = ""

        Catch ex As Exception

        End Try
    End Sub



    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim li_row_number As Integer
    End Sub
    Private Sub DataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick
    End Sub

    Private Sub llenar_etiquetas()
    End Sub
    Private Sub cmb_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Modificar_pedido_walmart()
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim ls_sql As String
        Try
            oTrans.open()

            Dim li_row_number, liRowNumberEncabado As Integer
            li_row_number = Me.dgv_detalle.CurrentRow.Index
            liRowNumberEncabado = Me.dgv_pedidos.CurrentRow.Index
            ls_sql = "pa_upd_um_rebaja_pedido_walmart '" & Me.dgv_detalle.Item("empresa", li_row_number).Value & "','" & _
                                                           Me.dgv_detalle.Item("tipodocto", li_row_number).Value & "'," & _
                                                           Me.dgv_detalle.Item("correlativo", li_row_number).Value & ",'" & _
                                                           Me.dgv_detalle.Item("producto", li_row_number).Value & "'," & _
                                                           Me.dgv_detalle.Item("secuencia", li_row_number).Value & ",'" & _
                                                           Me.txt_motivo.Text & "','" & _
                                                           gs_usuario & "'," & _
                                                           System.Convert.ToInt32(Me.Cantidad_Pedida.Text) & "," & _
                                                           System.Convert.ToInt32(Me.rebaja_cant.Text) & ""


            oTrans.Escribir_Log(ls_sql)
            oTrans.Actualiza(ls_sql)

            If oTrans.Codigo_error = 0 Then
                MessageBox.Show("Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                generarAviso(Me.dgv_detalle.Item("empresa", li_row_number).Value, Me.dgv_detalle.Item("tipodocto", li_row_number).Value, _
                              Me.dgv_pedidos.Item("numero", li_row_number).Value, Me.dgv_detalle.Item("glosa", li_row_number).Value)

            Else
                MessageBox.Show(oTrans.descripcion_error)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try


    End Sub

    Private Sub generarAviso(psEmpresa As String, psTipoDocto As String, psNumero As String, psGlosa As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable
        Dim idaviso As Integer = 0
        Dim lsMensaje As String = "Modifacion Pedido " & psEmpresa & "  " & psTipoDocto & "-" & psNumero


        Try


            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (37)" '37= Modificacion Pedido Walmart
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsMensaje & " " & psGlosa & "  Motivo " & Me.txt_motivo.Text, 37)
            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs)

    End Sub

    Private Sub DataGrid2_Navigate(sender As Object, ne As NavigateEventArgs)

    End Sub

    Private Sub rebaja_cant_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txt_motivo.Focus()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbEmpresa_SelectedValueChanged(sender As Object, e As EventArgs)
        Pedidos_walmart()
    End Sub

    Private Sub enc_pedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_pedidos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_pedidos.Rows(rowIndex)

                ' If dgv_pedidos.Columns(colIndex).Name.ToLower.IndexOf("status_pedido") > -1 Then
                If Me.dgv_pedidos.Item("status_pedido", rowIndex).Value.ToString = "N" Then
                    Me.dgv_pedidos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
                'End If


            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub enc_pedidos_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_pedidos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_pedidos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_pedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidos.CellContentClick

    End Sub

    Private Sub dgv_pedidos_Click(sender As Object, e As EventArgs) Handles dgv_pedidos.Click

    End Sub

    Private Sub dgv_pedidos_MouseClick1(sender As Object, e As MouseEventArgs) Handles dgv_pedidos.MouseClick
        Try
            If oDataSet.Tables("encabezado").Rows.Count > 0 Then
                detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)
                Me.glosa.Text = ""
                Me.Cantidad_Pedida.Text = ""
                Me.lbl_cant_x_pack.Text = ""
                Me.lbl_packs_pedidos.Text = ""
                Me.rebaja_cant.Text = ""
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

        ' cambia la propiedad visible a FALSE del Text Motivo
        Label3.Visible = False
        Me.txt_motivo.Visible = False
        cmb_liberar.Visible = False

        ' bloquea los text box que reciben las cantidades
        Me.rebaja_cant.Enabled = False
        Me.txt_cantidadPacksDespachados.Enabled = False

    End Sub

    Dim cant As String

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_liberar_Click_1(sender As Object, e As EventArgs)

        Dim li_row_number As Integer
        li_row_number = Me.dgv_detalle.CurrentRow.Index
        If oDataSet.Tables("pedidos").Rows.Count > 0 Then
            If rebaja_cant.Text <> "" Then
                If (IsNumeric(rebaja_cant.Text)) Then
                    If CDbl(rebaja_cant.Text) > 0 Then
                        If MessageBox.Show("Esta Seguro de Rebajar la Cantidad de " & rebaja_cant.Text & " del producto " & Me.dgv_detalle.Item("GLOSA", li_row_number).Value & " De la linea " & Me.dgv_detalle.Item("Secuencia", li_row_number).Value & " ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Modificar_pedido_walmart()
                            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

                            Limpiar_Bindings()
                        End If
                    End If
                Else
                    MessageBox.Show("ERROR: La cantidad a Rebajar debe ser un dato numérico mayor que cero.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Limpiar_Bindings()
                End If
            Else
                MessageBox.Show("ERROR: La cantidad no puede estar en blanco.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Limpiar_Bindings()
            End If
        Else
            MessageBox.Show("ERROR: No existen registros que modificar.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Limpiar_Bindings()
        End If
    End Sub

    Private Sub rebaja_cant_KeyPress1(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txt_motivo.Focus()
        End If
    End Sub

    Private Sub rebaja_cant_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub gb1_Enter(sender As Object, e As EventArgs) Handles gb1.Enter

    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_liberar_Click_2(sender As Object, e As EventArgs) Handles cmb_liberar.Click

        Dim li_row_number, li_row_encabezado As Integer
        li_row_number = Me.dgv_detalle.CurrentRow.Index
        li_row_encabezado = Me.dgv_pedidos.CurrentRow.Index

        If oDataSet.Tables("encabezado").Rows.Count > 0 Then
            If (IsNumeric(rebaja_cant.Text)) Then
                If Me.txt_motivo.Text <> "" Then
                    ' If Val(rebaja_cant.Text) > 0 Then
                    If MessageBox.Show("Esta Seguro de actualizar la Cantidad de " & rebaja_cant.Text & " del producto " & Me.dgv_detalle.Item("GLOSA", li_row_number).Value & " De la linea " & Me.dgv_detalle.Item("Secuencia", li_row_number).Value & " ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Modificar_pedido_walmart()
                        Pedidos_walmart()

                        Try
                            'recupero la fila seleccionada del encabezado
                            Me.dgv_pedidos.Rows(li_row_encabezado).Selected = True
                            Me.dgv_pedidos.CurrentCell = Me.dgv_pedidos.Rows(li_row_encabezado).Cells(1)

                            'recupero la fila seleccionada del detalle
                            Me.dgv_detalle.Rows(li_row_number).Selected = True
                            Me.dgv_detalle.CurrentCell = Me.dgv_detalle.Rows(li_row_number).Cells(3)
                        Catch ex As Exception

                        End Try


                        'refresco el datagridview 
                        detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)
                        Limpiar_Bindings()

                        'deshabilito los controles hasta una nueva seleccion del usuario
                        Me.rebaja_cant.Enabled = False
                        Me.txt_cantidadPacksDespachados.Enabled = False
                        Me.txt_motivo.Enabled = False
                        Me.cmb_liberar.Enabled = False

                        ' cambia la propiedad visible a FALSE del Text Motivo
                        Label3.Visible = False
                        Me.txt_motivo.Visible = False
                        cmb_liberar.Visible = False
                    End If
                Else
                    MessageBox.Show("ERROR: Tiene que escribir un motivo de actualizacion de linea....", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txt_motivo.Focus()
                End If
            Else
                MessageBox.Show("ERROR: La cantidad a actualizar debe ser un dato numérico mayor que cero.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Limpiar_Bindings()
                Me.rebaja_cant.Focus()
            End If
        Else
            MessageBox.Show("ERROR: No existen registros que modificar.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Limpiar_Bindings()
        End If
    End Sub

    Private Sub dgv_detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_detalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv_detalle.CurrentCellChanged

    End Sub

    Private Sub dgv_detalle_MouseCaptureChanged(sender As Object, e As EventArgs) Handles dgv_detalle.MouseCaptureChanged

    End Sub

    Private Sub dgv_detalle_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_detalle.MouseClick
        Limpiar_Bindings()

        ' cambia la propiedad visible a FALSE del Text Motivo
        Label3.Visible = False
        Me.txt_motivo.Visible = False
        cmb_liberar.Visible = False
        '


        ' habilito los controles para la actualizacion de la linea
        Me.rebaja_cant.Enabled = True
        Me.txt_cantidadPacksDespachados.Enabled = True
        Me.txt_motivo.Enabled = True
        If Me.cmb_liberar.Enabled = True Then
            Me.cmb_liberar.Enabled = False
        End If

        ' lleno los labels con la fila seleccionada por el usuario
        Me.glosa.Text = dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value
        Me.Cantidad_Pedida.Text = dgv_detalle.Item("Cantidad", dgv_detalle.CurrentRow.Index).Value
        Me.lbl_cant_x_pack.Text = dgv_detalle.Item("analisisproducto20", dgv_detalle.CurrentRow.Index).Value

        ' si la cantidad pedida dentro del innerpack es menor a 1 devuelve 0 
        ' de lo contrario devuelve la cantidad de innerpacks disponibles 
        If (dgv_detalle.Item("cantidad", dgv_detalle.CurrentRow.Index).Value / dgv_detalle.Item("analisisproducto20", dgv_detalle.CurrentRow.Index).Value) < 1 Then
            Me.lbl_packs_pedidos.Text = "0"
        Else
            Me.lbl_packs_pedidos.Text = Int(dgv_detalle.Item("cantidad", dgv_detalle.CurrentRow.Index).Value / dgv_detalle.Item("analisisproducto20", dgv_detalle.CurrentRow.Index).Value)
        End If

        ' Desbloque los text para ingresar las cantidades

        Me.rebaja_cant.Enabled = True
        Me.txt_cantidadPacksDespachados.Enabled = True


        Me.rebaja_cant.Focus()
        Me.Refresh()

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub txt_motivo_TextChanged(sender As Object, e As EventArgs) Handles txt_motivo.TextChanged

    End Sub

    Private Sub rebaja_cant_Enter(sender As Object, e As EventArgs) Handles rebaja_cant.Enter

    End Sub

    Private Sub rebaja_cant_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles rebaja_cant.GiveFeedback

    End Sub

    Private Sub rebaja_cant_GotFocus(sender As Object, e As EventArgs) Handles rebaja_cant.GotFocus
        ' cambia la propiedad visible a FALSE del Text Motivo
        Label3.Visible = False
        Me.txt_motivo.Visible = False
        cmb_liberar.Visible = False
        '

    End Sub

    Private Sub rebaja_cant_KeyDown(sender As Object, e As KeyEventArgs) Handles rebaja_cant.KeyDown

    End Sub



    Private Sub rebaja_cant_KeyPress2(sender As Object, e As KeyPressEventArgs) Handles rebaja_cant.KeyPress

        '' no permite ingresar letras 
        If Not (Char.IsNumber(e.KeyChar)) Then
            e.Handled = True
        End If

        '' permite el retroceso
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If

        '' occurre cuando presiona la tecla 'ENTER' o 'TAB'
        If Asc(e.KeyChar) = 13 Or e.KeyChar = Convert.ToChar(9) Then
            If Me.rebaja_cant.Text = "" Then
                Me.rebaja_cant.Text = 0
                Me.txt_cantidadPacksDespachados.Text = Val(Me.rebaja_cant.Text) / Val(Me.lbl_cant_x_pack.Text)
                Me.txt_motivo.Focus()
            End If
        End If

        '' occurre cuando presiona la tecla 'ENTER' o 'TAB'
        If Asc(e.KeyChar) = 13 Or e.KeyChar = Convert.ToChar(9) Then
            If Val(Me.rebaja_cant.Text) > Val(Cantidad_Pedida.Text) Then
                MessageBox.Show("ERROR: La cantidad a Rebajar debe ser menor a la pedida.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Limpiar_Bindings()
                Me.rebaja_cant.Focus()
            Else
                Dim parte_decimal As Double
                parte_decimal = (Val(Me.rebaja_cant.Text) Mod Val(Me.lbl_cant_x_pack.Text))
                If parte_decimal <> 0 Then
                    MessageBox.Show("ERROR: La cantidad a Rebajar debe ser multiplo de la cantidad que contiene el pack.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Limpiar_Bindings()
                    Me.rebaja_cant.Focus()
                Else
                    If MessageBox.Show("Esta Seguro de esta cantidad " & " ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.txt_cantidadPacksDespachados.Text = Val(Me.rebaja_cant.Text) / Val(Me.lbl_cant_x_pack.Text)

                        ' cambia la propiedad visible a TRUE del Text Motivo
                        Label3.Visible = True
                        Me.txt_motivo.Visible = True
                        cmb_liberar.Visible = True


                        ' habilito el boton de actualizar linea
                        Me.cmb_liberar.Enabled = True
                        Me.txt_motivo.Focus()
                    Else
                        Me.dgv_detalle.Focus()

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub rebaja_cant_KeyUp(sender As Object, e As KeyEventArgs) Handles rebaja_cant.KeyUp

    End Sub

    Private Sub rebaja_cant_Layout(sender As Object, e As LayoutEventArgs) Handles rebaja_cant.Layout

    End Sub

    Private Sub rebaja_cant_Leave(sender As Object, e As EventArgs) Handles rebaja_cant.Leave

    End Sub

    Private Sub rebaja_cant_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles rebaja_cant.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey() = True
        End If
    End Sub

    Private Sub rebaja_cant_TabIndexChanged(sender As Object, e As EventArgs) Handles rebaja_cant.TabIndexChanged

    End Sub

    Private Sub rebaja_cant_TextChanged_1(sender As Object, e As EventArgs) Handles rebaja_cant.TextChanged

    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles txt_cantidadPacksDespachados.GotFocus
        ' cambia la propiedad visible a FALSE del Text Motivo
        Label3.Visible = False
        Me.txt_motivo.Visible = False
        cmb_liberar.Visible = False
        '
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_cantidadPacksDespachados.KeyDown

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidadPacksDespachados.KeyPress

        ' no permite ingresar letras 
        If Not (Char.IsNumber(e.KeyChar)) Then
            e.Handled = True
        End If
        ' permite el input de la tecla retroceso
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If


        If Asc(e.KeyChar) = 13 Or e.KeyChar = Convert.ToChar(9) Then
            If Me.txt_cantidadPacksDespachados.Text = "" Then
                Me.txt_cantidadPacksDespachados.Text = 0
                ' If MessageBox.Show("Esta Seguro de esta cantidad " & " ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.rebaja_cant.Text = CInt(Me.txt_cantidadPacksDespachados.Text) * CInt(Me.lbl_cant_x_pack.Text)
                Me.txt_motivo.Focus()
                'End If
            End If
        End If

        If e.KeyChar = Chr(13) Or e.KeyChar = Convert.ToChar(9) Then

            If CInt(Me.txt_cantidadPacksDespachados.Text) > CInt(Me.lbl_packs_pedidos.Text) Then
                MessageBox.Show("ERROR: La cantidad de packs a Rebajar debe ser menor a la cantidad de packs pedidos.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Limpiar_Bindings()
                Me.txt_cantidadPacksDespachados.Focus()
            Else
                If (CInt(Me.txt_cantidadPacksDespachados.Text) * CInt(Me.lbl_cant_x_pack.Text)) > CInt(Cantidad_Pedida.Text) Then
                    MessageBox.Show("ERROR: La cantidad a Rebajar debe ser menor a la cantidad pedida.", "Umbright", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Limpiar_Bindings()
                    Me.txt_cantidadPacksDespachados.Focus()
                Else


                    If MessageBox.Show("Esta Seguro de esta cantidad " & " ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.rebaja_cant.Text = CInt(Me.txt_cantidadPacksDespachados.Text) * CInt(Me.lbl_cant_x_pack.Text)


                        ' cambia la propiedad visible a TRUE del Text Motivo
                        Label3.Visible = True
                        Me.txt_motivo.Visible = True
                        cmb_liberar.Visible = True
                        Me.txt_motivo.Focus()
                        '
                        ' habilito el boton de actualizar linea
                        Me.cmb_liberar.Enabled = True

                    Else
                        Me.rebaja_cant.Focus()
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_cantidadPacksDespachados.KeyUp

    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txt_cantidadPacksDespachados.Leave

    End Sub

    Private Sub TextBox1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt_cantidadPacksDespachados.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey() = True
        End If
    End Sub



    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub cant_pack_Click(sender As Object, e As EventArgs) Handles lbl_cant_x_pack.Click

    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Cantidad_Pedida_Click(sender As Object, e As EventArgs) Handles Cantidad_Pedida.Click

    End Sub

    Private Sub glosa_Click(sender As Object, e As EventArgs) Handles glosa.Click

    End Sub

    Private Sub dtp_fecha_final_ValueChanged(sender As Object, e As EventArgs) Handles dtp_fecha_final.ValueChanged
        'Pedidos_walmart()
    End Sub

    Private Sub dtp_fecha_inicio_ValueChanged(sender As Object, e As EventArgs) Handles dtp_fecha_inicio.ValueChanged
        'Pedidos_walmart()
    End Sub

    Private Sub dgv_pedidos_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_pedidos.SelectionChanged

    End Sub

    Private Sub cmb_liberar_Leave(sender As Object, e As EventArgs) Handles cmb_liberar.Leave

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Pedidos_walmart()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txt_cantidadPacksDespachados.TextChanged

    End Sub
End Class
