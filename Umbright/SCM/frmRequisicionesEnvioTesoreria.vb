Public Class frmRequisicionesEnvioTesoreria

    Dim ods As New DataSet
    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "empresas"
            Ods.Tables.Add(dt.Copy)


            Me.cmbEmpresa.DataSource = dt
            Me.cmbEmpresa.ValueMember = "EMPRESA"
            Me.cmbEmpresa.DisplayMember = "EMPRESA"


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub crearEstructura()
        Dim dt As DataTable

        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))

        ods.Tables.Add(dt.Copy)

        Me.dgvDetalle.DataSource = ods.Tables("detalle")
    End Sub

    Private Sub buscarRequisicion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_requisicion '" & Me.cmbEmpresa.SelectedValue & "','" & Me.txtNumeroRequisicion.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("estado") = 90 Then
                    Me.txtCodigoProveedor.Text = dt.Rows(0).Item("proveedor").ToString
                    Me.txtNombreProveedor.Text = dt.Rows(0).Item("razonSocial").ToString
                    Me.txtTotal.Text = dt.Rows(0).Item("totalDetalle").ToString
                    Me.btnAgregar.Focus()
                Else
                    MessageBox.Show("La Orden de Compra No Esta En Tesoreria", "Verificacion", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("No Existe Orden de Compra", "Verificacion", MessageBoxButtons.OK)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub limpiarLinea()
        Me.txtNumeroRequisicion.Text = String.Empty
        Me.txtCodigoProveedor.Text = String.Empty
        Me.txtNombreProveedor.Text = String.Empty
    End Sub

    Private Sub alinearGrid()
        Dim clsgen As New ClasesGenerales.General
        clsgen.Alinear_GridView(ods.Tables("detalle"), Me.dgvDetalle, "", "", "", "", "", "", "", True, True, 250, 0)
        clsgen = Nothing
    End Sub
    Private Sub agregarLinea()

        Dim dr As DataRow

        Try
            ods.Tables("detalle").DefaultView.RowFilter = "empresa = '" & Me.cmbEmpresa.SelectedValue & "' and numero = '" & Me.txtNumeroRequisicion.Text & "'"

            If ods.Tables("detalle").DefaultView.Count = 0 Then
                dr = ods.Tables("detalle").NewRow
                dr.Item("empresa") = Me.cmbEmpresa.SelectedValue
                dr.Item("numero") = Me.txtNumeroRequisicion.Text
                dr.Item("proveedor") = Me.txtCodigoProveedor.Text
                dr.Item("razonSocial") = Me.txtNombreProveedor.Text
                dr.Item("total") = Me.txtTotal.Text
                ods.Tables("detalle").Rows.Add(dr)
                limpiarLinea()
                alinearGrid()
                Me.txtNumeroRequisicion.Focus()
            End If
        Catch ex As Exception
        Finally
            ods.Tables("detalle").DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub GuardarEnvio()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = "pa_var_um_requisicion_envio_Tesoreria_numero"
            dt = Otrans.Obtiene(lsSQL)
            Me.lblNumero.Text = dt.Rows(0).Item("numero")

            lsSQL = "pa_ins_um_requisicionenvioTesoreria '" & Me.lblNumero.Text & "','" & Me.DateTimePicker1.Value & "','" & gs_usuario & "'"
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error = 0 Then
                For Each dr As DataRow In ods.Tables("detalle").Rows
                    lsSQL = "pa_upd_um_requisicion_estado '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "',80" & ",'Envio Numero " & Me.lblNumero.Text & "'"
                    Otrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_requisicion_envio '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & Me.lblNumero.Text & "'"
                    Otrans.Actualiza(lsSQL)
                Next

                MessageBox.Show("Envio Generado " & Me.lblNumero.Text, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                enviarReporte()
            Else
                MessageBox.Show(Otrans.descripcion_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub enviarReporte()

        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim sNombreReporte As String = String.Empty

        Try
            sNombreReporte = "envio OC a Tesoreria"


            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\" & sNombreReporte & "_" & gs_empresa & "_" & Me.lblNumero.Text & ".pdf"

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\Requisiciones\" & sNombreReporte & ".rpt"
            pm_parametros(0) = "@PNumeroLote"
            pm_valores(0) = Me.lblNumero.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", False, False, "PDF", True)

        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try


    End Sub

    Private Sub agregarLote()
        Dim dr As DataRow
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()

            lsSQL = "pa_var_um_requisicion_envio " & Me.txtLoteCreditos.Text
            dt = Otrans.Obtiene(lsSQL)
            For Each drAux As DataRow In dt.Rows
                If drAux.Item("estado") = 90 Then
                    ods.Tables("detalle").DefaultView.RowFilter = "empresa = '" & drAux.Item("empresa") & "' and numero = '" & drAux.Item("numero") & "'"
                    If ods.Tables("detalle").DefaultView.Count = 0 Then
                        dr = ods.Tables("detalle").NewRow
                        dr.Item("empresa") = drAux.Item("empresa")
                        dr.Item("numero") = drAux.Item("numero")
                        dr.Item("proveedor") = drAux.Item("proveedor")
                        dr.Item("razonSocial") = drAux.Item("razonSocial")
                        dr.Item("total") = drAux.Item("totalDetalle")
                        ods.Tables("detalle").Rows.Add(dr)
                    End If
                End If
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ods.Tables("detalle").DefaultView.RowFilter = ""
            alinearGrid()
        End Try
    End Sub

    Private Sub frmRequisicionesEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
    End Sub

    Private Sub txtNumeroRequisicion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroRequisicion.GotFocus
        limpiarLinea()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroRequisicion.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.txtNumeroRequisicion.Text = Me.txtNumeroRequisicion.Text.PadLeft(10, "0")
            buscarRequisicion()
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedValueChanged
        limpiarLinea()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.txtNombreProveedor.Text.Length > 0 Then
            agregarLinea()
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            guardarEnvio()
        End If
    End Sub


    Private Sub btnAgregarLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click

        agregarLote()

    End Sub

    Private Sub txtNumeroRequisicion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroRequisicion.TextChanged

    End Sub
End Class