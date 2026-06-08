Imports System.IO
Public Class frm_recepcion_mercaderia_vinoteca
    Dim Ods As DataSet


    Private Sub crearEstructura()
        Ods = New DataSet
        Dim dt As New DataTable("detalle_traslado")

        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("motivo", GetType(String)))
        dt.Columns.Add(New DataColumn("codigomotivo", GetType(String)))
        dt.Columns.Add(New DataColumn("secuenciaOrigen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fechavcto", GetType(String)))
        dt.Columns.Add(New DataColumn("precio", GetType(Double)))
        dt.Columns.Add(New DataColumn("tipodoctoGenerado", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativoGenerado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("SecuenciaGenerado", GetType(Integer)))





        Ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub llenarCombos()

        Dim clsgen As New ClasesGenerales.General

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dt2 As DataTable

        Try
            lsSQL = "pa_sel_um_tipodocumento_usuario '" & gs_empresa & "','Salida (i)',null,'" & gs_usuario & "'"
            clsgen.fillComboBox(Otrans, lsSQL, "tipodocumento", "tipoDocto", "tipoDocto", cmbTipoDoctoOrigen)


            'lsSQL = "pa_sel_um_gen_tabcod null,'gen_bodega','" & gs_empresa & "'"
            'clsgen.fillComboBox(Otrans, lsSQL, "bodega", "CODIGO", "CODIGO", cmbBodega)

            'If gs_empresa = "VINOTECA" Then ''Cambio solicitado para que solo los dueños de las salas envien a sus tiendas (c) 28012015
            'lsSQL = "pa_sel_um_usuario_bodega '" & gs_empresa & "','SOLICITUD O/COMPRA','" & gs_usuario & "'"
            'dt = Otrans.Obtiene(lsSQL)
            'Me.cmbBodega.DataSource = dt
            'Me.cmbBodega.DisplayMember = "ubicacion"
            'Me.cmbBodega.ValueMember = "bodega"






            'lsSQL = "pa_sel_um_tipodocumento_usuario '" & gs_empresa & "','entrada (i)',null,'" & gs_usuario & "'"
            'dt = clsgen.selectQuery("FlexLine", lsSQL)


            ''DefaultView.RowFilter = "Bodega = '" & drBodega.Item("Bodega").ToString & "'"
            'dt.DefaultView.RowFilter = "tipodocto like '%entrada traslado%'"

            'If dt.DefaultView.Count > 1 Then
            '    MessageBox.Show("Su Usario Tiene Asignado Mas de Un Tipo de Documento de Entrada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.btnGuardar.Visible = False
            '    'Me.txtTipoDoctoDestino.Text = dt.DefaultView(0).Item("tipodocto").ToString
            'ElseIf dt.DefaultView.Count = 0 Then
            '    MessageBox.Show("Su Usario no tiene Asignado Tipo de Documento de Entrada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.btnGuardar.Visible = False
            'Else
            '    Me.txtTipoDoctoDestino.Text = dt.DefaultView(0).Item("tipodocto").ToString
            'End If


            ''Llenar Bodega

            ''Cambio solicitado para que solo los dueños de las salas envien a sus tiendas (c) 28012015
            lsSQL = "pa_sel_um_usuario_bodega '" & gs_empresa & "','SOLICITUD O/COMPRA','" & gs_usuario & "'"
            dt = clsgen.selectQuery("FlexLine", lsSQL)

            If dt.Rows.Count > 1 Then
                MessageBox.Show("Tiene mas de Una Bodega Asignada, No Puede Utilizar esta Opcion", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.txtBodegaDestino.Text = dt.Rows(0).Item("Bodega").ToString
            End If


        Catch ex As Exception
            clsgen.Escribir_Log(ex.ToString)
        Finally
            'Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try

    End Sub


    Private Sub buscarDocumento()

        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try
            lsSQL = "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.SelectedValue & "','" & Me.txtNumeroOrigen.Text & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("vigencia").ToString.ToUpper = "A" Then
                    MessageBox.Show("Documento Anulado, No Se Puede Operar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Try
                    'ElseIf dt.Rows(0).Item("aprobacion").ToString.ToUpper = "P" Then
                    '    MessageBox.Show("Documento Pendiente de Aprobacion, No Se Puede Operar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Try
                End If
                If Val(dt.Rows(0).Item("porcentajeasignado").ToString) > 0 Then
                    MessageBox.Show("Documento Asignado Previamente, No Se Puede Operar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Try

                End If


                dt.TableName = "documento"
                If Ods.Tables.Contains("documento") Then Ods.Tables.Remove("documento")
                Ods.Tables.Add(dt.Copy)
                Me.dgvDetalleDocumento.DataSource = Ods.Tables("documento")
                clsGen.Alinear_GridView(Ods.Tables("documento"), dgvDetalleDocumento, ",producto,glosa,cantidad,precio,lote,fechavctod,", "", ",producto,glosa,cantidad,precio,lote,fechavctod,", "", "", "", ",producto,glosa,cantidad,precio,", True, True, 250, 0)
                If dt.Rows.Count > 0 Then
                    Me.txtBodega.Text = dt.Rows(0).Item("Bodega")
                    Me.txtGlosaDocto.Text = dt.Rows(0).Item("glosa_docto")
                    Me.txtFecha.Text = dt.Rows(0).Item("fecha")
                    Me.txtComentario1.Text = dt.Rows(0).Item("comentario1").ToString
                End If
            Else
                MessageBox.Show("Documento No Existe, Por Favor Verifique", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        Finally
            clsGen = Nothing
        End Try

    End Sub

    'Private Sub agregarLinea()
    '    Dim clsGen As New ClasesGenerales.General

    '    Try
    '        If Val(Me.txtCantidad.Text) > 0 Then


    '            Dim dr As DataRow
    '            dr = Ods.Tables("detalle_traslado").NewRow
    '            dr.Item("cantidad") = Me.txtCantidad.Text
    '            'dr.Item("bodega") = Me.cmbBodega.SelectedValue
    '            dr.Item("producto") = Me.txtCodigoProducto.Text
    '            dr.Item("glosa") = Me.txtGlosa.Text
    '            dr.Item("lote") = Me.txtLote.Text
    '            dr.Item("fechavcto") = Me.txtFechaVcto.Text
    '            dr.Item("secuenciaOrigen") = Me.lblSecuenciaOrigen.Text
    '            dr.Item("codigomotivo") = Me.cmbMotivoInternacion.SelectedValue
    '            dr.Item("motivo") = Me.cmbMotivoInternacion.Text
    '            dr.Item("precio") = Me.txtPrecio.Text


    '            Ods.Tables("detalle_traslado").Rows.Add(dr)
    '            Me.dgvTraslado.DataSource = Ods.Tables("detalle_traslado")
    '            clsGen.Alinear_GridView(Ods.Tables("detalle_traslado"), Me.dgvTraslado, "", ",lote,motivo,precio,codigomotivo,secuenciaOrigen,", ",producto,glosa,", "", "", "", "", True, True, 150, 0)
    '            limpiarProducto()
    '        End If

    '    Catch ex As Exception
    '    Finally
    '        clsGen = Nothing
    '    End Try
    'End Sub


    'Private Function realizarSalida(ByRef psTipoDocto As String, ByRef psNumeroDocto As String, ByRef piCorrelativo As Integer) As Integer


    '    Dim Otrans As New Transaccional.Conexion("FlexLine")

    '    Dim Oflex As New Umbral_Flex.Pedidos(False, True)

    '    Oflex.Validar_Totales = False


    '    Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()

    '    Dim dr, ofila As DataRow
    '    Dim li_linea As Integer = 0
    '    Dim ls_pedido_generado As Integer = 0
    '    Dim s_empresa As String = String.Empty
    '    Dim proceso_exitoso As Boolean = False
    '    Dim pd_total_pedido As Double = 0
    '    Dim forma_pago As String = String.Empty
    '    Dim sTipoDocto As String
    '    ''Dim drEncabezado As DataRow

    '    Dim lsSQL As String
    '    Dim esDevolucionRefactura As Boolean = False


    '    'drEncabezado = dt.Rows(0)
    '    s_empresa = gs_empresa ' drEncabezado.Item("empresa").ToString


    '    If s_empresa = "VINOTECA" Then
    '        sTipoDocto = "SALIDA DE PRODUCTO INVENTARIO"
    '    End If

    '    Otrans.open()


    '    dr = Oflex.ods.Tables("encabezado").NewRow

    '    dr.Item("Empresa") = s_empresa
    '    dr.Item("tipodocto") = sTipoDocto
    '    dr.Item("correlativo") = 0
    '    dr.Item("CtaCte") = String.Empty
    '    dr.Item("numero") = ""
    '    dr.Item("fecha") = Today.ToString("dd-MM-yyyy")
    '    dr.Item("proveedor") = String.Empty
    '    dr.Item("cliente") = String.Empty
    '    dr.Item("bodega") = Me.txtBodega.Text
    '    dr.Item("bodega2") = String.Empty
    '    dr.Item("local") = String.Empty
    '    dr.Item("comprador") = String.Empty
    '    dr.Item("vendedor") = String.Empty
    '    dr.Item("CentroCosto") = String.Empty
    '    dr.Item("fechaVcto") = "01/01/1900"
    '    dr.Item("listaPrecio") = String.Empty
    '    'dr.Item("Analisis") = "piloto"
    '    dr.Item("Zona") = String.Empty
    '    dr.Item("tipocta") = "VEHICULO PENDIENTE"
    '    dr.Item("moneda") = "QUETZALES"
    '    dr.Item("paridad") = 1
    '    dr.Item("neto") = 0
    '    dr.Item("subtotal") = 0
    '    dr.Item("total") = pd_total_pedido
    '    dr.Item("NetoIngreso") = 0
    '    dr.Item("SubTotalIngreso") = 0
    '    dr.Item("TotalIngreso") = 0
    '    dr.Item("centraliza") = String.Empty
    '    dr.Item("valoriza") = String.Empty
    '    dr.Item("costeo") = String.Empty
    '    dr.Item("aprobacion") = "S"
    '    dr.Item("TipoComprobante") = String.Empty
    '    dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
    '    dr.Item("FactorMonto") = 0
    '    dr.Item("TipoCtaCte") = String.Empty
    '    dr.Item("IdCtaCte") = String.Empty
    '    dr.Item("Glosa") = "Referencia " & Me.txtTipoDoctoDestino.Text & "-" & Me.txtNumeroDestino.Text  'drEncabezado.Item("TipoDoctoFactura") & "-" & drEncabezado.Item("NumeroFactura") 'Validar Glosa
    '    dr.Item("comentario1") = String.Empty 'drEncabezado.Item("comentario1").ToString
    '    dr.Item("comentario2") = String.Empty
    '    dr.Item("vigencia") = "S"
    '    dr.Item("Emitido") = "N"
    '    dr.Item("PorcentajeAsignado") = 0
    '    dr.Item("direccion") = String.Empty 'drEncabezado.Item("direccion").ToString
    '    dr.Item("ciudad") = String.Empty
    '    dr.Item("comuna") = String.Empty
    '    dr.Item("EstadoDir") = String.Empty
    '    dr.Item("pais") = String.Empty
    '    dr.Item("contacto") = String.Empty
    '    dr.Item("FechaModif") = Now
    '    dr.Item("FechaUModif") = Now
    '    dr.Item("UsuarioModif") = gs_usuario 'drEncabezado.Item("UsuarioRecepcion").ToString.ToUpper '"Admin" 03Junio2014
    '    dr.Item("Hora") = Now.ToString("HH:mm:ss")
    '    dr.Item("NetoBimoneda") = 0
    '    dr.Item("SubTotalBimoneda") = 0
    '    dr.Item("TotalBimoneda") = 0
    '    dr.Item("ParidadBimoneda") = 1
    '    dr.Item("AnalisisE1") = String.Empty
    '    dr.Item("AnalisisE2") = String.Empty
    '    dr.Item("AnalisisE3") = String.Empty
    '    dr.Item("UsuarioAprueba") = String.Empty
    '    dr.Item("referenciaexterna") = "0" 'drEncabezado.Item("correlativo") //Rechazos No Aplica
    '    dr.Item("Analisis") = String.Empty
    '    dr.Item("TipoCta") = String.Empty

    '    Oflex.ods.Tables("encabezado").Rows.Add(dr)



    '    Dim iCount As Integer = 0

    '    Dim ldSubTotal As Double = 0
    '    ''DocumentoD
    '    For Each ofila In Ods.Tables("detalle_traslado").Rows


    '        iCount += 1
    '        dr = Oflex.ods.Tables("detalle").NewRow

    '        dr.Item("Empresa") = s_empresa
    '        dr.Item("tipodocto") = sTipoDocto
    '        dr.Item("Secuencia") = iCount 'ofila.Item("secuenciaFactura") 'iCount


    '        ofila.Item("secuenciaGenerado") = iCount
    '        ofila.Item("TipoDoctoGenerado") = sTipoDocto

    '        dr.Item("Linea") = iCount 'ofila.Item("secuenciaFactura") 'iCount
    '        dr.Item("Producto") = ofila.Item("producto")
    '        dr.Item("Cantidad") = ofila.Item("cantidad")
    '        dr.Item("Precio") = ofila.Item("precio") ''Precio de La factura Original
    '        dr.Item("PorcentajeDr") = 0 'ofila.Item("PorcentajeDRFactura")
    '        dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
    '        dr.Item("Impuesto") = 0
    '        dr.Item("Neto") = dr.Item("SubTotal")
    '        dr.Item("DRGlobal") = 0
    '        dr.Item("Costo") = 0


    '        Try
    '            'Debo Buscar Costo
    '            '(c) 0709
    '            dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
    '        Catch ex As Exception
    '            dr.Item("Costo") = 0
    '        End Try
    '        'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
    '        dr.Item("Total") = dr.Item("Neto")
    '        dr.Item("PrecioAjustado") = dr.Item("precio")
    '        dr.Item("UnidadIngreso") = "UN"
    '        dr.Item("CantidadIngreso") = ofila.Item("cantidad")
    '        dr.Item("PrecioIngreso") = dr.Item("precio")
    '        dr.Item("SubTotalIngreso") = dr.Item("Total")
    '        dr.Item("ImpuestoIngreso") = 0
    '        dr.Item("NetoIngreso") = dr.Item("SubTotalIngreso")
    '        dr.Item("DRGlobalIngreso") = 0
    '        dr.Item("TotalIngreso") = dr.Item("Total")
    '        Try
    '            If ofila.Item("lote").ToString.Trim.Length = 0 Then
    '                dr.Item("Lote") = System.DBNull.Value
    '                dr.Item("fechavcto") = System.DBNull.Value
    '            Else
    '                dr.Item("Lote") = ofila.Item("lote")
    '                dr.Item("fechavcto") = ofila.Item("fechavcto")
    '            End If
    '        Catch ex As Exception

    '        End Try

    '        dr.Item("TipoDoctoOrigen") = Me.cmbTipoDoctoOrigen.SelectedValue 'ofila.Item("TipoDoctoFactura")
    '        dr.Item("CorrelativoOrigen") = Ods.Tables("documento").Rows(0).Item("correlativo")
    '        dr.Item("SecuenciaOrigen") = ofila.Item("secuenciaOrigen")
    '        dr.Item("Bodega") = Me.txtBodega.Text  'Debo tomar la bodega del documento original
    '        dr.Item("FactorInventario") = -1


    '        dr.Item("FechaEntrega") = Today
    '        dr.Item("CantidadAsignada") = 0
    '        dr.Item("Fecha") = Today
    '        dr.Item("comentario") = ofila.Item("bodega").ToString 'La bodega va como comentario
    '        dr.Item("Vigente") = "S"

    '        dr.Item("CUP") = dr.Item("costo")
    '        dr.Item("Ubicacion") = "PRINCIPAL"
    '        dr.Item("Ubicacion2") = "PRINCIPAL"
    '        dr.Item("cuenta") = String.Empty
    '        dr.Item("FactorImpto") = 1
    '        dr.Item("PrecioBimoneda") = dr.Item("precio")
    '        dr.Item("SubTotalBimoneda") = dr.Item("subtotal")
    '        dr.Item("ImpuestoBimoneda") = 0
    '        dr.Item("NetoBimoneda") = dr.Item("Neto")
    '        dr.Item("DrGlobalBimoneda") = 0
    '        dr.Item("TotalBimoneda") = dr.Item("Total")
    '        Try
    '            dr.Item("PrecioListaP") = ofila.Item("precioListaP")
    '            dr.Item("FechaVigenciaLp") = String.Empty 'ofila.Item("FechaVigenciaLp")
    '        Catch ex As Exception
    '            dr.Item("PrecioListaP") = 0
    '        End Try

    '        dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")

    '        dr.Item("LoteDestino") = String.Empty
    '        dr.Item("SerieDestino") = String.Empty
    '        dr.Item("ProdAlias") = String.Empty
    '        dr.Item("DoctoOrigenVal") = "S"
    '        dr.Item("MontoAsignado") = 0
    '        dr.Item("Aux_Valor14") = ofila.Item("codigomotivo")

    '        dr.Item("ValPorcentajeDr1") = 0
    '        dr.Item("ValPorcentajeDr2") = 0
    '        dr.Item("ValPorcentajeDr3") = 0
    '        dr.Item("ValPorcentajeDr4") = 0
    '        dr.Item("ValPorcentajeDr5") = 0
    '        dr.Item("ValPorcentajeDr1Ingreso") = 0
    '        dr.Item("ValPorcentajeDr2Ingreso") = 0
    '        dr.Item("ValPorcentajeDr3Ingreso") = 0
    '        dr.Item("ValPorcentajeDr4Ingreso") = 0
    '        dr.Item("ValPorcentajeDr5Ingreso") = 0
    '        dr.Item("ValPorcentajeDr1Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr2Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr3Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr4Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr5Bimoneda") = 0

    '        Oflex.ods.Tables("detalle").Rows.Add(dr)
    '        ldSubTotal = ldSubTotal + dr.Item("SubTotal")
    '    Next

    '    Try

    '        Oflex.ods.Tables("encabezado").Rows(0).Item("total") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalIngreso") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalBimoneda") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoBimoneda") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotal") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalBimoneda") = ldSubTotal / 1.12


    '    Catch ex As Exception

    '    End Try

    '    ls_pedido_generado = Oflex.Guardar_Documento()
    '    If ls_pedido_generado > 0 Then
    '        psNumeroDocto = Oflex.ods.Tables("encabezado").Rows(0).Item("Numero")
    '        psTipoDocto = Oflex.ods.Tables("encabezado").Rows(0).Item("tipoDocto")
    '        piCorrelativo = ls_pedido_generado
    '        Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & gs_empresa & "','" & psTipoDocto & "'")

    '    End If
    '    Otrans.close()
    '    Otrans = Nothing

    '    Try
    '        'Imprimir Documento
    '        imprimirDocumento(psTipoDocto, psNumeroDocto)

    '        'Sincronizar Documento
    '        MessageBox.Show("Sincronizar Documento")
    '    Catch ex As Exception

    '    End Try

    '    Return ls_pedido_generado
    'End Function


    'Private Sub realizarIngresoVinoteca()

    '    'Ingreso de Mercaderia debo realizar varios
    '    Dim clsGen As New ClasesGenerales.General
    '    Dim dt, dtBodega As DataTable
    '    Dim lsSQL As String
    '    Dim Oflex As Umbral_Flex.Pedidos
    '    Dim Otrans As New Transaccional.Conexion("FlexLine")

    '    Try
    '        Otrans.open()




    '        ''Debo generar el nuevo numero

    '        lsSQL = "pa_var_um_tipodocumento_correlativo '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "'"
    '        dt = Otrans.Obtiene(lsSQL)
    '        Me.txtNumeroDestino.Text = (dt.Rows(0).Item("correlativoactual") + 1).ToString.PadLeft(10, "0")

    '        ''Guardo los documentos

    '        lsSQL = "pa_ins_um_documento_traslado_VINOTECA '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.Text & "','" & Me.txtNumeroOrigen.Text & "','" &
    '                Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "','" &
    '                Me.txtComentario1.Text & "','" & Me.txtGlosa.Text & "','" &
    '                Me.txtBodegaDestino.Text & "','" & gs_usuario & "'"

    '        If Otrans.Ingresa(lsSQL) > 0 Then

    '            lsSQL = "pa_ins_um_documentod_traslado_vinoteca '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.Text & "','" & Me.txtNumeroOrigen.Text & "','" &
    '                Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "','" &
    '                Me.txtBodegaDestino.Text & "'"

    '            If Otrans.Ingresa(lsSQL) > 0 Then

    '                Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "'")

    '                Try
    '                    'Sincronizar hacia la tienda

    '                    'Imprimir Documento
    '                    'imprimirDocumento(sTipoDocto, Oflex.ods.Tables("encabezado").Rows(0).Item("Numero"))

    '                    Dim oScn As New Sincronizacion.Documentos(Me.txtBodegaDestino.Text)
    '                    Try
    '                        If oScn.codigo_error > 0 Then
    '                            MessageBox.Show(oScn.descripcion_error, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        Else

    '                            Dim pdataset As New DataSet
    '                            lsSQL = "pa_var_um_documento '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "'"
    '                            dt = Otrans.Obtiene(lsSQL)
    '                            dt.TableName = "encabezado_documento"
    '                            pdataset.Tables.Add(dt.Copy)
    '                            'Me.txt_codcliente.Text = dt.Rows(0).Item("cliente")
    '                            'Me.txt_piloto.Text = dt.Rows(0).Item("razonsocial").ToString.Trim
    '                            'If Me.txt_codcliente.Text.Length = 0 Then
    '                            ' Me.txt_codcliente.Text = dr.Item("proveedor").ToString
    '                            ' Me.txt_piloto.Text = dr.Item("razonSocial").ToString
    '                            'End If
    '                            'Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
    '                            'Me.SBP_panel1.Text = "Usuario Grabo .:: " & dt.Rows(0).Item("UsuarioModif")


    '                            'Obtengo DocumentoD
    '                            lsSQL = "pa_var_um_documentod '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "'"
    '                            dt = Otrans.Obtiene(lsSQL)
    '                            dt.TableName = "documentod"
    '                            pdataset.Tables.Add(dt.Copy)

    '                            'Obtengo DocumentoV
    '                            lsSQL = "pa_var_um_documentov '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "'  "
    '                            dt = Otrans.Obtiene(lsSQL)
    '                            dt.TableName = "documentov"
    '                            pdataset.Tables.Add(dt.Copy)

    '                            'Obtengo DocumentoP
    '                            lsSQL = "pa_var_um_documentop '" & gs_empresa & "','" & Me.txtTipoDoctoDestino.Text & "','" & Me.txtNumeroDestino.Text & "'"
    '                            dt = Otrans.Obtiene(lsSQL)
    '                            dt.TableName = "documentop"
    '                            pdataset.Tables.Add(dt.Copy)


    '                            oScn.Enviar_Documento_Tienda(gs_empresa, pdataset.Tables("encabezado_documento").Rows(0),
    '                                             pdataset.Tables("documentod"), pdataset.Tables("documentov"), pdataset.Tables("documentop"), "", True)

    '                            If oScn.codigo_error > 0 Then
    '                                MessageBox.Show(oScn.descripcion_error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            Else
    '                                MessageBox.Show("Sincronizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                                ''Limpiar_Forma()
    '                            End If
    '                        End If

    '                    Catch ex As Exception
    '                    Finally
    '                        oScn.Cerrar()
    '                        oScn = Nothing
    '                    End Try


    '                Catch ex As Exception

    '                End Try

    '                'Actualizo Previos

    '                Try

    '                    'Obtengo DocumentoD
    '                    lsSQL = "pa_var_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.Text & "','" & Me.txtNumeroOrigen.Text & "'"
    '                    dt = Otrans.Obtiene(lsSQL)
    '                    For Each dr As DataRow In dt.Rows

    '                        lsSQL = "pa_upd_um_documentod_asignado_traslados '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "'," &
    '                                dr.Item("correlativo") & ",'" & dr.Item("producto").ToString & "'," & dr.Item("secuencia") & ",'" & gs_usuario & "'"
    '                        clsGen.insertQuery("FlexLine", lsSQL)




    '                    Next

    '                Catch ex As Exception

    '                End Try
    '            End If



    '        End If




    '    Catch ex As Exception
    '    Finally
    '        clsGen = Nothing
    '        Otrans.close()
    '        Otrans = Nothing
    '    End Try



    'End Sub



    Private Sub realizarIngreso(psTipodoctoSalida As String, psNumeroSalida As String, piCorrelativoSalida As Integer)

        'Ingreso de Mercaderia debo realizar varios
        Dim clsGen As New ClasesGenerales.General
        Dim dt, dtBodega As DataTable
        Dim lsSQL As String
        Dim Oflex As Umbral_Flex.Pedidos
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()

            dtBodega = clsGen.ValoresDistinto(Ods.Tables("detalle_traslado"), "bodega".Split(","))

            ''Realiza un Ingreso por Bodega
            For Each drBodega As DataRow In dtBodega.Rows

                Oflex = New Umbral_Flex.Pedidos(False, True)
                Oflex.Validar_Totales = False


                Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()

                Dim dr As DataRow
                Dim li_linea As Integer = 0
                Dim ls_pedido_generado As Integer = 0
                Dim s_empresa As String = String.Empty
                Dim proceso_exitoso As Boolean = False
                Dim pd_total_pedido As Double = 0
                Dim forma_pago As String = String.Empty
                Dim sTipoDocto As String
                ''Dim drEncabezado As DataRow


                s_empresa = gs_empresa ' drEncabezado.Item("empresa").ToString

                If s_empresa = "DMARTE1" Then
                    sTipoDocto = "ENTRADA DE PRODUCTO INVENTARIO"
                ElseIf s_empresa = "CODICASA" Then
                    sTipoDocto = "ENTRADA DE PRODUCTO INVENTARIO"
                ElseIf s_empresa = "DIUVA" Then
                    sTipoDocto = "ENTRADA DE PRODUCTO INVENTARIO"
                ElseIf s_empresa = "VINOTECA" Then
                    sTipoDocto = "ENTRADA DE PRODUCTO INVENTARIO"
                End If
                'forma_pago = drEncabezado.Item("forma_pago").ToString



                'osinc.Llenar_Auxiliares(ods, drEncabezado.Item("ctacte"), s_empresa)
                'osinc = Nothing


                dr = Oflex.ods.Tables("encabezado").NewRow
                ' pd_total_pedido = drEncabezado.Item("total_devolucion").ToString

                dr.Item("Empresa") = s_empresa
                dr.Item("tipodocto") = sTipoDocto
                dr.Item("correlativo") = 0
                dr.Item("CtaCte") = String.Empty
                dr.Item("numero") = ""
                dr.Item("fecha") = Today.ToString("dd-MM-yyyy")
                dr.Item("proveedor") = String.Empty
                dr.Item("cliente") = String.Empty
                dr.Item("bodega") = drBodega.Item("bodega").ToString
                dr.Item("bodega2") = String.Empty
                dr.Item("local") = String.Empty
                dr.Item("comprador") = String.Empty
                dr.Item("vendedor") = String.Empty
                dr.Item("CentroCosto") = String.Empty
                dr.Item("fechaVcto") = "01/01/1900"
                dr.Item("listaPrecio") = String.Empty
                'dr.Item("Analisis") = "piloto"
                dr.Item("Zona") = String.Empty
                dr.Item("tipocta") = "VEHICULO PENDIENTE"
                dr.Item("moneda") = "QUETZALES"
                dr.Item("paridad") = 1
                dr.Item("neto") = 0
                dr.Item("subtotal") = 0
                dr.Item("total") = pd_total_pedido
                dr.Item("NetoIngreso") = 0
                dr.Item("SubTotalIngreso") = 0
                dr.Item("TotalIngreso") = 0
                dr.Item("centraliza") = String.Empty
                dr.Item("valoriza") = String.Empty
                dr.Item("costeo") = String.Empty
                dr.Item("aprobacion") = "S"
                dr.Item("TipoComprobante") = String.Empty
                dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
                dr.Item("FactorMonto") = 0
                dr.Item("TipoCtaCte") = String.Empty
                dr.Item("IdCtaCte") = String.Empty
                dr.Item("Glosa") = "Referencia " & Me.cmbTipoDoctoOrigen.SelectedValue & "-" & Me.txtNumeroOrigen.Text  'drEncabezado.Item("TipoDoctoFactura") & "-" & drEncabezado.Item("NumeroFactura") 'Validar Glosa
                dr.Item("comentario1") = "Referencia " & psTipodoctoSalida & "--" & psNumeroSalida 'drEncabezado.Item("comentario1").ToString
                dr.Item("comentario2") = String.Empty
                dr.Item("vigencia") = "S"
                dr.Item("Emitido") = "N"
                dr.Item("PorcentajeAsignado") = 0
                dr.Item("direccion") = String.Empty 'drEncabezado.Item("direccion").ToString
                dr.Item("ciudad") = String.Empty
                dr.Item("comuna") = String.Empty
                dr.Item("EstadoDir") = String.Empty
                dr.Item("pais") = String.Empty
                dr.Item("contacto") = String.Empty
                dr.Item("FechaModif") = Now
                dr.Item("FechaUModif") = Now
                dr.Item("UsuarioModif") = gs_usuario 'drEncabezado.Item("UsuarioRecepcion").ToString.ToUpper '"Admin" 03Junio2014
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


                dr.Item("Analisis") = String.Empty
                dr.Item("TipoCta") = String.Empty




                Oflex.ods.Tables("encabezado").Rows.Add(dr)



                Dim iCount As Integer = 0

                Dim ldSubTotal As Double = 0
                ''DocumentoD

                Ods.Tables("detalle_traslado").DefaultView.RowFilter = "Bodega = '" & drBodega.Item("Bodega").ToString & "'"

                For Each drvDetalle As DataRowView In Ods.Tables("detalle_traslado").DefaultView

                    iCount += 1
                    dr = Oflex.ods.Tables("detalle").NewRow

                    dr.Item("Empresa") = s_empresa
                    dr.Item("tipodocto") = sTipoDocto
                    dr.Item("Secuencia") = iCount 'ofila.Item("secuenciaFactura") 'iCount
                    dr.Item("Linea") = iCount 'ofila.Item("secuenciaFactura") 'iCount
                    dr.Item("Producto") = drvDetalle.Item("producto")
                    dr.Item("Cantidad") = drvDetalle.Item("cantidad")
                    dr.Item("Precio") = drvDetalle.Item("precio") ''Precio de La factura Original
                    dr.Item("PorcentajeDr") = 0 'ofila.Item("PorcentajeDRFactura")
                    dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
                    dr.Item("Impuesto") = 0
                    dr.Item("Neto") = dr.Item("SubTotal")
                    dr.Item("DRGlobal") = 0
                    dr.Item("Costo") = 0


                    Try
                        'Debo Buscar Costo
                        '(c) 0709
                        dr.Item("Costo") = drvDetalle.Item("precio")  'Es el costo de la tabla ProdBodegas
                    Catch ex As Exception
                        dr.Item("Costo") = 0
                    End Try
                    'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
                    dr.Item("Total") = dr.Item("Neto")
                    dr.Item("PrecioAjustado") = dr.Item("precio")
                    dr.Item("UnidadIngreso") = "UN"
                    dr.Item("CantidadIngreso") = drvDetalle.Item("cantidad")
                    dr.Item("PrecioIngreso") = dr.Item("precio")
                    dr.Item("SubTotalIngreso") = dr.Item("Total")
                    dr.Item("ImpuestoIngreso") = 0
                    dr.Item("NetoIngreso") = dr.Item("SubTotalIngreso")
                    dr.Item("DRGlobalIngreso") = 0
                    dr.Item("TotalIngreso") = dr.Item("Total")
                    Try
                        If drvDetalle.Item("lote").ToString.Trim.Length = 0 Then
                            dr.Item("Lote") = System.DBNull.Value
                            dr.Item("fechavcto") = System.DBNull.Value
                        Else
                            dr.Item("Lote") = drvDetalle.Item("lote")
                            dr.Item("fechavcto") = drvDetalle.Item("fechavcto")
                        End If
                    Catch ex As Exception

                    End Try

                    dr.Item("TipoDoctoOrigen") = drvDetalle.Item("tipoDoctoGenerado") 'ofila.Item("TipoDoctoFactura")
                    dr.Item("CorrelativoOrigen") = piCorrelativoSalida
                    dr.Item("SecuenciaOrigen") = drvDetalle.Item("secuenciaGenerado")
                    dr.Item("Bodega") = drvDetalle.Item("Bodega")  'bodega Seleccionada
                    dr.Item("FactorInventario") = 1


                    dr.Item("FechaEntrega") = Today
                    dr.Item("CantidadAsignada") = 0
                    dr.Item("Fecha") = Today
                    dr.Item("comentario") = String.Empty
                    dr.Item("Vigente") = "S"

                    dr.Item("CUP") = dr.Item("costo")
                    dr.Item("Ubicacion") = "PRINCIPAL"
                    dr.Item("Ubicacion2") = "PRINCIPAL"
                    dr.Item("cuenta") = String.Empty
                    dr.Item("FactorImpto") = 1
                    dr.Item("PrecioBimoneda") = dr.Item("precio")
                    dr.Item("SubTotalBimoneda") = dr.Item("subtotal")
                    dr.Item("ImpuestoBimoneda") = 0
                    dr.Item("NetoBimoneda") = dr.Item("Neto")
                    dr.Item("DrGlobalBimoneda") = 0
                    dr.Item("TotalBimoneda") = dr.Item("Total")
                    Try
                        dr.Item("PrecioListaP") = System.DBNull.Value
                        dr.Item("FechaVigenciaLp") = String.Empty 'ofila.Item("FechaVigenciaLp")
                    Catch ex As Exception
                        dr.Item("PrecioListaP") = 0
                    End Try

                    dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")

                    dr.Item("LoteDestino") = String.Empty
                    dr.Item("SerieDestino") = String.Empty
                    dr.Item("ProdAlias") = String.Empty
                    dr.Item("DoctoOrigenVal") = "S"
                    dr.Item("MontoAsignado") = 0
                    dr.Item("Aux_Valor14") = drvDetalle.Item("codigomotivo") ''Motivo del traslado

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
                    ldSubTotal = ldSubTotal + dr.Item("SubTotal")
                Next

                Try

                    Oflex.ods.Tables("encabezado").Rows(0).Item("total") = ldSubTotal
                    Oflex.ods.Tables("encabezado").Rows(0).Item("totalIngreso") = ldSubTotal
                    Oflex.ods.Tables("encabezado").Rows(0).Item("totalBimoneda") = ldSubTotal
                    Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = ldSubTotal / 1.12
                    Oflex.ods.Tables("encabezado").Rows(0).Item("netoIngreso") = ldSubTotal / 1.12
                    Oflex.ods.Tables("encabezado").Rows(0).Item("netoBimoneda") = ldSubTotal / 1.12
                    Oflex.ods.Tables("encabezado").Rows(0).Item("subtotal") = ldSubTotal / 1.12
                    Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalIngreso") = ldSubTotal / 1.12
                    Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalBimoneda") = ldSubTotal / 1.12
                Catch ex As Exception
                End Try

                ls_pedido_generado = Oflex.Guardar_Documento()
                If ls_pedido_generado > 0 Then

                    Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & gs_empresa & "','" & sTipoDocto & "'")

                    Try
                        'Imprimir Documento
                        imprimirDocumento(sTipoDocto, Oflex.ods.Tables("encabezado").Rows(0).Item("Numero"))
                    Catch ex As Exception

                    End Try


                End If



            Next



        Catch ex As Exception
        Finally
            clsGen = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub guardarComentario()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            lsSQL = "pa_upd_um_documento_comentario4 '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.SelectedValue & "','" & Me.txtNumeroOrigen.Text & "','" & gs_usuario & "','" & Me.txtComentario1.Text & "'"

            clsGen.insertQuery("FlexLine", lsSQL)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub
    Private Function generarPDF(psFechaDocto As String) As String

        Dim lsRutaPDF As String
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = 1


        ''El Documento se crea en el Directorio de la fecha de generacion
        ' lsRutaPDF = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" & gs_empresa & "\" & psFechaDocto
        'Ruta Local
        lsRutaPDF = "c:\temp\" & gs_empresa & "\" & psFechaDocto

        Try
            If Not Directory.Exists(lsRutaPDF) Then
                Directory.CreateDirectory(lsRutaPDF)
            End If
        Catch ex As Exception

        End Try



        Try

            'lsRutaPDF = "c:\temp\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"
            lsRutaPDF = lsRutaPDF & "\" & Me.cmbTipoDoctoOrigen.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumeroOrigen.Text & ".pdf"

            clsGen.Escribir_Log("Ruta PDF " & lsRutaPDF)
            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("scm")
            Dim ppath_reporte As String = clsGen.Path_Reporte



            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Logistica\Bodega\EntradasInternaciones.rpt"

            Dim pm_parametros2(2) As String
            Dim pm_valores2(2) As String


            pm_parametros2(0) = "@Empresa"
            pm_parametros2(1) = "@Tipodocto"
            pm_parametros2(2) = "@Numero"


            pm_valores2(0) = gs_empresa
            pm_valores2(1) = Me.cmbTipoDoctoOrigen.SelectedValue
            pm_valores2(2) = Me.txtNumeroOrigen.Text


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                True, False, "PDF", False, lsRutaPDF, True, 1, gs_empresa, ",")




        Catch ex As Exception
            clsGen.Escribir_Log("Generar PDF " & ex.ToString)
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try
        Return lsRutaPDF
    End Function

    Private Sub enviarCorreo()


        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LGS1"
        Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try




            Dim iCount As Integer = 0

            sSubject = Me.cmbTipoDoctoOrigen.SelectedValue.ToString & "-" & Me.txtNumeroOrigen.Text


            sBody = "<br>"
            sBody = sBody & "Se les Informa que se ha ingresado a " & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            sBody = sBody & Me.cmbTipoDoctoOrigen.SelectedValue.ToString & "-" & Me.txtNumeroOrigen.Text & "<br>"
            sBody = sBody & "Proveedor " & Me.txtGlosaDocto.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Adjunto se envia el documento de Ingreso <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            If Me.txtComentario1.Text.Length > 0 Then
                sBody = sBody & " Comentarios " & Me.txtComentario1.Text
            End If




            Try
                Dim dtBU As DataTable
                Dim dtCorreo As DataTable
                dtBU = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.SelectedValue.ToString & "','" & Me.txtNumeroOrigen.Text & "'")
                ldFechaDocto = dtBU.Rows(0).Item("fecha_docto")
                dtBU = clsGen.ValoresDistinto(dtBU, "analisisproducto17".Split(","))
                For Each dr As DataRow In dtBU.Rows
                    '' Debo obtener las personas que tienen permisos para esa unidad de negocio
                    Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & dr.Item("analisisproducto17").ToString & "','" & gs_empresa & "'")
                    For Each drBU As DataRow In dtUsuarioBU.Rows
                        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drBU.Item("usuario").ToString & "'")
                        If dtCorreo.Rows.Count > 0 Then
                            If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                            scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                        End If
                    Next

                Next
                ''Correos por empresa
                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null, 'gen_correo_internaci', '" & gs_empresa & "'")
                For Each dr As DataRow In dtCorreo.Rows
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dr.Item("descripcion").ToString
                Next



            Catch ex As Exception

            End Try




            'scuentas = "coscal@umbral.com.gt, chernandez@logiservicios.com"
            Dim lsRuta As String = generarPDF(ldFechaDocto.ToString("yyyyMM"))

            clsGen.enviarcorreo(sRemitente, snombreRemitente, scuentas, sSubject, sBody, lsRuta)

            'Ruta En Servidor

            Dim lsRutaServidor As String = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" &
                                    gs_empresa & "\" & ldFechaDocto.ToString("yyyyMM")


            Try
                If Not Directory.Exists(lsRutaServidor) Then
                    Directory.CreateDirectory(lsRutaServidor)
                End If
            Catch ex As Exception

            End Try

            lsRutaServidor &= "\" & Me.cmbTipoDoctoOrigen.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumeroOrigen.Text & ".pdf"

            clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub imprimirDocumento(psTipoDocto As String, psNumeroDocto As String)

        Dim lsRutaPDF As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = 1
        Try

            'lsRutaPDF = "c:\temp\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte



            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Movimientos.rpt"

            Dim pm_parametros2(2) As String
            Dim pm_valores2(2) As String


            pm_parametros2(0) = "Empresa"
            pm_parametros2(1) = "Numero"
            pm_parametros2(2) = "tipoDocto"


            pm_valores2(0) = gs_empresa
            pm_valores2(2) = psTipoDocto
            pm_valores2(1) = psNumeroDocto


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                False, True, "PDF", False, lsRutaPDF, True, 1, gs_empresa, ",")




        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Function validacionesGuardar() As Boolean
        Dim lbpasavalidaciones As Boolean = False
        Dim dtUnicos As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim liCantidadTraslado As Integer = 0
        Dim liCantidadDocumento As Integer = 0
        Try

            '' las cantidades no deben sobrepasar lo indicado en cada linea

            'para DM
            ''SALIDA DE PRODUCTO INVENTARIO
            ''ENTRADA DE PRODUCTO INVENTARIO 
            If Ods.Tables("detalle_traslado").Rows.Count = 0 Then
                lbpasavalidaciones = True
            End If

            dtUnicos = clsGen.ValoresDistinto(Ods.Tables("detalle_traslado"), "producto,secuenciaOrigen".Split(","))

            For Each dr As DataRow In dtUnicos.Rows

                liCantidadTraslado = 0
                liCantidadTraslado = Ods.Tables("detalle_traslado").Compute("sum(cantidad)", "producto = '" & dr.Item("producto") & "' and secuenciaOrigen = " & dr.Item("secuenciaOrigen"))

                liCantidadDocumento = 0
                liCantidadDocumento = Ods.Tables("documento").Compute("sum(cantidad)", "producto = '" & dr.Item("producto") & "' and secuencia = " & dr.Item("secuenciaOrigen"))



                If liCantidadDocumento >= liCantidadTraslado Then
                    lbpasavalidaciones = True
                Else
                    MessageBox.Show("Cantidad SobrePasa lo Ingresado " & dr.Item("Producto").ToString, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbpasavalidaciones = False
                End If


            Next

            'If Ods.Tables("detalle_traslado").Rows.Count = 0 Then
            '    If MessageBox.Show("Esta Orden No Tiene Traslados, Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            '        lbpasavalidaciones = False
            '    Else
            '        lbpasavalidaciones = True

            '    End If

            'End If

        Catch ex As Exception
        Finally
            clsGen = Nothing
            Ods.Tables("documento").DefaultView.RowFilter = ""
        End Try
        Return lbpasavalidaciones
    End Function

    Private Sub Limpiar()
        Ods.Tables("detalle_traslado").Rows.Clear()
        Me.dgvDetalleDocumento.DataSource = Nothing
        'Me.dgvTraslado.DataSource = Nothing
        Me.txtNumeroOrigen.Text = String.Empty
        Me.txtGlosaDocto.Text = String.Empty
        Me.txtComentario1.Text = String.Empty

        '   Me.txtTipoDoctoDestino.Text = "ENTRADA POR TRASLADO"
        'Me.txtNumeroDestino.Text = String.Empty


    End Sub

    Private Sub limpiarProducto()
        'Me.txtCodigoProducto.Text = String.Empty
        'Me.txtGlosa.Text = String.Empty
        'Me.txtCantidad.Text = String.Empty
    End Sub


    Private Sub frm_InformeInternaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
        Limpiar()
        limpiarProducto()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarDocumento()

    End Sub

    Private Sub dgvDetalleDocumento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleDocumento.CellContentClick
        Try
            'Me.txtCodigoProducto.Text = Me.dgvDetalleDocumento.Item("producto", e.RowIndex).Value
            'Me.txtGlosa.Text = Me.dgvDetalleDocumento.Item("glosa", e.RowIndex).Value
            'Me.lblSecuenciaOrigen.Text = Me.dgvDetalleDocumento.Item("secuencia", e.RowIndex).Value
            'Me.txtPrecio.Text = Me.dgvDetalleDocumento.Item("precioAjustado", e.RowIndex).Value
            'Me.txtLote.Text = Me.dgvDetalleDocumento.Item("lote", e.RowIndex).Value.ToString
            'Me.txtFechaVcto.Text = Me.dgvDetalleDocumento.Item("FechaVctod", e.RowIndex).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs)
        'agregarLinea()
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub


    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Aplicar los Cambios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim ClsGen As New ClasesGenerales.General
            Dim lsSQL As String
            Dim lsNombreReporte As String = String.Empty
            Dim Oaut As Automatizar.Reportes_CraxDrt
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Dim lsNombreArchivo As String = Me.cmbTipoDoctoOrigen.SelectedValue & "_" & Me.txtNumeroOrigen.Text & ".pdf"
            Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\" & lsNombreArchivo
            Try



                'Me.Cursor = Cursors.WaitCursor
                ''If validacionesGuardar() Then
                'Dim stipodocto As String '= "SALIDA DE PRODUCTO INVENTARIO"
                'Dim scorrelativo As Integer '= 4000076
                'Dim snumero As String '= "0000035819"

                ''

                ''realizarIngresoVinoteca()
                'If Ods.Tables("detalle_traslado").Rows.Count > 0 Then
                '    'realizarSalida(stipodocto, snumero, scorrelativo)  '1 Salida Global
                '    'realizarIngreso(stipodocto, snumero, scorrelativo) '1 Entrada por bodega (muchas entradas)
                'End If

                ''If Me.txtComentario1.Text.Length > 0 Then '(c)20160328 Modificamos el comentario4 del documento Original 
                ''guardarComentario()

                ''End If
                Dim lsRutaReporte As String = ClsGen.Path_Reporte() & "Logistica\Bodega\Impresion de Movimientos.rpt"

                Try


                    Dim pm_valores(2) As String
                    Dim pm_parametros(2) As String
                    pm_parametros(0) = "empresa"
                    pm_parametros(1) = "numero"
                    pm_parametros(2) = "tipodocto"

                    pm_valores(0) = gs_empresa
                    pm_valores(2) = Me.cmbTipoDoctoOrigen.SelectedValue
                    pm_valores(1) = Me.txtNumeroOrigen.Text

                    'lsArchivoGenerado = exportar_reporte(lsRutaReporte, lsNombreReporte, False, pm_parametros, pm_valores, "", pm_conexion)
                    'lsArchivoGenerado = _reporte_generico_clase(path_reporte, pm_parametros, pm_parametros, "vdataserver", "BDFlexLine",)


                    ')


                    'lsSQL = "pa_ins_um_aprobaciones '" & dr.Item("empresa").ToString & "','DEVOLUCION','" &
                    'dr.Item("correlativo") & "','" & Date.Parse(dr.Item("fecha_devolucion").ToString()).ToString("yyyy-M-dd") & "','" & dr.Item("usuario_grabo") & "','" &
                    'dr.Item("comentarios").ToString & "','" & lsNombreReporte & "','P','" &
                    'dr.Item("correo_usuario_grabo").ToString & "','carlos.oscal@umbralcorp.com',''"

                    'ClsGen.insertQuery("RegionalDBintOut", lsSQL)
                    ClsGen.Escribir_Log(lsSQL)

                    'Mover_Archivos_FTP(lsArchivoGenerado)
                    Oaut.Archivo_Generado = lsArchivoGenerado
                    Oaut._reporte_generico(lsRutaReporte, pm_parametros, pm_valores, "VdataServer", "BDFLexline", "flexline", "flexline", True, False, "PDF", False)

                    Mover_Archivos_FTP(lsArchivoGenerado)
                Catch ex As Exception

                End Try


                lsSQL = "pa_ins_um_aprobaciones '" & gs_empresa & "','" & Me.cmbTipoDoctoOrigen.SelectedValue & "','" &
                Me.txtNumeroOrigen.Text & "','" & DateTime.Parse(Me.txtFecha.Text).ToString("yyyy-MM-dd") & "','" & gs_usuario & "','" &
                Me.txtComentario1.Text & "','" & lsNombreArchivo & "','P','','mayra.osorio@vinoteca.gt','','mosorio'"

                ClsGen.insertQuery("RegionalDBintOut", lsSQL)


                ''enviarCorreo()
                MessageBox.Show("Proceso Finalizado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

            Catch ex As Exception
                ClsGen.Escribir_Log(ex.ToString)
            Finally
                ClsGen = Nothing
                Me.Cursor = Cursors.Default
                Me.Limpiar()
                Me.limpiarProducto()
            End Try
        End If
    End Sub


    Private Sub Mover_Archivos_FTP(psRuta As String)
        Dim clsGen As New ClasesGenerales.General

        Dim Archivos As String()
        Dim Ruta_Archivos As String
        Dim strDir As String
        Dim ArchivoDestino As String
        Dim dt As DataTable
        Dim lsSQL As String
        Dim drv As DataRowView
        Dim ff As New FTP.clsFTP

        lsSQL = "pa_sel_um_edi_configuraciones 'aprobaciones'"

        dt = clsGen.selectQuery("Corporativo", lsSQL)

        dt.DefaultView.RowFilter = ""
        drv = dt.DefaultView(0)

        Try



            ff = New FTP.clsFTP

            ff.RemoteHost = drv.Item("host").ToString.Split(":")(0)
            ff.RemoteUser = drv.Item("usuario")
            ff.RemotePassword = drv.Item("password")
            Try
                ff.RemotePort = drv.Item("host").ToString.Split(":")(1)
            Catch ex As Exception
            End Try
            If (ff.Login()) Then
                'ff.ChangeDirectory(drv.Item("carpeta"))
                'ff.ChangeDirectory(drv.Item("descripcion"))
                'ff.ChangeDirectory("Receive")
                'ff.ChangeDirectory("tekne")
                ff.SetBinaryMode(True)

                Try
                    ff.UploadFile(psRuta)
                Catch ex As Exception
                    clsGen.Escribir_Log(ex.Message)
                End Try

                'Ruta_Archivos = _dr.Item("path_archivos").ToString & "receive"
                'Ruta_Archivos = "c:\aplicaciones\mr\" & _dr.Item("cod_cliente").ToString & "\Receive"

                'Try
                '    Archivos = Directory.GetFiles(Ruta_Archivos, "*.*")
                '    ArchivoDestino = _dr.Item("path_archivos").ToString & "Receive"

                '    For Each strDir In Archivos
                '        ff.UploadFile(strDir)

                '        clsGen.Mover_Archivo(strDir, Ruta_Archivos & "\log\" & strDir.Split("\").GetValue(strDir.Split("\").LongLength - 1))

                '    Next
                'Catch ex As Exception
                '    clsGen.Escribir_Log(ex.Message)
                'Finally

                'End Try
            End If
        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Limpiar()
        Me.limpiarProducto()
    End Sub
End Class