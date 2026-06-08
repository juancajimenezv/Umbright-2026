Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Math
Imports System.Configuration
Imports System.Net.Mail
Imports System.Net.Mime



#Region " Generales "

Public Class General

    Public ls_log As String
    Dim dvcombobox As DataGridViewComboBoxColumn
    Dim dvcombobox2 As DataGridViewComboBoxColumn
    Dim dvcombobox3 As DataGridViewComboBoxColumn
    Dim dvCalendar As CalendarColumn
    Dim butilizarcombobox As Boolean = False
    Dim butlizarCalendar As Boolean = False
    Dim psColumnasEnteros As String = String.Empty
    Public gsNombreInicialLog As String = "log_" + Now.ToString("yyyyMM")

    Public Function Obtener_Moneda(ByVal pempresa As String) As String
        Dim lsSQL As String
        Dim lsMoneda As String = String.Empty
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod 'MONEDA','CONFIG.EMPRESA','" & pempresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "flexline_configuracion"
            lsMoneda = dt.Rows(0)("Texto")
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Return lsMoneda

    End Function

    Public Function dtTableToCSV(dt As DataTable, filename As String, Optional headers As Boolean = True, Optional delim As String = ",")
        Dim txt As String
        Dim fileloc As String = filename + ".csv"
        If File.Exists(fileloc) Then
            File.Delete(fileloc)
        End If
        Dim n = 0
        If headers = True Then
            For Each column As DataColumn In dt.Columns
                If n = 0 Then
                    txt += column.ColumnName
                Else
                    txt += delim + column.ColumnName
                End If
                n += 1
            Next
        End If
        txt += vbCrLf
        n = 0
        For Each row As DataRow In dt.Rows
            Dim line As String = ""

            For Each column As DataColumn In dt.Columns
                line += delim & row(column.ColumnName).ToString()
            Next
            If dt.Rows.Count - 1 = n Then
                txt += line.Substring(1)
            Else
                txt += line.Substring(1) & vbCrLf
            End If
            n += 1
        Next
        Using sw As StreamWriter = New StreamWriter(fileloc)
            sw.Write(txt)
        End Using
        dt.Dispose()
        Return fileloc
    End Function

    Public Sub Alinea_Grid(ByVal otabla As DataTable, ByVal oDataGrid As DataGrid, ByVal Ocultar As Integer, ByVal Maximo As Integer,
            ByVal Minimo As Integer, ByVal ocultar_primera_fila As Boolean, ByVal formato_decimal As Boolean,
            ByVal campos_mostrar As String, ByVal ppermitir_ordenar As Boolean, ByVal pcampos_readonly As String)

        Alinea_Grid(otabla, oDataGrid, otabla.TableName, Ocultar, Maximo, Minimo, ocultar_primera_fila, formato_decimal, campos_mostrar, ppermitir_ordenar, pcampos_readonly)
    End Sub

    Public Sub Alinea_Grid(ByVal otabla As DataTable, ByVal oDataGrid As DataGrid, ByVal ps_nombretabla As String, ByVal Ocultar As Integer, ByVal Maximo As Integer,
            ByVal Minimo As Integer, ByVal ocultar_primera_fila As Boolean, ByVal formato_decimal As Boolean,
            ByVal campos_mostrar As String, ByVal ppermitir_ordenar As Boolean, ByVal pcampos_readonly As String)

        Dim estilo As New DataGridTableStyle
        Dim i As Integer
        '  Dim clGenerales As New Clases_Generales.General
        estilo.MappingName = ps_nombretabla
        Dim nombre_tipo As String
        Dim fechahora As DateTime
        Dim dt As DataColumn
        Dim nombrecolumna As String

        For i = 0 To otabla.Columns.Count() - 1
            If i > Ocultar Then
                nombrecolumna = otabla.Columns(i).ColumnName
                If campos_mostrar.Length = 0 Or
                    campos_mostrar.ToLower.LastIndexOf(nombrecolumna.ToLower & ",") >= 0 Then

                    'nombrecolumna.Trim.ToLower.LastIndexOf(campos_mostrar.Replace(",", " ").Trim.ToLower) >= 0 Then
                    dt = otabla.Columns(i)

                    Try
                        nombre_tipo = dt.DataType.ToString
                    Catch ex As Exception
                        nombre_tipo = ""
                    End Try
                    If nombre_tipo.ToLower = "system.boolean" Then
                        Dim mydatacol As New ClasesGenerales.DataGridCheckBox(nombrecolumna, 60,
                                                HorizontalAlignment.Center,
                                                False, nombrecolumna,
                                                String.Empty, False, True,
                                                False, String.Empty)
                        estilo.GridColumnStyles.Add(mydatacol)
                    Else
                        Dim column As New DataGridTextBoxColumn
                        With column


                            If ocultar_primera_fila And i = Ocultar + 1 Then
                                .Width = 0
                            Else
                                .Width = tamaño_maximo_campo(otabla, " ", nombrecolumna, oDataGrid, Maximo, Minimo)
                            End If

                            .MappingName = nombrecolumna.Trim
                            .HeaderText = nombrecolumna.Trim.Replace("_", " ")
                            .NullText = ""

                            If pcampos_readonly.LastIndexOf(nombrecolumna) >= 0 Then
                                .ReadOnly = True
                            End If

                            If formato_decimal And (nombre_tipo = "System.Decimal" Or nombre_tipo = "System.Double") Then
                                .Format = "n"
                                .Alignment = HorizontalAlignment.Right
                            End If

                            If nombre_tipo.ToString.ToLower.LastIndexOf("int") > 0 Then
                                .Alignment = HorizontalAlignment.Right
                            End If

                            If nombre_tipo = "System.DateTime" Then
                                .Width = 95
                                Try
                                    fechahora = otabla.Rows(0).Item(nombrecolumna)
                                Catch ex As Exception
                                    fechahora = Now
                                End Try
                                If fechahora.Minute > 0 Then
                                    .Format = "dd/MM/yyyy HH:mm"
                                Else
                                    .Width = 65
                                End If
                            End If
                        End With
                        estilo.GridColumnStyles.Add(column)
                    End If '' Boolean
                End If '' el nombre esta
            End If '' ocultar
        Next
        estilo.HeaderForeColor = Color.Black
        estilo.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        estilo.GridLineColor = Color.LightGray
        estilo.AlternatingBackColor = Color.WhiteSmoke
        estilo.RowHeaderWidth = 5
        estilo.AllowSorting = ppermitir_ordenar

        oDataGrid.TableStyles.Clear()
        oDataGrid.TableStyles.Add(estilo)

    End Sub

    Public Sub Alinear_GridView(ByVal odt As DataTable, ByVal odgv As DataGridView, ByVal _columnas_mostrar As String, ByVal _columnas_ocultar As String,
                            ByVal _columnas_readonly As String, ByVal _columnas_derecha As String, ByVal _formato_decimal As Boolean, ByVal _autoajustar As Boolean, ByVal _maximo As Integer, ByVal _minimo As Integer)

        Alinear_GridView(odt, odgv, _columnas_mostrar, _columnas_ocultar, _columnas_readonly, _columnas_derecha, "", "", "", _formato_decimal, _autoajustar, _maximo, _minimo)
    End Sub

    Public Sub Alinear_GridView(ByVal odt As DataTable, ByVal odgv As DataGridView, ByVal _columnas_mostrar As String, ByVal _columnas_ocultar As String,
                            ByVal _columnas_readonly As String, ByVal _columnas_derecha As String, ByVal _columnas_reemplazar As String,
                            ByVal _columnas_fijas As String,
                            ByVal _orden_columnas As String,
                            ByVal _formato_decimal As Boolean, ByVal _autoajustar As Boolean, ByVal _maximo As Integer, ByVal _minimo As Integer)

        Dim dc As DataGridViewColumn
        Dim nombre_tipo As String

        Dim dtc As DataColumn
        Dim _tamaño As Integer
        Dim text As String
        Dim inicio, total As Integer
        Dim orden_columnas As String() = _orden_columnas.Split(",")

        Try


            For Each dc In odgv.Columns
                dtc = odt.Columns(dc.Name)
                Try
                    nombre_tipo = dtc.DataType.ToString
                Catch ex As Exception
                    nombre_tipo = ""
                End Try





                If _columnas_readonly.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                    dc.ReadOnly = True
                End If

                If _columnas_derecha.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

                If _columnas_reemplazar.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") >= 0 Then

                    inicio = _columnas_reemplazar.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") + 1
                    total = _columnas_reemplazar.ToString.ToLower.IndexOf(",", inicio)
                    text = _columnas_reemplazar.Substring(inicio, total - inicio)
                    dc.HeaderText = text.Split("=")(1)
                End If


                Try
                    dc.HeaderText = dc.HeaderText.Trim.Replace("_", " ")
                Catch ex As Exception
                End Try


                If _formato_decimal And (nombre_tipo = "System.Decimal" Or nombre_tipo = "System.Double") Then
                    dc.DefaultCellStyle.Format = "n"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

                If _autoajustar Then
                    If _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") >= 0 Then
                        inicio = _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") + 1
                        total = _columnas_fijas.ToString.ToLower.IndexOf(",", inicio)
                        text = _columnas_fijas.Substring(inicio, total - inicio)

                        dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        dc.Width = Val(text.Split("=")(1))
                    Else

                        dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        If dc.Width > _maximo Then
                            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            dc.Width = tamaño_maximo_campo_datagridview(odt, " ", dc.Name, odgv, _maximo, _minimo)
                        Else
                            _tamaño = dc.Width
                            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            dc.Width = _tamaño
                        End If
                    End If
                End If ''Auto Ajustar

                If _columnas_mostrar.Length > 0 Then
                    If _columnas_mostrar.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                        dc.Visible = True
                    Else
                        dc.Visible = False
                    End If
                End If

                If _columnas_ocultar.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                    dc.Visible = False
                End If

                If psColumnasEnteros.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If



            Next
            If butilizarcombobox Then

                Try
                    For Each dc In odgv.Columns
                        If dc.Name.ToLower = dvcombobox.Name.ToLower Then
                            ' dc.DataGridView.DataGridViewControlCollectio()


                            If _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") >= 0 Then
                                inicio = _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") + 1
                                total = _columnas_fijas.ToString.ToLower.IndexOf(",", inicio)
                                text = _columnas_fijas.Substring(inicio, total - inicio)

                                dvcombobox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                dvcombobox.Width = Val(text.Split("=")(1))
                            End If


                            dc.Visible = False



                            odgv.Columns.Insert(dc.Index, dvcombobox)
                            'odgv.Dat = dc.Name
                            'Dim Cbo As DataGridViewColumn = New DataGridViewComboBoxColumn
                            'DataGridView1.Columns.Insert(2, Cbo)
                            ''dc = dvcombobox
                            'odgv.Columns.Add(dvcombobox)
                            odgv.Columns.Remove(dc)
                            '  Exit For


                        End If
                    Next


                Catch ex As Exception

                End Try

                Try
                    For Each dc In odgv.Columns
                        If dc.Name.ToLower = dvcombobox2.Name.ToLower Then
                            ' dc.DataGridView.DataGridViewControlCollectio()

                            If _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") >= 0 Then
                                inicio = _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") + 1
                                total = _columnas_fijas.ToString.ToLower.IndexOf(",", inicio)
                                text = _columnas_fijas.Substring(inicio, total - inicio)

                                dvcombobox2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                dvcombobox2.Width = Val(text.Split("=")(1))
                            End If

                            dc.Visible = False



                            odgv.Columns.Insert(dc.Index, dvcombobox2)
                            'odgv.Dat = dc.Name
                            'Dim Cbo As DataGridViewColumn = New DataGridViewComboBoxColumn
                            'DataGridView1.Columns.Insert(2, Cbo)
                            ''dc = dvcombobox
                            'odgv.Columns.Add(dvcombobox)
                            odgv.Columns.Remove(dc)
                            '  Exit For
                        End If
                    Next


                Catch ex As Exception

                End Try

                Try
                    For Each dc In odgv.Columns
                        If dc.Name.ToLower = dvcombobox3.Name.ToLower Then
                            ' dc.DataGridView.DataGridViewControlCollectio()

                            If _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") >= 0 Then
                                inicio = _columnas_fijas.ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & "=") + 1
                                total = _columnas_fijas.ToString.ToLower.IndexOf(",", inicio)
                                text = _columnas_fijas.Substring(inicio, total - inicio)

                                dvcombobox3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                dvcombobox3.Width = Val(text.Split("=")(1))
                            End If

                            dc.Visible = False



                            odgv.Columns.Insert(dc.Index, dvcombobox3)
                            'odgv.Dat = dc.Name
                            'Dim Cbo As DataGridViewColumn = New DataGridViewComboBoxColumn
                            'DataGridView1.Columns.Insert(2, Cbo)
                            ''dc = dvcombobox
                            'odgv.Columns.Add(dvcombobox)
                            odgv.Columns.Remove(dc)
                            '  Exit For
                        End If
                    Next


                Catch ex As Exception

                End Try

                'odgv.Columns.Add(dvcombobox)
            End If

            If butlizarCalendar Then

                Try
                    For Each dc In odgv.Columns
                        If dc.Name.ToLower = dvCalendar.Name.ToLower Then
                            ' dc.DataGridView.DataGridViewControlCollectio()
                            dc.Visible = False



                            odgv.Columns.Insert(dc.Index, dvCalendar)
                            'odgv.Dat = dc.Name
                            'Dim Cbo As DataGridViewColumn = New DataGridViewComboBoxColumn
                            'DataGridView1.Columns.Insert(2, Cbo)
                            ''dc = dvcombobox
                            'odgv.Columns.Add(dvcombobox)
                            odgv.Columns.Remove(dc)
                            '  Exit For
                        End If
                    Next


                Catch ex As Exception

                End Try
                'odgv.Columns.Add(dvcombobox)
            End If


        Catch ex As Exception

        End Try

        Try
            For inicio = 1 To orden_columnas.Length - 2 'la posicion 0 y la n vienen vacias
                odgv.Columns(orden_columnas(inicio)).DisplayIndex = inicio
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Property Alinear_GridViewEnteros() As String
        Get

        End Get
        Set(ByVal svalue As String)
            psColumnasEnteros = svalue
        End Set
    End Property


    Public Sub Alinear_GridViewComboBox(ByVal pdgc As DataGridViewComboBoxColumn)
        dvcombobox = pdgc
        butilizarcombobox = True

    End Sub

    Public Sub Alinear_GridViewComboBox2(ByVal pdgc As DataGridViewComboBoxColumn)
        dvcombobox2 = pdgc
        butilizarcombobox = True

    End Sub

    Public Sub Alinear_GridViewComboBox3(ByVal pdgc As DataGridViewComboBoxColumn)
        dvcombobox3 = pdgc
        butilizarcombobox = True

    End Sub

    Public Sub Alinear_GridViewCalendar(ByVal pcc As CalendarColumn)
        dvCalendar = pcc
        butlizarCalendar = True
    End Sub


    Public Function tamaño_maximo_campo(ByVal otabla As DataTable, ByVal TableName As String, ByVal Columna As String, ByVal oDataGrid As DataGrid, ByVal Maximo As Integer, ByVal Minimo As Integer) As Integer
        Dim maxLength As Integer = Maximo
        Dim minLength As Integer = Minimo

        Dim objGraphic As Graphics = oDataGrid.CreateGraphics

        'Take width of one blank space and add to the new width of the column.

        Dim offset As Integer = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(" ", oDataGrid.Font).Width))

        Dim i As Integer = 0
        Dim li_nuevomayor As Integer = 0
        Dim intaux As Integer
        Dim straux As String
        Dim tot As Integer = otabla.Rows.Count


        For i = 0 To (tot - 1)
            straux = otabla.Rows(i).Item(Columna).ToString()

            intaux = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(straux, oDataGrid.Font).Width))
            If (intaux > li_nuevomayor) Then
                li_nuevomayor = intaux
            End If

        Next


        ''el nuevo minimo es el tamaño del nombre de la columna
        If (tot = 0 Or (li_nuevomayor <= maxLength)) And minLength = 0 Then
            straux = Columna

            intaux = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(straux, oDataGrid.Font).Width))
            If (intaux > li_nuevomayor) Then
                li_nuevomayor = intaux
            End If

        End If

        If (li_nuevomayor < maxLength) Then
            maxLength = li_nuevomayor
        End If

        If (maxLength < minLength) Then
            maxLength = minLength
        End If
        Return maxLength + offset
    End Function

    Public Function tamaño_maximo_campo_datagridview(ByVal otabla As DataTable, ByVal TableName As String, ByVal Columna As String, ByVal oDataGrid As DataGridView, ByVal Maximo As Integer, ByVal Minimo As Integer) As Integer
        Dim maxLength As Integer = Maximo
        Dim minLength As Integer = Minimo

        Dim objGraphic As Graphics = oDataGrid.CreateGraphics

        'Take width of one blank space and add to the new width of the column.

        Dim offset As Integer = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(" ", oDataGrid.Font).Width))

        Dim i As Integer = 0
        Dim li_nuevomayor As Integer = 0
        Dim intaux As Integer
        Dim straux As String
        Dim tot As Integer = otabla.Rows.Count


        For i = 0 To (tot - 1)
            straux = otabla.Rows(i).Item(Columna).ToString()

            intaux = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(straux, oDataGrid.Font).Width))
            If (intaux > li_nuevomayor) Then
                li_nuevomayor = intaux
            End If

        Next


        ''el nuevo minimo es el tamaño del nombre de la columna
        If (tot = 0 Or (li_nuevomayor <= maxLength)) And minLength = 0 Then
            straux = Columna

            intaux = Convert.ToInt32(Math.Ceiling(objGraphic.MeasureString(straux, oDataGrid.Font).Width))
            If (intaux > li_nuevomayor) Then
                li_nuevomayor = intaux
            End If

        End If

        If (li_nuevomayor < maxLength) Then
            maxLength = li_nuevomayor
        End If

        If (maxLength < minLength) Then
            maxLength = minLength
        End If
        Return maxLength + offset
    End Function

    Public Function Armar_Filtro(ByVal campo1 As String, ByVal campo2 As String, ByVal campo3 As String, ByVal campo4 As String, ByVal campo5 As String, ByVal campo6 As String,
                                ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String, ByVal texto5 As String, ByVal texto6 As String,
                                ByVal operador1 As String, ByVal operador2 As String, ByVal operador3 As String, ByVal operador4 As String, ByVal operador5 As String, ByVal operador6 As String,
                                ByVal operador_logico1 As String, ByVal operador_logico2 As String, ByVal operador_logico3 As String, ByVal operador_logico4 As String, ByVal operador_logico5 As String) As String
        Dim ls_filtro As String = ""
        If texto1.Length > 0 Then
            ls_filtro = ls_filtro & " " & campo1 & " " &
                            operador1 & " '" & IIf(operador1 = "like", "%", "") &
                            texto1 & IIf(operador1 = "like", "%", "") & "'"

            If texto2.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico1 & " " &
                 campo2 & " " &
                 operador2 & " '" & IIf(operador2 = "like", "%", "") &
                 texto2 & IIf(operador2 = "like", "%", "") & "'"

            End If

            If texto3.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico2 & " " &
                 campo3 & " " &
                 operador3 & " '" & IIf(operador3 = "like", "%", "") &
                 texto3 & IIf(operador3 = "like", "%", "") & "'"

            End If

            If texto4.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico3 & " " &
                 campo4 & " " &
                 operador4 & " '" & IIf(operador4 = "like", "%", "") &
                 texto4 & IIf(operador4 = "like", "%", "") & "'"
            End If

            If texto5.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico4 & " " &
                 campo5 & " " &
                 operador5 & " '" & IIf(operador5 = "like", "%", "") &
                 texto5 & IIf(operador5 = "like", "%", "") & "'"
            End If

            If texto6.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico4 & " " &
                 campo6 & " " &
                 operador6 & " '" & IIf(operador6 = "like", "%", "") &
                 texto6 & IIf(operador6 = "like", "%", "") & "'"
            End If




        End If
        Return ls_filtro
    End Function

    Public Function Armar_Filtro(ByVal campo1 As String, ByVal campo2 As String, ByVal campo3 As String, ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal operador1 As String, ByVal operador2 As String, ByVal operador3 As String, ByVal operador_logico1 As String, ByVal operador_logico2 As String) As String
        Dim ls_filtro As String = ""
        If texto1.Length > 0 Then
            ls_filtro = ls_filtro & " " & campo1 & " " &
                            operador1 & " '" & IIf(operador1 = "like", "%", "") &
                            texto1 & IIf(operador1 = "like", "%", "") & "'"

            If texto2.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico1 & " " &
                 campo2 & " " &
                 operador2 & " '" & IIf(operador2 = "like", "%", "") &
                 texto2 & IIf(operador2 = "like", "%", "") & "'"

            End If

            If texto3.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico2 & " " &
                 campo3 & " " &
                 operador3 & " '" & IIf(operador3 = "like", "%", "") &
                 texto3 & IIf(operador3 = "like", "%", "") & "'"

            End If

        End If
        Return ls_filtro
    End Function

    Public Function Armar_Filtro(ByVal campo1 As String, ByVal campo2 As String, ByVal campo3 As String, ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal operador1 As String, ByVal operador2 As String, ByVal operador3 As String, ByVal operador_logico1 As String, ByVal operador_logico2 As String, ByVal dt As DataTable) As String
        Dim ls_filtro As String = ""
        Dim dc As DataColumn
        Dim lnumerico As Boolean = False
        If texto1.Length > 0 Then
            For Each dc In dt.Columns
                If dc.ColumnName.ToLower = campo1.ToLower Then
                    If dc.DataType.ToString.ToLower = "system.decimal" Or
                        dc.DataType.ToString.ToLower = "system.double" Or
                        dc.DataType.ToString.ToLower = "system.int32" Or
                       dc.DataType.ToString.ToLower = "system.single" Then

                        lnumerico = True

                        Exit For
                    End If
                End If
            Next

            ls_filtro = ls_filtro & " " &
                             campo1 & " " &
                            operador1 &
                            IIf(lnumerico, " ", " '") & IIf(operador1 = "like", "%", "") &
                            texto1.ToLower & IIf(operador1 = "like", "%", "") & IIf(lnumerico, " ", "'")


            lnumerico = False
            For Each dc In dt.Columns
                If dc.ColumnName.ToLower = campo2.ToLower Then
                    If dc.DataType.ToString.ToLower = "system.decimal" Or
                        dc.DataType.ToString.ToLower = "system.double" Or
                       dc.DataType.ToString.ToLower = "system.single" Then
                        lnumerico = True

                        Exit For
                    End If
                End If
            Next

            If texto2.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico1 & " " &
                        campo2 & " " &
                        operador2 &
                        IIf(lnumerico, " ", " '") & IIf(operador2 = "like", "%", "") &
                        texto2.ToLower & IIf(operador2 = "like", "%", "") & IIf(lnumerico, " ", " '")

            End If


            lnumerico = False
            For Each dc In dt.Columns
                If dc.ColumnName.ToLower = campo3.ToLower Then
                    If dc.DataType.ToString.ToLower = "system.decimal" Or
                        dc.DataType.ToString.ToLower = "system.double" Or
                       dc.DataType.ToString.ToLower = "system.single" Then
                        lnumerico = True

                        Exit For
                    End If
                End If
            Next
            If texto3.Length > 0 Then
                ls_filtro = ls_filtro & " " & operador_logico2 & " " &
                        campo3 & " " &
                        operador3 &
                        IIf(lnumerico, " ", " '") & IIf(operador3 = "like", "%", "") &
                            texto3.ToLower & IIf(operador3 = "like", "%", "") & IIf(lnumerico, " ", " '")

            End If

        End If
        Return ls_filtro
    End Function

