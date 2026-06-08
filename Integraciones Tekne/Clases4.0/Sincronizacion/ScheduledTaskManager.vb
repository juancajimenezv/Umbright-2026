Imports System
Imports System.IO
Imports System.Windows.Forms

Public Class ScheduledTaskManager
    Private scheduledHours() As Integer
    Private lastRunDate As Date = Date.MinValue
    Private lastRunHour As Integer = -1
    Private stateFilePath As String
    Private clsGen As New ClasesGenerales.General

    Public Property TaskAction As Action(Of DateTime)

    Public Sub New(scheduledHours() As Integer, Optional stateFileName As String = "last_run_state.txt")
        Me.scheduledHours = scheduledHours
        stateFilePath = Path.Combine(Application.StartupPath, stateFileName)
        LoadLastRunState()
    End Sub

    Private Sub LoadLastRunState()
        Try
            If File.Exists(stateFilePath) Then
                Dim s As String = File.ReadAllText(stateFilePath).Trim()
                If Not String.IsNullOrEmpty(s) Then
                    Dim parts() As String = s.Split("|"c)
                    If parts.Length >= 2 Then
                        Dim d As Date
                        If Date.TryParseExact(parts(0), "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, d) Then
                            lastRunDate = d
                        End If
                        Dim h As Integer
                        If Integer.TryParse(parts(1), h) Then
                            lastRunHour = h
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error leyendo estado de tareas programadas: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub

    Private Sub SaveLastRunState()
        Try
            Dim s As String = lastRunDate.ToString("yyyy-MM-dd") & "|" & lastRunHour.ToString()
            File.WriteAllText(stateFilePath, s)
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error guardando estado de tareas programadas: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub

    Public Sub Start(timer As Timer)
        If timer Is Nothing Then Return
        timer.Interval = 60 * 1000
        AddHandler timer.Tick, AddressOf TimerTick
        timer.Start()
    End Sub

    Public Sub TimerTick(sender As Object, e As EventArgs)
        Try
            CheckNow(DateTime.Now)
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error en ScheduledTaskManager.TimerTick: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub

    Public Sub CheckNow(nowDt As DateTime)
        If nowDt.Minute = 0 AndAlso Array.IndexOf(scheduledHours, nowDt.Hour) >= 0 Then
            If lastRunDate.Date <> nowDt.Date OrElse lastRunHour <> nowDt.Hour Then
                RunTask(nowDt)
            End If
        End If
    End Sub

    Public Sub RunTask(nowDt As DateTime)
        Try
            If TaskAction IsNot Nothing Then
                'TaskAction(nowDt)
                PerformScheduledTask(nowDt)
            Else
        Try
            clsGen.Escribir_Log("ScheduledTaskManager: No TaskAction assigned")
        Catch
        End Try
        End If
        Catch ex As Exception
        Try
            clsGen.Escribir_Log("Error ejecutando tarea programada: " & ex.Message)
        Catch
        End Try
        End Try

        lastRunDate = nowDt.Date
        lastRunHour = nowDt.Hour
        SaveLastRunState()
    End Sub


    Private Sub PerformScheduledTask(nowDt As DateTime)
        Dim clsGen As New ClasesGenerales.General

        Try
            clsGen.Escribir_Log("Compra Interempresa La Incodicional " & nowDt.ToString("HH:mm"))
            Dim umbralflex As New Umbral_Flex.comprasInterempresa
            umbralflex.verificarStockLAINCONDICIONAL()
            umbralflex = Nothing

            lastRunDate = nowDt.Date
            lastRunHour = nowDt.Hour
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error en PerformScheduledTask: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub

    Public Function GetLastRunHour() As Integer
        Return lastRunHour
    End Function

    Public Function GetLastRunDate() As Date
        Return lastRunDate
    End Function
End Class
