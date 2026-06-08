Public Class frmMantenedorProductosLista

    Public ods As New DataSet
    Public psProducto As String
    Public psGlosa As String
    Public dtListas As DataTable
    Public pbAplicar As Boolean

    Private Sub crearEstructura()
        Dim dt As New DataTable("Precios")

        dt.Columns.Add(New DataColumn("ListaPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(Date)))
        dt.Columns.Add(New DataColumn("precio_anterior", GetType(Double)))
        dt.Columns.Add(New DataColumn("precio_nuevo", GetType(Double)))

        Ods.Tables.Add(dt.Copy)

    End Sub

    Private Sub llenarInformacion()

        Dim ls_sql As String
        Dim drAux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General


        ls_sql = "pa_sel_um_listapreciod '" & gs_empresa & "','" & _
                 psProducto & "',NULL"



        otrans.open()
        dt = otrans.Obtiene(ls_sql)
        otrans.close()
        otrans = Nothing

        For Each dr As DataRow In dtListas.Rows
            dt.DefaultView.RowFilter = "lisprecio = '" & dr.Item("lisprecio").ToString & "'"
            drAux = ods.Tables("Precios").NewRow
            drAux.Item("ListaPrecio") = dr.Item("lisprecio")
            If dt.DefaultView.Count > 0 Then
                Try

                    drAux.Item("precio_anterior") = Double.Parse(dt.DefaultView(0).Item("valor"))
                    drAux.Item("vigencia") = dt.DefaultView(0).Item("fec_final")
                Catch ex As Exception
                    drAux.Item("precio_anterior") = 0
                End Try
            Else
                drAux.Item("precio_anterior") = 0
            End If

            ods.Tables("Precios").Rows.Add(drAux)

        Next
        Me.dgvProductos.DataSource = ods.Tables("precios")

        clsgen.Alinear_GridView(ods.Tables("precios"), Me.dgvProductos, ",listaprecio,precio_anterior,precio_nuevo,vigencia,", "", ",listaprecio,precio_anterior,vigencia,", "", "", "", "", True, True, 250, 0)

        'ls_sql = "fec_final > '" & Now & "'"

        'otabla.DefaultView.RowFilter = ls_sql

        'Dim oform As New frm_resultado
        'Dim clsgen As New ClasesGenerales.General
        'oform.dgv_resultado.DataSource = otabla
        'oform.dgv_resultado.ReadOnly = True
        'oform.Text = "Listas de Precios .:"
        ''        clsgen.Alinea_Grid(otabla, oform.DataGrid1, otabla.TableName, 3, 250, 0, True, True, ",lisprecio,valor,fec_final,vigente,oferta,", True, "")

        'clsgen = Nothing

        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
        Me.Label1.Text = psProducto & " " & psGlosa

    End Sub

    Private Sub frmMantenedorProductosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarInformacion()
    End Sub

    Private Sub dgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub

    Private Sub dgvProductos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvProductos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                'therow = Me.dgvProductos.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If

                If Me.dgvProductos.Columns(colIndex).Name.ToLower = "precio_nuevo" Then
                    If Me.dgvProductos.Item("precio_nuevo", e.RowIndex).Value.ToString > 0 And _
                        Me.dgvProductos.Item("precio_nuevo", e.RowIndex).Value.ToString < Me.dgvProductos.Item("precio_anterior", e.RowIndex).Value.ToString Then
                        Me.dgvProductos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvProductos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellValueChanged

    End Sub

    Private Sub dgvProductos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProductos.DataError

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        pbAplicar = True
        Me.Close()

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        pbAplicar = False
        Me.Close()
    End Sub
End Class