#Region "Menu"


    Public Class RichMenuItem : Inherits MenuItem
        Private Shared mnuStyle As IconMenuStyle = IconMenuStyle.VSNet
        Public Shared Property DefaultMenuStyle() As IconMenuStyle
            Get
                Return mnuStyle
            End Get
            Set(ByVal value As IconMenuStyle)
                mnuStyle = value
            End Set
        End Property
        '
        Private _shortcuttext As String = ""
        Private _stringformat As StringFormat = New StringFormat
        Private _icon As Bitmap = Nothing
        Private _style As MenuItemStyleDrawer = Nothing
        Private _menustyle As IconMenuStyle = IconMenuStyle.VSNet
        '
        Private shortcuttextwidth As Integer
        '
        ' Descripción para usar en las barras de estado, etc.           (20/Jun/04)
        Private _description As String
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property
        '
        Public Shadows Function CloneMenu() As RichMenuItem
            Dim rmnu As New RichMenuItem(Me.Icon, Me.Text)
            rmnu.Checked = Me.Checked
            Return rmnu
        End Function
        Public Shadows Function CloneMenu(ByVal handler As EventHandler) As RichMenuItem
            Dim rmnu As New RichMenuItem(Me.Icon, Me.Text, handler, Me.Description)
            rmnu.Checked = Me.Checked
            Return rmnu
        End Function
        Public Shadows Function CloneMenu(ByVal handler As EventHandler, ByVal description As String) As RichMenuItem
            Dim rmnu As New RichMenuItem(Me.Icon, Me.Text, handler, description)
            rmnu.Checked = Me.Checked
            Return rmnu
        End Function
        '
        Public Property MenuStyle() As IconMenuStyle
            Get
                Return _menustyle
            End Get
            Set(ByVal value As IconMenuStyle)
                ' asignar la variable compartida,                       (19/Jun/04)
                ' para que los nuevos menús usen el último estilo
                mnuStyle = value
                Select Case value
                    Case IconMenuStyle.Office2000
                        _style = New Office2000Style
                        OwnerDraw = True

                    Case IconMenuStyle.Office2003
                        _style = New Office2003Style
                        OwnerDraw = True

                    Case IconMenuStyle.VSNet
                        _style = New VSNetStyle
                        OwnerDraw = True

                    Case Else
                        _style = Nothing
                        OwnerDraw = False

                End Select
            End Set
        End Property
        '
        Public Overloads Property ShortCutText() As String
            Get
                Return _shortcuttext
            End Get
            Set(ByVal Value As String)
                _shortcuttext = Value
            End Set
        End Property
        '
        Public Property Icon() As Bitmap
            Get
                Return _icon
            End Get
            Set(ByVal Value As Bitmap)
                _icon = Value
            End Set
        End Property
        '
        Public Sub New()
            MyBase.New()
            MenuStyle = mnuStyle
        End Sub
        '
        ' Sin estilo ni icono
        Public Sub New(ByVal text As String)
            MyBase.New(text)
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal text As String, ByVal items As RichMenuItem())
            MyBase.New(text, items)
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal text As String, ByVal handler As EventHandler)
            MyBase.New(text, handler)
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut)
            Me.New(text, handler)
            Me.Shortcut = shortcut
            MenuStyle = mnuStyle
        End Sub
        '
        ' Usando el estilo en el primer parámetro
        Public Sub New(ByVal style As IconMenuStyle)
            MyBase.New()
            MenuStyle = style
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String)
            MyBase.New(text)
            MenuStyle = style
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal items As RichMenuItem())
            MyBase.New(text, items)
            MenuStyle = style
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler)
            MyBase.New(text, handler)
            MenuStyle = style
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut)
            Me.New(style, text, handler)
            Me.Shortcut = shortcut
        End Sub
        '
        ' con iconos y estilo                                           (17/Jun/04)
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String)
            MyBase.New(text)
            MenuStyle = style
            Me.Icon = icono
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal items As RichMenuItem())
            MyBase.New(text, items)
            MenuStyle = style
            Me.Icon = icono
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler)
            MyBase.New(text, handler)
            MenuStyle = style
            Me.Icon = icono
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut)
            Me.New(icono, style, text, handler)
            Me.Shortcut = shortcut
        End Sub
        '
        ' con iconos sin estilo de menú                                 (19/Jun/04)
        Public Sub New(ByVal icono As Bitmap, ByVal text As String)
            MyBase.New(text)
            Me.Icon = icono
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal items As RichMenuItem())
            MyBase.New(text, items)
            Me.Icon = icono
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal handler As EventHandler)
            MyBase.New(text, handler)
            Me.Icon = icono
            MenuStyle = mnuStyle
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut)
            Me.New(icono, text, handler)
            Me.Shortcut = shortcut
            MenuStyle = mnuStyle
        End Sub
        '
        ' constructores con la descripción
        Public Sub New(ByVal text As String, ByVal description As String)
            MyBase.New(text)
            MenuStyle = mnuStyle
            _description = description
        End Sub
        Public Sub New(ByVal text As String, ByVal items As RichMenuItem(), ByVal description As String)
            MyBase.New(text, items)
            MenuStyle = mnuStyle
            _description = description
        End Sub
        Public Sub New(ByVal text As String, ByVal handler As EventHandler, ByVal description As String)
            MyBase.New(text, handler)
            MenuStyle = mnuStyle
            _description = description
        End Sub
        Public Sub New(ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut, ByVal description As String)
            Me.New(text, handler, description)
            Me.Shortcut = shortcut
            MenuStyle = mnuStyle
        End Sub
        '
        ' Usando el estilo en el primer parámetro
        'Public Sub New(ByVal style As IconMenuStyle, ByVal description As String)
        '    MyBase.New()
        '    MenuStyle = style
        '    _description = description
        'End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal description As String)
            MyBase.New(text)
            MenuStyle = style
            _description = description
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal items As RichMenuItem(), ByVal description As String)
            MyBase.New(text, items)
            MenuStyle = style
            _description = description
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal description As String)
            MyBase.New(text, handler)
            MenuStyle = style
            _description = description
        End Sub
        Public Sub New(ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut, ByVal description As String)
            Me.New(style, text, handler, description)
            Me.Shortcut = shortcut
        End Sub
        '
        ' con iconos y estilo                                           (17/Jun/04)
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal description As String)
            MyBase.New(text)
            MenuStyle = style
            Me.Icon = icono
            _description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal items As RichMenuItem(), ByVal description As String)
            MyBase.New(text, items)
            MenuStyle = style
            Me.Icon = icono
            _description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal description As String)
            MyBase.New(text, handler)
            MenuStyle = style
            Me.Icon = icono
            _description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal style As IconMenuStyle, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut, ByVal description As String)
            Me.New(icono, style, text, handler, description)
            Me.Shortcut = shortcut
        End Sub
        '
        ' con iconos sin estilo de menú                                 (19/Jun/04)
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal description As String)
            MyBase.New(text)
            Me.Icon = icono
            MenuStyle = mnuStyle
            _description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal items As RichMenuItem(), ByVal description As String)
            MyBase.New(text, items)
            Me.Icon = icono
            MenuStyle = mnuStyle
            description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal handler As EventHandler, ByVal description As String)
            MyBase.New(text, handler)
            Me.Icon = icono
            MenuStyle = mnuStyle
            _description = description
        End Sub
        Public Sub New(ByVal icono As Bitmap, ByVal text As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut, ByVal description As String)
            Me.New(icono, text, handler, description)
            Me.Shortcut = shortcut
            MenuStyle = mnuStyle
        End Sub
        '
        '
        Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)
            MyBase.OnMeasureItem(e)

            '// make shortcut text
            If (Shortcut <> Shortcut.None) Then
                Dim text As String = ""
                Dim key As Integer = Shortcut
                Dim ch As Integer = key And &HFF
                If ((Keys.Control And key) > 0) Then _
                    text &= "Ctrl+"
                If ((Keys.Shift And key) > 0) Then _
                    text &= "Shift+"
                If ((Keys.Alt And key) > 0) Then _
                    text &= "Alt+"

                If (ch >= Shortcut.F1 And ch <= Shortcut.F12) Then
                    text &= "F" & (ch - Shortcut.F1 + 1)
                ElseIf ((Keys.Insert And key) = Keys.Insert) Then
                    text &= "Ins"
                Else
                    ' mostrar la letra del acceso                       (17/Jun/04)
                    text &= ChrW(ch)
                End If
                _shortcuttext = text
            End If
            If (MenuStyle <> IconMenuStyle.Standard) Then
                If (Text = "-") Then
                    e.ItemHeight = 8
                    e.ItemWidth = 4
                    Exit Sub 'Return
                End If
                Dim textwidth As Integer = CType(e.Graphics.MeasureString(Text, SystemInformation.MenuFont).Width, Integer)
                shortcuttextwidth = CType(e.Graphics.MeasureString(ShortCutText, SystemInformation.MenuFont).Width, Integer)
                textwidth += shortcuttextwidth

                e.ItemHeight = SystemInformation.MenuHeight
                If (Parent Is Parent.GetMainMenu()) Then
                    e.ItemWidth = textwidth - 5  '// 5 is a magic number :)
                Else
                    e.ItemWidth = Math.Max(160, textwidth + 15)
                End If
            End If
        End Sub
        '
        Protected Overrides Sub OnSelect(ByVal e As EventArgs)
            MyBase.OnSelect(e)
        End Sub
        '
        Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
            MyBase.OnDrawItem(e)
            Dim g As Graphics = e.Graphics
            Dim bounds As Rectangle = e.Bounds
            Dim selected As Boolean = (e.State And DrawItemState.Selected) > 0
            Dim toplevel As Boolean = (Parent Is Parent.GetMainMenu())
            Dim hasicon As Boolean = Not (Icon Is Nothing)

            _style.DrawBackground(g, bounds, e.State, toplevel, hasicon)
            If (hasicon) Then
                _style.DrawIcon(g, Icon, bounds, selected, Enabled, Checked)
            ElseIf (Checked) Then
                _style.DrawCheckmark(g, bounds, selected)
            End If

            If (Text = "-") Then
                _style.DrawSeparator(g, bounds)
            Else
                _style.DrawMenuText(g, bounds, Text, ShortCutText, Enabled, toplevel, e.State)
            End If
        End Sub
    End Class
    '
    '---
    '
    Public Enum IconMenuStyle
        Standard
        Office2000
        Office2003
        VSNet
    End Enum

    Public Interface MenuItemStyleDrawer
        Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean)
        Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean)
        Sub DrawSeparator(ByVal g As Graphics, ByVal bounds As Rectangle)
        Sub DrawBackground(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal state As DrawItemState, ByVal toplevel As Boolean, ByVal hasicon As Boolean)
        Sub DrawMenuText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal text As String, ByVal shortcut As String, ByVal enabled As Boolean, ByVal toplevel As Boolean, ByVal state As DrawItemState)
    End Interface

    ' Nueva clase al estilo de Office2003                               (17/Jun/04)
    ' Sólo los colores, sin efectos de degradados...
    Public Class Office2003Style : Implements MenuItemStyleDrawer
        Shared bgcolor As Color = Color.WhiteSmoke                  ' El color de fondo de los menús
        Dim ibgcolor As Color = Color.FromArgb(200, 215, 240)       ' El color de la banda izquierda de los menús
        Shared sbcolor As Color = Color.FromArgb(255, 236, 196)     ' color de fondo del elemento seleccionado
        Dim sbbcolor As Color = Color.FromArgb(60, 96, 192)         ' Color alrededor de la selección
        '
        Dim TEXTSTART As Integer = 24 '20
        '
        Public Shared ReadOnly Property BackColor() As Color
            Get
                Return bgcolor
            End Get
        End Property
        Public Shared ReadOnly Property SelectedBackColor() As Color
            Get
                Return sbcolor
            End Get
        End Property
        '
        Public Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean) Implements MenuItemStyleDrawer.DrawCheckmark
            'ControlPaint.DrawMenuGlyph(g, New Rectangle(bounds.X + 2, bounds.Y + 2, 14, 14), MenuGlyph.Checkmark)
            'g.DrawRectangle(New Pen(sbbcolor), bounds.X + 1, bounds.Y + 1, 14 + 1, 14 + 1)
            '
            If selected = False Then
                g.FillRectangle(New Pen(Color.Gold).Brush, bounds.X + 2, bounds.Y + 2, 14 + 2, 14 + 1)
            End If
            g.DrawString("v", New Font(SystemInformation.MenuFont, FontStyle.Bold), New Pen(SystemColors.MenuText).Brush, bounds.X + 2, bounds.Y + 2)
            ''
        End Sub

        Public Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean) Implements MenuItemStyleDrawer.DrawIcon
            If enabled Then
                If selected Then
                    ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 2, Color.Black)
                    g.DrawImage(icon, bounds.Left + 1, bounds.Top + 1)
                Else
                    g.DrawImage(icon, bounds.Left + 2, bounds.Top + 2)
                End If
            Else
                ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 2, SystemColors.HighlightText)
            End If
        End Sub

        Public Sub DrawSeparator(ByVal g As Graphics, ByVal bounds As Rectangle) Implements MenuItemStyleDrawer.DrawSeparator
            Dim y As Integer = CType(bounds.Y + bounds.Height / 2, Integer)
            g.DrawLine(New Pen(SystemColors.ControlDark), bounds.X + SystemInformation.SmallIconSize.Width + 7, y, bounds.X + bounds.Width - 2, y)
        End Sub

        Public Sub DrawBackground(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal state As DrawItemState, ByVal toplevel As Boolean, ByVal hasicon As Boolean) Implements MenuItemStyleDrawer.DrawBackground
            Dim selected As Boolean = (state And DrawItemState.Selected) > 0

            If (selected OrElse ((state And DrawItemState.HotLight) > 0)) Then
                If (toplevel AndAlso selected) Then '// draw toplevel, selected menuitem
                    g.FillRectangle(New SolidBrush(ibgcolor), bounds)
                    ControlPaint.DrawBorder3D(g, bounds.Left, bounds.Top, bounds.Width, bounds.Height, Border3DStyle.Flat, Border3DSide.Top Or Border3DSide.Left Or Border3DSide.Right)
                Else '// draw menuitem, selected OR toplevel, hotlighted
                    g.FillRectangle(New SolidBrush(sbcolor), bounds)
                    g.DrawRectangle(New Pen(sbbcolor), bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1)
                End If
            Else
                If (Not toplevel) Then '// draw menuitem, unselected
                    g.FillRectangle(New SolidBrush(ibgcolor), bounds)
                    bounds.X += 16 + 5
                    bounds.Width -= 16 + 5
                    g.FillRectangle(New SolidBrush(bgcolor), bounds)
                Else
                    '// draw toplevel, unselected menuitem
                    g.FillRectangle(SystemBrushes.Control, bounds)
                End If
            End If
        End Sub

        Public Sub DrawMenuText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal text As String, ByVal shortcut As String, ByVal enabled As Boolean, ByVal toplevel As Boolean, ByVal state As DrawItemState) Implements MenuItemStyleDrawer.DrawMenuText
            Dim stringformat As StringFormat = New StringFormat
            stringformat.HotkeyPrefix = CType(IIf(((state And DrawItemState.NoAccelerator) > 0), HotkeyPrefix.Hide, HotkeyPrefix.Show), HotkeyPrefix)
            Dim textwidth As Integer = CType(g.MeasureString(text, SystemInformation.MenuFont).Width, Integer)
            Dim shortcutwidth As Integer = CType(g.MeasureString(shortcut, SystemInformation.MenuFont).Width, Integer)

            Dim x As Integer = CType(IIf(toplevel, bounds.Left + (bounds.Width - textwidth) / 2, bounds.Left + TEXTSTART), Integer)
            Dim y As Integer = bounds.Top + 2
            Dim brush As Brush = Nothing
            If enabled Then
                brush = New SolidBrush(SystemColors.MenuText)
            Else
                brush = New SolidBrush(Color.FromArgb(120, SystemColors.MenuText))
            End If
            g.DrawString(text, SystemInformation.MenuFont, brush, x, y, stringformat)
            g.DrawString(shortcut, SystemInformation.MenuFont, brush, bounds.Right - shortcutwidth - 10, bounds.Top + 2, stringformat)
        End Sub

    End Class

    Public Class Office2000Style : Implements MenuItemStyleDrawer
        Dim TEXTSTART As Integer = 20
        '
        Public Shared ReadOnly Property BackColor() As Color
            Get
                Return SystemColors.Menu
            End Get
        End Property
        Public Shared ReadOnly Property SelectedBackColor() As Color
            Get
                Return SystemColors.Highlight
            End Get
        End Property
        '
        Public Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean) Implements MenuItemStyleDrawer.DrawCheckmark
            ControlPaint.DrawMenuGlyph(g, New Rectangle(bounds.X + 2, bounds.Y + 2, 14, 14), MenuGlyph.Checkmark)
        End Sub

        Public Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean) Implements MenuItemStyleDrawer.DrawIcon
            If (enabled) Then
                g.DrawImage(icon, bounds.Left + 2, bounds.Top + 2)
            Else
                ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 2, SystemColors.Control)
            End If
            If (selected) Then _
                ControlPaint.DrawBorder3D(g, bounds.Left, bounds.Top, icon.Width + 3, icon.Height + 3, Border3DStyle.RaisedInner)
        End Sub

        Public Sub DrawSeparator(ByVal g As Graphics, ByVal bounds As Rectangle) Implements MenuItemStyleDrawer.DrawSeparator
            ControlPaint.DrawBorder3D(g, bounds.X, bounds.Y + 2, bounds.Width, 3, Border3DStyle.Etched, Border3DSide.Top)
        End Sub

        Public Sub DrawBackground(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal state As DrawItemState, ByVal toplevel As Boolean, ByVal hasicon As Boolean) Implements MenuItemStyleDrawer.DrawBackground
            Dim selected As Boolean = (state And DrawItemState.Selected) > 0
            If (selected OrElse ((state And DrawItemState.HotLight) > 0)) Then
                If (toplevel) Then
                    '//                 g.FillRectangle(SystemBrushes.Highlight, bounds);
                    ControlPaint.DrawBorder3D(g, bounds.Left, bounds.Top, bounds.Width, bounds.Height, CType(IIf(selected, Border3DStyle.SunkenOuter, Border3DStyle.RaisedInner), Border3DStyle), Border3DSide.All)
                Else
                    If (hasicon) Then
                        g.FillRectangle(SystemBrushes.Menu, New Rectangle(bounds.X, bounds.Y, bounds.X + SystemInformation.SmallIconSize.Width + 5, bounds.Height))
                        bounds.X += SystemInformation.SmallIconSize.Width + 5
                        bounds.Width -= SystemInformation.SmallIconSize.Width + 5
                    End If
                    g.FillRectangle(SystemBrushes.Highlight, bounds)
                End If
            Else
                If (toplevel) Then
                    g.FillRectangle(SystemBrushes.Control, bounds)
                Else
                    g.FillRectangle(SystemBrushes.Menu, bounds)
                End If
            End If
        End Sub

        Public Sub DrawMenuText(ByVal g As Graphics, ByVal Bounds As Rectangle, ByVal Text As String, ByVal ShortCut As String, ByVal Enabled As Boolean, ByVal TopLevel As Boolean, ByVal State As DrawItemState) Implements MenuItemStyleDrawer.DrawMenuText
            Dim selected As Boolean = (State And DrawItemState.Selected) > 0
            Dim _stringformat As StringFormat = New StringFormat
            _stringformat.HotkeyPrefix = CType(IIf(((State And DrawItemState.NoAccelerator) > 0), HotkeyPrefix.Hide, HotkeyPrefix.Show), HotkeyPrefix)
            Dim shortcutwidth As Integer = CType(g.MeasureString(ShortCut, SystemInformation.MenuFont).Width, Integer)
            Dim textwidth As Integer = CType(g.MeasureString(Text, SystemInformation.MenuFont).Width, Integer)
            Dim x As Integer = CType(IIf(TopLevel, Bounds.Left + (Bounds.Width - textwidth) / 2, Bounds.Left + TEXTSTART), Integer)

            Dim y As Integer = Bounds.Top + 2
            If (Enabled) Then
                '// normal draw
                Dim color As Color = CType(IIf((selected And (Not TopLevel)), Color.White, SystemColors.MenuText), Color)
                g.DrawString(Text, SystemInformation.MenuFont, New SolidBrush(color), x, y, _stringformat)
                g.DrawString(ShortCut, SystemInformation.MenuFont, New SolidBrush(color), Bounds.Left + 130, Bounds.Top + 2, _stringformat)
            Else
                '// disabled menuitem draw
                If (Not selected) Then
                    g.DrawString(Text, SystemInformation.MenuFont, SystemBrushes.ControlLightLight, x + 1, y + 1, _stringformat)
                    g.DrawString(ShortCut, SystemInformation.MenuFont, SystemBrushes.ControlLightLight, Bounds.Right - shortcutwidth - 10 + 1, Bounds.Top + 2 + 1, _stringformat)
                End If
                g.DrawString(Text, SystemInformation.MenuFont, New SolidBrush(SystemColors.GrayText), x, y, _stringformat)
                g.DrawString(ShortCut, SystemInformation.MenuFont, New SolidBrush(SystemColors.GrayText), Bounds.Right - shortcutwidth - 10, Bounds.Top + 2, _stringformat)
            End If
        End Sub
    End Class

    Public Class VSNetStyle : Implements MenuItemStyleDrawer
        ' El color de fondo de los menús
        Shared bgcolor As Color = SystemColors.ControlLightLight   '//Color.FromArgb(246, 246, 246);
        Dim ibgcolor As Color = SystemColors.Control 'SystemColors.ControlLight       ' El color de la banda izquierda de los menús '//Color.FromArgb(202, 202, 202);
        Shared sbcolor As Color = Color.FromArgb(200, 215, 240)    ' color de fondo del elemento seleccionado ' Color.FromArgb(173, 173, 209)
        Dim sbbcolor As Color = Color.FromArgb(60, 96, 192)     ' Color alrededor de la selección '0,0,128
        Dim TEXTSTART As Integer = 20
        '
        Public Shared ReadOnly Property BackColor() As Color
            Get
                Return bgcolor
            End Get
        End Property

        Public Shared ReadOnly Property SelectedBackColor() As Color
            Get
                Return sbcolor
            End Get
        End Property
        '
        Public Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean) Implements MenuItemStyleDrawer.DrawCheckmark
            ControlPaint.DrawMenuGlyph(g, New Rectangle(bounds.X + 2, bounds.Y + 2, 14, 14), MenuGlyph.Checkmark)
            'g.DrawRectangle(new Pen(sbbcolor), bounds.X + 1, bounds.Y + 1, 14 + 1, 14 + 1);
        End Sub

        Public Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean) Implements MenuItemStyleDrawer.DrawIcon
            If (enabled) Then
                If (selected) Then
                    ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 2, Color.Black)
                    g.DrawImage(icon, bounds.Left + 1, bounds.Top + 1)
                Else
                    g.DrawImage(icon, bounds.Left + 2, bounds.Top + 2)
                End If
            Else
                ControlPaint.DrawImageDisabled(g, icon, bounds.Left + 2, bounds.Top + 2, SystemColors.HighlightText)
            End If
        End Sub

        Public Sub DrawSeparator(ByVal g As Graphics, ByVal bounds As Rectangle) Implements MenuItemStyleDrawer.DrawSeparator
            Dim y As Integer = CType(bounds.Y + bounds.Height / 2, Integer)
            g.DrawLine(New Pen(SystemColors.ControlDark), bounds.X + SystemInformation.SmallIconSize.Width + 7, y, bounds.X + bounds.Width - 2, y)
        End Sub

        Public Sub DrawBackground(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal state As DrawItemState, ByVal toplevel As Boolean, ByVal hasicon As Boolean) Implements MenuItemStyleDrawer.DrawBackground
            Dim selected As Boolean = (state And DrawItemState.Selected) > 0

            If (selected OrElse ((state And DrawItemState.HotLight) > 0)) Then
                If (toplevel AndAlso selected) Then '// draw toplevel, selected menuitem
                    g.FillRectangle(New SolidBrush(ibgcolor), bounds)
                    ControlPaint.DrawBorder3D(g, bounds.Left, bounds.Top, bounds.Width, bounds.Height, Border3DStyle.Flat, Border3DSide.Top Or Border3DSide.Left Or Border3DSide.Right)
                Else '// draw menuitem, selected OR toplevel, hotlighted
                    g.FillRectangle(New SolidBrush(sbcolor), bounds)
                    g.DrawRectangle(New Pen(sbbcolor), bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1)
                End If
            Else
                If (Not toplevel) Then '// draw menuitem, unselected
                    g.FillRectangle(New SolidBrush(ibgcolor), bounds)
                    bounds.X += 16 + 5
                    bounds.Width -= 16 + 5
                    g.FillRectangle(New SolidBrush(bgcolor), bounds)
                Else
                    '// draw toplevel, unselected menuitem
                    g.FillRectangle(SystemBrushes.Control, bounds)

                End If
            End If
        End Sub

        Public Sub DrawMenuText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal text As String, ByVal shortcut As String, ByVal enabled As Boolean, ByVal toplevel As Boolean, ByVal state As DrawItemState) Implements MenuItemStyleDrawer.DrawMenuText
            Dim stringformat As StringFormat = New StringFormat
            stringformat.HotkeyPrefix = CType(IIf(((state And DrawItemState.NoAccelerator) > 0), HotkeyPrefix.Hide, HotkeyPrefix.Show), HotkeyPrefix)
            Dim textwidth As Integer = CType(g.MeasureString(text, SystemInformation.MenuFont).Width, Integer)
            Dim shortcutwidth As Integer = CType(g.MeasureString(shortcut, SystemInformation.MenuFont).Width, Integer)

            Dim x As Integer = CType(IIf(toplevel, bounds.Left + (bounds.Width - textwidth) / 2, bounds.Left + TEXTSTART), Integer)
            Dim y As Integer = bounds.Top + 2
            Dim brush As Brush = Nothing
            If (Not enabled) Then
                brush = New SolidBrush(Color.FromArgb(120, SystemColors.MenuText))
            Else
                brush = New SolidBrush(SystemColors.MenuText)
            End If
            g.DrawString(text, SystemInformation.MenuFont, brush, x, y, stringformat)
            g.DrawString(shortcut, SystemInformation.MenuFont, brush, bounds.Right - shortcutwidth - 10, bounds.Top + 2, stringformat)
        End Sub
    End Class

    Public Enum eImagenes
        eNew
        eOpen
        eSave
        eCut
        eCopy
        ePaste
        eDelete
        eProperties
        eUndo
        eRedo
        ePreview
        ePrint
        eSearch
        eReSearch
        eHelp
        eZoomIn
        eZoomOut
        eBack
        eForward
        eFavorites
        eAddToFavorites
        eStop
        eRefresh
        eHome
        eVentanaLapiz   'Edit
        eVentanaTools
        eVentanaTiles   ' 2 cuadros
        eVentanaIcons   ' 6 cuadros
        eVentanaListAB  ' List
        eVentanaDivHor  'Details
        eVentanaDivVer  'Pane
        eCulture
        eLanguages
        eHistory
        eMail
        eParent
        eFolderProperties
        '
        egMsgBStop
        egMsgBExclamation
        egMsgBInfo
        egMsgBQuestion
        egMinimize
        egRueda
        egConfig1
        egConfigOk
        egRun
        egCompuTeclado
        egStandBy
        egAltavoz
        egAltavozOff
        EConsigna
        'Ultima = egAltavozOff
    End Enum

    Public Class MImages
        Private mImages As Image()
        Private numImg As Integer

        ' En el constructor pasamos la imagen a usar                    (26/Dic/05)
        Public Sub New(ByVal picImageList16 As Image)
            Dim bmap As New Bitmap(picImageList16)
            numImg = CType((bmap.Width / bmap.Height), Integer) - 1
            ReDim mImages(numImg)
            Dim rect As New Rectangle(0, 0, bmap.Height, bmap.Height)
            For i As Integer = 0 To numImg
                mImages(i) = bmap.Clone(rect, bmap.PixelFormat)
                rect.X += bmap.Height
            Next
        End Sub
        Public Function Images(ByVal index As eImagenes) As Image
            If index > numImg Then
                index = CType(numImg, eImagenes)
            End If
            Return mImages(CType(index, Integer))
        End Function
        Public Function Bitmaps(ByVal index As eImagenes) As Bitmap
            If index > numImg Then
                index = CType(numImg, eImagenes)
            End If
            Return New Bitmap(mImages(CType(index, Integer)))
        End Function
    End Class
