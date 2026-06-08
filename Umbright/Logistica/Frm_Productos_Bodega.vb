Public Class Frm_Productos_Bodega
    Dim _dtDetalle As DataTable
    'Dim gs_empresa As String = "DIUVA"

    Private Sub Frm_Productos_Bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        _dtDetalle.Columns.Add(New DataColumn("Peso", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("Etiquetas", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Cajas_x_Tarima", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Cajas_x_Cama", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Camas_x_Tarima", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Cuarto_Frio", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("InnerPack_Uni", GetType(Integer)))
        _dtDetalle.Columns.Add(New DataColumn("InnerPack_Des", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("InnerPack_Min", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("Existencia", GetType(String)))
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
            lsSQL = "spa_Productos_Bodega '" & gs_empresa & "'"

            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtDetalle.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtDetalle.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Glosa") = dr.Item("Glosa")
                dr2.Item("UxC") = dr.Item("UxC")
                dr2.Item("Peso") = dr.Item("Peso")
                dr2.Item("Etiquetas") = dr.Item("Etiquetas")
                dr2.Item("Cajas_x_Tarima") = dr.Item("Cajas_x_Tarima")
                dr2.Item("Cajas_x_Cama") = dr.Item("Cajas_x_Cama")
                dr2.Item("Camas_x_Tarima") = dr.Item("Camas_x_Tarima")
                dr2.Item("Cuarto_Frio") = dr.Item("Cuarto_Frio")
                dr2.Item("Existencia") = dr.Item("Existencia")
                dr2.Item("InnerPack_Uni") = dr.Item("Un_x_InnerPack")
                dr2.Item("InnerPack_Des") = dr.Item("Desc_InnerPack")
                dr2.Item("InnerPack_Min") = dr.Item("Min_InnerPack")

                dr2.Item("Modificado") = False
                _dtDetalle.Rows.Add(dr2)

            Next

            Me.dgv_Detalle.DataSource = _dtDetalle    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Detalle, ",Producto,Glosa,UxC,Peso,Etiquetas,Cajas_x_Tarima,Cajas_x_Cama,Camas_x_Tarima,Cuarto_Frio,InnerPack_Uni,InnerPack_Des,InnerPack_Min,Existencia,", ",Empresa", ",Producto,Glosa,UxC,Existencia,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Actualiza()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("Se Actualizarán Los Productos Modificados ?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            cargar()

        Else

            Try

                Otrans.open()   'abre conexion

                _dtDetalle.DefaultView.RowFilter = "modificado = true"
                For Each drv As DataRowView In _dtDetalle.DefaultView


                    'If drv.Item("Movimiento") = True Then
                    ls_sql = "exec spa_Actualiza_Productos_Bodega '" & drv.Item("Empresa") & "','" & drv.Item("Producto") & "','" & drv.Item("Peso") & "','" & drv.Item("Etiquetas") &
                        "','" & drv.Item("Cajas_x_Tarima") & "','" & drv.Item("Cajas_x_Cama") & "','" &
                        drv.Item("Camas_x_Tarima") & "','" & drv.Item("Cuarto_Frio") & "','" &
                        drv.Item("InnerPack_Uni") & "','" &
                        drv.Item("InnerPack_Des") & "','" &
                        drv.Item("InnerPack_Min") & "','" &
                        gs_usuario & "'"
                    Otrans.Ingresa(ls_sql)


                Next
                'dt.DefaultView.RowFilter = ""
                MsgBox("Productos Actualizados Con Exito!!", MsgBoxStyle.Information, "Actualización")
                Me.dgv_Detalle.DataSource = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.Message)
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
                Me.dgv_Detalle.Item("modificado", iRow).Value = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Imprimir()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(0) As String
        Dim pm_conexion(0) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt


        Try

            pm_conexion = ClsGen.Parametros_Conexion("Dataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Logistica\Bodega\Informe de Productos 2.rpt"

            pm_parametros(0) = "?Empresa"
            pm_valores(0) = gs_empresa

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub btn_Imprimir_Click(sender As Object, e As EventArgs) Handles btn_Imprimir.Click
        Imprimir()
    End Sub


    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Me.Actualiza()
    End Sub

    Private Sub btn_Cargar_Click(sender As Object, e As EventArgs) Handles btn_Cargar.Click
        cargar()
    End Sub

    Private Sub cargar()
        CreaTabla()
        Llena_Detalle()
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub dgv_Detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Detalle.CellContentClick

    End Sub
End Class