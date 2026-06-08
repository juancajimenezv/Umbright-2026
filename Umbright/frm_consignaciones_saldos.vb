
Public Class frm_consignaciones_saldos
    Dim Ods As DataSet

    Private Sub Crear_Estructura()
        Ods = New DataSet

        Dim dt = New DataTable("productos")

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Modificado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Conteo_1", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Conteo_2", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Conteo_3", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Conteo_4", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Conteo_5", GetType(Integer)))

        Ods.Tables.Add(dt.Copy)


        dt = New DataTable("historial")
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("consignacion", GetType(String)))
        Ods.Tables.Add(dt.Copy)

        dt = New DataTable("clientes_envio")
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        dt.Columns(0).Unique = True

        Ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub Llenar_Listado_Clientes()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            myOtrans.open()

            ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.rows.count() = 0 Then
                ls_sql = "pa_sel_um_consignaciones_saldos_cliente_ren null,'" & gs_empresa & "'"
                dt = Otrans.Obtiene(ls_sql)

            End If

            For Each dr In dt.Rows
                Ods.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("con_cliente") & "'"
                If Ods.Tables("clientes_envio").DefaultView.Count = 0 Then
                    dr_aux = Ods.Tables("clientes_envio").NewRow
                    dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                    dr_aux.Item("Razon_Social") = dr.Item("RazonSocial")
                    Ods.Tables("clientes_envio").Rows.Add(dr_aux)
                End If
            Next

            ''Lleno los clientes aprobados sin saldo
            ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & gi_cod_empresa_onbase.ToString & ",NULL,NULL)"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                Try
                    Ods.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("cod_cliente_flex") & "'"
                    If Ods.Tables("clientes_envio").DefaultView.Count = 0 Then
                        dr_aux = Ods.Tables("clientes_envio").NewRow
                        dr_aux.Item("cod_cliente") = dr.Item("cod_cliente_flex")
                        dr_aux.Item("Razon_Social") = Buscar_Cliente_dc(dr.Item("cod_cliente_flex"))
                        Ods.Tables("clientes_envio").Rows.Add(dr_aux)
                    End If

                Catch ex As Exception
                End Try
            Next


           
            Ods.Tables("clientes_envio").DefaultView.RowFilter = ""
            Me.dgv_clientes.DataSource = Ods.Tables("clientes_envio").DefaultView
            ClsGen.Alinear_GridView(Ods.Tables("clientes_envio"), Me.dgv_clientes, "", "", ",cod_cliente,razon_social,", "", False, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Mostrar_Cliente()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt_fechas As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim ls_sql As String
        Dim nombre_columnas As String = ""
        Dim icount As Integer


        Try
            Otrans.open()
            myOtrans.open()
            Ods.Tables("productos").Rows.Clear()

            ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & gi_cod_empresa_onbase.ToString & ",'" & Me.txt_codigo_cliente_dc.Text & "',NULL)"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr_aux = Ods.Tables("productos").NewRow
                dr_aux.Item("codigo") = dr.Item("cod_producto_flex")
                dr_aux.Item("descripcion") = ""
                dr_aux.Item("Saldo") = 0
                dr_aux.Item("Aprobado") = dr.Item("cantidad_maxima")
                dr_aux.Item("modificado") = 0
                Ods.Tables("productos").Rows.Add(dr_aux)
            Next

            ls_sql = "pa_sel_um_consignaciones_saldos_cliente '" & Me.txt_codigo_cliente_dc.Text & "','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.ROWS.COUNT = 0 Then
                ls_sql = "pa_sel_um_consignaciones_saldos_cliente_REN '" & Me.txt_codigo_cliente_dc.Text & "','" & gs_empresa & "'"
                dt = Otrans.Obtiene(ls_sql)

            End If

            For Each dr In dt.Rows
                Ods.Tables("productos").DefaultView.RowFilter = "codigo = '" & dr.Item("con_producto").ToString & "'"
                If Ods.Tables("productos").DefaultView.Count > 0 Then
                    Ods.Tables("productos").DefaultView(0)("descripcion") = dr.Item("con_desc")
                    Ods.Tables("productos").DefaultView(0)("Saldo") = dr.Item("Saldo")
                Else
                    dr_aux = Ods.Tables("productos").NewRow
                    dr_aux.Item("codigo") = dr.Item("con_producto")
                    dr_aux.Item("descripcion") = dr.Item("con_desc")
                    dr_aux.Item("Saldo") = dr.Item("Saldo")
                    dr_aux.Item("Aprobado") = 0
                    dr_aux.Item("modificado") = 0
                    Ods.Tables("productos").Rows.Add(dr_aux)
                End If
            Next


            Ods.Tables("productos").DefaultView.RowFilter = "descripcion = ''"

            For Each drv In Ods.Tables("productos").DefaultView
                dt = Obtener_Producto(drv.Item("codigo"))
                If dt.Rows.Count > 0 Then
                    drv.Item("descripcion") = dt.Rows(0).Item("glosa").ToString
                End If
            Next

            Ods.Tables("productos").DefaultView.RowFilter = ""







            ''Lenar_Encabezado_Conteos

            ''Llenar Conteos
            ls_sql = "call pa_var_um_crm_cliente_producto_consignacion_conteo_fechas ('" & Me.txt_codigo_cliente_dc.Text & "')"
            dt_fechas = myOtrans.Obtiene(ls_sql)

            ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo (" & gi_cod_empresa_onbase & ",'" & Me.txt_codigo_cliente_dc.Text & "',NULL)"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr In dt_fechas.Rows
                dt.DefaultView.RowFilter = "cod_conteo = " & dr.Item("cod_conteo") 'fecha = '" & DateTime.Parse(dr.Item("fecha").ToString).ToString("yyyy-MM-dd") & "'"
                icount += 1
                ls_sql = "conteo_" & icount.ToString
                For Each drv In dt.DefaultView

                    Ods.Tables("productos").DefaultView.RowFilter = "codigo = '" & drv.Item("cod_producto_flex").ToString & "'"
                    If Ods.Tables("productos").DefaultView.Count > 0 Then
                        Ods.Tables("productos").DefaultView(0).Item(ls_sql) = drv.Item("conteo")
                    End If
                Next
                nombre_columnas += "," & ls_sql & "=" & DateTime.Parse(dr.Item("fecha").ToString).ToString("dd/MM/yyyy") & ","

            Next


            Ods.Tables("productos").DefaultView.RowFilter = ""


            Me.dgv_productos.DataSource = Nothing
            Me.dgv_productos.DataSource = Ods.Tables("productos")

            ClsGen.Alinear_GridView(Ods.Tables("productos"), Me.dgv_productos, "", _
                        ",modificado,", ",codigo,descripcion,saldo,conteo_1,conteo_2,conteo_3,conteo_4,conteo_5,", "", _
                        nombre_columnas, _
                        "", "", True, True, 300, 0)



            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Historial(ByVal _listado As Boolean, ByVal _producto As String, ByVal _cliente As String)
        'Dim nrow As Integer
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim ls_sql As String

        Try
            Otrans.open()
            'nrow = Me.dgv_productos.CurrentCell.RowIndex
            ls_sql = "pa_sel_um_consignaciones_saldos null,'" & gs_empresa & "','" & _cliente & "','" & _producto & "'"
            dt2 = Otrans.Obtiene(ls_sql)

            ls_sql = "pa_sel_um_consignaciones null,'" & gs_empresa & "','" & _cliente & "','" & _
                        _producto & "'"


            dt = Otrans.Obtiene(ls_sql)
            Ods.Tables("historial").Rows.Clear()

            For Each dr In dt.Rows
                ls_sql = "con_numero = '" & dr.Item("con_numero").ToString & "' and con_producto = '" & dr.Item("con_producto").ToString & "' and saldo <> 0"
                dt2.DefaultView.RowFilter = ls_sql

                If dt2.DefaultView.Count > 0 Then




                    dr_aux = Ods.Tables("historial").NewRow
                    dr_aux.Item("tipo") = dr.Item("fd_tipo")
                    If dr.Item("fd_tipo").ToString.ToLower.StartsWith("con") Then
                        dr_aux.Item("numero") = dr.Item("con_numero")
                        dr_aux.Item("fecha") = dr.Item("con_fecha")
                        dr_aux.Item("Cantidad") = dr.Item("con_cant")
                    Else
                        dr_aux.Item("numero") = dr.Item("fd_numero")
                        dr_aux.Item("fecha") = dr.Item("fd_fecha")
                        dr_aux.Item("Cantidad") = dr.Item("fd_cantidad")
                        dr_aux.Item("Consignacion") = dr.Item("con_numero")
                    End If


                    Ods.Tables("historial").Rows.Add(dr_aux)
                End If
            Next
            If _listado Then
                Me.dgv_listado_clientes_productos.DataSource = Ods.Tables("historial")
                ClsGen.Alinear_GridView(Ods.Tables("historial"), Me.dgv_listado_clientes_productos, "", "", "", "", True, True, 200, 0)

            Else
                Me.dgv_historial.DataSource = Ods.Tables("historial")
                ClsGen.Alinear_GridView(Ods.Tables("historial"), Me.dgv_historial, "", "", "", "", True, True, 200, 0)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Function Obtener_Producto(ByVal _codigo As String) As DataTable
        Dim dt As New DataTable
        Dim Oflex As New Umbral_Flex.productos


        Try
            dt = Oflex.Obtener_Producto(gs_empresa, _codigo)



        Catch ex As Exception
        Finally
            Oflex.close()
            Oflex = Nothing
        End Try

        Return dt
    End Function

    Private Sub Buscar_Producto_Listado()
        Dim dt As DataTable
        dt = Obtener_Producto(Me.txt_codigo_listado_producto.Text)

        If dt.Rows.Count > 0 Then
            Me.txt_nombre_listado_producto.Text = dt.Rows(0).Item("glosa").ToString
        End If


    End Sub

    Private Sub Buscar_Producto_Detalle_cliente()
        Dim dt As DataTable
        dt = Obtener_Producto(Me.txt_codigo_producto_dc.Text)

        If dt.Rows.Count > 0 Then
            Me.txt_descripcion_producto_dc.Text = dt.Rows(0).Item("glosa").ToString
        Else
            Me.txt_descripcion_producto_dc.Text = ""
            MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK)
        End If


    End Sub

    Private Sub Buscar_Saldos_Productos_Clientes()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & gs_empresa & "','" & Me.txt_codigo_listado_producto.Text & "'"
            dt = Otrans.Obtiene(ls_sql)
            Me.dgv_listado_productos_clientes_saldos.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgv_listado_productos_clientes_saldos, "", _
                                ",con_producto,con_desc,tipoctacte,", "", ",saldo,", ",con_cliente=codigo_cliente,", "", "", True, True, 250, 0)




        Catch ex As Exception
        Finally
            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Productos_Aprobados()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim bhuboerrores As Boolean = False



        Try
            myOtrans.Open()
            Ods.Tables("productos").DefaultView.RowFilter = "modificado = 1"
            For Each drv In Ods.Tables("productos").DefaultView
                ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & gi_cod_empresa_onbase.ToString & ",'" & Me.txt_codigo_cliente_dc.Text & "','" & drv.Item("codigo").ToString & "')"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    ls_sql = "call pa_upd_um_crm_cliente_producto_consignacion (" & gi_cod_empresa_onbase.ToString & ",'" & Me.txt_codigo_cliente_dc.Text & "','" & drv.Item("codigo").ToString & "'," & _
                            drv.Item("Aprobado").ToString & ",'" & gs_usuario & "')"
                    myOtrans.Actualiza(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        MessageBox.Show(myOtrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bhuboerrores = True
                    End If

                Else 'debo agregar
                    ls_sql = "call pa_ins_um_crm_cliente_producto_consignacion (" & gi_cod_empresa_onbase.ToString & ",'" & Me.txt_codigo_cliente_dc.Text & "','" & drv.Item("codigo").ToString & "'," & _
                                                drv.Item("Aprobado").ToString & ",'" & gs_usuario & "')"
                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        MessageBox.Show(myOtrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bhuboerrores = True
                    End If
                End If
            Next

            If Not bhuboerrores = True Then
                MessageBox.Show("Proceso Finalizado con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Proceso Finalizado con Errores", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
        Finally
            myOtrans.Close()
            myOtrans = Nothing
            Ods.Tables("productos").DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Function Buscar_Cliente_dc(ByVal pCodigoCliente As String) As String
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_nombre As String = ""


        Try
            oTrans.open()
            dt = oTrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & pCodigoCliente & "'")
            ls_nombre = dt.Rows(0).Item("nombre_cliente").ToString


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

        Return ls_nombre
    End Function

    Private Sub Limpiar_Pantalla()
        Me.txt_cantidad_aprobada_dc.Text = 0
        Me.txt_codigo_producto_dc.Text = ""
        Me.txt_codigo_cliente_dc.Text = ""
        Me.txt_descripcion_producto_dc.Text = ""
        Me.txt_nombre_cliente_dc.Text = ""
        Ods.Tables("productos").Rows.Clear()
        Ods.Tables("historial").Rows.Clear()



    End Sub

    Private Sub Verificar_Permisos()

        If tiene_permisos("mco_con_aprobar_cliente_productos") Then
            Me.btn_guardar.Visible = True
        Else
            Me.btn_guardar.Visible = False
        End If

    End Sub

    Private Sub frm_saldos_consignaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Verificar_Permisos()
        Crear_Estructura()
        Llenar_Listado_Clientes()
        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub



    Private Sub dgv_clientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_clientes.DoubleClick
        Dim nrow As Integer
        Try
            nrow = Me.dgv_clientes.CurrentCell.RowIndex
            Me.txt_codigo_cliente_dc.Text = Me.dgv_clientes.Item("cod_cliente", nrow).Value
            Me.txt_nombre_cliente_dc.Text = Me.dgv_clientes.Item("razon_social", nrow).Value

        Catch ex As Exception

        End Try
        Mostrar_Cliente()
    End Sub


    Private Sub dgv_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.DoubleClick
        Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex
        Mostrar_Historial(False, Me.dgv_productos.Item("codigo", nrow).Value.ToString, Me.txt_codigo_cliente_dc.Text)
    End Sub


    Private Sub dgv_productos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.CurrentCellChanged
        Try
            Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex
            Mostrar_Historial(False, Me.dgv_productos.Item("codigo", nrow).Value.ToString, Me.txt_codigo_cliente_dc.Text)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgv_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellValueChanged

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Me.dgv_productos.Item("modificado", e.RowIndex).Value = 1

        End If
    End Sub

    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Dim therow As DataGridViewRow
            therow = Me.dgv_productos.Rows(e.RowIndex)
            If therow.Cells("modificado").Value = 1 Then
                therow.DefaultCellStyle.ForeColor = Color.Blue

            End If

        End If
    End Sub

    Private Sub txt_codigo_listado_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_listado_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txt_codigo_listado_producto.Text.Length = 10 _
                And IsNumeric(Me.txt_codigo_listado_producto.Text.Substring(0, 1)) Then
                Buscar_Producto_Listado()
            Else
                Dim oform As New frm_busqueda_general
                oform.nombre_vista = ""
                oform.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                oform.parametros = "glosa,producto,tipoproducto,familia"
                oform.nombre_vista = "v_um_producto_busqueda"
                oform.lista_campos = "producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"
                oform.txt_buscar1.Text = Me.txt_codigo_listado_producto.Text

                oform.txt_buscar1.Focus()
                oform.dg_buscar.ReadOnly = False
                oform.btn_seleccion_multipe.Visible = False
                oform.Btn_Aceptar.Visible = True

                oform.ShowDialog(Me)
                Me.txt_codigo_listado_producto.Text = oform.resultado

                oform.Dispose()
                oform = Nothing
                Buscar_Producto_Listado()

            End If
        End If

    End Sub

    Private Sub btn_buscar_listado_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_listado_productos.Click
        Buscar_Saldos_Productos_Clientes()
    End Sub

    Private Sub dgv_listado_productos_clientes_saldos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado_productos_clientes_saldos.CurrentCellChanged
        Try
            Dim nrow As Integer = Me.dgv_listado_productos_clientes_saldos.CurrentCell.RowIndex
            If nrow > -1 Then
                Mostrar_Historial(True, Me.txt_codigo_listado_producto.Text, Me.dgv_listado_productos_clientes_saldos.Item("con_cliente", nrow).Value.ToString)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_codigo_producto_detalle_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto_dc.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txt_codigo_producto_dc.Text.Length = 10 _
                And IsNumeric(Me.txt_codigo_producto_dc.Text.Substring(0, 1)) Then
                Buscar_Producto_Detalle_cliente()
            Else
                Dim oform As New frm_busqueda_general
                oform.nombre_vista = ""
                oform.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                oform.parametros = "glosa,producto,tipoproducto,familia"
                oform.nombre_vista = "v_um_producto_busqueda"
                oform.lista_campos = "producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"
                oform.txt_buscar1.Text = Me.txt_codigo_producto_dc.Text

                oform.txt_buscar1.Focus()
                oform.dg_buscar.ReadOnly = False
                oform.btn_seleccion_multipe.Visible = False
                oform.Btn_Aceptar.Visible = True

                oform.ShowDialog(Me)
                Me.txt_codigo_producto_dc.Text = oform.resultado
                Me.txt_cantidad_aprobada_dc.Focus()

                oform.Dispose()
                oform = Nothing
                Buscar_Producto_Detalle_cliente()

            End If
            
        End If

    End Sub

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.Click
        Dim dr As DataRow
        Try
            dr = Ods.Tables("productos").NewRow()
            dr.Item("codigo") = Me.txt_codigo_producto_dc.Text
            dr.Item("descripcion") = Me.txt_descripcion_producto_dc.Text
            dr.Item("Saldo") = 0
            dr.Item("Aprobado") = Me.txt_cantidad_aprobada_dc.Text
            dr.Item("Modificado") = 1
            Ods.Tables("productos").Rows.Add(dr)

        Catch ex As Exception
        End Try


    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Guardar_Productos_Aprobados()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Limpiar_Pantalla()
    End Sub

    Private Sub txt_codigo_cliente_dc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_cliente_dc.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_nombre_cliente_dc.Text = ""
            If IsNumeric(Me.txt_codigo_cliente_dc.Text.Substring(0, 1)) Then

                Me.txt_nombre_cliente_dc.Text = Buscar_Cliente_dc(Me.txt_codigo_cliente_dc.Text)
            End If

            If Me.txt_nombre_cliente_dc.Text.Length = 0 Then
                Dim oform As New frm_busqueda_general
                oform.nombre_vista = ""
                oform.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                oform.parametros = "RazonSocial,CtaCte,Giro,Tipo,Ejecutivo"
                oform.nombre_vista = "v_um_ctacte_busqueda"
                oform.lista_campos = "CtaCte, RazonSocial,  Giro, Tipo, Ejecutivo, Vigencia_Cliente, Direccion"
                oform.txt_buscar1.Text = Me.txt_codigo_cliente_dc.Text

                oform.txt_buscar1.Focus()
                oform.dg_buscar.ReadOnly = False
                oform.btn_seleccion_multipe.Visible = False
                oform.Btn_Aceptar.Visible = True

                oform.ShowDialog(Me)
                Me.txt_codigo_cliente_dc.Text = oform.resultado


                oform.Dispose()
                oform = Nothing
                Me.txt_nombre_cliente_dc.Text = Buscar_Cliente_dc(Me.txt_codigo_cliente_dc.Text)
            End If
            Mostrar_Cliente()
            Me.txt_codigo_producto_dc.Focus()

        End If

    End Sub


End Class