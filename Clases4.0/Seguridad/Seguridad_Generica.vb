Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class Usuario
    Dim otransaccion As Object
    Dim prefijo As String
    Public lbAntigua As Boolean
    'Public _Conexion As String = ""

    ''Public Sub New(ByVal conector_bd As String)

    ''    If conector_bd = "mysql" Then
    ''        otransaccion = New Transaccional.Conexion_mysql(_Conexion)
    ''        prefijo = "call "
    ''    Else
    ''        otransaccion = New Transaccional.Conexion(_Conexion)
    ''        prefijo = ""
    ''    End If

    ''End Sub

    Public Sub New(ByVal conector_bd As String, ByVal _conexion As String)
        If conector_bd = "mysql" Then
            otransaccion = New Transaccional.Conexion_mysql(_conexion)
            prefijo = "call "
        Else
            otransaccion = New Transaccional.Conexion(_conexion)
            prefijo = ""
        End If
    End Sub

    Public Function Tiene_Acceso(ByVal usuario As String, ByVal password As String, ByVal empresa As String) As Boolean
        Dim permiso_empresa As Boolean = False
        Dim ls_password As String
        Dim ls_StrSql As String
        Dim oTabla As DataTable
        otransaccion.open()

        ls_password = encripta_password(password)

        ls_StrSql = prefijo & "pa_sel_um_sg_usuario " & _
            IIf(prefijo.Length > 0, "(", "") & _
            "'" & usuario & "','" & ls_password & "','" & empresa & "'" & _
            IIf(prefijo.Length > 0, ")", "")

        Try

            oTabla = otransaccion.Obtiene(ls_StrSql)
            otransaccion.close()
            'otransaccion = Nothing

            If oTabla.Rows.Count > 0 Then
                Try
                    If oTabla.Rows(0).Item("cambiar_clave").ToString.ToUpper = "SI" Then
                        Me.lbAntigua = True
                    End If
                Catch ex As Exception

                End Try
                Return True
            Else
                    Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function existe_usuario(ByVal usuario As String) As Boolean
        Dim ls_StrSql As String
        Dim otabla As DataTable

        otransaccion.open()
        ls_StrSql = prefijo & "pa_sel_um_sg_usuario_simple " & _
                    IIf(prefijo.Length > 0, "(", "") & _
                    "'" & usuario & "'" & _
                    IIf(prefijo.Length > 0, ")", "")

        Try
            otabla = otransaccion.Obtiene(ls_StrSql)
            otransaccion.close()
            ' otransaccion = Nothing
            If otabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try


    End Function
    Private Function encripta_password(ByVal password As String) As String

        Dim MD5 As MD5 = MD5CryptoServiceProvider.Create()

        Dim dataMd5 As Byte() = MD5.ComputeHash(Encoding.Default.GetBytes(password))
        '''dataMd5 = MD5.ComputeHash(Encoding.Default.GetBytes(pass))

        Dim sb As StringBuilder = New StringBuilder
        Dim i As Integer = 0
        For i = 0 To dataMd5.Length() - 1
            sb.AppendFormat("{0:x2}", dataMd5(i))
        Next
        Return sb.ToString
    End Function

    Public Function registra_usuario(ByVal usuario As String, ByVal password As String, ByVal nombre As String, ByVal activo As Boolean,
                                     ByVal administrador As Boolean, ByVal ubicacion As String, ByVal puesto As String,
                                     ByVal psUsuarioGrabo As String, psEmail As String, ByVal spCelular As String, spMetodoValidacion As String,
                                     spNivelRiesgo As String, spPasswordless As String) As Boolean

        Dim ls_StrSql As String
        Dim ls_password As String
        Dim li_resultado As Integer
        Dim lb_resultado As Boolean

        Dim oTransaccion As New Transaccional.Conexion("Flexline")
        oTransaccion.open()
        ls_password = encripta_password(password)
        ls_StrSql = "pa_ins_um_sg_usuario '" & usuario & "','" & ls_password & "','" & nombre & "'," & IIf(activo, "1", "0") & "," & IIf(administrador, "1", "0") &
                    ",'" & ubicacion & "','" & puesto & "','" & psUsuarioGrabo & "','" & psEmail & "','" & spCelular & "','" & spMetodoValidacion & "','" &
                    spNivelRiesgo & "','" & spPasswordless & "'"
        li_resultado = oTransaccion.Ingresa(ls_StrSql)

        If oTransaccion.Codigo_error > 0 Then
            lb_resultado = False
        Else
            lb_resultado = True
        End If

        oTransaccion.close()
        ' oTransaccion = Nothing

        Return lb_resultado
    End Function

    Public Function actualiza_usuario(ByVal usuario As String, ByVal password As String, ByVal nombre As String,
                                      ByVal estado As Boolean, ByVal sPUsuarioGrabo As String,
                                      ByVal sEmail As String) As Boolean
        Dim ls_strsql As String
        Dim ls_password As String
        Dim li_resultado As Integer
        Dim lb_resultado As Boolean

        ls_password = encripta_password(password)

        otransaccion.open()
        ls_strsql = prefijo & "pa_upd_um_sg_usuario " &
                    IIf(prefijo.Length > 0, "(", "") &
                    "'" & usuario & "','" & ls_password & "',NULL,NULL,NULL" &
                    IIf(prefijo.Length > 0, ",NULL,NULL,NULL,NULL,NULL,NULL)", ",'" & sPUsuarioGrabo & "'," & IIf(sEmail.Length > 0, "'" & sEmail & "'", "NULL"))


        li_resultado = otransaccion.Ingresa(ls_strsql)

        If otransaccion.Codigo_error > 0 Then
            lb_resultado = False
        Else
            lb_resultado = True
        End If

        otransaccion.close()

        Return lb_resultado
    End Function
    Public Function actualiza_usuario_simple(ByVal usuario As String, ByVal password As String, ByVal nombre As String, ByVal estado As Boolean,
                                             ByVal ubicacion As String, ByVal puesto As String, ByVal _empresa As String, ByVal sPUsuario_modifico As String,
                                             ByVal spEmail As String, ByVal spCelular As String, spMetodoValidacion As String, spNivelRiesgo As String, spPasswordless As String) As Boolean
        Dim ls_strsql As String
        ' Dim ls_password As String
        Dim li_resultado As Integer

        'ls_password = encripta_password(password)

        otransaccion.open()
        ls_strsql = prefijo & "pa_upd_um_sg_usuario " &
                    IIf(prefijo.Length > 0, "(", "") &
                    "'" & usuario & "', Null ,'" & nombre & "'," & IIf(estado, "1", "0") & ",'" & ubicacion & "','" & puesto & "','" & _empresa & "'" &
                    IIf(prefijo.Length > 0, ",NULL,NULL,NULL,NULL,NULL)", ",'" & sPUsuario_modifico & "','" & spEmail & "','" & spCelular & "','" & spMetodoValidacion & "','" & spNivelRiesgo & "','" & spPasswordless & "'")

        li_resultado = otransaccion.Actualiza(ls_strsql)

        If otransaccion.Codigo_error > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
End Class

