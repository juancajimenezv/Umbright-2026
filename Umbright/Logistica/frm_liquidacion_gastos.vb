Public Class frm_liquidacion_gastos
    Dim ods, ods1, ods_listado As New DataSet
    Dim existe_cliente As Boolean = False
    Public conectar As String = String.Empty
    Public dt, dt_guias As DataTable
    Public numero_liquidacion As Integer
    Dim placa As String
    Private ps_nombre_vista As String = ""
    Public lista_campos As String
    Public ps_parametros_fijos As String
    Public ds_guia As DataSet
    'Public gs_usuario As String = "admin"

    Dim fila As Integer
    Dim comida As String
    Dim viaticos As String
    Dim combustible As String
    Dim hospedaje As String
    Dim parqueo As String
    Dim peaje As String
    Dim taxi As String
    Dim gtos As String
    Dim otros As String
    Dim gasto As String
    Dim total As Double

    Dim dmarte As Integer = 0
    Dim codicasa As Integer = 0
    Dim alamsa As Integer = 0
    Dim diuva As Integer = 0
    Dim vinoteca As Integer = 0
    Dim laincodi As Integer = 0
    Dim dimaexsa As Integer = 0

    Private Sub llenar_combos()
        Dim ls_sql, ls_sqlc As String
        Dim tipos_doctos(20) As String
        Dim ldt_table, ldt_tablec, ldt_table_ As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()


        ls_sql = "pa_sel_um_gen_tabcod_all 'GEN_AUXILIAR'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "piloto"
        'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_auxiliar.DisplayMember = "CODIGO"
        Me.cmb_auxiliar.ValueMember = "CODIGO"
        Me.cmb_auxiliar.DataSource = ldt_table.DefaultView


        ls_sql = "pa_sel_um_gen_tabcod_all 'GEN_AUXILIAR'"
        ldt_table_ = oTransaccion.Obtiene(ls_sql)
        ldt_table_.TableName = "piloto"
        ' ldt_table_.DefaultView.RowFilter = "vigencia <> 'N'"

        Me.cmb_auxiliar2.DisplayMember = "CODIGO"
        Me.cmb_auxiliar2.ValueMember = "CODIGO"
        Me.cmb_auxiliar2.DataSource = ldt_table_.DefaultView


        ls_sql = "pa_sel_um_gen_tabcod_all 'GEN_PILOTO'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "piloto"
        'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_piloto.DisplayMember = "CODIGO"
        Me.cmb_piloto.ValueMember = "CODIGO"
        Me.cmb_piloto.DataSource = ldt_table.DefaultView

        ls_sql = "select tipodocto from tipodocumento where empresa='logiserv' and sistema='compras' and clase='Factura (c)' AND SUBSTRING(COMENTARIO,1,1)='S' order by 1"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "td"
        'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmb_TipoDocto.DisplayMember = "tipodocto"
        Me.cmb_TipoDocto.ValueMember = "tipodocto"
        Me.cmb_TipoDocto.DataSource = ldt_table.DefaultView

        ls_sqlc = "select codigo from gen_tabcod where empresa='logiserv' and tipo='con_ccosto'   order by 1"
        ldt_tablec = oTransaccion.Obtiene(ls_sqlc)
        ldt_tablec.TableName = "CC"
        Me.cmb_ccosto.DisplayMember = "codigo"
        Me.cmb_ccosto.ValueMember = "codigo"
        Me.cmb_ccosto.DataSource = ldt_tablec.DefaultView

        ls_sql = "select Codigo Item, Texto1 Gasto from gen_tabcod where empresa='logiserv' and tipo='con_item' and texto1!='' order by 2"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "tg"
        Me.cmb_tipo_documento.DisplayMember = "Gasto"
        Me.cmb_tipo_documento.ValueMember = "Gasto"
        Me.cmb_tipo_documento.DataSource = ldt_table.DefaultView

        oTransaccion.close()
        oTransaccion = Nothing


        '*--- Llena parametro de busqueda

        Me.cmb_valor1.Items.Add("Piloto")
        Me.cmb_valor1.Items.Add("Cod_Liquidacion")
        'Me.cmb_valor1.Items.Add("Origen")
        Me.cmb_valor1.Items.Add("Ruta")
        Me.cmb_valor1.Items.Add("Ayudante")

        'Me.cmb_campos.Items.Add("")

        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")

        Me.cmb_valor1.Text = "Cod_Liquidacion"
        Me.cmb_1.Text = "like"




    End Sub


    Private Sub Crear_Estructura()
        Dim dt, dt1, dt2 As DataTable

        ods = New DataSet

        dt = New DataTable("liquidacion")

        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Nit", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("No_Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Item", GetType(String)))
        dt.Columns.Add(New DataColumn("claseiva", GetType(String)))
        dt.Columns.Add(New DataColumn("Combustible", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Comida", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Hospedaje", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Parqueo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Peaje", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Taxi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Gtos_Trans", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Viaticos", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Otros", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("centrocosto", GetType(String)))
        dt.Columns.Add(New DataColumn("tipogas", GetType(String)))
        dt.Columns.Add(New DataColumn("galones", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Exento", GetType(Decimal)))
        dt.Columns("No_Factura").Unique = True
        ods.Tables.Add(dt)

        Me.dgv_liquidacion.DataSource = ods.Tables("liquidacion")



        ''------------------------------------------------------------

        ods1 = New DataSet
        dt1 = New DataTable("guias")
        dt1.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt1.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt1.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt1.Columns.Add(New DataColumn("Peso", GetType(Double)))
        dt1.Columns.Add(New DataColumn("Unidades", GetType(Double)))
        dt1.Columns.Add(New DataColumn("Volumen", GetType(Double)))
        ods1.Tables.Add(dt1)
        Me.dgv_guias.DataSource = ods1.Tables("guias")
    End Sub
    Private Sub crear_estructura_guias()
        Dim dt2 As DataTable
        ''------------------------------------------------------------

        ods_listado = New DataSet

        dt2 = New DataTable("listado")

        dt2.Columns.Add(New DataColumn("Cod_liquidacion", GetType(String)))
        dt2.Columns.Add(New DataColumn("Correlativo", GetType(String)))
        dt2.Columns.Add(New DataColumn("Piloto", GetType(String)))
        dt2.Columns.Add(New DataColumn("Ayudante", GetType(String)))
        dt2.Columns.Add(New DataColumn("Ayudante2", GetType(String)))
        dt2.Columns.Add(New DataColumn("Fecha_Del", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Fecha_Al", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Ruta", GetType(String)))
        dt2.Columns.Add(New DataColumn("Guardia", GetType(String)))
        dt2.Columns.Add(New DataColumn("km_inicial", GetType(String)))
        dt2.Columns.Add(New DataColumn("km_final", GetType(String)))
        dt2.Columns.Add(New DataColumn("carga", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt2.Columns.Add(New DataColumn("fecha_grabo", GetType(Date)))



        ods_listado.Tables.Add(dt2)

        Me.dgv_listado_liquidaciones.DataSource = ods_listado.Tables("listado")
    End Sub
    Private Sub llenar_informacion()
        Dim ls_sql, ls_sqls As String
        Dim dr, dr_aux As DataRow

        Dim dt, dt2 As DataTable

        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()

            'ls_sql = "pa_sel_um_liquidacionpiloto '" & Me.cmb_piloto.Text & "'"
            ls_sql = "pa_sel_um_liquidacionpiloto "
            dt = oTrans.Obtiene(ls_sql)

            ls_sqls = "pa_sel_um_liquidacionpilotod  " & dt.Rows(0).Item("cod_liquidacion")
            dt2 = oTrans.Obtiene(ls_sqls)

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows

                    dr_aux = ods_listado.Tables("listado").NewRow
                    dr_aux.Item("Cod_liquidacion") = dr.Item("cod_liquidacion")
                    dr_aux.Item("Correlativo") = dr.Item("correlativo")
                    dr_aux.Item("Piloto") = dr.Item("piloto")
                    dr_aux.Item("Ayudante") = dr.Item("ayudante")
                    dr_aux.Item("Ayudante2") = dr.Item("ayudante2")
                    dr_aux.Item("Fecha_Del") = dr.Item("fecha")
                    dr_aux.Item("Fecha_Al") = dr.Item("fechavcto")
                    dr_aux.Item("Ruta") = dr.Item("ruta")
                    dr_aux.Item("Guardia") = dr.Item("guardia")
                    dr_aux.Item("km_inicial") = dr.Item("km_inicial")
                    dr_aux.Item("km_final") = dr.Item("km_final")
                    dr_aux.Item("carga") = dr.Item("cantidad_combustible")
                    dr_aux.Item("usuario_grabo") = dr.Item("usuario_grabo")
                    dr_aux.Item("fecha_grabo") = dr.Item("fecha_grabo")
                    ods_listado.Tables("listado").Rows.Add(dr_aux)


                Next
                clsgen.Alinear_GridView(ods_listado.Tables("listado"), Me.dgv_listado_liquidaciones, ",Cod_liquidacion,Correlativo,Piloto,Ayudante,Ayudante2,Fecha_Del,Fecha_Al,Ayudante,Ruta,Guardian,km_inicial,km_final,carga,usuario_grabo,fecha_grabo,", ",Cod_liquidacion,Guardia,km_inicial,km_final,carga,usuario_grabo,fecha_grabo,", ",,", "", "", ",Codigo=100,Correlativo=75,Fecha_Del=100,Fecha_Al=100,Piloto=175,Ayudante=175,Ayudante2=175,", "", True, True, 200, 0)

            End If

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try



    End Sub

    Public Sub Imprimir_liquidacion()
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Logistica\Trafico\LiquidacionPiloto.rpt"
            pm_parametros(0) = "cod_liquidacion"
            pm_valores(0) = numero_liquidacion
            'pm_parametros(1) = "Numero de Documento"
            'pm_valores(0) = gs_empresa
            'pm_valores(1) = Me.lbl_numero.Text

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                            False, True, "PDF", False, "", True)
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub
    Private Sub llenar_detalle()

        Dim ls_sql, ls_sqls, lss_sql, prod, ls_caja, comentario As String
        Dim dr, dr_aux As DataRow
        Dim dt, dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")

        Try
            oTrans.open()

            ls_sqls = "pa_sel_um_liquidacionpilotod  " & numero_liquidacion
            dt2 = oTrans.Obtiene(ls_sqls)
            'MsgBox("Llena Detalle")

            lbl_numero.Text = dt2.Rows(0).Item("Cod_Liquidacion")


            If dt2.Rows.Count > 0 Then
                For Each dr In dt2.Rows
                    dr_aux = ods.Tables("liquidacion").NewRow
                    lss_sql = "select razonsocial from vi_proveedores where codlegal='" & dr.Item("Nit") & "'"
                    dt = oTrans.Obtiene(lss_sql)

                    dr_aux.Item("TipoDocto") = dr.Item("Tipo_Docto")
                    dr_aux.Item("Nit") = dr.Item("nit")
                    dr_aux.Item("Proveedor") = dt.Rows(0).Item("razonsocial").ToString
                    dr_aux.Item("Fecha") = dr.Item("fecha")
                    dr_aux.Item("Serie") = dr.Item("serie")
                    dr_aux.Item("No_Factura") = dr.Item("nodocto")
                    dr_aux.Item("Item") = dr.Item("Item")
                    dr_aux.Item("ClaseIva") = dr.Item("Iva_Clase")

                    dr_aux.Item("tipogas") = dr.Item("tipogas")
                    dr_aux.Item("galones") = dr.Item("galones")

                    If dr.Item("tipodocto").ToString = "Combustible" Then
                        dr_aux.Item("Combustible") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Comida" Then
                        dr_aux.Item("Comida") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Hospedaje" Then
                        dr_aux.Item("Hospedaje") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Parqueo" Then
                        dr_aux.Item("Parqueo") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Peaje" Then
                        dr_aux.Item("Peaje") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Taxi" Then
                        dr_aux.Item("Taxi") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Gtos_Trans" Then
                        dr_aux.Item("Gtos_Trans") = dr.Item("valor")
                        ' ya no se usaran
                    ElseIf dr.Item("tipodocto").ToString = "Viaticos" Then
                        dr_aux.Item("Viaticos") = dr.Item("valor")
                    ElseIf dr.Item("tipodocto").ToString = "Otros" Then
                        dr_aux.Item("Otros") = dr.Item("valor")
                    End If

                    dr_aux.Item("Total") = dr.Item("valor")
                    ods.Tables("liquidacion").Rows.Add(dr_aux)

                    Me.totalizar(ods.Tables("liquidacion"))



                Next
                Me.llenar_guias()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try

    End Sub

    Private Sub frm_liquidacion_gastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_Agrega.Visible = False
        llenar_combos()
        Crear_Estructura()
        llenar_informacion()
    End Sub


    Private Sub Maquillar_Grid()
        Dim Clsgen As New ClasesGenerales.General
        Try
            Me.dgv_liquidacion.DataSource = Nothing
            Me.dgv_liquidacion.DataSource = ods.Tables("liquidacion")
            Clsgen.Alinear_GridView(ods.Tables("liquidacion"), Me.dgv_liquidacion, ",tipodocto,nit,proveedor,fecha,serie,no_factura,item,claseiva,tipogas,galones,combustible,comida,hospedaje,parqueo,peaje,taxi,gtos_trans,viaticos,otros,total,", ",serie,", ",,", ",,", ",,", ",nit=75,proveedor=250,serie=50,no_factura=75,viaticos=65,viaticos=65,combustible=65,hospedaje=65,taxi=65,otros=65,total=65,", "", True, True, 250, 50)
            'ya no se usara'comida,viaticos,combustible,hospedaje,taxi,otros,total,", ",serie,", ",,", ",,", ",,", ",nit=75,proveedor=250,serie=50,no_factura=75,viaticos=65,viaticos=65,combustible=65,hospedaje=65,taxi=65,otros=65,total=65,", "", True, True, 250, 50)

        Catch ex As Exception
        Finally
            Clsgen = Nothing
        End Try

    End Sub



    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        If e.KeyChar = Chr(13) Then
            valida_periodos_abiertos()
            'Buscar_Cliente(True)
            'If existe_cliente Then
            '    boton_agregar_informacion()
            'Else
            '    MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Else
            Exit Sub
        End If
    End Sub
    Private Sub valida_periodos_abiertos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion


            ls_sql = "pa_sel_um_periodo_activo_flexline 'LOGISERV','" & dtp_fecha_docto.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                Buscar_Cliente(True)

                If existe_cliente Then
                    boton_agregar_informacion()
                Else
                    MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Ingrese Fecha Valida! Periodo Cerrado en Flexline!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtp_fecha_docto.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub


    Private Sub txt_valor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valor.LostFocus
        Try
            Me.txt_valor.Text = Double.Parse(Me.txt_valor.Text)

        Catch ex As Exception
            Me.txt_valor.Text = 0
        End Try

    End Sub
    Private Sub boton_agregar_informacion()
        Dim lbagregar_producto As Boolean = False

        Try
            If Val(Me.txt_valor.Text) = 0 Or Me.txt_nit.Text.Length = 0 Or Me.txt_proveedor.Text.Length = 0 Or Me.txt_numero.Text.Length = 0 Then

                MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf cmb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" And cmb_tipo_documento.Text <> "Combustible" Then
                MessageBox.Show("Valide Tipo de Documento y Gasto Combustible", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_TipoDocto.Focus()

            ElseIf cmb_TipoDocto.Text <> "COMBUSTIBLE POR PAGAR" And cmb_tipo_documento.Text = "Combustible" Then
                MessageBox.Show("Valide Tipo de Documento y Gasto Combustible", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_TipoDocto.Focus()

            ElseIf cmb_claseIva.SelectedIndex < 0 Then
                MessageBox.Show("Valide Clase de IVA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_claseIva.Focus()

            ElseIf txt_producto.Text.Length = 0 Or txt_item.Text.Length = 0 Then
                MessageBox.Show("Valide Producto/Item ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_producto.Focus()

            ElseIf txt_producto.Text = "1031014" And cmb_combustible.Text = "" Then
                MessageBox.Show("Debe Seleccionar tipo de Combustible ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_combustible.Focus()

            ElseIf txt_producto.Text = "1031014" And cmb_combustible.Text <> "" And cmb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" And txt_galones.Text = "0.00" Then
                MessageBox.Show("Debe Galones de Combustible ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_combustible.Focus()

            ElseIf txt_producto.Text = "1031014" And cmb_combustible.Text <> "" And cmb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" And cmb_claseIva.Text <> "Compra" Then
                MessageBox.Show("Valide Clase de IVA para Combustible ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_combustible.Focus()

            ElseIf cmb_TipoDocto.Text = "CAJA CHICA" And cmb_claseIva.Text = "Exento" Then
                MessageBox.Show("Valide Clase de IVA para Caja Chica ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb_TipoDocto.Focus()

            Else

                If txt_producto.Text <> "1031014" Then
                    cmb_combustible.Text = "NO"
                    txt_galones.Text = "0.00"
                End If

                lbagregar_producto = True

            End If

            If lbagregar_producto Then
                Agregar_Producto()
                limpiar_campos()
                Me.totalizar(ods.Tables("liquidacion"))
                Me.txt_numero.Focus()
            End If

        Catch ex As Exception
        Finally

        End Try

    End Sub
    Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, tot_viaticos, tot_combustible, tot_hospedaje, tot_otros, tot_comida, tot_taxi As Double
        total = 0
        tot_viaticos = 0
        tot_combustible = 0
        tot_hospedaje = 0
        tot_otros = 0
        tot_comida = 0
        tot_taxi = 0

        Try
            For Each dr In otabla.Rows
                Try

                    If dr.Item("Combustible").ToString.Length > 0 Then
                        tot_combustible += dr.Item("Combustible")
                    End If

                    If dr.Item("Comida").ToString.Length > 0 Then
                        tot_comida += dr.Item("Comida")
                    End If

                    If dr.Item("Hospedaje").ToString.Length > 0 Then
                        tot_hospedaje += dr.Item("Hospedaje")
                    End If

                    If dr.Item("Parqueo").ToString.Length > 0 Then
                        tot_otros += dr.Item("Parqueo")
                    End If

                    If dr.Item("Peaje").ToString.Length > 0 Then
                        tot_otros += dr.Item("Peaje")
                    End If

                    If dr.Item("Taxi").ToString.Length > 0 Then
                        tot_taxi += dr.Item("Taxi")
                    End If

                    If dr.Item("Gtos_Trans").ToString.Length > 0 Then
                        tot_otros += dr.Item("Gtos_Trans")
                    End If

                    If dr.Item("Viaticos").ToString.Length > 0 Then
                        tot_viaticos += dr.Item("Viaticos")
                    End If

                    If dr.Item("Otros").ToString.Length > 0 Then
                        tot_otros += dr.Item("Otros")
                    End If
                    '    total += dr.Item("total")

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            'Me.lbl_total.Text = total + Val(Me.txt_carga_combustible.Text)
            Me.lbl_total_viaticos.Text = tot_viaticos
            Me.lbl_total_combustible.Text = tot_combustible + Val(Me.txt_carga_combustible.Text)
            Me.lbl_total_hospedaje.Text = tot_hospedaje
            Me.lbl_comida.Text = tot_comida
            Me.lbl_otros.Text = tot_otros
            Me.lbl_taxi.Text = tot_taxi
            'MsgBox(Me.lbl_total_combustible.Text)
            Me.lbl_total.Text = CDbl(Me.lbl_total_combustible.Text) + CDbl(Me.lbl_otros.Text) + CDbl(Me.lbl_comida.Text) + CDbl(Me.lbl_total_hospedaje.Text) + CDbl(Me.lbl_taxi.Text)

            '+ CDbl(lbl_comida.Text) ' total + Val(Me.txt_carga_combustible.Text) + Val(Me.lbl_total_viaticos.Text) + Val(Me.lbl_total_combustible.Text) + Val(Me.lbl_total_hospedaje.Text) + Val(Me.lbl_comida.Text) + Val(Me.lbl_otros.Text) + Val(Me.lbl_taxi.Text)

            '     MsgBox(Me.lbl_total_combustible.Text + " + " + Me.lbl_otros.Text + " + " + Me.lbl_comida.Text)
            '    MsgBox(lbl_total.Text)

        End Try

    End Sub
    Private Sub Agregar_Producto()

        Dim dr, dr_aux As DataRow

        Try
            For Each dr In ods.Tables("liquidacion").Rows
                ' If dr.Item("nit") = Me.txt_nit.Text And dr.Item("No_Factura") = Me.txt_no_factura.Text And dr.Item("Serie") = Me.txt_serie.Text Then
                If dr.Item("Viaticos") = Me.cmb_tipo_documento.Text Or dr.Item("Comida") = Me.cmb_tipo_documento.Text Or dr.Item("Combustible") = Me.cmb_tipo_documento.Text Or dr.Item("Hospedaje") = Me.cmb_tipo_documento.Text Or dr.Item("Taxi") = Me.cmb_tipo_documento.Text Or dr.Item("Otros") = Me.cmb_tipo_documento.Text Then
                    dr.Delete()
                End If
            Next
        Catch ex As Exception
        End Try

        dr_aux = ods.Tables("liquidacion").NewRow
        dr_aux.Item("TipoDocto") = Me.cmb_TipoDocto.Text
        dr_aux.Item("Nit") = Me.txt_nit.Text
        dr_aux.Item("Proveedor") = Me.txt_proveedor.Text
        dr_aux.Item("Fecha") = Me.dtp_fecha_docto.Text
        dr_aux.Item("Serie") = Me.txt_serieSat.Text
        dr_aux.Item("No_Factura") = Me.txt_numero.Text
        dr_aux.Item("Item") = Me.txt_item.Text
        dr_aux.Item("Exento") = Me.txt_exento.Text

        If Me.cmb_tipo_documento.Text = "Combustible" Then
            dr_aux.Item("Combustible") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Comida" Then
            dr_aux.Item("Comida") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Hospedaje" Then
            dr_aux.Item("Hospedaje") = Me.txt_valor.Text


        ElseIf Me.cmb_tipo_documento.Text = "Parqueo" Then
            dr_aux.Item("Parqueo") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Peaje" Then
            dr_aux.Item("Peaje") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Taxi" Then
            dr_aux.Item("Taxi") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Gtos_Trans" Then
            dr_aux.Item("Gtos_Trans") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Viaticos" Then
            dr_aux.Item("Viaticos") = Me.txt_valor.Text

        ElseIf Me.cmb_tipo_documento.Text = "Otros" Then
            dr_aux.Item("Otros") = Me.txt_valor.Text

        End If

        dr_aux.Item("Total") = Me.txt_valor.Text

        dr_aux.Item("producto") = Me.txt_producto.Text
        dr_aux.Item("centrocosto") = cmb_ccosto.Text
        dr_aux.Item("claseiva") = cmb_claseIva.Text
        dr_aux.Item("tipogas") = cmb_combustible.Text
        dr_aux.Item("galones") = txt_galones.Text

        ods.Tables("liquidacion").Rows.Add(dr_aux)

        Me.Maquillar_Grid()



    End Sub
    Private Sub limpiar_campos()
        Me.txt_nit.Text = ""
        Me.txt_proveedor.Text = ("")
        ' Me.dtp_fecha_docto.Text = Today.Now
        Me.txt_no_factura.Text = ""
        Me.txt_valor.Text = 0
        Me.txt_serie.Text = ""
        txt_serieSat.Text = ""
        txt_numero.Text = ""
        'dtp_fecha_docto.Value = dt.Rows(0).Item("Fecha")
        txt_nit.Text = ""
        txt_valor.Text = "0.00"
        txt_proveedor.Text = ""
        cmb_tipo_documento.Text = ""
        cmb_combustible.Text = "NO"
        txt_galones.Text = "0.00"

    End Sub
    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Buscar_Cliente(True)
        If existe_cliente Then
            boton_agregar_informacion()
        Else
            MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If

    End Sub


    Private Sub dgv_liquidacion_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_liquidacion.RowHeaderMouseClick

        Try
            fila = dgv_liquidacion.CurrentRow.Index


            combustible = dgv_liquidacion.Rows(fila).Cells(8).Value.ToString()
            MsgBox(dgv_liquidacion.Rows(fila).Cells(8).Value.ToString())
            If combustible = "" Then
                combustible = "0"
            End If

            comida = dgv_liquidacion.Rows(fila).Cells(9).Value.ToString()
            If comida = "" Then
                comida = "0"
            End If

            hospedaje = dgv_liquidacion.Rows(fila).Cells(10).Value.ToString()
            If hospedaje = "" Then
                hospedaje = "0"
            End If

            parqueo = dgv_liquidacion.Rows(fila).Cells(11).Value.ToString()
            If parqueo = "" Then
                parqueo = "0"
            End If

            peaje = dgv_liquidacion.Rows(fila).Cells(12).Value.ToString()
            If peaje = "" Then
                peaje = "0"
            End If

            taxi = dgv_liquidacion.Rows(fila).Cells(13).Value.ToString()
            If taxi = "" Then
                taxi = "0"
            End If

            gtos = dgv_liquidacion.Rows(fila).Cells(14).Value.ToString()
            If gtos = "" Then
                gtos = "0"
            End If

            viaticos = dgv_liquidacion.Rows(fila).Cells(15).Value.ToString()
            If viaticos = "" Then
                viaticos = "0"
            End If

            otros = dgv_liquidacion.Rows(fila).Cells(16).Value.ToString()
            If otros = "" Then
                otros = "0"
            End If


            total = dgv_liquidacion.Rows(fila).Cells(17).Value

            If CDbl(combustible) > 0 Then
                gasto = "Combustible"
            ElseIf CDbl(comida) > 0 Then
                gasto = "Comida"
            ElseIf CDbl(hospedaje) > 0 Then
                gasto = "Hospedaje"
            ElseIf CDbl(parqueo) > 0 Then
                gasto = "Parqueo"
            ElseIf CDbl(peaje) > 0 Then
                gasto = "Peaje"
            ElseIf CDbl(taxi) > 0 Then
                gasto = "Taxi"
            ElseIf CDbl(gtos) > 0 Then
                gasto = "Gtos_Trans"
            ElseIf CDbl(viaticos) > 0 Then
                gasto = "Viaticos"
            ElseIf CDbl(otros) > 0 Then
                gasto = "Otros"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        '        MsgBox(gasto)

    End Sub

    Private Sub Eliminar_Linea()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try

            Otrans.open()   'abre conexion

            ls_sql = "pa_del_um_liquidacionpilotodd '" & numero_liquidacion & "','" & gasto & "'," & total
            Otrans.Actualiza(ls_sql)

            MessageBox.Show("Linea Eliminada !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub


    Private Sub dgv_liquidacion_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_liquidacion.UserDeletedRow
        If MsgBox("Seguro que Desea Eliminar la Linea? ", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            Try
                MsgBox("Se eliminara la fila " & fila & ",Tipo de Gasto " & gasto & ", Por un Monto de: " & total)
                Eliminar_Linea()
                totalizar(ods.Tables("liquidacion"))

            Catch ex As Exception
            End Try
        Else
            Exit Sub


        End If

    End Sub
    Private Sub totalizar_km()
        Try
            If CDbl(txt_km_final.Text) <= CDbl(txt_km_inicial.Text) Then
                MsgBox("Inconsistencia en los Kilometros Verifique!!", MsgBoxStyle.Critical, "Error")

                Me.txt_km_total.Text = Val(Me.txt_km_final.Text) - Val(Me.txt_km_inicial.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_km_final_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_km_final.KeyPress
        If e.KeyChar = Chr(13) Then
            Valida_Km_Final()
        End If

    End Sub

    Private Sub txt_km_final_LostFocus(sender As Object, e As EventArgs) Handles txt_km_final.LostFocus
        Valida_Km_Final()
    End Sub


    Private Sub Valida_Km_Final()
        If Not IsNumeric(txt_km_final.Text) Or Val(txt_km_final.Text) <= Val(txt_km_inicial.Text) Then
            MsgBox("Debe Ingresar Kilometro Final Valido / o Km Final Incorrecto")
            txt_km_final.Focus()
        Else
            txt_km_total.Text = Val(txt_km_final.Text) - Val(txt_km_inicial.Text)
            totalizar_km()
        End If

    End Sub


    'Private Sub txt_km_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_km_final.TextChanged
    '    totalizar_km()
    'End Sub

    Private Sub guardar_movimiento()
        Dim ls_sql, ls_sqls, ls_ssql, tipodocto, ls_caja, prod As String
        Dim dt, dt1 As DataTable
        Dim dr As DataRow
        Dim correlativo As Integer = 0
        Dim cod_liquidacion As Integer = 0
        Dim cod_liquidaciond As Integer = 0
        Dim numerocd, numeroala, numerodm, numerovi, numerodi, numeroli, numerodim As String
        Dim montocd, montodm, montoala, montodi, montovi, montoli, montodim As Decimal
        Dim pesocd, pesodm, pesoala, pesodi, pesovi, pesoli, pesodim As Decimal
        Dim unicd, unidm, uniala, unidi, univi, unili, unidim As Decimal
        Dim volcd, voldm, volala, voldi, volvi, volli, voldim As Decimal
        Dim comentario As String

        Dim guardian As Integer = 0
        Dim valor As Double

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()

            If Me.dgv_liquidacion.Rows.Count >= 0 Then
                ls_sqls = "pa_sel_um_cod_liquidacionpiloto  "
                dt = Otrans.Obtiene(ls_sqls)

                ls_sql = "pa_sel_um_corr_liquidacionpiloto '" & Me.cmb_piloto.Text & "'"
                dt1 = Otrans.Obtiene(ls_sql)

                Try
                    If Me.rb_si.Checked = True Then
                        guardian = 1
                    ElseIf Me.rb_no.Checked = True Then
                        guardian = 0
                    End If
                    If dt.Rows.Count > 0 Then
                        cod_liquidacion = dt.Rows(0).Item("cod_liquidacion") + 1
                    End If

                    If dt1.Rows.Count > 0 And dt1.Rows(0).Item("correlativo").ToString <> "" Then
                        correlativo = dt1.Rows(0).Item("correlativo") + 1
                    Else
                        correlativo = 1
                    End If

                Catch ex As Exception

                    correlativo = 1
                    cod_liquidacion = 1
                    cod_liquidaciond = 0

                End Try
                If Me.txt_carga_combustible.Text.Length = 0 Or Me.txt_carga_combustible.Text = "" Then
                    Me.txt_carga_combustible.Text = 0

                End If

                ls_ssql = "pa_ins_um_liquidacionPiloto " & cod_liquidacion & "," & correlativo &
                " ,'" & Me.cmb_piloto.Text & "','" &
                Me.cmb_auxiliar.Text & "','" & Me.cmb_auxiliar2.Text & "'," & 0 & ",'" &
                Me.dtp_fecha_del.Text & "','" & Me.dtp_fecha_al.Text & "','" &
                Me.cmb_ruta.Text & "'," & guardian & "," & Me.txt_km_inicial.Text & "," &
                Me.txt_km_final.Text & ",'" & gs_usuario & "'," & Me.txt_carga_combustible.Text & ",'" & placa & "'"

                Otrans.Ingresa(ls_ssql)

                For Each dr In ods.Tables("liquidacion").Rows

                    Try
                        cod_liquidaciond = (cod_liquidaciond + 1)

                        If dr.Item("combustible").ToString <> "" Then
                            valor = Double.Parse(dr.Item("combustible").ToString)
                            tipodocto = "Combustible"

                        ElseIf dr.Item("comida").ToString <> "" Then
                            valor = Double.Parse(dr.Item("comida").ToString)
                            tipodocto = "Comida"

                        ElseIf dr.Item("hospedaje").ToString <> "" Then
                            valor = Double.Parse(dr.Item("hospedaje").ToString)
                            tipodocto = "Hospedaje"

                        ElseIf dr.Item("parqueo").ToString <> "" Then
                            valor = Double.Parse(dr.Item("parqueo").ToString)
                            tipodocto = "Parqueo"

                        ElseIf dr.Item("peaje").ToString <> "" Then
                            valor = Double.Parse(dr.Item("peaje").ToString)
                            tipodocto = "Peaje"

                        ElseIf dr.Item("taxi").ToString <> "" Then
                            valor = Double.Parse(dr.Item("taxi").ToString)
                            tipodocto = "Taxi"

                        ElseIf dr.Item("gtos_trans").ToString <> "" Then
                            valor = Double.Parse(dr.Item("gtos_trans").ToString)
                            tipodocto = "Gtos_Trans"

                        ElseIf dr.Item("viaticos").ToString <> "" Then
                            valor = Double.Parse(dr.Item("viaticos").ToString)
                            tipodocto = "Viaticos"

                        ElseIf dr.Item("Otros").ToString <> "" Then
                            valor = Double.Parse(dr.Item("Otros").ToString)
                            tipodocto = "Otros"
                        End If

                        ls_sql = "pa_ins_um_liquidacionPilotoD  " & cod_liquidacion & ",'" &
                       dr.Item("nit").ToString & "','" & dr.Item("fecha") & "','" &
                        dr.Item("No_Factura").ToString & "','" & dr.Item("Serie").ToString & " '," & "'" &
                        tipodocto & "'," & valor
                        Otrans.Ingresa(ls_sql)

                        prod = ""
                        '   ----------- carga a cajas chicas
                        '   ----------------------------------
                        If dgv_liquidacion.Rows(fila).Cells(7).Value.ToString() <> "" Then
                            prod = "1031012"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(10).Value.ToString() <> "" Then
                            prod = "1031013"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(6).Value.ToString() <> "" Then
                            prod = "1031014"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(8).Value.ToString() <> "" Then
                            prod = "1031011"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(11).Value.ToString() <> "" Then
                            prod = "1031017"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(9).Value.ToString() <> "" Then
                            prod = "1031015"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(12).Value.ToString() <> "" Then
                            prod = "1031016"
                        End If

                        'If dr.Item("exento") = "" Then
                        '    dr.Item("exento") = "0.00"
                        'End If
                        '   Math.Round(dr.Item("Total") / 1.12 * 0.12, 2)
                        'cod_liquidacion = 11565

                        comentario = "Liq." & cod_liquidacion & ", CC:" & dr.Item("centrocosto") & ", R:" & cmb_ruta.Text & ", P:" & cmb_piloto.Text & ", V:" & txt_vehiculo.Text & ""

                        ls_caja = "spa_Guarda_Cajas_Chicas 'LOGISERV'," & cod_liquidacion & ",'" & dr.Item("TipoDocto").ToString & "','" & dtp_fecha_docto.Text & "','" &
                            dr.Item("No_Factura") & "','" & dr.Item("Nit") & "','" & gs_usuario & "','" & dr.Item("Serie") & "','" & dr.Item("Total") & "','" & dr.Item("Item") & "','" & dr.Item("Item") & "','" &
                            dr.Item("centrocosto") & "','" & dr.Item("claseiva") & "','" & dr.Item("exento") & "',0.00,0.00," &
                            0 & ",'" & comentario & "','" & dr.Item("tipogas") & "','" & IIf(dr.Item("galones").ToString = "", 0.00, dr.Item("galones")) & "','" & gs_usuario & "','" & Now() & "',0,0,0"
                        Otrans.Obtiene(ls_caja)

                        '---------- txt_glosa.Text

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Next

                For Each dr In ods1.Tables("guias").Rows

                    Try
                        ls_sql = "pa_ins_um_liquidacionPilotoGuiaD   '" & dr.Item("Empresa") & "'," & cod_liquidacion & ",'" & dr.Item("Numero") & "'," & dr.Item("monto") & "," & dr.Item("peso")
                        Otrans.Ingresa(ls_sql)

                        If dr.Item("Empresa").ToString = "CODICASA" Then
                            numerocd = dr.Item("Numero").ToString & " " & numerocd
                            montocd = dr.Item("Monto").ToString + montocd
                            pesocd = dr.Item("Peso").ToString + pesocd
                            unicd = dr.Item("Unidades").ToString + unicd
                            volcd = dr.Item("Volumen").ToString + volcd

                        End If
                        If dr.Item("Empresa").ToString = "DMARTE1" Then
                            numerodm = dr.Item("Numero").ToString & " " & numerodm
                            montodm = dr.Item("Monto").ToString + montodm
                            pesodm = dr.Item("Peso").ToString + pesodm
                            unidm = dr.Item("Unidades").ToString + unidm
                            voldm = dr.Item("Volumen").ToString + voldm
                        End If
                        If dr.Item("Empresa").ToString = "ALAMSA" Then
                            numeroala = dr.Item("Numero").ToString & " " & numeroala
                            montoala = Double.Parse(dr.Item("Monto").ToString) + montoala
                            pesoala = Double.Parse(dr.Item("Peso").ToString) + pesoala
                            uniala = dr.Item("Unidades").ToString + uniala
                            volala = dr.Item("Volumen").ToString + volala
                        End If
                        If dr.Item("Empresa").ToString = "DIUVA" Then
                            numerodi = dr.Item("Numero").ToString & " " & numerodi
                            montodi = dr.Item("Monto").ToString + montodi
                            pesodi = dr.Item("Peso").ToString + pesodi
                            unidi = dr.Item("Unidades").ToString + unidi
                            voldi = dr.Item("Volumen").ToString + voldi
                        End If
                        If dr.Item("Empresa").ToString = "VINOTECA" Then
                            numerovi = dr.Item("Numero").ToString & " " & numerovi
                            montovi = dr.Item("Monto").ToString + montovi
                            pesovi = dr.Item("Peso").ToString + pesovi
                            univi = dr.Item("Unidades").ToString + univi
                            volvi = dr.Item("Volumen").ToString + volvi
                        End If

                        If dr.Item("Empresa").ToString = "LAINCONDI" Then
                            numeroli = dr.Item("Numero").ToString & " " & numeroli
                            montoli = dr.Item("Monto").ToString + montoli
                            pesoli = dr.Item("Peso").ToString + pesoli
                            unili = dr.Item("Unidades").ToString + unili
                            volli = dr.Item("Volumen").ToString + volli
                        End If

                        If dr.Item("Empresa").ToString = "DIMAEXSA" Then
                            numerodim = dr.Item("Numero").ToString & " " & numerodim
                            montodim = dr.Item("Monto").ToString + montodim
                            pesodim = dr.Item("Peso").ToString + pesodim
                            unidim = dr.Item("Unidades").ToString + unidim
                            voldim = dr.Item("Volumen").ToString + voldim
                        End If

                    Catch ex As Exception
                    End Try
                Next

                ls_sql = "pa_ins_um_liquidacionPilotoGuias_temp   " & cod_liquidacion & " ,'" &
                        numerodm & "'," & montodm & "," & pesodm & "," & unidm & "," & voldm & "," & Me.dmarte & ",'" &
                        numeroala & "'," & montoala & "," & pesoala & "," & uniala & "," & volala & "," & Me.alamsa & ",'" &
                        numerocd & "'," & montocd & "," & pesocd & "," & unicd & "," & volcd & "," & Me.codicasa & ",'" &
                        numerodi & "'," & montodi & "," & pesodi & "," & unidi & "," & voldi & "," & Me.diuva & ",'" &
                        numerovi & "'," & montovi & "," & pesovi & "," & univi & "," & volvi & "," & Me.vinoteca

                Otrans.Ingresa(ls_sql)


                MessageBox.Show("Informacion Guardada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                numero_liquidacion = cod_liquidacion
                Me.dmarte = 0
                Me.codicasa = 0
                Me.diuva = 0
                Me.alamsa = 0
                Me.vinoteca = 0
                Me.laincodi = 0
                Me.dimaexsa = 0


                If MessageBox.Show("Desea Imprimir la Liquidacion", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Imprimir_liquidacion()
                End If

                limpiar()



            End If

        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing


        End Try
    End Sub

    Private Sub Actualizar()
        Dim ls_sql, ls_sqls, ls_ssql, tipodocto As String
        Dim dt, dt1 As DataTable
        Dim dr As DataRow
        Dim correlativo As Integer = 0
        Dim cod_liquidacion As Integer = 0
        Dim cod_liquidaciond As Integer = 0
        Dim numerocd, numeroala, numerodm, numerovi, numerodi As String
        Dim montocd, montodm, montoala, montodi, montovi As Decimal
        Dim pesocd, pesodm, pesoala, pesodi, pesovi As Decimal
        Dim unicd, unidm, uniala, unidi, univi As Decimal
        Dim volcd, voldm, volala, voldi, volvi As Decimal

        Dim guardian As Integer = 0
        Dim valor As Double

        Dim prod As String
        Dim ls_caja As String
        Dim comentario As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()

            If Me.dgv_liquidacion.Rows.Count >= 0 Then

                Try
                    If Me.rb_si.Checked = True Then
                        guardian = 1
                    ElseIf Me.rb_no.Checked = True Then
                        guardian = 0
                    End If

                Catch ex As Exception

                End Try

                '-----------------------------------
                If Me.txt_carga_combustible.Text.Length = 0 Or Me.txt_carga_combustible.Text = "" Then
                    Me.txt_carga_combustible.Text = 0

                End If

                ls_ssql = "pa_upd_LiquidacionPiloto " & numero_liquidacion & "," & lbl_numero.Text & ",'" &
                Me.dtp_fecha_del.Text & "','" & Me.dtp_fecha_al.Text & "','" &
                guardian & "'," & Me.txt_km_inicial.Text & "," &
                Me.txt_km_final.Text & ",'" & gs_usuario & "'"
                Otrans.Ingresa(ls_ssql)

                For Each dr In ods.Tables("liquidacion").Rows

                    Try
                        '                cod_liquidaciond = (cod_liquidaciond + 1)

                        '                If dr.Item("combustible").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("combustible").ToString)
                        '                    tipodocto = "Combustible"

                        '                ElseIf dr.Item("comida").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("comida").ToString)
                        '                    tipodocto = "Comida"

                        '                ElseIf dr.Item("hospedaje").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("hospedaje").ToString)
                        '                    tipodocto = "Hospedaje"

                        '                ElseIf dr.Item("parqueo").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("parqueo").ToString)
                        '                    tipodocto = "Parqueo"

                        '                ElseIf dr.Item("peaje").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("peaje").ToString)
                        '                    tipodocto = "Peaje"

                        '                ElseIf dr.Item("taxi").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("taxi").ToString)
                        '                    tipodocto = "Taxi"

                        '                ElseIf dr.Item("gtos_trans").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("gtos_trans").ToString)
                        '                    tipodocto = "Gtos_Trans"

                        '                ElseIf dr.Item("viaticos").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("viaticos").ToString)
                        '                    tipodocto = "Viaticos"

                        '                ElseIf dr.Item("Otros").ToString <> "" Then
                        '                    valor = Double.Parse(dr.Item("Otros").ToString)
                        '                    tipodocto = "Otros"
                        '                End If

                        '                ls_sql = "pa_ins_um_liquidacionPilotoD  " & cod_liquidacion & ",'" &
                        'dr.Item("nit").ToString & "','" & dr.Item("fecha") & "','" &
                        ' dr.Item("No_Factura").ToString & "','" & dr.Item("Serie").ToString & " '," & "'" &
                        ' tipodocto & "'," & valor

                        '                Otrans.Ingresa(ls_sql)

                        prod = ""
                        '   ----------- carga a cajas chicas
                        '   ----------------------------------
                        If dgv_liquidacion.Rows(fila).Cells(7).Value.ToString() <> "" Then
                            prod = "1031012"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(10).Value.ToString() <> "" Then
                            prod = "1031013"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(6).Value.ToString() <> "" Then
                            prod = "1031014"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(8).Value.ToString() <> "" Then
                            prod = "1031011"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(11).Value.ToString() <> "" Then
                            prod = "1031017"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(9).Value.ToString() <> "" Then
                            prod = "1031015"
                        End If

                        If dgv_liquidacion.Rows(fila).Cells(12).Value.ToString() <> "" Then
                            prod = "1031016"
                        End If

                        '   Math.Round(dr.Item("Total") / 1.12 * 0.12, 2)
                        'cod_liquidacion = 11565

                        comentario = "Liq." & cod_liquidacion & ", CC:" & dr.Item("centrocosto") & ", R:" & cmb_ruta.Text & ", P:" & cmb_piloto.Text & ", V:" & txt_vehiculo.Text & ""


                        ls_caja = "spa_Guarda_Cajas_Chicas 'LOGISERV'," & numero_liquidacion & ",'" & dr.Item("TipoDocto").ToString & "','" & dtp_fecha_docto.Text & "','" &
             dr.Item("No_Factura")


                        ls_caja = "spa_Guarda_Cajas_Chicas 'LOGISERV'," & numero_liquidacion & ",'" & dr.Item("TipoDocto").ToString & "','" & dtp_fecha_docto.Text & "','" &
             dr.Item("No_Factura") & "','" & dr.Item("Nit") & "','" & gs_usuario & "','" & dr.Item("Serie") & "','" & dr.Item("Total") & "','" & dr.Item("Item") & "','" & dr.Item("Item") & "','" &
             dr.Item("centrocosto") & "','" & dr.Item("claseiva") & "','0.00',0.00,0.00," &
             0 & ",'" & comentario & "','" & dr.Item("tipogas") & "','" & IIf(dr.Item("galones").ToString = "", 0.00, dr.Item("galones")) & "','" & gs_usuario & "','" & Now() & "',0,0,0.00"
                        Otrans.Obtiene(ls_caja)

                        '---------- txt_glosa.Text

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Next





                MessageBox.Show("Informacion Actualizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                numero_liquidacion = cod_liquidacion
                Me.dmarte = 0
                Me.codicasa = 0
                Me.diuva = 0
                Me.alamsa = 0
                Me.vinoteca = 0
                Me.laincodi = 0
                Me.dimaexsa = 0

                If MessageBox.Show("Desea Imprimir la Liquidacion", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Imprimir_liquidacion()
                End If

                limpiar()



            End If

        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing


        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If btn_guardar.Text = "Guardar" Then
            If Me.dgv_guias.Rows.Count >= 0 And Val(Me.txt_km_final.Text) > 0 And Val(Me.txt_km_final.Text) > Val(Me.txt_km_inicial.Text) And Me.dgv_liquidacion.Rows.Count > 0 And Me.lbl_numero.Text = "" Then
                guardar_movimiento()
                Crear_Estructura()
                llenar_informacion()
            Else
                MessageBox.Show("No se puede guardar la informacion, favor hacer la revision", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            Actualizar()
            'guardar_movimiento()
            limpiar()
            limpiar_campos()
            txt_buscar1.Text = ""
            dgv_listado_liquidaciones.DataSource = Nothing
        End If

    End Sub
    Private Sub limpiar()
        ods.Tables("liquidacion").Rows.Clear()
        ods1.Tables("guias").Rows.Clear()
        Me.txt_km_inicial.Text = ""
        Me.txt_km_final.Text = ""
        Me.txt_km_total.Text = ""
        Me.txt_serie.Text = ""

        Me.lbl_comida.Text = 0
        Me.lbl_total_combustible.Text = 0
        Me.lbl_total_hospedaje.Text = 0

        Me.lbl_total_viaticos.Text = 0
        Me.lbl_total.Text = 0
        Me.txt_peso.Text = 0
        Me.txt_monto.Text = 0
        Me.lbl_otros.Text = 0

        Me.cmb_ruta.Text = ""
        Me.lbl_numero.Text = ""
        Me.txt_carga_combustible.Text = 0
        Me.StatusBarPanel1.Text = ""
        Me.StatusBarPanel2.Text = ""
        Me.txt_nit.Text = ""
        Me.txt_proveedor.Text = ""

        txt_numero.Text = ""
        txt_serieSat.Text = ""
        txt_nit.Text = ""
        txt_valor.Text = "0.00"
        txt_proveedor.Text = ""

        cmb_combustible.Text = ""
        txt_galones.Text = "0.00"
        txt_producto.Text = ""
        txt_item.Text = ""

        btn_Agrega.Visible = False


    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        habilitar_campos()
        'Dim oform As New frm_control_transporte
        'oform.Show()

    End Sub
    Private Sub llenar_guias()
        Dim ls_sql, ls_ssql As String
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim peso_total As Double = 0
        Dim unidades As Double = 0
        Dim volumen As Double = 0
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")


        Try
            ods1.Tables("guias").Rows.Clear()
            oTrans.open()

            'ls_sql = "Select * from documento where tipodocto='CONTROL DE TRANSPORTE CDX' " & _
            '" and analisis='" & Me.cmb_piloto.Text & "'  and fecha='" & Me.dtp_fecha_del.Text & "' and fechavcto='" & Me.dtp_fecha_al.Text & "'"
            ls_sql = "pa_sel_um_documento_control_transporte '" & Me.cmb_piloto.Text & "','" & Me.dtp_fecha_del.Text & "','" & Me.dtp_fecha_al.Text & "'"

            dt = oTrans.Obtiene(ls_sql)
            dt_guias = dt

            If dt.Rows.Count > 0 Then

                Me.placa = dt.Rows(0).Item("TipoCta").ToString
                Me.cmb_ccosto.Text = dt.Rows(0).Item("Ccosto").ToString
                Me.txt_vehiculo.Text = dt.Rows(0).Item("TipoCta").ToString

                For i As Integer = 0 To dt.Rows.Count - 1
                    ls_ssql = "pa_sel_um_gen_control_transporte_detalle_temporal_liquidacion '" & dt.Rows(i).Item("empresa").ToString & "','" & dt.Rows(i).Item("numero").ToString & "',1"
                    dt2 = oTrans.Obtiene(ls_ssql)
                    If dt2.Rows.Count > 0 Then
                        Me.cmb_ruta.Text = dt.Rows(0).Item("glosa")



                        For j As Integer = 0 To dt2.Rows.Count - 1
                            Try
                                '******************************************************
                                If dt2.Rows(j).Item("empresa").ToString = "DMARTE1" Then
                                    dmarte += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "CODICASA" Then
                                    codicasa += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "ALAMSA" Then
                                    alamsa += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "DIUVA" Then
                                    diuva += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "VINOTECA" Then
                                    vinoteca += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "LAINCONDI" Then
                                    laincodi += 1
                                ElseIf dt2.Rows(j).Item("empresa").ToString = "DIMAEXSA" Then
                                    dimaexsa += 1

                                End If

                                '*****************************************************
                                peso_total = peso_total + dt2.Rows(j).Item("peso")
                                unidades = unidades + dt2.Rows(j).Item("unidades")
                                volumen = volumen + dt2.Rows(j).Item("volumen")
                            Catch ex As Exception

                            End Try
                        Next
                        dr_aux = ods1.Tables("guias").NewRow
                        dr_aux.Item("Empresa") = dt2.Rows(0).Item("empresa").ToString
                        dr_aux.Item("Numero") = dt2.Rows(0).Item("numero").ToString

                        dr_aux.Item("Monto") = dt.Rows(i).Item("total")  'Format(Convert.ToDecimal(dt.Rows(i).Item("total")), "###,###,##0.00").ToString 'dt.Rows(i).Item("total") 'Format(Convert.ToDecimal(dt.Rows(i).Item("total")), "###,###,##0.00").ToString 'dt.Rows(i).Item("total").ToString
                        dr_aux.Item("Peso") = peso_total 'Format(Convert.ToDecimal(peso_total), "###,###,##0.00").ToString
                        dr_aux.Item("Unidades") = unidades
                        dr_aux.Item("Volumen") = volumen
                        ods1.Tables("guias").Rows.Add(dr_aux)
                        peso_total = 0
                        unidades = 0
                        volumen = 0


                    End If

                Next

                'ls_sql = "update liquidacionpilotoguias  set DMfacturas=" & dmarte & ", CDfacturas=" & codicasa & ", ALfacturas=" & alamsa & ", DIfacturas=" & diuva & ",VIfacturas=" & vinoteca & " where cod_liquidacion=" & numero_liquidacion & ""
                'oTrans.Actualiza(ls_sql)
                Recalcular_Totales(ods1.Tables("guias"))
                clsgen.Alinear_GridView(ods1.Tables("guias"), Me.dgv_guias, ",Empresa,Numero,Monto,Peso,Unidades,Volumen,", "", "", "", "", ",Empresa=80,Numero=80,Monto=75,Peso=60,Unidades=60,Volumen=60,", "", True, True, 200, 0)


            End If


            'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value
            'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value

            'Me.dtp_fecha_docto.Value = Me.dtp_fecha_docto.MinDate


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try


    End Sub
    Private Sub Recalcular_Totales(ByVal dt As DataTable)
        Dim dr As DataRow
        Dim total, total_peso, unidades, volumen As Double

        total = 0
        total_peso = 0
        unidades = 0
        volumen = 0

        Try

            For Each dr In dt.Rows
                total = total + dr.Item("Monto")
                total_peso = total_peso + dr.Item("Peso")
                unidades = unidades + dr.Item("unidades")
                volumen = volumen + dr.Item("volumen")

            Next
        Catch ex As Exception
        Finally
            Me.txt_monto.Text = total
            Me.txt_peso.Text = total_peso

            Try
                'Me.StatusBarPanel1.Text = "Documentos " & .Tables("detalle_guia").Rows.Count.ToString
            Catch ex As Exception
            End Try
        End Try

    End Sub
    Private Sub lbl_total_viaticos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total_viaticos.TextChanged
        Me.lbl_total_viaticos.Text = Format(Convert.ToDecimal(Me.lbl_total_viaticos.Text), "###,###,##0.00").ToString
    End Sub
    Private Sub lbl_total_combustible_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total_combustible.TextChanged
        Me.lbl_total_combustible.Text = Format(Convert.ToDecimal(Me.lbl_total_combustible.Text), "###,###,##0.00").ToString
    End Sub
    Private Sub lbl_total_hospedaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total_hospedaje.TextChanged
        Me.lbl_total_hospedaje.Text = Format(Convert.ToDecimal(Me.lbl_total_hospedaje.Text), "###,###,##0.00").ToString
    End Sub
    Private Sub lbl_total_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total.TextChanged
        Me.lbl_total.Text = Format(Convert.ToDecimal(Me.lbl_total.Text), "###,###,##0.00").ToString
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        llenar_guias()

    End Sub
    Private Sub txt_km_inicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_km_inicial.TextChanged
        totalizar_km()
    End Sub
    Private Sub txt_nit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
        Dim ls_codigo As String
        If e.KeyChar = Chr(13) Then
            realizarBusquedaCliente()
        End If
    End Sub
    Private Sub Buscar_Cliente(ByVal bmostrar_alerta As Boolean)
        Dim ls_sql, ls_sql2 As String
        Dim dt, dt2 As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim bcrear_cliente As Boolean = False

        Try
            Otrans.open()


            ls_sql = "select * from ctacte where empresa='LOGISERV' AND TIPOCTACTE='PROVEEDOR' AND codlegal='" & Me.txt_nit.Text & "'"
            dt = Otrans.Obtiene(ls_sql)


            ls_sql2 = "select * from liquidacionpilotoproveedores where codlegal='" & Me.txt_nit.Text & "'"
            dt2 = Otrans.Obtiene(ls_sql2)

            If dt.Rows.Count > 0 Then

                With dt.Rows(0)
                    Me.txt_nit.Text = .Item("CodLegal").ToString
                    Me.txt_proveedor.Text = .Item("RazonSocial").ToString
                End With
                '  Me.dtp_fecha_docto.Focus()
                Me.cmb_tipo_documento.Focus()

                existe_cliente = True

            ElseIf dt2.Rows.Count > 0 Then

                With dt2.Rows(0)
                    Me.txt_nit.Text = .Item("CodLegal").ToString
                    Me.txt_proveedor.Text = .Item("RazonSocial").ToString
                End With
                'Me.dtp_fecha_docto.Focus()
                Me.cmb_tipo_documento.Focus()
                existe_cliente = True
            Else
                '   Me.txt_proveedor.Text = ""
                Me.txt_nit.Focus()
                existe_cliente = False
            End If


            If existe_cliente = False Then
                If MessageBox.Show("El Proveedor No Existe, Desea Ingresar Nuevo", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim frm_busqueda As New Frm_ClienteNuevo
                    frm_busqueda.cnit = Me.txt_nit.Text
                    frm_busqueda.crazon = Me.txt_proveedor.Text

                    frm_busqueda.ShowDialog(Me)
                    frm_busqueda.Dispose()
                    frm_busqueda = Nothing
                    'Me.txt_nit.Text = frm_busqueda.txt_nit.Text
                    realizarBusquedaCliente()

                End If
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
    Private Sub realizarBusquedaCliente()
        Dim ls_codigo As String
        Buscar_Cliente(True)

    End Sub
    Private Sub lbl_comida_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_comida.TextChanged
        Me.lbl_comida.Text = Format(Convert.ToDecimal(Me.lbl_comida.Text), "###,###,##0.00").ToString
    End Sub
    Private Sub deshabilitar_campos()
        Me.cmb_piloto.Enabled = False
        Me.cmb_auxiliar.Enabled = False
        Me.cmb_auxiliar2.Enabled = False
        '  Me.dtp_fecha_del.Enabled = False
        ' Me.dtp_fecha_al.Enabled = False
        ' Me.txt_km_inicial.Enabled = False
        ' Me.txt_km_final.Enabled = False
        Me.Button1.Visible = False
        ' Me.btn_agregar_producto.Visible = False
        Me.txt_carga_combustible.Enabled = False

    End Sub
    Private Sub habilitar_campos()
        Me.cmb_piloto.Enabled = True
        Me.cmb_auxiliar.Enabled = True
        Me.cmb_auxiliar2.Enabled = True
        'Me.dtp_fecha_del.Enabled = True

        'Me.dtp_fecha_al.Enabled = True
        'Me.txt_km_inicial.Enabled = True
        'Me.txt_km_final.Enabled = True
        Me.Button1.Visible = True
        ' Me.btn_agregar_producto.Visible = True
        Me.txt_carga_combustible.Enabled = True

    End Sub
    Private Sub dgv_listado_liquidaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado_liquidaciones.DoubleClick
        Dim dr As DataRow
        Dim nRow As Integer
        Dim numero As String

        Try
            ods.Tables("liquidacion").Rows.Clear()
            nRow = Me.dgv_listado_liquidaciones.CurrentCell.RowIndex

            numero_liquidacion = Me.dgv_listado_liquidaciones.Item(0, nRow).Value.ToString

            Me.lbl_numero.Text = Me.dgv_listado_liquidaciones.Item(1, nRow).Value.ToString
            Me.cmb_piloto.Text = Me.dgv_listado_liquidaciones.Item(2, nRow).Value.ToString
            Me.cmb_auxiliar.Text = Me.dgv_listado_liquidaciones.Item(3, nRow).Value.ToString
            Me.cmb_auxiliar2.Text = Me.dgv_listado_liquidaciones.Item(4, nRow).Value.ToString
            Me.dtp_fecha_del.Text = Me.dgv_listado_liquidaciones.Item(5, nRow).Value.ToString
            Me.dtp_fecha_al.Text = Me.dgv_listado_liquidaciones.Item(6, nRow).Value.ToString
            Me.cmb_ruta.Text = Me.dgv_listado_liquidaciones.Item(7, nRow).Value.ToString
            If Me.dgv_listado_liquidaciones.Item(8, nRow).Value.ToString = True Then
                Me.rb_si.Checked = True
            Else
                Me.rb_no.Checked = True

            End If
            Me.txt_km_inicial.Text = Me.dgv_listado_liquidaciones.Item(9, nRow).Value.ToString
            Me.txt_km_final.Text = Me.dgv_listado_liquidaciones.Item(10, nRow).Value.ToString
            Me.txt_carga_combustible.Text = Me.dgv_listado_liquidaciones.Item(11, nRow).Value.ToString
            Me.StatusBarPanel1.Text = "Usuario Grabo: " & Me.dgv_listado_liquidaciones.Item(12, nRow).Value.ToString
            Me.StatusBarPanel2.Text = "Fecha Grabo: " & Me.dgv_listado_liquidaciones.Item(13, nRow).Value.ToString

            txt_km_total.Text = Val(txt_km_final.Text) - Val(txt_km_inicial.Text)
            btn_guardar.Text = "Update"
            btn_Agrega.Visible = True
            deshabilitar_campos()

            '***********************************************
            llenar_detalle()
            Me.Maquillar_Grid()
            '***********************************************

            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If Me.lbl_numero.Text <> "" Then
            Imprimir_liquidacion()
        End If

    End Sub

    Private Sub txt_carga_combustible_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_carga_combustible.KeyPress
        Me.totalizar(ods.Tables("liquidacion"))
    End Sub

    Private Sub txt_carga_combustible_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_carga_combustible.LostFocus
        Try
            Me.txt_carga_combustible.Text = Double.Parse(Me.txt_carga_combustible.Text)

        Catch ex As Exception
            Me.txt_carga_combustible.Text = 0
        End Try
        Me.totalizar(ods.Tables("liquidacion"))

    End Sub




    Private Sub lbl_otros_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_otros.TextChanged
        Me.lbl_otros.Text = Format(Convert.ToDecimal(Me.lbl_otros.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub dtp_fecha_docto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_fecha_docto.TextChanged
        'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value
        'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value

        'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value
        'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value

        '  Me.dtp_fecha_docto.Value = Me.dtp_fecha_docto.MinDate

    End Sub

    Private Sub txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto.TextChanged
        Me.txt_monto.Text = Format(Convert.ToDecimal(Me.txt_monto.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub txt_peso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_peso.TextChanged
        Me.txt_peso.Text = Format(Convert.ToDecimal(Me.txt_peso.Text), "###,###,##0.00").ToString
    End Sub


    Private Sub txt_buscar1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress
        If e.KeyChar = Chr(13) Then


            crear_estructura_guias()

            If conectar = String.Empty Then
                hacer_busqueda_vista()
            Else
                hacer_busqueda_vista(conectar)
            End If
            ' Else
            '    hacer_busqueda_sp()

        End If
    End Sub

    Private Sub hacer_busqueda_vista(Optional ByVal conexion As String = "flexline")
        Dim ls_parametros As String
        Dim oTransaccion As Transaccional.Conexion
        Dim ls_Script As String
        Dim clsgen As New ClasesGenerales.General

        Dim tipo As String


        ls_parametros = ""
        ps_parametros_fijos = "cod_liquidacion,correlativo,piloto,ayudante,ayudante2,fecha as Fecha_Del," & _
                        "fechavcto as Fecha_Al,ruta,guardia,km_inicial,km_final,cantidad_combustible as carga,usuario_grabo,fecha_grabo"

        tipo = Me.cmb_valor1.Text
        lista_campos = "*"
        ps_nombre_vista = "liquidacionpiloto"

        If Me.txt_buscar1.Text.Length > 0 Then
            ls_parametros = ls_parametros & " " & tipo & " " & _
                            Me.cmb_1.Text & " '" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "'"



            oTransaccion = New Transaccional.Conexion(conexion)
            oTransaccion.open()
            ls_Script = "Select " & ps_parametros_fijos & "  From liquidacionpiloto Where " & " (" & ls_parametros & ")"

            Try
                dt = oTransaccion.Obtiene(ls_Script)
                Me.dgv_listado_liquidaciones.DataSource = dt
                clsgen.Alinear_GridView(dt, Me.dgv_listado_liquidaciones, ",Cod_liquidacion,Correlativo,Piloto,Ayudante,Ayudante2,Fecha_Del,Fecha_Al,Ayudante,Ruta,Guardian,km_inicial,km_final,carga,usuario_grabo,fecha_grabo,", ",correlativo,Guardia,km_inicial,km_final,carga,usuario_grabo,fecha_grabo,", ",,", "", "", ",Codigo=100,Correlativo=75,Fecha_Del=100,Fecha_Al=100,Piloto=175,Ayudante=175,Ayudante2=175,", "", True, True, 200, 0)
            Catch ex As Exception
            Finally
            End Try
            oTransaccion.close()
            oTransaccion = Nothing
            clsgen = Nothing
        End If


    End Sub



    Private Sub btn_analisis8020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_analisis8020.Click
        'Dim oform As New frm_analisis_guias
        'oform.dt_recibe = dt_guias
        'oform.ShowDialog(Me)
        'oform.Dispose()
        'oform = Nothing
        crear_struct()
        Mostrar_registro()
        Me.TabControl1.SelectedTab = Me.TabPage3

    End Sub

    '''NUEVOS PARAMETROS
    Private Sub totalizar_(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, subtotal_monto, subtotal_monto2 As Double
        total = 0
        subtotal_monto = 0
        subtotal_monto2 = 0
        Try
            For Each dr In otabla.Rows
                Try
                    If dr.Item("monto").ToString.Length > 0 Then
                        subtotal_monto += dr.Item("monto")
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each dr In otabla.Rows
                Try
                    If dr.Item("monto").ToString.Length > 0 Then
                        subtotal_monto2 = dr.Item("monto")
                        total += (subtotal_monto2 / subtotal_monto) * 100
                        If total <= 80.99 Then
                            dr.Item("peso") = 1
                        Else
                            dr.Item("peso") = 0
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        Finally
        End Try
    End Sub
    Private Sub crear_struct()
        Dim dt As DataTable
        ds_guia = New DataSet
        dt = New DataTable("detalle_guia")
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("municipio", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        ds_guia.Tables.Add(dt)
        Me.dgv_8020.DataSource = ds_guia.Tables("detalle_guia")
    End Sub



    Private Sub Mostrar_registro()
        Dim ls_sql, sql, concatena As String
        Dim dt, dt2, dt3 As DataTable
        Dim dr, dr_aux, dr2 As DataRow
        Dim clsGen As New ClasesGenerales.General
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()


        Try
            ds_guia.Tables("detalle_guia").Rows.Clear()
            sql = "delete from liquidacionpilotoanalisis"
            otrans.Obtiene(sql)
            For i As Integer = 0 To Me.dt_guias.Rows.Count - 1
                ls_sql = "pa_sel_um_gen_control_transporte_detalle_temporalanalisis '" & dt_guias.Rows(i).Item("empresa").ToString & "','" & dt_guias.Rows(i).Item("numero").ToString & "',1"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ls_sql = "pa_ins_um_liquidacionPilotoanalisis  '" & dr.Item("empresa") & "'," & dr.Item("total") & "," & dr.Item("peso") & ",'" & dr.Item("ctacte") & "'"
                    otrans.Ingresa(ls_sql)
                Next
            Next

            ls_sql = "select sum(a.total)as total,a.ctacte from liquidacionpilotoanalisis a group by a.ctacte order by a.total desc"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ls_sql = "select top 1  case " & _
                         "when ltrim(razonSocial) <> 'OPERADORA DE TIENDAS, S.A.' then  " & _
                         "  razonSocial  " & _
                         "  else " & _
                         "   giro " & _
                         " end  as nombre_cliente,direccionenvio,comuna from ctacte where tipoctacte='CLIENTE' and empresa<>'DEMO' and ctacte='" & dr.Item("ctacte") & "'"
                dt2 = otrans.Obtiene(ls_sql)

                ls_sql = "select empresa,ctacte from liquidacionpilotoanalisis where  ctacte='" & dr.Item("ctacte") & "' group by empresa,ctacte"
                dt3 = otrans.Obtiene(ls_sql)
                concatena = ""

                For Each dr2 In dt3.Rows
                    concatena = dr2.Item("empresa") & "  " & concatena
                Next
                dr_aux = ds_guia.Tables("detalle_guia").NewRow
                dr_aux.Item("empresa") = concatena
                dr_aux.Item("nombre") = dt2.Rows(0).Item("nombre_cliente")
                dr_aux.Item("direccion") = dt2.Rows(0).Item("direccionenvio")
                dr_aux.Item("municipio") = dt2.Rows(0).Item("comuna")
                dr_aux.Item("monto") = dr.Item("total")
                dr_aux.Item("peso") = 0
                ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
            Next
            clsGen.Alinear_GridView(ds_guia.Tables("detalle_guia"), Me.dgv_8020, ",empresa,nombre,direccion,municipio,monto,peso,", ",numero,tipodocto,comentario_factura,peso,", "", "", "", ",nombre=275,direccion=275,monto=75,", "", True, True, 200, 0)
            Me.totalizar_(ds_guia.Tables("detalle_guia"))

            For Each Row As DataGridViewRow In Me.dgv_8020.Rows 'oform.dgv_resultado.Rows
                If Row.Cells("peso").Value = 1 Then
                    Row.DefaultCellStyle.ForeColor = Color.DarkRed
                Else
                    Row.DefaultCellStyle.ForeColor = Color.DarkBlue
                End If
            Next




            '/*/*/*/*/*/*/*/*
            'Dim oform As New frm_resultado

            'oform.Refresh()

            'oform.dgv_resultado.DataSource = ds_guia.Tables("detalle_guia")
            'oform.Text = "::Analisis 80/20 "

            'For Each Row As DataGridViewRow In oform.dgv_resultado.Rows
            '    If Row.Cells("peso").Value = 1 Then
            '        Row.DefaultCellStyle.ForeColor = Color.DarkRed
            '        'oform.Refresh()
            '    Else
            '        Row.DefaultCellStyle.ForeColor = Color.DarkBlue
            '        'oform.Refresh()
            '    End If
            'Next

            'oform.Refresh()

            'clsGen.Alinear_GridView(ds_guia.Tables("detalle_guia"), oform.dgv_resultado, "", ",peso,", "", "", "", "", "", True, True, 200, 0)
            'oform.Refresh()
            'oform.ShowDialog(Me)
            'oform.Dispose()
            'oform = Nothing
            '/*/*/*/*/*/*/*
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    '' FIN DE NUEVOS PARAMETROS


    Private Sub txt_valor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.TextChanged

    End Sub

    Private Sub dtp_fecha_docto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_docto.ValueChanged
        'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value
        'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value
    End Sub

    Private Sub dtp_fecha_del_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_del.ValueChanged
        Try
            'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value
            'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtp_fecha_al_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_al.ValueChanged
        Try
            'Me.dtp_fecha_docto.MinDate = Me.dtp_fecha_del.Value
            'Me.dtp_fecha_docto.MaxDate = Me.dtp_fecha_al.Value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_Agrega_Click(sender As Object, e As EventArgs) Handles btn_Agrega.Click
        ' MsgBox("Agregar linea")
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()

            ls_sql = "pa_ins_um_liquidacionPilotoD  " & numero_liquidacion & ",'" & _
           txt_nit.Text & "','" & dtp_fecha_docto.Text & "','2','0'," & "'" & _
            cmb_tipo_documento.Text & "','" & txt_valor.Text & "'"
            Otrans.Ingresa(ls_sql)
            limpiar()
        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    'Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter

    'End Sub

    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            If txt_numero.Text = "" Or txt_numero.Text.Length = 0 Then
                Exit Sub
            Else

                busca_Datos_Sat()
            End If

        End If
    End Sub
    Private Sub busca_Datos_Sat()
        'clsGen.selectQuery("RegionalDBintOut", lsSQL)
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("RegionalDBintOut")

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_numero_compra 'LOGISERV','" & txt_numero.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("tipoDTE").ToString = "FPEQ" Then
                    cmb_TipoDocto.Text = "FACT PEQUEÑO CONTRI"
                    cmb_claseIva.Text = "Exento"
                Else
                    cmb_TipoDocto.Text = cmb_TipoDocto.Text
                End If


                ' MsgBox("hay informacion")
                txt_numero.Text = dt.Rows(0).Item("Numero")
                    txt_serieSat.Text = dt.Rows(0).Item("Serie")
                    dtp_fecha_docto.Text = dt.Rows(0).Item("Fecha")
                    txt_nit.Text = dt.Rows(0).Item("NitEmisor")
                    txt_valor.Text = dt.Rows(0).Item("Total")
                    txt_proveedor.Text = dt.Rows(0).Item("RazonEmisor")
                    cmb_tipo_documento.Text = dt.Rows(0).Item("TipoGasto")
                    cmb_combustible.Text = dt.Rows(0).Item("TipoGasolina")
                txt_galones.Text = dt.Rows(0).Item("CantidadCombustible")
                txt_exento.Text = dt.Rows(0).Item("ImpuestoTurismo") + dt.Rows(0).Item("MontoImpuestoIDP")



                If dt.Rows(0).Item("TipoGasto").ToString <> "COMBUSTIBLE" Then
                    cmb_combustible.Text = "NO"
                    txt_galones.Text = "0"
                    cmb_TipoDocto.Text = cmb_TipoDocto.Text
                    cmb_tipo_documento.Text = "Comida"

                ElseIf dt.Rows(0).Item("TipoGasto").ToString = "COMBUSTIBLE" Then

                    cmb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR"

                End If


                Busca_Numero_Existe()

                    cmb_tipo_documento.Focus()
                Else
                    MsgBox("Documento no Existe, Favor de validar", MsgBoxStyle.Information, "Validar")
                Exit Sub

            End If

        Catch ex As Exception

        End Try


    End Sub


    Private Sub Busca_Numero_Existe()
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_busca_fel_existe_caja_chica 'LOGISERV','" & txt_numero.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                'MsgBox("El Numero Ingresado ya existe en el lote " & dt.Rows(0).Item("lote") & ", Tipo Documento " & dt.Rows(0).Item("TipoDocto") & ", Numero: " & dt.Rows(0).Item("numero"))
                MessageBox.Show("El Numero Ingresado ya existe en el lote " & dt.Rows(0).Item("lote") & ", Tipo Documento " & dt.Rows(0).Item("TipoDocto") & ", Numero: " & dt.Rows(0).Item("numero"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

                txt_numero.Focus()
                Exit Sub

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmb_tipo_documento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_tipo_documento.SelectedValueChanged

        If cmb_tipo_documento.Text = "Parqueo" Then
            txt_producto.Text = "1031015"
            txt_item.Text = "1031015"
            cmb_claseIva.Text = "Servicio"

        ElseIf cmb_tipo_documento.Text = "Hospedaje" Then
            txt_producto.Text = "1031011"
            txt_item.Text = "1031011"
            cmb_claseIva.Text = "Servicio"

        ElseIf cmb_tipo_documento.Text = "Comida" And cmb_tipo_documento.Text <> "FACT PEQUEÑO CONTRI" Then
            txt_producto.Text = "1031012"
            txt_item.Text = "1031012"
            cmb_claseIva.Text = "Compra"
            cmb_TipoDocto.Text = "CAJAS CHICAS"

        ElseIf cmb_tipo_documento.Text = "Combustible" Then
            txt_producto.Text = "1031014"
            txt_item.Text = "1031014"
            cmb_claseIva.Text = "Compra"

        ElseIf cmb_tipo_documento.Text = "Taxi" Then
            txt_producto.Text = "1031017"
            txt_item.Text = "1031017"
            cmb_claseIva.Text = "Servicio"

        ElseIf cmb_tipo_documento.Text = "Peaje" Then
            txt_producto.Text = "1031013"
            txt_item.Text = "1031013"
            cmb_claseIva.Text = "Servicio"

        ElseIf cmb_tipo_documento.Text = "Gtos_Trans" And cmb_tipo_documento.Text <> "FACT PEQUEÑO CONTRI" Then
            txt_producto.Text = "1031016"
            txt_item.Text = "1031016"
            cmb_claseIva.Text = "Compra"

        ElseIf cmb_tipo_documento.Text = "Gtos_Trans" And cmb_tipo_documento.Text = "FACT PEQUEÑO CONTRI" Then
            txt_producto.Text = "1031016"
            txt_item.Text = "1031016"
            cmb_claseIva.Text = "Exento"

        ElseIf cmb_tipo_documento.Text = "Comida" And cmb_tipo_documento.Text = "FACT PEQUEÑO CONTRI" Then
            txt_producto.Text = "1031012"
            txt_item.Text = "1031012"
            cmb_claseIva.Text = "Exento"


        Else
            txt_producto.Text = ""
            txt_item.Text = ""
        End If


    End Sub



    Private Sub cmb_tipo_documento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_tipo_documento.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_valor.Focus()
        End If
    End Sub

    Private Sub cmb_TipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_TipoDocto.SelectedValueChanged

        If cmb_TipoDocto.Text = "FACT PEQUEÑO CONTRI" Or cmb_TipoDocto.Text = "FACTURAS EXENTAS" Then
            cmb_claseIva.Text = "Exento"
        ElseIf cmb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" Or cmb_TipoDocto.Text = "CAJA CHICA" Then
            cmb_claseIva.Text = "Compra"

        End If
    End Sub

    Private Sub txt_valor_TabIndexChanged(sender As Object, e As EventArgs) Handles txt_valor.TabIndexChanged

    End Sub
End Class