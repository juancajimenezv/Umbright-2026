Public Class frm_maq_orden_etiquetas
    Dim ls_codigo As String
    Dim valida As Boolean = False
  

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Private Sub frm_maq_orden_etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combos()

    End Sub

    Private Sub llenar_combos()
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim index As Integer = 0
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim newRow As DataRow

        Try
            ' myOtrans.open()
            otrans.open()

            ls_sql = "bdflexline.flexline.pa_sel_um_sg_usuario_simple '" & gs_usuario & "'"
            dt = otrans.Obtiene(ls_sql)
            solicitado_por.Text = dt.Rows(0)("nombre")

            ls_sql = "pa_sel_um_maq_control_numero'" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows(0)("numero").ToString <> "" Then
                Me.txt_op_numero_orden.Text = dt.Rows(0)("numero")
            Else
                Me.txt_op_numero_orden.Text = 1
            End If

            Me.txt_op_cantidad_solicitada.Text = 1

            ls_sql = "pa_sel_um_maq_costo_materiales 2"
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            newRow = dt.NewRow()
            newRow("descripcion") = "No. Operadores Asignados"
            dt.Rows.Add(newRow)
            dt.TableName = "costo_primo"
            dt.Columns.Add("cantidad")
            ds.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 1"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "chequeo1"
            ds.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 2"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "chequeo2"
            dt.Columns.Add("cantidad")
            ds.Tables.Add(dt.Copy)

            clbx_chequeo.DataSource = ds.Tables("chequeo1")
            dgv_chequeo.DataSource = ds.Tables("chequeo2")

            clbx_chequeo.DisplayMember = "descripcion"
            clbx_chequeo.ValueMember = "cod_chequeo"

            dgv_chequeo.DataSource = ds.Tables("chequeo2")
            dgv_costo_primo.DataSource = ds.Tables("costo_primo")

            ClsGen.Alinear_GridView(ds.Tables("costo_primo"), dgv_costo_primo, ",descripcion,cantidad,", ",costo,", ",descripcion,", "", "", "", "", False, True, 250, 0)
            ClsGen.Alinear_GridView(ds.Tables("chequeo2"), dgv_chequeo, ",descripcion,cantidad,", ",cod_chequeo,tipo,", ",descripcion,", "", "", "", "", False, True, 250, 0)

            index = 0
            For Each row As DataGridViewRow In dgv_costo_primo.Rows
                dgv_costo_primo.Item("cantidad", index).Value = 0
                index += 1
            Next

            index = 0
            For Each row As DataGridViewRow In dgv_chequeo.Rows
                dgv_chequeo.Item("cantidad", index).Value = 0
                index += 1
            Next


        Catch ex As Exception
            'myOtrans.close()
            'myOtrans = Nothing

            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click


        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "glosa,producto"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa "
        frm_busqueda.cmb_2.Visible = False
        frm_busqueda.cmb_log1.Visible = False
        frm_busqueda.txt_buscar2.Visible = False
        frm_busqueda.cmb_valor2.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.txt_buscar1.Text = Me.txt_producto.Text
        frm_busqueda.txt_buscar1.Focus()
        'frm_busqueda.pConexion = "FlexLine"
        frm_busqueda.ShowDialog(Me)
        ls_codigo = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Me.txt_producto.Text = ls_codigo

        buscarProducto()
    End Sub
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")
                ' Me.txt_proveedor.Text = dt.Rows(0)("subfamilia")
                Me.txt_op_cantidad_solicitada.Focus()

            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub
    Private Sub verificacion()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            otrans.open()

            ls_sql = "pa_var_um_maq_control_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.dtp_op_fecha_etiquetado.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                valida = False
            Else
                valida = True
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub
    Private Sub limpiar()
        Dim index As Integer = 0
        Me.txt_producto.Text = ""
        Me.txt_op_DI.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_op_cantidad_solicitada.Text = ""
        Me.txt_costo_primo.Text = 0


        For i As Integer = 0 To clbx_chequeo.Items.Count - 1
            If clbx_chequeo.GetItemChecked(i) Then
                clbx_chequeo.SetSelected(i, True)
                clbx_chequeo.SetItemChecked(i, False)

            End If
        Next

        index = 0
        For Each row As DataGridViewRow In dgv_chequeo.Rows
            dgv_chequeo.Item("cantidad", index).Value = 0
            index += 1
        Next

        index = 0
        For Each row As DataGridViewRow In dgv_costo_primo.Rows
            dgv_costo_primo.Item("cantidad", index).Value = 0
            index += 1
        Next


        Me.txt_producto.Focus()


    End Sub
    Private Sub procesar_informacion()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim index As Integer

        Try
            otrans.open()

            ls_sql = "pa_ins_um_maq_control_produccion_etiqueta '" & gs_empresa & "','" & Me.txt_op_numero_orden.Text & "','" & Me.txt_producto.Text & "'," & Me.txt_op_cantidad_solicitada.Text & ",'" & Me.txt_op_DI.Text & "','" & Me.dtp_op_fecha_etiquetado.Text & "','" & gs_usuario & "'," & Me.txt_costo_primo.Text & ""
            otrans.Ingresa(ls_sql)

            If otrans.Codigo_error = 0 Then
                For i As Integer = 0 To clbx_chequeo.Items.Count - 1
                    If clbx_chequeo.GetItemChecked(i) Then
                        clbx_chequeo.SetSelected(i, True)
                        ls_sql = "pa_ins_um_maq_control_produccion_etiqueta_detalle " & _
                                            txt_op_numero_orden.Text & ",'" & gs_empresa & "'," & clbx_chequeo.SelectedValue & _
                                            ",1,'" & gs_usuario & "','" & Now() & "'"

                        otrans.Ingresa(ls_sql)
                    End If
                Next

                index = 0
                For Each row As DataGridViewRow In dgv_chequeo.Rows
                    If dgv_chequeo.Item("cantidad", index).Value > 0 Then
                        ls_sql = "pa_ins_um_maq_control_produccion_etiqueta_detalle " & _
                                            txt_op_numero_orden.Text & ",'" & gs_empresa & "'," & dgv_chequeo.Item("cod_chequeo", index).Value & _
                                            "," & dgv_chequeo.Item("cantidad", index).Value & ",'" & gs_usuario & "','" & Now() & "'"


                        otrans.Ingresa(ls_sql)

                    End If
                    index += 1
                Next

                MessageBox.Show("Informacion Grabada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR: " & otrans.descripcion_error)

        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub guardar_cambios()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            otrans.open()
            ls_sql = "pa_var_um_maq_control_producto '" & gs_empresa & "',null,null,'" & txt_op_numero_orden.Text & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                ls_sql = "pa_del_um_maq_control_producto '" & gs_empresa & "','" & txt_op_numero_orden.Text & "'"
                otrans.Elimina(ls_sql)
            End If

            verificacion()

            If valida Then
                procesar_informacion()
                llenar_combos()

            Else
                If MessageBox.Show("El producto '" & txt_producto.Text & "' ya existe en la fecha '" & dtp_op_fecha_etiquetado.Text & "'. Desea asignarlo en la misma fecha? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    procesar_informacion()
                    llenar_combos()
                End If
            End If

            txt_op_numero_orden.ReadOnly = True
            txt_producto.Focus()

        Catch ex As Exception
            MessageBox.Show("ERROR: " & otrans.descripcion_error)

        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub generaReporteCosto()

        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Logistica\Internaciones\control de Etiquedado.rpt"
            pm_parametros(0) = "@Pempresa"
            pm_parametros(1) = "@Pnumero"


            pm_valores(0) = gs_empresa
            pm_valores(1) = Me.txt_op_numero_orden.Text
            'pm_valores(2) = cliente

            'pm_parametros(1) = "Numero de Documento"
            'pm_valores(0) = gs_empresa
            'pm_valores(1) = Me.lbl_numero.Text


            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                False, True, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                           False, False, "PDF", False, "", True)
        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Private Sub btn_guardar_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_orden_produccion.Click
        Try
            If Me.txt_producto.Text.Length = 10 And Me.txt_descripcion.Text.Length > 0 And Val(Me.txt_op_cantidad_solicitada.Text) <> 0 Then
                guardar_cambios()
            Else
                MessageBox.Show("No se puede Grabar la informacion, por favor verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Catch ex As Exception
            MessageBox.Show("No se puede Grabar la informacion, por favor verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub btn_nuevo_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_orden_produccion.Click
        limpiar()
        llenar_combos()
        txt_op_numero_orden.ReadOnly = True

    End Sub

    Private Sub txt_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_producto.LostFocus

        Me.buscarProducto()

    End Sub


    Private Sub txt_op_cantidad_solicitada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_op_cantidad_solicitada.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Function calcular_costo_primo() As Double
        Dim index As Integer = 0
        Dim total As Integer
        Dim costo_primo, _aux As Double

        total = dgv_costo_primo.Rows.Count

        For Each row As DataGridViewRow In dgv_costo_primo.Rows
            _aux = 0

            If total <> (index + 1) Then
                If IsDBNull(dgv_costo_primo.Item("costo", index).Value) Then dgv_costo_primo.Item("costo", index).Value = 0
                If IsDBNull(dgv_costo_primo.Item("cantidad", index).Value) Then dgv_costo_primo.Item("cantidad", index).Value = 0
                If IsDBNull(dgv_costo_primo.Item("cantidad", (total - 1)).Value) Then dgv_costo_primo.Item("cantidad", (total - 1)).Value = 0

                _aux = Convert.ToDouble(dgv_costo_primo.Item("cantidad", index).Value) * Convert.ToDouble(dgv_costo_primo.Item("costo", index).Value)
                _aux = _aux * Convert.ToDouble(dgv_costo_primo.Item("cantidad", (total - 1)).Value)

            End If

            costo_primo = costo_primo + _aux
            index += 1
        Next

        Return (costo_primo)

    End Function


    Private Sub dgv_costo_equipo_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub dgv_costo_primo_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_costo_primo.CellValueChanged
        txt_costo_primo.Text = calcular_costo_primo()
    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim index As Integer
        Dim mRows() As DataRow
        Dim dt As DataTable
        Try
            otrans.open()
            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_detalle '" & txt_producto.Text & "','" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            For i As Integer = 0 To clbx_chequeo.Items.Count - 1
                clbx_chequeo.SetSelected(i, True)
                mRows = dt.Select("cod_chequeo = '" & clbx_chequeo.SelectedValue & "'")

                If mRows.Length > 0 Then
                    clbx_chequeo.SetItemChecked(i, True)
                Else
                    clbx_chequeo.SetItemChecked(i, False)

                End If

            Next

            index = 0
            For Each row As DataGridViewRow In dgv_chequeo.Rows
                mRows = dt.Select("cod_chequeo ='" & dgv_chequeo.Item("cod_chequeo", index).Value & "'")
                If mRows.Length > 0 Then
                    dgv_chequeo.Item("cantidad", index).Value = mRows(0)("cantidad")

                Else
                    dgv_chequeo.Item("cantidad", index).Value = 0

                End If
                index += 1
            Next

            If dt.Rows.Count > 0 Then
                txt_costo_primo.Text = dt.Rows(0).Item("costo_primo")
            Else
                txt_costo_primo.Text = 0
            End If

        Catch
            MessageBox.Show("ERROR: " & otrans.descripcion_error)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm_buscar_orden As New frm_buscar_orden_etiquetas
        frm_buscar_orden.ShowDialog()

        If frm_buscar_orden.num_orden <> "" Then
            txt_op_numero_orden.Text = frm_buscar_orden.num_orden
            obtener_detalle_orden()
        End If

    End Sub

    Private Sub txt_op_numero_orden_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_op_numero_orden.KeyDown
        
    End Sub

    Private Sub obtener_detalle_orden()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim index As Integer
        Dim dt As New DataTable
        Dim dr, _dr() As DataRow

        Try
            otrans.open()
            myOtrans.open()
            ls_sql = "pa_sel_um_maq_orden_etiquetas '" & txt_op_numero_orden.Text & "', '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)
                txt_producto.Text = dr.Item("producto")
                txt_descripcion.Text = dr.Item("glosa")
                txt_op_cantidad_solicitada.Text = dr.Item("cantidad")
                dtp_op_fecha_etiquetado.Text = dr.Item("fecha_produccion")
                txt_op_DI.Text = dr.Item("observaciones")

                For i As Integer = 0 To clbx_chequeo.Items.Count - 1
                    clbx_chequeo.SetSelected(i, True)
                    clbx_chequeo.SetItemChecked(i, False)

                    _dr = dt.Select("cod_chequeo = '" & clbx_chequeo.SelectedValue & "'")

                    If _dr.Length > 0 Then
                        clbx_chequeo.SetItemChecked(i, True)
                    Else
                        clbx_chequeo.SetItemChecked(i, False)
                    End If

                Next

                index = 0
                For Each row As DataGridViewRow In dgv_chequeo.Rows
                    _dr = dt.Select("cod_chequeo ='" & dgv_chequeo.Item("cod_chequeo", index).Value & "'")
                    If _dr.Length > 0 Then
                        dgv_chequeo.Item("cantidad", index).Value = _dr(0)("cantidad_chequeo")

                    Else
                        dgv_chequeo.Item("cantidad", index).Value = 0

                    End If
                    index += 1
                Next

                If dt.Rows.Count > 0 Then
                    txt_costo_primo.Text = dt.Rows(0).Item("costo_primo")
                Else
                    txt_costo_primo.Text = 0
                End If

                ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & dr.Item("usuario_grabo").ToString & "')"
                dt = myOtrans.Obtiene(ls_sql)
                solicitado_por.Text = dt.Rows(0)("nombre")

            End If
        Catch
            MessageBox.Show("ERROR: " & otrans.descripcion_error)
        Finally
            otrans.close()
            myOtrans.close()

            otrans = Nothing
            myOtrans = Nothing

        End Try
    End Sub

    Private Sub calcular_tiempo()
        Dim tiempo As Date
        tiempo = "00:00:00"

        If DateDiff(DateInterval.Second, Date.Parse(dtp_hora_inicio.Text), Date.Parse(dtp_hora_final.Text)) > 0 Then

            tiempo = tiempo.AddSeconds(DateDiff(DateInterval.Second, Date.Parse(dtp_hora_inicio.Text), Date.Parse(dtp_hora_final.Text)))

        End If

        txt_tiempo.Text = tiempo.ToString("HH:mm:ss")

    End Sub

    Private Sub dtp_hora_inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hora_inicio.ValueChanged
        calcular_tiempo()

    End Sub

    Private Sub dtp_hora_final_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hora_final.ValueChanged
        calcular_tiempo()
    End Sub

    Private Sub clbx_chequeo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbx_chequeo.SelectedValueChanged
        txt_stickers.Text = calcular_stickers_colocados()

    End Sub

    Function calcular_stickers_colocados()
        Dim cantidad, count As Integer

        For i As Integer = 0 To (clbx_chequeo.Items.Count - 1)
            If clbx_chequeo.GetItemChecked(i) = True Then
                count += 1

            End If
        Next

        cantidad = txt_op_cantidad_solicitada.Text * count
        Return (cantidad)

    End Function

    Private Sub txt_op_cantidad_solicitada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_op_cantidad_solicitada.TextChanged
        txt_stickers.Text = calcular_stickers_colocados()

    End Sub

    Private Sub tbn__mostrar_ordenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbn__mostrar_ordenes.Click
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            otrans.open()
            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            dgv_listado_ordenes.DataSource = dt
            ClsGen.Alinear_GridView(dt, dgv_listado_ordenes, "", "", "", "", "", "", "", False, True, 250, 0)

        Catch ex As Exception

        Finally
            otrans.close()

        End Try

        

    End Sub


    Private Sub dgv_listado_ordenes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado_ordenes.DoubleClick
        tb_ordenes_etiquetado.SelectedTab = tb_detalle
        txt_op_numero_orden.Text = (dgv_listado_ordenes.Item("numero", dgv_listado_ordenes.CurrentRow.Index).Value.ToString)
        obtener_detalle_orden()
    End Sub

    Private Sub dgv_listado_ordenes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado_ordenes.CellContentClick

    End Sub

    Private Sub dgv_costo_primo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_costo_primo.CellContentClick

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        GeneraReporteCosto()
    End Sub
End Class

