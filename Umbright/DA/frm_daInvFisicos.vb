Imports System.Windows.Forms
Public Class frm_daInvFisicos
    Dim dua As String
    Dim ods As DataSet
    Dim listaProducto As Collection
    Dim listaStock As Collection
    Dim listaStockCorrecto As Collection
    Dim listaStockNoCorrecto As Collection
    Dim listakeys As Collection


    Private Sub frm_invCiclicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txFecha.Text = Date.Today.ToString
        Me.listaProducto = New Collection
        Me.listaStock = New Collection
        Me.listaStockCorrecto = New Collection
        Me.listaStockNoCorrecto = New Collection
        Me.listakeys = New Collection

        getHistorialIngresos()
    End Sub


    Private Sub estructuraDetalle()
        Dim dt As DataTable

        ods = New DataSet

        dt = New DataTable("productos")

        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("dua", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))

        ods.Tables.Add(dt.Copy)
    End Sub
    Private Sub btnDuaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuaDetalle.Click
        tabs.SelectedIndex = 0
        getProductos()
    End Sub
    Private Sub getProductos()
        Dim ls_sql, ls_sql2 As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General()
        Dim dt As DataTable
        Dim ds As DataSet
        ds = New DataSet


        Me.dua = ""

        If (faltaArreglar()) Then
            ls_sql = "pa_sel_um_dua_reservas_detalle '" & txFecha.Text & "','" & gs_empresa & "'"
            ls_sql2 = "pa_sel_um_dua_reservas_detalle_custom '" & txFecha.Text & "','" & gs_empresa & "'"
            estructuraDetalle()
            Try
                otrans.open()
                dt = otrans.Obtiene(ls_sql2)
                If (dt.Rows.Count.Equals(0)) Then
                    dt = otrans.Obtiene(ls_sql)
                End If

                dt.TableName = "reservas"
                ds.Tables.Add(dt.Copy)

                Dim i As Integer
                i = 0
                For Each dr As DataRow In ds.Tables("reservas").Rows
                    Dim draux As DataRow
                    draux = ods.Tables("productos").NewRow()
                    draux.Item("empresa") = gs_empresa
                    draux.Item("dua") = ds.Tables("reservas").Rows.Item(i).Item("dua")
                    draux.Item("producto") = ds.Tables("reservas").Rows.Item(i).Item("producto")
                    draux.Item("descripcion") = ds.Tables("reservas").Rows.Item(i).Item("descripcion")
                    draux.Item("cantidad") = 0
                    ods.Tables("productos").Rows.Add(draux)
                    i = i + 1
                Next

                Me.dg_productos.DataSource = ods.Tables("productos")
                clsgen.Alinear_GridView(ods.Tables("productos"), Me.dg_productos, "", "", ",empresa,dua,producto,descripcion,", "", "", "", "", False, True, 350, 50)
                dg_productos.Columns("empresa").SortMode = DataGridViewColumnSortMode.NotSortable
                dg_productos.Columns("dua").SortMode = DataGridViewColumnSortMode.NotSortable
                dg_productos.Columns("producto").SortMode = DataGridViewColumnSortMode.NotSortable
                dg_productos.Columns("descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
                dg_productos.Columns("cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            Catch ex As Exception
            Finally
                If (dg_productos.Rows.Count = 0) Then
                    MessageBox.Show("No hay movimientos para mostrar de fecha: " & txFecha.Text, "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                otrans.close()
                otrans = Nothing
                dt = Nothing
                ds = Nothing
            End Try
        Else
            Me.dg_productos.DataSource = New DataTable
            MessageBox.Show("Se han ingresado correctamente todos los movimientos de fecha: " & txFecha.Text, "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub compararStock()
        Dim ls_sql, ls_sql2 As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ds As DataSet
        ls_sql = "pa_sel_um_existencia_dua '" & gs_empresa & "','" & txFecha.Text & "'"
        ls_sql2 = "pa_sel_um_existencia_dua '" & gs_empresa & "','" & txFecha.Text & "'"
        ds = New DataSet
        Try
            otrans.open()

            dt = otrans.Obtiene(ls_sql2)
            If (dt.Rows.Count.Equals(0)) Then
                dt = otrans.Obtiene(ls_sql)
            End If

            dt.TableName = "stockActual"
            ds.Tables.Add(dt.Copy)

            ' se va a guardar toda la información del stock actual en los arreglos
            ' públicos de la clase
            Dim i As Integer
            i = 0
            For Each dr As DataRow In ds.Tables("stockActual").Rows
                Me.listaProducto.Add(ds.Tables("stockActual").Rows.Item(i).Item("producto"), ds.Tables("stockActual").Rows.Item(i).Item("producto"))
                Me.listaStock.Add(ds.Tables("stockActual").Rows.Item(i).Item("existencia"))
                i = i + 1
            Next

            otrans.close()
        Catch ex As Exception

        Finally
            otrans = Nothing
            dt = Nothing
            ds = Nothing
        End Try

        ' ahora que ya se tiene la informacion actual, se va a comparar la info ingresada
        ' con el arreglo listaStock que contiene el stock de todos los productos, 
        ' vamos a comparar 1 con 1, 2 con 2, etc... por que el stored procedure
        ' del select tiene un order by, para que el orden siempre sea el mismo y
        ' se pueda comparar conforme a los índices

        Dim j As Integer
        'longitud = Me.listaStock.Count

        j = 0
        For Each dr As DataGridViewRow In dg_productos.Rows
            Dim stock, producto As String
            stock = dr.Cells(4).Value.ToString
            producto = dr.Cells(2).Value.ToString
            If (Me.listaProducto.Contains(producto)) Then
                Dim key, x As Integer
                key = 0
                For x = 1 To Me.listaProducto.Count
                    If (Me.listaProducto.Item(x).ToString.Equals(producto)) Then
                        key = x
                    End If
                Next
                Try
                    If (Integer.Parse(stock) = (Me.listaStock.Item(key).ToString)) Then
                        Me.listaStockCorrecto.Add(stock, Me.listaProducto.Item(key).ToString)
                        Me.listakeys.Add(key)
                        ' Si si son iguales ( el stock con el recuento son correctos ) 

                        '' Se guardan las posiciones para saber que se va a colocar 
                        '' como con "Stock correcto" y saber cuales tienen el stock
                        '' incorrecto para que en el segundo conteo, se muestren
                        '' solamente las que no cumplen con las condiciones necesarias.
                    End If
                Catch ex As Exception

                End Try

            End If
            j += 1



            'If (Me.listaStock.Item(j + 1).ToString.Equals(dg_productos.Item(4, j).Value.ToString)) Then

            '            Me.listaStockCorrecto.Add(j + 1, j + 1)
            'End If

        Next
    End Sub
    Private Sub guardarEncabezado()
        Dim empresa, usuario, dua, descripcion, ls_sql, estatus As String

        empresa = gs_empresa
        usuario = gs_usuario
        ' se le solicitará al usuario ingresar una descripción del conteo que está realizando

        dua = txFecha.Text
        descripcion = txDescripcion.Text
        estatus = "P"
        ls_sql = "pa_ins_um_inv_fisico_encabezado '" & empresa & "','" & usuario & "', '" & _
            descripcion & "', '" & dua & "', '" & estatus & "'"
        ' se guarda la info con el stored procedure.
        insertQuery(ls_sql)

    End Sub
    Private Sub guardarDetalle()
        Dim empresa, dua, producto, ls_sql As String
        Dim stock, i, cuadro As Integer

        empresa = gs_empresa
        stock = 0

        For i = 1 To dg_productos.Rows.Count
            producto = dg_productos.Item(2, i - 1).Value.ToString
            dua = dg_productos.Item(1, i - 1).Value.ToString
            Dim key, x As Integer
            key = 0
            For x = 1 To Me.listaProducto.Count
                If (Me.listaProducto.Item(x).ToString.Equals(producto)) Then
                    key = x
                End If
            Next
            Try
                stock = listaStock.Item(key)
            Catch ex As Exception
                stock = 0
            End Try


            ' aquí se tiene que hacer el guardado
            ' hay que ir a traer el stock del producto o guardarlo en un array cuando
            ' se consulta la primera vez, luego se guarda con el sp
            Try
                If Integer.Parse(listaStockCorrecto.Item(producto)) = stock Then
                    '' El stock colocado fue correcto
                    cuadro = 1
                Else
                    '' El stock colocado fue incorrecto
                    cuadro = 0
                End If
            Catch
                cuadro = 0
            End Try
            If key = 0 Then
                If (stock = cuadro) Then
                    cuadro = 1
                End If
            End If

            ls_sql = "pa_ins_um_inv_fisico_detalle '" & empresa & "','" & dua & "', '" & _
            producto & "', '" & stock & "', '0', '" & txFecha.Text & "'"
            insertQuery(ls_sql)
            ls_sql = " pa_upd_um_inv_fisico_detalle_cuadro '" & empresa & "','" & dua & "', '" & _
            producto & "', '" & cuadro & "', '" & stock & "'"
            updateQuery(ls_sql)
        Next
    End Sub
    Private Sub guardarDetalleConteo()
        Dim empresa, producto, dua, ls_sql As String
        Dim correlativo, cuenta, i As Integer
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable

        empresa = gs_empresa
        ' el correlativo hay que ir a traerlo se busca si ya existe un correlativo y se suma
        ' el correlativo se va a traer una vez por cada guardado que se le haga al conteo
        ' de los productos.
        Try

            dt = New DataTable
            otrans.open()
            ls_sql = "pa_sel_um_inv_fisico_correlativo '" & empresa & "', '" & txFecha.Text & "'"
            dt = otrans.Obtiene(ls_sql)
            correlativo = dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            correlativo = 0
        Finally
            otrans.close()
            dt = Nothing
        End Try

        For i = 0 To dg_productos.Rows.Count - 1
            ' id del producto 
            producto = dg_productos.Item(2, i).Value.ToString
            ' cuenta es cuánto conto la persona
            cuenta = dg_productos.Item(4, i).Value.ToString
            ' acá ya se almacena normalmente con el sp
            dua = dg_productos.Item(1, i).Value.ToString

            ls_sql = "pa_ins_um_inv_fisico_detalle_conteo '" & empresa & "','" & producto & "', '" & _
            dua & "', '" & correlativo & "', '" & cuenta & "','" & txFecha.Text & "'"
            insertQuery(ls_sql)
            ls_sql = "pa_upd_um_inv_fisico_detalle_conteo_cuadro '" & empresa & "','" & dua & "','" & _
            producto & "'"
            updateQuery(ls_sql)
        Next

    End Sub
    Private Sub insertQuery(ByVal sql As String)
        Dim otrans As New Transaccional.Conexion("SCM")
        Try
            otrans.open()
            otrans.Ingresa(sql)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub
    Private Sub updateQuery(ByVal sql As String)
        Dim otrans As New Transaccional.Conexion("SCM")
        Try
            otrans.open()
            otrans.Actualiza(sql)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        
        compararStock()
        guardarEncabezado()
        guardarDetalle()
        guardarDetalleConteo()
        If (faltaArreglar()) Then
            getProductos()
        Else
            Dim ls_sql As String
            ls_sql = "pa_upd_um_estatus_inv_fisico_encabezado '" & gs_empresa & "', '" _
            & txFecha.Text & "', 'S'"
            updateQuery(ls_sql)
            getProductos()
        End If

        MessageBox.Show("Su información ha sido almacenada, se mostrarán los productos cuyo stock no cuadra.", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.listaProducto = New Collection
        Me.listaStock = New Collection
        Me.listaStockCorrecto = New Collection
        Me.listaStockNoCorrecto = New Collection
        Me.listakeys = New Collection
    End Sub
    Private Sub getHistoricoDetalle(ByVal empresa As String, ByVal fecha As String)
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General()
        Dim ds As DataSet
        ds = New DataSet
        ls_sql = "pa_sel_um_inv_fisico_detalle '" & empresa & "', NULL,'" & fecha & "'"

        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "historia"
            ds.Tables.Add(dt.Copy)

            Me.dg_historial_detalle.DataSource = ds.Tables("historia")
            clsGen.Alinear_GridView(ds.Tables("historia"), Me.dg_historial_detalle, "", ",cuadro,stock,", "", "", "", "", "", True, True, 350, 50)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub
    Private Function faltaArreglar() As Boolean
        Dim empresa, dua, ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim errores As Boolean

        empresa = gs_empresa
        dua = Me.dua
        ls_sql = "pa_sel_um_reservas_num_errores '" & empresa & "','" & txFecha.Text & "'"
        errores = True
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            If (dt.Rows(0).Item(0).ToString.Equals("0")) Then
                errores = False
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Return errores
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim dua, empresa, path As String
        Dim pm_parametros(2) As String
        Dim pm_valores(2) As String
        Dim clsGen As New ClasesGenerales.General()

        dua = Me.dua
        compararStock()
        guardarEncabezado()
        'guardarDetalle()

        empresa = gs_empresa
        path = clsGen.Path_Reporte & "Logistica\Bodega\Inventario Fisico.rpt"

        pm_valores(0) = empresa
        pm_valores(1) = txFecha.Text



        pm_parametros(0) = "@empresa"
        pm_parametros(1) = "@fecha"
        pm_parametros(2) = "@dua"

        '_reporte_generico_clase(path, pm_parametros, pm_valores, "DATASERVER", "SCM", "flexline", "flexline", True, False, "PDF", False, "InvFisicoConteo", True, 1)
        _reporte_generico_clase(path, pm_parametros, pm_valores, "vDATASERVER", "SCM", "flexline", "flexline", False, False, "PDF", True, "Inv.FisicoConteo", True)
        '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "mysql", "onBase", "sa", "sa", True, False, "PDF", "cotizacion_" & pm_valores(0), True)
        getHistorialIngresos()
        Me.listaProducto = New Collection
        Me.listaStock = New Collection
        Me.listaStockCorrecto = New Collection
        Me.listaStockNoCorrecto = New Collection
        Me.listakeys = New Collection
    End Sub

    Private Sub getHistorialIngresos()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General()
        Dim dt As DataTable
        Dim ds As DataSet
        ds = New DataSet

        Try
            otrans.open()
            ls_sql = "pa_sel_um_all_inv_fisico_encabezado"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "reservas"
            ds.Tables.Add(dt.Copy)

            Me.dg_historial.DataSource = ds.Tables("reservas")
            clsgen.Alinear_GridView(ds.Tables("reservas"), Me.dg_historial, ",empresa,fecha,usuario,fechaIngreso,descripcion,", "", ",empresa,fecha,usuario,fechaIngreso,descripcion,", "", "", "", "", True, True, 350, 50)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
            dt = Nothing
            ds = Nothing
        End Try
    End Sub



    Private Sub dg_productos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg_productos.DataError
        MessageBox.Show("Ingresó un valor inválido", "ERROR")
    End Sub

    Private Sub dg_productos_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellValueChanged
        Dim colnum, num As Integer
        Try
            colnum = dg_productos.SelectedCells(0).ColumnIndex
            If (colnum = 4) Then
                num = dg_productos.SelectedCells(0).Value
                If (num < 0) Then
                    dg_productos.SelectedCells(0).Value = 0
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub dg_historial_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_historial.CellClick
        Dim row As Integer
        Dim fecha, empresa As String
        Try
            row = dg_historial.SelectedCells(0).RowIndex
            fecha = dg_historial.Item("fecha", row).Value.ToString
            empresa = dg_historial.Item("empresa", row).Value.ToString
            getHistoricoDetalle(empresa, fecha)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportes.Click
        Dim fInicial, fFinal, ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ds As DataSet
        Dim clsGen As New ClasesGenerales.General()
        ds = New DataSet
        fInicial = fechaInicial.SelectionStart.ToShortDateString.ToString
        fFinal = fechaFinal.SelectionStart.ToShortDateString.ToString

        ls_sql = "pa_sel_um_da_reporte_rendimiento '" & fInicial & "','" & fFinal & "'"
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "reporte"
            ds.Tables.Add(dt.Copy)

            Me.dg_reporte.DataSource = ds.Tables("reporte")
            clsGen.Alinear_GridView(ds.Tables("reporte"), Me.dg_reporte, "", "", "", "", "", "", "", True, True, 350, 50)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
            dt = Nothing
            ds = Nothing
        End Try
    End Sub
End Class