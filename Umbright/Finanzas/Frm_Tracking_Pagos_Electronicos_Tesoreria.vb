Public Class Frm_Tracking_Pagos_Electronicos_Tesoreria

    Public lote As String
    Public nd_correlativo As Integer
    Public nd_tipoComprobante As String
    Public nd_lote As String
    Public nd_fecha As Date

    Dim lbValidaCorrelativo As Boolean = False
    Dim lbValidaValores As Boolean = False

    Dim dtDetalleLote As DataTable

    '   Dim gs_empresa As String = "VINOTECA"
    Private Sub Frm_Tracking_Pagos_Electronicos_Tesoreria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_Enviar.Enabled = False
        carga_lote()
        carga_banco()
    End Sub

    Private Sub carga_banco()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            oTrans.open()

            lsSQL = "flexline.pa_sel_tracking_pagos_banco '" & gs_empresa & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                cmbBanco.DataSource = dt
                cmbBanco.DisplayMember = "Banco"   ' Texto visible
                cmbBanco.ValueMember = "Banco"     ' Valor interno

                ' Si solo hay un registro, seleccionarlo automáticamente
                If dt.Rows.Count = 1 Then
                    cmbBanco.SelectedIndex = 0
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub carga_cuenta_banco()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            oTrans.open()

            lsSQL = "flexline.pa_sel_tracking_pagos_cuentabanco '" & gs_empresa & "','" & cmbBanco.SelectedValue.ToString() & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                cmbCuentaBanco.DataSource = dt
                cmbCuentaBanco.DisplayMember = "CuentaBanco"   ' Texto visible
                cmbCuentaBanco.ValueMember = "CuentaBanco"     ' Valor interno

                ' Si solo hay un registro, seleccionarlo automáticamente
                If dt.Rows.Count = 1 Then
                    cmbCuentaBanco.SelectedIndex = 0
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub carga_moneda()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            oTrans.open()

            lsSQL = "flexline.pa_sel_tracking_pagos_moneda '" & gs_empresa & "','" & cmbCuentaBanco.SelectedValue.ToString() & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                cmbMoneda.DataSource = dt
                cmbMoneda.DataSource = dt
                cmbMoneda.ValueMember = "Moneda"

                ' Si solo hay un registro, seleccionarlo automáticamente
                If dt.Rows.Count = 1 Then
                    cmbMoneda.SelectedIndex = 0
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub carga_lote()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()

            lsSQL = "flexline.pa_um_sel_Pagos_Electronicos_Lotes '" & gs_empresa & "','" & lote.Trim & "'"
            dtDetalleLote = oTrans.Obtiene(lsSQL)

            lbl_lote.Text = lote
            nd_lote = lbl_lote.Text

            dgv_Detalle.DataSource = dtDetalleLote

            'MsgBox("El Lote se Encuentra en Tesorería!!!", MsgBoxStyle.Information, "Tesorería...")
            'Carga_Combos()
            ClsGen.Alinear_GridView(dtDetalleLote, Me.dgv_Detalle, "", "", "", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_valida_proceso_Click(sender As Object, e As EventArgs) Handles btn_valida_proceso.Click
        Try
            validaCorrelativos()
            valida_valores()

            If lbValidaCorrelativo = False And lbValidaValores = False Then
                btn_Enviar.Enabled = True
            Else
                btn_Enviar.Enabled = False
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        Valida_tasa()
    End Sub

    Private Sub Valida_tasa()
        If cmbMoneda.Text = "DOLARES" Then
            If txtTasa.Text = "" Or txtTasa.Text = "0" Or Not IsNumeric(txtTasa.Text) Then
                MessageBox.Show("Debe Ingresar una Tasa de Cambio Valida", "Validacion de Tasa de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTasa.Focus()
                txtTasa.SelectAll()
                Exit Sub
            Else
                Crea_nd_flexline()
            End If
        Else
            Crea_nd_flexline()
        End If

    End Sub

    Private Sub Crea_nd_flexline()
        'Dim oTrans As New Transaccional.Conexion("FlexLine")
        'Dim ClsGen As New ClasesGenerales.General
        'Dim lsSQL As String

        Try

            'oTrans.open()
            'lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & lote.Trim & "','" & gs_usuario & "'," & 6
            'oTrans.Obtiene(lsSQL)

            nd_lote = lote.Trim

            Crea_Partida()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '   oTrans.close()
            '  oTrans = Nothing
            ' ClsGen = Nothing
        End Try
        '(c) 20190613 Valida Correlativos
        ' If validaCorrelativos() Then

        'Else
        'MessageBox.Show("No Se Procesara la Partida Contable, Realice las Correcciones", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        'Me.Close()
    End Sub

    Private Function validaCorrelativos() As Boolean
        '    Dim lbValido As Boolean = True
        Dim clsgen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtDetalle As DataTable
        Dim cuenta As Integer = 0

        Try
            dtDetalle = dgv_Detalle.DataSource
            For Each dr As DataRow In dtDetalle.Rows

                lsSQL = "select EMPRESA, Fecha, TIPO_COMPROBANTE, CORRELATIVO from CON_ENCCOM where EMPRESA='" & gs_empresa &
                    "' and TIPO_COMPROBANTE='nota de debito' and CORRELATIVO='" & dr.Item("NotaDebito").ToString() & "' and PERIODO=YEAR('" & dr.Item("Fecha").ToString() & "')"
                dt = clsgen.selectQuery("FlexLine", lsSQL)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("El Comprobante " & dr.Item("NotaDebito").ToString() & "  ya Existe En Contabilidad con Fecha " & dt.Rows(0).Item("Fecha").ToString & ", Debe Cambiar El Correlativo", "Validacion de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cuenta = cuenta + 1
                End If
            Next

            If cuenta > 0 Then
                lbValidaCorrelativo = True
            Else
                lbValidaCorrelativo = False
            End If

        Catch ex As Exception
            lbValidaCorrelativo = False

        Finally
            clsgen = Nothing
        End Try

    End Function

    Private Sub valida_valores()
        '    Dim lbValidom As Boolean = True
        Dim clsgen As New ClasesGenerales.General
        '        Dim lsSQL As String
        Dim dtDetalle As DataTable
        Dim cuentavalores As Integer = 0

        Try
            dtDetalle = dgv_Detalle.DataSource
            For Each dr As DataRow In dtDetalle.Rows

                'lsSQL = "select EMPRESA, Fecha, TIPO_COMPROBANTE, CORRELATIVO from CON_ENCCOM where EMPRESA='" & gs_empresa &
                '    "' and TIPO_COMPROBANTE='nota de debito' and CORRELATIVO='" & dr.Item("NotaDebito").ToString() & "' and PERIODO=YEAR('" & dr.Item("Fecha").ToString() & "')"
                'dt = clsgen.selectQuery("FlexLine", lsSQL)

                If dr.Item("Monto") = 0 Then
                    MessageBox.Show("El Comprobante " & dr.Item("NotaDebito").ToString() & " Contiene Valores a Cero, No puede ser Procesado..", "Validacion de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cuentavalores = cuentavalores + 1
                ElseIf dr.Item("Fecha") = "01/01/1900" Then
                    MessageBox.Show("El Comprobante " & dr.Item("NotaDebito").ToString() & " Contiene Fechas Invalidas, No puede ser Procesado..", "Validacion de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cuentavalores = cuentavalores + 1
                End If
            Next

            If cuentavalores > 0 Then
                lbValidaValores = True
            Else
                lbValidaValores = False
            End If

        Catch ex As Exception
            lbValidaValores = False

        Finally
            clsgen = Nothing
        End Try


    End Sub
    Private Sub Crea_Partida()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim Cuenta As Integer = 0
        Dim Cuenta2 As Integer = 0
        Dim SQL As String = ""
        Dim lsSQL As String

        If MessageBox.Show("Se Procederá a Crear Partida en FlexLine?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try
            Otrans.open()   'abre conexion
            dt = dgv_Detalle.DataSource



            For Each drv As DataRowView In dt.DefaultView

                If drv.Item("NotaDebito").ToString = "                " Then
                    Cuenta = Cuenta + 1
                ElseIf drv.Item("Fecha").ToString = "01/01/1900" Then
                    Cuenta2 = Cuenta2 + 1
                Else
                End If

                'SQL = "select EMPRESA, Fecha, TIPO_COMPROBANTE, CORRELATIVO from CON_ENCCOM where EMPRESA='" & drv.Item("Empresa").ToString() & " ' and TIPO_COMPROBANTE='nota de debito' and CORRELATIVO='" & drv.Item("NotaDebito").ToString() & "' and PERIODO=YEAR('" & drv.Item("Fecha").ToString() & "')"
                'dt = Otrans.Obtiene(SQL)
                'If dt.Rows.Count > 0 Then
                '    MsgBox("Comprobante ya Existen en la contabilidad")
                'End If

            Next

            If Cuenta + Cuenta2 > 0 Then
                MsgBox("Existen Documentos Que No Serán Centralizados", MsgBoxStyle.Information, "Información")
            End If

            dt = dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView
                '   GUARDA EN LA TABLA TEMPORAL SCM.[flexline].[Pagos_Electronicos_Guarda]
                SQL = "flexline.pa_umb_ins_Pagos_Electronicos_Guarda '" & drv.Item("Empresa").ToString() & "','" & drv.Item("NotaDebito").ToString() & "','" & drv.Item("Fecha").ToString() & "','" & drv.Item("Lote").ToString() & "','" & drv.Item("NIT").ToString() & "','" & drv.Item("Proveedor").ToString() & "','" &
                drv.Item("Tipo_Documento").ToString() & "','" & drv.Item("Referencia").ToString() & "','" & drv.Item("Monto").ToString & "','" & gs_usuario & "','N','" & cmbCuentaBanco.Text & "','" & cmbMoneda.Text & "'," & txtTasa.Text
                Otrans.Obtiene(SQL)

                nd_tipoComprobante = "NOTA DE DEBITO"
                nd_correlativo = drv.Item("NotaDebito").ToString()
                nd_fecha = drv.Item("Fecha").ToString()

            Next

            '   GENERA EL CURSO QUE CREARA LAS PARTIDAS POR PROVEEDOR
            SQL = "flexline.pa_umb_ins_Pagos_Electronicos_Cursor '" & gs_empresa & "','" & lote.Trim & "'"
            Otrans.Obtiene(SQL)

            ' GUARDA EN EL LOG QUE EL LOTE FUE CENTRALIZADO
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & lote.Trim & "','" & gs_usuario & "'," & 7
            Otrans.Obtiene(lsSQL)




            MsgBox("Partidas Creadas Satisfactoriamente", MsgBoxStyle.Information, "Creación")

            Genera_Reporte()

            dt.DefaultView.RowFilter = ""

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_Verifica_Click(sender As Object, e As EventArgs) Handles btn_Verifica.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim SQL As String = ""

        Try
            Otrans.open()
            SQL = "select EMPRESA, Fecha, TIPO_COMPROBANTE, CORRELATIVO from CON_ENCCOM where EMPRESA='" & gs_empresa & "' and TIPO_COMPROBANTE='nota de debito' and CORRELATIVO='" & tb_Verifica.Text & "' and PERIODO=YEAR('" & dtp_Fecha.Text & "')"
            dt = Otrans.Obtiene(SQL)

            If dt.Rows.Count > 0 Then
                MsgBox("Comprobante ya Existen En Contabilidad con Fecha " & dt.Rows(0).Item("Fecha").ToString & ", Debe Cambiar El Correlativo", MsgBoxStyle.Information, "Precaución")
            Else
                MsgBox("Comprobante Libre En Contabilidad...", MsgBoxStyle.Information, "Información")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub btnAplicarFecha_Click(sender As Object, e As EventArgs) Handles btnAplicarFecha.Click
        Try

            For Each dr As DataRow In dtDetalleLote.Rows
                dr.Item("fecha") = Me.dtpFechaAsignacion.Value.ToString("dd/MM/yyyy")
            Next


        Catch ex As Exception

            End Try
    End Sub

    Private Sub btnAsignarLote_Click(sender As Object, e As EventArgs) Handles btnAsignarLote.Click

        Dim clsGen As New ClasesGenerales.General
        Try

            Dim dt As DataTable
            Dim SQL As String = ""

            Try
                SQL = "pa_var_um_valida_con_enccom_comprobante '" & gs_empresa & "','" & Me.txtLoteAsigna.Text & "','" & Year(Me.dtpFechaAsignacion.Value) & "'"
                dt = clsGen.selectQuery("FlexLine", SQL)

                If dt.Rows.Count > 0 Then
                    MsgBox("Comprobante ya Existen En Contabilidad con Fecha " & dt.Rows(0).Item("Fecha").ToString & ", Debe Cambiar El Correlativo", MsgBoxStyle.Information, "Precaución")
                    '    Else
                    '       MsgBox("Comprobante Libre En Contabilidad...", MsgBoxStyle.Information, "Información")
                    Exit Sub

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
            End Try

        Catch ex As Exception

        End Try


        Dim iSelectedRow As Integer
        Try
            iSelectedRow = Me.dgv_Detalle.Rows.GetRowCount(DataGridViewElementStates.Selected)

            For i As Integer = 0 To iSelectedRow
                Me.dgv_Detalle.Item("notadebito", Me.dgv_Detalle.SelectedRows(i).Index).Value = Me.txtLoteAsigna.Text
            Next
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Genera_Reporte()

        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(4), pm_valores_consolidado(2) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(2) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("VDataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Comprobante_Lote.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@lote"
            pm_valores(1) = nd_lote

            '  pm_parametros(1) = "@TipoCom"
            ' pm_valores(1) = nd_tipoComprobante

            ' pm_parametros(2) = "@Inicial"
            'pm_valores(2) = nd_correlativo

            'pm_parametros(3) = "@Final"
            'pm_valores(3) = nd_correlativo


            'pm_parametros(4) = "@Periodo"
            'pm_valores(4) = nd_fecha.Year

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub dgv_Detalle_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_Detalle.RowsRemoved

        ' MsgBox("Fila Eliminada")
    End Sub

    Private Sub cmbBanco_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBanco.SelectedValueChanged
        carga_cuenta_banco()
    End Sub
    Private Sub cmbCuentaBanco_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCuentaBanco.SelectedValueChanged
        carga_moneda()
    End Sub

    Private Sub txtTasa_LostFocus(sender As Object, e As EventArgs) Handles txtTasa.LostFocus
        If cmbMoneda.Text <> "DOLARES" Then
            txtTasa.Text = 1.0
        End If

    End Sub
End Class