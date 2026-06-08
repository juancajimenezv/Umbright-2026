Public Class frm_scm_tracking_pedido_tesoreria
    Dim ds1 As DataSet
    Private Sub llenarOCAprobadas()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = ""
            dt = clsGen.selectQuery("SCM", "pa_var_um_inv_pedido_encabezado_tesoreria '" & Me.dtpFechaInicio.Value.ToShortDateString & "','" & Me.dtpFechaFinal.Value.ToShortDateString & "'")
            Me.dgvOrdenes.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvOrdenes, "", ",tasa_cambio,", "", "", "", ",cod_calculo=50,dias_credito=50,", "", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub CrearEstructura()
        Dim dt2 As New DataTable
        ds1 = New DataSet

        dt2.Columns.Add(New DataColumn("Tipo Documento", GetType(String)))
        dt2.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Fecha Vencimiento", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Usuario", GetType(String)))
        dt2.Columns.Add(New DataColumn("Orden", GetType(Integer)))
        ds1.Tables.Add(dt2)


        dt2 = New DataTable("Facturas")
        dt2.Columns.Add(New DataColumn("orden", GetType(String)))
        dt2.Columns.Add(New DataColumn("serie", GetType(String)))
        dt2.Columns.Add(New DataColumn("numero", GetType(String)))
        dt2.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt2.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt2.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt2.Columns("numero").Unique = True
        ds1.Tables.Add(dt2)
    End Sub

    Private Sub frm_scm_tracking_pedido_tesoreria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearEstructura()
        Me.dtpFechaInicio.Value = "01/" & Month(Today) & "/" & Year(Today)
        llenarOCAprobadas()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarOCAprobadas()
    End Sub

    Private Sub btnAsociarOC_Click(sender As Object, e As EventArgs) Handles btnAsociarOC.Click



        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String





        Try
            Dim nRow As Integer = Me.dgvOrdenes.CurrentCell.RowIndex
            Dim dt, dt2 As DataTable

            lsSQL = "pa_var_um_documento_tracking_tesoreria_oc '" & Me.dgvOrdenes.Item("empresa", nRow).Value & "','orden de compra','" & _
                     Me.dgvOrdenes.Item("cod_calculo", nRow).Value & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)



            For Each dr As DataRow In dt.Rows

                dr.Item("fecha_embarque") = "01/01/1900"

                lsSQL = "pa_sel_um_control_historialfechas '" & dr.Item("empresa").ToString & "','" & dr.Item("numero").ToString & "'"
                dt2 = clsGen.selectQuery("FlexLine", lsSQL)

                dt2.DefaultView.RowFilter = "tipodocto like '%fecha embarque%'"
                For Each drv As DataRowView In dt2.DefaultView
                    dr.Item("fecha_embarque") = drv.Item("fechavcto")

                    'Dim draux2 As DataRow

                    'draux2 = ds1.Tables("fechas").NewRow
                    'Dim norden As Integer
                    'draux2.Item("Tipo Documento") = drv.Item("tipodocto")
                    'draux2.Item("Fecha") = drv.Item("fecha")
                    'draux2.Item("Fecha Vencimiento") = drv.Item("fechavcto")
                    'draux2.Item("Usuario") = drv.Item("usuariomodif")
                    ''draux2.Item("orden") = norden
                    'ds1.Tables("fechas").Rows.Add(draux2)

                Next


                lsSQL = "scm..pa_sel_um_oc_documentacion_factura '" & dr.Item("empresa").ToString & "','ORDEN DE COMPRA','" & dr.Item("numero").ToString & "'"
                Dim DTfacturas As DataTable
                DTfacturas = clsGen.selectQuery("SCM", lsSQL)

                For Each drFactura As DataRow In DTfacturas.Rows
                    Dim drAgregar As DataRow
                    drAgregar = ds1.Tables("facturas").NewRow

                    drAgregar.Item("orden") = drFactura.Item("numero")
                    drAgregar.Item("serie") = drFactura.Item("serie_factura")
                    drAgregar.Item("numero") = drFactura.Item("numero_factura")
                    drAgregar.Item("fecha") = drFactura.Item("fecha_factura")
                    drAgregar.Item("monto") = drFactura.Item("monto_factura")
                    drAgregar.Item("moneda") = drFactura.Item("moneda_factura")
                    ds1.Tables("facturas").Rows.Add(drAgregar)

                Next


                'Me.dgvFechas.DataSource = ds1.Tables("fechas")
            Next


            Try

                Me.txtPedido.Text = Me.dgvOrdenes.Item("cod_calculo", nRow).Value
                Me.txtEmpresa.Text = Me.dgvOrdenes.Item("empresa", nRow).Value
                Me.dtpFechaCOPAC.Value = Me.dgvOrdenes.Item("fecha_copac", nRow).Value
                Me.txtRefenciaCopac.Text = Me.dgvOrdenes.Item("nombre_calculo", nRow).Value
                Me.dtpFechaAprueba.Value = Me.dgvOrdenes.Item("fecha_aprobo", nRow).Value
                Me.txtBUMAprueba.Text = Me.dgvOrdenes.Item("bum_aprobo", nRow).Value

                Me.txtSocio.Text = Me.dgvOrdenes.Item("proveedor_contable", nRow).Value
                Me.txtOrigen.Text = Me.dgvOrdenes.Item("origen", nRow).Value
                Me.dtpFechaDespachoInicial.Value = Me.dgvOrdenes.Item("fecha_despacho", nRow).Value
                Me.txtDiasCredito.Text = Me.dgvOrdenes.Item("dias_credito", nRow).Value
                Me.dtpFechaPagoInicial.Value = Me.dgvOrdenes.Item("fecha_pago", nRow).Value

                Me.txtMoneda.Text = Me.dgvOrdenes.Item("moneda", nRow).Value
                Me.txtMontoMoneda.Text = Double.Parse(Me.dgvOrdenes.Item("monto_aprobado", nRow).Value.ToString).ToString("n")
                Me.txtMontoQ.Text = Double.Parse(Me.dgvOrdenes.Item("monto_moneda_gtq", nRow).Value.ToString).ToString("n")


            Catch ex As Exception

            End Try


            'Dim oform As New frm_resultado
            'oform.dgv_resultado.DataSource = dt
            'clsGen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", True, True, 250, 0)
            'oform.ShowDialog()
            'oform.Dispose()
            'oform = Nothing
            Me.TabControl1.SelectedTab = Me.TabPage2
            Me.dgvOC.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvOC, "", "", "", "", ",fecha_embarque=fecha_despacho_(embarque),", "", "", True, True, 250, 0)

            Me.dgvFacturas.DataSource = ds1.Tables("facturas")
            clsGen.Alinear_GridView(ds1.Tables("facturas"), Me.dgvFacturas, "", "", "", "", "", "", "", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub

   
    Private Sub txtMontoMoneda_TextChanged(sender As Object, e As EventArgs) Handles txtMontoMoneda.TextChanged

    End Sub
End Class