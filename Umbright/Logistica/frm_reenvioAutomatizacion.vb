Public Class frm_reenvioAutomatizacion
    Private clsgls As New ClasesGenerales.General
    Private otrans As New Transaccional.Conexion("flexline")
    Private dt As New DataTable
    Private necesitaImprimir As Boolean = False
    Private ctacte, numPedido As String


    Private Sub previewFactura()
        Dim sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Try
            Otrans.open()
            lsSQL = "pa_var_um_documento_guia_transporte '" & Me.cmbEmpresa.SelectedValue & "','" & Me.cmbTipoDocto.Text & "','" & Me.txNumero.Text & "'"

            dt = Otrans.Obtiene(lsSQL)
            If Otrans.Codigo_error = 0 Then
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Control Asignado  " & Chr(13) & dt.Rows(0).Item("numero_control").ToString & " del " & _
                                        dt.Rows(0).Item("fecha_control").ToString, _
                     "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show(Otrans.descripcion_error)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



        dt = clsgls.dbQuery("flexline", Sql, "SELECT")
        Try
            If (dt.Rows.Count > 0) Then
                lblEmpresa.Text = dt.Rows(0).Item("empresa").ToString
                lblNumero.Text = dt.Rows(0).Item("numeroorigen").ToString
                lblRuta.Text = dt.Rows(0).Item("nombre_planif").ToString
                lblTipoDocto.Text = dt.Rows(0).Item("tipodoctoorigen").ToString
            Else
                MessageBox.Show("No existe el documento que intenta ingresar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txNumero.Text = ""
                lblEmpresa.Text = ""
                lblNumero.Text = ""
                lblTipoDocto.Text = ""
            End If
            If (dt.Rows(0).Item("CodLegal").ToString.Equals("737810-6")) Then
                'Es Operadora de Tiendas, necesita impresion
                necesitaImprimir = True
                ctacte = dt.Rows(0).Item("ctacte").ToString

            End If
        Catch ex As Exception
            MessageBox.Show("No existe el documento que intenta ingresar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            txNumero.Text = ""
            lblEmpresa.Text = ""
            lblNumero.Text = ""
            lblTipoDocto.Text = ""
        End Try

    End Sub

    Private Sub confirmar()
        txNumero.Focus()
        Dim lsSQL As String

        Try

            'lsSQL = "pa_del_um_documentod_guia '" & gs_empresa & "','" & Me.cmbTipoDocto.ValueMember & "','" & _
            '    Me.txNumero.Text & "','" & Me.txt_guia.Text & "','" & Me.cmb_tipos.Text & "','" & _
            '    dr.Item("comentario") & "','" & gs_usuario & "'"
            'otrans.Elimina(ls_sqlscript)


            '            @P_empresa as varchar(20),
            '@P_tipodocto as varchar(40),
            '@P_numero as varchar(20),
            '@P_numero_guia as varchar(20),
            '@P_tipoguia as varchar(40),
            '@P_observaciones as varchar(100)=null,
            '@P_usuario as varchar(20)=null

        Catch ex As Exception

        End Try



        Dim sql As String
        Dim dtaux As DataTable
        If (necesitaImprimir) Then
            necesitaImprimir = False

            dt = clsgls.dbQuery("flexline", "pa_var_um_facturas_oc_edifact2 '" _
            & lblEmpresa.Text & "','" & lblTipoDocto.Text & "','" & lblNumero.Text & "'", "SELECT")

            Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

            sql = "call pa_var_um_mov_edi_pedido_wm ('" & lblEmpresa.Text & "','" & dt.Rows(0).Item("tipo_pedido").ToString & "','" _
             & dt.Rows(0).Item("numero_pedido").ToString & "','" & ctacte & "')"

            dtaux = clsgls.dbQuery("onbase", sql, "SELECT", "MYSQL")


        End If
        Try
            'Imprimir_Ordenes(lblEmpresa.Text.ToString, dtaux.Rows(0).Item("numero_pedido").ToString, dtaux.Rows(0).Item("idempresalocal").ToString)
        Catch
        End Try

        sql = "pa_upd_cambiar_estado_control_transporte '" & lblEmpresa.Text & "','" & lblTipoDocto.Text & "','" & lblNumero.Text & "'"
        clsgls.dbQuery("flexline", sql, "UPDATE")
        txNumero.Text = ""

    End Sub

    Private Sub frm_reenvioAutomatizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsgls.fillComboBox(otrans, "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','ALAMSA'", "empresa", "descripcion", "descripcion", cmbEmpresa)
            clsgls.fillComboBox(otrans, "pa_sel_um_tipo_documento ", "tipodocto", "tipodocto", "tipodocto", cmbTipoDocto)

        Catch ex As Exception
        Finally
            clsgls = Nothing
        End Try

    End Sub

    Private Sub txNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNumero.KeyPress, txt.KeyPress, TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            previewFactura()
            btnConfirmar.Focus()
            confirmar()
        End If

    End Sub

    Private Sub txNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txNumero.TextChanged, txt.TextChanged, TextBox2.TextChanged

    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click

    End Sub
End Class