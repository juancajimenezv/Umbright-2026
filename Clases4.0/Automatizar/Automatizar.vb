Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Imports CrystalDecisions.Shared


Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource



#Region "Exportar Excel"

Public Class exportar_excel
    Public ocultar_columnas As String
    Public Texto_Columnas(,) As Integer
    Public Nombre_Columnas As String
    Public nAgregar_Filas As Integer

    Public sEncabezado As String
    Public sTitulo As String
    Public sgPiePagina As String '(c) 20240829
    Public sFileName As String = String.Empty

    Public Sub DataTableToExcelArchivo(ByVal pDataTable As DataTable)
        Dim vFileName As String
        If sFileName.Length = 0 Then

            vFileName = Path.GetTempFileName()
        Else
            vFileName = sFileName
        End If

        FileOpen(1, vFileName, OpenMode.Output)

        Dim sb As String = String.Empty
        Dim dc As DataColumn
        For Each dc In pDataTable.Columns


            If ocultar_columnas.LastIndexOf("," & dc.ColumnName & ",") < 0 Then
                sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab
            End If
            'sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab

        Next
        PrintLine(1, sb)


        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If ocultar_columnas.LastIndexOf("," & dc.ColumnName & ",") < 0 Then
                    'If dc.ColumnName.LastIndexOf(ocultar_columnas, 0) < 0 Then
                    'sb &= dc.ColumnName & Microsoft.VisualBasic.ControlChars.Tab
                    If Not IsDBNull(dr(i)) Then
                        sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    Else
                        sb &= Microsoft.VisualBasic.ControlChars.Tab
                    End If
                End If
                i += 1
            Next

            PrintLine(1, sb)
        Next
        FileClose(1)
        TextToExcel(vFileName)

    End Sub
    Public Sub DataTableToExcel(ByVal pDataTable As DataTable)
        Dim vFileName As String
        If sFileName.Length = 0 Then

            vFileName = Path.GetTempFileName()
        Else
            vFileName = sFileName
        End If

        FileOpen(1, vFileName, OpenMode.Output)

        Dim sb As String = String.Empty
        Dim dc As DataColumn
        For Each dc In pDataTable.Columns


            If ocultar_columnas.LastIndexOf("," & dc.ColumnName & ",") < 0 Then
                sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab
            End If
            'sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab

        Next
        PrintLine(1, sb)


        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If ocultar_columnas.LastIndexOf("," & dc.ColumnName & ",") < 0 Then
                    'If dc.ColumnName.LastIndexOf(ocultar_columnas, 0) < 0 Then
                    'sb &= dc.ColumnName & Microsoft.VisualBasic.ControlChars.Tab
                    If Not IsDBNull(dr(i)) Then
                        sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    Else
                        sb &= Microsoft.VisualBasic.ControlChars.Tab
                    End If
                End If
                i += 1
            Next

            PrintLine(1, sb)
        Next
        FileClose(1)
        TextToExcel(vFileName, pDataTable)

    End Sub


    Public Sub TextToExcel(ByVal pFileName As String)
        Dim p As Process = New Process
        p.EnableRaisingEvents = False

        Process.Start("Excel.exe", pFileName)

    End Sub

    Public Sub TextToExcel(ByVal pFileName As String, ByVal pdt As DataTable)

        Dim vFormato As Excel.XlRangeAutoFormat
        Dim serror As String
        Dim icount As Integer
        Dim dc As DataColumn

        Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        Dim Exc As Excel.Application = New Excel.Application
        Exc.Workbooks.OpenText(pFileName, , , , Excel.XlTextQualifier.xlTextQualifierNone, , True, , , , , , FieldInfo:=Texto_Columnas)
        Dim Wb As Excel.Workbook = Exc.ActiveWorkbook
        Dim Ws As Excel.Worksheet = Wb.ActiveSheet

        'Se le indica el formato al que queremos exportarlo
        Dim valor As Integer = 2
        If valor > -1 Then
            Select Case valor
                Case 0 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatNone
                Case 1 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple
                Case 2 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1
                Case 3 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2
                Case 4 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic3
                Case 5 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1
                Case 6 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting2
                Case 7 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting3
                Case 8 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting4
                Case 9 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor1
                Case 10 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2
                Case 11 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor3
                Case 12 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList1
                Case 13 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList2
                Case 14 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList3
                Case 15 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1
                Case 16 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects2
            End Select

            Try
                Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).AutoFormat(vFormato)
                Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).Font.Size = 8.0

                Dim xx As Integer
                Dim stype As String
                Dim sarray(Ws.UsedRange.Columns.Count) As String
                sarray = Nombre_Columnas.Split(",")

                For xx = 1 To Ws.UsedRange.Columns.Count

                    If xx < 55 Then '(c) 20240829
                        For Each dc In pdt.Columns
                            If Not Ws.Cells(xx).Value.ToString.ToLower.Contains("tran") Then


                                If Ws.Cells(xx).Value = dc.ColumnName Then
                                    stype = dc.DataType.ToString
                                    If stype = "System.Decimal" Then
                                        Ws.Columns(xx).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
                                    ElseIf stype = "System.String" Then
                                        Ws.Columns(xx).numberformat = "@"
                                    ElseIf stype.Substring(0, 10).ToLower = "system.int" Then
                                        Ws.Columns(xx).numberformat = "#,##0_);[Red](#,##0)"
                                    End If
                                    Exit For

                                End If
                            End If
                        Next
                    Else

                    End If
                    ''Reemplazo el nombre de la Colunma por el envia
                    If sarray.Length > xx - 1 Then
                        If sarray(xx).ToString.Length > 0 Then
                            Ws.Cells(xx).value = sarray(xx)
                        Else
                            'If sarray(xx - 1).ToString.Length > 0 Then
                            '    Ws.Cells(xx).value = sarray(xx - 1)
                            'Else
                            stype = Ws.Cells(xx).value.ToString.Replace("_", " ")
                            Ws.Cells(xx).value = Ws.Cells(xx).value.ToString.Replace("_", " ")
                        End If
                    End If
                Next








            Catch ex As Exception
                serror = ex.Message
            End Try

            Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).Columns.AutoFit()
            For icount = 1 To nAgregar_Filas + 2
                Ws.Rows(icount).Insert()
            Next

            Ws.Cells(1, 1).value = sEncabezado
            Ws.Cells(2, 1).value = sTitulo
            Ws.Range(Ws.Cells(1, 1), Ws.Cells(2, 1)).Font.Bold = True
            Ws.Cells(Ws.UsedRange.Rows.Count + 3, 1).value = sgPiePagina
            Try
                File.Delete(pFileName)
            Catch ex As Exception

            End Try

            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)


            Exc.Visible = True
            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)

        End If
        'Exc.Quit()

        Ws = Nothing
        Wb = Nothing
        'Exc = Nothing

        GC.Collect()

        'If valor > -1 Then
        '    Dim p As Process = New Process
        '    p.EnableRaisingEvents = False

        '    Process.Start("Excel.exe", pFileName)

        'End If
        'System.Threading.Thread.CurrentThread.CurrentCulture = vCultura

    End Sub


    Private Sub aplicar_formatos(ByVal ws As Excel._Worksheet)

    End Sub

    Public Function ExportExcel(ByVal dtSource As System.Data.DataTable, ByVal sFileName As String)
        ExportExcel = Nothing

        Dim iRowCount As Integer = dtSource.Rows.Count
        Dim iColCount As Integer = dtSource.Columns.Count
        Dim oData(iRowCount, iColCount) As Object

        Dim iRow As Integer, iCol As Integer
        For iRow = 0 To iRowCount - 1
            For iCol = 0 To iColCount - 1
                oData(iRow, iCol) = dtSource.Rows(iRow).Item(iCol)
            Next
        Next


        ' Start Excel and get Application object
        Dim oExcel As Excel._Application = New Excel.Application

        'oExcel.Visible = True  ' Make visible

        ' Get a new workbook
        Dim oBook As Excel._Workbook '= CType(oExcel.Workbooks.Add(Missing.Value), Excel._Workbook)
        Dim oSheet As Excel._Worksheet = CType(oBook.ActiveSheet, Excel._Worksheet)

        Dim oRange As Excel.Range = oSheet.Range("A1")
        oRange = oRange.Resize(iRowCount, iColCount)
        oRange.Value = oData

        oSheet.SaveAs(sFileName)
        oExcel.Workbooks.Close()
        oExcel.Quit()

        oBook = Nothing
        oSheet = Nothing
        oExcel = Nothing
    End Function
