Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Math
Public Class frm_inventarios_fisicos

    Dim ods As New DataSet("productos")
    Dim ods2 As New DataSet("Revision")

    Dim pdt As DataTable
    Dim WithEvents myrapi As New RAPI


    Private Sub Crear_Estructura_Revision()

        Dim icount As Integer

        Dim dt As New DataTable("conteos")

        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("bodega", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("glosa", GetType(String))

        For icount = 1 To 20
            dt.Columns.Add("usuario_" & icount.ToString, GetType(String))
        Next
        ods2.Tables.Add(dt)
        dt.Columns.Add("cod_conteo", GetType(String))

        dt = New DataTable("conteos_usuarios")

        dt.Columns.Add("cod_usuario", GetType(String))
        dt.Columns.Add("usuario", GetType(String))

        ods2.Tables.Add(dt)



    End Sub

    Private Sub Crear_Estructura()

        Dim dt As DataTable
        dt = New DataTable("usuario")
        dt.Columns.Add("usuario", GetType(String))
        dt.Columns.Add("nombre", GetType(String))

        If ods.Tables.Contains(dt.TableName) Then
            ods.Tables.Remove(dt.TableName)
        End If
        ods.Tables.Add(dt.Copy)

        dt = New DataTable("encabezado_conteo")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cod_conteo", GetType(Integer))
        dt.Columns.Add("usuario", GetType(String))
        If ods.Tables.Contains(dt.TableName) Then
            ods.Tables.Remove(dt.TableName)
        End If
        ods.Tables.Add(dt.Copy)

    End Sub

    Private Sub Llenar_Combos()
        Dim nitems(5) As Integer
        nitems(0) = 10
        Me.cmb_campos1.Items.Add("TIPOPRODUCTO")
        Me.cmb_campos1.Items.Add("FAMILIA")
        Me.cmb_campos1.Items.Add("PROVEEDOR")
        Me.cmb_campos1.Items.Add("MARCA")
        Me.cmb_campos1.Items.Add("SUBTIPO")
        Me.cmb_campos1.Items.Add("GLOSA")
        Me.cmb_campos1.Items.Add("CODIGO")
        For icount As Integer = 0 To Me.cmb_campos1.Items.Count - 1
            Me.cmb_campos2.Items.Add(Me.cmb_campos1.Items(icount))
            Me.cmb_campos3.Items.Add(Me.cmb_campos1.Items(icount))
            Me.cmb_campos4.Items.Add(Me.cmb_campos1.Items(icount))
            Me.cmb_campos5.Items.Add(Me.cmb_campos1.Items(icount))
            Me.cmb_campos6.Items.Add(Me.cmb_campos1.Items(icount))
        Next


    End Sub

    Private Function Armar_filtro() As String
        Dim ls_filtro As String = ""
        Dim ClsGen As New ClasesGenerales.General

        Try
            ls_filtro = ClsGen.Armar_Filtro(Me.cmb_campos1.Text, Me.cmb_campos2.Text, Me.cmb_campos3.Text, Me.cmb_campos4.Text, Me.cmb_campos5.Text, Me.cmb_campos6.Text, _
                            Me.txt_buscar1.Text, Me.txt_buscar2.Text, Me.txt_buscar3.Text, Me.txt_buscar4.Text, Me.txt_buscar5.Text, Me.txt_buscar6.Text, _
                            Me.cmb_operador1.Text.Replace("Contenga", "like"), Me.cmb_operador2.Text.Replace("Contenga", "like"), Me.cmb_operador3.Text.Replace("Contenga", "like"), _
                            Me.cmb_operador4.Text.Replace("Contenga", "like"), Me.cmb_operador5.Text.Replace("Contenga", "like"), Me.cmb_operador6.Text.Replace("Contenga", "like"), _
                            Me.cmb_operador_logico1.Text.Replace("Y", "And").Replace("O", "OR"), Me.cmb_operador_logico2.Text.Replace("Y", "And").Replace("O", "OR"), Me.cmb_operador_logico3.Text.Replace("Y", "And").Replace("O", "OR"), _
                            Me.cmb_operador_logico4.Text.Replace("Y", "And").Replace("O", "OR"), Me.cmb_operador_logico5.Text.Replace("Y", "And").Replace("O", "OR"))
            ls_filtro = ls_filtro.Replace("Contenga", "like")

            ' MessageBox.Show(ls_filtro)

        Catch ex As Exception
            ls_filtro = String.Empty
        Finally
            ClsGen = Nothing

        End Try
        Return ls_filtro

    End Function


    Private Sub Hacer_Busqueda()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql, filtro As String
        Dim clsgen As New ClasesGenerales.General


        Try
            Otrans.open()
            filtro = Armar_filtro()
            filtro = filtro.Replace("MARCA", "TIPO").Replace("PROVEEDOR", "SUBFAMILIA").Replace("CODIGO", "PRODUCTO")
            ls_sql = "Select empresa,producto,glosa,tipoproducto,familia,subfamilia as proveedor,tipo as marca,subtipo,vigente, codbarra,factoralt from v_um_producto_busqueda  where empresa = '" & gs_empresa & "'"
            ls_sql += " And validastock = 'S' "
            ls_sql += IIf(filtro.Length > 0, " And (" & filtro & ")", "")
            pdt = Otrans.Obtiene(ls_sql)
            Me.DataGridView1.DataSource = pdt
            clsgen.Alinear_GridView(pdt, Me.DataGridView1, "", ",empresa,", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing

        End Try

    End Sub

    Private Sub Generar_Archivo_PDA()

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
            Asociar_Usuario_Archivo_PDA()

        End If

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


    Private Sub Enviar_Archivos_PDA()
        Dim ClsGen As New ClasesGenerales.General
        Dim ruta_archivos As String
        Dim archivos As String()
        Dim archivo As String

        Try
            ruta_archivos = "C:\Aplicaciones\SDF\"
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
        Dim oTransCE As New Transaccional.Conexion_CE("mv_inventarios")
        'Dim dr As DataRow
        Dim ls_sql As String



        Try
            oTransCE.abrir()

            '   For Each dr In ods.Tables("producto").Rows

            ls_sql = "Delete from producto"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("productos").Rows
                ls_sql = "Insert Into producto (empresa,producto,glosa,tipoproducto,familia,proveedor," & _
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

            ls_sql = "Delete from usuario"
            oTransCE.Elimina(ls_sql)
            For Each dr As DataRow In ods.Tables("usuario").Rows
                ls_sql = "Insert Into usuario (usuario, nombre) " & _
                        "Select '" & dr.Item("usuario").ToString & "','" & _
                        dr.Item("nombre").ToString & "'"
                oTransCE.Ingresa(ls_sql)
            Next

           

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




            'Next




        Catch ex As Exception
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing

        End Try

    End Sub


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
            myrapi.DeleteDeviceFile("Umbral\" & nombre_archivo)
            myrapi.CopyFileToDevice("c:\temp\SDF\" & nombre_archivo, "\Umbral\" & nombre_archivo, True)
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
            myrapi.CreateDeviceDirectory("\Umbral")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Umbral\Send")
        Catch ex As Exception
        End Try

        Try
            'myrapi.CreateDeviceDirectory("\My Documents\Umbral\Receive")
            myrapi.CreateDeviceDirectory("\Umbral\Receive")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Umbral\Send\Log")
        Catch ex As Exception
        End Try

        Try
            myrapi.CreateDeviceDirectory("\Umbral\Receive\Log")
        Catch ex As Exception
        End Try


    End Sub

    Private Sub Realizar_Recepcion()

        Dim archivos As FileList
        Dim icount As Integer
        Dim sArchivo As String
        Try
            Conectar_HandHeld()
            archivos = myrapi.EnumFiles("\Umbral\Send\*.xml")
            If Not archivos Is Nothing Then


                For icount = 0 To archivos.Count - 1
                    sArchivo = "\Umbral\Send\" & archivos.Item(icount).FileName
                    myrapi.CopyFileFromDevice("C:\Temp\Send\" & archivos.Item(icount).FileName, "\Umbral\Send\" & archivos.Item(icount).FileName, True)
                    myrapi.MoveDeviceFile("\Umbral\Send\" & archivos.Item(icount).FileName, "\Umbral\Send\Log\" & archivos.Item(icount).FileName)
                Next
            End If

        Catch ex As Exception
        Finally
            myrapi.Disconnect()
            Procesar_Recepcion()
        End Try
    End Sub

    Private Sub Procesar_Recepcion()

        Dim ClsGen As New ClasesGenerales.General
        Dim OdsRecepcion As New DataSet
        Dim ruta_archivos As String
        Dim archivos As String()
        Dim archivo As String
        Dim eliminar_archivo As Boolean = False
        Try

            ruta_archivos = "C:\Temp\Send\"
            archivos = Directory.GetFiles(ruta_archivos, "*.xml")

            For Each archivo In archivos
                OdsRecepcion.ReadXml(archivo)
                If OdsRecepcion.Tables.Count > 0 Then
                    If OdsRecepcion.Tables.Contains("producto_revision") Then

                        eliminar_archivo = Procesar_Barras(OdsRecepcion.Tables("producto_revision"))
                    End If

                    If OdsRecepcion.Tables.Contains("Conteo_fisico_encabezado") Then
                        eliminar_archivo = Procesar_Conteos(OdsRecepcion)
                    End If

                    If OdsRecepcion.Tables.Contains("Conteo_fisico_detalle") Then
                        eliminar_archivo = Procesar_detalle_Conteos(OdsRecepcion)

                    End If

                End If


                If eliminar_archivo Then
                    ClsGen.Mover_Archivo(archivo, ruta_archivos & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                End If
                eliminar_archivo = False
            Next




        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Function Procesar_Barras(ByVal _dt As DataTable) As Boolean

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow
        Dim ls_sql As String
        Dim Proceso_Exitoso As Boolean = False

        Try
            myOtrans.open()
            For Each dr In _dt.Rows
                If dr.Item("codigocorrecto").ToString.ToLower <> "s" Then

                    ls_sql = "call pa_ins_um_inv_producto_verificacion_barras(" & _
                        clsGen.Codigo_Empresa_Onbase(dr.Item("empresa")) & ",'" & _
                        dr.Item("producto").ToString & "','" & _
                        dr.Item("codigobarranuevo").ToString & "','" & _
                        dr.Item("codigobarra").ToString &  "')"

                    myOtrans.Ingresa(ls_sql)
                End If



            Next
            Proceso_Exitoso = True

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

        Return Proceso_Exitoso
    End Function

    Private Function Procesar_Conteos(ByVal _ods As DataSet) As Boolean
        Dim lbproceso_exitoso As Boolean = True
        Dim dr As DataRow
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Try
            myOtrans.open()
            For Each dr In _ods.Tables("Conteo_fisico_encabezado").Rows


                ls_sql = "call pa_ins_um_inv_producto_inventario ('" & _
                        dr.Item("empresa").ToString & "','" & _
                        dr.Item("producto").ToString & "','" & _
                        dr.Item("descripcion").ToString & "'," & _
                        dr.Item("cod_conteo").ToString & ",'" & _
                        dr.Item("usuario").ToString & "'," & _
                        dr.Item("total").ToString & ",'" & dr.Item("bodega").ToString & "')"

                myOtrans.Ingresa(ls_sql)


            Next
        Catch ex As Exception
            lbproceso_exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            'mostrar_Conteos()
        End Try
        Return lbproceso_exitoso

    End Function

    Private Function Procesar_detalle_Conteos(ByVal _ods As DataSet) As Boolean
        Dim lbproceso_exitoso As Boolean = True
        Dim dr As DataRow
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Try
            myOtrans.open()
            For Each dr In _ods.Tables("conteo_fisico_detalle").Rows

                'ls_sql = "call pa_ins_um_inv_producto_inventario ('" & _
                '        dr.Item("empresa").ToString & "','" & _
                '        dr.Item("producto").ToString & "',''," & _
                '        dr.Item("cod_conteo").ToString & ",'" & _
                '        dr.Item("usuario").ToString & "'," & _
                '        dr.Item("total").ToString & ",'SVPC')"

                ls_sql = "call pa_ins_um_inv_producto_inventario_detalle ('" & _
                        dr.Item("empresa").ToString & "','" & _
                        dr.Item("producto").ToString & "'," & _
                        dr.Item("cod_conteo").ToString & ",'" & _
                        dr.Item("usuario").ToString & "'," & _
                        dr.Item("total").ToString & ",'" & dr.Item("bodega").ToString & "','" & _
                        dr.Item("tipo").ToString & "','" & _
                        DateTime.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"

                myOtrans.Ingresa(ls_sql)
                If myOtrans.Codigo_error > 0 Then
                    MessageBox.Show(myOtrans.descripcion_error)
                End If


            Next
        Catch ex As Exception
            lbproceso_exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            'mostrar_Conteos()
        End Try
        Return lbproceso_exitoso

    End Function

    Private Function Mostrar_Conteos()
        Dim lbproceso_exito As Boolean = True
        Dim dr, dr2 As DataRow
        Dim dr_aux As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim liusuario As Integer

        Dim icount As Integer
        Dim ls_conteos As String = String.Empty
        Dim lb_encontrado As Boolean = False
        Dim ClsGen As New ClasesGenerales.General

        Try
            ods2.Tables("conteos").Rows.Clear()

            myOtrans.open()
            ls_sql = "call pa_sel_um_inv_producto_inventario ('" & gs_empresa & "')"
            ls_sql = "call pa_sel_um_inv_producto_inventario (null)"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows

                ods2.Tables("conteos_usuarios").DefaultView.RowFilter = "usuario = '" & dr.Item("usuario_conteo").ToString & "'"

                If ods2.Tables("conteos_usuarios").DefaultView.Count > 0 Then
                    liusuario = ods2.Tables("conteos_usuarios").DefaultView(0).Item("cod_usuario")
                Else
                    Try
                        liusuario = ods2.Tables("conteos_usuarios").Compute("max(cod_usuario)", "")
                    Catch ex As Exception
                        liusuario = 0
                    End Try
                    liusuario += 1

                    dr_aux = ods2.Tables("conteos_usuarios").NewRow
                    dr_aux.Item("cod_usuario") = liusuario
                    dr_aux.Item("usuario") = dr.Item("usuario_conteo")
                    ods2.Tables("conteos_usuarios").Rows.Add(dr_aux)
                End If

                For Each dr2 In ods2.Tables("conteos").Rows
                    If dr2.Item("producto").ToString = dr.Item("cod_flex").ToString And _
                        dr2.Item("cod_conteo") = dr.Item("cod_conteo") And _
                        dr2.Item("bodega") = dr.Item("bodega") And _
                        dr2.Item("empresa") = dr.Item("empresa") Then

                        dr2.Item("usuario_" & liusuario) = dr.Item("cantidad")
                        lb_encontrado = True
                        Exit For
                    End If

                Next

                If Not lb_encontrado Then


                    dr_aux = ods2.Tables("conteos").NewRow
                    For icount = 1 To 20
                        dr_aux.Item("usuario_" & icount.ToString) = 0
                    Next
                    dr_aux.Item("empresa") = dr.Item("empresa").ToString
                    dr_aux.Item("producto") = dr.Item("cod_flex").ToString
                    dr_aux.Item("glosa") = dr.Item("nombre_producto").ToString
                    dr_aux.Item("cod_conteo") = dr.Item("cod_conteo").ToString
                    dr_aux.Item("usuario_" & liusuario) = dr.Item("cantidad")
                    dr_aux.Item("bodega") = dr.Item("bodega")
                    ods2.Tables("conteos").Rows.Add(dr_aux)

                    'If ls_conteos.IndexOf(dr.Item("cod_conteo")) = -1 Then
                    '    ls_conteos += dr.Item("cod_conteo").ToString & ","
                    'End If

                End If
                lb_encontrado = False
            Next

            'MessageBox.Show(ls_conteos)

            dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "empresa".Split(","))
            Me.cmbEmpresa.DataSource = dt
            Me.cmbEmpresa.ValueMember = "empresa"
            Me.cmbEmpresa.DisplayMember = "empresa"


            dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "cod_conteo".Split(","))
            Me.cmbConteos.DataSource = dt
            Me.cmbConteos.ValueMember = "cod_conteo"
            Me.cmbConteos.DisplayMember = "cod_conteo"



            dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "bodega".Split(","))
            Me.cmbBodega.DataSource = dt
            Me.cmbBodega.ValueMember = "bodega"
            Me.cmbBodega.DisplayMember = "bodega"
            Me.dgv_conteo.DataSource = ods2.Tables("conteos")
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Alinear_Grid_Conteos()
    End Function


    Private Sub Alinear_Grid_Conteos()

        Me.dgv_conteo.DataSource = ods2.Tables("conteos")
        Me.dgv_conteo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dgv_conteo.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgv_conteo.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String
        Dim mes_actual As Date

        For Each dc In Me.dgv_conteo.Columns
            dc.ReadOnly = True
            If dc.Name.ToLower.StartsWith("usuario_") Then
                mes = dc.Name.Split("_")
                ods2.Tables("conteos_usuarios").DefaultView.RowFilter = "cod_usuario = " & Int32.Parse(mes(1))
                If ods2.Tables("conteos_usuarios").DefaultView.Count > 0 Then
                    dc.HeaderText = ods2.Tables("conteos_usuarios").DefaultView(0).Item("usuario")
                    dc.DefaultCellStyle.Format = "n0"
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dc.Visible = True

                Else
                    dc.Visible = False
                End If

            ElseIf dc.Name.ToLower.StartsWith("vige") Then
                dc.Width = 10
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            ElseIf dc.Name.ToLower = "total" Then
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End If
        Next

    End Sub



    Private Sub Mostrar_Barras()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dr As DataRow
        Dim ls_sql As String
        Dim Proceso_Exitoso As Boolean = False
        Dim dt As DataTable

        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_inv_producto_verificacion_barras (" & gi_cod_empresa_onbase & ",0)"

            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "verificacion_barras"

            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            Me.dgv_listado_barras.DataSource = ods.Tables("verificacion_barras")

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub

    Private Sub Actualizar_Barras_Flex()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim drv As DataRowView
        Dim ls_sql As String
        Dim dt As DataTable
        Dim lboperado As Boolean = False

        Try
            Otrans.open()
            myOtrans.open()
            ods.Tables("verificacion_barras").DefaultView.Sort = "barra_nueva"
            For Each drv In ods.Tables("verificacion_barras").DefaultView

                If (drv.Item("barra_nueva").ToString.Trim.Length = 0 Or _
                    drv.Item("barra_nueva").ToString.Trim.Length > 15) Or _
                    Not IsNumeric(drv.Item("barra_nueva").ToString) Then
                    ls_sql = "pa_del_um_prodcodbarra '" & gs_empresa & "','" & drv.Item("cod_flex").ToString & "',3"
                    Otrans.Elimina(ls_sql)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show(Otrans.descripcion_error)
                    Else
                        lboperado = True
                    End If

                Else
                    ls_sql = "pa_sel_um_prodcodbarra '" & gs_empresa & "','" & drv.Item("cod_flex").ToString & "'"
                    dt = Otrans.Obtiene(ls_sql)
                    dt.DefaultView.RowFilter = "Linea=3"
                    If dt.DefaultView.Count > 0 Then
                        ls_sql = "pa_upd_um_prodcodbarra '" & gs_empresa & "','" & drv.Item("cod_flex").ToString & "','" & _
                                drv.Item("barra_nueva").ToString & "',3"
                        Otrans.Actualiza(ls_sql)
                        If Otrans.Codigo_error > 0 Then
                            MessageBox.Show(Otrans.descripcion_error)
                        Else
                            lboperado = True
                        End If
                    Else
                        dt.DefaultView.RowFilter = ""
                        If dt.Rows.Count > 0 Then
                            ls_sql = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & drv.Item("barra_nueva").ToString & "','" & _
                                    drv.Item("cod_flex").ToString & "','" & dt.Rows(0).Item("Unidad").ToString & "'," & _
                                    dt.Rows(0).Item("Factor").ToString & ",3," & dt.Rows(0).Item("FactorUb").ToString & ",'" & _
                                    dt.Rows(0).Item("TipoCodigo").ToString & "'"
                            Otrans.Ingresa(ls_sql)
                            If Otrans.Codigo_error > 0 Then
                                MessageBox.Show(Otrans.descripcion_error)
                            Else
                                lboperado = True
                            End If
                        Else
                            ls_sql = "pa_ins_um_prodcodbarra"

                        End If

                    End If
                End If

                If lboperado Then
                    ls_sql = "call pa_upd_um_inv_producto_verificacion_barras (" & _
                            gi_cod_empresa_onbase & ",'" & drv.Item("cod_flex").ToString & "')"
                    myOtrans.Actualiza(ls_sql)


                    lboperado = False
                End If







            Next



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Private Sub Seleccionar_usuario()
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
            dr.Item("cod_conteo") = Me.NumericUpDown1.Value
            dr.Item("usuario") = ods.Tables("usuario").Rows(0).Item("usuario")
            ods.Tables("encabezado_conteo").Rows.Add(dr)


        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Function Crear_Tabla_Temporal(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn

        dt = dv.Table.Clone

        For Each dgc In Me.dgv_conteo.Columns
            If dgc.Visible = False Then
                dt.Columns.Remove(dgc.Name)
            End If
        Next

        For Each drv In dv
            dr = dt.NewRow
            For Each dc In dt.Columns
                dr.Item(dc.ColumnName) = drv.Item(dc.ColumnName)
            Next
            dt.Rows.Add(dr)
        Next

        Return dt


    End Function


    Private Sub Exportar_Vista_Actual()
        Dim mExcel As New Automatizar.exportar_excel

        Dim dc As DataGridViewColumn
        Dim dt As DataTable

        Try

            dt = Crear_Tabla_Temporal(ods2.Tables("conteos").DefaultView)

            mExcel.ocultar_columnas = ""

            mExcel.sFileName = "c:\temp\Conteo_" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_conteo.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
        Finally

            mExcel = Nothing

        End Try


    End Sub

    Private Sub frm_inventarios_fisicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   gs_empresa = "VINOTECA"
        Crear_Estructura()
        Crear_Estructura_Revision()
        Llenar_Combos()
    End Sub


    Private Sub txt_buscar1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress, txt_buscar2.KeyPress, txt_buscar3.KeyPress, txt_buscar4.KeyPress, txt_buscar5.KeyPress, txt_buscar6.KeyPress
        If e.KeyChar = Chr(13) Then
            Hacer_Busqueda()
        End If
    End Sub


    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Hacer_Busqueda()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Esta Seguro que es el Conteo No." & Chr(13) & _
                            "        " & Me.NumericUpDown1.Value.ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Generar_Archivo_PDA()
        End If

    End Sub


    Private Sub btn_obtener_archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_obtener_archivos.Click, btn_obtener_informacion2.Click
        Realizar_Recepcion()
        Mostrar_Barras()
        Mostrar_Conteos()
    End Sub

    Private Sub btn_actualizar_Barras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar_Barras.Click
        If MessageBox.Show("Esta Seguro de Actualizar Los Productos En FlexLine", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Actualizar_Barras_Flex()
        End If
    End Sub

    Private Sub btn_enviar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_Excel.Click
        Exportar_Vista_Actual()
    End Sub

    

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged, cmbEmpresa.SelectedIndexChanged, cmbConteos.SelectedIndexChanged
        Try
            ods2.Tables("conteos").DefaultView.RowFilter = "cod_conteo = " & Me.cmbConteos.SelectedValue & " and bodega = '" & Me.cmbBodega.SelectedValue & "' and empresa = '" & Me.cmbEmpresa.SelectedValue & "'"
        Catch ex As Exception

        End Try
    End Sub
End Class