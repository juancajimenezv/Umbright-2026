Public Class frm_scm_aprobacion_tesoreria
    Public giNumeroPedido As Integer
    Public gslEmpresa As String

    Private Sub LlenarCombo()
        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Try
            Otrans.open()
            clsGen.fillComboBox(Otrans, "pa_sel_um_gen_tabcod null,'gen_moneda','" & gslEmpresa & "'", "moneda", "CODIGO", "CODIGO", Me.cmdMoneda)

            dt = clsGen.selectQuery("SCM", "pa_sel_um_prv_proveedor '" & gslEmpresa & "'")
            dt = clsGen.ValoresDistinto(dt, "origen".Split(","))
            Me.cmbOrigen.DataSource = dt
            Me.cmbOrigen.ValueMember = "origen"
            Me.cmbOrigen.DisplayMember = "origen"


            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null,null,'" & gslEmpresa & "'")
            dt.DefaultView.RowFilter = "cod_sub_menu = 40"
            dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "nombre,usuario".Split(","))
            Me.cmbBU.DataSource = dt
            Me.cmbBU.ValueMember = "usuario"
            Me.cmbBU.DisplayMember = "nombre"


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub Buscar_Proveedor()


        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try


            If Me.txtCodProveedor.Text.Length > 0 Then
                Otrans.open()
                lsSQL = "pa_sel_um_ctacte '" & gslEmpresa & "','PROVEEDOR','" & Me.txtCodProveedor.Text.Trim & "'"
                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Proveedor No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNombreProveedor.Text = ""
                    Me.txtCodProveedor.Focus()
                Else
                    Me.txtNombreProveedor.Text = dt.Rows(0).Item("RazonSocial").ToString & "/" & dt.Rows(0).Item("giro").ToString
                End If

            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub guardarTesoreria()

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String


        Try

            If Me.txtCodProveedor.Text.Length > 0 Then
                If Not Double.Parse(Me.txtMontoAprobado.Text) < 10 Then
                    If Not Double.Parse(Me.txtTasaCambio.Text) < 1 Then
                        'If Not (Me.dtpFechaDespacho.Value < Today Or Me.dtpFechaPago.Value < Today) Then

                        lsSQL = "pa_upd_um_inv_pedido_encabezado_tesoreria " & Me.txtNumeroPedido.Text & ",'" & Me.txtCodProveedor.Text & "'," & _
                                Me.txtMontoAprobado.Text & "," & Me.txtTasaCambio.Text & ",'" & Me.cmdMoneda.SelectedValue & "','" & _
                                Me.dtpFechaDespacho.Value & "','" & Me.dtpFechaDespacho.Value.AddDays(Me.nudDiasCredito.Value) & "','" & gs_usuario & "','" & _
                                Me.cmbOrigen.SelectedValue & "'," & Me.nudDiasCredito.Value & ",'" & Me.cmbBU.SelectedValue & "','" & _
                                Me.dtpFechaCopac.Value.ToShortDateString & "'"
                        clsGen.insertQuery("SCM", lsSQL)


                        lsSQL = "pa_ins_um_inv_pedido_encabezado_estado " & Me.txtNumeroPedido.Text & ",10,'" & gs_usuario & "','" & Me.txtComentario.Text & "'"
                        clsGen.insertQuery("SCM", lsSQL)

                        MessageBox.Show("Procesado Exitosamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        'Else
                        '    MessageBox.Show("Valide las Fechas", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'End If

                    Else
                        MessageBox.Show("Problemas con la Tasa de Cambio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Problemas con el Monto Aprobado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Debe Asociar un Proveedor", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            MessageBox.Show("No Se Puede Actualizar, Revise sus datos", "Revision", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            clsGen = Nothing
        End Try



    End Sub


    Private Sub frm_scm_aprobacion_tesoreria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCombo()

    End Sub

    Private Sub btnBuscaProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscaProveedor.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_proveedor_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gslEmpresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
        frm_busqueda.ShowDialog(Me)

        Me.txtCodProveedor.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Buscar_Proveedor()
    End Sub

   
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarTesoreria()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaCopac.ValueChanged

    End Sub
End Class