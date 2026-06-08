Public Class frm_int_listado
    Dim ds_internaciones As New DataSet

    Private Sub Llenar_Combos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim clsgen As New ClasesGenerales.General

        Try
            otrans.open()
            ls_sql = "pa_sel_um_v_pg_estados 1"
            dt = otrans.Obtiene(ls_sql)
            Me.cmb_estados.DataSource = dt
            Me.cmb_estados.ValueMember = "cod_estado"
            Me.cmb_estados.DisplayMember = "estado"
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_Internaciones_pendientes()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim dr As DataRow

        Dim clsgen As New ClasesGenerales.General
        Dim clsDias As New ClasesGenerales.DiasHabiles

        Try
            otrans.open()

            If ds_internaciones.Tables.IndexOf("internaciones_pendientes") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_pendientes")
            End If

            If ds_internaciones.Tables.IndexOf("internaciones_detalle") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_detalle")
            End If

            If ds_internaciones.Tables.IndexOf("internaciones_dua") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_dua")
            End If

            ls_sql = "pa_var_um_int_pedido_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_pendientes"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_internaciones.DataSource = ds_internaciones.Tables("internaciones_pendientes")

            ls_sql = "pa_sel_um_int_pedido_detalle_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_detalle"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_detalle.DataSource = ds_internaciones.Tables("internaciones_detalle")

            ls_sql = "pa_sel_um_int_pedido_detalle_dua_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_dua"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_detalle_dua.DataSource = ds_internaciones.Tables("internaciones_dua")

            For Each dr In ds_internaciones.Tables("internaciones_pendientes").Rows
                dr.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(dr.Item("fecha").ToString), Today).ToString
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds_internaciones.Tables.Contains("internaciones_pendientes") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_pendientes"), dg_internaciones, "", ",estado,", "", "", "", ",cod_pedido=30,", "", True, True, 200, 0)
        If ds_internaciones.Tables.Contains("internaciones_detalle") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=40,cantidad=40,", "", True, True, 200, 0)
        If ds_internaciones.Tables.Contains("internaciones_dua") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_dua"), dg_detalle_dua, "", "", "", "", "", ",cod_pedido=40,dua=80,", "", True, True, 200, 0)
        clsgen = Nothing
    End Sub

    Private Sub Actualizar_Estado(ByVal npedido As Integer, ByVal nestado As Integer)
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr As DataRow


        Try
            otrans.open()
            'Verificamos que este en el mismo estado
            ls_sql = "pa_var_um_int_pedido_pendientes " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)
            dr = dt.Rows(0)
            If Me.cmb_estados.SelectedValue < Int32.Parse(dr.Item("estado").ToString) Or _
                Me.cmb_estados.SelectedValue > Int32.Parse(dr.Item("estado").ToString) + 1 Or _
                Me.cmb_estados.SelectedValue = Int32.Parse(dr.Item("estado").ToString) Then

                MessageBox.Show("No Puede Asignar Estado " & Me.cmb_estados.Text & " A este Pedido")
            Else
                ls_sql = "pa_ins_um_int_pedido_estado " & npedido.ToString & "," & Me.cmb_estados.SelectedValue & ",'" & _
                        gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
                If otrans.Ingresa(ls_sql) Then
                    MessageBox.Show("Actualizacion Exitosa !!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Llenar_Internaciones_pendientes()
                End If
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Editar_Detalle_Pedido_Dua(ByVal npedido As Integer, ByVal snombre As String)

        Dim ls_sql As String
        Dim oform As New frm_int_asociar_solicitud
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As New DataTable

        Try
            otrans.open()
            ls_sql = "pa_var_um_int_pedido_detalle_dua " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


        oform.pdt = dt
        oform.txt_numero.Text = npedido
        oform.txt_nombre.Text = snombre
        oform.btn_Guardar.Text = "Modificar"
        oform.txt_nombre.ReadOnly = True
        oform.lbl_daiv.Visible = False
        oform.lbl_iva.Visible = False

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    'Mostrar los productos en los diferentes grids
    Private Sub Mostrar_Productos()

        Dim nrow, npedido As Integer

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            ds_internaciones.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & npedido
            ds_internaciones.Tables("internaciones_dua").DefaultView.RowFilter = "cod_pedido = " & npedido
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Exportar_Pedido()
        Dim nrow, npedido As Integer
        Dim ls_sql As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim Oaut As New Automatizar.exportar_excel

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            otrans.open()
            ls_sql = "pa_var_um_int_pedido_detalle_dua " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)


            Oaut.nAgregar_Filas = 2
            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}}
            Oaut.ocultar_columnas = ",proveedor,agregar,"
            Oaut.Nombre_Columnas = ",,,Traslado CJ"
            Oaut.sEncabezado = "Solicitud de Traslado del DA"
            Oaut.sTitulo = "Solicitud No. " & npedido.ToString
            Oaut.DataTableToExcel(dt)
            Oaut = Nothing




        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Imprimir_Pedido()

        Dim path_reporte As String
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String
        Dim nrow, npedido As Integer

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Compras e Importaciones\pedido_internaciones.rpt"
            pm_parametros(0) = "@Pcod_pedido"
            pm_valores(0) = npedido

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "DATASERVER", "BDflexline", "flexline", "flexline", False, True, "PDF", False, "", True)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub frm_int_listado_internaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Internaciones_pendientes()
        Mostrar_Productos()
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click

        Dim nrow, npedido, nestado As Integer

        nrow = Me.dg_internaciones.CurrentCell.RowIndex
        npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString
        nestado = Me.dg_internaciones.Item(4, nrow).Value.ToString

        If MessageBox.Show("Esta Seguro de Cambiar Estado a Pedido No. " & npedido.ToString, "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Actualizar_Estado(npedido, nestado)
        End If
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click

        Dim nrow, npedido, nestado As Integer
        Dim snombre As String

        nrow = Me.dg_internaciones.CurrentCell.RowIndex
        npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString
        nestado = Me.dg_internaciones.Item(4, nrow).Value.ToString
        snombre = Me.dg_internaciones.Item(3, nrow).Value.ToString

        If nestado > 0 Then
            MessageBox.Show("Este Pedido No Se Puede Editar Por que Ya fue Aprobado en el DA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.Editar_Detalle_Pedido_Dua(npedido, snombre)
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar_Pedido()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        'Imprimir_Pedido()
        Dim oform As New Frm_generador_xml
        oform.Show()
    End Sub

    Private Sub dg_internaciones_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_internaciones.CurrentCellChanged
        Mostrar_Productos()
    End Sub
End Class