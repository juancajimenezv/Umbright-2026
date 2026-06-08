Public Class frmRequisicionRecepcionCreditos

    Dim ods As New DataSet

    Private Sub crearEstructura()
        Dim dt As DataTable

        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("recibido", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        'dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentarios", GetType(String)))

        ods.Tables.Add(dt.Copy)

        Me.dgvDetalle.DataSource = ods.Tables("detalle")
    End Sub

    Private Sub llenarLote(ByVal piNumeroLote As Integer, ByVal psUsuarioRecibio As String, psOrigen As String)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drAux As DataRow
        Dim lsSQL As String

        Try
            ods.Tables("detalle").Rows.Clear()
            If psUsuarioRecibio.Length > 0 Then
                Me.dgvDetalle.ReadOnly = True
                Me.btnGuardar.Enabled = False
            Else
                Me.dgvDetalle.ReadOnly = False
                Me.btnGuardar.Enabled = True
            End If

            Me.lblNumero.Text = piNumeroLote
            Me.lblOrigen.Text = psOrigen


            Otrans.abrir()
            lsSQL = "pa_var_um_requisicion_envio_" & psOrigen & " " & piNumeroLote
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows
                drAux = ods.Tables("detalle").NewRow
                drAux("recibido") = True
                drAux("empresa") = dr.Item("empresa")
                drAux("numero") = dr.Item("numero")
                drAux("razonSocial") = dr.Item("razonSocial")
                drAux("Comentarios") = String.Empty
                ods.Tables("detalle").Rows.Add(drAux)
            Next


            clsGen.Alinear_GridView(ods.Tables("detalle"), Me.dgvDetalle, "", "", ",empresa,numero,razonsocial,", "", ",razonSocial=Proveedor,", "", "", True, True, 250, 0)
            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub llenarListado()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_requisicionEnvio_" & Me.cmbOrigen.Text.Trim
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvListado, "", ",fecha_grabo,", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub grabarRecepcion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()


            For Each dr As DataRow In ods.Tables("detalle").Rows
                If dr.Item("recibido") = False And dr.Item("comentarios").ToString.Length = 0 Then
                    MessageBox.Show("Hay Ordenes de Compra Que Fueron Rechazadas Sin Motivo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If

            Next

            For Each dr As DataRow In ods.Tables("detalle").Rows

                If dr.Item("recibido") = True Then
                    lsSQL = "pa_upd_um_requisicion_estado '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "',90" & ",''"
                    Otrans.Actualiza(lsSQL)

                    'Generar Documento FlexLine

                    lsSQL = "pa_sel_um_requisicion '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "'"
                    dt = Otrans.Obtiene(lsSQL)
                    If dt.Rows.Count > 0 Then
                        lsSQL = "bdflexline.flexline.spa_Convierte_Req_Orden '" & dr.Item("Empresa").ToString & "'," & dt.Rows(0).Item("correlativo")
                        Otrans.Ingresa(lsSQL)
                    End If


                Else
                    lsSQL = "pa_upd_um_requisicion_estado '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "','" & gs_usuario & "',910" & ",'" & dr.Item("comentarios").ToString & "'"
                    Otrans.Actualiza(lsSQL)

                    lsSQL = "pa_upd_um_requisicion_envio_" & Me.lblOrigen.Text & " '" & dr.Item("Empresa").ToString & "','" & dr.Item("numero").ToString & "',0"
                    Otrans.Actualiza(lsSQL)
                End If
            Next

            lsSQL = "pa_upd_um_requisicionEnvio_Recepcion_" & Me.lblOrigen.Text & " " & Me.lblNumero.Text & ",'" & gs_usuario & "'"
            Otrans.Actualiza(lsSQL)

            MessageBox.Show("Proceso Finalizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.llenarListado()
            Me.lblNumero.Text = ""
            ods.Tables("detalle").Rows.Clear()

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub frmRequisicionRecepcionCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()

        'llenarLote(1)
    End Sub

    Private Sub dgvListado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        llenarLote(dgvListado.Item("LoteEnvio", e.RowIndex).Value, dgvListado.Item("usuario_recibio", e.RowIndex).Value.ToString, Me.cmbOrigen.Text)

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar Esta Recepcion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            grabarRecepcion()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenarListado()
    End Sub

    Private Sub cmbOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrigen.SelectedIndexChanged

    End Sub

    Private Sub cmbOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOrigen.SelectedValueChanged
        Me.dgvListado.DataSource = Nothing
    End Sub
End Class