Public Class frm_MonitorMaquila


    Private Sub generarInformacion()

        Dim ls_sql As String

        Dim dt2 As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try

            myOtrans.open()

            'debo obtener el codigo en onbase
            ls_sql = "call pa_var_um_maq_orden_produccion ('" & gs_empresa & "')"
            dt2 = myOtrans.Obtiene(ls_sql)
            Me.dgvListado.DataSource = dt2
            ClsGen.Alinear_GridView(dt2, Me.dgvListado, "", ",inicio_venta,", " ", "", ",cod_produccion=Orden,", ",cod_produccion=25,", "", True, True, 250, 0)


            
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Mostrar_OP_Producto(psProducto As String)
        Dim ls_sql As String

        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Me.dgv_OPProducto.DataSource = Nothing
            myOtrans.open()

            ls_sql = "call pa_sel_um_inv_producto (null,'" & gs_empresa & "','"
            ls_sql = ls_sql & psProducto & "')"

            'debo obtener el codigo en onbase
            dt = myOtrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                ls_sql = "call pa_sel_um_maq_orden_produccion (" & dt.Rows(0).Item("cod_producto") & ")"
                dt = myOtrans.Obtiene(ls_sql)

                Me.dgv_OPProducto.DataSource = dt

                ClsGen.Alinear_GridView(dt, dgv_OPProducto, ",cantidad,fecha_inicio_venta,observaciones,", ",cod_producto,cod_produccion,", "", "", ",fecha_inicio_venta=fecha,", "", ",estado,cantidad,fecha_inicio_venta,", False, True, 250, 0)
                'ClsGen.Alinea_Grid(dt, Me.dg_op_producto, dt.TableName, -1, 200, 0, True, True, "", True, "")
                'ClsGen.Alinea_Grid(dt, Me.dg_estadisticas_op, dt.TableName, -1, 200, 0, True, True, "", True, "")
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub


    Private Sub Mostrar_OP_Avance(piOrdenProduccion As Integer)
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String


        Try
            myOtrans.open()

            
            'sSQL = "call pa_sel_um_maq_orden_produccion_avance (" & piOrdenProduccion & ")"

            lsSQL = "call pa_sel_um_maq_orden_produccion_avance_diario_orden (" & piOrdenProduccion & ")"

            dt = myOtrans.Obtiene(lsSQL)
            Me.dgv_OPAvance.DataSource = dt
            clsGen.Alinear_GridView(dt, dgv_OPAvance, ",cantidad,fecha_grabo,", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing

        End Try
    End Sub

    Private Sub Mostrar_Imagen_Produccion(piOrdenProduccion As Integer, piSolicitado As Integer)
        Dim nrow, nsolicitado, norden, navance As Integer
        Dim ls_sql As String

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable

        nsolicitado = piSolicitado
        norden = 0
        navance = 0
        Me.txt_estadisticas_producido.Text = 0



        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_maq_orden_produccion_avance (" & piOrdenProduccion & ")"
            dt = myOtrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                navance = (dt.Rows(0).Item("Cantidad") / nsolicitado) * 100
            End If

            Me.txt_estadisticas_producido.Text = dt.Rows(0).Item("Cantidad")
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        ActualizarBarra(Me.PanelRellenoProduccion, Me.PanelBaseProduccion, "B", navance)
    End Sub


    Sub InicializarBarra(ByRef NombreBarraRelleno As Panel, ByVal PosicionBarra As String)
        ' Valores de PosicionBarra
        ' H = Horizontal; V(Vertical)
        If PosicionBarra.ToUpper = "H" Then
            NombreBarraRelleno.Width = 0
        ElseIf PosicionBarra = "V" Then
            NombreBarraRelleno.Height = 0
        End If
    End Sub

    Sub ActualizarBarra(ByRef NombreBarraRelleno As Panel, ByRef NombreBarraBase As Panel, _
             ByVal PuntoInicio As String, ByVal Valor As Integer)
        ' Valores de PuntoInicio
        ' R(Right) = de derecha a izquierda ; L(Left) = de izquierda a derecha ; 
        ' T(Top) = de arriba a abajo ; B(Bottom) = de abajo a arriba

        'variable que sirve para guardar el valor de la unidad en la barra de progreso
        Dim Unidad As Decimal

        If PuntoInicio.ToUpper = "R" Or PuntoInicio.ToUpper = "L" Then
            'guardo el valor de la unidad de la barra de relleno
            Unidad = NombreBarraBase.Width / 100
        Else
            If PuntoInicio.ToUpper = "T" Or PuntoInicio.ToUpper = "B" Then
                'guardo el valor de la unidad de la barra de relleno
                Unidad = NombreBarraBase.Height / 100
            End If
        End If
        Select Case PuntoInicio
            Case "R" 'de derecha a izquierda
                NombreBarraRelleno.Left = NombreBarraBase.Width - (Unidad * Valor)
                NombreBarraRelleno.Width = Unidad * Valor
            Case "L" 'de izquierda a derecha
                NombreBarraRelleno.Width() = NombreBarraRelleno.Left + (Unidad * Valor)
            Case "T" 'de arriba a abajo
                NombreBarraRelleno.Height() = NombreBarraRelleno.Top + (Unidad * Valor)
            Case "B" 'de abajo a arriba
                NombreBarraRelleno.Top = NombreBarraBase.Height - (Unidad * Valor)
                NombreBarraRelleno.Height() = Unidad * Valor
            Case Else
                MessageBox.Show("El valor del parámetro PuntoInicio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub


    Private Sub frm_MonitorMaquila_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub gtnGenerar_Click(sender As Object, e As EventArgs) Handles gtnGenerar.Click
        generarInformacion()
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Mostrar_OP_Producto(Me.dgvListado.Item("producto", e.RowIndex).Value)
        Mostrar_OP_Avance(Me.dgvListado.Item("cod_produccion", e.RowIndex).Value)
        'Mostrar_Estadisticas(Me.dgvListado.Item("cod_produccion", e.RowIndex).Value)
        InicializarBarra(Me.PanelRellenoProduccion, "V") 'de abajo a arriba
        '    'de abajo a arriba
        Mostrar_Imagen_Produccion(Me.dgvListado.Item("cod_produccion", e.RowIndex).Value, Me.dgvListado.Item("cantidad", e.RowIndex).Value)
    End Sub

    Private Sub dgvListado_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvListado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvListado.Rows(rowIndex)

                If dgvListado.Columns(colIndex).Name.ToLower.StartsWith("estado") Then
                    If Me.dgvListado.Item(colIndex, rowIndex).Value.ToString = "Solicitada" Then
                        Me.dgvListado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Purple

                    ElseIf Me.dgvListado.Item(colIndex, rowIndex).Value.ToString = "En Proceso" Then
                        Me.dgvListado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                    End If
                End If

                'End I

            End If

        Catch ex As Exception
        End Try
    End Sub
End Class