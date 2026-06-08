Imports System.Windows.Forms
Public Class frm_separar_factura_transporte
    Private clsgls As New ClasesGenerales.General
    Private otrans As New Transaccional.Conexion("flexline")
    Private dt As New DataTable
    Private necesitaImprimir As Boolean = False
    Private ctacte, numPedido As String
    'Private sql As New String
    Private Sub frm_separar_factura_transporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsgls.fillComboBox(otrans, "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','ALAMSA'", "empresa", "descripcion", "descripcion", cmbEmpresa)
        clsgls.fillComboBox(otrans, "pa_sel_um_tipo_documento ", "tipodocto", "tipodocto", "tipodocto", cmbTipoDocto)
    End Sub

    Private Sub txNumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNumero.KeyPress
        If e.KeyChar = Chr(13) Then
            previewFactura()
            btnConfirmar.Focus()
            confirmar()
        End If
    End Sub

    Private Sub previewFactura()
        Dim sql As String
        If (txNumero.Text.ToString.Length > 12) Then
            sql = "pa_sel_um_transportes_planif '" & cmbEmpresa.Text.ToString & "', '" & cmbTipoDocto.Text.ToString & "','" & txNumero.Text.ToString.Substring(0, 12) & "'"
            txNumero.Text = txNumero.Text.ToString.Substring(0, 12)
        Else
            sql = "pa_sel_um_transportes_planif '" & cmbEmpresa.Text.ToString & "', '" & cmbTipoDocto.Text.ToString & "','" & txNumero.Text.ToString & "'"
        End If

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

    Private Sub buscarCorrespondientes()
      
    End Sub

    Private Sub confirmar()
        txNumero.Focus()
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
            Imprimir_Ordenes(lblEmpresa.Text.ToString, dtaux.Rows(0).Item("numero_pedido").ToString, dtaux.Rows(0).Item("idempresalocal").ToString)
        Catch
        End Try

        sql = "pa_upd_cambiar_estado_control_transporte '" & lblEmpresa.Text & "','" & lblTipoDocto.Text & "','" & lblNumero.Text & "'"
        clsgls.dbQuery("flexline", sql, "UPDATE")
        txNumero.Text = ""

    End Sub
    Public Sub Imprimir_Ordenes(ByVal spEmpresa As String, ByVal spOrdendeCompra As String, ByVal cliente_ As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Try
            pm_conexion = ClsGen.Parametros_Conexion("Onbase")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\edifact.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "cod_pedido"
            pm_parametros(2) = "cliente"

            pm_valores(0) = spEmpresa
            pm_valores(1) = spOrdendeCompra
            pm_valores(2) = cliente_

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                            False, True, "PDF", False, "", True, 1)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub txNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txNumero.TextChanged

    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click

    End Sub
End Class