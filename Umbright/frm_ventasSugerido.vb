Public Class frm_ventasSugerido

    Dim Ods As DataSet

    Private Sub crearEstructura()
        Ods = New DataSet
        Dim dt As New DataTable("productos")

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("sugerido", GetType(Integer)))

        Ods.Tables.Add(dt.Copy)

        Me.dgvProductos.DataSource = Ods.Tables("productos")
        alinearGrid()


    End Sub

    Private Sub alinearGrid()
        Dim clsGenerales As New ClasesGenerales.General


        clsGenerales.Alinear_GridView(Ods.Tables("productos"), dgvProductos, "", "", ",descripcion,", "", "", "", "", True, True, 250, 0)
        clsGenerales = Nothing

    End Sub

    Private Sub llenarCombos()
        Dim otrans As New Transaccional.Conexion("FlexLineDW")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "pa_sel_um_vsp_colocador"
            dt = otrans.Obtiene(lsSQL)

            Me.cmbColocador.DataSource = dt
            Me.cmbColocador.DisplayMember = "colocador"
            Me.cmbColocador.ValueMember = "colocador"

            lsSQL = "pa_sel_um_vsp_supervisor"
            dt = otrans.Obtiene(lsSQL)

            Me.cmbSupervisor.DataSource = dt
            Me.cmbSupervisor.DisplayMember = "supervisor"
            Me.cmbSupervisor.ValueMember = "supervisor"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub buscarCliente()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            otrans.open()
            lsSQL = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txtCodigoCliente.Text & "'"
            dt = otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.txtRazonSocial.Text = .Item("nombre_cliente").ToString
                    Me.txtVendedor.Text = .Item("ejecutivo").ToString
                    Me.txtDireccion.Text = .Item("direccion").ToString
                End With
            Else
                MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    Private Function buscarProducto(ByVal psCodigoProducto As String) As String
        Dim sDescripcion As String = ""
        Dim lsSQL As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "pa_sel_um_producto '" & gs_empresa & "','" & psCodigoProducto & "'"
            dt = otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                sDescripcion = dt.Rows(0).Item("glosa").ToString
            End If

        Catch ex As Exception
            otrans.close()
            otrans = Nothing

        End Try



        Return sDescripcion


    End Function

    Private Sub guardarInformacion()

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String

        Try
            otrans.open()

            For Each dr As DataRow In Ods.Tables("productos").Rows
                lsSQL = "pa_ins_um_ventassugeridopuntos '" + gs_empresa + "','" + Me.txtCodigoCliente.Text

                lsSQL += "'" + dr.Item("codigo")


            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        'Ods.Tables("SS").Rows.Clear()

    End Sub

    Private Sub frm_ventasSugerido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarCliente()
        End If
    End Sub


    Private Sub dgvProductos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvProductos.Rows(rowIndex)
                'If (",codigo,").IndexOf(Me.dgvProductos.Columns(colIndex).Name.ToLower) > -1 Then
                '    Dim ncantidad As Integer = -99
                '    Dim clickasociar As Boolean = Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("asociar")
                '    'Me.dgv_detalle.Item("valor_sugerido", rowIndex).Value = Me.dgv_detalle.Item("pedido", rowIndex).Value * Me.dgv_detalle.Item("fob", rowIndex).Value

                '    If Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("asociar") Then
                '        If Me.dgvDuas.Item(colIndex, rowIndex).Value = True Then
                '            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, True)
                '        Else
                '            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, 0, False)
                '        End If
                '    End If
                If Me.dgvProductos.Columns(colIndex).Name.ToLower.Equals("codigo") Then

                    'If Me.dgvDuas.Item("cantidad_trasladar", rowIndex).Value > Me.dgvDuas.Item("saldo_cajas", rowIndex).Value Then

                    Me.dgvProductos.Item("descripcion", rowIndex).Value = buscarProducto(Me.dgvProductos.Item("codigo", rowIndex).Value)
                    alinearGrid()
                    'If Me.dgvDuas.Item("asociar", rowIndex).Value = True The
                    'Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, True)
                    'End If
                    'End If

                End If
                'hacerResumen()
                '                    dg_producto_dua.CurrentCell = dg_producto_dua.Item(colIndex, rowIndex)
            End If
            'End If


        Catch ex As Exception
        End Try



    End Sub



    Private Sub dgvProductos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProductos.DataError
        MessageBox.Show("Ingreso Un Valor Invalido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro De Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarInformacion()
        End If

    End Sub
End Class