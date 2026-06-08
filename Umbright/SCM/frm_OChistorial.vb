Imports VB = Microsoft.VisualBasic
Public Class frm_OChistorial
    Dim ds, ds1, ds2, ods1, ods2, ods3 As New DataSet
    Private ps_nombre_vista As String = ""
    Public lista_campos As String
    Public conectar As String = String.Empty
    Public dt As DataTable
    Public ps_parametros_fijos As String
    Public numero_ As String

    Private Sub llenar_combobox()
        Me.cmb_valor1.Items.Add("Glosa")
        'Me.cmb_valor1.Items.Add("Origen")
        Me.cmb_valor1.Items.Add("Proveedor")
        Me.cmb_valor1.Items.Add("Orden_Compra")
        'Me.cmb_campos.Items.Add("")

        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")

        Me.cmb_valor1.Text = "Glosa"
        Me.cmb_1.Text = "like"
    End Sub

    Private Sub crear_estructura(ByVal tipo As String)

        Dim dt1 As DataTable

        dt1 = New DataTable("lista")
        ods1 = New DataSet
        Me.dgv_listado.DataSource = Nothing

        If tipo.ToString = "Producto" Then
            'Me.lista_campos = "producto,glosa,correlativo,fecha,razon_social"
            dt1.Columns.Add(New DataColumn("Numero", GetType(String)))
            dt1.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            dt1.Columns.Add(New DataColumn("Producto", GetType(String)))
            dt1.Columns.Add(New DataColumn("Glosa", GetType(Integer)))
            dt1.Columns.Add(New DataColumn("Fecha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha_Vencimiento", GetType(String)))
            dt1.Columns.Add(New DataColumn("Razon_social", GetType(String)))
            dt1.Columns.Add(New DataColumn("Proveedor", GetType(String)))
            ods1.Tables.Add(dt1)



        ElseIf tipo.ToString = "Proveedor" Then
            'lista_campos = "correlativo,tipodocto,numero,proveedor,fecha,analisis,tipoCta,fechaumodif"

            dt1.Columns.Add(New DataColumn("Numero", GetType(Integer)))
            dt1.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            dt1.Columns.Add(New DataColumn("Proveedor", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Analisis", GetType(String)))
            dt1.Columns.Add(New DataColumn("TipoCta", GetType(String)))
            dt1.Columns.Add(New DataColumn("FechaModif", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha_Vencimiento", GetType(String)))
            ods1.Tables.Add(dt1)

        ElseIf tipo.ToString = "Orden_Compra" Then
            ' lista_campos = "correlativo,tipodocto,numero,fecha,analisis,tipoCta,fechaumodif"
            dt1.Columns.Add(New DataColumn("Numero", GetType(Integer)))
            dt1.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Analisis", GetType(String)))
            dt1.Columns.Add(New DataColumn("TipoCta", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha_Vencimiento", GetType(String)))
            dt1.Columns.Add(New DataColumn("Proveedor", GetType(String)))
            ods1.Tables.Add(dt1)

        End If


        Me.dgv_listado.DataSource = ods1.Tables("lista")

    End Sub
    Private Sub crea_estructura_historial()

        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("historial")
        ods2 = New DataSet
        dt1.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
        dt1.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt1.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Usuario", GetType(String)))
        ods2.Tables.Add(dt1)
        Me.dgv_historial.DataSource = ods2.Tables("historial")


    End Sub
    Private Sub llenarCombos()

        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()



            ls_sql = "pa_sel_um_vi_unidadingreso '" & gs_empresa & "'"
            otabla = otrans.Obtiene(ls_sql)

            ds.Tables("tipo_unidad").Rows.Clear()

            For Each dr As DataRow In otabla.Rows
                Dim draux As DataRow = ds.Tables("tipo_unidad").NewRow
                draux.Item("unidad") = dr.Item("unidadingreso")
                ds.Tables("tipo_unidad").Rows.Add(draux)

            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub


    Private Sub CrearEstructura()

        Dim dt, dt2 As New DataTable
        Dim ClsGen As New ClasesGenerales.General
        dt = New DataTable
        ds = New DataSet


        ' estructura de productos
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad pedido", GetType(Integer)))
        dt.Columns.Add(New DataColumn("preciou", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("cantidad_facturada", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaVencimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("Codigo_proveedor", GetType(String)))
        '        dt.Columns("producto").Unique = True
        dt.TableName = "productos"

        Dim draux3 As DataRow = dt.NewRow

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)


        Dim dc As New ClasesGenerales.CalendarColumn
        dc.Name = "fechaVencimiento"
        dc.DataPropertyName = "fechaVencimiento"

        dt = New DataTable("tipo_unidad")
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        If Not ds.Tables.Contains("tipo_unidad") Then ds.Tables.Add(dt.Copy)


        ''Estructura de fechas
        dt2 = New DataTable("fechas")
        ds1 = New DataSet

        dt2.Columns.Add(New DataColumn("Tipo Documento", GetType(String)))
        dt2.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Fecha Vencimiento", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Usuario", GetType(String)))
        dt2.Columns.Add(New DataColumn("Orden", GetType(Integer)))
        ds1.Tables.Add(dt2)
        Me.dgv_fechas.DataSource = ds1.Tables("fechas")


    End Sub

    Private Sub crear_struc_comentario()
        Dim dt3 As New DataTable

        ''Estructura de Comentarios
        dt3 = New DataTable("comentarios")
        ds2 = New DataSet

        dt3.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt3.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt3.Columns.Add(New DataColumn("Usuario", GetType(String)))
        ds2.Tables.Add(dt3)
        Me.dgv_comentarios.DataSource = ds2.Tables("comentarios")

    End Sub




    Private Sub Crear_Estructura_documentacion()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("documentacion")
        ods3 = New DataSet

        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt1.Columns.Add(New DataColumn("Aplica", GetType(Boolean)))
        dt1.Columns.Add(New DataColumn("Lo tiene", GetType(Boolean)))
        dt1.Columns.Add(New DataColumn("Comentario", GetType(String)))
        ods3.Tables.Add(dt1)
        Me.dgv_control.DataSource = ods3.Tables("documentacion")

    End Sub


    Private Sub mostrarInformacionFAP()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, ls_sql, ls_sql2 As String
        Dim dt, dt2, dt3, dt4, dt5 As DataTable
        Dim draux, draux2 As DataRow
        'Dim dia, mes, mes_final, fecha_ As String
        Dim entra As Boolean = False


        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'FECHA ARRIBO PUERTO','" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            If dt.Rows.Count = 0 Then
                lsSQL = "pa_sel_um_documento_detalle_proveedor 'CONFIRMACION PROVEEDOR','" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
                dt = oTrans.Obtiene(lsSQL)
            End If

            ds.Tables("productos").Rows.Clear()




            ls_sql = "pa_sel_um_control_historialfechas '" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
            dt2 = oTrans.Obtiene(ls_sql)


            '1

            ls_sql = "pa_sel_um_control_historial_ingresofechas '" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
            dt3 = oTrans.Obtiene(ls_sql)


            If dt3.Rows.Count > 0 Then


                '2

                ls_sql = "pa_sel_um_control_historial_ingresofechasd '" & gs_empresa & "','" & dt3.Rows(0).Item("correlativo") & "'"
                dt4 = oTrans.Obtiene(ls_sql)



                '3
                If dt4.Rows.Count > 0 Then

                    ls_sql = "pa_sel_um_control_historial_fechaingreso '" & gs_empresa & "','" & dt4.Rows(0).Item("correlativo") & "'"
                    dt5 = oTrans.Obtiene(ls_sql)
                    Me.lbl_descripcion_Orden.Visible = True
                    Me.txt_no_Orden.Visible = True
                    Me.dtp_fecha_OrdenCompra.Visible = True
                    Me.lbl_fecha.Visible = True
                    Me.lbl_indicador.Visible = True

                    Me.lbl_indicador.Text = "Orden de Compra ya Ingresada"


                    Me.txt_no_Orden.Text = dt5.Rows(0).Item("numero").ToString
                    Me.dtp_fecha_OrdenCompra.Value = dt5.Rows(0).Item("fecha")
                    numero_ = dt5.Rows(0).Item("numero").ToString


                End If

            End If




            If dt2.Rows.Count > 0 Then

                For Each dr As DataRow In dt2.Rows
                    draux2 = ds1.Tables("fechas").NewRow

                    'If dr.Item("porcentajeasignado").ToString > 0 And entra = False Then
                    'entra = True

                    'End If
                    Dim norden As Integer
                    draux2.Item("Tipo Documento") = dr.Item("tipodocto")
                    draux2.Item("Fecha") = dr.Item("fecha")
                    draux2.Item("Fecha Vencimiento") = dr.Item("fechavcto")
                    draux2.Item("Usuario") = dr.Item("usuariomodif")

                    Select Case draux2.Item("tipo documento").ToString.ToLower
                        Case "orden de compra"
                            norden = 1
                        Case "confirmacion proveedor"
                            norden = 2
                        Case "fecha embarque"
                            norden = 3
                        Case "fecha confirmacion de embarque"
                            norden = 4
                        Case "fecha arribo puerto"
                            norden = 5
                        Case "fecha salida puerto de guatemala"
                            norden = 6
                        Case "fecha ingreso deposito aduanero"
                            norden = 7
                    End Select




                    draux2.Item("orden") = norden
                    ds1.Tables("fechas").Rows.Add(draux2)

                Next
                Me.dgv_fechas.DataSource = Nothing


                ds1.Tables("fechas").DefaultView.Sort = "orden"
                Me.dgv_fechas.DataSource = ds1.Tables("fechas").DefaultView
                clsGen.Alinear_GridView(ds1.Tables("fechas"), Me.dgv_fechas, ",fecha,Tipo Documento,Fecha Vencimiento,Usuario,", ",orden,", "", "", ",fecha=Fecha_Docto,fecha vencimiento=Fecha Venc/Ingreso,", ",Tipo Documento=250,Fecha Vencimiento=100,Usuario=90,", "", True, True, 200, 0)
                ds1.Tables("fechas").DefaultView.Sort = "orden"

            End If

            'If entra = True Then
            '    Me.lbl_indicador.Visible = True

            '    Me.lbl_indicador.Text = "Orden de Compra ya Ingresada"
            '    entra = False

            'End If

            ds.Tables("productos").Rows.Clear()
            Me.dgv_fap_productos.DataSource = Nothing
            Me.dgv_fap_productos.DataSource = ds.Tables("productos")


            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("vigencia").ToString.ToLower <> "a" And _
                    dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado


                    For Each dr As DataRow In dt.Rows
                        draux = ds.Tables("productos").NewRow
                        draux.Item("producto") = dr.Item("producto")
                        draux.Item("glosa") = dr.Item("glosa")
                        draux.Item("unidad") = dr.Item("unidadIngreso")
                        draux.Item("cantidad pedido") = dr.Item("cantidadIngreso")
                        draux.Item("preciou") = dr.Item("precioIngreso")
                        draux.Item("total") = dr.Item("subtotalIngreso")
                        draux.Item("cantidad_facturada") = dr.Item("valor1")
                        If dr.Item("valor2").ToString = "" Then
                            draux.Item("fechaVencimiento") = ""
                        Else
                            'dia = dr.Item("valor2").ToString
                            'mes = VB.Right(dia, 7)
                            'mes_final = VB.Left(mes, 2)
                            'dia = VB.Left(dia, 2)
                            'fecha_ = dia & "/" & mes_final

                            draux.Item("fechaVencimiento") = dr.Item("valor2").ToString.Substring(3)
                        End If
                        draux.Item("codigo_proveedor") = dr.Item("codigoproveedor")
                        Try
                            draux.Item("cantidad_facturada") = dr.Item("valor1").ToString
                        Catch ex As Exception

                        End Try
                        ds.Tables("productos").Rows.Add(draux)
                    Next



                    Me.dgv_fap_productos.DataSource = ds.Tables("productos")
                    Dim dgtbc As New DataGridViewComboBoxColumn
                    dgtbc.DataSource = ds.Tables("tipo_unidad")
                    dgtbc.ValueMember = "unidad"
                    dgtbc.DisplayMember = "unidad"
                    dgtbc.HeaderText = "unidad"
                    dgtbc.DataPropertyName = "unidad"
                    dgtbc.Name = "unidad"

                    clsGen.Alinear_GridViewComboBox(dgtbc)

                    clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_fap_productos, "", "", "unidad,preciou,cantidad pedido,glosa,total,codigo_proveedor,", ",cantidad pedido,preciou,total,", "", ",cantidad pedido=60,cantidad_facturada=60,unidad=40,fechaVencimineto=40,codigo_proveedor=60,", "", True, True, 200, 0)

                    Me.txt_fap_numeroOC.Enabled = False


                Else
                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                        'MessageBox.Show("Esta Orden de Compra No Esta Vigente, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' Me.txtNumeroOC.Text = String.Empty
                    Else
                        'MessageBox.Show("Esta Orden de Compra Esta Anulada o Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' Me.txtNumeroOC.Text = String.Empty
                    End If
                End If
            Else
                ' MessageBox.Show("Problemas con Esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Me.txtNumeroOC.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
            'totalizar()
        End Try
    End Sub

    Private Sub hacer_busqueda_vista(Optional ByVal conexion As String = "flexline")
        Dim ls_parametros As String
        Dim oTransaccion As Transaccional.Conexion
        Dim ls_Script As String
        Dim clGeneral As New ClasesGenerales.General
        Dim tipo As String


        ls_parametros = ""

        ps_parametros_fijos = " empresa = '" & gs_empresa & "' and tipodocto = 'Orden de Compra' and "
        If Me.cmb_valor1.Text = "Glosa" Then
            tipo = "Glosa"

            lista_campos = "Numero,Tipodocto,Producto,Glosa,Fecha,FechaVcto as Fecha_Vencimiento,Razonsocial,Proveedor"
            ps_nombre_vista = "v_documento_producto_historial"
            ' ps_nombre_vista = "documento"


        ElseIf Me.cmb_valor1.Text = "Proveedor" Then
            tipo = "Proveedor"
            lista_campos = "Numero,Tipodocto,Proveedor,Fecha,FechaVcto as Fecha_Vencimiento,Analisis,TipoCta,Fechaumodif,fechaAprueba"
            'ps_nombre_vista = "v_documento_proveedor_historial"
            ps_nombre_vista = "documento"


        ElseIf Me.cmb_valor1.Text = "Orden_Compra" Then
            tipo = "Numero"

            'lista_campos = "Numero,Tipodocto,Fecha,FechaVcto as Fecha_Vencimiento"
            lista_campos = "Numero,Tipodocto,Fecha,Analisis,TipoCta,FechaVcto as Fecha_Vencimiento,Proveedor"
            'ps_nombre_vista = "v_documento_proveedor_historial"
            ps_nombre_vista = "documento"
        End If

        If Me.txt_buscar1.Text.Length > 0 Then
            ls_parametros = ls_parametros & "d." & tipo & " " & _
                            Me.cmb_1.Text & " ''" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "''"



            oTransaccion = New Transaccional.Conexion(conexion)
            oTransaccion.open()
            If Me.cmb_valor1.Text = "Glosa" Then
                ls_parametros = "p." & tipo & " " & _
                                            Me.cmb_1.Text & " ''" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "''"

                ls_Script = "pa_var_um_oc_documento_producto_historial '" & gs_empresa & "','" & ls_parametros & "'"
            Else
                ls_Script = "pa_var_um_oc_documento_historial '" & gs_empresa & "','" & ls_parametros & "'"
                '                ls_Script = "Select " & Me.lista_campos & " From " & ps_nombre_vista & " Where " & ps_parametros_fijos & " (" & ls_parametros & ")"
            End If


            Try
                dt = oTransaccion.Obtiene(ls_Script)
                Me.dgv_listado.DataSource = dt

                If Me.cmb_valor1.Text = "Glosa" Then
                    clGeneral.Alinear_GridView(dt, Me.dgv_listado, ",Numero,Tipodocto,Producto,Glosa,Fecha,Fecha_Vencimiento,Proveedor,fecha_Ingreso,aprobacion,fecha_aprueba,usuario_aprueba,numero_ingreso,", "", "", "", ",fecha_ingreso=fecha Real Ingreso,", ",Numero=70,Tipodocto=130,Producto=70,Glosa=230,Fecha=90,Fecha_Vencimiento=90,Proveedor=150,aprobacion=40,", "", True, True, 250, 10)

                Else
                    'If Me.cmb_valor1.Text = "Proveedor" Then
                    clGeneral.Alinear_GridView(dt, Me.dgv_listado, ",Numero,Tipodocto,Proveedor,fecha,Analisis,TipoCta,FechaModif,Fecha_Vencimiento,fecha_ingreso,aprobacion,fecha_aprueba,usuario_aprueba,numero_ingreso,", ",Analisis,TipoCta,FechaModif,", "", "", ",fecha_ingreso=Fecha Real Ingreso,", ",Numero=70,Tipodocto=130,Proveedor=200,Fecha=90,Fecha_Vencimiento=90,aprobacion=40,", ",tipodocto,numero,", True, True, 250, 10)

                    'ElseIf Me.cmb_valor1.Text = "Orden_Compra" Then
                    'clGeneral.Alinear_GridView(dt, Me.dgv_listado, ",Numero,Tipodocto,Fecha,Analisis,TipoCta,Fecha_Vencimiento,Proveedor,fecha_ingreso,", ",Analisis,TipoCta,", "", "", ",fecha_ingreso=Fecha Real Ingreso,", ",Numero=80,Tipodocto=130,Fecha=90,Fecha_Vencimiento=90,Proveedor=190,", "", True, True, 250, 10)

                End If

                Me.dgv_listado.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 6.5)

            Catch ex As Exception
            Finally
            End Try
            oTransaccion.close()
            oTransaccion = Nothing
            clGeneral = Nothing
        End If


    End Sub

    Private Sub llenar_informacion()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql, ls_sql2 As String
        Dim dt, dt2 As DataTable
        Dim dr, dr2, dr_aux As DataRow
        Dim total_registros, contador As Integer
        Dim i As Integer

        Dim oTransC As New Transaccional.Conexion("SCM")
        Crear_Estructura_documentacion()
        ods3.Tables("documentacion").Rows.Clear()

        Try
            oTransC.open()


            ls_sql = "pa_sel_um_gen_tabcod_oc  NULL,'GEN_DOCUMENTACION_OC','UMBRAL'"
            dt = oTransC.Obtiene(ls_sql)
            ls_sql2 = "pa_sel_um_oc_documentacion  '" & gs_empresa & "','" & Me.txt_fap_numeroOC.Text & "'"
            dt2 = oTransC.Obtiene(ls_sql2)




            If dt2.Rows.Count <= dt.Rows.Count And dt2.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count
                    'If dt2.Rows.Count <= dt.Rows.Count Then

                    For Each dr2 In dt2.Rows

                        total_registros = dt2.Rows.Count
                        dr_aux = ods3.Tables("documentacion").NewRow
                        If dt.Rows(i).Item("descripcion").ToString = dr2.Item("documentooc").ToString Then
                            dr_aux.Item("Descripcion") = dt.Rows(i).Item("descripcion")
                            dr_aux.Item("Aplica") = dr2.Item("asignado")
                            dr_aux.Item("Lo tiene") = dr2.Item("tiene")
                            dr_aux.Item("Comentario") = dr2.Item("comentario")
                            ods3.Tables("documentacion").Rows.Add(dr_aux)
                            contador = 0
                            Exit For
                        Else
                            contador = contador + 1
                            If contador = total_registros Then
                                dr_aux.Item("Descripcion") = dt.Rows(i).Item("descripcion")
                                dr_aux.Item("Aplica") = 0
                                dr_aux.Item("Lo tiene") = 0
                                dr_aux.Item("Comentario") = ""
                                ods3.Tables("documentacion").Rows.Add(dr_aux)
                                contador = 0
                                Exit For
                            End If
                        End If

                    Next


                    ' end if
                    clsgen.Alinear_GridView(ods3.Tables("documentacion"), Me.dgv_control, ",Descripcion,Aplica,Lo tiene,Comentario,", "", ",Descripcion,Aplica,Lo tiene,Comentario,", "", "", ",Descripcion=250,Aplica=50,Lo tiene=70,Comentario=450,", "", True, True, 200, 0)

                    '  End If
                Next




            Else

                For Each dr In dt.Rows

                    dr_aux = ods3.Tables("documentacion").NewRow
                    dr_aux.Item("Descripcion") = dr.Item("descripcion")
                    dr_aux.Item("Aplica") = 0
                    dr_aux.Item("Lo tiene") = 0
                    ods3.Tables("documentacion").Rows.Add(dr_aux)
                Next
                clsgen.Alinear_GridView(ods3.Tables("documentacion"), Me.dgv_control, ",Descripcion,Aplica,Lo tiene,Comentario,", "", ",Descripcion,Aplica,Lo tiene,Comentario,", "", "", ",Descripcion=250,Aplica=50,Lo tiene=70,Comentario=450,", "", True, True, 200, 0)
            End If

            Me.dgv_control.ForeColor = Color.Black
        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
        End Try
    End Sub



    Private Sub frm_OChistorial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combobox()


    End Sub

    Private Sub llenar_comentarios(ByVal Pnumero)

        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt, dt2, dt3, dt4, dt5 As DataTable
        Dim dr, dr2, dr_aux, dr_aux2 As DataRow
        Dim entro As Integer
        Dim i As Integer
        Dim acceso As Boolean = False
        Dim oTransC As New Transaccional.Conexion("Flexline")


        crear_struc_comentario()

        ds2.Tables("comentarios").Rows.Clear()


        Try

            oTransC.open()


            ls_sql = "pa_sel_um_control_historialdoc_com '" & gs_empresa & "','" & Pnumero & "'"
            dt5 = oTransC.Obtiene(ls_sql)


            If dt5.Rows.Count > 0 Then

                For Each dr In dt5.Rows
                    dr_aux2 = ds2.Tables("comentarios").NewRow
                    dr_aux2.Item("Comentario") = dr.Item("comentario").ToString
                    dr_aux2.Item("Fecha") = dr.Item("fecha_grabo").ToString
                    dr_aux2.Item("Usuario") = dr.Item("usuario_grabo")
                    ds2.Tables("comentarios").Rows.Add(dr_aux2)
                Next

                clsgen.Alinear_GridView(ds2.Tables("comentarios"), Me.dgv_comentarios, ",Comentario,Fecha,Usuario,", "", "", "", "", ",Comentario=550,Fecha=110,Usuario=60,", "", True, True, 200, 0)

            End If

        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
        End Try


    End Sub

    Private Sub llenar_historial(ByVal Pnumero As String)
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt, dt2, dt3, dt4, dt5 As DataTable
        Dim dr, dr2, dr_aux, dr_aux2 As DataRow
        Dim entro As Integer
        Dim i As Integer
        Dim acceso As Boolean = False
        Dim oTransC As New Transaccional.Conexion("Flexline")

        crea_estructura_historial()
        CrearEstructura()
        ds.Tables("productos").Rows.Clear()
        ds1.Tables("fechas").Rows.Clear()
        ods2.Tables("historial").Rows.Clear()
        Try

            oTransC.open()
            ls_sql = "pa_sel_um_control_historialdoc '" & gs_empresa & "','" & Pnumero & "'" 'trae los documentos con exepcion de 'GEN_DOCUMENTACION_OC'
            dt = oTransC.Obtiene(ls_sql)

            ls_sql = "pa_sel_um_control_docultimo '" & gs_empresa & "','" & Pnumero & "'"  ' trae el ultimo documento tipo 'GEN_DOCUMENTACION_OC'
            dt2 = oTransC.Obtiene(ls_sql)

            ls_sql = "pa_sel_um_control_dochistorial '" & Pnumero & "','" & gs_empresa & "'" 'trae el conteo de los documentos que Aplica y Tiene

            dt3 = oTransC.Obtiene(ls_sql)

            ls_sql = "pa_sel_um_OChistorial '" & gs_empresa & "','" & Pnumero & "'" 'tra  datos para el encabezado
            dt4 = oTransC.Obtiene(ls_sql)

            ls_sql = "pa_sel_um_control_historialdoc_com '" & gs_empresa & "','" & Pnumero & "'"
            dt5 = oTransC.Obtiene(ls_sql)


            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    dr_aux = ods2.Tables("historial").NewRow
                    If dr.Item("tipodocto").ToString = "GEN_DOCUMENTACION_OC" Then
                        dr_aux.Item("Tipo_Documento") = "CONTROL DOCUMENTACION"
                        dr_aux.Item("Comentario") = dr.Item("comentario") & " Aplica(" & dt3.Rows(0).Item("asignado") & ") Tiene(" & dt3.Rows(0).Item("tiene") & ")"
                        dr_aux.Item("Fecha") = dr.Item("fecha_grabo").ToString
                        dr_aux.Item("Usuario") = dr.Item("usuario_grabo")
                        ods2.Tables("historial").Rows.Add(dr_aux)
                    Else
                        If dr.Item("estado").ToString = "T" Then

                            dr_aux.Item("Tipo_Documento") = dr.Item("tipodocto")
                            dr_aux.Item("Comentario") = " (INGRESO) " & dr.Item("comentario")
                            dr_aux.Item("Fecha") = dr.Item("fecha_grabo").ToString
                            dr_aux.Item("Usuario") = dr.Item("usuario_grabo")
                            ods2.Tables("historial").Rows.Add(dr_aux)

                        ElseIf (dr.Item("estado").ToString = "M" Or dr.Item("estado").ToString = "N") And dr.Item("tipodocto").ToString <> "GEN_OCTRACKING_COM" Then
                            dr_aux.Item("Tipo_Documento") = dr.Item("tipodocto")
                            dr_aux.Item("Comentario") = "(MODIFICACION) " & dr.Item("comentario")
                            dr_aux.Item("Fecha") = dr.Item("fecha_grabo").ToString
                            dr_aux.Item("Usuario") = dr.Item("usuario_grabo")
                            ods2.Tables("historial").Rows.Add(dr_aux)
                        ElseIf dr.Item("estado").ToString = "E" Then
                            dr_aux.Item("Tipo_Documento") = dr.Item("tipodocto")
                            dr_aux.Item("Comentario") = "(ELIMINACION) " & dr.Item("comentario")
                            dr_aux.Item("Fecha") = dr.Item("fecha_grabo").ToString
                            dr_aux.Item("Usuario") = dr.Item("usuario_grabo")
                            ods2.Tables("historial").Rows.Add(dr_aux)
                        End If


                    End If
                Next
            ElseIf dt2.Rows.Count > 0 Then
                For Each dr In dt2.Rows
                    dr_aux2 = ods2.Tables("historial").NewRow
                    dr_aux2.Item("Tipo_Documento") = "Asignacion de Documentos"
                    dr_aux2.Item("Comentario") = dr.Item("comentario") & "  Aplica(" & dt3.Rows(0).Item("asignado") & ")  Tiene(" & dt3.Rows(0).Item("tiene") & ")"
                    dr_aux2.Item("Fecha") = dr.Item("fecha_grabo").ToString
                    dr_aux2.Item("Usuario") = dr.Item("usuario_grabo")
                    ods2.Tables("historial").Rows.Add(dr_aux2)
                Next

            End If



            Me.txt_fap_numeroOC.Text = dt4.Rows(0).Item("correlativo")
            Me.txt_fap_numeroOC.Text = Me.txt_fap_numeroOC.Text.PadLeft(10, "0")
            Me.txtComentarioConfirmacion.Text = dt4.Rows(0).Item("comentario1").ToString
            Me.lbl_fap_Correlativo.Text = dt4.Rows(0)("correlativo")
            Me.txt_fap_proveedor.Text = dt4.Rows(0)("proveedor").ToString
            Me.dtpFechaVencimientoConfirmacion.Value = dt4.Rows(0).Item("fechaVcto")
            Me.dtpFechaDespacho.Value = dt4.Rows(0).Item("fechaDespacho")

            clsgen.Alinear_GridView(ods2.Tables("historial"), Me.dgv_historial, ",Tipo_Documento,Comentario,Fecha,Usuario,", "", "", "", "", ",Tipo_Documento=215,Comentario=375,Fecha=110,Usuario=60,", "", True, True, 200, 0)


            llenarCombos()
            mostrarInformacionFAP()
            llenar_informacion()
            llenar_comentarios(Me.txt_fap_numeroOC.Text)



        Catch ex As Exception
        Finally
            oTransC.close()
            oTransC = Nothing
        End Try



    End Sub



    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress


        If e.KeyChar = Chr(13) Then


            crear_estructura(Me.cmb_valor1.Text)

            If conectar = String.Empty Then
                hacer_busqueda_vista()
            Else
                hacer_busqueda_vista(conectar)
            End If
            ' Else
            '    hacer_busqueda_sp()

        End If

    End Sub

    Private Sub dgv_listado_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado.DockChanged

    End Sub





    Private Sub dgv_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado.DoubleClick
        Dim dr As DataRow
        Dim nRow As Integer
        Dim numero As String

        Try
            nRow = Me.dgv_listado.CurrentCell.RowIndex
            numero = Me.dgv_listado.Item("numero", nRow).Value.ToString
            Me.txt_fap_numeroOC.Text = String.Empty
            Me.txt_fap_proveedor.Text = String.Empty
            Me.txt_fap_numeroOC.Enabled = True
            Me.lbl_fap_Correlativo.Text = String.Empty
            Me.dtpFechaDespacho.Text = Today
            Me.dtpFechaVencimientoConfirmacion.Text = Today
            Me.dgv_control.DataSource = Nothing
            Me.lbl_indicador.Text = ""
            Me.txt_no_Orden.Visible = False
            Me.txt_no_Orden.Text = ""
            Me.lbl_descripcion_Orden.Visible = False
            Me.lbl_indicador.Visible = False
            Me.lbl_fecha.Visible = False
            Me.dtp_fecha_OrdenCompra.Visible = False
            Me.numero_ = 0

            llenar_historial(numero)
            Me.TabControl1.SelectedTab = Me.TabPage5


        Catch ex As Exception

        End Try

    End Sub







    Private Sub dgv_control_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_control.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try

            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_control.Rows(rowIndex)
                'If Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                '    therow.DefaultCellStyle.BackColor = Color.DarkSeaGreen '.PaleGreen   'LightGreen
                'ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False Then
                '    therow.DefaultCellStyle.BackColor = Color.DarkSalmon
                'End If


                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                    therow.DefaultCellStyle.BackColor = Color.DarkSeaGreen '.PaleGreen   'LightGreen
                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False And numero_ > 0 Then
                    therow.DefaultCellStyle.BackColor = Color.Tomato

                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = True And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False And numero_ = 0 Then
                    therow.DefaultCellStyle.BackColor = Color.Gold
                ElseIf Me.dgv_control.Item("Aplica", e.RowIndex).Value = False And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = False Then
                    therow.DefaultCellStyle.BackColor = Color.White

                End If
                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False Then
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = True
                Else
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = False
                End If
                If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                    Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = 0
                    therow.DefaultCellStyle.BackColor = Color.White
                End If



            End If


        Catch ex As Exception
        End Try
    End Sub



    Private Sub dgv_fap_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_fap_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try

            'If colIndex > -1 And rowIndex > -1 Then
            '    therow = Me.dgv_fap_productos.Rows(rowIndex)
            '    If Me.dgv_fap_productos.Item("cantidad pedido", e.RowIndex).Value <> Me.dgv_fap_productos.Item("cantidad_facturada", e.RowIndex).Value Then
            '        therow.DefaultCellStyle.ForeColor = Color.Tomato   '.PaleGreen   'LightGreen
            '        ' therow.DefaultCellStyle.ForeColor = Color.Blue
            '    End If


            'End If
            If colIndex > -1 Then

                therow = Me.dgv_fap_productos.Rows(rowIndex)
                'If therow.Cells("combo").Value.ToString() = "si" Then
                '    therow.DefaultCellStyle.ForeColor = Color.Green
                'Else
                If therow.Cells("Cantidad pedido").Value < therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                ElseIf therow.Cells("Cantidad pedido").Value > therow.Cells("cantidad_facturada").Value Then
                    therow.DefaultCellStyle.ForeColor = Color.Brown
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado.CellContentClick
    End Sub

    Private Sub txt_buscar1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar1.TextChanged
    End Sub
End Class