#End Region

    Public Function Subir_FTP(ByVal pconfig As String, ByVal pruta_archivo As String) As Boolean
        Dim propiedades(2) As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim lb_regresa As Boolean = False

        ls_log = ""

        'pconfig = "gerber"
        ls_log = "Buscando Configuraciones" & vbCrLf
        otrans.open()
        otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('" & pconfig & "')")
        otrans.close()
        otrans = Nothing


        '        propiedades = otabla.Rows(0).Item("ftp_gerber").ToString.Split(",")
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Copy and paste the code below into a VB WebForm or WinForm
        '  application and then do the following:
        '
        '       1).  From within the ASP.NET or WinForm app set a
        '            reference to the FTP.dll and BitOperators.dll
        '            files.
        '       2).  At the top of the application code file 
        '            (E.g WebForm1.aspx.vb or Form1.vb) type in
        '               Imports FTP
        '       3).  Compile the application and run.
        '       4).  Have fun.

        'Protected Sub TestFTP()
        Dim ff As FTP.clsFTP

        Try
            '        '-------------------------------------------
            '        ' OPTION 1
            '        ' --------
            '        '
            '        ' Create an instance of the FTP Class.
            '            Me.txt_status.Text = "Creando la Instancia"
            ls_log = ls_log & " Creando Instancia FTP " & vbCrLf
            ff = New FTP.clsFTP


            ' Setup the appropriate properties.
            ff.RemoteHost = otabla.Rows(0)("host") '"gtmailmarketing.com"
            ff.RemoteUser = otabla.Rows(0)("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = otabla.Rows(0)("password") '"gerber"
            '        '-------------------------------------------

            '        '-------------------------------------------
            '        ' OPTION 2
            '        ' --------
            '        '  Pass the values into the constructor 
            '        '  instead.  These can be overridden by simply
            '        '  setting the appropriate properties on the
            '        '  instance of the clsFTP Class.
            '        ff = New clsFTP("microsoft", _
            '                        ".", _
            '                        "ftpuser", _
            '                        "password", _
            '                        21)

            '        ' Attempt to log into the FTP Server.
            'Me.txt_status.Text = "Conectando"
            ls_log = ls_log & " Conectando al FTP " & vbCrLf
            If (ff.Login()) Then
                '            '
                '            ' Move the to Area1\Section1\Subby1\ directory.
                If otabla.Rows(0)("Carpeta").ToString.Length > 0 Then
                    ls_log = ls_log & "Moviendo a Carpeta Especifica " & vbCrLf
                    ff.ChangeDirectory(otabla.Rows(0)("Carpeta").ToString)
                End If
                'ff.ChangeDirectory("Section1")

                'ff.CreateDirectory("Subby1")
                'ff.ChangeDirectory("Subby1")
                ff.SetBinaryMode(True)

                '            ' Upload a file.
                'Me.txt_status.Text = "Transfiriendo"
                ls_log = ls_log & " Transfiriendo Archivo " & vbCrLf
                ff.UploadFile(pruta_archivo)

                '            ' Download a file.
                '            'ff.DownloadFile("secureapps.pdf", "d:\general\secureapps.pdf")

                '            ' Remove a file from the FTP Site.
                '            If (ff.DeleteFile("secureapps.pdf")) Then
                '                Response.Write("File has been removed from FTP Site")
                '                'MessageBox.Show("File has been removed from FTP Site")
                '            Else
                '                Response.Write("Unable to remove file from FTP Site.  Message from server: " & ff.MessageString & "<br>")
                '                'MessageBox.Show("Unable to remove file from FTP Site")
                '            End If

                '            ' Rename a file on the FTP Site.
                '            'If (ff.RenameFile("secureapps.pdf", "newapp.pdf")) Then
                '            '    Response.Write("File has been renamed")
                '            '    MessageBox.Show("File has been renamed")
                '            'End If

                '            'ff.ChangeDirectory("..")
                '            'If (ff.RemoveDirectory("Subby1")) Then
                '            '    Response.Write("Directory has been removed<br>")
                '            '    ' MessageBox.Show("Directory has been removed")
                '            'Else
                '            '    Response.Write("Unable to remove the directory.  Message from server: " & ff.MessageString & "<br>")
                '            '    ' MessageBox.Show("Unable to remove the directory.")
                '            'End If
            End If
            'Me.txt_status.Text = "Finalizado Exitosamente"
            ls_log = ls_log & "Transferencia Finalizada Correctamente " & vbCrLf
            lb_regresa = True
            'MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Exception            '        

            'Messagebox.Show(ex.Message)
            'MessageBox.show("Message from FTP Server was: " & ff.MessageString)
            'Me.txt_status.Text = ex.Message & "  " & ff.MessageString
            ls_log = ls_log & "Error: " & ex.Message & vbCrLf
            ls_log = ls_log & "Error: " & ff.MessageString & vbCrLf
            'MsgBox(ex.Message)
            'MsgBox("Message from FTP Server was: " & ff.MessageString)
        Finally
            '        '
            '        ' Always close down the connection to ensure that
            '        '  there are no "stray" Fido's Fetching data.  In
            '        '  other words, no stray/limbo/not-in-use FTP
            '        '  connections.
            ff.CloseConnection()
        End Try

        'statusBar1.Text=string.Format("Logging into {0} ..", txtHost.Text);

        Return lb_regresa
    End Function

    Public Function FTP_Lista_Archivo(ByVal pconfig As String, ByVal ptipo_archivo As String) As String()
        Dim propiedades(2) As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim lb_regresa As Boolean = False
        Dim archivos As String()



        ls_log = ""

        ls_log = "Buscando Configuraciones" & vbCrLf
        otrans.open()
        otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('" & pconfig & "')")
        otrans.close()
        otrans = Nothing


        Dim ff As FTP.clsFTP

        Try

            ls_log = ls_log & " Creando Instancia FTP " & vbCrLf
            ff = New FTP.clsFTP


            ' Setup the appropriate properties.
            ff.RemoteHost = otabla.Rows(0)("host") '"gtmailmarketing.com"
            ff.RemoteUser = otabla.Rows(0)("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = otabla.Rows(0)("password") '"gerber"

            ls_log = ls_log & " Conectando al FTP " & vbCrLf
            If (ff.Login()) Then
                If otabla.Rows(0)("Carpeta").ToString.Length > 0 Then
                    ls_log = ls_log & "Moviendo a Carpeta Especifica " & vbCrLf
                    ff.ChangeDirectory(otabla.Rows(0)("Carpeta").ToString)
                End If
                ff.SetBinaryMode(True)


                archivos = ff.GetFileList("*.txt")

            End If
            ls_log = ls_log & "Transferencia Finalizada Correctamente " & vbCrLf
            lb_regresa = True
        Catch ex As System.Exception            '        

            ls_log = ls_log & "Error: " & ex.Message & vbCrLf
            ls_log = ls_log & "Error: " & ff.MessageString & vbCrLf
        Finally
            ff.CloseConnection()
        End Try

        Return archivos
    End Function

    Public Function Telefonos_Validos(ByVal _pdt As DataTable, ByVal _psnombre_campo As String) As Boolean
        Dim dr As DataRow
        Dim lvalidos As Boolean = True
        Try
            For Each dr In _pdt.Rows
                If dr.Item(_psnombre_campo).ToString.Trim.Length = 8 Or
                    dr.Item(_psnombre_campo).ToString.Trim.Length = 4 Then
                Else
                    lvalidos = False
                End If

            Next
        Catch ex As Exception
            lvalidos = False
        End Try

        Return lvalidos
    End Function

    ''Devuelve los Parametros de las conexiones para Reportes
    Public Function Parametros_Conexion(ByVal _codigo As String) As String()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim pm_parametros(3) As String
        Dim ls_sql As String

        Try

            pm_parametros(0) = ""  'Nombre del ODBC
            pm_parametros(1) = ""  'Base de Datos
            pm_parametros(2) = ""  'Usuario
            pm_parametros(3) = ""  'Pwd

            otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod  " &
            IIf(_codigo.Trim.Length = 0, "NULL", "'" & _codigo & "'") &
                     ",'GEN_PARAMETROS_REPORTES',NULL"
            dt = otrans.Obtiene(ls_sql)

            'If dt.Rows.Count > 0 Then
            '    pm_parametros(0) = dt.Rows(0).Item("CODIGO").ToString ''
            '    pm_parametros(1) = dt.Rows(0).Item("DESCRIPCION").ToString  'Base de Datos
            '    pm_parametros(2) = dt.Rows(0).Item("TEXTO").ToString    'Usuario
            '    pm_parametros(3) = dt.Rows(0).Item("TEXTO1").ToString   'Pws

            'End If

            If dt.Rows.Count > 0 Then
                If _codigo.Length = 0 Then
                    dt.DefaultView.RowFilter = "valor1 = 1 and texto5 = '" & Obtener_XMLConfig("Ubicacion", False) & "'"
                    pm_parametros(0) = dt.DefaultView(0)("CODIGO").ToString ''
                    pm_parametros(1) = dt.DefaultView(0)("DESCRIPCION").ToString  'Base de Datos
                    pm_parametros(2) = dt.DefaultView(0)("TEXTO").ToString    'Usuario
                    pm_parametros(3) = dt.DefaultView(0)("TEXTO1").ToString   'Pws

                Else
                    pm_parametros(0) = dt.Rows(0).Item("CODIGO").ToString ''
                    pm_parametros(1) = dt.Rows(0).Item("DESCRIPCION").ToString  'Base de Datos
                    pm_parametros(2) = dt.Rows(0).Item("TEXTO").ToString    'Usuario
                    pm_parametros(3) = dt.Rows(0).Item("TEXTO1").ToString   'Pws
                End If
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return pm_parametros
    End Function

    Public Function Parametros_Conexion(ByVal _ubicacion As Integer, ByVal _tipo_conexion As String) As DataTable
        Dim dt As New DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String

        Try
            'ls_sql = "call pa_var_um_pg_ubicacion_conexiones (" & _ubicacion.ToString & ",'" & _tipo_conexion & "')"
            'myOtrans.open()
            ls_sql = "pa_var_um_pg_ubicacion_conexiones " & _ubicacion.ToString & "," & _tipo_conexion & "'"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = selectQuery("Corporativo", ls_sql)

        Catch ex As Exception
        Finally
            '   myOtrans.close()
            '  myOtrans = Nothing
        End Try
        Return dt
    End Function

    Public Function Path_Reporte() As String
        Dim lspath As String = ""
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lspath = dt.Rows(0).Item("path_reportes").ToString

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lspath
    End Function

    Public Function Path_fileserver() As String
        Dim lspath As String = ""
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lspath = dt.Rows(0).Item("path_fileserver").ToString

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lspath
    End Function


    Public Function Path_Logos() As String
        Dim lspath As String = ""
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lspath = dt.Rows(0).Item("path_logos").ToString

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lspath
    End Function

    Public Function Path_Imagenes() As String
        Dim lspath As String = ""
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lspath = dt.Rows(0).Item("path_imagenes").ToString

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lspath
    End Function

    Public Function Bodegas() As String()
        Dim lsbodegas() As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lsbodegas = dt.Rows(0).Item("bodegas").ToString.Split(",")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lsbodegas

    End Function


    Public Function Escribir_Log(ByVal _texto_log As String) As Boolean
        Dim exitoso As Boolean = True


        exitoso = Escribir_texto("c:\aplicaciones\" & gsNombreInicialLog & ".txt",
                        Now.ToString & " " & _texto_log & vbCrLf)

        Return exitoso
    End Function

    Public Function Escribir_texto(ByVal _pnombre_archivo As String, ByVal _plinea As String) As Boolean
        Dim myStreamWriter As StreamWriter

        Dim lexito As Boolean = True
        Try




            myStreamWriter = File.AppendText(_pnombre_archivo)

            myStreamWriter.Write(_plinea)
            myStreamWriter.Flush()
            myStreamWriter.Close()
            myStreamWriter = Nothing

        Catch ex As Exception
            lexito = False
        End Try

        Return lexito

    End Function

    Public Function Eliminar_Archivo(ByVal _pnombre_archivo As String) As Boolean
        Dim lexito As Boolean = True

        Try
            File.Delete(_pnombre_archivo)
        Catch ex As Exception
            lexito = False
        End Try
        Return lexito

    End Function

    Public Function Copiar_Archivo(ByVal _nombre_archivo_origen As String, ByVal _nombre_archivo_destino As String, ByVal _sobreescribir As Boolean) As Boolean
        Dim lexito As Boolean = True

        Try
            'File.Delete(_pnombre_archivo)
            If File.Exists(_nombre_archivo_destino) Then

                If _sobreescribir Then
                    File.SetAttributes(_nombre_archivo_destino, FileAttributes.Temporary)
                    File.Delete(_nombre_archivo_destino)
                End If

            End If

            File.Copy(_nombre_archivo_origen, _nombre_archivo_destino)


        Catch ex As Exception
            Me.Escribir_Log(ex.ToString)
            lexito = False
        End Try
        Return lexito


    End Function

    Public Function Mover_Archivo(ByVal _nombre_archivo_origen As String, ByVal _nombre_archivo_destino As String)
        Dim lexito As Boolean = True
        Try
            If File.Exists(_nombre_archivo_origen) Then
                File.Delete(_nombre_archivo_destino)
            End If
            File.Move(_nombre_archivo_origen, _nombre_archivo_destino)
        Catch ex As Exception
            lexito = False
        End Try
        Return (lexito)

    End Function

    Public Function Modificar_XMLConfig(ByVal seccion As String,
                            ByVal clave As String,
                            ByVal valor As String,
                            ByVal configxml As XmlDocument,
                            ByVal nombre_archivo As String) As Boolean
        '
        Dim n As XmlNode
        Dim exitoso As Boolean = False

        Try
            n = configxml.SelectSingleNode(seccion & "/add[@key=""" & clave & """]")
            If Not n Is Nothing Then
                n.Attributes("value").InnerText = valor
            End If
            configxml.Save(nombre_archivo)
            exitoso = True
        Catch ex As Exception


        End Try



        Return exitoso
    End Function

    Public Function Obtener_XMLConfig(ByVal _clave As String, ByVal _procesar As Boolean, Optional pbLlenarlog As Boolean = True) As String

        Dim svalor_clave As String = ""

        Dim Data1 As String = ""
        Dim sData As String = ""

        Dim aval(1) As String



        Try


            svalor_clave = System.Configuration.ConfigurationManager.AppSettings(_clave).ToString
            If _procesar Then

                Do While (svalor_clave.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(svalor_clave.Substring(0, 2), 16)).ToString()
                    sData = sData + Data1
                    svalor_clave = svalor_clave.Substring(2, svalor_clave.Length - 2)
                Loop
                svalor_clave = sData
            End If

        Catch ex As Exception
            If pbLlenarlog Then
                Escribir_Log("obtener Clave " & _clave)
                Escribir_Log(ex.ToString)
            End If
        Finally
        End Try

        Return svalor_clave

    End Function

    Public Sub Comprimir_Archivo(ByVal _folderOrigen As String, ByVal _archivoOrigen As String,
                                    ByVal _folderDestino As String, ByVal _archivoDestino As String)



        Dim sc As Shell32.ShellClass
        Dim srf As Shell32.FolderItem
        Dim src As Shell32.Folder
        Dim dst As Shell32.Folder

        '----- Check the file for a .zip extenstion.
        'strdest += _archivoDestino
        If System.IO.Path.GetExtension(_archivoDestino).ToUpper.EndsWith(".ZIP") = False Then
            _archivoDestino += ".zip"
        End If
        If _archivoDestino.IndexOf(" ") <> -1 Then
            _archivoDestino = """" & _archivoDestino & """"
        End If

        '----- Binary Array representing a zip file header.
        Dim emptyZip As Byte() = New Byte() {80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}



        '----- Write out the zip file
        Dim fs As FileStream = File.Create(_folderDestino & _archivoDestino)

        fs.Write(emptyZip, 0, emptyZip.Length)
        fs.Flush()
        fs.Close()
        fs = Nothing

        sc = New Shell32.ShellClass
        src = sc.NameSpace(_folderOrigen)

        If _archivoOrigen.Length > 0 Then
            srf = src.Items().Item(_archivoOrigen)
        End If

        dst = sc.NameSpace(_folderDestino & _archivoDestino)
        '----- Begining File Compression in System Controlled Thread

        If _archivoOrigen.Length > 0 Then
            dst.CopyHere(srf, 20)
        Else
            dst.CopyHere(src, 20)
        End If



        '----- Sleep to allow the compression thread to begin execution
        'System.Threading.Thread.CurrentThread.Sleep(5000) ' 5 seconds is usually more than enough
        Threading.Thread.Sleep(5000)


    End Sub

    Public Sub Descomprimir_Archivo(ByVal _archivoOrigen As String, ByVal _pathDestino As String)
        'Dim sourcefile As String = "c:\sincronizacion\envio_catalogos\2.zip"

        'If Right(sourcefile.ri, 1) = “\” Then sourcefile = Left(sourcefile, Len(sourcefile) – 1)
        'Dim sPath As String = "c:\sincronizacion\envio_catalogos\" '= Left(sourcefile, InStrRev(sourcefile, " \ "))"

        Dim myShell As New Shell32.Shell
        Dim sourceFolder As Shell32.Folder = myShell.NameSpace(_archivoOrigen)
        Dim destinationFolder As Shell32.Folder = myShell.NameSpace(_pathDestino)
        Try
            Dim i As Integer
            For i = 0 To sourceFolder.Items.Count - 1
                If System.IO.File.Exists(destinationFolder.Items.Item.Path & "\" & sourceFolder.Items.Item(i).Name) Then _
                System.IO.File.Delete(destinationFolder.Items.Item.Path & "\" & sourceFolder.Items.Item(i).Name)
                destinationFolder.CopyHere(sourceFolder.Items.Item(i))
                ' Console.WriteLine("Unzipped " & sourceFolder.Items.Item(i).Name & " to " & destinationFolder.Items.Item.Path)
            Next
            'Return 0
        Catch ex As Exception
            'Console.WriteLine("Could not unzip from " & sourcefile & " to " & destinationFolder.Items.Item.Path)
            'Console.WriteLine("Error: " & Err.Description)
            'Return Err.Number
        Finally
            destinationFolder = Nothing
            sourceFolder = Nothing
            myShell = Nothing
        End Try
    End Sub

    Public Sub Generar_Backup(ByVal _path As String, ByVal _archivo As String)
        Dim pwd As String
        Dim comando As String

        pwd = Obtener_XMLConfig("linea3_sam", True)

        '_dt.Rows(0).Item("path_mysql").ToString()
        comando = _path & "\mysqldump" &
            " --user=root --password=" & pwd & " --databases sam -r " & _archivo

        Shell(comando, AppWinStyle.MinimizedFocus, True)
        'System.Threading.Thread.CurrentThread.Sleep(5000) ' 5 seconds is usually more than enough
        Threading.Thread.Sleep(5000)

    End Sub

    Public Enum CryptoAction
        'Define the enumeration for CryptoAction.

        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Function CreateKey(ByVal strPassword As String) As Byte()
        Dim bytKey As Byte()
        Dim bytSalt As Byte() = System.Text.Encoding.ASCII.GetBytes("salt")
        Dim pdb As New PasswordDeriveBytes(strPassword, bytSalt)

        bytKey = pdb.GetBytes(32)

        Return bytKey 'Return the key.

    End Function

    Private Function CreateIV(ByVal strPassword As String) As Byte()
        Dim bytIV As Byte()
        Dim bytSalt As Byte() = System.Text.Encoding.ASCII.GetBytes("salt")
        Dim pdb As New PasswordDeriveBytes(strPassword, bytSalt)

        bytIV = pdb.GetBytes(16)

        Return bytIV 'Return the IV.

    End Function

    Public Sub EncriptarArchivo(ByVal strInputFile As String,
                                    ByVal strOutputFile As String,
                                    ByVal Direction As CryptoAction)


        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream
        Dim lgenero_errores As Boolean = False

        'Declare variables for encrypt/decrypt process.
        fsInput = New System.IO.FileStream(strInputFile, FileMode.Open,
                                      FileAccess.Read)
        fsOutput = New System.IO.FileStream(strOutputFile,
                                               FileMode.OpenOrCreate,
                                               FileAccess.Write)
        fsOutput.SetLength(0) 'make sure fsOutput is empty

        Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing

        Dim lngBytesProcessed As Long = 0 'running count of bytes processed

        Dim lngFileLength As Long = fsInput.Length 'the input file's length

        Dim intBytesInCurrentBlock As Integer 'current bytes being processed

        Dim csCryptoStream As CryptoStream

        Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged

        Try


            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateEncryptor(CreateKey("Cdc$Mr"), CreateIV("Cdc$Mr")),
                    CryptoStreamMode.Write)

                Case CryptoAction.ActionDecrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateDecryptor(CreateKey("Cdc$Mr"), CreateIV("Cdc$Mr")),
                    CryptoStreamMode.Write)

            End Select

            'Use While to loop until all of the file is processed.

            While lngBytesProcessed < lngFileLength
                'Read file with the input filestream.

                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                'Write output file with the cryptostream.

                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                'Update lngBytesProcessed

                lngBytesProcessed = lngBytesProcessed +
                                        CLng(intBytesInCurrentBlock)
                'Update Progress Bar

                '  pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
            End While

            'Close FileStreams and CryptoStream.




        Catch ex As CryptographicException
            'MessageBox.Show(ex.ToString)
            lgenero_errores = True
        Catch ex As Exception
        Finally
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()
        End Try

        If lgenero_errores Then
            Dim ClsGen As New ClasesGenerales.General
            ClsGen.Eliminar_Archivo(strOutputFile)
            ClsGen = Nothing
        End If

    End Sub

    Public Sub Actualizar_Version(ByVal nombre_equipo As String, ByVal nombre_sistema As String,
                                ByVal version As String, ByVal _nombre_conexion As String, ByVal _
                                _direccion_ip As String, ByVal _pst As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)
        Dim ls_Sql As String

        Try
            myOtrans.open()
            ls_Sql = "call pa_ins_um_sg_usuario_version_sistema ('" & nombre_equipo & "','" & nombre_sistema & "','" & version & "','" & _direccion_ip & "'," & _pst.ToString & ")"
            myOtrans.Ingresa(ls_Sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try


    End Sub

    Public Function Verificar_Conexiones(ByVal _conexiones As String) As Boolean
        'Dim icount As Integer
        Dim sinc As Sincronizacion.Productos
        Dim conexiones As Boolean = True
        'Dim Aconexiones As String() = _conexiones.Split(",")
        Dim conexion_actual As String
        Try

            For Each conexion_actual In _conexiones.Split(",")
                If conexion_actual.Length > 0 Then


                    sinc = New Sincronizacion.Productos(conexion_actual)
                    If sinc.codigo_error > 0 Then
                        sinc = Nothing

                        Escribir_texto("c:\aplicaciones\log.txt", Now.ToString & " No se puede Tener Acceso a " & conexion_actual & " " & vbCrLf)
                        ' MessageBox.Show("En Este Momento No se Puede Operar Este Memo en " & Me.chk_ubicaciones.Items(icount)("nombre_bodega").ToString & _
                        '                Chr(13) & "Por Favor Intente Mas Tarde", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        conexiones = False
                    End If
                End If

            Next
        Catch ex As Exception
            conexiones = False
        Finally
            sinc = Nothing
        End Try
        Return conexiones

    End Function

    Public Function Codigo_Empresa_Onbase(ByVal nombre_empresa As String) As Integer
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Dim dt As DataTable
        Dim codigo_empresa As Integer = 0
        Try
            'myOtrans.open()
            'dt = myOtrans.Obtiene("call pa_sel_um_pg_empresa()")
            dt = selectQuery("corporativo", "pa_sel_um_pg_empresa")
            dt.DefaultView.RowFilter = "descripcion = '" & nombre_empresa & "'"
            If dt.DefaultView.Count > 0 Then
                codigo_empresa = dt.DefaultView(0).Item("cod_empresa").ToString
            End If


        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing


        End Try
        Return codigo_empresa

    End Function

    'Public Function Fecha_Servidor(ByVal Conexion As String) As DataTable
    '    Dim dt As New DataTable
    '    Dim Otrans As New Transaccional.Conexion(Conexion)
    '    Try
    '        Otrans.abrir()


    '        dt = Otrans.Obtiene("Select getdate() as Fecha_Actual")
    '    Catch ex As Exception
    '    Finally
    '        Otrans.close()
    '        Otrans = Nothing
    '    End Try
    '    Return dt
    'End Function

    Public Function Fecha_Servidor(ByVal Conexion As String) As DataTable
        Dim dt As New DataTable
        Dim Otrans As New Transaccional.Conexion(Conexion)
        Dim ClsGen As New ClasesGenerales.General
        Try
            Otrans.abrir()
            Dim zonaHoraria As String = "0"

            Try
                zonaHoraria = ClsGen.Obtener_XMLConfig("ZonaHoraria", False)
            Catch ex As Exception
                zonaHoraria = "0"
            End Try

            'DATEADD(hour,-6, getdate())
            dt = Otrans.Obtiene("Select DATEADD(hour," & zonaHoraria & ", getdate()) as Fecha_Actual")
            ClsGen.Escribir_Log("Zona horaria " & dt.Rows(0)(0))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return dt
    End Function

    Public Function Obtener_Usuario_Sistema(ByVal pnombre_sistema As String, ByVal pnombre_conexion As String) As DataTable
        Dim dt As New DataTable
        Dim ls_sql As String



        Dim otrans As New Transaccional.Conexion_mysql(pnombre_conexion)

        Try

            otrans.open()

            ls_sql = "call pa_sel_um_seg_usuario_sistema ('" & System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName)(0).ToString & "', '" & pnombre_sistema & "')"
            dt = otrans.Obtiene(ls_sql)

            ls_sql = "call pa_del_um_seg_usuario_sistema ('" & System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName)(0).ToString & "', '" & pnombre_sistema & "')"
            otrans.Elimina(ls_sql)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Path_Actualizaciones() As String
        Dim lspath As String = ""
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_gen_parametros_sistema")
            lspath = dt.Rows(0).Item("path_actualizacion").ToString

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return lspath
    End Function

    Public Function ValoresDistinto(ByVal tablaOrigen As DataTable, ByVal columnas As String()) As DataTable
        Dim vista As DataView = New DataView(tablaOrigen)
        Return vista.ToTable(True, columnas)

    End Function

    Public Sub mostrarAyuda(ByVal nombreArchivo As String)
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql, ls_rutamanual As String


        Dim proceso As New Process
        ls_sql = "pa_sel_um_gen_parametros_sistema"
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            ls_rutamanual = dt.Rows(0).Item("path_manuales").ToString.Trim
            ls_rutamanual += nombreArchivo '"memospromocionales.pdf"

            proceso.Start(ls_rutamanual)



        Catch ex As Exception
        Finally
            proceso = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Public Function usuariosAviso(ByVal pcodAviso As Integer) As DataTable
        Dim dt As New DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")

        Try
            myOtrans.open()
            dt = myOtrans.Obtiene("call pa_sel_um_seg_usuario_aviso_sistema (" & pcodAviso & ")")

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
        Return dt
    End Function

    Public Function guardarAviso(ByVal pusaurio As String, ByVal psistema As String, ByVal pmensaje As String, ByVal cod_aviso As Integer) As Integer
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim lsSQL As String
        Dim numeroAviso As Integer = -1
        Dim dt As DataTable

        Try
            myOtrans.open()
            lsSQL = "call pa_ins_um_seg_usuario_aviso ('" & pusaurio & "','" & psistema & "','" & pmensaje & "'," & cod_aviso & ")"
            myOtrans.Ingresa(lsSQL)
            If myOtrans.Codigo_error = 0 Then
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                numeroAviso = dt.Rows(0).Item("newid").ToString
                'Me.lbl_numero.Text = dt.Rows(0).Item("newid").ToString
            End If



        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return numeroAviso
    End Function

    Public Sub guardarAvisoDetalle(ByVal piaviso As Integer, ByVal pstexto1 As String, ByVal pstexto2 As String, ByVal pstexto3 As String, ByVal pdvalor1 As Double, ByVal pdvalor2 As Double, ByVal pdvalor3 As Double)
        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
        Dim lsSQL As String

        Try
            myOtrans.open()
            lsSQL = "call pa_ins_um_seg_usuario_aviso_detalle (" & piaviso & ",'" & pstexto1 & "','" & pstexto2 & "','" & pstexto3 & "'," & pdvalor1 & "," & pdvalor2 & "," & pdvalor3 & ")"
            myOtrans.Ingresa(lsSQL)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Public Function marcasEmpleado(ByVal sUsuario As String) As DataTable

        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_gen_tabcod null,'con_marca',null")
            If sUsuario.Length > 0 Then
                dt.DefaultView.RowFilter = "texto3 = '" & sUsuario & "'"
                dt = dt.DefaultView.ToTable
            End If



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Public Function Escribir_textoASCII(ByVal _pnombre_archivo As String, ByVal _plinea As String) As Boolean
        Dim myStreamWriter As StreamWriter

        Dim lexito As Boolean = True
        Try
            'myStreamWriter = File.AppendText(_pnombre_archivo)
            'myStreamWriter =
            File.AppendAllText(_pnombre_archivo, _plinea, Encoding.Default)
            'myStreamWriter.Write(_plinea)
            'myStreamWriter.Flush()
            'myStreamWriter.Close()
            'myStreamWriter = Nothing

        Catch ex As Exception
            lexito = False
        End Try

        Return lexito

    End Function
    Public Sub fillComboBox(ByVal conexion As Transaccional.Conexion, ByVal ls_sql As String, ByVal tableName As String, ByVal displaymember As String, ByVal valuemember As String, ByVal cmb As ComboBox)
        Dim dt, dtaux As New DataTable
        conexion.open()
        dt = conexion.Obtiene(ls_sql)
        conexion.close()
        'dtaux.Columns.Add(dt.Copy.Columns(displaymember))
        dt.TableName = tableName
        cmb.DisplayMember = displaymember
        cmb.ValueMember = valuemember
        cmb.DataSource = dt.DefaultView

        dt = Nothing
    End Sub

    Public Function dbQuery(ByVal con As String, ByVal ls_sql As String, ByVal tipo As String, Optional ByVal tipoCon As String = "SERVER") As DataTable
        Dim conexion As Transaccional.Conexion
        Dim myConexion As Transaccional.Conexion_mysql
        If (tipoCon.Equals("SERVER")) Then
            conexion = New Transaccional.Conexion(con)
            Dim dt As New DataTable
            Try
                conexion.open()
                If (tipo = "INSERT") Then
                    conexion.Ingresa(ls_sql)
                ElseIf (tipo = "UPDATE") Then
                    conexion.Actualiza(ls_sql)
                ElseIf (tipo = "DELETE") Then
                    conexion.Elimina(ls_sql)
                ElseIf (tipo = "SELECT") Then
                    dt = conexion.Obtiene(ls_sql)
                End If
            Catch ex As Exception

            Finally
                conexion.close()
                conexion = Nothing

            End Try
            Return dt
        ElseIf (tipoCon.Equals("MYSQL")) Then
            myConexion = New Transaccional.Conexion_mysql(con)
            Dim dt As New DataTable
            Try
                myConexion.open()
                If (tipo = "INSERT") Then
                    myConexion.Ingresa(ls_sql)
                ElseIf (tipo = "UPDATE") Then
                    myConexion.Actualiza(ls_sql)
                ElseIf (tipo = "DELETE") Then
                    myConexion.Elimina(ls_sql)
                ElseIf (tipo = "SELECT") Then
                    dt = myConexion.Obtiene(ls_sql)
                End If
            Catch ex As Exception

            Finally
                myConexion.close()
                myConexion = Nothing

            End Try
            Return dt
        End If



    End Function
    Public Sub insertLogBD(ByVal con As String, ByVal ls_sql As String, ls_usuario As String, ls_modulo As String, ls_opcion As String, ls_Version As String)
        Dim conexion As New Transaccional.Conexion(con, ls_usuario)
        Try
            'conexion.setSistema(Application.ProductName, Application.ProductVersion, ls_modulo, ls_opcion)
            conexion.setSistema(Application.ProductName, ls_Version, ls_modulo, ls_opcion)
            conexion.open()
            conexion.Ingresa(ls_sql, True)
        Catch ex As Exception

        Finally
            conexion.close()
            conexion = Nothing
        End Try
    End Sub

    Public Sub insertQuery(ByVal con As String, ByVal ls_sql As String, ls_usuario As String)
        'Dim conexion As New Transaccional.Conexion(con, ls_usuario)
        'Try
        '    conexion.open()
        '    conexion.Ingresa(ls_sql, True)
        'Catch ex As Exception

        'Finally
        '    conexion.close()
        '    conexion = Nothing
        'End Try
    End Sub

    Public Sub insertQuery(ByVal con As String, ByVal ls_sql As String)
        Dim conexion As New Transaccional.Conexion(con)
        Try
            conexion.open()
            conexion.Ingresa(ls_sql)

        Catch ex As Exception

        Finally
            conexion.close()
            conexion = Nothing
        End Try
    End Sub

    Public Function selectQuery(ByVal con As String, ByVal ls_sql As String) As DataTable
        Dim conexion As New Transaccional.Conexion(con)
        Dim dt As New DataTable
        Try
            conexion.open()
            dt = conexion.Obtiene(ls_sql)
        Catch ex As Exception

        Finally
            conexion.close()
            conexion = Nothing
        End Try
        Return dt
    End Function


    Public Function selectmyQuery(ByVal con As String, ByVal ls_sql As String) As DataTable
        Dim conexion As New Transaccional.Conexion_mysql(con)
        Dim dt As New DataTable
        Try
            conexion.open()
            dt = conexion.Obtiene(ls_sql)
        Catch ex As Exception

        Finally
            conexion.close()
            conexion = Nothing
        End Try
        Return dt
    End Function


    Public Function numeroCopias(ByVal psempresa As String, psCliente As String, psFormaPago As String, piRefacturacion As Integer, ByVal psTipoDocto As String) As Integer

        Dim lnCopias As Integer = 3

        Dim dt As DataTable

        Try
            dt = selectQuery("FlexLine", "pa_var_um_ctacte_copias '" & psempresa & "','" & psCliente & "','" & psFormaPago & "'," & piRefacturacion & ",'" & psTipoDocto & "'")
            If dt.Rows.Count > 0 Then
                lnCopias = dt.Rows(0).Item("copias")
            End If
        Catch ex As Exception

        End Try


        Return lnCopias

    End Function


    Public Sub enviarcorreo_html(psCuentaCorreo As String, psSubject As String, sBody As String, psImagen As String, psRutaAdjunto As String,
                         psCuentaCorreoEnvia As String, psNombreCorreoEnvia As String)



        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2


        Dim clsGen As New ClasesGenerales.General

        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient

        Dim adjuntar As Net.Mail.Attachment

        Dim dt As DataTable



        Try
            Message = New System.Net.Mail.MailMessage()
            'Dim adjuntar As New Net.Mail.Attachment(ruta)
            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
            SMTP1.EnableSsl = True


            'Copia para auditoria
            Try
                Dim sCorreoAuditoria As String
                Dim lsCuentasAudtoria As String = String.Empty
                sCorreoAuditoria = clsGen.Obtener_XMLConfig("correo_auditoria", False)
                If sCorreoAuditoria.Length > 0 Then

                    Dim dtCorreo As DataTable




                    For Each scuenta As String In sCorreoAuditoria.Split(",")

                        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & scuenta & "'")

                        If dtCorreo.Rows.Count > 0 Then
                            If lsCuentasAudtoria.Length > 0 Then lsCuentasAudtoria += ","

                            lsCuentasAudtoria += dtCorreo.Rows(0).Item("correo")
                        End If

                    Next


                    Message.[Bcc].Add(lsCuentasAudtoria)

                End If



            Catch ex As Exception

            End Try


            dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

            Message.[To].Add(psCuentaCorreo)


            Message.From = New System.Net.Mail.MailAddress(psCuentaCorreoEnvia, psNombreCorreoEnvia, System.Text.Encoding.UTF8) 'Quien envía el e-mail


            'Dim l_lnkres As LinkedResource
            Dim l_altview As AlternateView
            Try


                Dim l_lnkres As New LinkedResource(psImagen, MediaTypeNames.Image.Jpeg)
                l_lnkres.ContentId = Guid.NewGuid().ToString

                sBody = "<table style='width:100%; cellpadding:0px; cellspacing:0px;'>" +
                        "<tr><td><img src='cid:" + l_lnkres.ContentId + "' /></td></tr>" +
                        "</table><br />" + sBody

                l_altview = AlternateView.CreateAlternateViewFromString(sBody, Nothing, MediaTypeNames.Text.Html)
                l_altview.LinkedResources.Add(l_lnkres)
                Message.AlternateViews.Add(l_altview)
            Catch ex As Exception

            End Try



            'l_altview = AlternateView.CreateAlternateViewFromString(sBody)





            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = sBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True



            Try
                If psRutaAdjunto.Trim.Length > 0 Then
                    adjuntar = New Net.Mail.Attachment(psRutaAdjunto)
                End If


                Message.Attachments.Add(adjuntar)
            Catch ex As Exception

            End Try



            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(psSubject)
            clsGen.Escribir_Log(ex.ToString)

        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try
    End Sub




    Public Sub enviarcorreo(psRemitente As String,
                            psNombreRemitente As String,
                            psCuentas As String,
                            psSubject As String,
                            psBody As String,
                            psRutaAdjunto As String,
                            Optional ByVal psCuentasCopia As String = "")




        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2

        Dim sta_mer As String
        Dim nrow As Integer
        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim ls_sql As String
        Dim sBody As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim adjuntar As Net.Mail.Attachment
        Try


            Message = New System.Net.Mail.MailMessage()

            If psRutaAdjunto.Trim.Length > 0 Then
                adjuntar = New Net.Mail.Attachment(psRutaAdjunto)
            End If

            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com"
            SMTP1.EnableSsl = True


            dt = selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            'SMTP1.Credentials = New Net.NetworkCredential("chernandez_logi", "Umbral15")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)
            'SMTP1.Credentials = New System.Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            'Message.[To].Add(psCuentaCorreo)
            '132

            Try
                'For Each cuenta As String In psCuentas.Split(";")
                Message.[To].Add(psCuentas)
                'Next

            Catch ex As Exception

            End Try

            Try
                If psCuentasCopia.Length > 0 Then
                    Message.[CC].Add(psCuentasCopia)
                End If
            Catch ex As Exception

            End Try

            Message.From = New System.Net.Mail.MailAddress(psRemitente, psNombreRemitente, System.Text.Encoding.UTF8) 'Quien envía el e-mail
            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = psBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True
            Try
                Message.Attachments.Add(adjuntar)
            Catch ex As Exception

            End Try


            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try

    End Sub



    Public Sub enviarMensajeTeams(psUserOffice As String, psSubject As String, psBodyMessage As String)


        Try






            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & psUserOffice & """,
              ""Motivo"": """ & psSubject & """,
              ""Mensaje_a_enviar"": """ & psBodyMessage & """
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



            'Console.ReadLine()
        Catch ex As Exception

        End Try



    End Sub


    Public Function validarHorarioTareaAppConfig(psNombreTarea As String) As Boolean

        Dim lbAplicar As Boolean = vbFalse



        Try
            '(c) 20230808
            Dim hora1, minuto1, minuto2 As Integer
            Dim horario As String

            horario = Obtener_XMLConfig("horario1_" + psNombreTarea, False)



            hora1 = Val(horario.Split(":")(0))



            If Now.Hour = hora1 Then
                If horario.IndexOf("-") > 0 Then
                    minuto1 = Val(horario.Split(":")(1).Split("-")(0))
                    minuto2 = Val(horario.Split(":")(1).Split("-")(1))
                    If Now.Minute > minuto1 And Now.Minute < minuto2 Then
                        lbAplicar = True
                        Exit Try
                    End If
                Else
                    minuto1 = Val(horario.Split(":")(1))
                    If Now.Minute < minuto1 Then
                        lbAplicar = True
                        Exit Try
                    End If
                End If

            End If

            horario = Obtener_XMLConfig("horario2_" + psNombreTarea, False)

            hora1 = Val(horario.Split(":")(0))



            If Now.Hour = hora1 Then
                If horario.IndexOf("-") > 0 Then
                    minuto1 = Val(horario.Split(":")(1).Split("-")(0))
                    minuto2 = Val(horario.Split(":")(1).Split("-")(1))
                    If Now.Minute > minuto1 And Now.Minute < minuto2 Then
                        lbAplicar = True
                        Exit Try
                    End If
                Else
                    minuto1 = Val(horario.Split(":")(1))
                    If Now.Minute < minuto1 Then
                        lbAplicar = True
                        Exit Try
                    End If
                End If

            End If


            horario = Obtener_XMLConfig("horario3_" + psNombreTarea, False)
            hora1 = Val(horario.Split(":")(0))



            If Now.Hour = hora1 Then
                If horario.IndexOf("-") > 0 Then
                    minuto1 = Val(horario.Split(":")(1).Split("-")(0))
                    minuto2 = Val(horario.Split(":")(1).Split("-")(1))
                    If Now.Minute > minuto1 And Now.Minute < minuto2 Then
                        lbAplicar = True
                        Exit Try
                    End If
                Else
                    minuto1 = Val(horario.Split(":")(1))
                    If Now.Minute < minuto1 Then
                        lbAplicar = True
                        Exit Try
                    End If
                End If

            End If


        Catch ex As Exception

        End Try





        Return lbAplicar

    End Function


    Public Function ValidarHorarioTareaRecurrenteAppConfig(psNombreTarea As String) As Boolean
        Dim ahora As DateTime = DateTime.Now
        Dim indice As Integer = 1

        Try
            While True
                ' Armamos la key: horario1_tarea, horario2_tarea, etc.
                Dim clave As String = $"horario{indice}_{psNombreTarea}"
                Dim horario As String = Obtener_XMLConfig(clave, False, False)

                ' Si ya no hay valor, asumimos que no hay más horarios configurados
                If String.IsNullOrWhiteSpace(horario) Then
                    Exit While
                End If

                ' Identificador único por tarea + horario (ej: ejecucion_laincondicional_H1)
                Dim idHorario As String = $"{psNombreTarea}_H{indice}"

                ' Si alguno de los horarios aplica, devolvemos True
                If EsHorarioValido(horario, ahora) Then
                    ' Solo permitir si NO se ha ejecutado aún en esta fecha
                    If Not YaSeEjecutoHoy(idHorario, ahora) Then
                        RegistrarEjecucion(idHorario, ahora)
                        Return True  ' Se dispara la tarea una única vez
                    End If

                End If

                indice += 1
            End While

        Catch ex As Exception
            ' Manejo de errores/log si quieres
        End Try

        Return False
    End Function


    '---------------------------------------------------------
    ' Valida un horario en formato:
    '   HH:mm        (ej. 12:04  -> Now.Minute < 4)
    '   HH:mm-mm2    (ej. 18:20-25 -> 20 < Now.Minute < 25)
    '---------------------------------------------------------
    Private Function EsHorarioValido(horario As String, ahora As DateTime) As Boolean
        Try
            Dim partesHora = horario.Split(":"c)
            Dim hora As Integer = CInt(partesHora(0))

            ' Primero validamos la hora
            If ahora.Hour <> hora Then
                Return False
            End If

            Dim parteMinutos As String = partesHora(1)

            ' Rango de minutos: HH:mm1-mm2
            If parteMinutos.Contains("-"c) Then
                Dim rangos = parteMinutos.Split("-"c)
                Dim minutoInicio As Integer = CInt(rangos(0))
                Dim minutoFin As Integer = CInt(rangos(1))

                ' Conservo tu misma lógica: > inicio y < fin
                If ahora.Minute > minutoInicio AndAlso ahora.Minute < minutoFin Then
                    Return True
                End If

            Else
                ' Un solo minuto: HH:mm
                Dim minutoLimite As Integer = CInt(parteMinutos)

                ' Conservo tu lógica: minuto actual < minuto configurado
                If ahora.Minute < minutoLimite Then
                    Return True
                End If
            End If

        Catch ex As Exception
            ' Si el formato es inválido, simplemente devolvemos False
            Return False
        End Try

        Return False
    End Function


    ' Devuelve True si este horario ya se ejecutó HOY
    Private Function YaSeEjecutoHoy(idHorario As String, ahora As DateTime) As Boolean
        Dim ultimaEjecucion As DateTime? = ObtenerUltimaEjecucion(idHorario)

        If ultimaEjecucion.HasValue Then
            ' Si la última ejecución fue hoy, no ejecutar otra vez
            If ultimaEjecucion.Value.Date = ahora.Date Then
                Return True
            End If
        End If

        Return False
    End Function

    ' Marca que este horario ya se ejecutó (para que no se repita)
    Private Sub RegistrarEjecucion(idHorario As String, fecha As DateTime)
        ' Aquí guardas en BD / archivo / tabla según lo que uses.
        ' Ejemplo conceptual:
        ' INSERT INTO LogTareas(IdHorario, FechaHoraEjecucion) VALUES(@idHorario, @fecha)

        Dim lsSQL As String
        lsSQL = "pa_ins_um_pg_TareaEjecucion_Registrar '" & idHorario & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Environment.MachineName & "'"
        insertQuery("SCM", lsSQL)
    End Sub

    ' Lee la última vez que se ejecutó este horario
    Private Function ObtenerUltimaEjecucion(idHorario As String) As DateTime?
        ' Aquí lees de tu almacenamiento.
        ' Ejemplo conceptual:
        ' SELECT MAX(FechaHoraEjecucion) FROM LogTareas WHERE IdHorario = @idHorario

        ' Por ahora devuelvo Nothing para que compilen los ejemplos

        Dim dt As DataTable
        Dim lsSQL As String
        lsSQL = "pa_sel_um_pg_TareaEjecucion_ObtenerUltima '" & idHorario & "'"
        dt = selectQuery("SCM", lsSQL)
        Try
            If dt Is Nothing OrElse dt Is DBNull.Value Or dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0).Item("FechaHoraEjecucion")
            End If

        Catch ex As Exception
            Return Nothing
        End Try

        'Return Nothing
    End Function


End Class


#End Region

#Region " DataGridComboBoxColumn"
''Clase para agregar un ComboBox a un DataGrid  
Public Class DataGridComboBoxColumn
    Inherits DataGridTextBoxColumn
    Public ColumnComboBox As ComboSinKeyUp 'Atención aquí con esta declaración
    Private _Origen As System.Windows.Forms.CurrencyManager
    Private _NroRenglon As Integer
    Private _EstaEditando As Boolean
    Public Shared _RowCount As Integer

    Public Sub New()
        _Origen = Nothing
        _EstaEditando = False
        _RowCount = -1


        ColumnComboBox = New ComboSinKeyUp
        ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        AddHandler ColumnComboBox.Leave, AddressOf DejaComboBox
        AddHandler ColumnComboBox.SelectionChangeCommitted, AddressOf ComienzaEditarCombo

    End Sub

    Private Sub ManejaScroll(ByVal sender As Object, ByVal e As EventArgs)
        If ColumnComboBox.Visible Then
            ColumnComboBox.Hide()
        End If
    End Sub

    Private Sub ComienzaEditarCombo(ByVal sender As Object, ByVal e As EventArgs)
        _EstaEditando = True
        MyBase.ColumnStartedEditing(sender)


    End Sub


    Private Sub DejaComboBox(ByVal sender As Object, ByVal e As EventArgs)
        If _EstaEditando Then
            SetColumnValueAtRow(_Origen, _NroRenglon, ColumnComboBox.Text)

            _EstaEditando = False
            Invalidate()

        End If
        ColumnComboBox.Hide()
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf ManejaScroll)
    End Sub



    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        MyBase.Edit([source], rowNum, bounds, [readOnly], instantText, cellIsVisible)

        _NroRenglon = rowNum
        _Origen = [source]

        ColumnComboBox.Parent = Me.TextBox.Parent
        ColumnComboBox.Location = Me.TextBox.Location
        ColumnComboBox.Size = New Size(Me.TextBox.Size.Width, ColumnComboBox.Size.Height)
        ColumnComboBox.SelectedIndex = ColumnComboBox.FindStringExact(Me.TextBox.Text)
        ColumnComboBox.Text = Me.TextBox.Text
        Me.TextBox.Visible = False
        ColumnComboBox.Visible = True
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf ManejaScroll

        ColumnComboBox.BringToFront()
        ColumnComboBox.Focus()
    End Sub


    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        If _EstaEditando Then
            _EstaEditando = False
            SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text)
        End If
        Return True
    End Function

    Protected Overrides Sub ConcedeFocus()
        MyBase.ConcedeFocus()
    End Sub

    Protected Overrides Function GetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Object

        Dim s As Object = MyBase.GetColumnValueAtRow([source], rowNum)
        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object


        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.ValueMember).ToString
            If (Not s1 Is DBNull.Value) AndAlso _
                (Not s Is DBNull.Value) AndAlso _
                s = s1 Then

                Exit While
            End If
            i = i + 1
        End While

        If i < rowCount Then
            Return dv(i)(Me.ColumnComboBox.DisplayMember)
        End If
        Return DBNull.Value
    End Function

    Protected Overrides Sub SetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
        Dim s As Object = value

        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object

        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.DisplayMember)
            If (Not s1 Is DBNull.Value) AndAlso _
            s = s1 Then
                Exit While
            End If
            i = i + 1
        End While
        If i < rowCount Then
            s = dv(i)(Me.ColumnComboBox.ValueMember)
        Else
            s = DBNull.Value
        End If
        MyBase.SetColumnValueAtRow([source], rowNum, s)
    End Sub
    Public Class ComboSinKeyUp
        Inherits ComboBox
        Private WM_KEYUP As Integer = &H101

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If m.Msg = WM_KEYUP Then
                'Ignora el keyup para evita problemas de tabulación
                '(c)
                Return
            End If

            MyBase.WndProc(m)
        End Sub
    End Class
