Public Class frm_vin_Pedido_automatico_otras_bodegas
    Dim ods, ods_listado As DataSet
    Dim numero As Integer
    Dim iCount As Integer
    Dim total As Double
    Dim ctacte As String
    Dim sListaPrecio As String
    Dim Pbodega As String = ""
    Dim Pcomprador As String = ""
    Dim pCodigoCliente As String = String.Empty ''Codigo de Cliente para Comprar en DM,CDC,DIUVA
    Dim sEmpresaCompra As String = String.Empty
    Dim nLineasPedido As Integer = 30

    Private Sub llenar_informacion3()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()
            ls_sql = "pa_sel_um_prodbodegase_temp '" & gs_empresa & "','CD_CENTRAL',NULL"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "productos"
            If ods.Tables.IndexOf("productos") > 0 Then ods.Tables.Remove("productos")
            ods.Tables.Add(dt.Copy)
            Me.dgv_productos.DataSource = ods.Tables("productos")
            clsgen.Alinear_GridView(dt, dgv_productos, ",producto,glosa,stockminimo,stockmaximo,", "", ",producto,glosa,", "", "", ",Glosa=400,", "", True, True, 175, 0)
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing

        End Try
    End Sub

    Private Sub llenar_combos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2 As DataTable

        Try

            Otrans.open()

            ''Cada usuario debe tener asociada la bodega, en gentab cod en el tipo solicitud o/compra 

            Ods = New DataSet
            ls_sql = "pa_sel_um_usuario_bodega '" & gs_empresa & "','SOLICITUD O/COMPRA','" & gs_usuario & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            ods.Tables.Add(dt.Copy)

            Me.cmbBodega.Items.Clear()
            If dt.Rows.Count > 0 Then
                Pbodega = dt.Rows(0).Item("bodega")
                Pcomprador = dt.Rows(0).Item("comprador")
                Me.pCodigoCliente = dt.Rows(0).Item("cliente")
                Me.cmbBodega.Items.Add("CD_EXCLUSIVO_VNT")
                'Me.txt_bodega.Text = dt.Rows(0).Item("ubicacion")
                'ls_sql = "pa_sel_um_conteo_pedido_automatico '" & gs_empresa & "','SOLICITUD O/COMPRA','" & dt.Rows(0).Item("ubicacion") & "'"
                'dt = Otrans.Obtiene(ls_sql)
                'ls_sql = "pa_sel_um_fechadocto_pedido_automatico '" & gs_empresa & "','SOLICITUD O/COMPRA','" & Me.txt_bodega.Text & "'"
                'dt2 = Otrans.Obtiene(ls_sql)
                'Me.dtp_fecha.Text = dt2.Rows(0).Item("fecha")
                'Me.txt_conteo_factura.Text = dt.Rows(0).Item("cantidad")
            End If


            Me.cmb_valor1.Items.Add("Producto")
            Me.cmb_valor1.Items.Add("Glosa")
            Me.cmb_1.Items.Add("=")
            Me.cmb_1.Items.Add(">")
            Me.cmb_1.Items.Add("<")
            Me.cmb_1.Items.Add("like")
            Me.cmb_proveedor.Items.Add("CODICASA")
            Me.cmb_proveedor.Items.Add("DISTRIBUIDORA MARTE")
            Me.cmb_proveedor.Items.Add("DIUVA")
            Me.cmb_proveedor.Items.Add("PURITA")
            Me.cmb_valor1.Text = "Glosa"
            Me.cmb_1.Text = "like"
            Me.cmb_proveedor.Text = "CODICASA"


        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub frm_pedido_automatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combos()
        crear_estructura()
        crear_estructura_auxiliar()

    End Sub

    Private Sub crear_estructura_auxiliar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            If Not ods.Tables.Contains("documento") Then

                ls_sql = "pa_var_um_documento_traslado_fecha '" & gs_empresa & "',NULL,'01/01/2009','01/01/2009'"
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
                ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

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
                ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

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
                ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
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

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub crear_estructura()
        Dim dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General

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
        Me.dgv_productos.DataSource = ods_listado.Tables("listado")

    End Sub

    Private Sub llenar_info()
        Dim ls_sql As String
        Dim dt, dtExistenciaTienda, dtProveedor, dtPrecios, dtExistenciaCD As DataTable
        Dim dr, dr_aux As DataRow
        Dim existencia, verifica, existenciaCD As Double
        Dim clsgen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        'Dim lsListaPrecios As String = String.Empty

        Dim Oflex As New Umbral_Flex.productos
        Try
            ods_listado.Tables("listado").Rows.Clear()
            oTrans.open()
            ls_sql = "pa_sel_um_producto_bodega '" & gs_empresa & "','" & Me.cmb_proveedor.Text & "','" & pbodega & "'"
            dt = oTrans.Obtiene(ls_sql)

            If Me.cmb_proveedor.Text = "CODICASA" Then
                sEmpresaCompra = "CODICASA"
                ctacte = "79512"
            ElseIf Me.cmb_proveedor.Text = "DISTRIBUIDORA MARTE" Then
                sEmpresaCompra = "DMARTE1"
                ctacte = "122183"
            ElseIf Me.cmb_proveedor.Text = "DIUVA" Then
                sEmpresaCompra = "DIUVA"
                ctacte = "6608388"

            ElseIf Me.cmb_proveedor.Text = "PURITA" Then
                sEmpresaCompra = "PURITA"
                ctacte = "10572575"
            End If

            'If Me.cmb_proveedor.Text <> "DIUVA" Then
            ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & gs_empresa & "' ,'Proveedor'," & Me.ctacte
            dtProveedor = oTrans.Obtiene(ls_sql)
            sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")
            'End If

            '' Cambiar para que genere existencias de toda la empresa y bodega
            If dt.Rows.Count > 0 Then
                ls_sql = "pa_var_um_existencias_producto '" & gs_empresa & "',null,'" & cmbBodega.Text & "'"
                dtExistenciaTienda = oTrans.Obtiene(ls_sql)

                'CD_CENTRAL 
                'ls_sql = "pa_var_um_existencias_producto '" & sEmpresaCompra & "',null,'CD_CENTRAL'"
                ls_sql = "pa_var_um_existencias_producto '" & sEmpresaCompra & "',null,'" & Me.cmbBodega.Text & "'"
                dtExistenciaCD = oTrans.Obtiene(ls_sql)

                'Debe buscar la Lista de Precios Asociada a la tienda
                'La Lista de Precios debe ser compras


                'If Me.cmb_proveedor.Text = "DIUVA" Then
                ls_sql = "pa_var_um_listaPrecio '" & gs_empresa & "'"
                'Else
                '   ls_sql = "pa_sel_um_listapreciod '" & gs_empresa & "',null,'" & data.Rows(0).Item("listaprecio") & "'"
                'End If
                dtPrecios = oTrans.Obtiene(ls_sql)
                dtPrecios.DefaultView.RowFilter = "lisprecio = '" & sListaPrecio & "'" '"lisprecio like '%compras_2%'"
                dtPrecios = dtPrecios.DefaultView.ToTable


                For Each dr In dt.Rows

                    dtExistenciaTienda.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                    If dtExistenciaTienda.DefaultView.Count > 0 Then
                        If dtExistenciaTienda.DefaultView(0).Item("existencia") > 0 Then
                            existencia = dtExistenciaTienda.DefaultView(0).Item("existencia")
                        Else
                            existencia = 0
                        End If
                    Else
                        existencia = 0
                    End If

                    dr_aux = ods_listado.Tables("listado").NewRow
                    verifica = Val(dr.Item("stockmaximo")) - existencia
                    If verifica > 0 Then
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("glosa") = dr.Item("glosa")
                        dr_aux.Item("proveedor") = dr.Item("subfamilia")
                        dr_aux.Item("stockminimo") = dr.Item("stockminimo")
                        dr_aux.Item("stockmaximo") = dr.Item("stockmaximo")
                        dr_aux.Item("existencia") = existencia
                        existenciaCD = 0
                        dtExistenciaCD.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                        If dtExistenciaCD.DefaultView.Count > 0 Then
                            existenciaCD = dtExistenciaCD.DefaultView(0).Item("existencia")
                        End If
                        dr_aux.Item("existenciaCD") = existenciaCD
                        dr_aux.Item("sugerido") = Val(dr.Item("stockmaximo")) - existencia
                        dr_aux.Item("sugerido_original") = Val(dr.Item("stockmaximo")) - existencia
                        dr_aux.Item("comprar") = 1

                        'dtprecios = oflex.Obtener_Precio_Final(gs_empresa.
                        dtPrecios.DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                        If dtPrecios.DefaultView.Count > 0 Then
                            dr_aux.Item("valor") = dtPrecios.DefaultView(0).Item("valor")
                            dr_aux.Item("total") = dtPrecios.DefaultView(0).Item("valor") * dr_aux.Item("sugerido")
                        Else
                            dr_aux.Item("valor") = 0
                            dr_aux.Item("total") = 0
                        End If
                    Else
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("glosa") = dr.Item("glosa")
                        dr_aux.Item("proveedor") = dr.Item("subfamilia")
                        dr_aux.Item("stockminimo") = dr.Item("stockminimo")
                        dr_aux.Item("stockmaximo") = dr.Item("stockmaximo")
                        dr_aux.Item("existencia") = existencia
                        dr_aux.Item("sugerido") = 0
                        dr_aux.Item("sugerido_original") = 0
                        dr_aux.Item("comprar") = 0
                        dtPrecios.DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "'"
                        If dtPrecios.DefaultView.Count > 0 Then
                            dr_aux.Item("valor") = dtPrecios.DefaultView(0).Item("valor")
                            dr_aux.Item("total") = 0
                        Else
                            dr_aux.Item("valor") = 0
                            dr_aux.Item("total") = 0
                        End If
                        existenciaCD = 0
                        dtExistenciaCD.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                        If dtExistenciaCD.DefaultView.Count > 0 Then
                            existenciaCD = dtExistenciaCD.DefaultView(0).Item("existencia")
                        End If
                        dr_aux.Item("existenciaCD") = existenciaCD
                    End If
                    ods_listado.Tables("listado").Rows.Add(dr_aux)
                Next
            End If

            ods_listado.Tables("listado").DefaultView.RowFilter = "comprar = 1"

            Me.dgv_productos.DataSource = ods_listado.Tables("listado").DefaultView
            clsgen.Alinear_GridView(ods_listado.Tables("listado"), dgv_productos, ",producto,glosa,proveedor,stockminimo,stockmaximo,existencia,existenciacd,sugerido,sugerido_original,comprar,valor,total,grupo,", ",sugerido_original,", ",producto,glosa,stockminimo,stockmaximo,existencia,valor,total,", "", _
                                    ",existenciacd=" & Me.cmbBodega.Text & ",", ",producto=80,Glosa=200,stockminimo=85,stockmaximo=90,existencia=75,sugerido=75,valor=75,total=90,", "", True, True, 175, 0)

            '.ToLower.Replace("_", "")
            Me.dgv_productos.ForeColor = Color.Black
            Me.dgv_productos.Refresh()

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub txt_filtro1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub

    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", Me.txt_filtro1.Text, "", "", Me.cmb_1.Text, "", "", Me.txt_filtro1.Text, "")
        clsgen = Nothing
        ods_listado.Tables("listado").DefaultView.RowFilter = ls_filtro

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        hacer_filtro()


    End Sub

    Private Sub dgv_productos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_productos.CellFormatting
        Dim drv As DataRowView
        Try
            drv = ods_listado.Tables("listado").DefaultView.Item(e.RowIndex)
            If drv.Item("existencia").ToString = 0 Then
                dgv_productos.Item("existencia", e.RowIndex).Style.BackColor = Color.Gold
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function Preparar_Factura(ByVal igrupo As Integer) As Boolean
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr_aux As DataRow
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dr As DataRow
        Dim iCount As Integer
        Dim ls_sql, sTipoDocto As String
        Dim dtotal As Double = 0
        Dim correlativo As Integer
        Dim snumero As String = "0000000000001"

        Try
            sTipoDocto = "ORDEN/COMPRA"
            oTrans.open()
            ls_sql = "pa_sel_um_documento_numero'" & gs_empresa & "','" & sTipoDocto & "'"
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


            ls_sql = "pa_sel_um_documento_correlativo '" & gs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("correlativo").ToString <> "" Then
                    correlativo = dt.Rows(0).Item("correlativo") + 1
                Else
                    correlativo = 1
                End If

            Catch ex As Exception
            End Try


            Totalizar()

            ods.Tables("documento").Rows.Clear()
            ods.Tables("documentod").Rows.Clear()

            dr_aux = ods.Tables("documento").NewRow
            dr_aux.Item("empresa") = gs_empresa
            dr_aux.Item("TipoDocto") = sTipoDocto  '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
            dr_aux.Item("Numero") = snumero 'numero.ToString.PadLeft(13, "0")
            dr_aux.Item("Correlativo") = correlativo
            dr_aux.Item("ctacte") = ""
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
            dr_aux.Item("proveedor") = ctacte
            dr_aux.Item("Local") = Me.cmbBodega.Text  'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
            dr_aux.Item("Comprador") = Pcomprador
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
            dr_aux.Item("Comentario1") = Me.txt_observaciones.Text & " Facturar Bodega " & Me.cmbBodega.Text
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N" ''Emitido S para que no puedan realizarle cambios
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now
            'dr_aux.Item("Comentario1") = "" ' Me.txt_observaciones.Text
            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = gs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")
            dr_aux.Item("Caja") = "" 'gsCaja
            dr_aux.Item("Pago") = 0 'dr_aux.Item("Total")
            dr_aux.Item("IdApertura") = 0
            dr_aux.Item("NetoBimoneda") = 0
            dr_aux.Item("SubTotalBimoneda") = 0
            dr_aux.Item("TotalBimoneda") = 0
            dr_aux.Item("ParidadBimoneda") = 1
            ods.Tables("documento").Rows.Add(dr_aux)


            ods_listado.Tables("listado").DefaultView.RowFilter = "grupo = " & igrupo

            For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView 'ods.Tables("productos").Rows

                If drv.Item("comprar") = True Then
                    iCount += 1
                    dr_aux = ods.Tables("documentod").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = sTipoDocto '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
                    dr_aux.Item("Correlativo") = correlativo
                    dr_aux.Item("Secuencia") = iCount
                    dr_aux.Item("Linea") = iCount
                    dr_aux.Item("Producto") = drv.Item("producto").ToString 'dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")
                    dr_aux.Item("Cantidad") = drv.Item("sugerido")
                    dr_aux.Item("Precio") = drv.Item("valor")  'dr.Item("precio") '+ drv.Item("ValorDescuento")
                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = drv.Item("Total")
                    dr_aux.Item("Impuesto") = 0 'dr.Item("Total") - (dr.Item("Total") / porcentajeIva)  'drv.Item("ValorImpuesto")
                    dr_aux.Item("Neto") = drv.Item("Total") ' dr.Item("Total") 'dr.Item("Total") - dr_aux.Item("Impuesto")
                    dr_aux.Item("DrGlobal") = 0
                    dr_aux.Item("Total") = drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("PrecioAjustado") = drv.Item("valor") ' dr.Item("precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = "UN"
                    dr_aux.Item("CantidadIngreso") = drv.Item("sugerido")
                    dr_aux.Item("PrecioIngreso") = drv.Item("valor") 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalIngreso") = drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = drv.Item("Total") ' dr.Item("Total")
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
                    dr_aux.Item("SubTotalBimoneda") = drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ValPorcentajeDr1") = 0
                    dr_aux.Item("ValPorcentajeDr1Ingreso") = 0
                    dr_aux.Item("costo") = drv.Item("valor") ' dr_aux.Item("Precio")
                    dr_aux.Item("FechaVigenciaLp") = "01/01/1900"
                    dr_aux.Item("PrecioListaP") = 0
                    dr_aux.Item("DoctoOrigenVal") = "N"
                    ods.Tables("documentod").Rows.Add(dr_aux)

                    dtotal += drv.Item("total")
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





    Private Sub limpiar_campos()
        Me.txt_monto.Text = "0"
        Me.txt_observaciones.Text = " "
        Me.llenar_combos()

    End Sub
    Private Sub validacion_documento()
        ods_listado.Tables("listado").DefaultView.RowFilter = "comprar = true"
        ods_listado.Tables("listado").DefaultView.Sort = "existenciacd desc"
        Dim iCount, iGrupo As Integer
        iCount = 0
        iGrupo = 0

        ods_listado.Tables("listado").DefaultView.RowFilter = ""
        For Each dr As DataRow In ods_listado.Tables("listado").Rows

            If dr.Item("comprar") = True Then
                If iCount = nLineasPedido Then
                    iCount = 0
                End If
                If iCount = 0 Then
                    iGrupo += 1
                End If
                iCount += 1
                dr.Item("grupo") = iGrupo
            Else
                dr.Item("grupo") = 0
            End If
        Next

        ods_listado.Tables("listado").DefaultView.RowFilter = ""
        ods_listado.Tables("listado").DefaultView.RowFilter = ""
        Me.txtNumeroPedidos.Text = iGrupo
        'Dim dr As DataRow
        'For Each dr In ods_listado.Tables("listado").Rows 'ods.Tables("productos").Rows
        '    If dr.Item("comprar") = True Then
        '        iCount += 1
        '    End If
        'Next
    End Sub

    Private Sub Totalizar()
        Dim dr As DataRow
        Dim registros As Integer = 0
        Dim iSku As Integer = 0
        total = 0
        For Each dr In ods_listado.Tables("listado").Rows
            If dr.Item("comprar") = True Then
                total += Val(dr.Item("valor")) * dr.Item("sugerido")
                iSku += 1
            End If
            dr.Item("total") = Val(dr.Item("valor")) * dr.Item("sugerido")
        Next

        Me.txt_monto.Text = total
        Me.txtSkus.Text = iSku
        Try
            Me.txtNumeroPedidos.Text = Math.Ceiling(iSku / nLineasPedido)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grabar_informacion()
        validacion_documento()
        'Dim iPedidos As Integer
        Dim sNumeroPedidos As String = String.Empty

        'If iCount > 0 Then
        For iCount = 1 To Me.txtNumeroPedidos.Text
            Preparar_Factura(iCount)
            'Guardar_Factura()
            Guardar_Documento(ods, sEmpresaCompra, pCodigoCliente, Pcomprador, sNumeroPedidos, False)
            Me.txtPedidosGenerados.Text += sNumeroPedidos

            'Realizar Pedido
        Next
        '        Preparar_Factura()
        '        Guardar_Factura()
        '    Next

        'Else
        '    MessageBox.Show("No ha Selecionado Productos Para Generar Orden de Compra", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub


    Private Sub dgv_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellValueChanged
        Try
            Dim dr As DataRow
            total = 0
            For Each dr In ods_listado.Tables("listado").Rows 'ods.Tables("productos").Rows
                dr.Item("total") = Val(dr.Item("valor")) * dr.Item("sugerido")
            Next
        Catch ex As Exception
        End Try
        Totalizar()
    End Sub

    Private Sub txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto.TextChanged, txtSkus.TextChanged, txtNumeroPedidos.TextChanged
        Me.txt_monto.Text = Format(Convert.ToDecimal(Me.txt_monto.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub frm_pedido_automatico_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not ods.Tables.Contains("usuario_activo") Then
            MessageBox.Show("Usted no tiene permisos para crear Pedidos.", "Sin permisos Asignados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            If ods.Tables("usuario_activo").Rows.Count <= 0 Then
                MessageBox.Show("Usted no tiene permisos para crear Pedidos.", "Sin permisos Asignados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End If
    End Sub


    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        llenar_info()
        Totalizar()
        Me.btn_guardar.Enabled = True
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.validacion_documento()
            Me.grabar_informacion()
            Me.btn_guardar.Enabled = False
        End If
    End Sub

    Private Sub chkMostrarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMostrarTodo.CheckedChanged
        If chkMostrarTodo.CheckState = CheckState.Checked Then
            ods_listado.Tables("listado").DefaultView.RowFilter = ""
        Else
            ods_listado.Tables("listado").DefaultView.RowFilter = "comprar = 1"

        End If
    End Sub

    Private Sub chkDesmarcar_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDesmarcar.CheckStateChanged
        If Me.chkDesmarcar.CheckState = CheckState.Checked Then
            For Each dr As DataRow In ods_listado.Tables("listado").Rows
                dr.Item("comprar") = 0
            Next
            Totalizar()
            Me.chkMostrarTodo.CheckState = CheckState.Checked
            Me.chkDesmarcar.CheckState = CheckState.Unchecked
        End If

    End Sub

End Class