Public Class frm_carga_presupuesto_general
    Dim Ods As New DataSet
    Dim _sfiltro As String = String.Empty
    Dim encabezados_seleccionados As String = String.Empty
    Dim _dtregistros As DataTable


    Private Sub Crear_Estructura()
        Dim icount As Integer
        Dim sname As String

        Dim dt As New DataTable
        dt.TableName = "ppto_mensual"
        dt.Columns.Add(New DataColumn("vigente", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("UxC", GetType(Integer)))

        For icount = 1 To 12
            sname = "ppto_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        Next
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))

        Ods.Tables.Add(dt.Copy)
        dt.TableName = "resumen_ppto_mensual"
        Ods.Tables.Add(dt.Copy)

    End Sub

    Private Sub Procesar_Excel()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados(), encabezados_completo As String


        Dim icount As Integer

        Try
            Me.OFD_productos.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OFD_productos.FileName = ""
            Me.OFD_productos.ShowDialog()

            snombre_archivo = Me.OFD_productos.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas
            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If

            hojas_encabezados = Oaut.obtenerEncabezados


            Dim oform As New frm_columnas

            oform.clb_Columnas.Items.AddRange(hojas_encabezados)
            For icount = 0 To oform.clb_Columnas.Items.Count - 1
                If oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("prod") Then
                    oform.clb_Columnas.Items.Item(icount) += " "
                    oform.clb_Columnas.SetItemChecked(icount, True)
                ElseIf oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("desc") Then
                    oform.clb_Columnas.Items.Item(icount) += " "
                    oform.clb_Columnas.SetItemChecked(icount, True)
                Else
                    oform.clb_Columnas.Items.Item(icount) += " " & giPeriodo.ToString & _
                                Obtener_numero_mes(oform.clb_Columnas.Items.Item(icount).ToString).ToString.PadLeft(2, "0")
                    oform.clb_Columnas.SetItemChecked(icount, True)

                End If
            Next

            oform.ShowDialog()
            encabezados_completo = String.Empty

            oform.clb_Columnas.SetItemChecked(0, True)
            oform.clb_Columnas.SetItemChecked(1, True)
            For icount = 0 To oform.clb_Columnas.Items.Count - 1
                encabezados_completo += "," & oform.clb_Columnas.Items.Item(icount).ToString.Substring(0, oform.clb_Columnas.Items(icount).ToString.IndexOf(" "))
                If oform.clb_Columnas.GetItemChecked(icount) = True Then
                    encabezados_seleccionados += "," & oform.clb_Columnas.Items.Item(icount).ToString.Substring(0, oform.clb_Columnas.Items(icount).ToString.IndexOf(" "))
                End If
            Next
            oform = Nothing



            ' Oaut.pNombreColumnas = encabezados_seleccionados
            Oaut.pNombreColumnas = encabezados_completo
            Label1.Text = Now()

            _dtregistros = Oaut.obtener_registros_nombres()

            Label2.Text = Now()

        Catch ex As Exception
        Finally
            Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try

    End Sub


    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        Procesar_Excel()
        Procesar_tabla(_dtregistros, encabezados_seleccionados)
        Hacer_Resumen()
        Hacer_Total_Detalle()

    End Sub

    Private Sub Procesar_tabla(ByVal _dt As DataTable, ByVal encabezados_seleccionados As String)
        Dim ls_sql As String

        Dim dr, dr_aux As DataRow
        Dim dc As DataColumn
        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("flexline")
        Ods.Tables("ppto_mensual").Rows.Clear()

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)

            For Each dr In _dt.Rows

                dt.DefaultView.RowFilter = "producto = '" & dr.Item(0) & "'"

                If dt.DefaultView.Count > 0 Then
                    Try


                        dr_aux = Ods.Tables("ppto_mensual").NewRow
                        With dt.DefaultView(0)
                            dr_aux.Item("vigente") = .Item("vigente").ToString
                            dr_aux.Item("proveedor") = .Item("subfamilia").ToString
                            dr_aux.Item("marca") = .Item("tipo").ToString
                            dr_aux.Item("codigo") = dr.Item(0)
                            dr_aux.Item("descripcion") = .Item("glosa").ToString
                            dr_aux.Item("UxC") = .Item("FactorAlt")
                        End With


                        For Each dc In _dt.Columns
                            Select Case dc.ColumnName.ToString.ToLower.Substring(0, 3)
                                Case "ene"
                                    dr_aux.Item("ppto_01") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "feb"
                                    dr_aux.Item("ppto_02") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "mar"
                                    dr_aux.Item("ppto_03") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "abr"
                                    dr_aux.Item("ppto_04") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "may"
                                    dr_aux.Item("ppto_05") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "jun"
                                    dr_aux.Item("ppto_06") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "jul"
                                    dr_aux.Item("ppto_07") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "ago"
                                    dr_aux.Item("ppto_08") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "sep"
                                    dr_aux.Item("ppto_09") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "oct"
                                    dr_aux.Item("ppto_10") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "nov"
                                    dr_aux.Item("ppto_11") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                                Case "dic"
                                    dr_aux.Item("ppto_12") = Double.Parse(dr.Item(dc.ColumnName).ToString)
                            End Select
                        Next

                        Ods.Tables("ppto_mensual").Rows.Add(dr_aux)
                    Catch ex As Exception
                        'MessageBox.Show(ex.Message & dr.Item(1))
                    End Try
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            Me.dg_productos.DataSource = Ods.Tables("ppto_mensual")
            Mostrar_Meses(encabezados_seleccionados)

        End Try


    End Sub


    Private Sub Mostrar_Meses(ByVal encabezados_seleccionados As String)
        Dim dc As DataGridViewTextBoxColumn
        Dim mes() As String
        Dim mes_actual As DateTime

        For Each dc In Me.dg_productos.Columns
            If dc.Name.ToLower.StartsWith("ppto") Then
                mes = dc.Name.Split("_")
                mes_actual = Now.AddMonths((Now.Month * -1) + Int32.Parse(mes(1)))
                dc.HeaderText = StrConv(mes_actual.ToString("MMMM"), VbStrConv.ProperCase)
                'dc.Visible = False
                dc.DefaultCellStyle.Format = "N0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                If encabezados_seleccionados.ToString.ToLower.IndexOf(dc.HeaderText.ToLower) > 0 Then
                    dc.Visible = True
                Else
                    dc.Visible = False
                End If


                ''No Dejo Modificar Periodo Anterior
                If Int32.Parse(giPeriodo.ToString & mes(1)) > Int32.Parse(Now.ToString("yyyyMM")) Then   ''(c) validar tambien año utilizado
                    dc.ReadOnly = False
                Else
                    dc.ReadOnly = True
                End If
            ElseIf dc.Name.ToLower.StartsWith("total") Then
                dc.DefaultCellStyle.Format = "N0"
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dc.ReadOnly = True
            ElseIf dc.Name.ToLower = "descripcion" Then
                dc.ReadOnly = True


            ElseIf dc.Name.ToString.ToLower = "vigente" Then
                dc.ReadOnly = True
            End If

        Next

        Me.dg_productos.Columns("descripcion").Frozen = True
        Me.dg_productos.Columns(0).Width = 10

    End Sub

    Private Sub Maquillar_Resumen()
        Dim dc As DataGridViewColumn

        For Each dc In Me.dg_resumen.Columns
            If dc.Name.StartsWith("ppto") Then
                dc.HeaderText = Obtener_Nombre_Mes(dc.Name.ToString.Substring(5, 2))
                dc.DefaultCellStyle.Format = "N0"

                If encabezados_seleccionados.ToString.ToLower.IndexOf(dc.HeaderText.ToLower) > 0 Then
                    dc.Visible = True
                Else
                    dc.Visible = False
                End If

            ElseIf dc.Name.StartsWith("total") Then
                dc.DefaultCellStyle.Format = "N0"
                dc.Visible = True
            Else
                dc.Visible = False
            End If
            dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Next
    End Sub

    Private Sub Armar_Filtro()

        'Dim sfiltro As String = ""
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
        Hacer_Resumen()


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

    Private Sub Guardar_Informacion()

        Dim oform As New frm_columnas
        Dim dc As DataGridViewColumn
        Dim camposactualizar As String = ""
        Dim icount As Integer
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("umbralsa")
        Dim dr As DataRow
        Dim periodo As String
        Dim sfecha As String
        Dim dfecha As Date
        Dim clsGen As New ClasesGenerales.General
        Dim lbmantenerinformacion As Boolean = False

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            otrans.open()

            For Each dc In Me.dg_productos.Columns
                If dc.Name.ToLower.StartsWith("ppto") Then
                    If dc.Visible And dc.ReadOnly = False Then
                        oform.clb_Columnas.Items.Add(dc.HeaderText)
                        ' camposactualizar += dc.Name & ","
                    End If
                End If
            Next


            '        oform.clb_Columnas.Items.AddRange(encabezados_seleccionados.ToString.Split(","))
            oform.Text = ":: Confirme Los Meses Que Desea Actualizar ::"
            oform.ShowDialog()

            For icount = 0 To oform.clb_Columnas.Items.Count - 1
                If oform.clb_Columnas.GetItemChecked(icount) = True Then
                    camposactualizar += giPeriodo.ToString & Obtener_numero_mes(oform.clb_Columnas.Items.Item(icount).ToString).ToString.PadLeft(2, "0") & ","
                End If
            Next



            ''Preguntar Si Borrar Solo Lo Cargado

            Dim dt, dt2, dt3, dtActual, dtdistintos As DataTable
            Dim dtFamiliasActual, dtfamiliasNuevo As DataTable
            Dim dr1 As DataRow

            dtfamiliasNuevo = clsGen.ValoresDistinto(Ods.Tables("ppto_mensual"), "proveedor".Split(","))
            dtdistintos = dtfamiliasNuevo.Copy
            dtdistintos.Rows.Clear()
            dtActual = otrans.Obtiene(ls_sql)
            For Each periodo In camposactualizar.Split(",")
                If periodo.ToString.Length = 6 Then
                    'dt = Ods.Tables("ppto_mensual").Copy
                    'dt.DefaultView.RowFilter = ""
                    'dr.Item("ppto_" & periodo.ToString.Substring(4, 2).ToString).ToString()


                    'If dt3 Is Nothing Then
                    ls_sql = "pa_sel_um_ppt_presupuesto_general '" & gs_empresa & "',NULL,NULL," & periodo.Substring(0, 4)
                    dtActual = otrans.Obtiene(ls_sql)
                    'dtActual.DefaultView.RowFilter = "periodo=" & periodo
                    dt3 = clsGen.ValoresDistinto(dtActual, "subfamilia".Split(","))
                    'End If


                    If Not dt3 Is Nothing Then


                        dtFamiliasActual = clsGen.ValoresDistinto(dt3.DefaultView.ToTable, "subfamilia".Split(","))
                        Dim encontrado As Boolean = False
                        For Each dr2 As DataRow In dtFamiliasActual.Rows
                            For Each dr3 As DataRow In dtfamiliasNuevo.Rows
                                If dr2.Item("subfamilia").ToString.ToLower.Equals(dr3.Item("proveedor").ToString.ToLower) Then
                                    encontrado = True
                                    Exit For
                                End If
                            Next
                            If Not encontrado Then
                                dr1 = dtdistintos.NewRow
                                dr1.Item("proveedor") = dr2.Item("subfamilia")
                                '  dr1.Item("periodo") = periodo
                                dtdistintos.Rows.Add(dr1)
                            End If
                            encontrado = False
                        Next
                    End If

                End If
                Exit For
            Next

            If dtdistintos.Rows.Count > 0 Then
                Dim oform2 As New frm_resultado
                oform2.dgv_resultado.DataSource = dtdistintos
                oform2.Text = "Proveedores No Tomados En Cuenta En Esta Carga"

                oform2.ShowDialog()
                If MessageBox.Show("Desea Mantener La Informacion de Estos Proveedores", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    lbmantenerinformacion = True
                Else
                    lbmantenerinformacion = False
                End If
                'MessageBox.Show("Exiten Proveedores que no se Tomaron en cuenta, Desea Mantener Esa Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            ''debo borrar los meses seleccionados
            For Each periodo In camposactualizar.Split(",")
                If periodo.ToString.Length = 6 Then
                    If lbmantenerinformacion Then
                        For Each dr2 As DataRow In dtfamiliasNuevo.Rows

                            ls_sql = "pa_del_um_ppt_presupuesto_general_subfamilia '" & gs_empresa & "',NULL," & _
                                    periodo & ",'" & dr2.Item("proveedor") & "','" & gs_usuario & "'"
                            otrans.Elimina(ls_sql)


                        Next

                    Else
                        ' MessageBox.Show("Eliminar " & dd)
                        ls_sql = "pa_del_um_ppt_presupuesto_general '" & gs_empresa & "',NULL," & periodo & ",'" & gs_usuario & "'"
                        otrans.Elimina(ls_sql)
                    End If

                End If
            Next



            For Each dr In Ods.Tables("ppto_mensual").Rows

                For Each periodo In camposactualizar.Split(",")
                    If periodo.ToString.Length = 6 Then
                        ' MessageBox.Show("Eliminar " & dd)

                        ls_sql = "pa_ins_um_ppt_presupuesto_general '" & gs_empresa & "','" & dr.Item("codigo") & _
                                "','" & periodo & "'," & dr.Item("ppto_" & periodo.ToString.Substring(4, 2).ToString).ToString & _
                                "," & periodo.Substring(0, 4) & periodo.Substring(0, 4) & _
                                ",'" & gs_usuario & "'"

                        otrans.Ingresa(ls_sql)

                        'If lbmantenerinformacion Then
                        '    For Each dr2 As DataRow In dtdistintos.Rows
                        '        dtActual.DefaultView.RowFilter = "proveedor='" & dr2.Item("proveedor").ToString & "' and periodo = '" & periodo & "'"
                        '        For Each drv As DataRowView In dtActual.DefaultView

                        'ls_sql = "pa_ins_um_ppt_presupuesto_general '" & gs_empresa & "','" & dr.Item("producto") & _
                        '                                "','" & periodo & "'," & _
                        '                                dr.Item("cantidad").ToString & _
                        '                                "," & periodo.Substring(0, 4) & periodo.Substring(0, 4) & _
                        '                                ",'" & gs_usuario & "'"

                        'otrans.Ingresa(ls_sql)



                        '                    Next


                        'Next

                        '            End If


                    End If



                Next


            Next

            If giPeriodo > Now.Year Then
                For Each periodo In camposactualizar.Split(",")
                    If periodo.ToString.Length = 6 Then
                        sfecha = "01/" & periodo.ToString.Substring(4, 2).ToString & "/" & periodo.ToString.Substring(0, 4).ToString
                        dfecha = Date.Parse(sfecha)

                        ls_sql = "pa_ins_um_ppt_periodo " & periodo & "," & giPeriodo & ",'" & dfecha.ToString("yyyy-MM-dd") & "','" & _
                                dfecha.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") & "'"
                        otrans.Ingresa(ls_sql)

                    End If

                Next

            End If
            oform = Nothing
            MessageBox.Show("Proceso Finalizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub Hacer_Total_Detalle()

        Dim dr As DataRow
        Dim dc As DataColumn
        Dim totallinea As Integer

        For Each dr In Ods.Tables("ppto_mensual").Rows
            totallinea = 0

            For Each dc In Ods.Tables("ppto_mensual").Columns

                If dc.ColumnName.StartsWith("ppto") And dr.Item(dc.ColumnName).ToString.Length > 0 Then
                    totallinea += dr.Item(dc.ColumnName)
                End If
            Next
            dr.Item("total") = totallinea
        Next



    End Sub
    Private Sub Hacer_Resumen()
        Dim dr2 As DataRow
        Dim icount, itotal, total_general As Integer
        Dim sname As String

        Try


            Ods.Tables("resumen_ppto_mensual").Rows.Clear()
            dr2 = Ods.Tables("resumen_ppto_mensual").NewRow
            For icount = 1 To 12
                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                dr2.Item(sname) = 0
            Next


            For icount = 1 To 12
                sname = "ppto_" & icount.ToString.PadLeft(2, "0")
                Try
                    itotal = Ods.Tables("ppto_mensual").Compute("Sum(" & sname & ")", _sfiltro)
                    dr2.Item(sname) += itotal
                    total_general += itotal
                Catch ex As Exception
                End Try
            Next
            dr2.Item("total") = total_general
            Ods.Tables("resumen_ppto_mensual").Rows.Add(dr2)

        Catch ex As Exception
        Finally
            Me.dg_resumen.DataSource = Ods.Tables("resumen_ppto_mensual").DefaultView
            Maquillar_Resumen()
        End Try
    End Sub

    Private Function verificarInformacion() As Boolean

    End Function


    Private Sub frm_carga_presupuesto_general_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Me.cmb_operadores.SelectedItem = 1
    End Sub

    Private Sub dg_productos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellEnter
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try

            If colIndex = 2 Then
                If Me.dg_productos.Item(colIndex - 1, rowIndex).Value.ToString.Trim > 0 Then
                    SendKeys.Send("{Tab}")
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dg_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dg_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try


            'Me.dg_productos.Columns("vigente").Visible = True
            If rowIndex >= 0 And colIndex = 0 Then
                Dim therow As DataGridViewRow
                therow = Me.dg_productos.Rows(rowIndex)
                If therow.Cells(colIndex).Value.ToString() = "N" Then
                    therow.DefaultCellStyle.ForeColor = Color.Red

                End If

            End If
            Me.dg_productos.Columns(0).Width = 10
            'Me.dg_productos.Columns("vigente").Visible = False
        Catch ex As Exception
        End Try

    End Sub


    Private Sub dg_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        If rowIndex >= 0 And colIndex = 0 Then
            Dim therow As DataGridViewRow
            therow = Me.dg_productos.Rows(rowIndex)
            If therow.Cells(colIndex).Value.ToString() = "N" Then
                therow.DefaultCellStyle.BackColor = Color.Red
            End If

        End If

        If colIndex = 3 Then
            Dim c As Control = Me.dg_productos.EditingControl
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
                Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
                Me.dg_productos.Item(e.ColumnIndex + 1, e.RowIndex).Value = dt.Rows(0).Item("Glosa").ToString
                Me.dg_productos.Item(e.ColumnIndex - 1, e.RowIndex).Value = dt.Rows(0).Item("tipo").ToString
                Me.dg_productos.Item(e.ColumnIndex - 2, e.RowIndex).Value = dt.Rows(0).Item("subfamilia").ToString
                Me.dg_productos.Item(e.ColumnIndex - 3, e.RowIndex).Value = dt.Rows(0).Item("Vigente").ToString
            Else
                MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                Me.dg_productos.Item(e.ColumnIndex + 1, e.RowIndex).Value = ""
                Me.dg_productos.Item(e.ColumnIndex - 1, e.RowIndex).Value = ""

            End If
        End If

        Try
            Me.dg_productos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
            If colIndex >= 5 Then
                Hacer_Resumen()
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Ods.Tables("ppto_mensual").Rows.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Guardar Los Cambios " & Chr(13) & "Este proceso Eliminar la Informacion Anterior", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '          If verificarInformacion Then
                Guardar_Informacion()
                '          End If
            End If
        Else
            MessageBox.Show("No Se Puede Guardar Informacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Armar_Filtro()
    End Sub

    Private Sub txt_texto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_texto.KeyPress
        If e.KeyChar = Chr(13) Then
            Armar_Filtro()
        End If

    End Sub

    Private Sub dg_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellContentClick

    End Sub
End Class