End Class


Public Class DataGridComboBoxColumnAutoComplete
    Inherits DataGridTextBoxColumn
    Public ColumnComboBox As ComboSinKeyUp 'Atención aquí con esta declaración
    Private _Origen As System.Windows.Forms.CurrencyManager
    Private _NroRenglon As Integer
    Private _EstaEditando As Boolean
    Public Shared _RowCount As Integer

    Public Sub New()
        _Origen = Nothing
        _EstaEditando = False
        _RowCount = -1

        'c
        ColumnComboBox = New ComboSinKeyUp
        'ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        AddHandler ColumnComboBox.Leave, AddressOf DejaComboBox
        AddHandler ColumnComboBox.SelectionChangeCommitted, AddressOf ComienzaEditarCombo

        AddHandler ColumnComboBox.KeyUp, AddressOf BuscarValor
    End Sub

    Private Sub ManejaScroll(ByVal sender As Object, ByVal e As EventArgs)
        If ColumnComboBox.Visible Then
            ColumnComboBox.Hide()
        End If
    End Sub

    Private Sub ComienzaEditarCombo(ByVal sender As Object, ByVal e As EventArgs)
        _EstaEditando = True
        MyBase.ColumnStartedEditing(sender)
        Try
            BuscarValor(sender, System.Windows.Forms.KeyEventArgs.Empty)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BuscarValor(ByVal sender As Object, ByVal e As KeyEventArgs)
        ''(c)
        Dim sTypedText As String
        Dim sfoundtext As String
        Dim sAppendText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object

        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                _EstaEditando = True
                'Me.DejaComboBox(sender, System.EventArgs.Empty)
                SetColumnValueAtRow(_Origen, _NroRenglon, sender.text)
                Me.Commit(_Origen, _NroRenglon)
                Return

            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        sTypedText = sender.Text
        iFoundIndex = sender.FindString(sTypedText)
        If iFoundIndex >= 0 Then

            'Get the Item from the list (Return Type depends if Datasource was bound 

            ' or List Created)

            oFoundItem = sender.Items(iFoundIndex)

            'Use the ListControl.GetItemText to resolve the Name in case the Combo 

            ' was Data bound

            sfoundtext = sender.GetItemText(oFoundItem)

            'Append then found text to the typed text to preserve case

            sAppendText = sfoundtext.Substring(sTypedText.Length)
            sender.Text = sTypedText & sAppendText
            'sender. = sTypedText & sAppendText
            ColumnComboBox.Text = sTypedText & sAppendText

            'Select the Appended Text

            sender.SelectionStart = sTypedText.Length
            sender.SelectionLength = sAppendText.Length

        End If

    End Sub

    Private Sub DejaComboBox(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Me.BuscarValor(sender, System.Windows.Forms.KeyEventArgs.Empty)
        Catch ex As Exception
            _EstaEditando = True
        End Try

        If _EstaEditando Then
            SetColumnValueAtRow(_Origen, _NroRenglon, ColumnComboBox.Text)
            AutoCompleteCombo_Leave(sender)
            _EstaEditando = False
            Invalidate()

        End If
        ColumnComboBox.Hide()
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf ManejaScroll)
    End Sub

    Private Sub AutoCompleteCombo_Leave(ByVal cbo As ComboBox)
        ''Dim iFoundIndex As Integer

        ''iFoundIndex = cbo.FindStringExact(cbo.Text)

        ''cbo.SelectedIndex = iFoundIndex

    End Sub

    Protected Overloads Overrides Sub Edit(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        MyBase.Edit([source], rowNum, bounds, [readOnly], instantText, cellIsVisible)

        _NroRenglon = rowNum
        _Origen = [source]

        ColumnComboBox.Parent = Me.TextBox.Parent
        ColumnComboBox.Location = Me.TextBox.Location
        ColumnComboBox.Size = New Size(Me.TextBox.Size.Width, ColumnComboBox.Size.Height)
        ColumnComboBox.SelectedIndex = ColumnComboBox.FindStringExact(Me.TextBox.Text)
        ColumnComboBox.Text = Me.TextBox.Text
        Me.TextBox.Visible = False
        ColumnComboBox.Visible = True
        AddHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf ManejaScroll

        ColumnComboBox.BringToFront()
        ColumnComboBox.Focus()
    End Sub


    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

        If _EstaEditando Then
            _EstaEditando = False
            SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text)
        End If
        Return True
    End Function

    Protected Overrides Sub ConcedeFocus()
        MyBase.ConcedeFocus()
    End Sub

    Protected Overrides Function GetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Object

        Dim s As Object = MyBase.GetColumnValueAtRow([source], rowNum)
        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object


        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.ValueMember).ToString
            If (Not s1 Is DBNull.Value) AndAlso _
                (Not s Is DBNull.Value) AndAlso _
                s = s1 Then

                Exit While
            End If
            i = i + 1
        End While

        If i < rowCount Then
            Return dv(i)(Me.ColumnComboBox.DisplayMember)
        End If
        Return DBNull.Value
    End Function

    Protected Overrides Sub SetColumnValueAtRow(ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
        Dim s As Object = value

        Dim dv As DataView = CType(Me.ColumnComboBox.DataSource, DataView)
        Dim rowCount As Integer = dv.Count
        Dim i As Integer = 0
        Dim s1 As Object

        While i < rowCount
            s1 = dv(i)(Me.ColumnComboBox.DisplayMember)
            If (Not s1 Is DBNull.Value) AndAlso _
            s = s1 Then
                Exit While
            End If
            i = i + 1
        End While
        If i < rowCount Then
            s = dv(i)(Me.ColumnComboBox.ValueMember)
        Else
            s = DBNull.Value
        End If
        MyBase.SetColumnValueAtRow([source], rowNum, s)
    End Sub

    Public Class ComboSinKeyUp
        Inherits ComboBox
        Private WM_KEYUP As Integer = &H101

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If m.Msg = WM_KEYUP Then
                'Ignora el keyup para evita problemas de tabulación
                '(c)
                Return
            End If

            MyBase.WndProc(m)
        End Sub
    End Class
End Class

Public Class RowColorEventArgs
    Inherits EventArgs
    Public Sub New(ByVal col As Color, ByVal currManager As CurrencyManager, _
                   ByVal rowNum As Integer)
        Try
            Me.color = col
            Me.src = currManager
            Me.row = rowNum


        Catch ex As Exception
        End Try

    End Sub

    Private color As Color
    Private src As CurrencyManager
    Private row As Integer

    ' Color de la fila.
    Public Property RowColor() As Color
        Get
            Return color
        End Get
        Set(ByVal Value As Color)
            color = Value
        End Set
    End Property

    ' Fuente de datos
    Public ReadOnly Property Source() As CurrencyManager
        Get
            Return src
        End Get
    End Property

    ' Indice de la fila.
    Public ReadOnly Property RowIndex() As Integer
        Get
            Return row
        End Get
    End Property

End Class

Public Class DataGridColoredTextBoxColumn
    Inherits DataGridTextBoxColumn

    Public Event GetForeColor(ByVal sender As Object, _
                              ByVal e As RowColorEventArgs)

    Public Event GetBackColor(ByVal sender As Object, _
                              ByVal e As RowColorEventArgs)

    Public Event SetCellFormat As FormatCellEventHandler

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
              ByVal bounds As System.Drawing.Rectangle, _
              ByVal source As System.Windows.Forms.CurrencyManager, _
              ByVal rowNum As Integer, _
              ByVal backBrush As System.Drawing.Brush, _
              ByVal foreBrush As System.Drawing.Brush, _
              ByVal alignToRight As Boolean)

        Dim evArgs As RowColorEventArgs

        ' Guardamos las brochas para su posterior restauración.
        Dim oldBackBrush As Brush = backBrush
        Dim oldForeBrush As Brush = foreBrush

        ' Pedimos el color de fondo
        evArgs = New RowColorEventArgs(Me.TextBox.BackColor, source, rowNum)
        RaiseEvent GetBackColor(Me, evArgs)

        ' Creamos la brocha de fondo.
        backBrush = New SolidBrush(evArgs.RowColor)

        ' Pedimos el color del texto.
        evArgs = New RowColorEventArgs(Me.TextBox.ForeColor, source, rowNum)

        RaiseEvent GetForeColor(Me, evArgs)

        ' Creamos la brocha del texto
        foreBrush = New SolidBrush(evArgs.RowColor)

        ' Pintamos
        MyBase.Paint(g, bounds, source, rowNum, _
                    backBrush, foreBrush, alignToRight)

        ' Liberamos las brochas! Los recursos de GDI son limitados!
        backBrush.Dispose()
        foreBrush.Dispose()

        ' Restauramos las brochas antiguas
        backBrush = oldBackBrush
        foreBrush = oldForeBrush
    End Sub
