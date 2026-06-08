Imports System.Data
Imports Microsoft.Office.Interop



Public Class Frm_EvaluacionD

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
        Dim hoja2, hoja3 As Excel.Worksheet
        Dim myrange As String
        Dim clsgen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt As DataTable
        Dim ls_sql As String

        otrans.open()
        '  If Ods.Tables("Resultado").Rows.Count > 0 Then
        libro = mExcel.Workbooks.Add
        hoja2 = libro.Sheets.Add
        hoja3 = libro.Sheets.Add

        Oaut._xlInicializar_Hoja(hoja2, "Score Card Niveles")
        hoja2.Cells(1, 2) = Me.cmb_equipo.Text
        Oaut._xlInicializar_Hoja(hoja3, "Score Card Preguntas")
        hoja3.Cells(1, 2) = Me.cmb_equipo.Text


        '-------------------------------------------------------------------------------------------------------------
        '------------------------------------------------INICIALIZACION DE HOJA NO.3----------------------------------
        Dim dt_equipo, dt_distintosGrupos, dt_grupoPregunta, dt_preguntas, dt_resultados As DataTable
        Dim icont As Integer = 0
        Dim icont0 As Integer = 0
        Dim iconta As Integer = 0


        ls_sql = " select * from seg_usuario_evaluacion_mk a" & _
                 " inner join mov_encuesta_grupo_pregunta b on a.cod_grupo=b.cod_grupo" & _
                 " where a.equipo='" & Me.cmb_equipo.Text & "'" & _
                 " order by a.cod_grupo asc"
        dt_equipo = otrans.Obtiene(ls_sql)
        dt_distintosGrupos = clsgen.ValoresDistinto(dt_equipo, "cod_pregunta".Split(","))
        '   mExcel.Visible = True
        For Each dr As DataRow In dt_distintosGrupos.Rows
            icont0 += 1
            ls_sql = "select * from mov_encuesta_grupo_pregunta where cod_pregunta=" & dr.Item("cod_pregunta")
            dt_grupoPregunta = otrans.Obtiene(ls_sql)
            If icont = 0 Then
                icont += 6
            Else
                icont += 3
            End If

            For Each dr2 As DataRow In dt_grupoPregunta.Rows
                icont += 1
                If iconta = 0 Then
                    'coloco el titulo
                    hoja3.Cells(icont, 2) = dr2.Item("titulo")
                    myrange = "B" & icont & ":B" & icont + 1 & ""
                    hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                    hoja3.Range(myrange).WrapText = False
                    hoja3.Range(myrange).Orientation = 0
                    hoja3.Range(myrange).AddIndent = False
                    hoja3.Range(myrange).IndentLevel = 0
                    hoja3.Range(myrange).ShrinkToFit = False
                    hoja3.Range(myrange).MergeCells = True
                    hoja3.Range(myrange).Font.Size = 12
                    hoja3.Range(myrange).Font.ColorIndex = 1
                    hoja3.Range(myrange).Font.Bold = True
                    hoja3.Range("B" & icont & ":B" & icont + 1 & "").ColumnWidth = 60
                    Oaut._xlDibujar_Bordes(hoja3, "B" & icont & ":B" & icont + 1 & "")


                    hoja3.Cells(icont + 2, 2) = dr2.Item("descripcion")
                    myrange = "B" & icont + 2 & ":B" & icont + 2 & ""
                    hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                    hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify
                    hoja3.Range(myrange).Orientation = 0
                    hoja3.Range(myrange).AddIndent = False
                    hoja3.Range(myrange).IndentLevel = 0
                    hoja3.Range(myrange).ShrinkToFit = False
                    hoja3.Range(myrange).Font.Size = 10
                    hoja3.Range(myrange).Font.ColorIndex = 1
                    hoja3.Range(myrange).Font.Bold = True
                    hoja3.Range("B" & icont + 2 & ":B" & icont + 2 & "").ColumnWidth = 60

                    iconta += 1
                    ls_sql = " SELECT cod_pregunta, convert(cast(`descripcion` as char charset binary) using utf8) AS `descripcion` FROM mov_encuesta_modelo_detalle  " & _
                            " where empresa='dmarte1' and cod_encuesta=6 " & _
                            " and cod_tipo_respuesta=1 and cod_grupo_encuesta=" & dr2.Item("cod_grupo") & " order by cod_pregunta asc "
                    dt_preguntas = otrans.Obtiene(ls_sql)

                    Dim ax As Integer = 0
                    Dim ay As Integer = 0
                    For Each dr3 As DataRow In dt_preguntas.Rows
                        ax += 1
                        If ax = 1 Then
                            hoja3.Cells(icont + 3, 2) = dr3.Item("descripcion")
                            myrange = "B" & icont + 3 & ":B" & icont + 3 & ""
                            hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                            hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify
                            ay = icont + 3
                            ls_sql = "SELECT count(c.cod_alternativa)as conteo,c.cod_alternativa FROM seg_usuario_evaluacion_mk a " & _
                            " inner join mov_encuesta_resultado_encabezado b on a.empresa=b.empresa and a.cod_encuesta=b.cod_encuesta " & _
                            " inner join mov_encuesta_resultado_detalle_alternativa c on a.empresa=c.empresa and a.cod_encuesta=c.cod_encuesta " & _
                            " and b.cod_resultado=c.cod_resultado " & _
                            " and a.usuario=b.usuario_grabo " & _
                            " where a.equipo='" & Me.cmb_equipo.Text & "' and a.empresa='dmarte1' and a.cod_encuesta=6 " & _
                            " and a.cod_grupo=" & dr2.Item("cod_grupo") & " and c.cod_pregunta=" & dr3.Item("cod_pregunta") & " " & _
                            " group by c.cod_alternativa " & _
                            " order by c.cod_alternativa asc "
                            dt_resultados = otrans.Obtiene(ls_sql)
                            Try
                                If dt_resultados.Rows.Count > 0 Then

                                    Try
                                        hoja3.Cells(icont + 3, 4) = dt_resultados.Rows(0).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 4) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(icont + 3, 5) = dt_resultados.Rows(1).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 5) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(icont + 3, 6) = dt_resultados.Rows(2).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 6) = 0
                                    End Try
                                Else
                                    hoja3.Cells(icont + 3, 4) = 0
                                    hoja3.Cells(icont + 3, 5) = 0
                                    hoja3.Cells(icont + 3, 6) = 0
                                End If
                            Catch ex As Exception

                            End Try


                        Else
                            hoja3.Cells(ay + ax - 1, 2) = dr3.Item("descripcion")
                            myrange = "B" & ay + ax - 1 & ":B" & ay + ax - 1 & ""
                            hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                            hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify

                            ls_sql = "SELECT count(c.cod_alternativa)as conteo,c.cod_alternativa FROM seg_usuario_evaluacion_mk a " & _
                           " inner join mov_encuesta_resultado_encabezado b on a.empresa=b.empresa and a.cod_encuesta=b.cod_encuesta " & _
                           " inner join mov_encuesta_resultado_detalle_alternativa c on a.empresa=c.empresa and a.cod_encuesta=c.cod_encuesta " & _
                           " and b.cod_resultado=c.cod_resultado " & _
                           " and a.usuario=b.usuario_grabo " & _
                           " where a.equipo='" & Me.cmb_equipo.Text & "' and a.empresa='dmarte1' and a.cod_encuesta=6 " & _
                           " and a.cod_grupo=" & dr2.Item("cod_grupo") & " and c.cod_pregunta=" & dr3.Item("cod_pregunta") & " " & _
                           " group by c.cod_alternativa " & _
                           " order by c.cod_alternativa asc "
                            dt_resultados = otrans.Obtiene(ls_sql)
                            Try
                                If dt_resultados.Rows.Count > 0 Then

                                    Try
                                        hoja3.Cells(ay + ax - 1, 4) = dt_resultados.Rows(0).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 4) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(ay + ax - 1, 5) = dt_resultados.Rows(1).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 5) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(ay + ax - 1, 6) = dt_resultados.Rows(2).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 6) = 0
                                    End Try
                                Else
                                    hoja3.Cells(ay + ax - 1, 4) = 0
                                    hoja3.Cells(ay + ax - 1, 5) = 0
                                    hoja3.Cells(ay + ax - 1, 6) = 0
                                End If
                            Catch ex As Exception

                            End Try


                        End If

                    Next
                    icont += dt_preguntas.Rows.Count
                Else
                    'cada pregunta por subtitulo
                    hoja3.Cells(icont + 2, 2) = dr2.Item("descripcion")


                    myrange = "B" & icont + 2 & ":B" & icont + 2 & ""
                    hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                    hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify
                    hoja3.Range(myrange).Orientation = 0
                    hoja3.Range(myrange).AddIndent = False
                    hoja3.Range(myrange).IndentLevel = 0
                    hoja3.Range(myrange).ShrinkToFit = False
                    hoja3.Range(myrange).Font.Size = 10
                    hoja3.Range(myrange).Font.ColorIndex = 1
                    hoja3.Range(myrange).Font.Bold = True
                    hoja3.Range("B" & icont + 2 & ":B" & icont + 2 & "").ColumnWidth = 60
                    iconta += 1



                    ls_sql = " SELECT cod_pregunta, convert(cast(`descripcion` as char charset binary) using utf8) AS `descripcion` FROM mov_encuesta_modelo_detalle  " & _
                           " where empresa='dmarte1' and cod_encuesta=6 " & _
                           " and cod_tipo_respuesta=1 and cod_grupo_encuesta=" & dr2.Item("cod_grupo") & " order by cod_pregunta asc "
                    dt_preguntas = otrans.Obtiene(ls_sql)

                    Dim ax As Integer = 0
                    Dim ay As Integer = 0
                    For Each dr3 As DataRow In dt_preguntas.Rows
                        ax += 1
                        If ax = 1 Then
                            hoja3.Cells(icont + 3, 2) = dr3.Item("descripcion")
                            myrange = "B" & icont + 3 & ":B" & icont + 3 & ""
                            hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                            hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify
                            ay = icont + 3
                            ls_sql = "SELECT count(c.cod_alternativa)as conteo,c.cod_alternativa FROM seg_usuario_evaluacion_mk a " & _
                           " inner join mov_encuesta_resultado_encabezado b on a.empresa=b.empresa and a.cod_encuesta=b.cod_encuesta " & _
                           " inner join mov_encuesta_resultado_detalle_alternativa c on a.empresa=c.empresa and a.cod_encuesta=c.cod_encuesta " & _
                           " and b.cod_resultado=c.cod_resultado " & _
                           " and a.usuario=b.usuario_grabo " & _
                           " where a.equipo='" & Me.cmb_equipo.Text & "' and a.empresa='dmarte1' and a.cod_encuesta=6 " & _
                           " and a.cod_grupo=" & dr2.Item("cod_grupo") & " and c.cod_pregunta=" & dr3.Item("cod_pregunta") & " " & _
                           " group by c.cod_alternativa " & _
                           " order by c.cod_alternativa asc "
                            dt_resultados = otrans.Obtiene(ls_sql)
                            Try
                                If dt_resultados.Rows.Count > 0 Then

                                    Try
                                        hoja3.Cells(icont + 3, 4) = dt_resultados.Rows(0).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 4) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(icont + 3, 5) = dt_resultados.Rows(1).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 5) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(icont + 3, 6) = dt_resultados.Rows(2).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(icont + 3, 6) = 0
                                    End Try
                                Else
                                    hoja3.Cells(icont + 3, 4) = 0
                                    hoja3.Cells(icont + 3, 5) = 0
                                    hoja3.Cells(icont + 3, 6) = 0
                                End If
                            Catch ex As Exception

                            End Try

                        Else
                            hoja3.Cells(ay + ax - 1, 2) = dr3.Item("descripcion")

                            myrange = "B" & ay + ax - 1 & ":B" & ay + ax - 1 & ""
                            hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify
                            hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignJustify

                            ls_sql = "SELECT count(c.cod_alternativa)as conteo,c.cod_alternativa FROM seg_usuario_evaluacion_mk a " & _
                           " inner join mov_encuesta_resultado_encabezado b on a.empresa=b.empresa and a.cod_encuesta=b.cod_encuesta " & _
                           " inner join mov_encuesta_resultado_detalle_alternativa c on a.empresa=c.empresa and a.cod_encuesta=c.cod_encuesta " & _
                           " and b.cod_resultado=c.cod_resultado " & _
                           " and a.usuario=b.usuario_grabo " & _
                           " where a.equipo='" & Me.cmb_equipo.Text & "' and a.empresa='dmarte1' and a.cod_encuesta=6 " & _
                           " and a.cod_grupo=" & dr2.Item("cod_grupo") & " and c.cod_pregunta=" & dr3.Item("cod_pregunta") & " " & _
                           " group by c.cod_alternativa " & _
                           " order by c.cod_alternativa asc "
                            dt_resultados = otrans.Obtiene(ls_sql)
                            Try
                                If dt_resultados.Rows.Count > 0 Then

                                    Try
                                        hoja3.Cells(ay + ax - 1, 4) = dt_resultados.Rows(0).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 4) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(ay + ax - 1, 5) = dt_resultados.Rows(1).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 5) = 0
                                    End Try
                                    Try
                                        hoja3.Cells(ay + ax - 1, 6) = dt_resultados.Rows(2).Item("conteo")
                                    Catch ex As Exception
                                        hoja3.Cells(ay + ax - 1, 6) = 0
                                    End Try
                                Else
                                    hoja3.Cells(ay + ax - 1, 4) = 0
                                    hoja3.Cells(ay + ax - 1, 5) = 0
                                    hoja3.Cells(ay + ax - 1, 6) = 0
                                End If
                            Catch ex As Exception

                            End Try


                        End If

                    Next
                    icont += dt_preguntas.Rows.Count

                End If

              


            Next
            iconta = 0



        Next




        myrange = "B1:B1"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).WrapText = False
        hoja3.Range(myrange).Orientation = 0
        hoja3.Range(myrange).AddIndent = False
        hoja3.Range(myrange).IndentLevel = 0
        hoja3.Range(myrange).ShrinkToFit = False
        hoja3.Range(myrange).MergeCells = True
        hoja3.Range(myrange).Font.Size = 12
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Range("B1:B1").ColumnWidth = 60

        ' hoja3.Cells(5, 4) = "NIVEL 1"
        hoja3.Cells(7, 4) = "SCORE CARD"


        hoja3.Cells(8, 4) = "0"
        hoja3.Cells(8, 5) = "0.5"
        hoja3.Cells(8, 6) = "1"



        'myrange = "D5:F5"
        '' hoja2.Range(myrange).Interior.ColorIndex = 49
        'hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        'hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja3.Range(myrange).WrapText = False
        'hoja3.Range(myrange).Orientation = 0
        'hoja3.Range(myrange).AddIndent = False
        'hoja3.Range(myrange).IndentLevel = 0
        'hoja3.Range(myrange).ShrinkToFit = False
        'hoja3.Range(myrange).MergeCells = True
        'hoja3.Range(myrange).Font.Size = 12
        'hoja3.Range(myrange).Font.ColorIndex = 1
        'hoja3.Range(myrange).Font.Bold = True
        'hoja3.Range("D5:F5").ColumnWidth = 60


        myrange = "D7:F7"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).WrapText = False
        hoja3.Range(myrange).Orientation = 0
        hoja3.Range(myrange).AddIndent = False
        hoja3.Range(myrange).IndentLevel = 0
        hoja3.Range(myrange).ShrinkToFit = False
        hoja3.Range(myrange).MergeCells = True
        hoja3.Range(myrange).Font.Size = 12
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Range("D7:F7").ColumnWidth = 60



        myrange = "D8:D8"
        hoja3.Range(myrange).Interior.ColorIndex = 44
        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).WrapText = False
        hoja3.Range(myrange).Orientation = 0
        hoja3.Range(myrange).AddIndent = False
        hoja3.Range(myrange).IndentLevel = 0
        hoja3.Range(myrange).ShrinkToFit = False
        hoja3.Range(myrange).MergeCells = False
        hoja3.Range(myrange).Font.Size = 9
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Range("D8:D8").ColumnWidth = 5


        myrange = "E8:E8"
        hoja3.Range(myrange).Interior.ColorIndex = 36
        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).WrapText = False
        hoja3.Range(myrange).Orientation = 0
        hoja3.Range(myrange).AddIndent = False
        hoja3.Range(myrange).IndentLevel = 0
        hoja3.Range(myrange).ShrinkToFit = False
        hoja3.Range(myrange).MergeCells = False
        hoja3.Range(myrange).Font.Size = 9
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Range("E8:E8").ColumnWidth = 5


        myrange = "F8:F8"
        hoja3.Range(myrange).Interior.ColorIndex = 43
        hoja3.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja3.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja3.Range(myrange).WrapText = False
        hoja3.Range(myrange).Orientation = 0
        hoja3.Range(myrange).AddIndent = False
        hoja3.Range(myrange).IndentLevel = 0
        hoja3.Range(myrange).ShrinkToFit = False
        hoja3.Range(myrange).MergeCells = False
        hoja3.Range(myrange).Font.Size = 9
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Range("F8:F8").ColumnWidth = 5


        myrange = "B4:B5"
        'hoja.Range(myrange).Interior.ColorIndex = 37
        ' hoja4.Range(myrange).Interior.ColorIndex = 49
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
        hoja3.Range(myrange).Font.ColorIndex = 1
        hoja3.Range(myrange).Font.Bold = True
        hoja3.Cells(4, 2) = "Estándares de Excelencia Herramienta de evaluación PFG"

        Oaut._xlDibujar_Bordes(hoja3, "B4:B5")
        Oaut._xlDibujar_Bordes(hoja3, "B7:B8")
        'Oaut._xlDibujar_Bordes(hoja3, "B16:B17")
        'Oaut._xlDibujar_Bordes(hoja3, "B29:B30")
        'Oaut._xlDibujar_Bordes(hoja3, "B38:B39")
        'Oaut._xlDibujar_Bordes(hoja3, "B52:B53")
        ' Oaut._xlDibujar_Bordes(hoja3, "D5:F5")
        '  Oaut._xlDibujar_Borde    s(hoja3, "H5:J5")
        '  Oaut._xlDibujar_Bordes(hoja3, "L5:N5")
        ' Oaut._xlDibujar_Bordes(hoja3, "P5:R5")
        Oaut._xlDibujar_Bordes(hoja3, "D7:F7")
        '  Oaut._xlDibujar_Bordes(hoja3, "H7:J7")
        'Oaut._xlDibujar_Bordes(hoja3, "L7:N7")
        '  Oaut._xlDibujar_Bordes(hoja3, "P7:R7")



        '-------------------------------------------------------------------------------------------------------------
        '------------------------------------------------FINALIZACION DE HOJA NO.3------------------------------------


      
        myrange = "B1:B1"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B1:B1").ColumnWidth = 60

        hoja2.Cells(5, 4) = "NIVEL 1"
        hoja2.Cells(7, 4) = "SCORE CARD"
        hoja2.Cells(5, 8) = "NIVEL 2"
        hoja2.Cells(7, 8) = "SCORE CARD"
        hoja2.Cells(5, 12) = "NIVEL 3"
        hoja2.Cells(7, 12) = "SCORE CARD"
        hoja2.Cells(5, 16) = "NIVEL 4"
        hoja2.Cells(7, 16) = "SCORE CARD"
        hoja2.Cells(8, 4) = "0"
        hoja2.Cells(8, 5) = "0.5"
        hoja2.Cells(8, 6) = "1"


        hoja2.Cells(8, 8) = "0"
        hoja2.Cells(8, 9) = "0.5"
        hoja2.Cells(8, 10) = "1"

        hoja2.Cells(8, 12) = "0"
        hoja2.Cells(8, 13) = "0.5"
        hoja2.Cells(8, 14) = "1"

        hoja2.Cells(8, 16) = "0"
        hoja2.Cells(8, 17) = "0.5"
        hoja2.Cells(8, 18) = "1"

        hoja2.Cells(8, 2) = "I.Entendimiento de la oportunidad comercial"
        hoja2.Cells(9, 2) = "Conocimiento del mercado y la competencia"
        hoja2.Cells(10, 2) = "Conocimiento de marca y categoría"
        hoja2.Cells(11, 2) = "Entendimiento del consumidor e insights"
        hoja2.Cells(12, 2) = "Entendimiento del cliente e insights"
        hoja2.Cells(13, 2) = "Entendimiento del comprador e insights"
        hoja2.Cells(14, 2) = "Universo de clientes y segmentación"



        hoja2.Cells(16, 2) = "II.Desarrollo de la estrategia y ejecución del plan"
        hoja2.Cells(18, 2) = "Desarrollar Estrategia Comercial y Planificación (JUBP)"
        hoja2.Cells(19, 2) = "Desarrollar estrategia de inversión en el trade"
        hoja2.Cells(20, 2) = "GAME Plans"
        hoja2.Cells(21, 2) = "Customer Marketing"
        hoja2.Cells(22, 2) = "Definición de estrategia de contacto y cubrimiento"
        hoja2.Cells(23, 2) = "Estructura de la fuera de ventas"
        hoja2.Cells(24, 2) = "Estructura de mercadeo"
        hoja2.Cells(25, 2) = "Colaboración con el cliente"
        hoja2.Cells(26, 2) = "Desarrollar ofertas ganadoras para el cliente (JCP)"
        hoja2.Cells(27, 2) = "S&OP: Planeación y Forecast"




        hoja2.Cells(30, 2) = "III.Ejecución"
        hoja2.Cells(31, 2) = "Activación y Ejecución"
        hoja2.Cells(32, 2) = "Visita Estructurada"
        hoja2.Cells(33, 2) = "Administración de las redes de comunicación y relaciones en el trade"
        hoja2.Cells(34, 2) = "Servicio al cliente y recaudo de efectivo"
        hoja2.Cells(35, 2) = "Excelencia de mercadeo en la ejecución"
        hoja2.Cells(36, 2) = "Licencia para vender"




        hoja2.Cells(39, 2) = "IV.Administración del desempeño"
        hoja2.Cells(40, 2) = "Revisión de negocio (interna/externa)"
        hoja2.Cells(41, 2) = "Contratos, términos y cumplimiento"
        hoja2.Cells(42, 2) = "Perspicacia comercial"
        hoja2.Cells(43, 2) = "Perspicacia en mercadeo de marca"
        hoja2.Cells(44, 2) = "Administración de agencias"
        hoja2.Cells(45, 2) = "Creación de valor y colaboración en la cadena de suministro"
        hoja2.Cells(46, 2) = "Logística y almacenaje"
        hoja2.Cells(47, 2) = "Gobernabilidad y procesos"
        hoja2.Cells(48, 2) = "Recompensa y reconocimiento"
        hoja2.Cells(49, 2) = "Coaching"
        hoja2.Cells(50, 2) = "Inducción de reclutamiento  y gestión del talento"



        hoja2.Cells(53, 2) = "V.Medir y evaluar"
        hoja2.Cells(54, 2) = "Información de ventas y datos"
        hoja2.Cells(55, 2) = "Revisión total de inversión en el trade"
        hoja2.Cells(56, 2) = "Mejoramiento continuo"
        hoja2.Cells(57, 2) = "Evaluación de imagen y salud de la marca"
        hoja2.Cells(58, 2) = "Revisión de inversión de mercadeo"
        hoja2.Cells(59, 2) = "Seguridad y Salud"
        hoja2.Cells(60, 2) = "Revisión de la estructura organizacional y gestión del talento"


        'TITULOS Y COLORES

        myrange = "D7:F7"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("D7:F7").ColumnWidth = 60


        myrange = "H7:J7"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("H7:J7").ColumnWidth = 60



        myrange = "L7:N7"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("L7:N7").ColumnWidth = 60


        myrange = "P7:R7"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("P7:R7").ColumnWidth = 60




        myrange = "D5:F5"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("D5:F5").ColumnWidth = 60



        myrange = "H5:J5"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("H5:J5").ColumnWidth = 60


        myrange = "L5:N5"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("L5:N5").ColumnWidth = 60


        myrange = "P5:R5"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("P5:R5").ColumnWidth = 60
        'FIN DE TITULOS Y COLORES







        'TITULOS

        myrange = "B7:B8"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B7:B8").ColumnWidth = 60






        myrange = "B16:B17"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B16:B17").ColumnWidth = 60


        myrange = "B29:B30"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B29:B30").ColumnWidth = 60



        myrange = "B38:B39"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B38:B39").ColumnWidth = 60




        myrange = "B52:B53"
        ' hoja2.Range(myrange).Interior.ColorIndex = 49
        hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja2.Range(myrange).WrapText = False
        hoja2.Range(myrange).Orientation = 0
        hoja2.Range(myrange).AddIndent = False
        hoja2.Range(myrange).IndentLevel = 0
        hoja2.Range(myrange).ShrinkToFit = False
        hoja2.Range(myrange).MergeCells = True
        hoja2.Range(myrange).Font.Size = 12
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Range("B52:B53").ColumnWidth = 60



        'myrange = "B7:B7"
        'hoja2.Range(myrange).Interior.ColorIndex = 49
        'hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        'hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja2.Range(myrange).WrapText = False
        'hoja2.Range(myrange).Orientation = 0
        'hoja2.Range(myrange).AddIndent = False
        'hoja2.Range(myrange).IndentLevel = 0
        'hoja2.Range(myrange).ShrinkToFit = False
        'hoja2.Range(myrange).MergeCells = False
        'hoja2.Range(myrange).Font.Size = 9
        'hoja2.Range(myrange).Font.ColorIndex = 2
        'hoja2.Range(myrange).Font.Bold = True
        'hoja2.Range("B7:B7").ColumnWidth = 60


        'myrange = "C7:C7"
        'hoja2.Range(myrange).Interior.ColorIndex = 3
        'hoja2.Range(myrange).Interior.Pattern = Excel.XlPattern.xlPatternSolid
        'hoja2.Range(myrange).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja2.Range(myrange).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
        'hoja2.Range(myrange).WrapText = False
        'hoja2.Range(myrange).Orientation = 0
        'hoja2.Range(myrange).AddIndent = False
        'hoja2.Range(myrange).IndentLevel = 0
        'hoja2.Range(myrange).ShrinkToFit = False
        'hoja2.Range(myrange).MergeCells = False
        'hoja2.Range(myrange).Font.Size = 9
        'hoja2.Range(myrange).Font.ColorIndex = 1
        'hoja2.Range(myrange).Font.Bold = True
        'hoja2.Range("C7:C7").ColumnWidth = 15

        myrange = "D8:D8"
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
        hoja2.Range("D8:D8").ColumnWidth = 5


        myrange = "E8:E8"
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
        hoja2.Range("E8:E8").ColumnWidth = 5


        myrange = "F8:F8"
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
        hoja2.Range("F8:F8").ColumnWidth = 5









        'OZZ
        myrange = "H8:H8"
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
        hoja2.Range("H8:H8").ColumnWidth = 5


        myrange = "I8:I8"
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
        hoja2.Range("I8:I8").ColumnWidth = 5


        myrange = "J8:J8"
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
        hoja2.Range("J8:J8").ColumnWidth = 5
        'FIN OZZ




        'OZZ2
        myrange = "L8:L8"
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
        hoja2.Range("L8:L8").ColumnWidth = 5


        myrange = "M8:M8"
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
        hoja2.Range("M8:M8").ColumnWidth = 5


        myrange = "N8:N8"
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
        hoja2.Range("N8:N8").ColumnWidth = 5
        'FIN OZZ2




        'OZZ3
        myrange = "P8:P8"
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
        hoja2.Range("P8:P8").ColumnWidth = 5


        myrange = "Q8:Q8"
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
        hoja2.Range("Q8:Q8").ColumnWidth = 5


        myrange = "R8:R8"
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
        hoja2.Range("R8:R8").ColumnWidth = 5
        'FIN OZZ3




        myrange = "B4:B5"
        'hoja.Range(myrange).Interior.ColorIndex = 37
        ' hoja4.Range(myrange).Interior.ColorIndex = 49
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
        hoja2.Range(myrange).Font.ColorIndex = 1
        hoja2.Range(myrange).Font.Bold = True
        hoja2.Cells(4, 2) = "Estándares de Excelencia Herramienta de evaluación PFG"

        '  mExcel.Visible = True


        ''GENERAR INFORMACION
        Oaut._xlDibujar_Bordes(hoja2, "B4:B5")
        Oaut._xlDibujar_Bordes(hoja2, "B7:B8")
        Oaut._xlDibujar_Bordes(hoja2, "B16:B17")
        Oaut._xlDibujar_Bordes(hoja2, "B29:B30")
        Oaut._xlDibujar_Bordes(hoja2, "B38:B39")
        Oaut._xlDibujar_Bordes(hoja2, "B52:B53")
        Oaut._xlDibujar_Bordes(hoja2, "D5:F5")
        Oaut._xlDibujar_Bordes(hoja2, "H5:J5")
        Oaut._xlDibujar_Bordes(hoja2, "L5:N5")
        Oaut._xlDibujar_Bordes(hoja2, "P5:R5")
        Oaut._xlDibujar_Bordes(hoja2, "D7:F7")
        Oaut._xlDibujar_Bordes(hoja2, "H7:J7")
        Oaut._xlDibujar_Bordes(hoja2, "L7:N7")
        Oaut._xlDibujar_Bordes(hoja2, "P7:R7")


        Try

            Dim dt2, dt3 As DataTable
            Dim p1a, p1b, p1c, p2a, p2b, p2c, p3a, p3b, p3c, p4a, p4b, p4c As Integer

            If Ods.Tables.Contains("solicitantes") Then
                Ods.Tables.Remove("solicitantes")
            End If
            ls_sql = "SELECT * FROM seg_usuario_evaluacion_mk Where equipo ='" & Me.cmb_equipo.Text & "'"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "solicitantes"
            Ods.Tables.Add(dt.Copy)

            '------------------------------GRUPO NO.1-----------------------------------------
            Dim dw As DataTable
            'Dim broma As Integer = 0
            'Dim silvia As String

            For i As Integer = 1 To 40

                Ods.Tables("solicitantes").DefaultView.RowFilter = "cod_grupo = " & i
                dw = Ods.Tables("solicitantes").DefaultView.ToTable

                ls_sql = "SELECT * FROM mov_encuesta_modelo_detalle where empresa='DMARTE1' and cod_encuesta=6 and cod_grupo_encuesta=" & i & " and cod_tipo_respuesta=2 order by cod_grupo_encuesta,cod_pregunta asc"
                dt2 = otrans.Obtiene(ls_sql)

                For Each dr2 As DataRow In dt2.Rows




                    For Each dr1 As DataRow In dw.Rows
                        ls_sql = "SELECT * FROM mov_encuesta_resultado_detalle_alternativa a " & _
                         " inner join mov_encuesta_resultado_encabezado b on a.cod_encuesta=b.cod_encuesta and" & _
                        " a.cod_resultado = b.cod_resultado And a.empresa = b.empresa And b.cod_tipo_encuesta = 2" & _
                        " where a.cod_encuesta and a.empresa='DMARTE1' and a.cod_tipo_encuesta=2" & _
                        " and a.cod_pregunta=" & dr2.Item("cod_pregunta") & _
                        " and b.usuario_grabo='" & dr1.Item("usuario") & "'"
                        dt3 = otrans.Obtiene(ls_sql)
                        If dt3.Rows.Count > 0 Then
                            '--inicio de grupo 1
                            'broma += 1
                            'silvia = silvia & "|" & dt3.Rows(0).Item("cod_resultado")

                            If dr2.Item("cod_grupo_encuesta") = 1 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 13 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 14 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 15 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If


                                If dt3.Rows(0).Item("cod_pregunta") = 16 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If


                            End If
                            '--fin  de grupo 1



                            '--inicio de grupo encuesta 2
                            If dr2.Item("cod_grupo_encuesta") = 2 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 29 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 30 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 31 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 32 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 2



                            '--inicio de grupo encuesta 3
                            If dr2.Item("cod_grupo_encuesta") = 3 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 45 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 46 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 47 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 48 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 3




                            '--inicio de grupo encuesta 4
                            If dr2.Item("cod_grupo_encuesta") = 4 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 59 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 60 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 61 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 62 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 4



                            '--inicio de grupo encuesta 5
                            If dr2.Item("cod_grupo_encuesta") = 5 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 75 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 76 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 77 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 581 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 5


                            '--inicio de grupo encuesta 6
                            If dr2.Item("cod_grupo_encuesta") = 6 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 86 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 87 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 88 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 89 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 6






                            '--inicio de grupo encuesta 7
                            If dr2.Item("cod_grupo_encuesta") = 7 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 102 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 103 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 104 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 105 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 7




                            '--inicio de grupo encuesta 8
                            If dr2.Item("cod_grupo_encuesta") = 8 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 124 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 125 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 126 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 127 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 8





                            '--inicio de grupo encuesta 9
                            If dr2.Item("cod_grupo_encuesta") = 9 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 140 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 141 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 142 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 143 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 9



                            '--inicio de grupo encuesta 10
                            If dr2.Item("cod_grupo_encuesta") = 10 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 156 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 157 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 158 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 159 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 10



                            '--inicio de grupo encuesta 11
                            If dr2.Item("cod_grupo_encuesta") = 11 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 173 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 174 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 175 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 176 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 11





                            '--inicio de grupo encuesta 12
                            If dr2.Item("cod_grupo_encuesta") = 12 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 183 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 184 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 185 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 578 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 12



                            '--inicio de grupo encuesta 13
                            If dr2.Item("cod_grupo_encuesta") = 13 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 192 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 193 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 194 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 195 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 13






                            '--inicio de grupo encuesta 14
                            If dr2.Item("cod_grupo_encuesta") = 14 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 205 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 206 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 207 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 208 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 14




                            '--inicio de grupo encuesta 15
                            If dr2.Item("cod_grupo_encuesta") = 15 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 223 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 224 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 225 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 226 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 15





                            '--inicio de grupo encuesta 16
                            If dr2.Item("cod_grupo_encuesta") = 16 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 235 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 236 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 237 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 238 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 16




                            '--inicio de grupo encuesta 17
                            If dr2.Item("cod_grupo_encuesta") = 17 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 249 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 250 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 251 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 252 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 17






                            '--inicio de grupo encuesta 18
                            If dr2.Item("cod_grupo_encuesta") = 18 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 270 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 271 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 272 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 273 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 18

                            '--inicio de grupo encuesta 19
                            If dr2.Item("cod_grupo_encuesta") = 19 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 290 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 291 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 292 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 293 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 19


                            '--inicio de grupo encuesta 20
                            If dr2.Item("cod_grupo_encuesta") = 20 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 304 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 305 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 306 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 307 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 20


                            '--inicio de grupo encuesta 21
                            If dr2.Item("cod_grupo_encuesta") = 21 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 316 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 317 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 318 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 319 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 21

                            '--inicio de grupo encuesta 22
                            If dr2.Item("cod_grupo_encuesta") = 22 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 326 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 327 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 328 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 329 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 22

                            '--inicio de grupo encuesta 23
                            If dr2.Item("cod_grupo_encuesta") = 23 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 340 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 341 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 342 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 579 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 23

                            '--inicio de grupo encuesta 24
                            If dr2.Item("cod_grupo_encuesta") = 24 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 355 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 356 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 357 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 358 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 24




                            '--inicio de grupo encuesta 25
                            If dr2.Item("cod_grupo_encuesta") = 25 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 369 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 370 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 371 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 372 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 25


                            '--inicio de grupo encuesta 26
                            If dr2.Item("cod_grupo_encuesta") = 26 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 385 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 386 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 387 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 388 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 26


                            '--inicio de grupo encuesta 27
                            If dr2.Item("cod_grupo_encuesta") = 27 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 401 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 402 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 403 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 404 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 27


                            '--inicio de grupo encuesta 28
                            If dr2.Item("cod_grupo_encuesta") = 28 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 413 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 414 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 415 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 416 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 28



                            '--inicio de grupo encuesta 29
                            If dr2.Item("cod_grupo_encuesta") = 29 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 427 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 428 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 429 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 580 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 29



                            '--inicio de grupo encuesta 30
                            If dr2.Item("cod_grupo_encuesta") = 30 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 441 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 442 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 443 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 444 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 30


                            '--inicio de grupo encuesta 31
                            If dr2.Item("cod_grupo_encuesta") = 31 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 455 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 456 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 457 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 458 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 31


                            '--inicio de grupo encuesta 32
                            If dr2.Item("cod_grupo_encuesta") = 32 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 473 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 474 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 475 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 476 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 32


                            '--inicio de grupo encuesta 33
                            If dr2.Item("cod_grupo_encuesta") = 33 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 487 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 488 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 489 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 490 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 33


                            '--inicio de grupo encuesta 34
                            If dr2.Item("cod_grupo_encuesta") = 34 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 497 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 498 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 499 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 500 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 34


                            '--inicio de grupo encuesta 35
                            If dr2.Item("cod_grupo_encuesta") = 35 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 511 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 512 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 513 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 514 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 35


                            '--inicio de grupo encuesta 36
                            If dr2.Item("cod_grupo_encuesta") = 36 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 526 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 527 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 528 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 529 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 36



                            '--inicio de grupo encuesta 37
                            If dr2.Item("cod_grupo_encuesta") = 37 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 536 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 537 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 538 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 539 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 37


                            '--inicio de grupo encuesta 38
                            If dr2.Item("cod_grupo_encuesta") = 38 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 550 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 551 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 552 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 553 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 38


                            '--inicio de grupo encuesta 39
                            If dr2.Item("cod_grupo_encuesta") = 39 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 564 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 565 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 566 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 567 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 39


                            '--inicio de grupo encuesta 40
                            If dr2.Item("cod_grupo_encuesta") = 40 Then


                                If dt3.Rows(0).Item("cod_pregunta") = 574 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p1a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p1b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p1c += 1
                                    End If

                                End If



                                If dt3.Rows(0).Item("cod_pregunta") = 575 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p2a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p2b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p2c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 576 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p3a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p3b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p3c += 1
                                    End If

                                End If

                                If dt3.Rows(0).Item("cod_pregunta") = 577 Then
                                    If dt3.Rows(0).Item("cod_alternativa") = 1 Then
                                        p4a += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 2 Then
                                        p4b += 1
                                    ElseIf dt3.Rows(0).Item("cod_alternativa") = 3 Then
                                        p4c += 1
                                    End If

                                End If
                            End If
                            '--fin  grupo encuesta 40

























                        End If


                    Next
                    If dr2.Item("cod_grupo_encuesta") = 1 And dr2.Item("cod_pregunta") = 13 Then
                        hoja2.Cells(9, 4) = p1a
                        hoja2.Cells(9, 5) = p1b
                        hoja2.Cells(9, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 1 And dr2.Item("cod_pregunta") = 14 Then
                        hoja2.Cells(9, 8) = p2a
                        hoja2.Cells(9, 9) = p2b
                        hoja2.Cells(9, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 1 And dr2.Item("cod_pregunta") = 15 Then
                        hoja2.Cells(9, 12) = p3a
                        hoja2.Cells(9, 13) = p3b
                        hoja2.Cells(9, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 1 And dr2.Item("cod_pregunta") = 16 Then
                        hoja2.Cells(9, 16) = p4a
                        hoja2.Cells(9, 17) = p4b
                        hoja2.Cells(9, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 2 And dr2.Item("cod_pregunta") = 29 Then
                        hoja2.Cells(10, 4) = p1a
                        hoja2.Cells(10, 5) = p1b
                        hoja2.Cells(10, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 2 And dr2.Item("cod_pregunta") = 30 Then
                        hoja2.Cells(10, 8) = p2a
                        hoja2.Cells(10, 9) = p2b
                        hoja2.Cells(10, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 2 And dr2.Item("cod_pregunta") = 31 Then
                        hoja2.Cells(10, 12) = p3a
                        hoja2.Cells(10, 13) = p3b
                        hoja2.Cells(10, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 2 And dr2.Item("cod_pregunta") = 32 Then
                        hoja2.Cells(10, 16) = p4a
                        hoja2.Cells(10, 17) = p4b
                        hoja2.Cells(10, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 3 And dr2.Item("cod_pregunta") = 45 Then
                        hoja2.Cells(11, 4) = p1a
                        hoja2.Cells(11, 5) = p1b
                        hoja2.Cells(11, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 3 And dr2.Item("cod_pregunta") = 46 Then
                        hoja2.Cells(11, 8) = p2a
                        hoja2.Cells(11, 9) = p2b
                        hoja2.Cells(11, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 3 And dr2.Item("cod_pregunta") = 47 Then
                        hoja2.Cells(11, 12) = p3a
                        hoja2.Cells(11, 13) = p3b
                        hoja2.Cells(11, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 3 And dr2.Item("cod_pregunta") = 48 Then
                        hoja2.Cells(11, 16) = p4a
                        hoja2.Cells(11, 17) = p4b
                        hoja2.Cells(11, 18) = p4c

                    End If




                    If dr2.Item("cod_grupo_encuesta") = 4 And dr2.Item("cod_pregunta") = 59 Then
                        hoja2.Cells(12, 4) = p1a
                        hoja2.Cells(12, 5) = p1b
                        hoja2.Cells(12, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 4 And dr2.Item("cod_pregunta") = 60 Then
                        hoja2.Cells(12, 8) = p2a
                        hoja2.Cells(12, 9) = p2b
                        hoja2.Cells(12, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 4 And dr2.Item("cod_pregunta") = 61 Then
                        hoja2.Cells(12, 12) = p3a
                        hoja2.Cells(12, 13) = p3b
                        hoja2.Cells(12, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 4 And dr2.Item("cod_pregunta") = 62 Then
                        hoja2.Cells(12, 16) = p4a
                        hoja2.Cells(12, 17) = p4b
                        hoja2.Cells(12, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 5 And dr2.Item("cod_pregunta") = 75 Then
                        hoja2.Cells(13, 4) = p1a
                        hoja2.Cells(13, 5) = p1b
                        hoja2.Cells(13, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 5 And dr2.Item("cod_pregunta") = 76 Then
                        hoja2.Cells(13, 8) = p2a
                        hoja2.Cells(13, 9) = p2b
                        hoja2.Cells(13, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 5 And dr2.Item("cod_pregunta") = 77 Then
                        hoja2.Cells(13, 12) = p3a
                        hoja2.Cells(13, 13) = p3b
                        hoja2.Cells(13, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 5 And dr2.Item("cod_pregunta") = 581 Then
                        hoja2.Cells(13, 16) = p4a
                        hoja2.Cells(13, 17) = p4b
                        hoja2.Cells(13, 18) = p4c

                    End If




                    If dr2.Item("cod_grupo_encuesta") = 6 And dr2.Item("cod_pregunta") = 86 Then
                        hoja2.Cells(14, 4) = p1a
                        hoja2.Cells(14, 5) = p1b
                        hoja2.Cells(14, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 6 And dr2.Item("cod_pregunta") = 87 Then
                        hoja2.Cells(14, 8) = p2a
                        hoja2.Cells(14, 9) = p2b
                        hoja2.Cells(14, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 6 And dr2.Item("cod_pregunta") = 88 Then
                        hoja2.Cells(14, 12) = p3a
                        hoja2.Cells(14, 13) = p3b
                        hoja2.Cells(14, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 6 And dr2.Item("cod_pregunta") = 89 Then
                        hoja2.Cells(14, 16) = p4a
                        hoja2.Cells(14, 17) = p4b
                        hoja2.Cells(14, 18) = p4c

                    End If








                    If dr2.Item("cod_grupo_encuesta") = 7 And dr2.Item("cod_pregunta") = 102 Then
                        hoja2.Cells(18, 4) = p1a
                        hoja2.Cells(18, 5) = p1b
                        hoja2.Cells(18, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 7 And dr2.Item("cod_pregunta") = 103 Then
                        hoja2.Cells(18, 8) = p2a
                        hoja2.Cells(18, 9) = p2b
                        hoja2.Cells(18, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 7 And dr2.Item("cod_pregunta") = 104 Then
                        hoja2.Cells(18, 12) = p3a
                        hoja2.Cells(18, 13) = p3b
                        hoja2.Cells(18, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 7 And dr2.Item("cod_pregunta") = 105 Then
                        hoja2.Cells(18, 16) = p4a
                        hoja2.Cells(18, 17) = p4b
                        hoja2.Cells(18, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 8 And dr2.Item("cod_pregunta") = 124 Then
                        hoja2.Cells(19, 4) = p1a
                        hoja2.Cells(19, 5) = p1b
                        hoja2.Cells(19, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 8 And dr2.Item("cod_pregunta") = 125 Then
                        hoja2.Cells(19, 8) = p2a
                        hoja2.Cells(19, 9) = p2b
                        hoja2.Cells(19, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 8 And dr2.Item("cod_pregunta") = 126 Then
                        hoja2.Cells(19, 12) = p3a
                        hoja2.Cells(19, 13) = p3b
                        hoja2.Cells(19, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 8 And dr2.Item("cod_pregunta") = 127 Then
                        hoja2.Cells(19, 16) = p4a
                        hoja2.Cells(19, 17) = p4b
                        hoja2.Cells(19, 18) = p4c
                    End If


                    If dr2.Item("cod_grupo_encuesta") = 9 And dr2.Item("cod_pregunta") = 140 Then
                        hoja2.Cells(20, 4) = p1a
                        hoja2.Cells(20, 5) = p1b
                        hoja2.Cells(20, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 9 And dr2.Item("cod_pregunta") = 141 Then
                        hoja2.Cells(20, 8) = p2a
                        hoja2.Cells(20, 9) = p2b
                        hoja2.Cells(20, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 9 And dr2.Item("cod_pregunta") = 142 Then
                        hoja2.Cells(20, 12) = p3a
                        hoja2.Cells(20, 13) = p3b
                        hoja2.Cells(20, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 9 And dr2.Item("cod_pregunta") = 143 Then
                        hoja2.Cells(20, 16) = p4a
                        hoja2.Cells(20, 17) = p4b
                        hoja2.Cells(20, 18) = p4c

                    End If




                    If dr2.Item("cod_grupo_encuesta") = 10 And dr2.Item("cod_pregunta") = 156 Then
                        hoja2.Cells(21, 4) = p1a
                        hoja2.Cells(21, 5) = p1b
                        hoja2.Cells(21, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 10 And dr2.Item("cod_pregunta") = 157 Then
                        hoja2.Cells(21, 8) = p2a
                        hoja2.Cells(21, 9) = p2b
                        hoja2.Cells(21, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 10 And dr2.Item("cod_pregunta") = 158 Then
                        hoja2.Cells(21, 12) = p3a
                        hoja2.Cells(21, 13) = p3b
                        hoja2.Cells(21, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 10 And dr2.Item("cod_pregunta") = 159 Then
                        hoja2.Cells(21, 16) = p4a
                        hoja2.Cells(21, 17) = p4b
                        hoja2.Cells(21, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 11 And dr2.Item("cod_pregunta") = 173 Then
                        hoja2.Cells(22, 4) = p1a
                        hoja2.Cells(22, 5) = p1b
                        hoja2.Cells(22, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 11 And dr2.Item("cod_pregunta") = 174 Then
                        hoja2.Cells(22, 8) = p2a
                        hoja2.Cells(22, 9) = p2b
                        hoja2.Cells(22, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 11 And dr2.Item("cod_pregunta") = 175 Then
                        hoja2.Cells(22, 12) = p3a
                        hoja2.Cells(22, 13) = p3b
                        hoja2.Cells(22, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 11 And dr2.Item("cod_pregunta") = 176 Then
                        hoja2.Cells(22, 16) = p4a
                        hoja2.Cells(22, 17) = p4b
                        hoja2.Cells(22, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 12 And dr2.Item("cod_pregunta") = 183 Then
                        hoja2.Cells(23, 4) = p1a
                        hoja2.Cells(23, 5) = p1b
                        hoja2.Cells(23, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 12 And dr2.Item("cod_pregunta") = 184 Then
                        hoja2.Cells(23, 8) = p2a
                        hoja2.Cells(23, 9) = p2b
                        hoja2.Cells(23, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 12 And dr2.Item("cod_pregunta") = 185 Then
                        hoja2.Cells(23, 12) = p3a
                        hoja2.Cells(23, 13) = p3b
                        hoja2.Cells(23, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 12 And dr2.Item("cod_pregunta") = 578 Then
                        hoja2.Cells(23, 16) = p4a
                        hoja2.Cells(23, 17) = p4b
                        hoja2.Cells(23, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 13 And dr2.Item("cod_pregunta") = 192 Then
                        hoja2.Cells(24, 4) = p1a
                        hoja2.Cells(24, 5) = p1b
                        hoja2.Cells(24, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 13 And dr2.Item("cod_pregunta") = 193 Then
                        hoja2.Cells(24, 8) = p2a
                        hoja2.Cells(24, 9) = p2b
                        hoja2.Cells(24, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 13 And dr2.Item("cod_pregunta") = 194 Then
                        hoja2.Cells(24, 12) = p3a
                        hoja2.Cells(24, 13) = p3b
                        hoja2.Cells(24, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 13 And dr2.Item("cod_pregunta") = 195 Then
                        hoja2.Cells(24, 16) = p4a
                        hoja2.Cells(24, 17) = p4b
                        hoja2.Cells(24, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 14 And dr2.Item("cod_pregunta") = 205 Then
                        hoja2.Cells(25, 4) = p1a
                        hoja2.Cells(25, 5) = p1b
                        hoja2.Cells(25, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 14 And dr2.Item("cod_pregunta") = 206 Then
                        hoja2.Cells(25, 8) = p2a
                        hoja2.Cells(25, 9) = p2b
                        hoja2.Cells(25, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 14 And dr2.Item("cod_pregunta") = 207 Then
                        hoja2.Cells(25, 12) = p3a
                        hoja2.Cells(25, 13) = p3b
                        hoja2.Cells(25, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 14 And dr2.Item("cod_pregunta") = 208 Then
                        hoja2.Cells(25, 16) = p4a
                        hoja2.Cells(25, 17) = p4b
                        hoja2.Cells(25, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 15 And dr2.Item("cod_pregunta") = 223 Then
                        hoja2.Cells(26, 4) = p1a
                        hoja2.Cells(26, 5) = p1b
                        hoja2.Cells(26, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 15 And dr2.Item("cod_pregunta") = 224 Then
                        hoja2.Cells(26, 8) = p2a
                        hoja2.Cells(26, 9) = p2b
                        hoja2.Cells(26, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 15 And dr2.Item("cod_pregunta") = 225 Then
                        hoja2.Cells(26, 12) = p3a
                        hoja2.Cells(26, 13) = p3b
                        hoja2.Cells(26, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 15 And dr2.Item("cod_pregunta") = 226 Then
                        hoja2.Cells(26, 16) = p4a
                        hoja2.Cells(26, 17) = p4b
                        hoja2.Cells(26, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 16 And dr2.Item("cod_pregunta") = 235 Then
                        hoja2.Cells(27, 4) = p1a
                        hoja2.Cells(27, 5) = p1b
                        hoja2.Cells(27, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 16 And dr2.Item("cod_pregunta") = 236 Then
                        hoja2.Cells(27, 8) = p2a
                        hoja2.Cells(27, 9) = p2b
                        hoja2.Cells(27, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 16 And dr2.Item("cod_pregunta") = 237 Then
                        hoja2.Cells(27, 12) = p3a
                        hoja2.Cells(27, 13) = p3b
                        hoja2.Cells(27, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 16 And dr2.Item("cod_pregunta") = 238 Then
                        hoja2.Cells(27, 16) = p4a
                        hoja2.Cells(27, 17) = p4b
                        hoja2.Cells(27, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 17 And dr2.Item("cod_pregunta") = 249 Then
                        hoja2.Cells(31, 4) = p1a
                        hoja2.Cells(31, 5) = p1b
                        hoja2.Cells(31, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 17 And dr2.Item("cod_pregunta") = 250 Then
                        hoja2.Cells(31, 8) = p2a
                        hoja2.Cells(31, 9) = p2b
                        hoja2.Cells(31, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 17 And dr2.Item("cod_pregunta") = 251 Then
                        hoja2.Cells(31, 12) = p3a
                        hoja2.Cells(31, 13) = p3b
                        hoja2.Cells(31, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 17 And dr2.Item("cod_pregunta") = 252 Then
                        hoja2.Cells(31, 16) = p4a
                        hoja2.Cells(31, 17) = p4b
                        hoja2.Cells(31, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 18 And dr2.Item("cod_pregunta") = 270 Then
                        hoja2.Cells(32, 4) = p1a
                        hoja2.Cells(32, 5) = p1b
                        hoja2.Cells(32, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 18 And dr2.Item("cod_pregunta") = 271 Then
                        hoja2.Cells(32, 8) = p2a
                        hoja2.Cells(32, 9) = p2b
                        hoja2.Cells(32, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 18 And dr2.Item("cod_pregunta") = 272 Then
                        hoja2.Cells(32, 12) = p3a
                        hoja2.Cells(32, 13) = p3b
                        hoja2.Cells(32, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 18 And dr2.Item("cod_pregunta") = 273 Then
                        hoja2.Cells(32, 16) = p4a
                        hoja2.Cells(32, 17) = p4b
                        hoja2.Cells(32, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 19 And dr2.Item("cod_pregunta") = 290 Then
                        hoja2.Cells(33, 4) = p1a
                        hoja2.Cells(33, 5) = p1b
                        hoja2.Cells(33, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 19 And dr2.Item("cod_pregunta") = 291 Then
                        hoja2.Cells(33, 8) = p2a
                        hoja2.Cells(33, 9) = p2b
                        hoja2.Cells(33, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 19 And dr2.Item("cod_pregunta") = 292 Then
                        hoja2.Cells(33, 12) = p3a
                        hoja2.Cells(33, 13) = p3b
                        hoja2.Cells(33, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 19 And dr2.Item("cod_pregunta") = 293 Then
                        hoja2.Cells(33, 16) = p4a
                        hoja2.Cells(33, 17) = p4b
                        hoja2.Cells(33, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 20 And dr2.Item("cod_pregunta") = 304 Then
                        hoja2.Cells(34, 4) = p1a
                        hoja2.Cells(34, 5) = p1b
                        hoja2.Cells(34, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 20 And dr2.Item("cod_pregunta") = 305 Then
                        hoja2.Cells(34, 8) = p2a
                        hoja2.Cells(34, 9) = p2b
                        hoja2.Cells(34, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 20 And dr2.Item("cod_pregunta") = 306 Then
                        hoja2.Cells(34, 12) = p3a
                        hoja2.Cells(34, 13) = p3b
                        hoja2.Cells(34, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 20 And dr2.Item("cod_pregunta") = 307 Then
                        hoja2.Cells(34, 16) = p4a
                        hoja2.Cells(34, 17) = p4b
                        hoja2.Cells(34, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 21 And dr2.Item("cod_pregunta") = 316 Then
                        hoja2.Cells(35, 4) = p1a
                        hoja2.Cells(35, 5) = p1b
                        hoja2.Cells(35, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 21 And dr2.Item("cod_pregunta") = 317 Then
                        hoja2.Cells(35, 8) = p2a
                        hoja2.Cells(35, 9) = p2b
                        hoja2.Cells(35, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 21 And dr2.Item("cod_pregunta") = 318 Then
                        hoja2.Cells(35, 12) = p3a
                        hoja2.Cells(35, 13) = p3b
                        hoja2.Cells(35, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 21 And dr2.Item("cod_pregunta") = 319 Then
                        hoja2.Cells(35, 16) = p4a
                        hoja2.Cells(35, 17) = p4b
                        hoja2.Cells(35, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 22 And dr2.Item("cod_pregunta") = 326 Then
                        hoja2.Cells(36, 4) = p1a
                        hoja2.Cells(36, 5) = p1b
                        hoja2.Cells(36, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 22 And dr2.Item("cod_pregunta") = 327 Then
                        hoja2.Cells(36, 8) = p2a
                        hoja2.Cells(36, 9) = p2b
                        hoja2.Cells(36, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 22 And dr2.Item("cod_pregunta") = 328 Then
                        hoja2.Cells(36, 12) = p3a
                        hoja2.Cells(36, 13) = p3b
                        hoja2.Cells(36, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 22 And dr2.Item("cod_pregunta") = 329 Then
                        hoja2.Cells(36, 16) = p4a
                        hoja2.Cells(36, 17) = p4b
                        hoja2.Cells(36, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 23 And dr2.Item("cod_pregunta") = 340 Then
                        hoja2.Cells(40, 4) = p1a
                        hoja2.Cells(40, 5) = p1b
                        hoja2.Cells(40, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 23 And dr2.Item("cod_pregunta") = 341 Then
                        hoja2.Cells(40, 8) = p2a
                        hoja2.Cells(40, 9) = p2b
                        hoja2.Cells(40, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 23 And dr2.Item("cod_pregunta") = 342 Then
                        hoja2.Cells(40, 12) = p3a
                        hoja2.Cells(40, 13) = p3b
                        hoja2.Cells(40, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 23 And dr2.Item("cod_pregunta") = 579 Then
                        hoja2.Cells(40, 16) = p4a
                        hoja2.Cells(40, 17) = p4b
                        hoja2.Cells(40, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 24 And dr2.Item("cod_pregunta") = 355 Then
                        hoja2.Cells(41, 4) = p1a
                        hoja2.Cells(41, 5) = p1b
                        hoja2.Cells(41, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 24 And dr2.Item("cod_pregunta") = 356 Then
                        hoja2.Cells(41, 8) = p2a
                        hoja2.Cells(41, 9) = p2b
                        hoja2.Cells(41, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 24 And dr2.Item("cod_pregunta") = 357 Then
                        hoja2.Cells(41, 12) = p3a
                        hoja2.Cells(41, 13) = p3b
                        hoja2.Cells(41, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 24 And dr2.Item("cod_pregunta") = 358 Then
                        hoja2.Cells(41, 16) = p4a
                        hoja2.Cells(41, 17) = p4b
                        hoja2.Cells(41, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 25 And dr2.Item("cod_pregunta") = 369 Then
                        hoja2.Cells(42, 4) = p1a
                        hoja2.Cells(42, 5) = p1b
                        hoja2.Cells(42, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 25 And dr2.Item("cod_pregunta") = 370 Then
                        hoja2.Cells(42, 8) = p2a
                        hoja2.Cells(42, 9) = p2b
                        hoja2.Cells(42, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 25 And dr2.Item("cod_pregunta") = 371 Then
                        hoja2.Cells(42, 12) = p3a
                        hoja2.Cells(42, 13) = p3b
                        hoja2.Cells(42, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 25 And dr2.Item("cod_pregunta") = 372 Then
                        hoja2.Cells(42, 16) = p4a
                        hoja2.Cells(42, 17) = p4b
                        hoja2.Cells(42, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 26 And dr2.Item("cod_pregunta") = 385 Then
                        hoja2.Cells(43, 4) = p1a
                        hoja2.Cells(43, 5) = p1b
                        hoja2.Cells(43, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 26 And dr2.Item("cod_pregunta") = 386 Then
                        hoja2.Cells(43, 8) = p2a
                        hoja2.Cells(43, 9) = p2b
                        hoja2.Cells(43, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 26 And dr2.Item("cod_pregunta") = 387 Then
                        hoja2.Cells(43, 12) = p3a
                        hoja2.Cells(43, 13) = p3b
                        hoja2.Cells(43, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 26 And dr2.Item("cod_pregunta") = 388 Then
                        hoja2.Cells(43, 16) = p4a
                        hoja2.Cells(43, 17) = p4b
                        hoja2.Cells(43, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 27 And dr2.Item("cod_pregunta") = 401 Then
                        hoja2.Cells(44, 4) = p1a
                        hoja2.Cells(44, 5) = p1b
                        hoja2.Cells(44, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 27 And dr2.Item("cod_pregunta") = 402 Then
                        hoja2.Cells(44, 8) = p2a
                        hoja2.Cells(44, 9) = p2b
                        hoja2.Cells(44, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 27 And dr2.Item("cod_pregunta") = 403 Then
                        hoja2.Cells(44, 12) = p3a
                        hoja2.Cells(44, 13) = p3b
                        hoja2.Cells(44, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 27 And dr2.Item("cod_pregunta") = 404 Then
                        hoja2.Cells(44, 16) = p4a
                        hoja2.Cells(44, 17) = p4b
                        hoja2.Cells(44, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 28 And dr2.Item("cod_pregunta") = 413 Then
                        hoja2.Cells(45, 4) = p1a
                        hoja2.Cells(45, 5) = p1b
                        hoja2.Cells(45, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 28 And dr2.Item("cod_pregunta") = 414 Then
                        hoja2.Cells(45, 8) = p2a
                        hoja2.Cells(45, 9) = p2b
                        hoja2.Cells(45, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 28 And dr2.Item("cod_pregunta") = 415 Then
                        hoja2.Cells(45, 12) = p3a
                        hoja2.Cells(45, 13) = p3b
                        hoja2.Cells(45, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 28 And dr2.Item("cod_pregunta") = 416 Then
                        hoja2.Cells(45, 16) = p4a
                        hoja2.Cells(45, 17) = p4b
                        hoja2.Cells(45, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 29 And dr2.Item("cod_pregunta") = 427 Then
                        hoja2.Cells(46, 4) = p1a
                        hoja2.Cells(46, 5) = p1b
                        hoja2.Cells(46, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 29 And dr2.Item("cod_pregunta") = 428 Then
                        hoja2.Cells(46, 8) = p2a
                        hoja2.Cells(46, 9) = p2b
                        hoja2.Cells(46, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 29 And dr2.Item("cod_pregunta") = 429 Then
                        hoja2.Cells(46, 12) = p3a
                        hoja2.Cells(46, 13) = p3b
                        hoja2.Cells(46, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 29 And dr2.Item("cod_pregunta") = 580 Then
                        hoja2.Cells(46, 16) = p4a
                        hoja2.Cells(46, 17) = p4b
                        hoja2.Cells(46, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 30 And dr2.Item("cod_pregunta") = 441 Then
                        hoja2.Cells(47, 4) = p1a
                        hoja2.Cells(47, 5) = p1b
                        hoja2.Cells(47, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 30 And dr2.Item("cod_pregunta") = 442 Then
                        hoja2.Cells(47, 8) = p2a
                        hoja2.Cells(47, 9) = p2b
                        hoja2.Cells(47, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 30 And dr2.Item("cod_pregunta") = 443 Then
                        hoja2.Cells(47, 12) = p3a
                        hoja2.Cells(47, 13) = p3b
                        hoja2.Cells(47, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 30 And dr2.Item("cod_pregunta") = 444 Then
                        hoja2.Cells(47, 16) = p4a
                        hoja2.Cells(47, 17) = p4b
                        hoja2.Cells(47, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 31 And dr2.Item("cod_pregunta") = 455 Then
                        hoja2.Cells(48, 4) = p1a
                        hoja2.Cells(48, 5) = p1b
                        hoja2.Cells(48, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 31 And dr2.Item("cod_pregunta") = 456 Then
                        hoja2.Cells(48, 8) = p2a
                        hoja2.Cells(48, 9) = p2b
                        hoja2.Cells(48, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 31 And dr2.Item("cod_pregunta") = 457 Then
                        hoja2.Cells(48, 12) = p3a
                        hoja2.Cells(48, 13) = p3b
                        hoja2.Cells(48, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 31 And dr2.Item("cod_pregunta") = 458 Then
                        hoja2.Cells(48, 16) = p4a
                        hoja2.Cells(48, 17) = p4b
                        hoja2.Cells(48, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 32 And dr2.Item("cod_pregunta") = 473 Then
                        hoja2.Cells(49, 4) = p1a
                        hoja2.Cells(49, 5) = p1b
                        hoja2.Cells(49, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 32 And dr2.Item("cod_pregunta") = 474 Then
                        hoja2.Cells(49, 8) = p2a
                        hoja2.Cells(49, 9) = p2b
                        hoja2.Cells(49, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 32 And dr2.Item("cod_pregunta") = 475 Then
                        hoja2.Cells(49, 12) = p3a
                        hoja2.Cells(49, 13) = p3b
                        hoja2.Cells(49, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 32 And dr2.Item("cod_pregunta") = 476 Then
                        hoja2.Cells(49, 16) = p4a
                        hoja2.Cells(49, 17) = p4b
                        hoja2.Cells(49, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 33 And dr2.Item("cod_pregunta") = 487 Then
                        hoja2.Cells(50, 4) = p1a
                        hoja2.Cells(50, 5) = p1b
                        hoja2.Cells(50, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 33 And dr2.Item("cod_pregunta") = 488 Then
                        hoja2.Cells(50, 8) = p2a
                        hoja2.Cells(50, 9) = p2b
                        hoja2.Cells(50, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 33 And dr2.Item("cod_pregunta") = 489 Then
                        hoja2.Cells(50, 12) = p3a
                        hoja2.Cells(50, 13) = p3b
                        hoja2.Cells(50, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 33 And dr2.Item("cod_pregunta") = 490 Then
                        hoja2.Cells(50, 16) = p4a
                        hoja2.Cells(50, 17) = p4b
                        hoja2.Cells(50, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 34 And dr2.Item("cod_pregunta") = 497 Then
                        hoja2.Cells(54, 4) = p1a
                        hoja2.Cells(54, 5) = p1b
                        hoja2.Cells(54, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 34 And dr2.Item("cod_pregunta") = 498 Then
                        hoja2.Cells(54, 8) = p2a
                        hoja2.Cells(54, 9) = p2b
                        hoja2.Cells(54, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 34 And dr2.Item("cod_pregunta") = 499 Then
                        hoja2.Cells(54, 12) = p3a
                        hoja2.Cells(54, 13) = p3b
                        hoja2.Cells(54, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 34 And dr2.Item("cod_pregunta") = 500 Then
                        hoja2.Cells(54, 16) = p4a
                        hoja2.Cells(54, 17) = p4b
                        hoja2.Cells(54, 18) = p4c

                    End If


                    If dr2.Item("cod_grupo_encuesta") = 35 And dr2.Item("cod_pregunta") = 511 Then
                        hoja2.Cells(55, 4) = p1a
                        hoja2.Cells(55, 5) = p1b
                        hoja2.Cells(55, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 35 And dr2.Item("cod_pregunta") = 512 Then
                        hoja2.Cells(55, 8) = p2a
                        hoja2.Cells(55, 9) = p2b
                        hoja2.Cells(55, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 35 And dr2.Item("cod_pregunta") = 513 Then
                        hoja2.Cells(55, 12) = p3a
                        hoja2.Cells(55, 13) = p3b
                        hoja2.Cells(55, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 35 And dr2.Item("cod_pregunta") = 514 Then
                        hoja2.Cells(55, 16) = p4a
                        hoja2.Cells(55, 17) = p4b
                        hoja2.Cells(55, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 36 And dr2.Item("cod_pregunta") = 526 Then
                        hoja2.Cells(56, 4) = p1a
                        hoja2.Cells(56, 5) = p1b
                        hoja2.Cells(56, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 36 And dr2.Item("cod_pregunta") = 527 Then
                        hoja2.Cells(56, 8) = p2a
                        hoja2.Cells(56, 9) = p2b
                        hoja2.Cells(56, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 36 And dr2.Item("cod_pregunta") = 528 Then
                        hoja2.Cells(56, 12) = p3a
                        hoja2.Cells(56, 13) = p3b
                        hoja2.Cells(56, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 36 And dr2.Item("cod_pregunta") = 529 Then
                        hoja2.Cells(56, 16) = p4a
                        hoja2.Cells(56, 17) = p4b
                        hoja2.Cells(56, 18) = p4c

                    End If




                    If dr2.Item("cod_grupo_encuesta") = 37 And dr2.Item("cod_pregunta") = 536 Then
                        hoja2.Cells(57, 4) = p1a
                        hoja2.Cells(57, 5) = p1b
                        hoja2.Cells(57, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 37 And dr2.Item("cod_pregunta") = 537 Then
                        hoja2.Cells(57, 8) = p2a
                        hoja2.Cells(57, 9) = p2b
                        hoja2.Cells(57, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 37 And dr2.Item("cod_pregunta") = 538 Then
                        hoja2.Cells(57, 12) = p3a
                        hoja2.Cells(57, 13) = p3b
                        hoja2.Cells(57, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 37 And dr2.Item("cod_pregunta") = 539 Then
                        hoja2.Cells(57, 16) = p4a
                        hoja2.Cells(57, 17) = p4b
                        hoja2.Cells(57, 18) = p4c

                    End If



                    If dr2.Item("cod_grupo_encuesta") = 38 And dr2.Item("cod_pregunta") = 550 Then
                        hoja2.Cells(58, 4) = p1a
                        hoja2.Cells(58, 5) = p1b
                        hoja2.Cells(58, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 38 And dr2.Item("cod_pregunta") = 551 Then
                        hoja2.Cells(58, 8) = p2a
                        hoja2.Cells(58, 9) = p2b
                        hoja2.Cells(58, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 38 And dr2.Item("cod_pregunta") = 552 Then
                        hoja2.Cells(58, 12) = p3a
                        hoja2.Cells(58, 13) = p3b
                        hoja2.Cells(58, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 38 And dr2.Item("cod_pregunta") = 553 Then
                        hoja2.Cells(58, 16) = p4a
                        hoja2.Cells(58, 17) = p4b
                        hoja2.Cells(58, 18) = p4c

                    End If




                    If dr2.Item("cod_grupo_encuesta") = 39 And dr2.Item("cod_pregunta") = 564 Then
                        hoja2.Cells(59, 4) = p1a
                        hoja2.Cells(59, 5) = p1b
                        hoja2.Cells(59, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 39 And dr2.Item("cod_pregunta") = 565 Then
                        hoja2.Cells(59, 8) = p2a
                        hoja2.Cells(59, 9) = p2b
                        hoja2.Cells(59, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 39 And dr2.Item("cod_pregunta") = 566 Then
                        hoja2.Cells(59, 12) = p3a
                        hoja2.Cells(59, 13) = p3b
                        hoja2.Cells(59, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 39 And dr2.Item("cod_pregunta") = 567 Then
                        hoja2.Cells(59, 16) = p4a
                        hoja2.Cells(59, 17) = p4b
                        hoja2.Cells(59, 18) = p4c

                    End If

                    If dr2.Item("cod_grupo_encuesta") = 40 And dr2.Item("cod_pregunta") = 574 Then
                        hoja2.Cells(60, 4) = p1a
                        hoja2.Cells(60, 5) = p1b
                        hoja2.Cells(60, 6) = p1c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 40 And dr2.Item("cod_pregunta") = 575 Then
                        hoja2.Cells(60, 8) = p2a
                        hoja2.Cells(60, 9) = p2b
                        hoja2.Cells(60, 10) = p2c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 40 And dr2.Item("cod_pregunta") = 576 Then
                        hoja2.Cells(60, 12) = p3a
                        hoja2.Cells(60, 13) = p3b
                        hoja2.Cells(60, 14) = p3c
                    ElseIf dr2.Item("cod_grupo_encuesta") = 40 And dr2.Item("cod_pregunta") = 577 Then
                        hoja2.Cells(60, 16) = p4a
                        hoja2.Cells(60, 17) = p4b
                        hoja2.Cells(60, 18) = p4c

                    End If

                    p1a = 0
                    p1b = 0
                    p1c = 0
                    p2a = 0
                    p2b = 0
                    p2c = 0
                    p3a = 0
                    p3b = 0
                    p3c = 0
                    p4a = 0
                    p4b = 0
                    p4c = 0
                Next
                Ods.Tables("solicitantes").DefaultView.RowFilter = ""
            Next

        Catch ex As Exception
        Finally
            mExcel.Visible = True
        End Try

    End Sub
    Private Sub llenar_combo()
        Dim otrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt As DataTable
        Dim ls_sql As String

        Try


            otrans.open()
            ls_sql = "Select  distinct(equipo)as equipo from seg_usuario_evaluacion_diageo"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "Equipos"
            Ods.Tables.Add(dt.Copy)
            Me.cmb_equipo.DataSource = Ods.Tables("Equipos")
            Me.cmb_equipo.ValueMember = "equipo"
            Me.cmb_equipo.DisplayMember = "equipo"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub Frm_EvaluacionD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combo()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Me.Enviar_Excel_Ingresar_Punteo()


    End Sub


End Class