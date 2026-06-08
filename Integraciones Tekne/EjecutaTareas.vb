Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System
Imports System.Data
'Imports System.Threading.Tasks
Imports Microsoft.Data.SqlClient

Public Class EjecutaTareas

    ' Program.vb
    ' Requiere: dotnet add package Microsoft.Data.SqlClient


    Private Const ConnectionString As String =
        "Server=TU_SERVIDOR_SQL;Database=TU_BD;Trusted_Connection=True;TrustServerCertificate=True;"

        Private ReadOnly WorkerNode As String = Environment.MachineName

        Public Sub Main(args As String())
            ' En VB, Main no es async por defecto. Lanzamos el bucle async y esperamos.
            RunAsync().GetAwaiter().GetResult()
        End Sub

        Private Async Function RunAsync() As Task
            While True
                Try
                    Dim job = Await DequeueAsync(ConnectionString, WorkerNode)
                    If job Is Nothing Then
                        Await Task.Delay(TimeSpan.FromSeconds(3))
                        Continue While
                    End If

                    Dim exitCode As Integer = 0
                    Dim output As String = Nothing
                    Dim [error] As String = Nothing
                    Dim finishStatus As String = "SUCCEEDED"

                    Try
                        Select Case job.CommandType.ToUpperInvariant()
                            Case "SP"
                                Dim execRes = Await ExecuteStoredProcAsync(ConnectionString, job.CommandText)
                                exitCode = execRes.exitCode
                                output = execRes.output

                                ' Para habilitar TSQL con whitelist estricta:
                                'Case "TSQL"
                                '    If Not IsWhitelisted(job.CommandText) Then
                                '        Throw New InvalidOperationException("TSQL no permitido")
                                '    End If
                                '    Dim res = Await ExecuteTextAsync(ConnectionString, job.CommandText)
                                '    exitCode = res.exitCode
                                '    output = res.output

                            Case Else
                                Throw New NotSupportedException($"command_type no soportado: {job.CommandType}")
                        End Select

                    Catch ex As Exception
                        finishStatus = "FAILED"
                        exitCode = -1
                        [error] = ex.Message
                    End Try

                    Await FinishAsync(ConnectionString, job.RunId, finishStatus, exitCode, output, [error])

                Catch loopEx As Exception
                    Console.Error.WriteLine($"[WorkerError] {loopEx.Message}")
                'Await Task.Delay(TimeSpan.FromSeconds(5))
            End Try
            End While
        End Function

        ' ==== MODELO DE JOB =====
        Private Class Job
            Public Property RunId As Long
            Public Property TaskId As Integer
            Public Property CommandType As String
            Public Property CommandText As String
            Public Property TryNumber As Integer
        End Class

        ' ==== DEQUEUE =====
        Private Async Function DequeueAsync(cs As String, workerNode As String) As Task(Of Job)
            Using cn As New SqlConnection(cs)
                Await cn.OpenAsync().ConfigureAwait(False)

                Using cmd As New SqlCommand("flexline.gen_dequeue_next_run", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@worker_node", workerNode)

                    Dim pRunId As New SqlParameter("@run_id", SqlDbType.BigInt) With {.Direction = ParameterDirection.Output}
                    Dim pTaskId As New SqlParameter("@task_id", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    Dim pCmdType As New SqlParameter("@command_type", SqlDbType.VarChar, 30) With {.Direction = ParameterDirection.Output}
                    Dim pCmdText As New SqlParameter("@command_text", SqlDbType.NVarChar, -1) With {.Direction = ParameterDirection.Output}
                    Dim pTry As New SqlParameter("@try_number", SqlDbType.Int) With {.Direction = ParameterDirection.Output}

                    cmd.Parameters.Add(pRunId)
                    cmd.Parameters.Add(pTaskId)
                    cmd.Parameters.Add(pCmdType)
                    cmd.Parameters.Add(pCmdText)
                    cmd.Parameters.Add(pTry)

                    Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)

                    If pRunId.Value Is DBNull.Value Then
                        Return Nothing
                    End If

                    Return New Job With {
                    .RunId = CLng(pRunId.Value),
                    .TaskId = CInt(pTaskId.Value),
                    .CommandType = CStr(pCmdType.Value),
                    .CommandText = CStr(pCmdText.Value),
                    .TryNumber = CInt(pTry.Value)
                }
                End Using
            End Using
        End Function

        ' ==== EXECUTOR: Stored Procedure =====
        Private Async Function ExecuteStoredProcAsync(cs As String, procName As String) As Task(Of (exitCode As Integer, output As String))
            Using cn As New SqlConnection(cs)
                Await cn.OpenAsync().ConfigureAwait(False)

                Using cmd As New SqlCommand(procName, cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim sw = Diagnostics.Stopwatch.StartNew()
                    Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    sw.Stop()

                    Dim msg = $"SP '{procName}' OK en {sw.ElapsedMilliseconds} ms"
                    Return (0, msg)
                End Using
            End Using
        End Function

        ' ==== OPTIONAL: T-SQL con whitelist =====
        'Private Function IsWhitelisted(tsql As String) As Boolean
        '    ' Implementa tu validación/whitelist aquí
        '    Return False
        'End Function

        'Private Async Function ExecuteTextAsync(cs As String, text As String) As Task(Of (exitCode As Integer, output As String))
        '    Using cn As New SqlConnection(cs)
        '        Await cn.OpenAsync().ConfigureAwait(False)
        '        Using cmd As New SqlCommand(text, cn)
        '            cmd.CommandType = CommandType.Text
        '            Dim rows = Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
        '            Return (0, $"TSQL OK, filas afectadas: {rows}")
        '        End Using
        '    End Using
        'End Function

        ' ==== FINISH =====
        Private Async Function FinishAsync(cs As String, runId As Long, status As String, exitCode As Integer, output As String, [error] As String) As Task
            Using cn As New SqlConnection(cs)
                Await cn.OpenAsync().ConfigureAwait(False)

                Using cmd As New SqlCommand("flexline.gen_finish_run", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@run_id", runId)
                    cmd.Parameters.AddWithValue("@status", status)

                    Dim pExit = New SqlParameter("@exit_code", SqlDbType.Int)
                    pExit.Value = exitCode
                    cmd.Parameters.Add(pExit)

                    Dim pOut = New SqlParameter("@output_snippet", SqlDbType.NVarChar, 2000)
                    pOut.Value = If(output, CType(DBNull.Value, Object))
                    cmd.Parameters.Add(pOut)

                    Dim pErr = New SqlParameter("@error_message", SqlDbType.NVarChar, 2000)
                    pErr.Value = If([error], CType(DBNull.Value, Object))
                    cmd.Parameters.Add(pErr)

                    Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                End Using
            End Using
        End Function



End Class