End Class

Public Delegate Sub FormatCellEventHandler(ByVal sender As Object, ByVal e As DataGridFormatCellEventArgs)

Public Class DataGridFormatCellEventArgs
    Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal cellValue As Object, ByVal _name As String)
        Try
            rowNum = row
            colNum = col
            colName = _name
            fontVal = Nothing
            backBrushVal = Nothing
            foreBrushVal = Nothing
            fontDisposeVal = False
            backBrushDisposeVal = False
            foreBrushDisposeVal = False
            useBaseClassDrawingVal = True
            currentCellValueVal = cellValue

        Catch ex As Exception
        End Try

    End Sub 'New

    ' Holds the column name of the cell being painted.

    Public Property ColumnName() As String
        Get
            Return colName
        End Get
        Set(ByVal Value As String)
            colName = Value
        End Set
    End Property
    ' Holds the column number of the cell being painted.

    Public Property Column() As Integer
        Get
            Return colNum
        End Get
        Set(ByVal Value As Integer)
            colNum = Value
        End Set
    End Property
    ' Holds the row number of the cell being painted.
    Public Property Row() As Integer
        Get
            Return rowNum
        End Get
        Set(ByVal Value As Integer)
            rowNum = Value
        End Set
    End Property
    ' Holds the font to be used to draw text in the cell.
    Public Property TextFont() As Font
        Get
            Return fontVal
        End Get
        Set(ByVal Value As Font)
            fontVal = Value
        End Set
    End Property
    ' Holds the brush used to paint the cell's background.

    Public Property BackBrush() As Brush
        Get
            Return backBrushVal
        End Get
        Set(ByVal Value As Brush)
            backBrushVal = Value
        End Set
    End Property
    ' Holds the brush used to paint the text in the cell.
    Public Property ForeBrush() As Brush
        Get
            Return foreBrushVal
        End Get
        Set(ByVal Value As Brush)
            foreBrushVal = Value
        End Set
    End Property
    ' Set to true if the Dispose method of the TextFont
    '     should be called by the Paint override.
    Public Property TextFontDispose() As Boolean
        Get
            Return fontDisposeVal
        End Get
        Set(ByVal Value As Boolean)
            fontDisposeVal = Value
        End Set
    End Property
    ' Set to true if the Dispose method of the BackBrush
    '     should be called by the Paint override.
    Public Property BackBrushDispose() As Boolean
        Get
            Return backBrushDisposeVal
        End Get
        Set(ByVal Value As Boolean)
            BackBrushDispose = Value
        End Set
    End Property
    ' Set to true if the Dispose method of the ForeBrush
    '     should be called by the Paint override.
    Public Property ForeBrushDispose() As Boolean
        Get
            Return foreBrushDisposeVal
        End Get
        Set(ByVal Value As Boolean)
            ForeBrushDispose = Value
        End Set
    End Property
    ' Set to false if the MyBase.Paint method 
    '     should not be called in the Paint override.
    Public Property UseBaseClassDrawing() As Boolean
        Get
            Return useBaseClassDrawingVal
        End Get
        Set(ByVal Value As Boolean)
            useBaseClassDrawingVal = Value
        End Set
    End Property
    ' Holds the current cell value.
    Public ReadOnly Property CurrentCellValue() As Object

        Get
            Try
                Return currentCellValueVal
            Catch ex As Exception
            End Try
        End Get

    End Property
    ' Private fields to hold the public properties.
    Private colNum As Integer
    Private rowNum As Integer
    Private colName As String
    Private fontVal As Font
    Private backBrushVal As Brush
    Private foreBrushVal As Brush
    Private fontDisposeVal As Boolean
    Private backBrushDisposeVal As Boolean
    Private foreBrushDisposeVal As Boolean
    Private useBaseClassDrawingVal As Boolean
    Private currentCellValueVal As Object
