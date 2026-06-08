Imports System.Data
Imports Microsoft.Office.Interop



Public Class Frm_Evaluacion
    Inherits System.Windows.Forms.Form
    Dim Ods As New DataSet
    Dim dtComparacion As DataTable
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Dim Oaut As New Automatizar.Propiedades_Excel
    Dim entrodt As Boolean = False







    Private Sub Enviar_Excel_Ingresar_Punteo()
        Dim encontrado As Boolean = False
        Dim mExcel As New Excel.Application
        Dim libro As Excel.Workbook
        Dim hoja2 As Excel.Worksheet
        Dim hoja As Excel.Worksheet
        Dim hoja3 As Excel.Worksheet
        Dim hoja4 As Excel.Worksheet

        Dim graficaline As Excel.Chart
        Dim graficaarea As Excel.Chart
        Dim graficapie As Excel.Chart

        Dim formatt As Excel.FormatCondition


        Dim drv As DataRowView
        Dim dr As DataRow
        Dim sserie As Excel.SeriesCollection
        Dim scolection As Excel.SeriesCollection
        Dim scolection2 As Excel.SeriesCollection
        Dim scolection3 As Excel.SeriesCollection
        Dim scolection4 As Excel.SeriesCollection
        Dim myrange As String
        Dim icount, nrow As Integer
        Dim clsgen As New ClasesGenerales.General



        Try

            If Ods.Tables("Resultado").Rows.Count > 0 Then
                libro = mExcel.Workbooks.Add
                hoja4 = libro.Sheets.Add
                hoja3 = libro.Sheets.Add
                hoja2 = libro.Sheets.Add
                hoja = libro.Sheets.Add
                Oaut._xlInicializar_Hoja(hoja4, "AUTOEVALUACIÓN")
                Oaut._xlInicializar_Hoja(hoja3, "ANALISIS COMP")
                Oaut._xlInicializar_Hoja(hoja2, "RESULTADOS GLOBALES")
                Oaut._xlInicializar_Hoja(hoja, "INGRESAR PUNTEO")






                '  hoja.Columns("Y:Y").numberformat = "@"
                ' mExcel.Visible = True
                nrow = 9

                hoja.Cells(nrow, 2) = "CÓDIGO"
                hoja.Cells(nrow, 3) = "NOMBRE"
                hoja.Cells(nrow, 4) = "PUESTO"
                hoja.Cells(nrow, 5) = "HONESTIDAD"
                hoja.Cells(nrow, 6) = "PERSEVERANCIA"
                hoja.Cells(nrow, 7) = "ACTITUD HACIA SU TRABAJO"
                hoja.Cells(nrow, 8) = "LIDERAZGO"
                hoja.Cells(nrow, 9) = "RESPONSABILIDAD"
                hoja.Cells(nrow, 10) = "INICIATIVA"
                hoja.Cells(nrow, 11) = "CUMPLIMIENTO DE METAS"
                hoja.Cells(nrow, 12) = "PLANIFICACION Y ORG."
                hoja.Cells(nrow, 13) = "IDENTIFICACION CON LA EMPRESA"
                hoja.Cells(nrow, 14) = "TRABAJO EN EQUIPO"
                hoja.Cells(nrow, 15) = "COMUNICACIÓN"
                hoja.Cells(nrow, 16) = "MODALIDAD DE CONTACTO"
                hoja.Cells(nrow, 17) = "RELACION INTERPERSONALES"
                hoja.Cells(nrow, 18) = "ACTITUD DE SERVICIO"
                hoja.Cells(nrow, 19) = "RESPETO"
                hoja.Cells(nrow, 20) = "DM"
                hoja.Cells(nrow, 21) = "R"
                hoja.Cells(nrow, 22) = "B"
                hoja.Cells(nrow, 23) = "MB"
                hoja.Cells(nrow, 24) = "SS"
                hoja.Cells(nrow, 25) = "PONDERACIÓN"

                hoja.Cells(nrow, 26) = "5.99"
                hoja.Cells(nrow, 27) = "6.99-6.00"
                hoja.Cells(nrow, 28) = "7.39-7.00"
                hoja.Cells(nrow, 29) = "7.59-7.40"
                hoja.Cells(nrow, 30) = "7.99 a 7.6"
                hoja.Cells(nrow, 31) = "8.99 a 8"
                hoja.Cells(nrow, 32) = "10 a 9"

                hoja.Cells(8, 26) = "DM"
                hoja.Cells(8, 27) = "R"
                hoja.Cells(8, 28) = "B-"
                hoja.Cells(8, 29) = "B"
                hoja.Cells(8, 30) = "B+"
                hoja.Cells(8, 31) = "MB"
                hoja.Cells(8, 32) = "S"

                icount = 0
                Ods.Tables("Resultado").DefaultView.RowFilter = ""

                Dim dtdistintos, datos As DataTable
                Dim dm, r, b, mb, ss As Integer
                dm = 0
                r = 0
                b = 0
                b = 0
                mb = 0
                ss = 0
                Dim total_items As Integer = 0
                Dim ponderacion As Double = 0


                dtdistintos = clsgen.ValoresDistinto(Ods.Tables("Resultado"), "cod_resultado".Split(","))
                For Each drr As DataRow In dtdistintos.Rows
                    Ods.Tables("Resultado").DefaultView.RowFilter = " cod_resultado=" & drr("cod_resultado")
                    datos = Ods.Tables("Resultado").DefaultView.ToTable
                    nrow += 1
                    icount += 1
                    hoja.Cells(nrow, 2) = icount
                    hoja.Cells(nrow, 3) = datos.Rows(0).Item("usuario_evaluar")
                    hoja.Cells(nrow, 4) = datos.Rows(0).Item("puesto")
                    hoja.Cells(nrow, 5) = datos.Rows(0).Item("cod_alternativa")
                    hoja.Cells(nrow, 6) = datos.Rows(1).Item("cod_alternativa")
                    hoja.Cells(nrow, 7) = datos.Rows(2).Item("cod_alternativa")
                    hoja.Cells(nrow, 8) = datos.Rows(3).Item("cod_alternativa")
                    hoja.Cells(nrow, 9) = datos.Rows(4).Item("cod_alternativa")
                    hoja.Cells(nrow, 10) = datos.Rows(5).Item("cod_alternativa")
                    hoja.Cells(nrow, 11) = datos.Rows(6).Item("cod_alternativa")
                    hoja.Cells(nrow, 12) = datos.Rows(7).Item("cod_alternativa")
                    hoja.Cells(nrow, 13) = datos.Rows(8).Item("cod_alternativa")
                    hoja.Cells(nrow, 14) = datos.Rows(9).Item("cod_alternativa")
                    hoja.Cells(nrow, 15) = datos.Rows(10).Item("cod_alternativa")
                    hoja.Cells(nrow, 16) = datos.Rows(11).Item("cod_alternativa")
                    hoja.Cells(nrow, 17) = datos.Rows(12).Item("cod_alternativa")
                    hoja.Cells(nrow, 18) = datos.Rows(13).Item("cod_alternativa")
                    hoja.Cells(nrow, 19) = datos.Rows(14).Item("cod_alternativa")




                    Try
                        For i As Integer = 0 To 14
                            If datos.Rows(i).Item("cod_alternativa") = 2 Then
                                dm += 1
                            End If

                            If datos.Rows(i).Item("cod_alternativa") = 4 Then
                                r += 1
                            End If
                            If datos.Rows(i).Item("cod_alternativa") = 6 Then
                                b += 1
                            End If
                            If datos.Rows(i).Item("cod_alternativa") = 8 Then
                                mb += 1
                            End If

                            If datos.Rows(i).Item("cod_alternativa") = 10 Then
                                ss += 1
                            End If

                        Next
                    Catch ex As Exception

                    End Try

                    total_items += dm + r + b + mb + ss
                    hoja.Cells(nrow, 20) = dm
                    hoja.Cells(nrow, 21) = r
                    hoja.Cells(nrow, 22) = b
                    hoja.Cells(nrow, 23) = mb
                    hoja.Cells(nrow, 24) = ss

                    If total_items > 0 Then
                        ponderacion = (dm * 2 + r * 4 + b * 6 + mb * 8 + ss * 10) / total_items
                    Else
                        ponderacion = 0
                    End If

                    hoja.Cells(nrow, 25) = Math.Round(ponderacion, 2)
                    hoja.Cells(8, 26) = "DM"
                    hoja.Cells(8, 27) = "R"
                    hoja.Cells(8, 28) = "B-"
                    hoja.Cells(8, 29) = "B"
                    hoja.Cells(8, 30) = "B+"
                    hoja.Cells(8, 31) = "MB"
                    hoja.Cells(8, 32) = "S"
                    hoja.Cells(9, 33) = "CLASIFICACIÓN"


                    If ponderacion > 0 And ponderacion <= 5.99 Then

                        hoja.Cells(nrow, 26) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = ""
                    End If

                    If ponderacion >= 6 And ponderacion < 7 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = ""
                    End If

                    If ponderacion >= 7 And ponderacion < 7.4 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = ""
                    End If

                    If ponderacion >= 7.4 And ponderacion < 7.6 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = ""
                    End If

                    If ponderacion >= 7.6 And ponderacion < 8 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = ""
                    End If

                    If ponderacion >= 8 And ponderacion < 9 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 32) = ""
                    End If


                    If ponderacion >= 9 And ponderacion < 10 Then

                        hoja.Cells(nrow, 26) = ""
                        hoja.Cells(nrow, 27) = ""
                        hoja.Cells(nrow, 28) = ""
                        hoja.Cells(nrow, 29) = ""
                        hoja.Cells(nrow, 30) = ""
                        hoja.Cells(nrow, 31) = ""
                        hoja.Cells(nrow, 32) = Math.Round(ponderacion, 2)
                    End If

                    dm = 0
                    r = 0
                    b = 0
                    mb = 0
                    ss = 0
                    total_items = 0

                    If ponderacion >= 9 Then
                        hoja.Cells(nrow, 33) = "S"

                    ElseIf ponderacion >= 8 Then
                        hoja.Cells(nrow, 33) = "MB"

                    ElseIf ponderacion >= 7.6 Then
                        hoja.Cells(nrow, 33) = "B+"

                    ElseIf ponderacion >= 7.4 Then
                        hoja.Cells(nrow, 33) = "B"

                    ElseIf ponderacion >= 7 Then
                        hoja.Cells(nrow, 33) = "B-"

                    ElseIf ponderacion >= 6 Then
                        hoja.Cells(nrow, 33) = "R"

                    ElseIf ponderacion > 0 Then
                        hoja.Cells(nrow, 33) = "DM"
                    End If

                    Ods.Tables("Resultado").DefaultView.RowFilter = ""


                Next

                Oaut._xlDibujar_Bordes(hoja, "B9:AG" & (nrow).ToString)
                ' hoja.Cells(nrow + 1, 2) = "Totales"
                myrange = "B9:D9"
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False

                hoja.Range("B:B").ColumnWidth = 10
                hoja.Range("C:C").ColumnWidth = 30
                hoja.Range("D:D").ColumnWidth = 30
                hoja.Range(myrange).Font.ColorIndex = 2
                hoja.Range(myrange).Font.Bold = True



                myrange = "B:B"
                'hoja.Range(myrange).Interior.ColorIndex = 49
                'hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False


                myrange = "E5:E9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("E:E").ColumnWidth = 7.86


                myrange = "F5:F9"
                ' hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("F:F").ColumnWidth = 7.86


                myrange = "G5:G9"
                ' hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("G:G").ColumnWidth = 7.86

                myrange = "H5:H9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("H:H").ColumnWidth = 7.86


                myrange = "I5:I9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("I:I").ColumnWidth = 7.86


                myrange = "J5:J9"
                ' hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("J:J").ColumnWidth = 7.86

                myrange = "K5:K9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("K:K").ColumnWidth = 7.86

                myrange = "L5:L9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("L:L").ColumnWidth = 7.86


                myrange = "L5:L9"
                '  hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("L:L").ColumnWidth = 7.86




                myrange = "M5:M9"
                '  hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("M:M").ColumnWidth = 7.86

                myrange = "N5:N9"
                '  hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("N:N").ColumnWidth = 7.86

                myrange = "O5:O9"
                ' hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("O:O").ColumnWidth = 7.86

                myrange = "P5:P9"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("P:P").ColumnWidth = 7.86


                myrange = "Q5:Q9"
                ' hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("Q:Q").ColumnWidth = 7.86


                myrange = "R5:R9"
                '  hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("R:R").ColumnWidth = 7.86
                myrange = "S5:S9"
                '  hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 90
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Size = 7
                hoja.Range("S:S").ColumnWidth = 7.86


                myrange = "T:T"
                '  hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("T:T").ColumnWidth = 10


                myrange = "T9:Y9"
                hoja.Range(myrange).Font.Bold = True

                myrange = "U:U"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("U:U").ColumnWidth = 10



                myrange = "V:V"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("V:V").ColumnWidth = 10


                myrange = "W:W"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("W:W").ColumnWidth = 10

                myrange = "X:X"
                '  hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("X:X").ColumnWidth = 10
                myrange = "Y:Y"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range("Y:Y").ColumnWidth = 20


                myrange = "Z:Z"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("Z:Z").ColumnWidth = 10
                myrange = "Z8:AF8"
                hoja.Range(myrange).Font.Bold = True


                myrange = "AA:AA"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AA:AA").ColumnWidth = 10

                myrange = "AB:AB"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AB:AB").ColumnWidth = 10



                myrange = "AC:AC"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AC:AC").ColumnWidth = 10




                myrange = "AD:AD"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AD:AD").ColumnWidth = 10




                myrange = "AE:AE"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AE:AE").ColumnWidth = 10


                myrange = "AF:AF"
                ' hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AF:AF").ColumnWidth = 15


                myrange = "AG:AG"
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range("AG:AG").ColumnWidth = 15


                myrange = "AG9:AG9"
                hoja.Range(myrange).Font.Bold = True


                Oaut._xlDibujar_Bordes(hoja, "E5:S5")
                Oaut._xlDibujar_Bordes(hoja, "E6:S5")
                Oaut._xlDibujar_Bordes(hoja, "E7:S5")
                Oaut._xlDibujar_Bordes(hoja, "E8:S5")
                Oaut._xlDibujar_Bordes(hoja, "E9:S5")

                Oaut._xlDibujar_Bordes(hoja, "Z8:AF8")
                Oaut._xlDibujar_Bordes(hoja, "Z9:AG9")
                Oaut._xlDibujar_Bordes(hoja, "Z10:AG10")
                Oaut._xlDibujar_Bordes(hoja, "Z11:AG11")
                Oaut._xlDibujar_Bordes(hoja, "Z12:AG12")
                Oaut._xlDibujar_Bordes(hoja, "Z13:AG13")
                Oaut._xlDibujar_Bordes(hoja, "Z14:AG14")
                Oaut._xlDibujar_Bordes(hoja, "Z15:AG15")


                myrange = "B" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 12 & ": AG" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 13
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.Size = 12
                hoja.Range(myrange).Font.ColorIndex = 2
                hoja.Range(myrange).Font.Bold = True
                'hoja.Range("E:E").ColumnWidth = 7.86
                hoja.Cells(Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 12, 2) = "REPORTE 1- CALIFICACIÓN DE EMPLEADOS"


                myrange = "(B" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":D" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ")"
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False

                hoja.Range("B:B").ColumnWidth = 10
                hoja.Range("C:C").ColumnWidth = 30
                hoja.Range("D:D").ColumnWidth = 30
                hoja.Range(myrange).Font.ColorIndex = 2
                hoja.Range(myrange).Font.Bold = True


                '''''nueva tabla
                nrow = Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                hoja.Cells(nrow, 2) = "CÓDIGO"
                hoja.Cells(nrow, 3) = "NOMBRE"
                hoja.Cells(nrow, 4) = "PUESTO"
                hoja.Cells(nrow - 1, 5) = "DM"
                hoja.Cells(nrow - 1, 6) = "R"
                hoja.Cells(nrow - 1, 7) = "B-"
                hoja.Cells(nrow - 1, 8) = "B"
                hoja.Cells(nrow - 1, 9) = "B+"
                hoja.Cells(nrow - 1, 10) = "MB"
                hoja.Cells(nrow - 1, 11) = "S"

                hoja.Cells(nrow, 5) = "5.99"
                hoja.Cells(nrow, 6) = "6.99-6.00"
                hoja.Cells(nrow, 7) = "7.39-7.00"
                hoja.Cells(nrow, 8) = "7.59-7.40"
                hoja.Cells(nrow, 9) = "7.99 a 7.6"
                hoja.Cells(nrow, 10) = "8.99 a 8"
                hoja.Cells(nrow, 11) = "10 a 9"
                hoja.Cells(nrow, 12) = "CLASIFICACIÓN"

                ' myrange = "AG9:AG9"
                'hoja.Range(myrange).Font.Bold = True

                dtdistintos = clsgen.ValoresDistinto(Ods.Tables("Resultado"), "cod_resultado".Split(","))
                icount = 0
                Dim Contador_S As Integer = 0
                Dim Contador_BB As Integer = 0
                Dim Contador_BBB As Integer = 0
                Dim Contador_Bp As Integer = 0
                Dim Contador_MB As Integer = 0
                Dim Contador_DM As Integer = 0
                Dim Contador_r As Integer = 0
                Dim promedio As Integer = 0
                Dim promedioneto As Integer = 0
                Dim porc_S As Double = 0
                Dim porc_mb As Double = 0
                Dim porc_tot As Double = 0
                Dim porc_r As Double = 0
                Dim porc_promedio As Double = 0
                Dim porc_dm As Double = 0
                Dim porc_bb As Double = 0
                Dim porc_bbb As Double = 0
                Dim porc_bp As Double = 0


                For Each drr As DataRow In dtdistintos.Rows
                    Ods.Tables("Resultado").DefaultView.RowFilter = " cod_resultado=" & drr("cod_resultado")
                    datos = Ods.Tables("Resultado").DefaultView.ToTable
                    nrow += 1
                    icount += 1
                    hoja.Cells(nrow, 2) = icount
                    hoja.Cells(nrow, 3) = datos.Rows(0).Item("usuario_evaluar")
                    hoja.Cells(nrow, 4) = datos.Rows(0).Item("puesto")

                    Try
                        For i As Integer = 0 To 14
                            If datos.Rows(i).Item("cod_alternativa") = 2 Then
                                dm += 1
                            End If
                            If datos.Rows(i).Item("cod_alternativa") = 4 Then
                                r += 1
                            End If
                            If datos.Rows(i).Item("cod_alternativa") = 6 Then
                                b += 1
                            End If
                            If datos.Rows(i).Item("cod_alternativa") = 8 Then
                                mb += 1
                            End If

                            If datos.Rows(i).Item("cod_alternativa") = 10 Then
                                ss += 1
                            End If

                        Next
                    Catch ex As Exception

                    End Try

                    total_items += dm + r + b + mb + ss

                    If total_items > 0 Then
                        ponderacion = (dm * 2 + r * 4 + b * 6 + mb * 8 + ss * 10) / total_items
                    Else
                        ponderacion = 0
                    End If




                    If ponderacion > 0 And ponderacion <= 5.99 Then

                        hoja.Cells(nrow, 5) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = ""
                    End If

                    If ponderacion >= 6 And ponderacion < 7 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = ""
                    End If

                    If ponderacion >= 7 And ponderacion < 7.4 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = ""
                    End If

                    If ponderacion >= 7.4 And ponderacion < 7.6 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = ""
                    End If

                    If ponderacion >= 7.6 And ponderacion < 8 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = ""
                    End If

                    If ponderacion >= 8 And ponderacion < 9 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = Math.Round(ponderacion, 2)
                        hoja.Cells(nrow, 11) = ""
                    End If


                    If ponderacion >= 9 And ponderacion < 10 Then

                        hoja.Cells(nrow, 5) = ""
                        hoja.Cells(nrow, 6) = ""
                        hoja.Cells(nrow, 7) = ""
                        hoja.Cells(nrow, 8) = ""
                        hoja.Cells(nrow, 9) = ""
                        hoja.Cells(nrow, 10) = ""
                        hoja.Cells(nrow, 11) = Math.Round(ponderacion, 2)
                    End If

                    dm = 0
                    r = 0
                    b = 0
                    mb = 0
                    ss = 0
                    total_items = 0

                    If ponderacion >= 9 Then
                        hoja.Cells(nrow, 12) = "S"
                        Contador_S += 1

                    ElseIf ponderacion >= 8 Then
                        hoja.Cells(nrow, 12) = "MB"
                        Contador_MB += 1
                    ElseIf ponderacion >= 7.6 Then
                        hoja.Cells(nrow, 12) = "B+"
                        Contador_BB += 1

                    ElseIf ponderacion >= 7.4 Then
                        hoja.Cells(nrow, 12) = "B"
                        Contador_BBB += 1

                    ElseIf ponderacion >= 7 Then
                        hoja.Cells(nrow, 12) = "B-"
                        Contador_Bp += 1

                    ElseIf ponderacion >= 6 Then
                        hoja.Cells(nrow, 12) = "R"
                        Contador_r += 1

                    ElseIf ponderacion > 0 Then
                        hoja.Cells(nrow, 12) = "DM"
                        Contador_DM += 1
                    End If

                    Ods.Tables("Resultado").DefaultView.RowFilter = ""


                Next

                '''fin de nueva tabla


                myrange = "E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17 & ":K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10

                myrange = "E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                myrange = "E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17 & ":K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17
                hoja.Range(myrange).Font.Bold = True

                myrange = "F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True


                myrange = "G" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":G" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "G" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":G" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True

                myrange = "H" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":H" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "H" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":H" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True


                myrange = "I" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":I" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "I" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":I" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True


                myrange = "J" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":J" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "J" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":J" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True

                myrange = "K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                'myrange = "K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True


                myrange = "L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 15
                'myrange = "L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                'hoja.Range(myrange).Font.Bold = True

                myrange = "L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18
                hoja.Range(myrange).Font.Bold = True
                Oaut._xlDibujar_Bordes(hoja, "E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17 & ":K" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 17)
                Oaut._xlDibujar_Bordes(hoja, "B" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 & ":L" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 18 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad"))

                ''TABLA NO. 2
                myrange = "B" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 22 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") & ": AG" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 23
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.Size = 12
                hoja.Range(myrange).Font.ColorIndex = 2
                hoja.Range(myrange).Font.Bold = True
                'hoja.Range("E:E").ColumnWidth = 7.86
                hoja.Cells(Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 22, 2) = "REPORTE 2- RESULTADOS POR RANGOS"



                myrange = "C" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") & ": D" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.Size = 12
                hoja.Range(myrange).Font.ColorIndex = 2
                hoja.Range(myrange).Font.Bold = True
                'hoja.Range("E:E").ColumnWidth = 7.86
                hoja.Cells(Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26, 3) = "RANGOS"

                nrow = Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")
                hoja.Cells(nrow, 5) = "#"
                hoja.Cells(nrow, 6) = "%"
                myrange = "E" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26 & ":F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26
                hoja.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).ReadingOrder = Excel.Constants.xlRTL
                hoja.Range(myrange).MergeCells = False
                hoja.Range(myrange).ColumnWidth = 10
                hoja.Range(myrange).Font.ColorIndex = 2

                nrow = Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 26 + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad")

                hoja.Cells(nrow + 1, 3) = "1. SOBRESALIENTE "
                hoja.Cells(nrow + 2, 3) = "2. MUY BUENO"
                hoja.Cells(nrow + 3, 3) = "3. BUENO"
                hoja.Cells(nrow + 4, 3) = "4. REGULAR"
                hoja.Cells(nrow + 5, 3) = "5. DEBE MEJORAR"
                hoja.Cells(nrow + 6, 3) = "TOTAL"
                hoja.Cells(nrow + 7, 3) = "3.1   B+"
                hoja.Cells(nrow + 8, 3) = "3.2   B"
                hoja.Cells(nrow + 9, 3) = "3.3   B-"


                hoja.Cells(nrow + 1, 4) = "10.00-9.00"
                hoja.Cells(nrow + 2, 4) = "8.99-8.00"
                hoja.Cells(nrow + 3, 4) = "7.99-7.00"
                hoja.Cells(nrow + 4, 4) = "6.99-6.00"
                hoja.Cells(nrow + 5, 4) = "5.99"
                hoja.Cells(nrow + 7, 4) = "7.99-7.60"
                hoja.Cells(nrow + 8, 4) = "7.59-7.40"
                hoja.Cells(nrow + 9, 4) = "7.99-7.00"

                promedio = Contador_BBB + Contador_BB + Contador_Bp
                promedioneto = Contador_S + Contador_MB + Contador_BBB + Contador_BB + Contador_Bp + Contador_r + Contador_DM

                hoja.Cells(nrow + 1, 5) = Contador_S
                hoja.Cells(nrow + 2, 5) = Contador_MB
                hoja.Cells(nrow + 3, 5) = promedio
                hoja.Cells(nrow + 4, 5) = Contador_r
                hoja.Cells(nrow + 5, 5) = Contador_DM
                hoja.Cells(nrow + 6, 5) = Contador_S + Contador_MB + Contador_BBB + Contador_BB + Contador_Bp + Contador_r + Contador_DM
                hoja.Cells(nrow + 7, 5) = Contador_BB
                hoja.Cells(nrow + 8, 5) = Contador_BBB
                hoja.Cells(nrow + 9, 5) = Contador_Bp

                porc_S = (Contador_S * 100) / promedioneto
                porc_mb = (Contador_MB * 100) / promedioneto
                porc_promedio = (promedio * 100) / promedioneto
                porc_r = (Contador_r * 100) / promedioneto
                porc_dm = (Contador_DM * 100) / promedioneto
                porc_tot = (Contador_S + Contador_MB + Contador_BBB + Contador_BB + Contador_Bp + Contador_r + Contador_DM)
                porc_tot = (porc_tot * 100) / promedioneto

                porc_bb = (Contador_BB * 100) / promedioneto
                porc_bbb = (Contador_BBB * 100) / promedioneto
                porc_bp = (Contador_Bp * 100) / promedioneto

                hoja.Cells(nrow + 1, 6) = Math.Round(porc_S, 2)
                hoja.Cells(nrow + 2, 6) = Math.Round(porc_mb, 2)
                hoja.Cells(nrow + 3, 6) = Math.Round(porc_promedio, 2)
                hoja.Cells(nrow + 4, 6) = Math.Round(porc_r, 2)
                hoja.Cells(nrow + 5, 6) = Math.Round(porc_dm, 2)
                hoja.Cells(nrow + 6, 6) = Math.Round(porc_tot, 2)
                hoja.Cells(nrow + 7, 6) = Math.Round(porc_bb, 2)
                hoja.Cells(nrow + 8, 6) = Math.Round(porc_bbb, 2)
                hoja.Cells(nrow + 9, 6) = Math.Round(porc_bp, 2)



                myrange = "D" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 27 & ":D" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 35

                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = False
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = False

                'CUADRO DE SEGUNDA HOJA

                nrow = 7


                myrange = "A4:I4"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja2.Range(myrange).Interior.ColorIndex = 49
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = True
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = True
                hoja2.Range(myrange).Font.Size = 12
                hoja2.Range(myrange).Font.ColorIndex = 2
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Cells(4, 1) = "RESULTADOS GLOBALES:"


                myrange = "A4:E4"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja3.Range(myrange).Interior.ColorIndex = 49
                hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).WrapText = True
                hoja3.Range(myrange).Orientation = 0
                hoja3.Range(myrange).AddIndent = False
                hoja3.Range(myrange).IndentLevel = 0
                hoja3.Range(myrange).ShrinkToFit = False
                hoja3.Range(myrange).MergeCells = True
                hoja3.Range(myrange).Font.Size = 12
                hoja3.Range(myrange).Font.ColorIndex = 2
                hoja3.Range(myrange).Font.Bold = True
                hoja3.Cells(4, 1) = "REPORTE 5-PROMEDIO POR COMPETENCIA"
                hoja3.Cells(nrow, 2) = "ANALISIS COMPETENCIAS"
                hoja3.Cells(nrow, 3) = "PROMEDIO"
                hoja3.Cells(nrow, 4) = "CLASIFICACION"
                hoja3.Cells(8, 2) = "HONESTIDAD"
                hoja3.Cells(9, 2) = "PERSEVERANCIA"
                hoja3.Cells(10, 2) = "ACTITUD HACIA SU TRABAJO"
                hoja3.Cells(11, 2) = "LIDERAZGO"
                hoja3.Cells(12, 2) = "RESPONSABILIDAD"
                hoja3.Cells(13, 2) = "INICIATIVA"
                hoja3.Cells(14, 2) = "CUMPLIMIENTO DE METAS"
                hoja3.Cells(15, 2) = "PLANIFICACIÓN Y ORG. "
                hoja3.Cells(16, 2) = "IDENTIF.  EMPRESA"
                hoja3.Cells(17, 2) = "TRABAJO EN EQUIPO"
                hoja3.Cells(18, 2) = "COMUNICACIÓN"
                hoja3.Cells(19, 2) = "MODALIDAD DE CONTACTO"
                hoja3.Cells(20, 2) = "RELACIONES INTERPERSONALES"
                hoja3.Cells(21, 2) = "ACTITUD DE SERVICIO"
                hoja3.Cells(22, 2) = "RESPETO"


                myrange = "B7:B7"
                hoja3.Range(myrange).Interior.ColorIndex = 49
                hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).WrapText = False
                hoja3.Range(myrange).Orientation = 0
                hoja3.Range(myrange).AddIndent = False
                hoja3.Range(myrange).IndentLevel = 0
                hoja3.Range(myrange).ShrinkToFit = False
                hoja3.Range(myrange).MergeCells = False
                hoja3.Range(myrange).Font.Size = 10
                hoja3.Range(myrange).Font.ColorIndex = 2
                hoja3.Range(myrange).Font.Bold = True
                hoja3.Range("B7:B7").ColumnWidth = 60


                myrange = "D7:D7"
                hoja3.Range(myrange).Interior.ColorIndex = 49
                hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).WrapText = False
                hoja3.Range(myrange).Orientation = 0
                hoja3.Range(myrange).AddIndent = False
                hoja3.Range(myrange).IndentLevel = 0
                hoja3.Range(myrange).ShrinkToFit = False
                hoja3.Range(myrange).MergeCells = False
                hoja3.Range(myrange).Font.Size = 10
                hoja3.Range(myrange).Font.ColorIndex = 2
                hoja3.Range(myrange).Font.Bold = True
                hoja3.Range("D7:D7").ColumnWidth = 25

                myrange = "C7:C7"
                hoja3.Range(myrange).Interior.ColorIndex = 49
                hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).WrapText = False
                hoja3.Range(myrange).Orientation = 0
                hoja3.Range(myrange).AddIndent = False
                hoja3.Range(myrange).IndentLevel = 0
                hoja3.Range(myrange).ShrinkToFit = False
                hoja3.Range(myrange).MergeCells = False
                hoja3.Range(myrange).Font.Size = 10
                hoja3.Range(myrange).Font.ColorIndex = 2
                hoja3.Range(myrange).Font.Bold = True
                hoja3.Range("C7:C7").ColumnWidth = 20




                myrange = "C:C"

                ' hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                'hoja3.Range(myrange).WrapText = False
                'hoja3.Range(myrange).Orientation = 0
                'hoja3.Range(myrange).AddIndent = False
                'hoja3.Range(myrange).IndentLevel = 0
                'hoja3.Range(myrange).ShrinkToFit = False
                'hoja3.Range(myrange).MergeCells = False
                'hoja3.Range(myrange).Font.Size = 10
                'hoja3.Range(myrange).Font.ColorIndex = 2
                'hoja3.Range(myrange).Font.Bold = True
                ' hoja3.Range("C8:C8").ColumnWidth = 20


                hoja3.Range("C23").Value = "0"
                hoja3.Range("C8:C23").FormatConditions.AddDatabar()
                hoja3.Range("C23").Font.ColorIndex = 2



                myrange = "A1:H1"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 16
                hoja4.Range(myrange).Font.ColorIndex = 2
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(1, 1) = "REPORTE 6 - EVALUACIÓN Y AUTOEVALUACION (ADMINISTRATIVOS)"

                myrange = "A5:H5"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                ' hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 16
                hoja4.Range(myrange).Font.ColorIndex = 1
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(5, 1) = "RESULTADOS EVALUACION DEL DESEMPEÑO 2,013"




                'myrange = "C5:C5"
                ''hoja2.Range(myrange).Interior.ColorIndex = 49
                'hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                'hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                'hoja2.Range(myrange).WrapText = True
                'hoja2.Range(myrange).Orientation = 0
                'hoja2.Range(myrange).AddIndent = False
                'hoja2.Range(myrange).IndentLevel = 0
                'hoja2.Range(myrange).ShrinkToFit = False
                'hoja2.Range(myrange).MergeCells = True
                'hoja2.Range(myrange).Font.Size = 10
                'hoja2.Range(myrange).Font.ColorIndex = 2
                'hoja2.Range(myrange).Font.Bold = True
                'hoja.Cells(5, 2) = "Gerente:"


                myrange = "C5:C5"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                ' hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja.Range(myrange).WrapText = True
                hoja.Range(myrange).Orientation = 0
                hoja.Range(myrange).AddIndent = False
                hoja.Range(myrange).IndentLevel = 0
                hoja.Range(myrange).ShrinkToFit = False
                hoja.Range(myrange).MergeCells = True
                hoja.Range(myrange).Font.Size = 10
                hoja.Range(myrange).Font.ColorIndex = 1
                hoja.Range(myrange).Font.Bold = True
                hoja.Cells(5, 3) = "Gerente: " & Me.cmbTipoDocto.Text




                myrange = "A7:C7"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                ' hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                '  hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 12
                hoja4.Range(myrange).Font.ColorIndex = 1
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(7, 1) = "NOMBRE DEL COLABORADOR"


                myrange = "D7:H7"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                ' hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 12
                hoja4.Range(myrange).Font.ColorIndex = 1
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(7, 4) = Me.cmbTipoDocto.Text


                myrange = "A8:C8"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                ' hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                ' hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 12
                hoja4.Range(myrange).Font.ColorIndex = 1
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(8, 1) = "DEPARTAMENTO"


                myrange = "D8:H8"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                '  hoja4.Range(myrange).Interior.ColorIndex = 49
                hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja4.Range(myrange).WrapText = True
                hoja4.Range(myrange).Orientation = 0
                hoja4.Range(myrange).AddIndent = False
                hoja4.Range(myrange).IndentLevel = 0
                hoja4.Range(myrange).ShrinkToFit = False
                hoja4.Range(myrange).MergeCells = True
                hoja4.Range(myrange).Font.Size = 12
                hoja4.Range(myrange).Font.ColorIndex = 2
                hoja4.Range(myrange).Font.Bold = True
                hoja4.Cells(8, 4) = ""
                Try
                    If entrodt And Ods.Tables("Autoevaluacion").Rows.Count > 0 Then
                        dtdistintos = clsgen.ValoresDistinto(Ods.Tables("Autoevaluacion"), "usuario_evaluacion".Split(","))
                        dtdistintos.DefaultView.RowFilter = " usuario_evaluacion <> '" & Me.cmbTipoDocto.Text & "'"
                        If dtdistintos.DefaultView.Count >= 0 Then

                            myrange = "A9:C9"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(9, 1) = "EVALUADOR"

                            myrange = "D9:H9"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(9, 4) = dtdistintos.DefaultView(0).Item("usuario_evaluacion")

                        End If
                    End If


                Catch ex As Exception

                End Try
              







                'hoja4.Range("C7:C7").ColumnWidth = 40







                'hoja.Cells(Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") + 12, 2) = "REPORTE 1- CALIFICACIÓN DE EMPLEADOS"

                hoja2.Cells(nrow, 2) = "COMPETENCIAS"
                hoja2.Cells(nrow, 3) = "DM"
                hoja2.Cells(nrow, 4) = "R"
                hoja2.Cells(nrow, 5) = "B"
                hoja2.Cells(nrow, 6) = "MB"
                hoja2.Cells(nrow, 7) = "SS"



                For i As Integer = 1 To 15
                    hoja2.Cells(7 + i, 1) = i
                Next

                hoja2.Cells(8, 2) = "HONESTIDAD"
                hoja2.Cells(9, 2) = "PERSEVERANCIA"
                hoja2.Cells(10, 2) = "ACTITUD HACIA SU TRABAJO"
                hoja2.Cells(11, 2) = "LIDERAZGO"
                hoja2.Cells(12, 2) = "RESPONSABILIDAD"
                hoja2.Cells(13, 2) = "INICIATIVA"
                hoja2.Cells(14, 2) = "CUMPLIMIENTO DE METAS"
                hoja2.Cells(15, 2) = "PLANIFICACIÓN Y ORG. "
                hoja2.Cells(16, 2) = "IDENTIF.  EMPRESA"
                hoja2.Cells(17, 2) = "TRABAJO EN EQUIPO"
                hoja2.Cells(18, 2) = "COMUNICACIÓN"
                hoja2.Cells(19, 2) = "MODALIDAD DE CONTACTO"
                hoja2.Cells(20, 2) = "RELACIONES INTERPERSONALES"
                hoja2.Cells(21, 2) = "ACTITUD DE SERVICIO"
                hoja2.Cells(22, 2) = "RESPETO"




                myrange = "B7:B7"
                hoja2.Range(myrange).Interior.ColorIndex = 49
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 2
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("B7:B7").ColumnWidth = 60


                myrange = "C7:C7"
                hoja2.Range(myrange).Interior.ColorIndex = 3
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 1
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("C7:C7").ColumnWidth = 15

                myrange = "D7:D7"
                hoja2.Range(myrange).Interior.ColorIndex = 44
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 1
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("D7:D7").ColumnWidth = 15


                myrange = "E7:E7"
                hoja2.Range(myrange).Interior.ColorIndex = 36
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 1
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("E7:E7").ColumnWidth = 15


                myrange = "F7:F7"
                hoja2.Range(myrange).Interior.ColorIndex = 43
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 1
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("F7:F7").ColumnWidth = 15

                myrange = "G7:G7"
                hoja2.Range(myrange).Interior.ColorIndex = 10
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = False
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = False
                hoja2.Range(myrange).Font.Size = 9
                hoja2.Range(myrange).Font.ColorIndex = 1
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Range("G7:G7").ColumnWidth = 15



                ''
                Dim icont As Integer = 0
                Dim datosx As DataTable
                Dim mrow As Integer = 0

                Dim ii As Integer = 0
                ii = 2
                For x As Integer = 1 To 15
                    For j As Integer = 1 To 5
                        hoja2.Cells(7 + x, ii + j) = 0
                    Next
                Next
                Dim sumapromedio As Integer = 0
                Dim Pcompe As Integer = 0
                Dim competencias As Integer = 0
                Dim clasificacion As Double = 0
                Dim color As Integer = 0



                For Each drx As DataRow In Ods.Tables("Cantidad_Items").Rows
                    icont += 1
                    Ods.Tables("Cantidad_Items").DefaultView.RowFilter = " cod_pregunta=" & icont
                    datosx = Ods.Tables("Cantidad_Items").DefaultView.ToTable
                    If icont <= 15 Then
                        Try
                            sumapromedio = datosx.Compute(" sum(conteo) ", " conteo>0 ")
                            hoja2.Cells(7 + icont, 8) = sumapromedio
                        Catch ex As Exception
                        Finally


                        End Try

                    End If


                    ii = 0
                    Dim entro As Boolean = False
                    Dim alternativa As Integer = 0
                    Dim yrow As Integer = 0
                    Pcompe = 0
                    competencias = 0
                    clasificacion = 0
                    color = 0


                    For Each astu As DataRow In datosx.Rows
                        ' ii += 1
                        If icont = 1 Then
                            mrow = 8
                        ElseIf icont = 2 Then
                            mrow = 9
                        ElseIf icont = 3 Then
                            mrow = 10
                        ElseIf icont = 4 Then
                            mrow = 11
                        ElseIf icont = 5 Then
                            mrow = 12
                        ElseIf icont = 6 Then
                            mrow = 13
                        ElseIf icont = 7 Then
                            mrow = 14
                        ElseIf icont = 8 Then
                            mrow = 15
                        ElseIf icont = 9 Then
                            mrow = 16
                        ElseIf icont = 10 Then
                            mrow = 17
                        ElseIf icont = 11 Then
                            mrow = 18
                        ElseIf icont = 12 Then
                            mrow = 19
                        ElseIf icont = 13 Then
                            mrow = 20
                        ElseIf icont = 14 Then
                            mrow = 21
                        ElseIf icont = 15 Then
                            mrow = 22
                        End If

                        If astu.Item("cod_alternativa") = 1 Then
                            yrow = 2
                        ElseIf astu.Item("cod_alternativa") = 2 Then
                            yrow = 3
                        ElseIf astu.Item("cod_alternativa") = 3 Then
                            yrow = 4
                        ElseIf astu.Item("cod_alternativa") = 4 Then
                            yrow = 5
                        ElseIf astu.Item("cod_alternativa") = 5 Then
                            yrow = 6

                        End If


                        If astu.Item("cod_pregunta") = icont And astu.Item("cod_alternativa") = 1 Then
                            hoja2.Cells(mrow, yrow + 1) = astu.Item("conteo")
                            Pcompe = astu.Item("conteo") * 2
                            competencias += Pcompe
                        End If

                        If astu.Item("cod_pregunta") = icont And astu.Item("cod_alternativa") = 2 Then
                            hoja2.Cells(mrow, yrow + 1) = astu.Item("conteo")
                            Pcompe = astu.Item("conteo") * 4
                            competencias += Pcompe
                        End If
                        If astu.Item("cod_pregunta") = icont And astu.Item("cod_alternativa") = 3 Then
                            hoja2.Cells(mrow, yrow + 1) = astu.Item("conteo")
                            Pcompe = astu.Item("conteo") * 6
                            competencias += Pcompe

                        End If
                        If astu.Item("cod_pregunta") = icont And astu.Item("cod_alternativa") = 4 Then
                            hoja2.Cells(mrow, yrow + 1) = astu.Item("conteo")
                            Pcompe = astu.Item("conteo") * 8
                            competencias += Pcompe

                        End If
                        If astu.Item("cod_pregunta") = icont And astu.Item("cod_alternativa") = 5 Then
                            hoja2.Cells(mrow, yrow + 1) = astu.Item("conteo")
                            Pcompe = astu.Item("conteo") * 10
                            competencias += Pcompe

                        End If
                        clasificacion = Math.Round(competencias / sumapromedio, 2)
                        hoja3.Cells(mrow, 3) = clasificacion

                        If clasificacion >= 9 Then
                            color = 10
                            hoja3.Cells(mrow, 4) = "S"
                        ElseIf clasificacion >= 8 Then
                            color = 43
                            hoja3.Cells(mrow, 4) = "MB"
                        ElseIf clasificacion >= 7.6 Then
                            color = 35
                            hoja3.Cells(mrow, 4) = "B+"
                        ElseIf clasificacion >= 7.4 Then
                            color = 44
                            hoja3.Cells(mrow, 4) = "B"
                        ElseIf clasificacion >= 7 Then
                            color = 27
                            hoja3.Cells(mrow, 4) = "B-"
                        ElseIf clasificacion >= 6 Then
                            color = 44
                            hoja3.Cells(mrow, 4) = "R"
                        ElseIf clasificacion > 0 Then
                            color = 3
                            hoja3.Cells(mrow, 4) = "DM"
                        End If

                        myrange = "D" & 7 + icont & ":D" & 7 + icont
                        hoja3.Range(myrange).Interior.ColorIndex = color
                        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                        hoja3.Range(myrange).WrapText = False
                        hoja3.Range(myrange).Orientation = 0
                        hoja3.Range(myrange).AddIndent = False
                        hoja3.Range(myrange).IndentLevel = 0
                        hoja3.Range(myrange).ShrinkToFit = False
                        hoja3.Range(myrange).MergeCells = False
                        hoja3.Range(myrange).Font.Size = 10
                        hoja3.Range(myrange).Font.ColorIndex = IIf(color = 3, 2, 3)
                        hoja3.Range(myrange).Font.Bold = True
                        ' hoja3.Range(myrange).ColumnWidth = 15


                    Next
                Next



                ''aqui


                Dim contador As Integer = 0

                ''undecima grafica
                For ix As Integer = 0 To 14
                    contador += 1
                    graficapie = libro.Charts.Add()
                    ' mExcel.Visible = True
                    graficapie.ChartType = Excel.XlChartType.xlPie
                    graficapie.SetSourceData(Source:=libro.Sheets("RESULTADOS GLOBALES").Range("D7:D7"))
                    graficapie.SeriesCollection.NewSeries()
                    graficapie.SeriesCollection.NewSeries()
                    graficapie.SeriesCollection.NewSeries()
                    graficapie.SeriesCollection.NewSeries()
                    graficapie.SeriesCollection.NewSeries()


                    graficapie.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent)
                    scolection = graficapie.SeriesCollection
                    With scolection.Item(1)
                        .Name = hoja2.Range("B" & 7 + contador).Value
                        .Values = hoja2.Range("C" & 7 + contador & ":G" & 7 + contador)
                        .XValues = hoja2.Range("C7:G7")
                    End With



                    graficapie.SeriesCollection(1).Format.ThreeD.Visible = True
                    graficapie.SeriesCollection(1).Format.ThreeD.BevelTopType = 1
                    graficapie.SeriesCollection(1).Format.ThreeD.BevelTopInset = 5
                    graficapie.SeriesCollection(1).Format.ThreeD.BevelTopDepth = 2


                    With graficapie.SeriesCollection(1).points(1).Format.fill

                        .Visible = True
                        .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                        .ForeColor.TintAndShade = 0
                        .ForeColor.Brightness = 0
                        .Transparency = 0

                        .ForeColor.RGB = RGB(255, 0, 0) 'rojo

                        .Solid()
                    End With

                    With graficapie.SeriesCollection(1).points(2).Format.fill
                        .Visible = True
                        .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                        .ForeColor.TintAndShade = 0
                        .ForeColor.Brightness = 0
                        .Transparency = 0
                        .ForeColor.RGB = RGB(255, 192, 0) 'amarillo fuerte



                        .Solid()
                    End With

                    With graficapie.SeriesCollection(1).points(3).Format.fill
                        .Visible = True
                        .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                        .ForeColor.TintAndShade = 0
                        .ForeColor.Brightness = 0
                        .Transparency = 0
                        .ForeColor.RGB = RGB(255, 255, 102) 'amarillo palido


                        .Solid()
                    End With


                    With graficapie.SeriesCollection(1).points(4).Format.fill
                        .Visible = True
                        .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                        .ForeColor.TintAndShade = 0
                        .ForeColor.Brightness = 0
                        .Transparency = 0
                        .ForeColor.RGB = RGB(146, 208, 80) ' verde suave


                        .Solid()
                    End With


                    With graficapie.SeriesCollection(1).points(5).Format.fill
                        .Visible = True
                        .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                        .ForeColor.TintAndShade = 0
                        .ForeColor.Brightness = 0
                        .Transparency = 0
                        .ForeColor.RGB = RGB(0, 176, 80) 'verde fuerte

                        .Solid()
                    End With
                    graficapie.Location(Excel.XlChartLocation.xlLocationAsObject, Name:="RESULTADOS GLOBALES")
                Next

                Dim icount1 As Integer = 7 '10
                Dim icount2 As Integer = 1
                Dim icount3 As Integer = 1

                'hoja2 = libro.Sheets("Graficas")
                For Each myshape As Excel.Shape In hoja2.Shapes


                    If icount3 = 3 Then
                        icount3 = 1
                        icount1 += 1
                        icount2 += 1
                    End If

                    myshape.IncrementTop((-550) + 265 * icount1) '550
                    myshape.IncrementLeft((-450) + 265 * IIf(icount3 = 2, icount3 + 0.5, icount3)) 'IIf(icount3 = 2, icount3 + 0.5, icount3)
                    icount3 += 1
                Next




                myrange = "A36:I36"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja2.Range(myrange).Interior.ColorIndex = 49
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = True
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = True
                hoja2.Range(myrange).Font.Size = 12
                hoja2.Range(myrange).Font.ColorIndex = 2
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Cells(36, 1) = "REPORTE 3-RESULTADOS POR DEPARTAMENTO"



                myrange = "A92:I92"
                'hoja.Range(myrange).Interior.ColorIndex = 37
                hoja2.Range(myrange).Interior.ColorIndex = 49
                hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                hoja2.Range(myrange).WrapText = True
                hoja2.Range(myrange).Orientation = 0
                hoja2.Range(myrange).AddIndent = False
                hoja2.Range(myrange).IndentLevel = 0
                hoja2.Range(myrange).ShrinkToFit = False
                hoja2.Range(myrange).MergeCells = True
                hoja2.Range(myrange).Font.Size = 12
                hoja2.Range(myrange).Font.ColorIndex = 2
                hoja2.Range(myrange).Font.Bold = True
                hoja2.Cells(92, 1) = "REPORTE 4-RESULTADOS POR COMPETENCIA"
                'CUADRO DE SEGUNDA HOJA



                ''

                ''

                'graficas

                graficaline = libro.Charts.Add()
                graficaline.ChartType = Excel.XlChartType.xlColumnStacked100
                graficaline.SeriesCollection.NewSeries()
                graficaline.SeriesCollection.NewSeries()
                graficaline.SeriesCollection.NewSeries()
                graficaline.SeriesCollection.NewSeries()
                'graficaline.SeriesCollection.NewSeries()
                'grafica.SetSourceData(Source:=libro.Sheets("hoja4").Range("K42"))
                scolection2 = graficaline.SeriesCollection
                'ActiveChart.SetSourceData(Source:=Range("B3:G18"))

                With scolection2.Item(1)
                    .Name = hoja2.Range("C7").Value
                    .Values = hoja2.Range("C8:C22")
                    .XValues = hoja2.Range("B8:B22")

                End With

                With scolection2.Item(2)
                    .Name = hoja2.Range("D7").Value
                    .Values = hoja2.Range("D8:D22")
                    .XValues = hoja2.Range("B8:B22")
                End With


                With scolection2.Item(3)
                    .Name = hoja2.Range("E7").Value
                    .Values = hoja2.Range("E8:E22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With

                With scolection2.Item(4)
                    .Name = hoja2.Range("F7").Value
                    .Values = hoja2.Range("F8:F22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With

                With scolection2.Item(5)
                    .Name = hoja2.Range("G7").Value
                    .Values = hoja2.Range("G8:G22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With



                graficaline.SeriesCollection(1).Format.ThreeD.Visible = True
                graficaline.SeriesCollection(1).Format.ThreeD.BevelTopType = 1
                graficaline.SeriesCollection(1).Format.ThreeD.BevelTopInset = 5
                graficaline.SeriesCollection(1).Format.ThreeD.BevelTopDepth = 2


                graficaline.SeriesCollection(2).Format.ThreeD.Visible = True
                graficaline.SeriesCollection(2).Format.ThreeD.BevelTopType = 1
                graficaline.SeriesCollection(2).Format.ThreeD.BevelTopInset = 5
                graficaline.SeriesCollection(2).Format.ThreeD.BevelTopDepth = 2

                graficaline.SeriesCollection(3).Format.ThreeD.Visible = True
                graficaline.SeriesCollection(3).Format.ThreeD.BevelTopType = 1
                graficaline.SeriesCollection(3).Format.ThreeD.BevelTopInset = 5
                graficaline.SeriesCollection(3).Format.ThreeD.BevelTopDepth = 2



                graficaline.SeriesCollection(4).Format.ThreeD.Visible = True
                graficaline.SeriesCollection(4).Format.ThreeD.BevelTopType = 1
                graficaline.SeriesCollection(4).Format.ThreeD.BevelTopInset = 5
                graficaline.SeriesCollection(4).Format.ThreeD.BevelTopDepth = 2

                graficaline.SeriesCollection(5).Format.ThreeD.Visible = True
                graficaline.SeriesCollection(5).Format.ThreeD.BevelTopType = 1
                graficaline.SeriesCollection(5).Format.ThreeD.BevelTopInset = 5
                graficaline.SeriesCollection(5).Format.ThreeD.BevelTopDepth = 2


                With graficaline.SeriesCollection(5).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(0, 176, 80) 'verde fuerte

                    .Solid()
                End With




                With graficaline.SeriesCollection(1).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 0, 0) 'rojo

                    .Solid()
                End With


                With graficaline.SeriesCollection(4).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(146, 208, 80) ' verde suave

                    .Solid()
                End With



                With graficaline.SeriesCollection(3).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 255, 102) 'amarillo palido

                    .Solid()
                End With



                With graficaline.SeriesCollection(2).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 192, 0) 'amarillo fuerte

                    .Solid()
                End With





                With scolection2.Item(1)
                    .Border.LineStyle = -4105 'automatic
                    .Border.Weight = 2 'xlthing 
                    .Shadow = False
                    .InvertIfNegative = False
                    .Interior.ColorIndex = 3
                    .Interior.Pattern = 1 'xlSolid
                End With

                With graficaline
                    .PlotArea.Interior.ColorIndex = -4142
                End With
                With graficaline
                    .HasAxis(1, 1) = True
                    .HasAxis(1, 2) = False
                    .HasAxis(2, 1) = True
                    .HasAxis(2, 2) = True
                End With
                graficaline.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom


                With graficaline.Axes(Excel.XlAxisType.xlCategory).TickLabels
                    .Alignment = -4108   'xlCenter
                    .Offset = 100
                    .ReadingOrder = -5002
                    'Excel.Constants.xlContext() ''Valores de Constantes
                    .Orientation = Excel.XlTickLabelOrientation.xlTickLabelOrientationUpward
                    .font.size = 9
                End With
                'grafica.Location(Excel.XlChartLocation.xlLocationAsObject, "")

                For Each myshape As Excel.Shape In hoja.Shapes
                    myshape.ScaleWidth(1.5, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft)

                Next
                graficaline.Location(Excel.XlChartLocation.xlLocationAsObject, Name:="RESULTADOS GLOBALES")
                icount1 = 0
                For Each myshape As Excel.Shape In hoja2.Shapes
                    icount1 += 1
                    If icount1 = hoja2.Shapes.Count Then
                        myshape.IncrementTop(740) '760
                        myshape.IncrementLeft(-385)
                        myshape.ScaleWidth(2.5, Microsoft.Office.Core.MsoTriState.msoFalse)
                        myshape.ScaleHeight(1.95, Microsoft.Office.Core.MsoTriState.msoFalse)
                    End If
                Next


                ''grafica tercera hoa

                graficaarea = libro.Charts.Add()
                graficaarea.ChartType = Excel.XlChartType.xlAreaStacked100
                scolection3 = graficaarea.SeriesCollection

                With scolection3.Item(1) 'rojo
                    .Name = hoja2.Range("C7").Value
                    .Values = hoja2.Range("C8:C22")
                    .XValues = hoja2.Range("B8:B22")

                End With


                With scolection3.Item(2) 'amarillo fuerte
                    .Name = hoja2.Range("D7").Value
                    .Values = hoja2.Range("D8:D22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With


                With scolection3.Item(3) 'amarillo palido
                    .Name = hoja2.Range("E7").Value
                    .Values = hoja2.Range("E8:E22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With


                With scolection3.Item(4) 'verde palido
                    .Name = hoja2.Range("F7").Value
                    .Values = hoja2.Range("F8:F22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With

                With scolection3.Item(5) 'verde fuerte
                    .Name = hoja2.Range("G7").Value
                    .Values = hoja2.Range("G8:G22")
                    .XValues = hoja2.Range("B8:B22")
                    '   .ChartType = Excel.XlChartType.xlConeBarClustered
                End With

                graficaarea.SeriesCollection(1).Format.ThreeD.Visible = True
                graficaarea.SeriesCollection(1).Format.ThreeD.BevelTopType = 1
                graficaarea.SeriesCollection(1).Format.ThreeD.BevelTopInset = 5
                graficaarea.SeriesCollection(1).Format.ThreeD.BevelTopDepth = 2



                graficaarea.SeriesCollection(2).Format.ThreeD.Visible = True
                graficaarea.SeriesCollection(2).Format.ThreeD.BevelTopType = 1
                graficaarea.SeriesCollection(2).Format.ThreeD.BevelTopInset = 5
                graficaarea.SeriesCollection(2).Format.ThreeD.BevelTopDepth = 2


                graficaarea.SeriesCollection(3).Format.ThreeD.Visible = True
                graficaarea.SeriesCollection(3).Format.ThreeD.BevelTopType = 1
                graficaarea.SeriesCollection(3).Format.ThreeD.BevelTopInset = 5
                graficaarea.SeriesCollection(3).Format.ThreeD.BevelTopDepth = 2


                graficaarea.SeriesCollection(4).Format.ThreeD.Visible = True
                graficaarea.SeriesCollection(4).Format.ThreeD.BevelTopType = 1
                graficaarea.SeriesCollection(4).Format.ThreeD.BevelTopInset = 5
                graficaarea.SeriesCollection(4).Format.ThreeD.BevelTopDepth = 2



                graficaarea.SeriesCollection(5).Format.ThreeD.Visible = True
                graficaarea.SeriesCollection(5).Format.ThreeD.BevelTopType = 1
                graficaarea.SeriesCollection(5).Format.ThreeD.BevelTopInset = 5
                graficaarea.SeriesCollection(5).Format.ThreeD.BevelTopDepth = 2




                With graficaarea.SeriesCollection(5).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(0, 176, 80) 'verde fuerte

                    .Solid()
                End With




                With graficaarea.SeriesCollection(1).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 0, 0) 'rojo

                    .Solid()
                End With


                With graficaarea.SeriesCollection(4).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(146, 208, 80) ' verde suave

                    .Solid()
                End With



                With graficaarea.SeriesCollection(3).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 255, 102) 'amarillo palido

                    .Solid()
                End With



                With graficaarea.SeriesCollection(2).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 192, 0) 'amarillo fuerte

                    .Solid()
                End With


                With graficaarea
                    .PlotArea.Interior.ColorIndex = -4142
                End With


                With graficaarea
                    .HasAxis(1, 1) = True
                    .HasAxis(1, 2) = False
                    .HasAxis(2, 1) = True
                    .HasAxis(2, 2) = True
                End With
                graficaarea.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom

                With graficaarea.Axes(Excel.XlAxisType.xlCategory).TickLabels
                    .Alignment = -4108   'xlCenter -4108
                    .Offset = 100
                    .ReadingOrder = -5002
                    'Excel.Constants.xlContext() ''Valores de Constantes
                    .Orientation = Excel.XlTickLabelOrientation.xlTickLabelOrientationUpward
                    .font.size = 9
                End With

                ' grafica.Location(Excel.XlChartLocation.xlLocationAsObject, "")

                For Each myshape As Excel.Shape In hoja.Shapes
                    myshape.ScaleWidth(1.5, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft)

                Next

                graficaarea.Location(Excel.XlChartLocation.xlLocationAsObject, Name:="RESULTADOS GLOBALES")
                icount1 = 0
                For Each myshape As Excel.Shape In hoja2.Shapes
                    icount1 += 1
                    If icount1 = hoja2.Shapes.Count Then
                        myshape.IncrementTop(405) '460
                        myshape.IncrementLeft(-385)
                        myshape.ScaleWidth(2.45, Microsoft.Office.Core.MsoTriState.msoFalse) '2.68
                        myshape.ScaleHeight(1.42, Microsoft.Office.Core.MsoTriState.msoFalse) '1.42 ozziel
                        mExcel.Visible = True
                    End If
                Next












                ''grafica cuarta hoja
                'graficas

                If entrodt And Ods.Tables("Autoevaluacion").Rows.Count > 0 Then
                    Dim ixcont As Integer = 0
                    nrow = 200
                    dtdistintos = clsgen.ValoresDistinto(Ods.Tables("Autoevaluacion"), "cod_resultado".Split(","))
                    For Each drr As DataRow In dtdistintos.Rows
                        ixcont += 1

                        Ods.Tables("Autoevaluacion").DefaultView.RowFilter = " cod_resultado=" & drr("cod_resultado")
                        datos = Ods.Tables("Autoevaluacion").DefaultView.ToTable
                        nrow += 1
                        icount += 1
                        hoja4.Cells(nrow, 2) = icount
                        hoja4.Cells(nrow, 3) = datos.Rows(0).Item("usuario_evaluacion")
                        hoja4.Cells(nrow, 4) = datos.Rows(0).Item("puesto")
                        hoja4.Cells(nrow, 5) = datos.Rows(0).Item("cod_alternativa")
                        hoja4.Cells(nrow, 6) = datos.Rows(1).Item("cod_alternativa")
                        hoja4.Cells(nrow, 7) = datos.Rows(2).Item("cod_alternativa")
                        hoja4.Cells(nrow, 8) = datos.Rows(3).Item("cod_alternativa")
                        hoja4.Cells(nrow, 9) = datos.Rows(4).Item("cod_alternativa")
                        hoja4.Cells(nrow, 10) = datos.Rows(5).Item("cod_alternativa")
                        hoja4.Cells(nrow, 11) = datos.Rows(6).Item("cod_alternativa")
                        hoja4.Cells(nrow, 12) = datos.Rows(7).Item("cod_alternativa")
                        hoja4.Cells(nrow, 13) = datos.Rows(8).Item("cod_alternativa")
                        hoja4.Cells(nrow, 14) = datos.Rows(9).Item("cod_alternativa")
                        hoja4.Cells(nrow, 15) = datos.Rows(10).Item("cod_alternativa")
                        hoja4.Cells(nrow, 16) = datos.Rows(11).Item("cod_alternativa")
                        hoja4.Cells(nrow, 17) = datos.Rows(12).Item("cod_alternativa")
                        hoja4.Cells(nrow, 18) = datos.Rows(13).Item("cod_alternativa")
                        hoja4.Cells(nrow, 19) = datos.Rows(14).Item("cod_alternativa")




                        Try
                            For i As Integer = 0 To 14
                                If datos.Rows(i).Item("cod_alternativa") = 2 Then
                                    dm += 1
                                End If

                                If datos.Rows(i).Item("cod_alternativa") = 4 Then
                                    r += 1
                                End If
                                If datos.Rows(i).Item("cod_alternativa") = 6 Then
                                    b += 1
                                End If
                                If datos.Rows(i).Item("cod_alternativa") = 8 Then
                                    mb += 1
                                End If

                                If datos.Rows(i).Item("cod_alternativa") = 10 Then
                                    ss += 1
                                End If

                            Next
                        Catch ex As Exception

                        End Try

                        total_items += dm + r + b + mb + ss
                        hoja4.Cells(nrow, 20) = dm
                        hoja4.Cells(nrow, 21) = r
                        hoja4.Cells(nrow, 22) = b
                        hoja4.Cells(nrow, 23) = mb
                        hoja4.Cells(nrow, 24) = ss

                        If total_items > 0 Then
                            ponderacion = (dm * 2 + r * 4 + b * 6 + mb * 8 + ss * 10) / total_items
                        Else
                            ponderacion = 0
                        End If

                        hoja4.Cells(nrow, 25) = Math.Round(ponderacion, 2)
                        hoja4.Cells(200, 26) = "DM"
                        hoja4.Cells(200, 27) = "R"
                        hoja4.Cells(200, 28) = "B-"
                        hoja4.Cells(200, 29) = "B"
                        hoja4.Cells(200, 30) = "B+"
                        hoja4.Cells(200, 31) = "MB"
                        hoja4.Cells(200, 32) = "S"
                        hoja4.Cells(200, 33) = "CLASIFICACIÓN"


                        If ponderacion > 0 And ponderacion <= 5.99 Then

                            hoja4.Cells(nrow, 26) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = ""
                        End If

                        If ponderacion >= 6 And ponderacion < 7 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = ""
                        End If

                        If ponderacion >= 7 And ponderacion < 7.4 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = ""
                        End If

                        If ponderacion >= 7.4 And ponderacion < 7.6 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = ""
                        End If

                        If ponderacion >= 7.6 And ponderacion < 8 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = ""
                        End If

                        If ponderacion >= 8 And ponderacion < 9 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = Math.Round(ponderacion, 2)
                            hoja4.Cells(nrow, 32) = ""
                        End If


                        If ponderacion >= 9 And ponderacion < 10 Then

                            hoja4.Cells(nrow, 26) = ""
                            hoja4.Cells(nrow, 27) = ""
                            hoja4.Cells(nrow, 28) = ""
                            hoja4.Cells(nrow, 29) = ""
                            hoja4.Cells(nrow, 30) = ""
                            hoja4.Cells(nrow, 31) = ""
                            hoja4.Cells(nrow, 32) = Math.Round(ponderacion, 2)
                        End If

                        dm = 0
                        r = 0
                        b = 0
                        mb = 0
                        ss = 0
                        total_items = 0

                        If ponderacion >= 9 Then
                            hoja4.Cells(nrow, 33) = "S"

                        ElseIf ponderacion >= 8 Then
                            hoja4.Cells(nrow, 33) = "MB"

                        ElseIf ponderacion >= 7.6 Then
                            hoja4.Cells(nrow, 33) = "B+"

                        ElseIf ponderacion >= 7.4 Then
                            hoja4.Cells(nrow, 33) = "B"

                        ElseIf ponderacion >= 7 Then
                            hoja4.Cells(nrow, 33) = "B-"

                        ElseIf ponderacion >= 6 Then
                            hoja4.Cells(nrow, 33) = "R"

                        ElseIf ponderacion > 0 Then
                            hoja4.Cells(nrow, 33) = "DM"
                        End If

                        Ods.Tables("Autoevaluacion").DefaultView.RowFilter = ""

                        If ixcont = 1 Then
                            myrange = "A10:C10"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            'hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(10, 1) = "EVALUACIÓN"

                            myrange = "E10:E10"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True

                            hoja4.Cells(10, 4) = Math.Round(ponderacion, 2)
                            myrange = "D10:D10"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True


                            hoja4.Cells(10, 5) = hoja4.Cells(nrow, 33)

                        Else
                            myrange = "A11:C11"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            'hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(11, 1) = "AUTOEVALUACION"

                            myrange = "E11:E11"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(11, 5) = hoja4.Cells(nrow, 33)



                            myrange = "D11:D11"
                            hoja4.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                            hoja4.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                            hoja4.Range(myrange).WrapText = True
                            hoja4.Range(myrange).Orientation = 0
                            hoja4.Range(myrange).AddIndent = False
                            hoja4.Range(myrange).IndentLevel = 0
                            hoja4.Range(myrange).ShrinkToFit = False
                            hoja4.Range(myrange).MergeCells = True
                            hoja4.Range(myrange).Font.Size = 12
                            hoja4.Range(myrange).Font.ColorIndex = 1
                            hoja4.Range(myrange).Font.Bold = True
                            hoja4.Cells(11, 4) = Math.Round(ponderacion, 2)




                        End If



                    Next


                End If






                Dim graficalineclus As Excel.Chart

                ''ULTIMA GRAFICA
                graficalineclus = libro.Charts.Add()
                graficalineclus.ChartType = Excel.XlChartType.xlBarClustered
                graficalineclus.SetSourceData(Source:=libro.Sheets("RESULTADOS GLOBALES").Range("B8"))
                graficalineclus.SeriesCollection.NewSeries()
                'graficaline.SeriesCollection.NewSeries()

                scolection4 = graficalineclus.SeriesCollection

                With scolection4.Item(1)
                    .Name = "AUTOEVALUACIÓN"
                    .Values = hoja4.Range("E201:S201")
                    .XValues = hoja2.Range("B8:B22")

                End With


                'ActiveChart.SetSourceData(Source:=Range("B3:G18"))
                'Selection.Format.ThreeD.BevelTopInset = 5
                'Selection.Format.ThreeD.BevelTopDepth = 2


                With scolection4.Item(2)
                    .Name = "EVALUACIÓN"
                    .Values = hoja4.Range("E202:S202")
                    .XValues = hoja2.Range("B8:B22")

                    '                    .Border.LineStyle = Excel.XlBorderWeight.
                End With

                With graficalineclus

                End With

                graficalineclus.SeriesCollection(1).Format.ThreeD.Visible = True
                graficalineclus.SeriesCollection(1).Format.ThreeD.BevelTopType = 1
                graficalineclus.SeriesCollection(1).Format.ThreeD.BevelTopInset = 5
                graficalineclus.SeriesCollection(1).Format.ThreeD.BevelTopDepth = 2


                graficalineclus.SeriesCollection(2).Format.ThreeD.Visible = True
                graficalineclus.SeriesCollection(2).Format.ThreeD.BevelTopType = 1
                graficalineclus.SeriesCollection(2).Format.ThreeD.BevelTopInset = 5
                graficalineclus.SeriesCollection(2).Format.ThreeD.BevelTopDepth = 2

                With graficalineclus.SeriesCollection(1).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(255, 0, 0) ' verde fuerte

                    .Solid()
                End With

                With graficalineclus.SeriesCollection(2).Format.fill
                    .Visible = True
                    .ForeColor.ObjectThemeColor = Excel.XlBackground.xlBackgroundOpaque
                    .ForeColor.TintAndShade = 0
                    .ForeColor.Brightness = 0
                    .Transparency = 0
                    .ForeColor.RGB = RGB(0, 176, 80) ' verde fuerte

                    .Solid()
                End With





                graficalineclus.ChartGroups(1).GapWidth = 10
                graficalineclus.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop
                With graficalineclus.Axes(Excel.XlAxisType.xlValue)
                    .MaximumScale = 10

                End With



                With graficalineclus.Axes(Excel.XlAxisType.xlCategory).TickLabels
                    .Alignment = -4108   'xlCenter
                    .Offset = 100
                    .ReadingOrder = -5002
                    .Orientation = Excel.XlTickLabelOrientation.xlTickLabelOrientationHorizontal
                    .font.size = 9
                End With
                'grafica.Location(Excel.XlChartLocation.xlLocationAsObject, "")

                For Each myshape As Excel.Shape In hoja4.Shapes
                    myshape.ScaleWidth(1.5, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft)

                Next
                graficalineclus.Location(Excel.XlChartLocation.xlLocationAsObject, Name:="AUTOEVALUACIÓN")
                icount1 = 0
                For Each myshape As Excel.Shape In hoja4.Shapes
                    icount1 += 1
                    If icount1 = hoja4.Shapes.Count Then
                        myshape.IncrementTop(45) '460
                        myshape.IncrementLeft(-385)
                        myshape.ScaleWidth(1.5, Microsoft.Office.Core.MsoTriState.msoFalse) '2.68
                        myshape.ScaleHeight(1.5, Microsoft.Office.Core.MsoTriState.msoFalse) '1.42
                    End If


                    hoja.Application.ActiveWindow.Zoom = 100 '    100 
                    hoja.Activate()
                    hoja2.Application.ActiveWindow.Zoom = 70 '70 
                    hoja2.Activate()
                    hoja3.Application.ActiveWindow.Zoom = 145 '145
                    hoja3.Activate()
                    hoja4.Application.ActiveWindow.Zoom = 130 '130
                    hoja4.Activate()

                    mExcel.Visible = True
                    hoja2.Columns("A:A").ColumnWidth = 4.71
                    hoja2.Columns("B:B").ColumnWidth = 44.14
                    hoja2.Columns("C:C").ColumnWidth = 11.57
                    hoja2.Columns("D:G").ColumnWidth = 5.86
                    hoja2.Columns("H:H").ColumnWidth = 3.29
                    hoja2.Columns("I:I").ColumnWidth = 4.86


                    hoja3.Columns("A:A").ColumnWidth = 9.29
                    hoja3.Columns("B:B").ColumnWidth = 34
                    hoja3.Columns("C:C").ColumnWidth = 20.86
                    hoja3.Columns("D:D").ColumnWidth = 12.57
                    hoja3.Columns("E:E").ColumnWidth = 13.71
                    hoja3.Rows("8:8").RowHeight = 14.25
                    hoja3.Rows("9:8").RowHeight = 14.25
                    hoja3.Rows("10:8").RowHeight = 14.25
                    hoja3.Rows("11:8").RowHeight = 14.25
                    hoja3.Rows("12:8").RowHeight = 14.25
                    hoja3.Rows("13:8").RowHeight = 14.25
                    hoja3.Rows("14:8").RowHeight = 14.25
                    hoja3.Rows("15:8").RowHeight = 14.25
                    hoja3.Rows("16:8").RowHeight = 14.25
                    hoja3.Rows("17:8").RowHeight = 14.25
                    hoja3.Rows("18:8").RowHeight = 14.25
                    hoja3.Rows("19:8").RowHeight = 14.25
                    hoja3.Rows("20:8").RowHeight = 14.25
                    hoja3.Rows("21:8").RowHeight = 14.25
                    hoja3.Rows("22:8").RowHeight = 14.25
                    hoja2.Rows("4:1").RowHeight = 19.5
                    hoja2.Rows("7:1").RowHeight = 19.5
                    hoja2.Rows("36:1").RowHeight = 18
                    hoja2.Rows("92:1").RowHeight = 18
                    hoja.Activate()


                Next

                Oaut._xlDibujar_Bordes(hoja4, "A7:H11")
                ''
            End If
            Oaut._xlFinalizar_Libro(libro)

            '                Oaut._xlDibujar_Bordes(hoja, "C" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") * 3 + 15 & ":F" & Ods.Tables("Cantidad_Evaluaciones").Rows(0).Item("Cantidad") * 4 + 11)

        Catch ex As Exception
        Finally
            mExcel.Visible = True
            mExcel = Nothing
            libro = Nothing
            hoja = Nothing
            hoja2 = Nothing
            hoja3 = Nothing
            hoja4 = Nothing
        End Try








    End Sub




    Private Sub Generar_Informacion()
        Dim otrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt As DataTable
        Dim ls_sql As String

        Try


            otrans.open()
            If Ods.Tables.Contains("Resultado") Then
                Ods.Tables.Remove("Resultado")
            End If
            If Ods.Tables.Contains("Cantidad_Evaluaciones") Then
                Ods.Tables.Remove("Cantidad_Evaluaciones")
            End If

            If Ods.Tables.Contains("Cantidad_Items") Then
                Ods.Tables.Remove("Cantidad_Items")
            End If
            If Ods.Tables.Contains("Autoevaluacion") Then
                Ods.Tables.Remove("Autoevaluacion")
            End If







            ls_sql = "call pa_sel_um_seg_usuario_evaluacion_resultado(" & IIf(Me.chk_recogera.Checked = True, "NULL", "'" & Me.cmbTipoDocto.SelectedValue.ToString & "'") & ")"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "Resultado"
            Ods.Tables.Add(dt.Copy)

            ' ls_sql = "call pa_sel_um_seg_usuario_evaluacion_cantidad ('" & Me.cmbTipoDocto.SelectedValue.ToString & "')"
            ls_sql = "call pa_sel_um_seg_usuario_evaluacion_cantidad (" & IIf(Me.chk_recogera.Checked = True, "NULL", "'" & Me.cmbTipoDocto.SelectedValue.ToString & "'") & ")"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "Cantidad_Evaluaciones"
            Ods.Tables.Add(dt.Copy)

            'ls_sql = "call pa_sel_um_seg_usuario_evaluacion_resultado_item ('" & Me.cmbTipoDocto.SelectedValue.ToString & "')"
            ls_sql = "call pa_sel_um_seg_usuario_evaluacion_resultado_item (" & IIf(Me.chk_recogera.Checked = True, "NULL", "'" & Me.cmbTipoDocto.SelectedValue.ToString & "'") & ")"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "Cantidad_Items"
            Ods.Tables.Add(dt.Copy)


            If Me.chk_recogera.Checked = False Then
                ls_sql = "call pa_sel_um_seg_usuario_evaluacion_resultado_autoevaluacion( '" & Me.cmbTipoDocto.SelectedValue.ToString & "')"
                dt = otrans.Obtiene(ls_sql)
                dt.TableName = "Autoevaluacion"
                Ods.Tables.Add(dt.Copy)
                entrodt = True
            Else
                entrodt = False

            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub




    Private Sub llenar_combo()
        Dim otrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt As DataTable
        Dim ls_sql As String

        Try


            otrans.open()
            ls_sql = "call pa_sel_um_seg_usuario_evaluacion_evaluador()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "Usuarios"
            Ods.Tables.Add(dt.Copy)
            Me.cmbTipoDocto.DataSource = Ods.Tables("Usuarios")
            Me.cmbTipoDocto.ValueMember = "usuario_evaluacion"
            Me.cmbTipoDocto.DisplayMember = "nombre"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub




    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Generar_Informacion()
        Enviar_Excel_Ingresar_Punteo()
        'pruebaformato()
    End Sub




    Private Sub pruebaformato()
        Dim encontrado As Boolean = False
        Dim mExcel As New Excel.Application
        Dim libro As Excel.Workbook
        Dim hoja2 As Excel.Worksheet
        Dim hoja As Excel.Worksheet
        Dim hoja3 As Excel.Worksheet
        Dim hoja4 As Excel.Worksheet

        Dim graficaline As Excel.Chart
        Dim graficaarea As Excel.Chart
        Dim graficapie As Excel.Chart

        Dim formatt As Excel.FormatCondition
        libro = mExcel.Workbooks.Add

        hoja = libro.Sheets.Add
        Oaut._xlInicializar_Hoja(hoja, "AUTOEVALUACIÓN")



        hoja.Range("A2").Value = "1"
        hoja.Range("A3").Value = "2"
        hoja.Range("A4").Value = "3"
        hoja.Range("A5").Value = "8"
        hoja.Range("A6").Value = "7"
        hoja.Range("A7").Value = "4"
        hoja.Range("A8").Value = "5"

        'myrange = "A1:A8"
        'hoja.Range("A1:A8").
        hoja.Range("A1:A8").FormatConditions.AddDatabar()
        'hoja.Range("A1:A8").FormatConditions(1).ShowValue = True
        'hoja.Range("A1:A8").FormatConditions(1).SetFirstPriority()
        Dim formatt2 As Excel.FormatCondition = hoja.FormatConditions





        With formatt2
            .MinPoint.Modify(0)
            .MaxPoint.Modify(10)
        End With
        'With hoja.Range("A1:A8").FormatConditions(1).BarColor
        '    .Color = 13012579
        '    .TintAndShade = 0
        'End With
        'Selection.FormatConditions(1).BarFillType = xlDataBarFillGradient
        'Selection.FormatConditions(1).Direction = xlContext
        'Selection.FormatConditions(1).NegativeBarFormat.ColorType = xlDataBarColor
        'Selection.FormatConditions(1).BarBorder.Type = xlDataBarBorderSolid
        'Selection.FormatConditions(1).NegativeBarFormat.BorderColorType = _
        '    xlDataBarColor
        'With Selection.FormatConditions(1).BarBorder.Color
        '    .Color = 13012579
        '    .TintAndShade = 0
        'End With
        'Selection.FormatConditions(1).AxisPosition = xlDataBarAxisAutomatic
        'With Selection.FormatConditions(1).AxisColor
        '    .Color = 0
        '    .TintAndShade = 0
        'End With
        'With Selection.FormatConditions(1).NegativeBarFormat.Color
        '    .Color = 255
        '    .TintAndShade = 0
        'End With
        'With Selection.FormatConditions(1).NegativeBarFormat.BorderColor
        '    .Color = 255
        '    .TintAndShade = 0
        'End With
        'Range("A9").Select()
        'ActiveCell.FormulaR1C1 = "2"
        'Range("A10").Select()

        mExcel.Visible = True

    End Sub




    Private Sub Frm_Evaluacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combo()

    End Sub








End Class