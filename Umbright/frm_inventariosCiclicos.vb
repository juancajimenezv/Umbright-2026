Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Math
Public Class frm_inventariosCiclicos

    Dim ods As New DataSet("productos")
    Dim ods2 As New DataSet("Revision")

    Dim pdt As DataTable
    Dim existencia As Double
    Dim fecha As String
    Dim hora As String





    Private Sub Crear_Estructura_Revision()

        Dim icount As Integer
        If ods2.Tables.Contains("conteos") Then
            ods2.Tables.Remove("conteos")
        End If

        If ods2.Tables.Contains("conteos_usuarios") Then
            ods2.Tables.Remove("conteos_usuarios")
        End If
        Dim dt As New DataTable("conteos")
        dt.Columns.Add("empresa", GetType(String))
        'dt.Columns.Add("bodega", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        'dt.Columns.Add("Flex", GetType(Integer))
        dt.Columns.Add("CD_CANASTAS_CDC", GetType(Integer))
        dt.Columns.Add("CD_CENTRAL_CDC", GetType(Integer))
        dt.Columns.Add("CD_DEVOLUCIONES_CDC", GetType(Integer))
        dt.Columns.Add("CD_LIQUIDACION_CDC", GetType(Integer))
        dt.Columns.Add("CD_MAL_ESTADO_CDC", GetType(Integer))
        dt.Columns.Add("CD_PROMOCIONES_CDC", GetType(Integer))
        dt.Columns.Add("CD_PRONTA_ACCION_CDC", GetType(Integer))
        dt.Columns.Add("CD_REHABILITACION_CDC", GetType(Integer))
        dt.Columns.Add("CD_TRANSITO_CDC", GetType(Integer))

        dt.Columns.Add("CD_CANASTAS_DM", GetType(Integer))
        dt.Columns.Add("CD_CENTRAL_DM", GetType(Integer))
        dt.Columns.Add("CD_LIQUIDACION_DM", GetType(Integer))
        dt.Columns.Add("CD_MAL_ESTADO_DM", GetType(Integer))
        dt.Columns.Add("CD_PROMOCIONES_DM", GetType(Integer))
        dt.Columns.Add("CD_PRONTA_ACCION_DM", GetType(Integer))
        dt.Columns.Add("CD_REHABILITACION_DM", GetType(Integer))
        dt.Columns.Add("CD_TRANSITO_DM", GetType(Integer))

        dt.Columns.Add("CD_CANASTAS_DIU", GetType(Integer))
        dt.Columns.Add("CD_CENTRAL_DIU", GetType(Integer))
        dt.Columns.Add("CD_LIQUIDACION_DIU", GetType(Integer))
        dt.Columns.Add("CD_MAL_ESTADO_DIU", GetType(Integer))
        dt.Columns.Add("CD_PRONTA_ACCION_DIU", GetType(Integer))
        dt.Columns.Add("CD_TRANSITO_DIU", GetType(Integer))

        dt.Columns.Add("CD_CANASTAS_VI", GetType(Integer))
        dt.Columns.Add("CD_CENTRAL_VI", GetType(Integer))
        dt.Columns.Add("CD_LIQUIDACION_VI", GetType(Integer))
        dt.Columns.Add("CD_MAL_ESTADO_VI", GetType(Integer))
        dt.Columns.Add("CD_PRONTA_ACCION_VI", GetType(Integer))
        dt.Columns.Add("CD_TRANSITO_VI", GetType(Integer))
        dt.Columns.Add("TOTAL_EXISTENCIA", GetType(String))

        For icount = 1 To 20
            dt.Columns.Add("usuario_" & icount.ToString, GetType(String))
        Next

        dt.Columns.Add("DIFERENCIA", GetType(String))
        dt.Columns.Add("fecha", GetType(DateTime))
        dt.Columns.Add("cod_conteo", GetType(Integer))
        ods2.Tables.Add(dt)


        dt = New DataTable("conteos_usuarios")
        dt.Columns.Add("cod_usuario", GetType(String))
        dt.Columns.Add("usuario", GetType(String))
        ods2.Tables.Add(dt)



    End Sub

    Private Sub Crear_Estructura()

        Dim dt As DataTable

        If ods.Tables.Contains("usuarios") Then
            ods.Tables.Remove("usuarios")
        End If

        If ods.Tables.Contains("encabezado_conteo") Then
            ods.Tables.Remove("encabezado_conteo")
        End If
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
                        dr.Item("codigobarra").ToString & "')"

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
    Private Sub inicializar_inventarios()
       
        For Each dr2 As DataRow In ods2.Tables("conteos").Rows
            dr2.Item("CD_CANASTAS_CDC") = 0
            dr2.Item("CD_CENTRAL_CDC") = 0
            dr2.Item("CD_DEVOLUCIONES_CDC") = 0
            dr2.Item("CD_LIQUIDACION_CDC") = 0
            dr2.Item("CD_MAL_ESTADO_CDC") = 0
            dr2.Item("CD_PROMOCIONES_CDC") = 0
            dr2.Item("CD_PRONTA_ACCION_CDC") = 0
            dr2.Item("CD_REHABILITACION_CDC") = 0
            dr2.Item("CD_TRANSITO_CDC") = 0


            dr2.Item("CD_CANASTAS_DM") = 0
            dr2.Item("CD_CENTRAL_DM") = 0
            dr2.Item("CD_LIQUIDACION_DM") = 0
            dr2.Item("CD_MAL_ESTADO_DM") = 0
            dr2.Item("CD_PROMOCIONES_DM") = 0
            dr2.Item("CD_PRONTA_ACCION_DM") = 0
            dr2.Item("CD_REHABILITACION_DM") = 0
            dr2.Item("CD_TRANSITO_DM") = 0



            dr2.Item("CD_CANASTAS_DIU") = 0
            dr2.Item("CD_CENTRAL_DIU") = 0
            dr2.Item("CD_LIQUIDACION_DIU") = 0
            dr2.Item("CD_MAL_ESTADO_DIU") = 0
            dr2.Item("CD_PRONTA_ACCION_DIU") = 0
            dr2.Item("CD_TRANSITO_DIU") = 0
            dr2.Item("CD_CANASTAS_VI") = 0
            dr2.Item("CD_CENTRAL_VI") = 0
            dr2.Item("CD_LIQUIDACION_VI") = 0
            dr2.Item("CD_MAL_ESTADO_VI") = 0
            dr2.Item("CD_PRONTA_ACCION_VI") = 0
            dr2.Item("CD_TRANSITO_VI") = 0






        Next
    End Sub

    Private Function Mostrar_Conteos()
        Dim lbproceso_exito As Boolean = True
        Dim dr, dr2 As DataRow
        Dim dr_aux As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim liusuario As Integer



        Dim icount As Integer
        Dim ls_conteos As String = String.Empty
        Dim lb_encontrado As Boolean = False
        Dim ClsGen As New ClasesGenerales.General



        Try
            ods2.Tables("conteos").Rows.Clear()
            Otrans.open()
            myOtrans.open()
            ls_sql = "call pa_sel_um_inv_producto_inventarioCiclico ('" & Me.cmbEmpresa.Text & "')"
            'ls_sql = "call pa_sel_um_inv_producto_inventario (null)"
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
                Try
                    For Each dr2 In ods2.Tables("conteos").Rows
                        If dr2.Item("producto").ToString = dr.Item("cod_flex").ToString And _
                            dr2.Item("cod_conteo") = dr.Item("cod_conteo") And _
                            dr2.Item("empresa") = dr.Item("empresa") Then

                            dr2.Item("usuario_" & liusuario) = dr.Item("cantidad")
                            lb_encontrado = True
                            Exit For
                        End If

                    Next

                Catch ex As Exception

                End Try

             

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
                    '  dr_aux.Item("bodega") = dr.Item("bodega")
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    ods2.Tables("conteos").Rows.Add(dr_aux)

                    'If ls_conteos.IndexOf(dr.Item("cod_conteo")) = -1 Then
                    '    ls_conteos += dr.Item("cod_conteo").ToString & ","
                    'End If

                End If
                lb_encontrado = False
            Next

            Inicializar_Inventarios()


            'dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "empresa".Split(","))
            'Me.cmbEmpresa.DataSource = dt
            'Me.cmbEmpresa.ValueMember = "empresa"
            'Me.cmbEmpresa.DisplayMember = "empresa"


            'dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "bodega".Split(","))
            'Me.cmbBodega.DataSource = dt
            'Me.cmbBodega.ValueMember = "bodega"
            'Me.cmbBodega.DisplayMember = "bodega"

            'dt = ClsGen.ValoresDistinto(ods2.Tables("conteos"), "cod_conteo".Split(","))
            'Me.cmbConteos.DataSource = dt
            'Me.cmbConteos.ValueMember = "cod_conteo"
            'Me.cmbConteos.DisplayMember = "cod_conteo"


            Me.dgv_conteo.DataSource = ods2.Tables("conteos")
            'por defaul mostramos el ultimo conteo
            ods2.Tables("conteos").DefaultView.RowFilter = "cod_conteo = " & dt.Compute("Max(cod_conteo)", "cod_conteo>0")
            hora = CDate(ods2.Tables("conteos").DefaultView(0).Item("fecha").ToString).ToString("hh:mm:ss")

            If hora < "18:00:00" Then

                fecha = CDate(ods2.Tables("conteos").DefaultView(0).Item("fecha").ToString).AddDays(-1).ToString("dd/MM/yyyy")
            Else
                fecha = (CDate(ods2.Tables("conteos").DefaultView(0).Item("fecha").ToString).ToString("dd/MM/yyyy"))
            End If



            'ls_sql = "pa_var_um_existencias_producto_fecha null,null,'" & _
            '        ods2.Tables("conteos").DefaultView(0).Item("bodega") & "','" & _
            '        fecha & "'"

            'dt = Otrans.Obtiene(ls_sql)


            '@empresa as varchar(25)=null,
            '@producto as varchar(25)=NULL,
            '@bodega as varchar(20)=NULL,
            '@fechaFin as varchar(15)
            Dim totalCDC As Integer = 0
            Dim totalDM As Integer = 0
            Dim totalDIU As Integer = 0
            Dim totalVI As Integer = 0



            For Each drv As DataRowView In ods2.Tables("conteos").DefaultView
        
               
                ' ls_sql = "pa_var_um_xtmp_inventariosCiclicos_prueba  '" & Today.ToString("yyyyMM") & "','" & drv.Item("producto") & "'"
                ls_sql = "pa_var_um_xtmp_inventariosCiclicos_prueba  '" & drv.Item("producto") & "'"
                dt = Otrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    For Each drs As DataRow In dt.Rows
                        If drs.Item("empresa") = "CODICASA" Then

                            If drs.Item("bodega") = "CD_CANASTAS" Then
                                drv.Item("CD_CANASTAS_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_CENTRAL" Then
                                drv.Item("CD_CENTRAL_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_DEVOLUCIONES" Then
                                drv.Item("CD_DEVOLUCIONES_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_LIQUIDACION" Then
                                drv.Item("CD_LIQUIDACION_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_MAL_ESTADO" Then
                                drv.Item("CD_MAL_ESTADO_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_PROMOCIONES" Then
                                drv.Item("CD_PROMOCIONES_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_PRONTA_ACCION" Then
                                drv.Item("CD_PRONTA_ACCION_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If


                            If drs.Item("bodega") = "CD_REHABILITACION" Then
                                drv.Item("CD_REHABILITACION_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_TRANSITO" Then
                                drv.Item("CD_TRANSITO_CDC") = drs.Item("existenciaActual")
                                totalCDC += drs.Item("existenciaActual")
                            End If

                        ElseIf drs.Item("empresa") = "DMARTE1" Then
                            If drs.Item("bodega") = "CD_CANASTAS" Then
                                drv.Item("CD_CANASTAS_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_CENTRAL" Then
                                drv.Item("CD_CENTRAL_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If
                            If drs.Item("bodega") = "CD_LIQUIDACION" Then
                                drv.Item("CD_LIQUIDACION_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_MAL_ESTADO" Then
                                drv.Item("CD_MAL_ESTADO_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_PROMOCIONES" Then
                                drv.Item("CD_PROMOCIONES_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_PRONTA_ACCION" Then
                                drv.Item("CD_PRONTA_ACCION_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If


                            If drs.Item("bodega") = "CD_REHABILITACION" Then
                                drv.Item("CD_REHABILITACION_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_TRANSITO" Then
                                drv.Item("CD_TRANSITO_DM") = drs.Item("existenciaActual")
                                totalDM += drs.Item("existenciaActual")
                            End If

                        ElseIf drs.Item("empresa") = "DIUVA" Then
                            If drs.Item("bodega") = "CD_CANASTAS" Then
                                drv.Item("CD_CANASTAS_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_CENTRAL" Then
                                drv.Item("CD_CENTRAL_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If
                            If drs.Item("bodega") = "CD_LIQUIDACION" Then
                                drv.Item("CD_LIQUIDACION_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_MAL_ESTADO" Then
                                drv.Item("CD_MAL_ESTADO_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If



                            If drs.Item("bodega") = "CD_PRONTA_ACCION" Then
                                drv.Item("CD_PRONTA_ACCION_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If


                            If drs.Item("bodega") = "CD_TRANSITO" Then
                                drv.Item("CD_TRANSITO_DIU") = drs.Item("existenciaActual")
                                totalDIU += drs.Item("existenciaActual")
                            End If





                        ElseIf drs.Item("empresa") = "VINOTECA" Then
                            If drs.Item("bodega") = "CD_CANASTAS" Then
                                drv.Item("CD_CANASTAS_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_CENTRAL" Then
                                drv.Item("CD_CENTRAL_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If
                            If drs.Item("bodega") = "CD_LIQUIDACION" Then
                                drv.Item("CD_LIQUIDACION_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If

                            If drs.Item("bodega") = "CD_MAL_ESTADO" Then
                                drv.Item("CD_MAL_ESTADO_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If



                            If drs.Item("bodega") = "CD_PRONTA_ACCION" Then
                                drv.Item("CD_PRONTA_ACCION_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If


                            If drs.Item("bodega") = "CD_TRANSITO" Then
                                drv.Item("CD_TRANSITO_VI") = drs.Item("existenciaActual")
                                totalVI += drs.Item("existenciaActual")
                            End If

                        End If

                    Next
                    drv.Item("TOTAL_EXISTENCIA") = totalCDC + totalDM + totalDIU + totalVI
                    totalCDC = 0
                    totalDM = 0
                    totalDIU = 0
                    totalVI = 0

                    Try
                        drv.Item("DIFERENCIA") = Val(drv.Item("usuario_1").ToString) - Val(drv.Item("TOTAL_EXISTENCIA"))

                    Catch ex As Exception
                        drv.Item("DIFERENCIA") = 0
                    End Try

                End If
            Next


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            MessageBox.Show("Informacion Generada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Alinear_Grid_Conteos()
    End Function

    Private Sub Alinear_Grid_Conteos()

        Me.dgv_conteo.DataSource = ods2.Tables("conteos")
        'Me.dgv_conteo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
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

            mExcel.Nombre_Columnas = "," ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_conteo.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next
            mExcel.sEncabezado = "Conteo Fisico"

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
    End Sub



    Private Sub btn_obtener_archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_obtener_archivos.Click, btn_obtener_informacion2.Click
        'Realizar_Recepcion()
        ' Mostrar_Barras()
        Crear_Estructura()
        Crear_Estructura_Revision()
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