Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Imports CRAXDRT



#Region "Exportar Excel"

Public Class exportar_excel
    Public ocultar_columnas As String
    Public Texto_Columnas(,) As Integer
    Public Nombre_Columnas As String
    Public nAgregar_Filas As Integer

    Public sEncabezado As String
    Public sTitulo As String
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

                    For Each dc In pdt.Columns
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
                    Next
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



                Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).Columns.AutoFit()
                For icount = 1 To nAgregar_Filas + 2
                    Ws.Rows(icount).Insert()
                Next

                Ws.Cells(1, 1).value = sEncabezado
                Ws.Cells(2, 1).value = sTitulo
                Ws.Range(Ws.Cells(1, 1), Ws.Cells(2, 1)).Font.Bold = True


            Catch ex As Exception
                serror = ex.Message
            End Try


            Try
                File.Delete(pFileName)
            Catch ex As Exception

            End Try

            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)

            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)
            Exc.Visible = True
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
    Dim CrAp As CRAXDRT.Application
    Dim CrRp As CRAXDRT.Report
    Dim psempresa As String
    Dim pmodal As Boolean = True
    Public Archivo_Generado As String = String.empty
    Public Descripcion_Error As String = String.empty
    Public pnNumeroCopias As Integer = 1
    Public psUsuario As String = String.empty

    Public Sub New(ByVal sempresa As String)
        psempresa = sempresa
    End Sub

    Public Sub New(ByVal sempresa As String, ByVal modal As Boolean)
        psempresa = sempresa
        pmodal = modal
    End Sub

    Public Sub finalizar()
        CrAp = Nothing
        CrRp = Nothing
    End Sub

    Public Sub _exportar_reporte(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal oPanel As Windows.Forms.Panel, _
                    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal exportar As Boolean, _
                    ByVal imprimir As Boolean, ByVal acciones As String, ByVal tipo_exportar As String, _
                    ByVal proceso_adicional As Array)

        Dim clsGen As New ClasesGenerales.General
        Try
            CrAp = New CRAXDRT.Application
            CrRp = New CRAXDRT.Report

            _Inicializar_reporte_CRAXDRT(path_reporte, _pServidor, _pBase_datos, _pUsuario)
            'CrRp = CrAp.OpenReport(path_reporte)

            If proceso_adicional(0) = 1 Then
                Ejecutar_Proceso_Adicional(pm_parametros, oPanel, proceso_adicional)
                System.Threading.Thread.Sleep(1000)
            End If

            _procesar_reporte_CRAXDRT(path_reporte, pm_parametros, oPanel, _pServidor, _pBase_datos, _pUsuario)


            If exportar Then
                'If acciones.LastIndexOf("E") >= 0 Then
                If tipo_exportar.Length > 0 Then
                    hacer_exportar(tipo_exportar, True, False)
                Else
                    'MessageBox.Show("No Tiene Permisos Para Exportar", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If imprimir Then
                    If acciones.ToUpper.LastIndexOf("P") >= 0 Then
                        CrRp.PrintOut(True, pnNumeroCopias)
                        Dim oform As New frm_craxdrt_viewer_aut
                        oform.AxCRV.ReportSource = CrRp
                        oform.Dispose()
                        oform = Nothing
                        'Dim oForma As New frmReporte
                        'oForma.CrRpV = CrRp


                        ''oform.AxCRV.ReportSource = CrRp
                        'oForma.CrRpV = Nothing
                        'oForma.Dispose()
                        'oForma = Nothing
                    End If
                Else  ''Vista Previa


                    'Dim Oaut2 As New automatizacionReportes.automatizacionReportes
                    'Oaut2.mostrarReporte(CrRp, acciones, tipo_exportar)
                    'Oaut2 = Nothing
                    'Oaut2.CrRpV = CrRp
                    'Oaut2.Acciones = acciones
                    'Oaut2.Tipo_Exportar = tipo_exportar
                    'Oaut2.ShowDialog()
                    'Oaut2.Dispose()

                    Dim oForm As New frm_craxdrt_viewer_aut
                    oForm.CrRpV = CrRp
                    oForm.Acciones = acciones

                    oForm.Tipo_Exportar = tipo_exportar

                    ' '' ''x=Ejecutar en Vista Previa
                    ' ''If acciones.ToUpper.LastIndexOf("X") >= 0 Then
                    ''oForm.llenarReporte()
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

                    'Dim nLicensed As Object
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
            'clsGen.Escribir_Log(Now() & " data " & ex.Data)
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
            clsGen = Nothing

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

            CrAp.NewReport()
            ''cargo el reporte
            CrRp = CrAp.OpenReport(path_reporte)




            CrRp.DiscardSavedData()

            ''Aplico Seguridad Dependiendo 
            For i_count = 0 To 3
                cadena(i_count) = ""
            Next

            ls_valor = CrRp.Database.Tables(1).ConnectBufferString
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
                If _pServidor.ToUpper = "DATASERVER" Then
                    cadena(0) = "DATASERVER"
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

                'verifico la cadena de conexion
                If cadena(2).ToUpper = "FLEXLINE" Then
                    cadena(3) = "flexline"
                ElseIf cadena(2).ToUpper = "SYSGOLD" Then
                    cadena(3) = "sysgold"
                Else
                    cadena(3) = "sa"
                End If

            End If


            'Aplico Seguridad
            If cadena(1).ToString.IndexOf(":\") = -1 Then
                For i_aux = 1 To CrRp.Database.Tables.Count()
                    CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
                Next
            End If

        Catch ex As Exception
            Dim m As String = ex.Message
            'MessageBox.Show("Inicalizar Reporte ", ex.Message)
        End Try

    End Sub

    Private Sub _procesar_reporte_CRAXDRT(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal opanel As Windows.Forms.Panel, _
                    ByVal _pServidor As String, ByVal _pBase_Datos As String, ByVal _pUsuario As String)



        Dim paradef As CRAXDRT.ParameterFieldDefinition


        Dim i_count, i_aux, i_count2 As Integer
        Dim itemnum, imultiple As Integer
        Dim ls_valor As String
        Dim buffer(50) As String
        Dim cadena(3) As String
        Dim la_valores(2) As String


        '    'LLeno los Parametros
        Try


            i_count = -1

            For Each paradef In CrRp.ParameterFields
                i_count = i_count + 1
                If paradef.NeedsCurrentValue Then

                    If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
                        'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
                        If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then
                            paradef.AddCurrentValue(psempresa)
                        ElseIf paradef.ParameterFieldName.ToUpper.IndexOf("USER_NAME") > 0 Then
                            paradef.AddCurrentValue(psUsuario)
                        Else
                            For i_aux = 0 To opanel.Controls.Count - 1
                                If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                    itemnum = i_aux
                                    Exit For
                                End If
                            Next
                            If paradef.EnableMultipleValues Then
                                paradef.ClearCurrentValueAndRange()
                                imultiple = paradef.NumberOfCurrentValues
                                imultiple = IIf(imultiple < 1, 700, imultiple)
                                Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                    '    '-1
                                    For i_count2 = 1 To imultiple
                                        ls_valor = pm_parametros(i_count, i_count2)
                                        If ls_valor.Trim.Length > 0 Then
                                            paradef.AddCurrentValue(pm_parametros(i_count, i_count2))
                                            paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
                                        End If
                                    Next
                                Catch ex As Exception
                                End Try
                            Else
                                Select Case paradef.ValueType
                                    Case CRFieldValueType.crNumberField
                                        paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
                                    Case CRFieldValueType.crDateField
                                        paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
                                    Case CRFieldValueType.crStringField
                                        paradef.AddCurrentValue(pm_parametros(i_count, 1))
                                    Case CRFieldValueType.crDateTimeField
                                        paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
                                End Select
                            End If
                        End If
                    Else ''paradef.DiscreteOrRangeKind
                        For i_aux = 0 To opanel.Controls.Count - 1
                            If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                itemnum = i_aux
                                Exit For
                            End If
                        Next
                        If paradef.EnableMultipleValues = False Then
                            paradef.ClearCurrentValueAndRange()
                            Select Case paradef.ValueType
                                Case CRFieldValueType.crNumberField
                                    paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
                                Case CRFieldValueType.crDateField
                                    paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
                                Case CRFieldValueType.crStringField
                                    paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
                            End Select
                        Else
                            paradef.ClearCurrentValueAndRange()
                            imultiple = paradef.NumberOfCurrentValues()
                            imultiple = IIf(imultiple < 1, 700, imultiple)
                            For i_count2 = 1 To imultiple - 1
                                Try
                                    ls_valor = pm_parametros(i_count, i_count2)
                                    If ls_valor.Trim.Length > 0 Then
                                        la_valores = ls_valor.Split(",")
                                        paradef.AddCurrentRange(la_valores(0), la_valores(1), 3)
                                    End If
                                Catch ex As Exception
                                    Exit For
                                End Try

                            Next
                        End If
                    End If ''paradef.DiscreteOrRangeKind
                End If ''paradef.NeedsCurrentValue
            Next ''crrp.ParameterFields
        Catch ex As Exception
            ''MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub _reporte_generico(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean)

        '   Dim Sfd = New System.Windows.Forms.SaveFileDialog
        Descripcion_Error = String.Empty
        Dim paradef As CRAXDRT.ParameterFieldDefinition
        Dim i_aux, i_count2 As Integer
        Dim cadena(3) As String
        Dim ls_valores(2) As String


        Try

            CrAp = New CRAXDRT.Application
            CrRp = New CRAXDRT.Report

            ''cargo el reporte
            CrRp = CrAp.OpenReport(path_reporte)
            CrRp.DiscardSavedData()

            ''Aplico Seguridad 
            cadena(0) = _pServidor
            cadena(1) = _pBase_datos
            cadena(2) = _pUsuario
            cadena(3) = _ppwd

            For i_aux = 1 To CrRp.Database.Tables.Count()
                CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
            Next

            'Recorro los parametros
            For Each paradef In CrRp.ParameterFields
                Try
                    For i_aux = 0 To pm_parametros.Length - 1
                        Try
                            If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
                                If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                    If paradef.EnableMultipleValues Then
                                        ''Revisar los valores que llevo en el arreglo
                                        paradef.ClearCurrentValueAndRange()
                                        ReDim ls_valores(100)
                                        ls_valores = pm_valores(i_aux).ToString.Split(",")
                                        ''imultiple = paradef.NumberOfCurrentValues
                                        ''imultiple = IIf(imultiple < 1, 120, imultiple)
                                        Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                            '    '-1
                                            For i_count2 = 0 To ls_valores.Length - 1
                                                'ls_valor = pm_parametros(i_count, i_count2)
                                                If ls_valores(i_count2).Length > 0 Then
                                                    paradef.AddCurrentValue(ls_valores(i_count2))
                                                    'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
                                                End If
                                            Next
                                        Catch ex As Exception
                                        End Try
                                    Else
                                        Select Case paradef.ValueType
                                            Case CRFieldValueType.crNumberField
                                                paradef.AddCurrentValue(Double.Parse(pm_valores(i_aux)))
                                            Case CRFieldValueType.crDateField
                                                paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
                                            Case CRFieldValueType.crStringField
                                                paradef.AddCurrentValue(pm_valores(i_aux))
                                            Case CRFieldValueType.crDateTimeField
                                                paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
                                        End Select
                                    End If
                                End If

                                'Lista de valores

                            Else
                                If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                    paradef.ClearCurrentValueAndRange()
                                    'imultiple = paradef.NumberOfCurrentValues()
                                    'imultiple = IIf(imultiple < 1, 15, imultiple)
                                    'For i_count2 = 1 To imultiple - 1
                                    'ls_valor = pm_parametros(i_count, i_count2)
                                    'If ls_valor.Trim.Length > 0 Then
                                    ls_valores = pm_valores(i_aux).Split(",")
                                    paradef.AddCurrentRange(ls_valores(0), ls_valores(1), 3)
                                    'End If
                                    'Next
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


            If pexportar Then
                hacer_exportar(_ptipo_exportar, False, _pmostrar_archivo)
                'Si se desea exportar el archivo
                ' Obtenemos el nombre del archivo
                ''Sfd.Filter = "xls|*.xls"
                ''Sfd.ShowDialog()

                ''exportOpts = CrRp.ExportOptions

                ''exportOpts.FormatType = CRExportFormatType.crEFTExcel80
                ''exportOpts.ExcelAreaType = CRAreaKind.crDetail
                ''exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile

                'Exportamos el reporte
                ''If Sfd.FileName.Length > 0 Then
                ''    exportOpts.DiskFileName = Sfd.FileName
                ''    CrRp.Export(False)
                ''    MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ''End If
            Else
                If imprimir Then
                    CrRp.PrintOut(False, pnNumeroCopias)
                    'Dim oautrep As New automatizacionReportes.automatizacionReportes
                    'oautrep.cargarReporteSinMostrar(CrRp, "", "")
                    'oautrep = Nothing
                    'CrRp = Nothing
                    'CrAp = Nothing
                    Dim oform As New frm_craxdrt_viewer_aut
                    oform.CrRpV = CrRp

                    'oform.AxCRV.ReportSource = CrRp2
                    oform.CrRpV = Nothing
                    oform.Dispose()
                    oform = Nothing
                    

                Else

                    'Dim OautRep As New automatizacionReportes.automatizacionReportes
                    'OautRep.mostrarReporte(CrRp, "P", "")
                    'OautRep = Nothing

                    Dim oform As New frm_craxdrt_viewer_aut
                    oform.CrRpV = CrRp

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
                End If
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


    Public Sub _reporte_generico_multipleCarga(ByVal path_reporte As String, _
                            ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String)

        CrAp = New CRAXDRT.Application
        CrRp = New CRAXDRT.Report
        Dim cadena(3) As String
        Dim i_aux As Integer

        Try

            ''cargo el reporte
            CrRp = CrAp.OpenReport(path_reporte)

            CrRp.DiscardSavedData()

            ''Aplico Seguridad 
            cadena(0) = _pServidor
            cadena(1) = _pBase_datos
            cadena(2) = _pUsuario
            cadena(3) = _ppwd

            For i_aux = 1 To CrRp.Database.Tables.Count()
                CrRp.Database.Tables(i_aux).SetLogOnInfo(cadena(0), cadena(1), cadena(2), cadena(3))
            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _reporte_generico_multiple(ByVal pm_parametros As Array, ByVal pm_valores As Array, _
  ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String, ByVal _pmostrar_archivo As Boolean)

        '   Dim Sfd = New System.Windows.Forms.SaveFileDialog
        Descripcion_Error = String.Empty
        Dim paradef As CRAXDRT.ParameterFieldDefinition


        Dim ls_valores(2) As String
        Dim i_aux, i_count2 As Integer


        Try






            'Recorro los parametros
            For Each paradef In CrRp.ParameterFields
                Try
                    For i_aux = 0 To pm_parametros.Length - 1
                        Try
                            If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
                                If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                    If paradef.EnableMultipleValues Then
                                        ''Revisar los valores que llevo en el arreglo
                                        paradef.ClearCurrentValueAndRange()
                                        ReDim ls_valores(100)
                                        ls_valores = pm_valores(i_aux).ToString.Split(",")
                                        ''imultiple = paradef.NumberOfCurrentValues
                                        ''imultiple = IIf(imultiple < 1, 120, imultiple)
                                        Try ''por si al llegar a un valor i_count2 no tiene datos debe quedarse con los que lleva
                                            '    '-1
                                            For i_count2 = 0 To ls_valores.Length - 1
                                                'ls_valor = pm_parametros(i_count, i_count2)
                                                If ls_valores(i_count2).Length > 0 Then
                                                    paradef.AddCurrentValue(ls_valores(i_count2))
                                                    'paradef.AddDefaultValue(pm_parametros(i_count, i_count2))
                                                End If
                                            Next
                                        Catch ex As Exception
                                        End Try
                                    Else
                                        Select Case paradef.ValueType
                                            Case CRFieldValueType.crNumberField
                                                paradef.AddCurrentValue(Double.Parse(pm_valores(i_aux)))
                                            Case CRFieldValueType.crDateField
                                                paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
                                            Case CRFieldValueType.crStringField
                                                paradef.AddCurrentValue(pm_valores(i_aux))
                                            Case CRFieldValueType.crDateTimeField
                                                paradef.AddCurrentValue(System.DateTime.Parse(pm_valores(i_aux)))
                                        End Select
                                    End If
                                End If

                                'Lista de valores

                            Else
                                If pm_parametros(i_aux).ToString.ToUpper.Trim = paradef.ParameterFieldName.ToUpper.Trim Then
                                    paradef.ClearCurrentValueAndRange()
                                    'imultiple = paradef.NumberOfCurrentValues()
                                    'imultiple = IIf(imultiple < 1, 15, imultiple)
                                    'For i_count2 = 1 To imultiple - 1
                                    'ls_valor = pm_parametros(i_count, i_count2)
                                    'If ls_valor.Trim.Length > 0 Then
                                    ls_valores = pm_valores(i_aux).Split(",")
                                    paradef.AddCurrentRange(ls_valores(0), ls_valores(1), 3)
                                    'End If
                                    'Next
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


            If pexportar Then
                hacer_exportar(_ptipo_exportar, False, _pmostrar_archivo)
                'Si se desea exportar el archivo
                ' Obtenemos el nombre del archivo
                ''Sfd.Filter = "xls|*.xls"
                ''Sfd.ShowDialog()

                ''exportOpts = CrRp.ExportOptions

                ''exportOpts.FormatType = CRExportFormatType.crEFTExcel80
                ''exportOpts.ExcelAreaType = CRAreaKind.crDetail
                ''exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile

                'Exportamos el reporte
                ''If Sfd.FileName.Length > 0 Then
                ''    exportOpts.DiskFileName = Sfd.FileName
                ''    CrRp.Export(False)
                ''    MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ''End If
            Else
                If imprimir Then
                    CrRp.PrintOut(False)
                    'Dim oautrep As New automatizacionReportes.automatizacionReportes
                    'oautrep.cargarReporteSinMostrar(CrRp, "", "")
                    'oautrep = Nothing
                    'CrRp = Nothing
                    'CrAp = Nothing
                    Dim oform As New frm_craxdrt_viewer_aut
                    oform.CrRpV = CrRp

                    oform.AxCRV.ReportSource = CrRp
                    oform.CrRpV = Nothing
                    oform.Dispose()
                    oform = Nothing

                Else

                    'Dim OautRep As New automatizacionReportes.automatizacionReportes
                    'OautRep.mostrarReporte(CrRp, "P", "")
                    'OautRep = Nothing

                    Dim oform As New frm_craxdrt_viewer_aut
                    oform.CrRpV = CrRp

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
                End If
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

    Sub hacer_exportar(ByVal tipo_exportar As String, ByVal preguntar_tipo As Boolean, ByVal pmostrar_archivo As Boolean)

        If tipo_exportar.Length > 0 Then
            ' Obtenemos el nombre del archivo
            Dim exportOpts As CRAXDRT.ExportOptions
            Dim Sfd = New System.Windows.Forms.SaveFileDialog
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
                    Sfd.Filter = "xls|*.xls"

                ElseIf tipo_reporte.ToUpper = "PDF" Then
                    Sfd.Filter = "pdf|*.pdf"
                End If

                Sfd.ShowDialog()
                Archivo_Generado = Sfd.filename

            End If

            exportOpts = CrRp.ExportOptions

            If tipo_reporte.ToUpper = "EXCEL" Then

                exportOpts.FormatType = CRExportFormatType.crEFTExcel70
                exportOpts.ExcelUseTabularFormat = True
                'exportOpts.ExcelMaintainColumnAlignment = True

                '' exportOpts.FormatType = CRExportFormatType.crEFTExcelDataOnly
                'exportOpts.ExcelMaintainColumnAlignment = True
                '' exportOpts.ExcelMaintainRelativeObjectPosition = True
                'exportOpts.
                '  exportOpts.FormatType = CRExportFormatType.crEFTExcel50Tabular
                'exportOpts.ExcelMaintainColumnAlignment = True
                'exportOpts.ExcelUseTabularFormat = True
            End If

            If tipo_reporte.ToUpper = "PDF" Then
                exportOpts.FormatType = CRExportFormatType.crEFTPortableDocFormat
            End If
            exportOpts.ExcelAreaType = CRAreaKind.crDetail
            exportOpts.DestinationType = CRExportDestinationType.crEDTDiskFile
            'Exportamos el reporte
            If Archivo_Generado.Length > 0 Then
                exportOpts.DiskFileName = Archivo_Generado
                CrRp.Export(False)
                '       MessageBox.Show("Se Ha Exportado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            Sfd = Nothing
        Else
            '            MessageBox.Show("Este Reporte No se Puede Exportar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        If pmostrar_archivo Then
            Dim proceso As Process = New Process
            Process.Start(Archivo_Generado)
            proceso = Nothing
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
        Dim paradef As CRAXDRT.ParameterFieldDefinition

        Dim i_count, i_aux, i_count2 As Integer
        Dim itemnum, imultiple As Integer
        Dim ls_valor As String
        Dim valor_retorno As String = String.Empty
        Dim la_valores(100) As String

        icount = -1
        Try

            For Each paradef In CrRp.ParameterFields
                icount = icount + 1
                If paradef.NeedsCurrentValue Then

                    If nombre_parametro.ToLower.Trim <> paradef.ParameterFieldName.ToLower.Trim Then
                        'Exit For
                    Else
                        If paradef.DiscreteOrRangeKind = CRDiscreteOrRangeKind.crDiscreteValue Then
                            'If paradef.ParameterFieldName.ToUpper.Trim = "EMPRESA" Then
                            If paradef.ParameterFieldName.ToUpper.IndexOf("MPRESA") > 0 Then

                                'paradef.AddCurrentValue(ps_empresa)
                                valor_retorno = psempresa
                                Exit Try
                            ElseIf paradef.ParameterFieldName.ToUpper.IndexOf("USER_NAME") > 0 Then
                                paradef.AddCurrentValue(psUsuario)
                                Exit Try
                            Else
                                For i_aux = 0 To opanel.Controls.Count - 1
                                    If opanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                        itemnum = i_aux
                                        Exit For
                                    End If
                                Next
                                If paradef.EnableMultipleValues Then
                                    ' paradef.ClearCurrentValueAndRange()
                                    imultiple = paradef.NumberOfCurrentValues
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
                                        Case CRFieldValueType.crNumberField
                                            'paradef.AddCurrentValue(Double.Parse(pm_parametros(i_count, 1)))
                                        Case CRFieldValueType.crDateField
                                            'paradef.AddCurrentValue(System.DateTime.Parse(pm_parametros(i_count, 1)))
                                        Case CRFieldValueType.crStringField
                                            'paradef.AddCurrentValue(pm_parametros(i_count, 1))
                                        Case CRFieldValueType.crDateTimeField
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
                            If paradef.EnableMultipleValues = False Then
                                'paradef.ClearCurrentValueAndRange()
                                Select Case paradef.ValueType
                                    Case CRFieldValueType.crNumberField
                                        'paradef.AddCurrentRange(Double.Parse(pm_parametros(i_count, 1)), Double.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    Case CRFieldValueType.crDateField
                                        'paradef.AddCurrentRange(System.DateTime.Parse(pm_parametros(i_count, 1)), System.DateTime.Parse(pm_parametros(i_count + 25, 1)), 3)
                                    Case CRFieldValueType.crStringField
                                        'paradef.AddCurrentRange(pm_parametros(i_count, 1), pm_parametros(i_count + 25, 1), 3)
                                End Select
                            Else
                                paradef.ClearCurrentValueAndRange()
                                imultiple = paradef.NumberOfCurrentValues()
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

        Dim ClsGen As New ClasesGenerales.General
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

    Public Sub Enviar_Eface(ByVal _tipodocumento As String, ByVal _numerodocumento As String, ByVal _archivo As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lexito As Boolean
        'Dim _archivo As String = "c:\temp\" & "eface.txt"
        Dim linea, ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux, dr_p As DataRow
        Dim liunidades As Integer
        Dim ldpreciounitario, ldmonto, ldvolumen, ldiva, ldpreciosugerido, ldimpuestodistribucion, ldporcimpuestodistribucion As Double
        Dim ldtotallineas, ldtotaldescuentos, ldtotalsindescuentos, ldtotalimpuestos, ldtotalfactura, ldtotalimpuestodistribucion, ldtotaliva As Double
        Dim ldmontoimpuesto As Double

        Generar_Data(_tipodocumento, _numerodocumento)

        '_archivo = "\\manager\prnport\"
        _archivo = "c:\temp\"
        If _tipodocumento.ToLower.StartsWith("factura") Then
            _archivo += "FACE"
        ElseIf _tipodocumento.ToLower.IndexOf("credito") >= 0 Then
            _archivo += "NCE"
        ElseIf _tipodocumento.ToLower.IndexOf("debito") >= 0 Then
            _archivo += "NDE"
        End If
        _archivo += "_npg_" & psempresa.ToLower & _numerodocumento & Now.ToString("hhmmss")
        _archivo += ".txt"


        Try
            Otrans.open()
            ls_sql = "pa_sel_um_tipodocumento '" & psempresa & "',NULL,'" & _tipodocumento & "'"
            dt = Otrans.Obtiene(ls_sql)

            linea = "</ INICIO >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ DATOS CFD ********************************************************************** >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "No Autorización                : 12345"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Fecha Autorización             : 20/10/2008"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Tipo                           : "
            If _tipodocumento.ToLower.StartsWith("factura") Then
                linea += "FACE"
            ElseIf _tipodocumento.ToLower.IndexOf("credito") >= 0 Then
                linea += "NCE"
            ElseIf _tipodocumento.ToLower.IndexOf("debito") >= 0 Then
                linea += "NDE"
            End If
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Serie                          : " & dt.Rows(0).Item("SerieDocto").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Folio                          : " & _numerodocumento
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Estado                         : " 'ORIGINAL" ''Debo Cambiarlo
            If Ods.Tables("encabezado_documento").Rows(0).Item("vigencia").ToString.ToLower = "a" Then
                linea += "ANULADO"
            Else
                linea += "ORIGINAL" '(c) instrucciones correo alfredo 04/05
            End If
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Numero de Factura              : " & _numerodocumento
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Fecha Factura                  : " & Ods.Tables("encabezado_documento").Rows(0).Item("fecha").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ DATOS FISCALES EMISOR ********************************************************** >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

            ls_sql = "pa_var_um_per_empresa '" & psempresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dr = dt.Rows(0)

            linea = "Razon Social                   : " & dr.Item("razon_social").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "NIT                            : " & dr.Item("Rut").ToString.Replace("-", "")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "GLN Emisor                     : N/A"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Pais                           : GT"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Municipio                      : GT"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Lenguaje                       : ES"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Departamento                   : GT"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Calle                          : " & dr.Item("direccion").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ DATOS FISCALES RECEPTOR ******************************************************** >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

            dr = Ods.Tables("encabezado_documento").Rows(0)
            dr_aux = Ods.Tables("documento").Rows(0)
            dr_p = Ods.Tables("documentop").Rows(0)

            ls_sql = "pa_sel_um_ctacte '" & psempresa & "','CLIENTE','" & dr.Item("cliente").ToString & "'"
            dt = Otrans.Obtiene(ls_sql)
            dr = dt.Rows(0)
            linea = "Razon Social                   : " & dr.Item("razonsocial").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "NIT                            : " & dr.Item("CodLegal").ToString.ToString.Replace("-", "")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "GLN Receptor                   : N/A" '& "Analisis del Cliente"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Pais                           : " & "GT" 'dr.Item("pais").ToString (c) se debe parametrizar
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Municipio                      : " & dr.Item("comuna").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Lenguaje                       : ES"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Departamento                   : " & dr.Item("estado").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Direccion                      : " & dr.Item("direccion").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Bodega                         : " & dr_aux.Item("Bodega").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Condiciones                    : " & dr_p.Item("CodigoPago").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Numero Pedido                  : " & Ods.Tables("detalle_documento").Rows(0).Item("numero_origen").ToString  ' & dr.Item("direccion").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Vendedor                       : " & dr_aux.Item("Vendedor").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Fecha Vencimiento              : " & dr_p.Item("FechaVcto").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

            Dim scomentario As String
            scomentario = dr_aux.Item("Comentario1").ToString.Replace(System.Environment.NewLine, " ")
            ''scomentario = scomentario.Replace(System.Environment.NewLine, "")

            linea = "Comentarios                    : " & scomentario
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

            ls_sql = "pa_var_numeros_letras " & Ods.Tables("detalle_documento").Rows(0).Item("total_docto").ToString & ",'Quetzales'"
            dt = Otrans.Obtiene(ls_sql)

            linea = "Total Letras                   : " & dt.Rows(0).Item("monto").ToString
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ DETALLES *********************************************************************** >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "CODIGO                    DESCRIPCIÓN PRODUCTO                                        U. MEDIDA        CANTIDAD         MEDIDA     PRECIO UNITARIO        MONTO             FECHA ENTREGA         TIPO IMPUESTO   MONTO APLICAR IMP    MONTO IMPUESTO    PORCENTAJE IMPUESTO    PRECIO SUGERIDO  IMPUESTO DISTRIBUCION"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

            ls_sql = "pa_sel_um_gen_tabcod '01','CONFIG.IMPUESTO','" & psempresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dr_aux = dt.Rows(0)
            ldiva = dr_aux.Item("valor1")
            ldtotallineas = 0
            ldtotaldescuentos = 0
            ldtotalsindescuentos = 0
            ldtotalimpuestos = 0
            ldtotalimpuestodistribucion = 0
            ldtotaliva = 0

            For Each dr In Ods.Tables("detalle_documento").Rows

                liunidades = dr.Item("_unidades")
                ldpreciounitario = dr.Item("precio")
                ldmonto = dr.Item("total") + dr.Item("impuesto")
                ldvolumen = dr.Item("volumen")
                Try
                    ldimpuestodistribucion = dr.Item("impdist").ToString
                Catch ex As Exception
                    ldimpuestodistribucion = 0
                End Try
                ldtotalfactura = dr.Item("total_docto")


                ls_sql = "pa_sel_um_gen_tabcod '" & dr.Item("tipoproducto") & "','imp_distrib','" & psempresa & "'"
                dt = Otrans.Obtiene(ls_sql)


                Try
                    ldporcimpuestodistribucion = dt.Rows(0).Item("valor1")
                Catch ex As Exception
                    ldporcimpuestodistribucion = 0
                End Try


                ldpreciosugerido = dr.Item("precioventa") * (1 + ldporcimpuestodistribucion) * (1 + (ldiva / 100))
                ldtotallineas += (dr.Item("_unidades") * dr.Item("precio")) / (1 + (ldiva / 100))
                ldtotaldescuentos += (dr.Item("_unidades") * dr.Item("precio") * dr.Item("PorcentajeDR")) / 100 / (1 + (ldiva / 100))
                ldtotalimpuestos += dr.Item("impuesto")
                ldtotalimpuestodistribucion += ldimpuestodistribucion

                ldmontoimpuesto = dr.Item("impuesto")
                ldtotaliva += ldmontoimpuesto

                linea = ""
                linea += dr.Item("producto").ToString.PadRight(20, " ") & _
                        dr.Item("glosa").ToString.PadRight(70, " ") & _
                        dr.Item("unidad").ToString.PadRight(15, " ") & _
                        liunidades.ToString("G").PadRight(15, " ") & _
                        ldvolumen.ToString("G5").PadRight(5, "0") & _
                        Space(10) & _
                        ldpreciounitario.ToString("F6").PadRight(20, " ") & _
                        ldmonto.ToString("F6").PadRight(18, " ") & _
                        dr.Item("fecha").ToString.PadRight(24, " ") & _
                        "IVA".ToString.PadRight(18, " ") & _
                        "100".ToString.PadRight(21, " ") & _
                        ldmontoimpuesto.ToString("F6").PadRight(18, " ") & _
                        ldiva.ToString("F6").PadRight(18, " ") & _
                        ldpreciosugerido.ToString("F6").PadRight(23, " ") & _
                       ldimpuestodistribucion.ToString("F6").PadRight(20, " ")

                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            Next
            linea = ""
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "< FIN DETALLE />"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ TOTALES ************************************************************************ >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Total Lineas                   : " & ldtotallineas.ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Total Descuentos               : " & ldtotaldescuentos.ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Total Sin Impuestos            : " & (ldtotalfactura / (1 + (ldiva / 100))).ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Total Impuestos                : " & ldtotalimpuestos.ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Total Impuestos                : " & ldtotalimpuestos.ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Valor Pagar                    : " & ldtotalfactura.ToString("F6").PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Moneda                         : " & "GTQ".PadLeft(20, " ")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ IMPUESTOS ********************************************************************** >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "               TIPO    PORCENTAJE        MONTO"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Impuesto1       IVA        " & ldiva.ToString("F0").PadRight(10, " ") & ldtotaliva.ToString("F6")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "Impuesto2       IMPDIST    " & Space(10) & ldtotalimpuestodistribucion.ToString("F6")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            linea = "</ FIN DOCUMENTO >"
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            '  ClsGen.Copiar_Archivo(_archivo, _archivo.Replace(".tmp", ".txt"), True)
            '   ClsGen.copiar_archivo(_archivo, _archivo.Replace("c:\temp\", "\\manager\prnport\"))
            'ClsGen.Eliminar_Archivo_Texto(_archivo)
        Catch ex As Exception


        Finally

            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub


End Class

#End Region

