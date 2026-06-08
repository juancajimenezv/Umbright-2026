Imports System.Net

Public Class frmRequisiciones
    Dim oDS As DataSet
    Dim lbCambioObservaciones As Boolean = False
    Dim lbCambioLugarEntrega As Boolean = False
    Dim lbcambioFechaEntrega As Boolean = False

    Private Sub crearEstructura()
        Dim dt As DataTable
        oDS = New DataSet

        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt.Columns.Add(New DataColumn("precio", GetType(Double)))
        dt.Columns.Add(New DataColumn("cantidadFacturada", GetType(Double)))
        dt.Columns.Add(New DataColumn("precioTotal", GetType(Double)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        oDS.Tables.Add(dt.Copy)


        dt = New DataTable("centro_costo")
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns.Add(New DataColumn("reviso", GetType(String)))
        dt.Columns.Add(New DataColumn("aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        '      dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)

        dt = New DataTable("marca")
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns.Add(New DataColumn("reviso", GetType(String)))
        dt.Columns.Add(New DataColumn("aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Porcentaje_Empresa", GetType(Double)))
        dt.Columns.Add(New DataColumn("Porcentaje_Socio", GetType(Double)))
        '       dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)

        dt = New DataTable("gasto")
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("reviso", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)

        dt = New DataTable("canal")
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns.Add(New DataColumn("reviso", GetType(String)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)


        dt = New DataTable("imagenes")
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("rutaLocal", GetType(String)))
        dt.Columns.Add(New DataColumn("operar", GetType(Integer)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)

        dt = New DataTable("cotizaciones")
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("rutaLocal", GetType(String)))
        dt.Columns.Add(New DataColumn("operar", GetType(Integer)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)

        dt = New DataTable("clientes")
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("comentarios", GetType(String)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)



        Me.dgvDetalle.DataSource = oDS.Tables("detalle")
        Me.dgvCentroCosto.DataSource = oDS.Tables("centro_costo")
        Me.dgvGasto.DataSource = oDS.Tables("gasto")
        Me.dgvMarca.DataSource = oDS.Tables("marca")
        Me.dgvCliente.DataSource = oDS.Tables("clientes")
        Me.dgvCanal.DataSource = oDS.Tables("canal")


        'Nueva implementacion (c) 20231117
        Me.dgvCentroC.DataSource = oDS.Tables("centro_costo")
        Me.DGVItemC.DataSource = oDS.Tables("gasto")
        Me.dgvMC.DataSource = oDS.Tables("marca")
        Me.DGVCanalC.DataSource = oDS.Tables("canal")

    End Sub

    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_v_pg_estados 6"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "estados"

            oDS.Tables.Add(dt.Copy)

            Me.cmbEstado.DataSource = oDS.Tables("estados")
            Me.cmbEstado.ValueMember = "cod_estado"
            Me.cmbEstado.DisplayMember = "estado"


            'lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa null,null,'mci_solicitudRequisiciones','" & gs_empresa & "'"
            'dt = Otrans.Obtiene(lsSQL)
            'dt.TableName = "solicitantes"
            'oDS.Tables.Add(dt.Copy)

            lsSQL = "bdflexline.flexline.pa_sel_um_gen_tabcod null,'GEN_MONEDA','UMBRAL'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "monedas"
            oDS.Tables.Add(dt.Copy)

            Me.cmb_Moneda.DataSource = oDS.Tables("monedas")
            Me.cmb_Moneda.ValueMember = "CODIGO"
            Me.cmb_Moneda.DisplayMember = "CODIGO"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Function agregarLinea(ByVal pds As DataSet) As Boolean
        Dim nLinea As Integer
        Dim nLineaMin As Integer = 1
        Dim lbCorrecto As Boolean = False
        Dim lbAgregar As Boolean = False

        Try
            nLinea = oDS.Tables("detalle").Compute("max(linea)", "linea>0")
            nLinea += 1
        Catch ex As Exception
            nLinea = 1
        End Try

        Try
            nLineaMin = oDS.Tables("detalle").Compute("min(linea)", "linea>0")
        Catch ex As Exception

        End Try


        'Verificacion que todas las Lineas contenga %

        Try

            For Each dr As DataRow In pds.Tables("centro_costo").Rows
                If dr.Item("porcentaje") = 0 Then
                    MessageBox.Show("El Centro de Costo" & dr.Item("Descripcion") & " No Tiene Porcentaje Asignado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False

                End If
            Next

            For Each dr As DataRow In pds.Tables("marca").Rows
                If dr.Item("porcentaje") = 0 Then
                    MessageBox.Show("La Marca" & dr.Item("Descripcion") & " No Tiene Porcentaje Asignado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next

            For Each dr As DataRow In pds.Tables("gasto").Rows
                If dr.Item("porcentaje") = 0 Then
                    MessageBox.Show("El Gasto" & dr.Item("Descripcion") & " No Tiene Porcentaje Asignado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next


            Try
                If pds.Tables("centro_costo").Rows.Count = 0 And pds.Tables("marca").Rows.Count = 0 Then
                    MessageBox.Show("No Tiene Centro de Costo y/o Marca Asignada", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Catch ex As Exception
            End Try

            Try
                If pds.Tables("gasto").Rows.Count = 0 Then
                    MessageBox.Show("No Tiene Gasto Asignado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Catch ex As Exception
            End Try


            Dim drAux As DataRow

            drAux = oDS.Tables("detalle").NewRow
            drAux.Item("linea") = nLinea
            drAux.Item("codigo") = Me.txtCodigo.Text
            drAux.Item("descripcion") = Me.txtDescripcion.Text
            drAux.Item("observaciones") = Me.txtObservacionesLinea.Text
            drAux.Item("cantidad") = Me.txtCantidad.Text
            drAux.Item("precio") = Me.txtCosto.Text
            drAux.Item("modificado") = 0
            oDS.Tables("detalle").Rows.Add(drAux)


            For Each dr As DataRow In pds.Tables("centro_costo").Rows
                If oDS.Tables("centro_costo").Rows.Count = 0 Then
                    lbAgregar = True
                ElseIf nLinea = 1 Then
                    lbAgregar = True
                ElseIf dr.Item("linea") = nLineaMin Then
                    lbAgregar = True
                End If

                If lbAgregar Then
                    drAux = oDS.Tables("centro_costo").NewRow
                    drAux.Item("linea") = nLinea
                    drAux.Item("codigo") = dr.Item("codigo")
                    drAux.Item("descripcion") = dr.Item("descripcion")
                    drAux.Item("Porcentaje") = dr.Item("porcentaje")
                    oDS.Tables("centro_costo").Rows.Add(drAux)
                End If
                lbAgregar = False
            Next

            lbAgregar = False
            For Each dr As DataRow In pds.Tables("marca").Rows

                If oDS.Tables("marca").Rows.Count = 0 Then
                    lbAgregar = True
                ElseIf nLineaMin = 1 Then
                    lbAgregar = True
                ElseIf dr.Item("linea") = nLineaMin Then
                    lbAgregar = True
                End If

                If lbAgregar Then
                    drAux = oDS.Tables("marca").NewRow
                    drAux.Item("linea") = nLinea
                    drAux.Item("codigo") = dr.Item("codigo")
                    drAux.Item("descripcion") = dr.Item("descripcion")
                    drAux.Item("Porcentaje") = dr.Item("porcentaje")
                    drAux.Item("Porcentaje_Empresa") = dr.Item("porcentaje_Empresa")
                    drAux.Item("Porcentaje_Socio") = dr.Item("porcentaje_Socio")
                    oDS.Tables("marca").Rows.Add(drAux)
                End If
                lbAgregar = False
            Next

            lbAgregar = False
            For Each dr As DataRow In pds.Tables("gasto").Rows
                If oDS.Tables("gasto").Rows.Count = 0 Then
                    lbAgregar = True
                ElseIf nLineaMin = 1 Then
                    lbAgregar = True
                ElseIf dr.Item("linea") = nLineaMin Then
                    lbAgregar = True
                End If
                If lbAgregar Then
                    drAux = oDS.Tables("gasto").NewRow
                    drAux.Item("linea") = nLinea
                    drAux.Item("codigo") = dr.Item("codigo")
                    drAux.Item("descripcion") = dr.Item("descripcion")
                    drAux.Item("Porcentaje") = dr.Item("porcentaje")
                    drAux.Item("tipo") = dr.Item("tipo")
                    oDS.Tables("gasto").Rows.Add(drAux)
                End If
                lbAgregar = False
            Next

            lbAgregar = False
            For Each dr As DataRow In pds.Tables("canal").Rows
                If oDS.Tables("canal").Rows.Count = 0 Then
                    lbAgregar = True
                ElseIf nLineaMin = 1 Then
                    lbAgregar = True
                ElseIf dr.Item("linea") = nLineaMin Then
                    lbAgregar = True
                End If
                If lbAgregar Then
                    drAux = oDS.Tables("canal").NewRow
                    drAux.Item("linea") = nLinea
                    drAux.Item("codigo") = dr.Item("codigo")
                    drAux.Item("descripcion") = dr.Item("descripcion")
                    drAux.Item("Porcentaje") = dr.Item("porcentaje")
                    oDS.Tables("canal").Rows.Add(drAux)
                End If
                lbAgregar = False
            Next


            Try
                Dim ltotalIngreso As Double = 0
                For Each dr As DataRow In oDS.Tables("detalle").Rows
                    ltotalIngreso = ltotalIngreso + dr.Item("cantidad") * dr.Item("precio")
                Next

                Me.txtTotalIngreso.Text = ltotalIngreso.ToString("n")
            Catch ex As Exception

            End Try

            Return True
        Catch ex As Exception
            MessageBox.Show("Problemas Para Asociar Informacion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try

    End Function

    Private Function buscacliente(ByVal psCliente As String) As String
        Dim sNombreCliente As String = String.Empty
        Try


            If psCliente.Length > 0 Then
                Dim oTransaccion As New Transaccional.Conexion("flexline")
                Dim lsSQL As String
                Dim Otable As DataTable
                oTransaccion.open()
                lsSQL = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & psCliente.Trim & "'"
                Otable = oTransaccion.Obtiene(lsSQL)
                Otable.TableName = "clientes_flexline"
                'pds_Dataset.Tables.Add(oTable.Copy)

                If Otable.Rows.Count = 0 Then
                    MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Else
                    sNombreCliente = Otable.Rows(0).Item("RazonSocial") & "/" & Otable.Rows(0).Item("giro")
                    'Me.cmbTipoDocto.Focus()
                    '                Me.cmbEntrega.Focus()

                End If
                oTransaccion.close()
            End If

        Catch ex As Exception

        End Try
        Return sNombreCliente
    End Function

    Private Sub buscaProveedor_requisicion()
        Me.txtNombreProveedor.Text = String.Empty
        If Me.txtProveedorRequi.Text.Length > 0 Then
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Dim lsSQL As String
            Dim Otable As DataTable
            oTransaccion.open()
            lsSQL = "pa_sel_um_ctacte '" & gs_empresa & "','PROVEEDOR','" & Me.txtProveedorRequi.Text.Trim & "'"
            Otable = oTransaccion.Obtiene(lsSQL)
            'Otable.TableName = "clientes_flexline"
            'pds_Dataset.Tables.Add(oTable.Copy)

            If Otable.Rows.Count = 0 Then
                MessageBox.Show("Proveedor No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNombreProveedorRequi.Text = ""
                Me.txtProveedorRequi.Focus()

            Else
                Me.txtNombreProveedorRequi.Text = Otable.Rows(0).Item("RazonSocial") & "/" & Otable.Rows(0).Item("giro")
                'Me.cmbTipoDocto.Focus()
                '                Me.cmbEntrega.Focus()

            End If
            oTransaccion.close()
        End If


    End Sub

    Private Sub buscaProveedor()
        Me.txtNombreProveedor.Text = String.Empty
        If Me.txtProveedor.Text.Length > 0 Then
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Dim lsSQL As String
            Dim Otable As DataTable
            oTransaccion.open()
            lsSQL = "pa_sel_um_ctacte '" & gs_empresa & "','PROVEEDOR','" & Me.txtProveedor.Text.Trim & "'"
            Otable = oTransaccion.Obtiene(lsSQL)
            'Otable.TableName = "clientes_flexline"
            'pds_Dataset.Tables.Add(oTable.Copy)

            If Otable.Rows.Count = 0 Then
                MessageBox.Show("Proveedor No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNombreProveedor.Text = ""
                Me.txtProveedor.Focus()

            Else
                Me.txtNombreProveedor.Text = Otable.Rows(0).Item("RazonSocial") & "/" & Otable.Rows(0).Item("giro")

            End If
            oTransaccion.close()
        End If


    End Sub


    Private Sub llenarListado()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_var_um_requisicion_listado '" & gs_empresa & "','" & Me.dtpFechaInicio.Value & "','" & Me.dtpFechaFinal.Value & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "listado"
            If oDS.Tables.Contains("listado") Then oDS.Tables.Remove("listado")
            oDS.Tables.Add(dt.Copy)
            Me.dgvListado.DataSource = oDS.Tables("listado")

            Me.generarFiltro()
            clsGen.Alinear_GridView(oDS.Tables("listado"), dgvListado, "", ",correlativo,cod_estado,", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub alinearGrid(ByVal pEstado As Integer, ByVal Optional lbPlantilla As Boolean = False)
        Dim clsGen As New ClasesGenerales.General

        Dim lsReadOnly As String
        If pEstado < 20 Then
            lsReadOnly = ",descripcion,linea,codigo,"
        Else
            lsReadOnly = ",descripcion,linea,codigo,observaciones,cantidad,precio,"
        End If

        If lbPlantilla Then
            lsReadOnly = ",descripcion,linea,codigo,"
        End If


        'If pEstado >= 40 Then
        If pEstado > 39 Then
            clsGen.Alinear_GridView(oDS.Tables("detalle"), Me.dgvDetalle, ",codigo,descripcion,observaciones,cantidad,precio,cantidadFacturada,precioTotal,", ",linea,modificado,", lsReadOnly, "", "", "", "", True, True, 200, 0)
        Else
            clsGen.Alinear_GridView(oDS.Tables("detalle"), Me.dgvDetalle, "", ",linea,cantidadFacturada,preciototal,modificado,", lsReadOnly, "", "", "", "", True, True, 200, 0)

        End If

        'precioTotal
        '
        '
        clsGen.Alinear_GridView(oDS.Tables("centro_costo"), Me.dgvCentroCosto, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(oDS.Tables("gasto"), Me.dgvGasto, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)
        clsGen.Alinear_GridView(oDS.Tables("marca"), Me.dgvMarca, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)
        clsGen.Alinear_GridView(oDS.Tables("canal"), Me.dgvCanal, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)
        clsGen.Alinear_GridView(oDS.Tables("clientes"), Me.dgvCliente, "", ",,", ",razonSocial,", "", "", "", "", True, True, 200, 0)


        clsGen.Alinear_GridView(oDS.Tables("centro_costo"), Me.dgvCentroC, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(oDS.Tables("gasto"), Me.DGVItemC, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)
        clsGen.Alinear_GridView(oDS.Tables("marca"), Me.dgvMC, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)
        clsGen.Alinear_GridView(oDS.Tables("canal"), Me.DGVCanalC, "", ",linea,modificado,", ",descripcion,porcentaje,", "", "", "", "", True, True, 200, 0)



        clsGen = Nothing
    End Sub

    Private Sub buscarProducto(ByVal codigo_prod As String)
        Dim rTrans As New Transaccional.Conexion("scm")
        Dim dt_flex As New DataTable
        Dim dt_flex_ As New DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        rTrans.open()

        Try
            lsSQL = "pa_sel_um_producto '" & "LOGISERV" & "', '" & codigo_prod & "'"
            dt_flex = rTrans.Obtiene(lsSQL)

            If dt_flex.Rows.Count = 1 Then
                'sql_st = "pa_sel_um_listaprecio_costo '" & gs_empresa & "', '" & codigo_prod & "'"
                'dt_flex_ = rTrans.Obtiene(sql_st)
                Me.txtCodigo.Text = codigo_prod


                Me.txtDescripcion.Text = dt_flex.Rows(0)("glosa").ToString
                Me.txtObservacionesLinea.Focus()

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
            rTrans.close()
            rTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub guardarRequisicion(ByRef piRepeticiones As Integer)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim sNumeroGenerado As String = "0"
        Dim sCorrelativo As String
        Dim iLinea As Integer
        Dim lautorizamarca As Boolean = vbFalse

        Try
            Otrans.open()
            lsSQL = "pa_var_um_numero_requisicion '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            sNumeroGenerado = dt.Rows(0).Item("numero").ToString.PadLeft(10, "0")
            Me.lblNumero.Text = sNumeroGenerado

            lsSQL = "pa_ins_um_requisicion '" & gs_empresa & "','" & sNumeroGenerado & "','" & Me.dtpFechaEntrega.Value & "','" & Me.txtLugarEntrega.Text & "','" &
                    Me.txtObservacionesGenerales.Text & "','" & Me.txtProveedorRequi.Text & "','" & gs_usuario & "','" &
                    Me.cmb_Moneda.SelectedValue.ToString.ToUpper & "','" & Me.cmbAnticipo.SelectedItem.ToString.ToUpper & "','" & Me.cmbCadena.SelectedItem.ToString.ToUpper & "'," &
                    IIf(Me.cmbAnticipo.SelectedItem.ToString.ToUpper.Equals("SI"), Double.Parse(Me.txtMontoAnticipo.Text), 0) & ",'" & Me.cmbAfectaInventario.SelectedItem.ToString.ToUpper & "'"
            'IIf(Me.rbQTZ.Checked = True, "QUETZALES", "DOLARES") & "'"

            Otrans.Ingresa(lsSQL)
            If Otrans.Codigo_error > 0 Then
                MessageBox.Show("Error al guardar la Requisicion: " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & sNumeroGenerado & "'"
            dt = Otrans.Obtiene(lsSQL)
            sCorrelativo = dt.Rows(0).Item("correlativo")
            iLinea = oDS.Tables("detalle").Compute("min(linea)", "linea>0")


            For Each dr As DataRow In oDS.Tables("detalle").Rows
                lsSQL = "pa_ins_um_requisiciond '" & gs_empresa & "'," & sCorrelativo & "," &
                        dr.Item("Linea") & ",'" & dr.Item("codigo").ToString.Trim & "'," & dr.Item("cantidad") & "," &
                        dr.Item("precio") & ",'" & dr.Item("observaciones").ToString & "'"
                Otrans.Ingresa(lsSQL)

                'oDS.Tables("centro_costo").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("centro_costo").DefaultView.RowFilter = "linea = " & iLinea
                For Each drv As DataRowView In oDS.Tables("centro_costo").DefaultView
                    lsSQL = "pa_ins_um_requisicion_Costo '" & gs_empresa & "'," & sCorrelativo & ",'" &
                        dr.Item("codigo").ToString & "','" &
                        drv.Item("codigo") & "'," & drv.Item("porcentaje") & "," & dr.Item("Linea")
                    Otrans.Ingresa(lsSQL)
                Next

                'oDS.Tables("marca").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("marca").DefaultView.RowFilter = "linea = " & iLinea
                For Each drv As DataRowView In oDS.Tables("marca").DefaultView
                    lsSQL = "pa_ins_um_requisicion_marca '" & gs_empresa & "'," & sCorrelativo & ",'" &
                        dr.Item("codigo") & "','" &
                        drv.Item("codigo") & "'," & drv.Item("porcentaje") & "," &
                        drv.Item("porcentaje_Empresa") & "," &
                        drv.Item("porcentaje_Socio") & "," & dr.Item("Linea")
                    Otrans.Ingresa(lsSQL)
                    lautorizamarca = vbTrue
                Next

                'oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & iLinea
                For Each drv As DataRowView In oDS.Tables("gasto").DefaultView
                    lsSQL = "pa_ins_um_requisicion_gasto '" & gs_empresa & "'," & sCorrelativo & ",'" &
                        dr.Item("codigo").ToString.Trim & "','" &
                        drv.Item("codigo").ToString.Trim & "'," & drv.Item("porcentaje") & ",'" & drv.Item("tipo").ToString & "'," & dr.Item("Linea")
                    Otrans.Ingresa(lsSQL)
                Next

                'oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("canal").DefaultView.RowFilter = "linea = " & iLinea
                For Each drv As DataRowView In oDS.Tables("canal").DefaultView
                    lsSQL = "pa_ins_um_requisicion_canal '" & gs_empresa & "'," & sCorrelativo & ",'" &
                        drv.Item("codigo").ToString.Trim & "'," & drv.Item("porcentaje")
                    Otrans.Ingresa(lsSQL)
                Next
            Next




            For Each dr As DataRow In oDS.Tables("clientes").Rows

                If dr.Item("codigo").ToString.Length > 0 Then
                    lsSQL = "pa_ins_um_requisicionCliente '" & gs_empresa & "'," & sCorrelativo & ",'" &
                        dr.Item("codigo") & " ','" &
                        dr.Item("comentarios") & "'"
                    Otrans.Ingresa(lsSQL)
                End If
            Next

            'Guardar Imagenes

            Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
            If piRepeticiones > 0 Then
                guardarRepeticiones(Otrans, clsGen, sCorrelativo, piRepeticiones)
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

            If Val(sNumeroGenerado) > 0 Then
                MessageBox.Show("Se genero la Solicitud Numero " & Me.lblNumero.Text, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.limpiarForma()
                Me.limpiarProductos()
                Me.llenarListado()

                '(c) 20231117

                If False Then


                    Try
                        If gs_empresa = "VINOTECA" Then
                            Dim sUsuarioAprueba As String = String.Empty
                            Dim dtAprueba As DataTable
                            If lautorizamarca Then

                                lsSQL = "pa_var_um_sg_usuario_marca_contable_asignado '" & gs_empresa & "','" & sCorrelativo & "'"
                                dtAprueba = clsGen.selectQuery("SCM", lsSQL)
                                If dtAprueba.Rows.Count > 1 Then
                                    Dim oform As New ClasesGenerales.frm_seleccionar_opcion
                                    oform.cmb_listado.DataSource = dtAprueba
                                    oform.cmb_listado.ValueMember = "usuario"
                                    oform.cmb_listado.DisplayMember = "nombre"

                                    oform.ShowDialog()

                                    sUsuarioAprueba = oform.cmb_listado.SelectedValue



                                End If

                            Else 'Si no autoriza Marca, se autoriza por centro de costo
                                lsSQL = "pa_var_um_seg_usuario_centro_costo_asignado '" & gs_empresa & "','" & sCorrelativo & "'"
                                dtAprueba = clsGen.selectQuery("SCM", lsSQL)
                                If dtAprueba.Rows.Count > 1 Then
                                    Dim oform As New ClasesGenerales.frm_seleccionar_opcion
                                    oform.cmb_listado.DataSource = dtAprueba
                                    oform.cmb_listado.ValueMember = "usuario"
                                    oform.cmb_listado.DisplayMember = "nombre"

                                    oform.ShowDialog()

                                    sUsuarioAprueba = oform.cmb_listado.SelectedValue
                                End If

                            End If

                            lsSQL = "pa_sel_um_sg_usuario_email '" & sUsuarioAprueba & "'"
                            Dim dt3 As DataTable
                            dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                            'Dim uServicios As New Umbral_Servicios.aprobaciones

                            'dtAzure.DefaultView.RowFilter = lsFiltro & dt3.Rows(0).Item("correo").ToString & "'"

                            ''If dtAzure.DefaultView.Count = 0 Then
                            ''    lsNombreReporte = dr.Item("empresa").ToString & "-REQUISICION-" & dr.Item("numero").ToString & "_" & Now.ToString("HHmmss") & ".pdf"

                            ''    lsArchivoGenerado = exportar_reporte(lsRutaReporte, lsNombreReporte, False, pm_parametros, pm_valores, dr.Item("empresa").ToString, pm_conexion)
                            ''    Mover_Archivos_FTP(lsArchivoGenerado)

                            ''    uServicios.solicitarAprobacionRequisicion(dr, lsNombreReporte, dt3.Rows(0).Item("correo").ToString, dt3.Rows(0).Item("usuario").ToString, "Multipes Aprobaciones, Aplicara la Aprobación del Primero")

                            ''    clsGen.insertQuery("RegionalDBintOut", lsSQL)


                            ''    lbGenerarPDF = False
                            ''End If

                        End If


                    Catch ex As Exception

                    End Try

                End If

            End If
        End Try
    End Sub

    Private Sub guardarImagenes(ByVal Otrans As Transaccional.Conexion, ByVal clsgen As ClasesGenerales.General, ByVal psNumero As String)

        Dim lsSQL As String
        'Guardar Imagenes
        For Each dr As DataRow In oDS.Tables("imagenes").Rows
            'Dim sRuta As String = "\\onbase\tools$\images\req\" & gs_empresa & "_" & Me.lblNumero.Text & "_" & dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1, _
            '      dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)

            If dr.Item("operar") = 1 Then


                Dim sRuta As String = clsgen.Path_Imagenes & "Requisicion\" & gs_empresa &
                    "_" & Me.lblNumero.Text & "_" & dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1,
                    dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)


                lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & psNumero & "'"
                Dim dt2 As DataTable = clsgen.selectQuery("SCM", lsSQL)
                Dim sNumero As String = dt2.Rows(0).Item("correlativo")

                lsSQL = "pa_ins_um_requisicionImagen '" & gs_empresa & "'," & sNumero & ",'" &
                    dr.Item("nombre").ToString & " ','" &
                    dr.Item("rutaLocal").ToString & "','" & sRuta & "'"
                'Otrans.Ingresa(lsSQL)

                clsgen.insertQuery("SCM", lsSQL)
                clsgen.Copiar_Archivo(dr.Item("rutaLocal").ToString, sRuta, False)

                dr.Item("operar") = 0
            End If
        Next


    End Sub



    Private Sub guardarImagenes(ByVal clsgen As ClasesGenerales.General, ByVal psNumero As String)

        Dim lsSQL As String
        For Each dr As DataRow In oDS.Tables("imagenes").Rows

            If dr.Item("operar") = 1 Then


                Dim sRuta As String

                sRuta = clsgen.Path_Imagenes & "Requisicion\" & gs_empresa &
                    "_" & Me.lblNumero.Text & "_" & dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1,
                    dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)

                lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & psNumero & "'"
                Dim dt2 As DataTable = clsgen.selectQuery("SCM", lsSQL)
                Dim sNumero As String = dt2.Rows(0).Item("correlativo")

                lsSQL = "pa_ins_um_requisicionImagen '" & gs_empresa & "'," & sNumero & ",'" &
                    dr.Item("nombre").ToString & " ','" &
                    dr.Item("rutaLocal").ToString & "','" & sRuta & "'"

                clsgen.insertQuery("SCM", lsSQL)
                clsgen.Copiar_Archivo(dr.Item("rutaLocal").ToString, sRuta, False)

                dr.Item("operar") = 0
            End If
        Next


    End Sub

    Private Sub guardarRepeticiones(ByRef Otrans As Transaccional.Conexion, ByVal clsgen As ClasesGenerales.General, ByVal psCorrelativo As String, piRepeticiones As Integer)

        Dim lsSQL As String
        Dim liCodCalendario As Integer
        Dim dt As DataTable
        'Dim lfechaServidor As Date = clsgen.Fecha_Servidor("FlexLine")



        Try
            lsSQL = "pa_ins_um_requisicionCalendario '" & gs_empresa & "'," & psCorrelativo & "," & piRepeticiones & ",'" & gs_usuario & "'"
            Otrans.Ingresa(lsSQL)
            If Otrans.Codigo_error = 0 Then
                lsSQL = "pa_sel_um_requisicionCalendario '" & gs_empresa & "'," & psCorrelativo
                dt = Otrans.Obtiene(lsSQL)

                liCodCalendario = dt.Rows(0).Item("cod_calendario")

                For i As Integer = 1 To piRepeticiones

                    lsSQL = "pa_ins_um_requisicionCalendario_Detalle " & liCodCalendario & "," & i
                    Otrans.Ingresa(lsSQL)
                Next


            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub modificarRequisicion(ByVal pbLimpiarForma As Boolean)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim sNumero As String = "0"


        Try
            Otrans.open()

            lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & Me.lblNumero.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            sNumero = dt.Rows(0).Item("correlativo")

            lsSQL = "pa_del_um_requisiciond '" & gs_empresa & "'," & sNumero
            Otrans.Elimina(lsSQL)
            If Otrans.Codigo_error > 0 Then
                MessageBox.Show("Problemas en la Actualizacion, Intente mas tarde", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            For Each dr As DataRow In oDS.Tables("detalle").Rows
                lsSQL = "pa_ins_um_requisiciond '" & gs_empresa & "'," & sNumero & "," &
                        dr.Item("Linea") & ",'" & dr.Item("codigo") & "'," & dr.Item("cantidad") & "," &
                        dr.Item("precio") & ",'" & dr.Item("observaciones").ToString & "'"
                Otrans.Ingresa(lsSQL)

                oDS.Tables("centro_costo").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                For Each drv As DataRowView In oDS.Tables("centro_costo").DefaultView
                    lsSQL = "pa_ins_um_requisicion_Costo '" & gs_empresa & "'," & sNumero & ",'" &
                        dr.Item("codigo").ToString & " ','" &
                        drv.Item("codigo") & "'," & drv.Item("porcentaje") & "," & dr.Item("linea")
                    Otrans.Ingresa(lsSQL)
                Next
                oDS.Tables("marca").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                For Each drv As DataRowView In oDS.Tables("marca").DefaultView
                    lsSQL = "pa_ins_um_requisicion_marca '" & gs_empresa & "'," & sNumero & ",'" &
                        dr.Item("codigo") & " ','" &
                        drv.Item("codigo") & "'," & drv.Item("porcentaje") & "," & dr.Item("linea")
                    Otrans.Ingresa(lsSQL)
                Next

                'oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                'For Each drv As DataRowView In oDS.Tables("gasto").DefaultView
                '    lsSQL = "pa_ins_um_requisicion_gasto '" & gs_empresa & "'," & sNumero & ",'" &
                '        dr.Item("codigo") & " ','" &
                '        drv.Item("codigo") & "'," & drv.Item("porcentaje") & "," & dr.Item("linea")
                '    Otrans.Ingresa(lsSQL)
                'Next


                'oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                For Each drv As DataRowView In oDS.Tables("gasto").DefaultView
                    lsSQL = "pa_ins_um_requisicion_gasto '" & gs_empresa & "'," & sNumero & ",'" &
                        dr.Item("codigo").ToString.Trim & "','" &
                        drv.Item("codigo").ToString.Trim & "'," & drv.Item("porcentaje") & ",'" & drv.Item("tipo").ToString & "'," & dr.Item("Linea")
                    Otrans.Ingresa(lsSQL)
                Next

                'oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                oDS.Tables("canal").DefaultView.RowFilter = "linea = " & dr.Item("linea")
                For Each drv As DataRowView In oDS.Tables("canal").DefaultView
                    lsSQL = "pa_ins_um_requisicion_canal '" & gs_empresa & "'," & sNumero & ",'" &
                        drv.Item("codigo").ToString.Trim & "'," & drv.Item("porcentaje")
                    Otrans.Ingresa(lsSQL)
                Next

            Next

            Me.guardarImagenes(Otrans, clsGen, sNumero)

            lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'Modificacion Requisicion'"
            Otrans.Actualiza(lsSQL)

            lsSQL = "pa_upd_um_requisicion '" & gs_empresa & "','" & Me.lblNumero.Text & "',"
            lsSQL += IIf(Me.lbCambioObservaciones, "'" & Me.txtObservacionesGenerales.Text & "',", "null,")
            lsSQL += IIf(Me.lbCambioLugarEntrega, "'" & Me.txtLugarEntrega.Text & "',", "null,")
            lsSQL += IIf(Me.lbcambioFechaEntrega, "'" & Me.dtpFechaEntrega.Value & "','", "null,'")
            lsSQL += gs_usuario & "'"
            Otrans.Actualiza(lsSQL)


            If pbLimpiarForma Then
                MessageBox.Show("Actualizacion Finalizada Con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.limpiarForma()
                Me.limpiarProductos()

            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub subirImagenes()
        Dim sNombreArchivo, sNombreImagen As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow


        Try

            'Me.OFD.Filter = "*.*"
            OFD.FileName = ""
            OFD.Filter = "png|*.png"
            OFD.ShowDialog()

            sNombreArchivo = OFD.FileName

            If MessageBox.Show("Esta Seguro de Cargar Imagen", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sNombreImagen = InputBox("Ingrese Nombre de Imagen", "Nombre")

                dr = oDS.Tables("imagenes").NewRow
                dr.Item("nombre") = sNombreImagen
                dr.Item("rutaLocal") = sNombreArchivo
                dr.Item("operar") = 1
                oDS.Tables("imagenes").Rows.Add(dr)



            End If


            '(c) 20180408 Se Cargan Automaticamente las Imagenes
            Me.guardarImagenes(clsGen, Me.lblNumero.Text)

        Catch ex As Exception

        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub guardarCotizaciones(psNumero As String)
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            For Each dr As DataRow In oDS.Tables("cotizaciones").Rows
                If Not dr.Item("rutaLocal").ToString.ToLower.StartsWith("\\tda") Then
                    If dr.Item("operar") = 1 Then

                        Dim sRuta As String = clsGen.Path_Imagenes & "cotizaciones\" &
                                gs_empresa & "_" & Me.lblNumero.Text & "_" &
                                dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1,
                                dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)

                        lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & psNumero & "'"
                        Dim dt2 As DataTable = clsGen.selectQuery("SCM", lsSQL)
                        Dim sNumero As String = dt2.Rows(0).Item("correlativo")


                        lsSQL = "pa_ins_um_requisicionCotizacion '" & gs_empresa & "'," & sNumero & ",'" &
                                dr.Item("nombre").ToString & " ','" &
                                dr.Item("rutaLocal").ToString & "','" & sRuta & "'"
                        clsGen.insertQuery("SCM", lsSQL)

                        clsGen.Copiar_Archivo(dr.Item("rutaLocal").ToString, sRuta, False)
                        dr.Item("operar") = 0
                    End If
                End If
            Next


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub


    Private Sub guardarCotizaciones(ByVal Otrans As Transaccional.Conexion)
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            For Each dr As DataRow In oDS.Tables("cotizaciones").Rows
                If Not dr.Item("rutaLocal").ToString.ToLower.StartsWith("\\tda") Then
                    If dr.Item("operar") = 1 Then

                        Dim sRuta As String = clsGen.Path_Imagenes & "cotizaciones\" &
                                gs_empresa & "_" & Me.lblNumero.Text & "_" &
                                dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1,
                                dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)

                        lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & Me.lblNumero.Text & "'"
                        Dim dt2 As DataTable = Otrans.Obtiene(lsSQL)
                        Dim sNumero As String = dt2.Rows(0).Item("correlativo")

                        lsSQL = "pa_ins_um_requisicionCotizacion '" & gs_empresa & "'," & sNumero & ",'" &
                                dr.Item("nombre").ToString & " ','" &
                                dr.Item("rutaLocal").ToString & "','" & sRuta & "'"
                        Otrans.Ingresa(lsSQL)

                        clsGen.Copiar_Archivo(dr.Item("rutaLocal").ToString, sRuta, False)
                        dr.Item("operar") = 0
                    End If
                End If
            Next


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub


    Private Sub subirPDF(ByVal psTipo As String)
        Dim sNombreArchivo, sNombreImagen As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow

        Try


            OFD.FileName = ""
            OFD.Filter = "pdf|*.pdf"
            OFD.ShowDialog()

            sNombreArchivo = OFD.FileName

            If MessageBox.Show("Esta Seguro de Cargar PDF", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sNombreImagen = InputBox("Ingrese Nombre de Imagen", "Nombre")
                'psTipo = imagenes, cotizaciones
                dr = oDS.Tables(psTipo).NewRow
                dr.Item("nombre") = sNombreImagen
                dr.Item("rutaLocal") = sNombreArchivo
                dr.Item("operar") = 1
                oDS.Tables(psTipo).Rows.Add(dr)
            End If

            '(c) 20180408 Se Cargan Automaticamente las Imagenes
            If psTipo = "imagenes" Then
                Me.guardarImagenes(clsGen, Me.lblNumero.Text)
            Else
                Me.guardarCotizaciones(Me.lblNumero.Text)
            End If


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub MostrarImagenes()
        Dim clsGen As New ClasesGenerales.frm_mostrarImagen

        Try

            Dim sfile As String = String.Empty
            Dim sNombre As String = String.Empty

            If oDS.Tables("imagenes").Rows.Count = 1 Then
                sfile = oDS.Tables("imagenes").Rows(0).Item("RutaLocal")
                sNombre = oDS.Tables("imagenes").Rows(0).Item("nombre")

            ElseIf oDS.Tables("imagenes").Rows.Count > 1 Then
                'MostrarLista
                For Each dr As DataRow In oDS.Tables("imagenes").Rows
                    If sNombre.Length > 0 Then sNombre += ","
                    sNombre += dr.Item("nombre")
                Next

                Dim clsLista As New Automatizar.frm_lista
                clsLista.Llenar_Combo_Vector(sNombre.Split(","))
                clsLista.ShowDialog()
                sNombre = clsLista._selectedValue
                clsLista = Nothing
                oDS.Tables("imagenes").DefaultView.RowFilter = "nombre = '" & sNombre & "'"
                sfile = oDS.Tables("imagenes").DefaultView(0).Item("RutaLocal")

            End If



            If System.IO.File.Exists(sfile) Then
                Try
                    If sfile.IndexOf("pdf") > 0 Then
                        Try


                            Dim proceso As Process = New Process

                            proceso.StartInfo.FileName = sfile '.Replace(".jpg", ".pdf")
                            proceso.Start()
                            proceso = Nothing
                        Catch ex As Exception

                        End Try
                    Else
                        clsGen.Text = sNombre
                        clsGen.psimagen = sfile
                        clsGen.ShowDialog()
                    End If


                Catch ex As Exception
                    Try
                        Dim proceso As Process = New Process

                        proceso.StartInfo.FileName = sfile '.Replace(".jpg", ".pdf")
                        proceso.Start()
                        proceso = Nothing

                    Catch ex2 As Exception
                        '  MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End Try


            End If

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub mostrarCotizaciones()
        Dim clsGen As New ClasesGenerales.frm_mostrarImagen

        Try

            Dim sfile As String = String.Empty
            Dim sNombre As String = String.Empty

            If oDS.Tables("cotizaciones").Rows.Count = 1 Then
                sfile = oDS.Tables("cotizaciones").Rows(0).Item("RutaLocal")
                sNombre = oDS.Tables("cotizaciones").Rows(0).Item("nombre")
            ElseIf oDS.Tables("cotizaciones").Rows.Count > 1 Then
                'MostrarLista
                For Each dr As DataRow In oDS.Tables("cotizaciones").Rows
                    If sNombre.Length > 0 Then sNombre += ","
                    sNombre += dr.Item("nombre")
                Next

                Dim clsLista As New Automatizar.frm_lista
                clsLista.Llenar_Combo_Vector(sNombre.Split(","))
                clsLista.ShowDialog()
                sNombre = clsLista._selectedValue
                clsLista = Nothing
                oDS.Tables("cotizaciones").DefaultView.RowFilter = "nombre = '" & sNombre & "'"
                sfile = oDS.Tables("cotizaciones").DefaultView(0).Item("RutaLocal")

            End If



            If System.IO.File.Exists(sfile) Then
                'Try


                '    clsGen.Text = sNombre
                '    clsGen.psimagen = sfile
                '    clsGen.ShowDialog()
                'Catch ex As Exception
                Try
                    Dim proceso As Process = New Process

                    proceso.StartInfo.FileName = sfile '.Replace(".jpg", ".pdf")
                    proceso.Start()
                    proceso = Nothing

                Catch ex2 As Exception
                    '  MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
                'End Try


            End If

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub limpiarProductos()
        Me.txtCodigo.Text = String.Empty
        Me.txtDescripcion.Text = String.Empty
        Me.txtObservacionesLinea.Text = String.Empty
        Me.txtCantidad.Text = "0"
        Me.txtCosto.Text = "0"
    End Sub

    Private Sub limpiarForma()
        limpiarProductos()

        oDS.Tables("detalle").Rows.Clear()
        oDS.Tables("centro_costo").Rows.Clear()
        oDS.Tables("gasto").Rows.Clear()
        oDS.Tables("marca").Rows.Clear()
        oDS.Tables("canal").Rows.Clear()
        oDS.Tables("imagenes").Rows.Clear()
        oDS.Tables("cotizaciones").Rows.Clear()
        oDS.Tables("clientes").Rows.Clear()

        Me.txtTotalIngreso.Text = "0.00"

        Me.txtMontoAnticipo.Text = "0.00"
        Me.txtMontoAnticipo.Visible = False

        Me.lblNumero.Text = "0000"
        'Me.txtCodigoCliente.Text = String.Empty
        'Me.txtNombreCliente.Text = String.Empty
        'Me.txtCodigoCliente.Enabled = True
        'Me.btnBuscarCliente.Enabled = True
        'Me.txtNombreCliente.Enabled = False
        Me.txtLugarEntrega.Text = String.Empty
        Me.txtObservacionesGenerales.Text = String.Empty
        Me.txtProveedor.Text = String.Empty
        Me.txtNombreProveedor.Text = String.Empty
        Me.txtUsuarioGrabo.Text = gs_usuario

        Me.lblProveedor.Visible = False
        Me.btnBuscarProveedor.Visible = False
        Me.txtProveedor.Visible = False
        Me.txtNombreProveedor.Visible = False
        Me.txtProveedor.Enabled = True
        Me.txtNombreProveedor.Enabled = True
        Me.btnGuardar.Enabled = True
        Me.btnGuardar.Text = "Guardar"

        Me.btnCalendarizar.Visible = True
        Me.txtFacturaNumero.Text = String.Empty
        Me.txtFacturaSerie.Text = String.Empty
        Me.dtpFacturaFecha.Value = Today.AddYears(-50)

        Me.txtFacturaNumero.Visible = False
        Me.txtFacturaSerie.Visible = False
        Me.dtpFacturaFecha.Visible = False
        Me.lblFacturaNumero.Visible = False
        Me.lblFacturaSerie.Visible = False
        Me.lblFacturaFecha.Visible = False
        Me.txtFacturaNumero.Enabled = True
        Me.txtFacturaSerie.Enabled = True
        Me.dtpFacturaFecha.Enabled = True
        aplicarFiltro(0)

        Me.dgvDetalle.AllowUserToDeleteRows = True
        Me.dgvCliente.ReadOnly = False
        Me.alinearGrid(0)

        Me.cmbAnticipo.Visible = True
        Me.lblAnticipo.Visible = True

        Me.cmbAnticipo.SelectedItem = " "

        Try
            Me.txtProveedorRequi.Text = String.Empty
            Me.txtNombreProveedorRequi.Text = String.Empty

            Me.btnbuscarProveedorRequi.Enabled = True
            Me.txtProveedorRequi.Enabled = True
            Me.txtNombreProveedorRequi.Enabled = True

        Catch ex As Exception

        End Try





    End Sub

    Private Sub llenarItem(ByVal Otrans As Transaccional.Conexion, ByVal psNumero As String, ByVal psTipo As String, ByVal psTabla As String)
        Dim dt As DataTable
        Dim drAux As DataRow
        Dim lsSQL As String


        Try
            lsSQL = "pa_sel_um_requisicionCodigo '" & gs_empresa & "','" & psNumero & "','" & psTipo & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows
                drAux = oDS.Tables(psTabla).NewRow
                drAux.Item("linea") = dr.Item("linea").ToString
                drAux.Item("codigo") = dr.Item("codigo")
                drAux.Item("descripcion") = dr.Item("descripcion")
                drAux.Item("Porcentaje") = dr.Item("porcentaje")
                drAux.Item("reviso") = dr.Item("usuario_reviso").ToString

                If psTabla = "marca" Then
                    drAux.Item("Porcentaje_Empresa") = dr.Item("porcentaje_Empresa")
                    drAux.Item("Porcentaje_Socio") = dr.Item("porcentaje_Socio")
                End If

                Try
                    If dr.Item("tipo_gasto").ToString.Length > 0 Then
                        drAux.Item("tipo") = dr.Item("tipo_gasto")
                    End If
                Catch ex As Exception

                End Try




                oDS.Tables(psTabla).Rows.Add(drAux)
            Next

        Catch ex As Exception

        End Try


    End Sub

    Private Sub llenarCanales(ByVal Otrans As Transaccional.Conexion, ByVal psNumero As String)
        Dim dt As DataTable
        Dim drAux As DataRow
        Dim lsSQL As String


        Try
            lsSQL = "pa_sel_um_requisicionCanal '" & gs_empresa & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows
                drAux = oDS.Tables("canal").NewRow
                drAux.Item("linea") = dr.Item("linea")
                drAux.Item("codigo") = dr.Item("codigo")
                drAux.Item("descripcion") = dr.Item("descripcion")
                drAux.Item("Porcentaje") = dr.Item("porcentaje")



                oDS.Tables("canal").Rows.Add(drAux)
            Next

        Catch ex As Exception

        End Try


    End Sub


    Private Sub llenarClientes(ByVal Otrans As Transaccional.Conexion, ByVal psNumero As String)
        Dim dt As DataTable
        Dim lsSQL As String
        Dim drAux As DataRow

        Try
            lsSQL = "pa_sel_um_requisicionCliente '" & gs_empresa & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                drAux = oDS.Tables("clientes").NewRow
                drAux.Item("codigo") = dr.Item("ctacte")
                drAux.Item("razonSocial") = dr.Item("razonSocial")
                drAux.Item("comentarios") = dr.Item("Comentarios")
                oDS.Tables("clientes").Rows.Add(drAux)

            Next


        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenarDetalle(ByVal Otrans As Transaccional.Conexion, ByVal psNumero As String)
        Dim dt As DataTable
        Dim lsSQL As String
        Dim drAux As DataRow
        Dim ltotalIngreso As Double = 0
        Try
            lsSQL = "pa_sel_um_requisiciond '" & gs_empresa & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                drAux = oDS.Tables("detalle").NewRow
                drAux.Item("linea") = dr.Item("Linea")
                drAux.Item("codigo") = dr.Item("Producto")
                drAux.Item("descripcion") = dr.Item("glosa")
                drAux.Item("observaciones") = dr.Item("Comentario")
                drAux.Item("cantidad") = dr.Item("Cantidad")
                drAux.Item("precio") = dr.Item("precio")
                drAux.Item("cantidadFacturada") = dr.Item("CantidadAsignada")
                drAux.Item("precioTotal") = dr.Item("Neto")
                drAux.Item("modificado") = 0
                oDS.Tables("detalle").Rows.Add(drAux)

                ltotalIngreso = ltotalIngreso + dr.Item("cantidad") * dr.Item("precio")

            Next

            Me.txtTotalIngreso.Text = ltotalIngreso.ToString("n")

        Catch ex As Exception

        End Try


    End Sub

    Private Sub llenarImagenes(ByVal Otrans As Transaccional.Conexion, ByVal psNumero As String)

        Dim dt As DataTable
        Dim lsSQL As String
        Dim drAux As DataRow

        Try
            lsSQL = "pa_sel_um_requisicionImagen '" & gs_empresa & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)


            dt.DefaultView.RowFilter = "tipo = 'IMAGEN'"
            For Each drv As DataRowView In dt.DefaultView
                drAux = oDS.Tables("imagenes").NewRow
                drAux.Item("nombre") = drv.Item("nombre")
                drAux.Item("rutaLocal") = drv.Item("rutaactual")
                drAux.Item("operar") = 0
                oDS.Tables("imagenes").Rows.Add(drAux)
            Next


            dt.DefaultView.RowFilter = "tipo = 'COTIZACION'"
            For Each drv As DataRowView In dt.DefaultView
                drAux = oDS.Tables("cotizaciones").NewRow
                drAux.Item("nombre") = drv.Item("nombre")
                drAux.Item("rutaLocal") = drv.Item("rutaactual")
                drAux.Item("operar") = 0
                oDS.Tables("cotizaciones").Rows.Add(drAux)
            Next


        Catch ex As Exception
        Finally


        End Try
    End Sub

    Private Sub mostrarRequisicion(ByVal psNumero As String, ByVal iRowIndex As Integer)
        Dim dt As DataTable
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim iEstado As Integer

        Try
            limpiarForma()
            Me.btnCalendarizar.Visible = False

            Otrans.open()

            lsSQL = "pa_sel_um_requisicion '" & gs_empresa & "','" & psNumero & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows

                Me.lblNumero.Text = dr.Item("numero")
                Me.lblEstadoActual.Text = Me.dgvListado.Item("estado", iRowIndex).Value()
                Me.txtFechaGrabo.Text = dr.Item("fechagrabo")
                Me.txtUsuarioGrabo.Text = dr.Item("usuariograbo").ToString
                Me.txtLugarEntrega.Text = dr.Item("lugarEntrega").ToString
                Me.txtObservacionesGenerales.Text = dr.Item("Observaciones").ToString
                'Me.txtCodigoCliente.Text = dr.Item("ctacte").ToString
                Try
                    Me.dtpFechaEntrega.Value = dr.Item("fecha_entrega")
                Catch ex As Exception
                End Try



                'Me.btnBuscarCliente.Enabled = True
                'If Me.txtCodigoCliente.Text.Length > 0 Then
                '    Me.buscacliente()
                '    Me.btnBuscarCliente.Enabled = False
                '    Me.txtCodigoCliente.Enabled = False

                'End If
                Try
                    Me.txtProveedor.Text = dr.Item("proveedor").ToString
                    If Me.txtProveedor.Text.Length > 0 Then
                        Me.buscaProveedor()
                        Me.txtProveedor.Enabled = False
                        Me.txtNombreProveedor.Enabled = False
                        Me.btnBuscarProveedor.Enabled = False
                        '                Me.btnGuardar.Enabled = False

                        Me.txtNombreProveedorRequi.Text = Me.txtNombreProveedor.Text
                        Me.txtProveedorRequi.Text = Me.txtProveedor.Text
                    End If

                Catch ex As Exception

                End Try
                Try
                    Me.cmb_Moneda.SelectedValue = dr.Item("MONEDA").ToString
                Catch ex As Exception

                End Try


                'If dr.Item("moneda").ToString.ToLower.StartsWith("qu") Then
                '    Me.rbQTZ.Checked = True
                'Else
                '    Me.rbDLR.Checked = True
                'End If

                Try
                    Me.txtFacturaNumero.Text = dr.Item("ReferenciaExterna")
                    Me.txtFacturaSerie.Text = dr.Item("RefTipoDocto")
                    Me.dtpFacturaFecha.Value = dr.Item("RefFecha")
                Catch ex As Exception

                End Try

                Try

                    Me.cmbAnticipo.SelectedItem = "NO"
                    Me.cmbAnticipo.SelectedItem = dr.Item("tipocomprobante").ToString
                Catch ex As Exception

                End Try

                Try
                    Me.cmbAfectaInventario.SelectedItem = "NO"
                    Me.cmbAfectaInventario.SelectedItem = dr.Item("costeo").ToString
                Catch ex As Exception

                End Try

                iEstado = dr.Item("estado")
                aplicarFiltro(dr.Item("estado"))

                Try
                    Me.txtNombreProveedorRequi.Enabled = False
                    Me.txtProveedorRequi.Enabled = False
                    Me.btnbuscarProveedorRequi.Enabled = False

                Catch ex As Exception

                End Try

            Next

            llenarDetalle(Otrans, psNumero)
            llenarClientes(Otrans, psNumero)
            llenarItem(Otrans, psNumero, "CON_CCOSTO", "centro_costo")
            llenarItem(Otrans, psNumero, "CON_MARCA", "marca")
            llenarItem(Otrans, psNumero, "CON_ITEM", "gasto")
            llenarItem(Otrans, psNumero, "CON_A&P", "gasto")
            llenarCanales(Otrans, psNumero)
            llenarImagenes(Otrans, psNumero)
            alinearGrid(iEstado)
            Me.btnGuardar.Text = "Modificar"
            If iEstado > 20 Then Me.dgvDetalle.AllowUserToDeleteRows = False

            Me.dgvCliente.ReadOnly = True
            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub aplicarFiltro(ByVal iEstadoActual As Integer)

        Dim sFiltro As String = String.Empty
        Try

            If iEstadoActual = 10 Then
                sFiltro = "cod_estado in (10,20,90,900,1000)"
            ElseIf iEstadoActual = 0 Then
                sFiltro = "cod_estado in (0,10)"
            ElseIf iEstadoActual = 24 Then
                sFiltro = "cod_estado in (25,1000)"
            ElseIf iEstadoActual = 30 Or iEstadoActual = 40 Then
                sFiltro = "cod_estado in (40,50,90,900,1000)"
            ElseIf iEstadoActual = 60 Then
                sFiltro = "cod_estado in (50,70,1000)" '(c) 2017115 Se Agrego estado 50 para que puedan modificar el precio
            ElseIf iEstadoActual = 70 Then
                sFiltro = "cod_estado in (80)"
            ElseIf iEstadoActual = 110 Then
                sFiltro = "cod_estado in (0)"
                Me.btnGuardar.Enabled = False
            Else
                sFiltro = "cod_estado in (0)"
            End If
            oDS.Tables("estados").DefaultView.RowFilter = sFiltro

            If iEstadoActual >= 40 Then
                Me.lblProveedor.Visible = True
                Me.txtProveedor.Visible = True
                Me.btnBuscarProveedor.Visible = True
                Me.txtNombreProveedor.Visible = True
                Me.cmbAnticipo.Visible = True
                Me.lblAnticipo.Visible = True
            End If

            If iEstadoActual >= 60 Then
                Me.lblFacturaFecha.Visible = True
                Me.lblFacturaNumero.Visible = True
                Me.lblFacturaSerie.Visible = True
                Me.txtFacturaNumero.Visible = True
                Me.txtFacturaSerie.Visible = True
                Me.dtpFacturaFecha.Visible = True
                If iEstadoActual > 60 Then
                    Me.txtFacturaNumero.Enabled = False
                    Me.txtFacturaSerie.Enabled = False
                    Me.dtpFacturaFecha.Enabled = False
                End If
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub modificarRequisicion(ByVal pComentario As String)
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Try

            Otrans.open()
            'La revision se debe hacer por Centro de Costo o Marcas Afectas

            ''
            If Me.cmbEstado.SelectedValue = 10 Then ''Esperando Revision
                If gs_usuario.ToLower = Me.txtUsuarioGrabo.Text.ToLower Or Me.validarRevisar(Otrans) = True Then
                    If MessageBox.Show("Esta Seguro de Modificar Esta Requisicion", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.modificarRequisicion(True)
                    End If
                Else
                    MessageBox.Show("Solo El Usuario Que Grabo La Requisicion La Puede Modificar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If



            ElseIf Me.cmbEstado.SelectedValue = 20 Then ''Revisada

                If Me.validarRevisar(Otrans) = True Or gi_tipo_usuario = 1 Then
                    ''Verificar Cambios
                    'Mostrar Presupuestos


                    dt = clsGen.ValoresDistinto(oDS.Tables("detalle"), "modificado".Split(","))
                    For Each dr As DataRow In dt.Rows
                        If dr.Item("modificado") = 1 Then
                            If MessageBox.Show("Esta Seguro de Proceder con los Cambios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Me.modificarRequisicion(False)
                            End If
                            Exit For
                        End If
                    Next



                    If oDS.Tables("marca").Rows.Count > 0 Then

                        'mostrarPresupuestoMarcaMes()

                        lsSQL = "pa_var_um_sg_usuario_marca_contable_revision '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & gi_tipo_usuario
                        dt = Otrans.Obtiene(lsSQL)

                        If dt.Rows.Count > 0 Or gi_tipo_usuario = 1 Then
                            For Each dr As DataRow In dt.Rows
                                oDS.Tables("marca").DefaultView.RowFilter = "codigo = '" & dr.Item("marca") & "'"
                                For Each drv As DataRowView In oDS.Tables("marca").DefaultView
                                    drv.Item("reviso") = gs_usuario

                                    '20180408 (c) Prueba
                                    lsSQL = "pa_upd_um_requisicionCodigo '" & gs_empresa & "','" & Me.lblNumero.Text & "'," &
                                    drv.Item("linea") & ",'" & drv.Item("codigo") & "','" & gs_usuario & "','CON_MARCA'"
                                    Otrans.Actualiza(lsSQL)


                                Next
                            Next

                            oDS.Tables("marca").DefaultView.RowFilter = ""
                            dt = clsGen.ValoresDistinto(oDS.Tables("marca"), "reviso".Split(","))
                            dt.DefaultView.RowFilter = "reviso = ''"
                            If dt.DefaultView.Count > 0 Then 'oDS.Tables("marca").DefaultView.Count > 0 Then
                                MessageBox.Show("Quedara Marca Pendientes de Revision", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                'ElseIf dt.Rows.Count = 1 Then 'oDS.Tables("marca").DefaultView.Count = 0 Then
                            Else
                                lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'" & pComentario & "'"
                                Otrans.Actualiza(lsSQL)

                                'If Me.txtNombreCliente.Text.Length > 0 Then
                                If oDS.Tables("clientes").Rows.Count > 0 Then
                                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 4
                                    Me.guardarAvisoReal(35, "Se Aprobo la Requisicion para Verificacion de Clientes " & gs_empresa & "-" & Me.lblNumero.Text, Otrans)
                                Else
                                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 10
                                    'Me.guardarAvisoReal(33, "Se Aprobo la Requisicion " & gs_empresa & "-" & Me.lblNumero.Text, Otrans)
                                End If

                                Otrans.Actualiza(lsSQL)
                                MessageBox.Show("Revision Procesada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.limpiarForma()
                                Me.limpiarProductos()

                            End If
                            Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
                            'Else
                            '    MessageBox.Show("No Tiene Permisos Para Aprobar Las Marcas Asociadas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    ElseIf oDS.Tables("centro_costo").Rows.Count > 0 Then '' Validacion por Centro de Costo
                        If Me.cmbEstado.SelectedValue = 20 Then
                            lsSQL = "pa_var_um_seg_usuario_centro_costo_revision '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'"
                            dt = Otrans.Obtiene(lsSQL)


                            If dt.Rows.Count > 0 Or gi_tipo_usuario = 1 Then

                                If gi_tipo_usuario = 1 Then

                                    oDS.Tables("centro_costo").DefaultView.RowFilter = ""
                                    For Each drv As DataRowView In oDS.Tables("centro_costo").DefaultView
                                        drv.Item("reviso") = gs_usuario
                                        lsSQL = "pa_upd_um_requisicionCodigo '" & gs_empresa & "','" & Me.lblNumero.Text & "'," &
                                            drv.Item("linea") & ",'" & drv.Item("codigo") & "','" & gs_usuario & "','CON_CCOSTO'"

                                        Otrans.Actualiza(lsSQL)
                                    Next

                                Else
                                    For Each dr As DataRow In dt.Rows
                                        oDS.Tables("centro_costo").DefaultView.RowFilter = "codigo = '" & dr.Item("centro_costo") & "'"
                                        For Each drv As DataRowView In oDS.Tables("centro_costo").DefaultView
                                            drv.Item("reviso") = gs_usuario
                                            lsSQL = "pa_upd_um_requisicionCodigo '" & gs_empresa & "','" & Me.lblNumero.Text & "'," &
                                                drv.Item("linea") & ",'" & drv.Item("codigo") & "','" & gs_usuario & "','CON_CCOSTO'"

                                            Otrans.Actualiza(lsSQL)
                                        Next
                                    Next
                                End If

                                oDS.Tables("centro_costo").DefaultView.RowFilter = ""
                                dt = clsGen.ValoresDistinto(oDS.Tables("centro_costo"), "reviso".Split(","))
                                If dt.Rows.Count > 1 Then
                                    MessageBox.Show("Quedara Centro de Costo Pendientes de Revision", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ElseIf dt.Rows.Count = 1 Then

                                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'" & pComentario & "'"
                                    Otrans.Actualiza(lsSQL)

                                    If oDS.Tables("clientes").Rows.Count > 0 Then
                                        lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 4
                                        'Me.guardarAvisoReal(35, "Se Aprobo la Requisicion para Verificacion de Clientes " & gs_empresa & "-" & Me.lblNumero.Text, Otrans)
                                    Else
                                        lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 10
                                        'Me.guardarAvisoReal(33, "Se Aprobo la Requisicion " & gs_empresa & "-" & Me.lblNumero.Text, Otrans)
                                    End If

                                    'lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 10
                                    Otrans.Actualiza(lsSQL)
                                    MessageBox.Show("Revision Procesada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.limpiarForma()
                                    Me.limpiarProductos()
                                End If
                                Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
                                'Else
                                '    MessageBox.Show("No Tiene Permisos Para Aprobar Los Centros de Costo Afectados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If 'Revision por Marca o Centro de Costo
                    End If ''Revision
                End If
            ElseIf Me.cmbEstado.SelectedValue = 40 Or Me.cmbEstado.SelectedValue = 50 Then 'Cotizacion y OdC Generada
                ''Se deben Actualizar las Cotizaciones
                If tiene_permisos("mci_RequisicionesCotizar") Then
                    Dim snombresCotizaciones As String = String.Empty

                    If Me.cmbEstado.SelectedValue = 40 Then ''Mostrar Requisiciones con la Misma Marca y Mostrar Presupuesto
                        mostrarRequisiconesMismaMarca()
                    End If

                    If Me.cmbEstado.SelectedValue = 50 Then ''Debe Asociar OdC
                        If oDS.Tables("cotizaciones").Rows.Count = 0 Then
                            If MessageBox.Show("Debe Tener Cotizaciones Para Cambiar a Este Estado, Esta Seguro de Continuar", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                snombresCotizaciones = "Sin Cotizacion"
                            Else
                                Exit Try
                            End If



                        ElseIf oDS.Tables("cotizaciones").Rows.Count > 1 Then

                            For Each dr As DataRow In oDS.Tables("cotizaciones").Rows
                                If snombresCotizaciones.Length > 0 Then snombresCotizaciones += ","
                                snombresCotizaciones += dr.Item("nombre")
                            Next

                            Dim clsLista As New Automatizar.frm_lista

                            clsLista.Llenar_Combo_Vector(snombresCotizaciones.Split(","))
                            clsLista.ShowDialog()
                            snombresCotizaciones = clsLista._selectedValue
                            clsLista = Nothing

                        Else 'Solo tiene una
                            snombresCotizaciones = oDS.Tables("cotizaciones").Rows(0).Item("nombre")
                        End If

                    End If
                    'Guardar Cotizaciones

                    guardarCotizaciones(Otrans)

                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'" & pComentario & "'"
                    Otrans.Actualiza(lsSQL)
                    If Me.cmbEstado.SelectedValue = 50 Then
                        lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue + 10
                        Otrans.Actualiza(lsSQL)

                        lsSQL = "pa_upd_um_requisicion_proveedor '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & Me.txtProveedor.Text & "','" & snombresCotizaciones & "'"
                        Otrans.Actualiza(lsSQL)

                        For Each drAux As DataRow In oDS.Tables("detalle").Rows
                            lsSQL = "pa_upd_um_requisiciond_Precio '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & drAux.Item("linea") & "','" & drAux.Item("codigo") & "'," & drAux.Item("preciototal") & "," & drAux.Item("cantidadFacturada")
                            Otrans.Actualiza(lsSQL)
                        Next

                        '(c) 20230825 Actualizar anticipo
                        lsSQL = "pa_upd_um_requisicion_anticipo '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "','" & Me.cmbAnticipo.SelectedItem.ToString.ToUpper & "'"
                        Otrans.Actualiza(lsSQL)

                        clsGen.Escribir_Log(lsSQL)


                        MessageBox.Show("Actualizacion Exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("La Informacion del Proveedor y Precios No se Almacenara," & Chr(13) & " Por Que No Ha Finalizado de Cotizar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
                    Me.limpiarForma()
                    Me.limpiarProductos()
                Else ''No tiene Permisos
                    MessageBox.Show("No Tiene Permisos Para Cotizar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            ElseIf Me.cmbEstado.SelectedValue = 70 Then ''Factura Recibida
                If tiene_permisos("mci_RequisicionesRecibirFactura") Then

                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",''"
                    Otrans.Actualiza(lsSQL)


                    lsSQL = "pa_upd_um_requisicion_proveedor '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & Me.txtProveedor.Text & "',null,'" & Me.txtFacturaSerie.Text & "','" & Me.txtFacturaNumero.Text & "','" & Me.dtpFacturaFecha.Value & "'"
                    Otrans.Actualiza(lsSQL)

                    MessageBox.Show("Actualizacion Exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
                    Me.limpiarForma()
                    Me.limpiarProductos()
                Else
                    MessageBox.Show("No Tiene Permisos Para Procesar Este Estado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            ElseIf Me.cmbEstado.SelectedValue = 25 Then ''Cuando las Req Tienen Codigo de Cliente deben pasar por Aprobacion de Creditos

                If tiene_permisos("mci_RequisicionesAprobarCliente") Then
                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",''"
                    Otrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "',30,''"
                    Otrans.Actualiza(lsSQL)

                    Me.guardarAvisoReal(33, "Se Aprobo la Requisicion " & gs_empresa & "-" & Me.lblNumero.Text, Otrans)

                    MessageBox.Show("Actualizacion Exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Me.guardarImagenes(Otrans, clsGen, Me.lblNumero.Text)
                    Me.limpiarForma()
                    Me.limpiarProductos()
                End If
            ElseIf Me.cmbEstado.SelectedValue = 900 Then  'Rechazar Requisiciones
                ''Se deben Actualizar las Cotizaciones
                If tiene_permisos("mci_RequisicionesRechazar") Then
                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'" & pComentario & "'"
                    Otrans.Actualiza(lsSQL)
                    MessageBox.Show("Procesado Realizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.limpiarForma()
                    Me.limpiarProductos()
                End If

            ElseIf Me.cmbEstado.SelectedValue = 1000 Then 'Anular Requisiciones
                ''Se deben Actualizar las Cotizaciones
                If tiene_permisos("mci_RequisicionesAnular") Then
                    lsSQL = "pa_upd_um_requisicion_estado '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & Me.cmbEstado.SelectedValue & ",'" & pComentario & "'"
                    Otrans.Actualiza(lsSQL)
                    MessageBox.Show("Procesado Realizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.limpiarForma()
                    Me.limpiarProductos()
                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            llenarListado()

        End Try
    End Sub

    Private Sub mostrarRequisiconesMismaMarca()
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Dim dtDatos As DataTable

        Try

            dt = clsGen.ValoresDistinto(oDS.Tables("marca"), "codigo".Split(","))
            For Each dr As DataRow In dt.Rows
                dtDatos = clsGen.selectQuery("SCM", " pa_var_um_requisicion_marca '" & gs_empresa & "','" & dr.Item("codigo") & "','" & Today.ToString("dd/MM/yyyy") & "'")
                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dtDatos
                clsGen.Alinear_GridView(dtDatos, oform.dgv_resultado, "", "", "", "", True, True, 250, 0)
                Try
                    oform.Text = "Total del Mes " & Double.Parse(dtDatos.Compute("Sum(Neto)", "Neto>0").ToString).ToString("N")
                Catch ex As Exception

                End Try

                oform.ShowDialog()
                oform = Nothing

            Next


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub guardarAvisoReal(ByVal pidAviso As Integer, ByVal psMensaje As String, ByVal Otrans As Transaccional.Conexion)
        'Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable
        Dim idaviso As Integer = 0
        Dim sNombreReporte As String

        Try
            sNombreReporte = "Requisicion"
            sNombreReporte = exportar_reporte(sNombreReporte, False)


            '   Otrans.open()
            'lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (" & pidAviso.ToString & ")" '1= Ingreso de Dua OC
            lsSQL = "pa_var_um_seg_usuario_aviso_sistema " & pidAviso.ToString
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                clsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral", dr.Item("email").ToString, "Revision Requisicion " & gs_empresa & "-" & Me.lblNumero.Text, "Se Reviso la Requisicion Adjunta", sNombreReporte, "")
            Next

        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub aplicarSeguridad()

        Try
            SubirToolStripMenuItem.Visible = False
            Me.CargarImagenesToolStripMenuItem.Visible = False
            Me.CargarToolStripMenuItem.Visible = False

            If tiene_permisos("mci_subirCotizaciones") Then Me.SubirToolStripMenuItem.Visible = True
            If tiene_permisos("mci_subirImagenes") Then
                Me.CargarImagenesToolStripMenuItem.Visible = True
                Me.CargarToolStripMenuItem.Visible = True
            End If


            If tiene_permisos("mci_regresar_estado") Then Me.RegresarEstadoToolStripMenuItem.Visible = True


        Catch ex As Exception

        End Try
    End Sub

    Private Function validarGuardar() As Boolean
        Dim lbContinuar As Boolean = False
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            If oDS.Tables("marca").Rows.Count > 0 Then
                lbContinuar = True
            ElseIf oDS.Tables("centro_costo").Rows.Count > 0 Then
                lbContinuar = True
            Else
                lbContinuar = False
                MessageBox.Show("No se ha Especificado Centro de Costo o Marca", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If

            If oDS.Tables("gasto").Rows.Count > 0 Then
                lbContinuar = True
            Else

                lbContinuar = False
                MessageBox.Show("No se ha especificado Gasto Contable ", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If

            For Each dr As DataRow In oDS.Tables("detalle").Rows


                lsSQL = "pa_sel_um_producto '" & "LOGISERV" & "', '" & dr.Item("codigo") & "'"
                dt = Otrans.Obtiene(lsSQL)

                If dt.Rows.Count = 1 Then
                    If dt.Rows(0).Item("subfamilia").ToString = "S" Then
                        'If Me.txtNombreCliente.Text.Length = 0 Then
                        If oDS.Tables("clientes").Rows.Count = 0 Then
                            lbContinuar = False
                            MessageBox.Show("Para Este Tipo de Producto Debe Identificar Cliente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Me.txtCodigoCliente.Focus()
                            Exit Try
                        Else
                            lbContinuar = True
                        End If
                        Exit Try
                    Else
                        lbContinuar = True
                    End If
                End If
            Next

            If oDS.Tables("clientes").Rows.Count > 0 Then
                For Each dr As DataRow In oDS.Tables("clientes").Rows
                    lsSQL = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & dr.Item("codigo").ToString & "'"
                    dt = Otrans.Obtiene(lsSQL)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("vigencia").ToString.ToLower <> "s" Then
                            MessageBox.Show("La vigencia del Cliente " & dr.Item("razonSocial").ToString.Trim & " es " & dt.Rows(0).Item("vigencia_cliente") & " Comuniquese con Tesoreria ", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            lbContinuar = False
                        End If
                    Else
                        MessageBox.Show("El Codigo de Cliente " & dr.Item("codigo") & " No Existe, Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbContinuar = False
                    End If
                Next
            End If


            If Me.cmbCadena.SelectedItem Is Nothing Then
                lbContinuar = False
                MessageBox.Show("Debe Identificar Si la Requisicion es de una Cadena de Supermercados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If Me.cmbAnticipo.SelectedItem Is Nothing Then
                lbContinuar = False
                MessageBox.Show("Debe Identificar Si la Requisicion Tiene Anticipos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


            If Me.cmbAfectaInventario.SelectedItem Is Nothing Then
                lbContinuar = False
                MessageBox.Show("Debe Identificar Si la Requisicion Afecta Inventario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If Me.cmbCadena.SelectedItem.ToString.ToUpper = "" Then
                lbContinuar = False
                MessageBox.Show("Debe Identificar Si la Requisicion es de una Cadena de Supermercados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

            If Me.cmbAnticipo.SelectedItem.ToString.ToUpper = "SI" Then
                If Double.Parse(Me.txtMontoAnticipo.Text) < 100 Then
                    MessageBox.Show("Debe Indicar el Monto del Anticipos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbContinuar = False
                End If


            End If


        Catch ex As Exception
            lbContinuar = False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return lbContinuar
    End Function

    Private Function validarGenerarOC() As Boolean
        Try


            If Me.txtNombreProveedor.Text.Length > 0 Then
                For Each dr As DataRow In oDS.Tables("detalle").Rows
                    If Val(dr.Item("precioTotal")) = 0 Then '' Los productos que no se compraron deben agregar -1
                        If MessageBox.Show("Esta Seguro del Precio", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                            Return False
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Debe Agregar Proveedor para poder Generar la Orden de Compra", "Informacion", MessageBoxButtons.OK)
                Return False
            End If


            If Me.cmbAnticipo.SelectedItem.ToString.Trim.Length = 0 Then
                MessageBox.Show("Debe Indicar Si Aplica Anticipo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Problemas Para Cambiar Estado, Verifique los Precios", "Informacion", MessageBoxButtons.OK)
            Return False
        End Try
    End Function

    Private Function validarRevisar(ByVal Otrans As Transaccional.Conexion) As Boolean
        Dim lbValido As Boolean = False
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            If oDS.Tables("marca").Rows.Count > 0 Then

                lsSQL = "pa_var_um_sg_usuario_marca_contable_revision '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'," & gi_tipo_usuario
                dt = Otrans.Obtiene(lsSQL)

                If dt.Rows.Count > 0 Or gi_tipo_usuario = 1 Then
                    lbValido = True



                Else
                    lsSQL = "Empresa: " & gs_empresa & "|" &
                            "No. Requisción: " & Me.lblNumero.Text & "|" &
                            "Usuario: " & gs_usuario & "|" &
                            "Intruccion: " & lsSQL & "|"
                    If MessageBox.Show("No Tiene Permisos Para Aprobar Las Marcas Asociadas, Desea Solicitar Acceso", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        lsSQL += " ** SI solicita Acceso ***"
                    Else
                        lsSQL += " ** NO solicita Acceso ***"
                    End If


                    lbValido = False
                    clsGen.enviarMensajeTeams("carlos.oscal@umbralcorp.com", "Intento de Aprobar Requisición Marca", lsSQL)
                    clsGen.enviarMensajeTeams("jose.segura@umbralcorp.com", "Intento de Aprobar Requisición Marca", lsSQL)
                End If
            ElseIf oDS.Tables("centro_costo").Rows.Count > 0 Then '' Validacion por Centro de Costo
                If Me.cmbEstado.SelectedValue = 20 Then
                    lsSQL = "pa_var_um_seg_usuario_centro_costo_revision '" & gs_empresa & "','" & Me.lblNumero.Text & "','" & gs_usuario & "'"
                    dt = Otrans.Obtiene(lsSQL)

                    If dt.Rows.Count > 0 Or gi_tipo_usuario = 1 Then
                        lbValido = True


                    Else
                        lsSQL = "Empresa: " & gs_empresa & "|" &
                            "No. Requisción: " & Me.lblNumero.Text & "|" &
                            "Usuario: " & gs_usuario & "|" &
                            "Intruccion: " & lsSQL & "|"
                        If MessageBox.Show("No Tiene Permisos Para Aprobar Los Centros de Costo Afectados, Desea Solicitar Acceso", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            lsSQL += " ** SI solicita Acceso ***"
                        Else
                            lsSQL += " ** NO solicita Acceso ***"
                        End If

                        lbValido = False


                        clsGen.enviarMensajeTeams("carlos.oscal@umbralcorp.com", "Intento de Aprobar Requisición CCosto", lsSQL)
                        clsGen.enviarMensajeTeams("jose.segura@umbralcorp.com", "Intento de Aprobar Requisición CCosto", lsSQL)

                    End If
                End If 'Revision por Marca o Centro de Costo
            End If ''Revision

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try




        Return lbValido

    End Function

    Private Sub generarFiltro()

        Dim lsfiltro As String = String.Empty
        Dim lsEstados As String = String.Empty

        Try
            'Otrans.open()

            If Me.txtFiltro.Text.Length > 0 Then

                If Me.cmbCampos.Text = "numero" And Me.ComboBox2.Text <> "like" Then
                    Me.txtFiltro.Text = Me.txtFiltro.Text.PadLeft(10, "0")
                End If
                lsfiltro = "(" & Me.cmbCampos.Text & " " & Me.ComboBox2.Text & " '" & IIf(Me.ComboBox2.Text = "like", "%", "") & Me.txtFiltro.Text & IIf(Me.ComboBox2.Text = "like", "%", "") & "')"
            End If

            If Me.chkMostrarTodo.CheckState = CheckState.Unchecked Then

                If tiene_permisos("mci_operarCotizaciones") Then
                    lsEstados += IIf(lsEstados.Length > 0, ",", "") & "10,900,910,1000"
                End If

                If tiene_permisos("mci_RequisicionesCotizar") Then
                    lsEstados += IIf(lsEstados.Length > 0, ",", "") & "30,40,50,910"
                End If

                If tiene_permisos("mci_RequisicionesRecibirFactura") Then
                    lsEstados += IIf(lsEstados.Length > 0, ",", "") & "60"
                End If

                If tiene_permisos("mci_Revisar_Requisiciones") Then
                    lsEstados += IIf(lsEstados.Length > 0, ",", "") & "10,900,910,1000"
                End If

                If tiene_permisos("mci_RequisicionesAprobarCliente") Then
                    lsEstados += IIf(lsEstados.Length > 0, ",", "") & "24"
                End If



            End If

        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing

        End Try

        If lsEstados.Length > 0 Then lsfiltro = IIf(lsfiltro.Length > 0, lsfiltro & " and ", "") & " cod_estado in (" & lsEstados & ")"


        Try
            oDS.Tables("listado").DefaultView.RowFilter = lsfiltro
        Catch ex As Exception

        End Try


    End Sub

    Private Sub mostrarPresupuestoMarcaMes()
        Dim Otrans As New Transaccional.Conexion("umbralsa")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim dtPresupuesto As DataTable

        Try
            Otrans.open()

            dtPresupuesto = oDS.Tables("marca").Copy

            dtPresupuesto.Columns.Add(New DataColumn("presupuesto", GetType(Double)))
            dtPresupuesto.Columns.Add(New DataColumn("presupuesto_socio", GetType(Double)))
            'dtPresupuesto.Columns.Add(New DataColumn("precioTotal", GetType(Double)))


            For Each dr As DataRow In dtPresupuesto.Rows
                lsSQL = "pa_sel_um_integracion_finanzas '" & gs_empresa & "','" & DateTime.Parse(Me.txtFechaGrabo.Text).ToString("yyyyMM") & "','" & dr.Item("codigo") & "','S'"
                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    For Each dr2 As DataRow In dt.Rows
                        If dr2.Item("propio").ToString = "S" Then
                            dr.Item("presupuesto") = dr2.Item("presupuestoq")
                        Else
                            dr.Item("presupuesto_socio") = dr2.Item("presupuestoq")
                        End If
                    Next

                End If
            Next



            Dim clsGen As New ClasesGenerales.General

            Dim frmMostras As New frm_resultado
            frmMostras.Text = "Presupuesto Periodo " & DateTime.Parse(Me.txtFechaGrabo.Text).ToString("yyyyMM")
            frmMostras.dgv_resultado.DataSource = dtPresupuesto
            clsGen.Alinear_GridView(dtPresupuesto, frmMostras.dgv_resultado, "", ",linea,modificado,aprobado,", "", "", ",porcentaje_empresa=%_empresa,porcentaje_socio=%_socio,", ",porcentaje=40,porcentaje_empresa=40,porcentaje_socio=40,codigo=35,reviso=70,", "", True, True, 250, 0)
            frmMostras.ShowDialog()
            frmMostras.Dispose()
            frmMostras = Nothing

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub frmRequisiciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dtpFechaInicio.Value = "01/" & Today.Month & "/" & Today.Year
        Catch ex As Exception

        End Try
        crearEstructura()
        llenarCombos()
        llenarListado()
        aplicarSeguridad()

        Me.limpiarForma()
        Me.limpiarProductos()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Try
            Dim lbProcesar As Boolean = False
            Dim lbDatosPrevios As Boolean = False
            Dim dsLocal As DataSet

            If Me.txtDescripcion.Text.Length > 0 Then


                If Val(Me.txtCantidad.Text) > 0 And Val(Me.txtCosto.Text) > 0 Then


                    If oDS.Tables("detalle").Rows.Count > 0 Then
                        'If MessageBox.Show("Desea Obtener los Datos de las Lineas Anteriores", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        lbDatosPrevios = True
                        lbProcesar = True
                        'End If
                    End If
                    'Dim oform As New frmRequisiconesDetalle
                    'oform.psEmpresa = gs_empresa

                    If lbDatosPrevios Then
                        'oform.odsPrevio = oDS.Copy
                        'oform.pbDatosPrevios = True
                        dsLocal = oDS.Copy
                    Else
                        Dim oform As New frmRequisiconesDetalle
                        oform.psEmpresa = gs_empresa
                        oform.ShowDialog()
                        lbProcesar = oform.pbProcesar
                        dsLocal = oform.ods.Copy
                        oform = Nothing
                    End If

                    'oform.ShowDialog()
                    'lbProcesar = oform.pbProcesar
                    'dsLocal = oform.ods.Copy
                    'oform = Nothing
                    If lbProcesar Then
                        'If MessageBox.Show("Desea Agregar Solicitantes", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        '    Dim oform2 As New frmRequisicionUsuarioSolicito
                        '    oform2.ShowDialog()
                        '    oform = Nothing
                        'End If
                        If agregarLinea(dsLocal) Then

                            alinearGrid(0)
                            limpiarProductos()
                        End If
                    End If
                Else
                    MessageBox.Show("Debe Agregar Cantidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If 'Cantidad
            Else
                MessageBox.Show("Debe Ingresar Producto", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Problemas con los Datos, Verifique", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub dgvDetalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalle.Rows(rowIndex)
                If therow.Cells("modificado").Value = 1 Then
                    therow.DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDetalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        'Dim c As Control = Me.dg_productos.EditingControl

        If colIndex = 4 Then
            Me.dgvDetalle.Item("modificado", rowIndex).Value = 1
        End If
    End Sub

    Private Sub dgvDetalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim colIndex As Integer = Me.dgvDetalle.CurrentCell.ColumnIndex
            Dim rowIndex As Integer = Me.dgvDetalle.CurrentCell.RowIndex

            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                'therow = Me.dgvCentroCosto.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvDetalle.Item("linea", rowIndex).Value > 0 Then
                    Try
                        oDS.Tables("centro_costo").DefaultView.RowFilter = "linea = " & Me.dgvDetalle.Item("linea", rowIndex).Value
                    Catch ex As Exception
                    End Try

                    Try
                        oDS.Tables("marca").DefaultView.RowFilter = "linea = " & Me.dgvDetalle.Item("linea", rowIndex).Value
                    Catch ex As Exception
                    End Try

                    Try
                        oDS.Tables("gasto").DefaultView.RowFilter = "linea = " & Me.dgvDetalle.Item("linea", rowIndex).Value
                    Catch ex As Exception
                    End Try

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        'Enter
        If Asc(e.KeyChar()) = 13 Then
            buscarProducto(Me.txtCodigo.Text)
        End If
    End Sub

    Private Sub txtObservacionesLinea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacionesLinea.GotFocus
        Me.txtObservacionesLinea.SelectAll()
    End Sub

    Private Sub txtCantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.GotFocus
        Me.txtCantidad.SelectAll()
    End Sub

    Private Sub txtCosto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCosto.GotFocus, txtMontoAnticipo.GotFocus
        Me.txtCosto.SelectAll()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Me.btnGuardar.Text.ToLower.StartsWith("guar") Then
            If validarGuardar() Then

                If oDS.Tables("marca").Rows.Count > 0 Then
                    mostrarPresupuestoMarcaMes()
                End If
                Me.guardarRequisicion(-1)
            End If

        Else ''Modificar
            If Me.cmbEstado.SelectedValue = 50 Then ''OdeC Generada
                If validarGenerarOC() Then
                    modificarRequisicion("")
                End If

            ElseIf Me.cmbEstado.SelectedValue = 70 Then 'Factura Recibida
                If Me.txtFacturaNumero.Text.Length > 1 And Me.txtFacturaSerie.Text.Length > 1 And Me.dtpFacturaFecha.Value > Today.AddDays(-30) Then
                    modificarRequisicion("")
                Else
                    MessageBox.Show("Debe Agregar Informacion de la Factura", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                If Me.cmbEstado.SelectedValue = 900 Or Me.cmbEstado.SelectedValue = 1000 Then
                    Dim scomentario As String = InputBox("Ingrese Motivo")
                    If scomentario.Length < 10 Then
                        MessageBox.Show("Debe Ingresar Un Motivo Valido")
                    Else
                        modificarRequisicion(scomentario)
                    End If
                Else
                    modificarRequisicion("") 'Cambia de Estado pe Autorizacion
                End If
            End If
        End If
    End Sub


    Private Sub CargarImagenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarImagenesToolStripMenuItem.Click
        subirImagenes()
    End Sub

    Private Sub VerImagenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerImagenesToolStripMenuItem.Click
        MostrarImagenes()
    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick

        Try
            Dim colIndex As Integer = Me.dgvListado.CurrentCell.ColumnIndex
            Dim rowIndex As Integer = Me.dgvListado.CurrentCell.RowIndex

            mostrarRequisicion(Me.dgvListado.Item("numero", rowIndex).Value, rowIndex)
        Catch ex As Exception
        End Try

    End Sub

    Private Function exportar_reporte(ByVal psNombreReporte As String, ByVal pbVisualizar As Boolean) As String
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\" & psNombreReporte & "_" & gs_empresa & "_" & Me.lblNumero.Text & ".pdf"
        Dim pm_conexion(3) As String
        pm_conexion = clsgen.Parametros_Conexion("SCM")

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\" & psNombreReporte & ".rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero"
            pm_valores(0) = gs_empresa
            pm_valores(1) = Me.lblNumero.Text





            'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", Not pbVisualizar, False, "PDF", pbVisualizar)
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), Not pbVisualizar, False, "PDF", pbVisualizar)

        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

        Return lsArchivoGenerado
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim sNombreReporte As String = String.Empty

        Try
            If Me.txtNombreProveedor.Visible = True And Me.txtNombreProveedor.Text.Length > 0 Then


                Try
                    Dim clsLista As New Automatizar.frm_lista
                    clsLista.Llenar_Combo_Vector("Requisicion,Orden de Compra Local".Split(","))
                    clsLista.ShowDialog()
                    sNombreReporte = clsLista._selectedValue
                    clsLista = Nothing

                Catch ex As Exception

                End Try
            Else
                sNombreReporte = "Requisicion"
            End If
            exportar_reporte(sNombreReporte, True)


        Catch ex As Exception
        Finally

        End Try


    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Try

            Dim cod_producto As String = String.Empty
            Dim frm_busqueda As New frm_busqueda_general

            frm_busqueda.parametros_fijos = " empresa = 'LOGISERV' and "
            frm_busqueda.parametros = "glosa,producto,tipoproducto"
            frm_busqueda.nombre_vista = "scm.flexline.producto"
            frm_busqueda.lista_campos = "producto,glosa,tipoproducto"
            frm_busqueda.txt_buscar1.Focus()

            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.dg_buscar.ReadOnly = False
            frm_busqueda.btn_seleccion_multipe.Visible = False
            frm_busqueda.Btn_Aceptar.Visible = False
            frm_busqueda.ShowDialog(Me)

            cod_producto = frm_busqueda.resultado

            frm_busqueda.Dispose()
            frm_busqueda = Nothing

            If cod_producto <> Nothing Then
                Me.txtCodigo.Text = cod_producto
                buscarProducto(Me.txtCodigo.Text)

                'validacion_producto()
                'If valida_producto Then
                '    buscar_producto(cod_producto)
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        'mostrarRequisiconesMismaMarca()
        Me.limpiarForma()
        Me.limpiarProductos()
        If MessageBox.Show("La Nueva Requisicion es en Quetzales", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.cmb_Moneda.SelectedValue = "Quetzales"

        Else
            If gs_empresa = "VINOTECAHN" Then
            Else
                If MessageBox.Show("La Nueva Requisicion es en Dolares", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Me.cmb_Moneda.SelectedValue = "Dolares"
                End If
            End If
        End If
    End Sub

    Private Sub SubirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirToolStripMenuItem.Click
        Me.subirPDF("cotizaciones")
    End Sub



    Private Sub CargarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarToolStripMenuItem.Click
        Me.subirPDF("imagenes")
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
        frm_busqueda.ShowDialog(Me)

        'Me.txtCodigoCliente.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        'Me.buscacliente()
    End Sub

    Private Sub VerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerToolStripMenuItem.Click
        mostrarCotizaciones()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm_busqueda As New frm_busqueda_general
        frm_busqueda.Text = ":: Busqueda de Proveedor ::"
        frm_busqueda.nombre_vista = "ctacte"
        frm_busqueda.parametros_fijos = " tipoctacte = 'proveedor' and empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte"
        frm_busqueda.lista_campos = "CtaCte, codlegal, RazonSocial,Giro,CondPago,Vigencia "
        frm_busqueda.ShowDialog(Me)

        Me.txtProveedor.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Me.buscaProveedor()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        If e.KeyChar = Chr(13) Then
            generarFiltro()
        End If
    End Sub

    Private Sub RequisicionesAProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequisicionesAProveedoresToolStripMenuItem.Click

        Dim sNombreReporte As String = "Requisicion_Proveedor"
        Dim pathReporte As String = ""
        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)
        Dim clsGen As New ClasesGenerales.General

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        pm_conexion = clsGen.Parametros_Conexion("SCM")

        Try
            'Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\" & sNombreReporte & "_" & gs_empresa & "_" & Me.lblNumero.Text & ".pdf"

            pathReporte = clsGen.Path_Reporte()
            pathReporte += "Compras e Importaciones\" & sNombreReporte & ".rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero"
            pm_valores(0) = gs_empresa
            pm_valores(1) = Me.lblNumero.Text

            'Oaut._reporte_generico(pathReporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", True, False, "PDF", True)
            Oaut._reporte_generico(pathReporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", True)

            'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), Not pbVisualizar, False, "PDF", pbVisualizar)
        Catch ex As Exception
        Finally
            clsGen = Nothing
            Oaut.finalizar()
            Oaut = Nothing
        End Try

    End Sub

    Private Sub VisualizarEstadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarEstadosToolStripMenuItem.Click
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String = "pa_sel_um_requisicionEstado '" & gs_empresa & "','" & Me.lblNumero.Text & "'"
        Dim clsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            dt = Otrans.Obtiene(lsSQL)

            Dim clsResultado As New ClasesGenerales.frm_resultado
            clsResultado.dgv_resultado.DataSource = dt.DefaultView
            clsGen.Alinear_GridView(dt, clsResultado.dgv_resultado, "", "", "", "", "", "", "", True, True, 250, 0)
            clsResultado.Text = "Requisicion :: " & Me.lblNumero.Text & " :: " & gs_empresa
            clsResultado.ShowDialog()
            clsResultado = Nothing
            clsResultado.Dispose()

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing

        End Try
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)
        Try
            Dim linea As Integer = dgvDetalle.Item("linea", e.Row.Index).Value


            Try
                For Each dr As DataRow In oDS.Tables("centro_costo").Rows
                    If dr.Item("linea") = linea Then
                        dr.Delete()
                    End If
                Next
            Catch ex As Exception

            End Try

            Try
                For Each dr As DataRow In oDS.Tables("marca").Rows
                    If dr.Item("linea") = linea Then
                        dr.Delete()
                    End If
                Next
            Catch ex As Exception

            End Try

            Try
                For Each dr As DataRow In oDS.Tables("gasto").Rows
                    If dr.Item("linea") = linea Then
                        dr.Delete()
                    End If
                Next
            Catch ex As Exception

            End Try
            If Me.btnGuardar.Text.ToLower.StartsWith("modi") Then
                Me.aplicarFiltro(0)
                Me.cmbEstado.SelectedValue = 10
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGenerarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarFecha.Click
        Me.llenarListado()
    End Sub



    Private Sub txtProveedor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.Leave
        Me.buscaProveedor()
    End Sub


    Private Sub dgvCliente_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCliente.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        'Dim c As Control = Me.dg_productos.EditingControl

        If colIndex = 0 Then
            If Me.dgvCliente.Item("codigo", rowIndex).Value.ToString = "+" Then

                Dim frm_busqueda As New frm_busqueda_general

                frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
                frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
                frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
                frm_busqueda.ShowDialog(Me)
                Me.dgvCliente.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                'Me.txtCodigoCliente.Text = frm_busqueda.resultado
                frm_busqueda = Nothing
                'Me.buscacliente()

            ElseIf Me.dgvCliente.Item("codigo", rowIndex).Value.ToString.Length > 1 Then
                Dim sNombreCliente = Me.buscacliente(Me.dgvCliente.Item("codigo", rowIndex).Value)
                Me.dgvCliente.Item("razonsocial", rowIndex).Value = sNombreCliente
            End If
        End If
    End Sub

    Private Sub txtObservacionesGenerales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacionesGenerales.TextChanged
        Me.lbCambioObservaciones = True
    End Sub

    Private Sub txtLugarEntrega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugarEntrega.TextChanged
        Me.lbCambioLugarEntrega = True
    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaEntrega.ValueChanged
        Me.lbcambioFechaEntrega = True
    End Sub


    Private Sub VerificarPresupuestosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarPresupuestosToolStripMenuItem.Click
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "FN_VERIFICA_PRESUPUESTO '" & gs_empresa & "','SOCIO','102','" & Today.ToString("dd/MM/yyyy") & "','M','" & Me.lblNumero.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            Dim oform As New frm_resultado
            oform.dgv_resultado.DataSource = dt
            oform.ShowDialog()
            oform.Dispose()


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing


        End Try
    End Sub


    Private Sub PresupuestoMesRequisicionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PresupuestoMesRequisicionToolStripMenuItem.Click
        mostrarPresupuestoMarcaMes()
    End Sub

    Private Sub RegresarEstadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegresarEstadoToolStripMenuItem.Click
        If MessageBox.Show("Esta Seguro de Regresar a Estado Anterior", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        End If
    End Sub


    Private Sub btnCalendarizar_Click(sender As Object, e As EventArgs) Handles btnCalendarizar.Click
        If MessageBox.Show("Esta Seguro de Guardar y Calendarizar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If validarGuardar() Then

                Dim oform As New frmRequisicionesCalendario
                oform.ShowDialog()

                If oform.pbOpcion = False Then
                    MessageBox.Show("Debe Agregar Informacion Para Calendarizar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim iRepeticiones As Integer

                If oform.rbRepeticiones.Checked = True Then
                    iRepeticiones = oform.NumericUpDown1.Value
                Else
                    iRepeticiones = DateDiff(DateInterval.Month, Today, oform.DateTimePicker1.Value)
                End If


                oform.Dispose()
                oform = Nothing

                Me.guardarRequisicion(iRepeticiones)


            End If
        End If

    End Sub

    Private Sub btnPlantilla_Click(sender As Object, e As EventArgs) Handles btnPlantilla.Click
        If MessageBox.Show("Esta Seguro de Convertir esta Requisicion en Plantilla", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Me.btnGuardar.Enabled = True
            Me.btnGuardar.Text = "Guardar"
            Me.lblNumero.Text = "0"

            Dim dtc As DataColumn

            For Each dc As DataGridViewColumn In Me.dgvDetalle.Columns






                If ",observaciones,cantidad,precio,".ToString.ToLower.IndexOf("," & dc.Name.ToString.ToLower & ",") >= 0 Then
                    dc.ReadOnly = False
                End If
            Next

            Me.alinearGrid(0, True)

        End If
    End Sub

    Private Sub txtProveedorRequi_Leave(sender As Object, e As EventArgs) Handles txtProveedorRequi.Leave
        buscaProveedor_requisicion()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnbuscarProveedorRequi.Click
        Dim frm_busqueda As New frm_busqueda_general
        frm_busqueda.Text = ":: Busqueda de Proveedor ::"
        frm_busqueda.nombre_vista = "ctacte"
        frm_busqueda.parametros_fijos = " tipoctacte = 'proveedor' and empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte"
        frm_busqueda.lista_campos = "CtaCte, codlegal, RazonSocial,Giro,CondPago,Vigencia "
        frm_busqueda.ShowDialog(Me)

        Me.txtProveedorRequi.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Me.buscaProveedor_requisicion()
    End Sub


    Private Sub txtFacturaNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFacturaNumero.KeyPress

        If e.KeyChar = Chr(13) Then
            Try


                Dim lsSQL As String
                Dim clsgen As New ClasesGenerales.General

                Dim dt As DataTable

                lsSQL = "pa_sel_um_fel_documento_compras_numero '" & txtFacturaNumero.Text & "'"
                dt = clsgen.selectQuery("RegionalDBintOut", lsSQL)
                If dt.Rows.Count() > 0 Then
                    With dt.Rows(0)
                        'Me.txtNumeroFEL.Text = .Item("numero").ToString
                        Me.txtFacturaSerie.Text = .Item("serie").ToString
                        'Me.txtMontoFEL.Text = .Item("total").ToString
                        'Me.dtpFacturaFecha.Text = .Item("pdf_link").ToString

                        Me.dtpFacturaFecha.Value = .Item("fecha")
                        Try
                            Dim pdfPath As String = .Item("pdf_link").ToString

                            ' Crear un nuevo proceso para abrir el archivo PDF
                            Dim process As New Process()
                            process.StartInfo = New ProcessStartInfo(pdfPath) With {
                                .UseShellExecute = True
                            }

                            ' Iniciar el proceso
                            process.Start()

                            Dim savePath As String = "C:\temp\" + gs_empresa + "_" + Me.lblNumero.Text & "_" & txtFacturaNumero.Text + ".pdf"
                            Using client As New WebClient()
                                ' Descargar el archivo y guardarlo en la ruta especificada
                                client.DownloadFile(pdfPath, savePath)
                            End Using

                        Catch ex As Exception

                        End Try
                    End With

                End If
            Catch ex As Exception

            End Try
        End If
    End Sub



    Private Sub cmbAnticipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAnticipo.SelectedValueChanged

        If Me.cmbAnticipo.SelectedItem.ToString.ToUpper.Equals("SI") Then
            Me.txtMontoAnticipo.Visible = True
        Else
            Me.txtMontoAnticipo.Visible = False
        End If

    End Sub

    Private Sub txtMontoAnticipo_TextChanged(sender As Object, e As EventArgs) Handles txtMontoAnticipo.TextChanged

    End Sub

    Private Sub txtMontoAnticipo_Leave(sender As Object, e As EventArgs) Handles txtMontoAnticipo.Leave
        Try
            txtMontoAnticipo.Text = Format(Convert.ToDecimal(txtMontoAnticipo.Text), "###,###,##0.00").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub
End Class