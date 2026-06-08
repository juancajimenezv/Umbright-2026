Imports System.IO
Public Class frm_documentos_fel

    Dim lDsFel As DataSet

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)

        Busqueda_Documentos()

    End Sub

    Private Sub Busqueda_Documentos()

        Try

            Dim lFecha = New Date(dtFecha.Value.Year, dtFecha.Value.Month, dtFecha.Value.Day)
            PedidosPendientesFEL(gs_empresa, lFecha, lDsFel, lFecha)

            If dboTipoDocto.SelectedValue = "FEL WALMART" Then

                lDsFel.Tables("pedidos").DefaultView.RowFilter = "codlegal = '7378106'"
                'And tipodocto = 'PEDIDO WALMART'"
                grvDoctos.DataSource = lDsFel.Tables("pedidos").DefaultView

            Else

                lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = '" & dboTipoDocto.SelectedValue & "'"
                grvDoctos.DataSource = lDsFel.Tables("pedidos").DefaultView

            End If

            'lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = '" & dboTipoDocto.SelectedValue & "'"
            'grvDoctos.DataSource = lDsFel.Tables("pedidos").DefaultView

            Dim clsGen As New ClasesGenerales.General
            'clsGen.Alinear_GridView(lDsFel.Tables("pedidos"), grvDoctos, "", "", "", ",fecha=fecha creacion,numero=numero flex,", "", "", "", True, True, 150, 0)


            clsGen.Alinear_GridView(lDsFel.Tables("pedidos"), grvDoctos,
        ",tipodocto,serieFEL,NumeroFEL,forma_pago,bodega,exento,vigencia,direccion,enviar,numero,fecha,codlegal,nombre_cliente,PorcDescuento,comentarioFACE,glosa,comentario1,",
             ",numeroFACE,fecharecepcionFACE,fechaenvioFACE,firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,RefTipoDocto,RefCorrelativo,texto2,total,empresa,exento,",
             ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,documento,", "", "",
             ",PorcDescuento=30,vigencia=15,exento=15,glosa=260,", "", True, True, 150, 0)

            'For Each col As DataGridViewColumn In grvDoctos.Columns

            '    col.ReadOnly = True
            '    col.Visible = False

            'Next

            'grvDoctos.Columns("Enviar").ReadOnly = False
            'grvDoctos.Columns("Enviar").Visible = True
            'grvDoctos.Columns("SerieFel").Visible = True
            'grvDoctos.Columns("NumeroFel").Visible = True
            'grvDoctos.Columns("fecha").Visible = True
            'grvDoctos.Columns("numero").Visible = True
            'grvDoctos.Columns("correlativo").Visible = True
            'grvDoctos.Columns("codlegal").Visible = True
            'grvDoctos.Columns("nombre_cliente").Visible = True
            'grvDoctos.Columns("ComentarioFace").Visible = True

            'grvDoctos.Columns("Enviar").Visible = True
            'grvDoctos.Columns("SerieFel").HeaderText = "Serie FEL"
            'grvDoctos.Columns("NumeroFel").HeaderText = "Numero FEL"
            'grvDoctos.Columns("fecha").HeaderText = "Fecha creacion"
            'grvDoctos.Columns("numero").HeaderText = "Numero Flex"
            'grvDoctos.Columns("correlativo").HeaderText = "Correlativo Flex"
            'grvDoctos.Columns("codlegal").HeaderText = "NIT"
            'grvDoctos.Columns("nombre_cliente").HeaderText = "Cliente"
            grvDoctos.Columns("ComentarioFace").HeaderText = "Comentarios FEL"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Crear_estructuraFel(ByRef dsFel As DataSet)

        Dim dt As DataTable

        dsFel = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("SerieFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroFel", GetType(String)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
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
        dt.Columns.Add(New DataColumn("ComentarioFace", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario1", GetType(String)))

        dsFel.Tables.Add(dt)

    End Sub

    Private Sub PedidosPendientesFEL(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)

        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gs_empresa
        Dim oTabla As DataTable
        Dim tFacturasExcentas As DataTable = New DataTable

        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocto_creditos_FelPura '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"

        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each drv As DataRowView In oTabla.DefaultView

                agregarPedidoPendiente(drv.Row, odsFACE)

            Next

            oTabla.DefaultView.RowFilter = "documento like 'credito'"

            For Each drv As DataRowView In oTabla.DefaultView

                agregarPedidoPendiente(drv.Row, odsFACE)

            Next

            ls_sqltxt = "pa_var_um_detalle_creditos_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            If odsFACE.Tables.Contains("detalle_pedidos") Then

                odsFACE.Tables.Remove(odsFACE.Tables.Item("detalle_pedidos"))

            End If

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

    Private Sub agregarPedidoPendiente(dr As DataRow, ByRef odsFACE As DataSet)

        Dim dr_aux As DataRow = odsFACE.Tables("pedidos").NewRow

        Try
            dr_aux.Item("Enviar") = 0
            If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
        Catch ex As Exception

        End Try

        dr_aux.Item("serie") = dr.Item("serie")
        dr_aux.Item("SerieFel") = dr.Item("SerieFel")
        dr_aux.Item("NumeroFel") = dr.Item("NumeroFel")
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
        dr_aux.Item("ComentarioFace") = dr.Item("ComentarioFACE")
        dr_aux.Item("LisPrecio") = dr.Item("ListaPrecio")
        dr_aux.Item("glosa") = dr.Item("glosa")
        dr_aux.Item("comentario1") = dr.Item("comentario1")

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


    Private Sub imprimirFELCreditos()



        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias_fel.Value
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtFecha.Value.ToString("yyyyMM") & "\" & Me.dtFecha.Value.ToString("ddMMyyyy")


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



            lDsFel.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In lDsFel.Tables("pedidos").DefaultView

                pm_valores(0) = gs_empresa
                pm_valores(1) = drv.Item("tipodocto")
                pm_valores(2) = drv.Item("numero")
                pm_valores(3) = gs_usuario

                ppath_reporte = clsGen.Path_Reporte
                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                If drv.Item("TipoDocto") = "NOTA DE ABONO" Then
                    ppath_reporte += gs_empresa.ToLower.Trim + " NABNFEL DIF"
                ElseIf drv.Item("TipoDocto") = "PEDIDO FEL RE" Then
                    ppath_reporte += gs_empresa.ToLower.Trim + " FEL"
                    pm_valores(1) = "FEL RE"
                ElseIf drv.Item("TipoDocto").ToString.StartsWith("NC-") Then
                    ppath_reporte += gs_empresa.ToLower.Trim + " NCFEL DIF"
                End If

                'ppath_reporte += gs_empresa.ToLower.Trim + " NCFEL DIF"
                'ppath_reporte += drv.Item("serieFACE").ToString.Trim
                ppath_reporte += ".rpt"

                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", True, "", True, Me.nupCopias_fel.Value)

            Next

        Catch ex As Exception
        Finally
            lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = '" & dboTipoDocto.SelectedValue & "'"
            Oaut = Nothing
            clsGen = Nothing
        End Try


        'lTblPedidos.ImportRow(lDvFelSel(dr.Index).Row)




    End Sub

    Private Sub llenarCombos()


        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_Sql As String
        Dim clsGen As New ClasesGenerales.General

        'oTransaccion = New Transaccional.Conexion("flexline")
        'oTransaccion.open()

        Try


            'ls_Sql = "select CODIGO from gen_Tabcod where empresA='dmarte1' and tipo ='gen_fel_documentos' and VIGENCIA!='N' order by codigo '"
            ls_Sql = "pa_sel_um_gen_tabcod  NULL,'GEN_fel_documentos','DMARTE1'"
            ldt_table = clsGen.selectQuery("FlexLine", ls_Sql)
            'ldt_table = oTransaccion.Obtiene(ls_Sql)
            ldt_table.TableName = "TpDocto"
            'l_Dataset.Tables.Add(ldt_table.Copy)

            Me.dboTipoDocto.DisplayMember = "CODIGO"
            Me.dboTipoDocto.ValueMember = "CODIGO"
            Me.dboTipoDocto.DataSource = ldt_table

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub


    Private Sub frm_documentos_fel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not System.IO.Directory.Exists("C:\FEL") Then

            Try

                System.IO.Directory.CreateDirectory("C:\FEL")

            Catch ex As Exception

            End Try

        End If

        If Not System.IO.Directory.Exists(My.Settings.Default.DirFel) Then

            Try

                System.IO.Directory.CreateDirectory(My.Settings.Default.DirFel)

            Catch ex As Exception

            End Try

        End If

        llenarCombos()

        Crear_estructuraFel(lDsFel)
        dboTipoDocto.SelectedIndex = 0

    End Sub

    Private Sub chkSelTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelTodos.CheckedChanged

        If grvDoctos.Rows.Count > 0 Then

            If chkSelTodos.Checked Then

                For Each rw As DataGridViewRow In grvDoctos.Rows

                    rw.Cells(0).Value = True

                Next

            ElseIf chkSelTodos.Checked = False Then

                For Each rw As DataGridViewRow In grvDoctos.Rows

                    rw.Cells(0).Value = False

                Next

            End If

        Else

            chkSelTodos.Checked = False

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub btnObtenerNC_Click(sender As Object, e As EventArgs) Handles btnObtenerNC.Click
        Busqueda_Documentos()
    End Sub

    Private Sub btnGenerarTXTNC_Click(sender As Object, e As EventArgs) Handles btnGenerarTXTNC.Click

        If (MessageBox.Show("Esta seguro de procesar estos documentos??", "FEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then

            Exit Sub

        End If

        Dim lDsFelSel As New DataSet
        Dim lDsFelWM As New DataSet
        Dim lTblPedidos As DataTable = lDsFel.Tables("pedidos").Copy()
        Dim lTblDetPedidos As DataTable = lDsFel.Tables("detalle_pedidos").Copy()
        Dim lDvFelSel As DataView
        Dim oEnvioFel As New Umbral.FelInFile.ProcesarFel

        Dim posicion1_path_server As Int16
        Dim posicion2_path_server As Int16
        Dim path_server As String
        Dim path_reporte As String


        lTblPedidos.Rows.Clear()

        lDvFelSel = grvDoctos.DataSource

        For Each dr As DataGridViewRow In grvDoctos.Rows

            If dr.Cells(0).Value = True Then

                lTblPedidos.ImportRow(lDvFelSel(dr.Index).Row)

            End If

        Next

        lTblPedidos.DefaultView.RowFilter = String.Format("codlegal <> '{0}'", "7378106")

        lDsFelSel.Tables.Add(lTblPedidos.DefaultView.ToTable("pedidos"))
        lDsFelSel.Tables.Add(lTblDetPedidos)

        oEnvioFel.EnviarDteInfile(lDsFelSel, My.Settings.Default.DirFel)

        lTblPedidos.DefaultView.RowFilter = ""
        lTblPedidos.DefaultView.RowFilter = String.Format("codlegal = '{0}'", "7378106")

        lDsFelWM.Tables.Add(lTblPedidos.DefaultView.ToTable("pedidos"))
        lDsFelWM.Tables.Add(lTblDetPedidos.Copy())

        'posicion1_path_server = path_reporte.IndexOf("\\", 0, 1)
        'posicion2_path_server = path_reporte.IndexOf("\", 2)

        'path_server = path_reporte.Substring(0, posicion2_path_server).Replace("\\", "")

        '  oEnvioFel.DirectorioWalmart = String.Format("\\192.192.1.170\fel_wm$\{0}\", gs_empresa)

        oEnvioFel.DirectorioWalmart = oEnvioFel.obtenerRutaXMLWalmart("DMARTE1")

        oEnvioFel.EnviarDteInfileXml(lDsFelWM, My.Settings.Default.DirFel)

        Busqueda_Documentos()

    End Sub

    Private Sub btnReimpresionNC_Click(sender As Object, e As EventArgs) Handles btnReimpresionNC.Click
        imprimirFELCreditos()
    End Sub

    Private Sub btnXmlWM_Click(sender As Object, e As EventArgs) Handles btnXmlWM.Click

        Dim lDsFelSel As New DataSet
        Dim lDvFelSel As DataView
        Try


            Dim lTblPedidos As DataTable = lDsFel.Tables("pedidos").Copy()
            Dim lTblDetPedidos As DataTable = lDsFel.Tables("detalle_pedidos").Copy()

            Dim oEnvioFel As New Umbral.FelInFile.ProcesarFel
            Dim oFolderSave As New FolderBrowserDialog
            Dim oFlex As New Transaccional.Conexion("Flexline")

            lTblPedidos.Rows.Clear()

            lDvFelSel = grvDoctos.DataSource

            For Each dr As DataGridViewRow In grvDoctos.Rows

                If dr.Cells(0).Value = True Then

                    lTblPedidos.ImportRow(lDvFelSel(dr.Index).Row)

                End If

            Next

            oFolderSave.Description = "Seleccione la ubicacion donde guardara los archivos XML"
            If oFolderSave.ShowDialog = DialogResult.OK Then

                For Each dr As DataRow In lTblPedidos.Rows

                    Try

                        Dim sFileName As String = ""
                        Dim sFileNameDest As String = ""
                        Dim ruta As String = ""
                        ruta = oEnvioFel.obtenerRutaXMLWalmart("") 'No aplica empresa

                        If dboTipoDocto.SelectedValue = "PEDIDO FEL RE" And dr("codlegal") = "7378106" Then

                            sFileName = String.Format("{0}fel_wm$\{1}\{1}_{2}_{3}_DTE.xml", ruta, dr("empresa").ToString().ToUpper(), "FEL RE", dr("numero").ToString())
                            sFileNameDest = String.Format("{0}\{1}_{2}_{3}_DTE.xml", oFolderSave.SelectedPath, dr("empresa").ToString().ToUpper(), "FEL RE", dr("numero").ToString())

                        Else

                            sFileName = String.Format("{0}fel_wm$\{1}\{1}_{2}_{3}_DTE.xml", ruta, dr("empresa").ToString().ToUpper(), "FEL", dr("numero").ToString())
                            sFileNameDest = String.Format("{0}\{1}_{2}_{3}_DTE.xml", oFolderSave.SelectedPath, dr("empresa").ToString().ToUpper(), "FEL", dr("numero").ToString())

                        End If


                        If System.IO.File.Exists(sFileName) Then

                            System.IO.File.Copy(sFileName, sFileNameDest, True)

                        End If

                    Catch ex As Exception

                        oFlex.Escribir_Log("Umbright, frm_documentos_fel, btnXmlWM_Click, Err: " & ex.Message)

                    End Try

                Next

            End If
        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub dboTipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles dboTipoDocto.SelectedValueChanged

        If dboTipoDocto.SelectedValue = "FEL WALMART" Then

            btnGenerarTXTNC.Enabled = False
            btnXmlWM.Enabled = True

        ElseIf dboTipoDocto.SelectedValue = "PEDIDO FEL RE" Then

            btnGenerarTXTNC.Enabled = True
            btnXmlWM.Enabled = True

        Else

            btnGenerarTXTNC.Enabled = True
            btnXmlWM.Enabled = False

        End If

    End Sub

End Class