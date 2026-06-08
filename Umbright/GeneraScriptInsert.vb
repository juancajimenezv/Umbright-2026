Imports System.Windows.Forms
Module GeneraScript
    Public Function prepara_insert_dts(tabla As String, connectionstring As String, dt2 As DataTable)
        Dim script As String = ""
        Dim script_values As String = ""
        Dim script_Insert As String
        Dim fs As New FrmScript

        fs.Show()
        fs.Refresh()
        Threading.Thread.Sleep(2000)
        fs.Refresh()
        Dim squery As String = "select c.name  name_table,a.object_id,a.name name_column,a.column_id,a.max_length size ,b.name type_name,a.is_nullable Nunable,is_identity AutoIncrementa " &
                    " from sys.columns a inner join sys.types b on a.user_type_id = b.user_type_id inner join sys.sysobjects c  on a.object_id = c.id " &
                   " where c.name = '" & tabla & "' order by column_id "
        Dim cnst As New Transaccional.Conexion(connectionstring)
        cnst.abrir()
        Dim dt As New DataTable
        dt = cnst.Obtiene(squery)
        script = "Insert into " & tabla & " ("
        fs.Show()

        For aa As Integer = 0 To dt.Rows.Count - 1
            With dt.Rows(aa)
                If aa < dt.Rows.Count - 1 Then
                    If .Item("autoincrementa") = 0 Then
                        script = script & "[" & .Item("name_column") & "],"
                    End If
                Else
                    If aa >= dt.Rows.Count - 1 Then
                        script = script & "[" & .Item("name_column") & "]) values ("
                    End If
                End If
            End With
        Next

        fs.Bar1.Maximum = dt2.Rows.Count - 1
        For registro As Integer = 0 To dt2.Rows.Count - 1
            fs.Bar1.Value = registro
            For columna As Integer = 0 To dt.Rows.Count - 1
                If columna < dt.Rows.Count - 1 Then
                    With dt.Rows(columna)
                        If .Item("type_name") = "float" Or .Item("type_name") = "decimal" Or .Item("type_name") = "bit" Then

                            If dt2.Rows(registro).Item(columna).ToString.Length = 0 Then
                                script_values = script_values & " 0, "
                            Else
                                script_values = script_values & " " & dt2.Rows(registro).Item(columna).ToString.Replace(",", "") & ", "
                            End If
                        Else
                            '(c) 20180406 Tratamiento con los nulos
                            If dt2.Rows(registro).Item(columna).ToString.ToLower = "null" Then
                                script_values = script_values & dt2.Rows(registro).Item(columna) & ", "
                            Else
                                script_values = script_values & "'" & dt2.Rows(registro).Item(columna) & "', "
                            End If

                        End If
                    End With
                Else
                    If columna >= dt.Rows.Count - 1 Then
                        With dt.Rows(columna)
                            If .Item("type_name") = "float" Or .Item("type_name") = "decimal" Or .Item("type_name") = "bit" Then
                                If dt2.Rows(registro).Item(columna).ToString.Length = 0 Then
                                    script_values = script_values & " 0) "
                                Else
                                    script_values = script_values & " " & dt2.Rows(registro).Item(columna).ToString.Replace(",", "") & ") "
                                End If
                            Else
                                script_values = script_values & "'" & dt2.Rows(registro).Item(columna) & "') "
                            End If
                        End With
                    End If
                End If
            Next
            'fs.TextBox1.Text = fs.TextBox1.Text + script + script_values + vbCrLf + " GO " + vbCrLf + ""
            fs.GridListaScript.Rows.Add()
            fs.GridListaScript.Item(0, fs.GridListaScript.Rows.Count - 1).Value = script + script_values & "  "
            script_values = Nothing
            'script_Insert = script_Insert + script + script_values + vbCrLf + " GO " + vbCrLf + ""
        Next
        fs.Bar1.Value = 0
        fs.lbltabla.Text = tabla
        fs.lblServer.Text = connectionstring
        fs.Panel1.Enabled = True


        cnst.close()
        Return script_Insert & " GO " + vbCrLf +
            ""
    End Function
End Module
