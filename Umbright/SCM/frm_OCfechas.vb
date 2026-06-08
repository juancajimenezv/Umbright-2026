Imports System.Math
Public Class frm_OCfechas

    Public numero As String
    Dim ds, ods1, ds2, ds_p As New DataSet
    Dim clic As Boolean = False
    Public no_comentario As String


    Private Sub crearEstructuraAuxiliar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            ls_sql = "pa_var_um_documento_traslado_fecha 'VINOTECA',NULL,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)

            dt.TableName = "documento"
            If ds.Tables.Contains("documento") Then
                ds.Tables.Remove("documento")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)


            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If ds.Tables.Contains("documentod") Then
                ds.Tables.Remove("documentod")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If ds.Tables.Contains("documentov") Then
                ds.Tables.Remove("documentov")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If ds.Tables.Contains("documentop") Then
                ds.Tables.Remove("documentop")
            End If
            dt.Rows.Clear()
            ds.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Log_Ocfechas(ByVal pNumero As String, ByVal pActividad As String, ByVal pTipodocto As String)

        Dim ls_sql As String


        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()


            ls_sql = "pa_ins_um_gen_log_documento '" & gs_empresa & "','" & pTipodocto & "'," & "'" & pNumero & " ','" & gs_usuario & "','NULL','" & pActividad & "'"
            oTrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try



    End Sub



    Private Sub GenerarDocumentos(ByVal pDocumento As String, ByVal pDocumentoOrigen As String, ByVal pfechaVcto As DateTime)
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dtDetalleOriginal As DataTable
        Dim icount As Integer

        Dim lsSQL As String

        Try
            crearEstructuraAuxiliar()

            ds.Tables("documento").Rows.Clear()
            ds.Tables("documentod").Rows.Clear()
            ds.Tables("documentop").Rows.Clear()
            ds.Tables("documentov").Rows.Clear()

            otrans.open()

            dt = otrans.Obtiene("pa_var_um_documento '" & gs_empresa & "','" & pDocumentoOrigen & "','" & Me.txtNumeroOC.Text & "'")



            dr = dt.Rows(0)




            dr_aux = ds.Tables("documento").NewRow

            dr_aux.Item("empresa") = gs_empresa
            dr_aux.Item("TipoDocto") = pDocumento
            dr_aux.Item("Numero") = dr.Item("numero").ToString
            'dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy")
            dr_aux.Item("FechaVcto") = pfechaVcto.ToString("dd/MM/yyyy")

            dr_aux.Item("ctacte") = String.Empty
            dr_aux.Item("proveedor") = dr.Item("proveedor")
            dr_aux.Item("idCtacte") = dr.Item("proveedor")
            dr_aux.Item("Bodega") = String.Empty
            dr_aux.Item("Vendedor") = String.Empty
            dr_aux.Item("ListaPrecio") = String.Empty
            dr_aux.Item("Moneda") = dr.Item("moneda")
            dr_aux.Item("Paridad") = dr.Item("Paridad")

            dr_aux.Item("Neto") = dr.Item("Neto")
            dr_aux.Item("SubTotal") = dr.Item("SubTotal")
            dr_aux.Item("Total") = dr.Item("Total")
            dr_aux.Item("NetoIngreso") = dr.Item("NetoIngreso")
            dr_aux.Item("SubTotalIngreso") = dr.Item("SubTotalIngreso")
            dr_aux.Item("TotalIngreso") = dr.Item("TotalIngreso")
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("Valoriza") = "S"
            dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = dr.Item("tipoctacte")
            dr_aux.Item("glosa") = dr.Item("glosa")
            dr_aux.Item("Comentario1") = dr.Item("Comentario1")
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N"
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now

            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = gs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")

            'dr_aux.Item("Caja") = dr.Item("U_SSOCAJA")
            'dr_aux.Item("Pago") = dr_aux.Item("Total")
            'dr_aux.Item("IdApertura") = dr.Item("U_SSOSESION")

            dr_aux.Item("NetoBimoneda") = dr.Item("NetoBimoneda")
            dr_aux.Item("SubTotalBimoneda") = dr.Item("SubTotalBimoneda")
            dr_aux.Item("TotalBimoneda") = dr.Item("TotalBimoneda")

            dr_aux.Item("ParidadBimoneda") = 1
            dr_aux.Item("AnalisisE3") = dr.Item("analisisE3")
            dr_aux.Item("AnalisisE7") = dr.Item("analisisE7")


            ds.Tables("documento").Rows.Add(dr_aux)


            ''Detalle
            Try

                dt = otrans.Obtiene("pa_sel_um_documentod '" & gs_empresa & "','" & pDocumentoOrigen & "','" & Me.txtNumeroOC.Text & "'")

                icount = 0
                For Each drv In dt.DefaultView


                    'dt.DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"
                    'dt_producto_barra.DefaultView.RowFilter = "codbarra = '" & drv.Item("CodArticulo").ToString & "'"
                    dr_aux = ds.Tables("documentod").NewRow

                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = pDocumento
                    dr_aux.Item("Producto") = drv.Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")

                    dr_aux.Item("Cantidad") = drv.Item("Cantidad")
                    dr_aux.Item("Precio") = Round(drv.Item("precio"), 2)

                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = drv.Item("SubTotal")
                    dr_aux.Item("Impuesto") = 0 'Round(drv.Item("ValorImpuesto"), 2)
                    dr_aux.Item("Neto") = drv.Item("Neto")
                    dr_aux.Item("DrGlobal") = 0

                    dr_aux.Item("Total") = dr_aux.Item("Neto")
                    dr_aux.Item("PrecioAjustado") = drv.Item("precioAjustado")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = drv.Item("UnidadIngreso")
                    dr_aux.Item("CantidadIngreso") = drv.Item("CantidadIngreso")
                    dr_aux.Item("PrecioIngreso") = drv.Item("PrecioIngreso")
                    dr_aux.Item("SubTotalIngreso") = drv.Item("SubTotalIngreso")
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = drv.Item("NetoIngreso")
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = drv.Item("TotalIngreso")

                    'dr_aux.Item("Bodega") = drv.Item("U_SSOCOD")
                    dr_aux.Item("FactorInventario") = 0
                    dr_aux.Item("FechaEntrega") = pfechaVcto
                    dr_aux.Item("CantidadAsignada") = 0
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S"
                    dr_aux.Item("CUP") = drv.Item("CUP")
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1
                    dr_aux.Item("PrecioBimoneda") = drv.Item("PrecioBimoneda")
                    dr_aux.Item("SubTotalBimoneda") = drv.Item("SubTotalBimoneda")
                    dr_aux.Item("ImpuestoBimoneda") = drv.Item("ImpuestoBimoneda")
                    dr_aux.Item("NetoBimoneda") = drv.Item("NetoBimoneda")
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = drv.Item("TotalBimoneda")

                    dr_aux.Item("DoctoOrigenVal") = "N"
                    dr_aux.Item("Secuencia") = drv.Item("secuencia")
                    dr_aux.Item("Linea") = drv.Item("linea")
                    dr_aux.Item("TipoDoctoOrigen") = drv.Item("tipoDocto")
                    dr_aux.Item("CorrelativoOrigen") = drv.Item("correlativo")
                    dr_aux.Item("SecuenciaOrigen") = drv.Item("secuencia")


                    Try
                        dr_aux.Item("costo") = drv.Item("costo")
                    Catch ex As Exception
                        dr_aux.Item("costo") = 0
                    End Try

                    Try
                        dr_aux.Item("PrecioListaP") = drv.Item("PrecioListaP")
                    Catch ex As Exception
                        dr_aux.Item("PrecioListaP") = 0
                    End Try

                    ds.Tables("documentod").Rows.Add(dr_aux)
                Next
            Catch ex As Exception
                'Agregar_Log("Productos " & dr.Item("Numero") & " " & ex.Message, "Error")
                'lgenerar_error = True
            End Try


            Dim osinc As New Sincronizacion.Documentos("")

            dr = ds.Tables("documento").Rows(0)
            Try
                osinc.Enviar_Documento(gs_empresa, dr, ds.Tables("documentod").DefaultView.ToTable, ds.Tables("documentov").DefaultView.ToTable, ds.Tables("documentop").DefaultView.ToTable, pDocumento, False)
                If osinc.codigo_error = 0 Then
                    For Each dr In ds.Tables("documentod").Rows
                        lsSQL = "pa_upd_um_documentod_asignado '" & gs_empresa & "','" & dr.Item("tipodoctoOrigen") & "'," & dr.Item("correlativoOrigen") & ",'" & dr.Item("producto") & "'," & dr.Item("SecuenciaOrigen") & ",'" & gs_usuario & "'"
                        otrans.Actualiza(lsSQL)
                    Next
                End If

            Catch ex As Exception
            Finally
                osinc.Cerrar()
                osinc = Nothing
            End Try

        Catch ex As Exception
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub CrearEstructura()
        Dim ClsGen As New ClasesGenerales.General

        Try

            Dim dt, dt2, dt3 As New DataTable
            dt.Columns.Add(New DataColumn("orden", GetType(String)))
            dt.Columns.Add(New DataColumn("origen", GetType(String)))
            dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
            dt.Columns.Add(New DataColumn("fechaVencimiento", GetType(Date)))
            dt.Columns("tipodocto").Unique = True
            dt.TableName = "doctosfecha"

            Dim draux As DataRow = dt.NewRow
            draux.Item("orden") = 1
            draux.Item("origen") = "CONFIRMACION PROVEEDOR"
            draux.Item("tipodocto") = "FECHA EMBARQUE"
            draux.Item("fechaVencimiento") = Today.AddDays(-1)
            dt.Rows.Add(draux)

            draux = dt.NewRow
            draux.Item("orden") = 2
            draux.Item("origen") = "FECHA EMBARQUE"
            draux.Item("tipodocto") = "FECHA CONFIRMACION DE EMBARQUE"
            draux.Item("fechaVencimiento") = Today.AddDays(-1)
            dt.Rows.Add(draux)

            draux = dt.NewRow
            draux.Item("orden") = 3
            draux.Item("origen") = "FECHA CONFIRMACION DE EMBARQUE"
            draux.Item("tipodocto") = "FECHA ARRIBO PUERTO"
            draux.Item("fechaVencimiento") = Today.AddDays(-1)
            dt.Rows.Add(draux)

            draux = dt.NewRow
            draux.Item("orden") = 4
            draux.Item("origen") = "FECHA ARRIBO PUERTO"
            draux.Item("tipodocto") = "FECHA SALIDA PUERTO DE GUATEMALA"
            draux.Item("fechaVencimiento") = Today.AddDays(-1)
            dt.Rows.Add(draux)

            draux = dt.NewRow
            draux.Item("orden") = 5
            draux.Item("origen") = "FECHA SALIDA PUERTO DE GUATEMALA"
            draux.Item("tipodocto") = "FECHA INGRESO DEPOSITO ADUANERO"
            draux.Item("fechaVencimiento") = Today.AddDays(-1)
            dt.Rows.Add(draux)

            If ds.Tables.Contains("doctosfecha") Then ds.Tables.Remove("doctosfecha")
            ds.Tables.Add(dt.Copy)



            'dt2 = New DataTable("productos")
            dt2.Columns.Add(New DataColumn("producto", GetType(String)))
            dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
            dt2.Columns.Add(New DataColumn("unidad", GetType(String)))
            dt2.Columns.Add(New DataColumn("cantidad_pedido", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("preciou", GetType(Double)))
            dt2.Columns.Add(New DataColumn("total", GetType(Double)))
            dt2.Columns.Add(New DataColumn("cantidad_facturada", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("fechaVencimiento", GetType(Date)))
            dt2.Columns.Add(New DataColumn("Codigo_proveedor", GetType(String)))
            dt2.Columns("producto").Unique = True
            dt2.TableName = "productos"
            'ds.Tables.Add(dt2)



            dt3 = New DataTable("productos")
            ds_p = New DataSet
            Me.dgvProductosOC.DataSource = Nothing
            dt3.Columns.Add(New DataColumn("producto", GetType(String)))
            dt3.Columns.Add(New DataColumn("glosa", GetType(String)))
            dt3.Columns.Add(New DataColumn("unidad", GetType(String)))
            dt3.Columns.Add(New DataColumn("cantidad_pedido", GetType(Integer)))
            dt3.Columns.Add(New DataColumn("preciou", GetType(Double)))
            dt3.Columns.Add(New DataColumn("total", GetType(Double)))
            dt3.Columns.Add(New DataColumn("cantidad_facturada", GetType(Integer)))
            dt3.Columns.Add(New DataColumn("fechaVencimiento", GetType(Date)))
            dt3.Columns.Add(New DataColumn("Codigo_proveedor", GetType(String)))
            dt3.Columns("producto").Unique = True
            ds_p.Tables.Add(dt3)

            Me.dgvProductosOC.DataSource = ds_p.Tables("productos")


            Dim draux3 As DataRow = dt2.NewRow
        
            If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")


            ds.Tables.Add(dt2.Copy)



            Dim dc, dc3 As New ClasesGenerales.CalendarColumn
            dc.Name = "fechaVencimiento"
            dc.DataPropertyName = "fechaVencimiento"
           
            dc3.name = "fechaVencimiento"
            dc3.DataPropertyName = "fechaVencimiento"



            'Me.dataGridView1.RowCount = 5

            Me.dgvDoctos.DataSource = Nothing
            Me.dgvDoctos.Columns.Clear()
            Me.dgvDoctos.DataSource = ds.Tables("doctosfecha")

            Me.dgv_fap_productos.DataSource = Nothing
            Me.dgv_fap_productos.Columns.Clear()
            Me.dgv_fap_productos.DataSource = ds.Tables("productos")

            'Me.dgvDoctos.Columns.Add(col)

            ClsGen.Alinear_GridViewCalendar(dc)
            ClsGen.Alinear_GridView(ds.Tables("doctosfecha"), Me.dgvDoctos, ",tipodocto,fechavencimiento,", "", "", "", "", "", "", True, True, 250, 0)

            ClsGen.Alinear_GridViewCalendar(dc3)
            ClsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_fap_productos, ",producto,glosa,unidad,cantidad_pedido,preciou,total,cantidad_facturada,fechaVencimiento,Codigo_proveedor,", "", "", "", "", "", "", True, True, 250, 0)




            dt = New DataTable("tipo_unidad")
            dt.Columns.Add(New DataColumn("unidad", GetType(String)))

            If Not ds.Tables.Contains("tipo_unidad") Then ds.Tables.Add(dt.Copy)


        Catch ex As Exception

        End Try



       
    End Sub

    Private Sub buscarOrdenCompra()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'CONFIRMACION PROVEEDOR','" & gs_empresa & "','" & Me.txtNumeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            ds_p.Tables("productos").Rows.Clear()
            Me.dgvProductosOC.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                Dim cantidadAsignada As Integer = dt.Compute("Sum(CantidadAsignada)", "cantidad>0")
                If cantidadAsignada = 0 Then
                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "s" And _
                        dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado
                        Me.dtpFechaVencimientoConfirmacion.Value = dt.Rows(0).Item("fechaVcto")
                        Me.txtProveedor.Text = dt.Rows(0).Item("proveedor").ToString


                        For Each dr As DataRow In dt.Rows
                            draux = ds_p.Tables("productos").NewRow
                            draux.Item("producto") = dr.Item("producto")
                            draux.Item("glosa") = dr.Item("glosa")
                            ' draux.Item("unidad") = dr.Item("unidad")
                            draux.Item("cantidad_pedido") = dr.Item("cantidad")
                            draux.Item("fechaVencimiento") = Today.Date
                            draux.Item("preciou") = dr.Item("precio")
                            draux.Item("total") = dr.Item("subtotal")
                            ds_p.Tables("productos").Rows.Add(draux)
                        Next

                        Me.dgvProductosOC.DataSource = ds_p.Tables("productos")
                        clsGen.Alinear_GridView(ds_p.Tables("productos"), Me.dgvProductosOC, "", ",unidad,cantidad_facturada,fechaVencimiento,", ",glosa,total,", ",cantidad,preciou,total,", "", "", "", True, True, 250, 0)
                    Else
                        If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                            MessageBox.Show("Documento No Esta Vigente", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("Esta Orden de Compra No Esta Vigente o Esta Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtNumeroOC.Text = String.Empty
                        End If
                    End If
                Else
                    MessageBox.Show("Esta Confirmacion ya Tiene Documentos Relacionados", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtNumeroOC.Text = String.Empty
                End If

            Else
                MessageBox.Show("El Documento CONFIRMACION PROVEEDOR No Existe", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtNumeroOC.Text = String.Empty
            End If


        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub


    Private Function validarFechas() As Boolean

        Dim fechasvalidas As Boolean = True

        Try
            ds.Tables("doctosfecha").DefaultView.RowFilter = ""
            ds.Tables("doctosfecha").DefaultView.Sort = "orden"

            Dim fechainicial As DateTime = Today.AddYears(-1) ' Me.dtpFechaVencimientoConfirmacion.Value

            For Each drv As DataRowView In ds.Tables("doctosfecha").DefaultView
                If fechainicial > drv.Item("fechavencimiento") Then
                    MessageBox.Show("Problemas Con El Documento " & drv.Item("tipodocto").ToString, "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    fechasvalidas = False
                    Exit For
                Else
                    fechainicial = drv.Item("fechavencimiento")
                End If
                'If (DateDiff(DateInterval.Day, Today, fechainicial)) < 0 Then
                '    MessageBox.Show("La Fecha del Documento " & drv.Item("tipodocto").ToString & "No Puede Ser Menor a la Fecha Actual", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    fechasvalidas = False
                '    Exit For
                'End If
            Next
        Catch ex As Exception
            fechasvalidas = False
        End Try

        Return fechasvalidas
    End Function


    Private Sub llenarDocumentos()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            oTrans.open()
            lsSQL = " pa_sel_um_documento '" & gs_empresa & "',NULL,'" & Me.txt_numero.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "sistema = 'compras' and clase = 'pedido (c)' and tipodocto <> 'ORDEN DE COMPRA'"
            dt = dt.DefaultView.ToTable
            dt.DefaultView.RowFilter = "tipodocto <> 'confirmacion proveedor'"
            dt.DefaultView.Sort = "fecha, fechavcto"
            Me.dgvDocumentos.DataSource = dt.DefaultView
            clsGen.Alinear_GridView(dt, dgvDocumentos, ",tipodocto,numero,fecha,fechavcto,comentario1,", "", "", "", "", "", "", False, True, 200, 0)

            If dt.Rows.Count > 0 Then
                Me.txt_numero.Enabled = False
            End If
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub llenarCombos()

        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()


            ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_MOTIVOOC','DMARTE1'"
            otabla = otrans.Obtiene(ls_sql)
            Me.ComboBox1.DataSource = otabla
            Me.ComboBox1.DisplayMember = "DESCRIPCION"
            Me.ComboBox1.ValueMember = "DESCRIPCION"

            ls_sql = "pa_sel_um_vi_unidadingreso '" & gs_empresa & "'"
            otabla = otrans.Obtiene(ls_sql)

            ds.Tables("tipo_unidad").Rows.Clear()

            For Each dr As DataRow In otabla.Rows
                Dim draux As DataRow = ds.Tables("tipo_unidad").NewRow
                draux.Item("unidad") = dr.Item("unidadingreso")
                ds.Tables("tipo_unidad").Rows.Add(draux)

            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    Private Sub hacer_busqueda()
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTransaccion As New Transaccional.Conexion("flexline")

        Dim lsSQL As String

        Try


            oTransaccion.open()

            lsSQL = "pa_sel_um_documento_detalle_proveedor '" & Me.txtTipodocto.Text & "','" & gs_empresa & "','" & Me.txt_numero.Text & "'"
            otabla = oTransaccion.Obtiene(lsSQL)

            If oTransaccion.Codigo_error = 0 Then
                If otabla.Rows(0).Item("vigencia") <> "A" Then
                    otabla.TableName = "detalle"
                    oTransaccion.close()

                    Me.DataGrid1.DataSource = otabla

                    clGen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, 3, 200, 50, False, True, ",producto,glosa,cantidad,precio,subtotal,", True, "")
                    Me.txt_fecha.Text = otabla.Rows(0).Item("fecha")

                    Me.txt_cliente.Text = otabla.Rows(0).Item("RazonSocial")
                    Me.txt_fechaVcto.Text = otabla.Rows(0).Item("fechaVcto")
                    Me.dtp_nueva_fecha.Text = otabla.Rows(0).Item("fechaVcto")
                    Me.dtp_nueva_fecha.Focus()
                Else
                    MessageBox.Show("El Documento Esta ANULADO", "Vigencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '  Me.lbl_vigencia.Text = "Anulado"
                End If
            End If

        Catch ex As Exception
            If Me.txt_numero.Text.Length > 0 Then
                MessageBox.Show("Problema Con la Busqueda, Verifique El Numero", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.txt_fecha.Text = ""
            Me.txt_cliente.Text = ""


        Finally
            Me.Refresh()
        End Try
        oTransaccion = Nothing
    End Sub

    Private Function ValidarNuevaFecha() As Boolean
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim lbretorno As Boolean = False

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_relacionado '" & gs_empresa & "','" & Me.txtTipodocto.Text & "','" & Me.txt_numero.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("tipoDoctoDestino").ToString.Length > 5 Then
                    If Date.Parse(dt.Rows(0)("fechavctoDestino").ToString) < Me.dtp_nueva_fecha.Value Then
                        lbretorno = False

                    Else
                        lbretorno = True
                    End If

                Else
                    lbretorno = True
                End If
            Else
                lbretorno = True
            End If



        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

        Return lbretorno
    End Function

    Private Sub llenar_informacion()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql, lsSQL, ls_sql2 As String
        Dim dt, dt2 As DataTable
        Dim dr, dr2, dr_aux As DataRow
        Dim total_registros, contador As Integer
        Dim i As Integer
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim oTransC As New Transaccional.Conexion("SCM")

        ods1.Tables("control").Rows.Clear()
        Try


            oTrans.open()
            oTransC.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'FECHA ARRIBO PUERTO','" & gs_empresa & "','" & Me.txt_no_orden.Text & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                Me.dtp_fecha_vencimiento.Value = dt.Rows(0).Item("fechaVcto")
                Me.dtp_fecha_despacho.Value = dt.Rows(0).Item("fechaDespacho")
                'Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
                'Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString
                Me.lbl_correlativo.Text = dt.Rows(0)("correlativo")
                Me.txt_proveedor_control.Text = dt.Rows(0)("proveedor").ToString
                Me.txt_no_orden.Enabled = False








                'bdscm 
                ls_sql = "pa_sel_um_gen_tabcod_oc  NULL,'GEN_DOCUMENTACION_OC','UMBRAL'"
                dt = oTransC.Obtiene(ls_sql)


                ls_sql2 = "pa_sel_um_oc_documentacion  '" & gs_empresa & "','" & Me.txt_no_orden.Text & "'"

                dt2 = oTransC.Obtiene(ls_sql2)


                If dt2.Rows.Count <= dt.Rows.Count And dt2.Rows.Count > 0 Then
                    Me.btn_guardar_control.Text = "Actualizar"
                    For i = 0 To dt.Rows.Count
                        For Each dr2 In dt2.Rows
                            total_registros = dt2.Rows.Count
                            dr_aux = ods1.Tables("control").NewRow
                            If dt.Rows(i).Item("descripcion") = dr2.Item("documentooc") Then
                                dr_aux.Item("Descripcion") = dt.Rows(i).Item("descripcion")
                                dr_aux.Item("Aplica") = dr2.Item("asignado")
                                dr_aux.Item("Lo tiene") = dr2.Item("tiene")
                                dr_aux.Item("Comentario") = dr2.Item("comentario")
                                ods1.Tables("control").Rows.Add(dr_aux)
                                contador = 0

                                Exit For
                            Else
                                contador = contador + 1
                                If contador = total_registros Then
                                    dr_aux.Item("Descripcion") = dt.Rows(i).Item("descripcion")
                                    dr_aux.Item("Aplica") = 0
                                    dr_aux.Item("Lo tiene") = 0
                                    ods1.Tables("control").Rows.Add(dr_aux)
                                    contador = 0

                                    Exit For
                                End If
                            End If

                        Next
                        clsgen.Alinear_GridView(ods1.Tables("control"), Me.dgv_control, ",Descripcion,Aplica,Lo tiene,Comentario,", "", ",Descripcion,", "", "", ",Descripcion=250,Aplica=50,Lo tiene=70,Comentario=450,", "", True, True, 200, 0)
                    Next


                ElseIf dt2.Rows.Count = 0 Then
                    Me.btn_guardar_control.Text = "Guardar"
                    For Each dr In dt.Rows
                        dr_aux = ods1.Tables("control").NewRow
                        dr_aux.Item("Descripcion") = dr.Item("descripcion")
                        dr_aux.Item("Aplica") = 1
                        dr_aux.Item("Lo tiene") = 0
                        dr_aux.Item("Comentario") = ""
                        ods1.Tables("control").Rows.Add(dr_aux)
                    Next
                    clsgen.Alinear_GridView(ods1.Tables("control"), Me.dgv_control, ",Descripcion,Aplica,Lo tiene,Comentario,", "", ",Descripcion,", "", "", ",Descripcion=250,Aplica=50,Lo tiene=70,Comentario=450,", "", True, True, 200, 0)

                End If

                Me.dgv_control.ForeColor = Color.Black


                ''Mostras FActuras Ingresadas LlenarFacturas
                ls_sql = "pa_sel_um_oc_documentacion_factura '" & _
                     gs_empresa & "','ORDEN DE COMPRA','" & Me.txt_no_orden.Text & "'"
                dt = oTransC.Obtiene(ls_sql)
                Dim lsFacturas As String
                For Each drFactura As DataRow In dt.Rows
                    lsFacturas += drFactura.Item("serie_factura").ToString & "-" & drFactura.Item("numero_factura").ToString & " / "

                Next


                ods1.Tables("control").DefaultView.RowFilter = "descripcion like '%factura or%'"
                If ods1.Tables("control").DefaultView.Count > 0 Then
                    ods1.Tables("control").DefaultView(0).Item("comentario") = lsFacturas
                End If


                ods1.Tables("control").DefaultView.RowFilter = ""

            Else
                MessageBox.Show("Problemas con esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)


            End If
        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
            oTrans.close()
            oTrans = Nothing
        End Try
    End Sub
    Private Sub Crear_Estructura()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("control")
        ods1 = New DataSet

        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt1.Columns.Add(New DataColumn("Aplica", GetType(Boolean)))
        dt1.Columns.Add(New DataColumn("Lo tiene", GetType(Boolean)))
        dt1.Columns.Add(New DataColumn("Comentario", GetType(String)))
        ods1.Tables.Add(dt1)
        Me.dgv_control.DataSource = ods1.Tables("control")

    End Sub

    Private Sub Guarda_informacion()
        Dim ls_sql As String
        Dim dt As DataTable

        Dim oTrans As New Transaccional.Conexion("SCM")

        Dim dr As DataRow
        Dim asig, ing, cuenta, lotiene As Integer

        Try
            oTrans.open()

            For Each dr In ods1.Tables("control").Rows
                Try
                    If dr.Item("Aplica").ToString Then
                        asig = asig + 1
                    End If
                Catch ex As Exception
                End Try
            Next

            ' primero elimina
            If Me.btn_guardar_control.Text = "Actualizar" Then

                ls_sql = "pa_del_um_oc_documentacion '" & gs_empresa & "','" & Me.txt_no_orden.Text & " '"
                oTrans.Elimina(ls_sql)

            End If

            If (Me.btn_guardar_control.Text = "Guardar" Or Me.btn_guardar_control .Text = "Actualizar") And asig > 0 Then
                'inserta
                For Each dr In ods1.Tables("control").Rows
                    Try

                        If dr.Item("Aplica").ToString Then
                            If dr.Item("Lo tiene").ToString Then
                                lotiene = 1
                            Else
                                lotiene = 0

                            End If

                            ls_sql = "pa_ins_um_oc_documentacion '" & gs_empresa & "','GEN_DOCUMENTACION_OC','" & Me.txt_no_orden.Text & " '," & "'" & dr.Item("descripcion").ToString & "',1" & "," & lotiene & ",'" & dr.Item("Comentario").ToString & "'"


                            oTrans.Ingresa(ls_sql)
                        End If

                    Catch ex As Exception
                    End Try
                Next
                Log_control_documento(Me.txt_no_orden.Text, "Asignacion Documentos")
                MessageBox.Show("Asignacion Fue Realizada con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Me.btn_fac_guardar.Text = "Actualizar"
                Crear_Estructura()
                llenar_informacion()
            Else
                '    MessageBox.Show("Verifique que este Asignada alguna Opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                MessageBox.Show("Actualizacion Fue Realizada con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btn_fac_guardar.Text = "Actualizar"
                Crear_Estructura()
                llenar_informacion()
            End If

            asig = 0
            cuenta = 0

        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub Log_control_documento(ByVal pNumero As String, ByVal pActividad As String)

        Dim ls_sql, ls_sql1 As String


        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()

            'borro e ingreso
            ls_sql1 = "pa_del_um_oc_documentacion_historial  '" & gs_empresa & "','" & pNumero & "','GEN_DOCUMENTACION_OC'"
            oTrans.Elimina(ls_sql1)

            ls_sql = "pa_ins_um_gen_log_documento '" & gs_empresa & "','GEN_DOCUMENTACION_OC','" & pNumero & " ','" & gs_usuario & "','NULL','" & pActividad & "'"
            oTrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try



    End Sub

    Private Sub guardar_comentario()


        Dim ls_sql As String
        Dim dt As DataTable

        Dim oTrans As New Transaccional.Conexion("Flexline")

        Dim dr As DataRow
        Dim asig, ing, cuenta, lotiene As Integer

        Try
            oTrans.open()


            ls_sql = "pa_ins_um_gen_log_documento '" & gs_empresa & "','GEN_OCTRACKING_COM','" & Me.txt_no_orden_comentario.Text & " ','" & gs_usuario & "','N','" & Me.txt_comentario.Text & "'"

            oTrans.Ingresa(ls_sql)
            MessageBox.Show("Comentario Ingresado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_comentario.Text = ""


        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    
    Private Sub crear_struc_comentario()
        Dim dt3 As New DataTable

        ''Estructura de Comentarios
        dt3 = New DataTable("comentarios")
        ds2 = New DataSet

        dt3.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt3.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt3.Columns.Add(New DataColumn("Usuario", GetType(String)))
        ds2.Tables.Add(dt3)
        Me.dgv_comentarios.DataSource = ds2.Tables("comentarios")

    End Sub


    Private Sub frm_OCfechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
        llenarCombos()
        If tiene_permisos("mci_tracking_comentario") Then
            Me.btn_comentario.Visible = True


        Else
            Me.btn_comentario.Visible = False


        End If
    End Sub

    

    Private Sub txtNumeroOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroOC.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroOC.Text = Me.txtNumeroOC.Text.PadLeft(10, "0")
            CrearEstructura()
            buscarOrdenCompra()
        End If
    End Sub


    Private Sub crearAvisoFechas()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dtusuarioEmpresa As DataTable
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim bguardarAviso As Boolean = False


        Try
            Otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod '" & Me.txtProveedor.Text & "','CON_PROVEE','" & gs_empresa & "'"
            dt2 = Otrans.Obtiene(lsSQL)

            lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
            dtusuarioEmpresa = Otrans.Obtiene(lsSQL)


            dt = ClsGen.usuariosAviso(3) '3= pg_tipo_aviso=Fechas de Seguimiento OC


            For Each dr As DataRow In dt.Rows

                If dr.Item("validar_marca").ToString = "1" Then
                    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                    If dt2.DefaultView.Count > 0 Then bguardarAviso = True

                ElseIf dr.Item("validar_empresa").ToString = "1" Then 'validar empresa
                    dtusuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                    If dtusuarioEmpresa.DefaultView.Count > 0 Then bguardarAviso = True

                Else
                    bguardarAviso = True
                End If

                If bguardarAviso Then
                    ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Se Ingreso Seguimiento a la OC No. " & Me.txtNumeroOC.Text & " del Proveedor " & Me.txtProveedor.Text, 3)
                    bguardarAviso = False
                End If

            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        If validarFechas() Then
            If MessageBox.Show("Esta Seguro de Generar los " & ds.Tables("doctosfecha").Rows.Count & " documentos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'GenerarDocumentos() 'Solo Tiene que Generar Confirmacion de proveedor 
                ds.Tables("doctosfecha").DefaultView.Sort = "orden"
                For Each drv As DataRowView In ds.Tables("doctosfecha").DefaultView
                    GenerarDocumentos(drv.Item("tipodocto"), drv.Item("origen"), drv.Item("fechaVencimiento"))
                Next
                'Log aplicar [Seguimiento]
                Log_Ocfechas(Me.txtNumeroOC.Text, "Confirmacion de Proveedor Seguimiento", "CONFIRMACION PROVEEDOR")






                MessageBox.Show("Documentos Generados Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                crearAvisoFechas()

                Me.dgvProductosOC.DataSource = Nothing
                Me.dgvDoctos.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub txt_numero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numero.KeyDown

    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
            llenarDocumentos()
        End If
    End Sub


    Private Sub btn_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_liberar.Click
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        Dim lsSQL As String

        Try



            If ValidarNuevaFecha() Then



                If MessageBox.Show("Esta Seguro de Actualizar el Documento", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    lsSQL = "pa_upd_um_documento_fecha_vcto '" & gs_empresa & "','" & _
                                    Me.txtTipodocto.Text & "','" & Me.txt_numero.Text & "', '" & _
                                    Me.dtp_nueva_fecha.Text & "','" & gs_usuario & "',NULL,NULL,'" & _
                                    Me.ComboBox1.Text & " " & Me.txt_fechaVcto.Text & " " & Me.dtp_nueva_fecha.Text & "'"

                    oTransaccion.open()
                    oTransaccion.Actualiza(lsSQL)

                    ' Log_Ocfechas(Me.txt_numero.Text, "Actualizacion de Fechas", "ORDEN DE COMPRA")

                    If oTransaccion.Codigo_error > 0 Then
                        MessageBox.Show(oTransaccion.descripcion_error)
                    Else
                        MessageBox.Show("Actualizacion Exitosa Verifique los Documentos Relacionados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        llenarDocumentos()
                    End If
                    oTransaccion.close()
                End If

            Else
                MessageBox.Show("No Se Puede Asignar Fecha Menor Que los Documentos Destino", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
        Finally
            oTransaccion = Nothing
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.txt_numero.Text = String.Empty
        Me.txt_numero.Enabled = True
        Me.txt_numero.Focus()
        Me.DataGrid1.DataSource = Nothing
        Me.dgvDocumentos.DataSource = Nothing
        Me.txtTipodocto.Text = String.Empty
        Me.txt_fecha.Text = String.Empty
        Me.txt_cliente.Text = String.Empty
        Me.txt_fechaVcto.Text = String.Empty
        Me.dtp_nueva_fecha.Text = Today.AddDays(-1)
    End Sub



    Private Sub dgvDocumentos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocumentos.CurrentCellChanged
        Try
            Me.txtTipodocto.Text = Me.dgvDocumentos.Item("tipodocto", dgvDocumentos.CurrentRow.Index).Value
            Me.hacer_busqueda()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.TextChanged

    End Sub

    Private Sub btnAplicarFechaProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarFechaProduccion.Click
        If Me.txtNumeroOCProduccion.Text.Length = 10 Then


            Dim otrans As New Transaccional.Conexion("FlexLine")

            Try
                otrans.open()
                otrans.Actualiza("pa_upd_um_documento_analisis '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCProduccion.Text & "','" & gs_usuario & "','" & _
                                Me.txtComentarioProduccion.Text & "',null,'" & _
                                  Me.dtpFechaProduccionActualizacion.Value.ToString("dd/MM/yyyy") & "'")


                If otrans.Codigo_error > 0 Then
                    MessageBox.Show("problemas al actualizar Fecha de Produccion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Log_Ocfechas(Me.txtNumeroOCProduccion.Text, "Propiedades OC", "ORDEN DE COMPRA")
                    MessageBox.Show("Fecha de Produccion Actualizacion Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroOCProduccion.Text = String.Empty
                    Me.dtpFechaProduccionActualizacion.Value = Today.AddDays(-1)
                End If

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing

            End Try
        End If
    End Sub

    'Private Sub btnAplicarFechaDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.txtNumeroOCDespacho.Text.Length = 10 Then


    '        Dim otrans As New Transaccional.Conexion("FlexLine")

    '        Try
    '            otrans.open()
    '            otrans.Actualiza("pa_upd_um_documento_analisis '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtNumeroOCDespacho.Text & "','" & gs_usuario & "','" & _
    '                            Me.txtMotivoFechaDespacho.Text & "','" & Me.dtpFechaDespachoActualizacion.Value.ToString("dd/MM/yyyy") & "',null")


    '            If otrans.Codigo_error > 0 Then
    '                MessageBox.Show("problemas al actualizar Fecha de Despacho", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Else
    '                MessageBox.Show("Fecha de Despacho Actualizada Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.txtNumeroOCDespacho.Text = String.Empty
    '                Me.txtMotivoFechaDespacho.Text = String.Empty
    '                Me.dtpFechaDespachoActualizacion.Value = Today.AddDays(-1)
    '            End If

    '        Catch ex As Exception
    '        Finally
    '            otrans.close()
    '            otrans = Nothing

    '        End Try
    '    End If
    'End Sub

    Private Sub btnOCPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOCPendientes.Click
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "Select numero,fecha,proveedor,fechavcto,total,vigencia,comentario1 from documento  Where " & _
                    "tipodocto = 'CONFIRMACION PROVEEDOR' and porcentajeasignado = 0 and vigencia <> 'A' and empresa = '" & gs_empresa & "' " & _
                    "order by fecha"
            dt = oTrans.Obtiene(lsSQL)


            Dim oform As New frm_resultado
            oform.Text = "::. Ordenes de Compra Pendientes de Seguimiento .::"
            oform.dgv_resultado.DataSource = dt
            ClsGen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", "", "", "", True, True, 250, 0)

            oform.ShowDialog()

            oform.Dispose()
            oform = Nothing

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub



    

#Region "Fecha Arribo Puerto"


    Private Sub mostrarInformacionFAP()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'FECHA ARRIBO PUERTO','" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            ds.Tables("productos").Rows.Clear()
            Me.dgvProductosOC.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("vigencia").ToString.ToLower <> "a" And _
                    dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado
                    ' Me.dtpFechaVencimientoConfirmacion.Value = dt.Rows(0).Item("fechaVcto")
                    'Me.dtpFechaDespacho.Value = dt.Rows(0).Item("fechaDespacho")
                    'Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
                    'Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString
                    Me.lbl_fap_Correlativo.Text = dt.Rows(0)("correlativo")
                    Me.txt_fap_proveedor.Text = dt.Rows(0)("proveedor").ToString

                    For Each dr As DataRow In dt.Rows
                        draux = ds.Tables("productos").NewRow
                        draux.Item("producto") = dr.Item("producto")
                        draux.Item("glosa") = dr.Item("glosa")
                        draux.Item("unidad") = dr.Item("unidadingreso")
                        draux.Item("cantidad_pedido") = dr.Item("cantidadingreso")
                        draux.Item("preciou") = dr.Item("precioingreso")
                        draux.Item("total") = dr.Item("subtotalingreso")
                        draux.Item("cantidad_facturada") = dr.Item("valor1")
                        If dr.Item("valor2").ToString = "" Then
                            
                            draux.Item("fechaVencimiento") = Date.Today


                        Else
                            draux.Item("fechaVencimiento") = dr.Item("valor2")
                        End If

                        draux.Item("codigo_proveedor") = dr.Item("codigoProveedor")
                        Try
                            draux.Item("cantidad_facturada") = dr.Item("valor1").ToString
                        Catch ex As Exception

                        End Try
                        ds.Tables("productos").Rows.Add(draux)
                    Next



                    Me.dgv_fap_productos.DataSource = ds.Tables("productos")
                    Dim dgtbc, dgtbc2 As New DataGridViewComboBoxColumn
                    dgtbc.DataSource = ds.Tables("tipo_unidad")
                    dgtbc.ValueMember = "unidad"
                    dgtbc.DisplayMember = "unidad"
                    dgtbc.HeaderText = "unidad"
                    dgtbc.DataPropertyName = "unidad"
                    dgtbc.Name = "unidad"
                    clsGen.Alinear_GridViewComboBox(dgtbc)
                    clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_fap_productos, "", "", "unidad,preciou,cantidad_pedido,glosa,total,codigo_proveedor,", ",cantidad_pedido,preciou,total,", "", ",cantidad_pedido=60,cantidad_facturada=60,unidad=40,fechaVencimineto=40,codigo_proveedor=60,", "", True, True, 200, 0)

                    Me.txt_fap_numeroOC.Enabled = False
                Else
                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                        MessageBox.Show("Esta Orden de Compra No Esta Vigente, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtNumeroOC.Text = String.Empty
                    Else
                        MessageBox.Show("Esta Orden de Compra Esta Anulada o Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtNumeroOC.Text = String.Empty
                    End If
                End If
            Else
                MessageBox.Show("Problemas con Esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtNumeroOC.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
            totalizar()
        End Try
    End Sub

    Private Sub txt_fap_numeroOC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fap_numeroOC.KeyDown

    End Sub

    Private Sub txt_fap_numeroOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fap_numeroOC.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_fap_numeroOC.Text = Me.txt_fap_numeroOC.Text.PadLeft(10, "0")
            CrearEstructura()
            llenarCombos()
            mostrarInformacionFAP()
        End If
    End Sub



    Private Sub dgv_fap_productos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_fap_productos.CellEnter
        Try
            If e.RowIndex > -1 Then
                If Me.dgv_fap_productos.Item("cantidad_pedido", e.RowIndex).Value > 0 Then
                    Me.dgv_fap_productos.Item("producto", e.RowIndex).ReadOnly = True
                    Me.dgv_fap_productos.Item("unidad", e.RowIndex).ReadOnly = True
                Else
                    Me.dgv_fap_productos.Item("producto", e.RowIndex).ReadOnly = False
                    Me.dgv_fap_productos.Item("unidad", e.RowIndex).ReadOnly = False
                End If
            End If

        Catch ex As Exception
        Finally
            totalizar()
        End Try

    End Sub

    Private Sub totalizar()
        Dim total As Double

        Try
            total = ds.Tables("productos").Rows.Count
            Me.lbl_fap_lineas.Text = total
            total = ds.Tables("productos").Compute("Sum(cantidad_facturada)", "cantidad_facturada>0")
            Me.lbl_fap_unidades_facturadas.Text = total
        Catch ex As Exception
        End Try


        Try
            total = ds.Tables("productos").Compute("Sum(cantidad_pedido)", "cantidad_pedido>0")
            Me.lbl_fap_unidades_solicitadas.Text = total
        Catch ex As Exception
        End Try

    End Sub

    Private Sub guardarAvisoFAP(ByVal psproducto As String, ByVal psglosa As String, ByVal picantidad As Integer, ByVal picantidad_facturada As Integer)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dtusuarioEmpresa As DataTable
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim bguardarAviso As Boolean = False


        Try
            Otrans.open()

            lsSQL = "pa_sel_um_gen_tabcod '" & Me.txt_fap_proveedor.Text & "','CON_PROVEE','" & gs_empresa & "'"
            dt2 = Otrans.Obtiene(lsSQL)

            lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
            dtusuarioEmpresa = Otrans.Obtiene(lsSQL)

            dt = ClsGen.usuariosAviso(8)

            For Each dr As DataRow In dt.Rows

                If dr.Item("validar_marca").ToString = "1" Then
                    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                    If dt2.DefaultView.Count > 0 Then bguardarAviso = True

                ElseIf dr.Item("validar_empresa").ToString = "1" Then 'validar empresa
                    dtusuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                    If dtusuarioEmpresa.DefaultView.Count > 0 Then bguardarAviso = True

                Else
                    bguardarAviso = True
                End If

                If bguardarAviso Then
                    lsSQL = "OC No. " & Me.txt_fap_numeroOC.Text & " " & Me.txt_fap_proveedor.Text & " Producto " & psproducto & "-" & psglosa & " Se Solicito " & picantidad & " y Facturaron " & picantidad_facturada
                    ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsSQL, 8)
                    bguardarAviso = False
                End If

            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub guardarCambios_fap()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL, fecha_vencimiento As String
        fecha_vencimiento = ""



        Try
            Otrans.open()
            For Each dr As DataRow In ds.Tables("productos").Rows

                If dr.Item("fechaVencimiento") = Today Then

                    fecha_vencimiento = ""
                Else
                    fecha_vencimiento = dr.Item("fechaVencimiento")
                End If

                If dr.Item("cantidad_pedido").ToString = "" Then   ''Cuando Cantidad = 0, es por q es nueva linea

                    lsSQL = "pa_ins_um_documentod '" & gs_empresa & "','FECHA ARRIBO PUERTO', " & Me.lbl_fap_Correlativo.Text & ",null,'"
                    lsSQL += dr.Item("producto").ToString & "',0,0,0,0,1,'" & Today.ToString() & "',0,0,"
                    lsSQL += "null,null,'" & dr.Item("unidad").ToString & "'," & dr.Item("cantidad_facturada").ToString & ",'" & fecha_vencimiento & "'"


                    Otrans.Ingresa(lsSQL)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show(Otrans.descripcion_error, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    '@P_empresa as varchar(20),
                    '@P_TipoDocto as Varchar(40),
                    '@P_Correlativo as numeric,--op
                    '@P_Secuencia as numeric,--pendiente
                    '@P_Producto as varchar(20),
                    '@P_Cantidad as decimal(20,8),
                    '@P_precio as decimal(20,8),
                    '@P_total_con_Iva as decimal(20,8),
                    '@P_diascredito as numeric,
                    '@P_factor as decimal(20,8),
                    '@P_fecha as varchar(15),
                    '@P_PrecioListaP as decimal(20,8),
                    '@P_Costo as decimal(20,8),
                    '@P_Linea as numeric, --pendiente
                    '@P_VigenciaLP as varchar(15)=NULL,
                    '@PunidadIngreso as VarChar(20)=NULL,
                    '@P_Valor1 AS numeric=NULL
                Else
                    lsSQL = "pa_upd_um_documentod_valor '" & gs_empresa & "','FECHA ARRIBO PUERTO','" & Me.txt_fap_numeroOC.Text & "','" & dr.Item("PRODUCTO").ToString & "'," & _
                                   dr.Item("cantidad_facturada") & ",'" & fecha_vencimiento & "'"
                    Otrans.Actualiza(lsSQL)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show(Otrans.descripcion_error, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
                If dr.Item("cantidad_facturada") <> dr.Item("cantidad_pedido") Then
                    guardarAvisoFAP(dr.Item("producto"), dr.Item("glosa"), dr.Item("cantidad_pedido"), dr.Item("cantidad_facturada"))
                End If

            Next

            MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Log_Ocfechas(Me.txt_fap_numeroOC.Text, "Fecha Arribo Puerto", "FECHA ARRIBO PUERTO")


         

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub dgv_fap_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_fap_productos.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex



        Try

            'Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon

            Dim c As Control = Me.dgv_fap_productos.EditingControl



            Select Case Me.dgv_fap_productos.Columns(e.ColumnIndex).Name.ToLower
                Case "producto"

                    Dim oFlex As New Umbral_Flex.productos
                    Dim dt As DataTable
                    If c.Text = "+" Then
                        Dim frm_busqueda As New frm_busqueda_general
                        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                        frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                        frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
                        frm_busqueda.txt_buscar1.Focus()
                        frm_busqueda.ShowDialog(Me)

                        c.Text = frm_busqueda.resultado
                        frm_busqueda.Dispose()
                        frm_busqueda = Nothing
                        dt = oFlex.Obtener_Producto(gs_empresa, c.Text)
                    Else
                        dt = oFlex.Obtener_Producto(gs_empresa, c.Text)
                    End If
                    oFlex.close()
                    oFlex = Nothing

                    If dt.Rows.Count = 1 Then
                        ''Validar que el cliente no este en la lista
                        If dt.Rows(0)("VIGENTE").ToString.ToLower = "s" Then
                            Me.dgv_fap_productos.Item("fechaVencimiento", e.RowIndex).Value = Date.Today
                            Me.dgv_fap_productos.Item("producto", e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
                            Me.dgv_fap_productos.Item("glosa", e.RowIndex).Value = dt.Rows(0).Item("glosa").ToString
                            Me.dgv_fap_productos.Item("cantidad", e.RowIndex).Value = 0
                            Me.dgv_fap_productos.Item("preciou", e.RowIndex).Value = 0
                            Me.dgv_fap_productos.Item("total", e.RowIndex).Value = 0


                        Else
                            MessageBox.Show("El Producto No Esta Vigente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Case "cantidad_facturada"
                    'If Me.dgv_fap_productos.Item("preciou", e.RowIndex).Value > 0 Then
                    '    Me.dgv_fap_productos.Item("total", e.RowIndex).Value = c.Text * Me.dgv_fap_productos.Item("preciou", e.RowIndex).Value
                    totalizar()
                    'End If
                    'Case "preciou"
                    '    If Me.dgv_fap_productos.Item("cantidad", e.RowIndex).Value > 0 Then
                    '        Me.dgv_fap_productos.Item("total", e.RowIndex).Value = c.Text * Me.dgv_fap_productos.Item("cantidad", e.RowIndex).Value
                    '        totalizar()
                    '    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_fap_productos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgv_fap_productos.UserDeletingRow
        Try
            If e.Row.Index > -1 Then
                If Me.dgv_fap_productos.Item("cantidad", e.Row.Index).Value > 0 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_fac_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fac_guardar.Click
        Try
            Me.btn_fac_guardar.Enabled = False
            guardarCambios_fap()
            Me.btn_fac_guardar.Enabled = True
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub txt_fap_numeroOC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fap_numeroOC.KeyUp

    End Sub


    Private Sub txt_fap_numeroOC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fap_numeroOC.TextChanged

    End Sub

    Private Sub btn_fap_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fap_nuevo.Click
        Me.dgv_fap_productos.DataSource = Nothing
        Me.txt_fap_numeroOC.Text = String.Empty
        Me.txt_fap_proveedor.Text = String.Empty
        Me.lbl_fap_lineas.Text = String.Empty
        Me.lbl_fap_unidades_solicitadas.Text = String.Empty
        Me.lbl_fap_unidades_facturadas.Text = String.Empty
        Me.txt_fap_numeroOC.Enabled = True
        Me.lbl_fap_Correlativo.Text = String.Empty
    End Sub

    Private Sub dgv_fap_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_fap_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_fap_productos.Rows(rowIndex)
                'If therow.Cells("combo").Value.ToString() = "si" Then
                '    therow.DefaultCellStyle.ForeColor = Color.Green
                'Else
                If therow.Cells("cantidad_pedido").Value < therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                ElseIf therow.Cells("cantidad_pedido").Value > therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Brown
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If

               

            End If
            'color azul
            'Me.dg_presupuesto.Columns("Vigente").Width = 5
        Catch ex As Exception
        End Try

    End Sub

   

    Private Sub dgv_fap_productos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_fap_productos.DataError
        MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub txt_no_orden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_orden.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_no_orden.Text = Me.txt_no_orden.Text.PadLeft(10, "0")
            Crear_Estructura()
            llenar_informacion()

        End If
    End Sub

    Private Sub btn_limpiar_control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar_control.Click
        Me.dtp_fecha_vencimiento.Value = Today.Date
        Me.dtp_fecha_despacho.Value = Today.Date
        Me.dgv_control.DataSource = Nothing
        'Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
        'Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString
        Me.lbl_correlativo.Text = String.Empty
        Me.txt_proveedor_control.Text = String.Empty
        Me.txt_no_orden.Enabled = True
        Me.txt_no_orden.Text = ""
        Me.btn_guardar_control.Text = "Guardar"

       
    End Sub

    Private Sub btn_guardar_control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_control.Click
        If Me.lbl_correlativo.Text <> "123456" And Me.lbl_correlativo.Text <> "" Then
            Guarda_informacion()
        End If
    End Sub

  
    Private Sub eliminar_comentario()
        Dim ls_sql As String
        Dim dt As DataTable

        Dim oTrans As New Transaccional.Conexion("Flexline")

        Dim dr As DataRow
        Dim asig, ing, cuenta, lotiene As Integer

        Try
            oTrans.open()


            ls_sql = "pa_del_um_gen_log_documento '" & gs_empresa & "','GEN_OCTRACKING_COM','" & Me.txt_no_orden_comentario.Text & " ','" & no_comentario & "'"

            oTrans.Elimina(ls_sql)
            MessageBox.Show("Comentario Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            no_comentario = ""


        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub
  
    Private Sub btn_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comentario.Click


        'If modifica = False And Me.btn_comentario.Text = "Agregar" Then
        'GUARDA
        If Trim(Me.txt_comentario.Text) <> "" And Me.txt_no_orden_comentario.TextLength > 0 Then
            guardar_comentario()
            llenar_comentarios(Me.txt_no_orden_comentario.Text)
            Me.txt_comentario.Focus()
            Me.btn_comentario.Text = "Agregar"
            Me.txt_comentario.ReadOnly = False
        Else
            MessageBox.Show("No se Puede Grabar, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        'ElseIf modifica = True And Me.btn_comentario.Text = "Eliminar" Then

        '    'ELIMINA
        '    eliminar_comentario()

        '    Me.btn_comentario.Text = "Agregar"
        '    Me.txt_comentario.ReadOnly = False
        '    llenar_comentarios(Me.txt_no_orden_comentario.Text)
        '    modifica = False


        'End If
    End Sub
    Private Sub llenar_comentarios(ByVal Pnumero)

        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt, dt2, dt3, dt4, dt5 As DataTable
        Dim dr, dr2, dr_aux, dr_aux2 As DataRow
        Dim entro As Integer
        Dim i As Integer
        Dim acceso As Boolean = False
        Dim oTransC As New Transaccional.Conexion("Flexline")


        crear_struc_comentario()

        ds2.Tables("comentarios").Rows.Clear()


        Try

            oTransC.open()


            ls_sql = "pa_sel_um_control_historialdoc_com '" & gs_empresa & "','" & Pnumero & "'"
            dt5 = oTransC.Obtiene(ls_sql)


            If dt5.Rows.Count > 0 Then

                For Each dr In dt5.Rows
                    dr_aux2 = ds2.Tables("comentarios").NewRow
                    dr_aux2.Item("Comentario") = dr.Item("comentario").ToString
                    dr_aux2.Item("Fecha") = dr.Item("fecha_grabo").ToString
                    dr_aux2.Item("Usuario") = dr.Item("usuario_grabo")
                    ds2.Tables("comentarios").Rows.Add(dr_aux2)
                Next

                clsgen.Alinear_GridView(ds2.Tables("comentarios"), Me.dgv_comentarios, ",Comentario,Fecha,Usuario,", "", "", "", "", ",Comentario=550,Fecha=110,Usuario=60,", "", True, True, 200, 0)

            End If

        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
        End Try


    End Sub

    Private Sub llenar_informacion_comentario()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql, lsSQL, ls_sql2 As String
        Dim dt, dt2 As DataTable
        Dim dr, dr2, dr_aux As DataRow
        Dim total_registros, contador As Integer
        Dim i As Integer
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim oTransC As New Transaccional.Conexion("SCM")

        Try
            oTrans.open()
            oTransC.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'ORDEN DE COMPRA','" & gs_empresa & "','" & Me.txt_no_orden_comentario.Text & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                Me.dtp_fecha_vencimiento_comentario.Value = dt.Rows(0).Item("fechaVcto")
                Me.dtp_fecha_despacho_comentario.Value = dt.Rows(0).Item("fechaDespacho")
                'Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
                'Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString

                Me.txt_proveedor_comentario.Text = dt.Rows(0)("proveedor").ToString

                llenar_comentarios(Me.txt_no_orden_comentario.Text)
                Me.txt_no_orden_comentario.Enabled = False


            Else

                MessageBox.Show("Problemas con esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)


            End If
        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub dgv_comentarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_comentarios.Click

        Dim dr As DataRow
        Dim nRow As Integer


        Try
            nRow = Me.dgv_comentarios.CurrentCell.RowIndex
            no_comentario = Me.dgv_comentarios.Item(0, nRow).Value.ToString
            '   Me.txt_comentario.Text = Me.dgv_comentarios.Item(0, nRow).Value.ToString

            clic = True



        Catch ex As Exception

        End Try

    End Sub


    Private Sub txt_no_orden_comentario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_orden_comentario.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_no_orden_comentario.Text = Me.txt_no_orden_comentario.Text.PadLeft(10, "0")
            llenar_informacion_comentario()
        End If
    End Sub

  

    Private Sub btn_nuevo_orden_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_orden_comentario.Click
        Me.dtp_fecha_vencimiento_comentario.Value = Today.Date
        Me.dtp_fecha_despacho_comentario.Value = Today.Date
        Me.dgv_comentarios.DataSource = Nothing
        Me.txt_proveedor_comentario.Text = String.Empty
        Me.txt_no_orden_comentario.Enabled = True
        Me.txt_no_orden_comentario.Text = ""
        Me.btn_comentario.Text = "Agregar"
    End Sub

    Private Sub dgv_comentarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_comentarios.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If clic = True And no_comentario <> "" Then
            If MessageBox.Show("Esta Seguro de Eliminar el Comentario", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminar_comentario()

                llenar_comentarios(Me.txt_no_orden_comentario.Text)
                clic = False
            End If
        Else

            MessageBox.Show("No se Puede Eliminar, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub


    Private Sub dgv_control_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_control.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try

            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_control.Rows(rowIndex)
                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                    therow.DefaultCellStyle.BackColor = Color.DarkSeaGreen '.PaleGreen   'LightGreen
                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False And numero > 0 Then
                    therow.DefaultCellStyle.BackColor = Color.Tomato

                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False And numero = 0 Then
                    therow.DefaultCellStyle.BackColor = Color.Gold
                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = False And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False Then
                    therow.DefaultCellStyle.BackColor = Color.White

                End If
                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False Then
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = True
                Else
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = False
                End If
                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = 0
                    therow.DefaultCellStyle.BackColor = Color.White
                End If




            End If




        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_control_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_control.CellContentClick

    End Sub

    Private Sub txt_no_orden_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_orden.TextChanged

    End Sub

    Private Sub txt_no_orden_comentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_orden_comentario.TextChanged

    End Sub



    Private Sub dgv_control_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_control.CellValueChanged


        Try
            If Me.dgv_control.Item("descripcion", e.RowIndex).Value.ToString.ToLower.StartsWith("factura") Then


                If Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                    'MessageBox.Show("levantar Pantalla Para Ingreso de Multiples facturas " & Me.dgv_control.Item("descripcion", e.RowIndex).Value)
                    Dim oform As New frm_OCFacturas
                    oform.txtOrden.Text = Me.txt_no_orden.Text
                    oform.txtProveedor.Text = Me.txt_proveedor_control.Text
                    oform.ShowDialog()
                    oform.Dispose()
                    oform = Nothing
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class