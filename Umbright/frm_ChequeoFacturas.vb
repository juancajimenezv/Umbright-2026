Public Class frm_ChequeoFacturas

    Private Sub llenarCombos()
        'Dim clsgen As New ClasesGenerales.General
        'Dim Otrans As New Transaccional.Conexion("FlexLine")
        'clsgen.fillComboBox(otrans,"","chequeador","
    End Sub

    Private Sub buscarControl()

        Dim clsgen As New ClasesGenerales.General
        Dim dt, dtPendientes As DataTable

        dt = clsgen.selectQuery("FlexLine", "pa_var_um_gen_control_transporte_chequeo '" & Me.txtNumeroControl.Text & "'")

        If dt.Rows.Count > 0 Then
            Me.txtNumeroDocumentos.Text = dt.Rows.Count.ToString
            With dt.Rows(0)
                Me.txtPiloto.Text = .Item("piloto").ToString
                Me.txtRuta.Text = .Item("ruta").ToString
                Me.txtFecha.Text = .Item("fecha")
                If .Item("chequeador").ToString.Trim.Length = 0 Then
                    Dim oform As New frm_pickeador
                    oform.Text = "Seleccione Chequeador"
                    oform.Llenar_Combo_Chequeador()
                    oform.ShowDialog(Me)
                    Me.txtChequeador.Text = oform.cmb_nombre_picker.SelectedValue.ToString
                    oform.Dispose()
                Else
                    Me.txtChequeador.Text = .Item("chequeador").ToString
                End If
                If .Item("fecha_inicio_chequeo").ToString.Length = 0 Then

                    'Debo verificar que no tenga abierto otro proceso
                    dtPendientes = clsgen.selectQuery("FlexLine", "pa_var_um_gen_control_transporte_chequeo_pendiente_usuario '" & Me.txtChequeador.Text & "'")

                    If dtPendientes.Rows.Count > 0 Then
                        'MessageBox.Show("Tiene Pendiente Finalizar El chequeo del Control " & dt.Rows(0).Item("numero").ToString)
                        MessageBox.Show("Tiene Pendiente Finalizar El chequeo del Control " & dtPendientes.Rows(0).Item("numero").ToString)
                    ElseIf MessageBox.Show("Esta Seguro de Asignar Tiempo Inicio", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        clsgen.insertQuery("FlexLine", " pa_upd_um_gen_control_transporte_chequeo '" & Me.txtNumeroControl.Text & "','" & Me.txtChequeador.Text & "',1")
                    End If
                ElseIf .Item("fecha_final_chequeo").ToString.Length = 0 Then
                    Me.txtInicio.Text = .Item("fecha_inicio_chequeo").ToString
                    If MessageBox.Show("Esta Seguro de Asignar Tiempo Final", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        clsgen.insertQuery("FlexLine", " pa_upd_um_gen_control_transporte_chequeo '" & Me.txtNumeroControl.Text & "','" & Me.txtChequeador.Text & "',2")
                    End If
                Else
                    Me.txtInicio.Text = .Item("fecha_inicio_chequeo").ToString
                    Me.txtFinal.Text = .Item("fecha_final_chequeo").ToString
                End If
            End With
        End If
        clsgen = Nothing
    End Sub

    Private Sub txtNumeroControl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroControl.TextChanged

    End Sub

    Private Sub frm_ChequeoFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub txtNumeroControl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroControl.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txtNumeroControl.Text.Length > 10 Then
                Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.Substring(1, 10)
            ElseIf Me.txtNumeroControl.Text.Length > 0 Then
                Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.PadLeft(10, "0")
            End If
            buscarControl()
        End If
    End Sub
End Class