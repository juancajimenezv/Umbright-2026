Public Class frm_lotes_picking_consolidado
    Private ds_fel As New DataSet
    Private ds_refel As New DataSet
    Private ds_picking As New DataSet
    Private ds_repicking As New DataSet
    Private ds_picking2 As New DataSet
    Private ds_picking3 As New DataSet
    Private ds_pickingc As New DataSet
    Dim prt As prtcom.Imprimir_Puerto
    Dim clsgen As New ClasesGenerales.General


    Private Sub frm_lotes_picking_consolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dim fecha As Date
        ' Me.WindowState = FormWindowState.Maximized

        If gs_usuario = "orodriguez" Or gs_usuario = "eabad" Or gs_usuario = "cdelcid" Or gs_usuario = "asaravia" Or gs_usuario = "earreaga" Or gs_usuario = "walvarado" Then
            btn_controlTransporte.Visible = True
            btnEntregaFacturas.Visible = True
        Else
            btn_controlTransporte.Visible = False
            btnEntregaFacturas.Visible = False
        End If


        lbl_usuario.Text = lbl_usuario.Text & gs_usuario
        Crear_estructura_fel_dtt()
        Crear_estructura_refel_dtt()

        '  Crear_Estructura()
        ' Crear_Estructura2()
        ' Crear_Estructura3()
        '  picking_pendiente()
        'fecha = Now
        'dtp_fecha.Text = Format(CDate(fecha), "yyyy/MM/dd") 'Now.ToString

        refrescarPickingConsolidado()

        Me.TabPage1.Parent = Nothing
        'Me.TabPage3.Parent = Me.TabControl1
        'Me.TabControl1.SelectedTab = TabPage3

        'txt_lectura.Focus()
    End Sub

    Private Sub btn_generaDoctos_Click(sender As Object, e As EventArgs) Handles btn_generaDoctos.Click
        picking_pendiente()
        listar_documentos_para_lote()
        txt_lectura.Focus()

    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    picking_pendiente()
    '    'MsgBox("tiempo")
    'End Sub

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("pendientes_impresion")

        dt.Columns.Add(New DataColumn("Asignar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("FechaCreacion", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Departamento", GetType(String)))
        dt.Columns.Add(New DataColumn("Municipio", GetType(String)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("Tipo_Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(DateTime)))
        'dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        'dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("Ejecutivo", GetType(String)))
        'dt.Columns.Add(New DataColumn("Lista_Precio", GetType(String)))
        'dt.Columns.Add(New DataColumn("Departamento", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        'dt.Columns.Add(New DataColumn("Direccion", GetType(String)))

        ds_picking.Tables.Add(dt.Copy)

        dt.TableName = "re_impresion"
        ds_picking.Tables.Add(dt.Copy)
        dgv_normal.DataSource = dt
    End Sub

    Private Sub Crear_estructura_fel_dtt()
        Dim dt As New DataTable("pendientes_fel")

        dt.Columns.Add(New DataColumn("Asigna", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Documentos", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))

        ds_picking.Tables.Add(dt.Copy)

        dt.TableName = "fel"
        ds_fel.Tables.Add(dt.Copy)
        dgv_Lotes.DataSource = dt

    End Sub

    Private Sub Crear_estructura_refel_dtt()
        Dim dt As New DataTable("pendientes_refel")

        dt.Columns.Add(New DataColumn("Asigna", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Documentos", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))

        ds_repicking.Tables.Add(dt.Copy)

        dt.TableName = "fel"
        ds_refel.Tables.Add(dt.Copy)
        dgv_reDetalle.DataSource = dt

    End Sub

    Private Sub Crear_Estructura2()
        Dim dt As New DataTable("pendientes_impresion2")

        '  dt.Columns.Add(New DataColumn("Asignar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("FechaCreacion", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))

        ds_picking2.Tables.Add(dt.Copy)

        dt.TableName = "re_impresion2"
        ds_picking2.Tables.Add(dt.Copy)
        dgv_Resto.DataSource = dt
    End Sub

    Private Sub Crear_Estructura3()
        Dim dt As New DataTable("pendientes_impresion3")

        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))

        ds_picking3.Tables.Add(dt.Copy)
        dt.TableName = "re_impresion3"
        ds_picking3.Tables.Add(dt.Copy)
        dgv_creados.DataSource = dt
    End Sub

    Private Sub Crear_Estructura_c()
        Dim dt As New DataTable("pendientes_impresionc")

        dt.Columns.Add(New DataColumn("Asignar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("FechaCreacion", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        'dt.Columns.Add(New DataColumn("Tipo_Cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        'dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("Ejecutivo", GetType(String)))
        'dt.Columns.Add(New DataColumn("Lista_Precio", GetType(String)))
        'dt.Columns.Add(New DataColumn("Departamento", GetType(String)))

        'dt.Columns.Add(New DataColumn("Direccion", GetType(String)))

        ds_pickingc.Tables.Add(dt.Copy)

        dt.TableName = "re_impresionc"
        ds_pickingc.Tables.Add(dt.Copy)
        dgv_creados.DataSource = dt
    End Sub

    Private Sub picking_pendiente()
        Dim picker As String
        dgv_normal.DataSource = Nothing
        picker = "CONSOLIDADO"
        cmbPickerConsolidado.Text = picker
        agregarFacturasAsignadas("pa_sel_um_documentos_picking_pendiente_todos")
        agregarFacturasAsignadas2("pa_sel_um_documentos_picking_pendiente_todos2")
        txt_lectura.Focus()
    End Sub

    Private Sub agregarFacturasAsignadas(ByVal ls_sql As String)
        Dim dr, draux As DataRow
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        ' estructuraFacturasAsignadas()
        dtAsignar = ds_picking.Tables("re_impresion")
        ds_picking.Tables("re_impresion").Rows.Clear()

        Try
            otrans.open()
            dtaux = otrans.Obtiene(ls_sql)
            'dgv_normal.DataSource = dtaux
            For Each dr In dtaux.Rows
                'draux = dtAsignar.NewRow
                draux = ds_picking.Tables("re_impresion").NewRow
                draux.Item("Asignar") = False
                draux.Item("FechaCreacion") = dr.Item("FechaCreacion")
                draux.Item("Departamento") = dr.Item("Departamento")
                draux.Item("Municipio") = dr.Item("Municipio")
                draux.Item("Empresa") = dr.Item("Empresa")

                draux.Item("Nombre_Cliente") = dr.Item("Nombre_Cliente")
                draux.Item("TipoDocto") = dr.Item("TipoDocto")
                draux.Item("Numero") = dr.Item("Numero")
                draux.Item("Fecha") = dr.Item("Fecha")
                '    draux.Item("Bodega") = dr.Item("Bodega")
                '   draux.Item("Lineas") = dr.Item("Lineas")
                '  draux.Item("Ejecutivo") = dr.Item("Ejecutivo")
                ' draux.Item("Lista_Precio") = dr.Item("ListaPrecio")
                'draux.Item("Departamento") = dr.Item("Departamento")
                draux.Item("Comentario") = dr.Item("Comentario")
                'draux.Item("Direccion") = dr.Item("Direccion")
                ds_picking.Tables("re_impresion").Rows.Add(draux)
            Next

            dgv_normal.DataSource = ds_picking.Tables("re_impresion")
            Dim clsgen As New ClasesGenerales.General
            clsgen.Alinear_GridView(ds_picking.Tables("re_impresion"), dgv_normal, "", "", ",Empresa,Tipo_Cliente,Nombre_Cliente,TipoDocto,Numero,Lineas,Bodega,Ejecutivo,Fecha,Bodega,Ejecutivo,Lista_Precio,Departamento,Comentario,Direccion,", "", False, True, 300, 40)
            dgv_normal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
            dgv_normal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            otrans.close()
        End Try
    End Sub

    Private Sub agregarFacturasAsignadas2(ByVal ls_sql As String)
        Dim dr, draux As DataRow
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        ' estructuraFacturasAsignadas()
        dtAsignar = ds_picking2.Tables("re_impresion2")
        ds_picking2.Tables("re_impresion2").Rows.Clear()

        Try
            otrans.open()
            dtaux = otrans.Obtiene(ls_sql)
            'dgv_normal.DataSource = dtaux
            For Each dr In dtaux.Rows
                'draux = dtAsignar.NewRow
                draux = ds_picking2.Tables("re_impresion2").NewRow
                '   draux.Item("Asignar") = False
                draux.Item("FechaCreacion") = dr.Item("FechaCreacion")
                draux.Item("Empresa") = dr.Item("Empresa")
                '     draux.Item("Tipo_Cliente") = dr.Item("Tipo_Cliente")
                draux.Item("Nombre_Cliente") = dr.Item("Nombre_Cliente")
                draux.Item("TipoDocto") = dr.Item("TipoDocto")
                draux.Item("Numero") = dr.Item("Numero")
                draux.Item("Fecha") = dr.Item("Fecha")
                '    draux.Item("Bodega") = dr.Item("Bodega")
                '   draux.Item("Lineas") = dr.Item("Lineas")
                '  draux.Item("Ejecutivo") = dr.Item("Ejecutivo")
                ' draux.Item("Lista_Precio") = dr.Item("ListaPrecio")
                'draux.Item("Departamento") = dr.Item("Departamento")
                draux.Item("Comentario") = dr.Item("Comentario")
                'draux.Item("Direccion") = dr.Item("Direccion")
                ds_picking2.Tables("re_impresion2").Rows.Add(draux)
            Next

            dgv_Resto.DataSource = ds_picking2.Tables("re_impresion2")
            Dim clsgen As New ClasesGenerales.General
            clsgen.Alinear_GridView(ds_picking2.Tables("re_impresion2"), dgv_Resto, "", "", ",Empresa,Tipo_Cliente,Nombre_Cliente,TipoDocto,Numero,Lineas,Bodega,Ejecutivo,Fecha,Bodega,Ejecutivo,Lista_Precio,Departamento,Comentario,Direccion,", "", False, True, 300, 40)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try
    End Sub
    Private Sub btn_creaLote_Click(sender As Object, e As EventArgs) Handles btn_creaLote.Click
        Crear_Lote()
    End Sub

    Private Sub Crear_Lote()
        Dim lcorrelativo As Integer = 0

        If MessageBox.Show("Esta Seguro de Generar Lote", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim dt, dtCorrelativo As DataTable
            Dim clsGen As New ClasesGenerales.General
            Dim lsSQL As String

            Try
                dt = TryCast(Me.dgv_creados.DataSource, DataTable)

                ' ds_pickingc.Tables("re_impresionc").DefaultView.RowFilter = "Asignar = True"

                If dt.DefaultView.Count > 0 Then
                    lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_correlativo"
                    dtCorrelativo = clsGen.selectQuery("FlexLine", lsSQL)
                    lcorrelativo = dtCorrelativo.Rows(0).Item("correlativo").ToString()
                End If

                For Each drv As DataRowView In dt.DefaultView

                    '   If dr.Item("Agregar").ToString.ToLower.Equals("true") Then

                    lsSQL = "pa_ins_um_gen_log_documento_picking_consolidado '" & drv.Item("Empresa").ToString & "','" &
                            drv.Item("TipoDocto").ToString & "','" &
                            drv.Item("Numero").ToString & "','" &
                            gs_usuario & "','CONSOLIDADO'," & lcorrelativo
                    'dtCorrelativo.Rows(0).Item("correlativo").ToString()
                    '  Me.cmbPickerConsolidado.SelectedValue & "'," &

                    clsGen.insertQuery("FlexLine", lsSQL)

                    '  End If
                Next

                '' Imprimir Pickign Consolidad

                Dim path_reporte As String
                Dim pm_valores(0) As String
                Dim pm_parametros(0) As String
                Dim pm_conexion(3) As String

                Dim lbreturn As Boolean = False
                Try
                    'Obtengo Datos de Conexion
                    pm_conexion = clsGen.Parametros_Conexion("vDataServer")
                    path_reporte = clsGen.Path_Reporte


                    path_reporte += "Logistica\Picking\Picking On Trade Consolidado.rpt"

                    pm_parametros(0) = "@Identificador"
                    pm_valores(0) = dtCorrelativo.Rows(0).Item("correlativo").ToString

                    lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                   pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                   False, True, "PDF", True, "", True, 1)



                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    dgv_creados.DataSource = Nothing
                    '     Crear_Estructura3()
                    clsGen = Nothing
                End Try

                MessageBox.Show("Numero de Lote Generado " & dtCorrelativo.Rows(0).Item("correlativo").ToString, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                ' listarConsolidables()
                'listarConsolidables()
                Me.lb_tValores.Text = "0.00"
                Me.lb_tUnidades.Text = "0"
                Me.lb_tDocumentos.Text = "0"

                listar_documentos_para_lote()
                picking_pendiente()
                txt_lectura.Focus()

            End Try

        End If
    End Sub

    Private Sub listarConsolidables()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()
            lsSQL = "pa_sel_um_documentos_picking_pendiente_todos"
            dt = ClsGen.selectQuery("FlexLine", lsSQL)

            Me.dgv_normal.DataSource = ds_picking.Tables("re_impresion")

            ClsGen.Alinear_GridView(ds_picking.Tables("re_impresion"), dgv_normal, "", "", ",Empresa,Tipo_Cliente,Nombre_Cliente,TipoDocto,Numero,Lineas,Bodega,Ejecutivo,Fecha,Bodega,Ejecutivo,Lista_Precio,Departamento,Comentario,Direccion,", "", False, True, 300, 40)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub refrescarPickingConsolidado()
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim lsSQL0, lsSQL, lsql As String

        Try
            otrans.open()

            lsql = "pa_sel_um_pedido_fel_consolidado_dtt '" & dtp_fecha.Value.ToShortDateString & "','" & gs_usuario & "'"
            dt2 = otrans.Obtiene(lsql)

            Me.dgv_Lotes.DataSource = dt2

            If dt2.Rows.Count > 0 Then

            End If

            '    lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes '" & dtp_fecha.Text & "'"
            '    dt = ClsGen.selectQuery("FlexLine", lsSQL)
            '    Me.dgv_Lotes.DataSource = dt

            '    ClsGen.Alinear_GridView(dt, Me.dgv_Lotes, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)
            'Else
            '    If gs_usuario = "orodriguez" Or gs_usuario = "eabad" Or gs_usuario = "cdelcid" Then
            '        Exit Sub

            '    Else

            '        lsSQL0 = "pa_ins_um_pedido_consolidado_dtt '" & dtp_fecha.Text & "','" & gs_usuario & "'"
            '        otrans.Obtiene(lsSQL0)

            '        lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes '" & dtp_fecha.Text & "'"
            '        dt = ClsGen.selectQuery("FlexLine", lsSQL)
            '        Me.dgv_Lotes.DataSource = dt
            '        ClsGen.Alinear_GridView(dt, Me.dgv_Lotes, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)

            '    End If

            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btn_refrescar_picking_consolidado_Click(sender As Object, e As EventArgs) Handles btn_refrescar_picking_consolidado.Click
        refrescarPickingConsolidado()
    End Sub

    Private Sub Consolicar_para_impresion()
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim lsql, lsql2 As String

        Try
            otrans.open()

            lsql = "pa_sel_um_pedido_fel_consolidado_dtt '" & dtp_fecha.Value.ToShortDateString & "','" & gs_usuario & "'"
            otrans.Obtiene(lsql)

            lsql2 = "select * from scm.flexline.Picking_Consolidado_DTT where fecha='" & dtp_fecha.Value.ToShortDateString & "' and Numero<>'' "
            dt = otrans.Obtiene(lsql2)

            Me.dgv_Lotes.DataSource = dt

            If dt.Rows.Count > 0 Then
                Impresion_picking_consolidado()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btnReimpresionConsolidado_Click(sender As Object, e As EventArgs) Handles btnReimpresionConsolidado.Click
        Consolicar_para_impresion()
    End Sub

    Private Sub Impresion_picking_consolidado()

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim sql As String

        Try

            otrans.open()

            dt = TryCast(Me.dgv_Lotes.DataSource, DataTable)
            '  ds_picking.Tables("re_impresion").DefaultView.RowFilter = "Asignar = True"

            '    dt.DefaultView.RowFilter = "Asigna = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False
            'dt.DefaultView.Count
            '    If ds_picking.Tables("re_impresion").DefaultView.Count > 0 Then
            If dt.DefaultView.Count > 0 Then

                '      For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView
                For Each drv As DataRowView In dt.DefaultView

                    If CInt(drv.Item("Numero")).ToString <> Nothing Then

                        '  MsgBox(CInt(drv.Item("Numero")))
                        '  If drv.Item("Numero") = 1 Then
                        Try
                            'Obtengo Datos de Conexion
                            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                            path_reporte = ClsGen.Path_Reporte

                            path_reporte += "Logistica\Picking\Picking Consolidado DTT.rpt"

                            pm_parametros(0) = "@Identificador"
                            pm_valores(0) = CInt(drv.Item("Numero")).ToString

                            lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                           False, True, "PDF", True, "", True, 1)


                            'Asigna fecha de impresion y asignacion al picking consolidado para que no salga nuevamente en la pantalla

                            If gs_usuario = "cdcentral" Or gs_usuario = "earreaga" Or gs_usuario = "walvarado" Then
                                '---------------------------------------------------------------------------------------------------------
                                sql = "pa_upd_um_picking_consolidado_asigna '" & CInt(drv.Item("Numero")).ToString & "'"
                                otrans.Obtiene(sql)

                                '---------------------------------------------------------------------------------------------------------
                            End If


                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        Finally
                            '  ClsGen = Nothing
                        End Try
                        '    End If

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
            refrescarPickingConsolidado()
        End Try

    End Sub

    Private Sub txt_Lectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lectura.KeyPress
        If e.KeyChar = Chr(13) Then
            '  MsgBox(Mid(txt_lectura.Text, 2, 10))
            Agrega_documento()
            txt_lectura.Focus()
        End If
    End Sub

    Private Sub Agrega_documento()
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            dt = TryCast(Me.dgv_normal.DataSource, DataTable)
            ds_picking.Tables("re_impresion").DefaultView.RowFilter = "Asignar = False"
            'dt.DefaultView.RowFilter = "Asignar = False"

            For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView
                ' For Each drv As DataRowView In dt.DefaultView

                If drv.Item("Numero").ToString = Mid(txt_lectura.Text, 2, 10) Then 'txt_lectura.Text Then 
                    drv.Item("Asignar") = True

                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            txt_lectura.Text = ""
            ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
            'dt.DefaultView.RowFilter = ""
        End Try

    End Sub

    Private Sub btn_pasar_Click(sender As Object, e As EventArgs) Handles btn_pasar.Click
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            otrans.open()

            dt = TryCast(Me.dgv_normal.DataSource, DataTable)
            ds_picking.Tables("re_impresion").DefaultView.RowFilter = "Asignar = True"


            For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView

                '   If dr.Item("Agregar").ToString.ToLower.Equals("true") Then

                lsSQL = "pa_upd_um_gen_log_documento_tracking_lote '" & drv.Item("Empresa").ToString & "','" &
                            drv.Item("TipoDocto").ToString & "','" &
                            drv.Item("Numero").ToString & "'"
                otrans.Obtiene(lsSQL)

            Next

            MessageBox.Show("Documentos Trasladados Para Crear Lote", " Validación.. ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'listarConsolidables()
            listar_documentos_para_lote()
            picking_pendiente()
            Totalizar()
            txt_lectura.Focus()
        End Try
    End Sub


    Private Sub listar_documentos_para_lote()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_documentos_picking_pendiente_todos_cl "
            dt = ClsGen.selectQuery("FlexLine", lsSQL)

            Me.dgv_creados.DataSource = dt
            If dt.Rows.Count > 0 Then
                ClsGen.Alinear_GridView(dt, Me.dgv_Lotes, "", "", "Empresa,Cliente,Nombre_Cliente,TipoDocto,Numero,Fecha,Unidades,Monto,Bodega,Lineas,nombre_picking,Ejecutivo,ListaPrecio,Departamento,Comentario,Direccion,", "", True, True, 250, 0)
                Totalizar()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            ClsGen = Nothing
        End Try
    End Sub


    Private Sub dgv_creados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_creados.CellDoubleClick
        Dim nrow As Integer = Me.dgv_creados.CurrentRow.Index
        Dim tipodoc, numero As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            tipodoc = Me.dgv_creados.Item("TipoDocto", nrow).Value
            numero = Me.dgv_creados.Item("Numero", nrow).Value

            If MessageBox.Show("Seguro de Quitar el Documento " & tipodoc & " - " & numero & "Del Area de Creación de Lotes? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                otrans.open()

                lsSQL = "pa_upd_um_gen_log_documento_tracking_lote_regresa'" & Me.dgv_creados.Item("Empresa", nrow).Value & "','" &
                        Me.dgv_creados.Item("TipoDocto", nrow).Value & "','" &
                        Me.dgv_creados.Item("Numero", nrow).Value & "'"
                otrans.Obtiene(lsSQL)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            clsgen = Nothing
            otrans.close()
            listar_documentos_para_lote()
            picking_pendiente()
            Totalizar()
            txt_lectura.Focus()
        End Try

    End Sub

    Private Sub Totalizar()
        Dim ntotal As Double
        Dim nunidades As Integer
        Dim ndoctos As Integer
        Dim dt As DataTable

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_creados.DataSource

            If dt.Rows.Count > 0 Then

                ntotal = dt.Compute("sum(Monto)", "Monto>0")
                nunidades = dt.Compute("sum(Unidades)", "Unidades>0")
                ndoctos = dt.Compute("sum(cDoctos)", "Unidades>0")

                Me.lb_tValores.Text = Format(ntotal, "#,###,##0.00")
                Me.lb_tUnidades.Text = Format(nunidades, "#,###,##0")
                Me.lb_tDocumentos.Text = Format(ndoctos, "#,###,##0")
            Else
                Me.lb_tValores.Text = "0.00"
                Me.lb_tUnidades.Text = "0"
                Me.lb_tDocumentos.Text = "0"

                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btn_controlTransporte_Click(sender As Object, e As EventArgs) Handles btn_controlTransporte.Click

        crea_control_transporte_imprime()

    End Sub

    Private Sub crea_control_transporte_imprime()
        ' CREA EL CONTROL DE TRANSPORTE Y REALIZA LA IMPRESION POR VENDEDOR
        Dim ls_sql As String
        Dim dt, dt2 As DataTable

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim llimpiar_pantalla As Boolean = False
        Dim n As Integer = 0

        otrans.open()

        Try
            ls_sql = "pa_sel_um_numero_control_transporte_corporativo 'CONTROL DE TRANSPORTE'"
            dt = otrans.Obtiene(ls_sql)

            If otrans.Codigo_error = 0 Then

                If dt.Rows.Count > 0 Then
                    Me.lbl_numero.Text = CInt(dt.Rows(0).Item("numero")) + 1
                 '   Me.lbl_numero.Text = Me.lbl_numero.Text.PadLeft(10, "0")

                    dt2 = dgv_Lotes.DataSource

                    For Each dr As DataRow In dt2.Rows

                        'Dim oform As New frm_lotes_picking_asignacion
                        'oform.ShowDialog()
                        'n = n + 1

                        'Me.lbl_numero.Text = CInt(dt.Rows(0).Item("numero")) + n
                        'Me.lbl_numero.Text = Me.lbl_numero.Text.PadLeft(10, "0")

                        If dr.Item("Asigna") = 1 And dr.Item("Numero").ToString.Length = 0 Then
                            ' MsgBox("primero crear picking")

                            ls_sql = "flexline.pa_um_ins_control_transporte_dtt '" & gs_usuario & "','" & lbl_numero.Text & "','" & dtp_fecha.Text & "','" & dr.Item("Vendedor") & "'"
                            otrans.Obtiene(ls_sql)

                            MsgBox("Numero de Control asignado: " & lbl_numero.Text & " Para Lote de Facturas: " & dr.Item("Vendedor"))

                        End If
                    Next
                    MessageBox.Show("Se han creado Control de Transportes, Favor de Validar para Actualizar y crear Picking.......", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    refrescarPickingConsolidado()
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try



    End Sub

    Private Sub imprime_por_vendedor()

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            dt = TryCast(Me.dgv_Lotes.DataSource, DataTable)
            '  ds_picking.Tables("re_impresion").DefaultView.RowFilter = "Asignar = True"

            dt.DefaultView.RowFilter = "agregar = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False
            'dt.DefaultView.Count
            '    If ds_picking.Tables("re_impresion").DefaultView.Count > 0 Then
            If dt.DefaultView.Count > 0 Then

                '      For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView
                For Each drv As DataRowView In dt.DefaultView
                    Try
                        'Obtengo Datos de Conexion
                        pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                        path_reporte = ClsGen.Path_Reporte

                        path_reporte += "Logistica\Picking\Picking Consolidado DTT Por Vendedor.rpt"

                        pm_parametros(0) = "@Identificador"
                        pm_valores(0) = drv.Item("lote").ToString

                        lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        ClsGen = Nothing
                    End Try

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub btnEntregaFacturas_Click(sender As Object, e As EventArgs) Handles btnEntregaFacturas.Click
        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            dt = TryCast(Me.dgv_Lotes.DataSource, DataTable)

            dt.DefaultView.RowFilter = "agregar = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False
            If dt.DefaultView.Count > 0 Then

                For Each drv As DataRowView In dt.DefaultView
                    Try
                        pm_conexion = ClsGen.Parametros_Conexion("VDataServer")
                        path_reporte = ClsGen.Path_Reporte

                        path_reporte += "Finanzas\Facturacion\Traslada_Documentos_DTT.rpt"

                        pm_parametros(0) = "@Fecha"
                        pm_valores(0) = dtp_fecha.Text

                        lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        ClsGen = Nothing
                    End Try

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_reGenerar.Click
        refrescar()
    End Sub

    Private Sub refrescar()
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim lsSQL0, lsSQL, lsql As String

        Try
            otrans.open()

            lsql = "pa_sel_um_pedido_fel_consolidado_dtt_re '" & dtp_reFecha.Value.ToShortDateString & "','" & gs_usuario & "'"
            dt2 = otrans.Obtiene(lsql)

            Me.dgv_reDetalle.DataSource = dt2

            If dt2.Rows.Count > 0 Then

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btn_reImpresion_Click(sender As Object, e As EventArgs) Handles btn_reImpresion.Click
        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim sql As String

        Try

            '  otrans.open()

            dt = TryCast(Me.dgv_reDetalle.DataSource, DataTable)
            '  ds_picking.Tables("re_impresion").DefaultView.RowFilter = "Asignar = True"

            dt.DefaultView.RowFilter = "Asigna = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False
            'dt.DefaultView.Count
            '    If ds_picking.Tables("re_impresion").DefaultView.Count > 0 Then
            If dt.DefaultView.Count > 0 Then

                '      For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView
                For Each drv As DataRowView In dt.DefaultView

                    '  If CInt(drv.Item("Numero")).ToString <> Nothing Then

                    '  MsgBox(CInt(drv.Item("Numero")))
                    '  If drv.Item("Numero") = 1 Then
                    Try
                            'Obtengo Datos de Conexion
                            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                            path_reporte = ClsGen.Path_Reporte

                            path_reporte += "Logistica\Picking\Picking Consolidado DTT.rpt"

                            pm_parametros(0) = "@Identificador"
                            pm_valores(0) = CInt(drv.Item("Numero")).ToString

                            lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                           False, True, "PDF", True, "", True, 1)


                    Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        Finally
                            '  ClsGen = Nothing
                        End Try
                    '    End If

                    '        End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
            '        otrans.close()
            '    otrans = Nothing
            refrescar()
        End Try


    End Sub
End Class