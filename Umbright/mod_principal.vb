Imports System.Net
Imports System.IO
Imports System.Management
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Text


Module mod_principal
	Public gs_empresa, gs_usuario, gs_ubicacion, gs_nombre_usuario, gs_cuenta_usuario, gs_numero_telefonico, gs_medio_preferido_validacion, gs_nivel_riesgo, gs_passwordless As String
	Public mdfo_gs_empresa As String
	Public pb_acceso As Boolean = False
    Public gi_tipo_usuario As Short
    Public gi_cod_empresa_onbase As Short = 0
    Public giPeriodo As Integer
    Public pbPedirDobleFactor As Boolean = False

    Public gs_nombre_equipo As String '(c) 20150806 Todas las aprobaciones deben realizarse en el equipo propio

    Sub main()





        If ValidarVersion() Then '(c) 20230317
            If Obtener_Informacion_EndPoint() Then
                Dim oForm As Form
                oForm = New frm_login

                oForm.ShowDialog()

                If pb_acceso = True Then

                    If varlidarAccesos() Then



                        If tokenValido() Then
                            Asignar_Empresa_OnBase()
                            giPeriodo = System.Configuration.ConfigurationManager.AppSettings("periodo")
                            gs_usuario = gs_usuario.ToUpper

                            oForm = New frm_menu_principal

                            oForm.Text = "Menu Principal ::. " & gs_empresa & " - " & mdfo_gs_empresa & " .:::"
                            oForm.ShowDialog()
                            oForm.Dispose()
                            oForm = Nothing
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Function varlidarAccesos() As Boolean
        Dim lbAccesoValido As Boolean = True
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Try
            pbPedirDobleFactor = True

            dt = clsgen.selectQuery("corporativo", "pa_var_um_gen_log_umbright '" & gs_usuario & "','" & gs_nombre_equipo & "'")

            If dt.Rows.Count > 0 Then
                pbPedirDobleFactor = False
            Else
                MessageBox.Show("Se Registra un Acceso Desde Un Equipo Inusual, Se Enviara Token de Validación", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                clsgen.enviarMensajeTeams(gs_cuenta_usuario, "Acceso Inusual Detectado", "Estimado " & gs_nombre_usuario & "|Se ha registrado un acceso inusual desde el equipo '" & gs_nombre_equipo & "'|utilizando sus credenciales de UMBRIGHT" & "|Si usted no lo realizo este acceso, reportelo a Tecnologia INMEDIATAMENTE!!!" & "|" & clsgen.Fecha_Servidor("FlexLine").Rows(0).Item(0))

            End If




        Catch ex As Exception

        End Try


        Return lbAccesoValido

    End Function

    Public Function Es_Unico(ByVal TableName As String,
                              ByVal SourceTable As DataTable,
                              ByVal FieldName As String,
                              ByVal DatoActual As String) As Boolean


        Dim ReturnValue As Boolean = True
        Dim dt As New DataTable(TableName)
        Dim nveces As Integer = 0

        Try


            dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)


            For Each dr As DataRow In SourceTable.Select("", FieldName)
                If ColumnEqual(DatoActual, dr(FieldName)) Then
                    ReturnValue = False
                End If
                'If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
                '   LastValue = dr(FieldName)
                '    dt.Rows.Add(New Object() {LastValue})
                'End If
            Next
            'If Not ds Is Nothing Then ds.Tables.Add(dt)
            'Return dt
        Catch ex As Exception

        End Try
        Return ReturnValue
    End Function



    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle the fields in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function

    Public Function claveDebil(psClave As String) As Boolean
        Dim lbClaveDebil As Boolean = False

        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Try
            dt = clsgen.selectQuery("FlexLine", "pa_sel_um_pg_clave_debil '" & psClave & "'")
            If dt.Rows.Count > 0 Then
                lbClaveDebil = True
            Else
                If Len(psClave) < 7 Then
                    lbClaveDebil = True
                End If
            End If

        Catch ex As Exception

        Finally
            clsgen = Nothing
        End Try

        Return lbClaveDebil

    End Function

    Private Function tokenValido() As Boolean
        Dim liToken, liTokeRecibido As Integer
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lbTokenValido As Boolean
        Dim varMensajeAEnviar As String

        Try
            'pbPedirDobleFactor = True

            If pbPedirDobleFactor Then

                Dim lsabecedario As String = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,n,o,p,q,r,s,t,u,v,w,x,y,z"

                liToken = numAleatorioEntre(100000, 999999)
                dt = ClsGen.Fecha_Servidor("FlexLine")


                If pbPedirDobleFactor And gs_nivel_riesgo.ToString.ToLower.Equals("alto") Then

                    varMensajeAEnviar = "Validacion desde equipo:" & gs_nombre_equipo & ", " &
                                        "Usuario:" & gs_usuario & "," &
                    "TOKEN : " & liToken & "," & "Fecha:" & dt.Rows(0).Item("Fecha_Actual")

                    '"A Empresa : " & gs_empresa & "|" &
                    lsSQL = "pa_ins_um_pwa_enviar_sms_claro '" & gs_numero_telefonico & "','" & varMensajeAEnviar & "'"

                    ClsGen.insertQuery("RegionalDBintOut", lsSQL)
                    liTokeRecibido = InputBox("Ingrese el Token Enviado por SMS al Celular: ****-" + gs_numero_telefonico.ToString.Substring(gs_numero_telefonico.Length - 4), "Validacion")

                ElseIf pbPedirDobleFactor Then




                    Dim varMotivo As String = "Validacion de Acceso"
                    varMensajeAEnviar = "Desde Equipo: " & gs_nombre_equipo & "|" &
                    "A Empresa : " & gs_empresa & "|" &
                    "Usuario : " & gs_usuario & "|" &
                    "TOKEN : " & liToken & "|" & "Fecha :" & dt.Rows(0).Item("Fecha_Actual")

                    System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
                    Dim request As WebRequest
                    'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

                    request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
                    Dim response As WebResponse
                    Dim postData As String = "
            {
              ""Correo"": """ & gs_cuenta_usuario & """,
              ""Motivo"": """ & varMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
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

                    Dim lscorreoOculto As String

                    'lscorreoOculto = gs_cuenta_usuario.Substring(0, gs_cuenta_usuario.ToString.IndexOf("@") - 3).Replace(lsabecedario, "*") + gs_cuenta_usuario.Substring(gs_cuenta_usuario.IndexOf("@") - 3, gs_cuenta_usuario.Length())
                    lscorreoOculto = gs_cuenta_usuario.Substring(2, gs_cuenta_usuario.ToString.IndexOf("@") - 2)
                    For Each lscaracter As String In lsabecedario.Split(",")
                        lscorreoOculto = lscorreoOculto.Replace(lscaracter, "*")
                    Next


                    lscorreoOculto = gs_cuenta_usuario.Substring(0, 2) + lscorreoOculto + gs_cuenta_usuario.Substring(gs_cuenta_usuario.IndexOf("@") - 2)


                    liTokeRecibido = InputBox("Ingrese el Token Enviado a TEAMS!!! a la cuenta " + lscorreoOculto, "Validacion")
                End If

                If liToken <> liTokeRecibido Then
                    lbTokenValido = False
                Else
                    lbTokenValido = True
                    MessageBox.Show("Por Favor Cambie Su Contraseña", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim oform As New frm_cambiar_clave
                    oform.ShowDialog()
                    oform = Nothing
                End If
            Else
                lbTokenValido = True
            End If

        Catch ex As Exception
        End Try

        Return lbTokenValido

    End Function




    Function numAleatorioEntre(ByVal minimo As Integer, ByVal maximo As Integer) As Integer
        Randomize()
        Return CLng((minimo - maximo) * Rnd() + maximo)
    End Function


    Private Function ValidarVersion() As Boolean
        Dim regresar As Boolean = False

        Dim clsGen As New ClasesGenerales.General

        Dim dt As DataTable
        Dim lsVersionActual, lsVersionAPP As String

        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod  NULL,'GEN_VERSION_UM',NULL")
            lsVersionActual = dt.Rows(0).Item("descripcion")
            lsVersionAPP = Application.ProductVersion

            If lsVersionActual.Split(".")(1) <> lsVersionAPP.Split(".")(1) Then
                MessageBox.Show("   Tiene Una Versión de Umbright Antigua" & Chr(13) &
                            " Comuniquese con HelpDesk Para Continuar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf Math.Abs(Double.Parse(Replace(lsVersionAPP, ".", "")) - Double.Parse(Replace(lsVersionActual, ".", ""))) > 15 Then
                MessageBox.Show("   Tiene Una Versión de Umbright Antigua" & Chr(13) &
                           " Comuniquese con HelpDesk Para Continuar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf Math.Abs(Double.Parse(Replace(lsVersionAPP, ".", "")) - Double.Parse(Replace(lsVersionActual, ".", ""))) > 0 Then
                'MessageBox.Show("   Tiene Una Versión de Umbright Nueva" & Chr(13) &
                '           '" Comuniquese con HelpDesk Para Continuar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                regresar = True
            ElseIf dt.Rows(0).Item("descripcion") <> Application.ProductVersion Then
                MessageBox.Show("   Tiene Una Versión de Umbright Desactualizada" & Chr(13) &
                            " Algunas Funcionalidades No Se Ejecutarán Correctamente", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                regresar = True
            Else
                regresar = True
            End If
            If regresar Then
                lsVersionAPP = "8.26.1.2"
            End If

        Catch ex As Exception

        Finally
            clsGen = Nothing
        End Try




        Return regresar

    End Function

    Public Function tiene_permisos(ByVal _ps_opcion As String) As Boolean
        Dim ls_sql As String
        Dim ls_devuelve As Boolean = False

        Try
            If gi_tipo_usuario = 1 Then

                ls_devuelve = True
            Else
                Dim otabla As DataTable
                Dim otrans As New Transaccional.Conexion("FlexLine")
                ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa NULL,'" & gs_usuario & "','" & _ps_opcion & "','" & gs_empresa & "'"

                otrans.open()
                otabla = otrans.Obtiene(ls_sql)
                otrans.close()
                otrans = Nothing

                If otabla.Rows.Count > 0 Then
                    ls_devuelve = True
                End If

            End If

        Catch ex As Exception
            ls_devuelve = False
        End Try

        Return ls_devuelve

    End Function

    Public Sub guardarLogB(ByVal strLog As String, ByVal strUsuario As String, strModulo As String, strOpcion As String)
        Dim clsGen As New ClasesGenerales.General

        Try
            clsGen.insertLogBD("Corporativo", strLog, strUsuario, strModulo, strOpcion, "8.26.1.2")
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Function Obtener_Informacion_EndPoint() As Boolean
        'Dim mLocation As String
        'Dim ClsGen As New ClasesGenerales.General
        'Dim nombrecompleto As String()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        'Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        'nombrecompleto = hostInfo.HostName.Split(".")
        'Dim Direcciones As IPAddress() = hostInfo.AddressList

        gs_nombre_equipo = nombreHost
        Try
            'mLocation = System.Reflection.Assembly.GetExecutingAssembly.Location


            'ClsGen.Actualizar_Version(nombrecompleto(0),
            '            System.IO.Path.GetFileName(mLocation),
            '            System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion, "OnBase",
            '            Direcciones(0).ToString(), Obtiene_tamaño_pst())







        Catch ex As Exception
        Finally
            'ClsGen = Nothing

        End Try




        Return True

    End Function

    Public Sub Asignar_Empresa_OnBase()
        Dim ClsGen As New ClasesGenerales.General
        Try
            gi_cod_empresa_onbase = ClsGen.Codigo_Empresa_Onbase(gs_empresa)
        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try


    End Sub

    Private Function Obtiene_tamaño_pst() As Integer
        Dim tamaño As Long = 0

        Dim Ruta_Archivos As String = "c:\mailbox"
        Dim Archivos As String()
        Dim archivo As String

        Try
            Archivos = Directory.GetFiles(Ruta_Archivos, "*.pst")
            For Each archivo In Archivos
                Dim lArchivo As New FileInfo(archivo)
                If lArchivo.Length() > tamaño Then
                    tamaño = lArchivo.Length()
                End If

            Next

            tamaño = tamaño / 1024   'Convierte a Bytes
            tamaño = tamaño / 1024   'Convierte a MegaBytes

        Catch ex As Exception
        End Try

        Return tamaño
    End Function

    Public Sub Escribir_log(sLog As String)
        Dim Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Log.Info(sLog)

    End Sub




    Public Function Obtener_numero_mes(ByVal _nombremes As String) As Integer
        Dim numeromes As Integer = 0

        Select Case _nombremes.ToString.ToLower.Substring(0, 3)
            Case "ene"
                numeromes = 1
            Case "feb"
                numeromes = 2
            Case "mar"
                numeromes = 3
            Case "abr"
                numeromes = 4
            Case "may"
                numeromes = 5
            Case "jun"
                numeromes = 6
            Case "jul"
                numeromes = 7
            Case "ago"
                numeromes = 8
            Case "sep"
                numeromes = 9
            Case "oct"
                numeromes = 10
            Case "nov"
                numeromes = 11
            Case "dic"
                numeromes = 12

        End Select
        Return numeromes

    End Function
    Public Function Obtener_Nombre_Mes(ByVal _numeromes As Integer) As String
        Dim nombre_mes As String = ""

        Select Case _numeromes
            Case 1
                nombre_mes = "Enero"
            Case 2
                nombre_mes = "Febrero"
            Case 3
                nombre_mes = "Marzo"
            Case 4
                nombre_mes = "Abril"
            Case 5
                nombre_mes = "Mayo"
            Case 6
                nombre_mes = "Junio"
            Case 7
                nombre_mes = "Julio"
            Case 8
                nombre_mes = "Agosto"
            Case 9
                nombre_mes = "Septiembre"
            Case 10
                nombre_mes = "Octubre"
            Case 11
                nombre_mes = "Noviembre"
            Case 12
                nombre_mes = "Diciembre"
        End Select


        Return nombre_mes

    End Function



    Public Sub verificarStock_AGVinoteca(ByVal psEmpresa As String, ByVal psTipoDocto As String, ByVal psNumero As String, ods As DataSet, pdfecha As DateTime)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dtStock As DataTable
        Dim liPedir As Integer = 0
        Dim ods_listado As New DataSet

        Try
            crear_estructura_auxiliar(ods, ods_listado)
            ods_listado.Tables("listado").Rows.Clear()
            'dt = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "'")

            dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_vinoteca_ag '" & pdfecha.ToString("dd-MM-yyyy") & "'")



            For Each dr As DataRow In dt.Rows
                liPedir = 0
                dtStock = Oflex.Obtener_Existencias(psEmpresa, dr.Item("producto"), "CD_ANTIGUA")
                If dtStock.Rows.Count > 0 Then
                    If dtStock.Rows(0).Item("existencia") = 0 Then
                        liPedir = dr.Item("cantidad")
                    ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                        ''Pedir la diferencia
                        liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                    End If
                Else
                    'Pedir completo
                    liPedir = dr.Item("cantidad")
                End If

                '
                If liPedir > 0 Then
                    Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

                    drAux.Item("producto") = dr.Item("producto")
                    Try
                        drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")

                    Catch ex As Exception
                        Dim dtProducto As DataTable
                        dtProducto = Oflex.Obtener_Producto(psEmpresa, dr.Item("producto"))
                        If dtProducto.Rows.Count > 0 Then
                            drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
                        End If
                    End Try
                    drAux.Item("sugerido") = liPedir

                    ods_listado.Tables("listado").Rows.Add(drAux)

                End If

            Next

            If ods_listado.Tables("listado").Rows.Count > 0 Then
                Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "proveedor".Split(","))
                For Each dr As DataRow In dtProveedores.Rows

                    Dim sEmpresaCompra As String
                    Dim ctacte As String
                    If dr.Item("proveedor") = "CODICASA" Then
                        sEmpresaCompra = "CODICASA"
                        ctacte = "79512"
                    ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
                        sEmpresaCompra = "DMARTE1"
                        ctacte = "122183"
                    ElseIf dr.Item("proveedor") = "DIUVA" Then
                        sEmpresaCompra = "DIUVA"
                        ctacte = "6608388"
                    End If

                    'Preparar_Factura(1, "VINOTECA", "gbarrios", dr.Item("proveedor"), "Reposicion Pedido " & psEmpresa & " -" & psTipoDocto & " - " & psNumero & " " & Today.ToString("HH:mm"), ods, ods_listado)
                    Preparar_Factura(1, "VINOTECA", "gbarrios", dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado, "CD_ANTIGUA")


                    dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega 'VINOTECA','SOLICITUD O/COMPRA','gbarrios'")
                    'dt.TableName = "usuario_activo"
                    'ods.Tables.Add(dt.Copy)
                    Dim pcomprador As String = "GABRIELA BARRIOS"
                    If dt.Rows.Count > 0 Then
                        'sbodega = dt.Rows(0).Item("bodega")
                        pcomprador = dt.Rows(0).Item("comprador")
                        ctacte = dt.Rows(0).Item("ClienteAG")
                        'sbodega = dt.Rows(0).Item("ubicacion")
                    End If


                    Dim aa As String
                    Try
                        Guardar_Documento(ods, sEmpresaCompra, ctacte, pcomprador, aa, False)
                    Catch ex As Exception

                    End Try


                Next
            End If


        Catch ex As Exception

        End Try


    End Sub









    Public Sub verificarStockAG(pdfecha As DateTime, ods As DataSet)

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dtStock As DataTable
        Dim liPedir As Integer = 0
        Dim ods_listado As New DataSet
        Dim cOtrans As New Transaccional.Conexion("Corporativo")

        Try
            cOtrans.open()
            crear_estructura_auxiliar(ods, ods_listado)
            ods_listado.Tables("listado").Rows.Clear()
            'dt = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & psEmpresa & "','" & psTipoDocto & "','" & psNumero & "'")

            dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_antigua '" & pdfecha.ToString("dd-MM-yyyy") & "'")



            For Each dr As DataRow In dt.Rows
                liPedir = 0
                dtStock = Oflex.Obtener_Existencias(dr.Item("empresa").ToString, dr.Item("producto").ToString, "CD_ANTIGUA")
                If dtStock.Rows.Count > 0 Then
                    If dtStock.Rows(0).Item("existencia") = 0 Then
                        liPedir = dr.Item("cantidad")
                    ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                        ''Pedir la diferencia
                        liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                    End If
                Else
                    'Pedir completo
                    liPedir = dr.Item("cantidad")
                End If

                '
                If liPedir > 0 Then
                    Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

                    drAux.Item("empresa") = dr.Item("empresa")
                    drAux.Item("producto") = dr.Item("producto")
                    Try
                        drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")
                        drAux.Item("glosa") = dtStock.Rows(0).Item("glosa")

                    Catch ex As Exception
                        Dim dtProducto As DataTable
                        dtProducto = Oflex.Obtener_Producto(dr.Item("empresa").ToString, dr.Item("producto"))
                        If dtProducto.Rows.Count > 0 Then
                            drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
                        End If
                    End Try
                    drAux.Item("sugerido") = liPedir

                    ods_listado.Tables("listado").Rows.Add(drAux)

                End If

            Next

            Dim lsSQL As String

            If ods_listado.Tables("listado").Rows.Count > 0 Then
                Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "empresa".Split(","))
                Dim dtEmpresa As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "empresa".Split(","))

                For Each dr As DataRow In dtEmpresa.Rows

                    ods_listado.Tables("listado").DefaultView.RowFilter = "Empresa = '" & dr.Item("empresa").ToString & "'"
                    Dim icount As Integer = 0
                    For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView
                        If icount = 0 Then
                            lsSQL = "pa_ins_um_vn_traslado_encabezado '" & drv.Item("empresa").ToString &
                                "','CD_CENTRAL'," & "'" & drv.Item("empresa").ToString & " Traslado Automatico CD_CENTRAL-CD_ANTIGUA','" & gs_usuario & "','CD_ANTIGUA'"
                            cOtrans.Ingresa(lsSQL)
                            If cOtrans.Codigo_error = 0 Then
                                lsSQL = "SELECT @@IDENTITY AS NewID"
                                dt = cOtrans.Obtiene(lsSQL)
                            Else
                                icount = -1
                            End If
                        End If

                        If icount > -1 Then

                            lsSQL = "pa_ins_um_vn_traslado_detalle " & dt.Rows(0).Item("NewID") & ",'" & drv.Item("producto").ToString & "'," & drv.Item("sugerido")
                            cOtrans.Ingresa(lsSQL)
                        End If



                        icount = icount + 1
                    Next
                Next

                'For Each dr As DataRow In dtProveedores.Rows

                '    Dim sEmpresaCompra As String
                '    Dim ctacte As String
                '    If dr.Item("proveedor") = "CODICASA" Then
                '        sEmpresaCompra = "CODICASA"
                '        ctacte = "79512"
                '    ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
                '        sEmpresaCompra = "DMARTE1"
                '        ctacte = "122183"
                '    ElseIf dr.Item("proveedor") = "DIUVA" Then
                '        sEmpresaCompra = "DIUVA"
                '        ctacte = "6608388"
                '    End If

                '    'Preparar_Factura(1, "VINOTECA", "gbarrios", dr.Item("proveedor"), "Reposicion Pedido " & psEmpresa & " -" & psTipoDocto & " - " & psNumero & " " & Today.ToString("HH:mm"), ods, ods_listado)
                '    Preparar_Factura(1, "VINOTECA", "gbarrios", dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado)


                '    dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega 'VINOTECA','SOLICITUD O/COMPRA','gbarrios'")
                '    'dt.TableName = "usuario_activo"
                '    'ods.Tables.Add(dt.Copy)
                '    Dim pcomprador As String = "GABRIELA BARRIOS"
                '    If dt.Rows.Count > 0 Then
                '        'sbodega = dt.Rows(0).Item("bodega")
                '        pcomprador = dt.Rows(0).Item("comprador")
                '        ctacte = dt.Rows(0).Item("cliente")
                '        'sbodega = dt.Rows(0).Item("ubicacion")
                '    End If


                '    Dim aa As String
                '    Try
                '        Guardar_Documento(ods, sEmpresaCompra, ctacte, pcomprador, aa)
                '    Catch ex As Exception

                '    End Try


                'Next
            End If


        Catch ex As Exception

        Finally
            cOtrans.close()
            cOtrans = Nothing
        End Try


    End Sub






    Private Sub crear_estructura_auxiliar(ByRef ods As DataSet, ByRef ods_listado As DataSet)
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable

        Try
            Otrans.open()
            If Not ods.Tables.Contains("documento") Then

                ls_sql = "pa_var_um_documento_traslado_fecha '" & gs_empresa & "',NULL,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)

                dt.TableName = "documento"
                If ods.Tables.Contains("documento") Then
                    ods.Tables.Remove("documento")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documento").Rows.Clear()
            End If


            ''documentod
            If Not ods.Tables.Contains("documentod") Then
                ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentod"
                If ods.Tables.Contains("documentod") Then
                    ods.Tables.Remove("documentod")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentod").Rows.Clear()
            End If


            ''documentov
            If Not ods.Tables.Contains("documentov") Then
                ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentov"
                If ods.Tables.Contains("documentov") Then
                    ods.Tables.Remove("documentov")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentov").Rows.Clear()
            End If

            ''documentop
            If Not ods.Tables.Contains("documentop") Then
                ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentop"
                If ods.Tables.Contains("documentop") Then
                    ods.Tables.Remove("documentop")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentop").Rows.Clear()
            End If


            ods_Listado = New DataSet
            Dim dt2 = New DataTable("listado")
            dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
            dt2.Columns.Add(New DataColumn("producto", GetType(String)))
            dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
            dt2.Columns.Add(New DataColumn("proveedor", GetType(String)))
            dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Existencia", GetType(String)))
            dt2.Columns.Add(New DataColumn("ExistenciaCD", GetType(String)))
            dt2.Columns.Add(New DataColumn("Sugerido", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Sugerido_original", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Comprar", GetType(Boolean)))
            dt2.Columns.Add(New DataColumn("valor", GetType(Decimal)))
            dt2.Columns.Add(New DataColumn("total", GetType(Decimal)))
            dt2.Columns.Add(New DataColumn("grupo", GetType(Integer)))
            ods_Listado.Tables.Add(dt2)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub


    Public Function Preparar_Factura(ByVal igrupo As Integer, pgs_empresa As String, pgs_usuario As String, pgs_proveedor As String,
                                      pgs_comentarios As String, ByRef ods As DataSet, ByRef ods_listado As DataSet, psBodega As String) As Boolean
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr_aux As DataRow
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim dt, dtProveedor As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim iCount As Integer
        Dim ls_sql, sTipoDocto As String
        Dim dtotal As Double = 0
        Dim correlativo As Integer
        Dim snumero As String = "0000000000001"

        Dim sbodega As String = psBodega '"CD_CENTRAL"
        Dim pComprador As String
        Dim ctacte As String
        Dim sListaPrecio As String
        Dim sEmpresaCompra As String




        Try

            oTrans.open()

            ls_sql = "pa_sel_um_usuario_bodega '" & pgs_empresa & "','SOLICITUD O/COMPRA','" & pgs_usuario & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            'ods.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                sbodega = dt.Rows(0).Item("bodega")
                pComprador = dt.Rows(0).Item("comprador")
                If psBodega = "CD_PREMIUM" Then
                    ctacte = dt.Rows(0).Item("cliente").ToString
                Else
                    ctacte = dt.Rows(0).Item("clienteAG").ToString
                    sbodega = psBodega
                End If
                'sbodega = dt.Rows(0).Item("ubicacion")
            End If

                sTipoDocto = "ORDEN/COMPRA"

            ls_sql = "pa_sel_um_documento_numero'" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("numero").ToString <> "" Then
                    snumero = dt.Rows(0).Item("numero") + 1
                    If Len(snumero) < 10 Then snumero = snumero.PadLeft(10, "0")
                    'Else
                    '    numero = 1
                End If

            Catch ex As Exception
            End Try


            If pgs_proveedor = "CODICASA" Then
                sEmpresaCompra = "CODICASA"
                ctacte = "79512"
            ElseIf pgs_proveedor = "DISTRIBUIDORA MARTE" Then
                sEmpresaCompra = "DMARTE1"
                ctacte = "122183"
            ElseIf pgs_proveedor = "DIUVA" Then
                sEmpresaCompra = "DIUVA"
                ctacte = "6608388"
            End If

            'If Me.cmb_proveedor.Text <> "DIUVA" Then
            ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & pgs_empresa & "' ,'Proveedor'," & ctacte
            dtProveedor = oTrans.Obtiene(ls_sql)
            sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")



            ls_sql = "pa_sel_um_documento_correlativo '" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("correlativo").ToString <> "" Then
                    correlativo = dt.Rows(0).Item("correlativo") + 1
                Else
                    correlativo = 1
                End If

            Catch ex As Exception
            End Try


            Dim total As Double = 0



            'crear_estructura_auxiliar(ods)

            ods.Tables("documento").Rows.Clear()
            ods.Tables("documentod").Rows.Clear()

            dr_aux = ods.Tables("documento").NewRow
            dr_aux.Item("empresa") = pgs_empresa
            dr_aux.Item("TipoDocto") = sTipoDocto  '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
            dr_aux.Item("Numero") = snumero 'numero.ToString.PadLeft(13, "0")
            dr_aux.Item("Correlativo") = correlativo
            dr_aux.Item("ctacte") = ""
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
            dr_aux.Item("proveedor") = ctacte
            dr_aux.Item("Local") = sbodega 'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
            dr_aux.Item("Comprador") = pComprador
            dr_aux.Item("FechaVcto") = Today.ToString("dd/MM/yyyy")
            dr_aux.Item("ListaPrecio") = sListaPrecio
            dr_aux.Item("Moneda") = "QUETZALES"
            dr_aux.Item("Paridad") = 1
            dr_aux.Item("Total") = total
            dr_aux.Item("Neto") = total 'dr_aux.Item("Total")
            dr_aux.Item("SubTotal") = total ' dr_aux.Item("Total")
            dr_aux.Item("NetoIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("SubTotalIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("TotalIngreso") = total 'dr_aux.Item("Total")
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0 'ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = "PROVEEDOR"
            dr_aux.Item("IdCtaCte") = ctacte
            dr_aux.Item("glosa") = "" 'Me.txt_observaciones.Text
            dr_aux.Item("Comentario1") = pgs_comentarios 'sTipoDocto & " " & snumero
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N" ''Emitido S para que no puedan realizarle cambios
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now
            'dr_aux.Item("Comentario1") = "" ' Me.txt_observaciones.Text
            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = gs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")
            dr_aux.Item("Caja") = "" 'gsCaja
            dr_aux.Item("Pago") = 0 'dr_aux.Item("Total")
            dr_aux.Item("IdApertura") = 0
            dr_aux.Item("NetoBimoneda") = 0
            dr_aux.Item("SubTotalBimoneda") = 0
            dr_aux.Item("TotalBimoneda") = 0
            dr_aux.Item("ParidadBimoneda") = 1
            ods.Tables("documento").Rows.Add(dr_aux)


            'ods_listado.Tables("listado").DefaultView.RowFilter = "grupo = " & igrupo

            For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView 'ods.Tables("productos").Rows

                If drv.Item("proveedor").ToString.ToUpper.Equals(pgs_proveedor.ToUpper) Then
                    iCount += 1
                    dr_aux = ods.Tables("documentod").NewRow
                    dr_aux.Item("Empresa") = pgs_empresa
                    dr_aux.Item("TipoDocto") = sTipoDocto '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
                    dr_aux.Item("Correlativo") = correlativo
                    dr_aux.Item("Secuencia") = iCount
                    dr_aux.Item("Linea") = iCount
                    dr_aux.Item("Producto") = drv.Item("producto").ToString 'dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")
                    dr_aux.Item("Cantidad") = drv.Item("sugerido")

                    'Obtener precio del producto
                    Dim dtprecio As DataTable
                    dtprecio = Oflex.Obtener_Precio_Final(pgs_empresa, drv.Item("producto"), "", sListaPrecio)
                    Dim ldprecio As Double = 0
                    If dtprecio.Rows.Count > 0 Then
                        ldprecio = dtprecio.Rows(0).Item("valor")

                    End If

                    dr_aux.Item("Precio") = ldprecio 'dr.Item("precio") '+ drv.Item("ValorDescuento")
                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = ldprecio * dr_aux.Item("Cantidad")  ''drv.Item("Total")
                    dr_aux.Item("Impuesto") = 0 'dr.Item("Total") - (dr.Item("Total") / porcentajeIva)  'drv.Item("ValorImpuesto")
                    dr_aux.Item("Neto") = dr_aux.Item("Subtotal") 'drv.Item("Total") ' dr.Item("Total") 'dr.Item("Total") - dr_aux.Item("Impuesto")
                    dr_aux.Item("DrGlobal") = 0
                    dr_aux.Item("Total") = dr_aux.Item("Subtotal") ' drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("PrecioAjustado") = ldprecio 'drv.Item("valor") ' dr.Item("precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = "UN"
                    dr_aux.Item("CantidadIngreso") = drv.Item("sugerido")
                    dr_aux.Item("PrecioIngreso") = ldprecio 'drv.Item("valor") 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") ' dr.Item("Total")
                    dr_aux.Item("CorrelativoOrigen") = 0
                    dr_aux.Item("SecuenciaOrigen") = 0
                    dr_aux.Item("Bodega") = "" 'Me.cmbBodega.Text '"SVMF_KIOSKO" ''(c) 191011 Agregar Combo
                    dr_aux.Item("FactorInventario") = 0 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario") ''(c) 191011 Depende si es Entrada o Salida
                    dr_aux.Item("FechaEntrega") = Today.ToString("dd/MM/yyyy") ' Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("CantidadAsignada") = 0 ''dr.Item("sugerido")
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S" 'IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
                    dr_aux.Item("CUP") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
                    dr_aux.Item("PrecioBimoneda") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = dr_aux.Item("total")                ' drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ValPorcentajeDr1") = 0
                    dr_aux.Item("ValPorcentajeDr1Ingreso") = 0
                    dr_aux.Item("costo") = ldprecio ' drv.Item("valor") ' dr_aux.Item("Precio")
                    dr_aux.Item("FechaVigenciaLp") = "01/01/1900"
                    dr_aux.Item("PrecioListaP") = 0
                    dr_aux.Item("DoctoOrigenVal") = "N"
                    ods.Tables("documentod").Rows.Add(dr_aux)

                    dtotal += dr_aux.Item("total")
                End If
            Next


            ods.Tables("documento").Rows(0).Item("Total") = dtotal
            ods.Tables("documento").Rows(0).Item("Neto") = dtotal 'dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotal") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("NetoIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotalIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("TotalIngreso") = dtotal
        Catch ex As Exception
        Finally
            'ClsPOS = Nothing
            'Oflex.close()
            'Oflex = Nothing

        End Try
        Return True
    End Function



    Public Sub Guardar_Documento(pOds As DataSet, psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, ByRef psPedidosGenerados As String,
                                 psGuardarCopiaLocal As Boolean)
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr As DataRow
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        Dim porcentaje_consumido As Double = 0
        Dim facturas_disponibles As Integer = 0

        psPedidosGenerados = String.Empty

        Try
            For Each dr In pOds.Tables("documento").Rows
                HuboError = False
                pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                If pOds.Tables("documentod").DefaultView.Count > 0 Then
                    Osinc.Enviar_Documento(dr.Item("empresa"), dr, pOds.Tables("documentod").DefaultView.ToTable, pOds.Tables("documentov").DefaultView.ToTable, pOds.Tables("documentop").DefaultView.ToTable, "", True)
                End If
            Next
            If Osinc.codigo_error = 0 Then
                ''MessageBox.Show("Pedido Ingresado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''Me.txtPedidosGenerados.Text += pOds.Tables("documento").Rows(0).Item("numero") & ","
                psPedidosGenerados += pOds.Tables("documento").Rows(0).Item("numero") & ","
                For Each dr In pOds.Tables("documento").Rows
                    HuboError = False
                    pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                    If pOds.Tables("documentod").DefaultView.Count > 0 Then
                        generarPedido_Umbright(dr, pOds.Tables("documentod").DefaultView, psEmpresaCompra, psCodigoCliente, psComprador)
                    End If

                    If psEmpresaCompra = "" Then
                        mostrarOC(dr.Item("empresa").ToString, dr.Item("tipodocto").ToString, dr.Item("numero").ToString, psGuardarCopiaLocal)
                    End If
                Next
            End If
        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing
        End Try
    End Sub

    Public Sub mostrarOC(psEmpresa As String, psTipodocto As String, psNumero As String, psGuardarLocal As Boolean)




        Dim lsRutaPDF As String
        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = 1


        ''El Documento se crea en el Directorio de la fecha de generacion
        ' lsRutaPDF = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" & gs_empresa & "\" & psFechaDocto
        'Ruta Local
        lsRutaPDF = "c:\temp\" & gs_empresa

        Try
            If Not Directory.Exists(lsRutaPDF) Then
                Directory.CreateDirectory(lsRutaPDF)
            End If
        Catch ex As Exception

        End Try



        Try

            'lsRutaPDF = "c:\temp\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"
            lsRutaPDF = lsRutaPDF & "\" & psTipodocto.ToString.Replace(" ", "_").Replace("/", "_") & "_" & psNumero & ".pdf"

            clsGen.Escribir_Log("Ruta PDF " & lsRutaPDF)
            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("scm")
            Dim ppath_reporte As String = clsGen.Path_Reporte



            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Direccion Comercial\Vinoteca\Orden de Compra.rpt"

            Dim pm_parametros2(2) As String
            Dim pm_valores2(2) As String


            pm_parametros2(0) = "@PEmpresa"
            pm_parametros2(2) = "@PTipodocto"
            pm_parametros2(1) = "@PNumero"


            pm_valores2(0) = psEmpresa
            pm_valores2(2) = psTipodocto
            pm_valores2(1) = psNumero


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                False, False, "PDF", False, lsRutaPDF, True, 1, gs_empresa, ",")

            If psGuardarLocal Then
                _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                True, False, "PDF", False, lsRutaPDF, True, 1, gs_empresa, ",")



            End If


        Catch ex As Exception
            clsGen.Escribir_Log("Generar PDF " & ex.ToString)
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try



    End Sub

    Public Sub generarPedido_Umbright(ByVal drEncabezado As DataRow, ByVal dtvDetalle As DataView,
                                    psEmpresaCompra As String, psCodigoCliente As String, psComprador As String)
        Dim lsSQL As String
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double

        Try

            Otrans.open()
            cOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaCompra & "','CLIENTE','" & psCodigoCliente & "'")

            If dtCliente.Rows.Count > 0 Then

                ''Guardar 

                lsSQL = "pa_ins_um_mov_pedidos_encabezado_tekne '" &
                         psEmpresaCompra & "','" & Now.ToString("ddMMyyyyHHmmss") & "','" &
                         psCodigoCliente & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','"

                'lsSQL += "1900-01-01','" Fecha Modifico

                lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Comprador " & psComprador & "','" &
                        gs_usuario.ToString & "',0,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "',null,'',''"
                'Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'"

                'Catch ex As Exception
                'lsSQL += "','')"
                'End Try


                cOtrans.Ingresa(lsSQL)

                If cOtrans.Codigo_error = 0 Then
                    dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString

                    For Each drv As DataRowView In dtvDetalle

                        dt = oFlex.Obtener_Precio_Final(psEmpresaCompra, drv.Item("producto"), psCodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        lsSQL = "pa_ins_um_mov_pedidos_detalle " & numero_pedido & "," &
                                          drv.Item("Linea") & ",'" & drv.Item("producto") & "'," &
                                          drv.Item("cantidad") & "," & precio_unitario & "," &
                                          precio_unitario * drv.Item("cantidad")

                        cOtrans.Ingresa(lsSQL)
                        If cOtrans.Codigo_error > 0 Then
                            'lbExitoso = False
                        End If
                    Next
                End If

                lsSQL = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                cOtrans.Actualiza(lsSQL)
            End If
        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Public Sub generarPedido_UmbrightOnbase(ByVal drEncabezado As DataRow, ByVal dtvDetalle As DataView,
                                    psEmpresaCompra As String, psCodigoCliente As String, psComprador As String)
        Dim lsSQL As String
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double

        Try

            Otrans.open()
            myOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaCompra & "','CLIENTE','" & psCodigoCliente & "'")

            ''Guardar 

            lsSQL = "call pa_ins_um_mov_pedidos_encabezado_tekne ('" &
                     psEmpresaCompra & "','" & Now.ToString("ddMMyyyyHHmmss") & "','" &
                     psCodigoCliente & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                     "0,0,'" &
                    DateTime.Parse(Now.ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                    DateTime.Parse(Today.ToString).ToString("yyyy-MM-dd") & "','"

            lsSQL += "1900-01-01','"

            lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Comprador " & psComprador & "','" &
                    gs_usuario.ToString & "',0,'" &
                    dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                    Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'"

            'Catch ex As Exception
            lsSQL += "','')"
            'End Try


            myOtrans.Ingresa(lsSQL)

            If myOtrans.Codigo_error = 0 Then
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                numero_pedido = dt.Rows(0).Item("newid").ToString

                For Each drv As DataRowView In dtvDetalle

                    dt = oFlex.Obtener_Precio_Final(psEmpresaCompra, drv.Item("producto"), psCodigoCliente)
                    Try
                        precio_unitario = dt.Rows(0).Item("valor")
                    Catch ex As Exception
                        precio_unitario = 0
                    End Try

                    lsSQL = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," &
                                      drv.Item("Linea") & ",'" & drv.Item("producto") & "'," &
                                      drv.Item("cantidad") & "," & precio_unitario & "," &
                                      precio_unitario * drv.Item("cantidad") & ")"

                    myOtrans.Ingresa(lsSQL)
                    If myOtrans.Codigo_error > 0 Then
                        'lbExitoso = False
                    End If
                Next
            End If

            lsSQL = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
            myOtrans.Actualiza(lsSQL)

            lsSQL = "Call pa_upd_um_pg_procesos_isf_tiempo (7)"
            myOtrans.Actualiza(lsSQL)
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Public Class clEmpaquetar
        Dim strKey As String = "ZafiroBlue"
        'Dim objSimpleDes As New Simple3Des(strKey)
        'Dim lstPlain As New List(Of String)
        'Dim lstEncoded As New List(Of String)
        'Dim lstDecoded As New List(Of String)
        'Dim intItemLength As New List(Of Integer)
        Dim rnd As New Random
        'Dim strWords As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        'Dim strNumbers As String = "1234567890"

        Private tdDes As New TripleDESCryptoServiceProvider

        Sub New(ByVal strKey As String)

            tdDes.Key = Truncate(strKey, tdDes.KeySize \ 8)
            tdDes.IV = Truncate("", tdDes.BlockSize \ 8)

        End Sub
        Public Function Encrypt(ByVal strInput As String) As String

            Dim btInputBytes() As Byte =
               System.Text.Encoding.Unicode.GetBytes(strInput)
            Dim msInput As New IO.MemoryStream
            Dim csEncrypt As New CryptoStream(msInput,
               tdDes.CreateEncryptor(), CryptoStreamMode.Write)

            csEncrypt.Write(btInputBytes, 0, btInputBytes.Length)
            csEncrypt.FlushFinalBlock()

            Return Convert.ToBase64String(msInput.ToArray)

        End Function
        Public Function Decrypt(ByVal strOutput As String) As String

            Dim btOutputBytes() As Byte =
               Convert.FromBase64String(strOutput)
            Dim msOutput As New IO.MemoryStream
            Dim csDecrypt As New CryptoStream(msOutput,
               tdDes.CreateDecryptor(), CryptoStreamMode.Write)

            csDecrypt.Write(btOutputBytes, 0, btOutputBytes.Length)
            csDecrypt.FlushFinalBlock()

            Return System.Text.Encoding.Unicode.GetString(msOutput.ToArray)

        End Function
        Private Function Truncate(ByVal strKey As String,
              ByVal intLength As Integer) As Byte()

            Dim shaCrypto As New SHA1CryptoServiceProvider
            Dim btKeyBytes() As Byte = Encoding.Unicode.GetBytes(strKey)
            Dim btHash() As Byte = shaCrypto.ComputeHash(btKeyBytes)

            ReDim Preserve btHash(intLength - 1)
            Return btHash

        End Function
    End Class

End Module



Public Class WMI
    Private objOS As Management.ManagementObjectSearcher
    Private objCS As Management.ManagementObjectSearcher
    Private objMgmt As Management.ManagementObject
    Private m_strComputerName As String
    Private m_strManufacturer As String
    Private m_StrModel As String
    Private m_strOSName As String
    Private m_strOSVersion As String
    Private m_strSystemType As String
    Private m_strTPM As String
    Private m_strWindowsDir As String
    Public Sub New()
        objOS = New Management.ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
        objCS = New Management.ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")

        For Each objMgmt In objOS.Get
            m_strOSName = objMgmt("name").ToString()
            m_strOSVersion = objMgmt("version").ToString()
            m_strComputerName = objMgmt("csname").ToString()
            m_strWindowsDir = objMgmt("windowsdirectory").ToString()
        Next
        For Each objMgmt In objCS.Get
            m_strManufacturer = objMgmt("manufacturer").ToString()
            m_StrModel = objMgmt("model").ToString()
            m_strSystemType = objMgmt("systemtype").ToString
            m_strTPM = objMgmt("totalphysicalmemory").ToString()
        Next
    End Sub
    Public ReadOnly Property ComputerName()
        Get
            ComputerName = m_strComputerName
        End Get
    End Property
    Public ReadOnly Property Manufacturer()
        Get
            Manufacturer = m_strManufacturer
        End Get
    End Property
    Public ReadOnly Property Model()
        Get
            Model = m_StrModel
        End Get
    End Property
    Public ReadOnly Property OsName()
        Get
            OsName = m_strOSName
        End Get
    End Property
    Public ReadOnly Property OSVersion()
        Get
            OSVersion = m_strOSVersion
        End Get
    End Property
    Public ReadOnly Property SystemType()
        Get
            SystemType = m_strSystemType
        End Get
    End Property
    Public ReadOnly Property TotalPhysicalMemory()
        Get
            TotalPhysicalMemory = m_strTPM
        End Get
    End Property
    Public ReadOnly Property WindowsDirectory()
        Get
            WindowsDirectory = m_strWindowsDir
        End Get
    End Property




End Class

