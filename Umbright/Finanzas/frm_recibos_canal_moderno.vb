Imports System.Windows.Forms
Public Class frm_recibos_canal_moderno
    Private numDoctos As Integer
    Private monto As Decimal = 0
    'Private clsGen As New ClasesGenerales.General
    'Private oTrans As New Transaccional.Conexion("flexline")
    Private sql As String
    Private dt As DataTable
    Dim ods As New DataSet
    Dim DataRowDocumento As DataRow
    'Dim gs_empresa As String = "DMARTE1"

    Private Sub crearEstructura()
        Dim dt As DataTable

        ods = New DataSet

        dt = New DataTable("facturas")

        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("Control de Transporte", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(String)))
        dt.Columns.Add(New DataColumn("MontoAplicar", GetType(Double)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))


        ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim clsGen As New ClasesGenerales.General
        Try


            If (txDeposito.Text.Length > 0 And txMontoDeposito.Text.Length > 0) Then
                If Val(Me.txMontoDeposito.Text) = Val(Me.lblTotal.Text) Then

                    If Me.btnGuardar.Text = "Guardar" Then
                        Me.btnGuardar.Text = "Actualizar"

                        Dim fechaInicial, fechaFinal, tipodocto, numdocto As String


                        'Grabar el encabezado

                        Try
                            sql = "pa_ins_um_enc_walmart '" & gs_empresa & "'," & Me.txtNumeroRecibo.Text & ",'" & Me.txDeposito.Text & "','" &
                                Me.dtpFechaRecibo.Value.ToString("dd/MM/yyyy") & "'," &
                                Me.lblTotal.Text & ",'" & gs_usuario & "'"
                            clsGen.insertQuery("SCM", sql)

                        Catch ex As Exception
                        End Try

                        For Each dr As DataRow In ods.Tables("facturas").Rows
                            sql = "pa_ins_um_con_mov_walmart '" & gs_empresa & "','" & Me.dtpFechaRecibo.Text & "'," & Me.txtNumeroRecibo.Text & ",'" &
                        dr.Item("tipoDocto") & "','" & dr.Item("numero") & "'," & dr.Item("MontoAplicar") & "," & dr.Item("MontoAplicar") & ",'" &
                        dr.Item("glosa").ToString & "','" & dr.Item("cliente").ToString & "','" & dr.Item("proveedor") & "'"


                            clsGen.insertQuery("SCM", sql)
                        Next


                        'Se guarda la información en la base de datos
                        MessageBox.Show("Se ha guardado la información correctamente", "ÉXITO", MessageBoxButtons.OK)
                        dgInfo.DataSource = Nothing
                        lblDocumentos.Text = "0"
                        monto = 0
                        lblTotal.Text = "0.000000"
                        ods.Tables("facturas").Rows.Clear()

                    End If
                Else

                        Try
                        ods.Tables("facturas").WriteXml("c:\temp\recibo_" & Me.txtNumeroRecibo.Text & ".xml", XmlWriteMode.WriteSchema)
                    Catch ex As Exception

                    End Try

                    MessageBox.Show("Existen Diferencias Entre el Monto del Deposito y El Total Ingreso", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If 'Val(Me.txMontoDeposito.Text) = Val(Me.lblTotal.Text)
            Else
                MessageBox.Show("Ingrese el número y monto del depósito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            clsGen = Nothing
        End Try

    End Sub

    Private Sub llenarSaldos()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General



        Try
            lsSQL = "sp_Balance_Walmart '" & gs_empresa & "','" & Today & "','" & cmbCliente.Text & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)

            If ods.Tables.Contains("saldos") Then
                ods.Tables.Remove("saldos")
            End If
            dt.TableName = "saldos"
            ods.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub Totalizar()
        Dim ntotal As Double

        Try
            ntotal = ods.Tables("facturas").Compute("sum(MontoAplicar)", "MontoAplicar<>0")
            Me.lblTotal.Text = Format(ntotal, "###,###,##0.000000")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenarGrid()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_con_enc_walmart"
            dt = clsGen.selectQuery("scm", lsSQL)
            Me.DataGridView1.DataSource = dt

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub frm_recibos_canal_moderno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        txPreFace.Text = Now.ToString("yy")

        Try

            sql = "pa_sel_um_tipodocumento_walmart '" & gs_empresa & "'"
            clsGen.fillComboBox(oTrans, sql, "tipodocto", "tipoDocto", "tipoDocto", cmbTipoDocumentos)

            sql = "pa_sel_um_gen_tabcod null, 'GEN_EMP_RECIBO_MOD', '" & gs_empresa & "'"

            clsGen.fillComboBox(Otrans, sql, "clientes", "codigo", "nemotecnico", cmbCliente)
            crearEstructura()
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub txNumDocto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNumDocto.KeyPress, txtNumeroRecibo.KeyPress

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

        If tipodocto.Substring(0, 3).Equals("FEL") Then
            numDocto = numDocto.PadLeft(10, "0")
            '--------------------------------------

        ElseIf (tipodocto.Substring(0, 4).Equals("FACE")) Then
            numDocto = preFace & numDocto.PadLeft(10, "0")
        ElseIf tipodocto.Substring(0, 4).Equals("NCE-") Then
            numDocto = preFace & numDocto.PadLeft(12, "0")
        Else
            numDocto = numDocto.PadLeft(10, "0")
        End If

        For Each dgrv As DataGridViewRow In dgInfo.Rows
            If (dgrv.Cells("numero").Value.ToString.Equals(numDocto) And dgrv.Cells("TipoDocto").Value.ToString.Equals(tipodocto)) Then
                estaAgregada = True
            End If
        Next

        'If Val(Me.txtSaldo.Text) >= Val(Me.txtMontoAplicar.Text) And Val(txtMontoAplicar.Text) > 0 Then
        If Val(txtMontoAplicar.Text) > 0 Then

            If Not estaAgregada Then
                buscarFactura()
                calculos()
                txNumDocto.Text = ""
                Me.txtCodigoCliente.Text = String.Empty
                Me.txtNombreCliente.Text = String.Empty
                Me.txtTipoDocto.Text = String.Empty
                Me.txtNumero.Text = String.Empty
                Me.txtMonto.Text = String.Empty
                Me.txtMontoAplicar.Text = String.Empty
                Me.txtSaldo.Text = String.Empty
            Else
                MessageBox.Show("La factura que está intentando agregar ya se encuentra en la lista", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf Val(txtMontoAplicar.Text) Then
            MessageBox.Show("El Monto que aplica no debe ser mayor al Saldo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("El Monto que aplica no puede ser Mayor que el Saldo del Documento", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        txNumDocto.Focus()
    End Sub

    Private Sub calculos()

        lblDocumentos.Text = dgInfo.Rows.Count.ToString
        lblTotal.Text = monto.ToString("F")
        Totalizar()

    End Sub

    Private Sub previewFactura()
        Dim fechaInicial, fechaFinal, tipodocto, preFace, numdocto As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try

            tipodocto = cmbTipoDocumentos.Text
            preFace = txPreFace.Value.ToString
            numdocto = txNumDocto.Text
            DataRowDocumento = Nothing


            '   ACTUALIZACION POR FEL
            '--------------------------------------

            If tipodocto.Substring(0, 3).Equals("FEL") Then
                numdocto = numdocto.PadLeft(10, "0")
                '--------------------------------------
            ElseIf (tipodocto.Substring(0, 4).Equals("FACE")) Then
                numdocto = preFace & numdocto.PadLeft(10, "0")
                ElseIf tipodocto.Substring(0, 4).Equals("NCE-") Then
                    numdocto = numdocto.PadLeft(12, "0")
                Else
                    numdocto = numdocto.PadLeft(10, "0")
            End If

            sql = "pa_sel_um_documento_recibos '" & gs_empresa & "', '" & tipodocto & "','" & numdocto & "'"
            '& "','" & fechaInicial & "','" & fechaFinal & "'"

            Try
                Otrans.open()
                dt = Otrans.Obtiene(sql)
            Catch ex As Exception
            Finally
                'oTrans.close()
            End Try

            If (dt.Rows.Count > 0) Then
                'esta bien, solo hay un registro
                If (dt.Rows.Count = 1) Then
                    DataRowDocumento = dt.Rows(0)
                    Dim dsaldos As Double = 0.0
                    Try
                        Me.txtCodigoCliente.Text = DataRowDocumento.Item("cliente")
                        Me.txtNombreCliente.Text = DataRowDocumento.Item("nombre_cliente").ToString
                        Me.txtTipoDocto.Text = DataRowDocumento.Item("tipodocto")
                        Me.txtNumero.Text = DataRowDocumento.Item("numero")
                        Me.txtMonto.Text = Decimal.Parse(DataRowDocumento.Item("total")) '.ToString("F")
                        'DataRowDocumento.Item("tipodocto")
                        Try
                            ods.Tables("saldos").DefaultView.RowFilter = "Tipo_Documento = '" & DataRowDocumento.Item("tipodocto") & "' and Referencia = '" & numdocto & "'"
                            If ods.Tables("saldos").DefaultView.Count > 0 Then
                                dsaldos = ods.Tables("saldos").Compute("sum(saldo)", "Referencia = '" & numdocto & "'")
                            Else
                                dsaldos = 0
                            End If
                        Catch ex As Exception

                        End Try

                    Catch ex As Exception

                    Finally
                        Me.txtSaldo.Text = Format(dsaldos, "######0.00")
                        Me.txtMontoAplicar.Text = Format(dsaldos, "######0.00")

                    End Try
                Else
                    'hay mas de una factura
                    MessageBox.Show("Existe más de una factura con estas características", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                'No hay ninguna factura
                MessageBox.Show("No se encontró la factura seleccionada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub AgregarDebito()

        Dim clsGen As New ClasesGenerales.General
        Try

            Dim draux As DataRow ' Nueva Fila
            draux = ods.Tables("facturas").NewRow()
            draux.Item("Empresa") = gs_empresa ' DataRowDocumento.Item("empresa")
            'draux.Item("Control de Transporte") = ""
            draux.Item("TipoDocto") = "ND_WALMART" 'DataRowDocumento.Item("tipodocto")
            draux.Item("Numero") = Me.txtNumeroReferencia.Text 'Me.txtNumerorDataRowDocumento.Item("numero")
            draux.Item("Monto") = Me.txtValorReferencia.Text 'DataRowDocumento.Item("total")
            draux.Item("Cliente") = "" 'DataRowDocumento.Item("cliente")
            draux.Item("RazonSocial") = "" 'DataRowDocumento.Item("nombre_cliente")
            draux.Item("Proveedor") = "737810" 'Proveedor Walmart
            draux.Item("MontoAplicar") = Me.txtValorReferencia.Text * -1
            draux.Item("glosa") = Me.txtObservacionesReferencia.Text
            'monto += DataRowDocumento.Item("total")
            ods.Tables("facturas").Rows.Add(draux)

            dgInfo.DataSource = ods.Tables("facturas")

            clsGen.Alinear_GridView(ods.Tables("facturas"), dgInfo, "", "", "", "", True, True, 400, 20)

        Catch ex As Exception
        Finally
            Totalizar()

            lblCliente.Text = ""
            lblNum.Text = ""
            lblRazon.Text = ""
            lblTipo.Text = ""
            lblMonto.Text = ""
            lblEmpresa.Text = ""
            DataRowDocumento = Nothing
            clsGen = Nothing
        End Try

    End Sub


    Private Sub buscarFactura()

        Dim clsgen As New ClasesGenerales.General


        Try

            If (DataRowDocumento.Item("nit").Equals(cmbCliente.SelectedValue.ToString)) Then
                Dim draux As DataRow ' Nueva Fila
                draux = ods.Tables("facturas").NewRow()
                draux.Item("Empresa") = DataRowDocumento.Item("empresa")
                'draux.Item("Control de Transporte") = ""
                draux.Item("TipoDocto") = DataRowDocumento.Item("tipodocto")
                draux.Item("Numero") = DataRowDocumento.Item("numero")
                draux.Item("Monto") = DataRowDocumento.Item("total")
                draux.Item("Cliente") = DataRowDocumento.Item("cliente")
                draux.Item("RazonSocial") = DataRowDocumento.Item("nombre_cliente")
                draux.Item("proveedor") = DataRowDocumento.Item("proveedor")
                draux.Item("MontoAplicar") = Me.txtMontoAplicar.Text
                If draux.Item("cliente").ToString.Length = 0 Then draux.Item("MontoAplicar") = draux.Item("MontoAplicar") * -1
                monto += DataRowDocumento.Item("total")
                ods.Tables("facturas").Rows.Add(draux)

                dgInfo.DataSource = ods.Tables("facturas")
            Else
                MessageBox.Show("El cliente seleccionado no corresponde con el de la factura", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            clsgen.Alinear_GridView(ods.Tables("facturas"), dgInfo, "", "", "", "", True, True, 400, 20)
        Catch ex As Exception

        Finally
            lblCliente.Text = ""
            lblNum.Text = ""
            lblRazon.Text = ""
            lblTipo.Text = ""
            lblMonto.Text = ""
            lblEmpresa.Text = ""
            DataRowDocumento = Nothing
            clsgen = Nothing
        End Try


    End Sub
    Private Function getSelectedRow(ByVal gridview As DataGridView) As Integer
        Try
            Return gridview.SelectedCells(0).RowIndex
        Catch
            Return -1
        End Try
    End Function

    Private Sub cmbTipoDocumentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDocumentos.SelectedIndexChanged
        '   ACTUALIZACION POR FEL
        '--------------------------------------

        If (cmbTipoDocumentos.Text.Substring(0, 3).Equals("FEL")) Then
            txPreFace.Value = 0
            txPreFace.Visible = False
            '--------------------------------------

        ElseIf (cmbTipoDocumentos.Text.Substring(0, 4).Equals("FACE")) Then
            'txPreFace.Value = 14
            txPreFace.Visible = True
        Else
            txPreFace.Value = 0
            txPreFace.Visible = False
        End If
    End Sub

    
    Private Sub txNumDocto_TextChanged(sender As Object, e As EventArgs) Handles txNumDocto.TextChanged, txtNumeroRecibo.TextChanged

    End Sub

    Private Sub txtSaldo_TextChanged(sender As Object, e As EventArgs) Handles txtSaldo.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub btnAgregarReferencia_Click(sender As Object, e As EventArgs) Handles btnAgregarReferencia.Click
        Me.AgregarDebito()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        llenarSaldos()
        Me.btnGuardar.Text = "Guardar"
    End Sub

    Private Sub dgInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInfo.CellContentClick

    End Sub

    Private Sub dgInfo_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgInfo.RowsRemoved
        llenarSaldos()
    End Sub

    Private Sub dgInfo_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgInfo.UserDeletedRow
        llenarSaldos()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        llenarGrid()
    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        If MsgBox("Seguro de Actualizar a Contabilidad?", MsgBoxStyle.YesNo, "Actualizar") = MsgBoxResult.Yes Then
            Actualizar()
        End If
    End Sub

    Private Sub Actualizar()
        Dim oform As New Frm_Recibos_Canal_Moderno_Actualizar
        oform.ShowDialog()
    End Sub


End Class