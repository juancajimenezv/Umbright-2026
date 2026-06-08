Public Class frm_canastas2
    Dim pdt As DataTable

    Public esMovimiento As Boolean = False
    Private Sub frm_canastas2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
    End Sub




    Private Sub crearEstructura()

        pdt = New DataTable("productos")

        pdt.Columns.Add(New DataColumn("empresa_compra", GetType(String)))
        pdt.Columns.Add(New DataColumn("empresa_vende", GetType(String)))
        pdt.Columns.Add(New DataColumn("producto", GetType(String)))
        pdt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        pdt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        pdt.Columns.Add(New DataColumn("numero_traslado", GetType(String)))
        pdt.Columns.Add(New DataColumn("tipo_movimiento", GetType(String)))
        pdt.Columns.Add(New DataColumn("cod_cliente_compra", GetType(String)))

    End Sub

    Private Sub llenarCombos()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General


        Try
            otrans.open()
            lsSQL = "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)

            Me.cmbEmpresaCompra.DataSource = dt
            Me.cmbEmpresaCompra.DisplayMember = "empresa"
            Me.cmbEmpresaCompra.ValueMember = "empresa"

            dt = dt.Copy
            Me.cmbEmpresaVende.DataSource = dt
            Me.cmbEmpresaVende.DisplayMember = "empresa"
            Me.cmbEmpresaVende.ValueMember = "empresa"

            lsSQL = "pa_sel_um_tipodocumento null,NULL"
            dt = otrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "clase = 'Traspaso (i)' or clase = 'Salida (i)' or clase = 'Pedido (c)'"
            dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "tipodocto".Split(","))


            'ldt_table.DefaultView.RowFilter = " tipodocto like '%SALIDA BODEGA CD%'"
            Me.cmbTipoDocto.DisplayMember = "tipoDocto"
            Me.cmbTipoDocto.ValueMember = "tipoDocto"
            Me.cmbTipoDocto.DataSource = dt
            'Me.cmb_empresa.SelectedValue = gs_empresa



        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub agregarFactura()

        Dim ls_Sql As String
        Dim dt As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim drAux As DataRow

        Try
            oTrans.open()

            Me.txtNumero.Text = Me.txtNumero.Text.PadLeft(10, "0")
            ls_Sql = "pa_sel_um_documentod '" & Me.cmbEmpresaCompra.Text & "','" & Me.cmbTipoDocto.Text & "','" & Me.txtNumero.Text & "'"

            If esMovimiento Then ls_Sql = "pa_sel_um_documentod '" & Me.cmbEmpresaVende.Text & "','" & Me.cmbTipoDocto.Text & "','" & Me.txtNumero.Text & "'"


            dt = oTrans.Obtiene(ls_Sql)

            For Each dr As DataRow In dt.Rows
                If dr.Item("cantidad") > 0 Then
                    drAux = pdt.NewRow
                    drAux.Item("empresa_compra") = Me.cmbEmpresaCompra.Text
                    drAux.Item("empresa_vende") = Me.cmbEmpresaVende.Text
                    drAux.Item("producto") = dr.Item("producto")
                    drAux.Item("descripcion") = dr.Item("glosa")
                    drAux.Item("cantidad") = dr.Item("cantidad")
                    drAux.Item("numero_traslado") = Me.txtNumero.Text
                    drAux.Item("tipo_movimiento") = Me.cmbTipoDocto.Text
                    drAux.Item("cod_cliente_compra") = Me.txtCliente.Text

                    pdt.Rows.Add(drAux)
                End If


            Next

            Me.dgvProductos.DataSource = pdt

            Try
                Me.txtUnidades.Text = pdt.Compute("sum(cantidad)", "cantidad>0")
                Me.txtSku.Text = pdt.Rows.Count
            Catch ex As Exception

            End Try

            Me.txtNumero.Text = ""
            Me.txtNumero.Focus()
            clGen.Alinear_GridView(pdt, Me.dgvProductos, "", "", "", "", True, True, 250, 0)
        Catch ex As Exception
            MessageBox.Show("Problemas En Busqueda", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
        End Try



    End Sub


    Private Function guardarTraslado()
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt, dtEmpresa As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            myOtrans.open()
            Otrans.open()
            dtEmpresa = ClsGen.ValoresDistinto(pdt, "empresa_vende,cod_cliente_compra,numero_traslado".Split(","))

            For Each dr As DataRow In dtEmpresa.Rows
                Dim bencabezado As Boolean = True
                numero_pedido = -1
                Dim nlinea As Integer = 0
                pdt.DefaultView.RowFilter = "empresa_vende='" & dr.Item("empresa_vende").ToString & "' and cod_cliente_compra='" & dr.Item("cod_cliente_compra").ToString & "' and numero_traslado = " & dr.Item("numero_traslado")

                For Each drv As DataRowView In pdt.DefaultView
                    If bencabezado Then
                        dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & drv.Item("empresa_vende").ToString & "','CLIENTE','" & drv.Item("cod_cliente_compra").ToString & "'")
                        CodigoCliente = dr.Item("cod_cliente_compra").ToString

                        ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" & _
                                 drv.Item("empresa_vende").ToString.ToUpper & "','" & drv.Item("numero_traslado").ToString & "','" & _
                                 drv.Item("cod_cliente_compra").ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," & _
                                  "0,0,'" & _
                                  Now.ToString("yyyy-MM-dd HH:mm") & "','" & _
                                  Now.ToString("yyyy-MM-dd") & "','"

                        ls_sql += "1900-01-01','"

                        ls_sql += Me.txtComentarios.Text & "','" & _
                                gs_usuario.ToUpper & "',1,'" & _
                                dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" & _
                                Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL)"

                        myOtrans.Ingresa(ls_sql)

                        If myOtrans.Codigo_error = 0 Then
                            dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            numero_pedido = dt.Rows(0).Item("newid").ToString
                            bencabezado = False
                        End If
                    End If

                    If numero_pedido > 0 Then

                        nlinea += 1
                        dt = oFlex.Obtener_Precio_Final(drv.Item("empresa_vende").ToString.ToUpper, drv.Item("producto").ToString, CodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," & _
                                          nlinea & ",'" & drv.Item("producto").ToString & "'," & _
                                          drv.Item("cantidad").ToString & "," & precio_unitario & "," & _
                                          precio_unitario * drv.Item("cantidad") & ")"

                        myOtrans.Ingresa(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            lbExitoso = False
                        End If


                    End If

                Next
                If numero_pedido > 0 Then
                    ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
                    myOtrans.Actualiza(ls_sql)
                    MessageBox.Show("Pedido a " & dr.Item("empresa_vende").ToString.ToUpper & " Generado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If

            Next

            'ods.ReadXml(archivoXML)
        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
            Me.limpiarPantalla()
            

        End Try
        Return lbExitoso
    End Function

    Private Sub limpiarPantalla()
        pdt.Rows.Clear()
        pdt.DefaultView.RowFilter = ""
        Me.cmbEmpresaCompra.Enabled = False
        Me.txtCliente.Text = ""
        Me.txtNombreCliente.Text = ""
        Me.txtComentarios.Text = ""
        Me.dgvProductos.DataSource = Nothing

    End Sub




    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        agregarFactura()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MessageBox.Show("Esta Seguro de Guardar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarTraslado()
        End If


    End Sub

    Private Sub cmbEmpresaCompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresaCompra.SelectedIndexChanged

    End Sub

    Private Sub cmbEmpresaCompra_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresaCompra.SelectionChangeCommitted
        Me.cmbEmpresaCompra.Enabled = False
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Me.limpiarPantalla()
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub


End Class