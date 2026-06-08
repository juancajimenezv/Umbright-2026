Imports System.Text
Public Class frm_carga_presupuesto_comercial
    Dim encabezados_seleccionados As String = ""
    Dim _dtregistros As DataTable
    Dim _dtintegracion, _dtlogdetalle As DataTable
    Dim _dtresumen As DataTable
    Dim dt_producto As DataTable
    'Dim gs_empresa As String = "DMARTE1"



    Private Sub crearEstructura()

        _dtintegracion = New DataTable("clientes")

        _dtintegracion.Columns.Add(New DataColumn("producto", GetType(String)))
        _dtintegracion.Columns.Add(New DataColumn("glosa", GetType(String)))
        _dtintegracion.Columns.Add(New DataColumn("cliente", GetType(String)))
        _dtintegracion.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        _dtintegracion.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        _dtintegracion.Columns.Add(New DataColumn("precio_unitario", GetType(Double)))
        _dtintegracion.Columns.Add(New DataColumn("precio_total", GetType(Double)))
        _dtintegracion.PrimaryKey = New DataColumn() {_dtintegracion.Columns(0), _dtintegracion.Columns(2)}
        '_dtintegracion.Columns(0).Unique = True
        '_dtintegracion.Columns(2).Unique = True

        _dtlogdetalle = New DataTable("detalle_log")
        _dtlogdetalle.Columns.Add(New DataColumn("tipo", GetType(String)))
        _dtlogdetalle.Columns.Add(New DataColumn("descripcion", GetType(String)))

        _dtresumen = New DataTable("resumen")
        _dtresumen.Columns.Add(New DataColumn("producto", GetType(String)))
        _dtresumen.Columns.Add(New DataColumn("glosa", GetType(String)))
        _dtresumen.Columns.Add(New DataColumn("cantidad_comercial", GetType(Integer)))
        _dtresumen.Columns.Add(New DataColumn("cantidad_mercadeo", GetType(Integer)))
        _dtresumen.Columns.Add(New DataColumn("diferencia", GetType(Integer)))


    End Sub
    Private Sub Procesar_Excel()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados() As String


        Dim icount As Integer

        'Dim dr, dr_aux As DataRow

        Try
            Me.OFD_Productos.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OFD_Productos.FileName = ""
            Me.OFD_Productos.ShowDialog()

            snombre_archivo = Me.OFD_Productos.FileName
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
            'ReDim hojas_encabezados(7)


            Dim listaencabezado As New StringBuilder
            For Each encabezado As String In hojas_encabezados
                If Not encabezado Is Nothing Then listaencabezado.Append("," & encabezado)
            Next
            encabezados_seleccionados = listaencabezado.ToString


            'Dim oform As New frm_columnas

            'oform.clb_Columnas.Items.AddRange(hojas_encabezados)
            'For icount = 0 To oform.clb_Columnas.Items.Count - 1
            '    If oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("prod") Then
            '        oform.clb_Columnas.Items.Item(icount) += " "
            '        oform.clb_Columnas.SetItemChecked(icount, True)
            '    ElseIf oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("desc") Then
            '        oform.clb_Columnas.Items.Item(icount) += " "
            '        oform.clb_Columnas.SetItemChecked(icount, True)
            '    Else
            '        oform.clb_Columnas.Items.Item(icount) += " " & gi_periodo.ToString & _
            '                    Obtener_numero_mes(oform.clb_Columnas.Items.Item(icount).ToString).ToString.PadLeft(2, "0")
            '        oform.clb_Columnas.SetItemChecked(icount, True)

            '    End If
            'Next

            'oform.ShowDialog()
            'oform.clb_Columnas.SetItemChecked(0, True)
            'oform.clb_Columnas.SetItemChecked(1, True)
            'For icount = 0 To oform.clb_Columnas.Items.Count - 1
            '    If oform.clb_Columnas.GetItemChecked(icount) = True Then
            '        encabezados_seleccionados += "," & oform.clb_Columnas.Items.Item(icount).ToString.Substring(0, oform.clb_Columnas.Items(icount).ToString.IndexOf(" "))
            '    End If
            'Next
            'oform = Nothing

            Oaut.pNombreColumnas = encabezados_seleccionados
            '            Me.Label1.Text = Now()

            _dtregistros = Oaut.obtener_registros_nombres()
            ' Me.dgv_detalle.DataSource = _dtregistros

            '           Me.Label2.Text = Now()

        Catch ex As Exception
        Finally
            Oaut.Cerrar_libro()

            Oaut = Nothing
        End Try

    End Sub

    Private Sub Asignar_NombresProductosClientes()
        Dim dr_aux, dr_log As DataRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim umOtrans As New Transaccional.Conexion("Umbralsa")
        Dim dt_cliente, dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim lbrestringida, lbnoexiste, lbsinprecio As Boolean

        Try
            Otrans.open()
            umOtrans.open()
            dt = ClsGen.ValoresDistinto(_dtregistros, _dtregistros.Columns(0).ColumnName.Split(","))

            If dt.Rows.Count <> 1 Then
                MessageBox.Show("No Se Puede Procesar Mas de Un Periodo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dt.Rows.Count = 1 Then Me.lbl_periodo.Text = dt.Rows(0).Item(0)


            'dt = umOtrans.Obtiene("Select top 1 * from integracion where empresa = '" & gs_empresa & "' and glb_prd_id  = " & Me.lbl_periodo.Text)
            'If dt.Rows.Count > 0 Then
            '    MessageBox.Show("El Periodo No se Puede Cargar, Ya Existen Datos Asignados", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            dt_producto = Otrans.Obtiene("pa_sel_um_producto '" & gs_empresa & "'")
            dt_cliente = Otrans.Obtiene("pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE'")
            For Each dr As DataRow In _dtregistros.Rows
                lbnoexiste = False
                lbrestringida = False
                lbsinprecio = False

                dr_aux = _dtintegracion.NewRow
                dr_aux.Item("producto") = dr.Item("producto")
                dt_producto.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                If dt_producto.DefaultView.Count > 0 Then
                    dr_aux.Item("glosa") = dt_producto.DefaultView(0)("glosa")
                Else
                    dr_aux.Item("glosa") = "Producto No Existe"
                End If

                dr_aux.Item("cliente") = dr.Item("cliente")
                dt_cliente.DefaultView.RowFilter = "ctacte = '" & dr.Item("cliente") & "'"
                If dt_cliente.DefaultView.Count > 0 Then
                    dr_aux.Item("nombre_cliente") = dt_cliente.DefaultView(0)("nombre_cliente")
                Else
                    dr_aux.Item("nombre_cliente") = "Cliente No Existe"
                    lbnoexiste = True
                End If



                Try
                    dr_aux.Item("cantidad") = Integer.Parse(dr.Item("cantidad").ToString)
                Catch ex As Exception
                    dr_aux.Item("cantidad") = Double.Parse(dr.Item("cantidad"))
                End Try

                dr_aux.Item("precio_unitario") = Double.Parse(dr.Item(6).ToString) 'Double.Parse(dr.Item("preciou").ToString)
                dr_aux.Item("precio_total") = dr_aux.Item("cantidad") * dr_aux.Item("precio_unitario")

                Try
                    If Not lbnoexiste Then
                        If dr_aux.Item("precio_unitario") < 1 Then
                            lbsinprecio = True
                        Else
                            _dtintegracion.Rows.Add(dr_aux)
                        End If
                    End If


                Catch ex As Exception
                    lbrestringida = True



                End Try
                If lbrestringida Then
                    dr_log = _dtlogdetalle.NewRow
                    dr_log.Item("tipo") = "Repetida"
                    dr_log.Item("descripcion") = "Producto " & dr_aux.Item("producto") & "-" & dr_aux.Item("glosa") & " cliente " & dr_aux.Item("cliente").ToString & "-" & dr_aux.Item("nombre_cliente")
                    _dtlogdetalle.Rows.Add(dr_log)
                End If
                If lbnoexiste Then
                    dr_log = _dtlogdetalle.NewRow
                    dr_log.Item("tipo") = "No Existe"
                    dr_log.Item("descripcion") = "Producto " & dr_aux.Item("producto") & "-" & dr_aux.Item("glosa") & " cliente " & dr_aux.Item("cliente").ToString & "-" & dr_aux.Item("nombre_cliente")
                    _dtlogdetalle.Rows.Add(dr_log)

                End If
                If lbsinprecio Then
                    dr_log = _dtlogdetalle.NewRow
                    dr_log.Item("tipo") = "Sin Precio"
                    dr_log.Item("descripcion") = "Producto " & dr_aux.Item("producto") & "-" & dr_aux.Item("glosa") & " cliente " & dr_aux.Item("cliente").ToString & "-" & dr_aux.Item("nombre_cliente")
                    _dtlogdetalle.Rows.Add(dr_log)
                End If




            Next


        Catch ex As Exception
        Finally
            Me.dgv_detalle.DataSource = _dtintegracion
            ClsGen.Alinear_GridView(_dtintegracion, Me.dgv_detalle, "", "", ",glosa,nombre_cliente,precio_total,", "", "", "", "", True, True, 250, 0)
            Me.dgv_log.DataSource = _dtlogdetalle
            ClsGen.Alinear_GridView(_dtlogdetalle, Me.dgv_log, "", "", "", "", "", "", "", False, True, 300, 0)
            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing
            umOtrans.close()
            umOtrans = Nothing
        End Try



    End Sub

    Private Sub generar_resumen()
        Dim dt, dt_ppto As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dr_aux As DataRow
        Dim icomercial As Integer

        Try
            Otrans.open()
            dt_ppto = Otrans.Obtiene("pa_sel_um_ppt_presupuesto_general '" & gs_empresa & "'," & Me.lbl_periodo.Text)
            dt = ClsGen.ValoresDistinto(_dtintegracion, "producto,glosa".Split(","))

            For Each dr As DataRow In dt.Rows
                dr_aux = _dtresumen.NewRow
                dr_aux.Item("producto") = dr.Item("producto")
                dr_aux.Item("glosa") = dr.Item("glosa")

                icomercial = _dtintegracion.Compute("Sum(cantidad)", "producto = '" & dr.Item("producto") & "'")
                dr_aux.Item("cantidad_comercial") = icomercial

                dt_ppto.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                If dt_ppto.DefaultView.Count = 1 Then
                    dr_aux.Item("cantidad_mercadeo") = dt_ppto.DefaultView(0)("cantidad").ToString
                Else
                    dr_aux.Item("cantidad_mercadeo") = 0
                End If

                dr_aux.Item("diferencia") = dr_aux.Item("cantidad_mercadeo") - dr_aux.Item("cantidad_comercial")

                _dtresumen.Rows.Add(dr_aux)
            Next

            dgv_resumen.DataSource = _dtresumen
            ClsGen.Alinear_GridView(_dtresumen, Me.dgv_resumen, "", "", "", "", "", "", "", True, True, 250, 0)

            icomercial = _dtresumen.Compute("Sum(cantidad_comercial)", "cantidad_comercial<>0")
            Me.lbl_TotalComercial.Text = icomercial
            icomercial = _dtresumen.Compute("Sum(cantidad_mercadeo)", "cantidad_mercadeo<>0")
            Me.lbl_totalMercadeo.Text = icomercial
            Me.lbl_diferencia.Text = Val(Me.lbl_totalMercadeo.Text) - Val(Me.lbl_TotalComercial.Text)


        Catch ex As Exception
        Finally
            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    'Private Sub Procesar_tabla(ByVal _dt As DataTable, ByVal encabezados_seleccionados As String)
    '    Dim ls_sql As String

    '    Dim dr, dr_aux As DataRow
    '    Dim dc As DataColumn
    '    Dim dt As DataTable
    '    Dim oTrans As New Transaccional.Conexion("flexline")
    '    Ods.Tables("ppto_mensual").Rows.Clear()

    '    Try
    '        oTrans.open()

    '        For Each dr In _dt.Rows
    '            ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & dr.Item(0) & "'"
    '            dt = oTrans.Obtiene(ls_sql)

    '            If dt.Rows.Count > 0 Then
    '                Try


    '                    dr_aux = Ods.Tables("ppto_mensual").NewRow
    '                    dr_aux.Item("vigente") = dt.Rows(0).Item("vigente").ToString
    '                    dr_aux.Item("proveedor") = dt.Rows(0).Item("subfamilia").ToString
    '                    dr_aux.Item("marca") = dt.Rows(0).Item("tipo").ToString
    '                    dr_aux.Item("codigo") = dr.Item(0)
    '                    dr_aux.Item("descripcion") = dt.Rows(0).Item("glosa").ToString
    '                    dr_aux.Item("UxC") = dt.Rows(0).Item("FactorAlt")

    '                    For Each dc In _dt.Columns
    '                        Select Case dc.ColumnName.ToString.ToLower.Substring(0, 3)
    '                            Case "pro"
    '                                dr_aux.Item("codigo") = dr.Item(dc.ColumnName).ToString
    '                            Case "glo"
    '                                dr_aux.Item("descripcion") = dr.Item(dc.ColumnName).ToString
    '                            Case "ene"
    '                                dr_aux.Item("ppto_01") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "feb"
    '                                dr_aux.Item("ppto_02") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "mar"
    '                                dr_aux.Item("ppto_03") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "abr"
    '                                dr_aux.Item("ppto_04") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "may"
    '                                dr_aux.Item("ppto_05") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "jun"
    '                                dr_aux.Item("ppto_06") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "jul"
    '                                dr_aux.Item("ppto_07") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "ago"
    '                                dr_aux.Item("ppto_08") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "sep"
    '                                dr_aux.Item("ppto_09") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "oct"
    '                                dr_aux.Item("ppto_10") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "nov"
    '                                dr_aux.Item("ppto_11") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                            Case "dic"
    '                                dr_aux.Item("ppto_12") = Double.Parse(dr.Item(dc.ColumnName).ToString)
    '                        End Select
    '                    Next

    '                    Ods.Tables("ppto_mensual").Rows.Add(dr_aux)
    '                Catch ex As Exception
    '                    'MessageBox.Show(ex.Message & dr.Item(1))
    '                End Try
    '            End If

    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        oTrans.close()
    '        oTrans = Nothing
    '        Me.dg_productos.DataSource = Ods.Tables("ppto_mensual")
    '        Mostrar_Meses(encabezados_seleccionados)

    '    End Try


    'End Sub

    Private Sub Guardar_Presupuesto_Cliente()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim lb_errores As Boolean = False

        Try
            Otrans.open()
            '(c)221210 se quito x correo enviado por ggiron a pplamport
            'If Val(Me.lbl_diferencia.Text) > 0 Then
            '    MessageBox.Show("Este Presupuesto No se Puede Guardar No Cumple con lo establecido por Mercadeo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            '_dtresumen.DefaultView.RowFilter = "diferencia > 0"
            'If _dtresumen.Rows.Count > 0 Then
            '    MessageBox.Show(" No se Puede Guardar, Existen Productos Por Debajo de lo Establecido por Mercadeo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            For Each dr As DataRow In _dtintegracion.Rows


                If dr.Item("cantidad") > 0 Then
                    ls_sql = "pa_ins_um_integracion '" & gs_empresa & "','" & dr.Item("producto").ToString & "','" & dr.Item("cliente").ToString & "'," & _
                        lbl_periodo.Text & "," & _
                        giPeriodo.ToString & giPeriodo.ToString & "," & _
                        dr.Item("cantidad") & "," & dr.Item("precio_unitario").ToString & "," & dr.Item("precio_total")
                    Otrans.Ingresa(ls_sql)

                    If otrans.Codigo_error > 0 Then
                        'MessageBox.Show("Problemas Al Actualizar " & dr.Item("producto") & Chr(13) & otrans.descripcion_error, "Insertar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        lb_errores = True
                    End If
                End If
            Next
            If lb_errores Then
                MessageBox.Show("La Actualizacion Finalizo Con Problemas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Proceso Realizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            _dtresumen.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_obtener_excel.Click
        Try
            Me.btn_obtener_excel.Enabled = False
            crearEstructura()
            Procesar_Excel()
            Asignar_NombresProductosClientes()
            'generar_resumen()
        Catch ex As Exception
        Finally
            Me.btn_obtener_excel.Enabled = True

        End Try
        
    End Sub

    Private Sub dgv_resumen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_resumen.CellContentClick

    End Sub

    Private Sub dgv_resumen_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_resumen.CellPainting


        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim sname As String = "diferencia"

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = dgv_resumen.Rows(rowIndex)
                If therow.Cells("diferencia").Value.ToString() > 0 Then
                    therow.Cells(sname).Style.BackColor = Color.Coral
                ElseIf therow.Cells("diferencia").Value.ToString() < 0 Then
                    therow.Cells(sname).Style.BackColor = Color.Yellow
                ElseIf therow.Cells("diferencia").Value.ToString() = 0 Then
                    therow.Cells(sname).Style.BackColor = Color.White
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro de Cargar el Presupuesto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                btn_guardar.Enabled = False
                Guardar_Presupuesto_Cliente()
            Catch ex As Exception
            Finally
                btn_guardar.Enabled = True
            End Try
        End If
    End Sub

    Private Sub frm_carga_presupuesto_comercial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text += " Periodo " & giPeriodo
        cb_Bu.Enabled = False
        cb_BuPeriodo.Enabled = False
        Me.btn_Borrar.Text = "Activar"
        Me.btn_BuCancelar.Enabled = False

        bt_Borrar.Visible = False
        cb_Canal.Visible = False
        cb_Periodo.Visible = False
        l_canal.Visible = False
        l_periodo.Visible = False
        btn_Cancela.Visible = False

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub
    Private Sub Cancela_Borrado()

        btn_Borra_x_Canal.Enabled = True
        bt_Borrar.Visible = False
        cb_Canal.Visible = False
        cb_Periodo.Visible = False
        l_canal.Visible = False
        l_periodo.Visible = False
        btn_Cancela.Visible = False

    End Sub
        

    Private Sub btn_Borra_x_Canal_Click(sender As Object, e As EventArgs) Handles btn_Borra_x_Canal.Click
        If MessageBox.Show("Esta Seguro de Borrar Presupuesto Comercial x Canal?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                btn_Borra_x_Canal.Enabled = False
                Borra_x_Canal()

            Catch ex As Exception
            Finally
                btn_guardar.Enabled = True
            End Try
        Else
            Cancela_Borrado()
        End If
    End Sub

    Private Sub Borra_x_Canal()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim umOtrans As New Transaccional.Conexion("Umbralsa")
        umOtrans.open()

        bt_Borrar.Visible = True
        cb_Canal.Visible = True
        cb_Periodo.Visible = True
        l_canal.Visible = True
        l_periodo.Visible = True
        bt_Borrar.Enabled = True
        btn_Cancela.Visible = True
        
        
        ls_SqlScript = "spa_Gen_Canales '" & gs_empresa & "'"
        ldt_table = umOtrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Canal"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Canal.DisplayMember = "texto2"
        Me.cb_Canal.ValueMember = "texto2"
        Me.cb_Canal.DataSource = ldt_table


        ls_SqlScript = "spa_Periodo_Presupuesto_Comercial'" & gs_empresa & "'"
        ldt_table = umOtrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Periodo"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Periodo.DisplayMember = "Periodo"
        Me.cb_Periodo.ValueMember = "Periodo"
        Me.cb_Periodo.DataSource = ldt_table

    End Sub

    Private Sub bt_Borrar_Click(sender As Object, e As EventArgs) Handles bt_Borrar.Click
        If MessageBox.Show("Esta Seguro de Borrar Presupuesto Comercial x Canal? Tome En Cuenta Que No Tiene Reversión", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                btn_Borra_x_Canal.Enabled = False
                Borrar()
            Catch ex As Exception
            Finally
                btn_Borra_x_Canal.Enabled = True
                bt_Borrar.Enabled = False

                bt_Borrar.Visible = False
                cb_Canal.Visible = False
                cb_Periodo.Visible = False
                l_canal.Visible = False
                l_periodo.Visible = False
                btn_Cancela.Visible = False
                btn_Borra_x_Canal.Enabled = True

            End Try
        Else
            bt_Borrar.Visible = False
            cb_Canal.Visible = False
            cb_Periodo.Visible = False
            l_canal.Visible = False
            l_periodo.Visible = False
            btn_Cancela.Visible = False
            btn_Borra_x_Canal.Enabled = True

        End If
    End Sub

    Private Sub Borrar()

        Dim Utrans As New Transaccional.Conexion("UMBRALSA")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            Utrans.open()
            ls_sql = " spa_Borra_Presupuesto_Comercial_Canal '" & gs_empresa & "','" & cb_Periodo.Text & "','" & cb_Canal.Text & "','BORRAR'"
            Utrans.Obtiene(ls_sql)
            MsgBox("Datos Borrados Exitosamente!, Puede Volver a Subir Presupuesto!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_Cancela_Click(sender As Object, e As EventArgs) Handles btn_Cancela.Click
        Cancela_Borrado()
    End Sub

    Private Sub btn_Borrar_Click(sender As Object, e As EventArgs) Handles btn_Borrar.Click

        If btn_Borrar.Text = "Activar" Then

            If MsgBox("Desea Activar La Opción de Borrar Presupuesto Por Bu?", MsgBoxStyle.YesNo, "Activar") = MsgBoxResult.Yes Then
                Activar()
            Else
                Desactivar()
            End If

        ElseIf btn_Borrar.Text = "Borrar" Then
            If MsgBox("Desea Borrar Presupuesto de " & cb_Bu.Text & " Del Periodo " & cb_BuPeriodo.Text & " ?, Recuerde Que esta Operación No Tiene Reversión....", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Borrar_Bu()
            Else
                Desactivar()
            End If
        End If

    End Sub

    Private Sub Activar()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim umOtrans As New Transaccional.Conexion("Umbralsa")
        umOtrans.open()

        Try
            cb_Bu.Enabled = True
            cb_BuPeriodo.Enabled = True

            ls_SqlScript = "pa_vb_Bu '" & gs_empresa & "'"
            ldt_table = umOtrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Bu"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_Bu.DisplayMember = "Bu"
            Me.cb_Bu.ValueMember = "Bu"
            Me.cb_Bu.DataSource = ldt_table

            ls_SqlScript = "spa_Periodo_Presupuesto_Comercial'" & gs_empresa & "'"
            ldt_table = umOtrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Periodo"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_BuPeriodo.DisplayMember = "Periodo"
            Me.cb_BuPeriodo.ValueMember = "Periodo"
            Me.cb_BuPeriodo.DataSource = ldt_table
            btn_Borrar.Text = "Borrar"
            btn_BuCancelar.Enabled = True
        Catch ex As Exception

        Finally
            umOtrans.close()
            umOtrans = Nothing
        End Try
    End Sub

    Private Sub Desactivar()
        cb_Bu.Enabled = False
        cb_BuPeriodo.Enabled = False
        btn_BuCancelar.Enabled = False
        btn_Borrar.Text = "Activar"
    End Sub

    Private Sub Borrar_Bu()
        Dim Utrans As New Transaccional.Conexion("UMBRALSA")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            Utrans.open()
            ls_sql = " pa_vb_Borra_Presupuesto_Bu '" & gs_empresa & "','" & cb_BuPeriodo.Text & "','" & cb_Bu.Text & "'"
            Utrans.Obtiene(ls_sql)
            MsgBox("Datos Borrados Exitosamente!, Puede Volver a Subir Presupuesto!!", MsgBoxStyle.MsgBoxSetForeground, "Borrar")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
            Desactivar()
        End Try

    End Sub

    Private Sub btn_BuCancelar_Click(sender As Object, e As EventArgs) Handles btn_BuCancelar.Click
        Desactivar()
    End Sub


End Class