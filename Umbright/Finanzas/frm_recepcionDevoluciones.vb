Public Class frm_recepcionDevoluciones
    Dim ods As DataSet
    Dim odsFACE As DataSet


    Private Sub crear_estructuraFACE()
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
        dt.Columns.Add(New DataColumn("FechaEnvioFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("FechaRecepcionFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ComentarioFACE", GetType(String)))

        odsFACE.Tables.Add(dt.Copy)

   
        Me.dgvNotasFACE.DataSource = odsFACE.Tables("pedidos")


    End Sub

    Private Sub enviosPendientesFACE()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & gs_empresa & "','" & Me.dtpFechaInicio.Text & "','" & Me.dtpFechaFinal.Text & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'Credito'"

            oTabla = oTabla.DefaultView.ToTable

            '
            'ls_sqltxt = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            'dtPermisos = oTrans.Obtiene(ls_sqltxt)

            'lsFiltro = ""
            'icount = 0
            'For Each dr In dt.Rows
            '    If icount > 0 Then
            '        lsFiltro += " OR "
            '    End If
            '    lsFiltro += "Empresa = '" & dr.Item("empresa").ToString & "'"
            '    icount += 1
            'Next


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            dtPermisos = dt.DefaultView.ToTable.Copy
            'lsFiltro = ""
            '

            For Each dr In oTabla.Rows

                lbProcesar = True
                'If Me.chkTodo.CheckState = CheckState.Unchecked Then
                '    If dr.Item("vigencia").ToString.ToLower.Equals("a") Then
                '        lbProcesar = False
                '    End If
                'End If

                If lbProcesar Then
                    'lsFiltro = "empresa = '" & gs_empresa & "' and (texto = '" & dr.Item("analisisCtaCte2").ToString & "' Or texto2 = '" & dr.Item("analisisCtaCte2").ToString & "')"

                    lsFiltro = "(Empresa = '" & gs_empresa & "' AND (texto = '" & dr.Item("analisisCtaCte2").ToString & "'))"

                    '    If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO1") & "'"
                    '    If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte2 = '" & drv.Item("TEXTO2") & "'"
                    '    ls_filtro += "))"
                    dtPermisos.DefaultView.RowFilter = lsFiltro
                    If dtPermisos.DefaultView.Count > 0 Then
                        lbProcesar = True
                    Else
                        lbProcesar = False
                    End If

                End If

                If Not lbProcesar Then
                    If tiene_permisos("administrador") Then
                        lbProcesar = True
                    End If
                End If
                If lbProcesar Then

                    dr_aux = odsFACE.Tables("pedidos").NewRow

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
                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
                    dr_aux.Item("total") = dr.Item("total")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        dr_aux.Item("FechaEnvioFACE") = dr.Item("FechaEnvio")
                        dr_aux.Item("FechaRecepcionFACE") = dr.Item("FechaRecepcion")
                        dr_aux.Item("ComentarioFACE") = dr.Item("ComentarioFACE")
                    Catch ex As Exception

                    End Try
                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)
                End If


            Next
            'Me.txt_facturas.Text = odsFACE.Tables("pedidos").Rows.Count

            clGen.Alinear_GridView(odsFACE.Tables("pedidos"), dgvNotasFACE, _
                                   ",forma_pago,bodega,exento,vigencia,direccion,tipodocto,numero,fecha,codlegal,nombre_cliente,PorcDescuento,numeroFACE,fechaenvioFACE,comentarioFACE,fecharecepcionFACE,", _
             ",firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", _
             ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,", "", "", ",PorcDescuento=30,vigencia=15,exento=15,", "", True, True, 150, 0)

            'ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & Me.dtpFechaInicioFACE.Text & "','" & Me.dtpFechaFinalFACE.Text & "','" & gs_empresa & "'"
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "detalle_pedidos"

            'odsFACE.Tables.Add(oTabla.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            'detalle_pedidoFACE(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenarCombos()

        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        clsGen.fillComboBox(Otrans, "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'", "EMPRESAS", "EMPRESA", "EMPRESA", Me.cmbEmpresa)


        clsGen = Nothing
        Otrans = Nothing



    End Sub

    Private Sub crearEstructura()
        Dim dt As DataTable

        ods = New DataSet

        dt = New DataTable("notas")

        dt.Columns.Add(New DataColumn("NCE", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Refacturar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Correlativo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("Numero_Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha_Factura", GetType(Date)))
        dt.Columns.Add(New DataColumn("Dias", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns("numero").Unique = True


        ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub mostrarTipoDocto()


        Dim lsSQL As String
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable


        Try

            lsSQL = "pa_sel_um_tipodocumento '" & Me.cmbEmpresa.SelectedValue.ToString & "','devolucion (v)',null"
            dt = clsgen.selectQuery("FlexLine", lsSQL)
            Me.cmbTipoDocto.DataSource = dt
            Me.cmbTipoDocto.DisplayMember = "tipoDocto"
            Me.cmbTipoDocto.ValueMember = "tipoDocto"
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub

    Private Sub buscarNota()

        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_var_um_documento '" & Me.cmbEmpresa.SelectedValue.ToString & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'"

            dt = clsgen.selectQuery("FlexLine", lsSQL)

            If dt.Rows.Count > 0 Then

                Dim drAux As DataRow

                drAux = ods.Tables("notas").NewRow
                drAux.Item("NCE") = False
                drAux.Item("Refacturar") = False
                drAux.Item("Empresa") = Me.cmbEmpresa.SelectedValue
                drAux.Item("tipodocto") = Me.cmbTipoDocto.SelectedValue
                drAux.Item("correlativo") = dt.Rows(0).Item("correlativo")
                drAux.Item("numero") = Me.txtNumero.Text
                drAux.Item("cliente") = dt.Rows(0).Item("cliente")
                drAux.Item("razonSocial") = dt.Rows(0).Item("razonSocial")
                drAux.Item("Fecha") = dt.Rows(0).Item("Fecha")
                drAux.Item("glosa") = dt.Rows(0).Item("glosa")
                drAux.Item("Monto") = dt.Rows(0).Item("total")
                drAux.Item("dias") = 99


                Try
                    If drAux.Item("glosa").ToString.ToLower.IndexOf("parcial") > 0 Then
                        drAux.Item("NCE") = True
                        drAux.Item("Refacturar") = True
                    End If
                Catch ex As Exception

                End Try

                dt = clsgen.selectQuery("FlexLine", "pa_var_um_documento_previo '" & drAux.Item("Empresa").ToString & "','" & drAux.Item("tipodocto") & "','" & drAux.Item("numero").ToString & "'")
                If dt.Rows.Count = 1 Then
                    drAux.Item("numero_factura") = dt.Rows(0).Item("numero")
                    drAux.Item("fecha_factura") = dt.Rows(0).Item("fecha")
                    drAux.Item("dias") = dt.Rows(0).Item("dias")
                    If drAux.Item("dias") < 61 Then
                        drAux.Item("NCE") = True
                    Else
                        drAux.Item("NCE") = False
                    End If
                End If



                ods.Tables("notas").Rows.Add(drAux)
                Me.dgvNotas.DataSource = ods.Tables("notas")
                clsgen.Alinear_GridView(ods.Tables("notas"), Me.dgvNotas, "", ",empresa,correlativo,fecha,", _
                                        ",tipodocto,numero,cliente,razonsocial,glosa,total,numero_factura,fecha_factura,dias,", "", "", ",glosa=300,", "", True, True, 180, 0)


            End If


        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try

    End Sub

    Private Sub generarNotas()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            For Each dr As DataRow In ods.Tables("notas").Rows
                lsSQL = "pa_ins_um_gen_log_documento '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" & _
                            dr.Item("numero").ToString & "','" & gs_usuario & "','R','" & Me.txtLote.Text & "'"

                clsGen.insertQuery("FlexLine", lsSQL)

                If dr.Item("NCE") = True Then


                    lsSQL = "flexline.spa_Convierte_Dev_a_NotasFace '" & dr.Item("empresa").ToString & "','" & _
                                    dr.Item("tipodocto").ToString & "'," & dr.Item("correlativo")
                    clsGen.insertQuery("FlexLine", lsSQL)

                End If

                If dr.Item("refacturar") Then
                    Dim psNumeroDOcumento As String

                    If ProcesaRefactura(dr.Item("Empresa"), dr.Item("tipoDocto"), dr.Item("Numero"), psNumeroDOcumento) Then
                        '' Debo Crear la NC 
                        lsSQL = "flexline.spa_Convierte_Dev_a_NotasFace '" & _
                                                    psNumeroDOcumento.Split(",")(0).ToString & "','" & _
                                                    psNumeroDOcumento.Split(",")(1).ToString & "'," & _
                                                    psNumeroDOcumento.Split(",")(2).ToString


                        'dr.Item("empresa").ToString & "','" & _
                        '   dr.Item("tipodocto").ToString & "'," & dr.Item("correlativo")
                        clsGen.insertQuery("FlexLine", lsSQL)

                    End If

                End If

            Next
            imprimirRecepcionDevolucion()
            MessageBox.Show("Proceso Finalizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub imprimirRecepcionDevolucion()

        Try


            Dim path_reporte As String
            Dim pm_valores(2) As String
            Dim pm_parametros(2) As String
            Dim pm_conexion(3) As String
            Dim ClsGen As New ClasesGenerales.General

            Try


                pm_conexion = ClsGen.Parametros_Conexion("VDataServer")
                path_reporte = ClsGen.Path_Reporte()
                path_reporte += "Finanzas\Creditos\Jefatura\recepcion de devoluciones.rpt"

                pm_parametros(0) = "@Pempresa"
                pm_parametros(1) = "@Plote"

                pm_valores(0) = Me.cmbEmpresa.SelectedValue
                pm_valores(1) = Me.txtLote.Text

                '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                '               pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                '               False, True, "PDF", False, "", True)




                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                              pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                              False, False, "PDF", False, "", True, 1)


            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            Finally
                ClsGen = Nothing
            End Try
        Catch ex As Exception
        End Try

    End Sub

    

    Private Sub limpiarForma()
        Try
            Me.cmbEmpresa.Enabled = True
            ods.Tables("notas").Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub


    Private Function informacionValida() As Boolean

        Dim lbinformacionValida As Boolean = True

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()

            For Each dr As DataRow In ods.Tables("notas").Rows
                dt = Otrans.Obtiene("pa_sel_um_gen_log_documento '" & dr.Item("empresa") & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero") & "'")
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("El documento No. " & dr.Item("numero") & " Ya fue Recibido Con Anterioridad, No lo puede volver a Recibir", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbinformacionValida = False
                    Exit For
                End If
                If dr.Item("Dias") > 60 And dr.Item("NCE") = True Then
                    MessageBox.Show("El Documento No. " & dr.Item("numero") & " No Puede Generar NCE", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dr.Item("NCE") = False
                End If
            Next

        Catch ex As Exception
            lbinformacionValida = False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return lbinformacionValida

    End Function



    ''Private Function ProcesaRefactura(ByVal pOds As DataSet, ByVal dt As DataTable, ByVal Otrans As Transaccional.Conexion) As Boolean
    Private Function ProcesaRefactura(ByVal psEmpresa As String, pstipodocto As String, psNumero As String, ByRef psNumeroDocumento As String) As Boolean


        ''pOds Debe llevar la Informacion de la Nota de Devolucion

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
        Dim lbContinuar As Boolean = False
        Dim dtEncabezadoNota, dtDetalleNota As DataTable
        Dim clsGen As New ClasesGenerales.General

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()



            ''drEncabezado debe llevar el encabezado de la Nota de Devolucion

            lsSQL = "pa_var_um_documento '" & psEmpresa & "','" & pstipodocto & "','" & psNumero & "'"
            dtEncabezadoNota = Otrans.Obtiene(lsSQL)
            If dtEncabezadoNota.Rows.Count > 0 Then
                drEncabezado = dtEncabezadoNota.Rows(0)
            End If

            s_empresa = drEncabezado.Item("empresa").ToString
            Dim lsBodega As String = "FIN_TRANSITO"


            'forma_pago = drEncabezado.Item("forma_pago").ToString



            osinc.Llenar_Auxiliares(ods, drEncabezado.Item("cliente"), s_empresa)
            osinc = Nothing

            'If drEncabezado.Item("ctacte").ToString.StartsWith("149404") Then
            sTipoDocto = "DEVOLUCION REFACTURA"
            'End If


            dr = Oflex.ods.Tables("encabezado").NewRow
            ' pd_total_pedido = drEncabezado.Item("total_devolucion").ToString

            dr.Item("Empresa") = s_empresa
            dr.Item("tipodocto") = sTipoDocto
            dr.Item("correlativo") = 0
            dr.Item("CtaCte") = String.Empty
            dr.Item("numero") = ""
            dr.Item("fecha") = Today.ToString("dd-MM-yyyy")
            dr.Item("proveedor") = String.Empty
            dr.Item("cliente") = drEncabezado.Item("cliente")
            dr.Item("bodega") = lsBodega  'drEncabezado.Item("bodega")
            dr.Item("bodega2") = String.Empty
            dr.Item("local") = String.Empty
            dr.Item("comprador") = String.Empty
            dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
            dr.Item("CentroCosto") = String.Empty
            dr.Item("fechaVcto") = "01/01/1900"
            dr.Item("listaPrecio") = drEncabezado.Item("listaprecio").ToString
            dr.Item("Analisis") = drEncabezado.Item("analisis").ToString
            dr.Item("Zona") = String.Empty
            dr.Item("tipocta") = "VEHICULO PENDIENTE"
            dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")
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
            dr.Item("aprobacion") = "S" '(c) A partir del 02 de Mayo 2014
            dr.Item("TipoComprobante") = String.Empty
            dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = drEncabezado.Item("cliente")
            dr.Item("Glosa") = drEncabezado.Item("glosa") 'drEncabezado.Item("TipoDoctoFactura") & "-" & drEncabezado.Item("NumeroFactura") 'Validar Glosa
            dr.Item("comentario1") = drEncabezado.Item("comentario1").ToString
            dr.Item("comentario2") = drEncabezado.Item("comentario2").ToString
            dr.Item("vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("direccion") = drEncabezado.Item("direccion").ToString
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

            Try
                'Dim dtPiloto As DataTable
                'dtPiloto = Otrans.Obtiene("pa_var_um_documento_guia_transporte  '" & s_empresa & "','" & drEncabezado.Item("TipoDoctoFactura") & "','" & drEncabezado.Item("NumeroFactura") & "'")

                'If dtPiloto.Rows.Count > 0 Then
                dr.Item("Analisis") = drEncabezado.Item("Analisis")
                dr.Item("TipoCta") = drEncabezado.Item("TipoCta")
                'End If
            Catch ex As Exception

            End Try





            Oflex.ods.Tables("encabezado").Rows.Add(dr)

            'Detalle Nota de Devolucion

            lsSQL = "pa_var_um_documentod '" & psEmpresa & "','" & pstipodocto & "','" & psNumero & "'"
            dtDetalleNota = Otrans.Obtiene(lsSQL)

            Dim dtFacturas As DataTable
            dtFacturas = clsGen.ValoresDistinto(dtDetalleNota, "tipodoctoOrigen,correlativoOrigen".Split(","))

            If dtFacturas.Rows.Count = 1 Then
                lsSQL = "pa_var_um_documento_correlativo '" & psEmpresa & "','" & dtFacturas.Rows(0).Item("tipoDoctoOrigen").ToString & "',null," & dtFacturas.Rows(0).Item("CorrelativoOrigen")
                dtFacturas = Otrans.Obtiene(lsSQL)


                'Debo Buscar la Factura Completa


                lsSQL = "pa_var_um_documentod '" & psEmpresa & "','" & dtFacturas.Rows(0).Item("tipoDocto").ToString & _
                                        "','" & dtFacturas.Rows(0).Item("Numero").ToString & "'"
                Dim dtDetalleFactura = Otrans.Obtiene(lsSQL)

                Dim iCount As Integer = 0

                Dim ldSubTotal As Double = 0
                Dim CantidadDevuelta As Double
                ''DocumentoD
                'For Each ofila In dt.Rows
                For Each ofila In dtDetalleFactura.rows
                    '            dtDetalle.DefaultView.RowFilter = "numero = '" & ofila.Item("numero") & "' and  producto ='" & ofila.Item("producto") & "' and lote = '" & ofila.Item("lote") & "'"
                    '           drv = dtDetalle.DefaultView(0)

                    CantidadDevuelta = 0
                    lbContinuar = False
                    'For Each drbusca As DataRow In pOds.Tables("detalle").Rows
                    For Each drbusca As DataRow In dtDetalleNota.Rows
                        If ofila.Item("producto") = drbusca.Item("producto") Then
                            If ofila.Item("lote").ToString.Length > 0 Then
                                If ofila.Item("lote") = drbusca.Item("lote") And ofila.Item("fechavcto") = ofila.Item("fechavcto") Then
                                    CantidadDevuelta = drbusca.Item("cantidad")
                                    Exit For
                                End If

                            Else
                                CantidadDevuelta = drbusca.Item("cantidad")
                                Exit For
                            End If

                        End If
                    Next

                    If CantidadDevuelta > 0 Then
                        If ofila.Item("cantidad") - CantidadDevuelta = 0 Then
                            lbContinuar = False
                        Else
                            lbContinuar = True
                        End If
                    Else
                        lbContinuar = True
                    End If

                    If lbContinuar Then
                        iCount += 1
                        dr = Oflex.ods.Tables("detalle").NewRow

                        dr.Item("Empresa") = s_empresa
                        dr.Item("tipodocto") = sTipoDocto
                        dr.Item("Secuencia") = ofila.Item("secuencia") 'iCount
                        dr.Item("Linea") = ofila.Item("Linea") 'iCount
                        dr.Item("Producto") = ofila.Item("producto")
                        dr.Item("Cantidad") = ofila.Item("cantidad") - CantidadDevuelta
                        dr.Item("Precio") = ofila.Item("precio") ''Precio de La factura Original
                        dr.Item("PorcentajeDr") = ofila.Item("PorcentajeDR")
                        dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
                        dr.Item("Impuesto") = 0
                        dr.Item("Neto") = dr.Item("SubTotal")
                        dr.Item("DRGlobal") = 0
                        Try
                            dr.Item("Costo") = ofila.Item("costo") 'ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
                        Catch ex As Exception
                            dr.Item("Costo") = ofila.Item("costo")
                        End Try
                        'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
                        dr.Item("Total") = dr.Item("Neto")
                        dr.Item("PrecioAjustado") = dr.Item("precio")
                        dr.Item("UnidadIngreso") = ofila.Item("UnidadIngreso")
                        dr.Item("CantidadIngreso") = dr.Item("cantidad")
                        dr.Item("PrecioIngreso") = dr.Item("precio")
                        dr.Item("SubTotalIngreso") = dr.Item("Total")
                        dr.Item("ImpuestoIngreso") = 0
                        dr.Item("NetoIngreso") = dr.Item("SubTotalIngreso")
                        dr.Item("DRGlobalIngreso") = 0
                        dr.Item("TotalIngreso") = dr.Item("Total")
                        dr.Item("Lote") = ofila.Item("lote")
                        dr.Item("fechavcto") = ofila.Item("fechavcto")
                        dr.Item("TipoDoctoOrigen") = ofila.Item("tipoDocto")            'ofila.Item("TipoDoctoFactura")
                        dr.Item("CorrelativoOrigen") = ofila.Item("Correlativo") ' ofila.Item("correlativoFactura")
                        dr.Item("SecuenciaOrigen") = ofila.Item("Secuencia") 'ofila.Item("secuenciaFactura")
                        dr.Item("Bodega") = lsBodega  'ofila.Item("bodega")
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
                        dr.Item("PrecioListaP") = ofila.Item("precioListaP")
                        dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")
                        dr.Item("FechaVigenciaLp") = ofila.Item("FechaVigenciaLp")
                        dr.Item("LoteDestino") = String.Empty
                        dr.Item("SerieDestino") = String.Empty
                        dr.Item("ProdAlias") = String.Empty
                        dr.Item("DoctoOrigenVal") = "S"
                        dr.Item("MontoAsignado") = 0
                        dr.Item("Aux_Valor13") = "" ' ofila.Item("cod_motivo")

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
                    End If 'lbContinuar
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






                If Oflex.ods.Tables("detalle").Rows.Count > 0 Then

                    ls_pedido_generado = Oflex.Guardar_Documento()
                End If




                If ls_pedido_generado > 0 Then
                    proceso_exitoso = True
                    'Otrans.Actualiza("scm..pa_upd_um_rechazo_procesado '" & dr.Item("empresa") & "','" & drEncabezado.Item("tipodoctoRechazo") & "','" & drEncabezado.Item("numeroRechazo") & "','" & ls_pedido_generado & "'")
                    psNumeroDocumento = dr.Item("empresa") & "," & sTipoDocto & "," & ls_pedido_generado
                    'Try
                    '    For Each dr2 As DataRow In Oflex.ods.Tables("detalle").Rows
                    '        lsSQL = "pa_upd_um_documentod_asignado_sinControlTransporte '" & dr.Item("empresa") & "','" & dr.Item("tipodoctoOrigen") & "'," & _
                    '                dr2.Item("correlativoOrigen") & ",'" & dr2.Item("producto") & "'," & dr2.Item("secuenciaOrigen") & ",'" & _
                    '                drEncabezado.Item("UsuarioRecepcion").ToString.ToUpper & "'"

                    '        Otrans.Actualiza(lsSQL)
                    '    Next
                    'Catch ex As Exception

                    'End Try


                    Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & dr.Item("empresa") & "','" & sTipoDocto & "'")

                    'Try

                    '    'Dim dtAux As DataTable
                    '    'dtAux = Otrans.Obtiene("scm..pa_var_um_rechazo_parcial_total '" & drEncabezado.Item("empresa").ToString & "','" & drEncabezado.Item("TipoDoctoFactura") & "','" & drEncabezado.Item("numeroFactura") & "','" & sTipoDocto & "'")
                    '    Dim diferencia As Double = 0.1
                    '    Dim lsDescripcionRechazo As String = String.Empty
                    '    'For Each dr2 As DataRow In dtAux.Rows
                    '    '    diferencia += dr2.Item("diferencia")
                    '    '    If dr2.Item("descripcionRechazo").ToString.Length > 0 Then
                    '    '        lsDescripcionRechazo = dr2.Item("descripcionRechazo").ToString
                    '    '    End If
                    '    'Next


                    '    lsDescripcionRechazo = "Rechazo " & IIf(diferencia > 0, "Parcial", "Total") & " De Factura No. " & drEncabezado.Item("numeroFactura") & " " & lsDescripcionRechazo
                    '    lsSQL = "scm..pa_upd_um_documento_rechazo '" & drEncabezado.Item("empresa").ToString & "','" & sTipoDocto & "'," & ls_pedido_generado & ",'" & lsDescripcionRechazo & "'"
                    '    Otrans.Actualiza(lsSQL)
                    'Catch ex As Exception

                    'End Try

                    'Enviar Impresion de Devolucion
                    Try


                        ''Revisar Impresion 04092014

                        Oflex.imprimirDevolucion(drEncabezado.Item("empresa").ToString, Oflex.ods.Tables("encabezado").Rows(0).Item("numero"), Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto"), 1, ",")

                        'pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
                        'pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")



                    Catch ex As Exception

                    End Try
                End If '' dtdetallefacturas.rows = 1
            End If

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Oflex = Nothing

        Return proceso_exitoso
    End Function



    Private Sub mostrarNotasFACE()
        crear_estructuraFACE()
        enviosPendientesFACE()
    End Sub

    Private Sub frm_recepcionDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        crearEstructura()
    End Sub


    Private Sub cmbEmpresa_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectionChangeCommitted
        mostrarTipoDocto()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbEmpresa.Enabled = False
            Me.txtNumero.Text = Me.txtNumero.Text.PadLeft(10, "0")
            buscarNota()
            Me.txtNumero.Text = String.Empty
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If informacionValida Then


            If MessageBox.Show("Esta seguro de Guardar y Generar Notas de Credito Electronicas", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                Me.txtLote.Text = Now.ToString("ddmmyyyyHHMM")
                generarNotas()
            End If
        End If


    End Sub

    Private Sub dgvNotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotas.CellContentClick

    End Sub

    Private Sub dgvNotas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvNotas.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex


        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgvNotas.Rows(rowIndex)
                'If therow.Cells("combo").Value.ToString() = "si" Then
                '    therow.DefaultCellStyle.ForeColor = Color.Green
                'Else
                If therow.Cells("dias").Value > 60 Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                    'ElseIf therow.Cells("Vigente").Value.ToString() = "X" Then
                    '    therow.DefaultCellStyle.ForeColor = Color.Blue
                    '    'Else
                    '    For icount = 1 To 12
                    '        sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                    '        If Me.dg_presupuesto.Columns(sname).Visible = True Then
                    '            sname = "color_" & icount.ToString.PadLeft(2, "0")
                    '            If therow.Cells(sname).Value.ToString = 1 Then
                    '                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                    '                therow.Cells(sname).Style.BackColor = Color.Yellow
                    '                'therow.Cells(sname).ToolTipText = "Mercadeo < Comercial"
                    '            ElseIf therow.Cells(sname).Value.ToString = -1 Then
                    '                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                    '                therow.Cells(sname).Style.BackColor = Color.Coral
                    '                'therow.Cells(sname).ToolTipText = "Mercadeo > Comercial"
                    '            Else
                    '                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                    '                therow.Cells(sname).Style.BackColor = Color.White
                    '            End If
                    '        End If
                    '    Next

                End If



            End If
            'color azul
            'Me.dg_presupuesto.Columns("Vigente").Width = 5
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarForma()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        mostrarNotasFACE()
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged

    End Sub
End Class