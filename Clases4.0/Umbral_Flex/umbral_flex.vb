Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Data
Imports System.Math

'(c) 20230711 Se traslado la opción de verificar stock vinoteca y se enlazo con sincronización para que se facture automaticamente
' Se generarón claves de xmlconfig para parametrizar usuarios


#Region "Informacion de Productos"

Public Class productos
    Public oTrans As Transaccional.Conexion

    Public Sub New()
        Conectarse("FlexLine")
    End Sub

    Public Sub New(ByVal lsConexion)
        Conectarse(lsConexion)
    End Sub

    Private Sub Conectarse(ByVal ls_conexion)
        oTrans = New Transaccional.Conexion(ls_conexion)
        oTrans.open()
    End Sub

    Public Function Obtener_Precios(ByVal pempresa As String, ByVal pproducto As String, ByVal plista As String, ByVal poferta As Boolean, ByVal pcliente As String) As DataTable

        Dim ls_sql As String

        Dim dt As DataTable


        Try

            ''Memos Procionales lista individual o todas las listas, Cliente Individual o todos los clientes
            If poferta Then
                ls_sql = "pa_sel_um_productooferta '" & pempresa & "','" & _
                        pproducto & "'," & _
                        IIf(plista.Length = 0, "NULL", "'" & plista & "',") & _
                        IIf(pcliente.Length = 0, "NULL", "'" & pcliente & "'")


                'Precios Para Un Cliente Especifico
            ElseIf pcliente.Length > 0 Then
                ls_sql = "pa_sel_um_listaprecioD_cliente '" & pempresa & "','" & pproducto & "','" & _
                            pcliente & "'"
            Else
                'Precios  en General
                ls_sql = "pa_sel_um_listapreciod '" & pempresa & "','" & _
                         pproducto & "',"

                If plista.Length = 0 Then
                    ls_sql = ls_sql & "NULL"
                Else
                    ''Lista de Precios Especifica
                    ls_sql = ls_sql & "'" & plista & "'"
                End If
            End If

            dt = oTrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt

    End Function
    '''Devuelve las listas de precios en las que esta el producto
    '''2
    '''3
    '''4

    Public Function Obtener_Precio_Final(ByVal empresa As String, ByVal producto As String) As DataTable
        Dim dt As DataTable
        dt = Obtener_Precio_Final(empresa, producto, "", "")
        Return dt
    End Function

    Public Function Obtener_Precio_Final(ByVal empresa As String, ByVal producto As String, ByVal pcliente As String) As DataTable
        Dim dt As DataTable
        dt = Obtener_Precio_Final(empresa, producto, pcliente, "")
        Return dt
    End Function

    Public Function Obtener_Precio_Final(ByVal pempresa As String, ByVal pproducto As String, ByVal pcliente As String, ByVal plista As String) As DataTable
        Dim dt As DataTable
        Dim ls_sql As String
        Dim lprecio As Boolean = False



        Try

            If pcliente.Length > 0 Then
                ls_sql = "pa_sel_um_productooferta '" & pempresa & "','" & _
                                        pproducto & "'," & _
                                        IIf(plista.Length = 0, "NULL,", "'" & plista & "',") & _
                                        "'" & pcliente & "'"
                dt = oTrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    lprecio = True
                End If
            End If

            If Not lprecio Then
                If pcliente.Length = 0 Then
                    ls_sql = "pa_sel_um_listapreciod '" & pempresa & "','" & _
                            pproducto & "'," & _
                            IIf(plista.Length = 0, "NULL", "'" & plista & "'")
                    dt = oTrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        lprecio = True
                        Exit Try
                    End If
                ElseIf pcliente.Length > 0 Then
                    ls_sql = "pa_sel_um_listapreciod_cliente '" & pempresa & "','" & _
                                                pproducto & "','" & pcliente & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    lprecio = True
                    Exit Try
                End If
            End If



        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt


    End Function


    Public Function Obtener_Precio_Final(ByVal pempresa As String, ByVal pproducto As String, ByVal pcliente As String, ByVal plista As String, ByVal pCantidadPedido As Integer) As DataTable
        Dim dt As DataTable
        Dim ls_sql As String
        Dim lprecio As Boolean = False



        Try

            If pcliente.Length > 0 Then
                ls_sql = "pa_sel_um_productooferta '" & pempresa & "','" & _
                                        pproducto & "'," & _
                                        IIf(plista.Length = 0, "NULL,", "'" & plista & "',") & _
                                        "'" & pcliente & "'"
                dt = oTrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    lprecio = True
                End If
            End If

            If Not lprecio Then
                If pcliente.Length = 0 Then
                    ls_sql = "pa_sel_um_listapreciod '" & pempresa & "','" & _
                            pproducto & "'," & _
                            IIf(plista.Length = 0, "NULL", "'" & plista & "'")
                    dt = oTrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        lprecio = True
                        '       Exit Try
                    End If
                ElseIf pcliente.Length > 0 Then
                    ls_sql = "pa_sel_um_listapreciod_cliente '" & pempresa & "','" & _
                                                pproducto & "','" & pcliente & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        lprecio = True
                        '       Exit Try
                    Else

                        ls_sql = "pa_sel_um_listapreciod '" & pempresa & "','" & _
                            pproducto & "'," & _
                            IIf(plista.Length = 0, "NULL", "'" & plista & "'")
                        dt = oTrans.Obtiene(ls_sql)
                        lprecio = True
                    End If

                    '    Exit Try
                End If

                If lprecio Then
                    'if 
                End If


            End If



        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt


    End Function

    Public Function Obtener_Existencias(ByVal pproducto As String, ByVal pbodega As String) As DataTable
        Dim ls_sql As String

        Dim dt As DataTable
        ' Dim otrans As New Transaccional.Conexion("flexline")
        Try
            '    otrans.open()
            ls_sql = "pa_var_um_existencias_producto NULL," & _
                             IIf(pproducto.ToString.Length = 0, "NULL", "'" & pproducto & "'") & _
                             IIf(pbodega.ToString.Length = 0, "", ",'" & pbodega & "'")

            dt = oTrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Obtener_Existencias(ByVal pempresa As String, ByVal pproducto As String, ByVal pbodega As String) As DataTable
        Dim ls_sql As String

        Dim dt As DataTable
        ' Dim otrans As New Transaccional.Conexion("flexline")
        Try
            '    otrans.open()
            ls_sql = "pa_var_um_existencias_producto '" & _
                             pempresa & "'," & _
                             IIf(pproducto.ToString.Length = 0, "NULL", "'" & pproducto & "'") & _
                             IIf(pbodega.ToString.Length = 0, "", ",'" & pbodega & "'")

            dt = oTrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Obtener_Existencias_Lote(ByVal pempresa As String, ByVal pproducto As String, ByVal pbodega As String) As DataTable
        Dim ls_sql As String

        Dim dt As DataTable
        ' Dim otrans As New Transaccional.Conexion("flexline")
        Try
            '    otrans.open()
            ls_sql = "pa_var_um_existencias_producto_lote '" & _
                             pempresa & "'," & _
                             IIf(pproducto.ToString.Length = 0, "NULL", "'" & pproducto & "'") & _
                             IIf(pbodega.ToString.Length = 0, "", ",'" & pbodega & "'")

            dt = oTrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Obtener_Producto(ByVal pempresa As String, ByVal pproducto As String) As DataTable
        Dim dt As DataTable
        Dim ls_sql As String
        ls_sql = "pa_sel_um_producto "
        If pempresa.Trim.Length = 0 Then
            ls_sql += "NULL,"
        Else
            ls_sql += "'" & pempresa & "',"
        End If
        If pproducto.Trim.Length = 0 Then
            ls_sql += "NULL"
        Else
            ls_sql += "'" & pproducto & "'"
        End If
        dt = oTrans.Obtiene(ls_sql)

        Return dt

    End Function

    Public Function Obtener_ProductoBodega(ByVal pempresa As String, ByVal pbodega As String, ByVal pproducto As String) As DataTable
        Dim dt As DataTable
        Dim ls_sql As String
        ls_sql = "pa_sel_um_prodbodegas "
        If pempresa.Trim.Length = 0 Then
            ls_sql += "NULL,"
        Else
            ls_sql += "'" & pempresa & "',"
        End If

        If pbodega.Trim.Length = 0 Then
            ls_sql += "NULL,"
        Else
            ls_sql += "'" & pbodega & "',"
        End If

        If pproducto.Trim.Length = 0 Then
            ls_sql += "NULL"
        Else
            ls_sql += "'" & pproducto & "'"
        End If
        dt = oTrans.Obtiene(ls_sql)

        Return dt

    End Function
    Public Sub close()
        oTrans.close()
        oTrans = Nothing
    End Sub


End Class

#End Region

#Region "Guardar Pedidos "
Public Class Pedidos
    ''Variables 
    Public ods As DataSet
    Public serror As String = ""
    Public Validar_Totales As Boolean = True
    Public Consignaciones As Boolean = False
    Public Reestructura As Boolean = False

    Public Sub New()
        Crear_Estructura()
    End Sub

    Public Sub New(ByVal bconsignacion As Boolean, ByVal bReestructura As Boolean)
        Reestructura = bReestructura
        Crear_Estructura()
    End Sub

    Public Sub New(ByVal bconsignacion As Boolean)
        Consignaciones = bconsignacion
        Crear_Estructura()
    End Sub
    '
    'Inicializa la Informacion
    '
    Public Sub Limpiar_Datos()
        ods.Tables("encabezado").Rows.Clear()
        ods.Tables("detalle").Rows.Clear()
        ods.Tables("documentop").Rows.Clear()
        ods.Tables("documentov").Rows.Clear()
    End Sub

    Private Sub Crear_Estructura()

        ods = New DataSet
        Dim dt As New DataTable("encabezado")

        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String))) 'Codigo de Cliente Anterior
        dt.Columns.Add(New DataColumn("Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega2", GetType(String)))
        dt.Columns.Add(New DataColumn("Local", GetType(String)))
        dt.Columns.Add(New DataColumn("Comprador", GetType(String)))
        dt.Columns.Add(New DataColumn("vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("CentroCosto", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaVcto", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("diascredito", GetType(Integer)))
        dt.Columns.Add(New DataColumn("listaprecio", GetType(String)))
        dt.Columns.Add(New DataColumn("Analisis", GetType(String)))
        dt.Columns.Add(New DataColumn("Zona", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoCta", GetType(String)))
        dt.Columns.Add(New DataColumn("Moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("Paridad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Neto", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotal", GetType(Double)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt.Columns.Add(New DataColumn("NetoIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotalIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("TotalIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("Centraliza", GetType(String)))
        dt.Columns.Add(New DataColumn("Valoriza", GetType(String)))
        dt.Columns.Add(New DataColumn("Costeo", GetType(String)))
        dt.Columns.Add(New DataColumn("factor", GetType(Double)))
        dt.Columns.Add(New DataColumn("aprobacion", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoComprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("periodo", GetType(String)))
        dt.Columns.Add(New DataColumn("PeriodoLibro", GetType(Integer)))
        dt.Columns.Add(New DataColumn("FactorMonto", GetType(Integer)))
        dt.Columns.Add(New DataColumn("TipoCtaCte", GetType(String)))
        dt.Columns.Add(New DataColumn("IdCtaCte", GetType(String)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario1", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario2", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario3", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario4", GetType(String)))
        dt.Columns.Add(New DataColumn("Vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("Emitido", GetType(String)))
        dt.Columns.Add(New DataColumn("PorcentajeAsignado", GetType(Double)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna", GetType(String)))
        dt.Columns.Add(New DataColumn("EstadoDir", GetType(String)))
        dt.Columns.Add(New DataColumn("pais", GetType(String)))
        dt.Columns.Add(New DataColumn("contacto", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaModif", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaUModif", GetType(String)))
        dt.Columns.Add(New DataColumn("usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("UsuarioModif", GetType(String)))
        dt.Columns.Add(New DataColumn("ComisionTotal", GetType(Double)))
        dt.Columns.Add(New DataColumn("ComisionLPrecio", GetType(Double)))
        dt.Columns.Add(New DataColumn("Hora", GetType(String)))
        dt.Columns.Add(New DataColumn("Caja", GetType(String)))
        dt.Columns.Add(New DataColumn("Pago", GetType(Double)))
        dt.Columns.Add(New DataColumn("Donacion", GetType(Double)))
        dt.Columns.Add(New DataColumn("IdApertura", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Multipagina", GetType(String)))
        dt.Columns.Add(New DataColumn("NetoBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotalBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("TotalBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ParidadBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("AnalisisE1", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE2", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE3", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE7", GetType(String)))

        dt.Columns.Add(New DataColumn("AnalisisE10", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE21", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE22", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE23", GetType(String)))
        dt.Columns.Add(New DataColumn("AnalisisE24", GetType(String)))

        dt.Columns.Add(New DataColumn("UsuarioAprueba", GetType(String)))
        dt.Columns.Add(New DataColumn("ReferenciaExterna", GetType(String)))


        ods.Tables.Add(dt.Copy)

        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Correlativo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt.Columns.Add(New DataColumn("precio", GetType(Double)))
        dt.Columns.Add(New DataColumn("PorcentajeDr", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotal", GetType(Double)))
        dt.Columns.Add(New DataColumn("Impuesto", GetType(Double)))
        dt.Columns.Add(New DataColumn("Neto", GetType(Double)))
        dt.Columns.Add(New DataColumn("DrGlobal", GetType(Double)))
        dt.Columns.Add(New DataColumn("Costo", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("PrecioAjustado", GetType(Double)))
        dt.Columns.Add(New DataColumn("UnidadIngreso", GetType(String)))
        dt.Columns.Add(New DataColumn("CantidadIngreso", GetType(Integer)))
        dt.Columns.Add(New DataColumn("PrecioIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotalIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ImpuestoIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("NetoIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("DrGlobalIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("TotalIngreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("CorrelativoOrigen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("SecuenciaOrigen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("FactorInventario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("FechaEntrega", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("CantidadAsignada", GetType(Double)))
        dt.Columns.Add(New DataColumn("diascredito", GetType(Integer)))
        dt.Columns.Add(New DataColumn("factor", GetType(Double)))
        dt.Columns.Add(New DataColumn("precioLP", GetType(Double)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Vigente", GetType(String)))
        dt.Columns.Add(New DataColumn("CUP", GetType(Double)))
        dt.Columns.Add(New DataColumn("Ubicacion", GetType(String)))
        dt.Columns.Add(New DataColumn("Ubicacion2", GetType(String)))
        dt.Columns.Add(New DataColumn("Cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("Impdist", GetType(Double)))
        dt.Columns.Add(New DataColumn("FactorImpto", GetType(Double)))
        dt.Columns.Add(New DataColumn("PrecioBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("SubTotalBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ImpuestoBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("NetoBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("DrGlobalBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("TotalBimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("PrecioListaP", GetType(Double)))
        dt.Columns.Add(New DataColumn("UniMedDynamic", GetType(Double)))
        dt.Columns.Add(New DataColumn("costo", GetType(Double)))
        dt.Columns.Add(New DataColumn("FechaVigenciaLp", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("LoteDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("SerieDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("ProdAlias", GetType(String)))
        dt.Columns.Add(New DataColumn("DoctoOrigenVal", GetType(String)))
        dt.Columns.Add(New DataColumn("MontoAsignado", GetType(Double)))
        dt.Columns.Add(New DataColumn("Aux_Valor3", GetType(String)))
        dt.Columns.Add(New DataColumn("Aux_Valor6", GetType(String)))
        dt.Columns.Add(New DataColumn("Aux_Valor8", GetType(String)))
        dt.Columns.Add(New DataColumn("Aux_Valor9", GetType(String)))
        dt.Columns.Add(New DataColumn("Aux_Valor10", GetType(String)))
        dt.Columns.Add(New DataColumn("Aux_Valor13", GetType(String)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr1", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr2", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr3", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr4", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr5", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr1Ingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr2Ingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr3Ingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr4Ingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr5Ingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr1Bimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr2Bimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr3Bimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr4Bimoneda", GetType(Double)))
        dt.Columns.Add(New DataColumn("ValPorcentajeDr5Bimoneda", GetType(Double)))

        ods.Tables.Add(dt.Copy)


        dt = New DataTable("documentop")

        dt.Columns.Add(New DataColumn("codigopago", GetType(String)))
        dt.Columns.Add(New DataColumn("diascredito", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        ods.Tables.Add(dt.Copy)

        dt = New DataTable("documentov")
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("factor", GetType(Double)))

        ods.Tables.Add(dt.Copy)

        If Consignaciones Or Reestructura Then
            Dim Otrans As New Transaccional.Conexion("FlexLine")
            Dim lsSQL As String
            Try
                Otrans.open()
                ''documento
                lsSQL = "pa_var_um_documento_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"

                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "encabezado"
                If ods.Tables.Contains("encabezado") Then ods.Tables.Remove("encabezado")
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)

                ''documentod
                lsSQL = "pa_var_um_documentod_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"

                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "detalle"
                If ods.Tables.Contains("detalle") Then ods.Tables.Remove("detalle")
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)

                ''documentod
                lsSQL = "pa_var_um_documentov_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"

                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "documentov"
                If ods.Tables.Contains("documentov") Then ods.Tables.Remove("documentov")
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)

                ''Clientes
                lsSQL = "pa_var_um_ctacte_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"
                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "ctacte"
                If ods.Tables.Contains("ctacte") Then
                    ods.Tables.Remove("ctacte")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)


                ''Direcciones de Clientes
                lsSQL = "pa_var_um_ctacteDirecciones_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"
                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "ctacte_direcciones"
                If ods.Tables.Contains("ctacte_direcciones") Then
                    ods.Tables.Remove("ctacte_direcciones")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)

                ''Direcciones de Para Contabilidad
                lsSQL = "pa_var_um_ctacteGenTabCod_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"
                dt = Otrans.Obtiene(lsSQL)
                dt.TableName = "ctacte_gentabcod"
                If ods.Tables.Contains("ctacte_gentabcod") Then
                    ods.Tables.Remove("ctacte_gentabcod")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)



            Catch ex As Exception
            Finally
                Otrans.close()
                Otrans = Nothing

            End Try
        End If

        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim lsSQL As String
        'Try
        '    otrans.open()
        '    ''documentod
        '    lsSQL = "pa_var_um_documentod_traslado_fecha 'DMARTE1',null,'01/01/2050','01/01/2050'"

        '    dt = otrans.Obtiene(lsSQL)
        '    dt.TableName = "detalle"
        '    If ods.Tables.Contains("detalle") Then ods.Tables.Remove("detalle")

        '    dt.Rows.Clear()
        '    ods.Tables.Add(dt.Copy)


        '    'lsSQL = "pa_var_um_documento_traslado_fecha 'DMARTE1',NULL,'01/01/2050','01/01/2050'"
        '    'dt = otrans.Obtiene(lsSQL)

        '    'dt.TableName = "encabezado"
        '    'If ods.Tables.Contains("encabezado") Then ods.Tables.Remove("encabezado")

        '    'dt.Rows.Clear()
        '    'ods.Tables.Add(dt.Copy)

        'Catch ex As Exception
        'Finally
        '    otrans.close()
        '    otrans = Nothing
        'End Try


    End Sub

    Private Sub Cargar_Maestros()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")


        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & ods.Tables("encabezado").Rows(0).Item("empresa").ToString & _
                        "','CLIENTE','" & IIf(ods.Tables("encabezado").Rows(0).Item("codigo") Is System.DBNull.Value, ods.Tables("encabezado").Rows(0).Item("Cliente").ToString, ods.Tables("encabezado").Rows(0).Item("codigo").ToString) & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "Cliente"

            If ods.Tables.Contains("Cliente") Then
                ods.Tables.Remove("Cliente")
            End If
            ods.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    '
    'Guardar el Pedido, Debe Devolver el Numero de Pedido Generado
    '

    Public Function Guardar_PedidoBasico() As Int64
        Dim npedido As Int64 = 0
        Dim li_sresultado As Integer
        Dim dt As DataTable
        Dim dr, drp, drv, drd As DataRow
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim ls_aux, ls_tienda As String
        Dim huboerror As Boolean = False



        Cargar_Maestros()

        Try

            dr = ods.Tables("encabezado").Rows(0)
            drp = ods.Tables("documentop").Rows(0)
            drv = ods.Tables("documentov").Rows(0)

            ls_tienda = ods.Tables("Cliente").Rows(0).Item("Analisisctacte6").ToString
            ''Establecer Ubicacion del Pedido
            ''Validacion de Clientes

            If (dr.Item("tipodocto") = "PEDIDO AL CONTADO" _
                And ls_tienda.Length > 0) Or _
                    (ls_tienda.Length > 0 _
                    And dr.Item("aprobacion").ToString = "S") Then
                'Or _
                '                    (dr.Item("empresa").ToString.ToUpper = "DIVINOS" Or _
                '                    dr.Item("empresa").ToString.ToUpper = "ALAMSAES") Then



                oTrans = New Transaccional.Conexion("FlexLine" & ls_tienda)
                oTrans.open()

                ''Agregar Gen_Locales en las diferentes tiendas
                ls_sql = "flexline.pa_sel_um_gen_tabcod '" & ls_tienda & "','GEN_LOCALES'"
                dt = oTrans.Obtiene(ls_sql)

                ''Le Agrego el resto del nombre al pedido
                dr.Item("tipodocto") += " " & dt.Rows(0).Item("TEXTO1").ToString
                dr.Item("tipodocto") = Trim(dr.Item("tipodocto").ToString)
            Else
                oTrans.open()
            End If


            ''Si el Pedido No trae Numero Se Genera Automaticamente
            If dr.Item("numero").ToString.Length = 0 Then


                ls_aux = "0" & Trim(Format(Now, "yy") + Format(Now, "MM"))
                ls_sql = "flexline.pa_sel_var_numero_pedido '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" &
                         ls_aux & "'"

                dt = oTrans.Obtiene(ls_sql)

                Try
                    dr.Item("numero") = _
                        ls_aux & (System.Int32.Parse(dt.Rows(0)("numero").ToString.Substring(5, 5)) + 1).ToString.PadLeft(5, "0")
                Catch ex As Exception
                    serror += serror & ex.Message & ","
                    'ls_dnumero = " "
                    'MessageBox.Show(oTrans.descripcion_error)
                    'oTrans.close()
                End Try

            End If


            ''Si lleva numero continua
            If dr.Item("numero").ToString.Length = 10 Then

                Try
                    ''Valido nuevamente que no exista ningun documento con ese numero y ese tipo
                    ls_sql = "flexline.pa_sel_um_documento '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero").ToString & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    dr.Item("correlativo") = dt.Rows(0).Item("correlativo")
                    'huboerror = True
                Catch
                    dr.Item("correlativo") = -1
                End Try

                ''Continua solo si comprobo que no existe un correlativo Previo
                If dr.Item("correlativo") = -1 Then
                    Try
                        ls_sql = "flexline.pa_ins_um_documento '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "','" & dr.Item("fecha") &
                                            "','" & dr.Item("codigo") & "','" & dr.Item("vendedor") & "'," & CStr(dr.Item("diascredito").ToString) &
                                        ",'" & dr.Item("listaprecio") & "'," & CStr(dr.Item("total")) & "," & CStr(dr.Item("factor")) & ",'" & dr.Item("aprobacion") &
                                        "'," & CInt(dr.Item("periodo")) & "," &
                                        IIf(dr.Item("direccion") Is System.DBNull.Value, "NULL", "'" & dr.Item("direccion").ToString & "'") & "," &
                                        IIf(dr.Item("ciudad") Is System.DBNull.Value, "NULL", "'" & dr.Item("ciudad").ToString & "'") & "," &
                                        IIf(dr.Item("comuna") Is System.DBNull.Value, "NULL", "'" & dr.Item("comuna").ToString & "'") & "," &
                                        IIf(dr.Item("pais") Is System.DBNull.Value, "NULL", "'" & dr.Item("pais").ToString & "'") & "," &
                                        IIf(dr.Item("contacto") Is System.DBNull.Value, "NULL", "'" & dr.Item("contacto").ToString & "'") & "," &
                                        "'" & dr.Item("comentario1") & "','" &
                                        dr.Item("usuario") & "','" & dr.Item("AnalisisE3").ToString & "','" &
                                        dr.Item("moneda") & "'," &
                                        IIf(dr.Item("ReferenciaExterna") Is System.DBNull.Value, "NULL", "'" & dr.Item("ReferenciaExterna").ToString & "'") & "," &
                                        IIf(dr.Item("ANALISISE10") Is System.DBNull.Value, "NULL", "'" & dr.Item("ANALISISE10").ToString & "'") & "," &
                                        IIf(dr.Item("AnalisisE21") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE21").ToString & "'") & "," &
                                        IIf(dr.Item("bodega") Is System.DBNull.Value, "NULL", "'" & dr.Item("bodega").ToString & "'") & "," &
                        IIf(dr.Item("AnalisisE22") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE22").ToString & "'") & "," &
                                            IIf(dr.Item("AnalisisE23") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE23").ToString & "'") & "," &
                                            IIf(dr.Item("AnalisisE24") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE24").ToString & "'")



                        ''ingresamos encabezado
                        li_sresultado = oTrans.Ingresa(ls_sql)
                        '         li_procesos = li_procesos + 1

                        If li_sresultado > 0 Then
                            ls_sql = "flexline.pa_sel_um_documento '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'"
                            dt = oTrans.Obtiene(ls_sql)

                            '(c) 20230829 Debo validar que sea del mismo cliente
                            If dt.Rows.Count > 0 Then
                                If dt.Rows(0).Item("cliente").ToString.Equals(dr.Item("codigo").ToString) Then
                                    dr.Item("correlativo") = dt.Rows(0).Item("correlativo").ToString

                                    ''ingreso documentop
                                    ls_sql = "flexline.pa_ins_um_documentop '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "'," & CStr(dr.Item("correlativo").ToString) &
                                                    ",'" & drp.Item("codigopago") & "'," & drp.Item("diascredito").ToString & ",'" & drp.Item("total").ToString &
                                                    "','" & dr.Item("numero") & "','" & drp.Item("cuenta") & "','" & drp.Item("fecha").ToString & "'"

                                    li_sresultado = oTrans.Ingresa(ls_sql)
                                    If oTrans.Codigo_error > 0 Then
                                        huboerror = True
                                    End If

                                    ''Ingreso DocumentoV
                                    ls_sql = "flexline.pa_ins_um_documentov '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "'," & CStr(dr.Item("correlativo").ToString) &
                                                    "," & CStr(drv("total").ToString) & "," & CStr(drv.Item("factor").ToString)

                                    oTrans.Ingresa(ls_sql)
                                    If oTrans.Codigo_error > 0 Then
                                        huboerror = True
                                    End If

                                    'ingreso documentoD
                                    For Each drd In ods.Tables("detalle").Rows

                                        If drd.Item("costo") = 0 Then
                                            ls_sql = "flexline.pa_sel_um_producto '" & dr.Item("empresa") & "','" & drd.Item("producto") & "'"
                                            dt = oTrans.Obtiene(ls_sql)

                                            Try
                                                drd.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                                            Catch ex As Exception
                                                drd.Item("costo") = 0
                                            End Try

                                        End If

                                        ls_sql = "flexline.pa_sel_um_listaprecioD '" & dr.Item("empresa") & "','" & drd.Item("producto") & "','" & dr.Item("listaprecio") & "'"

                                        dt = oTrans.Obtiene(ls_sql)
                                        Try
                                            drd.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                                            drd.Item("precioLP") = dt.Rows(0).Item("valor")
                                        Catch ex As Exception
                                            drd.Item("precioLP") = 0
                                        End Try
                                        ls_sql = "flexline.pa_ins_um_documentod '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "'," & CStr(dr.Item("correlativo").ToString) &
                                                       "," & drd.Item("secuencia") & ",'" & drd.Item("producto") & "'," & drd.Item("cantidad") & "," & drd.Item("precio") &
                                                       "," & drd.Item("total") & "," & drd.Item("diascredito") & "," & drd.Item("factor") & ",'" & drd.Item("fecha").ToString &
                                                       "'," & drd.Item("precioLP") & "," & drd.Item("costo") & "," & drd.Item("linea") & ",'" &
                                                       drd.Item("FechaVigenciaLp").ToString & "',NULL,NULL,NULL," &
                                                       IIf(drd.Item("aux_valor3") Is System.DBNull.Value, "NULL", "'" & drd.Item("aux_valor3").ToString & "'") & "," &
                                                       IIf(drd.Item("aux_valor8") Is System.DBNull.Value, "NULL", "'" & drd.Item("aux_valor8").ToString & "'") & "," &
                                                       IIf(drd.Item("aux_valor9") Is System.DBNull.Value, "NULL", "'" & drd.Item("aux_valor9").ToString & "'") & "," &
                                                       IIf(drd.Item("aux_valor10") Is System.DBNull.Value, "NULL", "'" & drd.Item("aux_valor10").ToString & "'") & "," &
                                                       IIf(drd.Item("aux_valor6") Is System.DBNull.Value, "NULL", "'" & drd.Item("aux_valor6").ToString & "'") & "," &
                                                       IIf(drd.Item("comentario") Is System.DBNull.Value, "NULL", "'" & drd.Item("comentario").ToString & "'")

                                        li_sresultado = oTrans.Ingresa(ls_sql)
                                        If oTrans.Codigo_error > 0 Then
                                            li_sresultado = -99
                                            huboerror = True
                                            Exit For
                                        End If
                                    Next
                                Else
                                    huboerror = True
                                    oTrans.Escribir_Log("Se traslapo con otro pedido")
                                End If

                            End If

                        End If ''li_sresultado > 0


                    Catch ex As Exception
                        huboerror = True
                    Finally
                    End Try

                End If ''Correlativo Existente


                If Not huboerror Then

                    ls_sql = "flexline.pa_var_um_valida_documento_encabezado_detalle '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" &
                                    dr.Item("numero") & "'"

                    dt = oTrans.Obtiene(ls_sql)

                    If dt.Rows.Count = 0 Then
                        huboerror = True
                    Else
                        ''El Encabezado tiene diferencias con el detalle
                        If Val(dt.Rows(0).Item("diferencia")) > 10 Then
                            huboerror = True
                        End If
                    End If
                    npedido = dr.Item("correlativo")
                End If

            End If


        Catch ex As Exception
            npedido = 0
        Finally
            If huboerror Then
                npedido = 0
                ls_sql = "flexline.pa_del_um_documento_completo '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'," & dr.Item("correlativo")
                li_sresultado = oTrans.Elimina(ls_sql)

                '(c) Generar Aviso








            Else
                ''(c) 02062015 Si No hubo error y es pedido centralizado de walmart
                '' Debe generar el pedido walmart
                ''Se debe parametrizar los codigos centralizados
                'If dr.Item("empresa").ToString = "CODICASA" And 
                ''(c) 09062015 Se Agrego DM
                If dr.Item("tipodocto") = "PEDIDO AL CREDITO" Then
                    If dr.Item("codigo") = "49067556" Or dr.Item("codigo") = "49067552" Then
                        ls_sql = "flexline.pa_ins_um_pedido_automatico_walmart '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "', '" & dr.Item("numero") & "'"
                        oTrans.Ingresa(ls_sql)

                    End If
                End If


                '(c) 20250319 Los pedidos de facturan automatiamente






            End If

            oTrans.close()
            oTrans = Nothing

        End Try
        Return npedido
    End Function

    Public Function Guardar_Documento() As Int64
        Dim npedido As Int64 = 0
        Dim li_sresultado As Integer
        Dim dt As DataTable
        Dim dr, drp, drv, drd As DataRow
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim ls_aux, ls_tienda As String
        Dim huboerror As Boolean = False



        Cargar_Maestros()

        Try

            dr = ods.Tables("encabezado").Rows(0)
            Try
                drp = ods.Tables("documentop").Rows(0)
            Catch ex As Exception
            End Try

            Try
                drv = ods.Tables("documentov").Rows(0)
            Catch ex As Exception
            End Try


            Try


                ls_tienda = ods.Tables("Cliente").Rows(0).Item("Analisisctacte6").ToString
                ''Establecer Ubicacion del Pedido
                ''Validacion de Clientes

                If (dr.Item("tipodocto") = "PEDIDO AL CONTADO" _
                    And ls_tienda.Length > 0) Or _
                        (ls_tienda.Length > 0 _
                        And dr.Item("aprobacion").ToString = "S") Or _
                            (dr.Item("empresa").ToString = "DIVINOS" Or _
                            dr.Item("empresa").ToString = "ALAMSAES") Then


                    oTrans = New Transaccional.Conexion("FlexLine" & ls_tienda)
                    oTrans.open()

                    ''Agregar Gen_Locales en las diferentes tiendas
                    ls_sql = "pa_sel_um_gen_tabcod '" & ls_tienda & "','GEN_LOCALES'"
                    dt = oTrans.Obtiene(ls_sql)

                    ''Le Agrego el resto del nombre al pedido
                    dr.Item("tipodocto") += " " & dt.Rows(0).Item("TEXTO1").ToString
                    dr.Item("tipodocto") = Trim(dr.Item("tipodocto").ToString)
                Else
                    oTrans.open()
                End If
            Catch ex As Exception
                oTrans.open()
            End Try

            ''Si el Pedido No trae Numero Se Genera Automaticamente
            If dr.Item("numero").ToString.Length = 0 Then
                If dr.Item("tipodocto").ToString.ToLower.StartsWith("pedido") Or
                    dr.Item("tipodocto").ToString.ToLower.StartsWith("solicitud consigna") Then


                    ls_aux = "0" & Trim(Format(Now, "yy") + Format(Now, "MM"))
                    ls_sql = "pa_sel_var_numero_pedido '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" &
                             ls_aux & "'"

                    dt = oTrans.Obtiene(ls_sql)

                    Try
                        dr.Item("numero") =
                            ls_aux & (System.Int32.Parse(dt.Rows(0)("numero").ToString.Substring(5, 5)) + 1).ToString.PadLeft(5, "0")
                    Catch ex As Exception
                        serror += serror & ex.Message & ","
                        'ls_dnumero = " "
                        'MessageBox.Show(oTrans.descripcion_error)
                        'oTrans.close()
                    End Try
                ElseIf dr.Item("tipodocto").ToString.ToLower.StartsWith("devol") Or
                        dr.Item("tipodocto").ToString.ToLower.StartsWith("salida") Or
                        dr.Item("tipodocto").ToString.ToLower.StartsWith("entrada") Then

                    ls_sql = "pa_var_um_tipodocumento_correlativo '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    dr.Item("numero") = (dt.Rows(0).Item("correlativoactual") + 1).ToString.PadLeft(10, "0")
                Else
                    ls_sql = "pa_var_numero_documento '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    dr.Item("numero") = dt.Rows(0).Item("numero").ToString.PadLeft(10, "0")
                End If
            End If


            ''Si lleva numero continua
            If dr.Item("numero").ToString.Length = 10 Then

                Try
                    ''Valido nuevamente que no exista ningun documento con ese numero y ese tipo
                    ls_sql = "pa_sel_um_documento '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero").ToString & "'"
                    dt = oTrans.Obtiene(ls_sql)
                    dr.Item("correlativo") = dt.Rows(0).Item("correlativo")
                    'huboerror = True
                Catch
                    dr.Item("correlativo") = -1
                End Try

                ''Continua solo si comprobo que no existe un correlativo Previo
                If dr.Item("correlativo") = -1 Then
                    Try
                        dr.Item("correlativo") = 0

                        ls_sql = "pa_ins_um_documento_traslado_tmp '" & dr.Item("Empresa") & "','" & dr.Item("tipodocto") & "'," &
                                                               dr.Item("correlativo").ToString & ",'" & dr.Item("CtaCte").ToString & "','" &
                                                               dr.Item("numero").ToString & "','" & dr.Item("fecha").ToString & "','" & dr.Item("proveedor").ToString & "','" & dr.Item("cliente").ToString & "','" &
                                                               dr.Item("bodega").ToString & "','" & dr.Item("bodega2").ToString & "','" & dr.Item("local").ToString & "','" &
                                                               dr.Item("comprador").ToString & "','" & dr.Item("vendedor").ToString & "','" &
                                                               dr.Item("CentroCosto").ToString & "','" & dr.Item("fechaVcto").ToString & "','" &
                                                               dr.Item("listaPrecio").ToString & "','" & dr.Item("Analisis").ToString & "','" &
                                                               dr.Item("Zona").ToString & "','" &
                                                               dr.Item("tipocta").ToString & "','" &
                                                               dr.Item("moneda").ToString & "'," & dr.Item("paridad").ToString & "," &
                                                               IIf(dr.Item("RefTipoDocto") Is System.DBNull.Value, "NULL", "'" & dr.Item("RefTipoDocto").ToString & "'") &
                                                               "," & CStr(dr.Item("neto").ToString) &
                                                               "," & CStr(dr.Item("subtotal").ToString) & "," & CStr(dr.Item("total").ToString) & "," & CStr(dr.Item("NetoIngreso").ToString) & "," &
                                                               CStr(dr.Item("SubTotalIngreso").ToString) & "," & CStr(dr.Item("TotalIngreso").ToString) & ",'" & dr.Item("centraliza").ToString & "','" &
                                                               dr.Item("valoriza").ToString & "','" &
                                                               dr.Item("costeo").ToString & "','" &
                                                               dr.Item("aprobacion").ToString & "','" &
                                                               dr.Item("TipoComprobante").ToString & "'," & dr.Item("PeriodoLibro").ToString & "," &
                                                               dr.Item("FactorMonto").ToString & ", '" & dr.Item("TipoCtaCte").ToString & "','" &
                                                               dr.Item("IdCtaCte").ToString & "','" & dr.Item("Glosa").ToString & "','" & dr.Item("comentario1").ToString & "','" & dr.Item("comentario2").ToString & "'," &
                                                               IIf(dr.Item("Comentario3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario3").ToString & "'") & "," &
                                                               IIf(dr.Item("Comentario4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario4").ToString & "'") & ",'" &
                                                               dr.Item("vigencia").ToString & "','" & dr.Item("Emitido").ToString & "'," & dr.Item("PorcentajeAsignado").ToString & ",'" &
                                                               dr.Item("direccion").ToString & "','" & dr.Item("ciudad").ToString & "','" & dr.Item("comuna").ToString & "','" &
                                                               dr.Item("EstadoDir").ToString & "','" & dr.Item("pais").ToString & "','" &
                                                               dr.Item("contacto").ToString & "','" & dr.Item("FechaModif").ToString & "','" & dr.Item("FechaUModif").ToString & "','" & dr.Item("UsuarioModif").ToString & "'," &
                                                               IIf(dr.Item("ComisionTotal") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionTotal").ToString & "'") & "," &
                                                               IIf(dr.Item("ComisionLPrecio") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionLPrecio").ToString & "'") & ",'" &
                                                               dr.Item("Hora").ToString & "'," &
                                                               IIf(dr.Item("Caja") Is System.DBNull.Value, "NULL", "'" & dr.Item("Caja").ToString & "'") & "," &
                                                               IIf(dr.Item("Pago") Is System.DBNull.Value, "NULL", dr.Item("pago").ToString) & "," &
                                                               IIf(dr.Item("Donacion") Is System.DBNull.Value, "NULL", dr.Item("Donacion").ToString) & "," &
                                                               IIf(dr.Item("IdApertura") Is System.DBNull.Value, "NULL", dr.Item("IdApertura").ToString) & "," &
                                                               IIf(dr.Item("Multipagina") Is System.DBNull.Value, "NULL", "'" & dr.Item("Multipagina").ToString & "'") & "," &
                                                               CStr(dr.Item("NetoBimoneda").ToString) & "," & CStr(dr.Item("SubTotalBimoneda").ToString) & "," &
                                                               CStr(dr.Item("TotalBimoneda").ToString) & "," & CStr(dr.Item("ParidadBimoneda").ToString) & ",'" &
                                                               dr.Item("AnalisisE1").ToString & "','" & dr.Item("AnalisisE2").ToString & "','" &
                                                               dr.Item("AnalisisE3").ToString & "','" & dr.Item("UsuarioAprueba").ToString & "'," &
                                                                IIf(dr.Item("AnalisisE7") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE7").ToString & "'") & "," &
                                                                IIf(dr.Item("ReferenciaExterna") Is System.DBNull.Value, "NULL", "'" & dr.Item("ReferenciaExterna").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE8") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE8").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE9") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE9").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE10") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE10").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE11") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE11").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE12") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE12").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE13") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE13").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE14") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE14").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE15") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE15").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE16") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE16").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE17") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE17").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE18") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE18").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE19") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE19").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE20") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE20").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE21") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE21").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE22") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE22").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE23") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE23").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE24") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE24").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE25") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE25").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE26") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE26").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE27") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE27").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE28") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE28").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE29") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE29").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE30") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE30").ToString & "'") & "," &
                                                                IIf(dr.Item("AnalisisE6") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE6").ToString & "'")




                        ''ingresamos encabezado
                        li_sresultado = oTrans.Ingresa(ls_sql)
                        '         li_procesos = li_procesos + 1

                        If li_sresultado > 0 Then
                            ls_sql = "pa_sel_um_documento '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'"
                            dt = oTrans.Obtiene(ls_sql)

                            dr.Item("correlativo") = dt.Rows(0).Item("correlativo").ToString

                            Try

                                If ods.Tables("documentop").Rows.Count > 0 Then

                                    ''ingreso documentop
                                    ls_sql = "pa_ins_um_documentop '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "'," & CStr(dr.Item("correlativo").ToString) & _
                                                    ",'" & drp.Item("codigopago") & "'," & drp.Item("diascredito").ToString & ",'" & drp.Item("total").ToString & _
                                                    "','" & dr.Item("numero") & "','" & drp.Item("cuenta") & "','" & drp.Item("fecha").ToString & "'"

                                    li_sresultado = oTrans.Ingresa(ls_sql)
                                    If oTrans.Codigo_error > 0 Then
                                        huboerror = True
                                    End If
                                End If
                            Catch ex As Exception
                            End Try


                            Try

                                If ods.Tables("documentov").Rows.Count > 0 Then


                                    If ods.Tables("documentov").Rows.Count = 1 Then
                                        ''Ingreso DocumentoV
                                        ls_sql = "pa_ins_um_documentov '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "'," & CStr(dr.Item("correlativo").ToString) & _
                                                        "," & CStr(drv("total").ToString) & "," & CStr(drv.Item("factor").ToString)

                                        oTrans.Ingresa(ls_sql)
                                        If oTrans.Codigo_error > 0 Then
                                            huboerror = True
                                        End If
                                    Else
                                        '
                                        For Each dr2 As DataRow In ods.Tables("documentov").Rows
                                            ls_sql = "pa_ins_um_documentov_traslado '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipodocto") & "'," & _
                                                        CStr(dr.Item("correlativo").ToString) & ",'" & dr2.Item("Nombre").ToString & "'," & _
                                                        dr2.Item("Orden").ToString & "," & dr2.Item("Factor").ToString & "," & _
                                                        dr2.Item("Monto").ToString & "," & dr2.Item("MontoIngreso").ToString & "," & _
                                                        dr2.Item("Ajuste").ToString & "," & dr2.Item("AjusteIngreso").ToString & "," & _
                                                        IIf(dr2.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr2.Item("Texto").ToString & "'") & "," & _
                                                        dr2.Item("Porcentaje").ToString & "," & _
                                                        dr2.Item("MontoBimoneda").ToString & "," & _
                                                        IIf(dr2.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr2.Item("AjusteBimoneda").ToString)

                                            li_sresultado = oTrans.Ingresa(ls_sql)

                                            'descripcion_error = oTrans.descripcion_error
                                            If oTrans.Codigo_error > 0 Then
                                                huboerror = True
                                            End If
                                        Next

                                    End If
                                End If
                            Catch ex As Exception
                            End Try


                            For Each drd In ods.Tables("detalle").Rows
                                ls_sql = "pa_ins_um_documentod_traslado_tmp '" & drd.Item("Empresa").ToString & "','" & _
                                            drd.Item("tipodocto").ToString & "'," & _
                                            dr.Item("Correlativo").ToString 'solo esta linea tiene que ser dr por que es del encabezado

                                ls_sql += "," & drd.Item("Secuencia") & "," & drd.Item("Linea") & ",'" &
                                            drd.Item("Producto") & "'," & drd.Item("Cantidad") & "," & drd.Item("Precio") & "," &
                                            drd.Item("PorcentajeDr") & "," & drd.Item("SubTotal") & "," & drd.Item("Impuesto") & "," &
                                            drd.Item("Neto") & "," & drd.Item("DRGlobal") & "," &
                                            IIf(drd.Item("Costo") Is System.DBNull.Value, "0", drd.Item("Costo")) & "," &
                                            drd.Item("Total") & "," & drd.Item("PrecioAjustado") & ",'" & drd.Item("UnidadIngreso") & "'," &
                                            drd.Item("CantidadIngreso") & "," & drd.Item("PrecioIngreso") & "," & drd.Item("SubTotalIngreso") & "," &
                                            drd.Item("ImpuestoIngreso") & "," & drd.Item("NetoIngreso") & "," & drd.Item("DRGlobalIngreso") & "," &
                                            drd.Item("TotalIngreso") & ",'" & drd.Item("TipoDoctoOrigen") & "'," &
                                            drd.Item("CorrelativoOrigen") & "," & drd.Item("SecuenciaOrigen") & ",'" &
                                            drd.Item("Bodega") & "'," & drd.Item("FactorInventario") & ",'" &
                                            drd.Item("FechaEntrega") & "'," & drd.Item("CantidadAsignada") & ",'" &
                                            drd.Item("Fecha") & "','" & drd.Item("comentario").ToString & "','" &
                                            drd.Item("Vigente") & "'," &
                                            IIf(drd.Item("CUP") Is System.DBNull.Value, "NULL", drd.Item("CUP")) & ",'" &
                                            drd.Item("Ubicacion") & "','" & drd.Item("Ubicacion2") & "','" & drd.Item("cuenta").ToString & "'," &
                                            IIf(drd.Item("Impdist") Is System.DBNull.Value, "NULL", drd.Item("Impdist").ToString) & "," &
                                            IIf(drd.Item("FactorImpto") Is System.DBNull.Value, "NULL", drd.Item("FactorImpto")) & "," &
                                            drd.Item("PrecioBimoneda") & "," &
                                            drd.Item("SubTotalBimoneda") & "," & drd.Item("ImpuestoBimoneda") & "," &
                                            drd.Item("NetoBimoneda") & "," & drd.Item("DrGlobalBimoneda") & "," &
                                            drd.Item("TotalBimoneda") & "," & drd.Item("PrecioListaP") & "," &
                                            IIf(drd.Item("UniMedDynamic") Is System.DBNull.Value, "NULL", drd.Item("UniMedDynamic").ToString) & ",'" &
                                            drd.Item("FechaVigenciaLp") & "','" &
                                            drd.Item("LoteDestino").ToString & "','" & drd.Item("SerieDestino").ToString & "','" &
                                            drd.Item("ProdAlias").ToString & "','" & drd.Item("DoctoOrigenVal") & "'," &
                                            IIf(drd.Item("MontoAsignado") Is System.DBNull.Value, "NULL", drd.Item("MontoAsignado").ToString & "," &
                                            IIf(drd.Item("Aux_Valor1") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor1").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor2") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor2").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor3") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor3").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor4") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor4").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor5") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor5").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor6") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor6").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor7") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor7").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor8") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor8").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor9") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor9").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor10") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor10").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor11") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor11").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor12") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor12").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor13") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor13").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor14") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor14").ToString & "'") & "," &
                                                                            IIf(drd.Item("Aux_Valor15") Is System.DBNull.Value, "NULL", "'" & drd.Item("Aux_Valor15").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr1") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr1").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr2") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr2").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr3") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr3").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr4") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr4").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr5") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr5").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr1Ingreso") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr1Ingreso").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr2Ingreso") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr2Ingreso").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr3Ingreso") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr3Ingreso").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr4Ingreso") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr4Ingreso").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr5Ingreso") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr5Ingreso").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr1Bimoneda") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr1Bimoneda").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr2Bimoneda") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr2Bimoneda").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr3Bimoneda") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr3Bimoneda").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr4Bimoneda") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr4Bimoneda").ToString & "'") & "," &
                                                                            IIf(drd.Item("ValPorcentajeDr5Bimoneda") Is System.DBNull.Value, "NULL", "'" & drd.Item("ValPorcentajeDr5Bimoneda").ToString & "'") & "," &
                                        IIf(drd.Item("Lote") Is System.DBNull.Value, "''", "'" & drd.Item("Lote").ToString & "'") & "," &
                                        IIf(drd.Item("fechavcto") Is System.DBNull.Value, "NULL", "'" & drd.Item("fechavcto").ToString & "'") & "," &
                                        IIf(drd.Item("Serie") Is System.DBNull.Value, "NULL", "'" & drd.Item("Serie").ToString & "'"))



                                li_sresultado = oTrans.Ingresa(ls_sql)
                                'codigo_error = oTrans.Codigo_error
                                'descripcion_error = oTrans.descripcion_error
                                If oTrans.Codigo_error > 0 Then
                                    'HayErrores = True
                                End If
                            Next

                        End If


                    Catch ex As Exception
                        huboerror = True
                    Finally
                    End Try
                Else
                    dr.Item("correlativo") = 0

                End If ''Correlativo Existente


                If Not huboerror Then

                    If Validar_Totales Then  'lo mando como parametro por que existen casos q no deseo validar
                        'ejemplo Solicitud de consignaciones

                        ls_sql = "pa_var_um_valida_documento_encabezado_detalle '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & _
                                        dr.Item("numero") & "'"

                        dt = oTrans.Obtiene(ls_sql)

                        If dt.Rows.Count = 0 Then
                            huboerror = True
                        Else
                            ''El Encabezado tiene diferencias con el detalle
                            'Debo Generar un Margen para diferencia
                            If dt.Rows(0).Item("diferencia") <> 0 Then
                                If Math.Abs(Double.Parse(dt.Rows(0).Item("diferencia").ToString)) > 1 Then
                                    huboerror = True
                                End If

                            End If
                        End If
                    End If
                    npedido = dr.Item("correlativo")

                End If

            End If


        Catch ex As Exception
            npedido = 0
        Finally
            If huboerror Then
                npedido = 0
                ls_sql = "pa_del_um_documento_completo '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'," & dr.Item("correlativo")
                li_sresultado = oTrans.Elimina(ls_sql)
            End If

            oTrans.close()
            oTrans = Nothing

        End Try
        Return npedido
    End Function

    Public Sub imprimirDevolucion(ByVal psEmpresa As String, ByVal psNumero As String, ByVal psTipoDocto As String, _
                                  ByVal piNumeroCopias As Integer, ByVal psImpresora As String)
        Dim clsGen As New ClasesGenerales.General

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String


        pm_conexion = clsGen.Parametros_Conexion("")
        Dim ppath_reporte As String = clsGen.Path_Reporte

        ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Devoluciones de Mercaderia.rpt"
        'ppath_reporte += ".rpt"
        pm_parametros(0) = "Empresa"
        pm_parametros(1) = "Numero"
        pm_parametros(2) = "tipodocto"
        pm_valores(0) = psEmpresa 'drEncabezado.Item("empresa").ToString
        pm_valores(1) = psNumero 'Oflex.ods.Tables("encabezado").Rows(0).Item("numero") 'ls_pedido_generado
        pm_valores(2) = psTipoDocto


        'Guardo las copias en pdf
        If psImpresora.Trim.Length = 0 Then psImpresora = "\\192.192.1.33\Bodega,USB001"

        _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            False, True, "PDF", False, "", True, piNumeroCopias, psEmpresa, psImpresora)

    End Sub

    Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
          ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
          ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean, _
          ByVal _nombre_archivo As String, ByVal mostrarError As Boolean, ByVal nCopias As Integer, ByVal psEmpresa As String, _
          ByVal psImpresora As String) As Boolean
        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt(psEmpresa)
        If _nombre_archivo.Length > 0 Then
            Oaut.Archivo_Generado = _nombre_archivo
        End If
        Oaut.pnNumeroCopias = nCopias

        If psImpresora.Length > 0 Then
            Oaut.psImpresora = psImpresora.Split(",")(0)
            Oaut.psPort = psImpresora.Split(",")(1)
        End If

        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)

        If Oaut.Descripcion_Error.Length > 0 Then
            If mostrarError Then
                Dim clsGen As New ClasesGenerales.General
                'guardarAviso("Problemas al Imprimir " & pm_valores(1) & " " & pm_valores(2) & " " & Oaut.Descripcion_Error)
                clsGen.Escribir_Log(Oaut.Descripcion_Error)
                clsGen = Nothing
            End If
            valorRegreso = False
        End If

        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()
        Return valorRegreso
    End Function

End Class
#End Region

#Region "Guardar Memos Promocionales"

Public Class Memos_Promocionales
    Dim Ods As DataSet
    Dim ClsGen As ClasesGenerales.General
    Public Sub New()
        Ods = New DataSet
        ClsGen = New ClasesGenerales.General

    End Sub

    Public Sub Dispose()
        ClsGen = Nothing
    End Sub



    Private Sub enviarcorreo33(pdtPedidos As DataTable, psCuentaCorreo As String, psUsuarioActual As String, psSubject As String, psBody As String)




        Dim sta_mer As String
        Dim nrow As Integer
        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim ls_sql As String
        Dim sBody As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Message = New System.Net.Mail.MailMessage()
            'Dim adjuntar As New Net.Mail.Attachment(ruta)
            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
            SMTP1.EnableSsl = True





            Dim iCount As Integer = 0

            sBody = "<tr></tr><tr>"
            sBody = sBody & "Buen Dia "

            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & psUsuarioActual & "'")

            Try
                sBody = sBody & StrConv(dt.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
            Catch ex As Exception
            End Try

            sBody = sBody & "</tr>"
            sBody = sBody & "<table><font size=2>"
            For Each dr As DataRow In pdtPedidos.Rows
                Try


                    iCount += 1
                    sBody = sBody & "<tr>"
                    'sBody = sBody & "<td>Buen Dia </td>"
                    'sBody = sBody & "</tr>"

                    'sBody = sBody & "<td>Empresa</td>"


                    Try
                        sBody = sBody & "<td>" & dr.Item(1) & " - " & dr.Item(2) & "</td>"
                    Catch ex As Exception
                    End Try

                    Try
                        sBody = sBody & "<td>" & dr.Item(3) & "</td>"
                    Catch ex As Exception
                    End Try

                    Try
                        sBody = sBody & "<td>" & dr.Item(4) & "</td>"
                        sBody = sBody & "<td>" & dr.Item(5) & "</td>"
                    Catch ex As Exception

                    End Try

                    sBody = sBody & "</tr>"


                Catch ex As Exception


                Finally
                End Try
            Next
            sBody = sBody & "</table>"

            'l_srv_salida.Credentials = New System.Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv");

            dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            ''SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            'SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

            Message.[To].Add(psCuentaCorreo)
            'Message.[To].Add("coscal@umbral.com.gt")
            Message.From = New System.Net.Mail.MailAddress("notificacion@umbralcorp.com", "Notificaciones Umbral", System.Text.Encoding.UTF8) 'Quien envía el e-mail
            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = sBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True
            'Message.Attachments.Add(adjuntar)

            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try

    End Sub



    Public Function Guardar_Memo_Flex(ByVal _pdr As DataRow) As Boolean
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim OtransCorp As New Transaccional.Conexion("Corporativo")


        Dim dt As DataTable
        Dim dr, dr2 As DataRow

        Dim ls_sql, ls_listaprecios As String
        Dim ls_sql_detalle, sNumeroFlex As String
        Dim idoferta As Integer
        Dim numero As Integer

        Dim proceso_exitoso As Boolean = True
        Dim conexiones As Boolean = True


        Try
            ls_listaprecios = String.Empty
            Otrans.open()
            OtransCorp.open()




            ''Verificar las Conexiones a las diferentes ubicaciones

            conexiones = ClsGen.Verificar_Conexiones(_pdr.Item("ubicaciones").ToString)

            ''Validaciones se debe validar una vez mas antes de procesarlo en el sistema


            If conexiones Then
                Try



                    '' (c) 20160222
                    ls_sql = "pa_upd_um_mmp_encabezado_opero_flex " & _pdr.Item("cod_memo").ToString & ",'Admin'"
                    OtransCorp.Actualiza(ls_sql)
                    '' (c) 20160222

                    ls_sql = "pa_sel_um_mmp_detalle_producto " & _pdr.Item("cod_memo").ToString
                    dt = OtransCorp.Obtiene(ls_sql)
                    dt.TableName = "mmp_detalle_productos"

                    If Ods.Tables.Contains("mmp_detalle_productos") Then
                        Ods.Tables.Remove("mmp_detalle_productos")
                    End If
                    Ods.Tables.Add(dt.Copy)

                    ls_sql = "pa_sel_um_mmp_detalle_clientes " & _pdr.Item("cod_memo").ToString
                    dt = OtransCorp.Obtiene(ls_sql)
                    dt.TableName = "mmp_detalle_clientes"

                    If Ods.Tables.Contains("mmp_detalle_clientes") Then
                        Ods.Tables.Remove("mmp_detalle_clientes")
                    End If
                    Ods.Tables.Add(dt.Copy)

                    Ods.Tables("mmp_detalle_clientes").Columns.Add(New DataColumn("listaprecio", GetType(String)))


                    For Each dr2 In Ods.Tables("mmp_detalle_clientes").Rows
                        ls_sql_detalle = "pa_sel_um_ctacte '" & _pdr.Item("empresa").ToString & "','CLIENTE','" & dr2.Item("cod_cliente") & "',NULL"
                        dt = Otrans.Obtiene(ls_sql_detalle)
                        Try
                            dr2.Item("listaprecio") = dt.Rows(0).Item("ListaPrecio")
                        Catch ex As Exception
                            ClsGen.Escribir_Log("Error Lista de Precios " & ls_sql_detalle)
                            ClsGen.Escribir_Log("Error Lista de Precios " & ex.ToString)
                            ClsGen.Escribir_Log("Error Lista de Precios " & ex.Message)

                            Exit Try
                        End Try


                    Next


                    ''Debo Establecer que no Exista Otro Memo

                    If Validar_Memo(Ods, _pdr) Then

                        ''Debo Obtener Correlativo Nuevo


                        sNumeroFlex = "00"
                        ls_sql = "pa_sel_um_productooferta_numero '" & _pdr.Item("empresa").ToString & "'"
                        dt = Otrans.Obtiene(ls_sql)
                        If dt.Rows.Count = 1 Then
                            numero = dt.Rows(0).Item("Numero_maximo").ToString
                            numero += 1
                            sNumeroFlex += dt.Rows(0).Item("anio").ToString.Trim
                            sNumeroFlex += numero.ToString.PadLeft(4, "0")
                        Else
                            ClsGen.Escribir_Log("No se Pudo Obtener el Correlativo")
                            Exit Try
                        End If

                        If _pdr.Item("empresa").ToString = "CODICASA" Then
                            sNumeroFlex += "  "
                            sNumeroFlex += _pdr.Item("porcentaje_empresa").ToString.PadLeft(3, "0")
                            sNumeroFlex += "  "
                            sNumeroFlex += _pdr.Item("porcentaje_proveedor").ToString.PadLeft(3, "0")
                        End If

                        For Each dr In Ods.Tables("mmp_detalle_productos").Rows

                            ls_sql = "pa_sel_um_producto '" & _pdr.Item("empresa").ToString & "','" & dr.Item("cod_flex").ToString & "'"
                            dt = Otrans.Obtiene(ls_sql)


                            ''Aprueba solo los vigentes
                            If dt.Rows(0).Item("VIGENTE").ToString.ToUpper = "S" Then


                                ls_sql = "pa_var_um_productoOferta_id '" & _pdr.Item("empresa").ToString & "','" &
                                                                        dr.Item("cod_flex").ToString & "'"

                                dt = Otrans.Obtiene(ls_sql)
                                idoferta = dt.Rows(0).Item("newIdOferta")
                                ls_sql = "pa_ins_um_productooferta '" & _pdr.Item("empresa").ToString & "','" &
                                                              dr.Item("cod_flex").ToString & "',''," & dr.Item("precio").ToString & ",'" &
                                                              Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" &
                                                              Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "',"

                                If _pdr.Item("aplica_todos").ToString Then
                                    ls_sql += "'S','"
                                    ls_listaprecios = _pdr.Item("lista_precios").ToString
                                Else
                                    ls_sql += "'N','"
                                    For Each dr2 In Ods.Tables("mmp_detalle_clientes").Rows

                                        ls_sql_detalle = ""
                                        ls_sql_detalle = "pa_ins_um_productoOferta '" & _pdr.Item("empresa").ToString & "','" &
                                                            dr.Item("cod_flex").ToString & "','" & dr2.Item("cod_cliente").ToString & "'," & dr.Item("precio").ToString & ",'" &
                                                            Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" &
                                                            Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "','N','" &
                                                            sNumeroFlex & "','" &
                                                            Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToString("HH:mm:ss") & "','" &
                                                            Date.Parse(_pdr.Item("vigencia_final").ToString).ToString("HH:mm:ss") & "',0.00,0.00,'" &
                                                            dr2.Item("listaprecio").ToString & "'," & idoferta.ToString
                                        Otrans.Ingresa(ls_sql_detalle)

                                        If Otrans.Codigo_error > 0 Then
                                            ClsGen.Escribir_Log(Otrans.descripcion_error)
                                            proceso_exitoso = False
                                        End If


                                        ls_listaprecios = dr2.Item("listaprecio").ToString
                                    Next  ''Detalle de Clientes
                                End If  ''Aplica a todos

                                ls_sql += sNumeroFlex & "','" &
                                            Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToString("HH:mm:ss") & "','" &
                                            Date.Parse(_pdr.Item("vigencia_final").ToString).ToString("HH:mm:ss") & "',0.00,0.00,'" &
                                            ls_listaprecios & "'," & idoferta.ToString
                                Otrans.Ingresa(ls_sql)
                                If Otrans.Codigo_error > 0 Then
                                    ClsGen.Escribir_Log(Otrans.descripcion_error)
                                    proceso_exitoso = False
                                End If

                                ''Guardo nueva tabla debe guardar una linea por producto para mantener la vigencia
                                ls_sql = "pa_ins_um_productooferta_memo '" & _pdr.Item("empresa").ToString & "','" & sNumeroFlex & "'," &
                                            dr.Item("objetivo_venta").ToString & "," &
                                            IIf(_pdr.Item("ataque_contrabando").ToString = True, 1, 0) & ",' " &
                                            _pdr.Item("ubicaciones").ToString.Trim & "'," &
                                            _pdr.Item("porcentaje_proveedor").ToString & "," & _pdr.Item("porcentaje_empresa").ToString & "," &
                                             _pdr.Item("numero").ToString & ",'" & dr.Item("cod_flex").ToString & "'"

                                Otrans.Ingresa(ls_sql)
                                If Otrans.Codigo_error > 0 Then
                                    ClsGen.Escribir_Log("Errr Insertando Memo " & Otrans.descripcion_error)
                                    proceso_exitoso = False
                                End If

                            End If ''Productos Vigentes
                        Next


                        ''Enviar Memo a Distintas ubicaciones

                        If proceso_exitoso Then

                            ls_sql = "pa_upd_um_mmp_encabezado_opero_flex " & _pdr.Item("cod_memo").ToString & ",'Admin'"
                            OtransCorp.Actualiza(ls_sql)

                            If _pdr.Item("ubicaciones").ToString.Trim.Length > 0 Then

                                If Not Traslado_Memos(_pdr, sNumeroFlex) Then
                                    ls_sql = "pa_upd_um_mmp_encabezado_estado (" & _pdr.Item("cod_memo").ToString & ",6"
                                    OtransCorp.Actualiza(ls_sql)
                                    proceso_exitoso = False
                                    'Debo Eliminar El Memo
                                Else
                                    proceso_exitoso = True
                                End If


                            End If

                            If proceso_exitoso Then
                                ls_sql = "pa_upd_um_mmp_encabezado_estado " & _pdr.Item("cod_memo").ToString & ",20"
                                OtransCorp.Actualiza(ls_sql)

                                Dim sCorreo, lsSQL As String
                                Dim dt3 As DataTable

                                Try
                                    Dim varMotivo As String = " Memo Promocional Operado"

                                    Dim varMensajeAEnviar As String = "Empresa: " & _pdr.Item("Empresa").ToString & "|" &
                                        "Numero : " & sNumeroFlex & "|" &
                                        "Vigencia: " & _pdr.Item("vigencia_inicio") & " Al " & _pdr.Item("vigencia_final") & "|" &
                                        "Actividad : " & _pdr.Item("actividad").ToString & "|"

                                    '"Fecha Proceso:" & dt.Rows(0).Item("Fecha_Actual")

                                    sCorreo = ClsGen.Obtener_XMLConfig("correo_facturacion_GT", False).ToString
                                    If sCorreo.Length > 0 Then
                                        ClsGen.enviarMensajeTeams(sCorreo, varMotivo, varMensajeAEnviar)
                                    End If

                                    lsSQL = "pa_sel_um_sg_usuario_email '" & _pdr.Item("usuario_solicito").ToString & "'"
                                    dt3 = ClsGen.selectQuery("FlexLine", lsSQL)
                                    sCorreo = dt3.Rows(0).Item("correo").ToString

                                    If sCorreo.Length > 0 Then
                                        ClsGen.enviarMensajeTeams(sCorreo, varMotivo, varMensajeAEnviar)
                                    End If

                                    lsSQL = "pa_sel_um_sg_usuario_email '" & _pdr.Item("usuario_aprobo").ToString & "'"
                                    dt3 = ClsGen.selectQuery("FlexLine", lsSQL)
                                    sCorreo = dt3.Rows(0).Item("correo").ToString

                                    If sCorreo.Length > 0 Then
                                        ClsGen.enviarMensajeTeams(sCorreo, varMotivo, varMensajeAEnviar)
                                    End If

                                Catch ex As Exception
                                End Try
                            End If

                            '(c) 20230831
                            'Debo enviar todo memo a la nube

                            Try
                                'Realiza_Traslado_Memos(_pdr, sNumeroFlex, "",
                                '                            "RegionalDBintOut")
                            Catch ex As Exception

                            End Try

                        Else ''Dio Error al momento de procesar
                            ls_sql = "pa_upd_um_mmp_encabezado_estado_rechazado " & _pdr.Item("cod_memo").ToString & ",6,'Reprocesando...'"
                            OtransCorp.Actualiza(ls_sql)

                        End If
                    Else 'validar_memo
                        ls_sql = "pa_upd_um_mmp_encabezado_estado_rechazado " & _pdr.Item("cod_memo").ToString & ",22,'Ya Existe Memo Con Estas Caracteristicas Rechazado Operado FlexLine'"
                        OtransCorp.Actualiza(ls_sql)

                        Dim varMotivo As String = " Memo Promocional RECHAZADO"
                        Dim lsSQL, scorreo As String
                        Dim dt3 As DataTable

                        Dim varMensajeAEnviar As String = "Empresa: " & _pdr.Item("Empresa").ToString & "|" &
                            "Numero Solicitud : " & _pdr.Item("cod_memo").ToString & "|" &
                            "Vigencia: " & _pdr.Item("vigencia_inicio") & " Al " & _pdr.Item("vigencia_final") & "|" &
                            "Actividad : " & _pdr.Item("actividad").ToString & "|" & "|" &
                            "Motivo Rechazo :  Ya Existe Memo Con Estas Caracteristicas Rechazado Operado FlexLine"


                        '"Fecha Proceso:" & dt.Rows(0).Item("Fecha_Actual")


                        lsSQL = "pa_sel_um_sg_usuario_email '" & _pdr.Item("usuario_solicito").ToString & "'"
                        dt3 = ClsGen.selectQuery("FlexLine", lsSQL)
                        scorreo = dt3.Rows(0).Item("correo").ToString

                        If scorreo.Length > 0 Then
                            ClsGen.enviarMensajeTeams(scorreo, varMotivo, varMensajeAEnviar)
                        End If

                        lsSQL = "pa_sel_um_sg_usuario_email '" & _pdr.Item("usuario_aprobo").ToString & "'"
                        dt3 = ClsGen.selectQuery("FlexLine", lsSQL)
                        scorreo = dt3.Rows(0).Item("correo").ToString

                        If scorreo.Length > 0 Then
                            ClsGen.enviarMensajeTeams(scorreo, varMotivo, varMensajeAEnviar)
                        End If


                    End If 'validar_memo


                Catch ex As Exception
                    ls_sql = "pa_upd_um_mmp_encabezado_estado_rechazado " & _pdr.Item("cod_memo").ToString & ",6,'Reprocesando... " & ex.ToString & "'"
                    OtransCorp.Actualiza(ls_sql)
                End Try
            End If ''Conexiones
        Catch ex As Exception
            ClsGen.Escribir_Log("Problemas Memo Flex " & ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            OtransCorp.close()
            OtransCorp = Nothing
        End Try

        Return proceso_exitoso
    End Function


    Private Function Validar_Memo(ByVal ods As DataSet, ByVal _pdr As DataRow) As Boolean
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim retorno As Boolean = True
        Dim clsGen As New ClasesGenerales.General

        Try
            Otrans.open()


            For Each dr_producto As DataRow In ods.Tables("mmp_detalle_productos").Rows
                For Each dr_cliente As DataRow In ods.Tables("mmp_detalle_clientes").Rows
                    ls_sql = "pa_sel_um_productooferta_fecha '" & _pdr.Item("empresa").ToString & "','" & dr_cliente.Item("cod_cliente").ToString & "','" & _
                            dr_producto.Item("codigo").ToString & "','" & Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" & _
                           Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        clsGen.Escribir_Log("Existen Memos Para Esta Lista")
                        retorno = False
                        Exit Try
                    End If
                Next
                ''debo verificar si es aplicable a toda la lista

                If _pdr.Item("aplica_todos").ToString Then
                    ls_sql = "pa_sel_um_productooferta_lista '" & _pdr.Item("empresa").ToString & "','" & dr_producto.Item("cod_flex").ToString & "','" & _
                            _pdr.Item("lista_precios").ToString & "','" & _
                            Date.Parse(_pdr.Item("vigencia_inicio").ToString).ToShortDateString & "','" & _
                            Date.Parse(_pdr.Item("vigencia_final").ToString).ToShortDateString & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        clsGen.Escribir_Log("Existen Memos Para esta Lista")
                        clsGen.Escribir_Log(ls_sql)
                        retorno = False
                        Exit Try
                    End If


                End If
            Next

        Catch ex As Exception
        Finally
            clsGen = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
        Return retorno

    End Function


    Private Function Traslado_Memos(ByVal _pdr As DataRow, ByVal _numero_memo_flex As String) As Boolean
        Dim exitoso As Boolean = True
        'Dim icount As Integer
        Dim ubicacion_actual As String

        Try
            For Each ubicacion_actual In _pdr.Item("ubicaciones").ToString.Split(",")
                Crear_Estructura_Traslado()
                exitoso = Prepara_Informacion_Traslado(_pdr, _numero_memo_flex)
                Exit For
            Next

            If exitoso Then
                For Each ubicacion_actual In _pdr.Item("ubicaciones").ToString.Split(",")
                    If ubicacion_actual.Trim.Length > 0 Then

                        If Not Realiza_Traslado_Memos(_pdr, _numero_memo_flex, _
                                                            ubicacion_actual) Then
                            exitoso = False
                        End If
                    End If
                Next
                'For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
                '    If Me.chk_ubicaciones.GetItemChecked(icount) Then
                '        If Not Realiza_Traslado_Memos(Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString, _
                '                                Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString) Then
                '            exitoso = False
                '        End If
                '    End If
                'Next

            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("Trasladar Memos " & ex.Message)

        End Try
        Return exitoso
    End Function

    Private Function Prepara_Informacion_Traslado(ByVal _pdr As DataRow, ByVal _numero_memo_flex As String) As Boolean
        Dim ls_sql As String

        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")

        Dim exitoso As Boolean = True

        Try
            Ods.Tables("traslado").Rows.Clear()
            otrans.open()
            ls_sql = "pa_var_um_productooferta '" & _pdr.Item("empresa").ToString & "',NULL,NULL,'" & _numero_memo_flex & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = Ods.Tables("traslado").NewRow

                dr_aux.Item("agregar") = True
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("precio") = dr.Item("precio")
                dr_aux.Item("porcentajemax") = dr.Item("porcentajemax")
                dr_aux.Item("listaprecio") = dr.Item("listaprecio")
                dr_aux.Item("fechai") = dr.Item("fechai")
                dr_aux.Item("fechaf") = dr.Item("fechaf")
                dr_aux.Item("horai") = dr.Item("horai").ToString
                dr_aux.Item("horaf") = dr.Item("horaf").ToString
                dr_aux.Item("todos") = dr.Item("todos")
                dr_aux.Item("ctacte") = dr.Item("ctacte")
                dr_aux.Item("porcdescuento") = dr.Item("porcdescuento")
                dr_aux.Item("idoferta") = dr.Item("idoferta")

                Ods.Tables("traslado").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
            ClsGen.Escribir_Log("Prepara Informacion Traslado Memo " & ex.Message)
            '            MessageBox.Show(ex.Message)
            exitoso = False
        Finally

            otrans.close()
            otrans = Nothing
        End Try
        Return exitoso
    End Function

    Private Function Realiza_Traslado_Memos(ByVal _pdr As DataRow, ByVal _numero_memo_flex As String, ByVal pstienda As String) As Boolean

        Dim dr As DataRow
        Dim lerror As Boolean = False
        Dim exitoso As Boolean = True
        Dim sinc As New Sincronizacion.Productos(pstienda)

        Try

            For Each dr In Ods.Tables("traslado").Rows
                If dr.Item("agregar") = True Then
                    sinc.Actualizar_Ofertas(_pdr.Item("empresa").ToString, _numero_memo_flex, dr)
                    If sinc.codigo_error > 0 Then
                        '           MessageBox.Show(sinc.descripcion_error)
                        ClsGen.Escribir_Log(sinc.descripcion_error)
                        lerror = True
                        exitoso = False
                    End If
                End If

            Next

        Catch ex As Exception
            ClsGen.Escribir_Log(ex.Message)
            'MessageBox.Show(sinc.descripcion_error)
            exitoso = False
            lerror = True
        Finally
            sinc.Cerrar()
            sinc = Nothing
        End Try
        If lerror Then
            ClsGen.Escribir_Log("Finalizo Actualizacion a " & pstienda & " Con Errores")
            'MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            ClsGen.Escribir_Log("Actualizacion a " & pstienda & " Finalizada con Exito")
            'MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return exitoso
    End Function

    Private Function Realiza_Traslado_Memos(ByVal _pdr As DataRow, ByVal _numero_memo_flex As String, ByVal pstienda As String, psCadenaConexion As String) As Boolean

        Dim dr As DataRow
        Dim lerror As Boolean = False
        Dim exitoso As Boolean = True
        Dim sinc As New Sincronizacion.Productos(psCadenaConexion, pstienda)

        Try

            For Each dr In Ods.Tables("traslado").Rows
                If dr.Item("agregar") = True Then
                    sinc.Actualizar_Ofertas(_pdr.Item("empresa").ToString, _numero_memo_flex, dr)
                    If sinc.codigo_error > 0 Then
                        '           MessageBox.Show(sinc.descripcion_error)
                        ClsGen.Escribir_Log(sinc.descripcion_error)
                        lerror = True
                        exitoso = False
                    End If
                End If

            Next

        Catch ex As Exception
            ClsGen.Escribir_Log(ex.Message)
            'MessageBox.Show(sinc.descripcion_error)
            exitoso = False
            lerror = True
        Finally
            sinc.Cerrar()
            sinc = Nothing
        End Try
        If lerror Then
            ClsGen.Escribir_Log("Finalizo Actualizacion a " & pstienda & " Con Errores")
            'MessageBox.Show("Finalizo Actualizacion a " & psnombre & " Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            ClsGen.Escribir_Log("Actualizacion a " & pstienda & " Finalizada con Exito")
            'MessageBox.Show("Actualizacion a " & psnombre & " Finalizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return exitoso
    End Function


    Private Sub Crear_Estructura_Traslado()

        Try
            Dim dt = New DataTable("traslado")

            If Not Ods.Tables.Contains("traslado") Then

                dt.Columns.Add(New DataColumn("agregar", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("producto", GetType(String)))
                dt.Columns.Add(New DataColumn("glosa", GetType(String)))
                dt.Columns.Add(New DataColumn("precio", GetType(Double)))
                dt.Columns.Add(New DataColumn("porcentajemax", GetType(Double)))
                dt.Columns.Add(New DataColumn("listaprecio", GetType(String)))
                dt.Columns.Add(New DataColumn("fechai", GetType(Date)))
                dt.Columns.Add(New DataColumn("fechaf", GetType(Date)))
                dt.Columns.Add(New DataColumn("horai", GetType(String)))
                dt.Columns.Add(New DataColumn("horaf", GetType(String)))
                dt.Columns.Add(New DataColumn("todos", GetType(String)))
                dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
                dt.Columns.Add(New DataColumn("porcdescuento", GetType(Double)))
                dt.Columns.Add(New DataColumn("idoferta", GetType(Integer)))

                Ods.Tables.Add(dt.Copy)
            End If
        Catch ex As Exception

        End Try



    End Sub


End Class



#End Region


#Region "Guate Facturas"
'Public Class guateFacturas
'    Dim gsEmpresa As String

'    Public Sub New(ByVal psEmpresa As String)
'        gsEmpresa = psEmpresa
'    End Sub

'    Private Sub crear_estructuraFACE(ByRef odsFACE As DataSet)
'        Dim dt As DataTable

'        odsFACE = New DataSet
'        dt = New DataTable("pedidos")
'        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
'        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
'        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
'        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
'        dt.Columns.Add(New DataColumn("numero", GetType(String)))
'        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
'        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
'        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
'        dt.Columns.Add(New DataColumn("forma_Pago", GetType(String)))
'        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
'        dt.Columns.Add(New DataColumn("PorcDescuento", GetType(Double)))
'        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
'        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
'        dt.Columns.Add(New DataColumn("Total", GetType(String)))
'        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
'        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
'        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
'        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
'        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
'        dt.Columns.Add(New DataColumn("exento", GetType(String)))
'        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
'        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
'        dt.Columns.Add(New DataColumn("Numero_Pedido", GetType(String)))
'        dt.Columns.Add(New DataColumn("Numero_PedidoWM", GetType(String)))
'        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
'        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
'        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
'        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
'        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
'        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
'        dt.Columns.Add(New DataColumn("procesado", GetType(Boolean)))
'        dt.Columns.Add(New DataColumn("MaquinaFace", GetType(Integer)))
'        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
'        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas

'        dt.Columns.Add(New DataColumn("comuna", GetType(String)))  ''(c)24032015 Envios Walmart
'        dt.Columns.Add(New DataColumn("estado", GetType(String)))  ''(c)24032015 Envios Walmart


'        odsFACE.Tables.Add(dt)

'        ' Me.dgv_pedidosFACE.DataSource = odsFACE.Tables("pedidos")

'    End Sub

'    'Genera la Informacion pa el Envio a GuateFacturas con la Estructura de GuateFacturas
'    Private Sub send_procesarInformacionFACE(ByRef psEmpresa As String, ByRef psfecha As Date, ByRef odsFACE As DataSet)

'        Dim Otrans As New Transaccional.Conexion("FlexLine")
'        Dim ls_sql As String
'        Dim dt As DataTable
'        Dim linea As String = String.Empty
'        Dim tipo_documento As String = String.Empty
'        Dim scodigoDocumento As String = String.Empty
'        Dim lsNombreArchivo, lsNombreCompleto As String
'        Dim sdirectorio As String = "C"

'        Dim ClsGen As New ClasesGenerales.General
'        Dim lexito As Boolean
'        Dim importe_total, importe_bruto, importe_neto As Double
'        Dim importe_iva, importe_descuento, impdist As Double

'        Dim i As Integer = 0
'        Dim entro As Boolean = False
'        Dim entro_d As Boolean = False
'        Dim entro_c As Boolean = False
'        Dim reemplazar As Boolean = True
'        Dim vigencia As String = String.Empty
'        Dim exento, dvalorPorcentajeDR1 As Double

'        Dim IMPORT_BRUTO As Double = 0.0
'        Dim IMPORT_NETO As Double = 0.0
'        Dim IMPORT_IVA As Double = 0.0
'        Dim IMPORT_TOTAL As Double = 0.0
'        Dim nLineas As Integer = 0
'        Dim lsRutaArchivos As String
'        Dim lbProcesar As Boolean = True 'Para Enviar Archivo
'        Dim lsLote As String = Now.ToString("HHmmss")
'        Try



'            lsRutaArchivos = sdirectorio & ":\aplicaciones\Guatefacturas Send\" & psEmpresa

'            lsNombreArchivo = "3591-" & lsLote & "-" & _
'                             Today.ToString("yyyyMMdd").Replace("/", "") & ".txt"

'            lsNombreCompleto = lsRutaArchivos & "\" & lsNombreArchivo

'            'ClsGen.Escribir_Log("Cargado Informacion " & lsNombreCompleto)
'            Otrans.open()

'            If reemplazar Then

'                odsFACE.Tables("pedidos").DefaultView.RowFilter = ""

'                For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

'                    '                    If drv.Item("vigencia") = "S" Then

'                    tipo_documento = "FACE"
'                    scodigoDocumento = "63"
'                    If drv.Item("documento").ToString = "Factura" Then
'                        tipo_documento = "FACE"
'                        scodigoDocumento = "63"
'                    ElseIf drv.Item("documento").ToString = "Credito" Then
'                        tipo_documento = "NCE"
'                        scodigoDocumento = "64"
'                    End If


'                    If drv.Item("serie").ToString.Trim = "" Then
'                        If drv.Item("vigencia").ToString = "S" Then 'Or drv.Item("vigencia").ToString = "N" Then
'                            '  If drv.Item("enviar") = True Then 'Or drv.Item("vigencia").ToString = "N" Then

'                            'Cuando es Factura Electronica Pura por medio de FTP lleva otra informacion 22/11/2013
'                            linea = "1|"
'                            linea += "1|" 'Establecimiento que emite el documento (
'                            'linea += "1|" 'Numero de maquina que emite el documento
'                            linea += drv.Item("maquinaFace") & "|"
'                            'linea += "63|" 'Codigo de Documento SAT a cargar 63= Factura Electronica Pura
'                            linea += scodigoDocumento & "|" 'Codigo de Documento SAT a cargar 63= Factura Electronica Pura

'                            linea += Date.Parse(Today.ToString).ToString("yyyyMMdd") & "|" ' & tipo_documento & "|"
'                            linea += drv.Item("codlegal").ToString & "|1|1|"
'                            linea += drv.Item("TipoDoctoOrigen").ToString & "-" & drv.Item("numero").ToString & "|" 'Numero de Referencia Para No Duplicar
'                            linea += "B|1|N|"
'                            linea += drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
'                            linea += drv.Item("direccion").ToString.Replace("|", " ")
'                            If drv.Item("codlegal").ToString = "7378106" Then
'                                linea += "|Vendor 010085261  " '& Me.txtNumero.Text '& drv.Item("numero").ToString
'                            Else
'                                linea += "|Pedido " & drv.Item("numero").ToString
'                            End If

'                            If drv.Item("codlegal").ToString = "7378106" Then 'Numero de Orden
'                                '       linea += "|" & Me.txtNumeroOC.Text '& drv.Item("numero_pedidoWM").ToString
'                                linea += "|"
'                            Else
'                                linea += "|"
'                            End If
'                            If drv.Item("codlegal").ToString = "7378106" Then
'                                '      linea += "|" + Me.txtNumeroOCRecepcionWM.Text
'                                linea += "|"
'                            Else
'                                linea += "|"
'                            End If
'                            linea += "|Bodega " & drv.Item("Bodega").ToString.Trim & "   Agente: " & drv.Item("vendedor").ToString.Trim
'                            linea += "|" & drv.Item("comentario").ToString.Trim.Replace(Chr(13), " ")



'                            'drv.Item("numero").ToString.Trim & ".txt"

'                            'If drv.Item("documento").ToString = "Factura" And entro = False Then
'                            If entro = False Then
'                                If Directory.Exists(lsRutaArchivos) Then
'                                    Try
'                                        System.IO.File.Delete(lsNombreArchivo)
'                                        entro = True
'                                    Catch ex As Exception
'                                        ClsGen.Escribir_Log(ex.ToString)
'                                    End Try
'                                Else
'                                    Try
'                                        System.IO.Directory.CreateDirectory(lsRutaArchivos)
'                                        entro = True
'                                    Catch ex As Exception
'                                        ClsGen.Escribir_Log(ex.ToString & "  " & lsRutaArchivos)
'                                    End Try
'                                End If
'                            End If

'                            lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)

'                            odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString & _
'                                                                        "' and tipodocto  = '" & _
'                                                                       drv.Item("tipodocto").ToString & _
'                                                                       "' and empresa = '" & drv.Item("empresa").ToString & "'"


'                            If drv.Item("documento").ToString.Trim <> "Debito" Then
'                                importe_total = 0
'                                importe_bruto = 0
'                                importe_neto = 0
'                                importe_iva = 0
'                                dvalorPorcentajeDR1 = 0
'                                importe_descuento = 0

'                                For Each drvD As DataRowView In odsFACE.Tables("detalle_pedidos").DefaultView
'                                    dvalorPorcentajeDR1 = 0
'                                    IMPORT_BRUTO = 0
'                                    IMPORT_NETO = 0
'                                    IMPORT_IVA = 0
'                                    IMPORT_TOTAL = 0

'                                    linea = ""
'                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
'                                    linea = "2|" & drvD.Item("cantidad") & "|1|"
'                                    '4.PRECIO
'                                    linea += drvD.Item("Precio") & "|"

'                                    'VERIFICA SI HAY DESCUENTO   
'                                    If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

'                                        If drvD.Item("PorcentajeDR") <> 0 Then
'                                            '5.PORCENTAJE_DESCUENTO 
'                                            linea += drvD.Item("PorcentajeDR") * -1 & "|"
'                                            dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
'                                        Else
'                                            '5.PORCENTAJE_DESCUENTO 
'                                            dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
'                                            linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
'                                        End If

'                                        '6.IMPORTE_DESCUENTO
'                                        linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
'                                        '7.IMPORTE_BRUTO
'                                        linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"
'                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
'                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
'                                    Else
'                                        'SI NO HAY DESCUENTO
'                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
'                                        linea += "0|0|"
'                                        '7.IMPORTE_BRUTO
'                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
'                                        linea += IMPORT_BRUTO & "|"
'                                        importe_bruto += IMPORT_BRUTO
'                                    End If

'                                    'VERIFICA SI HAY IMPORTE EXENTO
'                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
'                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
'                                    If drv.Item("exento").ToString.ToLower = "si" Then
'                                        exento = IMPORT_BRUTO
'                                        '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
'                                        linea += exento & "|0|0|0|"
'                                        IMPORT_TOTAL = exento
'                                        linea += IMPORT_TOTAL & "|"
'                                    Else
'                                        '8.IMPORTE_EXENTO 
'                                        linea += "0|"
'                                        '9.IMPORTE_NETO
'                                        IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
'                                        linea += IMPORT_NETO & "|"
'                                        '10.IMPORTE_IVA    11.IMPORTE_OTROS
'                                        IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
'                                        linea += IMPORT_IVA & "|0|"

'                                        '12.IMPORTE_TOTAL
'                                        IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
'                                        linea += IMPORT_TOTAL & "|"
'                                    End If

'                                    '13.PRODUCTO       14.DESCRIPCION
'                                    linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
'                                    If drv.Item("documento").ToString = "Factura" Or _
'                                        drv.Item("documento").ToString = "Credito" Then

'                                        If drv.Item("exento").ToString.ToLower = "si" Then
'                                            'linea += "0.00|0.00"
'                                            '15.IMPUESTO_DISTRIBUCION
'                                            linea += "0.00"
'                                        Else
'                                            '15.IMPUESTO_DISTRIBUCION
'                                            linea += Math.Round(drvD.Item("Impdist"), 2).ToString
'                                        End If
'                                        '16.PRECIO_SUGERIDO
'                                        linea += "|" & drvD.Item("psugerido").ToString

'                                        If drvD.Item("volumen").ToString.Length > 0 Then
'                                            '17.VOLUMEN
'                                            linea += "|" & drvD.Item("volumen").ToString
'                                        Else
'                                            '17.VOLUMEN
'                                            linea += "|" & 0
'                                        End If
'                                    End If

'                                    impdist = 0

'                                    importe_total += IMPORT_TOTAL
'                                    importe_neto += IMPORT_NETO
'                                    importe_iva += IMPORT_IVA
'                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
'                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
'                                Next '' Detalle de Pedidos

'                                nLineas = odsFACE.Tables("detalle_pedidos").DefaultView.Count
'                                ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
'                                ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
'                                If drv.Item("porcDescuento") > 0 Then
'                                    ls_sql = "pa_var_um_documentov '" & psEmpresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
'                                    dt = Otrans.Obtiene(ls_sql)
'                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

'                                    Dim drv2 As DataRowView = dt.DefaultView(0)
'                                    dvalorPorcentajeDR1 = 0
'                                    IMPORT_BRUTO = 0
'                                    IMPORT_NETO = 0
'                                    IMPORT_IVA = 0
'                                    IMPORT_TOTAL = 0

'                                    Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

'                                    linea = ""
'                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
'                                    linea = "2|1|1|"
'                                    '4.PRECIO
'                                    linea += dMonto & "|"

'                                    'VERIFICA SI HAY DESCUENTO   
'                                    'SI NO HAY DESCUENTO
'                                    '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
'                                    linea += "0|0|"
'                                    '7.IMPORTE_BRUTO
'                                    IMPORT_BRUTO = dMonto
'                                    linea += IMPORT_BRUTO & "|"
'                                    importe_bruto += IMPORT_BRUTO

'                                    'VERIFICA SI HAY IMPORTE EXENTO
'                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
'                                    'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

'                                    '8.IMPORTE_EXENTO 
'                                    linea += "0|"
'                                    '9.IMPORTE_NETO
'                                    IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
'                                    linea += IMPORT_NETO & "|"
'                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
'                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
'                                    linea += IMPORT_IVA & "|0|"

'                                    '12.IMPORTE_TOTAL
'                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
'                                    linea += IMPORT_TOTAL & "|"

'                                    '13.PRODUCTO       14.DESCRIPCION
'                                    'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
'                                    If drv.Item("codlegal").ToString = "7378106" Then
'                                        linea += "0000000002|DESCUENTO POR CENTRALIZACION|"
'                                    Else
'                                        linea += "0000000001|DESCUENTOS GLOBALES|"
'                                    End If


'                                    'linea += "0.00|0.00"
'                                    '15.IMPUESTO_DISTRIBUCION
'                                    linea += "0.00"

'                                    '16.PRECIO_SUGERIDO
'                                    linea += "|0"

'                                    '17.VOLUMEN
'                                    linea += "|0"

'                                    impdist = 0
'                                    importe_total += IMPORT_TOTAL
'                                    importe_neto += IMPORT_NETO
'                                    importe_iva += IMPORT_IVA
'                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
'                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
'                                    nLineas += 1
'                                End If ''Descuento Global



'                                If drv.Item("documento").ToString = "Credito" Then
'                                    linea = ""
'                                    If drv.Item("Refnumero").ToString.Trim.Length = 12 Then

'                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
'                                        dt = Otrans.Obtiene(ls_sql)

'                                        Try
'                                            linea += "3|FACE|" & drv.Item("RefTipoDocto").ToString & "|" & _
'                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")

'                                        Catch ex As Exception

'                                        End Try
'                                    Else

'                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & _
'                                                    "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
'                                        dt = Otrans.Obtiene(ls_sql)

'                                        Try
'                                            linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto4") & "-" & dt.Rows(0).Item("texto1") & "|" & _
'                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")
'                                        Catch ex As Exception
'                                        End Try

'                                    End If
'                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)

'                                End If

'                                If drv.Item("documento").ToString = "Factura" Then
'                                    If Math.Abs(importe_total - drv.Item("total")) > 0.1 Then
'                                        'MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
'                                        ClsGen.Escribir_Log("**** Problemas con Los Totales en " & drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & "','" & drv.Item("numero") & "'")
'                                        lbProcesar = False
'                                    Else
'                                        linea = ""
'                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
'                                        linea += Math.Round(importe_descuento, 2) & "|"
'                                        If drv.Item("exento").ToString.ToLower = "si" Then
'                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
'                                        Else
'                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
'                                        End If
'                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" & _
'                                            nLineas & "|0"

'                                        Dim lsSQL As String = "pa_ins_um_gen_log_documento_face '" & _
'                                            drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & _
'                                            "','" & drv.Item("numero") & "','" & lsLote & "'"
'                                        Otrans.Ingresa(lsSQL)
'                                        If Otrans.Codigo_error = 0 Then
'                                            lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
'                                            drv.Item("procesado") = 1
'                                        End If
'                                    End If
'                                End If '' Factura
'                                If drv.Item("documento").ToString = "Credito" Then
'                                    linea = ""
'                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_total, 2) & "|0|0|" & _
'                                    nLineas & "|" & dt.Rows.Count
'                                    Dim lsSQL As String = "pa_ins_um_gen_log_documento_face '" & _
'                                        drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & _
'                                        "','" & drv.Item("numero") & "','" & lsLote & "'"

'                                    Otrans.Ingresa(lsSQL)
'                                    If Otrans.Codigo_error = 0 Then
'                                        lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
'                                        drv.Item("procesado") = 1
'                                    End If

'                                End If
'                            End If
'                        End If 'drv.Item("vigencia").ToString = "S"
'                    End If 'Serie Vacia
'                    ' End If 'Pedido Enviar
'                Next

'                If File.Exists(lsNombreCompleto) Then
'                    If lbProcesar Then
'                        ClsGen.Comprimir_Archivo(lsRutaArchivos, lsNombreArchivo, lsRutaArchivos & "\", lsNombreArchivo.Replace("txt", "zip"))
'                        ClsGen.Comprimir_Archivo(lsRutaArchivos, "1.txt", lsRutaArchivos & "\", lsNombreArchivo.Replace(".txt", "-OK.zip"))
'                        Dim lsArchivos As String() = Directory.GetFiles(lsRutaArchivos, "*.zip")

'                        'If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
'                        Dim iArchivosSincronizados As String = 0

'                        For Each lsarchivo As String In lsArchivos
'                            If lsarchivo.IndexOf("-OK") = -1 Then ' And lsarchivo.Trim.Length > 0 Then
'                                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
'                                    iArchivosSincronizados = 1
'                                End If
'                            End If
'                        Next


'                        For Each lsarchivo As String In lsArchivos
'                            If lsarchivo.IndexOf("-OK") <> 1 Then 'And lsarchivo.Trim.Length > 0 Then
'                                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
'                                    iArchivosSincronizados += 1
'                                End If
'                            End If
'                        Next


'                        ClsGen.Escribir_Log("Archivos Sincronizados " & iArchivosSincronizados.ToString)
'                        If iArchivosSincronizados >= 2 Then
'                            moverArchivosFACE(psEmpresa, "Send")
'                        End If
'                    Else 'Si No  se procesa Por que Alguno estaba Malo

'                        ClsGen.Mover_Archivo(lsNombreCompleto, lsRutaArchivos & "\Err\" & lsNombreArchivo)
'                        'Debo Regresar Los que fueron Procesados
'                        odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
'                        For Each dr As DataRow In odsFACE.Tables("pedidos").Rows
'                            If dr.Item("procesado") = True Then
'                                Dim lsSQL As String = "pa_del_um_gen_log_documento_face '" & _
'                                                dr.Item("Empresa") & "','" & dr.Item("tipoDoctoOrigen") & "','" & dr.Item("numero") & "'"
'                                Otrans.Elimina(lsSQL)

'                            End If
'                        Next



'                    End If
'                End If 'Existe Archivo

'            End If
'        Catch ex As Exception
'            ClsGen.Escribir_Log(" Fnal Send_ProcesarInformacion " & ex.Message)
'        Finally
'            Otrans.close()
'            Otrans = Nothing
'            ClsGen = Nothing
'        End Try
'    End Sub

'    Private Sub send_enviosPendientesFACE(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet)
'        Dim oTrans As Transaccional.Conexion
'        Dim clGen As New ClasesGenerales.General
'        Dim oTabla As DataTable
'        Dim dt, dtPermisos As DataTable
'        Dim drv As DataRowView
'        Dim dr, dr_aux As DataRow
'        Dim lbProcesar As Boolean
'        Dim ls_sqltxt, lsFiltro As String
'        Dim iCount As Integer
'        'Dim odsFACE As New DataSet

'        odsFACE.Tables("pedidos").Rows.Clear()
'        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
'        clGen.Escribir_Log(ls_sqltxt)
'        oTrans = New Transaccional.Conexion("flexline")
'        Try

'            oTrans.open()
'            oTabla = oTrans.Obtiene(ls_sqltxt)

'            oTabla.DefaultView.RowFilter = "documento like 'factura'"



'            ''Armar_Filtro
'            'ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
'            'dt = oTrans.Obtiene(ls_sqltxt)

'            'dt.DefaultView.RowFilter = "CODIGO = '" & psEmpresa & "'"
'            'dtPermisos = dt.DefaultView.ToTable.Copy


'            '
'            For Each dr In oTabla.Rows



'                If dr.Item("fechaenvio") = "01/01/1900" And _
'                    (dr.Item("tipodocto").ToString = "PEDIDO FACE" Or dr.Item("tipodocto").ToString = "PEDIDO FACE RE") _
'                    And dr.Item("total") > 0 Then

'                    dr_aux = odsFACE.Tables("pedidos").NewRow

'                    Try
'                        dr_aux.Item("Enviar") = 0
'                        If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
'                    Catch ex As Exception

'                    End Try

'                    dr_aux.Item("serie") = dr.Item("serie")
'                    dr_aux.Item("documento") = dr.Item("documento")
'                    dr_aux.Item("empresa") = dr.Item("empresa")
'                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
'                    dr_aux.Item("correlativo") = dr.Item("correlativo")
'                    dr_aux.Item("numero") = dr.Item("numero")
'                    dr_aux.Item("fecha") = dr.Item("fecha")
'                    dr_aux.Item("codlegal") = dr.Item("codlegal")
'                    dr_aux.Item("ctacte") = dr.Item("ctacte")
'                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
'                    dr_aux.Item("direccion") = dr.Item("direccion")
'                    dr_aux.Item("telefono") = dr.Item("telefono")
'                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
'                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
'                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
'                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
'                    dr_aux.Item("vigencia") = dr.Item("vigencia")
'                    dr_aux.Item("exento") = dr.Item("exento")
'                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
'                    dr_aux.Item("comentario") = dr.Item("comentario")
'                    dr_aux.Item("Bodega") = dr.Item("bodega")
'                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
'                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
'                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
'                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
'                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
'                    dr_aux.Item("total") = dr.Item("total")
'                    Try
'                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
'                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
'                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
'                        End If
'                    Catch ex As Exception

'                    End Try
'                    dr_aux.Item("procesado") = 0
'                    Try
'                        If dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE" Then
'                            dr_aux.Item("MaquinaFACE") = 1
'                        ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
'                            dr_aux.Item("MaquinaFACE") = 2
'                        End If
'                    Catch ex As Exception

'                    End Try
'                    dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
'                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)
'                End If


'            Next

'            ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & psFecha & "','" & psFecha & "','" & psEmpresa & "'"
'            oTabla = oTrans.Obtiene(ls_sqltxt)
'            oTabla.TableName = "detalle_pedidos"

'            odsFACE.Tables.Add(oTabla.Copy)
'            ' clGen.Escribir_Log(ls_sqltxt)
'            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)
'        Catch ex As Exception
'            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)
'            'MessageBox.Show(ex.Message)
'        Finally

'            oTrans.close()
'            oTrans = Nothing
'            clGen = Nothing
'        End Try


'    End Sub


'    Private Sub send_enviosPendientesNCFACE(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet)
'        Dim oTrans As Transaccional.Conexion
'        Dim clGen As New ClasesGenerales.General
'        Dim oTabla As DataTable
'        Dim dt, dtPermisos As DataTable
'        Dim drv As DataRowView
'        Dim dr_aux As DataRow
'        Dim lbProcesar As Boolean
'        Dim ls_sqltxt, lsFiltro As String
'        Dim iCount As Integer
'        'Dim odsFACE As New DataSet

'        'odsFACE.Tables("pedidos").Rows.Clear()
'        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
'        clGen.Escribir_Log(ls_sqltxt)
'        oTrans = New Transaccional.Conexion("flexline")
'        Try

'            oTrans.open()
'            oTabla = oTrans.Obtiene(ls_sqltxt)

'            oTabla.DefaultView.RowFilter = "documento like '%Credito%'"



'            ''Armar_Filtro
'            'ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
'            'dt = oTrans.Obtiene(ls_sqltxt)

'            'dt.DefaultView.RowFilter = "CODIGO = '" & psEmpresa & "'"
'            'dtPermisos = dt.DefaultView.ToTable.Copy


'            '
'            For Each dr As DataRowView In oTabla.DefaultView



'                If dr.Item("fechaenvio") = "01/01/1900" And _
'                    (dr.Item("tipodocto").ToString = "NOTA CREDITO FACE" _
'                    And dr.Item("total")) > 0 Then

'                    dr_aux = odsFACE.Tables("pedidos").NewRow

'                    Try
'                        dr_aux.Item("Enviar") = 0
'                        If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
'                    Catch ex As Exception

'                    End Try

'                    dr_aux.Item("serie") = dr.Item("serie")
'                    dr_aux.Item("documento") = dr.Item("documento")
'                    dr_aux.Item("empresa") = dr.Item("empresa")
'                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
'                    dr_aux.Item("correlativo") = dr.Item("correlativo")
'                    dr_aux.Item("numero") = dr.Item("numero")
'                    dr_aux.Item("fecha") = dr.Item("fecha")
'                    dr_aux.Item("codlegal") = dr.Item("codlegal")
'                    dr_aux.Item("ctacte") = dr.Item("ctacte")
'                    dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
'                    dr_aux.Item("direccion") = dr.Item("direccion")
'                    dr_aux.Item("telefono") = dr.Item("telefono")
'                    dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
'                    dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
'                    dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
'                    dr_aux.Item("RefFecha") = dr.Item("fechaRef")
'                    dr_aux.Item("vigencia") = dr.Item("vigencia")
'                    dr_aux.Item("exento") = dr.Item("exento")
'                    dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
'                    dr_aux.Item("comentario") = dr.Item("comentario")
'                    dr_aux.Item("Bodega") = dr.Item("bodega")
'                    dr_aux.Item("Vendedor") = dr.Item("vendedor")
'                    dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
'                    dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
'                    dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
'                    dr_aux.Item("forma_pago") = dr.Item("codigoPago")
'                    dr_aux.Item("total") = dr.Item("total")
'                    Try
'                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
'                            dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
'                            dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
'                        End If
'                    Catch ex As Exception

'                    End Try
'                    dr_aux.Item("procesado") = 0
'                    Try
'                        If dr.Item("TipoDocto").ToString.ToUpper = "NOTA CREDITO FACE" Then
'                            dr_aux.Item("MaquinaFACE") = 1
'                            'ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
'                            '    dr_aux.Item("MaquinaFACE") = 2
'                        End If
'                    Catch ex As Exception

'                    End Try
'                    dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
'                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)
'                End If


'            Next

'            '(c) ya no llena esta info por que la trae de las facturas (c)
'            'ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & psFecha & "','" & psFecha & "','" & psEmpresa & "'"
'            'oTabla = oTrans.Obtiene(ls_sqltxt)
'            'oTabla.TableName = "detalle_pedidos"

'            'odsFACE.Tables.Add(oTabla.Copy)
'            '' clGen.Escribir_Log(ls_sqltxt)
'            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)
'        Catch ex As Exception
'            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)
'            'MessageBox.Show(ex.Message)
'        Finally

'            oTrans.close()
'            oTrans = Nothing
'            clGen = Nothing
'        End Try


'    End Sub


'    ' Generar Informacion para Envio a GuateFacturas
'    Public Sub generarInformacion()

'        Dim clsGen As New ClasesGenerales.General

'        Try
'            Dim dFechaProceso As Date = Today

'            'For Each sempresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")
'            Dim odsFACE As New DataSet
'            'clsGen.Escribir_Log("Generar " & sempresa)
'            crear_estructuraFACE(odsFACE)
'            send_enviosPendientesFACE(gsEmpresa, dFechaProceso, odsFACE)
'            send_enviosPendientesNCFACE(gsEmpresa, dFechaProceso, odsFACE)
'            send_procesarInformacionFACE(gsEmpresa, dFechaProceso, odsFACE)
'            'Next

'        Catch ex As Exception
'            clsGen.Escribir_Log(ex.Message)
'            clsGen.Escribir_Log(ex.ToString)
'        Finally

'            clsGen = Nothing
'        End Try

'    End Sub

'    ' Obtiene Informacion Generada en GuateFacturas
'    Public Sub obtenerInformacion()
'        Dim sUsuario As String = "GUATE_FTP"
'        Dim sRutaZip As String

'        'For Each sempresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")
'        Dim dFechaProceso As Date = Today

'        Dim odsFACE As New DataSet

'        Try

'            crear_estructuraFACE(odsFACE)
'            obtenerProcesadosGuateFacturas(gsEmpresa)
'            extraerzipFACE(gsEmpresa, sRutaZip, sUsuario, odsFACE, dFechaProceso)
'        Catch ex As Exception

'        End Try

'        'Next
'    End Sub


'    Public Sub limpiarInformacion()
'        'For Each sempresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")

'        Try
'            Me.LimpiarProcesadosGuateFacturas(gsEmpresa)
'            'crear_estructuraFACE(odsFACE)
'            'obtenerProcesadosGuateFacturas(sempresa)
'            'extraerzipFACE(sempresa, sRutaZip, sUsuario, odsFACE, dFechaProceso)
'        Catch ex As Exception

'        End Try

'        'Next
'    End Sub

'    'Extrae la Informacion de los Archivos Generados por Guatefacturas
'    Private Sub extraerzipFACE(ByVal psEmpresa As String, ByRef psRutaZip As String, ByRef psUsuario As String, ByVal odsFace As DataSet, ByRef psFecha As Date)

'        Dim ClsGen As New ClasesGenerales.General
'        Dim lsRuta As String
'        Dim lsArchivos() As String
'        psRutaZip = String.Empty

'        Try
'            lsRuta = "C:\aplicaciones\Guatefacturas Receive\" & psEmpresa

'            lsArchivos = Directory.GetFiles(lsRuta, "*.zip")
'            If lsArchivos.Length = 1 Then
'                '                MessageBox.Show("No Puede Haber Mas de un Archivo ZIP en " & Chr(13) & Me.txtRuta.Text, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            ElseIf lsArchivos.Length > 1 Then 'Debe venir uno con nombre Ok
'                For Each lsarchivo As String In lsArchivos

'                    If lsarchivo.IndexOf("OK") > 0 Then 'Si Tengo el Archivo Ok, Proceso el 
'                        'ClsGen.Descomprimir_Archivo(lsArchivos(0), lsRuta)
'                        ClsGen.Descomprimir_Archivo(lsarchivo.Replace("-OK", String.Empty), lsRuta & "\Proceso")
'                        'Dim di As New DirectoryInfo(lsRuta & "\app")
'                        Dim di As New DirectoryInfo(lsRuta & "\Proceso")
'                        Dim fics() As FileInfo
'                        fics = di.GetFiles("*.txt", SearchOption.AllDirectories)
'                        Dim lsTextos As String() = Directory.GetFiles(lsRuta & "\Proceso", "*.txt")
'                        'MessageBox.Show(fics(0).FullName)
'                        'If fics.Length = 2 Then
'                        If lsTextos.Length = 2 Then
'                            For Each lstexto As String In lsTextos
'                                If lstexto.IndexOf("ERR") > -1 Then
'                                    'psRutaZip = fics(0).FullName
'                                    psRutaZip = lstexto.Replace("-ERR", String.Empty)
'                                    generarFACEFlexLine(psEmpresa, psUsuario, psRutaZip, odsFace, psFecha)
'                                    ClsGen.Eliminar_Archivo(lstexto)
'                                    ClsGen.Eliminar_Archivo(psRutaZip)
'                                    moverArchivosFACEEspecifico(psEmpresa, "Receive", lsarchivo)
'                                    moverArchivosFACEEspecifico(psEmpresa, "Receive", lsarchivo.Replace("-OK", String.Empty))
'                                End If


'                            Next
'                        Else
'                            For Each lstexto As String In lsTextos

'                                'psRutaZip = lstexto
'                                procesarErrorFACE(psEmpresa, psUsuario, lstexto, odsFace, psFecha)
'                                ClsGen.Eliminar_Archivo(lstexto)
'                                moverArchivosFACEEspecifico(psEmpresa, "Err", lsarchivo)
'                                moverArchivosFACEEspecifico(psEmpresa, "Err", lsarchivo.Replace("-OK", String.Empty))
'                            Next

'                        End If
'                    End If
'                Next
'            Else
'            End If

'        Catch ex As Exception
'            ClsGen.Escribir_Log("Extraer Zip " & ex.ToString)
'        Finally
'            ClsGen = Nothing

'        End Try


'    End Sub

'    Private Sub procesarErrorFACE(ByRef psEmpresa As String, ByRef psUsuario As String, _
'                           psRutaZip As String, ByVal odsFace As DataSet, ByRef psFecha As Date)


'        Dim Otrans As New Transaccional.Conexion("FlexLine")
'        Dim lsSQL As String
'        Dim clsGen As New ClasesGenerales.General
'        Dim lsrutaGenera As String
'        Dim dtDocumentos As DataTable


'        Try

'            Otrans.open()

'            Dim sArchivo As String = psRutaZip
'            Dim sLineas, sDetalle, Sdocumento As String()
'            Dim sr As New System.IO.StreamReader(sArchivo)

'            lsrutaGenera = sr.ReadToEnd()
'            sr.Close()


'            lsSQL = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
'            dtDocumentos = Otrans.Obtiene(lsSQL)

'            sLineas = lsrutaGenera.Split(Chr(10))
'            For Each sLinea As String In sLineas
'                If sLinea.Length > 0 Then
'                    sDetalle = sLinea.Split("|")
'                    If sDetalle.Length = 6 Then 'Solo Trae 6 Lineas cuando se pasa primero el archivo Ok y luego el de Datos
'                        Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5))
'                        limpiarLote(sArchivo.Split("-")(1), Otrans)
'                    ElseIf sDetalle.Length = 24 Then
'                        If sDetalle(4) = "2" Then 'Problemas con el Nit
'                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14))
'                            Sdocumento = sDetalle(14).Split("-")
'                            dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
'                            If dtDocumentos.DefaultView.Count = 1 Then
'                                lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
'                                    Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
'                                Otrans.Actualiza(lsSQL)
'                            End If
'                            limpiarLote(sArchivo.Split("-")(1), Otrans)
'                        ElseIf sDetalle(4) = "57" Then 'Archivo Duplicado
'                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14))

'                            Try
'                                Sdocumento = sDetalle(14).Split("-")
'                                dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
'                                If dtDocumentos.DefaultView.Count = 1 Then
'                                    lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
'                                        Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
'                                    Otrans.Actualiza(lsSQL)
'                                End If
'                            Catch ex As Exception
'                            End Try
'                        ElseIf sDetalle(4) = "15" Then 'Documento Enviados No Existen
'                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14))

'                            Try
'                                Sdocumento = sDetalle(14).Split("-")
'                                dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
'                                If dtDocumentos.DefaultView.Count = 1 Then
'                                    lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
'                                        Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
'                                    Otrans.Actualiza(lsSQL)
'                                End If
'                            Catch ex As Exception
'                            End Try

'                        ElseIf sDetalle(4) = "40" Then 'Tipo Documento No Existe
'                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14))
'                        Else
'                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Error Desconocido " & sDetalle(4) & sDetalle(5))
'                        End If
'                    Else
'                        Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Error Desconocido")
'                    End If
'                End If
'            Next



'        Catch ex As Exception
'            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
'        Finally
'            Otrans.close()
'            Otrans = Nothing
'            clsGen = Nothing
'        End Try
'    End Sub

'    Private Sub limpiarLote(psLote As String, Otrans As Transaccional.Conexion)
'        Dim dt As DataTable
'        Dim lsSQL As String
'        Try
'            lsSQL = "pa_sel_um_gen_log_documento_FACE_lote '" & psLote & "'"
'            dt = Otrans.Obtiene(lsSQL)
'            For Each dr As DataRow In dt.Rows
'                lsSQL = "pa_del_um_gen_log_documento_face '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'"
'                Otrans.Elimina(lsSQL)
'            Next

'        Catch ex As Exception

'        End Try
'    End Sub

'    'Inserta las facturas generadas en GUATEFACTURA en FlexLine
'    Private Sub generarFACEFlexLine(ByRef psEmpresa As String, ByRef psUsuario As String, _
'                            psRutaZip As String, ByVal odsFace As DataSet, ByRef psFecha As Date)


'        Dim Otrans As New Transaccional.Conexion("FlexLine")
'        Dim lsSQL As String
'        Dim clsGen As New ClasesGenerales.General
'        Dim lsrutaGenera As String
'        Dim dtDocumentos, dtImpresoras As DataTable
'        Dim dr As DataRow


'        Try

'            Otrans.open()

'            Dim sArchivo As String = psRutaZip

'            Dim sLineas, sDetalle, Sdocumento As String()


'            Dim sr As New System.IO.StreamReader(sArchivo)
'            lsrutaGenera = sr.ReadToEnd()
'            sr.Close()

'            odsFace.Tables("pedidos").Rows.Clear()

'            lsSQL = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
'            dtDocumentos = Otrans.Obtiene(lsSQL)

'            sLineas = lsrutaGenera.Split(Chr(10))
'            For Each sLinea As String In sLineas
'                If sLinea.Length > 0 Then
'                    sDetalle = sLinea.Split("|")
'                    Sdocumento = sDetalle(8).Split("-")
'                    dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
'                    If dtDocumentos.DefaultView.Count = 1 Then

'                        If Math.Abs(dtDocumentos.DefaultView(0).Item("total") - sDetalle(5)) > 0.1 Then
'                            clsGen.Escribir_Log("Problemas con los totales en el Documento " & psEmpresa & " " & Sdocumento(0) & " " & Sdocumento(1) & " " &
'                                                 sDetalle(2) & " " & sDetalle(3))
'                            Me.guardarAviso("Problemas con los totales en el Documento  " & psEmpresa & " " & Sdocumento(0) & " " & Sdocumento(1) & " " &
'                                                 sDetalle(2) & " " & sDetalle(3))

'                            lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
'                                       Sdocumento(0) & "','" & Sdocumento(1) & "','Diferencia En Los Totales Flex-GuateFacturas'"
'                            Otrans.Actualiza(lsSQL)
'                        Else
'                            dr = odsFace.Tables("pedidos").NewRow
'                            dr.Item("tipoDoctoOrigen") = Sdocumento(0)
'                            dr.Item("numero") = Sdocumento(1)
'                            dr.Item("fechaFACE") = sDetalle(1).Substring(6, 2) & "/" & sDetalle(1).Substring(4, 2) & "/" & sDetalle(1).Substring(0, 4) 'añomesdia
'                            dr.Item("serieFACE") = sDetalle(2)
'                            dr.Item("numeroFACE") = sDetalle(3)
'                            dr.Item("firmaFACE") = sDetalle(7)
'                            dr.Item("nitFACE") = sDetalle(4)
'                            dr.Item("nombreFACE") = sDetalle(9)
'                            dr.Item("direccionFACE") = sDetalle(10)
'                            dr.Item("ctacte") = dtDocumentos.DefaultView(0).Item("ctacte")
'                            dr.Item("ImpresoraFACE") = dtDocumentos.DefaultView(0).Item("impresora")
'                            Try
'                                dr.Item("BodegaInterEmpresas") = dtDocumentos.DefaultView(0).Item("bodegaFacturar").ToString
'                            Catch ex As Exception

'                            End Try
'                            Try
'                                dr.Item("forma_pago") = dtDocumentos.DefaultView(0).Item("codigopago")
'                            Catch ex As Exception

'                            End Try

'                            odsFace.Tables("pedidos").Rows.Add(dr)
'                        End If
'                    Else
'                        clsGen.Escribir_Log("Filtro " & "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero '" & Sdocumento(1) & "'")
'                    End If
'                End If
'            Next

'            odsFace.Tables("pedidos").DefaultView.RowFilter = ""

'            For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView

'                If drv.Item("numeroFACE").ToString.Trim.Length > 0 Then
'                    ''Creamos los documentos FACE
'                    lsSQL = "pa_ins_um_documento_FACE '" & psEmpresa & "','" & _
'                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
'                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
'                            drv.Item("firmaFACE").ToString.PadRight(100, " ") & "','" & psEmpresa & "','" & _
'                            Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"


'                    If Otrans.Ingresa(lsSQL) > 0 Then
'                        lsSQL = "pa_ins_um_documentod_FACE '" & psEmpresa & "','" & _
'                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
'                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
'                                Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"
'                        Otrans.Ingresa(lsSQL)
'                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)

'                        lsSQL = "pa_ins_um_documentop_FACE '" & psEmpresa & "','" & _
'                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
'                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"
'                        Otrans.Ingresa(lsSQL)
'                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)

'                        lsSQL = "pa_ins_um_documentov_FACE '" & psEmpresa & "','" & _
'                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
'                                drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "'"

'                        Otrans.Ingresa(lsSQL)
'                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)

'                        ''Anulo el Documento Anterior ''Pruebas No lo debo realizar
'                        lsSQL = "pa_upd_um_documento_estado '" & psEmpresa & "','" & _
'                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "',NULL,'A','" & _
'                                psUsuario & "','" & drv.Item("serieFACE") & " " & drv.Item("numeroFACE") & "'"
'                        Otrans.Actualiza(lsSQL)
'                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)

'                        ''Actualizo la Informacion de GuateFactura

'                        lsSQL = "pa_upd_um_ctacte_FACE '" & psEmpresa & "','" & _
'                            drv.Item("ctacte") & "','" & _
'                            drv.Item("nitFACE") & "','" & _
'                            drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" & _
'                            drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "','" & _
'                            drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" & _
'                            drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "'"

'                        Otrans.Actualiza(lsSQL)
'                        'guardarAviso(Otrans.descripcion_error)
'                        If Otrans.Codigo_error > 0 Then
'                            clsGen.Escribir_Log(lsSQL)
'                            Otrans.Actualiza(lsSQL)
'                            guardarAviso(Otrans.descripcion_error)
'                        Else
'                            Dim lsSQL2 As String = ""
'                            Try

'                                Dim DtCliente As DataTable
'                                lsSQL2 = "pa_sel_um_ctacte '" & psEmpresa & "','CLIENTE','" & drv.Item("ctacte") & "'"
'                                DtCliente = Otrans.Obtiene(lsSQL2)
'                                If DtCliente.Rows(0).Item("AnalisisCtaCte25").ToString.Trim.Length = 0 Then
'                                    clsGen.Escribir_Log(lsSQL2)
'                                    Otrans.Actualiza(lsSQL)
'                                End If

'                            Catch ex As Exception
'                                clsGen.Escribir_Log(ex.ToString)
'                                clsGen.Escribir_Log(lsSQL)
'                                clsGen.Escribir_Log(lsSQL2)

'                            End Try

'                        End If
'                        If drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("walmart") > 0 Then
'                            'Los Pedidos de WalMart No deben Generar Picking por eso se llena la Informacion con picker en Blanco
'                            lsSQL = "pa_ins_um_gen_log_documento_tracking  '" & _
'                                        drv.Item("empresa") & "','" & drv.Item("serieFACE") & _
'                                        "','" & drv.Item("numeroFACE") & "','" & psUsuario & "','" & _
'                                          "', NULL"
'                            Otrans.Ingresa(lsSQL)
'                            If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)
'                        End If
'                        lsSQL = "pa_upd_um_gen_log_documento_face_proceso '" & psEmpresa & "','" & _
'                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "'"

'                        Otrans.Actualiza(lsSQL)
'                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)


'                        If drv.Item("tipodocto").ToString.ToLower.StartsWith("pedido consol") Then
'                            ''Debo correr el Script del pedido Consolidad0
'                        End If
'                        ''Llamar al Reporte
'                        Try

'                            Dim pm_valores(3), pm_valores_consolidado(2) As String
'                            Dim pm_parametros(3) As String
'                            Dim pm_conexion(3) As String


'                            pm_conexion = clsGen.Parametros_Conexion("")
'                            Dim ppath_reporte As String = clsGen.Path_Reporte

'                            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
'                            ppath_reporte += psEmpresa.ToLower.Trim + " "
'                            ppath_reporte += drv.Item("serieFACE").ToString.Trim
'                            ppath_reporte += ".rpt"
'                            pm_parametros(0) = "empresa"
'                            pm_parametros(1) = "tipodocto"
'                            pm_parametros(2) = "numero"
'                            pm_parametros(3) = "user_name"
'                            pm_valores(0) = psEmpresa
'                            pm_valores(1) = drv.Item("serieFACE")
'                            pm_valores(2) = drv.Item("numeroFACE")
'                            pm_valores(3) = "GUATE_FTP"

'                            'Guardo las copias en pdf

'                            Dim ncopias As Integer
'                            ncopias = clsGen.numeroCopias(psEmpresa, drv.Item("ctacte"), drv.Item("forma_pago").ToString, _
'                                                          IIf(drv.Item("tipodoctoOrigen").ToString.LastIndexOf("RE") > 0, 1, 0), drv.Item("serieFACE"))


'                            ''Revisar Impresora a Imprimir

'                            Try

'                                dtImpresoras = clsGen.selectQuery("FlexLine", _
'                                                                  "pa_sel_um_gen_tabcod '" & drv.Item("tipodoctoOrigen") & "','gen_impresion','" & psEmpresa & "'")

'                                If dtImpresoras.Rows.Count = 1 Then
'                                    If dtImpresoras.Rows(0).Item("valor1") = 1 Then drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")

'                                End If
'                            Catch ex As Exception

'                            End Try


'                            If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then ncopias = 1

'                            If ncopias > 0 Then
'                                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
'                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
'                                    False, True, "PDF", False, "", True, ncopias, psEmpresa, drv.Item("ImpresoraFACE").ToString)
'                            End If


'                            '                        _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
'                            'pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
'                            '    False, True, "PDF", False, "", True, 3, psEmpresa, drv.Item("ImpresoraFACE").ToString)

'                            'clsGen.Escribir_Log(drv.Item("bodegaInterEmpresas").ToString)
'                            If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then 'Si El Pedido Lleva Bodega debe Realizar un Ingreso a la Bodega
'                                lsSQL = "flexline.spa_Convierte_FactVtas_Compras '" & psEmpresa & "','" & _
'                                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
'                                            drv.Item("bodegaInterEmpresas") & "','ADMIN_ISF'"

'                                If Otrans.Ingresa(lsSQL) > 0 Then 'Si se realizo el SP
'                                    clsGen.Escribir_Log("Enviar Impresion Ingreso " & psEmpresa)
'                                    ppath_reporte = clsGen.Path_Reporte
'                                    ppath_reporte = ppath_reporte & "Logistica\Bodega\Impresion de Compras.rpt"
'                                    Dim pm_parametros2(3) As String
'                                    Dim pm_valores2(3) As String

'                                    clsGen.Escribir_Log("Inicializo Parametros " & psEmpresa)
'                                    pm_parametros2(0) = "@Empresa"
'                                    pm_parametros2(1) = "@Tipodocto"
'                                    pm_parametros2(2) = "@Numero"
'                                    pm_parametros2(3) = "@Proveedor"

'                                    clsGen.Escribir_Log("Inicializo Valores " & psEmpresa)
'                                    pm_valores2(0) = psEmpresa
'                                    If drv.Item("ctacte").ToString.StartsWith("12218") Then
'                                        pm_valores2(0) = "DMARTE1"
'                                    ElseIf drv.Item("ctacte").ToString.StartsWith("7951") Then
'                                        pm_valores2(0) = "CODICASA"
'                                    ElseIf drv.Item("ctacte").ToString.StartsWith("6608") Then
'                                        pm_valores2(0) = "DIUVA"
'                                    ElseIf drv.Item("ctacte").ToString.StartsWith("2968") Then
'                                        pm_valores2(0) = "VINOTECA"
'                                    End If

'                                    clsGen.Escribir_Log("Parametros0 " & pm_valores2(0))
'                                    pm_valores2(1) = "FACE DE COMPRAS" '' drv.Item("serieFACE")
'                                    pm_valores2(2) = drv.Item("numeroFACE")
'                                    clsGen.Escribir_Log("Parametros1 " & pm_valores2(1))
'                                    clsGen.Escribir_Log("Parametros2 " & pm_valores2(2))

'                                    If psEmpresa.ToLower.Equals("dmarte1") Then
'                                        pm_valores2(3) = "122183"
'                                    ElseIf psEmpresa.ToLower.Equals("codicasa") Then
'                                        pm_valores2(3) = "79512"
'                                    ElseIf psEmpresa.ToLower.Equals("diuva") Then
'                                        pm_valores2(3) = "6608388"
'                                    End If

'                                    'Los Ingresos Interempresas se imprimen en la misma impresora de facturas


'                                    clsGen.Escribir_Log("Parametros3 " & pm_valores2(3))

'                                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
'                                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
'                                            False, True, "PDF", False, "", True, 2, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)


'                                End If 'realiza el ingreso
'                            End If 'bodega Interempresa

'                            ''Forma de Pago
'                            If drv.Item("forma_pago").ToString.ToLower.StartsWith("contado") And drv.Item("tipodoctoOrigen").ToString.ToUpper = "PEDIDO FACE" Then

'                                'lsSQL = flexline.spa_RecibosGuarda @Empresa varchar(20),@Tipodocto varchar(40), @Numero varchar(20)
'                                lsSQL = " flexline.spa_RecibosGuarda '" & psEmpresa & "','" & drv.Item("serieFACE").ToString & "','" & drv.Item("numeroFACE").ToString & "'"
'                                If Otrans.Ingresa(lsSQL) > 0 Then
'                                    ppath_reporte = clsGen.Path_Reporte
'                                    ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"

'                                    Dim pm_parametros2(2) As String
'                                    Dim pm_valores2(2) As String

'                                    pm_parametros2(0) = "Empresa"
'                                    pm_parametros2(1) = "Tipodocto"
'                                    pm_parametros2(2) = "Numero"

'                                    pm_valores2(0) = psEmpresa
'                                    pm_valores2(1) = drv.Item("serieFACE")
'                                    pm_valores2(2) = drv.Item("numeroFACE")


'                                    Try
'                                        ncopias = 1
'                                        dtImpresoras = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod 'recibos','gen_impresion','" & psEmpresa & "'")

'                                        If dtImpresoras.Rows.Count = 1 Then
'                                            If dtImpresoras.Rows(0).Item("valor1") = 1 Then
'                                                drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")
'                                                ncopias = 2
'                                            End If


'                                        End If
'                                    Catch ex As Exception

'                                    End Try

'                                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
'                                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
'                                            False, True, "PDF", False, "", True, 2, psEmpresa, drv.Item("ImpresoraFACE").ToString)


'                                    'Guardar Copia Electronica del Recibo
'                                    'Dim lsRutaCopia As String = clsGen.Path_Imagenes
'                                    'lsRutaCopia += "Recibos\" + psEmpresa + "\" + drv.Item("serieFACE") + "-" + drv.Item("numeroFACE")


'                                    '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
'                                    '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
'                                    '        True, False, "PDF", False, lsRutaCopia, True, 1, psEmpresa, "")

'                                End If

'                            End If 'forma Pago


'                            'Abro las Nota de Credito Face para que puedan reporcesar
'                            If drv.Item("tipodoctoOrigen").ToString.ToUpper = "NOTA CREDITO FACE" Then

'                                ''Anulo el Documento Anterior ''Pruebas No lo debo realizar
'                                lsSQL = "pa_upd_um_documento_estado '" & psEmpresa & "','" & _
'                                        drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "',NULL,'S','" & _
'                                        psUsuario & "','" & drv.Item("tipodoctoOrigen") & " " & drv.Item("numero") & "'"


'                                Otrans.Actualiza(lsSQL)
'                                If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error)
'                            End If


'                        Catch ex As Exception

'                        End Try
'                    End If
'                End If
'            Next


'        Catch ex As Exception
'            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
'        Finally
'            Otrans.close()
'            Otrans = Nothing
'            clsGen = Nothing
'        End Try
'    End Sub

'    Private Sub moverArchivosFACE(psEmpresa As String, ByRef psTipo As String)

'        Dim clsGen As New ClasesGenerales.General
'        Dim lsArchivos() As String
'        Try

'            Dim lsRuta As String = "C:\aplicaciones\Guatefacturas " & psTipo & "\" & psEmpresa

'            If Not Directory.Exists(lsRuta & "\" & Today.ToString("yyyyMM")) Then 'Si el Directorio Año Mes No Existe lo tengo que crear
'                System.IO.Directory.CreateDirectory(lsRuta & "\" & Today.ToString("yyyyMM"))
'            End If

'            lsArchivos = Directory.GetFiles(lsRuta, "*.*") 'Muevo los archivos para Log en Mes Año
'            For Each lsArchivo As String In lsArchivos
'                clsGen.Mover_Archivo(lsArchivo, lsRuta & "\" & Today.ToString("yyyyMM") & "\" & lsArchivo.Split("\").GetValue(lsArchivo.Split("\").LongLength - 1))
'            Next

'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub moverArchivosFACEEspecifico(psEmpresa As String, ByRef psTipo As String, psArchivo As String)

'        Dim clsGen As New ClasesGenerales.General
'        Try
'            Dim lsRuta As String = "C:\aplicaciones\Guatefacturas " & psTipo & "\" & psEmpresa

'            If Not Directory.Exists(lsRuta & "\" & Today.ToString("yyyyMM")) Then 'Si No Existe el Archivo Años Mes lo Creo
'                System.IO.Directory.CreateDirectory(lsRuta & "\" & Today.ToString("yyyyMM"))
'            End If

'            'Muevo El Archivo Especifico
'            clsGen.Mover_Archivo(psArchivo, lsRuta & "\" & Today.ToString("yyyyMM") & "\" & psArchivo.Split("\").GetValue(psArchivo.Split("\").LongLength - 1))


'        Catch ex As Exception
'        Finally
'            clsGen = Nothing
'        End Try
'    End Sub

'    'Obtiene Informacion Procesada en GuateFacturas
'    Private Sub obtenerProcesadosGuateFacturas(ByRef psEmpresa As String)
'        Dim lsRutaArchivos As String
'        Dim ClsGen As New ClasesGenerales.General


'        lsRutaArchivos = "C:\Aplicaciones\Guatefacturas Receive\" & psEmpresa
'        'lsRutaArchivos = "C:\Aplicaciones"
'        Dim sarchivos As String()

'        ClsGen.Escribir_Log("Obtener Procesados Guatefacturas " & psEmpresa)


'        Dim otabla As DataTable
'        Dim otrans As New Transaccional.Conexion_mysql("onBase")
'        Dim lb_regresa As Boolean = False


'        otrans.open()
'        otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('face_" & psEmpresa.ToLower & "')") 'Obtengo los parametros deacuerdo a la empresa
'        otrans.close()
'        otrans = Nothing

'        Dim ff As New FTP.clsFTP
'        With otabla.Rows(0)
'            ff.RemoteHost = .Item("host")
'            ff.RemoteUser = .Item("usuario")
'            ff.RemotePassword = .Item("password")
'        End With


'        Try


'            If (ff.Login()) Then
'                ff.ChangeDirectory("Archivos_XML_CAE") 'Directorio en donde estan los archivos procesados
'                '    ' ff.ChangeDirectory("Download")
'                ff.SetBinaryMode(True)


'                sarchivos = ff.GetFileList("*.zip") 'Obtengo todos los archivo ZIP
'                For icount As Integer = 0 To sarchivos.Length - 1
'                    If sarchivos(icount).ToLower.IndexOf("zip") > 0 And Not sarchivos(icount).ToLower.StartsWith("_") Then
'                        ff.DownloadFile(sarchivos(icount).Trim, lsRutaArchivos & "\" & sarchivos(icount).Trim)
'                        ff.RenameFile(sarchivos(icount).Trim, "_" & sarchivos(icount).Trim.Replace("zip", "pro")) 'Renombro los archivos para no volverlos a bajar y que la extension sea diferente para que no hayan muchos
'                    End If
'                Next
'            End If ''Existe Archivo .txt

'        Catch ex As System.Exception            '        
'        Finally
'            ff.CloseConnection()
'            ff = Nothing
'            ClsGen = Nothing
'        End Try


'    End Sub


'    Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
'       ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
'       ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean, _
'       ByVal _nombre_archivo As String, ByVal mostrarError As Boolean, ByVal nCopias As Integer, ByVal psEmpresa As String, _
'       ByVal psImpresora As String) As Boolean
'        Dim valorRegreso As Boolean = True

'        Dim Oaut As New Automatizar.Reportes_CraxDrt(psEmpresa)
'        If _nombre_archivo.Length > 0 Then
'            Oaut.Archivo_Generado = _nombre_archivo
'        End If
'        Oaut.pnNumeroCopias = nCopias

'        If psImpresora.Length > 0 Then
'            Oaut.psImpresora = psImpresora.Split(",")(0)
'            Oaut.psPort = psImpresora.Split(",")(1)
'        End If

'        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)

'        If Oaut.Descripcion_Error.Length > 0 Then
'            If mostrarError Then
'                Dim clsGen As New ClasesGenerales.General
'                guardarAviso("Problemas al Imprimir " & pm_valores(1) & " " & pm_valores(2) & " " & Oaut.Descripcion_Error)
'                clsGen.Escribir_Log("Reporte Generico Clase " & Oaut.Descripcion_Error)
'                clsGen = Nothing
'            Else
'                Dim clsGen As New ClasesGenerales.General
'                'guardarAviso("Problemas al Imprimir " & pm_valores(1) & " " & pm_valores(2) & " " & Oaut.Descripcion_Error)
'                clsGen.Escribir_Log("Reporte Generico Clase " & Oaut.Descripcion_Error)
'                clsGen = Nothing
'            End If
'            valorRegreso = False
'        End If

'        Oaut.finalizar()
'        Oaut = Nothing
'        GC.Collect()
'        Return valorRegreso
'    End Function


'    ''Todo los problemas que existan se genera un Aviso con el Codigo 31
'    Private Sub guardarAviso(ByVal psComentario As String)


'        Dim clsgen As New ClasesGenerales.General
'        Dim dtAvisos As DataTable
'        Dim iidAviso As Integer = 31
'        dtAvisos = clsgen.usuariosAviso(iidAviso)
'        For Each dr As DataRow In dtAvisos.Rows
'            clsgen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Factura Electronica FTP " & _
'                                psComentario, iidAviso)

'        Next
'        clsgen = Nothing
'    End Sub


'    Private Sub LimpiarProcesadosGuateFacturas(ByRef psEmpresa As String)
'        Dim lsRutaArchivos As String
'        Dim ClsGen As New ClasesGenerales.General

'        Try

'            lsRutaArchivos = "C:\Aplicaciones\LOG\" & psEmpresa & "\" & Today.ToString("yyyyMM")
'            'lsRutaArchivos = "C:\Aplicaciones"
'            Dim sarchivos As String()

'            ClsGen.Escribir_Log("Limpiar Procesados Guatefacturas " & psEmpresa)


'            Dim otabla As DataTable
'            Dim otrans As New Transaccional.Conexion_mysql("onBase")
'            Dim lb_regresa As Boolean = False


'            otrans.open()
'            otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('face_" & psEmpresa.ToLower & "')") 'Obtengo los parametros deacuerdo a la empresa
'            otrans.close()
'            otrans = Nothing

'            Dim ff As New FTP.clsFTP
'            With otabla.Rows(0)
'                ff.RemoteHost = .Item("host")
'                ff.RemoteUser = .Item("usuario")
'                ff.RemotePassword = .Item("password")
'            End With


'            Try


'                If (ff.Login()) Then
'                    ClsGen.Escribir_Log("Limpiar Procesados Login")
'                    ff.ChangeDirectory("Archivos_XML_CAE") 'Directorio en donde estan los archivos procesados
'                    '    ' ff.ChangeDirectory("Download")
'                    ff.SetBinaryMode(True)


'                    sarchivos = ff.GetFileList("*.*") 'Obtengo todos los archivo ZIP
'                    ClsGen.Escribir_Log("Archivos Log " & sarchivos.Length)
'                    For icount As Integer = 0 To sarchivos.Length - 1
'                        If sarchivos(icount).ToLower.IndexOf("pro") > 0 Then 'And Not sarchivos(icount).ToLower.StartsWith("_") Then
'                            ClsGen.Escribir_Log("DownLoad " & lsRutaArchivos & "\" & sarchivos(icount).Trim)
'                            ff.DownloadFile(sarchivos(icount).Trim, lsRutaArchivos & "\" & sarchivos(icount).Trim)
'                            'ff.RenameFile(sarchivos(icount).Trim, "_" & sarchivos(icount).Trim.Replace("zip", "pro")) 'Renombro los archivos para no volverlos a bajar y que la extension sea diferente para que no hayan muchos
'                            ff.DeleteFile(sarchivos(icount).Trim)

'                        End If
'                    Next
'                End If ''Existe Archivo .txt

'            Catch ex As System.Exception            '        
'                ClsGen.Escribir_Log("Limpiar Procesados " & psEmpresa & " Login" & ex.ToString)
'            Finally
'                ff.CloseConnection()
'                ff = Nothing
'                ClsGen = Nothing
'            End Try

'        Catch ex As Exception
'            ClsGen.Escribir_Log("Limpiar Procesados " & psEmpresa & " " & ex.ToString)
'        Finally

'        End Try

'    End Sub

'End Class

Public Class guateFacturasXML
    Dim gsEmpresa As String

    Public Sub New(ByVal psEmpresa As String)
        gsEmpresa = psEmpresa
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
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String))) '(c)20180105 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("moneda", GetType(String))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("tasa", GetType(Double))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("UsuarioModif", GetType(String))) '(c)20190117
        dt.Columns.Add(New DataColumn("F_FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("F_SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Analisis17", GetType(String)))
        dt.Columns.Add(New DataColumn("LisPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("SerieFace", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroAutFace", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaFace", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("NoAutFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NoSerieFel", GetType(String)))

        odsFACE.Tables.Add(dt)

        ' Me.dgv_pedidosFACE.DataSource = odsFACE.Tables("pedidos")

    End Sub

    'Genera la Informacion pa el Envio a GuateFacturas con la Estructura de GuateFacturas

    Private Sub send_procesarInformacionFACE(ByRef psEmpresa As String, ByRef psfecha As Date, ByRef odsFACE As DataSet)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim linea As String = String.Empty
        Dim tipo_documento As String = String.Empty
        Dim scodigoDocumento As String = String.Empty
        Dim lsNombreArchivo, lsNombreCompleto As String
        Dim sdirectorio As String = "C"

        Dim ClsGen As New ClasesGenerales.General
        Dim lexito As Boolean
        Dim importe_total, importe_bruto, importe_neto As Double
        Dim importe_iva, importe_descuento, impdist As Double

        Dim i As Integer = 0
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim reemplazar As Boolean = True
        Dim vigencia As String = String.Empty
        Dim exento, dvalorPorcentajeDR1 As Double

        Dim IMPORT_BRUTO As Double = 0.0
        Dim IMPORT_NETO As Double = 0.0
        Dim IMPORT_IVA As Double = 0.0
        Dim IMPORT_TOTAL As Double = 0.0
        Dim nLineas As Integer = 0
        Dim lsRutaArchivos As String
        Dim lbProcesar As Boolean = True 'Para Enviar Archivo
        Dim lsLote As String = Now.ToString("HHmmss")
        Try



            lsRutaArchivos = sdirectorio & ":\aplicaciones\Guatefacturas Send\" & psEmpresa

            lsNombreArchivo = "3591-" & lsLote & "-" &
                             Today.ToString("yyyyMMdd").Replace("/", "") & ".txt"

            lsNombreCompleto = lsRutaArchivos & "\" & lsNombreArchivo

            'ClsGen.Escribir_Log("Cargado Informacion " & lsNombreCompleto)
            Otrans.open()

            If reemplazar Then

                odsFACE.Tables("pedidos").DefaultView.RowFilter = ""

                For Each drv As DataRowView In odsFACE.Tables("pedidos").DefaultView

                    '                    If drv.Item("vigencia") = "S" Then

                    tipo_documento = "FACE"
                    scodigoDocumento = "63"
                    If drv.Item("documento").ToString = "Factura" Then
                        tipo_documento = "FACE"
                        scodigoDocumento = "63"
                    ElseIf drv.Item("documento").ToString = "Credito" Then
                        tipo_documento = "NCE"
                        scodigoDocumento = "64"
                    End If


                    If drv.Item("serie").ToString.Trim = "" Then
                        If drv.Item("vigencia").ToString = "S" Then 'Or drv.Item("vigencia").ToString = "N" Then
                            '  If drv.Item("enviar") = True Then 'Or drv.Item("vigencia").ToString = "N" Then

                            'Cuando es Factura Electronica Pura por medio de FTP lleva otra informacion 22/11/2013
                            linea = "1|"
                            linea += "1|" 'Establecimiento que emite el documento (
                            'linea += "1|" 'Numero de maquina que emite el documento
                            linea += drv.Item("maquinaFace") & "|"
                            'linea += "63|" 'Codigo de Documento SAT a cargar 63= Factura Electronica Pura
                            linea += scodigoDocumento & "|" 'Codigo de Documento SAT a cargar 63= Factura Electronica Pura

                            linea += Date.Parse(Today.ToString).ToString("yyyyMMdd") & "|" ' & tipo_documento & "|"
                            linea += drv.Item("codlegal").ToString & "|1|1|"
                            linea += drv.Item("TipoDoctoOrigen").ToString & "-" & drv.Item("numero").ToString & "|" 'Numero de Referencia Para No Duplicar
                            linea += "B|1|N|"
                            linea += drv.Item("nombre_cliente").ToString.Replace("|", " ") & "|"
                            linea += drv.Item("direccion").ToString.Replace("|", " ")
                            If drv.Item("codlegal").ToString = "7378106" Then
                                linea += "|Vendor 010085261  " '& Me.txtNumero.Text '& drv.Item("numero").ToString
                            Else
                                linea += "|Pedido " & drv.Item("numero").ToString
                            End If

                            If drv.Item("codlegal").ToString = "7378106" Then 'Numero de Orden
                                '       linea += "|" & Me.txtNumeroOC.Text '& drv.Item("numero_pedidoWM").ToString
                                linea += "|"
                            Else
                                linea += "|"
                            End If
                            If drv.Item("codlegal").ToString = "7378106" Then
                                '      linea += "|" + Me.txtNumeroOCRecepcionWM.Text
                                linea += "|"
                            Else
                                linea += "|"
                            End If
                            linea += "|Bodega " & drv.Item("Bodega").ToString.Trim & "   Agente: " & drv.Item("vendedor").ToString.Trim
                            linea += "|" & drv.Item("comentario").ToString.Trim.Replace(Chr(13), " ")



                            'drv.Item("numero").ToString.Trim & ".txt"

                            'If drv.Item("documento").ToString = "Factura" And entro = False Then
                            If entro = False Then
                                If Directory.Exists(lsRutaArchivos) Then
                                    Try
                                        System.IO.File.Delete(lsNombreArchivo)
                                        entro = True
                                    Catch ex As Exception
                                        ClsGen.Escribir_Log(ex.ToString)
                                    End Try
                                Else
                                    Try
                                        System.IO.Directory.CreateDirectory(lsRutaArchivos)
                                        entro = True
                                    Catch ex As Exception
                                        ClsGen.Escribir_Log(ex.ToString & "  " & lsRutaArchivos)
                                    End Try
                                End If
                            End If

                            lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)

                            odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString &
                                                                        "' and tipodocto  = '" &
                                                                       drv.Item("tipodocto").ToString &
                                                                       "' and empresa = '" & drv.Item("empresa").ToString & "'"


                            If drv.Item("documento").ToString.Trim <> "Debito" Then
                                importe_total = 0
                                importe_bruto = 0
                                importe_neto = 0
                                importe_iva = 0
                                dvalorPorcentajeDR1 = 0
                                importe_descuento = 0

                                For Each drvD As DataRowView In odsFACE.Tables("detalle_pedidos").DefaultView
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|" & drvD.Item("cantidad") & "|1|"
                                    '4.PRECIO
                                    linea += drvD.Item("Precio") & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

                                        If drvD.Item("PorcentajeDR") <> 0 Then
                                            '5.PORCENTAJE_DESCUENTO 
                                            linea += drvD.Item("PorcentajeDR") * -1 & "|"
                                            dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
                                        Else
                                            '5.PORCENTAJE_DESCUENTO 
                                            dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
                                            linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        End If

                                        '6.IMPORTE_DESCUENTO
                                        linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
                                        '7.IMPORTE_BRUTO
                                        linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"
                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        'SI NO HAY DESCUENTO
                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                        linea += "0|0|"
                                        '7.IMPORTE_BRUTO
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                        linea += IMPORT_BRUTO & "|"
                                        importe_bruto += IMPORT_BRUTO
                                    End If

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                    If drv.Item("exento").ToString.ToLower = "si" Then
                                        exento = IMPORT_BRUTO
                                        '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
                                        linea += exento & "|0|0|0|"
                                        IMPORT_TOTAL = exento
                                        linea += IMPORT_TOTAL & "|"
                                    Else
                                        '8.IMPORTE_EXENTO 
                                        linea += "0|"
                                        '9.IMPORTE_NETO
                                        IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                        linea += IMPORT_NETO & "|"
                                        '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                        IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                        linea += IMPORT_IVA & "|0|"

                                        '12.IMPORTE_TOTAL
                                        IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                        linea += IMPORT_TOTAL & "|"
                                    End If

                                    '13.PRODUCTO       14.DESCRIPCION
                                    linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("documento").ToString = "Factura" Or
                                        drv.Item("documento").ToString = "Credito" Then

                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            'linea += "0.00|0.00"
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += "0.00"
                                        Else
                                            '15.IMPUESTO_DISTRIBUCION
                                            linea += Math.Round(drvD.Item("Impdist"), 2).ToString
                                        End If
                                        '16.PRECIO_SUGERIDO
                                        linea += "|" & drvD.Item("psugerido").ToString

                                        If drvD.Item("volumen").ToString.Length > 0 Then
                                            '17.VOLUMEN
                                            linea += "|" & drvD.Item("volumen").ToString
                                        Else
                                            '17.VOLUMEN
                                            linea += "|" & 0
                                        End If
                                    End If

                                    impdist = 0

                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                Next '' Detalle de Pedidos

                                nLineas = odsFACE.Tables("detalle_pedidos").DefaultView.Count
                                ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
                                ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
                                If drv.Item("porcDescuento") > 0 Then
                                    ls_sql = "pa_var_um_documentov '" & psEmpresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"

                                    Dim drv2 As DataRowView = dt.DefaultView(0)
                                    dvalorPorcentajeDR1 = 0
                                    IMPORT_BRUTO = 0
                                    IMPORT_NETO = 0
                                    IMPORT_IVA = 0
                                    IMPORT_TOTAL = 0

                                    Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

                                    linea = ""
                                    '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                    linea = "2|1|1|"
                                    '4.PRECIO
                                    linea += dMonto & "|"

                                    'VERIFICA SI HAY DESCUENTO   
                                    'SI NO HAY DESCUENTO
                                    '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                    linea += "0|0|"
                                    '7.IMPORTE_BRUTO
                                    IMPORT_BRUTO = dMonto
                                    linea += IMPORT_BRUTO & "|"
                                    importe_bruto += IMPORT_BRUTO

                                    'VERIFICA SI HAY IMPORTE EXENTO
                                    '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                    'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

                                    '8.IMPORTE_EXENTO 
                                    linea += "0|"
                                    '9.IMPORTE_NETO
                                    IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
                                    linea += IMPORT_NETO & "|"
                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                    linea += IMPORT_IVA & "|0|"

                                    '12.IMPORTE_TOTAL
                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                    linea += IMPORT_TOTAL & "|"

                                    '13.PRODUCTO       14.DESCRIPCION
                                    'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        linea += "0000000002|DESCUENTO POR CENTRALIZACION|"
                                    Else
                                        linea += "0000000001|DESCUENTOS GLOBALES|"
                                    End If


                                    'linea += "0.00|0.00"
                                    '15.IMPUESTO_DISTRIBUCION
                                    linea += "0.00"

                                    '16.PRECIO_SUGERIDO
                                    linea += "|0"

                                    '17.VOLUMEN
                                    linea += "|0"

                                    impdist = 0
                                    importe_total += IMPORT_TOTAL
                                    importe_neto += IMPORT_NETO
                                    importe_iva += IMPORT_IVA
                                    importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                    nLineas += 1
                                End If ''Descuento Global



                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    If drv.Item("Refnumero").ToString.Trim.Length = 12 Then

                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|FACE|" & drv.Item("RefTipoDocto").ToString & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")

                                        Catch ex As Exception

                                        End Try
                                    Else

                                        ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString &
                                                    "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                        dt = Otrans.Obtiene(ls_sql)

                                        Try
                                            linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto4") & "-" & dt.Rows(0).Item("texto1") & "|" &
                                                    drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")
                                        Catch ex As Exception
                                        End Try

                                    End If
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)

                                End If

                                If drv.Item("documento").ToString = "Factura" Then
                                    If Math.Abs(importe_total - drv.Item("total")) > 0.1 Then
                                        'MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                        ClsGen.Escribir_Log("**** Problemas con Los Totales en " & drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & "','" & drv.Item("numero") & "'")
                                        lbProcesar = False
                                    Else
                                        linea = ""
                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
                                        linea += Math.Round(importe_descuento, 2) & "|"
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
                                        Else
                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
                                        End If
                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                            nLineas & "|0"

                                        Dim lsSQL As String = "pa_ins_um_gen_log_documento_face '" &
                                            drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") &
                                            "','" & drv.Item("numero") & "','" & lsLote & "'"
                                        Otrans.Ingresa(lsSQL)
                                        If Otrans.Codigo_error = 0 Then
                                            lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                            drv.Item("procesado") = 1
                                        End If
                                    End If
                                End If '' Factura
                                If drv.Item("documento").ToString = "Credito" Then
                                    linea = ""
                                    linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                    nLineas & "|" & dt.Rows.Count
                                    Dim lsSQL As String = "pa_ins_um_gen_log_documento_face '" &
                                        drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") &
                                        "','" & drv.Item("numero") & "','" & lsLote & "'"

                                    Otrans.Ingresa(lsSQL)
                                    If Otrans.Codigo_error = 0 Then
                                        lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                        drv.Item("procesado") = 1
                                    End If

                                End If
                            End If
                        End If 'drv.Item("vigencia").ToString = "S"
                    End If 'Serie Vacia
                    ' End If 'Pedido Enviar
                Next

                If File.Exists(lsNombreCompleto) Then
                    If lbProcesar Then
                        ClsGen.Comprimir_Archivo(lsRutaArchivos, lsNombreArchivo, lsRutaArchivos & "\", lsNombreArchivo.Replace("txt", "zip"))
                        ClsGen.Comprimir_Archivo(lsRutaArchivos, "1.txt", lsRutaArchivos & "\", lsNombreArchivo.Replace(".txt", "-OK.zip"))
                        Dim lsArchivos As String() = Directory.GetFiles(lsRutaArchivos, "*.zip")

                        'If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                        Dim iArchivosSincronizados As String = 0

                        For Each lsarchivo As String In lsArchivos
                            If lsarchivo.IndexOf("-OK") = -1 Then ' And lsarchivo.Trim.Length > 0 Then
                                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                                    iArchivosSincronizados = 1
                                End If
                            End If
                        Next


                        For Each lsarchivo As String In lsArchivos
                            If lsarchivo.IndexOf("-OK") <> 1 Then 'And lsarchivo.Trim.Length > 0 Then
                                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                                    iArchivosSincronizados += 1
                                End If
                            End If
                        Next


                        ClsGen.Escribir_Log("Archivos Sincronizados " & iArchivosSincronizados.ToString)
                        If iArchivosSincronizados >= 2 Then
                            moverArchivosFACE(psEmpresa, "Send")
                        End If
                    Else 'Si No  se procesa Por que Alguno estaba Malo

                        ClsGen.Mover_Archivo(lsNombreCompleto, lsRutaArchivos & "\Err\" & lsNombreArchivo)
                        'Debo Regresar Los que fueron Procesados
                        odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
                        For Each dr As DataRow In odsFACE.Tables("pedidos").Rows
                            If dr.Item("procesado") = True Then
                                Dim lsSQL As String = "pa_del_um_gen_log_documento_face '" &
                                                dr.Item("Empresa") & "','" & dr.Item("tipoDoctoOrigen") & "','" & dr.Item("numero") & "'"
                                Otrans.Elimina(lsSQL)

                            End If
                        Next



                    End If
                End If 'Existe Archivo

            End If
        Catch ex As Exception
            ClsGen.Escribir_Log(" Fnal Send_ProcesarInformacion " & ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub


    Public Sub send_procesarInformacionFACEXML(ByRef psEmpresa As String, ByRef psfecha As Date, ByRef odsFACE As DataSet, _
                                                ByRef OdsXML As DataSet, drv As DataRowView, pdFechaFacturacion As Date)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Otrans.gsnombreLog = "log_" & psEmpresa
        Dim ls_sql As String
        Dim dt As DataTable
        Dim linea As String = String.Empty
        Dim tipo_documento As String = String.Empty
        Dim scodigoDocumento As String = String.Empty
        Dim lsNombreArchivo, lsNombreCompleto As String
        Dim sdirectorio As String = "C"

        Dim ClsGen As New ClasesGenerales.General
        ClsGen.gsNombreInicialLog = "log_" & psEmpresa
        Dim lexito As Boolean
        Dim importe_total, importe_bruto, importe_neto As Double
        Dim importe_iva, importe_descuento, impdist As Double

        Dim i As Integer = 0
        Dim entro As Boolean = False
        Dim entro_d As Boolean = False
        Dim entro_c As Boolean = False
        Dim reemplazar As Boolean = True
        Dim vigencia As String = String.Empty
        Dim exento, dvalorPorcentajeDR1 As Double

        Dim IMPORT_BRUTO As Double = 0.0
        Dim IMPORT_NETO As Double = 0.0
        Dim IMPORT_IVA As Double = 0.0
        Dim IMPORT_TOTAL As Double = 0.0
        Dim nLineas As Integer = 0
        Dim lsRutaArchivos As String
        Dim lbProcesar As Boolean = True 'Para Enviar Archivo
        Dim lsLote As String = Now.ToString("HHmmss")

        Dim dtmyPedido As DataTable
        Dim dtmyEdiEncabezado As DataTable
        Dim dtmyDetalle As DataTable


        Dim lsSQL As String

        Try


            OdsXML.ReadXml("C:\Aplicaciones\formato\XMLGuatefacturasWalmart.xml")




            OdsXML.Tables("Receptor").Rows.Clear()
            OdsXML.Tables("InfoDoc").Rows.Clear()
            OdsXML.Tables("Totales").Rows.Clear()
            OdsXML.Tables("DocAsociados").Rows.Clear()
            OdsXML.Tables("Encabezado").Rows.Clear()
            OdsXML.Tables("Productos").Rows.Clear()

            Otrans.open()

            If reemplazar Then

                tipo_documento = "FACE"
                scodigoDocumento = "63"
                If drv.Item("documento").ToString = "Factura" Then
                    tipo_documento = "FACE"
                    scodigoDocumento = "63"
                ElseIf drv.Item("documento").ToString = "Credito" Then
                    tipo_documento = "NCE"
                    scodigoDocumento = "64"
                End If


                If drv.Item("serie").ToString.Trim = "" Then
                    If drv.Item("vigencia").ToString = "S" Then 'Agregarlo al proceso en vivo

                        Dim drReceptor As DataRow = OdsXML.Tables("Receptor").NewRow
                        drReceptor.Item("NitReceptor") = drv.Item("codlegal").ToString
                        drReceptor.Item("Nombre") = drv.Item("nombre_cliente").ToString.Replace("|", " ")
                        drReceptor.Item("Direccion") = drv.Item("direccion").ToString.Replace("|", " ")
                        OdsXML.Tables("Receptor").Rows.Add(drReceptor)

                        Dim drInfoDocto As DataRow = OdsXML.Tables("Infodoc").NewRow
                        drInfoDocto.Item("TipoVenta") = drv.Item("TipoVenta") ''Bienes
                        'drInfoDocto.Item("TipoVenta") = "B" ''Bienes
                        drInfoDocto.Item("DestinoVenta") = "1" 'Guatemala
                        drInfoDocto.Item("Fecha") = Date.Parse(Today.ToString).ToString("dd/MM/yyyy") 'Fecha del Documento
                        '(c) 20151102 Facturacion con Fecha De Cierre
                        drInfoDocto.Item("Fecha") = Date.Parse(pdFechaFacturacion.ToString).ToString("dd/MM/yyyy")

                        '(c) 20180116 Validar para LGS
                        drInfoDocto.Item("Moneda") = drv.Item("Moneda") '1 = GTQ
                        drInfoDocto.Item("Tasa") = drv.Item("Tasa") '1 Cuando es GTQ
                        drInfoDocto.Item("Referencia") = drv.Item("TipoDoctoOrigen").ToString & "-" & drv.Item("numero").ToString 'Numero de Referencia Para No Duplicar
                        OdsXML.Tables("Infodoc").Rows.Add(drInfoDocto)

                        'Cuando es Factura Electronica Pura por medio de FTP lleva otra informacion 22/11/2013

                        Dim drEncabezado As DataRow = OdsXML.Tables("Encabezado").NewRow

                        If drv.Item("codlegal").ToString = "7378106" Then
                            drEncabezado.Item("Numero") = "Vendor 010085261  "
                        Else
                            'linea += "|Pedido " & drv.Item("numero").ToString
                            drEncabezado.Item("Numero") = "Pedido " & drv.Item("numero").ToString
                        End If

                        drEncabezado.Item("Condiciones") = "Bodega " & drv.Item("Bodega").ToString.Trim & "   Agente: " & drv.Item("vendedor").ToString.Trim
                        drEncabezado.Item("Observaciones") = drv.Item("comentario").ToString.Trim.Replace(Chr(13), " ")

                        drEncabezado.Item("Numero_Orden") = String.Empty
                        drEncabezado.Item("Numero_Recepcion") = String.Empty


                        ''Datos Adicionales Walmart
                        ''Informacion Almacenada en mySQL


                        Dim dtDocumentoPrevio As DataTable
                        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

                        Try
                            myOtrans.open()


                            lsSQL = "pa_var_um_documento_previo '" & drv.Item("empresa").ToString & "','" & drv.Item("tipodocto").ToString & "','" & drv.Item("numero").ToString & "'"
                            dtDocumentoPrevio = ClsGen.selectQuery("FlexLine", lsSQL)

                            If drv.Item("tipodocto") = "PEDIDO FACE RE" Or drv.Item("tipodocto") = "PEDIDO CONSOLIDADO" Then
                                Dim iCount As Integer = 0
                                While True
                                    Try

                                        lsSQL = "pa_var_um_documento_previo '" & drv.Item("empresa").ToString & "','" & _
                                                dtDocumentoPrevio.Rows(0).Item("tipodocto") & "','" & dtDocumentoPrevio.Rows(0).Item("numero") & "'"
                                        dtDocumentoPrevio = ClsGen.selectQuery("FlexLine", lsSQL)
                                        If iCount > 5 Or dtDocumentoPrevio.Rows(0).Item("tipodocto").ToString.ToLower.StartsWith("pedido al") Then
                                            Exit While
                                        End If
                                        iCount = +1
                                    Catch ex As Exception
                                        Exit While
                                    End Try

                                End While
                            End If


                            Try
                                lsSQL = "call pa_var_um_mov_pedidos_encabezado_numeroflex ('" & drv.Item("empresa").ToString & "','" & _
                                        dtDocumentoPrevio.Rows(0).Item("tipodocto") & "','" & dtDocumentoPrevio.Rows(0).Item("numero") & "')"
                                dtmyPedido = myOtrans.Obtiene(lsSQL)


                                If dtmyPedido.Rows.Count > 0 Then
                                    If dtmyPedido.Rows(0).Item("gln").ToString.Trim.Length > 0 Then

                                        ''Debo Ir a traer el encabezado para el CodProv

                                        lsSQL = "call pa_var_um_edi_pedido_encabezado ('" & psEmpresa & "','" & dtmyPedido.Rows(0).Item("numero_pedido").ToString & "','" & _
                                                    dtmyPedido.Rows(0).Item("gln").ToString & "')"
                                        dtmyEdiEncabezado = myOtrans.Obtiene(lsSQL)

                                        drEncabezado.Item("codProv") = dtmyEdiEncabezado.Rows(0).Item("idempresalocalproveedor").ToString.PadLeft(9, "0")

                                        drEncabezado.Item("Numero") = "Vendor  " & dtmyEdiEncabezado.Rows(0).Item("idempresalocalproveedor").ToString.PadLeft(9, "0")
                                        'If psEmpresa = "CODICASA" Then
                                        '    drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA
                                        'ElseIf psEmpresa = "DMARTE1" Then
                                        '    drEncabezado.Item("codProv") = "010244261" 'Codigo de DM
                                        'ElseIf psEmpresa = "DIUVA" Then
                                        '    drEncabezado.Item("codProv") = "016783261" 'Codigo de DIUVA
                                        'End If
                                        drEncabezado.Item("gln") = dtmyPedido.Rows(0).Item("gln")
                                        drEncabezado.Item("city") = drv.Item("Comuna").ToString
                                        drEncabezado.Item("state") = drv.Item("Estado").ToString
                                        drEncabezado.Item("streetAddress") = drv.Item("Direccion").ToString
                                        drEncabezado.Item("NoPedido") = dtmyPedido.Rows(0).Item("numero_pedido")
                                        drEncabezado.Item("CodRecepcion") = IIf(drv.Item("Numero_Recepcion_Walmart").ToString.Length > 0, drv.Item("Numero_Recepcion_Walmart").ToString, "2803120099").ToString.Replace(dtmyPedido.Rows(0).Item("numero_pedido").ToString, "")

                                        If drv.Item("tipodocto") = "PEDIDO FACE RE" Then
                                            drEncabezado.Item("CodRecepcion") = drEncabezado.Item("Observaciones").ToString.ToLower.Substring(
                                                                     drEncabezado.Item("Observaciones").ToString.ToLower.IndexOf("rec") + 4).Trim.Replace("-", "")
                                        End If

                                        drEncabezado.Item("Numero_Orden") = dtmyPedido.Rows(0).Item("numero_pedido")
                                        drEncabezado.Item("Numero_Recepcion") = drEncabezado.Item("CodRecepcion")

                                        drEncabezado.Item("Descuento") = 0

                                        lsSQL = "call pa_sel_um_mov_pedidos_detalle_walmart (" & dtmyPedido.Rows(0).Item("cod_pedido") & ")"
                                        dtmyDetalle = myOtrans.Obtiene(lsSQL)


                                    ElseIf drv.Item("codlegal").ToString = "7378106" Then 'Si No encontro Informacion pero es walmart
                                        'drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA

                                        If psEmpresa = "CODICASA" Then
                                            drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA
                                        ElseIf psEmpresa = "DMARTE1" Then
                                            drEncabezado.Item("codProv") = "010244261" 'Codigo de CODICASA
                                        ElseIf psEmpresa = "DIUVA" Then
                                            drEncabezado.Item("codProv") = "016783261" 'Codigo de DIUVA
                                        End If
                                        drEncabezado.Item("gln") = "7407001008593" 'dtmyPedido.Rows(0).Item("gln")
                                        drEncabezado.Item("city") = drv.Item("Comuna").ToString
                                        drEncabezado.Item("state") = drv.Item("Estado").ToString
                                        drEncabezado.Item("streetAddress") = drv.Item("Direccion").ToString
                                        drEncabezado.Item("NoPedido") = "2803120099" 'dtmyPedido.Rows(0).Item("numero_pedido")
                                        drEncabezado.Item("CodRecepcion") = IIf(drv.Item("Numero_Recepcion_Walmart").ToString.Length > 0, drv.Item("Numero_Recepcion_Walmart").ToString, "2803120099")

                                        If drv.Item("tipodocto") = "PEDIDO FACE RE" Then
                                            drEncabezado.Item("CodRecepcion") = drEncabezado.Item("Observaciones").ToString.ToLower.Substring( _
                                                                     drEncabezado.Item("Observaciones").ToString.ToLower.IndexOf("rec") + 4).Trim.Replace("-", "")
                                        End If
                                        drEncabezado.Item("Descuento") = 0
                                    End If
                                End If
                            Catch ex As Exception
                                If drv.Item("codlegal").ToString = "7378106" Then 'Si No encontro Informacion pero es walmart
                                    'drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA

                                    If psEmpresa = "CODICASA" Then
                                        drEncabezado.Item("codProv") = "010085261" 'Codigo de CODICASA
                                    ElseIf psEmpresa = "DMARTE1" Then
                                        drEncabezado.Item("codProv") = "010244261" 'Codigo de CODICASA
                                    ElseIf psEmpresa = "DIUVA" Then
                                        drEncabezado.Item("codProv") = "016783261" 'Codigo de DIUVA
                                    End If
                                    drEncabezado.Item("gln") = "7407001008593" 'dtmyPedido.Rows(0).Item("gln")
                                    drEncabezado.Item("city") = drv.Item("Comuna").ToString
                                    drEncabezado.Item("state") = drv.Item("Estado").ToString
                                    drEncabezado.Item("streetAddress") = drv.Item("Direccion").ToString
                                    drEncabezado.Item("NoPedido") = "2803120099" 'dtmyPedido.Rows(0).Item("numero_pedido")
                                    drEncabezado.Item("CodRecepcion") = IIf(drv.Item("Numero_Recepcion_Walmart").ToString.Length > 0, drv.Item("Numero_Recepcion_Walmart").ToString, "2803120099")

                                    If drv.Item("tipodocto") = "PEDIDO FACE RE" Then
                                        drEncabezado.Item("CodRecepcion") = drEncabezado.Item("Observaciones").ToString.ToLower.Substring( _
                                                                 drEncabezado.Item("Observaciones").ToString.ToLower.IndexOf("rec") + 4).Trim.Replace("-", "")
                                    End If
                                    drEncabezado.Item("Descuento") = 0
                                End If
                            End Try

                        Catch ex As Exception
                            ClsGen.Escribir_Log(ex.Message)
                        Finally
                            myOtrans.close()
                            myOtrans = Nothing

                        End Try

                        OdsXML.Tables("Encabezado").Rows.Add(drEncabezado)


                        odsFACE.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & drv.Item("numero").ToString & _
                                                                    "' and tipodocto  = '" & _
                                                                   drv.Item("tipodocto").ToString & _
                                                                   "' and empresa = '" & drv.Item("empresa").ToString & "'"


                        If drv.Item("documento").ToString.Trim <> "Debito" Then
                            importe_total = 0
                            importe_bruto = 0
                            importe_neto = 0
                            importe_iva = 0
                            dvalorPorcentajeDR1 = 0
                            importe_descuento = 0

                            For Each drvD As DataRowView In odsFACE.Tables("detalle_pedidos").DefaultView
                                Dim drProducto As DataRow = OdsXML.Tables("Productos").NewRow

                                drProducto.Item("Producto") = drvD.Item("producto").ToString
                                drProducto.Item("Descripcion") = drvD.Item("glosa").ToString.Replace("´", "")
                                If psEmpresa = "LOGISERV" Then '20180413 La descripcion debe llevar los comentarios
                                    drProducto.Item("Descripcion") = drProducto.Item("Descripcion") + vbLf + drvD("Comentario").ToString
                                End If
                                drProducto.Item("Medida") = 1
                                drProducto.Item("Cantidad") = drvD.Item("cantidad")


                                '20180117 facturacion en dolares
                                If drvD.Item("moneda").ToString.ToLower.StartsWith("quet") Then
                                    drProducto.Item("Precio") = drvD.Item("Precio")
                                Else

                                    drProducto.Item("Precio") = drvD.Item("PrecioIngreso")
                                End If


                                '20180409 comentarios

                                Try
                                    drProducto.Item("Comentario") = drvD.Item("comentario")
                                Catch ex As Exception

                                End Try


                                dvalorPorcentajeDR1 = 0
                                IMPORT_BRUTO = 0
                                IMPORT_NETO = 0
                                IMPORT_IVA = 0
                                IMPORT_TOTAL = 0

                                ''linea = ""
                                '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                ''linea = "2|" & drvD.Item("cantidad") & "|1|"
                                '4.PRECIO
                                ''linea += drvD.Item("Precio") & "|"

                                'VERIFICA SI HAY DESCUENTO   
                                If drvD.Item("PorcentajeDR") <> 0 Or Val(drvD.Item("ValPorcentajeDR1").ToString) <> 0 Then

                                    If drvD.Item("PorcentajeDR") <> 0 Then
                                        '5.PORCENTAJE_DESCUENTO 
                                        drProducto.Item("PorcDesc") = drvD.Item("PorcentajeDR") * -1
                                        linea += drvD.Item("PorcentajeDR") * -1 & "|"
                                        '(c) 20180117 se cambio para utilizar el valor ya asignado
                                        'dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)
                                        dvalorPorcentajeDR1 = Math.Round((drvD.Item("cantidad") * Math.Round(drProducto.Item("Precio"), 2)) * (drvD.Item("PorcentajeDR") / -100), 2)

                                    Else
                                        '5.PORCENTAJE_DESCUENTO 
                                        dvalorPorcentajeDR1 = drvD.Item("ValPorcentajeDR1")
                                        linea += Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        '(c) 20180117 se cambio para utilizar el valor ya asignado
                                        'drProducto.Item("PorcDesc") = Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drvD.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                        drProducto.Item("PorcDesc") = Math.Round(dvalorPorcentajeDR1 / (drvD.Item("cantidad") * Math.Round(drProducto.Item("Precio"), 2)) * 100, 2) & "|" '(drvD.Item("PorcentajeDR") * -1 & "|"
                                    End If

                                    '6.IMPORTE_DESCUENTO
                                    linea += Math.Round(dvalorPorcentajeDR1, 2) & "|"
                                    '7.IMPORTE_BRUTO
                                    linea += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2) & "|"


                                    '20180117 facturacion en dolares
                                    If drvD.Item("moneda").ToString.ToLower.StartsWith("quet") Then
                                        drProducto.Item("ImpBruto") = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        drProducto.Item("ImpBruto") = Math.Round(drvD.Item("subtotalIngreso") + dvalorPorcentajeDR1, 2)
                                    End If



                                    drProducto.Item("ImpDescuento") = Math.Round(dvalorPorcentajeDR1, 2)

                                    '20180117 facturacion en dolares
                                    If drvD.Item("moneda").ToString.ToLower.StartsWith("quet") Then
                                        importe_bruto += Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotal") + dvalorPorcentajeDR1, 2)
                                    Else
                                        importe_bruto += Math.Round(drvD.Item("subtotalIngreso") + dvalorPorcentajeDR1, 2)
                                        IMPORT_BRUTO = Math.Round(drvD.Item("subtotalIngreso") + dvalorPorcentajeDR1, 2)
                                    End If
                                Else
                                        'SI NO HAY DESCUENTO
                                        '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                        linea += "0|0|"
                                    '7.IMPORTE_BRUTO

                                    '20180117 facturacion en dolares
                                    If drvD.Item("moneda").ToString.ToLower.StartsWith("quet") Then
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                    Else
                                        IMPORT_BRUTO = Math.Round(drvD.Item("IMPORTE_BRUTO_INGRESO"), 2)
                                    End If

                                    drProducto.Item("PorcDesc") = 0
                                        drProducto.Item("ImpDescuento") = 0
                                        'drProducto.Item("ImpBruto") = Math.Round(drvD.Item("IMPORTE_BRUTO"), 2)
                                        drProducto.Item("ImpBruto") = Math.Round(IMPORT_BRUTO, 2)
                                        linea += IMPORT_BRUTO & "|"
                                        importe_bruto += IMPORT_BRUTO
                                    End If

                                'VERIFICA SI HAY IMPORTE EXENTO
                                '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                '20180117 facturacion en dolares
                                If drvD.Item("moneda").ToString.ToLower.StartsWith("quet") Then
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                Else
                                    IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO_INGRESO"), 2)
                                End If

                                If drv.Item("exento").ToString.ToLower = "si" Then
                                    exento = IMPORT_BRUTO
                                    '8.IMPORTE_EXENTO 9.IMPORTE_NETO  10.IMPORTE_IVA 11.IMPORTE_OTROS
                                    linea += exento & "|0|0|0|"
                                    IMPORT_TOTAL = exento
                                    linea += IMPORT_TOTAL & "|"
                                    drProducto.Item("ImpExento") = exento
                                    drProducto.Item("ImpOtros") = 0
                                    drProducto.Item("ImpNeto") = 0
                                    drProducto.Item("ImpIsr") = 0
                                    drProducto.Item("ImpIva") = 0
                                    drProducto.Item("ImpTotal") = IMPORT_TOTAL
                                Else
                                    '8.IMPORTE_EXENTO 
                                    linea += "0|"
                                    drProducto.Item("ImpExento") = 0
                                    drProducto.Item("ImpOtros") = 0
                                    '9.IMPORTE_NETO
                                    'IMPORT_NETO = Math.Round(drvD.Item("IMPORTE_NETO"), 2)
                                    linea += IMPORT_NETO & "|"
                                    drProducto.Item("ImpNeto") = IMPORT_NETO
                                    drProducto.Item("ImpIsr") = 0
                                    '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                    IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                    linea += IMPORT_IVA & "|0|"
                                    drProducto.Item("ImpIva") = IMPORT_IVA
                                    '12.IMPORTE_TOTAL
                                    IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                    linea += IMPORT_TOTAL & "|"
                                    drProducto.Item("ImpTotal") = IMPORT_TOTAL
                                End If


                                drProducto.Item("impuestodistribucion") = 0
                                drProducto.Item("preciosugerido") = 0
                                '13.PRODUCTO       14.DESCRIPCION
                                linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                If drv.Item("documento").ToString = "Factura" Or _
                                    drv.Item("documento").ToString = "Credito" Then

                                    If drv.Item("exento").ToString.ToLower = "si" Then
                                        'linea += "0.00|0.00"
                                        '15.IMPUESTO_DISTRIBUCION
                                        linea += "0.00"
                                    Else
                                        '15.IMPUESTO_DISTRIBUCION
                                        linea += Math.Round(drvD.Item("Impdist"), 2).ToString
                                        drProducto.Item("impuestodistribucion") = Math.Round(drvD.Item("Impdist"), 2)
                                    End If
                                    '16.PRECIO_SUGERIDO
                                    linea += "|" & drvD.Item("psugerido").ToString
                                    Try
                                        If drvD.Item("psugerido") > 0 Then
                                            drProducto.Item("preciosugerido") = drvD.Item("psugerido")
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    drProducto.Item("medida") = 0
                                    If drvD.Item("volumen").ToString.Length > 0 Then
                                        '17.VOLUMEN
                                        linea += "|" & drvD.Item("volumen").ToString
                                        drProducto.Item("medida") = drvD.Item("volumen").ToString
                                    Else
                                        '17.VOLUMEN
                                        linea += "|" & 0
                                    End If
                                End If


                                impdist = 0

                                importe_total += IMPORT_TOTAL
                                importe_neto += IMPORT_NETO
                                importe_iva += IMPORT_IVA
                                importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                'lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)


                                ''(c) 23032014
                                ''Datos Adicionales Walmart
                                ''Obtener del pedido en mysql


                                Try

                                    If dtmyDetalle.Rows.Count > 0 Then
                                        dtmyDetalle.DefaultView.RowFilter = "cod_producto_flex = '" & drProducto.Item("Producto").ToString & "'"
                                        If dtmyDetalle.DefaultView.Count > 0 Then
                                            If dtmyDetalle.DefaultView(0).Item("gtin").ToString.Trim.Length = 0 Then
                                                drProducto.Item("gtin") = "00014800000344"
                                                drProducto.Item("IdBuyer") = "070327006"
                                                drProducto.Item("IdU12") = ""
                                                drProducto.Item("IdU13") = "0014800000344"
                                                drProducto.Item("IdSupplier") = "200060191"
                                                drProducto.Item("UnitofMesure") = "EA"
                                            Else
                                                drProducto.Item("gtin") = dtmyDetalle.DefaultView(0).Item("gtin").ToString
                                                drProducto.Item("IdBuyer") = dtmyDetalle.DefaultView(0).Item("idBuyer").ToString
                                                drProducto.Item("IdU12") = dtmyDetalle.DefaultView(0).Item("IdU12").ToString
                                                drProducto.Item("IdU13") = dtmyDetalle.DefaultView(0).Item("IdU13").ToString
                                                drProducto.Item("IdSupplier") = dtmyDetalle.DefaultView(0).Item("IdSupplier").ToString
                                                drProducto.Item("UnitofMesure") = dtmyDetalle.DefaultView(0).Item("UnitofMesure").ToString
                                            End If
                                        End If
                                    ElseIf drv.Item("codlegal").ToString = "7378106" Then
                                        drProducto.Item("gtin") = "00014800000344"
                                        drProducto.Item("IdBuyer") = "070327006"
                                        drProducto.Item("IdU12") = ""
                                        drProducto.Item("IdU13") = "0014800000344"
                                        drProducto.Item("IdSupplier") = "200060191"
                                        drProducto.Item("UnitofMesure") = "EA"
                                    End If

                                Catch ex As Exception
                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        drProducto.Item("gtin") = "00014800000344"
                                        drProducto.Item("IdBuyer") = "070327006"
                                        drProducto.Item("IdU12") = ""
                                        drProducto.Item("IdU13") = "0014800000344"
                                        drProducto.Item("IdSupplier") = "200060191"
                                        drProducto.Item("UnitofMesure") = "EA"
                                    End If
                                End Try

                                OdsXML.Tables("Productos").Rows.Add(drProducto) ''Agrego el Registro

                            Next '' Detalle de Pedidos

                            nLineas = odsFACE.Tables("detalle_pedidos").DefaultView.Count
                            ''Descuentos Globales se Ingresaran como un producto adicional con precio negativo
                            ''(c) Reunin 16/05/2013 con Acamey, lsolis, orodriguez, xorellana
                            If drv.Item("porcDescuento") > 0 Then

                                ls_sql = "pa_var_um_documentov '" & psEmpresa & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("numero").ToString & "'"
                                dt = Otrans.Obtiene(ls_sql)

                                ''(c) 20160128 El Descuento por pronto pago
                                dt.DefaultView.RowFilter = "nombre = 'DESC_LICORES'"
                                If dt.DefaultView(0).Item("Monto") = 0 Then
                                    'If dt.DefaultView.Count = 0 Then
                                    ''(c) 20160128 El Descuento de Centralizacion viene en este campo
                                    dt.DefaultView.RowFilter = "nombre = 'DESC_CENTRA'"
                                End If
                                Dim drProducto As DataRow = OdsXML.Tables("Productos").NewRow
                                Dim drv2 As DataRowView = dt.DefaultView(0)
                                dvalorPorcentajeDR1 = 0
                                IMPORT_BRUTO = 0
                                IMPORT_NETO = 0
                                IMPORT_IVA = 0
                                IMPORT_TOTAL = 0

                                Dim dMonto As Double = Math.Round(drv2.Item("Monto"), 2) * -1

                                linea = ""
                                '1.TIPO REGISTRO  2.CANTIDAD 3.UNIDAD MEDIDA
                                linea = "2|1|1|"
                                '4.PRECIO
                                linea += dMonto & "|"

                                'VERIFICA SI HAY DESCUENTO   
                                'SI NO HAY DESCUENTO
                                '5.PORCENTAJE_DESCUENTO 6.IMPORTE_DESCUENTO
                                linea += "0|0|"
                                '7.IMPORTE_BRUTO
                                IMPORT_BRUTO = dMonto
                                linea += IMPORT_BRUTO & "|"
                                importe_bruto += IMPORT_BRUTO

                                'VERIFICA SI HAY IMPORTE EXENTO
                                '9.IMPORTE_NETO --Se realizo el salto de correlativo cuando sea exento
                                'IMPORT_NETO = Math.Round(drv2.Item("Monto"), 2)

                                '8.IMPORTE_EXENTO 
                                linea += "0|"
                                '9.IMPORTE_NETO
                                IMPORT_NETO = Math.Round(dMonto / 1.12, 2)
                                linea += IMPORT_NETO & "|"
                                '10.IMPORTE_IVA    11.IMPORTE_OTROS
                                IMPORT_IVA = IMPORT_BRUTO - IMPORT_NETO
                                linea += IMPORT_IVA & "|0|"

                                '12.IMPORTE_TOTAL
                                IMPORT_TOTAL = IMPORT_NETO + IMPORT_IVA
                                linea += IMPORT_TOTAL & "|"

                                '13.PRODUCTO       14.DESCRIPCION
                                'linea += drvD.Item("producto").ToString & "|" & drvD.Item("glosa").ToString & "|"
                                If drv.Item("codlegal").ToString = "7378106" Then
                                    linea += "0000000002|DESCUENTO POR CENTRALIZACION|"
                                    drProducto.Item("Producto") = "0000000002"
                                    drProducto.Item("Descripcion") = "DESCUENTO POR CENTRALIZACION"
                                Else
                                    linea += "0000000001|DESCUENTOS GLOBALES|"
                                    drProducto.Item("Producto") = "0000000001"
                                    drProducto.Item("Descripcion") = "DESCUENTOS GLOBALES"
                                End If




                                'linea += "0.00|0.00"
                                '15.IMPUESTO_DISTRIBUCION
                                linea += "0.00"

                                '16.PRECIO_SUGERIDO
                                linea += "|0"

                                '17.VOLUMEN
                                linea += "|0"

                                impdist = 0
                                importe_total += IMPORT_TOTAL
                                importe_neto += IMPORT_NETO
                                importe_iva += IMPORT_IVA
                                importe_descuento += Math.Round(dvalorPorcentajeDR1, 2)
                                lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                nLineas += 1


                                drProducto.Item("PorcDesc") = 0
                                drProducto.Item("ImpDescuento") = 0
                                drProducto.Item("ImpBruto") = IMPORT_BRUTO

                                drProducto.Item("impuestodistribucion") = 0
                                drProducto.Item("preciosugerido") = 0
                                drProducto.Item("Medida") = 1
                                drProducto.Item("Cantidad") = 1
                                drProducto.Item("Precio") = dMonto
                                drProducto.Item("ImpExento") = exento
                                drProducto.Item("ImpOtros") = 0
                                drProducto.Item("ImpNeto") = IMPORT_NETO
                                drProducto.Item("ImpIsr") = 0
                                drProducto.Item("ImpIva") = IMPORT_IVA
                                drProducto.Item("ImpTotal") = IMPORT_TOTAL

                                Try
                                    If dtmyDetalle.DefaultView.Count > 0 Then
                                        drProducto.Item("gtin") = dtmyDetalle.DefaultView(0).Item("gtin").ToString
                                        drProducto.Item("IdBuyer") = dtmyDetalle.DefaultView(0).Item("idBuyer").ToString
                                        drProducto.Item("IdU12") = dtmyDetalle.DefaultView(0).Item("IdU12").ToString
                                        drProducto.Item("IdU13") = dtmyDetalle.DefaultView(0).Item("IdU13").ToString
                                        drProducto.Item("IdSupplier") = dtmyDetalle.DefaultView(0).Item("IdSupplier").ToString
                                        drProducto.Item("UnitofMesure") = dtmyDetalle.DefaultView(0).Item("UnitofMesure").ToString
                                    ElseIf drv.Item("codlegal").ToString = "7378106" Then
                                        drProducto.Item("gtin") = "00014800000344"
                                        drProducto.Item("IdBuyer") = "070327006"
                                        drProducto.Item("IdU12") = ""
                                        drProducto.Item("IdU13") = "0014800000344"
                                        drProducto.Item("IdSupplier") = "200060191"
                                        drProducto.Item("UnitofMesure") = "EA"
                                    End If
                                Catch ex As Exception

                                    If drv.Item("codlegal").ToString = "7378106" Then
                                        drProducto.Item("gtin") = "00014800000344"
                                        drProducto.Item("IdBuyer") = "070327006"
                                        drProducto.Item("IdU12") = ""
                                        drProducto.Item("IdU13") = "0014800000344"
                                        drProducto.Item("IdSupplier") = "200060191"
                                        drProducto.Item("UnitofMesure") = "EA"
                                    End If

                                    ClsGen.Escribir_Log(ex.ToString)
                                End Try
                                'Complemento del ultimo pedido




                                OdsXML.Tables("Productos").Rows.Add(drProducto) ''Agrego el Registro


                                Try
                                    OdsXML.Tables("Encabezado").Rows(0).Item("Descuento") = IMPORT_TOTAL * -1

                                Catch ex As Exception
                                    ClsGen.Escribir_Log(ex.ToString)
                                End Try
                            End If ''Descuento Global


                            ''Documentos Asociados
                            If drv.Item("documento").ToString = "Credito" Then
                                linea = ""
                                If drv.Item("Refnumero").ToString.Trim.Length = 12 Then

                                    ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)

                                    Try
                                        linea += "3|FACE|" & drv.Item("RefTipoDocto").ToString & "|" & _
                                                drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")

                                    Catch ex As Exception

                                    End Try
                                Else

                                    ls_sql = "pa_sel_um_documento_NCDC '" & drv.Item("empresa").ToString & _
                                                "','" & drv.Item("RefTipoDocto").ToString & "','" & drv.Item("RefCorrelativo").ToString & "'"
                                    dt = Otrans.Obtiene(ls_sql)

                                    Try
                                        linea += "3|CFACE|CFACE-" & dt.Rows(0).Item("texto4") & "-" & dt.Rows(0).Item("texto1") & "|" & _
                                                drv.Item("Refnumero").ToString & "|" & Date.Parse(drv.Item("Reffecha").ToString).ToString("yyyyMMdd")
                                    Catch ex As Exception
                                    End Try

                                End If
                                'lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)

                            End If


                            ''Totales

                            If drv.Item("documento").ToString = "Factura" Then
                                Dim ldtotalFactura As Double = 0
                                '20180117 facturacion en dolares

                                ldtotalFactura = drv.Item("total")

                                If Math.Abs(importe_total - ldtotalFactura) > 0.1 Then
                                    'MessageBox.Show("Problemas con Documento Numero " & drv.Item("Numero"), "Verificacion", MessageBoxButtons.OK)
                                    ClsGen.Escribir_Log("**** Problemas con Los Totales en " & drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & "','" & drv.Item("numero") & "'")
                                    lbProcesar = False
                                Else
                                    Dim drTotales As DataRow = OdsXML.Tables("Totales").NewRow
                                        drTotales.Item("Isr") = 0
                                        linea = ""
                                        linea += "4|" & Math.Round(importe_bruto, 2) & "|"
                                        linea += Math.Round(importe_descuento, 2) & "|"
                                        If drv.Item("exento").ToString.ToLower = "si" Then
                                            linea += Math.Round(importe_bruto, 2) & "|0|0"
                                            drTotales.Item("Exento") = Math.Round(importe_bruto, 2)
                                            drTotales.Item("Otros") = 0
                                            drTotales.Item("Neto") = Math.Round(importe_bruto, 2)
                                            drTotales.Item("Iva") = 0

                                        Else
                                            linea += "0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2)
                                            drTotales.Item("Exento") = 0
                                            drTotales.Item("Otros") = 0
                                            drTotales.Item("Neto") = Math.Round(importe_neto, 2)
                                            drTotales.Item("Iva") = Math.Round(importe_iva, 2)
                                        End If
                                        linea += "|0|" & Math.Round(importe_total, 2) & "|0|0|" &
                                        nLineas & "|0"

                                        drTotales.Item("Bruto") = Math.Round(importe_bruto, 2)
                                        drTotales.Item("Descuento") = Math.Round(importe_descuento, 2)
                                        drTotales.Item("Total") = Math.Round(importe_total, 2)

                                        OdsXML.Tables("Totales").Rows.Add(drTotales)


                                        lsSQL = "pa_ins_um_gen_log_documento_face '" &
                                        drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") &
                                        "','" & drv.Item("numero") & "','" & lsLote & "',null," &
                                    importe_total & "," & nLineas
                                        Otrans.Ingresa(lsSQL)
                                        If Otrans.Codigo_error = 0 Then
                                            '    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                            drv.Item("procesado") = 1
                                        End If
                                    End If

                                End If '' Factura
                                If drv.Item("documento").ToString = "Credito" Then
                                linea = ""
                                linea += "4|" & Math.Round(importe_bruto, 2) & "|0|0|" & Math.Round(importe_neto, 2) & "|" & Math.Round(importe_iva, 2) & "|0|" & Math.Round(importe_total, 2) & "|0|0|" & _
                                nLineas & "|" & dt.Rows.Count

                                lsSQL = "pa_ins_um_gen_log_documento_face '" & _
                                    drv.Item("Empresa") & "','" & drv.Item("tipoDoctoOrigen") & _
                                    "','" & drv.Item("numero") & "','" & lsLote & "',null," & _
                                    importe_total & "," & nLineas

                                Otrans.Ingresa(lsSQL)
                                If Otrans.Codigo_error = 0 Then
                                    lexito = ClsGen.Escribir_textoASCII(lsNombreCompleto, linea & vbCrLf)
                                    drv.Item("procesado") = 1
                                End If

                            End If
                        End If
                    End If 'drv.Item("vigencia").ToString = "S"
                End If 'Serie Vacia
                ' End If 'Pedido Enviar
                'Next

                'If File.Exists(lsNombreCompleto) Then
                '    If lbProcesar Then
                '        ClsGen.Comprimir_Archivo(lsRutaArchivos, lsNombreArchivo, lsRutaArchivos & "\", lsNombreArchivo.Replace("txt", "zip"))
                '        ClsGen.Comprimir_Archivo(lsRutaArchivos, "1.txt", lsRutaArchivos & "\", lsNombreArchivo.Replace(".txt", "-OK.zip"))
                '        Dim lsArchivos As String() = Directory.GetFiles(lsRutaArchivos, "*.zip")

                '        'If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                '        Dim iArchivosSincronizados As String = 0

                '        For Each lsarchivo As String In lsArchivos
                '            If lsarchivo.IndexOf("-OK") = -1 Then ' And lsarchivo.Trim.Length > 0 Then
                '                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                '                    iArchivosSincronizados = 1
                '                End If
                '            End If
                '        Next


                '        For Each lsarchivo As String In lsArchivos
                '            If lsarchivo.IndexOf("-OK") <> 1 Then 'And lsarchivo.Trim.Length > 0 Then
                '                If ClsGen.Subir_FTP("face_" & psEmpresa.ToLower, lsarchivo) Then
                '                    iArchivosSincronizados += 1
                '                End If
                '            End If
                '        Next


                '        ClsGen.Escribir_Log("Archivos Sincronizados " & iArchivosSincronizados.ToString)
                '        If iArchivosSincronizados >= 2 Then
                '            moverArchivosFACE(psEmpresa, "Send")
                '        End If
                '    Else 'Si No  se procesa Por que Alguno estaba Malo

                '        ClsGen.Mover_Archivo(lsNombreCompleto, lsRutaArchivos & "\Err\" & lsNombreArchivo)
                '        'Debo Regresar Los que fueron Procesados
                '        odsFACE.Tables("pedidos").DefaultView.RowFilter = ""
                '        For Each dr As DataRow In odsFACE.Tables("pedidos").Rows
                '            If dr.Item("procesado") = True Then
                '                Dim lsSQL As String = "pa_del_um_gen_log_documento_face '" & _
                '                                dr.Item("Empresa") & "','" & dr.Item("tipoDoctoOrigen") & "','" & dr.Item("numero") & "'"
                '                Otrans.Elimina(lsSQL)

                '            End If
                '        Next



                '    End If
                'End If 'Existe Archivo

            End If
        Catch ex As Exception
            ClsGen.Escribir_Log(" Fnal Send_ProcesarInformacion " & ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Public Sub escribirXML(odsXML As DataSet, ByRef sArchivo As String, psNitEmisor As String)
        'Dim Oface As New umbral_face.umbral_face(psNitEmisor)
        'Oface.rutaArhivos(sArchivo)
        'Oface.escribirXML(odsXML)


        Dim gsRuta As String = sArchivo
        Dim gsArchivoGenerado As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        'sArchivo = Oface.archivoGenerado

        Dim archivo As Object

        Try

            If odsXML.Tables("infoDoc").Rows.Count > 0 Then


                Dim drInfoDoc As DataRow = odsXML.Tables("InfoDoc").Rows(0)
                Dim drEncabezado As DataRow = odsXML.Tables("Encabezado").Rows(0)

                'gsArchivoGenerado = "c:\aplicaciones\" & gsNitEmisor & "\" & gsNitEmisor & "_" & drInfoDoc.Item("Referencia").ToString.Trim.Replace("-", "_").Replace(" ", "") & ".xml"
                gsArchivoGenerado = gsRuta & "\" & psNitEmisor & "_" & drInfoDoc.Item("Referencia").ToString.Trim.Replace("-", "_").Replace(" ", "") & "_" & _
                     drEncabezado.Item("NoPedido").ToString.Trim & ".xml"

                Try
                    If File.Exists(gsArchivoGenerado) Then
                        File.Copy(gsArchivoGenerado, gsArchivoGenerado.Replace(".xml", "_" & Now.ToString("HHmmss") & ".xml"))
                        File.Delete(gsArchivoGenerado)
                    End If
                Catch ex As Exception

                End Try

                Dim obj As Object


                obj = CreateObject("Scripting.FileSystemObject")
                archivo = obj.createtextfile(gsArchivoGenerado, True)
                archivo.writeLine("<?xml version= '1.0'  encoding='ISO-8859-1'?>")
                archivo.writeLine("<DocElectronico>")
                archivo.writeLine("<Encabezado>")

                Dim drReceptor As DataRow = odsXML.Tables("Receptor").Rows(0)
                archivo.writeLine("<Receptor>")
                archivo.writeLine("<NITReceptor>" & drReceptor.Item("NitReceptor").ToString.Trim & "</NITReceptor>")
                archivo.writeLine("<Nombre>" & drReceptor.Item("Nombre").ToString.Trim.Replace("&", "&amp;") & "</Nombre>")
                archivo.writeLine("<Direccion>" & drReceptor.Item("Direccion").ToString.Trim & "</Direccion>")
                archivo.writeLine("</Receptor>")

                'Dim drInfoDoc As DataRow = OdsXML.Tables("InfoDoc").Rows(0)
                archivo.writeLine("<InfoDoc>")
                archivo.writeLine("<TipoVenta>" & drInfoDoc.Item("TipoVenta").ToString.Trim & "</TipoVenta>")
                archivo.writeLine("<DestinoVenta>" & drInfoDoc.Item("DestinoVenta").ToString.Trim & "</DestinoVenta>")
                archivo.writeLine("<Fecha>" & drInfoDoc.Item("Fecha").ToString.Trim & "</Fecha>")
                archivo.writeLine("<Moneda>" & drInfoDoc.Item("Moneda").ToString.Trim & "</Moneda>")
                archivo.writeLine("<Tasa>" & drInfoDoc.Item("Tasa").ToString.Trim & "</Tasa>")
                archivo.writeLine("<Referencia>" & drInfoDoc.Item("Referencia").ToString.Trim & "</Referencia>")
                archivo.writeLine("<Revision> " & drInfoDoc.Item("Revision").ToString.Trim & "</Revision>")
                archivo.writeLine("</InfoDoc>")

                Dim drTotales As DataRow = odsXML.Tables("Totales").Rows(0)
                archivo.writeLine("<Totales>")
                archivo.writeLine("<Bruto>" & drTotales.Item("Bruto").ToString.Trim & "</Bruto>")
                archivo.writeLine("<Descuento>" & drTotales.Item("Descuento").ToString.Trim & "</Descuento>")
                archivo.writeLine("<Exento>" & drTotales.Item("Exento").ToString.Trim & "</Exento>")
                archivo.writeLine("<Otros>" & drTotales.Item("Otros").ToString.Trim & "</Otros>")
                archivo.writeLine("<Neto>" & drTotales.Item("Neto").ToString.Trim & "</Neto>")
                archivo.writeLine("<Isr>" & drTotales.Item("Isr").ToString.Trim & "</Isr>")
                archivo.writeLine("<Iva>" & drTotales.Item("Iva").ToString.Trim & "</Iva>")
                archivo.writeLine("<Total>" & drTotales.Item("Total").ToString.Trim & "</Total>")
                archivo.writeLine("</Totales>")



                archivo.writeLine("<DatosAdicionales>")

                archivo.writeLine("<NUMERO>" & drEncabezado.Item("NUMERO").ToString.Trim & "</NUMERO>")
                archivo.writeLine("<NUMERO_ORDEN> " & drEncabezado.Item("NUMERO_ORDEN").ToString.Trim & "</NUMERO_ORDEN>")
                archivo.writeLine("<NUMERO_RECEPCION> " & drEncabezado.Item("NUMERO_RECEPCION").ToString.Trim & "</NUMERO_RECEPCION>")
                archivo.writeLine("<CONDICIONES>" & drEncabezado.Item("CONDICIONES").ToString.Trim.Replace("&", " ") & "</CONDICIONES>")
                archivo.writeLine("<OBSERVACIONES>" & drEncabezado.Item("OBSERVACIONES").ToString.Trim.Replace("&", " ") & "</OBSERVACIONES>")

                ''Informacion WalMart
                If True Then
                    archivo.writeLine("<codProv>" & drEncabezado.Item("codProv").ToString.Trim & "</codProv>")
                    archivo.writeLine("<gln>" & drEncabezado.Item("gln").ToString.Trim & "</gln>")
                    archivo.writeLine("<city>" & drEncabezado.Item("city").ToString.Trim & "</city>")
                    archivo.writeLine("<state>" & drEncabezado.Item("state").ToString.Trim & "</state>")
                    archivo.writeLine("<streetAddress>" & drEncabezado.Item("streetAddress").ToString.Trim.PadLeft(80, " ").Substring(0, 79) & "</streetAddress>")
                    archivo.writeLine("<NoPedido>" & drEncabezado.Item("NoPedido").ToString.Trim & "</NoPedido>")
                    archivo.writeLine("<CodRecepcion>" & drEncabezado.Item("CodRecepcion").ToString.Trim & "</CodRecepcion>")
                    archivo.writeLine("<Descuento>" & drEncabezado.Item("Descuento").ToString.Trim & "</Descuento>")
                End If
                archivo.writeLine("</DatosAdicionales>")

                archivo.writeLine("</Encabezado>")

                archivo.writeLine("<Detalles>")


                For Each drProductos As DataRow In odsXML.Tables("Productos").Rows
                    archivo.writeLine("<Productos>")
                    archivo.writeLine("<Producto>" & drProductos.Item("Producto").ToString.Trim & "</Producto>")
                    archivo.writeLine("<Descripcion>" & drProductos.Item("Descripcion").ToString.Trim.Replace("&", "&amp;") & "</Descripcion>")
                    archivo.writeLine("<Medida>" & drProductos.Item("Medida").ToString.Trim & "</Medida>")
                    archivo.writeLine("<Cantidad>" & drProductos.Item("Cantidad").ToString.Trim & "</Cantidad>")
                    archivo.writeLine("<Precio>" & drProductos.Item("Precio").ToString.Trim & "</Precio>")
                    archivo.writeLine("<PorcDesc>" & drProductos.Item("PorcDesc").ToString.Trim & "</PorcDesc>")
                    archivo.writeLine("<ImpBruto>" & drProductos.Item("ImpBruto").ToString.Trim & "</ImpBruto>")
                    archivo.writeLine("<ImpDescuento>" & drProductos.Item("ImpDescuento").ToString.Trim & "</ImpDescuento>")
                    archivo.writeLine("<ImpExento>" & drProductos.Item("ImpExento").ToString.Trim & "</ImpExento>")
                    archivo.writeLine("<ImpOtros>" & drProductos.Item("ImpOtros").ToString.Trim & "</ImpOtros>")
                    archivo.writeLine("<ImpNeto>" & drProductos.Item("ImpNeto").ToString.Trim & "</ImpNeto>")
                    archivo.writeLine("<ImpIsr>" & drProductos.Item("ImpIsr").ToString.Trim & "</ImpIsr>")
                    archivo.writeLine("<ImpIva>" & drProductos.Item("ImpIva").ToString.Trim & "</ImpIva>")
                    archivo.writeLine("<ImpTotal>" & drProductos.Item("ImpTotal").ToString.Trim & "</ImpTotal>")
                    archivo.writeLine("<ImpTotal>" & drProductos.Item("ImpTotal").ToString.Trim & "</ImpTotal>")
                    archivo.writeLine("<DatosAdicionalesProd>")
                    archivo.writeLine("<impuestodistribucion>" & drProductos.Item("impuestodistribucion").ToString.Trim & "</impuestodistribucion>")
                    archivo.writeLine("<preciosugerido>" & drProductos.Item("preciosugerido").ToString.Trim & "</preciosugerido>")
                    archivo.writeLine("<medida>" & drProductos.Item("medida").ToString.Trim & "</medida>")

                    If True Then


                        ''Informacion WalMart
                        archivo.writeLine("<gtin>" & drProductos.Item("gtin").ToString.Trim & "</gtin>")
                        archivo.writeLine("<IdBuyer>" & drProductos.Item("idBuyer").ToString.Trim & "</IdBuyer>")
                        archivo.writeLine("<IdU12>" & drProductos.Item("IdU12").ToString.Trim & "</IdU12>")
                        archivo.writeLine("<IdU13>" & drProductos.Item("IdU13").ToString.Trim & "</IdU13>")
                        archivo.writeLine("<IdSupplier>" & drProductos.Item("IdSupplier").ToString.Trim & "</IdSupplier>")
                        archivo.writeLine("<UnitofMesure>" & drProductos.Item("UnitOfMesure").ToString.Trim & "</UnitofMesure>")
                    End If
                    archivo.writeLine("</DatosAdicionalesProd>")
                    archivo.writeLine("</Productos>")
                Next

                archivo.writeLine("<DocAsociados>")
                archivo.writeLine("<DASerie></DASerie>")
                archivo.writeLine("<DAPreimpreso></DAPreimpreso>")
                archivo.writeLine("</DocAsociados>")
                archivo.writeLine("</Detalles> ")


                archivo.writeLine("</DocElectronico>")
                archivo.close()
            End If
        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            archivo.close()
            sArchivo = gsArchivoGenerado
            clsGen = Nothing
        End Try


    End Sub


    Private Sub send_enviosPendientesFACE(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)
        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gsEmpresa
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        '        Dim drv As DataRowView
        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")
        'oTrans.gsnombreLog = "log_" & gsEmpresa
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In oTabla.Rows

                'If dr.Item("fechaenvio") = "01/01/1900" And
                '    (dr.Item("tipodocto").ToString = "PEDIDO FACE" Or
                '        dr.Item("tipodocto").ToString = "PEDIDO FACE RE" Or
                '        dr.Item("tipodocto").ToString = "PEDIDO FACE DA") _
                '        And dr.Item("total") > 0 Then

                If (dr.Item("tipodocto").ToString = "PEDIDO FACE" Or
                        dr.Item("tipodocto").ToString = "PEDIDO FACE RE" Or
                        dr.Item("tipodocto").ToString = "PEDIDO FACE DA") _
                        And dr.Item("total") > 0 Then

                    If dr.Item("codlegal") = "7378106" Then
                        If dr.Item("tipodocto").ToString <> "PEDIDO FACE RE" Or dr.Item("comentario").ToString.Substring(0, 7) <> "PDA-EDI" Then ''Si es WM debe validar Precios de OC" Then

                            agregarPedidoPendiente(dr, odsFACE)
                        Else
                            If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then
                                agregarPedidoPendiente(dr, odsFACE)
                            Else                            ''Generar Aviso que los precios estan incorrectos
                                clGen.Escribir_Log("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)
                                guardarAviso("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)
                                ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
                                            dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
                                            "','" & dr.Item("numero") & "','',null,0,0,'" &
                                            "Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"

                                clGen.insertQuery("FlexLine", ls_sqltxt)

                            End If
                        End If
                    Else  ''Pedido de Cualquier otro cliente
                        agregarPedidoPendiente(dr, odsFACE)
                    End If

                End If
            Next

            'Filtro2 (c) Servira para generar los pedidos centralizados de walmart, deben liberrar el envio para generar la informacion de la fecha establecida
            '(c) 20150422
            '(c) 20150527 Siempre debe verificar pues hay pedidos del mismo dia
            'If psFechaAdicional <> psFecha Then

            ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPura '" & psEmpresa & "','" & psFechaAdicional & "','" & psFechaAdicional & "',1"
            clGen.Escribir_Log(ls_sqltxt & "WM")
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In oTabla.Rows

                'If dr.Item("fechaenvio") = "01/01/1900" And
                '    (dr.Item("tipodocto").ToString = "PEDIDO WALMART" Or dr.Item("tipodocto").ToString = "PEDIDO CONSOLIDADO") _
                '        And dr.Item("total") > 0 And dr.Item("numero_recepcion_walmart").ToString.Length > 0 Then

                Dim numero As Boolean

                If dr("numero") = "0190701422" Then

                    numero = True

                End If

                If (dr.Item("tipodocto").ToString = "PEDIDO WALMART" Or dr.Item("tipodocto").ToString = "PEDIDO CONSOLIDADO") _
                        And dr.Item("total") > 0 And dr.Item("numero_recepcion_walmart").ToString.Length > 0 Then

                    ldfechaInicial = psFechaAdicional

                    '(c) 20150806
                    ''Debo Verificar si es pedido walmart (Centralizado) que el pedido 
                    ''tenga los mismo valores que la OdeC Walmart
                    If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then

                        agregarPedidoPendiente(dr, odsFACE)
                    Else

                        ''Generar Aviso que los precios estan incorrectos

                        clGen.Escribir_Log("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)

                        guardarAviso("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)

                        ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
                                    dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
                                    "','" & dr.Item("numero") & "','',null,0,0,'" &
                                    "Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"

                        clGen.insertQuery("FlexLine", ls_sqltxt)


                        'ls_sqltxt = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                        '           dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "','Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"
                        ''oTrans.Actualiza(lsSQL)

                        'clGen.insertQuery("FlexLine", ls_sqltxt)



                    End If
                End If
            Next
            'End If



            ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)
        Catch ex As Exception
            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)

        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
        End Try

    End Sub



    Private Sub DocumentospendientesEmisionFEL(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)

        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gsEmpresa
        Dim oTabla As DataTable
        Dim tFacturasExcentas As DataTable = New DataTable
        Dim dt, dtPermisos As DataTable
        '        Dim drv As DataRowView
        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        'ls_sqltxt = "pa_sel_um_tipodocto_creditos_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        ls_sqltxt = "pa_sel_um_tipodocumento_Fel_Pendiente_Emision '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")
        'oTrans.gsnombreLog = "log_" & gsEmpresa
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In oTabla.Rows

                If (dr.Item("tipodocto").ToString = "FEL" Or
                        dr.Item("tipodocto").ToString = "FEL COSTO" _
                        And dr.Item("total") > 0) Then

                    If dr.Item("codlegal") = "7378106" Then

                        If dr.Item("tipodocto").ToString <> "PEDIDO FACE RE" Or dr.Item("comentario").ToString.Substring(0, 7) <> "PDA-EDI" Then ''Si es WM debe validar Precios de OC" Then

                            agregarPedidoPendiente(dr, odsFACE)

                        Else

                            If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then
                                agregarPedidoPendiente(dr, odsFACE)
                            Else                            ''Generar Aviso que los precios estan incorrectos
                                clGen.Escribir_Log("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)
                                guardarAviso("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)
                                ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
                                            dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
                                            "','" & dr.Item("numero") & "','',null,0,0,'" &
                                            "Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "'"

                                clGen.insertQuery("FlexLine", ls_sqltxt)

                            End If

                        End If

                    Else  ''Pedido de Cualquier otro cliente

                        agregarPedidoPendiente(dr, odsFACE)

                    End If

                End If

            Next

            'oTabla.DefaultView.RowFilter = "documento like 'credito'"

            'For Each dr In oTabla.Rows

            '    agregarPedidoPendiente(dr, odsFACE)

            'Next

            '+----------------------------------
            '|            FEL EXENTAS
            '+----------------------------------

            ls_sqltxt = "pa_sel_um_tipodocumento_exentas_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
            tFacturasExcentas = oTrans.Obtiene(ls_sqltxt)

            Dim tFacturasExcentasDistintas As New DataTable
            Dim tFactExcentas As DataTable = tFacturasExcentas.Copy()

            tFacturasExcentasDistintas = tFactExcentas.Copy()
            tFacturasExcentasDistintas.Clear()

            tFacturasExcentas.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In tFacturasExcentas.Rows

                If dr("TipoDocto") = "PEDIDO FEL EXENTO" Then

                    tFactExcentas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
                        & "' and Numero = '" & dr("Numero") & "'"

                    tFacturasExcentasDistintas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
                        & "' and Numero = '" & dr("Numero") & "'"

                    If tFactExcentas.Rows.Count > 0 Then

                        If tFacturasExcentasDistintas.DefaultView.Count = 0 Then

                            tFacturasExcentasDistintas.DefaultView.RowFilter = ""
                            Dim rFactExcenta As DataRow = tFacturasExcentasDistintas.NewRow()

                            For Each fExcenta As DataRowView In tFactExcentas.DefaultView

                                Dim colCount As Integer = 0

                                Do While (colCount < tFacturasExcentas.Columns.Count() - 4)

                                    rFactExcenta(colCount) = fExcenta(colCount)
                                    colCount = colCount + 1

                                Loop

                                If fExcenta(colCount).ToString() <> "" And Val(fExcenta(colCount).ToString()) > 0 Then

                                    rFactExcenta(colCount) = fExcenta(colCount)

                                End If

                                If fExcenta(colCount + 1).ToString() <> "" And Val(fExcenta(colCount + 1).ToString()) > 0 Then

                                    rFactExcenta(colCount + 1) = fExcenta(colCount + 1)

                                End If

                                If fExcenta(colCount + 2).ToString() <> "" And Val(fExcenta(colCount + 2).ToString()) > 0 Then

                                    rFactExcenta(colCount + 2) = fExcenta(colCount + 2)

                                End If

                                If fExcenta(colCount + 3).ToString() <> "" And Val(fExcenta(colCount + 3).ToString()) > 0 Then

                                    rFactExcenta(colCount + 3) = fExcenta(colCount + 3)

                                End If

                            Next

                            rFactExcenta("Exento") = "Si"
                            tFacturasExcentasDistintas.Rows.Add(rFactExcenta)
                            agregarPedidoPendiente(rFactExcenta, odsFACE)

                        End If

                    End If

                End If

            Next

            '========================================

            'Filtro2 (c) Servira para generar los pedidos centralizados de walmart, deben liberrar el envio para generar la informacion de la fecha establecida
            '(c) 20150422
            '(c) 20150527 Siempre debe verificar pues hay pedidos del mismo dia
            'If psFechaAdicional <> psFecha Then

            'ls_sqltxt = "pa_sel_um_tipodocumento_FelPura '" & psEmpresa & "','" & psFechaAdicional & "','" & psFechaAdicional & "',1"
            'clGen.Escribir_Log(ls_sqltxt & "WM")
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.DefaultView.RowFilter = "documento like 'factura'"

            'For Each dr In oTabla.Rows

            '    Dim numero As Boolean

            '    If dr("numero") = "0190701422" Then

            '        numero = True

            '    End If

            '    If (dr.Item("tipodocto").ToString = "PEDIDO WALMART" Or dr.Item("tipodocto").ToString = "PEDIDO CONSOLIDADO") _
            '            And dr.Item("total") > 0 And dr.Item("numero_recepcion_walmart").ToString.Length > 0 Then

            '        ldfechaInicial = psFechaAdicional

            '        '(c) 20150806
            '        ''Debo Verificar si es pedido walmart (Centralizado) que el pedido 
            '        ''tenga los mismo valores que la OdeC Walmart
            '        If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then

            '            agregarPedidoPendiente(dr, odsFACE)
            '        Else

            '            ''Generar Aviso que los precios estan incorrectos

            '            clGen.Escribir_Log("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)

            '            guardarAviso("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)

            '            ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
            '                        dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
            '                        "','" & dr.Item("numero") & "','',null,0,0,'" &
            '                        "Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"

            '            clGen.insertQuery("FlexLine", ls_sqltxt)

            '        End If

            '    End If

            'Next

            'End If

            ls_sqltxt = "pa_var_um_detalle_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            'ls_sqltxt = "pa_var_um_detalle_creditos_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)

        Catch ex As Exception

            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)

        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try

    End Sub


    Private Sub PedidosPendientesFEL(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)

        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gsEmpresa
        Dim oTabla As DataTable
        Dim tFacturasExcentas As DataTable = New DataTable
        Dim dt, dtPermisos As DataTable
        '        Dim drv As DataRowView
        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        'ls_sqltxt = "pa_sel_um_tipodocto_creditos_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        ls_sqltxt = "pa_sel_um_tipodocumento_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")
        'oTrans.gsnombreLog = "log_" & gsEmpresa
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In oTabla.Rows

                If (dr.Item("tipodocto").ToString = "PEDIDO FEL" Or
                        dr.Item("tipodocto").ToString = "PEDIDO FEL COSTO" _
                        And dr.Item("total") > 0) Then

                    If dr.Item("codlegal") = "7378106" Then

                        If dr.Item("tipodocto").ToString <> "PEDIDO FACE RE" Or dr.Item("comentario").ToString.Substring(0, 7) <> "PDA-EDI" Then ''Si es WM debe validar Precios de OC" Then

                            agregarPedidoPendiente(dr, odsFACE)

                        Else

                            If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then
                                agregarPedidoPendiente(dr, odsFACE)
                            Else                            ''Generar Aviso que los precios estan incorrectos
                                clGen.Escribir_Log("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)
                                guardarAviso("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)
                                ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
                                            dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
                                            "','" & dr.Item("numero") & "','',null,0,0,'" &
                                            "Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "'"

                                clGen.insertQuery("FlexLine", ls_sqltxt)

                            End If

                        End If

                    Else  ''Pedido de Cualquier otro cliente

                        agregarPedidoPendiente(dr, odsFACE)

                    End If

                End If

            Next

            'oTabla.DefaultView.RowFilter = "documento like 'credito'"

            'For Each dr In oTabla.Rows

            '    agregarPedidoPendiente(dr, odsFACE)

            'Next

            '+----------------------------------
            '|            FEL EXENTAS
            '+----------------------------------

            ls_sqltxt = "pa_sel_um_tipodocumento_exentas_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
            tFacturasExcentas = oTrans.Obtiene(ls_sqltxt)

            Dim tFacturasExcentasDistintas As New DataTable
            Dim tFactExcentas As DataTable = tFacturasExcentas.Copy()

            tFacturasExcentasDistintas = tFactExcentas.Copy()
            tFacturasExcentasDistintas.Clear()

            tFacturasExcentas.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In tFacturasExcentas.Rows

                If dr("TipoDocto") = "PEDIDO FEL EXENTO" Then

                    tFactExcentas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
                        & "' and Numero = '" & dr("Numero") & "'"

                    tFacturasExcentasDistintas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
                        & "' and Numero = '" & dr("Numero") & "'"

                    If tFactExcentas.Rows.Count > 0 Then

                        If tFacturasExcentasDistintas.DefaultView.Count = 0 Then

                            tFacturasExcentasDistintas.DefaultView.RowFilter = ""
                            Dim rFactExcenta As DataRow = tFacturasExcentasDistintas.NewRow()

                            For Each fExcenta As DataRowView In tFactExcentas.DefaultView

                                Dim colCount As Integer = 0

                                Do While (colCount < tFacturasExcentas.Columns.Count() - 4)

                                    rFactExcenta(colCount) = fExcenta(colCount)
                                    colCount = colCount + 1

                                Loop

                                If fExcenta(colCount).ToString() <> "" And Val(fExcenta(colCount).ToString()) > 0 Then

                                    rFactExcenta(colCount) = fExcenta(colCount)

                                End If

                                If fExcenta(colCount + 1).ToString() <> "" And Val(fExcenta(colCount + 1).ToString()) > 0 Then

                                    rFactExcenta(colCount + 1) = fExcenta(colCount + 1)

                                End If

                                If fExcenta(colCount + 2).ToString() <> "" And Val(fExcenta(colCount + 2).ToString()) > 0 Then

                                    rFactExcenta(colCount + 2) = fExcenta(colCount + 2)

                                End If

                                If fExcenta(colCount + 3).ToString() <> "" And Val(fExcenta(colCount + 3).ToString()) > 0 Then

                                    rFactExcenta(colCount + 3) = fExcenta(colCount + 3)

                                End If

                            Next

                            rFactExcenta("Exento") = "Si"
                            tFacturasExcentasDistintas.Rows.Add(rFactExcenta)
                            agregarPedidoPendiente(rFactExcenta, odsFACE)

                        End If

                    End If

                End If

            Next

            '========================================

            'Filtro2 (c) Servira para generar los pedidos centralizados de walmart, deben liberrar el envio para generar la informacion de la fecha establecida
            '(c) 20150422
            '(c) 20150527 Siempre debe verificar pues hay pedidos del mismo dia
            'If psFechaAdicional <> psFecha Then

            'ls_sqltxt = "pa_sel_um_tipodocumento_FelPura '" & psEmpresa & "','" & psFechaAdicional & "','" & psFechaAdicional & "',1"
            'clGen.Escribir_Log(ls_sqltxt & "WM")
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.DefaultView.RowFilter = "documento like 'factura'"

            'For Each dr In oTabla.Rows

            '    Dim numero As Boolean

            '    If dr("numero") = "0190701422" Then

            '        numero = True

            '    End If

            '    If (dr.Item("tipodocto").ToString = "PEDIDO WALMART" Or dr.Item("tipodocto").ToString = "PEDIDO CONSOLIDADO") _
            '            And dr.Item("total") > 0 And dr.Item("numero_recepcion_walmart").ToString.Length > 0 Then

            '        ldfechaInicial = psFechaAdicional

            '        '(c) 20150806
            '        ''Debo Verificar si es pedido walmart (Centralizado) que el pedido 
            '        ''tenga los mismo valores que la OdeC Walmart
            '        If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then

            '            agregarPedidoPendiente(dr, odsFACE)
            '        Else

            '            ''Generar Aviso que los precios estan incorrectos

            '            clGen.Escribir_Log("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)

            '            guardarAviso("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)

            '            ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
            '                        dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
            '                        "','" & dr.Item("numero") & "','',null,0,0,'" &
            '                        "Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"

            '            clGen.insertQuery("FlexLine", ls_sqltxt)

            '        End If

            '    End If

            'Next

            'End If

            ls_sqltxt = "pa_var_um_detalle_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            'ls_sqltxt = "pa_var_um_detalle_creditos_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)

        Catch ex As Exception

            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)

        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try

    End Sub

    Private Sub PedidosPendientesCreditosFEL(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)

        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gsEmpresa
        Dim oTabla As DataTable
        Dim tFacturasExcentas As DataTable = New DataTable
        Dim dt, dtPermisos As DataTable
        '        Dim drv As DataRowView
        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocto_creditos_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        'ls_sqltxt = "pa_sel_um_tipodocumento_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")
        'oTrans.gsnombreLog = "log_" & gsEmpresa
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each dr In oTabla.Rows

                If (dr.Item("tipodocto").ToString = "PEDIDO FEL RE" Or
                        dr.Item("tipodocto").ToString = "PEDIDO FEL COSTO" _
                        And dr.Item("total") > 0) Then

                    If dr.Item("codlegal") = "7378106" Then

                        If dr.Item("tipodocto").ToString <> "PEDIDO FACE RE" Or dr.Item("comentario").ToString.Substring(0, 7) <> "PDA-EDI" Then ''Si es WM debe validar Precios de OC" Then

                            agregarPedidoPendiente(dr, odsFACE)

                        Else

                            If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then
                                agregarPedidoPendiente(dr, odsFACE)
                            Else                            ''Generar Aviso que los precios estan incorrectos
                                clGen.Escribir_Log("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)
                                guardarAviso("Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)
                                ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
                                            dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
                                            "','" & dr.Item("numero") & "','',null,0,0,'" &
                                            "Diferencia En Precios EdiFact-FEL " & ldDiferenciaTotal & "'"

                                clGen.insertQuery("FlexLine", ls_sqltxt)

                            End If

                        End If

                    Else  ''Pedido de Cualquier otro cliente

                        agregarPedidoPendiente(dr, odsFACE)

                    End If

                End If

            Next

            oTabla.DefaultView.RowFilter = "documento like 'credito'"

            For Each dr In oTabla.Rows

                agregarPedidoPendiente(dr, odsFACE)

            Next

            '+----------------------------------
            '|            FEL EXENTAS
            '+----------------------------------

            'ls_sqltxt = "pa_sel_um_tipodocumento_exentas_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"
            'tFacturasExcentas = oTrans.Obtiene(ls_sqltxt)

            'Dim tFacturasExcentasDistintas As New DataTable
            'Dim tFactExcentas As DataTable = tFacturasExcentas.Copy()

            'tFacturasExcentasDistintas = tFactExcentas.Copy()
            'tFacturasExcentasDistintas.Clear()

            'tFacturasExcentas.DefaultView.RowFilter = "documento like 'factura'"

            'For Each dr In tFacturasExcentas.Rows

            '    If dr("TipoDocto") = "PEDIDO FEL EXENTO" Then

            '        tFactExcentas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
            '            & "' and Numero = '" & dr("Numero") & "'"

            '        tFacturasExcentasDistintas.DefaultView.RowFilter = "Empresa = '" & dr("Empresa") & "' and TipoDocto = '" & dr("TipoDocto") _
            '            & "' and Numero = '" & dr("Numero") & "'"

            '        If tFactExcentas.Rows.Count > 0 Then

            '            If tFacturasExcentasDistintas.Rows.Count = 0 Then

            '                tFacturasExcentasDistintas.DefaultView.RowFilter = ""
            '                Dim rFactExcenta As DataRow = tFacturasExcentasDistintas.NewRow()

            '                For Each fExcenta As DataRow In tFacturasExcentas.Rows

            '                    Dim colCount As Integer = 0

            '                    Do While (colCount < tFacturasExcentas.Columns.Count() - 4)

            '                        rFactExcenta(colCount) = fExcenta(colCount)
            '                        colCount = colCount + 1

            '                    Loop

            '                    If fExcenta(colCount).ToString() <> "" And Val(fExcenta(colCount).ToString()) > 0 Then

            '                        rFactExcenta(colCount) = fExcenta(colCount)

            '                    End If

            '                    If fExcenta(colCount + 1).ToString() <> "" And Val(fExcenta(colCount + 1).ToString()) > 0 Then

            '                        rFactExcenta(colCount + 1) = fExcenta(colCount + 1)

            '                    End If

            '                    If fExcenta(colCount + 2).ToString() <> "" And Val(fExcenta(colCount + 2).ToString()) > 0 Then

            '                        rFactExcenta(colCount + 2) = fExcenta(colCount + 2)

            '                    End If

            '                    If fExcenta(colCount + 3).ToString() <> "" And Val(fExcenta(colCount + 3).ToString()) > 0 Then

            '                        rFactExcenta(colCount + 3) = fExcenta(colCount + 3)

            '                    End If

            '                Next

            '                rFactExcenta("Exento") = "Si"
            '                tFacturasExcentasDistintas.Rows.Add(rFactExcenta)
            '                agregarPedidoPendiente(rFactExcenta, odsFACE)

            '            End If

            '        End If

            '    End If

            'Next

            '========================================

            'Filtro2 (c) Servira para generar los pedidos centralizados de walmart, deben liberrar el envio para generar la informacion de la fecha establecida
            '(c) 20150422
            '(c) 20150527 Siempre debe verificar pues hay pedidos del mismo dia
            'If psFechaAdicional <> psFecha Then

            'ls_sqltxt = "pa_sel_um_tipodocumento_FelPura '" & psEmpresa & "','" & psFechaAdicional & "','" & psFechaAdicional & "',1"
            'clGen.Escribir_Log(ls_sqltxt & "WM")
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.DefaultView.RowFilter = "documento like 'factura'"

            'For Each dr In oTabla.Rows

            '    Dim numero As Boolean

            '    If dr("numero") = "0190701422" Then

            '        numero = True

            '    End If

            '    If (dr.Item("tipodocto").ToString = "PEDIDO WALMART" Or dr.Item("tipodocto").ToString = "PEDIDO CONSOLIDADO") _
            '            And dr.Item("total") > 0 And dr.Item("numero_recepcion_walmart").ToString.Length > 0 Then

            '        ldfechaInicial = psFechaAdicional

            '        '(c) 20150806
            '        ''Debo Verificar si es pedido walmart (Centralizado) que el pedido 
            '        ''tenga los mismo valores que la OdeC Walmart
            '        If valores_orden_edifact_correctos(psEmpresa, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, ldDiferenciaTotal) Then

            '            agregarPedidoPendiente(dr, odsFACE)
            '        Else

            '            ''Generar Aviso que los precios estan incorrectos

            '            clGen.Escribir_Log("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString)

            '            guardarAviso("Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "  " & psEmpresa & " " & dr.Item("tipodocto").ToString & " " & dr.Item("Numero").ToString, 36)

            '            ls_sqltxt = "pa_ins_um_gen_log_documento_face '" &
            '                        dr.Item("Empresa") & "','" & dr.Item("tipoDocto") &
            '                        "','" & dr.Item("numero") & "','',null,0,0,'" &
            '                        "Diferencia En Precios EdiFact-Flex " & ldDiferenciaTotal & "'"

            '            clGen.insertQuery("FlexLine", ls_sqltxt)

            '        End If

            '    End If

            'Next

            'End If

            'ls_sqltxt = "pa_var_um_detalle_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            ls_sqltxt = "pa_var_um_detalle_creditos_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)

        Catch ex As Exception

            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)

        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try

    End Sub

    Private Function valores_orden_edifact_correctos(psempresa As String, psTipoDocto As String, psNumeroDocto As String, ByRef pdDiferencia As Double)
        Dim lbValoresCorrectos As Boolean = False

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtDetalle, dtOrdenes As DataTable
        Dim lsSQL As String
        pdDiferencia = 0

        Try
            myOtrans.open()
            lsSQL = "pa_var_um_pedidos_walmart_detalle_pedido '" & psempresa & "','" & psTipoDocto & "','" & psNumeroDocto & "'"
            dtDetalle = ClsGen.selectQuery("FlexLine", lsSQL)
            dtOrdenes = ClsGen.ValoresDistinto(dtDetalle, "pedido,numero_pedido".Split(","))

            For Each drEncabezado As DataRow In dtOrdenes.Rows
                lsSQL = "call pa_var_um_edi_pedido_precios ('" & psempresa & "','" &
                            drEncabezado.Item("pedido").ToString & "','" &
                            drEncabezado.Item("numero_pedido").ToString & "')"

                dt = myOtrans.Obtiene(lsSQL)

                dtDetalle.DefaultView.RowFilter = "pedido = '" & drEncabezado.Item("pedido") & "' and numero_pedido = '" & drEncabezado.Item("numero_pedido") & "'"

                For Each drv As DataRowView In dtDetalle.DefaultView
                    dt.DefaultView.RowFilter = "codigoFlex = '" & drv.Item("producto").ToString & "'"
                    If dt.DefaultView.Count > 0 Then
                        drv.Item("precioEdi") = Math.Round(dt.DefaultView(0).Item("costonegociado"), 2, MidpointRounding.AwayFromZero)
                        drv.Item("precioEdi_iva") = Math.Round(drv.Item("precioEdi") * 1.12, 2, MidpointRounding.AwayFromZero)
                        drv.Item("PrecioAjustado") = Math.Round(drv.Item("PrecioAjustado"), 2, MidpointRounding.AwayFromZero)
                    End If
                Next

            Next

            dtDetalle.DefaultView.RowFilter = ""

            For Each dr As DataRow In dtDetalle.Rows
                dr.Item("diferencia") = Math.Abs(dr.Item("precioAjustado") - dr.Item("precioEdi"))
                'dr.Item("diferencia") = Math.Abs(dr.Item("precio") - dr.Item("precioEdi_iva"))
                pdDiferencia = pdDiferencia + (dr.Item("diferencia") * dr.Item("cantidad"))

            Next
            lbValoresCorrectos = True

            If Math.Abs(pdDiferencia) > Double.Parse(ClsGen.Obtener_XMLConfig("diferencia_maxima_WM", False).ToString) Then
                lbValoresCorrectos = False
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return lbValoresCorrectos
    End Function

    Private Sub agregarPedidoPendiente(dr As DataRow, ByRef odsFACE As DataSet)
        Dim dr_aux As DataRow = odsFACE.Tables("pedidos").NewRow

        Try
            dr_aux.Item("Enviar") = 0
            If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
        Catch ex As Exception

        End Try

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


        'Cuando la facturacion sea en dolares
        '(c) 20180117
        If dr.Item("moneda").ToString = "1" Then
            dr_aux.Item("total") = dr.Item("total")
        Else
            dr_aux.Item("total") = dr.Item("totalIngreso")
        End If

        Try
            If dr.Item("FACE").ToString.Trim.Length > 0 Then
                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
            End If
        Catch ex As Exception

        End Try
        dr_aux.Item("procesado") = 0
        Try
            If dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE" Or dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO WALMART" Then
                dr_aux.Item("MaquinaFACE") = 1
            ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
                dr_aux.Item("MaquinaFACE") = 2
            End If
        Catch ex As Exception

        End Try
        dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
        dr_aux.Item("comuna") = dr.Item("comuna")
        dr_aux.Item("estado") = dr.Item("estado")

        Try
            dr_aux.Item("Numero_Recepcion_Walmart") = dr.Item("numero_recepcion_walmart").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        Try
            dr_aux.Item("tipoVenta") = dr.Item("tipoVenta").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        ''aqui
        Try
            dr_aux.Item("moneda") = dr.Item("moneda").ToString
            dr_aux.Item("tasa") = dr.Item("paridad").ToString
        Catch ex As Exception

        End Try

        ''Debo llamar al SP para que calcule el impuesto de distribucion
        '(c) 20150911
        Try
            Dim lsSQL As String
            Dim clsgen As New ClasesGenerales.General
            lsSQL = "spa_AddImptoDistribDetalle '" & dr_aux.Item("empresa").ToString & "','" & dr_aux.Item("TipoDocto") & "'," & dr_aux.Item("correlativo")
            '  clsgen.insertQuery("FlexLine", lsSQL)
            clsgen = Nothing
        Catch ex As Exception

        End Try


        'Llenar UsuarioModif
        '(c) 20190117
        Try
            dr_aux.Item("usuarioModif") = dr.Item("UsuarioModif").ToString

        Catch ex As Exception

        End Try

        Try

            If dr.Table.Columns.Contains("Listaprecio") = True Then

                If dr.Item("Listaprecio") IsNot DBNull.Value Then

                    dr_aux.Item("LisPrecio") = dr.Item("Listaprecio")

                Else

                    dr_aux.Item("LisPrecio") = ""

                End If

            End If

            If dr.Table.Columns.Contains("F_FLETE") = True Then

                If dr.Item("F_FLETE") IsNot DBNull.Value Then

                    dr_aux.Item("F_FLETE") = dr.Item("F_FLETE")
                    dr_aux.Item("F_SEGURO") = dr.Item("F_SEGURO")
                    dr_aux.Item("FLETE") = dr.Item("FLETE")
                    dr_aux.Item("SEGURO") = dr.Item("SEGURO")

                End If

            End If

            If dr.Item("SerieFace") IsNot DBNull.Value Then

                dr_aux.Item("Serie") = "Credito"
                dr_aux.Item("SerieFace") = dr.Item("SerieFace")
                dr_aux.Item("NumeroAutFace") = dr.Item("NumeroAutFace")
                dr_aux.Item("FechaFace") = dr.Item("FechaFace")
                dr_aux.Item("NoAutFel") = dr.Item("NoAutFel")
                dr_aux.Item("NoSerieFel") = dr.Item("NoSerieFel")

            End If

        Catch ex As Exception

        End Try

        odsFACE.Tables("pedidos").Rows.Add(dr_aux)

    End Sub


    Private Sub send_enviosPendientesNCFACE(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet)
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt, dtPermisos As DataTable
        Dim drv As DataRowView
        Dim dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt, lsFiltro As String
        Dim iCount As Integer
        'Dim odsFACE As New DataSet

        'odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
        clGen.Escribir_Log(ls_sqltxt)
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like '%Credito%'"



            ''Armar_Filtro
            'ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_FACTURADOR_PEDID',NULL"
            'dt = oTrans.Obtiene(ls_sqltxt)

            'dt.DefaultView.RowFilter = "CODIGO = '" & psEmpresa & "'"
            'dtPermisos = dt.DefaultView.ToTable.Copy


            '
            For Each dr As DataRowView In oTabla.DefaultView



                If dr.Item("fechaenvio") = "01/01/1900" And _
                    (dr.Item("tipodocto").ToString = "NOTA CREDITO FACE" _
                    And dr.Item("total")) > 0 Then

                    dr_aux = odsFACE.Tables("pedidos").NewRow

                    Try
                        dr_aux.Item("Enviar") = 0
                        If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
                    Catch ex As Exception

                    End Try

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
                    dr_aux.Item("procesado") = 0
                    Try
                        If dr.Item("TipoDocto").ToString.ToUpper = "NOTA CREDITO FACE" Then
                            dr_aux.Item("MaquinaFACE") = 1
                            'ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
                            '    dr_aux.Item("MaquinaFACE") = 2
                        End If
                    Catch ex As Exception

                    End Try
                    dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
                    odsFACE.Tables("pedidos").Rows.Add(dr_aux)
                End If


            Next

            '(c) ya no llena esta info por que la trae de las facturas (c)
            'ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & psFecha & "','" & psFecha & "','" & psEmpresa & "'"
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "detalle_pedidos"

            'odsFACE.Tables.Add(oTabla.Copy)
            '' clGen.Escribir_Log(ls_sqltxt)
            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)
        Catch ex As Exception
            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)
            'MessageBox.Show(ex.Message)
        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
        End Try


    End Sub


    ' Generar Informacion para Envio a GuateFacturas
    Public Sub generarInformacion(ByRef odsface As DataSet, ByRef odsXML As DataSet, pdFechaProceso As Date, pdFechaAdicional As Date)

        Try

            odsface = New DataSet
            odsXML = New DataSet
            Dim lsArchivo As String = String.Empty
            crear_estructuraFACE(odsface)
            send_enviosPendientesFACE(gsEmpresa, pdFechaProceso, odsface, pdFechaAdicional)

        Catch ex As Exception
        Finally
        End Try

    End Sub

    Public Sub generarInformacionFEL(ByRef odsface As DataSet, ByRef odsXML As DataSet, pdFechaProceso As Date, pdFechaAdicional As Date)

        Try

            odsface = New DataSet
            odsXML = New DataSet
            Dim lsArchivo As String = String.Empty
            crear_estructuraFACE(odsface)
            PedidosPendientesFEL(gsEmpresa, pdFechaProceso, odsface, pdFechaAdicional)

        Catch ex As Exception
        Finally
        End Try

    End Sub


    Public Sub generarInformacionFEL_Emision(ByRef odsface As DataSet, ByRef odsXML As DataSet, pdFechaProceso As Date, pdFechaAdicional As Date)

        Try

            odsface = New DataSet
            odsXML = New DataSet
            Dim lsArchivo As String = String.Empty
            crear_estructuraFACE(odsface)
            DocumentospendientesEmisionFEL(gsEmpresa, pdFechaProceso, odsface, pdFechaAdicional)

        Catch ex As Exception
        Finally
        End Try

    End Sub

    ' Obtiene Informacion Generada en GuateFacturas
    Public Sub obtenerInformacion()
        Dim sUsuario As String = "GUATE_FTP"
        Dim sRutaZip As String

        'For Each sempresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")
        Dim dFechaProceso As Date = Today

        Dim odsFACE As New DataSet

        Try

            crear_estructuraFACE(odsFACE)
            obtenerProcesadosGuateFacturas(gsEmpresa)
            extraerzipFACE(gsEmpresa, sRutaZip, sUsuario, odsFACE, dFechaProceso)
        Catch ex As Exception

        End Try

        'Next
    End Sub


    Public Sub limpiarInformacion()
        'For Each sempresa As String In "DMARTE1,CODICASA,DIUVA".Split(",")

        Try
            Me.LimpiarProcesadosGuateFacturas(gsEmpresa)
            'crear_estructuraFACE(odsFACE)
            'obtenerProcesadosGuateFacturas(sempresa)
            'extraerzipFACE(sempresa, sRutaZip, sUsuario, odsFACE, dFechaProceso)
        Catch ex As Exception

        End Try

        'Next
    End Sub

    'Extrae la Informacion de los Archivos Generados por Guatefacturas
    Private Sub extraerzipFACE(ByVal psEmpresa As String, ByRef psRutaZip As String, ByRef psUsuario As String, ByVal odsFace As DataSet, ByRef psFecha As Date)

        Dim ClsGen As New ClasesGenerales.General
        Dim lsRuta As String
        Dim lsArchivos() As String
        psRutaZip = String.Empty

        Try
            lsRuta = "C:\aplicaciones\Guatefacturas Receive\" & psEmpresa

            lsArchivos = Directory.GetFiles(lsRuta, "*.zip")
            If lsArchivos.Length = 1 Then
                '                MessageBox.Show("No Puede Haber Mas de un Archivo ZIP en " & Chr(13) & Me.txtRuta.Text, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf lsArchivos.Length > 1 Then 'Debe venir uno con nombre Ok
                For Each lsarchivo As String In lsArchivos

                    If lsarchivo.IndexOf("OK") > 0 Then 'Si Tengo el Archivo Ok, Proceso el 
                        'ClsGen.Descomprimir_Archivo(lsArchivos(0), lsRuta)
                        ClsGen.Descomprimir_Archivo(lsarchivo.Replace("-OK", String.Empty), lsRuta & "\Proceso")
                        'Dim di As New DirectoryInfo(lsRuta & "\app")
                        Dim di As New DirectoryInfo(lsRuta & "\Proceso")
                        Dim fics() As FileInfo
                        fics = di.GetFiles("*.txt", SearchOption.AllDirectories)
                        Dim lsTextos As String() = Directory.GetFiles(lsRuta & "\Proceso", "*.txt")
                        'MessageBox.Show(fics(0).FullName)
                        'If fics.Length = 2 Then
                        If lsTextos.Length = 2 Then
                            For Each lstexto As String In lsTextos
                                If lstexto.IndexOf("ERR") > -1 Then
                                    'psRutaZip = fics(0).FullName
                                    psRutaZip = lstexto.Replace("-ERR", String.Empty)
                                    generarFACEFlexLine(psEmpresa, psUsuario, psRutaZip, odsFace, psFecha)
                                    ClsGen.Eliminar_Archivo(lstexto)
                                    ClsGen.Eliminar_Archivo(psRutaZip)
                                    moverArchivosFACEEspecifico(psEmpresa, "Receive", lsarchivo)
                                    moverArchivosFACEEspecifico(psEmpresa, "Receive", lsarchivo.Replace("-OK", String.Empty))
                                End If


                            Next
                        Else
                            For Each lstexto As String In lsTextos

                                'psRutaZip = lstexto
                                procesarErrorFACE(psEmpresa, psUsuario, lstexto, odsFace, psFecha)
                                ClsGen.Eliminar_Archivo(lstexto)
                                moverArchivosFACEEspecifico(psEmpresa, "Err", lsarchivo)
                                moverArchivosFACEEspecifico(psEmpresa, "Err", lsarchivo.Replace("-OK", String.Empty))
                            Next

                        End If
                    End If
                Next
            Else
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("Extraer Zip " & ex.ToString)
        Finally
            ClsGen = Nothing

        End Try


    End Sub

    Private Sub procesarErrorFACE(ByRef psEmpresa As String, ByRef psUsuario As String, _
                           psRutaZip As String, ByVal odsFace As DataSet, ByRef psFecha As Date)


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsrutaGenera As String
        Dim dtDocumentos As DataTable


        Try

            Otrans.open()

            Dim sArchivo As String = psRutaZip
            Dim sLineas, sDetalle, Sdocumento As String()
            Dim sr As New System.IO.StreamReader(sArchivo)

            lsrutaGenera = sr.ReadToEnd()
            sr.Close()


            lsSQL = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
            dtDocumentos = Otrans.Obtiene(lsSQL)

            sLineas = lsrutaGenera.Split(Chr(10))
            For Each sLinea As String In sLineas
                If sLinea.Length > 0 Then
                    sDetalle = sLinea.Split("|")
                    If sDetalle.Length = 6 Then 'Solo Trae 6 Lineas cuando se pasa primero el archivo Ok y luego el de Datos
                        Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5), 31)
                        limpiarLote(sArchivo.Split("-")(1), Otrans)
                    ElseIf sDetalle.Length = 24 Then
                        If sDetalle(4) = "2" Then 'Problemas con el Nit
                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14), 31)
                            Sdocumento = sDetalle(14).Split("-")
                            dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
                            If dtDocumentos.DefaultView.Count = 1 Then
                                lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                                    Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
                                Otrans.Actualiza(lsSQL)
                            End If
                            limpiarLote(sArchivo.Split("-")(1), Otrans)
                        ElseIf sDetalle(4) = "57" Then 'Archivo Duplicado
                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14), 31)

                            Try
                                Sdocumento = sDetalle(14).Split("-")
                                dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
                                If dtDocumentos.DefaultView.Count = 1 Then
                                    lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                                        Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
                                    Otrans.Actualiza(lsSQL)
                                End If
                            Catch ex As Exception
                            End Try
                        ElseIf sDetalle(4) = "15" Then 'Documento Enviados No Existen
                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14), 31)

                            Try
                                Sdocumento = sDetalle(14).Split("-")
                                dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
                                If dtDocumentos.DefaultView.Count = 1 Then
                                    lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                                        Sdocumento(0) & "','" & Sdocumento(1) & "','" & sDetalle(5) & "'"
                                    Otrans.Actualiza(lsSQL)
                                End If
                            Catch ex As Exception
                            End Try

                        ElseIf sDetalle(4) = "40" Then 'Tipo Documento No Existe
                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Problema " & sDetalle(5) & "  " & sDetalle(14), 31)
                        Else
                            Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Error Desconocido " & sDetalle(4) & sDetalle(5), 31)
                        End If
                    Else
                        Me.guardarAviso(" Lote " & sArchivo.Split("-")(1) & " Error Desconocido", 31)
                    End If
                End If
            Next



        Catch ex As Exception
            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub limpiarLote(psLote As String, Otrans As Transaccional.Conexion)
        Dim dt As DataTable
        Dim lsSQL As String
        Try
            lsSQL = "pa_sel_um_gen_log_documento_FACE_lote '" & psLote & "'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                lsSQL = "pa_del_um_gen_log_documento_face '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'"
                Otrans.Elimina(lsSQL)
            Next

        Catch ex As Exception

        End Try
    End Sub

    'Inserta las facturas generadas en GUATEFACTURA en FlexLine

    Public Sub generarFACEFlexLineXML(ByRef psEmpresa As String, ByRef psUsuario As String, _
                           psRutaZip As String, ByVal odsFace2 As DataSet, ByRef psFecha As Date, _
                           psArchivo As String, ByRef psFechaAdicional As Date, _
                           pdFechaFacturacion As Date, psInformacionPedido As String)


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Otrans.gsnombreLog = "log_" & psEmpresa
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        clsGen.gsNombreInicialLog = "log_" & psEmpresa
        Dim lsrutaGenera As String
        Dim dtDocumentos, dtImpresoras As DataTable
        Dim dr As DataRow

        Dim odsFace As New DataSet

        Try

            Otrans.open()


            Dim lodsXML As New DataSet
            lodsXML.ReadXml(psArchivo)

            odsFace = odsFace2.Copy
            odsFace.Tables("pedidos").Rows.Clear()

            Dim drResultado As DataRow
            If lodsXML.Tables.Contains("Resultado") Then
                drResultado = lodsXML.Tables("Resultado").Rows(0)


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

                                    lsSQL = "pa_upd_um_ctacte_FACE '" & psEmpresa & "','" &
                                        drv.Item("ctacte") & "','" &
                                        drv.Item("nitFACE") & "','" &
                                        drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" &
                                        drv.Item("nombreFACE").ToString.PadRight(100, " ").Substring(50).Replace("'", "") & "','" &
                                        drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(0, 50).Replace("'", "") & "','" &
                                        drv.Item("direccionFACE").ToString.PadRight(100, " ").Substring(50, 50).Replace("'", "") & "','" &
                                        drv.Item("direccionFACE").ToString.PadRight(150, " ").Substring(100, 50).Replace("'", "") & "'"


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

                                        'Si es logiservicios que guarde la factura en PDF

                                        If psEmpresa = "LOGISERV" Then
                                            Dim lsRuta As String = "c:\temp\" & drv.Item("serieFace").ToString & "-" & drv.Item("NumeroFACE").ToString & ".PDF"
                                            Dim lsCuentasCorreo As String = ""

                                            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                                True, False, "PDF", False, lsRuta, True, ncopias, psEmpresa, drv.Item("ImpresoraFACE").ToString)

                                            'Enviar Correo
                                            Dim lsSubject As String = "Emision de Factura Electronica " & drv.Item("NumeroFace").ToString
                                            Dim lsBody As String = "Factura Serie: " & drv.Item("serieFace").ToString &
                                                                   "Factura Numero: " & drv.Item("NumeroFACE").ToString &
                                                                   "Cliente: " & drv.Item("nombreFACE").ToString.PadRight(100, " ")



                                            Try
                                                Dim lsCuentaUsuario As String
                                                Dim dtUsuario As DataTable
                                                dtUsuario = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drv.Item("UsuarioModif") & "'")
                                                Try
                                                    lsCuentaUsuario = dtUsuario.Rows(0).Item("correo").ToString
                                                    lsCuentasCorreo = dtUsuario.Rows(0).Item("correo").ToString
                                                Catch ex As Exception
                                                    lsCuentasCorreo = "face@logiservicios.com"
                                                End Try



                                            Catch ex As Exception
                                                lsCuentasCorreo = "face@logiservicios.com"
                                            End Try



                                            clsGen.enviarcorreo("notificacion@umbralcorp.com", "Factura Electronica", lsCuentasCorreo,
                                                                lsSubject, lsBody, lsRuta)

                                        Else


                                            If ncopias > 0 Then
                                                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                                    False, True, "PDF", False, "", True, ncopias, psEmpresa, drv.Item("ImpresoraFACE").ToString)
                                            End If
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
                                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                        False, True, "PDF", False, "", True, 1, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)


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
                                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                        False, True, "PDF", False, "", True, 1, psEmpresa, drv.Item("ImpresoraFACE").ToString)

                                                '(c) 20150522
                                                'Envio 2 veces la impresion por incompatibilidad del server donde esta alojado
                                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                                        False, True, "PDF", False, "", True, 1, psEmpresa, drv.Item("ImpresoraFACE").ToString)

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
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(psArchivo)


                ' Now create StringWriter object to get data from xml document.
                Dim sw As New StringWriter()
                Dim xw As New XmlTextWriter(sw)
                xmlDoc.WriteTo(xw)
                Dim XmlString As String = sw.ToString()


                'Almacenar Informacion del Error

                'psInformacionPedido

                lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                        psInformacionPedido.ToString.Split("-")(0) & "','" & _
                        psInformacionPedido.ToString.Split("-")(1) & "','" & _
                        XmlString.Substring(XmlString.IndexOf("<Resultado>")).ToString.Replace("Resultado>", "").Replace("<", "") & "'"


                'drResultado.Item("Referencia").ToString.Split("-")(0) & "','" & drResultado.Item("Referencia").ToString.Split("-")(1) & "','Diferencia En Los Totales Flex-GuateFacturas'"
                Otrans.Actualiza(lsSQL)


            End If 'lodsXML.Tables.Contains("Resultado")
        Catch ex As Exception
            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub pruebaImpresion(psEmpresa As String, psSerie As String, psNumero As String)
        Dim dtImpresoras As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim pm_valores(3), pm_valores_consolidado(2) As String
        Dim pm_parametros(3) As String
        Dim pm_conexion(3) As String
        Dim lsImpresora As String = ""


        pm_conexion = clsGen.Parametros_Conexion("")
        Dim ppath_reporte As String = clsGen.Path_Reporte

        ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
        ppath_reporte += psEmpresa.ToLower.Trim + " "
        ppath_reporte += psSerie 'drv.Item("serieFACE").ToString.Trim
        ppath_reporte += ".rpt"
        pm_parametros(0) = "empresa"
        pm_parametros(1) = "tipodocto"
        pm_parametros(2) = "numero"
        pm_parametros(3) = "user_name"
        pm_valores(0) = psEmpresa
        pm_valores(1) = psSerie 'drv.Item("serieFACE")
        pm_valores(2) = psNumero 'drv.Item("numeroFACE")
        pm_valores(3) = "GUATE_FTP"

        'Guardo las copias en pdf

        Dim ncopias As Integer = 1
        'ncopias = clsGen.numeroCopias(psEmpresa, drv.Item("ctacte"), drv.Item("forma_pago").ToString, _
        '                              IIf(drv.Item("tipodoctoOrigen").ToString.LastIndexOf("RE") > 0, 1, 0), drv.Item("serieFACE"))


        ''Revisar Impresora a Imprimir

        Try

            dtImpresoras = clsGen.selectQuery("FlexLine", _
                                              "pa_sel_um_gen_tabcod '" & "PEDIDO FACE" & "','gen_impresion','" & psEmpresa & "'")

            If dtImpresoras.Rows.Count = 1 Then
                If dtImpresoras.Rows(0).Item("valor1") = 1 Then
                    'drv.Item("ImpresoraFACE") = dtImpresoras.Rows(0).Item("Texto")
                    lsImpresora = dtImpresoras.Rows(0).Item("Texto")
                End If


            End If
        Catch ex As Exception

        End Try


        'If drv.Item("bodegaInterEmpresas").ToString.Trim.Length > 0 Then ncopias = 1

        If ncopias > 0 Then
            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                False, True, "PDF", False, "", True, ncopias, psEmpresa, lsImpresora)


        End If
    End Sub


    Private Sub generarFACEFlexLine(ByRef psEmpresa As String, ByRef psUsuario As String, _
                            psRutaZip As String, ByVal odsFace As DataSet, ByRef psFecha As Date)


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsrutaGenera As String
        Dim dtDocumentos, dtImpresoras As DataTable
        Dim dr As DataRow


        Try

            Otrans.open()

            Dim sArchivo As String = psRutaZip

            Dim sLineas, sDetalle, Sdocumento As String()


            Dim sr As New System.IO.StreamReader(sArchivo)
            lsrutaGenera = sr.ReadToEnd()
            sr.Close()

            odsFace.Tables("pedidos").Rows.Clear()

            lsSQL = "pa_sel_um_tipodocumento_guatefacturaPURA '" & psEmpresa & "','" & psFecha & "','" & psFecha & "'"
            dtDocumentos = Otrans.Obtiene(lsSQL)

            sLineas = lsrutaGenera.Split(Chr(10))
            For Each sLinea As String In sLineas
                If sLinea.Length > 0 Then
                    sDetalle = sLinea.Split("|")
                    Sdocumento = sDetalle(8).Split("-")
                    dtDocumentos.DefaultView.RowFilter = "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero = '" & Sdocumento(1) & "'"
                    If dtDocumentos.DefaultView.Count = 1 Then

                        If Math.Abs(dtDocumentos.DefaultView(0).Item("total") - sDetalle(5)) > 0.1 Then
                            clsGen.Escribir_Log("Problemas con los totales en el Documento " & psEmpresa & " " & Sdocumento(0) & " " & Sdocumento(1) & " " &
                                                 sDetalle(2) & " " & sDetalle(3))
                            Me.guardarAviso("Problemas con los totales en el Documento  " & psEmpresa & " " & Sdocumento(0) & " " & Sdocumento(1) & " " &
                                                 sDetalle(2) & " " & sDetalle(3), 31)

                            lsSQL = "pa_upd_um_gen_log_documento_face_proceso_comentario '" & psEmpresa & "','" & _
                                       Sdocumento(0) & "','" & Sdocumento(1) & "','Diferencia En Los Totales Flex-GuateFacturas'"
                            Otrans.Actualiza(lsSQL)
                        Else
                            dr = odsFace.Tables("pedidos").NewRow
                            dr.Item("tipoDoctoOrigen") = Sdocumento(0)
                            dr.Item("numero") = Sdocumento(1)
                            dr.Item("fechaFACE") = sDetalle(1).Substring(6, 2) & "/" & sDetalle(1).Substring(4, 2) & "/" & sDetalle(1).Substring(0, 4) 'añomesdia
                            dr.Item("serieFACE") = sDetalle(2)
                            dr.Item("numeroFACE") = sDetalle(3)
                            dr.Item("firmaFACE") = sDetalle(7)
                            dr.Item("nitFACE") = sDetalle(4)
                            dr.Item("nombreFACE") = sDetalle(9)
                            dr.Item("direccionFACE") = sDetalle(10)
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
                        End If
                    Else
                        clsGen.Escribir_Log("Filtro " & "tipoDoctoOrigen = '" & Sdocumento(0) & "' And numero '" & Sdocumento(1) & "'")
                    End If
                End If
            Next

            odsFace.Tables("pedidos").DefaultView.RowFilter = ""

            For Each drv As DataRowView In odsFace.Tables("pedidos").DefaultView

                If drv.Item("numeroFACE").ToString.Trim.Length > 0 Then
                    ''Creamos los documentos FACE
                    lsSQL = "pa_ins_um_documento_FACE '" & psEmpresa & "','" & _
                            drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "','" & _
                            drv.Item("serieFACE") & "','" & drv.Item("numeroFACE") & "','" & _
                            drv.Item("firmaFACE").ToString.PadRight(100, " ") & "','" & psEmpresa & "','" & _
                            Date.Parse(drv.Item("fechaFACE").ToString).ToString("dd-MM-yyyy") & "'"


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
                        If drv.Item("tipodoctoOrigen").ToString.ToLower.IndexOf("walmart") > 0 Then
                            'Los Pedidos de WalMart No deben Generar Picking por eso se llena la Informacion con picker en Blanco
                            lsSQL = "pa_ins_um_gen_log_documento_tracking  '" & _
                                        drv.Item("empresa") & "','" & drv.Item("serieFACE") & _
                                        "','" & drv.Item("numeroFACE") & "','" & psUsuario & "','" & _
                                          "', NULL"
                            Otrans.Ingresa(lsSQL)
                            If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)
                        End If
                        lsSQL = "pa_upd_um_gen_log_documento_face_proceso '" & psEmpresa & "','" & _
                                drv.Item("tipodoctoOrigen") & "','" & drv.Item("numero") & "'"

                        Otrans.Actualiza(lsSQL)
                        If Otrans.Codigo_error > 0 Then guardarAviso(Otrans.descripcion_error, 31)


                        If drv.Item("tipodocto").ToString.ToLower.StartsWith("pedido consol") Then
                            ''Debo correr el Script del pedido Consolidad0
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
                                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, True, "PDF", False, "", True, ncopias, psEmpresa, drv.Item("ImpresoraFACE").ToString)
                            End If


                            '                        _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
                            'pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                            '    False, True, "PDF", False, "", True, 3, psEmpresa, drv.Item("ImpresoraFACE").ToString)

                            'clsGen.Escribir_Log(drv.Item("bodegaInterEmpresas").ToString)
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
                                    pm_valores2(1) = "FACE DE COMPRAS" '' drv.Item("serieFACE")
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

                                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                            False, True, "PDF", False, "", True, 2, pm_valores2(0), drv.Item("ImpresoraFACE").ToString)


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

                                    _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                            False, True, "PDF", False, "", True, 2, psEmpresa, drv.Item("ImpresoraFACE").ToString)


                                    'Guardar Copia Electronica del Recibo
                                    'Dim lsRutaCopia As String = clsGen.Path_Imagenes
                                    'lsRutaCopia += "Recibos\" + psEmpresa + "\" + drv.Item("serieFACE") + "-" + drv.Item("numeroFACE")


                                    '_reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                                    '        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    '        True, False, "PDF", False, lsRutaCopia, True, 1, psEmpresa, "")

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
            Next


        Catch ex As Exception
            clsGen.Escribir_Log("Generar FACE " & ex.ToString)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub moverArchivosFACE(psEmpresa As String, ByRef psTipo As String)

        Dim clsGen As New ClasesGenerales.General
        Dim lsArchivos() As String
        Try

            Dim lsRuta As String = "C:\aplicaciones\Guatefacturas " & psTipo & "\" & psEmpresa

            If Not Directory.Exists(lsRuta & "\" & Today.ToString("yyyyMM")) Then 'Si el Directorio Año Mes No Existe lo tengo que crear
                System.IO.Directory.CreateDirectory(lsRuta & "\" & Today.ToString("yyyyMM"))
            End If

            lsArchivos = Directory.GetFiles(lsRuta, "*.*") 'Muevo los archivos para Log en Mes Año
            For Each lsArchivo As String In lsArchivos
                clsGen.Mover_Archivo(lsArchivo, lsRuta & "\" & Today.ToString("yyyyMM") & "\" & lsArchivo.Split("\").GetValue(lsArchivo.Split("\").LongLength - 1))
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub moverArchivosFACEEspecifico(psEmpresa As String, ByRef psTipo As String, psArchivo As String)

        Dim clsGen As New ClasesGenerales.General
        Try
            Dim lsRuta As String = "C:\aplicaciones\Guatefacturas " & psTipo & "\" & psEmpresa

            If Not Directory.Exists(lsRuta & "\" & Today.ToString("yyyyMM")) Then 'Si No Existe el Archivo Años Mes lo Creo
                System.IO.Directory.CreateDirectory(lsRuta & "\" & Today.ToString("yyyyMM"))
            End If

            'Muevo El Archivo Especifico
            clsGen.Mover_Archivo(psArchivo, lsRuta & "\" & Today.ToString("yyyyMM") & "\" & psArchivo.Split("\").GetValue(psArchivo.Split("\").LongLength - 1))


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    'Obtiene Informacion Procesada en GuateFacturas
    Private Sub obtenerProcesadosGuateFacturas(ByRef psEmpresa As String)
        Dim lsRutaArchivos As String
        Dim ClsGen As New ClasesGenerales.General


        lsRutaArchivos = "C:\Aplicaciones\Guatefacturas Receive\" & psEmpresa
        'lsRutaArchivos = "C:\Aplicaciones"
        Dim sarchivos As String()

        ClsGen.Escribir_Log("Obtener Procesados Guatefacturas " & psEmpresa)


        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim lb_regresa As Boolean = False


        otrans.open()
        otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('face_" & psEmpresa.ToLower & "')") 'Obtengo los parametros deacuerdo a la empresa
        otrans.close()
        otrans = Nothing

        Dim ff As New FTP.clsFTP
        With otabla.Rows(0)
            ff.RemoteHost = .Item("host")
            ff.RemoteUser = .Item("usuario")
            ff.RemotePassword = .Item("password")
        End With


        Try


            If (ff.Login()) Then
                ff.ChangeDirectory("Archivos_XML_CAE") 'Directorio en donde estan los archivos procesados
                '    ' ff.ChangeDirectory("Download")
                ff.SetBinaryMode(True)


                sarchivos = ff.GetFileList("*.zip") 'Obtengo todos los archivo ZIP
                For icount As Integer = 0 To sarchivos.Length - 1
                    If sarchivos(icount).ToLower.IndexOf("zip") > 0 And Not sarchivos(icount).ToLower.StartsWith("_") Then
                        ff.DownloadFile(sarchivos(icount).Trim, lsRutaArchivos & "\" & sarchivos(icount).Trim)
                        ff.RenameFile(sarchivos(icount).Trim, "_" & sarchivos(icount).Trim.Replace("zip", "pro")) 'Renombro los archivos para no volverlos a bajar y que la extension sea diferente para que no hayan muchos
                    End If
                Next
            End If ''Existe Archivo .txt

        Catch ex As System.Exception            '        
        Finally
            ff.CloseConnection()
            ff = Nothing
            ClsGen = Nothing
        End Try


    End Sub


    Public Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
       ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
       ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean, _
       ByVal _nombre_archivo As String, ByVal mostrarError As Boolean, ByVal nCopias As Integer, ByVal psEmpresa As String, _
       ByVal psImpresora As String) As Boolean
        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt(psEmpresa)
        If _nombre_archivo.Length > 0 Then
            Oaut.Archivo_Generado = _nombre_archivo
        End If
        Oaut.pnNumeroCopias = nCopias

        If psImpresora.Length > 0 Then
            Oaut.psImpresora = psImpresora.Split(",")(0)
            Oaut.psPort = psImpresora.Split(",")(1)
        End If

        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)

        If Oaut.Descripcion_Error.Length > 0 Then
            If mostrarError Then
                Dim clsGen As New ClasesGenerales.General
                guardarAviso("Problemas al Imprimir " & pm_valores(1) & " " & pm_valores(2) & " " & Oaut.Descripcion_Error, 31)
                clsGen.Escribir_Log(Oaut.Descripcion_Error)
                clsGen = Nothing
            End If
            valorRegreso = False
        End If

        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()
        Return valorRegreso
    End Function

    Public Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, _
    ByVal _pmostrar_archivo As Boolean, ByVal _nombre_archivo As String, ByVal mostrarError As Boolean, ByVal nCopias As Integer) As Boolean
        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt("")
        If _nombre_archivo.Length > 0 Then
            Oaut.Archivo_Generado = _nombre_archivo
        End If
        Oaut.pnNumeroCopias = nCopias
        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)

        If Oaut.Descripcion_Error.Length > 0 Then
            If mostrarError Then
                'MessageBox.Show("Oaut._Reporte Generico " & Oaut.Descripcion_Error)
            End If
            valorRegreso = False
        End If

        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()
        Return valorRegreso
    End Function

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


    Private Sub LimpiarProcesadosGuateFacturas(ByRef psEmpresa As String)
        Dim lsRutaArchivos As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            lsRutaArchivos = "C:\Aplicaciones\LOG\" & psEmpresa & "\" & Today.ToString("yyyyMM")
            'lsRutaArchivos = "C:\Aplicaciones"
            Dim sarchivos As String()

            ClsGen.Escribir_Log("Limpiar Procesados Guatefacturas " & psEmpresa)


            Dim otabla As DataTable
            Dim otrans As New Transaccional.Conexion_mysql("onBase")
            Dim lb_regresa As Boolean = False


            otrans.open()
            otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('face_" & psEmpresa.ToLower & "')") 'Obtengo los parametros deacuerdo a la empresa
            otrans.close()
            otrans = Nothing

            Dim ff As New FTP.clsFTP
            With otabla.Rows(0)
                ff.RemoteHost = .Item("host")
                ff.RemoteUser = .Item("usuario")
                ff.RemotePassword = .Item("password")
            End With


            Try


                If (ff.Login()) Then
                    ClsGen.Escribir_Log("Limpiar Procesados Login")
                    ff.ChangeDirectory("Archivos_XML_CAE") 'Directorio en donde estan los archivos procesados
                    '    ' ff.ChangeDirectory("Download")
                    ff.SetBinaryMode(True)


                    sarchivos = ff.GetFileList("*.*") 'Obtengo todos los archivo ZIP
                    ClsGen.Escribir_Log("Archivos Log " & sarchivos.Length)
                    For icount As Integer = 0 To sarchivos.Length - 1
                        If sarchivos(icount).ToLower.IndexOf("pro") > 0 Then 'And Not sarchivos(icount).ToLower.StartsWith("_") Then
                            ClsGen.Escribir_Log("DownLoad " & lsRutaArchivos & "\" & sarchivos(icount).Trim)
                            ff.DownloadFile(sarchivos(icount).Trim, lsRutaArchivos & "\" & sarchivos(icount).Trim)
                            'ff.RenameFile(sarchivos(icount).Trim, "_" & sarchivos(icount).Trim.Replace("zip", "pro")) 'Renombro los archivos para no volverlos a bajar y que la extension sea diferente para que no hayan muchos
                            ff.DeleteFile(sarchivos(icount).Trim)

                        End If
                    Next
                End If ''Existe Archivo .txt

            Catch ex As System.Exception            '        
                ClsGen.Escribir_Log("Limpiar Procesados " & psEmpresa & " Login" & ex.ToString)
            Finally
                ff.CloseConnection()
                ff = Nothing
                ClsGen = Nothing
            End Try

        Catch ex As Exception
            ClsGen.Escribir_Log("Limpiar Procesados " & psEmpresa & " " & ex.ToString)
        Finally

        End Try

    End Sub

End Class
#End Region



#Region "La Incondicional "

Public Class comprasInterempresa
    Public Sub New()

    End Sub

    '(c) 20231107 Vinoteca vende sin inventario propio, esta ruta compra lo necesrio en una fecha especifica
    Public Sub verificarStockVINOTECA(ByRef psfecha As String)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dtStock As DataTable
        Dim liPedir As Integer = 0
        Dim ods_listado As New DataSet
        Dim ods As New DataSet
        Dim lsempresaCOMPRA As String = "VINOTECA"
        Dim lsusuarioCOMPRA As String = clsGen.Obtener_XMLConfig("comprador_vinoteca_premium", False).ToString.ToUpper 'JESTRADA"
        Dim lsbodegaCOMPRA As String = clsGen.Obtener_XMLConfig("bodega_vinoteca_premium", False).ToString.ToUpper 'JESTRADA"

        Try
            crear_estructura_auxiliar(ods, ods_listado, lsempresaCOMPRA)
            ods_listado.Tables("listado").Rows.Clear()

            dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_vinoteca '" & psfecha & "'")



            For Each dr As DataRow In dt.Rows
                liPedir = 0
                dtStock = Oflex.Obtener_Existencias(lsempresaCOMPRA, dr.Item("producto"), lsbodegaCOMPRA)

                If dtStock.Rows.Count > 0 Then
                    If dtStock.Rows(0).Item("existencia") <= 0 Then
                        liPedir = dr.Item("cantidad")
                    ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                        ''Pedir la diferencia
                        liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                    End If
                Else
                    'Pedir completo
                    liPedir = dr.Item("cantidad")
                End If

                '
                If liPedir > 0 Then
                    Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

                    drAux.Item("producto") = dr.Item("producto")
                    Try
                        drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")
                    Catch ex As Exception
                        Dim dtProducto As DataTable
                        dtProducto = Oflex.Obtener_Producto(lsempresaCOMPRA, dr.Item("producto"))
                        If dtProducto.Rows.Count > 0 Then
                            drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
                        End If
                    End Try
                    drAux.Item("sugerido") = liPedir
                    ods_listado.Tables("listado").Rows.Add(drAux)

                End If
            Next

            If ods_listado.Tables("listado").Rows.Count > 0 Then
                Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "proveedor".Split(","))
                For Each dr As DataRow In dtProveedores.Rows

                    Dim sEmpresaCompra As String = String.Empty
                    Dim ctacte As String
                    If dr.Item("proveedor") = "CODICASA" Then
                        sEmpresaCompra = "CODICASA"
                        ctacte = "79512"
                    ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
                        sEmpresaCompra = "DMARTE1"
                        ctacte = "122183"
                    ElseIf dr.Item("proveedor") = "DIUVA" Then
                        sEmpresaCompra = "DIUVA"
                        ctacte = "6608388"

                    End If

                    If sEmpresaCompra.Length > 0 Then


                        Preparar_Factura(1, lsempresaCOMPRA, lsusuarioCOMPRA, dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado, lsbodegaCOMPRA)


                        dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega '" & lsempresaCOMPRA & "','SOLICITUD O/COMPRA','" & lsusuarioCOMPRA & "'")
                        Dim pcomprador As String = "GABRIELA BARRIOS"
                        If dt.Rows.Count > 0 Then
                            pcomprador = dt.Rows(0).Item("comprador")
                            ctacte = dt.Rows(0).Item("cliente")
                        End If


                        Dim aa As String
                        Try

                            Guardar_Documento(ods, sEmpresaCompra, ctacte, pcomprador, aa, lsusuarioCOMPRA, lsbodegaCOMPRA)
                        Catch ex As Exception

                        End Try


                    End If


                Next
            End If

        Catch ex As Exception
        End Try


    End Sub


    '(c) 20231107 La incondicional vende sin inventario propio, esta ruta compra lo necesrio en una fecha especifica
    Public Sub verificarStockLAINCONDICIONAL()

        '(c)
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dtStock As DataTable
        Dim liPedir As Integer = 0
        Dim ods_listado As New DataSet
        Dim lsEmpresaCOMPRA As String = "LAINCONDI"
        Dim lsUsuarioCOMPRA As String = clsGen.Obtener_XMLConfig("comprador_laincondicional", False).ToString.ToUpper 'JESTRADA"

        Dim ods As New DataSet
        Dim sCedi As String
        Dim sCentrosDistribucion As String = "CD_CENTRAL,CDR_ANTIGUA,CDR_XELA,CDR_ORIENTE"
        'sCentrosDistribucion = "CD_CENTRAL,"

        Try

            For Each sBodega As String In sCentrosDistribucion.Split(",")

                dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega 'laincondi','SOLICITUD O/COMPRA','" & lsUsuarioCOMPRA & "'")
                Dim pcomprador As String
                Dim ctacte As String
                If dt.Rows.Count > 0 Then
                    pcomprador = dt.Rows(0).Item("comprador")
                    ctacte = dt.Rows(0).Item("cliente")
                End If


                If sBodega = "CDR_ANTIGUA" Then
                    sCedi = "AG"
                    ctacte = "1187845402"
                ElseIf sBodega = "CDR_XELA" Then
                    sCedi = "XE"
                    ctacte = "1187845401"
                ElseIf sBodega = "CDR_ORIENTE" Then
                    sCedi = "OR"
                    ctacte = "1187845403" '(c) 20240830
                ElseIf sBodega = "CD_CENTRAL" Then
                    sCedi = ""
                    ctacte = "11878454"
                End If

                crear_estructura_auxiliar(ods, ods_listado, lsEmpresaCOMPRA)
                ods_listado.Tables("listado").Rows.Clear()

                'dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_laincondicional '" & Today.ToString("dd-MM-yyyy") & "'")
                dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_laincondicional_cedi '" & Today.AddDays(0).ToString("dd-MM-yyyy") & "','" & sCedi & "'")



                For Each dr As DataRow In dt.Rows
                    liPedir = 0
                    dtStock = Oflex.Obtener_Existencias(lsEmpresaCOMPRA, dr.Item("producto"), sBodega)

                    If dtStock.Rows.Count > 0 Then
                        If dtStock.Rows(0).Item("existencia") = 0 Then
                            liPedir = dr.Item("cantidad")
                        ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                            ''Pedir la diferencia
                            liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                        End If
                    Else
                        'Pedir completo
                        liPedir = dr.Item("cantidad")
                    End If

                    '
                    If liPedir > 0 Then
                        Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

                        drAux.Item("producto") = dr.Item("producto")
                        Try
                            drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")
                        Catch ex As Exception
                            Dim dtProducto As DataTable
                            dtProducto = Oflex.Obtener_Producto(lsEmpresaCOMPRA, dr.Item("producto"))
                            If dtProducto.Rows.Count > 0 Then
                                drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
                            End If
                        End Try
                        drAux.Item("sugerido") = liPedir
                        ods_listado.Tables("listado").Rows.Add(drAux)

                    End If
                Next

                If ods_listado.Tables("listado").Rows.Count > 0 Then
                    Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "proveedor".Split(","))
                    For Each dr As DataRow In dtProveedores.Rows

                        Dim sEmpresaCompra As String

                        If dr.Item("proveedor") = "CODICASA" Then
                            sEmpresaCompra = "CODICASA"
                            'ctacte = "79512"
                        ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
                            sEmpresaCompra = "DMARTE1"
                            'ctacte = "122183"
                        ElseIf dr.Item("proveedor") = "DIUVA" Then
                            sEmpresaCompra = "DIUVA"
                            'ctacte = "6608388"
                        End If

                        Preparar_Factura(1, lsEmpresaCOMPRA, lsUsuarioCOMPRA, dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado, sBodega)


                        Dim aa As String
                        Try
                            Guardar_Documento(ods, sEmpresaCompra, ctacte, pcomprador, aa, lsUsuarioCOMPRA, sBodega)
                        Catch ex As Exception

                        End Try
                    Next
                End If

            Next
        Catch ex As Exception
        End Try


    End Sub

    Private Sub crear_estructura_auxiliar(ByRef ods As DataSet, ByRef ods_listado As DataSet, psEmpresa As String)
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable

        Try
            Otrans.open()
            If Not ods.Tables.Contains("documento") Then

                ls_sql = "pa_var_um_documento_traslado_fecha '" & psEmpresa & "',NULL,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)

                dt.TableName = "documento"
                If ods.Tables.Contains("documento") Then
                    ods.Tables.Remove("documento")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documento").Rows.Clear()
            End If


            ''documentod
            If Not ods.Tables.Contains("documentod") Then
                ls_sql = "pa_var_um_documentod_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentod"
                If ods.Tables.Contains("documentod") Then
                    ods.Tables.Remove("documentod")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentod").Rows.Clear()
            End If


            ''documentov
            If Not ods.Tables.Contains("documentov") Then
                ls_sql = "pa_var_um_documentov_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentov"
                If ods.Tables.Contains("documentov") Then
                    ods.Tables.Remove("documentov")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentov").Rows.Clear()
            End If

            ''documentop
            If Not ods.Tables.Contains("documentop") Then
                ls_sql = "pa_var_um_documentop_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentop"
                If ods.Tables.Contains("documentop") Then
                    ods.Tables.Remove("documentop")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentop").Rows.Clear()
            End If


            ods_listado = New DataSet
            Dim dt2 = New DataTable("listado")
            dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
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

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub



    Private Function Preparar_Factura(ByVal igrupo As Integer, pgs_empresa As String, pgs_usuario As String, pgs_proveedor As String,
                                      pgs_comentarios As String, ByRef ods As DataSet, ByRef ods_listado As DataSet, psBodega As String) As Boolean
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr_aux As DataRow
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim dt, dtProveedor As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim iCount As Integer
        Dim ls_sql, sTipoDocto As String
        Dim dtotal As Double = 0
        Dim correlativo As Integer
        Dim snumero As String = "0000000000001"

        Dim sbodega As String = psBodega '"CD_CENTRAL"
        Dim pComprador As String
        Dim ctacte As String
        Dim sListaPrecio As String
        Dim sEmpresaCompra As String
        ''Dim lsUsuario As String = "CARANA"



        Try

            oTrans.open()

            ls_sql = "pa_sel_um_usuario_bodega '" & pgs_empresa & "','SOLICITUD O/COMPRA','" & pgs_usuario & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            'ods.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                sbodega = dt.Rows(0).Item("bodega")
                pComprador = dt.Rows(0).Item("comprador")
                If psBodega = "CD_PREMIUM" Then
                    ctacte = dt.Rows(0).Item("cliente").ToString
                Else
                    ctacte = dt.Rows(0).Item("clienteAG").ToString
                    sbodega = psBodega
                End If
                'sbodega = dt.Rows(0).Item("ubicacion")
            End If

            sTipoDocto = "ORDEN/COMPRA"

            ls_sql = "pa_sel_um_documento_numero'" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("numero").ToString <> "" Then
                    snumero = dt.Rows(0).Item("numero") + 1
                    If Len(snumero) < 10 Then snumero = snumero.PadLeft(10, "0")
                    'Else
                    '    numero = 1
                End If

            Catch ex As Exception
            End Try


            If pgs_proveedor = "CODICASA" Then
                sEmpresaCompra = "CODICASA"
                ctacte = "79512"
            ElseIf pgs_proveedor = "DISTRIBUIDORA MARTE" Then
                sEmpresaCompra = "DMARTE1"
                ctacte = "122183"
            ElseIf pgs_proveedor = "DIUVA" Then
                sEmpresaCompra = "DIUVA"
                ctacte = "6608388"
            End If

            'If Me.cmb_proveedor.Text <> "DIUVA" Then
            ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & pgs_empresa & "' ,'Proveedor','" & ctacte & "'"
            dtProveedor = oTrans.Obtiene(ls_sql)
            sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")



            ls_sql = "pa_sel_um_documento_correlativo '" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("correlativo").ToString <> "" Then
                    correlativo = dt.Rows(0).Item("correlativo") + 1
                Else
                    correlativo = 1
                End If

            Catch ex As Exception
            End Try


            Dim total As Double = 0



            'crear_estructura_auxiliar(ods)

            ods.Tables("documento").Rows.Clear()
            ods.Tables("documentod").Rows.Clear()

            dr_aux = ods.Tables("documento").NewRow
            dr_aux.Item("empresa") = pgs_empresa
            dr_aux.Item("TipoDocto") = sTipoDocto  '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
            dr_aux.Item("Numero") = snumero 'numero.ToString.PadLeft(13, "0")
            dr_aux.Item("Correlativo") = correlativo
            dr_aux.Item("ctacte") = ""
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
            dr_aux.Item("proveedor") = ctacte
            dr_aux.Item("Local") = sbodega 'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
            dr_aux.Item("Comprador") = pComprador
            dr_aux.Item("FechaVcto") = Today.ToString("dd/MM/yyyy")
            dr_aux.Item("ListaPrecio") = sListaPrecio
            dr_aux.Item("Moneda") = "QUETZALES"
            dr_aux.Item("Paridad") = 1
            dr_aux.Item("Total") = total
            dr_aux.Item("Neto") = total 'dr_aux.Item("Total")
            dr_aux.Item("SubTotal") = total ' dr_aux.Item("Total")
            dr_aux.Item("NetoIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("SubTotalIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("TotalIngreso") = total 'dr_aux.Item("Total")
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0 'ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = "PROVEEDOR"
            dr_aux.Item("IdCtaCte") = ctacte
            dr_aux.Item("glosa") = "" 'Me.txt_observaciones.Text
            dr_aux.Item("Comentario1") = pgs_comentarios 'sTipoDocto & " " & snumero
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N" ''Emitido S para que no puedan realizarle cambios
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now
            'dr_aux.Item("Comentario1") = "" ' Me.txt_observaciones.Text
            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = pgs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")
            dr_aux.Item("Caja") = "" 'gsCaja
            dr_aux.Item("Pago") = 0 'dr_aux.Item("Total")
            dr_aux.Item("IdApertura") = 0
            dr_aux.Item("NetoBimoneda") = 0
            dr_aux.Item("SubTotalBimoneda") = 0
            dr_aux.Item("TotalBimoneda") = 0
            dr_aux.Item("ParidadBimoneda") = 1
            ods.Tables("documento").Rows.Add(dr_aux)


            'ods_listado.Tables("listado").DefaultView.RowFilter = "grupo = " & igrupo

            For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView 'ods.Tables("productos").Rows

                If drv.Item("proveedor").ToString.ToUpper.Equals(pgs_proveedor.ToUpper) Then
                    iCount += 1
                    dr_aux = ods.Tables("documentod").NewRow
                    dr_aux.Item("Empresa") = pgs_empresa
                    dr_aux.Item("TipoDocto") = sTipoDocto '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
                    dr_aux.Item("Correlativo") = correlativo
                    dr_aux.Item("Secuencia") = iCount
                    dr_aux.Item("Linea") = iCount
                    dr_aux.Item("Producto") = drv.Item("producto").ToString 'dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")
                    dr_aux.Item("Cantidad") = drv.Item("sugerido")

                    'Obtener precio del producto
                    Dim dtprecio As DataTable
                    dtprecio = Oflex.Obtener_Precio_Final(pgs_empresa, drv.Item("producto"), "", sListaPrecio)
                    Dim ldprecio As Double = 0
                    If dtprecio.Rows.Count > 0 Then
                        ldprecio = dtprecio.Rows(0).Item("valor")

                    End If

                    dr_aux.Item("Precio") = ldprecio 'dr.Item("precio") '+ drv.Item("ValorDescuento")
                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = ldprecio * dr_aux.Item("Cantidad")  ''drv.Item("Total")
                    dr_aux.Item("Impuesto") = 0 'dr.Item("Total") - (dr.Item("Total") / porcentajeIva)  'drv.Item("ValorImpuesto")
                    dr_aux.Item("Neto") = dr_aux.Item("Subtotal") 'drv.Item("Total") ' dr.Item("Total") 'dr.Item("Total") - dr_aux.Item("Impuesto")
                    dr_aux.Item("DrGlobal") = 0
                    dr_aux.Item("Total") = dr_aux.Item("Subtotal") ' drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("PrecioAjustado") = ldprecio 'drv.Item("valor") ' dr.Item("precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = "UN"
                    dr_aux.Item("CantidadIngreso") = drv.Item("sugerido")
                    dr_aux.Item("PrecioIngreso") = ldprecio 'drv.Item("valor") 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") ' dr.Item("Total")
                    dr_aux.Item("CorrelativoOrigen") = 0
                    dr_aux.Item("SecuenciaOrigen") = 0
                    dr_aux.Item("Bodega") = "" 'Me.cmbBodega.Text '"SVMF_KIOSKO" ''(c) 191011 Agregar Combo
                    dr_aux.Item("FactorInventario") = 0 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario") ''(c) 191011 Depende si es Entrada o Salida
                    dr_aux.Item("FechaEntrega") = Today.ToString("dd/MM/yyyy") ' Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("CantidadAsignada") = 0 ''dr.Item("sugerido")
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S" 'IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
                    dr_aux.Item("CUP") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
                    dr_aux.Item("PrecioBimoneda") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = dr_aux.Item("total")                ' drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ValPorcentajeDr1") = 0
                    dr_aux.Item("ValPorcentajeDr1Ingreso") = 0
                    dr_aux.Item("costo") = ldprecio ' drv.Item("valor") ' dr_aux.Item("Precio")
                    dr_aux.Item("FechaVigenciaLp") = "01/01/1900"
                    dr_aux.Item("PrecioListaP") = 0
                    dr_aux.Item("DoctoOrigenVal") = "N"
                    ods.Tables("documentod").Rows.Add(dr_aux)

                    dtotal += dr_aux.Item("total")
                End If
            Next


            ods.Tables("documento").Rows(0).Item("Total") = dtotal
            ods.Tables("documento").Rows(0).Item("Neto") = dtotal 'dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotal") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("NetoIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotalIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("TotalIngreso") = dtotal
        Catch ex As Exception
        Finally
            'ClsPOS = Nothing
            'Oflex.close()
            'Oflex = Nothing

        End Try
        Return True
    End Function


    Private Sub Guardar_Documento(pOds As DataSet, psEmpresaCompra As String, psCodigoCliente As String, psComprador As String,
                                  ByRef psPedidosGenerados As String, psUsuarioPedido As String, psDireccionEntrega As String)
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr As DataRow
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        Dim porcentaje_consumido As Double = 0
        Dim facturas_disponibles As Integer = 0

        psPedidosGenerados = String.Empty

        Try
            For Each dr In pOds.Tables("documento").Rows
                HuboError = False
                pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                If pOds.Tables("documentod").DefaultView.Count > 0 Then
                    Osinc.Enviar_Documento(dr.Item("empresa"), dr, pOds.Tables("documentod").DefaultView.ToTable, pOds.Tables("documentov").DefaultView.ToTable, pOds.Tables("documentop").DefaultView.ToTable, "", True)
                End If
            Next
            If Osinc.codigo_error = 0 Then
                ''MessageBox.Show("Pedido Ingresado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''Me.txtPedidosGenerados.Text += pOds.Tables("documento").Rows(0).Item("numero") & ","
                psPedidosGenerados += pOds.Tables("documento").Rows(0).Item("numero") & ","
                For Each dr In pOds.Tables("documento").Rows
                    HuboError = False
                    pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                    If pOds.Tables("documentod").DefaultView.Count > 0 Then
                        generarPedido_Umbright_20240927(dr, pOds.Tables("documentod").DefaultView, psEmpresaCompra, psCodigoCliente, psComprador, psUsuarioPedido, psDireccionEntrega)
                        '(c) 20240927 se debe generar pedido en tenant, corporativo algunas veces se bloquea
                        'generarPedido_tenant(dr, pOds.Tables("documentod").DefaultView, psEmpresaCompra, psCodigoCliente, psComprador, psUsuarioPedido, psDireccionEntrega)
                    End If

                Next
            End If
        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing
        End Try
    End Sub



    Private Sub generarPedido_Umbright_20240927(ByVal drEncabezado As DataRow, ByVal dtvDetalle As DataView,
                                    psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, psUsuarioPedido As String,
                                       psDireccionEntrega As String)
        Dim lsSQL As String
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double
        'Dim lsUsuario As String = "CARANA"

        Try

            Otrans.open()
            cOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaCompra & "','CLIENTE','" & psCodigoCliente & "'")

            If dtCliente.Rows.Count > 0 Then

                ''Guardar 

                lsSQL = "pa_ins_um_mov_pedidos_encabezado_tekne '" &
                         psEmpresaCompra & "','" & Now.ToString("ddMMyyyyHHmmss") & "','" &
                         psCodigoCliente & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','"

                'lsSQL += "1900-01-01','" Fecha Modifico

                lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Comprador " & psComprador & "','" &
                        psUsuarioPedido.ToString & "',0,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" & psDireccionEntrega & "','',''"



                cOtrans.Ingresa(lsSQL)

                If cOtrans.Codigo_error = 0 Then
                    dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString

                    For Each drv As DataRowView In dtvDetalle

                        dt = oFlex.Obtener_Precio_Final(psEmpresaCompra, drv.Item("producto"), psCodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        lsSQL = "pa_ins_um_mov_pedidos_detalle " & numero_pedido & "," &
                                          drv.Item("Linea") & ",'" & drv.Item("producto") & "'," &
                                          drv.Item("cantidad") & "," & precio_unitario & "," &
                                          precio_unitario * drv.Item("cantidad")

                        cOtrans.Ingresa(lsSQL)
                        If cOtrans.Codigo_error > 0 Then
                            'lbExitoso = False
                        End If
                    Next
                End If

                lsSQL = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                cOtrans.Actualiza(lsSQL)


                '(c) 20230811 Llamar al proceso de facturación automatico

                lsSQL = "pa_var_um_mov_pedidos_encabezado_procesables_id " & numero_pedido
                dt = cOtrans.Obtiene(lsSQL)

                Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA

                Dim dtDetalle As DataTable = dtvDetalle.ToTable


                oSinc.generarPedidoCorporativo_to_flexline(dt.Rows(0), "", "", dtDetalle, 75)


            End If
        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub generarPedido_tenant(ByVal drEncabezado As DataRow, ByVal dtvDetalle As DataView,
                                    psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, psUsuarioPedido As String,
                                       psDireccionEntrega As String)
        Dim lsSQL As String
        Dim tOtrans As New Transaccional.Conexion("RegionalDB")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double
        'Dim lsUsuario As String = "CARANA"

        Try

            Otrans.open()
            tOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaCompra & "','CLIENTE','" & psCodigoCliente & "'")

            If dtCliente.Rows.Count > 0 Then

                ''Guardar 

                lsSQL = "pa_ins_mov_pedidos_encabezado '" &
                         psEmpresaCompra & "','" &
                         psCodigoCliente & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(Today.ToString).ToString("yyyy-MM-dd") & "','" &
                        DateTime.Parse(Today.ToString).ToString("yyyy-MM-dd") & "','" &
                        DateTime.Parse(Today.ToString).ToString("yyyy-MM-dd") & "','"


                lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Comprador " & psComprador & "','" &
                        psUsuarioPedido.ToString & "',0,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" & psDireccionEntrega & "','','',null,'','',null,null,null,0"



                tOtrans.Ingresa(lsSQL)

                If tOtrans.Codigo_error = 0 Then
                    dt = tOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString

                    For Each drv As DataRowView In dtvDetalle

                        dt = oFlex.Obtener_Precio_Final(psEmpresaCompra, drv.Item("producto"), psCodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        lsSQL = "pa_ins_mov_pedidos_detalle " & numero_pedido & "," &
                                          drv.Item("Linea") & ",'" & drv.Item("producto") & "'," &
                                          drv.Item("cantidad") & "," & precio_unitario & "," &
                                          precio_unitario * drv.Item("cantidad")

                        tOtrans.Ingresa(lsSQL)
                        If tOtrans.Codigo_error > 0 Then
                            'lbExitoso = False
                        End If
                    Next
                End If

                lsSQL = "pa_upd_um_mov_Pedidos_encabezado " & numero_pedido & ",'" & psEmpresaCompra & "',1,null,null"
                tOtrans.Actualiza(lsSQL)


                '(c) 20230811 Llamar al proceso de facturación automatico

                lsSQL = "pa_var_um_mov_pedidos_encabezado_procesables_id " & numero_pedido
                dt = tOtrans.Obtiene(lsSQL)

                Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA

                Dim dtDetalle As DataTable = dtvDetalle.ToTable


                'Sinc.generarPedidoCorporativo_to_flexline(dt.Rows(0), "", "", dtDetalle)
                oSinc.generarPedidoAzzure_to_flexline(dt.Rows(0), "", "", dtDetalle, 45)


            End If
        Catch ex As Exception
        Finally
            tOtrans.close()
            tOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


End Class

#End Region




#Region " Documentos Consignaciones"

Public Class consignaciones

    Public Sub New()

    End Sub


    '(c) 20240828
    Public Function generarDocumentosConsignacionesTenant(ByVal _dvDetalleConteo As DataView, ByVal pdrEncabezado As DataRow, ByRef pNumeroPedido As String, ByRef pTipoDocumento As String, Optional ByVal aplicarBodegaPedido As Boolean = vbFalse) As Boolean


        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim dr_aux As DataRow
        Dim ods As New DataSet
        Dim lBodega As String = "CONSIGNACIONES"

        Try





            'Ods.Tables("Conteos_Pendientes").Rows.Clear()
            'Otrans.open()
            'ls_sql = "pa_sel_um_mov_consignacion_conteo_pendiente null,null,null"
            'dt = Otrans.Obtiene(ls_sql)
            If _dvDetalleConteo.Count > 0 Then
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
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("Usuario_Grabo", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) 'Establecer CONSIGNACIONES, REN_CONSIGNACIONES
                ods.Tables.Add(dt2.Copy)

                dt2 = New DataTable("clientes_procesar")
                dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
                dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) '(c) 20180629
                ods.Tables.Add(dt2.Copy)



                Dim dtBodega As DataTable




                For Each dr As DataRowView In _dvDetalleConteo




                    dr_aux = ods.Tables("Conteos_Pendientes").NewRow
                    dtBodega = ClsGen.selectQuery("FlexLine", "pa_sel_um_consignacion_cliente_bodega '" & dr.Item("empresa").ToString & "','" & dr.Item("ctacte").ToString & "'")
                    dr_aux.Item("Bodega") = "CONSIGNACIONES"
                    '20180629 (c)
                    If dtBodega.Rows(0).Item("Lineas") > 0 Then
                        '      dr_aux.Item("Bodega") = "REN_CONSIGNACIONES"
                    End If
                    dr_aux.Item("cod_conteo") = dr.Item("cod_pedido")
                    'dr_aux.Item("cod_empresa") = dr.Item("cod_empresa")
                    dr_aux.Item("empresa") = dr.Item("empresa").ToString
                    dr_aux.Item("cod_cliente") = dr.Item("ctacte")
                    'dr_aux.Item("Razon_Social") = ""
                    dr_aux.Item("cod_producto") = dr.Item("cod_producto_flex")
                    ' dr_aux.Item("nombre_producto") = ""
                    dr_aux.Item("conteo") = dr.Item("cantidad")
                    'dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                    dr_aux.Item("fecha") = pdrEncabezado.Item("fecha_pedido")
                    dr_aux.Item("saldo_actual") = Obtener_Saldo_Consignacion_Actual(dr.Item("empresa").ToString, dr.Item("cod_producto_flex").ToString, dr.Item("ctacte"), dr_aux.Item("Bodega"))
                    'dr_aux.Item("cantidad_consignar") = IIf(dr.Item("cantidad_maxima") Is System.DBNull.Value, 0, dr.Item("cantidad_maxima")) - dr.Item("conteo").ToString
                    dr_aux.Item("cantidad_facturar") = IIf(dr_aux.Item("saldo_actual") Is System.DBNull.Value, 0, dr_aux.Item("saldo_actual")) - dr.Item("cantidad").ToString
                    'dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios").ToString
                    dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_encabezado").ToString
                    'dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega").ToString
                    dr_aux.Item("Direccion_entrega_factura") = pdrEncabezado.Item("direccion_entrega").ToString()
                    dr_aux.Item("Usuario_Grabo") = pdrEncabezado.Item("Usuario_Grabo").ToString
                    ods.Tables("Conteos_Pendientes").Rows.Add(dr_aux)

                Next



                For Each dr As DataRow In ods.Tables("Conteos_Pendientes").Rows

                    ods.Tables("clientes_procesar").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                    If ods.Tables("clientes_procesar").DefaultView.Count = 0 Then
                        dr_aux = ods.Tables("clientes_procesar").NewRow
                        dr_aux.Item("empresa") = dr.Item("empresa")
                        dr_aux.Item("cod_cliente") = dr.Item("cod_cliente")
                        'dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios_reposicion").ToString
                        dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
                        'dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
                        dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
                        dr_aux.Item("bodega") = dr.Item("bodega").ToString
                        ods.Tables("clientes_procesar").Rows.Add(dr_aux)
                    End If

                Next

                For Each dr As DataRow In ods.Tables("clientes_procesar").Rows
                    ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                    Crear_Documento_Consignacion_Factura_Flex(ods.Tables("conteos_pendientes").DefaultView, dr.Item("cod_cliente").ToString,
                        dr.Item("Comentarios_reposicion").ToString, dr.Item("Comentarios_factura").ToString,
                        dr.Item("Direccion_entrega_reposicion").ToString, dr.Item("Direccion_entrega_factura").ToString, dr.Item("Bodega").ToString)
                Next
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

        Return True

    End Function


    Public Function Generar_Documentos_Consignaciones() As Boolean


        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim ods As New DataSet
        Dim lBodega As String = "CONSIGNACIONES"

        Try





            'Ods.Tables("Conteos_Pendientes").Rows.Clear()
            Otrans.open()
            ls_sql = "pa_sel_um_mov_consignacion_conteo_pendiente null,null,null"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
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
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("Usuario_Grabo", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) 'Establecer CONSIGNACIONES, REN_CONSIGNACIONES
                ods.Tables.Add(dt2.Copy)

                dt2 = New DataTable("clientes_procesar")
                dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
                dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) '(c) 20180629
                ods.Tables.Add(dt2.Copy)



                Dim dtBodega As DataTable




                For Each dr In dt.Rows




                    dr_aux = ods.Tables("Conteos_Pendientes").NewRow
                    dtBodega = ClsGen.selectQuery("FlexLine", "pa_sel_um_consignacion_cliente_bodega '" & dr.Item("empresa").ToString & "','" & dr.Item("cod_cliente_flex").ToString & "'")
                    dr_aux.Item("Bodega") = "CONSIGNACIONES"
                    '20180629 (c)
                    If dtBodega.Rows(0).Item("Lineas") > 0 Then
                        '      dr_aux.Item("Bodega") = "REN_CONSIGNACIONES"
                    End If
                    dr_aux.Item("cod_conteo") = dr.Item("cod_conteo")
                    dr_aux.Item("cod_empresa") = dr.Item("cod_empresa")
                    dr_aux.Item("empresa") = dr.Item("empresa").ToString
                    dr_aux.Item("cod_cliente") = dr.Item("cod_cliente_flex")
                    'dr_aux.Item("Razon_Social") = ""
                    dr_aux.Item("cod_producto") = dr.Item("cod_producto_flex")
                    ' dr_aux.Item("nombre_producto") = ""
                    dr_aux.Item("conteo") = dr.Item("conteo")
                    dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("saldo_actual") = Obtener_Saldo_Consignacion_Actual(dr.Item("empresa").ToString, dr.Item("cod_producto_flex").ToString, dr.Item("cod_cliente_flex"), dr_aux.Item("Bodega"))
                    dr_aux.Item("cantidad_consignar") = IIf(dr.Item("cantidad_maxima") Is System.DBNull.Value, 0, dr.Item("cantidad_maxima")) - dr.Item("conteo").ToString
                    dr_aux.Item("cantidad_facturar") = IIf(dr_aux.Item("saldo_actual") Is System.DBNull.Value, 0, dr_aux.Item("saldo_actual")) - dr.Item("conteo").ToString
                    dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios").ToString
                    dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
                    dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
                    dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
                    dr_aux.Item("Usuario_Grabo") = dr.Item("Usuario_Grabo").ToString
                    ods.Tables("Conteos_Pendientes").Rows.Add(dr_aux)

                Next



                For Each dr In ods.Tables("Conteos_Pendientes").Rows

                    ods.Tables("clientes_procesar").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                    If ods.Tables("clientes_procesar").DefaultView.Count = 0 Then
                        dr_aux = ods.Tables("clientes_procesar").NewRow
                        dr_aux.Item("empresa") = dr.Item("empresa")
                        dr_aux.Item("cod_cliente") = dr.Item("cod_cliente")
                        dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios_reposicion").ToString
                        dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
                        dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
                        dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
                        dr_aux.Item("bodega") = dr.Item("bodega").ToString
                        ods.Tables("clientes_procesar").Rows.Add(dr_aux)
                    End If

                Next

                For Each dr In ods.Tables("clientes_procesar").Rows
                    ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                    Crear_Documento_Consignacion_Factura_Flex(ods.Tables("conteos_pendientes").DefaultView, dr.Item("cod_cliente").ToString,
                        dr.Item("Comentarios_reposicion").ToString, dr.Item("Comentarios_factura").ToString,
                        dr.Item("Direccion_entrega_reposicion").ToString, dr.Item("Direccion_entrega_factura").ToString, dr.Item("Bodega").ToString)
                Next
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

        Return True

    End Function

    Private Function obtenerBodegaConsignacion(psEmpresa As String, psCodigoCliente As String) As String

        Dim lsBodega As String = "CONSIGNACIONES"



        Return lsBodega
    End Function




    Private Function Obtener_Saldo_Consignacion_Actual(ByVal _empresa As String, ByVal _producto As String, ByVal _cliente As String, psBodega As String) As Integer
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_Sql As String
        Dim saldo_actual As Integer = 0

        Try
            otrans.open()
            ls_Sql = "pa_sel_um_consignaciones_saldos_cliente '" & _cliente & "','" & _empresa & "','" & _producto & "'"
            If psBodega = "REN_CONSIGNACIONES" Then
                ls_Sql = "pa_sel_um_consignaciones_saldos_cliente_ren '" & _cliente & "','" & _empresa & "','" & _producto & "'"
            End If

            dt = otrans.Obtiene(ls_Sql)
            saldo_actual = dt.Rows(0).Item("Saldo")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return saldo_actual
    End Function

    Public Function Crear_Documento_Solicitud_Consignacion(ByVal _dv As DataView, ByVal pdrEncabezado As DataRow, ByRef pNumeroPedido As String, ByRef pTipoDocumento As String, Optional ByVal aplicarBodegaPedido As Boolean = vbFalse) As Boolean


        Dim Oflex As New Umbral_Flex.Pedidos(True)

        Dim Oflex_producto As New Umbral_Flex.productos
        Dim OtransCorp As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim oCRUD As New FlexLine_CRUD.readMaster("umbral_flex")

        Dim dr, dr2, drf As DataRow
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim li_secuencia As Integer = 0
        Dim li_secuenciaFactura As Integer = 0
        Dim ls_filtro As String = ""
        Dim dc As DataColumn
        Dim lsMoneda As String = clsGen.Obtener_Moneda(_dv(0).Item("empresa").ToString)
        Dim lbexitoso As Boolean = vbFalse

        Try
            Otrans.open()

            '(c) 20230927
            oCRUD.Empresa = _dv(0).Item("empresa").ToString

            Oflex.Consignaciones = True
            Oflex.Limpiar_Datos()
            Oflex.Validar_Totales = False

            dt = oCRUD.getCliente(pdrEncabezado.Item("ctacte").ToString)

            dr = Oflex.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "SOLICITUD CONSIGNACION"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = pdrEncabezado.Item("ctacte").ToString
            dr.Item("Bodega") = "CD_CENTRAL"
            dr.Item("Bodega2") = "" ' "CONSIGNACIONES" (c) 20180629
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
            dr.Item("aprobacion") = "P"
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = pdrEncabezado.Item("ctacte").ToString
            dr.Item("Glosa") = pdrEncabezado.Item("comentarios").ToString
            dr.Item("Direccion") = pdrEncabezado.Item("direccion_entrega").ToString
            dr.Item("comentario1") = "PDA- " & pdrEncabezado.Item("comentarios").ToString
            dr.Item("Vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("FechaModif") = Now
            dr.Item("FechaUModif") = Now
            dr.Item("UsuarioModif") = pdrEncabezado.Item("usuario_grabo").ToString
            dr.Item("Hora") = Now.ToString("HH:mm:ss")
            dr.Item("NetoBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("ParidadBimoneda") = 1
            dr.Item("AnalisisE3") = "30/12/1899"
            dr.Item("AnalisisE7") = ""
            '(c) 20251119 información para las consignaciones vinoteca
            Try
                dr.Item("AnalisisE6") = pdrEncabezado.Item("AnalisisE6").ToString
            Catch ex As Exception

            End Try

            Oflex.ods.Tables("encabezado").Rows.Add(dr)


            'Ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "cod_cliente = '" & _cod_cliente & "'"
            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView
                If drv.Item("cantidad") > 0 Then

                    dr = Oflex.ods.Tables("detalle").NewRow()

                    li_secuencia += 1
                    dr.Item("Empresa") = drv.Item("empresa").ToString
                    dr.Item("TipoDocto") = "SOLICITUD CONSIGNACION"
                    dr.Item("Correlativo") = 0
                    dr.Item("secuencia") = li_secuencia
                    dr.Item("Linea") = li_secuencia
                    dr.Item("producto") = drv.Item("cod_producto_flex")
                    dr.Item("cantidad") = drv.Item("cantidad")

                    dt = Oflex_producto.Obtener_Precio_Final(drv.Item("empresa").ToString, drv.Item("cod_producto_flex").ToString, pdrEncabezado.Item("ctacte").ToString)

                    Try
                        dr.Item("precio") = dt.Rows(0).Item("valor")
                    Catch ex As Exception
                        dr.Item("precio") = 0
                    End Try

                    '(c) separación de campos
                    Try
                        dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                    Catch ex As Exception

                    End Try

                    dr.Item("PorcentajeDr") = 0
                    dr.Item("SubTotal") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("Neto") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("Impuesto") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("DrGlobal") = 0

                    dt = Oflex_producto.Obtener_Producto(drv.Item("empresa").ToString, drv.Item("cod_producto_flex"))
                    Try
                        dr.Item("Costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                    Catch ex As Exception
                        dr.Item("Costo") = 0
                    End Try



                    dr.Item("total") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("PrecioAjustado") = Round(dr.Item("precio") / 1.12, 6)
                    dr.Item("UnidadIngreso") = "UN"
                    dr.Item("CantidadIngreso") = drv.Item("cantidad")
                    dr.Item("PrecioIngreso") = dr.Item("precio")
                    dr.Item("SubTotalIngreso") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("ImpuestoIngreso") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("NetoIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("DrGlobalIngreso") = 0
                    dr.Item("TotalIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("CorrelativoOrigen") = 0
                    dr.Item("SecuenciaOrigen") = 0
                    dr.Item("Bodega") = "CD_CENTRAL"
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


                    dr2 = dr
                    Oflex.ods.Tables("detalle").Rows.Add(dr)

                    dr2 = Oflex.ods.Tables("detalle").NewRow()
                    For Each dc In Oflex.ods.Tables("detalle").Columns
                        dr2.Item(dc) = dr.Item(dc)
                    Next


                    dr2.Item("Secuencia") = dr2.Item("Secuencia") * -1
                    dr2.Item("Linea") = dr2.Item("Linea") * -1
                    dr2.Item("Cantidad") = dr2.Item("Cantidad") * -1
                    dr2.Item("SubTotal") = dr2.Item("SubTotal") * -1
                    dr2.Item("Impuesto") = dr2.Item("Impuesto") * -1
                    dr2.Item("Neto") = dr2.Item("Neto") * -1
                    dr2.Item("Total") = dr2.Item("Total") * -1
                    dr2.Item("CantidadIngreso") = dr2.Item("CantidadIngreso") * -1
                    dr2.Item("SubTotalIngreso") = dr2.Item("SubTotalIngreso") * -1
                    dr2.Item("ImpuestoIngreso") = dr2.Item("ImpuestoIngreso") * -1
                    dr2.Item("NetoIngreso") = dr2.Item("NetoIngreso") * -1
                    dr2.Item("TotalIngreso") = dr2.Item("TotalIngreso") * -1
                    ' dr2.Item("Bodega") = psBodega '"CONSIGNACIONES" (c) 20180629
                    dr2.Item("CUP") = System.DBNull.Value
                    dr2.Item("Ubicacion2") = System.DBNull.Value
                    dr2.Item("FactorImpto") = System.DBNull.Value
                    dr2.Item("PrecioBimoneda") = dr2.Item("PrecioBimoneda") * -1
                    dr2.Item("SubTotalBimoneda") = dr2.Item("SubTotalBimoneda") * -1
                    dr2.Item("ImpuestoBimoneda") = dr2.Item("ImpuestoBimoneda") * -1
                    dr2.Item("NetoBimoneda") = dr2.Item("NetoBimoneda") * -1
                    dr2.Item("TotalBimoneda") = dr2.Item("TotalBimoneda") * -1
                    dr2.Item("PrecioListaP") = dr2.Item("PrecioListaP") * -1
                    dr2.Item("FechaVigenciaLp") = System.DBNull.Value
                    dr2.Item("DoctoOrigenVal") = System.DBNull.Value
                    dr2.Item("MontoAsignado") = System.DBNull.Value
                    Oflex.ods.Tables("detalle").Rows.Add(dr2)

                End If
            Next


            ''actualizo encabezado Solicitud
            ls_filtro = "linea > 0"

            Try
                Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = Oflex.ods.Tables("detalle").Compute("sum(neto)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotal)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("Total") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") 'Round(Oflex.ods.Tables("detalle").Compute("sum(Total)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = Oflex.ods.Tables("detalle").Compute("sum(NetoIngreso)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") ''Round(Oflex.ods.Tables("detalle").Compute("sum(TotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoBimoneda") = Oflex.ods.Tables("detalle").Compute("sum(NetoBimoneda)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalBimoneda)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalBimoneda") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") 'Round(Oflex.ods.Tables("detalle").Compute("sum(TotalBimoneda)", ls_filtro), 2)

            Catch ex As Exception
                Otrans.Escribir_Log("Solicitud Consignacion")
                Otrans.Escribir_Log(ex.Message)
                Otrans.Escribir_Log(ex.ToString)
            End Try



            ''(c) Debo Identificar a que consignaciones se va a rebajar el total
            ls_filtro = ""

            Dim liCorrelativoGeneradoConsignacion As Integer = 0


            Try
                liCorrelativoGeneradoConsignacion = Oflex.Guardar_Documento()

                If liCorrelativoGeneradoConsignacion > 0 Then

                    lbexitoso = vbTrue

                    pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto").ToString
                    pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("Numero").ToString

                    '(c) 20151911 Enviar Correo Informando que se proceso el pedido

                End If
            Catch ex As Exception
                clsGen.Escribir_Log(ex.Message)
            Finally
                clsGen = Nothing
            End Try

        Catch ex As Exception
            OtransCorp.Escribir_Log(ex.ToString)
        Finally
            OtransCorp = Nothing
            Oflex = Nothing
            'Oflex_Facturar = Nothing

        End Try
        Return lbexitoso

    End Function

    Private Sub Crear_Documento_Consignacion_Factura_Flex(ByVal _dv As DataView, ByVal _cod_cliente As String,
                ByVal _comentario_consignacion As String, ByVal _comentario_factura As String,
                ByVal _direccion_entrega_consignacion As String, ByVal _direccion_entrega_factura As String,
                ByVal psBodega As String)

        Dim Oflex As New Umbral_Flex.Pedidos(True)
        Dim Oflex_Facturar As New Umbral_Flex.Pedidos(True)
        Dim Oflex_producto As New Umbral_Flex.productos
        Dim OtransCorp As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim oCRUD As New FlexLine_CRUD.readMaster("umbral_flex")

        Dim dr, dr2, drf As DataRow
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim li_secuencia As Integer = 0
        Dim li_secuenciaFactura As Integer = 0
        Dim ls_filtro As String = ""
        Dim dc As DataColumn
        Dim lsMoneda As String = clsGen.Obtener_Moneda(_dv(0).Item("empresa").ToString)

        'Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString


        Try
            Otrans.open()

            '(c) 20230927
            oCRUD.Empresa = _dv(0).Item("empresa").ToString


            Oflex.Consignaciones = True
            Oflex.Limpiar_Datos()
            Oflex.Validar_Totales = False

            Oflex_Facturar.Consignaciones = True
            Oflex_Facturar.Limpiar_Datos()
            Oflex_Facturar.Validar_Totales = True

            'dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)
            dt = oCRUD.getCliente(_cod_cliente)

            dr = Oflex.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "SOLICITUD CONSIGNACION"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = _cod_cliente
            dr.Item("Bodega") = "CD_CENTRAL"
            dr.Item("Bodega2") = psBodega ' "CONSIGNACIONES" (c) 20180629
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
            dr.Item("aprobacion") = "P"
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = _cod_cliente
            dr.Item("Glosa") = _comentario_consignacion
            dr.Item("Direccion") = _direccion_entrega_consignacion
            dr.Item("comentario1") = "PDA- CON"
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
            Oflex.ods.Tables("encabezado").Rows.Add(dr)


            'Ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "cod_cliente = '" & _cod_cliente & "'"
            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView
                If drv.Item("cantidad_consignar") > 0 Then

                    dr = Oflex.ods.Tables("detalle").NewRow()


                    li_secuencia += 1
                    dr.Item("Empresa") = drv.Item("empresa").ToString
                    dr.Item("TipoDocto") = "SOLICITUD CONSIGNACION"
                    dr.Item("Correlativo") = 0
                    dr.Item("secuencia") = li_secuencia
                    dr.Item("Linea") = li_secuencia
                    dr.Item("producto") = drv.Item("cod_producto")
                    dr.Item("cantidad") = drv.Item("cantidad_consignar")

                    dt = Oflex_producto.Obtener_Precio_Final(drv.Item("empresa").ToString, drv.Item("cod_producto").ToString, _cod_cliente)
                    Try
                        dr.Item("precio") = dt.Rows(0).Item("valor")
                        dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                    Catch ex As Exception
                        dr.Item("precio") = 0
                    End Try

                    dr.Item("PorcentajeDr") = 0
                    dr.Item("SubTotal") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("Neto") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("Impuesto") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("DrGlobal") = 0

                    dt = Oflex_producto.Obtener_Producto(drv.Item("empresa").ToString, drv.Item("cod_producto"))
                    Try
                        dr.Item("Costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                    Catch ex As Exception
                        dr.Item("Costo") = 0
                    End Try



                    dr.Item("total") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("PrecioAjustado") = Round(dr.Item("precio") / 1.12, 6)
                    dr.Item("UnidadIngreso") = "UN"
                    dr.Item("CantidadIngreso") = drv.Item("cantidad_consignar")
                    dr.Item("PrecioIngreso") = dr.Item("precio")
                    dr.Item("SubTotalIngreso") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("ImpuestoIngreso") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("NetoIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("DrGlobalIngreso") = 0
                    dr.Item("TotalIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("CorrelativoOrigen") = 0
                    dr.Item("SecuenciaOrigen") = 0
                    dr.Item("Bodega") = "CD_CENTRAL"
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


                    dr2 = dr
                    Oflex.ods.Tables("detalle").Rows.Add(dr)

                    dr2 = Oflex.ods.Tables("detalle").NewRow()
                    For Each dc In Oflex.ods.Tables("detalle").Columns
                        dr2.Item(dc) = dr.Item(dc)
                    Next


                    dr2.Item("Secuencia") = dr2.Item("Secuencia") * -1
                    dr2.Item("Linea") = dr2.Item("Linea") * -1
                    dr2.Item("Cantidad") = dr2.Item("Cantidad") * -1
                    dr2.Item("SubTotal") = dr2.Item("SubTotal") * -1
                    dr2.Item("Impuesto") = dr2.Item("Impuesto") * -1
                    dr2.Item("Neto") = dr2.Item("Neto") * -1
                    dr2.Item("Total") = dr2.Item("Total") * -1
                    dr2.Item("CantidadIngreso") = dr2.Item("CantidadIngreso") * -1
                    dr2.Item("SubTotalIngreso") = dr2.Item("SubTotalIngreso") * -1
                    dr2.Item("ImpuestoIngreso") = dr2.Item("ImpuestoIngreso") * -1
                    dr2.Item("NetoIngreso") = dr2.Item("NetoIngreso") * -1
                    dr2.Item("TotalIngreso") = dr2.Item("TotalIngreso") * -1
                    dr2.Item("Bodega") = psBodega '"CONSIGNACIONES" (c) 20180629
                    dr2.Item("CUP") = System.DBNull.Value
                    dr2.Item("Ubicacion2") = System.DBNull.Value
                    dr2.Item("FactorImpto") = System.DBNull.Value
                    dr2.Item("PrecioBimoneda") = dr2.Item("PrecioBimoneda") * -1
                    dr2.Item("SubTotalBimoneda") = dr2.Item("SubTotalBimoneda") * -1
                    dr2.Item("ImpuestoBimoneda") = dr2.Item("ImpuestoBimoneda") * -1
                    dr2.Item("NetoBimoneda") = dr2.Item("NetoBimoneda") * -1
                    dr2.Item("TotalBimoneda") = dr2.Item("TotalBimoneda") * -1
                    dr2.Item("PrecioListaP") = dr2.Item("PrecioListaP") * -1
                    dr2.Item("FechaVigenciaLp") = System.DBNull.Value
                    dr2.Item("DoctoOrigenVal") = System.DBNull.Value
                    dr2.Item("MontoAsignado") = System.DBNull.Value
                    Oflex.ods.Tables("detalle").Rows.Add(dr2)

                End If




                If drv.Item("cantidad_facturar") > 0 Then

                    ''Genero El Detalle de la Solicitud de Facturacion
                    dt = Obtener_Consignacion_Facturar(_cod_cliente,
                                                    drv.Item("cod_producto"),
                                                    drv.Item("cantidad_facturar"), _dv(0).Item("empresa").ToString,
                                                    IIf(drv.Item("empresa").ToString = "DIVINOS", "NOTA DE REMISION", "CONSIGNACIONES"),
psBodega)

                    For Each drf In dt.Rows ' Ods.Tables("detalle_facturar").Rows


                        li_secuenciaFactura += 1
                        dr = Oflex_Facturar.ods.Tables("detalle").NewRow()

                        dr.Item("Empresa") = _dv(0).Item("empresa").ToString
                        dr.Item("TipoDocto") = "FACTURAR CONSIGNACION"
                        dr.Item("Correlativo") = 0
                        dr.Item("secuencia") = li_secuenciaFactura
                        dr.Item("Linea") = li_secuenciaFactura
                        dr.Item("producto") = drv.Item("cod_producto")

                        dr.Item("cantidad") = drf.Item("cantidad")  ''debo establecer cuanto se va a facturar

                        dr.Item("precio") = 0
                        dt = Oflex_producto.Obtener_Precio_Final(_dv(0).Item("empresa").ToString, drv.Item("cod_producto").ToString, _cod_cliente)
                        Try
                            dr.Item("precio") = dt.Rows(0).Item("valor")
                            dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                        Catch ex As Exception
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

            'dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)
            dt = oCRUD.getCliente(_cod_cliente)
            dr = Oflex_Facturar.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "FACTURAR CONSIGNACION"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = _cod_cliente
            dr.Item("Bodega") = "CONSIGNACIONES"
            dr.Item("Bodega2") = "CONSIGNACIONES"
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
            dr.Item("aprobacion") = "S"
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = _cod_cliente
            dr.Item("Glosa") = ""
            dr.Item("comentario1") = "PDA- CON " & _comentario_factura
            dr.Item("direccion") = _direccion_entrega_factura
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



            ''actualizo encabezado Solicitud
            ls_filtro = "linea > 0"

            Try
                Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = Oflex.ods.Tables("detalle").Compute("sum(neto)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotal)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("Total") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") 'Round(Oflex.ods.Tables("detalle").Compute("sum(Total)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = Oflex.ods.Tables("detalle").Compute("sum(NetoIngreso)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") ''Round(Oflex.ods.Tables("detalle").Compute("sum(TotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoBimoneda") = Oflex.ods.Tables("detalle").Compute("sum(NetoBimoneda)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalBimoneda)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalBimoneda") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") 'Round(Oflex.ods.Tables("detalle").Compute("sum(TotalBimoneda)", ls_filtro), 2)

            Catch ex As Exception
                Otrans.Escribir_Log("Solicitud Consignacion")
                Otrans.Escribir_Log(ex.Message)
                Otrans.Escribir_Log(ex.ToString)
            End Try

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
                Otrans.Escribir_Log("Facturar Consignacion")
                Otrans.Escribir_Log(ex.Message)
                Otrans.Escribir_Log(ex.ToString)
            End Try


            ''(c) Debo Identificar a que consignaciones se va a rebajar el total
            ls_filtro = ""
            'For Each dr In Oflex.ods.Tables("detalle").Rows
            '    If dr.Item("linea") > 0 Then

            '        Obtener_Consignacion_Facturar(_cod_cliente, _
            '                                                dr.Item("producto"), _
            '                                                dr.Item("cantidad"), _dv(0).Item("empresa").ToString)
            '    End If

            'Next

            ' Oflex.ods.Tables("encabezado").Rows(0).Item("Comentario1") = "PDA- Prueba IT **No Facturar*** " & ls_filtro

            Dim liCorrelativoGeneradoConsignacion As Integer = 0
            Dim liCorrelativoGeneradoFacturaCosignacion As Integer = 0

            Try
                liCorrelativoGeneradoConsignacion = Oflex.Guardar_Documento()

            Catch ex As Exception

            End Try
            Try
                liCorrelativoGeneradoFacturaCosignacion = Oflex_Facturar.Guardar_Documento()
            Catch ex As Exception

            End Try


            '(c) 20180702 Generar Correo de Confirmacion



            Try

            Catch ex As Exception

            End Try



            OtransCorp.open()

            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView
                OtransCorp.Actualiza("pa_upd_um_mov_consignacion_conteo_detalle_proceso " &
                                    drv.Item("cod_empresa").ToString & ",'" &
                                    drv.Item("cod_cliente").ToString & "','" &
                                    drv.Item("cod_producto").ToString & "'," &
                                    drv.Item("cod_conteo").ToString & ",1")
            Next
            OtransCorp.close()


            If liCorrelativoGeneradoConsignacion > 0 Then

                Try

                    '(c) 20151911 Enviar Correo Informando que se proceso el pedido


                    Dim lsBodyMail, sBody As String
                    Dim iCount As Integer

                    Dim dtPedido As DataTable
                    Dim dtPedidoDetalle As DataTable
                    Dim lsUsuarioGrabo As String = ""



                    lsBodyMail = String.Empty
                    iCount = 0

                    sBody = String.Empty
                    For Each drvConsignacion As DataRowView In Oflex.ods.Tables("encabezado").DefaultView


                        lsUsuarioGrabo = drvConsignacion.Item("usuarioModif").ToString
                        iCount += 1

                        sBody = sBody & "<tr></tr><tr>"
                        sBody = sBody & "</tr>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Empresa</td><td>" & drvConsignacion.Item("Empresa").ToString & "</td>"
                        sBody = sBody & "</tr><tr>"

                        Try

                            sBody = sBody & "<td>Consignacion</td><td>" & drvConsignacion.Item("tipodocto").ToString & "-" & drvConsignacion.Item("Numero").ToString & "</td>"

                            dtPedido = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")


                            dtPedidoDetalle = clsGen.selectQuery("FlexLine", "pa_var_um_valida_documento_encabezado_detalle_consignacion '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")



                        Catch ex As Exception
                        End Try

                        sBody = sBody & "</tr><tr>"

                        Try
                            If dtPedidoDetalle.Rows.Count > 0 Then
                                sBody = sBody & "<td>Unidades Consignar</td><td>" & dtPedidoDetalle.Rows(0).Item("Cantidad").ToString & "</td>"
                            End If
                        Catch ex As Exception

                        End Try

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Total</td><td>" & drvConsignacion.Item("Total").ToString & "</td>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Comentario</td><td>" & drvConsignacion.Item("Comentario1").ToString & "</td>"
                        sBody = sBody & "<td> </td><td>" & drvConsignacion.Item("glosa").ToString & "</td>"

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Cliente</td><td>" & drvConsignacion.Item("cliente").ToString


                        Try
                            sBody = sBody & " -- " & dtPedido.Rows(0).Item("razonsocial").ToString
                        Catch ex As Exception
                        End Try
                        sBody = sBody & "</td>"
                        sBody = sBody & "</tr><tr><td></td><td></td></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                    Next






                    For Each drvConsignacion As DataRowView In Oflex_Facturar.ods.Tables("encabezado").DefaultView


                        lsUsuarioGrabo = drvConsignacion.Item("usuarioModif").ToString
                        iCount += 1

                        sBody = sBody & "<tr></tr><tr>"
                        sBody = sBody & "</tr>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "</tr><tr>"

                        Try

                            sBody = sBody & "<td>Facturar Consignacion</td><td>" & drvConsignacion.Item("tipodocto").ToString & "-" & drvConsignacion.Item("Numero").ToString & "</td>"



                            dtPedidoDetalle = clsGen.selectQuery("FlexLine", "pa_var_um_valida_documento_encabezado_detalle_consignacion '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")

                        Catch ex As Exception

                        End Try

                        sBody = sBody & "</tr><tr>"
                        If dtPedidoDetalle.Rows.Count > 0 Then
                            sBody = sBody & "<td>Unidades Facturar</td><td>" & dtPedidoDetalle.Rows(0).Item("Cantidad").ToString & "</td>"
                        End If

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Comentario</td><td>" & drvConsignacion.Item("Comentario1").ToString & "</td>"
                        sBody = sBody & "<td> </td><td>" & drvConsignacion.Item("glosa").ToString & "</td>"

                        sBody = sBody & "</tr><tr>"
                        'sBody = sBody & "<td>Cliente</td><td>" & drvConsignacion.Item("cliente").ToString
                        'sBody = sBody & "</td>"
                        sBody = sBody & "</tr><tr><td></td><td></td></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                    Next


                    ''Si Sbody lleva datos debo enviar correo de confirmacion de recepcion de Pedidos
                    If sBody.Length > 0 Then
                        lsBodyMail = "<table><font size=1>"

                        lsBodyMail = lsBodyMail & "<tr></tr><tr>"
                        lsBodyMail = lsBodyMail & "<td>Buen Dia </td><td>"
                        Dim dtUsuario As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & lsUsuarioGrabo & "'")

                        Try
                            lsBodyMail = lsBodyMail & StrConv(dtUsuario.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
                        Catch ex As Exception

                        End Try
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "</tr><tr>"
                        lsBodyMail = lsBodyMail & "<td>Le informamos que hemos procesado las siguientes Consignaciones: "
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "</tr><tr>"

                        sBody = sBody & "</table>"
                        lsBodyMail = lsBodyMail + sBody

                        dtUsuario = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & lsUsuarioGrabo & "'")

                        Try
                            Dim lsCuentaUsuario As String
                            Try
                                lsCuentaUsuario = dtUsuario.Rows(0).Item("correo").ToString
                                '& ",alfredo.saravia@umbralcorp.com,coscal@umbral.com.gt"
                            Catch ex As Exception
                                'lsCuentaUsuario = "alfredo.saravia@umbralcorp.com,coscal@umbral.com.gt"
                            End Try



                            clsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral",
                                                lsCuentaUsuario,
                                                "Confirmacion Recepcion de Consignaciones", lsBodyMail, "")
                            clsGen.Escribir_Log("Enviando Correo de Consignaciones a " & lsUsuarioGrabo.ToString)
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.Message)
                        End Try

                    End If
                    lsBodyMail = String.Empty


                Catch ex As Exception
                    clsGen.Escribir_Log(ex.Message)
                Finally

                    clsGen = Nothing

                End Try
            End If



        Catch ex As Exception
            OtransCorp.Escribir_Log(ex.ToString)
        Finally
            OtransCorp = Nothing
            Oflex = Nothing
            Oflex_Facturar = Nothing

        End Try

    End Sub

    Private Function Obtener_Consignacion_Facturar(ByVal _cod_cliente As String,
                                                     ByVal _cod_producto As String,
                                                     ByVal _cantidad As Integer,
                                                     ByVal _empresa As String, ByVal ptipoDocto As String,
                                                   ByVal psBodega As String) As DataTable

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
            If psBodega = "REN_CONSIGNACIONES" Then
                ls_sql = "pa_sel_um_consignaciones_saldos_re NULL,'" & _empresa & "','" & _cod_cliente & "','" & _cod_producto & "'"
            End If
            oTrans.Escribir_Log(ls_sql)

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


                'ls_sql = "pa_sel_um_documentod '" & _empresa & "','" & ptipoDocto & "','" & drv.Item("con_numero") & "'"
                ls_sql = "pa_sel_um_documentod '" & _empresa & "','" & drv.Item("fd_tipor") & "','" & drv.Item("con_numero") & "'"
                dt2 = oTrans.Obtiene(ls_sql)
                dt2.DefaultView.RowFilter = "producto = '" & _cod_producto & "' and cantidad > 0 "
                If dt2.Rows.Count > 0 Then
                    drv2 = dt2.DefaultView(0)
                    dr = dt3.NewRow()
                    dr.Item("cod_producto") = _cod_producto
                    dr.Item("cantidad") = cantidad_asignada
                    dr.Item("TipoDoctoOrigen") = drv2.Item("tipodocto")  'ptipoDocto '"CONSIGNACIONES"
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
End Class
#End Region
