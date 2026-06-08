Imports System.Text

Public Class frm_asocia_solicitud_reserva
    Dim sql_st As String = String.Empty
    Dim ds_datos As New DataSet
    Dim dt As New DataTable
    Dim no_solicitud As String
    Dim idRow As Integer
    Dim sb_registro As New StringBuilder
    Dim estado As Integer = 0

    Private Sub frm_asocia_solicitud_reserva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructuras(no_solicitud)
    End Sub

    Private Sub crear_estructuras(ByVal numero As String)
        Dim Strans As New Transaccional.Conexion("scm")
        Try
            Strans.open()

            ds_datos = New DataSet

            If ds_datos.Tables.Contains("dt_bodegas") Then ds_datos.Tables.Remove("dt_bodegas")
            If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")

            sql_st = "pa_sel_um_bodegas '" & gs_empresa & "'"
            dt = Strans.Obtiene(sql_st)
            dt.TableName = "dt_bodegas"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_da_detalle_asocia_solicitud_reserva '" & gs_empresa & "', '" & numero & "'"
            dt = Strans.Obtiene(sql_st)
            dt.TableName = "dt_detalle"
            ds_datos.Tables.Add(dt.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Strans.close()
            Strans = Nothing
        End Try

        cb_bodega.ValueMember = "codigo"
        cb_bodega.DisplayMember = "descripcion"
        cb_bodega.DataSource = ds_datos.Tables("dt_bodegas")

        Dim clGen As New ClasesGenerales.General

        dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
        dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        clGen = Nothing
    End Sub

    Public Function cargar_informacion(ByVal ds_info As DataSet, ByVal numero As String) As Integer
        no_solicitud = numero

        Me.ShowDialog()

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return estado
        Else
            Return 0
        End If
    End Function

    Private Sub btn_ayuda_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_oc.Click
        Try
            If txt_producto.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no a seleccionado el producto al cual se le asignará la DI.", "No existe Producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim cod_dua As String = String.Empty
            Dim frm_busqueda As New frm_busqueda_general

            frm_busqueda.conectar = "scm"
            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and producto = '" & txt_producto.Text & "' and saldo_unidades > " & Val(txt_unidades.Text) & " and  "
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

                frm_busqueda.Dispose()
                frm_busqueda = Nothing

                txt_dua.Text = cod_dua
            Catch ex As Exception

            End Try

        Catch ex As Exception
            MessageBox.Show("Se produjo un error al retraer la información." & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub limpiar()
        txt_dua.Text = String.Empty
        cb_bodega.SelectedIndex = 0
        txt_reserva.Text = String.Empty

        txt_producto.Text = String.Empty
        txt_descripcion.Text = String.Empty

        txt_bultos.Text = String.Empty
        txt_unidades.Text = String.Empty

    End Sub

    Private Function verifica_saldo() As Boolean
        Dim Utrans As New Transaccional.Conexion("scm")
        Utrans.open()

        Try

            For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                With ds_datos.Tables("dt_detalle").Rows(ii)
                    dt = Utrans.Obtiene("pa_var_um_saldo_producto '" & gs_empresa & "', '" & .Item("dua") & "', '" & .Item("producto") & "'")

                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("bultos") < .Item("bultos") Then
                            MessageBox.Show("No se puede continuar con la grabación ya que el producto (" & .Item("producto") & ") " & _
                                            .Item("descripcion") & " execele el saldo que posee en la DUA. " & vbCrLf & _
                                            "Por favor revise los valores.")
                            Return False
                        End If
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

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        If Not verifica_saldo() Then Exit Sub

        Dim sin_dua As Integer = ds_datos.Tables("dt_detalle").Compute("count(dua)", "dua = '' or reserva = '' or bodega = ''")
        Dim sb_mensaje As New StringBuilder
        estado = 1

        If sin_dua > 0 Then
            sb_mensaje.Append("Existen ").Append(sin_dua).Append(" producto")
            If sin_dua > 1 Then sb_mensaje.Append("s")
            sb_mensaje.Append(" de la solicitud a los cuales no se les ha asignado DUA, Reserva o Bodega.")
            sb_mensaje.Append(vbCrLf)
            sb_mensaje.Append("Si continua con el proceso estos productos no seran tomados en cuenta.")
            sb_mensaje.Append(vbCrLf)
            sb_mensaje.Append("¿Desea continuar con el proceso?")

            If MessageBox.Show(sb_mensaje.ToString, "Productos Sin DUA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            estado = 2
        End If

        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()

            Dim mNewRow() As DataRow = ds_datos.Tables("dt_detalle").Select("dua <> ''  and reserva <> '' and bodega <> ''", "reserva")
            Dim corre As Integer
            Dim reserva As String = String.Empty

            For jj As Integer = 0 To mNewRow.Length - 1
                Try
                    sb_registro = New StringBuilder

                    If reserva <> mNewRow(jj)("reserva") Then
                        corre = 1
                        reserva = mNewRow(jj)("reserva")
                    End If

                    sb_registro.Append("pa_ins_um_da_reserva  ").Append("'")
                    sb_registro.Append(Now.Date.ToShortDateString).Append("', '")
                    sb_registro.Append(mNewRow(jj)("reserva")).Append("', '")
                    sb_registro.Append(gs_usuario).Append("', '")
                    sb_registro.Append(gs_empresa).Append("', '")
                    sb_registro.Append(mNewRow(jj)("proveedor")).Append("', '")
                    sb_registro.Append(mNewRow(jj)("dua")).Append("', '")
                    sb_registro.Append(mNewRow(jj)("bodega")).Append("', '")
                    sb_registro.Append(mNewRow(jj)("producto")).Append("', '")
                    sb_registro.Append(mNewRow(jj)("descripcion")).Append("', '")
                    sb_registro.Append("BULTOS").Append("', '")
                    sb_registro.Append(cb_bodega.Text).Append("', '")
                    sb_registro.Append(corre).Append("', ")
                    sb_registro.Append(mNewRow(jj)("bultos")).Append(", ")
                    sb_registro.Append(mNewRow(jj)("cantidad")).Append(", 'CREADA'")
                    sb_registro.Append(", '" & no_solicitud & "'")
                    corre += 1
                    Otrans.Ingresa(sb_registro.ToString)

                    sb_registro = New StringBuilder

                    sb_registro.Append("pa_upd_um_da_detalle_solicitud_reserva '")
                    sb_registro.Append(gs_empresa)
                    sb_registro.Append("', '")
                    sb_registro.Append(no_solicitud)
                    sb_registro.Append("', '")
                    sb_registro.Append(reserva)
                    sb_registro.Append("', '")
                    sb_registro.Append(mNewRow(jj)("producto"))
                    sb_registro.Append("'")

                    Otrans.Ingresa(sb_registro.ToString)

                Catch ex As Exception
                    MessageBox.Show("Se produjo el siguiente error: " & ex.Message)
                    Exit Sub
                End Try
            Next

            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            estado = 0
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub dgv_detalle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_detalle.DoubleClick
        idRow = dgv_detalle.CurrentRow.Index

        Dim producto As String = dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value.ToString

        Dim mNewRow() As DataRow = ds_datos.Tables("dt_detalle").Select("producto = '" & producto & "'")

        txt_producto.Text = mNewRow(0)("producto").ToString
        txt_descripcion.Text = mNewRow(0)("descripcion").ToString
        txt_proveedor.Text = mNewRow(0)("proveedor").ToString
        txt_bultos.Text = mNewRow(0)("bultos").ToString
        txt_unidades.Text = mNewRow(0)("cantidad").ToString

        txt_dua.Focus()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If idRow < 0 Then Exit Sub

        Try
            ds_datos.Tables("dt_detalle").Rows(idRow)("dua") = txt_dua.Text
            ds_datos.Tables("dt_detalle").Rows(idRow)("bodega") = cb_bodega.Text
            ds_datos.Tables("dt_detalle").Rows(idRow)("reserva") = txt_reserva.Text

        Catch ex As Exception
            Exit Sub
        End Try

        Dim clGen As New ClasesGenerales.General

        dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
        dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        clGen = Nothing

        limpiar()
    End Sub

    Private Sub dgv_detalle_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_detalle.CellFormatting
        Dim drv As DataRowView

        If e.RowIndex >= 0 Then
            If e.RowIndex <= ds_datos.Tables("dt_detalle").Rows.Count - 1 Then

                drv = ds_datos.Tables("dt_detalle").DefaultView.Item(e.RowIndex)

                If drv.Item("dua").ToString.Trim.Length <= 0 And drv.Item("bodega").ToString.Trim.Length <= 0 Then
                    e.CellStyle.BackColor = Color.Yellow
                Else
                    e.CellStyle.BackColor = Color.White
                End If
            End If
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub txt_reserva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_reserva.LostFocus
        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_reserva.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_da_numero_reserva '" & gs_empresa & "','" & txt_reserva.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 And dt.Rows.Count <= 1 Then
                    MessageBox.Show("La reserva No. " & txt_reserva.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
                    txt_reserva.Text = String.Empty
                    txt_reserva.Focus()
                End If

            Catch ex As Exception
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        End If

    End Sub
End Class