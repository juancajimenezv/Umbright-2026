Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Net.Security

Public Class CRM_Dynamics


    Public Function getDireccionesClientes(codigo_cliente As String) As DataTable
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("direccion", GetType(String))
        dataTable.Columns.Add("nombreDireccion", GetType(String))
        dataTable.Columns.Add("TipoDireccion", GetType(String))

        Try


            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2

            Dim request As WebRequest = WebRequest.Create("https://prod-74.westus.logic.azure.com:443/workflows/d178d45789214db2ac8da08e285db369/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=NP5FYe-3VS5dhRPphaXp8HiomDqKjZ5ttDNyL4dS110")
            Dim response As WebResponse
            Dim postData As String = "
        {
          ""Valor"": """ & codigo_cliente.Replace("-", "").Replace("EXT", "").Replace("CUI", "").Replace("CF", "") & """
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
            Dim jss As New JavaScriptSerializer()
            Dim jsonResponse As List(Of Dictionary(Of String, Object)) = jss.Deserialize(Of List(Of Dictionary(Of String, Object)))(sr.ReadToEnd())



            For Each item As Dictionary(Of String, Object) In jsonResponse
                Dim newRow As DataRow = dataTable.NewRow()
                newRow("direccion") = item("new_name").ToString()
                newRow("nombreDireccion") = If(item.ContainsKey("crd24_refpdvcomercial") AndAlso Not String.IsNullOrEmpty(item("crd24_refpdvcomercial").ToString()), item("crd24_refpdvcomercial").ToString(), item("new_name").ToString())
                newRow("TipoDireccion") = item("new_tipo_direccion@OData.Community.Display.V1.FormattedValue").ToString()
                dataTable.Rows.Add(newRow)
            Next
        Catch ex As Exception

        End Try
        Return dataTable
    End Function
End Class

Public Class crearDocumento
    Private pvsEmpresa As String
    Private pvICodigoError As Integer
    Private pvsDescripcionError As String

    Public Sub New()

    End Sub


    Public Property Empresa As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Property codigoError As Integer
        Get
            Return pvICodigoError
        End Get

        Set(ByVal value As Integer)
            'pvsEmpresa = value
        End Set
    End Property


    Public Function getEstructura() As DataSet
        Dim ldsEstructura As New DataSet
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable

        Try
            Otrans.open()


            ls_sql = "pa_var_um_documento_traslado_fecha '" & pvsEmpresa & "',NULL,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)

            dt.TableName = "encabezado"
            If ldsEstructura.Tables.Contains("encabezado") Then
                ldsEstructura.Tables.Remove("encabezado")
            End If
            dt.Rows.Clear()
            ldsEstructura.Tables.Add(dt.Copy)


            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & pvsEmpresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "detalle"
            If ldsEstructura.Tables.Contains("detalle") Then
                ldsEstructura.Tables.Remove("detalle")
            End If
            dt.Rows.Clear()
            ldsEstructura.Tables.Add(dt.Copy)



            ''documentov

            ls_sql = "pa_var_um_documentov_traslado_fecha '" & pvsEmpresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "valores"
            If ldsEstructura.Tables.Contains("valores") Then
                ldsEstructura.Tables.Remove("valores")
            End If
            dt.Rows.Clear()
            ldsEstructura.Tables.Add(dt.Copy)

            ''documentop

            ls_sql = "pa_var_um_documentop_traslado_fecha '" & pvsEmpresa & "',null,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pago"
            If ldsEstructura.Tables.Contains("pago") Then
                ldsEstructura.Tables.Remove("pago")
            End If
            dt.Rows.Clear()
            ldsEstructura.Tables.Add(dt.Copy)



        Catch ex As Exception
            pvICodigoError = 99
            pvsDescripcionError = "Problemas No Existe Clave en el registro"
            Otrans.Escribir_Log("new transaccional " & ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ldsEstructura
    End Function


    Public Function checkEstructura(pods As DataSet) As Boolean
        Dim plVdalido As Boolean = True
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Dim drEncabezado As DataRow
        Dim dtTipodocumento As DataTable
        Dim lsString As String

        Try
            Otrans.open()

            If pods.Tables("encabezado").Rows.Count = 1 Then
                drEncabezado = pods.Tables("encabezado").Rows(0)
                If drEncabezado.Item("empresa").ToString.ToUpper.Equals(pvsEmpresa.ToUpper) Then

                    lsString = "pa_sel_um_tipodocumento '" & pvsEmpresa & "',null,'" & drEncabezado.Item("tipodocto").ToString.ToUpper & "'"
                    dtTipodocumento = Otrans.Obtiene(lsString)

                    lsString = "pa_sel_um_gen_tabcod null,'CONFIG.PERIODO','" & pvsEmpresa & "'"
                    dt = Otrans.Obtiene(lsString)
                    dt.DefaultView.RowFilter = "codigo  = '" & drEncabezado.Item("periodolibro") & "' and Texto = 'S'"

                    If dt.DefaultView.Count > 0 Then

                        If drEncabezado.Item("periodolibro") = drEncabezado.Item("fecha").ToString("yyyyMM") Then



                        Else
                            plVdalido = False
                            Otrans.Escribir_Log("La Fecha del Documento no coincide con el periodo" & pvsEmpresa.ToUpper)
                        End If

                        'Valida Cliente
                        'Valida Proveedor
                        'Valida condicion de Pago
                        'Factor Inventario
                        'Factor Monto
                        'Valida ListadePrecios
                        'Valida productos
                        'Valida Serie
                        'valida Lote
                        'valida bodega (Inventarios)






                    Else
                        plVdalido = False
                        Otrans.Escribir_Log("El Documento Pertenece a un Periodo Cerrado " & pvsEmpresa.ToUpper)

                    End If














                Else
                    plVdalido = False
                    Otrans.Escribir_Log("El Encabezado Contiene Una Empresa Distinta a " & pvsEmpresa.ToUpper)
                End If

            Else
                plVdalido = False
                Otrans.Escribir_Log("El Encabezado Contiene " & pods.Tables("encabezado").Rows.Count & " Lineas")
            End If






        Catch ex As Exception

        End Try




        Return plVdalido


    End Function


    'Enviar Estructura
    'Validar Estructura



End Class

Public Class leerDocumento
    Private pvsEmpresa As String
    Private pvsUser As String
    Private pvsClave As String
    Private pvsIndetificador As String

    Private pvICodigoError As Integer
    Private pvsDescripcionError As String

    Public Sub New(identificador As String)

    End Sub

    Public Property usuario As String
        Get
            Return pvsUser
        End Get

        Set(ByVal value As String)
            pvsUser = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return pvsClave
        End Get

        Set(ByVal value As String)
            pvsClave = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Function getDocumento(Tipodocumento As String, numero As String) As DataSet


        Dim ldsEstructura As New DataSet
        Dim ls_sql As String
        Dim dt As DataTable

        Dim Otrans As New Transaccional.Conexion("FlexLine")



        Try
            Otrans.open()

            'ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa NULL,'" & pvsUser & "','cr_" & Tipodocumento & "','" & pvsEmpresa & "'"
            'dt = Otrans.Obtiene(ls_sql)
            If validarAcceso() Then




                ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa NULL,'" & pvsUser & "','cr_" & Tipodocumento & "','" & pvsEmpresa & "'"
                dt = Otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then



                    ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa NULL,'" & pvsUser & "','cr_" & Tipodocumento & "','" & pvsEmpresa & "'"
                    dt = Otrans.Obtiene(ls_sql)


                    If dt.Rows.Count > 0 Then

                        ls_sql = "pa_var_um_documento_interface '" & pvsEmpresa & "','" & Tipodocumento & "','" & numero & "'"
                        dt.TableName = "encabezado"

                        If ldsEstructura.Tables.Contains("encabezado") Then
                            ldsEstructura.Tables.Remove("encabezado")
                        End If
                        dt.Rows.Clear()
                        ldsEstructura.Tables.Add(dt.Copy)


                        ''documentod
                        ls_sql = "pa_var_um_documentod_interface '" & pvsEmpresa & "','" & Tipodocumento & "','" & numero & "'"

                        dt = Otrans.Obtiene(ls_sql)
                        dt.TableName = "detalle"
                        If ldsEstructura.Tables.Contains("detalle") Then
                            ldsEstructura.Tables.Remove("detalle")
                        End If
                        dt.Rows.Clear()
                        ldsEstructura.Tables.Add(dt.Copy)



                        ''documentov

                        ls_sql = "pa_var_um_documentov_interface '" & pvsEmpresa & "','" & Tipodocumento & "','" & numero & "'"

                        dt = Otrans.Obtiene(ls_sql)
                        dt.TableName = "valores"
                        If ldsEstructura.Tables.Contains("valores") Then
                            ldsEstructura.Tables.Remove("valores")
                        End If
                        dt.Rows.Clear()
                        ldsEstructura.Tables.Add(dt.Copy)

                        ''documentop

                        ls_sql = "pa_var_um_documentop_interface '" & pvsEmpresa & "','" & Tipodocumento & "','" & numero & "'"
                        dt = Otrans.Obtiene(ls_sql)
                        dt.TableName = "pago"
                        If ldsEstructura.Tables.Contains("pago") Then
                            ldsEstructura.Tables.Remove("pago")
                        End If
                        dt.Rows.Clear()
                        ldsEstructura.Tables.Add(dt.Copy)
                    Else
                        pvICodigoError = 203
                        pvsDescripcionError = "No Tiene Acceso a Esta Opcion"
                        Otrans.Escribir_Log("203 No Tiene Acceso a Esta Opcion")
                    End If

                Else
                    pvICodigoError = 202
                    pvsDescripcionError = "Sobre Pasa el Limite de Consulta Diaria"
                    Otrans.Escribir_Log("202 Sobre Pasa el Limite de Consulta Diaria")
                End If
            Else
                pvICodigoError = 201
                pvsDescripcionError = "Identificador No Valido"
                Otrans.Escribir_Log("201 Identificador No Valido")
            End If

        Catch ex As Exception
            pvICodigoError = 99
            pvsDescripcionError = "Problemas No Existe Clave en el registro"
            Otrans.Escribir_Log("new transaccional " & ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ldsEstructura


    End Function

    Private Function validarAcceso() As Boolean
        Dim pbAcceso As Boolean = False


        Dim oSeguridad As New Seguridad.Usuario("sql", "flexline")
        Try
            pbAcceso = oSeguridad.Tiene_Acceso(pvsUser, pvsClave, pvsEmpresa)
        Catch ex As Exception
        Finally
            oSeguridad = Nothing

        End Try

        Return pbAcceso

    End Function




End Class


Public Class ActualizarDocumento

    Private pvsEmpresa As String
    Private pvsUser As String
    Private pvsClave As String
    Private pvsIndetificador As String

    Private pvICodigoError As Integer
    Private pvsDescripcionError As String


    Public Property usuario As String
        Get
            Return pvsUser
        End Get

        Set(ByVal value As String)
            pvsUser = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return pvsClave
        End Get

        Set(ByVal value As String)
            pvsClave = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Property firmaelectronica As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Sub New(identificador As String)

    End Sub

    Public Sub anularDocumento()

        Try

        Catch ex As Exception

        End Try

    End Sub


End Class


Public Class readMaster
    Private pvsEmpresa As String
    Private pvsUser As String
    Private pvsClave As String
    Private pvsIndetificador As String

    Private pvICodigoError As Integer
    Private pvsDescripcionError As String

    Public Sub New(identificador As String)

    End Sub

    Public Property usuario As String
        Get
            Return pvsUser
        End Get

        Set(ByVal value As String)
            pvsUser = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return pvsClave
        End Get

        Set(ByVal value As String)
            pvsClave = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Function getCliente(codigocliente As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & pvsEmpresa & "','CLIENTE','" & codigocliente & "'"
            dt = Otrans.Obtiene(ls_sql)
            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return dt
    End Function



    Private Function validarAcceso() As Boolean
        Dim pbAcceso As Boolean = False


        Dim oSeguridad As New Seguridad.Usuario("sql", "flexline")
        Try
            pbAcceso = oSeguridad.Tiene_Acceso(pvsUser, pvsClave, pvsEmpresa)
        Catch ex As Exception
        Finally
            oSeguridad = Nothing

        End Try

        Return pbAcceso

    End Function




End Class

Public Class crearMaster
    Private pvsEmpresa As String
    Private pvsUser As String
    Private pvsClave As String
    Private pvsIndetificador As String

    Private pvICodigoError As Integer
    Private pvsDescripcionError As String

    Public Sub New(identificador As String)

    End Sub

    Public Property usuario As String
        Get
            Return pvsUser
        End Get

        Set(ByVal value As String)
            pvsUser = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return pvsClave
        End Get

        Set(ByVal value As String)
            pvsClave = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return pvsEmpresa
        End Get

        Set(ByVal value As String)
            pvsEmpresa = value
        End Set
    End Property

    Public Function getCliente(codigocliente As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & pvsEmpresa & "','CLIENTE','" & codigocliente & "'"
            dt = Otrans.Obtiene(ls_sql)
            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return dt
    End Function

    Public Function getEstructuraProveedor() As DataSet
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim odEstructura As New DataSet
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte_estructura"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cliente"
            odEstructura.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_ctacte_direccion"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cliente_direccion"
            odEstructura.Tables.Add(dt.Copy)



            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return odEstructura
    End Function

    Public Function crearProveedor(pDSProveedor As DataSet) As Boolean


        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow
        'Dim fcrud As New FlexLine_CRUD.

        Try

            If validarProveedor(pDSProveedor) Then

                dr = pDSProveedor.Tables("ctacte").Rows(0)




                Dim lsnuevoctate = dr.Item("nitEmisor").ToString.Substring(0, dr.Item("nitEmisor").ToString.Trim.Length - 1)
                If lsnuevoctate.ToString.Length > 10 Then 'Es DPI
                    lsnuevoctate = dr.Item("nitEmisor").ToString
                End If

                lsSQL = "pa_ins_um_ctacte_tipoctacte '" &
                            dr.Item("empresa").ToString & "','PROVEEDOR','" &
                            dr.Item("ctacte").ToString & "','" &
                            dr.Item("codlegal").ToString & "','" &
                            dr.Item("razonsocial").ToString & "','" &
                            dr.Item("giro").ToString & "','" &
                            dr.Item("tipo").ToString & "','" &
                            dr.Item("grupo").ToString & "','" &
                            dr.Item("ejecutivo").ToString & "','" &
                            dr.Item("CondPago").ToString & "','" &
                            dr.Item("vigencia").ToString & "','" &
                            dr.Item("ListaPrecio").ToString & "','" &
                            dr.Item("Zona").ToString & "','" &
                            dr.Item("Direccion").ToString & "','" &
                            dr.Item("Ciudad").ToString & "','" &
                            dr.Item("Comuna").ToString & "','" &
                            dr.Item("Estado").ToString & "','" &
                            dr.Item("Pais").ToString & "','" &
                            dr.Item("telefono").ToString & "','" &
                            dr.Item("LimiteCredito").ToString & "','" &
                            dr.Item("VigenciaCredito").ToString & "','" &
                            dr.Item("RetrasoCredito").ToString & "','" &
                            dr.Item("Comentario1").ToString & "','" &
                            dr.Item("usuariomodif").ToString & "','" &
                            dr.Item("VigenciaCredito").ToString & "','" &
                            dr.Item("Moneda").ToString & "'"





                clsGen.insertQuery("Flexline", lsSQL)
            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Function

    Private Function validarProveedor(pDSProveedor As DataSet) As Boolean
        Dim lbdatosValidos As Boolean = False
        Dim clsGen As New ClasesGenerales.General

        If pDSProveedor.Tables.Count > 1 Then
            lbdatosValidos = vbFalse
        ElseIf Not pDSProveedor.Tables.Contains("direccion") Then
            lbdatosValidos = vbFalse
        ElseIf pDSProveedor.Tables("ctacte").Rows.Count <> 1 Then
            lbdatosValidos = vbFalse
            'Debe traer 1 registro
        ElseIf pDSProveedor.Tables("direccion").Rows.Count < 1 Then
            lbdatosValidos = vbFalse
            'Debe traer mas de 1 registro
        Else








        End If
        Return lbdatosValidos
    End Function




    Public Function getProveedor(codigocliente As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & pvsEmpresa & "','PROVEEDOR','" & codigocliente & "'"
            dt = Otrans.Obtiene(ls_sql)
            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return dt
    End Function


    Private Function validarAcceso() As Boolean
        Dim pbAcceso As Boolean = False


        Dim oSeguridad As New Seguridad.Usuario("sql", "flexline")
        Try
            pbAcceso = oSeguridad.Tiene_Acceso(pvsUser, pvsClave, pvsEmpresa)
        Catch ex As Exception
        Finally
            oSeguridad = Nothing

        End Try

        Return pbAcceso

    End Function




End Class