End Class

#End Region

#Region "Propiedas Excel"

Public Class Propiedades_Excel

    Public Sub _xlDibujar_Bordes(ByVal _hoja As Excel.Worksheet, ByVal _rango As String)
        Dim icount As Integer

        Try
            For icount = 7 To 12
                With _hoja.Range(_rango).Borders(icount)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
            Next
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _xlSumar(ByVal _hoja As Excel.Worksheet, ByVal _columnas As String, ByVal _row_inicio As Integer, ByVal _row_final As Integer)
        Dim columna, myrange As String

        For Each columna In _columnas
            myrange = columna & _row_inicio.ToString & ":" & _
                      columna & _row_final.ToString
            _hoja.Range(columna & (_row_final + 1).ToString).Value = "@SUMA(" & myrange & ")"
        Next
    End Sub

    Public Sub _xlInicializar_Hoja(ByVal _hoja As Excel.Worksheet, ByVal _name As String)
        _hoja.Select()
        Dim myrange As String = "A1:Z1000"
        _hoja.Range(myrange).Font.Size = 8
        If _name.Length > 0 Then
            _hoja.Name = _name
        End If
        _hoja.Application.ActiveWindow.Zoom = 90

    End Sub

    Public Sub _xlFinalizar_Libro(ByVal _libro As Excel.Workbook)
        Dim _hoja As Excel.Worksheet

        For Each _hoja In _libro.Worksheets
            If _hoja.Name.ToLower.StartsWith("hoj") Then
                _hoja.Delete()
            End If
        Next

    End Sub

    Public Sub _xl_formulas_vertical(ByVal _hoja As Excel.Worksheet, ByVal _celdadestino As String, ByVal _rinicio As Integer, _
                                       ByVal _celda1 As String, ByVal _celda2 As String, ByVal _operador As String, ByVal _rmaximo As Integer)
        Dim nvacias As Integer
        Dim ox As Excel.Range
        Dim formula As String
        nvacias = 0



        Do While True
            _rinicio += 1


            Try

                If _hoja.Range(_celdadestino & _rinicio.ToString).Value = 0 Then
                    nvacias += 0
                Else

                    '_hoja.Range("A3").FormulaR1C1 = ""
                    ox = _hoja.Range(_celdadestino & _rinicio.ToString)
                    'ox.FormulaR1C1 = "=RC[-1]/RC[-3]"
                    formula = "=" & _celda1 & _rinicio.ToString & _operador & _celda2 & _rinicio.ToString
                    ox.Value = formula
                End If
            Catch ex As Exception
                nvacias += 1

            End Try
            If nvacias > 10 Then
                Exit Do
            End If
            If _rinicio > _rmaximo Then
                Exit Do
            End If


        Loop


    End Sub

    Public Sub _xlQuitarFondoyBordes(ByRef _hoja As Excel.Worksheet, ByVal quitartitulosLeyenda As Boolean)

        Try

            For Each xco As Excel.ChartObject In _hoja.ChartObjects
                'Dim xco As Excel.ChartObject
                ' xco = _hoja.ChartObjects(myshape.Name)
                With xco
                    .Interior.ColorIndex = -4142
                    .Border.LineStyle = -4142
                End With


                If quitartitulosLeyenda Then
                    With xco.Chart.Legend
                        .Position = Excel.XlLegendPosition.xlLegendPositionBottom
                        .Border.LineStyle = -4142
                        .Interior.ColorIndex = -4142
                    End With
                End If



            Next



        Catch ex As Exception
        Finally
        End Try
    End Sub

End Class

#End Region

