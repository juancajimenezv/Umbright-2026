Public Class Frm_PagosBI
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "ROOT"
    'Dim Ods As New DataSet
    'Public dt As DataTable

    Private Sub Frm_PagosBI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "Select Empresa, Tipo, Cuenta, Nit, Proveedor, Correo, Razon, NoFActura, Monto, Usuario, FechaModif, Tipo_Documento, Referencia from tmp_pagosBi  Where empresa = '" & gs_empresa & "'"
            dt = oTrans.Obtiene(lsSQL)
            Me.dgv_pagos.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgv_pagos, "", ",Empresa,Usuario,FechaModif,Tipo_Documento,Referencia,", ",Tipo,Cuenta,NIT,Proveedor,Monto,Correo,Razon,", "", "", "", "", True, True, 475, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub
    Private Sub Graba_Log()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()
            dt = Me.dgv_pagos.DataSource
            For Each drv As DataRowView In dt.DefaultView

                lsSQL = "exec spa_um_graba_log_pagosBI '" & drv.Item("Empresa") & "','" & drv.Item("Tipo") & "','" & drv.Item("Cuenta") & "','" & drv.Item("nit") &
                "','" & drv.Item("Proveedor") & "','" & drv.Item("Correo") & "','" & drv.Item("Razon") & "','" & drv.Item("NoFactura") & "','" & drv.Item("Monto") & "','" & gs_usuario & "','" & drv.Item("FechaModif") & "','BI','" & drv.Item("Tipo_Documento").ToString & "','" & drv.Item("Referencia").ToString & "'"
                dt = oTrans.Obtiene(lsSQL)
            Next
            '   dt.DefaultView.RowFilter = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub
    Private Function Crear_Tabla_Temporal(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn

        dt = dv.Table.Clone

        For Each dgc In Me.dgv_pagos.Columns
            If dgc.Visible = False Then
                dt.Columns.Remove(dgc.Name)
            End If
        Next

        For Each drv In dv
            dr = dt.NewRow
            For Each dc In dt.Columns
                dr.Item(dc.ColumnName) = drv.Item(dc.ColumnName)
            Next
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    Private Sub Exportar_Vista_Actual()
        Dim mExcel As New Automatizar.exportar_excel

        Dim dc As DataGridViewColumn
        Dim dt As DataTable

        Try

            dt = dgv_pagos.DataSource
            dt = Crear_Tabla_Temporal(dt.DefaultView)

            mExcel.ocultar_columnas = ""

            mExcel.sFileName = "c:\temp\BI_" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 0
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            mExcel.Nombre_Columnas = ""

            For Each dc In Me.dgv_pagos.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcelArchivo(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            mExcel = Nothing

        End Try

    End Sub

    Private Sub b_Cencela_G_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Cencela_G.Click
        Close()
    End Sub

    Private Sub b_Genera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Genera.Click
        Graba_Log()
        Exportar_Vista_Actual()
        Close()
    End Sub
End Class