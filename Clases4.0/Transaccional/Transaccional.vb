Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Win32 'para accesar al registro
Imports MySql.Data
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlServerCe
Imports System.Text
Imports System.Management
Imports System.Net

Public Class Conexion
    Private oConexion As SqlConnection
    Private Nombre_usuario, Password As String
    Private Nombre_servidor, Nombre_BD As String
    Public Codigo_error As Integer
    Public descripcion_error As String
    Public dt_mensajes As DataTable
    Public lbescribir_log As Boolean = True
    Public gsnombreLog As String = "log_" + Now.ToString("yyyyMM")
    'Log Mensual (c) 20230724



    '(c) 20200605
    Private sNombreEquipoTransaccion As String = ""
    Private sNombrePerfilTransaccion As String = ""
    Private sNombreSistema As String = ""
    Private sVersionSistema As String = ""
    Private sNombreUsuarioSistema As String = ""
    Private sModuloSistema As String = ""
    Private sOpcionSistema As String = ""

    Public Function setSistema(psNombreSistema As String, psVersionSistema As String, psModuloSistema As String, psOpcionSistema As String)
        sNombreSistema = psNombreSistema
        sVersionSistema = psVersionSistema
        sModuloSistema = psModuloSistema
        sOpcionSistema = psOpcionSistema

    End Function

    Public ReadOnly Property GetConDetailsForReport As String
        Get
            Return String.Format("server={0};database={1};uid={2};pwd={3};", Nombre_servidor, Nombre_BD, Nombre_usuario, Password) 'String.Format("server={0};database={1};uid={2};pwd={3};", If(Nombre_BD.ToUpper = "SCM", "SCM", Nombre_servidor), Nombre_BD, Nombre_usuario, Password)
        End Get
    End Property

    Public ReadOnly Property oCon As SqlConnection
        Get
            Return oConexion
        End Get
    End Property

    Private Sub Inicializar(ByVal Servidor As String)
        '' tengo que leer el registro
        'Dim regVersion As RegistryKey '= Registry.LocalMachine
        'Dim keyValue As String
        Dim Linea1 As String = String.Empty
        Dim Linea2 As String = String.Empty




        Try
            Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString

            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & Servidor.ToLower & "_" & lubicacion)
            Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & Servidor.ToLower & "_" & lubicacion)


            If Linea1 Is Nothing Then
                Nombre_usuario = System.Configuration.ConfigurationManager.AppSettings("usr_sql_" & Servidor.ToLower)
                Password = System.Configuration.ConfigurationManager.AppSettings("pwd_sql_" & Servidor.ToLower)
                Nombre_servidor = System.Configuration.ConfigurationManager.AppSettings("servidor_sql_" & Servidor.ToLower)
                Nombre_BD = System.Configuration.ConfigurationManager.AppSettings("bd_sql_" & Servidor.ToLower)

            Else
                'Dim Data As String = Me.TextBox2.Text
                Dim Data1 As String = String.Empty
                Dim sData As New StringBuilder
                Dim svalor As String = String.Empty

                'Dim aval(1) As String

                Do While (Linea1.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    'sData = sData + Data1
                    Linea1 = Linea1.Substring(2, Linea1.Length - 2)
                Loop


                svalor = sData.ToString
                'aval = svalor.Split(",")
                Nombre_servidor = svalor.Split(",")(0)
                Nombre_BD = svalor.Split(",")(1)

                sData = New StringBuilder

                Do While (Linea2.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    'sData = sData + Data1
                    Linea2 = Linea2.Substring(2, Linea2.Length - 2)
                Loop

                svalor = sData.ToString
                'aval = svalor.Split(",")
                Nombre_usuario = svalor.Split(",")(0)
                Password = svalor.Split(",")(1)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try
    End Sub


    Public Sub New(ByVal servidor As String, ByVal pSnombreusuario As String)
        Inicializar(servidor)
        sNombreUsuarioSistema = pSnombreusuario
    End Sub


    Public Sub New(ByVal servidor As String)

        '' tengo que leer el registro
        'Dim regVersion As RegistryKey '= Registry.LocalMachine
        'Dim keyValue As String
        Dim Linea1 As String = String.Empty
        Dim Linea2 As String = String.Empty




        Try
            Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString

            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & servidor.ToLower & "_" & lubicacion)
            Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & servidor.ToLower & "_" & lubicacion)


            If Linea1 Is Nothing Then
                Nombre_usuario = System.Configuration.ConfigurationManager.AppSettings("usr_sql_" & servidor.ToLower)
                Password = System.Configuration.ConfigurationManager.AppSettings("pwd_sql_" & servidor.ToLower)
                Nombre_servidor = System.Configuration.ConfigurationManager.AppSettings("servidor_sql_" & servidor.ToLower)
                Nombre_BD = System.Configuration.ConfigurationManager.AppSettings("bd_sql_" & servidor.ToLower)

            Else
                'Dim Data As String = Me.TextBox2.Text
                Dim Data1 As String = String.Empty
                Dim sData As New StringBuilder
                Dim svalor As String = String.Empty

                'Dim aval(1) As String

                Do While (Linea1.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    'sData = sData + Data1
                    Linea1 = Linea1.Substring(2, Linea1.Length - 2)
                Loop

                svalor = sData.ToString
                'aval = svalor.Split(",")
                Nombre_servidor = svalor.Split(",")(0)
                Nombre_BD = svalor.Split(",")(1)

                sData = New StringBuilder

                Do While (Linea2.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    'sData = sData + Data1
                    Linea2 = Linea2.Substring(2, Linea2.Length - 2)
                Loop

                svalor = sData.ToString
                'aval = svalor.Split(",")
                Nombre_usuario = svalor.Split(",")(0)
                Password = svalor.Split(",")(1)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try
    End Sub


    Public Sub New(ByVal tipo_conexion As String, ByVal codigo_ubicacion As Integer)

        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow


        Try

            'Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & servidor.ToLower)
            'Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & servidor.ToLower)
            dt = ClsGen.Parametros_Conexion(codigo_ubicacion, tipo_conexion)

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    If dr.Item("tipo_parametro") = 1 Then
                        Nombre_servidor = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 2 Then
                        Nombre_BD = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 3 Then
                        Nombre_usuario = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 4 Then
                        Password = dr.Item("valor")
                    End If
                Next

            Else
                Codigo_error = 99
                descripcion_error = "Problemas No Existe Clave en el registro"
                Escribir_Log(descripcion_error & " " & tipo_conexion & " " & codigo_ubicacion.ToString)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try

    End Sub

    Public Sub abrir()
        open()
    End Sub

    Public Sub cerrar()
        close()
    End Sub


    Private Sub Inicializa_Mensajes()
        dt_mensajes.Rows.Clear()
    End Sub


    Private Shared Sub OnInfoMessage(ByVal sender As Object, ByVal args As SqlInfoMessageEventArgs)
        Dim err As SqlError
        Dim ClsGen As New ClasesGenerales.General
        Dim lsNombreLogBD As String = "c:\Aplicaciones\mensajesBD_" + Now.ToString("yyyyMM") + ".txt"
        Dim lsNombreLogBD_copia As String = "c:\Aplicaciones\mensajesBD_" + Now.ToString("yyyyMM") & "_" & Now.ToString("ddMMyyymmss") & ".txt"
        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        Try



            myStreamWriter = File.AppendText(lsNombreLogBD)
            bytes = myStreamWriter.BaseStream.Length
            myStreamWriter.Close()

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(lsNombreLogBD, lsNombreLogBD_copia, True)
                ClsGen.Eliminar_Archivo(lsNombreLogBD)
            End If

            For Each err In args.Errors
                'Console.WriteLine("The {0} has received a severity {1} state {2} error number {3}\n" & _
                '         "on line {4} of procedure {5} on server {6}:\n{7}", _
                '  err.Source, err.Class, err.State, err.Number, err.LineNumber, _
                'err.Procedure, err.Server, err.Message)
                'ClsGen.Escribir_texto("c:\Aplicaciones\mensajes.txt", err.Message & vbCrLf)
                ClsGen.Escribir_texto(lsNombreLogBD, err.Message & vbCrLf)
            Next
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try


    End Sub

    Public Sub open()
        Codigo_error = 0
        Dim ls_conexion As String

        ls_conexion = "server=" & Nombre_servidor & _
                      ";database=" & Nombre_BD & _
                      ";uid=" & Nombre_usuario & _
                      ";pwd=" & Password & ";"

        Dim conexion2 As New SqlConnection(ls_conexion)
        Try

            oConexion = conexion2
            oConexion.Open()

            AddHandler oConexion.InfoMessage, _
                    New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)

        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 1
            descripcion_error = "Problemas Con La Informacion Para Conexion"
            Escribir_Log("Open " & ex.Message)
        End Try

        conexion2 = Nothing
    End Sub

    Public Sub close()
        Try
            oConexion.Close()
            oConexion.Dispose()
            oConexion = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Public Function Obtiene(ByVal strSQL As String) As DataTable
        Codigo_error = 0
        Try
            Dim oAdaptador As New SqlDataAdapter(strSQL, oConexion)

            oAdaptador.SelectCommand.CommandTimeout = 0
            Dim odataset As New DataSet
            Dim otable As New DataTable

            oAdaptador.Fill(odataset, "tabla")

            otable = odataset.Tables("tabla")

            oAdaptador.Dispose()
            odataset.Dispose()

            Return otable 'odataset.Tables("tabla")

        Catch ex As Exception
            Codigo_error = 10
            descripcion_error = "Problemas En Obtiene " & ex.Message
            Escribir_Log("Obtiene " & strSQL & " " & ex.Message)
        End Try

    End Function

    Public Function Ingresa(ByVal strSql As String, ByVal logBD As Boolean) As Integer
        Dim li_devolver As Integer
        Try


            If logBD = True Then
                li_devolver = logDB(strSql)
            Else
                li_devolver = Ingresa(strSql)
            End If

        Catch ex As Exception

        End Try
        Return li_devolver
    End Function

    Public Function Ingresa(ByVal strSql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oinserta As New SqlCommand(strSql, oConexion)
            oinserta.CommandTimeout = 0
            li_devolver = oinserta.ExecuteNonQuery()
            oinserta = Nothing
            If lbescribir_log Then
                Escribir_Log(strSql)
            End If

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Insert " & ex.Message
            Escribir_Log("Ingresa " & strSql & " " & ex.Message)
        End Try

    End Function

    Public Function Elimina(ByVal strsql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oElimina As New SqlCommand(strsql, oConexion)
            oElimina.CommandTimeout = 0
            li_devolver = oElimina.ExecuteNonQuery()
            oElimina = Nothing
            If lbescribir_log Then
                Escribir_Log(strsql)
            End If

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas Eliminando " & ex.Message
            Escribir_Log("Elimina " & strsql & " " & ex.Message)
        End Try

    End Function

    Public Function Actualiza(ByVal strsql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try

            Dim oActualiza As New SqlCommand(strsql, oConexion)
            oActualiza.CommandTimeout = 0
            li_devolver = oActualiza.ExecuteNonQuery()

            oActualiza = Nothing

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas al Actualizar " & ex.Message
            Escribir_Log("Actualiza " & strsql & " " & ex.Message)
        End Try

    End Function

    Public Sub Escribir_Log(ByVal _linea As String)
        Dim ClsGen As New ClasesGenerales.General

        ClsGen.gsNombreInicialLog = gsnombreLog
        Dim larchivo As String = "c:\Aplicaciones\" & gsnombreLog & ".txt"
        Dim larchivo_copia As String = "c:\Aplicaciones\" & gsnombreLog & "_" & Now.ToString("ddMMyyymmss") & ".txt"

        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        myStreamWriter = File.AppendText(larchivo)
        bytes = myStreamWriter.BaseStream.Length
        myStreamWriter.Close()

        Try

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(larchivo, larchivo_copia, True)
                ClsGen.Eliminar_Archivo(larchivo)
            End If

            ClsGen.Escribir_texto(larchivo, Now.ToString & " " & _linea & vbCrLf)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Public Function logDB(ByVal strSql As String) As Integer
        Dim li_devolver As Integer


        Dim StringSQL As String = "pa_ins_um_gen_log_umbright '"

        Try
            sNombreEquipoTransaccion = System.Net.Dns.GetHostName()
            sNombrePerfilTransaccion = System.Environment.UserName

        Catch ex As Exception


        End Try


        Try
            StringSQL = StringSQL & sNombreEquipoTransaccion & "','" & sNombrePerfilTransaccion & "','" &
                sNombreUsuarioSistema & "','" & sNombreSistema & "','" & sVersionSistema & "','" & sModuloSistema & "','" &
                sOpcionSistema & "','" & strSql & "'"

            'fechahora, equipow, perfilw,usuariou,sistema,version,modulo,opcion,instruccion
            Dim oinserta As New SqlCommand(StringSQL, oConexion)
            oinserta.CommandTimeout = 0
            oinserta.ExecuteNonQuery()
            oinserta = Nothing
            'If lbescribir_log Then
            '    Escribir_Log(strSql)
            'End If

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Insert " & ex.Message
            Escribir_Log("Ingresa " & strSql & " " & ex.Message)
        End Try

    End Function

End Class

'Provee la conexion a mysql
Public Class Conexion_mysql
    Private oConexion As MySqlClient.MySqlConnection
    Private Nombre_usuario, Password As String
    Private Nombre_servidor, Nombre_BD As String
    Public Codigo_error As Integer
    Public descripcion_error As String

    Public Sub New(ByVal servidor As String)
        '' tengo que leer el registro
        'Dim regVersion As RegistryKey '= Registry.LocalMachine
        'Dim keyValue As String
        Dim Linea1 As String = String.Empty
        Dim Linea2 As String = String.Empty
        Try
            Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString
            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & servidor.ToLower & "_" & lubicacion)
            Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & servidor.ToLower & "_" & lubicacion)

            If Linea1 Is Nothing Then
                ''ya no se va a utilizar el registro
                Nombre_usuario = System.Configuration.ConfigurationManager.AppSettings("usr_mysql_" & servidor)
                Password = System.Configuration.ConfigurationManager.AppSettings("pwd_mysql_" & servidor)
                Nombre_servidor = System.Configuration.ConfigurationManager.AppSettings("servidor_mysql_" & servidor)
                Nombre_BD = System.Configuration.ConfigurationManager.AppSettings("bd_mysql_" & servidor)
            Else
                Dim Data1 As String = String.Empty
                Dim sData As New StringBuilder
                Dim svalor As String = String.Empty

                'Dim aval(1) As String

                Do While (Linea1.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    'sData = sData + Data1
                    Linea1 = Linea1.Substring(2, Linea1.Length - 2)
                Loop

                svalor = sData.ToString
                '              aval = svalor.Split(",")
                Nombre_servidor = svalor.Split(",")(0)
                Nombre_BD = svalor.Split(",")(1)

                sData = New StringBuilder

                Do While (Linea2.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    Linea2 = Linea2.Substring(2, Linea2.Length - 2)
                Loop

                svalor = sData.ToString
                'aval = svalor.Split(",")
                Nombre_usuario = svalor.Split(",")(0)
                Password = svalor.Split(",")(1)
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log(ex.Message)
        End Try
    End Sub

    Public Sub abrir()
        open()
    End Sub

    Public Sub open()
        Codigo_error = 0
        Dim ls_conexion As String


        ls_conexion = "server=" & Nombre_servidor & _
                               ";user id=" & Nombre_usuario & _
                               ";password=" & Password & _
                               ";database=" & Nombre_BD & _
                               ";port=3306"

        Dim conexion2 As New MySqlClient.MySqlConnection
        conexion2.ConnectionString = ls_conexion

        Try

            oConexion = conexion2
            oConexion.Open()

        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 1
            descripcion_error = "Problemas Con La Informacion Para Conexion " & ex.Message
        Finally
            conexion2 = Nothing
        End Try

    End Sub

    Public Sub cerrar()
        close()
    End Sub

    Public Sub close()
        oConexion.Close()
        oConexion.Dispose()
        oConexion = Nothing
    End Sub

    Public Function Obtiene(ByVal strSQL As String) As DataTable
        Codigo_error = 0
        Try

            Dim oAdaptador As New MySqlClient.MySqlDataAdapter(strSQL, oConexion)
            Dim otable As New DataTable

            oAdaptador.Fill(otable)
            oAdaptador.Dispose()
            Return otable

        Catch ex As Exception
            Codigo_error = 10
            descripcion_error = "Problemas En Obtiene " & ex.Message
            Escribir_Log(ex.Message)
        End Try
    End Function

    Public Function Ingresa(ByVal strSql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oinserta As New MySqlClient.MySqlCommand(strSql, oConexion)

            li_devolver = oinserta.ExecuteNonQuery()
            oinserta = Nothing
            Escribir_Log(strSql)

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Insert " & ex.Message
            Escribir_Log(ex.Message)
        End Try

    End Function

    Public Function Actualiza(ByVal strsql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try

            Dim oactualiza As New MySqlClient.MySqlCommand(strsql, oConexion)
            li_devolver = oactualiza.ExecuteNonQuery()
            oactualiza = Nothing

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas al Actualizar " & ex.Message
            Escribir_Log(ex.Message)

        End Try
    End Function

    Public Function Elimina(ByVal strsql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oElimina As New MySqlClient.MySqlCommand(strsql, oConexion)
            li_devolver = oElimina.ExecuteNonQuery()
            oElimina = Nothing
            Escribir_Log(strsql)
            Return li_devolver

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas Eliminando " & ex.Message
            Escribir_Log(ex.Message)

        End Try
    End Function

    Public Sub Escribir_Log(ByVal _linea As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim larchivo As String = "c:\Aplicaciones\log.txt"
        Dim larchivo_copia As String = "c:\Aplicaciones\log" & Now.ToString("ddMMyyymmss") & ".txt"

        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        myStreamWriter = File.AppendText(larchivo)
        bytes = myStreamWriter.BaseStream.Length
        myStreamWriter.Close()

        Try

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(larchivo, larchivo_copia, True)
                ClsGen.Eliminar_Archivo(larchivo)
            End If

            ClsGen.Escribir_texto(larchivo, Now.ToString & " " & _linea & vbCrLf)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub
End Class

Public Class Conexion_Access
    Public Lista_Campos As String = String.Empty
    Public Lista_Valores As String = String.Empty
    Public Nombre_Tabla As String = String.Empty
    Public Condiciones As String = String.Empty
    Public Ordenamiento As String = String.Empty
    Public Agrupamiento As String = String.Empty
    Private Nombre_usuario, Password As String
    Private Nombre_servidor, DataSource As String
    Private SystemDB As String = String.Empty
    Public Codigo_error As Integer
    Public descripcion_error As String
    Private oConexion As OleDbConnection ''Cuando se Utilizan palabras reservadas se debe enviar dentro de corchetes


    Public Sub New(ByVal servidor As String)

        Dim Linea1 As String = String.Empty
        Dim Linea2 As String = String.Empty
        Try

            Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString

            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & servidor.ToLower & "_" & lubicacion)
            Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & servidor.ToLower & "_" & lubicacion)

            'Dim Data As String = Me.TextBox2.Text
            Dim Data1 As String = String.Empty
            Dim sData As New StringBuilder
            Dim svalue As String = String.Empty
            'Dim shex As String = ""
            'Dim aval(1) As String

            Do While (Linea1.Length > 0)
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString()
                sData.Append(Data1)
                Linea1 = Linea1.Substring(2, Linea1.Length - 2)
            Loop

            svalue = sData.ToString
            'aval = sData.Split(",")
            Nombre_servidor = svalue.Split(",")(0)
            DataSource = svalue.Split(",")(1)
            sData = New StringBuilder

            Do While (Linea2.Length > 0)
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString()
                sData.Append(Data1)
                Linea2 = Linea2.Substring(2, Linea2.Length - 2)
            Loop

            svalue = sData.ToString
            Nombre_usuario = svalue.Split(",")(0)
            Password = svalue.Split(",")(1)



        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal tipo_conexion As String, ByVal codigo_ubicacion As Integer)

        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow
        Try

            'Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_" & servidor.ToLower)
            'Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_" & servidor.ToLower)
            dt = ClsGen.Parametros_Conexion(codigo_ubicacion, tipo_conexion)
            password = String.Empty
            SystemDB = String.Empty

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    If dr.Item("tipo_parametro") = 1 Then
                        Nombre_servidor = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 2 Then
                        DataSource = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 3 Then
                        Nombre_usuario = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 4 Then
                        Password = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 5 Then
                        SystemDB = dr.Item("valor")
                    End If
                Next

            Else
                Codigo_error = 99
                descripcion_error = "Problemas No Existe Clave en el registro"
                Escribir_Log(descripcion_error & " " & tipo_conexion & " " & codigo_ubicacion.ToString)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try

    End Sub

    Public Sub Open()

        Codigo_error = 0
        Dim ls_conexion As String

        Try

   

            ls_conexion = "Provider=Microsoft.Jet.OLEDB.4.0;" + _
                                   "Data Source=" & DataSource & ";" + _
                                   IIf(Password.Trim.Length > 0, "Jet OLEDB:DataBase Password=" & Password & ";", "") + _
                                    IIf(SystemDB.Trim.Length > 0, "Jet OLEDB:System database=" & SystemDB, "")



        Catch ex As Exception

        End Try

        Dim conexion2 As New OleDbConnection(ls_conexion)
        Try

            oConexion = conexion2
            oConexion.Open()

        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 1
            descripcion_error = "Problemas Con La Informacion Para Conexion"
            Escribir_Log("Open " & ex.Message)
        End Try

        conexion2 = Nothing

    End Sub

    Public Sub Close()
        oConexion.Close()
        oConexion.Dispose()
        oConexion = Nothing
    End Sub

    Public Sub Abrir()
        Open()
    End Sub

    Public Sub Cerrar()
        Close()
    End Sub

    Public Function Obtiene() As DataTable

        Codigo_error = 0
        Dim ls_sql As String = String.Empty
        Dim dt As New DataTable


        Try
            ls_sql = Armar_Query("Select")
            Dim oAdaptador As New OleDb.OleDbDataAdapter(ls_sql, oConexion)

            Dim odataset As New DataSet


            oAdaptador.Fill(odataset, "tabla")

            dt = odataset.Tables("tabla")

            oAdaptador.Dispose()
            odataset.Dispose()
            oAdaptador = Nothing


        Catch ex As Exception
            Codigo_error = 10
            descripcion_error = "Problemas En Obtiene " & ex.Message
            Escribir_Log("Obtiene " & ls_sql & " " & ex.Message)
        Finally


        End Try

        Return dt


    End Function

    Public Function Ingresa() As Boolean
        Dim li_devolver As Integer
        Codigo_error = 0
        Dim strsql As String = Armar_Query("Insert")

        Try
            Dim oinserta As New OleDbCommand(strsql, oConexion)
            oinserta.CommandTimeout = 0
            li_devolver = oinserta.ExecuteNonQuery()
            oinserta = Nothing
            Escribir_Log(strsql)



            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Insert " & ex.Message
            Escribir_Log("Ingresa " & strsql & " " & ex.Message)
        End Try

    End Function

    Public Function Eliminar()
        Dim li_devolver As Integer = -1
        'Dim dt As DataTable
        'dt = Obtener()

        Codigo_error = 0
        Dim strsql As String = Armar_Query("Delete")
        'If dt.Rows.Count > 150 Then
        '    Codigo_error = 15
        '    descripcion_error = "Problemas Eliminando No Puede Eliminar Esa Cantidad de Datos"
        '    Escribir_Log("Elimina " & descripcion_error)
        'Else
        Try
            Dim oElimina As New OleDbCommand(strsql, oConexion)
            oElimina.CommandTimeout = 0
            li_devolver = oElimina.ExecuteNonQuery()
            oElimina = Nothing
            Escribir_Log(strsql)

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas Eliminando " & ex.Message
            Escribir_Log("Elimina " & strsql & " " & ex.Message)
        End Try
        'End If
        Return li_devolver



    End Function

    Public Function Actualiza() As Boolean
        Dim li_devolver As Integer
        Codigo_error = 0
        Dim strsql As String = Armar_Query("Update")

        Try

            Dim oActualiza As New OleDbCommand(strsql, oConexion)
            oActualiza.CommandTimeout = 0
            li_devolver = oActualiza.ExecuteNonQuery()
            oActualiza = Nothing
            Escribir_Log(strsql)

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Actualizar " & ex.Message
            Escribir_Log("Actualizar " & strsql & " " & ex.Message)
        End Try

    End Function

    Private Function Armar_Query(ByVal _accion As String) As String
        Dim ls_sql As String = String.Empty

        Try

            If _accion = "Select" Then
                ls_sql = _accion & " " & _
                         IIf(Lista_Campos.Trim.Length > 0, Lista_Campos, "*") & _
                         " from " & Nombre_Tabla & _
                         IIf(Condiciones.Trim.Length > 0, " where " & Condiciones, String.Empty) & _
                         IIf(Ordenamiento.Trim.Length > 0, " Order by " & Ordenamiento, String.Empty) & _
                         IIf(Agrupamiento.Trim.Length > 0, " Group by " & Agrupamiento, String.Empty)
            ElseIf _accion = "Insert" Then
                ls_sql = _accion & " Into " & Nombre_Tabla & " ( " & _
                         Lista_Campos & ") " & _
                        " Select " & Lista_Valores
            ElseIf _accion = "Delete" Then
                ls_sql = _accion & " From " & Nombre_Tabla & _
                        IIf(Condiciones.Trim.Length > 0, " Where " & Condiciones, "")
            ElseIf _accion = "Update" Then
                ls_sql = _accion & " " & Nombre_Tabla & _
                        " Set " & Lista_Campos & _
                        IIf(Condiciones.Trim.Length > 0, " Where " & Condiciones, "")
            End If

        Catch ex As Exception
            Escribir_Log("Armar_Query " & _accion & " " & ex.Message)
        End Try

        Return ls_sql
    End Function

    Private Sub Escribir_Log(ByVal _linea As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim rutaTemp As String = Environment.GetEnvironmentVariable("TEMP")
        Dim larchivo As String = rutaTemp & "\1001.tmp"
        Dim larchivo_copia As String = rutaTemp & "\1001" & Now.ToString("ddMMyyymmss") & ".tmp"

        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        myStreamWriter = File.AppendText(larchivo)
        bytes = myStreamWriter.BaseStream.Length
        myStreamWriter.Close()

        Try

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(larchivo, larchivo_copia, True)
                ClsGen.Eliminar_Archivo(larchivo)
            End If

            ClsGen.Escribir_texto(larchivo, Now.ToString & " " & _linea & vbCrLf)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

End Class

'(c) Fuera de Servicio
'20200624


'Provee Conexion a SQL CE
Public Class Conexion_CE


    Private oConexion As SqlCeConnection ' SqlConnection
    Private Nombre_usuario, Password As String
    Private Nombre_servidor, Nombre_BD As String
    Public Codigo_error As Integer
    Public descripcion_error As String
    Public dt_mensajes As DataTable
    Public lbescribir_log As Boolean = True




    Public Sub New(ByVal servidor As String)
        '' tengo que leer el registro
        'Dim regVersion As RegistryKey '= Registry.LocalMachine
        'Dim keyValue As String
        Dim Linea1 As String = String.Empty
        Dim Linea2 As String = String.Empty
        Try

            '            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_SDF" & servidor.ToLower).ToString 'System.Configuration.ConfigurationSettings.AppSettings("linea1_" & servidor.ToLower)
            '           Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_SDF" & servidor.ToLower).ToString  'System.Configuration.ConfigurationSettings.AppSettings("linea2_" & servidor.ToLower)

            Linea1 = System.Configuration.ConfigurationManager.AppSettings("linea1_SDF_GT").ToString
            Linea2 = System.Configuration.ConfigurationManager.AppSettings("linea2_SDF_GT").ToString

            If Linea1 Is Nothing Then
                Nombre_usuario = System.Configuration.ConfigurationManager.AppSettings("usr_sql_" & servidor.ToLower)
                Password = System.Configuration.ConfigurationManager.AppSettings("pwd_sql_" & servidor.ToLower)
                Nombre_servidor = System.Configuration.ConfigurationManager.AppSettings("servidor_sql_" & servidor.ToLower)
                Nombre_BD = System.Configuration.ConfigurationManager.AppSettings("bd_sql_" & servidor.ToLower)

            Else
                'Dim Data As String = Me.TextBox2.Text
                Dim Data1 As String = String.Empty
                Dim sData As New StringBuilder
                Dim svalue As String = String.Empty
                'Dim shex As String = ""
                Dim aval(1) As String

                Do While (Linea1.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    Linea1 = Linea1.Substring(2, Linea1.Length - 2)
                Loop
                svalue = sData.ToString
                'aval = sData.Split(",")
                Nombre_servidor = svalue.Split(",")(0)
                Nombre_BD = svalue.Split(",")(0) & servidor & ".SDF"

                sData = New StringBuilder

                Do While (Linea2.Length > 0)
                    Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString()
                    sData.Append(Data1)
                    Linea2 = Linea2.Substring(2, Linea2.Length - 2)
                Loop

                svalue = sData.ToString
                Nombre_usuario = svalue.Split(",")(0)
                Password = svalue.Split(",")(1)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try
    End Sub

    Public Sub Compactar_Base_de_Datos()
        Dim ls_conexion As String




        ls_conexion = "Data Source=" & Nombre_BD &
                          ";Password=" & Password & ";"

        Dim engine As SqlCeEngine

        engine = New SqlCeEngine(ls_conexion)
        engine.Shrink()
        engine.Compact(Nothing)

        engine = Nothing


    End Sub

    Public Sub abrir()
        open()
    End Sub

    Public Sub cerrar()
        close()
    End Sub

    Public Sub open()
        Codigo_error = 0
        Dim ls_conexion As String


        '    SqlCeConnection conn;conn = new SqlCeConnection("Data Source = base.sdf;Password=passw");
        'conn.Open();
        'SqlCeCommand objCom = new SqlCeCommand();
        'objCom.Connection = conn;
        'objCom.CommandText = "SELECT * FROM clientes";
        'SqlCeDataReader read;
        'read = objCom.ExecuteReader();
        'if (read.Read()){
        '    string aux = read.GetString(1);
        ' }
        'conn.Close();

        'ls_conexion = "Provider=Microsoft.SQLSERVER.MOBILE.OLEDB.3.0;Data Source=" & Nombre_BD & _
        '            ";Password =" + Password
        'ls_conexion = "server=" & Nombre_servidor & _
        '              ";database=" & Nombre_BD & _
        '              ";uid=" & Nombre_usuario & _
        '              ";pwd=" & Password & ";"

        ls_conexion = "Data Source=" & Nombre_BD &
                      ";Password=" & Password & ";"

        Dim conexion2 As New SqlCeConnection(ls_conexion)
        Try

            oConexion = conexion2
            oConexion.Open()



        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 1
            descripcion_error = "Problemas Con La Informacion Para Conexion"
            Escribir_Log("Open " & ex.Message)
        End Try

        conexion2 = Nothing
    End Sub

    Public Sub close()
        oConexion.Close()
        oConexion.Dispose()
        oConexion = Nothing
    End Sub

    Public Function Elimina(ByVal strsql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oElimina As New SqlCeCommand(strsql, oConexion)
            li_devolver = oElimina.ExecuteNonQuery()
            oElimina = Nothing
            If lbescribir_log Then
                Escribir_Log(strsql)
            End If

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 12
            descripcion_error = "Problemas Eliminando " & ex.Message
            Escribir_Log("Elimina " & strsql & " " & ex.Message)
        End Try

    End Function

    Public Function Ingresa(ByVal strSql As String) As Integer
        Dim li_devolver As Integer
        Codigo_error = 0
        Try
            Dim oinserta As New SqlCeCommand(strSql, oConexion)
            oinserta.CommandTimeout = 0
            li_devolver = oinserta.ExecuteNonQuery()
            oinserta = Nothing
            If lbescribir_log Then
                Escribir_Log(strSql)
            End If

            Return li_devolver

        Catch ex As Exception
            Codigo_error = 11
            descripcion_error = "Problemas en Insert " & ex.Message
            Escribir_Log("Ingresa " & strSql & " " & ex.Message)
        End Try

    End Function

    Public Sub Escribir_Log(ByVal _linea As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim larchivo As String = "c:\Aplicaciones\log.txt"
        Dim larchivo_copia As String = "c:\Aplicaciones\log" & Now.ToString("ddMMyyymmss") & ".txt"

        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        myStreamWriter = File.AppendText(larchivo)
        bytes = myStreamWriter.BaseStream.Length
        myStreamWriter.Close()

        Try

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(larchivo, larchivo_copia, True)
                ClsGen.Eliminar_Archivo(larchivo)
            End If

            ClsGen.Escribir_texto(larchivo, Now.ToString & " " & _linea & vbCrLf)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

End Class


'Nada Corre Como un Zorro
Public Class Conexion_Fox
    Public Fecha_Proceso As String = String.Empty
    Public Lista_Campos As String = String.Empty
    Public Lista_Valores As String = String.Empty
    Public Nombre_Tabla As String = String.Empty
    Public Condiciones As String = String.Empty
    Public Ordenamiento As String = String.Empty
    Private Nombre_usuario, Password As String
    Private Nombre_servidor, DataSource As String
    Public Codigo_error As Integer
    Public descripcion_error As String
    Private oConexion As OleDbConnection ''Cuando se Utilizan palabras reservadas se debe enviar dentro de corchetes

    Public Sub New(ByVal tipo_conexion As String, ByVal codigo_ubicacion As Integer)

        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow
        Try

            dt = ClsGen.Parametros_Conexion(codigo_ubicacion, tipo_conexion)

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    If dr.Item("tipo_parametro") = 1 Then
                        Nombre_servidor = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 2 Then
                        DataSource = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 3 Then
                        Nombre_usuario = dr.Item("valor")
                    ElseIf dr.Item("tipo_parametro") = 4 Then
                        Password = dr.Item("valor")
                    End If
                Next

            Else
                Codigo_error = 99
                descripcion_error = "Problemas No Existe Clave en el registro"
                Escribir_Log(descripcion_error & " " & tipo_conexion & " " & codigo_ubicacion.ToString)
            End If

        Catch ex As Exception
            Codigo_error = 99
            descripcion_error = "Problemas No Existe Clave en el registro"
            Escribir_Log("new transaccional " & ex.Message)
        End Try

    End Sub

    Public Sub Open()

        Codigo_error = 0
        Dim ls_conexion As String

        '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\folder;Extended Properties=dBASE IV;User ID=Admin;Password="


        ls_conexion = "Provider=Microsoft.Jet.OLEDB.4.0;" &
                               "Data Source=" & Nombre_servidor

        If Fecha_Proceso.Length > 0 Then
            ls_conexion &= Fecha_Proceso
        End If
        ls_conexion &= ";" & "Extended Properties=dBase IV;"
        '& _
        '"Mode=Shared Deny None;" & _
        '"Mask Passware=False;" & _
        '"Cache Authentication=False;" & _
        '"Encrypt Password=False;" & _
        '          "Collating Sequence=MACHINE;"






        Dim conexion2 As New OleDbConnection(ls_conexion)
        Try

            oConexion = conexion2
            ' oConexion.Open()

        Catch ex As Exception
            'MsgBox(ex.Message)
            Codigo_error = 1
            descripcion_error = "Problemas Con La Informacion Para Conexion"
            Escribir_Log("Open " & ex.Message)
        End Try

        conexion2 = Nothing

    End Sub

    Public Sub Close()
        oConexion.Close()
        oConexion.Dispose()
        oConexion = Nothing
    End Sub

    Public Sub Abrir()
        Open()
    End Sub

    Public Sub Cerrar()
        Close()
    End Sub

    Public Function Obtiene() As DataTable

        Codigo_error = 0
        Dim ls_sql As String = String.Empty
        Dim dt As New DataTable


        Try
            ls_sql = Armar_Query("Select")
            Dim oAdaptador As New OleDb.OleDbDataAdapter(ls_sql, oConexion)

            Dim odataset As New DataSet


            oAdaptador.Fill(odataset, "tabla")

            dt = odataset.Tables("tabla")

            oAdaptador.Dispose()
            odataset.Dispose()
            oAdaptador = Nothing


        Catch ex As Exception
            Codigo_error = 10
            descripcion_error = "Problemas En Obtiene " & ex.Message
            Escribir_Log("Obtiene " & ls_sql & " " & ex.Message)
        Finally


        End Try

        Return dt


    End Function

    Public Function Actualiza() As Boolean
        Dim bProcesoExitoso As Boolean = False
        Dim ls_sql As String

        Try
            ls_sql = Armar_Query("Update")
            'Open()

            Dim oActualiza As New OleDb.OleDbCommand '(ls_sql, oConexion)

            oActualiza.CommandType = CommandType.Text
            oActualiza.CommandText = ls_sql
            ' oActualiza.Connection = oConexion

            oActualiza.CommandTimeout = 0
            Try
                'Open()
                'oConexion.Open()
                If oConexion.State = ConnectionState.Closed Then oConexion.Open()
                oActualiza.Connection = oConexion
                If oActualiza.ExecuteNonQuery() > 0 Then
                    bProcesoExitoso = True
                End If
                'oConexion.Close()
                ' Close()

            Catch ex As Exception

            End Try


            'oActualiza = Nothing
            Escribir_Log(ls_sql)


        Catch ex As Exception

        End Try

        Return bProcesoExitoso
    End Function


    Private Function Armar_Query(ByVal _accion As String) As String
        Dim ls_sql As String = String.Empty
        Dim sbsql As New StringBuilder
        Try

            If _accion = "Select" Then
                sbsql.Append("Select ")
                If Lista_Campos.Trim.Length > 0 Then sbsql.Append(Lista_Campos) Else sbsql.Append("*")
                sbsql.Append(" From ").Append(Nombre_Tabla)
                If Condiciones.Trim.Length > 0 Then sbsql.Append(" Where ").Append(Condiciones)
                If Ordenamiento.Trim.Length > 0 Then sbsql.Append(" Order By ").Append(Ordenamiento)



            ElseIf _accion = "Insert" Then
                sbsql.Append("Insert Into ").Append(Nombre_Tabla).Append(" ( ")
                sbsql.Append(Lista_Campos).Append(") Select ")
                sbsql.Append(Lista_Valores)

            ElseIf _accion = "Delete" Then
                sbsql.Append("Delete From ").Append(Nombre_Tabla)
                If Condiciones.Trim.Length > 0 Then sbsql.Append(" Where ").Append(Condiciones)

            ElseIf _accion = "Update" Then
                sbsql.Append("Update ").Append(Nombre_Tabla)
                sbsql.Append(" Set ").Append(Lista_Campos)
                sbsql.Append(" Where ").Append(Condiciones)

            End If

        Catch ex As Exception
            Escribir_Log("Armar_Query " & _accion & " " & ex.Message)
        Finally
            ls_sql = sbsql.ToString
        End Try

        Return ls_sql
    End Function

    Public Sub Escribir_Log(ByVal _linea As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim larchivo As String = "c:\Aplicaciones\log.txt"
        Dim larchivo_copia As String = "c:\Aplicaciones\log" & Now.ToString("ddMMyyymmss") & ".txt"

        Dim myStreamWriter As StreamWriter
        Dim bytes As Long

        myStreamWriter = File.AppendText(larchivo)
        bytes = myStreamWriter.BaseStream.Length
        myStreamWriter.Close()

        Try

            If bytes > (1024 * 1024) Then
                ClsGen.Copiar_Archivo(larchivo, larchivo_copia, True)
                ClsGen.Eliminar_Archivo(larchivo)
            End If

            ClsGen.Escribir_texto(larchivo, Now.ToString & " " & _linea & vbCrLf)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub
End Class