#Region "Importar Excel"
Public Class importar_excel
    Dim mExcel As Excel.Application
    Dim libro As Excel.Workbook
    Dim hoja As Excel.Worksheet
    Public pNombreArchivo As String = String.Empty
    Public pNombreHoja As String = String.Empty
    Public pNombreColumnas As String = String.Empty
    'Dim libro As New Excel.Workbook
    ' Dim hoja As New Excel.Worksheet


    Public Sub New()
        mExcel = New Excel.Application
    End Sub

    Public Function obtener_encabezadosOld() As String()
        libro = mExcel.Workbooks.Open(pNombreArchivo)
        Dim encabezados(13) As String
        hoja = libro.Sheets.Item(pNombreHoja)

        Dim nrow, ncol, nvacias As Integer


        nrow = 1
        nvacias = 0

        'Do While True
        '    nrow += 1


        Try


            If hoja.Cells(nrow, 1).Value.ToString.Length = 0 Then
                nvacias += 1
            Else
                For ncol = 1 To 14
                    Try
                        encabezados(ncol - 1) = hoja.Cells(nrow, ncol).Value.ToString()
                    Catch ex As Exception
                        'ReDim encabezados(ncol - 1)
                        Exit For

                    End Try
                Next

            End If


        Catch ex As Exception

        End Try
        'Loop

        Return encabezados
    End Function

    Public Function obtenerEncabezados() As String()
        libro = mExcel.Workbooks.Open(pNombreArchivo)
        Dim encabezados(13) As String
        hoja = libro.Sheets.Item(pNombreHoja)

        Dim nrow, ncol, nvacias As Integer


        nrow = 1
        nvacias = 0

        'Do While True
        '    nrow += 1


        Try


            If hoja.Cells(nrow, 1).Value.ToString.Length = 0 Then
                nvacias += 1
            Else
                For ncol = 1 To 14
                    Try
                        encabezados(ncol - 1) = hoja.Cells(nrow, ncol).Value.ToString()
                    Catch ex As Exception
                        'ReDim encabezados(ncol - 1)
                        Exit For

                    End Try
                Next

            End If


        Catch ex As Exception

        End Try
        'Loop

        Return encabezados
    End Function

    Public Function Obtener_Hojas() As String()
        libro = mExcel.Workbooks.Open(pNombreArchivo)
        Dim nombre_hojas() As String

        ReDim nombre_hojas(libro.Sheets.Count - 1)
        Dim icount As Integer = 0

        For Each hoja In libro.Sheets
            nombre_hojas(icount) = hoja.Name
            icount += 1
        Next


        Return nombre_hojas
    End Function


    Public Function obtener_registros(ByVal pNombreArchivo As String, ByVal nNumeroColumnas As Integer) As DataTable

        Dim dt As New DataTable
        Try


            Dim libro As Excel.Workbook
            Dim hoja As Excel.Worksheet


            Dim dr As DataRow
            Dim nrow, ncol, nvacias As Integer
            Dim scampo As String

            libro = mExcel.Workbooks.Open(pNombreArchivo)
            hoja = libro.Sheets.Item(1)
            dt = Crear_Estructura(nNumeroColumnas)
            nrow = 1
            nvacias = 0

            Do While True
                nrow += 1


                Try

                    'hoja.Cells(nrow, 1) = drv.Item("corriente")
                    'hoja.Cells(nrow, 2) = drv.Item("1-15")

                    If hoja.Cells(nrow, 1).Value.ToString.Length = 0 Then
                        nvacias += 1
                    Else

                        dr = dt.NewRow
                        For ncol = 1 To nNumeroColumnas
                            scampo = "Columna" & ncol
                            dr.Item(scampo) = hoja.Cells(nrow, ncol).Value.ToString
                        Next


                        dt.Rows.Add(dr)
                        '_hoja.Range("A3").FormulaR1C1 = ""
                    End If
                Catch ex As Exception
                    nvacias += 1

                End Try
                If nvacias > 10 Then
                    Exit Do
                End If


            Loop


        Catch ex As Exception

        End Try
        Return dt


    End Function

    Public Function obtener_registros_nombres() As DataTable

        Dim dt As DataTable
        Dim dr As DataRow
        Dim nrow, ncol, nvacias As Integer
        Dim scampo As String
        Dim columnas() As String = pNombreColumnas.Split(",")
        Dim icount As Integer = 0
        Dim numerocolumnas(columnas.Length - 1) As Integer
        'antes tenia 14

        libro = mExcel.Workbooks.Open(pNombreArchivo)
        hoja = libro.Sheets.Item(pNombreHoja)
        dt = Crear_Estructura_nombres()
        nrow = 1
        nvacias = 0

        ''
        For ncol = 1 To columnas.Length - 1
            If pNombreColumnas.ToString.IndexOf(hoja.Cells(1, ncol).value.ToString.trim) > 0 Then
                numerocolumnas(nvacias) = ncol
                nvacias += 1

                'For icount = 0 To columnas.Length
                '    If columnas(icount) = hoja.Cells(1, ncol).value.ToString Then
                '        Exit For
                '    End If
                'Next
                'scampo = columnas(icount)
                'dr.Item(scampo) = hoja.Cells(nrow, ncol).Value.ToString
            End If
        Next
        nvacias = 0


        Do While True
            nrow += 1

            Try
                If hoja.Cells(nrow, 1).Value.ToString.Length = 0 Then
                    nvacias += 1
                Else
                    dr = dt.NewRow
                    Try
                        For icount = 0 To numerocolumnas.Length - 2
                            Try
                                scampo = hoja.Cells(1, numerocolumnas(icount)).value.ToString
                                dr.Item(scampo.Trim) = hoja.Cells(nrow, numerocolumnas(icount)).value.ToString
                            Catch ex As Exception

                            End Try

                        Next



                        ''For ncol = 1 To 14
                        ''    If pNombreColumnas.ToString.IndexOf(hoja.Cells(1, ncol).value.ToString) > 0 Then
                        ''        For icount = 0 To columnas.Length
                        ''            If columnas(icount) = hoja.Cells(1, ncol).value.ToString Then
                        ''                Exit For
                        ''            End If
                        ''        Next
                        ''        scampo = columnas(icount)
                        ''        dr.Item(scampo) = hoja.Cells(nrow, ncol).Value.ToString
                        ''    End If
                        ''Next

                    Catch ex As Exception
                    End Try
                    dt.Rows.Add(dr)

                End If
            Catch ex As Exception
                nvacias += 1

            End Try
            If nvacias > 10 Then
                Exit Do
            End If
        Loop

        Return dt
    End Function


    Private Function Crear_Estructura(ByVal nNumeroColumnas As Integer) As DataTable
        Dim dt As New DataTable
        Dim icount As Integer

        For icount = 1 To nNumeroColumnas
            dt.Columns.Add(New DataColumn("Columna" & icount, GetType(String)))
        Next


        Return dt
    End Function

    Private Function Crear_Estructura_nombres() As DataTable
        Dim dt As New DataTable
        Dim icount As Integer
        Dim columnas() As String = pNombreColumnas.Split(",")

        For icount = 1 To columnas.Length - 1
            dt.Columns.Add(New DataColumn(columnas(icount).Trim, GetType(String)))
        Next

        Return dt
    End Function

    Public Function Cerrar_Libros()
        Try

            'hoja = Nothing
            'libro.Close()
            'libro = Nothing
        Catch ex As Exception
        End Try

        Try
            mExcel.Workbooks.Close()
            mExcel.Quit()
            mExcel = Nothing
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function Cerrar_libro()
        Try
            libro.Close(False)
            libro = Nothing
            mExcel.Workbooks.Close()
            mExcel.Quit()
            mExcel = Nothing
        Catch ex As Exception
        End Try

        Return True
    End Function

End Class
#End Region

#Region "Manejar Crystal"

''Para que funcione se tiene que hacer referencia
''Al archivo craxdrt.dll de C:\Archivos de programa\Seagate Software\Crystal Reports\Developer Files\include
''de la version developer 8.5
''En Windows System sscsdk80.dll y pg32conv.dll

