'Imports CRAXDRT
Imports System.Data
Imports System.IO

Module _Reporte_CraxDrt
    'Dim CrAp As CRAXDRT.Application
    'Dim CrRp As CRAXDRT.Report
    Dim pm_campos(50) As String
    Dim pm_valor(50) As String

    Sub _exportar_reporte_Clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal oPanel As Windows.Forms.Panel, _
                    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal exportar As Boolean, _
                    ByVal imprimir As Boolean, ByVal acciones As String, ByVal tipo_exportar As String, _
                    ByVal proceso_adicional As Array)

        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut._exportar_reporte(path_reporte, pm_parametros, oPanel, _
            _pServidor, _pBase_datos, _pUsuario, exportar, imprimir, acciones, tipo_exportar, proceso_adicional)
        If Oaut.Descripcion_Error.Length > 0 Then
            MessageBox.Show(Oaut.Descripcion_Error)
        End If



        'Dim Oaut As New Automatizacion.Reportes_CraxDrt(gs_empresa)
        'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)
        'If Oaut.Descripcion_Error.Length > 0 Then
        '    MessageBox.Show(Oaut.Descripcion_Error)
        'End If

        Oaut.finalizar()
        Oaut = Nothing


    End Sub


    'Sub _exportar_reporte_Clase_Proceso(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal oPanel As Windows.Forms.Panel, _
    '                ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal exportar As Boolean, _
    '                ByVal imprimir As Boolean, ByVal acciones As String, ByVal tipo_exportar As String, _
    '                ByVal proceso_adicional As Array)


    '    Try
    '        CrAp = New CRAXDRT.Application
    '        CrRp = New CRAXDRT.Report

    '        '_Inicializar_reporte_CRAXDRT_proceso(path_reporte, _pServidor, _pBase_datos, _pUsuario)
    '        CrRp = CrAp.OpenReport(path_reporte)
    '        CrRp.DiscardSavedData()
    '        Dim pwd As String

    '        If proceso_adicional(0) = 1 Then
    '            Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
    '            System.Threading.Thread.Sleep(1000)
    '        End If

    '        _procesar_reporte_CRAXDRT_Proceso(path_reporte, pm_parametros, oPanel, _pServidor, _pBase_datos, _pUsuario)
    '        CrRp = Nothing
    '        CrAp = Nothing

    '        If _pUsuario = "sa" Then
    '            pwd = "sa"
    '        ElseIf _pUsuario = "flexline" Then
    '            pwd = "flexline"
    '        Else
    '            pwd = ""
    '        End If


    '        'MessageBox.Show("Reporte Generico Clase")

    '        _reporte_generico_clase(path_reporte, pm_campos, pm_valor, _pServidor, _pBase_datos, _pUsuario, pwd, exportar, imprimir, tipo_exportar, False, "")



    '    Catch ex As Exception
    '        MessageBox.Show("Exportar Reporte Clase Proceso " & ex.Message & ex.Source)
    '    Finally
    '    End Try

    'End Sub

    'Sub _exportar_reporte_(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal oPanel As Windows.Forms.Panel, _
    '                ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal exportar As Boolean, _
    '                ByVal imprimir As Boolean, ByVal acciones As String, ByVal tipo_exportar As String, _
    '                ByVal proceso_adicional As Array)


    '    Try
    '        CrAp = New CRAXDRT.Application
    '        CrRp = New CRAXDRT.Report

    '        _Inicializar_reporte_CRAXDRT(path_reporte, _pServidor, _pBase_datos, _pUsuario)
    '        'CrRp = CrAp.OpenReport(path_reporte)

    '        If proceso_adicional(0) = 1 Then
    '            Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
    '            System.Threading.Thread.Sleep(1000)
    '        End If

    '        _procesar_reporte_CRAXDRT(path_reporte, pm_parametros, oPanel, _pServidor, _pBase_datos, _pUsuario)




    '        If exportar Then
    '            'If acciones.LastIndexOf("E") >= 0 Then
    '            If tipo_exportar.Length > 0 Then
    '                hacer_exportar(tipo_exportar, True)
    '            Else
    '                MessageBox.Show("No Tiene Permisos Para Exportar", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Else
    '            If imprimir Then
    '                If acciones.LastIndexOf("P") >= 0 Then
    '                    CrRp.PrintOut(True)
    '                    Dim Oaut As New Automatizacion.frm_craxdrt_viewer_aut
    '                    Oaut.CrRpV = CrRp
    '                    'Oaut.ShowDialog()
    '                    Oaut.CrRpV = Nothing
    '                    Oaut.Dispose()
    '                    Oaut = Nothing
    '                    'Dim oform As New frm_craxdrt_viewer
    '                    'oform.pCrRp = CrRp
    '                    'oform.AxCRV.ReportSource = CrRp
    '                    'oform.pCrRp = Nothing
    '                    'oform.Dispose()
    '                    'oform = Nothing
    '                End If
    '            Else  'Vista Previa

    '                'Dim oform As New frm_craxdrt_viewer
    '                'oform.CrRpV = CrRp
    '                'oform.Acciones = acciones
    '                'oform.Tipo_Exportar = tipo_exportar
    '                'Dim Oaut As New Automatizacion.frm_craxdrt_viewer_aut
    '                'Oaut.CrRpV = CrRp
    '                'Oaut.Acciones = acciones
    '                'oaut.tipo_exportar = tipo_exportar


    '                'x=Ejecutar en Vista Previa
    '                'If acciones.LastIndexOf("X") >= 0 Then
    '                '    oform.ShowDialog()
    '                '    'Oaut.ShowDialog()
    '                'End If

    '                'If oaut.descripcion_error.Trim.Length > 0 Then
    '                '    MessageBox.Show(oaut.descripcion_error)
    '                'End If
    '                'Oaut.Dispose()
    '                'Oaut = Nothing
    '                'oform.Dispose()
    '                'oform = Nothing
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & ex.Source)
    '    Finally


    '        'Dim intNumReports As Integer = 1
    '        ' Dim intNumApps As Integer = 1

    '        'If IsReference(CrRp) Then
    '        'Do
    '        '    intNumReports = System.Runtime.InteropServices.Marshal.ReleaseComObject(CrRp)
    '        'Loop While intNumReports > 0

    '        'Correr Proceso despues que termine de generar el reporte
    '        If proceso_adicional(0) = 0 Then
    '            Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
    '            System.Threading.Thread.Sleep(1000)
    '        End If


    '        CrRp = Nothing

    '        'End If

    '        'If IsReference(CrAp) Then
    '        'Do
    '        'intNumApps = System.Runtime.InteropServices.Marshal.ReleaseComObject(CrAp)
    '        'Loop While intNumApps > 0
    '        CrAp = Nothing
    '        'End If

    '        'GC.Collect()


    '    End Try

    'End Sub

    'Sub _Inicializar_reporte_CRAXDRT(ByVal path_reporte As String, _
    '        ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String)
    '    Dim i_aux As Integer
    '    Dim ls_valor As String
    '    Dim buffer(50) As String
    '    Dim cadena(3) As String
    '    Dim la_valores(2) As String

    '    Try
    '        'cargo el reporte
    '        CrRp = CrAp.OpenReport(path_reporte)
    '        CrRp.DiscardSavedData()

    '        'Aplico Seguridad Dependiendo 
    '        For i_count = 0 To 3
    '            cadena(i_count) = ""
    '        Next

    '        ls_valor = CrRp.Database.Tables(1).ConnectBufferString
    '        buffer = ls_valor.Replace(";", "=").Split("=")

    '        Try
    '            For i_count = 0 To 49
    '                If buffer(i_count) = "PreQEServerName" Then
    '                    cadena(0) = buffer(i_count + 1)
    '                End If
    '                If buffer(i_count) = "DATABASE" Then
    '                    cadena(1) = buffer(i_count + 1)
    '                End If
    '                If buffer(i_count) = "UserId" Then
    '                    cadena(2) = buffer(i_count + 1)
    '                End If
    '                If cadena(0).Trim.Length > 0 And _
    '                    cadena(1).Trim.Length > 0 And _
    '                    cadena(2).Trim.Length > 0 Then
    '                    Exit For
    '                End If
    '            Next
    '        Catch ex As Exception
    '            If _pServidor.ToUpper = "DATASERVER" Then
    '                cadena(0) = "DATASERVER"
    '                cadena(1) = "BDFlexline"
    '                cadena(2) = "flexline"
    '            Else
    '                cadena(0) = _pServidor
    '                cadena(1) = _pBase_datos
    '                cadena(2) = _pUsuario
    '            End If
    '        End Try

    '        'verifico la cadena de conexion
    '        If cadena(2).ToUpper = "FLEXLINE" Then
    '            cadena(3) = "flexline"
    '        Else
    '            cadena(3) = "sa"
    '        End If

    '        'Aplico Seguridad

    '        If cadena(1).ToString.IndexOf(":\") = -1 Then
    '            For i_aux = 1 To CrRp.Database.Tables.Count()
    '                CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
    '            Next
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show("Inicializar Reporte ", ex.Message)
    '    End Try

    'End Sub


    'Sub _Inicializar_reporte_CRAXDRT_proceso(ByVal path_reporte As String, _
    '    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String)
    '    Dim i_count, i_aux As Integer
    '    Dim ls_valor As String
    '    Dim buffer(50) As String
    '    Dim cadena(3) As String
    '    Dim la_valores(2) As String

    '    Try
    '        'cargo el reporte
    '        CrRp = CrAp.OpenReport(path_reporte)
    '        CrRp.DiscardSavedData()

    '        'Aplico Seguridad Dependiendo 
    '        For i_count = 0 To 3
    '            cadena(i_count) = ""
    '        Next

    '        ls_valor = CrRp.Database.Tables(1).ConnectBufferString
    '        buffer = ls_valor.Replace(";", "=").Split("=")

    '        Try
    '            For i_count = 0 To 49
    '                If buffer(i_count) = "PreQEServerName" Then
    '                    cadena(0) = buffer(i_count + 1)
    '                End If
    '                If buffer(i_count) = "DATABASE" Then
    '                    cadena(1) = buffer(i_count + 1)
    '                End If
    '                If buffer(i_count) = "UserId" Then
    '                    cadena(2) = buffer(i_count + 1)
    '                End If
    '                If cadena(0).Trim.Length > 0 And _
    '                    cadena(1).Trim.Length > 0 And _
    '                    cadena(2).Trim.Length > 0 Then
    '                    Exit For
    '                End If
    '            Next
    '        Catch ex As Exception
    '            If _pServidor.ToUpper = "DATASERVER" Then
    '                cadena(0) = "DATASERVER"
    '                cadena(1) = "BDFlexline"
    '                cadena(2) = "flexline"
    '            Else
    '                cadena(0) = _pServidor
    '                cadena(1) = _pBase_datos
    '                cadena(2) = _pUsuario
    '            End If
    '        End Try

    '        'verifico la cadena de conexion
    '        If cadena(2).ToUpper = "FLEXLINE" Then
    '            cadena(3) = "flexline"
    '        Else
    '            cadena(3) = "sa"
    '        End If

    '        'Aplico Seguridad

    '        If cadena(1).ToString.IndexOf(":\") = -1 Then
    '            For i_aux = 1 To CrRp.Database.Tables.Count()
    '                CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
    '            Next
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show("Inicializar Reporte ", ex.Message)
    '    End Try

    'End Sub

    'Sub _procesar_reporte_CRAXDRT(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, _
    '                ByVal _pServidor As String, ByVal _pBase_Datos As String, ByVal _pUsuario As String)


    '    'Dim mysubreportobject As CRAXDRT.SubreportObject
    '    'Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
    '    'Dim coninfo As CRAXDRT.DatabaseTables

    '    'Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    'Dim mysubrepdoc As CRAXDRT.SubreportObject
    '    'Dim currValue As CRAXDRT.ParameterValues
    '    'Dim paravalue As CRAXDRT.ParameterFieldDefinition


    '    'Dim paradefs As CRAXDRT.ParameterFieldDefinitions
    '    Dim paradef As CRAXDRT.ParameterFieldDefinition


    '    Dim i_count, i_aux, i_count2 As Integer
    '    Dim itemnum, imultiple As Integer
    '    Dim ls_valor As String

    '    Dim buffer(50) As String
    '    Dim cadena(3) As String
    '    Dim la_valores(2) As String


    '    '    'LLeno los Parametros
    '    Try


    '        i_count = -1

    '        For Each paradef In CrRp.ParameterFields
    '            i_count = i_count + 1
    '            If paradef.NeedsCurrentValue Then

    '                If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
    '                    'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
    '                    If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then
    '                        paradef.AddCurrentValue(gs_empresa)
    '                    Else
    '                        For i_aux = 0 To opanel.Controls.Count - 1
    '                            If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                                itemnum = i_aux
    '                                Exit For
    '                            End If
    '                        Next
    '                        If paradef.EnableMultipleValues Then
    '                            paradef.ClearCurrentValueAndRange()
    '                            imultiple = paradef.NumberOfCurrentValues
    '                            imultiple = IIf(imultiple < 1, 120, imultiple)
    '                            Try 'por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
    '                                '    '-1
    '                                For i_count2 = 1 To imultiple
    '                                    ls_valor = pm_parametros(i_count, i_count2)
    '                                    If ls_valor.Trim.Length > 0 Then
    '                                        paradef.AddCurrentValue(pm_parametros(i_count, i_count2))
    '                                        paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
    '                                    End If
    '                                Next
    '                            Catch ex As Exception
    '                            End Try
    '                        Else
    '                            Select Case paradef.ValueType
    '                                Case CRFieldValueType.crNumberField
    '                                    paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
    '                                Case CRFieldValueType.crDateField
    '                                    paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                                Case CRFieldValueType.crStringField
    '                                    paradef.AddCurrentValue(pm_parametros(i_count, 1))
    '                                Case CRFieldValueType.crDateTimeField
    '                                    paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                            End Select
    '                        End If
    '                    End If
    '                Else 'paradef.DiscreteOrRangeKind
    '                    For i_aux = 0 To opanel.Controls.Count - 1
    '                        If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                            itemnum = i_aux
    '                            Exit For
    '                        End If
    '                    Next
    '                    If paradef.EnableMultipleValues = False Then
    '                        paradef.ClearCurrentValueAndRange()
    '                        Select Case paradef.ValueType
    '                            Case CRFieldValueType.crNumberField
    '                                paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                            Case CRFieldValueType.crDateField
    '                                paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                            Case CRFieldValueType.crStringField
    '                                paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
    '                        End Select
    '                    Else
    '                        paradef.ClearCurrentValueAndRange()
    '                        imultiple = paradef.NumberOfCurrentValues()
    '                        imultiple = IIf(imultiple < 1, 15, imultiple)
    '                        For i_count2 = 1 To imultiple - 1
    '                            ls_valor = pm_parametros(i_count, i_count2)
    '                            If ls_valor.Trim.Length > 0 Then
    '                                la_valores = ls_valor.Split(",")
    '                                paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
    '                            End If
    '                        Next
    '                    End If
    '                End If 'paradef.DiscreteOrRangeKind
    '            End If 'paradef.NeedsCurrentValue
    '        Next 'crrp.ParameterFields
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    'Sub _procesar_reporte_CRAXDRT_Proceso(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, _
    '              ByVal _pServidor As String, ByVal _pBase_Datos As String, ByVal _pUsuario As String)


    '    'Dim mysubreportobject As CRAXDRT.SubreportObject
    '    'Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
    '    'Dim coninfo As CRAXDRT.DatabaseTables

    '    'Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    'Dim mysubrepdoc As CRAXDRT.SubreportObject
    '    'Dim currValue As CRAXDRT.ParameterValues
    '    'Dim paravalue As CRAXDRT.ParameterFieldDefinition


    '    'Dim paradefs As CRAXDRT.ParameterFieldDefinitions
    '    Dim paradef As CRAXDRT.ParameterFieldDefinition


    '    Dim i_count, i_aux, i_count2 As Integer
    '    Dim itemnum, imultiple As Integer
    '    Dim ls_valor As String

    '    Dim buffer(50) As String
    '    Dim cadena(3) As String
    '    Dim la_valores(2) As String



    '    '    'LLeno los Parametros
    '    Try


    '        i_count = -1

    '        Dim nitems As Integer
    '        nitems = CrRp.ParameterFields.Count
    '        ReDim pm_campos(nitems)
    '        ReDim pm_valor(nitems)


    '        For Each paradef In CrRp.ParameterFields
    '            i_count = i_count + 1
    '            If paradef.NeedsCurrentValue Then

    '                If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
    '                    'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
    '                    If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then
    '                        pm_campos(i_count) = paradef.ParameterFieldName
    '                        pm_valor(i_count) = gs_empresa
    '                        paradef.AddCurrentValue(gs_empresa)
    '                    Else
    '                        For i_aux = 0 To opanel.Controls.Count - 1
    '                            If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                                itemnum = i_aux
    '                                Exit For
    '                            End If
    '                        Next
    '                        If paradef.EnableMultipleValues Then
    '                            paradef.ClearCurrentValueAndRange()
    '                            imultiple = paradef.NumberOfCurrentValues
    '                            imultiple = IIf(imultiple < 1, 120, imultiple)
    '                            Try 'por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
    '                                '    '-1
    '                                For i_count2 = 1 To imultiple
    '                                    ls_valor = pm_parametros(i_count, i_count2)
    '                                    If ls_valor.Trim.Length > 0 Then
    '                                        paradef.AddCurrentValue(pm_parametros(i_count, i_count2))
    '                                        paradef.AddDefaultValue(pm_parametros(i_count, i_count2))

    '                                    End If
    '                                Next
    '                            Catch ex As Exception
    '                            End Try
    '                        Else
    '                            Select Case paradef.ValueType
    '                                Case CRFieldValueType.crNumberField
    '                                    paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
    '                                Case CRFieldValueType.crDateField
    '                                    paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                                Case CRFieldValueType.crStringField
    '                                    paradef.AddCurrentValue(pm_parametros(i_count, 1))
    '                                Case CRFieldValueType.crDateTimeField
    '                                    paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                            End Select
    '                            pm_campos(i_count) = paradef.ParameterFieldName
    '                            pm_valor(i_count) = pm_parametros(i_count, 1)
    '                        End If
    '                    End If
    '                Else 'paradef.DiscreteOrRangeKind
    '                    For i_aux = 0 To opanel.Controls.Count - 1
    '                        If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                            itemnum = i_aux
    '                            Exit For
    '                        End If
    '                    Next
    '                    If paradef.EnableMultipleValues = False Then
    '                        paradef.ClearCurrentValueAndRange()
    '                        Select Case paradef.ValueType
    '                            Case CRFieldValueType.crNumberField
    '                                paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                            Case CRFieldValueType.crDateField
    '                                paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                            Case CRFieldValueType.crStringField
    '                                paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
    '                        End Select
    '                        pm_campos(i_count) = paradef.ParameterFieldName
    '                        pm_valor(i_count) = pm_parametros(i_count, 1)
    '                    Else
    '                        paradef.ClearCurrentValueAndRange()
    '                        imultiple = paradef.NumberOfCurrentValues()
    '                        imultiple = IIf(imultiple < 1, 15, imultiple)
    '                        For i_count2 = 1 To imultiple - 1
    '                            ls_valor = pm_parametros(i_count, i_count2)
    '                            If ls_valor.Trim.Length > 0 Then
    '                                la_valores = ls_valor.Split(",")
    '                                paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
    '                            End If
    '                        Next
    '                        pm_campos(i_count) = paradef.ParameterFieldName
    '                        pm_valor(i_count) = pm_parametros(i_count, 1)
    '                    End If
    '                End If 'paradef.DiscreteOrRangeKind
    '            End If 'paradef.NeedsCurrentValue
    '        Next 'crrp.ParameterFields
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub


    'Sub __reporte_generico(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    'ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    'ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String)

    '    Dim Sfd = New System.Windows.Forms.SaveFileDialog
    '    Dim paradef As CRAXDRT.ParameterFieldDefinition
    '    Dim i_aux, i_count2 As Integer
    '    Dim cadena(3) As String
    '    Dim ls_valores(2) As String

    '    Try

    '        CrAp = New CRAXDRT.Application
    '        CrRp = New CRAXDRT.Report

    '        'cargo el reporte
    '        CrRp = CrAp.OpenReport(path_reporte)
    '        CrRp.DiscardSavedData()

    '        'Aplico Seguridad 
    '        cadena(0) = _pServidor
    '        cadena(1) = _pBase_datos
    '        cadena(2) = _pUsuario
    '        cadena(3) = _ppwd

    '        For i_aux = 1 To CrRp.Database.Tables.Count()
    '            CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
    '        Next

    '        'Recorro los parametros
    '        For Each paradef In CrRp.ParameterFields
    '            Try
    '                For i_aux = 0 To pm_parametros.Length - 1
    '                    Try
    '                        If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
    '                            If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
    '                                If paradef.EnableMultipleValues Then
    '                                    'Revisar los valores que llevo en el arreglo
    '                                    paradef.ClearCurrentValueAndRange()
    '                                    ReDim ls_valores(100)
    '                                    ls_valores = pm_valores(i_aux).ToString.Split(",")
    '                                    'imultiple = paradef.NumberOfCurrentValues
    '                                    'imultiple = IIf(imultiple < 1, 120, imultiple)
    '                                    Try 'por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
    '                                        '    '-1
    '                                        For i_count2 = 0 To ls_valores.Length - 1
    '                                            'ls_valor = pm_parametros(i_count, i_count2)
    '                                            If ls_valores(i_count2).Length > 0 Then
    '                                                paradef.AddCurrentValue(ls_valores(i_count2))
    '                                                'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
    '                                            End If
    '                                        Next
    '                                    Catch ex As Exception
    '                                    End Try
    '                                Else
    '                                    Select Case paradef.ValueType
    '                                        Case CRFieldValueType.crNumberField
    '                                            paradef.AddCurrentValue(Double.Parse(pm_valores(i_aux)))
    '                                        Case CRFieldValueType.crDateField
    '                                            paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
    '                                        Case CRFieldValueType.crStringField
    '                                            paradef.AddCurrentValue(pm_valores(i_aux))
    '                                    End Select
    '                                End If
    '                            End If

    '                            'Lista de valores

    '                        Else
    '                            If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
    '                                paradef.ClearCurrentValueAndRange()
    '                                'imultiple = paradef.NumberOfCurrentValues()
    '                                'imultiple = IIf(imultiple < 1, 15, imultiple)
    '                                'For i_count2 = 1 To imultiple - 1
    '                                'ls_valor = pm_parametros(i_count, i_count2)
    '                                'If ls_valor.Trim.Length > 0 Then
    '                                ls_valores = pm_valores(i_aux).Split(",")
    '                                paradef.AddCurrentRange(ls_valores(0), ls_valores(1), 3)
    '                                'End If
    '                                'Next
    '                            End If
    '                        End If
    '                    Catch ex As Exception
    '                    End Try
    '                Next
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            End Try
    '        Next


    '        If pexportar Then
    '            hacer_exportar(_ptipo_exportar, False)
    '            'Si se desea exportar el archivo
    '            ' Obtenemos el nombre del archivo
    '            'Sfd.Filter = "xls|*.xls"
    '            'Sfd.ShowDialog()

    '            'exportOpts = CrRp.ExportOptions

    '            'exportOpts.FormatType = CRExportFormatType.crEFTExcel80
    '            'exportOpts.ExcelAreaType = CRAreaKind.crDetail
    '            'exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile

    '            'Exportamos el reporte
    '            'If Sfd.FileName.Length > 0 Then
    '            '    exportOpts.DiskFileName = Sfd.FileName
    '            '    CrRp.Export(False)
    '            '    MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            'End If
    '        Else
    '            If imprimir Then
    '                'CrRp.PrintOut(False)
    '                'Dim oform As New frm_craxdrt_viewer
    '                'oform.pCrRp = CrRp
    '                'oform.AxCRV.ReportSource = CrRp
    '                'oform.Dispose()
    '                'oform = Nothing
    '            Else
    '                '    Dim oform As New frm_craxdrt_viewer
    '                '    oform.pCrRp = CrRp
    '                '    'oform.AxCRV.ReportSource = CrRp
    '                '    'oform.AxCRV.ViewReport()
    '                '    oform.ShowDialog()
    '                '    oform.Dispose()
    '                '    oform = Nothing
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)

    '    Finally

    '        Sfd = Nothing
    '        CrAp = Nothing
    '        CrRp = Nothing

    '    End Try
    'End Sub

    'Sub hacer_exportar(ByVal tipo_exportar As String, ByVal preguntar_tipo As Boolean)

    '    If tipo_exportar.Length > 0 Then
    '        ' Obtenemos el nombre del archivo
    '        Dim exportOpts As CRAXDRT.ExportOptions
    '        Dim Sfd = New System.Windows.Forms.SaveFileDialog
    '        Dim tipo_reporte As String

    '        If preguntar_tipo Then
    '            Dim oform As New frm_pickeador
    '            oform.Llenar_Combo_exportar(tipo_exportar)
    '            oform.Text = "Seleccion Tipo de Archivo a Exportar"
    '            oform.Label1.Text = "Tipo"
    '            oform.ShowDialog()
    '            tipo_reporte = oform.cmb_nombre_picker.Text
    '            oform = Nothing
    '        Else
    '            tipo_reporte = tipo_exportar
    '        End If

    '        If tipo_reporte.ToUpper = "EXCEL" Then
    '            Sfd.Filter = "xls|*.xls"
    '        End If
    '        If tipo_reporte.ToUpper = "PDF" Then
    '            Sfd.Filter = "pdf|*.pdf"
    '        End If
    '        Sfd.ShowDialog()

    '        exportOpts = CrRp.ExportOptions

    '        If tipo_reporte.ToUpper = "EXCEL" Then
    '            exportOpts.FormatType = CRExportFormatType.crEFTExcel80
    '        End If

    '        If tipo_reporte.ToUpper = "PDF" Then
    '            exportOpts.FormatType = CRExportFormatType.crEFTPortableDocFormat
    '        End If
    '        exportOpts.ExcelAreaType = CRAreaKind.crDetail
    '        exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile
    '        'Exportamos el reporte
    '        If Sfd.FileName.Length > 0 Then
    '            exportOpts.DiskFileName = Sfd.FileName
    '            CrRp.Export(False)
    '            MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If
    '        Sfd = Nothing
    '    Else
    '        MessageBox.Show("Este Reporte No se Puede Exportar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Sub


    'Sub Ejecutar_Proceso_Adicional(ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, ByVal pm_proceso_adicional As Array)
    '    Dim icount As Integer

    '    Dim buffer(50) As String
    '    Dim cadena(3) As String
    '    Dim la_valores(100) As String
    '    Dim ls_sql As String

    '    'ls_sql = pm_proceso_adicional(2).ToString.Substring(0, pm_proceso_adicional(2).ToString.IndexOf("("))
    '    ls_sql = pm_proceso_adicional(2).ToString.Substring(0, pm_proceso_adicional(2).ToString.IndexOf("(")) & " "
    '    la_valores = pm_proceso_adicional(2).ToString.Substring(ls_sql.Length, pm_proceso_adicional(2).ToString.IndexOf(")") - (ls_sql.Length)).Split(",")


    '    For icount = 0 To la_valores.Length - 1
    '        ls_sql = ls_sql & "'" & Buscar_parametro_especifico(la_valores(icount), opanel, pm_parametros) & "'" & _
    '            IIf(icount <> la_valores.Length - 1, ",", "")
    '    Next

    '    Dim otrans As New Transaccional.Conexion(pm_proceso_adicional(1))
    '    'Dim otrans As New Transaccional.Conexion("umbral_flexline")
    '    Try
    '        otrans.open()
    '        otrans.Actualiza(ls_sql)
    '        If otrans.Codigo_error > 0 Then
    '            MessageBox.Show(otrans.descripcion_error)
    '        End If
    '    Catch ex As Exception

    '    Finally
    '        otrans.close()
    '        otrans = Nothing

    '    End Try

    'End Sub

    'Private Function Buscar_parametro_especifico(ByVal nombre_parametro As String, ByVal opanel As Windows.Forms.Panel, ByVal pm_parametros As Array) As String
    '    Dim icount As Integer
    '    Dim paradef As CRAXDRT.ParameterFieldDefinition

    '    Dim i_count, i_aux, i_count2 As Integer
    '    Dim itemnum, imultiple As Integer
    '    Dim ls_valor As String
    '    Dim valor_retorno As String = String.Empty
    '    Dim la_valores(100) As String

    '    icount = -1
    '    Try

    '        For Each paradef In CrRp.ParameterFields
    '            icount = icount + 1
    '            If paradef.NeedsCurrentValue Then

    '                If nombre_parametro.ToLower.Trim <> paradef.ParameterFieldName.ToLower.Trim Then
    '                    'Exit For
    '                Else
    '                    If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
    '                        'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
    '                        If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then
    '                            'paradef.AddCurrentValue(gs_empresa)
    '                            valor_retorno = gs_empresa
    '                            Exit Try
    '                        Else
    '                            For i_aux = 0 To opanel.Controls.Count - 1
    '                                If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                                    itemnum = i_aux
    '                                    Exit For
    '                                End If
    '                            Next
    '                            If paradef.EnableMultipleValues Then
    '                                ' paradef.ClearCurrentValueAndRange()
    '                                imultiple = paradef.NumberOfCurrentValues
    '                                imultiple = IIf(imultiple < 1, 120, imultiple)
    '                                Try 'por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
    '                                    '    '-1
    '                                    For i_count2 = 1 To imultiple
    '                                        ls_valor = pm_parametros(i_count, i_count2)
    '                                        If ls_valor.Trim.Length > 0 Then
    '                                            valor_retorno = pm_parametros(i_count, i_count2)
    '                                            'paradef.AddCurrentValue(pm_parametros(i_count, i_count2))
    '                                            'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
    '                                            Exit Try
    '                                        End If
    '                                    Next
    '                                Catch ex As Exception
    '                                End Try
    '                            Else
    '                                Select Case paradef.ValueType
    '                                    Case CRFieldValueType.crNumberField
    '                                        'paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
    '                                    Case CRFieldValueType.crDateField
    '                                        'paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                                    Case CRFieldValueType.crStringField
    '                                        'paradef.AddCurrentValue(pm_parametros(i_count, 1))
    '                                    Case CRFieldValueType.crDateTimeField
    '                                        'paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
    '                                End Select
    '                                valor_retorno = pm_parametros(icount, 1)
    '                                Exit Try
    '                            End If
    '                        End If
    '                    Else 'paradef.DiscreteOrRangeKind
    '                        For i_aux = 0 To opanel.Controls.Count - 1
    '                            If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
    '                                itemnum = i_aux
    '                                Exit For
    '                            End If
    '                        Next
    '                        If paradef.EnableMultipleValues = False Then
    '                            'paradef.ClearCurrentValueAndRange()
    '                            Select Case paradef.ValueType
    '                                Case CRFieldValueType.crNumberField
    '                                    'paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                                Case CRFieldValueType.crDateField
    '                                    'paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
    '                                Case CRFieldValueType.crStringField
    '                                    'paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
    '                            End Select
    '                        Else
    '                            paradef.ClearCurrentValueAndRange()
    '                            imultiple = paradef.NumberOfCurrentValues()
    '                            imultiple = IIf(imultiple < 1, 15, imultiple)
    '                            For i_count2 = 1 To imultiple - 1
    '                                ls_valor = pm_parametros(i_count, i_count2)
    '                                If ls_valor.Trim.Length > 0 Then
    '                                    la_valores = ls_valor.Split(",")
    '                                    'paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
    '                                End If
    '                            Next
    '                        End If
    '                    End If 'paradef.DiscreteOrRangeKind.
    '                End If 'nombre_parametro.ToLower <> paradef.ParameterFieldName.ToLower
    '            End If 'paradef.NeedsCurrentValue
    '        Next 'crrp.ParameterFields
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    Return valor_retorno

    'End Function

    'Genera el Reporte de la Clase de Automatizacion
    Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
        ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
        ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, _
        ByVal _pmostrar_archivo As Boolean, ByVal _nombre_archivo As String, ByVal mostrarError As Boolean, ByVal nCopias As Integer) As Boolean
        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)
        If _nombre_archivo.Length > 0 Then
            Oaut.Archivo_Generado = _nombre_archivo
        End If
        Oaut.pnNumeroCopias = nCopias
        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)
        If Oaut.Descripcion_Error.Length > 0 Then
            If mostrarError Then
                MessageBox.Show("Oaut._Reporte Generico " & Oaut.Descripcion_Error)
            End If
            valorRegreso = False
        End If

        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()
        Return valorRegreso
    End Function

    Function _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
        ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
        ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean, ByVal _nombre_archivo As String, ByVal mostrarError As Boolean) As Boolean

        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)
        If _nombre_archivo.Length > 0 Then
            Oaut.Archivo_Generado = _nombre_archivo
        End If

        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)
        If Oaut.Descripcion_Error.Length > 0 Then
            If mostrarError Then
                MessageBox.Show("Oaut._Reporte Generico " & Oaut.Descripcion_Error)
            End If
            valorRegreso = False
        End If

        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()
        Return valorRegreso
    End Function

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


    Public Function imprimiryPDFSalidaEntrada(psEmpresa As String, psTipodocto As String, psNumero As String) As String

        'Debo Definir Fecha del Documento para Insertarlo en la Carpeta Indicada

        Dim lsrutaPDF As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Dim ldfechaDocto As Date

        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_documento '" & psEmpresa & "','" & psTipodocto & "','" & psNumero & "'")
            ldfechaDocto = dt.Rows(0).Item("fecha")

            lsrutaPDF = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" & gs_empresa & "\" & ldfechaDocto.ToString("yyyyMM")


            Try
                If Not Directory.Exists(lsrutaPDF) Then
                    Directory.CreateDirectory(lsrutaPDF)
                End If
            Catch ex As Exception

            End Try

            lsrutaPDF = lsrutaPDF & "\" & psTipodocto.ToString.Replace(" ", "_") & "_" & psNumero & ".pdf"

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


            pm_valores2(0) = psEmpresa
            pm_valores2(2) = psTipodocto
            pm_valores2(1) = psNumero


            ''Envio a PDF
            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                True, False, "PDF", False, lsrutaPDF, True, 1, gs_empresa, ",")

            ''Envio a Impresora
            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2, _
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                False, True, "PDF", False, lsrutaPDF, True, 1, gs_empresa, ",")

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Function

End Module
