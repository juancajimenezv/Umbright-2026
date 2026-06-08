Public Class frmTrackingFactura

    Dim ds As DataSet
    Private Sub Crear_Esquema()
        Try
            ds = New DataSet
        Catch ex As Exception
        End Try

        Dim clGen As New ClasesGenerales.General
        Dim dt As New DataTable("control_transporte")

        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_guia", GetType(Date)))
        dt.Columns.Add(New DataColumn("fecha_en_Control", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("piloto", GetType(String)))
        dt.Columns.Add(New DataColumn("vehiculo", GetType(String)))
        dt.Columns.Add(New DataColumn("ayudante", GetType(String)))
        dt.Columns.Add(New DataColumn("chequeador", GetType(String)))
        dt.Columns.Add(New DataColumn("comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_creditos", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("recibio_creditos", GetType(String)))

        ds.Tables.Add(dt.Copy)

        dt.TableName = "devoluciones"
        ds.Tables.Add(dt.Copy)

        dt.TableName = "controles_asociados"
        ds.Tables.Add(dt.Copy)

    End Sub


    Private Sub Tracking_pedido()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim dt_aux As New DataTable
        Dim dt2 As New DataTable
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim lirownumber As Integer
        Dim clsgen As New ClasesGenerales.General
        Dim cl As DataGridTextBoxColumn
        Dim dr As DataRow
        Dim guia_anterior As String = ""

        Try
            Crear_Esquema()
            'Me.TabControl1.SelectedTab = Me.TabPage3
            'lirownumber = Me.dg_top_pedidos.CurrentCell.RowNumber

            otrans.open()

            'Informacion del pedido
            'ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)
            Me.txt_comentario.Text = dt.Rows(0).Item("comentario1")
            Me.txt_vendedor.Text = dt.Rows(0).Item("vendedor")
            Me.txt_fecha.Text = dt.Rows(0).Item("fecha")
            Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fechaumodif")
            Me.txt_lista_precios.Text = dt.Rows(0).Item("ListaPrecio")
            Me.txt_tipo_pedido.Text = dt.Rows(0).Item("TipoDocto")
            Me.txt_aprobacion.Text = dt.Rows(0).Item("descripcion")
            Me.txt_porcentaje.Text = dt.Rows(0).Item("PorcentajeAsignado")
            Me.txt_numero.Text = dt.Rows(0).Item("numero")
            If dt.Rows(0).Item("descripcion_vigencia") = "ANULADO" Then
                Me.txt_aprobacion.Text = "ANULADO"
            End If
            Me.txt_total_pedido.Text = dt.Rows(0).Item("total").ToString
            Me.txt_aprobacion_pedido.Text = dt.Rows(0).Item("fecha_aprobacion")


            'Picking
            'ls_sql = "pa_var_um_impresion_picking '" & gs_empresa & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dg_picking.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_picking, dt.TableName, -1, 250, -1, False, True, ",tipo_documento,numero,fecha_impresion,nombre_picker", True, "")

            cl = Me.dg_picking.TableStyles(0).GridColumnStyles(2)
            cl.HeaderText = "Fecha Picking"


            ' facturas
            'ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" & _
            '        Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dgv_facturas.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_facturas, ",tipodocto,numero,fechaumodif,bodega,total,", "", "", "", ",fechaumodif=fecha facturado,", ",fechaumodif=300,", "", True, True, 250, 100)



            'clsgen.Alinea_Grid(dt, Me.dg_factura_generada, dt.TableName, -1, 250, 0, False, True, ",TipoDocto,Numero,FechaUModif,Bodega,Total", True, "")

            Try
                '       cl = Me.dg_factura_generada.TableStyles(0).GridColumnStyles(5)
                'cl.HeaderText = "Fecha Facturado"
            Catch ex As Exception
            End Try

            dt.TableName = "facturas_generadas"
            If ds.Tables.IndexOf("facturas_generadas") > 0 Then
                ds.Tables.Remove("facturas_generadas")
            End If
            ds.Tables.Add(dt.Copy)
            '

            'Guia de Transporte
            For Each dr In dt.Rows

                ls_sql = "pa_sel_var_documento_generado '" & gs_empresa & "','" & _
                            dr.Item("TipoDocto") & "','" & _
                            dr.Item("Numero") & "'"

                ls_sql2 = "pa_var_um_documento_control_transporte '" & gs_empresa & "','" & _
                            dr.Item("TipoDocto") & "','" & _
                            dr.Item("Numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)

                If dt_aux.Rows.Count > 0 Then
                    If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                        Agregar_Esquema(dt_aux, IIf(dt_aux.Rows(0).Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones"))

                        'dt2.ImportRow(dt_aux.Rows(0))
                        If dt2.Rows.Count > 0 Then
                            Me.dg_control_transporte.DataSource = dt2
                        End If
                        guia_anterior = dt_aux.Rows(0).Item("numero")
                    End If

                Else
                    'Tengo que Buscar en la Guia Temporal
                    dt_aux = otrans.Obtiene(ls_sql2)

                    If dt_aux.Rows.Count > 0 Then

                        ls_sql = "pa_sel_um_documento '" & gs_empresa & "','" & _
                                "CONTROL DE TRANSPORTE','" & _
                                dt_aux.Rows(0).Item("numero_temporal") & "'"
                        dt_aux = otrans.Obtiene(ls_sql)

                        If dt_aux.Rows.Count > 0 Then
                            If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                                Agregar_Esquema(dt_aux, "control_transporte")
                            End If
                            guia_anterior = dt_aux.Rows(0).Item("numero")
                        End If
                    End If
                End If

            Next


            Me.dg_control_transporte.DataSource = ds.Tables("control_transporte")
            clsgen.Alinea_Grid(ds.Tables("control_transporte"), Me.dg_control_transporte, ds.Tables("control_transporte").TableName, _
                                        -1, 190, 0, False, True, "", True, "")

            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(8)
            cl.HeaderText = "Com Liquidador"
            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(0)
            cl.Width = 50

            Me.dg_devoluciones.DataSource = ds.Tables("devoluciones")

            If ds.Tables("devoluciones").Rows.Count > 0 Then
                ls_sql = "pa_sel_um_documentod '" & gs_empresa & "','" & _
                        ds.Tables("devoluciones").Rows(0).Item("tipo") & "','" & _
                        ds.Tables("devoluciones").Rows(0).Item("numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)
                If dt_aux.Rows.Count > 0 Then
                    ds.Tables("devoluciones").Rows(0).Item("comentario") = dt_aux.Rows(0).Item("descripcion_motivo")
                End If
                ds.Tables("devoluciones").Rows(0).Item("piloto") = ""
                ds.Tables("devoluciones").Rows(0).Item("vehiculo") = ""
            End If

            clsgen.Alinea_Grid(ds.Tables("devoluciones"), Me.dg_devoluciones, ds.Tables("devoluciones").TableName, _
                            -1, 200, 10, False, True, "tipo,numero,fecha_guia,fecha_en_control,comentario", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try

    End Sub

    Private Sub Agregar_Esquema(ByVal dt As DataTable, ByVal nombre_esquema As String)
        Dim dr As DataRow
        Dim dr_aux As DataRow


        For Each dr In dt.Rows

            dr_aux = ds.Tables( _
                            IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones") _
                            ).NewRow()
            dr_aux.Item("tipo") = dr.Item("TipoDocto")
            dr_aux.Item("numero") = dr.Item("numero")
            dr_aux.Item("fecha_guia") = dr.Item("fecha")
            dr_aux.Item("fecha_en_control") = dr.Item("FechaUModif")
            dr_aux.Item("piloto") = dr.Item("Analisis")
            dr_aux.Item("vehiculo") = dr.Item("TipoCta")
            dr_aux.Item("ayudante") = dr.Item("AnalisisE1")
            dr_aux.Item("chequeador") = dr.Item("AnalisisE2")
            dr_aux.Item("comentario") = dr.Item("comentario")
            Try
                If dr.Item("usuario_recepcion_creditos").ToString.Trim.Length > 0 Then
                    dr_aux.Item("fecha_creditos") = dr.Item("fecha_recepcion_creditos")
                    dr_aux.Item("recibio_creditos") = dr.Item("usuario_recepcion_creditos")
                End If

            Catch ex As Exception

            End Try

            ds.Tables( _
                    IIf(dr.Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones") _
                    ).Rows.Add(dr_aux)
        Next

    End Sub

    Private Sub cargar_empresa()
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_SqlScript As String
        Dim otransaccion As Transaccional.Conexion

        otransaccion = New Transaccional.Conexion("flexline")
        otransaccion.open()

        ls_SqlScript = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        otransaccion.close()
        ldt_table.TableName = "empresas_usuarios"


        Me.cmbEmpresa.DisplayMember = "empresa"
        Me.cmbEmpresa.ValueMember = "empresa"
        Me.cmbEmpresa.DataSource = ldt_table

    End Sub

    Private Sub cargarTipoDocto()

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try

            lsSQL = "pa_sel_um_tipodocumento '" & Me.cmbEmpresa.SelectedValue & "','Boleta (v)'"
            clsGen.fillComboBox(Otrans, lsSQL, "tipodocto", "tipoDocto", "tipoDocto", cmbTipoDocto)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub realizarTracking()

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim dt_aux As New DataTable
        Dim dt2 As New DataTable
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim lirownumber As Integer
        Dim clsgen As New ClasesGenerales.General
        Dim cl As DataGridTextBoxColumn
        Dim dr As DataRow
        Dim guia_anterior As String = ""

        Try
            Me.gbWalmart.Visible = False
            Me.txtNumeroFactura.Text = Me.txtNumeroFactura.Text.PadLeft(10, "0")
            Crear_Esquema()
            'Me.TabControl1.SelectedTab = Me.TabPage3
            'lirownumber = Me.dg_top_pedidos.CurrentCell.RowNumber

            otrans.open()

            ls_sql = "pa_sel_um_documentod '" & Me.cmbEmpresa.SelectedValue & "','" & _
                    Me.cmbTipoDocto.SelectedValue & "','"

            ls_sql = ls_sql & IIf(Me.cmbTipoDocto.SelectedValue.ToString.StartsWith("FACE"), Me.nupAnio.Value, "")

            ls_sql = ls_sql & Me.txtNumeroFactura.Text.PadLeft(10, "0") & "'"

            dt = otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then


                Try


                    'Informacion del pedido
                    ls_sql = "pa_sel_um_documento '" & Me.cmbEmpresa.SelectedValue & "','" &
                        dt.Rows(0).Item("tipodoctoOrigen").ToString & "','" &
                        dt.Rows(0).Item("numero_origen").ToString & "'"
                    '        Me.dg_top_pedidos.Item(lirownumber, 1).ToString & "','" & _
                    '        Me.dg_top_pedidos.Item(lirownumber, 2).ToString & "'"

                    dt = otrans.Obtiene(ls_sql)
                    Me.txt_comentario.Text = dt.Rows(0).Item("comentario1").ToString
                    Me.txt_vendedor.Text = dt.Rows(0).Item("vendedor").ToString
                    Me.txt_fecha.Text = dt.Rows(0).Item("fecha")
                    'Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fechaumodif")

                    '(c)
                    'Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fechaumodif")
                    Me.txt_fecha_grabo.Text = dt.Rows(0).Item("fecha_insertado")

                    Me.txt_lista_precios.Text = dt.Rows(0).Item("ListaPrecio")
                    Me.txt_tipo_pedido.Text = dt.Rows(0).Item("TipoDocto")
                    Me.txt_aprobacion.Text = dt.Rows(0).Item("descripcion")
                    Me.txt_porcentaje.Text = dt.Rows(0).Item("PorcentajeAsignado")
                    Me.txt_numero.Text = dt.Rows(0).Item("numero")
                    If dt.Rows(0).Item("descripcion_vigencia") = "ANULADO" Then
                        Me.txt_aprobacion.Text = "ANULADO"
                    End If
                    Me.txt_total_pedido.Text = dt.Rows(0).Item("total").ToString
                    Me.txt_aprobacion_pedido.Text = dt.Rows(0).Item("fecha_aprobacion")
                    Me.txtDireccionEntrega.Text = dt.Rows(0).Item("direccion").ToString
                Catch ex As Exception

                End Try
            End If
            'Picking
            ls_sql = "pa_var_um_impresion_picking_factura '" & Me.cmbEmpresa.SelectedValue & "','" &
                    Me.cmbTipoDocto.SelectedValue & "','" &
                    IIf(Me.cmbTipoDocto.SelectedValue.ToString.StartsWith("FACE"), Me.nupAnio.Value, "") &
                    Me.txtNumeroFactura.Text.PadLeft(10, "0") & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dg_picking.DataSource = dt
            clsgen.Alinea_Grid(dt, Me.dg_picking, dt.TableName, -1, 250, -1, False, True, ",tipo_documento,numero,fecha_impresion,nombre_picker,ac_ubicacion,", True, "")

            cl = Me.dg_picking.TableStyles(0).GridColumnStyles(2)
            cl.HeaderText = "Fecha Picking"


            ' facturas
            ls_sql = "pa_sel_var_documento_generado_factura '" & Me.cmbEmpresa.SelectedValue & "','" &
                    Me.cmbTipoDocto.SelectedValue & "','" &
                    IIf(Me.cmbTipoDocto.SelectedValue.ToString.StartsWith("FACE"), Me.nupAnio.Value, "") &
                    Me.txtNumeroFactura.Text.PadLeft(10, "0") & "'"

            dt = otrans.Obtiene(ls_sql)

            Me.dgv_facturas.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_facturas, ",tipodocto,numero,fechaumodif,bodega,total,analisise28,", "", "", "", ",fechaumodif=fecha facturado,analisise28=area despacho,", ",fechaumodif=100,", "", True, True, 250, 100)



            'clsgen.Alinea_Grid(dt, Me.dg_factura_generada, dt.TableName, -1, 250, 0, False, True, ",TipoDocto,Numero,FechaUModif,Bodega,Total", True, "")

            Try
                '       cl = Me.dg_factura_generada.TableStyles(0).GridColumnStyles(5)
                'cl.HeaderText = "Fecha Facturado"
            Catch ex As Exception
            End Try

            dt.TableName = "facturas_generadas"
            If ds.Tables.IndexOf("facturas_generadas") > 0 Then
                ds.Tables.Remove("facturas_generadas")
            End If
            ds.Tables.Add(dt.Copy)
            '

            'Guia de Transporte
            For Each dr In dt.Rows

                ls_sql = "pa_sel_var_documento_generado '" & Me.cmbEmpresa.SelectedValue & "','" &
                            dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"

                ls_sql2 = "pa_var_um_documento_control_transporte '" & Me.cmbEmpresa.SelectedValue & "','" &
                            dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)

                If dt_aux.Rows.Count > 0 Then
                    If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                        Agregar_Esquema(dt_aux, IIf(dt_aux.Rows(0).Item("TipoDocto").ToString.StartsWith("CONTROL DE TRANSPORTE"), "control_transporte", "devoluciones"))

                        'dt2.ImportRow(dt_aux.Rows(0))
                        If dt2.Rows.Count > 0 Then
                            Me.dg_control_transporte.DataSource = dt2
                        End If
                        guia_anterior = dt_aux.Rows(0).Item("numero")
                    End If

                Else
                    'Tengo que Buscar en la Guia Temporal
                    dt_aux = otrans.Obtiene(ls_sql2)

                    If dt_aux.Rows.Count > 0 Then

                        ls_sql = "pa_sel_um_documento '" & Me.cmbEmpresa.SelectedValue & "','" &
                                "CONTROL DE TRANSPORTE','" &
                                dt_aux.Rows(0).Item("numero_temporal") & "'"
                        dt_aux = otrans.Obtiene(ls_sql)

                        If dt_aux.Rows.Count > 0 Then
                            If dt_aux.Rows(0).Item("numero") <> guia_anterior Then
                                Agregar_Esquema(dt_aux, "control_transporte")
                            End If
                            guia_anterior = dt_aux.Rows(0).Item("numero")
                        End If
                    End If
                End If

            Next


            Me.dg_control_transporte.DataSource = ds.Tables("control_transporte")
            clsgen.Alinea_Grid(ds.Tables("control_transporte"), Me.dg_control_transporte, ds.Tables("control_transporte").TableName,
                                        -1, 190, 0, False, True, "", True, "")

            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(8)
            cl.HeaderText = "Com Liquidador"
            cl = Me.dg_control_transporte.TableStyles(0).GridColumnStyles(0)
            cl.Width = 50

            Me.dg_devoluciones.DataSource = ds.Tables("devoluciones")

            If ds.Tables("devoluciones").Rows.Count > 0 Then
                ls_sql = "pa_sel_um_documentod '" & Me.cmbEmpresa.SelectedValue & "','" &
                        ds.Tables("devoluciones").Rows(0).Item("tipo") & "','" &
                        ds.Tables("devoluciones").Rows(0).Item("numero") & "'"

                dt_aux = otrans.Obtiene(ls_sql)
                If dt_aux.Rows.Count > 0 Then
                    ds.Tables("devoluciones").Rows(0).Item("comentario") = dt_aux.Rows(0).Item("descripcion_motivo")
                End If
                ds.Tables("devoluciones").Rows(0).Item("piloto") = ""
                ds.Tables("devoluciones").Rows(0).Item("vehiculo") = ""
            End If

            clsgen.Alinea_Grid(ds.Tables("devoluciones"), Me.dg_devoluciones, ds.Tables("devoluciones").TableName,
                            -1, 200, 10, False, True, "tipo,numero,fecha_guia,fecha_en_control,comentario", True, "")


            dt = otrans.Obtiene("scm.flexline.pa_var_um_documento_envio_walmart_detalle_factura '" & Me.cmbEmpresa.SelectedValue & "','" &
                    Me.cmbTipoDocto.SelectedValue & "','" &
                    IIf(Me.cmbTipoDocto.SelectedValue.ToString.StartsWith("FACE"), Me.nupAnio.Value, "00") &
                    Me.txtNumeroFactura.Text.PadLeft(10, "0") & "'")
            If dt.Rows.Count > 0 Then
                Me.dgWalmart.DataSource = dt
                Me.gbWalmart.Visible = True

            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try


    End Sub

    Private Sub mostrarControlesAsociados()
        Dim dt As DataTable
        Dim dr, dr_aux, dr2 As DataRow
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Try
            ds.Tables("controles_asociados").Rows.Clear()
            otrans.open()

            For Each dr In ds.Tables("facturas_generadas").Rows
                ls_sql = "pa_sel_um_gen_log_guia_liquidador '" & gs_empresa & "','" &
                        dr.Item("TipoDocto") & "','" &
                            dr.Item("Numero") & "'"
                dt = otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    For Each dr_aux In dt.Rows

                        dr2 = ds.Tables("controles_asociados").NewRow()
                        dr2.Item("tipo") = dr_aux.Item("TipoDocto_Origen")
                        dr2.Item("numero") = dr_aux.Item("numero_origen")
                        dr2.Item("fecha_guia") = dr_aux.Item("fecha_control")
                        dr2.Item("piloto") = dr_aux.Item("usuario")
                        dr2.Item("vehiculo") = dr_aux.Item("tipoDocto")
                        dr2.Item("ayudante") = dr_aux.Item("numero")
                        dr2.Item("comentario") = dr_aux.Item("Observaciones")

                        ds.Tables("controles_asociados").Rows.Add(dr2)
                    Next
                End If
            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds.Tables("controles_asociados").Rows.Count > 0 Then
            Dim oform As New frm_resultado
            Dim clsgen As New ClasesGenerales.General
            Dim cl As DataGridViewColumn

            oform.dgv_resultado.DataSource = ds.Tables("controles_asociados")
            '            clsgen.Alinea_Grid(ds.Tables("controles_asociados"), oform.DataGrid1, ds.Tables("controles_asociados").TableName, _
            '                                        -1, 200, 0, False, True, ",tipo, numero, fecha_guia, vehiculo, ayudante, comentario", True, "")

            clsgen.Alinear_GridView(ds.Tables("controles_asociados"), oform.dgv_resultado, ",tipo,numero,fecha_guia,vehiculo,ayudante,comentario", "", "", "", "", "", "", True, True, 200, 0)

            cl = oform.dgv_resultado.Columns(0)
            cl.HeaderText = "Control"
            cl = oform.dgv_resultado.Columns(1)
            cl.HeaderText = "Numero"
            cl = oform.dgv_resultado.Columns(2)
            cl.HeaderText = "Fecha Control"
            cl = oform.dgv_resultado.Columns(3)
            cl.HeaderText = "TipoDocto"
            cl = oform.dgv_resultado.Columns(4)
            cl.HeaderText = "NumeroDocto"
            cl = oform.dgv_resultado.Columns(5)
            cl.HeaderText = "Motivo"
            oform.Text = "Controles Asociados"

            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
        Else
            MessageBox.Show("No Hay Movimientos en Control Historico", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub limpiarForma()
        Me.txt_comentario.Text = ""
        Me.txt_vendedor.Text = ""
        Me.txt_fecha.Text = ""
        Me.txt_fecha_grabo.Text = ""
        Me.txt_lista_precios.Text = ""
        Me.txt_tipo_pedido.Text = ""
        Me.txt_aprobacion.Text = ""
        Me.txt_porcentaje.Text = ""
        Me.txt_numero.Text = ""
        Me.txt_total_pedido.Text = 0
        Me.txt_aprobacion_pedido.Text = ""


        Me.lblSerieFEL.Visible = False
        Me.lblNumeroFEL.Visible = False
        Me.txtNumeroFel.Visible = False
        Me.txtSerieFEL.Visible = False


        Me.dgv_facturas.DataSource = Nothing

        Me.dg_control_transporte.DataSource = Nothing
        Me.dg_picking.DataSource = Nothing

        Me.dg_devoluciones.DataSource = Nothing
        ds = New DataSet
    End Sub

    Private Sub frmTrackingPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_empresa()
        Me.nupAnio.Value = Today.Year - 2000
        limpiarForma()
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged

    End Sub

    Private Sub cmbEmpresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedValueChanged
        cargarTipoDocto()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        RealizarTracking()
    End Sub

    Private Sub lbl_controles_asociados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_controles_asociados.Click
        mostrarControlesAsociados()
    End Sub

    Private Sub txtNumeroFactura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroFactura.Leave, txtSerieFEL.Leave, txtNumeroFel.Leave
        limpiarForma()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiarForma()
    End Sub

    Private Sub cmbTipoDocto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDocto.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoDocto.SelectedValueChanged

    End Sub

    Private Sub cmbTipoDocto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipoDocto.SelectionChangeCommitted
        If Me.cmbTipoDocto.Text = "FEL" Then
            Me.lblNumeroFEL.Visible = True
            Me.lblSerieFEL.Visible = True
            Me.txtSerieFEL.Visible = True
            Me.txtNumeroFel.Visible = True
            Me.nupAnio.Visible = False
            Me.lblAnio.Visible = False
        Else
            Me.lblNumeroFEL.Visible = False
            Me.lblSerieFEL.Visible = False
            Me.txtSerieFEL.Visible = False
            Me.txtNumeroFel.Visible = False
            Me.nupAnio.Visible = True
            Me.lblAnio.Visible = True
        End If
    End Sub

    Private Sub txtNumeroFactura_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroFactura.TextChanged

    End Sub
End Class