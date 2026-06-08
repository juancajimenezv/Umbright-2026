Imports System.Text

Public Class frm_dr
    Dim ds_datos As New DataSet
    Dim estilo As New DataGridTableStyle
    Dim sql_st As String = String.Empty
    Dim dt As DataTable
    Dim nuevo As Boolean = False
    Dim no_oc As String = String.Empty
    Dim idRow As Integer
    Dim dtSaldos As New DataTable

    Private Sub nuevo_di()
        crear_estructuras()
        nuevo = True
        txt_numeroDR.Text = String.Empty
        txt_numeroDR.Enabled = True
        txt_dua.Text = String.Empty
        btn_borrar.Enabled = False
        txt_no_reserva.Text = String.Empty
        Me.txtProveedor.Text = String.Empty
        Me.txtProveedor.Enabled = False

        dtp_fecha.Value = Now.Date
        cb_bodega.SelectedIndex = 0
        nuevo_producto()

        GroupBox2.Enabled = False
        txt_dua.Enabled = False
        cb_bodega.Enabled = False
        dtp_fecha.Enabled = False

        ds_datos.Tables("dt_detalle").Rows.Clear()

        btn_grabar.Text = "Guardar"
        btn_grabar.ImageIndex = 1
    End Sub

    Private Sub crear_estructuras()
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()
            ds_datos = New DataSet

            If ds_datos.Tables.Contains("dt_bodegas") Then ds_datos.Tables.Remove("dt_bodegas")
            If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")
            If ds_datos.Tables.Contains("dt_lista") Then ds_datos.Tables.Remove("dt_lista")
            If ds_datos.Tables.Contains("dt_dr") Then ds_datos.Tables.Remove("dt_dr")

            sql_st = "pa_sel_um_bodegas '" & gs_empresa & "', 'S'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_bodegas"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_da_di_detalle '" & gs_empresa & "'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_detalle"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_da_lista_dI '" & gs_empresa & "'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_lista"
            ds_datos.Tables.Add(dt.Copy)


            dt = New DataTable
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("bultos", GetType(Integer)))
            dt.Columns.Add(New DataColumn("unidades", GetType(Integer)))

            dt.Columns.Add(New DataColumn("lote", GetType(String)))
            dt.Columns.Add(New DataColumn("bultos_s", GetType(Integer)))
            dt.Columns.Add(New DataColumn("unidades_s", GetType(Integer)))

            dt.TableName = "dt_dr"
            ds_datos.Tables.Add(dt.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        cb_bodega.ValueMember = "codigo"
        cb_bodega.DisplayMember = "descripcion"
        cb_bodega.DataSource = ds_datos.Tables("dt_bodegas")

        dgv_lista_ingresos.DataSource = ds_datos.Tables("dt_lista")
        dgv_lista_ingresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        clGen.Alinear_GridView(ds_datos.Tables("dt_lista"), dgv_lista_ingresos, "", "", "", "", "", "", "", True, True, 250, 0)

        dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
        dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

        clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        Me.dgv_productosDR.DataSource = ds_datos.Tables("dt_dr")
        clGen = Nothing
    End Sub

    Private Sub frm_dua_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nuevo_di()
    End Sub

    Private Function pasa_validaciones() As Boolean

        If txt_numeroDR.Text.Trim.Length <= 0 Then
            MessageBox.Show("Primero debe asignar un número de salida para poder agregar productos.", "Número de Salida", MessageBoxButtons.OK)
            txt_numeroDR.Focus()
            Return False
        End If


        If Val(txt_unidades.Text.Trim) < 0 Then
            MessageBox.Show("El valor que ingreso para las unidades es incorrecto.", "Valor incorrecto", MessageBoxButtons.OK)
            txt_unidades.Focus()
            Return False
        End If

        Dim cantidad As Integer = Val(txt_saldo_u.Text) / Val(txt_saldo_b.Text)

        If (Val(txt_bultos.Text) * cantidad) <> Val(txt_unidades.Text) Then
            MessageBox.Show("Las unidades para el valor en bultos debería ser " & Val(txt_bultos.Text) * cantidad & ".", "Valor incorrecto", MessageBoxButtons.OK)
            txt_unidades.Text = String.Empty
            txt_unidades.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub txt_numero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numeroDR.LostFocus
        If Not nuevo Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numeroDR.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_da_numero_di '" & gs_empresa & "','" & txt_numeroDR.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 And dt.Rows.Count <= 1 Then
                    MessageBox.Show("La salida No. " & txt_numeroDR.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
                    txt_numeroDR.Text = String.Empty
                    txt_numeroDR.Focus()
                Else
                    txt_numeroDR.Enabled = False
                    txt_numeroDR.BackColor = Color.White
                End If

            Catch ex As Exception
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevo = True
        crear_estructuras()
        nuevo_di()
        btn_borrar.Enabled = False
    End Sub

    Private Function total_bultos() As Double
        Return ds_datos.Tables("dt_detalle").Compute("sum(bultos)", "1 = 1").ToString
    End Function

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Not pasa_validaciones() Then Exit Sub
        agregarProducto()

        '     If actualiza_producto() Then nuevo_producto()
    End Sub

    Private Sub agregarProducto()

        Dim dr As DataRow
        Dim clsGen As New ClasesGenerales.General

        Try
            For Each dr In ds_datos.Tables("dt_dr").Rows
                If dr.Item("producto").ToString.Equals(Me.txt_cod_producto.Text) And _
                    dr.Item("lote").ToString.Equals(Me.txt_lote.Text) Then

                    dr.Item("unidades") = Me.txt_unidades.Text
                    dr.Item("bultos") = Me.txt_bultos.Text
                    Exit Try

                End If
            Next

            dr = ds_datos.Tables("dt_dr").NewRow
            dr.Item("producto") = Me.txt_cod_producto.Text
            dr.Item("descripcion") = Me.txt_descripcion.Text
            dr.Item("unidades") = Me.txt_unidades.Text
            dr.Item("bultos") = Me.txt_bultos.Text
            dr.Item("lote") = Me.txt_lote.Text
            ds_datos.Tables("dt_dr").Rows.Add(dr)

            Me.dgv_productosDR.DataSource = ds_datos.Tables("dt_dr")

        Catch ex As Exception
        Finally
            clsGen.Alinear_GridView(ds_datos.Tables("dt_dr"), Me.dgv_productosDR, "", "", "", "", "", "", "", True, True, 250, 0)
            clsGen = Nothing
        End Try
    End Sub

    Private Sub nuevo_producto()
        txt_cod_producto.Text = String.Empty
        txt_descripcion.Text = String.Empty
        txt_unidades.Text = String.Empty
        txt_saldo_u.Text = String.Empty
        txt_saldo_b.Text = String.Empty
        txt_unidades.Text = String.Empty
        txt_bultos.Text = String.Empty
    End Sub

    Sub _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String)

        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)

        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, False)

        If Oaut.Descripcion_Error.Length > 0 Then
            MessageBox.Show(Oaut.Descripcion_Error)
        End If

        Oaut.finalizar()
        Oaut = Nothing
    End Sub

    ''Verificamos el saldo de la reserva

    Private Function verifica_saldo() As Boolean
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_da_detalle_reserva '" & gs_empresa & "','" & Me.txt_no_reserva.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In ds_datos.Tables("dt_dr").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "' and lote = '" & dr.Item("lote").ToString & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("unidades_s") = dt.DefaultView(0).Item("cantidad")
                    dr.Item("bultos_s") = dt.DefaultView(0).Item("bultos")
                End If
            Next


        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al verificar los saldos. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return True
    End Function


    'Private Sub guardarAvisos()

    '    Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
    '    Dim Otrans As New Transaccional.Conexion("FlexLine")
    '    Dim dt, dt2, dtUsuarioEmpresa As DataTable
    '    Dim lsSQL As String
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim bguardarAviso As Boolean = False

    '    Try
    '        Otrans.open()
    '        myOtrans.open()
    '        lsSQL = "pa_sel_um_gen_tabcod '" & Mid(lbl_proveedor.Text, 13) & _
    '                    "','CON_PROVEE','" & gs_empresa & "'"
    '        dt2 = Otrans.Obtiene(lsSQL)

    '        lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
    '        dtUsuarioEmpresa = Otrans.Obtiene(lsSQL)

    '        lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(4)" '4= Ingreso de DI
    '        dt = myOtrans.Obtiene(lsSQL)
    '        For Each dr As DataRow In dt.Rows

    '            If dr.Item("validar_marca").ToString = "1" Then
    '                dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
    '                If dt2.DefaultView.Count > 0 Then bguardarAviso = True

    '            ElseIf dr.Item("validar_empresa").ToString = "1" Then
    '                dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
    '                If dtUsuarioEmpresa.DefaultView.Count > 0 Then bguardarAviso = True

    '            Else
    '                bguardarAviso = True

    '            End If

    '            If bguardarAviso Then
    '                ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Creacion de DI " & _
    '                                                    Me.txt_numero.Text & " del Proveedor " & _
    '                                                    Mid(lbl_proveedor.Text, 13), 4)
    '                bguardarAviso = False
    '            End If
    '        Next

    '    Catch ex As Exception
    '    Finally
    '        Otrans.close()
    '        Otrans = Nothing
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        ClsGen = Nothing

    '    End Try


    'End Sub

    Private Sub guardarDR()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim sb_registro As New StringBuilder
        Dim iCount As Integer = 0

        Try
            Otrans.open()

            For Each dr As DataRow In ds_datos.Tables("dt_dr").Rows
                If dr.Item("unidades") > 0 And dr.Item("bultos") > 0 Then
                    ''Actualizo reserva
                    lsSQL = "pa_upd_um_da_reserva_detalle '" & gs_empresa & "','" & Me.txt_no_reserva.Text & "','" & _
                            dr.Item("producto").ToString & "'," & _
                            dr.Item("bultos_s") - dr.Item("bultos") & "," & _
                            dr.Item("unidades_s") - dr.Item("unidades") & "," & _
                            IIf(dr.Item("lote").ToString.Trim.Length > 0, "'" & dr.Item("lote").ToString & "'", "NULL")

                    Otrans.Actualiza(lsSQL)

                    ''Inserto DI

                    iCount += 1
                    If Otrans.Codigo_error = 0 Then
                        sb_registro = New StringBuilder
                        sb_registro.Append("pa_ins_um_da_di  ").Append("'")
                        sb_registro.Append(dtp_fecha.Value.ToShortDateString).Append("', '")
                        sb_registro.Append(txt_numeroDR.Text).Append("', '")
                        sb_registro.Append(gs_usuario).Append("', '")
                        sb_registro.Append(gs_empresa).Append("', '")
                        sb_registro.Append(txtProveedor.Text).Append("', '")
                        sb_registro.Append(txt_dua.Text).Append("', '")
                        sb_registro.Append(cb_bodega.SelectedValue).Append("', '")
                        sb_registro.Append(dr.Item("producto")).Append("', '")
                        sb_registro.Append(dr.Item("descripcion")).Append("', '")
                        sb_registro.Append("BULTOS").Append("', '")
                        sb_registro.Append(cb_bodega.Text).Append("', ")
                        sb_registro.Append(iCount).Append(", ")
                        sb_registro.Append(dr.Item("bultos")).Append(", ")
                        sb_registro.Append(dr.Item("unidades")).Append(", ")
                        sb_registro.Append("0").Append(",'")
                        sb_registro.Append(dr.Item("lote")).Append("','")
                        sb_registro.Append(Me.txt_no_reserva.Text).Append("'")

                        Otrans.Ingresa(sb_registro.ToString)
                    End If
                End If
            Next
            If iCount > 0 Then
                lsSQL = "pa_upd_da_reserva_encabezado_estado '" & gs_empresa & "', '" & Me.txt_no_reserva.Text & "'"
                Otrans.Actualiza(lsSQL)

                MessageBox.Show("Proceso Finalizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo_di()
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub


    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If Not verifica_saldo() Then Exit Sub

        guardarDR()
        Exit Sub

    End Sub

    Private Sub btn_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar.Click
        If MessageBox.Show("¿Realmente desea eliminar esta salida?", "Eliminar Salida", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")
        Try
            Utrans.open()

            sql_st = "pa_del_um_da_di '" & gs_empresa & "', '" & txt_numeroDR.Text & "'"
            Utrans.Elimina(sql_st)

            crear_estructuras()
            nuevo_di()
            btn_borrar.Enabled = False
        Catch ex As Exception
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numeroDR.TextChanged
        If txt_numeroDR.Text.Trim.Length > 0 Then
            GroupBox2.Enabled = True
            txt_dua.ReadOnly = False
            cb_bodega.Enabled = True
            dtp_fecha.Enabled = True
        Else
            GroupBox2.Enabled = False
            txt_dua.ReadOnly = True
            cb_bodega.Enabled = False
            dtp_fecha.Enabled = False
        End If
    End Sub

    Private Sub btn_ayuda_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_oc.Click
        Dim cod_dua As String = String.Empty
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.conectar = "scm"
        frm_busqueda.parametros_fijos = " estatus='APROBADA' and empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "proveedor,no_orden"
        frm_busqueda.nombre_vista = "da_reserva_encabezado"
        frm_busqueda.lista_campos = "no_orden as No_Reserva, Proveedor, dua, fecha, observaciones, Bodega"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        Try
            cod_dua = frm_busqueda.resultado.Trim

        Catch ex As Exception

        End Try

        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        Me.txt_no_reserva.Text = cod_dua
        mostrarDetalleReserva()

        'mostrar_detalle_dua(cod_dua)
    End Sub

    Private Sub mostrarDetalleReserva()
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_da_detalle_reserva '" & gs_empresa & "','" & Me.txt_no_reserva.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                Me.txt_dua.Text = dt.Rows(0).Item("dua").ToString
                Me.cb_bodega.Text = dt.Rows(0).Item("bodega").ToString
                Me.txtProveedor.Text = dt.Rows(0).Item("proveedor").ToString
            End If
            Me.dgv_detalle.DataSource = dt
            clsGEN.Alinear_GridView(dt, Me.dgv_detalle, "", "", "", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGEN = Nothing

        End Try

    End Sub



    Private Sub txt_bultos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_bultos.TextChanged
        If Val(txt_bultos.Text) > Val(txt_saldo_b.Text) Then
            MessageBox.Show("Error en bultos:" & vbCrLf & "El monto ingresado supera al saldo de Bultos.", "Error en Bultos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_bultos.Text = String.Empty
            txt_bultos.Focus()
        End If
    End Sub

    Private Sub txt_unidades_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unidades.TextChanged
        If Val(txt_unidades.Text) > Val(txt_saldo_u.Text) Then
            MessageBox.Show("Error en bultos:" & vbCrLf & "El monto ingresado supera al saldo de Bultos.", "Error en Bultos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_bultos.Text = String.Empty
            txt_bultos.Focus()
        End If
    End Sub

    'Private Sub dgv_lista_ingresos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_lista_ingresos.DoubleClick
    '    'Dim rowActual As Integer = dgv_lista_ingresos.CurrentRow.Index

    '    Dim sdi As String = dgv_lista_ingresos.Item("numero_di", dgv_lista_ingresos.CurrentRow.Index).Value.ToString
    '    nuevo_di()

    '    nuevo = False
    '    btn_borrar.Enabled = True
    '    If seleccionar_di(sdi) Then
    '        TabControl1.SelectedTab = TabPage1

    '        btn_grabar.Text = "Modificar"
    '        btn_grabar.ImageIndex = 6
    '    End If
    'End Sub

    'Private Function seleccionar_di(ByVal numero As String) As Boolean
    '    Try
    '        Dim mRow() As DataRow = ds_datos.Tables("dt_lista").Select("numero_di = '" & numero & "'")

    '        If mRow.Length > 0 Then
    '            txt_numeroDR.Text = mRow(0)("numero_di")
    '            dtp_fecha.Value = CDate(mRow(0)("Fecha")).Date

    '            If Now.Date < dtp_fecha.Value.Date.AddDays(2) Then
    '                btn_grabar.Enabled = True
    '            Else
    '                btn_grabar.Enabled = False
    '            End If

    '            cb_bodega.Text = mRow(0)("bodega")
    '            '             lbl_proveedor.Text = "Proveedor:  " & mRow(0)("proveedor")
    '            txt_dua.Text = mRow(0)("dua")
    '            txt_no_reserva.Text = mRow(0)("no_retiro")

    '            '  mostrar_detalle_dua(mRow(0)("dua"))

    '            Dim clGen As New ClasesGenerales.General
    '            Dim Otrans As New Transaccional.Conexion("scm")

    '            Try
    '                Otrans.open()
    '                If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")

    '                sql_st = "pa_sel_um_da_di_detalle '" & gs_empresa & "', '" & numero & "'"
    '                dt = Otrans.Obtiene(sql_st)
    '                dt.TableName = "dt_detalle"
    '                ds_datos.Tables.Add(dt.Copy)

    '                dtSaldos.Rows.Clear()
    '                dtSaldos = dt.Copy

    '            Catch ex As Exception
    '            Finally
    '                Otrans.close()
    '                Otrans = Nothing
    '            End Try

    '            dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
    '            dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

    '            clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

    '            clGen = Nothing
    '        Else
    '            MessageBox.Show("No se encontro el número de orden seleccionado.")
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try

    '    Return True
    'End Function

    Private Sub mostrarProducto(ByVal irow As Integer)

        Me.txt_cod_producto.Text = Me.dgv_detalle.Item("producto", irow).Value.ToString
        Me.txt_descripcion.Text = Me.dgv_detalle.Item("descripcion", irow).Value.ToString
        Me.txt_lote.Text = Me.dgv_detalle.Item("lote", irow).Value.ToString
        Me.txt_saldo_b.Text = Double.Parse(Me.dgv_detalle.Item("bultos", irow).Value.ToString)
        Me.txt_saldo_u.Text = Double.Parse(Me.dgv_detalle.Item("cantidad", irow).Value.ToString)
        Me.txt_bultos.Text = String.Empty
        Me.txt_unidades.Text = String.Empty
    End Sub

    Private Sub dgv_detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_detalle.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("¿Está seguro de elimiar este producto?", "Eliminación de Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            ds_datos.Tables("dt_detalle").Rows(dgv_detalle.CurrentRow.Index).Delete()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        nuevo_producto()
    End Sub

    Private Sub txt_numero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numeroDR.Leave
        If Not nuevo Then Exit Sub
        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numeroDR.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_numero_di '" & gs_empresa & "','" & txt_numeroDR.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("La DI No. " & txt_numeroDR.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
                    txt_numeroDR.Text = String.Empty
                    txt_numeroDR.Focus()
                Else
                    txt_numeroDR.Enabled = False
                    txt_numeroDR.BackColor = Color.White
                End If

            Catch ex As Exception
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        End If
    End Sub

    Private Sub txt_cod_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_producto.TextChanged
        Dim rTrans As New Transaccional.Conexion("flexline")

        sql_st = "pa_sel_um_prodcodbarra '" & gs_empresa & "', '" & Me.txt_cod_producto.Text & "'"

        rTrans.open()
        dt = rTrans.Obtiene(sql_st)

        Dim dRow() As DataRow

        dRow = dt.Select("linea = 4")

        'If dRow.Length <= 0 Then
        '    txt_cod_provee.Text = String.Empty
        'Else
        '    txt_cod_provee.Text = dRow(0)("codbarra")
        'End If


        rTrans.close()
        rTrans = Nothing
    End Sub

    Private Sub txt_dua_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dua.TextChanged

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub txt_no_retiro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_detalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_detalle.CurrentCellChanged
        Try
            MostrarProducto(Me.dgv_detalle.CurrentRow.Index)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class