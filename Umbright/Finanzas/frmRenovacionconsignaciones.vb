Imports System.Math

Public Class frmRenovacionconsignaciones
    Dim ods As DataSet

    Private Sub crearEsctructura()
        Dim dt, dt2 As DataTable

        ods = New DataSet

        dt2 = New DataTable("Conteos_Pendientes")
        dt2.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("cod_empresa", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt2.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        dt2.Columns.Add(New DataColumn("Cod_Producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("nombre_producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("saldo_actual", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("conteo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("cantidad_facturar", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("cantidad_Consignar", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        'dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
        dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
        ' dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
        ' dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
        dt2.Columns.Add(New DataColumn("Usuario_Grabo", GetType(String)))
        ods.Tables.Add(dt2.Copy)

        dt2 = New DataTable("clientes_procesar")
        dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
        dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
        dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
        dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))

        ods.Tables.Add(dt2.Copy)

    End Sub

    Private Sub llenarSaldo()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_Sql As String
        Dim saldo_actual As Integer = 0
        Dim dr, dr_aux As DataRow

        ods.Tables("conteos_pendientes").Rows.Clear()

        Try
            otrans.open()
            ls_Sql = "pa_sel_um_consignaciones_saldos_cliente '" & Me.txtCodigoCliente.Text & "','" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_Sql)



            For Each dr In dt.Rows
                dr_aux = ods.Tables("Conteos_Pendientes").NewRow
                dr_aux.Item("cod_conteo") = Now.ToString("MMddHHmm")
                'dr_aux.Item("cod_empresa") = dr.Item("cod_empresa")
                dr_aux.Item("empresa") = dr.Item("con_empresa").ToString
                'dr_aux.Item("cod_cliente") = dr.Item("cod_cliente_flex")
                dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                dr_aux.Item("Razon_Social") = dr.Item("razonSocial")
                dr_aux.Item("cod_producto") = dr.Item("con_producto")
                dr_aux.Item("nombre_producto") = dr.Item("con_desc")
                dr_aux.Item("conteo") = 0
                dr_aux.Item("cantidad_aprobada") = 0
                dr_aux.Item("fecha") = Today
                dr_aux.Item("saldo_actual") = dr.Item("saldo") ' Obtener_Saldo_Consignacion_Actual(dr.Item("empresa").ToString, dr.Item("cod_producto_flex").ToString, dr.Item("cod_cliente_flex"))
                dr_aux.Item("cantidad_consignar") = 0 ' IIf(dr.Item("cantidad_maxima") Is System.DBNull.Value, 0, dr.Item("cantidad_maxima")) - dr.Item("conteo").ToString
                dr_aux.Item("cantidad_facturar") = IIf(dr_aux.Item("saldo_actual") Is System.DBNull.Value, 0, dr_aux.Item("saldo_actual")) - dr_aux.Item("conteo").ToString
                '       dr_aux.Item("Comentarios_reposicion") = "" ' dr.Item("Comentarios").ToString
                dr_aux.Item("Comentarios_factura") = "Consolidacion de Saldos " & Now.ToString("dd-MM-yyyy HH:mm") 'dr.Item("Comentarios_factura").ToString
                'dr_aux.Item("Direccion_entrega_reposicion") = ""
                'dr_aux.Item("Direccion_entrega_factura") = ""
                dr_aux.Item("Usuario_Grabo") = gs_usuario
                ods.Tables("Conteos_Pendientes").Rows.Add(dr_aux)

            Next

            Me.dgvProductos.DataSource = ods.Tables("conteos_pendientes")
            clsGen.Alinear_GridView(ods.Tables("Conteos_Pendientes"), Me.dgvProductos, "", ",cod_conteo,cantidad_aprobada,cantidad_consignar,", "", "", True, True, 150, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub


    Private Function Obtener_Cliente(ByVal _empresa As String, ByVal _codigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & _empresa & "','CLIENTE','" & _codigo & "'"
            dt = Otrans.Obtiene(ls_sql)
            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return dt

    End Function

    Private Function Obtener_Moneda(ByVal pempresa As String) As String
        Dim lsSQL As String
        Dim lsMoneda As String = String.Empty
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod 'MONEDA','CONFIG.EMPRESA','" & pempresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "flexline_configuracion"
            lsMoneda = dt.Rows(0)("Texto")
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Return lsMoneda

    End Function



    Private Sub Crear_Documento_Consignacion_Factura_Flex()

        Dim Oflex As New Umbral_Flex.Pedidos(True)
        Dim Oflex_Facturar As New Umbral_Flex.Pedidos(True)
        Dim Oflex_producto As New Umbral_Flex.productos
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim _dv As DataView
        Dim dr, dr2, drf As DataRow
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim li_secuencia As Integer = 0
        Dim li_secuenciaFactura As Integer = 0
        Dim ls_filtro As String = ""
        Dim dc As DataColumn


        _dv = ods.Tables("conteos_pendientes").DefaultView

        Dim lsMoneda As String = Obtener_Moneda(_dv(0).Item("empresa").ToString)

        Dim _cod_cliente As String = _dv(0).Item("cod_cliente").ToString
        Dim _comentario_factura As String = _dv(0).Item("comentarios_factura").ToString




        Try
            Otrans.open()

            Oflex.Consignaciones = True
            Oflex.Limpiar_Datos()
            Oflex.Validar_Totales = False

            Oflex_Facturar.Consignaciones = True
            Oflex_Facturar.Limpiar_Datos()
            Oflex_Facturar.Validar_Totales = True

            dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)



            'Ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "cod_cliente = '" & _cod_cliente & "'"
            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView



                If drv.Item("cantidad_facturar") > 0 Then

                    ''Genero El Detalle de la Solicitud de Facturacion
                    dt = Obtener_Consignacion_Facturar(_cod_cliente,
                                                    drv.Item("cod_producto"),
                                                    drv.Item("cantidad_facturar"), _dv(0).Item("empresa").ToString,
                                                    IIf(drv.Item("empresa").ToString = "DIVINOS", "NOTA DE REMISION", "CONSIGNACIONES"))

                    For Each drf In dt.Rows ' Ods.Tables("detalle_facturar").Rows


                        li_secuenciaFactura += 1
                        dr = Oflex_Facturar.ods.Tables("detalle").NewRow()

                        dr.Item("Empresa") = _dv(0).Item("empresa").ToString
                        dr.Item("TipoDocto") = "DEVOLUCION DE CONSIGNACIONES"
                        dr.Item("Correlativo") = 0
                        dr.Item("secuencia") = li_secuenciaFactura
                        dr.Item("Linea") = li_secuenciaFactura
                        dr.Item("producto") = drv.Item("cod_producto")

                        dr.Item("cantidad") = drf.Item("cantidad")  ''debo establecer cuanto se va a facturar

                        dt = Oflex_producto.Obtener_Precio_Final(_dv(0).Item("empresa").ToString, drv.Item("cod_producto").ToString, _cod_cliente)
                        Try
                            dr.Item("precio") = dt.Rows(0).Item("valor")
                            dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                        Catch ex As Exception
                            '(c) 20180430 Precios 
                            dr.Item("precio") = 0.01
                            dr.Item("FechaVigenciaLp") = "01/01/1900"
                        End Try

                        dr.Item("PorcentajeDr") = 0
                        dr.Item("SubTotal") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("Neto") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("Impuesto") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("DrGlobal") = 0

                        dt = Oflex_producto.Obtener_Producto(_dv(0).Item("empresa").ToString, drv.Item("cod_producto"))
                        Try
                            dr.Item("Costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                        Catch ex As Exception
                            dr.Item("Costo") = 0
                        End Try
                        dr.Item("total") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("PrecioAjustado") = Round(dr.Item("precio") / 1.12, 6)
                        dr.Item("UnidadIngreso") = "UN"

                        dr.Item("CantidadIngreso") = drf.Item("cantidad")

                        dr.Item("PrecioIngreso") = dr.Item("precio")
                        dr.Item("SubTotalIngreso") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("ImpuestoIngreso") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("NetoIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("DrGlobalIngreso") = 0
                        dr.Item("TotalIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)

                        dr.Item("TipoDoctoOrigen") = drf.Item("TipoDoctoOrigen").ToString
                        dr.Item("CorrelativoOrigen") = drf.Item("CorrelativoOrigen").ToString
                        dr.Item("SecuenciaOrigen") = drf.Item("SecuenciaOrigen").ToString

                        dr.Item("Bodega") = "CONSIGNACIONES"
                        dr.Item("FactorInventario") = 0
                        dr.Item("FechaEntrega") = Today
                        dr.Item("CantidadAsignada") = 0
                        dr.Item("fecha") = Today
                        dr.Item("Comentario") = ""
                        dr.Item("Vigente") = "S"
                        dr.Item("CUP") = dr.Item("Costo")
                        dr.Item("Ubicacion") = "PRINCIPAL"
                        dr.Item("Ubicacion2") = "PRINCIPAL"
                        dr.Item("Cuenta") = ""
                        dr.Item("FactorImpto") = Round(1 / 1.12, 6)
                        dr.Item("PrecioBimoneda") = dr.Item("precio")
                        dr.Item("SubTotalBimoneda") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("ImpuestoBimoneda") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("NetoBimoneda") = dr.Item("Neto")
                        dr.Item("DrGlobalBimoneda") = 0
                        dr.Item("TotalBimoneda") = dr.Item("Neto")
                        dr.Item("PrecioListaP") = dr.Item("Precio")
                        dr.Item("UniMedDynamic") = 0
                        dr.Item("LoteDestino") = ""
                        dr.Item("SerieDestino") = ""
                        dr.Item("ProdAlias") = ""
                        dr.Item("DoctoOrigenVal") = "N"
                        dr.Item("MontoAsignado") = 0
                        Oflex_Facturar.ods.Tables("detalle").Rows.Add(dr)
                    Next ''Facturacion
                End If


            Next
            ''Encabezado de Facturacion

            dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)
            dr = Oflex_Facturar.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "DEVOLUCION DE CONSIGNACIONES"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = _cod_cliente
            dr.Item("Bodega") = "CONSIGNACIONES"
            dr.Item("Bodega2") = "TRA_CONSIGNACIONES"
            dr.Item("vendedor") = dt.Rows(0).Item("Ejecutivo").ToString
            dr.Item("FechaVcto") = Today '"Pendiente Establecer"
            dr.Item("listaprecio") = dt.Rows(0).Item("ListaPrecio").ToString
            dr.Item("Moneda") = lsMoneda
            dr.Item("Paridad") = 1
            dr.Item("Neto") = 0
            dr.Item("SubTotal") = 0
            dr.Item("Total") = 0
            dr.Item("NetoIngreso") = 0
            dr.Item("SubTotalIngreso") = 0
            dr.Item("TotalIngreso") = 0
            dr.Item("aprobacion") = "P" 'Creditos lo debe regrabar para aprobar el traslado
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = _cod_cliente
            dr.Item("Glosa") = ""
            dr.Item("comentario1") = "PDA- CON " & _comentario_factura
            dr.Item("direccion") = ""
            dr.Item("Vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("FechaModif") = Now
            dr.Item("FechaUModif") = Now
            dr.Item("UsuarioModif") = _dv(0).Item("usuario_grabo").ToString
            dr.Item("Hora") = Now.ToString("HH:mm:ss")
            dr.Item("NetoBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("ParidadBimoneda") = 1
            dr.Item("AnalisisE3") = "30/12/1899"
            dr.Item("AnalisisE7") = ""
            Oflex_Facturar.ods.Tables("encabezado").Rows.Add(dr)





            Try

                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("neto") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(neto)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotal") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotal)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("Total") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotal") 'Round(Oflex.ods.Tables("detalle").Compute("sum(Total)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(NetoIngreso)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotalIngreso)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") ''Round(Oflex.ods.Tables("detalle").Compute("sum(TotalIngreso)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("NetoBimoneda") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(NetoBimoneda)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotalBimoneda)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("TotalBimoneda") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") 'Round(Oflex.ods.Tables("detalle").Compute("sum(TotalBimoneda)", ls_filtro), 2)
            Catch ex As Exception

            End Try


            ''(c) Debo Identificar a que consignaciones se va a rebajar el total
            ls_filtro = ""

            If False Then
                Oflex_Facturar.Guardar_Documento()
            End If


        Catch ex As Exception
        Finally
            myOtrans = Nothing
            Oflex = Nothing
            Oflex_Facturar = Nothing

        End Try

    End Sub



    Private Function Obtener_Consignacion_Facturar(ByVal _cod_cliente As String,
                                                     ByVal _cod_producto As String,
                                                     ByVal _cantidad As Integer,
                                                     ByVal _empresa As String, ByVal ptipoDocto As String) As DataTable
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dt3 As DataTable
        Dim dr As DataRow
        Dim drv, drv2 As DataRowView
        Dim ls_sql As String
        ' Dim ls_consignaciones5 As String = ""
        Dim nueva_cantidad As Integer = _cantidad
        Dim cantidad_asignada As Integer = 0

        dt3 = New DataTable("detalle_facturar")
        dt3.Columns.Add(New DataColumn("cod_Producto", GetType(String)))
        dt3.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt3.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt3.Columns.Add(New DataColumn("CorrelativoOrigen", GetType(Integer)))
        dt3.Columns.Add(New DataColumn("SecuenciaOrigen", GetType(Integer)))
        'Ods.Tables("detalle_facturar").Rows.Clear()

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_consignaciones_saldos NULL,'" & _empresa & "','" & _cod_cliente & "','" & _cod_producto & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "Saldo > 0"
            For Each drv In dt.DefaultView
                If drv.Item("saldo") < nueva_cantidad Then
                    cantidad_asignada = drv.Item("saldo")
                    nueva_cantidad = nueva_cantidad - drv.Item("saldo")
                Else
                    cantidad_asignada = nueva_cantidad
                    nueva_cantidad = nueva_cantidad - drv.Item("saldo")
                End If
                If nueva_cantidad < 1 Then
                    nueva_cantidad = 0
                End If


                ls_sql = "pa_sel_um_documentod '" & _empresa & "','" & ptipoDocto & "','" & drv.Item("con_numero") & "'"
                dt2 = oTrans.Obtiene(ls_sql)
                dt2.DefaultView.RowFilter = "producto = '" & _cod_producto & "' and cantidad > 0 "
                If dt2.Rows.Count > 0 Then
                    drv2 = dt2.DefaultView(0)
                    dr = dt3.NewRow()
                    dr.Item("cod_producto") = _cod_producto
                    dr.Item("cantidad") = cantidad_asignada
                    dr.Item("TipoDoctoOrigen") = ptipoDocto '"CONSIGNACIONES"
                    dr.Item("CorrelativoOrigen") = drv2.Item("correlativo")
                    dr.Item("SecuenciaOrigen") = drv2.Item("secuencia")
                    dt3.Rows.Add(dr)
                End If

                '                ls_consignaciones += " Consignacion No. " & drv.Item("con_numero").ToString & " Cantidad " & cantidad_asignada & "," & vbCrLf

                If nueva_cantidad < 1 Then
                    Exit For
                End If

            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
        Return dt3
    End Function




    'Private Function crearEstructura()


    '    Dim ls_sql As String
    '    Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim dt, dt2 As DataTable
    '    Dim dr, dr_aux As DataRow
    '    Dim ods As New DataSet


    '    Try

    '        'Ods.Tables("Conteos_Pendientes").Rows.Clear()
    '        myOtrans.open()
    '        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo_pendiente (null,null,null)"
    '        dt = myOtrans.Obtiene(ls_sql)
    '        If dt.Rows.Count > 0 Then
    '        End If


    '        For Each dr In dt.Rows
    '            dr_aux = ods.Tables("Conteos_Pendientes").NewRow
    '            dr_aux.Item("cod_conteo") = dr.Item("cod_conteo")
    '            dr_aux.Item("cod_empresa") = dr.Item("cod_empresa")
    '            dr_aux.Item("empresa") = dr.Item("empresa").ToString
    '            dr_aux.Item("cod_cliente") = dr.Item("cod_cliente_flex")
    '            'dr_aux.Item("Razon_Social") = ""
    '            dr_aux.Item("cod_producto") = dr.Item("cod_producto_flex")
    '            ' dr_aux.Item("nombre_producto") = ""
    '            dr_aux.Item("conteo") = dr.Item("conteo")
    '            dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
    '            dr_aux.Item("fecha") = dr.Item("fecha")
    '            dr_aux.Item("saldo_actual") = Obtener_Saldo_Consignacion_Actual(dr.Item("empresa").ToString, dr.Item("cod_producto_flex").ToString, dr.Item("cod_cliente_flex"))
    '            dr_aux.Item("cantidad_consignar") = IIf(dr.Item("cantidad_maxima") Is System.DBNull.Value, 0, dr.Item("cantidad_maxima")) - dr.Item("conteo").ToString
    '            dr_aux.Item("cantidad_facturar") = IIf(dr_aux.Item("saldo_actual") Is System.DBNull.Value, 0, dr_aux.Item("saldo_actual")) - dr.Item("conteo").ToString
    '            dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios").ToString
    '            dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
    '            dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
    '            dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
    '            dr_aux.Item("Usuario_Grabo") = dr.Item("Usuario_Grabo").ToString
    '            ods.Tables("Conteos_Pendientes").Rows.Add(dr_aux)

    '        Next



    '        For Each dr In ods.Tables("Conteos_Pendientes").Rows

    '            ods.Tables("clientes_procesar").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
    '            If ods.Tables("clientes_procesar").DefaultView.Count = 0 Then
    '                dr_aux = ods.Tables("clientes_procesar").NewRow
    '                dr_aux.Item("empresa") = dr.Item("empresa")
    '                dr_aux.Item("cod_cliente") = dr.Item("cod_cliente")
    '                dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios_reposicion").ToString
    '                dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
    '                dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
    '                dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString

    '                ods.Tables("clientes_procesar").Rows.Add(dr_aux)
    '            End If

    '        Next
    '        For Each dr In ods.Tables("clientes_procesar").Rows
    '            ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
    '            Crear_Documento_Consignacion_Factura_Flex(ods.Tables("conteos_pendientes").DefaultView, dr.Item("cod_cliente").ToString,
    '                dr.Item("Comentarios_reposicion").ToString, dr.Item("Comentarios_factura").ToString,
    '                dr.Item("Direccion_entrega_reposicion").ToString, dr.Item("Direccion_entrega_factura").ToString)

    '        Next



    'Catch ex As Exception
    '    Finally
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        ClsGen = Nothing
    '    End Try

    '    Return True

    'End Function



    Private Sub frmRenovacionconsignaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEsctructura()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenarSaldo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta Seguro de Realizar el Traslado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Crear_Documento_Consignacion_Factura_Flex()
        End If
    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As EventArgs) Handles txtCodigoCliente.LostFocus
        Try
            Dim dt As DataTable
            dt = Me.Obtener_Cliente(gs_empresa, Me.txtCodigoCliente.Text)

            Me.TextBox2.Text = dt.Rows(0).Item("razonsocial").ToString
        Catch ex As Exception

        End Try

    End Sub
End Class