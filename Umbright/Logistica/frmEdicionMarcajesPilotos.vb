Public Class frmEdicionMarcajesPilotos

    Dim dtGuia As DataTable

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod_MotivosDevolucion")

            dt.DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
            Me.cmbMotivoNoEntrega.DataSource = dt.DefaultView
            Me.cmbMotivoNoEntrega.ValueMember = "CODIGO"
            Me.cmbMotivoNoEntrega.DisplayMember = "descripcion"
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub buscarControl()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dtGuia = clsgen.selectQuery("FlexLine", "pa_var_um_gen_control_transporte_detalle_temporal null,'" & Me.txtNumeroControl.Text & "'")
            Me.dgvMarcajes.DataSource = dtGuia
            clsgen.Alinear_GridView(dtGuia, Me.dgvMarcajes, "", ",tipodocto,usuario_grabo,fecha_grabo,fecha_entrada_rampa,fecha_salida_rampa,modificado,auxiliar,piloto,vehiculo,fechaorigen,", "", "", "", ",empresa=40,entregado=30,", "", True, True, 250, 0)

            Try
                Me.txtPiloto.Text = dtGuia.Rows(0).Item("piloto").ToString
                Me.txtAuxiliar.Text = dtGuia.Rows(0).Item("auxiliar").ToString
                Me.DTPFechaEntradaRampa.Value = dtGuia.Rows(0).Item("fecha_entrada_rampa")
                Me.dtpFechaSalidaRampa.Value = dtGuia.Rows(0).Item("fecha_salida_rampa")
                Me.MtxtHoraEntradaRampa.Text = TimeValue(dtGuia.Rows(0).Item("fecha_entrada_rampa"))
                Me.MtxtHoraSalidaRampa.Text = TimeValue(dtGuia.Rows(0).Item("fecha_salida_rampa"))
                Me.txtKilometrajeInicial.Text = dtGuia.Rows(0).Item("kilometraje_inicial")
                Me.txtKilometrajeFinal.Text = dtGuia.Rows(0).Item("kilometraje_final")


            Catch ex As Exception

            End Try
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub

    Private Sub limpiarForma()
        Me.txtPiloto.Text = String.Empty
        Me.txtAuxiliar.Text = String.Empty
        Me.txtNumeroDocto.Text = String.Empty
        Me.dtpFechaSalidaRampa.Value = "01/01/1900"
        Me.MtxtHoraSalidaRampa.Text = "00:00:01"
        Me.DTPFechaEntradaRampa.Value = "01/01/1900"
        Me.MtxtHoraEntradaRampa.Text = "00:00:01"
        Me.txtKilometrajeInicial.Text = String.Empty
        Me.txtKilometrajeFinal.Text = String.Empty
    End Sub

    Private Sub limpiarLinea()
        Me.txtEmpresaDocto.Text = String.Empty
        Me.txtTipoDocto.Text = String.Empty
        Me.txtNumeroDocto.Text = String.Empty
        Me.mtxtHoraEntradaCliente.Text = String.Empty
        Me.mtxtHoraSalidaCliente.Text = String.Empty
        Me.dtpFechaEntradaCliente.Value = "01/01/1900"
        Me.DTPFechaSalidaCliente.Value = "01/01/1900"
    End Sub

    Private Sub mostrarLinea()

        Dim nRow As Integer

        Try
            nRow = Me.dgvMarcajes.CurrentCell.RowIndex
            Me.txtEmpresaDocto.Text = Me.dgvMarcajes.Item("Empresa", nRow).Value
            Me.txtTipoDocto.Text = Me.dgvMarcajes.Item("TipoDoctoOrigen", nRow).Value
            Me.txtNumeroDocto.Text = Me.dgvMarcajes.Item("numeroOrigen", nRow).Value
            Me.mtxtHoraEntradaCliente.Text = TimeValue(Me.dgvMarcajes.Item("fecha_entrada_cliente", nRow).Value)
            Me.mtxtHoraSalidaCliente.Text = TimeValue(Me.dgvMarcajes.Item("fecha_salida_cliente", nRow).Value)
            Me.dtpFechaEntradaCliente.Value = Me.dgvMarcajes.Item("fecha_entrada_cliente", nRow).Value
            Me.DTPFechaSalidaCliente.Value = Me.dgvMarcajes.Item("fecha_salida_cliente", nRow).Value

            Me.cmbEntregado.Text = Me.dgvMarcajes.Item("entregado", nRow).Value.ToString
            Me.cmbMotivoNoEntrega.SelectedValue = Me.dgvMarcajes.Item("motivo", nRow).Value.ToString
            Me.txtKilometraje.Text = Me.dgvMarcajes.Item("kilometraje", nRow).Value.ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub modificarLinea()

        Try
            For Each dr As DataRow In dtGuia.Rows
                If dr.Item("empresa").ToString.Equals(Me.txtEmpresaDocto.Text) _
                    And dr.Item("tipoDoctoOrigen").ToString.Equals(Me.txtTipoDocto.Text) _
                    And dr.Item("numeroOrigen").ToString.Equals(Me.txtNumeroDocto.Text) Then

                    dr.Item("fecha_entrada_cliente") = Me.dtpFechaEntradaCliente.Text & " " & Me.mtxtHoraEntradaCliente.Text.Replace(" ", "0").PadRight(5, "0")
                    dr.Item("fecha_salida_cliente") = Me.DTPFechaSalidaCliente.Text & " " & Me.mtxtHoraSalidaCliente.Text.Replace(" ", "0").PadRight(5, "0")
                    dr.Item("kilometraje") = Me.txtKilometraje.Text
                    dr.Item("entregado") = Me.cmbEntregado.Text

                    dr.Item("motivo") = If(Val(Me.cmbEntregado.Text) = 1, "", Me.cmbMotivoNoEntrega.SelectedValue)
                    dr.Item("modificado") = 1


                    Exit For


                End If
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Function validacionesLinea() As Boolean
        Dim ldFechaEntrada, ldFechaSalida As Date
        ldFechaEntrada = Me.dtpFechaEntradaCliente.Text.Substring(0, 10) & " " & Me.mtxtHoraEntradaCliente.Text.Replace(" ", "0")
        ldFechaSalida = Me.DTPFechaSalidaCliente.Text.Substring(0, 10) & " " & Me.mtxtHoraSalidaCliente.Text.Replace(" ", "0")

        If ldFechaSalida < ldFechaEntrada Then
            MessageBox.Show("Debe Validar Los Horarios de Cliente", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Try
            If Val(Me.txtKilometraje.Text) < 1000 Or Val(Me.txtKilometraje.Text) > 10000000 Then
                MessageBox.Show("Problemas con el Kilometraje", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Problemas con el Kilometraje", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End Try


        
        Return True
    End Function


    Private Sub guardarCambios()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            For Each dr As DataRow In Me.dtGuia.Rows
                If dr.Item("modificado").ToString.Equals("1") Then
                    lsSQL = "pa_upd_gen_control_transporte_temporal_edicion '" & dr.Item("empresa").ToString & "','" & _
                        Me.txtNumeroControl.Text & "','" & dr.Item("TipoDoctoOrigen").ToString & "','" & _
                        dr.Item("NumeroOrigen").ToString & "','" & dr.Item("fecha_entrada_cliente") & "','" & _
                        dr.Item("fecha_salida_cliente") & "','" & dr.Item("entregado") & "','" & _
                        dr.Item("motivo").ToString & "'," & dr.Item("kilometraje").ToString.Trim & ",'" & gs_usuario & "'"

                    clsGen.insertQuery("FlexLine", lsSQL)
                End If
            Next





            If ((Val(Me.txtKilometrajeInicial.Text) <> dtGuia.Rows(0).Item("kilometraje_inicial") Or _
                Val(Me.txtKilometrajeFinal.Text) <> dtGuia.Rows(0).Item("kilometraje_final")) And _
                (Val(Me.txtKilometrajeFinal.Text) > Val(Me.txtKilometrajeInicial.Text))) Then



                If ((Me.DTPFechaEntradaRampa.Value.ToShortDateString & " " & Me.MtxtHoraEntradaRampa.Text.Replace(" ", "0").PadRight(5, "0") <> dtGuia.Rows(0).Item("fecha_entrada_rampa") Or
                    Me.dtpFechaSalidaRampa.Value.ToShortDateString & " " & Me.MtxtHoraSalidaRampa.Text.Replace(" ", "0").PadRight(5, "0") <> dtGuia.Rows(0).Item("fecha_salida_rampa")) Or _
                    ((Val(Me.txtKilometrajeInicial.Text) <> dtGuia.Rows(0).Item("kilometraje_inicial") Or _
                        Val(Me.txtKilometrajeFinal.Text) <> dtGuia.Rows(0).Item("kilometraje_final")) And _
                        (Val(Me.txtKilometrajeFinal.Text) > Val(Me.txtKilometrajeInicial.Text)))) Then

                    ''Actualizar fecha de entrada y salida de rampa

                    lsSQL = "pa_upd_gen_control_transporte_temporal_chequeo_edicion '" & _
                        Me.txtNumeroControl.Text & "','" & _
                        Me.dtpFechaSalidaRampa.Value.ToShortDateString & " " & Me.MtxtHoraSalidaRampa.Text.Replace(" ", "0").PadRight(5, "0") & "','" & _
                        Me.DTPFechaEntradaRampa.Value.ToShortDateString & " " & Me.MtxtHoraEntradaRampa.Text.Replace(" ", "0").PadRight(5, "0") & "','" & _
                        gs_usuario & "'," & _
                        Me.txtKilometrajeInicial.Text.Trim & "," & _
                        Me.txtKilometrajeFinal.Text.Trim

                    clsGen.insertQuery("FlexLine", lsSQL)
                End If
                MessageBox.Show("Informacion De Rampa Actualizada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No Se Actualiza Informacion de Rampa", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If




        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub frmEdicionMarcajesPilotos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub


    Private Sub txtNumeroControl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroControl.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.PadLeft(10, "0")
            limpiarLinea()
            limpiarForma()
            buscarControl()
        End If
    End Sub

    
    Private Sub dgvMarcajes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcajes.CellDoubleClick
        limpiarLinea()
        mostrarLinea()
    End Sub

    Private Sub txtKilometraje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKilometraje.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                If Val(Me.txtKilometraje.Text) < 1000 Then
                    MessageBox.Show("Ingreso un valor Invalido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Catch ex As Exception
                MessageBox.Show("Ingreso un valor Invalido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtKilometraje_MouseEnter(sender As Object, e As EventArgs) Handles txtKilometraje.MouseEnter

    End Sub

    

    Private Sub btnModificarLinea_Click(sender As Object, e As EventArgs) Handles btnModificarLinea.Click
        If validacionesLinea Then
            modificarLinea()
        End If

    End Sub

    Private Sub dgvMarcajes_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMarcajes.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvMarcajes.Rows(rowIndex)
                If Me.dgvMarcajes.Item("modificado", rowIndex).Value = 1 Then
                    Me.dgvMarcajes.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvMarcajes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcajes.CellContentClick

    End Sub

    Private Sub cmbEntregado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEntregado.SelectedIndexChanged

    End Sub

    Private Sub cmbEntregado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEntregado.SelectedValueChanged
        If Me.cmbEntregado.Text = "0" Then
            Me.cmbMotivoNoEntrega.Visible = True
        Else
            Me.cmbMotivoNoEntrega.Visible = False
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Aplicar Los Cambios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarCambios()

        End If
    End Sub

    Private Sub txtNumeroControl_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroControl.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiarForma()
    End Sub
End Class