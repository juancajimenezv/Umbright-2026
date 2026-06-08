Public Class frm_Información_Lgs
    Dim Ods As New DataSet
    Dim ds_picking As New DataSet


    Private Sub Crea_Tabla()
        Dim dt As New DataTable("Pick_Actual")

        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaUModif", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Hora", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha_Impresion_Picking", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Año", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Canal", GetType(String)))
        dt.Columns.Add(New DataColumn("Tiempo", GetType(String)))
        dt.Columns.Add(New DataColumn("Minutos", GetType(Double)))

        ds_picking.Tables.Add(dt.Copy)

        'dt.TableName = "re_impresion"
        ' ds_picking.Tables.Add(dt.Copy)

        dgv_pdaact.DataSource = dt

    End Sub



    Private Sub btn_ControlRutas_Click(sender As Object, e As EventArgs) Handles btn_ControlRutas.Click

        ProgressBar1.Value = 0
        Label4.Visible = True
        Label5.Visible = True
        Label5.Text = "0.00%"
        ProgressBar1.Visible = True
        Generar()
    End Sub

    Private Sub Generar()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsSQL2, lsSQL3, lsSQL4, lsSQL5, lsSQL6, lsSQL7, lsSQL8, lsSQL9 As String
        Dim dt, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9 As DataTable
        Dim dr, dr_aux As DataRow

        lb_inicial.Text = Now.ToShortTimeString

        Try

            otrans.open()    'abre conexion

            'ds_picking.Tables("Pick_Actual").DefaultView.RowFilter = "Unidades > 0"
            ds_picking.Tables("Pick_Actual").Rows.Clear()

            Barra()
            lsSQL = "pa_gen_um_Informacion_Lgs '" & dtp_FechaI.Text & "','" & dtp_FechaF.Text & "'"
            otrans.Obtiene(lsSQL)

            Barra()
            lsSQL2 = "select * from SCM.FLEXLINE.Info_lgs_Picking_Detalle_Actual order by fecha"
            dt2 = otrans.Obtiene(lsSQL2)
            '     dgv_pdaact.DataSource = dt2


            For Each dr In dt2.Rows
                dr_aux = ds_picking.Tables("Pick_Actual").NewRow

                dr_aux.Item("Empresa") = dr.Item("Empresa")
                dr_aux.Item("TipoDocto") = dr.Item("TipoDocto")
                dr_aux.Item("Numero") = dr.Item("Numero")
                dr_aux.Item("Fecha") = dr.Item("Fecha")
                dr_aux.Item("Bodega") = dr.Item("Bodega")
                dr_aux.Item("FechaUModif") = dr.Item("FechaUModif")
                dr_aux.Item("Hora") = dr.Item("Hora")
                dr_aux.Item("Fecha_Impresion_Picking") = dr.Item("Fecha_Impresion_Picking")
                dr_aux.Item("Cantidad") = dr.Item("Cantidad")
                dr_aux.Item("Unidades") = dr.Item("Unidades")
                dr_aux.Item("Año") = dr.Item("Año")
                dr_aux.Item("Canal") = dr.Item("Canal")
                dr_aux.Item("Tiempo") = dr.Item("Tiempo")
                dr_aux.Item("Minutos") = dr.Item("Minutos")
                ds_picking.Tables("Pick_Actual").Rows.Add(dr_aux)
            Next

            Me.dgv_pdaact.DataSource = ds_picking.Tables("Pick_Actual")



            Barra()
            lsSQL3 = "select * from SCM.FLEXLINE.Info_lgs_Picking_Detalle_Anterior order by fecha"
            dt3 = otrans.Obtiene(lsSQL3)
            dgv_Pdaant.DataSource = dt3


            Barra()
            lsSQL4 = "select * from SCM.FLEXLINE.Info_lgs_Picking_Resumen "
            dt4 = otrans.Obtiene(lsSQL4)
            dgv_ResPicking.DataSource = dt4

            Barra()
            lsSQL5 = "select * from  SCM.FLEXLINE.Info_lgs_Picking_Tabla_Actual"
            dt5 = otrans.Obtiene(lsSQL5)
            dgv_TablaActual.DataSource = dt5

            Barra()
            lsSQL6 = "select * from  SCM.FLEXLINE.Info_lgs_Picking_Tabla_Anterior"
            dt6 = otrans.Obtiene(lsSQL6)
            dgv_TablaAnterior.DataSource = dt6

            Barra()
            lsSQL7 = "select * from SCM.FLEXLINE.Info_lgs_Devoluciones_Anterior"
            dt7 = otrans.Obtiene(lsSQL7)
            dgv_DevAnterior.DataSource = dt7

            Barra()
            lsSQL8 = "select * from SCM.FLEXLINE.Info_lgs_Devoluciones_Actual"
            dt8 = otrans.Obtiene(lsSQL8)
            dgv_DevActual.DataSource = dt8


            Barra()
            lsSQL9 = "select * from SCM.FLEXLINE.Info_Lgs_Dev_Resumen"
            dt9 = otrans.Obtiene(lsSQL9)
            dgv_DevResumen.DataSource = dt9


            lb_final.Text = Now().ToShortTimeString
            MsgBox("Proceso Generado Con Exito!!")

            'ProgressBar1.Value = 0
            'ProgressBar1.Visible = False
            'Label4.Visible = False
            'Label5.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Barra()
        ProgressBar1.Increment(12.5)
        Label5.Text = ProgressBar1.Value.ToString & "%"
        '   MsgBox(ProgressBar1.Value.ToString)

    End Sub

    Private Sub frm_Información_Lgs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Visible = False
        Label5.Visible = False
        ProgressBar1.Visible = False
        Crea_Tabla()
    End Sub

    Private Function Crear_Tabla_Temporal(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_pdaact.Columns
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
            dt = dgv_pdaact.DataSource
            dt = Crear_Tabla_Temporal(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Picking_Detalle_Actual.xls" ' & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_pdaact.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Sub btn_Exportar_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        Exportar_Vista_Actual()
        Exporta_Vista_2()
        Exporta_Vista_3()
        Exporta_Vista_4()
        Exporta_Vista_5()
        Exporta_Vista_6()
        Exporta_Vista_7()
        Exporta_Vista_8()
    End Sub

    Private Function Crea_Tabla_2(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_Pdaant.Columns
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

    Private Sub Exporta_Vista_2()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_Pdaant.DataSource
            dt = Crea_Tabla_2(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Picking_Detalle_Anterior.xls" '& Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_Pdaant.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Function Crea_Tabla_3(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_ResPicking.Columns
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

    Private Sub Exporta_Vista_3()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_ResPicking.DataSource
            dt = Crea_Tabla_3(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Picking_Resumen.xls" ' & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_ResPicking.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Function Crea_Tabla_4(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_TablaActual.Columns
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

    Private Function Crea_Tabla_5(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_TablaAnterior.Columns
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

    Private Sub Exporta_Vista_4()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_TablaActual.DataSource
            dt = Crea_Tabla_4(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Flujo_Facturacion_Actual.xls" '" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_TablaActual.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Sub Exporta_Vista_5()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_TablaAnterior.DataSource
            dt = Crea_Tabla_5(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Flujo_Facturacion_Anterior.xls" '& 'Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_TablaAnterior.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Function Crea_Tabla_6(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_DevAnterior.Columns
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

    Private Sub Exporta_Vista_6()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_DevAnterior.DataSource
            dt = Crea_Tabla_6(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Devoluciones_Anterior.xls" ' & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_DevAnterior.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub


    Private Function Crea_Tabla_7(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_DevActual.Columns
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

    Private Sub Exporta_Vista_7()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_DevActual.DataSource
            dt = Crea_Tabla_7(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Devoluciones_Actual.xls" ' & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_DevActual.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub

    Private Function Crea_Tabla_8(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn
        dt = dv.Table.Clone
        For Each dgc In Me.dgv_DevResumen.Columns
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

    Private Sub Exporta_Vista_8()
        Dim mExcel As New Automatizar.exportar_excel
        Dim dc As DataGridViewColumn
        Dim dt As DataTable
        Try
            dt = dgv_DevResumen.DataSource
            dt = Crea_Tabla_8(dt.DefaultView)
            mExcel.ocultar_columnas = ""
            mExcel.sFileName = "c:\temp\Devoluciones_Resumen.xls" ' & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}
            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dgv_DevResumen.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            mExcel = Nothing
        End Try
    End Sub
End Class