End Class

Public Class FormattableTextBoxColumn
    Inherits DataGridTextBoxColumn

    Public Event GetForeColor(ByVal sender As Object, _
                          ByVal e As RowColorEventArgs)

    Public Event SetCellFormat As FormatCellEventHandler


    'used to fire an event to retrieve formatting info
    'and then draw the cell with this formatting info

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, _
        ByVal [source] As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)


        Try
            Dim e As DataGridFormatCellEventArgs = Nothing

            Dim evArgs As RowColorEventArgs
            'fire the formatting event

            Dim col As Integer = Me.DataGridTableStyle.GridColumnStyles.IndexOf(Me)
            e = New DataGridFormatCellEventArgs(rowNum, col, Me.GetColumnValueAtRow([source], rowNum), Me.HeaderText)
            RaiseEvent SetCellFormat(Me, e)

            Dim callBaseClass As Boolean = True ' assume we will call the baseclass

            If Not (e.BackBrush Is Nothing) Then
                backBrush = e.BackBrush
            End If

            If Not (e.ForeBrush Is Nothing) Then
                Try
                    ' Pedimos el color del texto.
                    evArgs = New RowColorEventArgs(Me.TextBox.ForeColor, source, rowNum)

                    RaiseEvent GetForeColor(Me, evArgs)

                    ' Creamos la brocha del texto
                    foreBrush = New SolidBrush(evArgs.RowColor)

                Catch ex As Exception
                    foreBrush = e.ForeBrush

                End Try
            End If

            'if TextFont set, then must call drawstring

            If Not (e.TextFont Is Nothing) Then
                g.FillRectangle(backBrush, bounds)
                Try
                    Dim charWidth As Integer = Fix(Math.Ceiling(g.MeasureString("c", e.TextFont, 20, StringFormat.GenericTypographic).Width))
                    Dim s As String = Me.GetColumnValueAtRow([source], rowNum).ToString()
                    Dim maxChars As Integer = Math.Min(s.Length, bounds.Width / charWidth)

                    Try
                        g.DrawString(s.Substring(0, maxChars), e.TextFont, foreBrush, bounds.X, bounds.Y + 2)
                    Catch ex As Exception
                        'Console.WriteLine(ex.Message.ToString())
                    End Try
                Catch 'empty catch
                End Try

                callBaseClass = False
            End If

            If Not e.UseBaseClassDrawing Then
                callBaseClass = False
            End If

            If callBaseClass Then
                MyBase.Paint(g, bounds, [source], rowNum, backBrush, foreBrush, alignToRight)

            End If

            'clean up

            If Not (e Is Nothing) Then
                If e.BackBrushDispose Then
                    e.BackBrush.Dispose()
                End If
                If e.ForeBrushDispose Then
                    e.ForeBrush.Dispose()
                End If
                If e.TextFontDispose Then
                    e.TextFont.Dispose()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub 'Paint   

    ''Protected Overrides Sub Abort(ByVal rowNum As Integer)

    ''End Sub

    ''Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
    ''    Return True
    ''End Function

    ''Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

    ''End Sub

    ''Protected Overrides Function GetMinimumHeight() As Integer

    ''End Function

    ''Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

    ''End Function

    ''Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

    ''End Function

    ''Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

    ''End Sub

    ''Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)

    ''End Sub
End Class

#End Region

#Region "CalendarColumn"

Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class

#End Region

#Region " CheckBox Column "


Public Class DataGridCheckBox
    Inherits DataGridBoolColumn


    Public Sub New(ByVal MappingName As String)
        MyBase.New()
        Me.MappingName = MappingName
    End Sub

    Public Sub New(ByVal MappingName As String, _
                   ByVal Width As Integer, _
                   ByVal Alignment As HorizontalAlignment, _
                   ByVal [ReadOnly] As Boolean, _
                   ByVal HeaderText As String, _
                   ByVal NullText As String, _
                   ByVal FalseValue As Object, _
                   ByVal TrueValue As Object, _
                   ByVal AllowNull As Boolean, _
                   ByVal NullValue As Object)
        Me.New(MappingName)
        Me.Alignment = Alignment
        Me.Width = Width
        Me.ReadOnly = [ReadOnly]
        Me.HeaderText = HeaderText
        Me.FalseValue = FalseValue
        Me.TrueValue = TrueValue
        Me.NullText = NullText
        Me.NullValue = NullValue
        Me.AllowNull = AllowNull
    End Sub

    ''Protected Overrides Sub Abort(ByVal rowNum As Integer)

    ''End Sub

    ''Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

    ''End Function

    ''Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

    ''End Sub

    ''Protected Overrides Function GetMinimumHeight() As Integer

    ''End Function

    ''Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

    ''End Function

    ''Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

    ''End Function

    ''Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

    ''End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
                                            ByVal bounds As System.Drawing.Rectangle, _
                                            ByVal source As System.Windows.Forms.CurrencyManager, _
                                            ByVal rowNum As Integer, _
                                            ByVal alignToRight As Boolean)


        ''Dim evArgs As RowColorEventArgs

        '' Guardamos las brochas para su posterior restauración.
        ''Dim oldBackBrush As Brush = backBrush
        ''Dim oldForeBrush As Brush = foreBrush

        '' Pedimos el color de fondo
        ''evArgs = New RowColorEventArgs(Me.TextBox.BackColor, source, rowNum)
        ''RaiseEvent GetBackColor(Me, evArgs)

        '' Creamos la brocha de fondo.
        ''backBrush = New SolidBrush(evArgs.RowColor)

        '' Pedimos el color del texto.
        ''evArgs = New RowColorEventArgs(Me.TextBox.ForeColor, source, rowNum)

        ''RaiseEvent GetForeColor(Me, evArgs)

        ''Try
        ''    ' Creamos la brocha del texto
        ''    foreBrush = New SolidBrush(evArgs.RowColor)

        ''    ' Pintamos
        ''    MyBase.Paint(g, bounds, source, rowNum, _
        ''            backBrush, foreBrush, alignToRight)


        ''    foreBrush.Dispose()
        ''    foreBrush = oldForeBrush
        ''Catch ex As Exception

        ''End Try




        '' Liberamos las brochas! Los recursos de GDI son limitados!
        ''backBrush.Dispose()


        '' Restauramos las brochas antiguas
        ''backBrush = oldBackBrush

    End Sub
End Class

#End Region

#Region " CheckBox Column "
Public Class myTextBoxRequerido
    Inherits System.Windows.Forms.TextBox

    Dim myErrorP As New System.Windows.Forms.ErrorProvider
    Dim mySendkey As System.Windows.Forms.SendKeys



#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region
    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)

        If Me.Text.Length = 0 Then

            myErrorP.SetError(Me, "dato requerido")

            Me.Focus()

        Else

            myErrorP.SetError(Me, "")


        End If

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            e.Handled = True

            mySendkey.Send("{tab}")

        End If

    End Sub
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        Me.SelectAll()
    End Sub
End Class
#End Region

#Region "Seleccionar Opciones"

Public Class Seleccionar_Opcion
    Public _SelectedValue As String
    Public pdt As DataTable
    Public _DisplayMember As String
    Public _ValueMember As String
    Public texto_formulario As String = ""
    Public texto_opciones As String = ""


    Public Sub Obtener_Seleccion()
        Dim oform As New frm_seleccionar_opcion
        oform.cmb_listado.DataSource = pdt
        oform.cmb_listado.DisplayMember = _DisplayMember
        oform.cmb_listado.ValueMember = _ValueMember
        oform.Text = IIf(texto_formulario.Length > 0, texto_formulario, oform.Text)
        oform.lbl_opcion.Text = IIf(texto_opciones.Length > 0, texto_opciones, oform.lbl_opcion.Text)
        oform.ShowDialog()
        _SelectedValue = oform.cmb_listado.SelectedValue
        oform.Dispose()
        oform = Nothing
    End Sub

End Class

#End Region

#Region "Emitir Sonido"
Public Class Emitir_Sonido


    '----------------------------------------------------------------------------
    'Programación sólida
    '* PlaySound devuelve true cuando tiene éxito y false cuando no es así.
    '* Si el archivo especificado no existe, PlaySound reproduce el sonido de 
    '  evento de sistema predeterminado y no devuelve ningún error.
    '* El nombre de archivo debe hacer referencia a un archivo de sonido que
    '  se encuentre en el sistema.

    '----------------------------------------------------------------------------


    Private Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name _
        As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer
    ' name specifies the sound file when the SND_FILENAME flag is set.
    ' hmod specifies an executable file handle.
    ' hmod must be Nothing if the SND_RESOURCE flag is not set.
    ' flags specifies which flags are set. 

    ' The PlaySound documentation lists all valid flags.
    Public Const SND_SYNC As Integer = &H0          ' play synchronously
    Public Const SND_ASYNC As Integer = &H1         ' play asynchronously
    Public Const SND_FILENAME As Integer = &H20000  ' name is file name
    Public Const SND_RESOURCE As Integer = &H40004  ' name is resource name or atom



    ' -------------------------------------------------
    '  <summary>
    '    Reproducir un archivo de sonido que esta en un archivo del disco
    '  </summary>
    '  <remarks>
    '    <para>Referencia bibliografica Ayuda MSDM</para>
    '    <para>ms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.3082/dv_vbcode/html/vbtskCodeExamplePlayingSound.htm 
    '    </para>
    '    <para>Si el archivo especificado no existe, se reproduce el 
    '    sonido de evento de sistema predeterminado y no devuelve ningun 
    '    error.</para>
    '  </remarks>
    '  <param name = 'nombreFicheroSonido'>
    '    El nombre de archivo que debe hacer referencia a un archivo 
    '    de sonido que se encuentre en el sistema
    '    <see cref = "System.String">
    '       (System.String)
    '    </see>
    '  </param>
    '  <returns>
    '    <para>Un valor booleano.: Devuelve </para>
    '    <para>True.: cuando tiene exito y el archivo de sonido 
    '          se reproduce</para>
    '    <para>False: cuando por la razon que sea no se reproduce el 
    '    sonido</para>
    '    <see cref = "System.Boolean">
    '       (System.Boolean)
    '    </see>
    '  </returns>
    '  <example>
    '    En este ejemplo se reproduce un sonido a partir de un archivo.
    '    <code>
    '         Private Sub SonarLaAlarma()
    '             Dim SoundInst As SoundClass = Nothing
    '             Try
    '                 ' Instanciar la clase
    '                 SoundInst = New SoundClass()
    '                 ' Tocar el sonido
    '                 SoundInst.PlaySoundFile("MisResources/45.wav")
    '                 ' continuar en el finally
    '             Catch ex As Exception
    '                 Throw ex
    '             Finally
    '                 SoundInst = Nothing
    '             End Try
    '         End Sub
    '    </code>
    '  </example>
    ' -------------------------------------------------
    Public Function PlaySound(ByVal nombreFicheroSonido As String) As Boolean
        Try
            ' Plays a sound from filename.
            Return CBool(PlaySound(nombreFicheroSonido, _
            Nothing, _
            SND_FILENAME Or SND_ASYNC))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
#End Region

#Region "Dias Habiles"

Public Class DiasHabiles


    Public Function Obtener_DiasHabiles(ByVal pempresa As String, ByVal pfechainicio As Date, ByVal pfechafinal As Date) As Integer
        Dim otrans As New Transaccional.Conexion("UMBRAL")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim ntotaldias As Integer = 0

        Try
            otrans.open()
            ls_sql = "pa_var_dias_habiles '" & pempresa & "','" & pfechainicio.ToString("dd/MM/yyyy") & "','" & pfechafinal.ToString("dd/MM/yyyy") & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                ntotaldias = dt.Compute("sum(dia_habil)", "dia_habil < 10")
            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

        Return ntotaldias

        ''Dim incrementar As Int16 = -1

        ''If pfechainicio < pfechafinal Then
        ''    incrementar = 1
        ''End If

        ''Do While pfechainicio.Date <> pfechafinal.Date
        ''    If pfechainicio.DayOfWeek <> DayOfWeek.Saturday And _
        ''       pfechainicio.DayOfWeek <> DayOfWeek.Sunday Then
        ''        ntotaldias += 1
        ''    End If
        ''    pfechainicio = pfechainicio.AddDays(incrementar)
        ''Loop
        ''If pfechainicio.Date = pfechafinal.Date And _
        ''    pfechainicio.DayOfWeek <> DayOfWeek.Saturday And _
        ''    pfechainicio.DayOfWeek <> DayOfWeek.Sunday Then
        ''    ntotaldias += 1
        ''End If
    End Function


End Class

#End Region


#Region "MR"

