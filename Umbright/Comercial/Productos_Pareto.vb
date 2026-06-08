Public Class Productos_Pareto
    Dim _dtDetalle As DataTable
    'Dim gs_empresa As String = "DMARTE1"


    Private Sub Productos_Pareto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gs_empresa = "ALAMSA" Then
            lb_Empresa.Text = "NEGOCIOS GENERALES ALFREDO LAMPORT, S.A."

        ElseIf gs_empresa = "CODICASA" Then
            lb_Empresa.Text = "COMPAÑIA DE DISTRIBUCION CENTROAMERICANA, S.A."

        ElseIf gs_empresa = "DIUVA" Then
            lb_Empresa.Text = "DISTRIBUIDORA LA UVA, S.A."

        ElseIf gs_empresa = "DMARTE1" Then
            lb_Empresa.Text = "DISTRIBUIDORA MARTE, S.A."

        ElseIf gs_empresa = "VINOTECA" Then
            lb_Empresa.Text = "VINOTECA, S.A."

        Else
            lb_Empresa.Text = "EMPRESA NO VALIDA"
        End If

        CreaTabla()
        Llena_Detalle()
    End Sub

    Private Sub CreaTabla()
        _dtDetalle = New DataTable("Tmp_Detalle")

        _dtDetalle.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Producto", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Glosa", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("UxC", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Pareto", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Bu", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Presupuesto_Compras", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("Presupuesto_Ventas", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("Modificado", GetType(Boolean)))

    End Sub

    Private Sub Llena_Detalle()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Productos_Pareto '" & gs_empresa & "'"

            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtDetalle.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtDetalle.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Glosa") = dr.Item("Glosa")
                dr2.Item("UxC") = dr.Item("UxC")
                dr2.Item("Pareto") = dr.Item("Pareto")
                dr2.Item("Bu") = dr.Item("Bu")
                dr2.Item("Presupuesto_Compras") = dr.Item("Presupuesto_Compras")
                dr2.Item("Presupuesto_Ventas") = dr.Item("Presupuesto_Ventas")
                dr2.Item("Modificado") = False
                _dtDetalle.Rows.Add(dr2)

            Next

            Me.dgv_Detalle.DataSource = _dtDetalle    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Detalle, ",Producto,Glosa,UxC,Pareto,Bu,Presupuesto_Compras,Presupuesto_Ventas,", ",Empresa", ",Producto,Glosa,UxC,Presupuesto_Compras,Presupuesto_Ventas,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Busca()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_vb_Productos_Pareto_Busca '" & gs_empresa & "','" & tb_Producto.Text & "','" & tb_Glosa.Text & "','" & tb_Pareto.Text & "','" & tb_Bu.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtDetalle.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtDetalle.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Glosa") = dr.Item("Glosa")
                dr2.Item("UxC") = dr.Item("UxC")
                dr2.Item("Pareto") = dr.Item("Pareto")
                dr2.Item("Bu") = dr.Item("Bu")
                dr2.Item("Presupuesto_Compras") = dr.Item("Presupuesto_Compras")
                dr2.Item("Presupuesto_Ventas") = dr.Item("Presupuesto_Ventas")
                dr2.Item("Modificado") = False
                _dtDetalle.Rows.Add(dr2)

            Next

            Me.dgv_Detalle.DataSource = _dtDetalle
            clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Detalle, ",Producto,Glosa,UxC,Pareto,Bu,Presupuesto_Compras,Presupuesto_Ventas,", ",Empresa", ",Producto,Glosa,UxC,Presupuesto_Compras,Presupuesto_Ventas,", "", "", "", "", True, True, 275, 0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Producto_Enter(sender As Object, e As EventArgs) Handles tb_Producto.Enter
        If (Not String.IsNullOrEmpty(tb_Producto.Text)) Then
            tb_Producto.SelectionStart = 0
            tb_Producto.SelectionLength = tb_Bu.Text.Length
        End If
    End Sub

    Private Sub tb_Producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca()
        End If
    End Sub

    Private Sub tb_Glosa_Enter(sender As Object, e As EventArgs) Handles tb_Glosa.Enter
        If (Not String.IsNullOrEmpty(tb_Glosa.Text)) Then
            tb_Glosa.SelectionStart = 0
            tb_Glosa.SelectionLength = tb_Bu.Text.Length
        End If
    End Sub

    Private Sub tb_Glosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Glosa.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca()
        End If
    End Sub

    Private Sub tb_Pareto_Enter(sender As Object, e As EventArgs) Handles tb_Pareto.Enter
        If (Not String.IsNullOrEmpty(tb_Pareto.Text)) Then
            tb_Pareto.SelectionStart = 0
            tb_Pareto.SelectionLength = tb_Bu.Text.Length
        End If
    End Sub

    Private Sub tb_Pareto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Pareto.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca()
        End If
    End Sub

    Private Sub tb_Bu_Enter(sender As Object, e As EventArgs) Handles tb_Bu.Enter
        If (Not String.IsNullOrEmpty(tb_Bu.Text)) Then
            tb_Bu.SelectionStart = 0
            tb_Bu.SelectionLength = tb_Bu.Text.Length
        End If

    End Sub

    Private Sub tb_Bu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Bu.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca()
        End If
    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("Se Actualizarán Los Productos Modificados ?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Me.Close()

        Else

            Try

                Otrans.open()   'abre conexion

                _dtDetalle.DefaultView.RowFilter = "modificado = true"
                For Each drv As DataRowView In _dtDetalle.DefaultView


                    'If drv.Item("Movimiento") = True Then
                    ls_sql = "pa_upd_um_Producto_Pareto_Actualiza '" & drv.Item("Empresa").ToString & "','" & drv.Item("Producto") & "','" & drv.Item("Pareto") & "','" & drv.Item("Bu") & "','" & gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)


                Next
                'dt.DefaultView.RowFilter = ""
                MsgBox("Productos Actualizados Con Exito!!", MsgBoxStyle.Information, "Actualización")
                Me.dgv_Detalle.DataSource = Nothing

            Catch ex As Exception
            Finally

                Otrans.close()
                Otrans = Nothing

            End Try
        End If
    End Sub

    Private Sub dgv_Detalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_Detalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_Detalle.Rows(rowIndex)


                If Me.dgv_Detalle.Item("modificado", rowIndex).Value Then
                    Me.dgv_Detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red

                End If
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub dgv_Detalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Detalle.CellValueChanged
        Dim iRow As Integer = e.RowIndex

        Try
            If iRow > -1 Then
                Me.dgv_Detalle.Item("Modificado", iRow).Value = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub btn_Cargar_Click(sender As Object, e As EventArgs) Handles btn_Cargar.Click
        CreaTabla()
        Llena_Detalle()
    End Sub
End Class