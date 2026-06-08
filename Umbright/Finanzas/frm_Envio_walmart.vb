Imports System.Windows.Forms
Imports System.Collections.ArrayList
Public Class frm_recibos_walmart
    Private numDoctos As Integer
    Private monto As Decimal = 0
    Private clsGen As New ClasesGenerales.General
    Private oTrans As New Transaccional.Conexion("flexline")
    Private sql As String
    Private dt As DataTable
    Dim ods As New DataSet
    Dim totalDeposito, totalIngresado As Double
    Dim DataRowDocumento As DataRow
    'Dim documentosIngresadosMonto As New ArrayList

    Private Sub crearEstructura()
        Dim dt As DataTable

        ods = New DataSet

        dt = New DataTable("facturas")

        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("Control de Transporte", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(String)))


        ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim fechaInicial, fechaFinal, tipodocto, numdocto As String

        fechaInicial = dtpFechaInicial.Text
        fechaFinal = dtpFechaFinal.Text
        Dim envio As String
        envio = txNombreEnvio.Text
        'Se inserta el emcabezado
        sql = "pa_ins_um_documento_envio_walmart_encabezado '" & gs_empresa & "' , '" & envio & "','" & gs_usuario & "'"
        clsGen.insertQuery("flexline", sql)

        For Each drv As DataGridViewRow In dgInfo.Rows

            tipodocto = drv.Cells("tipodocto").Value.ToString
            numdocto = drv.Cells("numero").Value.ToString

            'se inserta el detalle
            sql = "pa_ins_um_documento_envio_walmart_detalle '" & gs_empresa & "' , '" & tipodocto _
                & "','" & numdocto & "'"
            clsGen.insertQuery("flexline", sql)
        Next


        'Se guarda la información en la base de datos
        MessageBox.Show("Se ha guardado la información correctamente", "ÉXITO", MessageBoxButtons.OK)
        dgInfo.DataSource = Nothing
        lblDocumentos.Text = "0"
        monto = 0
        lblTotal.Text = "0.00"
        ods.Tables("facturas").Rows.Clear()
        llenarTablas()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim row As Integer
        row = getSelectedRow(dgInfo)
        Try
            If (MessageBox.Show("Está seguro de eliminar la factura #" & dgInfo.Rows(row).Cells("numero").Value.ToString, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                monto -= Decimal.Parse(dgInfo.Rows(row).Cells("monto").Value.ToString)
                dgInfo.Rows.RemoveAt(row)
            End If
        Catch ex As Exception

        End Try

        Try
            txDiferencia.Text = (totalDeposito - monto).ToString("C")
            If ((totalDeposito - monto) < 0) Then
                txDiferencia.ForeColor = Color.Red
            Else
                txDiferencia.ForeColor = Color.Black
            End If
        Catch
        End Try
        lblTotal.Text = monto.ToString("C")
    End Sub



    Private Sub frm_recibos_canal_moderno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "pa_sel_um_tipodocumento '" & gs_empresa & "'"
        clsGen.fillComboBox(oTrans, sql, "tipodocto", "tipodocto", "tipodocto", cmbTipoDocumentos)
        sql = "pa_sel_um_gen_tabcod null, 'GEN_EMP_RECIBO_MOD', '" & gs_empresa & "'"
        clsGen.fillComboBox(oTrans, sql, "clientes", "codigo", "nemotecnico", cmbCliente)
        crearEstructura()
        llenarTablas()
    End Sub

    Private Sub txNumDocto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNumDocto.KeyPress

        If e.KeyChar = Chr(13) Then
            previewFactura()
            btnAdd.Focus()
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim numDocto, tipodocto, preFace As String
        tipodocto = cmbTipoDocumentos.Text
        preFace = txPreFace.Value.ToString
        numDocto = txNumDocto.Text
        Dim estaAgregada As Boolean = False
        If (tipodocto.Substring(0, 4).Equals("FACE")) Then
            numDocto = preFace & numDocto.PadLeft(10, "0")
        End If

        For Each dgrv As DataGridViewRow In dgInfo.Rows
            If (dgrv.Cells("numero").Value.ToString.Equals(numDocto)) Then
                estaAgregada = True
            End If
        Next
        If Not estaAgregada Then
            buscarFactura()
            calculos()
            txNumDocto.Text = ""
        Else
            MessageBox.Show("La factura que está intentando agregar ya se encuentra en la lista", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        txNumDocto.Focus()
        Try
            txDiferencia.Text = (totalDeposito - monto).ToString("C")
            If ((totalDeposito - monto) < 0) Then
                txDiferencia.ForeColor = Color.Red
            Else
                txDiferencia.ForeColor = Color.Black
            End If
        Catch
        End Try
    End Sub

    Private Sub calculos()
        lblDocumentos.Text = dgInfo.Rows.Count.ToString
        lblTotal.Text = monto.ToString("C")
    End Sub


    Private Sub llenarTablas()
        Try
            Dim dt As New DataTable
            sql = "pa_sel_um_envio_walmart_encabezado"
            dt = clsGen.selectQuery("flexline", sql)
            dgEncabezado.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub
    Private Sub llenarDetalle()

        Try
            Dim row As Integer = getSelectedRow(dgEncabezado)

            Dim dtDetalleLote As DataTable
            If (row >= 0) Then
                sql = "pa_sel_um_envio_walmart_detalle " & dgEncabezado.Rows(row).Cells("CorrelativoEnvio").Value.ToString
                dtDetalleLote = clsGen.selectQuery("flexline", sql)
                dgDetalle.DataSource = dtDetalleLote
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub previewFactura()
        Dim fechaInicial, fechaFinal, tipodocto, preFace, numdocto As String
        fechaInicial = dtpFechaInicial.Text
        fechaFinal = dtpFechaFinal.Text
        tipodocto = cmbTipoDocumentos.Text
        preFace = txPreFace.Value.ToString
        numdocto = txNumDocto.Text
        DataRowDocumento = Nothing
        If (tipodocto.Substring(0, 4).Equals("FACE")) Then
            numdocto = preFace & numdocto.PadLeft(10, "0")
        Else
            numdocto = numdocto.PadLeft(10, "0")
        End If

        sql = "pa_sel_um_documento_recibos '" & gs_empresa & "', '" & tipodocto & "','" & numdocto _
         & "','" & fechaInicial & "','" & fechaFinal & "'"


        Try
            oTrans.open()
            dt = oTrans.Obtiene(sql)
        Catch ex As Exception
        Finally
            oTrans.close()
        End Try
        If (dt.Rows.Count > 0) Then
            'esta bien, solo hay un registro
            If (dt.Rows.Count = 1) Then
                DataRowDocumento = dt.Rows(0)

                Try
                    lblCliente.Text = DataRowDocumento.Item("cliente").ToString
                    lblNum.Text = DataRowDocumento.Item("numero").ToString
                    lblRazon.Text = DataRowDocumento.Item("nombre_cliente").ToString
                    lblTipo.Text = DataRowDocumento.Item("tipodocto").ToString
                    lblMonto.Text = Decimal.Parse(DataRowDocumento.Item("total")).ToString("C")
                    lblEmpresa.Text = DataRowDocumento.Item("empresa").ToString
                Catch ex As Exception

                End Try
            Else
                'hay mas de una factura
                MessageBox.Show("Existe más de una factura con estas características", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            'No hay ninguna factura
            MessageBox.Show("No se encontró la factura seleccionada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub buscarFactura()
        Try


            Dim draux As DataRow ' Nueva Fila
            draux = ods.Tables("facturas").NewRow()
            draux.Item("Empresa") = DataRowDocumento.Item("empresa")
            'draux.Item("Control de Transporte") = ""
            draux.Item("TipoDocto") = DataRowDocumento.Item("tipodocto")
            draux.Item("Numero") = DataRowDocumento.Item("numero")
            draux.Item("Monto") = DataRowDocumento.Item("total")
            draux.Item("Cliente") = DataRowDocumento.Item("cliente")
            draux.Item("RazonSocial") = DataRowDocumento.Item("nombre_cliente")
            monto += Decimal.Parse(DataRowDocumento.Item("total").ToString)
            ods.Tables("facturas").Rows.Add(draux)

            dgInfo.DataSource = ods.Tables("facturas")

        Catch ex As Exception

        Finally
            lblCliente.Text = ""
            lblNum.Text = ""
            lblRazon.Text = ""
            lblTipo.Text = ""
            lblMonto.Text = ""
            lblEmpresa.Text = ""
            DataRowDocumento = Nothing
        End Try

        clsGen.Alinear_GridView(ods.Tables("facturas"), dgInfo, "", "", "", "", True, True, 400, 20)
    End Sub
    Private Function getSelectedRow(ByVal gridview As DataGridView) As Integer
        Try
            Return gridview.SelectedCells(0).RowIndex
        Catch
            Return -1
        End Try
    End Function

    Private Sub cmbTipoDocumentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDocumentos.SelectedIndexChanged
        If (cmbTipoDocumentos.Text.Substring(0, 4).Equals("FACE")) Then
            txPreFace.Value = 14
            txPreFace.Visible = True
        Else
            txPreFace.Value = 0
            txPreFace.Visible = False
        End If
    End Sub


    Private Sub txMontoDeposito_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            lblTotalDeposito.Text = totalDeposito.ToString("C")
            txDiferencia.Text = (totalDeposito - monto).ToString("C")
        End If
    End Sub

    Private Sub dgEncabezado_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEncabezado.CellClick
        llenarDetalle()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim row As Integer = getSelectedRow(dgEncabezado)

        Try


            If (row >= 0) Then
                Dim path_reporte As String
                Dim nombre_reporte As String
                Dim pm_valores(0) As String
                Dim pm_parametros(0) As String
                Dim pm_conexion(3) As String
                Dim ClsGen As New ClasesGenerales.General



                'Obtengo Datos de Conexion
                pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                path_reporte = ClsGen.Path_Reporte


                path_reporte += "Finanzas\Creditos\Jefatura\Documentos Walmart.rpt"

                pm_parametros(0) = "@numEnvio"
                pm_valores(0) = dgEncabezado.Rows(row).Cells("CorrelativoEnvio").Value.ToString

                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                               pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                               False, False, "PDF", True, "", True)
            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub



    Private Sub dgEncabezado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgEncabezado.DataError

    End Sub


    Private Sub dgDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetalle.CellContentClick

    End Sub

    Private Sub dgDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgDetalle.DataError

    End Sub
End Class