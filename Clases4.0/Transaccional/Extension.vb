Imports System.Data.Common

Namespace DAO
    Public Module Extension
        <System.Runtime.CompilerServices.Extension> _
        Public Sub SetParameters(dbcommand As DbCommand, ByVal parms() As Object)
            If (Not parms Is Nothing) Then
                For i As Integer = 0 To parms.Length - 1 Step 2
                    Dim name As String = parms(i).ToString()
                    If (parms(i + 1) Is Nothing OrElse String.IsNullOrEmpty(parms(i + 1).ToString)) Then
                        parms(i + 1) = Convert.DBNull
                    End If
                    Dim dbParameter = dbcommand.CreateParameter
                    dbParameter.ParameterName = name
                    dbParameter.Value = parms(i + 1)
                    dbcommand.Parameters.Add(dbParameter)
                Next
            End If
        End Sub
    End Module
End Namespace
