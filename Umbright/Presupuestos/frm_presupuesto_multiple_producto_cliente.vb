Imports system.Math
Public Class frm_presupuesto_multiple_producto_cliente


    Dim _CodigoProducto As String = String.Empty
    Public _descripcion As String = String.Empty
    Public _periodo As String = String.Empty
    Public _nombre_periodo As String
    Public _presupuesto_general As Integer
    Public _dt As New DataTable
    Public _productos As String()
    Public _nombreproductos As String()
    Public _valores As Integer()
    Public _precios As Double()
    Dim _presupuesto_comercial As Integer
    Dim _presupuesto_sugerido As Integer
    Dim ods As New DataSet
    Dim dprecio As Double = 0
    Dim filtro_actual As String = String.Empty

    Private Sub Crear_Estructura()
        Dim icount As Integer
        Dim sname As String

        Dim dt As New DataTable
        dt.TableName = "productos"

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("vigente", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("ejecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ppto_mercadeo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("valor", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("vmmpa", GetType(Integer)))
        dt.Columns.Add(New DataColumn("prom24meses", GetType(Decimal)))
        For icount = 1 To 3
            sname = "mes_" & icount.ToString.PadLeft(1, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        Next
        dt.Columns.Add(New DataColumn("sugerido", GetType(Integer)))
        dt.Columns.Add(New DataColumn("valor_sugerido", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("peso", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("supervisor", GetType(String)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))

        'dt.Columns("cliente").Unique = True 'Llave Unica

        ods.Tables.Add(dt.Copy)

        dt.TableName = "resumen"
        ods.Tables.Add(dt.Copy)

        dt.TableName = "productos_extra"
        ods.Tables.Add(dt.Copy)

        dt.TableName = "productos_cambios"
        ods.Tables.Add(dt.Copy)

        dt.TableName = "productos_eliminados"
        ods.Tables.Add(dt.Copy)

        'dt = New DataTable
        'dt.Columns.Add(New DataColumn("supervisor", GetType(String)))
        'ods.Tables.Add(dt.Copy)

    End Sub

    Private Sub Agregar_Tabla(ByVal dt As DataTable, ByVal ppto_mercadeo As Integer)

        Dim dr, dr_aux As DataRow
        Dim icount As Integer
        Dim sname As String

        Try
            For Each dr In dt.Rows
                dr_aux = ods.Tables("productos").NewRow
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")
                dr_aux.Item("vigente") = dr.Item("vigencia_cliente")
                dr_aux.Item("cliente") = dr.Item("cliente")
                dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
                dr_aux.Item("ppto_mercadeo") = ppto_mercadeo
                dr_aux.Item("cantidad") = dr.Item("cantidad")
                dr_aux.Item("valor") = dr.Item("valor")
                dr_aux.Item("vmmpa") = dr.Item("vmmpa")
                dr_aux.Item("prom24meses") = dr.Item("prom24meses")
                For icount = 1 To 3
                    sname = "mes_" & icount.ToString.PadLeft(1, "0")
                    dr_aux.Item(sname) = dr.Item(sname)
                Next
                dr_aux.Item("sugerido") = dr.Item("sugerido")
                dr_aux.Item("valor_sugerido") = dr.Item("sugerido") * dr.Item("precio")
                dr_aux.Item("precio") = dr.Item("precio")
                dr_aux.Item("tipo") = dr.Item("tipo")
                dr_aux.Item("ejecutivo") = dr.Item("ejecutivo")
                dr_aux.Item("supervisor") = dr.Item("supervisor")
                dr_aux.Item("modificado") = 0

                ods.Tables("productos").Rows.Add(dr_aux)

            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Actualizar_Precios(ByVal dt As DataTable, ByVal precio As Double)
        Dim oTrans As New Transaccional.Conexion("Umbralsa")
        Dim dr As DataRow
        Dim ls_sql As String


        Try
            oTrans.open()
            For Each dr In dt.Rows
                ls_sql = "pa_upd_um_integracion '" & gs_empresa & "','" & _
                        dr.Item("producto").ToString & "','" & _
                        dr.Item("cliente").ToString & "'," & _
                        dr.Item("periodo").ToString & "," & _
                        dr.Item("ejercicio").ToString & "," & _
                        dr.Item("cantidad").ToString & "," & _
                        precio.ToString & "," & _
                        dr.Item("cantidad").ToString * precio & ",'" & _
                        dr.Item("nodocumento") & "'"
                oTrans.Actualiza(ls_sql)

            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

    End Sub

    Private Sub Mostrar_Informacion()
        Dim ls_sql As String
        Dim dt, dt_clientes As DataTable
        Dim otrans As New Transaccional.Conexion("Umbralsa")
        Dim oFlex As New Umbral_Flex.productos
        Dim icount As Integer = 0
        Dim actualizar_precio As Boolean = False
        Dim periodo As String


        ReDim _precios(_productos.Length)
        periodo = giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
        If Val(periodo) < Val(Now.ToString("yyyyMM")) Then Me.btn_guardar.Visible = False
        'Else
        'Me.btn_guardar.Visible = True

        'End If

        Try
            otrans.open()
            For icount = 0 To _productos.Length - 1
                ls_sql = "pa_sel_um_ppt_presupuesto_cliente '" & gs_empresa & "'," & giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & _
                        ",'" & _productos(icount) & "',NULL," & _valores(icount) & ",NULL,NULL" '" & gs_nombre_usuario & "'"
                dt_clientes = otrans.Obtiene(ls_sql)



                ''precios
                'If ods.Tables("productos").Rows.Count > 0 Then
                Try
                    dprecio = dt_clientes.Rows(0).Item("precio")
                Catch ex As Exception
                    dprecio = 0
                End Try

                'End If
                _precios(icount) = dprecio

                ''Precios
                ls_sql = "pa_var_um_ListaPrecio_Vigente '" & gs_empresa & "'"
                dt = otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    dprecio = Me.Precio_Lista(_productos(icount).ToString)

                    dprecio = dprecio / 1.12
                    dprecio = Round(dprecio, 2)
                    If _precios(icount) <> dprecio And dprecio > 0 Then
                        If Me.btn_guardar.Visible Then
                            If MessageBox.Show("El Precio de Lista del Producto " & _nombreproductos(icount) & " Cambio de " & _precios(icount).ToString & " a " & dprecio.ToString & " Desea Aplicar los nuevos Precios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                'Actualizar_Precio
                                actualizar_precio = True
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("No Existen Listas de Precios Vingentes Para Presupuestos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                If actualizar_precio And dprecio > 0 Then
                    Actualizar_Precios(dt_clientes, dprecio)

                    'vuelvo a obtener los productos
                    ls_sql = "pa_sel_um_ppt_presupuesto_cliente '" & gs_empresa & "'," & giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & _
                            ",'" & _productos(icount) & "',NULL," & _valores(icount)
                    dt_clientes = otrans.Obtiene(ls_sql)

                End If

                If dt_clientes.Rows.Count > 0 Then
                    Agregar_Tabla(dt_clientes, _valores(icount))
                End If





            Next
        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            otrans.close()
            otrans = Nothing
            Me.dg_productos.DataSource = ods.Tables("productos")
            Hacer_Resumen()
            Me.dg_resumen.DataSource = ods.Tables("resumen")
            Maquillar_Grid()
            Maquillar_Grid_Resumen()
        End Try


    End Sub

    Public Sub Maquillar_Grid()
        Dim dgvc As DataGridViewColumn
        Dim periodo_actual As Integer = giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
        Dim fecha_actual As Date = "01/" & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & _
                                      "/" & giPeriodo.ToString

        Try
            'Me.dg_productos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            'Me.dg_productos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            For Each dgvc In Me.dg_productos.Columns
                Select Case dgvc.Name.ToString.ToLower.Substring(0, 4)
                    Case "cant", "clie", "prec", "nomb", "tipo", "ejec", "peso", "vmmp", "suge", "peso", "valo", "mes_", "prom"
                        dgvc.Visible = True
                        dgvc.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 7.0F, FontStyle.Regular, GraphicsUnit.Point)
                    Case Else
                        dgvc.Visible = False
                End Select
            Next
            Me.dg_productos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dg_productos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            For Each dgvc In Me.dg_productos.Columns
                Select Case dgvc.Name.ToString.ToLower.Substring(0, 4)
                    Case "cant", "clie"
                    Case "vmmp"
                        dgvc.ReadOnly = True
                        dgvc.HeaderText = "vt" & fecha_actual.AddMonths(-12).ToString("MMMyy")
                    Case "prom"
                        dgvc.HeaderText = "Pro Vta12M"
                        dgvc.ReadOnly = True
                    Case "mes_"
                        Dim nmes As Integer
                        nmes = dgvc.ToString.Substring(dgvc.ToString.IndexOf("_") + 1, 1)
                        dgvc.HeaderText = fecha_actual.AddMonths(nmes * -1).ToString("MMM yyyy")
                        dgvc.ReadOnly = True
                    Case Else
                        dgvc.ReadOnly = True
                End Select
                dgvc.HeaderText = StrConv(dgvc.HeaderText, VbStrConv.ProperCase)
                dgvc.HeaderText = dgvc.HeaderText.Replace("_", " ")

                If dgvc.ValueType.ToString.ToLower = "system.decimal" Then
                    dgvc.DefaultCellStyle.Format = "N2"
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                ElseIf dgvc.ValueType.ToString.ToLower = "system.int32" Then
                    dgvc.DefaultCellStyle.Format = "N0"
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    dgvc.Width = 60
                Else
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                End If

                If dgvc.Name.ToString.ToLower = "prom24meses" Or _
                    dgvc.Name.ToString.ToLower = "valor_sugerido" Then
                    dgvc.DefaultCellStyle.Format = "N0"
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dgvc.Width = 60
                End If

            Next

            Me.dg_productos.Columns(9).Frozen = True
            Me.dg_productos.Columns("sugerido").DefaultCellStyle.BackColor = Color.LightCyan

        Catch ex As Exception
        Finally
            Sugerido()
        End Try
    End Sub

    Public Sub Maquillar_Grid_Resumen()
        Dim dgvc As DataGridViewColumn
        Dim periodo_actual As Integer = giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
        Dim fecha_actual As Date = "01/" & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & _
                                      "/" & giPeriodo.ToString

        Try
            For Each dgvc In Me.dg_resumen.Columns
                Select Case dgvc.Name.ToString.ToLower.Substring(0, 3)
                    Case "can", "vmm", "sug", "ppt", "pro", "val", "mes", "glo", "ppt"
                        dgvc.Visible = True
                        dgvc.ReadOnly = True
                        dgvc.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 7.0F, FontStyle.Regular, GraphicsUnit.Point)
                    Case Else
                        dgvc.Visible = False
                End Select

                Select Case dgvc.Name.ToString.ToLower.Substring(0, 4)
                    Case "vmmp"
                        dgvc.HeaderText = "vt" & fecha_actual.AddMonths(-12).ToString("MMMyy")
                    Case "prom"
                        dgvc.HeaderText = "Pr Vta12M"
                    Case "mes_"
                        Dim nmes As Integer
                        nmes = dgvc.ToString.Substring(dgvc.ToString.IndexOf("_") + 1, 1)
                        dgvc.HeaderText = fecha_actual.AddMonths(nmes * -1).ToString("MMM yyyy")
                    Case "ppto"
                        dgvc.HeaderText = "Ppto Mercadeo"
                End Select
                dgvc.HeaderText = StrConv(dgvc.HeaderText, VbStrConv.ProperCase)

                If dgvc.ValueType.ToString.ToLower = "system.decimal" Then
                    dgvc.DefaultCellStyle.Format = "N2"
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                ElseIf dgvc.ValueType.ToString.ToLower = "system.int32" Then
                    dgvc.DefaultCellStyle.Format = "N0"
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Else
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                End If
            Next
        Catch ex As Exception
        Finally
            Me.dg_resumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Me.dg_resumen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            'Me.dg_resumen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            'Me.dg_resumen.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells)
        End Try
    End Sub

    Private Function Precio_Lista(ByVal producto As String) As Double
        Dim preciolista As Double = 0
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_var_um_glb_empresas '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)

            Otrans.close()
            Otrans = New Transaccional.Conexion("FlexLine")
            Otrans.open()
            ls_sql = "pa_var_um_listaprecioD '" & gs_empresa & "','" & producto & "','" & dt.Rows(0).Item("ListaPrecio_Presupuesto").ToString & "'"
            dt = Otrans.Obtiene(ls_sql)

            preciolista = dt.Rows(0).Item("Valor").ToString



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        Return preciolista
    End Function

    Private Function BuscarCliente(ByVal _cliente As String) As DataTable
        Dim dt As New DataTable
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql As String

        Try
            ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & _cliente & "',NULL"
            Otrans.open()
            dt = Otrans.Obtiene(ls_sql)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Private Sub Sugerido()

        Dim dr As DataRow
        Dim dt As DataTable = ods.Tables("resumen").Copy
        Try
            For Each dr In ods.Tables("productos").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("peso") = (dr.Item("cantidad") / dt.DefaultView(0).Item("cantidad")) * 100
                    dr.Item("sugerido") = (dr.Item("peso") / 100) * dr.Item("ppto_mercadeo") ''Esta debe ser la cantidad del resumen
                    dr.Item("valor_sugerido") = dr.Item("sugerido") * dr.Item("precio")
                    'ods.Tables("resumen").DefaultView(0).Item("glosa") = dr.Item("glosa").ToString
                End If
            Next
        Catch ex As Exception
        Finally
            'ods.Tables("resumen").DefaultView.RowFilter = ""
            Hacer_Resumen()
        End Try

    End Sub

    Private Sub Calcular_Precios()
        Dim dr As DataRow
        Dim dr2 As DataRow

        Try

            For Each dr In ods.Tables("productos").Rows
                If dr.Item("precio").ToString.Trim.Length = 0 Then
                    For Each dr2 In ods.Tables("resumen").Rows
                        If dr.Item("producto") = dr2.Item("producto") Then
                            dprecio = dr2.Item("precio")
                            Exit For
                        End If
                    Next
                    If dprecio = 0 Then
                        dprecio = Precio_Lista(_CodigoProducto)
                    End If
                    dr.Item("precio") = dprecio
                End If
                dr.Item("valor") = dr.Item("cantidad") * dr.Item("precio")
                dr.Item("valor_sugerido") = dr.Item("sugerido") * dr.Item("precio")

            Next
        Catch ex As Exception

        End Try

    End Sub

    ''Resumen de todos los productos
    Private Sub Hacer_Resumen()
        Dim ncantidad, nsugerido As Integer
        Dim icount As Integer
        Dim nvalor, nvalorsugerido, nvmmap, nprom24, nmes_1, nmes_2, nmes_3 As Double
        ncantidad = nsugerido = 0
        nvalor = nvmmap = nprom24 = nmes_1 = nmes_2 = nmes_3 = nvalorsugerido = 0

        Dim dr As DataRow

        If ods.Tables("resumen").Rows.Count = _productos.Length Then
            For Each dr In ods.Tables("resumen").Rows

                Try
                    ncantidad = ods.Tables("productos").Compute("sum(cantidad)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    ncantidad = 0
                End Try

                Try
                    nsugerido = ods.Tables("productos").Compute("sum(sugerido)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nsugerido = 0
                End Try

                Try
                    nvalor = ods.Tables("productos").Compute("sum(valor)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nvalor = 0
                End Try

                Try
                    nvalorsugerido = ods.Tables("productos").Compute("sum(valor_sugerido)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nvalorsugerido = 0
                End Try

                Try
                    nmes_1 = ods.Tables("productos").Compute("sum(mes_1)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nmes_1 = 0
                End Try

                Try
                    nmes_2 = ods.Tables("productos").Compute("sum(mes_2)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nmes_2 = 0
                End Try

                Try
                    nmes_3 = ods.Tables("productos").Compute("sum(mes_3)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nmes_3 = 0
                End Try

                Try
                    nprom24 = ods.Tables("productos").Compute("sum(prom24meses)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nprom24 = 0
                End Try

                Try
                    nvmmap = ods.Tables("productos").Compute("sum(vmmpa)", "producto = '" & dr.Item("producto") & "'")
                Catch ex As Exception
                    nvmmap = 0
                End Try

                With dr
                    .Item("cantidad") = ncantidad
                    .Item("sugerido") = nsugerido
                    .Item("valor") = nvalor
                    .Item("valor_sugerido") = nvalorsugerido
                    .Item("vmmpa") = nvmmap
                    .Item("prom24meses") = nprom24
                    .Item("mes_1") = nmes_1
                    .Item("mes_2") = nmes_2
                    .Item("mes_3") = nmes_3
                End With
            Next
        Else

            ods.Tables("resumen").Rows.Clear()

            Try
                For icount = 0 To _productos.Length - 1
                    'For Each dr In ods.Tables("productos").Rows
                    Try
                        ncantidad = ods.Tables("productos").Compute("sum(cantidad)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        ncantidad = 0
                    End Try
                    Try
                        nsugerido = ods.Tables("productos").Compute("sum(sugerido)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nsugerido = 0
                    End Try
                    Try
                        nvalor = ods.Tables("productos").Compute("sum(valor)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nvalor = 0
                    End Try

                    Try
                        nvalorsugerido = ods.Tables("productos").Compute("sum(valor_sugerido)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nvalorsugerido = 0
                    End Try

                    Try
                        nmes_1 = ods.Tables("productos").Compute("sum(mes_1)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nmes_1 = 0
                    End Try
                    Try
                        nmes_2 = ods.Tables("productos").Compute("sum(mes_2)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nmes_2 = 0
                    End Try
                    Try
                        nmes_3 = ods.Tables("productos").Compute("sum(mes_3)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nmes_3 = 0
                    End Try
                    Try
                        nprom24 = ods.Tables("productos").Compute("sum(prom24meses)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nprom24 = 0
                    End Try


                    Try
                        nvmmap = ods.Tables("productos").Compute("sum(vmmpa)", "producto = '" & _productos(icount) & "'")
                    Catch ex As Exception
                        nvmmap = 0
                    End Try

                    Try
                        dr = ods.Tables("resumen").NewRow
                        With dr
                            .Item("producto") = _productos(icount)
                            .Item("glosa") = _nombreproductos(icount)
                            .Item("ppto_mercadeo") = _valores(icount)
                            .Item("cantidad") = ncantidad
                            .Item("sugerido") = nsugerido
                            .Item("valor") = nvalor
                            .Item("valor_sugerido") = nvalorsugerido
                            .Item("vmmpa") = nvmmap
                            .Item("prom24meses") = nprom24
                            .Item("mes_1") = nmes_1
                            .Item("mes_2") = nmes_2
                            .Item("mes_3") = nmes_3
                            .Item("precio") = IIf(_precios(icount) = 0, Precio_Lista(_productos(icount)), _precios(icount)) ''precio
                        End With
                        ods.Tables("resumen").Rows.Add(dr)
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub Filtrar_Informacion_detalle(ByVal nrow As Integer)

        Try
            _CodigoProducto = Me.dg_resumen.Item(0, nrow).Value
            filtro_actual = "producto = '" & _CodigoProducto & "'"
            ods.Tables("productos").DefaultView.RowFilter = filtro_actual
            Me.lbl_codigo.Text = _CodigoProducto
            Me.lbl_descripcion.Text = Me.dg_resumen.Item(1, nrow).Value 'ods.Tables("productos").DefaultView(0).Item("Glosa").ToString
            Me.lbl_presupuesto.Text = Me.dg_resumen.Item(7, nrow).Value.ToString 'ods.Tables("productos").DefaultView(0).Item("ppto_mercadeo").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Filtrar_informacion")
        End Try
    End Sub

    Private Function ClienteDuplicado(ByVal CodigoCliente As String) As Boolean
        Dim resultado As Boolean = True
        Dim dt As DataTable
        Try

            dt = ods.Tables("productos").Copy

            dt.DefaultView.RowFilter = "producto = '" & _CodigoProducto & "' and  cliente = '" & CodigoCliente & "'"

            If dt.DefaultView.Count = 0 Then
                resultado = False
            End If

        Catch ex As Exception
        End Try

        Return resultado
    End Function

    Private Sub Crear_Filtro_Supervisores()
        Dim dt As New DataTable
        dt = New DataTable
        dt.Columns.Add(New DataColumn("supervisor", GetType(String)))
        Dim dr, dr2, dr3 As DataRow
        Dim agregar_supervisor As Boolean = False
        Me.ContextMenuStrip1.Items.Clear()


        Try
            For Each dr In ods.Tables("productos").Rows
                Try
                    For Each dr3 In dt.Rows
                        If dr3.Item("supervisor") = dr.Item("supervisor") Then
                            agregar_supervisor = False
                            Exit For
                        End If
                    Next

                    If agregar_supervisor Or dt.Rows.Count = 0 Then
                        dr2 = dt.NewRow
                        dr2.Item("supervisor") = dr.Item("supervisor").ToString
                        dt.Rows.Add(dr2)
                    End If
                    agregar_supervisor = True
                Catch ex As Exception

                End Try
            Next
            Me.ContextMenuStrip1.Items.Add("Quitar Filtro", Nothing, AddressOf ToolStripMenuItem_Click)
            For Each dr In dt.Rows
                Me.ContextMenuStrip1.Items.Add("Filtrar " & dr.Item("supervisor").ToString, Nothing, AddressOf ToolStripMenuItem_Click)
            Next

        Catch ex As Exception
        End Try

    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("quitar") Then
                    ods.Tables("productos").DefaultView.RowFilter = filtro_actual
                Else


                    menuItem.Text.Replace("Filtrar ", " ")
                    Dim nombre_supervisor As String = menuItem.Text.Replace("Filtrar ", "")
                    'MessageBox.Show("The " & nombre_supervisor & " item was just selected.")
                    ods.Tables("productos").DefaultView.RowFilter = filtro_actual & " and supervisor = '" & nombre_supervisor & "'"
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Obtener_Venta_Clientes_Sin_Presupuesto(ByVal dt As DataTable, ByVal icount As Integer, _
                            ByVal fecha_actual As Date, ByVal periodo_actual As Integer)

        Dim dr, dr2, dr3 As DataRow
        Dim agregar As Boolean = False
        Dim ls_filtro As String
        Dim valor As Double
        Dim dt2 As DataTable

        For Each dr In dt.Rows

            ods.Tables("productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto").ToString & "' and cliente = '" & dr.Item("cliente").ToString & "'"
            If ods.Tables("productos").DefaultView.Count = 0 Then
                agregar = True
            End If

            If agregar Or ods.Tables("productos").Rows.Count = 0 Then
                ls_filtro = "producto = '" & dr.Item("producto") & "' and cliente = '" & dr.Item("cliente") & "'"
                ods.Tables("productos_extra").DefaultView.RowFilter = ls_filtro

                If ods.Tables("productos_extra").DefaultView.Count = 0 Then
                    dr3 = ods.Tables("productos_extra").NewRow
                    dr3.Item("producto") = dr.Item("producto")
                    dr3.Item("cliente") = dr.Item("cliente")

                    ods.Tables("productos_extra").Rows.Add(dr3)
                End If
            End If
            agregar = False
        Next

        ods.Tables("productos").DefaultView.RowFilter = ""

        For Each dr In ods.Tables("productos_extra").Rows
            If dr.Item("producto").ToString = _productos(icount) Then
                Try
                    valor = dt.Compute("Sum(ventasU)", "cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'") / 12
                Catch ex As Exception
                    valor = 1
                End Try

                dr.Item("prom24meses") = valor

                dr.Item("vmmpa") = dt.Compute("Sum(ventasU)", "periodo=" & (periodo_actual - 100).ToString & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                dr.Item("mes_1") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-1).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                dr.Item("mes_2") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-2).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                dr.Item("mes_3") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-3).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
            End If

            ods.Tables("productos").DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "' and cliente =  '" & dr.Item("cliente") & "'"

            If ods.Tables("productos").DefaultView.Count = 0 Then

                If (dr.Item("mes_1").ToString.Length > 0 Or _
                    dr.Item("mes_2").ToString.Length > 0 Or _
                    dr.Item("mes_3").ToString.Length > 0 Or _
                    dr.Item("vmmpa").ToString.Length > 0) And _
                    dr.Item("prom24meses") > 0.01 Then
                    dr2 = ods.Tables("productos").NewRow

                    dr2.Item("producto") = dr.Item("producto")
                    dr2.Item("cliente") = dr.Item("cliente")
                    dr2.Item("prom24meses") = dr.Item("prom24meses")
                    dr2.Item("vmmpa") = dr.Item("vmmpa")
                    dr2.Item("mes_1") = dr.Item("mes_1")
                    dr2.Item("mes_2") = dr.Item("mes_2")
                    dr2.Item("mes_3") = dr.Item("mes_3")

                    dt2 = BuscarCliente(dr.Item("cliente"))
                    If dt2.Rows.Count > 0 Then
                        dr2.Item("nombre_cliente") = dt2.Rows(0).Item("nombre_cliente").ToString
                        dr2.Item("ejecutivo") = dt2.Rows(0).Item("ejecutivo").ToString
                        dr2.Item("tipo") = dt2.Rows(0).Item("tipo").ToString
                        dr2.Item("vigente") = dt2.Rows(0).Item("vigencia_cliente").ToString
                        dr2.Item("supervisor") = dt2.Rows(0).Item("supervisor").ToString
                    End If

                    dr2.Item("cantidad") = 0
                    dr2.Item("sugerido") = 0
                    dr2.Item("peso") = 0

                    ods.Tables("productos").Rows.Add(dr2)
                End If
            End If

        Next
        Calcular_Precios()
    End Sub

    Private Sub Agregar_Cambios_Temporales_dr(ByVal _dr As DataRow)
        Dim dr As DataRow
        Dim encontrado As Boolean = False

        Try
            For Each dr In ods.Tables("productos_cambios").Rows
                If dr.Item("producto") = _dr.Item("producto").ToString And dr.Item("cliente").ToString = _dr.Item("cliente").ToString Then
                    dr.Item("cantidad") = _dr.Item("cantidad")
                    dr.Item("valor") = _dr.Item("valor")
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                dr = ods.Tables("productos_cambios").NewRow
                dr.Item("producto") = _dr.Item("producto")
                dr.Item("cliente") = _dr.Item("cliente")
                dr.Item("cantidad") = _dr.Item("cantidad")
                dr.Item("valor") = _dr.Item("valor")
                dr.Item("precio") = _dr.Item("precio")
                dr.Item("modificado") = 1
                ods.Tables("productos_cambios").Rows.Add(dr)
                encontrado = False
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Agregar_Cambios_Temporales(ByVal _dr As DataGridViewRow)

        Dim dr As DataRow
        Dim encontrado As Boolean = False

        Try


            For Each dr In ods.Tables("productos_cambios").Rows
                If dr.Item("producto") = _dr.Cells(0).Value.ToString And dr.Item("cliente") = _dr.Cells(5).Value.ToString Then
                    dr.Item("cantidad") = _dr.Cells(8).Value.ToString
                    dr.Item("valor") = _dr.Cells(9).Value.ToString
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                dr = ods.Tables("productos_cambios").NewRow
                dr.Item("producto") = _dr.Cells(0).Value.ToString.Trim
                dr.Item("cliente") = _dr.Cells(5).Value.ToString.Trim
                dr.Item("cantidad") = _dr.Cells(8).Value.ToString
                dr.Item("valor") = _dr.Cells(9).Value
                dr.Item("precio") = _dr.Cells(17).Value
                dr.Item("modificado") = 1

                ods.Tables("productos_cambios").Rows.Add(dr)
                encontrado = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Agregar_Productos_Eliminados(ByVal _dr As DataGridViewRow)

        Dim dr As DataRow
        Dim encontrado As Boolean = False

        Try


            For Each dr In ods.Tables("productos_eliminados").Rows
                If dr.Item("producto") = _dr.Cells(0).Value.ToString And dr.Item("cliente") = _dr.Cells(5).Value.ToString Then
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                dr = ods.Tables("productos_eliminados").NewRow
                dr.Item("producto") = _dr.Cells(0).Value.ToString.Trim
                dr.Item("cliente") = _dr.Cells(5).Value.ToString.Trim
                ods.Tables("productos_eliminados").Rows.Add(dr)
                encontrado = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Guardar_Cambios()
        Dim dr As DataRow
        Dim dt As DataTable
        Dim lb_presupuestos_bajos As Boolean = False
        Dim lb_continuar As Boolean = True
        Dim lb_errores As Boolean = False
        Dim ls_sql As String
        Dim otrans As Transaccional.Conexion

        Calcular_Precios()
        Hacer_Resumen()
        For Each dr In ods.Tables("resumen").Rows
            If dr.Item("ppto_mercadeo") > dr.Item("cantidad") Then
                lb_presupuestos_bajos = True
                Exit For
            End If
        Next

        If lb_presupuestos_bajos Then
            If MessageBox.Show("Existen Productos Con Presupuesto Menor al de Mercadeo, Desea Continuar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                lb_continuar = False
            End If
        End If

        If lb_continuar Then
            Try
                lb_errores = Guardar_Clientes_Eliminados()
                otrans = New Transaccional.Conexion("Umbralsa")
                otrans.open()


                For Each dr In ods.Tables("productos_cambios").Rows
                    ls_sql = "pa_sel_um_integracion '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                            giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
                    dt = otrans.Obtiene(ls_sql)
                    If dt.Rows.Count > 0 Then
                        If dr.Item("cantidad") > 0 Then 'Actualizar Ppto Actual
                            ls_sql = "pa_upd_um_integracion '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                                giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & "," & _
                                giPeriodo.ToString & giPeriodo.ToString & "," & _
                                dr.Item("cantidad") & "," & dr.Item("precio").ToString & "," & dr.Item("valor") & ",'" & _
                                dt.Rows(0).Item("nodocumento").ToString & "'"

                            otrans.Actualiza(ls_sql)

                            If otrans.Codigo_error > 0 Then
                                MessageBox.Show("Problemas Al Actualizar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Insertar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                lb_errores = True

                            End If
                        Else
                            'eliminar presupuesto por cantidad 0
                            ls_sql = "pa_del_um_integracion_cliente_producto_periodo '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                                    giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & ",'" & _
                                    dt.Rows(0).Item("nodocumento").ToString & "'"
                            otrans.Elimina(ls_sql)
                            If otrans.Codigo_error > 0 Then
                                MessageBox.Show("Problemas Al Eliminar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                lb_errores = True
                            End If
                        End If

                    Else ''cliente nuevo
                        If dr.Item("cantidad") > 0 Then
                            ls_sql = "pa_ins_um_integracion '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                                giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & "," & _
                                giPeriodo.ToString & giPeriodo.ToString & "," & _
                                dr.Item("cantidad") & "," & dr.Item("precio").ToString & "," & dr.Item("valor")
                            otrans.Ingresa(ls_sql)
                            If otrans.Codigo_error > 0 Then
                                MessageBox.Show("Problemas Al Actualizar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Insertar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                lb_errores = True
                            End If
                        End If
                    End If
                Next
                If lb_errores Then
                    MessageBox.Show("Proceso Finalizado Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing

            End Try
        End If
    End Sub

    Private Function Guardar_Clientes_Eliminados() As Boolean
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim lb_errores As Boolean = False


        Try

            Otrans.open()
            For Each dr In ods.Tables("productos_eliminados").Rows
                'If dr.RowState = DataRowState.Deleted Then


                ls_sql = "pa_sel_um_integracion '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                        giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
                dt = Otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    'eliminar Cliente y Presupuesto 
                    ls_sql = "pa_del_um_integracion_cliente_producto_periodo '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                            giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & ",'" & _
                            dt.Rows(0).Item("nodocumento").ToString & "'"
                    Otrans.Elimina(ls_sql)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show("Problemas Al Eliminar " & dr.Item("producto") & Chr(13) & Otrans.descripcion_error, "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lb_errores = True
                    End If
                End If
                'End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Clientes Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lb_errores = True
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return lb_errores

    End Function

    Private Sub Aplicar_Seguridad()
        If tiene_permisos("mpt_modificarPresupuestoComercial") = True Then
            Me.btn_guardar.Visible = True
        End If

        If tiene_permisos("mpt_verpresupuestoEstadisticas") = True Then
            Me.btn_aplicar_estadisticas.Visible = True
        End If

    End Sub

    Private Sub Actualizar_Ppto_DATASERVER()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "sp_integracion '" & gs_empresa & "'," & giPeriodo.ToString
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub frm_presupuesto_multiple_producto_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim icount As Integer

        Me.Text += " " & _periodo & " " & giPeriodo.ToString
        Me.lbl_periodo.Text = _periodo & " " & giPeriodo.ToString
        Aplicar_Seguridad()
        Crear_Estructura()
        Mostrar_Informacion()
        Crear_Filtro_Supervisores()

        For icount = 1 To ods.Tables("resumen").Rows.Count - 1
            Filtrar_Informacion_detalle(icount)
        Next
        Filtrar_Informacion_detalle(0)
    End Sub

    Private Sub dg_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dg_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dg_productos.Rows(rowIndex)
                If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                    therow.DefaultCellStyle.BackColor = Color.Yellow
                ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                    therow.DefaultCellStyle.BackColor = Color.Red
                End If

                If Me.dg_productos.Columns(colIndex).Name.ToLower = "cantidad" Then
                    If Me.dg_productos.Item("modificado", e.RowIndex).Value.ToString = 1 Then
                        Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                    End If
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_estadisticas.Click
        Dim dr As DataRow
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim icount As Integer
        Dim valor As Double
        Dim fecha_actual As Date = "01/" & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString & _
                              "/" & giPeriodo.ToString
        Dim generar_Venta_sin_presupuesto As Boolean = False

        If MessageBox.Show("Desea Generar Venta de Productos Sin Presupuesto ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            generar_Venta_sin_presupuesto = True
        End If


        Me.Label1.Text = Now
        Dim periodo_actual As Integer = giPeriodo.ToString & _nombre_periodo.ToString.Substring(_nombre_periodo.IndexOf("_") + 1, 2).ToString
        Try
            Otrans.open()

            For icount = 0 To _productos.Length - 1
                'ls_sql = "pa_var_um_ventas_rango_periodo '" & gs_empresa & "','" & _productos(icount) & _
                ls_sql = "pa_var_um_cbo_ventas_rango_periodo '" & gs_empresa & "','" & _productos(icount) & _
                        "',NULL," & (periodo_actual - 100).ToString & "," & _
                        periodo_actual.ToString
                dt = Otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    For Each dr In ods.Tables("productos").Rows
                        If dr.Item("producto").ToString = _productos(icount) Then
                            Try
                                valor = dt.Compute("Sum(ventasU)", "cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'") / 12
                            Catch ex As Exception
                                valor = 1
                            End Try

                            dr.Item("prom24meses") = valor

                            dr.Item("vmmpa") = dt.Compute("Sum(ventasU)", "periodo=" & (periodo_actual - 100).ToString & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                            dr.Item("mes_1") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-1).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                            dr.Item("mes_2") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-2).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                            dr.Item("mes_3") = dt.Compute("Sum(ventasU)", "periodo=" & fecha_actual.AddMonths(-3).ToString("yyyyMM") & " and cliente = '" & dr.Item("cliente") & "' and producto = '" & dr.Item("producto") & "'")
                        End If
                    Next
                    ''Debo Agregar Los Clientes Que Tengan Venta y no esten en el listado

                    If generar_Venta_sin_presupuesto Then
                        Obtener_Venta_Clientes_Sin_Presupuesto(dt, icount, fecha_actual, periodo_actual)
                        Crear_Filtro_Supervisores()
                    End If

                    Calcular_Precios()

                End If
            Next
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Me.Label2.Text = Now
        Filtrar_Informacion_detalle(0)
        Hacer_Resumen()
        Maquillar_Grid()


    End Sub

    Private Sub dg_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex



        Try

            'Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon

            Dim c As Control = Me.dg_productos.EditingControl

            If colIndex = 5 Then
                Dim dt As DataTable
                If c.Text = "+" Then
                    'Levantar la busqueda
                    Dim frm_busqueda As New frm_busqueda_general
                    frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                    frm_busqueda.parametros = "RazonSocial,Giro,Ejecutivo,vigencia_cliente"
                    frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
                    frm_busqueda.lista_campos = "ctacte, RazonSocial, Giro, Ejecutivo, vigencia_cliente,ListaPrecio "

                    frm_busqueda.txt_buscar1.Focus()
                    frm_busqueda.dg_buscar.ReadOnly = False
                    'frm_busqueda.btn_seleccion_multipe.Visible = True
                    frm_busqueda.Btn_Aceptar.Visible = True
                    frm_busqueda.ShowDialog(Me)

                    c.Text = frm_busqueda.resultado
                    frm_busqueda.Dispose()
                    frm_busqueda = Nothing
                    dt = BuscarCliente(c.Text)
                Else
                    dt = BuscarCliente(c.Text)
                End If
                If dt.Rows.Count = 1 Then
                    ''Validar que el cliente no este en la lista
                    If ClienteDuplicado(dt.Rows(0).Item("ctacte").ToString) Then
                        MessageBox.Show("Este Cliente Ya Esta Presupuestado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Value = dt.Rows(0).Item("ctacte").ToString
                        Me.dg_productos.Item(e.ColumnIndex + 1, e.RowIndex).Value = dt.Rows(0).Item("nombre_cliente").ToString
                        Me.dg_productos.Item(e.ColumnIndex - 1, e.RowIndex).Value = dt.Rows(0).Item("ejecutivo")
                        Me.dg_productos.Item(e.ColumnIndex - 2, e.RowIndex).Value = dt.Rows(0).Item("tipo")
                        Me.dg_productos.Item(e.ColumnIndex - 3, e.RowIndex).Value = dt.Rows(0).Item("vigencia_cliente").ToString
                        Me.dg_productos.Item(e.ColumnIndex - 5, e.RowIndex).Value = Me.lbl_codigo.Text
                        Me.dg_productos.Item(e.ColumnIndex + 2, e.RowIndex).Value = Me.lbl_presupuesto.Text
                        Me.dg_productos.Item(e.ColumnIndex + 3, e.RowIndex).Value = 0
                        Me.dg_productos.Item("supervisor", e.RowIndex).Value = dt.Rows(0).Item("supervisor").ToString
                        Me.dg_productos.Item("modificado", e.RowIndex).Value = 1

                    End If
                Else
                    MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    Me.dg_productos.Item(e.ColumnIndex + 1, e.RowIndex).Value = ""
                    Me.dg_productos.Item(e.ColumnIndex - 1, e.RowIndex).Value = ""

                End If
            ElseIf colIndex = 8 Then
                Me.dg_productos.Item(colIndex + 1, e.RowIndex).Value = Me.dg_productos.Item(colIndex, e.RowIndex).Value * dprecio
                Me.dg_productos.Item("precio", e.RowIndex).Value = dprecio
                Agregar_Cambios_Temporales(Me.dg_productos.Rows(e.RowIndex))
                Me.dg_productos.Item("modificado", e.RowIndex).Value = 1
                Calcular_Precios()
                Hacer_Resumen()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_AplicarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AplicarSugerido.Click
        Dim dr As DataRow
        Dim drv As DataRowView

        If MessageBox.Show("Esta Seguro de Aplicar el Sugerido", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If filtro_actual.Length > 0 Then
                For Each drv In ods.Tables("productos").DefaultView
                    If drv.Item("cliente").ToString.Length > 0 Then
                        drv.Item("cantidad") = drv.Item("sugerido")
                        drv.Item("valor") = drv.Item("cantidad") * drv.Item("precio")
                        drv.Item("modificado") = 1
                        Me.Agregar_Cambios_Temporales_dr(drv.Row)
                    End If
                Next
            Else
                For Each dr In ods.Tables("productos").Rows
                    dr.Item("cantidad") = dr.Item("sugerido")
                    dr.Item("valor") = dr.Item("cantidad") * dr.Item("precio")
                    dr.Item("modificado") = 1
                    Me.Agregar_Cambios_Temporales_dr(dr)
                Next
            End If
        End If
        Hacer_Resumen()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro de Guardar Permanentemente los Cambios", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Guardar_Cambios()
        End If
    End Sub


    Private Sub dg_resumen_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_resumen.CellMouseClick
        Filtrar_Informacion_detalle(e.RowIndex)
    End Sub

    'QuitarFiltro
    Private Sub QuitarFiltrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitarFiltrarToolStripMenuItem.Click
        ods.Tables("productos").DefaultView.RowFilter = filtro_actual
    End Sub


    Private Sub dg_resumen_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_resumen.RowEnter
        Filtrar_Informacion_detalle(e.RowIndex)
    End Sub

    Private Sub dg_productos_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dg_productos.UserDeletedRow
        Try
            ' Me.Agregar_Productos_Eliminados(Me.dg_productos.CurrentRow)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellContentClick

    End Sub

    Private Sub dg_productos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dg_productos.UserDeletingRow
        Try
            Me.Agregar_Productos_Eliminados(Me.dg_productos.CurrentRow)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If MessageBox.Show("Esta Seguro de Actualizar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Actualizar_Ppto_DATASERVER()
        End If
    End Sub

    Private Sub dg_productos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg_productos.DataError
        MessageBox.Show(e.Exception.Message)
    End Sub

    Private Sub dg_resumen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_resumen.CellContentClick

    End Sub
End Class