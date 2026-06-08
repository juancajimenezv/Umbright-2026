Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data.Common

Namespace DAO
    Public Class DB(Of T)

        Public Codigo_error As Integer
        Public descripcion_error As String

        Dim Otrans As Conexion
        Public Sub New(ByVal tipo As EnumDB)
            If (tipo = EnumDB.SCM) Then
                Otrans = New Transaccional.Conexion("SCM")
            Else
                If (tipo = EnumDB.FLEXLINE) Then
                    Otrans = New Transaccional.Conexion("FLEXLINE")
                End If
            End If
        End Sub

        Sub New()

        End Sub

        Public Function GetTobjFromStored(ByVal sql As String, make As Func(Of IDataReader, T), ByVal o() As Object) As T
            Dim cmd As New SqlCommand
            Dim rd As SqlDataReader
            Try
                Dim t As T = Nothing
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sql
                cmd.SetParameters(o)
                Otrans.open()
                cmd.Connection = Otrans.oCon
                rd = cmd.ExecuteReader
                While (rd.Read())
                    t = make(rd)
                End While
                Return t
            Catch ex As Exception
                Codigo_error = 10
                descripcion_error = String.Format("Problemas En GetTobFromStored {0}", ex.Message)
                Otrans.Escribir_Log(String.Format("Obtiene {0} {1}", sql, ex.Message))
            Finally
                Otrans.close()
            End Try
        End Function
        Public Function GetListFromStored(ByVal sql As String, make As Func(Of IDataReader, T), Optional ByVal o() As Object = Nothing) As List(Of T)
            Dim rd As SqlDataReader
            Dim cmd As New SqlCommand

            Try
                Dim lt As New List(Of T)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sql
                cmd.SetParameters(o)
                Otrans.open()
                cmd.Connection = Otrans.oCon
                rd = cmd.ExecuteReader
                While (rd.Read())
                    lt.Add(make(rd))
                End While
                Return lt
            Catch ex As Exception
                Codigo_error = 10
                descripcion_error = String.Format("Problemas En GetListFromStored {0}", ex.Message)
                Otrans.Escribir_Log(String.Format("Obtiene {0} {1}", sql, ex.Message))
            Finally
                Otrans.close()
            End Try
        End Function

        Public Function InsertWithIDReturn(ByVal sql As String, ByVal o() As Object) As Integer
            Dim cmd As New SqlCommand
            Dim rd As SqlDataReader
            Try
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sql
                cmd.SetParameters(o)
                Otrans.open()
                cmd.Connection = Otrans.oCon
                rd = cmd.ExecuteReader
                Dim id As Integer
                While (rd.Read())
                    id = If(rd.GetValue(0), 0)
                End While
                Return id
            Catch ex As Exception
                Codigo_error = 10
                descripcion_error = String.Format("Problemas En InsertWithIDReturn {0}", ex.Message)
                Otrans.Escribir_Log(String.Format("InsertWithIDReturn {0} {1}", sql, ex.Message))
            Finally
                Otrans.close()
            End Try
        End Function
    End Class

End Namespace
