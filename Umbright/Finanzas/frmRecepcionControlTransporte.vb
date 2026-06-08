Public Class frmRecepcionControlTransporte
    Dim pdataset As DataSet

    Private Sub buscarControl()

        Dim ls_SqlScript As String
        Dim otabla As DataTable
        Dim dt As DataTable
        Dim clGen As New ClasesGenerales.General

        If Me.txtNumeroControl.Text.Length = 12 Then
            'lempresa = Me.txt_guia.Text.Substring(0, 1)
            Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.Substring(1, 10)
            'pdataset.Tables("empresa").DefaultView.RowFilter = "codigo = '0" & lempresa & "'"
            'If pdataset.Tables("empresa").DefaultView.Count = 1 Then lempresa = pdataset.Tables("empresa").DefaultView(0)("Descripcion").ToString
        End If





        If Me.txtNumeroControl.Text.Length > 0 Then
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Try
                oTransaccion.open()

                Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.PadLeft(10, "0")
                'ls_SqlScript = "pa_sel_um_documento_relacion_detalle '" & Me.cmb_tipos.Text & "','" & lempresa & "','" & Me.txt_guia.Text & "'"
                ls_SqlScript = "pa_var_um_documento_guia_recepcion 'CONTROL DE TRANSPORTE',NULL,'" & Me.txtNumeroControl.Text & "'"
                otabla = oTransaccion.Obtiene(ls_SqlScript)

                If oTransaccion.Codigo_error = 0 Then
                    Try
                        'pdataset.Reset()
                        'Crear_Esquema()
                        pdataset.Tables("guia_liquidador_copia").Rows.Clear()

                    Catch ex As Exception
                    End Try

                    otabla.TableName = "guia_liquidador"
                    'For Each dr As DataRow In otabla.Rows
                    '    dr.Item("Comentario") = "L"
                    'Next
                    If pdataset.Tables.Contains("guia_liquidador") Then pdataset.Tables.Remove("guia_liquidador")
                    pdataset.Tables.Add(otabla.Copy)

                    Me.dgvDocumentos.DataSource = pdataset.Tables("guia_liquidador")
                    'Me.dvgDocumentos.CaptionText = "Documentos en Guia " & otabla.Rows.Count
                    If otabla.Rows.Count > 0 Then
                        Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA_GUIA")
                        Me.txt_piloto.Text = otabla.Rows(0).Item("PILOTO").ToString
                        Me.txtAuxiliar.Text = otabla.Rows(0).Item("Auxiliar").ToString
                        Me.txtVehiculo.Text = otabla.Rows(0).Item("Vehiculo").ToString
                        Me.txtChequeador.Text = otabla.Rows(0).Item("Chequeador").ToString
                        Me.txtRuta.Text = otabla.Rows(0).Item("ruta").ToString


                    End If



                    clGen.Alinear_GridView(pdataset.Tables("guia_liquidador"), Me.dgvDocumentos, ",empresa,numero_guia,fecha_guia,piloto,comentario,numero,fecha,nombre,", "", _
                                           ",empresa,numero_guia,fecha_guia,piloto,numero,fecha,nombre,", " ", "", "", _
                                           ",comentario,empresa,comentario,numero,fecha,nombre,numero_guia,fecha_guia,piloto,nombre,", True, True, 200, 40)


                    'Me.dgDocumentos.Refresh()
                    'Me.DataGrid2.Refresh()

                    'Muevo el ultimo registro para que tome la estructura que deseo
                    'Mover_registro_a_copia(otabla.Rows.Count - 1)
                    'Regreso el registro que movi previamente
                    'DataGrid2_DoubleClick(sender, e)

                    'Me.Refresh()
                    Me.txtNumeroControl.Enabled = False

                Else
                    MessageBox.Show(oTransaccion.descripcion_error)
                End If

            Catch ex As Exception
                MessageBox.Show("Guia No Existe, Verique el Numero", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                oTransaccion.close()
                oTransaccion = Nothing
            End Try
        End If
        clGen = Nothing

        'If pdataset.Tables("guia_liquidador").Rows.Count > 0 Then

        '    If MessageBox.Show("Desea Procesar la Liquidacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        'Liberar_Documentos()
        '        Actualizar_Documentos_Guia()
        '        Limpiar_Forma()
        '    End If
        'End If
        'End If
    End Sub


    Private Sub agregarComentarioFactura()

        Try
            For Each dr As DataRow In pdataset.Tables("guia_liquidador").Rows
                If dr.Item("numero").ToString.Equals(Me.txtNumeroFactura.Text) Then
                    dr.Item("comentario") = Me.txtComentarioFactura.Text

                    Me.txtNumeroFactura.Focus()
                    Me.txtNumeroFactura.Text = String.Empty
                    Me.txtComentarioFactura.Text = String.Empty
                    Exit Try
                End If
            Next

        Catch ex As Exception
        Finally


        End Try
    End Sub


    Private Sub BuscarFacturaenControl()

        Try
            For Each dr As DataRow In pdataset.Tables("guia_liquidador").Rows
                If dr.Item("numero").ToString.Equals(Me.txtNumeroFactura.Text) Then
                    Me.txtComentarioFactura.Text = String.Empty
                    Me.txtComentarioFactura.Text = dr.Item("comentario").ToString
                    Me.txtComentarioFactura.Focus()
                    Exit Try
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Actualizar_Documentos_Guia()
        Dim i As Integer
        'Dim dr As DataRow
        Dim ls_sqlscript As String
        Dim oTrans As Transaccional.Conexion

        If pdataset.Tables("guia_liquidador").Rows.Count > 0 Then
            oTrans = New Transaccional.Conexion("flexline")
            oTrans.open()

            For Each dr As DataRow In pdataset.Tables("guia_liquidador").Rows
                Try
                    'dr = pdataset.Tables("guia_liquidador").Rows(i)
                    ls_sqlscript = "pa_upd_um_documentod_guia '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipo").ToString & "','" & _
                                    dr.Item("numero").ToString & "','" & dr.Item("numero_guia").ToString & "','CONTROL DE TRANSPORTE','" & _
                                    dr.Item("comentario").ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(ls_sqlscript)
                    If oTrans.Codigo_error > 0 Then
                        MessageBox.Show(oTrans.descripcion_error)
                    End If
                Catch ex As Exception
                    ' MessageBox.Show(ex.Message)
                End Try

            Next
            oTrans.close()
            oTrans = Nothing
            MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiar()
        End If
    End Sub

    Private Sub AsignarGrid()

    End Sub

    Private Sub limpiar()
        pdataset = New DataSet
        Me.txtNumeroControl.Enabled = True
        Me.txt_fecha.Text = String.Empty
        Me.txt_piloto.Text = String.Empty
        Me.txtAuxiliar.Text = String.Empty
        Me.txtVehiculo.Text = String.Empty
        Me.txtChequeador.Text = String.Empty
        Me.txtRuta.Text = String.Empty
        Me.txtNumeroFactura.Text = String.Empty
        Me.txtComentarioFactura.Text = String.Empty

        Me.txtNumeroControl.Focus()

        Try
            Me.dgvDocumentos.DataSource = Nothing
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmRecepcionControlTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpiar()


    End Sub

    Private Sub txtNumeroControl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroControl.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarControl()
        End If
    End Sub

    Private Sub txtNumeroControl_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroControl.TextChanged

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta seguro de Procesar este Control", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.Actualizar_Documentos_Guia()
        End If

    End Sub

    Private Sub txtNumeroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroFactura.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtNumeroFactura.Text.Length = 13 Then txtNumeroFactura.Text = txtNumeroFactura.Text.Substring(0, 12)


            BuscarFacturaenControl()
        End If
    End Sub

    Private Sub txtNumeroFactura_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroFactura.TextChanged


    End Sub

    Private Sub txtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioFactura.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtComentarioFactura.Text.Length > 0 Then
                agregarComentarioFactura()
            End If
        End If
    End Sub

    Private Sub txtComentario_TextChanged(sender As Object, e As EventArgs) Handles txtComentarioFactura.TextChanged

    End Sub
End Class