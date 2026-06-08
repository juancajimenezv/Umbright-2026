Imports System.Text

Public Class frm_di
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
        txt_numero.Text = String.Empty
        txt_numero.Enabled = True
        txt_dua.Text = String.Empty
        btn_borrar.Enabled = False
        txt_no_retiro.Text = String.Empty

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

        clGen = Nothing
    End Sub

    Private Sub frm_dua_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nuevo_di()
    End Sub

    Private Function pasa_validaciones() As Boolean

        If txt_numero.Text.Trim.Length <= 0 Then
            MessageBox.Show("Primero debe asignar un número de salida para poder agregar productos.", "Número de Salida", MessageBoxButtons.OK)
            txt_numero.Focus()
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

    Private Sub txt_numero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus
        If Not nuevo Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numero.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_da_numero_di '" & gs_empresa & "','" & txt_numero.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 And dt.Rows.Count <= 1 Then
                    MessageBox.Show("La salida No. " & txt_numero.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
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

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevo = True
        crear_estructuras()
        nuevo_di()
        btn_borrar.Enabled = False
    End Sub

    Private Function actualiza_producto() As Boolean
        Try
            With ds_datos.Tables("dt_detalle")

                ds_datos.Tables("dt_detalle").Rows(idRow)("producto") = txt_cod_producto.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("descripcion") = txt_descripcion.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("bultos") = txt_bultos.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("cantidad") = txt_unidades.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("empresa") = gs_empresa
                ds_datos.Tables("dt_detalle").Rows(idRow)("Bodega") = cb_bodega.ValueMember
                ds_datos.Tables("dt_detalle").Rows(idRow)("Lote") = Me.txt_lote.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("proveedor") = Mid(lbl_proveedor.Text, 13)
            End With

            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            clGen = Nothing
        Catch ex As Exception
            Return False
        End Try

        Return True

        nuevo_producto()
    End Function

    Private Function total_bultos() As Double
        Return ds_datos.Tables("dt_detalle").Compute("sum(bultos)", "1 = 1").ToString
    End Function

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Not pasa_validaciones() Then Exit Sub

        If actualiza_producto() Then nuevo_producto()
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

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Dua(txt_numero.Text)
    End Sub

    Private Sub Imprimir_Dua(ByVal numero_dua As String)
        'Dim pm_valores(3) As String
        'Dim pm_parametros(3) As String
        'Dim path_reporte As String

        'pm_parametros(0) = "Empresa"
        'pm_parametros(1) = "no_orden"
        'pm_valores(0) = gs_empresa
        'pm_valores(1) = numero_dua

        'path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\Compras e Importaciones\DIU\Reporte de Dua10.rpt"
        '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "UMBRALCD", "UMBRALSA", "flexline", "flexline", False, False, "PDF")
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

    Private Function verifica_saldo() As Boolean
        Dim Utrans As New Transaccional.Conexion("scm")
        Utrans.open()

        Try

            For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                With ds_datos.Tables("dt_detalle").Rows(ii)
                    dt = Utrans.Obtiene("pa_var_um_saldo_producto '" & gs_empresa & "', '" & txt_dua.Text & "', '" & .Item("producto") & "','" & .Item("lote") & "'")

                    If dt.Rows(0)("bultos") < .Item("bultos") Then
                        MessageBox.Show("No se puede continuar con la grabación ya que el producto (" & .Item("producto") & ") " & _
                                        .Item("descripcion") & " execele el saldo que posee en la DUA. " & vbCrLf & _
                                        "Por favor revise los valores.")
                        Return False
                    End If
                End With
            Next

            Utrans.close()
            Utrans = Nothing

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al verificar los saldos. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Utrans.close()
            Utrans = Nothing

            Return False
        End Try

        Return True
    End Function


    Private Sub guardarAvisos()

        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dtUsuarioEmpresa As DataTable
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim bguardarAviso As Boolean = False

        Try
            Otrans.open()
            myOtrans.open()
            lsSQL = "pa_sel_um_gen_tabcod '" & Mid(lbl_proveedor.Text, 13) & _
                        "','CON_PROVEE','" & gs_empresa & "'"
            dt2 = Otrans.Obtiene(lsSQL)

            lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
            dtUsuarioEmpresa = Otrans.Obtiene(lsSQL)

            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(4)" '4= Ingreso de DI
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                If dr.Item("validar_marca").ToString = "1" Then
                    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                    If dt2.DefaultView.Count > 0 Then bguardarAviso = True

                ElseIf dr.Item("validar_empresa").ToString = "1" Then
                    dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                    If dtUsuarioEmpresa.DefaultView.Count > 0 Then bguardarAviso = True

                Else
                    bguardarAviso = True

                End If

                If bguardarAviso Then
                    ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Creacion de DI " & _
                                                        Me.txt_numero.Text & " del Proveedor " & _
                                                        Mid(lbl_proveedor.Text, 13), 4)
                    bguardarAviso = False
                End If
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing

        End Try


    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If Not verifica_saldo() Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")
        Utrans.open()
        Try
            Dim cuenta_bultos As Integer = ds_datos.Tables("dt_detalle").Compute("count(bultos)", "bultos = 0")
            If total_bultos() <= 0 Then
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
                        For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                            If Val(ds_datos.Tables("dt_detalle").Rows(ii)("bultos").ToString) = 0 Then
                                ds_datos.Tables("dt_detalle").Rows(ii).Delete()

                                todos = False
                                Exit For
                            End If

                            If ii = ds_datos.Tables("dt_detalle").Rows.Count - 1 Then todos = True
                        Next

                    Loop Until todos
                End If
            End If


            If MessageBox.Show("¿Desea guardar esta salida?", "Guardar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            With ds_datos.Tables("dt_detalle")
                Dim sb_registro As New StringBuilder

                For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                    sb_registro = New StringBuilder

                    If btn_grabar.Text.ToUpper = "GUARDAR" Then
                        sb_registro.Append("pa_ins_um_da_di  ").Append("'")
                    Else
                        sb_registro.Append("pa_upd_um_da_di  ").Append("'")
                    End If

                    sb_registro.Append(dtp_fecha.Value.ToShortDateString).Append("', '")
                    sb_registro.Append(txt_numero.Text).Append("', '")
                    sb_registro.Append(gs_usuario).Append("', '")
                    sb_registro.Append(gs_empresa).Append("', '")
                    sb_registro.Append(Mid(lbl_proveedor.Text, 13)).Append("', '")
                    sb_registro.Append(txt_dua.Text).Append("', '")
                    sb_registro.Append(cb_bodega.SelectedValue).Append("', '")
                    sb_registro.Append(.Rows(ii)("producto")).Append("', '")
                    sb_registro.Append(.Rows(ii)("descripcion")).Append("', '")
                    sb_registro.Append("BULTOS").Append("', '")
                    sb_registro.Append(cb_bodega.Text).Append("', ")
                    sb_registro.Append(ii + 1).Append(", ")
                    sb_registro.Append(.Rows(ii)("bultos")).Append(", ")
                    sb_registro.Append(.Rows(ii)("cantidad")).Append(", ")
                    sb_registro.Append(Val(txt_no_retiro.Text)).Append(",'")
                    sb_registro.Append(.Rows(ii)("lote")).Append("'")

                    Utrans.Ingresa(sb_registro.ToString)

                    If Utrans.Codigo_error <> 0 Then
                        MessageBox.Show(sb_registro.ToString & vbCrLf & vbCrLf & vbCrLf & Utrans.descripcion_error)
                    End If
                Next
            End With

            MessageBox.Show("Salida guardado satisfactoriamente.", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'If MessageBox.Show("Salida guardado satisfactoriamente." & vbCrLf & "¿Desea imprimirla?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            'Imprimir_Dua(txt_numero.Text)
            'End If
            If btn_grabar.Text.ToUpper = "GUARDAR" Then guardarAvisos()
            nuevo_di()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub btn_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar.Click
        If MessageBox.Show("¿Realmente desea eliminar esta salida?", "Eliminar Salida", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")
        Try
            Utrans.open()

            sql_st = "pa_del_um_da_di '" & gs_empresa & "', '" & txt_numero.Text & "'"
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

    Private Sub dgv_detalle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_detalle.DoubleClick
        Try
            idRow = dgv_detalle.CurrentRow.Index

            Dim producto As String = dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value.ToString
            Dim lote As String = dgv_detalle.Item("lote", dgv_detalle.CurrentRow.Index).Value.ToString

            Dim mNewRow() As DataRow = ds_datos.Tables("dt_detalle").Select("producto = '" & producto & "' and lote = '" & lote & "'")
            Dim rowSaldo() As DataRow = dtSaldos.Select("producto = '" & producto & "' and lote = '" & lote & "'")





            txt_cod_producto.Text = mNewRow(0)("producto").ToString
            txt_descripcion.Text = mNewRow(0)("descripcion").ToString
            txt_lote.Text = mNewRow(0)("lote").ToString
            gs_empresa = mNewRow(0)("empresa").ToString
            txt_saldo_b.Text = ds_datos.Tables("dt_detalle_dua").Compute("sum(saldo_bultos)", "no_dua = '" & txt_dua.Text.Trim & "' and producto = '" & txt_cod_producto.Text & "' and lote ='" & txt_lote.Text & "'") + _
                                rowSaldo(0)("bultos").ToString
            txt_saldo_u.Text = ds_datos.Tables("dt_detalle_dua").Compute("sum(saldo)", "no_dua = '" & txt_dua.Text.Trim & "' and producto = '" & txt_cod_producto.Text & "' and lote ='" & txt_lote.Text & "'") + _
                                rowSaldo(0)("cantidad").ToString
            lbl_proveedor.Text = "Proveedor:  " & mNewRow(0)("proveedor").ToString
            txt_bultos.Focus()

        Catch ex As Exception
            MessageBox.Show("Se produjo un error al retraer el producto por favor intentelo de nuevo." & _
                   vbCrLf & "------------------------------------------------------------------------" & _
                   vbCrLf & "Error:" & vbCrLf & ex.Message, _
                   "Error Al Retraer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.TextChanged
        If txt_numero.Text.Trim.Length > 0 Then
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
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "producto,descripcion,bodega,No_DUA"
        frm_busqueda.nombre_vista = "vst_detalle_dua"
        frm_busqueda.lista_campos = "No_dua, Bodega, Fecha_Vence_DUA, Fecha_Vence_Prod, Producto, Descripcion, Unidades, Saldo_Unidades, Bultos, Saldo_Bultos"
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

        txt_dua.Text = cod_dua

        mostrar_detalle_dua(cod_dua)
    End Sub

    Private Sub mostrar_detalle_dua(ByVal numero As String)
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()

            If ds_datos.Tables.Contains("dt_detalle_dua") Then ds_datos.Tables.Remove("dt_detalle_dua")

            sql_st = "pa_sel_um_da_detalle_dua '" & gs_empresa & "', '" & numero.Trim & "'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_detalle_dua"
            ds_datos.Tables.Add(dt.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables("dt_detalle").Rows.Clear()

        For ii As Integer = 0 To dt.Rows.Count - 1
            Dim mNewRow As DataRow = ds_datos.Tables("dt_detalle").NewRow
            lbl_proveedor.Text = "Proveedor:  " & dt.Rows(ii)("proveedor")

            mNewRow("producto") = dt.Rows(ii)("producto")
            mNewRow("descripcion") = dt.Rows(ii)("descripcion")
            mNewRow("proveedor") = dt.Rows(ii)("proveedor")
            mNewRow("bultos") = 0
            mNewRow("cantidad") = 0
            mNewRow("lote") = dt.Rows(ii)("lote")
            mNewRow("bodega") = cb_bodega.Text
            mNewRow("empresa") = gs_empresa

            ds_datos.Tables("dt_detalle").Rows.Add(mNewRow)
        Next

        dtSaldos.Rows.Clear()

        dtSaldos = ds_datos.Tables("dt_detalle").Copy

        dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
        dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

        clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        clGen = Nothing

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

    Private Sub dgv_lista_ingresos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_lista_ingresos.DoubleClick
        'Dim rowActual As Integer = dgv_lista_ingresos.CurrentRow.Index

        Dim sdi As String = dgv_lista_ingresos.Item("numero_di", dgv_lista_ingresos.CurrentRow.Index).Value.ToString
        nuevo_di()

        nuevo = False
        btn_borrar.Enabled = True
        If seleccionar_di(sdi) Then
            TabControl1.SelectedTab = TabPage1

            btn_grabar.Text = "Modificar"
            btn_grabar.ImageIndex = 6
        End If
    End Sub

    Private Function seleccionar_di(ByVal numero As String) As Boolean
        Try
            Dim mRow() As DataRow = ds_datos.Tables("dt_lista").Select("numero_di = '" & numero & "'")

            If mRow.Length > 0 Then
                txt_numero.Text = mRow(0)("numero_di")
                dtp_fecha.Value = CDate(mRow(0)("Fecha")).Date

                If Now.Date < dtp_fecha.Value.Date.AddDays(2) Then
                    btn_grabar.Enabled = True
                Else
                    btn_grabar.Enabled = False
                End If

                cb_bodega.Text = mRow(0)("bodega")
                lbl_proveedor.Text = "Proveedor:  " & mRow(0)("proveedor")
                txt_dua.Text = mRow(0)("dua")
                txt_no_retiro.Text = mRow(0)("no_retiro")

                mostrar_detalle_dua(mRow(0)("dua"))

                Dim clGen As New ClasesGenerales.General
                Dim Otrans As New Transaccional.Conexion("scm")

                Try
                    Otrans.open()
                    If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")

                    sql_st = "pa_sel_um_da_di_detalle '" & gs_empresa & "', '" & numero & "'"
                    dt = Otrans.Obtiene(sql_st)
                    dt.TableName = "dt_detalle"
                    ds_datos.Tables.Add(dt.Copy)

                    dtSaldos.Rows.Clear()
                    dtSaldos = dt.Copy

                Catch ex As Exception
                Finally
                    Otrans.close()
                    Otrans = Nothing
                End Try

                dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
                dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

                clGen = Nothing
            Else
                MessageBox.Show("No se encontro el número de orden seleccionado.")
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub dgv_detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_detalle.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("¿Está seguro de elimiar este producto?", "Eliminación de Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            ds_datos.Tables("dt_detalle").Rows(dgv_detalle.CurrentRow.Index).Delete()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        nuevo_producto()
    End Sub

    Private Sub txt_numero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.Leave
        If Not nuevo Then Exit Sub
        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numero.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_numero_di '" & gs_empresa & "','" & txt_numero.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("La DI No. " & txt_numero.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
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

    Private Sub txt_cod_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_producto.TextChanged
        Dim rTrans As New Transaccional.Conexion("flexline")

        sql_st = "pa_sel_um_prodcodbarra '" & gs_empresa & "', '" & Me.txt_cod_producto.Text & "'"

        rTrans.open()
        dt = rTrans.Obtiene(sql_st)

        Dim dRow() As DataRow

        dRow = dt.Select("linea = 4")

        If dRow.Length <= 0 Then
            txt_cod_provee.Text = String.Empty
        Else
            txt_cod_provee.Text = dRow(0)("codbarra")
        End If

        rTrans.close()
        rTrans = Nothing
    End Sub

    Private Sub txt_dua_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dua.TextChanged

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub txt_no_retiro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_retiro.TextChanged

    End Sub
End Class