Public Class frmLiquidacionCajaP
    Dim ds As New DataSet
    Public pEmpresa As String
    Public pTipodocto As String
    Public pNumero As String
    Public pMonto As Double


    Private Sub frmLiquidacionCajaP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crea_estructura()
        llena_combobox()
        lb_tipodocto.Text = pTipodocto
        lb_numero.Text = pNumero
        lb_totalDocto.Text = Format(pMonto, "##,###,##0.00")
        btn_guardar.Enabled = False
    End Sub

    Private Sub crea_estructura()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("Codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))

        dt.TableName = "pagos"

        If ds.Tables.Contains("pagos") Then ds.Tables.Remove("pagos")
        ds.Tables.Add(dt.Copy)

        dgv_detalle.DataSource = dt

    End Sub

    Private Sub llena_combobox()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        Try
            ls_sql = "pa_var_um_forma_pago "
            ldt_table = oTransaccion.Obtiene(ls_sql)

            ldt_table.TableName = "GBOD"
            Me.cb_formaPago.DisplayMember = "forma_pago"
            Me.cb_formaPago.ValueMember = "forma_pago"
            Me.cb_formaPago.DataSource = ldt_table.DefaultView

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTransaccion.close()
            oTransaccion = Nothing
        End Try


    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        Agregar()
    End Sub

    Private Sub Agregar()
        Dim dr_aux As DataRow

        Try
            dr_aux = ds.Tables("pagos").NewRow
            dr_aux.Item("Codigo") = cb_formaPago.Text
            dr_aux.Item("Monto") = txt_monto.Text

            ds.Tables("pagos").Rows.Add(dr_aux)

            Me.dgv_detalle.DataSource = ds.Tables("pagos")
            ds.Tables("pagos").DefaultView.RowFilter = ""

            Total()
            'btn_Guardar.Enabled = True
            'GroupBox2.Enabled = True
            txt_monto.Text = "0.00"
            txt_monto.SelectAll()
            btn_guardar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub


    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable

        Try

            dt = Me.dgv_detalle.DataSource
            ntotal = dt.Compute("sum(Monto)", "Monto>0")
            Me.lb_pagos.Text = Format(ntotal, "##,###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Guardar_Dgv()
    End Sub

    Private Sub Guardar_Dgv()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim n As Integer = 0
        Try

            Otrans.open()   'abre conexion
            dt = dgv_detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView
                If drv.Item("Codigo").ToString <> Nothing Then
                    n = n + 1

                    ls_sql = "exec pa_ins_um_liquidacion_muestra_cuadre_pagos '" & pEmpresa & "','" & lb_tipodocto.Text & "','" &
                    lb_numero.Text & "'," & n & ",'" & drv.Item("Codigo").ToString & "'," & drv.Item("Monto").ToString & ",'" & gs_usuario & "'"
                    Otrans.Ingresa(ls_sql)

                Else

                End If
            Next

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
End Class