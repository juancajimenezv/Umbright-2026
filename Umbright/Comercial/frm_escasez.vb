Public Class frm_escasez
    Dim oDs As DataSet

    Private okToValidate As Boolean

    Private Sub crear_Estructura()
        Dim dt = New DataTable("canal")
        'ods_marca_subtipo = New DataSet

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(Double)))
        dt.Columns.Add(New DataColumn("todos", GetType(String)))
        dt.Columns("codigo").Unique = True 'Llave Unica

        'dt.Columns.Add(New DataColumn("Fecha_vencimiento", GetType(String)))
        'dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        'dt.Columns.Add(New DataColumn("Subtipo", GetType(String)))
        'dt.Columns.Add(New DataColumn("Imagen", GetType(String)))

        oDs.Tables.Add(dt)
        Me.dgvCanal.DataSource = oDs.Tables("Canal")


        dt = New DataTable("clientes")

        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("razonsocial", GetType(String)))
        dt.Columns.Add(New DataColumn("ejecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("canal", GetType(String)))

        dt.Columns(0).Unique = True

        oDs.Tables.Add(dt.Copy)

        Me.dgvCliente.DataSource = oDs.Tables("clientes")


        alinearGrid()
    End Sub

    Private Function buscarGlosaContaCanal(ByVal sCodigo As String, ByVal sTipo As String, ByRef sBum As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim sDescripcion As String = String.Empty

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_var_um_canales '" & sCodigo & "'")
            If dt.Rows.Count = 1 Then
                sDescripcion = dt.Rows(0).Item("texto4").ToString
                'sBum = dt.Rows(0).Item("texto4").ToString
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return sDescripcion
    End Function

    Private Sub alinearGrid()
        Dim clsGen As New ClasesGenerales.General
        'clsGen.Alinear_GridView(oDs.Tables("centro_costo"), Me.dgvCentroCosto, "", "", ",descripcion,", "", "", "", "", True, True, 250, 0)
        'clsGen.Alinear_GridView(oDs.Tables("gasto"), Me.dgvGasto, "", ",tipo,", ",descripcion,tipo,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(oDs.Tables("clientes"), Me.dgvCliente, "", "", ",razonsocial,ejecutivo,canal,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(oDs.Tables("canal"), Me.dgvCanal, "", ",descripcion,todos,", ",descripcion,", "", "", "", "", True, True, 250, 0)
        clsGen = Nothing


    End Sub

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Try
            dt = clsGen.selectQuery("FlexLine", "pa_var_um_bodega_escasez '" & gs_empresa & "'")
            Me.cmbBodega.DataSource = dt
            Me.cmbBodega.ValueMember = "CODIGO"
            Me.cmbBodega.DisplayMember = "CODIGO"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenarListado()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            lsSQL = "pa_var_um_producto_escasez_listado '" & gs_empresa & "'"
            dt = clsgen.selectQuery("SCM", lsSQL)

            Me.dgvListado.DataSource = dt
            clsgen.Alinear_GridView(dt, dgvListado, "", ",empresa,", "", "", ",id=Numero,", "", "", True, True, 250, 50)
        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try


    End Sub

    Private Sub frm_escasez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oDs = New DataSet

        crear_Estructura()
        llenarCombos()
        llenarListado()
        limpiarFormulario()
    End Sub

    Private Sub dgvCanal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanal.CellContentClick

    End Sub

    Private Sub dgvCanal_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanal.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try

            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvCanal.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvCanal.Columns(colIndex).Name.ToLower = "codigo" Then
                    Try

                        If Me.dgvCanal.Item("codigo", rowIndex).Value = "+" Then


                            Dim frm_busqueda As New frm_busqueda_general
                            ' frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo in ('" & IIf(Me.rbItem.Checked = True, "CON_ITEM", "CON_A&P") & "') and " 'con_item','con_a&p') and "
                            frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo = 'sysgold_ejecutivos' and substring(texto4,3,1) =  ')' and " 'con_item','con_a&p') and "
                            frm_busqueda.parametros = "texto4"
                            frm_busqueda.nombre_vista = "gen_tabcod"
                            frm_busqueda.lista_campos = "Distinct texto4 as codigo, texto4 as descripcion"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)
                            Try
                                If frm_busqueda.resultado.Length > 0 Then
                                    Me.dgvCanal.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                                Else
                                    Me.dgvCanal.Item("codigo", rowIndex).Value = ""
                                End If
                            Catch ex As Exception
                                Me.dgvCanal.Item("codigo", rowIndex).Value = ""
                            End Try

                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If

                        Dim sdescripcion As String = buscarGlosaContaCanal(Me.dgvCanal.Item("codigo", rowIndex).Value, "sysgold_ejecutivos", String.Empty)
                        'If sdescripcion.Trim.Length = 0 Then
                        '    sdescripcion = buscarGlosaConta(Me.dgvGasto.Item("codigo", rowIndex).Value, "CON_A&P")
                        'End If

                        Me.dgvCanal.Item("descripcion", rowIndex).Value = sdescripcion
                        If sdescripcion.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception
                    Finally


                    End Try

                End If
                If Me.dgvCanal.Columns(colIndex).Name.ToLower = "porcentaje" Then
                    Me.alinearGrid()

                End If
            End If

        Catch ex As Exception
        Finally
            alinearGrid()
        End Try
    End Sub

    Private Function Obtener_Cliente_tabla(ByVal pcod_cliente As String) As DataTable

        Dim ls_sql As String
        Dim lb_resultado As String = ""
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & pcod_cliente & "',NULL"
        otrans.open()
        dt = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        Return dt
    End Function

    Private Sub dgvCliente_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellValueChanged


        'newcurrentrow = Me.dg_clientes.CurrentCell.RowNumber
        'newcurrentcol = Me.dg_clientes.CurrentCell.ColumnNumber

        If e.ColumnIndex > 0 Then
            Exit Sub
        End If

        Dim ls_codigo As String
        Dim dt As DataTable
        Try
            ls_codigo = Me.dgvCliente.Item("ctacte", e.RowIndex).Value
            'totalizar(odataset.Tables("cotizacion_productos"))
        Catch ex As Exception
        End Try

        If ls_codigo = "+" Then
            ' Me.dg_clientes(oldcurrentrow, 0) = ""
            Try


                Dim frm_busqueda As New frm_busqueda_general

                frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                frm_busqueda.parametros = "CtaCte,RazonSocial,Giro,Ejecutivo,vigencia_cliente,canal"
                frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
                frm_busqueda.lista_campos = "Cast(0 as bit) as agregar, ctacte, RazonSocial, Giro, Ejecutivo, vigencia_cliente,ListaPrecio, canal "

                frm_busqueda.txt_buscar1.Focus()
                frm_busqueda.dg_buscar.ReadOnly = False
                frm_busqueda.btn_seleccion_multipe.Visible = True
                frm_busqueda.Btn_Aceptar.Visible = True
                frm_busqueda.dgv_listadoclientes.ReadOnly = False
                frm_busqueda.ShowDialog(Me)


                'Ods.Tables("clientes").Clear()
                'MyOtrans.open()
                'ls_sql = "call pa_sel_um_mmp_detalle_clientes ( " & _pcod_memo & ")"
                'dt = MyOtrans.Obtiene(ls_sql)
                'Me.dg_clientes(oldcurrentrow, 0) = ""
                Dim dr, dr_aux As DataRow
                Dim icount As Integer = 0

                For Each dr In frm_busqueda.dt.Rows
                    If dr.Item("agregar") = True Then
                        icount += 1
                        'If icount = 1 Then
                        '    ls_codigo = dr.Item("ctacte")
                        '    Me.dgvCliente.Item("ctacte", e.RowIndex).Value = ls_codigo

                        'Else
                        Try


                            dr_aux = oDs.Tables("clientes").NewRow
                            dr_aux.Item("ctacte") = dr.Item("ctacte")
                            'dt = Obtener_Cliente_tabla(dr.Item("ctacte"))
                            'If dt.Rows.Count > 0 Then
                            dr_aux.Item("razonSocial") = dr.Item("razonSocial")
                            dr_aux.Item("canal") = dr.Item("canal")
                            dr_aux.Item("Ejecutivo") = dr.Item("Ejecutivo")
                            ' End If


                            oDs.Tables("clientes").Rows.Add(dr_aux)
                        Catch ex As Exception

                        End Try
                        'End If
                    End If
                Next

                'For Each dr In oDs.Tables("clientes").Rows
                '    If dr.Item("ctacte") = "+" Or dr.Item("ctacte").ToString.Length = 0 Then
                '        dr.Delete()
                '    End If
                'Next

                'ls_codigo = frm_busqueda.resultado

                frm_busqueda.Dispose()
                frm_busqueda = Nothing
                alinearGrid()
                Me.dgvCliente.Item("ctacte", e.RowIndex).Value = ls_codigo
                validarClientes()
            Catch ex As Exception
                'Me.dgvCliente.Item("ctacte", e.RowIndex).Value = ""

            End Try

        End If

        If okToValidate And Not DatoValido(e.RowIndex, e.ColumnIndex, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            '    If oldcurrentcol = 1 Then ''La Validacion  del codigo del producto la hago en el nombre del producto
            '        Me.dg_clientes.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
            '    Else
            '        Me.dg_clientes.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            '    End If
            '    okToValidate = True
            'Else
            '    oldcurrentrow = newcurrentrow
            '    oldcurrentcol = newcurrentcol
            '    If newcurrentcol = 1 Then
            '        SendKeys.Send("{Tab}")
            '    End If

            '    If newcurrentcol = 2 Then
            '        SendKeys.Send("{Tab}")
            '    End If

        End If
        alinearGrid()
        validarClientes()
    End Sub

    Private Sub validarClientes()

        Try

            Dim lsFiltro As String = String.Empty

            For Each dr As DataRow In oDs.Tables("Canal").Rows

                If lsFiltro.Length = 0 Then
                    lsFiltro = "canal = '" & dr.Item("descripcion").ToString & "'"
                Else
                    lsFiltro = lsFiltro + " Or canal = '" & dr.Item("descripcion").ToString & "'"
                End If

            Next

            'si no ha ingresado canales 
            If lsFiltro.Length = 0 Then
                lsFiltro = "canal = 'vacio'"
            End If


            oDs.Tables("clientes").DefaultView.RowFilter = lsFiltro

            'For Each dr As DataRow In oDs.Tables("clientes").Rows
            '    If dr.Item("ctacte").ToString.Trim = "" Then

            '        dr.Delete()
            '        'dr_aux.Item("razonSocial") = dt.Rows(0).Item("nombre_cliente")
            '        'dr_aux.Item("canal") = dt.Rows(0).Item("canal")




            '        'End If
            '    End If
            'Next
        Catch ex As Exception


        End Try
    End Sub


    Private Function DatoValido(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True

        Try
            If col = 0 Then
                returnValue = Buscar_Cliente(dgvCliente.Item("ctacte", row).Value, row)
            End If

            'If col = 0 And (row = 0 Or row = 4) Then
            '    alinearGrid()
            'End If
        Catch ex As Exception

        End Try
        Return returnValue
    End Function

    Private Function Buscar_Cliente(ByVal pcod_cliente As String, ByVal posicion_grid As Integer)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim lb_resultado As Boolean = False

        dt = Obtener_Cliente_tabla(pcod_cliente)
        If dt.Rows.Count > 0 Then
            Me.dgvCliente.Item("razonsocial", posicion_grid).Value = dt.Rows(0).Item("nombre_cliente").ToString  'ls_sql 'otabla.Rows(0).Item("nombre_cliente")
            Me.dgvCliente.Item("canal", posicion_grid).Value = dt.Rows(0).Item("canal").ToString
            Me.dgvCliente.Item("ejecutivo", posicion_grid).Value = dt.Rows(0).Item("ejecutivo").ToString
            lb_resultado = True
        Else
            MessageBox.Show("Cliente No Existe")
        End If

        Return lb_resultado
    End Function



    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress, txtFechaGrabo.KeyPress
        'Enter
        If Asc(e.KeyChar()) = 13 Then
            Dim lsCodigo As String = txtProducto.Text
            limpiarFormulario()
            txtProducto.Text = lsCodigo
            buscarProducto(Me.txtProducto.Text)
        End If
    End Sub


    Private Sub buscarProducto(ByVal codigo_prod As String)
        '    Dim rTrans As New Transaccional.Conexion("scm")

        Dim dt As New DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        '   rTrans.open()

        Try
            lsSQL = "pa_sel_um_producto '" & gs_empresa & "', '" & codigo_prod & "'"
            '       dt_flex = rTrans.Obtiene(lsSQL)
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count = 1 Then
                'sql_st = "pa_sel_um_listaprecio_costo '" & gs_empresa & "', '" & codigo_prod & "'"
                'dt_flex_ = rTrans.Obtiene(sql_st)
                '           Me.txtCodigo.Text = codigo_prod


                Me.txtGlosa.Text = dt.Rows(0)("glosa").ToString
                Me.txtBU.Text = dt.Rows(0)("BU").ToString
                If dt.Rows(0).Item("Lote").ToString.ToUpper.Equals("S") Then
                    Me.lblLote.Visible = True
                    Me.txtLote.Visible = True

                End If

                If dt.Rows(0).Item("Serie").ToString.ToUpper.Equals("S") Then
                    Me.lblSerie.Visible = True
                    Me.txtSerie.Visible = True
                End If


                '           Me.txtObservacionesLinea.Focus()

                'If dt_flex_.Rows.Count > 0 Then
                '    Me.txt_precio.Text = dt_flex_.Rows(0)("valor")
                'Else
                '    Me.txt_precio.Text = 0
                '    MessageBox.Show("El producto no se encuentra en la lista de precios, Favor realizar la verificacion.", "Precio no Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    txt_descripcion.Text = ""
                '    Me.txt_cod_producto.Focus()

                '    Me.txt_cod_producto.SelectAll()


                'End If

                'If tiene_permisos("mco_facturacion_costo_marca") Then



                '    '' Para Bodega, buscar la Marca
                '    sql_st = "pa_var_um_marca_facturacion_costo '" & gs_empresa & "', '" & codigo_prod & "'"
                '    dt_flex = rTrans.Obtiene(sql_st)
                '    dt_flex = clsGen.ValoresDistinto(dt_flex, "cod_marca,descripcion".Split(","))
                '    If dt_flex.Rows.Count = 1 Then
                '        Me.txt_cod_marca.Text = dt_flex.Rows(0).Item("cod_marca")
                '    ElseIf dt_flex.Rows.Count > 1 Then
                '        Dim oform As New frm_resultado
                '        dt_flex = clsGen.ValoresDistinto(dt_flex, "cod_marca,descripcion".Split(","))
                '        oform.dgv_resultado.DataSource = dt_flex
                '        oform.ShowDialog()
                '        oform.Dispose()
                '        oform = Nothing
                '        Me.txt_cod_marca.Text = dt_flex.Rows(0).Item("cod_marca")
                '    ElseIf dt_flex.Rows.Count = 0 Then
                '    End If
                'End If




            Else
                MessageBox.Show("No se encontró el producto solicitado vuelva a intentarlo.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'limpiar_linea()

                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message)
        Finally

            clsGen = Nothing
        End Try

    End Sub

    Private Function validarSolicitud() As Boolean
        Dim lbSolicitudValida As Boolean = vbFalse
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try

            If Val(Me.lbl_numero_solicitud.Text) = 0 Then
                lbSolicitudValida = vbTrue
            Else
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud ya Creada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If Me.txtProducto.Text.Length = 10 Then
                lbSolicitudValida = vbTrue
            Else
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud Debe Agregar Informacion", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return vbFalse
            End If

            If Me.txtLote.Visible = True And Me.txtLote.Text.Trim.Length = 0 Then
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud Debe Ingresar Lote", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Return vbFalse
            End If

            If Me.txtSerie.Visible = True And Me.txtSerie.Text.Trim.Length = 0 Then
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud Debe Ingresar Serie (Añada)", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Return vbFalse
            End If

            If Not tiene_permisos(Me.txtBU.Text) Then
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud No tiene Permisos para Esta Opcion, " + Me.txtBU.Text, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return vbFalse

            End If



            If Me.txtBU.Text.Length > 5 Then
                lbSolicitudValida = vbTrue
            Else
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud No Tiene BU", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return vbFalse
            End If

            If oDs.Tables("canal").Rows.Count > 0 Then
                lbSolicitudValida = vbTrue
            Else
                lbSolicitudValida = vbFalse
                MessageBox.Show("No Puede Guardar una Solicitud Debe Agregar Canales", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return vbFalse
            End If





            'Validar Fechas
            If Me.dtp_final.Value >= Me.dtp_inicio.Value Then
                lbSolicitudValida = vbTrue
            Else
                lbSolicitudValida = vbFalse
                MessageBox.Show("La Fecha de Finalización no puede ser menor a la de Inicio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return vbFalse
            End If

            lbSolicitudValida = validarBUM

            'Validar Cantidades
            If lbSolicitudValida Then

                For Each dr As DataRow In oDs.Tables("canal").Rows
                    Try
                        If Double.Parse(dr.Item("cantidad").ToString) < 1 Then
                            MessageBox.Show("Existen Canales con Cantidades Incorrectas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            lbSolicitudValida = vbFalse
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Existen Canales con Cantidades Incorrectas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbSolicitudValida = vbFalse
                    End Try

                Next
                'oDs.Tables("canal").DefaultView.RowFilter = "cantidad < 1"
                '    If oDs.Tables("canal").DefaultView.Count > 0 Then
                '    MessageBox.Show("Existen Canales con Cantidades Incorrectas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    lbSolicitudValida = vbFalse
                'End If
                'oDs.Tables("canal").DefaultView.RowFilter = ""
                If Not lbSolicitudValida Then Return vbFalse
            End If


            'Validar producto, bodega y rango de fechas

            If lbSolicitudValida Then
                lsSQL = "pa_var_um_producto_escasez_validacion '" & gs_empresa & "','" & Me.txtProducto.Text & "','" & Me.cmbBodega.SelectedValue & "','" & dtp_inicio.Value.ToString("dd/MM/yyyy") & "'"
                dt = clsGen.selectQuery("SCM", lsSQL)
                If dt.Rows.Count > 0 Then
                    lbSolicitudValida = vbFalse
                    MessageBox.Show("Existen Definiciones Previas del Producto, Bodega y Fecha", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    If Not lbSolicitudValida Then Return vbFalse
                End If

            End If





        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

        Return lbSolicitudValida
    End Function

    Private Function validarBUM() As Boolean

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lbValido As Boolean = True

        Try

            ''(c) 20200429 Si es administrador puede aprobar
            If gi_tipo_usuario = 1 Then
                lbValido = True


            Else


                Otrans.open()
                lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa 16,'" & gs_usuario & "',null,'" & gs_empresa & "'"
                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.RowFilter = "cod_sub_menu = 40"
                    Dim dtBU As DataTable = oDs.Tables("detalle").Copy
                    dtBU = clsGen.ValoresDistinto(dtBU, "bu".Split(","))
                    For Each dr As DataRow In dtBU.Rows
                        dt.DefaultView.RowFilter = "descripcion = '" & Me.txtBU.Text & "'"
                        If dt.DefaultView.Count = 0 Then
                            MessageBox.Show("Hay Productos Que No Pertenecen a Unidad de Negocio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            lbValido = False
                            Exit For
                        End If
                    Next


                Else
                    'Para Vinoteca Cambia por que es mediante Lista de Precios Gabriela(Premium) Juan Carlos (Directo)
                    MessageBox.Show("El Solicitante No Tiene BU Asignada", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbValido = False
                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return lbValido
    End Function


    Private Sub guardarSolicitud()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim liID As Integer

        Try
            Otrans.open()
            lsSQL = "pa_ins_um_inv_producto_escasez '" & gs_empresa & "','" & Me.txtProducto.Text & "','" & Me.cmbBodega.SelectedValue & "','" & dtp_inicio.Value.ToString("dd/MM/yyyy") & "','" &
                dtp_final.Value.ToString("dd/MM/yyyy") & "','" & Me.txtDescripcion.Text & "','" & gs_usuario & "'"

            If Me.txtLote.Visible = True Then
                lsSQL = lsSQL + ",'" & Me.txtLote.Text & "'"
            Else
                lsSQL = lsSQL + ",null"
            End If


            If Me.txtSerie.Visible = True Then
                lsSQL = lsSQL + ",'" & Me.txtSerie.Text & "'"
            Else
                lsSQL = lsSQL + ",null"
            End If


            Otrans.Ingresa(lsSQL)
            lsSQL = "SELECT @@IDENTITY AS NewID"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                liID = dt.Rows(0).Item("NewID")

                Me.lbl_numero_solicitud.Text = liID

                For Each dr As DataRow In oDs.Tables("canal").Rows
                    lsSQL = "pa_ins_um_inv_producto_escasez_canal " & liID & ",'" & dr.Item("codigo").ToString & "'," & dr.Item("cantidad")

                    Otrans.Ingresa(lsSQL)
                Next

                For Each dr As DataRow In oDs.Tables("clientes").Rows
                    lsSQL = "pa_ins_um_inv_producto_escasez_cliente " & liID & ",'" & dr.Item("ctacte").ToString & "','" & dr.Item("canal").ToString & "'"
                    Otrans.Ingresa(lsSQL)
                Next


            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub editarSolicitud()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Try
            Otrans.open()

            lsSQL = "pa_upd_um_inv_producto_escasez '" & Me.lbl_numero_solicitud.Text & "','" & dtp_final.Value.ToString("dd/MM/yyyy") & "','" & Me.txtDescripcion.Text & " - Editado " & Now() & "','" & gs_usuario & "'"
            Otrans.Escribir_Log(lsSQL)
            Otrans.Actualiza(lsSQL)
            If Otrans.Codigo_error = 0 Then
                For Each dr As DataRow In oDs.Tables("canal").Rows
                    lsSQL = "pa_upd_um_inv_producto_escasez_canal " & Me.lbl_numero_solicitud.Text & ",'" & dr.Item("codigo").ToString & "'," & dr.Item("cantidad")

                    Otrans.Ingresa(lsSQL)
                Next

                MessageBox.Show("Proceso Finalizado con Exito!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Me.btnEditar.Visible = True Then
            If gs_usuario = Me.StatusBarPanel1.Text Then
                If MessageBox.Show("Esta Seguro de Guardar los Cambios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    editarsolicitud
                End If
            Else
                MessageBox.Show("Solo el Usuario que Grabo Puede Editar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        ElseIf MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If validarSolicitud() Then
                guardarSolicitud()
            End If
        End If
    End Sub

    Private Sub limpiarFormulario()

        Try


            Me.txtProducto.ReadOnly = False
            Me.cmbBodega.Enabled = True
            Me.dtp_inicio.Enabled = True
            Me.dtp_final.Enabled = True
            Me.txtDescripcion.ReadOnly = False

            Me.txtDescripcion.Text = String.Empty
            Me.txtProducto.Text = String.Empty
            Me.txtGlosa.Text = String.Empty
            Me.dtp_final.Value = Today
            Me.dtp_inicio.Value = Today

            Me.lbl_numero_solicitud.Text = "0"
            Me.oDs.Tables("canal").Rows.Clear()
            Me.oDs.Tables("clientes").Rows.Clear()

            Me.dgvCliente.ReadOnly = False
            Me.dgvCanal.ReadOnly = False

            Me.lblSerie.Visible = False
            Me.lblLote.Visible = False
            Me.txtSerie.Visible = False
            Me.txtLote.Visible = False
            Me.btnEditar.Visible = False

            Me.StatusBarPanel1.Text = String.Empty
            Me.StatusBarPanel2.Text = String.Empty

            Me.dgvCanal.AllowUserToDeleteRows = True

        Catch ex As Exception

        End Try


    End Sub



    Private Sub mostrarSolicitud(lidSolicitud As Integer)
        Dim dt As DataTable
        Dim lsSQL As String
        Dim clsgen As New ClasesGenerales.General

        Try

            Me.txtProducto.ReadOnly = True
            Me.cmbBodega.Enabled = False
            Me.dtp_inicio.Enabled = False
            Me.dtp_final.Enabled = False
            Me.txtDescripcion.ReadOnly = True
            Me.dgvCanal.ReadOnly = True
            Me.dgvCliente.ReadOnly = True

            Me.lbl_numero_solicitud.Text = lidSolicitud

            lsSQL = "pa_var_um_producto_escasez " & lidSolicitud
            dt = clsgen.selectQuery("SCM", lsSQL)

            If dt.Rows.Count > 0 Then
                Me.txtProducto.Text = dt.Rows(0).Item("producto").ToString
                Me.txtFechaGrabo.Text = dt.Rows(0).Item("fecha_grabo").ToString
                Me.txtDescripcion.Text = dt.Rows(0).Item("descripcion").ToString
                Me.cmbBodega.Text = dt.Rows(0).Item("bodega").ToString
                Me.dtp_inicio.Value = dt.Rows(0).Item("fecha_inicio").ToString
                Me.dtp_final.Value = dt.Rows(0).Item("fecha_final").ToString
                Me.StatusBarPanel1.Text = dt.Rows(0).Item("usuario_grabo")
                Me.StatusBarPanel2.Text = dt.Rows(0).Item("fecha_grabo")


                buscarProducto(dt.Rows(0).Item("producto").ToString)

                lsSQL = "pa_var_um_producto_escasez_canal " & lidSolicitud
                dt = clsgen.selectQuery("SCM", lsSQL)

                For Each dr As DataRow In dt.Rows
                    Dim drAux As DataRow
                    drAux = oDs.Tables("canal").NewRow
                    drAux.Item("Codigo") = dr.Item("canal")
                    drAux.Item("Cantidad") = dr.Item("cantidad_maxima")

                    oDs.Tables("canal").Rows.Add(drAux)

                Next

                lsSQL = "pa_var_um_producto_escasez_cliente " & lidSolicitud
                dt = clsgen.selectQuery("SCM", lsSQL)

                For Each dr As DataRow In dt.Rows
                    Dim drAux As DataRow
                    drAux = oDs.Tables("clientes").NewRow
                    drAux.Item("ctacte") = dr.Item("ctacte").ToString
                    drAux.Item("razonsocial") = dr.Item("razonsocial").ToString
                    drAux.Item("ejecutivo") = dr.Item("ejecutivo").ToString
                    drAux.Item("canal") = dr.Item("canal").ToString


                    oDs.Tables("clientes").Rows.Add(drAux)

                Next



                'dt = New DataTable("clientes")

                'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
                'dt.Columns.Add(New DataColumn("razonsocial", GetType(String)))
                'dt.Columns.Add(New DataColumn("ejecutivo", GetType(String)))
                'dt.Columns.Add(New DataColumn("canal", GetType(String)))

                Me.btnEditar.Visible = True
            End If



        Catch ex As Exception
        Finally
            Me.TabControl1.SelectedTab = Me.TabPage1
            clsgen = Nothing
            alinearGrid()

        End Try


    End Sub

    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Try
            limpiarFormulario()
            mostrarSolicitud(Me.dgvListado.Item("id", e.RowIndex).Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarFormulario()
    End Sub


    Private Sub txtProducto_Leave(sender As Object, e As EventArgs) Handles txtProducto.Leave
        Try
            Dim lsCodigo As String = txtProducto.Text
            limpiarFormulario()
            txtProducto.Text = lsCodigo
            buscarProducto(txtProducto.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEstadisticas_Click(sender As Object, e As EventArgs) Handles btnEstadisticas.Click
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.selectQuery("SCM", "pa_var_um_producto_escazes_ventas " & Me.lbl_numero_solicitud.Text)

            Dim oresultado As New frm_resultado
            oresultado.Text = ":: Ventas Por Canal ::"
            oresultado.dgv_resultado.DataSource = dt
            clsgen.Alinear_GridView(dt, oresultado.dgv_resultado, "", "", "", "", True, True, 250, 0)
            oresultado.ShowDialog()
            oresultado = Nothing


        Catch ex As Exception
        Finally
            clsgen = Nothing

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.dtp_final.Enabled = True
        Me.dgvCanal.ReadOnly = False
        Me.dgvCanal.AllowUserToDeleteRows = False
    End Sub
End Class