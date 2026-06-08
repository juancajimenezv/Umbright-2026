Imports System.IO
Imports System.Xml
Imports System.Text
Public Class frm_Procesar_Pedidos_3pl

    Public dt3PLMovimiento As New DataTable
    Public dt3PLMovimientoLote As New DataTable



    Private Function ProcesarDocumento(ByVal dt3PL As DataTable) As Boolean


        Dim Otrans As New Transaccional.Conexion("FlexLine")


        Dim Oflex As New Umbral_Flex.Pedidos(False, True)

        Oflex.Validar_Totales = False


        Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()

        Dim dr, ofila As DataRow
        Dim li_linea As Integer = 0
        Dim ls_pedido_generado As Integer = 0
        Dim s_empresa As String = String.Empty
        Dim proceso_exitoso As Boolean = False
        Dim pd_total_pedido As Double = 0
        Dim forma_pago As String = String.Empty
        Dim sTipoDocto As String
        Dim drEncabezado As DataRow
        Dim ods As New DataSet
        Dim lsSQL As String

        drEncabezado = dt3PL.Rows(0)
        s_empresa = drEncabezado.Item("empresa").ToString

        sTipoDocto = drEncabezado.Item("tipodocto").ToString.ToUpper
        If sTipoDocto.ToString.ToLower.StartsWith("salida de mercaderias serie") Then
            sTipoDocto = "Salida de Mercaderia".ToUpper
        End If

        If sTipoDocto.ToString.Trim.Length > 20 Then sTipoDocto = sTipoDocto.Substring(0, 20).ToUpper
        'forma_pago = drEncabezado.Item("forma_pago").ToString
        Dim lfechaDocto As Date
        lfechaDocto = DateTime.Parse(drEncabezado.Item("fecha"))


        osinc.Llenar_Auxiliares(ods, drEncabezado.Item("codigo_cliente"), s_empresa)
        osinc = Nothing

        dr = Oflex.ods.Tables("encabezado").NewRow
        ' pd_total_pedido = drEncabezado.Item("total_devolucion").ToString


        dr.Item("Empresa") = s_empresa
        dr.Item("tipodocto") = sTipoDocto
        dr.Item("correlativo") = 0
        dr.Item("CtaCte") = String.Empty
        dr.Item("numero") = drEncabezado.Item("numero").ToString.PadLeft(10, "0")
        dr.Item("fecha") = lfechaDocto.ToString("dd-MM-yyyy")
        dr.Item("proveedor") = String.Empty
        dr.Item("cliente") = drEncabezado.Item("codigo_cliente")
        dr.Item("bodega") = drEncabezado.Item("bodega")
        dr.Item("bodega2") = String.Empty
        dr.Item("local") = String.Empty
        dr.Item("comprador") = String.Empty
        'dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
        dr.Item("CentroCosto") = String.Empty
        dr.Item("fechaVcto") = "01/01/1900"
        'dr.Item("listaPrecio") = drEncabezado.Item("listaprecio").ToString
        'dr.Item("Analisis") = "piloto"
        dr.Item("Zona") = String.Empty
        dr.Item("tipocta") = "VEHICULO PENDIENTE"
        'dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")
        dr.Item("paridad") = 1
        dr.Item("neto") = 0
        dr.Item("subtotal") = 0
        dr.Item("total") = 0
        dr.Item("NetoIngreso") = 0
        dr.Item("SubTotalIngreso") = 0
        dr.Item("TotalIngreso") = 0
        dr.Item("centraliza") = String.Empty
        dr.Item("valoriza") = String.Empty
        dr.Item("costeo") = String.Empty
        dr.Item("aprobacion") = "S" '(c) A partir del 02 de Mayo 2014
        dr.Item("TipoComprobante") = String.Empty
        dr.Item("PeriodoLibro") = lfechaDocto.ToString("yyyyMM")
        dr.Item("FactorMonto") = 0
        dr.Item("TipoCtaCte") = "CLIENTE"
        dr.Item("IdCtaCte") = drEncabezado.Item("codigo_cliente")
        dr.Item("Glosa") = drEncabezado.Item("documento_numero")
        dr.Item("comentario1") = drEncabezado.Item("comentario_entrega").ToString.Replace(",", "").Replace("'", "")
        dr.Item("comentario2") = String.Empty
        dr.Item("vigencia") = "S"
        dr.Item("Emitido") = "N"
        dr.Item("PorcentajeAsignado") = 0
        dr.Item("direccion") = drEncabezado.Item("direccion_entrega").ToString.Replace(",", "").Replace("'", "")
        dr.Item("ciudad") = String.Empty
        dr.Item("comuna") = String.Empty
        dr.Item("EstadoDir") = String.Empty
        dr.Item("pais") = String.Empty
        dr.Item("contacto") = String.Empty
        dr.Item("FechaModif") = Now
        dr.Item("FechaUModif") = Now
        dr.Item("UsuarioModif") = "Admin"
        dr.Item("Hora") = Now.ToString("HH:mm:ss")
        dr.Item("NetoBimoneda") = 0
        dr.Item("SubTotalBimoneda") = 0
        dr.Item("TotalBimoneda") = 0
        dr.Item("ParidadBimoneda") = 1
        dr.Item("AnalisisE1") = String.Empty
        dr.Item("AnalisisE2") = String.Empty
        dr.Item("AnalisisE3") = String.Empty
        dr.Item("UsuarioAprueba") = String.Empty
        dr.Item("referenciaexterna") = "0" 'drEncabezado.Item("correlativo") //Rechazos No Aplica

        'Try
        '    Dim dtPiloto As DataTable
        '    dtPiloto = Otrans.Obtiene("pa_var_um_documento_guia_transporte  '" & s_empresa & "','" & drEncabezado.Item("TipoDoctoFactura") & "','" & drEncabezado.Item("NumeroFactura") & "'")

        '    If dtPiloto.Rows.Count > 0 Then
        '        dr.Item("Analisis") = dtPiloto.Rows(0).Item("piloto")
        '        dr.Item("TipoCta") = dtPiloto.Rows(0).Item("TipoCta")
        '    End If
        'Catch ex As Exception

        'End Try





        Oflex.ods.Tables("encabezado").Rows.Add(dr)


        ''DocumentoV
        '  dr = Oflex.ods.Tables("documentov").NewRow
        ' dr.Item("total") = pd_total_pedido
        'dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
        'Oflex.ods.Tables("documentov").Rows.Add(dr)



        'lsSQL = "pa_var_um_devolucion_factura_producto " & dt.Rows(0).Item("cod_devolucion")
        '    Dim dtDetalle As DataTable
        '     dtDetalle = Otrans.Obtiene(lsSQL)


        '      Dim drv As DataRowView
        Dim iCount As Integer = 0

        Dim ldSubTotal As Double = 0
        ''DocumentoD
        For Each ofila In dt3PL.Rows
            '            dtDetalle.DefaultView.RowFilter = "numero = '" & ofila.Item("numero") & "' and  producto ='" & ofila.Item("producto") & "' and lote = '" & ofila.Item("lote") & "'"
            '           drv = dtDetalle.DefaultView(0)

            iCount += 1
            dr = Oflex.ods.Tables("detalle").NewRow

            dr.Item("Empresa") = s_empresa
            dr.Item("tipodocto") = sTipoDocto
            dr.Item("Secuencia") = iCount 'ofila.Item("secuenciaFactura") 'iCount
            dr.Item("Linea") = iCount 'ofila.Item("secuenciaFactura") 'iCount
            dr.Item("Producto") = ofila.Item("producto_lgs")
            If ofila.Item("existencia2") > 0 Then 'Cuando lleva mas de 1 Lote, la primera vez debe ingresar la cantidad total del primer Lote
                'dr.Item("Cantidad") = ofila.Item("cantidad")
                dr.Item("Cantidad") = ofila.Item("existencia")
                dr.Item("CantidadIngreso") = ofila.Item("existencia")
            Else
                dr.Item("Cantidad") = ofila.Item("cantidad")
                dr.Item("CantidadIngreso") = ofila.Item("cantidad")
            End If
            dr.Item("Precio") = 0 ''Precio de La factura Original
            dr.Item("PorcentajeDr") = 0
            dr.Item("SubTotal") = 0
            dr.Item("Impuesto") = 0
            dr.Item("Neto") = 0
            dr.Item("DRGlobal") = 0
            Try
                dr.Item("Costo") = 0 'Es el costo de la tabla ProdBodegas
            Catch ex As Exception
                dr.Item("Costo") = 0
            End Try
            'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
            dr.Item("Total") = 0
            dr.Item("PrecioAjustado") = 0
            dr.Item("UnidadIngreso") = "UN"
            dr.Item("CantidadIngreso") = ofila.Item("cantidad")
            dr.Item("PrecioIngreso") = dr.Item("precio")
            dr.Item("SubTotalIngreso") = dr.Item("Total")
            dr.Item("ImpuestoIngreso") = 0
            dr.Item("NetoIngreso") = 0
            dr.Item("DRGlobalIngreso") = 0
            dr.Item("TotalIngreso") = 0
            dr.Item("Lote") = ofila.Item("lote")
            dr.Item("fechavcto") = ofila.Item("fechavcto")
            'dr.Item("TipoDoctoOrigen") = ofila.Item("TipoDoctoFactura")
            dr.Item("CorrelativoOrigen") = 0
            dr.Item("SecuenciaOrigen") = 0
            dr.Item("Bodega") = ofila.Item("bodega")
            dr.Item("FactorInventario") = ofila.Item("factor")
            dr.Item("FechaEntrega") = Today
            dr.Item("CantidadAsignada") = 0
            dr.Item("Fecha") = lfechaDocto.ToString("dd-MM-yyyy")
            dr.Item("comentario") = ofila.Item("observaciones_maquila").Replace(",", "").Replace("'", "")
            dr.Item("Vigente") = "S"

            dr.Item("CUP") = 0
            dr.Item("Ubicacion") = "PRINCIPAL"
            dr.Item("Ubicacion2") = "PRINCIPAL"
            dr.Item("cuenta") = String.Empty
            dr.Item("FactorImpto") = 1
            dr.Item("PrecioBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("ImpuestoBimoneda") = 0
            dr.Item("NetoBimoneda") = 0
            dr.Item("DrGlobalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("PrecioListaP") = 0
            dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")
            'dr.Item("FechaVigenciaLp") = ofila.Item("FechaVigenciaLp")
            dr.Item("LoteDestino") = String.Empty
            dr.Item("SerieDestino") = String.Empty
            dr.Item("ProdAlias") = String.Empty
            dr.Item("DoctoOrigenVal") = "S"
            dr.Item("MontoAsignado") = 0
            'dr.Item("Aux_Valor13") = ofila.Item("cod_motivo")

            dr.Item("ValPorcentajeDr1") = 0
            dr.Item("ValPorcentajeDr2") = 0
            dr.Item("ValPorcentajeDr3") = 0
            dr.Item("ValPorcentajeDr4") = 0
            dr.Item("ValPorcentajeDr5") = 0
            dr.Item("ValPorcentajeDr1Ingreso") = 0
            dr.Item("ValPorcentajeDr2Ingreso") = 0
            dr.Item("ValPorcentajeDr3Ingreso") = 0
            dr.Item("ValPorcentajeDr4Ingreso") = 0
            dr.Item("ValPorcentajeDr5Ingreso") = 0
            dr.Item("ValPorcentajeDr1Bimoneda") = 0
            dr.Item("ValPorcentajeDr2Bimoneda") = 0
            dr.Item("ValPorcentajeDr3Bimoneda") = 0
            dr.Item("ValPorcentajeDr4Bimoneda") = 0
            dr.Item("ValPorcentajeDr5Bimoneda") = 0

            Oflex.ods.Tables("detalle").Rows.Add(dr)


            ''Inserto la Linea 2 con Lote
            If ofila.Item("existencia2") > 0 Then

                iCount += 1
                dr = Oflex.ods.Tables("detalle").NewRow

                dr.Item("Empresa") = s_empresa
                dr.Item("tipodocto") = sTipoDocto
                dr.Item("Secuencia") = iCount 'ofila.Item("secuenciaFactura") 'iCount
                dr.Item("Linea") = iCount 'ofila.Item("secuenciaFactura") 'iCount
                dr.Item("Producto") = ofila.Item("producto_lgs")
                dr.Item("Cantidad") = ofila.Item("cantidad") '(c) Cantidad de Lote 2
                'dr.Item("Cantidad") = ofila.Item("cantidad")

                dr.Item("Cantidad") = ofila.Item("cantidad") - ofila.Item("existencia")
                dr.Item("CantidadIngreso") = ofila.Item("cantidad") - ofila.Item("existencia")

                dr.Item("Precio") = 0 ''Precio de La factura Original
                dr.Item("PorcentajeDr") = 0
                dr.Item("SubTotal") = 0
                dr.Item("Impuesto") = 0
                dr.Item("Neto") = 0
                dr.Item("DRGlobal") = 0
                Try
                    dr.Item("Costo") = 0 'Es el costo de la tabla ProdBodegas
                Catch ex As Exception
                    dr.Item("Costo") = 0
                End Try
                'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
                dr.Item("Total") = 0
                dr.Item("PrecioAjustado") = 0
                dr.Item("UnidadIngreso") = "UN"
                dr.Item("PrecioIngreso") = dr.Item("precio")
                dr.Item("SubTotalIngreso") = dr.Item("Total")
                dr.Item("ImpuestoIngreso") = 0
                dr.Item("NetoIngreso") = 0
                dr.Item("DRGlobalIngreso") = 0
                dr.Item("TotalIngreso") = 0
                dr.Item("Lote") = ofila.Item("lote2")
                dr.Item("fechavcto") = ofila.Item("fechavcto2")
                'dr.Item("TipoDoctoOrigen") = ofila.Item("TipoDoctoFactura")
                dr.Item("CorrelativoOrigen") = 0
                dr.Item("SecuenciaOrigen") = 0
                dr.Item("Bodega") = ofila.Item("bodega")
                dr.Item("FactorInventario") = ofila.Item("factor")
                dr.Item("FechaEntrega") = Today
                dr.Item("CantidadAsignada") = 0
                dr.Item("Fecha") = lfechaDocto.ToString("dd-MM-yyyy")
                dr.Item("comentario") = ofila.Item("observaciones_maquila").Replace(",", "").Replace("'", "")
                dr.Item("Vigente") = "S"

                dr.Item("CUP") = 0
                dr.Item("Ubicacion") = "PRINCIPAL"
                dr.Item("Ubicacion2") = "PRINCIPAL"
                dr.Item("cuenta") = String.Empty
                dr.Item("FactorImpto") = 1
                dr.Item("PrecioBimoneda") = 0
                dr.Item("SubTotalBimoneda") = 0
                dr.Item("ImpuestoBimoneda") = 0
                dr.Item("NetoBimoneda") = 0
                dr.Item("DrGlobalBimoneda") = 0
                dr.Item("TotalBimoneda") = 0
                dr.Item("PrecioListaP") = 0
                dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")
                'dr.Item("FechaVigenciaLp") = ofila.Item("FechaVigenciaLp")
                dr.Item("LoteDestino") = String.Empty
                dr.Item("SerieDestino") = String.Empty
                dr.Item("ProdAlias") = String.Empty
                dr.Item("DoctoOrigenVal") = "S"
                dr.Item("MontoAsignado") = 0
                'dr.Item("Aux_Valor13") = ofila.Item("cod_motivo")

                dr.Item("ValPorcentajeDr1") = 0
                dr.Item("ValPorcentajeDr2") = 0
                dr.Item("ValPorcentajeDr3") = 0
                dr.Item("ValPorcentajeDr4") = 0
                dr.Item("ValPorcentajeDr5") = 0
                dr.Item("ValPorcentajeDr1Ingreso") = 0
                dr.Item("ValPorcentajeDr2Ingreso") = 0
                dr.Item("ValPorcentajeDr3Ingreso") = 0
                dr.Item("ValPorcentajeDr4Ingreso") = 0
                dr.Item("ValPorcentajeDr5Ingreso") = 0
                dr.Item("ValPorcentajeDr1Bimoneda") = 0
                dr.Item("ValPorcentajeDr2Bimoneda") = 0
                dr.Item("ValPorcentajeDr3Bimoneda") = 0
                dr.Item("ValPorcentajeDr4Bimoneda") = 0
                dr.Item("ValPorcentajeDr5Bimoneda") = 0

                Oflex.ods.Tables("detalle").Rows.Add(dr)

            End If


        Next

        Try




        Catch ex As Exception

        End Try
        ls_pedido_generado = Oflex.Guardar_Documento()




        Oflex = Nothing

        Return proceso_exitoso
    End Function

    Private Function ProcesarCliente(ByRef pdt3PL As DataTable)

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr As DataRow

        Try
            dr = pdt3PL.Rows(0)

            lsSQL = "pa_sel_um_ctacte '" & _
                     dr.Item("empresa").ToString & "','CLIENTE','" & dr.Item("codigo_cliente").ToString & "'"

            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count = 0 Then

                lsSQL = "pa_ins_um_ctacte '" & _
                    dr.Item("Empresa").ToString & "','" & _
                    dr.Item("codigo_cliente").ToString & "','" & _
                    dr.Item("codigo_cliente").ToString & "','" & _
                    dr.Item("nombre_cliente").ToString & "','" & _
                    "','','" & _
                    dr.Item("direccion_entrega").ToString & "','" & _
                    "','','','','','','" & _
                    dr.Item("direccion_entrega").ToString & "','" & _
                    "Admin','3PL','TESA','TESA'"

                clsGen.insertQuery("FlexLine", lsSQL)

            End If




        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try



    End Function



    Private Sub enviarCorreoNoProcesados(ByRef psBody As String)


        Dim dtUsuarioBU, dtBU, dtCorreo As DataTable
        Dim clsGen As New ClasesGenerales.General()

        Dim scuentas As String = String.Empty


        scuentas = "coscal@umbral.com.gt"
        'dtBU = clsGen.ValoresDistinto(dtMovimientos, "Bu".Split(","))


        'For Each dr As DataRow In dtBU.Rows



        '    '' Debo obtener las personas que tienen permisos para esa unidad de negocio
        '    dtUsuarioBU = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" + dr.Item("Bu").ToString() + "','" + sEmpresa + "'")
        '    For Each drUsuarioBU As DataRow In dtUsuarioBU.Rows

        '        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" + drUsuarioBU.Item("usuario").ToString() + "'")
        '        If (dtCorreo.Rows.Count > 0) Then



        '            If (scuentas.IndexOf(dtCorreo.Rows(0).Item("correo").ToString()) < 0) Then
        '                If (scuentas.ToString().Length > 0) Then scuentas += ","

        '                scuentas += dtCorreo.Rows(0).Item("correo").ToString()
        '            End If
        '        End If

        '    Next
        'Next

        'MessageBox.Show(scuentas)



        'Dim lsRuta As String = generarPDF(dFecha.ToShortDateString(), sEmpresa, sBodega)
        Dim sSubject As String = String.Empty, sBody = String.Empty, scuentasCopia = String.Empty


        sSubject = "Documentos No Procesado  " & Today.ToShortDateString()



        'sBody = "<h2> Buen Dia <span style='color: #5e9ca0;'>"


        'sBody = sBody & "</span></h2>"

        'sBody = sBody & "<h2 style='color: #2e6c80;'>Detalle:</h2>"




        'scuentas = scuentas
        'scuentas = "coscal@umbral.com.gt"
        'scuentasCopia = "hbonilla@logiservicios.com,omonterroso@logiservicios.com,hcambara@logiservicios.com,chernandez@logiservicios.com,mrojas@logiservicios.com,maquila@logiservicios.com,ggonzalez@logiservicios.com,coscal@umbral.com.gt,"

        'scuentasCopia = clsGen.Obtener_XMLConfig("copia_correo_inventarios_3pl", False)
        clsGen.Escribir_Log(scuentas)
        'clsGen.Escribir_Log(scuentasCopia)
        'clsGen.enviarcorreo("lgs1@logiservicios.com", "LGS1", scuentas, sSubject, psBody, "")

        clsGen.enviarcorreo("lgs1@logiservicios.com", "LGS1", scuentas, sSubject, psBody, "")
        'ProcesarMail(scuentas, "")

        'Ruta En Servidor


        clsGen = Nothing







    End Sub



    Private Sub crearEstructura()

        dt3PLMovimiento.Columns.Add(New DataColumn("correlativo", GetType(Integer)))
        dt3PLMovimiento.Columns.Add(New DataColumn("documento_numero", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("numero", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("codigo_cliente", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("direccion_entrega", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("comentario_entrega", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("codigo_producto", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("nombre_producto", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt3PLMovimiento.Columns.Add(New DataColumn("cajas", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("inner_packs", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("observaciones_maquila", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("total_unidades", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("total_lineas", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("bodega", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("factor", GetType(Double)))
        dt3PLMovimiento.Columns.Add(New DataColumn("existencia", GetType(Double)))
        dt3PLMovimiento.Columns.Add(New DataColumn("existencia_calculada", GetType(Double)))
        dt3PLMovimiento.Columns.Add(New DataColumn("producto_lgs", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("valido_lineas", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("valido_unidades", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("valido_stock_individual", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("valido_stock_total", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("procesar", GetType(Integer)))
        dt3PLMovimiento.Columns.Add(New DataColumn("verifica_lote", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("lote", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("fechavcto", GetType(DateTime)))

        dt3PLMovimiento.Columns.Add(New DataColumn("existencia2", GetType(Double)))
        dt3PLMovimiento.Columns.Add(New DataColumn("lote2", GetType(String)))
        dt3PLMovimiento.Columns.Add(New DataColumn("fechavcto2", GetType(DateTime)))

        dt3PLMovimiento.Columns.Add(New DataColumn("Empresa", GetType(String)))


        Me.dgvProductos.DataSource = dt3PLMovimiento
        dt3PLMovimientoLote = dt3PLMovimiento.Copy
    End Sub


    Private Sub validarDocumentos()
        Dim clsGen As New ClasesGenerales.General
        Dim dtUnicos As DataTable
        Dim lvalido As Boolean = False
        Dim dtStock As DataTable
        Dim dtStockLote As DataTable
        Dim dtProductos As DataTable


        Try
            ''Busco el Codigo Flex

            dtProductos = clsGen.selectQuery("FlexLine", "pa_var_um_prodcodbarra_glosa 'logiserv',null,4")
            dtStock = clsGen.selectQuery("FlexLine", "pa_var_um_verificacion_inventario_3PL 'TESA'")
            dtStockLote = clsGen.selectQuery("FlexLine", "pa_var_um_verificacion_inventario_lote_3PL 'TESA'")

            For Each dr As DataRow In dt3PLMovimiento.Rows
                dtProductos.DefaultView.RowFilter = "codbarra = '" & dr.Item("codigo_producto").ToString.Trim & "'"
                If dtProductos.DefaultView.Count < 1 Then
                    dtProductos.DefaultView.RowFilter = "codbarra = '0" & dr.Item("codigo_producto").ToString.Trim & "'"
                End If
                If dtProductos.DefaultView.Count < 1 Then
                    dtProductos.DefaultView.RowFilter = "codbarra = '" & dr.Item("codigo_producto").ToString.Trim.Substring(1) & "'"
                End If

                If dtProductos.DefaultView.Count > 0 Then

                    dr.Item("producto_lgs") = dtProductos.DefaultView(0).Item("producto")
                    dr.Item("verifica_lote") = dtProductos.DefaultView(0).Item("lote") 'valida Lote
                    dr.Item("empresa") = dtProductos.DefaultView(0).Item("Empresa")
                    dr.Item("procesar") = 0
                End If

                If dr.Item("documento_numero").ToString.Length = 0 Then
                    dr.Item("documento_numero") = dr.Item("tipodocto").ToString.Substring(0, 20) & "-" & dr.Item("numero").ToString
                End If
                'dr.Item("procesar") = 1
            Next


            ''Validacion previa de stock
            For Each dr As DataRow In dt3PLMovimiento.Rows
                dr.Item("existencia") = 0
                dr.Item("existencia2") = 0
                dtStock.DefaultView.RowFilter = "producto = '" & dr.Item("producto_lgs").ToString.Trim & "'"
                If dtStock.DefaultView.Count > 0 Then
                    dr.Item("existencia") = dtStock.DefaultView(0).Item("existencia")
                End If

                If Integer.Parse(dr.Item("factor")) > 0 Then
                    dr.Item("valido_stock_individual") = "Ok"
                Else
                    If dr.Item("existencia") >= Double.Parse(dr.Item("cantidad").ToString) Then
                        dr.Item("valido_stock_individual") = "Ok"
                    Else
                        dr.Item("valido_stock_individual") = "Fail"
                    End If
                End If
            Next


            'Valida Stock Con Lote
            For Each dr As DataRow In dt3PLMovimiento.Rows
                If dr.Item("verifica_lote").ToString.ToLower = "s" Then
                    dr.Item("existencia") = 0
                    dr.Item("existencia2") = 0
                    dtStockLote.DefaultView.RowFilter = "producto = '" & dr.Item("producto_lgs").ToString.Trim & "'"

                    'Verificar Fecha de Lote
                    Dim dtLote As DataTable = dtStockLote.DefaultView.ToTable
                    dtLote.DefaultView.Sort = "FechaVcto"
                    Dim iVeces As Integer = 0
                    For Each drViewLote As DataRowView In dtLote.DefaultView

                        If drViewLote.Item("existencia") > 0 Then

                            iVeces = iVeces + 1
                            If iVeces = 2 Then
                                'MessageBox.Show("Asignar Lote2")
                                dr.Item("existencia2") = drViewLote.Item("existencia")
                                dr.Item("Lote2") = drViewLote.Item("Lote")
                                dr.Item("fechavcto2") = drViewLote.Item("fechavcto")
                            ElseIf iVeces = 3 Then
                                MessageBox.Show("Asignar Lote 3")

                            ElseIf iVeces = 1 Then
                                dr.Item("existencia") = drViewLote.Item("existencia")
                                dr.Item("Lote") = drViewLote.Item("Lote")
                                dr.Item("fechavcto") = drViewLote.Item("fechavcto")
                            End If
                            If Integer.Parse(dr.Item("factor")) > 0 Then
                                dr.Item("valido_stock_individual") = "Ok"
                                Exit For
                            Else
                                If (dr.Item("existencia") + dr.Item("existencia2")) >= Double.Parse(dr.Item("cantidad").ToString) Then
                                    dr.Item("valido_stock_individual") = "Ok"
                                    Exit For
                                Else
                                    dr.Item("valido_stock_individual") = "Fail"
                                End If
                            End If
                        End If
                    Next
                    'If dtStockLote.DefaultView.Count > 0 Then
                    '    dr.Item("existencia") = dtStockLote.DefaultView(0).Item("existencia")
                    'End If


                End If
            Next





            dtUnicos = clsGen.ValoresDistinto(dt3PLMovimiento, "documento_numero".Split(","))

            For Each dr As DataRow In dtUnicos.Rows
                dt3PLMovimiento.DefaultView.RowFilter = "documento_numero = '" & dr.Item("documento_numero") & "'"

                If dt3PLMovimiento.DefaultView.Count = dt3PLMovimiento.DefaultView(0).Item("total_lineas") Then
                    lvalido = True
                End If

                If lvalido Then
                    For Each drv As DataRowView In dt3PLMovimiento.DefaultView
                        drv.Item("valido_lineas") = "Ok"
                    Next
                End If


                lvalido = False

                If dt3PLMovimiento.Compute("sum(cantidad)", "documento_numero = '" & dr.Item("documento_numero") & "'") = dt3PLMovimiento.DefaultView(0).Item("total_unidades") Then
                    lvalido = True
                End If

                If lvalido Then
                    For Each drv As DataRowView In dt3PLMovimiento.DefaultView
                        drv.Item("valido_unidades") = "Ok"
                    Next
                End If
            Next

            'Valido stock global
            '1 Fase

            For Each dr As DataRow In dt3PLMovimiento.Rows

                If dr.Item("valido_stock_individual").ToString = "Fail" Then
                    dr.Item("valido_stock_total") = "Fail"
                End If

                If dr.Item("factor") = 1 Then 'Suma Inventario
                    dr.Item("valido_stock_total") = "Ok"
                End If


            Next

            Dim validaProducto As DataTable
            validaProducto = clsGen.ValoresDistinto(dt3PLMovimiento, "producto_lgs".Split(","))

            Dim ilineas As Integer = 0
            Dim dexistencia As Double = 0
            For Each dr As DataRow In validaProducto.Rows
                dt3PLMovimiento.DefaultView.RowFilter = "producto_lgs = '" & dr.Item("producto_lgs") & "'"
                dt3PLMovimiento.DefaultView.Sort = "factor desc, correlativo"
                ilineas = 0


                For Each drv As DataRowView In dt3PLMovimiento.DefaultView



                    If ilineas = 0 Then
                        drv.Item("existencia_calculada") = drv.Item("existencia") + drv.Item("existencia2") + (drv.Item("cantidad") * drv.Item("factor"))
                        dexistencia = drv.Item("existencia_calculada")
                    Else
                        drv.Item("existencia_calculada") = dexistencia - drv.Item("cantidad")
                        dexistencia = drv.Item("existencia_calculada")
                    End If
                    ilineas += 1
                Next
            Next

            ''Valido todo lo que se pueda despachar
            For Each dr As DataRow In dt3PLMovimiento.Rows
                If dr.Item("existencia_calculada") >= 0 Then
                    dr.Item("valido_stock_total") = "Ok"
                End If

            Next




            ''Establecer si se procesara la transaccion
            Dim validaFinal As DataTable
            Dim lbProcesaTransaccion As Boolean
            validaFinal = clsGen.ValoresDistinto(dt3PLMovimiento, "documento_numero".Split(","))

            For Each dr As DataRow In validaFinal.Rows
                dt3PLMovimiento.DefaultView.RowFilter = "documento_numero = '" & dr.Item("documento_numero") & "'"
                lbProcesaTransaccion = True
                For Each drv As DataRowView In dt3PLMovimiento.DefaultView
                    If drv.Item("valido_stock_total") = "Fail" Or drv.Item("valido_lineas") = "Fail" Or drv.Item("valido_unidades") = "Fail" Then
                        lbProcesaTransaccion = False
                        Exit For
                    End If
                Next

                For Each drv As DataRowView In dt3PLMovimiento.DefaultView
                    If lbProcesaTransaccion Then
                        drv.Item("procesar") = 1
                    Else
                        drv.Item("procesar") = -1
                    End If
                Next



            Next

            'dt.DefaultView.RowFilter = ""
            'Dim dtFinal As DataTable
            'dtFinal = dt.Copy()
            'dtFinal.Rows.Clear()
            'For Each dr As DataRow In dt.Rows
            '    If dr.Item("procesar") = 1 Then
            '        dr.Item("procesar") = 1

            '        Dim drnew As DataRow = dtFinal.NewRow
            '        For Each dc As DataColumn In dt.Columns
            '            drnew(dc.ColumnName) = dr(dc.ColumnName)
            '        Next

            '        dtFinal.Rows.Add(drnew)

            '    End If
            'Next




            'dt.DefaultView.RowFilter = ""



            'Dim procesarTRansacciones As DataTable = clsGen.ValoresDistinto(dtFinal, "documento_numero".Split(","))

            'Try
            '    For Each dr As DataRow In procesarTRansacciones.Rows
            '        dt.DefaultView.RowFilter = "documento_numero = '" & dr.Item("documento_numero") & "'"
            '        Me.ProcesarCliente(dt.DefaultView.ToTable)
            '        Me.ProcesarDocumento(dt.DefaultView.ToTable)
            '    Next

            'Catch ex As Exception

            'End Try

            dt3PLMovimiento.DefaultView.RowFilter = "procesar < 0"
            Dim NoprocesarTRansacciones As DataTable = clsGen.ValoresDistinto(dt3PLMovimiento.DefaultView.ToTable, "documento_numero".Split(","))

            Dim sBody As String = String.Empty
            sBody = dt3PLMovimiento.DefaultView.Count & "<br>"
            For Each dr As DataRow In NoprocesarTRansacciones.Rows
                sBody = sBody & "<p>" & dr.Item("documento_numero").ToString & "<p>"

                If False Then


                    dt3PLMovimiento.DefaultView.RowFilter = "documento_numero = '" & dr.Item("documento_numero") & "'"

                    For Each drv As DataRowView In dt3PLMovimiento.DefaultView
                        Dim lbStockIndividual As Boolean = True
                        Dim lbStockTotal As Boolean = True
                        Dim lsLinea As String = String.Empty
                        If drv.Item("valido_lineas") = "Fail" Then

                        End If
                        If drv.Item("valido_unidades") = "Fail" Then

                        End If
                        If drv.Item("valido_stock_individual") = "Fail" Then
                            lbStockIndividual = False
                        End If

                        If drv.Item("valido_stock_total").ToString = "Fail" Then
                            lbStockTotal = False
                        End If

                        If Not lbStockIndividual Then
                            lsLinea = lsLinea & " Stock No Cubre la Linea"
                        End If

                        If Not lbStockTotal Then
                            lsLinea = lsLinea & "-Stock Acumulado No Cubre la Linea"
                        End If

                        If lsLinea.Length > 0 Then
                            sBody = sBody & "<li>" & drv.Item("codigo_producto").ToString & lsLinea & "</li>"
                        End If

                    Next
                End If
            Next

            If sBody.Length > 0 Then
                'enviarCorreoNoProcesados(sBody)
            End If

        Catch ex As Exception
        Finally
            dt3PLMovimiento.DefaultView.RowFilter = ""
        End Try


    End Sub



    Private Sub btn_BuscarArchivo3PL_Click(sender As Object, e As EventArgs) Handles btn_BuscarArchivo3PL.Click

        dt3PLMovimiento.Rows.Clear()
        dt3PLMovimientoLote.Rows.Clear()

        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName


        Dim lbprimeraLinea As Boolean = True
        Dim iposicion As Integer
        Using MyReader As New Microsoft.VisualBasic.
                        FileIO.TextFieldParser(
                          Me.TextBox1.Text)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(vbTab)
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    If Not lbprimeraLinea Then
                        'Crear Estructura
                        iposicion = 0
                        Dim currentField As String
                        Dim dr As DataRow = dt3PLMovimiento.NewRow

                        For Each currentField In currentRow
                            dr(iposicion) = currentField
                            iposicion += 1
                            'MsgBox(currentField & " " & iposicion)
                        Next
                        dt3PLMovimiento.Rows.Add(dr)
                    End If
                    lbprimeraLinea = False
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try

            End While
        End Using

        validarDocumentos()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
    End Sub



    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvProductos.CellPainting


        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then


                If Me.dgvProductos.Columns(colIndex).Name.ToLower.IndexOf("valido") > -1 Then
                    If Me.dgvProductos.Item(colIndex, rowIndex).Value.ToString = "Ok" Then
                        Me.dgvProductos.Item(colIndex, rowIndex).Style.ForeColor = Color.Green
                    Else
                        Me.dgvProductos.Item(colIndex, rowIndex).Style.ForeColor = Color.Red
                    End If



                End If

                'If Me.DataGridView1.Item("valido_stock_individual", rowIndex).Value = "Ok" Then
                '    'Me.DataGridView1.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Green
                '    'Else
                '    '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Red
                'End If

                'If Me.DataGridView1.Item("valido_unidades", rowIndex).Value = "Ok" Then
                '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Green
                'Else
                '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Red
                'End If
                'If Me.DataGridView1.Item("valido_lineas", rowIndex).Value = "Ok" Then
                '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Green
                'Else
                '    Me.DataGridView1.Item(colIndex, rowIndex).Style.BackColor = Color.Red
                'End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnProcesar3PL_Click(sender As Object, e As EventArgs) Handles btnProcesar3PL.Click
        Dim clsgen As New ClasesGenerales.General


        dt3PLMovimiento.DefaultView.RowFilter = ""
        Dim dtFinal As DataTable
        dtFinal = dt3PLMovimiento.Copy()
        dtFinal.Rows.Clear()
        For Each dr As DataRow In dt3PLMovimiento.Rows
            If dr.Item("procesar") = 1 Then
                dr.Item("procesar") = 1
                Dim drnew As DataRow = dtFinal.NewRow
                For Each dc As DataColumn In dt3PLMovimiento.Columns
                    drnew(dc.ColumnName) = dr(dc.ColumnName)
                Next
                dtFinal.Rows.Add(drnew)
            End If
        Next

        Dim procesarTRansacciones As DataTable = clsgen.ValoresDistinto(dtFinal, "documento_numero".Split(","))

        Try
            For Each dr As DataRow In procesarTRansacciones.Rows
                dt3PLMovimiento.DefaultView.RowFilter = "documento_numero = '" & dr.Item("documento_numero") & "'"
                Me.ProcesarCliente(dt3PLMovimiento.DefaultView.ToTable)
                Me.ProcesarDocumento(dt3PLMovimiento.DefaultView.ToTable)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lodsXML As New DataSet
        Dim dtResultado As New DataTable
        dtResultado.Columns.Add(New DataColumn("empresa", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("referencia", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("serie", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("PreImpreso", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("Firma", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("nombre", GetType(String)))
        dtResultado.Columns.Add(New DataColumn("direccion", GetType(String)))


        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName

        lodsXML.ReadXml(Me.TextBox1.Text)

        'Me.DataGridView1.DataSource = lodsXML.Tables("resultado")
        'Me.DataGridView1.DataSource = lodsXML.Tables("DCAE")

        Dim dr As DataRow
        dr = dtResultado.NewRow

        Dim referencia As String
        Dim referencias() As String

        referencias = Me.TextBox1.Text.Split("_")
        referencia = referencias(3).Split(".")(0)

        dr.Item("referencia") = referencia  '"PEDIDO FACE-0161102195"
        dr.Item("serie") = lodsXML.Tables("DCAE").Rows(0).Item("Serie")
        dr.Item("PreImpreso") = lodsXML.Tables("DCAE").Rows(0).Item("NumeroDocumento")
        dr.Item("Firma") = lodsXML.Tables("FCAE").Rows(0).Item("SignatureValue")


        lodsXML.Tables("nameAndAddress").DefaultView.RowFilter = "buyer_id = 0"
        dr.Item("nombre") = lodsXML.Tables("nameAndAddress").DefaultView(0).Item("name")
        dr.Item("direccion") = lodsXML.Tables("nameAndAddress").DefaultView(0).Item("StreetAddressOne").ToString & " "

        Try
            dr.Item("direccion") = dr.Item("direccion") & lodsXML.Tables("nameAndAddress").DefaultView(0).Item("StreetAddressTwo").ToString()
        Catch ex As Exception

        End Try

        Try

            If lodsXML.Tables("DCAE").Rows(0).Item("nitemisor") = "66083885" Then
                dr.Item("Empresa") = "DIUVA"
            ElseIf lodsXML.Tables("DCAE").Rows(0).Item("nitemisor") = "795127" Then
                dr.Item("Empresa") = "CODICASA"
            ElseIf lodsXML.Tables("DCAE").Rows(0).Item("nitemisor") = "1221833" Then
                dr.Item("Empresa") = "DMARTE1"
            End If
        Catch ex As Exception

        End Try

        dtResultado.Rows.Add(dr)

        Me.dgvProductos.DataSource = dtResultado

        Dim psEmpresa As String = dr.Item("Empresa")
        Dim psFecha As Date = Today
        Dim psFechaAdicional As Date = Today
        Dim psFechaFacturacion As Date = Today
        Dim odsFace As DataSet

        crear_estructuraFACE(odsFace)
        generarFACEFlexLineXML(psEmpresa, "eolivares", odsFace, psFecha, psFechaAdicional, psFechaFacturacion, dtResultado.Rows(0))
    End Sub


    Public Sub generarFACEFlexLineXML(ByRef psEmpresa As String, ByRef psUsuario As String, _
                            ByVal odsFace2 As DataSet, ByRef psFecha As Date, _
                            ByRef psFechaAdicional As Date, _
                           pdFechaFacturacion As Date, _
                           pdrResultado As DataRow)


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Otrans.gsnombreLog = "log_" & psEmpresa
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        clsGen.gsNombreInicialLog = "log_" & psEmpresa
        Dim lsrutaGenera As String
        Dim dtDocumentos, dtImpresoras As DataTable
        Dim dr As DataRow

        Dim odsFace As New DataSet

        Try

            Otrans.open()


            'Dim lodsXML As New DataSet

            'lodsXML.ReadXml(psArchivo)


            odsFace = odsFace2.Copy
            odsFace.Tables("pedidos").Rows.Clear()


            Dim drResultado As DataRow
            drResultado = pdrResultado
            'If lodsXML.Tables.Contains("Resultado") Then
            If Not drResultado Is Nothing Then
                'drResultado = lodsXML.Tables("Resultado").Rows(0)


                lsSQL = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFechaAdicional & "','" & psFecha & "',0"
                dtDocumentos = Otrans.Obtiene(lsSQL)

                dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & drResultado.Item("Referencia").ToString.Split("-")(0) & "' And numero = '" & drResultado.Item("Referencia").ToString.Split("-")(1) & "'"
                If dtDocumentos.DefaultView.Count = 1 Then
                    dr = odsFace.Tables("pedidos").NewRow

                    dr.Item("tipoDoctoOrigen") = drResultado.Item("Referencia").ToString.Split("-")(0)
                    dr.Item("numero") = drResultado.Item("Referencia").ToString.Split("-")(1)

                    dr.Item("fechaFACE") = Today 'psFecha.ToString
                    '(c) 20151102
                    'Fecha Para Generar las del cierre
                    dr.Item("fechaFACE") = pdFechaFacturacion

                    dr.Item("serieFACE") = drResultado.Item("Serie").ToString
                    dr.Item("numeroFACE") = drResultado.Item("PreImpreso").ToString
                    dr.Item("firmaFACE") = drResultado.Item("Firma").ToString

                    '(c) 20160916
                    'Nit Face debe ser el NIT del cliente
                    dr.Item("nitFACE") = dtDocumentos.DefaultView(0).Item("codlegal").ToString

                    dr.Item("nombreFACE") = drResultado.Item("Nombre").ToString
                    dr.Item("direccionFACE") = drResultado.Item("Direccion").ToString
                    dr.Item("ctacte") = dtDocumentos.DefaultView(0).Item("ctacte")
                    dr.Item("ImpresoraFACE") = dtDocumentos.DefaultView(0).Item("impresora")

                    Try
                        dr.Item("BodegaInterEmpresas") = dtDocumentos.DefaultView(0).Item("bodegaFacturar").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        dr.Item("forma_pago") = dtDocumentos.DefaultView(0).Item("codigopago")
                    Catch ex As Exception

                    End Try

                    odsFace.Tables("pedidos").Rows.Add(dr)



                    If Math.Abs(dtDocumentos.DefaultView(0).Item("total") - dtDocumentos.DefaultView(0).Item("totalPedidoPrevio")) > 0.1 Then
                        clsGen.Escribir_Log("Problemas con los totales en el Documento " & psEmpresa & " " & drResultado.Item("Referencia").ToString.Split("-")(0) & " " & drResultado.Item("Referencia").ToString.Split("-")(1) & " " &
                                                             drResultado.Item("Serie").ToString & " " & drResultado.Item("PreImpreso").ToString)
                        Me.guardarAviso("Problemas con los totales en el Documento  " & psEmpresa & " " & drResultado.Item("Referencia").ToString.Split("-")(0) & " " & drResultado.Item("Referencia").ToString.Split("-")(1) & " " &
                                             drResultado.Item("Serie").ToString & " " & drResultado.Item("PreImpreso").ToString, 31)

                        lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                                   drResultado.Item("Referencia").ToString.Split("-")(0) & "','" & drResultado.Item("Referencia").ToString.Split("-")(1) & "','Diferencia En Los Totales Flex-GuateFacturas'"
                        Otrans.Actualiza(lsSQL)
                    Else
                        odsFace.Tables("pedidos").DefaultView.RowFilter = ""
                        For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView

                            If drv.Item("numeroFACE").ToString.Trim.Length > 0 Then
                                ''Creamos los documentos FACE
                                lsSQL = "pa_ins_um_documento_FACE '" & psEmpresa & "','" & _
                                        drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
                                        drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
                                        drv.Item("firmaFACE").ToString.PadRight(100, " ") & "','" & psEmpresa & "','" & _
                                      drv.Item("fechaFACE") & "'"


                                If Otrans.Ingresa(lsSQL) > 0 Then
                                    lsSQL = "pa_ins_um_documentod_FACE '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
                                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
                                            Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"
                                    Otrans.Ingresa(lsSQL)
                                    If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)

                                    lsSQL = "pa_ins_um_documentop_FACE '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
                                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"
                                    Otrans.Ingresa(lsSQL)
                                    If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)

                                    lsSQL = "pa_ins_um_documentov_FACE '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
                                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"

                                    Otrans.Ingresa(lsSQL)
                                    If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)


                                    ''Anulo el Documento Anterior ''Pruebas No lo debo realizar
                                    lsSQL = "pa_upd_um_documento_estado '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "',NULL,'A','" & _
                                            psUsuario & "','" & drv.Item("serieFACE") & " " & drv.Item("numeroFACE") & "'"
                                    Otrans.Actualiza(lsSQL)
                                    If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)

                                    ''Actualizo la Informacion de GuateFactura

                                    lsSQL = "pa_upd_um_ctacte_FACE '" & psEmpresa & "','" & _
                                        drv.Item("ctacte") & "','" & _
                                        drv.Item("nitFACE") & "','" & _
                                        drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" & _
                                        drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "','" & _
                                        drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" & _
                                        drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "'"

                                    Otrans.Actualiza(lsSQL)
                                    'guardarAviso(Otrans.descripcion_error)
                                    If Otrans.Codigo_error > 0 Then
                                        clsGen.Escribir_Log(lsSQL)
                                        Otrans.Actualiza(lsSQL)
                                        guardarAviso(Otrans.descripcion_error, 31)
                                    Else
                                        Dim lsSQL2 As String = ""
                                        Try

                                            Dim DtCliente As DataTable
                                            lsSQL2 = "pa_sel_um_ctacte '" & psEmpresa & "','CLIENTE','" & drv.Item("ctacte") & "'"
                                            DtCliente = Otrans.Obtiene(lsSQL2)
                                            If DtCliente.Rows(0).Item("AnalisisCtaCte25").ToString.Trim.Length = 0 Then
                                                clsGen.Escribir_Log(lsSQL2)
                                                Otrans.Actualiza(lsSQL)
                                            End If

                                        Catch ex As Exception
                                            clsGen.Escribir_Log(ex.ToString)
                                            clsGen.Escribir_Log(lsSQL)
                                            clsGen.Escribir_Log(lsSQL2)

                                        End Try

                                    End If
                                    If drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("walmart") > 0 Or _
                                         drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("consolidado") > 0 Then
                                        'Los Pedidos de WalMart No deben Generar Picking por eso se llena la Informacion con picker en Blanco
                                        lsSQL = "pa_ins_um_gen_log_documento_tracking  '" & _
                                                    psEmpresa & "','" & drv.Item("serieFACE") & _
                                                    "','" & drv.Item("numeroFACE") & "','" & psUsuario & "','" & _
                                                      "', NULL"
                                        Otrans.Ingresa(lsSQL)
                                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)

                                        ''Actualizo el log pedido walmart a facturado
                                        '(c)06052015
                                        lsSQL = "pa_upd_um_gen_log_documento_face_walmart_facturado '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "'"

                                        Otrans.Actualiza(lsSQL)

                                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)
                                    End If

                                    lsSQL = "pa_upd_um_gen_log_documento_face_proceso '" & psEmpresa & "','" & _
                                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "'"

                                    Otrans.Actualiza(lsSQL)

                                    If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)


                                    If drv.Item("tipodoctoOrigen").ToString.ToLower.StartsWith("pedido consol") Then
                                        ''Debo correr el Script del pedido Consolidad0

                                        Dim dtConsolidado As DataTable
                                        lsSQL = "pa_var_um_documento_pedido_consolidado '" & psEmpresa & "','" & drv.Item("tipodoctoOrigen") & "','" & _
                                            drv.Item("numero") & "'"

                                        dtConsolidado = Otrans.Obtiene(lsSQL)
                                        For Each drConsolidado As DataRow In dtConsolidado.Rows
                                            lsSQL = "pa_upd_um_documento_estado '" & psEmpresa & "','" & _
                                           drConsolidado.Item("tipodocto") & "','" & drConsolidado.Item("numero") & "',NULL,'A','" & _
                                           psUsuario & "','" & drv.Item("serieFACE") & " " & drv.Item("numeroFACE") & "'"
                                            Otrans.Actualiza(lsSQL)

                                        Next

                                        ''La nueva factura debe afectrar inventario
                                        lsSQL = "pa_upd_um_documento_consolidado '" & psEmpresa & "','" & _
                                                           drv.Item("serieFACE") & _
                                                    "','" & drv.Item("numeroFACE") & "'"
                                        Otrans.Actualiza(lsSQL)

                                    End If
                                    ''Llamar al Reporte
                                    Try

                                        Dim pm_valores(3), pm_valores_consolidado(2) As String
                                        Dim pm_parametros(3) As String
                                        Dim pm_conexion(3) As String


                                        pm_conexion = clsGen.Parametros_Conexion("")
                                        Dim ppath_reporte As String = clsGen.Path_Reporte

                                        ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                                        ppath_reporte += psEmpresa.ToLower.Trim + " "
                                        ppath_reporte += drv.Item("serieFACE").ToString.Trim
                                        ppath_reporte += ".rpt"
                                        pm_parametros(0) = "empresa"
                                        pm_parametros(1) = "tipodocto"
                                        pm_parametros(2) = "numero"
                                        pm_parametros(3) = "user_name"
                                        pm_valores(0) = psEmpresa
                                        pm_valores(1) = drv.Item("serieFACE")
                                        pm_valores(2) = drv.Item("numeroFACE")
                                        pm_valores(3) = "GUATE_FTP"

                                        'Guardo las copias en pdf

                                        Dim ncopias As Integer
                                        ncopias = clsGen.numeroCopias(psEmpresa, drv.Item("ctacte"), drv.Item("forma_pago").ToString, _
                                                                      IIf(drv.Item("tipodoctoOrigen").ToString.LastIndexOf("RE") > 0, 1, 0), drv.Item("serieFACE"))


                                        ''Revisar Impresora a Imprimir

                                        Try

                                            dtImpresoras = clsGen.selectQuery("FlexLine", _
                                                                              "pa_sel_um_gen_tabcod '" & drv.Item("tipodoctoOrigen") & "','gen_impresion','" & psEmpresa & "'")

                                            If dtImpresoras.Rows.Count = 1 Then
                                                If dtImpresoras.Rows(0).Item("valor1") = 1 Then drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")

                                            End If
                                        Catch ex As Exception

                                        End Try


                                        If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then ncopias = 1

                                        If ncopias > 0 Then
                                            '_reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
                                            'pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                            '    False, True, "PDF", False, "", True, ncopias, psEmpresa, drv.Item("ImpresoraFACE").ToString)


                                        End If

                                        If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then 'Si El Pedido Lleva Bodega debe Realizar un Ingreso a la Bodega
                                            lsSQL = "flexline.spa_Convierte_FactVtas_Compras '" & psEmpresa & "','" & _
                                                        drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
                                                        drv.Item("bodegaInterEmpresas") & "','ADMIN_ISF'"

                                            If Otrans.Ingresa(lsSQL) > 0 Then 'Si se realizo el SP
                                                clsGen.Escribir_Log("Enviar Impresion Ingreso " & psEmpresa)
                                                ppath_reporte = clsGen.Path_Reporte
                                                ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Compras.rpt"
                                                Dim pm_parametros2(3) As String
                                                Dim pm_valores2(3) As String

                                                clsGen.Escribir_Log("Inicializo Parametros " & psEmpresa)
                                                pm_parametros2(0) = "@Empresa"
                                                pm_parametros2(1) = "@Tipodocto"
                                                pm_parametros2(2) = "@Numero"
                                                pm_parametros2(3) = "@Proveedor"

                                                clsGen.Escribir_Log("Inicializo Valores " & psEmpresa)
                                                pm_valores2(0) = psEmpresa
                                                If drv.Item("ctacte").ToString.StartsWith("12218") Then
                                                    pm_valores2(0) = "DMARTE1"
                                                ElseIf drv.Item("ctacte").ToString.StartsWith("7951") Then
                                                    pm_valores2(0) = "CODICASA"
                                                ElseIf drv.Item("ctacte").ToString.StartsWith("6608") Then
                                                    pm_valores2(0) = "DIUVA"
                                                ElseIf drv.Item("ctacte").ToString.StartsWith("2968") Then
                                                    pm_valores2(0) = "VINOTECA"
                                                End If

                                                clsGen.Escribir_Log("Parametros0 " & pm_valores2(0))
                                                If drv.Item("serieFACE").ToString.ToUpper.IndexOf("FECAM") > 0 Then
                                                    pm_valores2(1) = "FECAM DE COMPRAS" '' drv.Item("serieFACE")
                                                Else
                                                    pm_valores2(1) = "FACE DE COMPRAS" '' drv.Item("serieFACE")
                                                End If

                                                pm_valores2(2) = drv.Item("numeroFACE")
                                                clsGen.Escribir_Log("Parametros1 " & pm_valores2(1))
                                                clsGen.Escribir_Log("Parametros2 " & pm_valores2(2))

                                                If psEmpresa.ToLower.Equals("dmarte1") Then
                                                    pm_valores2(3) = "122183"
                                                ElseIf psEmpresa.ToLower.Equals("codicasa") Then
                                                    pm_valores2(3) = "79512"
                                                ElseIf psEmpresa.ToLower.Equals("diuva") Then
                                                    pm_valores2(3) = "6608388"
                                                End If

                                                'Los Ingresos Interempresas se imprimen en la misma impresora de facturas


                                                clsGen.Escribir_Log("Parametros3 " & pm_valores2(3))


                                                '(c) 20160916 Se Cambio la Cantidad de Copias a 1 en InterEmpresas
                                                '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                '        False, True, "PDF", False, "", True, 1, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)


                                            End If 'realiza el ingreso
                                        End If 'bodega Interempresa

                                        ''Forma de Pago
                                        If drv.Item("forma_pago").ToString.ToLower.StartsWith("contado") And drv.Item("tipodoctoOrigen").ToString.ToUpper = "PEDIDO FACE" Then

                                            'lsSQL = flexline.spa_RecibosGuarda @Empresa varchar(20),@Tipodocto varchar(40), @Numero varchar(20)
                                            lsSQL = " flexline.spa_RecibosGuarda '" & psEmpresa & "','" & drv.Item("serieFACE").ToString & "','" & drv.Item("numeroFACE").ToString & "'"
                                            If Otrans.Ingresa(lsSQL) > 0 Then
                                                ppath_reporte = clsGen.Path_Reporte
                                                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

                                                Dim pm_parametros2(2) As String
                                                Dim pm_valores2(2) As String

                                                pm_parametros2(0) = "Empresa"
                                                pm_parametros2(1) = "Tipodocto"
                                                pm_parametros2(2) = "Numero"

                                                pm_valores2(0) = psEmpresa
                                                pm_valores2(1) = drv.Item("serieFACE")
                                                pm_valores2(2) = drv.Item("numeroFACE")


                                                Try
                                                    ncopias = 1
                                                    dtImpresoras = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod 'recibos','gen_impresion','" & psEmpresa & "'")

                                                    If dtImpresoras.Rows.Count = 1 Then
                                                        If dtImpresoras.Rows(0).Item("valor1") = 1 Then
                                                            drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")
                                                            ncopias = 2
                                                        End If


                                                    End If
                                                Catch ex As Exception

                                                End Try

                                                pm_conexion = clsGen.Parametros_Conexion("SCM")
                                                '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                '        False, True, "PDF", False, "", True, 1, psEmpresa, drv.Item("ImpresoraFACE").ToString)

                                                '(c) 20150522
                                                'Envio 2 veces la impresion por incompatibilidad del server donde esta alojado
                                                '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                '        False, True, "PDF", False, "", True, 1, psEmpresa, drv.Item("ImpresoraFACE").ToString)

                                            End If

                                        End If 'forma Pago


                                        'Abro las Nota de Credito Face para que puedan reporcesar
                                        If drv.Item("tipodoctoOrigen").ToString.ToUpper = "NOTA CREDITO FACE" Then

                                            ''Anulo el Documento Anterior ''Pruebas No lo debo realizar
                                            lsSQL = "pa_upd_um_documento_estado '" & psEmpresa & "','" & _
                                                    drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "',NULL,'S','" & _
                                                    psUsuario & "','" & drv.Item("tipodoctoOrigen") & " " & drv.Item("numero") & "'"


                                            Otrans.Actualiza(lsSQL)
                                            If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)
                                        End If


                                    Catch ex As Exception

                                    End Try
                                End If
                            End If
                            'End If 'false
                        Next
                    End If 'Validacion de totales








                End If 'dtDocumentos.DefaultView.Count = 1

            Else 'No Encontro el Documento (c) 20160201 'El XML Traer Error
                'Dim xmlDoc As New XmlDocument()
                'xmlDoc.Load(psArchivo)


                '' Now create StringWriter object to get data from xml document.
                'Dim sw As New StringWriter()
                'Dim xw As New XmlTextWriter(sw)
                'xmlDoc.WriteTo(xw)
                'Dim XmlString As String = sw.ToString()


                ''Almacenar Informacion del Error

                ''psInformacionPedido

                'lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                '        psInformacionPedido.ToString.Split("-")(0) & "','" & _
                '        psInformacionPedido.ToString.Split("-")(1) & "','" & _
                '        XmlString.Substring(XmlString.IndexOf("<Resultado>")).ToString.Replace("Resultado>", "").Replace("<", "") & "'"


                ''drResultado.Item("Referencia").ToString.Split("-")(0) & "','" & drResultado.Item("Referencia").ToString.Split("-")(1) & "','Diferencia En Los Totales Flex-GuateFacturas'"
                'Otrans.Actualiza(lsSQL)


            End If 'lodsXML.Tables.Contains("Resultado")
        Catch ex As Exception
            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    ''Todo los problemas que existan se genera un Aviso con el Codigo 31
    Private Sub guardarAviso(ByVal psComentario As String, ByVal piIdAviso As Integer)


        Dim clsgen As New ClasesGenerales.General
        Dim dtAvisos As DataTable
        'Dim iidAviso As Integer = 31
        dtAvisos = clsgen.usuariosAviso(piIdAviso)
        For Each dr As DataRow In dtAvisos.Rows
            clsgen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Factura Electronica " & _
                                psComentario, piIdAviso)

        Next
        clsgen = Nothing
    End Sub

    Private Sub crear_estructuraFACE(ByRef odsFACE As DataSet)
        Dim dt As DataTable

        odsFACE = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
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
        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("procesado", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("MaquinaFace", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas
        dt.Columns.Add(New DataColumn("Comuna", GetType(String))) '(c)230315 Campo para informacion walmart 
        dt.Columns.Add(New DataColumn("Estado", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("Numero_Recepcion_Walmart", GetType(String))) '(c)230315 Campo para informacion walmart



        odsFACE.Tables.Add(dt)

        ' Me.dgv_pedidosFACE.DataSource = odsFACE.Tables("pedidos")

    End Sub

End Class
