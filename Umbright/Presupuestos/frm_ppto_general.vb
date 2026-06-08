Public Class frm_ppto_general
    Dim Ods As New DataSet
    Dim _sfiltro As String = ""
    Dim mostrar_comercial As Boolean = False

    Private Sub Crear_Estructura()
        Dim icount As Integer
        Dim sname As String

        Dim dt As New DataTable
        dt.TableName = "ppto_mensual"

        dt.Columns.Add(New DataColumn("Vigente", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt.Columns.Add(New DataColumn("BU", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("UxC", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Volumen", GetType(Double)))

        For icount = 1 To 12
            sname = "ppto_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
            sname = "comercial_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
            sname = "color_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        Next
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        dt.Columns.Add(New DataColumn("combo", GetType(String)))
        dt.Columns("codigo").Unique = True
        Ods.Tables.Add(dt.Copy)

        dt.TableName = "resumen_ppto_mensual"
        Ods.Tables.Add(dt.Copy)

        dt.TableName = "ppto_mensual_cambios"
        Ods.Tables.Add(dt.Copy)

        dt.TableName = "ppto_mensual_original"
        Ods.Tables.Add(dt.Copy)

        dt = New DataTable("producto_derivado")
        dt.Columns.Add(New DataColumn("producto_padre", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        Ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub Maquillar_Grid_Resumen()

        Me.dg_resumen.DataSource = Ods.Tables("resumen_ppto_mensual")
        Me.dg_resumen.AutoResizeColumns()
        Me.dg_resumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader

        Me.dg_resumen.RowsDefaultCellStyle.BackColor = Color.White
        Me.dg_resumen.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String
        Dim mes_actual As Date

        For Each dc In Me.dg_resumen.Columns
            dc.ReadOnly = True
            If dc.Name.ToLower.StartsWith("ppto") Then
                mes = dc.Name.Split("_")
                mes_actual = Now.AddMonths((Now.Month * -1) + Int32.Parse(mes(1)))
                dc.HeaderText = StrConv(mes_actual.ToString("MMMM"), VbStrConv.ProperCase)
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ElseIf dc.Name.ToLower = "total" Then
                dc.HeaderText = StrConv(dc.Name, VbStrConv.ProperCase)
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ElseIf dc.Name.ToLower.StartsWith("comercial") Then
                mes = dc.Name.Split("_")
                mes_actual = Now.AddMonths((Now.Month * -1) + Int32.Parse(mes(1)))
                dc.HeaderText = "Com " & StrConv(mes_actual.ToString("MMMM"), VbStrConv.ProperCase)
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dc.Visible = False
            End If
        Next

        'Me.dg_resumen.AutoResizeColumnHeadersHeight()
    End Sub

    Private Sub Maquillar_Grid()

        Me.dg_presupuesto.DataSource = Ods.Tables("ppto_mensual")
        Me.dg_presupuesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dg_presupuesto.RowsDefaultCellStyle.BackColor = Color.White
        Me.dg_presupuesto.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String
        Dim mes_actual As Date

        For Each dc In Me.dg_presupuesto.Columns
            dc.ReadOnly = True
            If dc.Name.ToLower.StartsWith("ppto") Then
                mes = dc.Name.Split("_")
                mes_actual = Now.AddMonths((Now.Month * -1) + Int32.Parse(mes(1)))
                dc.HeaderText = StrConv(mes_actual.ToString("MMMM"), VbStrConv.ProperCase)
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ElseIf dc.Name.ToLower.StartsWith("vige") Then
                dc.Width = 10
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            ElseIf dc.Name.ToLower = "total" Then
                dc.DefaultCellStyle.Format = "n0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End If
        Next

    End Sub

    Private Sub Mostrar_Meses_Resumen()

        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String

        Dim dtotal As Integer = 0



        For Each dc In Me.dg_resumen.Columns
            'dc.ReadOnly = True
            If dc.Name.ToLower.StartsWith("ppto") Then
                mes = dc.Name.Split("_")
                If Me.cl_mes_mostrar.GetItemCheckState(Int32.Parse(mes(1)) - 1) = CheckState.Checked Then
                    dc.ReadOnly = True
                    dc.Visible = True
                Else
                    dc.Visible = False
                End If
            ElseIf dc.Name.ToLower = "total" Then
                dc.Visible = True
                dc.SortMode = DataGridViewColumnSortMode.Automatic
            ElseIf dc.Name.ToLower.StartsWith("comercial") And mostrar_comercial Then
                mes = dc.Name.Split("_")
                If Me.cl_mes_mostrar.GetItemCheckState(Int32.Parse(mes(1)) - 1) = CheckState.Checked Then
                    dc.ReadOnly = True
                    dc.Visible = True
                Else
                    dc.Visible = False
                End If

            Else
                dc.Visible = False
            End If
        Next

    End Sub

    Private Sub Mostrar_Meses()
        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String
        Dim icount As Integer

        If Me.btn_guardar.Visible = False Then
            Me.dg_presupuesto.AllowUserToAddRows = False
        End If

        For Each dc In Me.dg_presupuesto.Columns
            dc.ReadOnly = True
            If dc.Name.ToLower.StartsWith("ppto") Then
                mes = dc.Name.Split("_")
                dc.Visible = False
                If Me.cl_mes_mostrar.GetItemCheckState(Int32.Parse(mes(1)) - 1) = CheckState.Checked Then

                    If Int32.Parse(giPeriodo.ToString & mes(1)) > Int32.Parse(Now.ToString("yyyyMM")) Then   ''(c) validar tambien año utilizado
                        If Me.btn_guardar.Visible = True Then  ''Si no tiene Permisos para 
                            dc.ReadOnly = False
                        Else
                            dc.ReadOnly = True
                        End If
                    Else
                        dc.ReadOnly = True
                    End If
                    dc.Visible = True
                End If

            ElseIf dc.Name.ToLower = "codigo" Then
                dc.Visible = True
                dc.ReadOnly = False
            ElseIf dc.Name.StartsWith("Prov") Or dc.Name.StartsWith("Marc") Or _
                dc.Name.StartsWith("UxC") Or dc.Name.StartsWith("Volu") Or dc.Name.StartsWith("com") Or dc.Name.StartsWith("Vig") _
                Or dc.Name.ToLower.StartsWith("bu") Then
                dc.Visible = False
                For icount = 12 To 15
                    If Me.cl_mes_mostrar.GetItemCheckState(icount) = CheckState.Checked _
                        And dc.Name.ToLower = Me.cl_mes_mostrar.Items.Item(icount).ToString.ToLower Then
                        dc.Visible = True
                        Exit For
                    End If
                Next
            ElseIf dc.Name.StartsWith("color") Or dc.Name.StartsWith("comercial") Then
                dc.Visible = False

            End If
        Next

        Me.dg_presupuesto.Columns(5).Frozen = True


    End Sub

    Private Sub Totalizar()
        Dim dr2 As DataRow
        Dim icount, itotal, totalgeneral As Integer
        Dim sname As String


        Try

            totalgeneral = 0
            Ods.Tables("resumen_ppto_mensual").Rows.Clear()
            dr2 = Ods.Tables("resumen_ppto_mensual").NewRow
            For icount = 1 To 12
                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                dr2.Item(sname) = 0
                sname = "comercial_" & icount.ToString.PadLeft(2, "0")
                dr2.Item(sname) = 0
            Next


            For icount = 1 To 12
                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                Try
                    itotal = Ods.Tables("ppto_mensual").Compute("Sum(" & sname & ")", _sfiltro)
                    dr2.Item(sname) += itotal
                Catch ex As Exception
                End Try

                sname = "comercial_" & icount.ToString.PadLeft(2, "0")
                Try
                    itotal = Ods.Tables("ppto_mensual").Compute("Sum(" & sname & ")", _sfiltro)
                    dr2.Item(sname) += itotal
                Catch ex As Exception
                End Try


            Next
            Ods.Tables("resumen_ppto_mensual").Rows.Add(dr2)

        Catch ex As Exception
        Finally
            Totalizar_Resumen()

        End Try
    End Sub

    Private Sub Totalizar_Resumen()
        Dim itotal, totalgeneral As Integer
        'Calculando el total de los meses
        Try
            Dim dc As DataGridViewTextBoxColumn
            For Each dc In Me.dg_resumen.Columns
                If dc.Name.ToLower.StartsWith("ppto") And dc.Visible = True Then
                    itotal = Ods.Tables("resumen_ppto_mensual").Rows(0).Item(dc.Name)
                    totalgeneral += itotal
                End If
            Next
            Ods.Tables("resumen_ppto_mensual").Rows(0).Item("total") = totalgeneral

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Totalizar_Productos()

        Dim dr As DataRow
        Dim dc As DataGridViewTextBoxColumn

        Try
            For Each dr In Ods.Tables("ppto_mensual").Rows
                dr.Item("total") = 0
            Next

            For Each dc In Me.dg_presupuesto.Columns
                If dc.Name.ToLower.StartsWith("ppto") And dc.Visible = True Then
                    For Each dr In Ods.Tables("ppto_mensual").Rows
                        If dr.Item(dc.Name).ToString.Length > 0 Then
                            dr.Item("total") += dr.Item(dc.Name)
                        End If
                    Next
                End If
            Next


        Catch ex As Exception
        End Try
    End Sub

    Private Sub Armar_Filtro()


        Dim clsgen As New ClasesGenerales.General



        Try
            If Me.txt_texto.Text.Length > 0 Then
                _sfiltro = clsgen.Armar_Filtro(Me.cmb_campos.Text, "", "", Me.txt_texto.Text, "", "", Me.cmb_operadores.Text, "", "", "", "")
            Else
                _sfiltro = ""
            End If

        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
        Ods.Tables("ppto_mensual").DefaultView.RowFilter = _sfiltro
        Totalizar()


        If _sfiltro.Length > 0 And tiene_permisos("mpt_verpresupuestoComercial") Then
            Me.btn_Seleccion.Visible = True
        Else
            Me.btn_Seleccion.Visible = False
        End If

    End Sub

    Private Function BuscarProducto(ByVal pcodigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim ls_sql As String
        Dim nombre_producto As String = ""

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & pcodigo & "'"
            dt = Otrans.Obtiene(ls_sql)
            nombre_producto = dt.Rows(0).Item("glosa").ToString

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Private Sub Aplicar_Seguridad()

        If tiene_permisos("mpt_verpresupuestoGeneral") Then
            Me.btn_actualizar.Visible = True
        End If
        If tiene_permisos("mpt_exportarpresupuesto") Then
            Me.btn_exportar_excel.Visible = True
        End If
        If tiene_permisos("mpt_modificarPresupuestoGeneral") Then
            Me.btn_guardar.Visible = True
        End If


    End Sub

    Private Function Crear_Tabla_Temporal(ByVal dv As DataView) As DataTable
        Dim dt As DataTable
        Dim dgc As DataGridViewColumn
        Dim drv As DataRowView
        Dim dr As DataRow
        Dim dc As DataColumn

        dt = dv.Table.Clone

        For Each dgc In Me.dg_presupuesto.Columns
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

            dt = Crear_Tabla_Temporal(Ods.Tables("ppto_mensual").DefaultView)

            mExcel.ocultar_columnas = ""

            mExcel.sFileName = "c:\temp\" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
            mExcel.nAgregar_Filas = 2
            mExcel.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            mExcel.Nombre_Columnas = "" ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

            For Each dc In Me.dg_presupuesto.Columns
                If dc.Visible = True Then
                    mExcel.Nombre_Columnas &= dc.HeaderText & ","
                End If
            Next

            mExcel.DataTableToExcel(dt)
        Catch ex As Exception
        Finally

            mExcel = Nothing

        End Try


    End Sub

    Private Function Validar_Cantidad(ByVal producto As String, ByVal cantidad As Integer, ByVal columna As String) As Integer
        Dim cantidadvalida As Integer = cantidad



        If Not tiene_permisos("mpt_bajarUnidadesPresupuestoGeneral") Then
            Ods.Tables("ppto_mensual_original").DefaultView.RowFilter = "codigo = '" & producto & "'"
            If Ods.Tables("ppto_mensual_original").DefaultView.Count > 0 Then
                If cantidad < Ods.Tables("ppto_mensual_original").DefaultView(0).Item(columna) Then
                    cantidadvalida = Ods.Tables("ppto_mensual_original").DefaultView(0).Item(columna)
                End If
            End If
        End If
        Return cantidadvalida

    End Function


    Private Sub Hacer_Backup()

        ' Ods.Tables.Add(dt2.Copy)

        Dim dr, dr2 As DataRow
        Dim dc As DataColumn

        Try
            Ods.Tables("ppto_mensual_original").Rows.Clear()
            For Each dr In Ods.Tables("ppto_mensual").Rows
                dr2 = Ods.Tables("ppto_mensual_original").NewRow
                For Each dc In Ods.Tables("ppto_mensual").Columns
                    dr2.Item(dc.ColumnName) = dr.Item(dc.ColumnName)
                Next
                Ods.Tables("ppto_mensual_original").Rows.Add(dr2)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Agregar_Cambios_Temporales(ByVal _dr As DataGridViewRow, ByVal columna As String, ByVal _cantidad As Integer)
        Dim dr As DataRow
        Dim encontrado As Boolean = False

        Try
            For Each dr In Ods.Tables("ppto_mensual_cambios").Rows
                If dr.Item("codigo") = _dr.Cells("codigo").Value.ToString Then

                    dr.Item(columna) = _cantidad '_dr.Cells(columna).Value.ToString
                    'dr.Item("valor") = _dr.Cells(9).Value.ToString
                    encontrado = True
                    Exit For
                End If
            Next

            If Not encontrado Then
                dr = Ods.Tables("ppto_mensual_cambios").NewRow
                dr.Item("codigo") = _dr.Cells("codigo").Value.ToString.Trim
                dr.Item(columna) = _cantidad ' _dr.Cells(columna).Value.ToString

                Ods.Tables("ppto_mensual_cambios").Rows.Add(dr)
                encontrado = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Guardar_Cambios()

        Dim dr As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("Umbralsa")
        Dim icount As Integer
        Dim sname, ls_sql As String
        Dim lb_grabo As Boolean = False
        Dim lb_errores As Boolean = False


        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            otrans.open()
            For Each dr In Ods.Tables("ppto_mensual_cambios").Rows
                If dr.Item("codigo").ToString.Length > 0 Then
                    For icount = 1 To 12
                        sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                        Try
                            If dr.Item(sname).ToString.Length > 0 Then
                                If dr.Item(sname) > 0 Then
                                    ls_sql = "pa_sel_um_ppt_presupuesto_general_total '" & gs_empresa & "'," & _
                                        giPeriodo.ToString & icount.ToString.PadLeft(2, "0") & ",'" & _
                                        dr.Item("codigo").ToString & "'," & giPeriodo
                                    dt = otrans.Obtiene(ls_sql)
                                    If dt.Rows.Count > 0 Then ''Editar
                                        ls_sql = "pa_upd_um_ppt_presupuesto_general '" & gs_empresa & "','" & _
                                            dr.Item("codigo").ToString & "','" & _
                                            giPeriodo.ToString & icount.ToString.PadLeft(2, "0") & "'," & _
                                            dr.Item(sname).ToString & ",'" & _
                                            dt.Rows(0).Item("nodocumento").ToString & "'," & _
                                            giPeriodo.ToString & giPeriodo.ToString & ",'" & _
                                            gs_usuario & "'"

                                        otrans.Actualiza(ls_sql)
                                        If otrans.Codigo_error > 0 Then
                                            MessageBox.Show("Problemas Al Actualizar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            lb_errores = True
                                        Else
                                            lb_grabo = True
                                        End If

                                    Else 'agregar nuevo ppto

                                        ls_sql = "pa_ins_um_ppt_presupuesto_general '" & gs_empresa & "','" & _
                                                dr.Item("codigo").ToString & "','" & _
                                                giPeriodo.ToString & icount.ToString.PadLeft(2, "0") & "'," & _
                                                dr.Item(sname).ToString & "," & _
                                                giPeriodo.ToString & giPeriodo.ToString & ",'" & _
                                                gs_usuario & "'"
                                        otrans.Ingresa(ls_sql)
                                        If otrans.Codigo_error > 0 Then
                                            MessageBox.Show("Problemas Al Actualizar " & dr.Item("codigo") & Chr(13) & otrans.descripcion_error, "Insertar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            lb_errores = True
                                        Else
                                            lb_grabo = True
                                        End If
                                    End If 'Modificar/Agregar
                                ElseIf dr.Item(sname) = 0 Then '>0
                                    ls_sql = "pa_sel_um_ppt_presupuesto_general_total '" & gs_empresa & "'," & _
                                     giPeriodo.ToString & icount.ToString.PadLeft(2, "0") & ",'" & _
                                     dr.Item("codigo").ToString & "'," & giPeriodo
                                    dt = otrans.Obtiene(ls_sql)
                                    If dt.Rows.Count > 0 Then ''Editar
                                        ls_sql = "pa_upd_um_ppt_presupuesto_general '" & gs_empresa & "','" & _
                                            dr.Item("codigo").ToString & "','" & _
                                            giPeriodo.ToString & icount.ToString.PadLeft(2, "0") & "'," & _
                                            dr.Item(sname).ToString & ",'" & _
                                            dt.Rows(0).Item("nodocumento").ToString & "'," & _
                                            giPeriodo.ToString & giPeriodo.ToString & ",'" & _
                                            gs_usuario & "'"

                                        otrans.Actualiza(ls_sql)
                                        If otrans.Codigo_error > 0 Then
                                            MessageBox.Show("Problemas Al Actualizar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Insertar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            lb_errores = True
                                        Else
                                            lb_grabo = True
                                        End If
                                    End If

                                End If ' > 0
                            End If 'no sea nulo

                        Catch ex As Exception
                        End Try
                    Next

                End If
            Next
            If lb_grabo Then
                If lb_errores Then
                    MessageBox.Show("Proceso Finalizado Con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try

    End Sub

    Private Sub Llenar_Producto_Analisis()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow

        Try


            otrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dr.Item("analisisproducto5").ToString = "005" Then

                    Ods.Tables("ppto_mensual").DefaultView.RowFilter = "codigo = '" & dr.Item("producto") & "'"
                    If Ods.Tables("ppto_mensual").DefaultView.Count > 0 Then
                        Ods.Tables("ppto_mensual").DefaultView(0).Item("vigente") = "X"
                    End If
                   
                End If
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Ods.Tables("ppto_mensual").DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub Llenar_Productos_Combos()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow

        Try
            otrans.open()
            ls_sql = "pa_var_um_ProdReceta_detalle '" & gs_empresa & "',0,null"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows


                Ods.Tables("ppto_mensual").DefaultView.RowFilter = "codigo = '" & dr.Item("productoI") & "'"
                If Ods.Tables("ppto_mensual").DefaultView.Count > 0 Then
                    Ods.Tables("ppto_mensual").DefaultView(0).Item("combo") = "si"
                End If


            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Function Producto_No_Existe(ByVal cod_producto As String) As Boolean
        Dim lb_no_existe As Boolean = True
        Dim dt As New DataTable

        Try
            'dt = Ods.Tables("ppto_mensual")

            'dt.DefaultView.RowFilter = "codigo = '" & cod_producto & "'"
            ' If dt.DefaultView.Count > 1 Then
            'lb_no_existe = False
            'End If

        Catch ex As Exception

        End Try
        Return lb_no_existe
    End Function

    Private Sub Llenar_Informacion_Comercial()
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim sname As String
        Dim pintar As Integer = 0



        Try
            mostrar_comercial = True
            Otrans.open()
            ls_sql = "pa_sel_um_ppt_presupuesto_cliente_consolidado '" & gs_empresa & "'," & giPeriodo.ToString & giPeriodo.ToString
            dt = Otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows

                Ods.Tables("ppto_mensual").DefaultView.RowFilter = "codigo = '" & dr.Item("producto") & "'"

                If Ods.Tables("ppto_mensual").DefaultView.Count > 0 Then
                    If Ods.Tables("ppto_mensual").DefaultView(0).Item("codigo") = dr.Item("producto") Then
                        sname = "comercial_" & dr.Item("periodo").ToString.Substring(4, 2)
                        Ods.Tables("ppto_mensual").DefaultView(0).Item(sname) = dr.Item("cantidad")
                        sname = "ppto_" & dr.Item("periodo").ToString.Substring(4, 2)
                        If Val(dr.Item("cantidad")) > Val(Ods.Tables("ppto_mensual").DefaultView(0).Item(sname)) Then
                            pintar = 1
                        ElseIf Val(dr.Item("cantidad")) < Val(Ods.Tables("ppto_mensual").DefaultView(0).Item(sname)) Then
                            pintar = -1
                        Else
                            pintar = 0
                        End If
                        sname = "color_" & dr.Item("periodo").ToString.Substring(4, 2)
                        Ods.Tables("ppto_mensual").DefaultView(0).Item(sname) = pintar
                    End If
                End If
            Next





        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Ods.Tables("ppto_mensual").DefaultView.RowFilter = ""

    End Sub

    Private Sub frm_ppto_general_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Crear_Estructura()
        Aplicar_Seguridad()

        Dim icount As Integer
        If Now.Month = 12 Then
            Me.cl_mes_mostrar.SetItemChecked(0, True)
        Else
            Me.cl_mes_mostrar.SetItemChecked(Now.Month, True)
        End If
        For icount = 12 To 14
            Me.cl_mes_mostrar.SetItemChecked(icount, True)
        Next
        Maquillar_Grid()
        Maquillar_Grid_Resumen()
        Mostrar_Meses()
        Mostrar_Meses_Resumen()


        Me.Text = ":: Presupuesto General ::  Periodo Actual - " & giPeriodo.ToString

    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Dim otrans As New Transaccional.Conexion("Umbralsa")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux, dr2 As DataRow
        Dim sname As String
        Dim icount As Integer



        Try
            mostrar_comercial = False
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Ods.Tables("ppto_mensual").Rows.Clear()
            Ods.Tables("resumen_ppto_mensual").Rows.Clear()
            Ods.Tables("ppto_mensual_cambios").Rows.Clear()
            Ods.Tables("producto_derivado").Rows.Clear()

            dr2 = Ods.Tables("resumen_ppto_mensual").NewRow
            For icount = 1 To 12
                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                dr2.Item(sname) = 0
            Next

            'Me.Label1.Text = Now

            otrans.open()
            ls_sql = "pa_sel_um_ppt_presupuesto_general '" & gs_empresa & "',NULL,NULL," & giPeriodo.ToString
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                'If dr.Item("producto") = "0032815001" Then
                '    MessageBox.Show("")
                'End If
                Ods.Tables("ppto_mensual").DefaultView.RowFilter = "codigo = '" & dr.Item("producto") & "'"

                If Ods.Tables("ppto_mensual").DefaultView.Count = 0 Then
                    dr_aux = Ods.Tables("ppto_mensual").NewRow

                    dr_aux.Item("proveedor") = dr.Item("subfamilia")
                    dr_aux.Item("marca") = dr.Item("tipo")
                    dr_aux.Item("bu") = dr.Item("bu").ToString
                    dr_aux.Item("vigente") = dr.Item("vigente")
                    dr_aux.Item("codigo") = dr.Item("producto")
                    dr_aux.Item("descripcion") = dr.Item("glosa")
                    dr_aux.Item("UxC") = dr.Item("factoralt")
                    dr_aux.Item("Volumen") = dr.Item("volumen")
                    dr_aux.Item("Total") = 0
                    dr_aux.Item("combo") = "no"
                    For icount = 1 To 12
                        sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                        dr_aux.Item(sname) = 0
                        sname = "comercial_" & icount.ToString.PadLeft(2, "0")
                        dr_aux.Item(sname) = 0
                        sname = "color_" & icount.ToString.PadLeft(2, "0")
                        dr_aux.Item(sname) = 0
                    Next


                    Ods.Tables("ppto_mensual").Rows.Add(dr_aux)
                    Ods.Tables("ppto_mensual").DefaultView.RowFilter = "codigo = '" & dr.Item("producto") & "'"
                End If

                If Ods.Tables("ppto_mensual").DefaultView(0).Item("codigo") = dr.Item("producto") Then
                    sname = "ppto_" & dr.Item("periodo").ToString.Substring(4, 2)
                    Ods.Tables("ppto_mensual").DefaultView(0).Item(sname) = dr.Item("cantidad")
                    dr2.Item(sname) += dr.Item("cantidad")
                End If

            Next

            Ods.Tables("resumen_ppto_mensual").Rows.Add(dr2)
            Ods.Tables("ppto_mensual").DefaultView.RowFilter = ""

            Llenar_Producto_Analisis()


            ls_sql = "pa_sel_um_producto_derivado '" & gs_empresa & "'"
            dt = otrans.Obtiene(ls_sql)

            For Each dr In dt.Rows
                dr2 = Ods.Tables("producto_derivado").NewRow
                dr2.Item("producto") = dr.Item("producto")
                dr2.Item("producto_padre") = dr.Item("producto_padre")
                dr2.Item("glosa") = dr.Item("glosa")
                Ods.Tables("producto_derivado").Rows.Add(dr2)
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btn_generar")
        Finally
            Hacer_Backup()
            otrans.close()
            otrans = Nothing
            Mostrar_Meses()
            Mostrar_Meses_Resumen()
            Armar_Filtro()
            Totalizar_Productos()
        End Try
    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If MessageBox.Show("Esta Seguro de Aplicar Los Cambios ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Guardar_Cambios()
        End If

    End Sub

    ''Muestro el Detalle x Cliente del Producto y el mes seleccionado
    Private Sub dg_presupuesto_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_presupuesto.CellDoubleClick

        Try
            Dim cell As DataGridViewCell = Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex)
            Dim icount As Integer = 0

            If Me.dg_presupuesto.Columns(e.ColumnIndex).Name.ToLower.StartsWith("ppto") Then
                If tiene_permisos("mpt_verpresupuestoComercial") Then

                    cell = Me.dg_presupuesto.Item(3, e.RowIndex)
                    Dim productos(0) As String
                    Dim nombre_productos(0) As String
                    Dim valores(0) As Integer

                    Try
                        Ods.Tables("producto_derivado").DefaultView.RowFilter = "producto_padre = '" & cell.Value.ToString & "'"
                        If Ods.Tables("producto_derivado").DefaultView.Count > 0 Then
                            If MessageBox.Show("Existen Productos Derivados de Este Codigo," & Chr(13) & _
                                               "          Desea Agregarlos", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                ReDim productos(Ods.Tables("producto_derivado").DefaultView.Count)
                                ReDim nombre_productos(Ods.Tables("producto_derivado").DefaultView.Count)
                                ReDim valores(Ods.Tables("producto_derivado").DefaultView.Count)
                                For Each drv As DataRowView In Ods.Tables("producto_derivado").DefaultView
                                    icount += 1
                                    productos(icount) = drv.Item("producto")
                                    nombre_productos(icount) = drv.Item("glosa")
                                    valores(icount) = 0
                                Next
                            End If

                        End If
                    Catch ex As Exception

                    End Try


                    productos(0) = cell.Value.ToString
                    nombre_productos(0) = Me.dg_presupuesto.Item(4, e.RowIndex).Value.ToString
                    Try
                        valores(0) = Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value.ToString
                    Catch ex As Exception
                        valores(0) = 0
                    End Try
                    Dim oform As New frm_presupuesto_multiple_producto_cliente
                    oform._nombre_periodo = Me.dg_presupuesto.Columns(e.ColumnIndex).Name
                    oform._periodo = Me.dg_presupuesto.Columns(e.ColumnIndex).HeaderText
                    oform._valores = valores
                    oform._productos = productos
                    oform._nombreproductos = nombre_productos

                    oform.Show()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dg_presupuesto_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dg_presupuesto.CellValidating
        Try


            Dim cell As DataGridViewCell = Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex)
            Dim cantidadOriginal As Integer


            If cell.IsInEditMode Then
                Dim c As Control = Me.dg_presupuesto.EditingControl

                Select Case Me.dg_presupuesto.Columns(e.ColumnIndex).Name
                    Case "cod_menu", "rno"
                        Me.dg_presupuesto.Item(e.ColumnIndex + 1, e.RowIndex).Value = BuscarProducto(c.Text)
                    Case "name"
                        c.Text = CleanInputAlphabet(c.Text)
                End Select

                Select Case Me.dg_presupuesto.Columns(e.ColumnIndex).Name.Substring(0, 4)
                    Case "ppto"

                        Try
                            cantidadOriginal = Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value
                        Catch ex As Exception
                            cantidadOriginal = 0
                        End Try
                        Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                        c.Text = Validar_Cantidad(Me.dg_presupuesto.Item("codigo", e.RowIndex).Value.ToString, c.Text, Me.dg_presupuesto.Columns(e.ColumnIndex).Name)
                        If c.Text <> cantidadOriginal Then
                            Agregar_Cambios_Temporales(Me.dg_presupuesto.Rows(e.RowIndex), Me.dg_presupuesto.Columns(e.ColumnIndex).Name, c.Text)
                        End If
                        Totalizar()

                    Case "codi"

                        Dim dt As DataTable
                        If c.Text = "+" Then
                            'Levantar la busqueda
                            Dim frm_busqueda As New frm_busqueda_general
                            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                            frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                            frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                            frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.ShowDialog(Me)

                            c.Text = frm_busqueda.resultado
                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                            dt = BuscarProducto(c.Text)
                        Else
                            dt = BuscarProducto(c.Text)
                        End If
                        If dt.Rows.Count = 1 Then
                            'Validar Que No Exista en el grid
                            If Producto_No_Existe(c.Text) Then
                                Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
                                Me.dg_presupuesto.Item(e.ColumnIndex + 1, e.RowIndex).Value = dt.Rows(0).Item("Glosa").ToString
                                Me.dg_presupuesto.Item(e.ColumnIndex - 1, e.RowIndex).Value = dt.Rows(0).Item("tipo").ToString
                                Me.dg_presupuesto.Item(e.ColumnIndex - 2, e.RowIndex).Value = dt.Rows(0).Item("subfamilia").ToString
                                Me.dg_presupuesto.Item(e.ColumnIndex - 3, e.RowIndex).Value = dt.Rows(0).Item("Vigente").ToString
                            Else
                                MessageBox.Show("Este Producto Ya Esta Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            If c.Text.Length > 1 Then
                                MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = ""
                                Me.dg_presupuesto.Item(e.ColumnIndex + 1, e.RowIndex).Value = ""
                                Me.dg_presupuesto.Item(e.ColumnIndex - 1, e.RowIndex).Value = ""
                            End If
                        End If
                        Try
                            Me.dg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                        Catch ex As Exception
                        End Try
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function CleanInputAlphabet(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[0-9\b\s-]", "")
    End Function

    Private Function CleanInputNumber(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-.]", "")
    End Function

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Mostrar_Meses()
        Mostrar_Meses_Resumen()
        Totalizar_Resumen()
        Totalizar_Productos()
    End Sub


    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Armar_Filtro()
    End Sub

    Private Sub txt_texto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_texto.KeyPress
        If e.KeyChar = Chr(13) Then
            Armar_Filtro()
        End If
    End Sub


    Private Sub dg_presupuesto_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dg_presupuesto.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dg_presupuesto.Rows(rowIndex)
                'If therow.Cells("combo").Value.ToString() = "si" Then
                '    therow.DefaultCellStyle.ForeColor = Color.Green
                'Else
                If therow.Cells("Vigente").Value.ToString() = "N" Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf therow.Cells("Vigente").Value.ToString() = "X" Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                Else
                    For icount = 1 To 12
                        sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                        If Me.dg_presupuesto.Columns(sname).Visible = True Then
                            sname = "color_" & icount.ToString.PadLeft(2, "0")
                            If therow.Cells(sname).Value.ToString = 1 Then
                                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                                therow.Cells(sname).Style.BackColor = Color.Yellow
                                'therow.Cells(sname).ToolTipText = "Mercadeo < Comercial"
                            ElseIf therow.Cells(sname).Value.ToString = -1 Then
                                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                                therow.Cells(sname).Style.BackColor = Color.Coral
                                'therow.Cells(sname).ToolTipText = "Mercadeo > Comercial"
                            Else
                                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                                therow.Cells(sname).Style.BackColor = Color.White
                            End If
                        End If
                    Next

                End If



            End If
            'color azul
            'Me.dg_presupuesto.Columns("Vigente").Width = 5
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_Seleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Seleccion.Click

        If _sfiltro.Length > 0 Then



            Dim selectedCellCount As Integer = _
                    Me.dg_presupuesto.GetCellCount(DataGridViewElementStates.Selected)

            If selectedCellCount > 0 Then
                If Me.dg_presupuesto.AreAllCellsSelected(True) Then
                    MessageBox.Show("Todas Las Celdas Estan Seleccionadas", "Seleccion Celdas")
                Else



                    Dim i As Integer
                    Dim ncolumn As Integer = -1
                    Dim productos As String()
                    Dim valores As Integer()
                    Dim nombre_productos As String()

                    ReDim productos(selectedCellCount - 1)
                    ReDim valores(selectedCellCount - 1)
                    ReDim nombre_productos(selectedCellCount - 1)

                    ReDim productos(selectedCellCount - 1)
                    ReDim valores(selectedCellCount - 1)
                    ReDim nombre_productos(selectedCellCount - 1)

                    For i = 0 To selectedCellCount - 1

                        If ncolumn = -1 Then
                            ncolumn = Me.dg_presupuesto.SelectedCells(i).ColumnIndex
                            If Not Me.dg_presupuesto.Columns(ncolumn).Name.StartsWith("ppto") Then
                                ncolumn = -1
                                MessageBox.Show("Una o Mas Columnas son Invalidas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For

                            End If
                        ElseIf ncolumn <> Me.dg_presupuesto.SelectedCells(i).ColumnIndex Then
                            ncolumn = -1
                            MessageBox.Show("Solo Puede Seleccionar Datos de Un Mes", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        End If
                        productos(i) = Me.dg_presupuesto.Item(3, Me.dg_presupuesto.SelectedCells(i).RowIndex).Value.ToString
                        valores(i) = Me.dg_presupuesto.Item(ncolumn, Me.dg_presupuesto.SelectedCells(i).RowIndex).Value.ToString
                        nombre_productos(i) = Me.dg_presupuesto.Item(4, Me.dg_presupuesto.SelectedCells(i).RowIndex).Value.ToString
                    Next i
                    If ncolumn <> -1 Then
                        Dim oform As New frm_presupuesto_multiple_producto_cliente
                        oform._nombre_periodo = Me.dg_presupuesto.Columns(ncolumn).Name
                        oform._periodo = Me.dg_presupuesto.Columns(ncolumn).HeaderText
                        oform._valores = valores
                        oform._productos = productos
                        oform._nombreproductos = nombre_productos
                        oform.Show()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Solo Puede Generar Informacion Filtrada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub dg_presupuesto_CellStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dg_presupuesto.CellStateChanged
        If e.Cell.Selected = True Then
            Try
                If e.Cell.Value.ToString.Length = 0 Then
                    e.Cell.Selected = False
                End If
            Catch ex As Exception
                e.Cell.Selected = False
            End Try

        End If
    End Sub


    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Exportar_Vista_Actual()
    End Sub

    Private Sub dg_presupuesto_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg_presupuesto.DataError
        MessageBox.Show(e.Exception.Message)
    End Sub

    Private Sub dg_presupuesto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_presupuesto.CellContentClick

    End Sub

    Private Sub btn_packs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_packs.Click
        Llenar_Informacion_Comercial()
        Totalizar()
        Mostrar_Meses_Resumen()
        Me.Label1.Visible = True
        Me.Label2.Visible = True
    End Sub

    Private Sub dg_presupuesto_CellStyleChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg_presupuesto.CellStyleChanged

    End Sub
End Class