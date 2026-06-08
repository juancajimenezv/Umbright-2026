Imports System.Collections
Imports System.Drawing.Printing
Imports System.IO
'Imports Microsoft.Office.Interop.Excel
Public Class frm_automatizarTransporteGuia
    Public pdt As DataTable
    'Public dgvFacturasAsignadas As DataGridView

    Private Sub llenarCombo(ByVal conexion As Transaccional.Conexion, ByVal ls_sql As String, ByVal tableName As String, ByVal displaymember As String, ByVal valuemember As String, ByVal cmb As ComboBox,
                            psFiltro As String, psValoresUnicos As String)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        conexion.open()
        dt = conexion.Obtiene(ls_sql)
        conexion.close()

        If psValoresUnicos.Length > 5 Then
            dt = clsGen.ValoresDistinto(dt, psValoresUnicos.Split(","))
        End If
        If psFiltro.Length > 5 Then
            dt.DefaultView.RowFilter = psFiltro

        End If


        dt.TableName = tableName
        cmb.DisplayMember = displaymember
        cmb.ValueMember = valuemember
        cmb.DataSource = dt.DefaultView

        dt = Nothing

        'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        'Me.cmb_vehiculo.DisplayMember = "CODIGO"
        'Me.cmb_vehiculo.ValueMember = "CODIGO"

    End Sub


    Private Sub llenarCombo()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try

            llenarCombo(Otrans, "pa_sel_um_rutas_transporte", "rutas", "codigo", "codigo", cmbRutaFinal, "", "")
            llenarCombo(Otrans, "pa_sel_um_vehiculos_disponibles '" & dtpControl.Text & "' ", "vehiculos", "codigo", "codigo", cmbVehiculos, "", "")
            llenarCombo(Otrans, "pa_sel_um_gen_tabcod NULL,'GEN_PILOTO'", "pilotos", "codigo", "codigo", cmbPiloto, "vigencia <> 'N'", "codigo,vigencia")
            llenarCombo(Otrans, "pa_sel_um_gen_tabcod NULL,'GEN_AUXILIAR'", "auxiliares", "codigo", "codigo", cmbAuxiliar, "vigencia <> 'N'", "codigo,vigencia")
        Catch ex As Exception
        Finally

            Otrans = Nothing
        End Try

    End Sub

    Private Function documentosPreparados() As Boolean

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dtResultado As DataTable

        Dim lbContinuarconelProceso As Boolean = vbFalse


        Try
            lbContinuarconelProceso = vbTrue
            For Each dr As DataRow In pdt.Rows

                lsSQL = String.Format("pa_sel_um_pwa_ruta_piloto_picking  '{0}', '{1}', '{2}'",
                                      dr.Item("empresa"), dr.Item("tipodocto").ToString, dr.Item("numero").ToString)

                dtResultado = clsGen.selectQuery("SCM", lsSQL)
                If dtResultado.Rows.Count = 0 Then
                    If MessageBox.Show("El Documento " & dr.Item("empresa") & "-" & dr.Item("tipodocto").ToString & "-" & dr.Item("numero").ToString & " No Esta Preparado, Desea Continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        lbContinuarconelProceso = vbFalse
                    End If
                End If



            Next
        Catch ex As Exception
            lbContinuarconelProceso = vbFalse
        Finally
            clsGen = Nothing
        End Try




        Return lbContinuarconelProceso

    End Function



    Private Sub Procesar()
        Dim dt1 As DataTable
        Dim listadoEmpresas As New ArrayList()
        Dim numeroControl, ptipo_guia, numTransporte, ls_periodo As String
        Dim existeControl As Boolean = False
        Dim ldfecha As Date
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql, ls_sql2 As String
        Dim dt As DataTable
        Dim clsgls As New ClasesGenerales.General

        Try

            If documentospreparados Then




                Otrans.open()
                ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_TIPOGUIA',NULL"
                dt = Otrans.Obtiene(ls_sql)
                ptipo_guia = dt.Rows(0).Item("descripcion").ToString

                ls_sql = "pa_sel_um_numero_control_transporte_corporativo '" & ptipo_guia & "'"

                dt = Otrans.Obtiene(ls_sql)
                numTransporte = CInt(dt.Rows(0).Item("numero")) + 1



                numTransporte = numTransporte.PadLeft(10, "0").Trim
                clsgls.Escribir_Log("Numero de Transporte Generado " & numTransporte)
                lbl_numero.Text = numTransporte
                'Termina obtención del número de transporte
                'Si ya existía, solo hay que ir a buscarlo.


                For Each dr As DataGridViewRow In dgvFacturasAsignadas.Rows
                    If (listadoEmpresas.IndexOf(dr.Cells("empresa").Value.ToString) < 0) Then
                        ' Si es menor que cero, no existen, por lo que se agregará
                        listadoEmpresas.Add(dr.Cells("empresa").Value.ToString)
                    End If
                Next

                'Genera el período
                ldfecha = Me.dtpControl.Value
                ls_periodo = ldfecha.Year & ldfecha.Month.ToString.PadLeft(2, "0")


                'Se tiene que crear el control de transporte


                ' guarda en tabla documento
                ' Si ya existía, no se ingresa este registro

                'Guarda los controles por empresa
                For Each empresaI As String In listadoEmpresas

                    ls_sql = "pa_ins_um_control_transporte '" & empresaI & "','" &
                                     ptipo_guia & "','" & numTransporte & "','" &
                                     Me.dtpControl.Text & "','" & Me.dtpVencimiento.Text & "','" &
                                     Me.cmbPiloto.Text & "','" & Me.cmbVehiculos.Text & "','" &
                                     Me.cmbAuxiliar.Text & "'," & Double.Parse(Me.lblMonto.Text) & "," &
                                    "12,'S','" & ls_periodo & "','" & Me.cmbRutaFinal.Text & "','"

                    ls_sql2 = Me.txObservaciones.Text & "','" &
                                    gs_usuario & "',null,'" &
                                    IIf(Me.chkTiempoExtra.CheckState = CheckState.Checked, "SI", "NO") & "'"


                    Otrans.Ingresa(ls_sql & ls_sql2)
                Next

                If Otrans.Codigo_error = 0 Then


                    Otrans.close()


                    'para cada fila hay que agregar el control de transporte
                    'y hacer el insert del nuevo control de transporte

                    For Each dgrv As DataGridViewRow In dgvFacturasAsignadas.Rows
                        'Hay que ver si la row que se está leyendo tiene seleccionada la columna
                        If (dgrv.Cells("Seleccionar").Value) Then
                            'si está seleccionada significa que hay que agregarla al control de transporte actual
                            ls_sql = "pa_upd_um_agregar_control_transporte '" & dgrv.Cells("empresa").Value.ToString & "', '" &
                                dgrv.Cells("TipoDocto").Value.ToString & "', '" & dgrv.Cells("numero").Value.ToString & "', '" &
                                numTransporte & "'"
                            clsgls.dbQuery("flexline", ls_sql, "UPDATE")
                            clsgls.Escribir_Log(ls_sql)
                        End If

                    Next

                    MessageBox.Show("Guía guardada correctamente", "Guardada", MessageBoxButtons.OK)
                    '(c) 20241218 imprimira directo
                    'limpiar()
                    'If MessageBox.Show("Desea Imprimir Control", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Imprimir_Control(numTransporte)
                    ' End If

                    'If MessageBox.Show("Desea Imprimir Documentos", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    imprimirDocumentos(True)
                    'End If


                End If
            End If
        Catch ex As Exception
        Finally
            'limpiar()
        End Try
    End Sub




    Public Sub Imprimir_Control(psNumeroControl As String)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General


        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            'path_reporte += "Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            'path_reporte += "Logistica\Trafico\Guía del Liquidador Global 2005 Corporativa.rpt"
            path_reporte += "Logistica\Trafico\Guía del Liquidador Global citizen.rpt"
            '  pm_parametros(0) = "empresa"
            pm_parametros(0) = "Numero de Documento"
            pm_valores(0) = psNumeroControl

            '(c) 20150601

            For i As Integer = 1 To Me.NUDcopias.Value
                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", False, "", True, 1)
            Next


        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try


    End Sub


    Private Sub realizarCalculos()

        Dim sumar As Double

        Dim clsGen As New ClasesGenerales.General
        Try

            Me.lblPeso.Text = pdt.Compute("sum(Peso)", "Peso>0")
            Me.lblVolumen.Text = pdt.Compute("sum(Volumen)", "Volumen>0")
            Me.lblMonto.Text = pdt.Compute("sum(Total)", "Total>0")
            'de kgs a toneladas

            clsGen.Alinear_GridView(pdt, dgvFacturasAsignadas, "", ",seleccionar,", "", "", "", ",empresa=38,tipodocto=50,", "", True, True, 200, 10)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub frm_automatizarTransporteGuia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombo()
        realizarCalculos()
        actualizarformaPagofacturas()
        actualizarAnexos()


    End Sub


    Private Sub ActualizarAnexos()
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Dim nuevaColumna As New DataColumn("anexo", GetType(String))


            pdt.Columns.Add(nuevaColumna)

            For Each dr As DataRow In pdt.Rows
                dr.Item("anexo") = String.Empty
                If dr.Item("tipodocto").ToString.StartsWith("FEL") Then
                    lsSQL = "pa_var_um_cliente_anexo_transporte '" & dr.Item("empresa").ToString & "','" & dr.Item("ctacte").ToString & "'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    Try


                        If dt.Rows.Count > 0 Then
                            dr.Item("anexo") = dt.Rows(0).Item("anexo").ToString
                        End If
                    Catch ex As Exception

                    End Try
                End If

            Next

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub actualizarformaPagofacturas()
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Dim nuevaColumna As New DataColumn("forma_pago", GetType(String))


            pdt.Columns.Add(nuevaColumna)

            For Each dr As DataRow In pdt.Rows
                If dr.Item("tipodocto").ToString.StartsWith("FEL") Then
                    lsSQL = "pa_var_um_documentop '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        dr.Item("forma_pago") = dt.Rows(0).Item("codigoPago").ToString
                    End If


                End If

            Next

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub




    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Esta Seguro de Guardar el Control", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.btnSave.Enabled = False
            Procesar()
            'Si es DTT lo procesa de una vez, sin preguntar
            '(c) 20241218
            Valida_ruta_dtt()
        End If
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        'If Me.lbl_numero.Text.Length = 0 Then
        '    MessageBox.Show("Esta Seguro de Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        'End If
        If MessageBox.Show("Esta Seguro de Procesar, este proceso, creará el control de transporte ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.btnSave.Enabled = False


            If Me.lbl_numero.Text.Length = 0 Then

                Procesar()
            End If

            'Si es DTT lo procesa de una vez, sin preguntar
            '(c) 20241218
            Valida_ruta_dtt()

            '  imprimirDocumentos(True)
        End If
    End Sub



    Private Sub imprimirDocumentos(pbImprimirCompleto As Boolean)
        Dim lsnumeroOrden As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsRuta As String
        Dim dt As DataTable

        Dim pm_valores(3), pm_valores_consolidado(2) As String
        Dim pm_parametros(3) As String
        Dim pm_conexion(3) As String
        Dim ppath_reporte As String
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Dim pm_parametros2(2) As String
        Dim pm_valores2(2) As String
        Dim lbcontinuar As Boolean
        Dim ImprimirAviso As Boolean = False

        Try




            For Each dr As DataRow In pdt.Rows

                lbcontinuar = False

                If pbImprimirCompleto = True Then
                    lbcontinuar = True
                Else
                    lsSQL = String.Format("pa_sel_um_gen_log_documento_impresion  '{0}', '{1}', '{2}'",
                                          dr.Item("empresa"), dr.Item("tipodocto").ToString, dr.Item("numero").ToString)

                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count = 0 Then
                        lbcontinuar = True
                    End If
                End If


                Try
                    '(c) No Imprime reenvios
                    '(c) 20250121
                    If dr.Item("reenvio").ToString = "SI" Then
                        lbcontinuar = False
                    End If
                Catch ex As Exception

                End Try

                If lbcontinuar Then



                    'Imprimir Factura
                    If dr.Item("tipodocto").ToString.StartsWith("FEL") Then


                        Oaut.pnNumeroCopias = NUDcopias.Value


                        Try


                            pm_conexion = clsGen.Parametros_Conexion("")
                            ppath_reporte = clsGen.Path_Reporte

                            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

                            pm_parametros(0) = "empresa"
                            pm_parametros(1) = "tipodocto"
                            pm_parametros(2) = "numero"
                            pm_parametros(3) = "user_name"


                            ppath_reporte = clsGen.Path_Reporte
                            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                            ppath_reporte += dr.Item("empresa") + " "
                            ppath_reporte += dr.Item("tipodocto")
                            ppath_reporte += ".rpt"

                            pm_valores(0) = dr.Item("empresa")
                            pm_valores(1) = dr.Item("tipodocto")
                            pm_valores(2) = dr.Item("numero")
                            Try
                                pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo & " - " & Me.lbl_numero.Text & " - " & Me.cmbRutaFinal.Text
                            Catch ex As Exception
                                pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo
                            End Try



                            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        False, True, "PDF", True, "", True, Oaut.pnNumeroCopias)

                            lsSQL = "pa_ins_um_gen_log_documento_impresion '" & dr.Item("empresa") & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "','" & gs_nombre_equipo & "','frm_automatizartransporteguia'," & NUDcopias.Value

                            clsGen.insertQuery("FlexLine", lsSQL)

                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                        Finally

                        End Try
                        'Agregar quien imprimio

                        'Imprimir Recibo

                        Try

                            If dr.Item("forma_pago").ToString.StartsWith("CONT") Then

                                '(c) valido que exista el recibo

                                lsSQL = String.Format("spa_RecibosFC  '{0}', '{1}', {2}, '{3}'",
                                dr.Item("empresa"), dr.Item("tipodocto").ToString, vbNull, dr.Item("numero").ToString)

                                clsGen.insertQuery("FlexLine", lsSQL)


                                ppath_reporte = clsGen.Path_Reporte
                                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"


                                pm_conexion = clsGen.Parametros_Conexion("SCM")

                                pm_parametros2(0) = "Empresa"
                                pm_parametros2(1) = "Tipodocto"
                                pm_parametros2(2) = "Numero"


                                pm_valores2(0) = dr.Item("empresa")
                                pm_valores2(2) = dr.Item("numero")
                                pm_valores2(1) = dr.Item("tipodocto")


                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", True, "", True, 1) 'Oaut.pnNumeroCopias)

                                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", True, "", True, 1) 'Oaut.pnNumeroCopias)


                            End If
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                        End Try

                    ElseIf dr.Item("tipodocto").ToString.Equals("SALIDA POR TRASLADO") Then
                        Try


                            imprimir_traslado(dr.Item("empresa").ToString, dr.Item("tipodocto").ToString, dr.Item("numero").ToString)

                            lsSQL = String.Format("pa_upd_um_traslado_inv '{0}', '{1}'", dr.Item("empresa").ToString, dr.Item("numero").ToString)
                            clsGen.insertQuery("FlexLine", lsSQL)

                            lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}",
                                              dr.Item("empresa"), dr.Item("tipodocto").ToString, dr.Item("numero").ToString, gs_usuario, gs_nombre_equipo, "frm_automatizartransporteguia", NUDcopias.Value)

                            clsGen.insertQuery("FlexLine", lsSQL)
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                        End Try
                    ElseIf dr.Item("tipodocto").ToString.Equals("NOTA DE DEVOLUCION") Then
                        'debo obtener el correlativo
                        Try


                            Dim lsCodigoDevolucion As Integer
                            lsSQL = String.Format("pa_var_um_devolucion_numero '{0}', '{1}'", dr.Item("empresa").ToString, dr.Item("numero").ToString)
                            dt = clsGen.selectQuery("FlexLine", lsSQL)

                            If dt.Rows.Count > 0 Then
                                lsCodigoDevolucion = dt.Rows(0).Item("cod_devolucion")
                            End If


                            Imprimir_Devoluciones(dr.Item("empresa").ToString, lsCodigoDevolucion)
                            lsSQL = String.Format("pa_upd_um_devolucion_encabezado_trs '{0}', '{1}'", lsCodigoDevolucion, gs_usuario)
                            clsGen.insertQuery("FlexLine", lsSQL)

                            lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'",
                                              dr.Item("empresa"), dr.Item("tipodocto").ToString, dr.Item("numero").ToString, gs_usuario, gs_nombre_equipo, "frm_automatizartransporteguia", NUDcopias.Value)
                            clsGen.insertQuery("FlexLine", lsSQL)

                            'otrans.Actualiza("pa_upd_um_devolucion_encabezado_trs " & drv.Item("numero").ToString & ",'" & gs_usuario & "'")
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                        End Try
                    ElseIf dr.Item("tipodocto").ToString.StartsWith("CONSIG") Then
                        Try


                            imprimir_consignaciones(dr.Item("empresa").ToString, dr.Item("tipodocto").ToString, dr.Item("numero").ToString)
                            lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'",
                                              dr.Item("empresa"), dr.Item("tipodocto").ToString, dr.Item("numero").ToString, gs_usuario, gs_nombre_equipo, "frm_automatizartransporteguia", NUDcopias.Value)

                            clsGen.insertQuery("FlexLine", lsSQL)

                            'Habilitar Impresión de Consignaciones
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                        End Try

                    End If



                    'Imprimir Ordenes de Compra
                    Escribir_log("Revisando si hay Ordenes de Compra para Imprimir " & dr.Item("comentario").ToString)
                    If dr.Item("comentario").ToString.StartsWith("PDA-UNI") Then

                        Try

                            lsnumeroOrden = dr.Item("comentario").ToString.Split(",")(0)
                            lsnumeroOrden = lsnumeroOrden.Split(".")(1)

                            lsSQL = "pa_sel_um_mov_ctacte_unisuper '" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "'"
                            'dt = clsGen.selectQuery("Corporativo", lsSQL)
                            dt = clsGen.selectQuery("FlexLine", lsSQL)
                            lsnumeroOrden = dr.Item("empresa") & "_" & Integer.Parse(dt.Rows(0).Item("codigo_unisuper").ToString) & "_" & lsnumeroOrden & ".pdf"

                            lsRuta = clsGen.Path_Reporte() & "OrdenesUnisuper" ' & dr.Item("empresa") & "_" & Integer.Parse(dt.Rows(0).Item("codigo_unisuper").ToString) & "_" & lsnumeroOrden & ".pdf"


                            'Dim lsimpresora As String = clsGen.Obtener_XMLConfig("Impresora_transportes", False) '"\\NombreDelServidor\NombreDeImpresora" ' Cambia esto por el nombre de tu impresora

                            Escribir_log("Imprimiendo Orden de Compra Unisuper: " & lsnumeroOrden & " en ruta: " & lsRuta)

                            Dim proceso As Process = New Process





                            'Ejecutamos el proceso
                            proceso.StartInfo.WorkingDirectory = lsRuta
                            proceso.StartInfo.FileName = lsnumeroOrden
                            proceso.StartInfo.Verb = "print"

                            'El Path o la ubicacion del archivo

                            proceso.StartInfo.CreateNoWindow = True
                            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

                            proceso.Start()
                            proceso.WaitForExit(3000)
                            proceso = Nothing



                            ' Crear el objeto PrintDocument
                            'Dim printDoc As New PrintDocument()

                            '' Establecer la impresora específica
                            'printDoc.PrinterSettings.PrinterName = lsimpresora

                            '' Manejador del evento PrintPage
                            'AddHandler printDoc.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                            '                                   ' Leer el contenido del archivo
                            '                                   Dim contenido As String = File.ReadAllText(lsnumeroOrden)

                            '                                   ' Crear una fuente para el texto
                            '                                   Dim font As New Font("Arial", 12)

                            '                                   ' Dibujar el contenido del archivo en la impresora
                            '                                   e.Graphics.DrawString(contenido, font, Brushes.Black, 0, 0)
                            '                               End Sub

                            '' Imprimir el documento
                            'printDoc.Print()

                            'Console.WriteLine("El archivo se ha enviado a la impresora.")



                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)
                            clsGen.Escribir_Log(ex.Message)

                        End Try


                    End If
                    'Imprimir Ordenes de Compra
                    If dr.Item("anexo").ToString.Length > 5 Then
                        'lsnumeroOrden = dr.Item("comentario").ToString.Split(",")(0)
                        'lsnumeroOrden = lsnumeroOrden.Split(".")(1)

                        'lsSQL = "pa_sel_um_mov_ctacte_unisuper '" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "'"
                        'dt = clsGen.selectQuery("Corporativo", lsSQL)
                        'lsnumeroOrden = dr.Item("empresa") & "_" & Integer.Parse(dt.Rows(0).Item("codigo_unisuper").ToString) & "_" & lsnumeroOrden & ".pdf"
                        Try
                            lsRuta = clsGen.Path_Reporte() & "Anexos" ' & dr.Item("empresa") & "_" & Integer.Parse(dt.Rows(0).Item("codigo_unisuper").ToString) & "_" & lsnumeroOrden & ".pdf"


                            '    'mExcel.Visible = True
                            '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
                            'Catch ex As Exception

                            ' Dim lsimpresora As String = clsGen.Obtener_XMLConfig("Impresora_transportes", False) '"\\NombreDelServidor\NombreDeImpresora" ' Cambia esto por el nombre de tu impresora

                            Dim proceso As Process = New Process





                            'Ejecutamos el proceso
                            proceso.StartInfo.WorkingDirectory = lsRuta
                            proceso.StartInfo.FileName = dr.Item("anexo").ToString & ".pdf"
                            proceso.StartInfo.Verb = "print"

                            'El Path o la ubicacion del archivo

                            proceso.StartInfo.CreateNoWindow = True
                            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

                            proceso.Start()
                            proceso.WaitForExit(3000)
                            proceso = Nothing

                            Try


                            Catch ex As Exception
                                clsGen.Escribir_Log(ex.ToString)
                            End Try
                            'Console.WriteLine("El archivo se ha enviado a la impresora.")



                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.ToString)

                        End Try


                    End If

                End If

            Next


        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            clsGen = Nothing
            MessageBox.Show("Proceso de Impresión Finalizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub Imprimir_Devoluciones(ByVal spEmpresa As String, ByVal spOrdendeCompra As String)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Direccion Comercial\devoluciones.rpt"
            pm_parametros(0) = "@Pempresa"
            pm_parametros(1) = "@Pcod_devolucion"



            pm_valores(0) = spEmpresa
            pm_valores(1) = spOrdendeCompra



            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True, NUDcopias.Value)


        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try
    End Sub

    Private Sub imprimir_consignaciones(ByVal pEmpresa As String, ByVal pTipoDocto As String, ByVal pNumero As String)

        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            ''path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Finanzas\Facturacion\Consignaciones "
            path_reporte += pEmpresa & ".rpt"

            'path_reporte = "\\192.192.1.170\reportes$\Logistica\Bodega\Impresion de Movimientos.rpt"

            pm_parametros(0) = "Empresa"
            pm_parametros(2) = "tipoDocto"
            pm_parametros(1) = "Numero"
            pm_valores(0) = pEmpresa
            pm_valores(2) = pTipoDocto
            pm_valores(1) = pNumero
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True, NUDcopias.Value)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub imprimir_traslado(ByVal pEmpresa As String, ByVal pTipoDocto As String, ByVal pNumero As String)

        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            ''path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Logistica\Bodega\Impresion de Movimientos.rpt"

            'path_reporte = "\\192.192.1.170\reportes$\Logistica\Bodega\Impresion de Movimientos.rpt"

            pm_parametros(0) = "Empresa"
            pm_parametros(2) = "tipoDocto"
            pm_parametros(1) = "Numero"
            pm_valores(0) = pEmpresa
            pm_valores(2) = pTipoDocto
            pm_valores(1) = pNumero
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True, NUDcopias.Value)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub btnConsolidar_Click(sender As Object, e As EventArgs) Handles btnConsolidar.Click
        If MessageBox.Show("Esta Seguro de Procesar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.btnSave.Enabled = False
            If Me.lbl_numero.Text.Length = 0 Then
                Procesar()
            End If

            Valida_ruta_dtt()

        End If

    End Sub

    Private Sub Valida_ruta_dtt()
        'VALIDA SI LA RUTA ES DTT PARA CREAR PICKING CONSOLIDADO
        '-------------------------------------------------------
        If cmbRutaFinal.Text.ToString.StartsWith("DTT") Or cmbRutaFinal.Text.ToString.StartsWith("TEX") Then

            If lbl_numero.Text.Length <> 0 Then
                crea_picking_dtt()
            Else
                Exit Sub
            End If

        End If
    End Sub

    Private Sub crea_picking_dtt()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ' SE AGREGA RUTA 
            ls_sql = "pa_ins_um_pincking_consolidado_dtt '" & dtpControl.Text & "','" & gs_usuario & "','" & lbl_numero.Text & "','" & cmbRutaFinal.Text & "'"
            otrans.Ingresa(ls_sql)

            Imprimir_picking()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Imprimir_picking()
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            otrans.open()

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False

            Try
                'Obtengo Datos de Conexion
                pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                path_reporte = ClsGen.Path_Reporte

                path_reporte += "Logistica\Picking\Picking Consolidado DTT.rpt"

                pm_parametros(0) = "@Identificador"
                pm_valores(0) = CInt(lbl_numero.Text)

                For i As Integer = 1 To Me.NUDcopias.Value

                    lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                   pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                   False, True, "PDF", True, "", True, 1)
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btnImprimirParcial_Click(sender As Object, e As EventArgs) Handles btnImprimirParcial.Click
        If MessageBox.Show("Esta Seguro de Imprimir Documentos No Impresos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.btnSave.Enabled = False
            imprimirDocumentos(False)



            'Procesar()

        End If
    End Sub

    Private Sub dgvFacturasAsignadas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturasAsignadas.CellContentClick

    End Sub

    Private Sub dgvFacturasAsignadas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvFacturasAsignadas.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvFacturasAsignadas.Rows(rowIndex)


                'If Me.dgvFacturasAsignadas.Item("factura_costo", rowIndex).Value > 0 Then
                '    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.BackColor = Color.YellowGreen
                'End If
                If Me.dgvFacturasAsignadas.Item("reenvio", rowIndex).Value = "SI" Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSteelBlue
                End If

                If Me.dgvFacturasAsignadas.Item("impresiones", rowIndex).Value > 0 Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dgvFacturasAsignadas.Item("ubicacion_chequeo", rowIndex).Value.ToString.Length > 0 Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub
End Class