Public Class frmRequisicionesEnvio

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
                If dt.Rows(0).Item("estado") = 70 Then
                    Me.txtCodigoProveedor.Text = dt.Rows(0).Item("proveedor").ToString
                    Me.txtNombreProveedor.Text = dt.Rows(0).Item("razonSocial").ToString
                    Me.btnAgregar.Enabled = True
                    Me.btnAgregar.Focus()

                ElseIf dt.Rows(0).Item("estado") = 910 And dt.Rows(0).Item("glosa").ToString.Length > 0 Then
                    If MessageBox.Show("Ya fue Corregido " & dt.Rows(0).Item("glosa").ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.txtCodigoProveedor.Text = dt.Rows(0).Item("proveedor").ToString
                        Me.txtNombreProveedor.Text = dt.Rows(0).Item("razonSocial").ToString
                        Me.lblReenvio.Visible = True
                        Me.btnAgregar.Enabled = True
                        Me.btnAgregar.Focus()
                    End If
                Else
                    MessageBox.Show("La Orden de Compra No Tiene Factura Asignada", "Verificacion", MessageBoxButtons.OK)
                    Me.btnAgregar.Enabled = False
                End If
            Else
                MessageBox.Show("No Existe Orden de Compra", "Verificacion", MessageBoxButtons.OK)
                Me.btnAgregar.Enabled = False
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
            dr = ods.Tables("detalle").NewRow
            dr.Item("empresa") = Me.cmbEmpresa.SelectedValue
            dr.Item("numero") = Me.txtNumeroRequisicion.Text
            dr.Item("proveedor") = Me.txtCodigoProveedor.Text
            dr.Item("razonSocial") = Me.txtNombreProveedor.Text
            ods.Tables("detalle").Rows.Add(dr)
            limpiarLinea()
            alinearGrid()
            Me.txtNumeroRequisicion.Focus()
        Catch ex As Exception
        Finally
            Me.lblReenvio.Visible = False
        End Try



    End Sub

    Private Sub GuardarEnvio()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = "pa_var_um_requisicion_numero"
            dt = Otrans.Obtiene(lsSQL)
            Me.lblNumero.Text = dt.Rows(0).Item("numero")

            lsSQL = "pa_ins_um_requisicionenvio '" & Me.lblNumero.Text & "','" & Me.DateTimePicker1.Value & "','" & gs_usuario & "'"
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error = 0 Then
                For Each dr As DataRow In ods.Tables("detalle").Rows
                    lsSQL = "pa_upd_um_requisicion_estado '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "',80" & ",'Envio Numero " & Me.lblNumero.Text & "'"
                    Otrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_requisicion_envio '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & Me.lblNumero.Text & "'"
                    Otrans.Actualiza(lsSQL)
                Next

                MessageBox.Show("Envio Generado " & Me.lblNumero.Text, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnGuardar.Enabled = False
                enviarReporte()
                Me.llenarEnvios()
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

    Private Sub llenarEnvios()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String
        Try
            Otrans.open()
            lsSQL = "pa_sel_um_requisicionEnvio"
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvListado.DataSource = dt

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub mostrarLote(ByVal piLote As Integer)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr As DataRow
        Try
            Otrans.open()

            limpiarForma()
            dt = Otrans.Obtiene("pa_var_um_requisicion_envio  " & piLote)

            If dt.Rows.Count > 0 Then

                Me.lblNumero.Text = piLote

                For Each drAux As DataRow In dt.Rows
                    dr = ods.Tables("detalle").NewRow
                    dr.Item("empresa") = drAux.Item("empresa")
                    dr.Item("numero") = drAux.Item("numero")
                    dr.Item("proveedor") = drAux.Item("Proveedor")
                    dr.Item("razonSocial") = drAux.Item("razonSocial")
                    ods.Tables("detalle").Rows.Add(dr)
                Next

                Me.btnGuardar.Enabled = False
                Me.TabControl1.SelectedTab = Me.TabPage1
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub limpiarForma()
        Me.btnGuardar.Enabled = True
        Me.lblNumero.Text = ""
        Me.txtComentarios.Text = ""
        ods.Tables("detalle").Rows.Clear()
    End Sub

    Private Sub frmRequisicionesEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
        llenarEnvios()
        limpiarForma()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroRequisicion.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.lblReenvio.Visible = False
            Me.txtNumeroRequisicion.Text = Me.txtNumeroRequisicion.Text.PadLeft(10, "0")
            buscarRequisicion()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroRequisicion.TextChanged

    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged

    End Sub

    Private Sub cmbEmpresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedValueChanged
        limpiarLinea()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        agregarLinea()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            GuardarEnvio()
        End If
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.enviarReporte()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Try
            Dim colIndex As Integer = Me.dgvListado.CurrentCell.ColumnIndex
            Dim rowIndex As Integer = Me.dgvListado.CurrentCell.RowIndex

            mostrarLote(Me.dgvListado.Item("LoteEnvio", rowIndex).Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiarforma()

    End Sub
End Class