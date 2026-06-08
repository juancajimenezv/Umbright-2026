Imports System.IO
Public Class frmMonitorImpresiones_cedi
    Dim oDataSet As New DataSet
    Dim ods_Listado As New DataSet
    Dim odsCobro As New DataSet
    Dim odsFace As New DataSet
    Dim linea As Integer
    Dim formaPago As String


    Private Sub crear_estructuraFACE()
        Dim dt As DataTable

        odsFace = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFEL", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("forma_Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("PorcDescuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(String)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("exento", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_Pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_PedidoWM", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaEnvioFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("FechaRecepcionFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ComentarioFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas
        dt.Columns.Add(New DataColumn("Comuna", GetType(String))) '(c)230315 Campo para informacion walmart 
        dt.Columns.Add(New DataColumn("Estado", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("picking", GetType(String))) '(c)230315 Campo para informacion walmart


        odsFace.Tables.Add(dt.Copy)

        dt.TableName = "nce"
        odsFace.Tables.Add(dt.Copy)
        Me.dgv_pedidosFACE.DataSource = odsFace.Tables("pedidos")


        dt = New DataTable("detalle_traslado")

        'dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_docto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        'dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("comentario_factura", GetType(String)))
        'dt.Columns.Add(New DataColumn("distancia", GetType(Integer)))

        odsFace.Tables.Add(dt.Copy)


    End Sub


    Private Sub Estructura_Cobros()
        Dim dt As DataTable

        odsCobro = New DataSet
        dt = New DataTable("cobros")

        dt.Columns.Add(New DataColumn("LineaCobro", GetType(Integer)))
        dt.Columns.Add(New DataColumn("TipoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("MontoCobro", GetType(Double)))
        dt.Columns.Add(New DataColumn("NumeroCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("BancoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("ChequeCobro", GetType(String)))

        odsCobro.Tables.Add(dt.Copy)

        dt.TableName = "dc"
        odsCobro.Tables.Add(dt.Copy)
        'Me.dgv_Detalle.DataSource = odsCobro.Tables("cobros")

    End Sub

    Private Sub enviosPendientesFEL()

        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        odsFace.Tables("pedidos").Rows.Clear()


        ''Debo hacer un recorrido por cliente

        'ls_sqltxt = "pa_sel_um_tipodocumento_FELPuraAG null,'" & Me.dtp_fel_inicio.Text & "','" & Me.dtp_fel_final.Text & "'"
        ls_sqltxt = "pa_sel_um_tipodocumento_FelPura_Cedis '" & gs_empresa & "','" & Me.dtp_fel_inicio.Text & "','" & Me.dtp_fel_final.Text & "','" & gs_usuario & "'"


        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)



            oTabla.DefaultView.RowFilter = "documento like 'factura'"



            For Each dr In oTabla.Rows


                dr_aux = odsFace.Tables("pedidos").NewRow

                    dr_aux.Item("Enviar") = 0
                    dr_aux.Item("serie") = dr.Item("serie")
                    dr_aux.Item("documento") = dr.Item("documento")
                    dr_aux.Item("empresa") = dr.Item("empresa")
                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                    dr_aux.Item("correlativo") = dr.Item("correlativo")
                    dr_aux.Item("numero") = dr.Item("numero")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("codlegal") = dr.Item("codlegal")
                    dr_aux.Item("ctacte") = dr.Item("ctacte")
                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                    dr_aux.Item("direccion") = dr.Item("direccion")
                    dr_aux.Item("telefono") = dr.Item("telefono")
                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
                    dr_aux.Item("vigencia") = dr.Item("vigencia")
                    dr_aux.Item("exento") = dr.Item("exento")
                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
                    dr_aux.Item("comentario") = dr.Item("comentario")
                    dr_aux.Item("Bodega") = dr.Item("bodega")
                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
                    'dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
                    'dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
                    'dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
                    dr_aux.Item("total") = dr.Item("total")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then


                        If dr.Item("FACE").ToString.Split(" ").Length = 2 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
                        ElseIf dr.Item("FACE").ToString.Split(" ").Length = 3 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0) + " " +
                                dr.Item("FACE").ToString.Split(" ")(1)
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(2)

                            '+ " " +                                dr.Item("FACE").ToString.Split(" ")(2)


                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(2)
                        ElseIf dr.Item("FACE").ToString.Split(" ").Length = 4 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0) + " " + dr.Item("FACE").ToString.Split(" ")(1) + " " + dr.Item("FACE").ToString.Split(" ")(2)
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(3)
                        End If


                    End If
                    Catch ex As Exception

                    End Try

                    Try

                        dr_aux.Item("FechaEnvioFACE") = dr.Item("FechaEnvio")
                        dr_aux.Item("FechaRecepcionFACE") = dr.Item("FechaRecepcion")
                        dr_aux.Item("ComentarioFACE") = dr.Item("ComentarioFACE")
                    Catch ex As Exception

                    End Try

                    Try

                        dr_aux.Item("ImpresoraFace") = dr.Item("Impresora")
                        dr_aux.Item("BodegaInterEmpresas") = dr.Item("bodegaFacturar")
                        dr_aux.Item("comuna") = dr.Item("comuna")
                        dr_aux.Item("estado") = dr.Item("estado")

                        'dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
                        'dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas

                    Catch ex As Exception

                    End Try

                    Try
                        dr_aux.Item("numeroFEL") = dr.Item("numeroFEL")
                    Catch ex As Exception

                    End Try

                    Try
                        dr_aux.Item("picking") = dr.Item("picking")
                    Catch ex As Exception

                    End Try

                    odsFace.Tables("pedidos").Rows.Add(dr_aux)




            Next
            'Me.txtDocumentosFel.Text = odsFace.Tables("pedidos").Rows.Count


            Me.dgv_pedidosFACE.DataSource = odsFace.Tables("pedidos")

            Dim lsColumnasMostrar As String = ",empresa,forma_pago,bodega,exento,vigencia,direccion,tipodocto,numero,vendedor,enviar,fecha,codlegal,nombre_cliente,PorcDescuentoE,BodegaInterEmpresas,numeroFace,serieface,"
            Dim lsColumnasOcultar As String = ",serie,firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,"
            clGen.Alinear_GridView(odsFace.Tables("pedidos"), dgv_pedidosFACE,
                                   lsColumnasMostrar, lsColumnasOcultar, ",serie,documento,empresa,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,", "", ",serieface=serie,numeroface=numero,", ",PorcDescuento=30,vigencia=15,exento=15,", "", True, True, 150, 0)

            '            ls_sqltxt = "pa_var_um_detalle_felPURA '" & Me.dtp_fel_inicio.Text & "','" & Me.dtp_fel_final.Text & "','" & gs_empresa & "'"
            '           oTabla = oTrans.Obtiene(ls_sqltxt)
            '          oTabla.TableName = "detalle_pedidos"

            'odsFace.Tables.Add(oTabla.Copy)
            'Me.dgv_detalle_fel.DataSource = odsFace.Tables("detalle_pedidos")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try


        Try
            'detalle_pedidoFEL(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub imprimirFEL()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Dim lsSQL As String
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtp_fel_inicio.Value.ToString("yyyyMM") & "\" & Me.dtp_fel_inicio.Value.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            odsFace.Tables("pedidos").DefaultView.RowFilter = "enviar = True"

            For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView
                ppath_reporte = clsGen.Path_Reporte
                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                ppath_reporte += drv.Item("empresa").ToString.ToLower.Trim + " "
                ppath_reporte += drv.Item("tipodocto").ToString.Trim.Substring(7)
                ppath_reporte += ".rpt"

                pm_valores(0) = drv.Item("empresa").ToString
                pm_valores(1) = drv.Item("serieFACE").ToString
                pm_valores(2) = drv.Item("numeroFACE").ToString
                pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo

                formaPago = drv.Item("forma_Pago").ToString

                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", False, "", True, Me.nupCopias.Value)

                'llenar Linea de Impresion
                Try
                    If Not drv.Item("picking").ToString.ToLower = "c" Then

                        lsSQL = "pa_ins_um_gen_log_documento  '" &
                                                           drv.Item("empresa").ToString & "','" & drv.Item("tipodocto") &
                                                           "','" & drv.Item("numero") & "','" & gs_usuario & "','C', NULL"

                        clsGen.insertQuery("FlexLine", lsSQL)
                    End If
                Catch ex As Exception

                End Try

                Try
                    '(c) 20241710 Control de Impresiones
                    lsSQL = "pa_ins_um_gen_log_documento_impresion '" & drv.Item("empresa") & "','" & drv.Item("serieFACE").ToString & "','" & drv.Item("numeroFACE").ToString & "','" & gs_usuario & "','" & gs_nombre_equipo & "','frm_MonitorImpresionesAG'," & Me.nupCopias.Value
                    clsGen.insertQuery("FlexLine", lsSQL)
                Catch ex As Exception

                End Try




            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub ReimprimirRecibos()
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Try

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("SCM")
            Dim ppath_reporte As String = clsGen.Path_Reporte

            odsFace.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView


                If Not drv.Item("forma_Pago").ToString.ToLower.StartsWith("credit") Then


                    ppath_reporte = clsGen.Path_Reporte
                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

                    Dim pm_parametros2(2) As String
                    Dim pm_valores2(2) As String


                    pm_parametros2(0) = "Empresa"
                    pm_parametros2(1) = "Tipodocto"
                    pm_parametros2(2) = "Numero"


                    pm_valores2(0) = drv.Item("empresa").ToString
                    pm_valores2(1) = drv.Item("serieFACE").ToString
                    pm_valores2(2) = drv.Item("numeroFACE").ToString


                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        False, True, "PDF", True, "", True, Me.nupCopias.Value, drv.Item("empresa"), "Star TSP100 Cutter (TSP143),USB010")
                End If
            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub ImpresionRecibos()
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value

        Try
            odsFace.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView



                frm_Impresion_Factura.Emp = drv.Item("empresa").ToString
                frm_Impresion_Factura.TipDoc = drv.Item("serieFACE").ToString
                frm_Impresion_Factura.Num = drv.Item("numeroFACE").ToString
                frm_Impresion_Factura.Salida = "Impresora"
                frm_Impresion_Factura.ShowDialog()
                frm_Impresion_Factura = Nothing

            Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try


        'frm_Impresion_Factura.TipDoc = "FEL"

    End Sub

    Private Sub Buscar_Factura()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dr, dr_aux As DataRow

        otrans.open()

        Try


            ''Es Otro Tipo de Documento diferente a Devolucion
            Me.txt_e_numero.Text = Me.txt_e_numero.Text.PadLeft(10, "0")
            ls_sql = "pa_var_um_documento_control_transporte '" & Me.cmb_e_empresa.SelectedValue & "','" &
                                Me.cmb_e_tipodocto.Text & "','" & Me.txt_e_numero.Text & "'"

            dt = otrans.Obtiene(ls_sql)

            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error)
            Else
                If dt.Rows.Count > 0 Then
                    'If dt.Rows(0).Item("porcentajeAsignado") > 0 Or
                    '        dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0 Then
                    '    MessageBox.Show("Factura Asignada En Otro Control " &
                    '        IIf(dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0, " Temporal No. " & dt.Rows(0).Item("numero_temporal").ToString, " "),
                    '        "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'Else
                    'Verificar Picker


                    dr = dt.Rows(0)


                        ''(c) 20160606 Validar que no sea Interempresas
                        '' then 'CD_CENTRAL'
                        ''  then 'CD_TELEMERCADEO'
                        ') then 'WINE_SOCIETY'

                        Me.dtp_Fecha.Text = dr.Item("fecha")
                        Me.txt_e_razonSocial.Text = dr.Item("nombre_cliente")
                        Me.txt_e_monto.Text = dr.Item("total")
                        Me.txt_e_comentario.Text = dr.Item("comentario1")

                    'txt_e_montoCobro.Text = txt_e_monto.Text
                    'lb_Pendiente.Text = txt_e_monto.Text

                    'dr_aux = ds_guia.Tables("detalle_guia").NewRow
                    '        dr_aux.Item("tipo_docto") = dr.Item("tipodocto")
                    '        dr_aux.Item("numero") = dr.Item("numero")
                    '        dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                    '        dr_aux.Item("monto") = dr.Item("total")
                    '        dr_aux.Item("peso") = dr.Item("peso")
                    '        dr_aux.Item("picker") = dr.Item("picker")
                    '        dr_aux.Item("comentario_factura") = dr.Item("comentario1")

                    '        End Try

                    '        dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                    '        ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
                    '        Colorear_Grid()
                    '        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                    '        Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                    '    Else
                    '        MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    End If
                    'End If
                Else
                    MessageBox.Show("Documento No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If 'codigo_error

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.txt_e_numero.Focus()
            Me.txt_e_numero.SelectAll()

        End Try

    End Sub

    Private Sub llenarEmpresas()

        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSql As String

        Try
            lsSql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSql)
            dt.TableName = "empresa"
            Me.cmb_e_empresa.DisplayMember = "descripcion"
            Me.cmb_e_empresa.ValueMember = "descripcion"
            Me.cmb_e_empresa.DataSource = dt

            lsSql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSql)
            dt.TableName = "empresa2"
            'Me.cmb_e_empresa2.DisplayMember = "descripcion"
            'Me.cmb_e_empresa2.ValueMember = "descripcion"
            'Me.cmb_e_empresa2.DataSource = dt

            lsSql = "pa_var_um_tipodocto_AG "
            dt = clsGen.selectQuery("FlexLine", lsSql)
            Me.cmb_e_tipodocto.DisplayMember = "tipodocto"
            Me.cmb_e_tipodocto.ValueMember = "tipodocto"
            Me.cmb_e_tipodocto.DataSource = dt


            lsSql = "pa_vb_Recibos_Formas_Pago '" & gs_empresa & "'"

            dt = clsGen.selectQuery("SCM", lsSql)
            dt.TableName = "Formas"
            'Me.cb_FormasPago.DisplayMember = "Codigo"
            'Me.cb_FormasPago.ValueMember = "Codigo"
            'Me.cb_FormasPago.DataSource = dt


            'Dim otrans As New Transaccional.Conexion("FlexLine")
            'otrans.open()
            'clsGen.fillComboBox(oTrans, "pa_var_Configuracion_Concilicaciones", "Gen_Conciliaciones_Bancos", "tipo_banco", "tipo_banco", cmb_e_banco)
            'otrans.close()
            'otrans = Nothing
            lsSql = "pa_sel_um_gen_tabcod NULL,'ANALISISCTACTE23','UMBRAL'"
            dt = clsGen.selectQuery("FlexLine", lsSql)
            dt.TableName = "bco"
            'Me.cmb_e_banco.DisplayMember = "descripcion"
            'Me.cmb_e_banco.ValueMember = "descripcion"
            'Me.cmb_e_banco.DataSource = dt



            lsSql = "pa_var_um_destino_traslado_documentos"
            dt = clsGen.selectQuery("FlexLine", lsSql)
            Me.cmb_e_Destino.DataSource = dt
            Me.cmb_e_Destino.ValueMember = "Destino"
            Me.cmb_e_Destino.DisplayMember = "Destino"

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub frmMonitorImpresionesAG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        crear_estructuraFACE()
        txt_e_monto.Text = "0.00"
        'txt_e_montoCobro.Text = "0.00"
        llenarEmpresas()
        Estructura_Cobros()
        'btn_e_guardar.Enabled = False

    End Sub

    Private Sub btnObtenerNC_Click(sender As Object, e As EventArgs) Handles btnObtenerNC.Click
        crear_estructuraFACE()
        Me.dgv_pedidosFACE.DataSource = Nothing
        '  Me.dgvDetalleFACE.DataSource = Nothing
        enviosPendientesFEL()
    End Sub

    Private Sub btnReimpresionNC_Click(sender As Object, e As EventArgs) Handles btnReimpresionNC.Click
        imprimirFEL()
        Me.ReimprimirRecibos()
        'If Not formaPago.StartsWith("CREDITO") Then
        'ImpresionRecibos()
        'End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.ReimprimirRecibos()
    End Sub

    Private Sub txt_e_numero_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_e_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_e_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            Buscar_Factura()
            'cb_FormasPago.Focus()
            Me.btn_Agregar.Focus()
        End If
    End Sub



    Private Sub btn_creditos_obtener_Click(sender As Object, e As EventArgs)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try
            '    dt = clsGen.selectQuery("FlexLine", "pa_var_um_entregas_AG '" & Me.dtp_creditos_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_creditos_final.Value.ToString("dd/MM/yyyy") & "'")
            '    Me.dgv_creditos.DataSource = dt

            '    clsGen.Alinear_GridView(dt, dgv_creditos, "", ",correlativo,", "", "", True, True, 200, 0)
            'Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub guardarEntrega()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dr As DataRow

        Try
            Otrans.open()


            For Each dr In odsCobro.Tables("cobros").Rows

                lsSQL = "pa_ins_um_recibos_lote_acumula_temp '" & Me.cmb_e_empresa.SelectedValue & "','" & dr.Item("NumeroCobro") & "','" &
                    Me.cmb_e_tipodocto.SelectedValue & "','" & dtp_Fecha.Text & "','" & Me.txt_e_numero.Text & "','" & Format(CDbl(txt_e_monto.Text), "########0.00") & "','" &
                     dr.Item("LineaCobro") & "','" & dr.Item("TipoCobro") & "','" & dr.Item("MontoCobro") & "','" & dr.Item("BancoCobro") & "','" &
                     dr.Item("ChequeCobro") & "','" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

                'lsSQL = lsSQL & "," & Me.txt_e_montoCobro.Text

                'If Me.txt_e_cheque.Text.Length > 0 Then
                '    lsSQL = lsSQL + ",'" & Me.cmb_e_banco.SelectedValue & "','" & Me.txt_e_cheque.Text & "'"
                'Else
                '    lsSQL = lsSQL + ",'',''"
                'End If

                'lsSQL = lsSQL + ",'" & gs_usuario & "'"


            Next


            If Otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Almacenada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarForma()
            Else
                MessageBox.Show("Informacion Almacenada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub limpiarForma()
        'Me.txt_e_cheque.Text = String.Empty
        Me.txt_e_comentario.Text = String.Empty
        Me.txt_e_monto.Text = String.Empty
        Me.txt_e_razonSocial.Text = String.Empty
        'Me.txt_e_recibo.Text = String.Empty
        Me.txt_e_numero.Text = String.Empty
        'Me.txt_e_cheque.Text = String.Empty
        'Me.txt_e_montoCobro.Text = String.Empty
        'cb_FormasPago.SelectedIndex = -1
        'cmb_e_banco.SelectedIndex = -1
        btn_e_guardar.Enabled = False
        Estructura_Cobros()
        'lb_Total.Text = "0.00"
        linea = 0
        txt_e_numero.Focus()
    End Sub


    Private Sub btn_e_guardar_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            guardarEntrega()

        End If


    End Sub

    Private Sub dgv_pedidosFACE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidosFACE.CellContentClick

    End Sub

    Private Sub dgv_pedidosFACE_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_pedidosFACE.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        'Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                ' therow = Me.dgv_pedidosFACE.Rows(rowIndex)
                If Me.dgv_pedidosFACE.Item("picking", rowIndex).Value.ToString.ToLower.Equals("c") Then
                    Me.dgv_pedidosFACE.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCrediticiasReporte_Click(sender As Object, e As EventArgs)
        'Dim clsGen As New ClasesGenerales.General
        'Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(cmb_e_empresa2.Text)
        'Oaut.pnNumeroCopias = Me.nupCopias.Value
        'Try

        '    Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtp_fel_inicio.Value.ToString("yyyyMM") & "\" & Me.dtp_fel_inicio.Value.ToString("ddMMyyyy")


        '    If Not Directory.Exists(lsDirectorio) Then
        '        System.IO.Directory.CreateDirectory(lsDirectorio)
        '    End If

        '    Dim pm_valores(2), pm_valores_consolidado(2) As String
        '    Dim pm_parametros(2) As String
        '    Dim pm_conexion(3) As String

        '    pm_conexion = clsGen.Parametros_Conexion("")
        '    Dim ppath_reporte As String = clsGen.Path_Reporte
        '    '023:


        '    ' SE AGREGA PARAMETRO DE EMPRESA YA QUE LA LIQUIDACION DEBE SER POR EMPRESA
        '    '---------------------------------------------------------------------------

        '    pm_parametros(0) = "@empresa"
        '    pm_parametros(1) = "@fechai"
        '    pm_parametros(2) = "@fechaf"
        '    'pm_parametros(2) = "numero"
        '    'pm_parametros(3) = "user_name"



        '    ppath_reporte = clsGen.Path_Reporte
        '    ppath_reporte = ppath_reporte & "Finanzas\Creditos\Cuadre_AG"
        '    'ppath_reporte += drv.Item("empresa").ToString.ToLower.Trim + " "
        '    'ppath_reporte += drv.Item("serieFACE").ToString.Trim
        '    ppath_reporte += ".rpt"

        '    '  pm_valores(0) = cmb_e_empresa2.Text
        '    'pm_valores(1) = Me.dtp_creditos_inicio.Value.ToString("dd/MM/yyyy") & " 00:00:00"
        '    ' pm_valores(2) = Me.dtp_creditos_final.Value.ToString("dd/MM/yyyy") & " 00:00:00"
        '    'pm_valores(2) = drv.Item("numeroFACE").ToString
        '    ' pm_valores(3) = gs_usuario




        '    _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
        '            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
        '            False, False, "PDF", True, "", True, 1)




        'Catch ex As Exception
        '    MessageBox.Show("Problemas...", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Finally
        '    Oaut = Nothing
        '    clsGen = Nothing
        'End Try
    End Sub



    Private Sub valida_Montos()

        'If CDbl(txt_e_montoCobro.Text) <> CDbl(txt_e_monto.Text) Then
        '    MessageBox.Show("Cobro Diferente al Total del Documento, Revise el Cobro o si Posee Devoluciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txt_e_recibo.Focus()
        'End If


    End Sub

    'Private Sub txt_e_montoCobro_LostFocus(sender As Object, e As EventArgs) Handles txt_e_montoCobro.LostFocus
    '    valida_Montos()
    'End Sub

    Private Sub txt_e_montoCobro_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            '     valida_Montos()
            'txt_e_recibo.Focus()

        End If
    End Sub

    Private Sub txt_e_recibo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            'If txt_e_recibo.Text.Length = 0 Then
            '    txt_e_recibo.Focus()
            'Else
            '    cmb_e_banco.Focus()
            'End If
        End If
    End Sub

    Private Sub txt_e_cheque_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            btn_Agregar.Focus()
        End If
    End Sub

    Private Sub cb_FormasPago_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            'txt_e_montoCobro.Focus()
            'txt_e_montoCobro.SelectAll()
        End If
    End Sub

    Private Sub cmb_e_banco_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            'txt_e_cheque.Focus()
            'txt_e_cheque.SelectAll()
        End If
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs)
        Valida_Agregar()
    End Sub

    Private Sub Valida_Agregar()

        'If CDbl(txt_e_montoCobro.Text) < CDbl(txt_e_monto.Text) Then
        '    MessageBox.Show("Cobro es Diferente al Total del Documento, Revise el Cobro o Bien si Posee Devoluciones el Documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        'If txt_e_montoCobro.Text > lb_Pendiente.Text Then

        '    MessageBox.Show("El Monto del Cobro No debe ser Mayor al Saldo Pendiente Actual", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txt_e_montoCobro.Focus()
        '    txt_e_montoCobro.SelectAll()

        'Else
        '    Agregar_Cobro()
        '    If CDbl(txt_e_monto.Text) = CDbl(lb_Total.Text) Then
        '        btn_e_guardar.Enabled = True
        '    Else
        '        btn_e_guardar.Enabled = False
        '    End If
        'End If

    End Sub

    Private Sub Agregar_Cobro()
        Dim clsGen As New ClasesGenerales.General
        Dim rubro As String = ""
        Dim dr_aux As DataRow

        Try

            linea = linea + 1

            dr_aux = odsCobro.Tables("cobros").NewRow

            'dr_aux.Item("LineaCobro") = linea
            ' dr_aux.Item("TipoCobro") = Me.cb_FormasPago.Text
            ' dr_aux.Item("MontoCobro") = Me.txt_e_montoCobro.Text
            ' dr_aux.Item("NumeroCobro") = Me.txt_e_recibo.Text.Trim
            ' dr_aux.Item("BancoCobro") = Me.cmb_e_banco.Text.Trim
            'dr_aux.Item("ChequeCobro") = Me.txt_e_cheque.Text.Trim
            odsCobro.Tables("cobros").Rows.Add(dr_aux)

            'Me.dgv_Detalle.DataSource = odsCobro.Tables("cobros")
            Cuenta_Lineas()
            Total()

            'txt_e_montoCobro.Text = txt_e_monto.Text - lb_Total.Text
            'lb_Pendiente.Text = txt_e_monto.Text - lb_Total.Text


        Catch ex As Exception

        End Try


    End Sub

    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable


        Try

            'dt = Me.dgv_Detalle.DataSource

            If dt.Rows.Count > 0 Then

                ntotal = dt.Compute("sum(MontoCobro)", "MontoCobro>=0")
                '     Me.lb_Total.Text = Format(ntotal, "###,###,##0.00")

            Else
                ntotal = 0
                '    Me.lb_Total.Text = Format(ntotal, "###,###,##0.00")
            End If

            '  Me.lb_Pendiente.Text = txt_e_monto.Text - lb_Total.Text

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_Detalle_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs)
        Total()
        Cuenta_Lineas()
    End Sub

    Private Sub btn_e_nuevo_Click(sender As Object, e As EventArgs)
        Nuevo()
    End Sub

    Private Sub Nuevo()
        limpiarForma()
    End Sub


    Private Sub Cuenta_Lineas()
        'Dim n As Integer = 0

        'Try
        '    For Each row As DataGridViewRow In dgv_Detalle.Rows
        '        dgv_Detalle.Rows(n).Cells(0).Value = n + 1
        '        n += 1

        '    Next

        '    'If n = 1 Then
        '    '    Asigna_Correlativo()
        '    'End If

        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString())
        'End Try

    End Sub

    Private Sub mProcesosLiberar_Click(sender As Object, e As EventArgs) Handles mProcesosLiberar.Click
        'Dim forma As New frm_LiberarSalidasCd
        'forma.ShowDialog()
        'forma = Nothing
    End Sub

    Private Sub txt_e_numero_TextChanged_1(sender As Object, e As EventArgs) Handles txt_e_numero.TextChanged

    End Sub

    Private Sub txt_e_monto_TextChanged(sender As Object, e As EventArgs) Handles txt_e_monto.TextChanged
        txt_e_monto.Text = Format(Convert.ToDecimal(txt_e_monto.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub agregartraslado()
        Dim dr_aux, dr As DataRow
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General

        Try

            If Me.txt_e_razonSocial.Text.Length > 0 Then



                If Es_Unico("detalle_traslado", odsFace.Tables("detalle_traslado"), "numero", Me.txt_e_numero.Text) Then

                    'dr = dt.Rows(0)
                    dr_aux = odsFace.Tables("detalle_traslado").NewRow
                    dr_aux.Item("empresa") = Me.cmb_e_empresa.SelectedValue
                    dr_aux.Item("tipo_docto") = Me.cmb_e_tipodocto.SelectedValue
                    dr_aux.Item("numero") = Me.txt_e_numero.Text
                    dr_aux.Item("nombre") = Me.txt_e_razonSocial.Text
                    dr_aux.Item("monto") = Me.txt_e_monto.Text
                    'dr_aux.Item("peso") = 0 'dr.Item("peso")
                    'dr_aux.Item("picker") = "" 'dr.Item("picker")
                    dr_aux.Item("comentario_factura") = Me.txt_e_comentario.Text
                    'dr_aux.Item("distancia") = Me.txtDistancia.Text
                    'dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                    odsFace.Tables("detalle_traslado").Rows.Add(dr_aux)
                    'Colorear_Grid()
                    'Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                    'Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                    Me.dgvDetalleEnvios.DataSource = odsFace.Tables("detalle_traslado")
                    clsgen.Alinear_GridView(odsFace.Tables("detalle_traslado"), Me.dgvDetalleEnvios, "", "", "", "", True, True, 250, 0)
                    limpiarformaEnvio()
                    Me.txt_e_numero.Focus()
                Else
                    MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub limpiarformaEnvio()
        Me.txt_e_monto.Text = "0"
        Me.txt_e_comentario.Text = String.Empty
        Me.txt_e_razonSocial.Text = String.Empty
        Me.txt_e_numero.Text = String.Empty


    End Sub

    Private Sub btn_Agregar_Click_1(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        agregarTraslado
    End Sub

    Private Sub btn_e_guardar_Click_1(sender As Object, e As EventArgs) Handles btn_e_guardar.Click
        If Me.odsFace.Tables("detalle_traslado").Rows.Count > 0 Then


            If Me.txt_e_numero_envio.Text.ToString.Length = 0 Then
                If Me.cmb_e_Destino.SelectedValue.ToString.Trim.Length > 0 Then


                    If MessageBox.Show("Esta Seguro de Aplicar el Traslado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.txt_e_numero_envio.Text = Now.ToString("yyMMddHHmm")
                        almacenarTraslado()
                    End If
                Else
                    MessageBox.Show("Debe Seleccionar Destino", "Conformacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Traslado Ingresado Previamente", "Conformacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub imprimirtraslado(sNumeroTraslado As String)
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias.Value
        Try

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte

            'odsFace.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            'For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView
            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\traslada_documentos.rpt"

            Dim pm_parametros2(0) As String
            Dim pm_valores2(0) As String


            pm_parametros2(0) = "@Correlativo"


            pm_valores2(0) = sNumeroTraslado


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, 2)

            ' Next

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub almacenarTraslado()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")


        Try
            Otrans.open()

            For Each dr As DataRow In odsFace.Tables("detalle_traslado").Rows
                lsSQL = "pa_ins_gen_log_Traslada_documento '" & Me.cmb_e_Destino.SelectedValue.ToString & "','" & dr.Item("empresa").ToString & "','" &
                    dr.Item("tipo_docto").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "','" & Me.txt_e_numero_envio.Text & "'"

                Otrans.Ingresa(lsSQL)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show("Problemas al Insertar " & dr.Item("numero"), "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If



            Next
            Try
                Dim dt As DataTable
                dt = Otrans.Obtiene("pa_sel_gen_log_Traslada_documento '" & Me.txt_e_numero_envio.Text & "'")
                Me.txt_e_numero_envio.Text = dt.Rows(0).Item("Correlativo")

                imprimirtraslado(Me.txt_e_numero_envio.Text)
            Catch ex As Exception

            End Try



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub btn_e_nuevo_Click_1(sender As Object, e As EventArgs) Handles btn_e_nuevo.Click
        Me.txt_e_numero_envio.Text = String.Empty
        odsFace.Tables("detalle_traslado").Rows.Clear()
    End Sub

    Private Sub btnBuscarTraslados_Click(sender As Object, e As EventArgs) Handles btnBuscarTraslados.Click
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Try
            'buscar traslados
            'gs_usuario = "jcastillo"
            lsSQL = "pa_sel_um_gen_log_traslada_documento_usuario '" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            Me.dgv_listados_traslados.DataSource = dt
            clsGen.Alinear_GridView(dt, dgv_listados_traslados, "", "", "", "", False, True, 250, 0)





        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub btnImprimirTraslados_Click(sender As Object, e As EventArgs) Handles btnImprimirTraslados.Click


        Try
                    Dim nrow As Integer = Me.dgv_listados_traslados.CurrentRow.Index



            'Otrans.open()
            'lsSQL = "pa_upd_um_documento_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("numero", nrow).Value & "','" & _
            '            Me.txtComentario2.Text & "','" & gs_usuario & "'"
            'Otrans.Actualiza(lsSQL)

            ''Verificar Stock
            'If Me.dgv_encabezado.Item("empresa", nrow).Value = "VINOTECA

            imprimirtraslado(Me.dgv_listados_traslados.Item("correlativo", nrow).Value)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class