Public Class frm_entregaExpress

    Public lsVehiculo, lsPiloto, lsEmpresa, lsAuxiliar As String
    Private Sub llenarInformacion()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "empresa"

            Me.cmbEmpresa.DisplayMember = "descripcion"
            Me.cmbEmpresa.ValueMember = "descripcion"
            Me.cmbEmpresa.DataSource = dt

            lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_AUXILIAR','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "auxiliar"
            dt.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.cmbAuxiliar.DisplayMember = "CODIGO"
            Me.cmbAuxiliar.ValueMember = "CODIGO"
            Me.cmbAuxiliar.DataSource = dt.DefaultView

            lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_PILOTO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "piloto"
            dt.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.cmbPiloto.DisplayMember = "CODIGO"
            Me.cmbPiloto.ValueMember = "CODIGO"
            Me.cmbPiloto.DataSource = dt.DefaultView

            lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_VEHICULOS','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "piloto"
            dt.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.cmbVehiculo.DisplayMember = "CODIGO"
            Me.cmbVehiculo.ValueMember = "CODIGO"
            Me.cmbVehiculo.DataSource = dt.DefaultView

            Me.cmbVehiculo.SelectedValue = lsVehiculo
            Me.cmbPiloto.SelectedValue = lsPiloto
            Me.cmbEmpresa.SelectedValue = lsEmpresa
            Me.cmbAuxiliar.SelectedValue = lsAuxiliar

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub guardarInformacion()
        Dim lsSQL As String
        Dim ptipoDocto As String = "ENTREGA EXPRESS"
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()
            lsSQL = "pa_sel_var_numero_control_transporte '" & Me.cmbEmpresa.SelectedValue & "','" & ptipoDocto & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count = 1 Then
                Me.txtNumero.Text = (Val(dt.Rows(0).Item("numero").ToString) + 1).ToString.PadLeft(10, "0")
            End If

            lsSQL = "pa_ins_um_entrega_express '" & Me.cmbEmpresa.SelectedValue & "','" & _
                                         ptipoDocto & "','" & Me.txtNumero.Text & "','" & _
                                         Me.dtpFecha.Text & "','" & Me.dtpFecha.Text & "','" & _
                                         Me.cmbPiloto.Text & "','" & Me.cmbVehiculo.Text & "','" & _
                                         Me.cmbAuxiliar.Text & "'," & Double.Parse(Me.txtViaticos.Text) & "," & _
                                         Double.Parse(Me.txtHorasExtra.Text) & "," & Double.Parse(Me.txtTaxi.Text) & "," & _
                                         Double.Parse(Me.txtOtros.Text) & ",'" & Me.txtOrigen.Text & "','" & _
                                         Me.txtDestino.Text & "','" & Me.txtNumeroDocto.Text & "','" & _
                                         Me.txtTarifaCosto.Text & "','" & Me.txtUsuarioSolicita.Text & "'," & Double.Parse(Me.txtValor.Text) & ", " & _
                                         "12,'S','" & Me.dtpFecha.Value.ToString("yyyyMM") & "','" & _
                                         "peso=" & Me.txtPeso.Text.Trim & ",Volumen=" & Me.txtVolumen.Text.Trim & "','" & _
                                          Me.txtPeso.Text.Trim & "','" & Me.txtVolumen.Text.Trim & "','"

            lsSQL += Me.txtComentarios.Text & "','" & _
                    gs_usuario & "','" & Me.txtCodCliente.Text & "'"


            Otrans.Ingresa(lsSQL)
            If Otrans.Codigo_error = 0 Then
                lsSQL = "pa_var_um_documento '" & Me.cmbEmpresa.SelectedValue & "','" & _
                                         ptipoDocto & "','" & Me.txtNumero.Text & "'"
                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    lsSQL = "pa_ins_um_documentod '" & Me.cmbEmpresa.SelectedValue & "','" & _
                            ptipoDocto & "'," & dt.Rows(0).Item("correlativo") & ",1,'0900280001',1," & Double.Parse(Me.txtValor.Text) & "," & _
                            Double.Parse(Me.txtValor.Text) & ",0,12,'" & Me.dtpFecha.Text & "',0,0,1"
                    Otrans.Ingresa(lsSQL)

                    If Otrans.Codigo_error = 0 Then
                        enviarImpresion()
                        MessageBox.Show("Entrega Almacenada Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                End If


            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub enviarImpresion()
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Logistica\Trafico\Entrega Express.rpt"
            pm_parametros(0) = "Empresa"
            pm_parametros(1) = "Numero"

            pm_valores(0) = Me.cmbEmpresa.Text
            pm_valores(1) = Me.txtNumero.Text


            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                           False, True, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try

    End Sub

    Private Sub buscarCliente()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_ctacte '" & Me.cmbEmpresa.SelectedValue & "','CLIENTE','" & Me.txtCodCliente.Text & "'")
            If dt.Rows.Count = 1 Then
                Me.txtNombreCliente.Text = dt.Rows(0).Item("razonSocial").ToString
            Else
                Dim frm_busqueda As New frm_busqueda_general

                frm_busqueda.parametros_fijos = " empresa = '" & Me.cmbEmpresa.SelectedValue & "' and "
                frm_busqueda.parametros = "CtaCte,RazonSocial,Giro,Ejecutivo,vigencia_cliente"
                frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
                frm_busqueda.lista_campos = "ctacte, RazonSocial, Giro, Ejecutivo, vigencia_cliente,ListaPrecio "

                frm_busqueda.txt_buscar1.Focus()
                frm_busqueda.dg_buscar.ReadOnly = False
                frm_busqueda.btn_seleccion_multipe.Visible = False
                frm_busqueda.Btn_Aceptar.Visible = True
                frm_busqueda.ShowDialog(Me)

                Me.txtCodCliente.Text = frm_busqueda.resultado

                'Ods.Tables("clientes").Clear()
                'MyOtrans.open()
                'ls_sql = "call pa_sel_um_mmp_detalle_clientes ( " & _pcod_memo & ")"
                'dt = MyOtrans.Obtiene(ls_sql)
                'Me.dg_clientes(oldcurrentrow, 0) = ""
             
                frm_busqueda.Dispose()
                frm_busqueda = Nothing
                dt = Otrans.Obtiene("pa_sel_um_ctacte '" & Me.cmbEmpresa.SelectedValue & "','CLIENTE','" & Me.txtCodCliente.Text & "'")
                If dt.Rows.Count = 1 Then Me.txtNombreCliente.Text = dt.Rows(0).Item("razonSocial").ToString
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub calcularTotal()
        Dim dtotal As Double = 0
        Try
            dtotal = dtotal + Double.Parse(Me.txtViaticos.Text)
            dtotal = dtotal + Double.Parse(Me.txtHorasExtra.Text)
            dtotal = dtotal + Double.Parse(Me.txtTaxi.Text)
            dtotal = dtotal + Double.Parse(Me.txtOtros.Text)

        Catch ex As Exception

        End Try
        Me.txtTotalCosto.Text = dtotal

    End Sub

    Private Sub frm_entregaExpress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarInformacion()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarInformacion()
        End If
    End Sub

    Private Sub txtCodCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCliente.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarCliente()
        End If
    End Sub

    Private Sub txtCodCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodCliente.TextChanged

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub txtViaticos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtViaticos.Leave, txtHorasExtra.Leave, txtTaxi.Leave, txtOtros.Leave
        calcularTotal()
    End Sub

    
End Class