Public Class Reportes_CraxDrt
    Dim CrRp As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim CrAp As New frm_craxdrt_viewer_aut
    Dim ClsGen As New ClasesGenerales.General
    Dim psempresa As String
    Dim pmodal As Boolean = True
    Public Archivo_Generado As String = String.Empty
    Public Descripcion_Error As String = String.Empty
    Public pnNumeroCopias As Integer = 1
    Public psUsuario As String = String.Empty
    Public psImpresora As String = String.Empty
    Public psPort As String = String.Empty

    Dim Parametros As ParameterFields = New ParameterFields()
    Dim PrimerParametro As ParameterField = New ParameterField()
    Dim SegundoParametro As ParameterField = New ParameterField()
    Dim myDiscreteValue1 As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()

    Public Sub New(ByVal sempresa As String)
        psempresa = sempresa
    End Sub

    Public Sub New(ByVal sempresa As String, ByVal modal As Boolean)
        psempresa = sempresa
        pmodal = modal
    End Sub

    Public Sub finalizar()

        Try
            CrRp.Close()
            CrRp = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _exportar_reporte(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal oPanel As Windows.Forms.Panel, _
                    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal exportar As Boolean, _
                        ByVal imprimir As Boolean, ByVal acciones As String, ByVal tipo_exportar As String, _
                        ByVal proceso_adicional As Array)
        Dim iConnectionInfo As ConnectionInfo = New ConnectionInfo()
        Try
            CrRp = New ReportDocument
            CrRp.Load(path_reporte)

            _Inicializar_reporte_CRAXDRT(path_reporte, _pServidor, _pBase_datos, _pUsuario)

            If proceso_adicional(0) = 1 Then
                Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
                System.Threading.Thread.Sleep(1000)
            End If

            _procesar_reporte_CRAXDRT(path_reporte, pm_parametros, oPanel, _pServidor, _pBase_datos, _pUsuario)

            If exportar Then
                '            'If acciones.LastIndexOf("E") >= 0 Then
                If tipo_exportar.Length > 0 Then
                    hacer_exportar(tipo_exportar, True, False)
                Else
                    'MessageBox.Show("No Tiene Permisos Para Exportar", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If imprimir Then
                    If acciones.ToUpper.LastIndexOf("P") >= 0 Then
                        '                    CrRp.PrintOut(True, pnNumeroCopias)
                        If psImpresora.Length > 0 Then
                            'CrRp.s.SelectPrinter("winspool", psImpresora, psPort)
                        End If
                        CrRp.PrintToPrinter(pnNumeroCopias, True, 0, 0)
                        Dim oform As New frm_craxdrt_viewer_aut
                        oform.AxCRV.ReportSource = CrRp
                        oform.Dispose()
                        oform = Nothing
                    End If
                Else  ''Vista Previa

                    Dim oForm As New frm_craxdrt_viewer_aut
                    oForm.AxCRV.ReportSource = CrRp
                    'oForm.Acciones = acciones

                    'oForm.Tipo_Exportar = tipo_exportar

                    '' ''x=Ejecutar en Vista Previa
                    If acciones.ToUpper.LastIndexOf("X") >= 0 Then
                        oForm.AxCRV.ShowExportButton = True

                    End If

                    'oForm.llenarReporte()
                    If pmodal Then
                        oForm.ShowDialog()
                        oForm.Dispose()
                        oForm = Nothing
                    Else
                        oForm.Show()
                    End If
                    ''End If

                    ''If oForm.descripcion_error.Length > 0 Then
                    ''    clsGen.Escribir_Log(Now() & " error forma " & oForm.descripcion_error)
                    ''End If

                    'Dim Oaut As New AutomatizacionCrystal.Crystal
                    'Oaut.mostrarReporte(CrRp, acciones, tipo_exportar)
                    'Oaut = Nothing
                    ''oform.AxCRV.ReportSource = CrRp
                    ''oform.AxCRV.ViewReport()
                    '                'Dim nLicensed As Object
                    'Dim nActive As Object
                    'Dim blnResult As Object
                    'Dim strMsgActive As String
                    'Dim strMsgLicensed As String
                    'Dim strMsg As String

                    'blnResult = CrAp.GetLicenseStatus(nLicensed, nActive)
                    'If blnResult = True Then
                    '    strMsgActive = CStr(nActive - 1)
                    'Else
                    '    strMsgActive = CStr(nActive)
                    'End If
                    'strMsgLicensed = CStr(nLicensed)
                    'MessageBox.Show(strMsgActive & " License(s) of " & strMsgLicensed & " licenses used.")
                    'If tipo_exportar.LastIndexOf("*") >= 0 Then
                    'And acciones.LastIndexOf("E") >= 0 Then
                    'oform.AxCRV.EnableExportButton = True
                    'Else
                    '    oform.AxCRV.EnableExportButton = False
                    'End If

                    'Permisos para Imprimir
                    'If acciones.LastIndexOf("P") >= 0 Then
                    'oform.AxCRV.EnablePrintButton = True
                    'Else
                    '    oform.AxCRV.EnablePrintButton = False
                    'End If



                    'oform.Dispose()
                    'oform = Nothing

                    'Dim oform As New frm_craxdrt_viewer_aut
                    'oform.CrRpV = CrRp

                    'oform.AxCRV.ReportSource = CrRp
                    'oform.AxCRV.ViewReport()
                    'oform.ShowDialog()

                End If
            End If

        Catch ex As Exception
            clsGen.Escribir_Log(Now() & " source " & ex.Source)
            clsGen.Escribir_Log(Now() & " message " & ex.Message)
            ClsGen.Escribir_Log(Now() & " data " & ex.Data.ToString)
            'MessageBox.Show(ex.Message & ex.Source)
        Finally


            'Dim intNumReports As Integer = 1
            ' Dim intNumApps As Integer = 1
            'If IsReference(CrRp) Then
            'Do
            '    intNumReports = System.Runtime.InteropServices.Marshal.ReleaseComObject(CrRp)
            'Loop While intNumReports > 0

            ''Correr Proceso despues que termine de generar el reporte
            If proceso_adicional(0) = 0 Then
                Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
                System.Threading.Thread.Sleep(1000)
            End If
            CrRp = Nothing
            CrAp = Nothing

            'End If
            'If IsReference(CrAp) Then
            'Do
            'intNumApps = System.Runtime.InteropServices.Marshal.ReleaseComObject(CrAp)
            'Loop While intNumApps > 0
            ' CrAp = Nothing
            'End If

            'GC.Collect()
            'clsGen = Nothing

        End Try

    End Sub

    Private Sub _Inicializar_reporte_CRAXDRT(ByVal path_reporte As String, _
            ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String)
        Dim i_count, i_aux As Integer
        Dim ls_valor As String
        Dim pm_conexion(3) As String
        Dim buffer(50) As String
        Dim cadena(3) As String
        Dim la_valores(2) As String
        Try
            'Aplico Seguridad Dependiendo 
            For i_count = 0 To 3
                cadena(i_count) = ""
            Next
            'ls_valor = CrRp.Database.Tables(1).ConnectBufferString
            ls_valor = CrRp.Database.Tables(0).ToString
            buffer = ls_valor.Replace(";", "=").Split("=")
            Try
                For i_count = 0 To 49
                    If buffer(i_count) = "PreQEServerName" Then
                        cadena(0) = buffer(i_count + 1)
                    End If
                    If buffer(i_count) = "DATABASE" Then
                        cadena(1) = buffer(i_count + 1)
                    End If
                    If buffer(i_count) = "UserId" Then
                        cadena(2) = buffer(i_count + 1)
                    End If
                    If cadena(0).Trim.Length > 0 And _
                        cadena(1).Trim.Length > 0 And _
                            cadena(2).Trim.Length > 0 Then
                        Exit For
                    End If
                Next
            Catch ex As Exception
                If _pServidor.ToUpper = "vDATASERVER" Then
                    cadena(0) = "vDATASERVER"
                    cadena(1) = "BDFlexline"
                    cadena(2) = "flexline"
                Else
                    cadena(0) = _pServidor
                    cadena(1) = _pBase_datos
                    cadena(2) = _pUsuario
                End If
            End Try

            pm_conexion = Obtener_Seguridad_Reporte(cadena(0))


            If pm_conexion(3).ToString.Length > 0 Then
                cadena(3) = pm_conexion(3)
            Else

                '            'verifico la cadena de conexion
                If cadena(2).ToUpper = "FLEXLINE" Then
                    cadena(3) = "flexline"
                ElseIf cadena(2).ToUpper = "SYSGOLD" Then
                    cadena(3) = "sysgold"
                Else
                    cadena(3) = "sa"
                End If

            End If
            Dim logOnInfo As TableLogOnInfo

            '        'Aplico Seguridad
            If cadena(1).ToString.IndexOf(":\") = -1 Then
                For i_aux = 0 To CrRp.Database.Tables.Count() - 1
                    Dim t As CrystalDecisions.CrystalReports.Engine.Table
                    t = CrRp.Database.Tables(i_aux)
                    logOnInfo = t.LogOnInfo
                    logOnInfo.ReportName = CrRp.Name
                    logOnInfo.ConnectionInfo.ServerName = cadena(0)
                    logOnInfo.ConnectionInfo.DatabaseName = cadena(1)
                    logOnInfo.ConnectionInfo.UserID = cadena(2)
                    logOnInfo.ConnectionInfo.Password = cadena(3)
                    logOnInfo.TableName = t.Name
                    CrRp.Database.Tables(i_aux).ApplyLogOnInfo(logOnInfo)
                Next
            End If


        Catch ex As Exception
            Dim m As String = ex.Message
            'MessageBox.Show("Inicalizar Reporte ", ex.Message)
        End Try

    End Sub

    Private Sub _procesar_reporte_CRAXDRT(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, _
                    ByVal _pServidor As String, ByVal _pBase_Datos As String, ByVal _pUsuario As String)

        'Dim paradef As ParameterFieldDefinition
        Dim i_count, i_aux, i_count2 As Integer
        Dim itemnum, imultiple As Integer
        Dim ls_valor As String
        Dim buffer(50) As String
        Dim cadena(3) As String
        Dim la_valores(2) As String

        '    'LLeno los Parametros
        Try
            i_count = -1

            For Each paradef As ParameterField In CrRp.ParameterFields
                Try

                    i_count = i_count + 1
                    'If paradef.NeedsCurrentValue Then
                    'If paradef.CurrentValues. Then

                    If paradef.DiscreteOrRangeKind = DiscreteOrRangeKind.DiscreteValue Then
                        'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
                        If paradef.ParameterFieldName.ToUpper.IndexOf("EMPRESA") >= 0 Then
                            'paradef.CurrentValues.AddValue(psempresa)
                            paradef.CurrentValues.Clear()
                            CrRp.SetParameterValue(paradef.Name, psempresa)
                        ElseIf paradef.ParameterFieldName.ToUpper.IndexOf("USER_NAME") >= 0 Then
                            paradef.CurrentValues.Clear()
                            paradef.CurrentValues.AddValue(psUsuario)
                        Else
                            For i_aux = 0 To opanel.Controls.Count - 1
                                If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                    itemnum = i_aux
                                    Exit For
                                End If
                            Next
                            If paradef.EnableAllowMultipleValue Then
                                paradef.CurrentValues.Clear()
                                imultiple = paradef.CurrentValues.Count
                                imultiple = IIf(imultiple < 1, 700, imultiple)
                                Dim lsValores As String = String.Empty


                                Dim valoresParametros As ArrayList = New ArrayList()
                                Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                    '    '-1
                                    For i_count2 = 1 To imultiple
                                        ls_valor = String.Empty
                                        ls_valor = pm_parametros(i_count, i_count2)
                                        If ls_valor.Trim.Length > 0 Then
                                            valoresParametros.Add(ls_valor)
                                        End If
                                        If lsValores.Length > 0 And ls_valor.Length > 0 Then
                                            lsValores = lsValores + ","
                                        End If
                                        If ls_valor.Length > 0 Then
                                            lsValores = lsValores + ls_valor
                                        End If
                                    Next
                                Catch ex As Exception
                                Finally
                                    'SetCurrentValuesForParameterField(CrRp, valoresParametros, paradef.Name)
                                    'CrRp.SetParameterValue(paradef.Name, valoresParametros)
                                    'CrRp.SetParameterValue(paradef.Name, lsValores)
                                    Dim crParameterValues As New ParameterValues
                                    Dim crParameterDiscreteValue As New ParameterDiscreteValue
                                    'Dim crParameterFieldDefinition As ParameterFieldDefinition

                                    crParameterValues = paradef.CurrentValues
                                    Try
                                        For i As Integer = 0 To lsValores.Split(",").Length
                                            If i > 0 Then
                                                crParameterDiscreteValue = Nothing
                                            End If
                                            If lsValores.Split(",")(i).Trim.Length > 0 Then
                                                crParameterDiscreteValue = New ParameterDiscreteValue()
                                                crParameterDiscreteValue.Value = lsValores.Split(",")(i)
                                                crParameterValues.Add(crParameterDiscreteValue)
                                            End If
                                        Next
                                    Catch ex As Exception

                                    End Try

                                    paradef.CurrentValues = crParameterValues

                                End Try
                            Else
                                Try
                                    paradef.CurrentValues.Clear()

                                    Select Case paradef.ParameterValueType
                                        Case ParameterValueKind.NumberParameter
                                            CrRp.SetParameterValue(paradef.Name, Double.Parse(pm_parametros(i_count, 1).ToString))
                                            paradef.CurrentValues.AddValue(Double.Parse(pm_parametros(i_count, 1).ToString))
                                        Case ParameterValueKind.DateParameter
                                            CrRp.SetParameterValue(paradef.Name, System.DateTime.Parse(pm_parametros(i_count, 1).ToString))
                                            paradef.CurrentValues.AddValue(System.DateTime.Parse(pm_parametros(i_count, 1).ToString))
                                        Case ParameterValueKind.StringParameter
                                            CrRp.SetParameterValue(paradef.Name, (pm_parametros(i_count, 1).ToString))
                                            paradef.CurrentValues.AddValue((pm_parametros(i_count, 1).ToString))
                                        Case ParameterValueKind.DateTimeParameter
                                            CrRp.SetParameterValue(paradef.Name, System.DateTime.Parse(pm_parametros(i_count, 1).ToString))
                                            paradef.CurrentValues.AddValue(System.DateTime.Parse(pm_parametros(i_count, 1).ToString))
                                    End Select

                                    'CrRp.SetParameterValue(paradef.Name, psempresa)
                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Else ''paradef.DiscreteOrRangeKind
                        For i_aux = 0 To opanel.Controls.Count - 1
                            If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                itemnum = i_aux
                                Exit For
                            End If
                        Next
                        If paradef.EnableAllowMultipleValue = False Then
                            paradef.CurrentValues.Clear()
                            Select Case paradef.ParameterValueType
                                Case FieldValueType.NumberField
                                    'paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    paradef.CurrentValues.AddRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), RangeBoundType.NoBound, RangeBoundType.NoBound)
                                Case FieldValueType.DateField
                                    'paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    paradef.CurrentValues.AddRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), RangeBoundType.NoBound, RangeBoundType.NoBound)
                                Case FieldValueType.StringField
                                    'paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
                                    paradef.CurrentValues.AddRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), RangeBoundType.NoBound, RangeBoundType.NoBound)
                                Case FieldValueType.Int32sField
                                    Dim rangeParam As New ParameterRangeValue()
                                    Dim currentValues As ParameterValues
                                    rangeParam.StartValue = pm_parametros(i_count, 1)
                                    rangeParam.EndValue = pm_parametros(i_count + 25, 1)
                                    currentValues = paradef.CurrentValues
                                    currentValues.Add(rangeParam)
                                    'paradef.ApplyCurrentValues(currentValues)
                                    paradef.CurrentValues = currentValues
                                    'paradef.CurrentValues.AddRange(Int32.Parse(pm_parametros(i_count, 1)), Int32.Parse(pm_parametros(i_count + 25, 1)), RangeBoundType.NoBound, RangeBoundType.NoBound)
                            End Select
                        Else
                            paradef.CurrentValues.Clear()
                            imultiple = paradef.CurrentValues.Count()
                            imultiple = IIf(imultiple < 1, 700, imultiple)
                            For i_count2 = 1 To imultiple - 1
                                Try
                                    ls_valor = pm_parametros(i_count, i_count2)
                                    If ls_valor.Trim.Length > 0 Then
                                        la_valores = ls_valor.Split(",")
                                        'paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
                                        paradef.CurrentValues.AddRange(la_valores(0), la_valores(1), RangeBoundType.NoBound, RangeBoundType.NoBound)

                                    End If
                                Catch ex As Exception
                                    Exit For
                                End Try

                            Next
                        End If
                    End If ''paradef.DiscreteOrRangeKind
                    'End If ''paradef.NeedsCurrentValue


                Catch ex As Exception

                End Try
            Next ''crrp.ParameterFields
        Catch ex As Exception
            ''MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub SetCurrentValuesForParameterField(ByVal myReportDocument As ReportDocument, ByVal myArrayList As ArrayList, param As String)
        Dim currentParameterValues As ParameterValues = New ParameterValues()
        For Each submittedValue As Object In myArrayList
            Dim myParameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
            myParameterDiscreteValue.Value = submittedValue.ToString()
            currentParameterValues.Add(myParameterDiscreteValue)
        Next
        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(param)
        myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues)
    End Sub



    Public Sub _reporte_generico2(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean)
        Dim info As New ReportDocument
        Try
            info.Load(path_reporte)


            info.SetParameterValue("@Empresa", "CODICASA")
            CrRp.SetParameterValue("@Empresa", "CODICASA")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _reporte_generico(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean)

        Dim Sfd = New System.Windows.Forms.SaveFileDialog
        Descripcion_Error = String.Empty
        Dim i_aux, i_count2 As Integer
        Dim imultiple As Integer
        Dim cadena(3) As String
        Dim ls_valores(2) As String
        Dim ls_valor As String


        Try

            Dim info As New ReportDocument
            'info.Load("C:\Nueva carpeta\WindowsApplication1\WindowsApplication1\CrystalReport1.rpt")
            info.Load(path_reporte)

            ''Aplico Seguridad 
            cadena(0) = _pServidor
            cadena(1) = _pBase_datos
            cadena(2) = _pUsuario
            cadena(3) = _ppwd

            Dim logOnInfo As TableLogOnInfo

            'autentica con la conexión que trae definida el .rpt
            For Each t As CrystalDecisions.CrystalReports.Engine.Table In info.Database.Tables
                logOnInfo = t.LogOnInfo
                logOnInfo.ReportName = info.Name
                logOnInfo.ConnectionInfo.ServerName = cadena(0)
                logOnInfo.ConnectionInfo.DatabaseName = cadena(1)
                logOnInfo.ConnectionInfo.UserID = cadena(2)
                logOnInfo.ConnectionInfo.Password = cadena(3)
                logOnInfo.TableName = t.Name
                t.ApplyLogOnInfo(logOnInfo)
            Next

            Dim currentValues As CrystalDecisions.Shared.ParameterValues
            Dim newValue As CrystalDecisions.Shared.ParameterDiscreteValue



            'Recorro los parametros
            'For Each paradef In info.ParameterFields
            For Each paradef As ParameterFieldDefinition In info.DataDefinition.ParameterFields
                Try
                    currentValues = paradef.CurrentValues
                    currentValues.Clear()
                    For i_aux = 0 To pm_parametros.Length - 1
                        Try
                            If paradef.DiscreteOrRangeKind = DiscreteOrRangeKind.DiscreteValue Then
                                If pm_parametros(i_aux).ToString.ToUpper.Trim.Equals(paradef.ParameterFieldName.ToUpper.Trim) Then
                                    If paradef.EnableAllowMultipleValue Then
                                        '    ''Revisar los valores que llevo en el arreglo

                                        'paradef.ClearCurrentValueAndRange()
                                        paradef.CurrentValues.Clear()
                                        ReDim ls_valores(100)
                                        ls_valores = pm_valores(i_aux).ToString.Split(",")
                                        'imultiple = paradef.NumberOfCurrentValues
                                        imultiple = paradef.CurrentValues.Count
                                        imultiple = IIf(imultiple < 1, 120, imultiple)
                                        Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                            '        '    '-1
                                            For i_count2 = 0 To ls_valores.Length - 1
                                                'ls_valores = pm_parametros(i_count, i_count2)
                                                ls_valores = pm_parametros(imultiple, i_count2)
                                                If ls_valores(i_count2).Length > 0 Then
                                                    paradef.CurrentValues.Add(ls_valores(i_count2))
                                                    'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
                                                    paradef.DefaultValues.Add(pm_parametros(imultiple, i_count2))
                                                End If
                                            Next
                                        Catch ex As Exception
                                        End Try
                                    Else

                                        paradef.CurrentValues.Clear()
                                        Select Case paradef.ValueType
                                            Case FieldValueType.NumberField
                                                'myDiscreteValue1.Value = Double.Parse(pm_valores(i_aux))
                                                'paradef.ApplyCurrentValues(myDiscreteValue1.Value)
                                                newValue = New CrystalDecisions.Shared.ParameterDiscreteValue()
                                                newValue.Value = pm_valores(i_aux)
                                                currentValues.Add(newValue)
                                                ' paradef.CurrentValues.Add(Double.Parse(pm_valores(i_aux)))
                                            Case FieldValueType.DateField

                                                'myDiscreteValue1.Value = System.DateTime.Parse(pm_valores(i_aux))
                                                ' paradef.ApplyCurrentValues(myDiscreteValue1.Value)
                                                newValue = New CrystalDecisions.Shared.ParameterDiscreteValue()
                                                newValue.Value = pm_valores(i_aux)
                                                currentValues.Add(newValue)
                                                'paradef.CurrentValues.Add(System.DateTime.Parse(pm_valores(i_aux)))

                                            Case FieldValueType.StringField
                                                'myDiscreteValue1.Value = (pm_valores(i_aux))
                                                'paradef.ApplyCurrentValues(myDiscreteValue1.Value)
                                                newValue = New CrystalDecisions.Shared.ParameterDiscreteValue()
                                                newValue.Value = pm_valores(i_aux)
                                                currentValues.Add(newValue)
                                            Case FieldValueType.DateTimeField
                                                'paradef.CurrentValues.Add(System.DateTime.Parse(pm_valores(i_aux)))

                                                'myDiscreteValue1.Value = System.DateTime.Parse(pm_valores(i_aux))
                                                'paradef.ApplyCurrentValues(myDiscreteValue1.Value)
                                                newValue = New CrystalDecisions.Shared.ParameterDiscreteValue()
                                                newValue.Value = pm_valores(i_aux)
                                                currentValues.Add(newValue)
                                        End Select
                                        ''  End If
                                    End If

                                    paradef.ApplyCurrentValues(currentValues)
                                End If


                                'Lista de valores

                            Else

                                'If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                    Dim a = New CrystalDecisions.Shared.ParameterRangeValue
                                    paradef.CurrentValues.Clear()
                                    imultiple = paradef.CurrentValues.Count
                                    imultiple = IIf(imultiple < 1, 15, imultiple)
                                    For i_count2 = 1 To imultiple - 1
                                        '    '        'ls_valor = pm_parametros(i_count, i_count2)
                                        ls_valor = pm_parametros(imultiple, i_count2)

                                        If (ls_valor.Trim.Length > 0) Then
                                            ls_valores = pm_valores(i_aux).ToString.Split(",")
                                            '    paradef.AddCurrentRange(ls_valores(0), ls_valores(1), 3) ????
                                            paradef.CurrentValues.AddRange(ls_valores(0), ls_valores(1), RangeBoundType.NoBound, RangeBoundType.NoBound)
                                        End If
                                    Next

                                End If

                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    Descripcion_Error = ex.Message & " " & ex.ToString
                End Try
            Next


            CrRp = info
            If pexportar Then
                hacer_exportar(_ptipo_exportar, False, _pmostrar_archivo)


            ElseIf imprimir Then
                'CrRp.PrintOut(False, pnNumeroCopias)
                If psImpresora.Length > 0 Then
                    'CrRp.s.SelectPrinter("winspool", psImpresora, psPort)
                    ClsGen.Escribir_Log("Cambia Impresora " & psImpresora)
                    Try
                        info.PrintOptions.PrinterName = psImpresora
                    Catch ex As Exception
                        ClsGen.Escribir_Log(ex.Message)
                    End Try



                End If

                info.PrintToPrinter(pnNumeroCopias, False, 0, 0)
                'Dim oautrep As New automatizacionReportes.automatizacionReportes
                'oautrep.cargarReporteSinMostrar(CrRp, "", "")
                'oautrep = Nothing
                'CrRp = Nothing
                'CrAp = Nothing

                Dim oform As New frm_craxdrt_viewer_aut
                oform.AxCRV.ReportSource = info
                'oform.CrRpV = info

                'oform.AxCRV.ReportSource = CrRp2
                oform.AxCRV = Nothing
                oform.Dispose()
                oform = Nothing


            Else

                'Dim OautRep As New automatizacionReportes.automatizacionReportes
                'OautRep.mostrarReporte(CrRp, "P", "")
                'OautRep = Nothing

                Dim oform As New frm_craxdrt_viewer_aut
                oform.AxCRV.ReportSource = info
                'oform.CrRpV = info

                ' ''oform.AxCRV.ReportSource = CrRp
                ' ''oform.AxCRV.ViewReport()

                If pmodal Then
                    oform.ShowDialog()
                    oform.Dispose()
                    oform = Nothing
                Else
                    oform.Show()
                End If


                'Dim Oaut As New AutomatizacionCrystal.Crystal
                'Oaut.mostrarReporte(CrRp, "XPE", "*")
                'Oaut = Nothing
                'End If
            End If

            If Not info Is Nothing And info.IsLoaded Then
                info.Close()
                CrRp.Close()
            End If


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Descripcion_Error = ex.ToString
        Finally

            ' Sfd = Nothing
            'CrAp = Nothing
            'CrRp = Nothing


        End Try

    End Sub


    'Public Sub _reporte_generico_multipleCarga(ByVal path_reporte As String, _
    '                        ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String)

    '    CrAp = New CRAXDRT.Application
    '    CrRp = New CRAXDRT.Report
    '    Dim cadena(3) As String
    '    Dim i_aux As Integer

    '    Try

    '        ''cargo el reporte
    '        CrRp = CrAp.OpenReport(path_reporte)

    '        CrRp.DiscardSavedData()

    '        ''Aplico Seguridad 
    '        cadena(0) = _pServidor
    '        cadena(1) = _pBase_datos
    '        cadena(2) = _pUsuario
    '        cadena(3) = _ppwd

    '        For i_aux = 1 To CrRp.Database.Tables.Count()
    '            CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
    '        Next

    '    Catch ex As Exception

    '    End Try

    'End Sub

    '  Public Sub _reporte_generico_multiple(ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    'ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean)

    '      '   Dim Sfd = New System.Windows.Forms.SaveFileDialog
    '      Descripcion_Error = String.Empty
    '      Dim paradef As CRAXDRT.ParameterFieldDefinition


    '      Dim ls_valores(2) As String
    '      Dim i_aux, i_count2 As Integer


    '      Try






    '          'Recorro los parametros
    '          For Each paradef In CrRp.ParameterFields
    '              Try
    '                  For i_aux = 0 To pm_parametros.Length - 1
    '                      Try
    '                          If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
    '                              If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
    '                                  If paradef.EnableMultipleValues Then
    '                                      ''Revisar los valores que llevo en el arreglo
    '                                      paradef.ClearCurrentValueAndRange()
    '                                      ReDim ls_valores(100)
    '                                      ls_valores = pm_valores(i_aux).ToString.Split(",")
    '                                      ''imultiple = paradef.NumberOfCurrentValues
    '                                      ''imultiple = IIf(imultiple < 1, 120, imultiple)
    '                                      Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
    '                                          '    '-1
    '                                          For i_count2 = 0 To ls_valores.Length - 1
    '                                              'ls_valor = pm_parametros(i_count, i_count2)
    '                                              If ls_valores(i_count2).Length > 0 Then
    '                                                  paradef.AddCurrentValue(ls_valores(i_count2))
    '                                                  'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
    '                                              End If
    '                                          Next
    '                                      Catch ex As Exception
    '                                      End Try
    '                                  Else
    '                                      Select Case paradef.ValueType
    '                                          Case CRFieldValueType.crNumberField
    '                                              paradef.AddCurrentValue(Double.Parse(pm_valores(i_aux)))
    '                                          Case CRFieldValueType.crDateField
    '                                              paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
    '                                          Case CRFieldValueType.crStringField
    '                                              paradef.AddCurrentValue(pm_valores(i_aux))
    '                                          Case CRFieldValueType.crDateTimeField
    '                                              paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
    '                                      End Select
    '                                  End If
    '                              End If

    '                              'Lista de valores

    '                          Else
    '                              If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
    '                                  paradef.ClearCurrentValueAndRange()
    '                                  'imultiple = paradef.NumberOfCurrentValues()
    '                                  'imultiple = IIf(imultiple < 1, 15, imultiple)
    '                                  'For i_count2 = 1 To imultiple - 1
    '                                  'ls_valor = pm_parametros(i_count, i_count2)
    '                                  'If ls_valor.Trim.Length > 0 Then
    '                                  ls_valores = pm_valores(i_aux).Split(",")
    '                                  paradef.AddCurrentRange(ls_valores(0), ls_valores(1), 3)
    '                                  'End If
    '                                  'Next
    '                              End If
    '                          End If
    '                      Catch ex As Exception
    '                      End Try
    '                  Next
    '              Catch ex As Exception
    '                  'MessageBox.Show(ex.Message)
    '                  Descripcion_Error = ex.Message & " " & ex.ToString
    '              End Try
    '          Next


    '          If pexportar Then
    '              hacer_exportar(_ptipo_exportar, False, _pmostrar_archivo)
    '              'Si se desea exportar el archivo
    '              ' Obtenemos el nombre del archivo
    '              ''Sfd.Filter = "xls|*.xls"
    '              ''Sfd.ShowDialog()

    '              ''exportOpts = CrRp.ExportOptions

    '              ''exportOpts.FormatType = CRExportFormatType.crEFTExcel80
    '              ''exportOpts.ExcelAreaType = CRAreaKind.crDetail
    '              ''exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile

    '              'Exportamos el reporte
    '              ''If Sfd.FileName.Length > 0 Then
    '              ''    exportOpts.DiskFileName = Sfd.FileName
    '              ''    CrRp.Export(False)
    '              ''    MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '              ''End If
    '          Else
    '              If imprimir Then
    '                  CrRp.PrintOut(False)
    '                  'Dim oautrep As New automatizacionReportes.automatizacionReportes
    '                  'oautrep.cargarReporteSinMostrar(CrRp, "", "")
    '                  'oautrep = Nothing
    '                  'CrRp = Nothing
    '                  'CrAp = Nothing
    '                  Dim oform As New frm_craxdrt_viewer_aut
    '                  oform.CrRpV = CrRp

    '                  oform.AxCRV.ReportSource = CrRp
    '                  oform.CrRpV = Nothing
    '                  oform.Dispose()
    '                  oform = Nothing

    '              Else

    '                  'Dim OautRep As New automatizacionReportes.automatizacionReportes
    '                  'OautRep.mostrarReporte(CrRp, "P", "")
    '                  'OautRep = Nothing

    '                  Dim oform As New frm_craxdrt_viewer_aut
    '                  oform.CrRpV = CrRp

    '                  ' ''oform.AxCRV.ReportSource = CrRp
    '                  ' ''oform.AxCRV.ViewReport()

    '                  If pmodal Then
    '                      oform.ShowDialog()
    '                      oform.Dispose()
    '                      oform = Nothing
    '                  Else
    '                      oform.Show()
    '                  End If


    '                  'Dim Oaut As New AutomatizacionCrystal.Crystal
    '                  'Oaut.mostrarReporte(CrRp, "XPE", "*")
    '                  'Oaut = Nothing
    '              End If
    '          End If

    '      Catch ex As Exception
    '          'MessageBox.Show(ex.Message)
    '          Descripcion_Error = ex.ToString
    '      Finally

    '          ' Sfd = Nothing
    '          'CrAp = Nothing
    '          'CrRp = Nothing

    '      End Try

    '  End Sub

    Sub hacer_exportar(ByVal tipo_exportar As String, ByVal preguntar_tipo As Boolean, ByVal pmostrar_archivo As Boolean)

        If tipo_exportar.Length > 0 Then
            '        ' Obtenemos el nombre del archivo
            'Dim exportOpts As CRAXDRT.ExportOptions
            Dim exportOpts As CrystalDecisions.Shared.ExportOptions
            Dim excelFormatOptions As New CrystalDecisions.Shared.ExcelFormatOptions()
            Dim pdfFormatOptions As New CrystalDecisions.Shared.PdfFormatOptions()
            Dim diskOpts As New DiskFileDestinationOptions()
            Dim Sfd = New System.Windows.Forms.SaveFileDialog
            Dim dfDestinationOptions As New DiskFileDestinationOptions()

            Dim tipo_reporte As String

            If preguntar_tipo Then
                Dim oform As New frm_lista
                oform.Llenar_Combo_exportar(tipo_exportar)
                oform.Text = "Seleccion Tipo de Archivo a Exportar"
                oform.Label1.Text = "Tipo"
                oform.ShowDialog()
                tipo_reporte = oform.cmb_lista.Text
                oform = Nothing
            Else
                tipo_reporte = tipo_exportar
            End If


            If Archivo_Generado.Trim.Length = 0 Then
                If tipo_reporte.ToUpper = "EXCEL" Then
                    Sfd.Filter = "Excel|*.xls"

                ElseIf tipo_reporte.ToUpper = "PDF" Then
                    Sfd.Filter = "PDF|*.pdf"
                End If

                Sfd.ShowDialog()
                Archivo_Generado = Sfd.filename

            End If
            exportOpts = New ExportOptions
            'CrRp.Export(excelFormatOptions)
            If tipo_reporte.ToUpper = "EXCEL" Then
                'exportOpts.FormatType = CRExportFormatType.crEFTExcel70
                exportOpts.ExportFormatType = ExportFormatType.Excel
                'exportOpts.ExcelUseTabularFormat = True

                '       exportOpts.ExcelMaintainColumnAlignment = True
                excelFormatOptions.ExcelTabHasColumnHeadings = True
                excelFormatOptions.ExcelAreaType = AreaSectionKind.Detail

                exportOpts.ExportFormatOptions = excelFormatOptions

            End If

            If tipo_reporte.ToUpper = "PDF" Then
                '            exportOpts.FormatType = CRExportFormatType.crEFTPortableDocFormat
                exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
                exportOpts.ExportFormatOptions = Nothing
            End If

            '        exportOpts.ExcelAreaType = CRAreaKind.crDetail
            '        exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile

            '        'Exportamos el reporte
            If Archivo_Generado.Length > 0 Then

                dfDestinationOptions.DiskFileName = Archivo_Generado

                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile
                exportOpts.ExportDestinationOptions = dfDestinationOptions
                Try
                    CrRp.Export(exportOpts)
                Catch ex As Exception

                End Try

                '            CrRp.Export(False)
                'exportOpts = CrRp.Export(excelFormatOptions)
                '            '       MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            Sfd = Nothing
            '    Else
            '        '            MessageBox.Show("Este Reporte No se Puede Exportar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        If pmostrar_archivo Then
            'Dim proceso As Process = New Process
            Process.Start(Archivo_Generado)
            'proceso = Nothing
        End If

    End Sub


    Sub Ejecutar_Proceso_Adicional(ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, ByVal pm_proceso_adicional As Array)
        Dim icount As Integer
        Dim buffer(50) As String
        Dim cadena(3) As String
        Dim la_valores(100) As String
        Dim ls_sql As String

        'ls_sql = pm_proceso_adicional(2).ToString.Substring(0, pm_proceso_adicional(2).ToString.IndexOf("("))
        ls_sql = pm_proceso_adicional(2).ToString.Substring(0, pm_proceso_adicional(2).ToString.IndexOf("(")) & " "
        la_valores = pm_proceso_adicional(2).ToString.Substring(ls_sql.Length, pm_proceso_adicional(2).ToString.IndexOf(")") - (ls_sql.Length)).Split(",")


        For icount = 0 To la_valores.Length - 1
            ls_sql = ls_sql & "'" & Buscar_parametro_especifico(la_valores(icount), opanel, pm_parametros) & "'" & _
                IIf(icount <> la_valores.Length - 1, ",", "")
        Next

        Dim otrans As New Transaccional.Conexion(pm_proceso_adicional(1))
        'Dim otrans As New Transaccional.Conexion("umbral_flexline")
        Try
            otrans.open()
            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error > 0 Then
                'MessageBox.Show(otrans.descripcion_error)
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Function Buscar_parametro_especifico(ByVal nombre_parametro As String, ByVal opanel As Windows.Forms.Panel, ByVal pm_parametros As Array) As String
        Dim icount As Integer
        Dim paradef As ParameterFieldDefinition

        Dim i_count, i_aux, i_count2 As Integer
        Dim itemnum, imultiple As Integer
        Dim ls_valor As String
        Dim valor_retorno As String = String.Empty
        Dim la_valores(100) As String

        icount = -1
        Try

            For Each paradef In CrRp.ParameterFields
                icount = icount + 1

                'If paradef.NeedsCurrentValue Then
                If paradef.HasCurrentValue Then
                    If nombre_parametro.ToLower.Trim <> paradef.ParameterFieldName.ToLower.Trim Then
                        'Exit For
                    Else
                        If paradef.DiscreteOrRangeKind = DiscreteOrRangeKind.DiscreteValue Then
                            'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
                            If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then
                                'paradef.AddCurrentValue(ps_empresa)
                                valor_retorno = psempresa
                                Exit Try
                            ElseIf paradef.ParameterFieldName.ToUpper.IndexOf("USER_NAME") > 0 Then

                                paradef.CurrentValues.Add(psUsuario)

                                Exit Try
                            Else
                                For i_aux = 0 To opanel.Controls.Count - 1
                                    If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                        itemnum = i_aux
                                        Exit For
                                    End If
                                Next
                                'If paradef.EnableMultipleValues Then
                                If paradef.EnableAllowMultipleValue Then
                                    ' paradef.ClearCurrentValueAndRange()
                                    imultiple = paradef.CurrentValues.Count
                                    imultiple = IIf(imultiple < 1, 700, imultiple)
                                    Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                        '    '-1
                                        For i_count2 = 1 To imultiple
                                            ls_valor = pm_parametros(i_count, i_count2)
                                            If ls_valor.Trim.Length > 0 Then
                                                valor_retorno = pm_parametros(i_count, i_count2)
                                                'paradef.AddCurrentValue(pm_parametros(i_count, i_count2))
                                                'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
                                                Exit Try
                                            End If
                                        Next
                                    Catch ex As Exception
                                    End Try
                                Else
                                    Select Case paradef.ValueType
                                        Case FieldValueType.NumberField
                                            'paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
                                        Case FieldValueType.DateField
                                            'paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
                                        Case FieldValueType.StringField
                                            'paradef.AddCurrentValue(pm_parametros(i_count, 1))
                                        Case FieldValueType.DateTimeField
                                            'paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
                                    End Select
                                    valor_retorno = pm_parametros(icount, 1)
                                    Exit Try
                                End If
                            End If
                        Else ''paradef.DiscreteOrRangeKind
                            For i_aux = 0 To opanel.Controls.Count - 1
                                If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                    itemnum = i_aux
                                    Exit For
                                End If
                            Next
                            If Not paradef.EnableAllowMultipleValue Then
                                'paradef.ClearCurrentValueAndRange()
                                Select Case paradef.ValueType
                                    Case FieldValueType.NumberField
                                        'paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    Case FieldValueType.DateField
                                        'paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    Case FieldValueType.StringField
                                        'paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
                                End Select
                            Else
                                'paradef.ClearCurrentValueAndRange()
                                paradef.CurrentValues.Clear()

                                'imultiple = paradef.NumberOfCurrentValues()
                                imultiple = paradef.CurrentValues.Count
                                imultiple = IIf(imultiple < 1, 15, imultiple)
                                For i_count2 = 1 To imultiple - 1
                                    ls_valor = pm_parametros(i_count, i_count2)
                                    If ls_valor.Trim.Length > 0 Then
                                        la_valores = ls_valor.Split(",")
                                        'paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
                                    End If
                                Next
                            End If
                        End If ''paradef.DiscreteOrRangeKind.
                    End If ''nombre_parametro.ToLower <> paradef.ParameterFieldName.ToLower
                End If ''paradef.NeedsCurrentValue
            Next ''crrp.ParameterFields
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
        Return valor_retorno

    End Function

    Private Function Obtener_Seguridad_Reporte(ByVal _conexion As String) As String()

        Dim pm_conexion(3) As String

        Try
            pm_conexion = ClsGen.Parametros_Conexion(_conexion)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

        Return pm_conexion
    End Function

End Class


#End Region

#Region "Facturas Eface"

Public Class Eface
    Dim psempresa As String
    Dim Ods As New DataSet

    Public Sub New(ByVal sempresa As String)
        psempresa = sempresa
    End Sub

    Private Sub Generar_Data(ByVal _tipodocumento As String, ByVal _numerodocumento As String)
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Ods = New DataSet
            oTrans.open()
            ls_sql = "pa_sel_um_documento_detalle '" & _tipodocumento & "','" & psempresa & "','" & _numerodocumento & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "encabezado_documento"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_documentod '" & psempresa & "','" & _tipodocumento & "','" & _numerodocumento & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "detalle_documento"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_var_um_documento '" & psempresa & "','" & _tipodocumento & "','" & _numerodocumento & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "documento"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_var_um_documentop '" & psempresa & "','" & _tipodocumento & "','" & _numerodocumento & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            Ods.Tables.Add(dt.Copy)

            'ls_sql = "pa_sel_um_documento_relacion_detalle '" & _tipodocumento & "','" & psempresa & "','" & _numerodocumento & "'"
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "documento_previo"
            'Ods.Tables.Add(dt.Copy)




        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try


    End Sub



End Class

#End Region

