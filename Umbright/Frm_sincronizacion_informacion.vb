Imports System.IO
Imports System.Math
Public Class Frm_sincronizacion_informacion
    Dim ods As New DataSet

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Dim dt As DataTable

        Try
            myOtrans.open()
            ls_sql = "CALL pa_sel_um_pg_ubicacion ()"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "ubicaciones"
            If ods.Tables.Contains("ubicaciones") Then
                ods.Tables.Remove("ubicaciones")
            End If
            ods.Tables.Add(dt.Copy)
            dt.DefaultView.RowFilter = "traslada_informacion = true and nombre_empresa = '" & gs_empresa & "'"
            Me.cmb_ubicaciones.DataSource = dt.DefaultView
            Me.cmb_ubicaciones.DisplayMember = "descripcion"
            If gs_empresa = "VINOTECA" Then
                Me.cmb_ubicaciones.ValueMember = "codigo_alterno"
            Else
                Me.cmb_ubicaciones.ValueMember = "cod_ubicacion"
            End If


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Private Sub Crear_Estructura()
        Dim dt As New DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            dt.TableName = "Log"
            dt.Columns.Add(New DataColumn("Hora", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(String)))
            ods.Tables.Add(dt.Copy)
            Me.dgv_log.DataSource = ods.Tables("Log")

            ClsGen.Alinear_GridView(ods.Tables("Log"), Me.dgv_log, "", "", ",Hora,descripcion,estado,", "", "", ",Hora=100,descripcion=450,estado=40,", "", True, True, 0, 0)
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try




    End Sub

    Private Sub Crear_Estructura_Auxiliar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            ls_sql = "pa_var_um_documento_traslado_fecha 'VINOTECA',NULL,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)

            dt.TableName = "documento"
            If ods.Tables.Contains("documento") Then
                ods.Tables.Remove("documento")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)


            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If ods.Tables.Contains("documentod") Then
                ods.Tables.Remove("documentod")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If ods.Tables.Contains("documentov") Then
                ods.Tables.Remove("documentov")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If ods.Tables.Contains("documentop") Then
                ods.Tables.Remove("documentop")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)


            ''Clientes
            ls_sql = "pa_var_um_ctacte_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte"
            If ods.Tables.Contains("ctacte") Then
                ods.Tables.Remove("ctacte")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "pa_var_um_ctacteDirecciones_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_direcciones"
            If ods.Tables.Contains("ctacte_direcciones") Then
                ods.Tables.Remove("ctacte_direcciones")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Para Contabilidad
            ls_sql = "pa_var_um_ctacteGenTabCod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_gentabcod"
            If ods.Tables.Contains("ctacte_gentabcod") Then
                ods.Tables.Remove("ctacte_gentabcod")
            End If
            dt.Rows.Clear()
            ods.Tables.Add(dt.Copy)

            If ods.Tables("Log").Rows.Count > 0 Then
                If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ods.Tables("Log").Rows.Clear()
                End If
            End If



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Agregar_Log(ByVal _descripcion As String, ByVal _estado As String)
        Dim dr As DataRow

        Try
            dr = ods.Tables("Log").NewRow
            dr.Item("Hora") = Now.ToString
            dr.Item("descripcion") = _descripcion
            dr.Item("estado") = _estado
            ods.Tables("Log").Rows.Add(dr)

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub Cerrar_Documentos_Sucursal()
      
    End Sub

    Private Sub Generar_informacion()
        Dim Otrans As Transaccional.Conexion
        Dim ClsGen As New ClasesGenerales.General

        Dim dt As DataTable
        Dim ls_sql As String
        Dim lgenerar_error As Boolean = False

        Try

            dt = ods.Tables("ubicaciones")
            dt.DefaultView.RowFilter = "descripcion = '" & Me.cmb_ubicaciones.Text.ToString & "'"
            'abro la conexion al nuevo servidor
            Otrans = New Transaccional.Conexion("FlexLine" & dt.DefaultView(0).Item("nombre_bodega"))

            Otrans.open()

            ls_sql = "pa_var_um_documento_traslado_fecha  '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documento"
            If ods.Tables.Contains("documento") Then
                ods.Tables.Remove("documento")
            End If
            ods.Tables.Add(dt.Copy)

            Me.dgv_documentos.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)



            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If ods.Tables.Contains("documentod") Then
                ods.Tables.Remove("documentod")
            End If
            ods.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If ods.Tables.Contains("documentov") Then
                ods.Tables.Remove("documentov")
            End If
            ods.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If ods.Tables.Contains("documentop") Then
                ods.Tables.Remove("documentop")
            End If
            ods.Tables.Add(dt.Copy)

            ''Clientes
            ls_sql = "pa_var_um_ctacte_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte"
            If ods.Tables.Contains("ctacte") Then
                ods.Tables.Remove("ctacte")
            End If
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "pa_var_um_ctacteDirecciones_traslado_fecha '" & gs_empresa & "',null,'" & _
            Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_direcciones"
            If ods.Tables.Contains("ctacte_direcciones") Then
                ods.Tables.Remove("ctacte_direcciones")
            End If
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "pa_var_um_ctacteGenTabCod_traslado_fecha '" & gs_empresa & "',null,'" & _
            Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_gentabcod"
            If ods.Tables.Contains("ctacte_gentabcod") Then
                ods.Tables.Remove("ctacte_gentabcod")
            End If
            ods.Tables.Add(dt.Copy)



            'Si el traslado es de el salvador se debe agregar 
            'la informacion de contabilidad
            'If dt.DefaultView(0).Item("nombre_bodega").ToString.ToLower = "es" Then
            '    ''C
            '    ls_sql = "pa_var_um_con_enccom_traslado_fecha '" & gs_empresa & "',null,'" & _
            '                Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            '    dt = Otrans.Obtiene(ls_sql)
            '    dt.TableName = "documentod"
            '    If ods.Tables.Contains("documentod") Then
            '        ods.Tables.Remove("documentod")
            '    End If
            '    ods.Tables.Add(dt.Copy)

            'End If

            If ods.Tables("Log").Rows.Count > 0 Then
                If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ods.Tables("Log").Rows.Clear()
                End If
            End If

            Agregar_Log(ods.Tables("documento").Rows.Count.ToString & " Documentos Listos Para Procesar", "Ok")


            dt.Columns.Add(New DataColumn("Hora", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(String)))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Me.btn_procesar.Visible = True


    End Sub

    Private Sub Leer_Archivos_Mensajes()
        Dim fs_archivo As StreamReader
        Dim linea As String

        Try

            fs_archivo = System.IO.File.OpenText("c:\aplicaciones\mensajes.txt")
            Do Until fs_archivo.Peek = -1
                linea = CStr(fs_archivo.ReadLine)
                If linea.Trim.Length > 0 Then
                    Agregar_Log(linea, "Info")
                End If
            Loop
            fs_archivo.Close()

        Catch ex As Exception
        Finally
            fs_archivo = Nothing
        End Try

    End Sub

    Private Sub Generar_Informacion_Vinoteca_FontaBella()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Aotrans As New Transaccional.Conexion_Access("Access", 16)
        Dim fOtrans As Transaccional.Conexion_Fox

        Dim ClsGen As New ClasesGenerales.General

        Dim ls_sql As String
        Dim dt, dt_cliente, dt_ventas, dt_clienteAccess As DataTable
        Dim dt_gndSale, dt_gndtndr, dt_gndItem, dt_Itm, dt_gndVoid, dt_empleado As DataTable
        Dim dt_tdr As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim icount As Integer = 0
        Dim lagregar_Cliente As Boolean = False
        Dim lgenerar_error As Boolean = False







        Dim ls_listaprecios As String = "FONTABELLA_1103A"


        If Me.dtp_fecha_inicio.Value < Date.Parse("01/03/2011") Then
            '            ls_listaprecios = "PREMIUM_1103A"
            ls_listaprecios = "FONTABELLA_0910"
        End If

        Dim dtotal_encabezado As Double = 0, dtotal_detalle As Double = 0, dtotal_pago As Double = 0, dtotal_valores As Double

        Try
            Otrans.open()
            ls_sql = "pa_var_um_listaPrecio_listado '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "fec_inicio <='" & Me.dtp_fecha_inicio.Value & "' and fec_final >= '" & Me.dtp_fecha_inicio.Value & "'"

            dt = dt.DefaultView.ToTable
            dt.DefaultView.RowFilter = "lisprecio like '%fonta%'"

            If dt.DefaultView.Count = 1 Then
                ls_listaprecios = dt.DefaultView(0).Item("lisprecio")
            End If


            Crear_Estructura_Auxiliar()
            Aotrans.Open()
            If Aotrans.Codigo_error > 0 Then
                MessageBox.Show(Aotrans.descripcion_error)
                Exit Sub
            End If

            Aotrans.Nombre_Tabla = "HInvoice" '"HInvoice"
            Aotrans.Condiciones = "DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_ventas = Aotrans.Obtiene()

            Aotrans.Lista_Campos = "Cliente.*"
            Aotrans.Nombre_Tabla = "CLIENTE, HINVOICE "
            Aotrans.Condiciones = "CLIENTE.CliNit = HINVOICE.CliNit and HINVOICE.DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_clienteAccess = Aotrans.Obtiene


            fOtrans = New Transaccional.Conexion_Fox("Fox", 16)
            fOtrans.Fecha_Proceso = "NewData"
            fOtrans.Open()
            fOtrans.Nombre_Tabla = "Itm"
            dt_Itm = fOtrans.Obtiene()

            fOtrans.Nombre_Tabla = "emp"
            dt_empleado = fOtrans.Obtiene

            fOtrans = New Transaccional.Conexion_Fox("Fox", 16)
            fOtrans.Fecha_Proceso = Me.dtp_fecha_inicio.Value.ToString("yyyyMMdd")
            fOtrans.Open()
            fOtrans.Nombre_Tabla = "Gndtndr"
            dt_gndtndr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndSale"
            dt_gndSale = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndItem"
            dt_gndItem = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Tdr"
            dt_tdr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Gndvoid"
            dt_gndVoid = fOtrans.Obtiene



            For Each dr In dt_ventas.Rows
                dr_aux = ods.Tables("documento").NewRow
                'If dr.Item("counter") = 12176 Then
                '    dr.Item("counter") = 12176
                'End If

                dr_aux.Item("empresa") = gs_empresa
                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                dr_aux.Item("Numero") = dr.Item("Counter").ToString.PadLeft(10, "0")
                dr_aux.Item("Correlativo") = dr.Item("Counter")
                dr_aux.Item("Fecha") = dr.Item("DOB")

                If dr.Item("CliNit").ToString = "-" Or dr.Item("CliNit").ToString = "_" Then
                    dr_aux.Item("Cliente") = "0000000001" 'dr.Item("")"
                Else
                    ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,NULL,'" & dr.Item("CliNit") & "'"
                    dt_cliente = Otrans.Obtiene(ls_sql)
                    If dt_cliente.Rows.Count > 0 Then
                        dr_aux.Item("Cliente") = dt_cliente.Rows(0).Item("CtaCte")
                    Else
                        ''Debo Crear El Cliente
                        dr_aux.Item("Cliente") = dr.Item("CliNit").ToString.Split("-")(0)
                        lagregar_Cliente = True
                    End If
                End If


                dr_aux.Item("Bodega") = "SVFB"
                dr_aux.Item("Vendedor") = "RESTAURANTE FB"

                dr_aux.Item("ListaPrecio") = ls_listaprecios
                dr_aux.Item("Moneda") = "QUETZALES"
                dr_aux.Item("Paridad") = 1

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                dr_aux.Item("Neto") = 0
                For Each drv4 As DataRowView In dt_gndSale.DefaultView
                    dr_aux.Item("Neto") = dr_aux.Item("Neto") + drv4.Item("Amount")
                Next
                'dr_aux.Item("Neto") = dt_gndSale.DefaultView(0).Item("Amount")

                dr_aux.Item("SubTotal") = dr.Item("Total")
                dr_aux.Item("Total") = dr.Item("Total")
                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalIngreso") = dr.Item("Total")
                dr_aux.Item("TotalIngreso") = dr.Item("Total")
                dr_aux.Item("Aprobacion") = "S"
                dr_aux.Item("PeriodoLibro") = Date.Parse(dr.Item("DOB").ToString).ToString("yyyyMM")
                dr_aux.Item("FactorMonto") = 1
                dr_aux.Item("FactorMontoProyectado") = 0
                dr_aux.Item("TipoCtaCte") = "CLIENTE"
                dr_aux.Item("glosa") = "Check " & dr.Item("CheckNumber").ToString
                dr_aux.Item("IdCtaCte") = dr_aux.Item("Cliente")
                dr_aux.Item("Vigencia") = IIf(dr.Item("Activo"), "S", "A")
                dr_aux.Item("Emitido") = "N"
                dr_aux.Item("PorcentajeAsignado") = 0
                dr_aux.Item("Adjuntos") = "N"
                Try
                    dr_aux.Item("FechaModif") = dr.Item("DOB") & " " & _
                                                               dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                               dt_gndSale.DefaultView(0).Item("Closemin")

                    dr_aux.Item("FechaUModif") = dr_aux.Item("FechaModif")
                Catch ex As Exception

                End Try


                dt_empleado.DefaultView.RowFilter = "id = " & dt_gndItem.DefaultView(0).Item("employee")
                If dt_empleado.DefaultView.Count > 0 Then
                    If dt_empleado.DefaultView(0)("Address1").ToString.Length > 0 Then

                        dr_aux.Item("UsuarioModif") = dt_empleado.DefaultView(0)("Address1").ToString.ToUpper ''En Address debe estar el Usuario Flex para que no todo venga con Admin
                    Else
                        dr_aux.Item("UsuarioModif") = "Admin"
                    End If
                Else
                    dr_aux.Item("UsuarioModif") = "Admin"
                End If

                Try
                    dr_aux.Item("Hora") = dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                dt_gndSale.DefaultView(0).Item("Closemin")
                Catch ex As Exception
                    dr_aux.Item("Hora") = ""
                End Try


                dr_aux.Item("Caja") = ""
                dr_aux.Item("Pago") = dr.Item("Total")
                dr_aux.Item("IdApertura") = 0

                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalBimoneda") = dr.Item("Total")
                dr_aux.Item("TotalBimoneda") = dr.Item("Total")
                dr_aux.Item("ParidadBimoneda") = 1


                ods.Tables("documento").Rows.Add(dr_aux)


                ''Detalle
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                icount = 0
                For Each drv In dt_gndItem.DefaultView

                    dt_Itm.DefaultView.RowFilter = "Id = " & drv.Item("Item")
                    If dt_Itm.DefaultView.Count > 0 Then



                        If Not dt_Itm.DefaultView(0).Item("Bohname").ToString.StartsWith("-----") Then


                            dt_gndVoid.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and Item = " & drv.Item("Item")
                            If drv.Item("Price") > 0 Then
                                'If dt_gndVoid.DefaultView.Count = 0 Then

                                icount += 1
                                dr_aux = ods.Tables("documentod").NewRow

                                dr_aux.Item("Empresa") = gs_empresa
                                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                                dr_aux.Item("Correlativo") = dr.Item("Counter")
                                dr_aux.Item("Secuencia") = icount
                                dr_aux.Item("Linea") = icount
                                dr_aux.Item("Producto") = dt_Itm.DefaultView(0).Item("Bohname")

                                dr_aux.Item("Cantidad") = drv.Item("Quantity")
                                dr_aux.Item("Precio") = drv.Item("Price")
                                dr_aux.Item("PorcentajeDr") = 0
                                dr_aux.Item("SubTotal") = dr_aux.Item("Cantidad") * dr_aux.Item("Precio")
                                dr_aux.Item("Impuesto") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                                dr_aux.Item("Neto") = dr_aux.Item("SubTotal") - dr_aux.Item("Impuesto")
                                dr_aux.Item("DrGlobal") = 0

                                dr_aux.Item("Total") = dr_aux.Item("Neto")
                                dr_aux.Item("PrecioAjustado") = drv.Item("Price") - drv.Item("Incltax")
                                dr_aux.Item("UnidadIngreso") = "UN"
                                dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                                dr_aux.Item("PrecioIngreso") = drv.Item("Price")
                                dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                                dr_aux.Item("ImpuestoIngreso") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                                dr_aux.Item("DRGlobalIngreso") = 0
                                dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                                dr_aux.Item("CorrelativoOrigen") = 0
                                dr_aux.Item("SecuenciaOrigen") = 0
                                dr_aux.Item("Bodega") = "SVFB"
                                dr_aux.Item("FactorInventario") = -1
                                dr_aux.Item("FechaEntrega") = dr.Item("DOB")
                                dr_aux.Item("CantidadAsignada") = 0
                                dr_aux.Item("Fecha") = dr.Item("DOB")
                                dr_aux.Item("Vigente") = "S"
                                dr_aux.Item("CUP") = 0
                                dr_aux.Item("Ubicacion") = "PRINCIPAL"
                                dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                                dr_aux.Item("FactorImpto") = 0.89285714
                                dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                                dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                                dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                                dr_aux.Item("DrGlobalBimoneda") = 0
                                dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")
                                dr_aux.Item("DoctoOrigenVal") = "N"


                                ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"
                                dt = Otrans.Obtiene(ls_sql)

                                Try
                                    dr_aux.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                                Catch ex As Exception
                                    dr_aux.Item("costo") = 0
                                End Try


                                ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                                        "','" & ls_listaprecios & "'"

                                dt = Otrans.Obtiene(ls_sql)
                                Try
                                    dr_aux.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                                    dr_aux.Item("PrecioListaP") = dt.Rows(0).Item("valor")
                                Catch ex As Exception
                                    dr_aux.Item("PrecioListaP") = 0
                                End Try
                                ods.Tables("documentod").Rows.Add(dr_aux)
                                'End If 'void
                            End If 'precio > 0

                        End If 'Bohname").ToString.StartsWith("-----")
                    End If
                Next


                ''DocumentoP
                dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11"
                icount = 0
                For Each drv In dt_gndtndr.DefaultView
                    icount += 1
                    dr_aux = ods.Tables("documentop").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    dr_aux.Item("Linea") = icount
                    If drv.Item("TypeId") = 1 Or drv.Item("TypeId") = 4 Then
                        ls_sql = "CONTADO,010101010700"
                    ElseIf drv.Item("TypeId") = 3 Then
                        ls_sql = "TC MASTERCARD,010101010300"
                    ElseIf drv.Item("TypeId") = 6 Then
                        ls_sql = "TC AMEX,010101010300"
                    ElseIf drv.Item("TypeId") = 7 Then
                        ls_sql = "TC DINERSCLUB,010101010300"
                    ElseIf drv.Item("TypeId") = 2 Then
                        ls_sql = "TC VISA NET,010101010300"
                    ElseIf drv.Item("TypeId") = 8 Then
                        ls_sql = "EXENCION IVA,010102040300"
                    ElseIf drv.Item("TypeId") = 9 Then
                        ls_sql = "PAGARE,010102010100"
                    ElseIf drv.Item("TypeId") = 10 Then
                        ls_sql = "CORTESIA,060103010100"
                    End If

                    If drv.Item("TypeId") < 11 Then
                        dr_aux.Item("CodigoPago") = ls_sql.Split(",")(0)
                        dr_aux.Item("TipoPago") = "T"
                        dr_aux.Item("FechaVcto") = dr.Item("DOB")
                        dr_aux.Item("Monto") = drv.Item("Amount")
                        dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                        dr_aux.Item("TipoDoctoPago") = dr_aux.Item("TipoDocto")
                        dr_aux.Item("NroDoctoPago") = dr.Item("Counter").ToString.PadLeft(10, "0")
                        dr_aux.Item("Cuenta") = ls_sql.Split(",")(1)
                        dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                        dr_aux.Item("AjusteBimoneda") = 0
                        dr_aux.Item("CuentaPago") = drv.Item("Ident")
                        dr_aux.Item("MonedaPago") = "QUETZALES"
                        dr_aux.Item("MontoPago") = dr_aux.Item("Monto")
                        dr_aux.Item("ParidadPago") = 1
                        ods.Tables("documentop").Rows.Add(dr_aux)
                    End If

                Next


                ''Documentov

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"


                For icount = 1 To 5
                    dr_aux = ods.Tables("documentov").NewRow
                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    If icount = 1 Then
                        dr_aux.Item("Nombre") = "DESC_LICORES"
                        dr_aux.Item("Orden") = 4
                        dr_aux.Item("Monto") = 0
                    ElseIf icount = 2 Then
                        dr_aux.Item("Nombre") = "DESCUENTO_L"
                        dr_aux.Item("Orden") = 13
                        dr_aux.Item("Monto") = 0

                        ''Debo Agregar Descuento Globales
                        dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 3"
                        For Each drvAux As DataRowView In dt_gndtndr.DefaultView
                            dr_aux.Item("Monto") = dr_aux.Item("Monto") + drvAux.Item("Amount")
                        Next


                        dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11 and TypeId = 11"
                        For Each drvAux As DataRowView In dt_gndtndr.DefaultView
                            dr_aux.Item("Monto") = dr_aux.Item("Monto") + drvAux.Item("Amount")
                        Next

                    ElseIf icount = 3 Then
                        dr_aux.Item("Nombre") = "IVA"
                        dr_aux.Item("Orden") = 21
                        dr_aux.Item("Porcentaje") = 12
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                        Try
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        Catch ex As Exception
                            dr_aux.Item("Monto") = 0
                        End Try

                    ElseIf icount = 4 Then
                        dr_aux.Item("Nombre") = "IVA_REAL"
                        dr_aux.Item("Orden") = 20
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"

                        Try
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        Catch ex As Exception
                            dr_aux.Item("Monto") = 0
                        End Try

                        dr_aux.Item("Porcentaje") = 0
                    ElseIf icount = 5 Then
                        dr_aux.Item("Nombre") = "NETO"
                        dr_aux.Item("Orden") = 1
                        dr_aux.Item("Monto") = 0
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                        For Each drva As DataRowView In dt_gndSale.DefaultView
                            dr_aux.Item("Monto") += drva.Item("Amount")
                        Next

                        dr_aux.Item("Porcentaje") = 0
                    End If
                    If icount < 3 Then
                        dr_aux.Item("Factor") = -1

                        dr_aux.Item("Porcentaje") = 0
                    Else
                        dr_aux.Item("Factor") = 0
                    End If

                    dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                    dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                    dr_aux.Item("Ajuste") = 0
                    dr_aux.Item("AjusteIngreso") = 0
                    ods.Tables("documentov").Rows.Add(dr_aux)
                Next


                If lagregar_Cliente Then

                    dt_clienteAccess.DefaultView.RowFilter = "CliNit = '" & dr.Item("CliNit").ToString & "'"
                    dr_aux = ods.Tables("ctacte").NewRow
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("RazonSocial") = dt_clienteAccess.DefaultView(0).Item("CliName")
                        dr_aux.Item("Direccion") = dt_clienteAccess.DefaultView(0).Item("CliDireccion")
                    Else
                        Agregar_Log("Problemas con el Cliente " & dr.Item("CliNit").ToString, "Error")
                    End If


                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoCtaCte") = "CLIENTE"
                    dr_aux.Item("CtaCte") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("CodLegal") = dr.Item("CliNit").ToString

                    dr_aux.Item("Tipo") = "FONTABELLA"
                    dr_aux.Item("Grupo") = "VENTA DIRECTA"
                    dr_aux.Item("Ejecutivo") = "RESTAURANTE FB"
                    dr_aux.Item("CondPago") = "CONTADO"
                    dr_aux.Item("Vigencia") = "S"
                    dr_aux.Item("ListaPrecio") = ls_listaprecios

                    dr_aux.Item("Pais") = "GUATEMALA"
                    dr_aux.Item("LimiteCredito") = 1
                    dr_aux.Item("VigenciaCredito") = Today
                    dr_aux.Item("RetrasoCredito") = 1
                    dr_aux.Item("FechaModif") = Now
                    dr_aux.Item("UsuarioModif") = "Admin"
                    dr_aux.Item("PorcDr1") = 0
                    dr_aux.Item("PorcDr2") = 0
                    dr_aux.Item("PorcDr3") = 0
                    dr_aux.Item("PorcDr4") = 0
                    dr_aux.Item("Moneda") = "QUETZALES"
                    dr_aux.Item("EstaCertificado") = "N"

                    ods.Tables("ctacte").Rows.Add(dr_aux)


                    dr_aux = ods.Tables("ctacte_gentabcod").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("Tipo") = "CON_CLIENT"
                    dr_aux.Item("Codigo") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("NemoTecnico") = dr.Item("CliNit").ToString.Split("-")(0)
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("Descripcion") = dt_clienteAccess.DefaultView(0).Item("CliName")
                    End If
                    dr_aux.Item("Texto1") = ""
                    dr_aux.Item("Vigencia") = "S"

                    ods.Tables("ctacte_gentabcod").Rows.Add(dr_aux)



                End If
                ''Validar Totales

                Try
                    dtotal_encabezado = Round(ods.Tables("documento").Compute("Sum(Total)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_detalle = Round(ods.Tables("documentod").Compute("Sum(SubTotal)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_pago = Round(ods.Tables("documentop").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_valores = Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter") & " And Orden < 21"), 2)

                    Try
                        '       dtotal_valores += Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter") & " And Orden < 21"), 2)
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try

                If dtotal_encabezado <> dtotal_detalle Or dtotal_encabezado <> dtotal_pago Or dtotal_encabezado <> dtotal_valores Then
                    Agregar_Log("Problemas con los Totales " & dr.Item("Serie") & " " & dr.Item("Counter"), "Error")
                    '  lgenerar_error = True
                End If

                'Osinc.Enviar_Documento(gs_empresa, ods.Tables("documento").Rows(0), ods.Tables("documentod"), _
                '                ods.Tables("documentov"), ods.Tables("documentop"), "", True)
                'Exit For
            Next 'dr




        Catch ex As Exception
            lgenerar_error = True
        Finally
            Aotrans.Close()
            Aotrans = Nothing
            Otrans.close()
            Otrans = Nothing
            fOtrans = Nothing
            Me.dgv_documentos.DataSource = ods.Tables("documento")
            ClsGen.Alinear_GridView(ods.Tables("documento"), Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)
            ClsGen = Nothing
        End Try
        If Not lgenerar_error Then
            Me.btn_procesar.Visible = True

        End If

    End Sub

    Private Sub Generar_Informacion_Vinoteca_AlohaPC()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Aotrans As New Transaccional.Conexion_Access("Access", 24)
        Dim fOtrans As Transaccional.Conexion_Fox

        Dim ClsGen As New ClasesGenerales.General

        Dim ls_sql As String
        Dim dt, dt_cliente, dt_ventas, dt_clienteAccess As DataTable
        Dim dt_gndSale, dt_gndtndr, dt_gndItem, dt_Itm, dt_gndVoid, dt_empleado As DataTable
        Dim dt_tdr As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim icount As Integer = 0
        Dim lagregar_Cliente As Boolean = False
        Dim lgenerar_error As Boolean = False

        Dim ls_listaprecios As String = "FONTABELLA_1103A"


        If Me.dtp_fecha_inicio.Value < Date.Parse("01/03/2011") Then
            '            ls_listaprecios = "PREMIUM_1103A"
            ls_listaprecios = "FONTABELLA_0910"
        End If

        Dim dtotal_encabezado As Double = 0, dtotal_detalle As Double = 0, dtotal_pago As Double = 0, dtotal_valores As Double

        Try

            Otrans.open()
            ls_sql = "pa_var_um_listaPrecio_listado '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "fec_inicio <='" & Me.dtp_fecha_inicio.Value.ToString("dd-MM-yyyy") & "' and fec_final >= '" & Me.dtp_fecha_inicio.Value.ToString("dd-MM-yyyy") & "'"

            dt = dt.DefaultView.ToTable
            dt.DefaultView.RowFilter = "lisprecio like '%fonta%'"

            If dt.DefaultView.Count = 1 Then
                ls_listaprecios = dt.DefaultView(0).Item("lisprecio")
            End If
            Crear_Estructura_Auxiliar()
            Aotrans.Open()
            If Aotrans.Codigo_error > 0 Then
                MessageBox.Show(Aotrans.descripcion_error)
                Exit Sub
            End If

            Aotrans.Nombre_Tabla = "HInvoice" '"HInvoice"
            Aotrans.Condiciones = "DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_ventas = Aotrans.Obtiene()

            Aotrans.Lista_Campos = "Cliente.*"
            Aotrans.Nombre_Tabla = "CLIENTE, HINVOICE "
            Aotrans.Condiciones = "CLIENTE.CliNit = HINVOICE.CliNit and HINVOICE.DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_clienteAccess = Aotrans.Obtiene


            fOtrans = New Transaccional.Conexion_Fox("Fox", 24)
            fOtrans.Fecha_Proceso = "NewData"
            fOtrans.Open()


            fOtrans.Nombre_Tabla = "emp"
            dt_empleado = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Itm"
            dt_Itm = fOtrans.Obtiene()

            fOtrans = New Transaccional.Conexion_Fox("Fox", 24)
            fOtrans.Fecha_Proceso = Me.dtp_fecha_inicio.Value.ToString("yyyyMMdd")
            fOtrans.Open()

            fOtrans.Nombre_Tabla = "Gndtndr"
            dt_gndtndr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndSale"
            dt_gndSale = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndItem"
            dt_gndItem = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Tdr"
            dt_tdr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Gndvoid"
            dt_gndVoid = fOtrans.Obtiene



            For Each dr In dt_ventas.Rows
                dr_aux = ods.Tables("documento").NewRow
                If dr.Item("counter") = 531 Then
                    dr.Item("counter") = 531
                End If

                dr_aux.Item("empresa") = gs_empresa
                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                dr_aux.Item("Numero") = dr.Item("Counter").ToString.PadLeft(10, "0")
                dr_aux.Item("Correlativo") = dr.Item("Counter")
                dr_aux.Item("Fecha") = dr.Item("DOB")

                If dr.Item("CliNit").ToString = "-" Or dr.Item("CliNit").ToString = "_" Then
                    dr_aux.Item("Cliente") = "0000000001" 'dr.Item("")"
                Else
                    ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,NULL,'" & dr.Item("CliNit") & "'"
                    dt_cliente = Otrans.Obtiene(ls_sql)
                    If dt_cliente.Rows.Count > 0 Then
                        dr_aux.Item("Cliente") = dt_cliente.Rows(0).Item("CtaCte")
                    Else
                        ''Debo Crear El Cliente
                        dr_aux.Item("Cliente") = dr.Item("CliNit").ToString.Split("-")(0)
                        lagregar_Cliente = True
                    End If
                End If


                dr_aux.Item("Bodega") = "SVPC_FLIGHTS"
                dr_aux.Item("Vendedor") = "FLIGHTS PC"

                dr_aux.Item("ListaPrecio") = ls_listaprecios
                dr_aux.Item("Moneda") = "QUETZALES"
                dr_aux.Item("Paridad") = 1

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                dr_aux.Item("Neto") = 0
                For Each drv4 As DataRowView In dt_gndSale.DefaultView
                    dr_aux.Item("Neto") = dr_aux.Item("Neto") + drv4.Item("Amount")
                Next
                'dr_aux.Item("Neto") = dt_gndSale.DefaultView(0).Item("Amount")

                dr_aux.Item("SubTotal") = dr.Item("Total")
                dr_aux.Item("Total") = dr.Item("Total")
                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalIngreso") = dr.Item("Total")
                dr_aux.Item("TotalIngreso") = dr.Item("Total")
                dr_aux.Item("Aprobacion") = "S"
                dr_aux.Item("PeriodoLibro") = Date.Parse(dr.Item("DOB").ToString).ToString("yyyyMM")
                dr_aux.Item("FactorMonto") = 1
                dr_aux.Item("FactorMontoProyectado") = 0
                dr_aux.Item("TipoCtaCte") = "CLIENTE"
                dr_aux.Item("glosa") = "Check " & dr.Item("CheckNumber").ToString
                dr_aux.Item("IdCtaCte") = dr_aux.Item("Cliente")
                dr_aux.Item("Vigencia") = IIf(dr.Item("Activo"), "S", "A")
                dr_aux.Item("Emitido") = "N"
                dr_aux.Item("PorcentajeAsignado") = 0
                dr_aux.Item("Adjuntos") = "N"
                Try
                    dr_aux.Item("FechaModif") = dr.Item("DOB") & " " & _
                                                               dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                               dt_gndSale.DefaultView(0).Item("Closemin")

                    dr_aux.Item("FechaUModif") = dr_aux.Item("FechaModif")
                Catch ex As Exception

                End Try


                dt_empleado.DefaultView.RowFilter = "id = " & dt_gndItem.DefaultView(0).Item("employee")
                If dt_empleado.DefaultView.Count > 0 Then
                    If dt_empleado.DefaultView(0)("Address1").ToString.Length > 0 Then

                        dr_aux.Item("UsuarioModif") = dt_empleado.DefaultView(0)("Address1").ToString.ToUpper ''En Address debe estar el Usuario Flex para que no todo venga con Admin
                    Else
                        dr_aux.Item("UsuarioModif") = "Admin"
                    End If
                Else
                    dr_aux.Item("UsuarioModif") = "Admin"
                End If

                Try
                    dr_aux.Item("Hora") = dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                dt_gndSale.DefaultView(0).Item("Closemin")
                Catch ex As Exception

                End Try

                dr_aux.Item("Caja") = ""
                dr_aux.Item("Pago") = dr.Item("Total")
                dr_aux.Item("IdApertura") = 0

                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalBimoneda") = dr.Item("Total")
                dr_aux.Item("TotalBimoneda") = dr.Item("Total")
                dr_aux.Item("ParidadBimoneda") = 1


                ods.Tables("documento").Rows.Add(dr_aux)


                ''Detalle
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                icount = 0
                For Each drv In dt_gndItem.DefaultView

                    dt_Itm.DefaultView.RowFilter = "Id = " & drv.Item("Item")
                    If dt_Itm.DefaultView.Count > 0 Then



                        If Not dt_Itm.DefaultView(0).Item("Bohname").ToString.StartsWith("-----") Then


                            dt_gndVoid.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and Item = " & drv.Item("Item")
                            If drv.Item("Price") > 0 Then
                                'If dt_gndVoid.DefaultView.Count = 0 Then

                                icount += 1
                                dr_aux = ods.Tables("documentod").NewRow

                                dr_aux.Item("Empresa") = gs_empresa
                                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                                dr_aux.Item("Correlativo") = dr.Item("Counter")
                                dr_aux.Item("Secuencia") = icount
                                dr_aux.Item("Linea") = icount
                                dr_aux.Item("Producto") = dt_Itm.DefaultView(0).Item("Bohname")

                



                                ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"

                                            dt = Otrans.Obtiene(ls_sql)

                                            dr_aux.Item("Cantidad") = drv.Item("Quantity")
                                            dr_aux.Item("Precio") = dt_Itm.DefaultView(0).Item("Price") '--drv.Item("Price")

                                            Try
                                                If dr_aux.Item("cantidad").ToString.Split(".").Length = 1 Then '= Integer.Parse(dr_aux.Item("cantidad").ToString) Then
                                                    dr_aux.Item("Precio") = drv.Item("Price")
                                                End If
                                            Catch ex As Exception

                                            End Try


                                            dr_aux.Item("PorcentajeDr") = 0
                                            'dr_aux.Item("SubTotal") = dr_aux.Item("Price")
                                            dr_aux.Item("SubTotal") = dr_aux.Item("Cantidad") * dr_aux.Item("Precio")
                                            If dr_aux.Item("SubTotal") <> drv.Item("Price") Then
                                                ' If dr_aux.Item("producto") = "0400060481" Then
                                                If dr_aux.Item("Cantidad") < 1 Then
                                                    dr_aux.Item("SubTotal") = drv.Item("Price")
                                                    dr_aux.Item("precio") = dr_aux.Item("subtotal") / dr_aux.Item("cantidad")
                                                End If

                                            End If

                                            dr_aux.Item("Impuesto") = Round((dr_aux.Item("subtotal") / 1.12) * 0.12, 6) 'drv.Item("Incltax") '* dr_aux.Item("Cantidad")
                                            dr_aux.Item("Neto") = dr_aux.Item("SubTotal") - dr_aux.Item("Impuesto")
                                            dr_aux.Item("DrGlobal") = 0

                                            dr_aux.Item("Total") = dr_aux.Item("Neto")
                                            dr_aux.Item("PrecioAjustado") = drv.Item("Price") - drv.Item("Incltax")
                                            dr_aux.Item("UnidadIngreso") = "UN"

                                            If dt.Rows.Count = 1 Then dr_aux.Item("UnidadIngreso") = dt.Rows(0).Item("unidad")


                                            dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                                            dr_aux.Item("PrecioIngreso") = dt_Itm.DefaultView(0).Item("Price") 'drv.Item("Price")
                                            dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                                            dr_aux.Item("ImpuestoIngreso") = dr_aux.Item("Impuesto")
                                            dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                                            dr_aux.Item("DRGlobalIngreso") = 0
                                            dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                                            dr_aux.Item("CorrelativoOrigen") = 0
                                            dr_aux.Item("SecuenciaOrigen") = 0
                                            dr_aux.Item("Bodega") = "SVPC_FLIGHTS"
                                            dr_aux.Item("FactorInventario") = -1
                                            dr_aux.Item("FechaEntrega") = dr.Item("DOB")
                                            dr_aux.Item("CantidadAsignada") = 0
                                            dr_aux.Item("Fecha") = dr.Item("DOB")
                                            dr_aux.Item("Vigente") = "S"
                                            dr_aux.Item("CUP") = 0
                                            dr_aux.Item("Ubicacion") = "PRINCIPAL"
                                            dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                                            dr_aux.Item("FactorImpto") = 0.89285714
                                            dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                                            dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                                            dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                                            dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                                            dr_aux.Item("DrGlobalBimoneda") = 0
                                            dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")
                                            dr_aux.Item("DoctoOrigenVal") = "N"



                                            Try
                                                dr_aux.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                                            Catch ex As Exception
                                                dr_aux.Item("costo") = 0
                                            End Try


                                            ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                                                    "','" & ls_listaprecios & "'"

                                            dt = Otrans.Obtiene(ls_sql)
                                            Try
                                                dr_aux.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                                                dr_aux.Item("PrecioListaP") = dt.Rows(0).Item("valor")
                                            Catch ex As Exception
                                                dr_aux.Item("PrecioListaP") = 0
                                            End Try



                                            ods.Tables("documentod").Rows.Add(dr_aux)
                                            'End If 'void
                                        End If 'precio > 0

                                    End If 'Bohname").ToString.StartsWith("-----")
                                End If 'dt_im.DefaultView
                Next

                ''DocumentoP
                dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11"
                icount = 0
                For Each drv In dt_gndtndr.DefaultView
                    icount += 1
                    dr_aux = ods.Tables("documentop").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    dr_aux.Item("Linea") = icount
                    If drv.Item("TypeId") = 1 Or drv.Item("TypeId") = 4 Then
                        ls_sql = "CONTADO,010101010700"
                    ElseIf drv.Item("TypeId") = 3 Then
                        ls_sql = "TC MASTERCARD,010101010300"
                    ElseIf drv.Item("TypeId") = 6 Then
                        ls_sql = "TC AMEX,010101010300"
                    ElseIf drv.Item("TypeId") = 7 Then
                        ls_sql = "TC DINERSCLUB,010101010300"
                    ElseIf drv.Item("TypeId") = 2 Then
                        ls_sql = "TC VISA NET,010101010300"
                    ElseIf drv.Item("TypeId") = 8 Then
                        ls_sql = "EXENCION IVA,010102040300"
                    ElseIf drv.Item("TypeId") = 9 Then
                        ls_sql = "PAGARE,010102010100"
                    ElseIf drv.Item("TypeId") = 10 Then
                        ls_sql = "CORTESIA,060103010100"
                    End If

                    dr_aux.Item("CodigoPago") = ls_sql.Split(",")(0)
                    dr_aux.Item("TipoPago") = "T"
                    dr_aux.Item("FechaVcto") = dr.Item("DOB")
                    dr_aux.Item("Monto") = drv.Item("Amount")
                    dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                    dr_aux.Item("TipoDoctoPago") = dr_aux.Item("TipoDocto")
                    dr_aux.Item("NroDoctoPago") = dr.Item("Counter").ToString.PadLeft(10, "0")
                    dr_aux.Item("Cuenta") = ls_sql.Split(",")(1)
                    dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                    dr_aux.Item("AjusteBimoneda") = 0
                    dr_aux.Item("CuentaPago") = drv.Item("Ident")
                    dr_aux.Item("MonedaPago") = "QUETZALES"
                    dr_aux.Item("MontoPago") = dr_aux.Item("Monto")
                    dr_aux.Item("ParidadPago") = 1
                    ods.Tables("documentop").Rows.Add(dr_aux)

                Next


                ''Documentov

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"

                For icount = 1 To 5
                    dr_aux = ods.Tables("documentov").NewRow
                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    If icount = 1 Then
                        dr_aux.Item("Nombre") = "DESC_LICORES"
                        dr_aux.Item("Orden") = 4
                        dr_aux.Item("Monto") = 0
                    ElseIf icount = 2 Then
                        dr_aux.Item("Nombre") = "DESCUENTO_L"
                        dr_aux.Item("Orden") = 13

                        ''Debo Agregar Descuento Globales
                        dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 3"
                        If dt_gndtndr.DefaultView.Count > 0 Then
                            dr_aux.Item("Monto") = dt_gndtndr.DefaultView(0).Item("Amount")
                        Else
                            dr_aux.Item("Monto") = 0
                        End If

                    ElseIf icount = 3 Then
                        dr_aux.Item("Nombre") = "IVA"
                        dr_aux.Item("Orden") = 21
                        dr_aux.Item("Porcentaje") = 12
                        dr_aux.Item("Monto") = 0
                        Try
                            dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        Catch ex As Exception

                        End Try

                    ElseIf icount = 4 Then
                        dr_aux.Item("Nombre") = "IVA_REAL"
                        dr_aux.Item("Orden") = 20
                        dr_aux.Item("Monto") = 0
                        Try
                            dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        Catch ex As Exception
                        End Try
                        dr_aux.Item("Porcentaje") = 0
                    ElseIf icount = 5 Then
                        dr_aux.Item("Nombre") = "NETO"
                        dr_aux.Item("Orden") = 1
                        dr_aux.Item("Monto") = 0
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                        Try

                            For Each drva As DataRowView In dt_gndSale.DefaultView
                                dr_aux.Item("Monto") += drva.Item("Amount")
                            Next
                        Catch ex As Exception
                        End Try

                        dr_aux.Item("Porcentaje") = 0
                    End If
                    If icount < 3 Then
                        dr_aux.Item("Factor") = -1

                        dr_aux.Item("Porcentaje") = 0
                    Else
                        dr_aux.Item("Factor") = 0
                    End If



                    dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                    dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")

                    dr_aux.Item("Ajuste") = 0
                    dr_aux.Item("AjusteIngreso") = 0



                    ods.Tables("documentov").Rows.Add(dr_aux)

                Next




                If lagregar_Cliente Then

                    dt_clienteAccess.DefaultView.RowFilter = "CliNit = '" & dr.Item("CliNit").ToString & "'"
                    dr_aux = ods.Tables("ctacte").NewRow
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("RazonSocial") = dt_clienteAccess.DefaultView(0).Item("CliName")
                        dr_aux.Item("Direccion") = dt_clienteAccess.DefaultView(0).Item("CliDireccion")
                    Else
                        Agregar_Log("Problemas con el Cliente " & dr.Item("CliNit").ToString, "Error")
                    End If


                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoCtaCte") = "CLIENTE"
                    dr_aux.Item("CtaCte") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("CodLegal") = dr.Item("CliNit").ToString

                    dr_aux.Item("Tipo") = "ZONA 14"
                    dr_aux.Item("Grupo") = "VENTA DIRECTA"
                    dr_aux.Item("Ejecutivo") = "VENTA DIRECTA 14"
                    dr_aux.Item("CondPago") = "CONTADO"
                    dr_aux.Item("Vigencia") = "S"
                    dr_aux.Item("ListaPrecio") = ls_listaprecios

                    dr_aux.Item("Pais") = "GUATEMALA"
                    dr_aux.Item("LimiteCredito") = 1
                    dr_aux.Item("VigenciaCredito") = Today
                    dr_aux.Item("RetrasoCredito") = 1
                    dr_aux.Item("FechaModif") = Now
                    dr_aux.Item("UsuarioModif") = "Admin"
                    dr_aux.Item("PorcDr1") = 0
                    dr_aux.Item("PorcDr2") = 0
                    dr_aux.Item("PorcDr3") = 0
                    dr_aux.Item("PorcDr4") = 0
                    dr_aux.Item("Moneda") = "QUETZALES"
                    dr_aux.Item("EstaCertificado") = "N"

                    ods.Tables("ctacte").Rows.Add(dr_aux)


                    dr_aux = ods.Tables("ctacte_gentabcod").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("Tipo") = "CON_CLIENT"
                    dr_aux.Item("Codigo") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("NemoTecnico") = dr.Item("CliNit").ToString.Split("-")(0)
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("Descripcion") = dt_clienteAccess.DefaultView(0).Item("CliName")
                    End If
                    dr_aux.Item("Texto1") = ""
                    dr_aux.Item("Vigencia") = "S"

                    ods.Tables("ctacte_gentabcod").Rows.Add(dr_aux)

                End If
                ''Validar Totales


                Try
                    dtotal_encabezado = Round(ods.Tables("documento").Compute("Sum(Total)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_detalle = Round(ods.Tables("documentod").Compute("Sum(SubTotal)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_pago = Round(ods.Tables("documentop").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_valores = Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter") & " And Orden < 21"), 2)
                Catch ex As Exception
                End Try

                If Val(dtotal_encabezado - dtotal_detalle) > 0.1 Or Val(dtotal_encabezado - dtotal_pago) > 0.1 Or Val(dtotal_encabezado - dtotal_valores) > 0.1 Then
                    Agregar_Log("Problemas con los Totales " & dr.Item("Serie") & " " & dr.Item("Counter"), "Error")
                    lgenerar_error = True
                End If

                'Osinc.Enviar_Documento(gs_empresa, ods.Tables("documento").Rows(0), ods.Tables("documentod"), _
                '                ods.Tables("documentov"), ods.Tables("documentop"), "", True)
                'Exit For
            Next 'dr




        Catch ex As Exception
            lgenerar_error = True
        Finally
            Aotrans.Close()
            Aotrans = Nothing
            Otrans.close()
            Otrans = Nothing
            fOtrans = Nothing
            Me.dgv_documentos.DataSource = ods.Tables("documento")
            ClsGen.Alinear_GridView(ods.Tables("documento"), Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)
            ClsGen = Nothing
        End Try
        'If Not lgenerar_error Then
        Me.btn_procesar.Visible = True

        'End If

    End Sub

    Private Sub generarInformacionVinotecaAlohaZ14Inventarios()
        'Private Sub Generar_Informacion_Vinoteca_AlohaZ14()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Aotrans As New Transaccional.Conexion_Access("Access", 20)
        Dim fOtrans As Transaccional.Conexion_Fox

        Dim ClsGen As New ClasesGenerales.General

        Dim ls_sql As String
        Dim dt, dt_cliente, dt_ventas, dt_clienteAccess, dtDocumentos As DataTable
        Dim dt_gndSale, dt_gndtndr, dt_gndItem, dt_Itm, dt_gndVoid, dt_empleado As DataTable
        Dim dt_tdr, dtProductosFlex As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim icount As Integer = 0
        Dim lagregar_Cliente As Boolean = False
        Dim lgenerar_error As Boolean = False

        Dim ls_listaprecios As String = "DIRECTO_1204A"

        If Me.dtp_fecha_inicio.Value < Date.Parse("01/03/2011") Then
            '            ls_listaprecios = "PREMIUM_1103A"
            ls_listaprecios = "DIRECTO_1204A"
        End If

        Dim dtotal_encabezado As Double = 0, dtotal_detalle As Double = 0, dtotal_pago As Double = 0, dtotal_valores As Double

        Try
            'Crear_Estructura_Auxiliar()
            Aotrans.Open()
            If Aotrans.Codigo_error > 0 Then
                MessageBox.Show(Aotrans.descripcion_error)
                Exit Sub
            End If
            Otrans.open()


            ls_sql = "pa_sel_um_producto '" & gs_empresa & "',null"
            dtProductosFlex = Otrans.Obtiene(ls_sql)
            ''Salidas
            Aotrans.Nombre_Tabla = "qRIJ06"
            'Aotrans.Nombre_Tabla = "DBInfo"
            Aotrans.Condiciones = ""
            'Aotrans.Nombre_Tabla = "HInvoice" '"HInvoice"
            Aotrans.Condiciones = "AdjDate = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_ventas = Aotrans.Obtiene()
            dtDocumentos = ClsGen.ValoresDistinto(dt_ventas, "adjTypeDescription,adjReference,unitname".Split(","))
            Me.dgv_documentos.DataSource = dtDocumentos

            For Each dr2 As DataRow In dtDocumentos.Rows

                dt_ventas.DefaultView.RowFilter = "adjTypeDescription = '" & dr2.Item("adjTypeDescripcion").ToString & "' and " & _
                                                  "adjReference = '" & dr2.Item("adjReference").ToString & "' and " & _
                                                  "unitname = '" & dr2.Item("unitname").ToString & "'"

                Dim lbinicio As Boolean = True
                icount = 0

                For Each drv2 As DataRowView In dt_ventas.DefaultView
                    If lbinicio Then
                        lbinicio = False

                        dr_aux = ods.Tables("documento").NewRow
                        'If dr.Item("counter") = 12176 Then
                        '    dr.Item("counter") = 12176
                        'End If

                        dr_aux.Item("empresa") = gs_empresa
                        If drv2.Item("adjTypeDescription") = "Adj Trans. Out" Then
                            dr_aux.Item("TipoDocto") = "Entrada Trans. Z14"
                            dr_aux.Item("Bodega") = "SV14"
                        End If

                        dr_aux.Item("Numero") = drv2.Item("txControl_ID").ToString
                        dr_aux.Item("Correlativo") = Val(drv2.Item("txControl_ID").ToString)
                        dr_aux.Item("Fecha") = drv2.Item("AdjDate")


                        dr_aux.Item("Moneda") = "QUETZALES"
                        dr_aux.Item("Paridad") = 1

                    


                        dr_aux.Item("Neto") = 0
                        ' For Each drv4 As DataRowView In dt_gndSale.DefaultView
                        'dr_aux.Item("Neto") = dr_aux.Item("Neto") + drv4.Item("Amount")
                        'Next
                        'dr_aux.Item("Neto") = dt_gndSale.DefaultView(0).Item("Amount")

                        dr_aux.Item("SubTotal") = dr.Item("Total")
                        dr_aux.Item("Total") = dr.Item("Total")
                        dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                        dr_aux.Item("SubTotalIngreso") = dr.Item("Total")
                        dr_aux.Item("TotalIngreso") = dr.Item("Total")
                        dr_aux.Item("Aprobacion") = "S"
                        dr_aux.Item("PeriodoLibro") = Date.Parse(drv2.Item("AdjDate").ToString).ToString("yyyyMM")
                        dr_aux.Item("FactorMonto") = 0
                        dr_aux.Item("FactorMontoProyectado") = 0
                        dr_aux.Item("TipoCtaCte") = "CLIENTE"
                        dr_aux.Item("glosa") = drv2.Item("AdjReference").ToString '"Check " & dr.Item("CheckNumber").ToString
                        dr_aux.Item("IdCtaCte") = "" 'dr_aux.Item("Cliente")
                        dr_aux.Item("Vigencia") = "S" 'IIf(dr.Item("Activo"), "S", "A")
                        dr_aux.Item("Emitido") = "N"
                        dr_aux.Item("PorcentajeAsignado") = 0
                        dr_aux.Item("Adjuntos") = "N"

                        dr_aux.Item("FechaModif") = drv2.Item("TrxDateAdded")
                        dr_aux.Item("FechaUModif") = drv2.Item("TrxDateAdded")
                        dr_aux.Item("UsuarioModif") = drv2.Item("Operator")

                        'dr_aux.Item("Hora") = dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                        'dt_gndSale.DefaultView(0).Item("Closemin")
                        dr_aux.Item("Caja") = ""
                        dr_aux.Item("Pago") = dr.Item("Total")
                        dr_aux.Item("IdApertura") = 0

                        dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                        dr_aux.Item("SubTotalBimoneda") = dr.Item("Total")
                        dr_aux.Item("TotalBimoneda") = dr.Item("Total")
                        dr_aux.Item("ParidadBimoneda") = 1


                        ods.Tables("documento").Rows.Add(dr_aux)

                    End If




                    ''Detalle
                    dtProductosFlex.DefaultView.RowFilter = "itm = '" & drv2.Item("ItemNumber").ToString & "'"
                    'dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                    ' For Each drv In dt_gndItem.DefaultView

                    'dt_Itm.DefaultView.RowFilter = "Id = " & drv.Item("Item")
                    'dt_Itm.DefaultView.RowFilter = "bohname = '" & drv.Item("bohname").ToString & "'"
                    If dtProductosFlex.DefaultView.Count = 1 Then 'Not dt_Itm.DefaultView(0).Item("Bohname").ToString.StartsWith("-----") Then


                        'dt_gndVoid.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and Item = " & drv.Item("Item")
                        'If drv.Item("Price") > 0 Then
                        'If dt_gndVoid.DefaultView.Count = 0 Then

                        icount += 1
                        dr_aux = ods.Tables("documentod").NewRow

                        dr_aux.Item("Empresa") = gs_empresa
                        If drv2.Item("adjTypeDescription") = "Adj Trans. Out" Then
                            dr_aux.Item("TipoDocto") = "Entrada Trans. Z14"
                            dr_aux.Item("Bodega") = "SV14"
                        End If

                        dr_aux.Item("Correlativo") = drv2.Item("txControl_ID").ToString

                        dr_aux.Item("Secuencia") = icount
                        dr_aux.Item("Linea") = icount
                        dr_aux.Item("Producto") = dtProductosFlex.DefaultView(0).Item("Producto")

                        dr_aux.Item("Cantidad") = drv2.Item("AdjQty")
                        dr_aux.Item("Precio") = drv2.Item("AdjAMount") / drv2.Item("AdjQty") 'dt_Itm.DefaultView(0).Item("Price") '--drv.Item("Price")
                        dr_aux.Item("PorcentajeDr") = 0
                        'dr_aux.Item("SubTotal") = dr_aux.Item("Price")
                        dr_aux.Item("SubTotal") = drv2.Item("AdjAMount") 'dr_aux.Item("Cantidad") * dr_aux.Item("Precio")
                        'If dr_aux.Item("SubTotal") <> drv.Item("Price") Then
                        '    If dr_aux.Item("producto") = "0400060481" Then
                        '        dr_aux.Item("SubTotal") = drv.Item("Price")
                        '        dr_aux.Item("precio") = dr_aux.Item("subtotal") / dr_aux.Item("cantidad")
                        '    End If
                        'End If
                        dr_aux.Item("Impuesto") = dr_aux.Item("SubTotal") * 0.89285714 'drv.Item("Incltax") * dr_aux.Item("Cantidad")
                        dr_aux.Item("Neto") = dr_aux.Item("SubTotal") - dr_aux.Item("Impuesto")
                        dr_aux.Item("DrGlobal") = 0

                        dr_aux.Item("Total") = dr_aux.Item("Neto")
                        dr_aux.Item("PrecioAjustado") = 0 ' drv.Item("Price") - drv.Item("Incltax")
                        dr_aux.Item("UnidadIngreso") = "UN"
                        dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                        dr_aux.Item("PrecioIngreso") = dr_aux.Item("Precio")
                        dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                        dr_aux.Item("ImpuestoIngreso") = dr_aux.Item("Impuesto") 'drv.Item("Incltax") * dr_aux.Item("Cantidad")
                        dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                        dr_aux.Item("DRGlobalIngreso") = 0
                        dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                        dr_aux.Item("CorrelativoOrigen") = 0
                        dr_aux.Item("SecuenciaOrigen") = 0
                        'dr_aux.Item("Bodega") = "SV14"
                        dr_aux.Item("FactorInventario") = 1
                        dr_aux.Item("FechaEntrega") = drv2.Item("AdjDate")
                        dr_aux.Item("CantidadAsignada") = 0
                        dr_aux.Item("Fecha") = drv2.Item("AdjDate")
                        dr_aux.Item("Vigente") = "S"
                        dr_aux.Item("CUP") = 0
                        dr_aux.Item("Ubicacion") = "PRINCIPAL"
                        dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                        dr_aux.Item("FactorImpto") = 0.89285714
                        dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                        dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                        dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                        dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                        dr_aux.Item("DrGlobalBimoneda") = 0
                        dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")
                        dr_aux.Item("DoctoOrigenVal") = "N"


                        ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"
                        dt = Otrans.Obtiene(ls_sql)

                        Try
                            dr_aux.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                        Catch ex As Exception
                            dr_aux.Item("costo") = 0
                        End Try


                        ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                                "','" & ls_listaprecios & "'"

                        dt = Otrans.Obtiene(ls_sql)
                        Try
                            dr_aux.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                            dr_aux.Item("PrecioListaP") = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            dr_aux.Item("PrecioListaP") = 0
                        End Try



                        ods.Tables("documentod").Rows.Add(dr_aux)
                        'End If 'void
                        'End If 'precio > 0

                    End If 'Bohname").ToString.StartsWith("-----")

                Next








            Next
            'Next


            If False Then

                Aotrans.Lista_Campos = "Cliente.*"
                Aotrans.Nombre_Tabla = "CLIENTE, HINVOICE "
                Aotrans.Condiciones = "CLIENTE.CliNit = HINVOICE.CliNit and HINVOICE.DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
                dt_clienteAccess = Aotrans.Obtiene


                fOtrans = New Transaccional.Conexion_Fox("Fox", 24)
                fOtrans.Fecha_Proceso = "NewData"
                fOtrans.Open()
                fOtrans.Nombre_Tabla = "Itm"
                dt_Itm = fOtrans.Obtiene()

                fOtrans.Nombre_Tabla = "emp"
                dt_empleado = fOtrans.Obtiene

                fOtrans = New Transaccional.Conexion_Fox("Fox", 24)
                fOtrans.Fecha_Proceso = Me.dtp_fecha_inicio.Value.ToString("yyyyMMdd")
                fOtrans.Open()
                fOtrans.Nombre_Tabla = "Gndtndr"
                dt_gndtndr = fOtrans.Obtiene
                fOtrans.Nombre_Tabla = "GndSale"
                dt_gndSale = fOtrans.Obtiene
                fOtrans.Nombre_Tabla = "GndItem"
                dt_gndItem = fOtrans.Obtiene
                fOtrans.Nombre_Tabla = "Tdr"
                dt_tdr = fOtrans.Obtiene
                fOtrans.Nombre_Tabla = "Gndvoid"
                dt_gndVoid = fOtrans.Obtiene



                For Each dr In dt_ventas.Rows
                    dr_aux = ods.Tables("documento").NewRow
                    'If dr.Item("counter") = 12176 Then
                    '    dr.Item("counter") = 12176
                    'End If

                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Numero") = dr.Item("Counter").ToString.PadLeft(10, "0")
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    dr_aux.Item("Fecha") = dr.Item("DOB")

                    If dr.Item("CliNit").ToString = "-" Or dr.Item("CliNit").ToString = "_" Then
                        dr_aux.Item("Cliente") = "0000000001" 'dr.Item("")"
                    Else
                        ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,NULL,'" & dr.Item("CliNit") & "'"
                        dt_cliente = Otrans.Obtiene(ls_sql)
                        If dt_cliente.Rows.Count > 0 Then
                            dr_aux.Item("Cliente") = dt_cliente.Rows(0).Item("CtaCte")
                        Else
                            ''Debo Crear El Cliente
                            dr_aux.Item("Cliente") = dr.Item("CliNit").ToString.Split("-")(0)
                            lagregar_Cliente = True
                        End If
                    End If


                    dr_aux.Item("Bodega") = "SV14"
                    dr_aux.Item("Vendedor") = "VENTA DIRECTA 14"

                    dr_aux.Item("ListaPrecio") = ls_listaprecios
                    dr_aux.Item("Moneda") = "QUETZALES"
                    dr_aux.Item("Paridad") = 1

                    dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                    dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                    dr_aux.Item("Neto") = 0
                    For Each drv4 As DataRowView In dt_gndSale.DefaultView
                        dr_aux.Item("Neto") = dr_aux.Item("Neto") + drv4.Item("Amount")
                    Next
                    'dr_aux.Item("Neto") = dt_gndSale.DefaultView(0).Item("Amount")

                    dr_aux.Item("SubTotal") = dr.Item("Total")
                    dr_aux.Item("Total") = dr.Item("Total")
                    dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                    dr_aux.Item("SubTotalIngreso") = dr.Item("Total")
                    dr_aux.Item("TotalIngreso") = dr.Item("Total")
                    dr_aux.Item("Aprobacion") = "S"
                    dr_aux.Item("PeriodoLibro") = Date.Parse(dr.Item("DOB").ToString).ToString("yyyyMM")
                    dr_aux.Item("FactorMonto") = 1
                    dr_aux.Item("FactorMontoProyectado") = 0
                    dr_aux.Item("TipoCtaCte") = "CLIENTE"
                    dr_aux.Item("glosa") = "Check " & dr.Item("CheckNumber").ToString
                    dr_aux.Item("IdCtaCte") = dr_aux.Item("Cliente")
                    dr_aux.Item("Vigencia") = IIf(dr.Item("Activo"), "S", "A")
                    dr_aux.Item("Emitido") = "N"
                    dr_aux.Item("PorcentajeAsignado") = 0
                    dr_aux.Item("Adjuntos") = "N"
                    Try
                        dr_aux.Item("FechaModif") = dr.Item("DOB") & " " & _
                                                                   dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                                   dt_gndSale.DefaultView(0).Item("Closemin")

                        dr_aux.Item("FechaUModif") = dr_aux.Item("FechaModif")
                    Catch ex As Exception

                    End Try


                    dt_empleado.DefaultView.RowFilter = "id = " & dt_gndItem.DefaultView(0).Item("employee")
                    If dt_empleado.DefaultView.Count > 0 Then
                        If dt_empleado.DefaultView(0)("Address1").ToString.Length > 0 Then

                            dr_aux.Item("UsuarioModif") = dt_empleado.DefaultView(0)("Address1").ToString.ToUpper ''En Address debe estar el Usuario Flex para que no todo venga con Admin
                        Else
                            dr_aux.Item("UsuarioModif") = "Admin"
                        End If
                    Else
                        dr_aux.Item("UsuarioModif") = "Admin"
                    End If

                    dr_aux.Item("Hora") = dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                                dt_gndSale.DefaultView(0).Item("Closemin")
                    dr_aux.Item("Caja") = ""
                    dr_aux.Item("Pago") = dr.Item("Total")
                    dr_aux.Item("IdApertura") = 0

                    dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                    dr_aux.Item("SubTotalBimoneda") = dr.Item("Total")
                    dr_aux.Item("TotalBimoneda") = dr.Item("Total")
                    dr_aux.Item("ParidadBimoneda") = 1


                    ods.Tables("documento").Rows.Add(dr_aux)


                    ''Detalle
                    dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                    icount = 0
                    For Each drv In dt_gndItem.DefaultView

                        dt_Itm.DefaultView.RowFilter = "Id = " & drv.Item("Item")
                        'dt_Itm.DefaultView.RowFilter = "bohname = '" & drv.Item("bohname").ToString & "'"
                        If Not dt_Itm.DefaultView(0).Item("Bohname").ToString.StartsWith("-----") Then


                            dt_gndVoid.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and Item = " & drv.Item("Item")
                            If drv.Item("Price") > 0 Then
                                'If dt_gndVoid.DefaultView.Count = 0 Then

                                icount += 1
                                dr_aux = ods.Tables("documentod").NewRow

                                dr_aux.Item("Empresa") = gs_empresa
                                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                                dr_aux.Item("Correlativo") = dr.Item("Counter")
                                dr_aux.Item("Secuencia") = icount
                                dr_aux.Item("Linea") = icount
                                dr_aux.Item("Producto") = dt_Itm.DefaultView(0).Item("Bohname")

                                dr_aux.Item("Cantidad") = drv.Item("Quantity")
                                dr_aux.Item("Precio") = dt_Itm.DefaultView(0).Item("Price") '--drv.Item("Price")
                                dr_aux.Item("PorcentajeDr") = 0
                                'dr_aux.Item("SubTotal") = dr_aux.Item("Price")
                                dr_aux.Item("SubTotal") = dr_aux.Item("Cantidad") * dr_aux.Item("Precio")
                                If dr_aux.Item("SubTotal") <> drv.Item("Price") Then
                                    If dr_aux.Item("producto") = "0400060481" Then
                                        dr_aux.Item("SubTotal") = drv.Item("Price")
                                        dr_aux.Item("precio") = dr_aux.Item("subtotal") / dr_aux.Item("cantidad")
                                    End If
                                End If
                                dr_aux.Item("Impuesto") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                                dr_aux.Item("Neto") = dr_aux.Item("SubTotal") - dr_aux.Item("Impuesto")
                                dr_aux.Item("DrGlobal") = 0

                                dr_aux.Item("Total") = dr_aux.Item("Neto")
                                dr_aux.Item("PrecioAjustado") = drv.Item("Price") - drv.Item("Incltax")
                                dr_aux.Item("UnidadIngreso") = "UN"
                                dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                                dr_aux.Item("PrecioIngreso") = drv.Item("Price")
                                dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                                dr_aux.Item("ImpuestoIngreso") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                                dr_aux.Item("DRGlobalIngreso") = 0
                                dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                                dr_aux.Item("CorrelativoOrigen") = 0
                                dr_aux.Item("SecuenciaOrigen") = 0
                                dr_aux.Item("Bodega") = "SV14"
                                dr_aux.Item("FactorInventario") = -1
                                dr_aux.Item("FechaEntrega") = dr.Item("DOB")
                                dr_aux.Item("CantidadAsignada") = 0
                                dr_aux.Item("Fecha") = dr.Item("DOB")
                                dr_aux.Item("Vigente") = "S"
                                dr_aux.Item("CUP") = 0
                                dr_aux.Item("Ubicacion") = "PRINCIPAL"
                                dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                                dr_aux.Item("FactorImpto") = 0.89285714
                                dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                                dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                                dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                                dr_aux.Item("DrGlobalBimoneda") = 0
                                dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")
                                dr_aux.Item("DoctoOrigenVal") = "N"


                                ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"
                                dt = Otrans.Obtiene(ls_sql)

                                Try
                                    dr_aux.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                                Catch ex As Exception
                                    dr_aux.Item("costo") = 0
                                End Try


                                ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                                        "','" & ls_listaprecios & "'"

                                dt = Otrans.Obtiene(ls_sql)
                                Try
                                    dr_aux.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                                    dr_aux.Item("PrecioListaP") = dt.Rows(0).Item("valor")
                                Catch ex As Exception
                                    dr_aux.Item("PrecioListaP") = 0
                                End Try



                                ods.Tables("documentod").Rows.Add(dr_aux)
                                'End If 'void
                            End If 'precio > 0

                        End If 'Bohname").ToString.StartsWith("-----")

                    Next


                    ''DocumentoP
                    dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11"
                    icount = 0
                    For Each drv In dt_gndtndr.DefaultView
                        icount += 1
                        dr_aux = ods.Tables("documentop").NewRow
                        dr_aux.Item("Empresa") = gs_empresa
                        dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                        dr_aux.Item("Correlativo") = dr.Item("Counter")
                        dr_aux.Item("Linea") = icount
                        If drv.Item("TypeId") = 1 Or drv.Item("TypeId") = 4 Then
                            ls_sql = "CONTADO,010101010700"
                        ElseIf drv.Item("TypeId") = 3 Then
                            ls_sql = "TC MASTERCARD,010101010300"
                        ElseIf drv.Item("TypeId") = 6 Then
                            ls_sql = "TC AMEX,010101010300"
                        ElseIf drv.Item("TypeId") = 7 Then
                            ls_sql = "TC DINERSCLUB,010101010300"
                        ElseIf drv.Item("TypeId") = 2 Then
                            ls_sql = "TC VISA NET,010101010300"
                        ElseIf drv.Item("TypeId") = 8 Then
                            ls_sql = "EXENCION IVA,010102040300"
                        End If

                        dr_aux.Item("CodigoPago") = ls_sql.Split(",")(0)
                        dr_aux.Item("TipoPago") = "T"
                        dr_aux.Item("FechaVcto") = dr.Item("DOB")
                        dr_aux.Item("Monto") = drv.Item("Amount")
                        dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                        dr_aux.Item("TipoDoctoPago") = dr_aux.Item("TipoDocto")
                        dr_aux.Item("NroDoctoPago") = dr.Item("Counter").ToString.PadLeft(10, "0")
                        dr_aux.Item("Cuenta") = ls_sql.Split(",")(1)
                        dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                        dr_aux.Item("AjusteBimoneda") = 0
                        dr_aux.Item("CuentaPago") = drv.Item("Ident")
                        dr_aux.Item("MonedaPago") = "QUETZALES"
                        dr_aux.Item("MontoPago") = dr_aux.Item("Monto")
                        dr_aux.Item("ParidadPago") = 1
                        ods.Tables("documentop").Rows.Add(dr_aux)

                    Next


                    ''Documentov

                    dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"

                    For icount = 1 To 5
                        dr_aux = ods.Tables("documentov").NewRow
                        dr_aux.Item("empresa") = gs_empresa
                        dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                        dr_aux.Item("Correlativo") = dr.Item("Counter")
                        If icount = 1 Then
                            dr_aux.Item("Nombre") = "DESC_LICORES"
                            dr_aux.Item("Orden") = 4
                            dr_aux.Item("Monto") = 0
                        ElseIf icount = 2 Then
                            dr_aux.Item("Nombre") = "DESCUENTO_L"
                            dr_aux.Item("Orden") = 13

                            ''Debo Agregar Descuento Globales
                            dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 3"
                            If dt_gndtndr.DefaultView.Count > 0 Then
                                dr_aux.Item("Monto") = dt_gndtndr.DefaultView(0).Item("Amount")
                            Else
                                dr_aux.Item("Monto") = 0
                            End If

                        ElseIf icount = 3 Then
                            dr_aux.Item("Nombre") = "IVA"
                            dr_aux.Item("Orden") = 21
                            dr_aux.Item("Porcentaje") = 12
                            dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        ElseIf icount = 4 Then
                            dr_aux.Item("Nombre") = "IVA_REAL"
                            dr_aux.Item("Orden") = 20
                            dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                            dr_aux.Item("Porcentaje") = 0
                        ElseIf icount = 5 Then
                            dr_aux.Item("Nombre") = "NETO"
                            dr_aux.Item("Orden") = 1
                            dr_aux.Item("Monto") = 0
                            dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                            For Each drva As DataRowView In dt_gndSale.DefaultView
                                dr_aux.Item("Monto") += drva.Item("Amount")
                            Next

                            dr_aux.Item("Porcentaje") = 0
                        End If
                        If icount < 3 Then
                            dr_aux.Item("Factor") = -1

                            dr_aux.Item("Porcentaje") = 0
                        Else
                            dr_aux.Item("Factor") = 0
                        End If



                        dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                        dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")

                        dr_aux.Item("Ajuste") = 0
                        dr_aux.Item("AjusteIngreso") = 0



                        ods.Tables("documentov").Rows.Add(dr_aux)

                    Next




                    If lagregar_Cliente Then

                        dt_clienteAccess.DefaultView.RowFilter = "CliNit = '" & dr.Item("CliNit").ToString & "'"
                        dr_aux = ods.Tables("ctacte").NewRow
                        If dt_clienteAccess.DefaultView.Count > 0 Then
                            dr_aux.Item("RazonSocial") = dt_clienteAccess.DefaultView(0).Item("CliName")
                            dr_aux.Item("Direccion") = dt_clienteAccess.DefaultView(0).Item("CliDireccion")
                        Else
                            Agregar_Log("Problemas con el Cliente " & dr.Item("CliNit").ToString, "Error")
                        End If


                        dr_aux.Item("Empresa") = gs_empresa
                        dr_aux.Item("TipoCtaCte") = "CLIENTE"
                        dr_aux.Item("CtaCte") = dr.Item("CliNit").ToString.Split("-")(0)
                        dr_aux.Item("CodLegal") = dr.Item("CliNit").ToString

                        dr_aux.Item("Tipo") = "ZONA 14"
                        dr_aux.Item("Grupo") = "VENTA DIRECTA"
                        dr_aux.Item("Ejecutivo") = "VENTA DIRECTA 14"
                        dr_aux.Item("CondPago") = "CONTADO"
                        dr_aux.Item("Vigencia") = "S"
                        dr_aux.Item("ListaPrecio") = ls_listaprecios

                        dr_aux.Item("Pais") = "GUATEMALA"
                        dr_aux.Item("LimiteCredito") = 1
                        dr_aux.Item("VigenciaCredito") = Today
                        dr_aux.Item("RetrasoCredito") = 1
                        dr_aux.Item("FechaModif") = Now
                        dr_aux.Item("UsuarioModif") = "Admin"
                        dr_aux.Item("PorcDr1") = 0
                        dr_aux.Item("PorcDr2") = 0
                        dr_aux.Item("PorcDr3") = 0
                        dr_aux.Item("PorcDr4") = 0
                        dr_aux.Item("Moneda") = "QUETZALES"
                        dr_aux.Item("EstaCertificado") = "N"

                        ods.Tables("ctacte").Rows.Add(dr_aux)


                        dr_aux = ods.Tables("ctacte_gentabcod").NewRow
                        dr_aux.Item("Empresa") = gs_empresa
                        dr_aux.Item("Tipo") = "CON_CLIENT"
                        dr_aux.Item("Codigo") = dr.Item("CliNit").ToString.Split("-")(0)
                        dr_aux.Item("NemoTecnico") = dr.Item("CliNit").ToString.Split("-")(0)
                        If dt_clienteAccess.DefaultView.Count > 0 Then
                            dr_aux.Item("Descripcion") = dt_clienteAccess.DefaultView(0).Item("CliName")
                        End If
                        dr_aux.Item("Texto1") = ""
                        dr_aux.Item("Vigencia") = "S"

                        ods.Tables("ctacte_gentabcod").Rows.Add(dr_aux)



                    End If
                    ''Validar Totales

                    dtotal_encabezado = Round(ods.Tables("documento").Compute("Sum(Total)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_detalle = Round(ods.Tables("documentod").Compute("Sum(SubTotal)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_pago = Round(ods.Tables("documentop").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                    dtotal_valores = Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter") & " And Orden < 21"), 2)

                    If Val(dtotal_encabezado - dtotal_detalle) > 0.1 Or Val(dtotal_encabezado - dtotal_pago) > 0.1 Or Val(dtotal_encabezado - dtotal_valores) > 0.1 Then
                        Agregar_Log("Problemas con los Totales " & dr.Item("Serie") & " " & dr.Item("Counter"), "Error")
                        lgenerar_error = True
                    End If

                    'Osinc.Enviar_Documento(gs_empresa, ods.Tables("documento").Rows(0), ods.Tables("documentod"), _
                    '                ods.Tables("documentov"), ods.Tables("documentop"), "", True)
                    'Exit For
                Next 'dr

            End If



        Catch ex As Exception
            lgenerar_error = True
        Finally
            Aotrans.Close()
            Aotrans = Nothing
            Otrans.close()
            Otrans = Nothing
            fOtrans = Nothing
            '  Me.dgv_documentos.DataSource = ods.Tables("documento")
            '   ClsGen.Alinear_GridView(ods.Tables("documento"), Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)
            '   ClsGen = Nothing
        End Try
        If Not lgenerar_error Then
            Me.btn_procesar.Visible = True

        End If

    End Sub

    Private Sub Generar_Informacion_Vinoteca_Aloha()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Aotrans As New Transaccional.Conexion_Access("Access", 16)
        Dim fOtrans As Transaccional.Conexion_Fox

        Dim ClsGen As New ClasesGenerales.General

        Dim ls_sql As String
        Dim dt, dt_cliente, dt_ventas, dt_clienteAccess As DataTable
        Dim dt_gndSale, dt_gndtndr, dt_gndItem, dt_Itm, dt_gndVoid, dt_empleado As DataTable
        Dim dt_tdr As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim icount As Integer = 0
        Dim lagregar_Cliente As Boolean = False
        Dim lgenerar_error As Boolean = False

        Dim ls_listaprecios As String = "FONTABELLA_1103A"

        If Me.dtp_fecha_inicio.Value < Date.Parse("01/03/2011") Then
            '            ls_listaprecios = "PREMIUM_1103A"
            ls_listaprecios = "FONTABELLA_0910"
        End If

        Dim dtotal_encabezado As Double = 0, dtotal_detalle As Double = 0, dtotal_pago As Double = 0, dtotal_valores As Double

        Try
            Crear_Estructura_Auxiliar()
            Aotrans.Open()
            If Aotrans.Codigo_error > 0 Then
                MessageBox.Show(Aotrans.descripcion_error)
                Exit Sub
            End If
            Otrans.open()
            Aotrans.Nombre_Tabla = "HInvoice"
            Aotrans.Condiciones = "DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_ventas = Aotrans.Obtiene()

            Aotrans.Lista_Campos = "Cliente.*"
            Aotrans.Nombre_Tabla = "CLIENTE, HINVOICE "
            Aotrans.Condiciones = "CLIENTE.CliNit = HINVOICE.CliNit and HINVOICE.DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            dt_clienteAccess = Aotrans.Obtiene


            fOtrans = New Transaccional.Conexion_Fox("Fox", 16)
            fOtrans.Fecha_Proceso = "NewData"
            fOtrans.Open()
            fOtrans.Nombre_Tabla = "Itm"
            dt_Itm = fOtrans.Obtiene()

            fOtrans.Nombre_Tabla = "emp"
            dt_empleado = fOtrans.Obtiene

            fOtrans = New Transaccional.Conexion_Fox("Fox", 16)
            fOtrans.Fecha_Proceso = Me.dtp_fecha_inicio.Value.ToString("yyyyMMdd")
            fOtrans.Open()
            fOtrans.Nombre_Tabla = "Gndtndr"
            dt_gndtndr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndSale"
            dt_gndSale = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "GndItem"
            dt_gndItem = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Tdr"
            dt_tdr = fOtrans.Obtiene
            fOtrans.Nombre_Tabla = "Gndvoid"
            dt_gndVoid = fOtrans.Obtiene



            For Each dr In dt_ventas.Rows
                dr_aux = ods.Tables("documento").NewRow
                If dr.Item("counter") = 12176 Then
                    dr.Item("counter") = 12176
                End If

                dr_aux.Item("empresa") = gs_empresa
                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                dr_aux.Item("Numero") = dr.Item("Counter").ToString.PadLeft(10, "0")
                dr_aux.Item("Correlativo") = dr.Item("Counter")
                dr_aux.Item("Fecha") = dr.Item("DOB")

                If dr.Item("CliNit").ToString = "-" Then
                    dr_aux.Item("Cliente") = "0000000001" 'dr.Item("")"
                Else
                    ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,NULL,'" & dr.Item("CliNit") & "'"
                    dt_cliente = Otrans.Obtiene(ls_sql)
                    If dt_cliente.Rows.Count > 0 Then
                        dr_aux.Item("Cliente") = dt_cliente.Rows(0).Item("CtaCte")
                    Else
                        ''Debo Crear El Cliente
                        dr_aux.Item("Cliente") = dr.Item("CliNit").ToString.Split("-")(0)
                        lagregar_Cliente = True
                    End If
                End If


                dr_aux.Item("Bodega") = "SVFB"
                dr_aux.Item("Vendedor") = "RESTAURANTE FB"

                dr_aux.Item("ListaPrecio") = ls_listaprecios
                dr_aux.Item("Moneda") = "QUETZALES"
                dr_aux.Item("Paridad") = 1

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                dr_aux.Item("Neto") = 0
                For Each drv4 As DataRowView In dt_gndSale.DefaultView
                    dr_aux.Item("Neto") = dr_aux.Item("Neto") + drv4.Item("Amount")
                Next
                'dr_aux.Item("Neto") = dt_gndSale.DefaultView(0).Item("Amount")

                dr_aux.Item("SubTotal") = dr.Item("Total")
                dr_aux.Item("Total") = dr.Item("Total")
                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalIngreso") = dr.Item("Total")
                dr_aux.Item("TotalIngreso") = dr.Item("Total")
                dr_aux.Item("Aprobacion") = "S"
                dr_aux.Item("PeriodoLibro") = Date.Parse(dr.Item("DOB").ToString).ToString("yyyyMM")
                dr_aux.Item("FactorMonto") = 1
                dr_aux.Item("FactorMontoProyectado") = 0
                dr_aux.Item("TipoCtaCte") = "CLIENTE"
                dr_aux.Item("glosa") = "Check " & dr.Item("CheckNumber").ToString
                dr_aux.Item("IdCtaCte") = dr_aux.Item("Cliente")
                dr_aux.Item("Vigencia") = IIf(dr.Item("Activo"), "S", "A")
                dr_aux.Item("Emitido") = "N"
                dr_aux.Item("PorcentajeAsignado") = 0
                dr_aux.Item("Adjuntos") = "N"
                dr_aux.Item("FechaModif") = dr.Item("DOB") & " " & _
                                            dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                            dt_gndSale.DefaultView(0).Item("Closemin")

                dr_aux.Item("FechaUModif") = dr_aux.Item("FechaModif")

                dt_empleado.DefaultView.RowFilter = "id = " & dt_gndItem.DefaultView(0).Item("employee")
                If dt_empleado.DefaultView.Count > 0 Then
                    If dt_empleado.DefaultView(0)("Address1").ToString.Length > 0 Then

                        dr_aux.Item("UsuarioModif") = dt_empleado.DefaultView(0)("Address1").ToString.ToUpper ''En Address debe estar el Usuario Flex para que no todo venga con Admin
                    Else
                        dr_aux.Item("UsuarioModif") = "Admin"
                    End If
                Else
                    dr_aux.Item("UsuarioModif") = "Admin"
                End If

                dr_aux.Item("Hora") = dt_gndSale.DefaultView(0).Item("Closehour") & ":" & _
                                            dt_gndSale.DefaultView(0).Item("Closemin")
                dr_aux.Item("Caja") = ""
                dr_aux.Item("Pago") = dr.Item("Total")
                dr_aux.Item("IdApertura") = 0

                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalBimoneda") = dr.Item("Total")
                dr_aux.Item("TotalBimoneda") = dr.Item("Total")
                dr_aux.Item("ParidadBimoneda") = 1


                ods.Tables("documento").Rows.Add(dr_aux)


                ''Detalle
                dt_gndItem.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber")
                icount = 0
                For Each drv In dt_gndItem.DefaultView

                    dt_Itm.DefaultView.RowFilter = "Id = " & drv.Item("Item")

                    If Not dt_Itm.DefaultView(0).Item("Bohname").ToString.StartsWith("-----") Then


                        dt_gndVoid.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and Item = " & drv.Item("Item")
                        If drv.Item("Price") > 0 Then
                            'If dt_gndVoid.DefaultView.Count = 0 Then

                            icount += 1
                            dr_aux = ods.Tables("documentod").NewRow

                            dr_aux.Item("Empresa") = gs_empresa
                            dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                            dr_aux.Item("Correlativo") = dr.Item("Counter")
                            dr_aux.Item("Secuencia") = icount
                            dr_aux.Item("Linea") = icount
                            dr_aux.Item("Producto") = dt_Itm.DefaultView(0).Item("Bohname")

                            dr_aux.Item("Cantidad") = drv.Item("Quantity")
                            dr_aux.Item("Precio") = drv.Item("Price")
                            dr_aux.Item("PorcentajeDr") = 0
                            dr_aux.Item("SubTotal") = dr_aux.Item("Cantidad") * dr_aux.Item("Precio")
                            dr_aux.Item("Impuesto") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                            dr_aux.Item("Neto") = dr_aux.Item("SubTotal") - dr_aux.Item("Impuesto")
                            dr_aux.Item("DrGlobal") = 0

                            dr_aux.Item("Total") = dr_aux.Item("Neto")
                            dr_aux.Item("PrecioAjustado") = drv.Item("Price") - drv.Item("Incltax")
                            dr_aux.Item("UnidadIngreso") = "UN"
                            dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                            dr_aux.Item("PrecioIngreso") = drv.Item("Price")
                            dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                            dr_aux.Item("ImpuestoIngreso") = drv.Item("Incltax") * dr_aux.Item("Cantidad")
                            dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                            dr_aux.Item("DRGlobalIngreso") = 0
                            dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                            dr_aux.Item("CorrelativoOrigen") = 0
                            dr_aux.Item("SecuenciaOrigen") = 0
                            dr_aux.Item("Bodega") = "SVFB"
                            dr_aux.Item("FactorInventario") = -1
                            dr_aux.Item("FechaEntrega") = dr.Item("DOB")
                            dr_aux.Item("CantidadAsignada") = 0
                            dr_aux.Item("Fecha") = dr.Item("DOB")
                            dr_aux.Item("Vigente") = "S"
                            dr_aux.Item("CUP") = 0
                            dr_aux.Item("Ubicacion") = "PRINCIPAL"
                            dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                            dr_aux.Item("FactorImpto") = 0.89285714
                            dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                            dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                            dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                            dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                            dr_aux.Item("DrGlobalBimoneda") = 0
                            dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")
                            dr_aux.Item("DoctoOrigenVal") = "N"


                            ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"
                            dt = Otrans.Obtiene(ls_sql)

                            Try
                                dr_aux.Item("costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                            Catch ex As Exception
                                dr_aux.Item("costo") = 0
                            End Try


                            ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                                    "','" & ls_listaprecios & "'"

                            dt = Otrans.Obtiene(ls_sql)
                            Try
                                dr_aux.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                                dr_aux.Item("PrecioListaP") = dt.Rows(0).Item("valor")
                            Catch ex As Exception
                                dr_aux.Item("PrecioListaP") = 0
                            End Try



                            ods.Tables("documentod").Rows.Add(dr_aux)
                            'End If 'void
                        End If 'precio > 0

                    End If 'Bohname").ToString.StartsWith("-----")

                Next


                ''DocumentoP
                dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11"
                icount = 0
                For Each drv In dt_gndtndr.DefaultView
                    icount += 1
                    dr_aux = ods.Tables("documentop").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    dr_aux.Item("Linea") = icount
                    If drv.Item("TypeId") = 1 Or drv.Item("TypeId") = 4 Then
                        ls_sql = "CONTADO,010101010700"
                    ElseIf drv.Item("TypeId") = 3 Then
                        ls_sql = "TC MASTERCARD,010101010300"
                    ElseIf drv.Item("TypeId") = 6 Then
                        ls_sql = "TC AMEX,010101010300"
                    ElseIf drv.Item("TypeId") = 7 Then
                        ls_sql = "TC DINERSCLUB,010101010300"
                    ElseIf drv.Item("TypeId") = 2 Then
                        ls_sql = "TC VISA NET,010101010300"
                    ElseIf drv.Item("TypeId") = 8 Then
                        ls_sql = "EXENCION IVA,010102040300"
                    End If

                    dr_aux.Item("CodigoPago") = ls_sql.Split(",")(0)
                    dr_aux.Item("TipoPago") = "T"
                    dr_aux.Item("FechaVcto") = dr.Item("DOB")
                    dr_aux.Item("Monto") = drv.Item("Amount")
                    dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                    dr_aux.Item("TipoDoctoPago") = dr_aux.Item("TipoDocto")
                    dr_aux.Item("NroDoctoPago") = dr.Item("Counter").ToString.PadLeft(10, "0")
                    dr_aux.Item("Cuenta") = ls_sql.Split(",")(1)
                    dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                    dr_aux.Item("AjusteBimoneda") = 0
                    dr_aux.Item("CuentaPago") = drv.Item("Ident")
                    dr_aux.Item("MonedaPago") = "QUETZALES"
                    dr_aux.Item("MontoPago") = dr_aux.Item("Monto")
                    dr_aux.Item("ParidadPago") = 1
                    ods.Tables("documentop").Rows.Add(dr_aux)

                Next


                ''Documentov

                dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"

                For icount = 1 To 5
                    dr_aux = ods.Tables("documentov").NewRow
                    dr_aux.Item("empresa") = gs_empresa
                    dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                    dr_aux.Item("Correlativo") = dr.Item("Counter")
                    If icount = 1 Then
                        dr_aux.Item("Nombre") = "DESC_LICORES"
                        dr_aux.Item("Orden") = 4
                        dr_aux.Item("Monto") = 0
                    ElseIf icount = 2 Then
                        dr_aux.Item("Nombre") = "DESCUENTO_L"
                        dr_aux.Item("Orden") = 13

                        ''Debo Agregar Descuento Globales
                        dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 3"
                        If dt_gndtndr.DefaultView.Count > 0 Then
                            dr_aux.Item("Monto") = dt_gndtndr.DefaultView(0).Item("Amount")
                        Else
                            dr_aux.Item("Monto") = 0
                        End If

                    ElseIf icount = 3 Then
                        dr_aux.Item("Nombre") = "IVA"
                        dr_aux.Item("Orden") = 21
                        dr_aux.Item("Porcentaje") = 12
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                        dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                    ElseIf icount = 4 Then
                        dr_aux.Item("Nombre") = "IVA_REAL"
                        dr_aux.Item("Orden") = 20
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                        dr_aux.Item("Monto") = dt_gndSale.DefaultView(0).Item("Amount")
                        dr_aux.Item("Porcentaje") = 0
                    ElseIf icount = 5 Then
                        dr_aux.Item("Nombre") = "NETO"
                        dr_aux.Item("Orden") = 1
                        dr_aux.Item("Monto") = 0
                        dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                        For Each drva As DataRowView In dt_gndSale.DefaultView
                            dr_aux.Item("Monto") += drva.Item("Amount")
                        Next

                        dr_aux.Item("Porcentaje") = 0
                    End If
                    If icount < 3 Then
                        dr_aux.Item("Factor") = -1

                        dr_aux.Item("Porcentaje") = 0
                    Else
                        dr_aux.Item("Factor") = 0
                    End If



                    dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                    dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")

                    dr_aux.Item("Ajuste") = 0
                    dr_aux.Item("AjusteIngreso") = 0



                    ods.Tables("documentov").Rows.Add(dr_aux)

                Next




                If lagregar_Cliente Then

                    dt_clienteAccess.DefaultView.RowFilter = "CliNit = '" & dr.Item("CliNit").ToString & "'"
                    dr_aux = ods.Tables("ctacte").NewRow
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("RazonSocial") = dt_clienteAccess.DefaultView(0).Item("CliName")
                        dr_aux.Item("Direccion") = dt_clienteAccess.DefaultView(0).Item("CliDireccion")
                    Else
                        Agregar_Log("Problemas con el Cliente " & dr.Item("CliNit").ToString, "Error")
                    End If


                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("TipoCtaCte") = "CLIENTE"
                    dr_aux.Item("CtaCte") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("CodLegal") = dr.Item("CliNit").ToString

                    dr_aux.Item("Tipo") = "FONTABELLA"
                    dr_aux.Item("Grupo") = "VENTA DIRECTA"
                    dr_aux.Item("Ejecutivo") = "RESTAURANTE FB"
                    dr_aux.Item("CondPago") = "CONTADO"
                    dr_aux.Item("Vigencia") = "S"
                    dr_aux.Item("ListaPrecio") = ls_listaprecios

                    dr_aux.Item("Pais") = "GUATEMALA"
                    dr_aux.Item("LimiteCredito") = 1
                    dr_aux.Item("VigenciaCredito") = Today
                    dr_aux.Item("RetrasoCredito") = 1
                    dr_aux.Item("FechaModif") = Now
                    dr_aux.Item("UsuarioModif") = "Admin"
                    dr_aux.Item("PorcDr1") = 0
                    dr_aux.Item("PorcDr2") = 0
                    dr_aux.Item("PorcDr3") = 0
                    dr_aux.Item("PorcDr4") = 0
                    dr_aux.Item("Moneda") = "QUETZALES"
                    dr_aux.Item("EstaCertificado") = "N"

                    ods.Tables("ctacte").Rows.Add(dr_aux)


                    dr_aux = ods.Tables("ctacte_gentabcod").NewRow
                    dr_aux.Item("Empresa") = gs_empresa
                    dr_aux.Item("Tipo") = "CON_CLIENT"
                    dr_aux.Item("Codigo") = dr.Item("CliNit").ToString.Split("-")(0)
                    dr_aux.Item("NemoTecnico") = dr.Item("CliNit").ToString.Split("-")(0)
                    If dt_clienteAccess.DefaultView.Count > 0 Then
                        dr_aux.Item("Descripcion") = dt_clienteAccess.DefaultView(0).Item("CliName")
                    End If
                    dr_aux.Item("Texto1") = ""
                    dr_aux.Item("Vigencia") = "S"

                    ods.Tables("ctacte_gentabcod").Rows.Add(dr_aux)



                End If
                ''Validar Totales

                dtotal_encabezado = Round(ods.Tables("documento").Compute("Sum(Total)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                dtotal_detalle = Round(ods.Tables("documentod").Compute("Sum(SubTotal)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                dtotal_pago = Round(ods.Tables("documentop").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter")), 2)
                dtotal_valores = Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("Counter") & " And Orden < 21"), 2)

                If dtotal_encabezado <> dtotal_detalle Or dtotal_encabezado <> dtotal_pago Or dtotal_encabezado <> dtotal_valores Then
                    Agregar_Log("Problemas con los Totales " & dr.Item("Serie") & " " & dr.Item("Counter"), "Error")
                    lgenerar_error = True
                End If

                'Osinc.Enviar_Documento(gs_empresa, ods.Tables("documento").Rows(0), ods.Tables("documentod"), _
                '                ods.Tables("documentov"), ods.Tables("documentop"), "", True)
                'Exit For
            Next 'dr




        Catch ex As Exception
            lgenerar_error = True
        Finally
            Aotrans.Close()
            Aotrans = Nothing
            Otrans.close()
            Otrans = Nothing
            fOtrans = Nothing
            Me.dgv_documentos.DataSource = ods.Tables("documento")
            ClsGen.Alinear_GridView(ods.Tables("documento"), Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)
            ClsGen = Nothing
        End Try
        If Not lgenerar_error Then
            Me.btn_procesar.Visible = True

        End If

    End Sub

    Private Sub Generar_Informacion_Vinoteca_Local()

        Dim dt, dt_cliente, dt_cliente_venta As DataTable
        Dim dt_encabezado, dt_detalle, dt_producto_barra, dt_producto, dt_pagos, dt_listaprecio As DataTable
        Dim icount As Integer = 0
        Dim nombre_bodega As String

        dt = ods.Tables("ubicaciones").Copy
        dt.DefaultView.RowFilter = "codigo_alterno = " & Me.cmb_ubicaciones.SelectedValue
        icount = dt.DefaultView(0)("cod_ubicacion")
        nombre_bodega = dt.DefaultView(0)("nombre_bodega")
        Dim ls_ejecutivo As String = dt.DefaultView(0)("ejecutivo_default")
        Dim ls_tipo As String = dt.DefaultView(0)("tipo_default")
        Dim ls_listaprecios As String = "DIRECTO_0609A"
        If Me.dtp_fecha_inicio.Value > Date.Parse("21/08/2011") Then
            ls_listaprecios = "DIRECTO_1109A"
        End If


        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim vOtrans As New Transaccional.Conexion("SQL", icount)
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String


        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim lagregar_Cliente As Boolean = False
        Dim lgenerar_error As Boolean = False

        Dim dtotal_encabezado As Double = 0, dtotal_detalle As Double = 0, dtotal_pago As Double = 0, dtotal_valores As Double


        Try
            If ods.Tables("Log").Rows.Count > 0 Then
                If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ods.Tables("Log").Rows.Clear()
                End If
            End If


            Crear_Estructura_Auxiliar()
            'Aotrans.Open()
            vOtrans.open()
            Otrans.open()
            'Aotrans.Nombre_Tabla = "HInvoice"
            'Aotrans.Condiciones = "DOB = #" & Me.dtp_fecha_inicio.Value.ToString("MM-dd-yyyy") & "#"
            ls_sql = "pa_var_um_SSO_FFAC '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            '            dt_ventas = Aotrans.Obtiene()
            dt_encabezado = vOtrans.Obtiene(ls_sql)
            If vOtrans.Codigo_error > 0 Then
                Me.Agregar_Log(vOtrans.descripcion_error, "Error")
            End If

            ls_sql = "pa_var_um_SSO_BF '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt_cliente_venta = vOtrans.Obtiene(ls_sql)
            If vOtrans.Codigo_error > 0 Then
                Me.Agregar_Log(vOtrans.descripcion_error, "Error")
            End If


            ls_sql = "pa_var_um_SSO_FFDE '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt_detalle = vOtrans.Obtiene(ls_sql)
            If vOtrans.Codigo_error > 0 Then
                Me.Agregar_Log(vOtrans.descripcion_error, "Error")
            End If

            ls_sql = "pa_var_um_SSO_FPFAMA '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt_pagos = vOtrans.Obtiene(ls_sql)
            If vOtrans.Codigo_error > 0 Then
                Me.Agregar_Log(vOtrans.descripcion_error, "Error")
            End If


            ''Maestros de Flex
            ls_sql = "pa_sel_um_prodcodbarra '" & gs_empresa & "',null,1"
            dt_producto_barra = Otrans.Obtiene(ls_sql)
            If Otrans.Codigo_error > 0 Then
                Me.Agregar_Log(Otrans.descripcion_error, "Error")
            End If

            ls_sql = "pa_sel_um_producto '" & gs_empresa & "',null"
            dt_producto = Otrans.Obtiene(ls_sql)
            If Otrans.Codigo_error > 0 Then
                Me.Agregar_Log(Otrans.descripcion_error, "Error")
            End If

            ls_sql = "pa_var_um_listaprecioD '" & gs_empresa & "',null,'" & ls_listaprecios & "'"
            dt_listaprecio = Otrans.Obtiene(ls_sql)
            If Otrans.Codigo_error > 0 Then
                Me.Agregar_Log(Otrans.descripcion_error, "Error")
            End If

            For Each dr In dt_encabezado.Rows
                dr_aux = ods.Tables("documento").NewRow
                'If dr.Item("NoDocumento") = 9747 Then
                '    dr.Item("NoDocumento") = 9747
                'End If
                dr_aux.Item("empresa") = gs_empresa
                dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                dr_aux.Item("Numero") = dr.Item("NoDocumento").ToString.PadLeft(10, "0")
                dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
                dr_aux.Item("Fecha") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")

                If dr.Item("FacturaNit").ToString.ToLower.StartsWith("c") Then
                    dr_aux.Item("Cliente") = "0000000001" 'dr.Item("")"
                Else
                    ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,NULL,'" & dr.Item("FacturaNit") & "'"
                    dt_cliente = Otrans.Obtiene(ls_sql)
                    If dt_cliente.Rows.Count > 0 Then
                        dr_aux.Item("Cliente") = dt_cliente.Rows(0).Item("CtaCte")
                    Else
                        ''Debo Crear El Cliente
                        dr_aux.Item("Cliente") = dr.Item("FacturaNit").ToString.Split("-")(0)
                        lagregar_Cliente = True
                    End If
                End If


                dr_aux.Item("Bodega") = nombre_bodega
                dr_aux.Item("Vendedor") = ls_ejecutivo

                dr_aux.Item("ListaPrecio") = ls_listaprecios
                dr_aux.Item("Moneda") = "QUETZALES"
                dr_aux.Item("Paridad") = 1

                ' dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                'dt_gndSale.DefaultView(0).Item("Amount")
                dr_aux.Item("Neto") = Round(dr.Item("ValorTotal") - dr.Item("ValorImpuesto"), 2)


                dr_aux.Item("SubTotal") = Round(dr.Item("ValorTotal"), 2)
                dr_aux.Item("Total") = Round(dr.Item("ValorTotal"), 2)
                dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalIngreso") = Round(dr.Item("ValorTotal"), 2)
                dr_aux.Item("TotalIngreso") = Round(dr.Item("ValorTotal"), 2)
                dr_aux.Item("Aprobacion") = "S"
                dr_aux.Item("PeriodoLibro") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("yyyyMM")
                dr_aux.Item("FactorMonto") = 1
                dr_aux.Item("FactorMontoProyectado") = 0
                dr_aux.Item("TipoCtaCte") = "CLIENTE"
                'dr_aux.Item("glosa") = "Check " & dr.Item("CheckNumber").ToString
                dr_aux.Item("IdCtaCte") = dr_aux.Item("Cliente")
                dr_aux.Item("Vigencia") = IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
                dr_aux.Item("Emitido") = "N"
                dr_aux.Item("PorcentajeAsignado") = 0
                dr_aux.Item("Adjuntos") = "N"
                dr_aux.Item("FechaModif") = dr.Item("FechaIngreso")

                dr_aux.Item("FechaUModif") = dr_aux.Item("FechaModif")
                dr_aux.Item("UsuarioModif") = dr.Item("UsuarioIngreso")
                dr_aux.Item("Hora") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("HH:mm")

                dr_aux.Item("Caja") = dr.Item("U_SSOCAJA")
                dr_aux.Item("Pago") = dr_aux.Item("Total")
                dr_aux.Item("IdApertura") = dr.Item("U_SSOSESION")

                dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("Total")
                dr_aux.Item("TotalBimoneda") = dr_aux.Item("Total")

                dr_aux.Item("ParidadBimoneda") = 1


                ods.Tables("documento").Rows.Add(dr_aux)


                ''Detalle
                Try
                    dt_detalle.DefaultView.RowFilter = "Numero = " & dr.Item("Numero")
                    icount = 0
                    For Each drv In dt_detalle.DefaultView



                        dt_producto_barra.DefaultView.RowFilter = "codbarra = '" & drv.Item("CodArticulo").ToString & "'"
                        If dt_producto_barra.DefaultView.Count > 0 Then

                            icount += 1
                            dr_aux = ods.Tables("documentod").NewRow

                            dr_aux.Item("Empresa") = gs_empresa
                            dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                            dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
                            dr_aux.Item("Secuencia") = icount
                            dr_aux.Item("Linea") = icount
                            dr_aux.Item("Producto") = dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")

                            dr_aux.Item("Cantidad") = drv.Item("Cantidad")
                            dr_aux.Item("Precio") = Round(drv.Item("ValorUnitario") + drv.Item("ValorDescuento"), 2)
                            'If drv.Item("ValorDescuento") > 0 Then
                            '    MessageBox.Show("Descuento")
                            'End If
                            dr_aux.Item("PorcentajeDr") = Round(drv.Item("PorcDescuento"), 0) * -1
                            dr_aux.Item("SubTotal") = drv.Item("ValorLinea")
                            dr_aux.Item("Impuesto") = Round(drv.Item("ValorImpuesto"), 2)
                            dr_aux.Item("Neto") = Round(drv.Item("ValorLinea") - drv.Item("ValorImpuesto"), 2)
                            dr_aux.Item("DrGlobal") = 0

                            dr_aux.Item("Total") = dr_aux.Item("Neto")
                            dr_aux.Item("PrecioAjustado") = Round(drv.Item("valorunitario") / (1 + dr.Item("PORCIMPUESTO")), 2)   'drv.Item("Price") - drv.Item("Incltax")
                            dr_aux.Item("UnidadIngreso") = "UN"
                            dr_aux.Item("CantidadIngreso") = dr_aux.Item("Cantidad")
                            dr_aux.Item("PrecioIngreso") = dr_aux.Item("Precio")
                            dr_aux.Item("SubTotalIngreso") = dr_aux.Item("SubTotal")
                            dr_aux.Item("ImpuestoIngreso") = Round(drv.Item("ValorImpuesto"), 2)
                            dr_aux.Item("NetoIngreso") = dr_aux.Item("Neto")
                            dr_aux.Item("DRGlobalIngreso") = 0
                            dr_aux.Item("TotalIngreso") = dr_aux.Item("Neto")
                            dr_aux.Item("CorrelativoOrigen") = 0
                            dr_aux.Item("SecuenciaOrigen") = 0
                            dr_aux.Item("Bodega") = drv.Item("U_SSOCOD")
                            dr_aux.Item("FactorInventario") = -1
                            dr_aux.Item("FechaEntrega") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                            dr_aux.Item("CantidadAsignada") = 0
                            dr_aux.Item("Fecha") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                            dr_aux.Item("Vigente") = IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
                            dr_aux.Item("CUP") = 0
                            dr_aux.Item("Ubicacion") = "PRINCIPAL"
                            dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                            dr_aux.Item("FactorImpto") = 1 / (1 + dr.Item("PORCIMPUESTO")) '0.89285714
                            dr_aux.Item("PrecioBimoneda") = dr_aux.Item("Precio")
                            dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("SubTotal")
                            dr_aux.Item("ImpuestoBimoneda") = dr_aux.Item("Impuesto")
                            dr_aux.Item("NetoBimoneda") = dr_aux.Item("Neto")
                            dr_aux.Item("DrGlobalBimoneda") = 0
                            dr_aux.Item("TotalBimoneda") = dr_aux.Item("Neto")

                            dr_aux.Item("DoctoOrigenVal") = "N"


                            'ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr_aux.Item("producto") & "'"
                            'dt = Otrans.Obtiene(ls_sql)

                            Try
                                dt_producto.DefaultView.RowFilter = "producto = '" & dr_aux.Item("producto") & "'"
                                If dt_producto.DefaultView.Count > 0 Then
                                    dr_aux.Item("costo") = Double.Parse(dt_producto.DefaultView(0).Item("costo").ToString)
                                Else
                                    dr_aux.Item("costo") = 0
                                End If

                            Catch ex As Exception
                                dr_aux.Item("costo") = 0
                            End Try


                            'ls_sql = "pa_sel_um_listaprecioD '" & gs_empresa & "','" & dr_aux.Item("producto") & _
                            '        "','" & ls_listaprecios & "'"

                            'dt = Otrans.Obtiene(ls_sql)
                            Try

                                dt_listaprecio.DefaultView.RowFilter = "producto = '" & dr_aux.Item("producto") & "'"
                                If dt_listaprecio.DefaultView.Count > 0 Then
                                    dr_aux.Item("FechaVigenciaLp") = dt_listaprecio.DefaultView(0).Item("fec_inicio").ToString
                                    dr_aux.Item("PrecioListaP") = dt_listaprecio.DefaultView(0).Item("valor")
                                Else
                                    dr_aux.Item("PrecioListaP") = 0
                                End If
                            Catch ex As Exception
                                dr_aux.Item("PrecioListaP") = 0
                            End Try


                            dr_aux.Item("ValPorcentajeDr1") = (dr_aux.Item("Cantidad") * drv.Item("ValorDescuento")) * -1
                            dr_aux.Item("ValPorcentajeDr1Ingreso") = dr_aux.Item("ValPorcentajeDr1")
                            dr_aux.Item("ValPorcentajeDr1Bimoneda") = dr_aux.Item("ValPorcentajeDr1")

                            ods.Tables("documentod").Rows.Add(dr_aux)

                        Else
                            Me.Agregar_Log(drv.Item("CodArticulo").ToString & "-" & drv.Item("Descripcion1").ToString & " No Existe Equivalente Factura " & dr.Item("NoDocumento"), "Error")
                            lgenerar_error = True
                        End If
                    Next
                Catch ex As Exception
                    Agregar_Log("Productos " & dr.Item("Numero") & " " & ex.Message, "Error")
                    lgenerar_error = True
                End Try




                ''DocumentoP
                Try
                    dt_pagos.DefaultView.RowFilter = "U_SSONoFact = " & dr.Item("Numero")
                    icount = 0
                    Dim vuelto_utilizado As Double = 0

                    For Each drv In dt_pagos.DefaultView
                        icount += 1

                        dr_aux = ods.Tables("documentop").NewRow
                        dr_aux.Item("Empresa") = gs_empresa
                        dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                        dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
                        'If dr.Item("NoDocumento") = 5888 Then
                        '    MessageBox.Show("")
                        'End If
                        dr_aux.Item("Linea") = icount
                        If (drv.Item("u_ssocodfp") = 1 And (drv.Item("u_ssocodemisor") = 11 Or drv.Item("u_ssocodemisor") = 12)) Or _
                             drv.Item("u_ssocodfp") = 5 Or drv.Item("u_ssocodfp") = 6 Or drv.Item("u_ssocodfp") = 7 Then
                            ls_sql = "CONTADO,010101010700"
                            'ElseIf drv.Item("TypeId") = 3 Then
                            '    ls_sql = "TC MASTERCARD,010101010300"
                            'ElseIf drv.Item("TypeId") = 6 Then
                            '    ls_sql = "TC AMEX,010101010300"
                            'ElseIf drv.Item("TypeId") = 7 Then
                            '    ls_sql = "TC DINERSCLUB,010101010300"
                            If vuelto_utilizado > 0 Then
                                drv.Item("vuelto") = 0
                            Else
                                vuelto_utilizado = drv.Item("vuelto")
                            End If
                        ElseIf drv.Item("u_ssocodfp") = 2 And drv.Item("u_ssocodemisor") = 14 Then
                            ls_sql = "TC VISA NET,010101010300"
                        ElseIf drv.Item("u_ssocodfp") = 2 And drv.Item("u_ssocodemisor") = 13 Then
                            ls_sql = "TC CREDOMATIC,010101010300"
                        ElseIf drv.Item("u_ssocodfp") = 9 Then
                            ls_sql = "EXENCION IVA,010102040300"
                        ElseIf drv.Item("u_ssocodfp") = 4 Or drv.Item("u_ssocodfp") = 8 Then
                            ls_sql = "CHEQUES,010101010700"
                        End If

                        dr_aux.Item("CodigoPago") = ls_sql.Split(",")(0)
                        dr_aux.Item("TipoPago") = "T"
                        dr_aux.Item("FechaVcto") = Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")

                        dr_aux.Item("Monto") = Round(drv.Item("u_ssovaloraplicado") - IIf(dr_aux.Item("CodigoPago").ToString = "CONTADO", drv.Item("Vuelto"), 0), 2)
                        dr_aux.Item("MontoIngreso") = dr_aux.Item("Monto")
                        dr_aux.Item("TipoDoctoPago") = dr_aux.Item("TipoDocto")
                        dr_aux.Item("NroDoctoPago") = dr.Item("NoDocumento").ToString.PadLeft(10, "0")
                        dr_aux.Item("Cuenta") = ls_sql.Split(",")(1)
                        dr_aux.Item("MontoBimoneda") = dr_aux.Item("Monto")
                        dr_aux.Item("AjusteBimoneda") = 0
                        dr_aux.Item("CuentaPago") = "NULL"
                        dr_aux.Item("MonedaPago") = "QUETZALES"
                        dr_aux.Item("MontoPago") = dr_aux.Item("Monto")
                        dr_aux.Item("ParidadPago") = 1
                        ods.Tables("documentop").Rows.Add(dr_aux)

                    Next
                Catch ex As Exception
                    Agregar_Log("Documento P " & ex.Message, "Error")
                    lgenerar_error = True
                End Try
                'dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 11"



                ''Documentov

                '  dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                Try
                    For icount = 1 To 5
                        dr_aux = ods.Tables("documentov").NewRow
                        dr_aux.Item("empresa") = gs_empresa
                        dr_aux.Item("TipoDocto") = "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper
                        dr_aux.Item("Correlativo") = dr.Item("NoDocumento")
                        If icount = 1 Then
                            dr_aux.Item("Nombre") = "DESC_LICORES"
                            dr_aux.Item("Orden") = 4
                            dr_aux.Item("Monto") = 0
                        ElseIf icount = 2 Then
                            dr_aux.Item("Nombre") = "DESCUENTO_L"
                            dr_aux.Item("Orden") = 13

                            ''Debo Agregar Descuento Globales
                            'dt_gndtndr.DefaultView.RowFilter = "Check = " & dr.Item("CheckNumber") & " and Type = 3"
                            'If dt_gndtndr.DefaultView.Count > 0 Then
                            'dr_aux.Item("Monto") = dt_gndtndr.DefaultView(0).Item("Amount")
                            'Else
                            dr_aux.Item("Monto") = 0
                            'End If

                        ElseIf icount = 3 Then
                            dr_aux.Item("Nombre") = "IVA"
                            dr_aux.Item("Orden") = 21
                            dr_aux.Item("Porcentaje") = dr.Item("PORCIMPUESTO") * 100
                            'dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = Round(dr.Item("ValorImpuesto"), 4) 'dt_gndSale.DefaultView(0).Item("Amount")
                        ElseIf icount = 4 Then
                            dr_aux.Item("Nombre") = "IVA_REAL"
                            dr_aux.Item("Orden") = 20
                            ' dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 33"
                            dr_aux.Item("Monto") = Round(dr.Item("ValorImpuesto"), 4)  'dt_gndSale.DefaultView(0).Item("Amount")
                            dr_aux.Item("Porcentaje") = 0
                        ElseIf icount = 5 Then
                            dr_aux.Item("Nombre") = "NETO"
                            dr_aux.Item("Orden") = 1
                            ' dt_gndSale.DefaultView.RowFilter = "check = " & dr.Item("CheckNumber") & " and type = 31"
                            dr_aux.Item("Monto") = Round(dr.Item("ValorTotal") - dr.Item("ValorImpuesto"), 2) 'dt_gndSale.DefaultView(0).Item("Amount")
                            dr_aux.Item("Porcentaje") = 0
                        End If
                        If icount < 3 Then
                            dr_aux.Item("Factor") = -1

                            dr_aux.Item("Porcentaje") = 0
                        Else
                            dr_aux.Item("Factor") = 0
                        End If



                        dr_aux.Item("MontoIngreso") = Round(dr_aux.Item("Monto"), 2)
                        dr_aux.Item("MontoBimoneda") = Round(dr_aux.Item("Monto"), 2)

                        dr_aux.Item("Ajuste") = 0
                        dr_aux.Item("AjusteIngreso") = 0



                        ods.Tables("documentov").Rows.Add(dr_aux)

                    Next
                Catch ex As Exception
                    Agregar_Log("Documentov " & ex.Message, "Error")
                    lgenerar_error = True
                End Try




                Try
                    If lagregar_Cliente Then
                        dt_cliente_venta.DefaultView.RowFilter = "U_SSONit = '" & dr.Item("FacturaNit").ToString & "'"
                        If dt_cliente_venta.DefaultView.Count > 0 Then


                            dr_aux = ods.Tables("ctacte").NewRow
                            dr_aux.Item("Empresa") = gs_empresa
                            dr_aux.Item("TipoCtaCte") = "CLIENTE"
                            dr_aux.Item("CtaCte") = dr.Item("FacturaNit").ToString.Split("-")(0)
                            dr_aux.Item("CodLegal") = dr.Item("FacturaNit").ToString
                            dr_aux.Item("RazonSocial") = dt_cliente_venta.DefaultView(0).Item("U_SSONombre").ToString
                            dr_aux.Item("Telefono") = dt_cliente_venta.DefaultView(0).Item("U_SSOTelefono").ToString
                            dr_aux.Item("Tipo") = ls_tipo
                            dr_aux.Item("Grupo") = "VENTA DIRECTA"
                            dr_aux.Item("Ejecutivo") = ls_ejecutivo
                            dr_aux.Item("CondPago") = "CONTADO"
                            dr_aux.Item("Vigencia") = "S"
                            dr_aux.Item("ListaPrecio") = ls_listaprecios
                            dr_aux.Item("Direccion") = dt_cliente_venta.DefaultView(0).Item("U_SSODireccion").ToString
                            dr_aux.Item("Pais") = "GUATEMALA"
                            dr_aux.Item("LimiteCredito") = 1
                            dr_aux.Item("VigenciaCredito") = Today
                            dr_aux.Item("RetrasoCredito") = 1
                            dr_aux.Item("FechaModif") = Now
                            dr_aux.Item("UsuarioModif") = dt_cliente_venta.DefaultView(0).Item("U_SSOUsuaIngreso").ToString
                            dr_aux.Item("PorcDr1") = 0
                            dr_aux.Item("PorcDr2") = 0
                            dr_aux.Item("PorcDr3") = 0
                            dr_aux.Item("PorcDr4") = 0
                            dr_aux.Item("Moneda") = "QUETZALES"
                            dr_aux.Item("EstaCertificado") = "N"

                            ods.Tables("ctacte").Rows.Add(dr_aux)


                            dr_aux = ods.Tables("ctacte_gentabcod").NewRow
                            dr_aux.Item("Empresa") = gs_empresa
                            dr_aux.Item("Tipo") = "CON_CLIENT"
                            dr_aux.Item("Codigo") = dr.Item("FacturaNit").ToString.Split("-")(0)
                            dr_aux.Item("NemoTecnico") = dr.Item("FacturaNit").ToString.Split("-")(0)
                            dr_aux.Item("Descripcion") = dt_cliente_venta.DefaultView(0).Item("U_SSONombre")
                            dr_aux.Item("Texto1") = ""
                            dr_aux.Item("Vigencia") = "S"

                            ods.Tables("ctacte_gentabcod").Rows.Add(dr_aux)
                        End If


                    End If

                Catch ex As Exception
                    Agregar_Log("Agregar Clientes " & ex.Message, "Error")
                    lgenerar_error = True
                End Try

                ''Validar Totales
                dtotal_encabezado = Round(ods.Tables("documento").Compute("Sum(Total)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("NoDocumento")), 2)
                dtotal_detalle = Round(ods.Tables("documentod").Compute("Sum(SubTotal)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("NoDocumento")), 2)
                dtotal_pago = Round(ods.Tables("documentop").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("NoDocumento")), 2)
                dtotal_valores = Round(ods.Tables("documentov").Compute("Sum(Monto)", "tipodocto = '" & "FACTURA SERIE " & dr.Item("Serie").ToString.ToUpper & "' and correlativo = " & dr.Item("NoDocumento") & " And Orden < 21"), 2)

                
                'If dtotal_encabezado <> dtotal_detalle Or dtotal_encabezado <> dtotal_pago Or dtotal_encabezado <> dtotal_valores Then
                If Abs(dtotal_encabezado + (dtotal_detalle * -1) + dtotal_pago + (dtotal_valores * -1)) > 0.1 Then
                    Agregar_Log("Problemas con los Totales " & dr.Item("Serie") & " " & dr.Item("NoDocumento"), "Error")
                End If


                'Osinc.Enviar_Documento(gs_empresa, ods.Tables("documento").Rows(0), ods.Tables("documentod"), _
                '                ods.Tables("documentov"), ods.Tables("documentop"), "", True)
                'Exit For
            Next 'dr

            Agregar_Log(ods.Tables("documento").Rows.Count.ToString & " Documentos Listos Para Procesar", "Ok")



        Catch ex As Exception
            Agregar_Log(ex.Message, "Error")
            lgenerar_error = True
        Finally
            Otrans.close()
            Otrans = Nothing
            vOtrans.close()
            vOtrans = Nothing
            Me.dgv_documentos.DataSource = ods.Tables("documento")
            ClsGen.Alinear_GridView(ods.Tables("documento"), Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)
            ClsGen = Nothing
        End Try

        If Not lgenerar_error Then
            Me.btn_procesar.Visible = True

        End If
    End Sub

    Private Sub Generar_Informacion_Vinoteca()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("VinotecaTransFer")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim cm As CurrencyManager
        Dim ldoctosfacturas As Boolean = False

        Try
            Otrans.open()
            If ods.Tables("Log").Rows.Count > 0 Then
                If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ods.Tables("Log").Rows.Clear()
                End If
            End If

            Me.Agregar_Log("Inicia Proceso", "Ok")
            ls_sql = "SSO_TRA_VENTASFLEXTIENDA " & Me.cmb_ubicaciones.SelectedValue.ToString & ",'" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & " 00:00','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & " 23:59','V'"
            Otrans.Actualiza(ls_sql)
            'Me.Agregar_Log(Otrans.descripcion_error, "Error")

            ls_sql = "SSO_TRA_REVISAPROBLEMADOCSFLEX '', INT_FLEXLINE_POS,'" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & " 23:59'"
            dt = Otrans.Obtiene(ls_sql)
            If dt Is Nothing Then
                'Me.Agregar_Log("Proceso Correcto", "Ok")
            Else
                For Each dr In dt.Rows
                    If dr.Item("TipoDocto").ToString.ToLower.IndexOf("tura serie") > 0 Then
                        ldoctosfacturas = True
                        Exit For
                    End If
                Next
            End If
            If ldoctosfacturas Then
                Me.dgv_documentos.DataSource = dt
                Me.btn_procesar.Visible = False
            Else
                Me.Agregar_Log("Proceso Correcto", "Ok")
                Me.btn_procesar.Visible = True
            End If

            Leer_Archivos_Mensajes()
            cm = CType(Me.BindingContext(Me.dgv_log.DataSource), CurrencyManager)
            cm.Position = cm.Count - 1
            ClsGen.Eliminar_Archivo("c:\aplicaciones\mensajes.txt")


            '            If dt Is Nothing Then
            If Not ldoctosfacturas Then


                Generar_informacion_Vinoteca_Onbase()
            End If

        Catch ex As Exception
        Finally

            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Generar_informacion_Vinoteca_Onbase()
        Dim Otrans As Transaccional.Conexion
        Dim ClsGen As New ClasesGenerales.General

        Dim dt As DataTable
        Dim ls_sql, ls_ubicacion As String



        Try


            dt = ods.Tables("ubicaciones")
            dt.DefaultView.RowFilter = "codigo_alterno = " & Me.cmb_ubicaciones.SelectedValue.ToString
            ls_ubicacion = dt.DefaultView(0).Item("nombre_bodega").ToString
            'abro la conexion al nuevo servidor
            Otrans = New Transaccional.Conexion("VinotecaOnbase")

            Otrans.open()

            ls_sql = "Int_Flexline_POS..pa_var_um_documento_traslado_fecha  '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        ls_ubicacion & "'"


            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documento"
            If ods.Tables.Contains("documento") Then
                ods.Tables.Remove("documento")
            End If
            ods.Tables.Add(dt.Copy)

            Me.dgv_documentos.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)



            ''documentod
            ls_sql = "Int_Flexline_POS..pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        ls_ubicacion & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If ods.Tables.Contains("documentod") Then
                ods.Tables.Remove("documentod")
            End If
            ods.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "Int_Flexline_POS..pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                         Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        ls_ubicacion & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If ods.Tables.Contains("documentov") Then
                ods.Tables.Remove("documentov")
            End If
            ods.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "Int_Flexline_POS..pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        ls_ubicacion & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If ods.Tables.Contains("documentop") Then
                ods.Tables.Remove("documentop")
            End If
            ods.Tables.Add(dt.Copy)

            ''Clientes
            ls_sql = "Int_Flexline_POS..pa_var_um_ctacte_traslado_fecha '" & gs_empresa & "',null,'" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & _
                        Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte"
            If ods.Tables.Contains("ctacte") Then
                ods.Tables.Remove("ctacte")
            End If
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "Int_Flexline_POS..pa_var_um_ctacteDirecciones_traslado_fecha '" & gs_empresa & "',null,'" & _
            Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_direcciones"
            If ods.Tables.Contains("ctacte_direcciones") Then
                ods.Tables.Remove("ctacte_direcciones")
            End If
            ods.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "Int_Flexline_POS..pa_var_um_ctacteGenTabCod_traslado_fecha '" & gs_empresa & "',null,'" & _
            Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_gentabcod"
            If ods.Tables.Contains("ctacte_gentabcod") Then
                ods.Tables.Remove("ctacte_gentabcod")
            End If
            ods.Tables.Add(dt.Copy)

            'If ods.Tables("Log").Rows.Count > 0 Then
            '    If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        ods.Tables("Log").Rows.Clear()
            '    End If
            'End If

            Agregar_Log(ods.Tables("documento").Rows.Count.ToString & " Documentos Listos Para Procesar", "Ok")


            dt.Columns.Add(New DataColumn("Hora", GetType(DateTime)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(String)))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Procesar_Informacion()

        Dim Osinc As New Sincronizacion.Documentos("")
        Dim OSinc_Clientes As New Sincronizacion.Clientes("")
        Dim dr As DataRow
        Dim dt, dt2 As DataTable
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        Dim cm As CurrencyManager

        Dim Otrans As Transaccional.Conexion

        Dim ls_sql As String
        Dim lgenerar_error As Boolean = False

        Try

            'abro la conexion al nuevo servidor
            If gs_empresa <> "VINOTECA" Then
                dt2 = ods.Tables("ubicaciones")
                dt2.DefaultView.RowFilter = "cod_ubicacion = " & Me.cmb_ubicaciones.SelectedValue.ToString

                Otrans = New Transaccional.Conexion("FlexLine" & dt2.DefaultView(0).Item("nombre_bodega"))
                Otrans.open()

            End If


        Catch ex As Exception

        End Try

        Try

            For Each dr In ods.Tables("documento").Rows
                HuboError = False

                ods.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                ods.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                ods.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString

                'If Not dr.Item("tipodocto").ToString.ToLower.StartsWith("factura serie") Then
                Osinc.Enviar_Documento(gs_empresa, dr, ods.Tables("documentod").DefaultView.ToTable, ods.Tables("documentov").DefaultView.ToTable, ods.Tables("documentop").DefaultView.ToTable, "", True)
                '-End If


                If Osinc.codigo_error > 0 Then
                    HuboError = True
                    ndoctoserror += 1
                Else
                    If gs_empresa <> "VINOTECA" Then
                        ls_sql = "pa_upd_um_documento_cerrado '" & gs_empresa & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero") & "','" & gs_usuario & "'"
                        Otrans.Actualiza(ls_sql)
                    End If
                End If

                Agregar_Log(dr.Item("tipodocto").ToString & " " & dr.Item("numero") & IIf(HuboError, Osinc.descripcion_error, ""), _
                                    IIf(HuboError, "Error", "Ok"))

                ' End If
            Next

            For Each dr In ods.Tables("ctacte").Rows

                OSinc_Clientes.Obtener_Cliente(dr.Item("empresa"), dr.Item("ctacte"))
                If dr.Item("ctacte") = "121" Then
                    dr.Item("ctacte") = "121"
                End If
                If OSinc_Clientes.codigo_error = 0 Then

                    dt = OSinc_Clientes.dt

                    If dt.Rows.Count = 0 Then
                        ods.Tables("ctacte_direcciones").DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte").ToString & "'"
                        ods.Tables("ctacte_gentabcod").DefaultView.RowFilter = "codigo = '" & dr.Item("ctacte").ToString & "'"
                        OSinc_Clientes.Inserta_Clientes_Nuevos(dr, ods.Tables("ctacte_direcciones").DefaultView.ToTable, _
                                                            ods.Tables("ctacte_gentabcod").DefaultView.ToTable)
                        If Osinc.codigo_error > 0 Then
                            HuboError = True
                        End If
                    End If
                End If

            Next



            If ndoctoserror = 0 Then
                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Agregar_Log(ods.Tables("documento").Rows.Count & " Documentos Procesados ", "Ok")
                Cerrar_Documentos_Sucursal()
            Else
                MessageBox.Show("El Proceso Genero Errores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Agregar_Log(ndoctoserror.ToString & " Documentos Con Errores", _
                             IIf(ndoctoserror > 0, "Error", "Ok"))

            End If
            cm = CType(Me.BindingContext(Me.dgv_log.DataSource), CurrencyManager)
            cm.Position = cm.Count - 1

        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing
            If Not Otrans Is Nothing Then
                Otrans.close()
                Otrans = Nothing

            End If
        End Try
    End Sub

    Private Sub Procesar_Informacion_Vinoteca_FontaBella()


    End Sub

    Private Sub Procesar_Informacion_VINOTECA()

        Dim Osinc As New Sincronizacion.Documentos("")
        Dim OSinc_Clientes As New Sincronizacion.Clientes("")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        Dim cm As CurrencyManager
        Dim nprocesados As Integer = 0


        Try

            For Each dr In ods.Tables("documento").Rows
                HuboError = False
                ods.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                ods.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                ods.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString

                'If dr.Item("TipoDocto").ToString.ToLower.StartsWith("factura serie") Then
                Osinc.Enviar_Documento(gs_empresa, dr, ods.Tables("documentod").DefaultView.ToTable, ods.Tables("documentov").DefaultView.ToTable, ods.Tables("documentop").DefaultView.ToTable, "", True)



                If Osinc.codigo_error > 0 Then
                    HuboError = True
                    ndoctoserror += 1
                Else
                    nprocesados += 1
                End If
                Agregar_Log(dr.Item("tipodocto").ToString & " " & dr.Item("numero") & IIf(HuboError, Osinc.descripcion_error, ""), _
                                    IIf(HuboError, "Error", "Ok"))
                'End If

            Next

            For Each dr In ods.Tables("ctacte").Rows

                OSinc_Clientes.Obtener_Cliente(dr.Item("empresa"), dr.Item("ctacte"))
                If OSinc_Clientes.codigo_error = 0 Then

                    dt = OSinc_Clientes.dt

                    If dt.Rows.Count = 0 Then
                        ods.Tables("ctacte_direcciones").DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte").ToString & "'"
                        ods.Tables("ctacte_gentabcod").DefaultView.RowFilter = "codigo = '" & dr.Item("ctacte").ToString & "'"
                        OSinc_Clientes.Inserta_Clientes_Nuevos(dr, ods.Tables("ctacte_direcciones").DefaultView.ToTable, _
                                                            ods.Tables("ctacte_gentabcod").DefaultView.ToTable)
                        If Osinc.codigo_error > 0 Then
                            HuboError = True
                        End If
                    End If
                End If

            Next



            If ndoctoserror = 0 Then
                MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Agregar_Log(nprocesados & " Documentos Procesados ", "Ok")
            Else
                MessageBox.Show("El Proceso Genero Errores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Agregar_Log(ndoctoserror.ToString & " Documentos Con Errores", _
                             IIf(ndoctoserror > 0, "Error", "Ok"))

            End If
            cm = CType(Me.BindingContext(Me.dgv_log.DataSource), CurrencyManager)
            cm.Position = cm.Count - 1

        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing




        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Combos()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Me.btn_procesar.Visible = False
        If gs_empresa = "VINOTECA" Then
            If Me.cmb_ubicaciones.SelectedValue = 4 Then
                Generar_Informacion_Vinoteca_FontaBella()
            ElseIf Me.cmb_ubicaciones.SelectedValue = 8 Then ''PC
                Me.Generar_Informacion_Vinoteca_AlohaPC()
            ElseIf Me.cmb_ubicaciones.SelectedValue = 9 Then
                Me.generarInformacionVinotecaAlohaZ14Inventarios()

            Else
                Generar_informacion()
            End If
        Else
            Generar_informacion()
        End If

    End Sub

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        If gs_empresa = "VINOTECA" Then
            Procesar_Informacion()
        Else
            Procesar_Informacion()
        End If

    End Sub

    Private Sub dgv_log_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_log.CellContentClick

    End Sub

    Private Sub dgv_log_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_log.CellPainting
        If e.RowIndex > -1 And e.ColumnIndex > 0 Then
            Dim therow As DataGridViewRow
            therow = Me.dgv_log.Rows(e.RowIndex)
            Try
                If therow.Cells("estado").Value.ToString.ToLower = "error" Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                End If
            Catch ex As Exception
            End Try


        End If
    End Sub
End Class