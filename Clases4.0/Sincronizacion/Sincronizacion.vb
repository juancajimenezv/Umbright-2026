Imports System.Data
Imports System.Data.Entity.Migrations
Imports System.Data.SQLite
Imports System.IO
Imports System.Math
Imports System.Net
Imports System.Threading


'(c)  20230711 Se parametriza usuario de facturación por medio e appconfig

#Region "Sincronizacion de Productos Entre Tiendas"

Public Class Productos
    Shared oTrans As Transaccional.Conexion
    Shared fOtrans As Transaccional.Conexion_Fox
    Public codigo_error As Integer
    Public descripcion_error As String
    Public dt As DataTable
    Public accion As String


    Public Sub New(ByVal stienda As String)

        Dim ls_string As String
        ls_string = "Flexline" & stienda

        oTrans = New Transaccional.Conexion(ls_string)
        Try
            oTrans.Escribir_Log(ls_string)

            oTrans.open()
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error

        Catch ex As Exception
            accion = ex.Message
        End Try

    End Sub

    Public Sub New(ByVal stienda As String, ByVal nombre_conexion As String)
        Dim ls_string As String
        ls_string = nombre_conexion & stienda

        oTrans = New Transaccional.Conexion(ls_string)
        Try
            oTrans.open()
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error

        Catch ex As Exception
            accion = ex.Message
        End Try

    End Sub

    Public Sub New(ByVal stienda As String, ByVal nombre_conexion As String, ByVal esFox As Boolean)
        'Dim ls_string As String

        fOtrans = New Transaccional.Conexion_Fox(nombre_conexion, 16)
        fOtrans.Fecha_Proceso = "NewData"
        fOtrans.Open()



    End Sub

    Public Sub Cerrar()
        Try
            oTrans.close()
            oTrans = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Inicializar_Errores()
        codigo_error = 0
        descripcion_error = 0
    End Sub

    Private Sub Agregar_Oferta(ByVal sempresa As String, ByVal smemo As String, ByVal pdr As DataRow)
        accion = "Agregar " & pdr.Item("producto").ToString
        Dim ls_sql As String

        ls_sql = "pa_ins_um_productooferta '" & sempresa & "','" & pdr.Item("producto").ToString & "','" &
                pdr.Item("ctacte").ToString & "'," & pdr.Item("precio") & ",'" & pdr.Item("fechai") & "','" &
                pdr.Item("fechaf").ToString & "','" & pdr.Item("todos") & ",','" & smemo & "','" &
                pdr.Item("horai").ToString & "','" & pdr.Item("horaf").ToString & "'," & pdr.Item("porcentajemax") & "," &
                pdr.Item("porcdescuento") & ",'" & pdr.Item("listaprecio").ToString & "'," & pdr.Item("idoferta")

        oTrans.Ingresa(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error & " " & pdr.Item("producto")
    End Sub

    ''Modificamos una oferta ya existente
    Private Sub Modificar_Oferta(ByVal sempresa As String, ByVal smemo As String, ByVal pdr As DataRow)
        accion = "Modificar " & pdr.Item("producto").ToString
        Dim ls_sql As String
        ls_sql = "pa_upd_um_productooferta '" & sempresa & "','" & pdr.Item("producto").ToString & "','" &
                pdr.Item("ctacte").ToString & "'," & pdr.Item("precio") & ",'" & pdr.Item("fechai") & "','" &
                pdr.Item("fechaf").ToString & "','" & pdr.Item("todos") & ",','" & smemo & "','" &
                pdr.Item("horai").ToString & "','" & pdr.Item("horaf").ToString & "'," & pdr.Item("porcentajemax") & "," &
                pdr.Item("porcdescuento") & ",'" & pdr.Item("listaprecio").ToString & "'," & pdr.Item("idoferta")

        oTrans.Actualiza(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error
    End Sub

    Public Sub Actualizar_Ofertas(ByVal sempresa As String, ByVal smemo As String, ByVal pdr As DataRow)
        Dim ls_sql As String
        ls_sql = "pa_var_um_productooferta '" & sempresa & "','" & pdr.Item("producto").ToString & "','" & smemo & "','" & pdr.Item("ctacte").ToString & "','" & pdr.Item("listaPrecio").ToString & "'"
        dt = oTrans.Obtiene(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error

        If dt.Rows.Count > 0 Then
            Modificar_Oferta(sempresa, smemo, pdr)
        Else
            Agregar_Oferta(sempresa, smemo, pdr)
        End If

    End Sub

    Public Sub Actualizar_Producto(ByVal pdr As DataRow)
        Dim ls_sql As String

        ls_sql = "pa_ins_um_producto '" & pdr.Item("empresa").ToString & "','" & pdr.Item("producto").ToString & "','" &
                pdr.Item("glosa").ToString.Replace("'", "") & "','" & pdr.Item("tipoproducto").ToString & "','" & pdr.Item("familia").ToString & "','" &
                pdr.Item("subfamilia").ToString & "','" & pdr.Item("tipo").ToString.Replace("'", "") & "','" & pdr.Item("subtipo").ToString & "','" &
                pdr.Item("vigente").ToString & "','" & pdr.Item("unidad").ToString & "'," & pdr.Item("decimales").ToString & "," &
                pdr.Item("precioventa").ToString & ",'" & pdr.Item("procedencia").ToString & "','" & pdr.Item("cuentacompra").ToString & "','" &
                pdr.Item("cuentaventa").ToString & "','" & pdr.Item("cuentacosto").ToString & "','" & pdr.Item("unidadalt").ToString & "'," &
                pdr.Item("factoralt").ToString & "," & pdr.Item("decimalesalt").ToString & ",'" & pdr.Item("serie").ToString & "','" &
                pdr.Item("lote").ToString & "','" & pdr.Item("fechavcto").ToString & "','" & pdr.Item("validastock").ToString & "','" &
                pdr.Item("cmonetaria").ToString & "','" & pdr.Item("costeable").ToString & "','" & pdr.Item("depreciable").ToString & "','" &
                pdr.Item("compuesto").ToString & "'," & pdr.Item("factor1").ToString & "," & pdr.Item("factor2").ToString & "," & pdr.Item("factor3").ToString & "," &
                pdr.Item("factor4").ToString & "," & pdr.Item("factor5").ToString & "," & pdr.Item("factor6").ToString & "," & pdr.Item("factor7").ToString & "," &
                pdr.Item("factor8").ToString & "," & pdr.Item("factor9").ToString & "," & pdr.Item("factor10").ToString & "," & pdr.Item("factor11").ToString & "," &
                pdr.Item("factor12").ToString & "," & pdr.Item("factor13").ToString & "," & pdr.Item("factor14").ToString & "," & pdr.Item("factor15").ToString & "," &
                pdr.Item("factor16").ToString & "," & pdr.Item("factor17").ToString & "," & pdr.Item("factor18").ToString & "," & pdr.Item("factor19").ToString & "," &
                pdr.Item("factor20").ToString & "," & pdr.Item("stockminimo").ToString & "," & pdr.Item("stockmaximo").ToString & "," &
                pdr.Item("costoestandar").ToString & ",'" & pdr.Item("comentario").ToString & "','" &
                pdr.Item("fechamodif").ToString & "'," & pdr.Item("costo_valor").ToString & ",'" & pdr.Item("usuariomodif").ToString & "'," &
                pdr.Item("aux_valor1").ToString & "," & pdr.Item("aux_valor2").ToString & "," & pdr.Item("aux_valor3").ToString & "," &
                pdr.Item("aux_valor4").ToString & "," & pdr.Item("aux_valor5").ToString & "," & pdr.Item("aux_valor6").ToString & "," &
                pdr.Item("aux_valor7").ToString & "," & pdr.Item("aux_valor8").ToString & "," & pdr.Item("aux_valor9").ToString & "," &
                pdr.Item("aux_valor10").ToString & "," & pdr.Item("aux_valor11").ToString & "," & pdr.Item("aux_valor12").ToString & "," &
                pdr.Item("aux_valor13").ToString & "," & pdr.Item("aux_valor14").ToString & "," & pdr.Item("aux_valor15").ToString & "," &
                pdr.Item("aux_valor16").ToString & "," & pdr.Item("aux_valor17").ToString & "," & pdr.Item("aux_valor18").ToString & "," &
                pdr.Item("aux_valor19").ToString & "," & pdr.Item("aux_valor20").ToString & "," &
                pdr.Item("diascompra").ToString & "," & pdr.Item("diasproduccion").ToString & "," &
                pdr.Item("lotecompra").ToString & "," & pdr.Item("loteproduccion").ToString & "," & pdr.Item("stockreposicion").ToString & "," &
                pdr.Item("peso").ToString & "," & pdr.Item("volumen").ToString & ",'" & pdr.Item("proveedor").ToString & "','" &
                pdr.Item("kitvirtual").ToString & "'," & pdr.Item("productosxempaque1").ToString & "," & pdr.Item("empaque1xempaque2").ToString & ",'" &
                pdr.Item("analisisproducto1").ToString & "','" & pdr.Item("analisisproducto2").ToString & "','" & pdr.Item("analisisproducto3").ToString & "','" &
                pdr.Item("analisisproducto4").ToString & "','" & pdr.Item("analisisproducto5").ToString & "','" & pdr.Item("analisisproducto6").ToString & "','" &
                pdr.Item("analisisproducto7").ToString & "','" & pdr.Item("analisisproducto8").ToString & "','" & pdr.Item("analisisproducto9").ToString & "','" &
                pdr.Item("analisisproducto10").ToString & "','" & pdr.Item("multiple").ToString & "','" & pdr.Item("act_grupo").ToString & "','" &
                pdr.Item("Act_SerieCartola").ToString & "'"

        Try
            ls_sql += IIf(pdr.Item("cuentadesc").ToString.Length = 0, ",NULL", ",'" & pdr.Item("cuentadesc").ToString & "'")
            ls_sql += IIf(pdr.Item("cuentadev").ToString.Length = 0, ",NULL", ",'" & pdr.Item("cuentadev").ToString & "'")
        Catch ex As Exception
        End Try


        Try
            ls_sql += IIf(pdr.Item("analisisproducto11").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto11").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto12").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto12").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto13").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto13").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto14").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto14").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto15").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto15").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto16").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto16").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto17").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto17").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto18").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto18").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto19").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto19").ToString & "'")
            ls_sql += IIf(pdr.Item("analisisproducto20").ToString.Length = 0, ",NULL", ",'" & pdr.Item("analisisproducto20").ToString & "'")
        Catch ex As Exception
        End Try

        oTrans.Ingresa(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error

    End Sub

    Public Sub Actualizar_ProductoBarra(ByVal pdt As DataTable)

        Dim ls_sql As String
        Dim dr As DataRow

        Inicializar_Errores()

        ls_sql = "pa_del_um_prodcodbarra '" & pdt.Rows(0).Item("EMPRESA").ToString & "','" & pdt.Rows(0).Item("PRODUCTO").ToString & "'"
        oTrans.Elimina(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error

        For Each dr In pdt.Rows
            ls_sql = "pa_ins_um_prodcodbarra '" & dr.Item("EMPRESA").ToString & "','" & dr.Item("CODBARRA").ToString & "','" &
                     dr.Item("PRODUCTO").ToString & "','" & dr.Item("Unidad").ToString & "'," & dr.Item("Factor").ToString & "," &
                     dr.Item("Linea").ToString & "," & dr.Item("FactorUB").ToString & ",'" & dr.Item("TipoCodigo").ToString & "'"

            oTrans.Ingresa(ls_sql)
            codigo_error += oTrans.Codigo_error
            descripcion_error += oTrans.descripcion_error & " " & dr.Item("Producto")

        Next

    End Sub

    Public Sub Actualizar_ProductoReceta(ByVal pdt As DataTable, ByVal ElimarPrevios As Boolean)

        Dim ls_sql As String
        Dim dr As DataRow

        Inicializar_Errores()

        If ElimarPrevios Then
            ls_sql = "pa_del_um_prodreceta '" & pdt.Rows(0).Item("EMPRESA").ToString & "','" & pdt.Rows(0).Item("PRODUCTO").ToString & "'"
            oTrans.Elimina(ls_sql)
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error
        End If


        For Each dr In pdt.Rows
            ls_sql = "pa_ins_um_prodReceta '" & dr.Item("EMPRESA").ToString & "','" & dr.Item("Producto").ToString & "','" &
                     dr.Item("Receta").ToString & "'," & dr.Item("Linea").ToString & ",'" & dr.Item("Proceso").ToString & "','" &
                     dr.Item("ProductoI").ToString & "'," & dr.Item("Cantidad").ToString & ",'" & dr.Item("UnidadI").ToString & "'," &
                     dr.Item("CantidadI").ToString

            oTrans.Ingresa(ls_sql)
            codigo_error += oTrans.Codigo_error
            descripcion_error += "ProductoReceta " + oTrans.descripcion_error & " " & dr.Item("Producto")

        Next

    End Sub

    Public Sub Actualizar_ProductoPrecio(ByVal pdt As DataTable, ByVal EliminarPrevios As Boolean)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim lidlisprecio As Integer
        Dim clsGen As New ClasesGenerales.General

        Inicializar_Errores()

        ls_sql = "pa_var_um_listaPrecio_listado '" & pdt.Rows(0).Item("Empresa").ToString & "'"
        dt = oTrans.Obtiene(ls_sql)

        ''Elimino los precios Previos
        If EliminarPrevios Then
            ls_sql = "pa_del_um_listapreciod '" & pdt.Rows(0).Item("Empresa").ToString & "','" & pdt.Rows(0).Item("Producto").ToString & "'"
            oTrans.Elimina(ls_sql)
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error
        End If

        For Each dr In pdt.Rows
            dt.DefaultView.RowFilter = "Lisprecio = '" & dr.Item("Lisprecio") & "'"

            If dt.DefaultView.Count > 0 Then
                ''Solo paso aquellos memos q han finalizado hace 6 meses hasta los que no han finalizado
                If dr.Item("fec_final") > Today.AddMonths(-6) Then
                    lidlisprecio = dt.DefaultView(0).Item("idlisprecio")
                    ls_sql = "pa_ins_um_listapreciod '" & dr.Item("Empresa").ToString & "'," & lidlisprecio.ToString & ",'" &
                             dr.Item("Producto").ToString & "'," & dr.Item("Valor").ToString & ",'" & dr.Item("Moneda").ToString & "'," &
                             dr.Item("PorcMaxDesc").ToString & "," & dr.Item("Intervalo").ToString & "," &
                             dr.Item("PorcentajeInt").ToString & "," & dr.Item("Cantidad").ToString & ",'" &
                             dr.Item("Tipo").ToString & "'," & dr.Item("ValorC").ToString & ",'" &
                             dr.Item("FECHAVIGENCIA").ToString & "','" & dr.Item("Origen").ToString & "'," &
                             dr.Item("ValorOrigen").ToString & "," & dr.Item("ValorPOrigen").ToString & ",'" &
                             dr.Item("UserModif").ToString & "','" & dr.Item("FechaModif").ToString & "','" &
                             dr.Item("Efecto").ToString & "'," & dr.Item("PorcMaxDesc1").ToString & "," &
                             dr.Item("PorcMaxDesc2").ToString & "," & dr.Item("PorcMaxDesc3").ToString & "," &
                             dr.Item("PorcMaxDesc4").ToString & "," & dr.Item("PorcMaxDesc5").ToString

                    oTrans.Ingresa(ls_sql)
                    codigo_error += oTrans.Codigo_error
                    descripcion_error += oTrans.descripcion_error & " " & dr.Item("Producto").ToString & " LP " & dr.Item("Lisprecio")
                    If oTrans.Codigo_error > 0 Then
                        Try
                            clsGen.insertQuery("RegionalDBintOut", ls_sql)

                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        Next

        clsGen = Nothing
    End Sub

    Public Sub Actualizar_ProductoPrecio(ByVal pdt As DataTable)
        Actualizar_ProductoPrecio(pdt, True)
    End Sub


#Region "Vinoteca"

    Public Sub Actualizar_Producto_Vinoteca(ByVal pdr As DataRow, ByVal procesar_todo As Int16)
        Dim ls_sql As String
        Dim dt As DataTable

        Inicializar_Errores()

        ls_sql = "pa_sel_um_SSO_InvItem '" & pdr.Item("codigo_corto") & "'"
        dt = oTrans.Obtiene(ls_sql)

        If dt.Rows.Count > 0 Then

            ls_sql = "pa_upd_um_SSO_InvItem '" & pdr.Item("codigo_corto") & "','" &
                            pdr.Item("glosa").ToString & "'," &
                            Obtener_Grupo_Vinoteca(pdr.Item("TipoProducto")) & "," &
                            Obtener_Proveedor_Vinoteca(pdr.Item("SubFamilia")) & "," &
                            IIf(pdr.Item("costo").ToString.Length = 0, 0.0, pdr.Item("costo").ToString) & ",'" &
                            IIf(pdr.Item("Unidad").ToString.ToLower.StartsWith("libra"), "W", "I") & "','" &
                            IIf(pdr.Item("vigente").ToString = "S", "N", "Y") & "'"

            oTrans.Actualiza(ls_sql)

        Else
            If procesar_todo = 1 Then

                ls_sql = "pa_ins_um_SSO_InvItem 'IVA',NULL,'" &
                                pdr.Item("producto").ToString & "','" &
                                pdr.Item("glosa").ToString & "'," &
                                "Null,Null," &
                                Obtener_Grupo_Vinoteca(pdr.Item("TipoProducto")) & "," &
                                "Null,Null,'" &
                                IIf(pdr.Item("Unidad").ToString.ToLower.StartsWith("libra"), "W", "I") &
                                "',0,0,null,0,'Y','Y','Y'," &
                                "'N','N',0,0,0,0,NULL," &
                                Obtener_Proveedor_Vinoteca(pdr.Item("SubFamilia")) &
                                ",'Admin','Admin',NULL,NULL,NULL,NULL,NULL,NULL," &
                                IIf(pdr.Item("costo").ToString.Length = 0, 0.0, pdr.Item("costo").ToString)


                oTrans.Ingresa(ls_sql)

            End If
        End If
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error

    End Sub

    Public Sub Actualizar_ProductoBarra_Vinoteca(ByVal pdt As DataTable)

        Dim ls_sql As String
        Dim dr As DataRow

        Inicializar_Errores()
        Try


            ls_sql = "pa_del_um_SSO_InvBarras '" & pdt.Rows(0).Item("codigo_corto").ToString & "'"
            oTrans.Elimina(ls_sql)
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error

            For Each dr In pdt.Rows
                ls_sql = "pa_ins_um_sso_invBarras NULL,NULL,'" &
                        dr.Item("codigo_barra").ToString & "','" &
                         dr.Item("codigo_corto").ToString & "','Admin','Admin'"



                oTrans.Ingresa(ls_sql)
                codigo_error += oTrans.Codigo_error
                descripcion_error += oTrans.descripcion_error & " " & dr.Item("Producto")

            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Actualizar_ProductoBarra_VinotecaFB(ByVal drv As DataRowView)
        Inicializar_Errores()

        Try
            fOtrans.Nombre_Tabla = "Itm"
            fOtrans.Lista_Campos = "Sku = '" & drv.Item("codbarra").ToString & "'"
            fOtrans.Condiciones = "bohname = '" & drv.Item("producto").ToString & "'"
            If Not fOtrans.Actualiza() Then
                codigo_error += oTrans.Codigo_error
                descripcion_error += oTrans.descripcion_error & " " & drv.Item("Producto").ToString & " LP " & drv.Item("Lisprecio")
            End If


        Catch ex As Exception

        End Try
    End Sub


    Public Sub Actualizar_ProductoPrecio_Vinoteca(ByVal pdr As DataRow, ByVal pdt As DataTable)
        Dim ls_sql As String


        Inicializar_Errores()



        Try
            ls_sql = "pa_del_um_SSO_PrmPreciosBase '" & pdt.Rows(0).Item("codigo_corto").ToString & "',1"
            oTrans.Elimina(ls_sql)
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error


            ls_sql = "pa_ins_um_SSO_PrmPreciosBase null,null,'" &
                        pdt.Rows(0).Item("codigo_corto").ToString & "',1," &
                        pdr.Item("valor").ToString & ",'QTZ','N',1.12,0,4"
            oTrans.Ingresa(ls_sql)
            If oTrans.Codigo_error > 0 Then
                codigo_error += oTrans.Codigo_error
                descripcion_error += oTrans.descripcion_error & " " & pdt.Rows(0).Item("Producto").ToString & " LP " & pdr.Item("Lisprecio")
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Sub Actualizar_ProductoPrecio_VinotecaFB(ByVal pdr As DataRow, ByVal pdt As DataTable)
        'Dim ls_sql As String
        'Dim dr As DataRow

        Inicializar_Errores()



        Try
            fOtrans.Nombre_Tabla = "Itm"
            fOtrans.Lista_Campos = "price = " & Double.Parse(pdr.Item("valor").ToString).ToString("0.00")
            fOtrans.Condiciones = "bohname = '" & pdr.Item("producto").ToString & "'"

            If Not fOtrans.Actualiza() Then
                codigo_error += oTrans.Codigo_error
                descripcion_error += oTrans.descripcion_error & " " & pdr.Item("Producto").ToString & " LP " & pdr.Item("Lisprecio")

            End If

            'dt_Itm = fOtrans.Obtiene()

            'ls_sql = "pa_del_um_SSO_PrmPreciosBase '" & pdt.Rows(0).Item("codigo_corto").ToString & "',1"
            'oTrans.Elimina(ls_sql)
            'codigo_error = oTrans.Codigo_error
            'descripcion_error = oTrans.descripcion_error


            'ls_sql = "pa_ins_um_SSO_PrmPreciosBase null,null,'" & _
            '            pdt.Rows(0).Item("codigo_corto").ToString & "',1," & _
            '            pdr.Item("valor").ToString & ",'QTZ','N',1.12,0,4"
            'oTrans.Ingresa(ls_sql)
            'If codigo_error > 0 Then
            '    codigo_error += oTrans.Codigo_error
            '    descripcion_error += oTrans.descripcion_error & " " & pdt.Rows(0).Item("Producto").ToString & " LP " & dr.Item("Lisprecio")
            'End If
        Catch ex As Exception

        End Try


    End Sub


    Private Function Obtener_Grupo_Vinoteca(ByVal _tipo_producto As String) As Integer
        Dim ls_sql As String
        Dim dt As DataTable
        Dim codigo_grupo As Integer = -1

        Try
            ls_sql = "pa_sel_um_sso_invGrupItem null,'" & _tipo_producto & "'"
            dt = oTrans.Obtiene(ls_sql)
            If dt.Rows.Count = 1 Then
                codigo_grupo = dt.Rows(0).Item("U_SSoCodigo").ToString
            Else
                codigo_grupo = 0
            End If

        Catch ex As Exception
            codigo_grupo = 0
        End Try

        Return codigo_grupo
    End Function

    Private Function Obtener_Proveedor_Vinoteca(ByVal _proveedor As String) As String
        '        Dim ls_sql As String
        '       Dim dt As DataTable
        Dim codigo_grupo As Integer = 0

        Try
            'ls_sql = "pa_sel_um_sso_BP null,'" & _proveedor & "'"
            'dt = oTrans.Obtiene(ls_sql)
            'If dt.Rows.Count = 1 Then
            '    codigo_grupo = dt.Rows(0).Item("U_SSoCodigo").ToString
            'End If

        Catch ex As Exception

        End Try

        Return codigo_grupo
    End Function

    Public Function Existe_ProductoBarra_Vinoteca(ByVal pCodigoBarra As String, ByRef codigo_asignado As String) As Boolean
        Dim dt As DataTable
        Dim ls_sql As String
        Dim lbTieneBarra As Boolean = False

        Try
            ls_sql = "pa_sel_um_SSO_InvBarras '" & pCodigoBarra & "'"
            dt = oTrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                lbTieneBarra = True
                codigo_asignado = dt.Rows(0).Item("U_SSOCodiItem")
            End If

        Catch ex As Exception


        End Try

        Return lbTieneBarra
    End Function

#End Region

End Class
#End Region

#Region "Sincronizacion de Cliente"

Public Class Clientes
    Shared oTrans As Transaccional.Conexion
    Dim ls_sql As String

    Public codigo_error As Integer
    Public descripcion_error As String
    Public dt As DataTable
    Public accion As String

    Public Sub New(ByVal stienda As String)
        Dim ls_string As String
        ls_string = "Flexline" & stienda

        oTrans = New Transaccional.Conexion(ls_string)
        Try
            oTrans.open()
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error

        Catch ex As Exception
            accion = ex.Message
        End Try

    End Sub

    Public Sub Obtener_Cliente(ByVal sempresa As String, ByVal scod_cliente As String)
        ls_sql = "pa_sel_um_ctacte '" & sempresa & "','CLIENTE','" & scod_cliente & "'"

        dt = oTrans.Obtiene(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error


    End Sub

    Public Sub Obtener_Ctacte(ByVal sempresa As String, ByVal scod_cliente As String, stipoCtaCte As String)
        ls_sql = "pa_sel_um_ctacte '" & sempresa & "','" & stipoCtaCte & "','" & scod_cliente & "'"

        dt = oTrans.Obtiene(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error


    End Sub

    ''Envia Informacion a tienda
    Private Sub Enviar_informacion(ByVal sempresa As String, ByVal drv As DataRowView)
        Dim ls_sql As String

        ls_sql = "pa_upd_um_ctacte '" & sempresa & "','CLIENTE','" & drv.Item("CtaCte").ToString & "',NULL,NULL,NULL,'" &
                 drv.Item("CondPago").ToString & "','" & drv.Item("vigencia").ToString & "'," &
                 drv.Item("LimiteCredito") & "," & drv.Item("RetrasoCredito") & ",'" &
                 drv.Item("Comentario1").ToString & "','" & drv.Item("ejecutivo") & "','" &
                 drv.Item("listaprecio").ToString & "'"

        oTrans.Actualiza(ls_sql)
        codigo_error = oTrans.Codigo_error
        descripcion_error = oTrans.descripcion_error
    End Sub

    ''Recibe Informacion de tienda a central
    ''Se Actualizar la Informacion  direccion, razonsocial, giro
    Private Sub Recibe_informacion(ByVal sempresa As String, ByVal dr As DataRow)
        Dim fTrans As New Transaccional.Conexion("flexline")

        Dim ls_sql As String

        Try
            fTrans.open()

            ls_sql = "pa_upd_um_ctacte '" & sempresa & "','CLIENTE','" & dr.Item("CtaCte").ToString & "','" &
                    dr.Item("razonsocial").ToString & "','" & dr.Item("Giro").ToString & "','" &
                    dr.Item("direccion").ToString & "',NULL,NULL,NULL,NULL,NULL,NULL,NULL"

            fTrans.Actualiza(ls_sql)
            codigo_error = fTrans.Codigo_error
            descripcion_error = fTrans.descripcion_error

        Catch ex As Exception
        Finally
            fTrans.close()
            fTrans = Nothing
        End Try
    End Sub

    ''Cliente Nuevo en Central
    Public Sub Inserta_Clientes_Nuevos(ByVal dr_clientes As DataRow, ByVal dt_clientes_direcciones As DataTable, ByVal dt_clientes_gentabcod As DataTable)
        Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "pa_ins_um_ctacte_traslado '" & dr_clientes.Item("empresa").ToString & "','" &
                      dr_clientes.Item("TipoCtaCte").ToString & "','" & dr_clientes.Item("CtaCte").ToString & "','" &
                      dr_clientes.Item("CodLegal").ToString & "','" & dr_clientes.Item("RazonSocial").ToString & "','" &
                      dr_clientes.Item("Sigla").ToString & "','" & dr_clientes.Item("Giro").ToString & "','" &
                      dr_clientes.Item("Tipo").ToString & "','" & dr_clientes.Item("Grupo").ToString & "','" &
                      dr_clientes.Item("Ejecutivo").ToString & "','" & dr_clientes.Item("CondPago").ToString & "','" &
                      dr_clientes.Item("Vigencia").ToString & "','" & dr_clientes.Item("ListaPrecio").ToString & "','" &
                      dr_clientes.Item("Zona").ToString & "','" & dr_clientes.Item("Direccion").ToString & "','" &
                        IIf(dr_clientes.Item("Ciudad") Is System.DBNull.Value, "", dr_clientes.Item("Ciudad").ToString) & "','" &
                          IIf(dr_clientes.Item("Comuna") Is System.DBNull.Value, "", dr_clientes.Item("Comuna").ToString) & "','" &
                            IIf(dr_clientes.Item("Estado") Is System.DBNull.Value, "", dr_clientes.Item("Estado").ToString) & "','" &
                              IIf(dr_clientes.Item("Pais") Is System.DBNull.Value, "", dr_clientes.Item("Pais").ToString) & "','" &
            dr_clientes.Item("Telefono").ToString & "','" & dr_clientes.Item("Fax").ToString & "','" &
                      dr_clientes.Item("eMail").ToString & "','" & dr_clientes.Item("CodPostal").ToString & "','" &
                      dr_clientes.Item("Contacto").ToString & "','" & dr_clientes.Item("ModoEnvio").ToString & "','" &
                      dr_clientes.Item("DireccionEnvio").ToString & "'," &
                          IIf(dr_clientes.Item("LimiteCredito") Is System.DBNull.Value, "NULL", dr_clientes.Item("LimiteCredito").ToString) & ",'" &
                      dr_clientes.Item("VigenciaCredito").ToString & "'," &
            IIf(dr_clientes.Item("RetrasoCredito") Is System.DBNull.Value, "NULL", dr_clientes.Item("RetrasoCredito").ToString) & ",'" &
                      dr_clientes.Item("Comentario1").ToString & "','" & dr_clientes.Item("Comentario2").ToString & "','" &
                      dr_clientes.Item("Comentario3").ToString & "','" & dr_clientes.Item("Comentario4").ToString & "','" &
                      dr_clientes.Item("FechaModif").ToString & "','" & dr_clientes.Item("UsuarioModif").ToString & "','" &
                      dr_clientes.Item("TipoContribuyente").ToString & "'," &
                      IIf(dr_clientes.Item("PorcDr1") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr1").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr2") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr2").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr3") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr3").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr4") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr4").ToString) & ",'" &
                      dr_clientes.Item("AnalisisCtacte1").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte2").ToString & "','" & dr_clientes.Item("AnalisisCtaCte3").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte4").ToString & "','" & dr_clientes.Item("AnalisisCtaCte5").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte6").ToString & "','" & dr_clientes.Item("AnalisisCtaCte7").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte8").ToString & "','" & dr_clientes.Item("AnalisisCtaCte9").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte10").ToString & "','" & dr_clientes.Item("ZonaCob").ToString & "','" &
                      dr_clientes.Item("FlujoCob").ToString & "','" & dr_clientes.Item("CobradorCob").ToString & "','" &
                      dr_clientes.Item("FechaBloqueo").ToString & "','" & dr_clientes.Item("UsuarioBloqueo").ToString & "','" &
                      dr_clientes.Item("ComentarioBloqueo").ToString & "','" & dr_clientes.Item("Moneda").ToString & "','" &
                      dr_clientes.Item("EstaCertificado").ToString & "'"

            Otrans.Ingresa(ls_sql)


            If Otrans.Codigo_error = 0 Then
                For Each dr In dt_clientes_direcciones.Rows
                    ls_sql = "pa_ins_um_ctacteDirecciones_traslado '" & dr.Item("Empresa").ToString & "','" &
                             dr.Item("CtaCte").ToString & "','" & dr.Item("Direccion").ToString & "','" &
                             dr.Item("Comuna").ToString & "','" & dr.Item("Ciudad").ToString & "','" &
                             dr.Item("Estado").ToString & "','" & dr.Item("Pais").ToString & "','" &
                             dr.Item("Telefono").ToString & "','" & dr.Item("Fax").ToString & "','" &
                             dr.Item("CodPostal").ToString & "','" & dr.Item("eMail").ToString & "','" &
                             dr.Item("ModoEnvio").ToString & "','" & dr.Item("Principal").ToString & "','" &
                             dr.Item("TipoCtaCte").ToString & "'"

                    Otrans.Ingresa(ls_sql)

                Next

                dr = dt_clientes_gentabcod.Rows(0)
                ls_sql = "pa_ins_um_gen_tabcod '" & dr.Item("Empresa").ToString & "','" & dr.Item("Tipo").ToString & "','" &
                            dr.Item("codigo").ToString & "','" & dr.Item("nemotecnico") & "','" &
                            dr.Item("descripcion").ToString & "'," &
                            IIf(dr.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto").ToString & "'") & "," &
                            IIf(dr.Item("Texto1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto1").ToString & "'") & "," &
                            IIf(dr.Item("Texto2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto2").ToString & "'") & "," &
                            IIf(dr.Item("Texto3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto3").ToString & "'") & "," &
                            IIf(dr.Item("Texto4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto4").ToString & "'") & "," &
                            IIf(dr.Item("Texto5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto5").ToString & "'") & "," &
                            IIf(dr.Item("Valor1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor1").ToString & "'") & "," &
                            IIf(dr.Item("Valor2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor2").ToString & "'") & "," &
                            IIf(dr.Item("Valor3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor3").ToString & "'") & "," &
                            IIf(dr.Item("Valor4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor4").ToString & "'") & "," &
                            IIf(dr.Item("Valor5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor5").ToString & "'") & ",'" &
                            dr.Item("Vigencia").ToString & "'," &
                            IIf(dr.Item("RelacionTipo1") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionTipo1").ToString & "'") & "," &
                            IIf(dr.Item("RelacionCodigo1") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionCodigo1").ToString & "'") & "," &
                            IIf(dr.Item("RelacionTipo2") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionTipo2").ToString & "'") & "," &
                            IIf(dr.Item("RelacionCodigo2") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionCodigo2").ToString & "'") & "," &
                            IIf(dr.Item("Moneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("Moneda").ToString & "'")

                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    descripcion_error += Otrans.descripcion_error
                End If

            Else
                descripcion_error = Otrans.descripcion_error
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    ''Cliente Nuevo en Central
    Public Sub envia_ctacte(ByVal dr_clientes As DataRow, ByVal dt_clientes_direcciones As DataTable, ByVal dt_clientes_gentabcod As DataTable)
        Dim dr As DataRow
        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            '   Otrans.open()
            ls_sql = "pa_ins_um_ctacte_traslado '" & dr_clientes.Item("empresa").ToString & "','" &
                      dr_clientes.Item("TipoCtaCte").ToString & "','" & dr_clientes.Item("CtaCte").ToString & "','" &
                      dr_clientes.Item("CodLegal").ToString & "','" & dr_clientes.Item("RazonSocial").ToString & "','" &
                      dr_clientes.Item("Sigla").ToString & "','" & dr_clientes.Item("Giro").ToString & "','" &
                      dr_clientes.Item("Tipo").ToString & "','" & dr_clientes.Item("Grupo").ToString & "','" &
                      dr_clientes.Item("Ejecutivo").ToString & "','" & dr_clientes.Item("CondPago").ToString & "','" &
                      dr_clientes.Item("Vigencia").ToString & "','" & dr_clientes.Item("ListaPrecio").ToString & "','" &
                      dr_clientes.Item("Zona").ToString & "','" & dr_clientes.Item("Direccion").ToString & "','" &
                        IIf(dr_clientes.Item("Ciudad") Is System.DBNull.Value, "", dr_clientes.Item("Ciudad").ToString) & "','" &
                          IIf(dr_clientes.Item("Comuna") Is System.DBNull.Value, "", dr_clientes.Item("Comuna").ToString) & "','" &
                            IIf(dr_clientes.Item("Estado") Is System.DBNull.Value, "", dr_clientes.Item("Estado").ToString) & "','" &
                              IIf(dr_clientes.Item("Pais") Is System.DBNull.Value, "", dr_clientes.Item("Pais").ToString) & "','" &
            dr_clientes.Item("Telefono").ToString & "','" & dr_clientes.Item("Fax").ToString & "','" &
                      dr_clientes.Item("eMail").ToString & "','" & dr_clientes.Item("CodPostal").ToString & "','" &
                      dr_clientes.Item("Contacto").ToString & "','" & dr_clientes.Item("ModoEnvio").ToString & "','" &
                      dr_clientes.Item("DireccionEnvio").ToString & "'," &
                          IIf(dr_clientes.Item("LimiteCredito") Is System.DBNull.Value, "NULL", dr_clientes.Item("LimiteCredito").ToString) & ",'" &
                      dr_clientes.Item("VigenciaCredito").ToString & "'," &
            IIf(dr_clientes.Item("RetrasoCredito") Is System.DBNull.Value, "NULL", dr_clientes.Item("RetrasoCredito").ToString) & ",'" &
                      dr_clientes.Item("Comentario1").ToString & "','" & dr_clientes.Item("Comentario2").ToString & "','" &
                      dr_clientes.Item("Comentario3").ToString & "','" & dr_clientes.Item("Comentario4").ToString & "','" &
                      dr_clientes.Item("FechaModif").ToString & "','" & dr_clientes.Item("UsuarioModif").ToString & "','" &
                      dr_clientes.Item("TipoContribuyente").ToString & "'," &
                      IIf(dr_clientes.Item("PorcDr1") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr1").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr2") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr2").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr3") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr3").ToString) & "," &
                      IIf(dr_clientes.Item("PorcDr4") Is System.DBNull.Value, "NULL", dr_clientes.Item("PorcDr4").ToString) & ",'" &
                      dr_clientes.Item("AnalisisCtacte1").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte2").ToString & "','" & dr_clientes.Item("AnalisisCtaCte3").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte4").ToString & "','" & dr_clientes.Item("AnalisisCtaCte5").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte6").ToString & "','" & dr_clientes.Item("AnalisisCtaCte7").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte8").ToString & "','" & dr_clientes.Item("AnalisisCtaCte9").ToString & "','" &
                      dr_clientes.Item("AnalisisCtacte10").ToString & "','" & dr_clientes.Item("ZonaCob").ToString & "','" &
                      dr_clientes.Item("FlujoCob").ToString & "','" & dr_clientes.Item("CobradorCob").ToString & "','" &
                      dr_clientes.Item("FechaBloqueo").ToString & "','" & dr_clientes.Item("UsuarioBloqueo").ToString & "','" &
                      dr_clientes.Item("ComentarioBloqueo").ToString & "','" & dr_clientes.Item("Moneda").ToString & "','" &
                      dr_clientes.Item("EstaCertificado").ToString & "'"

            Otrans.Ingresa(ls_sql)


            If Otrans.Codigo_error = 0 Then
                For Each dr In dt_clientes_direcciones.Rows
                    ls_sql = "pa_ins_um_ctacteDirecciones_traslado '" & dr.Item("Empresa").ToString & "','" &
                             dr.Item("CtaCte").ToString & "','" & dr.Item("Direccion").ToString & "','" &
                             dr.Item("Comuna").ToString & "','" & dr.Item("Ciudad").ToString & "','" &
                             dr.Item("Estado").ToString & "','" & dr.Item("Pais").ToString & "','" &
                             dr.Item("Telefono").ToString & "','" & dr.Item("Fax").ToString & "','" &
                             dr.Item("CodPostal").ToString & "','" & dr.Item("eMail").ToString & "','" &
                             dr.Item("ModoEnvio").ToString & "','" & dr.Item("Principal").ToString & "','" &
                             dr.Item("TipoCtaCte").ToString & "'"

                    Otrans.Ingresa(ls_sql)

                Next

                dr = dt_clientes_gentabcod.Rows(0)
                ls_sql = "pa_ins_um_gen_tabcod '" & dr.Item("Empresa").ToString & "','" & dr.Item("Tipo").ToString & "','" &
                            dr.Item("codigo").ToString & "','" & dr.Item("nemotecnico") & "','" &
                            dr.Item("descripcion").ToString & "'," &
                            IIf(dr.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto").ToString & "'") & "," &
                            IIf(dr.Item("Texto1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto1").ToString & "'") & "," &
                            IIf(dr.Item("Texto2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto2").ToString & "'") & "," &
                            IIf(dr.Item("Texto3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto3").ToString & "'") & "," &
                            IIf(dr.Item("Texto4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto4").ToString & "'") & "," &
                            IIf(dr.Item("Texto5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto5").ToString & "'") & "," &
                            IIf(dr.Item("Valor1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor1").ToString & "'") & "," &
                            IIf(dr.Item("Valor2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor2").ToString & "'") & "," &
                            IIf(dr.Item("Valor3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor3").ToString & "'") & "," &
                            IIf(dr.Item("Valor4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor4").ToString & "'") & "," &
                            IIf(dr.Item("Valor5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Valor5").ToString & "'") & ",'" &
                            dr.Item("Vigencia").ToString & "'," &
                            IIf(dr.Item("RelacionTipo1") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionTipo1").ToString & "'") & "," &
                            IIf(dr.Item("RelacionCodigo1") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionCodigo1").ToString & "'") & "," &
                            IIf(dr.Item("RelacionTipo2") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionTipo2").ToString & "'") & "," &
                            IIf(dr.Item("RelacionCodigo2") Is System.DBNull.Value, "NULL", "'" & dr.Item("RelacionCodigo2").ToString & "'") & "," &
                            IIf(dr.Item("Moneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("Moneda").ToString & "'")

                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    descripcion_error += Otrans.descripcion_error
                End If

            Else
                descripcion_error = Otrans.descripcion_error
            End If


        Catch ex As Exception
        Finally
            ' Otrans.close()
            'oTrans = Nothing

        End Try

    End Sub


    Public Sub Actualizar_Cliente(ByVal tipo As Short, ByVal sempresa As String, ByVal drv As DataRowView, ByVal dr As DataRow)

        If tipo = 1 Then
            Enviar_informacion(sempresa, drv)
            Recibe_informacion(sempresa, dr)
        ElseIf tipo = 2 Then
            Enviar_informacion(sempresa, drv)
        ElseIf tipo = 3 Then
            Recibe_informacion(sempresa, dr)
        End If

    End Sub


    Public Sub Cerrar()
        oTrans.close()
        oTrans = Nothing
    End Sub

End Class
#End Region

#Region "Sincronizacion de Documentos a Tiendas"
Public Class Documentos
    Shared oTrans As Transaccional.Conexion
    Dim ls_sql As String

    Public codigo_error As Integer
    Public descripcion_error As String
    Public dt As DataTable
    Public accion As String
    Public HayErrores As Boolean = False

    Public Sub New(ByVal stienda As String)
        Dim ls_string As String
        ls_string = "Flexline" & stienda

        oTrans = New Transaccional.Conexion(ls_string)
        Try
            oTrans.open()
            codigo_error = oTrans.Codigo_error
            descripcion_error = oTrans.descripcion_error

        Catch ex As Exception
            accion = ex.Message
        End Try

    End Sub

    Private Sub Inicializar_Errores()
        HayErrores = False
        codigo_error = 0
        descripcion_error = ""
    End Sub

    ''Envia Informacion a tienda
    Public Sub Enviar_Documento(ByVal psempresa As String, ByVal dr_encabezado As DataRow,
                            ByVal dt_detalle As DataTable,
                            ByVal dt_documentov As DataTable,
                            ByVal dt_documentop As DataTable,
                            ByVal ptipodocto As String, ByVal sobreescribir As Boolean)



        Dim ls_sql As String

        Inicializar_Errores()

        Dim ls_dempresa, ls_dtipodocto, ls_dnumero, ls_dfecha, ls_dfechaVcto, ls_dvendedor, ls_dlistaPrecio, ls_daprobacion As String
        Dim ls_ddireccion, ls_dciudad, ls_dcomuna, ls_dpais, ls_dcontacto As String
        Dim ls_dcliente, ls_dbodega, ls_dmoneda, ls_dcentraliza As String
        Dim ln_dcorrelativo As Integer
        Dim ld_dtotal As Double
        Dim ld_dneto As Double

        Dim ld_dsubtotal, ld_dNetoIngreso, ld_dSubTotalIngreso, ld_dTotalIngreso As Double
        Dim ls_dproveedor, ls_dCtaCte, ls_dvaloriza, ls_dPeriodoLibro, ls_dTipoCtaCte, ls_dIdCtaCte, ls_dGlosa, ls_dvigencia As String
        Dim ls_dEmitido, ls_dUsuarioModif As String
        Dim ld_dNetoBimoneda, ld_dSubTotalBimoneda, ld_dTotalBimoneda, ld_dParidadBimoneda As Double
        Dim ls_dcomentario1 As String
        Dim li_sresultado As Integer
        Dim ls_pedido_generado As Integer

        Dim ls_Query As String

        Dim li_procesos As Integer = 0
        Dim li_linea As Integer = 0

        Dim otabla As DataTable
        Dim dr As DataRow

        Try
            ls_dempresa = psempresa
            If ptipodocto.Length > 0 Then
                ls_dtipodocto = ptipodocto
                ln_dcorrelativo = 0
            Else
                ls_dtipodocto = dr_encabezado.Item("TipoDocto")
                ln_dcorrelativo = dr_encabezado.Item("Correlativo")
            End If

            ls_dCtaCte = dr_encabezado.Item("CtaCte").ToString
            ls_dproveedor = dr_encabezado.Item("Proveedor").ToString
            ls_dnumero = dr_encabezado.Item("numero").ToString
            ls_dfecha = dr_encabezado.Item("fecha").ToString
            ls_dfechaVcto = dr_encabezado.Item("fechavcto").ToString
            ls_dcliente = dr_encabezado.Item("cliente").ToString
            ls_dbodega = dr_encabezado.Item("bodega").ToString
            ls_dmoneda = dr_encabezado.Item("moneda").ToString
            ld_dneto = dr_encabezado.Item("neto").ToString
            ld_dsubtotal = dr_encabezado.Item("SubTotal").ToString
            ld_dtotal = dr_encabezado.Item("Total").ToString
            ld_dNetoIngreso = dr_encabezado.Item("NetoIngreso").ToString
            ld_dSubTotalIngreso = dr_encabezado.Item("SubTotalIngreso").ToString
            ld_dTotalIngreso = dr_encabezado.Item("TotalIngreso").ToString
            ls_dcentraliza = dr_encabezado.Item("Centraliza").ToString
            ls_dvaloriza = dr_encabezado.Item("Valoriza").ToString
            ls_daprobacion = dr_encabezado.Item("Aprobacion").ToString
            ls_dPeriodoLibro = dr_encabezado.Item("PeriodoLibro").ToString
            ls_dTipoCtaCte = dr_encabezado.Item("TipoCtaCte").ToString
            ls_dIdCtaCte = dr_encabezado.Item("IdCtaCte").ToString
            ls_dGlosa = dr_encabezado.Item("Glosa").ToString
            ls_dcomentario1 = dr_encabezado.Item("Comentario1").ToString
            ls_dvigencia = dr_encabezado.Item("vigencia").ToString
            ls_dEmitido = dr_encabezado.Item("Emitido").ToString
            ls_dUsuarioModif = dr_encabezado.Item("UsuarioModif").ToString
            ld_dNetoBimoneda = dr_encabezado.Item("NetoBimoneda").ToString
            ld_dSubTotalBimoneda = dr_encabezado.Item("SubTotalBimoneda").ToString
            ld_dTotalBimoneda = dr_encabezado.Item("TotalBimoneda").ToString
            ld_dParidadBimoneda = dr_encabezado.Item("ParidadBimoneda").ToString
            ls_dlistaPrecio = dr_encabezado.Item("ListaPrecio").ToString
            ls_dvendedor = dr_encabezado.Item("vendedor").ToString
            ls_ddireccion = dr_encabezado.Item("direccion").ToString
            ls_dciudad = dr_encabezado.Item("ciudad").ToString
            ls_dcomuna = dr_encabezado.Item("comuna").ToString
            ls_dpais = dr_encabezado.Item("pais").ToString
            ls_dcontacto = dr_encabezado.Item("contacto").ToString

            dr = dr_encabezado '' Procesar el encabezado
            '' Si No Pudo Asignar el correlativo no continua
            If ls_dnumero.Length >= 10 Then

                Try
                    ''Valido nuevamente que no exista ningun documento con ese numero y ese tipo
                    ls_sql = "pa_var_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," &
                                IIf(ln_dcorrelativo > 0, ln_dcorrelativo, "NULL")
                    otabla = oTrans.Obtiene(ls_sql)
                    li_sresultado = otabla.Rows(0).Item("correlativo")
                    If otabla.Rows(0).Item("TipoComprobante").ToString.Trim.Length < 1 Then
                        If sobreescribir Then
                            ''Elimino el documento anterior
                            ls_Query = "pa_del_um_documento_completo_temp '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ln_dcorrelativo.ToString
                            li_sresultado = oTrans.Elimina(ls_Query)
                            If li_sresultado > 0 Then
                                li_sresultado = -1
                            End If

                        End If
                    End If

                Catch ex As Exception
                    li_sresultado = -1
                    'guardarLog(ex.Source)
                End Try

                'Si el documento aun no existe en la BD lo Agrego
                If li_sresultado = -1 Then

                    Try
                        ls_sql = "pa_ins_um_documento_traslado_fel_tmp '" & ls_dempresa & "','" & ls_dtipodocto & "'," &
                                        ln_dcorrelativo.ToString & ",'" & ls_dCtaCte & "','" &
                                        ls_dnumero & "','" & ls_dfecha & "','" & ls_dproveedor & "','" & ls_dcliente & "','" &
                                        ls_dbodega & "','" & dr.Item("bodega2").ToString & "','" & dr.Item("local").ToString & "','" &
                                        dr.Item("comprador").ToString & "','" & ls_dvendedor & "','" &
                                        dr.Item("CentroCosto").ToString & "','" & ls_dfechaVcto & "','" &
                                        ls_dlistaPrecio & "','" & dr.Item("Analisis").ToString & "','" &
                                        dr.Item("Zona").ToString & "','" &
                                        dr.Item("tipocta").ToString & "','" &
                                        dr.Item("moneda").ToString & "'," & dr.Item("paridad").ToString & "," &
                                        IIf(dr.Item("RefTipoDocto") Is System.DBNull.Value, "NULL", "'" & dr.Item("RefTipoDocto").ToString & "'") &
                                        "," & CStr(ld_dneto) &
                                        "," & CStr(ld_dsubtotal) & "," & CStr(ld_dtotal) & "," & CStr(ld_dNetoIngreso) & "," &
                                        CStr(ld_dSubTotalIngreso) & "," & CStr(ld_dTotalIngreso) & ",'" & ls_dcentraliza & "','" &
                                        ls_dvaloriza & "','" &
                                        dr.Item("costeo").ToString & "','" &
                                        ls_daprobacion & "','" &
                                        dr.Item("TipoComprobante").ToString & "'," & ls_dPeriodoLibro & "," &
                                        dr.Item("FactorMonto").ToString & ", '" & ls_dTipoCtaCte & "','" &
                                        ls_dIdCtaCte & "','" & Replace(ls_dGlosa, "'", "") & "','" & Replace(ls_dcomentario1, "'", "") & "','" & dr.Item("comentario2").ToString & "'," &
                                        IIf(dr.Item("Comentario3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario3").ToString & "'") & "," &
                                        IIf(dr.Item("Comentario4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario4").ToString & "'") & ",'" &
                                        ls_dvigencia & "','" & ls_dEmitido & "'," & dr.Item("PorcentajeAsignado").ToString & ",'" &
                                         ls_ddireccion & "','" & ls_dciudad & "','" & ls_dcomuna & "','" & dr.Item("EstadoDir").ToString & "','" & ls_dpais &
                                        "','" & ls_dcontacto & "','" & dr.Item("FechaModif").ToString & "','" & dr.Item("FechaUModif").ToString & "','" & ls_dUsuarioModif & "'," &
                                        IIf(dr.Item("ComisionTotal") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionTotal").ToString & "'") & "," &
                                        IIf(dr.Item("ComisionLPrecio") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionLPrecio").ToString & "'") & ",'" &
                                        dr.Item("Hora").ToString & "'," &
                                        IIf(dr.Item("Caja") Is System.DBNull.Value, "NULL", "'" & dr.Item("Caja").ToString & "'") & "," &
                                        IIf(dr.Item("Pago") Is System.DBNull.Value, "NULL", dr.Item("pago").ToString) & "," &
                                        IIf(dr.Item("Donacion") Is System.DBNull.Value, "NULL", dr.Item("Donacion").ToString) & "," &
                                        IIf(dr.Item("IdApertura") Is System.DBNull.Value, "NULL", dr.Item("IdApertura").ToString) & "," &
                                        IIf(dr.Item("Multipagina") Is System.DBNull.Value, "NULL", "'" & dr.Item("Multipagina").ToString & "'") & "," &
                                        CStr(ld_dNetoBimoneda) & "," & CStr(ld_dSubTotalBimoneda) & "," &
                                        CStr(ld_dTotalBimoneda) & "," & CStr(ld_dParidadBimoneda) & ",'" &
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
                        IIf(dr.Item("AnalisisE4") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE4").ToString & "'") & "," &
                        IIf(dr.Item("AnalisisE5") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE5").ToString & "'") & "," &
                        IIf(dr.Item("AnalisisE6") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE6").ToString & "'")





                        ''ingresamos encabezado
                        li_sresultado = oTrans.Ingresa(ls_sql)
                        codigo_error = oTrans.Codigo_error
                        descripcion_error = oTrans.descripcion_error

                        'If li_sresultado > 0 Then
                        If codigo_error > 0 Then
                            HayErrores = True
                        Else
                            If ln_dcorrelativo > 0 Then
                                ls_pedido_generado = ln_dcorrelativo
                            Else
                                ls_sql = "pa_var_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," &
                                                                   IIf(ln_dcorrelativo > 0, ln_dcorrelativo, "NULL")
                                otabla = oTrans.Obtiene(ls_sql)

                                codigo_error = oTrans.Codigo_error
                                descripcion_error = oTrans.descripcion_error
                                ls_pedido_generado = otabla.Rows(0).Item("correlativo")
                            End If


                            ''ingreso documentop
                            If dt_documentop.Rows.Count > 0 Then

                                For Each dr In dt_documentop.Rows
                                    ls_Query = "pa_ins_um_documentop_traslado_tmp '" & dr.Item("Empresa").ToString & "','" &
                                                ls_dtipodocto & "'," & CStr(ls_pedido_generado) & "," & dr.Item("Linea") & ",'" &
                                                dr.Item("codigopago").ToString & "','" & dr.Item("TipoPago").ToString & "','" &
                                                dr.Item("FechaVcto").ToString & "'," & dr.Item("Monto").ToString & "," &
                                                dr.Item("MontoIngreso").ToString & ",'" & dr.Item("TipoDoctoPago").ToString & "','" &
                                                dr.Item("NroDoctoPago").ToString & "','" & dr.Item("Cuenta").ToString & "'," &
                                                IIf(dr.Item("MontoBimoneda") Is System.DBNull.Value, "NULL", dr.Item("MontoBimoneda").ToString) & "," &
                                                IIf(dr.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr.Item("AjusteBimoneda").ToString) & ",'" &
                                                dr.Item("Entidad").ToString & "','" & dr.Item("NumAutoriza").ToString & "','" &
                                                dr.Item("CuentaPago").ToString & "','" & dr.Item("FechaVctoTarjeta").ToString & "','" &
                                                dr.Item("PropietarioTarjeta").ToString & "','" & dr.Item("FechaVctoDocto").ToString & "','" &
                                                dr.Item("RutComprador").ToString & "','" & dr.Item("RutGirador").ToString & "','" &
                                                dr.Item("MonedaPago").ToString & "'," & dr.Item("MontoPago").ToString & "," &
                                                dr.Item("ParidadPago").ToString & ",'" & dr.Item("ValorGenerico").ToString & "'"

                                    li_sresultado = oTrans.Ingresa(ls_Query)
                                    codigo_error = oTrans.Codigo_error
                                    descripcion_error = oTrans.descripcion_error
                                    If codigo_error > 0 Then
                                        HayErrores = True
                                    End If
                                Next

                            End If

                            ''Ingreso DocumentoV
                            If dt_documentov.Rows.Count > 0 Then
                                For Each dr In dt_documentov.Rows
                                    ls_Query = "pa_ins_um_documentov_traslado '" & dr.Item("Empresa").ToString & "','" & ls_dtipodocto & "'," &
                                                CStr(ls_pedido_generado) & ",'" & dr.Item("Nombre").ToString & "'," &
                                                dr.Item("Orden").ToString & "," & dr.Item("Factor").ToString & "," &
                                                dr.Item("Monto").ToString & "," & dr.Item("MontoIngreso").ToString & "," &
                                                dr.Item("Ajuste").ToString & "," & dr.Item("AjusteIngreso").ToString & "," &
                                                IIf(dr.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto").ToString & "'") & "," &
                                                dr.Item("Porcentaje").ToString & "," &
                                                dr.Item("MontoBimoneda").ToString & "," &
                                                IIf(dr.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr.Item("AjusteBimoneda").ToString)

                                    li_sresultado = oTrans.Ingresa(ls_Query)
                                    codigo_error = oTrans.Codigo_error
                                    descripcion_error = oTrans.descripcion_error
                                    If codigo_error > 0 Then
                                        HayErrores = True
                                    End If
                                Next

                            End If

                            'ingreso documentoD
                            For Each dr In dt_detalle.Rows

                                ls_Query = "pa_ins_um_documentod_traslado_tmp '" & dr.Item("Empresa") & "','" & ls_dtipodocto & "'," &
                                            CStr(ls_pedido_generado) & "," & dr.Item("Secuencia") & "," & dr.Item("Linea") & ",'" &
                                            dr.Item("Producto") & "'," & dr.Item("Cantidad") & "," & dr.Item("Precio") & "," &
                                            dr.Item("PorcentajeDr") & "," & dr.Item("SubTotal") & "," & dr.Item("Impuesto") & "," &
                                            dr.Item("Neto") & "," & dr.Item("DRGlobal") & "," & dr.Item("Costo") & "," &
                                            dr.Item("Total") & "," & dr.Item("PrecioAjustado") & ",'" & dr.Item("UnidadIngreso") & "'," &
                                            dr.Item("CantidadIngreso") & "," & dr.Item("PrecioIngreso") & "," & dr.Item("SubTotalIngreso") & "," &
                                            dr.Item("ImpuestoIngreso") & "," & dr.Item("NetoIngreso") & "," & dr.Item("DRGlobalIngreso") & "," &
                                            dr.Item("TotalIngreso") & ",'" & dr.Item("TipoDoctoOrigen") & "'," &
                                            dr.Item("CorrelativoOrigen") & "," & dr.Item("SecuenciaOrigen") & ",'" &
                                            dr.Item("Bodega") & "'," & dr.Item("FactorInventario") & ",'" &
                                            dr.Item("FechaEntrega") & "'," & dr.Item("CantidadAsignada") & ",'" &
                                            dr.Item("Fecha") & "','" & dr.Item("comentario").ToString.Replace("'", "") & "','" &
                                            dr.Item("Vigente") & "'," &
                                            IIf(dr.Item("CUP") Is System.DBNull.Value, "NULL", dr.Item("CUP").ToString) & ",'" &
                                            dr.Item("Ubicacion") & "','" & dr.Item("Ubicacion2") & "','" & dr.Item("cuenta").ToString & "'," &
                                            IIf(dr.Item("Impdist") Is System.DBNull.Value, "NULL", dr.Item("Impdist").ToString) & "," &
                                            IIf(dr.Item("FactorImpto") Is System.DBNull.Value, "NULL", dr.Item("FactorImpto").ToString) &
                                            "," & dr.Item("PrecioBimoneda") & "," &
                                            dr.Item("SubTotalBimoneda") & "," & dr.Item("ImpuestoBimoneda") & "," &
                                            dr.Item("NetoBimoneda") & "," & dr.Item("DrGlobalBimoneda") & "," &
                                            dr.Item("TotalBimoneda") & "," & dr.Item("PrecioListaP") & "," &
                                            IIf(dr.Item("UniMedDynamic") Is System.DBNull.Value, "NULL", dr.Item("UniMedDynamic").ToString) & ",'" &
                                            dr.Item("FechaVigenciaLp") & "','" &
                                            dr.Item("LoteDestino").ToString & "','" & dr.Item("SerieDestino").ToString & "','" &
                                            dr.Item("ProdAlias").ToString & "','" & dr.Item("DoctoOrigenVal") & "'," &
                                            IIf(dr.Item("MontoAsignado") Is System.DBNull.Value, "NULL", dr.Item("MontoAsignado").ToString) & "," &
                                            IIf(dr.Item("Aux_Valor1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor1").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor2").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor3").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor4").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor5").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor6") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor6").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor7") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor7").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor8") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor8").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor9") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor9").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor10") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor10").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor11") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor11").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor12") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor12").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor13") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor13").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor14") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor14").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor15") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor15").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5Bimoneda").ToString & "'")



                                li_sresultado = oTrans.Ingresa(ls_Query)
                                codigo_error = oTrans.Codigo_error
                                descripcion_error = oTrans.descripcion_error

                                If oTrans.Codigo_error > 0 Then
                                    li_sresultado = -99
                                    HayErrores = True
                                    guardarLog(oTrans.descripcion_error)
                                    Exit For
                                End If
                            Next

                        End If

                        If HayErrores Then
                            codigo_error = 89

                            ls_Query = "pa_del_um_documento_completo '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ls_pedido_generado
                            li_sresultado = oTrans.Elimina(ls_Query)
                        End If

                    Catch ex As Exception
                        codigo_error = 88
                        descripcion_error = ex.Message
                        HayErrores = True
                        guardarLog(ex.Source)
                    Finally
                    End Try
                Else
                    codigo_error = 87
                    descripcion_error = "Este Documento ya Existe en la Tienda"
                    HayErrores = True
                End If
            End If


        Catch ex As Exception
            codigo_error = 86
            descripcion_error = ex.Message
            HayErrores = True
            guardarLog(ex.Source)
            '   MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK)
        Finally
            '      oTrans = Nothing
        End Try

    End Sub

    ''Envia Informacion a tienda
    Public Sub Enviar_Documento_Tienda(ByVal psempresa As String, ByVal dr_encabezado As DataRow,
                            ByVal dt_detalle As DataTable,
                            ByVal dt_documentov As DataTable,
                            ByVal dt_documentop As DataTable,
                            ByVal ptipodocto As String, ByVal sobreescribir As Boolean)


        ''Esdras 8:22 La mano de nuestro Dios es propicia para con todos los 
        ''            que le buscan, mas su poder y su ira contra todos los 
        ''            que le abandonan.

        Dim ls_sql As String

        Inicializar_Errores()

        Dim ls_dempresa, ls_dtipodocto, ls_dnumero, ls_dfecha, ls_dfechaVcto, ls_dvendedor, ls_dlistaPrecio, ls_daprobacion As String
        Dim ls_ddireccion, ls_dciudad, ls_dcomuna, ls_dpais, ls_dcontacto As String
        Dim ls_dcliente, ls_dbodega, ls_dmoneda, ls_dcentraliza As String
        Dim ln_dcorrelativo As Integer
        Dim ld_dtotal As Double
        Dim ld_dneto As Double

        Dim ld_dsubtotal, ld_dNetoIngreso, ld_dSubTotalIngreso, ld_dTotalIngreso As Double
        Dim ls_dproveedor, ls_dCtaCte, ls_dvaloriza, ls_dPeriodoLibro, ls_dTipoCtaCte, ls_dIdCtaCte, ls_dGlosa, ls_dvigencia As String
        Dim ls_dEmitido, ls_dUsuarioModif As String
        Dim ld_dNetoBimoneda, ld_dSubTotalBimoneda, ld_dTotalBimoneda, ld_dParidadBimoneda As Double
        Dim ls_dcomentario1 As String
        Dim li_sresultado As Integer
        Dim ls_pedido_generado As Integer

        Dim ls_Query As String

        Dim li_procesos As Integer = 0
        Dim li_linea As Integer = 0

        Dim otabla As DataTable
        Dim dr As DataRow

        Try
            ls_dempresa = psempresa
            If ptipodocto.Length > 0 Then
                ls_dtipodocto = ptipodocto
                ln_dcorrelativo = 0
            Else
                ls_dtipodocto = dr_encabezado.Item("TipoDocto")
                ln_dcorrelativo = dr_encabezado.Item("Correlativo")
            End If

            ls_dCtaCte = dr_encabezado.Item("CtaCte").ToString
            ls_dproveedor = dr_encabezado.Item("Proveedor").ToString
            ls_dnumero = dr_encabezado.Item("numero").ToString
            ls_dfecha = dr_encabezado.Item("fecha").ToString
            ls_dfechaVcto = dr_encabezado.Item("fechavcto").ToString
            ls_dcliente = dr_encabezado.Item("cliente").ToString
            ls_dbodega = dr_encabezado.Item("bodega").ToString
            ls_dmoneda = dr_encabezado.Item("moneda").ToString
            ld_dneto = dr_encabezado.Item("neto").ToString
            ld_dsubtotal = dr_encabezado.Item("SubTotal").ToString
            ld_dtotal = dr_encabezado.Item("Total").ToString
            ld_dNetoIngreso = dr_encabezado.Item("NetoIngreso").ToString
            ld_dSubTotalIngreso = dr_encabezado.Item("SubTotalIngreso").ToString
            ld_dTotalIngreso = dr_encabezado.Item("TotalIngreso").ToString
            ls_dcentraliza = dr_encabezado.Item("Centraliza").ToString
            ls_dvaloriza = dr_encabezado.Item("Valoriza").ToString
            ls_daprobacion = dr_encabezado.Item("Aprobacion").ToString
            ls_dPeriodoLibro = dr_encabezado.Item("PeriodoLibro").ToString
            ls_dTipoCtaCte = dr_encabezado.Item("TipoCtaCte").ToString
            ls_dIdCtaCte = dr_encabezado.Item("IdCtaCte").ToString
            ls_dGlosa = dr_encabezado.Item("Glosa").ToString
            ls_dcomentario1 = dr_encabezado.Item("Comentario1").ToString
            ls_dvigencia = dr_encabezado.Item("vigencia").ToString
            ls_dEmitido = dr_encabezado.Item("Emitido").ToString
            ls_dUsuarioModif = dr_encabezado.Item("UsuarioModif").ToString
            ld_dNetoBimoneda = dr_encabezado.Item("NetoBimoneda").ToString
            ld_dSubTotalBimoneda = dr_encabezado.Item("SubTotalBimoneda").ToString
            ld_dTotalBimoneda = dr_encabezado.Item("TotalBimoneda").ToString
            ld_dParidadBimoneda = dr_encabezado.Item("ParidadBimoneda").ToString
            ls_dlistaPrecio = dr_encabezado.Item("ListaPrecio").ToString
            ls_dvendedor = dr_encabezado.Item("vendedor").ToString
            ls_ddireccion = dr_encabezado.Item("direccion").ToString
            ls_dciudad = dr_encabezado.Item("ciudad").ToString
            ls_dcomuna = dr_encabezado.Item("comuna").ToString
            ls_dpais = dr_encabezado.Item("pais").ToString
            ls_dcontacto = dr_encabezado.Item("contacto").ToString

            dr = dr_encabezado '' Procesar el encabezado
            '' Si No Pudo Asignar el correlativo no continua
            If ls_dnumero.Length >= 10 Then

                Try
                    ''Valido nuevamente que no exista ningun documento con ese numero y ese tipo
                    ls_sql = "pa_var_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," &
                                IIf(ln_dcorrelativo > 0, ln_dcorrelativo, "NULL")
                    otabla = oTrans.Obtiene(ls_sql)
                    li_sresultado = otabla.Rows(0).Item("correlativo")
                    'If otabla.Rows(0).Item("TipoComprobante").ToString.Trim.Length < 1 Then
                    '(c) 20210311 Para las tiendas siempre los envia
                    If sobreescribir Then
                        ''Elimino el documento anterior
                        ls_Query = "pa_del_um_documento_completo_temp '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ln_dcorrelativo.ToString
                        li_sresultado = oTrans.Elimina(ls_Query)
                        If li_sresultado > 0 Then
                            li_sresultado = -1
                        End If

                    End If
                    'End If

                Catch ex As Exception
                    li_sresultado = -1
                    'guardarLog(ex.Source)
                End Try

                'Si el documento aun no existe en la BD lo Agrego
                If li_sresultado = -1 Then

                    Try
                        ls_sql = "pa_ins_um_documento_traslado_fel_tmp '" & ls_dempresa & "','" & ls_dtipodocto & "'," &
                                        ln_dcorrelativo.ToString & ",'" & ls_dCtaCte & "','" &
                                        ls_dnumero & "','" & ls_dfecha & "','" & ls_dproveedor & "','" & ls_dcliente & "','" &
                                        ls_dbodega & "','" & dr.Item("bodega2").ToString & "','" & dr.Item("local").ToString & "','" &
                                        dr.Item("comprador").ToString & "','" & ls_dvendedor & "','" &
                                        dr.Item("CentroCosto").ToString & "','" & ls_dfechaVcto & "','" &
                                        ls_dlistaPrecio & "','" & dr.Item("Analisis").ToString & "','" &
                                        dr.Item("Zona").ToString & "','" &
                                        dr.Item("tipocta").ToString & "','" &
                                        dr.Item("moneda").ToString & "'," & dr.Item("paridad").ToString & "," &
                                        IIf(dr.Item("RefTipoDocto") Is System.DBNull.Value, "NULL", "'" & dr.Item("RefTipoDocto").ToString & "'") &
                                        "," & CStr(ld_dneto) &
                                        "," & CStr(ld_dsubtotal) & "," & CStr(ld_dtotal) & "," & CStr(ld_dNetoIngreso) & "," &
                                        CStr(ld_dSubTotalIngreso) & "," & CStr(ld_dTotalIngreso) & ",'" & ls_dcentraliza & "','" &
                                        ls_dvaloriza & "','" &
                                        dr.Item("costeo").ToString & "','" &
                                        ls_daprobacion & "','" &
                                        dr.Item("TipoComprobante").ToString & "'," & ls_dPeriodoLibro & "," &
                                        dr.Item("FactorMonto").ToString & ", '" & ls_dTipoCtaCte & "','" &
                                        ls_dIdCtaCte & "','" & Replace(ls_dGlosa, "'", "") & "','" & Replace(ls_dcomentario1, "'", "") & "','" & dr.Item("comentario2").ToString & "'," &
                                        IIf(dr.Item("Comentario3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario3").ToString & "'") & "," &
                                        IIf(dr.Item("Comentario4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Comentario4").ToString & "'") & ",'" &
                                        ls_dvigencia & "','" & ls_dEmitido & "'," & dr.Item("PorcentajeAsignado").ToString & ",'" &
                                         ls_ddireccion & "','" & ls_dciudad & "','" & ls_dcomuna & "','" & dr.Item("EstadoDir").ToString & "','" & ls_dpais &
                                        "','" & ls_dcontacto & "','" & dr.Item("FechaModif").ToString & "','" & dr.Item("FechaUModif").ToString & "','" & ls_dUsuarioModif & "'," &
                                        IIf(dr.Item("ComisionTotal") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionTotal").ToString & "'") & "," &
                                        IIf(dr.Item("ComisionLPrecio") Is System.DBNull.Value, "NULL", "'" & dr.Item("ComisionLPrecio").ToString & "'") & ",'" &
                                        dr.Item("Hora").ToString & "'," &
                                        IIf(dr.Item("Caja") Is System.DBNull.Value, "NULL", "'" & dr.Item("Caja").ToString & "'") & "," &
                                        IIf(dr.Item("Pago") Is System.DBNull.Value, "NULL", dr.Item("pago").ToString) & "," &
                                        IIf(dr.Item("Donacion") Is System.DBNull.Value, "NULL", dr.Item("Donacion").ToString) & "," &
                                        IIf(dr.Item("IdApertura") Is System.DBNull.Value, "NULL", dr.Item("IdApertura").ToString) & "," &
                                        IIf(dr.Item("Multipagina") Is System.DBNull.Value, "NULL", "'" & dr.Item("Multipagina").ToString & "'") & "," &
                                        CStr(ld_dNetoBimoneda) & "," & CStr(ld_dSubTotalBimoneda) & "," &
                                        CStr(ld_dTotalBimoneda) & "," & CStr(ld_dParidadBimoneda) & ",'" &
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
                        IIf(dr.Item("AnalisisE4") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE4").ToString & "'") & "," &
                        IIf(dr.Item("AnalisisE5") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE5").ToString & "'") & "," &
                        IIf(dr.Item("AnalisisE6") Is System.DBNull.Value, "NULL", "'" & dr.Item("AnalisisE6").ToString & "'")




                        ''ingresamos encabezado
                        li_sresultado = oTrans.Ingresa(ls_sql)
                        codigo_error = oTrans.Codigo_error
                        descripcion_error = oTrans.descripcion_error

                        'If li_sresultado > 0 Then
                        If codigo_error > 0 Then
                            HayErrores = True
                        Else
                            If ln_dcorrelativo > 0 Then
                                ls_pedido_generado = ln_dcorrelativo
                            Else
                                ls_sql = "pa_var_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," &
                                                                   IIf(ln_dcorrelativo > 0, ln_dcorrelativo, "NULL")
                                otabla = oTrans.Obtiene(ls_sql)

                                codigo_error = oTrans.Codigo_error
                                descripcion_error = oTrans.descripcion_error
                                ls_pedido_generado = otabla.Rows(0).Item("correlativo")
                            End If


                            ''ingreso documentop
                            If dt_documentop.Rows.Count > 0 Then

                                For Each dr In dt_documentop.Rows
                                    ls_Query = "pa_ins_um_documentop_traslado_tmp '" & dr.Item("Empresa").ToString & "','" &
                                                ls_dtipodocto & "'," & CStr(ls_pedido_generado) & "," & dr.Item("Linea") & ",'" &
                                                dr.Item("codigopago").ToString & "','" & dr.Item("TipoPago").ToString & "','" &
                                                dr.Item("FechaVcto").ToString & "'," & dr.Item("Monto").ToString & "," &
                                                dr.Item("MontoIngreso").ToString & ",'" & dr.Item("TipoDoctoPago").ToString & "','" &
                                                dr.Item("NroDoctoPago").ToString & "','" & dr.Item("Cuenta").ToString & "'," &
                                                IIf(dr.Item("MontoBimoneda") Is System.DBNull.Value, "NULL", dr.Item("MontoBimoneda").ToString) & "," &
                                                IIf(dr.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr.Item("AjusteBimoneda").ToString) & ",'" &
                                                dr.Item("Entidad").ToString & "','" & dr.Item("NumAutoriza").ToString & "','" &
                                                dr.Item("CuentaPago").ToString & "','" & dr.Item("FechaVctoTarjeta").ToString & "','" &
                                                dr.Item("PropietarioTarjeta").ToString & "','" & dr.Item("FechaVctoDocto").ToString & "','" &
                                                dr.Item("RutComprador").ToString & "','" & dr.Item("RutGirador").ToString & "','" &
                                                dr.Item("MonedaPago").ToString & "'," & dr.Item("MontoPago").ToString & "," &
                                                dr.Item("ParidadPago").ToString & ",'" & dr.Item("ValorGenerico").ToString & "'"

                                    li_sresultado = oTrans.Ingresa(ls_Query)
                                    codigo_error = oTrans.Codigo_error
                                    descripcion_error = oTrans.descripcion_error
                                    If codigo_error > 0 Then
                                        HayErrores = True
                                    End If
                                Next

                            End If

                            ''Ingreso DocumentoV
                            If dt_documentov.Rows.Count > 0 Then
                                For Each dr In dt_documentov.Rows
                                    ls_Query = "pa_ins_um_documentov_traslado '" & dr.Item("Empresa").ToString & "','" & ls_dtipodocto & "'," &
                                                CStr(ls_pedido_generado) & ",'" & dr.Item("Nombre").ToString & "'," &
                                                dr.Item("Orden").ToString & "," & dr.Item("Factor").ToString & "," &
                                                dr.Item("Monto").ToString & "," & dr.Item("MontoIngreso").ToString & "," &
                                                dr.Item("Ajuste").ToString & "," & dr.Item("AjusteIngreso").ToString & "," &
                                                IIf(dr.Item("Texto") Is System.DBNull.Value, "NULL", "'" & dr.Item("Texto").ToString & "'") & "," &
                                                dr.Item("Porcentaje").ToString & "," &
                                                dr.Item("MontoBimoneda").ToString & "," &
                                                IIf(dr.Item("AjusteBimoneda") Is System.DBNull.Value, "NULL", dr.Item("AjusteBimoneda").ToString)

                                    li_sresultado = oTrans.Ingresa(ls_Query)
                                    codigo_error = oTrans.Codigo_error
                                    descripcion_error = oTrans.descripcion_error
                                    If codigo_error > 0 Then
                                        HayErrores = True
                                    End If
                                Next

                            End If

                            'ingreso documentoD
                            For Each dr In dt_detalle.Rows

                                ls_Query = "pa_ins_um_documentod_traslado_tmp '" & dr.Item("Empresa") & "','" & ls_dtipodocto & "'," &
                                            CStr(ls_pedido_generado) & "," & dr.Item("Secuencia") & "," & dr.Item("Linea") & ",'" &
                                            dr.Item("Producto") & "'," & dr.Item("Cantidad") & "," & dr.Item("Precio") & "," &
                                            dr.Item("PorcentajeDr") & "," & dr.Item("SubTotal") & "," & dr.Item("Impuesto") & "," &
                                            dr.Item("Neto") & "," & dr.Item("DRGlobal") & "," & dr.Item("Costo") & "," &
                                            dr.Item("Total") & "," & dr.Item("PrecioAjustado") & ",'" & dr.Item("UnidadIngreso") & "'," &
                                            dr.Item("CantidadIngreso") & "," & dr.Item("PrecioIngreso") & "," & dr.Item("SubTotalIngreso") & "," &
                                            dr.Item("ImpuestoIngreso") & "," & dr.Item("NetoIngreso") & "," & dr.Item("DRGlobalIngreso") & "," &
                                            dr.Item("TotalIngreso") & ",'" & dr.Item("TipoDoctoOrigen") & "'," &
                                            dr.Item("CorrelativoOrigen") & "," & dr.Item("SecuenciaOrigen") & ",'" &
                                            dr.Item("Bodega") & "'," & dr.Item("FactorInventario") & ",'" &
                                            dr.Item("FechaEntrega") & "'," & dr.Item("CantidadAsignada") & ",'" &
                                            dr.Item("Fecha") & "','" & dr.Item("comentario").ToString.Replace("'", "") & "','" &
                                            dr.Item("Vigente") & "'," &
                                            IIf(dr.Item("CUP") Is System.DBNull.Value, "NULL", dr.Item("CUP").ToString) & ",'" &
                                            dr.Item("Ubicacion") & "','" & dr.Item("Ubicacion2") & "','" & dr.Item("cuenta").ToString & "'," &
                                            IIf(dr.Item("Impdist") Is System.DBNull.Value, "NULL", dr.Item("Impdist").ToString) & "," &
                                            IIf(dr.Item("FactorImpto") Is System.DBNull.Value, "NULL", dr.Item("FactorImpto").ToString) &
                                            "," & dr.Item("PrecioBimoneda") & "," &
                                            dr.Item("SubTotalBimoneda") & "," & dr.Item("ImpuestoBimoneda") & "," &
                                            dr.Item("NetoBimoneda") & "," & dr.Item("DrGlobalBimoneda") & "," &
                                            dr.Item("TotalBimoneda") & "," & dr.Item("PrecioListaP") & "," &
                                            IIf(dr.Item("UniMedDynamic") Is System.DBNull.Value, "NULL", dr.Item("UniMedDynamic").ToString) & ",'" &
                                            dr.Item("FechaVigenciaLp") & "','" &
                                            dr.Item("LoteDestino").ToString & "','" & dr.Item("SerieDestino").ToString & "','" &
                                            dr.Item("ProdAlias").ToString & "','" & dr.Item("DoctoOrigenVal") & "'," &
                                            IIf(dr.Item("MontoAsignado") Is System.DBNull.Value, "NULL", dr.Item("MontoAsignado").ToString) & "," &
                                            IIf(dr.Item("Aux_Valor1") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor1").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor2") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor2").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor3") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor3").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor4") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor4").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor5") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor5").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor6") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor6").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor7") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor7").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor8") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor8").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor9") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor9").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor10") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor10").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor11") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor11").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor12") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor12").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor13") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor13").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor14") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor14").ToString & "'") & "," &
                                            IIf(dr.Item("Aux_Valor15") Is System.DBNull.Value, "NULL", "'" & dr.Item("Aux_Valor15").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5Ingreso") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5Ingreso").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr1Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr1Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr2Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr2Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr3Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr3Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr4Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr4Bimoneda").ToString & "'") & "," &
                                            IIf(dr.Item("ValPorcentajeDr5Bimoneda") Is System.DBNull.Value, "NULL", "'" & dr.Item("ValPorcentajeDr5Bimoneda").ToString & "'")



                                li_sresultado = oTrans.Ingresa(ls_Query)
                                codigo_error = oTrans.Codigo_error
                                descripcion_error = oTrans.descripcion_error

                                If oTrans.Codigo_error > 0 Then
                                    li_sresultado = -99
                                    HayErrores = True
                                    guardarLog(oTrans.descripcion_error)
                                    Exit For
                                End If
                            Next


                            ''Enviar proveedor


                        End If

                        If HayErrores Then
                            codigo_error = 89

                            ls_Query = "pa_del_um_documento_completo '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ls_pedido_generado
                            li_sresultado = oTrans.Elimina(ls_Query)
                        End If

                    Catch ex As Exception
                        codigo_error = 88
                        descripcion_error = ex.Message
                        HayErrores = True
                        guardarLog(ex.Source)
                    Finally
                    End Try
                Else
                    codigo_error = 87
                    descripcion_error = "Este Documento ya Existe en la Tienda"
                    HayErrores = True
                End If
            End If


        Catch ex As Exception
            codigo_error = 86
            descripcion_error = ex.Message
            HayErrores = True
            guardarLog(ex.Source)
            '   MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK)
        Finally
            '      oTrans = Nothing
        End Try

    End Sub


    Public Sub PreValidacion_Envio_Documento()

    End Sub

    Public Sub Cerrar()
        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub guardarLog(ByVal sLog As String)
        Dim ClsGen As New ClasesGenerales.General
        Try
            ClsGen.Escribir_Log(sLog)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

End Class
#End Region

#Region "Sincronizacion de Productos a OnBase"

Public Class Envio_Onbase
    Dim Ods As New DataSet

    Private Sub Llenar_Informacion()
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("onBase")


        Try

            myOtrans.open()

            ls_sql = "call pa_sel_um_inv_producto_familia"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "familia"
            If Ods.Tables.Contains("familia") Then
                Ods.Tables.Remove("familia")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_inv_tipo_bebidas_todos"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "tipo_bebida"
            If Ods.Tables.Contains("tipo_bebida") Then
                Ods.Tables.Remove("tipo_bebida")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_pg_pais"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "pg_pais"
            If Ods.Tables.Contains("pg_pais") Then
                Ods.Tables.Remove("pg_pais")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_inv_proveedor"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "inv_proveedor"
            If Ods.Tables.Contains("inv_proveedor") Then
                Ods.Tables.Remove("inv_proveedor")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_inv_producto_marca"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "inv_marca"
            If Ods.Tables.Contains("inv_marca") Then
                Ods.Tables.Remove("inv_marca")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_inv_producto_subtipo_todos"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "inv_subtipo"
            If Ods.Tables.Contains("inv_subtipo") Then
                Ods.Tables.Remove("inv_subtipo")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_pg_empresa"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "pg_empresa"
            If Ods.Tables.Contains("pg_empresa") Then
                Ods.Tables.Remove("pg_empresa")
            End If
            Ods.Tables.Add(otabla.Copy)

            ls_sql = "call pa_sel_um_inv_producto_cepa"
            otabla = myOtrans.Obtiene(ls_sql)
            otabla.TableName = "inv_cepa"
            If Ods.Tables.Contains("inv_cepa") Then
                Ods.Tables.Remove("inv_cepa")
            End If
            Ods.Tables.Add(otabla.Copy)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Public Sub New()
        Llenar_Informacion()
    End Sub

    Public Sub Insertar_OnBase(ByVal _pempresa As String, ByVal _pcodigo As String)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_var_um_producto  '" & _pempresa & "','" & _pcodigo & "'"
            dt = Otrans.Obtiene(ls_sql)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            If dt.Rows.Count > 0 Then
                Insertar_OnBase(_pempresa, _pcodigo, dt)
            End If
        End Try


    End Sub

    Public Sub Insertar_OnBase(ByVal _pempresa As String, ByVal _pcodigo As String, ByVal _dt As DataTable)
        Dim icount As Integer
        ''Solo se va a procesar si la tabla contiene datos
        If _dt.Rows.Count > 0 Then
            While icount < 7 And
                Not Enviar_OnBase(_dt)

                icount += 1
                Llenar_Informacion()
            End While
        End If

    End Sub

    Private Function Enviar_OnBase(ByVal _dt As DataTable)

        Dim Otrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dr As DataRow
        Dim lbingresar As Boolean = True
        Dim ls_sql As String
        Dim ls_filtro As String
        Dim ls_aux As String

        Try

            Otrans.open()
            dr = _dt.Rows(0)

            ls_sql = "call pa_ins_um_inv_producto ("
            ''Empresa
            ls_filtro = "descripcion = '" & dr.Item("empresa").ToString & "'"
            Ods.Tables("pg_empresa").DefaultView.RowFilter = ls_filtro
            Try
                ls_sql += Ods.Tables("pg_empresa").DefaultView(0).Item("cod_empresa").ToString

            Catch ex As Exception
                lbingresar = False
            End Try

            ls_sql += ",'" &
                       dr.Item("producto") & "','" &
                        dr.Item("glosa") & "',"


            ''tipo producto
            ls_filtro = "trim(descripcion) = '" & dr.Item("tipoproducto") & "'"
            Ods.Tables("tipo_bebida").DefaultView.RowFilter = ls_filtro
            Try
                ls_sql = ls_sql & Ods.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida") & ","
            Catch ex As Exception
                lbingresar = False
                If dr.Item("tipoproducto").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_tipo_bebidas ('" & dr.Item("tipoproducto").ToString & "',0)"
                    Otrans.Ingresa(ls_aux)
                End If

            End Try


            ''Familia
            ls_filtro = "trim(descripcion) = '" & dr.Item("familia") & "'"
            Ods.Tables("familia").DefaultView.RowFilter = ls_filtro
            Try
                ls_sql = ls_sql & Ods.Tables("familia").DefaultView(0)("cod_familia") & ","
            Catch ex As Exception
                lbingresar = False
                If dr.Item("familia").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_familia ('" & dr.Item("familia").ToString & "')"
                    Otrans.Ingresa(ls_aux)
                End If
            End Try

            ''proveedor
            ls_filtro = "trim(descripcion) = '" & dr.Item("subfamilia") & "'"
            Ods.Tables("inv_proveedor").DefaultView.RowFilter = ls_filtro

            Try
                ls_sql = ls_sql & Ods.Tables("inv_proveedor").DefaultView(0)("cod_proveedor") & ","
            Catch ex As Exception
                lbingresar = False
                If dr.Item("subfamilia").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_proveedor ('" & dr.Item("subfamilia").ToString & "')"
                    Otrans.Ingresa(ls_aux)
                End If
            End Try

            ''marca
            ls_filtro = "trim(descripcion) = '" & dr.Item("tipo") & "'"
            Ods.Tables("inv_marca").DefaultView.RowFilter = ls_filtro
            Try
                ls_sql = ls_sql & Ods.Tables("inv_marca").DefaultView(0)("cod_marca") & ","
            Catch ex As Exception
                lbingresar = False

                If dr.Item("tipo").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_marca ('" & dr.Item("tipo").ToString & "')"
                    Otrans.Ingresa(ls_aux)
                End If
            End Try

            ''sub tipo
            ls_filtro = "trim(descripcion) = '" & dr.Item("subtipo") & "'"
            Ods.Tables("inv_subtipo").DefaultView.RowFilter = ls_filtro
            Try
                ls_sql = ls_sql & Ods.Tables("inv_subtipo").DefaultView(0)("cod_subtipo") & ","
            Catch ex As Exception
                lbingresar = False

                If dr.Item("subtipo").ToString.Length > 0 Then
                    ls_aux = "call pa_ins_um_inv_subtipo ('" & dr.Item("subtipo").ToString & "')"
                    Otrans.Ingresa(ls_aux)
                End If
            End Try


            ''pais

            'ls_filtro = "pais = '"
            If dr.Item("procedencia").ToString.ToLower = "usa" Or
                dr.Item("procedencia").ToString.ToLower = "miami" Then
                ls_filtro = "pais = 'estados unidos'"
            Else
                ls_filtro = "pais = '" & dr.Item("procedencia").ToString.ToLower & "'"
            End If

            Ods.Tables("pg_pais").DefaultView.RowFilter = ls_filtro

            Try
                ls_sql = ls_sql & Ods.Tables("pg_pais").DefaultView(0)("cod_pais").ToString & ","
            Catch ex As Exception
                lbingresar = False
            End Try

            ls_sql = ls_sql & "'','" &
                        dr.Item("unidad") & "'," &
                        dr.Item("volumen") & "," &
                        "0,0,'v_000.png','Admin','',NULL)"


            If lbingresar Then

                Otrans.Ingresa(ls_sql)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

        Return lbingresar
    End Function

    Public Sub Actualizar_Onbase(ByVal _dr As DataRow, ByVal _pusuario As String)
        Dim myotrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim dt As New DataTable


        Try
            myotrans.open()
            ls_sql = "call pa_sel_um_inv_producto (null,'" & _dr.Item("empresa").ToString & "','" & _dr.Item("producto").ToString & "'"
            dt = myotrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            myotrans.close()
            myotrans = Nothing
        End Try
        If dt.Rows.Count > 0 Then
            Actualizar_Onbase(_dr, _pusuario, dt.DefaultView(0))
        End If

    End Sub

    Public Sub Actualizar_Onbase(ByVal _dr As DataRow, ByVal _pusuario As String, ByVal _drv As DataRowView)

        Dim lactualizar As Boolean = False
        Dim ls_filtro, ls_aux As String
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Try
            myOtrans.open()

            '  _drv = Ods.Tables("productos").DefaultView(0)
            'drv = OnBase
            'dr = Flexline

            ''Descripcion
            If _drv.Item("nombre_producto") <> _dr.Item("glosa") Then
                'MessageBox.Show("Actualizar Nombre")
                _drv.Item("nombre_producto") = _dr.Item("glosa").ToString.Replace("'", "")
                lactualizar = True
                ' Exit For
            End If

            ''tipo producto
            If _drv.Item("tipo") <> _dr.Item("tipoproducto") Then
                ls_filtro = "trim(descripcion) = '" & _dr.Item("tipoproducto") & "'"
                Ods.Tables("tipo_bebida").DefaultView.RowFilter = ls_filtro
                Try
                    _drv.Item("cod_tipo") = Ods.Tables("tipo_bebida").DefaultView(0)("cod_tipo_bebida")
                    lactualizar = True
                Catch ex As Exception
                    'MessageBox.Show("Actualizar TipoProducto " & ls_filtro)
                    lactualizar = False
                End Try
                'Exit For
            End If

            ''Familia
            If _drv.Item("familia") <> _dr.Item("familia") Then
                ls_filtro = "trim(descripcion) = '" & _dr.Item("familia") & "'"
                Ods.Tables("familia").DefaultView.RowFilter = ls_filtro
                Try
                    _drv.Item("cod_familia") = Ods.Tables("familia").DefaultView(0)("cod_familia")
                    lactualizar = True
                Catch ex As Exception
                    'MessageBox.Show("Actualizar Familia " & ls_filtro)
                    lactualizar = False
                End Try
            End If

            ''proveedor
            If _drv.Item("proveedor") <> _dr.Item("subfamilia") Then
                ls_filtro = "trim(descripcion) = '" & _dr.Item("subfamilia") & "'"
                Ods.Tables("inv_proveedor").DefaultView.RowFilter = ls_filtro
                Try
                    _drv.Item("cod_proveedor") = Ods.Tables("inv_proveedor").DefaultView(0)("cod_proveedor")
                    lactualizar = True
                Catch ex As Exception
                    ' MessageBox.Show("Actualizar Proveedor " & ls_filtro)
                    lactualizar = False
                End Try
            End If


            ''marca
            If _drv.Item("marca") <> _dr.Item("tipo") Then

                ls_filtro = "trim(descripcion) = '" & _dr.Item("tipo") & "'"
                Ods.Tables("inv_marca").DefaultView.RowFilter = ls_filtro
                Try
                    _drv.Item("cod_marca") = Ods.Tables("inv_marca").DefaultView(0)("cod_marca")
                    lactualizar = True
                Catch ex As Exception
                    ' MessageBox.Show("Actualizar Marca " & ls_filtro)
                    lactualizar = False
                End Try
            End If

            ''sub tipo
            Try
                If _drv.Item("subtipo") <> _dr.Item("subtipo") Then
                    ls_filtro = "trim(descripcion) = '" & _dr.Item("subtipo") & "'"
                    Ods.Tables("inv_subtipo").DefaultView.RowFilter = ls_filtro
                    Try
                        _drv.Item("cod_subtipo") = Ods.Tables("inv_subtipo").DefaultView(0)("cod_subtipo")
                        lactualizar = True
                    Catch ex As Exception
                        '   MessageBox.Show("Actualizar SubTipo " & ls_filtro)
                        lactualizar = False
                        If _dr.Item("subtipo").ToString.Length > 0 Then
                            ls_aux = "call pa_ins_um_inv_subtipo ('" & _dr.Item("subtipo").ToString & "')"
                            myOtrans.Ingresa(ls_aux)
                        End If
                    End Try
                End If
            Catch ex As Exception

            End Try
            ''pais
            If _drv.Item("pais").ToString.ToLower <> _dr.Item("procedencia").ToString.ToLower Then


                'ls_filtro = "pais = '" & dr.Item("procedencia") & "'"

                If _dr.Item("procedencia").ToString.ToLower = "usa" Or
                    _dr.Item("procedencia").ToString.ToLower = "miami" Then
                    ls_filtro = "pais = 'estados unidos'"
                ElseIf _dr.Item("procedencia").ToString.ToLower = "rep.dominicana" Then
                    ls_filtro = "pais = 'republica dominicana'"
                ElseIf _dr.Item("procedencia").ToString.ToLower = "sud africa" Then
                    ls_filtro = "pais = 'sudafrica'"
                ElseIf _dr.Item("procedencia").ToString.ToLower = "salvador" Then
                    ls_filtro = "pais = 'el salvador'"
                Else
                    ls_filtro = "pais = '" & _dr.Item("procedencia").ToString.ToLower & "'"
                End If
                Ods.Tables("pg_pais").DefaultView.RowFilter = ls_filtro
                Try
                    _drv.Item("cod_pais") = Ods.Tables("pg_pais").DefaultView(0)("cod_pais")
                    lactualizar = True
                Catch ex As Exception
                    '  MessageBox.Show("Actualizar Pais de " & ls_filtro)
                    lactualizar = False
                End Try
            End If

            ''estado
            If _drv.Item("estado") <> _dr.Item("vigente") Then
                _drv.Item("estado") = _dr.Item("vigente")
                lactualizar = True
            End If

            _drv.Item("unidad") = _dr.Item("unidad")
            _drv.Item("volumen") = _dr.Item("volumen")

            If lactualizar Then
                '          MessageBox.Show("Actualizar " & drv.Item("nombre_producto"))
                ls_sql = "call pa_upd_um_inv_producto_masivo (" &
                            _drv.Item("cod_producto").ToString & ",'" &
                            _drv.Item("nombre_producto").ToString & "'," &
                            _drv.Item("cod_tipo").ToString & "," &
                            _drv.Item("cod_familia").ToString & "," &
                            _drv.Item("cod_proveedor").ToString & "," &
                            _drv.Item("cod_marca").ToString & "," &
                            _drv.Item("cod_subtipo").ToString & "," &
                            _drv.Item("cod_pais").ToString & ",'" &
                            _drv.Item("unidad").ToString & "'," &
                            _drv.Item("volumen").ToString & ",'" &
                            _pusuario & "','" &
                            _drv.Item("estado").ToString & "')"
                myOtrans.Actualiza(ls_sql)
            End If

            If _drv.Item("plasma") > 0 Then
                ''Actualizar Precio
                Dim dt As DataTable
                Dim Otrans As New Transaccional.Conexion("FlexLine")
                Try
                    Otrans.open()

                    ls_sql = "pa_sel_um_listaprecioD '"

                    ls_filtro = "cod_empresa = " & _drv.Item("cod_empresa").ToString & ""
                    Ods.Tables("pg_empresa").DefaultView.RowFilter = ls_filtro
                    Try
                        ls_sql += Ods.Tables("pg_empresa").DefaultView(0).Item("descripcion").ToString & "','" &
                                 _dr.Item("producto") & "','" &
                                 Ods.Tables("pg_empresa").DefaultView(0).Item("lista_precio_default").ToString & "'"
                    Catch ex As Exception
                    End Try


                    dt = Otrans.Obtiene(ls_sql)

                    If Otrans.Codigo_error = 0 And
                        dt.Rows.Count > 0 Then
                        ls_sql = "call pa_upd_um_plm_opcion (" & _drv.Item("cod_producto").ToString & "," &
                                dt.Rows(0).Item("valor") & ")"
                        myOtrans.Actualiza(ls_sql)
                    End If

                Catch ex As Exception
                Finally
                    Otrans.close()
                    Otrans = Nothing
                End Try
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
    End Sub



End Class
#End Region

#Region "Sincronizacion de Clientes OnBase"

Public Class Sincronizacion_Clientes_OnBase
    Dim myOtrans As Transaccional.Conexion_mysql


    Public Sub New(ByVal _conexion As String)
        myotrans = New Transaccional.Conexion_mysql(_conexion)
        myotrans.open()
    End Sub

    Public Function Agrega_Cliente_Ubicacion(ByVal _dr As DataRow) As Boolean
        'Dim ls_sql As String

        'ls_sql = "call pa_ins_um_crm_cliente_sincronizacion (" & _dr.Item("cod_cliente").ToString & ",'" & _
        '         _dr.Item("nit").ToString & "','" &  _dr.Item("nombre").tostring & "','" & _dr.Item("razon_social") T "','" & _


    End Function

    Public Sub Finalizar()
        myOtrans.close()
        myOtrans = Nothing
    End Sub

End Class

#End Region



#Region "Envio de Informacion Umbright Mobile  Enterprise "
Public Class Preparar_Informacion_PDA
    Dim ps_usuario As String

    Dim ods As New DataSet("Informacion_PDA")
    Dim ods2 As New DataSet("Informacion_PDA_generales")
    Dim ods3 As New DataSet("Informacion_PDA_clientes")
    Dim ods4 As New DataSet("Informacion_PDA_Consignaciones")
    Dim ods5 As New DataSet("Informacion_PDA_encuestas")
    Dim FTPLocal As String = String.Empty

    Public Sub PDA_Generar_Informacion(ByVal usuario_generar As String)

        Dim sOpciones As String
        ps_usuario = usuario_generar
        Dim ClsGen As New ClasesGenerales.General
        Dim Enviar_Archivo As Boolean = True
        Dim iprocesos As Integer = 0

        Try

            If Crear_Estructura() Then
                Copiar_Estructura("C:\Aplicaciones\SDF\")
                sOpciones = Seleccionar_usuario()
                If sOpciones.Length > 0 Then

                    iprocesos += IIf(Llenar_Estructura(sOpciones), 1, 0)
                    iprocesos += IIf(Llenar_Estructura_Consignaciones(sOpciones), 1, 0)
                    iprocesos += IIf(Procesar_Informacion_General(), 1, 0)
                    iprocesos += IIf(Procesar_Archivos_XML(sOpciones), 1, 0)
                    iprocesos += IIf(Procesar_Archivos_XML_Consignaciones(sOpciones), 1, 0)

                    'tekneLlenarEstructuraEncuestas()
                    'tekneProcesarEstructuraEncuestas()
                    'CrearIndices() 'Los Indices los crea en el equipo localmente

                    Compactar_BD()

                    If iprocesos = 5 Then
                        Enviar_Archivo_PDA_FTP("C:\Aplicaciones\SDF\", "*.sdf", "")
                    Else
                        ClsGen.Escribir_Log("El Usuario " & usuario_generar & " Genero Errores")
                    End If
                Else
                    ClsGen.Escribir_Log("El Usuario " & usuario_generar & " No tiene Accesos Definidos")
                End If

            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("PDA_Generar_Informacion " & ex.Message)
        Finally
            ClsGen = Nothing
        End Try



    End Sub

    Private Sub Copiar_Estructura(ByVal ruta_archivos As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim archivos As String()
        Dim archivo As String

        Try
            archivos = Directory.GetFiles(ruta_archivos & "Estructura\", "*.SDF")
            For Each archivo In archivos
                If archivo.ToLower.IndexOf("sdf") > 0 Then
                    ClsGen.Copiar_Archivo(archivo, ruta_archivos & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1), True)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Enviar_Archivo_PDA_FTP(ByVal ruta_archivos As String, ByVal tipo_archivos As String, ByVal carpeta As String)

        Dim ClsGen As New ClasesGenerales.Manejo_FTP(ps_usuario, "Onbase")
        Dim ClsGen2 As New ClasesGenerales.General

        Dim archivos, archivos_aux As String()
        Dim archivo, archivo_aux As String



        Try
            If carpeta.Length > 0 Then ClsGen.FTP_CambiarDirectorio(carpeta)


            archivos_aux = ClsGen.FTP_ListaArchivo("*.txt")
            Dim dfechaActual As DateTime = Now
            Dim dfechaInicio As DateTime = dfechaActual
            Dim dfechaFinal As DateTime = dfechaActual
            Dim sfecha As String
            Try

                For Each archivo_aux In archivos_aux
                    If archivo_aux.ToLower.IndexOf("txt") > 0 Then
                        Try


                            sfecha = archivo_aux.ToString.Split("_")(1).Split(".")(0)

                            If archivo_aux.ToLower.StartsWith("inicio") Then
                                If sfecha.Length = 14 Then
                                    dfechaInicio = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" &
                                                                    sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" &
                                                                  sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
                                End If

                            End If
                            If archivo_aux.ToLower.StartsWith("final") Then
                                dfechaFinal = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" &
                                                                sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" &
                                                               sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))

                            End If
                        Catch ex As Exception

                        End Try
                        ClsGen.FTP_EliminaArchivo(archivo_aux.Trim)

                        If dfechaActual <> dfechaInicio And
                            dfechaActual <> dfechaFinal Then Guardar_Sincronizacion(ps_usuario, dfechaInicio, dfechaFinal, 2, 0)

                    End If
                Next
                ''Borro los traslados anteriores
                archivos_aux = ClsGen.FTP_ListaArchivo("*.xml")
                For Each archivo_aux In archivos_aux
                    If archivo_aux.ToLower.IndexOf("xml") > 0 Then ClsGen.FTP_EliminaArchivo(archivo_aux)

                Next
            Catch ex As Exception

            End Try

            ' ruta_archivos = "C:\Aplicaciones\SDF\"
            archivos = Directory.GetFiles(ruta_archivos, tipo_archivos)
            For Each archivo In archivos
                If ClsGen.FTP_SubirArchivo(archivo) Then

                    ''Guardar Historial de las Bases de Datos Enviadas
                    If archivo.IndexOf("sdf") > 0 Then
                        archivos_aux = Directory.GetDirectories(ruta_archivos, ps_usuario)
                        If archivos_aux.Length = 0 Then
                            Directory.CreateDirectory(ruta_archivos & "\" & ps_usuario)
                        End If
                        ClsGen2.Copiar_Archivo(archivo, ruta_archivos & "\" & ps_usuario & "\" & Today.ToString("ddMMyyyy") & ".sdf", True)

                    End If

                    ClsGen.FTP_SubirArchivo("c:\aplicaciones\tekne.txt")
                End If

                'ClsGen.FTP_ListaArchivo("*.xml")

            Next

        Catch ex As Exception
        Finally
            ClsGen.Finalizar()
            ClsGen = Nothing
            ClsGen2 = Nothing

        End Try
    End Sub

    Public Sub Guardar_Sincronizacion(ByVal usuario As String, ByVal fechai As DateTime, ByVal fechaf As DateTime, ByVal tipo As Integer, ByVal npedidos As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim ls_sql As String

        Try
            myOtrans.open()
            ls_sql = "call pa_ins_um_mov_sincronizacion ('" & usuario & "','" &
                            fechai.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                            fechaf.ToString("yyyy-MM-dd HH:mm:ss") & "'," & tipo & "," & npedidos & ")"
            myOtrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try


    End Sub

    Private Function tekneLlenarEstructuraConsignaciones(ByVal pOpciones As String) As Boolean

        Dim drv, drv2, drv_aux As DataRowView
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt_aux, dt_onbase, dt_historial, dt_conteos, dt_saldos, dt_conteos_encabezado As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim lbexitoso As Boolean = True
        Dim dt_saldos_clientes As DataTable

        Try
            Otrans.open()
            myOtrans.open()

            If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Then
                ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
                dt_aux = Otrans.Obtiene(ls_sql)
                dt_aux.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"
                For Each drv_aux In dt_aux.DefaultView

                    '   If Not drv_aux.Item("Empresa").ToString.ToLower.Equals("dmarte1") Then

                    ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_saldos_clientes = Otrans.Obtiene(ls_sql)

                    ods4.Tables("clientes_envio").Rows.Clear()
                    For Each dr In dt_saldos_clientes.Rows
                        ods4.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("con_cliente") & "'"
                        If ods4.Tables("clientes_envio").DefaultView.Count = 0 Then
                            dr_aux = ods4.Tables("clientes_envio").NewRow
                            dr_aux.Item("Agregar") = True
                            dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                            dr_aux.Item("Razon_Social") = dr.Item("RazonSocial")
                            ods4.Tables("clientes_envio").Rows.Add(dr_aux)
                        End If
                    Next

                    ods4.Tables("clientes_envio").DefaultView.RowFilter = "agregar = true"

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null,null)"
                    dt_onbase = myOtrans.Obtiene(ls_sql)

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null,null)"
                    dt_conteos = myOtrans.Obtiene(ls_sql)

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo_encabezado (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null)"
                    dt_conteos_encabezado = myOtrans.Obtiene(ls_sql)

                    ls_sql = "pa_sel_um_consignaciones null,'" & drv_aux.Item("Empresa") & "',null,null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_historial = Otrans.Obtiene(ls_sql)
                    ls_sql = "pa_sel_um_consignaciones_saldos null,'" & drv_aux.Item("Empresa") & "',null,null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_saldos = Otrans.Obtiene(ls_sql)



                    For Each drv In ods4.Tables("clientes_envio").DefaultView
                        'ls_sql = "pa_sel_um_consignaciones_saldos_cliente '" & drv.Item("cod_cliente") & "','" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)
                        dt_saldos_clientes.DefaultView.RowFilter = "con_empresa = '" & drv_aux.Item("Empresa") & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                        For Each drv3 As DataRowView In dt_saldos_clientes.DefaultView

                            dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                            dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                            dr_aux.Item("ctacte") = drv3.Item("con_cliente")
                            dr_aux.Item("producto") = drv3.Item("con_producto")
                            dr_aux.Item("saldo") = drv3.Item("saldo")
                            dr_aux.Item("cantidad_aprobada") = 0

                            dt_onbase.DefaultView.RowFilter = "cod_cliente_flex = '" & drv3.Item("con_cliente") & "' and cod_producto_flex = '" & drv3.Item("con_producto") & "'"
                            If dt_onbase.DefaultView.Count > 0 Then
                                dr_aux.Item("cantidad_aprobada") = dt_onbase.DefaultView(0)("cantidad_maxima").ToString
                            End If

                            ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                        Next



                        dt_historial.DefaultView.RowFilter = "con_empresa = '" & drv_aux.Item("Empresa") & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                        If dt_historial.DefaultView.Count > 0 Then
                            For Each drv2 In dt_historial.DefaultView

                                dt_saldos.DefaultView.RowFilter = "con_cliente = '" & drv2.Item("con_cliente").ToString &
                                                                   "' and con_numero = '" & drv2.Item("con_numero").ToString &
                                                                   "' and con_producto = '" & drv2.Item("con_producto").ToString &
                                                                   "' and saldo > 0"

                                If dt_saldos.DefaultView.Count > 0 Then
                                    dr_aux = ods4.Tables("consignaciones_movimientos_historicos").NewRow
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("con_cliente")
                                    dr_aux.Item("producto") = drv2.Item("con_producto")
                                    dr_aux.Item("tipo") = drv2.Item("fd_tipo")
                                    If drv2.Item("fd_tipo").ToString.ToLower.StartsWith("con") Then
                                        dr_aux.Item("numero") = drv2.Item("con_numero")
                                        dr_aux.Item("fecha") = drv2.Item("con_fecha")
                                        dr_aux.Item("Cantidad") = drv2.Item("con_cant")
                                    Else
                                        dr_aux.Item("numero") = drv2.Item("fd_numero")
                                        dr_aux.Item("fecha") = drv2.Item("fd_fecha")
                                        dr_aux.Item("Cantidad") = drv2.Item("fd_cantidad")
                                    End If
                                    dr_aux.Item("consignacion") = drv2.Item("con_numero")
                                    ods4.Tables("consignaciones_movimientos_historicos").Rows.Add(dr_aux)
                                Else

                                End If

                            Next
                        End If


                        dt_conteos.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                        If dt_conteos.DefaultView.Count > 0 Then
                            For Each drv2 In dt_conteos.DefaultView
                                If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then
                                    dr_aux = ods4.Tables("consignaciones_conteos").NewRow
                                    dr_aux.Item("cod_conteo") = Val(drv2.Item("cod_conteo").ToString)
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                    dr_aux.Item("producto") = drv2.Item("cod_producto_flex")
                                    dr_aux.Item("cantidad") = drv2.Item("conteo")
                                    dr_aux.Item("fecha") = drv2.Item("fecha")

                                    ods4.Tables("consignaciones_conteos").Rows.Add(dr_aux)
                                End If
                            Next

                        End If


                        dt_conteos_encabezado.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                        If dt_conteos_encabezado.DefaultView.Count > 0 Then
                            For Each drv2 In dt_conteos_encabezado.DefaultView
                                If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then

                                    dr_aux = ods4.Tables("consignaciones_conteos_encabezado").NewRow
                                    dr_aux.Item("cod_conteo") = drv2.Item("cod_conteo").ToString
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                    dr_aux.Item("fecha") = drv2.Item("fecha")
                                    dr_aux.Item("usuario_grabo") = drv2.Item("usuario_grabo").ToString
                                    ods4.Tables("consignaciones_conteos_encabezado").Rows.Add(dr_aux)
                                End If
                            Next

                        End If

                    Next 'Clientes Envio
                    ''Este proceso es para complementar los productos que no han tenido movimiento pero que tienen saldo
                    For Each dr In dt_onbase.Rows
                        ods4.Tables("consignaciones_saldos").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' " &
                                " and ctacte = '" & dr.Item("cod_cliente_flex") & "' and producto = '" & dr.Item("cod_producto_flex") & "'"
                        If ods4.Tables("consignaciones_saldos").DefaultView.Count = 0 Then
                            ods3.Tables("cliente").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' and ctacte = '" & dr.Item("cod_cliente_flex") & "'"
                            If ods3.Tables("cliente").DefaultView.Count > 0 Then 'Me aseguro que el cliente pertenezca al vendedor
                                dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                                dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                dr_aux.Item("ctacte") = dr.Item("cod_cliente_flex")
                                dr_aux.Item("producto") = dr.Item("cod_producto_flex")
                                dr_aux.Item("saldo") = 0 ' Por que no hay saldo//drv3.Item("saldo")
                                dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                                ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                            End If
                        End If
                    Next
                    '(c) 0712 Se debe verificar que los clientes que no hayan tenido ningun movimiento y tenga productos aprobados tambien se envien

                    '  End If
                Next 'Empresas a los que el usuario tiene acceso
            End If  ''Opciones


        Catch ex As Exception
            lbexitoso = False
        Finally
            oFlex.close()
            oFlex = Nothing
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso

    End Function

    Private Function Llenar_Estructura(ByVal pOpciones As String)
        Dim OtransUm As New Transaccional.Conexion("Umbralsa")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim OtransSysGold As New Transaccional.Conexion("SysGold")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt, dtEmpresaUsuario, dtInventarioCliente, dtClientes As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv, drv_aux As DataRowView
        Dim ls_sql As String

        Dim ls_listasdePrecios As String = String.Empty
        Dim ls_empresas As String = String.Empty
        Dim lbAgregarTodos As Boolean = False
        Dim lbAgregar As Boolean = False
        Dim lbexitoso2 As Boolean = True

        Try
            Otrans.open()
            OtransUm.open()
            'OtransSysGold.open()
            myOtrans.open()

            ods3.Tables("cliente").Rows.Clear()
            ods.Tables("presupuesto_cliente").Rows.Clear()
            ods.Tables("inventario_cliente").Rows.Clear()
            ods2.Tables("ListaPrecio").Rows.Clear()
            ods2.Tables("ProductoOferta").Rows.Clear()
            ods2.Tables("ProductoExistencia").Rows.Clear()
            ods3.Tables("cliente_ruta").Rows.Clear()
            ods3.Tables("cliente_saldos").Rows.Clear()
            ods3.Tables("cliente_documento").Rows.Clear()
            ods3.Tables("cliente_direccion").Rows.Clear()



            If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Or
                pOpciones.ToLower.IndexOf("pda_pedidos") > 0 Then



                ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
                dtEmpresaUsuario = Otrans.Obtiene(ls_sql)
                dtEmpresaUsuario.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"
                For Each drv_aux In dtEmpresaUsuario.DefaultView
                    ls_listasdePrecios = String.Empty
                    ''Lleno Clientes
                    ls_sql = "pa_sel_um_ctacte_Pedidos_PDA '" & drv_aux.Item("Empresa") & "','CLIENTE',NULL,NULL,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dtClientes = Otrans.Obtiene(ls_sql)
                    'dt = OtransUm.Obtiene(ls_sql)
                    For Each drv In dtClientes.DefaultView
                        If drv.Item("Listaprecio").ToString.Length > 0 And drv.Item("CondPago").ToString.Length > 0 Then
                            'And drv.Item("vigencia") = "S" Then  (c) 291010 Se deben enviar todos los clientes
                            dr = ods3.Tables("cliente").NewRow
                            dr.Item("empresa") = drv.Item("Empresa")
                            dr.Item("CtaCte") = drv.Item("CtaCte").ToString
                            dr.Item("Nit") = drv.Item("CodLegal").ToString
                            dr.Item("RazonSocial") = IIf(drv.Item("CodLegal").ToString.StartsWith("737810"), drv.Item("giro"), drv.Item("RazonSocial").ToString)
                            dr.Item("ListaPrecio") = drv.Item("ListaPrecio").ToString.ToUpper.Trim
                            dr.Item("CondPago") = drv.Item("CondPago").ToString
                            dr.Item("Vigencia") = drv.Item("Vigencia").ToString
                            'dr.Item("Direccion") = drv.Item("Direccion").ToString ''Quitarla Cuando los usuarios esten actualizados
                            dr.Item("Telefono") = drv.Item("Telefono").ToString
                            'dr.Item("Ruta") = ""
                            'dr.Item("Orden_Visita") = 0
                            'dr.Item("Frecuencia") = ""
                            dr.Item("limite_credito") = drv.Item("LimiteCredito").ToString

                            dr.Item("Giro") = drv.Item("Giro").ToString & IIf(drv.Item("Contacto").ToString.Length > 0, "/" & drv.Item("Contacto").ToString, "")

                            ods3.Tables("cliente").Rows.Add(dr)
                            If ls_listasdePrecios.IndexOf(drv.Item("ListaPrecio")) < 0 Then
                                ls_listasdePrecios += "," & drv.Item("ListaPrecio")
                            End If
                        End If
                    Next

                    ls_sql = "pa_sel_um_ctacte_Pedidos_PDA_direccion '" & drv_aux.Item("Empresa") & "','CLIENTE',NULL,NULL,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    'dt = OtransUm.Obtiene(ls_sql)


                    For Each drv In dt.DefaultView
                        dr = ods3.Tables("cliente_direccion").NewRow
                        dr.Item("empresa") = drv.Item("empresa")
                        dr.Item("ctacte") = drv.Item("ctacte")
                        dr.Item("direccion") = drv.Item("direccion").ToString.Trim & " " & drv.Item("comuna").ToString.Trim & " " & drv.Item("estado").ToString
                        dr.Item("principal") = drv.Item("principal")
                        dr.Item("telefono") = drv.Item("telefono")
                        ods3.Tables("cliente_direccion").Rows.Add(dr)
                    Next


                    ls_sql = "pa_sel_um_ppt_presupuesto_cliente '" & drv_aux.Item("empresa") & "'," &
                        Now.ToString("yyyyMM") & ",NULL,NULL,NULL,'" & drv_aux.Item("DESCRIPCION").ToString & "'"

                    dt = OtransUm.Obtiene(ls_sql)

                    For Each dr In dt.Rows
                        dr_aux = ods.Tables("presupuesto_cliente").NewRow
                        dr_aux.Item("empresa") = drv_aux.Item("empresa")
                        dr_aux.Item("ctacte") = dr.Item("cliente")
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("cantidad") = dr.Item("cantidad")
                        ods.Tables("presupuesto_cliente").Rows.Add(dr_aux)
                    Next
                    '                    ls_empresas = String.Empty

                    ''Llenar Rutas
                    ls_sql = "call pa_sel_um_mov_cliente_ruta ('" & drv_aux.Item("empresa") & "')"
                    'ls_sql = "pa_sel_um_cliruta '" & drv.Item("CODIGO").ToString & drv.Item("empresa").ToString.Substring(0, 3) & "'"
                    'dt = Otrans.Obtiene(ls_sql)
                    dt = myOtrans.Obtiene(ls_sql)
                    dt.DefaultView.RowFilter = "ejecutivo = '" & drv_aux.Item("descripcion").ToString & "'"
                    dt = dt.DefaultView.ToTable

                    For Each dr In dt.Rows

                        dr_aux = ods3.Tables("cliente_ruta").NewRow
                        dr_aux.Item("empresa") = dr.Item("empresa")
                        dr_aux.Item("ctacte") = dr.Item("ctacte")
                        dr_aux.Item("ruta") = dr.Item("ruta")
                        dr_aux.Item("Orden_Visita") = dr.Item("ordenvisita")
                        dr_aux.Item("frecuencia") = dr.Item("frecuencia")
                        ods3.Tables("cliente_ruta").Rows.Add(dr_aux)

                    Next
                    '   Next ''Finaliza Llenado de Clientes



                    '     For Each drv_aux In dtEmpresaUsuario.DefaultView
                    ' If ls_empresas.IndexOf(drv_aux.Item("Empresa")) < 0 Then


                    If ls_empresas.IndexOf(drv_aux.Item("empresa")) < 0 Then
                        ls_empresas += "," & drv_aux.Item("empresa")
                    End If



                    'ls_sql = "pa_var_um_cliinven_empresa '" & drv_aux.Item("empresa").ToString.Substring(0, 3) & "'"
                    'dtInventarioCliente = OtransSysGold.Obtiene(ls_sql)

                    'For Each dr In ods3.Tables("cliente").Rows
                    '    If dr.Item("empresa") = drv_aux.Item("empresa") Then


                    '        ''Inventario Cliente
                    '        dtInventarioCliente.DefaultView.RowFilter = "inv_client = '" & dr.Item("ctacte") & "'"
                    '        If dtInventarioCliente.DefaultView.Count > 0 Then
                    '            For Each drv In dtInventarioCliente.DefaultView
                    '                dr_aux = ods.Tables("inventario_cliente").NewRow
                    '                dr_aux.Item("empresa") = dr.Item("empresa")
                    '                dr_aux.Item("ctacte") = drv.Item("inv_client")
                    '                dr_aux.Item("producto") = drv.Item("inv_articu")
                    '                dr_aux.Item("existencia_anterior") = drv.Item("existencia")
                    '                ods.Tables("inventario_cliente").Rows.Add(dr_aux)
                    '            Next

                    '        End If
                    '    End If

                    'Next ''Clientes Inventario


                    ''Saldos




                    If pOpciones.ToLower.IndexOf("pda_saldos_cliente") > -1 Then


                        'ls_sql = "sp_Balances_Dias_PDA '" & drv_aux.Item("empresa") & "','" & Today.ToString("dd/MM/yyyy") & "','" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_mov_cliente_documentos_pendientes_saldos ('" & drv_aux.Item("empresa").ToString & "','" & drv_aux.Item("Descripcion").ToString & "')"
                        dt = myOtrans.Obtiene(ls_sql)


                        'If dr.Item("empresa") = drv_aux.Item("empresa") Then
                        Dim clsgen As New ClasesGenerales.General
                        Dim dtaux As DataTable = clsgen.ValoresDistinto(dt, "empresa,ctacte".Split(","))

                        For Each dr In dtaux.Rows
                            dt.DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "'"
                            If dt.DefaultView.Count > 0 Then

                                Dim ls_filtro As String
                                dr_aux = ods3.Tables("cliente_saldos").NewRow
                                dr_aux.Item("empresa") = dr.Item("Empresa")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' and dias_factura < 1"
                                dr_aux.Item("saldo_corriente") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 0 and dias_factura < 31)"
                                dr_aux.Item("saldo1a30") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 30 and dias_factura < 61)"
                                dr_aux.Item("saldo31a60") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 60 and dias_factura < 91)"
                                dr_aux.Item("saldo61a90") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 90 and dias_factura < 121)"
                                dr_aux.Item("saldo91a120") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and dias_factura > 120 "
                                dr_aux.Item("saldomas120") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and saldo <> 0"
                                dr_aux.Item("saldo_total") = dt.Compute("sum(saldo)", ls_filtro)


                                ods3.Tables("cliente_saldos").Rows.Add(dr_aux)
                            End If
                        Next ''Clientes Saldos

                        'ls_sql = "sp_Balances_Dias_factura_PDA '" & drv_aux.Item("empresa") & "','" & Today.ToString("dd/MM/yyyy") & "','" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_mov_cliente_documentos_pendientes ('" & drv_aux.Item("empresa").ToString & "','" & drv_aux.Item("Descripcion").ToString & "')"
                        dt = myOtrans.Obtiene(ls_sql)

                        For Each dr In dt.Rows
                            If Math.Abs(Val(dr.Item("saldo").ToString)) >= 0.01 Then
                                dr_aux = ods3.Tables("cliente_documento").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")
                                dr_aux.Item("tipo_docto") = dr.Item("tipo_docto")
                                dr_aux.Item("numero") = dr.Item("numero")
                                dr_aux.Item("fecha") = dr.Item("fecha")
                                dr_aux.Item("saldo") = dr.Item("saldo")
                                ods3.Tables("cliente_documento").Rows.Add(dr_aux)
                            End If
                        Next
                    End If ''Clientes Saldos



                    ''Lleno Listas  de Precios

                    ls_listasdePrecios = String.Empty
                    For Each dr In ods3.Tables("cliente").Rows
                        If dr.Item("empresa") = drv_aux.Item("empresa") Then
                            If ls_listasdePrecios.IndexOf(dr.Item("ListaPrecio")) < 0 Then
                                ls_listasdePrecios += "," & dr.Item("ListaPrecio")
                            End If
                        End If
                    Next




                    ls_sql = "pa_var_um_listaPrecio '" & drv_aux.Item("empresa") & "'"
                    dt = Otrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows
                        'Solo Agregara Productos Presupuestados
                        If ls_listasdePrecios.IndexOf(dr.Item("lisprecio")) > 0 Then
                            If pOpciones.ToLower.IndexOf("pda_solo_productos_ppto") > -1 Then
                                ''Solo productos Presupuestados
                                ods.Tables("presupuesto_cliente").DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and producto = '" & dr.Item("producto") & "'"
                                If ods.Tables("presupuesto_cliente").DefaultView.Count > 0 Then
                                    lbAgregar = True
                                Else
                                    lbAgregar = False
                                End If
                                ods.Tables("presupuesto_cliente").DefaultView.RowFilter = ""
                            Else
                                lbAgregar = True
                            End If

                            If lbAgregar Then
                                dr_aux = ods2.Tables("ListaPrecio").NewRow
                                dr_aux.Item("empresa") = dr.Item("Empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("ListaPrecio") = dr.Item("LisPrecio").ToString.ToUpper
                                dr_aux.Item("Valor") = dr.Item("valor")
                                dr_aux.Item("FechaI") = dr.Item("fec_Inicio")
                                dr_aux.Item("FechaF") = dr.Item("fec_Final")
                                ods2.Tables("ListaPrecio").Rows.Add(dr_aux)
                            End If
                            lbAgregar = False
                        End If
                    Next


                    ''Lleno Producto Oferta
                    ls_sql = "pa_var_um_productooferta_Vigente '" & drv_aux.Item("empresa") & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    lbAgregar = False

                    For Each dr In dt.Rows

                        If ls_listasdePrecios.IndexOf(dr.Item("listaprecio")) > 0 Then
                            ''Envio Solo productos que esten en la lista de precios
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                                If dr.Item("todos").ToString.ToLower.Equals("s") Then
                                    lbAgregar = True
                                Else
                                    dtClientes.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                                    If dtClientes.DefaultView.Count > 0 Then
                                        lbAgregar = True
                                    End If
                                End If
                            End If

                            If lbAgregar Then
                                dr_aux = ods2.Tables("ProductoOferta").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")
                                dr_aux.Item("Precio") = dr.Item("precio")
                                dr_aux.Item("FechaI") = dr.Item("fechai")
                                dr_aux.Item("FechaF") = dr.Item("fechaf")
                                dr_aux.Item("Todos") = dr.Item("todos")
                                dr_aux.Item("Descripcion") = dr.Item("descripcion")
                                dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                                ods2.Tables("ProductoOferta").Rows.Add(dr_aux)
                                lbAgregar = False
                            End If
                        End If
                    Next


                    ''Llenar Existencias

                    '                        ls_sql = "pa_var_um_existencias_producto '" & drv_aux.Item("empresa") & "',null,'CD_CENTRAL'"
                    '                       dt = Otrans.Obtiene(ls_sql)
                    ls_sql = "call pa_sel_um_mov_producto_existencia('" & drv_aux.Item("empresa").ToString & "')"
                    dt = myOtrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows

                        If dr.Item("Existencia") > 0 Then
                            ''Envio Solo productos que esten en la lista de precios
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then


                                dr_aux = ods2.Tables("ProductoExistencia").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("Bodega") = dr.Item("bodega")
                                dr_aux.Item("Existencia") = dr.Item("Existencia")

                                ods2.Tables("ProductoExistencia").Rows.Add(dr_aux)
                            End If
                        End If
                    Next

                    '        End If ''Verificacion por empresa
                Next '' dv empresa Empresa
            End If





            If pOpciones.ToLower.IndexOf("pda_inventarios_fisicos") > 0 Then
                lbAgregarTodos = True
                ls_empresas = "dmarte1,codicasa,diuva,vinoteca"
            Else
                lbAgregarTodos = False
            End If



            ''Lleno Productos Para todos los casos
            ods.Tables("producto").Rows.Clear()
            For Each ls_empresa As String In ls_empresas.Split(",")
                If ls_empresa.Length > 0 Then

                    ls_sql = "Select empresa,producto,glosa,tipoproducto,familia,subfamilia as proveedor,tipo as marca,subtipo,vigente, codbarra,factoralt,plu " &
                                        " from v_um_producto_busqueda  where empresa = '" & ls_empresa & "'" &
                                        " And validastock = 'S' "


                    dt = Otrans.Obtiene(ls_sql)
                    dt.DefaultView.RowFilter = "Vigente='S'"
                    For Each drv In dt.DefaultView
                        ''Envio Solo productos que esten en la lista de precios
                        If Not lbAgregarTodos Then
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & ls_empresa & "' and producto = '" & drv.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                                lbAgregar = True
                            End If
                        Else
                            lbAgregar = True
                        End If
                        If lbAgregar Then
                            dr = ods.Tables("producto").NewRow
                            dr.Item("empresa") = ls_empresa
                            dr.Item("producto") = drv.Item("producto")
                            dr.Item("descripcion") = drv.Item("glosa")
                            dr.Item("marca") = drv.Item("marca")
                            dr.Item("subtipo") = drv.Item("Subtipo")
                            dr.Item("CodigoBarra") = drv.Item("codbarra")
                            dr.Item("FactorAlt") = drv.Item("FactorAlt")
                            dr.Item("plu") = drv.Item("plu")
                            ods.Tables("producto").Rows.Add(dr)
                        End If
                        lbAgregar = False
                    Next

                End If
            Next  'each ls_empresa


        Catch ex As Exception
            lbexitoso2 = False
        Finally
            Otrans.close()
            Otrans = Nothing
            OtransUm.close()
            OtransUm = Nothing
            'OtransSysGold.close()
            'OtransSysGold = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso2
    End Function

    Private Function tekneLlenarEstructura(ByVal pOpciones As String)
        'Dim OtransUm As New Transaccional.Conexion("Umbralsa")
        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        'Dim OtransSysGold As New Transaccional.Conexion("SysGold")
        Dim myOtrans As New Transaccional.Conexion_mysql("tekne")
        Dim dt, dtEmpresaUsuario, dtInventarioCliente, dtClientes As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv, drv_aux As DataRowView
        Dim ls_sql As String

        Dim ls_listasdePrecios As String = String.Empty
        Dim ls_empresas As String = String.Empty
        Dim lbAgregarTodos As Boolean = False
        Dim lbAgregar As Boolean = False
        Dim lbexitoso2 As Boolean = True

        Try
            'Otrans.open()
            'OtransUm.open()
            'OtransSysGold.open()
            myOtrans.open()

            ods3.Tables("cliente").Rows.Clear()
            ods.Tables("presupuesto_cliente").Rows.Clear()
            ods.Tables("inventario_cliente").Rows.Clear()
            ods2.Tables("ListaPrecio").Rows.Clear()
            ods2.Tables("ProductoOferta").Rows.Clear()
            ods2.Tables("ProductoExistencia").Rows.Clear()
            ods3.Tables("cliente_ruta").Rows.Clear()
            ods3.Tables("cliente_saldos").Rows.Clear()
            ods3.Tables("cliente_documento").Rows.Clear()
            ods3.Tables("cliente_direccion").Rows.Clear()



            If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Or
                pOpciones.ToLower.IndexOf("pda_pedidos") > 0 Then



                '                ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
                ls_sql = "call pa_sel_um_seg_usuario_empresa('" & ps_usuario & "')" 'seg_usuario_empresa

                dtEmpresaUsuario = myOtrans.Obtiene(ls_sql)
                '               dtEmpresaUsuario.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"

                For Each draux As DataRow In dtEmpresaUsuario.Rows
                    ls_listasdePrecios = String.Empty
                    ''Lleno Clientes
                    ls_sql = "call pa_sel_um_mov_cliente ('" & draux.Item("Empresa") & "','" & draux.Item("nombre") & "')"
                    'ls_sql = "pa_sel_um_ctacte_Pedidos_PDA '" & draux.Item("Empresa") & "','CLIENTE',NULL,NULL,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dtClientes = myOtrans.Obtiene(ls_sql)
                    'dt = OtransUm.Obtiene(ls_sql)
                    For Each drv In dtClientes.DefaultView
                        If drv.Item("Listaprecio").ToString.Length > 0 And drv.Item("CondPago").ToString.Length > 0 Then
                            'And drv.Item("vigencia") = "S" Then  (c) 291010 Se deben enviar todos los clientes
                            dr = ods3.Tables("cliente").NewRow
                            dr.Item("empresa") = drv.Item("Empresa")
                            dr.Item("CtaCte") = drv.Item("CtaCte").ToString
                            dr.Item("Nit") = drv.Item("nit").ToString
                            dr.Item("RazonSocial") = IIf(drv.Item("nit").ToString.StartsWith("737810"), drv.Item("giro"), drv.Item("RazonSocial").ToString)
                            dr.Item("ListaPrecio") = drv.Item("ListaPrecio").ToString.ToUpper.Trim
                            dr.Item("CondPago") = drv.Item("CondPago").ToString
                            dr.Item("Vigencia") = drv.Item("Vigencia").ToString
                            'dr.Item("Direccion") = drv.Item("Direccion").ToString ''Quitarla Cuando los usuarios esten actualizados
                            dr.Item("Telefono") = drv.Item("Telefono").ToString
                            'dr.Item("Ruta") = ""
                            'dr.Item("Orden_Visita") = 0
                            'dr.Item("Frecuencia") = ""
                            dr.Item("limite_credito") = drv.Item("LimiteCredito").ToString

                            dr.Item("Giro") = drv.Item("Giro").ToString '& IIf(drv.Item("Contacto").ToString.Length > 0, "/" & drv.Item("Contacto").ToString, "")

                            ods3.Tables("cliente").Rows.Add(dr)
                            If ls_listasdePrecios.IndexOf(drv.Item("ListaPrecio")) < 0 Then
                                ls_listasdePrecios += "," & drv.Item("ListaPrecio")
                            End If
                        End If
                    Next

                    '(c) pendiente revisar
                    'ls_sql = "pa_sel_um_ctacte_Pedidos_PDA_direccion '" & drv_aux.Item("Empresa") & "','CLIENTE',NULL,NULL,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    ls_sql = "call pa_sel_um_mov_cliente_direccion ('" & draux.Item("Empresa") & "','" & draux.Item("nombre") & "')"

                    dt = myOtrans.Obtiene(ls_sql)
                    'dt = OtransUm.Obtiene(ls_sql)


                    For Each drv In dt.DefaultView
                        dr = ods3.Tables("cliente_direccion").NewRow
                        dr.Item("empresa") = drv.Item("empresa")
                        dr.Item("ctacte") = drv.Item("ctacte")
                        dr.Item("direccion") = drv.Item("direccion").ToString.Trim & " " & drv.Item("comuna").ToString.Trim & " " & drv.Item("estado").ToString
                        dr.Item("principal") = drv.Item("principal")
                        dr.Item("telefono") = drv.Item("telefono")
                        ods3.Tables("cliente_direccion").Rows.Add(dr)
                    Next


                    ls_sql = "call pa_sel_um_mov_presupuesto_cliente ('" & draux.Item("Empresa") & "','" & draux.Item("nombre") & "'," & Now.ToString("yyyyMM") & ")"
                    dt = myOtrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows
                        dr_aux = ods.Tables("presupuesto_cliente").NewRow
                        dr_aux.Item("empresa") = drv_aux.Item("empresa")
                        dr_aux.Item("ctacte") = dr.Item("cliente")
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("cantidad") = dr.Item("cantidad")
                        ods.Tables("presupuesto_cliente").Rows.Add(dr_aux)
                    Next
                    '                    ls_empresas = String.Empty

                    ''Llenar Rutas
                    ls_sql = "call pa_sel_um_mov_cliente_ruta ('" & draux.Item("empresa") & "')"
                    'ls_sql = "pa_sel_um_cliruta '" & drv.Item("CODIGO").ToString & drv.Item("empresa").ToString.Substring(0, 3) & "'"
                    'dt = Otrans.Obtiene(ls_sql)
                    dt = myOtrans.Obtiene(ls_sql)
                    dt.DefaultView.RowFilter = "ejecutivo = '" & draux.Item("nombre").ToString & "'"
                    dt = dt.DefaultView.ToTable

                    For Each dr In dt.Rows

                        dr_aux = ods3.Tables("cliente_ruta").NewRow
                        dr_aux.Item("empresa") = dr.Item("empresa")
                        dr_aux.Item("ctacte") = dr.Item("ctacte")
                        dr_aux.Item("ruta") = dr.Item("ruta")
                        dr_aux.Item("Orden_Visita") = dr.Item("ordenvisita")
                        dr_aux.Item("frecuencia") = dr.Item("frecuencia")
                        ods3.Tables("cliente_ruta").Rows.Add(dr_aux)

                    Next
                    '   Next ''Finaliza Llenado de Clientes



                    '     For Each drv_aux In dtEmpresaUsuario.DefaultView
                    ' If ls_empresas.IndexOf(drv_aux.Item("Empresa")) < 0 Then


                    If ls_empresas.IndexOf(draux.Item("empresa")) < 0 Then
                        ls_empresas += "," & draux.Item("empresa")
                    End If




                    'ls_sql = "pa_var_um_cliinven_empresa '" & drv_aux.Item("empresa").ToString.Substring(0, 3) & "'"
                    'dtInventarioCliente = OtransSysGold.Obtiene(ls_sql)

                    'For Each dr In ods3.Tables("cliente").Rows
                    '    If dr.Item("empresa") = drv_aux.Item("empresa") Then


                    '        ''Inventario Cliente
                    '        dtInventarioCliente.DefaultView.RowFilter = "inv_client = '" & dr.Item("ctacte") & "'"
                    '        If dtInventarioCliente.DefaultView.Count > 0 Then
                    '            For Each drv In dtInventarioCliente.DefaultView
                    '                dr_aux = ods.Tables("inventario_cliente").NewRow
                    '                dr_aux.Item("empresa") = dr.Item("empresa")
                    '                dr_aux.Item("ctacte") = drv.Item("inv_client")
                    '                dr_aux.Item("producto") = drv.Item("inv_articu")
                    '                dr_aux.Item("existencia_anterior") = drv.Item("existencia")
                    '                ods.Tables("inventario_cliente").Rows.Add(dr_aux)
                    '            Next

                    '        End If
                    '    End If

                    'Next ''Clientes Inventario


                    ''Saldos
                    If pOpciones.ToLower.IndexOf("pda_saldos_cliente") > -1 Then


                        'ls_sql = "sp_Balances_Dias_PDA '" & drv_aux.Item("empresa") & "','" & Today.ToString("dd/MM/yyyy") & "','" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_mov_cliente_documentos_pendientes_saldos ('" & draux.Item("empresa").ToString & "','" & draux.Item("Nombre").ToString & "')"
                        dt = myOtrans.Obtiene(ls_sql)


                        'If dr.Item("empresa") = drv_aux.Item("empresa") Then
                        Dim clsgen As New ClasesGenerales.General
                        Dim dtaux As DataTable = clsgen.ValoresDistinto(dt, "empresa,ctacte".Split(","))

                        For Each dr In dtaux.Rows
                            dt.DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "'"
                            If dt.DefaultView.Count > 0 Then

                                Dim ls_filtro As String
                                dr_aux = ods3.Tables("cliente_saldos").NewRow
                                dr_aux.Item("empresa") = dr.Item("Empresa")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' and dias_factura < 1"
                                dr_aux.Item("saldo_corriente") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 0 and dias_factura < 31)"
                                dr_aux.Item("saldo1a30") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 30 and dias_factura < 61)"
                                dr_aux.Item("saldo31a60") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 60 and dias_factura < 91)"
                                dr_aux.Item("saldo61a90") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and (dias_factura > 90 and dias_factura < 121)"
                                dr_aux.Item("saldo91a120") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and dias_factura > 120 "
                                dr_aux.Item("saldomas120") = dt.Compute("sum(saldo)", ls_filtro)

                                ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                                ls_filtro += "and saldo <> 0"
                                dr_aux.Item("saldo_total") = dt.Compute("sum(saldo)", ls_filtro)


                                ods3.Tables("cliente_saldos").Rows.Add(dr_aux)
                            End If
                        Next ''Clientes Saldos

                        'ls_sql = "sp_Balances_Dias_factura_PDA '" & drv_aux.Item("empresa") & "','" & Today.ToString("dd/MM/yyyy") & "','" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_mov_cliente_documentos_pendientes ('" & drv_aux.Item("empresa").ToString & "','" & drv_aux.Item("Descripcion").ToString & "')"
                        dt = myOtrans.Obtiene(ls_sql)

                        For Each dr In dt.Rows
                            If Math.Abs(Val(dr.Item("saldo").ToString)) >= 0.01 Then
                                dr_aux = ods3.Tables("cliente_documento").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")
                                dr_aux.Item("tipo_docto") = dr.Item("tipo_docto")
                                dr_aux.Item("numero") = dr.Item("numero")
                                dr_aux.Item("fecha") = dr.Item("fecha")
                                dr_aux.Item("saldo") = dr.Item("saldo")
                                ods3.Tables("cliente_documento").Rows.Add(dr_aux)
                            End If
                        Next
                    End If ''Clientes Saldos



                    ''Lleno Listas  de Precios

                    ls_listasdePrecios = String.Empty
                    For Each dr In ods3.Tables("cliente").Rows
                        If dr.Item("empresa") = drv_aux.Item("empresa") Then
                            If ls_listasdePrecios.IndexOf(dr.Item("ListaPrecio")) < 0 Then
                                ls_listasdePrecios += "," & dr.Item("ListaPrecio")
                            End If
                        End If
                    Next




                    'ls_sql = "pa_var_um_listaPrecio '" & draux.Item("empresa") & "'"
                    ls_sql = "call pa_sel_um_mov_listaprecio ('" & draux.Item("empresa") & "'"
                    dt = myOtrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows
                        'Solo Agregara Productos Presupuestados
                        If ls_listasdePrecios.IndexOf(dr.Item("lisprecio")) > 0 Then
                            If pOpciones.ToLower.IndexOf("pda_solo_productos_ppto") > -1 Then
                                ''Solo productos Presupuestados
                                ods.Tables("presupuesto_cliente").DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and producto = '" & dr.Item("producto") & "'"
                                If ods.Tables("presupuesto_cliente").DefaultView.Count > 0 Then
                                    lbAgregar = True
                                Else
                                    lbAgregar = False
                                End If
                                ods.Tables("presupuesto_cliente").DefaultView.RowFilter = ""
                            Else
                                lbAgregar = True
                            End If

                            If lbAgregar Then
                                dr_aux = ods2.Tables("ListaPrecio").NewRow
                                dr_aux.Item("empresa") = dr.Item("Empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("ListaPrecio") = dr.Item("LisPrecio").ToString.ToUpper
                                dr_aux.Item("Valor") = dr.Item("valor")
                                dr_aux.Item("FechaI") = dr.Item("fec_Inicio")
                                dr_aux.Item("FechaF") = dr.Item("fec_Final")
                                ods2.Tables("ListaPrecio").Rows.Add(dr_aux)
                            End If
                            lbAgregar = False
                        End If
                    Next


                    ''Lleno Producto Oferta
                    'ls_sql = "pa_var_um_productooferta_Vigente '" & drv_aux.Item("empresa") & "'"

                    ls_sql = "call pa_sel_um_productoOferta ('" & drv.Item("empresa") & "')"
                    dt = myOtrans.Obtiene(ls_sql)
                    lbAgregar = False

                    For Each dr In dt.Rows

                        If ls_listasdePrecios.IndexOf(dr.Item("listaprecio")) > 0 Then
                            ''Envio Solo productos que esten en la lista de precios
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                                If dr.Item("todos").ToString.ToLower.Equals("s") Then
                                    lbAgregar = True
                                Else
                                    dtClientes.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                                    If dtClientes.DefaultView.Count > 0 Then
                                        lbAgregar = True
                                    End If
                                End If
                            End If

                            If lbAgregar Then
                                dr_aux = ods2.Tables("ProductoOferta").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("ctacte") = dr.Item("ctacte")
                                dr_aux.Item("Precio") = dr.Item("precio")
                                dr_aux.Item("FechaI") = dr.Item("fechai")
                                dr_aux.Item("FechaF") = dr.Item("fechaf")
                                dr_aux.Item("Todos") = dr.Item("todos")
                                dr_aux.Item("Descripcion") = dr.Item("descripcion")
                                dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                                ods2.Tables("ProductoOferta").Rows.Add(dr_aux)
                                lbAgregar = False
                            End If
                        End If
                    Next


                    ''Llenar Existencias

                    '                        ls_sql = "pa_var_um_existencias_producto '" & drv_aux.Item("empresa") & "',null,'CD_CENTRAL'"
                    '                       dt = Otrans.Obtiene(ls_sql)
                    ls_sql = "call pa_sel_um_mov_producto_existencia('" & draux.Item("empresa").ToString & "')"
                    dt = myOtrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows

                        If dr.Item("Existencia") > 0 Then
                            ''Envio Solo productos que esten en la lista de precios
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then


                                dr_aux = ods2.Tables("ProductoExistencia").NewRow
                                dr_aux.Item("empresa") = dr.Item("empresa")
                                dr_aux.Item("producto") = dr.Item("producto")
                                dr_aux.Item("Bodega") = dr.Item("bodega")
                                dr_aux.Item("Existencia") = dr.Item("Existencia")

                                ods2.Tables("ProductoExistencia").Rows.Add(dr_aux)
                            End If
                        End If
                    Next

                    '        End If ''Verificacion por empresa
                Next '' dv empresa Empresa
            End If





            If pOpciones.ToLower.IndexOf("pda_inventarios_fisicos") > 0 Then
                lbAgregarTodos = True
                ls_empresas = "dmarte1,codicasa,diuva,vinoteca"
            Else
                lbAgregarTodos = False
            End If



            ''Lleno Productos Para todos los casos
            ods.Tables("producto").Rows.Clear()
            For Each ls_empresa As String In ls_empresas.Split(",")
                If ls_empresa.Length > 0 Then

                    'ls_sql = "Select empresa,producto,glosa,tipoproducto,familia,subfamilia as proveedor,tipo as marca,subtipo,vigente, codbarra,factoralt,plu " & _
                    '                    " from v_um_producto_busqueda  where empresa = '" & ls_empresa & "'" & _
                    '                    " And validastock = 'S' "

                    ls_sql = "call pa_sel_um_mov_producto ('" & ls_empresa & "')"
                    dt = myOtrans.Obtiene(ls_sql)
                    'dt.DefaultView.RowFilter = "Vigente='S'"
                    For Each drv In dt.DefaultView
                        ''Envio Solo productos que esten en la lista de precios
                        If Not lbAgregarTodos Then
                            ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & ls_empresa & "' and producto = '" & drv.Item("producto").ToString & "'"
                            If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                                lbAgregar = True
                            End If
                        Else
                            lbAgregar = True
                        End If
                        If lbAgregar Then
                            dr = ods.Tables("producto").NewRow
                            dr.Item("empresa") = ls_empresa
                            dr.Item("producto") = drv.Item("producto")
                            dr.Item("descripcion") = drv.Item("glosa")
                            dr.Item("marca") = drv.Item("marca")
                            dr.Item("subtipo") = drv.Item("Subtipo")
                            dr.Item("CodigoBarra") = drv.Item("codbarra")
                            dr.Item("FactorAlt") = drv.Item("FactorAlt")
                            dr.Item("plu") = drv.Item("plu")
                            ods.Tables("producto").Rows.Add(dr)
                        End If
                        lbAgregar = False
                    Next

                End If
            Next  'each ls_empresa


        Catch ex As Exception
            lbexitoso2 = False
        Finally
            'Otrans.close()
            'Otrans = Nothing
            'OtransUm.close()
            'OtransUm = Nothing
            'OtransSysGold.close()
            'OtransSysGold = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso2
    End Function

    Private Function Llenar_Estructura_Consignaciones(ByVal pOpciones As String) As Boolean

        Dim drv, drv2, drv_aux As DataRowView
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt_aux, dt_onbase, dt_historial, dt_conteos, dt_saldos, dt_conteos_encabezado As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim lbexitoso As Boolean = True
        Dim dt_saldos_clientes As DataTable

        Try
            Otrans.open()
            myOtrans.open()

            If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Then
                ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
                dt_aux = Otrans.Obtiene(ls_sql)
                dt_aux.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"

                'ls_sql = "call pa_sel_um_seg_usuario_empresa('" & ps_usuario & "')" 'seg_usuario_empresa

                'dt_aux = myOtrans.Obtiene(ls_sql)

                For Each drv_aux In dt_aux.DefaultView

                    '   If Not drv_aux.Item("Empresa").ToString.ToLower.Equals("dmarte1") Then

                    ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_saldos_clientes = Otrans.Obtiene(ls_sql)

                    ods4.Tables("clientes_envio").Rows.Clear()
                    For Each dr In dt_saldos_clientes.Rows
                        ods4.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("con_cliente") & "'"
                        If ods4.Tables("clientes_envio").DefaultView.Count = 0 Then
                            dr_aux = ods4.Tables("clientes_envio").NewRow
                            dr_aux.Item("Agregar") = True
                            dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                            dr_aux.Item("Razon_Social") = dr.Item("RazonSocial")
                            ods4.Tables("clientes_envio").Rows.Add(dr_aux)
                        End If
                    Next

                    ods4.Tables("clientes_envio").DefaultView.RowFilter = "agregar = true"

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null,null)"
                    dt_onbase = myOtrans.Obtiene(ls_sql)

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null,null)"
                    dt_conteos = myOtrans.Obtiene(ls_sql)

                    ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo_encabezado (" & ClsGen.Codigo_Empresa_Onbase(drv_aux.Item("Empresa")) & ",null)"
                    dt_conteos_encabezado = myOtrans.Obtiene(ls_sql)

                    ls_sql = "pa_sel_um_consignaciones null,'" & drv_aux.Item("Empresa") & "',null,null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_historial = Otrans.Obtiene(ls_sql)
                    ls_sql = "pa_sel_um_consignaciones_saldos null,'" & drv_aux.Item("Empresa") & "',null,null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                    dt_saldos = Otrans.Obtiene(ls_sql)



                    For Each drv In ods4.Tables("clientes_envio").DefaultView
                        'ls_sql = "pa_sel_um_consignaciones_saldos_cliente '" & drv.Item("cod_cliente") & "','" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                        'dt = Otrans.Obtiene(ls_sql)
                        dt_saldos_clientes.DefaultView.RowFilter = "con_empresa = '" & drv_aux.Item("Empresa") & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                        For Each drv3 As DataRowView In dt_saldos_clientes.DefaultView

                            dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                            dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                            dr_aux.Item("ctacte") = drv3.Item("con_cliente")
                            dr_aux.Item("producto") = drv3.Item("con_producto")
                            dr_aux.Item("saldo") = drv3.Item("saldo")
                            dr_aux.Item("cantidad_aprobada") = 0

                            dt_onbase.DefaultView.RowFilter = "cod_cliente_flex = '" & drv3.Item("con_cliente") & "' and cod_producto_flex = '" & drv3.Item("con_producto") & "'"
                            If dt_onbase.DefaultView.Count > 0 Then
                                dr_aux.Item("cantidad_aprobada") = dt_onbase.DefaultView(0)("cantidad_maxima").ToString
                            End If

                            ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                        Next



                        dt_historial.DefaultView.RowFilter = "con_empresa = '" & drv_aux.Item("Empresa") & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                        If dt_historial.DefaultView.Count > 0 Then
                            For Each drv2 In dt_historial.DefaultView

                                dt_saldos.DefaultView.RowFilter = "con_cliente = '" & drv2.Item("con_cliente").ToString &
                                                                   "' and con_numero = '" & drv2.Item("con_numero").ToString &
                                                                   "' and con_producto = '" & drv2.Item("con_producto").ToString &
                                                                   "' and saldo > 0"

                                If dt_saldos.DefaultView.Count > 0 Then
                                    dr_aux = ods4.Tables("consignaciones_movimientos_historicos").NewRow
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("con_cliente")
                                    dr_aux.Item("producto") = drv2.Item("con_producto")
                                    dr_aux.Item("tipo") = drv2.Item("fd_tipo")
                                    If drv2.Item("fd_tipo").ToString.ToLower.StartsWith("con") Then
                                        dr_aux.Item("numero") = drv2.Item("con_numero")
                                        dr_aux.Item("fecha") = drv2.Item("con_fecha")
                                        dr_aux.Item("Cantidad") = drv2.Item("con_cant")
                                    Else
                                        dr_aux.Item("numero") = drv2.Item("fd_numero")
                                        dr_aux.Item("fecha") = drv2.Item("fd_fecha")
                                        dr_aux.Item("Cantidad") = drv2.Item("fd_cantidad")
                                    End If
                                    dr_aux.Item("consignacion") = drv2.Item("con_numero")
                                    ods4.Tables("consignaciones_movimientos_historicos").Rows.Add(dr_aux)
                                Else

                                End If

                            Next
                        End If


                        dt_conteos.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                        If dt_conteos.DefaultView.Count > 0 Then
                            For Each drv2 In dt_conteos.DefaultView
                                If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then
                                    dr_aux = ods4.Tables("consignaciones_conteos").NewRow
                                    dr_aux.Item("cod_conteo") = Val(drv2.Item("cod_conteo").ToString)
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                    dr_aux.Item("producto") = drv2.Item("cod_producto_flex")
                                    dr_aux.Item("cantidad") = drv2.Item("conteo")
                                    dr_aux.Item("fecha") = drv2.Item("fecha")

                                    ods4.Tables("consignaciones_conteos").Rows.Add(dr_aux)
                                End If
                            Next

                        End If


                        dt_conteos_encabezado.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                        If dt_conteos_encabezado.DefaultView.Count > 0 Then
                            For Each drv2 In dt_conteos_encabezado.DefaultView
                                If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then

                                    dr_aux = ods4.Tables("consignaciones_conteos_encabezado").NewRow
                                    dr_aux.Item("cod_conteo") = drv2.Item("cod_conteo").ToString
                                    dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                    dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                    dr_aux.Item("fecha") = drv2.Item("fecha")
                                    dr_aux.Item("usuario_grabo") = drv2.Item("usuario_grabo").ToString
                                    ods4.Tables("consignaciones_conteos_encabezado").Rows.Add(dr_aux)
                                End If
                            Next

                        End If

                    Next 'Clientes Envio
                    ''Este proceso es para complementar los productos que no han tenido movimiento pero que tienen saldo
                    For Each dr In dt_onbase.Rows
                        ods4.Tables("consignaciones_saldos").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' " &
                                " and ctacte = '" & dr.Item("cod_cliente_flex") & "' and producto = '" & dr.Item("cod_producto_flex") & "'"
                        If ods4.Tables("consignaciones_saldos").DefaultView.Count = 0 Then
                            ods3.Tables("cliente").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' and ctacte = '" & dr.Item("cod_cliente_flex") & "'"
                            If ods3.Tables("cliente").DefaultView.Count > 0 Then 'Me aseguro que el cliente pertenezca al vendedor
                                dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                                dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                                dr_aux.Item("ctacte") = dr.Item("cod_cliente_flex")
                                dr_aux.Item("producto") = dr.Item("cod_producto_flex")
                                dr_aux.Item("saldo") = 0 ' Por que no hay saldo//drv3.Item("saldo")
                                dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                                ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                            End If
                        End If
                    Next
                    '(c) 0712 Se debe verificar que los clientes que no hayan tenido ningun movimiento y tenga productos aprobados tambien se envien

                    '  End If
                Next 'Empresas a los que el usuario tiene acceso
            End If  ''Opciones


        Catch ex As Exception
            lbexitoso = False
        Finally
            oFlex.close()
            oFlex = Nothing
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso

    End Function

    Private Function tekneLlenarEstructuraEncuestas()

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim draux As DataRow

        Try
            myOtrans.open()

            lsSQL = "call pa_sel_um_mov_encuesta_usuario ('" & ps_usuario & "')"
            dt = myOtrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    draux = ods5.Tables("mov_encuesta_usuario").NewRow
                    draux.Item("empresa") = dr.Item("empresa")
                    draux.Item("cod_encuesta") = dr.Item("cod_encuesta")
                    draux.Item("usuario") = dr.Item("usuario")
                    ods5.Tables("mov_encuesta_usuario").Rows.Add(draux)
                Next


                lsSQL = "call pa_sel_um_mov_encuesta ('" & ps_usuario & "')"
                dt = myOtrans.Obtiene(lsSQL)
                For Each dr As DataRow In dt.Rows
                    draux = ods5.Tables("mov_encuesta").NewRow
                    draux.Item("empresa") = dr.Item("empresa")
                    draux.Item("cod_encuesta") = dr.Item("cod_encuesta")
                    draux.Item("nombre_encuesta") = dr.Item("nombre_encuesta").ToString
                    draux.Item("descripcion") = dr.Item("descripcion").ToString
                    draux.Item("fecha_inicio") = dr.Item("fecha_inicio")
                    draux.Item("fecha_final") = dr.Item("fecha_final")
                    ods5.Tables("mov_encuesta").Rows.Add(draux)
                Next

                lsSQL = "call pa_sel_um_mov_encuesta_modelo_encabezado ('" & ps_usuario & "')"
                dt = myOtrans.Obtiene(lsSQL)
                For Each dr As DataRow In dt.Rows
                    draux = ods5.Tables("mov_encuesta_modelo_encabezado").NewRow
                    draux.Item("empresa") = dr.Item("empresa")
                    draux.Item("cod_encuesta") = dr.Item("cod_encuesta")
                    draux.Item("label_valor1") = dr.Item("label_valor1").ToString
                    draux.Item("label_valor2") = dr.Item("label_valor2").ToString
                    draux.Item("label_valor3") = dr.Item("label_valor3").ToString
                    draux.Item("label_valor4") = dr.Item("label_valor4").ToString
                    draux.Item("label_valor5") = dr.Item("label_valor5").ToString
                    ods5.Tables("mov_encuesta_modelo_encabezado").Rows.Add(draux)
                Next

                lsSQL = "call pa_sel_um_mov_encuesta_modelo_detalle ('" & ps_usuario & "')"
                dt = myOtrans.Obtiene(lsSQL)
                For Each dr As DataRow In dt.Rows
                    draux = ods5.Tables("mov_encuesta_modelo_detalle").NewRow
                    draux.Item("empresa") = dr.Item("empresa")
                    draux.Item("cod_encuesta") = dr.Item("cod_encuesta")
                    draux.Item("cod_pregunta") = dr.Item("cod_pregunta")
                    draux.Item("descripcion") = dr.Item("descripcion")
                    draux.Item("cod_tipo_pregunta") = dr.Item("cod_tipo_pregunta")
                    ods5.Tables("mov_encuesta_modelo_detalle").Rows.Add(draux)
                Next

                lsSQL = "call pa_sel_um_mov_encuesta_modelo_detalle_alternativa ('" & ps_usuario & "')"
                dt = myOtrans.Obtiene(lsSQL)
                For Each dr As DataRow In dt.Rows
                    draux = ods5.Tables("mov_encuesta_modelo_detalle_alternativa").NewRow
                    draux.Item("empresa") = dr.Item("empresa")
                    draux.Item("cod_encuesta") = dr.Item("cod_encuesta")
                    draux.Item("cod_pregunta") = dr.Item("cod_pregunta")
                    draux.Item("cod_alternativa") = dr.Item("cod_alternativa")
                    draux.Item("descripcion") = dr.Item("descripcion")
                    ods5.Tables("mov_encuesta_modelo_detalle_alternativa").Rows.Add(draux)
                Next

            End If




        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Function

    Private Function tekneProcesarEstructuraEncuestas()
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Dim dr2 As DataRow
        Dim lsSQL As String
        Dim lbexitoso As Boolean = True


        Try
            oTransCE.abrir()
            oTransCE.lbescribir_log = False

            lsSQL = "Delete from mov_encuesta"
            oTransCE.Elimina(lsSQL)
            lsSQL = "Delete from mov_encuesta_usuario"
            oTransCE.Elimina(lsSQL)
            lsSQL = "Delete from mov_encuesta_modelo_encabezado"
            oTransCE.Elimina(lsSQL)
            lsSQL = "Delete from mov_encuesta_modelo_detalle"
            oTransCE.Elimina(lsSQL)
            lsSQL = "Delete from mov_encuesta_modelo_detalle_alternativa"
            oTransCE.Elimina(lsSQL)



            For Each dr As DataRow In ods5.Tables("mov_encuesta").Rows
                lsSQL = "insert into mov_encuesta (empresa, cod_encuesta, nombre_encuesta, descripcion, fecha_inicio, fecha_final) Select '" &
                            dr.Item("empresa") & "'," & dr.Item("cod_encuesta") & ",'" & dr.Item("nombre_encuesta") & "','" &
                            dr.Item("descripcion") & "','" & DateTime.Parse(dr.Item("fecha_inicio").ToString).ToString("MM-dd-yyyy") & "','" &
                            DateTime.Parse(dr.Item("fecha_final").ToString).ToString("MM-dd-yyyy") & "'"
                oTransCE.Ingresa(lsSQL)
            Next

            For Each dr As DataRow In ods5.Tables("mov_encuesta_usuario").Rows
                lsSQL = "insert into mov_encuesta_usuario (empresa, cod_encuesta, usuario) Select '" &
                            dr.Item("empresa") & "'," & dr.Item("cod_encuesta") & ",'" & dr.Item("usuario") & "'"
                oTransCE.Ingresa(lsSQL)
            Next

            For Each dr As DataRow In ods5.Tables("mov_encuesta_modelo_encabezado").Rows
                lsSQL = "insert into mov_encuesta_modelo_encabezado (empresa, cod_encuesta, label_valor1, label_valor2, label_valor3, label_valor4, label_valor5) Select '" &
                            dr.Item("empresa") & "'," & dr.Item("cod_encuesta") & ",'" & dr.Item("label_valor1") & "','" & dr.Item("label_valor2") & "','" & dr.Item("label_valor3") &
                            "','" & dr.Item("label_valor4") & "','" & dr.Item("label_valor5") & "'"
                oTransCE.Ingresa(lsSQL)
            Next


            For Each dr As DataRow In ods5.Tables("mov_encuesta_modelo_detalle").Rows
                lsSQL = "insert into mov_encuesta_modelo_detalle (empresa, cod_encuesta, cod_pregunta, descripcion, cod_tipo_pregunta) Select '" &
                            dr.Item("empresa") & "'," & dr.Item("cod_encuesta") & "," & dr.Item("cod_pregunta") & ",'" &
                            dr.Item("descripcion") & "'," & dr.Item("cod_tipo_pregunta")
                oTransCE.Ingresa(lsSQL)
            Next


            For Each dr As DataRow In ods5.Tables("mov_encuesta_modelo_detalle_alternativa").Rows
                lsSQL = "insert into mov_encuesta_modelo_detalle_alternativa (empresa, cod_encuesta, cod_pregunta, cod_alternativa, descripcion) Select '" &
                            dr.Item("empresa") & "'," & dr.Item("cod_encuesta") & "," & dr.Item("cod_pregunta") & "," & dr.Item("cod_alternativa") & ",'" &
                            dr.Item("descripcion") & "'"
                oTransCE.Ingresa(lsSQL)
            Next



        Catch ex As Exception
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing
        End Try

    End Function

    Private Function Procesar_Archivos_XML(ByVal popciones As String)
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Dim dr As DataRow
        Dim ls_sql As String

        Dim lbexitoso As Boolean = True

        Try
            oTransCE.abrir()
            oTransCE.lbescribir_log = False

            ls_sql = "Delete from producto"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from ListaPrecio"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from ProductoOferta"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from ProductoExistencia"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_Telefono"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_Direccion"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_Giro"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_ruta"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_Saldos"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from Cliente_Documento"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from presupuesto_cliente"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from inventario_cliente"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from pedidos_encabezado"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from pedidos_detalle"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from cli_noventa"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from gen_log_actividades"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete From Gen_Parametros"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from pedidos_encabezado_tracking"
            oTransCE.Elimina(ls_sql)
            ls_sql = "Delete from pedidos_detalle_tracking"
            oTransCE.Elimina(ls_sql)



            For Each dr2 As DataRow In ods.Tables("producto").Rows
                If Len(dr2.Item("producto")) = 10 Then
                    ls_sql = "Insert Into producto (empresa, producto,descripcion,codigobarra,marca,subtipo,factoralt,plu) " &
                             "Select '" & dr2.Item("empresa").ToString & "','" & dr2.Item("producto").ToString & "','" &
                             dr2.Item("descripcion").ToString.Replace("'", "") & "','" &
                             dr2.Item("codigobarra").ToString & "','" &
                             dr2.Item("marca").ToString.Replace("'", "") & "','" & dr2.Item("subtipo").ToString.Replace("'", "") & "'," &
                             dr2.Item("FactorAlt").ToString & ",'" & dr2.Item("plu") & "'"



                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If
            Next



            For Each dr In ods2.Tables("ListaPrecio").Rows
                If Len(dr.Item("producto")) = 10 Then
                    ls_sql = "Insert Into ListaPrecio (empresa,producto,ListaPrecio,Valor,fechai,fechaf) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("producto").ToString & "','" &
                             dr.Item("ListaPrecio").ToString & "'," &
                             Val(dr.Item("valor").ToString) & ",'" &
                             DateTime.Parse(dr.Item("fechaI").ToString).ToString("MM-dd-yyyy") & "','" &
                             DateTime.Parse(dr.Item("fechaF").ToString).ToString("MM-dd-yyyy") & "'"


                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If
            Next

            For Each dr In ods2.Tables("ProductoOferta").Rows
                If Len(dr.Item("producto")) = 10 Then
                    ls_sql = "Insert Into ProductoOferta (empresa, producto,ctacte,Precio,fechaI, FechaF,Todos,Descripcion,ListaPrecio) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("producto").ToString & "','" &
                             dr.Item("ctacte").ToString & "'," &
                             dr.Item("precio").ToString & ",'" &
                             DateTime.Parse(dr.Item("fechaI").ToString).ToString("MM-dd-yyyy") & "','" &
                             DateTime.Parse(dr.Item("fechaF").ToString).ToString("MM-dd-yyyy") & "','" &
                             dr.Item("Todos").ToString & "','" & dr.Item("Descripcion").ToString & "','" &
                             dr.Item("ListaPrecio").ToString & "'"

                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If
            Next



            For Each dr In ods2.Tables("ProductoExistencia").Rows
                If Len(dr.Item("producto")) = 10 Then
                    ls_sql = "Insert Into ProductoExistencia (empresa, producto,bodega,existencia) Select '" &
                            dr.Item("empresa").ToString & "','" & dr.Item("producto").ToString & "','" &
                            dr.Item("bodega").ToString & "'," & dr.Item("existencia").ToString
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If
            Next




            For Each dr In ods3.Tables("Cliente").Rows
                ls_sql = "Insert Into Cliente (empresa, ctacte,Nit,RazonSocial,ListaPrecio,CondPago,Vigencia, limite_credito) " &
                         "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                         dr.Item("Nit").ToString & "','" &
                         dr.Item("RazonSocial").ToString.Replace("'", "") & "','" &
                         dr.Item("ListaPrecio").ToString & "','" &
                         dr.Item("CondPago").ToString & "','" &
                         dr.Item("Vigencia").ToString & "'," &
                         dr.Item("limite_credito").ToString


                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If




                If dr.Item("telefono").ToString.Trim.Length > 0 Then
                    ls_sql = "Insert Into Cliente_Telefono (empresa, ctacte, telefono) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                            dr.Item("telefono").ToString & "'"
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If

                If dr.Item("Direccion").ToString.Trim.Length > 0 And ods3.Tables("cliente_direccion").Rows.Count = 0 Then
                    ls_sql = "Insert Into Cliente_Direccion (empresa, ctacte, Direccion,principal) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                            dr.Item("Direccion").ToString & "','S'"
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If

                If dr.Item("Giro").ToString.Trim.Length > 1 Then
                    ls_sql = "Insert Into Cliente_Giro (empresa, ctacte, Giro) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                            dr.Item("Giro").ToString.Replace("'", "") & "'"
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                End If
            Next 'Informacion de Cliente

            For Each dr In ods3.Tables("cliente_ruta").Rows
                ls_sql = "Insert Into Cliente_ruta (empresa, ctacte, ruta, orden_visita, frecuencia) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                            dr.Item("ruta").ToString.Trim & "'," & dr.Item("orden_visita") & ",'" & dr.Item("Frecuencia").ToString & "'"
                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If
            Next



            For Each dr In ods3.Tables("cliente_direccion").Rows
                ls_sql = "Insert Into Cliente_Direccion (empresa, ctacte, Direccion, Telefono, principal) " &
                             "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "','" &
                            dr.Item("Direccion").ToString & "','" & dr.Item("telefono") & "','" & dr.Item("principal") & "'"
                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If
            Next




            For Each dr In ods3.Tables("cliente_saldos").Rows
                ls_sql = "Insert Into Cliente_Saldos (empresa, ctacte, saldo_total,saldo_corriente,saldo1a30,saldo31a60," &
                        "saldo61a90, saldo91a120,saldomas120) Select '" &
                        dr.Item("empresa").ToString & "','" & dr.Item("CtaCte").ToString & "'," &
                        IIf(dr.Item("saldo_total") Is System.DBNull.Value, 0, dr.Item("saldo_total").ToString) & "," &
                        IIf(dr.Item("saldo_corriente") Is System.DBNull.Value, 0, dr.Item("saldo_corriente").ToString) & "," &
                        IIf(dr.Item("saldo1a30") Is System.DBNull.Value, 0, dr.Item("saldo1a30").ToString) & "," &
                        IIf(dr.Item("saldo31a60") Is System.DBNull.Value, 0, dr.Item("saldo31a60").ToString) & "," &
                        IIf(dr.Item("saldo61a90") Is System.DBNull.Value, 0, dr.Item("saldo61a90").ToString) & "," &
                        IIf(dr.Item("saldo91a120") Is System.DBNull.Value, 0, dr.Item("saldo91a120").ToString) & "," &
                        IIf(dr.Item("saldomas120") Is System.DBNull.Value, 0, dr.Item("saldomas120").ToString)
                oTransCE.Ingresa(ls_sql)

                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If
            Next

            For Each dr In ods3.Tables("cliente_documento").Rows
                ls_sql = " Insert Into Cliente_Documento(empresa, ctacte, tipo_docto, numero, fecha, saldo) Select '" &
                        dr.Item("empresa").ToString & "','" & dr.Item("ctacte").ToString & "','" & dr.Item("tipo_docto") & "','" &
                        dr.Item("numero").ToString & "','" &
                        DateTime.Parse(dr.Item("fecha").ToString).ToString("MM-dd-yyyy") & "'," &
                        dr.Item("saldo").ToString
                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If

            Next


            ''Parametros_Generales
            For Each dr In ods.Tables("Gen_Parametros").Rows
                ls_sql = "Insert Into Gen_Parametros (Servidor_ftp, usuario, clave, nombre_conexion, usuario_conexion, clave_conexion) " &
                                                        "Select '" & dr.Item("servidor_ftp").ToString & "','" &
                                                           dr.Item("usuario").ToString & "','" & dr.Item("clave").ToString & "','" &
                                                           dr.Item("nombre_conexion").ToString & "','" & dr.Item("usuario_conexion") & "','" & dr.Item("password_conexion") & "'"





                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If
            Next


            ''Presupuesto Cliente
            For Each dr In ods.Tables("presupuesto_cliente").Rows
                ls_sql = "Insert Into presupuesto_cliente (empresa,ctacte,producto,cantidad) " &
                                "Select '" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "','" &
                                dr.Item("producto") & "'," & dr.Item("cantidad")

                oTransCE.Ingresa(ls_sql)
                If oTransCE.Codigo_error > 0 Then
                    lbexitoso = False
                End If
            Next

            ''Inventario Cliente
            For Each dr In ods.Tables("inventario_cliente").Rows
                ls_sql = "Insert Into inventario_cliente (empresa, ctacte, producto,estado,existencia_anterior) " &
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("ctacte").ToString & "','" &
                            dr.Item("producto").ToString & "',0," & dr.Item("existencia_anterior")
                oTransCE.Ingresa(ls_sql)
            Next


        Catch ex As Exception
            lbexitoso = False
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing
        End Try
        Return lbexitoso

    End Function

    Private Function Compactar_BD()
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Try
            oTransCE.Compactar_Base_de_Datos()
        Catch ex As Exception
        Finally
            oTransCE = Nothing
        End Try
        Return True
    End Function

    Private Function Procesar_Archivos_XML_Consignaciones(ByVal popciones As String)
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Dim dr2 As DataRow
        Dim ls_sql As String
        Dim lbexitoso As Boolean = True


        Try
            oTransCE.abrir()


            If popciones.ToLower.IndexOf("pda_consignaciones") > 0 Then

                ls_sql = "Delete from consignaciones_saldos"
                oTransCE.Elimina(ls_sql)
                ls_sql = "Delete from consignaciones_movimientos_historicos"
                oTransCE.Elimina(ls_sql)

                ls_sql = "Delete from consignaciones_conteos"
                oTransCE.Elimina(ls_sql)

                ls_sql = "Delete from consignaciones_conteos_encabezado"
                oTransCE.Elimina(ls_sql)

                oTransCE.lbescribir_log = False
                For Each dr2 In ods4.Tables("consignaciones_saldos").Rows
                    ls_sql = "Insert Into consignaciones_saldos (empresa,ctacte, producto, saldo,cantidad_aprobada) " &
                             "Select '" & dr2.Item("empresa").ToString & "','" &
                             dr2.Item("ctacte").ToString & "','" &
                             dr2.Item("producto").ToString & "'," &
                             dr2.Item("saldo").ToString & "," &
                             dr2.Item("cantidad_aprobada").ToString

                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                Next


                For Each dr2 In ods4.Tables("consignaciones_movimientos_historicos").Rows
                    ls_sql = "Insert Into consignaciones_movimientos_historicos (empresa,ctacte, producto, tipo, numero, cantidad, consignacion, fecha) " &
                             "Select '" & dr2.Item("empresa").ToString & "','" &
                             dr2.Item("ctacte").ToString & "','" &
                             dr2.Item("producto").ToString & "','" &
                             dr2.Item("tipo").ToString & "','" &
                             dr2.Item("numero").ToString & "'," &
                             dr2.Item("Cantidad").ToString & ",'" &
                             dr2.Item("consignacion").ToString & "','" &
                             DateTime.Parse(dr2.Item("fecha").ToString).ToString("MM-dd-yyyy") & "'"


                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                Next




                For Each dr2 In ods4.Tables("consignaciones_conteos").Rows

                    oTransCE.Ingresa("Insert into consignaciones_conteos (cod_conteo,empresa, ctacte, producto, cantidad, fecha_grabo)" &
                          " select " & dr2.Item("cod_conteo") & ",'" & dr2.Item("empresa").ToString & "','" &
                          dr2.Item("ctacte").ToString & "','" &
                          dr2.Item("producto").ToString & "'," &
                          dr2.Item("cantidad").ToString & ",'" &
                          DateTime.Parse(dr2.Item("fecha").ToString).ToString("MM-dd-yyyy HH:mm") & "'")


                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If

                Next



                For Each dr2 In ods4.Tables("consignaciones_conteos_encabezado").Rows

                    oTransCE.Ingresa("Insert into consignaciones_conteos_encabezado (cod_conteo,empresa, ctacte, fecha_grabo, usuario_grabo,estado)" &
                          " select " & dr2.Item("cod_conteo") & ",'" & dr2.Item("empresa").ToString & "','" &
                          dr2.Item("ctacte").ToString & "','" &
                          DateTime.Parse(dr2.Item("fecha").ToString).ToString("MM-dd-yyyy") & "','" &
                          dr2.Item("usuario_grabo").ToString & "',0")


                    If oTransCE.Codigo_error > 0 Then
                        lbexitoso = False
                    End If
                Next
            Else
                ls_sql = "Drop Table consignaciones_saldos"
                oTransCE.Elimina(ls_sql)
                ls_sql = "Drop Table consignaciones_movimientos_historicos"
                oTransCE.Elimina(ls_sql)

                ls_sql = "Drop Table consignaciones_conteos"
                oTransCE.Elimina(ls_sql)

                ls_sql = "Drop Table consignaciones_conteos_encabezado"
                oTransCE.Elimina(ls_sql)

            End If
        Catch ex As Exception
            lbexitoso = False
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing
        End Try
        Return lbexitoso
    End Function

    Private Function Procesar_Informacion_General()
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        '        Dim Otrans As New Transaccional.Conexion("SysGold")

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow

        Dim ls_sql As String
        Dim lbexitoso As Boolean = True

        Try
            oTransCE.open()
            ' Otrans.open()

            myOtrans.open()

            oTransCE.Elimina("Delete from gen_fechas")
            oTransCE.Elimina("Delete From gen_motivo_no_venta")


            'ls_sql = "pa_sel_um_calendario 'dmarte1'"
            'ls_sql = "pa_sel_um_calendario 'DMARTE1'"
            ls_sql = "call pa_var_um_pg_fecha()"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ls_sql = "Insert Into gen_fechas (fecha,dia,frec2,frec3,estado) Select '" &
                            DateTime.Parse(dr.Item("fecha").ToString).ToString("MM-dd-yyyy") & "','" &
                            dr.Item("dia").ToString & "','" & dr.Item("Frec2").ToString & "','" &
                            dr.Item("Frec3").ToString & "',0"
                oTransCE.Ingresa(ls_sql)
            Next

            ''Motivos de Novisita
            'ls_sql = "pa_sel_um_motinovi"
            ls_sql = "call pa_sel_um_pg_motivo_noventa ()"
            'dt = Otrans.Obtiene(ls_sql)
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                ls_sql = "Insert Into gen_motivo_no_venta (cod_motivo, descripcion) Select " &
                        dr.Item("cod_motivo").ToString & ",'" & dr.Item("descripcion").ToString.Trim & "'"
                oTransCE.Ingresa(ls_sql)
            Next



        Catch ex As Exception
            lbexitoso = False
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing
            ClsGen = Nothing
            'Otrans.close()
            'Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return lbexitoso
    End Function

    Private Function Seleccionar_usuario() As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable

        Dim ls_sql As String = String.Empty
        Try

            Otrans.open()
            ls_sql = "pa_sel_um_sg_usuario_todos"
            dt = Otrans.Obtiene(ls_sql)

            dt.DefaultView.RowFilter = "usuario = '" & ps_usuario & "'"

            ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa 18,'" & ps_usuario & "'"
            dt2 = Otrans.Obtiene(ls_sql)

            Dim dt3 As DataTable = ClsGen.ValoresDistinto(dt2, "opcion".Split(","))

            ls_sql = String.Empty
            For Each dr As DataRow In dt3.Rows
                ls_sql += "," & dr.Item("opcion")
            Next
            'dt.DefaultView.RowFilter = "empresa = 'umbral' and (ubicacion = 'contabilidad' or ubicacion = 'recursos humanos')"

            Agregar_Usuario(dt.DefaultView, ls_sql)

            ''Para Inventarios Fisicos deben Ir varios Usuarios

            Agregar_Usuario_Parametros(dt.DefaultView(0).Item("usuario"))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ls_sql
    End Function

    Private Function tekneSeleccionarusuario() As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("Tekne")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable

        Dim ls_sql As String = String.Empty
        Try

            myOtrans.open()
            ls_sql = "CALL pa_sel_um_sg_usuario_simple('" & ps_usuario & "')"
            dt = myOtrans.Obtiene(ls_sql)

            dt.DefaultView.RowFilter = "usuario = '" & ps_usuario & "'"

            '(c) pendienteSS
            ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa 18,'" & ps_usuario & "'"
            dt2 = Otrans.Obtiene(ls_sql)

            Dim dt3 As DataTable = ClsGen.ValoresDistinto(dt2, "opcion".Split(","))

            ls_sql = String.Empty
            For Each dr As DataRow In dt3.Rows
                ls_sql += "," & dr.Item("opcion")
            Next
            'dt.DefaultView.RowFilter = "empresa = 'umbral' and (ubicacion = 'contabilidad' or ubicacion = 'recursos humanos')"

            tekneAgregarUsuario(dt.DefaultView, ls_sql)

            ''Para Inventarios Fisicos deben Ir varios Usuarios

            tekneAgregarUsuarioParametros(dt.DefaultView(0).Item("usuario"))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ls_sql
    End Function

    Private Sub tekneAgregarUsuario(ByVal dtv As DataView, ByVal popciones As String)
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        'Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("Tekne")
        Dim ClsGen As New ClasesGenerales.General
        Dim drv, drv2 As DataRowView

        Dim ls_sql As String
        Dim ls_aux As String = ","
        Dim dt As DataTable



        Try
            oTransCE.abrir()
            myOtrans.abrir()
            ls_sql = "Delete from usuario"
            oTransCE.Elimina(ls_sql)


            ls_sql = "call pa_sel_um_seg_usuario_empresa('" & ps_usuario & "')" 'seg_usuario_empresa
            dt = myOtrans.Obtiene(ls_sql)


            For Each drv In dtv
                'dt.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"
                'dt = dt.DefaultView.ToTable(True, "empresa", "CODIGO", "RELACIONCODIGO1")
                For Each dr2 As DataRow In dt.Rows
                    If ls_aux.IndexOf(drv.Item("empresa").ToString.ToLower) < 0 Then

                        ls_aux += drv.Item("empresa").ToString.ToLower & ","

                        ls_sql = "Insert Into usuario (usuario,nombre, empresa, permisos, clave,fecha_generado) " &
                                "Select '" & drv.Item("usuario").ToString & "','" &
                                drv.Item("nombre").ToString & "','" & drv.Item("empresa").ToString & "','" & popciones & "','" &
                                drv.Item("password").ToString & "','" &
                                Now.ToString("MM-dd-yyyy") & "'"

                        oTransCE.Ingresa(ls_sql)
                        If oTransCE.Codigo_error > 0 Then
                            ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                        End If
                    End If
                Next

            Next


        Catch ex As Exception
            ClsGen.Escribir_Log("Agregar_Usuario" & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            oTransCE.cerrar()
            oTransCE = Nothing

        End Try

    End Sub

    Private Sub tekneAgregarUsuarioParametros(ByVal pusuario As String)
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim dt As DataTable
        Dim dr As DataRow

        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones('" & pusuario & "')"
            dt = myOtrans.Obtiene(ls_sql)
            ods.Tables("Gen_Parametros").Rows.Clear()

            dr = ods.Tables("Gen_Parametros").NewRow
            With dt.Rows(0)


                dr.Item("Servidor_FTP") = dt.Rows(0).Item("host")
                dr.Item("usuario") = dt.Rows(0).Item("usuario")
                dr.Item("clave") = dt.Rows(0).Item("password")
                dr.Item("nombre_conexion") = .Item("nombre_conexion_gprs")
                dr.Item("usuario_conexion") = .Item("usuario_conexion_gprs")
                dr.Item("password_conexion") = .Item("password_conexion_gprs")
            End With
            ods.Tables("Gen_Parametros").Rows.Add(dr)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub


    Private Sub Agregar_Usuario(ByVal dtv As DataView, ByVal popciones As String)
        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim drv, drv2 As DataRowView

        Dim ls_sql As String
        Dim ls_aux As String = ","
        Dim dt As DataTable



        Try
            oTransCE.abrir()
            oTrans.abrir()
            ls_sql = "Delete from usuario"
            oTransCE.Elimina(ls_sql)


            ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"  'seg_usuario_empresa
            dt = oTrans.Obtiene(ls_sql)


            For Each drv In dtv
                dt.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"
                'dt = dt.DefaultView.ToTable(True, "empresa", "CODIGO", "RELACIONCODIGO1")
                For Each drv2 In dt.DefaultView
                    If ls_aux.IndexOf(drv2.Item("empresa").ToString.ToLower) < 0 Then

                        ls_aux += drv2.Item("empresa").ToString.ToLower & ","

                        ls_sql = "Insert Into usuario (usuario,nombre, empresa, permisos, clave,fecha_generado, usuario_sysgold) " &
                                "Select '" & drv.Item("usuario").ToString & "','" &
                                drv.Item("nombre").ToString & "','" & drv2.Item("empresa").ToString & "','" & popciones & "','" &
                                drv.Item("password").ToString & "','" &
                                Now.ToString("MM-dd-yyyy") & "','" & drv2.Item("codigo").ToString & "'"

                        oTransCE.Ingresa(ls_sql)
                        If oTransCE.Codigo_error > 0 Then
                            ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                        End If
                    End If
                Next
                If popciones.IndexOf("fisico") > 0 Then
                    For Each ls_aux In "dmarte1,codicasa,diuva,vinoteca".Split(",")


                        ls_sql = "Insert Into usuario (usuario,nombre, empresa, permisos, clave,fecha_generado, usuario_sysgold) " &
                                  "Select '" & drv.Item("usuario").ToString & "','" &
                                  drv.Item("nombre").ToString & "','" & ls_aux & "','" & popciones & "','" &
                                  drv.Item("password").ToString & "','" &
                                  Now.ToString("MM-dd-yyyy") & "',''"

                        oTransCE.Ingresa(ls_sql)
                        If oTransCE.Codigo_error > 0 Then
                            ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                        End If
                    Next
                End If

            Next

            If popciones.IndexOf("fisico") > 0 Then
                dt = oTrans.Obtiene("pa_sel_um_gen_tabcod null,'gen_bodega'")
                dt.DefaultView.RowFilter = "valor5 = 1"
                For Each drv In dt.DefaultView
                    ls_sql = "Insert Into bodega_conteo(empresa,bodega) Select '" & drv.Item("empresa").ToString & "','" & drv.Item("codigo").ToString & "'"
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                    End If
                Next
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("Agregar_Usuario" & ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            oTransCE.cerrar()
            oTransCE = Nothing

        End Try

    End Sub

    Private Sub Agregar_Usuario_Parametros(ByVal pusuario As String)
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim dt As DataTable
        Dim dr As DataRow

        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones('" & pusuario & "')"
            dt = myOtrans.Obtiene(ls_sql)
            ods.Tables("Gen_Parametros").Rows.Clear()

            dr = ods.Tables("Gen_Parametros").NewRow
            With dt.Rows(0)


                dr.Item("Servidor_FTP") = dt.Rows(0).Item("host")
                dr.Item("usuario") = dt.Rows(0).Item("usuario")
                dr.Item("clave") = dt.Rows(0).Item("password")
                dr.Item("nombre_conexion") = .Item("nombre_conexion_gprs")
                dr.Item("usuario_conexion") = .Item("usuario_conexion_gprs")
                dr.Item("password_conexion") = .Item("password_conexion_gprs")
            End With
            ods.Tables("Gen_Parametros").Rows.Add(dr)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub

    Private Function Crear_Estructura()
        Dim lbexitoso As Boolean = True

        Try

            ods = New DataSet("Informacion_PDA")
            ods2 = New DataSet("Informacion_PDA_generales")
            ods3 = New DataSet("Informacion_PDA_clientes")
            ods4 = New DataSet("Informacion_PDA_Consignaciones")
            ods5 = New DataSet("Informacion_PDA_Encuestas")

            Dim dt = New DataTable("producto")

            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("Descripcion", GetType(String))
            dt.Columns.Add("CodigoBarra", GetType(String))
            dt.Columns.Add("marca", GetType(String))
            dt.Columns.Add("subtipo", GetType(String))
            dt.Columns.Add("FactorAlt", GetType(Integer))
            dt.Columns.Add("plu", GetType(String))
            ods.Tables.Add(dt.copy)

            dt = New DataTable("presupuesto_cliente")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("ctacte", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("cantidad", GetType(Integer))
            ods.Tables.Add(dt.copy)

            dt = New DataTable("inventario_cliente")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("ctacte", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("existencia_anterior", GetType(Integer))
            ods.Tables.Add(dt.copy)


            dt = New DataTable("Gen_Parametros")
            dt.Columns.Add("Servidor_FTP", GetType(String))
            dt.Columns.Add("Servidor_FTP_Local", GetType(String))
            dt.Columns.Add("usuario", GetType(String))
            dt.Columns.Add("clave", GetType(String))
            dt.Columns.Add("nombre_conexion", GetType(String))
            dt.Columns.Add("usuario_conexion", GetType(String))
            dt.Columns.Add("password_conexion", GetType(String))
            ods.Tables.Add(dt.copy)



            dt = New DataTable("ListaPrecio")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("ListaPrecio", GetType(String))
            dt.Columns.Add("Valor", GetType(Double))
            dt.Columns.Add("FechaI", GetType(String))
            dt.Columns.Add("FechaF", GetType(String))
            ods2.Tables.Add(dt.copy)



            dt = New DataTable("ProductoOferta")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("ctacte", GetType(String))
            dt.Columns.Add("Precio", GetType(Double))
            dt.Columns.Add("FechaI", GetType(String))
            dt.Columns.Add("FechaF", GetType(String))
            dt.Columns.Add("Todos", GetType(String))
            dt.Columns.Add("Descripcion", GetType(String))
            dt.Columns.Add("ListaPrecio", GetType(String))
            ods2.Tables.Add(dt.copy)


            dt = New DataTable("ProductoExistencia")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("producto", GetType(String))
            dt.Columns.Add("Bodega", GetType(String))
            dt.Columns.Add("Existencia", GetType(Double))
            ods2.Tables.Add(dt.copy)


            dt = New DataTable("cliente")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("CtaCte", GetType(String))
            dt.Columns.Add("Nit", GetType(String))
            dt.Columns.Add("RazonSocial", GetType(String))
            dt.Columns.Add("ListaPrecio", GetType(String))
            dt.columns.add("CondPago", GetType(String))
            dt.columns.add("Vigencia", GetType(String))
            dt.columns.add("Direccion", GetType(String))
            dt.columns.add("Telefono", GetType(String))
            dt.columns.add("Giro", GetType(String))
            dt.columns.add("Ruta", GetType(String))
            dt.columns.add("Orden_Visita", GetType(Integer))
            dt.columns.add("frecuencia", GetType(String))
            dt.Columns.Add("limite_credito", GetType(Double))

            ods3.Tables.Add(dt.copy)

            dt = New DataTable("cliente_ruta")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("CtaCte", GetType(String))
            dt.Columns.Add("ruta", GetType(String))
            dt.Columns.Add("orden_visita", GetType(Integer))
            dt.Columns.Add("frecuencia", GetType(String))
            ods3.Tables.Add(dt.copy)

            dt = New DataTable("cliente_direccion")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("CtaCte", GetType(String))
            dt.Columns.Add("direccion", GetType(String))
            dt.Columns.Add("telefono", GetType(String))
            dt.Columns.Add("principal", GetType(String))
            ods3.Tables.Add(dt.copy)


            dt = New DataTable("cliente_saldos")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("CtaCte", GetType(String))
            dt.columns.add("saldo_total", GetType(Double))
            dt.columns.add("saldo_corriente", GetType(Double))
            dt.columns.add("saldo1a30", GetType(Double))
            dt.columns.add("saldo31a60", GetType(Double))
            dt.columns.add("saldo61a90", GetType(Double))
            dt.columns.add("saldo91a120", GetType(Double))
            dt.columns.add("saldomas120", GetType(Double))
            ods3.Tables.Add(dt.copy)

            dt = New DataTable("cliente_documento")
            dt.Columns.Add("empresa", GetType(String))
            dt.Columns.Add("ctaCte", GetType(String))
            dt.Columns.Add("tipo_docto", GetType(String))
            dt.Columns.Add("numero", GetType(String))
            dt.Columns.Add("fecha", GetType(DateTime))
            dt.columns.add("saldo", GetType(Double))
            ods3.Tables.Add(dt.copy)


            dt = New DataTable("clientes_envio")
            dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
            dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
            dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
            ods4.Tables.Add(dt.Copy)

            dt = New DataTable("consignaciones_saldos")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
            dt.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
            ods4.Tables.Add(dt.copy)




            dt = New DataTable("consignaciones_movimientos_historicos")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
            dt.Columns.Add(New DataColumn("numero", GetType(String)))
            dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
            dt.Columns.Add(New DataColumn("consignacion", GetType(String)))
            ods4.Tables.Add(dt.Copy)



            dt = New DataTable("consignaciones_conteos")
            dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
            dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
            dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
            ods4.Tables.Add(dt.copy)

            dt = New DataTable("consignaciones_conteos_encabezado")
            dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("comentarios_reposicion", GetType(String)))
            dt.Columns.Add(New DataColumn("comentarios_factura", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
            dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
            ods4.Tables.Add(dt.copy)


            dt = New DataTable("mov_encuesta")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_encuesta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("nombre_encuesta", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("fecha_inicio", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("fecha_final", GetType(DateTime)))
            ods5.Tables.Add(dt.copy)

            dt = New DataTable("mov_encuesta_modelo_encabezado")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_encuesta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("label_valor1", GetType(String)))
            dt.Columns.Add(New DataColumn("label_valor2", GetType(String)))
            dt.Columns.Add(New DataColumn("label_valor3", GetType(String)))
            dt.Columns.Add(New DataColumn("label_valor4", GetType(String)))
            dt.Columns.Add(New DataColumn("label_valor5", GetType(String)))
            ods5.Tables.Add(dt.copy)

            dt = New DataTable("mov_encuesta_modelo_detalle")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_encuesta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("cod_pregunta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_tipo_pregunta", GetType(Integer)))
            ods5.Tables.Add(dt.copy)

            dt = New DataTable("mov_encuesta_modelo_detalle_alternativa")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_encuesta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("cod_pregunta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("cod_alternativa", GetType(Integer)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            ods5.Tables.Add(dt.copy)

            dt = New DataTable("mov_encuesta_usuario")
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("cod_encuesta", GetType(Integer)))
            dt.Columns.Add(New DataColumn("usuario", GetType(String)))
            ods5.Tables.Add(dt.copy)



        Catch ex As Exception
            lbexitoso = False
        End Try
        Return lbexitoso

    End Function

    Public Function PDA_Generar_Informacion_Complementaria(ByVal usuario_generar As String) As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt_clientes, dt_aux, dt3, dt4 As DataTable
        Dim drv As DataRowView
        Dim ls_sql As String
        Dim ls_aux As String = String.Empty
        Dim dr As DataRow
        Dim ComentarioPedido As String
        Dim myOds As New DataSet("Complemento")
        Dim ls_ruta As String = String.Empty
        ps_usuario = usuario_generar

        Try
            Crear_Estructura_Complemento(myOds)
            myOtrans.open()
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
            dt = Otrans.Obtiene(ls_sql)




            dt.DefaultView.RowFilter = "texto3  = '" & usuario_generar & "'"
            'dt = dt.DefaultView.ToTable(True, "empresa", "CODIGO", "RELACIONCODIGO1")
            For Each drv In dt.DefaultView
                'If ls_aux.IndexOf(drv.Item("empresa").ToString.ToLower) < 0 Then



                ls_aux += drv.Item("empresa").ToString.ToLower & ","

                ls_sql = "pa_sel_um_ctacte_Pedidos_PDA '" & drv.Item("Empresa") & "','CLIENTE',NULL,NULL,'" & drv.Item("DESCRIPCION").ToString & "'"
                dt_clientes = Otrans.Obtiene(ls_sql)

                ls_sql = "call pa_sel_um_mov_pedidos_encabezado ('" & drv.Item("empresa") & "',Null,2)"
                dt_aux = myOtrans.Obtiene(ls_sql)

                For Each dr In dt_clientes.Rows

                    dt_aux.DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and ctacte = '" & dr.Item("ctacte") & "'"
                    For Each drv2 As DataRowView In dt_aux.DefaultView

                        If DateDiff(DateInterval.Day, drv2.Item("fecha_pedido"), Today) < (4 + IIf(Today.DayOfWeek = DayOfWeek.Monday, 2, IIf(Today.DayOfWeek = DayOfWeek.Tuesday, 1, 0))) Then


                            ls_sql = "pa_var_um_documento '" & dr.Item("empresa").ToString & "', '" & drv2.Item("tipo_docto_flex") & "','" & drv2.Item("numero_flex") & "'"

                            dt3 = Otrans.Obtiene(ls_sql)
                            If dt3.Rows.Count > 0 Then

                                ComentarioPedido = dt3.Rows(0).Item("Comentario1").ToString
                                ls_sql = "pa_var_um_documento_relacion_detalle_tracking '" & dr.Item("empresa").ToString & "', '" & drv2.Item("tipo_docto_flex") & "'," &
                                        dt3.Rows(0).Item("Correlativo").ToString
                                dt3 = Otrans.Obtiene(ls_sql)

                                ls_sql = "call pa_var_um_mov_pedidos_detalle_procesables (" & drv2.Item("cod_pedido") & ")"
                                dt4 = myOtrans.Obtiene(ls_sql)
                                Agregar_Pedido(drv2, dt4, dt3, ComentarioPedido, myOds)
                            End If
                        End If
                    Next
                Next
            Next

            If myOds.Tables("pedidos_encabezado").Rows.Count > 0 Then
                ls_ruta = "C:\Aplicaciones\Umbright Mobile EE\Send\Complemento_" & usuario_generar & Now.ToString("ddMMyyyyhhmmss") & ".xml"
                myOds.WriteXml(ls_ruta, XmlWriteMode.WriteSchema)
                Enviar_Archivo_PDA_FTP("c:\Aplicaciones\Umbright Mobile EE\Send\", "*.xml", "Complemento")
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ls_ruta

    End Function

    Private Sub Agregar_Pedido(ByVal pdrv_pedido As DataRowView, ByVal dt_detalle_pedido As DataTable,
                                ByVal pdt_factura As DataTable, ByVal pcomentarioActual As String, ByRef myOds As DataSet)
        Dim dr, dr2 As DataRow



        If pdt_factura.Rows.Count > 0 Then
            dr = myOds.Tables("pedidos_encabezado_tracking").NewRow
            With pdt_factura.Rows(0)
                dr.Item("numero_pedido") = pdrv_pedido.Item("numero_pedido")
                dr.Item("numero_factura") = .Item("numero")
                dr.Item("fecha_factura") = .Item("fecha")
                dr.Item("total_factura") = .Item("total_factura")
            End With

            myOds.Tables("pedidos_encabezado_tracking").Rows.Add(dr)
        End If

        For Each dr2 In pdt_factura.Rows

            dr = myOds.Tables("pedidos_detalle_tracking").NewRow
            With dr2
                dr.Item("numero_pedido") = pdrv_pedido.Item("numero_pedido")
                dr.Item("producto") = .Item("producto")
                dr.Item("cantidad") = .Item("cantidad")
                dr.Item("precio") = .Item("precio")
                dr.Item("total_linea") = .Item("Total")
            End With
            myOds.Tables("pedidos_detalle_tracking").Rows.Add(dr)
        Next



        dr = myOds.Tables("pedidos_encabezado").NewRow
        With pdrv_pedido
            dr.Item("empresa") = .Item("empresa")
            dr.Item("numero_pedido") = .Item("numero_pedido")
            dr.Item("ctacte") = .Item("ctacte")
            dr.Item("forma_pago") = .Item("forma_pago")
            dr.Item("total_pedido") = .Item("total_pedido")
            dr.Item("fecha_pedido") = .Item("fecha_pedido")
            dr.Item("fecha_entrega") = .Item("fecha_entrega")
            dr.Item("comentarios") = pcomentarioActual
            dr.Item("estado") = .Item("estado")
            dr.Item("listaprecios") = .Item("listaprecios")
        End With
        myOds.Tables("pedidos_encabezado").Rows.Add(dr)



        For Each dr2 In dt_detalle_pedido.Rows
            dr = myOds.Tables("pedidos_detalle").NewRow
            With dr2
                dr.Item("numero_pedido") = pdrv_pedido.Item("numero_pedido")
                dr.Item("linea") = .Item("linea")
                dr.Item("producto") = .Item("cod_producto_flex")
                dr.Item("cantidad") = .Item("cantidad")
                dr.Item("precio") = .Item("precio")
                dr.Item("total_linea") = .Item("total_linea")
            End With

            myOds.Tables("pedidos_detalle").Rows.Add(dr)
        Next

    End Sub

    Private Sub Crear_Estructura_Complemento(ByRef myOds)

        Dim dt = New DataTable("pedidos_encabezado_tracking")

        dt.Columns.Add("numero_pedido", GetType(String))
        dt.Columns.Add("numero_factura", GetType(String))
        dt.Columns.Add("fecha_factura", GetType(DateTime))
        dt.Columns.Add("total_factura", GetType(Double))

        myOds.Tables.Add(dt.copy)

        dt = New DataTable("pedidos_detalle_tracking")
        dt.Columns.Add("numero_pedido", GetType(String))
        dt.Columns.Add("linea", GetType(Integer))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("cantidad", GetType(Double))
        dt.Columns.Add("precio", GetType(String))
        dt.Columns.Add("total_linea", GetType(String))
        myOds.Tables.Add(dt.copy)

        dt = New DataTable("pedidos_encabezado")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("numero_pedido", GetType(String))
        dt.Columns.Add("ctacte", GetType(String))
        dt.Columns.Add("forma_pago", GetType(String))
        dt.Columns.Add("total_pedido", GetType(Double))
        dt.Columns.Add("fecha_pedido", GetType(DateTime))
        dt.Columns.Add("fecha_entrega", GetType(DateTime))
        dt.Columns.Add("comentarios", GetType(String))
        dt.Columns.Add("estado", GetType(Integer))
        dt.Columns.Add("listaprecios", GetType(String))

        myOds.Tables.Add(dt.copy)


        dt = New DataTable("pedidos_detalle")
        dt.Columns.Add("numero_pedido", GetType(String))
        dt.Columns.Add("linea", GetType(Integer))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("cantidad", GetType(Double))
        dt.Columns.Add("precio", GetType(String))
        dt.Columns.Add("total_linea", GetType(String))
        myOds.Tables.Add(dt.copy)
    End Sub
End Class

#End Region

#Region "Recepcion Informacion Umbright Mobile"

Public Class Recepcion_Informacion_PDA


    Public Sub revision_facturacion_autoconsumo()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim numero_pedido As Integer

        Try
            Otrans.open()
            cOtrans.open()
            ls_sql = "pa_var_um_facturacion_autoconsumo_traslado" '(c) 20230428
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Dim Correlativo As Integer = 0
                For Each dr As DataRow In dt.Rows
                    Try

                        Correlativo += 1
                        ls_sql = "pa_sel_um_listaprecio_facturacion_autoconsumo_traslado '" & dr.Item("empresa") & "'"
                        dt3 = Otrans.Obtiene(ls_sql)


                        ls_sql = "pa_ins_um_mov_pedidos_encabezado '" & dr.Item("empresa") & "','" &
                        Now.ToString("yy") & dr.Item("numero").ToString.PadLeft(8, "0") & "','" & dr.Item("ctacte_fc") & "','CREDITO 30 DIAS',0,0,'" &
                        Now.ToString("dd-MM-yyyy") & "','" & Now.ToString("dd-MM-yyyy") & "','" &
                            "SOLICITUD NO. " & dr.Item("numero") & " " & dr.Item("observaciones") & "','" & dr.Item("usuario_grabo") & "',0,'" & dt3.Rows(0).Item("lisprecio") & "','" & dr.Item("direccion_entrega") & "','" &
                            dr.Item("bodega").ToString & "'"

                        cOtrans.Ingresa(ls_sql)
                        If cOtrans.Codigo_error = 0 Then
                            dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            numero_pedido = dt.Rows(0).Item("newid").ToString

                            ls_sql = "pa_var_um_facturacion_autoconsumo_detalle_traslado " & dr.Item("cod_factura")

                            dt2 = Otrans.Obtiene(ls_sql)

                            Dim LineaLocal As Integer = 0

                            For Each drrs As DataRow In dt2.Rows
                                LineaLocal += 1
                                ls_sql = "pa_ins_um_mov_pedidos_detalle_traslado " & numero_pedido & "," &
                                    LineaLocal & ",'" & drrs.Item("producto").ToString & "'," &
                                    drrs.Item("Cantidad") & "," & drrs.Item("precio") & "," &
                                    drrs.Item("Cantidad") * drrs.Item("precio") & ",'" & drrs.Item("marca") &
                                    "','" & drrs.Item("centro_costo") & "','" & drrs.Item("gasto_conta") & "','" &
                                    drrs.Item("rubro") & "','" & drrs.Item("comentario") & "'"
                                cOtrans.Ingresa(ls_sql)
                            Next

                            ls_sql = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                            cOtrans.Actualiza(ls_sql)
                            ls_sql = "pa_upd_facturacion_autoconsumo_traslado_estado '" & dr.Item("empresa") & "'," & dr.Item("cod_factura") & ",'" & numero_pedido & "'"
                            Otrans.Actualiza(ls_sql)
                        End If

                    Catch ex As Exception
                        Otrans.Escribir_Log(ex.ToString)
                    End Try
                Next
            End If

        Catch ex As Exception
            Otrans.Escribir_Log(ex.ToString)
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub



    Public Function Procesar_Pedidos_Umbright_Mobile_Gestion() As DataTable

        Dim dt, dt_detalle, dtValidacion, dtAux As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento, lsCliente, lsComentarioRechazo As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbOrdenEdifact As Boolean = False
        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim liJump As Integer = 0
        Dim liProceso As Integer = 7
        Dim sMonedaPago As String = "Q"
        Dim lsOrigen As String
        Try
            'ls_sql = "pa_var_um_mov_pedidos_encabezado_procesables_empresa"
            ls_sql = "pa_var_um_mov_pedidos_encabezado_procesables"

            dt = ClsGen.selectQuery("corporativo", ls_sql)


            For Each dr In dt.Rows
                Try
                    If True Then





                        generarPedidoCorporativo_to_flexline(dr, lsNumeroPedido, lsTipoDocumento, dt_detalle, 80, lsComentarioRechazo)
                        lsOrigen = "Tekne"

                        Try
                            If lsNumeroPedido.Length > 5 Then


                                '+------------------------------------------
                                '| Envio de correo de recepcion de pedidos
                                '+------------------------------------------
                                Try
                                    If dr.Item("Empresa") = "DIVINOS" Then
                                        sMonedaPago = "$"
                                    ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                        sMonedaPago = "L"
                                    Else
                                        sMonedaPago = "Q"
                                    End If

                                Catch ex As Exception

                                End Try


                                Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))
                                'oFlex.Obtiene(String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                                Dim oMail As New Interfaz_CRM.Mail.SendMail()
                                Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                                Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                                lstPedidos.Clear()

                                For Each drow As DataRow In dt_detalle.Rows 'dsPedidos.Tables().Item("pedidos_detalle").Rows

                                    Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))
                                    'oFlex.Obtiene(String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", drow.Item("empresa"), drow.Item("cod_producto_flex")))

                                    If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                        oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                          .cantidad = drow.Item("cantidad"),
                                          .cod_pedido = drow.Item("cod_pedido"),
                                          .cod_producto_flex = drow.Item("cod_producto_flex"),
                                          .comentario = drow.Item("comentario").ToString,
                                          .empresa = dr.Item("empresa"),
                                          .Id = 0, 'drow.Item("Id"),
                                          .linea = drow.Item("linea"),
                                          .marca = drow.Item("marca").ToString,
                                          .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                          .precio = drow.Item("precio"),
                                          .total_linea = drow.Item("total_linea"),
                                          .unitofMesure = drow.Item("unitofMesure").ToString
                                        })

                                    End If

                                Next

                                oPedido.ctacte = dr.Item("ctacte").ToString()
                                oPedido.cod_pedido = dr.Item("cod_pedido")
                                oPedido.comentarios = dr.Item("comentarios").ToString.PadRight(80, " ").Substring(0, 80)
                                oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                                oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                                oPedido.referencia_pdv = dr.Item("referencia_pdv").ToString
                                oPedido.dias_entrega = dr.Item("dias_entrega").ToString
                                oPedido.horas_entrega = dr.Item("horas_entrega").ToString
                                oPedido.empresa = dr.Item("empresa")
                                oPedido.numero_pedido = lsNumeroPedido
                                oPedido.fecha_entrega = dr.Item("fecha_entrega")
                                oPedido.fecha_pedido = dr.Item("fecha_modifico")
                                oPedido.DetallePedido = oDetallePedido
                                oPedido.total_pedido = dr.Item("total_pedido")
                                oPedido.tipo_docto_flex = lsTipoDocumento
                                oPedido.motivo_retenido = lsComentarioRechazo

                                lstPedidos.Add(oPedido)
                                Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                            String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                                Dim strCorreos As String = oCorreos.Rows(0).Item("correo").ToString()

                                Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                                String.Format("pa_var_um_credenciales_notificacion"))

                                'Pedido Aprabado / Rechazado
                                Try
                                    If lsComentarioRechazo.Length > 0 Then
                                        lsOrigen += " - Retenido -"


                                        ClsGen.enviarMensajeTeams(strCorreos.Split(",")(0), "Pedido Retenido",
                                              "Empresa : " & dr.Item("empresa") & "|" &
                                              "Cliente : " & dr.Item("ctacte").ToString() & dtCliente.Rows(0).Item("RazonSocial") & "|" &
                                              "Monto : " & dr.Item("total_pedido") & "|" &
                                              "Pedido : " & lsTipoDocumento & " - " & lsNumeroPedido & "|" &
                                              "Motivo Retenido: " & lsComentarioRechazo & "|" &
                                              "Comentarios Pedido : " & dr.Item("comentarios").ToString.PadRight(80, " ").Substring(0, 80))
                                    End If
                                Catch ex As Exception


                                End Try

                                oMail.EnviarCorreo(oCorreos.Rows(0).Item("nombre"), strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, lsOrigen, sMonedaPago)
                            End If

                        Catch ex As Exception
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)
                        End Try



                    End If
                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try


            Next



        Catch ex As Exception
        Finally

            ClsGen = Nothing

        End Try
        Return dt
    End Function

    Public Function Procesar_Pedidos_Umbright_Mobile_PowerStreet() As DataTable

        Dim dt, dt_detalle, dtValidacion, dtAux As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento, lsCliente As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbOrdenEdifact As Boolean = False
        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim sMonedaPago As String


        Try
            'myOtrans.open()
            ls_sql = "pa_var_um_mov_pedidos_encabezado_procesables"

            dt = ClsGen.selectQuery("scm", ls_sql)

            For Each dr In dt.Rows

                Try

                    lsNumeroPedido = String.Empty
                    lsTipoDocumento = String.Empty

                    generarPedidoPowerStreet(dr, lsNumeroPedido, lsTipoDocumento, dt_detalle)





                    If lsNumeroPedido.Length > 5 Then



                        Try

                            '+------------------------------------------
                            '| Envio de correo de recepcion de pedidos
                            '+------------------------------------------
                            Try
                                If dr.Item("Empresa") = "DIVINOS" Then
                                    sMonedaPago = "$"
                                ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                    sMonedaPago = "L"
                                Else
                                    sMonedaPago = "Q"
                                End If

                            Catch ex As Exception

                            End Try

                            Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))
                            'oFlex.Obtiene(String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                            Dim oMail As New Interfaz_CRM.Mail.SendMail()
                            Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                            Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                            lstPedidos.Clear()

                            For Each drow As DataRow In dt_detalle.Rows 'dsPedidos.Tables().Item("pedidos_detalle").Rows

                                Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))
                                'oFlex.Obtiene(String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", drow.Item("empresa"), drow.Item("cod_producto_flex")))

                                If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                    oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                              .cantidad = drow.Item("cantidad"),
                                              .cod_pedido = drow.Item("cod_pedido"),
                                              .cod_producto_flex = drow.Item("cod_producto_flex"),
                                              .comentario = drow.Item("comentario").ToString,
                                              .empresa = dr.Item("empresa"),
                                              .Id = 0, 'drow.Item("Id"),
                                              .linea = drow.Item("linea"),
                                              .marca = drow.Item("marca").ToString,
                                              .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                              .precio = drow.Item("precio"),
                                              .total_linea = drow.Item("total_linea"),
                                              .unitofMesure = drow.Item("unitofMesure").ToString
                                            })

                                End If

                            Next

                            oPedido.ctacte = dr.Item("ctacte").ToString()
                            oPedido.cod_pedido = dr.Item("cod_pedido")
                            oPedido.comentarios = dr.Item("comentarios")
                            oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                            oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                            oPedido.empresa = dr.Item("empresa")
                            oPedido.numero_pedido = lsNumeroPedido
                            oPedido.fecha_entrega = dr.Item("fecha_entrega")
                            oPedido.fecha_pedido = dr.Item("fecha_modifico")
                            oPedido.DetallePedido = oDetallePedido
                            oPedido.total_pedido = dr.Item("total_pedido")
                            oPedido.tipo_docto_flex = lsTipoDocumento

                            lstPedidos.Add(oPedido)
                            Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                                String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                            Dim strCorreos As String = oCorreos.Rows(0).Item("correo").ToString()

                            Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                                    String.Format("pa_var_um_credenciales_notificacion"))

                            oMail.EnviarCorreo(oCorreos.Rows(0).Item("nombre"), strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, "Power Street", sMonedaPago)

                        Catch ex As Exception
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)
                        End Try


                    End If

                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try




            Next



        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
        Return dt
    End Function

    Public Function Procesar_Pedidos_Umbright_Mobile_Cavas() As DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt, dt_detalle, dtUnicos As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento, lsCliente As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbOrdenEdifact As Boolean = False
        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim sMonedaPago As String


        Try
            'myOtrans.open()
            ls_sql = "pa_var_um_mov_pedidos_encabezado_procesables_cavas"
            '            dt = myOtrans.Obtiene(ls_sql)
            dt = ClsGen.selectQuery("corporativo", ls_sql)

            For Each dr In dt.Rows

                ls_sql = "pa_var_um_mov_pedidos_detalle_procesables_cavas " & dr.Item("cod_pedido").ToString
                dt_detalle = ClsGen.selectQuery("corporativo", ls_sql)
                dt_detalle.TableName = "pedidos_detalle"

                Dim ods As New DataSet
                ods.Tables.Add(dt_detalle.Copy)
                lsNumeroPedido = ""
                lsTipoDocumento = "PEDIDO AL CONTADO SHIFT"
                lsCliente = ""

                Try

                    dr.Item("comentarios") = dr.Item("comentarios") & " Numero Pedido Web: " & dr.Item("numero_pedido").ToString

                    If Hacer_Pedido_Clase_Web(ods, dr.Item("numero_pedido"), dr, lsNumeroPedido, lsTipoDocumento, lsCliente, False, 75) Then
                        ls_sql = "pa_upd_um_mov_pedidos_encabezado_cavas " & dr.Item("cod_pedido").ToString & ",'" & dr.Item("empresa").ToString & "',2,'" &
                                        lsTipoDocumento & "','" & lsNumeroPedido & "'"

                        ClsGen.insertQuery("corporativo", ls_sql)

                        ls_sql = "pa_upd_um_documento_shift '" & dr.Item("empresa").ToString & "','" &
                                        lsTipoDocumento & "','" & lsNumeroPedido & "'"

                        ClsGen.insertQuery("corporativo", ls_sql)

                    End If

                    'Enviar Correo por cada pedido

                    Try

                        Try
                            If dr.Item("Empresa") = "DIVINOS" Then
                                sMonedaPago = "$"
                            ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                sMonedaPago = "L"
                            Else
                                sMonedaPago = "Q"
                            End If

                        Catch ex As Exception

                        End Try
                        '+------------------------------------------
                        '| Envio de correo de recepcion de pedidos
                        '+------------------------------------------

                        Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))
                        'oFlex.Obtiene(String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                        Dim oMail As New Interfaz_CRM.Mail.SendMail()
                        Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                        Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                        lstPedidos.Clear()

                        For Each drow As DataRow In dt_detalle.Rows 'dsPedidos.Tables().Item("pedidos_detalle").Rows

                            Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))
                            'oFlex.Obtiene(String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", drow.Item("empresa"), drow.Item("cod_producto_flex")))

                            If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                      .cantidad = drow.Item("cantidad"),
                                      .cod_pedido = drow.Item("cod_pedido"),
                                      .cod_producto_flex = drow.Item("cod_producto_flex"),
                                      .comentario = drow.Item("comentario").ToString,
                                      .empresa = dr.Item("empresa"),
                                      .Id = 0, 'drow.Item("Id"),
                                      .linea = drow.Item("linea"),
                                      .marca = drow.Item("marca").ToString,
                                      .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                      .precio = drow.Item("precio"),
                                      .total_linea = drow.Item("total_linea"),
                                      .unitofMesure = drow.Item("unitofMesure").ToString
                                    })

                            End If

                        Next

                        oPedido.ctacte = dr.Item("ctacte").ToString()
                        oPedido.cod_pedido = dr.Item("cod_pedido")
                        oPedido.comentarios = dr.Item("comentarios")
                        oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                        oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                        oPedido.empresa = dr.Item("empresa")
                        oPedido.numero_pedido = lsNumeroPedido
                        oPedido.fecha_entrega = dr.Item("fecha_entrega")
                        oPedido.fecha_pedido = dr.Item("fecha_modifico")
                        oPedido.DetallePedido = oDetallePedido
                        oPedido.total_pedido = dr.Item("total_pedido")
                        oPedido.tipo_docto_flex = lsTipoDocumento

                        lstPedidos.Add(oPedido)
                        Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                        String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                        Dim strCorreos As String
                        Try
                            strCorreos = oCorreos.Rows(0).Item("correo").ToString()
                        Catch ex As Exception
                            strCorreos = "facturacion@umbral.com.gt"
                        End Try


                        Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                            String.Format("pa_var_um_credenciales_notificacion"))

                        oMail.EnviarCorreo("", strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, "Shift", sMonedaPago)


                    Catch ex As Exception

                        ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                        ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)

                    End Try




                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try

            Next

            If False Then


                '(c) 20151911 Enviar Correo Informando que se proceso el pedido
                Dim lsBodyMail, sBody As String
                Dim iCount As Integer
                dtUnicos = ClsGen.ValoresDistinto(dt, "usuario_grabo".Split(","))
                Dim dtPedido As DataTable
                Dim lbDiferenciasEdi As Boolean = False

                For Each dr In dtUnicos.Rows
                    dt.DefaultView.RowFilter = "usuario_grabo = '" & dr.Item("usuario_grabo") & "'"
                    lsBodyMail = String.Empty
                    iCount = 0
                    lbOrdenEdifact = False
                    sBody = String.Empty
                    For Each drv As DataRowView In dt.DefaultView
                        'If drv.Item("comentarios").ToString.ToLower.StartsWith("tekne") Or
                        ' drv.Item("comentarios").ToString.ToLower.StartsWith("edi") Then
                        If drv.Item("comentarios").ToString.Length > 0 Or
                            drv.Item("comentarios").ToString.Length > 0 Then

                            If drv.Item("comentarios").ToString.ToLower.StartsWith("edi") Then lbOrdenEdifact = True

                            iCount += 1

                            sBody = sBody & "<tr></tr><tr>"
                            'sBody = sBody & "<td>Buen Dia </td>"
                            sBody = sBody & "</tr>"
                            sBody = sBody & "<td>Pedido No.</td>"
                            sBody = sBody & "<td>" & iCount & "</td>"
                            sBody = sBody & "</tr><tr>"
                            sBody = sBody & "<td>Empresa</td><td>" & drv.Item("Empresa").ToString & "</td>"
                            sBody = sBody & "</tr><tr>"


                            Try


                                dtPedido = ClsGen.selectQuery("corporativo", "pa_var_um_mov_pedidos_encabezado_numero '" & drv.Item("Empresa").ToString & "','" &
                                            drv.Item("numero_pedido").ToString & "','" & drv.Item("ctacte").ToString & "'")

                                sBody = sBody & "<td>Pedido</td><td>" & dtPedido.Rows(0).Item("tipo_docto_Flex") & "-" & dtPedido.Rows(0).Item("Numero_Flex") & "</td>"


                                ''Llenar la Informacion de walmart 07012019
                                If lbOrdenEdifact Then

                                    If Me.ValidarOrdenesEdi(drv.Item("Empresa"), dtPedido.Rows(0).Item("Numero_Flex"), sBody) Then lbDiferenciasEdi = True



                                End If



                                dtPedido = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & drv.Item("Empresa").ToString &
                                                "','" & dtPedido.Rows(0).Item("tipo_docto_Flex").ToString & "','" & dtPedido.Rows(0).Item("Numero_Flex").ToString & "'")


                            Catch ex As Exception

                            End Try

                            sBody = sBody & "</tr><tr>"
                            'Try
                            '    If dt.Rows.Count > 0 Then
                            '        sBody = sBody & "<td>Factura</td><td>" & dt.Rows(0).Item("tipodocto") & "-" & dt.Rows(0).Item("numero") & "</td>"
                            '        sBody = sBody & "</tr><tr>"
                            '    Else
                            '        dt = ClsGen.selectQuery("FlexLine", "pa_sel_um_documento '" & dr.Item("Empresa").ToString & _
                            '                            "','" & dr.Item("tipo_docto_Flex").ToString & "','" & dr.Item("Numero_Flex").ToString & "'")
                            '        If dt.Rows.Count > 0 Then
                            '            ''Validar con Creditos el envio de esta informacion
                            '            ''Estado y comentario1
                            '            sBody = sBody & "<td>Creditos</td><td>" & dt.Rows(0).Item("descripcion") & "    - " & dt.Rows(0).Item("comentario1") & "</td>"
                            '            sBody = sBody & "</tr><tr>"
                            '        End If
                            '    End If
                            'Catch ex As Exception

                            'End Try

                            sBody = sBody & "<td>Total</td><td>" & drv.Item("total_pedido") & "</td>"
                            sBody = sBody & "</tr><tr>"
                            sBody = sBody & "<td>Lineas</td><td>" & drv.Item("total_lineas") & "</td>"
                            sBody = sBody & "</tr><tr>"
                            sBody = sBody & "<td>Comentario</td><td>" & drv.Item("comentarios") & "</td>"
                            sBody = sBody & "</tr><tr>"
                            sBody = sBody & "<td>Cliente</td><td>" & drv.Item("ctacte")

                            Try
                                sBody = sBody & " -- " & dtPedido.Rows(0).Item("razonsocial").ToString
                            Catch ex As Exception

                            End Try
                            sBody = sBody & "</td>"
                            '& "-" & drv.Item("razonSocial") & "</td>"
                            sBody = sBody & "</tr><tr><td></td><td></td></tr><tr></tr>"
                            sBody = sBody & "<tr></tr><tr></tr>"
                            sBody = sBody & "<tr></tr><tr></tr>"
                        End If

                    Next

                    ''Si Sbody lleva datos debo enviar correo de confirmacion de recepcion de Pedidos
                    If sBody.Length > 0 Then



                        lsBodyMail = "<table><font size=1>"

                        lsBodyMail = lsBodyMail & "<tr></tr><tr>"
                        lsBodyMail = lsBodyMail & "<td>Buen Dia "
                        Dim dtUsuario As DataTable = ClsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & dr.Item("usuario_grabo") & "'")

                        Try
                            lsBodyMail = lsBodyMail & StrConv(dtUsuario.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
                        Catch ex As Exception

                        End Try
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "<td>Le informamos que hemos procesado los siguientes pedidos: "
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "</tr><tr>"

                        sBody = sBody & "</table>"
                        lsBodyMail = lsBodyMail + sBody

                        dtUsuario = ClsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario_grabo") & "'")
                        Try
                            Dim lsCuentaUsuario As String
                            lsCuentaUsuario = dtUsuario.Rows(0).Item("correo").ToString

                            'If Today.DayOfWeek = DayOfWeek.Friday Or Today.DayOfWeek = DayOfWeek.Saturday Then
                            'If lbOrdenEdifact Then lsCuentaUsuario = lsCuentaUsuario & ", it@umbralcorp.com"
                            If lbOrdenEdifact Then lsCuentaUsuario = "edi_walmart@umbralcorp.com"


                            'End If

                            If lbDiferenciasEdi Then lsCuentaUsuario = lsCuentaUsuario & ",lrivera@umbral.com.gt"
                            ClsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral",
                                                lsCuentaUsuario,
                                                "Confirmacion Recepcion de Pedidos" & IIf(lbDiferenciasEdi, "  ** Pedidos Con Diferencias de Precios **", ""), lsBodyMail, "", IIf(lbDiferenciasEdi, "rosa.pacheco@codicasa.com, enma.aguilar@dmarte.com", ""))
                            ClsGen.Escribir_Log("Enviando Correo a " & dr.Item("usuario_grabo").ToString)
                        Catch ex As Exception

                        End Try

                    End If
                    lsBodyMail = String.Empty

                Next 'Usuarios
            End If

        Catch ex As Exception
        Finally

            ClsGen = Nothing

        End Try
        Return dt
    End Function
    '(c) 01/10/2024

    Public Function Procesar_Solicitud_Consignaciones_Azzure() As DataTable

        Dim dt, dt_detalle As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento As String
        Dim ClsGen As New ClasesGenerales.General

        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim oflex As New Umbral_Flex.consignaciones
        Dim sMonedaPago As String

        Try

            ls_sql = "pa_var_um_mov_pedidos_encabezado_solicitud_consignacion_procesables"
            dt = ClsGen.selectQuery("RegionalDB", ls_sql)

            For Each dr In dt.Rows

                Try

                    lsNumeroPedido = String.Empty
                    lsTipoDocumento = String.Empty
                    generarsolicitudConsignacion_Azzure(dr, lsNumeroPedido, lsTipoDocumento, dt_detalle)

                    If lsNumeroPedido.Length > 5 Then
                        Try
                            Try
                                If dr.Item("Empresa") = "DIVINOS" Then
                                    sMonedaPago = "$"
                                ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                    sMonedaPago = "L"
                                Else
                                    sMonedaPago = "Q"
                                End If

                            Catch ex As Exception

                            End Try

                            Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                            Dim oMail As New Interfaz_CRM.Mail.SendMail()
                            Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                            Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                            lstPedidos.Clear()

                            For Each drow As DataRow In dt_detalle.Rows

                                Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))


                                If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                    oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                              .cantidad = drow.Item("cantidad"),
                                              .cod_pedido = drow.Item("cod_pedido"),
                                              .cod_producto_flex = drow.Item("cod_producto_flex"),
                                              .comentario = drow.Item("comentario").ToString,
                                              .empresa = dr.Item("empresa"),
                                              .Id = 0, 'drow.Item("Id"),
                                              .linea = drow.Item("linea"),
                                              .marca = drow.Item("marca").ToString,
                                              .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                              .precio = drow.Item("precio"),
                                              .total_linea = drow.Item("total_linea"),
                                              .unitofMesure = drow.Item("unitofMesure").ToString
                                            })

                                End If

                            Next

                            oPedido.ctacte = dr.Item("ctacte").ToString()
                            oPedido.cod_pedido = dr.Item("cod_pedido")
                            oPedido.comentarios = dr.Item("comentarios")
                            oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                            oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                            oPedido.empresa = dr.Item("empresa")
                            oPedido.numero_pedido = lsNumeroPedido
                            oPedido.fecha_entrega = dr.Item("fecha_entrega")
                            oPedido.fecha_pedido = dr.Item("fecha_modifico")
                            oPedido.DetallePedido = oDetallePedido
                            oPedido.total_pedido = dr.Item("total_pedido")
                            oPedido.tipo_docto_flex = lsTipoDocumento

                            lstPedidos.Add(oPedido)

                            Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                                String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                            Dim strCorreos As String = oCorreos.Rows(0).Item("correo").ToString()

                            Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                                    String.Format("pa_var_um_credenciales_notificacion"))

                            oMail.EnviarCorreo(oCorreos.Rows(0).Item("nombre"), strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, "Tenant", sMonedaPago)

                        Catch ex As Exception
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)
                        End Try
                    End If

                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
        Return dt
    End Function

    '(c) 20240827

    Public Function Procesar_Conteo_Consignaciones_Azzure() As DataTable

        Dim dt, dt_detalle As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento As String
        Dim ClsGen As New ClasesGenerales.General

        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim oflex As New Umbral_Flex.consignaciones
        Dim sMonedaPago As String


        Try

            ls_sql = "pa_var_um_mov_pedidos_encabezado_conteo_consignacion_procesables"
            dt = ClsGen.selectQuery("RegionalDB", ls_sql)

            For Each dr In dt.Rows

                Try

                    lsNumeroPedido = String.Empty
                    lsTipoDocumento = String.Empty
                    generarConteo_Consignacion_Azzure(dr, lsNumeroPedido, lsTipoDocumento, dt_detalle)

                    If lsNumeroPedido.Length > 5 Then
                        Try

                            Try
                                If dr.Item("Empresa") = "DIVINOS" Then
                                    sMonedaPago = "$"
                                ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                    sMonedaPago = "L"
                                Else
                                    sMonedaPago = "Q"
                                End If

                            Catch ex As Exception

                            End Try

                            Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                            Dim oMail As New Interfaz_CRM.Mail.SendMail()
                            Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                            Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                            lstPedidos.Clear()

                            For Each drow As DataRow In dt_detalle.Rows

                                Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))


                                If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                    oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                              .cantidad = drow.Item("cantidad"),
                                              .cod_pedido = drow.Item("cod_pedido"),
                                              .cod_producto_flex = drow.Item("cod_producto_flex"),
                                              .comentario = drow.Item("comentario").ToString,
                                              .empresa = dr.Item("empresa"),
                                              .Id = 0, 'drow.Item("Id"),
                                              .linea = drow.Item("linea"),
                                              .marca = drow.Item("marca").ToString,
                                              .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                              .precio = drow.Item("precio"),
                                              .total_linea = drow.Item("total_linea"),
                                              .unitofMesure = drow.Item("unitofMesure").ToString
                                            })

                                End If

                            Next

                            oPedido.ctacte = dr.Item("ctacte").ToString()
                            oPedido.cod_pedido = dr.Item("cod_pedido")
                            oPedido.comentarios = dr.Item("comentarios")
                            oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                            oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                            oPedido.empresa = dr.Item("empresa")
                            oPedido.numero_pedido = lsNumeroPedido
                            oPedido.fecha_entrega = dr.Item("fecha_entrega")
                            oPedido.fecha_pedido = dr.Item("fecha_modifico")
                            oPedido.DetallePedido = oDetallePedido
                            oPedido.total_pedido = dr.Item("total_pedido")
                            oPedido.tipo_docto_flex = lsTipoDocumento

                            lstPedidos.Add(oPedido)

                            Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                                String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                            Dim strCorreos As String = oCorreos.Rows(0).Item("correo").ToString()

                            Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                                    String.Format("pa_var_um_credenciales_notificacion"))

                            oMail.EnviarCorreo(oCorreos.Rows(0).Item("nombre"), strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, "Tenant", sMonedaPago)

                        Catch ex As Exception
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)
                        End Try
                    End If

                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
        Return dt
    End Function




    Public Function Procesar_Pedidos_Umbright_Mobile_Azzure() As DataTable

        Dim dt, dt_detalle, dtValidacion, dtAux As DataTable
        Dim dr As DataRow
        Dim ls_sql As String
        Dim lsNumeroPedido, lsTipoDocumento, lsCliente, lsComentarioRechazo As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbOrdenEdifact As Boolean = False
        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim sMonedaPago As String
        Dim sMaximoComentarios As Integer = 45
        Dim lsOrigen As String
        Try

            ls_sql = "pa_var_um_mov_pedidos_encabezado_procesables"
            dt = ClsGen.selectQuery("RegionalDB", ls_sql)

            For Each dr In dt.Rows

                Try

                    'If dr.Item("empresa").ToString.ToLower <> "dmarte1" Then

                    sMaximoComentarios = 45
                    If dr.Item("empresa") = "DIMAEXSA" Then
                        sMaximoComentarios = 60
                    End If

                    lsNumeroPedido = String.Empty
                    lsTipoDocumento = String.Empty
                    lsComentarioRechazo = String.Empty
                    lsOrigen = "Tenant"

                    generarPedidoAzzure_to_flexline(dr, lsNumeroPedido, lsTipoDocumento, dt_detalle, sMaximoComentarios, lsComentarioRechazo)


                    If lsNumeroPedido.Length > 5 Then



                        Try

                            Try
                                If dr.Item("Empresa") = "DIVINOS" Then
                                    sMonedaPago = "$"
                                ElseIf dr.Item("Empresa") = "VINOTECAHN" Then
                                    sMonedaPago = "L"
                                Else
                                    sMonedaPago = "Q"
                                End If

                            Catch ex As Exception

                            End Try
                            '+------------------------------------------
                            '| Envio de correo de recepcion de pedidos
                            '+------------------------------------------

                            Dim dtCliente As DataTable = ClsGen.selectQuery("FlexLine", String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))
                            'oFlex.Obtiene(String.Format("pa_sel_um_cliente_new_ps '{0}', '{1}'", dr.Item("ctacte"), dr.Item("Empresa")))

                            Dim oMail As New Interfaz_CRM.Mail.SendMail()
                            Dim oPedido As New Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas()
                            Dim oDetallePedido As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps)

                            lstPedidos.Clear()

                            For Each drow As DataRow In dt_detalle.Rows 'dsPedidos.Tables().Item("pedidos_detalle").Rows

                                Dim dtProducto As DataTable = ClsGen.selectQuery("Flexline", String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", dr.Item("empresa"), drow.Item("cod_producto_flex")))
                                'oFlex.Obtiene(String.Format("pa_sel_um_producto_new_ps '{0}', '{1}'", drow.Item("empresa"), drow.Item("cod_producto_flex")))

                                If drow.Item("cod_pedido") = dr.Item("cod_pedido") Then

                                    oDetallePedido.Add(New Interfaz_CRM.Mail.DTO.mov_pedidos_detalle_ps() With {
                                                  .cantidad = drow.Item("cantidad"),
                                                  .cod_pedido = drow.Item("cod_pedido"),
                                                  .cod_producto_flex = drow.Item("cod_producto_flex"),
                                                  .comentario = drow.Item("comentario").ToString,
                                                  .empresa = dr.Item("empresa"),
                                                  .Id = 0, 'drow.Item("Id"),
                                                  .linea = drow.Item("linea"),
                                                  .marca = drow.Item("marca").ToString,
                                                  .nombre_producto = dtProducto.Rows(0)("GLOSA"),
                                                  .precio = drow.Item("precio"),
                                                  .total_linea = drow.Item("total_linea"),
                                                  .unitofMesure = drow.Item("unitofMesure").ToString
                                                })

                                End If

                            Next

                            oPedido.ctacte = dr.Item("ctacte").ToString()
                            oPedido.cod_pedido = dr.Item("cod_pedido")
                            oPedido.comentarios = dr.Item("comentarios").ToString.PadRight(sMaximoComentarios, " ").Substring(0, sMaximoComentarios)
                            oPedido.nombre_cliente = dtCliente.Rows(0).Item("RazonSocial")
                            oPedido.direccion_entrega = dr.Item("direccion_entrega").ToString
                            oPedido.empresa = dr.Item("empresa")
                            oPedido.referencia_pdv = dr.Item("referencia_pdv").ToString
                            oPedido.numero_pedido = lsNumeroPedido
                            oPedido.fecha_entrega = dr.Item("fecha_entrega")
                            oPedido.fecha_pedido = dr.Item("fecha_modifico")
                            oPedido.DetallePedido = oDetallePedido
                            oPedido.total_pedido = dr.Item("total_pedido")
                            oPedido.dias_entrega = dr.Item("dias_entrega").ToString
                            oPedido.horas_entrega = dr.Item("horas_entrega").ToString
                            oPedido.tipo_docto_flex = lsTipoDocumento
                            oPedido.bodega = dr.Item("bodega").ToString
                            oPedido.path_pdf = dr.Item("path_pdf").ToString
                            oPedido.motivo_retenido = lsComentarioRechazo

                            Try
                                If File.Exists(oPedido.path_pdf) Then
                                    oPedido.adjunto_correcto = "SI"
                                Else
                                    oPedido.adjunto_correcto = "NO"
                                End If

                            Catch ex As Exception

                            End Try

                            lstPedidos.Add(oPedido)
                            Dim oCorreos As DataTable = ClsGen.selectQuery("FlexLine",
                                    String.Format("pa_sel_um_correo_usuario_lgs '{0}'", dr.Item("usuario_grabo")))
                            Dim strCorreos As String = oCorreos.Rows(0).Item("correo").ToString()

                            Dim oCorreosSeg As DataTable = ClsGen.selectQuery("SCM",
                                                        String.Format("pa_var_um_credenciales_notificacion"))

                            Try
                                If lsComentarioRechazo.Length > 0 Then
                                    lsOrigen += " - Retenido -"


                                    ClsGen.enviarMensajeTeams(strCorreos.Split(",")(0), "Pedido Retenido",
                                              "Empresa : " & dr.Item("empresa") & "|" &
                                              "Cliente : " & dr.Item("ctacte").ToString() & dtCliente.Rows(0).Item("RazonSocial") & "|" &
                                              "Monto : " & dr.Item("total_pedido") & "|" &
                                              "Pedido : " & lsTipoDocumento & " - " & lsNumeroPedido & "|" &
                                              "Motivo Retenido: " & lsComentarioRechazo & "|" &
                                              "Comentarios Pedido : " & dr.Item("comentarios").ToString.PadRight(80, " ").Substring(0, 80))
                                End If

                            Catch ex As Exception

                            End Try

                            oMail.EnviarCorreo(oCorreos.Rows(0).Item("nombre"), strCorreos, lstPedidos, oCorreosSeg.Rows(0).Item("mail").ToString, oCorreosSeg.Rows(0).Item("pwd").ToString, lsOrigen, sMonedaPago)

                        Catch ex As Exception
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.Message)
                            ClsGen.Escribir_Log("Obtener Tekne: " & ex.ToString)
                        End Try


                    End If
                    'End If
                Catch ex As Exception
                    ClsGen.Escribir_Log("Problemas Pedido " & dr.Item("numero_pedido"))
                End Try
            Next



        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
        Return dt
    End Function

    Public Sub generarPedidoPowerStreet(pdr As DataRow, ByRef psNumeroPedido As String, ByRef psTipoDocumento As String, ByRef dtDetalle As DataTable)

        Dim lsSQL As String
        Dim dtValidacion, dtAux As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Dim lsCliente As String

        Try
            lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & pdr.Item("cod_pedido").ToString
            dtDetalle = ClsGen.selectQuery("scm", lsSQL)
            dtDetalle.TableName = "pedidos_detalle"

            Dim ods As New DataSet
            ods.Tables.Add(dtDetalle.Copy)
            psNumeroPedido = ""
            psTipoDocumento = ""
            lsCliente = ""

            Try


                pdr.Item("comentarios") = "PS " & pdr.Item("comentarios").ToString 'Identifico que viene de azzure
                If Hacer_Pedido_Clase_Web(ods, pdr.Item("numero_pedido"), pdr, psNumeroPedido, psTipoDocumento, lsCliente, False, 75) Then
                    lsSQL = "pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',1,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                    ClsGen.insertQuery("scm", lsSQL)
                End If
                'End If

                '(c) 20230217 - Se proceda el PEDIDO FEL

                '265324 unisuper
                '2968550 vinoteca premium
                '20230810 (c) La Incondicional Interempresa

                'c) 20230925 Para PS todavia no estará activo

                Try
                    'If False Then
                    If pdr.Item("ctacte").ToString.Equals("2968550") Or
                                    pdr.Item("ctacte").ToString.StartsWith("265324") Or
                                    pdr.Item("listaprecios").ToString.StartsWith("2)_UNISUPER") Or
                                    pdr.Item("ctacte").ToString = "2968550" Or
                                    pdr.Item("ctacte").ToString = "11878454" Then
                        '203265207

                        dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdr.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                        If dtValidacion.Rows.Count > 0 Then
                            If dtValidacion.Rows(0).Item("cliente") = "2968550" Or 'Vintoeca Premium
                                           dtValidacion.Rows(0).Item("cliente") = "11878454" Or
                                            dtValidacion.Rows(0).Item("codlegal") = "2653247-6" Then 'Unisuper

                                If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                        psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                        (pdr.Item("empresa").ToString = "DMARTE1" Or
                                        pdr.Item("empresa").ToString = "DIUVA" Or
                                        pdr.Item("empresa").ToString = "CODICASA" Or
                                             pdr.Item("empresa").ToString = "VINOTECA") Then

                                    If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                            psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                                (pdr.Item("empresa").ToString = "DMARTE1" Or
                                                 pdr.Item("empresa").ToString = "DIUVA" Or
                                                 pdr.Item("empresa").ToString = "CODICASA" Or
                                                 pdr.Item("empresa").ToString = "VINOTECA") Then

                                        'If lsTipoDocumento.StartsWith("PEDIDO AL CREDITO") And dr.Item("CTACTE").ToString.StartsWith("2653248") Then
                                        '(c) 20220809
                                        Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                        Dim lsBodega As String

                                        If slCedi.Length = 0 Then
                                            lsBodega = "CD_CENTRAL"
                                        Else
                                            dtAux = Nothing

                                            dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdr.Item("empresa").ToString & "'")
                                            If dtAux.Rows.Count = 1 Then
                                                lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                            Else
                                                'Problema con los cedis
                                                'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                                Exit Try
                                            End If
                                        End If
                                    End If



                                    'generarPedidoFACEAutomatico_cedi(pdr.Item("empresa").ToString,
                                    '                                psTipoDocumento,
                                    '                                psNumeroPedido, lsBodega,
                                    '                                slCedi)




                                End If
                            End If
                        End If
                    End If

                    'End If
                Catch ex As Exception

                End Try







            Catch ex As Exception
                ClsGen.Escribir_Log("Problemas Pedido " & pdr.Item("numero_pedido"))
            End Try



        Catch ex As Exception

        End Try

    End Sub

    '01/10/2024 (c)
    Public Sub generarConteo_Consignacion_Azzure(pdr As DataRow, ByRef psNumeroPedido As String, ByRef psTipoDocumento As String, ByRef dtDetalle As DataTable)
        '-
        Dim lsSQL As String
        Dim dtValidacion, dtAux As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim oFlex As New Umbral_Flex.consignaciones

        Dim lsCliente As String

        Try
            lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & pdr.Item("cod_pedido").ToString
            dtDetalle = ClsGen.selectQuery("RegionalDB", lsSQL)
            dtDetalle.TableName = "pedidos_detalle"

            Dim ods As New DataSet
            ods.Tables.Add(dtDetalle.Copy)
            psNumeroPedido = ""
            psTipoDocumento = ""
            lsCliente = ""

            Try
                '(c) le cambio estado para que no se duplique el proceso
                lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',33,'',''"
                ClsGen.insertQuery("RegionalDB", lsSQL)

                pdr.Item("comentarios") = "AZ " & pdr.Item("comentarios").ToString 'Identifico que viene de azzure.



                If oFlex.generarDocumentosConsignacionesTenant(dtDetalle.DefaultView, pdr, psNumeroPedido, psTipoDocumento, False) Then

                    '    If Hacer_Pedido_Clase_Web(ods, pdr.Item("numero_pedido"), pdr, psNumeroPedido, psTipoDocumento, lsCliente, True) Then
                    lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',12,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                    ClsGen.insertQuery("RegionalDB", lsSQL)
                End If


                '(c) 20230217 - Se proceda el PEDIDO FEL

                '265324 unisuper
                '2968550 vinoteca premium
                '20230810 (c) La Incondicional Interempresa

                Try

                    If pdr.Item("ctacte").ToString.Equals("2968550") Or
                                    pdr.Item("ctacte").ToString.StartsWith("265324") Or
                                    pdr.Item("listaprecios").ToString.StartsWith("2)_UNISUPER") Or
                                    pdr.Item("ctacte").ToString = "2968550" Or
                                    pdr.Item("ctacte").ToString = "11878454" Then

                        dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdr.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                        If dtValidacion.Rows.Count > 0 Then
                            If dtValidacion.Rows(0).Item("cliente") = "2968550" Or 'Vintoeca Premium
                                           dtValidacion.Rows(0).Item("cliente") = "11878454" Or
                                            dtValidacion.Rows(0).Item("codlegal") = "2653247-6" Then 'Unisuper


                                If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                            psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                                (pdr.Item("empresa").ToString = "DMARTE1" Or
                                                 pdr.Item("empresa").ToString = "DIUVA" Or
                                                 pdr.Item("empresa").ToString = "CODICASA" Or
                                                 pdr.Item("empresa").ToString = "VINOTECA") Then


                                    '(c) 20220809
                                    Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                    Dim lsBodega As String

                                    If slCedi.Length = 0 Then
                                        lsBodega = "CD_CENTRAL"
                                        '(c) 20231019 Bodega de donde seleccionaron, por el momento solo para unisuper
                                        If dtValidacion.Rows(0).Item("codlegal") = "2653247-6" And dtValidacion.Rows(0).Item("bodega").ToString.Length > 0 Then
                                            lsBodega = dtValidacion.Rows(0).Item("bodega").ToString
                                        End If
                                    Else
                                        dtAux = Nothing
                                        dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdr.Item("empresa").ToString & "'")
                                        If dtAux.Rows.Count = 1 Then
                                            lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                        Else
                                            'Problema con los cedis
                                            'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                            Exit Try
                                        End If
                                    End If

                                    '(c) 20250319 
                                    Dim lsUsuariograbo As String = "root"
                                    Try
                                        lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                    Catch ex As Exception

                                    End Try

                                    generarPedidoFACEAutomatico_cedi(pdr.Item("empresa").ToString,
                                                                        psTipoDocumento,
                                                                        psNumeroPedido, lsBodega,
                                                                        slCedi, lsUsuariograbo, "sincronizacion.recepcion_informacion_pda")
                                End If
                            End If
                        End If
                    End If

                Catch ex As Exception
                End Try




            Catch ex As Exception
                ClsGen.Escribir_Log("Problemas Pedido " & pdr.Item("numero_pedido"))
            End Try



        Catch ex As Exception

        End Try

    End Sub


    Public Sub generarsolicitudConsignacion_Azzure(pdr As DataRow, ByRef psNumeroPedido As String, ByRef psTipoDocumento As String, ByRef dtDetalle As DataTable)

        Dim lsSQL As String
        Dim dtValidacion, dtAux As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim oFlex As New Umbral_Flex.consignaciones

        Dim lsCliente As String

        Try
            lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & pdr.Item("cod_pedido").ToString
            dtDetalle = ClsGen.selectQuery("RegionalDB", lsSQL)
            dtDetalle.TableName = "pedidos_detalle"

            Dim ods As New DataSet
            ods.Tables.Add(dtDetalle.Copy)
            psNumeroPedido = ""
            psTipoDocumento = ""
            lsCliente = ""

            Try
                '(c) le cambio estado para que no se duplique el proceso
                lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',13,'',''"
                ClsGen.insertQuery("RegionalDB", lsSQL)

                pdr.Item("comentarios") = "AZ " & pdr.Item("comentarios").ToString 'Identifico que viene de azzure.

                If oFlex.Crear_Documento_Solicitud_Consignacion(dtDetalle.DefaultView, pdr, psNumeroPedido, psTipoDocumento, False) Then

                    '    If Hacer_Pedido_Clase_Web(ods, pdr.Item("numero_pedido"), pdr, psNumeroPedido, psTipoDocumento, lsCliente, True) Then
                    lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',12,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                    ClsGen.insertQuery("RegionalDB", lsSQL)
                End If


                '(c) 20230217 - Se proceda el PEDIDO FEL

                '265324 unisuper
                '2968550 vinoteca premium
                '20230810 (c) La Incondicional Interempresa

                Try

                    If pdr.Item("ctacte").ToString.Equals("2968550") Or
                                    pdr.Item("ctacte").ToString.StartsWith("265324") Or
                                    pdr.Item("listaprecios").ToString.StartsWith("2)_UNISUPER") Or
                                    pdr.Item("ctacte").ToString = "2968550" Or
                                    pdr.Item("ctacte").ToString = "11878454" Then

                        dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdr.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                        If dtValidacion.Rows.Count > 0 Then
                            If dtValidacion.Rows(0).Item("cliente") = "2968550" Or 'Vintoeca Premium
                                           dtValidacion.Rows(0).Item("cliente") = "11878454" Or
                                            dtValidacion.Rows(0).Item("codlegal") = "2653247-6" Then 'Unisuper


                                If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                            psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                                (pdr.Item("empresa").ToString = "DMARTE1" Or
                                                 pdr.Item("empresa").ToString = "DIUVA" Or
                                                 pdr.Item("empresa").ToString = "CODICASA" Or
                                                 pdr.Item("empresa").ToString = "VINOTECA") Then


                                    '(c) 20220809
                                    Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                    Dim lsBodega As String

                                    If slCedi.Length = 0 Then
                                        lsBodega = "CD_CENTRAL"
                                        '(c) 20231019 Bodega de donde seleccionaron, por el momento solo para unisuper
                                        If dtValidacion.Rows(0).Item("codlegal") = "2653247-6" And dtValidacion.Rows(0).Item("bodega").ToString.Length > 0 Then
                                            lsBodega = dtValidacion.Rows(0).Item("bodega").ToString
                                        End If
                                    Else
                                        dtAux = Nothing
                                        dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdr.Item("empresa").ToString & "'")
                                        If dtAux.Rows.Count = 1 Then
                                            lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                        Else
                                            'Problema con los cedis
                                            'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                            Exit Try
                                        End If
                                    End If

                                    '(c) 20250319 
                                    Dim lsUsuariograbo As String = "root"
                                    Try
                                        lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                    Catch ex As Exception

                                    End Try
                                    generarPedidoFACEAutomatico_cedi(pdr.Item("empresa").ToString,
                                                                        psTipoDocumento,
                                                                        psNumeroPedido, lsBodega,
                                                                        slCedi, lsUsuariograbo, "Sincronizacion.Recepcion_informacion_pda.generarsolicitudConsignacion_azzure")
                                End If
                            End If
                        End If
                    End If

                Catch ex As Exception
                End Try




            Catch ex As Exception
                ClsGen.Escribir_Log("Problemas Pedido " & pdr.Item("numero_pedido"))
            End Try



        Catch ex As Exception

        End Try

    End Sub


    Public Sub generarPedidoAzzure_to_flexline(pdr As DataRow, ByRef psNumeroPedido As String, ByRef psTipoDocumento As String, ByRef dtDetalle As DataTable,
                                               ByRef piTamañoComentario As Integer, Optional ByRef psComentarioRechazo As String = "")

        Dim lsSQL As String
        Dim dtValidacion, dtAux As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Dim lsCliente As String

        Try
            lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & pdr.Item("cod_pedido").ToString
            dtDetalle = ClsGen.selectQuery("RegionalDB", lsSQL)
            dtDetalle.TableName = "pedidos_detalle"

            Dim ods As New DataSet
            ods.Tables.Add(dtDetalle.Copy)
            psNumeroPedido = ""
            psTipoDocumento = ""
            lsCliente = ""
            psComentarioRechazo = ""

            Try
                '(c) le cambio estado para que no se duplique el proceso
                lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',3,'',''"
                ClsGen.insertQuery("RegionalDB", lsSQL)


                pdr.Item("comentarios") = "AZ " & pdr.Item("comentarios").ToString 'Identifico que viene de azzure
                If Hacer_Pedido_Clase_Web(ods, pdr.Item("numero_pedido"), pdr, psNumeroPedido, psTipoDocumento, lsCliente, True, piTamañoComentario, psComentarioRechazo) Then
                    lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdr.Item("cod_pedido").ToString & ",'" & pdr.Item("empresa").ToString & "',2,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                    ClsGen.insertQuery("RegionalDB", lsSQL)
                End If


                '(c) 20230217 - Se proceda el PEDIDO FEL

                '265324 unisuper
                '2968550 vinoteca premium
                '20230810 (c) La Incondicional Interempresa

                Try
                    If True Then
                        If pdr.Item("ctacte").ToString.Equals("2968550") Or
                                    pdr.Item("ctacte").ToString.StartsWith("265324") Or
                                    pdr.Item("listaprecios").ToString.StartsWith("2)_UNISUPER") Or
                                    pdr.Item("ctacte").ToString = "2968550" Or
                                    pdr.Item("ctacte").ToString = "11878454" Then
                            '203265207

                            dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdr.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                            If dtValidacion.Rows.Count > 0 Then
                                If dtValidacion.Rows(0).Item("cliente") = "2968550" Or 'Vintoeca Premium
                                           dtValidacion.Rows(0).Item("cliente") = "11878454" Or
                                            dtValidacion.Rows(0).Item("codlegal") = "2653247-6" Then 'Unisuper


                                    If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                            psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                                (pdr.Item("empresa").ToString = "DMARTE1" Or
                                                 pdr.Item("empresa").ToString = "DIUVA" Or
                                                 pdr.Item("empresa").ToString = "CODICASA" Or
                                                 pdr.Item("empresa").ToString = "VINOTECA") Then

                                        'If lsTipoDocumento.StartsWith("PEDIDO AL CREDITO") And dr.Item("CTACTE").ToString.StartsWith("2653248") Then
                                        '(c) 20220809
                                        Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                        Dim lsBodega As String

                                        If slCedi.Length = 0 Then
                                            lsBodega = "CD_CENTRAL"
                                            '(c) 20231019 Bodega de donde seleccionaron, por el momento solo para unisuper
                                            If dtValidacion.Rows(0).Item("codlegal") = "2653247-6" And dtValidacion.Rows(0).Item("bodega").ToString.Length > 0 Then

                                                lsBodega = dtValidacion.Rows(0).Item("bodega").ToString


                                            End If



                                        Else
                                            dtAux = Nothing

                                            dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdr.Item("empresa").ToString & "'")
                                            If dtAux.Rows.Count = 1 Then
                                                lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                            Else
                                                'Problema con los cedis
                                                'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                                Exit Try
                                            End If
                                        End If

                                        '(c) 20250319 
                                        'Dim lsUsuariograbo As String = "root"
                                        'Try
                                        '    lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                        'Catch ex As Exception

                                        'End Try
                                        'If lsUsuariograbo.Length = 0 Then
                                        '    lsUsuariograbo = "ROOT"
                                        'End If


                                        generarPedidoFACEAutomatico_cedi(pdr.Item("empresa").ToString,
                                                                        psTipoDocumento,
                                                                        psNumeroPedido, lsBodega,
                                                                        slCedi, "ROOT", "Sincronizacion.Recepcion_Informacion_PDA.generarPedidoAzzure_to_flexline")




                                    End If
                                End If
                            End If
                        Else
                            '(c) 20250804 Facturación Automatica
                            Try
                                If Hour(Now()) > 4 And Hour(Now()) < 20 Then

                                    If (pdr.Item("empresa").ToString = "DMARTE1" Or
                                     pdr.Item("empresa").ToString = "DIUVA" Or
                                     pdr.Item("empresa").ToString = "CODICASA") Then



                                        dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdr.Item("Empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                                        If dtValidacion.Rows.Count > 0 Then

                                            If dtValidacion.Rows(0).Item("facturar_pedido_automatico").ToString.ToUpper = "S" Then


                                                '(c) 20220809
                                                Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                                Dim lsBodega As String

                                                If slCedi.Length = 0 Then
                                                    lsBodega = "CD_CENTRAL"
                                                Else
                                                    dtAux = Nothing

                                                    dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdr.Item("empresa").ToString & "'")
                                                    If dtAux.Rows.Count = 1 Then
                                                        lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                                    Else
                                                        'Problema con los cedis
                                                        'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                                        Exit Try
                                                    End If
                                                End If


                                                '(c) 20250319 
                                                Dim lsUsuariograbo As String = String.Empty
                                                Try
                                                    lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                                Catch ex As Exception

                                                End Try
                                                If lsUsuariograbo.Length = 0 Then
                                                    lsUsuariograbo = "root"
                                                End If

                                                generarPedidoFACEAutomatico_cedi(pdr.Item("empresa").ToString,
                                                                                psTipoDocumento,
                                                                                psNumeroPedido, lsBodega,
                                                                                slCedi, lsUsuariograbo, "Sincronizacion.Recepcion_informacion_PDA.generarPedidoAzzure_to_flexline")



                                            End If

                                        End If
                                    End If
                                End If


                            Catch ex As Exception

                            End Try


                        End If
                    End If
                Catch ex As Exception

                End Try







            Catch ex As Exception
                ClsGen.Escribir_Log("Problemas Pedido " & pdr.Item("numero_pedido"))
            End Try



        Catch ex As Exception

        End Try

    End Sub


    Public Sub generarPedidoCorporativo_to_flexline(pdrEncabezado As DataRow, ByRef psNumeroPedido As String, ByRef psTipoDocumento As String,
                                                    ByRef dtDetalle As DataTable, Optional ByRef piCaracteresComentario As Integer = 75, Optional ByRef psComentarioRechazo As String = "")

        Dim lsSQL As String
        Dim dtValidacion, dtAux As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Dim lsCliente As String

        Try
            lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & pdrEncabezado.Item("cod_pedido").ToString
            dtDetalle = ClsGen.selectQuery("corporativo", lsSQL)
            dtDetalle.TableName = "pedidos_detalle"

            Dim ods As New DataSet
            ods.Tables.Add(dtDetalle.Copy)
            psNumeroPedido = ""
            psTipoDocumento = ""
            lsCliente = ""
            psComentarioRechazo = ""

            Try

                'Cambio el estado del pedido para que solo sea un proceso unico
                lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdrEncabezado.Item("cod_pedido").ToString & ",'" & pdrEncabezado.Item("empresa").ToString & "',3,'',''"
                ClsGen.insertQuery("corporativo", lsSQL)

                ''Verificar pedido Costo
                If dtDetalle.Rows(0).Item("centro_costo").ToString.Trim.Length > 0 Then
                    If Hacer_Pedido_Clase_WebCosto(ods, pdrEncabezado.Item("numero_pedido"), pdrEncabezado, psNumeroPedido, psTipoDocumento) Then
                        lsSQL = "pa_upd_um_mov_pedidos_encabezado " & pdrEncabezado.Item("cod_pedido").ToString & ",'" & pdrEncabezado.Item("empresa").ToString & "',2,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                        ClsGen.insertQuery("corporativo", lsSQL)
                        ''(c) Almaceno en la tabla de las solicitudes

                        ClsGen.insertQuery("SCM", "pa_upd_facturacion_autoconsumo_operado_flex " & pdrEncabezado.Item("cod_pedido").ToString & ",'" & psTipoDocumento & "','" & psNumeroPedido & "'")


                    End If
                Else
                    If Hacer_Pedido_Clase_Web(ods, pdrEncabezado.Item("numero_pedido"), pdrEncabezado, psNumeroPedido, psTipoDocumento, lsCliente, False, piCaracteresComentario, psComentarioRechazo) Then
                        lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdrEncabezado.Item("cod_pedido").ToString & ",'" & pdrEncabezado.Item("empresa").ToString & "',2,'" &
                                        psTipoDocumento & "','" & psNumeroPedido & "'"
                        ClsGen.insertQuery("corporativo", lsSQL)
                    Else 'Si no logro procesarlo lo regreso al estado Original

                        lsSQL = " pa_upd_um_mov_pedidos_encabezado " & pdrEncabezado.Item("cod_pedido").ToString & ",'" & pdrEncabezado.Item("empresa").ToString & "',1,'',''"
                        ClsGen.insertQuery("corporativo", lsSQL)
                        ClsGen.enviarMensajeTeams("carlos.oscal@umbralcorp.com", "Error al procesar Pedido Corporativo",
                                                  "Empresa : " & pdrEncabezado.Item("empresa") & "|" &
                                                  "cliente : " & pdrEncabezado.Item("ctacte") & "|" &
                                                  "Monto : " & pdrEncabezado.Item("total_pedido") & "|" &
                                                  "Usuario Grabo : " & pdrEncabezado.Item("usuario_grabo") & "|" &
                                                  "comentarios : " & pdrEncabezado.Item("comentarios") & "|")

                        ClsGen.enviarMensajeTeams("geancarlo.velasquez@umbralcorp.com", "Error al procesar Pedido Corporativo",
                          "Empresa : " & pdrEncabezado.Item("empresa") & "|" &
                          "cliente : " & pdrEncabezado.Item("ctacte") & "|" &
                          "Monto : " & pdrEncabezado.Item("total_pedido") & "|" &
                          "Usuario Grabo : " & pdrEncabezado.Item("usuario_grabo") & "|" &
                          "comentarios : " & pdrEncabezado.Item("comentarios") & "|")
                    End If
                End If

                '(c) 20230217 - Se proceda el PEDIDO FEL

                '265324 unisuper
                '2968550 vinoteca premium
                '20230810 (c) La Incondicional Interempresa

                Try
                    '(C) 20250703 Validacion de Autoconsumo AUTOMATICO
                    If psTipoDocumento.Contains("AUTOCONSUMO") Then

                        If (pdrEncabezado.Item("empresa").ToString = "DMARTE1" Or
                                                pdrEncabezado.Item("empresa").ToString = "DIUVA" Or
                                                pdrEncabezado.Item("empresa").ToString = "CODICASA") Then

                            dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdrEncabezado.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                            If dtValidacion.Rows.Count > 0 Then

                                Dim lsCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                Dim lsBodega As String = dtValidacion.Rows(0).Item("bodega").ToString '(c) 20250703 Se toma la bodega del pedido autoconsumo
                                Dim dt As DataTable
                                Dim lbProcesar As Boolean = False

                                '(c) 20250703 Debo validar que la bodega exista en el CEDI


                                lsSQL = "exec pa_um_sel_sg_usuario_empresas_tekne_av_usuario '" & pdrEncabezado.Item("empresa").ToString & "','" & dtValidacion.Rows(0).Item("usuariomodif").ToString & "','Ventas_BodegaPedido'"
                                dt = ClsGen.selectQuery("RegionalDBintOut", lsSQL)

                                dt.DefaultView.RowFilter = "DisplayCombobox = '" & IIf(lsCedi = "", "CD_CENTRAL", lsCedi) & "'"
                                For Each drv As DataRowView In dt.DefaultView
                                    If drv.Item("ValueCombobox").ToString = lsBodega Then
                                        lbProcesar = True
                                        Exit For
                                    End If
                                Next

                                'dt.TableName = "bodegas_facturar"


                                '(c) 20250319 
                                If lbProcesar Then
                                    Dim lsUsuariograbo As String = "ROOT"




                                    generarPedidoFACEA_AUTOCONSUMOAutomatico_cedi(pdrEncabezado.Item("empresa").ToString,
                                                                                psTipoDocumento,
                                                                                psNumeroPedido, lsBodega,
                                                                                lsCedi, lsUsuariograbo, "Sincronizacion.Recepcion_Informacion_PDA.generarPedidoCorporativo_to_flexline")



                                    'generarPedidoFACEAutomatico_cedi(pdrEncabezado.Item("empresa").ToString,
                                    '                                            psTipoDocumento,
                                    '                                            psNumeroPedido, lsBodega,
                                    '                                            lsCedi, lsUsuariograbo, "Sincronizacion.Recepcion_Informacion_PDA.generarPedidoCorporativo_to_flexline")


                                End If


                            End If




                        End If




                    ElseIf pdrEncabezado.Item("ctacte").ToString.Equals("2968550") Or
                                        pdrEncabezado.Item("ctacte").ToString.StartsWith("265324_") Or
                                        pdrEncabezado.Item("listaprecios").ToString.StartsWith("2)_UNISUPER_") Or
                                        pdrEncabezado.Item("ctacte").ToString = "2968550_" Or
                                        pdrEncabezado.Item("ctacte").ToString.StartsWith("11878454") Then
                        '203265207

                        dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdrEncabezado.Item("empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                        If dtValidacion.Rows.Count > 0 Then
                            If dtValidacion.Rows(0).Item("cliente") = "2968550" Or 'Vintoeca Premium
                                               dtValidacion.Rows(0).Item("cliente").ToString.StartsWith("11878454") Or 'la incondicional
                                                dtValidacion.Rows(0).Item("codlegal") = "2653247-6" Then 'Unisuper


                                If (psTipoDocumento.StartsWith("PEDIDO AL CONTADO") Or
                                                psTipoDocumento.StartsWith("PEDIDO AL CREDITO")) And
                                                    (pdrEncabezado.Item("empresa").ToString = "DMARTE1" Or
                                                     pdrEncabezado.Item("empresa").ToString = "DIUVA" Or
                                                     pdrEncabezado.Item("empresa").ToString = "CODICASA" Or
                                                     pdrEncabezado.Item("empresa").ToString = "VINOTECA") Then

                                    'If lsTipoDocumento.StartsWith("PEDIDO AL CREDITO") And dr.Item("CTACTE").ToString.StartsWith("2653248") Then
                                    '(c) 20220809
                                    Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                    Dim lsBodega As String

                                    If slCedi.Length = 0 Then
                                        lsBodega = "CD_CENTRAL"
                                    Else
                                        dtAux = Nothing

                                        dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdrEncabezado.Item("empresa").ToString & "'")
                                        If dtAux.Rows.Count = 1 Then
                                            lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                        Else
                                            'Problema con los cedis
                                            'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                            Exit Try
                                        End If
                                    End If


                                    '(c) 20250319 
                                    Dim lsUsuariograbo As String = "ROOT"
                                    Try
                                        lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                    Catch ex As Exception

                                    End Try
                                    If lsUsuariograbo.Length = 0 Then
                                        lsUsuariograbo = "ROOT"
                                    End If




                                    generarPedidoFACEAutomatico_cedi(pdrEncabezado.Item("empresa").ToString,
                                                                            psTipoDocumento,
                                                                            psNumeroPedido, lsBodega,
                                                                            slCedi, lsUsuariograbo, "Sincronizacion.Recepcion_Informacion_PDA.generarPedidoCorporativo_to_flexline")




                                End If
                            End If
                        End If
                    Else
                        '(c) 20250804 Facturación Automatica
                        Try
                            If Hour(Now()) > 4 And Hour(Now()) < 20 Then

                                If (pdrEncabezado.Item("empresa").ToString = "DMARTE1" Or
                                     pdrEncabezado.Item("empresa").ToString = "DIUVA" Or
                                     pdrEncabezado.Item("empresa").ToString = "CODICASA") Then



                                    dtValidacion = ClsGen.selectQuery("FlexLine", "pa_var_um_documento '" & pdrEncabezado.Item("Empresa").ToString & "','" & psTipoDocumento & "','" & psNumeroPedido & "'")
                                    If dtValidacion.Rows.Count > 0 Then

                                        If dtValidacion.Rows(0).Item("facturar_pedido_automatico").ToString.ToUpper = "S" Then


                                            '(c) 20220809
                                            Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                            Dim lsBodega As String

                                            If slCedi.Length = 0 Then
                                                lsBodega = "CD_CENTRAL"
                                            Else
                                                dtAux = Nothing

                                                dtAux = ClsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & pdrEncabezado.Item("empresa").ToString & "'")
                                                If dtAux.Rows.Count = 1 Then
                                                    lsBodega = dtAux.Rows(0).Item("descripcion").ToString
                                                Else
                                                    'Problema con los cedis
                                                    'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                                    Exit Try
                                                End If
                                            End If


                                            '(c) 20250319 
                                            Dim lsUsuariograbo As String = String.Empty
                                            Try
                                                lsUsuariograbo = ClsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                            Catch ex As Exception

                                            End Try
                                            If lsUsuariograbo.Length = 0 Then
                                                lsUsuariograbo = "ROOT"
                                            End If

                                            generarPedidoFACEAutomatico_cedi(pdrEncabezado.Item("empresa").ToString,
                                                                                psTipoDocumento,
                                                                                psNumeroPedido, lsBodega,
                                                                                slCedi, lsUsuariograbo, "Sincronizacion.Recepcion_Informacion_PDA.generarPedidoCorporativo_to_flexline")



                                        End If

                                    End If
                                End If
                            End If


                        Catch ex As Exception

                        End Try

                    End If

                Catch ex As Exception

                End Try







            Catch ex As Exception
                ClsGen.Escribir_Log("Problemas Pedido " & pdrEncabezado.Item("numero_pedido"))
            End Try



        Catch ex As Exception

        End Try

    End Sub

    Public Sub generarPedidoFACEAutomatico_cedi(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, psBodega As String, psCedi As String, psUsuarioGrabo As String, pdSistemaEjecuta As String)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        'Dim lsNumeroGenerado As String
        'Dim gs_usuario As String
        Dim plDescuento As Double = 0
        Dim plmontoMinimo As Double = 0

        Try
            'gs_usuario = clsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
            'lsSQL = "pa_ins_um_pedido_FACE_automatico '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "'"
            '(c) 20220908
            If True Then


                'lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & gs_usuario & "','" & psBodega & "','" & psCedi & "'"


                '(c) 20241107
                lsSQL = "pa_ins_um_pedido_FACE_automatico_cedi_descuento_porcentaje_asignado_minimo '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & psUsuarioGrabo & "','" & psBodega & "','" & psCedi & "'," & plDescuento & "," & plmontoMinimo
                dt = clsGen.selectQuery("FlexLine", lsSQL)
                If dt.Rows.Count > 0 Then
                    clsGen.Escribir_Log("Se Genero el Documento " & psEmpresa & " - - " & dt.Rows(0).Item("TipoDocto").ToString & " - -" & dt.Rows(0).Item("numero").ToString)

                Else
                    'MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                lsSQL = "pa_ins_um_gen_log_documento_emision '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & psUsuarioGrabo & "','" & Today.ToShortDateString & "'"
                clsGen.insertQuery("Flexline", lsSQL)

            End If

            '(c) 20230823
            'Se llenerá una tabla para que sea SQL quien geneere el Pedido FEL automatico




        Catch ex As Exception
            Try
                clsGen.Escribir_Log("El Proceso Genero Error " & psEmpresa & "','" & psTipoDocto & "','" & psNumero)
            Catch ex2 As Exception

            End Try

        Finally

            Try
                'lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','" & dt.Rows(0).Item("TipoDocto").ToString & "','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                ''lsSQL = "pa_var_valida_documento_completo '" & psEmpresa & "','PEDIDO FEL','" & dt.Rows(0).Item("numero").ToString.PadLeft(10, "0") & "'"
                'dt = clsGen.selectQuery("FlexLine", lsSQL)

                'If dt.Rows.Count = 0 Then
                '    clsGen.Escribir_Log(lsSQL)
                '    clsGen.Escribir_Log("El Proceso Genero Error, Generarlo en FlexLine")
                'End If
            Catch ex As Exception
                'eliminar el documento
            End Try


            clsGen = Nothing
        End Try
    End Sub

    Public Sub generarPedidoFACEA_AUTOCONSUMOAutomatico_cedi(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, psBodega As String, psCedi As String, psUsuarioGrabo As String, pdSistemaEjecuta As String)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        'Dim lsNumeroGenerado As String
        'Dim gs_usuario As String
        Dim plDescuento As Double = 0
        Dim plmontoMinimo As Double = 0

        Try
            lsSQL = "VAL_pa_ins_um_pedido_FACE_automatico_cedi_descuento_porcentaje_asignado_minimo_autoconsumo '" &
                        psEmpresa & "','" & psTipoDocto & "','" & psNumero & "','" & psUsuarioGrabo & "','" & psBodega & "','" & psCedi & "'," & plDescuento & "," & plmontoMinimo
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then
                clsGen.Escribir_Log("Se Genero el Documento " & psEmpresa & " - - " & dt.Rows(0).Item("TipoDocto").ToString & " - -" & dt.Rows(0).Item("numero").ToString)

            Else
                'MessageBox.Show("El Proceso Genero Error, Generarlo en FlexLine", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If





        Catch ex As Exception
            Try
                clsGen.Escribir_Log("El Proceso Genero Error " & psEmpresa & "','" & psTipoDocto & "','" & psNumero)
            Catch ex2 As Exception

            End Try

        Finally



            clsGen = Nothing
        End Try
    End Sub



    Private Function Hacer_Pedido_Clase_Web(ByVal ods As DataSet, ByVal _NumeroPedido As String, ByVal dr_encabezado As DataRow,
                 ByRef pNumeroPedido As String, ByRef pTipoDocumento As String, ByRef pCodigoCliente As String, Optional ByVal aplicarBodegaPedido As Boolean = vbFalse,
                 Optional ByRef piCaracteresComentario As Integer = 27, Optional ByRef psComentarioRechazo As String = "") As Boolean

        Dim Oflex As New Umbral_Flex.Pedidos
        Dim dr, ofila As DataRow
        Dim li_linea As Integer = 0
        Dim ls_pedido_generado As Integer = 0
        Dim condiciones As String()
        Dim s_empresa As String = String.Empty
        Dim proceso_exitoso As Boolean = False
        Dim pd_total_pedido As Double = 0
        Dim forma_pago As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        psComentarioRechazo = String.Empty '(c) 20250901 


        Try




            Oflex.Limpiar_Datos()
            s_empresa = dr_encabezado.Item("empresa").ToString
            forma_pago = dr_encabezado.Item("forma_pago").ToString

            Llenar_Auxiliares(ods, dr_encabezado.Item("ctacte"), s_empresa)
            If dr_encabezado.Item("forma_pago").ToString.Length = 0 Then
                forma_pago = ods.Tables("FlexLine_Clientes").Rows(0).Item("CondPago")
            End If



            Try
                pCodigoCliente = ods.Tables("flexline_clientes").Rows(0).Item("ctacte")
            Catch ex As Exception

            End Try
            ''filtrando informacion de las condiciones de pago
            ods.Tables("flexline_condiciones").DefaultView.RowFilter = "DESCRIPCION = '" & forma_pago & "'"

            ''Encabezado
            dr = Oflex.ods.Tables("encabezado").NewRow

            dr.Item("empresa") = s_empresa
            dr.Item("tipodocto") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto")
            dr.Item("numero") = ""
            dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
            dr.Item("codigo") = ods.Tables("flexline_clientes").Rows(0).Item("ctacte")
            dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
            condiciones = ods.Tables("flexline_condiciones").DefaultView(0).Item("VALOR1").ToString.Split(".")
            dr.Item("diascredito") = condiciones(0).ToString
            dr.Item("listaprecio") = dr_encabezado.Item("listaprecios").ToString
            pd_total_pedido = dr_encabezado.Item("total_pedido").ToString
            dr.Item("total") = pd_total_pedido
            dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
            dr.Item("aprobacion") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto2")
            dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")

            dr.Item("comentario1") = "PDA-" & dr_encabezado.Item("comentarios").ToString '& " No. " & dr_encabezado.Item("numero").ToString

            If s_empresa <> "DIMAEXSA" Then
                dr.Item("comentario1") = dr.Item("comentario1").ToString.PadRight(piCaracteresComentario, " ").Substring(0, piCaracteresComentario)
            End If

            dr.Item("comentario1") = dr.Item("comentario1").ToString.TrimEnd

            If aplicarBodegaPedido Then
                dr.Item("bodega") = dr_encabezado.Item("bodega").ToString
            End If
            ''Verifico la aprobacion de los pedidos

            ''Verifico la aprobacion de los pedidos
            If Trim(dr.Item("aprobacion")) <> "S" Then

                Try
                    Dim Otrans As New Transaccional.Conexion("FlexLine")
                    Dim ls_tipo As String = "SYSGOLD_GRUPOS"
                    Dim oTabla As DataTable

                    Dim ls_codigo As String = ods.Tables("flexline_clientes").Rows(0).Item("grupo")

                    Dim ls_Query As String = "flexline.pa_sel_um_gen_tabcod NULL" & ",'" & ls_tipo & "','" & dr.Item("empresa") & "'"

                    Otrans.open()

                    oTabla = Otrans.Obtiene(ls_Query)
                    oTabla.DefaultView.RowFilter = "descripcion  = '" & ls_codigo & "'"

                    If oTabla.DefaultView.Count > 0 Then
                        dr.Item("aprobacion") = oTabla.DefaultView(0).Item("texto1")
                    End If


                    Otrans.close()
                    Otrans = Nothing

                Catch ex As Exception
                End Try


                Try
                    If s_empresa.ToUpper <> "VINOTECA" Then
                        If s_empresa.ToUpper <> "DIMAEXSA" Then '01/10/2014 Verifica la Informacion de todas las empresas


                            If Trim(dr.Item("aprobacion")) <> "S" Then
                                Dim lsSQL As String
                                lsSQL = "flexline.sp_Balances_ISF '" & dr.Item("empresa") & "','" &
                                                ods.Tables("flexline_clientes").Rows(0).Item("ctacte") & "','" &
                                                Today.ToString("dd-MM-yyyy") & "'"

                                Dim dtAux As DataTable
                                dtAux = clsGen.selectQuery("FlexLine", lsSQL)
                                'lsSQL = "flexline.pa_ins_um_gen_log_documento '"& dr.Item("empresa") & "','" & _
                                If dtAux.Rows.Count = 0 Then 'No tiene Documentos Pendientes
                                    dr.Item("aprobacion") = "S"
                                    dr.Item("comuna") = "***Analisis Aprobado No tiene Documentos Pendientes**"
                                Else
                                    Dim dSaldo As Double = 0
                                    dSaldo = dtAux.Compute("sum(saldo)", "saldo<>0") ''Saldo Total
                                    If dSaldo = 0 Then
                                        If pd_total_pedido > ods.Tables("flexline_clientes").Rows(0).Item("LimiteCredito") Then
                                            dr.Item("comentario1") = dr.Item("comentario1") & " ***Analisis Rechazado Sobrepasa Limite de Credito"
                                            psComentarioRechazo = "Sobrepasa Limite de Credito" '(c) 20250901"    
                                        Else
                                            dr.Item("aprobacion") = "S"
                                            dr.Item("comuna") = " ***Analisis Aprobado Sin Saldo Pendiente **"
                                        End If
                                    ElseIf dSaldo + pd_total_pedido > ods.Tables("flexline_clientes").Rows(0).Item("LimiteCredito") Then

                                        dr.Item("comentario1") = dr.Item("comentario1") & " ***Analisis Rechazado Sobrepasa Limite de Credito"
                                        psComentarioRechazo = "Sobrepasa Limite de Credito"
                                    Else
                                        Try

                                            dSaldo = dtAux.Compute("sum(saldo)", "dias_factura>15") ''Saldo Vencido + 15 Dias Gracia
                                        Catch ex As Exception
                                            dSaldo = 0

                                        End Try
                                        If dSaldo < 1 Then
                                            'dSaldo = dtAux.Compute("sum(saldo)", "saldo<>0") ''Saldo Total

                                            'Else
                                            dr.Item("aprobacion") = "S" '' No tiene Saldo Vencidos
                                            dr.Item("comuna") = "***Analisis Aprobado Sin Saldo Vencido **"
                                        Else
                                            dr.Item("comentario1") = dr.Item("comentario1") & " ***Analisis Rechazado Facturas Vencidas"
                                            psComentarioRechazo = "Facturas Vencidas"
                                        End If
                                    End If
                                End If
                            End If
                        End If 'Empresa2
                    End If ' Empresa 
                Catch ex As Exception

                End Try
            End If

            dr.Item("periodo") = Trim(Date.Parse(dr.Item("fecha").ToString).ToString("yyyy") + Date.Parse(dr.Item("fecha").ToString).ToString("MM"))
            'dr.Item("direccion") = ods.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
            dr.Item("ciudad") = String.Empty ' ods.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
            'dr.Item("comuna") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
            dr.Item("pais") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
            dr.Item("contacto") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString

            dr.Item("usuario") = dr_encabezado.Item("usuario_grabo").ToString
            dr.Item("direccion") = dr_encabezado.Item("direccion_entrega").ToString.Replace(vbCrLf, " ")



            dr.Item("AnalisisE3") = Date.Parse(dr_encabezado.Item("fecha_entrega").ToString).ToString("dd/MM/yyyy")
            Try
                dr.Item("referenciaExterna") = dr_encabezado.Item("numero_pedido").ToString
            Catch ex As Exception

            End Try


            ''Debo Agregar AnalisisE10 Se utiliza para los pedidos que son interempresas

            Try
                dr.Item("AnalisisE10") = ods.Tables("pedidos_detalle").Rows(0).Item("bodega_interempresas").ToString.ToUpper
            Catch ex As Exception
            End Try

            Try
                dr.Item("AnalisisE21") = dr_encabezado.Item("recoge_bodega").ToString
            Catch ex As Exception

            End Try

            Try
                '(c)20250204 Referencia Punto de Venta
                dr.Item("AnalisisE22") = dr_encabezado.Item("referencia_pdv").ToString
            Catch ex As Exception

            End Try

            Try
                'Dias Despacho
                dr.Item("AnalisisE23") = dr_encabezado.Item("dias_entrega").ToString.Replace("Lunes", "Lu").Replace("Miércoles", "Mi").Replace("Jueves", "Ju").Replace("Martes", "Ma").Replace("Viernes", "Vi").Replace("Sábado", "Sa")
            Catch ex As Exception

            End Try

            Try
                dr.Item("AnalisisE24") = dr_encabezado.Item("horas_entrega").ToString
            Catch ex As Exception

            End Try

            Try
                If dr_encabezado.Item("direccion_entrega").ToString = "" Then
                    'buscar la dirección de entrega del cliente
                    '(c) Pasa con los clientes de vinoteca
                    If dr.Item("codigo").ToString.StartsWith("2968") Then

                        Dim flexCrud As New FlexLine_CRUD.CRM_Dynamics
                        Dim dtDirecciones As DataTable
                        Try
                            dtDirecciones = flexCrud.getDireccionesClientes(dr.Item("codigo"))
                            dtDirecciones.DefaultView.RowFilter = "TipoDireccion = 'Entrega'"
                            'If dtDirecciones.DefaultView.Count = 0 Then
                            '    dtDirecciones.DefaultView.RowFilter = "TipoDireccion = 'Fiscal'"
                            'End If

                            dr.Item("direccion") = dtDirecciones.DefaultView(0).Item("direccion").ToString
                            dr.Item("AnalisisE22") = dtDirecciones.DefaultView(0).Item("nombredireccion").ToString

                        Catch ex As Exception

                        Finally
                            flexCrud = Nothing
                        End Try
                    End If
                End If

            Catch ex As Exception

            End Try


            Oflex.ods.Tables("encabezado").Rows.Add(dr)

            ''Documentop
            dr = Oflex.ods.Tables("documentop").NewRow

            dr.Item("codigopago") = forma_pago
            dr.Item("diascredito") = condiciones(0).ToString
            dr.Item("total") = pd_total_pedido
            dr.Item("cuenta") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto1")
            dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
            Oflex.ods.Tables("documentop").Rows.Add(dr)

            ''DocumentoV
            dr = Oflex.ods.Tables("documentov").NewRow
            dr.Item("total") = pd_total_pedido
            dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
            Oflex.ods.Tables("documentov").Rows.Add(dr)

            ''DocumentoD
            For Each ofila In ods.Tables("pedidos_detalle").Rows
                'li_linea = li_linea + 1
                If ofila.Item("cod_pedido") = dr_encabezado.Item("cod_pedido") Then


                    dr = Oflex.ods.Tables("detalle").NewRow
                    dr.Item("secuencia") = ofila.Item("linea")
                    dr.Item("producto") = ofila.Item("cod_producto_flex")
                    dr.Item("cantidad") = ofila.Item("cantidad")


                    dr.Item("precio") = ofila.Item("precio")
                    dr.Item("total") = ofila.Item("total_linea")

                    dr.Item("diascredito") = condiciones(0).ToString
                    dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
                    dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
                    dr.Item("costo") = 0
                    dr.Item("linea") = ofila.Item("linea")

                    Oflex.ods.Tables("detalle").Rows.Add(dr)
                End If
            Next



            ls_pedido_generado = Oflex.Guardar_PedidoBasico()

            If ls_pedido_generado > 0 Then
                proceso_exitoso = True
                pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
                pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")
            End If

        Catch ex As Exception
        Finally
            Oflex = Nothing

        End Try


        Return proceso_exitoso
    End Function


    Private Function ValidarOrdenesEdi(psEmpresa As String, psNumero As String, ByRef sBody As String) As Boolean
        Dim clsGen As New ClasesGenerales.General
        Dim dtEdi As DataTable
        Dim dtPedido As DataTable
        Dim lsSQL As String
        Dim ldTotalDiferencia As Double = 0
        Dim lbDiferencias As Boolean = False

        Try

            lsSQL = "pa_var_um_pedidos_walmart_detalle_pedido '" & psEmpresa & "','PEDIDO WALMART','" & psNumero & "'"
            dtPedido = clsGen.selectQuery("FlexLine", lsSQL)

            lsSQL = "call pa_var_um_edi_pedido_precios ('" & psEmpresa & "','PEDIDO AL CREDITO'" &
                            ",'" & psNumero & "')"

            dtEdi = clsGen.selectmyQuery("Onbase", lsSQL)


            For Each drv As DataRowView In dtPedido.DefaultView
                dtEdi.DefaultView.RowFilter = "codigoFlex = '" & drv.Item("producto").ToString & "'"
                If dtEdi.DefaultView.Count > 0 Then
                    drv.Item("precioEdi") = Math.Round(dtEdi.DefaultView(0).Item("costonegociado"), 2, MidpointRounding.AwayFromZero)
                    drv.Item("precioEdi_iva") = Math.Round(drv.Item("precioEdi") * 1.12, 2, MidpointRounding.AwayFromZero)

                    drv.Item("diferencia") = Math.Abs(drv.Item("precio") - drv.Item("precioEdi_iva"))
                    ldTotalDiferencia += drv.Item("diferencia") * drv.Item("cantidad")
                End If
            Next


            If ldTotalDiferencia > 20 Then
                sBody = sBody & "</tr><tr>"
                sBody = sBody & "<td>***Diferencias *** </td><td>" & Math.Round(ldTotalDiferencia, 2, MidpointRounding.AwayFromZero) & "</td>"
                sBody = sBody & "</tr><tr>"
                sBody = sBody & "<td>Diferencia Total en Orden </td><td>" & Math.Round(ldTotalDiferencia, 2, MidpointRounding.AwayFromZero) & "</td>"
                sBody = sBody & "</tr><tr>"
                dtPedido.DefaultView.RowFilter = "diferencia > 0"
                sBody = sBody & "<td>Diferencias</td>"

                For Each drv As DataRowView In dtPedido.DefaultView
                    sBody = sBody & "</tr><tr><td> </td>"
                    sBody = sBody & "<td>" & drv.Item("producto") & "-" & drv.Item("glosa") & "</td>"
                    sBody = sBody & "<td>Precio Edi " & drv.Item("precioEdi_iva") & "</td>"
                    sBody = sBody & "<td>Precio Flex" & drv.Item("precio") & "</td>"

                Next
                'sBody = sBody & "</tr>"

            End If


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
        Return lbDiferencias
    End Function

    Private Function Hacer_Pedido_Clase_WebCosto(ByVal ods As DataSet, ByVal _NumeroPedido As String, ByVal dr_encabezado As DataRow,
                 ByRef pNumeroPedido As String, ByRef pTipoDocumento As String) As Boolean

        Dim Oflex As New Umbral_Flex.Pedidos
        Dim dr, ofila As DataRow
        Dim li_linea As Integer = 0
        Dim ls_pedido_generado As Integer = 0
        Dim condiciones As String()
        Dim s_empresa As String = String.Empty
        Dim proceso_exitoso As Boolean = False
        Dim pd_total_pedido As Double = 0
        Dim forma_pago As String = String.Empty
        'pTipoDocumento = "PEDIDO AL COSTO"
        pTipoDocumento = "PEDIDO AUTOCONSUMO"



        Oflex.Limpiar_Datos()
        s_empresa = dr_encabezado.Item("empresa").ToString
        forma_pago = dr_encabezado.Item("forma_pago").ToString

        Llenar_Auxiliares(ods, dr_encabezado.Item("ctacte"), s_empresa)
        If dr_encabezado.Item("forma_pago").ToString.Length = 0 Then
            forma_pago = ods.Tables("FlexLine_Clientes").Rows(0).Item("CondPago")
        End If


        ''filtrando informacion de las condiciones de pago
        ods.Tables("flexline_condiciones").DefaultView.RowFilter = "DESCRIPCION = '" & forma_pago & "'"

        ''Encabezado
        dr = Oflex.ods.Tables("encabezado").NewRow

        dr.Item("empresa") = s_empresa
        dr.Item("tipodocto") = pTipoDocumento 'ods.Tables("flexline_condiciones").DefaultView(0).Item("texto")
        dr.Item("numero") = ""
        dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
        dr.Item("codigo") = ods.Tables("flexline_clientes").Rows(0).Item("ctacte")
        dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
        condiciones = ods.Tables("flexline_condiciones").DefaultView(0).Item("VALOR1").ToString.Split(".")
        dr.Item("diascredito") = condiciones(0).ToString
        dr.Item("listaprecio") = dr_encabezado.Item("listaprecios").ToString
        pd_total_pedido = dr_encabezado.Item("total_pedido").ToString
        dr.Item("total") = pd_total_pedido
        dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
        dr.Item("aprobacion") = "S" 'ods.Tables("flexline_condiciones").DefaultView(0).Item("texto2")
        dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")

        '(c) 20250611
        Try
            dr.Item("bodega") = dr_encabezado.Item("bodega").ToString
        Catch ex As Exception

        End Try

        ''Verifico la aprobacion de los pedidos
        If Trim(dr.Item("aprobacion")) <> "S" Then

            Try
                Dim Otrans As New Transaccional.Conexion("FlexLine")
                Dim ls_tipo As String = "SYSGOLD_GRUPOS"
                Dim oTabla As DataTable

                Dim ls_codigo As String = ods.Tables("flexline_clientes").Rows(0).Item("grupo")

                Dim ls_Query As String = "pa_sel_um_gen_tabcod NULL" & ",'" & ls_tipo & "','" & dr.Item("empresa") & "'"

                Otrans.open()

                oTabla = Otrans.Obtiene(ls_Query)
                oTabla.DefaultView.RowFilter = "descripcion  = '" & ls_codigo & "'"

                If oTabla.DefaultView.Count > 0 Then
                    dr.Item("aprobacion") = oTabla.DefaultView(0).Item("texto1")
                End If


                Otrans.close()
                Otrans = Nothing

            Catch ex As Exception
            End Try
        End If

        dr.Item("periodo") = Trim(Date.Parse(dr.Item("fecha").ToString).ToString("yyyy") + Date.Parse(dr.Item("fecha").ToString).ToString("MM"))
        'dr.Item("direccion") = ods.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
        dr.Item("ciudad") = String.Empty ' ods.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
        dr.Item("comuna") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
        dr.Item("pais") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
        dr.Item("contacto") = String.Empty 'ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
        dr.Item("comentario1") = "PDA-" & dr_encabezado.Item("comentarios").ToString
        dr.Item("usuario") = dr_encabezado.Item("usuario_grabo").ToString

        dr.Item("direccion") = dr_encabezado.Item("direccion_entrega").ToString

        dr.Item("AnalisisE3") = Date.Parse(dr_encabezado.Item("fecha_entrega").ToString).ToString("dd/MM/yyyy")



        Oflex.ods.Tables("encabezado").Rows.Add(dr)

        ''Documentop
        dr = Oflex.ods.Tables("documentop").NewRow

        dr.Item("codigopago") = forma_pago
        dr.Item("diascredito") = condiciones(0).ToString
        dr.Item("total") = pd_total_pedido
        dr.Item("cuenta") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto1")
        dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
        Oflex.ods.Tables("documentop").Rows.Add(dr)

        ''DocumentoV
        dr = Oflex.ods.Tables("documentov").NewRow
        dr.Item("total") = pd_total_pedido
        dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
        Oflex.ods.Tables("documentov").Rows.Add(dr)

        ''DocumentoD
        For Each ofila In ods.Tables("pedidos_detalle").Rows
            'li_linea = li_linea + 1
            If ofila.Item("cod_pedido") = dr_encabezado.Item("cod_pedido") Then


                dr = Oflex.ods.Tables("detalle").NewRow
                dr.Item("secuencia") = ofila.Item("linea")
                dr.Item("producto") = ofila.Item("cod_producto_flex")
                dr.Item("cantidad") = ofila.Item("cantidad")


                dr.Item("precio") = ofila.Item("precio")
                dr.Item("total") = ofila.Item("total_linea")

                dr.Item("diascredito") = condiciones(0).ToString
                dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
                dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
                dr.Item("costo") = 0
                dr.Item("linea") = ofila.Item("linea")
                dr.Item("aux_valor8") = ofila.Item("gasto") 'A&P
                dr.Item("aux_valor9") = ofila.Item("marca") 'Marca
                dr.Item("aux_valor10") = ofila.Item("centro_costo") 'Centro de Costo
                dr.Item("aux_valor3") = ofila.Item("centro_costo")   'Centro de Costo
                dr.Item("aux_valor6") = ofila.Item("rubro") 'Rubro
                dr.Item("comentario") = ofila.Item("comentario")

                Oflex.ods.Tables("detalle").Rows.Add(dr)
            End If
        Next



        ls_pedido_generado = Oflex.Guardar_PedidoBasico()

        If ls_pedido_generado > 0 Then
            proceso_exitoso = True
            pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
            pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")
        End If

        Oflex = Nothing

        Return proceso_exitoso
    End Function



    Public Sub Llenar_Auxiliares(ByRef ods As DataSet, ByVal _codigo_cliente As String, ByVal _empresa As String)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()
            ls_sql = "flexline.pa_sel_um_gen_tabcod NULL,'SYSGOLD_CONDICIONES','" & _empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_condiciones"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            ls_sql = "flexline.pa_sel_um_ctacte '" & _empresa & "','CLIENTE','" & _codigo_cliente & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_clientes"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            ls_sql = "flexline.pa_sel_um_gen_tabcod '01','CONFIG.IMPUESTO','" & _empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_impuesto"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            ls_sql = "flexline.pa_sel_um_gen_tabcod 'MONEDA','CONFIG.EMPRESA','" & _empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_configuracion"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub


End Class

#End Region



#Region "Pedidos SysGold"
Public Class Pedidos_SysGold


    Public Function Hacer_Traslado_Pedidos_SysGold(ByVal numero_pedido As String)

        Dim Oflex As New Umbral_Flex.Pedidos
        Dim dr As DataRow

        Dim oTabla As DataTable
        Dim oTablaAux As DataTable
        Dim oFila As DataRow
        Dim ls_Query, ls_codigo, ls_sql As String
        Dim ls_dcodigo, ls_tipo, ls_dempresa As String
        Dim ls_daprobacion As String = ""
        Dim li_linea As Integer
        Dim lprocesar As Boolean = True

        Dim ldt_fecha_inicio, ldt_fecha_final As DateTime


        Dim oTransaccional As New Transaccional.Conexion("Sysgold")
        ldt_fecha_inicio = Now

        Try

            Dim oDataSet As New DataSet


            oTransaccional.open()

            ls_Query = "pa_sel_um_vis_encabezado_de_pedidos '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_encabezado_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_Query = "pa_sel_um_vis_detalle_de_pedido '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_detalle_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_Query = "pa_var_um_vis_detalle_de_pedido_total '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_total_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            '' traigo informacion del cliente en sysgold
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_client")
            ls_Query = "pa_sel_um_clientes '" & Trim(ls_codigo) & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            oTransaccional.close()

            ''Me cambio se servidor y BD
            oTransaccional = New Transaccional.Conexion("Flexline")
            oTransaccional.open()

            '' traigo informacion de la empresa de flex
            ls_tipo = "SYSGOLD_EMPRESA"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("empresa")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_empresa"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_dempresa = oDataSet.Tables("flexline_empresa").Rows(0).Item("descripcion")

            ''traigo informacion del impuesto
            ls_tipo = "CONFIG.IMPUESTO"
            ls_codigo = "01"
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_impuesto"
            oDataSet.Tables.Add(oTabla.Copy)

            ''traigo condicion del pedido
            ls_tipo = "SYSGOLD_CONDICIONES"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("forpago")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_condiciones"
            oDataSet.Tables.Add(oTabla.Copy)

            '' traigo nombre del ejecutivo
            ls_tipo = "SYSGOLD_EJECUTIVOS"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_asesor")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_ejecutivo"
            oDataSet.Tables.Add(oTabla.Copy)

            '' Traigo la Informacion del Cliente en flexline
            ls_dcodigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_cliente")
            ls_Query = "pa_sel_um_ctacte '" & ls_dempresa & "','CLIENTE','" & ls_dcodigo & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_daprobacion = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto2")

            ''Verifico la aprobacion de los pedidos
            If Trim(ls_daprobacion) <> "S" Then

                Try
                    ls_tipo = "SYSGOLD_GRUPOS"

                    ls_codigo = oDataSet.Tables("sysgold_clientes").Rows(0).Item("subcanal")
                    ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

                    oTabla = oTransaccional.Obtiene(ls_Query)

                    ls_daprobacion = oTabla.Rows(0).Item("texto1")
                Catch ex As Exception
                End Try
            End If


            Oflex.Limpiar_Datos()

            ''Encabezado
            dr = Oflex.ods.Tables("encabezado").NewRow

            dr.Item("empresa") = ls_dempresa
            dr.Item("tipodocto") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto").ToString
            dr.Item("numero") = Trim(Mid(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha"), 9, 2) +
                                Mid(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha"), 4, 2) +
                                oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("numero")).PadLeft(10, "0")
            dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
            dr.Item("codigo") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ctacte")
            dr.Item("vendedor") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
            dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
            dr.Item("listaprecio") = oDataSet.Tables("flexline_clientes").Rows(0).Item("listaPrecio").ToString
            dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
            dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
            dr.Item("aprobacion") = ls_daprobacion
            dr.Item("periodo") = Trim(Format(Now, "yyyy") + Format(Now, "MM"))
            dr.Item("direccion") = oDataSet.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
            dr.Item("ciudad") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
            dr.Item("comuna") = oDataSet.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
            dr.Item("pais") = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais").ToString
            dr.Item("contacto") = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais").ToString
            dr.Item("comentario1") = "PDA - " & Replace(Trim(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("observ")), "'", " ")
            dr.Item("usuario") = "PDA"

            Try
                If oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecen") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha") Then
                    dr.Item("AnalisisE3") = "30/12/1899"
                Else
                    dr.Item("AnalisisE3") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecen").ToString.Substring(0, 10)
                End If
            Catch ex As Exception
                dr.Item("AnalisisE3") = "30/12/1899"
            End Try


            Oflex.ods.Tables("encabezado").Rows.Add(dr)

            ''Documentop
            dr = Oflex.ods.Tables("documentop").NewRow

            dr.Item("codigopago") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("descripcion").ToString
            dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
            dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
            dr.Item("cuenta") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto1")
            dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
            Oflex.ods.Tables("documentop").Rows.Add(dr)

            ''DocumentoV
            dr = Oflex.ods.Tables("documentov").NewRow
            dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
            dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
            Oflex.ods.Tables("documentov").Rows.Add(dr)

            ''DocumentoD
            For Each oFila In oDataSet.Tables("sysgold_detalle_pedido").Rows
                li_linea = li_linea + 1
                dr = Oflex.ods.Tables("detalle").NewRow
                dr.Item("secuencia") = oFila.Item("numitem")
                dr.Item("producto") = oFila.Item("cod_producto")
                dr.Item("cantidad") = oFila.Item("ped_cantid")
                dr.Item("precio") = oFila.Item("ped_valor")
                dr.Item("total") = oFila.Item("ped_base")
                dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
                dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
                dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
                dr.Item("costo") = 0
                dr.Item("linea") = li_linea
                Oflex.ods.Tables("detalle").Rows.Add(dr)
            Next

            lprocesar = True
            'If oDataSet.Tables("flexline_clientes").Rows(0).Item("Analisisctacte6").ToString.Length > 0 Then

            '    ' MessageBox.Show("PEdidod Tienda")
            '    'lprocesar = False

            'End If
        Catch ex As Exception
        Finally



            If lprocesar Then

                If Oflex.Guardar_PedidoBasico > 0 Then
                    ldt_fecha_final = Now
                    oTransaccional = New Transaccional.Conexion("Flexline")
                    oTransaccional.open()
                    ls_sql = "pa_ins_um_gen_log_isf '" & Oflex.ods.Tables("encabezado").Rows(0).Item("empresa") & "','" &
                                        Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto") & "','" &
                                        Oflex.ods.Tables("encabezado").Rows(0).Item("numero") & "','" &
                                                    ldt_fecha_inicio & "','" & ldt_fecha_final & "'"

                    oTransaccional.Ingresa(ls_sql)

                    ''Me cambio se servidor y BD
                    ''elimino el documento en sysgold
                    oTransaccional = New Transaccional.Conexion("Sysgold")
                    oTransaccional.open()
                    ls_Query = "pa_del_um_encabezado_detalle_de_pedidos '" & numero_pedido & "'"
                    oTransaccional.Elimina(ls_Query)
                End If
            End If


            Oflex = Nothing

            oTransaccional.close()
            oTransaccional = Nothing
        End Try
        oTabla = Nothing
        oTablaAux = Nothing
        Return True
    End Function

    Public Sub Hacer_Traslado_Pedidos_SysGold_Oferta(ByVal numero_pedido As String)

        Dim ls_codigo As String
        Dim ls_tipo As String
        Dim oTabla As DataTable
        Dim oTablaAux As DataTable
        Dim oFila As DataRow
        'Dim ls_sqlString As String
        Dim ls_dempresa, ls_dtipodocto, ls_dnumero, ls_dfecha, ls_dvendedor, ls_dlistaPrecio, ls_daprobacion As String
        Dim ls_ddireccion, ls_dciudad, ls_dcomuna, ls_dpais, ls_dcontacto, ls_dcodigo, ls_dperiodo As String
        Dim ls_dcomentario1 As String
        Dim ld_dfactor, ld_dtotal As Double
        Dim li_sresultado As Integer
        Dim ls_pedido_generado As Integer
        Dim ln_diascredito As Integer
        Dim ls_pcuenta, ls_pcodigopago As String
        Dim ls_ddproducto As String
        Dim ls_ddsecuencia As String
        Dim li_ddcantidad As Integer
        Dim ld_ddprecio, ld_ddtotal, ld_ddpreciolista, ld_ddcosto As Double
        Dim ls_Query As String
        Dim ldt_fecha_inicio, ldt_fecha_final As DateTime
        Dim li_procesos As Integer = 0
        Dim li_linea As Integer = 0

        ldt_fecha_inicio = Now
        Try
            Dim oDataSet As New DataSet

            Dim oTransaccional As New Transaccional.Conexion("Sysgold")


            oTransaccional.open()

            ls_Query = "pa_sel_um_vis_encabezado_de_pedidos '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_encabezado_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_Query = "pa_sel_um_vis_detalle_de_pedido '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_detalle_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_Query = "pa_var_um_vis_detalle_de_pedido_total '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_total_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            '' traigo informacion del cliente en sysgold
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_client")
            ls_Query = "pa_sel_um_clientes '" & Trim(ls_codigo) & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            oTransaccional.close()

            ''Me cambio se servidor y BD
            oTransaccional = New Transaccional.Conexion("Flexline")
            oTransaccional.open()

            '' traigo informacion de la empresa de flex
            ls_tipo = "SYSGOLD_EMPRESA"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("empresa")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_empresa"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_dempresa = oDataSet.Tables("flexline_empresa").Rows(0).Item("descripcion")

            ''traigo informacion del impuesto
            ls_tipo = "CONFIG.IMPUESTO"
            ls_codigo = "01"
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_impuesto"
            oDataSet.Tables.Add(oTabla.Copy)

            ''traigo condicion del pedido
            ls_tipo = "SYSGOLD_CONDICIONES"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("forpago")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_condiciones"
            oDataSet.Tables.Add(oTabla.Copy)

            '' traigo nombre del ejecutivo
            ls_tipo = "SYSGOLD_EJECUTIVOS"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_asesor")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_ejecutivo"
            oDataSet.Tables.Add(oTabla.Copy)

            '' Traigo la Informacion del Cliente en flexline
            ls_dcodigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_cliente")
            ls_Query = "pa_sel_um_ctacte '" & ls_dempresa & "','CLIENTE','" & ls_dcodigo & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_daprobacion = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto2")

            ''Verifico la aprobacion de los pedidos
            If Trim(ls_daprobacion) <> "S" Then

                ls_tipo = "SYSGOLD_GRUPOS"
                ls_codigo = oDataSet.Tables("sysgold_clientes").Rows(0).Item("subcanal")
                ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

                oTabla = oTransaccional.Obtiene(ls_Query)
                Try
                    ls_daprobacion = oTabla.Rows(0).Item("texto1")
                Catch ex As Exception

                End Try

            End If

            ''Armando la Informacion para procesar el encabezado
            ''correlativo se autogenerara cuando se cree el documento
            ls_dtipodocto = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto")
            ln_diascredito = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
            ld_dfactor = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")

            ''debo cambiar para poner la linea 1
            ld_dtotal = oDataSet.Tables("sysgold_total_pedido").Rows(1).Item("total")
            ls_dvendedor = oDataSet.Tables("flexline_ejecutivo").Rows(0).Item("descripcion")

            ls_dlistaPrecio = oDataSet.Tables("flexline_clientes").Rows(0).Item("listaPrecio")
            ls_ddireccion = oDataSet.Tables("flexline_clientes").Rows(0).Item("direccion")
            ls_dciudad = oDataSet.Tables("flexline_clientes").Rows(0).Item("ciudad")
            ls_dcomuna = oDataSet.Tables("flexline_clientes").Rows(0).Item("comuna")
            ls_dpais = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais")
            ls_dcontacto = oDataSet.Tables("flexline_clientes").Rows(0).Item("contacto")
            ls_dnumero = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("numero")
            ls_dfecha = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
            ls_dperiodo = Trim(Mid(ls_dfecha, 7, 4) + Mid(ls_dfecha, 4, 2))


            ls_dnumero = Trim(Mid(ls_dfecha, 9, 2) + Mid(ls_dfecha, 4, 2) + ls_dnumero)
            ls_dnumero = ls_dnumero.PadLeft(10, "0")





            Try
                oTabla = oTransaccional.Obtiene(ls_Query)

                li_sresultado = oTabla.Rows(0).Item("correlativo")
                ls_pedido_generado = li_sresultado
            Catch
                li_sresultado = -1
            End Try

            ls_dcomentario1 = "PDA - " & Replace(Trim(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("observ")), "'", " ") &
                              " PEDIDO AL COSTO " & ls_dnumero

            If li_sresultado = -1 Then
                'Ingreso documento
                ls_Query = "pa_ins_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "','" & ls_dfecha &
                                "','" & ls_dcodigo & "','" & ls_dvendedor & "'," & CStr(ln_diascredito) &
                                ",'" & ls_dlistaPrecio & "'," & CStr(ld_dtotal) & "," & CStr(ld_dfactor) & ",'" & ls_daprobacion &
                                "'," & CInt(ls_dperiodo) & ",'" & ls_ddireccion & "','" & ls_dciudad & "','" & ls_dcomuna & "','" & ls_dpais &
                                "','" & ls_dcontacto & "','" & ls_dcomentario1 & "'"

                li_sresultado = oTransaccional.Ingresa(ls_Query)
                li_procesos = li_procesos + 1
                If li_sresultado > 0 Then

                    ls_Query = "pa_sel_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'"
                    oTabla = oTransaccional.Obtiene(ls_Query)

                    ls_pedido_generado = oTabla.Rows(0).Item("correlativo")
                    ls_pcuenta = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto1")
                    ls_pcodigopago = oDataSet.Tables("flexline_condiciones").Rows(0).Item("descripcion")

                    ''ingreso documentop
                    ls_Query = "pa_ins_um_documentop '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                    ",'" & ls_pcodigopago & "'," & CStr(ln_diascredito) & ",'" & CStr(ld_dtotal) &
                                    "','" & ls_dnumero & "','" & ls_pcuenta & "','" & ls_dfecha & "'"

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If oTransaccional.Codigo_error > 0 Then
                        li_procesos = -99
                    Else
                        li_procesos = li_procesos + 1
                    End If

                    ''Ingreso DocumentoV
                    ls_Query = "pa_ins_um_documentov '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                    "," & CStr(ld_dtotal) & "," & CStr(ld_dfactor)

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If oTransaccional.Codigo_error > 0 Then
                        li_procesos = -99
                    Else
                        li_procesos = li_procesos + 1
                    End If

                    'Ingreso DocumentoD
                    oTabla = oDataSet.Tables("sysgold_detalle_pedido")
                    For Each oFila In oTabla.Rows
                        ''Solo Procesara los productos normales
                        If oFila.Item("tipo") = "SO" Then
                            li_linea = li_linea + 1
                            ls_ddproducto = oFila.Item("cod_producto")
                            ls_ddsecuencia = oFila.Item("numitem")
                            li_ddcantidad = oFila.Item("ped_cantid")
                            ld_ddprecio = oFila.Item("ped_valor")
                            ld_ddtotal = oFila.Item("ped_base")

                            ls_Query = "pa_sel_um_producto '" & ls_dempresa & "','" & ls_ddproducto & "'"
                            oTablaAux = oTransaccional.Obtiene(ls_Query)
                            ld_ddcosto = oTablaAux.Rows(0).Item("costo")

                            ls_Query = "pa_sel_um_listaprecioD '" & ls_dempresa & "','" & ls_ddproducto & "','" & ls_dlistaPrecio & "'"
                            oTablaAux = oTransaccional.Obtiene(ls_Query)
                            Try
                                ld_ddpreciolista = oTablaAux.Rows(0).Item("valor")
                            Catch ex As Exception
                                ld_ddpreciolista = 0
                            End Try

                            ls_Query = "pa_ins_um_documentod '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                           "," & ls_ddsecuencia & ",'" & ls_ddproducto & "'," & li_ddcantidad & "," & ld_ddprecio &
                                           "," & ld_ddtotal & "," & ln_diascredito & "," & ld_dfactor & ",'" & ls_dfecha &
                                           "'," & ld_ddpreciolista & "," & ld_ddcosto & "," & li_linea

                            li_sresultado = oTransaccional.Ingresa(ls_Query)

                            If oTransaccional.Codigo_error > 0 Then
                                li_procesos = -99
                                '  Me.lbl.Items.Add("Fallo en " & ls_tipo & "- " & ls_Query)
                                ' Me.lbl.Items.Add(oTransaccional.descripcion_error)
                                'Me.lbl.Refresh()
                            End If
                        End If
                    Next

                    ldt_fecha_final = Now
                    ls_Query = "pa_ins_um_gen_log_isf '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "','" &
                                ldt_fecha_inicio & "','" & ldt_fecha_final & "'"

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If li_procesos <> -99 Then
                        li_procesos = li_procesos + 1
                    End If
                End If
            End If

            ls_Query = "pa_var_um_valida_documento_encabezado_detalle '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            If oTabla.Rows(0).Item("diferencia") = 0 Then
                li_procesos = 4
            Else
                li_procesos = -99
            End If

            oTransaccional.close()

            If li_procesos = 4 Then
                ''Me cambio se servidor y BD
                ''elimino el documento en sysgold


                Procesa_Pedido_Al_Costo(numero_pedido)


                ls_Query = "pa_sel_um_vis_encabezado_de_pedidos '" & numero_pedido & "'"
                oTabla = oTransaccional.Obtiene(ls_Query)
                ''Si todavia hay lineas significa que no lo hizo
                If oTabla.Rows.Count > 0 Then
                    li_procesos = -99
                End If

                ''''oTransaccional = New Transaccional.Conexion("Sysgold")
                ''''oTransaccional.open()
                ''''ls_Query = "pa_del_um_encabezado_detalle_de_pedidos '" & numero_pedido & "'"
                ''''li_sresultado = oTransaccional.Elimina(ls_Query)
            End If
            oDataSet = Nothing
            oTransaccional.close()
            oTransaccional = Nothing


        Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            '  Me.lbl.Items.Add("Fallo en " & ls_Query)
            ' Me.lbl.Refresh()
        Finally
            If li_procesos = -99 Then
                'ls_pedido_generado
                ''debo eliminar todo por que genero error
                Dim otransaccion As Transaccional.Conexion
                otransaccion = New Transaccional.Conexion("Flexline")
                otransaccion.open()
                ls_Query = "pa_del_um_documento_completo '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ls_pedido_generado
                li_sresultado = otransaccion.Elimina(ls_Query)

                otransaccion.close()

            End If

        End Try

        oTabla = Nothing
        oTablaAux = Nothing
    End Sub

    Private Sub Procesa_Pedido_Al_Costo(ByVal numero_pedido As String)
        Dim ls_codigo As String
        Dim ls_tipo As String
        Dim oTabla As DataTable
        Dim oTablaAux As DataTable
        Dim oFila As DataRow

        Dim ls_dempresa, ls_dtipodocto, ls_dnumero, ls_dfecha, ls_dvendedor, ls_dlistaPrecio, ls_daprobacion As String
        Dim ls_ddireccion, ls_dciudad, ls_dcomuna, ls_dpais, ls_dcontacto, ls_dcodigo, ls_dperiodo As String
        Dim ls_dcomentario1 As String
        Dim ld_dfactor, ld_dtotal As Double
        Dim li_sresultado As Integer
        Dim ls_pedido_generado As Integer
        Dim ln_diascredito As Integer
        Dim ls_pcuenta, ls_pcodigopago As String
        Dim ls_ddproducto As String
        Dim ls_ddsecuencia As String
        Dim li_ddcantidad As Integer
        Dim ld_ddprecio, ld_ddtotal, ld_ddpreciolista, ld_ddcosto As Double
        Dim ls_Query As String
        Dim ldt_fecha_inicio, ldt_fecha_final As DateTime
        Dim li_procesos As Integer = 0
        Dim li_linea As Integer = 0

        ldt_fecha_inicio = Now
        Try
            Dim oDataSet As New DataSet

            Dim oTransaccional As New Transaccional.Conexion("Sysgold")
            oTransaccional.open()

            ls_Query = "pa_sel_um_vis_encabezado_de_pedidos '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_encabezado_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_Query = "pa_sel_um_vis_detalle_de_pedido '" & numero_pedido & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_detalle_pedido"
            oDataSet.Tables.Add(oTabla.Copy)

            'ls_Query = "pa_var_um_vis_detalle_de_pedido_total '" & numero_pedido & "'"
            'oTabla = oTransaccional.Obtiene(ls_Query)
            'oTabla.TableName = "sysgold_total_pedido"
            'oDataSet.Tables.Add(oTabla.Copy)

            '' traigo informacion del cliente en sysgold
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_client")
            ls_Query = "pa_sel_um_clientes '" & Trim(ls_codigo) & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "sysgold_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            oTransaccional.close()

            ''Me cambio se servidor y BD
            oTransaccional = New Transaccional.Conexion("Flexline")
            oTransaccional.open()

            '' traigo informacion de la empresa de flex
            ls_tipo = "SYSGOLD_EMPRESA"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("empresa")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_empresa"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_dempresa = oDataSet.Tables("flexline_empresa").Rows(0).Item("descripcion")
            ''El codigo del cliente al que se debe facturar es al de la empresa
            ls_dcodigo = oDataSet.Tables("flexline_empresa").Rows(0)("texto2")

            ''traigo informacion del impuesto
            ls_tipo = "CONFIG.IMPUESTO"
            ls_codigo = "01"
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_impuesto"
            oDataSet.Tables.Add(oTabla.Copy)

            ''traigo condicion del pedido
            ls_tipo = "SYSGOLD_CONDICIONES"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("forpago")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_condiciones"
            oDataSet.Tables.Add(oTabla.Copy)

            '' traigo nombre del ejecutivo
            ls_tipo = "SYSGOLD_EJECUTIVOS"
            ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_asesor")
            ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_ejecutivo"
            oDataSet.Tables.Add(oTabla.Copy)

            '' Traigo la Informacion del Cliente en flexline
            ls_Query = "pa_sel_um_ctacte '" & ls_dempresa & "','CLIENTE','" & ls_dcodigo & "'"

            oTabla = oTransaccional.Obtiene(ls_Query)
            oTabla.TableName = "flexline_clientes"
            oDataSet.Tables.Add(oTabla.Copy)

            ls_daprobacion = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto2")

            ''Verifico la aprobacion de los pedidos
            If Trim(ls_daprobacion) <> "S" Then

                ls_tipo = "SYSGOLD_GRUPOS"
                ls_codigo = oDataSet.Tables("sysgold_clientes").Rows(0).Item("subcanal")
                ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

                oTabla = oTransaccional.Obtiene(ls_Query)
                Try
                    ls_daprobacion = oTabla.Rows(0).Item("texto1")
                Catch ex As Exception

                End Try

            End If

            ''Armando la Informacion para procesar el encabezado
            ''correlativo se autogenerara cuando se cree el documento
            ls_dtipodocto = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto3")
            ln_diascredito = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
            ld_dfactor = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
            ls_dlistaPrecio = oDataSet.Tables("flexline_clientes").Rows(0).Item("listaPrecio")

            ld_dtotal = 0
            '' Tengo que calcular el total del pedido
            oTabla = oDataSet.Tables("sysgold_detalle_pedido")
            For Each oFila In oTabla.Rows
                ''Solo Procesara los productos promocionales
                If oFila.Item("tipo") = "BO" Then
                    ls_Query = "pa_sel_um_listaprecioD '" & ls_dempresa & "','" & oFila.Item("cod_producto") & "','" & ls_dlistaPrecio & "'"
                    oTablaAux = oTransaccional.Obtiene(ls_Query)
                    Try
                        ld_dtotal = ld_dtotal + (oFila.Item("ped_cantid") * oTablaAux.Rows(0).Item("valor"))
                    Catch ex As Exception
                        'ld_total = ld_total
                    End Try

                End If
            Next

            'ld_dtotal = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
            ls_dvendedor = oDataSet.Tables("flexline_ejecutivo").Rows(0).Item("descripcion")
            ls_ddireccion = oDataSet.Tables("flexline_clientes").Rows(0).Item("direccion")
            ls_dciudad = oDataSet.Tables("flexline_clientes").Rows(0).Item("ciudad")
            ls_dcomuna = oDataSet.Tables("flexline_clientes").Rows(0).Item("comuna")
            ls_dpais = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais")
            ls_dcontacto = oDataSet.Tables("flexline_clientes").Rows(0).Item("contacto")
            ls_dnumero = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("numero")
            ls_dfecha = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
            ls_dperiodo = Trim(Mid(ls_dfecha, 7, 4) + Mid(ls_dfecha, 4, 2))


            ls_dnumero = Trim(Mid(ls_dfecha, 9, 2) + Mid(ls_dfecha, 4, 2) + ls_dnumero)
            ls_dnumero = ls_dnumero.PadLeft(10, "0")

            ls_dcomentario1 = "PDA - " & Replace(Trim(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("observ")), "'", " ") &
                                " Pedido Relacionado " & oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto") & " " & ls_dnumero &
                                ", Cliente " & oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_cliente")

            Try
                ls_Query = "pa_sel_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'"
                oTabla = oTransaccional.Obtiene(ls_Query)
                li_sresultado = oTabla.Rows(0).Item("correlativo")
                ls_pedido_generado = li_sresultado
            Catch
                li_sresultado = -1
            End Try


            If li_sresultado = -1 Then
                'Ingreso documento
                ls_Query = "pa_ins_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "','" & ls_dfecha &
                                "','" & ls_dcodigo & "','" & ls_dvendedor & "'," & CStr(ln_diascredito) &
                                ",'" & ls_dlistaPrecio & "'," & CStr(ld_dtotal) & "," & CStr(ld_dfactor) & ",'" & ls_daprobacion &
                                "'," & CInt(ls_dperiodo) & ",'" & ls_ddireccion & "','" & ls_dciudad & "','" & ls_dcomuna & "','" & ls_dpais &
                                "','" & ls_dcontacto & "','" & ls_dcomentario1 & "'"

                li_sresultado = oTransaccional.Ingresa(ls_Query)
                li_procesos = li_procesos + 1
                If li_sresultado > 0 Then

                    ls_Query = "pa_sel_um_documento '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'"
                    oTabla = oTransaccional.Obtiene(ls_Query)

                    ls_pedido_generado = oTabla.Rows(0).Item("correlativo")
                    ls_pcuenta = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto1")
                    ls_pcodigopago = oDataSet.Tables("flexline_condiciones").Rows(0).Item("descripcion")

                    ''ingreso documentop
                    ls_Query = "pa_ins_um_documentop '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                    ",'" & ls_pcodigopago & "'," & CStr(ln_diascredito) & ",'" & CStr(ld_dtotal) &
                                    "','" & ls_dnumero & "','" & ls_pcuenta & "','" & ls_dfecha & "'"

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If oTransaccional.Codigo_error > 0 Then
                        li_procesos = -99
                    Else
                        li_procesos = li_procesos + 1
                    End If

                    ''Ingreso DocumentoV
                    ls_Query = "pa_ins_um_documentov '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                    "," & CStr(ld_dtotal) & "," & CStr(ld_dfactor)

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If oTransaccional.Codigo_error > 0 Then
                        li_procesos = -99
                    Else
                        li_procesos = li_procesos + 1
                    End If

                    'Ingreso DocumentoD
                    oTabla = oDataSet.Tables("sysgold_detalle_pedido")
                    For Each oFila In oTabla.Rows
                        ''Solo Procesara los productos promocionales
                        If oFila.Item("tipo") = "BO" Then
                            li_linea = li_linea + 1
                            ls_ddproducto = oFila.Item("cod_producto")
                            ls_ddsecuencia = oFila.Item("numitem")
                            li_ddcantidad = oFila.Item("ped_cantid")
                            ld_ddprecio = oFila.Item("ped_valor")
                            ld_ddtotal = oFila.Item("ped_base")

                            ls_Query = "pa_sel_um_producto '" & ls_dempresa & "','" & ls_ddproducto & "'"
                            oTablaAux = oTransaccional.Obtiene(ls_Query)
                            ld_ddcosto = oTablaAux.Rows(0).Item("costo")

                            ls_Query = "pa_sel_um_listaprecioD '" & ls_dempresa & "','" & ls_ddproducto & "','" & ls_dlistaPrecio & "'"
                            oTablaAux = oTransaccional.Obtiene(ls_Query)
                            Try
                                ld_ddpreciolista = oTablaAux.Rows(0).Item("valor")
                            Catch ex As Exception
                                ld_ddpreciolista = 0
                            End Try

                            ls_Query = "pa_ins_um_documentod '" & ls_dempresa & "','" & ls_dtipodocto & "'," & CStr(ls_pedido_generado) &
                                           "," & ls_ddsecuencia & ",'" & ls_ddproducto & "'," & li_ddcantidad & "," & ld_ddprecio &
                                           "," & ld_ddtotal & "," & ln_diascredito & "," & ld_dfactor & ",'" & ls_dfecha &
                                           "'," & ld_ddpreciolista & "," & ld_ddcosto & "," & li_linea

                            li_sresultado = oTransaccional.Ingresa(ls_Query)

                            If oTransaccional.Codigo_error > 0 Then
                                li_procesos = -99
                                'Me.lbl.Items.Add("Fallo en " & ls_tipo & "- " & ls_Query)
                                'Me.lbl.Items.Add(oTransaccional.descripcion_error)
                                'Me.lbl.Refresh()
                            End If
                        End If
                    Next

                    ldt_fecha_final = Now
                    ls_Query = "pa_ins_um_gen_log_isf '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "','" &
                                ldt_fecha_inicio & "','" & ldt_fecha_final & "'"

                    li_sresultado = oTransaccional.Ingresa(ls_Query)
                    If li_procesos <> -99 Then
                        li_procesos = li_procesos + 1
                    End If
                End If
            End If

            ls_Query = "pa_var_um_valida_documento_encabezado_detalle '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'"
            oTabla = oTransaccional.Obtiene(ls_Query)
            If oTabla.Rows(0).Item("diferencia") = 0 Then
                li_procesos = 4
            Else
                li_procesos = -99
            End If

            oTransaccional.close()

            If li_procesos = 4 Then
                ''Me cambio se servidor y BD
                ''elimino el documento en sysgold

                Procesa_Pedido_Al_Costo(numero_pedido)
                oTransaccional = New Transaccional.Conexion("Sysgold")
                oTransaccional.open()
                ls_Query = "pa_del_um_encabezado_detalle_de_pedidos '" & numero_pedido & "'"
                li_sresultado = oTransaccional.Elimina(ls_Query)
            End If
            oDataSet = Nothing
            oTransaccional.close()
            oTransaccional = Nothing

        Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            '  Me.lbl.Items.Add("Fallo en " & ls_Query)
            '   Me.lbl.Refresh()
        Finally
            If li_procesos = -99 Then
                'ls_pedido_generado
                ''debo eliminar todo por que genero error
                Dim otransaccion As Transaccional.Conexion
                otransaccion = New Transaccional.Conexion("Flexline")
                otransaccion.open()
                ls_Query = "pa_del_um_documento_completo '" & ls_dempresa & "','" & ls_dtipodocto & "','" & ls_dnumero & "'," & ls_pedido_generado
                li_sresultado = otransaccion.Elimina(ls_Query)

                otransaccion.close()

            End If

        End Try

        oTabla = Nothing
        oTablaAux = Nothing

    End Sub

End Class
#End Region



#Region "Envio de Informacion Umbright_Mobile_SE "

Public Class Preparar_Informacion_Umbright_Mobile_SE

    Dim ods4 As New DataSet("Informacion_PDA_Consignaciones")

    Public Sub crearEstructura()
        Dim dt As DataTable
        dt = New DataTable("consignaciones_saldos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
        ods4.Tables.Add(dt.copy)

        dt = New DataTable("consignaciones_movimientos_historicos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("consignacion", GetType(String)))
        ods4.Tables.Add(dt.Copy)



        dt = New DataTable("consignaciones_conteos")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        ods4.Tables.Add(dt.copy)

        dt = New DataTable("consignaciones_conteos_encabezado")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("comentarios_reposicion", GetType(String)))
        dt.Columns.Add(New DataColumn("comentarios_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("clientes_envio")
        dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_saldos")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("CtaCte", GetType(String))
        dt.Columns.Add("saldo_total", GetType(Double))
        dt.Columns.Add("saldo_corriente", GetType(Double))
        dt.Columns.Add("saldo1a30", GetType(Double))
        dt.Columns.Add("saldo31a60", GetType(Double))
        dt.Columns.Add("saldo61a90", GetType(Double))
        dt.Columns.Add("saldo91a120", GetType(Double))
        dt.Columns.Add("saldomas120", GetType(Double))
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_documento")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("ctaCte", GetType(String))
        dt.Columns.Add("tipo_docto", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("fecha", GetType(DateTime))
        dt.Columns.Add("saldo", GetType(Double))
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("ListaPrecio")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        dt.Columns.Add("Valor", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("ProductoOferta")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ctacte", GetType(String))
        dt.Columns.Add("Precio", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        dt.Columns.Add("Todos", GetType(String))
        dt.Columns.Add("Descripcion", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        ods4.Tables.Add(dt.Copy)
    End Sub

    Private Function tekneLlenarEstructuraConsignaciones(ByVal dtUsuarios As DataTable) As Boolean

        ' Dim drv, drv2, drv_aux As DataRowView
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt_onbase, dt_historial, dt_conteos, dt_saldos, dt_conteos_encabezado As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim lbexitoso As Boolean = True
        Dim dt_saldos_clientes As DataTable

        Try
            Otrans.open()
            myOtrans.open()

            Dim ps_usuario As String = String.Empty
            ' If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Then
            'ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
            'dt_aux = Otrans.Obtiene(ls_sql)
            'dt_aux.DefaultView.RowFilter = "texto3  <> '" & ps_usuario & "'"


            For Each lsEmpresa As String In "DMARTE1,CODICASA,ALAMSA,DIUVA,VINOTECA".Split(",")

                For Each drUsuarios As DataRow In dtUsuarios.Rows
                    ' For Each drv_aux In dt_aux.DefaultView

                    '   If Not drv_aux.Item("Empresa").ToString.ToLower.Equals("dmarte1") Then

                    ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & lsEmpresa & "',null,'" & drUsuarios.Item("nombre").ToString & "'"
                    dt_saldos_clientes = Otrans.Obtiene(ls_sql)

                    'ods4.Tables("clientes_envio").Rows.Clear()
                    If dt_saldos_clientes.Rows.Count > 0 Then


                        For Each dr In dt_saldos_clientes.Rows
                            ods4.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("con_cliente") & "'"
                            If ods4.Tables("clientes_envio").DefaultView.Count = 0 Then
                                dr_aux = ods4.Tables("clientes_envio").NewRow
                                dr_aux.Item("Agregar") = True
                                dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                                dr_aux.Item("Razon_Social") = dr.Item("RazonSocial")
                                ods4.Tables("clientes_envio").Rows.Add(dr_aux)
                            End If
                        Next

                        ods4.Tables("clientes_envio").DefaultView.RowFilter = "agregar = true"

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null,null)"
                        dt_onbase = myOtrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null,null)"
                        dt_conteos = myOtrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo_encabezado (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null)"
                        dt_conteos_encabezado = myOtrans.Obtiene(ls_sql)

                        ls_sql = "pa_sel_um_consignaciones null,'" & lsEmpresa & "',null,null,'" & drUsuarios.Item("nombre").ToString & "'"
                        dt_historial = Otrans.Obtiene(ls_sql)
                        ls_sql = "pa_sel_um_consignaciones_saldos null,'" & lsEmpresa & "',null,null,'" & drUsuarios.Item("nombre").ToString & "'"
                        dt_saldos = Otrans.Obtiene(ls_sql)



                        For Each drv As DataRowView In ods4.Tables("clientes_envio").DefaultView
                            'ls_sql = "pa_sel_um_consignaciones_saldos_cliente '" & drv.Item("cod_cliente") & "','" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                            'dt = Otrans.Obtiene(ls_sql)
                            dt_saldos_clientes.DefaultView.RowFilter = "con_empresa = '" & lsEmpresa & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                            For Each drv3 As DataRowView In dt_saldos_clientes.DefaultView

                                dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                                dr_aux.Item("empresa") = lsEmpresa
                                dr_aux.Item("ctacte") = drv3.Item("con_cliente")
                                dr_aux.Item("producto") = drv3.Item("con_producto")
                                dr_aux.Item("saldo") = drv3.Item("saldo")
                                dr_aux.Item("cantidad_aprobada") = 0

                                dt_onbase.DefaultView.RowFilter = "cod_cliente_flex = '" & drv3.Item("con_cliente") & "' and cod_producto_flex = '" & drv3.Item("con_producto") & "'"
                                If dt_onbase.DefaultView.Count > 0 Then
                                    dr_aux.Item("cantidad_aprobada") = dt_onbase.DefaultView(0)("cantidad_maxima").ToString
                                End If

                                ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                            Next



                            dt_historial.DefaultView.RowFilter = "con_empresa = '" & lsEmpresa & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                            If dt_historial.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_historial.DefaultView

                                    dt_saldos.DefaultView.RowFilter = "con_cliente = '" & drv2.Item("con_cliente").ToString &
                                                                       "' and con_numero = '" & drv2.Item("con_numero").ToString &
                                                                       "' and con_producto = '" & drv2.Item("con_producto").ToString &
                                                                       "' and saldo > 0"

                                    If dt_saldos.DefaultView.Count > 0 Then
                                        dr_aux = ods4.Tables("consignaciones_movimientos_historicos").NewRow
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("con_cliente")
                                        dr_aux.Item("producto") = drv2.Item("con_producto")
                                        dr_aux.Item("tipo") = drv2.Item("fd_tipo")
                                        If drv2.Item("fd_tipo").ToString.ToLower.StartsWith("con") Then
                                            dr_aux.Item("numero") = drv2.Item("con_numero")
                                            dr_aux.Item("fecha") = drv2.Item("con_fecha")
                                            dr_aux.Item("Cantidad") = drv2.Item("con_cant")
                                        Else
                                            dr_aux.Item("numero") = drv2.Item("fd_numero")
                                            dr_aux.Item("fecha") = drv2.Item("fd_fecha")
                                            dr_aux.Item("Cantidad") = drv2.Item("fd_cantidad")
                                        End If
                                        dr_aux.Item("consignacion") = drv2.Item("con_numero")
                                        ods4.Tables("consignaciones_movimientos_historicos").Rows.Add(dr_aux)
                                    Else

                                    End If

                                Next
                            End If


                            dt_conteos.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                            If dt_conteos.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_conteos.DefaultView
                                    If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then
                                        dr_aux = ods4.Tables("consignaciones_conteos").NewRow
                                        dr_aux.Item("cod_conteo") = Val(drv2.Item("cod_conteo").ToString)
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                        dr_aux.Item("producto") = drv2.Item("cod_producto_flex")
                                        dr_aux.Item("cantidad") = drv2.Item("conteo")
                                        dr_aux.Item("fecha") = drv2.Item("fecha")

                                        ods4.Tables("consignaciones_conteos").Rows.Add(dr_aux)
                                    End If
                                Next

                            End If


                            dt_conteos_encabezado.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                            If dt_conteos_encabezado.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_conteos_encabezado.DefaultView
                                    If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then

                                        dr_aux = ods4.Tables("consignaciones_conteos_encabezado").NewRow
                                        dr_aux.Item("cod_conteo") = drv2.Item("cod_conteo").ToString
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                        dr_aux.Item("fecha") = drv2.Item("fecha")
                                        dr_aux.Item("usuario_grabo") = drv2.Item("usuario_grabo").ToString
                                        ods4.Tables("consignaciones_conteos_encabezado").Rows.Add(dr_aux)
                                    End If
                                Next

                            End If

                        Next 'Clientes Envio
                    End If
                    ''Este proceso es para complementar los productos que no han tenido movimiento pero que tienen saldo
                    'For Each dr In dt_onbase.Rows
                    '    ods4.Tables("consignaciones_saldos").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' " & _
                    '            " and ctacte = '" & dr.Item("cod_cliente_flex") & "' and producto = '" & dr.Item("cod_producto_flex") & "'"
                    '    If ods4.Tables("consignaciones_saldos").DefaultView.Count = 0 Then
                    '        ods3.Tables("cliente").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' and ctacte = '" & dr.Item("cod_cliente_flex") & "'"
                    '        If ods3.Tables("cliente").DefaultView.Count > 0 Then 'Me aseguro que el cliente pertenezca al vendedor
                    '            dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                    '            dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                    '            dr_aux.Item("ctacte") = dr.Item("cod_cliente_flex")
                    '            dr_aux.Item("producto") = dr.Item("cod_producto_flex")
                    '            dr_aux.Item("saldo") = 0 ' Por que no hay saldo//drv3.Item("saldo")
                    '            dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                    '            ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                    '        End If
                    '    End If
                    'Next
                    '(c) 0712 Se debe verificar que los clientes que no hayan tenido ningun movimiento y tenga productos aprobados tambien se envien

                    '  End If
                Next 'Usuarios
            Next 'Empresas a los que el usuario tiene acceso
            ' End If  ''Opciones


        Catch ex As Exception
            lbexitoso = False
        Finally
            oFlex.close()
            oFlex = Nothing
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso

    End Function


    Private Function tekeneLlenarEstructuraSaldos(ByVal dtUsuarios As DataTable, ByVal dtClientes As DataTable)
        Dim lsSQl As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'Dim Otrans as New Transaccional.co
        Dim dt As DataTable
        Dim dtListas As DataTable
        Dim dr, dr_aux As DataRow
        Dim lbAgregar As Boolean
        Dim clsGen As New ClasesGenerales.General


        Try


            myOtrans.open()


            dtListas = clsGen.ValoresDistinto(dtClientes, "empresa,listaprecio".Split(","))

            For Each lsEmpresa As String In "DMARTE1,CODICASA,ALAMSA,DIUVA,VINOTECA".Split(",")


                For Each drUsuarios As DataRow In dtUsuarios.Rows
                    lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes_saldos ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    dt = myOtrans.Obtiene(lsSQl)


                    'If dr.Item("empresa") = drv_aux.Item("empresa") Then

                    Dim dtaux As DataTable = clsgen.ValoresDistinto(dt, "empresa,ctacte".Split(","))

                    For Each dr In dtaux.Rows
                        dt.DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "'"
                        If dt.DefaultView.Count > 0 Then

                            Dim ls_filtro As String
                            dr_aux = ods4.Tables("cliente_saldos").NewRow
                            dr_aux.Item("empresa") = dr.Item("Empresa")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' and dias_factura < 1"
                            dr_aux.Item("saldo_corriente") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 0 and dias_factura < 31)"
                            dr_aux.Item("saldo1a30") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 30 and dias_factura < 61)"
                            dr_aux.Item("saldo31a60") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 60 and dias_factura < 91)"
                            dr_aux.Item("saldo61a90") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 90 and dias_factura < 121)"
                            dr_aux.Item("saldo91a120") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and dias_factura > 120 "
                            dr_aux.Item("saldomas120") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and saldo <> 0"
                            dr_aux.Item("saldo_total") = dt.Compute("sum(saldo)", ls_filtro)


                            ods4.Tables("cliente_saldos").Rows.Add(dr_aux)
                        End If
                    Next ''Clientes Saldos


                    lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    dt = myOtrans.Obtiene(lsSQl)

                    For Each dr In dt.Rows
                        If Math.Abs(Val(dr.Item("saldo").ToString)) >= 0.01 Then
                            dr_aux = ods4.Tables("cliente_documento").NewRow
                            dr_aux.Item("empresa") = dr.Item("empresa")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")
                            dr_aux.Item("tipo_docto") = dr.Item("tipo_docto")
                            dr_aux.Item("numero") = dr.Item("numero")
                            dr_aux.Item("fecha") = dr.Item("fecha")
                            dr_aux.Item("saldo") = dr.Item("saldo")
                            ods4.Tables("cliente_documento").Rows.Add(dr_aux)
                        End If
                    Next
                Next 'USUARIO


                ''Precios
                'lsSQl = "pa_var_um_listaPrecio '" & lsEmpresa & "'"
                dt = myOtrans.Obtiene("call pa_var_um_listaprecio_tekne()")

                For Each dr In dt.Rows
                    'Solo Agregara Productos Presupuestados
                    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                    If dtListas.DefaultView.Count > 0 Then
                        'If ls_listasdePrecios.IndexOf(dr.Item("lisprecio")) > 0 Then
                        'If pOpciones.ToLower.IndexOf("pda_solo_productos_ppto") > -1 Then
                        ''Solo productos Presupuestados
                        'ods.Tables("presupuesto_cliente").DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and producto = '" & dr.Item("producto") & "'"
                        'If ods.Tables("presupuesto_cliente").DefaultView.Count > 0 Then
                        lbAgregar = True
                    Else
                        lbAgregar = False
                    End If



                    If lbAgregar Then
                        dr_aux = ods4.Tables("ListaPrecio").NewRow
                        dr_aux.Item("empresa") = dr.Item("Empresa")
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                        dr_aux.Item("Valor") = dr.Item("valor")
                        dr_aux.Item("FechaI") = dr.Item("fechaInicio")
                        dr_aux.Item("FechaF") = dr.Item("fechaFinal")
                        ods4.Tables("ListaPrecio").Rows.Add(dr_aux)
                    End If
                    lbAgregar = False

                Next


                lsSQl = "call pa_sel_um_mov_productoOferta ('" & lsEmpresa & "')"
                dt = myOtrans.Obtiene(lsSQl)
                lbAgregar = False

                For Each dr In dt.Rows
                    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                    If dtListas.DefaultView.Count > 0 Then
                        'If ls_listasdePrecios.IndexOf(dr.Item("listaprecio")) > 0 Then
                        ''Envio Solo productos que esten en la lista de precios
                        ' ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                        'If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                        If dr.Item("todos").ToString.ToLower.Equals("s") Then
                            lbAgregar = True
                        Else
                            dtClientes.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                            If dtClientes.DefaultView.Count > 0 Then
                                lbAgregar = True
                            End If
                        End If
                        'End If

                        If lbAgregar Then
                            dr_aux = ods4.Tables("ProductoOferta").NewRow
                            dr_aux.Item("empresa") = dr.Item("empresa")
                            dr_aux.Item("producto") = dr.Item("producto")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")
                            dr_aux.Item("Precio") = dr.Item("precio")
                            dr_aux.Item("FechaI") = dr.Item("fechainicio")
                            dr_aux.Item("FechaF") = dr.Item("fechafinal")
                            dr_aux.Item("Todos") = dr.Item("todos")
                            dr_aux.Item("Descripcion") = dr.Item("descripcion")
                            dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                            ods4.Tables("ProductoOferta").Rows.Add(dr_aux)
                            lbAgregar = False
                        End If
                    End If
                Next
            Next 'eMPRESA

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Function

    Public Sub PrepararInformacion_tekne(ByVal psUsuarioEspecifico As String)

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtproductos, dtUsuarios As DataTable
        Dim ls_sql As String
        Dim lsRuta As String

        Try
            myOtrans.open()
            lsRuta = "C:\Aplicaciones\Tekne\Send\"

            crearEstructura()


            dtUsuarios = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")

            dtUsuarios.DefaultView.RowFilter = "cod_tipo_usuario = 8"
            dtUsuarios = dtUsuarios.DefaultView.ToTable
            dtUsuarios = ClsGen.ValoresDistinto(dtUsuarios, "usuario,nombre,telefono,cod_usuario".Split(","))
            dtUsuarios.TableName = "usuarios"
            dtUsuarios.WriteXml(lsRuta & "usuarios.xml", XmlWriteMode.WriteSchema)


            ls_sql = "call pa_sel_um_mov_cliente_tipo_usuario(8,null)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "clientes"
            dt.WriteXml(lsRuta & "clientes.xml", XmlWriteMode.WriteSchema)

            tekneLlenarEstructuraConsignaciones(dtUsuarios)
            Me.tekeneLlenarEstructuraSaldos(dtUsuarios, dt)

            ' ods4.Tables.Remove("clientes_envio")

            dt = ods4.Tables("cliente_saldos").Copy
            dt.TableName = "cliente_saldos"
            dt.WriteXml(lsRuta & "cliente_saldos.xml", XmlWriteMode.WriteSchema)

            dt = ods4.Tables("cliente_documento").Copy
            dt.TableName = "cliente_documento"
            dt.WriteXml(lsRuta & "cliente_documento.xml", XmlWriteMode.WriteSchema)

            dt = ods4.Tables("listaprecio").Copy
            dt.TableName = "listaprecio"
            dt.WriteXml(lsRuta & "listaprecio.xml", XmlWriteMode.WriteSchema)


            dt = ods4.Tables("ProductoOferta").Copy
            dt.TableName = "ProductoOferta"
            dt.WriteXml(lsRuta & "ProductoOferta.xml", XmlWriteMode.WriteSchema)

            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_producto_cliente_tekne(8,null)")
            dtproductos.TableName = "productos"
            dtproductos.WriteXml(lsRuta & "productos.xml", XmlWriteMode.WriteSchema)



            'dt = Otrans.Obtiene("pa_var_um_ppt_presupuesto_cliente_umbright_mobile_ee " & now.ToString("YYYY") & now.ToString("YYYY") ")
            'dt = myOtrans.Obtiene("call pa_sel_um_mov_presupuesto_cliente_se (6,null)")
            'dt.TableName = "presupuesto"
            'dt.Columns.Remove("cantidad")
            'dt.Columns.Remove("periodo")

            'dt.WriteXml(lsRuta & "presupuestos.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("call pa_sel_um_mov_producto_existencia_tekne(8,null)")
            dt.TableName = "existencia"
            dt.WriteXml(lsRuta & "existencias.xml", XmlWriteMode.WriteSchema)


            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_venta()")
            dtproductos.TableName = "mov_venta"
            dtproductos.WriteXml(lsRuta & "mov_venta.xml", XmlWriteMode.WriteSchema)


            'dtproductos = myOtrans.Obtiene("call pa_var_um_listaprecio_tekne()")
            'dtproductos.TableName = "precios"
            'dtproductos.WriteXml(lsRuta & "precios.xml", XmlWriteMode.WriteSchema)





            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_cliente_ruta(null)")
            dt.TableName = "rutas"
            dt.WriteXml(lsRuta & "rutas.xml", XmlWriteMode.WriteSchema)


            'dt = myOtrans.Obtiene("call pa_sel_um_mov_cliente_producto_distinto(6,null)")
            'dt.TableName = "producto_cliente"
            'dt.WriteXml(lsRuta & "producto_cliente.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "encuesta"
            'dt.WriteXml(lsRuta & "encuesta.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_usuario where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "encuesta_usuario"
            'dt.WriteXml(lsRuta & "encuesta_usuario.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "modelo_encuesta_detalle"
            'dt.WriteXml(lsRuta & "modelo_encuesta_detalle.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle_alternativa where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "modelo_encuesta_detalle_alternativa"
            'dt.WriteXml(lsRuta & "modelo_encuesta_detalle_alternativa.xml", XmlWriteMode.WriteSchema)


            ''Subir XML
            Dim ClsFTP As ClasesGenerales.Manejo_FTP
            Dim archivo As String
            Dim Archivos() As String


            Try

                ClsFTP = New ClasesGenerales.Manejo_FTP("tekne", "Onbase")
                ClsFTP.FTP_CambiarDirectorio("cell")
                ClsFTP.FTP_CambiarDirectorio("NewData")

                Archivos = Directory.GetFiles(lsRuta, "*.xml")
                For Each archivo In Archivos
                    If ClsFTP.FTP_SubirArchivo(archivo) Then
                        ClsGen.Mover_Archivo(archivo, lsRuta & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))

                    End If
                Next
                ClsFTP.FTP_CambiarDirectorio("..")

                'Archivos = ClsFTP.FTP_ListaArchivo("*.ttx")
                'For Each archivo In Archivos
                '    ClsFTP.FTP_EliminaArchivo(archivo)
                'Next

                Archivos = ClsFTP.FTP_ListaArchivo("*.dat")
                For Each archivo In Archivos
                    ClsFTP.FTP_RenombrarArchivo(archivo.Trim, Today.ToString("ddMMyyyy") & archivo.Replace("dat", "ttx").Trim)
                    ClsFTP.FTP_EliminaArchivo(archivo)
                Next

                ClsFTP.Finalizar()
            Finally
                ClsFTP = Nothing
                ClsGen = Nothing
            End Try



            'For icount2 = 0 To archivosxml.Length - 1
            '    If archivosxml(icount2).ToLower.IndexOf("xml") Then
            '        'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
            '        If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
            '            ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

            '            ff.DeleteFile("_" & archivosxml(icount2).Trim)
            '            ff.ChangeDirectory("Log")
            '            ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

            '            ff.ChangeDirectory("..")
            '        End If
            '    End If
            'Next
            'Dim proceso As New System.Diagnostics.Process

            'With proceso
            '    .StartInfo.FileName = "http://www.dmarte.com/cell/refresh/actualizar.php"
            '    .Start()
            'End With

            'Threading.Thread.Sleep(5000)


            'For Each proceso In Process.GetProcesses()
            '    If Not proceso Is Nothing Then
            '        If proceso.MainWindowTitle.ToLower.StartsWith("actualizacion umbright mobile se") Then
            '            proceso.Kill()
            '            Exit For
            '        End If
            '    End If
            'Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Public Sub PrepararInformacion_Umbright_Moble_SEGlobal(ByVal psUsuarioEspecifico As String)

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtproductos As DataTable
        Dim ls_sql As String
        Dim lsRuta As String

        Try
            myOtrans.open()

            ls_sql = "call pa_sel_um_mov_cliente_tipo_usuario (6,"
            If psUsuarioEspecifico.Length > 0 Then
                ls_sql += "'" & psUsuarioEspecifico & "'"
            Else
                ls_sql += "null"
            End If
            ls_sql += ")"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "clientes"
            dt.Columns.Remove("nit")
            dt.Columns.Remove("condpago")
            dt.Columns.Remove("listaprecio")
            dt.Columns.Remove("vigencia")
            dt.Columns.Remove("telefono")
            dt.Columns.Remove("giro")
            dt.Columns.Remove("ordenvisita")
            dt.Columns.Remove("frecuencia")
            dt.Columns.Remove("limiteCredito")


            lsRuta = "C:\Aplicaciones\Umbright Mobile SE\Send\"
            dt.WriteXml(lsRuta & "clientes.xml", XmlWriteMode.WriteSchema)

            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_producto_cliente_se (6,null)")
            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_producto_cliente_tekne (6,null)")
            dtproductos.TableName = "productos"
            dtproductos.WriteXml(lsRuta & "productos.xml", True)

            ''dt = Otrans.Obtiene("pa_var_um_ppt_presupuesto_cliente_umbright_mobile_ee " & now.ToString("YYYY") & now.ToString("YYYY") ")
            'dt = myOtrans.Obtiene("call pa_sel_um_mov_presupuesto_cliente_se (6,null)")
            'dt.TableName = "presupuesto"
            'dt.Columns.Remove("cantidad")
            'dt.Columns.Remove("periodo")

            'dt.WriteXml(lsRuta & "presupuestos.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("call pa_sel_um_mov_producto_existencia_se (6,null)")
            dt.TableName = "existencia"
            dt.WriteXml(lsRuta & "existencias.xml", XmlWriteMode.WriteSchema)



            dt = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")

            dt.DefaultView.RowFilter = "cod_tipo_usuario = 6"
            dt = dt.DefaultView.ToTable
            dt = ClsGen.ValoresDistinto(dt, "usuario,nombre,telefono,cod_usuario".Split(","))
            dt.TableName = "usuarios"
            dt.WriteXml(lsRuta & "usuarios.xml", XmlWriteMode.WriteSchema)


            dt = myOtrans.Obtiene("call pa_sel_um_mov_cliente_producto_distinto(6,null)")
            dt.TableName = "producto_cliente"
            dt.WriteXml(lsRuta & "producto_cliente.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("Select * from mov_encuesta where empresa = 'dmarte1' or empresa = 'codicasa'")
            dt.TableName = "encuesta"
            dt.WriteXml(lsRuta & "encuesta.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("Select * from mov_encuesta_usuario where empresa = 'dmarte1' or empresa = 'codicasa'")
            dt.TableName = "encuesta_usuario"
            dt.WriteXml(lsRuta & "encuesta_usuario.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle where empresa = 'dmarte1' or empresa = 'codicasa'")
            dt.TableName = "modelo_encuesta_detalle"
            dt.WriteXml(lsRuta & "modelo_encuesta_detalle.xml", XmlWriteMode.WriteSchema)

            dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle_alternativa where empresa = 'dmarte1' or empresa = 'codicasa'")
            dt.TableName = "modelo_encuesta_detalle_alternativa"
            dt.WriteXml(lsRuta & "modelo_encuesta_detalle_alternativa.xml", XmlWriteMode.WriteSchema)


            ''Subir XML
            Dim ClsFTP As ClasesGenerales.Manejo_FTP
            Dim archivo As String
            Dim Archivos() As String


            Try

                ClsFTP = New ClasesGenerales.Manejo_FTP("Umbright_Mobile_SE", "Onbase")
                ClsFTP.FTP_CambiarDirectorio("cell")
                ClsFTP.FTP_CambiarDirectorio("refresh")

                Archivos = Directory.GetFiles(lsRuta, "*.xml")
                For Each archivo In Archivos
                    If ClsFTP.FTP_SubirArchivo(archivo) Then
                        ClsGen.Mover_Archivo(archivo, lsRuta & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))

                    End If
                Next
                ClsFTP.FTP_CambiarDirectorio("..")

                'Archivos = ClsFTP.FTP_ListaArchivo("*.ttx")
                'For Each archivo In Archivos
                '    ClsFTP.FTP_EliminaArchivo(archivo)
                'Next

                Archivos = ClsFTP.FTP_ListaArchivo("*.dat")
                For Each archivo In Archivos
                    ClsFTP.FTP_RenombrarArchivo(archivo.Trim, Today.ToString("ddMMyyyy") & archivo.Replace("dat", "ttx").Trim)
                    ClsFTP.FTP_EliminaArchivo(archivo)
                Next

                ClsFTP.Finalizar()
            Finally
                ClsFTP = Nothing
                ClsGen = Nothing
            End Try



            'For icount2 = 0 To archivosxml.Length - 1
            '    If archivosxml(icount2).ToLower.IndexOf("xml") Then
            '        'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
            '        If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
            '            ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

            '            ff.DeleteFile("_" & archivosxml(icount2).Trim)
            '            ff.ChangeDirectory("Log")
            '            ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

            '            ff.ChangeDirectory("..")
            '        End If
            '    End If
            'Next
            'Dim proceso As New System.Diagnostics.Process

            'With proceso
            '    .StartInfo.FileName = "http://www.dmarte.com/cell/refresh/actualizar.php"
            '    .Start()
            'End With

            'Threading.Thread.Sleep(5000)


            'For Each proceso In Process.GetProcesses()
            '    If Not proceso Is Nothing Then
            '        If proceso.MainWindowTitle.ToLower.StartsWith("actualizacion umbright mobile se") Then
            '            proceso.Kill()
            '            Exit For
            '        End If
            '    End If
            'Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Public Sub Preparar_Informacion_Umbright_Mobile_SE(ByVal UsuarioEspecifico As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt_aux As DataTable
        Dim drv As DataRowView
        Dim ls_sql As String
        Dim ls_empresas As String = String.Empty

        Dim dt_producto As DataTable
        Dim iaux As Integer


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_sg_usuario_todos ()"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "cod_tipo_usuario = 6 "
            If UsuarioEspecifico.Length > 0 Then dt.DefaultView.RowFilter = "cod_tipo_usuario = 6 and usuario = '" & UsuarioEspecifico & "'"


            For Each drv In dt.DefaultView

                ls_sql = "call pa_var_um_sg_usuario_cliente ('" & drv.Item("usuario") & "')"
                dt_aux = myOtrans.Obtiene(ls_sql)
                ls_empresas = ""
                Dim dtempresas = ClsGen.ValoresDistinto(dt_aux, "nombre_empresa".Split(","))
                For Each dr As DataRow In dtempresas.Rows
                    'If ls_empresas.IndexOf(dr.Item("nombre_empresa")) < 0 Then
                    ls_empresas += "," & dr.Item("nombre_empresa")
                    ' End If
                Next

                'ls_empresa = ls_empresas.Split(",")

                For Each lempresa As String In ls_empresas.Split(",")
                    dt_aux.DefaultView.RowFilter = "nombre_empresa = '" & lempresa & "'"
                    iaux = 0
                    For Each drv2 As DataRowView In dt_aux.DefaultView
                        Generar_Informacion_Cliente_Umbright_Mobile_SE(iaux, drv, drv2)
                        Generar_Informacion_Productos_Umbright_Mobile_SE(iaux, drv, drv2, dt_producto)
                        iaux += 1
                    Next
                Next

            Next


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try


    End Sub

    Private Sub Generar_Informacion_Cliente_Umbright_Mobile_SE(ByVal pvez As Integer, ByVal pdrv As DataRowView, ByVal pdrvuc As DataRowView)
        '  Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_sql As String
        Dim nombre_archivo, ruta_archivo As String


        ruta_archivo = "C:\Aplicaciones\Umbright Mobile SE\Send\"
        nombre_archivo = "clientes_" & pdrv.Item("usuario").ToString.Trim.ToLower &
                        "_" & pdrv.Item("telefono").ToString.Trim &
                        "_" & pdrvuc.Item("nombre_empresa").ToString.ToLower & ".txt"

        Try
            'myOtrans.open()
            Otrans.open()

            If pvez = 0 Then
                ClsGen.Eliminar_Archivo(ruta_archivo + nombre_archivo)
            End If

            ls_sql = "pa_sel_um_ctacte '" & pdrvuc.Item("nombre_empresa") & "','CLIENTE','" & pdrvuc.Item("cod_flex") & "'"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count = 1 Then

                ClsGen.Escribir_texto(ruta_archivo + nombre_archivo, pdrvuc.Item("cod_flex") & "|" &
                            dt.Rows(0).Item("nombre_cliente") &
                            IIf(dt.Rows(0).Item("codlegal").ToString.StartsWith("2653247"), " " & dt.Rows(0).Item("direccion"), "") &
                            ":")

            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Generar_Informacion_Productos_Umbright_Mobile_SE(ByVal pvez As Integer, ByVal pdrv As DataRowView, ByVal pdrvuc As DataRowView, ByRef pdt As DataTable)
        Dim nombre_archivo, ruta_archivo As String
        Dim ClsGen As New ClasesGenerales.General

        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim OtransDS As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt, dt_barras, dt_plu As DataTable
        Dim adr() As DataRow
        Dim dr_aux As DataRow
        Dim codigo_barra, plu As String



        Try
            Otrans.open()
            OtransDS.open()
            ruta_archivo = "C:\Aplicaciones\Umbright Mobile SE\Send\"
            nombre_archivo = "productos_" & pdrv.Item("usuario").ToString.Trim.ToLower &
                            "_" & pdrv.Item("telefono").ToString.Trim &
                            "_" & pdrvuc.Item("nombre_empresa").ToString.ToLower & ".txt"

            ls_sql = "pa_var_um_ppt_presupuesto_cliente_ejercicio '" & pdrvuc.Item("nombre_empresa") & "'," & Today.ToString("yyyy") & Today.ToString("yyyy") & ",null,'" & pdrvuc.Item("cod_flex") & "'"
            dt = Otrans.Obtiene(ls_sql)

            dt_plu = OtransDS.Obtiene("pa_sel_um_prodcodbarra '" & pdrvuc.Item("nombre_empresa") & "',null,2")

            dt_barras = OtransDS.Obtiene("pa_sel_um_prodcodbarra '" & pdrvuc.Item("nombre_empresa") & "',null,3")

            If pvez = 0 Then
                ClsGen.Eliminar_Archivo(ruta_archivo + nombre_archivo)
                pdt = dt
                For Each dr As DataRow In dt.Rows
                    dt_plu.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                    If dt_plu.DefaultView.Count > 0 Then
                        plu = dt_plu.DefaultView(0).Item("codbarra").ToString
                    Else
                        plu = "."
                    End If

                    dt_barras.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                    If dt_barras.DefaultView.Count > 0 Then
                        codigo_barra = dt_barras.DefaultView(0).Item("codbarra").ToString
                    Else
                        codigo_barra = "."
                    End If

                    ClsGen.Escribir_texto(ruta_archivo + nombre_archivo, dr.Item("producto") & "|" & dr.Item("glosa") & "|" &
                        plu & "|" & codigo_barra & ":")
                Next
            Else
                For Each dr As DataRow In dt.Rows
                    adr = pdt.Select("producto = '" & dr.Item("producto") & "'")
                    If adr.Length <= 0 Then
                        dt_plu.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                        If dt_plu.DefaultView.Count > 0 Then
                            plu = dt_plu.DefaultView(0).Item("codbarra").ToString
                        Else
                            plu = "."
                        End If

                        dt_barras.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                        If dt_barras.DefaultView.Count > 0 Then
                            codigo_barra = dt_barras.DefaultView(0).Item("codbarra").ToString
                        Else
                            codigo_barra = "."
                        End If

                        ClsGen.Escribir_texto(ruta_archivo + nombre_archivo, dr.Item("producto") & "|" & dr.Item("glosa") & "|" &
                            plu & "|" & codigo_barra & ":")

                        dr_aux = pdt.NewRow
                        dr_aux.Item("producto") = dr.Item("producto")
                        pdt.Rows.Add(dr_aux)
                    End If
                Next
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            OtransDS.close()
            OtransDS = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Public Sub Generar_Informacion_Ultimo_Pedido_Umbright_Mobile_SE(ByVal piCodPedido As Integer)

        Dim ClsGen As New ClasesGenerales.General

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable

        Try
            myOtrans.open()

            dt = myOtrans.Obtiene("call pa_var_um_mov_pedidos_encabezado (" & piCodPedido & ")")
            If dt.Rows.Count > 0 Then
                'With dt.Rows(0)
                '    If .Item("comentarios").ToString.ToLower.StartsWith("cell") Then

                '        dt2 = Otrans.Obtiene("pa_sel_um_ctacte '" & .Item("empresa").ToString & "','CLIENTE','" & .Item("ctacte") & "'")
                '        nombre_archivo = "C:\Aplicaciones\Umbright Mobile SE\Send\ultimo_" & .Item("usuario_grabo").ToString.ToLower & _
                '                    "_" & .Item("empresa").ToString.ToLower & ".txt"

                '        ClsGen.Eliminar_Archivo(nombre_archivo)

                '        ClsGen.Escribir_texto(nombre_archivo, _
                '                .Item("empresa").ToString & "|" & _
                '                IIf(dt2.Rows.Count > 0, dt2.Rows(0).Item("nombre_cliente"), .Item("ctacte").ToString) & "|" & _
                '                .Item("total_pedido").ToString & "|" & _
                '                .Item("total_lineas").ToString & "|" & _
                '                DateTime.Parse(.Item("fecha_pedido").ToString).ToString("dd/MM/yyyy HH.mm") & ":")
                '    End If
                'End With

                dt.TableName = "pedido"
                dt.WriteXml("c:\aplicaciones\umbright Mobile SE\Send\Pedido_" & piCodPedido.ToString.Trim & ".xml", XmlWriteMode.WriteSchema)
            End If



        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    'Public Sub GeneraBDsqliteSE_Transportes(ByVal psUser As String)
    '    Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
    '    Dim Otrans As New Transaccional.Conexion("Flexline")

    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim dt, dtproductos, dtUsuarios As DataTable
    '    Dim ls_sql As String
    '    Dim lsRuta As String


    '    Try
    '        myOtrans.open()
    '        Otrans.open()

    '        ods4 = New DataSet
    '        crearEstructura()

    '        dtUsuarios = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")
    '        dtUsuarios.DefaultView.RowFilter = "usuario = '" & psUser & "'"
    '        dtUsuarios = dtUsuarios.DefaultView.ToTable
    '        dtUsuarios = ClsGen.ValoresDistinto(dtUsuarios, "usuario,nombre,telefono,cod_usuario".Split(","))
    '        dtUsuarios.TableName = "usuarios"

    '        lsRuta = "C:\Aplicaciones\SQLITE_TRANSPORTES\"
    '        '---------------------inicio de declaracion global
    '        Dim SQLconnect As New SQLite.SQLiteConnection()
    '        SQLconnect.ConnectionString = "Data Source=C:\Aplicaciones\SQLITE_TRANSPORTES\tekne.sqlite; Version=3; Synchronous=Full;"
    '        'SQLconnect.ConnectionString = "Data Source=C:\Aplicaciones\SQLITE_TRANSPORTES\tekne.sqlite; Version=3; Synchronous=Full;"
    '        SQLconnect.Open()
    '        '-------------------------------fin de global
    '        Dim SQLcommand As New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete  from  mov_control_transporte"
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()


    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete  from  mov_cliente_no_entrega "
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()





    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete from  pg_fecha"
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()

    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete from pg_fecha_control"
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()


    '        ''
    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete from pg_parametros"
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()

    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand.CommandText = "delete from seg_usuario"
    '        SQLcommand.ExecuteNonQuery()
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        ''
    '        '*****************FIN DE ELIMINACION DE INFORMACION EN TABLAS

    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        '-*--------------------------------------------------------------DOCUMENTOS--------------------------------------


    '        ls_sql = "call pa_var_um_mov_coordinador_vendedor (9,'" & psUser & "')"
    '        dt = myOtrans.Obtiene(ls_sql)
    '        ''Debo traer los controles de transporte de la fecha y adelante del usuario

    '        Dim dtControles As DataTable
    '        ls_sql = "pa_var_um_control_transporte_envio_tekne '" & dt.Rows(0).Item("nombre_usual") & "'"
    '        dtControles = Otrans.Obtiene(ls_sql)


    '        For Each drControl As DataRow In dtControles.Rows
    '            'ls_sql = "pa_sel_um_gen_control_tk '0000054560'"
    '            ls_sql = "pa_sel_um_gen_control_tk '" & drControl.Item("numero") & "'"
    '            'CAMBIAR EL NUMERO DE CONTROL DE TRANSPORTE
    '            dt = Otrans.Obtiene(ls_sql)

    '            Dim icorre As Integer = 0

    '            For Each dr As DataRow In dt.Rows
    '                icorre += 1
    '                If icorre = 1 Then
    '                    SQLcommand.CommandText = "INSERT INTO mov_control_transporte VALUES " & _
    '                 "('" & dr.Item("empresa") & "'," & _
    '                  "'" & dr.Item("tipodocto") & "'" & _
    '                  ",'" & dr.Item("numero") & "'" & _
    '                  ",'2664251'," & _
    '                  "'OFICINAS'," & _
    '                  "'OFICINAS'," & _
    '                  "'OFICINAS'," & _
    '                  "'" & dr.Item("total") & "'," & _
    '                  "'" & dr.Item("peso") & "'," & _
    '                  "'OFICINAS'," & _
    '                  "'" & dr.Item("fechaorigen") & "'," & _
    '                  "'" & dr.Item("piloto") & "'," & _
    '                  "'" & dr.Item("vehiculo") & "'," & _
    '                  "'" & dr.Item("ruta") & "'," & _
    '                  "'" & dr.Item("fecha") & "'," & _
    '                  "'" & dr.Item("fechavcto") & "'," & _
    '                  "'" & dr.Item("auxiliar") & "'," & _
    '                  "'OFICINAS'," & _
    '                  "'OFICINAS'," & _
    '                  "'" & dr.Item("ejecutivo") & "'," & _
    '                  "'" & dr.Item("coordinador") & "'," & _
    '                  "'')"
    '                    SQLcommand.ExecuteNonQuery()

    '                End If
    '                ' SQLcommand = SQLconnect.CreateCommand
    '                Try
    '                    SQLcommand.CommandText = "INSERT INTO mov_control_transporte VALUES " & _
    '                   "('" & dr.Item("empresa") & "'," & _
    '                    "'" & dr.Item("tipodocto") & "'" & _
    '                    ",'" & dr.Item("numero") & "'" & _
    '                    ",'" & dr.Item("ctacte") & "'," & _
    '                    "'" & dr.Item("razonsocial") & "'," & _
    '                    "'" & dr.Item("tipodoctoorigen") & "'," & _
    '                    "'" & dr.Item("numeroorigen") & "'," & _
    '                    "'" & dr.Item("total") & "'," & _
    '                    "'" & dr.Item("peso") & "'," & _
    '                    "'" & dr.Item("comentario1") & "'," & _
    '                    "'" & dr.Item("fechaorigen") & "'," & _
    '                    "'" & dr.Item("piloto") & "'," & _
    '                    "'" & dr.Item("vehiculo") & "'," & _
    '                    "'" & dr.Item("ruta") & "'," & _
    '                    "'" & dr.Item("fecha") & "'," & _
    '                    "'" & dr.Item("fechavcto") & "'," & _
    '                    "'" & dr.Item("auxiliar") & "'," & _
    '                    "'" & dr.Item("comentario2") & "'," & _
    '                    "'" & dr.Item("direccion") & "'," & _
    '                    "'" & dr.Item("ejecutivo") & "'," & _
    '                    "'" & dr.Item("coordinador") & "'," & _
    '                    "'')"
    '                    SQLcommand.ExecuteNonQuery()

    '                    SQLcommand.CommandText = "INSERT INTO mov_cliente_no_entrega VALUES " & _
    '                "('" & dr.Item("empresa") & "'," & _
    '                 "'" & dr.Item("ctacte") & "'" & _
    '                 ",'" & dr.Item("tipodoctoorigen") & "'" & _
    '                 ",'" & dr.Item("numeroorigen") & "'," & _
    '                 "'" & DateTime.Parse(dr.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss") & "'," & _
    '                 "'admin'," & _
    '                 "'99'," & _
    '                 "'0'," & _
    '                 "'_'," & _
    '                 "'_'," & _
    '                 "'si'," & _
    '                 "'" & dr.Item("numero") & "')"
    '                    SQLcommand.ExecuteNonQuery()
    '                Catch ex As Exception

    '                End Try

    '            Next
    '        Next 'Controles
    '        '-*------------------------------------------------------------FIN DOCUMENTOS--------------------------------------
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()


    '        '-*--------------------------------------------------------------USUARIO PARAMETROS--------------------------------------
    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        ls_sql = "call pa_sel_um_seg_usuario_parametros_tk('" & psUser & "')"
    '        dt = myOtrans.Obtiene(ls_sql)

    '        For Each dr As DataRow In dt.Rows
    '            '               SQLcommand = SQLconnect.CreateCommand
    '            SQLcommand.CommandText = "INSERT INTO pg_parametros VALUES ('" & dr.Item("direccion") & "','" & dr.Item("direccion_alterna") & "','" & dr.Item("lenguaje") & "','" & dr.Item("empresa") & "','','" & dr.Item("auto_envio") & "','" & dr.Item("activar_wifi") & "','" & dr.Item("carpeta") & "','" & dr.Item("carpeta_download") & "','" & dr.Item("carpeta_upload") & "')"
    '            SQLcommand.ExecuteNonQuery()
    '        Next
    '        '-*------------------------------------------------------------FIN DE USUARIO PARAMETROS--------------------------------------
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()

    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        '-*--------------------------------------------------------------USUARIO--------------------------------------
    '        ls_sql = "call pa_sel_um_seg_usuario_tk('" & psUser & "')"
    '        dt = myOtrans.Obtiene(ls_sql)


    '        For Each dr As DataRow In dt.Rows
    '            ' SQLcommand = SQLconnect.CreateCommand
    '            SQLcommand.CommandText = "INSERT INTO seg_usuario VALUES ('','" & dr.Item("cod_usuario") & "','" & dr.Item("usuario") & "','" & dr.Item("nombre") & "','" & dr.Item("clave") & "','','',0,'" & dr.Item("descripcion") & "')"
    '            SQLcommand.ExecuteNonQuery()
    '        Next
    '        '-*------------------------------------------------------------USUARIO--------------------------------------
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()


    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        '-*--------------------------------------------------------------FECHAS--------------------------------------

    '        ls_sql = "call pa_sel_um_pg_fechas_tk()"
    '        dt = myOtrans.Obtiene(ls_sql)


    '        For Each dr As DataRow In dt.Rows
    '            ' SQLcommand = SQLconnect.CreateCommand
    '            SQLcommand.CommandText = "INSERT INTO pg_fecha VALUES ('" & dr.Item("fecha") & "','" & dr.Item("dia") & "','" & dr.Item("frec2") & "','" & dr.Item("frec3") & "',0)"
    '            SQLcommand.ExecuteNonQuery()
    '        Next

    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()



    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        ' SQLcommand = SQLconnect.CreateCommand
    '        SQLcommand.CommandText = "UPDATE pg_fecha set estado=1 where fecha='" & Now.ToString("dd/MM/yyyy") & "'"
    '        SQLcommand.ExecuteNonQuery()

    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()

    '        '-*------------------------------------------------------------FECHAS--------------------------------------
    '        SQLcommand = New SQLiteCommand("begin", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()
    '        '-*--------------------------------------------------------------FECHAS CONTROL--------------------------------------

    '        ls_sql = "call  pa_sel_um_pg_fechas_control_tk()"
    '        dt = myOtrans.Obtiene(ls_sql)

    '        SQLcommand.CommandText = "INSERT INTO pg_fecha_control VALUES ('" & dt.Rows(0).Item("total_dias_mes") & "','" & dt.Rows(1).Item("total_dias_mes") & "','" & dt.Rows(0).Item("total_dias_mes") - dt.Rows(1).Item("total_dias_mes") & "','" & Now.ToLongDateString & "','" & Now.ToString("yyyy-MM-dd") & "','')"
    '        SQLcommand.ExecuteNonQuery()

    '        '-*------------------------------------------------------------FECHAS CONTROL--------------------------------------
    '        SQLcommand = New SQLiteCommand("end", SQLconnect)
    '        SQLcommand.ExecuteNonQuery()





    '        Try

    '            SQLcommand.Connection.Close()
    '            SQLcommand.Dispose()
    '            SQLconnect.Close()

    '            Dim dt2 As DataTable

    '            Copiar_EstructuraSQLITEP(lsRuta, psUser)
    '            ls_sql = "call pa_sel_um_edi_configuracionesTK ('" & psUser & "')"
    '            dt = myOtrans.Obtiene(ls_sql)

    '            ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"
    '            dt2 = myOtrans.Obtiene(ls_sql)


    '            Enviar_Informacion_Sitio_Tekne_Transporte(lsRuta, dt, dt2)
    '        Catch ex As Exception
    '        Finally
    '            SQLconnect = Nothing

    '        End Try



    '        Try
    '            myOtrans.close()
    '            Otrans.close()

    '            ClsGen = Nothing
    '        Catch ex As Exception

    '        End Try



    '    Catch ex As Exception
    '        ClsGen.Escribir_Log("Generar BDsqlitSE_Transportes " & ex.ToString)
    '        'Finally
    '        ' SQLcommand.Dispose()
    '        'SQLconnect.Close()

    '    Finally

    '    End Try

    'End Sub

    Private Sub Enviar_Informacion_Sitio_Tekne_Transporte(ByVal pRuta As String, ByVal dataUser As DataTable, ByVal dataFtp As DataTable)
        Dim ff As New FTP.clsFTP

        Dim archivos() As String
        '        Dim archivo As String
        '       Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General


        Try
            ClsGen.Escribir_Log("Enviando Informacion FTP Tekne  " & dataUser.Rows(0).Item("descripcion"))
            ff = New FTP.clsFTP
            ff.RemoteHost = dataFtp.Rows(0).Item("host") 'drv.Item("host")
            ff.RemoteUser = dataFtp.Rows(0).Item("usuario") 'drv.Item("usuario")
            ff.RemotePassword = dataFtp.Rows(0).Item("password") ' drv.Item("password")

            If (ff.Login()) Then
                ff.ChangeDirectory("www/tekne/bd") 'drv.Item("carpeta").ToString)
                ff.ChangeDirectory(dataUser.Rows(0).Item("descripcion").ToString) 'drv.Item("descripcion").ToString)
                ff.SetBinaryMode(True)
                Try
                    archivos = ff.GetFileList("*.txt")
                Catch ex As Exception

                End Try
                Dim dimension As String = ""
                ff.UploadFile("C:\Aplicaciones\SQLITE_TRANSPORTES\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")
                dimension = getTamFile("C:\Aplicaciones\SQLITE_TRANSPORTES\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")
                ClsGen.Escribir_Log("Tamaño de Archivo Enviado: " & dimension)
            End If

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Envio de Informacion Warning " & dataUser.Rows(0).Item("descripcion").ToString)
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
        Finally
            ff.CloseConnection()
            ff = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Copiar_EstructuraSQLITEP(ByVal ruta_archivos As String, ByVal usuario As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim archivos As String()
        Dim archivo As String

        Try

            'archivos = Directory.GetFiles(ruta_archivos & "Estructura\", "*.sqlite")
            archivos = Directory.GetFiles(ruta_archivos, "*.sqlite")

            For Each archivo In archivos
                If archivo.ToLower.IndexOf("sqlite") > 0 Then
                    'ClsGen.Eliminar_Archivo("C:\Aplicaciones\SQLITE\tekne.sqlite")
                    ClsGen.Copiar_Archivo(archivo, ruta_archivos & usuario & "\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1), True)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Public Function getTamFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            If (fi.Length / 1024) > 1024 Then
                Return Math.Round(((fi.Length / 1024) / 1024), 2).ToString() & " Mb"
            Else
                Return Math.Round((fi.Length / 1024), 2).ToString() & " Kb"
            End If
        Else
            Return String.Empty
        End If
    End Function
End Class
#End Region



    