Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Math



Public Class frm_daEnvioInformacion

    Dim ods As New DataSet("productos")
    Dim ods2 As New DataSet("Revision")

    Dim pdt As DataTable
    Dim WithEvents myrapi As New RAPI

    Private Sub Agregar_Usuario(ByVal dtv As DataView, ByVal popciones As String, ByVal psUsuario As String)
        Dim oTransCE As New Transaccional.Conexion_CE("mv_tekne_Mobile")
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim drv, drv2 As DataRowView

        Dim ls_sql As String
        Dim ls_aux As String = ","
        Dim dt As DataTable



        Try
            oTransCE.abrir()
            oTrans.abrir()
            ls_sql = "Delete from usuario"
            oTransCE.Elimina(ls_sql)


            ls_sql = "pa_sel_um_sg_usuario_empresa '" & psUsuario & "'"
            dt = oTrans.Obtiene(ls_sql)


            For Each drv In dtv
                'dt.DefaultView.RowFilter = "texto3  = '" & ps_usuario & "'"
                'dt = dt.DefaultView.ToTable(True, "empresa", "CODIGO", "RELACIONCODIGO1")
                For Each drv2 In dt.DefaultView
                    If ls_aux.IndexOf(drv2.Item("empresa").ToString.ToLower) < 0 Then

                        ls_aux += drv2.Item("empresa").ToString.ToLower & ","

                        ls_sql = "Insert Into usuario (usuario,nombre, empresa, permisos, clave,fecha_generado) " & _
                                "Select '" & drv.Item("usuario").ToString & "','" & _
                                drv.Item("nombre").ToString & "','" & drv2.Item("empresa").ToString & "','" & popciones & "','" & _
                                drv.Item("password").ToString & "','" & _
                                Now.ToString("MM-dd-yyyy") & "'"

                        oTransCE.Ingresa(ls_sql)
                        If oTransCE.Codigo_error > 0 Then
                            ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                        End If
                    End If
                Next

                If popciones.IndexOf("fisico") > 0 Then
                    For Each ls_aux In "dmarte1,codicasa,diuva,vinoteca".Split(",")


                        ls_sql = "Insert Into usuario (usuario,nombre, empresa, permisos, clave,fecha_generado, usuario_sysgold) " & _
                                  "Select '" & drv.Item("usuario").ToString & "','" & _
                                  drv.Item("nombre").ToString & "','" & ls_aux & "','" & popciones & "','" & _
                                  drv.Item("password").ToString & "','" & _
                                  Now.ToString("MM-dd-yyyy") & "',''"

                        oTransCE.Ingresa(ls_sql)
                        If oTransCE.Codigo_error > 0 Then
                            ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                        End If
                    Next
                End If

            Next

            If popciones.IndexOf("fisico") > 0 Then
                dt = oTrans.Obtiene("pa_sel_um_gen_tabcod null,'gen_bodega'")
                dt.DefaultView.RowFilter = "valor5 = 1"
                For Each drv In dt.DefaultView
                    ls_sql = "Insert Into bodega_conteo(empresa,bodega) Select '" & drv.Item("empresa").ToString & "','" & drv.Item("codigo").ToString & "'"
                    oTransCE.Ingresa(ls_sql)
                    If oTransCE.Codigo_error > 0 Then
                        ClsGen.Escribir_Log("Agregar_Usuario" & oTransCE.descripcion_error)
                    End If
                Next
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("Agregar_Usuario" & ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            oTransCE.cerrar()
            oTransCE = Nothing

        End Try

    End Sub


    Private Sub Agregar_Usuario(ByVal dtv As DataView)
        Dim drv As DataRowView
        Dim dr As DataRow



        Try
            ods.Tables("usuario").Rows.Clear()

            For Each drv In dtv
                dr = ods.Tables("usuario").NewRow
                dr.Item("usuario") = drv.Item("usuario")
                dr.Item("nombre") = drv.Item("nombre")

                ods.Tables("usuario").Rows.Add(dr)

            Next

            ods.Tables("encabezado_conteo").Rows.Clear()

            dr = ods.Tables("encabezado_conteo").NewRow
            dr.Item("empresa") = gs_empresa
            '  dr.Item("cod_conteo") = Me.NumericUpDown1.Value
            dr.Item("usuario") = ods.Tables("usuario").Rows(0).Item("usuario")
            ods.Tables("encabezado_conteo").Rows.Add(dr)


        Catch ex As Exception
        Finally

        End Try

    End Sub


    Private Sub Seleccionar_usuarioOLD()
        Dim ClsGen As New ClasesGenerales.Seleccionar_Opcion
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql As String
        Try

            Otrans.open()
            ls_sql = "pa_sel_um_sg_usuario_todos"
            dt = Otrans.Obtiene(ls_sql)
            ClsGen.pdt = dt
            ClsGen._DisplayMember = "nombre"
            ClsGen._ValueMember = "usuario"
            ClsGen.Obtener_Seleccion()

            ls_sql = ClsGen._SelectedValue
            dt.DefaultView.RowFilter = "usuario = '" & ls_sql & "'"
            Agregar_Usuario(dt.DefaultView)



        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Function Seleccionar_usuario() As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGenSP As New ClasesGenerales.Seleccionar_Opcion
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim lsusuario As String

        Dim ls_sql As String = String.Empty
        Try

            Otrans.open()
            ls_sql = "pa_sel_um_sg_usuario_todos"
            dt = Otrans.Obtiene(ls_sql)

            ClsGenSP.pdt = dt
            ClsGenSP._DisplayMember = "nombre"
            ClsGenSP._ValueMember = "usuario"
            ClsGenSP.Obtener_Seleccion()
            lsusuario = ClsGenSP._SelectedValue

            dt.DefaultView.RowFilter = "usuario = '" & lsusuario & "'"

            ls_sql = "pa_sel_um_sg_usuario_menu_opcion_empresa 18,'" & lsusuario & "'"
            dt2 = Otrans.Obtiene(ls_sql)

            Dim dt3 As DataTable = ClsGen.ValoresDistinto(dt2, "opcion".Split(","))

            ls_sql = String.Empty
            For Each dr As DataRow In dt3.Rows
                ls_sql += "," & dr.Item("opcion")
            Next
            'dt.DefaultView.RowFilter = "empresa = 'umbral' and (ubicacion = 'contabilidad' or ubicacion = 'recursos humanos')"

            Agregar_Usuario(dt.DefaultView, ls_sql, lsusuario)

            ''Para Inventarios Fisicos deben Ir varios Usuarios

            ' Agregar_Usuario_Parametros(dt.DefaultView(0).Item("usuario"))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return ls_sql
    End Function



    Private Function Copiar_HandHeld(ByVal nombre_archivo As String) As Boolean

        Dim proceso_exitoso As Boolean = True

        ' Perform the copy.
        Try
            Me.Conectar_HandHeld()
            Verificar_Carpetas_HandHeld()
            'If (txtCopySource.Text = "") Or (txtCopyDestination.Text = "") Then
            '    MessageBox.Show("You must provide both a source and destination file.", _
            '      "Missing File Information")
            '    Exit Sub
            'End If

            'Select Case cmbCopyDirection.Text
            '    Case ""
            '        MessageBox.Show("You must select a direction before initiating the copy.", _
            '          "No Destination Selected")
            '        Exit Sub
            '    Case "from desktop to device"
            'myrapi.CopyFileToDevice(txtCopySource.Text, txtCopyDestination.Text)
            Try
                myrapi.DeleteDeviceFile("Tekne\" & nombre_archivo)
            Catch ex As Exception

            End Try

            myrapi.CopyFileToDevice("c:\temp\SDF\" & nombre_archivo, "\Tekne\" & nombre_archivo, True)
            '    Case "from device to desktop"
            'myrapi.CopyFileFromDevice(txtCopySource.Text, txtCopyDestination.Text)
            'End Select


            proceso_exitoso = True
            ' Handle any errors that might occur.
        Catch ex As Exception
            MessageBox.Show("The following error occurred copying the file -" & ex.Message, _
              "Copy Error")
        Finally
            myrapi.Disconnect()
        End Try
        'mostrar_estatus()
        Return proceso_exitoso
    End Function

    Private Sub Conectar_HandHeld()
        Try
            ' Connect to the device.
            If myrapi.DevicePresent Then
                myrapi.Connect()
            End If
            'Do While Not myrapi.DevicePresent
            '    MessageBox.Show("Please connect your device to your PC using ActiveSync and " & _
            '      "before clicking the OK button.", "No Device Present")
            '    myrapi.Connect()
            'Loop

        Catch ex As Exception
            MessageBox.Show("The following error occurred while attempting to connect to" & _
              " your device - " & ex.Message, "Connection Error")
            'Application.Exit()
        End Try
    End Sub

    Private Sub Verificar_Carpetas_HandHeld()

        Try
            myrapi.CreateDeviceDirectory("\Tekne")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Tekne\Send")
        Catch ex As Exception
        End Try

        Try
            'myrapi.CreateDeviceDirectory("\My Documents\Umbral\Receive")
            myrapi.CreateDeviceDirectory("\Tekne\Receive")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Tekne\Send\Log")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Tekne\Receive\Log")
        Catch ex As Exception
        End Try


    End Sub


    Private Sub Enviar_Archivos_PDA()
        Dim ClsGen As New ClasesGenerales.General
        Dim ruta_archivos As String
        Dim archivos As String()
        Dim archivo As String

        Try
            ruta_archivos = "C:\Temp\SDF\"
            archivos = Directory.GetFiles(ruta_archivos, "*.sdf")
            For Each archivo In archivos
                If Copiar_HandHeld(archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1)) Then
                    'ClsGen.Mover_Archivo(archivo, "c:\temp\Receive\Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                    MessageBox.Show("Archivo Enviado Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Next


        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Procesar_Archivos_PDA_XML()
        Dim oTransCE As New Transaccional.Conexion_CE("mv_tekne_Mobile")
        'Dim dr As DataRow
        Dim ls_sql As String



        Try
            oTransCE.abrir()

            '   For Each dr In ods.Tables("producto").Rows

            Try
                oTransCE.Ingresa("Alter Table producto add tipoproducto nvarchar(50)")
                oTransCE.Ingresa("Alter Table producto add familia nvarchar(50)")
                oTransCE.Ingresa("Alter Table producto add proveedor nvarchar(50)")
                oTransCE.Ingresa("Alter Table producto add codigo_barra nvarchar(50)")
                oTransCE.Ingresa("Alter Table producto add vigente nvarchar(1)")
                oTransCE.Ingresa("Alter Table producto add codigo_barra_nuevo nvarchar(50)")

                oTransCE.Ingresa("Alter Table da_dua_encabezado add bodega nvarchar(50)")
                oTransCE.Ingresa("Alter Table da_dua_encabezado add no_ingreso int")


            Catch ex As Exception

            End Try
            ls_sql = "Delete from producto"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("productos").Rows
                ls_sql = "Insert Into producto (empresa,producto,descripcion,tipoproducto,familia,proveedor," & _
                        "marca,subtipo,codigo_barra,vigente,codigo_barra_nuevo,factoralt) " & _
                         "Select '" & dr.Item("empresa").ToString & "','" & _
                         dr.Item("producto").ToString & "','" & _
                         dr.Item("glosa").ToString & "','" & _
                         dr.Item("tipoproducto").ToString & "','" & _
                         dr.Item("familia").ToString & "','" & _
                         dr.Item("proveedor").ToString & "','" & _
                         dr.Item("marca").ToString & "','" & _
                         dr.Item("subtipo").ToString & "','" & _
                         dr.Item("codbarra").ToString & "','" & _
                         dr.Item("Vigente").ToString & "','" & _
                         dr.Item("codbarra").ToString & "'," & _
                         dr.Item("factoralt").ToString

                oTransCE.Ingresa(ls_sql)
            Next



            ls_sql = "Delete from da_dua_encabezado"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_dua_encabezado").Rows

                Try
                    ls_sql = "Insert into da_dua_encabezado (empresa,no_orden, bodega, no_ingreso,no_ordenCompra," & _
                                          "total_bultos, aduana, contenedor, fecha, fecha_vencimiento, " & _
                                          "usuario, fecha_hora_grabo, usuario_modif, fecha_hora_modif, " & _
                                          "proveedor, recibida_por, facturas) " & _
                                          "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "','" & _
                                          dr.Item("bodega").ToString & "'," & dr.Item("no_ingreso").ToString & ",'" & _
                                          dr.Item("no_ordencompra").ToString & "'," & _
                                          dr.Item("total_bultos").ToString & ",'" & dr.Item("aduana").ToString & "','" & dr.Item("contenedor").ToString & "','" & _
                                          DateTime.Parse(dr.Item("fecha").ToString).ToString("MM-dd-yyyy") & "','" & DateTime.Parse(dr.Item("fecha_vencimiento").ToString).ToString("MM-dd-yyyy") & "','" & _
                                          dr.Item("usuario").ToString & "','" & DateTime.Parse(dr.Item("fecha_hora_grabo").ToString).ToString("MM-dd-yyyy") & "','" & dr.Item("usuario_modif").ToString & "','"

                    If dr.Item("fecha_hora_modif").ToString.Trim.Length = 0 Then
                        ls_sql += "01-01-1900"
                    Else
                        ls_sql += DateTime.Parse(dr.Item("fecha_hora_modif").ToString).ToString("MM-dd-yyyy")
                    End If

                    ls_sql += "','" & dr.Item("proveedor").ToString & "','" & dr.Item("recibida_por").ToString & "','" & dr.Item("facturas").ToString & "'"

                    oTransCE.Ingresa(ls_sql)
                Catch ex As Exception

                End Try




            Next


            ls_sql = "Delete from da_dua_detalle"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_dua_detalle").Rows
                ls_sql = "Insert into da_dua_detalle (empresa,no_orden," & _
                        "bodega, correlativo,producto," & _
                        "codigo_barra, bultos, unidades, estanteria, nivel, " & _
                        "pasillo, tramo, fecha_venc, " & _
                        "observaciones, vence, produccion," & _
                        "proveedor, registro, lote, " & _
                        "batch, unidades_malas, motivo_malas) " & _
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "','" & _
                        dr.Item("bodega").ToString & "'," & dr.Item("correlativo").ToString & ",'" & dr.Item("producto").ToString & "','" & _
                        dr.Item("codigo_barra").ToString & "'," & dr.Item("bultos").ToString & "," & dr.Item("unidades").ToString & ",'" & _
                        dr.Item("estanteria").ToString & "','" & dr.Item("nivel").ToString & "','" & _
                        dr.Item("pasillo").ToString & "','" & dr.Item("tramo").ToString & "','" & dr.Item("fecha_venc").ToString & "','" & _
                        dr.Item("observaciones").ToString & "','" & dr.Item("vence").ToString & "'," & _
                        IIf(dr.Item("produccion") Is System.DBNull.Value, 0, dr.Item("produccion").ToString) & ",'" & _
                        dr.Item("proveedor").ToString & "','" & dr.Item("registro").ToString & "','" & dr.Item("lote").ToString & "','" & _
                        dr.Item("bacth").ToString & "'," & dr.Item("unidades_malas").ToString & ",'" & dr.Item("motivo_daño").ToString & "'"

                oTransCE.Ingresa(ls_sql)
            Next


            ls_sql = "Delete from da_di_encabezado"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_di_encabezado").Rows
                ls_sql = "Insert into da_di_encabezado (empresa,no_orden," & _
                        "bodega, no_retiro," & _
                        "fecha, usuario, fecha_hora_creacion, " & _
                        "usuario_modif, fecha_hora_modif, " & _
                        "proveedor, dua) " & _
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "','" & _
                        dr.Item("bodega").ToString & "'," & dr.Item("no_retiro").ToString & ",'" & _
                        DateTime.Parse(dr.Item("fecha").ToString).ToString("MM-dd-yyyy") & "','" & dr.Item("usuario").ToString & "','" & _
                        DateTime.Parse(dr.Item("fecha_hora_creacion").ToString).ToString("MM-dd-yyyy") & "','" & _
                        dr.Item("usuario_modif").ToString & "','"

                If dr.Item("fecha_hora_modif").ToString.Trim.Length = 0 Then
                    ls_sql += "01-01-1900"
                Else
                    ls_sql += DateTime.Parse(dr.Item("fecha_hora_modif").ToString).ToString("MM-dd-yyyy")
                End If

                ls_sql += "','" & dr.Item("proveedor").ToString & "','" & dr.Item("dua").ToString & "'"

                oTransCE.Ingresa(ls_sql)
            Next



            ls_sql = "Delete from da_di_detalle"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_di_detalle").Rows
                ls_sql = "Insert into da_di_detalle (empresa,no_orden," & _
                        "correlativo, dua, producto, " & _
                        "cantidad, proveedor, " & _
                        "bultos, observaciones, lote) " & _
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "'," & _
                        dr.Item("correlativo").ToString & ",'" & dr.Item("dua").ToString & "','" & dr.Item("producto") & "'," & _
                        dr.Item("cantidad").ToString & ",'" & dr.Item("proveedor").ToString & "'," & _
                        dr.Item("bultos").ToString & ",'" & dr.Item("observaciones").ToString & "','" & _
                        dr.Item("lote").ToString & "'"

                oTransCE.Ingresa(ls_sql)
            Next


            ls_sql = "Delete from da_reserva_encabezado"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_reserva_encabezado").Rows
                ls_sql = "Insert into da_reserva_encabezado (empresa,no_orden," & _
                        "bodega, fecha, dua, " & _
                        "proveedor,usuario, " & _
                        "fecha_hora_grabo,usuario_modif,fecha_hora_modif,estatus) " & _
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "','" & _
                        dr.Item("bodega").ToString & "','" & _
                        DateTime.Parse(dr.Item("fecha").ToString).ToString("MM-dd-yyyy") & "','" & _
                        dr.Item("dua").ToString & "','" & dr.Item("proveedor") & "','" & _
                        dr.Item("usuario").ToString.Trim & "','"

                If dr.Item("fecha_hora_grabo").ToString.Trim.Length = 0 Then
                    ls_sql += "01-01-1900"
                Else
                    ls_sql += DateTime.Parse(dr.Item("fecha_hora_grabo").ToString).ToString("MM-dd-yyyy")
                End If

                ls_sql += "','" & dr.Item("usuario_modif").ToString & "','"

                If dr.Item("fecha_hora_modif").ToString.Trim.Length = 0 Then
                    ls_sql += "01-01-1900"
                Else
                    ls_sql += DateTime.Parse(dr.Item("fecha_hora_modif").ToString).ToString("MM-dd-yyyy")
                End If
                ls_sql += "','" & dr.Item("estatus").ToString & "'"

                oTransCE.Ingresa(ls_sql)
            Next

            ls_sql = "Delete from da_reserva_detalle"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("da_reserva_detalle").Rows
                ls_sql = "Insert into da_reserva_detalle (empresa,no_orden," & _
                        "bodega,correlativo, dua, producto, " & _
                        "cantidad, proveedor, " & _
                        "bultos, observaciones, no_solicitud_reserva, lote) " & _
                        "Select '" & dr.Item("empresa").ToString & "','" & dr.Item("no_orden").ToString & "','" & _
                        dr.Item("bodega").ToString & "'," & dr.Item("correlativo").ToString & ",'" & dr.Item("dua").ToString & "','" & dr.Item("producto") & "'," & _
                        dr.Item("cantidad").ToString & ",'" & dr.Item("proveedor").ToString & "'," & _
                        dr.Item("bultos").ToString & ",'" & dr.Item("observaciones").ToString & "','" & dr.Item("no_solicitud_reserva").ToString & "','" & _
                        dr.Item("lote").ToString & "'"
                oTransCE.Ingresa(ls_sql)
            Next



            'ls_sql = "Delete from usuario"
            'oTransCE.Elimina(ls_sql)
            'For Each dr As DataRow In ods.Tables("usuario").Rows
            '    ls_sql = "Insert Into usuario (usuario, nombre) " & _
            '            "Select '" & dr.Item("usuario").ToString & "','" & _
            '            dr.Item("nombre").ToString & "'"
            '    oTransCE.Ingresa(ls_sql)
            'Next



            ls_sql = "Delete from encabezado_conteo"
            oTransCE.Elimina(ls_sql)

            If ods.Tables.Contains("encabezado_conteo") Then
                For Each dr As DataRow In ods.Tables("encabezado_conteo").Rows
                    ls_sql = "Insert Into encabezado_conteo (empresa,cod_conteo,usuario,fecha_inicio,hora_inicio, estado) " & _
                            "Select '" & dr.Item("empresa").ToString & "'," & dr.Item("cod_conteo") & ",'" & _
                            dr.Item("usuario").ToString & "','" & Today.ToString("yyyy/MM/dd") & "','" & _
                            Now.ToString("HH:mm") & "',1"
                    oTransCE.Ingresa(ls_sql)
                Next

            End If


            ls_sql = "Delete from encabezado_conteo"
            oTransCE.Elimina(ls_sql)

            If ods.Tables.Contains("encabezado_conteo") Then
                For Each dr As DataRow In ods.Tables("encabezado_conteo").Rows
                    ls_sql = "Insert Into encabezado_conteo (empresa,cod_conteo,usuario,fecha_inicio,hora_inicio, estado) " & _
                            "Select '" & dr.Item("empresa").ToString & "'," & dr.Item("cod_conteo") & ",'" & _
                            dr.Item("usuario").ToString & "','" & Today.ToString("yyyy/MM/dd") & "','" & _
                            Now.ToString("HH:mm") & "',1"
                    oTransCE.Ingresa(ls_sql)
                Next

            End If


            ls_sql = "Delete from detalle_conteo"
            oTransCE.Elimina(ls_sql)

            ls_sql = "Delete from producto_conteo"
            oTransCE.Elimina(ls_sql)



        Catch ex As Exception
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing

        End Try

    End Sub

    Private Sub Asociar_Usuario_Archivo_PDA()
        Dim lotroenvio As Boolean = False
        Try
            Seleccionar_usuario()


            ods.WriteXml("c:\temp\Receive\Conteo_Productos" & Now.ToString("ddMMyyyHHmm") & ".xml", XmlWriteMode.WriteSchema)
            Procesar_Archivos_PDA_XML()
            Enviar_Archivos_PDA()
            If MessageBox.Show("Desea Enviar a Otra PDA", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lotroenvio = True

            End If

        Catch ex As Exception

        End Try
        If lotroenvio Then
            MessageBox.Show("Conecte la nueva PDA", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Asociar_Usuario_Archivo_PDA()
        End If

    End Sub


    Private Sub Generar_Archivo_PDA()

        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            lsSQL = "Select empresa,producto,glosa,tipoproducto,familia,subfamilia as proveedor,tipo as marca,subtipo,vigente, codbarra,factoralt " & _
                    " from flexline.v_um_producto_busqueda  " & _
                    " where empresa in  ('DMARTE1','CODICASA','ALAMSA','DIUVA')"
            lsSQL += " And validastock = 'S' "
            pdt = Otrans.Obtiene(lsSQL)



            If pdt.Rows.Count > 0 Then
                Try
                    pdt.Columns.Add(New DataColumn("codigo_barra_asignado", GetType(String)))
                Catch ex As Exception
                End Try

                pdt.TableName = "productos"
                If ods.Tables.Contains("productos") Then
                    ods.Tables.Remove("productos")
                End If


                ods.Tables.Add(pdt.Copy)


                lsSQL = "pa_var_um_da_dua_encabezado_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_dua_encabezado"
                ods.Tables.Add(pdt.Copy)

                lsSQL = "pa_var_um_da_dua_detalle_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_dua_detalle"
                ods.Tables.Add(pdt.Copy)


                lsSQL = "pa_var_um_da_di_encabezado_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_di_encabezado"
                ods.Tables.Add(pdt.Copy)


                lsSQL = "pa_var_um_da_di_detalle_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_di_detalle"
                ods.Tables.Add(pdt.Copy)



                lsSQL = "pa_var_um_da_reserva_encabezado_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_reserva_encabezado"
                ods.Tables.Add(pdt.Copy)


                lsSQL = "pa_var_um_da_reserva_detalle_saldo '" & "dmarte1" & "'"
                pdt = Otrans.Obtiene(lsSQL)
                pdt.TableName = "da_reserva_detalle"
                ods.Tables.Add(pdt.Copy)


                Asociar_Usuario_Archivo_PDA()
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub generarInformacion()
        'If MessageBox.Show("Esta Seguro que es el Conteo No." & Chr(13) & _
        '                  "        " & Me.NumericUpDown1.Value.ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Generar_Archivo_PDA()
        'End If
    End Sub

    Private Sub frm_daEnvioInformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        generarInformacion()
    End Sub
End Class