'Utilizada por todos los lugares en donde se guardan movimientos de los MR dentro del programa SAM
Public Class MR
    Dim _cliente_mayorista As Integer
    Dim _sucursal As Integer
    Public _signo As Integer = 0
    Public Ods_Movimiento As DataSet
    Public _cliente_movimiento(50) As Integer
    Public _MensajeError As String
    Dim _Contiene_Documento_Previo As Boolean = False
    Dim _numero_previo, _cod_movimiento_previo As Integer
    Dim _tipo_movimiento_previo As Integer
    Public _procesar_lo_que_exista As Boolean = False 'Cuanto es verdadera solo despachara el total
    Public _validar_totales As Boolean = False 'valida que los totales esten correctos
    Dim _nombre_conexion As String


    Public Sub New(ByVal ncliente_mayorista As Integer, ByVal nsucursal As Integer)
        _cliente_mayorista = ncliente_mayorista
        _sucursal = nsucursal
    End Sub

    Public Sub New(ByVal ncliente_mayorista As Integer, ByVal nsucursal As Integer, ByVal nombre_conexion As String)
        _cliente_mayorista = ncliente_mayorista
        _sucursal = nsucursal
        _nombre_conexion = nombre_conexion
    End Sub

    Public Sub Documento_Previo(ByVal numero As Integer, ByVal tipo_movimiento As Integer)
        If numero > 0 Then
            _Contiene_Documento_Previo = True
            _numero_previo = numero
            _tipo_movimiento_previo = tipo_movimiento
        End If
    End Sub


    Public Sub Crear_Estructuras()
        Ods_Movimiento = New DataSet

        Dim dt As New DataTable("encabezado")
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_movimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("sub_total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desc_producto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desc_cliente", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("no_externo", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("condicion_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_proveedor_mayorista", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_vendedor", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cod_tipo_devolucion", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cod_sucursal", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cod_movimiento_original", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha_pago", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("estado_pago", GetType(Integer)))



        Ods_Movimiento.Tables.Add(dt.Copy)


        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("cod_producto_mayorista", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("costo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("sub_total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("porc_desc_producto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("porc_desc_cliente", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total_desc_producto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total_desc_cliente", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cod_proveedor", GetType(Integer)))
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cod_unidad_alternativa", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad_asignada", GetType(Integer)))
        dt.Columns.Add(New DataColumn("precio_original", GetType(Decimal)))



        Ods_Movimiento.Tables.Add(dt.Copy)

        'Esta Tabla se utiliza cuando es modificacion
        dt.TableName = "detalle_anterior"
        Ods_Movimiento.Tables.Add(dt.Copy)

        Limpiar_Tablas()
    End Sub

    Public Sub Limpiar_Tablas()
        Try
            Ods_Movimiento.Tables("encabezado").Rows.Clear()
            Ods_Movimiento.Tables("detalle").Rows.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Public Function No_Existe_Numero_Externo(ByVal _numero_externo As String, ByVal _tipo_movimiento As Integer, ByVal _conexion As String) As Boolean
        Dim ls_sql As String
        Dim bregresar As Boolean = True

        Dim myOtrans As New Transaccional.Conexion_mysql(_conexion)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim icount As Integer = 0

        Try
            myOtrans.open()
            ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento_externo (" & _cliente_mayorista & ",'" & _numero_externo & "'," & _tipo_movimiento & ")"
            dt = myOtrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                bregresar = False
                For Each dr In dt.Rows
                    _cliente_movimiento(icount) = dr.Item("cod_cliente_mayorista")
                    icount += 1
                Next
            End If

        Catch ex As Exception
            bregresar = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return bregresar

    End Function

    Public Function Guardar_Movimiento(ByVal _nombre_conexion As String) As Integer
        Dim ls_sql As String
        Dim icorrelativo, imovimiento, ilinea As Integer
        Dim dcosto, dprecio_original, dporcentaje_comision_producto As Double
        Dim HuboErrores As Boolean = False

        Dim lagregar As Boolean = False
        Dim lbprocesar_linea As Boolean = True
        Dim lbmodificar_encabezado As Boolean = False
        Dim dr, dre As DataRow
        Dim dte, dtd, dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)

        Try
            dte = Ods_Movimiento.Tables("encabezado")
            dtd = Ods_Movimiento.Tables("detalle")

            Obtener_Total_Encabezado(dtd, dte.Rows(0))

            imovimiento = -1
            icorrelativo = -1
            myOtrans.open()

            If _Contiene_Documento_Previo Then
                ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento (" & _
                                  _numero_previo.ToString & "," & _cliente_mayorista & "," & _
                                  dte.Rows(0).Item("cod_cliente").ToString & "," & _tipo_movimiento_previo & ",1,null)"

                dt = myOtrans.Obtiene(ls_sql)
                _cod_movimiento_previo = dt.Rows(0).Item("cod_movimiento").ToString

            End If

            If dtd.Rows.Count > 0 Then
                ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento_correlativo (" & _cliente_mayorista.ToString & "," & dte.Rows(0).Item("tipo_movimiento").ToString & "," & _sucursal & ")"
                dt = myOtrans.Obtiene(ls_sql)
                icorrelativo = dt.Rows(0).Item("nuevo_correlativo")

                ls_sql = "call pa_ins_um_bbj_mayorista_encabezado_movimiento (" & icorrelativo & "," & _cliente_mayorista.ToString & _
                         "," & dte.Rows(0).Item("cod_cliente").ToString & "," & dte.Rows(0).Item("tipo_movimiento").ToString & ",'" & _
                         DateTime.Parse(dte.Rows(0).Item("fecha").ToString).ToString("yyyy-MM-dd") & "','" & _
                         dte.Rows(0).Item("usuario_grabo") & _
                         "'," & Double.Parse(dte.Rows(0).Item("total").ToString).ToString & "," & _
                        Double.Parse(dte.Rows(0).Item("sub_total").ToString).ToString & "," & _
                        Double.Parse(dte.Rows(0).Item("desc_producto").ToString).ToString & "," & _
                        Double.Parse(dte.Rows(0).Item("desc_cliente").ToString).ToString & ",'" & _
                         dte.Rows(0).Item("no_externo") & "','" & _
                         dte.Rows(0).Item("observaciones").Replace("'", " ") & "'," & _
                         IIf(dte.Rows(0).Item("condicion_pago").ToString.Length = 0, "NULL", "'" & dte.Rows(0).Item("condicion_pago").ToString & "'") & "," & _
                         IIf(dte.Rows(0).Item("cod_proveedor_mayorista").ToString.Length = 0, "NULL", dte.Rows(0).Item("cod_proveedor_mayorista").ToString) & "," & _
                         IIf(dte.Rows(0).Item("cod_vendedor").ToString.Length = 0, "NULL", dte.Rows(0).Item("cod_vendedor").ToString) & "," & _
                         IIf(dte.Rows(0).Item("cod_tipo_devolucion").ToString.Length = 0, "NULL", dte.Rows(0).Item("cod_tipo_devolucion").ToString) & "," & _
                         IIf(dte.Rows(0).Item("cod_movimiento_original").ToString.Length = 0, "NULL", dte.Rows(0).Item("cod_movimiento_original").ToString) & "," & _
                         dte.Rows(0).Item("cod_sucursal").ToString & "," & _
                         IIf(dte.Rows(0).Item("fecha_pago").ToString.Length = 0, "NULL", "'" & DateTime.Parse(dte.Rows(0).Item("fecha_pago").ToString).ToString("yyyy-MM-dd") & "'") & ")"



                myOtrans.Ingresa(ls_sql)
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                imovimiento = dt.Rows(0).Item("newid").ToString

            End If

            If imovimiento > 0 Then
                ilinea = 0
                For Each dr In dtd.Rows

                    If _Contiene_Documento_Previo And dr.Item("cantidad_asignada") > 0 Then
                        dr.Item("cantidad") = dr.Item("cantidad") - dr.Item("cantidad_asignada")
                        If dr.Item("cantidad") > 0 Then

                            dr.Item("sub_total") = dr.Item("cantidad") * dr.Item("precio")
                            dr.Item("total_desc_producto") = Round((dr.Item("sub_total") * dr.Item("porc_desc_producto") / 100), 2)
                            dr.Item("total_desc_cliente") = Round(( _
                                                           (dr.Item("sub_total") - dr.Item("total_desc_producto")) _
                                                            * dr.Item("porc_desc_cliente") / 100), 2)
                            dr.Item("total") = dr.Item("sub_total") - dr.Item("total_desc_producto") - dr.Item("total_desc_cliente")

                            lbmodificar_encabezado = True
                        Else
                            dr.Item("cantidad") = 0
                            dr.Item("sub_total") = 0
                            dr.Item("total_desc_producto") = 0
                            dr.Item("total_desc_cliente") = 0
                            dr.Item("total") = 0
                        End If

                    End If


                    'Inicio el proceso de Guardar Movimiento
                    If dr.Item("cantidad") > 0 Then

                        ilinea += 1
                        ls_sql = "Call pa_sel_um_bbj_mayorista_productos_disponibles(" & _cliente_mayorista.ToString & ", '" & dr.Item("cod_producto_mayorista") & "',null," & _sucursal & ")"
                        dt = myOtrans.Obtiene(ls_sql)
                        If dt.Rows.Count = 1 Then
                            dcosto = dt.Rows(0).Item("precio_proveedor")
                            dprecio_original = dt.Rows(0).Item("precio_venta")
                            dporcentaje_comision_producto = dt.Rows(0).Item("porcentaje_comision")
                        Else
                            dcosto = 0
                            dprecio_original = 0
                            dporcentaje_comision_producto = 0
                        End If


                        If _signo = -1 Then ''Si Sale Producto de Inventario tengo que hacer una validacion extra del inventario
                            ''tengo q hacer la validacion
                            If dt.Rows(0).Item("existencia") < 1 Then
                                lbprocesar_linea = False
                                lbmodificar_encabezado = True
                                dr.Item("cantidad") = 0
                                dr.Item("sub_total") = 0
                                dr.Item("total_desc_producto") = 0
                                dr.Item("total_desc_cliente") = 0
                                dr.Item("total") = 0

                            ElseIf dt.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                                If _procesar_lo_que_exista Then
                                    ''Si Se Rebaja La Existencia Debe Recalcular La Linea
                                    dr.Item("cantidad") = dt.Rows(0).Item("existencia")
                                    dr.Item("sub_total") = dr.Item("cantidad") * dr.Item("precio")
                                    dr.Item("total_desc_producto") = Round((dr.Item("sub_total") * dr.Item("porc_desc_producto") / 100), 2)
                                    dr.Item("total_desc_cliente") = Round(( _
                                                                   (dr.Item("sub_total") - dr.Item("total_desc_producto")) _
                                                                    * dr.Item("porc_desc_cliente") / 100), 2)
                                    dr.Item("total") = dr.Item("sub_total") - dr.Item("total_desc_producto") - dr.Item("total_desc_cliente")

                                    lbmodificar_encabezado = True


                                End If
                            End If
                        End If

                        If lbprocesar_linea Then

                            ls_sql = "call pa_ins_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & "," & _
                                 dr.Item("cantidad") & "," & dr.Item("precio") & "," & dr.Item("sub_total") & "," & _
                                 dr.Item("porc_desc_producto") & "," & dr.Item("total_desc_producto") & "," & dr.Item("porc_desc_cliente") & "," & _
                                 dr.Item("total_desc_cliente") & "," & dr.Item("total") & "," & _
                                 IIf(dr.Item("linea").ToString.Length > 0, dr.Item("linea"), ilinea) & ",'" & dr.Item("cod_producto_mayorista") & "'," & _
                                 dcosto & "," & dr.Item("cod_proveedor") & "," & _
                                 IIf(dr.Item("cod_unidad_alternativa").ToString.Length > 0, dr.Item("cod_unidad_alternativa").ToString, "NULL") & "," & _
                                 IIf(dr.Item("cantidad_asignada").ToString.Length > 0, dr.Item("cantidad_asignada").ToString, "0") & "," & _
                                 dprecio_original & "," & dporcentaje_comision_producto & ")"

                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                myOtrans.Codigo_error = 0
                                HuboErrores = True
                                Exit For
                            End If

                            ''Actualizo Existencia
                            If _signo <> 0 Then

                                ls_sql = "call pa_upd_um_bbj_mayorista_productos_disponibles_existencia (" & _cliente_mayorista & ",'" & dr.Item("cod_producto_mayorista") & "'," & _
                                        dr.Item("cantidad") & "," & _signo.ToString & "," & dte.Rows(0).Item("cod_sucursal").ToString & ")"
                                myOtrans.Actualiza(ls_sql)

                                If myOtrans.Codigo_error > 0 Then
                                    myOtrans.Codigo_error = 0

                                    ls_sql = "call pa_del_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & ",'" & _
                                                dr.Item("cod_producto_mayorista") & "')"
                                    myOtrans.Elimina(ls_sql)
                                    HuboErrores = True
                                    Exit For

                                End If
                            End If ''signo
                            If _Contiene_Documento_Previo Then

                                ls_sql = "call pa_upd_um_bbj_mayorista_detalle_movimiento (" & _cod_movimiento_previo.ToString & ",'" & _
                                        dr.Item("cod_producto_mayorista").ToString & "'," & dr.Item("cod_proveedor").ToString & "," & _
                                        dr.Item("cantidad").ToString & ")"

                                myOtrans.Actualiza(ls_sql)
                                If myOtrans.Codigo_error > 0 Then
                                    HuboErrores = True
                                End If

                            End If
                        End If 'Procesar Linea
                        lbprocesar_linea = True
                    End If
                Next
                'Debo modificar los totales, por que pudieron haber cambiado algunas lineas del detalle
                'por el manejo de las existencias
                If lbmodificar_encabezado Then
                    Obtener_Total_Encabezado(dtd, dte.Rows(0))

                    dre = dte.Rows(0)
                    If _validar_totales Then
                        If dre.Item("total") > 0 Then
                            ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & _
                                            icorrelativo & "," & _cliente_mayorista & "," & dre.Item("cod_cliente").ToString & "," & dre.Item("tipo_movimiento").ToString & ",1,'" & _
                                            dre.Item("no_externo").ToString & "','" & dre.Item("observaciones").ToString.Replace("'", " ") & "',0," & _
                                            IIf(dre.Item("condicion_pago").ToString.Length = 0, "NULL", "'" & dre.Item("condicion_pago").ToString & "'") & "," & _
                                            IIf(dre.Item("cod_vendedor").ToString.Length = 0, "NULL", dre.Item("cod_vendedor").ToString) & "," & _
                                            Double.Parse(dre.Item("total").ToString).ToString & "," & _
                                            Double.Parse(dre.Item("sub_total").ToString).ToString & "," & _
                                            Double.Parse(dre.Item("desc_producto").ToString).ToString & "," & _
                                            Double.Parse(dre.Item("desc_cliente").ToString).ToString & ",'" & _
                                            dre.Item("usuario_grabo") & "'," & dre.Item("cod_sucursal").ToString & ",null,null)"

                            myOtrans.Actualiza(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                HuboErrores = True
                            End If

                        Else
                            ''Si no lleva total, se debe eliminar el encabezado
                            HuboErrores = True
                        End If
                    End If 'validar_totales
                End If

                ''Si ilienea = 0 no proceso nada en el detalle
                If ilinea = 0 Then
                    HuboErrores = True
                End If
            End If


        Catch ex As Exception
        Finally
            _MensajeError = ""
            Try
                If HuboErrores Then
                    ls_sql = "call pa_sel_um_bbj_mayorista_detalle_movimiento (" & imovimiento & ")"
                    dt = myOtrans.Obtiene(ls_sql)

                    For Each dr In dt.Rows

                        ls_sql = "call pa_upd_um_bbj_mayorista_productos_disponibles_existencia (" & _cliente_mayorista & ",'" & dr.Item("cod_producto") & "'," & _
                                   dr.Item("cantidad") & "," & (_signo * -1).ToString & "," & dte.Rows(0).Item("cod_sucursal").ToString & ")"

                        myOtrans.Actualiza(ls_sql)

                        ls_sql = "call pa_del_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & ",'" & _
                                    dr.Item("codigo") & "')"
                        myOtrans.Elimina(ls_sql)
                    Next
                    ls_sql = "call pa_del_um_bbj_mayorista_encabezado_movimiento (" & imovimiento.ToString & ")"
                    myOtrans.Elimina(ls_sql)
                    icorrelativo = -1

                    _MensajeError = "Problemas en la Actualizacion de Existencias"
                End If

            Catch ex As Exception
            End Try

            myOtrans.close()
            myOtrans = Nothing

        End Try

        Return icorrelativo

    End Function

    Public Function Modificar_Movimiento(ByVal _nombre_conexion As String) As Boolean

        Dim ls_sql As String
        Dim imovimiento, ilinea As Integer
        Dim dcosto, dporcentaje_comision_producto As Double
        Dim Exitoso As Boolean = True

        Dim lagregar As Boolean = False
        Dim dr As DataRow
        Dim dre As DataRow 'DataRow del encabezado
        Dim dtd, dt, dta As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)
        Dim lbprocesar_linea As Boolean = True

        Try
            dre = Ods_Movimiento.Tables("encabezado").Rows(0)
            dtd = Ods_Movimiento.Tables("detalle")
            dta = Ods_Movimiento.Tables("detalle_anterior")

            Obtener_Total_Encabezado(dtd, dre)
            imovimiento = -1

            myOtrans.open()


            ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento (" & dre.Item("correlativo").ToString & "," & _cliente_mayorista & "," & dre.Item("cod_cliente").ToString & "," & dre.Item("tipo_movimiento").ToString & ",1,null)"
            dt = myOtrans.Obtiene(ls_sql)
            imovimiento = dt.Rows(0).Item("cod_movimiento").ToString


            For Each dr In dta.Rows
                ''Debo Regresar El Inventario
                If _signo <> 0 Then
                    lbprocesar_linea = False
                    dtd.DefaultView.RowFilter = "cod_producto_mayorista = '" & dr.Item("cod_producto_mayorista").ToString & "'"
                    If dtd.DefaultView.Count > 0 Then
                        If dr.Item("cantidad") <> dtd.DefaultView(0).Item("cantidad") Or _
                                dr.Item("precio") <> dtd.DefaultView(0).Item("precio") Then
                            lbprocesar_linea = True
                        End If
                    ElseIf dtd.DefaultView.Count = 0 Then
                        lbprocesar_linea = True
                    End If

                    If lbprocesar_linea Then


                        ls_sql = "call pa_upd_um_bbj_mayorista_productos_disponibles_existencia (" & _cliente_mayorista & ",'" & dr.Item("cod_producto_mayorista") & "'," & _
                                dr.Item("cantidad") & "," & (_signo * -1).ToString & "," & dre.Item("cod_sucursal").ToString & ")"
                        myOtrans.Actualiza(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Exitoso = False
                        End If
                        ''Elimino la linea del detalle
                        ls_sql = "call pa_del_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & ",'" & _
                                dr.Item("cod_producto_mayorista").ToString & "')"
                        myOtrans.Elimina(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Exitoso = False
                        End If

                    End If
                Else
                    ''Debo Eliminar el Detalle
                    ls_sql = "call pa_del_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & ",'" & _
                                                    dr.Item("cod_producto_mayorista").ToString & "')"
                    myOtrans.Elimina(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Exitoso = False
                    End If
                End If

            Next

            dtd.DefaultView.RowFilter = ""

            ''Debo Agregar el nuevo detalle
            For Each dr In dtd.Rows 'detalle
                If dr.Item("cantidad") > 0 Then
                    If _signo = 0 Then
                        lagregar = True
                    Else
                        lagregar = False
                        dta.DefaultView.RowFilter = "cod_producto_mayorista = '" & dr.Item("cod_producto_mayorista").ToString & "'"
                        If dta.DefaultView.Count > 0 Then
                            If dr.Item("cantidad") <> dta.DefaultView(0).Item("cantidad") Or _
                                    dr.Item("precio") <> dta.DefaultView(0).Item("precio") Then
                                lagregar = True
                            End If
                        ElseIf dta.DefaultView.Count = 0 Then
                            lagregar = True
                        End If

                    End If


                    If lagregar Then

                        ilinea += 1
                        ls_sql = "Call pa_sel_um_bbj_mayorista_productos_disponibles(" & _cliente_mayorista.ToString & ", '" & dr.Item("cod_producto_mayorista") & "',null," & _sucursal & ")"
                        dt = myOtrans.Obtiene(ls_sql)

                        If dt.Rows.Count = 1 Then
                            dcosto = dt.Rows(0).Item("precio_proveedor")
                            dporcentaje_comision_producto = dt.Rows(0).Item("porcentaje_comision")
                            If dr.Item("precio_original").ToString.Length = 0 Then
                                dr.Item("precio_original") = dt.Rows(0).Item("precio_venta")
                            End If
                        Else
                            dcosto = 0
                            dporcentaje_comision_producto = 0
                            If dr.Item("precio_original").ToString.Length = 0 Then
                                dr.Item("precio_original") = 0
                            End If
                        End If

                        If _signo = -1 Then ''Si Sale Producto de Inventario tengo que hacer una validacion extra del inventario
                            If dt.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                                lbprocesar_linea = False
                            End If

                        End If

                        If lbprocesar_linea Then
                            ls_sql = "call pa_ins_um_bbj_mayorista_detalle_movimiento (" & imovimiento.ToString & "," & _
                                 dr.Item("cantidad") & "," & dr.Item("precio") & "," & dr.Item("sub_total") & "," & _
                                 dr.Item("porc_desc_producto") & "," & dr.Item("total_desc_producto") & "," & dr.Item("porc_desc_cliente") & "," & _
                                 dr.Item("total_desc_cliente") & "," & dr.Item("total") & "," & _
                                 IIf(dr.Item("linea").ToString.Length > 0, dr.Item("linea"), ilinea) & ",'" & dr.Item("cod_producto_mayorista") & "'," & _
                                 dcosto & "," & dr.Item("cod_proveedor") & "," & _
                                 IIf(dr.Item("cod_unidad_alternativa").ToString.Length > 0, dr.Item("cod_unidad_alternativa").ToString, "NULL") & "," & _
                                 dr.Item("cantidad_asignada").ToString & "," & dr.Item("precio_original") & "," & _
                                 dporcentaje_comision_producto & ")"

                            If Not myOtrans.Ingresa(ls_sql) > 0 Then
                                Exitoso = False
                            End If

                            If _signo <> 0 Then

                                ls_sql = "call pa_upd_um_bbj_mayorista_productos_disponibles_existencia (" & _cliente_mayorista & ",'" & dr.Item("cod_producto_mayorista") & "'," & _
                                        dr.Item("cantidad") & "," & _signo.ToString & "," & dre.Item("cod_sucursal").ToString & ")"
                                If Not myOtrans.Actualiza(ls_sql) > 0 Then
                                    Exitoso = False
                                End If
                            End If
                        End If 'Procesar Linea
                    End If 'Agregar
                    lbprocesar_linea = True
                End If
            Next

            ''Debo Modificar el Encabezado
            ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & _
                            dre.Item("correlativo") & "," & _cliente_mayorista & "," & dre.Item("cod_cliente").ToString & "," & dre.Item("tipo_movimiento").ToString & ",1,'" & _
                            dre.Item("no_externo").ToString & "','" & dre.Item("observaciones").ToString.Replace("'", " ") & "',0," & _
                            IIf(dre.Item("condicion_pago").ToString.Length = 0, "NULL", "'" & dre.Item("condicion_pago").ToString & "'") & "," & _
                            IIf(dre.Item("cod_vendedor").ToString.Length = 0, "NULL", dre.Item("cod_vendedor").ToString) & "," & _
                            Double.Parse(dre.Item("total").ToString).ToString & "," & _
                            Double.Parse(dre.Item("sub_total").ToString).ToString & "," & _
                            Double.Parse(dre.Item("desc_producto").ToString).ToString & "," & _
                            Double.Parse(dre.Item("desc_cliente").ToString).ToString & ",'" & _
                            dre.Item("usuario_grabo") & "'," & dre.Item("cod_sucursal").ToString & "," & _
                            IIf(dre.Item("fecha_pago").ToString.Length = 0, "Null", "'" & dre.Item("fecha_pago").ToString & "'") & "," & _
                            IIf(dre.Item("estado_pago").ToString.Length = 0, "Null", dre.Item("estado_pago").ToString) & ")"



            If Not myOtrans.Actualiza(ls_sql) > 0 Then
                Exitoso = False
            End If
        Catch ex As Exception
            Exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return Exitoso
    End Function

    Private Sub Obtener_Total_Encabezado(ByVal _dt As DataTable, ByRef _dr As DataRow)
        Dim dr As DataRow
        Dim total, sub_total, desc_producto, desc_cliente As Double

        total = 0
        sub_total = 0
        desc_producto = 0
        desc_cliente = 0

        Try

            For Each dr In _dt.Rows
                'dr.Item("total") = dr.Item("cantidad") * dr.Item("precio")
                total += dr.Item("total")
                sub_total += dr.Item("sub_total")
                desc_producto += dr.Item("total_desc_producto")
                desc_cliente += dr.Item("total_desc_cliente")
            Next

        Catch ex As Exception
        Finally
            _dr.Item("total") = total
            _dr.Item("sub_total") = sub_total
            _dr.Item("desc_producto") = desc_producto
            _dr.Item("desc_cliente") = desc_cliente
        End Try

    End Sub

    Public Function Obtener_Producto(ByVal sproducto As String) As DataTable
        Dim dt As New DataTable

        Dim MyOtrans As New Transaccional.Conexion_mysql("Sam")
        Dim ls_sql As String

        Try
            MyOtrans.open()
            ls_sql = "call pa_sel_um_bbj_mayorista_productos_disponibles (" & _cliente_mayorista & ",'" & sproducto & "',null," & _sucursal.ToString & ")"
            dt = MyOtrans.Obtiene(ls_sql)


        Catch ex As Exception
        Finally
            MyOtrans.close()
            MyOtrans = Nothing

        End Try
        Return dt

    End Function


    Public Function Guardar_Clientes() As Integer
        ''Guardar Clientes
        Try

        Catch ex As Exception

        End Try

    End Function

    Public Function Documentos_Pendientes_Pago(ByVal _condicion As String, ByVal no_campos As Integer) As DataTable
        Dim dt As New DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)


        Try
            myOtrans.open()
            ls_sql = "Select * from v_bbj_mayorista_encabezado_movimiento_pendiente_pago " & _
                     "Where cod_cliente = " & _cliente_mayorista.ToString & " and cod_sucursal = " & _sucursal.ToString & _
                     IIf(_condicion.ToString.Length > 0, " and " & _condicion, "")

            dt = myOtrans.Obtiene(ls_sql)


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return dt

    End Function

    Public Function Guardar_Control_Transporte(ByVal dt_encabezado As DataTable, ByVal dt_detalle As DataTable) As Integer
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim nmovimiento As Integer = -1
        Dim huboerrores As Boolean = False
        Dim icorrelativo As Integer

        Try
            myOtrans.open()
            If dt_detalle.Rows.Count > 0 Then '' Trae Detalle

                dr = dt_encabezado.Rows(0)
                ls_sql = "call pa_var_um_bbj_mayorista_control_transporte_correlativo (" & _cliente_mayorista.ToString & "," & _sucursal & ")"
                dt = myOtrans.Obtiene(ls_sql)
                icorrelativo = dt.Rows(0).Item("nuevo_correlativo")

                ls_sql = "call pa_ins_um_bbj_mayorista_control_transporte (" & _
                            icorrelativo & "," & _cliente_mayorista.ToString & "," & _sucursal.ToString & ",'" & _
                            dr.Item("referencia").ToString & "','" & _
                            dr.Item("vehiculo").ToString & "','" & dr.Item("piloto").ToString & "','" & _
                            dr.Item("ayudante").ToString & "','" & DateTime.Parse(dr.Item("fecha_entrega").ToString).ToString("yyyy-MM-dd") & "','" & _
                            dr.Item("observaciones").ToString & "','" & dr.Item("usuario").ToString & "')"

                myOtrans.Ingresa(ls_sql)

                'myOtrans.Ingresa(ls_sql)
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                nmovimiento = dt.Rows(0).Item("newid").ToString

                If nmovimiento > 0 Then
                    For Each dr In dt_detalle.Rows
                        ls_sql = " call pa_ins_um_bbj_mayorista_control_transporte_detalle (" & _
                                nmovimiento.ToString & "," & dr.Item("cod_movimiento").ToString & "," & _
                                dr.Item("orden").ToString & ")"

                        myOtrans.Ingresa(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            huboerrores = True
                        End If
                    Next
                End If 'nmovimiento
            End If 'trae detalle

            If huboerrores Then
                ''debo eliminar todo
                Eliminar_control(icorrelativo)

                icorrelativo = -1

            End If
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return icorrelativo
    End Function

    Public Function Modificar_Control_Transporte(ByVal dt_encabezado As DataTable, ByVal dt_detalle As DataTable) As Integer

        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim nmovimiento As Integer = -1
        Dim huboerrores As Boolean = False

        Try
            myOtrans.open()
            If dt_detalle.Rows.Count > 0 Then '' Trae Detalle

                dr = dt_encabezado.Rows(0)

                ls_sql = "call pa_upd_um_bbj_mayorista_control_transporte (" & _
                            dr.Item("numero").ToString & "," & _
                            _cliente_mayorista.ToString & "," & _sucursal.ToString & ",'" & _
                            dr.Item("referencia").ToString & "','" & _
                            dr.Item("vehiculo").ToString & "','" & dr.Item("piloto").ToString & "','" & _
                            dr.Item("ayudante").ToString & "','" & DateTime.Parse(dr.Item("fecha_entrega").ToString).ToString("yyyy-MM-dd") & "','" & _
                            dr.Item("observaciones").ToString & "','" & dr.Item("usuario").ToString & "')"

                myOtrans.Actualiza(ls_sql)

                If myOtrans.Codigo_error = 0 Then

                    ls_sql = "call pa_sel_um_bbj_mayorista_control_transporte (" & _cliente_mayorista & "," & _sucursal & ",1," & "' and numero = " & dr.Item("numero").ToString & "')"
                    dt = myOtrans.Obtiene(ls_sql)



                    ls_sql = "call pa_del_um_bbj_mayorista_control_transporte_detalle (" & _
                                dt.Rows(0).Item("cod_control").ToString & ")"
                    myOtrans.Elimina(ls_sql)

                    If myOtrans.Codigo_error = 0 Then

                        For Each dr In dt_detalle.Rows
                            ls_sql = " call pa_ins_um_bbj_mayorista_control_transporte_detalle (" & _
                                    dt.Rows(0).Item("cod_control").ToString & "," & dr.Item("cod_movimiento").ToString & "," & _
                                    dr.Item("orden").ToString & ")"

                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                huboerrores = True
                            End If
                        Next
                    Else
                        huboerrores = True
                    End If
                Else
                    huboerrores = True
                End If 'Sin Error
            End If 'trae detalle

            If huboerrores Then
                ''debo eliminar todo
                Eliminar_control(dt_encabezado.Rows(0).Item("numero").ToString)
            Else
                nmovimiento = 1
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return nmovimiento
    End Function

    Public Function Eliminar_control(ByVal _numero_control As Integer) As Integer
        Dim myOtrans As New Transaccional.Conexion_mysql(_nombre_conexion)
        Dim ls_sql As String
        Dim nproceso As Integer = 0
        Dim dt As DataTable


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_bbj_mayorista_control_transporte (" & _cliente_mayorista & "," & _sucursal & ",1," & "' and numero = " & _numero_control & "')"
            dt = myOtrans.Obtiene(ls_sql)

            If dt.Rows.Count = 1 Then




                ls_sql = "call pa_del_um_bbj_mayorista_control_transporte_detalle (" & dt.Rows(0).Item("cod_control").ToString & ")"
                myOtrans.Elimina(ls_sql)
                If myOtrans.Codigo_error = 0 Then
                    ls_sql = "call pa_del_um_bbj_mayorista_control_transporte (" & dt.Rows(0).Item("cod_control").ToString & ")"
                    myOtrans.Elimina(ls_sql)
                    If myOtrans.Codigo_error = 0 Then
                        nproceso = 99
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return nproceso

    End Function

    Public Function Enviar_Mensaje_CDC_MR(ByVal _asunto As String, ByVal _fecha As String, ByVal _mensaje1 As String, _
                        ByVal _mensaje2 As String, ByVal _mensaje3 As String, ByVal _usuario As String, ByVal _envio_recepcion As Integer) As Boolean

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim exitoso As Boolean = False


        Try
            myOtrans.open()
            ls_sql = "call pa_ins_um_bbj_mayorista_mensajeria (" & _cliente_mayorista & ",'" & _
                      _asunto & "','" & _
                     Date.Parse(_fecha).ToString("yyyy-MM-dd") & "','" & _
                     _mensaje1.Trim & " " & _mensaje2.Trim & " " & _mensaje3.Trim & "','" & _usuario & "'," & _
                     _envio_recepcion.ToString & ")"

            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error = 0 Then
                exitoso = True
            End If


            ''como estamos
            ''Status de Tareas, para ver q hace falta


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return exitoso
    End Function




End Class

#End Region


#Region "MaskedBox"

Public Class MaskedBox
    Inherits System.Windows.Forms.TextBox

    Private aMskMask() As Char
    Private aMask() As Char
    Private tmpMask As String
    Private a As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'MaskedBox
        '
        Me.Name = "MaskedBox"

    End Sub

#End Region

    Public Property Mask() As String

        Get
            Return tmpMask
        End Get

        Set(ByVal Value As String)
            tmpMask = Value
            SetMask()
        End Set

    End Property

    Private Sub SetMask()

        On Error Resume Next

        Me.Text = tmpMask
        Me.Text = Me.Text.Replace("#", "_")
        Me.Text = Me.Text.Replace("&", "_")

        ReDim aMask(Me.Text.Length - 1)
        ReDim aMskMask(Me.Text.Length - 1)

        For a = 0 To tmpMask.Length - 1
            If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                aMask.SetValue(CType("_", Char), a)
            Else
                aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
            End If
        Next

        For a = 0 To tmpMask.Length - 1
            aMskMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
        Next

    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim tmpset = Me.SelectionStart

        On Error Resume Next

        Select Case e.KeyCode
            Case Keys.Delete
                Me.Text = ""
                For a = tmpset To aMask.Length - 1
                    Select Case aMskMask.GetValue(a + 1)
                        Case ".", "-", "\", "/", ","
                            aMask.SetValue(aMask.GetValue(a + 2), a)
                            a = a + 1
                        Case Else
                            aMask.SetValue(aMask.GetValue(a + 1), a)
                    End Select
                Next

                aMask.SetValue(CType("_", Char), aMask.Length - 1)

                e.Handled = True

                Me.Text = ""
                For a = 0 To aMask.Length - 1
                    Me.Text += aMask.GetValue(a)
                Next
                Me.SelectionStart = tmpset

        End Select

    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        e.Handled = True
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tmpset = Me.SelectionStart
        Dim tmpCH As Char
        Dim a As Integer

        On Error Resume Next

        If Asc(e.KeyChar) = 8 Then
            Select Case CType(aMskMask.GetValue(tmpset - 1), String)
                Case ".", "-", "\", "/", ","
                    tmpset = tmpset - 2
                    aMask.SetValue(CType("_", Char), tmpset)
                    tmpset = tmpset - 1
                Case Else
                    tmpset = tmpset - 1
                    aMask.SetValue(CType("_", Char), tmpset)
                    tmpset = tmpset - 1
            End Select

            e.Handled = True

            Me.Text = ""
            For a = 0 To aMask.Length - 1
                Me.Text += aMask.GetValue(a)
            Next
            Me.SelectionStart = tmpset + 1

        ElseIf Char.IsControl(e.KeyChar) Then

        Else
            Select Case aMskMask.GetValue(tmpset)
                Case ".", "-", "\", "/", ","
                    tmpset = tmpset + 1
                    If aMskMask.GetValue(tmpset) = "#" Then
                        If Char.IsDigit(e.KeyChar) Then
                            aMask.SetValue(e.KeyChar, tmpset)
                        Else
                            tmpset = tmpset - 1
                        End If
                    ElseIf aMskMask.GetValue(tmpset) = "&" Then
                        aMask.SetValue(e.KeyChar, tmpset)
                    End If

                Case Else
                    If aMskMask.GetValue(tmpset) = "#" Then
                        If Char.IsDigit(e.KeyChar) Then
                            aMask.SetValue(e.KeyChar, tmpset)
                        Else
                            tmpset = tmpset - 1
                        End If
                    ElseIf aMskMask.GetValue(tmpset) = "&" Then
                        aMask.SetValue(e.KeyChar, tmpset)
                    End If

            End Select

            e.Handled = True

            Me.Text = ""
            For a = 0 To aMask.Length - 1
                Me.Text += aMask.GetValue(a)
            Next
            Me.SelectionStart = tmpset + 1

        End If
    End Sub

    Public Sub SetText(ByVal txt As String)

        Dim a As Integer
        On Error Resume Next

        If txt = "" Then
            For a = 0 To tmpMask.Length - 1
                If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                    aMask.SetValue(CType("_", Char), a)
                Else
                    aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
                End If
            Next
        Else
            For a = 0 To txt.Length - 1
                If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                    aMask.SetValue(CType(txt.Substring(a, 1), Char), a)
                Else
                    aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
                End If
            Next

        End If

        Me.Text = ""
        For a = 0 To aMask.Length - 1
            Me.Text += aMask.GetValue(a)
        Next

    End Sub

End Class

#End Region

Public Class Manejo_FTP
    Dim ls_log As String
    Dim ff As FTP.clsFTP

    Public Sub New(ByVal pConfiguracion As String, ByVal pConector As String)

        Dim otrans As New Transaccional.Conexion_mysql(pConector)
        Dim dt As DataTable


        ff = New FTP.clsFTP

        otrans.open()
        dt = otrans.Obtiene("call pa_sel_um_edi_configuraciones('" & pConfiguracion & "')")
        otrans.close()
        otrans = Nothing


        ' Setup the appropriate properties.
        ff.RemoteHost = dt.Rows(0)("host") '"gtmailmarketing.com"
        ff.RemoteUser = dt.Rows(0)("usuario")  '"gerber@gtmailmarketing.com"
        ff.RemotePassword = dt.Rows(0)("password") '"gerber"


        ls_log = ls_log & " Conectando al FTP " & vbCrLf
        If (ff.Login()) Then
            '            '
            '            ' Move the to Area1\Section1\Subby1\ directory.
            If dt.Rows(0)("Carpeta").ToString.Length > 0 Then
                ls_log = ls_log & "Moviendo a Carpeta Especifica " & vbCrLf
                ff.ChangeDirectory(dt.Rows(0)("Carpeta").ToString)
            End If
            'ff.ChangeDirectory("Section1")

            'ff.CreateDirectory("Subby1")
            'ff.ChangeDirectory("Subby1")
            ff.SetBinaryMode(True)
        End If

    End Sub

    Public Sub Finalizar()
        ff.CloseConnection()
    End Sub

    Public Function FTP_RenombrarArchivo(ByVal psArchivoOrigen As String, ByVal psArchivoDestino As String) As Boolean
        Dim lb_regresa As Boolean = False
        Try
            ff.RenameFile(psArchivoOrigen, psArchivoDestino)
            lb_regresa = True
        Catch ex As Exception
        End Try
        Return lb_regresa

    End Function

    Public Function FTP_SubirArchivo(ByVal pruta_archivo As String) As Boolean


        Dim lb_regresa As Boolean = False

        ls_log = ""


        ls_log = "Buscando Configuraciones" & vbCrLf



        Try
            ls_log = ls_log & " Creando Instancia FTP " & vbCrLf

            ls_log = ls_log & " Transfiriendo Archivo " & vbCrLf
            ff.UploadFile(pruta_archivo)


            ls_log = ls_log & "Transferencia Finalizada Correctamente " & vbCrLf
            lb_regresa = True
        Catch ex As System.Exception            '        
            ls_log = ls_log & "Error: " & ex.Message & vbCrLf
            ls_log = ls_log & "Error: " & ff.MessageString & vbCrLf
        End Try


        Return lb_regresa
    End Function

    Public Function FTP_ListaArchivo(ByVal ptipo_archivo As String) As String()


        Dim lb_regresa As Boolean = False
        Dim archivos As String()



        ls_log = ""

        ls_log = "Buscando Configuraciones" & vbCrLf

        Try
            archivos = ff.GetFileList(ptipo_archivo)

            lb_regresa = True
        Catch ex As System.Exception            '        

            ls_log = ls_log & "Error: " & ex.Message & vbCrLf
            ls_log = ls_log & "Error: " & ff.MessageString & vbCrLf
        End Try

        Return archivos
    End Function

    Public Function FTP_EliminaArchivo(ByVal pnombre_archivo As String) As Boolean
        Dim Exito As Boolean
        Try
            If pnombre_archivo.Length > 0 Then
                Exito = ff.DeleteFile(pnombre_archivo)
            Else
                Exito = True
            End If
        Catch ex As Exception
            Exito = False

        End Try
        Return Exito
    End Function

    Public Function FTP_CambiarDirectorio(ByVal nombrecarpeta As String) As Boolean

        Return ff.ChangeDirectory(nombrecarpeta)

    End Function

End Class

Public Class Imprimir_TMU
    ''' <summary>
    ''' 
    ''' </summary>
    'Dim prt As prtcom.Imprimir_Puerto  ''Se Debe Registrar el componente  prtcom en el equipo
    Dim lspuerto As String
    Public MaxLen As Integer = 40
    Dim pcsNombreArchivo As String = String.Empty



    Public Sub New(ByVal lPuerto As String)
        '   prt = New prtcom.Imprimir_Puerto
        lspuerto = lPuerto
    End Sub

    Public Sub New(ByVal lPuerto As String, ByVal psNombreArchivo As String)
        '  prt = New prtcom.Imprimir_Puerto
        lspuerto = lPuerto
        pcsNombreArchivo = psNombreArchivo
    End Sub

    Public Sub Imprimir_Linea(ByVal Cadena As String)
        Imprimir_Linea(Cadena, False)
    End Sub
    Public Sub Imprimir_Linea(ByVal Cadena As String, ByVal Centrar As Boolean)
        Dim diferencia As Integer
        Dim CadenaImprimir As String
        If Centrar Then

            If Len(Cadena) < MaxLen Then
                diferencia = (MaxLen - Len(Cadena)) / 2
                If Len(Cadena) + (diferencia) * 2 > MaxLen Then
                    diferencia -= 1
                End If
                '  Cadena = Cadena.PadLeft(diferencia, Space(1))
                ' Cadena = Cadena.PadRight(diferencia - 1, Space(1))
            End If
        End If
        CadenaImprimir = Cadena.ToString.Replace("ñ", Chr(164)).Replace("ó", Chr(162)).Replace("é", Chr(130))
        ' prt.Imprimir(Space(diferencia) + CadenaImprimir, lspuerto)
        System.Threading.Thread.CurrentThread.Sleep(150)
        If pcsNombreArchivo.Length > 0 Then escribirLog(Space(diferencia) + CadenaImprimir & vbCrLf)
    End Sub

    Public Sub Imprimir_Linea_Blanco()
        'prt.Imprimir(Chr(27), lspuerto)
        System.Threading.Thread.CurrentThread.Sleep(150)
        If pcsNombreArchivo.Length > 0 Then escribirLog(" " & vbCrLf)
    End Sub
    Public Sub FinyCortar()
        'prt.FinyCortar(lspuerto)
    End Sub


    Private Function escribirLog(ByVal _plinea As String) As Boolean
        Dim myStreamWriter As StreamWriter

        Dim lexito As Boolean = True
        Try
            myStreamWriter = File.AppendText(pcsNombreArchivo)

            myStreamWriter.Write(_plinea)
            myStreamWriter.Flush()
            myStreamWriter.Close()
            myStreamWriter = Nothing

        Catch ex As Exception
            lexito = False
        End Try

        Return lexito

    End Function

End Class
