Imports System.Text
Imports System.IO
Imports System.Net.Mime
Imports System.Web
Imports System.Net.Mail
Imports System.Linq
Imports System.Collections.Generic
Imports System.Data

Public Class frm_vin_Pedido_automatico
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

            ods = New DataSet
            ls_sql = "pa_sel_um_usuario_bodega '" & gs_empresa & "','SOLICITUD O/COMPRA','" & gs_usuario & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            ods.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                Pbodega = dt.Rows(0).Item("bodega")
                Pcomprador = dt.Rows(0).Item("comprador")
                Me.pCodigoCliente = dt.Rows(0).Item("cliente")
                Me.txt_bodega.Text = dt.Rows(0).Item("ubicacion")
                Me.txtEmailTienda.Text = dt.Rows(0).Item("email").ToString
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
            'Me.cmb_proveedor.Items.Add("CODICASA")
            'Me.cmb_proveedor.Items.Add("DISTRIBUIDORA MARTE")
            'Me.cmb_proveedor.Items.Add("DIUVA")
            Me.cmb_valor1.Text = "Glosa"
            Me.cmb_1.Text = "like"
            'Me.cmb_proveedor.Text = "CODICASA"

            ls_sql = "Select distinct CODIGO from flexline.gen_tabcod " &
  " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " &
  " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " &
  " UNION select distinct SubFamilia from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "

            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_SubFamilia"
            'ods.Tables.Add(dt.Copy)

            Me.cmb_proveedor.DataSource = dt
            Me.cmb_proveedor.DisplayMember = "CODIGO"
            Me.cmb_proveedor.ValueMember = "CODIGO"
            Me.cmb_proveedor.SelectedValue = "CODICASA"
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
        dt2.Columns.Add(New DataColumn("Sugerido", GetType(Decimal)))
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
        Me.txtNumeroPedidos.Text = String.Empty
        Me.txtPedidosGenerados.Text = String.Empty


        Dim lsProveedoresInternos As String = "CODICASA,DISTRIBUIDORA MARTE,DIUVA,PURITA"
        ctacte = String.Empty

        Dim Oflex As New Umbral_Flex.productos
        Try
            ods_listado.Tables("listado").Rows.Clear()
            oTrans.open()
            ls_sql = "pa_sel_um_producto_bodega '" & gs_empresa & "','" & Me.cmb_proveedor.Text & "','" & Pbodega & "'"
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
            Try
                ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & gs_empresa & "' ,'Proveedor'," & Me.ctacte
                dtProveedor = oTrans.Obtiene(ls_sql)
                sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")
            Catch ex As Exception

                sListaPrecio = "COMPRAS_2013A"
                's_sql = "pa_sel_um_proveedor_pedido_automatico '" & gs_empresa & "' ,'Proveedor'"
                'dtProveedor = oTrans.Obtiene(ls_sql)
                'sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")

            End Try

            'End If

            '' Cambiar para que genere existencias de toda la empresa y bodega
            If dt.Rows.Count > 0 Then
                ls_sql = "pa_var_um_existencias_producto '" & gs_empresa & "',null,'" & Pbodega & "'"
                dtExistenciaTienda = oTrans.Obtiene(ls_sql)

                'CD_CENTRAL 

                ls_sql = "pa_var_um_existencias_producto '" & sEmpresaCompra & "',null,'CD_CENTRAL'"
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
            clsgen.Alinear_GridView(ods_listado.Tables("listado"), dgv_productos, ",producto,glosa,proveedor,stockminimo,stockmaximo,existencia,existenciacd,sugerido,sugerido_original,comprar,valor,total,grupo,", ",sugerido_original,", ",producto,glosa,stockminimo,stockmaximo,existencia,valor,total,", "", "", ",producto=80,Glosa=200,stockminimo=85,stockmaximo=90,existencia=75,sugerido=75,valor=75,total=90,", "", True, True, 175, 0)
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
            dr_aux.Item("Local") = Me.txt_bodega.Text  'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
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
            dr_aux.Item("Comentario1") = Me.txt_observaciones.Text
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
    Private Sub validacion_documento(ByVal pbCambiarProveedor As Boolean)
        Dim ClsGen As New ClasesGenerales.General

        Try


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
            'Asigno el cliente 
            ctacte = Me.txtctacte.Text
            Dim lsSQL As String
            'Si es compra externa
            If ctacte = "" Or pbCambiarProveedor Then
                Dim frm_busqueda As New frm_busqueda_general
                frm_busqueda.Text = ":: Busqueda de Proveedor ::"
                frm_busqueda.nombre_vista = "ctacte"
                frm_busqueda.parametros_fijos = " tipoctacte = 'proveedor' and empresa = '" & gs_empresa & "' and "
                frm_busqueda.parametros = "razonsocial,ctacte"
                frm_busqueda.lista_campos = "CtaCte, codlegal, RazonSocial,Giro,CondPago,Vigencia "
                frm_busqueda.ShowDialog(Me)

                ctacte = frm_busqueda.resultado
                frm_busqueda = Nothing
                Me.txtctacte.Text = ctacte
                'Me.buscaProveedor()


                If ctacte.Length > 0 Then
                    If MessageBox.Show("Desea Configurar este proveedor como predeterminado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Try

                            lsSQL = "pa_upd_um_gen_tabcod '" & gs_empresa & "','producto.subfamilia','" & Me.cmb_proveedor.SelectedValue & "',null,null,'" & ctacte & "',null,null,null,null,null,'" & gs_usuario & "'"
                            ClsGen.insertQuery("FlexLine", lsSQL)
                            ClsGen.Escribir_Log(lsSQL)
                        Catch ex As Exception

                        End Try

                    End If
                End If

            End If

            If Me.txtEmailProveedor.Text.Length > 8 Then
                If Not Me.txtEmailProveedor.Text.Equals(Me.txtEmailOriginal.Text) Then
                    If MessageBox.Show("Desea Actualizar el Correo del Proveedor?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        lsSQL = "pa_upd_um_ctacte_email '" & gs_empresa & "','PROVEEDOR','" & ctacte & "','" & Me.txtEmailProveedor.Text & "','" & gs_usuario & "'"
                        ClsGen.insertQuery("FlexLine", lsSQL)
                        ClsGen.Escribir_Log(lsSQL)

                    End If


                End If
            End If
        Catch ex As Exception

        End Try
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
        'validacion_documento(False)
        'Dim iPedidos As Integer
        Dim sNumeroPedidos As String = String.Empty
        Dim psTipoDocto As String
        psTipoDocto = "ORDEN/COMPRA"

        Dim DT As DataTable
        Dim lsRutaPDF = "c:\temp\" & gs_empresa
        Dim cuentasCorreo As String = String.Empty
        Dim clsgen As New ClasesGenerales.General

        Try
            If Not Directory.Exists(lsRutaPDF) Then
                Directory.CreateDirectory(lsRutaPDF)
            End If
        Catch ex As Exception
            clsgen.Escribir_Log(ex.ToString)
        End Try

        'If iCount > 0 Then
        For iCount = 1 To Me.txtNumeroPedidos.Text
            Preparar_Factura(iCount)
            'Guardar_Factura()
            Guardar_Documento(ods, sEmpresaCompra, pCodigoCliente, Pcomprador, sNumeroPedidos, True)
            Me.txtPedidosGenerados.Text += sNumeroPedidos







            Try

                lsRutaPDF = lsRutaPDF & "\" & psTipoDocto.ToString.Replace(" ", "_").Replace("/", "_") & "_" & sNumeroPedidos.Replace(",", "") & ".pdf"

            Catch ex As Exception
                clsgen.Escribir_Log(ex.ToString)
            End Try


            Try

                cuentasCorreo = Me.txtEmailTienda.Text
                If Me.txtEmailProveedor.Text.Length > 0 Then
                    cuentasCorreo = Me.txtEmailProveedor.Text & "," & cuentasCorreo
                End If
            Catch ex As Exception
                clsgen.Escribir_Log(ex.ToString)
            End Try

            Try
                enviarcorreo_html(ods.Tables("listado"), cuentasCorreo, gs_usuario, "VINOTECA Orden de Compra " & sNumeroPedidos, False, 10, 0, lsRutaPDF)
            Catch ex As Exception
                clsgen.Escribir_Log(ex.ToString)
            End Try




            'Realizar Pedido
        Next


        '        Preparar_Factura()
        '        Guardar_Factura()
        '    Next

        'Else
        MessageBox.Show("Proceso de Compra Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub enviarPedido(sNumeroPedido As String)
        Dim psTipodocto, psNumero As String
        psTipodocto = "ORDEN/COMPRA"
        psNumero = sNumeroPedido
        mostrarOC("VINOTECA", psTipodocto, psNumero, True)
        Dim DT As DataTable
        Dim lsRutaPDF = "c:\temp\" & gs_empresa

        Try
            If Not Directory.Exists(lsRutaPDF) Then
                Directory.CreateDirectory(lsRutaPDF)
            End If
        Catch ex As Exception

        End Try



        Try

            lsRutaPDF = lsRutaPDF & "\" & psTipodocto.ToString.Replace(" ", "_").Replace("/", "_") & "_" & psNumero & ".pdf"

        Catch ex As Exception

        End Try


        'enviarcorreo_html(ods.Tables("listado"), "it@umbral.com.gt", "coscal", "VINOTECA Orden de Comrpra " & psNumero, False, 10, 0, lsRutaPDF)
        enviarcorreo_html(ods.Tables("listado"), Me.txtEmailTienda.Text, gs_usuario, "VINOTECA Orden de Compra " & psNumero, False, 10, 0, lsRutaPDF)
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
            Me.validacion_documento(False)
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

    Private Sub cmb_proveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectedIndexChanged

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    Me.validacion_documento(True)
        '    Me.grabar_informacion()
        '    Me.btn_guardar.Enabled = False
        'End If


        Dim psTipodocto, psNumero As String
        psTipodocto = "ORDEN/COMPRA"
        psNumero = "1400107390"
        mostrarOC("VINOTECA", psTipodocto, psNumero, True)
        Dim DT As DataTable
        Dim lsRutaPDF = "c:\temp\" & gs_empresa

        Try
            If Not Directory.Exists(lsRutaPDF) Then
                Directory.CreateDirectory(lsRutaPDF)
            End If
        Catch ex As Exception

        End Try



        Try

            lsRutaPDF = lsRutaPDF & "\" & psTipodocto.ToString.Replace(" ", "_").Replace("/", "_") & "_" & psNumero & ".pdf"

        Catch ex As Exception

        End Try

        Dim cuentasCorreo As String
        Try

            cuentasCorreo = Me.txtEmailTienda.Text
            If Me.txtEmailProveedor.Text.Length > 0 Then
                cuentasCorreo += "," & Me.txtEmailProveedor.Text
            End If
        Catch ex As Exception

        End Try


        enviarcorreo_html(ods.Tables("listado"), cuentasCorreo, "coscal", "VINOTECA Orden de Comrpra " & psNumero, False, 10, 0, lsRutaPDF)
    End Sub

    Private Sub cmb_proveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectedValueChanged


    End Sub


    Private Sub enviarcorreo_html(pdtPedidos As DataTable, psCuentaCorreo As String, psUsuarioActual As String, psSubject As String,
                                  pmostrarEncabezado As Boolean, pcolumnas As Integer, pmaximo As Integer,
                                  prutaAdjunto As String)
        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2



        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try


            Dim sbCorreo As New StringBuilder
            Dim iCount As Integer = 0


            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & psUsuarioActual & "'")

            sbCorreo.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>Estimado Proveedor</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td style='height:20px;'/></td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='10' style='text-align: Left;\'>Es un placer dirigirnos a usted en nombre de Vinoteca. Esperamos sinceramente que se encuentre bien y que sus actividades marchen de manera exitosa.</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td style='height:20px;'/></td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='10' style='text-align: Left;\'>Nos complace adjuntar la Orden de Compra correspondiente, la cual contiene los detalles de los productos requeridos. Apreciamos su pronta atención a este pedido y quedamos a su disposición para cualquier consulta o aclaración que pueda necesitar.</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td style='height:20px;'/></td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='10' style='text-align: Left;\'>Agradecemos de antemano su colaboración.</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")
            sbCorreo.AppendLine("<b>" + Me.txtRazonSocial.Text + "</b>")
            sbCorreo.AppendLine("</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "' style='height:20px;'>")
            sbCorreo.AppendLine("</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td><strong>Local</strong></td>")
            sbCorreo.AppendLine("<td  style='text-align: Left;'>" + Me.txt_bodega.Text + "</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td><strong>Numero de Orden</strong></td>")
            sbCorreo.AppendLine("<td style='text-align: Left;'>" + Me.txtPedidosGenerados.Text + "</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td><strong>Comprador</strong></td>")
            sbCorreo.AppendLine("<td colspan='2' style='text-align: Left;'>" + gs_nombre_usuario + "</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td><strong>Comentarios</strong></td>")
            sbCorreo.AppendLine("<td colspan='6' style='text-align: Left;'>" + Me.txt_observaciones.Text + "</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td style='height:20px;'/></td>")
            sbCorreo.AppendLine("</tr>")


            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td style='height:20px;'/></td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<td colspan='10' style='text-align: Left;'>Atentamente,</td>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("</tr>")
            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='10' style='text-align: Left;'>Vinoteca.</td>")
            sbCorreo.AppendLine("</tr>")

            Try

                'If pmostrarEncabezado = True And pdtPedidos.Rows.Count > 0 Then
                '    sbCorreo.AppendLine("<tr style='background-color:#560000; color:white;'>")
                '    For Each dcColumn As DataColumn In pdtPedidos.Columns
                '        iCount += 1
                '        sbCorreo.AppendLine("<td>")
                '        sbCorreo.AppendLine(dcColumn.ColumnName.ToString().TrimEnd)
                '        sbCorreo.AppendLine("</td>")

                '        If iCount > pcolumnas Then

                '            If iCount > pmaximo + pcolumnas Then Exit For
                '        End If
                '    Next
                '    sbCorreo.AppendLine("</tr>")





                '    iCount = 0


                '    For Each dr As DataRow In pdtPedidos.Rows
                '        sbCorreo.AppendLine("<tr>")
                '        Try

                '            iCount = 0

                '            For Each dcColumn As DataColumn In pdtPedidos.Columns
                '                iCount += 1

                '                sbCorreo.AppendLine("<td>")
                '                sbCorreo.AppendLine(dr.Item(dcColumn.ColumnName.ToString().TrimEnd))
                '                sbCorreo.AppendLine("</td>")
                '                If iCount > pcolumnas Then
                '                    If iCount > pmaximo + pcolumnas Then Exit For
                '                End If

                '            Next

                '        Catch ex As Exception

                '        Finally
                '        End Try
                '        sbCorreo.AppendLine("</tr>")
                '    Next

                'End If

                'sbCorreo.AppendLine("<tr>")
                'sbCorreo.AppendLine("<td></td>")
                'sbCorreo.AppendLine("<td></td>")
                'sbCorreo.AppendLine("<td></td>")
                'sbCorreo.AppendLine("<td>")
                ''sbCorreo.AppendLine("<b>Total</b>")
                'sbCorreo.AppendLine("</td>")
                'sbCorreo.AppendLine("<td><b>")
                ''sbCorreo.AppendLine(Decimal.Round(lDetTraslados.Sum(x >= x.Total), 2).ToString());
                'sbCorreo.AppendLine("</b></td>")
                sbCorreo.AppendLine("</table>")

            Catch ex As Exception
                clsGen.Escribir_Log(ex.ToString)
            End Try


            Try
                Message = New System.Net.Mail.MailMessage()
                SMTP1 = New System.Net.Mail.SmtpClient
                'config. para Outlook
                SMTP1.Port = 587
                SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
                SMTP1.EnableSsl = True

                dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
                SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

                Message.[To].Add(psCuentaCorreo)
                Message.From = New System.Net.Mail.MailAddress("notificacion@umbralcorp.com", "Abastecimiento VINOTECA", System.Text.Encoding.UTF8) 'Quien envía el e-mail

                Dim l_altview As AlternateView
                Dim sBody As String = sbCorreo.ToString()
                Try


                    'Dim l_lnkres As New LinkedResource(psImagen, MediaTypeNames.Image.Jpeg)
                    'l_lnkres.ContentId = Guid.NewGuid().ToString

                    'sBody = "<table style='width:100%; cellpadding:0px; cellspacing:0px;'>" +
                    '        "<tr><td><img src='cid:" + l_lnkres.ContentId + "' /></td></tr>" +
                    '        "</table><br />" + sBody
                    'l_altview.LinkedResources.Add(l_lnkres)
                Catch ex As Exception
                    clsGen.Escribir_Log(ex.ToString)
                End Try


                l_altview = AlternateView.CreateAlternateViewFromString(sBody, Nothing, MediaTypeNames.Text.Html)
                'l_altview = AlternateView.CreateAlternateViewFromString(sBody)

                Message.AlternateViews.Add(l_altview)

                Message.Subject = psSubject
                Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                Message.Body = sBody

                Message.BodyEncoding = System.Text.Encoding.UTF8
                Message.Priority = System.Net.Mail.MailPriority.Normal
                Message.IsBodyHtml = True

                If prutaAdjunto.Trim.Length > 0 Then
                    Dim adjuntar = New Net.Mail.Attachment(prutaAdjunto)
                    Message.Attachments.Add(adjuntar)
                End If

                SMTP1.Send(Message)

            Catch ex As Exception
                clsGen.Escribir_Log(ex.ToString)
            End Try

        Catch ex As Exception
            clsGen.Escribir_Log(psSubject)
            clsGen.Escribir_Log(ex.ToString)

        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub txt_filtro1_TextChanged(sender As Object, e As EventArgs) Handles txt_filtro1.TextChanged

    End Sub

    Private Sub cmb_1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_1.SelectedIndexChanged

    End Sub

    Private Sub cmb_valor1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_valor1.SelectedIndexChanged

    End Sub

    Private Sub chkDesmarcar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesmarcar.CheckedChanged

    End Sub

    Private Sub getProveedor()
        Me.txtEmailProveedor.Text = String.Empty
        Me.txtRazonSocial.Text = String.Empty
        Me.txtPedidosGenerados.Text = String.Empty
        Me.txt_observaciones.Text = String.Empty

        Try
            Dim clsGen As New ClasesGenerales.General
            Dim lsSQL As String
            Dim dt As DataTable

            lsSQL = "pa_sel_um_gen_tabcod '" & Me.cmb_proveedor.SelectedValue & "','producto.subfamilia','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then
                Me.txtctacte.Text = dt.Rows(0).Item("texto2").ToString
                lsSQL = "pa_var_um_ctactedirecciones '" & gs_empresa & "','PROVEEDOR','" & Me.txtctacte.Text & "'"
                dt = clsGen.selectQuery("Flexline", lsSQL)
                If dt.Rows.Count = 1 Then
                    Me.txtEmailOriginal.Text = dt.Rows(0).Item("email").ToString
                    Me.txtEmailProveedor.Text = dt.Rows(0).Item("email").ToString
                    Me.txtRazonSocial.Text = dt.Rows(0).Item("razonsocial").ToString
                ElseIf dt.Rows.Count > 0 Then
                    Me.txtRazonSocial.Text = dt.Rows(0).Item("razonsocial").ToString
                    Me.txtEmailOriginal.Text = dt.Rows(0).Item("email").ToString
                    Me.txtEmailProveedor.Text = dt.Rows(0).Item("email").ToString
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectionChangeCommitted

    End Sub

    Private Sub cmb_proveedor_Leave(sender As Object, e As EventArgs) Handles cmb_proveedor.Leave
        getProveedor()
    End Sub
End Class