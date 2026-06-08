Imports System.Text

Public Class frm_solicitud_reserva
    Dim sql_st As String = String.Empty
    Dim ds_info As New DataSet
    Dim dt As New DataTable
    Dim p_aprueba_rechaza As String = "adu_autoriza_rechaza_solicitud_reserva"
    Dim p_procesa As String = "adu_procesa_solicitud_reserva"
    Dim idRow As Integer
    Dim nuevo_p As Boolean = True
    Dim nuevo As Boolean = True

    Private Sub btn_ayuda_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_producto.Click
        'MessageBox.Show("Únicamente podrá elegir productos que posean saldo en el DA", "Productos DA", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim cod_producto As String = String.Empty
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.conectar = "scm"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "Producto,Descripcion,Proveedor"
        frm_busqueda.nombre_vista = "vi_producto_unidad_bulto"
        frm_busqueda.lista_campos = "Producto, Descripcion, Proveedor"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        cod_producto = frm_busqueda.resultado

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        buscar_producto(cod_producto)
    End Sub

    Private Sub buscar_producto(ByVal codigo_prod As String)
        Dim Otrans As New Transaccional.Conexion("flexline")
        Try
            Otrans.open()

            sql_st = "pa_sel_um_producto_unidad_bulto '" & gs_empresa & "','" & codigo_prod & "'"
            dt = Otrans.Obtiene(sql_st)


            If dt.Rows.Count > 0 And dt.Rows.Count <= 1 Then
                txt_cod_producto.Text = codigo_prod
                txt_descripcion.Text = dt.Rows(0)("descripcion")
                lbl_proveedor.Text = "Proveedor:  " & dt.Rows(0)("proveedor")

                If dt.Rows(0)("cantidad_por_bulto") > 1 Then
                    txt_cant_caja.Text = dt.Rows(0)("Tipo_bulto").ToString.ToLower & " (bulto) de " & CInt(dt.Rows(0)("cantidad_por_bulto")) & _
                                    " unidades."
                Else
                    txt_cant_caja.Text = dt.Rows(0)("Tipo_bulto").ToString.ToLower & " (bulto) de " & CInt(dt.Rows(0)("cantidad_por_bulto")) & _
                    " unidad."
                End If
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub nuevo_producto()
        btn_agregar.Text = "Agregar Producto"
        btn_agregar.ImageIndex = 4

        nuevo_p = True

        txt_cod_producto.Text = String.Empty
        txt_descripcion.Text = String.Empty
        lbl_proveedor.Text = String.Empty
        txt_bultos.Text = String.Empty
        txt_cant_caja.Text = String.Empty
        txt_unidades.Text = String.Empty
    End Sub

    Private Sub nueva_solicitud()
        crea_estructuras()

        dtp_fecha.Value = Now.Date
        txt_numero.Text = String.Empty
        cmb_estatus.Text = "CREADA"

        btn_grabar.Text = "Guardar"
        btn_grabar.ImageIndex = 1

        btn_borrar.Enabled = False

        nuevo_producto()
    End Sub

    Private Sub frm_solicitud_reserva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nueva_solicitud()
    End Sub

    Private Sub crea_estructuras()
        Dim utrans As New Transaccional.Conexion("scm")
        Dim clGen As New ClasesGenerales.General

        If ds_info.Tables.Contains("permisos") Then ds_info.Tables.Remove("permisos")
        If ds_info.Tables.Contains("lista_solicitudes") Then ds_info.Tables.Remove("lista_solicitudes")
        If ds_info.Tables.Contains("dt_detalle") Then ds_info.Tables.Remove("dt_detalle")

        Try
            carga_permisos()

            utrans.open()

            sql_st = "pa_sel_um_da_lista_solicitud_reserva '" & gs_empresa & "'"
            dt = utrans.Obtiene(sql_st)
            dt.TableName = "lista_solicitudes"
            ds_info.Tables.Add(dt.Copy)


            sql_st = "pa_sel_um_da_detalle_solicitud_reserva '" & gs_empresa & "'"
            dt = utrans.Obtiene(sql_st)
            dt.TableName = "dt_detalle"
            ds_info.Tables.Add(dt.Copy)

            dgv_lista_ingresos.DataSource = ds_info.Tables("lista_solicitudes")
            dgv_lista_ingresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            clGen.Alinear_GridView(ds_info.Tables("lista_solicitudes"), dgv_lista_ingresos, "", "", "", "", "", "", "", True, True, 250, 0)

            dgv_detalle.DataSource = ds_info.Tables("dt_detalle")
            clGen.Alinear_GridView(ds_info.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

            clGen = Nothing

        Catch ex As Exception
            utrans.close()
            utrans = Nothing
        End Try
    End Sub

    Private Sub carga_permisos()

        If Not ds_info.Tables.Contains("permisos") Then
            Dim Otrans As New Transaccional.Conexion("Flexline")
            Otrans.open()

            sql_st = "pa_sel_um_sg_usuario_menu_opcion 14"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "permisos"
            ds_info.Tables.Add(dt.Copy)

            Otrans.close()
            Otrans = Nothing
        End If

        cmb_estatus.Items.Clear()

        cmb_estatus.Items.Add("CREADA")

        If ds_info.Tables("permisos").Compute("count(opcion)", "opcion = '" & p_aprueba_rechaza & "'") > 0 Or gi_tipo_usuario = 1 Then
            cmb_estatus.Items.Add("APROBADA")
            cmb_estatus.Items.Add("RECHAZADA")
        End If

        If (ds_info.Tables("permisos").Compute("count(opcion)", "opcion = '" & p_procesa & "'") > 0 Or gi_tipo_usuario = 1) And (cmb_estatus.Text = "APROBADA" Or cmb_estatus.Text = "PARCIAL") Then
            cmb_estatus.Items.Add("PROCESADA")
        End If
    End Sub
    Private Sub cm_nuevo_prod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_nuevo_prod.Click
        nuevo_producto()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If nuevo_p Then agregar_producto() Else actualiza_producto()
    End Sub

    Private Function agregar_producto() As Boolean
        Try
            If ds_info.Tables("dt_detalle").Compute("count(producto)", "producto = '" & txt_cod_producto.Text.Trim & "'") Then
                MessageBox.Show("Este producto ya existe en la solicitud.")
                Return False
            End If

            With ds_info.Tables("dt_detalle")
                Dim mNewRow As DataRow = .NewRow

                mNewRow("producto") = txt_cod_producto.Text
                mNewRow("descripcion") = txt_descripcion.Text
                mNewRow("bultos") = txt_bultos.Text
                mNewRow("cantidad") = txt_unidades.Text
                mNewRow("empresa") = gs_empresa
                mNewRow("proveedor") = Mid(lbl_proveedor.Text, 13)

                .Rows.Add(mNewRow)
            End With

            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(ds_info.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            clGen = Nothing
        Catch ex As Exception
            Return False
        End Try

        nuevo_producto()
        Return True
    End Function

    Private Function actualiza_producto() As Boolean
        Try
            With ds_info.Tables("dt_detalle")

                ds_info.Tables("dt_detalle").Rows(idRow)("producto") = txt_cod_producto.Text
                ds_info.Tables("dt_detalle").Rows(idRow)("descripcion") = txt_descripcion.Text
                ds_info.Tables("dt_detalle").Rows(idRow)("bultos") = txt_bultos.Text
                ds_info.Tables("dt_detalle").Rows(idRow)("cantidad") = txt_unidades.Text
                ds_info.Tables("dt_detalle").Rows(idRow)("empresa") = gs_empresa
                ds_info.Tables("dt_detalle").Rows(idRow)("proveedor") = Mid(lbl_proveedor.Text, 13)
            End With

            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(ds_info.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            clGen = Nothing
        Catch ex As Exception
            Return False
        End Try

        nuevo_producto()
        Return True
    End Function

    Private Sub dgv_detalle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_detalle.DoubleClick
        nuevo_p = False

        btn_agregar.Text = "Actualizar Producto"
        btn_agregar.ImageIndex = 5

        idRow = dgv_detalle.CurrentRow.Index

        txt_cod_producto.Text = ds_info.Tables("dt_detalle").Rows(idRow)("producto")
        txt_descripcion.Text = ds_info.Tables("dt_detalle").Rows(idRow)("descripcion")
        txt_bultos.Text = ds_info.Tables("dt_detalle").Rows(idRow)("bultos")
        txt_unidades.Text = ds_info.Tables("dt_detalle").Rows(idRow)("cantidad")
        lbl_proveedor.Text = "Proveedor:  " & ds_info.Tables("dt_detalle").Rows(idRow)("proveedor")

        buscar_producto(txt_cod_producto.Text)
    End Sub

    Private Sub dgv_detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_detalle.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("¿Está seguro de elimiar este producto?", "Eliminación de Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            ds_info.Tables("dt_detalle").Rows(dgv_detalle.CurrentRow.Index).Delete()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevo = True
        nueva_solicitud()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim Utrans As New Transaccional.Conexion("scm")
        Utrans.open()
        Try
            Dim cuenta_bultos As Integer = ds_info.Tables("dt_detalle").Compute("count(bultos)", "bultos = 0")
            If cuenta_bultos > 0 Then
                MessageBox.Show("No se puede grabar un documento con total de bultos 0.", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If

            If cuenta_bultos > 0 Then
                If MessageBox.Show("Existe" & IIf(cuenta_bultos > 1, "n ", " ") & cuenta_bultos & " producto" & IIf(cuenta_bultos > 1, "s ", " ") & _
                                "con un total de bultos '0'." & vbCrLf & "Si continua seran borrados y únicamente se guardaran los que posees valores." & vbCrLf & "¿Desea continual con la grabación?", "Bultos a cero '0'", MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    Dim todos As Boolean = True

                    Do
                        For ii As Integer = 0 To ds_info.Tables("dt_detalle").Rows.Count - 1
                            If Val(ds_info.Tables("dt_detalle").Rows(ii)("bultos").ToString) = 0 Then

                                ds_info.Tables("dt_detalle").Rows(ii).Delete()
                                todos = False
                                Exit For

                            End If

                            If ii = ds_info.Tables("dt_detalle").Rows.Count - 1 Then todos = True
                        Next
                    Loop Until todos

                End If
            End If

            If cmb_estatus.Text = "PROCESADA" Then
                Dim frmProceso As New frm_asocia_solicitud_reserva
                Dim resultado As Integer = frmProceso.cargar_informacion(ds_info, txt_numero.Text)

                If resultado = 0 Then
                    MessageBox.Show("No se ingresaron los datos necesario para poder continuar con el Proceso de la solicitud.", "Falla en proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If resultado = 1 Then
                        sql_st = "pa_upd_um_solicitud_reserva '" & gs_empresa & "','" & txt_numero.Text & "', 'PROCESADA'"
                        Utrans.Actualiza(sql_st)
                    ElseIf resultado = 2 Then
                        sql_st = "pa_upd_um_solicitud_reserva '" & gs_empresa & "','" & txt_numero.Text & "', 'PARCIAL'"
                        Utrans.Actualiza(sql_st)
                    End If

                    MessageBox.Show("Reserva procesada satisfactoriamente.", "Procesando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    crea_estructuras()
                    nueva_solicitud()

                    Exit Sub
                End If
            End If

            If MessageBox.Show("¿Desea guardar esta solicitud de reserva?", "Guardar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub
            sql_st = "pa_del_um_da_solicitud_reserva '" & gs_empresa & "','" & txt_numero.Text & "'"
            Utrans.Elimina(sql_st)


            With ds_info.Tables("dt_detalle")
                Dim sb_registro As New StringBuilder

                For ii As Integer = 0 To ds_info.Tables("dt_detalle").Rows.Count - 1


                    sb_registro = New StringBuilder

                    sb_registro.Append("pa_ins_um_da_solicitud_reserva  ").Append("'")
                    sb_registro.Append(gs_empresa).Append("', '")
                    sb_registro.Append(txt_numero.Text).Append("', '")
                    sb_registro.Append(dtp_fecha.Value.ToShortDateString).Append("', '")
                    sb_registro.Append(gs_usuario).Append("', '")
                    sb_registro.Append(ii + 1).Append("', '")
                    sb_registro.Append(.Rows(ii)("proveedor")).Append("', '")
                    sb_registro.Append(.Rows(ii)("producto")).Append("', ")
                    sb_registro.Append(.Rows(ii)("bultos")).Append(", ")
                    sb_registro.Append(.Rows(ii)("cantidad")).Append(", '")
                    sb_registro.Append(.Rows(ii)("descripcion")).Append("', '")
                    sb_registro.Append("BULTOS").Append("', '")
                    sb_registro.Append(cmb_estatus.Text).Append("'")
                    sb_registro.Append(",''")

                    Utrans.Ingresa(sb_registro.ToString)

                    If Utrans.Codigo_error <> 0 Then
                        MessageBox.Show(sb_registro.ToString & vbCrLf & vbCrLf & vbCrLf & Utrans.descripcion_error)
                        Exit Sub
                    End If
                Next
            End With

            MessageBox.Show("Reserva guardada satisfactoriamente.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

            crea_estructuras()
            nueva_solicitud()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub btn_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar.Click
        If MessageBox.Show("¿Realmente desea eliminar esta Reserva?", "Eliminar Reserva", MessageBoxButtons.YesNo, _
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("umbral")
        Utrans.open()
        Try
            sql_st = "pa_del_um_da_solicitud_reserva '" & gs_empresa & "','" & txt_numero.Text & "'"
            Utrans.Elimina(sql_st)

        Catch ex As Exception
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub dgv_lista_ingresos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_lista_ingresos.DoubleClick
        Dim actualRow As Integer = dgv_lista_ingresos.CurrentRow.Index
        nueva_solicitud()

        nuevo = False
        btn_borrar.Enabled = True
        If seleccionar_solicitud(dgv_lista_ingresos.Item("no_solicitud", actualRow).Value.ToString) Then
            TabControl1.SelectedTab = TabPage1

            btn_grabar.Text = "Modificar"
            btn_grabar.ImageIndex = 6
        End If

        carga_permisos()
        btn_borrar.Enabled = True
    End Sub

    Private Function seleccionar_solicitud(ByVal numero As String) As Boolean
        Try
            Dim mRow() As DataRow = ds_info.Tables("lista_solicitudes").Select("no_solicitud = '" & numero & "'")

            If mRow.Length > 0 Then
                txt_numero.Text = mRow(0)("no_solicitud")
                dtp_fecha.Value = CDate(mRow(0)("Fecha")).Date
                lbl_proveedor.Text = "Proveedor:  " & mRow(0)("proveedor")
                cmb_estatus.Text = mRow(0)("estatus")

                Dim clGen As New ClasesGenerales.General
                Dim Otrans As New Transaccional.Conexion("scm")

                Try
                    Otrans.open()
                    If ds_info.Tables.Contains("dt_detalle") Then ds_info.Tables.Remove("dt_detalle")

                    sql_st = "pa_sel_um_da_detalle_solicitud_reserva '" & gs_empresa & "', '" & numero & "'"
                    dt = Otrans.Obtiene(sql_st)
                    dt.TableName = "dt_detalle"
                    ds_info.Tables.Add(dt.Copy)

                Catch ex As Exception
                Finally
                    Otrans.close()
                    Otrans = Nothing
                End Try

                dgv_detalle.DataSource = ds_info.Tables("dt_detalle")
                dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                clGen.Alinear_GridView(ds_info.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

                clGen = Nothing
            Else
                MessageBox.Show("No se encontro el número de orden seleccionado.")
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub txt_numero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.Leave, txtObservaciones.Leave
        If Not nuevo Then Exit Sub
        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numero.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_numero_solicitud_reserva '" & gs_empresa & "','" & txt_numero.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("La Solicutd No. " & txt_numero.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
                    txt_numero.Text = String.Empty
                    txt_numero.Focus()
                Else
                    txt_numero.Enabled = False
                    txt_numero.BackColor = Color.White
                End If

            Catch ex As Exception
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        End If

    End Sub

    Private Sub cmb_estatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_estatus.SelectedIndexChanged
        If cmb_estatus.Text = "PROCESADA" Then
            cmb_estatus.Enabled = False
        Else
            cmb_estatus.Enabled = True
        End If
    End Sub
End Class