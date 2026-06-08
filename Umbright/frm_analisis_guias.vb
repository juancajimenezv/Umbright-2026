Public Class frm_analisis_guias
    Public dt_recibe As DataTable
    Public ds_guia As DataSet


    Private Sub Crear_Estructura()
        Dim dt As DataTable
        ds_guia = New DataSet
        dt = New DataTable("detalle_guia")



        dt.Columns.Add(New DataColumn("tipo_docto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("comentario_factura", GetType(String)))

        ds_guia.Tables.Add(dt)
        Me.dgv_8020.DataSource = ds_guia.Tables("detalle_guia")
    End Sub

    Private Sub frm_analisis_guias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Mostrar_registro()


    End Sub
    Private Sub Mostrar_registro()
        Dim ls_sql, sql As String
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim clsGen As New ClasesGenerales.General
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("flexline")

        otrans.open()

        Try
            ds_guia.Tables("detalle_guia").Rows.Clear()
            Sql = "delete from liquidacionpilotoanalisis"
            otrans.Obtiene(Sql)
            For i As Integer = 0 To dt_recibe.Rows.Count - 1
                ls_sql = "pa_sel_um_gen_control_transporte_detalle_temporalanalisis '" & dt_recibe.Rows(i).Item("empresa").ToString & "','" & dt_recibe.Rows(i).Item("numero").ToString & "',1"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    'ls_sql = "insert into liquidacionpilotoanalisis(empresa,tipodocto,numero,tipodoctoorigen,numeroorigen,total,peso,ctacte,nombre_cliente) " & _
                    '     " values('" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "','" & dr.Item("tipodoctoOrigen") & "','" & _
                    '     dr.Item("numeroOrigen") & "'," & dr.Item("total") & "," & dr.Item("peso") & ",'" & dr.Item("ctacte") & "','" & dr.Item("nombre_cliente") & "')"
                    'otrans.Ingresa(ls_sql)
                    ls_sql = "pa_ins_um_liquidacionPilotoanalisis  " & dr.Item("total") & "," & dr.Item("peso") & ",'" & dr.Item("ctacte") & "'"
                    otrans.Ingresa(ls_sql)

                Next
            Next

            ls_sql = "select sum(a.total)as total,a.ctacte from liquidacionpilotoanalisis a group by a.ctacte order by a.total desc"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows

                ls_sql = "select top 1  case " & _
    "when ltrim(razonSocial) <> 'OPERADORA DE TIENDAS, S.A.' then  " & _
                "  razonSocial  " & _
    "  else " & _
                "   giro " & _
 " end  as nombre_cliente,direccionenvio from ctacte where tipoctacte='CLIENTE' and empresa<>'DEMO' and ctacte='" & dr.Item("ctacte") & "'"
                dt2 = otrans.Obtiene(ls_sql)
                dr_aux = ds_guia.Tables("detalle_guia").NewRow
                'dr.Item("tipodoctoOrigen")
                dr_aux.Item("numero") = "" 'dr.Item("numeroOrigen")
                dr_aux.Item("nombre") = dt2.Rows(0).Item("nombre_cliente")
                dr_aux.Item("direccion") = dt2.Rows(0).Item("direccionenvio")
                dr_aux.Item("monto") = dr.Item("total")
                dr_aux.Item("peso") = 0 'dr.Item("peso")
                dr_aux.Item("comentario_factura") = "" 'dr.Item("comentario1")
                dr_aux.Item("monto") = dr.Item("total")
                ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)

            Next
            clsGen.Alinear_GridView(ds_guia.Tables("detalle_guia"), Me.dgv_8020, ",nombre,direccion,monto,peso,", ",numero,tipodocto,comentario_factura,peso,", "", "", "", ",nombre=275,direccion=275,monto=75,", "", True, True, 200, 0)
            Me.totalizar(ds_guia.Tables("detalle_guia"))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            ' Colorear_Grid()
            '  Recalcular_Totales(ds_guia.Tables("detalle_guia"))

        End Try

    End Sub
    Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, subtotal_monto, subtotal_monto2 As Double
        total = 0
        subtotal_monto = 0
        subtotal_monto2 = 0


        Try

            For Each dr In otabla.Rows
                Try
                    If dr.Item("monto").ToString.Length > 0 Then
                        subtotal_monto += dr.Item("monto")
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each dr In otabla.Rows
                Try
                    If dr.Item("monto").ToString.Length > 0 Then
                        subtotal_monto2 = dr.Item("monto")
                        total += (subtotal_monto2 / subtotal_monto) * 100
                        If total <= 80.99 Then
                            dr.Item("peso") = 1
                        Else
                            dr.Item("peso") = 0
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Sub dgv_8020_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_8020.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow
        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_8020.Rows(rowIndex)
                If Me.dgv_8020.Item("peso", e.RowIndex).Value = 1 Then
                    therow.DefaultCellStyle.ForeColor = Color.DarkBlue
                Else
                    therow.DefaultCellStyle.ForeColor = Color.DarkRed
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class