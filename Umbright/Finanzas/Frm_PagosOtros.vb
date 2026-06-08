Public Class Frm_PagosOtros
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "RPINEDA"

    Private Sub Frm_PagosOtros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim sql As String

        Try

            oTrans.open()
            lsSQL = "Select * from tmp_pagosOtros  Where empresa = '" & gs_empresa & "'"
            dt = oTrans.Obtiene(lsSQL)

            Me.dgv_PagoOtros.DataSource = dt
            ClsGen.Alinear_GridView(dt, Me.dgv_PagoOtros, "", ",Empresa,Usuario,FechaModif,", ",Id,Nombre,Cod,Cuenta,Tipo,Valor,Comentario,Correo,", "", "", "", "", True, True, 475, 0)


            sql = "flexline.pa_umb_ins_Pagos_Electronicos_Update '" & gs_empresa & "'"
            oTrans.Obtiene(sql)

            sql = "flexline.pa_umb_ins_Pagos_Electronicos_Insert  '" & gs_empresa & "'"
            oTrans.Obtiene(sql)



        Catch ex As Exception
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
            dt = Me.dgv_PagoOtros.DataSource
            For Each drv As DataRowView In dt.DefaultView

                lsSQL = "exec spa_um_graba_log_pagosBI '" & drv.Item("Empresa") & "','" & drv.Item("Ti") & "','" & drv.Item("Cuenta") & "','" & drv.Item("Id") &
                "','" & drv.Item("Nombre") & "','" & drv.Item("Correo") & "','" & drv.Item("Comentario") & "','" & drv.Item("NoFactura") & "','" & drv.Item("Valor") & "','" & gs_usuario & "','" & drv.Item("FechaModif") & "','ACH','',''"
                dt = oTrans.Obtiene(lsSQL)

            Next
            dt.DefaultView.RowFilter = ""

        Catch ex As Exception
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

        For Each dgc In Me.dgv_PagoOtros.Columns
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

            dt = dgv_PagoOtros.DataSource
            dt = Crear_Tabla_Temporal(dt.DefaultView)

            mExcel.ocultar_columnas = ""

            mExcel.sFileName = "c:\temp\ACH_" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 0
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            mExcel.Nombre_Columnas = ""

            For Each dc In Me.dgv_PagoOtros.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcelArchivo(dt)
        Catch ex As Exception
        Finally

            mExcel = Nothing

        End Try

    End Sub

    Private Sub b_Genera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Genera.Click
        Graba_Log()
        Exportar_Vista_Actual()
        Close()
    End Sub

    Private Sub b_Cencela_G_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Cencela_G.Click
        Close()
    End Sub
End Class