Public Class frm_OCFacturas
    Dim dtFacturas As DataTable

    Private Sub crearEstructura()
        dtFacturas = New DataTable

        dtFacturas.Columns.Add(New DataColumn("serie", GetType(String)))
        dtFacturas.Columns.Add(New DataColumn("numero", GetType(String)))
        dtFacturas.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dtFacturas.Columns.Add(New DataColumn("monto", GetType(Double)))
        dtFacturas.Columns.Add(New DataColumn("moneda", GetType(String)))
        dtFacturas.Columns("numero").Unique = True

        Me.DataGridView1.DataSource = dtFacturas
    End Sub

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()
            clsGen.fillComboBox(Otrans, "pa_sel_um_gen_tabcod null,'gen_moneda','" & gs_empresa & "'", "moneda", "CODIGO", "CODIGO", Me.cmbMoneda)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub guardarInformacion()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable

        Try
            Otrans.open()
            For Each dr As DataRow In dtFacturas.Rows
                lsSQL = "pa_ins_um_oc_documentacion_factura '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtOrden.Text & "','" &
                    dr.Item("serie") & "','" & dr.Item("numero") & "','" & dr.Item("fecha") & "'," & dr.Item("monto") & ",'" &
                    dr.Item("moneda") & "','" & gs_usuario & "'"

                Otrans.Ingresa(lsSQL)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show(Otrans.descripcion_error)
                End If
            Next


            ''Debo Actualizar el Pedido
            dt = Otrans.Obtiene("BDflexline..pa_var_um_documento '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtOrden.Text & "'")
            If dt.Rows.Count > 0 Then
                lsSQL = "pa_upd_um_inv_pedido_encabezado_tesoreria_estado " & dt.Rows(0).Item("ReferenciaExterna") & ",50,'" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)
            End If

            MessageBox.Show("Informacion Ingresada Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub llenarInformacion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_oc_documentacion_factura '" & gs_empresa & "','ORDEN DE COMPRA','" & Me.txtOrden.Text & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)


            Me.DataGridView1.DataSource = dt
            clsGen.Alinear_GridView(dt, DataGridView1, "", "", "", "", True, True, 100, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub limpiarLinea()
        Me.txtNumero.Text = String.Empty
        Me.txtSerie.Text = String.Empty
        Me.txtMonto.Text = String.Empty

    End Sub

    Private Sub frm_OCFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
        llenarInformacion()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            guardarInformacion()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dr As DataRow
        Dim clsGen As New ClasesGenerales.General
        Try

            dr = dtFacturas.NewRow

            dr.Item("serie") = Me.txtSerie.Text
            dr.Item("numero") = Me.txtNumero.Text
            dr.Item("fecha") = Me.dtpFecha.Value
            dr.Item("monto") = Me.txtMonto.Text
            dr.Item("moneda") = Me.cmbMoneda.SelectedValue


            dtFacturas.Rows.Add(dr)
            clsGen.Alinear_GridView(dtFacturas, Me.DataGridView1, "", "", "", "", "", "", "", True, True, 200, 0)
            limpiarLinea()
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub
End Class