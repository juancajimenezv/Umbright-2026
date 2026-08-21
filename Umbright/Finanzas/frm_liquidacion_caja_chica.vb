Imports System.Collections.Generic
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Microsoft.Office.Interop
Imports Newtonsoft.Json
Imports Sincronizacion



Public Class frm_liquidacion_caja_chica


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsGen.selectQuery("RegionalDBintOut", "pa_var_um_liquidaciones_gastos_pendiente")
            dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvListado, "", "", "", "", True, True, 100, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub mostrarLiquidacionTeams(psCorreoLiquidacion As String, psPeriodo As String, psEmpresa As String)

        Dim clsGen As New ClasesGenerales.General
        Dim lbCCvacio As Boolean = False

        Try

            Dim dt, dtLiquidacion, dtProveedores As DataTable
            Dim lsSQL As String

            lsSQL = " pa_sel_um_liquidaciones_gastos '" & psCorreoLiquidacion & "','" & psPeriodo & "','" & psEmpresa & "'"
            dtLiquidacion = clsGen.selectQuery("RegionalDBintOut", lsSQL)

            lsSQL = "pa_var_um_ctacte_traslado '" & psEmpresa & "','PROVEEDOR'"
            dtProveedores = clsGen.selectQuery("FlexLine", lsSQL)


            For Each dr As DataRow In dtLiquidacion.Rows

                Try
                    dtProveedores.DefaultView.RowFilter = "ctacte = '" & dr.Item("proveedor").ToString.Substring(0, dr.Item("proveedor").ToString.Trim.Length - 1) & "'"
                    If dtProveedores.DefaultView.Count > 0 Then
                        dr.Item("razonsocial") = dtProveedores.DefaultView(0).Item("razonsocial").ToString
                        dr.Item("codigo") = dtProveedores.DefaultView(0).Item("ctacte").ToString
                        dr.Item("proveedor") = dtProveedores.DefaultView(0).Item("ctacte").ToString

                        '    CrearProveedor_MDFO(dr.Item("codigo"), dr.Item("razonsocial"))
                    Else
                        '(c) Debo Crear el Proveedor
                        lsSQL = "pa_um_pwa_sel_fel_documento_compras_nit '" & dr.Item("proveedor").ToString & "'"
                        dt = clsGen.selectQuery("RegionalDBintOut", lsSQL)
                        If dt.Rows.Count = 1 Then
                            With dt.Rows(0)
                                If .Item("pdf_link").ToString.Length > 20 Then
                                    Dim lsnuevoctate = .Item("nitEmisor").ToString.Substring(0, .Item("nitEmisor").ToString.Trim.Length - 1)
                                    dr.Item("razonsocial") = "*Nuevo* " & .Item("RazonEmisor").ToString
                                    dr.Item("codigo") = lsnuevoctate
                                    dr.Item("proveedor") = lsnuevoctate
                                    crearProveedor(dt, psEmpresa)

                                Else
                                    dr.Item("razonsocial") = "**** Mal Ingresado---"
                                End If
                            End With

                        End If

                    End If
                    '


                Catch ex As Exception
                End Try


                Try
                    lsSQL = "pa_sel_um_sg_usuario_cuenta_office '" & dr.Item("correo").ToString & "'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        For Each dr2 As DataRow In dt.Rows
                            If Not dr2.Item("usuario").ToString.ToUpper.StartsWith("umbvvv") Then
                                dr.Item("Responsable") = dr.Item("nombre").ToString
                            End If
                        Next
                        'r.Item("Responsable") = dt.Rows(0).Item("nombre").ToString
                    End If
                Catch ex As Exception
                End Try

                Try

                    lsSQL = "pa_sel_um_gen_tabcod '" & dt.Rows(0).Item("usuario").ToString & "','USUARIO.LIQUIDACION'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        dr.Item("Centro_Costo") = IIf(dtLiquidacion.Rows(0).Item("ccosto").ToString.Length > 0, dtLiquidacion.Rows(0).Item("ccosto").ToString, dt.Rows(0).Item("texto").ToString) 'dt.Rows(0).Item("texto").ToString
                        dr.Item("Responsable") = IIf(dtLiquidacion.Rows(0).Item("Piloto").ToString.Length > 0, dtLiquidacion.Rows(0).Item("Piloto").ToString, dt.Rows(0).Item("descripcion").ToString) 'dt.Rows(0).Item("descripcion").ToString
                    Else
                        If dtLiquidacion.Rows(0).Item("ccosto").ToString.Length > 0 Then
                            dr.Item("Centro_Costo") = dtLiquidacion.Rows(0).Item("ccosto").ToString 'dt.Rows(0).Item("texto").ToString
                            dr.Item("Responsable") = dtLiquidacion.Rows(0).Item("Piloto").ToString 'dt.Rows(0).Item("descripcion").ToString
                        Else
                            lbCCvacio = True

                        End If


                    End If
                Catch ex As Exception
                End Try

                Try
                    dr.Item("descripcion_producto") = dr.Item("tipo_gasto").ToString.Split("|")(1)
                    dr.Item("tipo_gasto") = dr.Item("tipo_gasto").ToString.Split("|")(2)
                Catch ex As Exception
                End Try

                Try
                    If dr.Item("producto").ToString.Equals("1031015") Then
                        dr.Item("Iva_Clase") = "SERVICIO"
                    End If
                Catch ex As Exception
                End Try

            Next

            If lbCCvacio Then
                MessageBox.Show("Existen Documentos sin Centro de Costo, Verificar para Continuar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
            End If

            Me.dgv_Detalle.DataSource = dtLiquidacion
            clsGen.Alinear_GridView(dtLiquidacion, Me.dgv_Detalle, "", "", "", "", True, True, 250, 0)

            Me.lblMonto.Text = dtLiquidacion.Compute("sum(Monto)", "Monto>0")
            Me.lb_registros.Text = dtLiquidacion.Rows.Count
            Me.lblCorreo.Text = psCorreoLiquidacion

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub CrearProveedor_MDFO(psrtu As String, psrazonsocial As String)
        Dim url As String = "https://86d4efb4f29feb5baca23d0e3af86d.07.environment.api.powerplatform.com:443/powerautomate/automations/direct/workflows/bd37a2c03a144eec856b4db5fdacc270/triggers/manual/paths/invoke/?api-version=1&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=bdH2C2tsXNh-CuoTFfHZUeHLLyXpN6u7lAuW4kLuLJM"

        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
        ' Construir lista con valores personalizados

        Dim jsonBody As String =
        "[{" & vbCrLf &
        "  ""CountryRegion"": ""GTM""," & vbCrLf &
        "  ""TaxExemptNumber"": """ & psrtu & """," & vbCrLf &
        "  ""CompanyCode"": """ & mdfo_gs_empresa & """," & vbCrLf &
        "  ""CompanyName"": """ & psrazonsocial & """," & vbCrLf &
        "  ""TipoDocumentoIdentificacion"": ""5""" & vbCrLf &
        "}]"


        'Try
        '    System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
        '    Dim request As WebRequest

        '    request = WebRequest.Create("https://86d4efb4f29feb5baca23d0e3af86d.07.environment.api.powerplatform.com:443/powerautomate/automations/direct/workflows/bd37a2c03a144eec856b4db5fdacc270/triggers/manual/paths/invoke/?api-version=1&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=bdH2C2tsXNh-CuoTFfHZUeHLLyXpN6u7lAuW4kLuLJM")
        '    Dim response As WebResponse
        '    'Dim postData As String = "
        '    '{
        '    '  ""Correo"": """ & psCorreo & """,
        '    '  ""Motivo"": """ & psEncabezado & """,
        '    '  ""Mensaje_a_enviar"": """ & psCuerpoMensaje & """
        '    '}"

        '    Dim data As Byte() = Encoding.UTF8.GetBytes(jsonBody)
        '    request.Method = "POST"
        '    request.ContentType = "application/json"
        '    request.ContentLength = data.Length
        '    Dim stream As Stream = request.GetRequestStream()
        '    stream.Write(data, 0, data.Length)
        '    stream.Close()
        '    response = request.GetResponse()
        '    Dim sr As New StreamReader(response.GetResponseStream())

        'Catch ex As Exception

        'End Try

        'Try
        '    Using client As New HttpClient()
        '        Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
        '        Dim response = client.PostAsync(url, content).GetAwaiter().GetResult()
        '        response.EnsureSuccessStatusCode()

        '        Dim result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
        '        MessageBox.Show("Respuesta del flujo: " & result)
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("Error: " & ex.Message)
        'End Try

        Try
            Using client As New HttpClient()

                '                jsonBody = "[
                '  {
                '    ""CountryRegion"": ""GTM"",
                '    ""TaxExemptNumber"": ""1000669921"",
                '    ""CompanyCode"": ""DMAR"",
                '    ""CompanyName"": ""GRUPO PRUEBA umbrigth"",
                '    ""TipoDocumentoIdentificacion"": ""5""
                '  },
                '  {
                '    ""CountryRegion"": ""GTM"",
                '    ""TaxExemptNumber"": ""1000669922"",
                '    ""CompanyCode"": ""DMAR"",
                '    ""CompanyName"": ""GRUPO PRUEBA umbrigth2"",
                '    ""TipoDocumentoIdentificacion"": ""5""
                '  }
                ']"
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

                Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                Dim response = client.PostAsync(url, content).GetAwaiter().GetResult()

                Dim body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()

                ' No forzar éxito: mostramos diagnóstico
                'MessageBox.Show($"Status: {(CInt(response.StatusCode))} {response.StatusCode}" & vbCrLf &
                '                $"Reason: {response.ReasonPhrase}" & vbCrLf &
                '                $"Body: {body}")
            End Using
        Catch ex As Exception

        End Try
    End Sub



    Private Sub crearProveedor(pdt As DataTable, psEmpresa As String)
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow = pdt.Rows(0)
        'Dim fcrud As New FlexLine_CRUD.

        Try



            Dim lsnuevoctate = dr.Item("nitEmisor").ToString.Substring(0, dr.Item("nitEmisor").ToString.Trim.Length - 1)
            If lsnuevoctate.ToString.Length > 10 Then 'Es DPI
                lsnuevoctate = dr.Item("nitEmisor").ToString
            End If

            lsSQL = "pa_ins_um_ctacte_tipoctacte '" &
                        psEmpresa & "','PROVEEDOR','" &
                        lsnuevoctate & "','" &
                        dr.Item("nitEmisor").ToString & "','" &
                        dr.Item("RazonEmisor").ToString & "','30 CREDITO','','" &
                        dr.Item("municipioEmisor").ToString & " " & dr.Item("departamentoEmisor").ToString & "','" &
                        dr.Item("municipioEmisor").ToString & "','" & dr.Item("departamentoEmisor").ToString & "','GUATEMALA','" &
                        "','','','','root'"


            clsGen.insertQuery("Flexline", lsSQL)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub


    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Try
            mostrarLiquidacionTeams(dgvListado.Item("correo", e.RowIndex).Value.ToString, dgvListado.Item("periodo", e.RowIndex).Value.ToString, dgvListado.Item("empresa", e.RowIndex).Value.ToString)
            Me.TabControl1.SelectedTab = Me.TabPage1
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_Convertir_Click(sender As Object, e As EventArgs) Handles btn_Convertir.Click


        Try
            If MessageBox.Show("Esta Seguro De Procesar esta Liquidacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'gs_usuario = "RPINEDA"
                'gs_nombre_usuario = "ROSA ELENA PINEDA"
                Crea_Lote()
                EnviarAviso()

                'MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarPantalla()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub limpiarPantalla()

        Try
            dgv_Detalle.DataSource = Nothing
            Me.lblCorreo.Text = String.Empty
            Me.lblMonto.Text = "0.00"
            Me.lb_registros.Text = "0"
            Me.lblNumeroLiquidacion.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Crea_Lote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtProductos As DataTable
        Dim dr2 As DataRow


        Try
            dtProductos = dgv_Detalle.DataSource
            otrans.open()    'abre conexion

            lsSQL = "spa_Cajas_chicas_Correlativo_M '" & dtProductos.Rows(0).Item("Empresa").ToString & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            For Each dr As DataRow In dt.Rows
                Me.lblNumeroLiquidacion.Text = dr.Item("Lote")
            Next


            For Each drv As DataRowView In dtProductos.DefaultView
                If drv.Item("Producto").ToString <> Nothing Then
                    'If drv.Item("pequeno_contribuyente") = 0 Then '(c) 20230512 Las facturas de pequeño contribuyente no deben afectar el Lote

                    lsSQL = "exec spa_Guarda_Cajas_Chicas_M_U '" & drv.Item("empresa").ToString & "','" & Me.lblNumeroLiquidacion.Text & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("Fecha").ToString & "','" &
                            drv.Item("Numero").ToString & "','" & drv.Item("Proveedor").ToString & "','" & drv.Item("Responsable").ToString & "','" & drv.Item("Factura_Serie").ToString & "','" &
                            drv.Item("Monto").ToString & "','" & drv.Item("Renta").ToString & "','" & drv.Item("Producto").ToString & "','" & drv.Item("Item").ToString & "','" & drv.Item("centro_costo").ToString & "','" & drv.Item("Iva_Clase").ToString & "','" &
                            drv.Item("Exento").ToString & "','" & ("Lote: " & Me.lblNumeroLiquidacion.Text & ", " & drv.Item("Glosa").ToString) & "','" & drv.Item("Combustible").ToString & "','" & drv.Item("Galones").ToString & "','" & drv.Item("SubTotal").ToString & "','" &
                            gs_usuario & "'"

                    clsGen.insertQuery("FlexLine", lsSQL)
                    'End If
                End If
            Next
            Reporte(dtProductos.Rows(0).Item("Empresa"))
            If MessageBox.Show("Desea Imprimir Listado de Facturas", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ReporteFel(dtProductos.Rows(0).Item("Empresa"))
            End If

            If MessageBox.Show("Proceso Finalizado !!, Desea Trasladar a FlexLine", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Sincroniza_Flexline(dtProductos.Rows(0).Item("Empresa"))
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Reporte(psEmpresaResponsable As String)
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "\Finanzas\Contabilidad\Jefatura\Informe De Cajas Chicas Multiple.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = psEmpresaResponsable

            pm_parametros(1) = "@Lote"
            pm_valores(1) = Me.lblNumeroLiquidacion.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

            Carga_imagenes_recibos()

        End Try

    End Sub



    Private Sub ReporteFel(psEmpresaResponsable As String)
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("VDATASERVER")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "\Finanzas\Contabilidad\Jefatura\Impresion Facturas Sat.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = psEmpresaResponsable

            pm_parametros(1) = "@Lote"
            pm_valores(1) = Me.lblNumeroLiquidacion.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try


    End Sub

    Private Sub Carga_imagenes_recibos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsNumero As String = ""
        Dim lsEmpresa As String = ""
        Dim lsTipoDocto As String = ""
        Dim lbEncontrado As Boolean = False
        Dim path_imagenes As String = ""

        Try

            ' Buscar en el DataGridView la fila donde TipoDocto = "Recibo"
            For Each row As DataGridViewRow In dgv_Detalle.Rows

                If row.Cells("tipodocto").Value.ToString = "FACTURAS EXENTAS" Then

                    lsNumero = row.Cells("numero").Value.ToString
                    lsEmpresa = row.Cells("empresa").Value.ToString
                    lsTipoDocto = "Recibo"
                    lbEncontrado = True


                    Dim lsSQL As String
                    lsSQL = " select PDF_link from dbo.liquidaciones_gastos where tipoDocto = 'Recibo' " &
                     " and No_factura = '" & lsNumero & "' and Empresa = '" & lsEmpresa & "'"

                    dt = clsGen.selectQuery("RegionalDBintOut", lsSQL)

                    path_imagenes = dt.Rows(0).Item("PDF_link").ToString

                    Try
                        ' Abrir el archivo con el navegador predeterminado
                        Process.Start(New ProcessStartInfo With {
                     .FileName = path_imagenes,
                     .UseShellExecute = True
                         })
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                End If

            Next

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub EnviarAviso()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim lsCorreoAprobacion As String = String.Empty


        Try

            lsSQL = "pa_sel_um_sg_usuario_simple '" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)


            If dt.Rows.Count > 0 Then
                lsCorreoAprobacion = dt.Rows(0).Item("cuenta_office").ToString
            End If


            dt = Me.dgv_Detalle.DataSource

            For Each dr As DataRow In dt.Rows

                lsSQL = "pa_upd_um_liquidaciones_gastos_liquidado '" &
                    Me.lblCorreo.Text & "','" &
                    dr.Item("Numero").ToString & "','" &
                    dr.Item("factura_serie").ToString & "','" &
                    Me.lblNumeroLiquidacion.Text & "','" &
                    gs_usuario & "','" &
                    lsCorreoAprobacion & "'"

                clsGen.insertQuery("RegionalDBintOut", lsSQL)

            Next
            Dim lsResponsable As String = dt.Rows(0).Item("Responsable").ToString
            dt = clsGen.Fecha_Servidor("FlexLine")
            Dim lsCuerpoMensaje As String = "Nombre :" & lsResponsable & "|" &
                    "No. de Doctos :" & Me.lb_registros.Text & "|" &
                    "Monto:" & Me.lblMonto.Text & "|" &
                    "Recibido Por :" & gs_nombre_usuario & "|" &
                    "Fecha :" & dt.Rows(0).Item("Fecha_Actual")

            enviarAvisoTeams("Liquidacion de Gastos No. " & Me.lblNumeroLiquidacion.Text, lsCuerpoMensaje, Me.lblCorreo.Text)



            'lsSQL = "pa_ins_um_bot_avisos_teams '" &
            '        "Liquidacion_Combustible_" & Me.lblNumeroLiquidacion.Text & "','" &
            '        Me.lblCorreo.Text & "','UMBRIGHT','" &
            '        "Recepcion de Liquidacion de Gastos No. " & Me.lblNumeroLiquidacion.Text & "','" &
            '        "Nombre :" & lsResponsable & "|" &
            '        "No. de Doctos :" & Me.lb_registros.Text & "|" &
            '        "Monto:" & Me.lblMonto.Text & "|" &
            '        "Recibido Por :" & gs_nombre_usuario & "|"



            'dt = clsGen.Fecha_Servidor("FlexLine")
            'lsSQL = lsSQL & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "'"
            'clsGen.insertQuery("RegionalDBintOut", lsSQL)


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub



    Private Sub frm_liquidacion_caja_chica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click

        Dim iSelectedRow As Integer

        Try
            If Me.txtGlosa.Text.Length > 0 Then
                If MessageBox.Show("Esta Seguro de Asignar Glosa", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then




                    iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected)

                    For i As Integer = 0 To iSelectedRow

                        Me.dgv_Detalle.Item("Glosa", Me.dgv_Detalle.SelectedRows(i).Index).Value = Me.txtGlosa.Text

                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRecibirParcial_Click(sender As Object, e As EventArgs) Handles btnRecibirParcial.Click


        Dim iSelectedRow As Integer
        Dim lnRegistros As Integer = 0
        Dim ldMonto As Double = 0

        Try

            iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1
            For i As Integer = 0 To iSelectedRow
                lnRegistros += 1
                ldMonto += Me.dgv_Detalle.Item("Monto", Me.dgv_Detalle.SelectedRows(i).Index).Value
            Next


            If MessageBox.Show("Esta Seguro de Continuar " & Chr(13) & lnRegistros & " Documentos " & Chr(13) & ldMonto & " Monto a Recibir", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Me.lb_registros.Text = lnRegistros
                Me.lblMonto.Text = ldMonto
                Crea_Lote_Parcial()
                EnviarAviso_Parcial()

                limpiarPantalla()
            End If



        Catch ex As Exception

        End Try




    End Sub

    Private Sub Sincroniza_Flexline(psEmpresaOperar As String)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql0 As String
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion
            ls_sql = "select empresa, tipodocto, Fecha, Numero, Proveedor, Centro_costo Ccosto from scm.flexline.con_cajas_chicas_M where empresa='" & psEmpresaOperar & "' and convertido = 0 and lote= '" & Me.lblNumeroLiquidacion.Text & "'"
            dt = Otrans.Obtiene(ls_sql)  'obtiene o ejecuta el procedimiento para extraer los datos


            For Each dr As DataRow In dt.Rows

                ls_sql2 = "pa_vb_ins_Cajas_Chicas_M '" & psEmpresaOperar & "','" & Me.lblNumeroLiquidacion.Text & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "'"
                Otrans.Actualiza(ls_sql2)

                ls_sql0 = "SCM.flexline.pa_vb_ins_Cajas_Chicas_M_Dist '" & Me.lblNumeroLiquidacion.Text & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & dr.Item("Ccosto").ToString & "'"
                Otrans.Obtiene(ls_sql0)


                'lb_Mensaje.Text = "Mensajes"
                ls_sql2 = "spa_Convierte_Doctos_aCajasChicas_M '" & psEmpresaOperar & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & Me.lblNumeroLiquidacion.Text & "'"
                Otrans.Obtiene(ls_sql2)

                'Total()
            Next

            '           Muestra_Facturas()
            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Reporte()  (c) 20230517 ya se genera previamente
            'Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Ocurrio un Problema Al Trasladar Documentos a FLEXLINE, Verifique!!")
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Total()
        Dim ntotal As Double
        Dim niva As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try


            '    Otrans.open()   'abre conexion
            'dt = Me.dgv_Detalle.DataSource

            'ntotal = dt.Compute("sum(SubTotal)", "SubTotal>0")
            '  niva = dt.Compute("sum(Iva)", "Iva>0")
            'Me.lb_Total.Text = Format(ntotal, "###,##0.00")
            'Me.lb_Iva.Text = Format(Math.Round(ntotal / 1.12 * 0.12, 2), "###,##0.00")
            '    Me.tb_Monto.Text = Format(ntotal, "###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Sub
    '(c) 20230403
    Private Sub Crea_Lote_Parcial()
        'Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtProductos As DataTable
        Dim iSelectedRow As Integer
        'Dim dr2 As DataRow


        Try
            'dtProductos = dgv_Detalle.DataSource
            '   otrans.open()    'abre conexion

            iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1


            lsSQL = "spa_Cajas_chicas_Correlativo_M '" & Me.dgv_Detalle.Item("Empresa", Me.dgv_Detalle.SelectedRows(iSelectedRow).Index).Value.ToString & "','" & gs_usuario & "'"
            'dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            dt = clsGen.selectQuery("SCM", lsSQL)
            For Each dr As DataRow In dt.Rows
                Me.lblNumeroLiquidacion.Text = dr.Item("Lote")
            Next


            'For Each drv As DataRowView In dtProductos.DefaultView
            'En el Lote no debo incluir las facturas de pequeño contiribuyente
            For i As Integer = 0 To iSelectedRow
                If Me.dgv_Detalle.Item("Producto", Me.dgv_Detalle.SelectedRows(iSelectedRow).Index).Value.ToString <> Nothing Then

                    'If Me.dgv_Detalle.Item("pequeno_contribuyente", Me.dgv_Detalle.SelectedRows(i).Index).Value = 0 Then


                    lsSQL = "exec spa_Guarda_Cajas_Chicas_M_U '" & Me.dgv_Detalle.Item("Empresa", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" & Me.lblNumeroLiquidacion.Text & "','" &
                        Me.dgv_Detalle.Item("TipoDocto", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Fecha", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Numero", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Proveedor", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Responsable", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Factura_Serie", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Monto", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Renta", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Producto", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Item", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Centro_Costo", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Iva_Clase", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Exento", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                         "Liq: " & Me.lblNumeroLiquidacion.Text & " " & Me.dgv_Detalle.Item("Glosa", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Combustible", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Galones", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        Me.dgv_Detalle.Item("Subtotal", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                        gs_usuario & "'"

                    clsGen.insertQuery("FlexLine", lsSQL)

                End If
            Next
            Reporte(Me.dgv_Detalle.Item("empresa", Me.dgv_Detalle.SelectedRows(0).Index).Value.ToString)

            If MessageBox.Show("Proceso Finalizado !!, Desea Trasladar a FlexLine", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Sincroniza_Flexline(Me.dgv_Detalle.Item("empresa", Me.dgv_Detalle.SelectedRows(0).Index).Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '  otrans.close()
            '   otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub EnviarAviso_Parcial()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim lsCorreoAprobacion As String = String.Empty
        Dim iSelectedRow As Integer


        Try

            lsSQL = "pa_sel_um_sg_usuario_simple '" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)


            If dt.Rows.Count > 0 Then
                lsCorreoAprobacion = dt.Rows(0).Item("cuenta_office").ToString
            End If


            'dt = Me.dgv_Detalle.DataSource

            iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1
            'For Each drv As DataRowView In dtProductos.DefaultView
            For i As Integer = 0 To iSelectedRow
                'For Each dr As DataRow In dt.Rows


                lsSQL = "pa_upd_um_liquidaciones_gastos_liquidado '" &
                    Me.lblCorreo.Text & "','" &
                    Me.dgv_Detalle.Item("Numero", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                    Me.dgv_Detalle.Item("Factura_Serie", Me.dgv_Detalle.SelectedRows(i).Index).Value.ToString & "','" &
                    Me.lblNumeroLiquidacion.Text & "','" &
                    gs_usuario & "','" &
                    lsCorreoAprobacion & "'"

                clsGen.insertQuery("RegionalDBintOut", lsSQL)

            Next


            Dim lsResponsable As String = Me.dgv_Detalle.Item("responsable", Me.dgv_Detalle.SelectedRows(0).Index).Value.ToString

            dt = clsGen.Fecha_Servidor("FlexLine")
            Dim lsCuerpoMensaje As String = "Nombre :" & lsResponsable & "|" &
                    "No. de Doctos :" & Me.lb_registros.Text & "|" &
                    "Monto:" & Me.lblMonto.Text & "|" &
                    "Recibido Por :" & gs_nombre_usuario & "|" &
                    "Fecha :" & dt.Rows(0).Item("Fecha_Actual")

            enviarAvisoTeams("Liquidacion de Gastos No. " & Me.lblNumeroLiquidacion.Text, lsCuerpoMensaje, Me.lblCorreo.Text)



            'lsSQL = "pa_ins_um_bot_avisos_teams '" &
            '        "Liquidacion_Combustible_" & Me.lblNumeroLiquidacion.Text & "','" &
            '        Me.lblCorreo.Text & "','UMBRIGHT','" &
            '        "Recepcion de Liquidacion de Gastos No. " & Me.lblNumeroLiquidacion.Text & "','" &
            '        "Nombre :" & lsResponsable & "|" &
            '        "No. de Doctos :" & Me.lb_registros.Text & "|" &
            '        "Monto:" & Me.lblMonto.Text & "|" &
            '        "Recibido Por :" & gs_nombre_usuario & "|"




            'lsSQL = lsSQL & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "'"
            'clsGen.insertQuery("RegionalDBintOut", lsSQL)


        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
            clsGen.Escribir_Log(ex.Message)
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub enviarAvisoTeams(psEncabezado As String, psCuerpoMensaje As String, psCorreo As String)

        Dim clsGen As New ClasesGenerales.General


        Try


            'Dim varMensajeAEnviar As String = "Empresa : " & psEmpresa & "|" &
            '    "Tipo    : " & psTipoDocto & "|" &
            '    "Numero  : " & psNumero & "|" &
            '    "Cliente : " & psCtate & "-" & psRazonSocial & "|" &
            '    "Fecha   :" & psFecha & "|" &
            '    "Comentario :" & psComentario


            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & psCorreo & """,
              ""Motivo"": """ & psEncabezado & """,
              ""Mensaje_a_enviar"": """ & psCuerpoMensaje & """
            }"
            Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            response = request.GetResponse()
            Dim sr As New StreamReader(response.GetResponseStream())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_Detalle_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv_Detalle.RowStateChanged

        Try


            If e.StateChanged = DataGridViewElementStates.Selected Then
                Dim iSelectedRow As Integer
                Dim ldMonto As Double = 0
                iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1

                Me.lblDocumentosSeleccionados.Text = iSelectedRow + 1
                Me.lblMontoDocumentosSeleccionados.Text = 0
                For i As Integer = 0 To iSelectedRow
                    ldMonto += Me.dgv_Detalle.Item("Monto", Me.dgv_Detalle.SelectedRows(i).Index).Value
                Next

                Me.lblMontoDocumentosSeleccionados.Text = ldMonto
                'MessageBox.Show("Test")
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtfitro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfitro.KeyPress

        If e.KeyChar = Chr(27) Then
            'Me.dgvListado.Rows.
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress



        If e.KeyChar = Chr(13) Then
            If txtBuscar.Text.Length > 4 Then


                Dim lsSQL As String
                Dim dt As DataTable
                Dim clsGen As New ClasesGenerales.General
                Try

                    lsSQL = " pa_var_um_liquidaciones_gastos_busqueda '" & Me.txtBuscar.Text & "'"
                    dt = clsGen.selectQuery("RegionalDBintOut", lsSQL)
                    Me.dgvBusqueda.DataSource = dt
                    clsGen.Alinear_GridView(dt, Me.dgvBusqueda, "", "", "", "", True, True, 250, 0)

                Catch ex As Exception

                End Try
            Else
                Me.dgvBusqueda.DataSource = Nothing
            End If

        End If
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub dgv_Detalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_Detalle.CellPainting
        ' ivate Sub() dgv_encabezado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_encabezado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_Detalle.Rows(rowIndex)
                'If lpedidos_posfechados Then ''Pedidos Posfechados
                If Me.dgv_Detalle.Item("pequeno_contribuyente", rowIndex).Value = 1 Then
                    'If Me.dgv_encabezado.Item("ControlTemporal", rowIndex).Value.ToString.Length = 10 Then
                    '    Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                    'ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 1 Then
                    '    Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    'ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 3 Then
                    Me.dgv_Detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    '    End If
                    'Else
                    '    Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                    'End If


                    'value = Data("porcentajeasignado").ToString
                    'value2 = Data("dias").ToString
                    ''Try
                    'value4 = 0
                    'value3 = Data("ControlTemporal").ToString
                    'If value3.Trim.Length = 10 Then
                    '    value4 = Int64.Parse(value3)
                    '    '       MessageBox.Show(value3)
                    'End If

                    ''Catch ex As Exception
                    ''value4 = 0
                    ''End Try





                    'If Double.Parse(value.ToString) = 0 Then
                    '    If Int64.Parse(value4.ToString) > 0 Then
                    '        e.RowColor = Color.Green
                    '    ElseIf Int64.Parse(value2) < 1 Then
                    '        e.RowColor = Color.Red
                    '    ElseIf Int64.Parse(value2) < 3 Then
                    '        e.RowColor = Color.Blue
                    '    End If
                    'Else
                    '    e.RowColor = Color.Green
                    'End If
                    '    ElseIf lanular_memos Then


                    'Else ''Pedidos
                    '    If Me.dgv_encabezado.Item("porcentajeasignado", rowIndex).Value = 0 Then
                    '        If Me.dgv_encabezado.Item("aprobacion", rowIndex).Value.ToString.ToLower = "n" Then
                    '            Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    '        Else
                    '            If Me.dgv_encabezado.Item("comentario2", rowIndex).Value.ToString.Length > 0 Then
                    '                Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Purple
                    '            Else
                    '                Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    '            End If
                    '        End If
                    '    ElseIf Me.dgv_encabezado.Item("porcentajeasignado", rowIndex).Value < 100 Then
                    '        Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                    '    End If

                    '    therow = Me.dgv_encabezado.Rows(rowIndex)
                    '    If Me.dgv_encabezado.Item("minutos", rowIndex).Value > 30 And Me.dgv_encabezado.Item("minutos", rowIndex).Value < 61 Then
                    '        therow.Cells("minutos").Style.BackColor = Color.Yellow
                    '    ElseIf Me.dgv_encabezado.Item("minutos", rowIndex).Value > 60 Then
                    '        therow.Cells("minutos").Style.BackColor = Color.LightCoral
                    '    End If
                    '    If Me.dgv_encabezado.Item("cedi", rowIndex).Value.ToString.ToLower.Length > 0 Then
                    '        Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                    '    End If

                End If


            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAplicarResponsable_Click(sender As Object, e As EventArgs) Handles btnAplicarResponsable.Click
        Dim iSelectedRow As Integer
        Try
            If Me.txtResponsable.Text.Length > 0 Then


                If MessageBox.Show("Esta Seguro de Asignar Responsable", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected)

                    For i As Integer = 0 To iSelectedRow

                        Me.dgv_Detalle.Item("responsable", Me.dgv_Detalle.SelectedRows(i).Index).Value = Me.txtResponsable.Text.ToUpper

                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAplicarFecha_Click(sender As Object, e As EventArgs) Handles btnAplicarFecha.Click
        Dim iSelectedRow As Integer

        Try
            If Me.dtpFecha.Value < Now Then
                If MessageBox.Show("Esta Seguro de Asignar Fecha", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then




                    iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected)

                    For i As Integer = 0 To iSelectedRow

                        Me.dgv_Detalle.Item("fecha", Me.dgv_Detalle.SelectedRows(i).Index).Value = Me.dtpFecha.Value.Date

                    Next
                End If
            Else
                MessageBox.Show("No puede asignar la fecha seleccionada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

    End Sub
End Class