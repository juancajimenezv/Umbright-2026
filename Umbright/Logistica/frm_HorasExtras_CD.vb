Imports System.Data


Public Class frm_HorasExtras_CD

    Private Sub HorariosExtraordinariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim horario_Extraordinario As New frm_Horarios_Extraordinarios
        horario_Extraordinario.Show()

    End Sub


    'Private Sub btn_Ver_Reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ver_Reporte.Click

    '    Dim aoTrans As New Transaccional.Conexion_Access("marcaje")
    '    Dim oTrans As New Transaccional.Conexion("Flexline")
    '    Dim scmTrans As New Transaccional.Conexion("SCM")
    '    Dim ClsGen As New ClasesGenerales.General

    '    Dim ds As New DataSet
    '    Dim dt, dtReporte As New DataTable
    '    Dim sl_sql, usuarios As String
    '    Dim index, totalExtra As Integer
    '    Dim horaExtra As DateTime


    '    Try
    '        'Obtengo listado de usuarios

    '        scmTrans.open()
    '        sl_sql = "pa_sel_um_seg_usuario_horarios"
    '        dt = scmTrans.Obtiene(sl_sql)
    '        dt.TableName = "usuarios"
    '        ds.Tables.Add(dt.Copy)


    '        usuarios = ""
    '        index = 0
    '        For Each row As DataRow In ds.Tables("usuarios").Rows
    '            If (index = 0) Then usuarios = "'" & ds.Tables("usuarios").Rows(index).Item("num_card") & "'"
    '            If (index > 0) Then usuarios = usuarios & ",'" & ds.Tables("usuarios").Rows(index).Item("num_card") & "'"
    '            index += 1
    '        Next

    '        'Obtengo todos los pickings en las fechas solicitadas
    '        oTrans.open()

    '        sl_sql = "select empresa,nombre_picking as nombre,fecha_impresion_picking as fecha from flexline.gen_log_documento_tracking where fecha_impresion_picking>='" & _
    '                    dtp_fecha_inicio.Text & " 00:00:00' and fecha_impresion_picking <='" & _
    '                    dtp_fecha_final.Text & " 23:59:59'"

    '        dt = oTrans.Obtiene(sl_sql)
    '        dt.TableName = "pickings"
    '        ds.Tables.Add(dt.Copy)

    '        'Obtengo todos los marcajes en el rango de fechas de todos usuarios
    '        aoTrans.Open()
    '        aoTrans.Nombre_Tabla = "EntryExitFile"
    '        aoTrans.Lista_Campos = "CardNo,Date,Time"
    '        aoTrans.Condiciones = "Date>=#" & Convert.ToDateTime(dtp_fecha_inicio.Text).ToString("MM/dd/yyyy") & _
    '                                    "# and Date<=#" & Convert.ToDateTime(dtp_fecha_final.Text).ToString("MM/dd/yyyy") & _
    '                                    "# and CardNo in(" & usuarios & ")"

    '        dt = aoTrans.Obtiene
    '        dt.TableName = "accesos"
    '        ds.Tables.Add(dt.Copy)


    '        ' Estructura tabla final
    '        dtReporte.Columns.Add(New DataColumn("Nombre", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Fecha", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Horario Entrada", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Horario Salida", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Marcaje Entrada", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Marcaje Salida", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Hora Extra", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Codicasa", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("DMarte", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Alamsa", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Vinoteca", GetType(String)))
    '        dtReporte.Columns.Add(New DataColumn("Diuva", GetType(String)))


    '        'Obtengo los horarios extraordinarios
    '        scmTrans.open()
    '        sl_sql = "select nombre,fecha,hora_entrada,hora_salida from seg_usuario_horarios_extraordinario where fecha>='" & _
    '                    dtp_fecha_inicio.Text & "' and fecha<='" & dtp_fecha_final.Text & "'"
    '        dt = scmTrans.Obtiene(sl_sql)
    '        dt.TableName = "HorarioExtraordinario"
    '        ds.Tables.Add(dt.Copy)


    '        Dim fecha As Date = dtp_fecha_inicio.Text
    '        While fecha <= dtp_fecha_final.Text
    '            dt.Clear()

    '            'Obtengo horarios vigentes en el dia procesado
    '            sl_sql = "select nombre,dia,MAX(fecha_inicio) fecha,max(hora_entrada) HoraEntrada,max(hora_salida) HoraSalida from seg_usuario_horarios where fecha_inicio<='" & _
    '                        fecha.ToString("dd/MM/yyyy") & "' and dia='" & quitar_acentos(fecha.ToString("dddd")) & "' group by nombre,dia"

    '            dt = scmTrans.Obtiene(sl_sql)
    '            dt.TableName = "horarios"
    '            If ds.Tables.Contains("horarios") Then ds.Tables.Remove("horarios")
    '            ds.Tables.Add(dt.Copy)

    '            Dim newRow As DataRow
    
    '            index = 0

    '            'Recorro todos los usuarios, identifico quienes trabajaron extra en el dia procesado
    '            For Each row As DataRow In ds.Tables("usuarios").Rows
    '                newRow = dtReporte.NewRow()

    '                'Verifico la hora del marcaje del dia
    '                If IsDBNull(ds.Tables("accesos").Compute("Max(Time)", "Date='" & fecha & _
    '                                "' and CardNo='" & ds.Tables("usuarios").Rows(index).Item("num_card").ToString & "'")) Then

    '                    newRow("Marcaje Entrada") = ""
    '                    newRow("Marcaje Salida") = ""

    '                Else
    '                    newRow("Marcaje Salida") = ds.Tables("accesos").Compute("Max(Time)", "Date='" & fecha & "' and CardNo='" & ds.Tables("usuarios").Rows(index).Item("num_card").ToString & "'")
    '                    newRow("Marcaje Entrada") = ds.Tables("accesos").Compute("Min(Time)", "Date='" & fecha & "' and CardNo='" & ds.Tables("usuarios").Rows(index).Item("num_card").ToString & "'")
    '                End If


    '                'Verifico si existen horarios establecidos.
    '                If IsDBNull(ds.Tables("horarios").Compute("Max(HoraEntrada)", "nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")) Then
    '                    newRow("Horario Entrada") = ""
    '                    newRow("Horario Salida") = ""
    '                Else
    '                    newRow("Horario Entrada") = ds.Tables("horarios").Compute("Max(HoraEntrada)", "nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")
    '                    newRow("Horario Salida") = ds.Tables("horarios").Compute("Max(HoraSalida)", "nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")
    '                End If


    '                'Verifico si hay horarios extraordinarios
    '                If IsDBNull(ds.Tables("HorarioExtraordinario").Compute("Max(hora_entrada)", "fecha='" & fecha & "' and nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")) Then
    '                Else
    '                    newRow("Horario Entrada") = ds.Tables("HorarioExtraordinario").Compute("Max(hora_entrada)", "fecha='" & fecha & "' and nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")
    '                    newRow("Horario Salida") = ds.Tables("HorarioExtraordinario").Compute("Min(hora_salida)", "fecha='" & fecha & "' and nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre").ToString & "'")
    '                End If


    '                newRow("Nombre") = ds.Tables("usuarios").Rows(index).Item("nombre").ToString
    '                newRow("Fecha") = fecha.ToString("dd/MM/yyyyy")

    '                'Cuento los picking de usuarios en cada empresa fuera de horarios
    '                Dim condicion As String
    '                condicion = "nombre='" & ds.Tables("usuarios").Rows(index).Item("nombre") & _
    '                                    "' and ((fecha<'" & fecha & " " & newRow("Horario Entrada").ToString & _
    '                                    "' and fecha>'" & fecha & " 00:00') or (fecha>'" & fecha & " " & _
    '                                    newRow("Horario Salida").ToString & "' and fecha<'" & fecha & " 23:59')) and empresa="

    '                If newRow("Marcaje Entrada").ToString <> "" And newRow("Marcaje Salida").ToString <> "" Then
    '                    newRow("codicasa") = "0"
    '                    newRow("DMarte") = "0"
    '                    newRow("Alamsa") = "0"
    '                    newRow("Vinoteca") = "0"
    '                    newRow("Diuva") = "0"

    '                    If ((newRow("Marcaje Salida").ToString > newRow("Horario Salida").ToString) Or (newRow("Marcaje Entrada").ToString < newRow("Horario Entrada").ToString)) Then
    '                        If IsDBNull(ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'CODICASA'")) Then newRow("codicasa") = "0" Else newRow("codicasa") = ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'CODICASA'")
    '                        If IsDBNull(ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'DMARTE1'")) Then newRow("DMarte") = "0" Else newRow("DMarte") = ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'DMARTE1'")
    '                        If IsDBNull(ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'ALAMSA'")) Then newRow("Alamsa") = "0" Else newRow("Alamsa") = ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'ALAMSA'")
    '                        If IsDBNull(ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'VINOTECA'")) Then newRow("Vinoteca") = "0" Else newRow("Vinoteca") = ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'VINOTECA'")
    '                        If IsDBNull(ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'DIUVA'")) Then newRow("Diuva") = "0" Else newRow("Diuva") = ds.Tables("pickings").Compute("Count(empresa)", "" & condicion & "'DIUVA'")

    '                    End If
    '                End If

    '                'Calcular las horas extra
    '                newRow("Hora Extra") = "00:00:00"
    '                totalExtra = 0
    '                horaExtra = "00:00:00"

    '                If newRow("Marcaje Entrada").ToString <> "" And newRow("Horario Entrada").ToString <> "" Then
    '                    If DateDiff(DateInterval.Second, Convert.ToDateTime(newRow("Marcaje Entrada")), Convert.ToDateTime(newRow("Horario Entrada"))) < 0 Then
    '                        newRow("Marcaje Entrada") = newRow("Horario Entrada")

    '                    End If

    '                    totalExtra = DateDiff(DateInterval.Second, Convert.ToDateTime(newRow("Marcaje Entrada")), Convert.ToDateTime(newRow("Horario Entrada")))
    '                    If totalExtra > 0 Then
    '                        newRow("Hora Extra") = horaExtra.AddSeconds(totalExtra).ToString("HH:mm:ss")
    '                    End If
    '                End If

    '                If newRow("Marcaje Salida").ToString <> "" And newRow("Horario Salida").ToString <> "" Then
    '                    horaExtra = "00:00:00"
    '                    If DateDiff(DateInterval.Second, Convert.ToDateTime(newRow("Horario Salida")), Convert.ToDateTime(newRow("Marcaje Salida"))) > 0 Then
    '                        If totalExtra > 0 Then
    '                            totalExtra = totalExtra + DateDiff(DateInterval.Second, Convert.ToDateTime(newRow("Horario Salida")), Convert.ToDateTime(newRow("Marcaje Salida")))
    '                            newRow("Hora Extra") = horaExtra.AddSeconds(totalExtra).ToString("HH:mm:ss")
    '                        Else
    '                            totalExtra = DateDiff(DateInterval.Second, Convert.ToDateTime(newRow("Horario Salida")), Convert.ToDateTime(newRow("Marcaje Salida")))
    '                            newRow("Hora Extra") = horaExtra.AddSeconds(totalExtra).ToString("HH:mm:ss")

    '                        End If
    '                    End If
    '                End If


    '                dtReporte.Rows.Add(newRow)

    '                index += 1
    '            Next

    '            fecha = fecha.AddDays(1)

    '        End While


    '        dtReporte.TableName = "Reporte"
    '        ds.Tables.Add(dtReporte.Copy)
    '        dgv_listado_usuarios.DataSource = ds.Tables("Reporte")

    '        ClsGen.Alinear_GridView(ds.Tables("Reporte"), dgv_listado_usuarios, ",Nombre,Fecha,Horario Entrada,Horario Salida,Marcaje Entrada,Marcaje Salida,Hora Extra,Codicasa,DMarte,Alamsa,Vinoteca,Diuva,", "", "", "", False, True, 250, 0)

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR: " & oTrans.descripcion_error & ", " & ex.Message)
    '        If oTrans.Codigo_error > 0 Then MessageBox.Show("ERROR: " & oTrans.descripcion_error)

    '    Finally
    '        aoTrans.Close()
    '        oTrans.close()
    '        scmTrans.close()

    '        aoTrans = Nothing
    '        oTrans = Nothing
    '        scmTrans = Nothing

    '    End Try

    'End Sub

    Private Function quitar_acentos(ByVal palabra As String)
        Dim ConAcento() As String = {"á", "é", "í", "ó", "ú", "Á", "É", "Í", "Ó", "Ú"}
        Dim SinAcento() As String = {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}
        Dim numCaracteres, i As Integer
        numCaracteres = palabra.Length

        For i = 0 To numCaracteres - 1
            palabra = Replace(palabra, ConAcento(i), SinAcento(i))
        Next

        Return (palabra)

    End Function

    Private Function obtener_horarios(ByVal cardsNo As String, ByVal fecha_inicio As Date, ByVal fecha_final As Date)

        Dim aoTrans As New Transaccional.Conexion_Access("marcaje")
        Dim scmTrans As New Transaccional.Conexion("SCM")
        Dim ls_sql, dia, num_card As String
        Dim fecha As DateTime
        Dim dt, dt_horarios As New DataTable
        Dim ds As New DataSet
        Dim index As Integer
        Dim dr() As DataRow

        Try
            'Obtengo Marcajes en las fechas solicitadas
            aoTrans.Open()
            aoTrans.Nombre_Tabla = "EntryExitFile"
            aoTrans.Lista_Campos = "Date as Fecha,CardNo,Min(Time) as Marcaje_Entrada,Max(Time) as Marcaje_Salida"
            aoTrans.Condiciones = "Date>=#" & fecha_inicio.ToString("MM/dd/yyyy") & "# and Date<=#" & fecha_final.ToString("MM/dd/yyyy") & "# and CardNo in(" & cardsNo & ") GROUP BY cardNo,HolderName,Date"
            aoTrans.Ordenamiento = "HolderName,Date"

            dt_horarios = aoTrans.Obtiene

            'Completo la Estructura

            dt_horarios.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt_horarios.Columns.Add(New DataColumn("Horario Normal_Entrada", GetType(String)))
            dt_horarios.Columns.Add(New DataColumn("Horario Normal_Salida", GetType(String)))
            dt_horarios.Columns.Add(New DataColumn("Horario Extra_Entrada", GetType(String)))
            dt_horarios.Columns.Add(New DataColumn("Horario Extra_Salida", GetType(String)))

            'Obtengo los horarios normales y extraordinarios de todos los usuarios
            scmTrans.open()
            ls_sql = "pa_sel_um_seg_usuario_horarios_normales"
            dt = scmTrans.Obtiene(ls_sql)
            dt.TableName = "Horarios_Normales"
            ds.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_seg_usuario_horarios"
            dt = scmTrans.Obtiene(ls_sql)
            dt.TableName = "Nombres"
            ds.Tables.Add(dt.Copy)


            ls_sql = "pa_sel_um_seg_usuario_horarios_extraordinario"
            dt = scmTrans.Obtiene(ls_sql)
            dt.TableName = "Horarios_Extraordinarios"
            ds.Tables.Add(dt.Copy)


            index = 0
            For Each Row As DataRow In dt_horarios.Rows

                dia = quitar_acentos(Convert.ToDateTime(dt_horarios.Rows(index).Item("fecha")).ToString("dddd"))
                fecha = Convert.ToDateTime(dt_horarios.Rows(index).Item("fecha"))
                num_card = dt_horarios.Rows(index).Item("CardNo")

                'Obtengo los nombres
                dr = ds.Tables("Nombres").Select("num_card='" & num_card & "'")
                If dr.GetLength(0) > 0 Then
                    dt_horarios.Rows(index).Item("Nombre") = dr(0)("Nombre")
                End If

                'Obtengo Horarios Normales en las fechas solicitadas
                dr = ds.Tables("Horarios_Normales").Select("num_card='" & num_card & "' and dia='" & dia & _
                                                            "' and fecha_inicio<'" & fecha.AddDays(1) & "'", "fecha_inicio desc")
                If dr.GetLength(0) > 0 Then
                    dt_horarios.Rows(index).Item("Horario Normal_Entrada") = dr(0)("hora_entrada")
                    dt_horarios.Rows(index).Item("Horario Normal_Salida") = dr(0)("hora_salida")
                Else
                    dt_horarios.Rows(index).Item("Horario Normal_Entrada") = "00:00:00"
                    dt_horarios.Rows(index).Item("Horario Normal_Salida") = "00:00:00"
                End If

                'Obtengo Horarios Extraordinarios en las fechas solicitadas
                dr = ds.Tables("Horarios_Extraordinarios").Select("num_card='" & num_card & "' and fecha='" & Convert.ToDateTime(dt_horarios.Rows(index).Item("fecha")) & "'")
                If dr.GetLength(0) = 1 Then
                    dt_horarios.Rows(index).Item("Horario Extra_Entrada") = dr(0)("hora_entrada")
                    dt_horarios.Rows(index).Item("Horario Extra_Salida") = dr(0)("hora_salida")
                Else
                    dt_horarios.Rows(index).Item("Horario Extra_Entrada") = "00:00:00"
                    dt_horarios.Rows(index).Item("Horario Extra_Salida") = "00:00:00"
                End If

                index += 1

            Next

            Return (dt_horarios)

        Catch ex As Exception
            MessageBox.Show("ERROR: " & aoTrans.descripcion_error & ", " & ex.Message)
            MessageBox.Show("ERROR: " & scmTrans.descripcion_error & ", " & ex.Message)

        Finally
            aoTrans.Close()
            aoTrans = Nothing

            scmTrans.close()
            scmTrans = Nothing

        End Try

    End Function

    Private Function obtener_usuarios()
        Dim scmTrans As New Transaccional.Conexion("SCM")
        Dim dt As New DataTable
        Dim sl_sql, usuarios As String
        Dim index As Integer

        Try
            scmTrans.open()
            sl_sql = "pa_sel_um_seg_usuario_horarios"
            dt = scmTrans.Obtiene(sl_sql)
            usuarios = ""

            index = 0
            For Each row As DataRow In dt.Rows
                If (index = 0) Then usuarios = "'" & dt.Rows(index).Item("num_card") & "'"
                If (index > 0) Then usuarios = usuarios & ",'" & dt.Rows(index).Item("num_card") & "'"

                index += 1
            Next
            Return (usuarios)

        Catch ex As Exception
            MessageBox.Show("ERROR: " & scmTrans.descripcion_error & ", " & ex.Message)

        Finally
            scmTrans.close()
            scmTrans = Nothing

        End Try

    End Function

    'Private Function obtener_horas_laboradas(ByVal dt_Marcajes As DataTable)
    '    'Estructura de tabla dt_Marcajes CardNo(num_card),Nombre(empleado),Fecha(fechaMarcaje),Entrada(horaMarcaje),Salida(HoraMarcajeSalida)
    '    Dim scmTrans As New Transaccional.Conexion("SCM")
    '    Dim index As Integer
    '    Dim ls_sql As String
    '    Dim dt As New DataTable
    '    Dim ds As New DataSet
    '    Dim dia, num_card As String
    '    Dim dr() As DataRow

    '    dt_Marcajes.Columns.Add(New DataColumn("Horario Normal_Entrada", GetType(String)))
    '    dt_Marcajes.Columns.Add(New DataColumn("Horario Normal_Salida", GetType(String)))
    '    dt_Marcajes.Columns.Add(New DataColumn("Horario Extra_Entrada", GetType(String)))
    '    dt_Marcajes.Columns.Add(New DataColumn("Horario Extra_Salida", GetType(String)))
    '    dt_Marcajes.Columns.Add(New DataColumn("Tiempo_Total_Laborado", GetType(String)))
    '    'dt_Marcajes.Columns.Add(New DataColumn("H_Jornada", GetType(String)))
    '    'dt_Marcajes.Columns.Add(New DataColumn("T_Extra", GetType(String)))

    '    Try

    '        'Obtengo los horarios normales y extraordinarios de todos los usuarios
    '        scmTrans.open()
    '        ls_sql = "pa_sel_um_seg_usuario_horarios_normales"
    '        dt = scmTrans.Obtiene(ls_sql)
    '        dt.TableName = "Horarios_Normales"
    '        ds.Tables.Add(dt.Copy)

    '        ls_sql = "pa_sel_um_seg_usuario_horarios_extraordinario"
    '        dt = scmTrans.Obtiene(ls_sql)
    '        dt.TableName = "Horarios_Extraordinarios"
    '        ds.Tables.Add(dt.Copy)

    '        index = 0
    '        For Each Row As DataRow In dt_Marcajes.Rows
    '            dia = quitar_acentos(Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")).ToString("dddd"))
    '            num_card = dt_Marcajes.Rows(index).Item("CardNo")

    '            'Obtengo Horarios Normales
    '            dr = ds.Tables("Horarios_Normales").Select("num_card='" & num_card & "' and dia='" & dia & "'")
    '            If dr.GetLength(0) = 1 Then
    '                dt_Marcajes.Rows(index).Item("Horario Normal_Entrada") = dr(0)("hora_entrada")
    '                dt_Marcajes.Rows(index).Item("Horario Normal_Salida") = dr(0)("hora_salida")
    '            Else
    '                dt_Marcajes.Rows(index).Item("Horario Normal_Entrada") = "00:00:00"
    '                dt_Marcajes.Rows(index).Item("Horario Normal_Salida") = "00:00:00"
    '            End If

    '            'Obtengo Horarios Extraordinarios
    '            dr = ds.Tables("Horarios_Extraordinarios").Select("num_card='" & num_card & "' and fecha='" & Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")) & "'")
    '            If dr.GetLength(0) = 1 Then
    '                dt_Marcajes.Rows(index).Item("Horario Extra_Entrada") = dr(0)("hora_entrada")
    '                dt_Marcajes.Rows(index).Item("Horario Extra_Salida") = dr(0)("hora_salida")
    '            Else
    '                dt_Marcajes.Rows(index).Item("Horario Extra_Entrada") = "00:00:00"
    '                dt_Marcajes.Rows(index).Item("Horario Extra_Salida") = "00:00:00"
    '            End If



    '            index += 1

    '        Next


    '        'For Each row As DataRow In dt_Marcajes.Rows
    '        '    dt_Marcajes.Rows(index).Item("Horas_Laboradas") = "00:00:00"
    '        '    dia = quitar_acentos(Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")).ToString("dddd"))
    '        '    num_card = dt_Marcajes.Rows(index).Item("CardNo")

    '        '    'Verifico el horario normal y lo ajusto tiene entrada antes del mismo
    '        '    If Not IsDBNull(ds.Tables("Horario_Normal").Compute("count(num_card)", "num_card='" & num_card & "' and dia='" & dia & "'")) Then

    '        '        If ds.Tables("Horario_Normal").Compute("count(num_card)", "num_card='" & num_card & "' and dia='" & dia & "'") > 0 Then
    '        '            dr = ds.Tables("Horario_Normal").Select("num_card='" & num_card & "' and dia='" & dia & "'")

    '        '            If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Entrada")), Convert.ToDateTime(dr(0)("hora_entrada"))) > 0 Then
    '        '                dt_Marcajes.Rows(index).Item("Entrada") = dr(0)("hora_entrada")
    '        '            End If

    '        '        End If

    '        '    End If

    '        '    'Verifico si existe horario extraordinario y lo ajusto si tiene marcaje antes del mismo
    '        '    If Not IsDBNull(ds.Tables("Horario_Extraordinario").Compute("count(num_card)", "num_card='" & num_card & "' and fecha='" & Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")) & "'")) Then

    '        '        If ds.Tables("Horario_Extraordinario").Compute("count(num_card)", "num_card='" & num_card & "' and fecha='" & Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")) & "'") > 0 Then
    '        '            dr = ds.Tables("Horario_Extraordinario").Select("num_card='" & num_card & "' and fecha='" & Convert.ToDateTime(dt_Marcajes.Rows(index).Item("fecha")) & "'")

    '        '            If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Entrada")), Convert.ToDateTime(dr(0)("hora_entrada"))) > 0 Then
    '        '                dt_Marcajes.Rows(index).Item("Entrada") = dr(0)("hora_entrada")
    '        '            End If

    '        '        End If

    '        '    End If

    '        '    'Calcular las horas efectivas laboradas
    '        '    If IsDate(dt_Marcajes.Rows(index).Item("Entrada")) Then

    '        '        If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Entrada")), Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Salida"))) > 0 Then
    '        '            dt_Marcajes.Rows(index).Item("Horas_Laboradas") = Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Horas_Laboradas")).AddSeconds(DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Entrada")), Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Salida")))).ToString("HH:mm:ss")

    '        '        End If

    '        '    End If

    '        '    'Calcular las horas de jornada y horas extra
    '        '    dt_Marcajes.Rows(index).Item("H_Jornada") = "00:00:00"
    '        '    dt_Marcajes.Rows(index).Item("T_Extra") = "00:00:00"
    '        '    dt_Marcajes.Rows(index).Item("H_Jornada") = Convert.ToDateTime(dt_Marcajes.Rows(index).Item("H_Jornada")).AddSeconds(DateDiff(DateInterval.Second, Convert.ToDateTime(dr(0)("hora_entrada")), Convert.ToDateTime(dr(0)("hora_salida")))).ToString("HH:mm:ss")

    '        '    If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("H_Jornada")), Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Horas_Laboradas"))) > 0 Then
    '        '        dt_Marcajes.Rows(index).Item("T_Extra") = Convert.ToDateTime(dt_Marcajes.Rows(index).Item("T_Extra")).AddSeconds(DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Marcajes.Rows(index).Item("H_Jornada")), Convert.ToDateTime(dt_Marcajes.Rows(index).Item("Horas_Laboradas")))).ToString("HH:mm:ss")

    '        '    End If

    '        '    index = index + 1

    '        'Next

    '        Return (dt_Marcajes)

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR: " & scmTrans.descripcion_error & ", " & ex.Message)

    '     Finally
    '        scmTrans.close()
    '        scmTrans = Nothing

    '    End Try

    'End Function

    Private Function calcular_tiempo_extra(ByVal dt_horarios As DataTable)
        Dim h_entrada, h_salida, h_laboradas, j_normal As DateTime
        Dim s_diferencia As Integer

        Dim index As Integer

        dt_horarios.Columns.Add(New DataColumn("Tiempo_Total_Laborado", GetType(String)))
        dt_horarios.Columns.Add(New DataColumn("Tiempo_Extra", GetType(String)))
        dt_horarios.Columns.Add(New DataColumn("Tiempo_Extra_Bruto", GetType(String)))

        index = 0
        For Each row As DataRow In dt_horarios.Rows
            dt_horarios.Rows(index).Item("Tiempo_Extra") = "00:00:00"
            dt_horarios.Rows(index).Item("Tiempo_Total_Laborado") = "00:00:00"
            dt_horarios.Rows(index).Item("Tiempo_Extra_Bruto") = "00:00:00"

            'Jornada Normal
            j_normal = "00:00:00"
            j_normal = j_normal.AddSeconds(DateDiff(DateInterval.Second, Convert.ToDateTime(dt_horarios.Rows(index).Item("Horario Normal_Entrada")), Convert.ToDateTime(dt_horarios.Rows(index).Item("Horario Normal_Salida"))))

            If dt_horarios.Rows(index).Item("Horario Extra_Entrada") <> "00:00:00" And dt_horarios.Rows(index).Item("Horario Extra_Entrada") <> "00:00:00" Then

                'Hora Entrada Ajustada
                If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_horarios.Rows(index).Item("Marcaje_Entrada")), Convert.ToDateTime(dt_horarios.Rows(index).Item("Horario Extra_Entrada"))) >= 0 Then
                    h_entrada = dt_horarios.Rows(index).Item("Horario Extra_Entrada")
                Else
                    h_entrada = dt_horarios.Rows(index).Item("Marcaje_Entrada")

                End If

                'Hora Salida Ajustada
                If DateDiff(DateInterval.Second, Convert.ToDateTime(dt_horarios.Rows(index).Item("Horario Extra_Salida")), Convert.ToDateTime(dt_horarios.Rows(index).Item("Marcaje_Salida"))) >= 0 Then
                    h_salida = dt_horarios.Rows(index).Item("Horario Extra_Salida")
                Else
                    h_salida = dt_horarios.Rows(index).Item("Marcaje_Salida")

                End If

                h_laboradas = "00:00:00"
                If DateDiff(DateInterval.Second, h_entrada, h_salida) > 0 Then
                    h_laboradas = h_laboradas.AddSeconds(DateDiff(DateInterval.Second, h_entrada, h_salida))

                End If

                'Tiempo Extra Ajustado
                If DateDiff(DateInterval.Second, j_normal, h_laboradas) > 0 Then

                    dt_horarios.Rows(index).Item("Tiempo_Extra") = Convert.ToDateTime(dt_horarios.Rows(index).Item("Tiempo_Extra")).AddSeconds(DateDiff(DateInterval.Second, j_normal, h_laboradas)).ToString("HH:mm:ss")

                End If

            End If

            'Obtengo Tiempo Total Laborado
            h_entrada = Convert.ToDateTime(dt_horarios.Rows(index).Item("marcaje_entrada"))
            h_salida = Convert.ToDateTime(dt_horarios.Rows(index).Item("marcaje_salida"))
            s_diferencia = DateDiff(DateInterval.Second, h_entrada, h_salida)

            If s_diferencia > 0 Then
                dt_horarios.Rows(index).Item("tiempo_total_laborado") = Convert.ToDateTime(dt_horarios.Rows(index).Item("tiempo_total_laborado")).AddSeconds(s_diferencia).ToString("HH:mm:ss")

            End If

            'Obtengo Tiempo Extra Bruto
            h_laboradas = dt_horarios.Rows(index).Item("tiempo_total_laborado")
            s_diferencia = DateDiff(DateInterval.Second, j_normal, h_laboradas)

            If s_diferencia > 0 Then
                dt_horarios.Rows(index).Item("tiempo_extra_bruto") = Convert.ToDateTime(dt_horarios.Rows(index).Item("tiempo_extra_bruto")).AddSeconds(s_diferencia).ToString("HH:mm:ss")

            End If



            index += 1
        Next

        Return (dt_horarios)

    End Function

    Private Function contar_picking(ByVal dt_horarios As DataTable)
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim h_entrada, h_salida, f_inicio, f_final, fecha, condicion As String
        Dim sl_sql As String
        Dim dt_picking As New DataTable
        Dim dr() As DataRow
        Dim index As Integer

        'Agregar a Estructura
        dt_horarios.Columns.Add(New DataColumn("Codicasa", GetType(Integer)))
        dt_horarios.Columns.Add(New DataColumn("DMarte", GetType(Integer)))
        dt_horarios.Columns.Add(New DataColumn("Alamsa", GetType(Integer)))
        dt_horarios.Columns.Add(New DataColumn("Vinoteca", GetType(Integer)))
        dt_horarios.Columns.Add(New DataColumn("Diuva", GetType(Integer)))

        Try
            'Obtener todos los picking en el rango de fechas
            oTrans.open()
            sl_sql = "pa_sel_um_gen_log_documento_tracking_fecha '" & _
                        dtp_fec_inicio.Text & " 00:00:00','" & dtp_fec_final.Text & " 23:59:59'"

            dt_picking = oTrans.Obtiene(sl_sql)

            'Cuento los picking de cada usuario en cada empresa
            index = 0
            For Each row As DataRow In dt_horarios.Rows
                dt_horarios.Rows(index).Item("Codicasa") = 0
                dt_horarios.Rows(index).Item("Dmarte") = 0
                dt_horarios.Rows(index).Item("Alamsa") = 0
                dt_horarios.Rows(index).Item("Vinoteca") = 0
                dt_horarios.Rows(index).Item("Diuva") = 0

                If (dt_horarios.Rows(index).Item("Horario Extra_Entrada") <> "00:00:00") And (dt_horarios.Rows(index).Item("Horario Extra_Salida") <> "00:00:00") Then
                    fecha = Convert.ToDateTime(dt_horarios.Rows(index).Item("fecha")).ToString("dd/MM/yyyy")
                    f_inicio = fecha & " 00:00:00"
                    f_final = fecha & " 23:59:59"
                    h_entrada = fecha & " " & dt_horarios.Rows(index).Item("Horario Normal_Entrada")
                    h_salida = fecha & " " & dt_horarios.Rows(index).Item("Horario Normal_Salida")

                    condicion = "AND nombre='" & dt_horarios.Rows(index).Item("nombre") & _
                                        "' AND fecha>'" & Convert.ToDateTime(f_inicio) & _
                                        "' AND fecha<'" & Convert.ToDateTime(f_final) & _
                                        "' AND (fecha>'" & Convert.ToDateTime(h_salida) & _
                                        "' OR fecha>'" & Convert.ToDateTime(h_salida) & "')"

                    dr = dt_picking.Select("empresa='CODICASA' " & condicion)
                    dt_horarios.Rows(index).Item("Codicasa") = dr.GetLength(0)

                    dr = dt_picking.Select("empresa='DMARTE1' " & condicion)
                    dt_horarios.Rows(index).Item("Dmarte") = dr.GetLength(0)

                    dr = dt_picking.Select("empresa='ALAMSA' " & condicion)
                    dt_horarios.Rows(index).Item("Alamsa") = dr.GetLength(0)

                    dr = dt_picking.Select("empresa='VINOTECA' " & condicion)
                    dt_horarios.Rows(index).Item("Vinoteca") = dr.GetLength(0)

                    dr = dt_picking.Select("empresa='DIUVA' " & condicion)
                    dt_horarios.Rows(index).Item("Diuva") = dr.GetLength(0)

                End If

                index += 1
            Next

            Return (dt_horarios)

        Catch ex As Exception
            MessageBox.Show("ERROR: " & oTrans.descripcion_error & ", " & ex.Message)

        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

    End Function

    Private Function Exportar_Excel(ByVal dt As DataTable)
        Dim mExcel As New Automatizar.exportar_excel
        Try

            mExcel.ocultar_columnas = ","
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            mExcel.Nombre_Columnas = "," ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"


            mExcel.nAgregar_Filas = 2
            mExcel.DataTableToExcel(dt)
            mExcel = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        Finally

            mExcel = Nothing

        End Try

    End Function


    Private Function generar_resumen(ByVal dt As DataTable)
        Dim scmTrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt_resumen, dt_usuarios As New DataTable
        Dim index, s_diff As Integer
        Dim nombre, sl_sql As String
        Dim newRow As DataRow
        Dim dr() As DataRow
        Dim ds As New DataSet

        Try
            scmTrans.open()
            sl_sql = "pa_sel_um_seg_usuario_horarios"
            dt_usuarios = scmTrans.Obtiene(sl_sql)

            dt_resumen.Columns.Add(New DataColumn("Division", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Horas_Extra", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Codicasa", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("DMarte", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Alamsa", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Vinoteca", GetType(String)))
            dt_resumen.Columns.Add(New DataColumn("Diuva", GetType(String)))


            dt.TableName = "pickings"
            ds.Tables.Add(dt.Copy)

            For Each row As DataRow In dt_usuarios.Rows
                newRow = dt_resumen.NewRow()
                nombre = dt_usuarios.Rows(index).Item("nombre")
                newRow("Division") = dt_usuarios.Rows(index).Item("Division")


                newRow("Nombre") = nombre

                If Not IsDBNull(ds.Tables("pickings").Compute("SUM(Codicasa)", "nombre='" & nombre & "'")) Then newRow("Codicasa") = Convert.ToInt32(ds.Tables("pickings").Compute("SUM(Codicasa)", "nombre='" & nombre & "'")) Else newRow("Codicasa") = 0
                If Not IsDBNull(ds.Tables("pickings").Compute("SUM(DMarte)", "nombre='" & nombre & "'")) Then newRow("DMarte") = Convert.ToInt32(ds.Tables("pickings").Compute("SUM(DMarte)", "nombre='" & nombre & "'")) Else newRow("Dmarte") = 0
                If Not IsDBNull(ds.Tables("pickings").Compute("SUM(Alamsa)", "nombre='" & nombre & "'")) Then newRow("Alamsa") = Convert.ToInt32(ds.Tables("pickings").Compute("SUM(Alamsa)", "nombre='" & nombre & "'")) Else newRow("Alamsa") = 0
                If Not IsDBNull(ds.Tables("pickings").Compute("SUM(Vinoteca)", "nombre='" & nombre & "'")) Then newRow("Vinoteca") = Convert.ToInt32(ds.Tables("pickings").Compute("SUM(Vinoteca)", "nombre='" & nombre & "'")) Else newRow("Vinoteca") = 0
                If Not IsDBNull(ds.Tables("pickings").Compute("SUM(Diuva)", "nombre='" & nombre & "'")) Then newRow("Diuva") = Convert.ToInt32(ds.Tables("pickings").Compute("SUM(Diuva)", "nombre='" & nombre & "'")) Else newRow("Diuva") = 0

                'dr = ds.Tables("pickings").Select("nombre='" & nombre & "' and tiempo_extra<>'00:00:00'")
                'newRow("Horas_Extra") = "00:00:00"

                'For i As Integer = 0 To dr.GetLength(0) - 1
                '    s_diff = DateDiff(DateInterval.Second, Convert.ToDateTime("00:00:00"), Convert.ToDateTime(dr(i)("tiempo_extra")))
                '    newRow("Horas_Extra") = Convert.ToDateTime(newRow("Horas_Extra")).AddSeconds(s_diff).ToString("HH:mm:ss")
                'Next

                Dim ntotalExtras As New TimeSpan
                ds.Tables("pickings").DefaultView.RowFilter = "nombre='" & nombre & "'"
                For Each drv As DataRowView In ds.Tables("pickings").DefaultView
                    ntotalExtras += TimeSpan.Parse(drv.Item("tiempo_extra"))
                Next
                newRow("Horas_Extra") = ntotalExtras.TotalHours
                ds.Tables("pickings").DefaultView.RowFilter = ""

                dt_resumen.Rows.Add(newRow)
                index += 1

            Next

            dgv_Resumen_Picking.DataSource = dt_resumen
            ClsGen.Alinear_GridView(dt_resumen, dgv_Resumen_Picking, "", "", "", "", False, True, 255, 0)

            dt_resumen.TableName = "Resumen"
            If ds_reportes.Tables.Contains("Resumen") = True Then
                ds_reportes.Tables.Remove("Resumen")
                ds_reportes.Tables.Add(dt_resumen.Copy)
            Else
                ds_reportes.Tables.Add(dt_resumen.Copy)
            End If

        Catch ex As Exception

            MessageBox.Show("ERROR: " & ex.Message)

        End Try


    End Function

    Dim ds_reportes As New DataSet

    Private Sub btn_ver_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_reporte.Click
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As New DataTable

        Dim empleados As String

        empleados = obtener_usuarios()

        dt = obtener_horarios(empleados, Convert.ToDateTime(dtp_Fec_Inicio.Text).ToString("dd/MM/yyyy"), Convert.ToDateTime(dtp_Fec_Final.Text).ToString("dd/MM/yyyy"))
        dt = calcular_tiempo_extra(dt)
        dt = contar_picking(dt)


        dt.Columns("Fecha").SetOrdinal(1)
        dt.Columns("Nombre").SetOrdinal(2)
        dt.Columns("Horario Normal_Entrada").SetOrdinal(3)
        dt.Columns("Horario Normal_Salida").SetOrdinal(4)
        dt.Columns("Horario Extra_Entrada").SetOrdinal(5)
        dt.Columns("Horario Extra_Salida").SetOrdinal(6)
        dt.Columns("Marcaje_Entrada").SetOrdinal(7)
        dt.Columns("Marcaje_Salida").SetOrdinal(8)
        dt.Columns("Tiempo_Total_Laborado").SetOrdinal(9)
        dt.Columns("Tiempo_Extra_Bruto").SetOrdinal(10)
        dt.Columns("Tiempo_Extra").SetOrdinal(11)

        dt.TableName = "Horas_Extra"
        If ds_reportes.Tables.Contains("Horas_Extra") = True Then
            ds_reportes.Tables.Remove("Horas_Extra")
            ds_reportes.Tables.Add(dt.Copy)
        Else
            ds_reportes.Tables.Add(dt.Copy)
        End If

        dgv_Horas_Extra.DataSource = dt

        ClsGen.Alinear_GridView(dt, dgv_Horas_Extra, "", "", ",CardNo,", ",fecha,", False, True, 255, 0)

        generar_resumen(dt)

    End Sub


    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If ds_reportes.Tables.Contains("Horas_Extra") Then Exportar_Excel(ds_reportes.Tables("Horas_Extra"))
        If ds_reportes.Tables.Contains("Resumen") Then Exportar_Excel(ds_reportes.Tables("Resumen"))

    End Sub
End Class
